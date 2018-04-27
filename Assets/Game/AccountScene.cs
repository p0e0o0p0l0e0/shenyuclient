using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#region
/*--------------------------------------------------------------------------------
//
// Copyright (C) 2017 netcosmos.com
// 
// 文件名 ： AccountScene
// 文件名功能描述:
//
// 创建者: 王骏(wangjun)
// 时间： (9/18/2017 11:36:36 AM)
//
// 修改人:
// 修改时间：
// 修改说明：
//
// 修改人:
// 修改时间：
// 修改说明：
//
// 版本: V1.0.0
//
//---------------------------------------------------------------------------------*/
#endregion

class AccountScene
{
    public static AccountScene Instance { get { return _instance; } }
    static AccountScene _instance = new AccountScene();

    // Login scene res
    public static ViSealedDataHolder<PathFileResStruct> LoginSceneRes = new ViSealedDataHolder<PathFileResStruct>(3000000);

    private Animator animator = null;
    public GameObject Root;
    private int CurSelectAvatarId;
    private byte CurSelectGender;
    Avatar mCurShowAvatar = null;
    public bool isLoad = false;
    public Transform cameraPosObj;
    public Transform cameraIn;//拉近后camera位置


    public Action scenceLoadedAction;
    public Action avataLoadedAction;
    public void Load()
    {
        if (!isLoad)
        {
            CurSelectAvatarId = -1;
            mSceneLoader.Start(LoginSceneRes, 2, OnLoad);
        }
    }

    public void OnLoad(UnityEngine.Object pAsset)
    {
        isLoad = true;

        UnityAssisstant.Destroy(ref _staticRes);
        if (_root == null)
        {
            _root = new GameObject("LoginScene");
        }
        GameObject obj = pAsset as GameObject;
        _staticRes = UnityAssisstant.InstantiateAsChild(obj, _root.transform);

        Transform trans = _staticRes.transform.Find("M_ZS_C_Camera_001");
        if (trans != null)
        {
            trans.SetParent(_root.transform, false);
            trans.Rotate(Vector3.zero);
            animator = trans.GetComponent<Animator>();
            animator.speed = 0;
            cameraPosObj = new GameObject("cameraObj").transform;
            cameraPosObj.SetParent(trans, false);
            cameraPosObj.localPosition = Vector3.zero;
            cameraPosObj.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            ViDebuger.Warning("场景内没有摄像机动画组件");
        }
        cameraIn = _staticRes.transform.Find("playercamera");
        if (scenceLoadedAction != null)
        {
            scenceLoadedAction();
            scenceLoadedAction = null;
        }
        GlobalGameObject.Instance.SceneCamera.fieldOfView = 42;
        GlobalGameObject.Instance.SceneCamera.nearClipPlane = 0.3f;
        GlobalGameObject.Instance.SceneCamera.farClipPlane = 120f;
        GlobalGameObject.Instance.SceneCamera.transform.position = cameraPosObj.position;
        GlobalGameObject.Instance.SceneCamera.transform.rotation = cameraPosObj.rotation;
        //if (CurSelectGender != (byte)UIRoleDataManager.Gender.Null)
        ShowAvatar(CurSelectAvatarId, CurSelectGender, avataLoadedAction);
        //else
        //    ShowAllAvatar(CurSelectAvatarId, CurSelectGender, avataLoadedAction);
    }

    public void ShowAvatar(int id, byte gender, Action callBack = null)
    {
        CurSelectAvatarId = id;
        CurSelectGender = gender;
        avataLoadedAction = callBack;
        if (CurSelectAvatarId == -1)
            return;
        if (_staticRes == null)
        {
            Debug.Log("Scene Need be loaded before ShowAvatar!");
            return;
        }
        // Debug.Log("ikiiiiiii");
        if (_avatar != null)
            _avatar.Clear();
        if (_avatarFiMale != null)
            _avatarFiMale.Clear();
        _avatar = new Avatar();
        _avatar.LoadCallback = this._OnAvatarLoaded;
        AvatarCreator.Create(_avatar, gender, id, 1.0f, GetItemList(), GetFair(), GetFace());
    }

    public void ShowAllAvatar(int id, byte gender, Action callBack = null)
    {

        CurSelectAvatarId = id;
        CurSelectGender = gender;
        avataLoadedAction = callBack;
        if (CurSelectAvatarId == -1)
            return;
        if (!isLoad)
        {
            Debug.Log("Scene Need be loaded before ShowAvatar!");
            return;
        }
        if (_avatar != null)
            _avatar.Clear();
        if (_avatarFiMale != null)
            _avatarFiMale.Clear();
        _avatar = new Avatar();
        _avatar.LoadCallback = this._OnAvatarLoaded;
        AvatarCreator.Create(_avatar, gender, id, 1.0f, GetItemList(), GetFair(), GetFace());
    }


