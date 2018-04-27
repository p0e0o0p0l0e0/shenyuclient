using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public struct Int8Property
{
	public Int8 Value;
}
public struct UInt8Property
{
	public UInt8 Value;
}
public struct Int16Property
{
	public Int16 Value;
}
public struct UInt16Property
{
	public UInt16 Value;
}
public struct Int32Property
{
	public Int32 Value;
}
public struct UInt32Property
{
	public UInt32 Value;
}
public struct Int64Property
{
	public Int64 Value;
}
public struct UInt64Property
{
	public UInt64 Value;
}
public struct FloatProperty
{
	public float Value;
}
public struct StringProperty
{
	public ViString Value;
}
public struct Int8PtrProperty
{
	public ViNormalDataPtr<Int8Property> Ptr;
}
public struct UInt8PtrProperty
{
	public ViNormalDataPtr<UInt8Property> Ptr;
}
public struct Int16PtrProperty
{
	public ViNormalDataPtr<Int16Property> Ptr;
}
public struct UInt16PtrProperty
{
	public ViNormalDataPtr<UInt16Property> Ptr;
}
public struct Int32PtrProperty
{
	public ViNormalDataPtr<Int32Property> Ptr;
}
public struct UInt32PtrProperty
{
	public ViNormalDataPtr<UInt32Property> Ptr;
}
public struct UInt64PtrProperty
{
	public ViNormalDataPtr<UInt64Property> Ptr;
}
public struct StringPtrProperty
{
	public ViNormalDataPtr<StringProperty> Ptr;
}
public struct TimeProperty
{
	public Int64 Value;
}
public struct Time1970Property
{
	public Int64 Value;
}
public struct LoopCountProperty
{
	public Int32 Count;
	public Int64 AccumulateCount;
}
public struct ShortCutProperty
{
	public UInt8 Type;
	public UInt64 Value;
}
public struct KeyboardValueProperty
{
	public UInt16 Value0;
	public UInt16 Value1;
}
public struct KeyboardSlotProperty
{
	public UInt32 Key;
	public UInt16 Value0;
	public UInt16 Value1;
}
public struct MessageProperty
{
	public Int64 Time1970;
	public ViString Content;
}
public struct EntityIDNameProperty
{
	public UInt64 ID;
	public ViString Name;
}
public struct PlayerIdentificationProperty
{
	public UInt64 ID;
	public ViString Name;
	public ViString NameAlias;
	public UInt8 Photo;
}
public struct StringInt32Property
{
	public ViString StrValue;
	public Int32 Int32Value;
}
public struct StringInt64Property
{
	public ViString StrValue;
	public Int64 Int64Value;
}
public struct UInt64Int32Property
{
	public UInt64 UInt64Value;
	public Int32 Int32Value;
}
public struct UInt32Int16Property
{
	public UInt64 UInt64Value;
	public Int32 Int32Value;
}
public struct CountValue64Property
{
	public Int64 Count;
	public Int64 Value;
}
public struct StatisticsValueProperty
{
	public Int64 Count;
	public Int64 Sum;
}
public struct ProgressProperty
{
	public Int64 StartTime;
	public Int64 EndTime;
}
public struct VisualAuraProperty_Alias
{
	public UInt32 Effect;
	public Int64 EndTime;
	public Int8 Level;
	public UInt64 Caster;
}
public struct DateProperty
{
	public UInt8 Year;
	public UInt8 Month;
	public UInt8 Day;
	public UInt8 Hour;
	public UInt8 Minute;
	public UInt8 WeakDay;
}
public struct AccmulateDurationProperty
{
	public Int64 StartTime;
	public Int64 Duration;
}
public struct TimeDurationProperty
{
	public Int64 StartTime;
	public Int64 EndTime;
}
public struct ChatRecordProperty
{
	public PlayerIdentificationProperty Sayer;
	public ViString Content;
	public Int64 Time1970;
}
public struct PlayerShotHeroProperty
{
	public ViForeignKey<HeroStruct> Info;
	public Int16 Level;
	public Int16 Star;
	public Int16 Quality;
	public Int16 WeaponLevel;
	public Int32 FightPower;
}
public struct PlayerShotHeroArrayProperty
{
	public static readonly int TYPE_SIZE = 18;
	public static readonly int Length = 3;
	//
	public int GetLength() { return Length; }
	//
	public PlayerShotHeroProperty E0;
	public PlayerShotHeroProperty E1;
	public PlayerShotHeroProperty E2;
	//
	public PlayerShotHeroProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
			}
		}
	}
}

public struct PlayerShotProperty
{
	public PlayerIdentificationProperty Identify;
	public UInt8 Gender;
	public Int16 Level;
	public UInt8 Class;
	public Int32 FightPower;
	public UInt8 State;
	public Int64 LastActiveTime1970;
	public ViString Guild;
	public ViNormalDataPtr<PlayerShotHeroArrayProperty> HeroList;
}
public struct LevelUpdateProperty
{
	public Int16 Level;
	public Int16 Power;
}
public struct LevelXPUpdateProperty
{
	public Int16 Level;
	public Int64 XP;
}
public struct ScoreProperty
{
	public ViForeignKey<ScoreStruct> Info;
	public Int32 Value;
}
public struct ScoreArray6Property
{
	public static readonly int TYPE_SIZE = 12;
	public static readonly int Length = 6;
	//
	public int GetLength() { return Length; }
	//
	public ScoreProperty E0;
	public ScoreProperty E1;
	public ScoreProperty E2;
	public ScoreProperty E3;
	public ScoreProperty E4;
	public ScoreProperty E5;
	//
	public ScoreProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
				case 5:
					E5 = value;
					return;
			}
		}
	}
}

