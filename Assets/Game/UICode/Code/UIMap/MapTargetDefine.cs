using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TargetEnum
{
    TARGET_NPC = EntityCategory.NORMAL_NPC,
    TARGET_GATE = EntityCategory.TELEPORT_OBJECT,
    TARGET_BOSS = EntityCategory.BOSS_VILLAIN,
    TARGET_MONSTER = EntityCategory.NORMAL_VILLAIN,    
    TARGET_OUTDOOR_GATHER = EntityCategory.COLLECT_OBJECT,
    TARGET_PLOT_NPC = EntityCategory.PLOT_NPC,
    TARGET_TASK1 = 100,
    TARGET_TASK2,
    TARGET_TASK3,
    TARGET_CAN_GET_TASK,
    TARGET_CAN_SUBMIT_TASK,
    TARGET_GOING_TASK,
    TARGET_TEAM_PLAYER,
    TARGET_LOCAL_PLAYER,
}
public class MapTargetDefine
{
    public static Dictionary<TargetEnum, ViConstValue<string>> targetIconData = new Dictionary<TargetEnum, ViConstValue<string>>
    {
        { TargetEnum.TARGET_NPC,  new ViConstValue<string>(TargetEnum.TARGET_NPC.ToString(), "map_target1")},
        { TargetEnum.TARGET_TASK1,  new ViConstValue<string>(TargetEnum.TARGET_TASK1.ToString(), "map_target2")},
        { TargetEnum.TARGET_TASK2,  new ViConstValue<string>(TargetEnum.TARGET_TASK2.ToString(), "map_target3")},
        { TargetEnum.TARGET_TASK3,  new ViConstValue<string>(TargetEnum.TARGET_TASK3.ToString(), "map_target4")},
        { TargetEnum.TARGET_GATE,  new ViConstValue<string>(TargetEnum.TARGET_GATE.ToString(), "map_target5")},
        { TargetEnum.TARGET_BOSS,  new ViConstValue<string>(TargetEnum.TARGET_BOSS.ToString(), "map_target6")},
        { TargetEnum.TARGET_CAN_GET_TASK,  new ViConstValue<string>(TargetEnum.TARGET_CAN_GET_TASK.ToString(), "map_target7")},
        { TargetEnum.TARGET_CAN_SUBMIT_TASK,  new ViConstValue<string>(TargetEnum.TARGET_CAN_SUBMIT_TASK.ToString(), "map_target8")},
        { TargetEnum.TARGET_MONSTER,  new ViConstValue<string>(TargetEnum.TARGET_MONSTER.ToString(), "map_target9")},
        { TargetEnum.TARGET_TEAM_PLAYER,  new ViConstValue<string>(TargetEnum.TARGET_TEAM_PLAYER.ToString(), "map_target10")},
        { TargetEnum.TARGET_OUTDOOR_GATHER,  new ViConstValue<string>(TargetEnum.TARGET_OUTDOOR_GATHER.ToString(), "map_target11")},
        { TargetEnum.TARGET_LOCAL_PLAYER,  new ViConstValue<string>(TargetEnum.TARGET_LOCAL_PLAYER.ToString(), "pic_oneself")},
        { TargetEnum.TARGET_PLOT_NPC,  new ViConstValue<string>(TargetEnum.TARGET_PLOT_NPC.ToString(), "map_target1")},
    };
}
