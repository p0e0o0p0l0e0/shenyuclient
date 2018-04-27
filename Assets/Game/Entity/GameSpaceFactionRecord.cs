using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
//
public class GameSpaceFactionRecord : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "GameSpaceFactionRecord"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public GameSpaceFactionRecordReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart() { }
	public void Start()
	{
		GameSpaceFactionPropertyWatcherCreator.Start(_property, this);
		//
		GameSpaceFactionRecordInstance.Start(this);
		//
		Property.ScriptProgressList.UpdateArrayCallbackList.Attach(_scriptProgressCallback, this._OnScriptProgressUpdated);
		Property.PlayerWorkingList.UpdateArrayCallbackList.Attach(_scriptWorkingListCallback, this._OnScriptWorkingListUpdated);
	}
	public void AftStart()
	{

	}
	public void ClearCallback()
	{
		_scriptProgressCallback.End();
		_scriptWorkingListCallback.End();
	}

	public void PreEnd()
	{
		GameSpaceFactionRecordInstance.End();
		//
	}
	public void End() { }
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<GameSpaceFactionRecordReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<GameSpaceFactionRecordReceiveProperty>.Free(_property);
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

	ViAsynCallback<UInt64> _scriptWorkingListCallback = new ViAsynCallback<UInt64>();
	void _OnScriptWorkingListUpdated(UInt32 eventID, UInt64 player)
	{
		if (eventID == (UInt32)ViDataArrayOperator.DEL)
		{
			_UpdateMemberBillBoard(player);
		}
	}
	void _UpdateMemberBillBoard(UInt64 player)
	{
		CellHero hero = GetCellHero(player);
		if (hero != null)
		{
			hero.UpdateNameBillBoard();
		}
	}

	public bool IsScriptEventWorking(UInt64 hero)
	{
		ReceiveDataSpaceHeroMemberProperty property;
		if (GameSpaceRecordInstance.Instance.Property.HeroList.TryGetValue(hero, out property))
		{
			return Property.PlayerWorkingList.Contain(property.Identification.ID);
		}
		return false;
	}

	public CellHero GetCellHero(ViEntityID player)
	{
		foreach (KeyValuePair<ViEntityID, ViReceiveDataDictionaryNode<ViEntityID, ReceiveDataSpaceHeroMemberProperty>> pair in GameSpaceRecordInstance.Instance.Property.HeroList.Array)
		{
			if (player == pair.Value.Property.Identification.ID)
			{
				return GameApplication.Instance.Client.EntityManager.GetEntity<CellHero>(pair.Key);
			}
		}
		return null;
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	GameSpaceFactionRecordReceiveProperty _property;
}

public class GameSpaceFactionRecordInstance
{
	public static GameSpaceFactionRecord Instance { get { return _instance; } }
	static GameSpaceFactionRecord _instance;

	public static void Start(GameSpaceFactionRecord record)
	{
		_instance = record;
	}

	public static void End()
	{
		_instance = null;
	}
}