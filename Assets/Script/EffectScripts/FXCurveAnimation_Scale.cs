using UnityEngine;
using System.Collections;

public class FXCurveAnimation_Scale : FXCurveAnimation_Base
{
	public AnimationCurve RotationCurve = new AnimationCurve();
	public Vector3 Axis = Vector3.up;
	public float ValueScale = 1.0f;
	public bool Loop = false;

	public override void InitAnimation()
	{
		_currentRender = GetComponent<Renderer>();
		base.InitAnimation();
		if (_currentRender != null)
		{
			_currentRender.enabled = false;
		}
		//
		_originalScale = gameObject.transform.localScale;
		_lastScale = _originalScale;
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (Hide)
		{
			if (_currentRender != null)
			{
				_currentRender.enabled = true;
			}
			//
			Hide = false;
		}
		if (_elapseTime > DurationTime)
		{
			if (AutoDestory && !Loop)
			{
				GameObject.Destroy(gameObject);
				return false;
			}
			else if(Loop)
			{
				gameObject.transform.localScale = _originalScale;
				_lastScale = _originalScale;
				_elapseTime = 0.0f;
			}
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float scaleValue = RotationCurve.Evaluate(_elapseTime / DurationTime) * ValueScale;
		Vector3 temp = (1 + scaleValue) * _originalScale;
		//
		if (Axis.x == 0)
		{
			temp.x = _originalScale.x;
		}
		else
		{
			temp.x *= Axis.x;
		}
		//
		if (Axis.y == 0)
		{
			temp.y = _originalScale.y;
		}
		else
		{
			temp.y *= Axis.y;
		}
		//
		if (Axis.z == 0)
		{
			temp.z = _originalScale.z;
		}
		else
		{
			temp.z *= Axis.z;
		}
		//
		Vector3 delta = temp - _lastScale;
		gameObject.transform.localScale = gameObject.transform.localScale + delta;
		_lastScale = temp;
		_elapseTime += Time.deltaTime;
		return true;
	}

	Vector3 _lastScale;
	Vector3 _originalScale;
	Renderer _currentRender;
}
