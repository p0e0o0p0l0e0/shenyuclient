using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UIControllerBase : IUIController
{
    protected string _mWinName = "";
    public bool IsShow { get; set; }
    protected bool _mIsLoadResource = false;
    protected UIControllerDefine.LayerType _mLayerType = UIControllerDefine.LayerType.NORMAL;
    public UICallback.VV_CB OnShowAction;//瞬时回掉，回掉后去除代理
    public UICallback.VV_CB OnHideAction;//瞬时回掉，回掉后去除代理
    public UIRES_ACTION CurResAction
    { get
        {
            return _curResAction;
        }
    }
    private UIRES_ACTION _curResAction = UIRES_ACTION.UNLOAD;
    public string WinName
    {
        get
        {
            return _mWinName;
        }
        set
        {
            _mWinName = value;
        }
    }
    //public bool IsLoadResource
    //{
    //    get
    //    {
    //        return _mIsLoadResource;
    //    }
    //}
    public UIControllerDefine.LayerType GetLayerType()
    {
        return _mLayerType;
    }
    public virtual void OnWinResLoaded(GameObject go)
    {
        //_mIsLoadResource = true;
        _curResAction = UIRES_ACTION.LOADED;
    }
    protected virtual void Initial()
    {
        //_mIsLoadResource = false;
        _curResAction = UIRES_ACTION.UNLOAD;
    }
    public virtual void OnWillShow()
    {
        _curResAction = UIRES_ACTION.WILLSHOW;
    }
    public virtual void OnWillHide()
    {
        _curResAction = UIRES_ACTION.WILLHIDE;
    }
    public virtual void Show()
    {
        IsShow = true;
        _curResAction = UIRES_ACTION.SHOW;
        if (OnShowAction != null)
        {
            OnShowAction();
            OnShowAction = null;
        }            
    }
    public virtual void Hide()
    {

        IsShow = false;
        _curResAction = UIRES_ACTION.HIDE;
        if (OnHideAction != null)
        {
            OnHideAction();
            OnHideAction = null;
        }
            
    }
    public virtual void OnLoading()
    {
        _curResAction = UIRES_ACTION.LOADING;
    }
    public virtual void OnWillDestroy()
    {
        _curResAction = UIRES_ACTION.WILLDESTROY;
    }
    public virtual void OnWillLoad()
    {
        _curResAction = UIRES_ACTION.WILLLOADING;
    }
    /// <summary>
    /// 必要的时候系统外部强制调用该接口，用于清除界面的数据，可以在此函数中初始化数据
    /// </summary>
    public virtual void ClearData()
    { }
    public virtual void Destroy()
    {
        //_mIsLoadResource = false;
        _mWinName = "";
        _curResAction = UIRES_ACTION.UNLOAD;
    }
    public virtual void Dispose()
    {
    }
    public virtual void SetSibling(int index)
    { }
    public virtual void SetDistance(int val)
    { }
}
