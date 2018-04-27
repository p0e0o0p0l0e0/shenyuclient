using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIWinManifest :  IDisposable
{
    private UIManifest _mManifest = null;
    public Action<bool> OnApplicationPauseChange
    {
        set
        {
            _mManifest.OnApplicationPauseChange = value;
        }
    }
    public Action<bool> OnApplicationFocusChange
    {
        set
        {
            _mManifest.OnApplicationFocusChange = value;
        }
    }

    /// <summary>
    /// 传递进来就是一个弱引用，表示该类拿到都是对象的一个弱类型,要注意_mManifest可能伴随外部资源释放为null
    /// </summary>
    /// <param name="weakGo"></param>
    public void Initial(WeakReference weakGo)
    {
        if (weakGo != null && (weakGo.Target as GameObject) != null)
        {
            GameObject go = weakGo.Target as GameObject;
            _mManifest = go.GetComponentInChildren<UIManifest>();
            if (_mManifest != null)
                _mManifest.ResolutionModity();
        }
        else
        {
            ViDebuger.Error("UIWinManifest.Initial failed, target is null or target is not alive");
        }      
    }
    public bool IsAvaliable()
    {
        return (_mManifest != null);
    }
    public void Destroy()
    {
        
        _mManifest.OnApplicationFocusChange = null;
        _mManifest.OnApplicationPauseChange = null;
        _mManifest = null;
    }
    public void Dispose()
    {
        Destroy();
    }
    public Transform FindTransform(string path)
    {
        Transform tran = null;
        if (_mManifest != null)
        {
            tran = _mManifest.FindTransform(path);
        }
        else
        {
            ViDebuger.Error("UIWinManifest.FindTransform error");
        }
        return tran;
    }
    public T GetComponent<T>(string path) where T:Component
    {
        T component = null;
        if (_mManifest != null)
        {
            component = _mManifest.GetComponent<T>(path);
        }
        else
        {
            ViDebuger.Error("UIWinManifest.FindTransform error");
        }
        return component;
    }
    public T[] GetComponents<T>(string path) where T : Component
    {
        T[] components = null;
        if (_mManifest != null)
        {
            components = _mManifest.GetComponents<T>(path);
        }
        else
        {
            ViDebuger.Error("UIWinManifest.FindTransform error");
        }
        return components;
    }
    public void StartNextFrameTask(Action action)
    {
        _mManifest.StartCoroutine(_NextFrameCoroutine(action));
    }
    private IEnumerator _NextFrameCoroutine(Action action)
    {
        yield return null;
        action();
    }
    public Vector2 GetPanelSize()
    {
        return this._mManifest.GetPanelSize();
    }
}
