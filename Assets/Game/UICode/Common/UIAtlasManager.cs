using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIAtlasManager: UIResManagerBase<GameObject>
{
    private static UIAtlasManager _handler = null;
    public static new UIAtlasManager Instance
    {
        get {
            if (_handler == null)
                _handler = new UIAtlasManager();
            return _handler;
        }
    }
    private Dictionary<string, string> _mAtlasShader = new Dictionary<string, string>();
    public void PreloadAtlas()
    {
        string[][] atlas = UIAtlasDefine.AtlasArray;
        for (int i = 0; i < atlas.Length; ++i)
        {
            this.Load(atlas[i][0], ResourcePath.UI_ATLAS_PATH);
            _mAtlasShader.Add(atlas[i][0], atlas[i][1]);
         }
    }
    public object Load(string path, UICallback.UIResLoad_CB callback)
    {
        this.RegisterCallBack(path, callback);
        return base.Load(path, ResourcePath.UI_ATLAS_PATH);
    }
    protected override void _OnResLoaded(string resName, object go)
    {
        if (_mRes.ContainsKey(resName) && go is GameObject)
        {
            //_mRes[resName] = go;
            GameObject gameObj = go as GameObject;
            UIAtlas atlas = gameObj.GetComponent<UIAtlas>();
            _mRes[resName] = atlas;
            if (atlas == null)
            {
                ViDebuger.Record("UIAtlasManager.load atlas  failed, uiatlas not found[" + resName + "]");
            }
            else
            {
                if (_mAtlasShader.ContainsKey(resName))
                {
                    string shaderName = _mAtlasShader[resName];
                    Shader shader = Shader.Find(shaderName);
                    atlas.spriteMaterial.shader = shader;
                }
              
            }
            DoCallBack(resName, atlas);
        }
    }


    public UIAtlas GetAtlas(string path)
    {
        object resObj = this.GetRes(path);
        //GameObject gameObj = resObj as GameObject;
        UIAtlas atlas = resObj as UIAtlas;
        //try
        //{
        //    atlas = gameObj.GetComponentInChildren<UIAtlas>();
        //}
        //catch (Exception ex)
        //{
        //    ViDebuger.Warning("GetAtlas failed msg=" + ex.ToString());
        //}
        if (atlas == null)
        {
            ViDebuger.Warning("GetAtlas failed path ="+ path);
        }
        return atlas;
    }
}
