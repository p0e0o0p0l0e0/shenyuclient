using UnityEngine;


public class GoalFactory
{
    public static GoalObject Generate(ReceiveDataGoalProperty goalProperty)
    {
        if (goalProperty == null || goalProperty.Info.Value == null)
            return null;

        GoalObject goalObj = null;
        switch ((GoalType)goalProperty.Info.Value.Content.Type.Value)
        {
            case GoalType.HUNTER_KILL_NPC:
                goalObj = new GoalObjectKillNpc();
                break;
            case GoalType.HUNTER_TALK_TO_NPC:
                goalObj = new GoalObjectTalkToNpc();
                break;
            case GoalType.HUNTER_COLLECT_SPACE_OBJECT:
                goalObj = new GoalObjectCollectSpaceObject();
                break;
            case GoalType.HUNTER_OPEN_FUNCTION_UI:
                goalObj = new GoalObjectOpenFunctionUI();
                break;
            case GoalType.HUNTER_JUMP_SPACE:
                goalObj = new GoalObjectJumpSpace();
                break;
        }
        if (goalObj == null)
            goalObj = new GoalObject();

        goalObj.Init(goalProperty);
        return goalObj;
    }
    public static GoalObject Generate(uint id)
    {
        GoalStruct goalConfig = ViSealedDB<GoalStruct>.Data(id);
        if (goalConfig == null)
            return null;

        GoalObject goalObj = null;
        switch ((GoalType)goalConfig.Content.Type.Value)
        {
            case GoalType.HUNTER_KILL_NPC:
                goalObj = new GoalObjectKillNpc();
                break;
            case GoalType.HUNTER_TALK_TO_NPC:
                goalObj = new GoalObjectTalkToNpc();
                break;
            case GoalType.HUNTER_COLLECT_SPACE_OBJECT:
                goalObj = new GoalObjectCollectSpaceObject();
                break;
            case GoalType.HUNTER_OPEN_FUNCTION_UI:
                goalObj = new GoalObjectOpenFunctionUI();
                break;
            case GoalType.HUNTER_JUMP_SPACE:
                goalObj = new GoalObjectJumpSpace();
                break;
        }
        if (goalObj == null)
            goalObj = new GoalObject();

        goalObj.Init(goalConfig);
        return goalObj;
    }
}
