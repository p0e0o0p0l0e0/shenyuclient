using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
/// <summary>
/// 剧情功能数据自定义编辑器
/// zlj
/// </summary>
public class StoryFunctionData : MonoBehaviour
{
    /// <summary>
    /// 并行index
    /// </summary>
    public int index;
    /// <summary>
    /// 后续步骤
    /// </summary>
    public StoryFunction reqStoryFunction;
    #region 功能类型
    public enum FUCTION_TYPE
    {
        /// <summary>
        /// 插图文本的方式
        /// </summary>
        TEXTURE,
        /// <summary>
        /// 冒泡
        /// </summary>
        BUBBLING,
        /// <summary>
        /// 视频
        /// </summary>
        MOVIE,
        /// <summary>
        /// 位移
        /// </summary>
        DISPLACEMENT,
        /// <summary>
        /// 游戏速度
        /// </summary>
        GAMESPEED,
        /// <summary>
        /// 背景音
        /// </summary>
        BACKMUSIC,
        /// <summary>
        /// 相机
        /// </summary>
        CAMERA,
        /// <summary>
        /// 动作
        /// </summary>
        ANIMATION,
        /// <summary>
        /// 眨眼
        /// </summary>
        BLINKOFANEYE,
        /// <summary>
        /// 剧情动画
        /// </summary>
        CINEMADIRECTOR,
        /// <summary>
        /// 黑幕
        /// </summary>
        BLACKBACKGROUND,
    }
    public string[] typeMenu = { "插图", "冒泡", "视频","位移","游戏速度","背景音乐","相机","动作", "眨眼","剧情动画","黑幕"};

    public FUCTION_TYPE type;

    /// <summary>
    /// 开启功能前延迟多久
    /// </summary>
    public float startWaitTime;
    /// <summary>
    /// 插图功能数据
    /// </summary>
    public StoryFunctionTextureTextData textData;
    /// <summary>
    /// 冒泡数据
    /// </summary>
    public StoryFunctionBubblingData bubblingData;
    /// <summary>
    /// 视频数据
    /// </summary>
    public StoryFunctionMovieData movieData;
    /// <summary>
    /// 分镜数据
    /// </summary>
    public StoryFunctionStoryboardData storyboardData;
    /// <summary>
    /// 位移数据
    /// </summary>
    public StoryFunctionDisplacementData displacementData;
    /// <summary>
    /// 游戏速度数据
    /// </summary>
    public StoryFunctionGameSpeedData gameSpeedData;
    /// <summary>
    /// 背景音数据
    /// </summary>
    public StoryFunctionBackMusicData backMusicData;
    /// <summary>
    /// 相机数据
    /// </summary>
    public StoryFunctionCameraData cameraData;
    /// <summary>
    /// 动作数据
    /// </summary>
    public StoryFunctionAimationData animationData;
    /// <summary>
    /// 眨眼数据
    /// </summary>
    public StoryFunctionCameraBlinkOfAnEyeData blinkOfAnEyeData;
    /// <summary>
    /// 黑幕数据
    /// </summary>
    public StoryFunctionBlackBackgroundData blackBackgroundData;
    /// <summary>
    /// 剧情动画数据
    /// </summary>
    public StoryFunctionCinemaDirectorData cinemaDirectorData;
    #endregion
    #region 下一步类型
    public enum NEXT_TYPE
    {
        /// <summary>
        /// 延迟时间方式
        /// </summary>
        TIME,
        /// <summary>
        /// 点击方式
        /// </summary>
        CLICK,
        /// <summary>
        /// 结束剧情
        /// </summary>
        ENDSTORY,
        /// <summary>
        /// 同步方式
        /// </summary>
        SYNS,
    }
    public string[] nextTypeNames = { "延迟", "点击"};
    /// <summary>
    /// 下一项的切换方式
    /// </summary>
    public NEXT_TYPE nextType;
    /// <summary>
    /// 下一步切换时间
    /// </summary>
    public float nextTime = 1;
    #endregion

}
#region 插图功能数据
/// <summary>
/// 插图功能数据
/// </summary>
[System.Serializable]
public class StoryFunctionTextureTextData
{
    #region 头像数据
    ///头像的位置
    public enum HEAD_ACTOR
    {
        /// <summary>
        /// 左边
        /// </summary>
        LEFT,
        /// <summary>
        /// 右边
        /// </summary>
        RIGHT
    }
    /// <summary>
    /// 头像的位置
    /// </summary>
    public HEAD_ACTOR headActor;
    