public struct ItemCountProperty
{
	public ViForeignKey<ItemStruct> Info;
	public Int32 Count;
}
public struct ItemCountWithColorProperty
{
	public ViForeignKey<ItemStruct> Info;
	public Int32 Count;
	public UInt8 Color;
}
public struct ItemCountArray6Property
{
	public static readonly int TYPE_SIZE = 12;
	public static readonly int Length = 6;
	//
	public int GetLength() { return Length; }
	//
	public ItemCountProperty E0;
	public ItemCountProperty E1;
	public ItemCountProperty E2;
	public ItemCountProperty E3;
	public ItemCountProperty E4;
	public ItemCountProperty E5;
	//
	public ItemCountProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
				case 5:
					E5 = value;
					return;
			}
		}
	}
}

public struct BagSlot
{
	public UInt8 Bag;
	public UInt16 Slot;
}
public struct ItemSlotCount
{
	public UInt16 Slot;
	public Int16 Count;
}
public struct ItemScriptValuePropertyList
{
	public static readonly int TYPE_SIZE = 4;
	public static readonly int Length = 4;
	//
	public int GetLength() { return Length; }
	//
	public Int32 E0;
	public Int32 E1;
	public Int32 E2;
	public Int32 E3;
	//
	public Int32 this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
			}
		}
	}
}

public struct EquipAttr
{
	public Int32 HPMax;
}
public struct ItemProperty
{
	public UInt64 ID;
	public ViForeignKey<ItemStruct> Info;
	public UInt8 State;
	public BagSlot Slot;
	public Int64 CreateTime1970;
	public Int64 StartTime;
	public Int64 EndTime;
	public Int64 RecoverTime;
	public Int32 StackCount;
	public UInt8 Color;
	public Int16 Durability;
	public ViNormalDataPtr<ItemScriptValuePropertyList> ScriptValues;
	public UInt16 OperateMask0;
	public UInt16 OperateMask1;
}
public struct ItemSaledProperty
{
	public ItemProperty Item;
	public Int64 Time;
}
public struct ItemTransportProperty
{
	public UInt16 From;
	public UInt16 To;
	public Int16 Count;
}
public struct PackageSlotProperty
{
	public UInt32 Item;
	public Int32 Count;
}
public struct ItemDelRecordProperty
{
	public UInt32 Type;
	public Int64 Time1970;
	public ItemProperty Item;
}
public struct ItemDelCountProperty
{
	public UInt32 Type;
	public Int64 Time1970;
	public ViForeignKey<ItemStruct> Info;
	public Int32 Count;
}
public struct ItemVersionProperty
{
	public Int64 Version;
	public ItemProperty Item;
}
public struct ItemLicenceRecordProperty
{
	public ViString Licence;
	public Int64 Time1970;
	public ViForeignKey<ItemStruct> Info;
	public Int32 Count;
}
public struct HeroEquipProperty
{
	public ItemProperty ItemInfo;
}
public struct HeroEquipArrayProperty
{
	public static readonly int TYPE_SIZE = 120;
	public static readonly int Length = 8;
	//
	public int GetLength() { return Length; }
	//
	public HeroEquipProperty E0;
	public HeroEquipProperty E1;
	public HeroEquipProperty E2;
	public HeroEquipProperty E3;
	public HeroEquipProperty E4;
	public HeroEquipProperty E5;
	public HeroEquipProperty E6;
	public HeroEquipProperty E7;
	//
	public HeroEquipProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
				case 6:
					return E6;
				case 7:
					return E7;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
				case 5:
					E5 = value;
					return;
				case 6:
					E6 = value;
					return;
				case 7:
					E7 = value;
					return;
			}
		}
	}
}

