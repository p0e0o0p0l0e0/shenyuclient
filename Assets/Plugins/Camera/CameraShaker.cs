using System;

public class CameraSpringShaker
{
	public ViVector3 Offset { get { return _offset.Value; } }
	public ViVector3 LookAtOffset { get { return Offset * _lookAtScale; } }

	public CameraSpringShaker()
	{
		_offset.StopAt(ViVector3.ZERO);
	}

	public void Start(ViVector3 speed, float spirngRate, float speedFriction, float timeScale, int sprintCount, float lookAtScale)
	{
		_offset.Init(spirngRate, speedFriction, timeScale, speed, sprintCount);
		_lookAtScale = lookAtScale;
	}

	public void Update(float deltaTime)
	{
		_offset.Update(ViVector3.ZERO, deltaTime);
	}

	ViVector3Interpolation_Spring _offset = new ViVector3Interpolation_Spring();
	float _lookAtScale = 0.0f;
}


public class CameraRandomShaker
{
	public ViVector3 Offset { get { return _offset; } }
	public ViVector3 LookAtOffset { get { return _offset * _lookAtScale; } }
	public float Scale { set { _scale = value; } }

	public void Start(float duration, float intensity, float lookAtScale)
	{
		float currentAmplitude = _duration * _timeSlide * _intensity;
		if (currentAmplitude > intensity)
		{
			return;
		}
		_duration = duration;
		_intensity = intensity;
		_lookAtScale = lookAtScale;
		_timeSlide = 1.0f / duration;
	}

	public void Update(float deltaTime)
	{
		if (_duration < deltaTime)
		{
			_duration = 0;
			_offset = ViVector3.ZERO;
		}
		else
		{
			_duration -= deltaTime;
			float intensity = _duration * _timeSlide * _intensity;
			Int32 randomRange = (Int32)(intensity * 100);
			_offset.x = ViRandom.Value(-randomRange, randomRange) * 0.01f;
			_offset.y = ViRandom.Value(-randomRange, randomRange) * 0.01f;
			_offset.z = ViRandom.Value(-randomRange, randomRange) * 0.01f;
			_offset *= _scale;
		}
	}

	float _duration;
	float _timeSlide;

	float _scale = 1.0f;
	float _intensity;
	ViVector3 _offset;

	float _lookAtScale = 0.0f;
}