    #endregion

    /// <summary>
    /// 对话框内数据
    /// </summary>
    public StoryDialogData dialogData;

    /// <summary>
    /// 对话框样式图片路径
    /// </summary>
    public string dialogStylePath;

    ///// <summary>
    ///// 背景图图片数据
    ///// </summary>
    public StoryTextureData backgroundTexData;
    /// <summary>
    /// 字幕内容
    /// </summary>
    public StoryTextData subtitleContent;
    /// <summary>
    /// 标题内容
    /// </summary>
    public StoryTextData titleContent;
    /// <summary>
    /// 出现数据
    /// </summary>
    public StoryAppearanceData appearanceData;
}
#endregion
#region 冒泡功能数据
/// <summary>
/// 冒泡功能数据
/// </summary>
[System.Serializable]
public class StoryFunctionBubblingData
{
    /// <summary>
    /// 冒泡图片路径
    /// </summary>
    public string bubblingTexPath;

    /// <summary>
    /// 播放冒泡等待多久开启
    /// </summary>
    public float dialogWaitTime;
    /// <summary>
    /// 通用角色类型数据
    /// </summary>
    public StoryRoleData roleData;
    /// <summary>
    /// 通用对话数据(主角（男），英雄，敌人遇到男主角)
    /// </summary>
    public StorySoundData soundData;
    /// <summary>
    /// 通用对话数据(女主角备用数据和敌人遇到女主角备用数据)
    /// </summary>
    public StorySoundData soundData1;

    /// <summary>
    /// 是否显示列表详情
    /// </summary>
    public bool showDetail = true;
    /// <summary>
    /// 独立英雄ID列表
    /// </summary>
    public List<int> heroList = new List<int>();
    /// <summary>
    /// 独立英雄对话列表
    /// </summary>
    public List<StorySoundData> soundDataList = new List<StorySoundData>();
    
    /// <summary>
    /// 播放结束是否隐藏此人
    /// </summary>
    public bool isHideCharacter;
}
#endregion
#region 视频功能数据
[System.Serializable]
public class StoryFunctionMovieData
{
    /// <summary>
    /// 视频路径
    /// </summary>
    public string moviePath;
    /// <summary>
    /// 是否可以跳过
    /// </summary>
    public bool isCanJump = true;
}
#endregion
#region 分镜功能数据
[System.Serializable]
public class StoryFunctionStoryboardData
{
    #region 分镜类型
    ///分镜下的功能数据
    public enum MOVIE_TYPE
    {
        /// <summary>
        /// 选择边缘框
        /// </summary>
        EdgeFrame,
        /// <summary>
        /// 选择对话相关
        /// </summary>
        Dialog,
        /// <summary>
        /// 镜头相关
        /// </summary>
        Camera,
        /// <summary>
        /// 人物预设
        /// </summary>
        RolePreset,
        /// <summary>
        /// 人物行为相关
        /// </summary>
        RoleAction,
    }

    public string[] movieTypeNames = { "选择边缘框", "选择对话相关", "镜头相关", "人物预设", "人物行为相关" };
    /// <summary>
    /// 当前分镜数据类型
    /// </summary>
    public MOVIE_TYPE movieType;
    #endregion

