using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务标识
/// </summary>
public interface IGoalFlag
{
    int BirthID { get;}
    void ShowGoalFlag();
    void CloseGoalFlag();
}
/// <summary>
/// 任务地图数据接口
/// </summary>
public interface IGoalMapInterface
{
    uint ID { get;}
    //
    GoalStateType StateType { get; set; }

    uint EntityID { get; }

    ViEnum32<EntityCategory> EntityCategory { get; }

    ViVector3 EntityPosition { get;}

    int SpaceID { get; }
}
/// <summary>
/// 计数类型数据接口
/// </summary>
interface IGoalCountInterface
{
    int MaybeTargetValue { get; set; }
    int CurrentCount { get; set; }

    bool IsEnouth();
}
/// <summary>
/// 任务类对象
/// </summary>
#region  GoalObject
public class GoalObject : IGoalMapInterface
{
    private const int Distance = 2;
    private const int EffectDuration = 50;

    public enum GoalObjectState
    {
        None = 0,
        Idle,
        Moving,
        Doing,
        Done,
        End,
    }
    public uint ID { get; private set; }
    public int NeedLevel { get; private set; }
    public int Count { get; private set; }
    public uint StoryID { get; private set; }
    public string Name { get; private set; }
    public string Icon { get; private set; }
    public string BGIcon { get; private set; }
    public string Description { get; private set; }
    public string StoryName { get; private set; }
    public string StoryEndConditionName { get; private set; }
    /// <summary>
    /// 自动完成任务
    /// </summary>
    public bool IsAutoTurnIn { get; private set; }
    /// <summary>
    /// 点击后完成任务
    /// </summary>
    public bool IsClickTurnIn { get; private set; }
    /// <summary>
    /// 到目标npc处交任务
    /// </summary>
    public bool IsTargetNPCTurnIn { get; private set; }
    public bool IsDynamicAddNPC { get; private set; }
    public bool IsShowEffect { get; private set; }
    public bool IsEnterStoryModel { get; private set; }
    public bool IsExitStoryModel { get; private set; }

    public GoalType Type { get; private set; }
    public GoalObjectState State { get; private set; }
    public GoalCategory Category { get; private set; }
    public List<LootItemInfo> LootItemInfoList { get; private set; }
    public ReceiveDataGoalProperty Property { get; private set; }
    protected GoalStruct GoalInfo { get; private set; }
    public bool IsLevelEnouth { get { return NeedLevel <= Player.Instance.Property.Level; } }
    public bool IsMainLine { get { return Category == GoalCategory.MAINLINE; } }
    public bool IsBranchLine { get { return Category == GoalCategory.BRANCHLINE; } }
    public bool IsTalkToNPC { get { return Type == GoalType.HUNTER_TALK_TO_NPC; } }
    public bool IsGoalCountInterface { get { return IsKillNPC || IsCollectSpaceObject; } }
    public bool IsKillNPC { get { return Type == GoalType.HUNTER_KILL_NPC; } }
    public bool IsCollectSpaceObject { get { return Type == GoalType.HUNTER_COLLECT_SPACE_OBJECT; } }
    public bool IsOpenFunctonUI { get { return Type == GoalType.HUNTER_OPEN_FUNCTION_UI; } }
    public bool IsJumpSpace { get { return Type == GoalType.HUNTER_JUMP_SPACE; } }
    public bool IsMoving { get { return State == GoalObjectState.Moving; } }
    public bool IsDoing { get { return State == GoalObjectState.Doing; } }
    public bool IsDone { get { return State == GoalObjectState.Done; } }
    public bool IsNotDone { get { return !IsDone && !IsEnd; } }
    public bool IsEnd { get { return State == GoalObjectState.End; } }
    public bool HasStory { get{ return StoryName.IsNotNullOrEmpty(); } }
    public bool IsStoryEnd { get; protected set; }
    public bool CanDo { get { return (HasStory && IsStoryEnd) || !HasStory; } }

