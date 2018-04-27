using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIFocusHUD : UIPlayerHUD
{
    public override void Initial(UIFightWindow window, string topPath)
    {
        base.Initial(window, topPath);
    }
    public override void UpdateName(string name)
    {
        _checkInfoFill();
        base.UpdateName(name);
    }
    public override void UpdateLevel(string level)
    {
        _checkInfoFill();
        base.UpdateLevel(level);
    }
    public override void UpdateIcon(IconData icon)
    {
        _checkInfoFill();
        base.UpdateIcon(icon);
    }
    public override void UpdatePlayerHp(float val)
    {
        _checkInfoFill();
        base.UpdatePlayerHp(val);
    }
    public override void UpdatePlayerBoom(float val)
    {
        _checkInfoFill();
        base.UpdatePlayerBoom(val);
    }

    public override void SetBoomVisible(bool isVisible)
    {
        _checkInfoFill();
        base.SetBoomVisible(isVisible);
    }
    public override void Dispose()
    {
        base.Dispose();
    }
    public override void Close()
    {
        base.Close();
    }
    private void _checkInfoFill()
    {
        if (_isClose)
            this.Open();
    }
}
