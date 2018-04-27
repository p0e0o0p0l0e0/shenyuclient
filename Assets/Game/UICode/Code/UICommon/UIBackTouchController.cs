using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBackTouchController : MonoBehaviour {

    public static UIBackTouchController Instance { get; set; }
    public Action<PointerEventData> TouchDownListener = null;
    public Action<PointerEventData> TouchUpListener = null;
    public Action<PointerEventData> TouchHoldingListener = null;
    private UIPointerListener _pointer = null;

	// Use this for initialization
	void Start () {
        _pointer = this.GetComponentInChildren<UIPointerListener>();
        if (_pointer != null)
        {
            _pointer.OnTouchDownCallBack = _OnTouchDown;
            _pointer.OnTouchUpCallBack = _OnTouchUp;
            _pointer.OnHoldingCallBack = _OnHolding;
        }
        RectTransform rectTran = this.GetComponent<RectTransform>();
        if (rectTran != null)
        {
            rectTran.SetInsetAndSizeFromParentEdge( RectTransform.Edge.Left, 0, Screen.width);
            rectTran.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, Screen.height);
        }
        Instance = this;
    }
    private void _OnTouchDown(int val, object obj)
    {
        if (TouchDownListener != null)
            TouchDownListener((PointerEventData)obj);
        //ViDebuger.Record("UIBackTouchController._OnTouchDown");
    }
    private void _OnTouchUp(int val, object obj)
    {
        if (TouchUpListener != null)
            TouchUpListener((PointerEventData)obj);
        //ViDebuger.Record("UIBackTouchController._OnTouchUp");
    }
    private void _OnHolding(int val, object obj)
    {
        if (TouchHoldingListener != null)
            TouchHoldingListener((PointerEventData)obj);
        //ViDebuger.Record("UIBackTouchController._OnHolding");

    }
}
