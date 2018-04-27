using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/********************************************************************
	created:	2018/02/01
	created:	1:2:2018   15:04
	filename: 	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat\UIMainChatComWin.cs
	file path:	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat
	file base:	UIMainChatComWin
	file ext:	cs
	author:		meixuelei
	
	purpose:	聊天主窗口 （主界面左边）
*********************************************************************/
public partial class UIMainChatComWin : UIChatComponentWin
{
    private const string BottomRoot = "/Bottom/";
    private const string InputPath = BottomRoot + "Server/Input";
    private const string ExpressionBtn = BottomRoot + "Server/ExpressionBtn"; // 表情按钮
    private const string SendBtnPath = BottomRoot + "Server/SendBtn";
    private const string ExpressionAndHistory = "/ExpressionAndHistory"; // 表情列表
    private const string VoiceBtn = InputPath + "/VoiceBtn"; // 语音按钮

    private const string SettingBtn = "/SettingBtn"; // 设置按钮
    private const string SettingViewPath = "/ChannelSetting"; // 设置界面节点
    private const string ExpressionPath = ExpressionAndHistory + "/BG/ExpressionList/Content/"; // 表情
    private const string ChatOpenBtn = "/CloseBtn";

    #region  频道设置界面

    private const string SettingChannelRoot = SettingViewPath + "/ChannelGrid/";
    private const string SettingPrivate = SettingChannelRoot + "private"; // 私聊
    private const string SettingNear = SettingChannelRoot + "near"; // 附近
    private const string SettingTeam = SettingChannelRoot + "team"; // 队伍
    private const string SettingLegion = SettingChannelRoot + "legion"; // 军团
    private const string SettingSuit = SettingChannelRoot + "suit"; //本服
    private const string SettingWorld = SettingChannelRoot + "world"; // 世界
    private const string SettingSystem = SettingChannelRoot + "system"; // 系统
    private const string SettingViewOkBtn = SettingViewPath + "/BG/OKBtn"; // 确定按钮 

    #endregion  频道设置界面

    #region 频道切换

    private const string LeftBtnRoot = "/LeftBtn";
    private const string PrivateChatBtn = LeftBtnRoot + "/PrivateChatBtn"; // 私聊频道
    private const string NearbyBtn = LeftBtnRoot + "/NearbyBtn"; // 附近频道
    private const string TeamBtn = LeftBtnRoot + "/TeamBtn"; // 队伍频道
    private const string ArmyGroupBtn = LeftBtnRoot + "/ArmyGroupBtn"; // 军团频道
    private const string ServerBtn = LeftBtnRoot + "/ServerBtn"; // 本服频道
    private const string WorldBtn = LeftBtnRoot + "/WorldBtn"; // 世界频道
    private const string SystemBtn = LeftBtnRoot + "/SystemBtn"; // 系统频道 

    // Select
    private const string PrivateChatBtnSelect = PrivateChatBtn + "/Select"; // 私聊频道
    private const string NearbyBtnSelect = NearbyBtn + "/Select"; // 附近频道
    private const string TeamBtnSelect = TeamBtn + "/Select"; // 队伍频道
    private const string ArmyGroupBtnSelect = ArmyGroupBtn + "/Select"; // 军团频道
    private const string ServerBtnSelect = ServerBtn + "/Select"; // 本服频道
    private const string WorldBtnSelect = WorldBtn + "/Select"; // 世界频道
    private const string SystemBtnSelect = SystemBtn + "/Select"; // 系统频道 

    // loop view
    private const string LoopVerticalScroll = "/ChatList";
    private const string CloneObj = "/ChatList/Content/";
    private ChannelView _channelPrivate = new ChannelView();
    private ChannelView _channelNear = new ChannelView();
    private ChannelView _channelTeam = new ChannelView();
    private ChannelView _channelArmy = new ChannelView();
    private ChannelView _channelServer = new ChannelView();
    private ChannelView _channelWorld = new ChannelView();
    private ChannelView _channelSystem = new ChannelView();

    #endregion 频道切换

    /// <summary>
    /// 记录当前频道 频道切换前的
    /// </summary>
    private string _currentChannel = string.Empty; // 记录当前频道标识

    /// <summary>
    /// 默认频道
    /// </summary>
    private byte _defaultChannel = (byte) ChatChannelType.SPACE;

    private const int ExpressionMax = 18; // 表情的总数

