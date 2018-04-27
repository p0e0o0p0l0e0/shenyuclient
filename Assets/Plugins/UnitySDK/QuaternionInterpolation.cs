using System;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionInterpolation
{
	public Quaternion Value { get { return _currentValue; } }
	public float Accelerate { get { return _accelerate; } set { _accelerate = ViMathDefine.Max(0.0f, value); } }
	public float MinSpeed { get { return _minSpeed; } set { _minSpeed = ViMathDefine.Max(0.0f, value); } }
	public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = ViMathDefine.Max(0.0f, value); } }
	public float CurrentSpeed { get { return _currentSpeed; } }
	public bool IsFiltering { get { return (_currentSpeed != 0.0f); } }
	public bool Update(Quaternion desireValue, float delatTime)
	{
		float diffLen = Quaternion.Angle(desireValue, _currentValue);
		if (diffLen == 0.0f)
		{
			return false;
		}
		float newSpeed = _currentSpeed + _accelerate * delatTime;
		float brakingSpeed = ViMathDefine.Sqrt(diffLen * _accelerate * 2.0f);
		_currentSpeed = ViMathDefine.Min(ViMathDefine.Clamp(newSpeed, _minSpeed, _maxSpeed), brakingSpeed);
		float frontDistance = _currentSpeed * delatTime;
		if (frontDistance > diffLen)
		{
			_currentValue = desireValue;
			_currentSpeed = 0.0f;
		}
		else
		{
			_currentValue = Quaternion.Lerp(_currentValue, desireValue, frontDistance / diffLen);
		}
		return true;
	}
	public void StopAt(Quaternion value)
	{
		_currentValue = value;
		_currentSpeed = 0.0f;
	}

	public void SetSample(float distance, float duration)
	{
		float avgSpeed = distance / duration;
		// 0.2 -> 1.9 -> 0.0, avg = 1.0
		_minSpeed = avgSpeed * 0.2f;
		_maxSpeed = avgSpeed * 1.9f;
		_accelerate = (2.0f * _maxSpeed - _minSpeed) / duration;
	}

	float _accelerate = 2.0f;
	float _currentSpeed = 0.0f;
	float _minSpeed = 0.0f;
	float _maxSpeed = 4.0f;
	Quaternion _currentValue;
}

public class QuaternionInterpolation_Loop
{
	public float Accelerate { get { return _accelerate; } set { _accelerate = Math.Max(0.0f, value); } }
	public float MinSpeed { get { return _minSpeed; } set { _minSpeed = ViMathDefine.Max(0.0f, value); } }
	public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = Math.Max(0.0f, value); } }
	public float CurrentSpeed { get { return _currentSpeed; } }
	public Quaternion Value { get { return _currentValue; } }
	public bool IsFiltering { get { return (_currentSpeed != 0.0f); } }

	public bool Update(Quaternion from, Quaternion to, float delatTime)
	{
		 Quaternion desireValue = _foward ? to : from;
		float diffLen = Quaternion.Angle(desireValue, _currentValue);
		float newSpeed = _currentSpeed + _accelerate * delatTime;
		float brakingSpeed = ViMathDefine.Sqrt(diffLen * _accelerate * 2.0f);
		_currentSpeed = ViMathDefine.Min(ViMathDefine.Clamp(newSpeed, _minSpeed, _maxSpeed), brakingSpeed);
		float frontDistance = _currentSpeed * delatTime;
		if (frontDistance > diffLen || diffLen == 0f)
		{
			_currentValue = desireValue;
			_currentSpeed = 0.0f;
			//
			_foward = !_foward;
		}
		else
		{
			_currentValue = Quaternion.Lerp(_currentValue, desireValue, frontDistance / diffLen);
		}
		return true;
	}
	public void StopAt(Quaternion value)
	{
		_currentValue = value;
		_currentSpeed = 0.0f;
	}

	public void SetSample(float distance, float duration)
	{
		float avgSpeed = distance / duration;
		// 0.2 -> 1.9 -> 0.0, avg = 1.0
		_minSpeed = avgSpeed * 0.2f;
		_maxSpeed = avgSpeed * 1.9f;
		_accelerate = (2.0f * _maxSpeed - _minSpeed) / duration;
		_foward = true;
	}

	float _accelerate = 2.0f;
	float _currentSpeed = 0.0f;
	float _minSpeed = 0.0f;
	float _maxSpeed = 4.0f;
	Quaternion _currentValue;
	bool _foward = true;
}