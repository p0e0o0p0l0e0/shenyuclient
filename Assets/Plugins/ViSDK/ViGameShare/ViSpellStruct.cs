using System;


public class ViSpellValueStruct
{
	public static readonly UInt32 REF_VALUE_MAX = 5;
	public ViUnitValueRange value;
	public ViStaticArray<ViUnitRefValue> casterRefValue = new ViStaticArray<ViUnitRefValue>(REF_VALUE_MAX);
	public ViStaticArray<ViUnitRefValue> targetRefValue = new ViStaticArray<ViUnitRefValue>(REF_VALUE_MAX);
}

public struct ViSpellCostStruct
{
	public ViUnitValue value;
	public ViUnitRefValue refValue;
}

public struct ViSpellValueScaleStruct
{
	public ViForeignKey<ViAuraTypeStruct> Request;
	public Int32 Scale10000;
}

public class ViTargetSelectStruct
{
	public static readonly UInt32 CONDITION_MAX = 3;
	public static readonly UInt32 MISC_VALUE_MAX = 3;

	public ViMask32<ViSpellSelectRalationMask> casterMask;
	public ViAreaStruct casterEffectRange;
	public ViMask32<ViSpellSelectRalationMask> targetMask;
	public ViAreaStruct targetEffectRange;
	public Int32 count;
	public ViForeignKey<ViSealedDataTypeStruct> entityType;
	public Int32 NatureIgnoreMask;
	public ViEnum32<BoolValue> PassBlock;
	public ViStaticArray<ViUnitValueRange> condition = new ViStaticArray<ViUnitValueRange>(CONDITION_MAX);
	public ViForeignKey<ViStateConditionStruct> state;
	public string script;

	public ViForeignKey<ViSpellStruct> X_spell;
	public Int32 X_selectorIdx;
	public ViStaticArray<ViMiscInt32> miscValue = new ViStaticArray<ViMiscInt32>(MISC_VALUE_MAX);
}

public enum DamageSpellType
{
    Physics,
    Magic,
    Raw,
};

public enum DamageSpellElementType
{
    None,
    Light,
    Dark,
    Ice,
    Fire,
};

public class ViHitEffectStruct : ViSealedData
{
	public static readonly UInt32 MISC_VALUE_MAX = 5;

	public bool IsEmpty { get { return (template == (Int32)ViHitEffectTemplate.NONE); } }
	public Int32 MiscValue(string key, Int32 defaultValue) { return miscValue.Value(key, defaultValue); }
	public Int32 MiscValue(string key) { return miscValue.Value(key); }
	public bool IsArea { get { return template == (Int32)ViHitEffectTemplate.AREA; } }

	public Int32 template;
	public Int32 EntityType;
	public ViForeignKey<ViSealedDataTypeStruct> type;
	public ViForeignKey<ViStateConditionStruct> ActiveState;
	public ViEnum32<ViEffectSign> effectSign;
	public string ScaleScript;

	public Int32 delay;
	public Int32 spreadSpeed;

	public ViEnum32<BoolValue> show;
	public ViEnum32<BoolValue> hitedPos;
	public ViForeignKey<ViEmptySealedData> KillVisual;
	public ViForeignKey<ViAttackForceStruct> Force;

	public Int32 createProbabilityChannel;
	public Int32 createProbability;

	public ViEnum32<BoolValue> NoUpGrade;
	public ViForeignKey<ViSpellStruct> X_spell;
	public Int32 Reserve_0;
	public Int32 Reserve_1;

	public ViSpellValueStruct valueSet = new ViSpellValueStruct();
	public ViSpellValueScaleStruct ValueScale = new ViSpellValueScaleStruct();
	public Int32 LevelValueScale;

    public ViEnum32<DamageSpellType> DamageType;
    public ViEnum32<DamageSpellElementType> DamageElementType;
    public Int32 PhysicsAttackCoefficient;
    public Int32 MagicAttackCoefficient;

    public ViStaticArray<ViMiscInt32> miscValue = new ViStaticArray<ViMiscInt32>(MISC_VALUE_MAX);
}

public class ViAuraTypeStruct : ViSealedData
{

}

public class ViAuraChannelStruct : ViSealedData
{

}

public class ViAuraLevelStruct : ViSealedData
{

}

public class ViAuraStruct : ViSealedData
{
	public struct CloseStruct
	{
		public ViForeignKey<ViAuraTypeStruct> Type;
		public ViForeignKey<ViAuraChannelStruct> Channel;
	}

