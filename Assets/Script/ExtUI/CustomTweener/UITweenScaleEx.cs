using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UITweenScaleEx : UITweenInterface
{
	public Vector3 From = Vector3.one;
	public Vector3 To = Vector3.one;
	public bool UpdateTable = false;

	[Range(1f, 1000f)]
	public float Factor = 100f; // 放大因子（插值时 保证 区间不至于太小）
	//
	public float SpringRate = 18f;
	public float SpeedFriction = 3.3f;
	public float SpringTimeScale = 10f;

	public static UITweenScaleEx Get(GameObject go, bool reset = true)
	{
		return UITweenInterface.Get<UITweenScaleEx>(go, reset);
	}

	public static UITweenScaleEx Begin(GameObject go, Vector3 from, Vector3 to)
	{
		UITweenScaleEx tween = UITweenInterface.Get<UITweenScaleEx>(go, false);
		tween.From = from;
		tween.To = to;
		tween.ResetToStart();
		return tween;
	}

	public override void Play(bool forward)
	{
		Vector3 start = forward ? From * Factor : To * Factor;
		_dest = forward ? To * Factor : From * Factor;
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
				_tweenerNormal.SetSample(Vector3.Distance(_dest, start), Duration);
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
				transform.localScale = _tweenerSpring.Value / Factor;
				_UpdateTable();
			}
			else
			{
				transform.localScale = _tweenerSpring.Value / Factor;
				OnComplete();
			}
		}
		else
		{
			if (_tweenerNormal.Update(_dest, deltaTime))
			{
				transform.localScale = _tweenerNormal.Value / Factor;
				_UpdateTable();
			}
			else
			{
				transform.localScale = _tweenerNormal.Value / Factor;
				OnComplete();
			}
		}
	}

	void _UpdateTable()
	{
		if (UpdateTable)
		{
			if (_mTable == null)
			{
				_mTable = NGUITools.FindInParents<UITable>(gameObject);
				if (_mTable == null) { UpdateTable = false; return; }
			}
			_mTable.repositionNow = true;
		}
	}

	public override void ResetToStart()
	{
		transform.localScale = From;
	}

	[ContextMenu("Apply Scale To From")]
	public void ApplyScaleToFrom()
	{
		From = transform.localScale;
	}

	[ContextMenu("Apply Scale To To")]
	public void ApplyScaleToTo()
	{
		To = transform.localScale;
	}

	Vector3 _dest;
	Vector3Interpolation_Spring _tweenerSpring = new Vector3Interpolation_Spring();
	Vector3Interpolation _tweenerNormal = new Vector3Interpolation();
	UITable _mTable;
}
