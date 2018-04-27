using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellHeroCommandInvoker : ViEntityCommandInvoker<CellHero>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".Exec", Server_0_Exec);
		AddFunc(".Exec", Server_1_Exec);
		AddFunc(".BroadCastPing", Server_2_BroadCastPing);
		AddFunc(".PrintDamage", Server_3_PrintDamage);
		AddFunc(".AddNPC", Server_4_AddNPC);
		AddFunc(".AddNPC", Server_5_AddNPC);
		AddFunc(".AddNPC", Server_6_AddNPC);
		AddFunc(".AddNPCs", Server_7_AddNPCs);
		AddFunc(".AddNPCWithBirthPos", Server_8_AddNPCWithBirthPos);
		AddFunc(".DelRoundNPC", Server_9_DelRoundNPC);
		AddFunc(".AddObject", Server_10_AddObject);
		AddFunc(".AddObject", Server_11_AddObject);
		AddFunc(".AddObjects", Server_12_AddObjects);
		AddFunc(".DelRoundObject", Server_13_DelRoundObject);
		AddFunc(".UpdateProperty", Server_14_UpdateProperty);
		AddFunc(".ModLevel", Server_15_ModLevel);
		AddFunc(".ModXP", Server_16_ModXP);
		AddFunc(".RandomLevelEffect", Server_17_RandomLevelEffect);
		AddFunc(".SelectLevelEffect", Server_18_SelectLevelEffect);
		AddFunc(".ResetAI", Server_19_ResetAI);
		AddFunc(".AIPause", Server_20_AIPause);
		AddFunc(".AIResume", Server_21_AIResume);
		AddFunc(".ResetSpell", Server_22_ResetSpell);
		AddFunc(".AddSpell", Server_23_AddSpell);
		AddFunc(".SetupSpell", Server_24_SetupSpell);
		AddFunc(".SwapSpell", Server_25_SwapSpell);
		AddFunc(".TalkToNPC", Server_26_TalkToNPC);
		AddFunc(".OpenFunctionUI", Server_27_OpenFunctionUI);
		AddFunc(".SpaceActionStart", Server_28_SpaceActionStart);
		AddFunc(".SpaceActionEnd", Server_29_SpaceActionEnd);
		AddFunc(".REQ_Revive", Server_30_REQ_Revive);
		AddFunc("/OnBroadCastPing", Client_0_OnBroadCastPing);
		AddFunc("/MessageBox", Client_1_MessageBox);
		AddFunc("/DebugMessage", Client_2_DebugMessage);
		AddFunc("/RollbackMove", Client_3_RollbackMove);
		AddFunc("/MoveLockACK", Client_4_MoveLockACK);
		AddFunc("/OnWinShow", Client_5_OnWinShow);
		AddFunc("/OnLoseShow", Client_6_OnLoseShow);
		AddFunc("/OnSpaceActionStart", Client_7_OnSpaceActionStart);
		AddFunc("/OnSpaceActionEnd", Client_8_OnSpaceActionEnd);
		AddFunc("/CollectSpaceObject", Client_9_CollectSpaceObject);
		AddFunc("/EnterSpaceObject", Client_10_EnterSpaceObject);
		AddFunc("/OnNPCLoot", Client_11_OnNPCLoot);
		AddFunc("/OnNPCDie", Client_12_OnNPCDie);
		AddFunc("/OnWaveLoaded", Client_13_OnWaveLoaded);
		AddFunc("/OnMeleeWithoutTarget", Client_14_OnMeleeWithoutTarget);
	}
	public static new bool Exec(CellHero entity, string name, List<string> paramList)
	{
		if (ViEntityCommandInvoker<CellHero>.Exec(entity, name, paramList) == true) { return true; }
		else { return GameUnitCommandInvoker.Exec(entity, name, paramList); }
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		CellHero deriveEntity = entity as CellHero;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void Exec(CellHero entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_0_Exec;
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

	public static void Exec(CellHero entity, ViString Script, ViString Param)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_1_Exec;
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

	public static void BroadCastPing(CellHero entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_2_BroadCastPing;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BroadCastPing(" + entity  + ")");
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

	public static void PrintDamage(CellHero entity, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_3_PrintDamage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintDamage(" + entity  + ", " + Count + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNPC(CellHero entity, UInt32 Template)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_4_AddNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPC(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNPC(CellHero entity, UInt32 Template, Int32 LiveCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_5_AddNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPC(" + entity  + ", " + Template + ", " + LiveCount + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, LiveCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNPC(CellHero entity, UInt32 Template, Int32 LiveCount, Int16 Count, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_6_AddNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPC(" + entity  + ", " + Template + ", " + LiveCount + ", " + Count + ", " + Range + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, LiveCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNPCs(CellHero entity, UInt32 TemplateInf, UInt32 TemplateSup, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_7_AddNPCs;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPCs(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Range + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNPCWithBirthPos(CellHero entity, UInt32 BirthPos)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_8_AddNPCWithBirthPos;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPCWithBirthPos(" + entity  + ", " + BirthPos + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, BirthPos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelRoundNPC(CellHero entity, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_9_DelRoundNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelRoundNPC(" + entity  + ", " + Range + ")");
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
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddObject(CellHero entity, UInt32 Template)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_10_AddObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddObject(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddObject(CellHero entity, UInt32 Template, Int16 Count, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_11_AddObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddObject(" + entity  + ", " + Template + ", " + Count + ", " + Range + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddObjects(CellHero entity, UInt32 TemplateInf, UInt32 TemplateSup, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_12_AddObjects;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddObjects(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Range + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelRoundObject(CellHero entity, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_13_DelRoundObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelRoundObject(" + entity  + ", " + Range + ")");
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
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateProperty(CellHero entity, UInt32 Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_14_UpdateProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateProperty(" + entity  + ", " + Property + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModLevel(CellHero entity, Int16 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_15_ModLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModLevel(" + entity  + ", " + DeltaValue + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModXP(CellHero entity, Int64 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_16_ModXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModXP(" + entity  + ", " + DeltaValue + ")");
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
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RandomLevelEffect(CellHero entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_17_RandomLevelEffect;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RandomLevelEffect(" + entity  + ")");
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

	public static void ResetAI(CellHero entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_19_ResetAI;
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

	public static void AIPause(CellHero entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_20_AIPause;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AIPause(" + entity  + ", " + Script + ")");
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

	public static void AIResume(CellHero entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_21_AIResume;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AIResume(" + entity  + ", " + Script + ")");
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

	public static void ResetSpell(CellHero entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_22_ResetSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetSpell(" + entity  + ")");
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

	public static void AddSpell(CellHero entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_23_AddSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpell(" + entity  + ", " + ID + ")");
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

	public static void SetupSpell(CellHero entity, UInt32 ID, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_24_SetupSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetupSpell(" + entity  + ", " + ID + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SwapSpell(CellHero entity, UInt32 FID, UInt32 TID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_25_SwapSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SwapSpell(" + entity  + ", " + FID + ", " + TID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SpaceActionStart(CellHero entity, SpaceObject Object)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_28_SpaceActionStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceActionStart(" + entity  + ", " + Object + ")");
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
		ViGameSerializer<SpaceObject>.Append(entity.RPC.OS, Object);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SpaceActionEnd(CellHero entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_29_SpaceActionEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceActionEnd(" + entity  + ")");
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

	static bool Server_0_Exec(CellHero entity, List<string> paramList)
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
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_0_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_Exec(CellHero entity, List<string> paramList)
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
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_1_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_BroadCastPing(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BroadCastPing(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_2_BroadCastPing;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_PrintDamage(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintDamage(" + entity  + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_3_PrintDamage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_AddNPC(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNPC(" + entity  + ", " + Template + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_4_AddNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_AddNPC(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int32 LiveCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out LiveCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNPC(" + entity  + ", " + Template + ", " + LiveCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_5_AddNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, LiveCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_AddNPC(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int32 LiveCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out LiveCount) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNPC(" + entity  + ", " + Template + ", " + LiveCount + ", " + Count + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_6_AddNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, LiveCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_AddNPCs(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 TemplateInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateInf) == false) { return false; }
		UInt32 TemplateSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateSup) == false) { return false; }
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNPCs(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_7_AddNPCs;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_AddNPCWithBirthPos(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 BirthPos = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out BirthPos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNPCWithBirthPos(" + entity  + ", " + BirthPos + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_8_AddNPCWithBirthPos;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, BirthPos);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_DelRoundNPC(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelRoundNPC(" + entity  + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_9_DelRoundNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_AddObject(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddObject(" + entity  + ", " + Template + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_10_AddObject;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_AddObject(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddObject(" + entity  + ", " + Template + ", " + Count + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_11_AddObject;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_AddObjects(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 TemplateInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateInf) == false) { return false; }
		UInt32 TemplateSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateSup) == false) { return false; }
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddObjects(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_12_AddObjects;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_DelRoundObject(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelRoundObject(" + entity  + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_13_DelRoundObject;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_UpdateProperty(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Property = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateProperty(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_14_UpdateProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_ModLevel(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaValue = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModLevel(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_15_ModLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_ModXP(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 DeltaValue = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModXP(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_16_ModXP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_RandomLevelEffect(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RandomLevelEffect(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_17_RandomLevelEffect;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_SelectLevelEffect(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SelectLevelEffect(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_18_SelectLevelEffect;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_19_ResetAI(CellHero entity, List<string> paramList)
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
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_19_ResetAI;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_20_AIPause(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AIPause(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_20_AIPause;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_21_AIResume(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AIResume(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_21_AIResume;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_22_ResetSpell(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetSpell(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_22_ResetSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_23_AddSpell(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpell(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_23_AddSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_24_SetupSpell(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetupSpell(" + entity  + ", " + ID + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_24_SetupSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_25_SwapSpell(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 FID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out FID) == false) { return false; }
		UInt32 TID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SwapSpell(" + entity  + ", " + FID + ", " + TID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_25_SwapSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_26_TalkToNPC(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 StoryID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out StoryID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TalkToNPC(" + entity  + ", " + StoryID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_26_TalkToNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, StoryID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_27_OpenFunctionUI(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 GameFuncID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GameFuncID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OpenFunctionUI(" + entity  + ", " + GameFuncID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_27_OpenFunctionUI;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GameFuncID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_28_SpaceActionStart(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		SpaceObject Object = default(SpaceObject); if (ViGameSerializer<SpaceObject>.Read(IS, out Object) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceActionStart(" + entity  + ", " + Object + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_28_SpaceActionStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<SpaceObject>.Append(entity.RPC.OS, Object);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_29_SpaceActionEnd(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceActionEnd(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_29_SpaceActionEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_30_REQ_Revive(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> REQ_Revive(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)CellHeroServerMethod.METHOD_30_REQ_Revive;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnBroadCastPing(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Time = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBroadCastPing(Time);
		return true;
	}
	static bool Client_1_MessageBox(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.MessageBox(Title, Content);
		return true;
	}
	static bool Client_2_DebugMessage(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.DebugMessage(Title, Content);
		return true;
	}
	static bool Client_3_RollbackMove(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.RollbackMove(Pos, Yaw);
		return true;
	}
	static bool Client_4_MoveLockACK(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.MoveLockACK(Result);
		return true;
	}
	static bool Client_5_OnWinShow(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnWinShow();
		return true;
	}
	static bool Client_6_OnLoseShow(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnLoseShow();
		return true;
	}
	static bool Client_7_OnSpaceActionStart(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		SpaceObject SpaceObject = default(SpaceObject); if (ViGameSerializer<SpaceObject>.Read(IS, out SpaceObject) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpaceActionStart(SpaceObject, Duration);
		return true;
	}
	static bool Client_8_OnSpaceActionEnd(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		SpaceObject SpaceObject = default(SpaceObject); if (ViGameSerializer<SpaceObject>.Read(IS, out SpaceObject) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpaceActionEnd(SpaceObject);
		return true;
	}
	static bool Client_9_CollectSpaceObject(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 ID = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out ID) == false) { return false; }
		Int32 Duration = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.CollectSpaceObject(ID, Duration);
		return true;
	}
	static bool Client_10_EnterSpaceObject(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 BirthID = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out BirthID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.EnterSpaceObject(BirthID);
		return true;
	}
	static bool Client_11_OnNPCLoot(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		CellNPC Entity = default(CellNPC); if (ViGameSerializer<CellNPC>.Read(IS, out Entity) == false) { return false; }
		Int32 XP = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out XP) == false) { return false; }
		Int32 YinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out YinPiao) == false) { return false; }
		List<ItemCountProperty> ItemList = default(List<ItemCountProperty>); if (ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnNPCLoot(Entity, XP, YinPiao, ItemList);
		return true;
	}
	static bool Client_12_OnNPCDie(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 BirthID = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out BirthID) == false) { return false; }
		Int32 NPCID = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out NPCID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnNPCDie(BirthID, NPCID);
		return true;
	}
	static bool Client_13_OnWaveLoaded(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 BirthID = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out BirthID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnWaveLoaded(BirthID);
		return true;
	}
	static bool Client_14_OnMeleeWithoutTarget(CellHero entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnMeleeWithoutTarget();
		return true;
	}
}
