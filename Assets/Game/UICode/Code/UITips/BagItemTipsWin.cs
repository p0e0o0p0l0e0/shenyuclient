using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagItemTipsWin : UISubWindow<UITipsWindow, UITipsController>
{
    private const string QualityBg = "/Top/EquipQualityBg";
    private const string Quality = "/Top/EquipQuality";
    private const string NameText = "/Top/ItemNameText";
    private const string NumText = "/Top/ItemText/ItemNumText";
    private const string DesText = "/Top/ItemDescText";
    private const string UseBtn= "/Top/UseButton";

    private ExUISprite backQuality;
    private ExUITexture quality;
    private Text nameText;
    private Text numText;
    private Text desText;
    private ExUIButton useBtn;

    public override void Initial(UITipsWindow window, UITipsController controller, string topPath = "")
    {
        base.Initial(window, controller, topPath);
        backQuality = this.GetComponent<ExUISprite>((QualityBg));
        quality = this.GetComponent<ExUITexture>((Quality));
        nameText = this.GetComponent<Text>((NameText));
        numText = this.GetComponent<Text>((NumText));
        desText = this.GetComponent<Text>((DesText));
        useBtn = this.GetComponent<ExUIButton>(UseBtn);
        if(useBtn.NotNull())
        useBtn.onClickEx = (val, o) =>
        {
            if (CellHero.LocalHero.Property.HP < CellHero.LocalHero.Property.HPMax0)
                PlayerServerInvoker.UseBagItem(Player.Instance, controller.bagPos);
            UIManager.Instance.Hide(UIControllerDefine.WIN_Tips);
        };
    }

    public override void Refresh()
    {
        ItemStruct item = _mController.GetItem();
        VisualItemStruct vItem;
        vItem = ViSealedDB<VisualItemStruct>.Data(item.ID);
        backQuality.SetExUISprite(_mController.GetQualityBackName());
        quality.LoadIcon(vItem.Icon, (ItemQualityEnum)_mController.GetItem().Quality.Data.ItemQualityEnum.Value, ExUITexture_Extend.IconStyle.RECT);
        nameText.SetTextContent(I18NManager.Instance.GetWord(item.Name));
        desText.SetTextContent(vItem.Desc);
        numText.SetTextContent(UIBagDataMgr.GetInstance.GetAllCountByID(item.ID));
        useBtn.SetActive(_mController.ItemCanUse());
    }
}

public class NormalTipsWin : BagItemTipsWin
{
    public override void Initial(UITipsWindow window, UITipsController controller, string topPath = "")
    {
        base.Initial(window, controller, topPath);
    }

    public override void Show()
    {
        base.Show();
    }
}
