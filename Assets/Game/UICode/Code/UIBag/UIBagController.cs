using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBagController : UIController<UIBagController, UIBagWin>
{
    public override void Show()
    {
        base.Show();
    }


    public override void Hide()
    {
        base.Hide();
    }

    public override void Destroy()
    {
        base.Destroy();

    }

    /// <summary>
    ///整理
    /// </summary>
    public void SortBagItem()
    {
       _mWinHandler.CallBackClickArrer();
    }
    /// <summary>
    /// 刷新一个格子
    /// </summary>
    /// <param name="solt"></param>
    public void CountChange()
    {
        _mWinHandler.RushAllFromZero();
    }

    public void RushWearEquip()
    {
        _mWinHandler.RushWearEquip();
    }

}
