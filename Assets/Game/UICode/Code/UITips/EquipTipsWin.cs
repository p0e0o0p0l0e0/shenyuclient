using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipTipsWin : UISubWindow<UITipsWindow, UITipsController>
{
    #region ui control name define
    private const string BackQuality = "/Top/EquipQualityBg";
    private const string Rank = "/Top/EquipRankSprite";
    private const string Quality = "/Top/EquipQuality";
    private const string NameText = "/Top/EquipNameText";
    private const string LvAndTypeText = "/Top/EquipLVandTypeText";
    private const string WearTipText = "/Top/EquipWearTipText";
    private const string RankNumText = "/Top/EquipRankText/EquipRankNumText";
    private const string GradeNumText = "/Top/EquipGradeText/EquipGradeNumText";
    private const string ActionButton = "/DischargeButton";

    private const string ScrollRect = "/PropList";
    private const string ScrollContent = "/PropList/Content";

    #endregion

    private ExUISprite backQuality;
    private ExUISprite rank;
    private ExUITexture quality;
    private Text nameText;
    private Text lvText;
    private Text wearTipText;
    private Text rankNumText;
    private Text gradeNumText;
    private ExUIButton actionButton;

    private LoopVerticalScrollRect scrollRect;
    private const string PropNameText = "PropNameText";
    private const string PropNumText = "PropNumText";
    private const string PropDiffText = "PropChangeNumText";
    private const string PropJew = "JewelBg/Jewel";

    private string root;
    private bool isWearing;

    public void SetWear(string root,bool wear)
    {
        this.root = "";
        isWearing = wear;
    }

    public override void Initial(UITipsWindow window, UITipsController controller, string topPath = "")
    {
        base.Initial(window, controller, topPath);
        backQuality = GetComponent<ExUISprite>(root+BackQuality);
        rank = GetComponent<ExUISprite>(root + Rank);
        quality = GetComponent<ExUITexture>(root + Quality);
        nameText = GetComponent<Text>(root + NameText);
        lvText = GetComponent<Text>(root + LvAndTypeText);
        wearTipText = GetComponent<Text>(root + WearTipText);
        rankNumText = GetComponent<Text>(root + RankNumText);
        gradeNumText = GetComponent<Text>(root + GradeNumText);

        actionButton = GetComponent<ExUIButton>(root + ActionButton);
        actionButton.onClickEx = (val, o) =>
        {
            if (isWearing)
            {
                PlayerServerInvoker.DeEquipItem(Player.Instance, controller.bagPos);
            }
            else
            {
                PlayerServerInvoker.UseBagItem(Player.Instance,controller.bagPos);
            }
            UIManager.Instance.Hide(UIControllerDefine.WIN_Tips);
        };

        scrollRect = window.GetComponent<LoopVerticalScrollRect>(_topPath + ScrollRect);
        scrollRect.Init(RefreshScroll, PropTotalCount, root + ScrollContent);
    }

    private void RefreshScroll(string root, int index)
    {
        if (item.Null())
            return;
        GameObject go = _mWindow.FindTransform(_topPath + root).gameObject;
        //临时代码  等后续更多属性类型添加
        if (index >= BasicPropCount)
        {
            go.SetActive(false);
            return;
        }

        string namePath = _topPath+root.ToNodePath(PropNameText);
        string valuePath = _topPath + root.ToNodePath(PropNumText);
        string diffPath = _topPath + root.ToNodePath(PropDiffText);

        Text nameText = _mWindow.GetComponent<Text>(namePath);
        Text valueText = _mWindow.GetComponent<Text>(valuePath);
        Text diffText = _mWindow.GetComponent<Text>(diffPath);
        if (index < BasicPropCount)
        {
            try
            {
                var props = item.Value.Data.Value.Array;
                if (index < props.Length && !props[index].Value.InValid())
                {
                    go.SetActive(true);
                    AttributeTypeStruct attri = props[index].Type.PData;
                    nameText.SetTextContent(attri.Name);
                    switch(attri.DisplayFomat.Data.ID)
                    {
                        case 0:
                            valueText.SetTextContent((props[index].Value ).ToString());
                            break;
                        case 1:
                            valueText.SetTextContent((props[index].Value / 100).ToString());
                            break;
                        case 2:
                            valueText.SetTextContent((props[index].Value / 10000).ToString());
                            break;
                    }
                    string diffValue = _mController.GetCompareValue(props[index].Type, props[index].Value);
                    diffText.SetTextContent(diffValue);
                }
                else
                    go.SetActive(false);
            }
            catch (Exception e)
            {
                ViDebuger.Error("装备配置错误  id "+item.ID);
                Console.WriteLine(e);
            }
        }
    }

    public void SetItemStruct(ItemStruct item)
    {
        this.item = item;
        vItem = ViSealedDB<VisualItemStruct>.Data(item.ID);
    }

    public override void Refresh()
    {
        backQuality.SetExUISprite(_mController.GetQualityBackName());
        rank.SetExUISprite(_mController.GetRankSpName());
        rankNumText.SetTextContent(vItem.PinJie);
        quality.LoadIcon(vItem.Icon, (ItemQualityEnum)item.Quality.Data.ItemQualityEnum.Value, ExUITexture_Extend.IconStyle.RECT);
        nameText.SetTextContent(I18NManager.Instance.GetWord(item.Name));
        string lv = item.Level + " " + vItem.EquipSlotName;
        if (CellHero.LocalHero.Property.Level >= item.Level)
            lv = lv.ToUnityColor(XLExtend.ColorWhite);
        else
            lv = lv.ToUnityColor(XLExtend.ColorRed);
        lvText.SetTextContent(lv);
        scrollRect.RefreshAllCells();
        actionButton.SetActive(_mController.IsEquipWearing || _mController.isItemInBag);
    }

    private ItemStruct item;
    private VisualItemStruct vItem;

    private const int BasicPropCount = 5;
    private const int PropTotalCount = 20;
}
