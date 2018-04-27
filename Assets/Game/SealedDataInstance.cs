using System;
using System.Collections.Generic;

public class ViSealedDataHolder<T>
	where T : ViSealedData, new()
{
	public static implicit operator T(ViSealedDataHolder<T> data)
	{
		return data.Data;
	}
	public static implicit operator Int32(ViSealedDataHolder<T> data)
	{
		return (Int32)data.ID;
	}
	public static implicit operator UInt32(ViSealedDataHolder<T> data)
	{
		return data.ID;
	}

	public ViSealedDataHolder(UInt32 ID)
	{
		_ID = ID;
	}
	public UInt32 ID { get { return _ID; } }
	public T Data
	{
		get
		{
			if (_data == null)
			{
				_data = ViSealedDB<T>.Data(_ID);
			}
			return _data;
		}
	}

	UInt32 _ID;
	T _data;
}


//+---------------------------------------------------------------------------------------------------------------------------------------------------

public static class GameStateConditionDataInstance
{
	public static ViSealedDataHolder<ViStateConditionStruct> Attackedable = new ViSealedDataHolder<ViStateConditionStruct>(3);
}

public static class GameAuraDataInstance
{
	public static ViSealedDataHolder<ViAuraStruct> AISpaceEnter = new ViSealedDataHolder<ViAuraStruct>(1060);
	public static ViSealedDataHolder<ViAuraStruct> HeroSpaceEnter = new ViSealedDataHolder<ViAuraStruct>(2010);
}

public static class GameHitEffectVisualInstance
{
	
}

public static class GameMailTypeInstance
{
	public static ViSealedDataHolder<MailTypeStruct> DEFAULT = new ViSealedDataHolder<MailTypeStruct>(0);
	public static ViSealedDataHolder<MailTypeStruct> GM = new ViSealedDataHolder<MailTypeStruct>(1);
	public static ViSealedDataHolder<MailTypeStruct> Guild = new ViSealedDataHolder<MailTypeStruct>(2);
	public static ViSealedDataHolder<MailTypeStruct> Sytem = new ViSealedDataHolder<MailTypeStruct>(3);
	public static ViSealedDataHolder<MailTypeStruct> Reward = new ViSealedDataHolder<MailTypeStruct>(4);
}

public static class GameSpaceEventInstance
{
	public static ViSealedDataHolder<SpaceEventStruct> Start = new ViSealedDataHolder<SpaceEventStruct>(10);
	public static ViSealedDataHolder<SpaceEventStruct> SpaceCamearDistanceStart = new ViSealedDataHolder<SpaceEventStruct>(90);
	public static ViSealedDataHolder<SpaceEventStruct> SpaceCamearDistanceEnd = new ViSealedDataHolder<SpaceEventStruct>(91);
}

public static class GameVisualItemInstance
{
	public static ViSealedDataHolder<VisualItemStruct> JinZi = new ViSealedDataHolder<VisualItemStruct>(100000);
	public static ViSealedDataHolder<VisualItemStruct> JinPiao = new ViSealedDataHolder<VisualItemStruct>(100001);
	public static ViSealedDataHolder<VisualItemStruct> YinPiao = new ViSealedDataHolder<VisualItemStruct>(100002);
	public static ViSealedDataHolder<VisualItemStruct> Power = new ViSealedDataHolder<VisualItemStruct>(100003);
	public static ViSealedDataHolder<VisualItemStruct> XP = new ViSealedDataHolder<VisualItemStruct>(100006);
	public static ViSealedDataHolder<VisualItemStruct> HeroXP = new ViSealedDataHolder<VisualItemStruct>(100007);
	//
	public static ViSealedDataHolder<VisualItemStruct> CommonHeroStone = new ViSealedDataHolder<VisualItemStruct>(200000);
}