public struct MarketItemBuyRecordProperty
{
	public PlayerIdentificationProperty Receiver;
	public UInt32 Item;
	public Int32 Count;
	public Int64 Cost;
	public Int64 ReserveMoney;
	public Int64 Time1970;
}
public struct MarketSellItemProperty
{
	public UInt32 MarketItem;
	public Int64 Price;
	public Int16 MaxCount;
}
public struct ShopItemBuyRecordProperty
{
	public UInt32 ID;
	public Int32 Count;
	public Int64 Cost;
	public Int64 ReserveMoney;
	public Int64 Time1970;
}
public struct ShopItemProperty
{
	public UInt32 ID;
	public Int64 Price;
	public Int16 ReserveCount;
}
public struct ItemTradeRecordProperty
{
	public PlayerIdentificationProperty FromPlayer;
	public PlayerIdentificationProperty ToPlayer;
	public Int64 Time1970;
	public Int64 Price;
	public ItemProperty ItemProperty;
}
public struct ItemTradeProperty
{
	public UInt64 ID;
	public ItemProperty ItemProperty;
	public Int64 Price;
	public PlayerIdentificationProperty Player;
	public Int64 EndTime;
	public Int64 AuctionPrice;
	public PlayerIdentificationProperty Auctioner;
}
public struct ItemTradeOfficialPriceProperty
{
	public Int32 Inf;
	public Int32 Sup;
	public Int32 Standard;
	public Int32 Current;
}
public struct MoneyProperty
{
	public UInt8 Type;
	public Int32 Money;
}
public struct MoneyModRecordProperty
{
	public UInt32 Type;
	public Int64 FromMoney;
	public Int64 ToMoney;
	public Int64 Time1970;
}
public struct ScriptDurationProperty
{
	public Int64 EndTime;
}
public struct CreateRoleProperty
{
	public ViString NameAlias;
	public UInt8 Gender;
	public UInt8 FaceType;
	public UInt8 HairType;
	public UInt8 PlayerInitConfigID;
}
public struct AccountRoleProperty
{
	public PlayerIdentificationProperty Identification;
	public UInt8 Gender;
	public Int16 Level;
	public UInt8 FaceType;
	public UInt8 HairType;
	public ViForeignKey<HeroStruct> HeroConfig;
	public HeroEquipArrayProperty EquipList;
	public Int64 EndTime;
}
public struct RechargeProperty
{
	public ViString OrderNo;
	public Int64 Time1970;
	public Int64 Money;
	public Int64 Value;
}
public struct RechargeExecProperty
{
	public Int64 CreateTime1970;
	public Int32 CreateDayNumber1970;
	public Int64 ExecTime1970;
	public Int32 ExecDayNumber1970;
	public Int64 Value;
}
public struct HTTPGiftProperty
{
	public ViString OrderNo;
	public Int64 CreateTime1970;
	public Int64 ExecTime1970;
	public Int32 Gift;
}
public struct GameUnitIndexProperty
{
	public Int32 HPMax0;
	public Int32 HPMax1;
	public Int32 HPMax2;
	public Int32 MPMax0;
	public Int32 MPMax1;
	public Int32 MPMax2;
	public Int32 SPMax0;
	public Int32 SPMax1;
	public Int32 SPMax2;
	public Int32 HPRegenerate0;
	public Int32 HPRegenerate1;
	public Int32 HPRegenerate2;
	public Int32 MPRegenerate0;
	public Int32 MPRegenerate1;
	public Int32 MPRegenerate2;
	public Int32 SPRegenerate0;
	public Int32 SPRegenerate1;
	public Int32 SPRegenerate2;
	public Int32 PhysicsAttack0;
	public Int32 PhysicsAttack1;
	public Int32 PhysicsAttack2;
	public Int32 PhysicsDefence0;
	public Int32 PhysicsDefence1;
	public Int32 PhysicsDefence2;
	public Int32 MagicAttack0;
	public Int32 MagicAttack1;
	public Int32 MagicAttack2;
	public Int32 MagicDefence0;
	public Int32 MagicDefence1;
	public Int32 MagicDefence2;
	public Int32 MoveSpeed0;
	public Int32 MoveSpeed1;
	public Int32 MoveSpeed2;
	public Int32 CriticalHit0;
	public Int32 CriticalHit1;
	public Int32 CriticalHit2;
	public Int32 CriticalMiss0;
	public Int32 CriticalMiss1;
	public Int32 CriticalMiss2;
	public Int32 CriticalHitRate0;
	public Int32 CriticalHitRate1;
	public Int32 CriticalHitRate2;
	public Int32 CriticalMissRate0;
	public Int32 CriticalMissRate1;
	public Int32 CriticalMissRate2;
	public Int32 CriticalDamageAttack0;
	public Int32 CriticalDamageAttack1;
	public Int32 CriticalDamageAttack2;
	public Int32 CriticalDamageDefence0;
	public Int32 CriticalDamageDefence1;
	public Int32 CriticalDamageDefence2;
	public Int32 Penetrate0;
	public Int32 Penetrate1;
	public Int32 Penetrate2;
	public Int32 AttackVampire0;
	public Int32 AttackVampire1;
	public Int32 AttackVampire2;
	public Int32 AttackSpeedMultiply0;
	public Int32 AttackSpeedMultiply1;
	public Int32 AttackSpeedMultiply2;
}
public struct HeroSpellProperty
{
	public ViForeignKey<OwnSpellStruct> Info;
	public ViForeignKey<ViSpellStruct> WorkingInfo;
	public Int16 Level;
	public Int32 LevelValue;
	public Int16 SetupIdx;
}
public struct HeroSpellArrayProperty
{
	public static readonly int TYPE_SIZE = 50;
	public static readonly int Length = 10;
	//
	public int GetLength() { return Length; }
	//
	public HeroSpellProperty E0;
	public HeroSpellProperty E1;
	public HeroSpellProperty E2;
	public HeroSpellProperty E3;
	public HeroSpellProperty E4;
	public HeroSpellProperty E5;
	public HeroSpellProperty E6;
	public HeroSpellProperty E7;
	public HeroSpellProperty E8;
	public HeroSpellProperty E9;
	//
	public HeroSpellProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
				case 6:
					return E6;
				case 7:
					return E7;
				case 8:
					return E8;
				case 9:
					return E9;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
				case 5:
					E5 = value;
					return;
				case 6:
					E6 = value;
					return;
				case 7:
					E7 = value;
					return;
				case 8:
					E8 = value;
					return;
				case 9:
					E9 = value;
					return;
			}
		}
	}
}

