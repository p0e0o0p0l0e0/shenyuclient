using System;
using System.Collections.Generic;


public class LootItem1Struct : ViSealedData
{
	public struct NodeStruct
	{
		public float GetProbability() { return ProbabilityQW * 0.0000001f; }
		//
		public Int32 ProbabilityQW;
		public ItemCountStruct Item;
	}
    //
    public ViEnum32<HeroClass> TargetHeroClass = new ViEnum32<HeroClass>(6);
	public ViStaticArray<NodeStruct> List = new ViStaticArray<NodeStruct>(10);
}

public class LootItem2Struct : ViSealedData
{
	public float GetProbability() { return ProbabilityQW * 0.0000001f; }
    //
    public ViEnum32<HeroClass> TargetHeroClass;
    public Int32 ProbabilityQW;
	public Int32 Count;
	public ViEnum32<BoolValue> NotRepeat;
	public ViStaticArray<ProbabilityValue2<ItemCountRangeStruct>> Item = new ViStaticArray<ProbabilityValue2<ItemCountRangeStruct>>(10);
}

public class LootItem3Struct : ViSealedData
{
	public float GetProbability() { return ProbabilityQW * 0.0000001f; }
    //
    public ViEnum32<HeroClass> TargetHeroClass;
    public Int32 ProbabilityQW;
	public Int32 Count;
	public ViEnum32<BoolValue> NotRepeat;
	public ViStaticArray<ProbabilityValue2<ItemCountRangeStruct>> Item = new ViStaticArray<ProbabilityValue2<ItemCountRangeStruct>>(100);
}

public struct LootItem4Struct
{
	public float GetProbability() { return ProbabilityQW * 0.0000001f; }
	public Int32 ProbabilityQW;
	public ViValueRange ReqLevel;
	public ItemCountRangeStruct Item;
}

public class LootItem5Struct:  ViSealedData
{
    public ViEnum32<HeroClass> TargetHeroClass;
    public ViStaticArray<LootItem4Struct> Item = new ViStaticArray<LootItem4Struct>(10);
}

public class LootItem6Struct: ViSealedData
{
    public ViEnum32<HeroClass> TargetHeroClass;
    public ViStaticArray<LootItem4Struct> Item = new ViStaticArray<LootItem4Struct>(100);
}

public class LootScaleStruct: ViSealedData
{
	public Int32 Scale;
	public Int32 XPScale;
	public Int32 YinPiaoScale;
	public Int32 JinPiaoScale;
	public Int32 HeroXPScale;
}

public class LootStruct : ViSealedData
{
	public struct RequreStruct
	{
		public ViValueRange Level;
	}

	public struct OnceLootStruct
	{
		public ViEnum32<BoolValue> ClearOther;
		public ViForeignKey<LootStruct> Loot;
	}

	public struct CDLootStruct
	{
		public ViForeignKey<CoolingDownStruct> CoolingDown;
		public ViForeignKey<LootStruct> Loot;
	}

	public struct ActivityLootStruct
	{
		public ViForeignKey<ActivityScriptStruct> Activity;
		public ViForeignKey<LootStruct> Loot;
	}

	public void Roll(Int16 level, Int16 playerLevel, out Int32 yinPiao, out Int32 jinPiao, out Int32 playerXP, out Int32 heroXP)
	{
		Roll(level, playerLevel, 1.0f, out yinPiao, out jinPiao, out playerXP, out heroXP);
	}
	public void Roll(Int16 level, Int16 playerLevel, float scale, out Int32 yinPiao, out Int32 jinPiao, out Int32 playerXP, out Int32 heroXP)
	{
		yinPiao = 0;
		jinPiao = 0;
		playerXP = 0;
		heroXP = 0;
		//
		AddRoll(scale, ref yinPiao, ref jinPiao, ref playerXP, ref heroXP);
		//
		LootStruct levelLootInfo = LevelLootStart.GetData(level);
		if (levelLootInfo != null)
		{
			levelLootInfo.AddRoll(scale, ref yinPiao, ref jinPiao, ref playerXP, ref heroXP);
		}
		//
		LootStruct playerLevelLootInfo = PlayerLevelLootStart.GetData(playerLevel);
		if (playerLevelLootInfo != null)
		{
			playerLevelLootInfo.AddRoll(scale, ref yinPiao, ref jinPiao, ref playerXP, ref heroXP);
		}
	}
	void AddRoll(float scale, ref Int32 yinPiao, ref Int32 jinPiao, ref Int32 playerXP, ref Int32 heroXP)
	{
		yinPiao += ViMathDefine.IntNear(YinPiao.Value * scale);
		jinPiao += ViMathDefine.IntNear(JinPiao.Value * scale);
		heroXP += ViMathDefine.IntNear(HeroXP.Value * scale);
	}

