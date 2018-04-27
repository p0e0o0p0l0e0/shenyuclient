using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIGoalWindow : UIWindow<UIGoalWindow, UIGoalController>
{
    #region ui control name define
    private const string BtnSlideInOut = "UIGoalWindow/Widget/btnSlideInOut";
    private const string ToggleGoal = "UIGoalWindow/Widget/TransMovePanel/ListGroup/toggleGoal";
    private const string ToggleTeam = "UIGoalWindow/Widget/TransMovePanel/ListGroup/toggleTeam";
    private const string TransMovePanel = "UIGoalWindow/Widget/TransMovePanel";
    private const string TransGoalList = "UIGoalWindow/Widget/TransMovePanel/GoalList";
    private const string TransGoalItem = "UIGoalWindow/Widget/TransMovePanel/GoalList/ScrollView/Viewport/VerticalLayoutGroup/GoalItem";
    private const string TransMissionCompleted = "UIGoalWindow/MissionCompleted";
    private const string TxtStoryModel = "UIGoalWindow/txtStoryModel";

    private const string TeamList = "UIGoalWindow/Widget/TransMovePanel/TeamList";
    private const string InviteBtn = "UIGoalWindow/Widget/TransMovePanel/NoTeamInvite/NoFriendText";
    private const string NoTeamInvite = "UIGoalWindow/Widget/TransMovePanel/NoTeamInvite";
    private const string TeamEntrance = "UIGoalWindow/Widget/TransMovePanel/Team";
    private const string Matching = "UIGoalWindow/Widget/TransMovePanel/Matching";
    private const string MatchingText = "UIGoalWindow/Widget/TransMovePanel/Matching/MatchingText";
    private const string MatchingBtn = "UIGoalWindow/Widget/TransMovePanel/Matching/TentativeMatchingBtn";

    private const string CreateBtn = "UIGoalWindow/Widget/TransMovePanel/Team/CreateTeamBtn";
    private const string NearbyBtn = "UIGoalWindow/Widget/TransMovePanel/Team/NearbyTeamBtn";
    private const string TeamHallBtn = "UIGoalWindow/Widget/TransMovePanel/Team/TeamHallBtn";
    #endregion
    private const int MoveDuration = 1;

    private ExUIButton _btnSlideInOut = null;
    private Toggle _toggleGoal = null;
    private Toggle _toggleTeam = null;
    private ExText txtStoryModel = null;
    private TweenScale _tweenScale = null;

    private Transform _transMovePanel = null;
    private Transform _transGoalList = null;
    private Transform _transGoalItem = null;
    private Transform _transMissionCompleted = null;
    private GameObject _objEffect = null;
    private Dictionary<uint, UIGoalManager.GoalItemElement> _goalItem = new Dictionary<uint, UIGoalManager.GoalItemElement>();

    private ViTimeNode1 _node1 = new ViTimeNode1();

    private Vector3[] _MovePoints = { Vector3.zero, Vector3.left * 300 };
    private Vector3[] _Direction = { Vector3.one, new Vector3(-1, 1, 1) };
    private bool _isMoving = false;
    private bool _isIn = true;
    private bool _isGoalOn = true;

    private UIPartyComponent _uiParty;
    private ExUIButton _inviteBtn;
    private GameObject _noTeamInvite;
    private GameObject _partyEntrance;
    private GameObject _matchingUi;
    private ExText _matchingText;
    private ViTimeNode2 _machingTime = new ViTimeNode2();
    protected override void Initial()
    {
        base.Initial();

        _btnSlideInOut = this.GetComponent<ExUIButton>(BtnSlideInOut);
        _btnSlideInOut.AddButtonListener(_OnSlideInOutClick);
        _toggleGoal = this.GetComponent<Toggle>(ToggleGoal);
        _toggleTeam = this.GetComponent<Toggle>(ToggleTeam);
        _toggleGoal.onValueChanged.AddListener(_OnGoalTagClick);
        _toggleTeam.onValueChanged.AddListener(_OnTeamTagClick);

        _transMovePanel = this.FindTransform(TransMovePanel);
        _transGoalList = this.FindTransform(TransGoalList);
        _transGoalItem = this.FindTransform(TransGoalItem);
        _transGoalItem.SetActive(false);
        _transMissionCompleted = this.FindTransform(TransMissionCompleted);
        _tweenScale = _transMissionCompleted.GetComponent<TweenScale>();
        _transMissionCompleted.SetActive(false);

        txtStoryModel = this.GetComponent<ExText>(TxtStoryModel);

        UIGoalManager.Instance.SetGoalItemTran(_transGoalItem);

        _uiParty = new UIPartyComponent();
        _uiParty.Initial(this, TeamList);
        _noTeamInvite = this.GetComponent<Transform>(NoTeamInvite).gameObject;
        _partyEntrance = this.GetComponent<Transform>(TeamEntrance).gameObject;
        _matchingUi = this.GetComponent<Transform>(Matching).gameObject;
        _matchingText = this.GetComponent<ExText>(MatchingText);
        GetComponent<ExUIButton>(MatchingBtn).onClick.AddListener(_OnMatchingBtnClick); //取消匹配

        GetComponent<ExUIButton>(CreateBtn).onClick.AddListener(_OnCreateTeamBtnClick);
        GetComponent<ExUIButton>(NearbyBtn).onClick.AddListener(_OnShowNearTeamBtnClick);
        GetComponent<ExUIButton>(TeamHallBtn).onClick.AddListener(_OnShowTeamListBtnClick);
        _inviteBtn = this.GetComponent<ExUIButton>(InviteBtn);
        _inviteBtn.AddButtonListener(_OnInviteBtnClick);
        if (PartyInstance.IsInParty)
            _OnShowTeamList();
        //_uiParty.SetActive(_toggleTeam.isOn);
        EventDispatcher.AddEventListener(Events.PartyEvent.FastMatching, _OnFastMatching);
        EventDispatcher.AddEventListener(Events.PartyEvent.EnterParty, _OnShowTeamList);
        EventDispatcher.AddEventListener<bool>(Events.GoalEvent.UpdateMapInfo, _OnShowPrompt);
    }
    public override void Destroy()
    {
        isToggleTeamOn = false;

        _uiParty.Dispose();
        _uiParty = null;
        _inviteBtn.RemoveButtonAllListener();
        EventDispatcher.RemoveEventListener(Events.PartyEvent.FastMatching, _OnFastMatching);
        EventDispatcher.RemoveEventListener(Events.PartyEvent.EnterParty, _OnShowTeamList);
        EventDispatcher.RemoveEventListener<bool>(Events.GoalEvent.UpdateMapInfo, _OnShowPrompt);
        _btnSlideInOut.RemoveButtonAllListener();
        _goalItem.Clear();
        _goalItem = null;
        UIGoalManager.Instance.Destroy();

        base.Destroy();
    }
    private void _OnSlideInOutClick()
    {
        if (_isMoving)
            return;
        if (_transMovePanel == null)
            return;

        _isMoving = true;
        _isIn = !_isIn;
        _transMovePanel.LocalMove(_MovePoints[_isIn ? 0 : 1], MoveDuration, _OnMoveEnd);
    }
    private void _OnMoveEnd()
    {
        _btnSlideInOut.SetLocalScale(_Direction[_isIn ? 0 : 1]);
        _isMoving = false;
    }
    private void _OnGoalTagClick(bool isOn)
    {
        if (isOn && _isGoalOn)
            UIManager.Instance.Show(UIControllerDefine.WIN_GoalDetail);
        _isGoalOn = isOn;
        _transGoalList.SetActive(isOn);
    }
    private bool isToggleTeamOn;
    private void _OnTeamTagClick(bool isOn)
    {
        _uiParty.SetActive(isOn);
        if (isOn)
        {
            if (isToggleTeamOn)
                _mController.OnToggleTeamClick(true);
            else
                _mController.OnToggleTeamClick(false);
        }
        isToggleTeamOn = isOn;

        ShowPartyEntrance(!PartyInstance.IsInParty);
    }
    private void _OnShowTeamList()
    {
        if (_toggleTeam.isOn)
        {//手动调用
            _OnTeamTagClick(true);
        }
        _toggleTeam.isOn = true;
    }
    private void _UpdateGoal(GoalObject goal)
    {
        UIGoalManager.GoalItemElement goalItemElement = null;
        if (!_goalItem.TryGetValue(goal.ID, out goalItemElement))
        {
            goalItemElement = UIGoalManager.Instance.SpwanGoalItem();
            _goalItem.Add(goal.ID, goalItemElement);
        }
        if (goal != null && goalItemElement != null)
        {

            goalItemElement.UpdateInfo(goal);
            UIGoalManager.Instance.RefreshPosition(goalItemElement);
        }
    }
    private void _OnClickGoalItem(uint id)
    {
        this._mController.ClickGoalItem(id);
    }
    public void UpdateGoalList(List<GoalObject> goalList)
    {
        if (goalList.Count == 0)
        {
            return;
        }
        if (UIGoalManager.Instance.CreateGoalItem(goalList.Count, _OnClickGoalItem))
        {
            for (int i = 0; i < goalList.Count; i++)
                _UpdateGoal(goalList[i]);
        }
    }
    public void UpdateGoalArray(GoalObject[] goalArray)
    {
        UIGoalManager.Instance.CreateGoalItem(goalArray.Length, _OnClickGoalItem);
        for (int i = 0; i < goalArray.Length; i++)
            _UpdateGoal(goalArray[i]);
    }
    public void KillGoalItem(uint id)
    {
        UIGoalManager.GoalItemElement goalItemElement = null;
        if (_goalItem.TryGetValue(id, out goalItemElement))
        {
            goalItemElement = _goalItem[id];
            UIGoalManager.Instance.KillGoalItemElement(goalItemElement);
            _goalItem.Remove(id);
        }
    }
    public void ShowGoalCompleteUI()
    {
        _transMissionCompleted.SetActive(true);
        //if (_objEffect == null)
        //{
        //    _objEffect = UIEffectManager.Instance.Load(UIGoalDefine.EFFECT_COMPLETEBIGGOAL, _OnEffectLoadedCallBack);
        //}

        _tweenScale.TweenScale(Vector3.one * 0.8f, Vector3.one, 1);

        ViTimerInstance.SetTime(_node1, 100, _OnAnimationEnd);
    }
    private void _OnEffectLoadedCallBack(string name, object go)
    {
        if (go == null)
            return;
        _objEffect = go as GameObject;
        _objEffect.transform.SetParent(_transMissionCompleted);
        _objEffect.transform.localPosition = Vector3.zero;
        _objEffect.transform.localScale = Vector3.one;
    }
    private void _OnAnimationEnd(ViTimeNodeInterface nodeInterface)
    {
        _transMissionCompleted.SetActive(false);
    }



    private void _OnFastMatching()
    {
        ShowPartyEntrance(true);
        if (PartyInstance.IsFastMatching)
        {
            count = 0;
            _machingTime = new ViTimeNode2();
            _machingTime.Delegate = MatchingTimeCallback;
            _machingTime.Start(ViTimerRealInstance.Timer, 600, 1);
        }
        else
        {
            if (_machingTime != null)
                _machingTime.Detach();
        }
    }
    int count = 0;
    private void MatchingTimeCallback(ViTimeNodeInterface node)
    {
        count++;
        _matchingText.text = String.Format(I18NManager.Instance.GetWord("tips_228"), count.ToString());
        if (count == 599)
            _OnMatchingBtnClick();
    }

    public void ShowPartyEntrance(bool isShow)
    {
        if (_toggleTeam.isOn)
        {
            if (isShow)
            {
                if (PartyInstance.IsFastMatching)
                {
                    _matchingUi.SetActive(true);
                    _partyEntrance.SetActive(false);
                }
                else
                {
                    _matchingUi.SetActive(false);
                    _partyEntrance.SetActive(true);
                }
            }
            else
            {
                _matchingUi.SetActive(false);
                _partyEntrance.SetActive(false);
            }
        }
        else
        {
            _matchingUi.SetActive(false);
            _partyEntrance.SetActive(false);
        }

    }
    private void _OnCreateTeamBtnClick()
    {
        if (!PartyInstance.IsInParty)
            _mController.OnBtnCreateTeamClick();
    }
    private void _OnShowNearTeamBtnClick()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_TeamList, () =>
        {
            UITeamListController uc = UIManager.Instance.GetController<UITeamListController, UITeamListWindow>(UIControllerDefine.WIN_TeamList);
            uc.ShowNearParty();
        });
    }
    private void _OnShowTeamListBtnClick()
    {
        _mController.OnToggleTeamClick(true);
    }
    public void ShowInviteBtn(bool isShow)
    {
        _noTeamInvite.SetActive(isShow);
    }
    private void _OnInviteBtnClick()
    {
        _mController.OnInviteBtnClick();
    }

    //取消匹配回调
    private void _OnMatchingBtnClick()
    {
        if (PartyInstance.IsFastMatching)
        {
            PartyInstance.FastMatching();
        }

    }
    private void _OnShowPrompt(bool show)
    {
        txtStoryModel.SetActive(true);
        txtStoryModel.SetTextContent(show ? "退出剧情模式" : "进入剧情模式");
        ViTimerInstance.SetTime(_node2, 200, _OnShowPromptEnd);
    }
    private void _OnShowPromptEnd(ViTimeNodeInterface nodeInterface)
    {
        txtStoryModel.SetActive(false);
    }

    ViTimeNode1 _node2 = new ViTimeNode1();




}
