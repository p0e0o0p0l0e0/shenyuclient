using System;
using System.Collections.Generic;


public class ViVisualVerticalCursor
{
	public float Height { get { return _height; } }
	public float Speed { get { return _speed; } }
	public float ReserveDuration { get { return _reserveDuration; } }
	public float Gravity { get { return _gravity; } }

	public void Update(float deltaTime)
	{
		if (_reserveDuration <= 0)
		{
			return;
		}
		//
		if (_reserveDuration < deltaTime)
		{
			_speed = 0;
			_height = 0;
			_reserveDuration = 0;
			_gravity = 0;
		}
		else
		{
			float gravity = -2 * (_height + _speed * _reserveDuration) / (_reserveDuration * _reserveDuration);
			float deltaSpeed = gravity * deltaTime;
			_speed += 0.5f * deltaSpeed;
			_height += _speed * deltaTime;
			_speed += 0.5f * deltaSpeed;
			_reserveDuration -= deltaTime;
			_gravity = gravity;
		}
	}

	public void Reset(float maxHeight, float duration)
	{
		_reserveDuration = duration;
		float gravity = -2.0f * maxHeight / ((duration * 0.5f) * (duration * 0.5f));
		_speed = -gravity * (duration * 0.5f);
		_height = 0;
		_gravity = gravity;
	}

	public void Reset(float duration)
	{
		float gravity = -2.0f * (_height + _speed * _reserveDuration) / (_reserveDuration * _reserveDuration);
		_reserveDuration = duration;
		_speed = -gravity * (duration * 0.5f);
	}

	public void Stop()
	{
		_speed = 0;
		_height = 0;
		_reserveDuration = 0;
		_gravity = 0;
	}

	float _height;
	float _speed;
	float _reserveDuration;
	float _gravity;
}