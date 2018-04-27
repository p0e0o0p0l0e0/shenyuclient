using System;

public class GameFuncStruct : ViSealedData
{
    public class FuncUIStruct
    {
        public string UIName;
        public Int32 PageTag1;
        public Int32 PageTag2;
    }

	public ViForeignKey<GameFuncStruct> Parent;
	public ViForeignKey<ActivityStruct> ReqActivity;
	public ViForeignKey<PlayerLevelStruct> ReqPlayerLevel;
	public Int32 ReqGMLevel;
	public ViForeignKey<ViEmptySealedData> Visual;
	public string Entity;
	public string Icon;
    public FuncUIStruct FuncUI = new FuncUIStruct();
    public ViForeignGroup<GoalStruct> AddGoalList = new ViForeignGroup<GoalStruct>();
}

public class GameFuncPolicyStruct : ViSealedData
{
	public Int32 OpenCount;
	public ViStaticArray<ViForeignKeyStruct<GameFuncStruct>> Open = new ViStaticArray<ViForeignKeyStruct<GameFuncStruct>>(30);
	public Int32 CloseCount;
	public ViStaticArray<ViForeignKeyStruct<GameFuncStruct>> Close = new ViStaticArray<ViForeignKeyStruct<GameFuncStruct>>(30);
}
