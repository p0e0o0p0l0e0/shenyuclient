
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager
{

    private static UIManager _hander = null;
    public static UIManager Instance
    {
        get
        {
            if (_hander == null)
            {
                _hander = new UIManager();
            }
            return _hander;
        }
    }

    private GameObject _UIRootGo = null;//UI总根结点
    private Camera _UICamera = null;
    private Transform _UITopRoot = null;//UI TOP层节点根对象
    private static Dictionary<string, UIControllerBase> _mControllers = new Dictionary<string, UIControllerBase>();//已经加载的controller，目前资源与controller并存
    private List<UIControllerBase> _mWinStack = new List<UIControllerBase>();//用于界面的显示栈，这个栈用来界面层叠,在最TOP层的不参与栈排序
    private Dictionary<string, UICallback.UICTRL_CB> _mReigsterCallBack = new Dictionary<string, UICallback.UICTRL_CB>();
    private string _soloWin = "";//单独显示的界面，独占界面
    private const int PanelBin = 50;//最高层与普通层分割节点
    private Dictionary<string, UIPanelConfigStruct> _panelConfig = new Dictionary<string, UIPanelConfigStruct>();
    private GameObject _preLoadCommonWindow = null;
    /// <summary>
    /// ui状态字典
    /// </summary>
    private Dictionary<string, bool> _windowStates = new Dictionary<string, bool>();
    public Camera UICamera { get { return _UICamera; } }
    private bool _isIPhoneX = false;
    public bool IsIPhoneX
    {
        get{
#if UNITY_EDITOR && IPHONEX
            return true;
#else
            return _isIPhoneX;              
#endif

        }
    }
    private UIManager()
    {}
    public void Inital()
    {

        _UIRootGo = GameObject.Find("UIRoot");
        if (_UIRootGo == null)
            ViDebuger.Record("UIManager inital Failed: not find the UIRoot GameObject");
        else
        {
            Transform cameraTran = _UIRootGo.transform.Find("UICamera");
            _UICamera = cameraTran.GetComponent<Camera>();
            GameObject.DontDestroyOnLoad(_UIRootGo);
            _UITopRoot = _UIRootGo.transform.Find("TopRoot");
        }
        _ResgisterController();
        _PreLoadCommonPanel();
        Debug.Log("Is iphoneX? =" + SystemInfo.deviceModel + "," + SystemInfo.deviceType);
        _isIPhoneX = (SystemInfo.deviceModel.ToLower() == "iphone x");
    }
    /// <summary>
    /// 注册所有界面
    /// </summary>
    private void _ResgisterController()
    {
        UIControllerRegister.Register(_mReigsterCallBack);
    }
    public void PreLoadController()
    {
        //_PreLoadController(UIControllerDefine.WIN_Login);
    }
    private void _PreLoadCommonPanel()
    {
        UIControllerBase controller = _CreateController(UIControllerDefine.WIN_PreloadCommon, _mReigsterCallBack[UIControllerDefine.WIN_PreloadCommon]);
        _preLoadCommonWindow = this._UITopRoot.Find(UIControllerDefine.WIN_PreloadCommon).gameObject;
        controller.OnWinResLoaded(_preLoadCommonWindow);
        controller.Show();
        UICommonController commCtrl = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_PreloadCommon);
        commCtrl.SetWindowType( UICommonController.WinType.LOADING);
    }
    public void DestroyPreloadCommonWindow()
    {
        if (_preLoadCommonWindow != null)
            GameObject.DestroyImmediate(_preLoadCommonWindow);
    }
    /// <summary>
    /// 直接打开界面
    /// </summary>
    /// <param name="winName"></param>
    public UIControllerBase Show(string winName, UICallback.VV_CB openCallback = null, bool isPopTop = false)
    {
        UIControllerBase controller = null;
        bool ret = _TryLoad(winName, out controller);
        if (controller == null) return null;
        controller.OnShowAction += openCallback;
        if (ret)//如果已经加载过了
        {
            if (_mWinStack.Contains(controller))//如果界面已经处于显示状态，则显示到栈顶，并pop出其他界面
            {
                if (isPopTop)
                    _PopWindowTo(winName);
                if (controller.OnShowAction != null)
                    controller.OnShowAction();
            }
            else//不在显示栈，但是已经加载了
            {
                try
                {
                    _PushWinAndShow(controller);
                }
                catch (Exception ex)
                {
                    ViDebuger.Error("UIManager show error ex=" + ex.ToString());
                }
            }
        }
        return controller;
    }
    public UIControllerBase HideWithTween(string winName, UICallback.VV_CB openCallback = null, bool isDestroy = true)
    {
        UIControllerBase controller = null;
        if (_mControllers.TryGetValue(winName, out controller))
        {
            controller.OnHideAction += ()=>
            {
                if (openCallback != null)
                    openCallback();
                _PopWinAndHide(winName, isDestroy);
                
            };
            controller.Hide();
        }
        else
        {
            if (Application.isEditor)
                ViDebuger.Warning("you must resigster controller firstly[" + winName + "]");
        };
        return controller;
    }
    public UIControllerBase Hide(string winName, UICallback.VV_CB openCallback = null)
    {
        UIControllerBase controller = null;
        bool isDestroy = _IsHideDestroy(winName);
        if (_mControllers.TryGetValue(winName, out controller))
        {
            controller.OnHideAction += openCallback;
            _PopWinAndHide(winName, isDestroy);
        }
        else
        {
            if (Application.isEditor)
                ViDebuger.Warning("you must resigster controller firstly["+ winName+"]");
        }
        return controller;
    }
    private bool _IsHideDestroy(string winName)
    {
        bool ret = true;
        UIPanelConfigStruct configInfo = null;
        _CheckCachPanelConfig();
        if (_panelConfig.TryGetValue(winName, out configInfo))
        {
            ret = (configInfo.IsHideDestrory == 1);
        }
        return ret;
    }
    private void _CheckCachPanelConfig()
    {
        UIPanelConfigStruct configInfo = null;
        if (_panelConfig.Count == 0)
        {
            List<UIPanelConfigStruct> panelConfig = ViSealedDB<UIPanelConfigStruct>.Array;
            for (int i = 0; i < panelConfig.Count; ++i)
            {
                configInfo = panelConfig[i];
                _panelConfig.Add(configInfo.Name, configInfo);
            }
        }
    }
    /// <summary>
    /// 用于缓存界面时用
    /// </summary>
    /// <param name="winName"></param>
    private void _PreLoadController(string winName)
    {
        UIControllerBase controller = null;
        if (!_mControllers.ContainsKey(winName))
        {
            _TryLoad(winName, out controller);
        }
        else
        {
            ViDebuger.Warning("UIManager.preLoadControllerRes "+winName+" already exist");
        }

    }
    private bool _TryLoad(string winName, out UIControllerBase controller)
    {
        bool ret = false;
        controller = null;
        UICallback.UICTRL_CB callBack = null;
        if (_mReigsterCallBack.TryGetValue(winName, out callBack))
        {
            if (_mControllers.TryGetValue(winName, out controller))
            {
                if (controller.CurResAction == UIRES_ACTION.UNLOAD)
                {
                    UIGoManager.Instance.Load(winName, (string name, object go) => { _OnWinResLoaded(name, go); });
                    controller.OnLoading();
                }
                else
                    ret = true;
            }
            else
            {
                controller = _CreateController(winName, callBack);
                UIGoManager.Instance.Load(winName, (string name, object go) => { _OnWinResLoaded(name, go); });
                controller.OnLoading();
            }
        }
        else
        {
            if (Application.isEditor)
                ViDebuger.Warning("you must resigster controller firstly");
        }
        return ret;
    }
    private UIControllerBase _CreateController(string winName, UICallback.UICTRL_CB callBack)
    {
        UIControllerBase controller = null;
        if (string.IsNullOrEmpty(winName) || callBack == null)
        {
            ViDebuger.Error("UIManager._CreateController failed");
            return null;
        }
        controller = callBack(winName);
        _mControllers.Add(winName, controller);
        return controller;
    }
    private void _PopWindowTo(string winName, bool isDestroy = true)
    {
        for (int i = _mWinStack.Count - 1; i >= 0; --i)
        {
            if (_mWinStack[i].WinName != winName)
            {
                _PopWinAndHide(winName, isDestroy);
            }
            else
            {
                break;
            }
        }
    }
    /// <summary>
    /// 界面资源载入处理
    /// </summary>
    /// <param name="resName"></param>
    /// <param name="go"></param>
    private void _OnWinResLoaded(string resName, object go)
    {
        UIControllerBase controller = null;
        if (_mControllers.TryGetValue(resName, out controller))
        {
            if (controller.CurResAction == UIRES_ACTION.WILLDESTROY)//加载过程中可能被释放了
            {
                this.DestroyController(controller);
            }
            else
            {
                GameObject gameObject = (GameObject)go;
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localScale = Vector3.one;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.name = resName;
                gameObject.layer = UIDefine.UI_INVISIBLE_LAYER;
                controller.OnWinResLoaded(gameObject);
                if (controller.GetLayerType() != UIControllerDefine.LayerType.TOP)//如果显示在最高层的界面，不参与到现实栈里面
                {
                    if (controller.CurResAction == UIRES_ACTION.WILLHIDE)//如果在加载当中已经被隐藏，那么直接调用hide
                    {
                        controller.Hide();
                        //虽然被隐藏，但是还是要设置默认计算好的distance，防止当前界面的隐藏是由于独占界面的隐藏(不弹出其他界面),
                        //这样独占界面消失后，该界面显示出来，但是没有设置默认distance，层级出错
                        int winDistance = this._GetCurWinDistance(controller);
                        controller.SetDistance(winDistance);
                    }
                    else
                        _PushWinAndShow(controller);
                }
                else
                {
                    int distance = _UITopRoot.childCount + 1;
                    controller.SetDistance(distance);
                    _ShowController(controller);
                }
            }
        }
    }
    private void _PopWinAndHide(string name, bool isDestroy = true, bool isUseStrategy = false)
    {
        UIControllerBase controller = null;
        _mControllers.TryGetValue(name, out controller);
        if(controller != null)
        {
            //在显示栈或者在缓存当中
            if (_mWinStack.Contains(controller))
            {
                _mWinStack.Remove(controller);
                _HideController(controller);
            }
            else//可能正在加载当中
            {
                if (controller.CurResAction == UIRES_ACTION.LOADING)
                {
                    controller.OnWillHide();
                    this._CheckSoloWin(name, false);//如果当前界面已经被solo界面记录了状态，则改变该状态
                }
            }

            if (isDestroy)
            {
                if (controller.CurResAction == UIRES_ACTION.LOADING)
                    controller.OnWillDestroy();
                else
                {
                    if (isUseStrategy)
                        UIManagerStrategy.Instance.OnDestroyWin(controller.WinName);
                    else
                    {
                        DestroyController(controller);
                        UIGoManager.Instance.UnLoad(controller.WinName);
                    }                      
                }
            }
        }
    }
    /// <summary>
    /// 仅仅隐藏，不去关心显示栈的变化
    /// </summary>
    /// <param name="controller"></param>
    private void _HideController(UIControllerBase controller)
    {
        controller.OnWillHide();
        controller.Hide();
    }
    /// <summary>
    /// 仅仅显示，不去关心显示栈的变化
    /// </summary>
    /// <param name="controller"></param>
    private void _ShowController(UIControllerBase controller)
    {
        controller.OnWillShow();
        controller.Show();
        UIManagerStrategy.Instance.OnRecoveryWin(controller.WinName);
    }
    public void DestroyController(UIControllerBase controller)
    {
        string winName = controller.WinName;
        controller.OnWillDestroy();
        controller.Destroy();
        _mControllers.Remove(winName);
        controller = null;
    }
    public void DestroyController(string winName)
    {
        UIControllerBase controller = null;
        if (_mControllers.TryGetValue(winName, out controller))
        {
            DestroyController(controller);
        }
    }
    public void DestroyAllController()
    {
        for(int i = _mWinStack.Count - 1; i >= 0; --i)
            _PopWinAndHide(_mWinStack[i].WinName, true, false);
        UIManagerStrategy.Instance.DestoryAll();
    }
    public void OnChageSpace()
    {
        UIManagerStrategy.Instance.DestoryAll();
    }
    public void SetCanvasCamera(Canvas canvas)
    {
        canvas.worldCamera = _UICamera;
    }
    public void SetWindowRoot(Transform winTran, UIControllerDefine.LayerType layerType)
    {
        if (layerType == UIControllerDefine.LayerType.TOP)
        {
            winTran.SetParent(_UITopRoot);
        }else
            winTran.SetParent(_UIRootGo.transform);
        winTran.localPosition = Vector3.zero;
        winTran.localScale = Vector3.one;
        winTran.localRotation = Quaternion.identity;
        //_UITopRoot.SetAsLastSibling();
    }
    public ControllerT GetController<ControllerT, WindowT>(string winName) 
        where WindowT : UIWindow<WindowT, ControllerT>, new()
        where ControllerT : UIController<ControllerT, WindowT>, new()
    {
        UIControllerBase controller = null;
        if (!_mControllers.TryGetValue(winName, out controller))
        {
            //Debug.LogWarning("---------->UIManager.GetController failed");
            return null;
        }
        return (ControllerT)controller;
    }
    public bool IsShow(string winName)
    {
        UIControllerBase controller = null;
        if (_mControllers.TryGetValue(winName, out controller))
        {
            if (_mWinStack.Contains(controller)) return true;
        }
        
        return false;
    }
    private void _PushWinAndShow(UIControllerBase controller)
    {
        bool ret = this._CheckSoloWin(controller.WinName, true);
        if (ret)
        {
            if (!_mWinStack.Contains(controller))
                _mWinStack.Add(controller);
            _ShowController(controller);
        }
        //由于独占界面显示中，当前界面不会显示，但是要设置计算好的distance，这样独占界面关闭后，被打开的界面才能正确显示层次
        int winDistance = _GetCurWinDistance(controller);
        controller.SetDistance(winDistance);
    }
    private int _GetCurWinDistance(UIControllerBase controller)
    {
        int winCount = PanelBin * 2;
        if (controller.GetLayerType() == UIControllerDefine.LayerType.NORMAL)
        {
            winCount = this._mWinStack.Count;
            winCount = PanelBin * 2 - winCount - 2;//-2是一个经验值，有些界面内的Z值可能超过界面，如若将来出现异常可以增加此值
        }
        else if (controller.GetLayerType() == UIControllerDefine.LayerType.NORMAL_TOP)
        {
            winCount = PanelBin;
        }
        return winCount;
    }
    /// <summary>
    /// 隐藏其他界面
    /// </summary>
    /// <param name="windowName"></param>
    public void HideWindowsKeepThis(string windowName)
    {
        _soloWin = windowName;
        foreach (KeyValuePair<string, UIControllerBase> kvp in _mControllers)
        {
            if (kvp.Key.Equals(windowName))
                continue;
            UIControllerBase controller = kvp.Value;      
            //如果当前界面已经加载，并且在显示状态， 或者当前界面处于loading加载过程当中      
            if (controller.IsShow || (controller.CurResAction == UIRES_ACTION.LOADING))
                _windowStates[kvp.Key] = true;
            else if (controller.CurResAction >= UIRES_ACTION.LOADED)
                _windowStates[kvp.Key] = false;
            if(controller.IsShow)
                this._HideController(controller);//仅仅隐藏其他界面，而不删除
        }       
    }
    /// <summary>
    /// 恢复界面
    /// </summary>
    public void RecoverWindows()
    {
        UIControllerBase controller = null;
        _soloWin = "";
        foreach (KeyValuePair<string,bool> windowOldState in _windowStates)
        {
            if (_mControllers.TryGetValue(windowOldState.Key, out controller) && windowOldState.Value)
            {
                this._ShowController(controller);
            }
        }
        _windowStates.Clear();       
    }



    /// <summary>
    /// 将要show或者hide时调用此方法
    /// </summary>
    /// <param name="winName"></param>
    /// <param name="isShow"></param>
    /// <returns></returns>
    private bool _CheckSoloWin(string winName, bool isShow)
    {
        bool ret = true;
        if (!string.IsNullOrEmpty(_soloWin))
        {
            _windowStates[winName] = isShow;
            ret = false;
        }
        return ret;
    }
}
