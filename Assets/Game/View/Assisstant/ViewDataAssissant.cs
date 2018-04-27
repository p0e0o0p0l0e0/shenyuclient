using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UInt8 = System.Byte;

#region GameUnitProperty
public static class View_PropertyPrintAssissant
{
	#region Hero Attribute
	public static void PrintHeroAttribute(GameUnitIndexProperty property, HeroStruct heroInfo, bool splitValue, ref string nameStr, ref string valueStr)
	{
		List<string> nameList = new List<string>();
		List<string> valueList = new List<string>();
		PrintHeroAttribute(property, heroInfo, splitValue, nameList, valueList);
		nameStr = StandardAssisstant.Combine(nameList, string.Empty, string.Empty, "\n");
		valueStr = StandardAssisstant.Combine(valueList, string.Empty, string.Empty, "\n");
	}
	public static void PrintHeroAttribute(GameUnitIndexProperty property, HeroStruct heroInfo, bool splitValue, List<string> nameStrList, List<string> valueStrList)
	{
        /*
		string name = string.Empty;
		string value = string.Empty;
		if (PrintHeroAttribute(AttributeIndex.HPMax, ModValueType.VALUE, property.HPMax0, property.HPMax1, property.HPMax2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		// attack
		if (PrintHeroAttribute(AttributeIndex.AttackPower, ModValueType.VALUE, property.AttackPower0, property.AttackPower1, property.AttackPower2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		// 防
		if (PrintHeroAttribute(AttributeIndex.DefencePower, ModValueType.VALUE, property.DefencePower0, property.DefencePower1, property.DefencePower2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		// 暴击
		if (PrintHeroAttribute(AttributeIndex.CriticalPower, ModValueType.VALUE, property.CriticalPower0, property.CriticalPower1, property.CriticalPower2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		// 暴击倍数
		if (PrintHeroAttribute(AttributeIndex.CriticalOutScale, ModValueType.VALUE, property.CriticalOutScale0 + 10000, property.CriticalOutScale1, property.CriticalOutScale2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		// Ex
		int attrValue = 0;
		attrValue = property.DamageOut0 + property.DamageOut1 + property.DamageOut2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageOut, ModValueType.VALUE, property.DamageOut0, property.DamageOut1, property.DamageOut2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageOutScale0 + property.DamageOutScale1 + property.DamageOutScale2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageOutScale, ModValueType.VALUE, property.DamageOutScale0, property.DamageOutScale1, property.DamageOutScale2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageIn0 + property.DamageIn1 + property.DamageIn2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageIn, ModValueType.VALUE, property.DamageIn0, property.DamageIn1, property.DamageIn2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageInScale0 + property.DamageInScale1 + property.DamageInScale2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageInScale, ModValueType.VALUE, property.DamageInScale0, property.DamageInScale1, property.DamageInScale2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageOutRecoverHPRating0 + property.DamageOutRecoverHPRating1 + property.DamageOutRecoverHPRating2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageOutRecoverHPRating, ModValueType.VALUE, property.DamageOutRecoverHPRating0, property.DamageOutRecoverHPRating1, property.DamageOutRecoverHPRating2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageOutRecoverHPScale1 + property.DamageOutRecoverHPScale1 + property.DamageOutRecoverHPScale2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageOutRecoverHPScale, ModValueType.VALUE, property.DamageOutRecoverHPScale1, property.DamageOutRecoverHPScale1, property.DamageOutRecoverHPScale2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageOutRecoverHP0 + property.DamageOutRecoverHP1 + property.DamageOutRecoverHP2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageOutRecoverHP, ModValueType.VALUE, property.DamageOutRecoverHP0, property.DamageOutRecoverHP1, property.DamageOutRecoverHP2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageInReflectionRating0 + property.DamageInReflectionRating1 + property.DamageInReflectionRating2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageInReflectionRating, ModValueType.VALUE, property.DamageInReflectionRating0, property.DamageInReflectionRating1, property.DamageInReflectionRating2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageInReflectionScale0 + property.DamageInReflectionScale1 + property.DamageInReflectionScale2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageInReflectionScale, ModValueType.VALUE, property.DamageInReflectionScale0, property.DamageInReflectionScale1, property.DamageInReflectionScale2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
		attrValue = property.DamageInReflection0 + property.DamageInReflection1 + property.DamageInReflection2;
		if (attrValue > 0 && PrintHeroAttribute(AttributeIndex.DamageInReflection, ModValueType.VALUE, property.DamageInReflection0, property.DamageInReflection1, property.DamageInReflection2, splitValue, out name, out value))
		{
			nameStrList.Add(name);
			valueStrList.Add(value);
		}
        */
	}