public struct HeroProperty
{
	public ViString Note;
	public ViForeignKey<HeroStruct> Info;
	public Int16 Level;
	public Int64 XP;
	public Int32 FightPower;
	public HeroSpellArrayProperty SpellList;
	public HeroEquipArrayProperty EquipList;
	public UInt8 FaceType;
	public UInt8 HairType;
}
public struct HeroWorkingProperty
{
	public HeroProperty Property;
	public List<HeroSpellProperty> StudySpellList;
	public GameUnitIndexProperty IndexProperty;
	public Int32 HP;
	public Int8 HPPerc;
	public Int32 MP;
	public Int32 SP;
	public UInt32 ActionStateMask;
	public UInt32 AuraStateMask;
	public Int64 CDEndTime;
}
public struct SpaceRecordProperty
{
	public Int8 Score;
	public Int32 WinCount;
	public Int32 Count;
}
public struct SpaceImmediateCompleteProperty
{
	public Int16 Count;
	public Int64 EndTime;
}
public struct SpaceBirthControllerProperty
{
	public UInt8 State;
	public Int16 ReserveCount;
	public ViVector3 Position;
	public UInt8 Faction;
	public Int64 FactionStartTime;
	public ViNormalDataPtr<UInt64Property> Team;
	public Int16 Level;
}
public struct SpaceBirthControllerShowProperty
{
	public UInt32 Show;
	public ViVector3 Position;
}
public struct SpaceEventCacheProperty
{
	public ViForeignKey<SpaceEventStruct> Info;
	public UInt8 Faction;
	public Int64 Time;
	public ViVector3 Position;
	public float Yaw;
}
public struct SpaceEventProperty
{
	public UInt8 Faction;
	public Int64 Time;
	public Int16 Count;
}
public struct SpaceBlockSlotProperty
{
	public Int16 X;
	public Int16 Y;
	public ViForeignKey<SpaceBlockSlotStruct> Info;
	public UInt8 State;
	public Int64 RecoverTime;
}
public struct SpaceHideSlotProperty
{
	public Int16 X;
	public Int16 Y;
	public ViForeignKey<SpaceHideSlotStruct> Info;
	public UInt8 State;
	public Int64 RecoverTime;
}
public struct SpacePlayerWorkingHeroSpellCDProperty
{
	public UInt32 Spell;
	public Int64 EndTime;
}
public struct SpacePlayerWorkingHeroSpellCDArrayProperty
{
	public static readonly int TYPE_SIZE = 8;
	public static readonly int Length = 4;
	//
	public int GetLength() { return Length; }
	//
	public SpacePlayerWorkingHeroSpellCDProperty E0;
	public SpacePlayerWorkingHeroSpellCDProperty E1;
	public SpacePlayerWorkingHeroSpellCDProperty E2;
	public SpacePlayerWorkingHeroSpellCDProperty E3;
	//
	public SpacePlayerWorkingHeroSpellCDProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
			}
		}
	}
}

public struct SpacePlayerMemberProperty
{
	public PlayerIdentificationProperty Identification;
	public UInt8 ClientState;
	public float LoadProgress;
	public UInt8 ClientSpaceCompleted;
	public ViString Guild;
	public Int16 Level;
	public UInt8 Faction;
}
public struct SpacePlayerMemberPtrProperty
{
	public ViNormalDataPtr<SpacePlayerMemberProperty> Ptr;
}
public struct SpaceHeroMemberProperty
{
	public PlayerIdentificationProperty Identification;
	public ViForeignKey<HeroStruct> Info;
	public ViString Guild;
	public Int16 Level;
	public UInt8 Faction;
}
public struct SpaceHeroLevelRandomEffectProperty
{
	public static readonly int TYPE_SIZE = 3;
	public static readonly int Length = 3;
	//
	public int GetLength() { return Length; }
	//
	public UInt32 E0;
	public UInt32 E1;
	public UInt32 E2;
	//
	public UInt32 this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
			}
		}
	}
}

public struct SpaceDamageOutProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 Faction;
	public Int64 CurrentDamageOut;
	public Int64 AccumulateDamageOut;
}
public struct SpaceFactionHeroMemberProperty
{
	public UInt32 ActionState;
	public Int32 HP;
	public Int32 HPMax;
	public ViVector3 Position;
}
public struct PublicSpaceEnterMemberProperty
{
	public PlayerIdentificationProperty Identification;
	public UInt8 Gender;
	public UInt8 FactionIdx;
	public ViString Guild;
	public Int16 Level;
	public Int64 EnterTime;
	public UInt8 Ready;
}
public struct PublicSpaceEnterGroupMemberProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 FactionIdx;
}
public struct PublicSpaceEnterGroupMemberArrayProperty
{
	public static readonly int TYPE_SIZE = 60;
	public static readonly int Length = 10;
	//
	public int GetLength() { return Length; }
	//
	public PublicSpaceEnterGroupMemberProperty E0;
	public PublicSpaceEnterGroupMemberProperty E1;
	public PublicSpaceEnterGroupMemberProperty E2;
	public PublicSpaceEnterGroupMemberProperty E3;
	public PublicSpaceEnterGroupMemberProperty E4;
	public PublicSpaceEnterGroupMemberProperty E5;
	public PublicSpaceEnterGroupMemberProperty E6;
	public PublicSpaceEnterGroupMemberProperty E7;
	public PublicSpaceEnterGroupMemberProperty E8;
	public PublicSpaceEnterGroupMemberProperty E9;
	//
	public PublicSpaceEnterGroupMemberProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
				case 6:
					return E6;
				case 7:
					return E7;
				case 8:
					return E8;
				case 9:
					return E9;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
				case 5:
					E5 = value;
					return;
				case 6:
					E6 = value;
					return;
				case 7:
					E7 = value;
					return;
				case 8:
					E8 = value;
					return;
				case 9:
					E9 = value;
					return;
			}
		}
	}
}

