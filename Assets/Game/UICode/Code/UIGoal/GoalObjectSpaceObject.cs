using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region         GoalObjectSpaceObject
public abstract class GoalObjectSpaceObject : GoalObject
{
    protected SpaceObjectBirthPositionStruct SpaceObjInfo { get; set; }

    protected override void InitData(GoalStruct goalConfig)
    {
        base.InitData(goalConfig);

        if (GoalInfo.SpaceObjPoint.PData.IsNull())
        {
            UConsole.Log(UConsoleDefine.Goal, "SpaceObjPoint 数据为空.id ={0},name ={1}", ID, Name);
            return;
        }

        SpaceObjInfo = GoalInfo.SpaceObjPoint;
        EntityBirthID = SpaceObjInfo.ID;
        EntityPosition = SpaceObjInfo.Position;

        if (SpaceObjInfo.Object.PData.IsNull())
        {
            UConsole.Log(UConsoleDefine.Goal, "SpaceObjPoint.SpaceObject 数据为空.id ={0},name ={1}", ID, Name);
            return;
        }
        EntityID = (uint)SpaceObjInfo.Object.PData.ID;
        EntityCategory = SpaceObjInfo.Object.PData.entityCategory;
    }
    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("SpaceID ={0},\tCategory = {1},\t Pos ={2},\t ", EntityID, EntityCategory, EntityPosition);
    }
}

public class GoalObjectCollectSpaceObject : GoalObjectSpaceObject, IGoalCountInterface
{
    public int MaybeTargetValue { get; set; }
    public int CurrentCount { get; set; }

    public override void Init(ReceiveDataGoalProperty goalProperty)
    {
        base.Init(goalProperty);

        EventDispatcher.AddEventListener<int>(Events.SceneCommonEvent.CollectSpaceObjectEnd, _OnCollectSpaceObjectEnd);
    }

    protected override void InitData(GoalStruct goalConfig)
    {
        base.InitData(goalConfig);

        MaybeTargetValue = GoalInfo.Content.MaybeTargetValue;

        if (Property == null)
        {
            CurrentCount = GoalInfo.Content.Count;
        }
        else
        {
            if (Property.Value > CurrentCount)
            {
                CurrentCount = Property.Value;

                if (ActionUpdateCount != null)
                    ActionUpdateCount(CurrentCount, Count);
            }
        }
    }

    protected override void Do()
    {
        if (CanDo)
        {
            GoalManager.GetInstance.CollectSpaceObject();
        }
    }
    private void _OnCollectSpaceObjectEnd(int id)
    {

    }
    public override void End()
    {
        CurrentCount = Count;
        if (ActionUpdateCount != null)
            ActionUpdateCount(Count, Count);

        base.End();
        EventDispatcher.RemoveEventListener<int>(Events.SceneCommonEvent.CollectSpaceObjectEnd, _OnCollectSpaceObjectEnd);
    }
    public bool IsEnouth()
    {
        return CurrentCount >= Count;
    }
    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("MaybeTargetValue ={0},\t Count ={1},\t CurrentCount = {2}\t ", MaybeTargetValue, Count, CurrentCount);
    }
    
}

#endregion
