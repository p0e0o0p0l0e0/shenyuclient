using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellPlayerCommandInvoker : ViEntityCommandInvoker<CellPlayer>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".Exec", Server_0_Exec);
		AddFunc(".Exec", Server_1_Exec);
		AddFunc(".OnPing", Server_2_OnPing);
		AddFunc(".UpdatePropertyWatcher", Server_3_UpdatePropertyWatcher);
		AddFunc(".SetHoldCallback", Server_4_SetHoldCallback);
		AddFunc(".OnClientStart", Server_5_OnClientStart);
		AddFunc(".OnClientEnd", Server_6_OnClientEnd);
		AddFunc(".OnNewDay", Server_7_OnNewDay);
		AddFunc(".OnNewWeek", Server_8_OnNewWeek);
		AddFunc(".OnNewMonth", Server_9_OnNewMonth);
		AddFunc(".PrintProperty", Server_10_PrintProperty);
		AddFunc(".PrintCenterProperty", Server_11_PrintCenterProperty);
		AddFunc(".PrintCenterComponentProperty", Server_12_PrintCenterComponentProperty);
		AddFunc(".PrintHeroProperty", Server_13_PrintHeroProperty);
		AddFunc(".PrintSpaceProperty", Server_14_PrintSpaceProperty);
		AddFunc(".PrintSpaceFactionProperty", Server_15_PrintSpaceFactionProperty);
		AddFunc(".PrintNPCProperty", Server_16_PrintNPCProperty);
		AddFunc(".PrintGlobalProperty", Server_17_PrintGlobalProperty);
		AddFunc(".CopyPropertyFromFocus", Server_18_CopyPropertyFromFocus);
		AddFunc(".SpaceExec", Server_19_SpaceExec);
		AddFunc(".SpaceFactionExec", Server_20_SpaceFactionExec);
		AddFunc(".EnterPublicSpace", Server_21_EnterPublicSpace);
		AddFunc(".EnterPrivateSpace", Server_22_EnterPrivateSpace);
		AddFunc(".ExitSpace", Server_23_ExitSpace);
		AddFunc(".UpdateSpaceLoadProgress", Server_24_UpdateSpaceLoadProgress);
		AddFunc(".CompleteSpaceLoad", Server_25_CompleteSpaceLoad);
		AddFunc(".OnSpaceCloseByGM", Server_26_OnSpaceCloseByGM);
		AddFunc(".REQ_SpaceScriptEvent", Server_27_REQ_SpaceScriptEvent);
		AddFunc(".SpaceSpell", Server_28_SpaceSpell);
		AddFunc(".SpaceSpell", Server_29_SpaceSpell);
		AddFunc(".ChatScriptBegin", Server_30_ChatScriptBegin);
		AddFunc(".ChatScriptEnd", Server_31_ChatScriptEnd);
		AddFunc(".ChatScriptShowItem", Server_32_ChatScriptShowItem);
		AddFunc(".ChatScriptWatchItem", Server_33_ChatScriptWatchItem);
		AddFunc(".ChatMessage", Server_34_ChatMessage);
		AddFunc(".ChatMessage", Server_35_ChatMessage);
		AddFunc(".ClearHero", Server_36_ClearHero);
		AddFunc(".CreateHero", Server_37_CreateHero);
		AddFunc(".CompleteHeroLoad", Server_38_CompleteHeroLoad);
		AddFunc(".REQ_AddMoveSpeedScale", Server_39_REQ_AddMoveSpeedScale);
		AddFunc(".REQ_DelMoveSpeedScale", Server_40_REQ_DelMoveSpeedScale);
		AddFunc(".REQ_MoveTo", Server_41_REQ_MoveTo);
		AddFunc(".REQ_MoveTo", Server_42_REQ_MoveTo);
		AddFunc(".REQ_BreakMoveTo", Server_43_REQ_BreakMoveTo);
		AddFunc(".REQ_TransportTo", Server_44_REQ_TransportTo);
		AddFunc(".REQ_TransportTo", Server_45_REQ_TransportTo);
		AddFunc(".REQ_ShotStart", Server_46_REQ_ShotStart);
		AddFunc(".REQ_ShotEnd", Server_47_REQ_ShotEnd);
		AddFunc(".REQ_RecoverShot", Server_48_REQ_RecoverShot);
		AddFunc(".REQ_AddShotYaw", Server_49_REQ_AddShotYaw);
		AddFunc(".REQ_DelShotYaw", Server_50_REQ_DelShotYaw);
		AddFunc(".REQ_DoSpellByID", Server_51_REQ_DoSpellByID);
		AddFunc(".REQ_DoSpellByID", Server_52_REQ_DoSpellByID);
		AddFunc(".REQ_DoSpellByID", Server_53_REQ_DoSpellByID);
		AddFunc(".REQ_DoSpellByID", Server_54_REQ_DoSpellByID);
		AddFunc(".REQ_CancelSpell", Server_55_REQ_CancelSpell);
		AddFunc(".REQ_DoDash", Server_56_REQ_DoDash);
		AddFunc(".REQ_StartFocus", Server_57_REQ_StartFocus);
		AddFunc(".REQ_EndFocus", Server_58_REQ_EndFocus);
		AddFunc(".REQ_SetHeroYaw", Server_59_REQ_SetHeroYaw);
		AddFunc(".REQ_NavigateTo", Server_60_REQ_NavigateTo);
		AddFunc(".REQ_NavigateTo", Server_61_REQ_NavigateTo);
		AddFunc(".REQ_InteractWithObject", Server_62_REQ_InteractWithObject);
		AddFunc(".QuestAddNPC", Server_63_QuestAddNPC);
		AddFunc(".QuestDelNPC", Server_64_QuestDelNPC);
		AddFunc(".EnterStoryModel", Server_65_EnterStoryModel);
		AddFunc(".ExitStoryModel", Server_66_ExitStoryModel);
		AddFunc(".GetItems", Server_67_GetItems);
		AddFunc("/MessageBox", Client_0_MessageBox);
		AddFunc("/DebugMessage", Client_1_DebugMessage);
		AddFunc("/ContainReserveWord", Client_2_ContainReserveWord);
		AddFunc("/OnPing", Client_3_OnPing);
		AddFunc("/HoldHeroRes", Client_4_HoldHeroRes);
		AddFunc("/FreeHeroRes", Client_5_FreeHeroRes);
		AddFunc("/OnNavigateTo", Client_6_OnNavigateTo);
	}
	public static new bool Exec(CellPlayer entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<CellPlayer>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		CellPlayer deriveEntity = entity as CellPlayer;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void Exec(CellPlayer entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_0_Exec;
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
	public static void Exec(CellPlayer entity, ViString Script, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_0_Exec;
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

	public static void Exec(CellPlayer entity, ViString Script, ViString Param)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_1_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ", " + Param + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void Exec(CellPlayer entity, ViString Script, ViString Param, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_1_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ", " + Param + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnPing(CellPlayer entity, Int64 Time)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_2_OnPing;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnPing(" + entity  + ", " + Time + ")");
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
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnPing(CellPlayer entity, Int64 Time, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_2_OnPing;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnPing(" + entity  + ", " + Time + ")");
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
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdatePropertyWatcher(CellPlayer entity, UInt8 Immediate)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_3_UpdatePropertyWatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdatePropertyWatcher(" + entity  + ", " + Immediate + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Immediate);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdatePropertyWatcher(CellPlayer entity, UInt8 Immediate, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_3_UpdatePropertyWatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdatePropertyWatcher(" + entity  + ", " + Immediate + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Immediate);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetHoldCallback(CellPlayer entity, ViRPCResultExecer<UInt8> StartResult, ViRPCResultExecer<UInt8>.DeleOnResult StartResultRPCCallback, ViRPCResultExecer<UInt8> EndResult, ViRPCResultExecer<UInt8>.DeleOnResult EndResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_4_SetHoldCallback;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetHoldCallback(" + entity  + ", " + StartResult + ", " + EndResult + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(StartResult, StartResultRPCCallback));
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(EndResult, EndResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetHoldCallback(CellPlayer entity, ViRPCResultExecer<UInt8> StartResult, ViRPCResultExecer<UInt8>.DeleOnResult StartResultRPCCallback, ViRPCResultExecer<UInt8> EndResult, ViRPCResultExecer<UInt8>.DeleOnResult EndResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_4_SetHoldCallback;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetHoldCallback(" + entity  + ", " + StartResult + ", " + EndResult + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(StartResult, StartResultRPCCallback));
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(EndResult, EndResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnClientStart(CellPlayer entity, UInt32 ClientID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_5_OnClientStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnClientStart(" + entity  + ", " + ClientID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ClientID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnClientStart(CellPlayer entity, UInt32 ClientID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_5_OnClientStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnClientStart(" + entity  + ", " + ClientID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ClientID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnClientEnd(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_6_OnClientEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnClientEnd(" + entity  + ")");
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
	public static void OnClientEnd(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_6_OnClientEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnClientEnd(" + entity  + ")");
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

	public static void OnNewDay(CellPlayer entity, Int16 DeltaDay)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_7_OnNewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewDay(" + entity  + ", " + DeltaDay + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaDay);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnNewDay(CellPlayer entity, Int16 DeltaDay, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_7_OnNewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewDay(" + entity  + ", " + DeltaDay + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaDay);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnNewWeek(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_8_OnNewWeek;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewWeek(" + entity  + ")");
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
	public static void OnNewWeek(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_8_OnNewWeek;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewWeek(" + entity  + ")");
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

	public static void OnNewMonth(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_9_OnNewMonth;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewMonth(" + entity  + ")");
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
	public static void OnNewMonth(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_9_OnNewMonth;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewMonth(" + entity  + ")");
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

	public static void PrintProperty(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_10_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ")");
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
	public static void PrintProperty(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_10_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ")");
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

	public static void PrintCenterProperty(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_11_PrintCenterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintCenterProperty(" + entity  + ")");
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
	public static void PrintCenterProperty(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_11_PrintCenterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintCenterProperty(" + entity  + ")");
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

	public static void PrintCenterComponentProperty(CellPlayer entity, ViString Component)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_12_PrintCenterComponentProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintCenterComponentProperty(" + entity  + ", " + Component + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintCenterComponentProperty(CellPlayer entity, ViString Component, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_12_PrintCenterComponentProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintCenterComponentProperty(" + entity  + ", " + Component + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintHeroProperty(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_13_PrintHeroProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintHeroProperty(" + entity  + ")");
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
	public static void PrintHeroProperty(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_13_PrintHeroProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintHeroProperty(" + entity  + ")");
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

	public static void PrintSpaceProperty(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_14_PrintSpaceProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceProperty(" + entity  + ")");
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
	public static void PrintSpaceProperty(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_14_PrintSpaceProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceProperty(" + entity  + ")");
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

	public static void PrintSpaceFactionProperty(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_15_PrintSpaceFactionProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceFactionProperty(" + entity  + ")");
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
	public static void PrintSpaceFactionProperty(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_15_PrintSpaceFactionProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceFactionProperty(" + entity  + ")");
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

	public static void PrintNPCProperty(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_16_PrintNPCProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintNPCProperty(" + entity  + ")");
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
	public static void PrintNPCProperty(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_16_PrintNPCProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintNPCProperty(" + entity  + ")");
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

	public static void PrintGlobalProperty(CellPlayer entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_17_PrintGlobalProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
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
	public static void PrintGlobalProperty(CellPlayer entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_17_PrintGlobalProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
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

	public static void CopyPropertyFromFocus(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_18_CopyPropertyFromFocus;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyPropertyFromFocus(" + entity  + ")");
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
	public static void CopyPropertyFromFocus(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_18_CopyPropertyFromFocus;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyPropertyFromFocus(" + entity  + ")");
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

	public static void SpaceExec(CellPlayer entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_19_SpaceExec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceExec(" + entity  + ", " + Name + ")");
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
	public static void SpaceExec(CellPlayer entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_19_SpaceExec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceExec(" + entity  + ", " + Name + ")");
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

	public static void SpaceFactionExec(CellPlayer entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_20_SpaceFactionExec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceFactionExec(" + entity  + ", " + Name + ")");
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
	public static void SpaceFactionExec(CellPlayer entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_20_SpaceFactionExec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceFactionExec(" + entity  + ", " + Name + ")");
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

	public static void EnterPublicSpace(CellPlayer entity, UInt64 ID, ViVector3 Pos, float Yaw, UInt8 Faction, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_21_EnterPublicSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPublicSpace(" + entity  + ", " + ID + ", " + Pos + ", " + Yaw + ", " + Faction + ", " + Result + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterPublicSpace(CellPlayer entity, UInt64 ID, ViVector3 Pos, float Yaw, UInt8 Faction, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_21_EnterPublicSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPublicSpace(" + entity  + ", " + ID + ", " + Pos + ", " + Yaw + ", " + Faction + ", " + Result + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterPrivateSpace(CellPlayer entity, UInt32 Space, SpaceCreateProperty Property, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_22_EnterPrivateSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPrivateSpace(" + entity  + ", " + Space + ", " + Property + ", " + Result + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<SpaceCreateProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterPrivateSpace(CellPlayer entity, UInt32 Space, SpaceCreateProperty Property, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_22_EnterPrivateSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPrivateSpace(" + entity  + ", " + Space + ", " + Property + ", " + Result + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<SpaceCreateProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitSpace(CellPlayer entity, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_23_ExitSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitSpace(" + entity  + ", " + Result + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExitSpace(CellPlayer entity, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_23_ExitSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitSpace(" + entity  + ", " + Result + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSpaceCloseByGM(CellPlayer entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_26_OnSpaceCloseByGM;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSpaceCloseByGM(" + entity  + ", " + Space + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSpaceCloseByGM(CellPlayer entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_26_OnSpaceCloseByGM;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSpaceCloseByGM(" + entity  + ", " + Space + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SpaceSpell(CellPlayer entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_28_SpaceSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceSpell(" + entity  + ", " + ID + ")");
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
	public static void SpaceSpell(CellPlayer entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_28_SpaceSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceSpell(" + entity  + ", " + ID + ")");
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

	public static void SpaceSpell(CellPlayer entity, UInt32 ID, ViVector3 Pos)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_29_SpaceSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceSpell(" + entity  + ", " + ID + ", " + Pos + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SpaceSpell(CellPlayer entity, UInt32 ID, ViVector3 Pos, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_29_SpaceSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceSpell(" + entity  + ", " + ID + ", " + Pos + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptBegin(CellPlayer entity, UInt8 Channel)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_30_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + Channel + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatScriptBegin(CellPlayer entity, UInt8 Channel, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_30_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + Channel + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptEnd(CellPlayer entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_31_ChatScriptEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptEnd(" + entity  + ", " + Script + ")");
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
	public static void ChatScriptEnd(CellPlayer entity, ViString Script, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_31_ChatScriptEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptEnd(" + entity  + ", " + Script + ")");
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

	public static void ChatScriptShowItem(CellPlayer entity, ItemProperty Item)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_32_ChatScriptShowItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptShowItem(" + entity  + ", " + Item + ")");
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
		ViGameSerializer<ItemProperty>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatScriptShowItem(CellPlayer entity, ItemProperty Item, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_32_ChatScriptShowItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptShowItem(" + entity  + ", " + Item + ")");
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
		ViGameSerializer<ItemProperty>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptWatchItem(CellPlayer entity, UInt8 Channel, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_33_ChatScriptWatchItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptWatchItem(" + entity  + ", " + Channel + ", " + ID + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatScriptWatchItem(CellPlayer entity, UInt8 Channel, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_33_ChatScriptWatchItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptWatchItem(" + entity  + ", " + Channel + ", " + ID + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatMessage(CellPlayer entity, UInt8 Channel, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_34_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Channel + ", " + Content + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatMessage(CellPlayer entity, UInt8 Channel, ViString Content, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_34_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Channel + ", " + Content + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatMessage(CellPlayer entity, PlayerIdentificationProperty Name, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_35_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Name + ", " + Content + ")");
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
		ViGameSerializer<PlayerIdentificationProperty>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatMessage(CellPlayer entity, PlayerIdentificationProperty Name, ViString Content, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_35_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Name + ", " + Content + ")");
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
		ViGameSerializer<PlayerIdentificationProperty>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearHero(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_36_ClearHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHero(" + entity  + ")");
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
	public static void ClearHero(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_36_ClearHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHero(" + entity  + ")");
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

	public static void CreateHero(CellPlayer entity, HeroWorkingProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_37_CreateHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateHero(" + entity  + ", " + Property + ")");
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
		ViGameSerializer<HeroWorkingProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CreateHero(CellPlayer entity, HeroWorkingProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_37_CreateHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateHero(" + entity  + ", " + Property + ")");
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
		ViGameSerializer<HeroWorkingProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_TransportTo(CellPlayer entity, ViVector3 Pos)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_44_REQ_TransportTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_TransportTo(" + entity  + ", " + Pos + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_TransportTo(CellPlayer entity, ViVector3 Pos, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_44_REQ_TransportTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_TransportTo(" + entity  + ", " + Pos + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_TransportTo(CellPlayer entity, ViVector3 Pos, float Yaw)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_45_REQ_TransportTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_TransportTo(" + entity  + ", " + Pos + ", " + Yaw + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_TransportTo(CellPlayer entity, ViVector3 Pos, float Yaw, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_45_REQ_TransportTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_TransportTo(" + entity  + ", " + Pos + ", " + Yaw + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void QuestAddNPC(CellPlayer entity, UInt32 QuestID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_63_QuestAddNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> QuestAddNPC(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void QuestAddNPC(CellPlayer entity, UInt32 QuestID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_63_QuestAddNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> QuestAddNPC(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void QuestDelNPC(CellPlayer entity, UInt32 QuestID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_64_QuestDelNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> QuestDelNPC(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void QuestDelNPC(CellPlayer entity, UInt32 QuestID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_64_QuestDelNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> QuestDelNPC(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterStoryModel(CellPlayer entity, UInt32 QuestID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_65_EnterStoryModel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterStoryModel(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterStoryModel(CellPlayer entity, UInt32 QuestID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_65_EnterStoryModel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterStoryModel(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitStoryModel(CellPlayer entity, UInt32 QuestID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_66_ExitStoryModel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitStoryModel(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExitStoryModel(CellPlayer entity, UInt32 QuestID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_66_ExitStoryModel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitStoryModel(" + entity  + ", " + QuestID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void GetItems(CellPlayer entity, UInt32 ItemID, UInt32 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_67_GetItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GetItems(" + entity  + ", " + ItemID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ItemID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void GetItems(CellPlayer entity, UInt32 ItemID, UInt32 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_67_GetItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GetItems(" + entity  + ", " + ItemID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ItemID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_Exec(CellPlayer entity, List<string> paramList)
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
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_0_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_Exec(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViString Param = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Exec(" + entity  + ", " + Script + ", " + Param + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_1_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_OnPing(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Time = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnPing(" + entity  + ", " + Time + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_2_OnPing;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_UpdatePropertyWatcher(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Immediate = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Immediate) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdatePropertyWatcher(" + entity  + ", " + Immediate + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_3_UpdatePropertyWatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Immediate);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_SetHoldCallback(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViRPCCallback<UInt8> StartResult = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out StartResult) == false) { return false; }
		ViRPCCallback<UInt8> EndResult = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out EndResult) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetHoldCallback(" + entity  + ", " + StartResult + ", " + EndResult + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_4_SetHoldCallback;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, StartResult);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, EndResult);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_OnClientStart(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ClientID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ClientID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnClientStart(" + entity  + ", " + ClientID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_5_OnClientStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ClientID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_OnClientEnd(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnClientEnd(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_6_OnClientEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_OnNewDay(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaDay = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaDay) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewDay(" + entity  + ", " + DeltaDay + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_7_OnNewDay;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaDay);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_OnNewWeek(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewWeek(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_8_OnNewWeek;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_OnNewMonth(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewMonth(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_9_OnNewMonth;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_PrintProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_10_PrintProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_PrintCenterProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintCenterProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_11_PrintCenterProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_PrintCenterComponentProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Component = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Component) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintCenterComponentProperty(" + entity  + ", " + Component + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_12_PrintCenterComponentProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_PrintHeroProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintHeroProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_13_PrintHeroProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_PrintSpaceProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintSpaceProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_14_PrintSpaceProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_PrintSpaceFactionProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintSpaceFactionProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_15_PrintSpaceFactionProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_PrintNPCProperty(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintNPCProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_16_PrintNPCProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_PrintGlobalProperty(CellPlayer entity, List<string> paramList)
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
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_17_PrintGlobalProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_CopyPropertyFromFocus(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CopyPropertyFromFocus(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_18_CopyPropertyFromFocus;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_19_SpaceExec(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceExec(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_19_SpaceExec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_20_SpaceFactionExec(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceFactionExec(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_20_SpaceFactionExec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_21_EnterPublicSpace(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterPublicSpace(" + entity  + ", " + ID + ", " + Pos + ", " + Yaw + ", " + Faction + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_21_EnterPublicSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_22_EnterPrivateSpace(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		SpaceCreateProperty Property = default(SpaceCreateProperty); if (ViGameSerializer<SpaceCreateProperty>.Read(IS, out Property) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterPrivateSpace(" + entity  + ", " + Space + ", " + Property + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_22_EnterPrivateSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<SpaceCreateProperty>.Append(entity.RPC.OS, Property);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_23_ExitSpace(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitSpace(" + entity  + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_23_ExitSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_24_UpdateSpaceLoadProgress(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 SpaceRecordID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out SpaceRecordID) == false) { return false; }
		float Progress = default(float); if (ViGameSerializer<float>.Read(IS, out Progress) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateSpaceLoadProgress(" + entity  + ", " + SpaceRecordID + ", " + Progress + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_24_UpdateSpaceLoadProgress;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, SpaceRecordID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Progress);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_25_CompleteSpaceLoad(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 SpaceRecordID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out SpaceRecordID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CompleteSpaceLoad(" + entity  + ", " + SpaceRecordID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_25_CompleteSpaceLoad;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, SpaceRecordID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_26_OnSpaceCloseByGM(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSpaceCloseByGM(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_26_OnSpaceCloseByGM;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_27_REQ_SpaceScriptEvent(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		Int32 Number = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Number) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_SpaceScriptEvent(" + entity  + ", " + Script + ", " + Number + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_27_REQ_SpaceScriptEvent;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Number);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_28_SpaceSpell(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceSpell(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_28_SpaceSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_29_SpaceSpell(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceSpell(" + entity  + ", " + ID + ", " + Pos + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_29_SpaceSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_30_ChatScriptBegin(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptBegin(" + entity  + ", " + Channel + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_30_ChatScriptBegin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_31_ChatScriptEnd(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptEnd(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_31_ChatScriptEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_32_ChatScriptShowItem(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ItemProperty Item = default(ItemProperty); if (ViGameSerializer<ItemProperty>.Read(IS, out Item) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptShowItem(" + entity  + ", " + Item + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_32_ChatScriptShowItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ItemProperty>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_33_ChatScriptWatchItem(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptWatchItem(" + entity  + ", " + Channel + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_33_ChatScriptWatchItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_34_ChatMessage(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatMessage(" + entity  + ", " + Channel + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_34_ChatMessage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_35_ChatMessage(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		PlayerIdentificationProperty Name = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Name) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatMessage(" + entity  + ", " + Name + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_35_ChatMessage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<PlayerIdentificationProperty>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_36_ClearHero(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearHero(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_36_ClearHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_37_CreateHero(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		HeroWorkingProperty Property = default(HeroWorkingProperty); if (ViGameSerializer<HeroWorkingProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreateHero(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_37_CreateHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroWorkingProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_38_CompleteHeroLoad(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CompleteHeroLoad(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_38_CompleteHeroLoad;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_39_REQ_AddMoveSpeedScale(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Value = default(float); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_AddMoveSpeedScale(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_39_REQ_AddMoveSpeedScale;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_40_REQ_DelMoveSpeedScale(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DelMoveSpeedScale(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_40_REQ_DelMoveSpeedScale;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_41_REQ_MoveTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_MoveTo(" + entity  + ", " + Pos + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_41_REQ_MoveTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_42_REQ_MoveTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViVector3> PosList = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PosList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_MoveTo(" + entity  + ", " + PosList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_42_REQ_MoveTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, PosList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_43_REQ_BreakMoveTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_BreakMoveTo(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_43_REQ_BreakMoveTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_44_REQ_TransportTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_TransportTo(" + entity  + ", " + Pos + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_44_REQ_TransportTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_45_REQ_TransportTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_TransportTo(" + entity  + ", " + Pos + ", " + Yaw + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_45_REQ_TransportTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_46_REQ_ShotStart(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_ShotStart(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_46_REQ_ShotStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_47_REQ_ShotEnd(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_ShotEnd(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_47_REQ_ShotEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_48_REQ_RecoverShot(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_RecoverShot(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_48_REQ_RecoverShot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_49_REQ_AddShotYaw(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_AddShotYaw(" + entity  + ", " + Yaw + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_49_REQ_AddShotYaw;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_50_REQ_DelShotYaw(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DelShotYaw(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_50_REQ_DelShotYaw;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_51_REQ_DoSpellByID(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 skillConfigID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out skillConfigID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_51_REQ_DoSpellByID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_52_REQ_DoSpellByID(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 skillConfigID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out skillConfigID) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Yaw + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_52_REQ_DoSpellByID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_53_REQ_DoSpellByID(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 skillConfigID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out skillConfigID) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		float Distance = default(float); if (ViGameSerializer<float>.Read(IS, out Distance) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Yaw + ", " + Distance + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_53_REQ_DoSpellByID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		ViGameSerializer<float>.Append(entity.RPC.OS, Distance);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_54_REQ_DoSpellByID(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 skillConfigID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out skillConfigID) == false) { return false; }
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Target + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_54_REQ_DoSpellByID;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_55_REQ_CancelSpell(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_CancelSpell(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_55_REQ_CancelSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_56_REQ_DoDash(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_DoDash(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_56_REQ_DoDash;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_57_REQ_StartFocus(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_StartFocus(" + entity  + ", " + Target + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_57_REQ_StartFocus;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_58_REQ_EndFocus(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_EndFocus(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_58_REQ_EndFocus;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_59_REQ_SetHeroYaw(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_SetHeroYaw(" + entity  + ", " + Yaw + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_59_REQ_SetHeroYaw;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_60_REQ_NavigateTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit TargetUnit = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetUnit) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_NavigateTo(" + entity  + ", " + TargetUnit + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_60_REQ_NavigateTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, TargetUnit);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_61_REQ_NavigateTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 TargetPosition = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPosition) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_NavigateTo(" + entity  + ", " + TargetPosition + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_61_REQ_NavigateTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, TargetPosition);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_62_REQ_InteractWithObject(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		SpaceObject targetObject = default(SpaceObject); if (ViGameSerializer<SpaceObject>.Read(IS, out targetObject) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_InteractWithObject(" + entity  + ", " + targetObject + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_62_REQ_InteractWithObject;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<SpaceObject>.Append(entity.RPC.OS, targetObject);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_63_QuestAddNPC(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 QuestID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out QuestID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> QuestAddNPC(" + entity  + ", " + QuestID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_63_QuestAddNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_64_QuestDelNPC(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 QuestID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out QuestID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> QuestDelNPC(" + entity  + ", " + QuestID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_64_QuestDelNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_65_EnterStoryModel(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 QuestID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out QuestID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterStoryModel(" + entity  + ", " + QuestID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_65_EnterStoryModel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_66_ExitStoryModel(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 QuestID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out QuestID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitStoryModel(" + entity  + ", " + QuestID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_66_ExitStoryModel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, QuestID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_67_GetItems(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ItemID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ItemID) == false) { return false; }
		UInt32 Count = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GetItems(" + entity  + ", " + ItemID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_67_GetItems;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ItemID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_MessageBox(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.MessageBox(Title, Content);
		return true;
	}
	static bool Client_1_DebugMessage(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.DebugMessage(Title, Content);
		return true;
	}
	static bool Client_2_ContainReserveWord(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString OrgValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out OrgValue) == false) { return false; }
		ViString FmtValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out FmtValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ContainReserveWord(OrgValue, FmtValue);
		return true;
	}
	static bool Client_3_OnPing(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Time = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPing(Time);
		return true;
	}
	static bool Client_4_HoldHeroRes(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.HoldHeroRes();
		return true;
	}
	static bool Client_5_FreeHeroRes(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.FreeHeroRes();
		return true;
	}
	static bool Client_6_OnNavigateTo(CellPlayer entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViVector3> PositionArray = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PositionArray) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnNavigateTo(PositionArray);
		return true;
	}
}
