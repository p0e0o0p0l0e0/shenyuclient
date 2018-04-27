using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIRTT : MonoBehaviour
{
	public int Depth = 0;
	public Vector2 RenderSize = Vector2.one;
	//
	public Camera RTTCamera;
	public UITexture DisplayTexture;
	//public Material TextureMat;

	public void RenderToTexture(Camera camera)
	{
		RTTCamera = camera;
		//
		if (DisplayTexture == null)
		{
			DisplayTexture = NGUITools.AddWidget<UITexture>(gameObject);
			DisplayTexture.name = "TextureShow";
		}
		//
		if (_targetTexture == null)
		{
			_targetTexture = new RenderTexture(Mathf.RoundToInt(RenderSize.x), Mathf.RoundToInt(RenderSize.y), 24);
			_targetTexture.Create();
		}
		//
		Update();
		//
		//if (TextureMat.HasProperty("_MainTex"))
		//{
		//    TextureMat.SetTexture("_MainTex", _targetTexture);
		//}
		//
		DisplayTexture.width = Mathf.RoundToInt(RenderSize.x);
		DisplayTexture.height = Mathf.RoundToInt(RenderSize.y);
		//DisplayTexture.material = TextureMat;
		DisplayTexture.depth = Depth;
		DisplayTexture.mainTexture = _targetTexture;
		DisplayTexture.shader = Shader.Find("Unlit/Transparent Colored Add");
	}

	void Update()
	{
		if (RTTCamera != null && RTTCamera.targetTexture == null)
		{
			RTTCamera.targetTexture = _targetTexture;
			RTTCamera.Render();
		}
	}

	public void End()
	{
		if (RTTCamera != null)
		{
			RTTCamera.targetTexture = null;
		}
		if (_targetTexture != null)
		{
			_targetTexture.Release();
			RenderTexture.Destroy(_targetTexture);
		}
		if (DisplayTexture != null)
		{
			DisplayTexture.mainTexture = null;
		}
		RTTCamera = null;
		_targetTexture = null;
	}

	RenderTexture _targetTexture;
}

