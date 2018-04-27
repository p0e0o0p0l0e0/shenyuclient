using System;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Interpolation
{
	public float Accelerate { get { return _accelerate; } set { _accelerate = ViMathDefine.Max(0.0f, value); } }
	public float MinSpeed { get { return _minSpeed; } set { _minSpeed = ViMathDefine.Max(0.0f, value); } }
	public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = ViMathDefine.Max(0.0f, value); } }
	public float TimeScale { get { return _timeScale; } set { _timeScale = ViMathDefine.Max(0.0f, value); } }
	public float CurrentSpeed { get { return _currentSpeed; } }
	public Vector3 Value { get { return _currentValue; } }
	public bool IsFiltering { get { return (_currentSpeed != 0.0f); } }
	public bool Update(Vector3 desireValue, float deltaTime)
	{
		Vector3 diff = desireValue - _currentValue;
		float diffLen = diff.magnitude;
		if (diffLen == 0.0f)
		{
			return false;
		}
		deltaTime *= TimeScale;
		float newSpeed = _currentSpeed + _accelerate * deltaTime;
		float brakingSpeed = ViMathDefine.Sqrt(diffLen * _accelerate * 2.0f);
		_currentSpeed = ViMathDefine.Min(ViMathDefine.Clamp(newSpeed, _minSpeed, _maxSpeed), brakingSpeed);
		float frontDistance = _currentSpeed * deltaTime;
		if (frontDistance > diffLen)
		{
			_currentValue = desireValue;
			_currentSpeed = 0.0f;
		}
		else
		{
			Vector3 delatDist = frontDistance * diff.normalized;
			_currentValue += delatDist;
		}
		return true;
	}
	public void StopAt(Vector3 fDistance)
	{
		_currentValue = fDistance;
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
	float _timeScale = 1.0f;
	Vector3 _currentValue;
}

public class Vector3Interpolation_Spring
{
	public Vector3 Value { get { return _currentValue; } }
	public float SpringRate { get { return _springRate; } }
	public float TimeScale { get { return _timeScale; } }
	public Vector3 CurrentSpeed { get { return _currentSpeed; } }
	public Vector3 Accelerate { get { return _accelerate; } }
	public bool IsFiltering { get { return (_currentSpeed != Vector3.zero); } }

	public void Init(float spirngRate, float speedFriction, float timeScale)
	{
		Init(spirngRate, speedFriction, timeScale, 5);
	}
	public void Init(float spirngRate, float speedFriction, float timeScale, int sprintCount)
	{
		_springRate = spirngRate;
		_speedFriction = speedFriction;
		_timeScale = timeScale;
		_sprintCount = sprintCount;
	}
	public bool Update(Vector3 destValue, float deltaTime)
	{
		if (destValue == _currentValue && _currentSpeed == Vector3.zero)
		{
			return false;
		}
		float span = 0.003f;
		while (deltaTime > span)
		{
			_Update(destValue, span);
			deltaTime -= span;
		}
		//
		_Update(destValue, deltaTime);
		//
		if (_sprintCount <= 0)
		{
			_currentValue = destValue;
			_currentSpeed = Vector3.zero;
			_accelerate = Vector3.zero;
		}
		//
		return true;
	}
	
	void _Update(Vector3 destValue, float deltaTime)
	{
		Vector3 diff = destValue - _currentValue;
		float diffLen = diff.magnitude;
		deltaTime *= _timeScale;
		Vector3 diffNormal = diff.normalized;
		float sprintForce = _springRate * diffLen;
		_accelerate = diffNormal * sprintForce - _currentSpeed * _speedFriction;
		_currentSpeed = _currentSpeed + _accelerate * deltaTime;
		Vector3 oldValue = _currentValue;
		_currentValue += _currentSpeed * deltaTime;
		if (IsCross(destValue, oldValue, _currentValue))
		{
			--_sprintCount;
		}
	}

	public void StopAt(Vector3 value)
	{
		_currentValue = value;
		_currentSpeed = Vector3.zero;
		_accelerate = Vector3.zero;
	}

	static bool IsCross(Vector3 root, Vector3 oldPos, Vector3 newPos)
	{
		Vector3 oldDir = oldPos - root;
		Vector3 newDir = newPos - root;
		return Vector3.Dot(oldDir, newDir) < 0;
	}

	float _springRate = 20.0f;
	Vector3 _currentSpeed;
	Vector3 _currentValue;
	float _speedFriction = 3.0f;
	float _timeScale = 1.0f;
	Vector3 _accelerate;
	int _sprintCount;
	//质量=1.0
}


public class ViVector3Interpolation_Spring
{
	public ViVector3 Value { get { return _currentValue; } }
	public float SpringRate { get { return _springRate; } }
	public float TimeScale { get { return _timeScale; } }
	public ViVector3 CurrentSpeed { get { return _currentSpeed; } }
	public ViVector3 Accelerate { get { return _accelerate; } }
	public bool IsFiltering { get { return (_currentSpeed != ViVector3.ZERO); } }

	public void Init(float spirngRate, float speedFriction, float timeScale, ViVector3 speed, int sprintCount)
	{
		_springRate = spirngRate;
		_speedFriction = speedFriction;
		_timeScale = timeScale;
		_sprintCount = sprintCount;
		_currentSpeed = speed;
	}

	public bool Update(ViVector3 destValue, float deltaTime)
	{
		if (destValue == _currentValue && _currentSpeed == ViVector3.ZERO)
		{
			return false;
		}
		float span = 0.003f;
		while (deltaTime > span)
		{
			_Update(destValue, span);
			deltaTime -= span;
		}
		//
		_Update(destValue, deltaTime);
		//
		if (_sprintCount <= 0)
		{
			_currentValue = destValue;
			_currentSpeed = ViVector3.ZERO;
			_accelerate = ViVector3.ZERO;
		}
		//
		return true;
	}

	void _Update(ViVector3 destValue, float deltaTime)
	{
		ViVector3 diff = destValue - _currentValue;
		float diffLen = diff.magnitude;
		deltaTime *= _timeScale;
		ViVector3 diffNormal = diff.normalized;
		float sprintForce = _springRate * diffLen;
		_accelerate = diffNormal * sprintForce - _currentSpeed * _speedFriction;
		_currentSpeed = _currentSpeed + _accelerate * deltaTime;
		ViVector3 oldValue = _currentValue;
		_currentValue += _currentSpeed * deltaTime;
		if (IsCross(destValue, oldValue, _currentValue))
		{
			--_sprintCount;
		}
	}

	public void StopAt(ViVector3 value)
	{
		_currentValue = value;
		_currentSpeed = ViVector3.ZERO;
		_accelerate = ViVector3.ZERO;
	}

	static bool IsCross(ViVector3 root, ViVector3 oldPos, ViVector3 newPos)
	{
		ViVector3 oldDir = oldPos - root;
		ViVector3 newDir = newPos - root;
		return ViVector3.Dot(oldDir, newDir) < 0;
	}

	float _springRate = 20.0f;
	ViVector3 _currentSpeed;
	ViVector3 _currentValue;
	float _speedFriction = 3.0f;
	float _timeScale = 1.0f;
	ViVector3 _accelerate;
	int _sprintCount;
	//质量=1.0
}
