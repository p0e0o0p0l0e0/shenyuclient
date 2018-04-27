using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIRoleWindow : UIWindow<UIRoleWindow, UIRoleController>
{
    #region ui control name define
    private const string BackBtn = "UIRoleWindow/BackBtn";
    private const string NextBtn = "UIRoleWindow/NextBtn";
    private const string TargetTexture = "UIRoleWindow/AvatarTarget/Texture";
    private const string MaleToggle = "UIRoleWindow/Career/SexGroup/MaleToggle";
    private const string FeMaleToggle = "UIRoleWindow/Career/SexGroup/FemaleToggle";
    private const string MaleToggleMask = "UIRoleWindow/Career/SexGroup/MaleToggle/Checkmark";
    private const string FeMaleToggleMask = "UIRoleWindow/Career/SexGroup/FemaleToggle/Checkmark";
    private const string CareerGroup = "UIRoleWindow/Career/CareerGroup";
    private const string SkillVideo = "UIRoleWindow/SkillVideo";
    private const string SkillVideoPlayer = "UIRoleWindow/SkillVideo/Vidio";
    private const string SkillShow = "UIRoleWindow/SkillShow";
    #endregion
    private ExUITexture _mAvatarTexture = null;
    private int _curSelectedRoleId = -1;
    private Button _mMaleToggle = null;
    private Button _mFeMaleToggle = null;

    private List<GameObject> _HeroTypeMask = null;
    private UIRoleSkillShowWindow skillShow;
    bool isMale;
    bool isFeiMale;

    bool isModelCreat=true;
    ViTimeNode2 playAnimCallBack;
    ResourceRequest resRe = new ResourceRequest();
    protected override void Initial()
    {
        base.Initial();
        AccountScene.Instance.Load();
        Button backBtn = this.GetComponent<Button>(BackBtn);
        backBtn.onClick.AddListener(_onClickBack);
        Button nextBtn = this.GetComponent<Button>(NextBtn);
        nextBtn.onClick.AddListener(_onNextBtn);
        _mAvatarTexture = this.GetComponent<ExUITexture>(TargetTexture);
        _mMaleToggle = this.GetComponent<Button>(MaleToggle);
        _mMaleToggle.onClick.AddListener(OnMaleToggle);
        _mFeMaleToggle = this.GetComponent<Button>(FeMaleToggle);
        _mFeMaleToggle.onClick.AddListener(OnFeMaleToggle);
        _HeroTypeMask = new List<GameObject>();
        Button skillBtn = this.GetComponent<Button>(SkillVideo);
        skillBtn.onClick.AddListener(CloseVideo);
        for (int i = 0; i < 6; i++)
        {
            Button btn = this.GetComponent<Button>(CareerGroup + "/caree" + i);
            if (i == 0 || i == 4)
            {
                btn.onClick.AddListener(delegate () { HeroTypeClick(int.Parse(btn.name.Replace("caree", "")) + 1); });
            }
            else
            {
                ExUISprite spri = btn.GetComponent<ExUISprite>(); //置灰操作
                spri.SetGray(true);
            }
            _HeroTypeMask.Add(btn.transform.Find("Checkmark").gameObject);
        }
        UIRoleDataManager.GetInstance.OnAvatarShow += _OnAvatarShow;
        OpenOrCloseVideo(false);
    }
    public override void Show()
    {
        base.Show();
        if (UIRoleDataManager.GetInstance.CurSelectAvatarId != -1 && UIRoleDataManager.GetInstance.CurSelectGender != (byte)UIRoleDataManager.Gender.Null)
        {
            if (UIRoleDataManager.GetInstance.CurSelectGender == (byte)UIRoleDataManager.Gender.MALE)
                ShowMale(true, false);
            else if (UIRoleDataManager.GetInstance.CurSelectGender == (byte)UIRoleDataManager.Gender.FEMALE)
                ShowMale(false, true);
            _curSelectedRoleId = UIRoleDataManager.GetInstance.CurSelectAvatarId;
            for (int i = 0; i < 6; i++)
            {
                if (i == _curSelectedRoleId - 1)
                    _HeroTypeMask[i].SetActive(true);
                else
                    _HeroTypeMask[i].SetActive(false);
            }
            PlayRightTween(UIRoleDataManager.GetInstance.GetVisId());
        }
        else
        {
            HeroTypeClick(1);     
        }
    }
    public override void Hide()
    {
        RemoveAnimationCallBack();
        _curSelectedRoleId = -1;
       // AccountScene.Instance.CameraAnimationPlayEnd();
        UIRoleDataManager.GetInstance.OnAvatarShow -= _OnAvatarShow;
        skillShow = null;
        base.Hide();
    }

    /// <summary>
    /// 设置初始性别
    /// </summary>
    public void ReSetCurSelectGender()
    {
        //UIRoleDataManager.GetInstance.CurSelectGender = (byte)UIRoleDataManager.Gender.Null;
        //ShowMale(false, false);
        if (_curSelectedRoleId != 5)
            OnMaleToggle();
        else
            OnFeMaleToggle();
    }

    /// <summary>
    ///男性点击
    /// </summary>
    private void OnMaleToggle()
    {
        //if (!isModelCreat)
        //    return;
        if (UIRoleDataManager.GetInstance.CurSelectGender != (byte)UIRoleDataManager.Gender.MALE)
        {
            UIRoleDataManager.GetInstance.CurSelectGender = (byte)UIRoleDataManager.Gender.MALE;
            ShowMale(true, false);
            //if (!isMale)
            //{
            //    isMale = true;
            //    //RemoveAnimationCallBack();

            //    //resRe.Start(ViSealedDB<PathFileResStruct>.Data(2001005), LoadEffect);
            //    //AccountScene.Instance.PlayShow3();
            //    //AddAnimationCallBack("show03");
            //    //AccountScene.Instance.PlayCameraAnimation();
            //}
        }
    }

    /// <summary>
    /// 女性点击
    /// </summary>
    private void OnFeMaleToggle()
    {
        //if (!isModelCreat)
        //    return;
        if (UIRoleDataManager.GetInstance.CurSelectGender != (byte)UIRoleDataManager.Gender.FEMALE)
        {
            UIRoleDataManager.GetInstance.CurSelectGender = (byte)UIRoleDataManager.Gender.FEMALE;
            ShowMale(false, true);
            //if (!isFeiMale)
            //{
            //    //RemoveAnimationCallBack();
            //    isFeiMale = true;


            //    //resRe.Start(ViSealedDB<PathFileResStruct>.Data(2001005), LoadEffect);
            //    //AccountScene.Instance.PlayShow3();
            //    //AddAnimationCallBack("show03");
            //    //AccountScene.Instance.PlayCameraAnimation();
            //}
        }
    }

    /// <summary>
    /// 切换页签显示
    /// </summary>
    /// <param name="isMale"></param>
    /// <param name="isFeimale"></param>
    private void ShowMale(bool isMale, bool isFeimale)
    {
        this.FindTransform(MaleToggleMask).SetActive(isMale);
        this.FindTransform(FeMaleToggleMask).SetActive(isFeimale);
    }

    /// <summary>
    /// 英雄类型点击
    /// </summary>
    /// <param name="id"></param>
    private void HeroTypeClick(int id)
    {
        if (!isModelCreat)
            return;
        if (_curSelectedRoleId != id)
        {
            isModelCreat = false;
            RemoveAnimationCallBack();
          

            if (id == 1) //置灰
            {
                ExUISprite ex = this.GetComponent<ExUISprite>("UIRoleWindow/Career/SexGroup/MaleToggle");
                ex.SetGray(false);
                ex.raycastTarget = true;
                 ex = this.GetComponent<ExUISprite>("UIRoleWindow/Career/SexGroup/FemaleToggle");
                ex.SetGray(true);
                ex.raycastTarget = false;
            }
            if (id == 5)
            {
                ExUISprite ex = this.GetComponent<ExUISprite>("UIRoleWindow/Career/SexGroup/MaleToggle");
                ex.SetGray(true);
                ex.raycastTarget = false;
                ex = this.GetComponent<ExUISprite>("UIRoleWindow/Career/SexGroup/FemaleToggle");
                ex.SetGray(false);
                ex.raycastTarget = true;
            }

            for (int i = 0; i < 6; i++)
            {
                if (i == id - 1)
                    _HeroTypeMask[i].SetActive(true);
                else
                    _HeroTypeMask[i].SetActive(false);
            }
            _curSelectedRoleId = id;
            ReSetCurSelectGender();
            UIRoleDataManager.GetInstance.CurSelectAvatarId = _curSelectedRoleId;
            PlayerInitStruct init = ViSealedDB<PlayerInitStruct>.Data(UIRoleDataManager.GetInstance.GetVisId());
            int index = init.Hero[0].Hero.PData.ID;
           // AccountScene.Instance.ResetCameraAC();
            UIRoleDataManager.GetInstance.ShowAvatar(index, UIRoleDataManager.GetInstance.CurSelectGender,()=>
            {
                isModelCreat = true;
                AccountScene.Instance.PlayShow1();
                resRe.Start(ViSealedDB<PathFileResStruct>.Data(2001004), LoadEffect);
                AddAnimationCallBack("show01");
            });

            PlayRightTween(UIRoleDataManager.GetInstance.GetVisId());
            //isMale = false;
            //isFeiMale = false;
        }
    }
    private void _onClickBack()
    {
        if (!isModelCreat)
            return;
        UnloadEffect();
        this._mController.OnClickBack();
    }
    private void _onNextBtn()
    {
        if (!isModelCreat)
            return;
        if (UIRoleDataManager.GetInstance.CurSelectGender != (byte)UIRoleDataManager.Gender.FEMALE)
        {
            UnloadEffect();
            this._mController.OnClickNext();
        }
    }

    private void GameObjback(string name, object obj)
    {
        if (obj != null && obj.ToString() != "null")
        {
            GameObject gam = obj as GameObject;
            skillShow = gam.AddComponent<UIRoleSkillShowWindow>();
            skillShow.SetParent(FindTransform(SkillShow));
            skillShow.Init(PlayVideo);
            skillShow.PlayFirstTween();
            skillShow.RushInfo(UIRoleDataManager.GetInstance.GetVisId());
        }
    }

    private void _OnAvatarShow(int id, object obj)
    {
        if (_curSelectedRoleId == id && obj is RenderTexture)
        {
            RenderTexture rt = obj as RenderTexture;
            if (rt != null)
            {
                _mAvatarTexture.texture = rt;
                _mAvatarTexture.Size = UIDefine.DESIGN_RESOLUTION;
            }
        }
    }

    private void PlayRightTween(int id)
    {
        if (skillShow == null)
            UIGoManager.Instance.Load("UIRoleSkillShowWindow", (string name, object obj1) => GameObjback(name, obj1));
        else
        {
            skillShow.PlayReAndFor(() => { PlayFirstTweenAndRush(); skillShow.RushInfo(id); });
        }
    }

    private void PlayFirstTweenAndRush()
    {
        if (skillShow != null)
        {
            skillShow.PlayFirstTween();
            skillShow.ClearClallBack();
        }

    }
    private bool IsRuning()
    {
        if (skillShow != null)
            return skillShow.IsRuning();
        else
            return false;
    }

    private void PlayVideo(int id)
    {
        OpenOrCloseVideo(true);
        VisualCorner visualInfo = ViSealedDB<VisualCorner>.Data(UIRoleDataManager.GetInstance.GetVisId() + 1);//_curSelectedRoleId
        string path = visualInfo.Spell[id].PData.VideoPath;
        if (!string.IsNullOrEmpty(path))
        {

            //AssetBundleWWW wwwLoad = AssetBundleWWW.Load("file:" + Application.dataPath + "/StreamingAssets/pro/" + path, 1, false);
            //VideoClip clip = wwwLoad.assetBundle.LoadAsset(path.Split('/')[1]) as VideoClip;
            VideoClip clip = Resources.Load("Video/zhujgsbqskill11") as VideoClip;
            if (clip != null)
            {
                VideoPlayer play = this.GetComponent<VideoPlayer>(SkillVideoPlayer);
                play.clip = clip;
                play.Play();
            }
        }
    }
    private void CloseVideo()
    {
        VideoPlayer play = this.GetComponent<VideoPlayer>(SkillVideoPlayer);
        if (play.isPlaying)
        {
            play.Stop();
        }
        OpenOrCloseVideo(false);
        skillShow.CloseSkillShow();
    }

    private void OpenOrCloseVideo(bool isShow)
    {
        this.FindTransform(SkillVideo).gameObject.SetActive(isShow);
    }

    ///// <summary>
    ///// 绑定摄像机
    ///// </summary>
    //private void BandCamera()
    //{
    //    timeCallBack = new ViTimeNode4();
    //    timeCallBack.Start(ViTimerRealInstance.Timer, 1, this.SetCameraPos);
    //}
    /// <summary>
    /// 同步摄像机动画和摄像机位置
    /// </summary>
    /// <param name="node"></param>
    private void SetCameraPos()
    {
        GlobalGameObject.Instance.SceneCamera.transform.position = AccountScene.Instance.cameraPosObj.transform.position;
        GlobalGameObject.Instance.SceneCamera.transform.rotation = AccountScene.Instance.cameraPosObj.transform.rotation;
    }
    //public void RemoveTime()
    //{
    //    timeCallBack.Detach();
    //}


    /// <summary>
    /// 增加动画回调
    /// </summary>
    public void AddAnimationCallBack(string animtion)
    {
        UIRoleDataManager.GetInstance.SetAnimation(true);
        playAnimCallBack = new ViTimeNode2();
        playAnimCallBack.Start(ViTimerRealInstance.Timer, 1, AccountScene.Instance.GetAnimationTime(animtion));
        if (animtion == "show01")
        {
            playAnimCallBack.Delegate = Show01CallBack;
        }
        //else if (animtion == "show03")
        //{
        //    playAnimCallBack.Delegate = Show03CallBack;
        //}
    }

    /// <summary>
    /// 移除动画播放完成回调
    /// </summary>
    public void RemoveAnimationCallBack()
    {
        if (playAnimCallBack != null)
            playAnimCallBack.Detach();
        UIRoleDataManager.GetInstance.SetAnimation(false);
    }

    public void Show01CallBack(ViTimeNodeInterface node)
    {
        UIRoleDataManager.GetInstance.SetAnimation(false);
        if (AccountScene.Instance.MaleAvatar() != null)
            AccountScene.Instance.MaleAvatar().Anim.Blend("show02", 10f);
    }

    private void LoadEffect(object obj)
    {
        if (AccountScene.Instance.MaleAvatar() != null)
        {
            UnloadEffect();
            GameObject obj1 = UnityAssisstant.InstantiateAsChild(obj as GameObject, AccountScene.Instance.MaleAvatar().Property.AttachPos[1]);
            resRe.End();
        }     
    }

    private void UnloadEffect()
    {
        if (AccountScene.Instance.MaleAvatar() != null)
        {
            Transform trans = AccountScene.Instance.MaleAvatar().Property.AttachPos[1];
            for (int i = 0; i < trans.childCount; i++)
            {
                trans.GetChild(i).SetActive(false);
            }
        }
    }
}

