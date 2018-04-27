using UnityEngine;

public class UITipsWindow : UIWindow<UITipsWindow, UITipsController>
{
    #region ui control name define
    private const string CloseBtn = "UITipsWindow/click";
    private const string ShowEquipRoot = "UITipsWindow/EquipTip/EquipTip1";
    private const string WearEquipRoot = "UITipsWindow/EquipTip/EquipTip2";
    private const string BagItemRoot = "UITipsWindow/ItemTip";
    private const string NormalItemRoot = "UITipsWindow/ItemPathTip";

    #endregion

    private ExUIButton closeBtn;

    private UISubWindow<UITipsWindow, UITipsController> curTips;
    private UISubWindow<UITipsWindow, UITipsController> curTips2;
    private EquipTipsWin showEquipTip;
    private EquipTipsWin wearEquipTip;
    private BagItemTipsWin bagItemTip;
    private NormalTipsWin normalItemTip;
    
    protected override void Initial()
    {
        closeBtn = GetComponent<ExUIButton>(CloseBtn);
        closeBtn.onClickEx = (a, o) =>
        {
            UIManager.Instance.Hide(UIControllerDefine.WIN_Tips);
        };

        showEquipTip = new EquipTipsWin();
        showEquipTip.SetWear(ShowEquipRoot, false);
        showEquipTip.Initial(this,_mController,ShowEquipRoot);
        showEquipTip.Hide();

        wearEquipTip = new EquipTipsWin();
        wearEquipTip.SetWear(WearEquipRoot , true);
        wearEquipTip.Initial(this,_mController,WearEquipRoot);
        wearEquipTip.Hide();

        bagItemTip = new BagItemTipsWin();
        bagItemTip.Initial(this,_mController, BagItemRoot);
        bagItemTip.Hide();

        normalItemTip = new NormalTipsWin();
        normalItemTip.Initial(this,_mController, NormalItemRoot);
        normalItemTip.Hide();
    }

    public override void Show()
    {
        _mController.ShowTips();
        base.Show();
    }

    public override void Hide()
    {
        if(curTips != null)
        curTips.Hide();
        curTips = null;
        if (curTips2.NotNull())
        {
            curTips2.Hide();
            curTips2 = null;
        }
        base.Hide();
    }

    public void ShowBagItem()
    {
        curTips = bagItemTip;
        bagItemTip.Show();
    }

    public void ShowNormalItem()
    {
        curTips = normalItemTip;
        normalItemTip.Show();
    }

    public void ShowEquip()
    {
        if (_mController.IsEquipWearing)
        {
            curTips = wearEquipTip;
            showEquipTip.Hide();
            wearEquipTip.SetItemStruct(_mController.GetItem());
            wearEquipTip.Show();
        }
        else
        {
            if (_mController.ShowEquipCompare)
            {
                wearEquipTip.SetItemStruct(_mController.GetCompareEquip());
                wearEquipTip.Show();
                curTips2 = wearEquipTip;
            }
            else
            {
                wearEquipTip.Hide();
            }
            curTips = showEquipTip;
            showEquipTip.SetItemStruct(_mController.GetItem());
            showEquipTip.Show();
        }
    }
}
