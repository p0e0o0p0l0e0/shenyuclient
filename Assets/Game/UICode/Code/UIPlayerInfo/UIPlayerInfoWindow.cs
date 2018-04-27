using System;
using UnityEngine;
using System.Collections.Generic;

public class UIPlayerInfoWindow : UIWindow<UIPlayerInfoWindow, UIPlayerInfoController>
{
    #region ui control name define
    private const string CloseBtn = "UIPlayerInfoWindow/CloseBtn";
    private const string AttrRoot = "UIPlayerInfoWindow/ShowList/PlayerProp";
    private const string ShowRoot = "UIPlayerInfoWindow/EquipList";
    private const string WearEquip = "/Equip";
    private const string TalentRoot = "UIPlayerInfoWindow/ShowList/PlayerTalent";

    private const string PropBtnRoot = "UIPlayerInfoWindow/BtnList/Prop";
    private const string TalentBtnRoot = "UIPlayerInfoWindow/BtnList/Talent";
    private const string WingBtnRoot = "UIPlayerInfoWindow/BtnList/Wing";

    #endregion

    private ExUIButton closeBtn;

    private const string normalName = "BtnNomal";
    private const string selectName = "BtnSelect";

    private ExUIButton propNorBtn;
    private GameObject propSelObj;

    private ExUIButton TalentNorBtn;
    private GameObject TalentSelObj;

    private ExUIButton WingNorBtn;
    private GameObject WingSelObj;

    private Transform showRoot;

    public PlayerAttrWin attrWin { get; private set; }
    public PlayerShowWin showWin { get; private set; }
    public PlayerTalentWin talentWin { get; private set; }

    protected override void Initial()
    {
        base.Initial();
        attrWin = new PlayerAttrWin();
        attrWin.Initial(this, AttrRoot);

        showWin = new PlayerShowWin();
        showWin.Initial(this,_mController,ShowRoot);

        talentWin = new PlayerTalentWin();
        talentWin.Initial(this,_mController,TalentRoot);

        closeBtn = GetComponent<ExUIButton>(CloseBtn);
        closeBtn.onClickEx = (a, b) => UIManager.Instance.Hide(UIControllerDefine.WIN_PlayerInfo);

        propSelObj = FindTransform(String.Format("{0}/{1}", PropBtnRoot, selectName)).gameObject;
        propNorBtn = GetComponent<ExUIButton>(String.Format("{0}/{1}", PropBtnRoot, normalName));
        propNorBtn.onClickEx = (a, b) =>
        {
            _mController.curType = UIPlayerInfoController.WinType.Prop;
        };

        TalentSelObj = FindTransform(String.Format("{0}/{1}", TalentBtnRoot, selectName)).gameObject;
        TalentNorBtn = GetComponent<ExUIButton>(String.Format("{0}/{1}", TalentBtnRoot, normalName));
        TalentNorBtn.onClickEx = (a, b) =>
        {
            _mController.curType = UIPlayerInfoController.WinType.Talent;
        };

        WingSelObj = FindTransform(String.Format("{0}/{1}", WingBtnRoot, selectName)).gameObject;
        WingNorBtn = GetComponent<ExUIButton>(String.Format("{0}/{1}", WingBtnRoot, normalName));
        WingNorBtn.onClickEx = (a, b) =>
        {
            _mController.curType = UIPlayerInfoController.WinType.Wing;
        };
        for (int i = 0; i < 8; i++)
        {
            ExUIButton btn = this.GetComponent<ExUIButton>(ShowRoot + WearEquip + i);
            btn.Id = UIBagDataMgr.GetInstance.GetWearTypeByItemId(i);
            btn.onClickEx = ClickWearEquip;
        }
    }

    public override void Show()
    {
        base.Show();
        this.StartNextFrameTask(() => {
            ShowByType(_mController.curType);
            RushWearEquip();
        });

    }

    public override void Hide()
    {
        showWin.HideModel();
        base.Hide();
    }

    public override void Destroy()
    {
        base.Destroy();
        UIBagDataMgr.GetInstance.UnLoadTexture();
    }

    #region 页签切换
    public void ShowByType(UIPlayerInfoController.WinType type)
    {
        switch (type)
        {
            case UIPlayerInfoController.WinType.Prop:
                propSelObj.SetActive(true);
                propNorBtn.gameObject.SetActive(false);
                attrWin.Show();
                _mController.RefreshAttr();
                showWin.Show();
                talentWin.Hide();
                break;
            case UIPlayerInfoController.WinType.Talent:
                TalentSelObj.SetActive(true);
                TalentNorBtn.gameObject.SetActive(false);
                talentWin.Show();
                showWin.Hide();
                break;
            case UIPlayerInfoController.WinType.Wing:
                break;
            case UIPlayerInfoController.WinType.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void HideByType(UIPlayerInfoController.WinType type)
    {
        switch (type)
        {
            case UIPlayerInfoController.WinType.Prop:
                propSelObj.SetActive(false);
                propNorBtn.gameObject.SetActive(true);
                attrWin.Hide();
                break;
            case UIPlayerInfoController.WinType.Talent:
                showWin.Hide();
                talentWin.Hide();
                TalentSelObj.SetActive(false);
                TalentNorBtn.gameObject.SetActive(true);
                break;
            case UIPlayerInfoController.WinType.Wing:
//                showWin.Hide();
                break;
            case UIPlayerInfoController.WinType.None:
                //                showWin.Hide();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion

    #region 装备穿戴
    public void RushWearEquip()
    {
        for (int i = 0; i < 8; i++)
        {
            this.FindTransform(ShowRoot + WearEquip + i).gameObject.SetActive(false);
        }
        for (int i = 0; i < Player.Instance.Property.Equipments.Count; i++)
        {
            // Debug.Log(i+"---->"+Player.Instance.Property.Equipments[i].Property.Info);
            string path = ShowRoot + "/" + UIBagDataMgr.GetInstance.GetWearItemName(Player.Instance.Property.Equipments[i].Property.Info.Value.EquipSlot);
            Transform trans = this.FindTransform(path);
            if (trans != null)
            {
                trans.gameObject.SetActive(true);
                ExUITexture tex = this.GetComponent<ExUITexture>(path);
                UIBagDataMgr.GetInstance.SetItemIconAndQuality(ref tex, Player.Instance.Property.Equipments[i].Property.Info, ExUITexture_Extend.IconStyle.CYCLE);
            }
        }
    }

    private void ClickWearEquip(int id, object obj)
    {
        for (int i = 0; i < Player.Instance.Property.Equipments.Count; i++)
        {
            if (Player.Instance.Property.Equipments.Array[i].Property.Info.Value.EquipSlot == id)
            {
                UIManagerUtility.ShowTips(false, Player.Instance.Property.Equipments.Array[i].Property.Info, Player.Instance.Property.Equipments.Array[i].Property.Slot.Slot, false);
                break;
            }
        }
    }
    #endregion




    public string ResetSpellText { get { return I18NManager.Instance.GetWord("tips_6"); } }
    public string LearnSpellTextThree { get { return I18NManager.Instance.GetWord("tips_5"); } }
    public string LearnSpellTextOne { get { return I18NManager.Instance.GetWord("tips_27"); } }
    public string LearnSpellTextTwo { get { return I18NManager.Instance.GetWord("tips_26"); } }
}