	static bool PrintHeroAttribute(AttributeIndex attrIdx, ModValueType type, int value0, int value1, int value2, bool splitValue, out string nameStr, out string valueStr)
	{
		if (splitValue)
		{
			string contactStr = " +";
			if (Print(attrIdx, type, value0, out nameStr, out valueStr))
			{
				string valueEx = string.Empty;
				if (value1 + value2 > 0)
				{
					valueEx = PrintValue(attrIdx, type, value1 + value2);
					valueEx = ColorUtil.Format(contactStr + valueEx, ColorUtil.GREEN);
					//
					if (value0 == 0)
					{
						valueStr = string.Empty;
					}
				}
				//
				valueStr += valueEx;
				return true;
			}
			else
			{
				nameStr = string.Empty;
				valueStr = string.Empty;
				return false;
			}
		}
		else
		{
			if (Print(attrIdx, type, value0 + value1 + value2, out nameStr, out valueStr))
			{
				return true;
			}
			else
			{
				nameStr = string.Empty;
				valueStr = string.Empty;
				return false;
			}
		}
	}
	#endregion

	public static bool Print(AttributeIndex attrIdx, ModValueType type, Int32 value, out string nameStr, out string valueStr)
	{
		AttributeTypeStruct info = GetAttributeInfo(attrIdx, type);
		if (info != null)
		{
			nameStr = info.Name;
			valueStr = info.PrintValue(value);
			return true;
		}
		else
		{
			nameStr = string.Empty;
			valueStr = string.Empty;
			return false;
		}
	}
	public static string Print(AttributeIndex attrIdx, ModValueType type, Int32 value, string contactStr)
	{
		AttributeTypeStruct info = GetAttributeInfo(attrIdx, type);
		if (info != null)
		{
			return info.Print(value, contactStr);
		}
		return string.Empty;
	}
	public static string PrintValue(AttributeIndex attrIdx, ModValueType type, Int32 value)
	{
		AttributeTypeStruct info = GetAttributeInfo(attrIdx, type);
		if (info != null)
		{
			return info.PrintValue(value);
		}
		return string.Empty;
	}

	public static AttributeTypeStruct GetAttributeInfo(AttributeIndex attrIdx, ModValueType type)
	{
		Cache();
		for (int iter = 0; iter < _attributeInfos.Count; ++iter)
		{
			AttributeTypeStruct iterInfo = _attributeInfos[iter];
			if (iterInfo.Type.Value == (Int32)type && iterInfo.Property == (Int32)attrIdx)
			{
				return iterInfo;
			}
		}
		return null;
	}

	static void Cache()
	{
		if (!_hasInit)
		{
			_attributeInfos = ViSealedDB<AttributeTypeStruct>.Array;
			_hasInit = true;
		}
	}

	static bool _hasInit = false;
	static List<AttributeTypeStruct> _attributeInfos;
}

#endregion

#region Item

public struct ItemOutput
{
	public UInt32 Item;
	public ScoreStruct Score;
	public bool ScoreEnable;
	public SpaceStruct Space;
	public bool SpaceEnable;
	public int OutputCount;
}

