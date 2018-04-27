using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceRequest
{
    private string mAssetBundleName = "";
    private string mAssetName = "";
    public bool mLoading = false;
    private bool mCache = false;
    private AssetBundleResource mBundleLoader = null;

    public string BundleName { get { return mAssetBundleName; } }
    public string AssetName { get { return mAssetName; } }

    public UnityEngine.Object mAsset = null;
    AsyncLoadAssetFinish mCallBack = null;

    string[] extend = { ".prefab", ".png", ".mat",".ogg", ".ttf", ".mp4", ".asset" };

    public void Start(PathFileResStruct res, AsyncLoadAssetFinish pCallback, bool bCache = false)
    {
        Start(res, 0, pCallback, bCache);
    }

    public void Start(PathFileResStruct res, int nLoadLevle, AsyncLoadAssetFinish pCallback, bool bCache = false)
    {
        if (res == null)
        {
            ViDebuger.Error("发现空 PathFileResStruct 参数");
            return;
        }
        string sBundleName = string.Empty;
        string sAssetName = string.Empty;
        res.GetLODAlias(nLoadLevle, out sBundleName, out sAssetName);

        if (string.IsNullOrEmpty(sBundleName) || string.IsNullOrEmpty(sAssetName))
        {
            ViDebuger.Error("资源ID = " + res.ID + " 没有找到!");
            return;
        }

        Start(sBundleName, sAssetName, pCallback, bCache);
    }

    public void Start(string sPath, string sName, AsyncLoadAssetFinish pCallBack, bool bCache = false)
    {
        if (mLoading)
        {
            if (mAsset != null)
            {
                // 下一帧执行 回调
                ResourceLoadManager.Instance.AddNextFrame(mAsset, pCallBack);
            }
            return;
        }
        
        mAssetBundleName = sPath.ToLower();
        mAssetName = sName.ToLower(); ;
        mCache = bCache;
        mCallBack = pCallBack;
        mLoading = true;

        if (ResourceLoadManager.Instance.IsHaveCache(mAssetBundleName))
        {
            ResourceLoadManager.Instance.AddNextFrameFromCache(mAssetBundleName, pCallBack);
            return;
        }

#if ASYNC_LOAD
        mBundleLoader = ResourceLoadManager.Instance.Load(BundleName);
        mBundleLoader.AddRefCount();
        ResourceLoadManager.Instance.AddResourceReq(this);
#else
        SyncLoad();
#endif
    }

    private void SyncLoad()
    {
        string sResPath = "Assets/" + mAssetBundleName;
        if (mAssetBundleName == "vib/vibstream")
        {
            AddSyncLoadReq(mAssetName);
        }
        else
        {
            // 应该是参数带扩展名 同步模式下直接加载、异步下去掉扩展名
            // 现在蛋疼了
            bool bFind = false;
            for (int i = 0; i < extend.Length; ++i)
            {
                if (File.Exists(sResPath + extend[i]))
                {
                    bFind = true;
                    AddSyncLoadReq(sResPath + extend[i]);
                    break;
                }
            }
            if (!bFind)
            {
                if (File.Exists(sResPath))
                {
                    bFind = true;
                    AddSyncLoadReq(sResPath);
                }
                else
                {
                    ViDebuger.Error("没有找到资源 " + sResPath);
                }
            }
        }
    }

    private void AddSyncLoadReq(string sPath)
    {
#if UNITY_EDITOR
        UnityEngine.Object pAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(sPath);
        ResourceLoadManager.Instance.AddNextFrame(pAsset, mCallBack);
#endif
    }

    public void End()
    {
        mAsset = null;
        mLoading = false;
        if (mBundleLoader != null)
        {
            mBundleLoader.DelRefCount();
            mBundleLoader = null;
        }
    }

    void OnLoadAssetFinish(UnityEngine.Object pAsset)
    {
        mAsset = pAsset;
        if (mCallBack != null)
        {
            mCallBack(mAsset);
        }
        if (mCache)
        {
            ResourceLoadManager.Instance.AddCacheAsset(mAssetBundleName, mAsset);
        }
    }

    public bool Update()
    {
        if (mBundleLoader == null)
        {
            return true;
        }
        if (mBundleLoader.IsReady())
        {
            ResourceLoadManager.Instance.OnStartLoadAsset(mBundleLoader.mAssetBundle, mAssetName, OnLoadAssetFinish);
            return true;
        }
        return false;
    }
}

public class AssetBundleResource
{
    public string mBundleName = "";
    public AssetBundle mAssetBundle = null;
    public List<AssetBundleResource> mDependList = new List<AssetBundleResource>();

    private int nRefCount = 0;

    public AssetBundleResource(string sBundleName)
    {
        mBundleName = sBundleName;
    }

    public void OnAssetBundleCompleted(AssetBundle pAssetBundle)
    {
        if (nRefCount > 0)
        {
            mAssetBundle = pAssetBundle;
        }
    }

    public bool IsReady()
    {
        if (mAssetBundle == null)
        {
            return false;
        }
        for (int i = 0; i < mDependList.Count; ++i)
        {
            if (!mDependList[i].IsReady())
            {
                return false;
            }
        }
        return true;
    }

    public void AddRefCount()
    {
        ++nRefCount;
        for (int i = 0; i < mDependList.Count; ++i)
        {
            mDependList[i].AddRefCount();
        }

        if (mBundleName.Contains("atlastextures/uipublicatlas"))
        {
            //Debug.Log(mBundleName + "    +++++++++++++++++++    " + nRefCount);
        }
    }

    public void DelRefCount()
    {
        --nRefCount;
        for (int i = 0; i < mDependList.Count; ++i)
        {
            mDependList[i].DelRefCount();
        }
        //if (mBundleName.Contains("atlastextures/uipublicatlas"))
        //{
            //Debug.Log(mBundleName + "    -----------------    " + nRefCount);
        //}
        if (nRefCount == 0)
        {
            if (mAssetBundle != null)
            {
                mAssetBundle.Unload(false);
                mAssetBundle = null;
            }
            
            ResourceLoadManager.Instance.RemoveBundle(mBundleName);
        }

        if (nRefCount < 0)
        {
            ViDebuger.Note(mBundleName + "  引用计数错误。");
        }
    }
}