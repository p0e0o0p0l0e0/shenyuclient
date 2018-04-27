using System;

public class ViValueInterpolation
{
	public float Value { get { return _currentValue; } }
	public float Accelerate { get { return _accelerate; } set { _accelerate = ViMathDefine.Max(0.0f, value); } }
	public float MinSpeed { get { return _minSpeed; } set { _minSpeed = ViMathDefine.Max(0.0f, value); } }
	public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = ViMathDefine.Max(0.0f, value); } }
	public float TimeScale { get { return _timeScale; } set { _timeScale = ViMathDefine.Max(0.0f, value); } }
	public float CurrentSpeed { get { return _currentSpeed; } }
	public bool IsFiltering { get { return (_currentSpeed != 0.0f); } }

	public bool Update(float destValue, float deltaTime)
	{
		float diff = destValue - _currentValue;
		if (diff == 0.0f)
		{
			return false;
		}
		deltaTime *= TimeScale;
		if (diff > 0.0f)
		{
			float newSpeed = _currentSpeed + _accelerate * deltaTime;
			float brakingSpeed = ViMathDefine.Sqrt(diff * _accelerate * 2.0f);
			_currentSpeed = ViMathDefine.Min(ViMathDefine.Clamp(newSpeed, _minSpeed, _maxSpeed), brakingSpeed);
			float deltaDist = _currentSpeed * deltaTime;
			_currentValue += deltaDist;
			if (_currentValue >= destValue)
			{
				_currentValue = destValue;
				_currentSpeed = 0.0f;
			}
		}
		else
		{
			float newSpeed = _currentSpeed - _accelerate * deltaTime;
			float brakingSpeed = -ViMathDefine.Sqrt(-diff * _accelerate * 2.0f);
			_currentSpeed = ViMathDefine.Max(ViMathDefine.Clamp(newSpeed, -_maxSpeed, -_minSpeed), brakingSpeed);
			float deltaDist = _currentSpeed * deltaTime;
			_currentValue += deltaDist;
			if (_currentValue <= destValue)
			{
				_currentValue = destValue;
				_currentSpeed = 0.0f;
			}
		}
		return true;
	}

	public void StopAt(float fDistance)
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
	float _currentValue = 0.0f;
}

public class ViVector3Interpolation
{
	public ViVector3 Value { get { return _currentValue; } }
	public float Accelerate { get { return _accelerate; } set { _accelerate = ViMathDefine.Max(0.0f, value); } }
	public float MinSpeed { get { return _minSpeed; } set { _minSpeed = ViMathDefine.Max(0.0f, value); } }
	public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = ViMathDefine.Max(0.0f, value); } }
	public float TimeScale { get { return _timeScale; } set { _timeScale = ViMathDefine.Max(0.0f, value); } }
	public float CurrentSpeed { get { return _currentSpeed; } }
	public bool IsFiltering { get { return (_currentSpeed != 0.0f); } }

	public bool Update(ViVector3 desireValue, float deltaTime)
	{
		ViVector3 diff = desireValue - _currentValue;
		float diffLen = diff.Length;
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
			ViVector3 deltaDist = frontDistance * diff.normalized;
			_currentValue += deltaDist;
		}
		return true;
	}

	public void StopAt(ViVector3 fDistance)
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
	ViVector3 _currentValue;
}
