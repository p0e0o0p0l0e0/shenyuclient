using UnityEngine;
public class UITeamInviteTipWindow : UIWindow<UITeamInviteTipWindow, UITeamInviteTipController>
{
    enum TipsType
    {
        Invite,     //邀请界面
        PleaseLeave, //请离界面
    }

    #region ui control name define

    private const string Team = "UITeamInviteTipWindow/Team";
    private const string RightBtn = "UITeamInviteTipWindow/Team/Invite/AcceptBtn";
    private const string LeftBtn = "UITeamInviteTipWindow/Team/Invite/RefuseBtn";
    private const string CenterBtn = "UITeamInviteTipWindow/Refuse/SendBtn";
    private const string InviteText = "UITeamInviteTipWindow/Invite/InviteTeamText";

    private const string TeamJob = "UITeamInviteTipWindow/Team/Top/Job";
    private const string TeamHead = "UITeamInviteTipWindow/Team/Top/Head";
    private const string TeamNameShow = "UITeamInviteTipWindow/Team/Top/Name";
    private const string TeamLevel = "UITeamInviteTipWindow/Team/Top/Level";
    private const string TeamBattleNumText = "UITeamInviteTipWindow/Team/Top/BattleNumText";
    private const string TeamFromText = "UITeamInviteTipWindow/Team/Top/TeamFromText";

    private const string PleaseLeave = "UITeamInviteTipWindow/PleaseLeave";
    private const string AgreeBtn = "UITeamInviteTipWindow/PleaseLeave/AgreeBtn";
    private const string RefuseBtn = "UITeamInviteTipWindow/PleaseLeave/RefuseBtn";
    private const string LeaveJob = "UITeamInviteTipWindow/PleaseLeave/Top/Job";
    private const string LeaveHead = "UITeamInviteTipWindow/PleaseLeave/Top/Head";
    private const string LeaveName = "UITeamInviteTipWindow/PleaseLeave/Top/Name";
    private const string LeaveLevel = "UITeamInviteTipWindow/PleaseLeave/Top/Level";
    private const string LevelBattleNumText = "UITeamInviteTipWindow/PleaseLeave/Top/LevelBattleNumText";


    #endregion
    protected override void Initial()
    {
        base.Initial();
    }
    ExText _leftButtonText;
    string _leftButtonStr;

    UICallback.VO_CB _leftCallback;
    UICallback.VO_CB _rightCallback;
    PartyInfoStruct _partyInfoStruct;
    ViTimeNode2 time;
    uint count;
    TipsType _tipsType;
    public void InitInviteJoinTeam(UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback, PartyInfoStruct p)
    {
        _tipsType = TipsType.Invite;
        ShowTeamUI(true);
        _leftCallback = leftCallback;
        _rightCallback = rightCallback;
        ExUIButton _leftButton = GetComponent<ExUIButton>(LeftBtn);
        ExUIButton _rightButton = GetComponent<ExUIButton>(RightBtn);
        _rightButton.gameObject.GetComponentInChildren<ExText>().text = I18NManager.Instance.GetWord("tips_119"); //接受
        _leftButtonText = _leftButton.gameObject.GetComponentInChildren<ExText>();
        _leftButtonStr = I18NManager.Instance.GetWord("tips_120") + "("; //拒绝
        _leftButton.RemoveButtonAllListener();
        //_inviteText.text = "邀请您加入队伍";
        StartTime(15, 1);
        _leftButton.onClick.AddListener(() =>
        {
            DetachTime();
            if (leftCallback != null)
                leftCallback(p.ID);
            _mController.HideTipWindow();
        });
        _rightButton.RemoveButtonAllListener();
        _rightButton.onClick.AddListener(() =>
        {
            DetachTime();
            if (rightCallback != null)
                rightCallback(p.ID);
            _mController.HideTipWindow();
        });
        GetComponent<ExText>(TeamNameShow).text = p.Leader.NameAlias;
        GetComponent<ExText>(TeamLevel).text = "" + p.Leader.Level;
        GetComponent<ExUISprite>(TeamJob).SpriteName = ViSealedDB<VisualCorner>.Data(p.Leader.Gender * 6 + (byte)p.Leader.HeroClass).professionIcon + "1";
        GetComponent<ExUISprite>(TeamHead).SpriteName = ViSealedDB<VisualCorner>.Data(p.Leader.Gender * 6 + (byte)p.Leader.HeroClass).iconName;

        //  GetComponent<ExText>(TeamBattleNumText).text  =p.Leader.
        // GetComponent<ExText>(TeamFromText).text   =
    }




    public void InitPleaseLeave(UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback, PartyInfoStruct p)
    {
        _tipsType = TipsType.PleaseLeave;
        ShowTeamUI(false);
        _leftCallback = leftCallback;
        _rightCallback = rightCallback;
        ExUIButton _leftButton = GetComponent<ExUIButton>(AgreeBtn);
        ExUIButton _rightButton = GetComponent<ExUIButton>(RefuseBtn);
        _rightButton.gameObject.GetComponentInChildren<ExText>().text = I18NManager.Instance.GetWord("tips_119"); //接受
        _leftButton.gameObject.GetComponentInChildren<ExText>().text = I18NManager.Instance.GetWord("tips_120"); //拒绝
        _leftButton.RemoveButtonAllListener();                                                                                                         //_inviteText.text = "邀请您加入队伍";
        StartTime(15, 1);
        _leftButton.onClick.AddListener(() =>
        {
            DetachTime();
            leftCallback(p.Leader.ID);
            _mController.HideTipWindow();
        });
        _rightButton.RemoveButtonAllListener();
        _rightButton.onClick.AddListener(() =>
        {
            DetachTime();
            rightCallback(p.Leader.ID);
            _mController.HideTipWindow();
        });
        GetComponent<ExText>(LeaveName).text = p.Leader.NameAlias;
        GetComponent<ExText>(LeaveLevel).text = "" + p.Leader.Level;
        GetComponent<ExUISprite>(TeamJob).SpriteName = ViSealedDB<VisualCorner>.Data(p.Leader.Gender * 6 + (byte)p.Leader.HeroClass).professionIcon + "1";
        GetComponent<ExUISprite>(TeamHead).SpriteName = ViSealedDB<VisualCorner>.Data(p.Leader.Gender * 6 + (byte)p.Leader.HeroClass).iconName;

        //  GetComponent<ExText>(TeamBattleNumText).text  =p.Leader.
        // GetComponent<ExText>(TeamFromText).text   =
    }

    private void StartTime(uint all,uint span)
    {
        time = new ViTimeNode2();
        count = all;
        time.Start(ViTimerRealInstance.Timer, all, span);
        time.Delegate = TimeCallBack;
    }


    private void DetachTime()
    {
        if (time != null)
            time.Detach();
    }

    private void TimeCallBack(ViTimeNodeInterface node)
    {
        count--;
        _leftButtonText.text = _leftButtonStr + count + "s)";
        if (count <= 0)
        {
            if (_leftCallback != null)
                _leftCallback(_partyInfoStruct.ID);
            _mController.HideTipWindow();
            DetachTime();
        }
    }

    private void ShowTeamUI(bool isTeamShow)
    {
        this.GetComponent<Transform>(Team).SetActive(isTeamShow);
        this.GetComponent<Transform>(PleaseLeave).SetActive(!isTeamShow);
    }
    public override void Hide()
    {
        _leftCallback = null;
        _rightCallback = null;
        GetComponent<ExUIButton>(LeftBtn).RemoveButtonAllListener();
        GetComponent<ExUIButton>(RightBtn).RemoveButtonAllListener();
        base.Hide();
    }
}

