using System;

public enum ModValueType
{
	VALUE,
	SCALE10000,
	SPELL,
}

public enum AttributeIndex
{
    None,
    HPMax,
    MPMax,
    SPMax,
    HPRegenerate,
    MPRegenerate,
    SPRegenerate,
    PhysicsAttack,
    PhysicsDefence,
    MagicAttack,
    MagicDefence,
    MoveSpeed,
    CriticalHit,
    CriticalMiss,
    CriticalHitRate,
    CriticalMissRate,
    CriticalDamageAttack,
    CriticalDamageDefence,
    Penetrate,
    AttackVampire,
    AttackSpeedMultiply,
    Total,
}

public enum AttributeValueType
{
	VALUE_0,// 基础
	VALUE_1,// 装备
	VALUE_2,// 静态额外值
	VALUE_3,// 属性平衡额外值
	VALUE_4,// 战斗额外值
    VALUE_5,// 战斗额外值
}

public enum Platform
{
	WEB,
	CLIENT,
	MOBILE,
	TOTAL,
}

public enum PlayerCreateResult
{
	SUCCESS,
	FAIL_NAME_EMPTY,
	FAIL_NAME_USED,
	FAIL_NAME_RESERVE,
	FAIL_NAME_LEN,
	FAIL_MAX_PLAYER,
}

public enum Gender
{
	MALE,
	FEMALE,
	TOTAL,
	SIZE = 18,
}

public enum HeroClass
{
    Cleric,
    Fighter,
    Ranger,
    Rogue,
    Wizard,
    Knight,
    All,
}

public enum PartyType
{ 
    OUTDOOR = 0,    //野外
    ADVENTURE,	//冒险者任务

    COPY,   //副本
    COPY1,       //...
    COPY2,       //...
    COPY3,
    COPY4,
    COPY5,
    ALL = 999999,   //不指定，相当于All,不往服务器传递
    NEARBY = 999998
}

public enum Faction
{
	FRIEND,
	NEUTRAL,
	ENEMY,
	PLAYER_FRIEND,
	PLAYER_0,
	PLAYER_1,
	PLAYER_2,
	TOTAL,
}


public enum Occupation
{
    NONE,
    WARRIOR,//战士
    KNIGHT,//骑士	
    MASTER,//法师

    //盗贼
    //牧师
    //

    TOTAL,
}

public enum FactionMask
{
	FRIEND = 0X01,
	NEUTRAL = 0X02,
	ENEMY = 0X04,
	PLAYER_FRIEND = 0X08,
	PLAYER_0 = 0X10,
	PLAYER_1 = 0X20,
	PLAYER_2 = 0X40,
}

public enum EntityRelationType
{
	FRIEND,
	ENEMY,
	NEUTRAL,
	TOTAL,
}

public enum ChatChannelType
{
	SYSTEM,
	WORLD,
	FACTION,
	GUILD,
	SPACE,
	SPACE_FACTION,
	SELF,
	FIGHT,
	ROOM,
	PARTY,
	TOTAL,
}

public enum ClientControllerState
{
	ACTIVE,
	LOSING,
	OFFLINE,
}

public enum MailState
{
	UN_READED,
	READED,
	JUNK,
	TOTAL,
}

public enum MoneyType
{
	YINZI,
	YINPIAO,
	JINZI,
	JINPIAO,
	TOTAL,
}

public enum ActivityState
{
	DEACTIVE,
	ACTIVE,
}


public enum GMRecordBroadcastRange
{
	ONLINE,
	ALL,
}

public enum PlayerClientState
{
	ACTIVE,
	LOSING,
	OFFLINE,
	TOTAL,
}

public enum LoginResult
{
	OK,
	ERROR_VERSION,
	ERROR_ACCOUNT,
	NEW_LOGIN,
	WAITING,
	INDULGE,
	DISABLE_ACCOUNT,
	DISABLE_IP,
}

public enum UnitNatureType
{
	HERO,
	MONSTER,
	BOSS,
	MINION,
	POT,
	BUILDING,
	TOTAL,
}

