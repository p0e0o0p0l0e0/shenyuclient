using System;
using UnityEngine;

public class AttachedSpaceExpress : ViExpressInterface
{
	public static AttachedSpaceExpress GetPosExpress(ViExpressOwnList<ViExpressInterface> expressList, Transform parentTran, string name)
	{
		expressList.List.BeginIterator();
		while (!expressList.List.IsEnd())
		{
			AttachedSpaceExpress express = StandardAssisstant.DynamicCast<AttachedSpaceExpress>(expressList.List.CurrentNode.Data);
			expressList.List.Next();
			if (express != null && System.Object.ReferenceEquals(express.ParentTransform, parentTran) && express.Name == name)
			{
				return express;
			}
		}
		return null;
	}

	public float Scale
	{
		get { return _scale; }
		set
		{
			if (value != 0)
			{
				_scale = value;
				UpdateState();
			}
		}
	}

	public UInt32 AttachMask;
	public Int32 Layer = (Int32)UnityLayer.DEFAULT;
	public string SwitchLayer = string.Empty;
	public Transform ParentTransform { get { return _parentTransform; } }
	public string Name { get { return _name; } }
	public GameObject Root
	{
		get
		{
			return _obj;
		}
	}

	public bool SoundDuration = false;
	public bool CameraAnim = false;
    public bool IsLocal = false;
    public delegate void OnLoadedCompleteDele(GameObject obj);
	public OnLoadedCompleteDele OnLoadedCompleteCallback;


    public void Start(PathFileResStruct res, Transform transform, ViVector3 offset, UInt32 attachMask, float delayTime, float duration, float fadeTime)
    {
        AttachMask = attachMask;
        Start(res, delayTime, transform, offset);
        SetDuration(delayTime + duration);
    }
    public void Start(PathFileResStruct res, Transform transform)
	{
		Start(res, 0, transform, ViVector3.ZERO);
	}

	public void Start(PathFileResStruct res, float delayTime, Transform transform, ViVector3 offset)
    {
        _res = res;
        _name = res.Name;

        if (transform == null)
		{
			return;
		}
		_parentTransform = transform;
		_offset = offset;

        if (delayTime <= 0)
        {
            mResLoader.Start(res, _OnResLoaded, true);
        }
        else
        {
            ViTimerVisualInstance.SetTime(_timeNode, delayTime, this.OnStartTime);
        }
        //
        AttachUpdate();
    }
    void OnStartTime(ViTimeNodeInterface node)
    {
        mResLoader.Start(_res, _OnResLoaded, true);
    }

	public override void End()
	{
        mResLoader.End();
        if (_obj != null)
		{
			_obj.transform.parent = null;
		}
		_parentTransform = null;
		UnityDeletor.Node deleteNode = UnityAssisstant.DestroyEx(ref _obj);
		_endTimeNode.Detach();
        _res = null;
        _timeNode.Detach();
        base.End();
	}

	public void DetachToWorld()
	{
		if (_obj != null)
		{
			_obj.transform.parent = null;
		}
	}

	public override void Update(float deltaTime)
	{
		if (ViMask32.HasAny(AttachMask, (UInt32)ExpressAttachMask.NO_ROTATE))
		{
			if (_obj != null && _parentTransform != null)
			{
				_obj.transform.localPosition = _parentTransform.transform.position;
			}
		}
	}

	void _OnResLoaded(UnityEngine.Object pAsset)
	{
        if (pAsset == null)
        {
            ViDebuger.Error("_OnResLoaded pAsset == null");
            return;
        }
		if (_parentTransform == null)
		{
			return;
		}
		if (!ViMask32.HasAny(AttachMask, (UInt32)ExpressAttachMask.NO_ROTATE))
		{
            if (ViMask32.HasAny(AttachMask, (UInt32)ExpressAttachMask.FORCE_ZERO))
            {
                _parentTransform.localRotation = Quaternion.identity;
            }
            _obj = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _parentTransform, _offset.Convert(), false);
		    _obj.transform.localRotation = Quaternion.identity;
        }
		else
		{
            _obj = UnityAssisstant.Instantiate(pAsset as GameObject, _parentTransform.position + _offset.Convert(), Quaternion.identity);
		}
        UpdateScriptCameraState();
		if (Layer != (Int32)UnityLayer.DEFAULT)
		{
			UnityAssisstant.SetLayerRecursively(_obj, Layer);
		}
		UnityAssisstant.UpdateSwitchComponent(_obj, SwitchLayer);
		//
		UpdateState();
		if (SoundDuration)
		{
			float duration = 0;
			UnityAssisstant.UpdateSoundVolume(_obj, ApplicationSetting.Instance.SoundVolumeScale, out duration);
			SetDuration(duration);
		}
		else
		{
			UnityAssisstant.UpdateSoundVolume(_obj, ApplicationSetting.Instance.SoundVolumeScale);
		}
		//
		if (OnLoadedCompleteCallback != null)
		{
			OnLoadedCompleteCallback(_obj);
		}
	}

	void UpdateState()
	{
		if (_obj != null)
		{
			UnityAssisstant.SetScale(_obj, _scale);
		}
	}

	void UpdateScriptCameraState()
	{
		if (_obj != null)
		{
			UnityComponentList<ScriptCameraComponent>.Begin(_obj, true);
			for (int iter = 0; iter < UnityComponentList<ScriptCameraComponent>.Count; ++iter)
			{
				ScriptCameraComponent iterComponent = UnityComponentList<ScriptCameraComponent>.List[iter];
				iterComponent.UpdateActiveState(CameraAnim);
			}
			UnityComponentList<ScriptCameraComponent>.End();
		}
	}

	//public GameObject DetachVisual()
	//{
 //       if (!IsLocal)
 //       {
 //           mResLoader.End();
 //       }
        
 //       if (_obj != null)
	//	{
	//		GameObject obj = _obj;
	//		_obj = null;
	//		obj.transform.parent = null;
	//		return obj;
	//	}
	//	else
	//	{
	//		return null;
	//	}
	//}

	public void SetDuration(float duration)
	{
		ViTimerVisualInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
	}
	void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}
	ViTimeNode1 _endTimeNode = new ViTimeNode1();

	protected Transform _parentTransform;
	protected ViVector3 _offset;
	protected GameObject _obj;
	string _name = string.Empty;
	float _scale = 1.0f;
    ResourceRequest mResLoader = new ResourceRequest();
    ViTimeNode1 _timeNode = new ViTimeNode1();
    PathFileResStruct _res;
}
