using UnityEngine;
using System.Collections;

public class FXCurveAnimation_Rotation : FXCurveAnimation_Base
{
	public AnimationCurve RotationCurve = new AnimationCurve();
	public Vector3 Axis = Vector3.up;
	[Tooltip("true : World Space; False : Local Space")]
	public bool WorldSpace = true;
	public float ValueScale = 360.0f;
	public bool Repeat = false;

	public override void InitAnimation()
	{
		_currentRender = GetComponent<Renderer>();
		if (WorldSpace)
		{
			_originalRatation = gameObject.transform.rotation;
		}
		else
		{
			_originalRatation = gameObject.transform.localRotation;
		}
		//
		base.InitAnimation();
		if (_currentRender != null)
		{
			_currentRender.enabled = false;
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (_elapseTime > DurationTime)
		{
			if (Repeat)
			{
				if (WorldSpace)
				{
					gameObject.transform.rotation = _originalRatation;
				}
				else
				{
					gameObject.transform.localRotation = _originalRatation;
				}
				//
				_elapseTime = 0.0f;
			}
			else
			{
				if (AutoDestory)
				{
					GameObject.Destroy(gameObject);
				}
				//
				return false;
			}
		}
		//
		if (Hide)
		{
			if (_currentRender != null)
			{
				_currentRender.enabled = true;
			}
			//
			Hide = false;
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float rotationValue = RotationCurve.Evaluate(_elapseTime / DurationTime) * ValueScale;
		float delta = (rotationValue - _lastValue);
		if (WorldSpace)
		{
			//gameObject.transform.rotation *= Quaternion.AngleAxis(delta, Axis);
		}
		else
		{
			//gameObject.transform.localRotation *= Quaternion.AngleAxis(delta, Axis);
		}
		//
		_lastValue = rotationValue;
		_elapseTime += deltaTime;
		return true;
	}

	float _lastValue = 0.0f;
	Renderer _currentRender;
	Quaternion _originalRatation;
}
