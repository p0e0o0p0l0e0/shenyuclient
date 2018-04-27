using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameRecordCommandInvoker : ViEntityCommandInvoker<GameRecord>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".Note", Server_0_Note);
		AddFunc(".AddBoard", Server_1_AddBoard);
		AddFunc(".AddBoard", Server_2_AddBoard);
		AddFunc(".DelBoard", Server_3_DelBoard);
		AddFunc(".AddNote", Server_4_AddNote);
		AddFunc(".DelNote", Server_5_DelNote);
		AddFunc(".CloseClientSession", Server_6_CloseClientSession);
		AddFunc(".ResetActivityTime", Server_7_ResetActivityTime);
		AddFunc(".ActivityStart", Server_8_ActivityStart);
		AddFunc(".ActivityEnd", Server_9_ActivityEnd);
		AddFunc(".ActivityScriptStart", Server_10_ActivityScriptStart);
		AddFunc(".ActivityScriptStart", Server_11_ActivityScriptStart);
		AddFunc(".ActivityScriptEnd", Server_12_ActivityScriptEnd);
		AddFunc(".SaveEntitySQL", Server_13_SaveEntitySQL);
		AddFunc(".RemoveEntitySQL", Server_14_RemoveEntitySQL);
		AddFunc(".LoadEntitySQL", Server_15_LoadEntitySQL);
		AddFunc(".SaveAccountEntitySQL", Server_16_SaveAccountEntitySQL);
		AddFunc(".LoadAccountEntitySQL", Server_17_LoadAccountEntitySQL);
		AddFunc(".LoadPlayerEntitySQL", Server_18_LoadPlayerEntitySQL);
		AddFunc(".RemoveAccountEntitySQL", Server_19_RemoveAccountEntitySQL);
		AddFunc(".RemovePlayerEntitySQL", Server_20_RemovePlayerEntitySQL);
		AddFunc(".BroadcastMessagte", Server_21_BroadcastMessagte);
		AddFunc(".BroadcastMessagte", Server_22_BroadcastMessagte);
		AddFunc(".BroadcastMessagte", Server_23_BroadcastMessagte);
		AddFunc(".BroadcastMessagte", Server_24_BroadcastMessagte);
		AddFunc(".BroadcastDebugMessage", Server_25_BroadcastDebugMessage);
		AddFunc(".NewDay", Server_26_NewDay);
		AddFunc(".NewWeek", Server_27_NewWeek);
		AddFunc(".NewMonth", Server_28_NewMonth);
		AddFunc(".SetTimeScale", Server_29_SetTimeScale);
		AddFunc(".ExecTimeScript", Server_30_ExecTimeScript);
		AddFunc(".AddLoginCount", Server_31_AddLoginCount);
		AddFunc(".AddLoginCount", Server_32_AddLoginCount);
		AddFunc(".ResetDayLoopStatistics", Server_33_ResetDayLoopStatistics);
		AddFunc(".SaveFragment0", Server_34_SaveFragment0);
		AddFunc(".SaveFragment1", Server_35_SaveFragment1);
		AddFunc(".ClearOnlinePlayerList", Server_36_ClearOnlinePlayerList);
		AddFunc(".AddTimeLoop", Server_37_AddTimeLoop);
		AddFunc(".DelTimeLoop", Server_38_DelTimeLoop);
		AddFunc(".OnTimeLoop", Server_39_OnTimeLoop);
		AddFunc(".AddGMRecordTo", Server_40_AddGMRecordTo);
		AddFunc(".AddGMRecordTo", Server_41_AddGMRecordTo);
		AddFunc(".AddGMRecordToAll", Server_42_AddGMRecordToAll);
		AddFunc(".AddGMRecordToOnline", Server_43_AddGMRecordToOnline);
		AddFunc(".ClearDBCache", Server_44_ClearDBCache);
		AddFunc(".ExecCommandTo", Server_45_ExecCommandTo);
		AddFunc(".ExecCommandTo", Server_46_ExecCommandTo);
		AddFunc(".ExecCommandToAllOnline", Server_47_ExecCommandToAllOnline);
		AddFunc(".ExecCommandToAll", Server_48_ExecCommandToAll);
		AddFunc(".FindPlayerByID", Server_49_FindPlayerByID);
		AddFunc(".FindPlayerByName", Server_50_FindPlayerByName);
		AddFunc(".FindPlayerByAccountID", Server_51_FindPlayerByAccountID);
		AddFunc(".FindPlayerByAccountName", Server_52_FindPlayerByAccountName);
		AddFunc(".DisplayPlayer", Server_53_DisplayPlayer);
		AddFunc(".DisableIP", Server_54_DisableIP);
		AddFunc(".DisableIP", Server_55_DisableIP);
		AddFunc(".DisableIP", Server_56_DisableIP);
		AddFunc(".DisableIP", Server_57_DisableIP);
		AddFunc(".EnableIP", Server_58_EnableIP);
		AddFunc(".EnableIP", Server_59_EnableIP);
		AddFunc(".ClearDisableIP", Server_60_ClearDisableIP);
		AddFunc(".ClearIPLoginCD", Server_61_ClearIPLoginCD);
		AddFunc(".ClearIPLoginCD", Server_62_ClearIPLoginCD);
		AddFunc(".DisableAccount", Server_63_DisableAccount);
		AddFunc(".DisableAccount", Server_64_DisableAccount);
		AddFunc(".DisableAccount", Server_65_DisableAccount);
		AddFunc(".DisableAccount", Server_66_DisableAccount);
		AddFunc(".EnableAccount", Server_67_EnableAccount);
		AddFunc(".EnableAccount", Server_68_EnableAccount);
		AddFunc(".ClearDisableAccount", Server_69_ClearDisableAccount);
		AddFunc(".AddGameFuncClosed", Server_70_AddGameFuncClosed);
		AddFunc(".DelGameFuncClosed", Server_71_DelGameFuncClosed);
		AddFunc(".SetPlayerExecReqFunc", Server_72_SetPlayerExecReqFunc);
		AddFunc(".SetCellPlayerExecReqFunc", Server_73_SetCellPlayerExecReqFunc);
		AddFunc(".SetCellHeroExecReqFunc", Server_74_SetCellHeroExecReqFunc);
		AddFunc(".SetRPCGMLevel", Server_75_SetRPCGMLevel);
		AddFunc(".SetRPCCoolingDown", Server_76_SetRPCCoolingDown);
		AddFunc(".SetRPCParamConstraint", Server_77_SetRPCParamConstraint);
		AddFunc(".ClearRPCExecCount", Server_78_ClearRPCExecCount);
		AddFunc(".SetAccountGMLevel", Server_79_SetAccountGMLevel);
		AddFunc(".Exec", Server_80_Exec);
		AddFunc(".ExecDB", Server_81_ExecDB);
		AddFunc(".ExecBase", Server_82_ExecBase);
		AddFunc(".ExecGM", Server_83_ExecGM);
		AddFunc(".ExecGlobal", Server_84_ExecGlobal);
		AddFunc(".ExecCell", Server_85_ExecCell);
		AddFunc(".ExecCell", Server_86_ExecCell);
		AddFunc(".FindEntityPackID", Server_87_FindEntityPackID);
		AddFunc(".ClearMacAddress", Server_88_ClearMacAddress);
		AddFunc(".PingCell", Server_89_PingCell);
		AddFunc(".OnPingCell", Server_90_OnPingCell);
		AddFunc(".SetCellWeight", Server_91_SetCellWeight);
		AddFunc(".ExecSQL", Server_92_ExecSQL);
		AddFunc(".ExecSQL", Server_93_ExecSQL);
		AddFunc(".ExecSQL", Server_94_ExecSQL);
		AddFunc(".ResetConstValue", Server_95_ResetConstValue);
		AddFunc(".ResetGameData", Server_96_ResetGameData);
		AddFunc(".ResetGameData", Server_97_ResetGameData);
		AddFunc(".ResetGameData", Server_98_ResetGameData);
		AddFunc(".SetConstBool", Server_99_SetConstBool);
		AddFunc(".SetConstBools", Server_100_SetConstBools);
		AddFunc(".SetConstInt", Server_101_SetConstInt);
		AddFunc(".SetConstInts", Server_102_SetConstInts);
		AddFunc(".SetConstFloat", Server_103_SetConstFloat);
		AddFunc(".SetConstFloats", Server_104_SetConstFloats);
		AddFunc(".SetConstString", Server_105_SetConstString);
		AddFunc(".SetConstStrings", Server_106_SetConstStrings);
		AddFunc(".SetConstVector3", Server_107_SetConstVector3);
		AddFunc(".SetConstVector3s", Server_108_SetConstVector3s);
		AddFunc(".SetLogLevel", Server_109_SetLogLevel);
		AddFunc(".SetLogLevel", Server_110_SetLogLevel);
		AddFunc(".ResetReserveWord", Server_111_ResetReserveWord);
		AddFunc(".AddReserveWord", Server_112_AddReserveWord);
		AddFunc(".CreateBigSpace", Server_113_CreateBigSpace);
		AddFunc(".AddSpaceClosed", Server_114_AddSpaceClosed);
		AddFunc(".DelSpaceClosed", Server_115_DelSpaceClosed);
		AddFunc(".ClearSpaceClosed", Server_116_ClearSpaceClosed);
		AddFunc(".OnSmallSpaceUpdate", Server_117_OnSmallSpaceUpdate);
		AddFunc(".OnSmallSpaceResult", Server_118_OnSmallSpaceResult);
		AddFunc(".OnSmallSpaceClose", Server_119_OnSmallSpaceClose);
		AddFunc(".CloseSmallSpace", Server_120_CloseSmallSpace);
		AddFunc(".ResultSmallSpace", Server_121_ResultSmallSpace);
		AddFunc(".AddSpellClosed", Server_122_AddSpellClosed);
		AddFunc(".DelSpellClosed", Server_123_DelSpellClosed);
		AddFunc(".AddItemLocked", Server_124_AddItemLocked);
		AddFunc(".DelItemLocked", Server_125_DelItemLocked);
		AddFunc(".ClearItemLocked", Server_126_ClearItemLocked);
		AddFunc(".AddCDKey", Server_127_AddCDKey);
		AddFunc(".AddCDKey", Server_128_AddCDKey);
		AddFunc(".ClearCDKey", Server_129_ClearCDKey);
		AddFunc(".AddMail", Server_130_AddMail);
		AddFunc(".AddMail", Server_131_AddMail);
		AddFunc(".AddMail", Server_132_AddMail);
		AddFunc(".AddMailLoot", Server_133_AddMailLoot);
		AddFunc(".AddMailLoot", Server_134_AddMailLoot);
		AddFunc(".UpdateScoreRankVersion", Server_135_UpdateScoreRankVersion);
		AddFunc(".HTTP_Send", Server_136_HTTP_Send);
		AddFunc(".HTTP_Receive", Server_137_HTTP_Receive);
		AddFunc("/OnTimeScaleUpdated", Client_0_OnTimeScaleUpdated);
		AddFunc("/OnTimeBoard", Client_1_OnTimeBoard);
		AddFunc("/OnLoot", Client_2_OnLoot);
		AddFunc("/OnNote", Client_3_OnNote);
		AddFunc("/DebugMessage", Client_4_DebugMessage);
		AddFunc("/SetConstBool", Client_5_SetConstBool);
		AddFunc("/SetConstBools", Client_6_SetConstBools);
		AddFunc("/SetConstInt", Client_7_SetConstInt);
		AddFunc("/SetConstInts", Client_8_SetConstInts);
		AddFunc("/SetConstFloat", Client_9_SetConstFloat);
		AddFunc("/SetConstFloats", Client_10_SetConstFloats);
		AddFunc("/SetConstString", Client_11_SetConstString);
		AddFunc("/SetConstStrings", Client_12_SetConstStrings);
		AddFunc("/SetConstVector3", Client_13_SetConstVector3);
		AddFunc("/SetConstVector3s", Client_14_SetConstVector3s);
	}
	public static new bool Exec(GameRecord entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<GameRecord>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		GameRecord deriveEntity = entity as GameRecord;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void Note(GameRecord entity, ViString Desc)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_0_Note;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Note(" + entity  + ", " + Desc + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Desc);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddBoard(GameRecord entity, UInt8 Type, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_1_AddBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBoard(" + entity  + ", " + Type + ", " + Content + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddBoard(GameRecord entity, UInt8 Type, Int64 StartTime1970, Int64 Duration, Int64 Span, UInt8 Loop, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_2_AddBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBoard(" + entity  + ", " + Type + ", " + StartTime1970 + ", " + Duration + ", " + Span + ", " + Loop + ", " + Content + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, StartTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Span);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Loop);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelBoard(GameRecord entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_3_DelBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBoard(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNote(GameRecord entity, ViString Title, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_4_AddNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNote(" + entity  + ", " + Title + ", " + Content + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelNote(GameRecord entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_5_DelNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelNote(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CloseClientSession(GameRecord entity, ViString Desc)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_6_CloseClientSession;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseClientSession(" + entity  + ", " + Desc + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Desc);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetActivityTime(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_7_ResetActivityTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetActivityTime(" + entity  + ")");
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

	public static void ActivityStart(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_8_ActivityStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ActivityStart(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ActivityEnd(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_9_ActivityEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ActivityEnd(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ActivityScriptStart(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_10_ActivityScriptStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ActivityScriptStart(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ActivityScriptStart(GameRecord entity, UInt32 ID, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_11_ActivityScriptStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ActivityScriptStart(" + entity  + ", " + ID + ", " + Duration + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ActivityScriptEnd(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_12_ActivityScriptEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ActivityScriptEnd(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SaveEntitySQL(GameRecord entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_13_SaveEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SaveEntitySQL(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RemoveEntitySQL(GameRecord entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_14_RemoveEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RemoveEntitySQL(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void LoadEntitySQL(GameRecord entity, ViString Type, UInt64 ID, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_15_LoadEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LoadEntitySQL(" + entity  + ", " + Type + ", " + ID + ", " + Name + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Type);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SaveAccountEntitySQL(GameRecord entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_16_SaveAccountEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SaveAccountEntitySQL(" + entity  + ", " + Name + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void LoadAccountEntitySQL(GameRecord entity, UInt64 ID, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_17_LoadAccountEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LoadAccountEntitySQL(" + entity  + ", " + ID + ", " + Name + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void LoadPlayerEntitySQL(GameRecord entity, UInt64 ID, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_18_LoadPlayerEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LoadPlayerEntitySQL(" + entity  + ", " + ID + ", " + Name + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RemoveAccountEntitySQL(GameRecord entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_19_RemoveAccountEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RemoveAccountEntitySQL(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RemovePlayerEntitySQL(GameRecord entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_20_RemovePlayerEntitySQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RemovePlayerEntitySQL(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BroadcastMessagte(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_21_BroadcastMessagte;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BroadcastMessagte(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BroadcastMessagte(GameRecord entity, UInt32 ID, ViString Param0)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_22_BroadcastMessagte;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BroadcastMessagte(" + entity  + ", " + ID + ", " + Param0 + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param0);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BroadcastMessagte(GameRecord entity, UInt32 ID, ViString Param0, ViString Param1)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_23_BroadcastMessagte;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BroadcastMessagte(" + entity  + ", " + ID + ", " + Param0 + ", " + Param1 + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param0);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param1);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BroadcastMessagte(GameRecord entity, UInt32 ID, ViString Param0, ViString Param1, ViString Param2)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_24_BroadcastMessagte;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BroadcastMessagte(" + entity  + ", " + ID + ", " + Param0 + ", " + Param1 + ", " + Param2 + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param0);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param1);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param2);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BroadcastDebugMessage(GameRecord entity, ViString Title, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_25_BroadcastDebugMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BroadcastDebugMessage(" + entity  + ", " + Title + ", " + Content + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void NewDay(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_26_NewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> NewDay(" + entity  + ")");
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

	public static void NewWeek(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_27_NewWeek;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> NewWeek(" + entity  + ")");
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

	public static void NewMonth(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_28_NewMonth;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> NewMonth(" + entity  + ")");
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

	public static void SetTimeScale(GameRecord entity, float Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_29_SetTimeScale;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetTimeScale(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecTimeScript(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_30_ExecTimeScript;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecTimeScript(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddLoginCount(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_31_AddLoginCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddLoginCount(" + entity  + ")");
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

	public static void AddLoginCount(GameRecord entity, Int32 OldDayNumber, Int32 NewDayNumber)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_32_AddLoginCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddLoginCount(" + entity  + ", " + OldDayNumber + ", " + NewDayNumber + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, OldDayNumber);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, NewDayNumber);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetDayLoopStatistics(GameRecord entity, Int32 OldDayNumber, Int32 NewDayNumber)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_33_ResetDayLoopStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetDayLoopStatistics(" + entity  + ", " + OldDayNumber + ", " + NewDayNumber + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, OldDayNumber);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, NewDayNumber);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SaveFragment0(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_34_SaveFragment0;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SaveFragment0(" + entity  + ")");
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

	public static void SaveFragment1(GameRecord entity, ViString Note)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_35_SaveFragment1;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SaveFragment1(" + entity  + ", " + Note + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearOnlinePlayerList(GameRecord entity, UInt32 Number)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_36_ClearOnlinePlayerList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOnlinePlayerList(" + entity  + ", " + Number + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Number);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddTimeLoop(GameRecord entity, ViString Name, UInt8 DateLoop, UInt32 DateID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_37_AddTimeLoop;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddTimeLoop(" + entity  + ", " + Name + ", " + DateLoop + ", " + DateID + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, DateLoop);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, DateID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelTimeLoop(GameRecord entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_38_DelTimeLoop;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelTimeLoop(" + entity  + ", " + Name + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnTimeLoop(GameRecord entity, UInt8 DateLoop, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_39_OnTimeLoop;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnTimeLoop(" + entity  + ", " + DateLoop + ", " + Duration + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, DateLoop);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGMRecordTo(GameRecord entity, ViString Player, ViString Requestor, ViString Comfirmer, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_40_AddGMRecordTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGMRecordTo(" + entity  + ", " + Player + ", " + Requestor + ", " + Comfirmer + ", " + Func + ", " + Params + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Player);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGMRecordTo(GameRecord entity, UInt64 Player, ViString Requestor, ViString Comfirmer, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_41_AddGMRecordTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGMRecordTo(" + entity  + ", " + Player + ", " + Requestor + ", " + Comfirmer + ", " + Func + ", " + Params + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGMRecordToAll(GameRecord entity, ViString Requestor, ViString Comfirmer, GMRequestProperty Request, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_42_AddGMRecordToAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGMRecordToAll(" + entity  + ", " + Requestor + ", " + Comfirmer + ", " + Request + ", " + Func + ", " + Params + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGMRecordToOnline(GameRecord entity, ViString Requestor, ViString Comfirmer, GMRequestProperty Request, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_43_AddGMRecordToOnline;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGMRecordToOnline(" + entity  + ", " + Requestor + ", " + Comfirmer + ", " + Request + ", " + Func + ", " + Params + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearDBCache(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_44_ClearDBCache;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDBCache(" + entity  + ")");
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

	public static void ExecCommandTo(GameRecord entity, ViString Player)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_45_ExecCommandTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecCommandTo(" + entity  + ", " + Player + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Player);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecCommandTo(GameRecord entity, UInt64 Player)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_46_ExecCommandTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecCommandTo(" + entity  + ", " + Player + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecCommandToAllOnline(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_47_ExecCommandToAllOnline;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecCommandToAllOnline(" + entity  + ")");
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

	public static void ExecCommandToAll(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_48_ExecCommandToAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecCommandToAll(" + entity  + ")");
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

	public static void FindPlayerByID(GameRecord entity, UInt64 ID, UInt64 CallbackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_49_FindPlayerByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByID(" + entity  + ", " + ID + ", " + CallbackID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByName(GameRecord entity, ViString Name, UInt64 CallbackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_50_FindPlayerByName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByName(" + entity  + ", " + Name + ", " + CallbackID + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByAccountID(GameRecord entity, UInt64 ID, UInt64 CallbackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_51_FindPlayerByAccountID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByAccountID(" + entity  + ", " + ID + ", " + CallbackID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByAccountName(GameRecord entity, ViString Name, UInt64 CallbackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_52_FindPlayerByAccountName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByAccountName(" + entity  + ", " + Name + ", " + CallbackID + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisplayPlayer(GameRecord entity, UInt64 ID, UInt64 CallbackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_53_DisplayPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisplayPlayer(" + entity  + ", " + ID + ", " + CallbackID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableIP(GameRecord entity, ViString Address, ViString Note)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_54_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + Address + ", " + Note + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Address);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableIP(GameRecord entity, List<DisableRecordProperty> AddressList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_55_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + AddressList + ")");
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
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableIP(GameRecord entity, ViString Address, ViString Note, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_56_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + Address + ", " + Note + ", " + Duration + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Address);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableIP(GameRecord entity, List<DisableRecordProperty> AddressList, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_57_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + AddressList + ", " + Duration + ")");
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
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnableIP(GameRecord entity, ViString Address)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_58_EnableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableIP(" + entity  + ", " + Address + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Address);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnableIP(GameRecord entity, List<ViString> AddressList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_59_EnableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableIP(" + entity  + ", " + AddressList + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearDisableIP(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_60_ClearDisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDisableIP(" + entity  + ")");
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

	public static void ClearIPLoginCD(GameRecord entity, ViString IP)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_61_ClearIPLoginCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearIPLoginCD(" + entity  + ", " + IP + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, IP);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearIPLoginCD(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_62_ClearIPLoginCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearIPLoginCD(" + entity  + ")");
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

	public static void DisableAccount(GameRecord entity, ViString Account, ViString Note)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_63_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + Account + ", " + Note + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Account);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableAccount(GameRecord entity, List<DisableRecordProperty> AccountList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_64_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + AccountList + ")");
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
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableAccount(GameRecord entity, ViString Account, ViString Note, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_65_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + Account + ", " + Note + ", " + Duration + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Account);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableAccount(GameRecord entity, List<DisableRecordProperty> AccountList, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_66_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + AccountList + ", " + Duration + ")");
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
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnableAccount(GameRecord entity, ViString Account)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_67_EnableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableAccount(" + entity  + ", " + Account + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Account);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnableAccount(GameRecord entity, List<ViString> AccountList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_68_EnableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableAccount(" + entity  + ", " + AccountList + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearDisableAccount(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_69_ClearDisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDisableAccount(" + entity  + ")");
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

	public static void AddGameFuncClosed(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_70_AddGameFuncClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGameFuncClosed(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelGameFuncClosed(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_71_DelGameFuncClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGameFuncClosed(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPlayerExecReqFunc(GameRecord entity, UInt16 Func, UInt32 GameFunc)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_72_SetPlayerExecReqFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPlayerExecReqFunc(" + entity  + ", " + Func + ", " + GameFunc + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Func);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFunc);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetCellPlayerExecReqFunc(GameRecord entity, UInt16 Func, UInt32 GameFunc)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_73_SetCellPlayerExecReqFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetCellPlayerExecReqFunc(" + entity  + ", " + Func + ", " + GameFunc + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Func);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFunc);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetCellHeroExecReqFunc(GameRecord entity, UInt16 Func, UInt32 GameFunc)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_74_SetCellHeroExecReqFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetCellHeroExecReqFunc(" + entity  + ", " + Func + ", " + GameFunc + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Func);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFunc);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetRPCGMLevel(GameRecord entity, ViString Name, Int32 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_75_SetRPCGMLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetRPCGMLevel(" + entity  + ", " + Name + ", " + Level + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetRPCCoolingDown(GameRecord entity, ViString Name, UInt32 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_76_SetRPCCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetRPCCoolingDown(" + entity  + ", " + Name + ", " + Idx + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetRPCParamConstraint(GameRecord entity, ViString Name, ViString Inf, ViString Sup)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_77_SetRPCParamConstraint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetRPCParamConstraint(" + entity  + ", " + Name + ", " + Inf + ", " + Sup + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Inf);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Sup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearRPCExecCount(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_78_ClearRPCExecCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearRPCExecCount(" + entity  + ")");
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

	public static void SetAccountGMLevel(GameRecord entity, UInt8 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_79_SetAccountGMLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetAccountGMLevel(" + entity  + ", " + Level + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void Exec(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_80_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecDB(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_81_ExecDB;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecDB(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecBase(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_82_ExecBase;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecBase(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecGM(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_83_ExecGM;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecGM(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecGlobal(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_84_ExecGlobal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecGlobal(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecCell(GameRecord entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_85_ExecCell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecCell(" + entity  + ", " + Script + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecCell(GameRecord entity, UInt8 CellID, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_86_ExecCell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecCell(" + entity  + ", " + CellID + ", " + Script + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, CellID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindEntityPackID(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_87_FindEntityPackID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindEntityPackID(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearMacAddress(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_88_ClearMacAddress;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearMacAddress(" + entity  + ")");
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

	public static void PingCell(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_89_PingCell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PingCell(" + entity  + ")");
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

	public static void OnPingCell(GameRecord entity, UInt16 CellID, Int64 Time)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_90_OnPingCell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnPingCell(" + entity  + ", " + CellID + ", " + Time + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, CellID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetCellWeight(GameRecord entity, UInt16 CellID, Int64 Weight)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_91_SetCellWeight;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetCellWeight(" + entity  + ", " + CellID + ", " + Weight + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, CellID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Weight);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecSQL(GameRecord entity, ViString SQL)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_92_ExecSQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecSQL(" + entity  + ", " + SQL + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, SQL);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecSQL(GameRecord entity, ViString SQL, UInt64 CallbackID, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_93_ExecSQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecSQL(" + entity  + ", " + SQL + ", " + CallbackID + ", " + Tag + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, SQL);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecSQL(GameRecord entity, List<ViString> SQLList, UInt64 CallbackID, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_94_ExecSQL;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecSQL(" + entity  + ", " + SQLList + ", " + CallbackID + ", " + Tag + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, SQLList);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetConstValue(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_95_ResetConstValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetConstValue(" + entity  + ")");
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

	public static void ResetGameData(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_96_ResetGameData;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetGameData(" + entity  + ")");
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

	public static void ResetGameData(GameRecord entity, UInt8 Override)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_97_ResetGameData;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetGameData(" + entity  + ", " + Override + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Override);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetGameData(GameRecord entity, ViString Name, UInt8 Override)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_98_ResetGameData;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetGameData(" + entity  + ", " + Name + ", " + Override + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Override);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstBool(GameRecord entity, ViString Name, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_99_SetConstBool;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstBool(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstBools(GameRecord entity, ViString Name, List<UInt8> Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_100_SetConstBools;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstBools(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstInt(GameRecord entity, ViString Name, Int32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_101_SetConstInt;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstInt(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstInts(GameRecord entity, ViString Name, List<Int32> Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_102_SetConstInts;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstInts(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstFloat(GameRecord entity, ViString Name, float Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_103_SetConstFloat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstFloat(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstFloats(GameRecord entity, ViString Name, List<float> Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_104_SetConstFloats;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstFloats(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstString(GameRecord entity, ViString Name, ViString Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_105_SetConstString;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstString(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstStrings(GameRecord entity, ViString Name, List<ViString> Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_106_SetConstStrings;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstStrings(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstVector3(GameRecord entity, ViString Name, ViVector3 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_107_SetConstVector3;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstVector3(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetConstVector3s(GameRecord entity, ViString Name, List<ViVector3> Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_108_SetConstVector3s;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetConstVector3s(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetLogLevel(GameRecord entity, Int32 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_109_SetLogLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetLogLevel(" + entity  + ", " + Level + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetLogLevel(GameRecord entity, ViString Name, Int32 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_110_SetLogLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetLogLevel(" + entity  + ", " + Name + ", " + Level + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetReserveWord(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_111_ResetReserveWord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetReserveWord(" + entity  + ")");
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

	public static void AddReserveWord(GameRecord entity, ViString Word)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_112_AddReserveWord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddReserveWord(" + entity  + ", " + Word + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Word);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CreateBigSpace(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_113_CreateBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateBigSpace(" + entity  + ")");
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

	public static void AddSpaceClosed(GameRecord entity, UInt32 ID, UInt8 Break)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_114_AddSpaceClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceClosed(" + entity  + ", " + ID + ", " + Break + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Break);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelSpaceClosed(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_115_DelSpaceClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSpaceClosed(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearSpaceClosed(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_116_ClearSpaceClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearSpaceClosed(" + entity  + ")");
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

	public static void OnSmallSpaceUpdate(GameRecord entity, UInt64 ID, double Progress, Int64 EndTime, List<SpacePlayerMemberProperty> MemberList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_117_OnSmallSpaceUpdate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceUpdate(" + entity  + ", " + ID + ", " + Progress + ", " + EndTime + ", " + MemberList + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<double>.Append(entity.RPC.OS, Progress);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, EndTime);
		ViGameSerializer<SpacePlayerMemberProperty>.Append(entity.RPC.OS, MemberList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpaceResult(GameRecord entity, UInt64 ID, UInt8 Result)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_118_OnSmallSpaceResult;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceResult(" + entity  + ", " + ID + ", " + Result + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpaceClose(GameRecord entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_119_OnSmallSpaceClose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceClose(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CloseSmallSpace(GameRecord entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_120_CloseSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseSmallSpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResultSmallSpace(GameRecord entity, UInt64 ID, UInt8 Result, UInt8 Asyn)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_121_ResultSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResultSmallSpace(" + entity  + ", " + ID + ", " + Result + ", " + Asyn + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Asyn);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSpellClosed(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_122_AddSpellClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpellClosed(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelSpellClosed(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_123_DelSpellClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSpellClosed(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItemLocked(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_124_AddItemLocked;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemLocked(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelItemLocked(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_125_DelItemLocked;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelItemLocked(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemLocked(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_126_ClearItemLocked;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemLocked(" + entity  + ")");
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

	public static void AddCDKey(GameRecord entity, ViString Key)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_127_AddCDKey;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddCDKey(" + entity  + ", " + Key + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Key);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddCDKey(GameRecord entity, List<ViString> List)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_128_AddCDKey;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddCDKey(" + entity  + ", " + List + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearCDKey(GameRecord entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_129_ClearCDKey;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearCDKey(" + entity  + ")");
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

	public static void AddMail(GameRecord entity, List<UInt64> PlayerList, MailProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_130_AddMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMail(" + entity  + ", " + PlayerList + ", " + Property + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddMail(GameRecord entity, UInt8 Range, GMRequestProperty Request, MailProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_131_AddMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMail(" + entity  + ", " + Range + ", " + Request + ", " + Property + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Range);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddMail(GameRecord entity, UInt64 Player, MailProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_132_AddMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMail(" + entity  + ", " + Player + ", " + Property + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddMailLoot(GameRecord entity, UInt64 Player, MailProperty MailHead, UInt32 Loot, Int16 Level, Int16 PlayerLevel, float Scale)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_133_AddMailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMailLoot(" + entity  + ", " + Player + ", " + MailHead + ", " + Loot + ", " + Level + ", " + PlayerLevel + ", " + Scale + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, MailHead);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, PlayerLevel);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddMailLoot(GameRecord entity, List<UInt64> PlayerList, MailProperty MailHead, Int16 Level, Int16 PlayerLevel, float Scale)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_134_AddMailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMailLoot(" + entity  + ", " + PlayerList + ", " + MailHead + ", " + Level + ", " + PlayerLevel + ", " + Scale + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, MailHead);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, PlayerLevel);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateScoreRankVersion(GameRecord entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_135_UpdateScoreRankVersion;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateScoreRankVersion(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void HTTP_Send(GameRecord entity, ViString Receiver, ViString Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_136_HTTP_Send;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> HTTP_Send(" + entity  + ", " + Receiver + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void HTTP_Receive(GameRecord entity, ViString Sender, ViString Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_137_HTTP_Receive;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> HTTP_Receive(" + entity  + ", " + Sender + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Sender);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_Note(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Desc = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Desc) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Note(" + entity  + ", " + Desc + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_0_Note;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Desc);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_AddBoard(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Type = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Type) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddBoard(" + entity  + ", " + Type + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_1_AddBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_AddBoard(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Type = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Type) == false) { return false; }
		Int64 StartTime1970 = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out StartTime1970) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		Int64 Span = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Span) == false) { return false; }
		UInt8 Loop = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Loop) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddBoard(" + entity  + ", " + Type + ", " + StartTime1970 + ", " + Duration + ", " + Span + ", " + Loop + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_2_AddBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, StartTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Span);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Loop);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_DelBoard(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelBoard(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_3_DelBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_AddNote(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNote(" + entity  + ", " + Title + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_4_AddNote;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_DelNote(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelNote(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_5_DelNote;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_CloseClientSession(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Desc = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Desc) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseClientSession(" + entity  + ", " + Desc + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_6_CloseClientSession;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Desc);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_ResetActivityTime(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetActivityTime(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_7_ResetActivityTime;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_ActivityStart(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ActivityStart(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_8_ActivityStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_ActivityEnd(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ActivityEnd(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_9_ActivityEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_ActivityScriptStart(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ActivityScriptStart(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_10_ActivityScriptStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_ActivityScriptStart(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ActivityScriptStart(" + entity  + ", " + ID + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_11_ActivityScriptStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_ActivityScriptEnd(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ActivityScriptEnd(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_12_ActivityScriptEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_SaveEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SaveEntitySQL(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_13_SaveEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_RemoveEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RemoveEntitySQL(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_14_RemoveEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_LoadEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Type = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Type) == false) { return false; }
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> LoadEntitySQL(" + entity  + ", " + Type + ", " + ID + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_15_LoadEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Type);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_SaveAccountEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SaveAccountEntitySQL(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_16_SaveAccountEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_LoadAccountEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> LoadAccountEntitySQL(" + entity  + ", " + ID + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_17_LoadAccountEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_LoadPlayerEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> LoadPlayerEntitySQL(" + entity  + ", " + ID + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_18_LoadPlayerEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_19_RemoveAccountEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RemoveAccountEntitySQL(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_19_RemoveAccountEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_20_RemovePlayerEntitySQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RemovePlayerEntitySQL(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_20_RemovePlayerEntitySQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_21_BroadcastMessagte(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BroadcastMessagte(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_21_BroadcastMessagte;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_22_BroadcastMessagte(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViString Param0 = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param0) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BroadcastMessagte(" + entity  + ", " + ID + ", " + Param0 + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_22_BroadcastMessagte;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param0);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_23_BroadcastMessagte(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViString Param0 = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param0) == false) { return false; }
		ViString Param1 = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param1) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BroadcastMessagte(" + entity  + ", " + ID + ", " + Param0 + ", " + Param1 + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_23_BroadcastMessagte;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param0);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param1);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_24_BroadcastMessagte(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViString Param0 = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param0) == false) { return false; }
		ViString Param1 = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param1) == false) { return false; }
		ViString Param2 = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param2) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BroadcastMessagte(" + entity  + ", " + ID + ", " + Param0 + ", " + Param1 + ", " + Param2 + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_24_BroadcastMessagte;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param0);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param1);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param2);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_25_BroadcastDebugMessage(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BroadcastDebugMessage(" + entity  + ", " + Title + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_25_BroadcastDebugMessage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_26_NewDay(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> NewDay(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_26_NewDay;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_27_NewWeek(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> NewWeek(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_27_NewWeek;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_28_NewMonth(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> NewMonth(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_28_NewMonth;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_29_SetTimeScale(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Value = default(float); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetTimeScale(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_29_SetTimeScale;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_30_ExecTimeScript(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecTimeScript(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_30_ExecTimeScript;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_31_AddLoginCount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddLoginCount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_31_AddLoginCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_32_AddLoginCount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 OldDayNumber = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out OldDayNumber) == false) { return false; }
		Int32 NewDayNumber = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out NewDayNumber) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddLoginCount(" + entity  + ", " + OldDayNumber + ", " + NewDayNumber + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_32_AddLoginCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, OldDayNumber);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, NewDayNumber);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_33_ResetDayLoopStatistics(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 OldDayNumber = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out OldDayNumber) == false) { return false; }
		Int32 NewDayNumber = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out NewDayNumber) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetDayLoopStatistics(" + entity  + ", " + OldDayNumber + ", " + NewDayNumber + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_33_ResetDayLoopStatistics;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, OldDayNumber);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, NewDayNumber);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_34_SaveFragment0(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SaveFragment0(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_34_SaveFragment0;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_35_SaveFragment1(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SaveFragment1(" + entity  + ", " + Note + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_35_SaveFragment1;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_36_ClearOnlinePlayerList(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Number = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Number) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearOnlinePlayerList(" + entity  + ", " + Number + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_36_ClearOnlinePlayerList;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Number);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_37_AddTimeLoop(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt8 DateLoop = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out DateLoop) == false) { return false; }
		UInt32 DateID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out DateID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddTimeLoop(" + entity  + ", " + Name + ", " + DateLoop + ", " + DateID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_37_AddTimeLoop;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, DateLoop);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, DateID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_38_DelTimeLoop(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelTimeLoop(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_38_DelTimeLoop;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_39_OnTimeLoop(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 DateLoop = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out DateLoop) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnTimeLoop(" + entity  + ", " + DateLoop + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_39_OnTimeLoop;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, DateLoop);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_40_AddGMRecordTo(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Player = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Player) == false) { return false; }
		ViString Requestor = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Requestor) == false) { return false; }
		ViString Comfirmer = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Comfirmer) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGMRecordTo(" + entity  + ", " + Player + ", " + Requestor + ", " + Comfirmer + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_40_AddGMRecordTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Player);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_41_AddGMRecordTo(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Player = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Player) == false) { return false; }
		ViString Requestor = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Requestor) == false) { return false; }
		ViString Comfirmer = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Comfirmer) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGMRecordTo(" + entity  + ", " + Player + ", " + Requestor + ", " + Comfirmer + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_41_AddGMRecordTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_42_AddGMRecordToAll(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Requestor = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Requestor) == false) { return false; }
		ViString Comfirmer = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Comfirmer) == false) { return false; }
		GMRequestProperty Request = default(GMRequestProperty); if (ViGameSerializer<GMRequestProperty>.Read(IS, out Request) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGMRecordToAll(" + entity  + ", " + Requestor + ", " + Comfirmer + ", " + Request + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_42_AddGMRecordToAll;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_43_AddGMRecordToOnline(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Requestor = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Requestor) == false) { return false; }
		ViString Comfirmer = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Comfirmer) == false) { return false; }
		GMRequestProperty Request = default(GMRequestProperty); if (ViGameSerializer<GMRequestProperty>.Read(IS, out Request) == false) { return false; }
		ViString Func = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Func) == false) { return false; }
		ViString Params = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Params) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGMRecordToOnline(" + entity  + ", " + Requestor + ", " + Comfirmer + ", " + Request + ", " + Func + ", " + Params + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_43_AddGMRecordToOnline;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Requestor);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Comfirmer);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_44_ClearDBCache(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearDBCache(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_44_ClearDBCache;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_45_ExecCommandTo(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Player = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Player) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecCommandTo(" + entity  + ", " + Player + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_45_ExecCommandTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Player);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_46_ExecCommandTo(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Player = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Player) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecCommandTo(" + entity  + ", " + Player + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_46_ExecCommandTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_47_ExecCommandToAllOnline(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecCommandToAllOnline(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_47_ExecCommandToAllOnline;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_48_ExecCommandToAll(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecCommandToAll(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_48_ExecCommandToAll;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_49_FindPlayerByID(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByID(" + entity  + ", " + ID + ", " + CallbackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_49_FindPlayerByID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_50_FindPlayerByName(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByName(" + entity  + ", " + Name + ", " + CallbackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_50_FindPlayerByName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_51_FindPlayerByAccountID(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByAccountID(" + entity  + ", " + ID + ", " + CallbackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_51_FindPlayerByAccountID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_52_FindPlayerByAccountName(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindPlayerByAccountName(" + entity  + ", " + Name + ", " + CallbackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_52_FindPlayerByAccountName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_53_DisplayPlayer(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisplayPlayer(" + entity  + ", " + ID + ", " + CallbackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_53_DisplayPlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_54_DisableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Address = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Address) == false) { return false; }
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableIP(" + entity  + ", " + Address + ", " + Note + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_54_DisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Address);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_55_DisableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<DisableRecordProperty> AddressList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AddressList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableIP(" + entity  + ", " + AddressList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_55_DisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_56_DisableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Address = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Address) == false) { return false; }
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableIP(" + entity  + ", " + Address + ", " + Note + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_56_DisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Address);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_57_DisableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<DisableRecordProperty> AddressList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AddressList) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableIP(" + entity  + ", " + AddressList + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_57_DisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_58_EnableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Address = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Address) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnableIP(" + entity  + ", " + Address + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_58_EnableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Address);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_59_EnableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViString> AddressList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out AddressList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnableIP(" + entity  + ", " + AddressList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_59_EnableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_60_ClearDisableIP(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearDisableIP(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_60_ClearDisableIP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_61_ClearIPLoginCD(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString IP = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out IP) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearIPLoginCD(" + entity  + ", " + IP + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_61_ClearIPLoginCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, IP);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_62_ClearIPLoginCD(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearIPLoginCD(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_62_ClearIPLoginCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_63_DisableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Account = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Account) == false) { return false; }
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableAccount(" + entity  + ", " + Account + ", " + Note + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_63_DisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Account);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_64_DisableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<DisableRecordProperty> AccountList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AccountList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableAccount(" + entity  + ", " + AccountList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_64_DisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_65_DisableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Account = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Account) == false) { return false; }
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableAccount(" + entity  + ", " + Account + ", " + Note + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_65_DisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Account);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_66_DisableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<DisableRecordProperty> AccountList = default(List<DisableRecordProperty>); if (ViGameSerializer<DisableRecordProperty>.Read(IS, out AccountList) == false) { return false; }
		Int64 Duration = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisableAccount(" + entity  + ", " + AccountList + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_66_DisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_67_EnableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Account = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Account) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnableAccount(" + entity  + ", " + Account + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_67_EnableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Account);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_68_EnableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViString> AccountList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out AccountList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnableAccount(" + entity  + ", " + AccountList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_68_EnableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_69_ClearDisableAccount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearDisableAccount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_69_ClearDisableAccount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_70_AddGameFuncClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGameFuncClosed(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_70_AddGameFuncClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_71_DelGameFuncClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelGameFuncClosed(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_71_DelGameFuncClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_72_SetPlayerExecReqFunc(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Func = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Func) == false) { return false; }
		UInt32 GameFunc = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GameFunc) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPlayerExecReqFunc(" + entity  + ", " + Func + ", " + GameFunc + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_72_SetPlayerExecReqFunc;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Func);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFunc);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_73_SetCellPlayerExecReqFunc(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Func = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Func) == false) { return false; }
		UInt32 GameFunc = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GameFunc) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetCellPlayerExecReqFunc(" + entity  + ", " + Func + ", " + GameFunc + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_73_SetCellPlayerExecReqFunc;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Func);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFunc);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_74_SetCellHeroExecReqFunc(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Func = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Func) == false) { return false; }
		UInt32 GameFunc = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GameFunc) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetCellHeroExecReqFunc(" + entity  + ", " + Func + ", " + GameFunc + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_74_SetCellHeroExecReqFunc;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Func);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFunc);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_75_SetRPCGMLevel(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Level = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetRPCGMLevel(" + entity  + ", " + Name + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_75_SetRPCGMLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_76_SetRPCCoolingDown(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt32 Idx = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetRPCCoolingDown(" + entity  + ", " + Name + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_76_SetRPCCoolingDown;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_77_SetRPCParamConstraint(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViString Inf = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Inf) == false) { return false; }
		ViString Sup = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Sup) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetRPCParamConstraint(" + entity  + ", " + Name + ", " + Inf + ", " + Sup + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_77_SetRPCParamConstraint;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Inf);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Sup);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_78_ClearRPCExecCount(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearRPCExecCount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_78_ClearRPCExecCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_79_SetAccountGMLevel(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Level = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetAccountGMLevel(" + entity  + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_79_SetAccountGMLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_80_Exec(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Exec(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_80_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_81_ExecDB(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecDB(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_81_ExecDB;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_82_ExecBase(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecBase(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_82_ExecBase;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_83_ExecGM(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecGM(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_83_ExecGM;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_84_ExecGlobal(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecGlobal(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_84_ExecGlobal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_85_ExecCell(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecCell(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_85_ExecCell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_86_ExecCell(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 CellID = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out CellID) == false) { return false; }
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecCell(" + entity  + ", " + CellID + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_86_ExecCell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, CellID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_87_FindEntityPackID(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FindEntityPackID(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_87_FindEntityPackID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_88_ClearMacAddress(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearMacAddress(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_88_ClearMacAddress;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_89_PingCell(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PingCell(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_89_PingCell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_90_OnPingCell(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 CellID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out CellID) == false) { return false; }
		Int64 Time = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnPingCell(" + entity  + ", " + CellID + ", " + Time + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_90_OnPingCell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, CellID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_91_SetCellWeight(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 CellID = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out CellID) == false) { return false; }
		Int64 Weight = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Weight) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetCellWeight(" + entity  + ", " + CellID + ", " + Weight + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_91_SetCellWeight;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, CellID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Weight);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_92_ExecSQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString SQL = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out SQL) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecSQL(" + entity  + ", " + SQL + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_92_ExecSQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, SQL);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_93_ExecSQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString SQL = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out SQL) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecSQL(" + entity  + ", " + SQL + ", " + CallbackID + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_93_ExecSQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, SQL);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_94_ExecSQL(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViString> SQLList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out SQLList) == false) { return false; }
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExecSQL(" + entity  + ", " + SQLList + ", " + CallbackID + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_94_ExecSQL;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, SQLList);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_95_ResetConstValue(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetConstValue(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_95_ResetConstValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_96_ResetGameData(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetGameData(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_96_ResetGameData;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_97_ResetGameData(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Override = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Override) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetGameData(" + entity  + ", " + Override + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_97_ResetGameData;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Override);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_98_ResetGameData(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt8 Override = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Override) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetGameData(" + entity  + ", " + Name + ", " + Override + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_98_ResetGameData;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Override);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_99_SetConstBool(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstBool(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_99_SetConstBool;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_100_SetConstBools(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<UInt8> Value = default(List<UInt8>); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstBools(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_100_SetConstBools;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_101_SetConstInt(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Value = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstInt(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_101_SetConstInt;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_102_SetConstInts(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<Int32> Value = default(List<Int32>); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstInts(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_102_SetConstInts;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_103_SetConstFloat(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		float Value = default(float); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstFloat(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_103_SetConstFloat;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_104_SetConstFloats(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<float> Value = default(List<float>); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstFloats(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_104_SetConstFloats;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_105_SetConstString(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstString(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_105_SetConstString;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_106_SetConstStrings(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<ViString> Value = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstStrings(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_106_SetConstStrings;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_107_SetConstVector3(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViVector3 Value = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstVector3(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_107_SetConstVector3;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_108_SetConstVector3s(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<ViVector3> Value = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetConstVector3s(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_108_SetConstVector3s;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_109_SetLogLevel(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 Level = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetLogLevel(" + entity  + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_109_SetLogLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_110_SetLogLevel(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Level = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetLogLevel(" + entity  + ", " + Name + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_110_SetLogLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_111_ResetReserveWord(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetReserveWord(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_111_ResetReserveWord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_112_AddReserveWord(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Word = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Word) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddReserveWord(" + entity  + ", " + Word + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_112_AddReserveWord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Word);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_113_CreateBigSpace(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreateBigSpace(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_113_CreateBigSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_114_AddSpaceClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 Break = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Break) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpaceClosed(" + entity  + ", " + ID + ", " + Break + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_114_AddSpaceClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Break);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_115_DelSpaceClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelSpaceClosed(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_115_DelSpaceClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_116_ClearSpaceClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearSpaceClosed(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_116_ClearSpaceClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_117_OnSmallSpaceUpdate(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		double Progress = default(double); if (ViGameSerializer<double>.Read(IS, out Progress) == false) { return false; }
		Int64 EndTime = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out EndTime) == false) { return false; }
		List<SpacePlayerMemberProperty> MemberList = default(List<SpacePlayerMemberProperty>); if (ViGameSerializer<SpacePlayerMemberProperty>.Read(IS, out MemberList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpaceUpdate(" + entity  + ", " + ID + ", " + Progress + ", " + EndTime + ", " + MemberList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_117_OnSmallSpaceUpdate;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<double>.Append(entity.RPC.OS, Progress);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, EndTime);
		ViGameSerializer<SpacePlayerMemberProperty>.Append(entity.RPC.OS, MemberList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_118_OnSmallSpaceResult(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt8 Result = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpaceResult(" + entity  + ", " + ID + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_118_OnSmallSpaceResult;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_119_OnSmallSpaceClose(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpaceClose(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_119_OnSmallSpaceClose;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_120_CloseSmallSpace(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseSmallSpace(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_120_CloseSmallSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_121_ResultSmallSpace(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt8 Result = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Result) == false) { return false; }
		UInt8 Asyn = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Asyn) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResultSmallSpace(" + entity  + ", " + ID + ", " + Result + ", " + Asyn + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_121_ResultSmallSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Asyn);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_122_AddSpellClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpellClosed(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_122_AddSpellClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_123_DelSpellClosed(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelSpellClosed(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_123_DelSpellClosed;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_124_AddItemLocked(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItemLocked(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_124_AddItemLocked;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_125_DelItemLocked(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelItemLocked(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_125_DelItemLocked;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_126_ClearItemLocked(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemLocked(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_126_ClearItemLocked;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_127_AddCDKey(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Key = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Key) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddCDKey(" + entity  + ", " + Key + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_127_AddCDKey;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Key);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_128_AddCDKey(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViString> List = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddCDKey(" + entity  + ", " + List + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_128_AddCDKey;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_129_ClearCDKey(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearCDKey(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_129_ClearCDKey;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_130_AddMail(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> PlayerList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out PlayerList) == false) { return false; }
		MailProperty Property = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddMail(" + entity  + ", " + PlayerList + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_130_AddMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_131_AddMail(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Range = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Range) == false) { return false; }
		GMRequestProperty Request = default(GMRequestProperty); if (ViGameSerializer<GMRequestProperty>.Read(IS, out Request) == false) { return false; }
		MailProperty Property = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddMail(" + entity  + ", " + Range + ", " + Request + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_131_AddMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Range);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_132_AddMail(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Player = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Player) == false) { return false; }
		MailProperty Property = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddMail(" + entity  + ", " + Player + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_132_AddMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_133_AddMailLoot(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Player = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Player) == false) { return false; }
		MailProperty MailHead = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out MailHead) == false) { return false; }
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		Int16 PlayerLevel = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out PlayerLevel) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddMailLoot(" + entity  + ", " + Player + ", " + MailHead + ", " + Loot + ", " + Level + ", " + PlayerLevel + ", " + Scale + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_133_AddMailLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Player);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, MailHead);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, PlayerLevel);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_134_AddMailLoot(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> PlayerList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out PlayerList) == false) { return false; }
		MailProperty MailHead = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out MailHead) == false) { return false; }
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		Int16 PlayerLevel = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out PlayerLevel) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddMailLoot(" + entity  + ", " + PlayerList + ", " + MailHead + ", " + Level + ", " + PlayerLevel + ", " + Scale + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_134_AddMailLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, MailHead);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, PlayerLevel);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_135_UpdateScoreRankVersion(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateScoreRankVersion(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_135_UpdateScoreRankVersion;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_136_HTTP_Send(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Receiver = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Receiver) == false) { return false; }
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> HTTP_Send(" + entity  + ", " + Receiver + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_136_HTTP_Send;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_137_HTTP_Receive(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Sender = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Sender) == false) { return false; }
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> HTTP_Receive(" + entity  + ", " + Sender + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameRecordServerMethod.METHOD_137_HTTP_Receive;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Sender);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnTimeScaleUpdated(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Value = default(float); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnTimeScaleUpdated(Value);
		return true;
	}
	static bool Client_1_OnTimeBoard(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Type = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Type) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnTimeBoard(Type, Content);
		return true;
	}
	static bool Client_2_OnLoot(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		PlayerIdentificationProperty Player = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Player) == false) { return false; }
		Int32 Loot = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Loot) == false) { return false; }
		List<ItemCountProperty> ItemList = default(List<ItemCountProperty>); if (ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLoot(Player, Loot, ItemList);
		return true;
	}
	static bool Client_3_OnNote(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnNote(Note);
		return true;
	}
	static bool Client_4_DebugMessage(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.DebugMessage(Title, Content);
		return true;
	}
	static bool Client_5_SetConstBool(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstBool(Name, Value);
		return true;
	}
	static bool Client_6_SetConstBools(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<UInt8> Value = default(List<UInt8>); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstBools(Name, Value);
		return true;
	}
	static bool Client_7_SetConstInt(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Value = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstInt(Name, Value);
		return true;
	}
	static bool Client_8_SetConstInts(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<Int32> Value = default(List<Int32>); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstInts(Name, Value);
		return true;
	}
	static bool Client_9_SetConstFloat(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		float Value = default(float); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstFloat(Name, Value);
		return true;
	}
	static bool Client_10_SetConstFloats(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<float> Value = default(List<float>); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstFloats(Name, Value);
		return true;
	}
	static bool Client_11_SetConstString(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstString(Name, Value);
		return true;
	}
	static bool Client_12_SetConstStrings(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<ViString> Value = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstStrings(Name, Value);
		return true;
	}
	static bool Client_13_SetConstVector3(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViVector3 Value = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstVector3(Name, Value);
		return true;
	}
	static bool Client_14_SetConstVector3s(GameRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		List<ViVector3> Value = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetConstVector3s(Name, Value);
		return true;
	}
}
