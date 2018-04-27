using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class FateAntiAliasing : MonoBehaviour
{
	public Shader FXAAShader;
	public float EdgeThresholdMin = 0.125f;
	public float EdgeThreshold = 0.25f;
	public float EdgeSharpness = 4.0f;

	void Start()
	{
		FXAAShader = Shader.Find("Fate Shading/Post Effect/FXAA");
		_FXAAMaterial = new Material(FXAAShader);
	}

	void OnRenderImage(RenderTexture sourceRT, RenderTexture tagertRT)
	{
		_FXAAMaterial.SetFloat("_EdgeThresholdMin", EdgeThresholdMin);
		_FXAAMaterial.SetFloat("_EdgeThreshold", EdgeThreshold);
		_FXAAMaterial.SetFloat("_EdgeSharpness", EdgeSharpness);
		Graphics.Blit(sourceRT, tagertRT, _FXAAMaterial);
	}

	Material _FXAAMaterial;
}
