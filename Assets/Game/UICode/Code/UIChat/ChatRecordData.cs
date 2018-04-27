using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************
	created:	2018/02/01
	created:	1:2:2018   14:29
	filename: 	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat\ChatRecordData.cs
	file path:	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat
	file base:	ChatRecordData
	file ext:	cs
	author:		meixuelei
	
	purpose:	 聊天数据
     
    要分频道 | 图文 | 语音
*********************************************************************/
public class ChatRecordData : DataManagerBase<ChatRecordData>, IRelease
{
    /// 输入限制，这个为了防止在编辑器修改
    /// 逻辑中 CharacterLogicLimit
    public const int CharacterLimit = 100;
    // 逻辑中用这个判断
    public const int CharacterLogicLimit = 100;
    
    /// <summary>
    /// 记录频道设置界面中 设置选项。
    /// </summary>
    /// <returns></returns>
    public Dictionary<ChatChannelType, bool> SettingDict = new Dictionary<ChatChannelType, bool>();

    /// <summary>
    /// 记录聊天信息最大的量 -- 这个 最大数量 是每个频道中的最大数，还是所有频道中的最大的数？
    /// </summary>
    private const int _ChatMessageMaxCount = 100;

    /// <summary>
    /// 根据类型存放对应的 数据  -- {暂时不包括私聊的内容，无时间顺序 }
    /// </summary>
    private Dictionary<ChatChannelType, List<ChatDataInfo>> _ChatDict =
        new Dictionary<ChatChannelType, List<ChatDataInfo>>();

    /// <summary>
    /// 记录所有的聊天记录 --  有时间顺序
    /// </summary>
    private List<ChatDataInfo> _ChatList = new List<ChatDataInfo>();

    /// <summary>
    /// 用于存放当前显示数据的列表
    /// </summary>
    private List<ChatDataInfo> _currentChatList = new List<ChatDataInfo>();

    /// <summary>
    /// 记录当前的频道
    /// </summary>
    public ChatChannelType CurrentChannel
    {
        get { return _currentChannel; }
        set { _currentChannel = value; }
    }
    private ChatChannelType _currentChannel = ChatChannelType.SPACE;

    private readonly object _syncObject = new object();

    private bool _isAddCurrentList;

    public List<ChatDataInfo> ChatListInfo
    {
        get { return _currentChatList; }
    }

    public ChatRecordData()
    {
        EventDispatcher.AddEventListener<ChatDataInfo>(Events.ChatSystemEvent.ChatReceives, MessageReceives);
    }

    /// <summary>
    /// 获取对应频道的信息，并设置当前显示的数据
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public List<ChatDataInfo> GetDataByChannel(ChatChannelType type)
    {
        _currentChatList.Clear();
        
        List<ChatDataInfo> list;
        
        if (_ChatDict.TryGetValue(type, out list))  _currentChatList = list;
        
        _currentChannel = type;

        return _currentChatList;
    }

    /// <summary>
    /// 接收服务器的信息 （参数 等服务器定好传入）
    /// </summary>
    #region 接收服务器消息
    private void MessageReceives(ChatDataInfo info)
    {
        if (info == null) return;
        lock (_syncObject)
        {
            // 保存起来，
            SaveMessage(info);

            //通知 controller 发消息
            if (_isAddCurrentList) EventDispatcher.TriggerEvent(Events.ChatSystemEvent.ChatDataNoticeController);
        }
    }

    #endregion
    
    /// <summary>
    /// 保存信息
    /// </summary>
    /// <param name="info"></param>
    private void SaveMessage(ChatDataInfo info)
    {
        _ChatList.Add(info);
        CheckMessageNumber(_ChatList);

        List<ChatDataInfo> list;
        if (_ChatDict.TryGetValue((ChatChannelType) info.ChannelId, out list))
        {
            list.Add(info);
            CheckMessageNumber(list);
        }

        _isAddCurrentList = false;
        if (info.ChannelId == (byte) _currentChannel)
        {
            _currentChatList.Add(info);
            CheckMessageNumber(_currentChatList);
            _isAddCurrentList = true;
        }
    }

    /// <summary>
    /// 检测聊天记录数量是否超过上限
    /// </summary>
    /// <param name="list">当前</param>
    /// <returns>是否进行删除操作</returns>
    private bool CheckMessageNumber(List<ChatDataInfo> list)
    {
        if (list == null || list.Count == 0) return false;

        if (list.Count > _ChatMessageMaxCount)
        {
            list.RemoveAt(0); // 删除第一条数据
            return true;
        }

        return false;
    }

    #region 设置表情

    /// <summary>
    /// 设置表情对应关系
    /// </summary>
    public void SetExpressionDict()
    {
        ChatExpression.Load();
    }

    #endregion

    public void Release()
    {
        EventDispatcher.RemoveEventListener<ChatDataInfo>(Events.ChatSystemEvent.ChatReceives, MessageReceives);
    }
}

#region 聊天对象

/// <summary>
/// 聊天对象
/// </summary>
public class ChatDataInfo
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public PlayerIdentificationProperty Property;

    /// <summary>
    /// 频道名称
    /// </summary>
    public string ChannelName;

    /// <summary>
    /// 频道ID
    /// </summary>
    public byte ChannelId;

    /// <summary>
    /// 文本内容
    /// </summary>
    public string Content;
}

#endregion