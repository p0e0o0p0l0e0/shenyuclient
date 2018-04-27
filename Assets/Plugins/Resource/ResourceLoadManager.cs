using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AssetBundleComplete(AssetBundle ab);
public delegate void AsyncLoadAssetFinish(UnityEngine.Object pAsset);
public delegate void ManifestLoadCallback();

public class AssetData
{
    public UnityEngine.Object mAsset = null;
    public AsyncLoadAssetFinish mCallBack = null;
    public AssetData(UnityEngine.Object pAsset, AsyncLoadAssetFinish pCallBack)
    {
        mAsset = pAsset;
        mCallBack = pCallBack;
    }

    public void Invoking()
    {
        if (mCallBack != null)
        {
            mCallBack(mAsset);
        }
        mCallBack = null;
        mAsset = null;
    }
}

public class ResourceLoadManager : MonoBehaviour
{
    public static ResourceLoadManager Instance = null;

    Dictionary<string, AssetBundleResource> mBundleList = new Dictionary<string, AssetBundleResource>();
    Dictionary<string, UnityEngine.Object> mCacheList = new Dictionary<string, UnityEngine.Object>();

    List<ResourceRequest> mResourceReqList = new List<ResourceRequest>();
    List<AssetData> mNextFrameInvoking = new List<AssetData>();

    AssetBundleManifest mMainfest = null;
    public ManifestLoadCallback ReadyCallBack = null;

    void Awake ()
    {
        Instance = this;
    }

    public void Initialize()
    {
#if ASYNC_LOAD
        LoadAssetBundle("AssetBundles", (AssetBundle ab) =>
        {
            OnStartLoadAsset(ab, "AssetBundleManifest", (UnityEngine.Object pAsset)=>
            {
                if (pAsset == null)
                {
                    Debug.LogError("加载 Manifest失败");
                }
                mMainfest = pAsset as AssetBundleManifest;
                if (ReadyCallBack != null)
                {
                    ReadyCallBack();
                }
                ab.Unload(false);
            });
        });
#else
        if (ReadyCallBack != null)
        {
            ReadyCallBack();
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = mResourceReqList.Count - 1; i >= 0; --i)
        {
            if (mResourceReqList[i].Update())
            {
                mResourceReqList.RemoveAt(i);
            }
        }

        for (int i = mNextFrameInvoking.Count - 1; i >= 0; --i)
        {
            mNextFrameInvoking[i].Invoking();
            mNextFrameInvoking.RemoveAt(i);
        }
        FilePackage.Instance.Update();
    }

    public AssetBundleResource Load(string sName)
    {
        AssetBundleResource pABReq = null;
        if (!mBundleList.TryGetValue(sName, out pABReq))
        {
            pABReq = CreateAssetBundleLoad(sName);

            string[] dependencies = mMainfest.GetAllDependencies(sName);
            if (dependencies != null && dependencies.Length > 0)
            {
                for (int i = 0; i < dependencies.Length; ++i)
                {
                    pABReq.mDependList.Add(Load(dependencies[i]));
                }
            }
        }
        return pABReq;
    }

    AssetBundleResource CreateAssetBundleLoad(string sBundleName)
    {
        AssetBundleResource pLoad = new AssetBundleResource(sBundleName);
        mBundleList.Add(sBundleName, pLoad);

        LoadAssetBundle(sBundleName, pLoad.OnAssetBundleCompleted);

        return pLoad;
    }

    public void RemoveBundle(string sName)
    {
        mBundleList.Remove(sName);
    }

    public void AddResourceReq(ResourceRequest pReq)
    {
        if (!mResourceReqList.Contains(pReq))
        {
            mResourceReqList.Add(pReq);
        }
    }

    public void AddCacheAsset(string sName, UnityEngine.Object pAsset)
    {
        mCacheList[sName] = pAsset;
    }

    public bool IsHaveCache(string sName)
    {
        return mCacheList.ContainsKey(sName);
    }

    public void RemoveCache(string sName)
    {
        mCacheList.Remove(sName);
    }

    public void ClearCache()
    {
        mCacheList.Clear();
    }

    public void AddNextFrameFromCache(string sName, AsyncLoadAssetFinish pCallBack)
    {
        UnityEngine.Object pAsset = null;
        if (mCacheList.TryGetValue(sName, out pAsset))
        {
            AddNextFrame(pAsset, pCallBack);
        }
    }

    public void AddNextFrame(UnityEngine.Object pAsset, AsyncLoadAssetFinish pCallBack)
    {
        mNextFrameInvoking.Add(new AssetData(pAsset, pCallBack));
    }

    IEnumerator Load_AssetBundle(byte[] dataArray, AssetBundleComplete abc)
    {
        AssetBundleCreateRequest ab = AssetBundle.LoadFromMemoryAsync(dataArray);
        
        yield return ab;

        if (abc != null)
        {
            abc(ab.assetBundle);
        }
    }

    public void LoadAssetBundle(string sBundleName, AssetBundleComplete abc)
    {
        FilePackage.Instance.AddReadFileMemoryReq(sBundleName, (byte[] bytes) =>
        {
            if (bytes == null)
            {
                Debug.LogError(sBundleName + " 加载失败!");
                return;
            }
            StartCoroutine(Load_AssetBundle(bytes, abc));
        });
    }

    IEnumerator Load_AssetAsync(AssetBundle ab, string sAssetName, AsyncLoadAssetFinish pCallback)
    {
        AssetBundleRequest request = ab.LoadAssetAsync(sAssetName);
        yield return request;
        pCallback(request.asset);
    }

    public void OnStartLoadAsset(AssetBundle ab, string sAssetName, AsyncLoadAssetFinish callback)
    {
        StartCoroutine(Load_AssetAsync(ab, sAssetName, callback));
    }
}
