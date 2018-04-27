using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffectManager : UIResManagerBase<GameObject>
{
    private static UIEffectManager _handler = null;
    public static UIEffectManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new UIEffectManager();
            return _handler;
        }
    }
    public GameObject Load(string path, UICallback.UIResLoad_CB callback)
    {
        string root = ResourcePath.UI_EFFECT_PATH;
        this.RegisterCallBack(path, callback);
        return this.Load(path, root) as GameObject;
    }
}
