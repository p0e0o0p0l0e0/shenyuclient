using UnityEngine;
using System.Collections;

public class FXCurveAnimation_Scale03 : FXCurveAnimation_Base
{
	public bool X = true;
	public float XValueScale = 1.0f;
	public AnimationCurve XScaleCurve = new AnimationCurve();
	public bool Y = true;
	public float YValueScale = 1.0f;
	public AnimationCurve YScaleCurve = new AnimationCurve();
	public bool Z = true;
	public float ZValueScale = 1.0f;
	public AnimationCurve ZScaleCurve = new AnimationCurve();
	
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
			else if (Loop)
			{
				gameObject.transform.localScale = _originalScale;
				_lastScale = _originalScale;
				_elapseTime = 0.0f;
			}
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		Vector3 temp = Vector3.zero;
		float coordinate = _elapseTime / DurationTime;
		//
		if (!X)
		{
			temp.x = _originalScale.x;
		}
		else
		{
			float xscaleValue = XScaleCurve.Evaluate(coordinate) * XValueScale;
			temp.x = (1 + xscaleValue) * _originalScale.x;
		}
		//
		if (!Y)
		{
			temp.y = _originalScale.y;
		}
		else
		{
			float yscaleValue = YScaleCurve.Evaluate(coordinate) * YValueScale;
			temp.y = (1 + yscaleValue) * _originalScale.y;
		}
		//
		if (!Z)
		{
			temp.z = _originalScale.z;
		}
		else
		{
			float zscaleValue = ZScaleCurve.Evaluate(coordinate) * ZValueScale;
			temp.z = (1 + zscaleValue) * _originalScale.z;
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
