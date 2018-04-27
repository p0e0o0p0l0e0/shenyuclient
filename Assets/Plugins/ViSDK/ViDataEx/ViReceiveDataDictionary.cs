using System;
using System.Collections.Generic;

using ViOperatorIdx = System.Byte;
using ViArrayIdx = System.Int32;
using UInt8 = System.Byte;


public abstract class ViReceiveDataDictionaryNodeWatcher<TProteKey, TReceiveData>
	where TReceiveData : ViReceiveDataNode
{
	public ViEntity Entity { get { return _entity; } }
	public TProteKey Key { get { return _key; } }
	public TReceiveData Property { get { return _property; } }
	public bool IsDirty { get { return _property == null; } }
	public void SetProperty(ViEntity entity, TProteKey key, TReceiveData property)
	{
		_entity = entity;
		_key = key;
		_property = property;
	}
	public void ClearProperty()
	{
		_entity = null;
		_property = null;
	}
	public abstract void OnStart(TProteKey key, TReceiveData property, ViEntity entity);
	public abstract void OnUpdate(TProteKey key, TReceiveData property, ViEntity entity);
	public abstract void OnEnd(TProteKey key, TReceiveData property, ViEntity entity);
	ViEntity _entity;
	TProteKey _key;
	TReceiveData _property;
}

public class ViReceiveDataDictionaryNode<TProteKey, TReceiveData> : ViReceiveDataMemoryObject
	where TReceiveData : ViReceiveDataNode, new()
{
	public TReceiveData Property { get { return _proeperty; } }
	public ViReceiveDataDictionaryNodeWatcher<TProteKey, TReceiveData> Watcher;
	public void OnCacheAlloc()
	{

	}

	public void OnCacheFree()
	{
		_proeperty = null;
	}
	TReceiveData _proeperty = new TReceiveData();
}

