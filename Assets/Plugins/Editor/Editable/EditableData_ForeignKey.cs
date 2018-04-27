using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class EditableDataForeignKey : EditableDataElement
{
	public EditableDataForeignKey(Type type)
	{
		_foreignType = type;
	}
	public Type ForeignType { get { return _foreignType; } }
	public Int32 Value { get { return _value; } }
	public override bool SetValue(string data)
	{
		int value;
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
        }
        if (Field != null)
        {
            //List<ViewData> config = DataEditor.GetDatas(ForeignType);
            //if (config != null)
            //{
            //    object entity = Field.FieldType.Assembly.CreateInstance(Field.FieldType.FullName);
            //    PropertyInfo[] props = Field.FieldType.GetProperties();
            //    foreach (PropertyInfo info in props)
            //    {
            //        if (info.Name == "Value")
            //        {
            //            info.SetValue(entity, _value, null);
            //        }
            //    }
                
            //    Field.SetValue(obj, entity);
            //}
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
        List<ViewData> config = DataEditor.GetDatas(ForeignType);
        if (config == null)
        {
            Debug.Log(ForeignType.Name + " >>>>>>>>>>>>>>>");
            return;
        }
        ViewData pData;
        mNameList.Clear();
        for (int i = 0; i < config.Count; ++i)
        {
            pData = config[i];
            if (pData.data.ID == _value)
            {
                vIndex = i;
            }
            mNameList.Add(pData.data.Name);
        }

        EditorGUILayout.BeginHorizontal(GUILayout.Width(500));

        GUILayout.Label(Name, EditorStyles.boldLabel);
        vIndex = EditorGUILayout.Popup(vIndex, mNameList.ToArray(), GUILayout.Width(350));
        _value = config[vIndex].data.ID;
        EditorGUILayout.EndHorizontal();
    }


    Int32 _value;
    Int32 vIndex = 0;
	Type _foreignType;
    private List<string> mNameList = new List<string>();
}