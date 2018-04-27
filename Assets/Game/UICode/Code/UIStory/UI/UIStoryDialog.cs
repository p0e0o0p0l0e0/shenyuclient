using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class UIStoryDialog : UIStoryBase
{
    /// <summary>
    /// 对话框组件类
    /// </summary>
    [System.Serializable]
    public class StoryDialogUIComponent
    {
        /// <summary>
        /// 模式类型
        /// </summary>
        public StoryAppearanceData.AppearanceMode EMode;

        /// <summary>
        /// 父物体
        /// </summary>
        public GameObject ObjParent;

        /// <summary>
        /// 对话的内容
        /// </summary>
        public Text TxtStory;
        /// <summary>
        /// 说话人名称
        /// </summary>
        public Text TxtSpeakName;

        public Text TxtTimeRecord;
        /// <summary>
        /// 左头像
        /// </summary>
        public ExUITexture TexLeftHead;
        /// <summary>
        /// 右头像
        /// </summary>
        public ExUITexture TexRightHead;
        /// <summary>
        /// 名字背景
        /// </summary>
        public ExUISprite SpriteNameBG;
        /// <summary>
        /// 对话框样式图片
        /// </summary>
        public ExUISprite SpriteDialogBG;
        /// <summary>
        /// 点击事件的BUTTON
        /// </summary>
        public ExUIButton BtnNextStep;
        public ExUISprite SpriteNextStep;
        //public ExUIButton BtnJump;

        private TweenPosition _twPosition;

        private Vector3[] _v3NextStep = { new Vector3(510, -57.8f, 0) ,new Vector3(223,-57.8f,0)};
        private Vector3[] _v3TalkName = { new Vector3(-252, 48, 0), new Vector3(-539, 48, 0)};
        private Vector3[] _v3DialogContext = { new Vector3(139, -29, 0), new Vector3(-148, -29, 0) };

        public StoryDialogUIComponent(StoryAppearanceData.AppearanceMode mode, Transform trans,
            UnityAction nextCallBack,UnityAction jumpCallBack)
        {
            EMode = mode;
            ObjParent = trans.gameObject;
            TxtStory = trans.GetComponentPro<Text>(Txt_Dialog);
            TxtSpeakName = trans.GetComponentPro<Text>(Txt_RoleName);
            TxtTimeRecord = trans.GetComponentPro<Text>(Txt_TimeRecord);
            TexLeftHead = trans.GetComponentPro<ExUITexture>(Tex_Left);
            TexRightHead = trans.GetComponentPro<ExUITexture>(Tex_Right);
            SpriteDialogBG = trans.GetComponentPro<ExUISprite>(Sprite_DialogBG);
            SpriteNameBG = trans.GetComponentPro<ExUISprite>(Sprite_NameBG);
            SpriteNextStep = trans.GetComponentPro<ExUISprite>(Sprite_Next);

            if (IsNormalMode())
            {
                BtnNextStep = trans.GetComponentPro<ExUIButton>(Btn_Next);
                if (SpriteNextStep != null)
                    _twPosition = SpriteNextStep.GetComponent<TweenPosition>();
                BtnNextStep.SetActive(true);
                //BtnJump = trans.GetComponentPro<ExUIButton>(Btn_Jump);
                //BtnJump.SetActive(IsNormalMode());

                BtnNextStep.RemoveButtonAllListener();
                BtnNextStep.AddButtonListener(nextCallBack);

                //BtnJump.RemoveButtonAllListener();
                //BtnJump.AddButtonListener(jumpCallBack);
            }

            ObjParent.SetActive(false);
        }
        public void SetRenderTex(RenderTexture tex)
        {
            TexLeftHead.SetRawImageTexture(tex);
            TexRightHead.SetRawImageTexture(tex);
        }
        public void Open(StoryFunctionData.NEXT_TYPE type)
        {
            SetNextState(false);
            ObjParent.SetActive(true);
        }
        public void SetNextState(bool enable)
        {
            if (IsNormalMode())
            {
                SpriteNextStep.SetActive(enable);
            }
        }

        public void Close()
        {
            ObjParent.SetActive(false);
            TxtStory.SetTextContent("");
            TxtSpeakName.SetTextContent("");
            TxtTimeRecord.SetTextContent("");
        }
        public bool IsNormalMode()
        {
            return EMode == StoryAppearanceData.AppearanceMode.Normal;
        }
        public void SetLocation(StoryFunctionTextureTextData.HEAD_ACTOR type)
        {
            if (!IsNormalMode())
                return;

            TexLeftHead.gameObject.SetActive(type == StoryFunctionTextureTextData.HEAD_ACTOR.LEFT);
            TexRightHead.gameObject.SetActive(type != StoryFunctionTextureTextData.HEAD_ACTOR.LEFT);
            if(SpriteNextStep.IsNotNull())
                _v3NextStep[(int)type].y = SpriteNextStep.rectTransform.localPosition.y;
            SpriteNextStep.SetLocalRectPosition(_v3NextStep[(int)type]);
            SpriteNameBG.SetLocalRectPosition(_v3TalkName[(int)type]);
            TxtStory.SetLocalRectPosition(_v3DialogContext[(int)type]);
            if (_twPosition.IsNotNull())
            {
                _twPosition.from = new Vector3(_v3NextStep[(int)type].x, _twPosition.from.y, 0);
                _twPosition.to = new Vector3(_v3NextStep[(int)type].x, _twPosition.to.y, 0);
            }
        }
        public void Play(StoryAppearanceData data, bool moveIn,TweenCallback callBack)
        {
            if (IsNormalMode())
            {
                if(callBack != null)
                    callBack();
            }
            else
            {
                if (moveIn)
                {
                    ObjParent.transform.localPosition = data.startPoint;
                    ObjParent.transform.LocalMove(data.endPoint, data.moveInDuration, callBack);
                }
                else
                {
                    ObjParent.transform.localPosition = data.endPoint;
                    ObjParent.transform.LocalMove(data.startPoint, data.moveOutDuration, callBack);
                }
            }
        }
    }
    #region ui control name define
    private const string TransNormal = "NormalDialog";
    private const string TransSide = "SideDialog";
    private const string SpriteBG = "/sprite_BG";
    private const string SpriteMask = "/sprite_Mask";
    private const string TxtTitle = "/txt_Title";
    private const string TxtContext = "/txt_Context";
    private const string CamStoryModel = "/cam_StoryTex";

    private const string Txt_Dialog = "sprite_DialogBG/txt_Dialog";
    private const string Txt_RoleName = "sprite_DialogBG/sprite_NameBG/txt_RoleName";
    private const string Txt_TimeRecord = "btn_Next/txt_TimeRecord";
    private const string Tex_Left = "sprite_DialogBG/tex_Left";
    private const string Tex_Right = "sprite_DialogBG/tex_Right";
    private const string Sprite_DialogBG = "sprite_DialogBG";
    private const string Sprite_NameBG = "sprite_DialogBG/sprite_NameBG";
    private const string Sprite_Next = "sprite_DialogBG/sprite_Next";
    private const string Btn_Next = "btn_Next";
    private const string Btn_Jump = "btn_Jump";
    #endregion

    /// 正常对话数据
    private StoryDialogUIComponent _normalDialogCom;
    /// 侧边对话数据
    private StoryDialogUIComponent _sideDialogCom;
    /// 当前对话数据
    private StoryDialogUIComponent _currentDialogCom;
    public StoryDialogUIComponent CurrentDialogCom
    {
        get
        {
            if (_currentDialogCom == null)
            {
                if (_functionData == null)
                    return _normalDialogCom;

                switch (_functionData.textData.appearanceData.appearanceMode)
                {
                    case StoryAppearanceData.AppearanceMode.Normal:
                        _currentDialogCom = _normalDialogCom;
                        break;
                    case StoryAppearanceData.AppearanceMode.WipeInOut:
                        _currentDialogCom = _sideDialogCom;
                        break;
                }
            }
            return _currentDialogCom;
        }
        set { _currentDialogCom = value; }
    }

    /// <summary>
    /// 背景图
    /// </summary>
    private ExUITexture _spriteBG;
    /// <summary>
    /// 背景图切换图
    /// </summary>
    private ExUITexture _spriteMask;
    /// <summary>
    /// 有背景图时显示标题
    /// </summary>
    private Text _txtTitle;
    /// <summary>
    /// 有背景图时显示内容
    /// </summary>
    private Text _txtContext;
    /// <summary>
    /// 模型父物体
    /// </summary>
    private Camera _camStoryModel;
    /// <summary>
    /// 模型
    /// </summary>
    private GameObject _objCurrentShowModel;
    /// <summary>
    /// 是否开始播放
    /// </summary>
    private bool _isPlaying = false;

    private VoidDelegate _callBack;
    private StoryFunctionData _functionData;
    private StoryFunctionTextureTextData _data;
    
    private StoryTextOneByOne _OneByOne = new StoryTextOneByOne();
    private StoryPlayDialog _playDialog = new StoryPlayDialog();
    private ViTimeNode3 _node3 = new ViTimeNode3();

    private const uint span = 100;
    private const int per = 100;
    private uint remainTime = 0;

    public override void Initial(UIStoryWindow window, string topPath)
    {
        base.Initial(window, topPath);

        RenderTexture _renderTex = StoryManager.GetInstance.CreateRenderTexture();

        Transform normalTrans = window.FindTransform(TransNormal);
        Transform sideTrans = window.FindTransform(TransSide);
        if (normalTrans != null)
        {
            _normalDialogCom = new StoryDialogUIComponent(
                StoryAppearanceData.AppearanceMode.Normal,
                normalTrans, NextClick, Jump);
            _normalDialogCom.SetRenderTex(_renderTex);
        }
        if (sideTrans != null)
        {
            _sideDialogCom = new StoryDialogUIComponent(
                StoryAppearanceData.AppearanceMode.WipeInOut,
                sideTrans, NextClick, Jump);
            _sideDialogCom.SetRenderTex(_renderTex);
        }

        _spriteBG = this.GetComponent<ExUITexture>(SpriteBG);
        _spriteMask = this.GetComponent<ExUITexture>(SpriteMask);

        _txtTitle = this.GetComponent<Text>(TxtTitle);
        _txtContext = this.GetComponent<Text>(TxtContext);

        _camStoryModel = this.GetComponent<Camera>(CamStoryModel);
        _camStoryModel.targetTexture = _renderTex;
    }
    /// <summary>
    /// 显示插图剧情
    /// </summary>
    /// <param name="data">数据.</param>
    /// <param name="callBack">显示对话以后的回调.</param>
    public override void ShowUI(StoryFunctionData data, VoidDelegate callBack)
    {
        Reset();
        _functionData = data;
        _data = data.textData;
        _callBack = callBack;
        Open();
        _isPlaying = true;

        InitUI();
        CurrentDialogCom.Play(_data.appearanceData,true, StartDialog);
    }
    public void InitUI()
    {
        CurrentDialogCom.Open(_functionData.nextType);
        StoryDialogData dialogData = _functionData.textData.dialogData;
        StoryRoleData.ROLETYPE roleType = GetRoleType(dialogData.limitRoleType);
        int profession = StoryManager.GetInstance.GetPlayerProfessionID(roleType);
        StoryModelData modelData = (IsWomanLeader() ? dialogData.dialogFileData1 : 
            dialogData.dialogFileData).GetStoryFileData(roleType, profession);

        switch (roleType)
        {
            case StoryRoleData.ROLETYPE.LEAD:
                modelData.roleID = StoryManager.GetInstance.GetPlayerID();
                _data.dialogData.roleName = StoryManager.GetInstance.GetPlayerName();
                break;
            case StoryRoleData.ROLETYPE.ENEMY:
                VisualNPCStruct visualInfo = ViSealedDB<VisualNPCStruct>.Data(modelData.roleID);
                _data.dialogData.roleName = visualInfo.Name;
                break;
        }
        //说话名称
        CurrentDialogCom.TxtSpeakName.SetTextContent(_data.dialogData.roleName);

        //头像部分
        if (_data.headActor == StoryFunctionTextureTextData.HEAD_ACTOR.LEFT)
        {
            _camStoryModel.aspect = CurrentDialogCom.TexLeftHead.AspectRatio;
            NewSetHeadData(modelData, _camStoryModel.transform, roleType);
        }
        else
        {
            _camStoryModel.aspect = CurrentDialogCom.TexRightHead.AspectRatio;
            NewSetHeadData(modelData,_camStoryModel.transform, roleType);
        }
        CurrentDialogCom.SetLocation(_data.headActor);
        //对话框样式 由于策划要求UI去修改对话框，所以关闭代码控制代码
        //SetNewTexOrDefault(data.dialogStylePath, StoryStaticData.DialogStyleDefaultName, 
        //                  CurrentDialogCom.dialogStyle);

        //背景图开启渐变
        PlaySlowShow();
        //背景图
        bool setNewBG = SetNewTexOrNull(_data.backgroundTexData.texPath, _spriteBG);

        if (setNewBG)
        {
            SetTextStyle(_txtTitle, _data.titleContent);
            SetTextStyle(_txtContext, _data.subtitleContent);
            _OneByOne.Play();
        }
        if (modelData.IsNotNull())
        {
            IStoryCharacter character = StoryManager.GetInstance.GetCharacter(modelData.roleData);
            if (character.IsNotNull())
            {
                character.Play(AnimationData.Talk01);
            }
        }
    }
    /// <summary>
    /// 开始插图剧情
    /// </summary>
    private void StartDialog()
    {
        StoryDialogData dialogData = _data.dialogData;
        StoryRoleData.ROLETYPE roleType = GetRoleType(dialogData.limitRoleType);
        //文本对话内容
        int profession = StoryManager.GetInstance.GetPlayerProfessionID(roleType);
        StorySoundData dialogAndSoundData = (IsWomanLeaderOrAttachWomanLeader() ?
            dialogData.soundData1 : dialogData.soundData).GetStoryFileData(roleType, profession);

        _playDialog.SetStoryTextData(CurrentDialogCom.TxtStory.gameObject, 
            CurrentDialogCom.TxtStory, dialogAndSoundData.storyTextArray, dialogAndSoundData.waitTime, CurrentDialogCom.IsNormalMode());
        _playDialog.PlayDialog(_OnDialogEndCallBack, !CurrentDialogCom.IsNormalMode());
        //语音部分
        audioLength = dialogAndSoundData.soundDuration;
        StoryManager.GetInstance.PlaySound(dialogAndSoundData.soundID);
        //最长时间
        maxWaitTime = _playDialog.totalWaitTime > audioLength ? _playDialog.totalWaitTime : audioLength;
        ProTextFunction();
    }
    private void _OnDialogEndCallBack()
    {
        CurrentDialogCom.SetNextState(true);
    }
    /// <summary>
    /// 点击回调
    /// </summary>
    private void NextClick()
    {
        int flag = _playDialog.ForceChangeState();

        if (flag == 0)
        {
            _playDialog.Reset();
            EndSound();
            EndText();
            WipeOutDone();
        }
        else if(flag == -1)
        {
            _OnDialogEndCallBack();
        }
    }
    /// <summary>
    /// 跳过 结束剧情
    /// </summary>
    private void Jump()
    {
        StoryCondition sc = _functionData.transform.parent.GetComponent<StoryCondition>();
        if (sc != null)
            sc.Stop();
    }
    public void Stop()
    {
        Reset();
        Close();
    }
    private void Reset()
    {
        EndSound();
        EndText();
        _playDialog.Reset();
        _isPlaying = false;
        CurrentDialogCom.Close();
        CurrentDialogCom = null;
        _node3.Detach();
        remainTime = 0;
    }
    /// <summary>
    /// 下一步
    /// </summary>
    private void ProTextFunction()
    {
        switch (_functionData.nextType)
        {
            case StoryFunctionData.NEXT_TYPE.TIME:
                {
                    if (_functionData.nextTime > maxWaitTime)
                        maxWaitTime = _functionData.nextTime;

                    CurrentDialogCom.TxtTimeRecord.SetTextContent(maxWaitTime.ToString());
                    remainTime = (uint)Mathf.CeilToInt(maxWaitTime * per);
                    uint count = remainTime / span;
                    _node3.Start(ViTimerInstance.Timer, count, span);
                    _node3.TickDelegate = _OnWaitTick;
                    _node3.EndDelegate = _OnWaitTimeDone;
                }
                break;
        }
    }
    private void _OnWaitTick(ViTimeNodeInterface nodeInterface)
    {
        if (_isPlaying)
        {
            remainTime =remainTime - span;
            CurrentDialogCom.TxtTimeRecord.SetTextContent(((uint)(remainTime / per)).ToString());
        }
    }
    /// <summary>
    /// 等待几秒
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private void _OnWaitTimeDone(ViTimeNodeInterface nodeInterface)
    {
        CurrentDialogCom.TxtTimeRecord.SetTextContent("");
        if (_isPlaying)
            WipeOutDone();
    }
    private void WipeOutDone()
    {
        _isPlaying = false;
        _node3.Detach();
        CurrentDialogCom.TxtTimeRecord.SetTextContent("");
        CurrentDialogCom.Play(_data.appearanceData, false, () =>
        {
            PlaySlowDisappear();
            EndCallBack();
        });
    }
    /// <summary>
    /// 结束回调
    /// </summary>
    private void EndCallBack()
    {
        if (_callBack != null)
            _callBack();
    }
    /// <summary>
    /// 新的设置头像数据
    /// </summary>
    /// <param name="modelData"></param>
    /// <param name="model"></param>
    /// <param name="texture"></param>
    private void NewSetHeadData(StoryModelData modelData,Transform parent, StoryRoleData.ROLETYPE type)
    {
        if (_objCurrentShowModel == null ||
             _data.dialogData.limitRoleType == StoryDialogData.LimitRoleType.None  && 
            !_objCurrentShowModel.name.Equals(StoryStaticData.HeadModelFileDefault) ||
            _data.dialogData.limitRoleType != StoryDialogData.LimitRoleType.None && 
            !_objCurrentShowModel.name.Equals(modelData.roleID))
            _objCurrentShowModel = SetNewModelOrDefault(_data.dialogData.limitRoleType,modelData.roleID, 
                parent, modelData.headModelSizePercent, modelData.modelLocalPos,_OnModelLoadedCallBack);
        PlayModelAnimation();
    }
    private void _OnModelLoadedCallBack(GameObject obj)
    {
        _objCurrentShowModel = obj;
        PlayModelAnimation();
    }

    private void PlayModelAnimation()
    {
        if (_objCurrentShowModel == null)
        {
            return;
        }
        Animation anim = _objCurrentShowModel.GetComponentInChildren<Animation>();

        if (anim != null)
        {
            if (anim.GetClip(AnimationData.Talk01) != null)
            {
                anim.Play(AnimationData.Talk01);
            }
            else
            {
                UConsole.Log("[Error] 插图模型不包含此动画名称，name：" + AnimationData.Talk01,Color.red);
            }
        }
    }
    /// <summary>
    /// 是否是女主角
    /// </summary>
    /// <returns></returns>
    private bool IsWomanLeader()
    {
        return _data.dialogData.isDistinguish &&
            _data.dialogData.limitRoleType == StoryDialogData.LimitRoleType.Leader &&
                    StoryManager.GetInstance.GetPlayerGender() == 1;
    }
    /// <summary>
    /// 是否是女主角或者怪物遇到女主角
    /// </summary>
    /// <returns></returns>
    private bool IsWomanLeaderOrAttachWomanLeader()
    {
        return _data.dialogData.isDistinguish &&
          (_data.dialogData.limitRoleType == StoryDialogData.LimitRoleType.Leader ||
                    _data.dialogData.limitRoleType == StoryDialogData.LimitRoleType.Monster) &&
                    StoryManager.GetInstance.GetPlayerGender() == 1;
    }
    /// <summary>
    /// 获取对应人物类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private StoryRoleData.ROLETYPE GetRoleType(StoryDialogData.LimitRoleType type)
    {
        switch (type)
        {
            case StoryDialogData.LimitRoleType.Leader:
                return StoryRoleData.ROLETYPE.LEAD;
            case StoryDialogData.LimitRoleType.None:
                return StoryRoleData.ROLETYPE.HERO;
            default:
                return StoryRoleData.ROLETYPE.ENEMY;
        }
    }

    /// <summary>
    /// 渐显
    /// </summary>
    private void PlaySlowShow()
    {
        if (IsPlaySlowShow(_data.backgroundTexData.showTextureType, _functionData.nextTime,
            _data.backgroundTexData.showDuration, _data.backgroundTexData.texPath, false))
            StartSlowChangeTexState(_spriteBG, _data.backgroundTexData.showDuration, true);
    }
    /// <summary>
    /// 渐隐
    /// </summary>
    /// <returns></returns>
    private float PlaySlowDisappear()
    {
        if (IsPlaySlowDisappear(_data.backgroundTexData.hideTextureType, 
            _data.backgroundTexData.hideDuration, _data.backgroundTexData.texPath, false))
        {
            SetNewTexOrNull(_data.backgroundTexData.texPath, _spriteMask);
            StartSlowChangeTexState(_spriteMask, _data.backgroundTexData.hideDuration, false);
            return _data.backgroundTexData.hideDuration;
        }
        else
        {
            _spriteMask.SetRawImageTexture(null);
            return 0;
        }
    }
    
    private void SetTextStyle(Text label, StoryTextData textData)
    {
        switch (textData.textPositionType)
        {
            case StoryTextData.TextPositionType.Middle:
                label.alignment = TextAnchor.MiddleCenter;
                break;
            case StoryTextData.TextPositionType.Left:
                label.alignment = TextAnchor.MiddleLeft;
                break;
            case StoryTextData.TextPositionType.Right:
                label.alignment = TextAnchor.MiddleRight;
                break;
            default:
                break;
        }
        switch (textData.showTextType)
        {
            case StoryTextData.ShowTextType.Direct:
                label.SetTextContent(textData.showContext);
                break;
            case StoryTextData.ShowTextType.OneByOne:
                if (!string.IsNullOrEmpty(textData.showContext) &&
                    textData.showContext.Length > 1)
                    _OneByOne.Init(label,textData.showContext,textData.interval);
                else
                    label.SetTextContent(textData.showContext);
                break;
            default:
                break;
        }
    }
    private void EndText()
    {
        _OneByOne.ForceEnd();
        _txtTitle.SetTextContent("");
        _txtContext.SetTextContent("");
    }
}
