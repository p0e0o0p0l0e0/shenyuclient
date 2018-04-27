using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIControllerDefine
{
    public enum LayerType
    {
        NORMAL,//是否参与栈排序
        NORMAL_TOP,//显示栈的最高层
        TOP//所有界面的最高层显示
    }
    #region controller define
    public const string WIN_Login = "UILoginWindow";
    public const string WIN_Common = "UICommonWindow";
    public const string WIN_Role = "UIRoleWindow";
    public const string WIN_CreateRole = "UIRoleCreateWindow";
    public const string WIN_FightWindow = "UIFightWindow";
    //public const string WIN_Direct = "UIDirectorWindow";
    public const string WIN_MiniMap = "UIMiniMapWindow";
    public const string WIN_Goal = "UIGoalWindow";
	public const string WIN_TeamList = "UITeamListWindow";
	public const string WIN_TeamInviteFriend = "UITeamInviteFriendWindow";
    public const string WIN_TeamInviteTip = "UITeamInviteTipWindow";
    public const string WIN_TeamInvite = "UITeamInviteWindow";
    public const string WIN_Story = "UIStoryWindow";
    public const string WIN_Tips = "UITipsWindow";
    public const string WIN_PlayerInfo = "UIPlayerInfoWindow";
    public const string WIN_LevelUp = "UIRoleLevelUpWindow";
    public const string WIN_Bag = "UIKnapsackWindow";
    public const string WIN_GoalDetail = "UIGoalDetailsWindow";
    public const string WIN_PreloadCommon = "UIPreloadWindow";
    public const string WIN_Resurrection = "UIResurrectionWindow";
    public const string WIN_Friend = "UIFriendWindow";
    public const string WIN_FriendAdd = "UIFriendAddWindow";
    public const string WIN_FriendAddBlack = "UIFriendAddBlackWindow";
    public const string WIN_ChatSys = "UIChatWindow";
    #endregion
}
public class UIControllerRegister
{

    static UICallback.UICTRL_CB CreateControllerCB<ControllerT, WindowT>()
    where WindowT : UIWindow<WindowT, ControllerT>, new()
    where ControllerT : UIController<ControllerT, WindowT>, new()
    {
        return UIController<ControllerT, WindowT>.CreateController;
    }


    public static void Register(Dictionary<string, UICallback.UICTRL_CB> reigsterCallBack)
    {
        reigsterCallBack[UIControllerDefine.WIN_Login] = CreateControllerCB<UILoginController, UILoginWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Common] = CreateControllerCB<UICommonController, UICommonWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Role] = CreateControllerCB<UIRoleController, UIRoleWindow>();
        reigsterCallBack[UIControllerDefine.WIN_CreateRole] = CreateControllerCB<UIRoleCreateController, UIRoleCreateWindow>();
        reigsterCallBack[UIControllerDefine.WIN_FightWindow] = CreateControllerCB<UIFightController, UIFightWindow>();
        //reigsterCallBack[UIControllerDefine.WIN_Direct] = CreateControllerCB<UIDirectController, UIDirectWindow>();
        reigsterCallBack[UIControllerDefine.WIN_MiniMap] = CreateControllerCB<UIMiniMapController, UIMiniMapWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Goal] = CreateControllerCB<UIGoalController, UIGoalWindow>();
		reigsterCallBack[UIControllerDefine.WIN_TeamList] = CreateControllerCB<UITeamListController, UITeamListWindow>();
		reigsterCallBack[UIControllerDefine.WIN_TeamInviteFriend] = CreateControllerCB<UITeamInviteFriendController, UITeamInviteFriendWindow>();
        reigsterCallBack[UIControllerDefine.WIN_TeamInvite] = CreateControllerCB<UITeamInviteController, UITeamInviteWindow>();
        reigsterCallBack[UIControllerDefine.WIN_TeamInviteTip] = CreateControllerCB<UITeamInviteTipController, UITeamInviteTipWindow>();

		reigsterCallBack[UIControllerDefine.WIN_Story] = CreateControllerCB<UIStoryController, UIStoryWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Tips] = CreateControllerCB<UITipsController, UITipsWindow>();
        reigsterCallBack[UIControllerDefine.WIN_PlayerInfo] = CreateControllerCB<UIPlayerInfoController, UIPlayerInfoWindow>();
        reigsterCallBack[UIControllerDefine.WIN_LevelUp] = CreateControllerCB<UIRoleLevelUpController, UIRoleLevelUpWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Bag] = CreateControllerCB<UIBagController, UIBagWin>();
        reigsterCallBack[UIControllerDefine.WIN_GoalDetail] = CreateControllerCB<UIGoalDetailsController, UIGoalDetailsWindow>();
        reigsterCallBack[UIControllerDefine.WIN_PreloadCommon] = CreateControllerCB<UICommonController, UICommonWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Resurrection] = CreateControllerCB<UIRoleResurrectionController, UIRoleResurrectionWindow>();
        reigsterCallBack[UIControllerDefine.WIN_Friend] = CreateControllerCB<UIFriendContoller, UIFriendWindow>();
        reigsterCallBack[UIControllerDefine.WIN_FriendAdd] = CreateControllerCB<UIFriendAddController, UIFriendAddWindow>();
        reigsterCallBack[UIControllerDefine.WIN_FriendAddBlack] = CreateControllerCB<UIFriendAddBlackController, UIFriendAddBlackWindow>();
        reigsterCallBack[UIControllerDefine.WIN_ChatSys] = CreateControllerCB<UIChatController, UIChatWindow>();
    }

}

public class EventsRegister
{
    public static void Register()
    {
        EventDispatcher.AddEventListener<int>(Events.PlayerEvent.PlayerLevelUpdated,(int lv)=> { UIManager.Instance.Show(UIControllerDefine.WIN_LevelUp); });
    }
}