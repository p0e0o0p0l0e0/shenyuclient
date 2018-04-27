using System;

public class ViAngleCursor1
{
	public float Direction { get { return _curDiretion; } set { _curDiretion = value; ViAngle.Normalize(ref _curDiretion); } }
	public float RotSpd { get { return _rotSpd; } set { _rotSpd = ViMathDefine.Max(1.0f, Math.Abs(value)); } }

	public bool Update(float deltaTime, float newDir)
	{
		if (newDir == _curDiretion)
		{
			return false;
		}
		float maxRot = deltaTime * _rotSpd;
		float deltaAngle = newDir - _curDiretion;
		ViAngle.Normalize(ref deltaAngle);
		if (Math.Abs(deltaAngle) < maxRot)
		{
			_curDiretion = newDir;
		}
		else
		{
			_curDiretion += maxRot * ViMathDefine.Sign(deltaAngle);
		}
		ViAngle.Normalize(ref _curDiretion);
		return true;
	}

	float _curDiretion;
	float _rotSpd = 10.0f;
}

public class ViAngleCursor2
{
	public float CurrentSpeed { get { return _currentSpeed; } }
	public float Direction
	{
		get { return _curDiretion; }
		set
		{
			_curDiretion = value;
			ViAngle.Normalize(ref _curDiretion);
			_currentSpeed = 0.0f;
		}
	}
	public float Accelerate { get { return _accelerate; } set { _accelerate = ViMathDefine.Max(0.0f, value); } }
	public float MinSpeed { get { return _minSpeed; } set { _minSpeed = ViMathDefine.Max(0.0f, value); } }
	public float MaxSpeed { get { return _maxSpeed; } set { _maxSpeed = ViMathDefine.Max(0.0f, value); } }

	public ViAngleCursor2()
	{
		SetSample(3.14f, 0.23f);
	}
	public bool Update(float deltaTime, float newDir)
	{
		float deltaAngle = newDir - _curDiretion;
		if (deltaAngle == 0.0f)
		{
			return false;
		}
		ViAngle.Normalize(ref deltaAngle);
		float maxRot = 0.0f;
		if (deltaAngle > 0.0f)
		{
			_currentSpeed = Math.Abs(_currentSpeed);
			float newSpeed = _currentSpeed + _accelerate * deltaTime;
			float brakingSpeed = ViMathDefine.Sqrt(deltaAngle * _accelerate * 2.0f);
			_currentSpeed = ViMathDefine.Min(ViMathDefine.Clamp(newSpeed, _minSpeed, _maxSpeed), brakingSpeed);
			maxRot = _currentSpeed * deltaTime;
		}
		else
		{
			_currentSpeed = -Math.Abs(_currentSpeed);
			float newSpeed = _currentSpeed - _accelerate * deltaTime;
			float brakingSpeed = -ViMathDefine.Sqrt(-deltaAngle * _accelerate * 2.0f);
			_currentSpeed = ViMathDefine.Max(ViMathDefine.Clamp(newSpeed, -_maxSpeed, -_minSpeed), brakingSpeed);
			maxRot = _currentSpeed * deltaTime;
		}
		if (Math.Abs(deltaAngle) < Math.Abs(maxRot))
		{
			_curDiretion = newDir;
			_currentSpeed = 0.0f;
		}
		else
		{
			_curDiretion += maxRot;
		}
		ViAngle.Normalize(ref _curDiretion);
		return true;
	}

	public void SetSample(float distance, float duration)
	{
		float avgSpeed = distance / duration;
		// 0.2 -> 1.9 -> 0.0, avg = 1.0
		_minSpeed = avgSpeed * 0.2f;
		_maxSpeed = avgSpeed * 1.9f;
		_accelerate = (2.0f * _maxSpeed - _minSpeed) / duration;
	}

	float _curDiretion;
	float _accelerate = 2.0f;
	float _currentSpeed = 0.0f;
	float _minSpeed = 0.0f;
	float _maxSpeed = 4.0f;
}
