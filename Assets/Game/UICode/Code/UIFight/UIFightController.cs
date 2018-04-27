using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFightController : UIController<UIFightController, UIFightWindow>
{
    private ViAsynCallback<ViReceiveDataNode, object> _spellCDListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private ViAsynCallback<ViReceiveDataNode, object> _dashCDCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private ViAsynCallback<ViReceiveDataNode, object> _spellListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private ViAsynCallback<ViReceiveDataNode, object> _infoChangeCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private float _lastRadius = 0;
    private Vector3 _lastBallPos = Vector3.zero;
    private bool _isFireSkill = false;
    private bool _isInCanceling = false;
    private bool _isDelaySetFocus = false;
    public override void Show()
    {
        base.Show();
        CellHero.LocalHero.Property.SpellList.CallbackList.Attach(_spellListCallback, this._OnSpellListUpdated);
        CellHero.LocalHero.Property.SpellCDList.CallbackList.Attach(_spellCDListCallback, this._OnSpellListUpdated);
        CellHero.LocalHero.Property.DashCD.CallbackList.Attach(_dashCDCallback, this.UpdateDash);
        CellHero.LocalHero.Property.Level.CallbackList.Attach(_infoChangeCallback, UpdatePlayerInfo);
        this._updateSkills();
        _updatePlayerInfo();
        _updateFocus();
        FocusManager.Instance.OnFocusChangeCallBack += _OnFocus;
        FocusManager.Instance.OnFocusStateChangeCallBack += _OnFocusTargetStateChange;
        UpdateFocusTarget();
    }
    public override void Hide()
    {
        _dashCDCallback.End();
        _spellCDListCallback.End();
        _spellListCallback.End();
        _infoChangeCallback.End();
        FocusManager.Instance.OnFocusChangeCallBack -= _OnFocus;
        FocusManager.Instance.OnFocusStateChangeCallBack -= _OnFocusTargetStateChange;
        base.Hide();
        
    }
    private void _OnFocus()
    {
        if (FocusManager.Instance.CurFocusUnitId == 0)
        {
            CancelFocusHUD();
        } else
        {
            _updateFocus();
        }
    }
    private void _OnFocusTargetStateChange(object obj)
    {
        if (obj != null)
        {
            FocusChangeStruct target = obj as FocusChangeStruct;
            _updateFocusTarget(target);
        }
        else
        {
            CancelFocusTargetHUD();
        }
        
        
    }
    private void _updateFocus()
    {
        if (FocusManager.Instance.CurFocusUnitId > 0)
        {
            _checkFocusSelf();
            FocusChangeStruct data = FocusManager.Instance.GetCurFocusData();
            IconData icon = data.Icon;
            //temp.s
            if (icon.Atlas == null || string.IsNullOrEmpty(icon.Sprite))
            {
                icon = new IconData("HeroIconAtlas", "icon_blame");
            }
            //temp.e
            string name = data.Name;
            string level = data.Level;
            this.UpdateFocusIcon(icon);
            this.UpdateFocusName(name);
            this.UpdateFocusLevel(level);
            this.UpdateFocusHostile(data.IsHostile);
            float val = data.IsShowBoom ? data.Boom_percent : -1;
            this.UpdateFocusBoom(val);
            UpdateFocusHp(data.Hp_percent);
        }

        _isDelaySetFocus = false;
    }

    private void UpdateFocusTarget()
    {
        FocusManager.Instance.FocusTarget();
            
    }
    private bool _checkFocusSelf()
    {
        if (FocusManager.Instance.CurFocusUnitId == CellHero.LocalHeroID)
        {
            CancelFocusTargetHUD();
            return true;
        }
        return false;
    }
    private void _updateFocusTarget(FocusChangeStruct data)
    {
        if (!_checkFocusSelf())
        {
            IconData icon = data.Icon;
            string name = data.Name;
            string level = data.Level;
            this.UpdateFocusTargetIcon(icon);
            this.UpdateFocusTargetName(name);
            this.UpdateFocusTargetLevel(level);
            this.UpdateFocusTargetHostile(data.IsHostile);
            float val = data.IsShowBoom ? data.Boom_percent : -1;
            this.UpdateFocusTargetBoom(val);
        }

    }

	//从队伍界面获得的焦点
	public void ShowTeamMember(PartyMemberStruct data)
	{
		FocusChangeStruct focus = new FocusChangeStruct();
		string name = data.NameAlias;
		string level = "" + data.Level;
		focus.Hp_percent = 1;
		focus.IsHostile = false;
		focus.IsShowBoom = false;
		focus.Level = level;
		focus.Name = name;
		VisualHeroStruct vhs = ViSealedDB<VisualHeroStruct>.Data(data.Photo);
		if (vhs != null && vhs.PhotoA != null)
		{
			IconData icon = IconDataManager.GetIcon(vhs.PhotoA);
			this.UpdateFocusIcon(icon);
			focus.Icon = icon;
		}

		//this.UpdateFocusName(name);
		//this.UpdateFocusLevel(level);
		//this.UpdateFocusHostile(false);

		//float val = data.IsShowBoom ? data.Boom_percent : -1;
		//	this.UpdateFocusBoom(val);
	}

    public void UpdatePlayerInfo(UInt32 dele, ViReceiveDataNode old, object now)
    {
        _updateSkills();
        _updatePlayerInfo();
    }
    private void _updatePlayerInfo()
    {
        CellHero hero = CellHero.LocalHero;
        IconData icon = IconDataManager.GetIcon(hero.VisualInfo.PhotoA);
        if (hero.Property != null && !string.IsNullOrEmpty(hero.Property.NameAlias))
            this._mWinHandler.UpdateHUD_Name(UIFightWindow.HUD.LOCAL_PLAYER, hero.Property.NameAlias);
        if (hero.Property != null)
            this._mWinHandler.UpdateHUD_Level(UIFightWindow.HUD.LOCAL_PLAYER, hero.Property.Level.Value.ToString());       
        this._mWinHandler.UpdateHUD_Icon(UIFightWindow.HUD.LOCAL_PLAYER, icon);
		if (CellHero.LocalHero != null)
            this.UpdateLocalPlayerHp(1.0f * CellHero.LocalHero.Property.HP.Value / CellHero.LocalHero.Property.HPMax0.Value);
        _mWinHandler.UpdateHUDBoom(UIFightWindow.HUD.LOCAL_PLAYER,hero.GetSpPrecent());
    }
    void _OnSpellListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        _updateSkills();
    }
    private void _updateSkills()
    {
        _mWinHandler.ClearSkill();
        XLColorDebug.LogUI("刷新战斗界面技能图标");
        for (int i = 0; i < CellHero.LocalHero.Property.SpellList.Count; ++i)
        {
            ReceiveDataHeroSpellProperty spellProperty = CellHero.LocalHero.Property.SpellList[i].Property;
            OwnSpellStruct ownSpellInfo = spellProperty.Info.Value;
            if(TalentDataMgr.GetInstance.SpellGridLock(spellProperty.SetupIdx.Value))
                continue;
            XLColorDebug.LogUI(string.Format("技能id{0}  索引{1} 图标{2}", ownSpellInfo.ID, spellProperty.SetupIdx.Value, ownSpellInfo.Icon));
            Int64 startTime = 0;
            Int64 endTime = 0;
            IconData icon = IconDataManager.GetIcon(ownSpellInfo.Icon);
            this._mWinHandler.UpdateSkill(spellProperty.SetupIdx, icon.Atlas, icon.Sprite);
            if (ownSpellInfo.Operate == (int)BoolValue.FALSE)
            {
                continue;
            }
            PlayerActionManager.Instance.CanCastSkill(spellProperty, out startTime, out endTime);           
            this._mWinHandler.UpdateSkillCd(spellProperty.SetupIdx, startTime, endTime);
        }
        XLColorDebug.LogUI("---------------------------------");
    }

    private void UpdateDash(UInt32 dele, ViReceiveDataNode old, object now)
    {
        XLColorDebug.LogUI("闪避CD   时间"+ CellHero.LocalHero.Property.DashCD);
        var startTime = PlayerActionManager.Instance.GetDashStartTime(CellHero.LocalHero.Property.DashCD);
        this._mWinHandler.UpdateDashCD( startTime, CellHero.LocalHero.Property.DashCD);
    }
    public void OnMoveBegin()
    {
        PlayerActionManager.Instance.OnBeginMove();
    }
    public void OnMoving(Vector3 joyPos)
    {
        //Debug.Log("------------>OnMoving.pos="+ joyPos);
        if (joyPos.sqrMagnitude > 0.001)
            PlayerActionManager.Instance.OnMoving(joyPos);
    }
    public void OnMovEnd()
    {
        PlayerActionManager.Instance.OnEndMove();
    }
    public void OnAttackPress()
    {
        PlayerActionManager.Instance.OnPressAttack();
    }
    public void OnAttackRelease()
    {
        PlayerActionManager.Instance.OnReleaseAttack();
    }
    public bool OnSkillPress(int index)
    {
        _isFireSkill = true;
        return PlayerActionManager.Instance.OnPressSkill(index);
    }

    public void OnDragingSpell(float radius, Vector3 ballPos)
    {
        _lastRadius = radius;
        _lastBallPos = ballPos;
        PlayerActionManager.Instance.OnDragingSpell(radius, ballPos);
    }
    public void OnSkillRelease()
    {
        _isFireSkill = false;
        this._mWinHandler.SetCancelBtnVisible(false);
        if (_isInCanceling)
        {
            _isInCanceling = false;
            PlayerActionManager.Instance.OnReleaseCancelSkill();
            return;
        }
        
        PlayerActionManager.Instance.OnReleaseSpell();

    }
    public void OnMovInCancel()
    {
        if (_isFireSkill)
        {
            _isInCanceling = true;
            PlayerActionManager.Instance.OnPressCancelSkill();           
        }          
    }
    public void OnMovOutCancel()
    {
        if (_isFireSkill)
        {
            PlayerActionManager.Instance.OnRetrunBackToSkill();
            _isInCanceling = false;
        }          
    }
    public void OnDropCancel()
    {
        if (_isFireSkill && _isInCanceling)
        {
            PlayerActionManager.Instance.OnReleaseCancelSkill();
            this._mWinHandler.SetCancelBtnVisible(false);
        }          
    }
    
    public void UpdateLocalPlayerHp(float val)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDHp(UIFightWindow.HUD.LOCAL_PLAYER, val);
    }
    public void UpdateLocalPlayerBoom(float val)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDBoom(UIFightWindow.HUD.LOCAL_PLAYER, val);
    }
    //hp
    public void UpdateFocusHp(float val)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDHp(UIFightWindow.HUD.FOCUS_HERO, val);
    }
    public void UpdateFocusTargetHp(float val)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDHp(UIFightWindow.HUD.FOCUS_TARGET, val);
    }
    //boom
    public void UpdateFocusBoom(float val)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDBoom(UIFightWindow.HUD.FOCUS_HERO, val);
    }
    public void UpdateFocusTargetBoom(float val)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDBoom(UIFightWindow.HUD.FOCUS_TARGET, val);
    }
    //name
    public void UpdateFocusName(string name)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUD_Name(UIFightWindow.HUD.FOCUS_HERO, name);
    }
    public void UpdateFocusTargetName(string name)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUD_Name(UIFightWindow.HUD.FOCUS_TARGET, name);
    }
    //level
    public void UpdateFocusLevel(string level)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUD_Level(UIFightWindow.HUD.FOCUS_HERO, level);
    }
    public void UpdateFocusTargetLevel(string level)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUD_Level(UIFightWindow.HUD.FOCUS_TARGET, level);
    }
    //icon
    public void UpdateFocusIcon(IconData icon)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUD_Icon(UIFightWindow.HUD.FOCUS_HERO, icon);
    }
    public void UpdateFocusTargetIcon(IconData icon)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUD_Icon(UIFightWindow.HUD.FOCUS_TARGET, icon);
    }
    //hostile

    public void UpdateFocusHostile(bool ishostile)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDHostile(UIFightWindow.HUD.FOCUS_HERO, ishostile);
    }
    public void UpdateFocusTargetHostile(bool ishostile)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateHUDHostile(UIFightWindow.HUD.FOCUS_TARGET, ishostile);
    }
    public void CancelFocusHUD()
    {
        if (this.IsShow)
            this._mWinHandler.CancelFocus();
        _isDelaySetFocus = false;
    }
    public void CancelFocusTargetHUD()
    {
        if (this.IsShow)
            this._mWinHandler.CancelFocusTarget();
    }
}
