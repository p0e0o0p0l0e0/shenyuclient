using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditableDataString : EditableDataElement
{
	public string Value { get { return _value; } set { if (value != null) { _value = value; } } }
	public override bool SetValue(string data)
	{
        _value = data;
		return true;
	}

	public override void ExportCharSet() 
	{
		for (int idx = 0; idx < Value.Length; ++idx)
		{
			char value = Value[idx];
			CharSetEx.Add(value);
		}
	}
	public override void ExportStringSet()
	{
		Save();
		StringSet.Add(Name, Value);
	}
	public override void ImportStringSet()
	{
		Save();
		StringSet.Replace(Name, ref _value);
	}

	public override void Read(ViStringIStream IS, object obj)
	{
		IS.Read(out _value);
        SetValue(_value);
		if (Field != null)
        {
            Field.SetValue(obj, _value);
        }
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
            OS.Write(_value);
        }
        else
        {
            OS.Write("\t" + _value);
        }
    }

    public override void OnGUI()
    {
        SetValue(EditorGUILayout.TextField(Name, _value.ToString(), GUILayout.Width(500)));
    }

    string _value = string.Empty;
}