	public void GetFixItem(Int16 level, Int16 playerLevel, List<ItemCountProperty> itemList)
	{
		GetFixItem(level, playerLevel, 1.0f, itemList);
	}
	public void GetFixItem(Int16 level, Int16 playerLevel, float scale, List<ItemCountProperty> itemList)
	{
		AddFixItem(scale, itemList);
		//
		LootStruct levelLootInfo = LevelLootStart.GetData(level);
		if (levelLootInfo != null)
		{
			levelLootInfo.AddFixItem(scale, itemList);
		}
		//
		LootStruct playerLevelLootInfo = PlayerLevelLootStart.GetData(playerLevel);
		if (playerLevelLootInfo != null)
		{
			playerLevelLootInfo.AddFixItem(scale, itemList);
		}
	}

	void AddFixItem(float scale, List<ItemCountProperty> itemList)
	{
		LootItem1Struct item1 = Item1.PData;
		if (item1 == null)
		{
			return;
		}
		for (int iter = 0; iter < item1.List.Length; ++iter)
		{
			LootItem1Struct.NodeStruct iterItem = item1.List[iter];
			if (!iterItem.Item.IsEmpty() && iterItem.ProbabilityQW >= 10000000)
			{
				ItemCountProperty itemCount = new ItemCountProperty();
				itemCount.Info = iterItem.Item.Item;
				itemCount.Count = ViMathDefine.IntNear(iterItem.Item.Count * scale);
				itemList.Add(itemCount);
			}
		}
	}

	public void PrintVisualItem(Int16 level, Int16 playerLevel, List<ItemCountProperty> itemList)
	{
		PrintVisualItem(level, playerLevel, 1.0f, itemList);
	}
	public void PrintVisualItem(Int16 level, Int16 playerLevel, float scale, List<ItemCountProperty> itemList)
	{
		int yinPiao = 0;
		int jinPiao = 0;
		int playerXP = 0;
		int heroXP = 0;
		Roll(level, playerLevel, scale, out yinPiao, out jinPiao, out playerXP, out heroXP);
		if (yinPiao > 0)
		{
			ItemCountProperty itemCount = new ItemCountProperty();
			itemCount.Info.Set(GameVisualItemInstance.YinPiao);
			itemCount.Count = yinPiao;
			itemList.Add(itemCount);
		}
		if (jinPiao > 0)
		{
			ItemCountProperty itemCount = new ItemCountProperty();
			itemCount.Info.Set(GameVisualItemInstance.JinPiao);
			itemCount.Count = jinPiao;
			itemList.Add(itemCount);
		}
		if (playerXP > 0)
		{
			ItemCountProperty itemCount = new ItemCountProperty();
			itemCount.Info.Set(GameVisualItemInstance.XP);
			itemCount.Count = playerXP;
			itemList.Add(itemCount);
		}
		if (heroXP > 0)
		{
			ItemCountProperty itemCount = new ItemCountProperty();
			itemCount.Info.Set(GameVisualItemInstance.HeroXP);
			itemCount.Count = heroXP;
			itemList.Add(itemCount);
		}
		//
		GetFixItem(level, playerLevel, itemList);
	}

	public RequreStruct Requre = new RequreStruct();
	public ViForeignKey<ActivityScriptStruct> ActivityScaleInfo;
	public ViForeignKey<LootScaleStruct> ActivityScaleValue;
	public ViValueRange YinPiao;
	public ViValueRange JinPiao;
	public ViForeignKey<ScoreStruct> ScoreType;
	public ViValueRange ScoreValue;
	public ViValueRange HeroXP;
	public ViForeignKey<MessageBoxStruct> MessageBox;
	public Int32 BroadcastLevel;
	public ViForeignKey<ColorStruct> Color;
	public string Icon;
	public string Desc;
	public ItemCountStruct FloorItem;
	public ViForeignKey<LootItem1Struct> Item1;
	public ViStaticArray<ViForeignKeyStruct<LootItem2Struct>> Item2 = new ViStaticArray<ViForeignKeyStruct<LootItem2Struct>>(6);
	public ViStaticArray<ViForeignKeyStruct<LootItem3Struct>> Item3 = new ViStaticArray<ViForeignKeyStruct<LootItem3Struct>>(6);
	public ViStaticArray<ViForeignKeyStruct<LootItem5Struct>> Item5 = new ViStaticArray<ViForeignKeyStruct<LootItem5Struct>>(6);
	public ViStaticArray<ViForeignKeyStruct<LootItem6Struct>> Item6 = new ViStaticArray<ViForeignKeyStruct<LootItem6Struct>>(6);
	public ViForeignKey<LootStruct> LevelLootStart;
	public ViForeignKey<LootStruct> PlayerLevelLootStart;
	public OnceLootStruct OnceLoot;
	public CDLootStruct CDLoot;
	public ActivityLootStruct ActivityLoot = new ActivityLootStruct();

    public Int32 XPLevelFactor;
    public Int32 XPLevelConstant;
    public Int32 QuestAdventureXP;
    public Int32 QuestAdventureCoin;
}

