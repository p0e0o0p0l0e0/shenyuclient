using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIResManagerBase<T> : IDisposable where T : UnityEngine.Object, new()
{
    public class ResNode
    {
        public string ResName { get; set; }
        public object Go { get; set; }
        public UICallback.UIResLoad_CB CallBack { get; set; }
        public UIResManagerBase<T> ResManager { get; set; }
        public int FrameCount { get; set; }
    }
    public bool IsAllLoaded
    {
        get
        {
            return _isLoadedAll();
        }
    }
    private static T _handler = null;
    public static T Instance
    {
        get
        {
            if (_handler == null)
            {
                _handler = new T();
            }

            return _handler;
        }
    }
    protected Dictionary<string, object> _mRes = new Dictionary<string, object>();
    protected Dictionary<string, List<UICallback.UIResLoad_CB>> _registerCallBack = new Dictionary<string, List<UICallback.UIResLoad_CB>>();
    protected bool IsAsynCallBack = true;
    protected static List<ResNode> _nodeList = new List<ResNode>();//资源回调列表
    protected static Dictionary<string, object> _releaseRes = new Dictionary<string, object>();
    public UIResManagerBase()
    {
        UILoaderManager<T>.Instance.onResLoaded += _OnResLoaded;
    }
    public void RegisterCallBack(string resName, UICallback.UIResLoad_CB callback)
    {
        if (!_registerCallBack.ContainsKey(resName))
        {
            _registerCallBack[resName] = new List<UICallback.UIResLoad_CB>();
        }
        _registerCallBack[resName].Add(callback);
    }
    protected void DoCallBack(string resName, object go)
    {
        if (_registerCallBack.ContainsKey(resName))
        {
            List<UICallback.UIResLoad_CB>  callBackList = _registerCallBack[resName];
            for (int i = 0; i < callBackList.Count; ++i)
            {
                if (callBackList[i] != null)
                    callBackList[i](resName, go);
            }
            _registerCallBack.Remove(resName);
        }
    }
    protected virtual void _OnResLoaded(string resName, object go)
    {
        if (_mRes.ContainsKey(resName))
        {
            if (IsAsynCallBack)
            {
                ResNode node = new ResNode();
                node.ResName = resName;
                node.Go = go;
                node.ResManager = this;
                node.FrameCount = Time.frameCount;
                _mRes[resName] = go;
                _nodeList.Insert(0, node);
                //ViDebuger.Record(resName+"------------>loaded, framecount="+Time.frameCount);
            }
            else
            {
                _mRes[resName] = go;
                DoCallBack(resName, go);
            }
        }
    }
    protected virtual object Load(string path, string resPath)
    {
        object restObj = null;
        if (!_mRes.TryGetValue(path, out restObj))
        {
            if (_releaseRes.ContainsKey(path))//在删除队列里面
            {
                _mRes[path] = _releaseRes[path];
                if (_mRes[path] != null)//判断是否正在加载中
                {
                    DoCallBack(path, _mRes[path]);
                }
                _releaseRes.Remove(path);//从删除队列里面删除
            }
            else
            {
                _mRes.Add(path, null);
                UILoaderManager<T>.Instance.LoadResource(path, resPath);
                //ViDebuger.Record(path + "------------>load, framecount=" + Time.frameCount);
            }
        }
        else
        {
            if (_mRes[path] != null)//判断是否正在加载中，如果为null说明还在加载当中
            {
                DoCallBack(path, _mRes[path]);
            }
        }
        return restObj;
    }
    public virtual void UnLoad(string path)
    {
        //object resObj = null;
        //if (_mRes.TryGetValue(path, out resObj))
        //{
        //    _mRes.Remove(path);
        //    UILoaderManager<T>.Instance.DeleteResource(path);
        //}
        object resObj = null;
        if (_mRes.TryGetValue(path, out resObj))
        {
            //对象在加载中或者已经加载都将其放到删除队列里面
            if (!_releaseRes.ContainsKey(path))
                _releaseRes.Add(path, _mRes[path]);
            _mRes.Remove(path);
        }

    }
    public virtual void Dispose()
    {
        foreach (KeyValuePair<string, object> kvp in _mRes)
        {
            string path = kvp.Key;
            UILoaderManager<T>.Instance.DeleteResource(path);
        }
        _mRes.Clear();
        UILoaderManager<T>.Instance.onResLoaded -= _OnResLoaded;
    }
    public virtual void Destroy()
    {
        foreach (KeyValuePair<string, object> kvp in _mRes)
        {
            string path = kvp.Key;
            UILoaderManager<T>.Instance.DeleteResource(path);
        }

        _mRes.Clear();
    }
    protected virtual bool _isLoadedAll()
    {
        bool ret = true;
        foreach (KeyValuePair<string, object> kvp in _mRes)
        {
            if (kvp.Value == null)
            {
                ret = false;
                break;
            }
        }
        return ret;
    }
    public virtual object GetRes(string path)
    {
        object resObj = null;
        if (!_mRes.TryGetValue(path, out resObj))
        {
            ViDebuger.Record("UIResManagerBase.GetRes "+path+" failed");
            return null;
        }
        return resObj;
    }
    public static void Update()
    {
        _CheckCallBack();
        _CheckReleaseRes();
    }
    private static void _CheckCallBack()
    {
        if (_nodeList != null && _nodeList.Count > 0)
        {
            for (int i = _nodeList.Count - 1; i >= 0; --i)
            {
                ResNode node = _nodeList[i];
                if (node.FrameCount != Time.frameCount)
                {
                    //ViDebuger.Record(node.ResName + "------------>_CheckCallBack, framecount=" + Time.frameCount);
                    node.ResManager.DoCallBack(node.ResName, node.Go);
                    _nodeList.Remove(node);
                }
            }
        }
    }
    private static void _CheckReleaseRes()
    {
        //object resObj = null;
        foreach(KeyValuePair<string, object> kvp in _releaseRes)
        {
            //_mRes.Remove(path);
            UILoaderManager<T>.Instance.DeleteResource(kvp.Key);
        }
        _releaseRes.Clear();
    }
}
