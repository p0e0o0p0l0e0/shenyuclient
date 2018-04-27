using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public static class EditableDataConstValue
{
	public static readonly BindingFlags BindingFlag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
}

public class CharSetEx
{
	public static void Add(char value)
	{
		List.Add(value);
	}
	public static HashSet<char> List = new HashSet<char>();
}

public static class ReserveWord
{
    public static string ID = "ID";
    public static string Name = "Name";
    public static string Note = "Note";
    public static string Int32 = "Int32";
    public static string String = "String";
}

public class StringSet
{
	public static void Add(string name, string value)
	{
		if (value == string.Empty)
		{
			return;
		}
		if (!NameList.Contains(name))
		{
			return;
		}
		if (List.ContainsKey(value))
		{
			return;
		}
		List.Add(value, null);
	}
	public static void Set(string value, string replaceValue)
	{
		List[value] = replaceValue;
	}
	public static void Replace(string name, ref string value)
	{
		if (!NameList.Contains(name))
		{
			return;
		}
		if (!List.ContainsKey(value))
		{
			return;
		}
		value = List[value];
	}
	public static Dictionary<string, string> List = new Dictionary<string, string>();
	public static HashSet<string> NameList = new HashSet<string>();
}



public abstract class EditableDataElement
{
	public string Name { get { return _name; } set { _name = value; } }
	public string NameAlias { get { return _nameAlias; } set { _nameAlias = value; } }
	public object Data { get { return _data; } set { _data = value; } }
	public FieldInfo Field { get { return _field; } set { _field = value; } }
	public char FormatTag;

	public virtual void WriteName(TextWriter OS)
	{
		OS.Write(Name + "\t");
	}
    public virtual bool SetValue(string data) { return false; }
	public virtual bool IsModified() { return false; }
	public virtual void Save() { }
	public virtual void Read(ViStringIStream IS, object obj) { }
	public virtual void AppendTo(ViOStream OS) { }
	public virtual void AppendTo(TextWriter OS) { }

	public virtual void ExportCharSet() { }
	public virtual void ExportStringSet() { }
	public virtual void ImportStringSet() { }
	public virtual bool CheckReserveWord(ref string log) { return false; }
	public virtual bool CheckCompleteness(ref string log) { return true; }

    public virtual void OnGUI() { }
    public virtual void OnGUI(int offset) { }

    string _name = string.Empty;
	string _nameAlias = string.Empty;
	object _data;
	FieldInfo _field;
}

public class EnumInfo
{
	public Dictionary<string, int> Enums { get { return _enumIdxList; } }
    public List<string> EnumsLable = new List<string>();

    public bool GetValue(string name, out int value)
	{
		return _enumIdxList.TryGetValue(name, out value);
	}
	public bool GetMask(string name, out int value)
	{
		string[] _description = name.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
		int valueOut = 0;
		foreach (string key in _description)
		{
			int elementValuel;
			if (!_enumIdxList.TryGetValue(key, out elementValuel))
			{
				ViDebuger.Note("MaskInfo 无法找到" + key);
				continue;
			}
			ViMask32.Add(ref valueOut, elementValuel);
		}
		value = valueOut;
		return true;
	}
	public void Load(Type type)
	{
		string[] names = Enum.GetNames(type);
		Array values = Enum.GetValues(type);
		int idx = 0;
		foreach (string name in names)
		{
			if (name == "TOTAL" || name == "INF" || name == "SUP")
			{
				++idx;
				continue;
			}
            if (_enumIdxList.ContainsKey(name))
            {
                ++idx;
                continue;
            }
			int value = (int)values.GetValue(idx);
			_enumIdxList[name] = (int)values.GetValue(idx);
            EnumsLable.Add(name);

            ++idx;
		}
	}
	Dictionary<string, int> _enumIdxList = new Dictionary<string, int>();
}
public static class EnumManager
{
	public static EnumInfo RegisterAsValue(Type type, string fieldName, Type enumType)
	{
		FieldInfo[] fieldList = type.GetFields(EditableDataConstValue.BindingFlag);///为了保证顺序
		FieldInfo field = type.GetField(fieldName, EditableDataConstValue.BindingFlag);
		ViDebuger.AssertWarning(field);
		EnumInfo info;
		if (_valueList.TryGetValue(field, out info))
		{
			info.Load(enumType);
			return info;
		}
		info = GetDynamic(enumType);
		_valueList[field] = info;
		return info;
	}
	public static EnumInfo RegisterAsMask(Type type, string fieldName, Type enumType)
	{
		FieldInfo[] fieldList = type.GetFields(EditableDataConstValue.BindingFlag);///为了保证顺序
		FieldInfo field = type.GetField(fieldName, EditableDataConstValue.BindingFlag);
		ViDebuger.AssertWarning(field);
		EnumInfo info;
		if (_maskList.TryGetValue(field, out info))
		{
			info.Load(enumType);
			return info;
		}
		info = GetDynamic(enumType);
		_maskList[field] = info;
		return info;
	}
	public static EnumInfo GetStatic(Type type)
	{
		EnumInfo info;
		if (_staticEnumList.TryGetValue(type, out info))
		{
			return info;
		}
		else
		{
			info = new EnumInfo();
			info.Load(type);
			_staticEnumList[type] = info;
			return info;
		}
	}
	public static EnumInfo GetDynamic(Type type)
	{
		EnumInfo info;
		if (_dynamicEnumList.TryGetValue(type, out info))
		{
			return info;
		}
		else
		{
			info = new EnumInfo();
			_dynamicEnumList[type] = info;
			info.Load(type);
			return info;
		}
	}
	public static EnumInfo GetAsValue(FieldInfo field)
	{
		EnumInfo info;
		if (_valueList.TryGetValue(field, out info))
		{
			return info;
		}
		else
		{
			return null;
		}
	}
	public static EnumInfo GetAsMask(FieldInfo field)
	{
		EnumInfo info;
		if (_maskList.TryGetValue(field, out info))
		{
			return info;
		}
		else
		{
			return null;
		}
	}

	static Dictionary<Type, EnumInfo> _staticEnumList = new Dictionary<Type, EnumInfo>();
	static Dictionary<Type, EnumInfo> _dynamicEnumList = new Dictionary<Type, EnumInfo>();
	static Dictionary<FieldInfo, EnumInfo> _valueList = new Dictionary<FieldInfo, EnumInfo>();
	static Dictionary<FieldInfo, EnumInfo> _maskList = new Dictionary<FieldInfo, EnumInfo>();
}



public static class ForeignKeyManager
{
	public static void Register(Type type, string fieldName, Type foreignType)
	{
		FieldInfo[] fieldList = type.GetFields(EditableDataConstValue.BindingFlag);///为了保证顺序
		FieldInfo field = type.GetField(fieldName, EditableDataConstValue.BindingFlag);
		ViDebuger.AssertWarning(field);
		_typeList[field] = foreignType;
	}

	public static Type Get(FieldInfo field)
	{
		Type info;
		if (_typeList.TryGetValue(field, out info))
		{
			return info;
		}
		else
		{
			return null;
		}
	}
	static Dictionary<FieldInfo, Type> _typeList = new Dictionary<FieldInfo, Type>();
}