    public enum CameraControlType
    {
        MoveCamera,
        RotateCamera,
        CameraPath,
        ChangeCamera,
    }
    public enum RoleActionType
    {
        PlayAnimation,
        Move,
    }
    /// <summary>
    /// 相机类型
    /// </summary>
    public CameraControlType cameraControlType;
    /// <summary>
    /// 角色行为类型
    /// </summary>
    public RoleActionType roleActionType;
    ///// <summary>
    ///// 边缘框图片数据
    ///// </summary>
    public StoryTextureData edgeFramTexData;
    /// <summary>
    /// 冒泡图片
    /// </summary>
    public string bubblingTexPath;
    /// <summary>
    /// 冒泡时长
    /// </summary>
    public float bubblingExistTime;
    /// <summary>
    /// 人物要播放的动作的动画名
    /// </summary>
    public string animatonName;
    /// <summary>
    /// 行为频率
    /// </summary>
    public float actionSpeed;
    /// <summary>
    /// 是否循环播放
    /// </summary>
    public bool isLoop;
    /// <summary>
    /// 移动的时间
    /// </summary>
    public float costTime;
    /// <summary>
    /// 行走速度
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 角色类型数据
    /// </summary>
    public StoryRoleData roleData;
    /// <summary>
    /// 声音数据
    /// </summary>
    public StorySoundData soundData;
}
#endregion
#region 位移功能数据
[System.Serializable]
public class StoryFunctionDisplacementData
{
    /// <summary>
    /// 通用角色类型数据
    /// </summary>
    public StoryRoleData roleData;
    /// <summary>
    /// 移动速度
    /// </summary>
    public float moveSpeed = 5;
    /// <summary>
    /// 要到达的位置
    /// </summary>
    public Vector3 position;
    /// <summary>
    /// 朝向
    /// </summary>
    public Vector3 angle;
}
#endregion
#region 游戏速度功能数据
[System.Serializable]
public class StoryFunctionGameSpeedData
{
    /// <summary>
    /// 游戏速度
    /// </summary>
    public float gameSpeed;
}
#endregion
#region 相机数据
[System.Serializable]
public class StoryFunctionCameraData
{
    /// <summary>
    /// 镜头等待多久开启
    /// </summary>
    public float cameraWaitTime;
    /// <summary>
    /// 是否播分镜过程中隐藏主角
    /// </summary>
    public bool isHidePlayer = false;
    /// <summary>
    /// 冒泡显示高度偏移量
    /// </summary>
    public float highOffset = 2.3f;
    /// <summary>
    /// 播放相机动画数据
    /// </summary>
    public PlayCameraAnimatorData cameraAnimatorData;
    /// <summary>
    /// 相机晃动数据
    /// </summary>
    public List<CameraShakeInfo> cameraShakeInfos = new List<CameraShakeInfo>();
}
#endregion
#region 眨眼数据
[System.Serializable]
public class StoryFunctionCameraBlinkOfAnEyeData
{
    /// <summary>
    /// 眨眼数据
    /// </summary>
    public CameraBlinkOfAnEyeInfo cameraBlinkOfAnEyeInfo;
}
#endregion
#region 黑幕数据
[System.Serializable]
public class StoryFunctionBlackBackgroundData
{
    /// <summary>
    /// 黑幕数据
    /// </summary>
    public BlackBackgroundData blackBackgroundData = new BlackBackgroundData();
}
#endregion
#region 剧情动画
[System.Serializable]
public class StoryFunctionCinemaDirectorData
{
    /// <summary>
    /// 剧情动画文件路径
    /// </summary>
    public StoryFileData fileData;
}
#endregion
#region 人物动作数据
[System.Serializable]
public class StoryFunctionAimationData
{
    /// <summary>
    /// 通用角色类型数据
    /// </summary>
    public StoryRoleData roleData;
    /// <summary>
    /// 播放动作等待多久开启
    /// </summary>
    public float actionWaitTime;
    /// <summary>
    /// 人物行为数据(主角（男），英雄，敌人)
    /// </summary>
    public StoryRoleActionData roleActionData;
}
#endregion
#region 背景音乐功能数据 
[System.Serializable]
public class StoryFunctionBackMusicData
{
    /// <summary>
    /// 声音ID
    /// </summary>
    public int soundID;
    /// <summary>
    /// 背景音量(0~1)
    /// </summary>
    public float volume = 0.8f;
}
#endregion
#region 独立数据
/// <summary>
/// 角色数据
/// </summary>
[System.Serializable]
public class StoryRoleData
{
    /// <summary>
    ///角色的类型
    /// </summary>
    public enum ROLETYPE
    {
        /// <summary>
        /// 主角
        /// </summary>
        LEAD,
        /// <summary>
        /// 英雄
        /// </summary>
        HERO,
        /// <summary>
        /// 敌人(包含敌人，剧情NPC，波怪)
        /// </summary>
        ENEMY,
        /// <summary>
        ///援军
        /// </summary>
        SceneNPC,
    }
    public string[] roleTypeNames = { "主角", "英雄", "地编怪物" ,"援军"};
    /// <summary>
    /// 类型
    /// </summary>
    public ROLETYPE controlType;
    /// <summary>
    /// npc monster 出生点信息
    /// </summary>
    public int npcBirthPositionID;
    /// <summary>
    /// npc monster 出生点信息,index
    /// </summary>
    public int npcBirthPositionIndex = 1;
    /// <summary>
    /// 角色ID（英雄，场景NCP）
    /// </summary>
    public int roleId;
    /// <summary>
    /// 地编文件路径
    /// </summary>
    public string battleGroupPrefabPath = "";
    /// <summary>
    /// 地编文件
    /// </summary>
    public GameObject battleGroupPrefab;
    /// <summary>
    /// 地编文件名字
    /// </summary>
    public string battleGroupPrefabName;
    /// <summary>
    /// 说话者为敌人时
    /// 此项为敌人的波次数
    /// </summary>
    public int enenmyCellIndex;
    /// <summary>
    /// 当说话者为敌人时，敌人的位置索引
    /// </summary>
    public int enemyPosition;
    /// <summary>
    /// 是否显示所有详情
    /// </summary>
    public bool isShowDetail = true;

