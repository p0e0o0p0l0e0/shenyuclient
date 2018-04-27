using System;

using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("Scene/SceneConfig")]
public class SceneConfig : MonoBehaviour
{
	[System.Serializable]
	public struct RendererInfo
	{
		public GameObject target;
		public int lightmapIndex;
		public Vector4 lightmapOffsetScale;
	}

	public RendererInfo[] RendererInfoes;
	public LightProbes SeceneLightProbes;
	public GameObject LightmapsRecorder;

	public Color AmbientColor;
	public Color AmbientEquatorColor;
	public Color AmbientGroundColor;
	public Color AmbientSkyColor;
	public LightmapsMode LightmapMode;

	public float HaloStrength = 0.5f;
	public bool Fog = false;
	public Color FogColor = Color.white * 0.4f;
	public float FogDensity = 0.01f;
	public FogMode FogMode = FogMode.Linear;
	public float FogStartDistance = 15.0f;
	public float FogEndDistance = 100;

	public Texture2D[] LightmapTextures;

	public UnityEngine.Rendering.AmbientMode RenderAmbientMode;
	public Transform Skybox;
	public float AmbientIntensity;

	public Texture2D SceneEnvironment;
	public List<ShadowMirrorPlane> planes = new List<ShadowMirrorPlane>();
	public GameObject ReflectionBox;

	public GameObject LODHeight;
	public GameObject LODLow;

