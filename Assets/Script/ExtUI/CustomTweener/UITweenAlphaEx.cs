using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UITweenAlphaEx : UITweenInterface
{
	[Range(0f, 1f)]
	public float From = 0f;
	[Range(0f, 1f)]
	public float To = 1f;

	public static UITweenAlphaEx Get(GameObject go, bool reset = true)
	{
		return UITweenInterface.Get<UITweenAlphaEx>(go, reset);
	}

	public static UITweenAlphaEx Begin(GameObject go, float from, float to)
	{
		UITweenAlphaEx tween = UITweenInterface.Get<UITweenAlphaEx>(go, false);
		tween.From = from;
		tween.To = to;
		tween.ResetToStart();
		return tween;
	}

	public override void Play(bool forward)
	{
		float start = forward ? From : To;
		_dest = forward ? To : From;
		_tweener.StopAt(start);
		_tweener.Accelerate = Accelerate;
		_tweener.MaxSpeed = MaxSpeed;
		_tweener.MinSpeed = MinSpeed;
		_tweener.TimeScale = NormalTimeScale;
		//
		if (Duration > 0f)
		{
			_tweener.SetSample(ViMathDefine.Abs(To - From), Duration);
		}
		//
		base.Play(true);
	}


	protected override void OnUpdate(float deltaTime)
	{
		if (_tweener.Update(_dest, deltaTime))
		{
			SetAlpha(_tweener.Value);
		}
		else
		{
			SetAlpha(_tweener.Value);
			OnComplete();
		}
	}

	public override void ResetToStart()
	{
		SetAlpha(From);
	}

	void SetAlpha(float value)
	{
		if (!mCached) Cache();

		if (mRect != null)
		{
			mRect.alpha = value;
		}
		else if (mSr != null)
		{
			Color c = mSr.color;
			c.a = value;
			mSr.color = c;
		}
		else if (mMat != null)
		{
			Color c = mMat.color;
			c.a = value;
			mMat.color = c;
		}
	}

	void Cache()
	{
		mCached = true;
		mRect = GetComponent<UIRect>();
		mSr = GetComponent<SpriteRenderer>();
		if (mRect == null && mSr == null)
		{
			Renderer ren = GetComponent<Renderer>();
			if (ren != null) mMat = ren.material;
			if (mMat == null) mRect = GetComponentInChildren<UIRect>();
		}
	}

	float _dest;
	ViValueInterpolation _tweener = new ViValueInterpolation();
	//
	bool mCached = false;
	UIRect mRect;
	Material mMat;
	SpriteRenderer mSr;
}
