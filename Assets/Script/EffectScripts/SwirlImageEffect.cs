using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using System;

public enum SwirlStep
{
	IN,
	OUT,
}

public class SwirlImageEffect : MonoBehaviour
{
	[Range(0.0f, 360.0f)]
	public float Angle = 0;
	public float Range = 1.0f;
	public float DeltaTimeScale;
	public Vector4 Center = new Vector4(0.5f, 0.5f, 0.0f, 0.0f);
	public SwirlStep CurrentStep = SwirlStep.IN;
	public Action OnSwirlInComplete;
	public Action OnSwirlOutComplete;
	[Range(0.0f, 1.0f)]
	public float SampleDist = 0.17f;
	[Range(1.0f, 5.0f)]
	public float SampleStrength = 2.09f;
	public Shader RadialBlurShader = null;
	public float LocalScale = 1.0f;
	public float DelayUpdatePosTime = 0.5f;
	public float DelaySwirlTime = 0.5f;
	public AnimationCurve LocalScaleCure = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 1f), new Keyframe(0.9f, 0.8f), new Keyframe(1f, 0.8f));

	void Start()
	{
		_meshFilter = GetComponent<MeshFilter>();
		if (_meshFilter != null)
		{
			_orginscale.x = gameObject.transform.localScale.x;
			_orginscale.y = gameObject.transform.localScale.y;
		}
		//
		StartSwirl();
	}

	public void StartSwirl()
	{
		_delaySwirlTime = 0.0f;
		_scale = 1.0f;
		_delayUpdatePosTime = 0.0f;
		//
		if (RadialBlurShader == null)
		{
			RadialBlurShader = Shader.Find("Fate Shading/RadialBlur");
		}
		//
		if (_radialBlurMaterial == null)
		{
			_radialBlurMaterial = new Material(RadialBlurShader);
			_radialBlurMaterial.hideFlags = HideFlags.HideAndDontSave;
		}
		//
		_radius = ViMathDefine.Min(ViMathDefine.Max(0, _radius), Range);
		Renderer render = GetComponent<Renderer>();
		if (render == null)
		{
			return;
		}
		//
		_swirlMaterial = render.sharedMaterial;
		if (_swirlMaterial == null)
		{
			return;
		}
		//
		if (CurrentStep == SwirlStep.IN)
		{
			_swirlMaterial.SetFloat("_Angle", Angle);
			_swirlMaterial.SetVector("_Center", Center);
			Texture2D texture2D = _swirlMaterial.GetTexture("_SwirlTexture") as Texture2D;
			_swirlMaterial.SetTexture("_SwirlTexture", _UpdateRadialBlur(texture2D));
			_height = gameObject.GetComponent<MeshFilter>().mesh.bounds.size.y;
		}
		else
		{
			_swirlMaterial.SetFloat("_Angle", 0.0f);
			_swirlMaterial.SetFloat("_ColorRange", 0.0f);
		}
	}

	void LateUpdate()
	{
		//
		if (_swirlMaterial == null)
		{
			return;
		}
		//
		if (_swirlMaterial.shader == null)
		{
			return;
		}
		//
		_delayUpdatePosTime += Time.deltaTime;
		if (CurrentStep == SwirlStep.IN)
		{
			//
			if (_swirlMaterial != null && _delaySwirlTime > DelaySwirlTime)
			{
				_radius = _radius + Time.deltaTime * DeltaTimeScale;
				_swirlMaterial.SetFloat("_Radius", _radius);
			}
			//
			_swirlMaterial.SetFloat("_Dark", 1 - _radius * 0.5f);
			if (_delayUpdatePosTime > DelayUpdatePosTime)
			{
				_delaySwirlTime += Time.deltaTime;
				_UpdatePosAndScale(_radius + _delaySwirlTime);
			}
			//
			if (_radius > Range)
			{
				_swirlMaterial.SetFloat("_Dark", 0);
				if (OnSwirlInComplete != null)
				{
					OnSwirlInComplete();
					OnSwirlInComplete = null;
				}
			}
		}
		else
		{
			_radius = _radius - Time.deltaTime * DeltaTimeScale;
			_swirlMaterial.SetFloat("_Dark", 1 - _radius);
			if (_radius < 0)
			{
				if (OnSwirlOutComplete != null)
				{
					OnSwirlOutComplete();
				}
			}
		}
	}

	void _UpdatePosAndScale(float escapeTime)
	{
		_scale = _scale + Time.deltaTime * LocalScale;
		gameObject.transform.localScale = _orginscale * _scale;
		Vector3 pos = Vector3.zero;
		float tranScale = ViMathDefine.Max(0, _scale - 1);
		float value = LocalScaleCure.Evaluate(escapeTime / (Range + _delaySwirlTime));
		gameObject.transform.localPosition = new Vector3(pos.x, pos.y - tranScale * _height * 0.5f * value, pos.z);
	}

	RenderTexture _UpdateRadialBlur(Texture2D sourceTexture)
	{
		if (sourceTexture == null)
		{
			return null;
		}
		//
		if (_currentRT == null)
		{
			_currentRT = new RenderTexture(sourceTexture.width, sourceTexture.height, 8, RenderTextureFormat.ARGB32);
		}
		//
		int rtW = sourceTexture.width;
		int rtH = sourceTexture.height;
		_radialBlurMaterial.SetFloat("_SampleDist", SampleDist);
		_radialBlurMaterial.SetFloat("_SampleStrength", SampleStrength);
		_radialBlurMaterial.SetVector("_Center", Center);
		RenderTexture rtTempA = RenderTexture.GetTemporary(rtW, rtH, 0, RenderTextureFormat.Default);
		rtTempA.filterMode = FilterMode.Bilinear;
		Graphics.Blit(sourceTexture, rtTempA);
		RenderTexture rtTempB = RenderTexture.GetTemporary(rtW, rtH, 0, RenderTextureFormat.Default);
		rtTempB.filterMode = FilterMode.Bilinear;
		_radialBlurMaterial.SetTexture("_MainTex", rtTempA);
		Graphics.Blit(rtTempA, rtTempB, _radialBlurMaterial, 0);
		_radialBlurMaterial.SetTexture("_BlurTex", rtTempB);
		Graphics.Blit(sourceTexture, _currentRT, _radialBlurMaterial, 1);
		RenderTexture.ReleaseTemporary(rtTempA);
		RenderTexture.ReleaseTemporary(rtTempB);
		return _currentRT;
	}

	public void Clear()
	{
		if (_currentRT != null)
		{
			_currentRT.Release();
			DestroyImmediate(_currentRT);
			_currentRT = null;
		}
		//
		if (_radialBlurMaterial != null)
		{
			DestroyImmediate(_radialBlurMaterial);
			_radialBlurMaterial = null;
		}
	}

	void OnDestroy()
	{
		Clear();
	}

	float _radius = 0.0f;
	Material _swirlMaterial;
	Vector3 _orginscale = Vector3.zero;
	MeshFilter _meshFilter;
	Material _radialBlurMaterial = null;
	RenderTexture _currentRT;
	float _scale = 1.0f;
	float _delayUpdatePosTime = 0.0f;
	float _delaySwirlTime;
	float _height;
}
