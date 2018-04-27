using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIWindowComponent<WindowT, ControllerT> : IDisposable 
    where WindowT : UIWindow<WindowT, ControllerT>, new()
    where ControllerT : UIController<ControllerT, WindowT>, new()
{

    protected WindowT _mWindow = null;
    protected WeakReference _windowRef = null;
    protected string _topPath = "";
    protected Transform _rootTran = null;

    public virtual void Initial(WindowT window, string topPath)
    {
        _windowRef = new WeakReference(window);
        _mWindow = _windowRef.Target as WindowT;
        _topPath = topPath;
        _rootTran = window.FindTransform(topPath);
    }
    public virtual void Dispose()
    {
        _topPath = "";
        _windowRef = null;
    }
    public Transform FindTransform(string path)
    {
        if (path == this._rootTran.name)
            return this._rootTran;
        if (path.IndexOf('/') != 0)
            path += "/";
        return _mWindow.FindTransform(_topPath + path);
    }
    public T GetComponent<T>(string path) where T : Component
    {
        if (path == this._rootTran.name)
            return _mWindow.GetComponent<T>(path);
        if (path.IndexOf('/') != 0)
            path = "/" + path;
        return _mWindow.GetComponent<T>(_topPath + path);
    }
    public T[] GetComponents<T>(string path) where T : Component
    {
        if (path == this._rootTran.name)
            return _mWindow.GetComponents<T>(path);
        if (path.IndexOf('/') != 0)
            path = "/" + path;
        return _mWindow.GetComponents<T>(_topPath + path);
    }
}

public abstract class UISubWindow<WindowT, ControllerT> : UIWindowComponent<WindowT, ControllerT>
    where WindowT : UIWindow<WindowT, ControllerT>, new()
    where ControllerT : UIController<ControllerT, WindowT>, new()
{
    protected WindowT _mWindow = null;
    protected ControllerT _mController;
    protected WeakReference _windowRef = null;
    protected string _rootPath = "";
    protected GameObject _rootObj = null;

    /// <summary>
    /// 需要打开和关闭的窗口 topPath传节点名
    /// </summary>
    public virtual void Initial(WindowT window,ControllerT controller, string topPath="")
    {
        base.Initial(window, topPath);
        _windowRef = new WeakReference(window);
        _mWindow = _windowRef.Target as WindowT;
        _mController = controller;
        _rootPath = topPath;
        if(topPath.Usable())
            _rootObj = window.FindTransform(topPath).gameObject;
    }

    public virtual void Show()
    {
        if(_rootObj.NotNull())
            _rootObj.SetActive(true);
        Refresh();
    }

    public virtual void Hide()
    {
        if (_rootObj.NotNull())
            _rootObj.SetActive(false);
    }

    public abstract void Refresh();

    public override void Dispose()
    {
        _rootPath = "";
        _windowRef = null;
        _mController = null;
        base.Dispose();
    }
}
