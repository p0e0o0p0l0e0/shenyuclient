using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
public class Guild : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "Guild"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public GuildReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }

	public bool SelfLeader
	{
		get { return Property.Leader.ID == Player.Instance.ID; }
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
	public void PreStart() { }
	public void Start()
	{
		GuildInstance.Start(this);
	}
	public void AftStart() { }
	public void ClearCallback() { }
	public void PreEnd()
	{
		GuildInstance.End();
	}
	public void End() { }
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<GuildReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
		GuildPropertyAssisstant.SetProperty(_property);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		GuildPropertyAssisstant.SetProperty(null);
		ViReceiveDataCache<GuildReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	public void OnSmallSpaceConvoke(UInt32 space, PlayerIdentificationProperty sayer)
	{

	}

	public void OnActivityConvoke(UInt32 activity, PlayerIdentificationProperty sayer)
	{

	}

	public GuildPositionStruct GetPosition(ViEntityID uiEntity)
	{
		ReceiveDataGuildMemberProperty pkMemberProperty;
		if (Property.MemberList.TryGetValue(uiEntity, out pkMemberProperty))
		{
			return ViSealedDB<GuildPositionStruct>.Data(pkMemberProperty.Position);
		}
		else
		{
			return GameGuildPositionInstance.Default;
		}

	}

	public Int32 GetMemberCount(GuildPositionStruct kPos)
	{
		Int32 count = 0;
		foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataGuildMemberProperty>> pair in Property.MemberList.Array)
		{
			ReceiveDataGuildMemberProperty iterNode = pair.Value.Property;
			if (iterNode.Position == kPos.ID)
			{
				++count;
			}
		}
		return count;
	}

	public bool HasDecision(ViEntityID kEntity, GuildPositionStruct kReqPos)
	{
		if (GetPosition(kEntity).ID < kReqPos.ID)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	GuildReceiveProperty _property;
}

public class GuildInstance
{
	public static Guild Instance { get { return _instance; } }
	static Guild _instance;
	//
	public static ViEventList EventCreate { get { return _CreateEvent; } }
	public static ViEventList EventExit { get { return _ExitEvent; } }

	public static void Start(Guild entity)
	{
		_instance = entity;
		//
		EventCreate.Invoke(0);
	}

	public static void End()
	{
		EventExit.Invoke(0);
		//
		_instance = null;
	}

	public static void Print(ReceiveDataGuildMessageProperty property, out string record, out DateTime time)
	{
		GuildEventType type = (GuildEventType)property.Type.Value;
		switch (type)
		{
			case GuildEventType.ENTER:
				record = CommonTextAssisstant.GuildEvent_Enter.Print(property.Member.NameAlias);
				break;
			case GuildEventType.EXIT:
				record = CommonTextAssisstant.GuildEvent_Exit.Print(property.Member.NameAlias);
				break;
			case GuildEventType.CONTRIBUTE_JINPIAO:
				record = CommonTextAssisstant.GuildEvent_Contribute.Print(property.Member.NameAlias, property.IntValue0.Value.ToString() + CommonTextAssisstant.JinPiao);
				break;
			case GuildEventType.CONTRIBUTE_YINPIAO:
				record = CommonTextAssisstant.GuildEvent_Contribute.Print(property.Member.NameAlias, property.IntValue0.Value.ToString() + CommonTextAssisstant.YinPiao);
				break;
			case GuildEventType.LEVEL_UP:
				record = CommonTextAssisstant.GuildEvent_LevelUp;
				break;
			case GuildEventType.POSITION_UPDATE:
				GuildPositionStruct info = ViSealedDB<GuildPositionStruct>.Data((Int32)property.IntValue0.Value);
				record = CommonTextAssisstant.GuildEvent_PositionUpdate.Print(property.Member.NameAlias, info.Name);
				break;
			default:
				record = property.Member.NameAlias;
				break;
		}
		//
		time = ViTickCount.Date(property.Time1970);
	}

	static ViEventList _CreateEvent = new ViEventList();
	static ViEventList _ExitEvent = new ViEventList();
}