using System;
using System.Collections;
using System.Collections.Generic;
using ViOperatorIdx = System.Byte;
using ViArrayIdx = System.Int32;
using UInt8 = System.Byte;


public abstract class ViReceiveDataArrayNodeWatcher<TReceiveData>
	where TReceiveData : ViReceiveDataNode
{
	public ViEntity Entity { get { return _entity; } }
	public TReceiveData Property { get { return _property; } }
	public bool IsDirty { get { return _property == null; } }
	public void SetProperty(ViEntity entity, TReceiveData property)
	{
		_entity = entity;
		_property = property;
	}
	public void ClearProperty()
	{
		_entity = null;
		_property = null;
	}
	public abstract void OnStart(TReceiveData property, ViEntity entity);
	public abstract void OnUpdate(TReceiveData property, ViEntity entity);
	public abstract void OnEnd(TReceiveData property, ViEntity entity);
	ViEntity _entity;
	TReceiveData _property;
}

public class ViReceiveDataArrayNode<TReceiveData> : ViReceiveDataMemoryObject
	where TReceiveData : ViReceiveDataNode, new()
{
	public TReceiveData Property { get { return _proeperty; } }
	public ViReceiveDataArrayNodeWatcher<TReceiveData> Watcher;

	public void OnCacheAlloc()
	{

	}

	public void OnCacheFree()
	{
		_proeperty = null;
	}

	TReceiveData _proeperty = new TReceiveData();
}

