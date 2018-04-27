using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GMAccountClientExecer : ViRPCExecer
{
	public static GMAccountClientExecer Create() { return new GMAccountClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(GMAccount entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new GMAccount();
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
		switch((GMAccountClientMethod)funcIdx)
		{
			case GMAccountClientMethod.METHOD_0_OnUpdatePlayerBaseInfo: 
				_0_OnUpdatePlayerBaseInfo(IS);
				break;
			case GMAccountClientMethod.METHOD_1_OnUpdatePlayerBaseInfo: 
				_1_OnUpdatePlayerBaseInfo(IS);
				break;
			case GMAccountClientMethod.METHOD_2_OnUpdatePlayerDetail: 
				_2_OnUpdatePlayerDetail(IS);
				break;
			case GMAccountClientMethod.METHOD_3_OnUpdateServer: 
				_3_OnUpdateServer(IS);
				break;
			case GMAccountClientMethod.METHOD_4_OnSQLResult: 
				_4_OnSQLResult(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnUpdatePlayerBaseInfo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<AccountWithPlayerProperty> List;
		ViGameSerializer<AccountWithPlayerProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdatePlayerBaseInfo(" + ", " + List + ")");
		}
		_entity.OnUpdatePlayerBaseInfo(List);
	}

	void _1_OnUpdatePlayerBaseInfo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<PlayerWithAccountProperty> List;
		ViGameSerializer<PlayerWithAccountProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdatePlayerBaseInfo(" + ", " + List + ")");
		}
		_entity.OnUpdatePlayerBaseInfo(List);
	}

	void _2_OnUpdatePlayerDetail(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		PlayerGMViewProperty Property;
		ViGameSerializer<PlayerGMViewProperty>.Read(IS, out Property);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdatePlayerDetail(" + ", " + Property + ")");
		}
		_entity.OnUpdatePlayerDetail(Property);
	}

	void _3_OnUpdateServer(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Tag;
		ViGameSerializer<ViString>.Read(IS, out Tag);
		List<ServerViewProperty> List;
		ViGameSerializer<ServerViewProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateServer(" + ", " + Tag + ", " + List + ")");
		}
		_entity.OnUpdateServer(Tag, List);
	}

	void _4_OnSQLResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Tag;
		ViGameSerializer<ViString>.Read(IS, out Tag);
		List<ViString> Fields;
		ViGameSerializer<ViString>.Read(IS, out Fields);
		List<ViString> Values;
		ViGameSerializer<ViString>.Read(IS, out Values);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSQLResult(" + ", " + Tag + ", " + Fields + ", " + Values + ")");
		}
		_entity.OnSQLResult(Tag, Fields, Values);
	}

	protected GMAccount _entity;
}
