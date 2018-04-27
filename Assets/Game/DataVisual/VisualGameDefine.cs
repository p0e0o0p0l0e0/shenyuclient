using System;

public enum VisualProgressMask
{
	SLIDER = 0x01,
	NUMBER = 0x02,
	QUEST_SLIDER = 0x04,
}

public enum EntityMessagePositionMask
{
	CHAT_BOX = 0X01,
	CENTER = 0X02,
	MOUSE0 = 0X04,
	MOUSE1 = 0X08,
	SPACE = 0X10,
	CONFIRM = 0X20,
	CONFIRM_CANCEL = 0X40,
	VOUCHER = 0X80,
	VIP = 0X100,
	LOCALPLAYER = 0X200,
	GOTITEM = 0X400,
}

public enum DurationVisualType
{
	NONE,
	ANIMATION,
	ANIMATION_SCALE,
	ANIMATION_REPLACE,
	SCALE,
	HIDE,
	HIDERENDER,
	CAMERA_FIELD,
	REPLACE_MATERIAL,
	HEXAGON_RANDOM,
	HEXAGON,
	TRANSPARENTRIM,
	SCREEN_GRAY,
	HP_PERC_AVATAR,
}

public enum DurationVisualChannel
{
	NONE,
	MOTION_BLUR,
	SCREEN_COLOR,
	ANIMATION,
	ANIMATION_SCALE,
	ANIMATION_REPLACE,
	SCALE,
	COLOR,
	CAMERA_FIELD,
	COLOR_MATERIAL,
	AVATAR_GHOST,
	SPELL_UI_EFFECT,
}

public enum AvatarAttachNode
{
	ROOT,
	BOTTOM,
	MIDDLE,
	CHEST,
	TOP,
	LEFT_WEAPON,
	RIGHT_WEAPON,
	FIRE,
	FOLLOW_01,
	FOLLOW_02,

    ZS_wuqi, //主武器
    ZS_wuqi_01,//副武器
    TOTAL,
}

public static class AvatarAttachNodeName
{
	public static string[] AttachNodeNameList = 
	{
	"Bip001 Pelvis",//ROOT
	"foot",//BOTTOM
	"CenterPoint",//MIDDLE
	"ChestPoint",//CHEST
	"TopPoint",//TOP
	"HandWeapon_L",//LEFT_WEAPON
	"right",//RIGHT_WEAPON
	"Fire",//FIRE
	"EffPoint01",//FOLLOW_01
	"EffPoint02",//FOLLOW_02
	};
}

public enum SpellPositionSelectType
{
	POS,
	YAW,
	SELF,
}

public enum AvatarDestroyType
{
	DEFAULT,
	DROP,
	EXIT,
	DISSOLVE,
}
public enum AutoFocusType
{
    MINHP,
    MAXHP,
    MINDISTANCE,
    MAXDISTANCE,
}