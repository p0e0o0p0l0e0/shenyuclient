using PhysicalShading;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameObjectNode
{
	public GameObject GameObject { get { return _root; } }
	public GameObject RealObject { get { return _realObject; } }
	public bool Ready { get { return _root != null && bReady; } }
	public ViActiveValue<Int32> Layer { get { return _layer; } }
	public void Start(PathFileResStruct res, GameObject parent)
	{
		Start(res, parent, true);
	}
	public void Start(PathFileResStruct res, GameObject parent, bool active)
	{
		_root = new GameObject(res.AssetBundleSectionName);
		_root.SetActive(active);
		_realObject = _root;
		UnityAssisstant.JionTransform(parent, GameObject);
        mResLoader.Start(res, OnLoad);
	}
	public void AttachTo(ViProvider<ViVector3> pos, bool active)
	{
		_tickNode.Attach(this.OnTick);
		_posProvider = pos;
		GameObject.transform.localPosition = _posProvider.Value.Convert();
		GameObject.SetActive(active);
	}
	public void Detach(bool active)
	{
		_tickNode.Detach();
		_posProvider = null;
		GameObject.SetActive(active);
	}
	public void Clear()
	{
        mResLoader.End();
        _tickNode.Detach();
		_posProvider = null;
		//
		UnityAssisstant.Destroy(ref _root);
	}
	void OnLoad(UnityEngine.Object pAsset)
	{
        bReady = true;
        GameObject obj = UnityAssisstant.Instantiate(pAsset as GameObject);
		obj.transform.parent = GameObject.transform;
		Int32 layer = 0;
		if (_layer.GetValue(ref layer))
		{
			UnityAssisstant.SetLayerRecursively(obj, layer);
		}
		_realObject = obj;
	}
	ViTickNode _tickNode = new ViTickNode();
	void OnTick(float deltaTime)
	{
		GameObject.transform.localPosition = _posProvider.Value.Convert();
	}

	GameObject _root;
	GameObject _realObject;
    bool bReady = false;
	ViProvider<ViVector3> _posProvider;
	ViActiveValue<Int32> _layer = new ViActiveValue<Int32>();
    ResourceRequest mResLoader = new ResourceRequest();
}
//
public class GlobalGameObject
{
	public static GlobalGameObject Instance { get { return _instance; } }
	static GlobalGameObject _instance = new GlobalGameObject();

	public Camera SceneCamera;
	//
	//public GameObject UIRoot;
	//public UIRoot NGUIRoot;

	//public float PixelAdjustment
	//{
	//	get
	//	{
	//		if (NGUIRoot == null)
	//		{
	//			return 1.0f;
	//		}
	//		return NGUIRoot.pixelSizeAdjustment;
	//	}
	//}

	public Camera UICamera;
	public CameraSwirlImageEffect SwirlImageEffect;
	public GameObject UIEnityNameRoot;
	public GameObject UIFightText_Critical;
	public GameObject UIFightText_Normal;
	public GameObject UIFightText_State;
	//
	public GameObject UIAtlasRoot;
	//
	public GameObject RTTCameraPrefab;
	public GameObject RTTRoot;
	//
	//
	public GameObject DebugHint;
	//
	public GameObject AudioListener;
	//
	public GlobalGameObjectNode FocusEntity = new GlobalGameObjectNode();
	//
	public GlobalGameObjectNode MoveDestHintOnce = new GlobalGameObjectNode();
	public GlobalGameObjectNode MoveDestHintLoop = new GlobalGameObjectNode();
	//
	public GlobalGameObjectNode MaterialInstance = new GlobalGameObjectNode();
	//
	public GlobalGameObjectNode WindowMask = new GlobalGameObjectNode();
	//
	public GlobalGameObjectNode TouchEffect = new GlobalGameObjectNode();
	public GlobalGameObjectNode TouchSoundEffect = new GlobalGameObjectNode();
	//
	public GlobalGameObjectNode AOIEffect = new GlobalGameObjectNode();
	public GlobalGameObjectNode SpellRangeEffect = new GlobalGameObjectNode();
	//
	public GlobalGameObjectNode NavigateCube = new GlobalGameObjectNode();

