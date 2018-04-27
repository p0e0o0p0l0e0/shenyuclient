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
//
public class PublicSpaceEnter : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "PublicSpaceEnter"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public PublicSpaceEnterReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }

	public bool IsLeader { get { return Property.Leader.ID == Player.Instance.ID; } }

	public UInt8 SelfFaction
	{
		get
		{
			ReceiveDataPublicSpaceEnterMemberProperty property;
			if (Property.MemberList.TryGetValue(Player.Instance.ID, out property))
			{
				return property.FactionIdx;
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
	public void PreStart() { }
	public void Start()
	{
		PublicSpaceEnterInstance.Start(this);
	}
	public void AftStart() { }
	public void ClearCallback() { }
	public void PreEnd() { }
	public void End()
	{
		PublicSpaceEnterInstance.End();
	}
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<PublicSpaceEnterReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<PublicSpaceEnterReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	public void GetFactionMembers(UInt8 faction, List<ReceiveDataPublicSpaceEnterMemberProperty> memberList)
	{
		foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataPublicSpaceEnterMemberProperty>> pair in PublicSpaceEnterInstance.Instance.Property.MemberList.Array)
		{
			ReceiveDataPublicSpaceEnterMemberProperty property = pair.Value.Property;
			if (property.FactionIdx == faction)
			{
				memberList.Add(property);
			}
		}
	}


	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	PublicSpaceEnterReceiveProperty _property;
}

public class PublicSpaceEnterInstance
{
	public static PublicSpaceEnter Instance { get { return _instance; } }
	static PublicSpaceEnter _instance;

	public static void Start(PublicSpaceEnter entity)
	{
		_instance = entity;
		//
		//ViewControllerManager.OnPublicSpaceGroupCreated();
	}

	public static void End()
	{
		//ViewControllerManager.OnExitPublicSpaceGroup();
		//
		_instance = null;
	}
}