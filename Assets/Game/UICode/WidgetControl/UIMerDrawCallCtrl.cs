using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMerDrawCallCtrl : UIDrawCallCtrl
{
    public string TAG = "";
    protected override void Awake()
    {
        base.Awake();
        if (Application.isEditor)
        {//防止挂錯脚本，該脚本衹能挂接到ExUISprite之上
            ExUISprite exSp = this.GetComponent<ExUISprite>();
            if (exSp == null)
                GameObject.DestroyImmediate(this);
        }
    }
    public void MergeTo(Material target)
    {
        _mRenderQ = target.renderQueue;
        this.RenderMaterial = target;
    }
}
