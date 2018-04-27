using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************
	created:	2018/02/01
	created:	1:2:2018   10:02
	filename: 	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat\UIChatWindow.cs
	file path:	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat
	file base:	UIChatWindow
	file ext:	cs
	author:		meixuelei
	
	purpose:	聊天Window
*********************************************************************/
public class UIChatWindow : UIWindow<UIChatWindow, UIChatController>
{
    #region 节点路径

    private const string ChatTipRoot = "UIChatWindow/Tip";
    private const string ChatSystemRoot = "UIChatWindow/ChatSystem";
    private const string ChatMainRoot = "UIChatWindow/Chat";
    private const string ChatImg = "UIChatWindow/Image";

    #endregion

    #region  节点对象

    private Transform _chatTiptran; // 不知道是干什么用的，目前先隐藏
    private Transform _chatImg; // 不知道是干什么用的，目前先隐藏
    private UIMainChatComWin _chatMain;
    private UIChatPlaneWin _chatSys;

    #endregion

    protected override void Initial()
    {
        base.Initial();

        _chatTiptran = this.FindTransform(ChatTipRoot);
        _chatImg = this.FindTransform(ChatImg);

        _chatMain = new UIMainChatComWin();
        _chatMain.Initial(this, ChatMainRoot);

        _chatSys = new UIChatPlaneWin();
        _chatSys.Initial(this, ChatSystemRoot);
    }


    public override void Show()
    {
        base.Show();
        // _mWinTran.gameObject.SetActive(true);
        _chatTiptran.gameObject.SetActive(false);
        _chatImg.gameObject.SetActive(false);

        _chatSys.Show();
        _chatMain.Show();
    }

    public override void Hide()
    {
        if (_chatMain != null) _chatMain.Hide();
        base.Hide();
    }

    #region 切换频道

    public void ChatChannelBtn(string channel)
    {
        if (channel == string.Empty) return;
        if (_chatMain != null) _chatMain.SetChannelFunc(channel);
    }

    #endregion

    #region  显示服务器发送的信息

    private readonly object _syncObj = new object();

    public void RefeshMessage(string name, ChatDataInfo info)
    {
        if (_chatMain != null) _chatMain.RefeshMessage(name, info);
    }

    #endregion

    public void ChangeToCount(int count = 1)
    {
        for (int i = 0; i < count; ++i)
        {
            if (_chatMain != null) _chatMain.ChangeToCount();
        }
    }

    /// <summary>
    /// 设置输入框内容
    /// </summary>
    /// <param name="str"></param>
    public void SetInputMessage(string str)
    {
        if (_chatMain != null) _chatMain.SetInputText(str);
    }

    public override void Destroy()
    {
        // do...
        _chatTiptran = null;
        _chatImg = null;
        _chatMain.Dispose();
        _chatSys.Dispose();
        _chatMain = null;
        _chatSys = null;
        base.Destroy();
    }
}