    public void SetAvatarFaceOrHair(int id)
    {
        if (_avatar != null)
            _avatar.SetFaceOrFair(id);
    }

    private void _OnAvatarLoaded(Avatar avatar)
    {
        Transform parent = _staticRes.transform;
        avatar.RootTran.parent = parent;
        avatar.Root.layer = (int)UnityLayer.DEFAULT;
        avatar.Root.name = "HeroAvatar";
        avatar.RootTran.position = new Vector3(0, 0, 0);
        avatar.RootTran.rotation = Quaternion.Euler(0, 0, 0);
        mCurShowAvatar = avatar;
        if (avataLoadedAction != null)
        {
            avataLoadedAction();
            avataLoadedAction = null;
        }
    }

    //public void PlayCameraAnimation()
    //{
    //    animator.speed = 1;
    //}

    //public void CameraAnimationPlayEnd()
    //{
    //    animator.Play("show03", 0, 4.32f);
    //}

    public Vector3 CameraAnimationEndPos()
    {
        return Vector3.zero;
    }

    private List<int> GetItemList()
    {
        VisualCorner cor = ViSealedDB<VisualCorner>.Data(CurSelectAvatarId);
        List<int> item = new List<int>();
        if (cor.Weapon1 != 0)
            item.Add(cor.Weapon1);
        if (cor.SubWeapon1 != 0)
            item.Add(cor.SubWeapon1);
        if (cor.Shoulder != 0)
            item.Add(cor.Shoulder);
        if (cor.Jacket != 0)
            item.Add(cor.Jacket);
        if (cor.Pants != 0)
            item.Add(cor.Pants);
        return item;
    }

    private int GetFace()
    {
        return ViSealedDB<VisualCorner>.Data(CurSelectAvatarId).Face[0];
    }
    private int GetFair()
    {
        return ViSealedDB<VisualCorner>.Data(CurSelectAvatarId).Hair[0];
    }
    public void Clear()
    {
        if (_avatar != null)
        {
            _avatar.Clear();
            _avatar = null;
        }
        UnityAssisstant.Destroy(ref _staticRes);
        UnityAssisstant.Destroy(ref _root);
        mCurShowAvatar = null;
        isLoad = false;
        mSceneLoader.End();
    }



    public void OnDragRole(Vector2 vDelta)
    {
        if (mCurShowAvatar != null)
        {
            // mCurShowAvatar.Root.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, mCurShowAvatar.Root.transform.localRotation.eulerAngles.y - vDelta.x, 0.0f));
            mCurShowAvatar.Root.transform.RotateAround(new Vector3(-2.4f, 1.5f,-7.9f),new Vector3(0,1,0), (- vDelta.x));
        }
    }
    public Avatar MaleAvatar()
    {
        return _avatar;
    }
    public Avatar FeMaleAvatar()
    {
        return _avatarFiMale;
    }
    GameObject _root = new GameObject("LoginScene");
    GameObject _staticRes = null;
    Avatar _avatar = null;
    Avatar _avatarFiMale = null;
    private Dictionary<int, Avatar> _mAvatars = new Dictionary<int, Avatar>();
    ResourceRequest mSceneLoader = new ResourceRequest();


    /// <summary>
    /// 播放人物动画
    /// </summary>
    public void PlayShow1()
    {
        PlayAnimation("show01");
    }

    public void PlayShow2()
    {
        PlayAnimation("show02");
    }

    public void PlayShow3()
    {
        PlayAnimation("show03");
    }
    public void PlayShow4()
    {
        PlayAnimation("show04");
    }

    public void PlayAnimation(string name)
    {
        if (mCurShowAvatar != null && mCurShowAvatar.Anim != null)
            mCurShowAvatar.Anim.Play(name);
    }

    /// <summary>
    /// 获得动画时间
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public uint GetAnimationTime(string name)
    {
        if (mCurShowAvatar != null)
        {
            AnimationClip info = mCurShowAvatar.Anim.GetClip(name);
            if (info != null)
                return (uint)info.length * 100;
            else
                return 0;
        }
        return 0;
    }
    /// <summary>
    /// 重置摄像机AC
    /// </summary>
    public void ResetCameraAC()
    {
        if (animator != null)
        {
            animator.SetActive(false);//暂用，还没找到一个重置方法
            animator.SetActive(true);
            animator.speed = 0;
        }
    }

    public void AnimationBlend(string anim2)
    {
        _avatar.Anim.Blend(anim2, 10f);
    }






}
