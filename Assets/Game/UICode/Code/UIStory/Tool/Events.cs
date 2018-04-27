using UnityEngine;
using System.Collections.Generic;

public class EventArgs
{
    public bool Done;
    public object Args;
    public object Sender;
}

public class EventArgs<T> : EventArgs
{
    public T Param;
}

/// <summary>
/// 接收方的参数定义,按顺序给出
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field)]
public class EventParams : System.Attribute
{
    public EventParams(params System.Type[] types) { Types = types; }
    public System.Type[] Types { get; private set; }

    /// <summary>
    /// 收到后应返回的消息定义
    /// </summary>
    public string RetMsg;
    /// <summary>
    /// 描述
    /// </summary>
     public string Description;
}
public static class Events
{
    public static class BattleEvent
    {
        [EventParams(typeof(void))]
        public const string BattleExit = "UIBattleEvent.BattleExit";
        // 进入游戏
        [EventParams(typeof(void))]
        public const string BattleEnter = "Battle.Enter";
        // 某波加载完成
        [EventParams(typeof(int))]
        public const string BattleWaveLoaded = "Battle.BattleWaveFinish";
        // 某波死亡
        [EventParams(typeof(int))]
        public const string BattleWaveDie = "Battle.BattleWaveDie";
        [EventParams(typeof(int))]
        public const string ArriveWaveCenter = "Battle.ArriveWaveCenter";
        // 需要加载新的剧情文件,p1:剧情prefabname, p2:domission对象
        [EventParams(typeof(string), typeof(object))]
        public const string LoadNewStory = "B.LoadNewStory";
        // 需要销毁场景动态剧情
        [EventParams(typeof(string))]
        public const string DestroySceneStory = "B.DestroySceneStory";
        [EventParams(typeof(IStoryCharacter), typeof(float))]
        public const string HpChanged = "BattleEvent.HpChanged";
    }
    public static class SkillEvent
    {
        [EventParams(typeof(void))]
        public const string SkillStart = "Skill.SkillStart";
    }
    public static class StoryEvent
    {
        // loading结束，战斗最开始
        [EventParams(typeof(void))]
        public const string BattleBeginning = "Story.BattleBeginning";
        //战斗胜利
        [EventParams(typeof(void))]
        public const string BattleWin = "Story.BattleWin";
        //剧情开始播放
        [EventParams(typeof(void))]
        public const string StoryStart = "Story.StoryStart";
        //剧情结束播放
        [EventParams(typeof(string), typeof(string), typeof(object))]
        public const string PlayStoryEnd = "Story.PlayStoryEnd";
        [EventParams(typeof(bool),typeof(Vector3))]
        public const string ChangeCamera = "StoryEvent.ChangeCamera";
        //到达指定地点
        [EventParams(typeof(void))]
        public const string ArriveTargetPlace = "Story.ArriveTargetPlace";
        //广播转向
        [EventParams(typeof(List<Transform>))]
        public const string BroadCastLookAtPlayer = "Story.BroadCastLookAtPlayer";
        //剧情模式
        [EventParams(typeof(uint),typeof(bool))]
        public const string SetStoryModel = "Story.SetStoryModel";
        //
        [EventParams(typeof(Camera), typeof(bool))]
        public const string CinemaDirectorCameraEvent = "Story.CinemaDirectorCameraEvent";
    }
    /// <summary>
    /// 场景类型公用触发
    /// </summary>
    public static class SceneCommonEvent
    {
        /// <summary>
        /// 场景加载结束
        /// </summary>
        [EventParams(typeof(void))]
        public const string LoadedScene = "SCE.LoadedScene";
        /// <summary>
        /// 清理当前场景 发在切场景之前 销毁当前场景动态创建的东西
        /// </summary>
        [EventParams(typeof(void))]
        public const string ClearScene = "SCE.ClearScene";
        /// <summary>
        /// 创建主角完成
        /// </summary>
        [EventParams(typeof(void))]
        public const string CreatedLocalHero = "SCE.CreatedLocalHero";
        /// <summary>
        /// 销毁主角
        /// </summary>
        [EventParams(typeof(void))]
        public const string DestoryLocalHero = "SCE.DestoryLocalHero";
        /// <summary>
        /// 主角模型创建完成
        /// </summary>
        [EventParams(typeof(void))]
        public const string CreatedLocalHeroModel = "SCE.CreatedLocalHeroModel";

        [EventParams(typeof(int))]
        public const string CollectSpaceObjectStart = "B.CollectSpaceObjectStart";

        [EventParams(typeof(int), typeof(int))]
        public const string CollectSpaceObjectEnd = "B.CollectSpaceObjectEnd";

        [EventParams(typeof(int), typeof(int))]
        public const string OnNavTo = "MINIMAP.OnNavTo";

        [EventParams(typeof(bool))]
        public const string WaitConnectUI = "SCE.WaitConnectUI";

        /// <summary>
        /// 创建主角完成
        /// </summary>
        [EventParams(typeof(bool),typeof(IGoalFlag))]
        public const string NPCCreated = "SCE.NPCCreatedAndDestory";
    }

    public static class GoalEvent
    {
        [EventParams(typeof(uint))]
        public const string OnGoalEndNeedClick = "GoalEvent.OnGoalEndNeedClick";

        [EventParams(typeof(GoalStateType),typeof(List<IGoalMapInterface>))]
        public const string GoalStateTypeUpdate = "GoalEvent.GoalStateTypeUpdate";
        /// <summary>
        /// 更新小地图显示数据，true显示，false不显示
        /// </summary>
        [EventParams(typeof(bool))]
        public const string UpdateMapInfo = "GoalEvent.UpdateMapInfo";

