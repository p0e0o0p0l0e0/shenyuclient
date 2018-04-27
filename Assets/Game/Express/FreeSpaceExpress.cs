using System;
using System.Collections.Generic;
using UnityEngine;

public class FreeSpaceExpress : ViSpaceExpress
{
	public float Scale
	{
		set
		{
			if (value != 0)
			{
				_scale = value;
				_OnUpdateScale();
			}
		}
	}
	public bool Active
	{
		get { return _active; }
		set
		{
			if (value != _active)
			{
				_active = value;
				_OnUpdateState();
			}
		}
	}
	public bool Static
	{
		get { return _static; }
		set
		{
			if (value != _static)
			{
				_static = value;
				_OnStaticUpdate();
			}
		}
	}
	public UInt32 AttachMask;
	public GameObject Root { get { return _obj; } set { _obj = value; } }
	public bool CameraAnim = false;
    public bool IsLocal = false;
	public string SwitchLayer = string.Empty;

	public void SetProvider(ViProvider<ViVector3> pos)
	{
		_posProvider = pos;
		if (_obj != null)
		{
			_obj.transform.localPosition = PosProvider.Value.Convert();
		}
	}
	public void SetProvider(ViProvider<ViVector3> pos, float yaw)
	{
		_posProvider = pos;
		_yaw = yaw;
		if (_obj != null)
		{
			_obj.transform.localPosition = PosProvider.Value.Convert();
			_obj.transform.localRotation = Quaternion.AngleAxis(ViMathDefine.Radius2Degree(_yaw), Vector3.up);
		}
	}

	public override void End()
	{
        mResLoader.End();
		_posProvider = null;
		UnityDeletor.Node deleteNode = UnityAssisstant.DestroyEx(ref _obj);
		base.End();
	}
	public override void Update(float deltaTime)
	{
		if (ViMask32.HasAny(AttachMask, (UInt32)ExpressAttachMask.WORLD))
		{
			return;
		}
		ViDebuger.AssertError(PosProvider);
		ViDebuger.AssertError(_obj);
		_obj.transform.localPosition = PosProvider.Value.Convert();
		if (ViMask32.HasAny(AttachMask, (UInt32)ExpressAttachMask.NO_ROTATE))
		{
			_obj.transform.rotation = Quaternion.AngleAxis(ViMathDefine.Radius2Degree(UnityAssisstant.CameraYaw), Vector3.up);
		}
	}

	protected void _OnResLoaded(UnityEngine.Object pAsset)
	{
		if (PosProvider != null)
		{
			Quaternion rotate = Quaternion.AngleAxis(ViMathDefine.Radius2Degree(_yaw), Vector3.up);
			_obj = UnityAssisstant.Instantiate(pAsset as  GameObject, PosProvider.Value.Convert(), rotate);
		}
		else
		{
			_obj = UnityAssisstant.Instantiate(pAsset as GameObject);
		}
		//
		UpdateScriptCameraState();
		_OnUpdateState();
		_OnUpdateScale();
		_OnStaticUpdate();
	}

	void _OnUpdateState()
	{
		if (_active && _obj != null && PosProvider != null)
		{
			AttachUpdate();
		}
		else
		{
			DetachUpdate();
		}
		if (_obj != null)
		{
			_obj.SetActive(_active);
			_obj.transform.localScale = new Vector3(_scale, _scale, _scale);
			Projector projector = _obj.GetComponent<Projector>();
			if (projector != null)
			{
				projector.orthographicSize = _scale;
			}
			UnityAssisstant.UpdateSwitchComponent(_obj, SwitchLayer);
		}
	}

	public void OnUpdate()
	{
		_OnUpdateState();
		_OnUpdateScale();
		_OnStaticUpdate();
	}

	void _OnUpdateScale()
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

	void _OnStaticUpdate()
	{
		if (_obj)
		{
			UnityAssisstant.SetStaticRecursively(_obj, _static);
		}
	}
    
