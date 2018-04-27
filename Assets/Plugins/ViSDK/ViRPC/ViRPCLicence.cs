using System;
using System.Collections.Generic;

using UInt8 = System.Byte;

public class ViRPCLicence
{
	public bool Error { get { return _error; } }

	public UInt8 Create()
	{
		if (_licenceList.Count == 0)
		{
			_error = true;
			return (UInt8)0;
		}
		UInt8 licence = _licenceList[_licenceList.Count - 1];
		_licenceList.RemoveAt(_licenceList.Count - 1);
		return licence;
	}

	public void Add(List<UInt8> list)
	{
		list.Reverse();
		_licenceList.InsertRange(0, list);
		_error = false;
	}

	public void Clear()
	{
		_licenceList.Clear();
	}

	bool _error = false;
	List<UInt8> _licenceList = new List<UInt8>();
}
