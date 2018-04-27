using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************
	created:	2018/01/31
	created:	31:1:2018   18:12
	filename: 	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat\UIChatController.cs
	file path:	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat
	file base:	UIChatController
	file ext:	cs
	author:		meixuelei
	
	purpose:	聊天Controller
*********************************************************************/

public class UIChatController : UIController<UIChatController, UIChatWindow>
{


    protected override void Initial()
    {
        base.Initial();
        this._mLayerType = UIControllerDefine.LayerType.NORMAL_TOP;  /// 设置层级
        AddEvents();

        ChatRecordData.GetInstance.SetExpressionDict();
    }

    public override void Show() { base.Show(); }
    public override void Hide() { base.Hide(); }
    public override void Destroy()
    {
        RemoveEvents();
        base.Destroy();
    }

    /// <summary>
    /// 监听事件
    /// </summary>
    private void AddEvents()
    {
        EventDispatcher.AddEventListener<string>(Events.ChatSystemEvent.ChatChannelBtn, ChatChannelBtnCB);
        EventDispatcher.AddEventListener<string>(Events.ChatSystemEvent.ChatSendMessage, SendMessage);
        EventDispatcher.AddEventListener(Events.ChatSystemEvent.ChatDataNoticeController, NoticeFunc);

        EventDispatcher.AddEventListener<string, int>(Events.ChatSystemEvent.ChatRefeshMessage, RefeshMessage);
        EventDispatcher.AddEventListener<byte>(Events.ChatSystemEvent.ChatGetDataMessage, ChatGetDataMessage);
        EventDispatcher.AddEventListener<string,string>(Events.ChatSystemEvent.ChatCheckMessage, ChatCheckMessage);
    }
    
    /// <summary>
    /// 主动请求显示信息
    /// </summary>
    /// <param name="name"></param>
    private void ChatGetDataMessage(byte channel)
    {
        List<ChatDataInfo> list =  ChatRecordData.GetInstance.GetDataByChannel((ChatChannelType)channel);

        if (list != null) _mWinHandler.ChangeToCount(list.Count);
    }

    /// <summary>
    /// 刷新消息列表
    /// </summary>
    /// <param name="name">所用 object的名字</param>
    /// <param name="idx">列表中的索引值</param>
    private void RefeshMessage(string name, int idx)
    {
        if (idx <= ChatRecordData.GetInstance.ChatListInfo.Count)
            _mWinHandler.RefeshMessage(name, ChatRecordData.GetInstance.ChatListInfo[idx]);
    }

    #region 发送消息
    private void SendMessage(string str)
    {
        //CellPlayerServerInvoker.ChatScriptEnd(CellPlayer.Instance, str);
        // 统一成用Player 发消息给服务器，服务器会自己处理  ChatRecordData.GetInstance.CurrentChannel->实际标识

        // PlayerServerInvoker.ChatMessage(Player.Instance, (byte)ChatRecordData.GetInstance.CurrentChannel, str, null, SendMessageResult);
        // PlayerServerInvoker.ChatMessage(Player.Instance, (byte)ChatChannelType.SPACE, str, null, SendMessageResult); // debug code
        _mWinHandler.ChangeToCount(); // test code
    }
    
    /// <summary>
    /// 输入检测
    /// </summary>
    /// <param name="current"></param>
    /// <param name="before"></param>
    private void ChatCheckMessage(string current, string before)
    {
        string message = "";
        
        /// 检测是否超出输出限制
        int expressionNum = ChatExpression.GetExpressionNumber(current);
        ///一个表情由三个字符组成，在输入框中按一个字符来处理
        /// tmpNum 是实际的长度
        int tmpNum = current.Length - expressionNum * 2;

        if (tmpNum > ChatRecordData.CharacterLogicLimit)
        {
            int redundant = ChatRecordData.CharacterLogicLimit - tmpNum;
            message = current.Substring(0, redundant + 1);
        }
        else
        {
            message = current;
        }
        /// -----其他限制 ------
        /// TODO
        
        _mWinHandler.SetInputMessage(message);
    }
    

    /// <summary>
    /// 通知有新的信息
    /// </summary>
    private void NoticeFunc()
    {
        _mWinHandler.ChangeToCount();
    }

    /// <summary>
    /// 发送信息时错误信息返回
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="result"></param>
    private void SendMessageResult(bool exception, byte result)
    {
        Debug.LogFormat("at UIChatController.cs SendMessageResult function exception -> {0},result->{1}", exception, result);
    }
    #endregion

    #region 切换频道
    private void ChatChannelBtnCB(string channel)
    {
        ChatChannelType type = GetChannelType(channel);

        if (ChatRecordData.GetInstance.CurrentChannel != type)
        {
            ChatRecordData.GetInstance.CurrentChannel = type;
            _mWinHandler.ChatChannelBtn(GetStingByChannel(ChatRecordData.GetInstance.CurrentChannel));
        }
    }
    #endregion

    #region 根据字符获取对应的频道
    private ChatChannelType GetChannelType(string channel)
    {
        ChatChannelType type = ChatChannelType.SPACE;
        switch (channel)
        {
            case "PrivateChatBtn":
                type = ChatChannelType.SELF;
                break;
            case "NearbyBtn":
                type = ChatChannelType.SPACE;
                break;
            case "TeamBtn":
                type = ChatChannelType.PARTY;
                break;
            case "ArmyGroupBtn":
                type = ChatChannelType.GUILD;
                break;
            case "ServerBtn":  // 暂定
                type = ChatChannelType.ROOM;
                break;
            case "WorldBtn":
                type = ChatChannelType.WORLD;
                break;
            case "SystemBtn":
                type = ChatChannelType.SYSTEM;
                break;
        }

        return type;
    }
    #endregion

    #region    根据频道获取对应的字符
    private string GetStingByChannel(ChatChannelType type)
    {
        string str = string.Empty;

        switch (type)
        {
            case ChatChannelType.SELF:
                str = "PrivateChatBtn";
                break;
            case ChatChannelType.SPACE:
                str = "NearbyBtn";
                break;
            case ChatChannelType.PARTY:
                str = "TeamBtn";
                break;
            case ChatChannelType.GUILD:
                str = "ArmyGroupBtn";
                break;
            case ChatChannelType.ROOM:
                str = "ServerBtn";
                break;
            case ChatChannelType.WORLD:
                str = "WorldBtn";
                break;
            case ChatChannelType.SYSTEM:
                str = "SystemBtn";
                break;
        }

        return str;
    }
    #endregion

    #region 删除注册的事件
    private void RemoveEvents()
    {
        EventDispatcher.RemoveEventListener<string>(Events.ChatSystemEvent.ChatChannelBtn, ChatChannelBtnCB);
        EventDispatcher.RemoveEventListener<string>(Events.ChatSystemEvent.ChatSendMessage, SendMessage);
        EventDispatcher.RemoveEventListener(Events.ChatSystemEvent.ChatDataNoticeController, NoticeFunc);
        EventDispatcher.RemoveEventListener<string, int>(Events.ChatSystemEvent.ChatRefeshMessage, RefeshMessage);
        EventDispatcher.RemoveEventListener<byte>(Events.ChatSystemEvent.ChatGetDataMessage, ChatGetDataMessage);
        EventDispatcher.RemoveEventListener<string, string>(Events.ChatSystemEvent.ChatCheckMessage, ChatCheckMessage);

    }
    #endregion

}

