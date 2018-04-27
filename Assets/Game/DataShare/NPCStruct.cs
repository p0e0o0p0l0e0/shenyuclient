using System;
using System.Collections.Generic;

public class NPCConfigStruct : ViSealedData
{
	public Int32 EnterBattleDuration;
	public Int32 EnterSpaceDuration;
	public Int32 EnterSpaceDisAttackedDuration;
	public ViEnum32<BoolValue> FreeLookAt;
}

public class NPCLevelStruct: ViSealedData
{
	public Int32 HPScale;
	public Int32 AttackPowerScale;
}

public class NPCSpellStruct : ViSealedData
{
	public struct NodeStruct
	{
		public ViEnum32<BoolValue> Operate;
		public ViForeignKey<ViSpellStruct> Spell;
		public ViForeignKey<ViValueMappingStruct> LevelValueMapping;
		public Int32 Level;
	}
    public ViStaticArray<NodeStruct> List = new ViStaticArray<NodeStruct>(10);
}

public class NPCPrivateLootStruct : ViSealedData
{
	public Int32 XP;
	public Int32 YinPiaoProbability;
	public ViValueRange YinPiao;
	public ViForeignKey<LootStruct> FirstDamageLoot;
	public ViForeignKey<LootStruct> KilledLoot;
	public Int32 AttackedLootProbability;
	public ViForeignKey<LootStruct> AttackedLoot;
	public Int32 DamageLootScale10000;
	public Int32 DamageLootProbability;
	public ViForeignKey<LootStruct> DamageLoot;
}

public struct NPCAttributeStruct
{
	public Int32 HPMax;
	public Int32 HPRecover;
	public Int32 AttackPower;
	public Int32 DefencePower;
	public Int32 Reserve_0;
	public Int32 Reserve_1;
}

public struct NPCAIStruct
{
	public ViEnum32<NPCAIType> Type;
	public Int32 PatrolRange;
	public Int32 ChaseRange;
	public Int32 ViewRange;
}

public class NPCBattleStruct
{
	public ViValueRange CorpseTime;
	public ViValueRange ReliveTime;
	public Int32 Reserve_0;
	public ViForeignKey<ViAuraLevelStruct> AuraReceiveLevel;
}

public class NPCStruct : ViSealedData
{
	public float GetBodyRadius()
	{
		return BodyRadius * 0.01f;
	}

	public Int32 Level;
	public ViForeignKey<NPCConfigStruct> Config;
	public ViForeignKey<NPCExStruct> DataEx;
	public Int32 BodyRadius;
	public ViEnum32<Faction> Faction;
	//public ViForeignKey<NPCPrivateLootStruct> Loot;
	public Int32 VisibilityRange;
	public Int32 AntiStealthRange;
	public ViMask32<SpaceVisibilityMask> VisibilityMask;
	public ViEnum32<SpaceVisibilityLevel> VisibilityLevel;
	public ViForeignKey<EntityMessageLogStruct> EnterMessage;
	public ViForeignKey<EntityMessageLogStruct> KilledMessage;
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
    public ViForeignKey<GameFuncStruct> GameFunc;
    public ViForeignKey<ViSpellStruct> HomeSpell;
    public ViForeignKey<ViSpellStruct> ShowSpell;
    public ViForeignKey<NPCSpellStruct> OwnSpell;
}

public class NPCExStruct : ViSealedData
{
	public ViForeignKey<GameUnitPropertyStruct> StandardProperty;
	public NPCAIStruct AI;
	public NPCBattleStruct Battle = new NPCBattleStruct();
    public ViEnum32<EntityCategory> entityCategory;
}
