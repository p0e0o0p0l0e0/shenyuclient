using System;


public enum TangercyType
{
	POINT,
	LINE,
	PLANE,
}

public enum ExpressFadeType
{
	ATTACH,
	WORLD,
}

public enum UnityLayer
{
	DEFAULT = 0,

	WATER = 4,

	UI = 5,

	GROUND = 8,
	GROUND_ALPHA,
	SCENE,
	SCENE_ALPHA,
	ENTITY,
	ENTITY_EXPLORE,
	ENTITY_PICK,
	CLICK,
	LOOT,
	CAMERA_COLLIDE,

	ENTITY_LOW = 19,
    UI_Invisible = 20,
    UI_Model = 21,
    UI_Video = 22,
    Story = 23,
    RTT_HERO = 25,
	RTT_KAN_BAN_NIANG,
	RTT_LOGIN_SABER,
	RTT_LOGIN_SHILANG,

	SUP,

    LAYER_REF_PLANE = 1 << 30,
    LAYER_TEST_SHADOW = 1 << 31,


    ALL = (1 << SUP) - 1,
	RTT = (1 << RTT_HERO) + (1 << RTT_KAN_BAN_NIANG) + (1 << RTT_LOGIN_SABER) + (1 << RTT_LOGIN_SHILANG),
	MIRROR_SHADOW_MASK = 1 << ENTITY_LOW,
	DARK_SCENE_VIEW_MASK = (1 << GROUND) + (1 << GROUND_ALPHA) + (1 << SCENE) + (1 << SCENE_ALPHA) + (1 << WATER),
	SCENE_VIEW_MASK = ALL - (1 << UI) - RTT - (1 << ENTITY_LOW)-(1 << UI_Invisible) - (1 << UI_Model),
}

public enum ExpressAttachMask
{
	WORLD = 0X01,
	UP = 0X02,
	NO_ROTATE = 0X04,
	FREE = 0X08,
    FORCE_ZERO = 0x10,
}

public enum ShaderQueueLayer
{
	AVATARINTERFACE = 2449,
	BUILDING_HIDE = 3100
}

public static class GameObjectNodeName
{
	public static readonly string Weist = "Bip001 Spine";
	public static readonly string Fire = "Fire";
	public static readonly string BodyLow = "BodyLow";
}
