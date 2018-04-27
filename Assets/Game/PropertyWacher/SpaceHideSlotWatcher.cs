
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHideSlotWatcher : ViReceiveDataArrayNodeWatcher<ReceiveDataSpaceHideSlotProperty>
{
	public static ViConstValue<float> VALUE_SpaceHideSlotAlphaInf = new ViConstValue<float>("SpaceHideSlotAlphaInf", 0.2f);
	public static ViConstValue<float> VALUE_SpaceHideSlotAlphaSup = new ViConstValue<float>("SpaceHideSlotAlphaSup", 0.5f);
	public static ViConstValue<float> VALUE_SpaceHideSlotDropDistance = new ViConstValue<float>("SpaceHideSlotDropDistance", 3.0f);

	public ViVector3 Pos { get { return _pos; } }
	public SpaceHideSlotStruct Info { get { return _info; } }

	public override void OnStart(ReceiveDataSpaceHideSlotProperty property, ViEntity entity)
	{
		GameSpace.ActiveInstance.Navigator.FomatPos(property.X, property.Y, out _pos);
		_info = property.Info.Value;
		_gameObject = new GameObject(Info.Name);
		_gameObject.transform.localPosition = Pos.Convert();
		GameObjectPath.AppendTo(_gameObject, GameObjectPath.Instance.SpaceHideSlot);
		//
		if (Info.Res.NotEmpty())
		{
            mResLoader.Start(Info.Res.Data, _OnResLoaded);
		}
		if (property.State != 0)
		{
			_gameObject.SetActive(true);
		}
		else
		{
			_gameObject.SetActive(false);
		}
		//
		_tickNode.Attach(this.OnTick);
	}

	void _OnResLoaded(UnityEngine.Object pAsset)
	{
		GameObject obj = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _gameObject.transform);
		_visualSwitcher = obj.GetComponent<SwitchComponent>();
		UpdateState();
	}

	public override void OnUpdate(ReceiveDataSpaceHideSlotProperty property, ViEntity entity)
	{
		UpdateState();
	}

	public override void OnEnd(ReceiveDataSpaceHideSlotProperty property, ViEntity entity)
	{
		_tickNode.Detach();
		_visualSwitcher = null;
        mResLoader.End();
        //
        if (_gameObject != null)
		{
			UnityAssisstant.Destroy(ref _gameObject);
		}
	}

	ViTickNode _tickNode = new ViTickNode();
	void OnTick(float deltaTime)
	{
		if (CellHero.LocalHero == null)
		{
			return;
		}
		float distance = ViGeographicObject.GetHorizontalDistance(CellHero.LocalHero.Position, Pos);
		float newScale = ViMathDefine.Clamp01(distance / VALUE_SpaceHideSlotDropDistance);
		if (newScale != _scale)
		{
			_scale = newScale;
			UpdateState();
		}
	}

	void UpdateState()
	{
		if (_visualSwitcher == null)
		{
			return;
		}
		if (Property.State == 0)
		{
			_visualSwitcher.Set("Dead", false);
		}
		else if (_scale < 0.25f)
		{
			_visualSwitcher.Set("Hide0", false);
		}
		else if (_scale < 0.5f)
		{
			_visualSwitcher.Set("Hide1", false);
		}
		else if (_scale < 0.75f)
		{
			_visualSwitcher.Set("Hide2", false);
		}
		else if (_scale < 1.0f)
		{
			_visualSwitcher.Set("Hide3", false);
		}
		else
		{
			_visualSwitcher.Set("Normal", false);
		}
	}

	ViVector3 _pos;
	SpaceHideSlotStruct _info;
	GameObject _gameObject;
	SwitchComponent _visualSwitcher;
	float _scale = 1.0f;
    ResourceRequest mResLoader = new ResourceRequest();
}
