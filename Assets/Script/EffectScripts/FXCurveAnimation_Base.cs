using UnityEngine;
using System.Collections;

public class FXCurveAnimation_Base : MonoBehaviour
{
	public float DurationTime = 1.0f;
	public float DelayTime = 0.0f;
	public bool AutoDestory = false;

	void Start()
	{
		InitAnimation();
		UpdateAnimation(0.0f);
	}

	public virtual void InitAnimation()
	{
		_startTime = Time.time;
		_elapseTime = 0.0f;
		Hide = true;
	}

	void LateUpdate()
	{
		UpdateAnimation(Time.deltaTime);
	}

	public virtual bool UpdateAnimation(float deltaTime)
	{
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (_elapseTime > DurationTime)
		{
			if (AutoDestory)
			{
				GameObject.Destroy(gameObject);
			}
			//
			return false;
		}
		//
		_elapseTime += deltaTime;
		return true;
	}

	void OnDisable()
	{
		Clear();
	}

	void OnDestory()
	{
		Clear();
	}

	public virtual void Clear()
	{
		
	}

	protected float _elapseTime = 0.0f;
	protected float _startTime = 0.0f;
	protected bool Hide = true;
}
