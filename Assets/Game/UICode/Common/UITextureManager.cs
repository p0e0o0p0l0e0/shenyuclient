using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextureManager : UIResManagerBase<Texture>
{
    private static UITextureManager _handler = null;
    public static new UITextureManager Instance
    {
        get
        {
            if (_handler == null)
            {
                _handler = new UITextureManager();
                _handler.IsAsynCallBack = false;
            }
                
            return _handler;
        }
    }
    public Texture Load(string path, UICallback.UIResLoad_CB callback)
    {
        
        int index = path.LastIndexOf('/') ;
        string root = ResourcePath.TEXTURE_PATH;
        if (index >= 0)
        {
            root += "/" + path.Substring(0, index); 
            path = path.Substring(index + 1, path.Length - index - 1);
        }
        this.RegisterCallBack(path, callback);
        return this.Load(path, root) as Texture;
    }
    protected override void _OnResLoaded(string resName, object go)
    {
        base._OnResLoaded(resName, go);
    }
}
