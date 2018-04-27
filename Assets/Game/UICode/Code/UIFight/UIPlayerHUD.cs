using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPlayerHUD: UIWindowComponent<UIFightWindow, UIFightController>
{
    private const string PlayerHeadSp = "/Info/Head";
    private const string PlayerName = "/Info/Name";
    private const string PlayerLevel = "/Info/Level";
    private const string PPlayerProTran = "/Hp";
    private const string BackSlider = "BackSlider";
    private const string FrontSlider = "FontSlider";
    private const string BoomSlider = "BoomSlider";

    protected ExCircleSprite _heroIconSp = null;
    protected Text _heroLevel = null;
    protected Text _heroName = null;
    protected PlayerHeadProgress _pHp = new PlayerHeadProgress();
    protected bool _isClose = false;

    public class PlayerHeadProgress:UIDirectManager.BoomHpElement
    {

    }

    public override void Initial(UIFightWindow window, string topPath)
    {
        base.Initial(window, topPath);
        _heroIconSp = this.GetComponent<ExCircleSprite>(PlayerHeadSp);
        ExUIButton btn = GetComponent<ExUIButton>(PlayerHeadSp);
        if (btn.NotNull())
            btn.onClickEx = (val, o) => UIManagerUtility.ShowPlayerInfo(UIPlayerInfoController.WinType.Prop);

        _heroLevel = this.GetComponent<Text>(PlayerLevel);
        _heroName = this.GetComponent<Text>(PlayerName);
        _pHp.Tran = this.FindTransform(PPlayerProTran);
        Transform backTran = _pHp.Tran.Find(BackSlider);
        Transform frontTran = _pHp.Tran.Find(FrontSlider);
        Transform boomTran = _pHp.Tran.Find(BoomSlider);
        _pHp.BackProgress = backTran.GetComponentInChildren<Slider>();
        _pHp.FrontProgress = frontTran.GetComponentInChildren<Slider>();
        _pHp.SubProgress = boomTran.GetComponentInChildren<Slider>();
        _pHp.HpSp = frontTran.GetComponentInChildren<ExUISprite>();
        _pHp.Open();
        _isClose = !_rootTran.gameObject.activeInHierarchy;
    }
    public virtual void UpdateName(string name)
    {
        _heroName.text = name;
    }
    public virtual void UpdateLevel(string level)
    {
        _heroLevel.text = level;
    }
    public virtual void UpdateIcon(IconData icon)
    {
        if (icon != null)
            UIUtility.SetSprite(_heroIconSp, icon);
    }
    public virtual void UpdatePlayerHp(float val)
    {
        _pHp.UpdateProgress(val);
    }
    public virtual void UpdatePlayerBoom(float val)
    {
        _pHp.UpdateSubProgress(val);
    }
    public override void Dispose()
    {
        _pHp = null;
    }
    public virtual void SetBoomVisible(bool isVisible)
    {
        _pHp.SetBoomVisible(isVisible);
    }
    public virtual void Open()
    {
        _isClose = false;
        this._rootTran.gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        _isClose = true;
        this._rootTran.gameObject.SetActive(false);
    }
    public virtual void UpdateHostile(bool ishostile)
    {
        HP_Type typ = ishostile ? HP_Type.Hostile : HP_Type.Unhostile;
        _pHp.SetHpType(typ);
    }
}