public static class GameFuncInstance
{
	public static ViSealedDataHolder<GameFuncStruct> Default = new ViSealedDataHolder<GameFuncStruct>(0);
	//public static ViSealedDataHolder<GameFuncStruct> BackToLogin = new ViSealedDataHolder<GameFuncStruct>(0);
	//public static ViSealedDataHolder<GameFuncStruct> ItemUse = new ViSealedDataHolder<GameFuncStruct>(0);
	//public static ViSealedDataHolder<GameFuncStruct> ItemDestroy = new ViSealedDataHolder<GameFuncStruct>(0);
	//
	public static ViSealedDataHolder<GameFuncStruct> Mail = new ViSealedDataHolder<GameFuncStruct>(100);
	public static ViSealedDataHolder<GameFuncStruct> Friend = new ViSealedDataHolder<GameFuncStruct>(110);
	public static ViSealedDataHolder<GameFuncStruct> Rank = new ViSealedDataHolder<GameFuncStruct>(120);
	public static ViSealedDataHolder<GameFuncStruct> Goal = new ViSealedDataHolder<GameFuncStruct>(140);
	public static ViSealedDataHolder<GameFuncStruct> Chat = new ViSealedDataHolder<GameFuncStruct>(11300);
	//
	public static ViSealedDataHolder<GameFuncStruct> Trade = new ViSealedDataHolder<GameFuncStruct>(10000);
	//
	public static ViSealedDataHolder<GameFuncStruct> Market = new ViSealedDataHolder<GameFuncStruct>(10100);
	//
	public static ViSealedDataHolder<GameFuncStruct> Guild = new ViSealedDataHolder<GameFuncStruct>(10200);
	//
	public static ViSealedDataHolder<GameFuncStruct> Party = new ViSealedDataHolder<GameFuncStruct>(10400);
	public static ViSealedDataHolder<GameFuncStruct> PublicSpaceEnter = new ViSealedDataHolder<GameFuncStruct>(10450);
	//
	public static ViSealedDataHolder<GameFuncStruct> Shop = new ViSealedDataHolder<GameFuncStruct>(10500);
	//
	public static ViSealedDataHolder<GameFuncStruct> Hero = new ViSealedDataHolder<GameFuncStruct>(10600);
	public static ViSealedDataHolder<GameFuncStruct> Hero_Upgrade = new ViSealedDataHolder<GameFuncStruct>(10610);
	//
	public static ViSealedDataHolder<GameFuncStruct> Space = new ViSealedDataHolder<GameFuncStruct>(10800);
	//
	public static ViSealedDataHolder<GameFuncStruct> Item = new ViSealedDataHolder<GameFuncStruct>(10900);
	//
	public static ViSealedDataHolder<GameFuncStruct> Payment = new ViSealedDataHolder<GameFuncStruct>(11000);
	//
	public static ViSealedDataHolder<GameFuncStruct> Welfare = new ViSealedDataHolder<GameFuncStruct>(11900);
	//
	public static ViSealedDataHolder<GameFuncStruct> Recharge = new ViSealedDataHolder<GameFuncStruct>(12100);
}

public static class GameSealedDataTypeInstance
{
	public static ViSealedDataHolder<ViSealedDataTypeStruct> NormalAttack = new ViSealedDataHolder<ViSealedDataTypeStruct>(10000);
	public static ViSealedDataHolder<ViSealedDataTypeStruct> HomeGoal = new ViSealedDataHolder<ViSealedDataTypeStruct>(20000);
}

public static class GameGuildPositionInstance
{
	public static ViSealedDataHolder<GuildPositionStruct> Default = new ViSealedDataHolder<GuildPositionStruct>(0);
	public static ViSealedDataHolder<GuildPositionStruct> Leader = new ViSealedDataHolder<GuildPositionStruct>(100);
	public static ViSealedDataHolder<GuildPositionStruct> Vice = new ViSealedDataHolder<GuildPositionStruct>(90);
	
}

public static class GameAvatarDurationVisualInstance
{
	public static ViSealedDataHolder<ViAvatarDurationVisualStruct> SpaceSlotHide = new ViSealedDataHolder<ViAvatarDurationVisualStruct>(100);
}

public static class GameUIMusicInstance
{
	public static ViSealedDataHolder<MusicStruct> Login = new ViSealedDataHolder<MusicStruct>(100);
	public static ViSealedDataHolder<MusicStruct> Main = new ViSealedDataHolder<MusicStruct>(110);
	public static ViSealedDataHolder<MusicStruct> PartyMatch = new ViSealedDataHolder<MusicStruct>(140);
	public static ViSealedDataHolder<MusicStruct> CustomRoom = new ViSealedDataHolder<MusicStruct>(150);
}

public static class GameHintInstance
{
	public static ViSealedDataHolder<HintStruct> FightUseSpell = new ViSealedDataHolder<HintStruct>(30000);
}

public static class GamePathFileResInstance
{
	public static ViSealedDataHolder<PathFileResStruct> Default = new ViSealedDataHolder<PathFileResStruct>(10001);
    public static ViSealedDataHolder<PathFileResStruct> Focus_Enemy = new ViSealedDataHolder<PathFileResStruct>(10109);
    public static ViSealedDataHolder<PathFileResStruct> Attack_Area = new ViSealedDataHolder<PathFileResStruct>(10110);
	public static ViSealedDataHolder<PathFileResStruct> Spell_Area = new ViSealedDataHolder<PathFileResStruct>(10111);
    public static ViSealedDataHolder<PathFileResStruct> MaterialInstance = new ViSealedDataHolder<PathFileResStruct>(10200);
    public static ViSealedDataHolder<PathFileResStruct> CubemapOnLogin = new ViSealedDataHolder<PathFileResStruct>(10210);
    public static ViSealedDataHolder<PathFileResStruct> LoginScene = new ViSealedDataHolder<PathFileResStruct>(3000000);
}

public static class GameValueMappingInstance
{
	public static ViSealedDataHolder<ViValueMappingStruct> ControllerMoveSpeedScale = new ViSealedDataHolder<ViValueMappingStruct>(30);
}

