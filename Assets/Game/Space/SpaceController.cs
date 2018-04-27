using System;
using System.Collections.Generic;
using UnityEngine;


public class SpaceController
{
	public static ViConstValue<Int32> VALUE_SpaceLoadingDuration = new ViConstValue<Int32>("SpaceLoadingDuration", 300);
	//
	public SpaceNavigator Navigator { get { return _navigator; } }
	public GameObject Root { get { return _root; } }
	public GameObject Static { get { return _staticRes; } }
	public SceneConfig SceneConfigProperty { get { return _sceneConfig; } }
	public ViewConfig ViewConfigProperty { get { return _viewConfig; } }
	//public GameObject Dynamic { get { return _dynamicRes; } }
	public GameObject View { get { return _view; } }
	public Camera Camera { get { return _camera; } }
	public float CameraScale { get { return _cameraScale; } }
	public delegate void DeleCompleted();
	public DeleCompleted CallbackCompleted;
	public ViPriorityValue<Int32> LODLevel { get { return _LODLevel; } }
	public ViPriorityValue<bool> ShadowSettingValue { get { return _shadowSettingValue; } }
	public ViPriorityValue<bool> MirrorCharacterSettingValue { get { return _mirrorCharacterSettingValue; } }
	public ViPriorityValue<bool> MirrorSceneSettingValue { get { return _mirrorSceneSettingValue; } }
	public ViPriorityValue<bool> ColorEnhanceSettingValue { get { return _colorEnhanceSettingValue; } }
	public ViPriorityValue<bool> BloomSettingValue { get { return _bloomSettingValue; } }

	public void Load(SpaceConfigStruct info)
	{
        
		_navigateArea = new Rect(info.Area.MinX * 0.01f, info.Area.MinY * 0.01f, info.Area.WidthX * 0.01f, info.Area.WidthY * 0.01f);

        mNavResLoader.Start(ResourcePath.NavMap + "/" + info.Area.NavMap, info.Area.NavMap, OnNavMapLoaded);
        mSceneResLoader.Start(info.StaticResource.Data, OnSceneLoaded);

        ShadowSettingValue.Add("Setting", 10, ApplicationSetting.Instance.GraphicsShadow != 0);
		MirrorCharacterSettingValue.Add("Setting", 10, ApplicationSetting.Instance.GraphicsMirrorCharacter != 0);
		MirrorSceneSettingValue.Add("Setting", 10, ApplicationSetting.Instance.GraphicsMirrorScene != 0);
		ColorEnhanceSettingValue.Add("Setting", 10, ApplicationSetting.Instance.GraphicsColorEnhance != 0);
		BloomSettingValue.Add("Setting", 10, ApplicationSetting.Instance.GraphicsBloom != 0);
		LODLevel.Add("Setting", 10, ApplicationSetting.Instance.GraphicsMainLevel);



        if (!info.SkyRes.IsNullOrEmpty())
        {
            mSkyBoxLoader = new ResourceRequest();
            mSkyBoxLoader.Start(ResourcePath.Sky + "/" + info.SkyRes, info.SkyRes, OnSkyBoxLoaded);
        }

    }

    public void Clear()
	{
		GameApplication.Instance.AudioListener.RotValue.Del(GameKeyWord.Space);
		CameraController.Instance.Clear();

        mNavResLoader.End();
        mSceneResLoader.End();
        if(mSkyBoxLoader != null)
            mSkyBoxLoader.End();

        CallbackCompleted = null;
		if (_viewConfig != null)
		{
			_viewConfig.Clear();
		}
		//
		_navigator.Clear();
		//
		UnityAssisstant.Destroy(ref _staticRes);
		//UnityAssisstant.Destroy(ref _root);
        Resources.UnloadUnusedAssets();
    }

    void OnSkyBoxLoaded(UnityEngine.Object pAsset)
    {
        RenderSettings.skybox = pAsset as Material;
        mSkyBoxLoader.End();
    }

    void OnNavMapLoaded(UnityEngine.Object pAsset)
    {
        _navigator.Load(_navigateArea, ((GameObject)pAsset).GetComponent<BlobStream>().GetData());
        if (_staticRes != null && CallbackCompleted != null)
        {
            CallbackCompleted();
        }
        mNavResLoader.End();
    }

	void OnSceneLoaded(UnityEngine.Object pAsset)
	{
		UnityAssisstant.Destroy(ref _staticRes);

		_staticRes = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _root.transform);

