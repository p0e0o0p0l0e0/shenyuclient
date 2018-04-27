using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameSpaceRecordClientExecer : ViRPCExecer
{
	public static GameSpaceRecordClientExecer Create() { return new GameSpaceRecordClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(GameSpaceRecord entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new GameSpaceRecord();
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
		switch((GameSpaceRecordClientMethod)funcIdx)
		{
			case GameSpaceRecordClientMethod.METHOD_0_OnResult: 
				_0_OnResult(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_1_OnEvent: 
				_1_OnEvent(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_2_OnEvent: 
				_2_OnEvent(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_3_OnControllerStart: 
				_3_OnControllerStart(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_4_OnControllerEnd: 
				_4_OnControllerEnd(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_5_OnControllerBorn: 
				_5_OnControllerBorn(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_6_OnControllerFactionStart: 
				_6_OnControllerFactionStart(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_7_OnControllerFactionEnd: 
				_7_OnControllerFactionEnd(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_8_OnControllerFactionRevert: 
				_8_OnControllerFactionRevert(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_9_UIEvent: 
				_9_UIEvent(IS);
				break;
			case GameSpaceRecordClientMethod.METHOD_10_UIEvent: 
				_10_UIEvent(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 WinFaction;
		ViGameSerializer<UInt8>.Read(IS, out WinFaction);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnResult(" + ", " + WinFaction + ")");
		}
		_entity.OnResult(WinFaction);
	}

	void _1_OnEvent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Event;
		ViGameSerializer<UInt32>.Read(IS, out Event);
		ViVector3 Position;
		ViGameSerializer<ViVector3>.Read(IS, out Position);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnEvent(" + ", " + Event + ", " + Position + ", " + Yaw + ")");
		}
		_entity.OnEvent(Event, Position, Yaw);
	}

	void _2_OnEvent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Event;
		ViGameSerializer<UInt32>.Read(IS, out Event);
		PlayerIdentificationProperty Actor;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Actor);
		ViVector3 Position;
		ViGameSerializer<ViVector3>.Read(IS, out Position);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnEvent(" + ", " + Event + ", " + Actor + ", " + Position + ", " + Yaw + ")");
		}
		_entity.OnEvent(Event, Actor, Position, Yaw);
	}

	void _3_OnControllerStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnControllerStart(" + ", " + ID + ")");
		}
		_entity.OnControllerStart(ID);
	}

	void _4_OnControllerEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnControllerEnd(" + ", " + ID + ")");
		}
		_entity.OnControllerEnd(ID);
	}

	void _5_OnControllerBorn(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnControllerBorn(" + ", " + ID + ")");
		}
		_entity.OnControllerBorn(ID);
	}

	void _6_OnControllerFactionStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt8 Faction;
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnControllerFactionStart(" + ", " + ID + ", " + Faction + ")");
		}
		_entity.OnControllerFactionStart(ID, Faction);
	}

	void _7_OnControllerFactionEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt8 Faction;
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnControllerFactionEnd(" + ", " + ID + ", " + Faction + ")");
		}
		_entity.OnControllerFactionEnd(ID, Faction);
	}

	void _8_OnControllerFactionRevert(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt8 Faction;
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnControllerFactionRevert(" + ", " + ID + ", " + Faction + ")");
		}
		_entity.OnControllerFactionRevert(ID, Faction);
	}

	void _9_UIEvent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].UIEvent(" + ", " + ID + ")");
		}
		_entity.UIEvent(ID);
	}

	void _10_UIEvent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt64 Player;
		ViGameSerializer<UInt64>.Read(IS, out Player);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].UIEvent(" + ", " + ID + ", " + Player + ")");
		}
		_entity.UIEvent(ID, Player);
	}

	protected GameSpaceRecord _entity;
}