	public static readonly UInt32 DISPEL_MAX = 8;
	public static readonly UInt32 VALUE_MAX = 5;
	public static readonly UInt32 CONDITION_MAX = 3;
	public static readonly UInt32 MISC_VALUE_MAX = 10;

	//static bool IsNotEmpty(ValueRangeArray& kCondition);
	public bool IsEmpty { get { return (template == (Int32)ViAuraTemplate.NONE) && (ScriptAura.Length == 0); } }
	public Int32 MiscValue(string key, Int32 defaultValue) { return miscValue.Value(key, defaultValue); }
	public Int32 MiscValue(string key) { return miscValue.Value(key); }
	public bool IsArea { get { return template == (Int32)ViAuraTemplate.AREA; } }
    
    public Int32 template;
	public Int32 EntityType;
	public ViForeignKey<ViAuraTypeStruct> Type;
	public ViForeignKey<ViAuraLevelStruct> Level;
	public string ScriptAura;
	public ViEnum32<ViEffectSign> effectSign;
	public ViEnum32<BoolValue> DisAoI;
	public string ScaleScript;
	public string DurationScript;

	public ViEnum32<BoolValue> show;
	public ViForeignKey<ViEmptySealedData> KillVisual;
	public ViForeignKey<ViEmptySealedData> EmptyExploreVisual;
	public ViForeignKey<ViAttackForceStruct> Force;

	///<创建>
	public Int32 createChannel;
	public Int32 createProbability;

	///<创建>
	public CloseStruct Close;

	public ViForeignKey<ViAuraChannelStruct> effectChannel;
	public Int32 effectChannelWeight;
	public ViStaticArray<ViForeignKeyStruct<ViAuraTypeStruct>> DispelType = new ViStaticArray<ViForeignKeyStruct<ViAuraTypeStruct>>(DISPEL_MAX);
	public Int32 Reserve_0;
	public Int32 maxAuras;
	public ViEnum32<ViAuraDurationOverlap> maxAuraDurationOverlap;


	///<作用时间>
	public Int32 Reserve_1;
	public Int32 delay;
	public Int32 spreadSpeed;
	public Int32 tickCnt;
	public Int32 amplitude;
	public ViEnum32<BoolValue> IgnoreGround;

	public ViEnum32<BoolValue> NoUpGrade;
	public ViForeignKey<ViSpellStruct> X_spell;
	public Int32 Reserve_2;
	public Int32 Reserve_3;

	///<作用/结束条件>
	public ViStaticArray<ViUnitValueRange> activeCondition = new ViStaticArray<ViUnitValueRange>(CONDITION_MAX);
	public ViForeignKey<ViStateConditionStruct> activeState;

	public ViStaticArray<ViUnitValueRange> endCondition = new ViStaticArray<ViUnitValueRange>(CONDITION_MAX);
	public ViForeignKey<ViStateConditionStruct> endState;

	public Int32 Reserve_4;
	public ViEnum32<BoolValue> ImmediateUpdateProperty;
	public ViEnum32<BoolValue> RecordCaster;

	public Int32 actionStateMask;
	public Int32 auraStateMask;
	public ViForeignKey<ViSpellEffectStruct> RadiateEffect;

	public ViStaticArray<ViSpellValueStruct> valueSet = new ViStaticArray<ViSpellValueStruct>(VALUE_MAX);
	public ViSpellValueScaleStruct ValueScale = new ViSpellValueScaleStruct();
	public Int32 LevelValueScale;

	public ViStaticArray<ViMiscInt32> miscValue = new ViStaticArray<ViMiscInt32>(MISC_VALUE_MAX);
}

public struct ViSpellTravelStruct
{
	public ViEnum32<ViSpellTravelType> type;
	public Int32 speed;
	public Int32 range;//! 飞行范围
}

//+-----------------------------------------------------------------------------

public class ViSpellConditionStruct
{
	public ViStaticArray<ViUnitValueRange> Condition = new ViStaticArray<ViUnitValueRange>(3);
	public ViForeignKey<ViStateConditionStruct> State;
}

public class ViSpellProcStruct
{
	public static readonly UInt32 COST_MAX = 3;
	public static readonly UInt32 MISC_VALUE_MAX = 20;

	public struct AccumulateCountStruct
	{
		public Int32 MaxCount;
		public Int32 RecoverSpan;
	}

