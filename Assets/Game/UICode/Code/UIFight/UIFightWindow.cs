using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UIFightWindow : UIWindow<UIFightWindow, UIFightController>
{
    #region ui control name define
    private const string MoveBtn = "UIFightWindow/JoyStick/MoveBtn";
    private const string MoveCycle = "UIFightWindow/JoyStick/MoveBtn/Cycle";
    private const string JoyTran = "UIFightWindow/JoyStick/Joy";
    private const string AttackBtn = "UIFightWindow/SkillGroup/AttackBtn";
    private const string AttackSprite = "UIFightWindow/SkillGroup/CareerAttack";
    private const string RushBtn = "UIFightWindow/SkillGroup/Skills/Skill";
    private const string SkillBtn = "UIFightWindow/SkillGroup/Skills/SkillBack";
    private const string SkillLock = "UIFightWindow/SkillGroup/Skills/SkillEmpty";
    private const string SkillCdSp = "CD";
    private const string SkillCdText = "CDText";
    private const string SkillJoyTopTran = "UIFightWindow/SkillGroup/Skills/Pad";
    private const string SkillJoyTran = "UIFightWindow/SkillGroup/Skills/Pad/Joy";
    private const string SkillCancelBtn = "UIFightWindow/SkillGroup/Skills/CancelSkill";
    private const string PlayerHUD = "UIFightWindow/HUD/PlayerHead";
    private const string FocusHUD = "UIFightWindow/HUD/FightCouple/TargetPlayerHead";
    private const string FocusTargetHUD = "UIFightWindow/HUD/FightCouple/TargetPlayerHeadAim";

    private const string TransGatherButton = "UIFightWindow/GatherButton";
    private const string BagButton = "UIFightWindow/KnapsackButton";
    private const string RoleButton = "UIFightWindow/RoleButton";
    private const string FriendBtton = "UIFightWindow/FriendButton";
    private const string SpriteCollectCD = "UIFightWindow/GatherButton/CD";
    private const string MoveTopTran = "UIFightWindow/JoyStick";
    #endregion
    public static ViConstValue<float> MOVE_AREAN_X = new ViConstValue<float>("MOVE_AREAN_X", 0.7f);
    public static ViConstValue<float> MOVE_AREAN_Y = new ViConstValue<float>("MOVE_AREAN_Y", 0.5f);

    private static int LEFT_JOY_RADIUS = 100;

    public enum HUD
    {
        LOCAL_PLAYER,
        FOCUS_HERO,
        FOCUS_TARGET,
    }
    private ExUIButton _moveJoyBtn = null;
    private Transform _joyTran = null;
    private ExUIButton _attackBtn = null;
    private UIPointerListener _dragListener = null;
    private readonly int SKILL_COUNT = 5;
    private Vector3 _mJoyPos = Vector3.zero;
    private List<SkillBtnInfo> _skillElement = new List<SkillBtnInfo>();
    private SkillBtnInfo dashElement;
    private SkillJoy _skillJoy = null;
    private Transform _cancelSkillTran = null;
    private UIPlayerHUD _playerHUD = new UIPlayerHUD();
    private UIFocusHUD _focusPlayerHUD = new UIFocusHUD();
    private UIFocusHUD _focusPlayerTargetHUD = new UIFocusHUD();
    private Transform _transCollectSpaceObj = null;
    private ExUISprite _spriteCollectCD = null;
    private ExUIButton bagButton;
    private ExUIButton friendBtn;
    private UIPointerListener _moveAreaPointer = null;
    private Transform _moveCycTran = null;
    private ViTickNode cdTimer = new ViTickNode();
    private float _totalDuring = 0f;
    private float _curPercent = 0f;
    private int _id = 0;


    protected override void Initial()
    {
        base.Initial();
        _dragListener = this.GetComponent<UIPointerListener>(MoveBtn);
        
        _joyTran = this.FindTransform(JoyTran);
        _mJoyPos = _joyTran.localPosition;
        _attackBtn = this.GetComponent<ExUIButton>(AttackBtn);
        _attackBtn.onClick.AddListener(_onAttack);
        _attackBtn.OnTouchDownCallBack = _onAttackPress;
        _attackBtn.OnTouchUpCallBack = _onAttackRelease;
        for (int i = 0; i < SKILL_COUNT; ++i)
        {
            int index = i + 1;
            Transform tran = this.FindTransform(SkillBtn + index);
            SkillBtnInfo skill = new SkillBtnInfo();
            skill.Tran = tran;
            skill.Btn = this.GetComponent<UIPointerListener>(SkillBtn + index + "/Skill");
            skill.Btn.Id = i;
            skill.Btn.OnTouchDownCallBack = _onSkillPress;
            skill.Btn.OnDragCallBack = _onSkillDrag;
            skill.Btn.OnTouchUpCallBack = _onSkillRelease;
            skill.LockObj = GetComponent<ExUIButton>(SkillLock + index);
            skill.LockObj.onClickEx = (val, o) =>
            {
                int j = index-1;
                UIManagerUtility.ShowHint(TalentDataMgr.GetInstance.GetSpellLockTips(j));
            };
            skill.ProgressSP = this.GetComponent<ExUISprite>(SkillBtn + index + "/Skill" + "/" + SkillCdSp);
            skill.ProgressText = this.GetComponent<ExText>(SkillBtn + index + "/Skill" + "/" + SkillCdText);
            skill.Icon = this.GetComponent<ExCircleSprite>(SkillBtn + index + "/Skill");
            skill.Close();
            _skillElement.Add(skill);
        }

        var dashBtn = this.GetComponent<ExUIButton>(RushBtn + (SKILL_COUNT + 1));
        Transform dashtran = this.FindTransform(RushBtn + (SKILL_COUNT + 1));
        dashElement = new SkillBtnInfo();
        dashElement.ProgressSP = this.GetComponent<ExUISprite>(RushBtn + (SKILL_COUNT + 1) + "/" + SkillCdSp);
        dashElement.ProgressText = this.GetComponent<ExText>(RushBtn + (SKILL_COUNT + 1) + "/" + SkillCdText);
        dashBtn.onClickEx = (val, o) => { PlayerActionManager.Instance.ReqDoDash(); CellPlayerServerInvoker.REQ_DoDash(CellPlayer.Instance);  };
       
        Transform skillJoyTopTran = this.FindTransform(SkillJoyTopTran);
        Transform skillJoyTran = this.FindTransform(SkillJoyTran);
        _skillJoy = new SkillJoy();
        _skillJoy.Tran = skillJoyTopTran;
        _skillJoy.Joy = skillJoyTran;
        _skillJoy.Close();
        UIPointerListener skillCancel = this.GetComponent<UIPointerListener>(SkillCancelBtn);
        _cancelSkillTran = skillCancel.transform;
        skillCancel.OnMovingInCallBack = _onMovInSkillCancel;
        skillCancel.OnMovingOutCallBack = _onMovOutSkillCancel;
        skillCancel.OnDropCallBack = _onDropSkillCancel;
        SetCancelBtnVisible(false);
        _playerHUD.Initial(this, PlayerHUD);
        _focusPlayerHUD.Initial(this, FocusHUD);
        _focusPlayerTargetHUD.Initial(this, FocusTargetHUD);
        
        _spriteCollectCD = this.GetComponent<ExUISprite>(SpriteCollectCD);
        _transCollectSpaceObj = this.FindTransform(TransGatherButton);
        _transCollectSpaceObj.SetActive(false);
        EventDispatcher.AddEventListener<int, int>(Events.SceneCommonEvent.CollectSpaceObjectStart, _OnCollectSpaceObject);

        bagButton = GetComponent<ExUIButton>(BagButton);
        bagButton.onClickEx = (id, o) => UIManager.Instance.Show(UIControllerDefine.WIN_Bag);

        friendBtn = GetComponent<ExUIButton>(FriendBtton);
        friendBtn.onClickEx = (id, o) => UIManager.Instance.Show(UIControllerDefine.WIN_Friend);

        ExUIButton rolebtn = GetComponent<ExUIButton>(RoleButton);
        rolebtn.onClickEx = (val, o) => UIManagerUtility.ShowPlayerInfo(UIPlayerInfoController.WinType.Prop);
        _moveCycTran = this.FindTransform(MoveCycle);
        _SetMoveArea();
    }
    private void _SetMoveArea()
    {
        int width = Screen.width;
        int height = Screen.height;
        float rate = 1.0f * width / height;
        height = (int)UIDefine.DESIGN_RESOLUTION.y;
        width = (int)(UIDefine.DESIGN_RESOLUTION.y * rate);
        RectTransform rectTran = this.GetComponent<RectTransform>(MoveBtn);
        rectTran.SetInsetAndSizeFromParentEdge( RectTransform.Edge.Left, 0, width * MOVE_AREAN_X);
        rectTran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, height * MOVE_AREAN_Y);
        rectTran.localPosition = Vector3.zero;
    }
    private void _RegisterMoveAction(bool  isRegister)
    {
        if (isRegister)
        {
            if (_dragListener != null)
            {
                _dragListener.OnBeginDragCallBack = _onBeginDrag;
                _dragListener.OnHoldingCallBack = _onDraging;
                _dragListener.OnEndCallBack = _onEndDrag;
                _dragListener.OnTouchDownCallBack = _onTouchDown;
                _dragListener.OnTouchUpCallBack = _onTouchUp;
            }
        }
        else
        {
            if (_dragListener != null)
            {
                _dragListener.OnBeginDragCallBack = null;
                _dragListener.OnHoldingCallBack = null;
                _dragListener.OnEndCallBack = null;
                _dragListener.OnTouchDownCallBack = null;
                _dragListener.OnTouchUpCallBack = null;
            }
            if (_joyTran != null)
            {
                _joyTran.localPosition = Vector3.zero;
            }
        }

    }
    public override void Show()
    {
        base.Show();
        _RegisterMoveAction(true);
    }
    public override void Hide()
    {
        base.Hide();
        _RegisterMoveAction(false);
    }

    private void _onAttack()
    {
    }
    private void _onBeginDrag(int id, object eventData)
    {
        this._mController.OnMoveBegin();
    }
    private void _onDraging(int id, object eventData)
    {
        PointerEventData evt = eventData as PointerEventData;
        _updateJoyPosition(evt);
        Vector3 localPos = _joyTran.parent.InverseTransformPoint(_moveCycTran.position);
        this._mController.OnMoving(_joyTran.localPosition - localPos);
    }
    private void _onEndDrag(int id, object eventData)
    {
        _joyTran.localPosition = Vector3.zero;
        this._mController.OnMovEnd();
    }
    private void _onTouchDown(int id, object eventData)
    {
        PointerEventData evt = eventData as PointerEventData;
        if (evt != null)
        {
            Vector2 pos = UIManager.Instance.UICamera.ScreenToWorldPoint(evt.position);
            pos = _moveCycTran.parent.InverseTransformPoint(pos);
            _moveCycTran.localPosition = pos;
            _mJoyPos = pos;
        }
        _updateJoyPosition(evt);
    }
    private void _onTouchUp(int id, object eventData)
    {
        //_joyTran.localPosition = _mJoyPos;
        _joyTran.localPosition = Vector3.zero;
        _moveCycTran.localPosition = Vector3.zero;
    }
    private void _updateJoyPosition(PointerEventData eventData)
    {
        Vector3 localPos = UIUtility.ScreenToLocalPosition(_joyTran, eventData.position);
        Vector3 joyDir = localPos - _mJoyPos;
        if (Vector3.Distance(_mJoyPos, localPos) <= LEFT_JOY_RADIUS)
            _joyTran.localPosition = localPos;
        else
            _joyTran.localPosition = _mJoyPos + joyDir.normalized * LEFT_JOY_RADIUS;
        _joyTran.localPosition = new Vector3(_joyTran.localPosition.x, _joyTran.localPosition.y, 0);
    }
    private void _onSkillPress(int id, object obj)
    {
        bool ret = this._mController.OnSkillPress(id);
        if (ret)
        {
            SkillBtnInfo skillBtn = _skillElement[id];
            _skillJoy.SetTargetCenter(skillBtn.Tran.localPosition);
            _skillJoy.Open();
            SetCancelBtnVisible(true);
        } else
            SetCancelBtnVisible(false);
    }
    public void SetCancelBtnVisible(bool isvisible)
    {
        _cancelSkillTran.gameObject.SetActive(isvisible);
    }
    private void _onSkillDrag(int id, object obj)
    {
        if (_skillJoy.IsVisible)
        {
            _skillJoy.UpdateJoyPosition(obj);
        }
        this._mController.OnDragingSpell(SkillJoy.RIGHT_JOY_RADIUS, _skillJoy.Joy.localPosition);
    }
    private void _onSkillRelease(int id, object obj)
    {
        _skillJoy.Close();
        this._mController.OnSkillRelease();
    }
    public void SetSkillCD(float val)
    {
    }
    public override void Destroy()
    {
        for (int i = 0; i < _skillElement.Count; ++i)
        {
            _skillElement[i].Destroy();
        }
        _skillElement.Clear();

        EventDispatcher.RemoveEventListener<int, int>(Events.SceneCommonEvent.CollectSpaceObjectStart, _OnCollectSpaceObject);
        base.Destroy();
    }

    public void ClearSkill()
    {
        //闪避不算在技能按钮里  特殊处理
        for (int i = 0; i < _skillElement.Count; i++)
        {
            _skillElement[i].Close();
        }
    }

    public void UpdateSkill(int index, UIAtlas atlas, string icon)
    {
        if (index < _skillElement.Count)
        {
            _skillElement[index].Open();
            if (index != _skillElement.Count - 1)//rush skill except
                _skillElement[index].SetIcon(atlas, icon);
        }
    }
    public void UpdateSkillCd(int index, Int64 startTime, Int64 endTime)
    {
        if (index < _skillElement.Count)
        {
            _skillElement[index].ResetCD(ViTimerInstance.Time, startTime, endTime);
        }
    }

    public void UpdateDashCD(Int64 startTime, Int64 endTime)
    {
        dashElement.ResetCD(ViTimerInstance.Time, startTime, endTime);
    }
    private void _onAttackPress(int id, object obj)
    {
        this._mController.OnAttackPress();
    }
    private void _onAttackRelease(int id, object obj)
    {
        this._mController.OnAttackRelease();
    }
    private void _onMovInSkillCancel(int id, object obj)
    {
        this._mController.OnMovInCancel();
    }
    public void _onMovOutSkillCancel(int id, object obj)
    {
        this._mController.OnMovOutCancel();
    }
    public void _onDropSkillCancel(int id, object obj)
    {
        this._mController.OnDropCancel();
    }

    private UIPlayerHUD _GetPlayerHud(HUD hud)
    {
        switch (hud)
        {
            case HUD.LOCAL_PLAYER: return _playerHUD;
            case HUD.FOCUS_HERO: return _focusPlayerHUD;
            case HUD.FOCUS_TARGET: return _focusPlayerTargetHUD;
        }
        return null;
    }
    public void UpdateHUDHp(HUD hud, float val)
    {
        UIPlayerHUD hudElement = _GetPlayerHud(hud);
        if (hudElement != null)
            hudElement.UpdatePlayerHp(val);
    }
    public void UpdateHUDBoom(HUD hud, float val)
    {
        UIPlayerHUD hudElement = _GetPlayerHud(hud);
        if (hudElement != null)
        {
            hudElement.UpdatePlayerBoom(val);
        }
    }
    public void UpdateHUDHostile(HUD hud, bool isHostile)
    {
        UIPlayerHUD hudElement = _GetPlayerHud(hud);
        if (hudElement != null)
        {
            hudElement.UpdateHostile(isHostile);
        }
    }
    public void UpdateHUD_Name(HUD hud, string name)
    {
        UIPlayerHUD hudElement = _GetPlayerHud(hud);
        if (hudElement != null)
            hudElement.UpdateName(name);
    }
    public void UpdateHUD_Level(HUD hud, string level)
    {
        UIPlayerHUD hudElement = _GetPlayerHud(hud);
        if (hudElement != null)
            hudElement.UpdateLevel(level);
    }
    public void UpdateHUD_Icon(HUD hud, IconData icon)
    {
        UIPlayerHUD hudElement = _GetPlayerHud(hud);
        if (hudElement != null)
            hudElement.UpdateIcon(icon);
    }
    public void CancelFocus()
    {
        UIPlayerHUD hudElement = _GetPlayerHud(HUD.FOCUS_TARGET);
        hudElement.Close();
        hudElement = _GetPlayerHud(HUD.FOCUS_HERO);
        hudElement.Close();
    }
    public void CancelFocusTarget()
    {
        UIPlayerHUD hudElement = _GetPlayerHud(HUD.FOCUS_TARGET);
        hudElement.Close();
    }

    private void _OnCollectSpaceObject(int id, int duration)
    {
        if (duration == 0)
        {
            EventDispatcher.TriggerEvent<int>(Events.SceneCommonEvent.CollectSpaceObjectEnd, _id);
            return;
        }

        _curPercent = 0;
        _totalDuring = duration / 100f;
        _id = id;

        _transCollectSpaceObj.SetActive(true);
        _spriteCollectCD.SetImageFillAmount(_curPercent);

        cdTimer.Attach(_OnTimeUpdate);
    }
    private void _OnTimeUpdate(float detalTime)
    {
        _curPercent += detalTime / _totalDuring;
        if (_curPercent >= 1)
        {
            cdTimer.Detach();
            _spriteCollectCD.SetImageFillAmount(1);
            _transCollectSpaceObj.SetActive(false);
            EventDispatcher.TriggerEvent<int>(Events.SceneCommonEvent.CollectSpaceObjectEnd, _id);
        }
        else
            _spriteCollectCD.SetImageFillAmount(_curPercent);
    }
    protected override void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            PlayerActionManager.Instance.OnReleaseCancelSkill();
            SetCancelBtnVisible(false);
            _skillJoy.Close();
            this._mController.OnMovEnd();
            //ViDebuger.Record("OnApplicationPause");
        }

    }
    protected override void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            PlayerActionManager.Instance.OnReleaseCancelSkill();
            SetCancelBtnVisible(false);
            _skillJoy.Close();
            this._mController.OnMovEnd();
            //ViDebuger.Record("OnApplicationFocus");
        }

    }
}
