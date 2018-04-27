using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamInviteTipType
{
    RequestJoinTeam,//申请入队，队长界面
    InviteJoinTeam, //被邀请界面，普通人界面
}

public class UITeamInviteTipController : UIController<UITeamInviteTipController, UITeamInviteTipWindow>
{
    public override void Show()
    {
        EventDispatcher.AddEventListener(Events.PartyEvent.EnterParty, HideTipWindow);
        base.Show();
    }
    public void InitInviteJoinTeam(UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback, PartyInfoStruct p)
    {
        _mWinHandler.InitInviteJoinTeam(leftCallback, rightCallback, p);
    }

    public void InitPleaseLeave(UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback, PartyInfoStruct p)
    {
        _mWinHandler.InitPleaseLeave(leftCallback, rightCallback, p);
    }
    public override void Hide()
    {
        EventDispatcher.RemoveEventListener(Events.PartyEvent.EnterParty, HideTipWindow);
        base.Hide();
    }
    public void HideTipWindow()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_TeamInviteTip);
    }
}