    private InputField _input;
    private ExUIToggle _expressionToggle;
    private ExUIButton _sendBtn;
    private ExUIButton _voiceBtn;
    private ExUIButton _chatOpenBtn;

    /// <summary>
    /// 频道设置界面
    /// </summary>
    private SettingView _settingView;

    /// <summary>
    /// 表情界面
    /// </summary>
    private ExpressionView _expressionView;

    /// <summary>
    /// 频道
    /// </summary>
    private ChannelView _channelView;

    /// <summary>
    /// 聊天窗口显示
    /// </summary>
    private bool _isChatOpen;

    private DisplayMessageInfo _messageInfo;

    /// <summary>
    /// 记录上一次输入的内容
    /// </summary>
    private string _beforeChange = "";

    /// <summary>
    /// 刷新数据
    /// </summary>
    /// <param name="name"></param>
    /// <param name="info"></param>
    public void RefeshMessage(string name, ChatDataInfo info)
    {
        Transform transfrom = this.GetComponent<Transform>(CloneObj + name);

        if (transfrom != null)
        {
            // 根据当前频道确定显示的内容，然后确定找哪个item进行赋值。。
            string path = CloneObj + name + "/LeftPrivite";

            // test start

            this.GetComponent<Transform>(path).gameObject.SetActive(true);
            this.GetComponent<ExText>(path + "/Name").text = "test111";
            this.GetComponent<ExText>(path + "/Level").text = "满级啦";
            SuperTextMesh textMesh = this.GetComponent<SuperTextMesh>(path + "/BubbleBg/ContentText");
            textMesh.Text = ChatExpression.Parsing(info.Content);
            textMesh.Rebuild();

            /// 操作文本背景框
            RectTransform rectT = this.GetComponent<RectTransform>(path + "/BubbleBg");

            // width *20 + 25
            float width;
            float height = textMesh.GetSuperTextHeight();
            height = float.Parse(string.Format("{0:N1}", height));
            height = height * 118;
            
            if (height < 40) height = 40; // 最小高度
            
            if (float.TryParse(string.Format("{0:N1}", textMesh.CurrentLineWidth), out width))
            {
                width = width * 20 + 25; // 20 是sacle
                if (width > 335) width = 335;

                rectT.sizeDelta = new Vector2(width, height);
            }
            /// 操作文本背景框
            // test end
        }
    }

    public void ChangeToCount()
    {
        if (_isChatOpen) // 如果窗口关闭着就不刷新信息
            _messageInfo.ChangeTotalCount(_messageInfo.ScrollRect.totalCount + 1);
    }

    #region UIMainChatComWin

    public override void Initial(UIChatWindow window, string topPath)
    {
        base.Initial(window, topPath);
        GetComponentObj();
    }

    public override void Show()
    {
        //_rootTran.gameObject.SetActive(true);

        // 设置聊天窗口
        _isChatOpen = false;
        SetChatOpen(false);
    }

    public override void Hide()
    {
        _isChatOpen = false;
        _rootTran.gameObject.SetActive(false);
    }

    public override void Dispose()
    {
        _expressionToggle = null;
        _sendBtn = null;
        _voiceBtn = null;

        _settingView.Dispose();
        _expressionView.Dispose();
        _timeNode = null;
        base.Dispose();
    }

    /// <summary>
    /// 切换频道
    /// </summary>
    /// <param name="flag"></param>
    public void SetChannelFunc(string flag)
    {
        // Debug.Log("SetChannelFunc--->" + flag + "   " + _currentChanne);
        if (_currentChannel != flag)
        {
            GetChannelView(flag).SetSelect(true);
            if (_currentChannel != string.Empty) GetChannelView(_currentChannel).SetSelect(false);
            _currentChannel = flag;
            _messageInfo.ChangeTotalCount(0); // 清屏
            ChatRecordData.GetInstance.ChatListInfo.Clear(); // test code  清除以前的数据
        }
    }

    /// <summary>
    /// 状态的切换
    /// </summary>
    /// <param name="state"></param>
    public void SetChatOpen(bool state)
    {
        _isChatOpen = state;
        ChatOpenAction();
    }

    private ViTimeNode1 _timeNode = new ViTimeNode1();

    /// <summary>
    /// 设置input text
    /// </summary>
    /// <param name="str"></param>
    public void SetInputText(string str)
    {
        if (_input != null)
        {
            _input.text = str;
            _input.ActivateInputField();
            _input.Select();
            ViTimerInstance.SetTime(_timeNode, (UInt32) (0.1f * 100), TimeCb);
        }

        _beforeChange = str;
    }