public struct PublicSpaceEnterGroupProperty
{
	public ViString Name;
	public ViForeignKey<SpaceStruct> Space;
	public Int64 StartTime;
	public PlayerIdentificationProperty Leader;
	public PublicSpaceEnterGroupMemberArrayProperty MemberList;
	public Int8 FactionCount;
	public Int16 FactionMemberCount;
	public Int16 MemberCount;
	public Int16 WatcherCount;
	public UInt8 HasPassword;
}
public struct GoalProperty
{
	public ViForeignKey<GoalStruct> Info;
	public Int64 CompleteTime1970;
	public UInt8 State;
	public Int32 Value;
	public Int32 ValueSup;
}
public struct ClientSettingForPlayerProperty
{
	public float CameraDistance;
	public UInt8 MinMap;
	public UInt8 MouseControllerType;
	public UInt8 AutoAct;
}
public struct ClientSettingForAccountProperty
{
	public UInt8 SpellLODLevel;
	public UInt8 GraphicsMainLevel;
	public UInt8 GraphicsMirrorCharacter;
	public UInt8 GraphicsMirrorScene;
	public UInt8 GraphicsShadow;
	public UInt8 GraphicsColorEnhance;
	public UInt8 GraphicsBloom;
	public UInt8 GraphicsDistort;
	public float CameraShakeScale;
	public UInt8 FPSLevel;
	public UInt8 EnergySave;
	public float MainVolume;
	public float MusicVolume;
	public float SoundVolume;
	public float CharacterVolume;
	public float AutoLockFocusScale;
}
public struct ClientDeviceProperty
{
	public UInt8 Platform;
	public ViString DeviceName;
	public ViString DeviceModel;
	public ViString DeviceUniqueIdentifier;
	public ViString OperatingSystem;
	public Int8 OperatingSystemAPILevel;
	public Int32 SystemMemorySize;
	public ViString ProcessorType;
	public Int8 ProcessorCount;
	public Int32 ProcessorFrequency;
	public ViString GraphicsDeviceName;
	public ViString GraphicsDeviceVendor;
	public ViString GraphicsDeviceVersion;
	public Int32 GraphicsMemorySize;
	public Int16 ScreenX;
	public Int16 ScreenY;
}
public struct FriendProperty
{
	public ViString Name;
	public ViString Note;
}
public struct FriendViewProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 Gender;
	public UInt8 Class;
	public Int32 FightPower;
	public UInt8 ClientState;
	public UInt8 HasGuild;
	public ViString GuildName;
	public UInt8 Photo;
	public Int64 LastActiveTime1970;
	public UInt32 Space;
}
public struct FriendInvitorProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 Gender;
	public UInt8 Class;
	public Int32 FightPower;
	public UInt8 ClientState;
	public UInt8 HasGuild;
	public ViString GuildName;
}
public struct FriendInviteeProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 Gender;
	public UInt8 Class;
	public Int32 FightPower;
	public UInt8 ClientState;
	public UInt8 HasGuild;
	public ViString GuildName;
}
public struct BlackFriendProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 Gender;
	public UInt8 Class;
	public Int32 FightPower;
	public UInt8 ClientState;
	public UInt8 HasGuild;
	public ViString GuildName;
}
public struct MailProperty
{
	public UInt8 State;
	public UInt8 Type;
	public Int64 Time1970;
	public ViString Title;
	public ViString Content;
	public PlayerIdentificationProperty Sender;
	public Int64 AttachmentReceiveTime1970;
	public Int64 AttachmentXP;
	public Int64 AttachmentYinPiao;
	public Int64 AttachmentJinPiao;
	public Int64 AttachmentJinZi;
	public ScoreArray6Property AttachmentScores;
	public ItemCountArray6Property AttachmentItems;
	public ViNormalDataPtr<ItemProperty> AttachmentItem;
}
public struct GuildMemberProperty
{
	public PlayerIdentificationProperty Identification;
	public UInt8 Position;
	public Int16 Level;
	public UInt8 Gender;
	public Int32 FightPower;
	public Int32 DailyContribution;
	public Int32 TotalContribution;
	public Int32 TotalContributionBadgeCount;
	public UInt8 ClientState;
	public Int64 LastOnlineTime;
	public Int64 LastOnlineTime1970;
}
public struct GuildMessageProperty
{
	public UInt8 Type;
	public Int64 Time1970;
	public PlayerIdentificationProperty Member;
	public Int64 IntValue0;
	public Int64 IntValue1;
	public ViString StringValue0;
	public ViString StringValue1;
}
public struct GuildApplyProperty
{
	public PlayerIdentificationProperty Identification;
	public Int16 Level;
	public UInt8 Gender;
	public Int32 FightPower;
}
public struct GuildViewProperty
{
	public UInt64 ID;
	public ViString Name;
	public PlayerIdentificationProperty Leader;
	public Int16 Level;
	public Int16 MemberCount;
	public UInt8 ResponseType;
	public Int16 ReqEnterLevel;
	public ViString Introdution;
	public Int32 FightPower;
}
public struct GuildActivitySeatProperty
{
	public UInt32 Activity;
	public Int64 Time1970;
}
public struct GuildActivityProperty
{
	public UInt64 Leader;
	public UInt8 State;
	public Int64 StartTime1970;
	public Int16 Count;
}
public struct GuildActivityEnterProperty
{
	public Int16 EnterCount;
	public Int16 BuyCount;
}
public struct ActivityProperty
{
	public UInt8 State;
	public Int64 EndTime1970;
	public Int64 Version;
}
public struct ActivityStatisticsProperty
{
	public Int64 Version;
	public Int32 EnterCount;
	public Int32 ExistCount;
	public Int32 MaxExistCount;
}
public struct ActivityStatisticsRecordProperty
{
	public UInt32 ID;
	public ViString Name;
	public Int64 StartTime;
	public Int64 StartTime1970;
	public Int64 Duration;
	public ActivityStatisticsProperty Statistics;
}
public struct ActivityEnterProperty
{
	public ViForeignKey<ActivityStruct> Info;
	public Int16 Count;
	public Int64 AccumulateCount;
	public Int64 LastVersion;
	public UInt32 Rank;
	public AccmulateDurationProperty Duration;
}
public struct ActivityRankProperty
{
	public PlayerShotProperty Property;
	public Int64 Score;
	public Int64 Value0;
	public Int64 Value1;
	public Int64 Value2;
}
public struct PaymentStateProperty
{
	public UInt32 ID;
	public UInt8 State;
}
public struct PartyMemberProperty
{
	public PlayerIdentificationProperty Identification;
	public PlayerIdentificationProperty Recommander;
	public UInt8 Ready;
	public UInt8 AutoReady;
	public UInt8 Gender;
	public Int16 Level;
	public UInt8 Online;
	public UInt8 Class;
	public UInt16 Power;
	public UInt8 Channel;
	public UInt32 SpaceID;
	public UInt8 KickOutTimes;
}
public struct PartySpaceSelectProperty
{
	public UInt32 Space;
	public UInt8 MatchType;
}
public struct PartySpaceMatchProperty
{
	public Int32 AverageScore;
	public UInt32 Space;
	public UInt8 MatchType;
	public Int64 StartTime;
	public float Progress;
}
public struct PartyInvitorProperty
{
	public UInt64 PartyID;
	public PlayerIdentificationProperty Leader;
	public PartyMemberProperty PlayerDetailLite;
}
public struct PartyPartnerRecordProperty
{
	public PlayerIdentificationProperty Identification;
	public UInt8 Gender;
	public UInt8 State;
}
public struct PartyDetail
{
	public UInt64 ID;
	public ViString Name;
	public UInt16 MaxPlayer;
	public UInt64 Type;
	public PlayerIdentificationProperty Leader;
	public List<PartyMemberProperty> member;
}
public struct PartyDetailLite
{
	public UInt64 ID;
	public ViString Name;
	public UInt16 MaxPlayer;
	public UInt16 Type;
}
public struct PlayerScoreRankProperty
{
	public PlayerIdentificationProperty Player;
	public Int32 Score;
	public UInt32 Position;
}
public struct ScoreRankStasticsProperty
{
	public Int32 Score;
	public UInt32 RankPosition;
	public UInt32 RankPositionBest;
	public Int32 MatchScore;
	public Int32 ContinueWinCount;
	public Int32 ContinueLoseCount;
	public Int32 TotalCount;
	public Int32 TotalWinCount;
	public Int32 TotalLoseCount;
	public Int32 VersionCount;
	public Int32 VersionWinCount;
	public Int32 VersionLoseCount;
	public Int64 Version;
	public Int64 RewardVersion;
}
public struct SpaceMatchProperty
{
	public UInt32 Space;
	public Int32 Size;
	public Int32 PlayerCount;
}
public struct MatchSpaceMemberScoreProperty
{
	public Int32 Score;
	public Int32 PartyScore;
	public Int32 ScoreMod;
}
public struct SpaceMatchEnterMemberProperty
{
	public PlayerIdentificationProperty Player;
	public UInt8 FactionIdx;
	public UInt8 Ready;
	public UInt32 Hero;
	public UInt8 HeroReady;
}
public struct SpaceCreateProperty
{
	public PlayerIdentificationProperty Owner;
	public Int16 OwnerLevel;
	public ViString Note;
	public Int16 ModLevel;
	public UInt8 MatchType;
	public UInt8 PKType;
	public UInt8 Exitable;
	public UInt8 EmptyDestroy;
	public UInt8 EraseExitMember;
	public Int16 MemberCountSup;
	public UInt8 BroadcastPropertyToCenter;
	public double HeroHPMaxScale;
	public double NPCHPPercScale;
	public HashSet<ViString> ScriptList;
	public Dictionary<ViString, Int64Property> ScriptValueList;
	public Dictionary<UInt64, MatchSpaceMemberScoreProperty> MatchScoreList;
}
public struct NotifyProperty
{
	public UInt8 State;
	public Int64 EndTime1970;
}
public struct CellStateProperty
{
	public Int32 OnlineCount;
	public Int32 BigSpaceCount;
	public Int32 ActivitySpaceCount;
	public Int32 PublicSmallSpaceCount;
	public Int32 PrivateSmallSpaceCount;
}
public struct DisableRecordProperty
{
	public ViString Value;
	public ViString Note;
	public Int64 EndTime1970;
}
public struct EntityServerProperty
{
	public UInt16 Create;
	public UInt16 Current;
	public Int64 Time;
	public Int64 Time1970;
}
public struct MemoryUseProperty
{
	public ViString Name;
	public UInt32 Size;
	public Int32 UseCount;
	public Int32 ReserveCount;
}
public struct AccountWithPlayerProperty
{
	public UInt64 AccountID;
	public ViString AccountName;
	public List<PlayerIdentificationProperty> RoleList;
	public ViString LastIP;
	public ViString LastMacAdress;
	public ViString SourceTag;
	public ViString SourceDate;
	public ViString CDKey;
	public ViString CDKeyTag;
	public UInt64 OnlineVersion;
	public List<ClientDeviceProperty> ClientDeviceList;
}
public struct PlayerWithAccountProperty
{
	public UInt64 AccountID;
	public ViString AccountName;
	public PlayerIdentificationProperty Player;
	public ViString LastIP;
	public ViString LastMacAdress;
	public ViString SourceTag;
	public ViString SourceDate;
	public ViString CDKey;
	public ViString CDKeyTag;
	public UInt64 OnlineVersion;
}
public struct PlayerOnlineProperty
{
	public PlayerIdentificationProperty Player;
	public ViString AccountName;
	public ViString IP;
	public ViString MacAdress;
	public UInt32 Space;
	public Int16 Level;
	public UInt32 OnlineNumber;
	public ViString SourceTag;
	public ViString SourceDate;
	public ViString CDKey;
	public ViString CDKeyTag;
	public UInt16 AccessServerID;
	public UInt16 HomeServerID;
	public UInt16 ServerBaseID;
	public UInt16 ServerCellID;
}
public struct GMStatisticValueProperty
{
	public UInt32 ID;
	public Int64 Count;
	public Int64 Value;
}
public struct GMStatisticValuePropertyList
{
	public List<GMStatisticValueProperty> ReceiveXPListInNPC;
	public List<GMStatisticValueProperty> ReceiveXPListInQuest;
	public List<GMStatisticValueProperty> ReceiveXPListInLoot;
	public List<GMStatisticValueProperty> ReceiveXPListInActivity;
	public List<GMStatisticValueProperty> ReceiveYinPiaoListInNPC;
	public List<GMStatisticValueProperty> ReceiveYinPiaoListInQuest;
	public List<GMStatisticValueProperty> ReceiveYinPiaoListInLoot;
	public List<GMStatisticValueProperty> ReceiveYinPiaoListInActivity;
	public List<GMStatisticValueProperty> ReceiveJinPiaoListInNPC;
	public List<GMStatisticValueProperty> ReceiveJinPiaoListInQuest;
	public List<GMStatisticValueProperty> ReceiveJinPiaoListInLoot;
	public List<GMStatisticValueProperty> ReceiveJinPiaoListInActivity;
	public List<GMStatisticValueProperty> ReceiveItemListInNPC;
	public List<GMStatisticValueProperty> ReceiveItemListInQuest;
	public List<GMStatisticValueProperty> ReceiveItemListInLoot;
	public List<GMStatisticValueProperty> ReceiveItemListInActivity;
	public List<GMStatisticValueProperty> ReceiveItemListInShop;
	public List<GMStatisticValueProperty> ReceiveItemListInMarket;
	public List<GMStatisticValueProperty> TradeItemListInMarket;
}
public struct PlayerGMViewProperty
{
	public ViString Name;
	public ViString NameAlias;
	public UInt64 AccountID;
	public ViString AccountName;
	public ViString SourceTag;
	public ViString SourceDate;
	public ViString CDKey;
	public ViString CDKeyTag;
	public UInt8 Online;
	public UInt64 OnlineVersion;
	public Int64 CreateTime1970;
	public Int64 LastOnlineTime1970;
	public Int64 CreateDayNumber1970;
	public Int64 CurrentDayNumber1970;
	public Int32 AccumulateLoginDayCount;
	public Int64 AccumulateOnlineDuration;
	public Int16 Level;
	public UInt8 Gender;
	public List<ItemProperty> Inventory;
	public List<ItemProperty> Equipments;
	public Dictionary<UInt32, UInt8Property> PaymentStateList;
	public Dictionary<UInt32, StatisticsValueProperty> YinPiaoPaymentRecordList;
	public Dictionary<UInt32, StatisticsValueProperty> JinPiaoPaymentRecordList;
	public Dictionary<UInt32, StatisticsValueProperty> JinZiPaymentRecordList;
	public GMStatisticValuePropertyList StatisticsValueList;
	public Dictionary<UInt32, SpaceRecordProperty> SpaceRecordList;
}
public struct QuestGameRecordProperty
{
	public UInt32 Quest;
	public Int64 ReceiveCount;
	public Int64 CommitCount;
}
public struct ItemGameRecordProperty
{
	public UInt32 Item;
	public Int64 ReceiveCount;
	public Int64 ComsumeCount;
	public Int64 AbandonCount;
}
public struct PaymentGameRecordProperty
{
	public UInt32 Type;
	public Int64 Value;
	public Int64 Count;
}
public struct PlayerLevelCountProperty
{
	public Int16 Level;
	public Int32 Count;
}
public struct BoardProperty
{
	public Int64 StartTime1970;
	public Int64 EndTime1970;
	public Int64 Span;
	public UInt8 LoopType;
	public ViString Content;
}
public struct GameNoteProperty
{
	public Int64 Time1970;
	public ViString Title;
	public ViString Content;
}
public struct RechargeInGameRecordProperty
{
	public ViString Account;
	public Int64 LastTime;
	public Int64 LastValue;
	public Int64 TotalValue;
}
public struct ServerBaseViewProperty
{
	public ViString ServerName;
	public UInt16 ID;
	public Int64 Time;
	public Int64 Time1970;
	public Int64 StartTime1970;
	public UInt64 Fragment0RecordID;
	public UInt64 Fragment1RecordID;
	public Int32 PlayerCount;
	public Int32 AccountCount;
	public Int32 GuildCount;
	public Int32 OnlineCount;
	public Int32 MaxOnlineCount;
	public Int32 DayMaxOnlineCount;
	public Int32 WeekMaxOnlineCount;
	public Int32 MonthMaxOnlineCount;
	public Int32 DayLoginCount;
	public Int32 WeekLoginCount;
	public Int32 MonthLoginCount;
	public Int32 DayNewAccountCount;
	public Int32 WeekNewAccountCount;
	public Int32 MonthNewAccountCount;
	public Int32 DayNewPlayerCount;
	public Int32 WeekNewPlayerCount;
	public Int32 MonthNewPlayerCount;
	public Int32 DayNewGuildCount;
	public Int32 WeekNewGuildCount;
	public Int32 MonthNewGuildCount;
	public Int32 LuckLootDayCount;
	public Int32 LuckLootAccumulateCount;
	public Int32 EntityCount;
	public Int32 EntityIDCount;
	public Int32 EntityPackIDCount;
	public Int32 SpaceCount;
}
public struct GMContentProperty
{
	public UInt8 State;
	public UInt64 Time1970;
	public ViString Requestor;
	public ViString Confirmer;
	public UInt64 StartTime;
	public UInt64 EndTime;
	public ViString Func;
	public ViString Params;
}
public struct GMRequestProperty
{
	public UInt32 OccupationMask;
	public Int16 LevelInf;
	public Int16 LevelSup;
	public UInt32 QuestReceived;
	public UInt32 QuestNotReceived;
	public UInt32 QuestCompleted;
	public UInt32 QuestNotCompleted;
	public UInt32 FuncOpened;
	public UInt32 FuncNotOpened;
}
public struct GMRequestContentProperty
{
	public GMRequestProperty Request;
	public GMContentProperty Content;
}
public struct GMRequestMailProperty
{
	public GMRequestProperty Request;
	public MailProperty Content;
}
public struct ServerViewProperty
{
	public ServerBaseViewProperty Base;
	public List<UInt16Property> MergeList;
	public List<StringProperty> RPCExecNameList;
	public List<Int64Property> RPCExecCountList;
	public List<MemoryUseProperty> MemoryCountList0;
	public List<MemoryUseProperty> MemoryCountList1;
	public Dictionary<UInt64, PlayerOnlineProperty> OnlinePlayerList;
	public List<GMRequestContentProperty> GlobalGMRecordList;
	public List<GMRequestMailProperty> GlobalMailList;
	public Dictionary<ViString, DisableRecordProperty> IPDisableList;
	public Dictionary<ViString, DisableRecordProperty> AccountDisableList;
	public List<UInt32Property> GameFuncClosedList;
	public List<BoardProperty> BoardList;
	public List<GameNoteProperty> NoteList;
	public List<QuestGameRecordProperty> QuestRecordList;
	public List<ItemGameRecordProperty> ItemRecordList;
	public List<PlayerLevelCountProperty> PlayerLevelCountList;
	public Dictionary<UInt32, StatisticsValueProperty> YinPiaoPaymentRecordList;
	public Dictionary<UInt32, StatisticsValueProperty> JinPiaoPaymentRecordList;
	public Dictionary<UInt32, StatisticsValueProperty> JinZiPaymentRecordList;
	public Dictionary<UInt32, StatisticsValueProperty> ItemMarketRecordList;
	public Dictionary<UInt32, StatisticsValueProperty> ItemShopRecordList;
	public List<RechargeInGameRecordProperty> RechargeList;
	public GMStatisticValuePropertyList StatisticsValueList;
}
public struct ServerFragment0Property
{
	public Int64 Time1970;
	public Int32 NewAccount;
	public Int32 NewPlayer;
	public Int32 WebOnline;
	public Int32 ClientOnline;
}
public struct ServerFragment0WithNameProperty
{
	public ViString ServerName;
	public ServerFragment0Property Property;
}
public struct ServerFragment1Property
{
	public Int64 Time1970;
	public ServerFragment0Property Base;
	public List<QuestGameRecordProperty> QuestRecordList;
	public List<ItemGameRecordProperty> ItemRecordList;
	public List<PaymentGameRecordProperty> YinPiaoPaymentRecordList;
	public List<PaymentGameRecordProperty> JinPiaoPaymentRecordList;
	public List<PlayerLevelCountProperty> PlayerLevelCountList;
}
public struct ServerFragment1WithNameProperty
{
	public ViString ServerName;
	public ServerFragment1Property Property;
}
public struct GoalEventStruct
{
	public UInt32 Space;
	public ViVector3 Position;
	public UInt32 ID;
	public UInt8 MatchType;
	public UInt32 Count;
}
