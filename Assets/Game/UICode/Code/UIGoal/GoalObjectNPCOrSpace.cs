using UnityEngine;
using System.Collections;

public abstract class GoalObjectNPCOrSpace : GoalObject
{
    protected SpaceObjectBirthPositionStruct SpaceObjInfo { get; set; }
    protected NPCBirthPositionStruct NpcInfo { get; private set; }

    protected override void InitData(GoalStruct goalConfig)
    {
        base.InitData(goalConfig);

        if(GoalInfo.NPCPoint.PData.IsNotNull())
        {
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
        else if (GoalInfo.SpaceObjPoint.PData.IsNotNull())
        {
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
        else
        {
            UConsole.LogError(UConsoleDefine.Goal, "既找不到spaceobjectbirth，又找不到npcbirth.id ={0},name ={1}", ID, Name);
        }
    }
    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("ID ={0},\tCategory = {1},\t Pos ={2},\t ", EntityID,EntityCategory, EntityPosition);
    }
}

public class GoalObjectTalkToNpc : GoalObjectNPCOrSpace
{
    public override void Init(ReceiveDataGoalProperty goalProperty)
    {
        base.Init(goalProperty);

        if (NpcInfo.IsNotNull())
        {
            EventDispatcher.AddEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);

            SetGoalFlag(true, GetTargetNPC(NpcInfo.ID));
        }
    }
    protected override void Do()
    {
        if (HasStory && IsStoryEnd)
            GoalManager.GetInstance.TalkToNPCEnd(StoryID);
        else
        {
            //DoStory
        }
    }
    public override void End()
    {
        if (NpcInfo.IsNotNull())
        {
            EventDispatcher.RemoveEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);

            SetGoalFlag(false, GetTargetNPC(NpcInfo.ID));
        }

        base.End();
    }
}

public class GoalObjectJumpSpace : GoalObjectNPCOrSpace
{
    public override void Init(ReceiveDataGoalProperty goalProperty)
    {
        base.Init(goalProperty);

        if (NpcInfo.IsNotNull())
        {
            EventDispatcher.AddEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);

            SetGoalFlag(true, GetTargetNPC(NpcInfo.ID));
        }
    }

    protected override void InitData(GoalStruct goalConfig)
    {
        base.InitData(goalConfig);

        if (GoalInfo.JumpSpaceId.PData.IsNull())
            UConsole.Log(UConsoleDefine.Goal, "JumpSpaceId 数据为空.id ={0},name ={1}", ID, Name);
        else
            _jumpSpaceID = GoalInfo.JumpSpaceId.PData.ID;
    }

    protected override void Do()
    {
        if (CanDo)
        {
            GoalManager.GetInstance.GoalJumpSpace(ID);
        }
    }
    public override void End()
    {
        if (NpcInfo.IsNotNull())
        {
            EventDispatcher.RemoveEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);

            SetGoalFlag(false, GetTargetNPC(NpcInfo.ID));
        }

        base.End();
    }

    public override string ToString()
    {
        string content = base.ToString();

        return content + string.Format("jumpSpaceID ={0}\t ", _jumpSpaceID);
    }

    int _jumpSpaceID;
}