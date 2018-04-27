using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UIManagerStrategy :  object
{
    public static ViConstValue<uint> UI_CHECK_COUNT = new ViConstValue<uint>("UI_CHECK_COUNT", 2);

    public class UIResElement
    {
        public string ResName { get; set; }
        public float LastUseTime { get; set; }
    }
    private static UIManagerStrategy _handler = null;

    public static UIManagerStrategy Instance
    {
        get
        {
            if (_handler == null)
                _handler = new UIManagerStrategy();
            return _handler;
        }
    }
    private Dictionary<string, UIResElement> _elementList = new Dictionary<string, UIResElement>();

    public void OnDestroyWin(string winName)
    {
        UIResElement element = null;
        if (_elementList.TryGetValue(winName, out element))
        {
            element.LastUseTime = Time.realtimeSinceStartup;
        }
        else
        {
            _elementList.Add(winName, new UIResElement() { ResName = winName, LastUseTime = Time.realtimeSinceStartup});
        }
        CheckStrategy();
    }
    public void CheckStrategy()
    {
        if (UI_CHECK_COUNT < _elementList.Count)
        {
            List<UIResElement> elemnts = new List<UIResElement>(_elementList.Values);
            elemnts.Sort((element1, element2) => {
                if (element1.LastUseTime < element2.LastUseTime)
                    return -1;
                else if (element1.LastUseTime > element2.LastUseTime)
                    return 1;
                else return 0;
            });
            for (int i = 0; i < UI_CHECK_COUNT; ++i)
            {
                UIResElement curEle = elemnts[i];
                if (!UIManager.Instance.IsShow(curEle.ResName))
                {
                    _elementList.Remove(curEle.ResName);
                    UIManager.Instance.DestroyController(curEle.ResName);
                    UIGoManager.Instance.UnLoad(curEle.ResName);
                    ViDebuger.Record("---will real destory resource " + curEle.ResName + ", lastusetime=" + curEle.LastUseTime);
                }

            }
            Resources.UnloadUnusedAssets();
        }
    }
    public void DestoryAll()
    {
        ViDebuger.Record("--ui destroy all");
        foreach (KeyValuePair<string, UIResElement> kvp in _elementList)
        {
            UIManager.Instance.DestroyController(kvp.Key);
            UIGoManager.Instance.UnLoad(kvp.Value.ResName);            
        }
        _elementList.Clear();
        Resources.UnloadUnusedAssets();
    }
    public void OnRecoveryWin(string winName)
    {
        UIResElement element = null;
        if (_elementList.TryGetValue(winName, out element))
        {
            _elementList.Remove(winName);
        }
    }
}