    /// <summary>
    /// 延时调用
    /// </summary>
    /// <param name="v"></param>
    private void TimeCb(ViTimeNodeInterface v)
    {
        _input.MoveTextEnd(false);
        _timeNode.Detach();
    }

    private void ChatOpenAction()
    {
        float rotateZ = _isChatOpen ? 0 : 180;
        float localX = _isChatOpen
            ? -UIDefine.DESIGN_RESOLUTION.x / 2 - 3
            : -601.83f - UIDefine.DESIGN_RESOLUTION.x / 2;

        _chatOpenBtn.transform.DOLocalRotate(new Vector3(0, 0, rotateZ), 0.1f);
        (_rootTran.transform as RectTransform).DOLocalMoveX(localX, 0.1f);
        if (_isChatOpen) // 窗口打开时的操作
            OpenAction();
        else
            CloseAction(); // 窗口关闭时的操作
    }

    /// <summary>
    /// 一些关闭动作
    /// </summary>
    private void CloseAction()
    {
        if (_messageInfo != null) _messageInfo.ChangeTotalCount(0);
        if (_input != null) _input.text = string.Empty;
        if (_expressionToggle != null) _expressionToggle.isOn = false;
        if (_expressionView != null) _expressionView.SetActive(false);
        if (_settingView != null) _settingView.Reset();
        SetChannelFunc("NearbyBtn"); // 设置默认频道
        ChatRecordData.GetInstance.ChatListInfo.Clear(); // test code  清除以前的数据
    }

    private void OpenAction()
    {
        // 请求当前频道的信息
        EventDispatcher.TriggerEvent(Events.ChatSystemEvent.ChatGetDataMessage, _defaultChannel);
    }

    #region 通过名称获取 对应的 view对象

    private ChannelView GetChannelView(string flag)
    {
        ChannelView view = null;
        switch (flag)
        {
            case "PrivateChatBtn":
                view = _channelPrivate;
                break;
            case "NearbyBtn":
                view = _channelNear;
                break;
            case "TeamBtn":
                view = _channelTeam;
                break;
            case "ArmyGroupBtn":
                view = _channelArmy;
                break;
            case "ServerBtn":
                view = _channelServer;
                break;
            case "WorldBtn":
                view = _channelWorld;
                break;
            case "SystemBtn":
                view = _channelSystem;
                break;
        }

        return view;
    }

    #endregion

    /// <summary>
    /// 获取组件
    /// </summary>
    private void GetComponentObj()
    {
        _input = this.GetComponent<InputField>(InputPath);
        _input.onValueChanged.AddListener((string s) => InputChangeCB(s));
        _input.characterLimit = ChatRecordData.CharacterLimit;
        _expressionToggle = this.GetComponent<ExUIToggle>(ExpressionBtn);
        _expressionToggle.onValueChanged.AddListener((bool state) => ToggleChangeCB(_expressionToggle, state));

        _sendBtn = this.GetComponent<ExUIButton>(SendBtnPath);
        _sendBtn.onClickEx = SendBtnCB;

        _voiceBtn = this.GetComponent<ExUIButton>(VoiceBtn);
        _chatOpenBtn = this.GetComponent<ExUIButton>(ChatOpenBtn);
        _chatOpenBtn.onClickEx = ChatOpenBtnCB;
        /**语音相关的暂放**/

        // TODO  语音设置
        //

        ///


        /// 设置界面
        _settingView = new SettingView
        {
            View = this.GetComponent<Transform>(SettingViewPath),
            ToggleList = GetSettingToggles(),
            SettingBtn = this.GetComponent<ExUIToggle>(SettingBtn), //_settingBtn,
            OKBtn = this.GetComponent<ExUIButton>(SettingViewOkBtn),
        };
        _settingView.SetCB();
        _settingView.SetActive(false);

        // 表情界面
        _expressionView = new ExpressionView
        {
            View = this.GetComponent<Transform>(ExpressionAndHistory),
            ExpressList = GetExpress(),
            input = _input,
        };
        _expressionView.SetExpressBtnCB();
        _expressionView.SetActive(false);
        ChannelFunc();

        _messageInfo = new DisplayMessageInfo
        {
            ScrollRect = this.GetComponent<LoopVerticalScrollRect>(LoopVerticalScroll),
        };
        _messageInfo.InitRect();
    } // end GetComponentObj

