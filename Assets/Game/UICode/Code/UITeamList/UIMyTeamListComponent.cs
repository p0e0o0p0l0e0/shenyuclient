using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMyTeamListComponent : UIWindowComponent<UITeamListWindow, UITeamListController>
{
    public class CameraAndTexture
    {
        public ulong modelId { set; get; }
        public Camera modelCamera { set; get; }
        public Avatar palyer { set; get; }
        public RenderTexture render { set; get; }

        public void SetCamera(Camera camera)
        {
            if (modelCamera == null)
                modelCamera = camera;
            if (render == null)
            {
                render = new RenderTexture(210, 398, 0);
                modelCamera.targetTexture = render;
            }
        }

        public void CreatAvata(PartyMemberStruct menber)
        {
            if (palyer == null)
            {
                palyer = new Avatar();
                palyer.LoadCallback = LoadBack;
                AvatarCreator.Create(palyer, menber.Gender,(int)menber.HeroClass, 1.0f, new List<int>());
            }
        }


        private void LoadBack(Avatar avatar)
        {
            Transform parent = modelCamera.transform;
            avatar.RootTran.parent = parent;
            UnityAssisstant.SetLayerRecursively(avatar.Root, (int)UnityLayer.UI_Model);
            avatar.Root.name = "HeroAvatar";
            avatar.RootTran.localPosition = new Vector3(0, -107, 265);
            avatar.RootTran.localRotation = Quaternion.Euler(0, 180, 0);
            // avatar.Anim.Play(AnimationData.Show04);
            avatar.PlayActionAnim(AnimationData.Show04, true);
            avatar.ChangeUIShander();
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Release()
        {
            render.Release();
            if (palyer != null)
                palyer.Clear();
        }
    }
    private const string teamList = "TeamList/Content";
    private const string applyListBtn = "ApplyListBtn";
    private const string teamFollowBtn = "TeamFollowBtn";
    private const string autoMactch = "AutoMatchingToggle";//自动匹配
    private const string autoGround = "/Background";
    private const string autoMatchMark = "/Checkmark";
    private const string exitTeam = "ExitTeamBtn";
    private const string topTargetBtn = "Top/TypeBG";
    private const string topTargetText = "Top/TypeBG/Text";
    private const string topShoutBtn = "Top/ShoutBtn";
    private const string shoutType = "Top/ShoutType";
    private const string currentChannel = "Top/ShoutType/CurrentChannel";
    private const string amryChannel = "Top/ShoutType/AmryChannel";
    private const string teamChannel = "Top/ShoutType/TeamChannel";
    private const string teamItem = "TeamList/Content/";
    private const string entryCopies = "Entry";

    private const string havePlayer = "/HavePlayer";
    private const string itemJob = "/Job";
    private const string itemLevel = "/Level";
    private const string itemIsLeader = "/Leader";
    private const string itemMode = "/Mode";
    private const string itemName = "/Name";
    private const string noPlayer = "/NoPlayer";
    private const string noPlayerAddBtn = "/AddBtn";

    private const string buttonBg = "ButtonBg";
    private const string addBtn = "/ButtonGrid/AddBtn";
    private const string sendBtn = "/ButtonGrid/SendBtn";
    private const string appointBtn = "/ButtonGrid/AppointBtn";
    private const string leaveBtn = "/ButtonGrid/LeaveBtn";

    private const string targetPanel = "ClickTarget";
    private const string targetType = "/CopyTypeList";
    private const string taskType = "/TaskTypeList";

    private const string applyList = "ApplyList";
    private const string applyLoop = "/TeamList";
    private const string applyClose = "/Black";
    private const string cameraList = "CameraList";

    private List<CameraAndTexture> avataList;

    private int currSelectModel = -1;

    private PlayerAutoFollow follow;
    public override void Initial(UITeamListWindow window, string topPath)
    {
        base.Initial(window, topPath);
        this.GetComponent<ExUIButton>(applyListBtn).onClickEx = OnClickApplyBtn;
        this.GetComponent<ExUIButton>(teamFollowBtn).onClickEx = OnClickTeamFollow;
        this.GetComponent<ExUIButton>(autoMactch + autoGround).onClickEx = AutoMatch;
        this.GetComponent<ExUIButton>(exitTeam).onClickEx = OnClickExitTeam;
        this.GetComponent<ExUIButton>(topTargetBtn).onClickEx = OnClickoTarget;
        this.GetComponent<ExUIButton>(topShoutBtn).onClickEx = OnClickShot;
        this.GetComponent<ExUIButton>(currentChannel).onClickEx = OnClickCurrChannel;
        this.GetComponent<ExUIButton>(amryChannel).onClickEx = OnClickArmyChannel;
        this.GetComponent<ExUIButton>(teamChannel).onClickEx = OnClickTeamChannel;
        this.GetComponent<ExUIButton>(entryCopies).onClickEx = OnClickGotoTarget;
        this.GetComponent<ExUIButton>(buttonBg + addBtn).onClickEx = OnClickAddFriend;
        this.GetComponent<ExUIButton>(buttonBg + sendBtn).onClickEx = OnClickSendMeaasge;
        this.GetComponent<ExUIButton>(buttonBg + appointBtn).onClickEx = OnClickToLeader;
        this.GetComponent<ExUIButton>(buttonBg + leaveBtn).onClickEx = OnClickLeaveTeam;
        this.GetComponent<LoopVerticalScrollRect>(targetPanel + targetType).Init(RushTargetType, 10);
        this.GetComponent<LoopVerticalScrollRect>(targetPanel + taskType).Init(RushTaskType, 10);
        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(applyList + applyLoop);
        loop.Init(RushApplyItem, 0);
        this.GetComponent<ExUIButton>(applyList + applyClose).onClickEx = OnClickClose;
        ExUIButton btn;
        for (int i = 0; i < 5; i++)
        {
            btn = this.GetComponent<ExUIButton>(teamItem + i.ToString() + havePlayer + itemMode);
            btn.Id = i;
            btn.onClickEx = OnClickModel;
            btn = this.GetComponent<ExUIButton>(teamItem + i.ToString() + noPlayer + noPlayerAddBtn);
            btn.Id = 1;
            btn.onClickEx = OnClickNoPlayer;
        }
        avataList = new List<CameraAndTexture>();
        for (int i = 0; i < this.GetComponent<Transform>(cameraList).childCount; i++)
        {
            CameraAndTexture cam = new CameraAndTexture();
            Camera ca = this.GetComponent<Camera>(cameraList + "/" + i);
            if (ca != null)
                cam.SetCamera(ca);
            else
                ViDebuger.Note("没有找到camera");
            avataList.Add(cam);
        }
        follow = new PlayerAutoFollow();
    }
    public void SetActive(bool isTrue)
    {
        if (isTrue)
        {
            EventDispatcher.AddEventListener(Events.PartyEvent.PartyTargetChange, RushTargetText);
            EventDispatcher.AddEventListener(Events.PartyEvent.PartyJoinChange, RushAutoMatch);
            EventDispatcher.AddEventListener(Events.PartyEvent.MemberChange, RushAllTeam);
            RushAllTeam();
            RushAutoMatch();
            RushTargetText();
            ShowOrHileTarget(false);
            SetButtonShow(false);
        }
        else
        {
            EventDispatcher.RemoveEventListener(Events.PartyEvent.PartyTargetChange, RushTargetText);
            EventDispatcher.RemoveEventListener(Events.PartyEvent.PartyJoinChange, RushAutoMatch);
            EventDispatcher.RemoveEventListener(Events.PartyEvent.MemberChange, RushAllTeam);
        }
    }

    #region 刷新队伍信息
    private void RushAllTeam()
    {
        for (int i = 0; i < PartyInstance.Instance.MaxMemberCount; i++)
        {
            ChangeAvataData(i);
            RushTeamInfoItem(i);
        }


    }

    /// 刷新第index 个人物item
    private void RushTeamInfoItem(int index)
    {
        string path = teamItem + index.ToString();
        PartyMemberStruct menber = PartyInstance.GetMember(index);
        if (menber != null)
        {
            SetPlayerItemShow(path, true);
            path = path + havePlayer;
            SetIsLeader(path, menber.IsLeader);
            this.GetComponent<ExUISprite>(path + itemJob).SpriteName=ViSealedDB<VisualCorner>.Data(menber.Gender*6+ (byte)menber.HeroClass).professionIcon+"1";
            this.GetComponent<ExText>(path + itemLevel).text = menber.Level.ToString();
            this.GetComponent<ExText>(path + itemName).text = menber.NameAlias;
            this.GetComponent<ExUITexture>(path + itemMode).texture = avataList[index].render;
        }
        else
        {
            SetPlayerItemShow(path, false);
        }
    }

    private void SetPlayerItemShow(string path, bool isHave)
    {
        this.GetComponent<Transform>(path + havePlayer).SetActive(isHave);
        this.GetComponent<Transform>(path + noPlayer).SetActive(!isHave);
    }

    private void SetIsLeader(string path, bool isle)
    {
        this.GetComponent<Transform>(path + itemIsLeader).SetActive(isle);
    }

    //修改人数模型的数据
    private void ChangeAvataData(int index)
    {
        PartyMemberStruct menber = PartyInstance.GetMember(index);
        if (menber == null) //没有数据
        {
            if (avataList[index].palyer != null)
            {
                avataList[index].palyer.Clear();
                avataList[index].palyer = null;
            }
            avataList[index].modelId = ulong.MaxValue;
        }
        else //有数据
        {
            int dex = avataList.FindIndex((CameraAndTexture patty) => { return patty.modelId == menber.ID; });
            if (dex >= 0)//找到相同
            {
                CameraAndTexture tex = avataList[dex];
                avataList.RemoveAt(dex);
                avataList.Insert(index, tex);
            }
            else //不存在相同
            {
                avataList[index].modelId = menber.ID;
                avataList[index].CreatAvata(menber);
            }
        }
    }

    #endregion

    #region  界面下方按钮
    /// 申请列表按钮
    private void OnClickApplyBtn(int id, object obj)
    {
        this.GetComponent<Transform>(applyList).SetActive(true);
        EventDispatcher.AddEventListener(Events.PartyEvent.PartyApplyChange, RushApply);
        RushApply();
    }
    //刷新是否匹配
    private void RushAutoMatch()
    {
        if (PartyInstance.Instance.Property.AgreeJoinPartyLazy.Value == 0)//禁止
            this.GetComponent<Transform>(autoMactch + autoMatchMark).SetActive(false);
        else if (PartyInstance.Instance.Property.AgreeJoinPartyLazy.Value == 1)
            this.GetComponent<Transform>(autoMactch + autoMatchMark).SetActive(true);
    }

    /// 自动匹配
    private void AutoMatch(int id, object obj)
    {
        if (PartyInstance.Instance.IsLeader)
        {
            if (PartyInstance.Instance.Property.AgreeJoinPartyLazy == 0)//禁止
                PlayerServerInvoker.AgreeJoinPartyLazy(Player.Instance, 1);
            else if (PartyInstance.Instance.Property.AgreeJoinPartyLazy == 1)
                PlayerServerInvoker.AgreeJoinPartyLazy(Player.Instance, 0);
        }
        else
            UIManagerUtility.ShowHint("没有权限修改");
    }
    /// 队伍跟随
    private void OnClickTeamFollow(int id, object obj)
    {
        //PlayerAutoFollow
    }
    /// 退出队伍
    private void OnClickExitTeam(int id, object obj)
    {
        PartyInstance.ExitParty();
        _mWindow.ShowTeamList(true);
    }
    //刷新进入
    private void RushGoToTarget()
    {
        this.GetComponent<ExUIButton>(entryCopies).gameObject.SetActive(PartyInstance.Instance.IsLeader);
    }
    //进入副本
    private void OnClickGotoTarget(int id, object obj)
    {
        if (PartyInstance.Instance.IsLeader) //进入副本
        {

            TaskStruct task = ViSealedDB<TaskStruct>.Data((int)PartyInstance.Instance.Property.Target.Value);
            bool isOk = true;
            for (int i = 0; i < PartyInstance.Instance.MaxMemberCount; i++)
            {
                PartyMemberStruct stru = PartyInstance.GetMember(i);
                if (stru != null&&(stru.Level < task.LowLevel || stru.Level > task.HightLevel))
                        isOk = false;
            }
            if (isOk)
            {
                SpaceObjectBirthPositionStruct birthPos = ViSealedDB<TaskStruct>.Data((int)PartyInstance.Instance.Property.Target.Value).SpacePosition.Data;
                PlayerServerInvoker.GotoBigSpaceWithParty(Player.Instance, (uint)birthPos.Space.Data.ID,(uint) birthPos.ID);      
            }
        }
        else
        {

        }

    }

    #endregion

    #region  目标点击的处理和逻辑 和目标相关 去目标和发送广播回调等
    int severClickType = -1;//服务器保存的类型
    int lastClickType = -1;//界面当前点击的类型
    int lastClickTask = -1;//点击的任务
    /// 更换目标
    private void OnClickoTarget(int id, object obj)
    {
        if (PartyInstance.IsLeader)
        {
            if (!this.GetComponent<Transform>(targetPanel).gameObject.activeSelf)
            {
                lastClickTask = (int)PartyInstance.Instance.Property.Target.Value % 10;
                ShowOrHileTarget(true);
                GetAllTaskName();
                LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(targetPanel + targetType);
                loop.ChangeTotalCount(taskNameList.Count);
                loop.RefillCells();
                OnClickTargetType(0, GetComponent<ExUIButton>(targetPanel + targetType + "/Content/0"));
            }
            else
            {
                ShowOrHileTarget(false);
            }
        }
    }
    //显示
    private void ShowOrHileTarget(bool isShow)
    {
        Transform trans = this.GetComponent<Transform>(targetPanel);
        trans.SetActive(isShow);
    }
    //刷新上面的目标text
    private void RushTargetText()
    {
        RushTargetText(ViSealedDB<TaskStruct>.Data((int)PartyInstance.Instance.Property.Target.Value).TaskName);
    }
    private void RushTargetText(string target)
    {
        this.GetComponent<ExText>(topTargetText).text = target;
    }
    //刷新单个格子类型
    private void RushTargetType(string name, int index)
    {
        string path = targetPanel + targetType + "/Content/" + name;
        this.GetComponent<ExText>(path + "/Select/Text").text = this.GetComponent<ExText>(path + "/Text").text = taskNameList[index];
        ExUIButton btn = this.GetComponent<ExUIButton>(path);
        btn.Id = index;
        btn.onClickEx = OnClickTargetType;
        if (lastClickType == index)
            this.GetComponent<Transform>(path + "/Select").SetActive(true);
        else
            this.GetComponent<Transform>(path + "/Select").SetActive(false);
    }
    //点击类型
    private void OnClickTargetType(int id, object ob)
    {
        string path = targetPanel + targetType + "/Content/";
        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(targetPanel + targetType);
        if (lastClickType != -1)
        {
            string trns = loop.GetNodeNameByIndex(lastClickType);
            if (!string.IsNullOrEmpty(trns))
                GetComponent<Transform>(path + trns + "/Select").gameObject.SetActive(false);
        }
        lastClickType = id;
        ExUIButton obj = ob as ExUIButton;
        this.GetComponent<Transform>(path + obj.gameObject.name + "/Select").SetActive(true);
        int count = GetTaskCount(lastClickType);
        LoopVerticalScrollRect taskloop = this.GetComponent<LoopVerticalScrollRect>(targetPanel + taskType);
        taskloop.ChangeTotalCount(count);
        taskloop.RefillCells();
    }
    //刷新任务
    private void RushTaskType(string name, int index)
    {
        string path = targetPanel + taskType + "/Content/" + name;
        TaskStruct task = GetTaskData(lastClickType, index);
        this.GetComponent<ExText>(path + "/NameText").text = task.TaskName;
        this.GetComponent<ExText>(path + "/DiffLevelText").text = GetDiffById(task.Difficulty);
        this.GetComponent<ExText>(path + "/DiffLevelText").color = GetColorById(task.Difficulty);
        this.GetComponent<ExText>(path + "/LvLimitText").text = task.LowLevel + "--" + task.HightLevel;
        ExUIButton btn = this.GetComponent<ExUIButton>(path + "/Click");
        btn.Id = task.ID;
        btn.onClickEx = OnClickTask;
        if (severClickType != -1 && severClickType == lastClickType)
        {
            if (index == lastClickTask)
                this.GetComponent<Transform>(path + "/Select").SetActive(true);
            else
                this.GetComponent<Transform>(path + "/Select").SetActive(false);
        }
        else
        {
            this.GetComponent<Transform>(path + "/Select").SetActive(false);
        }
    }
    private string GetDiffById(int id)
    {
        if (id == 0)
            return I18NManager.Instance.GetWord("tips_207");
        else if (id == 1)
            return I18NManager.Instance.GetWord("tips_208");
        else if (id == 2)
            return I18NManager.Instance.GetWord("tips_209");
        return "";
    }
    private Color32 GetColorById(int id)
    {
        if (id == 0)
            return new Color32(134, 211, 43, 255);
        else if (id == 1)
            return new Color32(37, 106, 190, 255);
        else if (id == 2)
            return new Color32(230, 67, 67, 255);
        return new Color32(255, 255, 255, 255);
    }
    //任务点击
    private void OnClickTask(int id, object ob)
    {
        //设置服务
        TaskStruct task = ViSealedDB<TaskStruct>.Data(id);
        if (id != severClickType * 10 + lastClickTask && CellHero.LocalHero.Property.Level >= task.LowLevel && CellHero.LocalHero.Property.Level <= task.HightLevel)
        {
            PlayerServerInvoker.SetPartyTarget(Player.Instance, (ulong)id);
            ShowOrHileTarget(false);
            severClickType = lastClickType;//本该服务器返回之后设置
                                           //RushTargetText(ViSealedDB<TaskStruct>.Data(id).TaskName);//刷新上面(等服务器返回)
            string path = targetPanel + taskType + "/Content/";
            ExUIButton obj = ob as ExUIButton;
            this.GetComponent<Transform>(path + "/" + obj.gameObject.name + "/Select").SetActive(true);
            if (severClickType != -1 && severClickType == lastClickType)
            {
                LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(targetPanel + taskType);
                string trns = loop.GetNodeNameByIndex(lastClickTask);
                if (!string.IsNullOrEmpty(trns))
                    GetComponent<Transform>(path + trns + "/Select").gameObject.SetActive(false);
            }
            lastClickTask = id % 10;
        }
        else
        {
            UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_178"));
        }

    }
    ///喊话
    private void OnClickShot(int id, object obj)
    {
        ShowOrHileShoutType(!IsShoutTypeShow());
    }
    private bool IsShoutTypeShow()
    {
        return this.GetComponent<Transform>(shoutType).gameObject.activeSelf;
    }

    private void ShowOrHileShoutType(bool isshow)
    {
        Transform trans = this.GetComponent<Transform>(shoutType);
        trans.SetActive(isshow);
    }
    /// 当前频道
    private void OnClickCurrChannel(int id, object obj)
    {
        ShowOrHileShoutType(false);
    }
    /// 军团频道
    private void OnClickArmyChannel(int id, object obj)
    {
        ShowOrHileShoutType(false);
    }
    /// 团队语音
    private void OnClickTeamChannel(int id, object obj)
    {
        ShowOrHileShoutType(false);
    }
    /// 前往目标

    protected bool IsPointUseful(ViVector3 viv3)
    {
        return !viv3.Equals(ViVector3.ZERO);
    }

    #endregion

    #region 点击模型和框的时候显示的按钮点击回调
    /// 人物模型点击
    private void OnClickModel(int id, object obj)
    {
        if (!PartyInstance.IsMe(PartyInstance.GetMember(id).ID))
        {
            if (currSelectModel == id)
            {
                SetButtonShow(false);
            }
            else
            {
                currSelectModel = id;
                Transform trans = this.GetComponent<Transform>(teamItem + id.ToString() + havePlayer + itemMode);
                ShowSelectBtnList(trans);
            }
        }
    }
    //显示按钮list的列表
    private void ShowSelectBtnList(Transform trans)
    {
        SetButtonShow(true);
        //一堆判断按钮是否显示的条件
        this.GetComponent<Transform>(buttonBg).position = trans.position;
    }
    //加为好友
    private void OnClickAddFriend(int id, object obj)
    {
        ulong Id = PartyInstance.GetMember(currSelectModel).ID;
        if (!PlayerFriendList.Instance.GetIsFriendById(Id))
        {
            PlayerCommandInvoker.AddFriend(Player.Instance, Id);
        }
        SetButtonShow(false);
    }
    //发送消息
    private void OnClickSendMeaasge(int id, object obj)
    {
        SetButtonShow(false);
    }
    //委任队长
    private void OnClickToLeader(int id, object obj)
    {
        if (PartyInstance.Instance.IsLeader)
        {
            PlayerServerInvoker.DeputePartyLeader(Player.Instance, PartyInstance.GetMember(currSelectModel).ID);
            SetButtonShow(false);
        }
        else
            UIManagerUtility.ShowHint("没有权限修改");

    }
    //请离队伍
    private void OnClickLeaveTeam(int id, object obj)
    {
        if (PartyInstance.Instance.IsLeader)
        {
            PartyInstance.RemoveMemberFromParty(PartyInstance.GetMember(currSelectModel).ID);
            SetButtonShow(false);
        }
        else
            UIManagerUtility.ShowHint("没有权限修改");
    }


    private void SetButtonShow(bool isShow)
    {
        Transform btn = this.GetComponent<Transform>(buttonBg);
        btn.SetActive(isShow);
        if (!isShow)
            currSelectModel = -1;
    }
    /// <summary>
    /// 邀请进入
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    private void OnClickNoPlayer(int id, object obj)
    {
        UIManagerUtility.ShowTeamInviteFriend();
    }
    #endregion

    #region taskStrust表的处理
    List<string> taskNameList = new List<string>();

    //获得所有的类型
    private void GetAllTaskName()
    {
        taskNameList.Clear();
        List<TaskStruct> task = ViSealedDB<TaskStruct>.Array;
        for (int i = 0; i < task.Count; i++)
        {
            string type = task[i].TypeName;
            if (!taskNameList.Contains(type))
                taskNameList.Add(type);
        }
    }

    //获得这个个数
    private int GetTaskCount(int type)
    {
        int count = 0;
        for (int i = 0; i < 10; i++)
        {
            int id = type * 10 + i;
            if (ViSealedDB<TaskStruct>.IsContainId(id))
            {
                count++;
            }
        }
        return count;
    }
    //根据类型和id 获得数据
    private TaskStruct GetTaskData(int type, int index)
    {
        if (ViSealedDB<TaskStruct>.Data(type * 10 + index).NotNull())
        {
            return ViSealedDB<TaskStruct>.Data(type * 10 + index);
        }
        return null;
    }

    #endregion

    #region 申请列表相关
    private void RushApply()
    {
        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(applyList + applyLoop);
        loop.ChangeTotalCount(PartyInstance.Instance.Property.RequestList.Count);
        loop.RefillCells();
    }

    private void RushApplyItem(string name, int index)
    {
        string path = applyList + applyLoop + "/Content/" + name;
        ReceiveDataPartyMemberProperty pro = PartyInstance.Instance.Property.RequestList[index].Property;
        this.GetComponent<ExText>(path + "/Name").text = pro.Identification.NameAlias;
        this.GetComponent<ExUISprite>(path + "/Head").SpriteName = ViSealedDB<VisualCorner>.Data((int)pro.Gender * 6 + (int)pro.Class).iconName;
        this.GetComponent<ExUISprite>(path + "/Job").SpriteName=ViSealedDB<VisualCorner>.Data(pro.Gender*6+ (byte)pro.Class).professionIcon+"1";
        this.GetComponent<ExText>(path + "/Level").text = pro.Level.Value.ToString();
        this.GetComponent<ExText>(path + "/BattleNumText").text = pro.Power.Value.ToString();
        this.GetComponent<Transform>(path + "/On_Line").SetActive(pro.Online == 0 ? true : false);
        ExUIButton btn = this.GetComponent<ExUIButton>(path + "/AcceptBtn");
        btn.Id = index;
        btn.onClickEx = OnClickAccept;
        btn = this.GetComponent<ExUIButton>(path + "/RefuseBtn");
        btn.Id = index;
        btn.onClickEx = OnClickRefuse;
    }

    private void OnClickAccept(int id, object obj)
    {
        PartyInstance.AgreeHeJoinParty(id);
    }
    private void OnClickRefuse(int id, object obj)
    {
        PartyInstance.DisagreeHeJoinParty(id);
    }

    private void OnClickClose(int index, object obj)
    {
        EventDispatcher.RemoveEventListener(Events.PartyEvent.PartyApplyChange, RushApply);
        this.GetComponent<Transform>(applyList).SetActive(false);
    }
    #endregion
    public override void Dispose()
    {
        base.Dispose();
    }
}
