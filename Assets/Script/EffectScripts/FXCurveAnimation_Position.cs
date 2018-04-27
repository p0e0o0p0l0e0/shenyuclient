using UnityEngine;
using System.Collections;

public class FXCurveAnimation_Position : FXCurveAnimation_Base
{
	public AnimationCurve DisplacementCurve = new AnimationCurve();
	public Vector3 Toward = Vector3.left;
	[Tooltip("true : World Space; False : Local Space")]
	public bool WorldSpace = true;
	public float ValueScale = 1.0f;
	public bool Repeat = false;

	public override void InitAnimation()
	{
		_currentRender = GetComponent<Renderer>();
		if (WorldSpace)
		{
			_originalPos = gameObject.transform.position;
		}
		else
		{
			_originalPos = gameObject.transform.position;
		}
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
					gameObject.transform.position = _originalPos;
				}
				else
				{
					gameObject.transform.localPosition = _originalPos;
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
		float displacement = DisplacementCurve.Evaluate(_elapseTime / DurationTime) * ValueScale;
		Vector3 delta = Toward * (displacement - _lastValue);
		if (WorldSpace)
		{
			gameObject.transform.position += delta;
		}
		else
		{
			gameObject.transform.position += gameObject.transform.TransformDirection(delta);
		}
		//
		_lastValue = displacement;
		_elapseTime += deltaTime;
		return true;
	}

	float _lastValue = 0.0f;
	Renderer _currentRender;
	Vector3 _originalPos;
}