    /// <summary>
    /// 聊天按钮开关
    /// </summary>
    /// <param name="val"></param>
    /// <param name="obj"></param>
    private void ChatOpenBtnCB(int val, object obj)
    {
        SetChatOpen(!_isChatOpen);
    }

    private void ChannelFunc()
    {
        ChannelView[] channels =
        {
            _channelPrivate, _channelNear, _channelTeam, _channelArmy, _channelServer,
            _channelWorld, _channelSystem
        };

        string[] btns = {PrivateChatBtn, NearbyBtn, TeamBtn, ArmyGroupBtn, ServerBtn, WorldBtn, SystemBtn};

        string[] select =
        {
            PrivateChatBtnSelect, NearbyBtnSelect, TeamBtnSelect, ArmyGroupBtnSelect, ServerBtnSelect, WorldBtnSelect,
            SystemBtnSelect
        };

        for (int i = 0; i < channels.Length; i++)
        {
            channels[i].Btn = this.GetComponent<ExUIButton>(btns[i]);
            channels[i].Select = this.GetComponent<Transform>(select[i]);
            channels[i].SetBtnCB();
        }
    }

    private List<Toggle> GetSettingToggles()
    {
        List<Toggle> list = new List<Toggle>();
        string[] paths =
        {
            SettingPrivate, // 私聊
            SettingNear, // 附近
            SettingTeam, // 队伍
            SettingLegion, // 军团
            SettingSuit, //本服
            SettingWorld, // 世界
            SettingSystem // 系统
        };

        for (int i = 0; i < paths.Length; i++)
        {
            list.Add(this.GetComponent<Toggle>(paths[i]));
        }

        return list;
    }

    /// <summary>
    /// 获取表情控件
    /// </summary>
    /// <returns></returns>
    private List<ExUIButton> GetExpress()
    {
        List<ExUIButton> btns = new List<ExUIButton>();

        for (int i = 0; i < ExpressionMax; i++)
        {
            ExUIButton btn = this.GetComponent<ExUIButton>(ExpressionPath + i);
            btn.gameObject.GetComponent<ExUISprite>().SpriteName = "pic_face_" + (i + 1);
            btns.Add(btn);
        }

        return btns;
    }

    /// <summary>
    /// 设置按钮
    /// </summary>
    /// <param name="settingBtn"></param>
    /// <param name="state"></param>
    private void SettingToggleCB(ExUIToggle settingBtn, bool state)
    {
        _settingView.SetActive(state);
    }

    /// <summary>
    /// 输入检测回调
    /// </summary>
    /// <param name="str"></param>
    private void InputChangeCB(string str)
    {
        // CellPlayerServerInvoker.ChatScriptBegin(CellPlayer.Instance, (byte)ChatChannelType.FACTION);  // 切换频道
        EventDispatcher.TriggerEvent(Events.ChatSystemEvent.ChatCheckMessage, str, _beforeChange);
    }


    /// <summary>
    /// 表情列表 toggle
    /// </summary>
    /// <param name="expressionToggle"></param>
    /// <param name="state"></param>
    private void ToggleChangeCB(ExUIToggle expressionToggle, bool state)
    {
        _expressionView.SetActive(state);
    }

    /// <summary>
    /// 发送按钮事件
    /// </summary>
    /// <param name="val"></param>
    /// <param name="obj"></param>
    private void SendBtnCB(int val, object obj)
    {
        ///目前频道能用的： 	SPACE,
        //CellPlayerServerInvoker.ChatScriptBegin(CellPlayer.Instance, (byte)ChatChannelType.SPACE);
        //// 发送消息
        //CellPlayerServerInvoker.ChatScriptEnd(CellPlayer.Instance, _input.text);
        if (_input.text != string.Empty)
        {
            ChatRecordData.GetInstance.ChatListInfo.Add(new ChatDataInfo {Content = _input.text}); // test code
            EventDispatcher.TriggerEvent<string>(Events.ChatSystemEvent.ChatSendMessage, _input.text);
            _input.text = string.Empty;
        }
    }

    #endregion  UIMainChatComWin

    #region 表情界面处理

    private class ExpressionView : IDisposable
    {
        public Transform View;
        public InputField input;

        public List<ExUIButton> ExpressList;

        /// <summary>
        /// 表情容器
        /// </summary>
        // public LoopVerticalScrollRect VloopRect;

        // public void InitRect()
        // {
        //     if (VloopRect != null)
        //     {
        //         VloopRect.Init(RefreshView, 100);
        //         VloopRect.SetCanDrag(false);
        //     }
        // }
        /// <summary>
        /// 刷新接口
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void RefreshView(string arg1, int arg2)
        {
        }

