using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 剧情触发条件编辑器
/// zlj
/// </summary>
[System.Serializable]
public class StoryConditionData: MonoBehaviour
{
    public string[] conStr = { "走到某区域（X,Y,Z）(可附加条件)", "某波敌人死亡", "进入游戏","游戏结算后", "某波角色加载后", "到达第几波怪的CENTER点", "血量低于一定值", "Loading结束开始战斗", "战斗胜利", "播放技能","自动立即触发", "其他剧情完成触发此条件", "任务完成触发剧情","测试用" };
    /// <summary>
    ///  触发条件的类型
    /// </summary>
    public enum CONDITION_TYPE
    {
        /// <summary>
        ///  区域触发类型
        /// </summary>
        RECT,
        /// <summary>
        /// 某波敌人死亡
        /// </summary>
        GROUPDEAD,
        /// <summary>
        /// 进入游戏后
        /// </summary>
        ENTER,
        /// <summary>
        /// 游戏结算后,
        /// </summary>
        RESUILTEND,
        /// <summary>
        /// 某波角色加载后
        /// </summary>
        LOADEDWAVEROLES,
        /// <summary>
        /// 到达第几波怪的CENTER点
        /// </summary>
        ARRIVEWAVECENTER,
        /// <summary>
        /// 血量低于一定值
        /// </summary>
        BLOODMINLIMIT,
        /// <summary>
        /// Loading结束后开始
        /// </summary>
        BEGINNING,
        /// <summary>
        /// 战斗胜利
        /// </summary>
        BATTLEWIN,
        /// <summary>
        /// 播放技能
        /// </summary>
        PLAYSKILL,
        /// <summary>
        /// 自动触发
        /// </summary>
        AUTOPLAY,
        /// <summary>
        /// 其他剧情完成触发此条件
        /// </summary>
        TRIGGERCONDITION,
        /// <summary>
        /// 任务完成触发
        /// </summary>
        GOALCOMPLETE,
        /// <summary>
        /// 测试用
        /// </summary>
        TEST,
    }
    /// <summary>
    /// 触发的类型
    /// </summary>
    public CONDITION_TYPE type;
    /// <summary>
    /// 角色类型数据
    /// </summary>
    public StoryRoleData roleData;
    /// <summary>
    /// 波次角色数据
    /// </summary>
    public StoryWaveData waveData;

    /// <summary>
    /// 血量低于百分之多少
    /// </summary>
    public float bloodLimitPercent;

    /// <summary>
    /// 技能ID
    /// </summary>
    public int skillID;
    /// <summary>
    /// 剧情条件ID
    /// </summary>
    public int storyConditionID;
    /// <summary>
    /// 触发区域判断条件 -1不需要其他条件 1需要其他触发条件
    /// </summary>
    public int rectConditionID = -1;

    /// <summary>
    /// 是否广播
    /// </summary>
    public bool isBroadCast = false;
    /// <summary>
    /// 广播角色数据
    /// </summary>
    public List<StoryRoleData> roleDataList = new List<StoryRoleData>();
    /// <summary>
    /// 此条件触发是否通知服务器添加npc
    /// </summary>
    public bool isNoticeServerLoadNPC = false;
    /// <summary>
    /// 此条件触发是否通知服务器进入剧情模式
    /// </summary>
    public bool isNoticeServerEnterStoryModel = false;
    /// <summary>
    /// 任务id
    /// </summary>
    public int goalID = 0;
    /// <summary>
    /// 特殊剧情模式下播放剧情
    /// </summary>
    public bool playInStoryModel = false;
    /// <summary>
    /// 结束强制删除剧情
    /// </summary>
    public bool isEndForceDestory = false;
}



