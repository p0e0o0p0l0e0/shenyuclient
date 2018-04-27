using System;
using System.Collections.Generic;
using System.Text;


public class ViFomatDictionary
{
	public Dictionary<string, string> ReplaceList { get { return _replaceList; } }
	public ViDoubleLink2<ViFomatString> RegisterList { get { return _registerList; } }

	public void Set(string oldValue, string newValue)
	{
		ReplaceList[oldValue] = newValue;
	}

	public void Broadcast()
	{
		ViDoubleLinkNode2<ViFomatString> iter = RegisterList.GetHead();
		while (!RegisterList.IsEnd(iter))
		{
			ViFomatString iterFomat = iter.Data;
			ViDoubleLink2<ViFomatString>.Next(ref iter);
			iterFomat.OnReplace();
		}
	}

	public bool TryGet(ref string value)
	{
		string newValue;
		if (ReplaceList.TryGetValue(value, out newValue))
		{
			value = newValue;
			return true;
		}
		else
		{
			return false;
		}
	}

	public void Clear()
	{
		ReplaceList.Clear();
	}

	public void Register(ViDoubleLinkNode2<ViFomatString> node)
	{
		RegisterList.PushBack(node);
	}
	
	Dictionary<string, string> _replaceList = new Dictionary<string, string>();
	ViDoubleLink2<ViFomatString> _registerList = new ViDoubleLink2<ViFomatString>();
}

public class ViFomatString
{
	public static ViFomatDictionary Dictionary { get { return _dictionary; } }
	static ViFomatDictionary _dictionary = new ViFomatDictionary();

	public static implicit operator string(ViFomatString data)
	{
		return data.Desc;
	}

	public ViFomatString(string name) 
	{
		_name = name;
		Fomat(true);
	}
	public ViFomatString(string name, bool replace)
	{
		_name = name;
		Fomat(replace);
	}

	void Fomat(bool replace)
	{
		_desc = _name;
		if (replace)
		{
			_replaceNode.Data = this;
			Dictionary.TryGet(ref _desc);
			Dictionary.Register(_replaceNode);
		}
		_descFragmentList = _desc.Split(Sign);
	}

	public string Name { get { return _name; } }
	public string Desc { get { return _desc; } }
	public string[] DescFragmentList { get { return _descFragmentList; } }

	public string Print()
	{
		return Desc;
	}

	public string Print(string value0)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string value0, string value1)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		_valueCache.Add(value1);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string value0, string value1, string value2)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		_valueCache.Add(value1);
		_valueCache.Add(value2);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string value0, string value1, string value2, string value3)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		_valueCache.Add(value1);
		_valueCache.Add(value2);
		_valueCache.Add(value3);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string value0, string value1, string value2, string value3, string value4)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		_valueCache.Add(value1);
		_valueCache.Add(value2);
		_valueCache.Add(value3);
		_valueCache.Add(value4);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string value0, string value1, string value2, string value3, string value4, string value5)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		_valueCache.Add(value1);
		_valueCache.Add(value2);
		_valueCache.Add(value3);
		_valueCache.Add(value4);
		_valueCache.Add(value5);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string value0, string value1, string value2, string value3, string value4, string value5, string value6)
	{
		_valueCache.Clear();
		_valueCache.Add(value0);
		_valueCache.Add(value1);
		_valueCache.Add(value2);
		_valueCache.Add(value3);
		_valueCache.Add(value4);
		_valueCache.Add(value5);
		_valueCache.Add(value6);
		return PrintEx(_descFragmentList, _valueCache);
	}

	public string Print(string[] valueArray)
	{
		_valueCache.Clear();
		for (int index = 0; index < valueArray.Length; ++ index)
		{
			_valueCache.Add(valueArray[index]);
		}
		return PrintEx(_descFragmentList, _valueCache);
	}

	public void OnReplace()
	{
		_desc = _name;
		if (Dictionary.TryGet(ref _desc))
		{
			_descFragmentList = _desc.Split(Sign);
		}
	}

	static ViStringBuilder _printBuilder = new ViStringBuilder(1024);
	static string PrintEx(string[] logList, List<string> valueList)
	{
		_printBuilder.Clear();
		int iter = 0;
		int minCount = (logList.Length < valueList.Count) ? logList.Length : valueList.Count;
		for (; iter < minCount; ++iter)
		{
			_printBuilder.Add(logList[iter]);
			_printBuilder.Add(valueList[iter]);
		}
		for (; iter < logList.Length; ++iter)
		{
			_printBuilder.Add(logList[iter]);
		}
		for (; iter < valueList.Count; ++iter)
		{
			_printBuilder.Add(valueList[iter]);
		}
		return _printBuilder.Value;
	}

	string _name;
	string _desc;
	string[] _descFragmentList;
	List<string> _valueCache = new List<string>();
	ViDoubleLinkNode2<ViFomatString> _replaceNode = new ViDoubleLinkNode2<ViFomatString>();

	static char[] Sign = { '&' };
}