public static class View_ItemAssisstant
{
	public static readonly string[] ItemTypeNames = new string[]
	{
	"垃圾",
	"防具",
	"时装",
	"消耗品",
	"原料",
	"宝石",
	"礼包",
	"经验卡",
	"英雄卡",
	"英雄碎片",
	"英雄经验卡",
	"Q版英雄经验卡",
	"物品碎片",
	"银票卡",
	"金票卡",
	"体力卡",
	"离线竞技场声望卡",
	"友情点数卡",
	"任务卷轴",
	"VIP卡",
	"Loot碎片",
	"连珠",
	"升级丹",
	"游戏激活卡",
	"地图门票",
	"协力战创建卷轴",
	"协力战进入卷轴",
	"魔术对决卷轴",
	};



	public static string GetItemAttribute(ItemStruct item)
	{
		if (item == null)
		{
			return string.Empty;
		}
		ItemValueStruct valueInfo = item.Value.PData;
		if (valueInfo == null)
		{
			return string.Empty;
		}
		string text = string.Empty;
		for (int iter = 0; iter < valueInfo.Value.Length; ++iter)
		{
			AttributeModValueStruct iterValue = valueInfo.Value[iter];
			AttributeTypeStruct iterInfo = iterValue.Type.PData;
			if (iterInfo == null)
			{
				continue;
			}
			if (!string.IsNullOrEmpty(text))
			{
				text += "\n";
			}
			text += iterInfo.Name + " +" + iterValue.Value.ToString();
		}
		return text;
	}

    public static ItemStruct GetItemStruct(int id)
	{
        var item = ViSealedDB<ItemStruct>.Data(id);
        if (item.Null())
		{
            Debug.LogError(string.Format("get itemstruct error   id {0} not exit", id));
			return new ItemStruct();
		}
        return item;
	}

    public static ItemType GetItemType(int id)
    {
        return (ItemType) GetItemStruct(id).Type.Value;
    }

	public static void CalcItemSpaceOutput(VisualItemStruct item, List<ItemOutput> outputList)
	{
		for (int iter = 0; iter < item.Output.ScoreMarketArray.Length; ++iter)
		{
			VisualItemStruct.OutputStruct.ScoreMarketStruct scoreMarket = item.Output.ScoreMarketArray[iter];
			ScoreStruct score = scoreMarket.Score.PData;
			if (score != null)
			{
				ItemOutput output = new ItemOutput();
				output.Item = (UInt32)item.ID;
				output.Score = score;
				output.ScoreEnable = Player.Instance.IsFunctionOpen(scoreMarket.ReqFunc.PData);
				outputList.Add(output);
			}
		}
		//
		List<SpaceStruct> spaceInfoList = ViSealedDB<SpaceStruct>.Array;
		for (int iter = 0; iter < spaceInfoList.Count; ++iter)
		{
			SpaceStruct info = spaceInfoList[iter];
			VisualSpaceStruct visualInfo = ViSealedDB<VisualSpaceStruct>.Data(info.ID);
			//
			int count = 0;
			if (visualInfo.OutputItem((UInt32)item.ID, out count))
			{
				ItemOutput output = new ItemOutput();
				output.Item = (UInt32)item.ID;
				output.Space = info;
				output.SpaceEnable = PlayerPropertyAssisstant.SpaceEnterable(Player.Instance.Property, output.Space);
				output.OutputCount = count;
				outputList.Add(output);
			}
		}
		//
		outputList.Sort(_OutputSort);
	}
	static int _OutputSort(ItemOutput data1, ItemOutput data2)
	{
		Int64 weight1 = _GetOutputWeight(data1);
		Int64 weight2 = _GetOutputWeight(data2);
		if (weight1 > weight2)
		{
			return -1;
		}
		else if (weight1 < weight2)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
	static Int64 _GetOutputWeight(ItemOutput output)
	{
		Int64 statWeight = 10000000000;
		Int64 value = 0;
		if (output.Score != null)
		{
			if (output.ScoreEnable)
			{
				value += statWeight;
			}
			else
			{
				value += statWeight / 10000;
			}
		}
		if (output.Space != null)
		{
			if (output.SpaceEnable)
			{
				value += statWeight / 100;
			}
			else
			{
				value += statWeight / 1000000;
			}
			value += output.OutputCount;
		}
		return value;
	}

}
#endregion

#region Hero & Q_Kid
public static class View_HeroAssisstant
{
	public static ViConstValue<List<Int32>> VALUE_HeroXPStoneList = new ViConstValue<List<Int32>>("HeroXPStoneList", new List<Int32>() { 120000, 120010, 120020, });


