using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeamListController : UIController<UITeamListController, UITeamListWindow>
{
    private List<PartyDetail> partyList;// = new List<PartyPropertyEx>();
    private void _OnPartyListUpdate()
    {
        ViDebuger.Error("partyList : " + partyList.Count);
    }
    public override void Show()
    {
        base.Show();
        EventDispatcher.AddEventListener(Events.PartyEvent.EnterParty, _OnTeamCreate);
        EventDispatcher.AddEventListener(Events.PartyEvent.ExitTeam, _OnExitTeam);
        EventDispatcher.AddEventListener<List<PartyDetail>>(Events.PartyEvent.PartyListUpdate, _OnPartyListUpdate);
        //PlayerCommandInvoker.PartyList(Player.Instance, partyList, _OnPartyListUpdate);
        if (PartyInstance.IsInParty)
            _mWinHandler.ShowTeamList(false);
        else
        {
            _mWinHandler.ShowTeamList(true);
            
        }
            
    }
    public void UpdatePartyList(ViEntityACK.DeleACKCallback callback)
    {
        PlayerServerInvoker.PartyList(Player.Instance, callback);
    }
    private bool _isCreating;
    public void OnBtnCreateTeamClick()
    {
        if (!_isCreating)
        {
            _isCreating = true;
            PartyInstance.CreateParty(()=>{
                _isCreating = false;
            });
        }
    }
    public override void Hide()
    {
        _isCreating = false;
        EventDispatcher.RemoveEventListener<List<PartyDetail>>(Events.PartyEvent.PartyListUpdate, _OnPartyListUpdate);
        EventDispatcher.RemoveEventListener(Events.PartyEvent.EnterParty, _OnTeamCreate);
        
        EventDispatcher.RemoveEventListener(Events.PartyEvent.ExitTeam, _OnExitTeam);
        base.Hide();
    }
    private void _OnTeamCreate()
    {
        _mWinHandler.ShowTeamList(false); //关闭队伍列表UI，显示队伍UI
//#if PARTY
//        ViDebuger.Record("TEST: Agree Join Party AUTO");
//        PlayerServerInvoker.AgreeJoinPartyLazy(Player.Instance, 1);
//#endif
        //UIManager.Instance.Hide(UIControllerDefine.WIN_TeamList);
        //UIManagerUtility.ShowTeam();
    }
    private void _OnPartyListUpdate(List<PartyDetail> partyList)
    {
        if (this.partyList != null)
        {
            this.partyList.Clear();
        }
        this.partyList = partyList;
        _mWinHandler.OnPartyListUpdate(partyList);
    }

    public void ShowNearParty()
    {
        _mWinHandler.SetNearShow();
    }

    private void _OnExitTeam()
    {
        _mWinHandler.OnExitTeam();
    }
}