    /// <summary>
    /// 是否是本地角色
    /// </summary>
    public bool isLocal = false;
    /// <summary>
    /// 结束是否删除
    /// </summary>
    public bool isDestory = true;
    /// <summary>
    /// 位置
    /// </summary>
    public Vector3 position;
    /// <summary>
    /// 角度
    /// </summary>
    public Vector3 angle;
    /// <summary>
    /// 援军跟随距离
    /// </summary>
    //public int followDistance = 3;
}
/// <summary>
/// 角色数据
/// </summary>
[System.Serializable]
public class StoryWaveData
{
    /// <summary>
    /// 地编文件路径
    /// </summary>
    [Obsolete]
    public string battleGroupPrefabPath = "";
    /// <summary>
    /// 地编文件
    /// </summary>
    [Obsolete]
    public GameObject battleGroupPrefab;
    /// <summary>
    /// 地编文件名字
    /// </summary>
    [Obsolete]
    public string battleGroupPrefabName;

    /// <summary>
    /// 波次列表
    /// </summary>
    public List<int> waveBirthPosList = new List<int>();
    /// <summary>
    /// 人物地编位置信息
    /// </summary>
    public StoryRoleData roleData;
}
/// <summary>
/// 对话和语音数据
/// </summary>
[System.Serializable]
public class StorySoundData
{
    /// <summary>
    /// 播放语音等待多久开启
    /// </summary>
    public float soundWaitTime;
    /// <summary>
    /// 是否显示详情
    /// </summary>
    public bool showDetail = true;
    /// <summary>
    /// 对话的内容
    /// </summary>
    public string storyText;
    /// <summary>
    /// 对话的内容
    /// </summary>
    public List<string> storyTextArray = new List<string>();
    /// <summary>
    /// 延迟时间
    /// </summary>
    public List<float> waitTime = new List<float>();
    /// <summary>
    /// 声音ID
    /// </summary>
    public int soundID;
    /// <summary>
    /// 声音时长
    /// </summary>
    public float soundDuration;
}
/// <summary>
/// 文字数据
/// </summary>
[System.Serializable]
public class StoryTextData
{
    public enum ShowTextType
    {
        /// <summary>
        /// 直接显示
        /// </summary>
        Direct,
        /// <summary>
        /// 一个字一个字显示
        /// </summary>
        OneByOne,
    }
    public ShowTextType showTextType = ShowTextType.OneByOne;

