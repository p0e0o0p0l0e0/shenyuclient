using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class TradeManagerCommandInvoker : ViEntityCommandInvoker<TradeManager>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".ClearTrade", Server_0_ClearTrade);
		AddFunc(".SetOfficialPrice", Server_1_SetOfficialPrice);
	}
	public static new bool Exec(TradeManager entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<TradeManager>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		TradeManager deriveEntity = entity as TradeManager;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void ClearTrade(TradeManager entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)TradeManagerServerMethod.METHOD_0_ClearTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearTrade(" + entity  + ")");
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

	public static void SetOfficialPrice(TradeManager entity, UInt32 Item, Int32 Inf, Int32 Sup, Int32 Standard, Int32 Current)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)TradeManagerServerMethod.METHOD_1_SetOfficialPrice;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetOfficialPrice(" + entity  + ", " + Item + ", " + Inf + ", " + Sup + ", " + Standard + ", " + Current + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Inf);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Sup);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Standard);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Current);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_ClearTrade(TradeManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearTrade(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)TradeManagerServerMethod.METHOD_0_ClearTrade;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_SetOfficialPrice(TradeManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		Int32 Inf = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Inf) == false) { return false; }
		Int32 Sup = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Sup) == false) { return false; }
		Int32 Standard = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Standard) == false) { return false; }
		Int32 Current = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Current) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetOfficialPrice(" + entity  + ", " + Item + ", " + Inf + ", " + Sup + ", " + Standard + ", " + Current + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)TradeManagerServerMethod.METHOD_1_SetOfficialPrice;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Inf);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Sup);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Standard);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Current);
		entity.RPC.SendMessage();
		return true;
	}
}
