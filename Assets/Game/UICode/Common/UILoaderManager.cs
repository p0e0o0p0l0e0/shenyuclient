using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoaderManager<T> where T : UnityEngine.Object
{
    const string TAG = "[UILoaderManager]";
    private static UILoaderManager<T> _hander = null;
    public UICallback.UIResLoad_CB onResLoaded;
    public static UILoaderManager<T> Instance
    {
        get
        {
            if (_hander == null)
                _hander = new UILoaderManager<T>();
            return _hander;
        }
    }
    private Dictionary<string, UIResLoader<T>> _resLoadProperty = new Dictionary<string, UIResLoader<T>>();
    private UILoaderManager() { }

    /// <summary>
    /// 下载资源，因为有可能是异步过程，可能存在返回null情况
    /// </summary>
    /// <param name="resourceName"></param>
    /// <returns></returns>
    public GameObject LoadResource(string resourceName, string pathRoot)
    {
        UIResLoader<T> resLoader = null;
        if (_resLoadProperty.TryGetValue(resourceName, out resLoader))
        {
             return resLoader.Resource;
        }
        else
        {
            resLoader = new UIResLoader<T>(resourceName, pathRoot);
            resLoader.Load(OnResourceLoaded);
            _resLoadProperty.Add(resourceName, resLoader);
        }
        return null;
    }
    public void DeleteResource(string resourceName)
    {
        UIResLoader<T> resLoader = null;
        if (_resLoadProperty.TryGetValue(resourceName, out resLoader))
        {
            resLoader.Dispose();
            _resLoadProperty.Remove(resourceName);
            resLoader = null;
        }
        else
        {
            ViDebuger.Warning(TAG+ "DeleteResource: the "+resourceName+" not exist");
        }
    }
    private void OnResourceLoaded(string resName, object go)
    {
        if (onResLoaded != null)
            onResLoaded(resName, go);
    }
}
