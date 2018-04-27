using System;


public class ViTrackMotor : ViMotorInterface
{
	public override void Start(float duration)
	{
		base.Start(duration);
		//
		if (Target != null)
		{
			ViVector3 dir = Target.Value - Translate;
			dir.Normalize();
			_direction = dir;
		}
	}

	public override void _Update(float deltaTime, ViVector3 target)
	{
		ViVector3 dir = target - Translate;
		dir.Normalize();
		_velocity = dir * _speed;
		_direction = dir;
	}
}
