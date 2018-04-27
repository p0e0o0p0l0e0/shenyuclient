using System;
using System.Collections.Generic;
using UInt8 = System.Byte;

public class ChatGroupManager<TEntity>
{
	public static ChatGroupManager<TEntity> Instance { get { return _instance; } }
	static ChatGroupManager<TEntity> _instance = new ChatGroupManager<TEntity>();
	//
	public void Register(ChatChannelType channel, TEntity entity)
	{
		if (_list.ContainsKey(channel))
		{
			ViDebuger.Warning("ChatGroupManager.Register(" + channel + ") Over ID");
		}
		else
		{
			_list.Add(channel, entity);
		}
	}

	public void Erase(ChatChannelType channel)
	{
		_list.Remove(channel);
	}

	public TEntity Get(ChatChannelType channel)
	{
		TEntity entity;
		_list.TryGetValue(channel, out entity);
		return entity;
	}

	Dictionary<ChatChannelType, TEntity> _list = new Dictionary<ChatChannelType, TEntity>();
}