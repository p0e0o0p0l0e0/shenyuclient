using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
public class UITeamInviteWindow : UIWindow<UITeamInviteWindow, UITeamInviteController>
{
    #region ui control name define
    private const string InviteTipBtn = "UITeamInviteWindow/InviteTipBtn";
    private const string InviteBg = "UITeamInviteWindow/InviteBg";
    private const string InviteList = "UITeamInviteWindow/InviteBg/InviteList";
    private const string Content = "UITeamInviteWindow/InviteBg/InviteList/Content/";
    private const string FromText = "/FromText";
    private const string FromTip = "来自";
    private const string FromTip1 = "的组队邀请";
    #endregion
    private ExUIToggle _tipToggle;
    private ExUISprite _tipSprite;
    private GameObject _inviteBg;
    private LoopVerticalScrollRect _inviteList;
    private ViTimeNode4 _updateTime = new ViTimeNode4();
    protected override void Initial()
    {
        base.Initial();
        _tipToggle = GetComponent<ExUIToggle>(InviteTipBtn);
        _tipToggle.onValueChanged.AddListener(_OnToggleChanged);
        _tipSprite = _tipToggle.gameObject.GetComponent<ExUISprite>();
        _inviteBg = GetComponent<Transform>(InviteBg).gameObject;
        _inviteList = GetComponent<LoopVerticalScrollRect>(InviteList);
        _inviteList.Init(_RefreshList,0);
    }
    private Tweener _tn;
    private List<PartyInfoStruct> _invite;
    private Dictionary<ulong, int> _inviteTimer = new Dictionary<ulong, int>();
    private List<ulong> _index = new List<ulong>();
    public void ShowInviteTipBtn(bool isTrue, List<PartyInfoStruct> inviteList, UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback)
    {
        if (!isTrue)
        {
            //Hide This
            _index.Clear();
            _inviteTimer.Clear();
            if(_invite != null)
                _invite.Clear();
            UIManager.Instance.Hide(UIControllerDefine.WIN_TeamInvite);
            _updateTime.Detach();
            return;
        }
        _leftCallback = leftCallback;
        _rightCallback = rightCallback;
        if (_invite != null)
            _invite.Clear();
        _invite = inviteList;
        this._inviteList.ChangeTotalCount(inviteList.Count);
        if (inviteList.Count > 5)
            this._inviteList.vertical = true;
        else
            this._inviteList.vertical = false;
        //remove old invite
        for (int i = _index.Count - 1; i >=0; i --)
        {
            PartyInfoStruct p = _invite.Find(delegate (PartyInfoStruct m)
            {
                return m.ID == _index[i];
            });
            if(p == null)
            {
                if (_inviteTimer.ContainsKey(_index[i]))
                    _inviteTimer.Remove(_index[i]);
                _index.RemoveAt(i);
            }   
        }
        
        //add new invite
        for (int i = 0; i < _invite.Count; i ++)
        {
            if (!_inviteTimer.ContainsKey(_invite[i].LeaderID))
            {
                _inviteTimer.Add(_invite[i].LeaderID, 30);
                _index.Add(_invite[i].LeaderID);
            }
        }
        if (isTrue)
            _ShowInviteTipBtn();
        else
            ;
        _updateTime.Start(ViTimerRealInstance.Timer, 100, _UpdateInviteTime);
    }
    private void _UpdateInviteTime(ViTimeNodeInterface node)
    {
        for(int i = _index.Count - 1; i >= 0 ; i --)
        {
            if (_inviteTimer.ContainsKey(_index[i]))
            {
                if (_inviteTimer[_index[i]] <= 0)
                    _inviteTimer.Remove(_index[i]);
                else
                    _inviteTimer[_index[i]]--;
            }
            else
            {
                _index.RemoveAt(i);
            }
        }
    }
    private void _ShowInviteTipBtn()
    {
        _tipToggle.gameObject.SetActive(true);
        _tn = UIUtility.TweenAlpha(_tipSprite, 1f, 0.5f, 0.5f, null, true, -1, LoopType.Yoyo);
    }
    private void _OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            _tn.Kill(true);
            _tipSprite.color = new Color(_tipSprite.color.r, _tipSprite.color.g, _tipSprite.color.b,1) ;
            _inviteBg.SetActive(true);
        }
        else
        {
            _inviteBg.SetActive(false);
            _ShowInviteTipBtn();
        }
    }
    private void _RefreshList(string path, int id)
    {
        if(_invite != null && id < _invite.Count)
        {
            ExUIButton exUIButton = GetComponent<ExUIButton>(Content + path);
            exUIButton.Id = id;
            exUIButton.onClickEx = _OnItemClick;
            ExText et = GetComponent<ExText>(Content + path + FromText);
            et.text = FromTip + _invite[id].Leader.NameAlias + FromTip1;
        }
    }
    private UICallback.VO_CB _leftCallback, _rightCallback;
    private void _OnItemClick(int val, object obj)
    {
        if (_invite != null && val >=0 && val <= _invite.Count)
        {
            UIManagerUtility.ShowTeamInviteTip(TeamInviteTipType.InviteJoinTeam, _leftCallback, _rightCallback, _invite[val]);
        }
        
    }
}
