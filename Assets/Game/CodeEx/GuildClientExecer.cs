using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GuildClientExecer : ViRPCExecer
{
	public static GuildClientExecer Create() { return new GuildClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(Guild entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new Guild();
		SetEntity(_entity);
		_entity.Enable(ID, PackID, asLocal);
		_entity.StartProperty(channelMask, IS);
		entityManager.AddEntity(ID, PackID, _entity);
		_entity.SetActive(true);
	}
	public override void OnPropertyUpdateStart(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateStart(channel);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdate(channel, IS);
	}
	public override void OnPropertyUpdateEnd(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateEnd(channel);
	}
	public override void End(ViEntityManager entityManager)
	{
		ViDebuger.AssertError(_entity);
		_entity.SetActive(false);
		_entity.EndProperty();
		entityManager.DelEntity(_entity);
		_entity.ClearProperty();
		_entity = null;
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((GuildClientMethod)funcIdx)
		{
			case GuildClientMethod.METHOD_0_OnSmallSpaceConvoke: 
				_0_OnSmallSpaceConvoke(IS);
				break;
			case GuildClientMethod.METHOD_1_OnActivityConvoke: 
				_1_OnActivityConvoke(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnSmallSpaceConvoke(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		PlayerIdentificationProperty Sayer;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Sayer);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSmallSpaceConvoke(" + ", " + Space + ", " + Sayer + ")");
		}
		_entity.OnSmallSpaceConvoke(Space, Sayer);
	}

	void _1_OnActivityConvoke(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Activity;
		ViGameSerializer<UInt32>.Read(IS, out Activity);
		PlayerIdentificationProperty Sayer;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Sayer);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnActivityConvoke(" + ", " + Activity + ", " + Sayer + ")");
		}
		_entity.OnActivityConvoke(Activity, Sayer);
	}

	protected Guild _entity;
}
