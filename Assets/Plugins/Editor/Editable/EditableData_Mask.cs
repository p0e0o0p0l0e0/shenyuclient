using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class EditableDataMask : EditableDataElement
{
	public EditableDataMask(Type type)
	{
		_info = EnumManager.GetStatic(type);
        FormatShowData();
    }
	public EditableDataMask(EnumInfo enumInfo)
	{
		_info = enumInfo;
        FormatShowData();
    }

	public EnumInfo Info { get { return _info; } }
	public string Description { get { return _description; } }

	public int GetNumValue(string data)
	{
		int value = 0;
		_info.GetMask(data, out value);
		return value;
	}

	public override bool SetValue(string data)
	{
		int value;
		if (_info.GetMask(data, out value))
		{
			_description = data;
			_value = value;
			return true;
		}
		else
		{
			return false;
		}
    }

    public override void Read(ViStringIStream IS, object obj)
	{
		string value;
		if (IS.Read(out value))
		{
			SetValue(value);
		}
        if (Field != null)
        {
            //object entity = Field.FieldType.Assembly.CreateInstance(Field.FieldType.FullName);
            //PropertyInfo[] props = Field.FieldType.GetProperties();
            //foreach (PropertyInfo info in props)
            //{
            //    info.SetValue(entity, _value, null);
            //}
            //Field.SetValue(obj, entity);
        }
    }

    public override void Save()
    {
        _description = "";
        foreach (var element in _info.Enums)
        {
            if (_value == -1 || ViMask32.HasAny(_value, element.Value))
            {
                _description += element.Key + "&";
            }
        }

        SetValue(_description);
    }

    public override void AppendTo(ViOStream OS)
	{
		Save();
		OS.Append(_value);
	}
	public override void AppendTo(TextWriter OS)
	{
		Save();
		if (DataEditor.IS_START)
		{
            DataEditor.IS_START = false;
			OS.Write(_description);
		}
		else
		{
			OS.Write("\t" + _description);
		}
	}
	public bool HasValue(string strEnum)
	{
		Int32 value;
		if (_info.GetMask(strEnum, out value))
		{
			return ViMask32.HasAll(_value, value);
		}
		else
		{
			return false;
		}
	}

    private void FormatShowData()
    {
        mShowList.Clear();
        int index = 0;
        foreach (var element in _info.Enums)
        {
            string skey = element.Value + " <> " + _info.EnumsLable[index] + " <> " + Alias.Get(_info.EnumsLable[index]);
            skey = skey.Replace("/", "|");
            mShowList.Add(skey);
            ++index;
        }
    }

    public override void OnGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.Width(500));
        _value =  EditorGUILayout.MaskField(Name, _value, mShowList.ToArray(), GUILayout.Width(350));
        EditorGUILayout.EndHorizontal();
    }

    Int32 _value;
	string _description = string.Empty;
	public EnumInfo _info;
    List<string> mShowList = new List<string>();
}