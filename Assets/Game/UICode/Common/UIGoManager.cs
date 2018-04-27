using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGoManager : UIResManagerBase<GameObject>
{
    private static UIGoManager _handler = null;
    public static new UIGoManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new UIGoManager();
            return _handler;
        }
    }

    public object Load(string path, UICallback.UIResLoad_CB callback)
    {
        this.RegisterCallBack(path, callback);
        return base.Load(path, ResourcePath.UI_PATH);
    }
    protected override void _OnResLoaded(string resName, object go)
    {
        base._OnResLoaded(resName, go);
    }
    public override void UnLoad(string path)
    {
        base.UnLoad(path);
    }
}