public enum UnitNatureMask
{
	HERO = 0X01,
	MONSTER = 0X02,
	BOSS = 0X04,
	MINION = 0X08,
	POT = 0X10,
	BUILDING = 0X20,
}

public enum GameUnitEntityType
{
	NONE,
	GAME_UNIT,
	NPC,
	HERO,
}

public enum GameUnitEntityMask
{
	GAME_UNIT = 0X01,
	NPC = 0X02,
	HERO = 0X04,
}

public enum ActionStateMask
{
	DURING_COMBAT = 0X01,
	ATTACKING = 0X02,
	DEAD = 0X04,
	BATTLING = 0X08,
	SOUL = 0X10,
	PROTECTED = 0X20,
	FLY = 0X40,
	AOI_WATCHED = 0X80,
	RESERVE_8 = 0X100,
	MOVING = 0X200,
    PRONE = 0x400,
	SWOON = 0X800,

	RESERVE_0 = 0X1000,
	DIS_SPACE_CHANGE = 0X2000,
	DIS_ATTACK = 0X4000,
	DIS_DEAD = 0X8000,
	DIS_DAMAG = 0X10000,
	DIS_DAMAGED = 0X20000,
	DIS_MOVE = 0X40000,
	DIS_TURN = 0X80000,
	DIS_HP_RECOVER = 0X100000,
	DIS_MOUNT = 0X200000,
	DIS_HANDLE_CONTROL = 0X400000,
	DIS_EQUIP_DURABILITY = 0X800000,
	RESERVE_4 = 0X1000000,
	DIS_OPERATE_SERVANT = 0X2000000,
	DIS_REVIVE = 0X4000000,
	DIS_LISTEN = 0X8000000,

	END_ATTACK = 0X10000000,
	END_ATTACKED = 0X20000000,

}

public static class ActionStateDescription
{
	public static string Desc(UInt32 state)
	{
		switch ((ActionStateMask)state)
		{
			case ActionStateMask.DURING_COMBAT: return "缠斗状态";
			case ActionStateMask.ATTACKING: return "战斗状态";
			case ActionStateMask.DEAD: return "死亡状态";
			case ActionStateMask.BATTLING: return "战斗状态";
			case ActionStateMask.SOUL: return "灵魂状态";
			case ActionStateMask.PROTECTED: return "新手保护";
			case ActionStateMask.FLY: return "飞行状态";
			case ActionStateMask.MOVING: return "移动";
			case ActionStateMask.SWOON: return "眩晕";
			case ActionStateMask.DIS_SPACE_CHANGE: return "禁止切换地图";
			case ActionStateMask.DIS_ATTACK: return "禁止攻击";
			case ActionStateMask.DIS_DEAD: return "禁止死亡";
			case ActionStateMask.DIS_DAMAGED: return "禁止被伤害";
			case ActionStateMask.DIS_MOVE: return "禁止移动";
			case ActionStateMask.DIS_HP_RECOVER: return "禁止使用生命恢复药剂";
			case ActionStateMask.DIS_MOUNT: return "禁止坐骑";
			case ActionStateMask.DIS_HANDLE_CONTROL: return "禁止手动操作";
			case ActionStateMask.DIS_OPERATE_SERVANT: return "禁止操作伙伴";
			case ActionStateMask.DIS_REVIVE: return "禁止复活";
			case ActionStateMask.END_ATTACK: return "结束攻击";
			case ActionStateMask.END_ATTACKED: return "结束被攻击";
			default: return string.Empty;
		}
	}
	public static string ReqFailDesc(UInt32 state)
	{
		switch ((ActionStateMask)state)
		{
			case ActionStateMask.DURING_COMBAT: return "只有在缠斗状态才能使用";
			case ActionStateMask.ATTACKING: return "只有在战斗状态才能使用";
			case ActionStateMask.DEAD: return "只有在死亡状态才能使用";
			case ActionStateMask.SOUL: return "只有在灵魂状态下才能";
			case ActionStateMask.PROTECTED: return "只有在新手保护状态才能使用";
			case ActionStateMask.FLY: return "只有在飞行状态才能使用";
			case ActionStateMask.MOVING: return "只有在移动中才能使用";
			default: return string.Empty;
		}
	}
	public static string NotFailDesc(UInt32 state)
	{
		switch ((ActionStateMask)state)
		{
			case ActionStateMask.DURING_COMBAT: return "缠斗状态下不能使用";
			case ActionStateMask.ATTACKING: return "战斗状态下不能使用";
			case ActionStateMask.DEAD: return "死亡状态下不能使用";
			case ActionStateMask.SOUL: return "灵魂状态下不能使用";
			case ActionStateMask.PROTECTED: return "新手保护状态下不能使用";
			case ActionStateMask.FLY: return "飞行状态下不能使用";
			case ActionStateMask.MOVING: return "移动中不能使用";
			case ActionStateMask.SWOON: return "眩晕";
			case ActionStateMask.DIS_SPACE_CHANGE: return "禁止切换地图";
			case ActionStateMask.DIS_ATTACK: return "禁止攻击";
			case ActionStateMask.DIS_DEAD: return "禁止死亡";
			case ActionStateMask.DIS_DAMAGED: return "禁止被伤害";
			case ActionStateMask.DIS_MOVE: return "禁止移动";
			case ActionStateMask.DIS_HP_RECOVER: return "禁止使用生命恢复药剂";
			case ActionStateMask.DIS_MOUNT: return "禁止坐骑";
			case ActionStateMask.DIS_OPERATE_SERVANT: return "禁止操作伙伴";
			case ActionStateMask.DIS_REVIVE: return "禁止复活";
			case ActionStateMask.END_ATTACK: return "结束攻击";
			case ActionStateMask.END_ATTACKED: return "结束被攻击";
			default: return string.Empty;
		}
	}
}

