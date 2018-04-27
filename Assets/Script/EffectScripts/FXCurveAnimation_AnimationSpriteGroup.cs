using UnityEngine;
using System;
using System.Collections.Generic;

public class FXCurveAnimation_AnimationSpriteGroup : FXCurveAnimation_GroupBase
{
	public Int32 TilingX = 1;
	public Int32 TilingY = 1;
	public Int32 StartFrame = 0;
	public bool Loop = false;

	public override void InitAnimation()
	{
		base.InitAnimation();
		TilingX = Math.Max(1, TilingX);
		TilingY = Math.Max(1, TilingY);
		_nextFrameNum = StartFrame;
		_totalFrameCount = TilingX * TilingY;
		_tilingX = 1.0f / TilingX;
		_tilingY = 1.0f / TilingY;
		_frameTime = DurationTime / _totalFrameCount;
		//
		if (MainMaterial != null)
		{
			_tilingX = 1.0f / TilingX;
			_tilingY = 1.0f / TilingY;
			MainMaterial.mainTextureScale = new Vector2(_tilingX, _tilingY);
			MainMaterial.mainTextureOffset = new Vector2(_nextFrameNum % TilingX * _tilingX, 1 - (_nextFrameNum / TilingX) * _tilingY - _tilingY);
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (MainMaterial == null)
		{
			return false;
		}
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (property.ShareObj != null && Hide)
		{
			for (Int32 iter = 0; iter < property.ShareObj.Count; ++iter)
			{
				Renderer iterRender =  property.ShareObj[iter];
				iterRender.enabled = true;
			}
			//
			Hide = false;
		}
		if (_nextFrameNum >= _totalFrameCount)
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
		}
		//
		if (_elapseTime > _frameTime)
		{
			_elapseTime = 0.0f;
			MainMaterial.mainTextureOffset = new Vector2(_nextFrameNum % TilingX * _tilingX, 1 - (_nextFrameNum / TilingX) * _tilingY - _tilingY);
			++_nextFrameNum;
		}
		//
		_elapseTime += deltaTime;
		return true;
	}

	float _tilingX = 0.0f;
	float _tilingY = 0.0f;
	Int32 _nextFrameNum = 0;
	Int32 _totalFrameCount;
	float _frameTime = 0.0f;
}