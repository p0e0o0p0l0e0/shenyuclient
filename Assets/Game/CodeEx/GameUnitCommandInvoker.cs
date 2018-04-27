using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameUnitCommandInvoker : ViEntityCommandInvoker<GameUnit>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".SetValue32", Server_0_SetValue32);
		AddFunc(".ModValue32", Server_1_ModValue32);
		AddFunc(".SetScriptValue", Server_2_SetScriptValue);
		AddFunc(".ClearScriptValue", Server_3_ClearScriptValue);
		AddFunc(".ClearReferencePtr", Server_4_ClearReferencePtr);
		AddFunc(".ClearReferencePtr", Server_5_ClearReferencePtr);
		AddFunc(".SetWeapon", Server_6_SetWeapon);
		AddFunc(".SetBullet", Server_7_SetBullet);
		AddFunc(".Spell", Server_8_Spell);
		AddFunc(".Spell", Server_9_Spell);
		AddFunc(".Spell", Server_10_Spell);
		AddFunc(".AddAura", Server_11_AddAura);
		AddFunc(".AddAura", Server_12_AddAura);
		AddFunc(".CloseAura", Server_13_CloseAura);
		AddFunc(".CloseAllAura", Server_14_CloseAllAura);
		AddFunc(".CloseAuraByChannel", Server_15_CloseAuraByChannel);
		AddFunc(".CloseAuraBySpell", Server_16_CloseAuraBySpell);
		AddFunc(".AddAreaAura", Server_17_AddAreaAura);
		AddFunc(".AddHitEffect", Server_18_AddHitEffect);
		AddFunc(".AddSpellEffect", Server_19_AddSpellEffect);
		AddFunc(".SetDefaultVisibilityMask", Server_20_SetDefaultVisibilityMask);
		AddFunc(".AddVisibilityMask", Server_21_AddVisibilityMask);
		AddFunc(".DelVisibilityMask", Server_22_DelVisibilityMask);
		AddFunc(".SetDynamicVisibilityChannel", Server_23_SetDynamicVisibilityChannel);
		AddFunc(".SetFaction", Server_24_SetFaction);
		AddFunc(".AddFaction", Server_25_AddFaction);
		AddFunc(".DelFaction", Server_26_DelFaction);
		AddFunc(".SetLevel", Server_27_SetLevel);
		AddFunc(".Revive", Server_28_Revive);
		AddFunc(".SendSpaceEvent", Server_29_SendSpaceEvent);
		AddFunc(".SendSpaceEvent", Server_30_SendSpaceEvent);
		AddFunc(".EraseSpaceEventCache", Server_31_EraseSpaceEventCache);
		AddFunc(".AddSpaceBlockSlot", Server_32_AddSpaceBlockSlot);
		AddFunc(".DelSpaceBlockSlot", Server_33_DelSpaceBlockSlot);
		AddFunc(".SetSpaceBlockSlotState", Server_34_SetSpaceBlockSlotState);
		AddFunc(".KillSpaceBlockSlot", Server_35_KillSpaceBlockSlot);
		AddFunc(".AddSpaceHideSlot", Server_36_AddSpaceHideSlot);
		AddFunc(".DelSpaceHideSlot", Server_37_DelSpaceHideSlot);
		AddFunc(".SetSpaceHideSlotState", Server_38_SetSpaceHideSlotState);
		AddFunc(".KillSpaceHideSlot", Server_39_KillSpaceHideSlot);
		AddFunc(".ClearSpellCD", Server_40_ClearSpellCD);
		AddFunc(".ClearSpellCD", Server_41_ClearSpellCD);
		AddFunc(".AddSpellCD", Server_42_AddSpellCD);
		AddFunc("/OnMoveTo", Client_0_OnMoveTo);
		AddFunc("/OnMoveTo", Client_1_OnMoveTo);
		AddFunc("/OnBreakMove", Client_2_OnBreakMove);
		AddFunc("/OnBreakMove", Client_3_OnBreakMove);
		AddFunc("/OnUpdateYaw", Client_4_OnUpdateYaw);
		AddFunc("/OnUpdatePosYaw", Client_5_OnUpdatePosYaw);
		AddFunc("/OnChargeTo", Client_6_OnChargeTo);
		AddFunc("/OnChargeTo", Client_7_OnChargeTo);
		AddFunc("/OnChargeTo", Client_8_OnChargeTo);
		AddFunc("/OnChargeTo", Client_9_OnChargeTo);
		AddFunc("/OnAimChargeTo", Client_10_OnAimChargeTo);
		AddFunc("/OnAimChargeTo", Client_11_OnAimChargeTo);
		AddFunc("/OnTransportTo", Client_12_OnTransportTo);
		AddFunc("/OnTransportTo", Client_13_OnTransportTo);
		AddFunc("/OnFlyTo", Client_14_OnFlyTo);
		AddFunc("/FixTimeFlyTo", Client_15_FixTimeFlyTo);
		AddFunc("/SetBodyVisiable", Client_16_SetBodyVisiable);
		AddFunc("/OnWorldSay", Client_17_OnWorldSay);
		AddFunc("/OnWorldSay", Client_18_OnWorldSay);
		AddFunc("/CloseWorldSay", Client_19_CloseWorldSay);
		AddFunc("/CloseWorldSay", Client_20_CloseWorldSay);
		AddFunc("/OnDamageHited", Client_21_OnDamageHited);
		AddFunc("/OnDie", Client_22_OnDie);
		AddFunc("/OnRevive", Client_23_OnRevive);
		AddFunc("/OnSoul", Client_24_OnSoul);
		AddFunc("/OnShotStart", Client_25_OnShotStart);
		AddFunc("/OnShotEnd", Client_26_OnShotEnd);
		AddFunc("/OnShotRecover", Client_27_OnShotRecover);
		AddFunc("/OnBulletStart", Client_28_OnBulletStart);
		AddFunc("/OnBulletStart", Client_29_OnBulletStart);
		AddFunc("/OnBulletEnd", Client_30_OnBulletEnd);
		AddFunc("/OnBulletClear", Client_31_OnBulletClear);
		AddFunc("/OnMeleeAttackOnce", Client_32_OnMeleeAttackOnce);
		AddFunc("/OnSpellPrepare", Client_33_OnSpellPrepare);
		AddFunc("/OnSpellPrepare", Client_34_OnSpellPrepare);
		AddFunc("/OnSpellCast", Client_35_OnSpellCast);
		AddFunc("/OnSpellCast", Client_36_OnSpellCast);
		AddFunc("/OnSpellCast", Client_37_OnSpellCast);
		AddFunc("/OnSpellCast", Client_38_OnSpellCast);
		AddFunc("/OnSpellCastStart", Client_39_OnSpellCastStart);
		AddFunc("/OnSpellCastStart", Client_40_OnSpellCastStart);
		AddFunc("/OnSpellCastEnd", Client_41_OnSpellCastEnd);
		AddFunc("/OnCancelSpell", Client_42_OnCancelSpell);
		AddFunc("/OnBreakSpell", Client_43_OnBreakSpell);
		AddFunc("/OnSpellEnd", Client_44_OnSpellEnd);
		AddFunc("/OnCastTo", Client_45_OnCastTo);
		AddFunc("/OnCastTo", Client_46_OnCastTo);
		AddFunc("/OnCastTo", Client_47_OnCastTo);
		AddFunc("/OnCastFrom", Client_48_OnCastFrom);
		AddFunc("/OnHitVisual", Client_49_OnHitVisual);
		AddFunc("/OnHitVisual", Client_50_OnHitVisual);
		AddFunc("/OnHitVisual", Client_51_OnHitVisual);
		AddFunc("/OnHitVisualShadow", Client_52_OnHitVisualShadow);
		AddFunc("/OnLinkVisualStart", Client_53_OnLinkVisualStart);
		AddFunc("/OnLinkVisualStart", Client_54_OnLinkVisualStart);
		AddFunc("/OnLinkVisualEnd", Client_55_OnLinkVisualEnd);
		AddFunc("/OnLinkVisualEndFrom", Client_56_OnLinkVisualEndFrom);
		AddFunc("/OnLinkVisualEndTo", Client_57_OnLinkVisualEndTo);
		AddFunc("/OnLinkVisualOnce", Client_58_OnLinkVisualOnce);
		AddFunc("/OnLinkVisualOnce", Client_59_OnLinkVisualOnce);
		AddFunc("/PlayActionAnim", Client_60_PlayActionAnim);
		AddFunc("/PlayStateAnim", Client_61_PlayStateAnim);
		AddFunc("/StopStateAnim", Client_62_StopStateAnim);
		AddFunc("/OnCastVisual", Client_63_OnCastVisual);
		AddFunc("/OnCastVisual", Client_64_OnCastVisual);
		AddFunc("/OnHitEffectVisual", Client_65_OnHitEffectVisual);
		AddFunc("/OnHitEffectVisual", Client_66_OnHitEffectVisual);
		AddFunc("/OnAreaHitEffectVisual", Client_67_OnAreaHitEffectVisual);
		AddFunc("/AddAvatarDurationVisual", Client_68_AddAvatarDurationVisual);
		AddFunc("/ClearAvatarDurationVisual", Client_69_ClearAvatarDurationVisual);
		AddFunc("/ShowDriveVisual", Client_70_ShowDriveVisual);
		AddFunc("/PrintHoldResource", Client_71_PrintHoldResource);
		AddFunc("/ShootAura", Client_72_ShootAura);
	}
	public static new bool Exec(GameUnit entity, string name, List<string> paramList)
	{
		if (ViEntityCommandInvoker<GameUnit>.Exec(entity, name, paramList) == true) { return true; }
		else { return ViGameUnitCommandInvoker.Exec(entity, name, paramList); }
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		GameUnit deriveEntity = entity as GameUnit;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void SetValue32(GameUnit entity, UInt16 PropertyIdx, Int32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_0_SetValue32;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetValue32(" + entity  + ", " + PropertyIdx + ", " + Value + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, PropertyIdx);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModValue32(GameUnit entity, UInt16 PropertyIdx, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_1_ModValue32;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModValue32(" + entity  + ", " + PropertyIdx + ", " + DeltaValue + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, PropertyIdx);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScriptValue(GameUnit entity, ViString Name, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_2_SetScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
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
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearScriptValue(GameUnit entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_3_ClearScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearScriptValue(" + entity  + ", " + Name + ")");
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

	public static void ClearReferencePtr(GameUnit entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_4_ClearReferencePtr;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearReferencePtr(" + entity  + ")");
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

	public static void ClearReferencePtr(GameUnit entity, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_5_ClearReferencePtr;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearReferencePtr(" + entity  + ", " + Tag + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetWeapon(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_6_SetWeapon;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetWeapon(" + entity  + ", " + ID + ")");
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

	public static void SetBullet(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_7_SetBullet;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetBullet(" + entity  + ", " + ID + ")");
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

	public static void Spell(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_8_Spell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Spell(" + entity  + ", " + ID + ")");
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

	public static void Spell(GameUnit entity, UInt32 ID, GameUnit Target)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_9_Spell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Spell(" + entity  + ", " + ID + ", " + Target + ")");
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
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void Spell(GameUnit entity, UInt32 ID, ViVector3 Pos)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_10_Spell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Spell(" + entity  + ", " + ID + ", " + Pos + ")");
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

	public static void AddAura(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_11_AddAura;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddAura(" + entity  + ", " + ID + ")");
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

	public static void AddAura(GameUnit entity, UInt32 ID, Int32 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_12_AddAura;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddAura(" + entity  + ", " + ID + ", " + Duration + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CloseAura(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_13_CloseAura;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseAura(" + entity  + ", " + ID + ")");
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

	public static void CloseAllAura(GameUnit entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_14_CloseAllAura;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseAllAura(" + entity  + ")");
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

	public static void CloseAuraByChannel(GameUnit entity, UInt32 Channel)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_15_CloseAuraByChannel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseAuraByChannel(" + entity  + ", " + Channel + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CloseAuraBySpell(GameUnit entity, UInt32 Spell)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_16_CloseAuraBySpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseAuraBySpell(" + entity  + ", " + Spell + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Spell);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddAreaAura(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_17_AddAreaAura;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddAreaAura(" + entity  + ", " + ID + ")");
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

	public static void AddHitEffect(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_18_AddHitEffect;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddHitEffect(" + entity  + ", " + ID + ")");
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

	public static void AddSpellEffect(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_19_AddSpellEffect;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpellEffect(" + entity  + ", " + ID + ")");
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

	public static void SetDefaultVisibilityMask(GameUnit entity, UInt32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_20_SetDefaultVisibilityMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetDefaultVisibilityMask(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddVisibilityMask(GameUnit entity, ViString Name, Int32 Weight, UInt32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_21_AddVisibilityMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddVisibilityMask(" + entity  + ", " + Name + ", " + Weight + ", " + Value + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelVisibilityMask(GameUnit entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_22_DelVisibilityMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelVisibilityMask(" + entity  + ", " + Name + ")");
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

	public static void SetDynamicVisibilityChannel(GameUnit entity, UInt64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_23_SetDynamicVisibilityChannel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetDynamicVisibilityChannel(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetFaction(GameUnit entity, UInt8 Faction)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_24_SetFaction;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetFaction(" + entity  + ", " + Faction + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddFaction(GameUnit entity, ViString Name, Int32 Weight, UInt8 Faction)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_25_AddFaction;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFaction(" + entity  + ", " + Name + ", " + Weight + ", " + Faction + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelFaction(GameUnit entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_26_DelFaction;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFaction(" + entity  + ", " + Name + ")");
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

	public static void SetLevel(GameUnit entity, Int16 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_27_SetLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetLevel(" + entity  + ", " + Level + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void Revive(GameUnit entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_28_Revive;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Revive(" + entity  + ")");
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

	public static void SendSpaceEvent(GameUnit entity, UInt32 Event)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_29_SendSpaceEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendSpaceEvent(" + entity  + ", " + Event + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SendSpaceEvent(GameUnit entity, UInt32 Event, Int32 DelayTime, UInt8 Faction)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_30_SendSpaceEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendSpaceEvent(" + entity  + ", " + Event + ", " + DelayTime + ", " + Faction + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DelayTime);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EraseSpaceEventCache(GameUnit entity, UInt32 Event)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_31_EraseSpaceEventCache;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EraseSpaceEventCache(" + entity  + ", " + Event + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSpaceBlockSlot(GameUnit entity, UInt32 ID, UInt8 State)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_32_AddSpaceBlockSlot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceBlockSlot(" + entity  + ", " + ID + ", " + State + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelSpaceBlockSlot(GameUnit entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_33_DelSpaceBlockSlot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSpaceBlockSlot(" + entity  + ", " + Idx + ")");
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

	public static void SetSpaceBlockSlotState(GameUnit entity, UInt16 Idx, UInt8 State)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_34_SetSpaceBlockSlotState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetSpaceBlockSlotState(" + entity  + ", " + Idx + ", " + State + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void KillSpaceBlockSlot(GameUnit entity, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_35_KillSpaceBlockSlot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> KillSpaceBlockSlot(" + entity  + ", " + Range + ")");
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

	public static void AddSpaceHideSlot(GameUnit entity, UInt32 ID, UInt8 State)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_36_AddSpaceHideSlot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceHideSlot(" + entity  + ", " + ID + ", " + State + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelSpaceHideSlot(GameUnit entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_37_DelSpaceHideSlot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSpaceHideSlot(" + entity  + ", " + Idx + ")");
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

	public static void SetSpaceHideSlotState(GameUnit entity, UInt16 Idx, UInt8 State)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_38_SetSpaceHideSlotState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetSpaceHideSlotState(" + entity  + ", " + Idx + ", " + State + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void KillSpaceHideSlot(GameUnit entity, float Range)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_39_KillSpaceHideSlot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> KillSpaceHideSlot(" + entity  + ", " + Range + ")");
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

	public static void ClearSpellCD(GameUnit entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_40_ClearSpellCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearSpellCD(" + entity  + ")");
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

	public static void ClearSpellCD(GameUnit entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_41_ClearSpellCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearSpellCD(" + entity  + ", " + ID + ")");
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

	public static void AddSpellCD(GameUnit entity, UInt32 ID, Int32 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_42_AddSpellCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpellCD(" + entity  + ", " + ID + ", " + Duration + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_SetValue32(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 PropertyIdx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out PropertyIdx) == false) { return false; }
		Int32 Value = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetValue32(" + entity  + ", " + PropertyIdx + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_0_SetValue32;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, PropertyIdx);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_ModValue32(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 PropertyIdx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out PropertyIdx) == false) { return false; }
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModValue32(" + entity  + ", " + PropertyIdx + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_1_ModValue32;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, PropertyIdx);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_SetScriptValue(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_2_SetScriptValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_ClearScriptValue(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearScriptValue(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_3_ClearScriptValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_ClearReferencePtr(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearReferencePtr(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_4_ClearReferencePtr;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_ClearReferencePtr(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearReferencePtr(" + entity  + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_5_ClearReferencePtr;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_SetWeapon(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetWeapon(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_6_SetWeapon;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_SetBullet(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetBullet(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_7_SetBullet;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_Spell(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Spell(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_8_Spell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_Spell(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Spell(" + entity  + ", " + ID + ", " + Target + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_9_Spell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_Spell(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Spell(" + entity  + ", " + ID + ", " + Pos + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_10_Spell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_AddAura(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddAura(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_11_AddAura;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_AddAura(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int32 Duration = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddAura(" + entity  + ", " + ID + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_12_AddAura;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_CloseAura(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseAura(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_13_CloseAura;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_CloseAllAura(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseAllAura(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_14_CloseAllAura;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_CloseAuraByChannel(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Channel = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Channel) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseAuraByChannel(" + entity  + ", " + Channel + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_15_CloseAuraByChannel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_CloseAuraBySpell(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Spell = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Spell) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseAuraBySpell(" + entity  + ", " + Spell + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_16_CloseAuraBySpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Spell);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_AddAreaAura(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddAreaAura(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_17_AddAreaAura;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_AddHitEffect(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddHitEffect(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_18_AddHitEffect;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_19_AddSpellEffect(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpellEffect(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_19_AddSpellEffect;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_20_SetDefaultVisibilityMask(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Value = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetDefaultVisibilityMask(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_20_SetDefaultVisibilityMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_21_AddVisibilityMask(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Weight = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Weight) == false) { return false; }
		UInt32 Value = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddVisibilityMask(" + entity  + ", " + Name + ", " + Weight + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_21_AddVisibilityMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_22_DelVisibilityMask(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelVisibilityMask(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_22_DelVisibilityMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_23_SetDynamicVisibilityChannel(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Value = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetDynamicVisibilityChannel(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_23_SetDynamicVisibilityChannel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_24_SetFaction(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetFaction(" + entity  + ", " + Faction + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_24_SetFaction;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_25_AddFaction(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Weight = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Weight) == false) { return false; }
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddFaction(" + entity  + ", " + Name + ", " + Weight + ", " + Faction + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_25_AddFaction;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_26_DelFaction(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelFaction(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_26_DelFaction;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_27_SetLevel(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetLevel(" + entity  + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_27_SetLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_28_Revive(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Revive(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_28_Revive;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_29_SendSpaceEvent(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Event = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Event) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SendSpaceEvent(" + entity  + ", " + Event + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_29_SendSpaceEvent;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_30_SendSpaceEvent(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Event = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Event) == false) { return false; }
		Int32 DelayTime = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DelayTime) == false) { return false; }
		UInt8 Faction = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Faction) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SendSpaceEvent(" + entity  + ", " + Event + ", " + DelayTime + ", " + Faction + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_30_SendSpaceEvent;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DelayTime);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Faction);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_31_EraseSpaceEventCache(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Event = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Event) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EraseSpaceEventCache(" + entity  + ", " + Event + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_31_EraseSpaceEventCache;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_32_AddSpaceBlockSlot(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 State = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out State) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpaceBlockSlot(" + entity  + ", " + ID + ", " + State + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_32_AddSpaceBlockSlot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_33_DelSpaceBlockSlot(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelSpaceBlockSlot(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_33_DelSpaceBlockSlot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_34_SetSpaceBlockSlotState(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		UInt8 State = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out State) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetSpaceBlockSlotState(" + entity  + ", " + Idx + ", " + State + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_34_SetSpaceBlockSlotState;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_35_KillSpaceBlockSlot(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> KillSpaceBlockSlot(" + entity  + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_35_KillSpaceBlockSlot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_36_AddSpaceHideSlot(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 State = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out State) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpaceHideSlot(" + entity  + ", " + ID + ", " + State + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_36_AddSpaceHideSlot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_37_DelSpaceHideSlot(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelSpaceHideSlot(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_37_DelSpaceHideSlot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_38_SetSpaceHideSlotState(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		UInt8 State = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out State) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetSpaceHideSlotState(" + entity  + ", " + Idx + ", " + State + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_38_SetSpaceHideSlotState;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_39_KillSpaceHideSlot(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Range = default(float); if (ViGameSerializer<float>.Read(IS, out Range) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> KillSpaceHideSlot(" + entity  + ", " + Range + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_39_KillSpaceHideSlot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Range);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_40_ClearSpellCD(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearSpellCD(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_40_ClearSpellCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_41_ClearSpellCD(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearSpellCD(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_41_ClearSpellCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_42_AddSpellCD(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int32 Duration = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpellCD(" + entity  + ", " + ID + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GameUnitServerMethod.METHOD_42_AddSpellCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnMoveTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnMoveTo(Pos);
		return true;
	}
	static bool Client_1_OnMoveTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViVector3> PosList = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PosList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnMoveTo(PosList);
		return true;
	}
	static bool Client_2_OnBreakMove(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBreakMove(Pos, Yaw);
		return true;
	}
	static bool Client_3_OnBreakMove(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBreakMove(Yaw);
		return true;
	}
	static bool Client_4_OnUpdateYaw(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateYaw(Yaw);
		return true;
	}
	static bool Client_5_OnUpdatePosYaw(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdatePosYaw(Pos, Yaw);
		return true;
	}
	static bool Client_6_OnChargeTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		UInt8 LockOnGround = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out LockOnGround) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChargeTo(DestPos, Yaw, Duration, LockOnGround);
		return true;
	}
	static bool Client_7_OnChargeTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		UInt8 LockOnGround = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out LockOnGround) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChargeTo(Visual, DestPos, Yaw, Duration, LockOnGround);
		return true;
	}
	static bool Client_8_OnChargeTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViVector3> PosList = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PosList) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		UInt8 LockOnGround = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out LockOnGround) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChargeTo(PosList, Yaw, Duration, LockOnGround);
		return true;
	}
	static bool Client_9_OnChargeTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		List<ViVector3> PosList = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PosList) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		UInt8 LockOnGround = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out LockOnGround) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChargeTo(Visual, PosList, Yaw, Duration, LockOnGround);
		return true;
	}
	static bool Client_10_OnAimChargeTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnAimChargeTo(DestPos, Duration);
		return true;
	}
	static bool Client_11_OnAimChargeTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnAimChargeTo(Visual, DestPos, Duration);
		return true;
	}
	static bool Client_12_OnTransportTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnTransportTo(DestPos, Yaw);
		return true;
	}
	static bool Client_13_OnTransportTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnTransportTo(Visual, DestPos, Yaw);
		return true;
	}
	static bool Client_14_OnFlyTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 StartPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out StartPos) == false) { return false; }
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnFlyTo(StartPos, DestPos, Yaw, Duration);
		return true;
	}
	static bool Client_15_FixTimeFlyTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpellID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpellID) == false) { return false; }
		ViVector3 StartPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out StartPos) == false) { return false; }
		ViVector3 DestPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out DestPos) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.FixTimeFlyTo(SpellID, StartPos, DestPos, Yaw);
		return true;
	}
	static bool Client_16_SetBodyVisiable(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Visiable = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Visiable) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.SetBodyVisiable(Visiable);
		return true;
	}
	static bool Client_17_OnWorldSay(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Dialog = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Dialog) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnWorldSay(Dialog);
		return true;
	}
	static bool Client_18_OnWorldSay(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Dialog = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Dialog) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnWorldSay(Dialog, Duration);
		return true;
	}
	static bool Client_19_CloseWorldSay(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.CloseWorldSay();
		return true;
	}
	static bool Client_20_CloseWorldSay(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float DelayTime = default(float); if (ViGameSerializer<float>.Read(IS, out DelayTime) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.CloseWorldSay(DelayTime);
		return true;
	}
	static bool Client_21_OnDamageHited(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnDamageHited(Attacker);
		return true;
	}
	static bool Client_22_OnDie(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnDie();
		return true;
	}
	static bool Client_23_OnRevive(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnRevive();
		return true;
	}
	static bool Client_24_OnSoul(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnSoul();
		return true;
	}
	static bool Client_25_OnShotStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnShotStart();
		return true;
	}
	static bool Client_26_OnShotEnd(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnShotEnd();
		return true;
	}
	static bool Client_27_OnShotRecover(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnShotRecover();
		return true;
	}
	static bool Client_28_OnBulletStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int8 Yaw = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out Yaw) == false) { return false; }
		UInt8 ID = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out ID) == false) { return false; }
		UInt8 Duration = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Duration) == false) { return false; }
		Int8 Speed = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBulletStart(Yaw, ID, Duration, Speed);
		return true;
	}
	static bool Client_29_OnBulletStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int8 Yaw = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out Yaw) == false) { return false; }
		List<UInt8> IDList = default(List<UInt8>); if (ViGameSerializer<UInt8>.Read(IS, out IDList) == false) { return false; }
		List<Int8> YawList = default(List<Int8>); if (ViGameSerializer<Int8>.Read(IS, out YawList) == false) { return false; }
		List<UInt8> DurationList = default(List<UInt8>); if (ViGameSerializer<UInt8>.Read(IS, out DurationList) == false) { return false; }
		Int8 Speed = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBulletStart(Yaw, IDList, YawList, DurationList, Speed);
		return true;
	}
	static bool Client_30_OnBulletEnd(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 ID = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBulletEnd(ID);
		return true;
	}
	static bool Client_31_OnBulletClear(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnBulletClear();
		return true;
	}
	static bool Client_32_OnMeleeAttackOnce(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit TargetEntity = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetEntity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnMeleeAttackOnce(TargetEntity);
		return true;
	}
	static bool Client_33_OnSpellPrepare(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		GameUnit TargetEntity = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetEntity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellPrepare(ID, TargetEntity);
		return true;
	}
	static bool Client_34_OnSpellPrepare(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 TargetPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellPrepare(ID, TargetPos);
		return true;
	}
	static bool Client_35_OnSpellCast(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		GameUnit TargetEntity = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetEntity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCast(ID, TargetEntity);
		return true;
	}
	static bool Client_36_OnSpellCast(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 TargetPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCast(ID, TargetPos);
		return true;
	}
	static bool Client_37_OnSpellCast(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		GameUnit TargetEntity = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetEntity) == false) { return false; }
		float SendTime = default(float); if (ViGameSerializer<float>.Read(IS, out SendTime) == false) { return false; }
		float TravelDuration = default(float); if (ViGameSerializer<float>.Read(IS, out TravelDuration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCast(ID, TargetEntity, SendTime, TravelDuration);
		return true;
	}
	static bool Client_38_OnSpellCast(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 TargetPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPos) == false) { return false; }
		float SendTime = default(float); if (ViGameSerializer<float>.Read(IS, out SendTime) == false) { return false; }
		float TravelDuration = default(float); if (ViGameSerializer<float>.Read(IS, out TravelDuration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCast(ID, TargetPos, SendTime, TravelDuration);
		return true;
	}
	static bool Client_39_OnSpellCastStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		GameUnit TargetEntity = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetEntity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCastStart(ID, TargetEntity);
		return true;
	}
	static bool Client_40_OnSpellCastStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 TargetPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCastStart(ID, TargetPos);
		return true;
	}
	static bool Client_41_OnSpellCastEnd(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellCastEnd();
		return true;
	}
	static bool Client_42_OnCancelSpell(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnCancelSpell();
		return true;
	}
	static bool Client_43_OnBreakSpell(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnBreakSpell();
		return true;
	}
	static bool Client_44_OnSpellEnd(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnSpellEnd();
		return true;
	}
	static bool Client_45_OnCastTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCastTo(ID, Pos, Duration);
		return true;
	}
	static bool Client_46_OnCastTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCastTo(ID, Target, Duration);
		return true;
	}
	static bool Client_47_OnCastTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 FromPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out FromPos) == false) { return false; }
		ViVector3 ToPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out ToPos) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCastTo(ID, FromPos, ToPos, Duration);
		return true;
	}
	static bool Client_48_OnCastFrom(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCastFrom(ID, Pos, Duration);
		return true;
	}
	static bool Client_49_OnHitVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitVisual(ID);
		return true;
	}
	static bool Client_50_OnHitVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitVisual(ID, Pos);
		return true;
	}
	static bool Client_51_OnHitVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		Int8 FromDir = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FromDir) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitVisual(ID, Pos, FromDir);
		return true;
	}
	static bool Client_52_OnHitVisualShadow(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		Int8 FromDir = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FromDir) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitVisualShadow(ID, Pos, FromDir);
		return true;
	}
	static bool Client_53_OnLinkVisualStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float FlyDuration = default(float); if (ViGameSerializer<float>.Read(IS, out FlyDuration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualStart(ID, Visual, Pos, FlyDuration);
		return true;
	}
	static bool Client_54_OnLinkVisualStart(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		float FlyDuration = default(float); if (ViGameSerializer<float>.Read(IS, out FlyDuration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualStart(ID, Visual, Target, FlyDuration);
		return true;
	}
	static bool Client_55_OnLinkVisualEnd(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualEnd(ID);
		return true;
	}
	static bool Client_56_OnLinkVisualEndFrom(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualEndFrom(ID, Duration);
		return true;
	}
	static bool Client_57_OnLinkVisualEndTo(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualEndTo(ID, Duration);
		return true;
	}
	static bool Client_58_OnLinkVisualOnce(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		float StartDuration = default(float); if (ViGameSerializer<float>.Read(IS, out StartDuration) == false) { return false; }
		float HoldDuration = default(float); if (ViGameSerializer<float>.Read(IS, out HoldDuration) == false) { return false; }
		float EndDuration = default(float); if (ViGameSerializer<float>.Read(IS, out EndDuration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualOnce(Visual, Pos, StartDuration, HoldDuration, EndDuration);
		return true;
	}
	static bool Client_59_OnLinkVisualOnce(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Visual = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Visual) == false) { return false; }
		GameUnit Target = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Target) == false) { return false; }
		float StartDuration = default(float); if (ViGameSerializer<float>.Read(IS, out StartDuration) == false) { return false; }
		float HoldDuration = default(float); if (ViGameSerializer<float>.Read(IS, out HoldDuration) == false) { return false; }
		float EndDuration = default(float); if (ViGameSerializer<float>.Read(IS, out EndDuration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLinkVisualOnce(Visual, Target, StartDuration, HoldDuration, EndDuration);
		return true;
	}
	static bool Client_60_PlayActionAnim(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.PlayActionAnim(Name);
		return true;
	}
	static bool Client_61_PlayStateAnim(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.PlayStateAnim(Name);
		return true;
	}
	static bool Client_62_StopStateAnim(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.StopStateAnim(Name);
		return true;
	}
	static bool Client_63_OnCastVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt16 SendTime = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out SendTime) == false) { return false; }
		GameUnit TargetEntity = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out TargetEntity) == false) { return false; }
		float Speed = default(float); if (ViGameSerializer<float>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCastVisual(ID, SendTime, TargetEntity, Speed);
		return true;
	}
	static bool Client_64_OnCastVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt16 SendTime = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out SendTime) == false) { return false; }
		ViVector3 TargetPosition = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPosition) == false) { return false; }
		float Speed = default(float); if (ViGameSerializer<float>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCastVisual(ID, SendTime, TargetPosition, Speed);
		return true;
	}
	static bool Client_65_OnHitEffectVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitEffectVisual(Attacker, ID);
		return true;
	}
	static bool Client_66_OnHitEffectVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int8 FromDir = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FromDir) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitEffectVisual(Attacker, ID, FromDir);
		return true;
	}
	static bool Client_67_OnAreaHitEffectVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Attacker = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Attacker) == false) { return false; }
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		ViVector3 Position = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Position) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnAreaHitEffectVisual(Attacker, ID, Position, Yaw);
		return true;
	}
	static bool Client_68_AddAvatarDurationVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.AddAvatarDurationVisual(ID);
		return true;
	}
	static bool Client_69_ClearAvatarDurationVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.ClearAvatarDurationVisual();
		return true;
	}
	static bool Client_70_ShowDriveVisual(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ShowDriveVisual(ID, Duration);
		return true;
	}
	static bool Client_71_PrintHoldResource(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.PrintHoldResource();
		return true;
	}
	static bool Client_72_ShootAura(GameUnit entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GameUnit Caster = default(GameUnit); if (ViGameSerializer<GameUnit>.Read(IS, out Caster) == false) { return false; }
		UInt32 AuraID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out AuraID) == false) { return false; }
		ViVector3 TargetPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out TargetPos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ShootAura(Caster, AuraID, TargetPos);
		return true;
	}
}
