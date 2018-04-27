using System;


public enum HitEffectTemplate
{
	DMG = ViHitEffectTemplate.SUP,
	FACTION_SCORE,
	HERO_XP,
    HIT_BACK,
    HIT_FLY,
    SUMMON,
    TARGETPOS_HITBACK, // 使目标位移 相对施法者位置的位移
    CLASH, // 施法者撞目标 相对目标位置的位移
    CLONE_ATK, // 分身攻击
    SUP,
}

public enum AuraTemplate
{
	DAMAGE = ViAuraTemplate.SUP,
	DIS_DAMAGE,
	AVATAR,//!
	EQUIP_VISUAL,
	PVP_PROPERTY,
	DAMAGE_IN_DIS_SCALE,
	CHANGE_FACTION,
    HIT_FLY,
    SILENCE,
    PEROID_SPELL_EFFECT,
    SPELL_EFFECT_BY_COUNT,
    SUP,
}

public enum AuraStateMask
{
	SILENCE = 0X01,// 沉默
	CURSE = 0X02,// 诅咒
	INVISIBABLE = 0X04,// 隐身
    RAGE = 0X08,// 狂暴
    WHOSYOURDADDY = 0X10,// 无敌
}

public enum SpellAction
{
	ENTER_ATTACK = 0X01,
	EXIT_ATTACK = 0X02,

}
