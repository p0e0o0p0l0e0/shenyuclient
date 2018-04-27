using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UITweenRotationEx : UITweenInterface
{

	public Vector3 From = Vector3.zero;
	public Vector3 To = Vector3.zero;
	//
	public float SpringRate = 18f;
	public float SpeedFriction = 3f;
	public float SpringTimeScale = 7f;

	public static UITweenRotationEx Get(GameObject go, bool reset = true)
	{
		return UITweenInterface.Get<UITweenRotationEx>(go, reset);
	}

	public static UITweenRotationEx Begin(GameObject go, Vector3 from, Vector3 to)
	{
		UITweenRotationEx tween = UITweenInterface.Get<UITweenRotationEx>(go, false);
		tween.From = from;
		tween.To = to;
		tween.ResetToStart();
		return tween;
	}

	public override void Play(bool forward)
	{
		Vector3 start = forward ? From : To;
		_dest = forward ? To : From;
		//
		if (Type == TweenType.SPRING)
		{
			_tweenerSpring.StopAt(start);
			_tweenerSpring.Init(SpringRate, SpeedFriction, SpringTimeScale);
		}
		else
		{
			_tweenerNormal.StopAt(start);
			float distance = (_dest - start).magnitude;
			_tweenerNormal.Accelerate = Accelerate;
			_tweenerNormal.MaxSpeed = MaxSpeed;
			_tweenerNormal.MinSpeed = MinSpeed;
			_tweenerNormal.TimeScale = NormalTimeScale;
			//
			if (Duration > 0f)
			{
				_tweenerNormal.SetSample(Vector3.Distance(From, To), Duration);
			}
		}
		//
		base.Play(forward);
	}


	protected override void OnUpdate(float deltaTime)
	{
		if (Type == TweenType.SPRING)
		{
			if (_tweenerSpring.Update(_dest, deltaTime))
			{
				_UpdateRotation(_tweenerSpring.Value);
			}
			else
			{
				_UpdateRotation(_tweenerSpring.Value);
				OnComplete();
			}
		}
		else
		{
			if (_tweenerNormal.Update(_dest, deltaTime))
			{
				_UpdateRotation(_tweenerNormal.Value);
			}
			else
			{
				_UpdateRotation(_tweenerNormal.Value);
				OnComplete();
			}
		}
	}

	void _UpdateRotation(Vector3 angle)
	{
		transform.localEulerAngles = angle;
	}

	public override void ResetToStart()
	{
		_UpdateRotation(From);
	}

	[ContextMenu("Apply Angle To From")]
	void ApplyPositionToFrom()
	{
		From = transform.localEulerAngles;
	}

	[ContextMenu("Apply Angle To To")]
	void ApplyPositionToTo()
	{
		To = transform.localEulerAngles;
	}

	[ContextMenu("Reset Pos")]
	void ResetPosition()
	{
		ResetToStart();
	}

	Vector3 _dest;
	Vector3Interpolation_Spring _tweenerSpring = new Vector3Interpolation_Spring();
	Vector3Interpolation _tweenerNormal = new Vector3Interpolation();
}
