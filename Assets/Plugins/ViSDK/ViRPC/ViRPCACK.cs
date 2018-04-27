using System;
using System.Collections.Generic;

using ViEntityID = System.UInt64;

public class ViEntityACK
{
	public delegate void DeleACKCallback();

	public void Add(UInt16 funcID)
	{
		if (!_list.ContainsKey(funcID))
		{
			_list[funcID] = null;
		}
	}
	public void Add(UInt16 funcID, DeleACKCallback callback)
	{
		if (!_list.ContainsKey(funcID))
		{
			_list[funcID] = callback;
		}
	}
	public void Ack(UInt16 funcID)
	{
		DeleACKCallback callback = null;
		if (_list.TryGetValue(funcID, out callback))
		{
			if (callback != null)
			{
				callback();
			}
			_list.Remove(funcID);
		}
	}
	public bool Has(UInt16 funcID)
	{
		return _list.ContainsKey(funcID);
	}
	Dictionary<UInt16, DeleACKCallback> _list = new Dictionary<UInt16, DeleACKCallback>();
}
