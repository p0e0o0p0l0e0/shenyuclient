using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class EditableDataEnum : EditableDataElement
{
	public EditableDataEnum(Type type)
	{
		_info = EnumManager.GetStatic(type);
        FormatShowData();
    }
	public EditableDataEnum(EnumInfo enumInfo)
	{
		_info = enumInfo;
        FormatShowData();
    }

	public EnumInfo Info { get { return _info; } }
	public string Description { get { return _description; } }

	public int GetNumValue(string data)
	{
		int value = 0;
		_info.GetValue(data, out value);
		return value;
	}

	public override bool SetValue(string data)
	{
		int value;
		if (_info.GetValue(data, out value))
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
	public override void Save()
	{
        SetValue(_description);
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
	public override void AppendTo(ViOStream OS)
	{
		Save();
		OS.Append(_value);
	}
	public override void AppendTo(TextWriter OS)
	{
        _description = _info.EnumsLable[_value];
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
	public virtual bool IsValue(string strEnum)
	{
		int value;
		if (_info.GetValue(strEnum, out value))
		{
			return value == _value;
		}
		else
		{
			return false;
		}
	}

    private void FormatShowData()
    {
        mShowList.Clear();
        for (int i = 0; i < _info.EnumsLable.Count; ++i)
        {
            string skey = i + " <> " + _info.EnumsLable[i] + " <> " + Alias.Get(_info.EnumsLable[i]);
            skey = skey.Replace("/", "|");
            mShowList.Add(skey);
        }
    }

    public override void OnGUI()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.Width(500));

        GUILayout.Label(Name, EditorStyles.boldLabel);
        _value = EditorGUILayout.Popup(_value, mShowList.ToArray(), GUILayout.Width(350));
        _description = _info.EnumsLable[_value];
        EditorGUILayout.EndHorizontal();
    }

    Int32 _value;
	string _description = string.Empty;
	public EnumInfo _info;
    List<string> mShowList = new List<string>();
}
