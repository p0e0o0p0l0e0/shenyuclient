using System;
using UnityEngine;
using System.Collections;

public class UITextureAssistant
{
	public static void Transfer2Blur(UIAtlas atlas, UISpriteData sprite, ref RenderTexture targetTexture)
	{
		Transfer2Blur(atlas, sprite, 2, 2, 1.0f, ref targetTexture);
	}

	public static void Transfer2Blur(UIAtlas atlas, UISpriteData sprite, Int32 downsample, Int32 blurIterations, float blurSize, ref RenderTexture targetTexture)
	{
		if (atlas == null || sprite == null)
		{
			return;
		}
		if (_blurMaterial == null)
		{
			_blurMaterial = new Material(Shader.Find("Hidden/FastBlur"));
		}
		//
		Texture2D texture = atlas.texture as Texture2D;
		if (texture == null)
		{
			return;
		}
		//
		Texture2D texture2D = new Texture2D(sprite.width, sprite.height, TextureFormat.ARGB32, false);
		Color[] colors = texture.GetPixels(sprite.x, texture.height - sprite.height - sprite.y, sprite.width, sprite.height);
		texture2D.SetPixels(colors);
		texture2D.Apply();
		Transfer2Blur(texture2D, sprite.width, sprite.height, downsample, blurIterations, blurSize, ref targetTexture);
	}

	static void Transfer2Blur(Texture2D currentTexture2D, Int32 width, Int32 height, Int32 downsample, Int32 blurIterations, float blurSize, ref RenderTexture targetTexture)
	{
		if (targetTexture != null)
		{
			//targetTexture.Release();
			//GameObject.DestroyImmediate(targetTexture);
			targetTexture.DiscardContents();
		}
		else
		{
			targetTexture = new RenderTexture(width, height, 8, RenderTextureFormat.ARGB32);
			targetTexture.filterMode = FilterMode.Bilinear;
		}
		//
		RenderTexture.active = targetTexture;
		float widthMod = 1.0f / (1.0f * (1 << downsample));
		_blurMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod, -blurSize * widthMod, 0.0f, 0.0f));
		int rtW = targetTexture.width >> downsample;
		int rtH = targetTexture.height >> downsample;
		RenderTexture rt = RenderTexture.GetTemporary(targetTexture.width, targetTexture.height);
		rt.filterMode = FilterMode.Bilinear;
		Graphics.Blit(currentTexture2D, rt, _blurMaterial, 0);
		Int32 passOffs = 0;
		for (int i = 0; i < blurIterations; i++)
		{
			float iterationOffs = (i * 1.0f);
			_blurMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod + iterationOffs, -blurSize * widthMod - iterationOffs, 0.0f, 0.0f));
			RenderTexture rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, RenderTextureFormat.ARGB32);
			rt2.filterMode = FilterMode.Bilinear;
			Graphics.Blit(rt, rt2, _blurMaterial, 1 + passOffs);
			RenderTexture.ReleaseTemporary(rt);
			rt = rt2;
			rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, RenderTextureFormat.ARGB32);
			rt2.filterMode = FilterMode.Bilinear;
			Graphics.Blit(rt, rt2, _blurMaterial, 2 + passOffs);
			RenderTexture.ReleaseTemporary(rt);
			rt = rt2;
		}
		//
		Graphics.Blit(rt, targetTexture);
		RenderTexture.ReleaseTemporary(rt);
		GameObject.DestroyImmediate(currentTexture2D);
		RenderTexture.active = null;
	}

	static Material _blurMaterial;
}
