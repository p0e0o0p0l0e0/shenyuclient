using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoleResurrectionWindow : UIWindow<UIRoleResurrectionWindow, UIRoleResurrectionController>
{
    private const string ResurrectionBtn = "UIResurrectionWindow/ResurrectionBtn";

    private ExUIButton resurrectionBtn = null;
    protected override void Initial()
    {
        base.Initial();
        resurrectionBtn = this.GetComponent<ExUIButton>(ResurrectionBtn);
        resurrectionBtn.onClick.AddListener(OnResurrectionBtnClick);
    }

    public override void Show()
    {
        base.Show();
    }

    private void OnResurrectionBtnClick()
    {
        _mController.OnResurrectionBtnClick();
    }
}
