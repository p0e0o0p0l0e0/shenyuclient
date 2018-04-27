using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CenterChatGroupClientExecer : ViRPCExecer
{
	public static CenterChatGroupClientExecer Create() { return new CenterChatGroupClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(CenterChatGroup entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new CenterChatGroup();
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
		switch((CenterChatGroupClientMethod)funcIdx)
		{
			case CenterChatGroupClientMethod.METHOD_0_OnChatScriptBegin: 
				_0_OnChatScriptBegin(IS);
				break;
			case CenterChatGroupClientMethod.METHOD_1_OnChatScriptShowItem: 
				_1_OnChatScriptShowItem(IS);
				break;
			case CenterChatGroupClientMethod.METHOD_2_OnChatScriptEnd: 
				_2_OnChatScriptEnd(IS);
				break;
			case CenterChatGroupClientMethod.METHOD_3_OnChatMessage: 
				_3_OnChatMessage(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnChatScriptBegin(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		PlayerIdentificationProperty Name;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Name);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChatScriptBegin(" + ", " + Name + ")");
		}
		_entity.OnChatScriptBegin(Name);
	}

	void _1_OnChatScriptShowItem(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Item;
		ViGameSerializer<UInt32>.Read(IS, out Item);
		UInt64 ID;
		ViGameSerializer<UInt64>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChatScriptShowItem(" + ", " + Item + ", " + ID + ")");
		}
		_entity.OnChatScriptShowItem(Item, ID);
	}

	void _2_OnChatScriptEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Script;
		ViGameSerializer<ViString>.Read(IS, out Script);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChatScriptEnd(" + ", " + Script + ")");
		}
		_entity.OnChatScriptEnd(Script);
	}

	void _3_OnChatMessage(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		PlayerIdentificationProperty Name;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Name);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChatMessage(" + ", " + Name + ", " + Content + ")");
		}
		_entity.OnChatMessage(Name, Content);
	}

	protected CenterChatGroup _entity;
}
