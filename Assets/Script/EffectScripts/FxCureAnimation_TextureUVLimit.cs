using System;
using System.Collections.Generic;
using UnityEngine;

public class FxCureAnimation_TextureUVLimit : FXCurveAnimation_Base
{
	public AnimationCurve XOffsetCurve = new AnimationCurve();
	public AnimationCurve YOffsetCurve = new AnimationCurve();
	public string ShaderUVName;

	public float TilingX = 1.0f;
	public float TilingY = 1.0f;
	public float OffsetX = 0.0f;
	public float OffsetY = 0.0f;
	public bool Repeat = false;

	public override void InitAnimation()
	{
		base.InitAnimation();
		_currentRender = GetComponent<Renderer>();
		if (_currentRender == null)
		{
			return;
		}
		_material = _currentRender.material;
		_currentRender.enabled = false;
		if (string.IsNullOrEmpty(ShaderUVName))
		{
			_orginScale = _material.mainTextureScale;
			_orginOffset = _material.mainTextureOffset;
		}
		else
		{
			if (_material.HasProperty (ShaderUVName)) 
			{
				_orginOffset = _material.GetTextureOffset (ShaderUVName);
				_orginScale = _material.GetTextureScale (ShaderUVName);
			}
		}
		//
		_tilingX = TilingX;
		_tilingY = TilingY;
		//
		Vector2 offset = new Vector2(OffsetX, OffsetY);
		Vector2 size = new Vector2(_tilingX, _tilingY);
		//
		if (string.IsNullOrEmpty(ShaderUVName))
		{
			_material.mainTextureScale = size;
			_material.mainTextureOffset = offset;
		}
		else
		{
			if (_material.HasProperty (ShaderUVName)) 
			{
				_material.SetTextureOffset (ShaderUVName, offset);
				_material.SetTextureScale (ShaderUVName, size);
			}
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (_material == null)
		{
			return false;
		}
		if (_currentRender == null)
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
		if (_elapseTime > DurationTime)
		{
			if (!Repeat)
			{
				if (AutoDestory)
				{
					GameObject.Destroy(gameObject);
				}
			}
			//
			return false;
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float xValue = _elapseTime / DurationTime;
		float scaleValueX = XOffsetCurve.Evaluate(xValue);
		float scaleValueY = YOffsetCurve.Evaluate(xValue);
		_offset.x = scaleValueX + OffsetX;
		_offset.y = scaleValueY + OffsetY;
		if (string.IsNullOrEmpty(ShaderUVName))
		{
			_material.mainTextureOffset = _offset;
		}
		else
		{
			if (_material.HasProperty (ShaderUVName)) 
			{
				_material.SetTextureOffset (ShaderUVName, _offset);
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
				if (_material.HasProperty (ShaderUVName)) 
				{
					_material.SetTextureOffset (ShaderUVName, _orginOffset);
					_material.SetTextureScale (ShaderUVName, _orginScale);
				}
			}
		}
	}

	Renderer _currentRender;
	Material _material;
	Vector2 _offset = Vector2.zero;
	Vector3 _orginScale;
	Vector3 _orginOffset;
	float _tilingX = 0.0f;
	float _tilingY = 0.0f;
}
