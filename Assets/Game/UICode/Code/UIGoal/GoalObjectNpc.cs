using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region GoalObjectNpc
public abstract class GoalObjectNpc : GoalObject
{
    protected NPCBirthPositionStruct NpcInfo { get; private set; }

    protected override void InitData(GoalStruct goalConfig)
    {
        base.InitData(goalConfig);
        
        if (GoalInfo.NPCPoint.PData.IsNull())
        {
            UConsole.LogError(UConsoleDefine.Goal, "NPCBirthPosition数据为空.id ={0},name ={1}", ID, Name);
            return;
        }

        NpcInfo = GoalInfo.NPCPoint.PData;
        EntityBirthID = NpcInfo.ID;
        EntityPosition = NpcInfo.Position;

        if (NpcInfo.NPC.Data.IsNull())
        {
            UConsole.LogError(UConsoleDefine.Goal, "NPC数据为空.id ={0},name ={1}", ID, Name);
            return;
        }
        else
            EntityID = (uint)NpcInfo.NPC.Data.ID;

        if (NpcInfo.NPC.Data.DataEx.Data.IsNull())
        {
            UConsole.LogError(UConsoleDefine.Goal, "NPCEX数据为空.id ={0},name ={1}", ID, Name);
            return;
        }
        else
            EntityCategory = NpcInfo.NPC.Data.DataEx.Data.entityCategory;
    }
    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("NPCID ={0},\tCategory = {1},\t Pos ={2},\t ", EntityID, EntityCategory, EntityPosition);
    }

}

public class GoalObjectKillNpc : GoalObjectNpc, IGoalCountInterface
{
    public int MaybeTargetValue { get; set; }
    public int CurrentCount { get; set; }

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
            GoalManager.GetInstance.AttackMonster();
        }
    }
    public bool IsEnouth()
    {
        return CurrentCount >= Count;
    }
    public override void End()
    {
        CurrentCount = Count;
        if (ActionUpdateCount != null)
            ActionUpdateCount(Count, Count);

        base.End();
    }
    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("MaybeTargetValue ={0},\t Count ={1},\t CurrentCount = {2}\t ", MaybeTargetValue, Count, CurrentCount);
    }
}


public class GoalObjectOpenFunctionUI : GoalObjectNpc
{

    public override void Init(ReceiveDataGoalProperty goalProperty)
    {
        base.Init(goalProperty);

        EventDispatcher.AddEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);

        SetGoalFlag(true, GetTargetNPC(NpcInfo.ID));
    }

    protected override void InitData(GoalStruct goalConfig)
    {
        base.InitData(goalConfig);

        if (GoalInfo.ReqFunc.PData.IsNull())
        {
            UConsole.LogError(UConsoleDefine.Goal, "ReqFunc 数据为空.id ={0},name ={1}", ID, Name);
            return;
        }

        _funcUIName = GoalInfo.ReqFunc.PData.FuncUI.UIName;
    }

    protected override void Do()
    {
        if (CanDo)
        {
            //openUI   maybe add send some value
            if (_funcUIName.IsNullOrEmpty())
            {
                UConsole.LogError("_funcUIName==null");
                return;
            }
            UIManager.Instance.Show(_funcUIName, () =>
            {
                GoalManager.GetInstance.OpenFunctionUIEnd((uint)GoalInfo.ReqFunc.Value);
            });
        }
    }
    public override void End()
    {
        EventDispatcher.RemoveEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);

        SetGoalFlag(false, GetTargetNPC(NpcInfo.ID));

        base.End();
    }
    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("funcUIName ={0}\t ", _funcUIName);
    }

    string _funcUIName;
}
#endregion
