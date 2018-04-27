using System;
using System.Collections.Generic;
using UnityEngine;

public class FXCurveAnimation_AnimationSprite : FXCurveAnimation_Base
{
	public Int32 TilingX = 1;
	public Int32 TilingY = 1;
	public Int32 StartFrame = 0;
	public Int32 EndFrame = 0;
	public bool Loop = false;
	public bool IsXScroll = false;
	public float OffsetX;
	public AnimationCurve XSpeedCurve = new AnimationCurve();
	public bool RandomValue = false;

	public override void InitAnimation()
	{
		random = new System.Random((Int32)DateTime.Now.Ticks);
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
		_nextFrameNum = StartFrame;
		_totalFrameCount = EndFrame - StartFrame + 1;
		_frameTime = DurationTime / (_totalFrameCount * 1.0f);
		//
		if (_currentRender != null)
		{
			_tilingX = 1.0f / TilingX;
			_tilingY = 1.0f / TilingY;
			_currentRender.material.mainTextureScale = new Vector2(_tilingX, _tilingY);
			if (!IsXScroll)
			{
				_currentRender.material.mainTextureOffset = new Vector2(_nextFrameNum % TilingX * _tilingX, 1 - (_nextFrameNum / TilingX) * _tilingY - _tilingY);
			}
			else
			{
				yStartOffset = 1 - (_nextFrameNum / TilingX) * _tilingY - _tilingY;
				_currentRender.material.mainTextureOffset = new Vector2(_nextFrameNum % TilingX * _tilingX + OffsetX, yStartOffset);
			}
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
		if (_nextFrameNum > EndFrame)
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
			_nextFrameNum = StartFrame;
			//
			if (!IsXScroll)
			{
				_currentRender.material.mainTextureOffset = new Vector2(_nextFrameNum % TilingX * _tilingX, 1 - (_nextFrameNum / TilingX) * _tilingY - _tilingY);
			}
		}
		//
		if (_elapseTime > _frameTime)
		{
			_elapseTime = 0.0f;
			if (RandomValue)
			{
				_nextFrameNum = random.Next(StartFrame, EndFrame);
				if (!IsXScroll)
				{
					yStartOffset = 1 - (_nextFrameNum / TilingX) * _tilingY - _tilingY;
					_currentRender.material.mainTextureOffset = new Vector2(_nextFrameNum % TilingX * _tilingX, yStartOffset);
				}
			}
			else
			{
				++_nextFrameNum;
				Int32 nextFrame = _nextFrameNum > EndFrame ? EndFrame : _nextFrameNum;
				if (!IsXScroll)
				{
					yStartOffset = 1 - (nextFrame / TilingX) * _tilingY - _tilingY;
					_currentRender.material.mainTextureOffset = new Vector2(nextFrame % TilingX * _tilingX, yStartOffset);
				}
				//

			}
		}
		//
		if (IsXScroll)
		{
			DurationTime = Mathf.Max(0.01f, DurationTime);
			float xValue = _elapseTime / DurationTime;
			float speedValue = XSpeedCurve.Evaluate(xValue);
			xOffset += deltaTime * speedValue;
			//xOffset = xOffset - (float)Math.Truncate((double)xOffset);
			_currentRender.material.mainTextureOffset = new Vector2(xOffset + OffsetX, yStartOffset);
		}
		//
		_elapseTime += deltaTime;
		return true;
	}

	Renderer _currentRender;
	float _tilingX = 0.0f;
	float _tilingY = 0.0f;
	Int32 _nextFrameNum = 0;
	Int32 _totalFrameCount;
	float _frameTime = 0.0f;
	//
	float xOffset;

	float yStartOffset;
	System.Random random;
}