    public GlobalGameObjectNode LoginScene = new GlobalGameObjectNode();
    //
    public GameObject Text3DPrefab;
	//
	public void Start(GameObject gameObject)
	{
        _CreateCamera();
        //UIRoot = gameObject.GetChild("UI Root");
		//NGUIRoot = UIRoot.GetComponent<UIRoot>();
		//UICamera = UIRoot.GetChild("UICamera").GetComponent<Camera>();
		//SwirlImageEffect = UIRoot.GetChild("UICamera").GetComponent<CameraSwirlImageEffect>();
		//UIEnityNameRoot = UIRoot.GetChild("UIEntityNamesRoot");
		//UIFightText_Critical = UIRoot.GetChild("UIFightDamageText_Critical");
		//UIFightText_Normal = UIRoot.GetChild("UIFightDamageText_Normal");
		//UIFightText_State = UIRoot.GetChild("UIFightDamageText_State");
		//
		//UIAtlasRoot = gameObject.GetChild("UIAtlasRoot");
		//
		//RTTCameraPrefab = gameObject.GetChild("RTTCamera");
		//RTTRoot = gameObject.GetChild("RTTRoot"); 
		//
		//DebugHint = gameObject.GetChild("DebugHint");
		//
		AudioListener = gameObject.GetChild("AudioListener");
		//
		//Text3DPrefab = gameObject.GetChild("Text3D");
		//Text3DPrefab.SetActive(false);
		//
		//UnityAssisstant.DebugHint = DebugHint;
	}


	public void LoadDynamic()
	{
		FocusEntity.Start(GamePathFileResInstance.Focus_Enemy, GameObjectPath.Instance.GlobalPath, false);
		MoveDestHintOnce.Start(GamePathFileResInstance.Spell_Area, GameObjectPath.Instance.GlobalPath, false);
		MoveDestHintLoop.Start(GamePathFileResInstance.Spell_Area, GameObjectPath.Instance.GlobalPath, false);
		MaterialInstance.Start(GamePathFileResInstance.MaterialInstance, GameObjectPath.Instance.GlobalPath, false);
		TouchEffect.Start( GamePathFileResInstance.Spell_Area, GameObjectPath.Instance.GlobalPath, false);
		TouchEffect.Layer.Set((Int32)UnityLayer.UI);
		TouchSoundEffect.Start(GamePathFileResInstance.Spell_Area, GameObjectPath.Instance.GlobalPath, false);
		AOIEffect.Start(GamePathFileResInstance.Attack_Area, GameObjectPath.Instance.GlobalPath, false);
		SpellRangeEffect.Start(GamePathFileResInstance.Spell_Area, GameObjectPath.Instance.GlobalPath, false);
        LoginScene.Start(GamePathFileResInstance.LoginScene, GameObjectPath.Instance.GlobalPath, false);
    }

    public void End()
	{
		
	}

	//public void UIRootFitWidth(bool fit)
	//{
	//	NGUIRoot.fitWidth = fit;
	//}

	public void SetWindowMaskAlpha(float alpha)
	{
        if (WindowMask.GameObject == null)
        {
            return;
        }
		UISprite maskSprite = WindowMask.GameObject.GetComponentInChildren<UISprite>();
		if (maskSprite != null)
		{
			maskSprite.alpha = alpha;
		}
	}


	public GlobalGameObjectNode Icon3D_Junk { get { return GetIcon3D(1); } }
	public GlobalGameObjectNode Icon3D_YinPiao { get { return GetIcon3D(2); } }
	public GlobalGameObjectNode Icon3D_XP { get { return GetIcon3D(3); } }
	public GlobalGameObjectNode Icon3D_JinPiao { get { return GetIcon3D(6); } }
	public GlobalGameObjectNode GetIcon3D(Int32 ID)
	{
		GlobalGameObjectNode node;
		_icon3DList.TryGetValue(ID, out node);
		return node;
	}

	public void CreateIcon3D()
	{
		List<Icon3DStruct> infoList = ViSealedDB<Icon3DStruct>.Array;
		for (Int32 iter = 0; iter < infoList.Count; ++iter )
		{
			Icon3DStruct iterInfo = infoList[iter];
			if (iterInfo.Res.NotEmpty())
			{
				CreateIcon3D(iterInfo);
			}
		}
	}

	public void ClearIcon3D()
	{
		foreach (KeyValuePair<Int32, GlobalGameObjectNode> iter in _icon3DList)
		{
			iter.Value.Clear();
		}
		_icon3DList.Clear();
	}

	GlobalGameObjectNode CreateIcon3D(Icon3DStruct info)
	{
		GlobalGameObjectNode node = new GlobalGameObjectNode();
		node.Start(info.Res.Data, GameObjectPath.Instance.GlobalPath, false);
		_icon3DList.Add(info.ID, node);
		return node;
	}
	Dictionary<Int32, GlobalGameObjectNode> _icon3DList = new Dictionary<Int32, GlobalGameObjectNode>();


    void _CreateCamera()
    {
        GameObject camera = new GameObject();
        SceneCamera = camera.AddComponent<Camera>();
        camera.AddComponent<RenderPipeline>();
        // if (!GameApplication.Instance.IsEditor)
        //{

        // }
        SceneCamera.name = "GameMainCamera";
        //SceneCamera.clearFlags = CameraClearFlags.Nothing;
        SceneCamera.cullingMask = (Int32)UnityLayer.SCENE_VIEW_MASK;
        SceneCamera.renderingPath = RenderingPath.Forward;
    }

}


