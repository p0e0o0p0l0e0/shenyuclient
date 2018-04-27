using System;
using UnityEngine;

public class SpaceTravelExpress<TMotor> : ViSpaceExpress
	where TMotor : ViMotorInterface, new()
{
	public float Scale
	{
		set
		{
			if (value != 0)
			{
				_scale = value;
				OnUpdateScale();
			}
		}
	}
	public TMotor Motor { get { return _motor; } }
	public ViCameraShakeStruct HitCameraShake { get { return _hitCameraShake; } set { _hitCameraShake = value; } }
	public ViTravelEndExpressDirection EndEpressReserveDirection { get { return _endEpressReserveDirection; } set { _endEpressReserveDirection = value; } }
	public string SwitchLayer = string.Empty;
	//
	public void Start(ViProvider<ViVector3> pos, float duration, PathFileResStruct res)
	{
		ViDebuger.AssertWarning(pos);
		if (pos == null)
		{
			return;
		}
		Motor.Target = pos;
		Motor.Start(duration);
		Motor.Update(0.01f);
		_posProviderOnwer = new ViSimpleProvider<ViVector3>();
		_posProvider = _posProviderOnwer;
        mResLoader.Start(res, _OnResLoaded);
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
		AttachUpdate();
	}

	public override void End()
	{
        mResLoader.End();
        UnityDeletor.Node deleteNode = UnityAssisstant.DestroyEx(ref _obj);
		_endTimeNode.Detach();
		base.End();
	}
	public override void Update(float deltaTime)
	{
		ViDebuger.AssertError(Motor.Target);
		bool updated = Motor.Update(deltaTime);
		_posProviderOnwer.SetValue(Motor.Translate);
		if (updated && _obj != null)
		{
			if (_updateRotate)
			{
				GroundWinger.Update(Motor.Translate, Motor.Direction, Motor.Roll, _obj.transform);
			}
			else
			{
				_obj.transform.localPosition = Motor.Translate.Convert();
			}
		}
	}
	void OnEndTime(ViTimeNodeInterface node)
	{
		if (HitCameraShake != null)
		{
			ShakeExpressEx shakeExpress = new ShakeExpressEx();
			shakeExpress.SetProvider(PosProvider);
			shakeExpress.Start(0.0f, HitCameraShake);
		}
		//
		End();
	}
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	//
	void _OnResLoaded(UnityEngine.Object pAsset)
	{
		_obj = UnityAssisstant.Instantiate(pAsset as GameObject, Motor.Translate.Convert(), SpaceTravelExpressAssisstant.Direction(Motor.Direction.Convert(), Motor.Roll));
		//
		UnityAssisstant.UpdateSwitchComponent(_obj, SwitchLayer);
		OnUpdateScale();
		UnityAssisstant.UpdateSoundVolume(_obj, ApplicationSetting.Instance.SoundVolumeScale);
	}
	void OnUpdateScale()
	{
		if (_obj != null && _scale > 0.01f)
		{
			_obj.transform.localScale = new Vector3(_scale, _scale, _scale);
		}
	}
    
	GameObject _obj;
	ViSimpleProvider<ViVector3> _posProviderOnwer = new ViSimpleProvider<ViVector3>();
	float _delayTime;
	ViCameraShakeStruct _hitCameraShake;
	TMotor _motor = new TMotor();
	ViTravelEndExpressDirection _endEpressReserveDirection = ViTravelEndExpressDirection.INHERIT;
	bool _updateRotate = true;
	float _scale = 1.0f;
	string _level = string.Empty;
    ResourceRequest mResLoader = new ResourceRequest();
}