        public void SetActive(bool state)
        {
            if (View != null) View.gameObject.SetActive(state);
        }

        /// <summary>
        /// 设置表情回调
        /// </summary>
        public void SetExpressBtnCB()
        {
            for (int i = 0; i < ExpressList.Count; i++)
            {
                if (ExpressList[i] != null)
                {
                    ExpressList[i].Id = i + ChatExpression.AnimKeyStart;
                    ExpressList[i].onClickEx = ExpressBtnCB;
                }
            }
        }

        #region 表情点击

        private void ExpressBtnCB(int id, object obj)
        {
            if (input != null)
            {
                /// 一个表情占一个字符，所以判断下是否超出限制 如果没有才写上
                if (input.text.Length + 1 <= ChatRecordData.CharacterLogicLimit)
                {
                    input.text = input.text + ChatExpression.ExpressionPrefix + id;
                }
            }
        }

        #endregion

        public void Dispose()
        {
            View = null;

            for (int i = 0; i < ExpressList.Count; ++i)
            {
                ExpressList[i] = null;
            }

            ExpressList.Clear();
        }
    }

    #endregion  表情界面 end

    #region 频道设置界面

    private class SettingView : IDisposable
    {
        public Transform View;
        public List<Toggle> ToggleList;
        public ExUIButton SettingOkBtn;
        public ExUIToggle SettingBtn; // 设置按钮
        public ExUIButton OKBtn; //确定按钮

        public void SetActive(bool state)
        {
            if (View != null) View.gameObject.SetActive(state);
        }

        public void Reset()
        {
            SettingBtn.isOn = false;
            SetActive(false);
        }

        public void SetCB()
        {
            if (ToggleList != null)
            {
                for (int i = 0; i < ToggleList.Count; i++)
                {
                    if (ToggleList[i] != null) SetToggle(ToggleList[i]);
                }
            }

            if (SettingOkBtn != null) SettingOkBtn.onClickEx = SettingOkBtnCB;
            if (SettingBtn != null)
                SettingBtn.onValueChanged.AddListener((state) => SettingToggleCB(SettingBtn, state));
            if (OKBtn != null) OKBtn.onClickEx = SettingOkBtnCB;
        }

        private void SettingToggleCB(ExUIToggle settingBtn, bool state)
        {
            //_settingView.SetActivie(state);
            SetActive(state);
        }

        private void SettingOkBtnCB(int val, object obj)
        {
            //  直接遍历 ToggleList 的状态（isOn属性）即可 保存数据
            // do....

            Reset();
        }

        private void SetToggle(Toggle toggle)
        {
            toggle.onValueChanged.AddListener((bool state) => ToggleChangeCB(toggle, state));
        }

        private void ToggleChangeCB(Toggle toggle, bool state)
        {
        }

        public void Dispose()
        {
            View = null;
            SettingBtn = null;
            for (int i = 0; i < ToggleList.Count; i++)
            {
                ToggleList[i] = null;
            }

            ToggleList.Clear();
        }
    }

    #endregion 频道设置界面 end

    #region 频道类

    private class ChannelView
    {
        public ExUIButton Btn;
        public Transform Select;
        public Transform RectRoot; // 滑动层根节点
        public LoopVerticalScrollRect LoopRect;

        public void SetSelect(bool state)
        {
            Select.gameObject.SetActive(state);
        }

        public void SetBtnCB()
        {
            if (Btn != null) Btn.onClickEx = BtnCB;
        }

        private void BtnCB(int val, object obj)
        {
            string flag = obj.ToString().Split(' ')[0];
            EventDispatcher.TriggerEvent<string>(Events.ChatSystemEvent.ChatChannelBtn, flag);
        }
    }

    #endregion

    #region 显示信息列表

    private class DisplayMessageInfo
    {
        public LoopVerticalScrollRect ScrollRect;

        public void InitRect()
        {
            ScrollRect.Init(RefreshView, 100);
            //ScrollRect.RefreshAllCells();
            ChangeTotalCount(0);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void RefreshView(string str, int idx)
        {
            EventDispatcher.TriggerEvent(Events.ChatSystemEvent.ChatRefeshMessage, str, idx);
        }

        public void ChangeTotalCount(int count)
        {
            ScrollRect.ChangeTotalCount(count);
            ScrollRect.RefillCellsFromEnd();
        }
    }

    #endregion
} // main class end