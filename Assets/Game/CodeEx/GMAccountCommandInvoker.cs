using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GMAccountCommandInvoker : ViEntityCommandInvoker<GMAccount>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".DisplayServerList", Server_0_DisplayServerList);
		AddFunc(".DisplayPlayer", Server_1_DisplayPlayer);
		AddFunc(".FindPlayerByID", Server_2_FindPlayerByID);
		AddFunc(".FindPlayerByName", Server_3_FindPlayerByName);
		AddFunc(".FindPlayerByAccountID", Server_4_FindPlayerByAccountID);
		AddFunc(".FindPlayerByAccountName", Server_5_FindPlayerByAccountName);
		AddFunc(".OnNewDay", Server_6_OnNewDay);
		AddFunc(".ResetData", Server_7_ResetData);
		AddFunc(".ResetConstValue", Server_8_ResetConstValue);
		AddFunc(".AddBoard", Server_9_AddBoard);
		AddFunc(".AddBoard", Server_10_AddBoard);
		AddFunc(".DelBoard", Server_11_DelBoard);
		AddFunc(".AddNote", Server_12_AddNote);
		AddFunc(".DelNote", Server_13_DelNote);
		AddFunc(".SendMail", Server_14_SendMail);
		AddFunc(".ResetActivityTime", Server_15_ResetActivityTime);
		AddFunc(".OpenActivity", Server_16_OpenActivity);
		AddFunc(".CloseActivity", Server_17_CloseActivity);
		AddFunc(".ResetTimeBoard", Server_18_ResetTimeBoard);
		AddFunc(".AddCDKey", Server_19_AddCDKey);
		AddFunc(".DisableIP", Server_20_DisableIP);
		AddFunc(".DisableIP", Server_21_DisableIP);
		AddFunc(".EnableIP", Server_22_EnableIP);
		AddFunc(".DisableAccount", Server_23_DisableAccount);
		AddFunc(".DisableAccount", Server_24_DisableAccount);
		AddFunc(".EnableAccount", Server_25_EnableAccount);
		AddFunc(".AddGameFuncClosed", Server_26_AddGameFuncClosed);
		AddFunc(".DelGameFuncClosed", Server_27_DelGameFuncClosed);
		AddFunc(".ExecScript", Server_28_ExecScript);
		AddFunc(".ExecScriptToPlayer", Server_29_ExecScriptToPlayer);
		AddFunc(".PrintProperty", Server_30_PrintProperty);
		AddFunc(".PrintGlobalProperty", Server_31_PrintGlobalProperty);
		AddFunc(".SendMail", Server_32_SendMail);
		AddFunc(".ExecScriptToPlayer", Server_33_ExecScriptToPlayer);
		AddFunc(".SQL_OnlineCount", Server_34_SQL_OnlineCount);
		AddFunc(".SQL_NewAccountCount", Server_35_SQL_NewAccountCount);
		AddFunc(".SQL_RechargeAccountStatistic", Server_36_SQL_RechargeAccountStatistic);
		AddFunc(".SQL_RechargeStatistic", Server_37_SQL_RechargeStatistic);
		AddFunc(".SQL_LoginCount", Server_38_SQL_LoginCount);
		AddFunc(".SQL_NewRechargeAccountCount", Server_39_SQL_NewRechargeAccountCount);
		AddFunc(".SQL_MaxAndAvgOnlineCount", Server_40_SQL_MaxAndAvgOnlineCount);
		AddFunc(".SQL_FindNameByNameAlias", Server_41_SQL_FindNameByNameAlias);
		AddFunc(".SQL_FindNameByNameAlias", Server_42_SQL_FindNameByNameAlias);
		AddFunc("/OnUpdatePlayerBaseInfo", Client_0_OnUpdatePlayerBaseInfo);
		AddFunc("/OnUpdatePlayerBaseInfo", Client_1_OnUpdatePlayerBaseInfo);
		AddFunc("/OnUpdatePlayerDetail", Client_2_OnUpdatePlayerDetail);
		AddFunc("/OnUpdateServer", Client_3_OnUpdateServer);
		AddFunc("/OnSQLResult", Client_4_OnSQLResult);
	}
	public static new bool Exec(GMAccount entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<GMAccount>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		GMAccount deriveEntity = entity as GMAccount;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	static bool Server_0_DisplayServerList(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisplayServerList(" + entity  + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_0_DisplayServerList;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_DisplayPlayer(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisplayPlayer(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_1_DisplayPlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_FindPlayerByID(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> IDList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out IDList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByID(" + entity  + ", " + IDList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_2_FindPlayerByID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_FindPlayerByName(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Server = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Server) == false) { return false; }
		List<ViString> NameList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out NameList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByName(" + entity  + ", " + Server + ", " + NameList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_3_FindPlayerByName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Server);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_FindPlayerByAccountID(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> IDList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out IDList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByAccountID(" + entity  + ", " + IDList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_4_FindPlayerByAccountID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_FindPlayerByAccountName(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Server = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Server) == false) { return false; }
		List<ViString> NameList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out NameList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByAccountName(" + entity  + ", " + Server + ", " + NameList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_5_FindPlayerByAccountName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Server);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_OnNewDay(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewDay(" + entity  + ", " + ServerList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_6_OnNewDay;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_ResetData(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetData(" + entity  + ", " + ServerList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_7_ResetData;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_ResetConstValue(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetConstValue(" + entity  + ", " + ServerList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_8_ResetConstValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_AddBoard(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		UInt8 Type = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Type) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddBoard(" + entity  + ", " + ServerList + ", " + Type + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_9_AddBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_AddBoard(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		UInt8 Type = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Type) == false) { return false; }
		Int64 StartTime1970 = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out StartTime1970) == false) { return false; }
		Int64 EndTime1970 = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out EndTime1970) == false) { return false; }
		Int64 Span = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Span) == false) { return false; }
		UInt8 Loop = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Loop) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddBoard(" + entity  + ", " + ServerList + ", " + Type + ", " + StartTime1970 + ", " + EndTime1970 + ", " + Span + ", " + Loop + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_10_AddBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, StartTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, EndTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Span);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Loop);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_DelBoard(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelBoard(" + entity  + ", " + ServerList + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_11_DelBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_AddNote(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNote(" + entity  + ", " + ServerList + ", " + Title + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_12_AddNote;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_DelNote(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelNote(" + entity  + ", " + ServerList + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_13_DelNote;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_SendMail(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		UInt8 BroadcastRange = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out BroadcastRange) == false) { return false; }
		GMRequestProperty Request = default(GMRequestProperty); if (ViGameSerializer<GMRequestProperty>.Read(IS, out Request) == false) { return false; }
		MailProperty Property = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SendMail(" + entity  + ", " + ServerList + ", " + BroadcastRange + ", " + Request + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_14_SendMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, BroadcastRange);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_ResetActivityTime(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetActivityTime(" + entity  + ", " + ServerList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_15_ResetActivityTime;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_OpenActivity(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OpenActivity(" + entity  + ", " + ServerList + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_16_OpenActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_CloseActivity(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseActivity(" + entity  + ", " + ServerList + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_17_CloseActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_ResetTimeBoard(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetTimeBoard(" + entity  + ", " + ServerList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_18_ResetTimeBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_19_AddCDKey(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<ViString> KeyList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out KeyList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddCDKey(" + entity  + ", " + ServerList + ", " + KeyList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_19_AddCDKey;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, KeyList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_20_DisableIP(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<DisableRecordProperty> AddressList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AddressList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableIP(" + entity  + ", " + ServerList + ", " + AddressList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_20_DisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_21_DisableIP(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<DisableRecordProperty> AddressList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AddressList) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableIP(" + entity  + ", " + ServerList + ", " + AddressList + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_21_DisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_22_EnableIP(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<ViString> AddressList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out AddressList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnableIP(" + entity  + ", " + ServerList + ", " + AddressList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_22_EnableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_23_DisableAccount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<DisableRecordProperty> AccountList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AccountList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_23_DisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_24_DisableAccount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<DisableRecordProperty> AccountList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AccountList) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_24_DisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_25_EnableAccount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<ViString> AccountList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out AccountList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_25_EnableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_26_AddGameFuncClosed(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<UInt32> FuncList = default(List<UInt32>); if (ViGameSerializer<UInt32>.Read(IS, out FuncList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGameFuncClosed(" + entity  + ", " + ServerList + ", " + FuncList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_26_AddGameFuncClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FuncList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_27_DelGameFuncClosed(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		List<UInt32> FuncList = default(List<UInt32>); if (ViGameSerializer<UInt32>.Read(IS, out FuncList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelGameFuncClosed(" + entity  + ", " + ServerList + ", " + FuncList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_27_DelGameFuncClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FuncList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_28_ExecScript(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecScript(" + entity  + ", " + ServerList + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_28_ExecScript;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_29_ExecScriptToPlayer(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> ServerList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out ServerList) == false) { return false; }
		UInt8 BroadcastRange = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out BroadcastRange) == false) { return false; }
		GMRequestProperty Request = default(GMRequestProperty); if (ViGameSerializer<GMRequestProperty>.Read(IS, out Request) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecScriptToPlayer(" + entity  + ", " + ServerList + ", " + BroadcastRange + ", " + Request + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_29_ExecScriptToPlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, BroadcastRange);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_30_PrintProperty(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_30_PrintProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_31_PrintGlobalProperty(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_31_PrintGlobalProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_32_SendMail(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> PlayerList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out PlayerList) == false) { return false; }
		MailProperty Property = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SendMail(" + entity  + ", " + PlayerList + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_32_SendMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_33_ExecScriptToPlayer(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> PlayerList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out PlayerList) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecScriptToPlayer(" + entity  + ", " + PlayerList + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_33_ExecScriptToPlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_34_SQL_OnlineCount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		Int64 Time1970Right = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Right) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_OnlineCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_34_SQL_OnlineCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_35_SQL_NewAccountCount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		Int64 Time1970Right = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Right) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_NewAccountCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_35_SQL_NewAccountCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_36_SQL_RechargeAccountStatistic(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		Int64 Time1970Right = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Right) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_RechargeAccountStatistic(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_36_SQL_RechargeAccountStatistic;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_37_SQL_RechargeStatistic(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		Int64 Time1970Right = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Right) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_RechargeStatistic(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_37_SQL_RechargeStatistic;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_38_SQL_LoginCount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_LoginCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_38_SQL_LoginCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_39_SQL_NewRechargeAccountCount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		Int64 Time1970Right = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Right) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_NewRechargeAccountCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_39_SQL_NewRechargeAccountCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_40_SQL_MaxAndAvgOnlineCount(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		Int64 Time1970Left = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Left) == false) { return false; }
		Int64 Time1970Right = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time1970Right) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_MaxAndAvgOnlineCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_40_SQL_MaxAndAvgOnlineCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_41_SQL_FindNameByNameAlias(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		ViString NameAlias = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out NameAlias) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_FindNameByNameAlias(" + entity  + ", " + ServerID + ", " + NameAlias + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_41_SQL_FindNameByNameAlias;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameAlias);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_42_SQL_FindNameByNameAlias(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 ServerID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ServerID) == false) { return false; }
		List<ViString> NameAliasList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out NameAliasList) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SQL_FindNameByNameAlias(" + entity  + ", " + ServerID + ", " + NameAliasList + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_42_SQL_FindNameByNameAlias;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameAliasList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnUpdatePlayerBaseInfo(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<AccountWithPlayerProperty> List = default(List<AccountWithPlayerProperty>); if (ViGameSerializer<AccountWithPlayerProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdatePlayerBaseInfo(List);
		return true;
	}
	static bool Client_1_OnUpdatePlayerBaseInfo(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<PlayerWithAccountProperty> List = default(List<PlayerWithAccountProperty>); if (ViGameSerializer<PlayerWithAccountProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdatePlayerBaseInfo(List);
		return true;
	}
	static bool Client_2_OnUpdatePlayerDetail(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		PlayerGMViewProperty Property = default(PlayerGMViewProperty); if (ViGameSerializer<PlayerGMViewProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdatePlayerDetail(Property);
		return true;
	}
	static bool Client_3_OnUpdateServer(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		List<ServerViewProperty> List = default(List<ServerViewProperty>); if (ViGameSerializer<ServerViewProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateServer(Tag, List);
		return true;
	}
	static bool Client_4_OnSQLResult(GMAccount entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		List<ViString> Fields = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out Fields) == false) { return false; }
		List<ViString> Values = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out Values) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSQLResult(Tag, Fields, Values);
		return true;
	}
}
