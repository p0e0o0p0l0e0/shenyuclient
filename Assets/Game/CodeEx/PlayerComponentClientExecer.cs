using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerComponentClientExecer : ViRPCExecer
{
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(PlayerComponent entity)
	{
		_entity = entity;
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((PlayerComponentClientMethod)funcIdx)
		{
			case PlayerComponentClientMethod.METHOD_0_MessageBox: 
				_0_MessageBox(IS);
				break;
			case PlayerComponentClientMethod.METHOD_1_DebugMessage: 
				_1_DebugMessage(IS);
				break;
			case PlayerComponentClientMethod.METHOD_2_ContainReserveWord: 
				_2_ContainReserveWord(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_MessageBox(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Title;
		ViGameSerializer<ViString>.Read(IS, out Title);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].MessageBox(" + ", " + Title + ", " + Content + ")");
		}
		_entity.MessageBox(Title, Content);
	}

	void _1_DebugMessage(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Title;
		ViGameSerializer<ViString>.Read(IS, out Title);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].DebugMessage(" + ", " + Title + ", " + Content + ")");
		}
		_entity.DebugMessage(Title, Content);
	}

	void _2_ContainReserveWord(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString OrgValue;
		ViGameSerializer<ViString>.Read(IS, out OrgValue);
		ViString FmtValue;
		ViGameSerializer<ViString>.Read(IS, out FmtValue);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ContainReserveWord(" + ", " + OrgValue + ", " + FmtValue + ")");
		}
		_entity.ContainReserveWord(OrgValue, FmtValue);
	}

	protected PlayerComponent _entity;
}
