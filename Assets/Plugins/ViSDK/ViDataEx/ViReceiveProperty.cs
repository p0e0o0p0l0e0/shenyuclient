using System;
using System.Collections.Generic;

using UInt8 = System.Byte;
using Index = System.UInt16;

public class ViReceiveProperty : ViReceiveDataNode, ViReceiveDataMemoryObject
{
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	public void OnCacheAlloc(){}
	public void OnCacheFree()
	{
		Clear();
	}
	public virtual void StartProperty(UInt16 channelMask, ViIStream IS, ViEntity entity) { }
	public virtual void OnPropertyUpdate(UInt8 channel, ViIStream IS, ViEntity entity) { }
	public virtual void EndProperty(ViEntity entity)
	{
		
	}
	public override void Clear()
	{
		_indexPropertys.Clear();
		//
		base.Clear();
	}
	public void ReserveIdxPropertySize(int size)
	{
		_indexPropertys.Capacity = size;
	}
	public void AddIdxProperty(ViReceiveDataInt32 data)
	{
		_indexPropertys.Add(data);
	}
	public ViReceiveDataInt32 GetIdxProperty(Index idx)
	{
		if (idx >= _indexPropertys.Count)
		{
			return null;
		}
		else
		{
			return _indexPropertys[idx];
		}
	}

	List<ViReceiveDataInt32> _indexPropertys = new List<ViReceiveDataInt32>();
}