    public string[] showTextTypeNames = { "直接显示", "一个一个显示" };

    public string showContext;

    public enum TextPositionType
    {
        Middle,
        Left,
        Right,
    }
    public TextPositionType textPositionType = TextPositionType.Middle;
    /// <summary>
    /// 一个一个显示文字的时间间隔
    /// </summary>
    public float interval = 0.2f;
}
/// <summary>
/// 图片数据
/// </summary>
[System.Serializable]
public class StoryTextureData
{
    public enum TextureStyleType
    {
        /// <summary>
        /// 直接显示
        /// </summary>
        Direct,
        /// <summary>
        /// 渐渐
        /// </summary>
        Slow,
    }
    public TextureStyleType showTextureType = TextureStyleType.Direct;
    public TextureStyleType hideTextureType = TextureStyleType.Direct;

    public string[] textTypeNames = { "直接", "渐渐" };

    /// <summary>
    /// 多久完全显示图片
    /// </summary>
    public float showDuration = 0f;
    /// <summary>
    /// 多久完全隐藏图片
    /// </summary>
    public float hideDuration = 0f;
    /// <summary>
    /// 图片路径
    /// </summary>
    public string texPath;
}
/// <summary>
/// 人物行为数据
/// </summary>
[System.Serializable]
public class StoryRoleActionData
{
    /// <summary>
    /// 技能动作id
    /// </summary>
    public int skillID;
    /// <summary>
    /// 技能动作id
    /// </summary>
    public int hitID;
    /// <summary>
    /// 动画名称
    /// </summary>
    public string animName;
    /// <summary>
    /// 普通人物行为文件
    /// </summary>
    public StoryFileData actionFileData;
    /// <summary>
    /// 主角人物行为文件 
    /// </summary>
    public List<StoryFileData> leaderActionFileData = new List<StoryFileData>();
    /// <summary>
    /// 主角职业列表
    /// </summary>
    public List<LeaderProfession> leaderProfessionList = new List<LeaderProfession>();

    /// <summary>
    /// 获取index
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public int GetStoryFileDataIndex(int profession)
    {
        if (profession < 1 || profession >= (int)LeaderProfession.Count)
            return -1;

        return leaderProfessionList.FindIndex(_list=>_list.Equals((LeaderProfession)(profession - 1)));
    }
    /// <summary>
    /// 获取对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public StoryFileData GetStoryFileData(int profession)
    {
        int index = GetStoryFileDataIndex(profession);
        if (index < 0)
            return new StoryFileData();
        return leaderActionFileData[index];
    }
    /// <summary>
    /// 获取人物类型对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public StoryFileData GetStoryFileData(StoryRoleData.ROLETYPE type,int profession = -1)
    {
        if (type == StoryRoleData.ROLETYPE.LEAD)
        {
            int index = GetStoryFileDataIndex(profession);
            if (index < 0)
                return new StoryFileData();
            return leaderActionFileData[index];
        }
        else
            return actionFileData;
    }
}
/// <summary>
/// 文件数据
/// </summary>
[System.Serializable]
public class StoryFileData
{
    //预制体
    public GameObject prefab;
    //预制体路径
    public string prefabPath;

