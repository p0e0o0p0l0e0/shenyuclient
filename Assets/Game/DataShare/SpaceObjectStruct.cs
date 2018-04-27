using System;

public class SpaceObjectStruct: ViSealedData
{
	public struct RequestStruct
	{
		public ViForeignKey<ViStateConditionStruct> StateCondition;
		public ViMask32<FactionMask> FactionMask;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
	}

	public struct TransportStruct
	{
		public ViEnum32<SpaceObjectTransportType> Type;
		public ViVector3Struct Pos;
		public Int32 Speed;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
	}

	public struct EffectStruct
	{
		public ViForeignKey<ViSpellStruct> Spell;
		public ViEnum32<BoolValue> BroadcastLoot;
		public ViForeignKey<LootStruct> Loot;
		public ViForeignKey<ViVisualHitEffectStruct> Visual;
		public TransportStruct Transport;
	}

	public struct ActionStruct
	{
		public ViEnum32<BoolValue> Lock;
        public ViEnum32<BoolValue> UnlimitedCount;
        public Int32 Count;
		public Int32 ActionDuration;
		public Int32 RecoverSpan;
		public EffectStruct Effect;
	}

	public struct SpaceObjectVisualStruct
	{
		public ViForeignKey<PathFileResStruct> BodyRes;
		public ViForeignKey<PathFileResStruct> sound0;
	}

	public struct PickBoundStruct
	{
		public Int32 XMax;
		public Int32 YMax;
		public Int32 ZMax;
		public Int32 MinScale100;
	}

	public ViEnum32<SpaceObjectType> Type;
	public ViForeignKey<ViSealedDataTypeStruct> Class;
	public ViEnum32<BoolValue> TriggerAlwaysActive;
    public Int32 EnterSpaceDuration;
	public Int32 ExitSpaceDuration;
	public Int32 CorpseTime;
	public Int32 ReliveTime;
	public Int32 Height;
	public Int32 UpdateSpan;
	public ViAreaStruct Body;
	public RequestStruct Request;
	public ViForeignKey<VisualProgressBarStruct> Progress;
	public ActionStruct Action;
	public EffectStruct EndEffect;
	public ViForeignKey<PathFileResStruct> Resource;
	public ViForeignKey<PathFileResStruct> Resource2;
	public SpaceObjectVisualStruct EnterSpaceVisualResource;
	public SpaceObjectVisualStruct DieVisualResource;
	public PickBoundStruct PickBound;
	public Int32 Scale100;
	public Int32 VisualHeight;
	public ViForeignKey<SpaceObjectStruct> FactionSet;
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
    public ViEnum32<EntityCategory> entityCategory;
    public ViForeignKey<GoalStruct> StoryGoal;
}
