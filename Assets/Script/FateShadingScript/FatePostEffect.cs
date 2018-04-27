using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class FatePostEffect : MonoBehaviour
{
	[Range(0.0f, 1.0f)]
	public float Scale = 0.0f;
	public float ScaleSup = 1.0f;
	public float ScaleSpeed = 1.0f;
	public Shader GrayEffectShader;

	void Start()
	{
		if (GrayEffectShader == null)
		{
			GrayEffectShader = Shader.Find("Fate Shading/Post Effect/GrayEffect");
		}
		if (GrayEffectShader != null)
		{
			_GrayEffectMaterial = new Material(GrayEffectShader);
		}
	}

	void OnRenderImage(RenderTexture sourceRT, RenderTexture TagertRT)
	{
		if (_GrayEffectMaterial == null)
		{
			Graphics.Blit(sourceRT, TagertRT);
		}
		else
		{
			_GrayEffectMaterial.SetFloat("_Trend", Scale);
			Graphics.Blit(sourceRT, TagertRT, _GrayEffectMaterial);
		}
	}

	void Update()
	{
		Scale += ScaleSpeed * Time.deltaTime;
		if (ScaleSpeed < 0.0f && Scale <= 0.0f)
		{
			enabled = false;
		}
		//
		Scale = ViMathDefine.Clamp(Scale, 0, ScaleSup);
	}

	Material _GrayEffectMaterial;
}