    //获取预制体上脚本信息
    public T Get<T>() where T : Component
    {
        if (prefab == null)
        {
            //Console.Log("StoryFileData prefab == null,type :" + typeof(T));
            return null;
        }
        else
            return prefab.GetComponent<T>();
    }
}
/// <summary>
/// 出现的数据类型
/// </summary>
[System.Serializable]
public class StoryAppearanceData
{
    /// <summary>
    /// 出现方式
    /// </summary>
    public enum AppearanceMode
    {
        Normal,
        /// <summary>
        /// 划入划出
        /// </summary>
        WipeInOut,
    }
    public AppearanceMode appearanceMode;
    public string[] appearanceModeNames = { "正常", "侧边划入划出" };

    /// <summary>
    /// 多久完全显示
    /// </summary>
    public float moveInDuration = 1f;
    /// <summary>
    /// 多久完全隐藏
    /// </summary>
    public float moveOutDuration = 1f;
    /// <summary>
    /// 起始移动点
    /// </summary>
    public Vector3 startPoint = new Vector3(800, 80,0);
    /// <summary>
    /// 目标点
    /// </summary>
    public Vector3 endPoint = new Vector3(-60, 80,0);

    /// <summary>
    /// 是否改变相机范围
    /// </summary>
    public bool isChangeCameraView = false;
    /// <summary>
    /// 新的视角范围
    /// </summary>
    public float newView = 15;
    /// <summary>
    /// 改变相机范围时长 
    /// </summary>
    public float changFOVDuration = 0.5f;
}
/// <summary>
/// 对话框数据
/// </summary>
[System.Serializable]
public class StoryDialogData
{
    /// <summary>
    /// 人物类型限制
    /// </summary>
    public enum LimitRoleType
    {
        None,
        Leader,
        Monster,
    }
    public string[] limitRoleTypeNames = { "无限制类型", "主角", "怪物" };
    public LimitRoleType limitRoleType;

