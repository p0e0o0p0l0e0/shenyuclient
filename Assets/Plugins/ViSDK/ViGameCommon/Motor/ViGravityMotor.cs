using System;

// 水平匀速
public class ViGravityMotor : ViMotorInterface
{
	public static readonly float GRAVITY = 9.8f;
	public float Gravity { get { return m_GravityAcc; } set { m_GravityAcc = ViMathDefine.Clamp(value, 0.1f * GRAVITY, 5.0f * GRAVITY); } }

	public override void Start(float duration)
	{
		ViDebuger.AssertWarning(Target);
		if (Target == null)
		{
			Target = new ViSimpleProvider<ViVector3>();
		}
		_velocity = ViVector3.ZERO;
		_duration = ViMathDefine.Max(0.01f, duration);
		ViVector3 targetPos = Target.Value;
		ViVector3 dir = targetPos - Translate;
		dir.z = 0.0f;
		dir.Normalize();
		float distanceH = ViMath2D.Length(targetPos.x, targetPos.y, Translate.x, Translate.y);
		float distanceV = targetPos.z - Translate.z;
		float time = distanceV / m_GravityAcc / _duration;
		float preDeltaTime = _duration * 0.5f + time;
		float speedH = distanceH / _duration;
		_velocity.x = dir.x * speedH;
		_velocity.y = dir.y * speedH;
		_velocity.z = preDeltaTime * m_GravityAcc;
		_direction = _velocity;
		_direction.Normalize();
	}

	public override void _Update(float deltaTime, ViVector3 target)
	{
		ViDebuger.AssertWarning(deltaTime > 0.0f);
		ViDebuger.AssertWarning(_speed > 0.0f);
		//
		ViVector3 targetPos = Target.Value;
		float distanceH = ViMath2D.Length(targetPos.x, targetPos.y, Translate.x, Translate.y);
		float distanceV = targetPos.z - Translate.z;
		float speedH = distanceH / _duration;
		m_GravityAcc = -2.0f * (distanceV / (_duration * _duration) - _velocity.z / _duration);
		m_GravityAcc = ViMathDefine.Clamp(m_GravityAcc, -GRAVITY, 5.0f * GRAVITY);
		ViVector3 dir = targetPos - Translate;
		dir.z = 0.0f;
		dir.Normalize();
		_velocity.x = dir.x * speedH;
		_velocity.y = dir.y * speedH;
		_velocity.z -= m_GravityAcc * deltaTime;
		_direction = _velocity;
		_direction.Normalize();
	}

	float m_GravityAcc = GRAVITY;
}

// 水平加速
public class ViGravityMotor2 : ViMotorInterface
{
	public static readonly float GRAVITY = 9.8f;
	public float Gravity { get { return m_GravityAcc; } set { m_GravityAcc = ViMathDefine.Clamp(value, 0.1f * GRAVITY, 5.0f * GRAVITY); } }

	public override void Start(float duration)
	{
		ViDebuger.AssertWarning(Target);
		if (Target == null)
		{
			Target = new ViSimpleProvider<ViVector3>();
		}
		_velocity = ViVector3.ZERO;
		_duration = ViMathDefine.Max(0.01f, duration);
		ViVector3 targetPos = Target.Value;
		ViVector3 dir = targetPos - Translate;
		dir.z = 0.0f;
		dir.Normalize();
		float distanceV = targetPos.z - Translate.z;
		float speedH = 0.0f;
		float time = distanceV / m_GravityAcc / _duration;
		float preDeltaTime = _duration * 0.5f + time;
		_velocity.x = dir.x * speedH;
		_velocity.y = dir.y * speedH;
		_velocity.z = preDeltaTime * m_GravityAcc;
		_direction = _velocity;
		_direction.Normalize();
	}

	public override void _Update(float deltaTime, ViVector3 target)
	{
		ViDebuger.AssertWarning(deltaTime > 0.0f);
		ViDebuger.AssertWarning(_speed > 0.0f);
		//
		ViVector3 targetPos = Target.Value;
		float distanceH = ViMath2D.Length(targetPos.x, targetPos.y, Translate.x, Translate.y);
		float distanceV = targetPos.z - Translate.z;
		float speedH = ViMath2D.Length(_velocity.x, _velocity.y);
		float accH = 2 * (distanceH - speedH * _duration) / (_duration * _duration);
		m_GravityAcc = -2.0f * (distanceV / (_duration * _duration) - _velocity.z / _duration);
		m_GravityAcc = ViMathDefine.Clamp(m_GravityAcc, -GRAVITY, 5.0f * GRAVITY);
		ViVector3 dir = targetPos - Translate;
		dir.z = 0.0f;
		dir.Normalize();
		_velocity.x += dir.x * accH * deltaTime;
		_velocity.y += dir.y * accH * deltaTime;
		_velocity.z -= m_GravityAcc * deltaTime;
		_direction = _velocity;
		_direction.Normalize();
	}

	float m_GravityAcc = GRAVITY;
}