public class ViReceiveDataArray<TReceiveData, TProto> : ViReceiveDataNode
	where TReceiveData : ViReceiveDataNode, new()
{
	public static readonly UInt16 END_SLOT = 0XFFFF;
	public static string GLOBAL_NAME { get { return "ViReceiveDataArray<" + typeof(TProto).Name + ">"; } }

	public delegate ViReceiveDataArrayNodeWatcher<TReceiveData> WatcherCreator();
	public WatcherCreator Creator;

	public ViEventList<TReceiveData> UpdateArrayCallbackList { get { return _updateArrayCallbackList; } }
	public int Count { get { return _array.Count; } }
	public List<ViReceiveDataArrayNode<TReceiveData>> Array { get { return _array; } }
	public ViReceiveDataArrayNode<TReceiveData> this[int index] { get { return Array[index]; } }
	//

	public ViArrayIdx GetIndex(TReceiveData data, ViArrayIdx defaultIndex)
	{
		for (ViArrayIdx iter = 0; iter < _array.Count; ++iter)
		{
			if (System.Object.ReferenceEquals(data, _array[iter].Property))
			{
				return iter;
			}
		}
		return defaultIndex;
	}
	public bool GetIndex(TReceiveData data, out ViArrayIdx index)
	{
		for (ViArrayIdx iter = 0; iter < _array.Count; ++iter)
		{
			if (System.Object.ReferenceEquals(data, _array[iter].Property))
			{
				index = iter;
				return true;
			}
		}
		index = _array.Count;
		return false;
	}

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
			case ViDataArrayOperator.ADD_BACK:
				{
					ViReceiveDataArrayNode<TReceiveData> newNode = ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Alloc();
					newNode.Property.ResisterInList(this);
					newNode.Property.Start(UInt16.MaxValue, IS, entity);
					AttachWatcher(newNode, entity);
					_array.Add(newNode);
					OnUpdateInvoke();
					_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.ADD_BACK, newNode.Property);
				}
				break;
			case ViDataArrayOperator.ADD_FRONT:
				{
					ViReceiveDataArrayNode<TReceiveData> newNode = ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Alloc();
					newNode.Property.ResisterInList(this);
					newNode.Property.Start(UInt16.MaxValue, IS, entity);
					AttachWatcher(newNode, entity);
					_array.Insert(0, newNode);
					OnUpdateInvoke();
					_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.ADD_FRONT, newNode.Property);
				}
				break;
			case ViDataArrayOperator.INSERT:
				{
					ViArrayIdx idx;
					IS.ReadPacked(out idx);
					if (idx <= _array.Count)
					{
						ViReceiveDataArrayNode<TReceiveData> newNode = ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Alloc();
						newNode.Property.ResisterInList(this);
						newNode.Property.Start(UInt16.MaxValue, IS, entity);
						AttachWatcher(newNode, entity);
						_array.Insert(idx, newNode);
						OnUpdateInvoke();
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.INSERT, newNode.Property);
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".INSERT at Slot(" + idx + ") > " + "Count(" + _array.Count + ")");
					}
				}
				break;
			case ViDataArrayOperator.DEL:
				{
					ViArrayIdx idx;
					IS.ReadPacked(out idx);
					if (idx < _array.Count)
					{
						ViReceiveDataArrayNode<TReceiveData> node = _array[idx];
						_array.RemoveAt(idx);
						OnUpdateInvoke(node.Property);
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.DEL, node.Property);
						DetachWatcher(node, entity);
						node.Property.End(entity);
						node.Property.Clear();
						ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Free(node);
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".DEL at Slot(" + idx + ") >= " + "Count(" + _array.Count + ")");
					}
				}
				break;
			case ViDataArrayOperator.MOD:
				{
					ViArrayIdx idx;
					IS.ReadPacked(out idx);
					if (idx < _array.Count)
					{
						ViReceiveDataArrayNode<TReceiveData> node = _array[idx];
						UInt16 slot;
						while (IS.Read(out slot) && slot != END_SLOT)
						{
							node.Property.OnUpdateAsContainer(slot, channel, IS, entity);
						}
						_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.MOD, node.Property);
						if (node.Watcher != null)
						{
							node.Watcher.OnUpdate(node.Property, entity);
						}
					}
					else
					{
						ViDebuger.Warning(GLOBAL_NAME + ".MOD at Slot(" + idx + ") >= " + "Count(" + _array.Count + ")");
					}
				}
				break;
			case ViDataArrayOperator.CLEAR:
				Update_Clear(IS, entity);
				OnUpdateInvoke();
				_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.CLEAR, null);
				break;
			case ViDataArrayOperator.RESET:
				Update_Clear(IS, entity);
				Update_Start(IS, entity);
				OnUpdateInvoke();
				_updateArrayCallbackList.Invoke((UInt32)ViDataArrayOperator.RESET, null);
				break;
			default:
				break;
		}
	}

	void Update_Clear(ViIStream IS, ViEntity entity)
	{
		for (int iter = 0; iter < _array.Count; ++iter)
		{
			ViReceiveDataArrayNode<TReceiveData> node = _array[iter];
			DetachWatcher(node, entity);
			node.Property.End(entity);
			node.Property.Clear();
			ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Free(node);
		}
		_array.Clear();
	}

	void Update_Start(ViIStream IS, ViEntity entity)
	{
		ViArrayIdx size;
		IS.ReadPacked(out size);
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViReceiveDataArray.size Error");
			return;
		}
		_array.Capacity = (int)size;
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			ViReceiveDataArrayNode<TReceiveData> newNode = ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Alloc();
			newNode.Property.ResisterInList(this);
			newNode.Property.Start(UInt16.MaxValue, IS, entity);
			AttachWatcher(newNode, entity);
			_array.Add(newNode);
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
		for (int iter = 0; iter < _array.Count; ++iter)
		{
			ViReceiveDataArrayNode<TReceiveData> node = _array[iter];
			DetachWatcher(node, entity);
			node.Property.End(entity);
			node.Property.Clear();
			ViReceiveDataCache<ViReceiveDataArrayNode<TReceiveData>>.Free(node);
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

	void DetachAllCallback()
	{
		_updateArrayCallbackList.Clear();
	}

	public void UpdateWatcher(WatcherCreator Creator, ViEntity entity)
	{
		for (int iter = 0; iter < _array.Count; ++iter)
		{
			ViReceiveDataArrayNode<TReceiveData> iterNode = _array[iter];
			if (iterNode.Watcher == null)
			{
				AttachWatcher(iterNode, entity);
			}
		}
	}

	void AttachWatcher(ViReceiveDataArrayNode<TReceiveData> node, ViEntity entity)
	{
		if (Creator != null)
		{
			ViReceiveDataArrayNodeWatcher<TReceiveData> watcher = Creator();
			node.Watcher = watcher;
			if (watcher != null)
			{
				watcher.SetProperty(entity, node.Property);
				watcher.OnStart(node.Property, entity);
			}
		}
	}

	void DetachWatcher(ViReceiveDataArrayNode<TReceiveData> node, ViEntity entity)
	{
		if (node.Watcher != null)
		{
			node.Watcher.OnEnd(node.Property, entity);
			node.Watcher.ClearProperty();
			node.Watcher = null;
		}
	}

	//
	List<ViReceiveDataArrayNode<TReceiveData>> _array = new List<ViReceiveDataArrayNode<TReceiveData>>();
	ViEventList<TReceiveData> _updateArrayCallbackList = new ViEventList<TReceiveData>();
}

public static class ViReceiveDataArraySerialize
{
	public static void Append<T, L>(ViOStream OS, ViReceiveDataArray<T, L> value)
	where T : ViReceiveDataNode, new()
	{
		ViDebuger.Error("ViReceiveDataArraySerialize Useless");
	}
}