using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class EditableContainer : EditableDataElement
{
	//km--
	public static List<String> keys = new List<String>();
	public string newFieldName = "";
	public static List<String> kmFileStrs = new List<String>();
	//km--
	
	public string ResName = string.Empty;
	public List<EditableDataElement> Children { get { return _children; } }
	
	public override bool SetValue(string data)
	{
		ViDebuger.AssertError("");
		return false;
	}
	public override bool IsModified()
	{
		foreach (EditableDataElement element in _children)
		{
			if (element.IsModified())
			{
				return true;
			}
		}
		return false;
	}
	public override void Save()
	{
		foreach (EditableDataElement element in _children)
		{
			element.Save();
		}
	}
	public override void ExportCharSet()
	{
		foreach (EditableDataElement element in _children)
		{
			element.ExportCharSet();
		}
	}
	public override void ExportStringSet()
	{
		foreach (EditableDataElement element in _children)
		{
			element.ExportStringSet();
		}
	}
	public override void ImportStringSet()
	{
		foreach (EditableDataElement element in _children)
		{
			element.ImportStringSet();
		}
	}
	public override bool CheckReserveWord(ref string log) 
	{
		bool result = false;
		foreach (EditableDataElement element in _children)
		{
			if (element.CheckReserveWord(ref log))
			{
				result = true;
			}
		}
		return result;
	}
	public override bool CheckCompleteness(ref string log)
	{
		bool result = true;
		foreach (EditableDataElement element in _children)
		{
			if (!element.CheckCompleteness(ref log))
			{
				result = false;
			}
		}
		return result;
	}
	public override void Read(ViStringIStream IS, object obj)
	{
		foreach (EditableDataElement element in _children)
		{
			element.Read(IS, obj);
		}
	}
	public override void AppendTo(ViOStream OS)
	{
		foreach (EditableDataElement element in _children)
		{
			element.AppendTo(OS);
		}
	}
	public override void AppendTo(TextWriter OS)
	{
		foreach (EditableDataElement element in _children)
		{
			element.AppendTo(OS);
		}
	}

	public void Parse(object obj)
	{
		PrintSingleField(obj.GetType().Name, obj);
	}
	string GetFileString(string parma0, string param1, string path, EditableDataMask dataType)
	{
		StringBuilder tempBuild = new StringBuilder();
		tempBuild.Append(parma0);
		tempBuild.Append("\t");
		tempBuild.Append(param1);
		tempBuild.Append("\t");
		tempBuild.Append(path);
		tempBuild.Append("\t");
		foreach (String k in dataType._info.Enums.Keys)
		{
			int value = 0;
			dataType._info.Enums.TryGetValue(k, out value);
			tempBuild.Append(value);
			tempBuild.Append("-");
			tempBuild.Append(k);
			tempBuild.Append(",");
		}
		tempBuild.Append("\t\n");

		return tempBuild.ToString();
	}

	void PrintSingleField(string fieldName, object obj)
	{
		newFieldName = fieldName;
		FieldInfo[] fieldList = ViSealedDataAssisstant.GetFeilds(obj.GetType());
		_children.Capacity = fieldList.Length;
		//FieldInfo[] fieldList = obj.GetType().GetFields(EditableDataConstValue.BindingFlag);
		//
		foreach (FieldInfo field in fieldList)
		{
			if (field.FieldType.Equals(ViBinaryReader.TYPE_Int32))
			{
				//ViDebuger.Note("Int32" + " " + fieldName + "." + field.Name);
				EnumInfo enumInfo = EnumManager.GetAsValue(field);
				if (enumInfo != null)
				{
					ParseEnum(field, enumInfo);
					continue;
				}
				enumInfo = EnumManager.GetAsMask(field);
				if (enumInfo != null)
				{
					ParseMask(field, enumInfo);
					continue;
				}
				//
				EditableDataInt32 dataType = new EditableDataInt32();
				_children.Add(dataType);
				dataType.Name = field.Name;
				dataType.NameAlias = Alias.GetMergeStr(field.Name, "Int32");
				if (field.Name.Equals(ReserveWord.ID))
				{
					dataType.Field = field;
					dataType.Value = (Int32)field.GetValue(obj);
				}
				//---------------------------------------------------
				//if (!DataEditor.Datas.km_print.Equals(""))
				//{
				//	String _path = newFieldName + "." + field.Name;
				//	if (keys.Contains(_path) == false)
				//	{
				//		keys.Add(_path);
				//		StringBuilder tempBuild = new StringBuilder();
				//		tempBuild.Append("\tTextFieldCellEditor\t");
				//		tempBuild.Append(_path);
				//		tempBuild.Append("\ttype:int\t\n");
				//		kmFileStrs.Add(tempBuild.ToString());
				//	}
				//}
				//---------------------------------------------------
			}
			else if (field.FieldType.Equals(ViBinaryReader.TYPE_Int64))
			{
				//ViDebuger.Note("Int64" + " " + fieldName + "." + field.Name);
				EditableDataInt64 dataType = new EditableDataInt64();
				_children.Add(dataType);
				dataType.Name = field.Name;
				dataType.NameAlias = Alias.GetMergeStr(field.Name, "Int64");
				if (field.Name.Equals(ReserveWord.ID))
				{
					dataType.Field = field;
					dataType.Value = (Int64)field.GetValue(obj);
				}
				//----------------------------------------------------------------------
				//if (!DataEditor.Datas.km_print.Equals(""))
				//{
				//	String _path = newFieldName + "." + field.Name;
				//	if (keys.Contains(_path) == false)
				//	{
				//		keys.Add(_path);
				//		StringBuilder tempBuild = new StringBuilder();
				//		tempBuild.Append("\tTextFieldCellEditor\t");
				//		tempBuild.Append(_path);
				//		tempBuild.Append("\ttype:int,min:-9223372036854775808,max:9223372036854775807\t\n");
				//		kmFileStrs.Add(tempBuild.ToString());
				//	}
				//}
				//---------------------------------------------------
			}
			else if (field.FieldType.Equals(ViBinaryReader.TYPE_String))
			{
				//ViDebuger.Note("String" + " " + fieldName + "." + field.Name);
				EditableDataString dataType = new EditableDataString();
				_children.Add(dataType);
				dataType.Name = field.Name;
				dataType.NameAlias = Alias.GetMergeStr(field.Name, "String");
				if (field.Name.Equals(ReserveWord.Name) || field.Name.Equals(ReserveWord.Note))
				{
					dataType.Field = field;
					dataType.Value = (String)field.GetValue(obj);
				}

				//
				//if ((typeof(PathFileStruct)).ToString().Equals(obj.GetType().ToString()))
				//{
				//    if (!DataEditor.Datas.km_print.Equals(""))
				//    {
				//        if (field.Name.Equals("File"))
				//        {
				//            String _path = newFieldName + "." + field.Name;
				//            if (keys.Contains(_path) == false)
				//            {
				//                keys.Add(_path);
				//                StringBuilder tempBuild = new StringBuilder();
				//                tempBuild.Append("PathFileStruct\tPathFileStruct\t");
				//                tempBuild.Append(_path);
				//                tempBuild.Append("\tPathFileStruct\t\n");
				//                kmFileStrs.Add(tempBuild.ToString());
				//            }
				//        }
				//    }
				//}
				//

				//----------------------------------------------------------------------
				//if (!DataEditor.Datas.km_print.Equals(""))
				//{
				//    String _path = newFieldName + "." + field.Name;
				//    if (keys.Contains(_path) == false)
				//    {
				//    keys.Add(_path);
				//    StringBuilder tempBuild = new StringBuilder();
				//    tempBuild.Append("");
				//    tempBuild.Append("\t");
				//    tempBuild.Append("TextFieldCellEditor");
				//    tempBuild.Append("\t");
				//    tempBuild.Append(_path);
				//    tempBuild.Append("\t");
				//    tempBuild.Append("type:string");
				//    tempBuild.Append("\t\n");
				//    kmFileStrs.Add(tempBuild.ToString());
				//    }
				//}
				//---------------------------------------------------
			}
			else if (field.FieldType.Equals(ViBinaryReader.TYPE_LazyString))
			{
				//ViDebuger.Note("String" + " " + fieldName + "." + field.Name);
				EditableDataLazyString dataType = new EditableDataLazyString();
				_children.Add(dataType);
				dataType.Name = field.Name;
				dataType.NameAlias = Alias.GetMergeStr(field.Name, "String");
				if (field.Name.Equals(ReserveWord.Name) || field.Name.Equals(ReserveWord.Note))
				{
					dataType.Field = field;
					dataType.Value = (ViLazyString)field.GetValue(obj);
				}
			}
			else
			{
				if (field.FieldType.IsGenericType)
				{
					if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_Mask)
					{
						ParseMask(field);
					}
					else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_Enum)
					{
						ParseEnum(field);
					}
					else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_ForeignKey)
					{
						Type foreignKeyType = ForeignKeyManager.Get(field);
						if (foreignKeyType != null)
						{
							ParseForeignKey(field, foreignKeyType);
						}
						else
						{
							ParseForeignKey(field);
						}
					}
					else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_ForeignGroup)
					{
						// 不处理
					}
					else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_SealedArray)
					{
						// 不处理
					}
					else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TTYPE_StaticArray)
					{
						object fieldObject = field.GetValue(obj);
						int len = ViArrayParser.Length(fieldObject);
						for (int idx = 0; idx < len; ++idx)
						{
							EditableContainer container = new EditableContainer();
							object elementObject = ViArrayParser.Object(fieldObject, idx);
							container.PrintSingleField(fieldName + "." + field.Name, elementObject);
							_children.Add(container);
							container.Name = field.Name;
							container.NameAlias = Alias.Get(field.Name) + "[" + field.Name + "][" + idx + "] " + elementObject.GetType().Name;
							//container.Field = field;
						}
					}
					else
					{
						EditableContainer container = new EditableContainer();
						container.PrintSingleField(fieldName + "." + field.Name, field.GetValue(obj));
						_children.Add(container);
						container.Name = field.Name;
						container.NameAlias = Alias.GetMergeStr(field.Name, field.FieldType.Name);
						//container.Field = field;
					}
				}
				else
				{
					EditableContainer container = new EditableContainer();
					container.PrintSingleField(fieldName + "." + field.Name, field.GetValue(obj));
					_children.Add(container);
					container.Name = field.Name;
					container.NameAlias = Alias.GetMergeStr(field.Name, field.FieldType.Name);
					//container.Field = field;
				}
			}
		}
	}

	void ParseEnum(FieldInfo field)
	{
		Type[] genericTypes = field.FieldType.GetGenericArguments();
		ViDebuger.AssertError(genericTypes.Length == 1);
		Type genericType = genericTypes[0];
		//ViDebuger.Note("ViEnum32<" + genericType.Name + "> " + fieldName + "." + field.Name);
		EditableDataEnum dataType = new EditableDataEnum(genericType);
		_children.Add(dataType);
		dataType.Name = field.Name;
		dataType.NameAlias = Alias.GetMergeStr(field.Name, "ViEnum32", genericType.Name);
		
		//dataType.Field = field;

		//
		//if (!DataEditor.Datas.km_print.Equals(""))
		//{
		//	String _path = newFieldName + "." + field.Name;
		//	if (keys.Contains(_path))
		//	{
		//		return;
		//	}
		//	if (dataType._info.Enums.Keys.Count == 0)
		//	{
		//		return;
		//	}
		//	StringBuilder tempBuild = new StringBuilder();
		//	tempBuild.Append("EnumsCellRenderer\tEnumsCellEditorStr\t");
		//	tempBuild.Append(_path);
		//	tempBuild.Append("\t");
		//	foreach (String k in dataType._info.Enums.Keys)
		//	{
		//		int value = 0;
		//		dataType._info.Enums.TryGetValue(k, out value);
		//		tempBuild.Append(value);
		//		tempBuild.Append("-");
		//		tempBuild.Append(k);
		//		tempBuild.Append(",");
		//	}
		//	tempBuild.Append("\t\n");
		//	keys.Add(_path);
		//	kmFileStrs.Add(tempBuild.ToString());
		//}
	}
	void ParseEnum(FieldInfo field, EnumInfo enumInfo)
	{
		EditableDataEnum dataType = new EditableDataEnum(enumInfo);
		_children.Add(dataType);
		dataType.Name = field.Name;
        dataType.NameAlias = Alias.GetMergeStr(field.Name, "ViDynamicEnum32");
		//dataType.Field = field;

		//
//		if (!DataEditor.Datas.km_print.Equals(""))
//		{
//			String _path = newFieldName + "." + field.Name;
//			if (keys.Contains(_path))
//			{
//				return;
//			}
//			if (dataType._info.Enums.Keys.Count == 0)
//			{
//				return;
//			}

//			StringBuilder tempBuild = new StringBuilder();
//			tempBuild.Append("EnumsCellRenderer\tEnumsCellEditorStr\t");
//			tempBuild.Append(_path);
//			tempBuild.Append("\t");
//			foreach (String k in dataType._info.Enums.Keys)
//			{
//				int value = 0;
//				dataType._info.Enums.TryGetValue(k, out value);
//				tempBuild.Append(value);
//				tempBuild.Append("-");
//				tempBuild.Append(k);
//				tempBuild.Append(",");
//			}
//			tempBuild.Append("\t\n");
//			keys.Add(_path);
//			kmFileStrs.Add(tempBuild.ToString());

//			//StreamWriter sw = new StreamWriter(DataEditor.Datas.km_print, true, System.Text.Encoding.Default);
//			//sw.Write("EnumsCellRenderer" + "\t");
//			//sw.Write("EnumsCellEditorStr" + "\t");
//			//sw.Write(_path + "\t");
//			//foreach (String k in dataType._info.Enums.Keys)
//			//{
////				sw.Write(k + ",");
//	//		}
//		//	sw.Write("\t");
//			//sw.WriteLine();
//			//sw.Close();
//			//keys.Add(_path);
//		}
	}
	
	
	void ParseMask(FieldInfo field)
	{
		Type[] genericTypes = field.FieldType.GetGenericArguments();
		ViDebuger.AssertError(genericTypes.Length == 1);
		Type genericType = genericTypes[0];
		//ViDebuger.Note("ViEnum32<" + genericType.Name + "> " + fieldName + "." + field.Name);
		EditableDataMask dataType = new EditableDataMask(genericType);
		_children.Add(dataType);
		dataType.Name = field.Name;
		dataType.NameAlias = Alias.GetMergeStr(field.Name, "ViMask32", genericType.Name);
		//dataType.Field = field;

		//-------------------------------------------------------------------------------
		//if (!DataEditor.Datas.km_print.Equals(""))
		//{
		//	String _path = newFieldName + "." + field.Name;
		//	if (keys.Contains(_path))
		//	{
		//		return;
		//	}
		//	if (dataType._info.Enums.Keys.Count==0)
		//	{
		//		return;
		//	}
		//	string temp = GetFileString("FlagsCellRendererStr", "FlagsPopUpCellEditorStr", _path, dataType);
		//	keys.Add(_path);
		//	kmFileStrs.Add(temp);
		//}
	}
	void ParseMask(FieldInfo field, EnumInfo enumInfo)
	{
		EditableDataMask dataType = new EditableDataMask(enumInfo);
		_children.Add(dataType);
		dataType.Name = field.Name;
        dataType.NameAlias = Alias.GetMergeStr(field.Name, "ViDynamicMask32");
		//dataType.Field = field;
		//-------------------------------------------------------------------------------
		//if (!DataEditor.Datas.km_print.Equals(""))
		//{
		//	String _path = newFieldName + "." + field.Name;
		//	if(keys.Contains(_path))
		//	{
		//		return;
		//	}
		//	if (enumInfo.Enums.Keys.Count == 0)
		//	{
		//		return;
		//	}

		//	String _temps = GetFileString("FlagsCellRendererStr", "FlagsPopUpCellEditorStr", _path, dataType);
		//	keys.Add(_path);
		//	kmFileStrs.Add(_temps);
		//}
	}
	void ParseForeignKey(FieldInfo field)
	{
		Type[] genericTypes = field.FieldType.GetGenericArguments();
		ViDebuger.AssertError(genericTypes.Length == 1);
		Type genericType = genericTypes[0];
		ParseForeignKey(field, genericType);
	}
	void ParseForeignKey(FieldInfo field, Type foreignType)
	{
		EditableDataForeignKey dataType = new EditableDataForeignKey(foreignType);
		_children.Add(dataType);
		dataType.Name = field.Name;
		dataType.NameAlias = Alias.GetMergeStr(field.Name, "ViForeignKey32", foreignType.Name);

		//--------------------------------------------------------------------------------------------
		//if (!DataEditor.Datas.km_print.Equals(""))
		//{
		//	String _path = newFieldName + "." + field.Name;
		//	if (keys.Contains(_path))
		//	{
		//		return;
		//	}
		//	StringBuilder tempBuild = new StringBuilder();
		//	tempBuild.Append("FlagsTypeIDNameRenderer\tTypeIDChooserCellEditorID\t");
		//	tempBuild.Append(_path);
		//	tempBuild.Append("\t");
		//	tempBuild.Append(foreignType.Name);
		//	tempBuild.Append(",\t\n");
		//	keys.Add(_path);
		//	kmFileStrs.Add(tempBuild.ToString());
		//}
	}

    public override void OnGUI()
    {
        mShowPosition = EditorGUILayout.Foldout(mShowPosition, Name);
        if (mShowPosition)
        {
            float height = 40.0f;
            if (_children.Count >= 10)
            {
                height = Mathf.Min(400.0f, _children.Count * 20);
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(700), GUILayout.Height(height));
            }
            for (int i = 0; i < _children.Count; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Space(50);
                EditorGUILayout.BeginVertical();
                _children[i].OnGUI();
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
            }

            if (_children.Count >= 10)
            {
                GUILayout.EndScrollView();
            }
        }
    }

    public void Clear()
    {
        _children.Clear();
    }

    Vector2 scrollPosition = Vector2.zero;
    bool mShowPosition = false;
    List<EditableDataElement> _children = new List<EditableDataElement>();
}