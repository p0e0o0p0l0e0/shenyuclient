using UnityEngine;
using System.Collections;

public class FXAnimation_Dissolve : FXCurveAnimation_Base
{
	public AnimationCurve DissolveChangeCurve = new AnimationCurve();

	public override void InitAnimation()
	{
		base.InitAnimation();
		_currentRender = GetComponent<Renderer>();
		if (_currentRender.material.HasProperty ("_N_mask")) 
		{
			_orginValue = _currentRender.material.GetFloat("_N_mask");
		}
		//
		_currentRender.enabled = false;
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (!base.UpdateAnimation(deltaTime))
		{
			return false;
		}
		if (Hide)
		{
			_currentRender.enabled = true;
			Hide = false;
		}
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float scaleValue = DissolveChangeCurve.Evaluate(_elapseTime / DurationTime) * _orginValue;
		if (_currentRender.material.HasProperty ("_N_mask")) 
		{
			_currentRender.material.SetFloat ("_N_mask", scaleValue);
		}
		return true;
	}

	Renderer _currentRender;
	float _orginValue;
}
