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
public class PublicSpaceManager : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "PublicSpaceManager"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public PublicSpaceManagerReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
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
		PublicSpaceManagerInstance.Start(this);
	}
	public void AftStart() { }
	public void ClearCallback() { }
	public void PreEnd()
	{
		PublicSpaceManagerInstance.End();
	}
	public void End() { }
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<PublicSpaceManagerReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<PublicSpaceManagerReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	PublicSpaceManagerReceiveProperty _property;
}

public class PublicSpaceManagerInstance
{
	public static PublicSpaceManager Instance { get { return _instance; } }
	static PublicSpaceManager _instance;
	//
	public static ViEventList EventCreate { get { return _CreateEvent; } }
	public static ViEventList EventExit { get { return _ExitEvent; } }

	public static void Start(PublicSpaceManager entity)
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

	static ViEventList _CreateEvent = new ViEventList();
	static ViEventList _ExitEvent = new ViEventList();
}