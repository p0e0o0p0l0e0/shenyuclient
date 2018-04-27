//#define Log
using System.Collections.Generic;
using UnityEngine;
using System;
using Utils;

public class GoalManager : DataManagerBase<GoalManager>, IRelease
{
    private UIGoalController _uiController;
    public UIGoalController UIController {
        get {
            if (_uiController == null)
                _uiController = UIManager.Instance.GetController<UIGoalController, UIGoalWindow>(UIControllerDefine.WIN_Goal);
            return _uiController;
        }
    }
    private ViAsynCallback<ViReceiveDataNode, object> _goalListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private ViAsynCallback<ViReceiveDataNode, object> _goalCompletedListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private ViAsynCallback<ViReceiveDataNode, object> _goalRewardListCallback = new ViAsynCallback<ViReceiveDataNode, object>();

    private OrderByComparer<GoalObject>[] _orderby = new OrderByComparer<GoalObject>[]
    {  new OrderByInt<GoalObject>((goal)=> { return (int)goal.Category; }, false), };

    private Dictionary<uint, GoalObject> _completedGoalDict = new Dictionary<uint, GoalObject>();
    public List<GoalObject> GoalList { get { return _goalList; } }
    private List<GoalObject> _goalList = new List<GoalObject>();

    private List<GoalObject> _addList = new List<GoalObject>();
    private List<uint> _removeList = new List<uint>();
    public GoalObject Current { get; private set; }
    
    public void Release()
    {
        End();
    }
    public void Start()
    {
#if Log
        UConsole.IsLog = true;
#else
        UConsole.IsLog = false;
#endif
        Player.Instance.Property.GoalList.CallbackList.Attach(_goalListCallback, this._GoalListUpdated);
        Player.Instance.Property.GoalCompletedList.CallbackList.Attach(_goalCompletedListCallback, this._GoalCompletedListUpdated);
        Player.Instance.Property.GoalRewardList.CallbackList.Attach(_goalRewardListCallback, this._GoalRewardListUpdated);

        EventDispatcher.AddEventListener(Events.SceneCommonEvent.CreatedLocalHero, _OnCreatedLocalHero);
        EventDispatcher.AddEventListener(Events.SceneCommonEvent.CreatedLocalHeroModel, _OnCreatedLocalHeroModel);
        EventDispatcher.AddEventListener<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, _OnPlayerMoveEnd);
        EventDispatcher.AddEventListener(Events.PlayerEvent.PlayerBreakMove, _OnPlayerBreakMove);
        EventDispatcher.AddEventListener<AutoPathType, List<ViVector3>>(Events.PlayerEvent.PlayerNavMove, _OnPlayerNavMove);
        EventDispatcher.AddEventListener<uint>(Events.GoalEvent.OnGoalEndNeedClick, _OnGoalEndNeedClick);
        EventDispatcher.AddEventListener<int>(Events.PlayerEvent.PlayerLevelUpdated, _OnPlayerLevelUpdated);
        EventDispatcher.AddEventListener<uint, bool>(Events.StoryEvent.SetStoryModel, _OnSetStoryModel);
        EventDispatcher.AddEventListener<string>(Events.StoryEvent.StoryStart, _OnStoryStart);

