using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UIWindow<WindowT, ControllerT> : IUIWindow
    where WindowT : UIWindow<WindowT, ControllerT>, new()
    where ControllerT : UIController<ControllerT, WindowT>, new()
{
    protected WeakReference _mResGo;
    private int _mDepth = 0;
    private UIWinManifest _mWinManifest = null;
    private UIWinPanelCtrl _mWinPanelCtrl = null;
    protected Transform _mWinTran = null;
    protected ControllerT _mController;
    private UIBlock _uiBlock = null;
    public bool IsBackBlur { get; set; }
    public UIWindow()
    {
        _mWinManifest = new UIWinManifest();
        _mWinPanelCtrl = new UIWinPanelCtrl();
    }
    /// <summary>
    /// 初始化界面以及其他变量
    /// </summary>
    protected virtual void Initial()
    {
        _UIAdapt();
    }
    public string GetWindowRootName()
    {
        return _mWinTran.name;
    }
    private void _UIAdapt()
    {
        if(_mWinTran != null)
        {
            UIWindowAdapter uiAdapter = _mWinTran.GetComponent<UIWindowAdapter>();
            if (uiAdapter != null)
            {
                if(UIManager.Instance.IsIPhoneX)
                {
                    if (uiAdapter.enabled == false)
                        uiAdapter.enabled = true;
                    uiAdapter.AdjustPostion();
                }
                uiAdapter.enabled = false; 
            }  
        }
    }
    public virtual void Show()
    {
        if (_mWinTran == null) return;
        _mWinTran.gameObject.layer = UIDefine.UI_VISIBLE_LAYER;
        _mWinPanelCtrl.SetCanvasEnable(true);
        if (_uiBlock != null)
            _uiBlock.isBlock = false;
        _mWinManifest.OnApplicationPauseChange = ((pauseStatus) => { this.OnApplicationPause(pauseStatus); });
        _mWinManifest.OnApplicationFocusChange = ((pauseStatus) => { this.OnApplicationFocus(pauseStatus); });
    }
    public virtual void Hide()
    {
        if (_mWinTran == null) return;
        _mWinTran.gameObject.layer = UIDefine.UI_INVISIBLE_LAYER;
        if (_uiBlock != null)
            _uiBlock.isBlock = true;
        _mWinManifest.OnApplicationPauseChange = null;
        _mWinManifest.OnApplicationFocusChange = null;
    }
    public virtual void Destroy()
    {
        _mResGo = null;
        _mWinManifest.Destroy();
        _mWinManifest = null;
        _mWinPanelCtrl.Destroy();
        _mWinPanelCtrl = null;
        _mController = null;
    }
    public void Dispose()
    {
        Destroy();
    }
    public void OnWinResLoaded(GameObject go, ControllerT controller)
    {
        if (go == null) return;
        _mController = controller;
        _mResGo = new WeakReference(go);
        _mWinManifest.Initial(_mResGo);
        _mWinPanelCtrl.Initial(_mResGo);
        _mWinTran = (_mResGo.Target as GameObject).transform;
        _uiBlock = _mWinTran.gameObject.AddComponent<UIBlock>();
        _uiBlock.isBlock = true;
        UIManager.Instance.SetWindowRoot(_mWinTran, controller.GetLayerType());
        Initial();
    }
    public void SetDistance(int val)
    {
        _mWinPanelCtrl.SetDistance(val);
    }
    /// <summary>
    /// 弱引用的关系，判断当前资源是否已经被删除
    /// </summary>
    /// <returns></returns>
    public bool IsResAvaliable()
    {
        if (_mResGo == null) return false;
        GameObject go = _mResGo.Target as GameObject;
        return (_mResGo != null && go != null);
    }
    public Transform FindTransform(string path)
    {
        Transform tran = null;
        if (IsResAvaliable())
        {
            tran = _mWinManifest.FindTransform(path);
        }
        else
        {
            ViDebuger.Error("UIWindow find Transform failed, because the resourc is not avaliable");
        }
        return tran;
    }
    public T GetComponent<T>(string path) where T:Component
    {
        T component = null;
        if (IsResAvaliable())
        {
            component = _mWinManifest.GetComponent<T>(path);
        }
        else
        {
            ViDebuger.Error("UIWindow find Transform failed, because the resourc is not avaliable");
        }
        return component;
    }
    public T[] GetComponents<T>(string path) where T : Component
    {
        T[] components = null;
        if (IsResAvaliable())
        {
            components = _mWinManifest.GetComponents<T>(path);
        }
        else
        {
            ViDebuger.Error("UIWindow find Transform failed, because the resourc is not avaliable");
        }
        return components;
    }
    public void SetSibling(int index)
    {
        _mWinTran.SetSiblingIndex(index);
    }
    public void StartNextFrameTask(Action action)
    {
        this._mWinManifest.StartNextFrameTask(action);
    }
    protected virtual void OnApplicationPause(bool pauseStatus)
    {
    }
    protected virtual void OnApplicationFocus(bool hasFocus)
    { }
    public Vector2 GetPanelSize()
    {
        return this._mWinManifest.GetPanelSize();
    }
}