        [EventParams(typeof(uint))]
        public const string OnGoalComplete = "GoalEvent.OnGoalComplete";
    }
    public static class PlayerEvent
    {
        [EventParams(typeof(int))]
        public const string PlayerLevelUpdated = "PlayerEvent.PlayerLevelUpdated";

        [EventParams(typeof(bool))]
        public const string PlayerPathFinding = "PlayerEvent.PlayerPathFinding";

        /// <summary>
        /// 主角模型创建完成
        /// </summary>
        [EventParams(typeof(void))]
        public const string PlayerMoveEnd = "SCE.PlayerMoveEnd";
        /// <summary>
        /// 主角模型创建完成
        /// </summary>
        [EventParams(typeof(void))]
        public const string PlayerBreakMove = "SCE.PlayerBreakMove";

        [EventParams(typeof(AutoPathType),typeof(List<ViVector3>))]
        public const string PlayerNavMove = "COMMON.PlayerNavMove";
        //切换最优解
        [EventParams(typeof(uint))]
        public const string SetLockTarget = "Story.SetLockTarget";
    }

    public static class PartyEvent
    {
		[EventParams(typeof(bool))]
		public const string MemberChange = "PartyEvent.MemberChange";

		[EventParams(typeof(void))]
		public const string LeaderChange = "PartyEvent.LeaderChange";

		[EventParams(typeof(void))]
		public const string EnterParty = "PartyEvent.EnterParty";

        [EventParams(typeof(void))]
        public const string FastMatching = "PartyEvent.FastMatching";

        [EventParams(typeof(void))]
		public const string ExitTeam = "PartyEvent.ExitTeam";

		[EventParams(typeof(List<PartyDetail>))]
		public const string PartyListUpdate = "PartyEvent.PartyListUpdate";

        [EventParams(typeof(void))]
        public const string BeDisagree = "PartyEvent.BeDisagree";

        [EventParams(typeof(void))]
        public const string PartyTargetChange = "PartyEvent.PartyTargetChange";
        [EventParams(typeof(void))]
        public const string PartyJoinChange = "PartyEvent.PartyJoinChange";
        [EventParams(typeof(void))]
        public const string PartyApplyChange = "PartyEvent.PartyApplyChange";
    }
    public static class SpaceEvent
    {
        [EventParams(typeof(void))]
        public const string SpaceLoadStart = "SpaceEvent.SpaceLoadStart";
        /// <summary>
        /// bool true:enter  false;exit
        /// </summary>
        [EventParams(typeof(bool))]
        public const string ChangeSpace = "SpaceEvent.ChangeSpace";
    }

    public static class FriendEvent
    {
        [EventParams(typeof(void))]
        public const string FriendSearchResult = "FriendEvent.FriendSearchResult";

        [EventParams(typeof(void))]
        public const string GameFriendRefresh = "FriendEvent.GameFriendRefresh";

        [EventParams(typeof(void))]
        public const string FriendApplyRefresh = "FriendEvent.FriendApplyRefresh";

        [EventParams(typeof(void))]
        public const string BlackListRefresh = "FriendEvent.BlackListRefresh";

        [EventParams(typeof(void))]
        public const string RecommandListRefresh = "FriendEvent.RecommandListRefresh";
    }

    #region 聊天系统事件标识

    public static class ChatSystemEvent
    {
        /// <summary>
        /// 屏蔽按钮功能   true->启用  false->取消
        /// </summary>
        [EventParams(typeof(bool))]
        public const string ShieldBtnFunc = "ChatSystemEvent.ShieldBtnFunc";

        /// <summary>
        /// 挂机按钮功能  true->启用   false->取消
        /// </summary>
        [EventParams(typeof(bool))]
        public const string HangUpBtnFunc = "ChatSystemEvent.HangUpFunc";

        /// <summary>
        ///  跟随按钮功能  true->启用   false->取消
        /// </summary>
        [EventParams(typeof(bool))]
        public const string FollowBtnFunc = "ChatSystemEvent.FollowBtnFunc";

        /// <summary>
        ///  自由按钮功能 true->启用   false->取消
        /// </summary>
        [EventParams(typeof(bool))]
        public const string FreeBtnFunc = "ChatSystemEvent.FreeBtnFunc";
        /// <summary>
        ///  接收信息
        /// </summary>
        [EventParams(typeof(ChatDataInfo))]
        public const string ChatReceives = "ChatSystemEvent.ChatReceives";
        /// <summary>
        /// 频道按钮事件
        /// </summary>
        [EventParams(typeof(string))]
        public const string ChatChannelBtn = "ChatSystemEvent.ChatChannelBtn";
        /// <summary>
        ///  发送消息
        /// </summary>
        [EventParams(typeof(string))]
        public const string ChatSendMessage = "ChatSystemEvent.ChatSendMessage";
        [EventParams(typeof(bool))]
        public const string ChatOpenBtnHandler = "ChatSystemEvent.ChatOpenBtnHandler";
        [EventParams(typeof(string), typeof(int))]
        public const string ChatRefeshMessage = "ChatSystemEvent.ChatRefeshMessage";

        /// <summary>
        /// 数据类 通知 controller
        /// </summary>
         [EventParams(typeof(void))]
        public const string ChatDataNoticeController = "ChatSystemEvent.ChatDataNoticeController";

        /// <summary>
        /// 主动获取对应频道数据
        /// </summary>
        [EventParams(typeof(byte))]
        public const string ChatGetDataMessage = "ChatSystemEvent.ChatGetDataMessage";
        /// <summary>
        /// 检测输入的内容是否合法,当前输入的内容和 输入前的内容
        /// </summary>
        [EventParams(typeof(string),typeof(string))]
        public const string ChatCheckMessage = "ChatSystemEvent.ChatCheckMessage";
        

    }
    #endregion
}


