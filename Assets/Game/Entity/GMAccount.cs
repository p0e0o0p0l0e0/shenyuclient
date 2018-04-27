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
public class GMAccount : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "GMAccount"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return _asLocal; } }
	public bool Active { get { return _active; } }
	public GMAccountReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
		_asLocal = asLocal;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart(){}
	public void Start(){}
	public void AftStart(){}
	public void ClearCallback(){}
	public void PreEnd(){}
	public void End(){}
	public void AftEnd(){}
	public void Tick(float fDeltaTime){}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<GMAccountReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<GMAccountReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel){}
	public void OnPropertyUpdateEnd(UInt8 channel){}
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public void OnUpdatePlayerBaseInfo(List<AccountWithPlayerProperty> list)
	{

	}

	public void OnUpdatePlayerBaseInfo(List<PlayerWithAccountProperty> list)
	{

	}

	public void OnUpdatePlayerDetail(PlayerGMViewProperty property)
	{

	}

	public void OnUpdateServer(List<ServerViewProperty> list)
	{

	}

	public void OnSQLResult(ViString tag, List<ViString> fields, List<ViString> values)
	{

	}

	public void OnUpdateServer(ViString tag, List<ServerViewProperty> list)
	{

	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _asLocal;
	bool _active;
	GMAccountReceiveProperty _property;
}
