using System;
using System.Collections.Generic;

using ViOperatorIdx = System.Byte;
using ViArrayIdx = System.Int32;
using UInt8 = System.Byte;



public interface ViReceiveDataSetNodeNodeWatcher<TProteKey>
{
	void OnStart(TProteKey key, ViEntity entity);
	void OnUpdate(TProteKey key, ViEntity entity);
	void OnEnd(TProteKey key, ViEntity entity);
}

public class ViReceiveDataSetNode<TProteKey>
{
	public ViReceiveDataSetNodeNodeWatcher<TProteKey> Watcher;
}

public class ViReceiveDataSet<TProteKey> : ViReceiveDataNode
{
	public static readonly UInt16 END_SLOT = 0XFFFF;
	public static string GLOBAL_NAME { get { return "ViReceiveDataSet<" + typeof(TProteKey).Name + ">"; } }

	public delegate ViReceiveDataSetNodeNodeWatcher<TProteKey> WatcherCreator();
	public WatcherCreator Creator;

	public ViEventList<TProteKey> UpdateArrayCallbackList { get { return _updateArrayCallbackList; } }
	public Dictionary<TProteKey, ViReceiveDataSetNode<TProteKey>> Array { get { return _array; } }

	public bool Contain(TProteKey key)
	{
		return Array.ContainsKey(key);
	}
	//
	public override void OnUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		if (!MatchChannel(channel))
		{
			return;
		}
		ViOperatorIdx op;
		IS.Read(out op);
		switch ((ViDataArrayOperator)op)
		{
			case ViDataArrayOperator.INSERT:
				{
					TProteKey key;
					ViSerializer<TProteKey>.Read(IS, out key);
					if(!_array.ContainsKey(key))
					{
						ViReceiveDataSetNode<TProteKey> newNode = new ViReceiveDataSetNode<TProteKey>();
						AttachWatcher(key, newNode, entity);
						_array[key] = newNode;
						OnUpdateInvoke();
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.INSERT, key);
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".INSERT at Key(" + key + ") is exist");
					}
				}
				break;
			case ViDataArrayOperator.DEL:
				{
					TProteKey key;
					ViSerializer<TProteKey>.Read(IS, out key);
					if(_array.ContainsKey(key))
					{
						ViReceiveDataSetNode<TProteKey> node = _array[key];
						_array.Remove(key);
						OnUpdateInvoke();
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.DEL, key);
						DetachWatcher(key, node, entity);
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".DEL at Key(" + key + ") is not exist");
					}
				}
				break;
			case ViDataArrayOperator.CLEAR:
				Update_Clear(IS, entity);
				OnUpdateInvoke();
				_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.CLEAR, default(TProteKey));
				break;
			case ViDataArrayOperator.RESET:
				Update_Clear(IS, entity);
				Update_Start(IS, entity);
				OnUpdateInvoke();
				_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.RESET, default(TProteKey));
				break;
			default:
				break;
		}
	}
	//
	void Update_Clear(ViIStream IS, ViEntity entity)
	{
		foreach (KeyValuePair<TProteKey, ViReceiveDataSetNode<TProteKey>> pair in _array)
		{
			ViReceiveDataSetNode<TProteKey> node = pair.Value;
			DetachWatcher(pair.Key, node, entity);
		}
		_array.Clear();
	}

	void Update_Start(ViIStream IS, ViEntity entity)
	{
		ViArrayIdx size;
		IS.ReadPacked(out size);
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViReceiveDataSet.size Error");
			return;
		}
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TProteKey key;
			ViSerializer<TProteKey>.Read(IS, out key);
			ViReceiveDataSetNode<TProteKey> newNode = new ViReceiveDataSetNode<TProteKey>();
			AttachWatcher(key, newNode, entity);
			_array[key] = newNode;
		}
	}

	public new void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		if (!MatchChannel(channelMask))
		{
			return;
		}
		Update_Start(IS, entity);
	}
	public override void End(ViEntity entity)
	{
		foreach (KeyValuePair<TProteKey, ViReceiveDataSetNode<TProteKey>> pair in _array)
		{
			ViReceiveDataSetNode<TProteKey> iterNode = pair.Value;
			if (iterNode.Watcher != null)
			{
				iterNode.Watcher.OnEnd(pair.Key, entity);
			}
		}
		_array.Clear();
		Creator = null;
		DetachAllCallback();
		base.End(entity);
	}

	public override void Clear()
	{
		_array.Clear();
		Creator = null;
		DetachAllCallback();
		base.Clear();
	}

	//
	void DetachAllCallback()
	{
		_updateArrayCallbackList.Clear();
	}

	public void UpdateWatcher(WatcherCreator Creator, ViEntity entity)
	{
		foreach (KeyValuePair<TProteKey, ViReceiveDataSetNode<TProteKey>> pair in _array)
		{
			ViReceiveDataSetNode<TProteKey> iterNode = pair.Value;
			if (iterNode.Watcher == null)
			{
				AttachWatcher(pair.Key, iterNode, entity);
			}
		}
	}

	void AttachWatcher(TProteKey key, ViReceiveDataSetNode<TProteKey> node, ViEntity entity)
	{
		if (Creator != null)
		{
			ViReceiveDataSetNodeNodeWatcher<TProteKey> watcher = Creator();
			node.Watcher = watcher;
			if (watcher != null)
			{
				watcher.OnStart(key, entity);
			}
		}
	}

	void DetachWatcher(TProteKey key, ViReceiveDataSetNode<TProteKey> node, ViEntity entity)
	{
		if (node.Watcher != null)
		{
			node.Watcher.OnEnd(key, entity);
			node.Watcher = null;
		}
	}

	Dictionary<TProteKey, ViReceiveDataSetNode<TProteKey>> _array = new Dictionary<TProteKey, ViReceiveDataSetNode<TProteKey>>();
	ViEventList<TProteKey> _updateArrayCallbackList = new ViEventList<TProteKey>();
}

public static class ViReceiveDataSetSerialize
{
	public static void Append<TProteKey>(ViOStream OS, ViReceiveDataSet<TProteKey> value)
	{
		ViDebuger.Error("ViReceiveDataSetSerialize Useless");
	}
}