public class SpaceTravelExpress1<TMotor> : ViSpaceExpress
	where TMotor : ViMotorInterface, new()
{
	public float Scale
	{
		set
		{
			if (value != 0)
			{
				_scale = value;
				OnUpdateScale();
			}
		}
	}
	public TMotor Motor { get { return _motor; } }
	public ViCameraShakeStruct HitCameraShake { get { return _hitCameraShake; } set { _hitCameraShake = value; } }
	public string SwitchLayer = string.Empty;

	public void Start(ViProvider<ViVector3> pos, float duration, PathFileResStruct res, float delayTime, Transform endAttachedTarget)
	{
		ViDebuger.AssertWarning(pos);
		if (pos == null)
		{
			return;
		}
		Motor.Target = pos;
		Motor.Start(duration);
		Motor.Update(0.01f);
		Motor.EndForceUpdate = true;
        mResLoader.Start(res, _OnResLoaded);
        //ResourceMgr.Instance.Load(res, _OnResLoaded);
		_delayTime = delayTime;
		_endAttachedTarget = endAttachedTarget;
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
		AttachUpdate();
	}
	public void Start(ViProvider<ViVector3> pos, float duration, GameObject sourceRes, float delayTime, Transform endAttachedTarget)
	{
		ViDebuger.AssertWarning(pos);
		if (pos == null)
		{
			return;
		}
		Motor.Target = pos;
		Motor.Start(duration);
		Motor.Update(0.01f);
		Motor.EndForceUpdate = true;
		SetRes(sourceRes);
		_delayTime = delayTime;
		_endAttachedTarget = endAttachedTarget;
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
		AttachUpdate();
	}
	public override void End()
	{
        mResLoader.End();

        UnityDeletor.Node deleteNode = UnityAssisstant.DestroyEx(ref _obj);
		_endTimeNode.Detach();
		base.End();
	}
	public override void Update(float deltaTime)
	{
		ViDebuger.AssertError(Motor.Target);
		bool updated = Motor.Update(deltaTime);
		if (updated && _obj != null)
		{
			if (_obj.transform.parent == null)
			{
				GroundWinger.Update(Motor.Translate, Motor.Direction, Motor.Roll, _obj.transform);
			}
		}
	}
	//
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	void OnEndTime(ViTimeNodeInterface node)
	{
		if (HitCameraShake != null)
		{
			ShakeExpressEx shakeExpress = new ShakeExpressEx();
			shakeExpress.SetProvider(PosProvider);
			shakeExpress.Start(0.0f, HitCameraShake);
		}
		if (_endAttachedTarget != null)
		{
			bool updated = Motor.Update(Motor.Duration);
			if(_obj != null)
			{
				if (updated)
				{
					GroundWinger.Update(Motor.Translate, Motor.Direction, Motor.Roll, _obj.transform);
				}
				_obj.transform.parent = _endAttachedTarget;
				_obj.transform.localPosition = Vector3.zero;
			}
			ViTimerInstance.SetTime(_endTimeNode, _delayTime, this.OnEndTime1);
		}
		else
		{
			End();
		}
	}
	void OnEndTime1(ViTimeNodeInterface node)
	{
		End();
	}
	//
	void _OnResLoaded(UnityEngine.Object pAsset)
	{
		SetRes(pAsset as GameObject);
	}
	void SetRes(GameObject res)
	{
		_obj = UnityAssisstant.Instantiate(res, Motor.Translate.Convert(), SpaceTravelExpressAssisstant.Direction(Motor.Direction.Convert(), Motor.Roll));
		OnUpdateScale();
		UnityAssisstant.UpdateSwitchComponent(_obj, SwitchLayer);
		UnityAssisstant.UpdateSoundVolume(_obj, ApplicationSetting.Instance.SoundVolumeScale);
	}

	void OnUpdateScale()
	{
		if (_obj != null && _scale > 0.01f)
		{
			_obj.transform.localScale = new Vector3(_scale, _scale, _scale);
		}
	}
    
	GameObject _obj;
	Transform _endAttachedTarget;
	ViCameraShakeStruct _hitCameraShake;
	float _delayTime;
	TMotor _motor = new TMotor();
	float _scale = 1.0f;
	string _level = string.Empty;
    ResourceRequest mResLoader = new ResourceRequest();
}

public struct TravelExpressData
{
	public ViProvider<ViVector3> FromPos;
	public ViProvider<ViVector3> ToPos;
	public float Gravity;
	public float Duration;
	public PathFileResStruct Resource;
	public float ReserveTime;
	public PathFileResStruct ReserveResource;
	public ViTravelEndExpressDirection ReserveDirection;
	public ViCameraShakeStruct CameraShake;
	public Transform EndAttachedTarget;
	public string SwitchLayer;
}

public static class SpaceTravelExpressAssisstant
{
	public static Quaternion Direction(Vector3 direction, float roll)
	{
		Vector3 up = Vector3.up;
		Quaternion rollQuat = Quaternion.AngleAxis(ViMathDefine.Rad2Deg * roll, direction);
		up = rollQuat * up;
		return Quaternion.LookRotation(direction, up);
	}
}