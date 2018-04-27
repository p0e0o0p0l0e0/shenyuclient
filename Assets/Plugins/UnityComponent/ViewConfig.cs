using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class ViewConfig : MonoBehaviour
{
	public Camera ViewCamera;
	public GameObject Route;
	public bool IsEnableAirFlow = false;
	public Texture2D AirFlowTex;
	public Vector4 AirFlowTexTillingOffset = new Vector4(1.0f, 1.0f, 0.0f, 0.0f);
	public Vector2 AirFlowTexOffsetSpeed = Vector2.zero;
	public Color AirFlowTexColor = Color.white;
	[Range(0.01f, 1000.0f)]
	public float AirFlowStartDepth = 20.0f;
	[Range(0.01f, 1000.0f)]
	public float AirFlowDepth = 50.0f;
	[Range(0.01f, 1000.0f)]
	public float AirFlowDistance = 50.0f;

	public Color FogColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
	[Range(-10.0f, 1000.0f)]
	public float FogStartDepth = 20.0f;
	[Range(0.01f, 1000.0f)]
	public float FogDepth = 50.0f;

	public bool IsEnableCloudShadow = false;
	public Texture2D CloudShadowTex;
	public Vector4 CloudShadowParam = new Vector4(1.0f, 1.0f, 0.0f, 0.0f);
	public Color CloudShadowColor = Color.black;

	public bool EnableGrassAnimation;
	public float Wavelength = 2.0f;
	public float Frequency = 2.0f;
	public float Amplitude = 1.0f;
	public Vector4 WaveDirection;

	void Start()
	{

	}

	void OnEnable()
	{
		InitAirFlow();
		//
		if (IsEnableAirFlow && AirFlowTex != null)
		{
			if (!Shader.IsKeywordEnabled("USE_FOG"))
			{
				Shader.EnableKeyword("USE_FOG");
			}
			//
			Shader.SetGlobalTexture("_AirFlowTex", AirFlowTex);
			Shader.SetGlobalFloat("_AirFlowStartDepth", AirFlowStartDepth);
			Shader.SetGlobalFloat("_AirFlowDepth", AirFlowDepth);
			Shader.SetGlobalColor("_AirFlowColor", AirFlowTexColor);
			Shader.SetGlobalVector("_AirFlowTex_ST", AirFlowTexTillingOffset);
			//
			Shader.SetGlobalFloat("_Depth", FogDepth);
			Shader.SetGlobalFloat("_StartDepth", FogStartDepth);
			Shader.SetGlobalColor("_FogColor", FogColor);
		}
		else if (Shader.IsKeywordEnabled("USE_FOG"))
		{
			Shader.DisableKeyword("USE_FOG");
		}

		if (IsEnableCloudShadow)
		{
			Shader.EnableKeyword("CLOUD_SHADOW");
			Shader.SetGlobalTexture("_CloudShadow", CloudShadowTex);
			Shader.SetGlobalColor("_CloudShadowColor", CloudShadowColor);
			Shader.SetGlobalVector("_Params", CloudShadowParam);
			_lastCloudShadowPrarm = CloudShadowParam;
		}
		else
		{
			Shader.DisableKeyword("CLOUD_SHADOW");
		}

		if (EnableGrassAnimation)
		{
			Shader.EnableKeyword("VERTEX_ANIMATION_ON");
		}
		else
		{
			Shader.DisableKeyword("VERTEX_ANIMATION_ON");
		}
	}

	void InitAirFlow()
	{
		if (IsEnableAirFlow && AirFlowTex != null)
		{
			if (!Shader.IsKeywordEnabled("USE_FOG"))
			{
				Shader.EnableKeyword("USE_FOG");
			}
			//
			Shader.SetGlobalTexture("_AirFlowTex", AirFlowTex);
			Shader.SetGlobalFloat("_AirFlowStartDepth", AirFlowStartDepth);
			Shader.SetGlobalFloat("_AirFlowDepth", AirFlowDepth);
			Shader.SetGlobalColor("_AirFlowColor", AirFlowTexColor);
			Shader.SetGlobalVector("_AirFlowTex_ST", AirFlowTexTillingOffset);
			//
			Shader.SetGlobalFloat("_Depth", FogDepth);
			Shader.SetGlobalFloat("_StartDepth", FogStartDepth);
			Shader.SetGlobalColor("_FogColor", FogColor);
		}
		else if (Shader.IsKeywordEnabled("USE_FOG"))
		{
			Shader.DisableKeyword("USE_FOG");
		}
		if (IsEnableCloudShadow && CloudShadowParam != _lastCloudShadowPrarm)
		{
			Shader.SetGlobalVector("_Params", CloudShadowParam);
			_lastCloudShadowPrarm = CloudShadowParam;
		}
	}

	public void InitViewCameraInfo()
	{
		if (ViewCamera != null)
		{
			_lastCameraRat = ViewCamera.transform.rotation;
			_lastCameraPos = ViewCamera.transform.position;
		}
	}

	void Update()
	{
		if (IsEnableAirFlow && AirFlowTex != null)
		{
			if (AirFlowTexOffsetSpeed.x != 0 || AirFlowTexOffsetSpeed.y != 0)
			{
				_fogOffset.x += AirFlowTexOffsetSpeed.x * Time.deltaTime;
				_fogOffset.y += AirFlowTexOffsetSpeed.y * Time.deltaTime;
			}
			//
			if (ViewCamera != null)
			{
				Quaternion currentRat = ViewCamera.transform.rotation;
				Vector3 currentPos = ViewCamera.transform.position;
				Vector3 deltaPos = currentPos - _lastCameraPos;
				Vector3 objectPos = ViewCamera.transform.InverseTransformVector(deltaPos);
				Vector3 deltaUV = objectPos / AirFlowDistance;
				float Deg2Rad = 0.01745329f;
				deltaUV /= ViewCamera.fieldOfView * Deg2Rad;
				deltaUV.x /= ViewCamera.aspect;
				_fogOffset.x += deltaUV.x * AirFlowTexTillingOffset.x;
				_fogOffset.y += deltaUV.y * AirFlowTexTillingOffset.y;
				//
				_lastCameraRat = currentRat;
				_lastCameraPos = currentPos;
			}
			//
			_fogOffset.x = Wrap(_fogOffset.x, 0, 1);
			_fogOffset.y = Wrap(_fogOffset.y, 0, 1);
			Shader.SetGlobalVector("_AirFlowOffset", _fogOffset);
		}
		//
		if (EnableGrassAnimation)
		{
			_elapseTime += Time.deltaTime;
			Shader.SetGlobalVector("_Offset", WaveDirection * (float)Math.Cos(2 * Math.PI * Frequency * _elapseTime - 2 * Math.PI / Wavelength) * Amplitude);
		}
	}

	public float Wrap(float val, float low, float high)// 取值范围[low, high)
	{
		float ret = (val);
		float rang = (high - low);

		while (ret >= high)
		{
			ret -= rang;
		}
		while (ret < low)
		{
			ret += rang;
		}
		return ret;
	}

	void OnValidate()
	{
		if (IsEnableAirFlow && AirFlowTex != null)
		{
			Shader.SetGlobalTexture("_AirFlowTex", AirFlowTex);
			Shader.SetGlobalFloat("_AirFlowStartDepth", AirFlowStartDepth);
			Shader.SetGlobalFloat("_AirFlowDepth", AirFlowDepth);
			Shader.SetGlobalColor("_AirFlowColor", AirFlowTexColor);
			Shader.SetGlobalVector("_AirFlowTex_ST", AirFlowTexTillingOffset);
			//
			Shader.SetGlobalFloat("_Depth", FogDepth);
			Shader.SetGlobalFloat("_StartDepth", FogStartDepth);
			Shader.SetGlobalColor("_FogColor", FogColor);
		}
		if (IsEnableCloudShadow && CloudShadowTex != null)
		{
			Shader.SetGlobalTexture("_CloudShadow", CloudShadowTex);
			Shader.SetGlobalColor("_CloudShadowColor", CloudShadowColor);
			Shader.SetGlobalVector("_Params", CloudShadowParam);
		}
	}

	void OnDisable()
	{
		Clear();
	}

	void OnDestory()
	{
		Clear();
	}

	public void Clear()
	{
		if (Shader.IsKeywordEnabled("USE_FOG"))
		{
			Shader.DisableKeyword("USE_FOG");
		}
		if (Shader.IsKeywordEnabled("CLOUD_SHADOW"))
		{
			Shader.DisableKeyword("CLOUD_SHADOW");
		}
	}

	Vector2 _fogOffset = Vector2.zero;
	Quaternion _lastCameraRat = Quaternion.identity;
	Vector3 _lastCameraPos = Vector3.zero;
	//
	Vector4 _lastCloudShadowPrarm = new Vector4();
	//
	float _elapseTime;
}
