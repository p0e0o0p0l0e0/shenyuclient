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
public class PlayerGuild : PlayerComponent, ViRPCEntity, ViEntity
{
	public static PlayerGuild Instance { get { return _instance; } }
	static PlayerGuild _instance = null;
	//
	public new PlayerGuildReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public new string Name { get { return "PlayerGuild"; } }
	public void SetProperty(PlayerGuildReceiveProperty property)
	{
		_property = property;
		base.SetProperty(property);
	}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<PlayerGuildReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
		base.SetProperty(_property);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<PlayerGuildReceiveProperty>.Free(_property);
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
		_instance = this;
	}
	public new void ClearCallback()
	{
		//
		base.ClearCallback();
	}
	public new void End()
	{
		_instance = null;
		//
		base.End();
	}

	PlayerGuildReceiveProperty _property;
}
