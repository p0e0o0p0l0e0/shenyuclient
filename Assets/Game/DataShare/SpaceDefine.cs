using System;

public enum SpaceType
{
	BIG_SPACE,
	BIG_SPACE_MIRROR,
	SMALL_SPACE_PVE,
	SMALL_SPACE_PVP,
	DISPLAY,
}

public enum SpaceTypeMask
{
	BIG_SPACE = 0X01,
	BIG_SPACE_MIRROR = 0X02,
	SMALL_SPACE_PVE = 0X04,
	SMALL_SPACE_PVP = 0X08,
	DISPLAY = 0X10,
}

public enum SpaceEnterMask
{
	MATCH_PVE = 0X01,
	MATCH_PVP = 0X02,
	MATCH_PVA = 0X04,
	MATCH_GVG = 0X08,
	ROOM_PRIVATE = 0X10,
	ROOM_GUILD = 0X20,
	ROOM_GM = 0X40,
	STORY = 0X80,
	DISCOVER = 0X100,
}

public enum GameSpaceState
{
	DEACTIVE,
	ACTIVE,
	END,
}

public enum SpaceStateMask
{
	BIG_SPACE = 0X01,
	PRIVATE = 0X02,
	PK = 0X04,
	PVP = 0X08,
	PVE = 0X10,
	COMPETITIVE = 0x20,
}

public enum SpaceVisibilityMask
{
	FUNCTION = 0X01,
	BUILDING = 0X02,
	FIGHT = 0X04,
	SOUL = 0X08,
	PLAYER_0 = 0X10,
	PLAYER_1 = 0X20,
	PLAYER_2 = 0X40,
}

public enum SpaceVisibilityLevel
{
	DEFAULT = 0,
	MONSTOR = 10,
	PLAYER = 20,
	AREA_AURA = 60,
	BOSS = 70,
	FUNCTION = 100,
}

public enum SpaceRevivePosType
{
	ENTER_POS,
	LOCAL_POS,
	TOTAL,
}

public enum SpaceReviveType
{
	NORMAL,
	RMB,
	AUTO,
	TOTAL,
}

public enum SpaceReviveMask
{
	NORMAL = 0X01,
	RMB = 0X02,
	AUTO = 0X04,
}

public enum SpaceBirthControllerState
{
	WAITING,
	PRE_BORN,
	AFT_BORN,
	DIE_OUT,
	SUP,
}

public enum SpaceBirthControllerResult
{
	BREAK,
	COMPLETE,
}

public enum SpaceBirthControllerEndType
{
	NONE,
	CLEAR_LIVE_COUNT,
	DIE_OUT,
	ERASE,
}

public enum SpaceBirthControllerActionMask
{
	ENTER_POS = 0X01,
}

public enum SpaceEntityBroadcastType
{
	NONE,
	SPACE,
	FACTION,
	FACTION_AOI,
}

public enum SpacePKType
{
	PLAYER_NEUTRAL_ZONE,
	PLAYER_FRIEND_ZONE,
	PLAYER_ENEMY_ZONE,
	FACTION_ZONE,
	TEAM_ZONE,
	TOTAL,
}

public enum SpaceHeroSelectType
{
	NONE,
	FACTION,
	ALL,
}