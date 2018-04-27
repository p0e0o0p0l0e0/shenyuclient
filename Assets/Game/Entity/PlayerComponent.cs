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
public class PlayerComponent : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "PlayerComponent"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return _asLocal; } }
	public bool Active { get { return _active; } }
	public PlayerComponentReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public void SetProperty(PlayerComponentReceiveProperty property)
	{
		_property = property;
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
	public void ClearCallback() { }
	public void PreEnd() { }
	public void End() { }
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	public void MessageBox(ViString title, ViString content)
	{
		//ViewControllerManager.PrintMSGView.SetMessage(content);
	}

	public void DebugMessage(ViString title, ViString content)
	{
		EntityMessageController.OnDebugMessage(title, content);
	}

	public void ContainReserveWord(ViString orgValue, ViString fmtValue)
	{
		//ViewControllerManager.PrintMSGView.SetMessage("包含禁用词汇(" + orgValue + "->" + fmtValue + ")");
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _asLocal;
	bool _active;
	PlayerComponentReceiveProperty _property;
}