public class ViReceiveDataDictionary<TProteKey, TReceiveData, TProtoData> : ViReceiveDataNode
	where TReceiveData : ViReceiveDataNode, new()
{
	public static readonly UInt16 END_SLOT = 0XFFFF;
	public static string GLOBAL_NAME { get { return "ViReceiveDataDictionary<" + typeof(TProteKey).Name + ", " + typeof(TProtoData).Name + ">"; } }

	public delegate ViReceiveDataDictionaryNodeWatcher<TProteKey, TReceiveData> WatcherCreator();
	public WatcherCreator Creator;

	public ViEventList<TProteKey, TReceiveData> UpdateArrayCallbackList { get { return _updateArrayCallbackList; } }
	public int Count { get { return _array.Count; } }
	public Dictionary<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> Array { get { return _array; } }

	public bool TryGetKey(TReceiveData value, out TProteKey key)
	{
		foreach (KeyValuePair<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> pair in _array)
		{
			if (System.Object.ReferenceEquals(value, pair.Value.Property))
			{
				key = pair.Key;
				return true;
			}
		}
		key = default(TProteKey);
		return false;
	}

	public TProteKey GetKey(TReceiveData value, TProteKey defaultKey)
	{
		foreach (KeyValuePair<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> pair in _array)
		{
			if (System.Object.ReferenceEquals(value, pair.Value.Property))
			{
				return pair.Key;
			}
		}
		return defaultKey;
	}

	public bool TryGetValue(TProteKey key, out TReceiveData value)
	{
		ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node;
		if (Array.TryGetValue(key, out node))
		{
			value = node.Property;
			return true;
		}
		else
		{
			value = default(TReceiveData);
			return false;
		}
	}

	public TReceiveData GetValue(TProteKey key, TReceiveData defaultValue)
	{
		ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node;
		if (Array.TryGetValue(key, out node))
		{
			return node.Property;
		}
		else
		{
			return defaultValue;
		}
	}

	public bool TryGetWatcher<TWatcher>(TProteKey key, out TWatcher value) where TWatcher : ViReceiveDataDictionaryNodeWatcher<TProteKey, TReceiveData>
	{
		ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node;
		if (Array.TryGetValue(key, out node))
		{
			value = node.Watcher as TWatcher;
			return true;
		}
		else
		{
			value = default(TWatcher);
			return false;
		}
	}

	public TWatcher GetWatcher<TWatcher>(TProteKey key, TWatcher defaultValue) where TWatcher : ViReceiveDataDictionaryNodeWatcher<TProteKey, TReceiveData>
	{
		ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node;
		if (Array.TryGetValue(key, out node))
		{
			return node.Watcher as TWatcher;
		}
		else
		{
			return defaultValue;
		}
	}

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
					if (!_array.ContainsKey(key))
					{
						ViReceiveDataDictionaryNode<TProteKey, TReceiveData> newNode = ViReceiveDataCache<ViReceiveDataDictionaryNode<TProteKey, TReceiveData>>.Alloc();
						newNode.Property.ResisterInList(this);
						newNode.Property.Start(UInt16.MaxValue, IS, entity);
						AttachWatcher(key, newNode, entity);
						_array[key] = newNode;
						OnUpdateInvoke();
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.INSERT, key, newNode.Property);
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
						ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node = _array[key];
						_array.Remove(key);
						OnUpdateInvoke(node.Property);
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.DEL, key, node.Property);
						DetachWatcher(key, node, entity);
						node.Property.End(entity);
						node.Property.Clear();
						ViReceiveDataCache<ViReceiveDataDictionaryNode<TProteKey, TReceiveData>>.Free(node);
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".DEL at Key(" + key + ") is not exist");
					}
				}
				break;
			case ViDataArrayOperator.MOD:
				{
					TProteKey key;
					ViSerializer<TProteKey>.Read(IS, out key);
					if(_array.ContainsKey(key))
					{
						ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node = _array[key];
						UInt16 slot;
						while (IS.Read(out slot) && slot != END_SLOT)
						{
							node.Property.OnUpdateAsContainer(slot, channel, IS, entity);
						}
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.MOD, key, node.Property);
						if (node.Watcher != null)
						{
							node.Watcher.OnUpdate(key, node.Property, entity);
						}						
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".MOD at Key(" + key + ") is not exist");
					}
				}
				break;
			case ViDataArrayOperator.CLEAR:
				Update_Clear(IS, entity);
				OnUpdateInvoke();
				_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.CLEAR, default(TProteKey), null);
				break;
			case ViDataArrayOperator.RESET:
				Update_Clear(IS, entity);
				Update_Start(IS, entity);
				OnUpdateInvoke();
				_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.RESET, default(TProteKey), null);
				break;
			default:
				break;
		}
	}

	void Update_Clear(ViIStream IS, ViEntity entity)
	{
		foreach (KeyValuePair<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> pair in _array)
		{
			ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node = pair.Value;
			DetachWatcher(pair.Key, node, entity);
			node.Property.End(entity);
			node.Property.Clear();
		}
		_array.Clear();
	}

	void Update_Start(ViIStream IS, ViEntity entity)
	{
		ViArrayIdx size;
		IS.ReadPacked(out size);
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViReceiveDataDictionary.size Error");
			return;
		}
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TProteKey key;
			ViSerializer<TProteKey>.Read(IS, out key);
			ViReceiveDataDictionaryNode<TProteKey, TReceiveData> newNode = ViReceiveDataCache<ViReceiveDataDictionaryNode<TProteKey, TReceiveData>>.Alloc();
			newNode.Property.ResisterInList(this);
			newNode.Property.Start(UInt16.MaxValue, IS, entity);
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
		foreach (KeyValuePair<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> pair in _array)
		{
			ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node = pair.Value;
			DetachWatcher(pair.Key, node, entity);
			node.Property.End(entity);
			node.Property.Clear();
			ViReceiveDataCache<ViReceiveDataDictionaryNode<TProteKey, TReceiveData>>.Free(node);
		}
		_array.Clear();
		Creator = null;
		DetachAllCallback();
		base.End(entity);
	}

	public override void Clear()
	{
		ViDebuger.AssertWarning(_array.Count == 0);
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
		foreach (KeyValuePair<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> pair in _array)
		{
			ViReceiveDataDictionaryNode<TProteKey, TReceiveData> iterNode = pair.Value;
			if (iterNode.Watcher == null)
			{
				AttachWatcher(pair.Key, iterNode, entity);
			}
		}
	}

	void AttachWatcher(TProteKey key, ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node, ViEntity entity)
	{
		if (Creator != null)
		{
			ViReceiveDataDictionaryNodeWatcher<TProteKey, TReceiveData> watcher = Creator();
			node.Watcher = watcher;
			if (watcher != null)
			{
				watcher.SetProperty(entity, key, node.Property);
				watcher.OnStart(key, node.Property, entity);
			}
		}
	}

	void DetachWatcher(TProteKey key, ViReceiveDataDictionaryNode<TProteKey, TReceiveData> node, ViEntity entity)
	{
		if (node.Watcher != null)
		{
			node.Watcher.OnEnd(key, node.Property, entity);
			node.Watcher.ClearProperty();
			node.Watcher = null;
		}
	}

	Dictionary<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>> _array = new Dictionary<TProteKey, ViReceiveDataDictionaryNode<TProteKey, TReceiveData>>();
	ViEventList<TProteKey, TReceiveData> _updateArrayCallbackList = new ViEventList<TProteKey, TReceiveData>();
}

public static class ViReceiveDataDictionarySerialize
{
	public static void Append<TProteKey, TReceiveData, TProtoData>(ViOStream OS, ViReceiveDataDictionary<TProteKey, TReceiveData, TProtoData> value)
		where TReceiveData : ViReceiveDataNode, new()
	{
		ViDebuger.Error("ViReceiveDataDictionarySerialize Useless");
	}
}