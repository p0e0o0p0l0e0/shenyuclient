using System;
using System.Collections.Generic;
using UnityEngine;

public class LootExpress : ViSpaceExpress
{
	public static ViConstValue<float> VALUE_LootExpressForce = new ViConstValue<float>("LootExpressForce", 2000.0f);
	public static ViConstValue<float> VALUE_LootExpressGravity = new ViConstValue<float>("LootExpressGravity", 9.8f);
	public static ViConstValue<float> VALUE_LootExpressExploreDuration = new ViConstValue<float>("LootExpressExploreDuration", 2.0f);
	public static ViConstValue<float> VALUE_LootExpressStartScale = new ViConstValue<float>("LootExpressStartScale", 0.5f);
	public static ViConstValue<float> VALUE_LootExpressEndScale = new ViConstValue<float>("LootExpressEndScale", 0.5f);
	public static ViConstValue<float> VALUE_LootExpressInSpeed = new ViConstValue<float>("LootExpressInSpeed", 8.0f);

	public ViGravityMotor2 Motor { get { return _motor; } }
	public float Scale
	{
		get
		{
			return ViMathDefine.Lerp(_startScale, _endScale, (_maxDuration - Motor.Duration) / _maxDuration);
		}
	}

	public void Start(GameObject res, ViProvider<ViVector3> absorbPos)
	{
		_res = res;
		_absorbTarget = absorbPos;
		_startScale = VALUE_LootExpressStartScale;
		_endScale = 1.0f;
		//
		//
		ViTimerVisualInstance.SetTime(_absorbTimeNode, VALUE_LootExpressExploreDuration, this.AbsorbStart);
	}

	ViTimeNode1 _absorbTimeNode = new ViTimeNode1();
	void AbsorbStart(ViTimeNodeInterface node)
	{
		ViVector3 pos = _res.transform.position.Convert();
		float distance = ViVector3.Distance(pos, _absorbTarget.Value);
		float duration = distance / VALUE_LootExpressInSpeed;
		float topHeight = 4.0f;
		//
		Motor.Translate = pos;
		Motor.Target = _absorbTarget;
		Motor.Gravity = VALUE_LootExpressGravity;
		Motor.Gravity = ViMathDefine.Min(VALUE_LootExpressGravity, 8.0f * topHeight / (duration * duration));
		Motor.Start(duration);
		//
		_startScale = 1.0f;
		_endScale = VALUE_LootExpressEndScale;
		_maxDuration = duration;
		//
		UnityAssisstant.DelComponent<Rigidbody>(_res);
		//
		AttachUpdate();
	}

	public override void End()
	{
		_absorbTimeNode.Detach();
		UnityAssisstant.DestroyEx(ref _res);
		base.End();
	}
	public override void Update(float deltaTime)
	{
		Motor.Update(deltaTime);
		_res.transform.localScale = Scale * Vector3.one;
		_res.transform.localPosition = Motor.Translate.Convert();
		//
		if (Motor.IsEnd)
		{
			End();
		}
	}

	GameObject _res;
	ViProvider<ViVector3> _absorbTarget;
	ViGravityMotor2 _motor = new ViGravityMotor2();
	float _startScale = 0.0f;
	float _endScale = 1.0f;
	float _maxDuration = 1.0f;
}