	public bool IsActiveSpotLight = false;
	public AnimationCurve LightPower = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 0.4f), new Keyframe(0.9f, 0.4f), new Keyframe(1f, 1f));
	[HideInInspector]
	public float SpotLightDuration = 0.0f;

	public bool EnableMirror = false;
	public bool EnableShadow = false;
	public bool EnableBlendMixTerrien = false;

	public List<Material> materials = new List<Material>();

	void OnEnable()
	{
//		LoadFromPrefab();
		if (EnableBlendMixTerrien)
		{
			Shader.EnableKeyword("BLEND_ON");
		}
		else
		{
			Shader.DisableKeyword("BLEND_ON");
		}
	}

	void OnDisable()
	{
		RenderSettings.skybox = null;
		LightmapSettings.lightmaps = new UnityEngine.LightmapData[0];
	}

	void DelaiedUpdate()
	{

	}

	void Update()
	{
		if (IsActiveSpotLight)
		{
			_escapeTime += Time.deltaTime;
			float scale = LightPower.Evaluate(_escapeTime / SpotLightDuration);
			Shader.SetGlobalFloat("_ColorScale", scale);
		}
		if (_escapeTime > SpotLightDuration && IsActiveSpotLight)
		{
			IsActiveSpotLight = false;
		}
	}

	#region SaveToPrefab

	public void RecordLightSettings()
	{
		LightmapMode = LightmapSettings.lightmapsMode;
		AmbientSkyColor = RenderSettings.ambientSkyColor;
		AmbientEquatorColor = RenderSettings.ambientEquatorColor;
		AmbientGroundColor = RenderSettings.ambientGroundColor;
		AmbientColor = RenderSettings.ambientLight;
		AmbientIntensity = RenderSettings.ambientIntensity;
		RenderAmbientMode = RenderSettings.ambientMode;
		HaloStrength = RenderSettings.haloStrength;
		FogColor = RenderSettings.fogColor;
		FogMode = RenderSettings.fogMode;
		FogStartDistance = RenderSettings.fogStartDistance;
		FogEndDistance = RenderSettings.fogEndDistance;
	}

	public void CreateRecord(List<Texture2D> textureList)
	{
		SeceneLightProbes = LightmapSettings.lightProbes;
		for (int iter = 0; iter < LightmapSettings.lightmaps.Length; ++iter)
		{
			LightmapData iterData = LightmapSettings.lightmaps[iter];
			textureList.Add(iterData.lightmapColor);
			textureList.Add(iterData.lightmapDir);
		}
		//
		LightmapTextures = textureList.ToArray();
		//
		List<RendererInfo> rendererInfoList = new List<RendererInfo>();
		Terrain terrain = GameObject.FindObjectOfType<Terrain>();
		if (terrain)
		{
			RendererInfo info = new RendererInfo();
			info.lightmapIndex = terrain.lightmapIndex;
			info.target = terrain.gameObject;
			info.lightmapOffsetScale = terrain.lightmapScaleOffset;
			rendererInfoList.Add(info);
		}
		//
		materials.Clear();
		UnityComponentList<Renderer>.Begin(gameObject);
		for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
		{
			Renderer rend = UnityComponentList<Renderer>.List[iter];
			if (rend.lightmapIndex > -1)
			{
				RendererInfo rendererInfo = new RendererInfo();
				rendererInfo.target = rend.gameObject;
				rendererInfo.lightmapIndex = rend.lightmapIndex;
				rendererInfo.lightmapOffsetScale = rend.lightmapScaleOffset;
				rendererInfoList.Add(rendererInfo);
			}
			SaveShades(rend);
		}
		UnityComponentList<Renderer>.End();
		//
		this.RendererInfoes = rendererInfoList.ToArray();

	}


	public void SaveShades(Renderer render)
	{
		for (int iter = 0; iter < render.sharedMaterials.Length; ++iter)
		{
			Material iterMaterial = render.sharedMaterials[iter];
			materials.Add(iterMaterial);
		}
	}

	#endregion

	#region ReadFromPrefab

	public void LoadFromPrefab()
	{
		InitSpotLight();
		InitSceneEnvTex();
		InitLightSettings();
		InitLightmaps();
	}

	void InitSceneEnvTex()
	{
		if (SceneEnvironment != null)
		{
			Shader.SetGlobalTexture("_SceneEnvTex", SceneEnvironment);
		}
	}

	void InitSpotLight()
	{
		Shader.SetGlobalFloat("_ColorScale", 1.0f);
	}

	public void ResetSpotLight()
	{
		_escapeTime = 0.0f;
	}

	public void InitLightSettings()
	{
		RenderSettings.ambientLight = AmbientColor;
		RenderSettings.ambientEquatorColor = AmbientEquatorColor;
		RenderSettings.ambientGroundColor = AmbientGroundColor;
		RenderSettings.ambientSkyColor = AmbientSkyColor;
		RenderSettings.ambientMode = RenderAmbientMode;
		RenderSettings.haloStrength = HaloStrength;
		RenderSettings.ambientIntensity = AmbientIntensity;
		RenderSettings.ambientMode = RenderAmbientMode;

		RenderSettings.fog = Fog;
		RenderSettings.fogColor = FogColor;
		RenderSettings.fogDensity = FogDensity;
		RenderSettings.fogEndDistance = FogEndDistance;
		RenderSettings.fogMode = FogMode;
		RenderSettings.fogStartDistance = FogStartDistance;
	}

	void InitLightmaps()
	{
		List<LightmapData> tmpLightmapDatas = new List<LightmapData>();
		for (int iter = 0; iter < LightmapTextures.Length; ++iter)
		{
			Texture2D tmpLightmap;
			LightmapData tmpLD = new LightmapData();

			tmpLightmap = LightmapTextures[iter];
			tmpLD.lightmapColor = tmpLightmap;

			++iter;
			tmpLightmap = LightmapTextures[iter];
			tmpLD.lightmapDir = tmpLightmap;

			tmpLightmapDatas.Add(tmpLD);
		}
		//
		LightmapSettings.lightmaps = tmpLightmapDatas.ToArray();
		LightmapSettings.lightmapsMode = LightmapMode;
		//
		if (SeceneLightProbes != null)
		{
			LightProbes tempLightProbe = LightProbes.Instantiate(SeceneLightProbes) as LightProbes;
			LightmapSettings.lightProbes = tempLightProbe;
		}
		//
		for (int iter = 0; iter < RendererInfoes.Length; ++iter)
		{
			SceneConfig.RendererInfo info = RendererInfoes[iter];
			if (info.target == null)
			{
				continue;
			}
			Renderer rend = info.target.GetComponent<Renderer>();
			if (rend)
			{
				rend.lightmapIndex = info.lightmapIndex;
				rend.lightmapScaleOffset = info.lightmapOffsetScale;
			}
			Terrain terrain = info.target.GetComponent<Terrain>();
			if (terrain)
			{
				terrain.lightmapIndex = info.lightmapIndex;
				terrain.lightmapScaleOffset = info.lightmapOffsetScale;
			}
		}

		for (int iter = 0; iter < materials.Count; ++iter)
		{
			Material iterMaterial = materials[iter];
			Int32 renderQueue = iterMaterial.renderQueue;
			if (iterMaterial != null)
			{
				iterMaterial.shader = Shader.Find(iterMaterial.shader.name);
				iterMaterial.renderQueue = renderQueue;
			}
		}
	}



	private void OnValidate()
	{

	}

	float _escapeTime;

	#endregion
}