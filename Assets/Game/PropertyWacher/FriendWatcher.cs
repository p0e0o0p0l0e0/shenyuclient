using System;
using System.Collections.Generic;

public class FriendWatcher : ViReceiveDataDictionaryNodeWatcher<UInt64, ReceiveDataFriendProperty>
{
	public int UnreadCount;

	public FriendViewProperty ViewProperty
	{
		get
		{
			ReceiveDataFriendViewProperty property;
			if (PlayerFriendList.Instance.Property.FriendViewPropertyList.TryGetValue(Key, out property))
			{
				return property;
			}
			return new FriendViewProperty();
		}
	}

	public List<ChatRecordProperty> ChatList { get { return _chatList; } }

	public override void OnStart(UInt64 key, ReceiveDataFriendProperty property, ViEntity entity)
	{
		_UpdateUnreadChatList(Key);
		UnreadCount = _chatList.Count;
	}

	public override void OnUpdate(UInt64 key, ReceiveDataFriendProperty property, ViEntity entity)
	{
	}
	//
	public override void OnEnd(UInt64 key, ReceiveDataFriendProperty property, ViEntity entity)
	{
	}

	void _UpdateUnreadChatList(UInt64 palyer)
	{
		_chatList.Clear();
		for (int iter = 0; iter < PlayerOfflineBox.Instance.Property.OfflineChatList.Count; ++iter)
		{
			ChatRecordProperty chat = PlayerOfflineBox.Instance.Property.OfflineChatList[iter].Property;
			if (chat.Sayer.ID == palyer)
			{
				_chatList.Add(chat);
			}
		}
	}

	List<ChatRecordProperty> _chatList = new List<ChatRecordProperty>();
}
