using System;

public enum GuildEventType
{
	ENTER,// [&]加入行会
	EXIT,// [&]退出行会
	CONTRIBUTE_YINPIAO,// [&]捐献[&]银票
	CONTRIBUTE_JINPIAO,// [&]捐献[&]金票
	CONTRIBUTE_BADGE,// [&]捐献[&]徽章
	LEVEL_UP,// 行会升级
	POSITION_UPDATE,// [&]成为[&]

	QUEST_COMPLETE = 40,

	BLESS_LINGTA_0 = 50,
	BLESS_LINGTA_1,
	BLESS_LINGTA_2,

	BLESS_TOTEM_0 = 60,
	BLESS_TOTEM_1,
	BLESS_TOTEM_2,

	GVG_SPACE_RESULT_WIN = 70,// [&]中战胜对手
	GVG_SPACE_RESULT_LOSE,// [&]中输给对手

}

public enum GuildActivityType
{
	NONE,
	SPACE,
	MATCH,
	TOTAL,
}

public enum GuildResponseType
{
	NONE,
	AGREE,
	DISAGREE,
};