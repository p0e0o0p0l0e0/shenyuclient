using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UITweenPositionEx : UITweenInterface
{
	public enum PositionType
	{
		DEFAULT,
		POS_X,
		POS_Y,
		POS_Z,
	}

	public PositionType PosSytle = PositionType.DEFAULT;
	public Vector3 From = Vector3.zero;
	public Vector3 To = Vector3.zero;
	//
	public float SpringRate = 18f;
	public float SpeedFriction = 3f;
	public float SpringTimeScale = 7f;

	public static UITweenPositionEx Get(GameObject go, bool reset = true)
	{
		return UITweenInterface.Get<UITweenPositionEx>(go, reset);
	}

	public static UITweenPositionEx Begin(GameObject go, Vector3 from, Vector3 to)
	{
		UITweenPositionEx tween = UITweenInterface.Get<UITweenPositionEx>(go, false);
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
				_UpdatePosition(_tweenerSpring.Value);
			}
			else
			{
				_UpdatePosition(_tweenerSpring.Value);
				OnComplete();
			}
		}
		else
		{
			if (_tweenerNormal.Update(_dest, deltaTime))
			{
				_UpdatePosition(_tweenerNormal.Value);
			}
			else
			{
				_UpdatePosition(_tweenerNormal.Value);
				OnComplete();
			}
		}
	}

	void _UpdatePosition(Vector3 pos)
	{
		Vector3 curPos = transform.localPosition;
		switch (PosSytle)
		{
			case PositionType.POS_X:
				curPos.x = pos.x;
				break;
			case PositionType.POS_Y:
				curPos.y = pos.y;
				break;
			case PositionType.POS_Z:
				curPos.z = pos.z;
				break;
			case PositionType.DEFAULT:
				curPos = pos;
				break;
			default:
				curPos = pos;
				break;
		}
		transform.localPosition = curPos;
	}

	public override void ResetToStart()
	{
		_UpdatePosition(From);
	}

	[ContextMenu("Apply Pos To From")]
	void ApplyPositionToFrom()
	{
		From = transform.localPosition;
	}

	[ContextMenu("Apply Pos To To")]
	void ApplyPositionToTo()
	{
		To = transform.localPosition;
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