	GameObject _obj;
	bool _active = true;
	float _scale = 1.0f;
	string _level = string.Empty;
	bool _static = false;
	float _yaw;
    protected ResourceRequest mResLoader = new ResourceRequest();
}


public class FreeSpaceExpressEx : FreeSpaceExpress
{
	public void Start(PathFileResStruct res, ViProvider<ViVector3> pos, float yaw, float delayTime, float duration)
    {
        _res = res;
        SetProvider(pos, yaw);

        if (delayTime < 0)
        {
            ViTimerVisualInstance.SetTime(_timeNode, 0.1f, this.OnEndTime);
        }
        else if (delayTime == 0)
        {
            mResLoader.Start(_res, _OnResLoaded, true);
        }
        else
        {
            ViTimerVisualInstance.SetTime(_timeNode1, delayTime, this.OnStartTime);
        }
        if (duration > 0)
		{
			ViTimerVisualInstance.SetTime(_timeNode, delayTime + duration, this.OnEndTime);
		}
	}

	public override void End()
	{
		base.End();
        _res = null;
        _timeNode.Detach();
        _timeNode1.Detach();

    }
    void OnStartTime(ViTimeNodeInterface node)
    {
        mResLoader.Start(_res, _OnResLoaded, true);
    }

    void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}
	ViTimeNode1 _timeNode = new ViTimeNode1();
    ViTimeNode1 _timeNode1 = new ViTimeNode1();
    PathFileResStruct _res;
}

public class ShakeExpressEx : ViSpaceExpress
{
	public void Start(float delayTime, ViCameraShakeStruct info)
	{
		_info = info;
		ViTimerVisualInstance.SetTime(_timeNode, delayTime, this.OmStartTime);
	}

	public void SetProvider(ViProvider<ViVector3> pos)
	{
		_posProvider = pos;
	}

	public override void End()
	{
		base.End();
		_timeNode.Detach();
	}
	//
	void OmStartTime(ViTimeNodeInterface node)
	{
		float distanceScale = 1.0f;
		if (PosProvider != null)
		{
			distanceScale = CameraController.Instance.ShakeScale(PosProvider.Value);
		}
		Shake(_info, distanceScale);
		End();
	}

	static void Shake(ViCameraShakeStruct info, float distanceScale)
	{
		float scale = distanceScale * ApplicationSetting.Instance.CameraShakeScale;
		if (GameSpace.ActiveInstance != null)
		{
			scale *= GameSpace.ActiveInstance.VisualInfo.GetCameraShakeScale();
		}
		CameraController.Instance.SpringShaker.Start(scale * info.Spring.Range * 0.01f * ViVector3.UNIT_Z, info.Spring.SpirngRate * 0.01f, info.Spring.SpeedFriction * 0.01f, info.Spring.TimeScale * 0.01f, info.Spring.SpringCount, info.LookAtScale * 0.01f);
		CameraController.Instance.RandomShaker.Start(info.Random.Duration * 0.01f, scale * info.Random.Intensity * 0.01f, info.LookAtScale * 0.01f);
	}

	ViTimeNode1 _timeNode = new ViTimeNode1();
	ViCameraShakeStruct _info;
}

public class BodyPartActiveExpressEx : ViSpaceExpress
{
	public void Start(Transform tran, Int32 delayTime, bool active, Int32 duration)
	{
		_tran = tran;
		_active = active;
		_oldActive = tran.gameObject.activeSelf;
		if (delayTime <= 0)
		{
			_tran.gameObject.SetActive(_active);
		}
		else
		{
			ViTimerVisualInstance.SetTime(_timeNode, delayTime * 0.01f, this.OnStartTime);
		}
		//
		ViTimerVisualInstance.SetTime(_endTimeNode, (delayTime + duration) * 0.01f, this.OnEndTime);
	}

