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
public class PlayerMailbox : PlayerComponent, ViRPCEntity, ViEntity
{
	public static PlayerMailbox Instance { get { return _instance; } }
	static PlayerMailbox _instance = null;
	//
	public static ViEventList EventCreate { get { return _CreateEvent; } }
	public static ViEventList EventExit { get { return _ExitEvent; } }
	static ViEventList _CreateEvent = new ViEventList();
	static ViEventList _ExitEvent = new ViEventList();
	//
	public new PlayerMailboxReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public new string Name { get { return "PlayerMailbox"; } }
	public void SetProperty(PlayerMailboxReceiveProperty property)
	{
		_property = property;
		base.SetProperty(property);
	}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<PlayerMailboxReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
		PlayerMailboxPropertyAssisstant.SetProperty(_property);
		base.SetProperty(_property);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		PlayerMailboxPropertyAssisstant.SetProperty(null);
		ViReceiveDataCache<PlayerMailboxReceiveProperty>.Free(_property);
		_property = null;
	}
	public new void OnPropertyUpdateStart(UInt8 channel){}
	public new void OnPropertyUpdateEnd(UInt8 channel){}
	public new void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public new void Start()
	{
		base.Start();
		//
		PlayerMailBoxPropertyWatcherCreator.Start(_property, this);
		_instance = this;
		//
		if (_instance != null)
		{
			EventCreate.Invoke(0);
		}
	}
	public new void ClearCallback()
	{
		//
		base.ClearCallback();
	}
	public new void End()
	{
		_instance = null;
		EventExit.Invoke(0);
		//
		base.End();
	}

	PlayerMailboxReceiveProperty _property;
	//

}

