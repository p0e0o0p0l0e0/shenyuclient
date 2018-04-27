using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class UITweenInterface : MonoBehaviour
{
	public enum TweenType
	{
		NORMAL,
		SPRING,
	}

	public delegate void TweenDele(UITweenInterface tweener);
	public TweenDele OnCompleteCallback;
	public TweenDele CompleteCallbackList;
	//
	public float Delay = 0f;
	public TweenType Type = TweenType.SPRING;
	//
	public float Accelerate = 30000f;
	public float MinSpeed = 0f;
	public float MaxSpeed = 30000f;
	public float NormalTimeScale = 1f;
	public float Duration = 0f;

	public bool Runnig
	{
		get { return enabled && _start; }
		set
		{
			enabled = value;
			_start = value;
		}
	}

	public static T Get<T>(GameObject go, bool reset = true) where T : UITweenInterface
	{
		T tweener = go.GetComponent<T>();
		if (tweener == null)
		{
			tweener = go.AddComponent<T>();
		}
		if (reset)
		{
			tweener.ResetToStart();
		}
		return tweener;
	}


	public void PlayForward()
	{
		Play(true);
	}
	public void PlayReverse()
	{
		Play(false);
	}
	public virtual void Play(bool forward)
	{
		_startTime = Time.time + Delay;
		Runnig = true;
	}



	void Update()
	{
		if (!Runnig)
		{
			return;
		}
		//
		float currentTime = Time.time;
		if (currentTime >= _startTime)
		{
			OnUpdate(Time.deltaTime);
		}
		else
		{
			//ViDebuger.Warning(gameObject.name + " not reach Start Time");
		}
	}

	protected abstract void OnUpdate(float deltaTime);

	protected void OnComplete()
	{
		_startTime = 0f;
		Runnig = false;
		//
		if (OnCompleteCallback != null)
		{
			OnCompleteCallback(this);
		}
		//
		if (CompleteCallbackList != null)
		{
			CompleteCallbackList(this);
		}
	}

	public abstract void ResetToStart();

	float _startTime = 0;
	bool _start = false;
}
