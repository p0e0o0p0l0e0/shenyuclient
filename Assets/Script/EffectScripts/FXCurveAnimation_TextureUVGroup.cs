using System;
using System.Collections.Generic;
using UnityEngine;

public class FXCurveAnimation_TextureUVGroup : FXCurveAnimation_GroupBase
{
	public float TilingX = 1.0f;
	public float TilingY = 1.0f;
	public float XSpeed = 1.0f;
	public float YSpeed = 1.0f;
	public float OffsetX = 0.0f;
	public float OffsetY = 0.0f;
	public bool Repeat = false;

	public override void InitAnimation()
	{
		base.InitAnimation();
		//
		if (MainMaterial == null)
		{
			return;
		}
		//
		_orginScale = MainMaterial.mainTextureScale;
		_orginOffset = MainMaterial.mainTextureOffset;
		TilingX = Math.Max(1, TilingX);
		TilingY = Math.Max(1, TilingY);
		_tilingX = 1.0f / TilingX;
		_tilingY = 1.0f / TilingY;
		MainMaterial.mainTextureScale = new Vector2(_tilingX, _tilingY);
		MainMaterial.mainTextureOffset = new Vector2(OffsetX, OffsetY);
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (!base.UpdateAnimation(deltaTime))
		{
			return false;
		}
		if (property.ShareObj != null && Hide)
		{
			for (Int32 iter = 0; iter < property.ShareObj.Count; ++iter)
			{
				Renderer iterRender = property.ShareObj[iter];
				iterRender.enabled = true;
			}
			//
			Hide = false;
		}
		if (MainMaterial == null)
		{
			return false;
		}
		//
		OffsetX += deltaTime * XSpeed;
		OffsetY += deltaTime * YSpeed;
		if (!Repeat && (OffsetX > 1.0f || OffsetY > 1.0f))
		{
			MainMaterial.mainTextureOffset = Vector2.zero;
			if (AutoDestory)
			{
				GameObject.Destroy(gameObject);
			}
			return false;
		}
		//
		OffsetX = OffsetX - (float)Math.Truncate((double)OffsetX);
		OffsetY = OffsetY - (float)Math.Truncate((double)OffsetY);
		_offset.x = OffsetX;
		_offset.y = OffsetY;
		MainMaterial.mainTextureOffset = _offset;
		return true;
	}

	public override void Clear()
	{
		base.Clear();
		if (MainMaterial)
		{
			MainMaterial.mainTextureScale = _orginScale;
			MainMaterial.mainTextureOffset = _orginOffset;
		}
	}

	Vector2 _offset = Vector2.zero;
	Vector3 _orginScale;
	Vector3 _orginOffset;
	float _tilingX = 0.0f;
	float _tilingY = 0.0f;
}
