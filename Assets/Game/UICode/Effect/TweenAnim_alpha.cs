using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/TweenAnim_alpha")]
public class TweenAnim_alpha : UITweener
{

    [Range(0f, 1f)]
    public float from = 1f;
    [Range(0f, 1f)]
    public float to = 1f;

    bool mCached = false;
//    UIRect mRect;
    Material mMat;
    //    SpriteRenderer mSr;
    Graphic _graphic;
    SuperTextMesh _superText;

    [System.Obsolete("Use 'value' instead")]
    public float alpha { get { return this.value; } set { this.value = value; } }

    void Cache()
    {
        mCached = true;
        //mRect = GetComponent<UIRect>();
        //mSr = GetComponent<SpriteRenderer>();

        //if (mRect == null && mSr == null)
        //{
        //    Renderer ren = GetComponent<Renderer>();
        //    if (ren != null) mMat = ren.material;
        //    if (mMat == null) mRect = GetComponentInChildren<UIRect>();
        //}
        _graphic = this.GetComponent<Graphic>();
        if (_graphic != null)
            mMat = _graphic.material;
        _superText = this.GetComponentInChildren<SuperTextMesh>();
    }

    /// <summary>
    /// Tween's current value.
    /// </summary>

    public float value
    {
        get
        {
            if (!mCached) Cache();
            //if (mRect != null) return mRect.alpha;
            //if (mSr != null) return mSr.color.a;

            if(_graphic != null) return _graphic.color.a;
            return mMat != null ? mMat.color.a : 1f;
        }
        set
        {
            if (!mCached) Cache();
            if (_graphic != null)
            {
                Color c = _graphic.color;
                c.a = value;
                _graphic.color = c;
            }
            else if (mMat != null)
            {
                Color c = mMat.color;
                c.a = value;
                mMat.color = c;
            }
            else if (_superText != null)
            {
                _superText.Alpha = value;
            }
        }
    }

    /// <summary>
    /// Tween the value.
    /// </summary>

    protected override void OnUpdate(float factor, bool isFinished) { value = Mathf.Lerp(from, to, factor); }

    /// <summary>
    /// Start the tweening operation.
    /// </summary>

    static public TweenAlpha Begin(GameObject go, float duration, float alpha)
    {
        TweenAlpha comp = UITweener.Begin<TweenAlpha>(go, duration);
        comp.from = comp.value;
        comp.to = alpha;

        if (duration <= 0f)
        {
            comp.Sample(1f, true);
            comp.enabled = false;
        }
        return comp;
    }

    public override void SetStartToCurrentValue() { from = value; }
    public override void SetEndToCurrentValue() { to = value; }
}
