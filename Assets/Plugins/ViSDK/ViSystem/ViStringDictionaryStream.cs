using System;
using System.Collections.Generic;
using System.Text;

public class ViStringDictionaryStream
{
	public void Load(string stream)
	{
		_list.Clear();
		//
		char[] split = {'&'};
		//
		string[] elementList = stream.Split(split, StringSplitOptions.None);
		for (int iter = 0; iter < elementList.Length; )
		{
			string iterKey = elementList[iter];
			++iter;
			string iterValue = elementList[iter];
			++iter;
			_list[iterKey] = iterValue;
		}
	}
	public string Print()
	{
		return Print("=", "&");
	}

	static ViStringBuilder _printBuilder = new ViStringBuilder(1024);
	public string Print(string split, string span)
	{
		_printBuilder.Clear();
		foreach (KeyValuePair<string, string> iter in _list)
		{
			_printBuilder.Add(iter.Key);
			_printBuilder.Add(split);
			_printBuilder.Add(iter.Value);
			_printBuilder.Add(span);
		}
		return _printBuilder.Value;
	}
	public void Clear()
	{
		_list.Clear();
	}

	public bool TryGet(string key, out string value)
	{
		return _list.TryGetValue(key, out value);
	}
	public string Get(string key, string defaultValue) 
	{
		string value;
		if (_list.TryGetValue(key, out value))
		{
			return value;
		}
		else
		{
			return defaultValue;
		}
	}
	public void Add(string key, string value)
	{
		_list[key] = value;
	}

	Dictionary<string, string> _list = new Dictionary<string, string>();
}