        StoryManager.GetInstance.Init();
        //初始化已完成
        _GoalCompletedListUpdated(0, null, null);
    }

    public void End()
    {
        EventDispatcher.RemoveEventListener(Events.SceneCommonEvent.CreatedLocalHero, _OnCreatedLocalHero);
        EventDispatcher.RemoveEventListener(Events.SceneCommonEvent.CreatedLocalHeroModel, _OnCreatedLocalHeroModel);
        EventDispatcher.RemoveEventListener<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, _OnPlayerMoveEnd);
        EventDispatcher.RemoveEventListener(Events.PlayerEvent.PlayerBreakMove, _OnPlayerBreakMove);
        EventDispatcher.RemoveEventListener<AutoPathType, List<ViVector3>>(Events.PlayerEvent.PlayerNavMove, _OnPlayerNavMove);
        EventDispatcher.RemoveEventListener<uint>(Events.GoalEvent.OnGoalEndNeedClick, _OnGoalEndNeedClick);
        EventDispatcher.RemoveEventListener<int>(Events.PlayerEvent.PlayerLevelUpdated, _OnPlayerLevelUpdated);
        EventDispatcher.RemoveEventListener<uint, bool>(Events.StoryEvent.SetStoryModel, _OnSetStoryModel);
        EventDispatcher.RemoveEventListener<string>(Events.StoryEvent.StoryStart, _OnStoryStart);

        _goalListCallback.End();
        _goalCompletedListCallback.End();
        _goalRewardListCallback.End();
        _uiController = null;
        if (_completedGoalDict != null)
            _completedGoalDict.Clear();
        if (_goalList != null)
            _goalList.Clear();
        if (_addList != null)
            _addList.Clear();
        if (_removeList != null)
            _removeList.Clear();
        if (Current != null)
        {
            Current.Dispose();
        }
    }
    private void _GoalListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        bool updateUI = false;
        foreach (KeyValuePair<uint, ViReceiveDataDictionaryNode<uint, ReceiveDataGoalProperty>> pair in Player.Instance.Property.GoalList.Array)
        {
            updateUI |= AddGoal(pair.Value.Property);
        }
        if (updateUI)
            _UpdateUI();
    }
    private void _GoalCompletedListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        foreach (KeyValuePair<UInt32, ViReceiveDataSetNode<UInt32>> pair in Player.Instance.Property.GoalCompletedList.Array)
        {
            CompletedGoal(pair.Key);
        }
    }
    private void _GoalRewardListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        foreach (KeyValuePair<UInt32, ViReceiveDataSetNode<UInt32>> pair in Player.Instance.Property.GoalRewardList.Array)
        {
            UConsole.Log(UConsoleDefine.Goal, "_GoalRewardListUpdated,id:{0}", pair.Key);
        }
    }
    private void _OnCreatedLocalHero()
    {
        UConsole.Log(UConsoleDefine.Goal, "GoalList:{0},GoalCompletedList:{1},GoalRewardList:{2}", Color.green,
            Player.Instance.Property.GoalList.Count,
            Player.Instance.Property.GoalCompletedList.Array.Count,
            Player.Instance.Property.GoalRewardList.Array.Count);

        if (Current.IsNotNull())
        {
            if (Current.IsMoving)
                Current.DoGoal();
        }
    }
    private void _OnCreatedLocalHeroModel()
    {
        for (int i = 0; i < _goalList.Count; i++)
        {
            if (!_completedGoalDict.ContainsKey(_goalList[i].ID))
            {
                if (_goalList[i].IsNotDone)
                {
                    _goalList[i].LoadStoryPrefab();
                }
            }
        }
    }
    private void _OnPlayerBreakMove()
    {
        if (Current.IsNotNull())
        {
            if (Current.IsMoving)
                Current.BreakMove();
        }
    }

    private void _OnPlayerMoveEnd(AutoPathType type)
    {
        if (type == AutoPathType.Goal)
        {
            if (Current.IsNotNull())
            {
                if (Current.IsMoving)
                    Current.MoveEnd();
            }
        }
        else if (type == AutoPathType.ClickNPC)
        {
            CellNPC npcEntity = Client.Current.EntityManager.GetPackEntity<GameUnit>(CellHero.LocalHero.Property.FocusEntity) as CellNPC;
            if (npcEntity == null)
                return;

            //TODO zlj 某些NPC可接任务

            for (int i = 0; i < _goalList.Count; i++)
            {
                if (_goalList[i].EntityID != npcEntity.LogicInfo.ID)
                    continue;
                if (_goalList[i].HasStory)
                    EventDispatcher.TriggerEvent(Events.StoryEvent.ArriveTargetPlace);
                else
                {
                    if (npcEntity.LogicInfo.GameFunc.PData.IsNotNull())
                    {
                        string uiName = npcEntity.LogicInfo.GameFunc.PData.FuncUI.UIName;
                        if (uiName.IsNotNullOrEmpty())
                            UIManager.Instance.Show(uiName, null);
                    }
                }
            }
        }
    }

    private void _OnPlayerNavMove(AutoPathType arg1, List<ViVector3> arg2)
    {
        if (Current.IsNotNull())
        {
            if (arg1 == AutoPathType.Goal)
                Current.NavMove();
            else
                Current.BreakMove();
        }
    }

    private void _OnPlayerLevelUpdated(int level)
    {
        for (int i = 0; i < _goalList.Count; i++)
        {
            _goalList[i].LevelUp();
        }
    }
    private void _OnStoryStart(string storyName)
    {
        GoalObject goal = _goalList.Find(_goal => _goal.StoryName.Equals(storyName));
        if (goal != null && goal.IsDynamicAddNPC)
            LoadGoalNPC(goal.ID);
    }

    private void _OnSetStoryModel(uint goalID, bool enter)
    {
        UConsole.Log(UConsoleDefine.Goal, "_OnSetStoryModel,goalID:{0},enter:{1}", goalID, enter);
        GoalObject goalObject = GetGoalObject(goalID);
        if (goalObject.IsNotNull())
        {
            if (enter)
            {
                if (goalObject.IsEnterStoryModel)
                {
                    StoryManager.GetInstance.EnterStoryModel(goalObject.StoryName);
                    EventDispatcher.TriggerEvent<bool>(Events.GoalEvent.UpdateMapInfo, false);
                    EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, GoalStateType.Acceptable, new List<IGoalMapInterface>());
                    EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, GoalStateType.CanReceive, new List<IGoalMapInterface>());
                    EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, GoalStateType.UnderWay, new List<IGoalMapInterface>() { goalObject as IGoalMapInterface });

                }
            }
            else
            {
                if (goalObject.IsExitStoryModel)
                {
                    StoryManager.GetInstance.ExitStoryModel(goalObject.StoryName);
                    EventDispatcher.TriggerEvent<bool>(Events.GoalEvent.UpdateMapInfo, true);
                    EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, GoalStateType.Acceptable, GetGoalMapList(GoalStateType.Acceptable));
                    EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, GoalStateType.CanReceive, GetGoalMapList(GoalStateType.CanReceive));
                    EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, GoalStateType.UnderWay, GetGoalMapList(GoalStateType.UnderWay));
                }
            }
        }
    }

    private void _OnGoalStateChange(GoalStateType oldType, GoalStateType newType)
    {
        EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, oldType, GetGoalMapList(oldType));
        EventDispatcher.TriggerEvent<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, newType, GetGoalMapList(newType));
    }
    private void _OnGoalEndNeedClick(uint id)
    {
        GoalObject goalObject = GetGoalObject(id);
        if (goalObject.IsNotNull())
        {
            goalObject.GoalEndNeedClick();
        }
    }
    private void _OnGoalClientEnd(GoalObject goalObject)
    {
        _removeList.Remove(goalObject.ID);
        _goalList.Remove(goalObject);

        if (!_completedGoalDict.ContainsKey(goalObject.ID))
        {
            _completedGoalDict.Add(goalObject.ID, goalObject);

            if (UIController != null)
                UIController.KillGoalItem(goalObject.ID);
        }

        if (_addList.Count > 0 && _removeList.Count == 0)
        {
            for (int i = 0; i < _addList.Count; i++)
                AddGoal(_addList[i]);
            _addList.Clear();

            _UpdateUI();
        }
        EventDispatcher.TriggerEvent<uint>(Events.GoalEvent.OnGoalComplete, goalObject.ID);
    }
    private void _UpdateUI()
    {
        if (UIController != null)
            UIController.UpdateGoalList(GoalList);
    }
    public void ShowGoalCompleteUI()
    {
        if (UIController != null)
            UIController.ShowGoalCompleteUI();
    }
    public bool AddGoal(ReceiveDataGoalProperty goalProperty)
    {
        GoalObject goalObject = GetGoalObject((uint)goalProperty.Info.Value.ID);
        if (goalObject.IsNull())
        {
            goalObject = GoalFactory.Generate(goalProperty);
            goalObject.ActionGoalUpdate = _OnGoalStateChange;

            if (_removeList.Count > 0)
            {
                _addList.Add(goalObject);
                return false;
            }
            else
                AddGoal(goalObject);
        }
        else
        {
            goalObject.UpdateGoal(goalProperty);
            return false;
        }

        return true;
    }
    public void AddGoal(GoalObject goalObject)
    {
        //添加规则改变，主线最前面，其余最新在最前
        if (goalObject.IsMainLine)
        {
            _goalList.Insert(0, goalObject);
        }
        else
        {
            int flag = -1;
            for (int i = 0; i < _goalList.Count; i++)
            {
                if (!_goalList[i].IsMainLine)
                {
                    flag = i;
                    break;
                }
            }
            if (flag >= 0)
                _goalList.Insert(flag, goalObject);
            else
                _goalList.Add(goalObject);
        }

        goalObject.LoadStoryPrefab();
    }
    /// <summary>
    /// 按照任务类型先后顺序去排序
    /// </summary>
    private void SortGoal()
    {
        GoalObject temp = null;
        for (int i = 0; i < _goalList.Count; i++)
        {
            for (int j = i; j < _goalList.Count; j++)
            {
                if ((int)_goalList[i].Category > (int)_goalList[j].Category)
                {
                    temp = _goalList[i];
                    _goalList[i] = _goalList[j];
                    _goalList[j] = temp;
                }
            }
        }
    }
    public void CompletedGoal(uint id)
    {
        if (!_completedGoalDict.ContainsKey(id))
        {
            GoalObject goalObject = GetGoalObject(id);

            if (goalObject.IsNotNull())
            {
                _removeList.Add(id);
                goalObject.ActionEnd = _OnGoalClientEnd;
                goalObject.End();
            }
            else
            {
                goalObject = GoalFactory.Generate(id);
                _completedGoalDict.Add(goalObject.ID, goalObject);
            }
        }
    }
    public void RemoveGoal(uint id)
    {
        GoalObject goalObject = GetGoalObject(id);
        if (goalObject.IsNotNull())
        {
            _goalList.Remove(goalObject);
        }
        else
            UConsole.LogError(UConsoleDefine.Goal, "RemoveGoal 没找到这个任务，id =" + id);
    }
    public void RemoveCompletedGoal(uint id)
    {
        if (_completedGoalDict.ContainsKey(id))
        {
            _completedGoalDict.Remove(id);
        }
        else
            UConsole.LogError(UConsoleDefine.Goal, "RemoveCompletedGoal 没找到这个任务，id =" + id);
    }
    public void ClearGoal()
    {
        for (int i = 0; i < _goalList.Count; i++)
        {
            _goalList[i].Dispose();
        }
        _goalList.Clear();
    }
    public void ClearCompletedGoal(uint id)
    {
        foreach (var item in _completedGoalDict)
        {
            item.Value.Dispose();
        }
        _completedGoalDict.Clear();
    }
    public GoalObject GetGoalObject(uint id)
    {
        return _goalList.Find((_item) => _item.ID == id);
    }
    public GoalObject[] GetGoalArray()
    {
        return _goalList.ToArray();
    }
    public List<GoalObject> GetGoalDetailList()
    {
        List<GoalObject> goalDetailList = new List<GoalObject>();
        //主线完成和进行中都添加
        //其余类型只添加进行中
        foreach (KeyValuePair<uint, GoalObject> item in _completedGoalDict)
        {
            if (item.Value.IsMainLine)
            {
                goalDetailList.Add(item.Value);
            }
        }
        goalDetailList.AddRange(_goalList);
        return goalDetailList;
    }
    public void DoGoal(uint id)
    {
        GoalObject goalObject = GetGoalObject(id);

        if (goalObject.IsNotNull())
        {
            if (IsCanDoGoal())
            {
                if (goalObject.IsLevelEnouth)
                {
                    Current = goalObject;
                    if (goalObject.DoGoal())
                        UConsole.Log(UConsoleDefine.Goal, Current.ToString(), Color.green);
                }
                else
                    UConsole.LogError(UConsoleDefine.Goal, "等级不足任务条件，current Level = {0}, id ={1}", Player.Instance.Property.Level.Value, id);
            }
            else
            {
                UIManagerUtility.ShowHint("当前场景无法寻路！");
            }
        }
        else
            UConsole.LogError(UConsoleDefine.Goal, "DoGoal 没找到这个任务，id =" + id);
    }
    public void LoadStory(string storyName)
    {
        if (storyName.IsNotNullOrEmpty())
        {
            StoryManager.GetInstance.LoadStory(storyName);
        }
    }
    public CellNPC GetNPC(ulong npcID)
    {
        return ViEntitySerialize.EntityNameger.GetEntity(npcID) as CellNPC;
    }
    public void CompleteGoal(uint id)
    {
        UConsole.Log(UConsoleDefine.Goal, "Client CompleteGoal,id={0}", id);
    }
    public bool IsCanDoGoal()
    {
        SpaceEnterMask mask = (SpaceEnterMask)GameSpaceRecordInstance.Instance.Property.Info.Value.Enter.Mask.Value;
        switch (mask)
        {
            case SpaceEnterMask.MATCH_PVP:
            case SpaceEnterMask.MATCH_GVG:
            case SpaceEnterMask.ROOM_GUILD:
                return false;
            default:
                return true;
        }
    }
    public List<IGoalMapInterface> GetGoalMapList(GoalStateType type)
    {
        List<IGoalMapInterface> list = new List<IGoalMapInterface>();
        for (int i = 0; i < GoalList.Count; i++)
        {
            if (GoalList[i].StateType == type)
            {
                list.Add(GoalList[i]);
            }
        }
        return list;
    }

    //net
    public void MoveTo(ViVector3 pos)
    {
        HeroController.Instance.MoveTo(pos, 2, AutoPathType.Goal);
    }
    public void GotoSpace(uint Space)
    {
        PlayerServerInvoker.GotoBigSpace(Player.Instance, Space);
    }
    public void TalkToNPCEnd(uint storyId)
    {
        CellHeroServerInvoker.TalkToNPC(CellHero.LocalHero, storyId);
    }
    public void OpenFunctionUIEnd(uint gameFuncID)
    {
        CellHeroServerInvoker.OpenFunctionUI(CellHero.LocalHero, gameFuncID);
    }
    public void ClickReward(uint id)
    {
        PlayerServerInvoker.ClickReward(Player.Instance, id);
    }
    public void ReceiveGoal(uint id)
    {
        PlayerServerInvoker.AddGoal(Player.Instance, id);
    }
    public void TurnInGoal(uint id)
    {
        PlayerServerInvoker.TurnInGoal(Player.Instance, id);
    }
    public void GoalJumpSpace(uint id)
    {
        PlayerServerInvoker.GoalJumpSpace(Player.Instance, id);
    }
    public void CollectSpaceObject()
    {
        SpaceObject spaceObject = HeroController.Instance.GetNearestCollectSpaceObject();
        if (spaceObject != null)
        {
            CellPlayerServerInvoker.REQ_InteractWithObject(CellPlayer.Instance, spaceObject);
        }
    }
    public void AttackMonster()
    {
        //TODO zlj 没有自动战斗
        return;
        ViVector3 dir = ViVector3.ZERO;
        ViGeographicObject.GetRotate(CellHero.LocalHero.Yaw, ref dir.x, ref dir.y);
        float yaw, distance;
        if (HeroController.Instance.AutoFocus(36,GameStateConditionDataInstance.Attackedable, AutoFocusType.MINDISTANCE,0,300, 1.0f, ref dir, out yaw, out distance) != null)
        {
            CellPlayerServerInvoker.REQ_SetHeroYaw(CellPlayer.Instance, yaw);
        }
        CellPlayerServerInvoker.REQ_ShotStart(CellPlayer.Instance);
    }
    public void LoadGoalNPC(uint goalID)
    {
        PlayerServerInvoker.EnterSpaceObjLoadNPC(Player.Instance, goalID);
    }
}