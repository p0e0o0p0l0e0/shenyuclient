using System;

using ViEntityTypeID = System.Byte;
using ViEntityID = System.UInt64;
using UInt8 = System.Byte;


public class ViSimpleEntity<TProperty> : ViRPCEntity, ViEntity
	where TProperty : ViReceiveProperty, ViReceiveDataMemoryObject, new()
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	public TProperty Property { get { return _property; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return _asLocal; } }
	public bool Active { get { return _active; } }
	public string Name { get { return "SimpleEntity"; } }

	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<TProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<TProperty>.Free(_property);
		_property = null;
	}
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
	public void PreStart() { }
	public void Start() { }
	public void AftStart() { }
	public void Tick(float fDeltaTime) { }
	public void ClearCallback() { }
	public void PreEnd() { }
	public void End() { }
	public void AftEnd()
	{
		RPC.End();
	}
	public void OnPropertyUpdateStart(UInt8 channel)
	{

	}
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public void OnPropertyUpdateEnd(UInt8 channel)
	{

	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _asLocal;
	bool _active;
	TProperty _property;
	ViRPCInvoker _RPC = new ViRPCInvoker();
}