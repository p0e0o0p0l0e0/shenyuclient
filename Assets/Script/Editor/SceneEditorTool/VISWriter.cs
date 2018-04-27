using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System;


public static class VISWriter
{
	public static readonly string VIS_Path = "../Binaries/Data/VIS/";

	public static void SaveVIS<T>() where T : ViSealedData, new()
	{
		string fileName = typeof(T).ToString();
		string path = VIS_Path + fileName + ".vis";
		string tmpPath = VIS_Path + "tmp" + fileName + ".vis";
		UnityEngine.Debug.Log("savingVIS:" + tmpPath);
		using (FileStream fs = new FileStream(path, FileMode.Open))
		{
			StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
			using (FileStream tmpFS = new FileStream(tmpPath, FileMode.Create))
			{
				StreamWriter tmpSW = new StreamWriter(tmpFS, System.Text.Encoding.Default);
				tmpSW.WriteLine(sr.ReadLine());
				tmpSW.WriteLine(sr.ReadLine());
				FieldInfo[] fieldInfos = (typeof(T)).GetFields(ViStreamReader.BindingFlag);
				//
				foreach (KeyValuePair<int, T> pair in ViSealedDB<T>.Dict)
				{
					for (int iter = fieldInfos.Length - 4; iter < fieldInfos.Length; ++iter)
					{
						FieldInfo tmpFieldInfo = fieldInfos[iter];
						T tmpData = pair.Value;
						PrintFieldToFile(tmpFieldInfo, tmpData, tmpSW);
					}
					//
					for (int iter2 = 0; iter2 < fieldInfos.Length - 4; ++iter2)
					{
						FieldInfo tmpFieldInfo = fieldInfos[iter2];
						T tmpData = pair.Value;
						PrintFieldToFile(tmpFieldInfo, tmpData, tmpSW);
					}
					tmpSW.WriteLine();
				}
				tmpSW.Close();
				fs.Close();
			}
		}

		File.Copy(tmpPath, path, true);
		File.Delete(tmpPath);
	}

	static void PrintFieldToFile<T>(FieldInfo field, T data, StreamWriter tmpSW)
	{
		System.Object tmpValue = field.GetValue(data);
		if (field.FieldType.IsGenericType)
		{
			if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_Enum)
			{
				PrintEnum(field, tmpValue, tmpSW);
				tmpSW.Write("\t");
			}
			else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_Mask)
			{
				PrintMask(field, tmpValue, tmpSW);
				tmpSW.Write("\t");
			}
			else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_ForeignKey)
			{
				PrintForeignKey(field, tmpValue, tmpSW);
				tmpSW.Write("\t");
			}
			else if (field.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TTYPE_StaticArray)
			{
				int len = ViArrayParser.Length(tmpValue);
				for (int idx = 0; idx < len; ++idx)
				{
					System.Object tmpData = ViArrayParser.Object(tmpValue, idx);
					Type dataType = tmpData.GetType();
					FieldInfo[] tmpFieldInfos = ViSealedDataAssisstant.GetFeilds(dataType);
					for (int iter = 0; iter < tmpFieldInfos.Length; ++iter)
					{
						FieldInfo tmpField = tmpFieldInfos[iter];
						PrintFieldToFile(tmpField, tmpData, tmpSW);
					}
				}
			}
		}
		else
		{
			if (field.FieldType.Equals(typeof(String)) || field.FieldType.Equals(typeof(Int32)) ||
				field.FieldType.Equals(typeof(Int64)))
			{
				tmpSW.Write(tmpValue);
				tmpSW.Write("\t");
			}
			else if (field.FieldType.Equals(typeof(UInt32)))
			{
				return;
			}
			else
			{
				FieldInfo[] tmpFieldInfos = ViSealedDataAssisstant.GetFeilds(tmpValue.GetType());
				for (int iter = 0; iter < tmpFieldInfos.Length; ++iter)
				{
					PrintFieldToFile(tmpFieldInfos[iter], tmpValue, tmpSW);
				}
			}
		}
	}

	static void PrintEnum(FieldInfo field, System.Object tmpValue, StreamWriter tmpSW)
	{
		Type[] genericTypes = field.FieldType.GetGenericArguments();
		Type genericType = genericTypes[0];
		Type type2 = tmpValue.GetType();
		FieldInfo valueField = type2.GetField("_value", ViStreamReader.BindingFlag);
		System.Object valueObj = valueField.GetValue(tmpValue);
		string enumName = Enum.GetName(genericType, valueObj);
		tmpSW.Write(enumName);
	}

	static void PrintMask(FieldInfo field, System.Object tmpValue, StreamWriter tmpSW)
	{
		Type[] genericTypes = field.FieldType.GetGenericArguments();
		Type genericType = genericTypes[0];
		Type type2 = tmpValue.GetType();
		FieldInfo valueField = type2.GetField("_value", ViStreamReader.BindingFlag);
		int maskValue = Convert.ToInt32(valueField.GetValue(tmpValue));
		foreach (int enumValue in Enum.GetValues(genericType))
		{
			string enumName = Enum.GetName(genericType, enumValue);
			if (enumName == "TOTAL" || enumName == "INF" || enumName == "SUP")
			{
				continue;
			}
			if (ViMask32.HasAll(maskValue, enumValue))
			{
				tmpSW.Write(enumName + "&");
			}
		}
	}

	static void PrintForeignKey(FieldInfo field, System.Object tmpValue, StreamWriter tmpSW)
	{
		Type type2 = tmpValue.GetType();
		FieldInfo valueField = type2.GetField("_value", ViStreamReader.BindingFlag);
		System.Object valueObj = valueField.GetValue(tmpValue);
		tmpSW.Write(valueObj);
	}

}