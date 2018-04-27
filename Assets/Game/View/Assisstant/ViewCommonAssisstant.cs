using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CommonAssisstant
{
	/// <summary>
	/// return count string. return string.Empty if count <= 1;
	/// </summary>
	public static string FormatItemCount(int count)
	{
		return count > 1 ? count.ToString() : string.Empty;
	}

	public static string FormatCountWithColor(int countHave, int countTarget)
	{
		string color = countHave >= countTarget ? ColorUtil.GREEN : ColorUtil.RED;
		return ColorUtil.Format(countHave.ToString() + "/" + countTarget.ToString(), color);
	}

	public static string FormatReserveWithColor(int reserve, int total)
	{
		string color = reserve > 0 ? ColorUtil.WITHE : ColorUtil.RED;
		return ColorUtil.Format(reserve.ToString() + "/" + total.ToString(), color);
	}

	public static string FormatMoneyWithColor(Int64 countHave, Int64 countTarget)
	{
		string color = countHave >= countTarget ? ColorUtil.WITHE : ColorUtil.RED;
		return ColorUtil.Format(countTarget.ToString(), color);
	}

	public static string FormatLevelText(int level)
	{
		return "Lv." + level.ToString();
	}

	public static string FomatOnlineState(PlayerClientState state, Int64 currentTime, Int64 lastActiveTime)
	{
		string stateStr = ColorUtil.Format(CommonTextAssisstant.Online, ColorUtil.GREEN);
		if (state == PlayerClientState.OFFLINE)
		{
			Int64 reserve = currentTime - lastActiveTime;
			string text = FormatTime.Print(reserve, 1);
			stateStr = CommonTextAssisstant.OfflineTime.Print(text);
		}
		return stateStr;
	}
}


public static class CommonTextAssisstant
{
	public static ViFomatString ALL = new ViFomatString("全部");
	public static ViFomatString Free = new ViFomatString("免费");

	//
	public static ViFomatString CountString = new ViFomatString("× &");
	//
	public static ViFomatString OK = new ViFomatString("确定");
	public static ViFomatString CANCEL = new ViFomatString("取消");
	public static ViFomatString Voucher = new ViFomatString("充值");
	//
	public static ViFomatString Return2Login = new ViFomatString("返回登陆");
	public static ViFomatString ExitGame = new ViFomatString("退出游戏");
	//
	public static ViFomatString FightPower = new ViFomatString("战力:&");
	//
	public static ViFomatString XP = new ViFomatString("经验");
	public static ViFomatString YinPiao = new ViFomatString("老虎币");
	public static ViFomatString JinPiao = new ViFomatString("晶石");
	public static ViFomatString JinZi = new ViFomatString("晶石");
	public static ViFomatString Power = new ViFomatString("体力");
	public static ViFomatString FakeAneraScore = new ViFomatString("积分");
	public static ViFomatString FakeAneraHonor = new ViFomatString("对决积分");
	public static ViFomatString PowerCost = new ViFomatString("体力消耗:&");
	//
	public static ViFomatString ChannelWorld = new ViFomatString("世界");
	public static ViFomatString ChannelGuild = new ViFomatString("公会");
	//
	public static ViFomatString Confrim_ExitSpace = new ViFomatString("退出战斗将失去已获得的副本奖励!\n是否退出副本?");
	public static ViFomatString Confrim_BuyItem = new ViFomatString("是否要购买该商品?");
	//
	public static ViFomatString Confrim_DelFriend = new ViFomatString("是否要删除该好友?");
	//
	public static ViFomatString ConfirmText_HeroXPStone = new ViFomatString("等级达到上限，继续将浪费多余经验！");
	public static ViFomatString ConfirmText_FuncNotOpen = new ViFomatString("功能暂未开放！");
	//
	public static ViFomatString Apply = new ViFomatString("申请");
	public static ViFomatString ApplyCancel = new ViFomatString("取消申请");
	//++++++++++++++++++++++++++++++++++
	public static ViFomatString GuildEvent_Enter = new ViFomatString("&加入公会!");
	public static ViFomatString GuildEvent_Exit = new ViFomatString("&退出了公会!");
	public static ViFomatString GuildEvent_Contribute = new ViFomatString("&捐献&给公会!");
	public static ViFomatString GuildEvent_LevelUp = new ViFomatString("哇喔, 公会等级上升!");
	public static ViFomatString GuildEvent_PositionUpdate = new ViFomatString("哇喔, &成为&!");
	//
	public static ViFomatString GuildMemberOperate_Scan = new ViFomatString("查看信息");
	public static ViFomatString GuildMemberOperate_HandOverLeader = new ViFomatString("禅让会长");
	public static ViFomatString GuildMemberOperate_PositonUpdate = new ViFomatString("提升副会");
	public static ViFomatString GuildMemberOperate_RemovePosition = new ViFomatString("解除职位");
	public static ViFomatString GuildMemberOperate_Fire = new ViFomatString("踢出公会");
	//
	public static ViFomatString Confrim_FireGuildMember = new ViFomatString("是否要踢走该公会成员?");
	public static ViFomatString Confrim_HandOverGuildLeader = new ViFomatString("是否要禅让会长给该公会成员?");
	public static ViFomatString Confrim_UpGuildPosition = new ViFomatString("是否要将该公会成员提升为副会长?");
	public static ViFomatString Confrim_RemoveGuildPosition = new ViFomatString("是否要解除该公会成员的职位?");

	//++++++++++++++++++++++++
	public static ViFomatString Time_Before = new ViFomatString("&前");
	public static ViFomatString Time_After = new ViFomatString("后");
	public static ViFomatString Time_Nearly = new ViFomatString("刚刚");
	public static ViFomatString Time_TimeOut = new ViFomatString("过期");
	//+++++++++
	public static ViFomatString Online = new ViFomatString("在线");
	public static ViFomatString Offline = new ViFomatString("离线");
	public static ViFomatString OfflineTime = new ViFomatString("离线&");
}

