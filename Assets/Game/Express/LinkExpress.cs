using System;
using UnityEngine;

public class LinkExpress : ViSpaceExpress
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
	public ViProvider<ViVector3> FromPosProvider { get { return _fromPos; } }
	public string SwitchLayer = string.Empty;

	public void Start(ViProvider<ViVector3> fromPos, ViProvider<ViVector3> toPos, PathFileResStruct res, float flyDuration)
	{
		ReLink(fromPos, toPos, flyDuration, true);
        mResLoader.Start(res, _OnResLoaded);
		//
		AttachUpdate();
	}

	public void ReLink(ViProvider<ViVector3> fromPos, ViProvider<ViVector3> toPos, float flyDuration, bool smoothBreak)
	{
		_fromPos = fromPos;
		_posProvider = toPos;
		//
		if (flyDuration > 0)
		{
			if (smoothBreak)
			{
				float len = ViVector3.Distance(fromPos.Value, toPos.Value);
				_toPosSmooth.StopAt(fromPos.Value);
				_toPosSmooth.SetSample(len, flyDuration);
			}
			else
			{
				float len = ViVector3.Distance(fromPos.Value, _toPosSmooth.Value);
				_toPosSmooth.SetSample(len, flyDuration);
			}
			//
			_toPosSmoothEndTime = ViTimerInstance.Time + ViMathDefine.IntNear(flyDuration * 100) + 10;
		}
		else
		{
			_toPosSmoothEndTime = 0;
		}
	}

	public override void End()
	{
        mResLoader.End();
        _fromPos = null;
		_posProvider = null;
		_fromTran = null;
		_toTran = null;
		UnityAssisstant.Destroy(ref _obj);
		_endTimeNode.Detach();
		base.End();
	}

	public void DelayEnd(float duration)
	{
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
	}

	void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}
	ViTimeNode1 _endTimeNode = new ViTimeNode1();

	public override void Update(float deltaTime)
	{
		ViVector3 toPos = _posProvider.Value;
		if (ViTimerInstance.Time < _toPosSmoothEndTime)
		{
			_toPosSmooth.Update(toPos, deltaTime);
			toPos = _toPosSmooth.Value;
		}
		//
		if (_fromTran != null)
		{
			ViVector3 localTo = toPos - _fromPos.Value;
			_fromTran.transform.position = _fromPos.Value.Convert();
			if (localTo != ViVector3.ZERO)
			{
				_fromTran.transform.rotation = Quaternion.LookRotation(localTo.Convert());
			}
		}
		if (_toTran != null)
		{
			_toTran.transform.position = toPos.Convert();
		}
	}

	void _OnResLoaded(UnityEngine.Object pAsset)
	{
		ViVector3 localTo = _posProvider.Value - _fromPos.Value;
		_obj = UnityAssisstant.Instantiate(pAsset as GameObject, _fromPos.Value.Convert(), Quaternion.LookRotation(localTo.Convert()));
		//
		Transform rootTran = _obj.transform;
		_fromTran = rootTran;
		_toTran = rootTran.GetChildRecursively("To", rootTran);
		//
		UnityAssisstant.UpdateSwitchComponent(_obj, SwitchLayer);
		OnUpdateScale();
	}

	void OnUpdateScale()
	{
		if (_obj != null && _scale > 0.01f)
		{
			_obj.transform.localScale = new Vector3(_scale, _scale, _scale);
		}
	}
    
	GameObject _obj;
	float _scale = 1.0f;
	string _level = string.Empty;
	ViProvider<ViVector3> _fromPos;
	Transform _fromTran;
	Transform _toTran;
	ViVector3Interpolation _toPosSmooth = new ViVector3Interpolation();
	Int64 _toPosSmoothEndTime;
    ResourceRequest mResLoader = new ResourceRequest();
}
