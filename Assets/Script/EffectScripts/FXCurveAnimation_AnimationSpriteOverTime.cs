using System;
using System.Collections.Generic;
using UnityEngine;

public class FXCurveAnimation_AnimationSpriteOverTime : FXCurveAnimation_Base
{
	public Int32 TilingX = 1;
	public Int32 TilingY = 1;
	public bool Loop = false;
	public AnimationCurve OverTime = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

	public override void InitAnimation()
	{
		base.InitAnimation();
		_currentRender = GetComponent<Renderer>();
		_currentRender.enabled = false;
		if (_currentRender == null)
		{
			return;
		}
		//
		TilingX = Math.Max(1, TilingX);
		TilingY = Math.Max(1, TilingY);
		if (_currentRender != null)
		{
			_tilingX = 1.0f / TilingX;
			_tilingY = 1.0f / TilingY;
			_currentRender.material.mainTextureScale = new Vector2(_tilingX, _tilingY);
			float frameNum = Mathf.Floor(OverTime.Evaluate(0.0f));
			float xOffset = frameNum % TilingX * _tilingX;
			float yOffset = (TilingY - Mathf.Floor(frameNum / TilingX)) * _tilingY - _tilingY;
			_currentRender.material.mainTextureOffset = new Vector2(xOffset, yOffset);
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (_currentRender == null)
		{
			return false;
		}
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (!_currentRender.enabled && Hide)
		{
			_currentRender.enabled = true;
			Hide = false;
		}
		if (_elapseTime > DurationTime)
		{
			if (!Loop)
			{
				if (AutoDestory)
				{
					GameObject.Destroy(gameObject);
				}
				//
				return false;
			}
			//
			_elapseTime = 0.0f;
		}
		//
		float frameNum = Mathf.Floor(OverTime.Evaluate(_elapseTime));
		float xOffset = frameNum % TilingX * _tilingX;
		float yOffset = (TilingY - Mathf.Floor(frameNum / TilingX)) * _tilingY - _tilingY;
		_currentRender.material.mainTextureOffset = new Vector2(xOffset, yOffset);
		_elapseTime += deltaTime;
		return true;
	}

#if UNITY_EDITOR

	private void OnValidate()
	{
		if (OverTime.length <= 0)
		{
			return;
		}
		//
		for (int iter = 0; iter < OverTime.keys.Length; ++iter)
		{
			if (iter == 0)
			{
				Keyframe oldKeyFrame =  OverTime.keys[iter];
				float time = oldKeyFrame.time;
				float value = oldKeyFrame.value;
				keyFrame.time = Mathf.Max(0.0f, Mathf.Min(time, 1.0f));
				keyFrame.value = Mathf.Max(Mathf.Min(value, TilingX * TilingY), 0.0f);
				keyFrame.inTangent = oldKeyFrame.inTangent;
				keyFrame.outTangent = oldKeyFrame.outTangent;
				keyFrame.tangentMode = oldKeyFrame.tangentMode;
				OverTime.MoveKey(iter, keyFrame);
				//OverTime.RemoveKey(iter);
				//OverTime.AddKey(keyFrame);
			}
			else if (iter == OverTime.keys.Length - 1)
			{
				Keyframe oldKeyFrame = OverTime.keys[iter];
				float time = oldKeyFrame.time;
				float value = oldKeyFrame.value;
				keyFrame.time = Mathf.Max(0.0f, Mathf.Min(time, 1.0f));
				if (_oldCount == TilingX * TilingY)
				{
					keyFrame.value = Mathf.Max(Mathf.Min(value, TilingX * TilingY), 0.0f);
				}
				else
				{
					keyFrame.value = Mathf.Max(TilingX * TilingY, 0.0f);
				}
				//
				keyFrame.inTangent = oldKeyFrame.inTangent;
				keyFrame.outTangent = oldKeyFrame.outTangent;
				keyFrame.tangentMode = oldKeyFrame.tangentMode;
				OverTime.MoveKey(iter, keyFrame);
				//OverTime.AddKey(keyFrame);
			}
			else
			{
				Keyframe oldKeyFrame = OverTime.keys[iter];
				float time = oldKeyFrame.time;
				float value = oldKeyFrame.value;
				keyFrame.time = Mathf.Max(0.0f, Mathf.Min(time, 1.0f));
				keyFrame.value = Mathf.Max(Mathf.Min(value, TilingX * TilingY), 0.0f);
				keyFrame.inTangent = oldKeyFrame.inTangent;
				keyFrame.outTangent = oldKeyFrame.outTangent;
				keyFrame.tangentMode = oldKeyFrame.tangentMode;
				OverTime.MoveKey(iter, keyFrame);
				//OverTime.RemoveKey(iter);
				//OverTime.AddKey(keyFrame);
			}
		}

		if (_oldCount == 0)
		{
			_oldCount = Math.Max(1, TilingX) * Math.Max(1, TilingY);
		}
	}
#endif

	Renderer _currentRender;
	float _tilingX = 0.0f;
	float _tilingY = 0.0f;
	Keyframe keyFrame = new Keyframe();

	Int32 _oldCount = 0;
}
