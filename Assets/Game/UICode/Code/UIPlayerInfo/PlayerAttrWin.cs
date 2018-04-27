using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttrWin : UIWindowComponent<UIPlayerInfoWindow, UIPlayerInfoController>
{
    #region ui control name define
    private const string NameText = "/PlayerName";
    private const string LevelText = "/LvSign/LvNumText";
    private const string ProfessionText = "/ProfessionSign/ProfessionNumText";
    private const string NumberText = "/NumberSign/NumberNumText";
    private const string EquipGradeText = "/EquipGradeSign/EquipGradeNumText";
    private const string HPNumText = "/HPSign/HPNumText";
    private const string HPProgress = "/HPSign/HPProgress";
    private const string EXPNumText = "/EXPSign/EXPNumText";
    private const string EXPProgress = "/EXPSign/EXPProgress";

    private const string ScrollRect = "/BaseProp/PropList";
    private const string ScrollContent = "/BaseProp/PropList/Content";
    #endregion

    private Text nameText;
    private Text levelText;
    private Text professionText;
    private Text numberText;
    private Text equipGradeText;
    private Text hpNumText;
    private Slider hpProgress;
    private Text expNumText;
    private Slider expProgress;

    private LoopVerticalScrollRect scrollRect;
    private const string PropNameText= "PropNameText";
    private const string PropNumText = "PropNumText";

    private ViConstValue<int> MaxValue_PlayerLv = new ViConstValue<int>("MaxPlayerLevel", 80);

    public override void Initial(UIPlayerInfoWindow window, string topPath)
    {
        base.Initial(window, topPath);
        nameText = GetComponent<Text>(NameText);
        levelText = GetComponent<Text>(LevelText);
        professionText = GetComponent<Text>(ProfessionText);
        numberText = GetComponent<Text>(NumberText);
        equipGradeText = GetComponent<Text>(EquipGradeText);
        hpNumText = GetComponent<Text>(HPNumText);
        hpProgress = GetComponent<Slider>(HPProgress);
        expNumText = GetComponent<Text>(EXPNumText);
        expProgress = GetComponent<Slider>(EXPProgress);

        scrollRect = GetComponent<LoopVerticalScrollRect>(ScrollRect);
        scrollRect.Init(RefreshScroll,5,ScrollContent);
    }

    public void RefreshBaseAttr()
    {
        scrollRect.RefreshAllCells();
    }

    private void RefreshScroll(string root,int index)
    {
        string namePath = root.ToNodePath(PropNameText);
        string valuePath = root.ToNodePath(PropNumText);

        Text nameText = GetComponent<Text>(namePath);
        Text valueText = GetComponent<Text>(valuePath);

        string name;
        string num;

        var controller = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
        controller.GetBasicAttr(index,out name,out num);

        nameText.text = name;
        valueText.text = num;
    }

    public void Show()
    {
        _rootTran.gameObject.SetActive(true);
        scrollRect.RefillAllCells();
    }

    public void Hide()
    {
        _rootTran.gameObject.SetActive(false);
    }

    public void SetConstInfo(CellHeroReceiveProperty prop)
    {
        nameText.text = prop.NameAlias;
//        var = ViSealedDB<VisualHeroStruct>.Data(prop.Info);
        professionText.text = prop.Info.Value.HeroClass.Value.ToString();
        numberText.text = Player.Instance.ID.ToString();
    }

    public void RefreshLevel(CellHeroReceiveProperty prop)
    {
        levelText.text = prop.Level.Value.ToString();
    }

    public void UpdateEquipGrade()
    {
        equipGradeText.text = "开发中";
    }

    public void UpdateExp(float cur,float max)
    {
        if (CellHero.LocalHero.Property.Level >= MaxValue_PlayerLv)
        {
            expNumText.text = I18NManager.Instance.GetWord("tips_80");
            expProgress.value = 1;
        }
        else
        {
            expNumText.text = string.Format("{0}/{1}", cur, max);
            expProgress.value = cur / max;
        }
    }

    public void UpdateHp(float curHp, float maxHp, float rate)
    {
        hpNumText.text = string.Format("{0}/{1}", curHp, maxHp);
        hpProgress.value = rate;
    }

    public void Refresh()
    {
        
    }
}