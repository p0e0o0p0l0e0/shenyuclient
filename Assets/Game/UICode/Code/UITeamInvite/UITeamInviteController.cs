using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeamInviteController : UIController<UITeamInviteController, UITeamInviteWindow>
{
    public void ShowInviteTipButton(bool isTrue, List<PartyInfoStruct> inviteList, UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback)
    {
        _mWinHandler.ShowInviteTipBtn(isTrue, inviteList,leftCallback,rightCallback);
    }
}
