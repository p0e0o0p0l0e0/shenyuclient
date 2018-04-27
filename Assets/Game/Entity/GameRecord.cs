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
public class GameRecord : ViRPCEntity, ViEntity
{
	public static GameRecord Instance { get { return _instance; } }
	static GameRecord _instance;
	//
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "GameRecord"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public GameRecordReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart(){}
	public void Start()
	{
		_instance = this;
	}
	public void AftStart()
	{
		GameTimeScale.SetLogic(Property.TimeScale);
	}
	public void ClearCallback() { }
	public void PreEnd()
	{
		_instance = null;
	}
	public void End(){}
	public void AftEnd(){}
	public void Tick(float fDeltaTime){}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<GameRecordReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
		GameRecordPropertyAssisstant.SetProperty(_property);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		GameRecordPropertyAssisstant.SetProperty(null);
		ViReceiveDataCache<GameRecordReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel){}
	public void OnPropertyUpdateEnd(UInt8 channel){}
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public void OnTimeScaleUpdated(float value)
	{
		GameTimeScale.SetLogic(value);
	}
	public void OnTimeBoard(UInt8 type, ViString content)
	{

	}

	public void OnLoot(PlayerIdentificationProperty player, Int32 loot, List<ItemCountProperty> itemList)
	{

	}

	public void OnNote(ViString note)
	{

	}

	public void DebugMessage(ViString title, ViString content)
	{
		EntityMessageController.OnDebugMessage(title, content);
	}

	public void SetConstBool(ViString name, UInt8 value)
	{
		ViConstValueList<bool>.AddValue(name, value != 0);
	}

	public void SetConstBools(ViString name, List<UInt8> value)
	{
		List<bool> newValue = new List<bool>();
		for (int iter = 0; iter < value.Count; ++iter)
		{
			newValue.Add(value[iter] == 1);
		}
		ViConstValueList<List<bool>>.AddValue(name, newValue);
	}

	public void SetConstInt(ViString name, Int32 value)
	{
		ViConstValueList<Int32>.AddValue(name, value);
	}

	public void SetConstInts(ViString name, List<Int32> value)
	{
		ViConstValueList<List<Int32>>.AddValue(name, value);
	}

	public void SetConstFloat(ViString name, float value)
	{
		ViConstValueList<float>.AddValue(name, value);
	}

	public void SetConstFloats(ViString name, List<float> value)
	{
		ViConstValueList<List<float>>.AddValue(name, value);
	}

	public void SetConstString(ViString name, ViString value)
	{
		ViConstValueList<ViString>.AddValue(name, value);
	}

	public void SetConstStrings(ViString name, List<ViString> value)
	{
		ViConstValueList<List<ViString>>.AddValue(name, value);
	}

	public void SetConstVector3(ViString name, ViVector3 value)
	{
		ViConstValueList<ViVector3>.AddValue(name, value);
	}

	public void SetConstVector3s(ViString name, List<ViVector3> value)
	{
		ViConstValueList<List<ViVector3>>.AddValue(name, value);
	}

	public bool IsActivityActive(ActivityStruct info, bool notify)
	{
		if (GameRecordPropertyAssisstant.IsActivityActive(Property, info))
		{
			return true;
		}
		else
		{
			if (notify)
			{
				EntityMessager messager = new EntityMessager();
				messager.Append(info);
				messager.Send(EntityMessage.ACTIVITY_CLOSED, true);
			}
			return false;
		}
	}

	public bool IsActivityScriptActive(ActivityScriptStruct kInfo, Player kEntity)
	{
		ReceiveDataActivityProperty pkProperty;
		if (Property.ScriptActivityList.TryGetValue((UInt32)kInfo.ID, out pkProperty))
		{
			return pkProperty.EndTime1970 > ViTimerInstance.Time1970;
		}
		else
		{
			return kEntity.IsActiveTime(kInfo.Duration);
		}
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	GameRecordReceiveProperty _property;
}
