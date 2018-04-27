using System;
using System.Collections.Generic;

public struct AttributeValueStruct
{
    public Int32 None;
    public Int32 HPMax;
    public Int32 MPMax;
    public Int32 SPMax;
    public Int32 HPRegenerate;
    public Int32 MPRegenerate;
    public Int32 SPRegenerate;
    public Int32 PhysicsAttack;
    public Int32 PhysicsDefence;
    public Int32 MagicAttack;
    public Int32 MagicDefence;
    public Int32 MoveSpeed;
    public Int32 CriticalHit;
    public Int32 CriticalMiss;
    public Int32 CriticalHitRate;
    public Int32 CriticalMissRate;
    public Int32 CriticalDamageAttack;
    public Int32 CriticalDamageDefence;
    public Int32 Penetrate;
    public Int32 AttackVampire;
    public Int32 AttackSpeedMultiply;
}

public class AttributeModifyStruct : ViSealedData
{
	public AttributeValueStruct Value;
}

public class GameUnitPropertyStruct : ViSealedData
{
	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public AttributeValueStruct Attribute;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class DamageInTypeStruct : ViSealedData
{

}

public class DamageOutScaleStruct : ViSealedData
{
	public struct ValueStruct
	{
		public Int32 Value;
	}
	public ViStaticArray<ValueStruct> Value = new ViStaticArray<ValueStruct>(10);
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class PlayerFirstNameStruct : ViSealedData
{

}
public class PlayerSecondMaleNameStruct : ViSealedData
{

}
public class PlayerSecondFemaleNameStruct : ViSealedData
{

}
//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class FormatStringStruct : ViSealedData
{
	public string Value;
    public override void Start()
    {
        base.Start();
        //I18NManager.Instance.Append(Name, Value);
    }
}
public class UIPanelConfigStruct : ViSealedData
{
    public string Value;
    public ViEnum32<BoolValue> IsHideDestrory;
}
public class ForbidedStringStruct : ViSealedData
{

}

//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class TimeBoardStruct : ViSealedData
{

	public Int32 Hour;
	public Int32 Minute;
	public Int32 Second;
	public Int32 Count;
	public Int32 Span;

	public string Icon;
	public string Description;
	public string Color;

	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
	public Int32 Reserve_3;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------

public class NotifyStruct : ViSealedData
{
	public string Desc;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------

public class HintStruct : ViSealedData
{
	public string Icon;
	public string Desc;
	public string Res;
	public string Script;
	public Int32 FontSize;
}

public enum EntityCategory
{
    NONE = 0,
    NORMAL_VILLAIN,
    BOSS_VILLAIN,
    NORMAL_NPC,
    PLOT_NPC,
    COLLECT_OBJECT,
    TELEPORT_OBJECT,
    TOTAL_COUNT,
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class RankRewardStruct : ViSealedData
{
	public struct RewardStruct
	{
		public ViForeignKey<LootStruct> Loot;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
		public Int32 Reserve_3;
	}

	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
	public Int32 Reserve_3;
	//
	public RewardStruct JueDou = new RewardStruct();
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class DateLoopStruct : ViSealedData
{
	public ViForeignGroup<GoalStruct> AddGoalList = new ViForeignGroup<GoalStruct>();
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class LoopDateTimeStruct : ViSealedData
{
	public ViEnum32<ViDateLoopType> Loop;
	public Int32 Day;
	public Int32 Hour;
	public Int32 Minute;
	public Int32 Second;
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(5);
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class VisualLoadingStruct : ViSealedData
{
	public struct RequestStruct
	{
		public ViValueRange Level;
		public ViForeignKey<GameFuncStruct> Func;
	}
	//
	public string Desc;
	public string Icon;
	public RequestStruct Request = new RequestStruct();
	//
	public Int32 Probability;
	public ViForeignKey<SpaceStruct> Space;
	public Int32 SpaceProbability;
}
//+---------------------------------------------------------------------------------------------------------------------------------------------------

public class ThreatStandardStruct : ViSealedData
{
	public struct AddValueStruct
	{
		public Int32 Attack;
		public Int32 Attacked;
		public Int32 Player;
		public Int32 NPC;
		public Int32 MeleeAttack;
		public Int32 RangeAttack;
	}

	public Int32 DamageScale100;
	public Int32 DistanceScale100;
	public Int32 HPReservePercScale100;
	public Int32 ChangeTargetScale;
	public AddValueStruct AddValue;
	public ViEnum32<BoolValue> Clear;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class PlayerStateConditionStruct : ViSealedData
{
	public ViMask32<PlayerStateMask> ReqMask;
	public ViMask32<PlayerStateMask> NotMask;
	public ViForeignKey<CoolingDownStruct> CD;
	public ViForeignKey<ScriptDurationStruct> Duration;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class PlayerLevelStruct : ViSealedData
{
	public string Icon;
	public Int64 XP;
	public Int32 PowerSup;
	public ViForeignGroup<GameFuncStruct> OpenFuncList = new ViForeignGroup<GameFuncStruct>();
	public ViForeignGroup<GoalStruct> AddGoalList = new ViForeignGroup<GoalStruct>();
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class PlayerPhotoStruct : ViSealedData
{
	public string Icon;
	public string Reserve0;
	public string Reserve1;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------

//added by wanglt. 2017/10/27
public class CornerListStruct : ViSealedData
{
    public UInt32 Type; //类型：1武器，2头盔，3肩膀
    public string Address;  //FBX地址
    public string Point;    //FBX挂点
    public string Icon; //FBXicon
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------

public class PlayerInitStruct : ViSealedData
{
	public struct HeroInitStruct
	{
		public ViForeignKey<HeroStruct> Hero;
		public ViForeignKey<HeroLevelStruct> Level;
		public Int32 SpellLevel;
		public ViEnum32<BoolValue> Working;
	}
	//
	public ViForeignKey<PlayerLevelStruct> Level;
	public Int32 JinPiao;
	public Int32 YinPiao;
	public Int32 BagSize;
	public ViStaticArray<HeroInitStruct> Hero = new ViStaticArray<HeroInitStruct>(10);
	public ViForeignKey<LootStruct> Loot;

    //added by wanglt. 2017/10/27
    public ViEnum32<HeroClass> Profession; //职业
    public string Description;  //职业描述
    public Int32 Skill1; //展示技能1
    public Int32 Skill2; //展示技能2
    public Int32 Skill3; //展示技能3
    public string Video1;   //职业视频1
    public string Video2;   //职业视频2
    public string Video3;   //职业视频3
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Hair_Male = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);  //初始可选发型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Hair_Female = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);    //初始可选发型, female
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Face_Male = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);  //初始可选脸型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Face_Female = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);    //初始可选脸型, female
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Hair_Male_Fight = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);    //战斗中可选发型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Hair_Female_Fight = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);  //战斗中可选发型, female
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Face_Male_Fight = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);    //战斗中可选脸型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCorner>> Face_Female_Fight = new ViStaticArray<ViForeignKeyStruct<VisualCorner>>(4);  //战斗中可选脸型, female
    public Int32 Weapon1;   //角色展示武器
    public Int32 SubWeapon1;    //角色展示副手
    public Int32 Shoulder_Male; //角色展示肩膀，男
    public Int32 Shoulder_Female;   //角色展示肩膀，女
    public Int32 Jacket_Male; //角色展示衣服，男
    public Int32 Jacket_Female;   //角色展示衣服，女
    public Int32 Pants_Male; //角色展示下身衣服，男
    public Int32 Pants_Female;   //角色展示下身衣服，女
    public Int32 Corner_Jacket_Male; //角色初始衣服，男
    public Int32 Corner_Jacket_Female;   //角色初始衣服，女
    public Int32 Corner_Pants_Male; //角色初始下身衣服，男
    public Int32 Corner_Pants_Female;   //角色初始下身衣服，女
    public Int32 MShow01;   //男性角色初始入场动作
    public Int32 GShow01;   //女性角色初始入场动作
    public Int32 MShow02;   //男性角色展示待机动作
    public Int32 GShow02;   //女性角色展示待机动作
    public Int32 MShow03;   //男性角色展示跳跃动作
    public Int32 GShow03;   //女性角色展示跳跃动作
    public Int32 MShow04;   //男性角色展示待机动作2(show03之后的)
    public Int32 GShow04;   //女性角色展示待机动作2(show03之后的)
    public string MCameraPath; //男性角色展示摄像机路径
    public string GCameraPath; //女性角色展示摄像机路径
    public string CreateLoadSound;  //创角载入音效
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class AttributeTypeStruct : ViSealedData
{
	public string PrintValue(Int32 value)
	{
		return DisplayFomat.Data.Print(value);
	}
	public string PrintValue(Int32 valueInf, Int32 valueSup)
	{
		if (valueInf == valueSup)
		{
			return DisplayFomat.Data.Print(valueInf);
		}
		else
		{
			return DisplayFomat.Data.Print(valueInf) + "~" + DisplayFomat.Data.Print(valueSup); ;
		}
	}

	public string Print(Int32 value)
	{
		return Print(value, ": ");
	}
	public string Print(Int32 value, string contactStr)
	{
		return Name + contactStr + PrintValue(value);
	}

	public ViEnum32<ModValueType> Type;
	public Int32 Reserve_0;
	public Int32 Property;
	public Int32 Reserve_1;
	public ViForeignKey<AttributeDisplayFomatStruct> DisplayFomat;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class ScoreRankPositionStruct : ViSealedData
{
	public static int Sort(ScoreRankPositionStruct info1, ScoreRankPositionStruct info2)
	{
		if (info1.ID < info2.ID)
		{
			return -1;
		}
		else if (info1.ID > info2.ID)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

	public override void Start()
	{
		ScoreRankStruct rankInfo = Rank.PData;
		if (rankInfo != null)
		{
			rankInfo.PostionList.Add(this);
		}
	}


	public ViForeignKey<ScoreRankStruct> Rank;
	public ViValueRange Value;
	public ViForeignKey<ColorStruct> Color;
	public string Icon;
	public ViForeignKey<LootStruct> Loot;
	public ViForeignKey<LootStruct> RankUpLoot;
}

public class ScoreRankStruct : ViSealedData
{
	public struct ScoreModStruct
	{
		public Int32 Base;
		public Int32 Inf;
		public Int32 Sup;
	}

	public struct MatchStruct
	{
		public Int32 StartScore;
		public ViValueRange ScoreRange;
		public Int32 Speed;
		public ScoreModStruct ModScore;
	}

	static bool PositionFormated = false;
	public static void FormatRankPosition()
	{
		if (PositionFormated)
		{
			return;
		}
		PositionFormated = true;
		List<ScoreRankStruct> list = ViSealedDB<ScoreRankStruct>.Array;
		for (int iter = 0; iter < list.Count; ++iter)
		{
			list[iter]._FormatRankPosition();
		}
	}

	void _FormatRankPosition()
	{
		ScoreRankPositionStruct pkPrePos = null;
		Int32 iLastInf = Int32.MinValue;
		List<ScoreRankPositionStruct> list = PostionList.List;
		list.Sort(ScoreRankPositionStruct.Sort);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			ScoreRankPositionStruct iterPos = list[iter];
			if (pkPrePos != null)
			{
				pkPrePos.Value.Sup = iterPos.Value.Inf - 1;
			}
			if (iLastInf >= iterPos.Value.Inf)
			{
				ViDebuger.Warning("ScoreRankPositionStruct[" + iterPos.Name + "].ValueInf < LastPos.ValueInf");
			}
			iLastInf = iterPos.Value.Inf;
			pkPrePos = iterPos;
		}
		//
		if (pkPrePos != null)
		{
			pkPrePos.Value.Sup = Int32.MaxValue;
		}
	}

	//
	public ViValueRange ScoreRange;
	public Int32 RewardHistoryCount;
	public MatchStruct Match;
	public ViForeignGroup<ScoreRankPositionStruct> PostionList = new ViForeignGroup<ScoreRankPositionStruct>();
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class MailTypeStruct : ViSealedData
{
	public ViEnum32<BoolValue> AutoDelete;
	public Int32 ExpireDay;
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------
public class ScoreStruct : ViSealedData
{
	public string Background0;
	public string Background1;
	public string ScoreIcon;
	public string Desc;
}

public class ScoreMarketItemStruct : ViSealedData
{
	public ViForeignKey<ScoreStruct> Type;
	public Int32 Price;
	public ItemCountStruct Item;
	public LoopCountStruct Count;
}
