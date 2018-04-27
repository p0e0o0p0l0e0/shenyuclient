using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoleLevelUpController: UIController<UIRoleLevelUpController, UIRoleLevelUpWindow>
{
    protected override void Initial()
    {
        base.Initial();
        this._mLayerType = UIControllerDefine.LayerType.NORMAL_TOP;
    }
    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

}
