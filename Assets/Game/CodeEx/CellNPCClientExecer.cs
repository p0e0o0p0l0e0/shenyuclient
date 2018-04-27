using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellNPCClientExecer : GameUnitClientExecer
{
	public static CellNPCClientExecer Create() { return new CellNPCClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(CellNPC entity)
	{
		_entity = entity;
		base.SetEntity(entity);
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new CellNPC();
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
		switch((CellNPCClientMethod)funcIdx)
		{
			case CellNPCClientMethod.METHOD_0_OnEnterSpaceComplete: 
				_0_OnEnterSpaceComplete(IS);
				break;
			case CellNPCClientMethod.METHOD_1_OnFirstChase: 
				_1_OnFirstChase(IS);
				break;
			case CellNPCClientMethod.METHOD_2_OnChaseStart: 
				_2_OnChaseStart(IS);
				break;
			case CellNPCClientMethod.METHOD_3_OnFirstAttacked: 
				_3_OnFirstAttacked(IS);
				break;
			case CellNPCClientMethod.METHOD_4_OnKilled: 
				_4_OnKilled(IS);
				break;
			case CellNPCClientMethod.METHOD_5_OnKilled: 
				_5_OnKilled(IS);
				break;
			case CellNPCClientMethod.METHOD_6_ShowExplore: 
				_6_ShowExplore(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnEnterSpaceComplete(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnEnterSpaceComplete(" + ")");
		}
		_entity.OnEnterSpaceComplete();
	}

	void _1_OnFirstChase(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Victim;
		ViGameSerializer<GameUnit>.Read(IS, out Victim);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFirstChase(" + ", " + Victim + ")");
		}
		_entity.OnFirstChase(Victim);
	}

	void _2_OnChaseStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Target;
		ViGameSerializer<GameUnit>.Read(IS, out Target);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChaseStart(" + ", " + Target + ")");
		}
		_entity.OnChaseStart(Target);
	}

	void _3_OnFirstAttacked(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFirstAttacked(" + ", " + Attacker + ")");
		}
		_entity.OnFirstAttacked(Attacker);
	}

	void _4_OnKilled(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		Int8 FromYaw;
		ViGameSerializer<Int8>.Read(IS, out FromYaw);
		UInt16 Force;
		ViGameSerializer<UInt16>.Read(IS, out Force);
		UInt8 Explore;
		ViGameSerializer<UInt8>.Read(IS, out Explore);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnKilled(" + ", " + Attacker + ", " + FromYaw + ", " + Force + ", " + Explore + ")");
		}
		_entity.OnKilled(Attacker, FromYaw, Force, Explore);
	}

	void _5_OnKilled(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		Int8 FromYaw;
		ViGameSerializer<Int8>.Read(IS, out FromYaw);
		UInt16 Force;
		ViGameSerializer<UInt16>.Read(IS, out Force);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		UInt8 Explore;
		ViGameSerializer<UInt8>.Read(IS, out Explore);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnKilled(" + ", " + Attacker + ", " + FromYaw + ", " + Force + ", " + Visual + ", " + Explore + ")");
		}
		_entity.OnKilled(Attacker, FromYaw, Force, Visual, Explore);
	}

	void _6_ShowExplore(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Force;
		ViGameSerializer<UInt32>.Read(IS, out Force);
		float ForceScale;
		ViGameSerializer<float>.Read(IS, out ForceScale);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ShowExplore(" + ", " + Force + ", " + ForceScale + ", " + Visual + ")");
		}
		_entity.ShowExplore(Force, ForceScale, Visual);
	}

	protected new CellNPC _entity;
}
