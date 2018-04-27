using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UITweenWindow<WindowT, ControllerT> : UIWindow<WindowT, ControllerT>
    where WindowT : UITweenWindow<WindowT, ControllerT>, new()
    where ControllerT : UITweenController<ControllerT, WindowT>, new()
{
    public enum WindowTweenType
    {
        TweenScale,
        TweenAlpha
    }

    public static int aaa = 0;
    private WindowTweenType _tweenTyp = WindowTweenType.TweenScale;
    private Action _onTweenWindowCallback;
    private float _duration  = 1f;
    protected void SetTween(WindowTweenType wt, System.Action callback, float duration = 1f)
    {
        _tweenTyp = wt;
        _onTweenWindowCallback = callback;
        _duration = duration;
    }
    public override void Show()
    {
        if (_mWinTran == null) return;
        _mWinTran.gameObject.layer = UIDefine.UI_VISIBLE_LAYER;
        _TweenWindow(_tweenTyp, _onTweenWindowCallback, true, _duration);
    }
    public override void Hide()
    {
        //if (_uiBlock != null) 访问权限不够
        //    _uiBlock.isBlock = true;
        _TweenWindow(_tweenTyp, _onTweenWindowCallback, false, _duration);
    }
    public bool IsTweening()
    {
        return _isOnTweening;
    }
    #region Window Scale&Alpha 
    private bool _isOnTweening;
    /// <summary>
    /// 一定要在Show或者Hide之前调用，不支持Component，Component直接调用UIUtility TweenScale或者TweenAlpha
    /// </summary>
    private void _TweenWindow(WindowTweenType wt, Action callback, bool playForward, float duration = 1f)
    {
        UIBlock uiblock = _mWinTran.gameObject.GetComponent<UIBlock>();
        if (uiblock != null)
            uiblock.isBlock = true;
        _isOnTweening = true;
        if (wt == WindowTweenType.TweenScale)
        {
            TweenScaleWindow(callback, playForward, duration);
        }
        else
        {
            TweenAlphaWindow(callback, playForward, duration);
        }
    }
    private void TweenAlphaWindow(Action callback, bool playForward, float duration)
    {
        this._onTweenWindowCallback = callback;
        MaskableGraphic[] uiTextures = _mWinTran.GetComponentsInChildren<MaskableGraphic>();
        Color color = new Color(0, 0, 0, 0);
        foreach (MaskableGraphic t in uiTextures)
        {
            Color End = playForward ? new Color(t.color.r, t.color.g, t.color.b, t.color.a) : color;
            if (playForward)
                t.color = color;
            t.DOColor(End, duration);
        }
        Tween tn = DOTween.To(() => _winScale, s => _winScale = s, 1f, duration);
        if (playForward)
            tn.OnComplete(_OnTweenWindowOpenComplete);
        else
            tn.OnComplete(_OnTweenWindowCloseComplete);
    }
    private void TweenScaleWindow(Action callback, bool playForward, float duration)
    {
        this._onTweenWindowCallback = callback;
        float start = playForward ? 0 : 1;
        float end = playForward ? 1 : 0;
        Canvas canvas = _mWinTran.GetComponent<Canvas>();
        if (canvas == null)
        {
            UIUtility.TweenScale(_mWinTran, _mWinTran.localScale * start, _mWinTran.localScale * end, duration, () =>
            {
                if (playForward)
                    _OnTweenWindowOpenComplete();
                else
                    _OnTweenWindowCloseComplete();
            }, playForward);
        }
        else
        {
            Vector3 vEndScale = Vector3.one, vEnd = Vector3.zero,vStartScale = Vector3.one;
            foreach (Transform r in _mWinTran)
            {
                vStartScale = playForward ? Vector3.zero : r.localScale * 1;
                vEndScale = playForward ? r.localScale * 1 : Vector3.zero;
                vEnd = playForward ? new Vector3(r.localPosition.x, r.localPosition.y, r.localPosition.z) : Vector3.zero;
                if (r.gameObject.activeSelf)
                {
                    r.localScale = vStartScale;
                }
                    
                if (playForward)
                    r.localPosition = Vector3.zero;
                r.DOLocalMove(vEnd, duration);
                r.DOScale(vEndScale, duration);
            }

            Tween t = DOTween.To(() => _winScale, s => _winScale = s, 1f, duration);
            if (playForward)
                t.OnComplete(_OnTweenWindowOpenComplete);
            else
                t.OnComplete(_OnTweenWindowCloseComplete);
        }
    }
    private float _winScale = 0;
    
    void _OnTweenWindowOpenComplete()
    {
        _isOnTweening = false;
        //if (_uiBlock != null)
        //    _uiBlock.isBlock = false;
        if (_onTweenWindowCallback != null)
        {
            _onTweenWindowCallback();
        }
        _onTweenWindowCallback = null;
        base.Show();
    }
    void _OnTweenWindowCloseComplete()
    {
        _isOnTweening = false;
        if (_onTweenWindowCallback != null)
        {
            _onTweenWindowCallback();
        }
        _onTweenWindowCallback = null;
        base.Hide();
        if (HideTween != null)
            HideTween();

    }
    public System.Action HideTween;
    bool isDelayDestroy = false;
    public override void Destroy()
    {
        if (_isOnTweening)
        {
            isDelayDestroy = true;
            return;
        }
        else
        {
            base.Destroy();
        }   
    }
    public new void Dispose()
    {
        if (_isOnTweening)
        {
            isDelayDestroy = true;
            return;
        }
        else
        {
            base.Destroy();
        }
    }
    #endregion
}


