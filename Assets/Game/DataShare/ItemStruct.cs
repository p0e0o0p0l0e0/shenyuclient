using System;

public enum ItemQualityEnum
{
    NONE = 0,
    WHITE,
    BLUE,
    PURPLE,
    ORANGE,
}

public class ItemQualityStruct: ViSealedData
{
	public string Icon;
    public ViEnum32<ItemQualityEnum> ItemQualityEnum;
}

public struct ItemUseCostStruct
{
	public MoneyStruct Money;
	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
}

public struct ItemUseReqStruct
{
	public ViForeignKey<PlayerStateConditionStruct> StateCondition;
	public ViMask32<Gender> GenderMask;
	public Int32 Level;
	public Int32 Reserve_0;
	public ViForeignKey<GameFuncStruct> Func;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
}

public struct ItemUseStruct
{
	public LoopCountStruct Count;
	public ViEnum32<ItemUseType> UseType;
	public ItemUseReqStruct Request;
	public ViEnum32<ItemSpellType> SpellType;
	public ViForeignKey<ViSpellStruct> Spell;
	public ViForeignKey<ScriptDurationStruct> ScriptDuration;
	public ViForeignKey<CoolingDownStruct> CoolChannel;
	public ItemUseCostStruct Cost;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
}

public class ItemValueStruct : ViSealedData
{
	public ViStaticArray<AttributeModValueStruct> Value = new ViStaticArray<AttributeModValueStruct>(41);
}

public class ItemStruct: ViSealedData
{
	public bool IsFragment()
	{
		switch ((ItemType)Type.Value)
		{
			//case ItemType.HERO_FRAGMENT:
			case ItemType.ITEM_FRAGMENT:
				return true;
			default:
				return false;
		}
	}

	public ViEnum32<ItemType> Type;
	public Int32 Level;
	public ViForeignKey<ItemQualityStruct> Quality;
	public ViEnum32<PlayerEquipSlotType> EquipSlot;
	public ItemUseStruct Use;
	public Int32 m_iReserve_1;
	public Int32 m_iReserve_2;
	public Int32 SalePrice;
	//
	public Int32 Stackable;
	public Int32 DelayTime;
	public Int32 Duration;
	public ViEnum32<BoolValue> Dropable;
	public Int32 BroadcastLevel;
    public ViEnum32<BoolValue> IsShowBag;
    //
    public Int32 TradeMaxCount;
	public Int32 BuyMaxCount;
	public Int32 ReceiveMaxCount;
    //
    public ViForeignKey<ItemValueStruct> Value;
	//
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
    ViEnum32<HeroClass> HeroLimit;
}
