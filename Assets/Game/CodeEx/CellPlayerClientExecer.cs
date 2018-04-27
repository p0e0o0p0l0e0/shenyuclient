using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellPlayerClientExecer : ViRPCExecer
{
	public static CellPlayerClientExecer Create() { return new CellPlayerClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(CellPlayer entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new CellPlayer();
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
		switch((CellPlayerClientMethod)funcIdx)
		{
			case CellPlayerClientMethod.METHOD_0_MessageBox: 
				_0_MessageBox(IS);
				break;
			case CellPlayerClientMethod.METHOD_1_DebugMessage: 
				_1_DebugMessage(IS);
				break;
			case CellPlayerClientMethod.METHOD_2_ContainReserveWord: 
				_2_ContainReserveWord(IS);
				break;
			case CellPlayerClientMethod.METHOD_3_OnPing: 
				_3_OnPing(IS);
				break;
			case CellPlayerClientMethod.METHOD_4_HoldHeroRes: 
				_4_HoldHeroRes(IS);
				break;
			case CellPlayerClientMethod.METHOD_5_FreeHeroRes: 
				_5_FreeHeroRes(IS);
				break;
			case CellPlayerClientMethod.METHOD_6_OnNavigateTo: 
				_6_OnNavigateTo(IS);
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

	void _3_OnPing(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int64 Time;
		ViGameSerializer<Int64>.Read(IS, out Time);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPing(" + ", " + Time + ")");
		}
		_entity.OnPing(Time);
	}

	void _4_HoldHeroRes(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].HoldHeroRes(" + ")");
		}
		_entity.HoldHeroRes();
	}

	void _5_FreeHeroRes(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].FreeHeroRes(" + ")");
		}
		_entity.FreeHeroRes();
	}

	void _6_OnNavigateTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ViVector3> PositionArray;
		ViGameSerializer<ViVector3>.Read(IS, out PositionArray);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnNavigateTo(" + ", " + PositionArray + ")");
		}
		_entity.OnNavigateTo(PositionArray);
	}

	protected CellPlayer _entity;
}
