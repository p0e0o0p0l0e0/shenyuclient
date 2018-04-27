using System;

static class ConstValue
{
	public const int SELF_SCALE = 0X01;
	public const int ROUND_SCALE = 0X1000;
}

public enum ViSpellSelectRalationMask
{

	SELF_MASK = 0XFFF,
	ROUND_MASK = 0XFFF000,

	THIS_SELF = ViUnitSocietyMask.SELF * ConstValue.SELF_SCALE,
	THIS_FRIEND = ViUnitSocietyMask.FRIEND * ConstValue.SELF_SCALE,
	THIS_ENEMY = ViUnitSocietyMask.ENEMY * ConstValue.SELF_SCALE,
	THIS_NEUTRAL = ViUnitSocietyMask.NEUTRAL * ConstValue.SELF_SCALE,
	THIS_TEAM = ViUnitSocietyMask.TEAM * ConstValue.SELF_SCALE,

	ROUND_SELF = ViUnitSocietyMask.SELF * ConstValue.ROUND_SCALE,
	ROUND_FRIEND = ViUnitSocietyMask.FRIEND * ConstValue.ROUND_SCALE,
	ROUND_ENEMY = ViUnitSocietyMask.ENEMY * ConstValue.ROUND_SCALE,
	ROUND_NEUTRAL = ViUnitSocietyMask.NEUTRAL * ConstValue.ROUND_SCALE,
	ROUND_TEAM = ViUnitSocietyMask.TEAM * ConstValue.ROUND_SCALE,

	POS = ViUnitSocietyMask.GROUND,

}
public class GetSpellSelectRelationMask
{
	public static UInt32 SelfMask(UInt32 mask)
	{
		return ViMask32.Value(mask, (UInt32)(ViSpellSelectRalationMask.SELF_MASK));
	}
	public static UInt32 RoundMask(UInt32 mask)
	{
		return ViMask32.Value(mask, (UInt32)(ViSpellSelectRalationMask.SELF_MASK)) >> 12;
	}
}

public enum ViEffectSign
{
	NONE,
	GOOD,
	BAD,
}

public enum ViEffectCreateType
{
	CASTED = 0,
	AUTO = 3,
}

public enum ViAuraDurationOverlap
{
	RESET,
	ADD,
	CLOSE_OLD,
	NONE,
}

public enum ViSpellActionType
{
	NONE_ACTION,
	ACTION,
}



public enum ViHitEffectTemplate
{
	NONE,
	BASE,//! 基本
	DISPEL_AURA_BYTYPE,//! 净化_AURA
	DISPEL_AURA_BYSIGN,//! 净化_AURA
	TRANSIT_ATTR,//!! 传递属性
	TRANSPORT_TARGET,
	CHARGE_TARGET,
	RADIATE,
	AREA,
	SUP,
}

//+---------------------------------------------------------------------------------------
public enum ViAuraTemplate
{
	NONE,
	BASE,
	VALUE_MOD,
	VALUE_TICK,
	VALUE_INHERIT,
	VALUE_MAPPING,
	RADIATE,
	AREA,
	SUP,
}

//+-----------------------------------------------------------------------------
public enum ViSpellTravelType
{
	NONE,
	SPELL_TARGET,
	SUP,
}

public enum ViSpellLogType
{
	LOG,
	NONE,
}

public enum ViSpellFlyType
{
    OUT_OF_CAMERA,
    PARABOLA,
    ORIGIN_OBLIQUE_SPRINT,
    TARGET_OBLIQUE_SPRINT,
}