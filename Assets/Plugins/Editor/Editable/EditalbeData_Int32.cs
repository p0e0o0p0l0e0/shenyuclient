using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditableDataInt32 : EditableDataElement
{
	public Int32 Value { get { return _value; } set { _value = value; } }
	public override bool SetValue(string data)
	{
		Int32 value;
		if (Int32.TryParse(data, out value))
		{
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
			if (Field != null)
            {
                Field.SetValue(obj, _value);
            }
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

    Int32 _value;
}
