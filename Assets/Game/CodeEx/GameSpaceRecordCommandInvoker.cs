using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameSpaceRecordCommandInvoker : ViEntityCommandInvoker<GameSpaceRecord>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".SetExitable", Server_0_SetExitable);
		AddFunc(".SetMemberCountSup", Server_1_SetMemberCountSup);
		AddFunc("/OnResult", Client_0_OnResult);
		AddFunc("/OnEvent", Client_1_OnEvent);
		AddFunc("/OnEvent", Client_2_OnEvent);
		AddFunc("/OnControllerStart", Client_3_OnControllerStart);
		AddFunc("/OnControllerEnd", Client_4_OnControllerEnd);
		AddFunc("/OnControllerBorn", Client_5_OnControllerBorn);
		AddFunc("/OnControllerFactionStart", Client_6_OnControllerFactionStart);
		AddFunc("/OnControllerFactionEnd", Client_7_OnControllerFactionEnd);
		AddFunc("/OnControllerFactionRevert", Client_8_OnControllerFactionRevert);
		AddFunc("/UIEvent", Client_9_UIEvent);
		AddFunc("/UIEvent", Client_10_UIEvent);
	}
	public static new bool Exec(GameSpaceRecord entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<GameSpaceRecord>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		GameSpaceRecord deriveEntity = entity as GameSpaceRecord;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void SetExitable(GameSpaceRecord entity, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameSpaceRecordServerMethod.METHOD_0_SetExitable;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetExitable(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetMemberCountSup(GameSpaceRecord entity, Int16 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameSpaceRecordServerMethod.METHOD_1_SetMemberCountSup;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetMemberCountSup(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_SetExitable(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetExitable(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameSpaceRecordServerMethod.METHOD_0_SetExitable;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_SetMemberCountSup(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Value = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetMemberCountSup(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameSpaceRecordServerMethod.METHOD_1_SetMemberCountSup;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnResult(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 WinFaction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out WinFaction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnResult(WinFaction);
		return true;
	}
	static bool Client_1_OnEvent(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Event = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Event) == false) { return false; }
		ViVector3 Position = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Position) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnEvent(Event, Position, Yaw);
		return true;
	}
	static bool Client_2_OnEvent(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Event = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Event) == false) { return false; }
		PlayerIdentificationProperty Actor = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Actor) == false) { return false; }
		ViVector3 Position = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Position) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnEvent(Event, Actor, Position, Yaw);
		return true;
	}
	static bool Client_3_OnControllerStart(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnControllerStart(ID);
		return true;
	}
	static bool Client_4_OnControllerEnd(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnControllerEnd(ID);
		return true;
	}
	static bool Client_5_OnControllerBorn(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnControllerBorn(ID);
		return true;
	}
	static bool Client_6_OnControllerFactionStart(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnControllerFactionStart(ID, Faction);
		return true;
	}
	static bool Client_7_OnControllerFactionEnd(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnControllerFactionEnd(ID, Faction);
		return true;
	}
	static bool Client_8_OnControllerFactionRevert(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnControllerFactionRevert(ID, Faction);
		return true;
	}
	static bool Client_9_UIEvent(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.UIEvent(ID);
		return true;
	}
	static bool Client_10_UIEvent(GameSpaceRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt64 Player = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Player) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.UIEvent(ID, Player);
		return true;
	}
}
