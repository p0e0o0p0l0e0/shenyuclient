using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class UICanvasGroupTween : UITweenInterface
{
    [Range(0f, 1f)]
    public float From = 0f;
    [Range(0f, 1f)]
    public float To = 1f;
    
    public static UICanvasGroupTween Get(GameObject go, bool reset = true)
    {
        return UITweenInterface.Get<UICanvasGroupTween>(go, reset);
    }

    public static UICanvasGroupTween Begin(GameObject go, float from, float to)
    {
        UICanvasGroupTween tween = UITweenInterface.Get<UICanvasGroupTween>(go, false);
        tween.From = from;
        tween.To = to;
        tween.ResetToStart();
        return tween;
    }

    public override void Play(bool forward)
    {
        float start = forward ? From : To;
        _dest = forward ? To : From;
        _tweener.StopAt(start);
        _tweener.Accelerate = Accelerate;
        _tweener.MaxSpeed = MaxSpeed;
        _tweener.MinSpeed = MinSpeed;
        _tweener.TimeScale = NormalTimeScale;
        //
        if (Duration > 0f)
        {
            _tweener.SetSample(ViMathDefine.Abs(To - From), Duration);
        }
        //
        base.Play(true);
    }


    protected override void OnUpdate(float deltaTime)
    {
        if (_tweener.Update(_dest, deltaTime))
        {
            SetAlpha(_tweener.Value);
        }
        else
        {
            SetAlpha(_tweener.Value);
            OnComplete();
        }
    }

    public override void ResetToStart()
    {
        SetAlpha(From);
    }

    void SetAlpha(float value)
    {
        if (!mCached) Cache();
        if ((canvasGroup != null&& value>=0.1)|| value==0)
            canvasGroup.alpha = value;
    }

    void Cache()
    {
        canvasGroup= transform.GetComponent<CanvasGroup>();
        mCached = true;
    }

    float _dest;
    ViValueInterpolation _tweener = new ViValueInterpolation();
    CanvasGroup canvasGroup;
    bool mCached = false;
    Material mMat;
    SpriteRenderer mSr;
}
