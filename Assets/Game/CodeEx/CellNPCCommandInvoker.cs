using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellNPCCommandInvoker : ViEntityCommandInvoker<CellNPC>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".DelSelf", Server_0_DelSelf);
		AddFunc(".ResetAI", Server_1_ResetAI);
		AddFunc("/OnEnterSpaceComplete", Client_0_OnEnterSpaceComplete);
		AddFunc("/OnFirstChase", Client_1_OnFirstChase);
		AddFunc("/OnChaseStart", Client_2_OnChaseStart);
		AddFunc("/OnFirstAttacked", Client_3_OnFirstAttacked);
		AddFunc("/OnKilled", Client_4_OnKilled);
		AddFunc("/OnKilled", Client_5_OnKilled);
		AddFunc("/ShowExplore", Client_6_ShowExplore);
	}
	public static new bool Exec(CellNPC entity, string name, List<string> paramList)
	{
		if (ViEntityCommandInvoker<CellNPC>.Exec(entity, name, paramList) == true) { return true; }
		else { return GameUnitCommandInvoker.Exec(entity, name, paramList); }
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		CellNPC deriveEntity = entity as CellNPC;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void DelSelf(CellNPC entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellNPCServerMethod.METHOD_0_DelSelf;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSelf(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetAI(CellNPC entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellNPCServerMethod.METHOD_1_ResetAI;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetAI(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_DelSelf(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelSelf(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellNPCServerMethod.METHOD_0_DelSelf;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_ResetAI(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetAI(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellNPCServerMethod.METHOD_1_ResetAI;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnEnterSpaceComplete(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnEnterSpaceComplete();
		return true;
	}
	static bool Client_1_OnFirstChase(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Victim = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Victim) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnFirstChase(Victim);
		return true;
	}
	static bool Client_2_OnChaseStart(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChaseStart(Target);
		return true;
	}
	static bool Client_3_OnFirstAttacked(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnFirstAttacked(Attacker);
		return true;
	}
	static bool Client_4_OnKilled(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		Int8 FromYaw = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FromYaw) == false) { return false; }
		UInt16 Force = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Force) == false) { return false; }
		UInt8 Explore = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Explore) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnKilled(Attacker, FromYaw, Force, Explore);
		return true;
	}
	static bool Client_5_OnKilled(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		Int8 FromYaw = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FromYaw) == false) { return false; }
		UInt16 Force = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Force) == false) { return false; }
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		UInt8 Explore = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Explore) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnKilled(Attacker, FromYaw, Force, Visual, Explore);
		return true;
	}
	static bool Client_6_ShowExplore(CellNPC entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Force = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Force) == false) { return false; }
		float ForceScale = default(float); if (ViGameSerializer<float>.Read(IS, out ForceScale) == false) { return false; }
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ShowExplore(Force, ForceScale, Visual);
		return true;
	}
}
