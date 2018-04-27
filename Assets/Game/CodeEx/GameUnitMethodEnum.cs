using System;

public enum GameUnitClientMethod
{
	INF = ViGameUnitClientMethod.SUP,
	METHOD_0_OnMoveTo = INF,
	METHOD_1_OnMoveTo,
	METHOD_2_OnBreakMove,
	METHOD_3_OnBreakMove,
	METHOD_4_OnUpdateYaw,
	METHOD_5_OnUpdatePosYaw,
	METHOD_6_OnChargeTo,
	METHOD_7_OnChargeTo,
	METHOD_8_OnChargeTo,
	METHOD_9_OnChargeTo,
	METHOD_10_OnAimChargeTo,
	METHOD_11_OnAimChargeTo,
	METHOD_12_OnTransportTo,
	METHOD_13_OnTransportTo,
	METHOD_14_OnFlyTo,
	METHOD_15_FixTimeFlyTo,
	METHOD_16_SetBodyVisiable,
	METHOD_17_OnWorldSay,
	METHOD_18_OnWorldSay,
	METHOD_19_CloseWorldSay,
	METHOD_20_CloseWorldSay,
	METHOD_21_OnDamageHited,
	METHOD_22_OnDie,
	METHOD_23_OnRevive,
	METHOD_24_OnSoul,
	METHOD_25_OnShotStart,
	METHOD_26_OnShotEnd,
	METHOD_27_OnShotRecover,
	METHOD_28_OnBulletStart,
	METHOD_29_OnBulletStart,
	METHOD_30_OnBulletEnd,
	METHOD_31_OnBulletClear,
	METHOD_32_OnMeleeAttackOnce,
	METHOD_33_OnSpellPrepare,
	METHOD_34_OnSpellPrepare,
	METHOD_35_OnSpellCast,
	METHOD_36_OnSpellCast,
	METHOD_37_OnSpellCast,
	METHOD_38_OnSpellCast,
	METHOD_39_OnSpellCastStart,
	METHOD_40_OnSpellCastStart,
	METHOD_41_OnSpellCastEnd,
	METHOD_42_OnCancelSpell,
	METHOD_43_OnBreakSpell,
	METHOD_44_OnSpellEnd,
	METHOD_45_OnCastTo,
	METHOD_46_OnCastTo,
	METHOD_47_OnCastTo,
	METHOD_48_OnCastFrom,
	METHOD_49_OnHitVisual,
	METHOD_50_OnHitVisual,
	METHOD_51_OnHitVisual,
	METHOD_52_OnHitVisualShadow,
	METHOD_53_OnLinkVisualStart,
	METHOD_54_OnLinkVisualStart,
	METHOD_55_OnLinkVisualEnd,
	METHOD_56_OnLinkVisualEndFrom,
	METHOD_57_OnLinkVisualEndTo,
	METHOD_58_OnLinkVisualOnce,
	METHOD_59_OnLinkVisualOnce,
	METHOD_60_PlayActionAnim,
	METHOD_61_PlayStateAnim,
	METHOD_62_StopStateAnim,
	METHOD_63_OnCastVisual,
	METHOD_64_OnCastVisual,
	METHOD_65_OnHitEffectVisual,
	METHOD_66_OnHitEffectVisual,
	METHOD_67_OnAreaHitEffectVisual,
	METHOD_68_AddAvatarDurationVisual,
	METHOD_69_ClearAvatarDurationVisual,
	METHOD_70_ShowDriveVisual,
	METHOD_71_PrintHoldResource,
	METHOD_72_ShootAura,
	SUP,
}
public enum GameUnitServerMethod
{
	INF = ViGameUnitServerMethod.SUP,
	METHOD_0_SetValue32 = INF,
	METHOD_1_ModValue32,
	METHOD_2_SetScriptValue,
	METHOD_3_ClearScriptValue,
	METHOD_4_ClearReferencePtr,
	METHOD_5_ClearReferencePtr,
	METHOD_6_SetWeapon,
	METHOD_7_SetBullet,
	METHOD_8_Spell,
	METHOD_9_Spell,
	METHOD_10_Spell,
	METHOD_11_AddAura,
	METHOD_12_AddAura,
	METHOD_13_CloseAura,
	METHOD_14_CloseAllAura,
	METHOD_15_CloseAuraByChannel,
	METHOD_16_CloseAuraBySpell,
	METHOD_17_AddAreaAura,
	METHOD_18_AddHitEffect,
	METHOD_19_AddSpellEffect,
	METHOD_20_SetDefaultVisibilityMask,
	METHOD_21_AddVisibilityMask,
	METHOD_22_DelVisibilityMask,
	METHOD_23_SetDynamicVisibilityChannel,
	METHOD_24_SetFaction,
	METHOD_25_AddFaction,
	METHOD_26_DelFaction,
	METHOD_27_SetLevel,
	METHOD_28_Revive,
	METHOD_29_SendSpaceEvent,
	METHOD_30_SendSpaceEvent,
	METHOD_31_EraseSpaceEventCache,
	METHOD_32_AddSpaceBlockSlot,
	METHOD_33_DelSpaceBlockSlot,
	METHOD_34_SetSpaceBlockSlotState,
	METHOD_35_KillSpaceBlockSlot,
	METHOD_36_AddSpaceHideSlot,
	METHOD_37_DelSpaceHideSlot,
	METHOD_38_SetSpaceHideSlotState,
	METHOD_39_KillSpaceHideSlot,
	METHOD_40_ClearSpellCD,
	METHOD_41_ClearSpellCD,
	METHOD_42_AddSpellCD,
	SUP,
}
