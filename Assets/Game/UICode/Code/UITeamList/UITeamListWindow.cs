using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITeamListWindow : UIWindow<UITeamListWindow, UITeamListController>
{
    #region ui control name define
    //private const string BtnCreateGroup = "UITeamListWindow/CreateGroupBtn";
    private const string BtnClose = "UITeamListWindow/CloseBtn";
    private const string BtnTeamList = "UITeamListWindow/LeftBtn/TeamListBtn";
    private const string BtnMyTeam = "UITeamListWindow/LeftBtn/MyTeamBtn";
    private const string BtnTeamListSelect = "UITeamListWindow/LeftBtn/TeamListBtn/Select";
    private const string BtnMyTeamSelect = "UITeamListWindow/LeftBtn/MyTeamBtn/Select";

    private const string TeamListPanel = "UITeamListWindow/Team";
    private const string MyTeamPanel = "UITeamListWindow/MyTeam";
    #endregion

    private UITeamListComponent _teamListComponent;
    private UIMyTeamListComponent _myTeamListComponent;
    private ExUIButton _myTeamBtn;
    private GameObject _leftBtnSelect0,_leftBtnSelect1;
    private GameObject _myTeam; //可能会放到子Component中
    protected override void Initial()
    {
    	base.Initial();
    	this.GetComponent<ExUIButton>(BtnClose).AddButtonListener(_OnCloseClick);
        _teamListComponent = new UITeamListComponent();
        _teamListComponent.Initial(this, TeamListPanel);
        _myTeamListComponent = new UIMyTeamListComponent();
        _myTeamListComponent.Initial(this, MyTeamPanel);
        ExUIButton teamListBtn = GetComponent<ExUIButton>(BtnTeamList);
        teamListBtn.Id = 1;
        teamListBtn.onClickEx =_OnLeftBtnClick;

        _myTeamBtn = GetComponent<ExUIButton>(BtnMyTeam);
        _myTeamBtn.Id = 2;
        _myTeamBtn.onClickEx = _OnLeftBtnClick;

        _leftBtnSelect0 = GetComponent<Transform>(BtnTeamListSelect).gameObject;
        _leftBtnSelect1 = GetComponent<Transform>(BtnMyTeamSelect).gameObject;
  
        _myTeam = GetComponent<Transform>(MyTeamPanel).gameObject;
    }
    public void ShowTeamList(bool isTrue)
    {
        _teamListComponent.SetActive(isTrue);
        _myTeamListComponent.SetActive(!isTrue);
        _myTeam.SetActive(!isTrue);
        if (!PartyInstance.IsInParty)       
            _myTeamBtn.SetActive<ExUIButton>(false);
        else
            _myTeamBtn.SetActive<ExUIButton>(true);
        
        if (isTrue)
        {
            _leftBtnSelect0.SetActive(true);
            _leftBtnSelect1.SetActive(false);
            RefreshPartyList(()=> { });
        }
        else
        {
            _leftBtnSelect0.SetActive(false);
            _leftBtnSelect1.SetActive(true);          
        }    
    }
    public void RefreshPartyList(ViEntityACK.DeleACKCallback callback)
    {
        _mController.UpdatePartyList(callback);
    }
    private void _OnCloseClick()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_TeamList);
    }
    public void OnPartyListUpdate(List<PartyDetail> partyList)
    {
        _teamListComponent.OnPartyListUpdate(partyList);
    }
    public void OnBtnCreateTeamClick()
    {
        if (!PartyInstance.IsInParty)
            _mController.OnBtnCreateTeamClick();
        else
            PartyInstance.ExitParty();
    }
    public void OnExitTeam()
    {
        _teamListComponent.OnExitTeam();
        _myTeamBtn.SetActive<ExUIButton>(false);
        ShowTeamList(true);
    }
    private void _OnLeftBtnClick(int val, object obj)
    {
        if (val == 1)
        {
            ShowTeamList(true);
        }
        else if(PartyInstance.IsInParty)
        {
            ShowTeamList(false);
        }
        else
        {
            ViDebuger.Record("Not in A Party");
        }
    }

    public void SetNearShow()
    {
        _teamListComponent.SetNearTrue();
    }
    public override void Hide()
    {
        _teamListComponent.Dispose();
        base.Hide();
    }

   
}