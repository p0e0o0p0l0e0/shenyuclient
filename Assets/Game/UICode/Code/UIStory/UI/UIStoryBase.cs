using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public abstract class UIStoryBase : UIWindowComponent<UIStoryWindow, UIStoryController>
{
    /// <summary>
    /// 状态
    /// </summary>
    protected bool isOpen = false;
    /// <summary>
    /// 最长等待时间
    /// </summary>
    protected float maxWaitTime;
    #region 播放声音数据
    /// <summary>
    /// 声音时长
    /// </summary>
    protected float audioLength = 0;
    /// <summary>
    /// 是否在播放声音
    /// </summary>
    protected bool isPlayingSound = false;
    #endregion

    protected StorySlowChangeTex slowShow = null;
    protected StorySlowChangeTex slowDisappear = null;
    protected ViTimeNode1 _node1 = new ViTimeNode1();

    ResourceRequest mResLoader = new ResourceRequest();
    Avatar mNpcAvatar = null;
    Avatar mLeaderAvatar = null;
    public abstract void ShowUI(StoryFunctionData data, VoidDelegate callBack);

    public virtual void Open()
    {
        isOpen = true;
        this._rootTran.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        isOpen = false;
        this._rootTran.gameObject.SetActive(false);
    }

    #region 公用的方法
    /// <summary>
    /// 设置模型不填则为默认模型 true为新 模型，false为默认
    /// </summary>
    /// <param name="newHeadPath"></param>
    /// <param name="defaultName"></param>
    /// <param name="texCompont"></param>
    protected GameObject SetNewModelOrDefault(StoryDialogData.LimitRoleType type, int id, Transform parent, float percent, Vector3 localPos,Action<GameObject> callBack)
    {
        if (parent == null)
            return null;

        foreach (Transform child in parent)
            GameObject.Destroy(child.gameObject);
        mResLoader.End();
        if (mNpcAvatar != null)
        {
            mNpcAvatar.Clear();
            mNpcAvatar = null;
        }
        if (mLeaderAvatar != null)
        {
            mLeaderAvatar.Clear();
            mLeaderAvatar = null;
        }

        switch (type)
        {
            case StoryDialogData.LimitRoleType.None:
                return SetGameObject(id, parent, percent, localPos, callBack);
            case StoryDialogData.LimitRoleType.Leader:
                return SetLeaderGameObject(id, parent, percent, localPos, callBack);
            case StoryDialogData.LimitRoleType.Monster:
                return SetNPCGameObject(id, parent, percent, localPos, callBack);
            default:
                break;
        }
        return null;
    }
    private GameObject SetGameObject(int id, Transform parent, float percent, Vector3 localPos, Action<GameObject> callBack)
    {
        PathFileResStruct resInfo = ViSealedDB<PathFileResStruct>.Data(id);
        mResLoader.Start(resInfo,(UnityEngine.Object pAsset) => 
        {
            GameObject obj = GameObject.Instantiate(pAsset as GameObject);
            obj.name = id.ToString();
            obj.transform.SetParent(parent);
            obj.transform.localPosition = localPos;
            obj.transform.localScale = Vector3.one * percent;
            obj.transform.eulerAngles = Vector3.up * 180f;
            ChangeUIShander(obj.transform);
            Layers.SetlayerRecursively(obj, Layers.UIModel);
            if (callBack != null)
                callBack(obj);
        });
        return null;
    }
    private GameObject SetNPCGameObject(int id, Transform parent, float percent, Vector3 localPos, Action<GameObject> callBack)
    {
        VisualNPCStruct visualInfo = ViSealedDB<VisualNPCStruct>.Data(id);
        SimpleAvatarStruct avatarInfo = visualInfo.Avatar.Data;
        mNpcAvatar = new Avatar();
        mNpcAvatar.LoadCallback = (Avatar avatar) =>
        {
            avatar.Root.name = id.ToString();
            avatar.RootTran.SetParent(parent);
            avatar.RootTran.localPosition = localPos;
            avatar.RootTran.localScale = Vector3.one * percent;
            avatar.RootTran.eulerAngles = Vector3.up * 180f;
            avatar.ChangeUIShander();
            Layers.SetlayerRecursively(avatar.Root, Layers.UIModel);
            if (callBack != null)
                callBack(mNpcAvatar.Root);
        };
        AvatarCreator.Create(mNpcAvatar, avatarInfo.BodyResource.Resource, 1.0f, avatarInfo.PartResource);
        return mNpcAvatar.Root;
    }
    private GameObject SetLeaderGameObject(int id, Transform parent, float percent, Vector3 localPos, Action<GameObject> callBack)
    {
        VisualHeroStruct visualInfo = ViSealedDB<VisualHeroStruct>.Data(id);
        SimpleAvatarStruct avatarInfo = visualInfo.Avatar.Data;
        mLeaderAvatar = new Avatar();
        mLeaderAvatar.LoadCallback = (Avatar avatar) =>
        {
            avatar.Root.name = id.ToString();
            avatar.RootTran.SetParent(parent);
            avatar.RootTran.localPosition = localPos;
            avatar.RootTran.localScale = Vector3.one * percent;
            avatar.RootTran.eulerAngles = Vector3.up * 180f;
            avatar.ChangeUIShander();
            Layers.SetlayerRecursively(avatar.Root, Layers.UIModel);
            if (callBack != null)
                callBack(mLeaderAvatar.Root);
        };
        AvatarCreator.Create(mLeaderAvatar, avatarInfo.BodyResource.Resource, 1.0f, avatarInfo.PartResource);
        return mLeaderAvatar.Root;
    }
    protected void ChangeUIShander(Transform parent)
    {
        if (parent != null)
        {
            Transform trans = parent.Find("Body");
            int count = trans.childCount;
            for (int i = 0; i < count; i++)
            {
                SkinnedMeshRenderer mat = trans.GetChild(i).GetComponent<SkinnedMeshRenderer>();
                if (mat != null)
                {
                    string str = IsShaderContainString(mat.material.shader.name);
                    if (str != "")
                    {
                        mat.material.shader = Shader.Find(str);
                    }
                }
            }
        }
    }
    private string IsShaderContainString(string name)
    {
        if (name.Contains("PBR"))
            return "Physical Shading/Character/UIPBR";
        else if (name.Contains("Hair"))
            return "Physical Shading/Character/UIHair";
        else if (name.Contains("PBRGlow"))
            return "Physical Shading/Character/UIPBRGlow";
        return "";
    }
    /// <summary>
    /// 设置图片不填则为默认图片 true为新图，false为默认
    /// </summary>
    /// <param name="newHeadPath"></param>
    /// <param name="defaultName"></param>
    /// <param name="texCompont"></param>
    protected bool SetNewTexOrDefault(string newResPath, string defaultName, ExUITexture texCompont)
    {
        if (string.IsNullOrEmpty(newResPath))
        {
            if (texCompont.mainTexture == null ||
                texCompont.mainTexture.name != defaultName)
            {
                string path = StoryManager.GetStoryResourcesPath(ResType.Texture, defaultName);
                SetTex(texCompont, path);
            }
            return false;
        }
        else
        {
            SetTex(texCompont, newResPath);
            return true;
        }
    }
    /// <summary>
    /// 设置图片，不填则不显示 true为新图，false为空
    /// </summary>
    /// <param name="newResPath"></param>
    /// <param name="texCompont"></param>
    protected bool SetNewTexOrNull(string newResPath, ExUITexture texCompont)
    {
        if (string.IsNullOrEmpty(newResPath))
        {
            texCompont.SetRawImageTexture(null);
            return false;
        }
        else
        {
            SetTex(texCompont, newResPath);
            return true;
        }
    }
    /// <summary>
    /// 加载设置图片
    /// </summary>
    /// <param name="texCompont"></param>
    /// <param name="resPath"></param>
    protected void SetTex(ExUITexture texCompont, string resPath)
    {
        texCompont.SetRawImageTexture(StoryManager.GetInstance.LoadAsset<Texture>(resPath));
    }
    /// <summary>
    /// 停止播放声音
    /// </summary>
    protected void EndSound()
    {
        Camera cam = Camera.main;
        if (cam != null)
        {
            AudioSource source = cam.GetComponent<AudioSource>();
            if (source != null)
                source.Stop();
        }
    }
    #endregion


    #region 渐渐显示图片,渐渐消失图片
    protected void StartSlowChangeTexState(ExUITexture tex, float duration, bool show)
    {
        if (tex == null)
            return;

        if (show)
        {
            slowShow = new StorySlowChangeTex();
            slowShow.Init(tex, duration, show);
        }
        else
        {
            slowDisappear = new StorySlowChangeTex();
            slowDisappear.Init(tex, duration, show);
        }
    }

    protected bool IsPlaySlowShow(StoryTextureData.TextureStyleType type, float nextTime, float duration, string texPath, bool canDefault)
    {
        if (type == StoryTextureData.TextureStyleType.Slow && nextTime >= duration)
        {
            if (canDefault)
                return true;
            else
            {
                if (!string.IsNullOrEmpty(texPath))
                    return true;
            }
        }
        return false;
    }
    protected bool IsPlaySlowDisappear(StoryTextureData.TextureStyleType type, float duration, string texPath, bool canDefault)
    {
        if (type == StoryTextureData.TextureStyleType.Slow && duration > 0.1f)
        {
            if (canDefault)
                return true;
            else
            {
                if (!string.IsNullOrEmpty(texPath))
                    return true;
            }
        }
        return false;
    }
    #endregion
}