		UnityAssisstant.SetStaticRecursively(_staticRes, true);
		SetLayer(_staticRes, "Water", (Int32)UnityLayer.WATER);
		SetLayer(_staticRes, "Ground", (Int32)UnityLayer.GROUND);
		SetLayer(_staticRes, "GroundAlpha", (Int32)UnityLayer.GROUND_ALPHA);
		SetLayer(_staticRes, "Scene", (Int32)UnityLayer.SCENE);
		SetLayer(_staticRes, "SceneAlpha", (Int32)UnityLayer.SCENE_ALPHA);
		StaticBatchingUtility.Combine(_staticRes);
        //TODO 需要创建灯光，需要使用灯光的方向 
        // 所有的
        //  需要相机
        GlobalGameObject.Instance.SceneCamera.farClipPlane = 400.0f;
        GlobalGameObject.Instance.SceneCamera.nearClipPlane = 0.5f;
        if (_navigator.IsReady && CallbackCompleted != null)
		{
			CallbackCompleted();
		}
        mSceneResLoader.End();

    }

	static void SetLayer(GameObject obj, string childName, Int32 value)
	{
		Transform childTransform = obj.transform.Find(childName);
		if (childTransform != null)
		{
			UnityAssisstant.SetLayerRecursively(childTransform.gameObject, value);
		}
	}

	void FormatView(Transform viewTran)
	{
		GlobalGameObject.Instance.SceneCamera = viewTran.gameObject.GetComponentInChildren<Camera>();
		for (int iter = 0; iter < viewTran.childCount; ++iter)
		{
			Transform iterTran = viewTran.GetChild(iter);
			iterTran.localPosition = Vector3.zero;
			iterTran.localRotation = Quaternion.identity;
		}
		//
		_camera = viewTran.GetComponentInChildren<Camera>();
		_camera.clearFlags = CameraClearFlags.Nothing;
		_camera.cullingMask = (Int32)UnityLayer.SCENE_VIEW_MASK;
		_camera.renderingPath = RenderingPath.Forward;
		if (_camera.orthographic)
		{
			_cameraSize = _camera.orthographicSize;
		}
		else
		{
			_cameraSize = _camera.fieldOfView;
		}
	}

	public void StartVRModel(float maxDistance)
	{
		VRViewer viewVR = View.AddComponent<VRViewer>();
		viewVR.Camera = Camera;
		viewVR.InitDevice();
		viewVR.LookAt = true;
		viewVR.LootAtDistanceSup = maxDistance;
		Camera.cullingMask = 0;
	}

	public void EndVRModel()
	{
		UnityAssisstant.DelComponent<VRViewer>(Camera.gameObject);
		Camera.cullingMask = (Int32)UnityLayer.SCENE_VIEW_MASK;
	}

	static ViConstValue<float> VALUE_SpaceViewScaleSup = new ViConstValue<float>("SpaceViewScaleSup", 2.0f);
	static ViConstValue<float> VALUE_SpaceViewScaleInf = new ViConstValue<float>("SpaceViewScaleInf", 1.0f);
	float _cameraScale = 1.0f;
	public void OnTouchLineStart()
	{
		
	}
	public void OnTouchLineEnd()
	{

	}
	public void OnTouchLineUpdate(float deltaScale, float rotate)
	{
		_cameraScale *= deltaScale;
		_cameraScale = ViMathDefine.Clamp(_cameraScale, VALUE_SpaceViewScaleInf, VALUE_SpaceViewScaleSup);
		//
		if (Camera.orthographic)
		{
			Camera.orthographicSize = _cameraSize / _cameraScale;
		}
		else
		{
			Camera.fieldOfView = _cameraSize / _cameraScale;
		}
	}

	GameObject _root = new GameObject("Scene");
	GameObject _staticRes;
	GameObject _view;
	ViewConfig _viewConfig;
	SceneConfig _sceneConfig;
	//
	SpaceNavigator _navigator = new SpaceNavigator();
	Rect _navigateArea;
	Camera _camera;
	float _cameraSize;
	//
	ViPriorityValue<Int32> _LODLevel = new ViPriorityValue<Int32>(0);
	ViPriorityValue<bool> _shadowSettingValue = new ViPriorityValue<bool>(false);
	ViPriorityValue<bool> _mirrorCharacterSettingValue = new ViPriorityValue<bool>(false);
	ViPriorityValue<bool> _mirrorSceneSettingValue = new ViPriorityValue<bool>(false);
	ViPriorityValue<bool> _colorEnhanceSettingValue = new ViPriorityValue<bool>(false);
	ViPriorityValue<bool> _bloomSettingValue = new ViPriorityValue<bool>(false);

    ResourceRequest mNavResLoader = new ResourceRequest();
    ResourceRequest mSceneResLoader = new ResourceRequest();
    ResourceRequest mSkyBoxLoader = new ResourceRequest();
}
