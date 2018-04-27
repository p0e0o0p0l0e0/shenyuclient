using System;
using System.Collections.Generic;
using UnityEngine;

public enum AvatarPartType
{
	LINK,
	SKIN,
    None,
}

public class AvatarPart
{
	public GameObject Obj;
    public PlayerEquipSlotType part { get; private set; }
    public int ID { get; private set; }
    public Action<PlayerEquipSlotType> CallBack = null;
    public void Start(int id, PlayerEquipSlotType setPart,PathFileResStruct res, int nLoadLevel, Action<PlayerEquipSlotType> pCallBack = null)
	{
        if (res.ID == 0)
        {
            ViDebuger.Note(string.Format("加载数据为空 id={0}--setPart={1}", id, setPart) );
        }
        ID = id;
        part = setPart;
        mResLoader.Start(res, nLoadLevel, OnLoaded);
        CallBack = pCallBack;
    }

	public void End()
	{
        mResLoader.End();
        if (_oldOne != null)
		{
			AvatarPart oldOne = _oldOne;
			_oldOne = null;
			oldOne.End();
		}
        Obj = null;
    }

	public void SetOld(AvatarPart value)
	{
		if (value != null && value._oldOne != null)
		{
			_oldOne = value._oldOne;
			value._oldOne = null;
		}
		else
		{
			_oldOne = value;
		}
	}

	public void ClearOld()
	{
		if (_oldOne != null)
		{
			AvatarPart oldOne = _oldOne;
			if (oldOne.Obj != null)
			{
				UnityAssisstant.Destroy(ref oldOne.Obj);
			}
			_oldOne = null;
			oldOne.End();
		}
	}

    public bool IsLoading()
    {
        return Obj == null;
    }

    public void OnLoaded(UnityEngine.Object pAsset)
    {
        Obj = pAsset as GameObject;
        if (CallBack != null)
        {
            CallBack(part);
            CallBack = null;
        }
    }

	AvatarPart _oldOne;
    ResourceRequest mResLoader = new ResourceRequest();
}
