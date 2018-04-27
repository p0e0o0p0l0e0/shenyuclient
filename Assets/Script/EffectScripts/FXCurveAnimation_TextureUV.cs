using System;
using System.Collections.Generic;
using UnityEngine;

public class FXCurveAnimation_TextureUV : FXCurveAnimation_Base
{
	public float TilingX = 1.0f;
	public float TilingY = 1.0f;
	public float XSpeed = 1.0f;
	public float YSpeed = 1.0f;
	public float OffsetX = 0.0f;
	public float OffsetY = 0.0f;
	public bool Repeat = false;
	public string ShaderUVName;

	public override void InitAnimation()
	{
		base.InitAnimation();
		_currentRender = GetComponent<Renderer>();
		if (_currentRender == null)
		{
			return;
		}
		//
		_currentRender.enabled = false;
		_material = _currentRender.material;
		if (string.IsNullOrEmpty(ShaderUVName))
		{
			_orginScale = _material.mainTextureScale;
			_orginOffset = _material.mainTextureOffset;
		}
		else
		{
			if (_material.HasProperty(ShaderUVName))
			{
				_orginOffset = _material.GetTextureOffset(ShaderUVName);
				_orginScale = _material.GetTextureScale(ShaderUVName);
			}
		}
		//
		FXCurveAnimation_AnimationSprite animation = GetComponent<FXCurveAnimation_AnimationSprite>();
		if (animation != null)
		{
			_tilingX = 1.0f / Math.Max(1, animation.TilingX);
			_tilingY = 1.0f / Math.Max(1, animation.TilingY);
		}
		else
		{
			_tilingX = TilingX;
			_tilingY = TilingY;
		}
		//
		Vector2 offset = new Vector2(OffsetX, OffsetY);
		Vector2 size = new Vector2(_tilingX, _tilingY);
		if (string.IsNullOrEmpty(ShaderUVName))
		{
			_material.mainTextureScale = size;
			_material.mainTextureOffset = offset;
		}
		else
		{
			if (_material.HasProperty(ShaderUVName))
			{
				_material.SetTextureOffset(ShaderUVName, offset);
				_material.SetTextureScale(ShaderUVName, size);
			}
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (_material == null)
		{
			return false;
		}
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (Hide)
		{
			_currentRender.enabled = true;
			Hide = false;
		}
		//
		OffsetX += deltaTime * XSpeed;
		OffsetY += deltaTime * YSpeed;
		if (!Repeat && (OffsetX > 1.0f || OffsetY > 1.0f))
		{
			if (string.IsNullOrEmpty(ShaderUVName))
			{
				_material.mainTextureOffset = Vector2.zero;
			}
			else
			{
				if (_material.HasProperty(ShaderUVName))
				{
					_material.SetTextureOffset(ShaderUVName, Vector2.zero);
				}
			}
			//
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
		if (string.IsNullOrEmpty(ShaderUVName))
		{
			_material.mainTextureOffset = _offset;
		}
		else
		{
			if (_material.HasProperty(ShaderUVName))
			{
				_material.SetTextureOffset(ShaderUVName, _offset);
			}
		}
		//
		_elapseTime += deltaTime;
		return true;
	}

	public override void Clear()
	{
		base.Clear();
		if (_material)
		{
			if (string.IsNullOrEmpty(ShaderUVName))
			{
				_material.mainTextureScale = _orginScale;
				_material.mainTextureOffset = _orginOffset;
			}
			else
			{
				if (_material.HasProperty(ShaderUVName))
				{
					_material.SetTextureOffset(ShaderUVName, _orginOffset);
					_material.SetTextureScale(ShaderUVName, _orginScale);
				}
			}
		}
	}

	Vector2 _offset = Vector2.zero;
	Vector3 _orginScale;
	Vector3 _orginOffset;
	float _tilingX = 0.0f;
	float _tilingY = 0.0f;
	Material _material;
	Renderer _currentRender;
}
