using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIWinPanelCtrl : IDisposable
{
    private UIPanelCtrl _panelCtrl = null;
    private Canvas _canvas = null;

    public void Initial(WeakReference weakGo)
    {
        if (weakGo != null && (weakGo.Target as GameObject) != null)
        {
            GameObject go = weakGo.Target as GameObject;
            _canvas = go.GetComponentInChildren<Canvas>(true);
            if (_canvas != null)
                UIManager.Instance.SetCanvasCamera(_canvas);          
        }
        else
        {
            ViDebuger.Record("UIWinManifest.Initial failed, target is null or target is not alive");
        }
    }
    public void Destroy()
    {
        _canvas = null;
        _panelCtrl = null;
    }
    public void Dispose()
    {
        Destroy();
    }
    public void SetCanvasEnable(bool isEnable)
    {
        if (_canvas != null)
            _canvas.enabled = isEnable;
    }
    public void SetDistance(int val)
    {
        //if (_canvas != null)
        //    _canvas.planeDistance = val;
        if (_canvas != null)
            _canvas.sortingOrder = -val;
    }
}
