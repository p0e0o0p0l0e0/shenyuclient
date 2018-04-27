using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController<ControllerT, WindowT>: UIControllerBase
    where WindowT : UIWindow<WindowT, ControllerT>,new()
    where ControllerT: UIController<ControllerT, WindowT>, new()
{

    #region register controler and create window
    public static UIControllerBase CreateController(string winName)
    {
        UIControllerBase controller = new ControllerT();
        controller.WinName = winName;
        return controller;
    }
    #endregion

    protected WindowT _mWinHandler;

    public UIController()
    {
        CreateWindow();
        Initial();
    }
    /// <summary>
    /// 在此函数的继承函数中初始化_mWinName以及创建窗体句柄_mWinHandler
    /// </summary>
    protected virtual void CreateWindow()
    {
        _mWinHandler = new WindowT();
    }
    public override void Show()
    {
        base.Show();
        if (_mWinHandler != null)
            _mWinHandler.Show();
    }
    public override void Hide()
    {
        base.Hide();
        if (_mWinHandler != null)
            _mWinHandler.Hide();
    }

    public override void Destroy()
    {
        if (this.IsShow)
        {
            this.Hide();
            //ViDebuger.Error(this.WinName + "Destroy, but not hide first, this is almost not happened");
        }
            
        _mWinHandler.Destroy();
        _mWinHandler = null;
    }
    public override void Dispose()
    {

    }
    public override void OnWinResLoaded(GameObject go)
    {
        base.OnWinResLoaded(go);
        if (_mWinHandler != null)
            _mWinHandler.OnWinResLoaded(go, (ControllerT)this);
    }
    public override void SetDistance(int val)
    {
        if (_mWinHandler != null)
            _mWinHandler.SetDistance(val);
    }
    public override void SetSibling(int index)
    {
        if (_mWinHandler != null)
            _mWinHandler.SetSibling(index);
    }
    public bool IsBackBlur()
    {
        if (_mWinHandler != null)
            return _mWinHandler.IsBackBlur;
        return false;
    }
    public void SetBackBlur(bool isBlur)
    {
        if (_mWinHandler != null)
            _mWinHandler.IsBackBlur = isBlur;
    }
}
