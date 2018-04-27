using System;
using System.Collections;
using System.Collections.Generic;

using UInt8 = System.Byte;
using Index = System.UInt16;

public enum ViReceiveDataNodeEventID
{
	START,
	UPDATE,
	DESTROY,
}

public enum ViDataArrayOperator
{
	ADD_BACK,
	ADD_FRONT,
	INSERT,
	MOD,
	DEL,
	CLEAR,
	RESET,
}

public class ViReceiveDataNode
{
	public static readonly int TYPE_SIZE = 1;

	public static bool IsNullOrDirty(ViReceiveDataNode node)
	{
		if (node == null)
		{
			return true;
		}
		return node.IsDirty;
	}
	public static void FormatDirty(ref ViReceiveDataNode node)
	{
		if (node.IsDirty)
		{
			node = null;
		}
	}

	public ViReceiveDataNode Parent { get { return _parent; } }
	public List<ViReceiveDataNode> ChildList
	{
		get
		{
			if (_childList == null)
			{
				_childList = new List<ViReceiveDataNode>();
			}
			return _childList;
		}
	}
	public ViEventList<ViReceiveDataNode, object> CallbackList
	{
		get
		{
			if (_updateCallbackList == null)
			{
				_updateCallbackList = new ViEventList<ViReceiveDataNode, object>();
			} 
			return _updateCallbackList;
		}
	}
	public bool IsDirty { get { return _parent == null; } }
	public virtual int GetSize() { return TYPE_SIZE; }
	public bool MatchChannel(UInt8 channel)
	{
		UInt16 mask = (UInt16)(1 << (int)channel);
		return (_channelMask & mask) != 0;
	}
	public bool MatchChannel(UInt16 channelMask)
	{
		return (channelMask & _channelMask) != 0;
	}
	//
	public virtual void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ViDebuger.Warning("Must be Override");
	}
	public virtual void OnUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		ViDebuger.Warning("Must be Override");
	}
	public void OnUpdateAsContainer(Index slot, UInt8 channel, ViIStream IS, ViEntity entity)
	{
		if (slot >= ChildList.Count)
		{
			ViDebuger.Error("slot(" + slot + ") >= _updateSlots.Count(" + ChildList.Count + ")");
			return;
		}
		ViReceiveDataNode data = ChildList[slot];
		if (data != null)
		{
			data.OnUpdate(channel, IS, entity);
		}
		else
		{
			ViDebuger.Error("_updateSlots[" + slot + "] == null");
		}
	}
	public virtual void End(ViEntity entity)
	{
		if (_updateCallbackList != null)
		{
			_updateCallbackList.Clear();
		}
	}
	public virtual void Clear()
	{
		if (_updateCallbackList != null)
		{
			_updateCallbackList.Clear();
		}
		if (_childList != null)
		{
			_childList.Clear();
		}
		_parent = null;
	}
	public void ReservePropertySize(int size)
	{
		ChildList.Capacity = size;
	}

	public virtual void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		//
		childList.Add(this);
	}

	protected void _RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent)
	{
		_channelMask = channelMask;
		_parent = parent;
	}

	public void ResisterInList(ViReceiveDataNode parent)
	{
		ReservePropertySize(GetSize());
		RegisterAsChild(ViConstValueDefine.MAX_UINT16, parent, ChildList);
	}

	protected void OnUpdateInvoke()
	{
		if (_updateCallbackList != null)
		{
			_updateCallbackList.Invoke((UInt32)ViReceiveDataNodeEventID.UPDATE, this, null);
		}
		if (_parent != null)
		{
			_parent.OnUpdateFromChildren(this);
		}
	}

	void OnUpdateFromChildren(ViReceiveDataNode node)
	{
		if (_updateCallbackList != null)
		{
			_updateCallbackList.Invoke((UInt32)ViReceiveDataNodeEventID.UPDATE, node, null);
		}
		if (_parent != null)
		{
			_parent.OnUpdateFromChildren(node);
		}
	}

	protected void OnUpdateInvoke<T>(T oldValue)
	{
		if (_updateCallbackList != null)
		{
			_updateCallbackList.Invoke((UInt32)ViReceiveDataNodeEventID.UPDATE, this, oldValue);
		}
		if (_parent != null)
		{
			_parent.OnUpdateFromChildren(this, oldValue);
		}
	}

	void OnUpdateFromChildren<T>(ViReceiveDataNode node, T oldValue)
	{
		if (_updateCallbackList != null)
		{
			_updateCallbackList.Invoke((UInt32)ViReceiveDataNodeEventID.UPDATE, node, oldValue);
		}
		if (_parent != null)
		{
			_parent.OnUpdateFromChildren(node, oldValue);
		}
	}

	UInt16 _channelMask;
	ViReceiveDataNode _parent;
	List<ViReceiveDataNode> _childList;
	ViEventList<ViReceiveDataNode, object> _updateCallbackList;
}

public static class ViReceiveDataNodeAssisstant
{
	public static bool IsNullOrDirty(this ViReceiveDataNode node)
	{
		return ViReceiveDataNode.IsNullOrDirty(node);
	}
}