    public string roleName;
    //true 区分男女角色,false 使用默认男性数据
    public bool isDistinguish = false;
    /// <summary>
    /// 对话框文件数据,（无限制时和男主角时使用)
    /// </summary>
    public StoryModelProfessionData dialogFileData = new StoryModelProfessionData();
    //(女主角时使用)
    public StoryModelProfessionData dialogFileData1 = new StoryModelProfessionData();
    /// <summary>
    /// 对话内容和语音数据（无限制时和怪物碰到男主角使用）
    /// </summary>
    public StorySoundProfessionData soundData = new StorySoundProfessionData();
    //(女主角时和怪物遇到女主角时使用)
    public StorySoundProfessionData soundData1 = new StorySoundProfessionData();
}
/// <summary>
/// 对话框文件数据
/// </summary>
[System.Serializable]
public class StoryModelData
{
    /// <summary>
    /// 人物数据id或模型资源id
    /// </summary>
    public int roleID;
    /// <summary>
    /// 模型尺寸比例
    /// </summary>
    public float headModelSizePercent = 0.5f;
    /// <summary>
    /// 模型位置
    /// </summary>
    public Vector3 modelLocalPos = new Vector3(0, -1f, 0.5f);
    /// <summary>
    /// 
    /// </summary>
    public StoryRoleData roleData = new StoryRoleData();
}
/// <summary>
/// 不同职业对应的数据（由于泛型类型数据预制体保存失败，提另写方法）
/// </summary>
[System.Serializable]
public class StoryModelProfessionData
{
    /// <summary>
    /// 被职业区分的数据
    /// </summary>
    public StoryModelData t = new StoryModelData();
    /// <summary>
    /// 列表数据
    /// </summary>
    public List<StoryModelData> tList = new List<StoryModelData>();
    /// <summary>
    /// 主角职业列表
    /// </summary>
    public List<LeaderProfession> leaderProfessionList = new List<LeaderProfession>();
    /// <summary>
    /// 获取index
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public int GetStoryFileDataIndex(int profession)
    {
        if (profession < 1 || profession >= (int)LeaderProfession.Count)
            return -1;

        return leaderProfessionList.FindIndex(_list => _list.Equals((LeaderProfession)(profession - 1)));
    }
    /// <summary>
    /// 获取对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public StoryModelData GetStoryFileData(int profession)
    {
        int index = GetStoryFileDataIndex(profession);
        if (index < 0)
            return new StoryModelData();
        return tList[index];
    }
    /// <summary>
    /// 获取人物类型对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public StoryModelData GetStoryFileData(StoryRoleData.ROLETYPE type, int profession = -1)
    {
        if (type == StoryRoleData.ROLETYPE.LEAD)
        {
            int index = GetStoryFileDataIndex(profession);
            if (index < 0)
                return new StoryModelData();
            return tList[index];
        }
        else
            return t;
    }
}
/// <summary>
/// 不同职业对应的数据,（由于泛型类型数据预制体保存失败，提另写方法）
/// </summary>
[System.Serializable]
public class StorySoundProfessionData
{
    /// <summary>
    /// 被职业区分的数据
    /// </summary>
    public StorySoundData t = new StorySoundData();
    /// <summary>
    /// 列表数据
    /// </summary>
    public List<StorySoundData> tList = new List<StorySoundData>();
    /// <summary>
    /// 主角职业列表
    /// </summary>
    public List<LeaderProfession> leaderProfessionList = new List<LeaderProfession>();
    /// <summary>
    /// 获取index
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public int GetStoryFileDataIndex(int profession)
    {
        if (profession < 0 || profession >= (int)LeaderProfession.Count)
            return -1;

        return leaderProfessionList.FindIndex(_list => _list.Equals((LeaderProfession)(profession)));
    }
    /// <summary>
    /// 获取对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public StorySoundData GetStoryFileData(int profession)
    {
        int index = GetStoryFileDataIndex(profession);
        if (index < 0)
            return new StorySoundData();
        return tList[index];
    }
    /// <summary>
    /// 获取人物类型对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public StorySoundData GetStoryFileData(StoryRoleData.ROLETYPE type, int profession = -1)
    {
        if (type == StoryRoleData.ROLETYPE.LEAD)
        {
            int index = GetStoryFileDataIndex(profession);
            if (index < 0)
                return new StorySoundData();
            return tList[index];
        }
        else
            return t;
    }
}
/// <summary>
/// 不同职业对应的数据
/// </summary>
[System.Serializable]
public class StoryProfessionData<T> where T : new()
{    
    /// <summary>
     /// 被职业区分的数据
     /// </summary>
    public T t = new T();
    /// <summary>
    /// 列表数据
    /// </summary>
    public List<T> tList = new List<T>();
    /// <summary>
    /// 主角职业列表
    /// </summary>
    public List<LeaderProfession> leaderProfessionList = new List<LeaderProfession>();
    /// <summary>
    /// 获取index
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public int GetStoryFileDataIndex(int profession)
    {
        if (profession < 1 || profession >= (int)LeaderProfession.Count)
            return -1;

        return leaderProfessionList.FindIndex(_list => _list.Equals((LeaderProfession)(profession - 1)));
    }
    /// <summary>
    /// 获取对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public T GetStoryFileData(int profession)
    {
        int index = GetStoryFileDataIndex(profession);
        if (index < 0)
            return new T();
        return tList[index];
    }
    /// <summary>
    /// 获取人物类型对应的职业数据
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public T GetStoryFileData(StoryRoleData.ROLETYPE type, int profession = -1)
    {
        if (type == StoryRoleData.ROLETYPE.LEAD)
        {
            int index = GetStoryFileDataIndex(profession);
            if (index < 0)
                return new T();
            return tList[index];
        }
        else
            return t;
    }
}