    public GoalStateType StateType  { get;set;  }
    public uint EntityID { get; protected set; }
    public int EntityBirthID { get; protected set; }
    public ViEnum32<EntityCategory> EntityCategory {get; protected set; }
    public ViVector3 EntityPosition   {get; protected set; }
    public int SpaceID { get; private set; }
    public ViVector3 TurnInNPCPos { get; protected set; }
    public int TurnInSpaceID { get; private set; }

    public Action ActionUpdateStateInfo { get; set; }
    public Action<int, int> ActionUpdateCount { get; set; }
    public Action<GoalObject> ActionEnd { get; set; }

    public Action ActionPlayerEffect = null;
    //oldstatetype,Newstatetype
    public Action<GoalStateType, GoalStateType> ActionGoalUpdate { get; set; }

    public virtual void Init(ReceiveDataGoalProperty goalProperty)
    {
        Property = goalProperty;
        InitData(goalProperty.Info.Value);

        switch ((GoalState)goalProperty.State.Value)
        {
            case GoalState.COMPLETE:
            case GoalState.FAIL:
                SetState(GoalObjectState.End);
                break;
            case GoalState.CLICK_REWARD:
                SetState(GoalObjectState.Done);
                break;
            default:
                SetState(GoalObjectState.Idle);
                break;
        }
        EventDispatcher.AddEventListener<string, string, object>(Events.StoryEvent.PlayStoryEnd, OnStoryEndCallBack);
    }
    public virtual void Init(GoalStruct goalConfig)
    {
        InitData(goalConfig);

        SetState(GoalObjectState.End);
    }
    protected virtual void InitData(GoalStruct goalConfig)
    {
        GoalInfo = goalConfig;
        ID = (uint)GoalInfo.ID;
        Name = GoalInfo.Name;
        Description = GoalInfo.Description;
        Category = (GoalCategory)GoalInfo.Type.Value;
        Type = (GoalType)GoalInfo.Content.Type.Value;
        int flag = GetCategoryIndex();
        Icon = string.IsNullOrEmpty(GoalInfo.Icon) ? UIGoalDefine.ICONARRAY[flag] : GoalInfo.Icon;
        BGIcon = string.IsNullOrEmpty(GoalInfo.BGIcon) ? UIGoalDefine.BGARRAY[flag] : GoalInfo.BGIcon;
        NeedLevel = GoalInfo.ReqLevel.Value;
        IsAutoTurnIn = (GoalTurnInType)GoalInfo.TurnInType.Value == GoalTurnInType.AUTO;
        IsClickTurnIn = (GoalTurnInType)GoalInfo.TurnInType.Value == GoalTurnInType.CLICK;
        IsTargetNPCTurnIn = (GoalTurnInType)GoalInfo.TurnInType.Value == GoalTurnInType.TARGETNPC;
        Count = GoalInfo.Content.Count;
        IsShowEffect = GoalInfo.ShowCompleteEffect.IsTrue();
        IsEnterStoryModel = GoalInfo.CanEnterStoryModel.IsTrue();
        IsExitStoryModel = GoalInfo.CanExitStoryModel.IsTrue();
        IsDynamicAddNPC = GoalInfo.DynamicAddNPC.IsTrue();
        StoryID = (uint)GoalInfo.Story.Value;
        InitLootItems();

        if (GoalInfo.Story.PData.IsNotNull())
        {
            StoryName = GoalInfo.Story.PData.StoryName;
            StoryEndConditionName = GoalInfo.Story.PData.StoryEndConditionName;
        }

        if (GoalInfo.GoalSpaceId.PData.IsNull())
            UConsole.Log(UConsoleDefine.Goal, "GoalSpaceId 数据为空.id ={0},name ={1}", ID, Name);
        else
            SpaceID = GoalInfo.GoalSpaceId.PData.ID;

        IsStoryEnd = StoryEndConditionName.IsNullOrEmpty();

        if (IsTargetNPCTurnIn)
        {
            if (GoalInfo.TurnInGoalNPC.PData.IsNull())
                UConsole.Log(UConsoleDefine.Goal, "TurnInGoalNPC 数据为空.id ={0},name ={1}", ID, Name);
            else
            {
                TurnInSpaceID = GoalInfo.TurnInGoalNPC.Data.Space;
                TurnInNPCPos = GoalInfo.TurnInGoalNPC.Data.Position;
            }
        }
    }
    public virtual void UpdateGoal(ReceiveDataGoalProperty goalProperty)
    {
        Property = goalProperty;
        InitData(goalProperty.Info.Value);
    }
    public virtual void Dispose()
    {
        Property = null;
        GoalInfo = null;
        _node1 = null;
        ActionEnd = null;
        ActionUpdateCount = null;
    }
    public override string ToString()
    {
        return string.Format("id ={0},\t name ={1},\t needlevel={2},\t storyName ={3},\t category={4},\t type = {5},\t autoReward={6},\t description= {7},\t spaceID = {8}\t ",
            ID, Name, NeedLevel, StoryName, Category, Type, IsAutoTurnIn,Description, SpaceID);
    }
    public void LoadStoryPrefab()
    {
        if (CellHero.LocalHero != null)
        {
            if (IsInRightSpace(SpaceID))
            {
                GoalManager.GetInstance.LoadStory(StoryName);
            }
        }
    }
    public bool DoGoal()
    {
        if (IsEnd)
        {
            UConsole.Log("这个任务已经完成,ID = " + ID);
            return false;
        }
        if (IsDone)
        {
            if (IsAutoTurnIn)
            {
                return false;
            }
            else if (IsClickTurnIn)
            {
                GoalManager.GetInstance.ClickReward(ID);
            }
            else if (IsTargetNPCTurnIn)
            {
                if (!IsInRightSpace(TurnInSpaceID))
                {
                    MoveToRightSpace(TurnInSpaceID);
                }
                else if(!IsArrived(TurnInNPCPos))
                {
                    MoveToTargetPos(TurnInNPCPos);
                }
                else
                {
                    //TODO openui turnin goal

                }
            }
        }
        else
        {
            if (!IsInRightSpace(SpaceID))
            {
                MoveToRightSpace(SpaceID);
                return true;
            }
            
            if (!IsArrived(EntityPosition))
            {
                MoveToTargetPos(EntityPosition);
            }
            else
            {
                SetState(GoalObjectState.Doing);
            }
        }
        return true;
    }
    public void NavMove()
    {
        SetState(GoalObjectState.Moving);

    }
    public void MoveEnd()
    {
        if (IsDone)
        {
            if (IsInRightSpace(TurnInSpaceID))
            {
                if (IsArrived(TurnInNPCPos))
                {
                    //TODO openui turnin goal

                }
            }
        }
        else
        {
            if (IsInRightSpace(SpaceID))
            {
                if (IsArrived(EntityPosition))
                {
                    SetState(GoalObjectState.Doing);
                }
            }
        }
    }
    public void BreakMove()
    {
        SetState(GoalObjectState.Idle);
    }
    public void LevelUp()
    {
        if (ActionUpdateStateInfo != null)
            ActionUpdateStateInfo();
    }
    public void GoalEndNeedClick()
    {
        SetState(GoalObjectState.Done);
    }
    public virtual void End()
    {
        if (ActionPlayerEffect != null)
            ActionPlayerEffect();
        if (IsShowEffect)
            GoalManager.GetInstance.ShowGoalCompleteUI();
        ViTimerInstance.SetTime(_node1, EffectDuration, _OnEffectEnd);
        EventDispatcher.RemoveEventListener<string, string, object>(Events.StoryEvent.PlayStoryEnd, OnStoryEndCallBack);
    }
    protected virtual void Do()
    {

    }
    protected virtual void Done()
    {
        if (ActionUpdateStateInfo != null)
            ActionUpdateStateInfo();
    }
    protected void SetState(GoalObjectState state)
    {
        State = state;
        switch (state)
        {
            case GoalObjectState.Doing:
                EventDispatcher.TriggerEvent(Events.StoryEvent.ArriveTargetPlace);
                SetStateType(GoalStateType.UnderWay);
                Do();
                break;
            case GoalObjectState.Done:
                if(IsAutoTurnIn)
                    SetStateType(GoalStateType.Finishi);
                else
                    SetStateType(GoalStateType.CanReceive);
                Done();
                break;
            case GoalObjectState.Idle:
            case GoalObjectState.Moving:
                SetStateType(GoalStateType.UnderWay);
                break;
            case GoalObjectState.End:
                SetStateType(GoalStateType.Finishi);
                if (ActionEnd != null)
                    ActionEnd(this);
                break;
        }
    }
    protected virtual void MoveToRightSpace(int spaceID)
    {
        SpaceObjectBirthPositionStruct birthPos = GameSpaceRecordInstance.Instance.LogicInfo.GetTelePortPoint(spaceID);

        if (birthPos != null)
        {
            if (IsPointUseful(birthPos.Position))
            {
                GoalManager.GetInstance.MoveTo(birthPos.Position);
            }
            else
                UConsole.Log("MoveToRightSpace  数据不对，无处可去");
        }
        else
        {
            //TODO zlj 炉石开启用传送	
            //传送点不存在 TP主城
            GoalManager.GetInstance.GotoSpace(Client.VALUE_MainCitySpaceId);
        }

    }
    protected virtual void MoveToTargetPos(ViVector3 v3)
    {
        if (IsPointUseful(v3))
        {
            GoalManager.GetInstance.MoveTo(v3);
        }
        else
            UConsole.Log(UConsoleDefine.Goal, "目标点位置为空.id ={0},name ={1}", ID, Name);
    }
    protected bool IsPointUseful(ViVector3 viv3)
    {
        return !viv3.Equals(ViVector3.ZERO);
    }
    public bool IsInRightSpace(int spaceID)
    {
        return spaceID == GameSpaceRecordInstance.Instance.Property.Info.Value.ID;
    }
    protected virtual bool IsArrived(ViVector3 v3)
    {
        float distance = ViVector3.DistanceH(CellHero.LocalHero.Position, v3);
        return distance <= Distance;
    }
    protected virtual void OnStoryEndCallBack(string storyName, string storyConditionName, object arg)
    {
        if (StoryName.Equals(storyName))
        {
            if (StoryEndConditionName.IsNotNullOrEmpty() && storyConditionName.Equals(StoryEndConditionName))
            {
                IsStoryEnd = true;
                Do();
            }
        }
    }

