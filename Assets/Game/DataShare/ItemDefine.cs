using System;

public enum ItemType
{
    JUNK,/// 垃圾
    ARMOR, ///装备
    CONSUMABLE,//生命药水
    MAGIC_ITEM, //魔法药水
    BUFF_ITEM, //BUFF药水
    DRAWING, //图纸
    XP_STONE,//主角经验
    MOUNT,//坐骑
    RIDING,//骑术
    GIFT,//礼包
    MAKE_STONE,//打造材料
    ENHANCE_STONE,//强化石
    GEM,//宝石
    DRESS, ///时装
	ELEMENT, ///原料
    GOALITEM, //任务道具
    //HERO_STONE,//英雄卡
    //HERO_FRAGMENT,//英雄碎片
    HERO_XP_STONE,//英雄经验卡
	HERO_KID_XP_STONE,//英雄卡通形象经验卡
	ITEM_FRAGMENT,//物品碎片
	YINPIAO_STONE,// 银票卡
	JINPIAO_STONE,// 金票卡
	POWER_STONE, // 体力卡
	FAKE_ARENA_HONR_STONE,// 离线竞技场声望
	FRIEND_HONR_STONE, // 好友点数
	QUEST_STONE,//任务卷轴
	VIP_STONE,// VIP卡
	LOOT_FRAGMENT,//Loot碎片
	LINK_STONE,//连珠
	LEVEL_UP_STONE,//升级丹
	CDKEY_STONE,// 游戏激活卡
	SPACE_TICKET,// 地图门票
	PRIVATE_SHARE_SPACE_CREATE_STONE,// 协力战创建卷轴
	PRIVATE_SHARE_SPACE_ENTER_STONE,// 协力战进入卷轴
	FAKE_ARENA_STONE,// 魔术对决卷轴
    TOTAL,
}

public enum PlayerEquipSlotType
{
	WEAPON, //武器	
	HELMET, //帽子	
	SHOULDER, //护肩		
	CLOAK, //披风	
	BODY, //护胸	
	HAND, //手套	
	WAIST, //腰带	
	LEG, //护腿	
	SHOES, //鞋子
	RING, //戒指
	WING, //翅膀
	NECKLACE, //项链	
	ACCESSORY, //饰品
	DRESS,//时装
    RIGHTWEAPON,//副手
    RESERVE_0,
	Face,
	Fair,
	TOTAL,
}

public enum PlayerEquipSlot
{
	WEAPON, //武器	
	HELMET, //帽子	
	SHOULDER, //护肩
	CLOAK, //披风		
	BODY, //护胸	
	HAND, //手套	
	WAIST, //腰带	
	LEG, //护腿	
	SHOES, //鞋子	
	RING_0, //戒指
	RING_1, //戒指
	WING, //翅膀
	NECKLACE_0, //项链0	
	NECKLACE_1, //项链1	
	ACCESSORY_0, //饰品
	ACCESSORY_1, //饰品
	DRESS,//时装
    RIGHTWEAPON,//副手
    RESERVE_0,
	RESERVE_1,
	RESERVE_2,
	TOTAL,
}

public enum ItemSpellType
{
	DEFAULT, ///无
	CAST,///使用触发
}

public enum ItemUseType
{
	NONE,
	USE,
}
