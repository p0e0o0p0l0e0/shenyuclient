using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ChatInputRecord
{
	public int Size { get { return _size; } set { if (value > 0) { _size = value; } } }

	public void AddRecord(string chat)
	{
		for (int idx = 0; idx < _records.Count; ++idx)
		{
			if (_records[idx] == chat)
			{
				_records.RemoveAt(idx);
				break;
			}
		}
		if (_records.Count >= _size)
		{
			_records.RemoveAt(0);
		}
		_records.Add(chat);
		_recordIdx = _records.Count;
	}

	public string UpRecord(string defaultValue)
	{
		if (_records.Count == 0)
		{
			return defaultValue;
		}
		if (_recordIdx > 0)
		{
			--_recordIdx;
		}
		ViDebuger.AssertError(0 <= _recordIdx && _recordIdx < _records.Count);
		return _records[_recordIdx];
	}

	public string DownRecord(string defaultValue)
	{
		if (_records.Count == 0)
		{
			return defaultValue;
		}
		++_recordIdx;
		if (_recordIdx >= _records.Count)
		{
			_recordIdx = _records.Count - 1;
		}
		ViDebuger.AssertError(0 <= _recordIdx && _recordIdx < _records.Count);
		return _records[_recordIdx];
	}
	//
	List<string> _records = new List<string>();
	int _recordIdx;
	int _size = 30;
}


public enum ClientChatChannelTab
{
	CUSTOM,
	GUILD,
}

public static class ChatChannelAssissant
{
	public static ClientChatChannelTab Convert(this ChatChannelType type)
	{
		switch (type)
		{
			case ChatChannelType.GUILD:
				return ClientChatChannelTab.GUILD;
			default:
				return ClientChatChannelTab.CUSTOM;
		}
	}

	public static ChatChannelType Convert(this ClientChatChannelTab type)
	{
		switch (type)
		{
			case ClientChatChannelTab.CUSTOM:
				return ChatChannelType.WORLD;
			case ClientChatChannelTab.GUILD:
				return ChatChannelType.GUILD;
			default:
				return ChatChannelType.WORLD;
		}
	}

	//public static string Name(this ChatChannelType type)
	//{
	//    switch (type)
	//    {
	//        case ChatChannelType.WORLD:
	//            return "【世界】";
	//        case ChatChannelType.GUILD:
	//            return "【公会】";
	//        default:
	//            return string.Empty;
	//    }
	//}
}