public enum AttackType
{
	MELEE,
	RANGE,
	NONE,
	TOTAL,
}

public enum AttackResult
{
	DEFAULT,
	MISS, // 丢失
	DODGE, // 闪避
	CRITICAL,
	BLOCK, // 格挡
	TOTAL,
}

public enum PlayerStateMask
{
	OFFLINE = 0X01,
	MATCH = 0X02,
	ROOM = 0X04,
	DIS_CHANGE_SPACE = 0X08,
	GUILD_ACTIVITY_SEAT = 0X10,
}

public static class PlayerStateMaskDescription
{
	public static string Desc(UInt32 state)
	{
		switch ((PlayerStateMask)state)
		{
			case PlayerStateMask.OFFLINE: return "离线状态";
			case PlayerStateMask.MATCH: return "匹配状态";
			case PlayerStateMask.ROOM: return "房间状态";
			case PlayerStateMask.DIS_CHANGE_SPACE: return "不可切换地图状态";
			case PlayerStateMask.GUILD_ACTIVITY_SEAT: return "行会活动报名状态";
			default: return string.Empty;
		}
	}
	public static string ReqFailDesc(UInt32 state)
	{
		switch ((PlayerStateMask)state)
		{
			case PlayerStateMask.OFFLINE: return "只有在离线状态才能使用";
			case PlayerStateMask.MATCH: return "只有在匹配状态才能使用";
			case PlayerStateMask.ROOM: return "只有在房间状态才能使用";
			case PlayerStateMask.DIS_CHANGE_SPACE: return "只有在不可切换地图状态才能使用";
			case PlayerStateMask.GUILD_ACTIVITY_SEAT: return "只有在行会活动报名状态才能使用";
			default: return string.Empty;
		}
	}
	public static string NotFailDesc(UInt32 state)
	{
		switch ((PlayerStateMask)state)
		{
			case PlayerStateMask.OFFLINE: return "离线状态不能使用";
			case PlayerStateMask.MATCH: return "匹配状态不能使用";
			case PlayerStateMask.ROOM: return "房间状态不能使用";
			case PlayerStateMask.DIS_CHANGE_SPACE: return "不可切换地图状态不能使用";
			case PlayerStateMask.GUILD_ACTIVITY_SEAT: return "行会活动报名状态不能使用";
			default: return string.Empty;
		}
	}
}

public enum MatchSpaceType
{
	NONE,
	PVE,
	PVP,
	PVA,
	GVG,
}

public enum ClientDevicePlatform
{
	ANDROID,
	IOS,
}
