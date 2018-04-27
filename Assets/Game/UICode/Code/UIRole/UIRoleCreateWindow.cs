using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIRoleCreateWindow : UIWindow<UIRoleCreateWindow, UIRoleCreateController>
{
    #region ui control name define
    private const string BackBtn = "UIRoleCreateWindow/BackBtn";
    private const string NextBtn = "UIRoleCreateWindow/NextBtn";
    private const string RandomBtn = "UIRoleCreateWindow/NameInput/RandomBtn";
    private const string RandomNameInput = "UIRoleCreateWindow/NameInput";
    private const string TargetTexture = "UIRoleCreateWindow/AvatarTarget/Texture";
    private const string FunctionTran = "UIRoleCreateWindow/Function";
    private const string RoleTran = "UIRoleCreateWindow/Function/Role";
    private const string RoleName = "/RoleName";
    private const string RoleLevel = "/Level";
    private const string RoleCSp = "/CareerSp";
    private const string LookDetail = "UIRoleCreateWindow/ViewToggleOut";
    private const string RightAvata = "UIRoleCreateWindow/Avatar";
    private const string RightBack = "UIRoleCreateWindow/Avatar/Back";
    private const string RightFaceAndFair = "UIRoleCreateWindow/Avatar/FairAndFace";
    private const string Fair = "/Fair";
    private const string Face = "/Face";
    private const string SkillShow = "SkillShow";
    #endregion
    /// <summary>
    /// 选择角色左侧按钮列表对象
    /// </summary>
    private class CareerUI
    {
        public Transform Tran { get; set; }
        public ExUISprite LowSp { get; set; }
        public Text Name { get; set; }
        public Text Level { get; set; }
        public ExUISprite CareerSp { get; set; }
        public void Hide()
        {
            Name.gameObject.SetActive(false);
            Level.gameObject.SetActive(false);
            CareerSp.gameObject.SetActive(false);
        }
        public void Show()
        {
            Name.gameObject.SetActive(true);
            Level.gameObject.SetActive(true);
            CareerSp.gameObject.SetActive(true);
        }
        public void ClickShow(bool isShow)
        {
            CareerSp.gameObject.SetActive(isShow);
        }
    }

    /// <summary>
    /// 脸和头发对象
    /// </summary>
    private class NameTitle
    {
        public Transform tra;
        public Text Name;

        public ExUISprite Incon;

        public GameObject Select;
        public NameTitle(Transform obj)
        {
            tra = obj;
            Incon = obj.GetComponent<ExUISprite>();
            Name = obj.Find("Name").GetComponent<Text>();
            Select = obj.Find("Title").gameObject;
        }

        public void SetSelect(bool isShow)
        {
            Select.SetActive(isShow);
        }
    }
    private InputField _randomName = null;
    private UIRoleSkillShowWindow skillShow = null;
    private int newPos = 29;  //脸头发动画重点坐标
    private List<CareerUI> _mCareerList = new List<CareerUI>();
    private List<NameTitle> _faceList = new List<NameTitle>();
    private List<NameTitle> _fairList = new List<NameTitle>();
    public int lastClickHero = -1;
    public int lastFair = -1;
    public int lastFace = -1;
    string inputName = "";

    Vector3 cameraInPos = new Vector3(-2.5f, 2.5f, -6.06f); //拉近的位置
    bool isModleCreat = true;


    ViTimeNode2 playAnimCallBack;
    ResourceRequest resRe = new ResourceRequest();
    protected override void Initial()
    {
        base.Initial();
        AccountScene.Instance.Load();
        _mCareerList.Clear();
        Button backBtn = this.GetComponent<Button>(BackBtn);
        backBtn.onClick.AddListener(ClickBack);
        Button nextBtn = this.GetComponent<Button>(NextBtn);
        nextBtn.onClick.AddListener(_OnClickNextBtn);
        Button randomBtn = this.GetComponent<Button>(RandomBtn);
        randomBtn.onClick.AddListener(_mController.OnClickRandomName);
        _randomName = this.GetComponent<InputField>(RandomNameInput);
        _randomName.onValueChanged.AddListener(OnInputValueChange);

        ExUIToggle pViewToggle = GetComponent<ExUIToggle>(LookDetail);
        pViewToggle.onValueChanged.AddListener(OnSelectChange);
        for (int i = 0; i < 6; ++i)
        {
            int index = i + 1;
            Transform tran = this.FindTransform(RoleTran + index);
            CareerUI cUI = new CareerUI();
            cUI.Tran = tran;
            cUI.LowSp = this.GetComponent<ExUISprite>(RoleTran + index);
            cUI.Name = this.GetComponent<Text>(RoleTran + index + RoleName);
            cUI.Level = this.GetComponent<Text>(RoleTran + index + RoleLevel);
            cUI.CareerSp = this.GetComponent<ExUISprite>(RoleTran + index + RoleCSp);
            ExUIButton btn = this.GetComponent<ExUIButton>(RoleTran + index);
            btn.Id = i;
            btn.onClickEx = _OnClickCareer;
            _mCareerList.Add(cUI);
        }
        for (int i = 0; i <= 5; i++)
        {
            Transform tran = this.FindTransform(RightFaceAndFair + Face + i);
            NameTitle na = new NameTitle(tran);
            ExUIButton bu = tran.GetComponent<ExUIButton>();
            bu.Id = i;
            bu.onClickEx = OnClickFace;
            _faceList.Add(na);

            Transform tran1 = this.FindTransform(RightFaceAndFair + Fair + i);
            NameTitle na1 = new NameTitle(tran1);
            ExUIButton bu1 = tran1.GetComponent<ExUIButton>();
            bu1.Id = i;
            bu1.onClickEx = OnClickFair;
            _fairList.Add(na1);
        }
    }

    public override void Show()
    {
        base.Show();
        UIRoleDataManager.GetInstance.OnAvatarShow += _OnAvatarShow;
        UpdateRoleInfo();
    }
    public override void Hide()
    {
        UnloadEffect();
        lastClickHero = -1;
        lastFair = -1;
        lastFace = -1;
        inputName = "";
        UIRoleDataManager.GetInstance.OnAvatarShow -= _OnAvatarShow;
        skillShow = null;
        base.Hide();
    }
    /// <summary>
    /// 摄像头拉近拉远
    /// </summary>
    /// <param name="isToggle"></param>
    private void OnSelectChange(bool isToggle)
    {
        TweenPosition.Begin(GlobalGameObject.Instance.SceneCamera.gameObject, 0.23f, isToggle ? cameraInPos : AccountScene.Instance.cameraPosObj.position);
    }

    /// <summary>
    /// 刷新面板信息
    /// </summary>
    public void UpdateRoleInfo()
    {
        if (UIRoleDataManager.GetInstance.GetCreatTag())  //创建
        {
            if (AccountScene.Instance.MaleAvatar() != null)
                AccountScene.Instance.MaleAvatar().Anim.Play("show02");
            ShowUI(true);
            PlayFaceAndFairTween();
            RushFairAndFace();
            OnClickFace(0, null);
            OnClickFair(0, null);
        }
        else                                           //选择
        {
            ShowUI(false);
            _UpdatePlayerList();
            _OnClickCareer(Account.Instance.Property.LastSelectRole, null);
        }
    }






    /// <summary>
    /// 在选择和创建之间切换UI
    /// </summary>
    /// <param name="isCreat"></param>
    private void ShowUI(bool isCreat)
    {
        FindTransform(RandomNameInput).SetActive(isCreat);
        FindTransform(FunctionTran).SetActive(!isCreat);
        FindTransform(RightAvata).SetActive(isCreat);
        FindTransform(LookDetail).SetActive(isCreat);
    }


    private void _OnAvatarShow(int id, object obj)
    {

    }
    #region 选择
    /// <summary>
    /// 刷新已拥有英雄列表
    /// </summary>
    private void _UpdatePlayerList()
    {
        ViReceiveDataArray<ReceiveDataAccountRoleProperty, AccountRoleProperty> playerList = Account.Instance.Property.PlayerList;
        for (int i = 0; i < _mCareerList.Count; ++i)
        {
            if (playerList != null && i < playerList.Count)
            {
                _mCareerList[i].Name.text = playerList[i].Property.Identification.NameAlias.Value;
                _mCareerList[i].Level.text = playerList[i].Property.Level.Value.ToString() + I18NManager.Instance.GetWord("tips_146");
                VisualCorner visualInfo = ViSealedDB<VisualCorner>.Data(playerList[i].Property.HeroConfig.Value.ID);
                _mCareerList[i].LowSp.SpriteName = visualInfo.professionIcon + "1";
                _mCareerList[i].CareerSp.SpriteName = visualInfo.professionIcon + "2";// "btn_soldier_02";
                _mCareerList[i].Show();
                _mCareerList[i].ClickShow(false);
            }
            else
            {
                _mCareerList[i].Hide();
            }
        }
    }

    /// <summary>
    /// 英雄点击
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ob"></param>
    private void _OnClickCareer(int id, object ob)
    {
        if (id != lastClickHero)
        {
            if (!isModleCreat)
                return;
            if (id < Account.Instance.Property.PlayerList.Count) //选择
            {
                isModleCreat = false;
                if (lastClickHero != -1)
                    _mCareerList[lastClickHero].ClickShow(false);
                lastClickHero = id;
                int heroId = Account.Instance.Property.PlayerList[id].Property.HeroConfig;
                if (heroId == 0)
                    ViDebuger.Error("服务器发过来的数据为0");
                byte gender = Account.Instance.Property.PlayerList[id].Property.Gender;
                _mCareerList[id].ClickShow(true);
                UIRoleDataManager.GetInstance.ShowAvatar(heroId, gender, () =>
                {
                    isModleCreat = true;
                    AccountScene.Instance.PlayShow1();                   
                    resRe.Start(ViSealedDB<PathFileResStruct>.Data(2001004), LoadEffect);
                    AddAnimationCallBack("show01");
                });
                PlayRightTween(heroId);
            }
            else //创建
            {
                lastClickHero = id;
                UIManager.Instance.Hide(UIControllerDefine.WIN_CreateRole, (() => { UIManager.Instance.Show(UIControllerDefine.WIN_Role); }));
                ResetSetCameraPosition();
            }
        }
    }
    /// <summary>
    /// 设置选择人物的时候摄像机初始位置
    /// </summary>
    private void SetCameraPos()
    {
        //GlobalGameObject.Instance.SceneCamera.transform.position = cameraStartPos;
        //GlobalGameObject.Instance.SceneCamera.transform.rotation = Quaternion.Euler(cameraStartRo);
    }
    #endregion


    #region //创建
    /// <summary>
    /// 右侧脸型动画
    /// </summary>
    private void PlayFaceAndFairTween()
    {
        UICanvasGroupTween _faceAlpha = this.GetComponent<UICanvasGroupTween>(RightFaceAndFair);
        UICanvasGroupTween _backAlpha = this.GetComponent<UICanvasGroupTween>(RightBack);
        this.GetComponent<RectTransform>(RightAvata).DOLocalMoveY(newPos, 0.2f);
        _backAlpha.PlayForward();
        _faceAlpha.PlayForward();
    }




    /// <summary>
    /// 刷新脸和头发的UI
    /// </summary>
    private void RushFairAndFace()
    {
        VisualCorner cor = ViSealedDB<VisualCorner>.Data(UIRoleDataManager.GetInstance.GetVisId());
        ViStaticArray<ViForeignKeyStruct<VisualCornerList>> hairList = cor.Hair;
        for (int i = 0; i < hairList.Length; i++)
        {
            _fairList[i].tra.SetActive(true);
            _fairList[i].Incon.SpriteName = hairList[i].PData.icon;
            _fairList[i].Incon.SetGray(true);
            _fairList[i].Incon.raycastTarget = false;
            _fairList[i].Name.text = hairList[i].PData.name;
        }
        for (int i = hairList.Length; i < _fairList.Count; i++)
        {
            _fairList[i].tra.SetActive(false);
        }
        ViStaticArray<ViForeignKeyStruct<VisualCornerList>> faceList = cor.Face;
        for (int i = 0; i < faceList.Length; i++)
        {
            _faceList[i].tra.SetActive(true);
            _faceList[i].Incon.SpriteName = faceList[i].PData.icon;
            _faceList[i].Incon.SetGray(true);
            _faceList[i].Incon.raycastTarget = false;
            _faceList[i].Name.text = faceList[i].PData.name;
        }
        for (int i = faceList.Length; i < _fairList.Count; i++)
        {
            _faceList[i].tra.SetActive(false);
        }
    }
    public void OnClickFace(int id, object obj)
    {
        if (id != lastFace)
        {
            if (lastFace != -1)
                _faceList[lastFace].SetSelect(false);
            _faceList[id].SetSelect(true);
            lastFace = id;
        }
    }

    public void OnClickFair(int id, object obj)
    {
        if (id != lastFair)
        {
            if (lastFair != -1)
                _fairList[lastFair].SetSelect(false);
            _fairList[id].SetSelect(true);
            lastFair = id;
        }
    }
    #endregion

    private void PlayRightTween(int id)
    {
        if (skillShow == null)
            UIGoManager.Instance.Load("UIRoleSkillShowWindow", (string name, object obj1) => GameObjBack(name, obj1));
        else
        {
            skillShow.PlayReAndFor(() => { skillShow.RushInfo(id); PlayFirstTweenAndRush(); });
            ResetSetCameraPosition();
        }
    }
    private void GameObjBack(string name, object obj)
    {
        if (!this.IsResAvaliable()) return;//异步加载，回来时界面可能不存在了
        if (obj != null && obj.ToString() != "null")
        {
            GameObject gam = obj as GameObject;
            skillShow = gam.AddComponent<UIRoleSkillShowWindow>();
            skillShow.SetParent(FindTransform(SkillShow));
            skillShow.Init(false, OnSelectChange);
            skillShow.PlayFirstTween();
            skillShow.RushInfo(Account.Instance.Property.PlayerList[lastClickHero].Property.HeroConfig);
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
    /// <summary>
    /// 输入框更改回调
    /// </summary>
    /// <param name="name"></param>
    private void OnInputValueChange(string name)
    {
        _randomName.text = UIRoleDataManager.GetInstance.ValueChange(name);
    }
    /// <summary>
    /// 直接更改，也会走上面
    /// </summary>
    /// <param name="name"></param>
    public void SetRandomName(string name)
    {
        _randomName.text = name;
    }
    /// <summary>
    /// 重置摄像机拉近
    /// </summary>
    private void ResetSetCameraPosition()
    {
        if (skillShow != null && skillShow.GetToggleIsOn())
        {
            skillShow.SetToggleIsOn(false);
        }
    }


    /// <summary>
    /// 返回按钮
    /// </summary>
    private void ClickBack()
    {
        if (!isModleCreat)
            return;
        ExUIToggle pViewToggle = GetComponent<ExUIToggle>(LookDetail);
        if (pViewToggle.isOn)
        {
            pViewToggle.isOn = false;
        }
        _mController.OnClickBack();
    }
    /// <summary>
    /// next按钮
    /// </summary>
    private void _OnClickNextBtn()
    {
        if (!isModleCreat)
            return;
        ResetSetCameraPosition();
        this._mController.OnClickEnter(_randomName.text);
    }




    //临时添加和uirole重复，找时间合成一个

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