	public Int32 MiscValue(string key, Int32 defaultValue) { return miscValue.Value(key, defaultValue); }
	public Int32 MiscValue(string key) { return miscValue.Value(key); }

	public string ScriptFlow;
	public ViEnum32<BoolValue> Face;
	public ViMask32<ViUnitSocietyMask> focusTargetMask;
	public Int32 focusNatureIgnoreMask;
	public string ScriptFocus;
	public Int32 addStateMask;
	public Int32 delStateMask;
	public Int32 cutDurationMask;

	public ViEnum32<ViSpellLogType> LogType;
	public Int32 ActionPriority;
	public Int32 reserve_2;
	public Int32 reserve_3;
	public Int32 disableCD;

	public Int32 ActionStateMask;
	public ViSpellConditionStruct casterCondition = new ViSpellConditionStruct();
	public ViSpellConditionStruct focusCondition = new ViSpellConditionStruct();

	public ViEnum32<BoolValue> GlobalCD;
	public Int32 coolChannel;
	public Int32 coolDuration;

	public AccumulateCountStruct AccumulateCount;

	public Int32 prepareTime;
	public Int32 castTime;
	public Int32 castCnt;
	public Int32 castEndTime;
	public Int32 actCoolTime;

	public ViValueRange Range;

	public ViSpellTravelStruct Travel;

	public ViStaticArray<ViSpellCostStruct> cost = new ViStaticArray<ViSpellCostStruct>(COST_MAX);

	public ViStaticArray<ViMiscInt32> miscValue = new ViStaticArray<ViMiscInt32>(MISC_VALUE_MAX);
}

public class ViSpellEffectStruct: ViSealedData
{
	public struct HitEffectStruct
	{
		public ViForeignKey<ViAuraTypeStruct> Request;
		public ViForeignKey<ViAuraTypeStruct> NotRequest;
		public ViForeignKey<ViHitEffectStruct> Effect;
	}
	public struct AuraStruct
	{
		public ViForeignKey<ViAuraTypeStruct> Request;
		public ViForeignKey<ViAuraTypeStruct> NotRequest;
		public ViForeignKey<ViAuraStruct> Effect;
	}
	//
	public static readonly UInt32 EFFECT_MAX = 8;
	//
	public ViTargetSelectStruct Selector = new ViTargetSelectStruct();
	public ViEnum32<BoolValue> Own;
	public Int32 Reserve_0;
	public Int32 X_HitEffectCount;
	public ViStaticArray<HitEffectStruct> HitEffectInfo = new ViStaticArray<HitEffectStruct>(EFFECT_MAX);
	public Int32 X_AuraCount;
	public ViStaticArray<AuraStruct> AuraInfo = new ViStaticArray<AuraStruct>(EFFECT_MAX);

     public Int32 DelayTime;
     public Int32 BlockTime;
     public ViForeignKey<ViSpellEffectStruct> next;
}

public class ViSpellStruct : ViSealedData
{
	public static readonly UInt32 EFFECT_MAX = 12;
	//
	public struct ScruptEventStruct
	{
		public string Script;
		public Int32 Time;
	}

    public struct FlyStruct
    {
        public ViEnum32<ViSpellFlyType> flyType;
        public Int32 upDuration;
        public Int32 airDuration;
        public Int32 downDuration;
        public Int32 flyHigh;
        public Int32 Reserve_1;
        public Int32 Reserve_2;
    }

    public ViForeignKey<ViSealedDataTypeStruct> Type;
	public ViSpellProcStruct proc = new ViSpellProcStruct();

	public ViStaticArray<ScruptEventStruct> ScripttEventStructs = new ViStaticArray<ScruptEventStruct>(10);
	public ViStaticArray<ViForeignKeyStruct<ViSpellEffectStruct>> effect = new ViStaticArray<ViForeignKeyStruct<ViSpellEffectStruct>>(EFFECT_MAX);
	public ViStaticArray<ViForeignKeyStruct<ViHitEffectStruct>> ScriptHitEffect = new ViStaticArray<ViForeignKeyStruct<ViHitEffectStruct>>(8);
	public ViStaticArray<ViForeignKeyStruct<ViAuraStruct>> ScriptAura = new ViStaticArray<ViForeignKeyStruct<ViAuraStruct>>(8);

    public FlyStruct flyStruct = new FlyStruct();
}

public struct ViAuraDurationStruct
{
	public ViForeignKey<ViAuraStruct> Aura;
	public Int32 Duration;
}

