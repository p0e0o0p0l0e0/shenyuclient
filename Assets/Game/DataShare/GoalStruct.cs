using System;


public class GoalStruct : ViSealedData
{
    public class ContentStruct
	{
		public ViEnum32<GoalType> Type;
		public string Desc;
        public Int32 Count;
        public Int32 MaybeTargetValue;
		public ViEnum32<GoalCompleteIDMatchType> MatchType;
        public ViStaticArray<ViMiscInt32> MiscValues = new ViStaticArray<ViMiscInt32>(5);
	}

	public class RewardStruct
    {
        public ViStaticArray<ViForeignKeyStruct<LootStruct>> Loots = new ViStaticArray<ViForeignKeyStruct<LootStruct>>(5);
	}

    public override void Format()
    {
    }
    public override void Start()
    {

    }


    public string Icon;
    public string BGIcon;
    public string Description;
    public ViForeignKey<StoryStruct> Story;
    public ViActiveDuration Duration;
    public ViEnum32<GoalCategory> Type;
	public ViEnum32<BoolValue> AutoEnter;
	public ViForeignKey<ViSealedDataTypeStruct> Class;
	public ViForeignKey<GoalDisplayTypeStruct> DisplayType;
	public ViEnum32<ViDateLoopType> Loop;
    public ViForeignKey<PlayerLevelStruct> ReqLevel;
	public ViForeignKey<GoalStruct> ReqGoal;
    public ViForeignKey<GameFuncStruct> ReqFunc;
    public ContentStruct Content = new ContentStruct();
	public RewardStruct Reward = new RewardStruct();
	public ViForeignGroup<GoalStruct> AddGoalList = new ViForeignGroup<GoalStruct>();

    public ViEnum32<GoalTurnInType> TurnInType;
    public ViEnum32<BoolValue> ShowCompleteEffect;
    public ViEnum32<BoolValue> RollBackSaveData;
    public ViForeignKey<GoalStruct> RollBackGoal;
    public ViForeignKey<SpaceStruct> GoalSpaceId;
    public ViForeignKey<SpaceStruct> JumpSpaceId;
    public ViForeignKey<NPCBirthPositionStruct> NPCPoint;
    public ViForeignKey<SpaceObjectBirthPositionStruct> SpaceObjPoint;
    public ViEnum32<BoolValue> DynamicAddNPC;
    public ViEnum32<BoolValue> CanEnterStoryModel;
    public ViEnum32<BoolValue> CanExitStoryModel;
    public ViStaticArray<ViForeignKeyStruct<NPCBirthPositionStruct>> AddNPCList = new ViStaticArray<ViForeignKeyStruct<NPCBirthPositionStruct>>(10);
    public ViForeignKey<NPCBirthPositionStruct> TurnInGoalNPC;
}