    protected void OnNPCCreated(IGoalFlag npc)
    {
        if (npc.IsNull())
        {
            return;
        }
        if (npc.BirthID != EntityBirthID)
        {
            return;
        }
        SetGoalFlag(true, npc);
    }
    protected void SetGoalFlag(bool show, IGoalFlag npc)
    {
        if (npc.IsNull())
        {
            return;
        }
        if (show)
        {
            npc.ShowGoalFlag();
        }
        else
        {
            npc.CloseGoalFlag();
        }
    }
    protected IGoalFlag GetTargetNPC(int id)
    {
        IGoalFlag flag = HeroController.Instance.GetNPCByPos(id);

        if (flag.IsNull())
        {
            flag = StoryCharacterFactory.GetStoryCharacter(id,1) as IGoalFlag;
        }
        return flag;
    }

    private void InitLootItems()
    {
        LootItemInfoList = new List<LootItemInfo>();
        ViStaticArray<ViForeignKeyStruct<LootStruct>> loots = GoalInfo.Reward.Loots;
        for (int i = 0; i < loots.Length; i++)
        {
            if (loots[i].PData == null)
                continue;
            if (loots[i].PData.Item1.PData != null)
            {
                ViStaticArray<LootItem1Struct.NodeStruct> item1List = loots[i].PData.Item1.PData.List;
                for (int j = 0; j < item1List.Length; j++)
                {
                    if (item1List[j].Item.Count == 0)
                        continue;
                    if (item1List[j].Item.Item.PData == null)
                        continue;
                    for (int k = 0; k < item1List[j].Item.Count; k++)
                    {
                        if (item1List[j].Item.Item.Empty())
                            continue;
                        LootItemInfo info = new LootItemInfo(item1List[j].Item.Item);
                        LootItemInfoList.Add(info);
                    }
                }
            }
            for (int j = 0; j < loots[i].PData.Item2.Array.Length; j++)
            {
                LootItem2Struct item2Struct = loots[i].PData.Item2[j].PData;
                if (item2Struct == null)
                    continue;
                if (item2Struct.Count == 0)
                    continue;
                for (int k = 0; k < item2Struct.Count; k++)
                {
                    if (item2Struct.Item[k].Data.IsEmpty())
                        continue;
                    for (int m = 0; m < item2Struct.Item[k].Data.Count.Value; m++)
                    {
                        if (item2Struct.Item[k].Data.Item.Empty())
                            continue;
                        LootItemInfo info = new LootItemInfo(item2Struct.Item[k].Data.Item);
                        LootItemInfoList.Add(info);
                    }
                }
            }
            for (int j = 0; j < loots[i].PData.Item3.Array.Length; j++)
            {
                LootItem3Struct item3Struct = loots[i].PData.Item3[j].PData;
                if (item3Struct == null)
                    continue;
                if (item3Struct.Count == 0)
                    continue;
                for (int k = 0; k < item3Struct.Count; k++)
                {
                    if (item3Struct.Item[k].Data.IsEmpty())
                        continue;
                    for (int m = 0; m < item3Struct.Item[k].Data.Count.Value; m++)
                    {
                        if (item3Struct.Item[k].Data.Item.Empty())
                            continue;
                        LootItemInfo info = new LootItemInfo(item3Struct.Item[k].Data.Item);
                        LootItemInfoList.Add(info);
                    }
                }
            }
            for (int j = 0; j < loots[i].PData.Item5.Array.Length; j++)
            {
                LootItem5Struct item5Struct = loots[i].PData.Item5[j].PData;
                if (item5Struct == null)
                    continue;
                for (int k = 0; k < item5Struct.Item.Length; k++)
                {
                    LootItem4Struct item4Struct = item5Struct.Item[k];
                    for (int m = 0; m < item4Struct.Item.Count.Value; m++)
                    {
                        if (item4Struct.Item.Item.Empty())
                            continue;
                        LootItemInfo info = new LootItemInfo(item4Struct.Item.Item);
                        LootItemInfoList.Add(info);
                    }
                }
            }
            for (int j = 0; j < loots[i].PData.Item6.Array.Length; j++)
            {
                LootItem6Struct item6Struct = loots[i].PData.Item6[j].PData;
                if (item6Struct == null)
                    continue;
                for (int k = 0; k < item6Struct.Item.Length; k++)
                {
                    LootItem4Struct item4Struct = item6Struct.Item[k];
                    for (int m = 0; m < item4Struct.Item.Count.Value; m++)
                    {
                        if (item4Struct.Item.Item.Empty())
                            continue;
                        LootItemInfo info = new LootItemInfo(item4Struct.Item.Item);
                        LootItemInfoList.Add(info);
                    }
                }
            }
        }
        
    }
    private void _OnEffectEnd(ViTimeNodeInterface nodeInterface)
    {
        SetState(GoalObjectState.End);
    }
    private void SetStateType(GoalStateType stateType)
    {
        if (StateType == stateType)
            return;

        GoalStateType oldType = StateType;
        StateType = stateType;

        if (ActionGoalUpdate != null)
            ActionGoalUpdate(oldType, StateType);
    }
    private int GetCategoryIndex()
    {
        switch (Category)
        {
            case GoalCategory.MAINLINE:
                return 0;
            case GoalCategory.BRANCHLINE:
            case GoalCategory.ACTIVITY:
            case GoalCategory.WEEKLY:
            case GoalCategory.ORIENTATION:
                return 1;
            case GoalCategory.TEAM:
            case GoalCategory.TRANSFER:
            case GoalCategory.LOVE:
            case GoalCategory.ADVENTURER:
            case GoalCategory.UNION:
            default:
                return 2;
        }
    }
    
    ViTimeNode1 _node1 = new ViTimeNode1();
}
#endregion

