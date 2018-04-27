using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBlockSlotWatcher : ViReceiveDataArrayNodeWatcher<ReceiveDataSpaceBlockSlotProperty>
{
	public ViVector3 Pos { get { return _pos; } }
	public SpaceBlockSlotStruct Info { get { return _info; } }

	public override void OnStart(ReceiveDataSpaceBlockSlotProperty property, ViEntity entity)
	{
		GameSpace.ActiveInstance.Navigator.FomatPos(property.X, property.Y, out _pos);
		_info = property.Info.Value;
		_gameObject = new GameObject(Info.Name);
		_gameObject.transform.localPosition = Pos.Convert();
		GameObjectPath.AppendTo(_gameObject, GameObjectPath.Instance.SpaceBlockSlot);
		//
		if (Info.Res.NotEmpty())
		{
            mResLoader.Start(Info.Res.Data, (UnityEngine.Object pAsset)=>
            {
                UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _gameObject.transform);
            });
		}
		if (property.State != 0)
		{
			_gameObject.SetActive(true);
			GameSpace.ActiveInstance.Navigator.ModNavigateBlock(Pos, Info.Range, 1);
		}
		else
		{
			_gameObject.SetActive(false);
		}
	}

	public override void OnUpdate(ReceiveDataSpaceBlockSlotProperty property, ViEntity entity)
	{
		bool newState = property.State != 0;
		if (newState != _gameObject.activeSelf)
		{
			if (newState)
			{
				GameSpace.ActiveInstance.Navigator.ModNavigateBlock(Pos, Info.Range, 1);
			}
			else
			{
				GameSpace.ActiveInstance.Navigator.ModNavigateBlock(Pos, Info.Range, -1);
			}
		}
		_gameObject.SetActive(newState);
	}

	public override void OnEnd(ReceiveDataSpaceBlockSlotProperty property, ViEntity entity)
	{
		if (property.State != 0)
		{
			GameSpace.ActiveInstance.Navigator.ModNavigateBlock(Pos, Info.Range, -1);
		}
        mResLoader.End();
        //
        if (_gameObject != null)
		{
			UnityAssisstant.Destroy(ref _gameObject);
		}
	}

	ViVector3 _pos;
	SpaceBlockSlotStruct _info;
	GameObject _gameObject;
    ResourceRequest mResLoader = new ResourceRequest();
}
