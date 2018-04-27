using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoleResurrectionController : UIController<UIRoleResurrectionController, UIRoleResurrectionWindow>
{
    protected override void Initial()
    {
        base.Initial();
        this._mLayerType = UIControllerDefine.LayerType.NORMAL_TOP;
    }

    public void OnResurrectionBtnClick()
    {
        CellHeroServerInvoker.REQ_Revive(CellHero.LocalHero);
    }
}