	public static List<HeroStruct> HeroList
	{
		get
		{
			if (_heroList == null || _heroList.Count <= 0)
			{
				ViSealedDB<HeroStruct>.IncludeZero = false;
				_heroList = ViSealedDB<HeroStruct>.Array;
			}
			return _heroList;
		}
	}
	static List<HeroStruct> _heroList = null;

	public static int Sort(HeroStruct hero1, HeroStruct hero2)
	{
		Int64 weight1 = _GetWeight(hero1);
		Int64 weight2 = _GetWeight(hero2);
		if (weight1 > weight2)
		{
			return -1;
		}
		else if (weight1 < weight2)
		{
			return 1;
		}
		else
		{
			if (hero1.ID < hero2.ID)
			{
				return -1;
			}
			else if (hero1.ID > hero2.ID)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}

	static Int64 _GetWeight(HeroStruct hero)
	{
		Int64 weight = 0;
		Int64 factor = 100;
		//
		ReceiveDataHeroProperty property;
		bool have = Player.Instance.Property.HeroList.TryGetValue((UInt32)hero.ID, out property);
		int count = Player.Instance.GetItemCount(hero.Request.kItem.Item);
		if (!have && count >= hero.Request.kItem.Count)
		{
			weight += START_WEIGHT;
		}
		//
		if (have)
		{
			weight += START_WEIGHT / factor;
			weight += property.FightPower;
		}
		return weight;
	}

	public static int Sort2(HeroWatcher hero1, HeroWatcher hero2)
	{
		if (hero1.Quality > hero2.Quality)
		{
			return -1;
		}
		else if (hero1.Quality < hero2.Quality)
		{
			return 1;
		}
		else
		{
			if (hero1.Level > hero2.Level)
			{
				return -1;
			}
			else if (hero1.Level < hero2.Level)
			{
				return 1;
			}
			else
			{
				if (hero1.Key < hero2.Key)
				{
					return -1;
				}
				else if (hero1.Key > hero2.Key)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}
	}

	static readonly Int64 START_WEIGHT = 10000000000;
    static readonly string NonDefineClass = "NonDefineClass";
    public static string ToHeroClass(this int hero,bool talent)
    {
        switch (hero)
        {
            case (int)HeroClass.Cleric:
                if (!talent)
                    return I18NManager.Instance.GetWord("Profession9");
                else
                    return I18NManager.Instance.GetWord("Profession10");
            case (int)HeroClass.Fighter:
                if (!talent)
                    return I18NManager.Instance.GetWord("Profession1");
                else
                    return I18NManager.Instance.GetWord("Profession2");
            case (int)HeroClass.Ranger:
                if (!talent)
                    return I18NManager.Instance.GetWord("Profession5");
                else
                    return I18NManager.Instance.GetWord("Profession6");
            case (int)HeroClass.Rogue:
                if (!talent)
                    return I18NManager.Instance.GetWord("Profession11");
                else
                    return I18NManager.Instance.GetWord("Profession12");

            case (int)HeroClass.Wizard:
                if (!talent)
                    return I18NManager.Instance.GetWord("Profession7");
                else
                    return I18NManager.Instance.GetWord("Profession8");
            case (int)HeroClass.Knight:
                if (!talent)
                    return I18NManager.Instance.GetWord("Profession3");
                else
                    return I18NManager.Instance.GetWord("Profession4");
            default:
                throw new ArgumentOutOfRangeException("hero", hero, null);
        }
        //return NonDefineClass;
    }
}

#endregion

#region  Friend
public static class View_FriendAssisstant
{
	public static int Sort(FriendWatcher friend1, FriendWatcher friend2)
	{
		if (friend1.ViewProperty.ClientState < friend2.ViewProperty.ClientState)
		{
			return -1;
		}
		else if (friend1.ViewProperty.ClientState > friend2.ViewProperty.ClientState)
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}

}
#endregion