	public override void End()
	{
		base.End();
		if (_tran != null && _tran.gameObject.activeSelf != _oldActive)
		{
			_tran.gameObject.SetActive(_oldActive);
		}
		//
		_timeNode.Detach();
		_endTimeNode.Detach();
	}
	//
	void OnStartTime(ViTimeNodeInterface node)
	{
		if (_tran != null && _tran.gameObject.activeSelf != _active)
		{
			_tran.gameObject.SetActive(_active);
		}
	}

	void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}

	ViTimeNode1 _timeNode = new ViTimeNode1();
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	Transform _tran;
	bool _active;
	bool _oldActive;
}

public class FunctionExpressEx : ViSpaceExpress
{
	public void Start(Transform obj, AnimationEventEx animEvent)
	{
		_tran = obj;
		_event = animEvent;
		if (animEvent.DelayTime <= 0)
		{
			if (_tran != null)
			{
				_tran.gameObject.SetActive(_event.Enable);
			}
		}
		else
		{
			ViTimerVisualInstance.SetTime(_timeNode, animEvent.DelayTime * 0.01f, this.OnStartTime);
		}
		//
		ViTimerVisualInstance.SetTime(_endTimeNode, (animEvent.DelayTime + animEvent.Duration) * 0.01f, this.OnEndTime);
	}

	public override void End()
	{
		if (_tran != null)
		{
			if (_event.Destory)
			{
				GameObject.Destroy(_tran.gameObject);
			}
			else
			{
				_tran.gameObject.SetActive(_event.EndEnable);
			}
		}
		//
		base.End();
		_timeNode.Detach();
		_endTimeNode.Detach();
	}
	//
	void OnStartTime(ViTimeNodeInterface node)
	{
		if (_tran != null)
		{
			_tran.gameObject.SetActive(_event.Enable);
		}
	}

	void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}

	ViTimeNode1 _timeNode = new ViTimeNode1();
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	AnimationEventEx _event;
	Transform _tran;
}


public class GameObjectCloneExpressEx : ViSpaceExpress
{
	public string SwitchLayer;
	public GameObject Obj { get { return _obj; } }

	public void Start(GameObject obj, ViProvider<ViVector3> pos, float yaw, float delayTime, float duration, ViVector3 offset, ViAreaStruct area)
	{
		if (obj == null)
		{
			return;
		}
		//
		_yaw = yaw;
		_area = area;
		_offset = offset;
		_template = obj;
		_position = pos;
		_duration = duration;
		ViTimerVisualInstance.SetTime(_timeNode, delayTime * 0.01f, this.OnStartTime);
		ViTimerVisualInstance.SetTime(_endTimeNode, (delayTime + duration) * 0.01f, this.OnEndTime);
	}

	public override void End()
	{
		if (_obj != null)
		{
			GameObject.Destroy(_obj);
		}
		//
		base.End();
		_timeNode.Detach();
		_endTimeNode.Detach();
	}
	//

	void OnStartTime(ViTimeNodeInterface node)
	{
		_obj = UnityAssisstant.Instantiate(_template, _position.Value.Convert() + _offset.Convert(), Quaternion.AngleAxis(ViMathDefine.Radius2Degree(_yaw), Vector3.up));
		UnityAssisstant.SetActive(_obj, true);
		if (_obj != null)
		{
			_UpdateLevel(_obj);
		}
	}

	void _UpdateLevel(GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		//
		obj.SetActive(true);
		AOIEffect aoiEffectScript = UnityAssisstant.CreateComponent<AOIEffect>(obj);
		aoiEffectScript.Initialization(_area, SwitchLayer, _duration);
		if (_area.type == (int)ViAreaType.RECT)
		{
			aoiEffectScript.UpdateOffset(_area.maxRange * 0.01f * 0.5f * aoiEffectScript.gameObject.transform.forward);
		}
		aoiEffectScript.SetPos(_position);
	}

	void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}

	ViProvider<ViVector3> _position;
	ViTimeNode1 _timeNode = new ViTimeNode1();
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	GameObject _template;
	GameObject _obj;
	ViVector3 _offset;
	ViAreaStruct _area;
	float _yaw;
	float _duration;
}