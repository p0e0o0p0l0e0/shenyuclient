using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
//
public class GameSpaceRecord : ViRPCEntity, ViEntity
{
	public static ViConstValue<float> VALUE_SpaceShowCameraDistanceProgress = new ViConstValue<float>("SpaceShowCameraDistanceProgress", 0.5f);
	//
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "GameSpaceRecord"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public SpacePKType PKType { get { return (SpacePKType)Property.PKType.Value; } }
	public GameSpaceRecordReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public SpaceStruct LogicInfo { get { return _logicInfo; } }
	public VisualSpaceStruct VisualInfo { get { return _visualInfo; } }

	public UInt8 SelfFaction
	{
		get
		{
			foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpacePlayerMemberProperty>> pair in Property.PlayerList.Array)
			{
				ReceiveDataSpacePlayerMemberProperty playerProperty = pair.Value.Property;
				if (pair.Key == Player.Instance.ID)
				{
					return playerProperty.Faction.Value;
				}
			}
			return 0;
		}
	}

	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart()
	{
		SpaceStruct spaceInfo = Property.Info.Value;
		//
	}
	public void Start()
	{
		_logicInfo = Property.Info.Value;
		_visualInfo = ViSealedDB<VisualSpaceStruct>.Data(Property.Info);
		//
		GlobalGameObject.Instance.CreateIcon3D();
		//ResourceManagerInstance.FreeUselessReserveSize.Add(GameKeyWord.Space, 20, ResourceManagerInstance.VALUE_ResourceFreeUselessInSpaceReserveSize);
		//
		_space.LoadCompleteCallback = this.OnResLoad;
		_space.Load(_logicInfo, _visualInfo);
		for (int iter = 0; iter < _visualInfo.WarmLoadAvatar.Length; ++iter)
		{
			SimpleAvatarStruct iterInfo = _visualInfo.WarmLoadAvatar[iter].PData;
			if (iterInfo != null)
			{
				//_resHolder.Hold(iterInfo, true);
			}
		}
		for (int iter = 0; iter < _visualInfo.WarmLoadSpell.Length; ++iter)
		{
			VisualSpellStruct iterInfo = _visualInfo.WarmLoadSpell[iter].PData;
			if (iterInfo != null)
			{
				//_resHolder.Hold(iterInfo, true);
			}
		}
		for (int iter = 0; iter < _visualInfo.WarmLoadHitEffect.Length; ++iter)
		{
			ViVisualHitEffectStruct iterInfo = _visualInfo.WarmLoadHitEffect[iter].PData;
			if (iterInfo != null)
			{
				//_resHolder.Hold(iterInfo, true);
			}
		}
		for (int iter = 0; iter < _visualInfo.WarmLoadResource.Length; ++iter)
		{
			//_resHolder.Hold(_visualInfo.WarmLoadResource[iter], true);
		}
		//
		GameSpaceRecordInstance.Start(this);
		//
		Property.ScriptProgressList.UpdateArrayCallbackList.Attach(_scriptProgressCallback, this._OnScriptProgressUpdated);
		Property.ScriptValueList.UpdateArrayCallbackList.Attach(_spaceScriptEventCallback, this._OnSpaceScriptEventUpdated);
	}

	public void AftStart()
	{

	}

	public void ClearCallback()
	{
		_scriptProgressCallback.End();
		_spaceScriptEventCallback.End();
	}

	public void PreEnd()
	{
		GameTimeScale.DelVisual("SpaceComplete");
		_ownExpressList.End();
		//_resHolder.End();
		GameSpaceRecordInstance.End();
		//
		GlobalGameObject.Instance.ClearIcon3D();
        //ResourceManagerInstance.FreeUselessReserveSize.Del(GameKeyWord.Space);
        EventDispatcher.TriggerEvent<bool>(Events.SpaceEvent.ChangeSpace, false);
    }

	public void End() { }
	public void AftEnd()
	{
        UIManagerUtility.ShowLoading();
        _space.Clear();

	}
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<GameSpaceRecordReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
		GameSpaceRecordPropertyAssisstant.SetProperty(_property);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		GameSpaceRecordPropertyAssisstant.SetProperty(null);
		ViReceiveDataCache<GameSpaceRecordReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	ViAsynCallback<UInt32, ReceiveDataProgressProperty> _scriptProgressCallback = new ViAsynCallback<UInt32, ReceiveDataProgressProperty>();
	void _OnScriptProgressUpdated(UInt32 eventID, UInt32 template, ReceiveDataProgressProperty node)
	{
		//ViewControllerManager.UpdateProgress();
	}

	ViCallback<string, ReceiveDataInt64Property> _spaceScriptEventCallback = new ViCallback<string, ReceiveDataInt64Property>();
	void _OnSpaceScriptEventUpdated(UInt32 eventID, string key, ReceiveDataInt64Property valueProperty)
	{

	}

	public void OnResult(UInt8 winFaction)
	{

	}

	public void OnEvent(UInt32 eventID, ViVector3 pos, float yaw)
	{
		OnEvent(eventID, new PlayerIdentificationProperty(), pos, yaw, 0);
	}
	public void OnEvent(UInt32 eventID, PlayerIdentificationProperty actor, ViVector3 pos, float yaw)
	{
		OnEvent(eventID, actor, pos, yaw, 0);
	}
	void OnEvent(UInt32 eventID, PlayerIdentificationProperty actor, ViVector3 pos, float yaw, Int64 startTime)
	{
		SpaceEventStruct eventInfo = ViSealedDB<SpaceEventStruct>.Data(eventID);
		//
		VisualSpaceEventDescStruct visualEventDescInfo = eventInfo.Desc.PData;
		if (visualEventDescInfo != null)
		{
			if (visualEventDescInfo.DescDuration > 0 && !string.IsNullOrEmpty(visualEventDescInfo.Desc))
			{
				Int64 reserveTime = startTime == 0 ? visualEventDescInfo.DescDuration : startTime + visualEventDescInfo.DescDuration - ViTimerInstance.Time;
				if (reserveTime > 0)
				{
					//ViewControllerManager.VisualSpaceEventDescView.UpdateSpaceEventDescription(visualEventDescInfo.Desc, reserveTime);
				}
			}
			if (visualEventDescInfo.SpaceResourceDuration > 0 && visualEventDescInfo.SpaceResource.NotEmpty())
			{
				Int64 reserveTime = startTime == 0 ? visualEventDescInfo.SpaceResourceDuration : startTime + visualEventDescInfo.SpaceResourceDuration - ViTimerInstance.Time;
				if (reserveTime > 0)
				{
					ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(pos);
					FreeSpaceExpressEx express = new FreeSpaceExpressEx();
					express.CameraAnim = true;
					express.AttachMask = (UInt32)visualEventDescInfo.SpaceResourceAttachMask;
					express.Start(visualEventDescInfo.SpaceResource.Data, posProvider, yaw, 0.0f, visualEventDescInfo.SpaceResourceDuration * 0.01f);
					_ownExpressList.Add(express);
				}
			}
		}
		//
		 if (eventID == GameSpaceEventInstance.SpaceCamearDistanceEnd)
		{
			CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
			if (camera != null)
			{
				camera.Distance = camera.Sup.Distance;
			}
		}
	}

	public bool HasCacheEvent(UInt32 ID)
	{
		for (int iter = 0; iter < Property.EventCacheList.Count; ++iter)
		{
			if (Property.EventCacheList[iter].Property.Info == ID)
			{
				return true;
			}
		}
		return false;
	}

	public void UIEvent(UInt32 ID)
	{
		//UIEventStruct info = ViSealedDB<UIEventStruct>.Data(ID);
		//ViewControllerInterface view = //ViewControllerManager.GetViewController(info.Window);
		//if (view != null)
		//{
		//	view.UIEventShow(ID);
		//}
	}

	public void UIEvent(UInt32 ID, UInt64 actor)
	{
		//UIEventStruct info = ViSealedDB<UIEventStruct>.Data(ID);
		//ViewControllerInterface view = //ViewControllerManager.GetViewController(info.Window);
		//if (view != null)
		//{
		//	view.UIEventShow(ID, actor);
		//}
	}

	public void OnControllerStart(UInt32 ID)
	{

	}

	public void OnControllerEnd(UInt32 ID)
	{

	}

	public void OnControllerBorn(UInt32 ID)
	{

	}

	public void OnControllerFactionStart(UInt32 ID, UInt8 faction)
	{

	}

	public void OnControllerFactionEnd(UInt32 ID, UInt8 faction)
	{

	}

	public void OnControllerFactionRevert(UInt32 ID, UInt8 faction)
	{

	}

	public void OnCompleteScriptEvent(UInt64 actor)
	{
		CellHero hero = GameApplication.Instance.Client.EntityManager.GetEntity<CellHero>(actor);
		if (hero != null)
		{
			hero.UpdateNameBillBoard();
		}
	}

	void OnResLoad()
	{
		GameSpaceRecordPropertyWatcherCreator.Start(Property, this);
		//
		CellPlayerServerInvoker.CompleteSpaceLoad(CellPlayer.Instance, GameSpaceRecordInstance.Instance.ID);
		//
		Client.Current.CompleteSpaceLoad();
		//
		EntityAssisstant.UpdateGroundHeight(Client.Current.EntityManager.Entitys);
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	GameSpaceRecordReceiveProperty _property;
	SpaceStruct _logicInfo;
	VisualSpaceStruct _visualInfo;
	//
	GameSpace _space = new GameSpace();
	//
	ViExpressOwnList<ViExpressInterface> _ownExpressList = new ViExpressOwnList<ViExpressInterface>();
}

public class GameSpaceRecordInstance
{
	public static GameSpaceRecord Instance { get { return _instance; } }
	static GameSpaceRecord _instance;

	public static void Start(GameSpaceRecord entity)
	{
		//ViSealedDB<ViAuraStruct>.Ready();
		//ViSealedDB<ViHitEffectStruct>.Ready();
		//ViSealedDB<ViSpellStruct>.Ready();S
		//ViSealedDB<ViVisualAuraStruct>.Ready();
		//ViSealedDB<ViVisualHitEffectStruct>.Ready();
		//ViSealedDB<VisualSpellStruct>.Ready();
		//ViSealedDB<VisualProgressBarStruct>.Ready();
		//
		_instance = entity;
		//
		Client.Current.OnGameSpaceCreated(entity.Property.Info.Value);
	}

	public static void End()
	{
		//ViewControllerManager.OnExitSpace(_instance.Property.Info.Value);
		_instance = null;
	}
}
