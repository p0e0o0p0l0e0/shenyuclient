using DG.Tweening;
using UnityEngine;

public class UITweenHelper
{
    public bool playing
    {
        get
        {
            if (tweener.NotNull())
                return tweener.IsPlaying();
            return false;
        }
    }

    public UITweenHelper(Transform tar,Vector3 endValue,float dur)
    {
        target = tar;
        startValue = target.localPosition;
        SetEndValue(endValue);
        SetDuration(dur);
    }

    public void LocalMove(TweenCallback callBack, bool forward = true)
    {
        XLColorDebug.LogUI("move-----");
        if (forward)
            tweener = target.DOLocalMove(endValue, duration);
        else
            tweener = target.DOLocalMove(startValue, duration);
        this.callBack = callBack;
        tweener.OnComplete(() =>
        {
            XLColorDebug.LogUI("callback");
            if (this.callBack.NotNull())
                this.callBack();
        });
        tweener.SetAutoKill(false);
    }

    public void Stop(Vector3? pos = null)
    {
        if(tweener.NotNull())
            tweener.Kill();
        if (pos.NotNull())
            target.localPosition = pos.Value;
    }

    public void SetEndValue(Vector3 endValue)
    {
        this.endValue = endValue;
    }

    public void SetDuration(float time)
    {
        duration = time;
    }

    private Transform target;
    private Tweener tweener;
    private TweenCallback callBack;

    private Vector3 startValue;
    private Vector3 endValue;
    private float duration;
}
