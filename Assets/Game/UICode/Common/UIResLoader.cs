using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum UILoadState
{
    NONE,
    LOADING,
    LOADED,
    WAIT_UNLOAD,
}
public class UIResLoader<T> : IDisposable where T : UnityEngine.Object
{
    private string _resName = "";
    private string _loadResPath = ResourcePath.UI_PATH;
    private UILoadState _mLoadState = UILoadState.NONE;
    public UICallback.UIResLoad_CB OnResLoaded;
    private T _mHoldResGo = null;
    ResourceRequest mResLoader = new ResourceRequest();

    public string ResourcName
    {
        get {
            return _resName;
        }
    }
 
    private GameObject _resObj = null;
    public GameObject Resource
    {
        get
        {
            if (_mLoadState == UILoadState.LOADED)
                return _resObj;
            else
                return null;
        }
    }
    public UILoadState CurrentState
    {
        get {
            return _mLoadState;
        }
    }
    /// <summary>
    /// 释放资源
    /// </summary>
    public void Clear()
    {
        mResLoader.End();
        _mLoadState = UILoadState.NONE;
    }
    /// <summary>
    /// 彻底删除对资源的引用
    /// </summary>
    public void Dispose()
    {
        if (_mLoadState == UILoadState.LOADED)
        {
            Clear();
            GameObject.DestroyImmediate(_mHoldResGo);
            _mHoldResGo = null;
        }
        else if(_mLoadState == UILoadState.LOADING)
            _mLoadState = UILoadState.WAIT_UNLOAD;

    }
    public UIResLoader(string name, string loadPath)
    {
        _resName = name;
        _loadResPath = loadPath;
    }
    public void Load(UICallback.UIResLoad_CB callBack)
    {
        if (_mLoadState != UILoadState.NONE)
        {
            ViDebuger.Warning("UIResLoader is Busy, then don't Start");
            return;
        }
        OnResLoaded = callBack;

        mResLoader.Start(_loadResPath + "/" + _resName, _resName, _OnResourceLoaded);
        //ViDebuger.Record("---->load:"+ _loadResPath + "/" + _resName);
        _mLoadState = UILoadState.LOADING;
    }
    void _OnResourceLoaded(UnityEngine.Object pAsset)
    {
        if (_mLoadState == UILoadState.LOADING)
        {
            T asset = pAsset as T;
            if (asset == null)
            {
                ViDebuger.Warning("UIResLoader._OnResourceLoaded pAsset is null");
                return;
            }
            if (_mHoldResGo != null)
            {
                ViDebuger.Error("UIResLoader._OnResourceLoaded error, should loaded after dispose the resource");
            }
            _mHoldResGo = GameObject.Instantiate(asset);
            _mLoadState = UILoadState.LOADED;
            if (OnResLoaded != null)
                OnResLoaded(_resName, _mHoldResGo);
        }
        else if (_mLoadState == UILoadState.WAIT_UNLOAD)//防止资源下载完毕回来后，上层已经删除了此资源
        {
            mResLoader.End();           
        }

    }
}