/// <summary>
/// 相机眨眼数据
/// </summary>
[System.Serializable]
public class CameraBlinkOfAnEyeInfo
{
    /// <summary>
    /// 眨眼数据列表
    /// </summary>
    public List<CameraBlinkOfAnEyeData> blinkOfAnEyeList = new List<CameraBlinkOfAnEyeData>();
}
/// <summary>
/// 相机眨眼数据
/// </summary>
[System.Serializable]
public class CameraBlinkOfAnEyeData
{
    /// <summary>
    /// 眨眼间隔时间
    /// </summary>
    public float blinkDuration;
    /// <summary>
    /// 眨眼打开速度
    /// </summary>
    public float blinkOpenSpeed = 10;
    /// <summary>
    /// 眨眼关闭速度
    /// </summary>
    public float blinkCloseSpeed = 10;
    /// <summary>
    /// 眨眼开眨眼闭间隔
    /// </summary>
    public float blinkOpenCloseDuration;
}
[System.Serializable]
public class BlackBackgroundData
{
    /// <summary>
    /// 黑幕持续时间
    /// </summary>
    public float duration;
    /// <summary>
    /// 起始等待时间
    /// </summary>
    public float waitTime;
    /// <summary>
    /// 文字内容
    /// </summary>
    public StorySoundData dialogData;
}
/// <summary>
/// 播放相机动画数据
/// </summary>
[System.Serializable]
public class PlayCameraAnimatorData
{
    /// <summary>
    /// 镜头名称,路径
    /// </summary>
    public string cameraPath;
    /// <summary>
    /// 相机动画名称
    /// </summary>
    public string cameraAnimatorName;
    /// <summary>
    /// 相机旋转度
    /// </summary>
    public Vector3 cameraAngle;
    /// <summary>
    /// 相机视角
    /// </summary>
    public float fieldOfView = 45;
    /// <summary>
    /// 最近视角
    /// </summary>
    public float nearClippingPlanes = 0.1f;
    /// <summary>
    /// 最远视角
    /// </summary>
    public float FarClippingPlanes = 300f;
    /// <summary>
    /// 声音接收器位置
    /// </summary>
    public Vector3 audioListenerPos = Vector3.zero;
}
[System.Serializable]
public class CameraShakeInfo : IComparable
{
    public float ShakeTime = 0;//震屏时间点
    /// <summary>
    /// The maximum number of shakes to perform.
    /// </summary>
    public int numberOfShakes = 2;
    /// <summary>
    /// The amount to shake in each direction.
    /// </summary>
    public Vector3 shakeAmount = Vector3.one;
    /// <summary>
    /// The amount to rotate in each direction.
    /// </summary>
    public Vector3 rotationAmount = Vector3.one;
    /// <summary>
    /// The initial distance for the first shake.
    /// </summary>
    public float distance = 00.10f;
    /// <summary>
    /// The speed multiplier for the shake.
    /// </summary>
    public float speed = 50.00f;
    /// <summary>
    /// The decay speed (between 0 and 1). Higher values will stop shaking sooner.
    /// </summary>
    public float decay = 00.20f;
    #region 新加
    public int CameraShakID = 0;
    #endregion
    public int CompareTo(object obj)
    {
        int result;
        CameraShakeInfo _CameraShakeInfo = obj as CameraShakeInfo;
        if (this.ShakeTime > _CameraShakeInfo.ShakeTime)
        {
            result = 1;
        }
        else if (this.ShakeTime == _CameraShakeInfo.ShakeTime)
        {
            result = 0;
        }
        else
        {
            result = -1;
        }
        return result;
    }

}
public enum ECountry
{
    ECountry_None = -1,
    ECountry_Player = 1,
    ECountry_Enemy = 2,
    ECountry_NPC = 3,
    ECountry_Friend = 4,
    ECountry_Count = 5
}
#endregion

