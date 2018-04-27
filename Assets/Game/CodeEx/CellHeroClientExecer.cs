using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellHeroClientExecer : GameUnitClientExecer
{
	public static CellHeroClientExecer Create() { return new CellHeroClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(CellHero entity)
	{
		_entity = entity;
		base.SetEntity(entity);
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new CellHero();
		SetEntity(_entity);
		_entity.Enable(ID, PackID, asLocal);
		_entity.StartProperty(channelMask, IS);
		entityManager.AddEntity(ID, PackID, _entity);
		_entity.SetActive(true);
		_entity.StartInViewData(IS);
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
		_entity.OnLeaveSpace();
		_entity.SetActive(false);
		_entity.EndProperty();
		entityManager.DelEntity(_entity);
		_entity.ClearProperty();
		_entity = null;
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((CellHeroClientMethod)funcIdx)
		{
			case CellHeroClientMethod.METHOD_0_OnBroadCastPing: 
				_0_OnBroadCastPing(IS);
				break;
			case CellHeroClientMethod.METHOD_1_MessageBox: 
				_1_MessageBox(IS);
				break;
			case CellHeroClientMethod.METHOD_2_DebugMessage: 
				_2_DebugMessage(IS);
				break;
			case CellHeroClientMethod.METHOD_3_RollbackMove: 
				_3_RollbackMove(IS);
				break;
			case CellHeroClientMethod.METHOD_4_MoveLockACK: 
				_4_MoveLockACK(IS);
				break;
			case CellHeroClientMethod.METHOD_5_OnWinShow: 
				_5_OnWinShow(IS);
				break;
			case CellHeroClientMethod.METHOD_6_OnLoseShow: 
				_6_OnLoseShow(IS);
				break;
			case CellHeroClientMethod.METHOD_7_OnSpaceActionStart: 
				_7_OnSpaceActionStart(IS);
				break;
			case CellHeroClientMethod.METHOD_8_OnSpaceActionEnd: 
				_8_OnSpaceActionEnd(IS);
				break;
			case CellHeroClientMethod.METHOD_9_CollectSpaceObject: 
				_9_CollectSpaceObject(IS);
				break;
			case CellHeroClientMethod.METHOD_10_EnterSpaceObject: 
				_10_EnterSpaceObject(IS);
				break;
			case CellHeroClientMethod.METHOD_11_OnNPCLoot: 
				_11_OnNPCLoot(IS);
				break;
			case CellHeroClientMethod.METHOD_12_OnNPCDie: 
				_12_OnNPCDie(IS);
				break;
			case CellHeroClientMethod.METHOD_13_OnWaveLoaded: 
				_13_OnWaveLoaded(IS);
				break;
			case CellHeroClientMethod.METHOD_14_OnMeleeWithoutTarget: 
				_14_OnMeleeWithoutTarget(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnBroadCastPing(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int64 Time;
		ViGameSerializer<Int64>.Read(IS, out Time);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBroadCastPing(" + ", " + Time + ")");
		}
		_entity.OnBroadCastPing(Time);
	}

	void _1_MessageBox(ViIStream IS)
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

	void _2_DebugMessage(ViIStream IS)
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

	void _3_RollbackMove(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].RollbackMove(" + ", " + Pos + ", " + Yaw + ")");
		}
		_entity.RollbackMove(Pos, Yaw);
	}

	void _4_MoveLockACK(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViRPCCallback<UInt8> Result;
		ViRPCCallbackSerializer.Read(IS, out Result);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].MoveLockACK(" + ", " + Result + ")");
		}
		_entity.MoveLockACK(Result);
	}

	void _5_OnWinShow(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnWinShow(" + ")");
		}
		_entity.OnWinShow();
	}

	void _6_OnLoseShow(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLoseShow(" + ")");
		}
		_entity.OnLoseShow();
	}

	void _7_OnSpaceActionStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		SpaceObject SpaceObject;
		ViGameSerializer<SpaceObject>.Read(IS, out SpaceObject);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpaceActionStart(" + ", " + SpaceObject + ", " + Duration + ")");
		}
		_entity.OnSpaceActionStart(SpaceObject, Duration);
	}

	void _8_OnSpaceActionEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		SpaceObject SpaceObject;
		ViGameSerializer<SpaceObject>.Read(IS, out SpaceObject);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpaceActionEnd(" + ", " + SpaceObject + ")");
		}
		_entity.OnSpaceActionEnd(SpaceObject);
	}

	void _9_CollectSpaceObject(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int32 ID;
		ViGameSerializer<Int32>.Read(IS, out ID);
		Int32 Duration;
		ViGameSerializer<Int32>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].CollectSpaceObject(" + ", " + ID + ", " + Duration + ")");
		}
		_entity.CollectSpaceObject(ID, Duration);
	}

	void _10_EnterSpaceObject(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int32 BirthID;
		ViGameSerializer<Int32>.Read(IS, out BirthID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].EnterSpaceObject(" + ", " + BirthID + ")");
		}
		_entity.EnterSpaceObject(BirthID);
	}

	void _11_OnNPCLoot(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		CellNPC Entity;
		ViGameSerializer<CellNPC>.Read(IS, out Entity);
		Int32 XP;
		ViGameSerializer<Int32>.Read(IS, out XP);
		Int32 YinPiao;
		ViGameSerializer<Int32>.Read(IS, out YinPiao);
		List<ItemCountProperty> ItemList;
		ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnNPCLoot(" + ", " + Entity + ", " + XP + ", " + YinPiao + ", " + ItemList + ")");
		}
		_entity.OnNPCLoot(Entity, XP, YinPiao, ItemList);
	}

	void _12_OnNPCDie(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int32 BirthID;
		ViGameSerializer<Int32>.Read(IS, out BirthID);
		Int32 NPCID;
		ViGameSerializer<Int32>.Read(IS, out NPCID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnNPCDie(" + ", " + BirthID + ", " + NPCID + ")");
		}
		_entity.OnNPCDie(BirthID, NPCID);
	}

	void _13_OnWaveLoaded(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int32 BirthID;
		ViGameSerializer<Int32>.Read(IS, out BirthID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnWaveLoaded(" + ", " + BirthID + ")");
		}
		_entity.OnWaveLoaded(BirthID);
	}

	void _14_OnMeleeWithoutTarget(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMeleeWithoutTarget(" + ")");
		}
		_entity.OnMeleeWithoutTarget();
	}

	protected new CellHero _entity;
}
