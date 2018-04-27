using System;
using System.Collections.Generic;
using ViArrayIdx = System.Int32;
using Int8 = System.SByte;
using UInt8 = System.Byte;

public class ViSerializer<T>
{
	public delegate void DeleAppend(ViOStream OS, T value);
	public static DeleAppend AppendExec;
	public delegate void DeleRead(ViIStream IS, out T value);
	public static DeleRead ReadExec;
	//
	public delegate bool DeleReadString(ViStringIStream IS, out T value);
	public static DeleReadString ReadStringExec;
	//
	public delegate void DeleAppendDictionaryString(ViStringDictionaryStream OS, string head, T value);
	public static DeleAppendDictionaryString AppendDictionaryStringExec;
	public delegate void DeleReadDictionaryString(ViStringDictionaryStream IS, string head, out T value);
	public static DeleReadDictionaryString ReadDictionaryStringExec;

	public static void Append(ViOStream OS, T value)
	{
		ViDebuger.AssertError(AppendExec != null);
		AppendExec(OS, value);
	}
	public static void Append(ViOStream OS, List<T> list)
	{
		ViDebuger.AssertError(AppendExec != null);
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			AppendExec(OS, list[iter]);
		}
	}
	public static void Append(ViOStream OS, HashSet<T> list)
	{
		ViDebuger.AssertError(AppendExec != null);
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		foreach (T iter in list)
		{
			AppendExec(OS, iter);
		}
	}
	public static void Append<TKey>(ViOStream OS, Dictionary<TKey, T> list)
	{
		ViDebuger.AssertError(AppendExec != null);
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		foreach (KeyValuePair<TKey, T> iter in list)
		{
			ViSerializer<TKey>.Append(OS, iter.Key);
			AppendExec(OS, iter.Value);
		}
	}

	public static void Read(ViIStream IS, out T value)
	{
		ViDebuger.AssertError(ReadExec != null);
		ReadExec(IS, out value);
	}
	public static void Read(ViIStream IS, out List<T> list)
	{
		ViDebuger.AssertError(ReadExec != null);
		ViArrayIdx size;
		list = new List<T>();
		if (!IS.ReadPacked(out size))
		{
			ViDebuger.Warning("ViSerializer.Read Error");
			return;
		}
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViSerializer.Read.size Error");
			return;
		}
		list.Capacity = size;
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			T value;
			ReadExec(IS, out value);
			list.Add(value);
		}
	}
	public static void Read(ViIStream IS, out HashSet<T> list)
	{
		ViDebuger.AssertError(ReadExec != null);
		ViArrayIdx size;
		list = new HashSet<T>();
		if (!IS.ReadPacked(out size))
		{
			ViDebuger.Warning("ViSerializer.Read Error");
			return;
		}
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViSerializer.Read.size Error");
			return;
		}
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			T value;
			ReadExec(IS, out value);
			list.Add(value);
		}
	}
	public static void Read<TKey>(ViIStream IS, out Dictionary<TKey, T> list)
	{
		ViDebuger.AssertError(ReadExec != null);
		ViArrayIdx size;
		list = new Dictionary<TKey, T>();
		if (!IS.ReadPacked(out size))
		{
			ViDebuger.Warning("ViSerializer.Read Error");
			return;
		}
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViSerializer.Read.size Error");
			return;
		}
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TKey key;
			T value;
			ViSerializer<TKey>.Read(IS, out key);
			ReadExec(IS, out value);
			list.Add(key, value);
		}
	}

	public static bool Read(ViStringIStream IS, out T value)
	{
		ViDebuger.AssertError(ReadStringExec != null);
		return ReadStringExec(IS, out value);
	}
	public static bool Read(ViStringIStream IS, out List<T> list)
	{
		ViDebuger.AssertError(ReadStringExec != null);
		list = new List<T>();
		ViArrayIdx size;
		if (!IS.Read(out size))
		{
			ViDebuger.Warning("ViSerializer.Read Error");
			return false;
		}
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViSerializer.Read.size Error");
			return false;
		}
		list.Capacity = size;
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			T value;
			if (!ReadStringExec(IS, out value))
			{
				return false;
			}
			list.Add(value);
		}
		return true;
	}
	public static bool Read(ViStringIStream IS, out HashSet<T> list)
	{
		ViDebuger.AssertError(ReadExec != null);
		ViArrayIdx size;
		list = new HashSet<T>();
		if (!IS.Read(out size))
		{
			ViDebuger.Warning("ViSerializer.Read Error");
			return false;
		}
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViSerializer.Read.size Error");
			return false;
		}
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			T value;
			ReadStringExec(IS, out value);
			list.Add(value);
		}
		return true;
	}
	public static bool Read<TKey>(ViStringIStream IS, out Dictionary<TKey, T> list)
	{
		ViDebuger.AssertError(ReadExec != null);
		ViArrayIdx size;
		list = new Dictionary<TKey, T>();
		if (!IS.Read(out size))
		{
			ViDebuger.Warning("ViSerializer.Read Error");
			return false;
		}
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("ViSerializer.Read.size Error");
			return false;
		}
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TKey key;
			T value;
			ViSerializer<TKey>.Read(IS, out key);
			ReadStringExec(IS, out value);
			list.Add(key, value);
		}
		return true;
	}

	public static void Append(ViStringDictionaryStream OS, string head, T value)
	{
		ViDebuger.AssertError(AppendDictionaryStringExec != null);
		AppendDictionaryStringExec(OS, head, value);
	}
	public static void Append(ViStringDictionaryStream OS, string head, List<T> list)
	{
		OS.Add(head + ".Count", list.Count.ToString());
		//
		ViDebuger.AssertError(AppendDictionaryStringExec != null);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			AppendDictionaryStringExec(OS, head + "[" + iter + "]", list[iter]);
		}
	}
	public static void Append<TKey>(ViStringDictionaryStream OS, string head, Dictionary<TKey, T> list)
	{
		OS.Add(head + ".Count", list.Count.ToString());
		//
		ViDebuger.AssertError(AppendDictionaryStringExec != null);
		foreach (KeyValuePair<TKey, T> iter in list)
		{
			AppendDictionaryStringExec(OS, head + "[" + iter.Key + "]", iter.Value);
		}
	}
	public static void Append(ViStringDictionaryStream OS, string head, HashSet<T> list)
	{
		OS.Add(head + ".Count", list.Count.ToString());
		//
		ViDebuger.AssertError(AppendDictionaryStringExec != null);
		UInt32 idx = 0;
		foreach (T iter in list)
		{
			AppendDictionaryStringExec(OS, head + "[" + idx + "]", iter);
			++idx;
		}
	}
	public static void Read(ViStringDictionaryStream IS, string head, out T value)
	{
		ViDebuger.AssertError(ReadDictionaryStringExec != null);
		ReadDictionaryStringExec(IS, head, out value);
	}
	public static void Read(ViStringDictionaryStream OS, string head, out List<T> list)
	{
		list = new List<T>();
	}
	public static void Read<TKey>(ViStringDictionaryStream OS, string head, out Dictionary<TKey, T> list)
	{
		list = new Dictionary<TKey, T>();
	}
	public static void Read(ViStringDictionaryStream OS, string head, out HashSet<T> list)
	{
		list = new HashSet<T>();
	}
}

public static class ViSerializer
{
	public static void Start()
	{
		ViSerializer<Int8>.AppendExec = Int8Serializer.Append;
		ViSerializer<Int8>.ReadExec = Int8Serializer.Read;
		ViSerializer<Int8>.ReadStringExec = Int8Serializer.Read;
		ViSerializer<Int8>.AppendDictionaryStringExec = Int8Serializer.Append;
		ViSerializer<Int8>.ReadDictionaryStringExec = Int8Serializer.Read;
		ViSerializer<UInt8>.AppendExec = UInt8Serializer.Append;
		ViSerializer<UInt8>.ReadExec = UInt8Serializer.Read;
		ViSerializer<UInt8>.ReadStringExec = UInt8Serializer.Read;
		ViSerializer<UInt8>.AppendDictionaryStringExec = UInt8Serializer.Append;
		ViSerializer<UInt8>.ReadDictionaryStringExec = UInt8Serializer.Read;
		ViSerializer<Int16>.AppendExec = Int16Serializer.Append;
		ViSerializer<Int16>.ReadExec = Int16Serializer.Read;
		ViSerializer<Int16>.ReadStringExec = Int16Serializer.Read;
		ViSerializer<Int16>.AppendDictionaryStringExec = Int16Serializer.Append;
		ViSerializer<Int16>.ReadDictionaryStringExec = Int16Serializer.Read;
		ViSerializer<UInt16>.AppendExec = UInt16Serializer.Append;
		ViSerializer<UInt16>.ReadExec = UInt16Serializer.Read;
		ViSerializer<UInt16>.ReadStringExec = UInt16Serializer.Read;
		ViSerializer<UInt16>.AppendDictionaryStringExec = UInt16Serializer.Append;
		ViSerializer<UInt16>.ReadDictionaryStringExec = UInt16Serializer.Read;
		ViSerializer<Int32>.AppendExec = Int32Serializer.Append;
		ViSerializer<Int32>.ReadExec = Int32Serializer.Read;
		ViSerializer<Int32>.ReadStringExec = Int32Serializer.Read;
		ViSerializer<Int32>.AppendDictionaryStringExec = Int32Serializer.Append;
		ViSerializer<Int32>.ReadDictionaryStringExec = Int32Serializer.Read;
		ViSerializer<UInt32>.AppendExec = UInt32Serializer.Append;
		ViSerializer<UInt32>.ReadExec = UInt32Serializer.Read;
		ViSerializer<UInt32>.ReadStringExec = UInt32Serializer.Read;
		ViSerializer<UInt32>.AppendDictionaryStringExec = UInt32Serializer.Append;
		ViSerializer<UInt32>.ReadDictionaryStringExec = UInt32Serializer.Read;
		ViSerializer<Int64>.AppendExec = Int64Serializer.Append;
		ViSerializer<Int64>.ReadExec = Int64Serializer.Read;
		ViSerializer<Int64>.ReadStringExec = Int64Serializer.Read;
		ViSerializer<Int64>.AppendDictionaryStringExec = Int64Serializer.Append;
		ViSerializer<Int64>.ReadDictionaryStringExec = Int64Serializer.Read;
		ViSerializer<UInt64>.AppendExec = UInt64Serializer.Append;
		ViSerializer<UInt64>.ReadExec = UInt64Serializer.Read;
		ViSerializer<UInt64>.ReadStringExec = UInt64Serializer.Read;
		ViSerializer<UInt64>.AppendDictionaryStringExec = UInt64Serializer.Append;
		ViSerializer<UInt64>.ReadDictionaryStringExec = UInt64Serializer.Read;
		ViSerializer<float>.AppendExec = FloatSerializer.Append;
		ViSerializer<float>.ReadExec = FloatSerializer.Read;
		ViSerializer<float>.ReadStringExec = FloatSerializer.Read;
		ViSerializer<float>.AppendDictionaryStringExec = FloatSerializer.Append;
		ViSerializer<float>.ReadDictionaryStringExec = FloatSerializer.Read;
		ViSerializer<double>.AppendExec = DoubleSerializer.Append;
		ViSerializer<double>.ReadExec = DoubleSerializer.Read;
		ViSerializer<double>.ReadStringExec = DoubleSerializer.Read;
		ViSerializer<double>.AppendDictionaryStringExec = DoubleSerializer.Append;
		ViSerializer<double>.ReadDictionaryStringExec = DoubleSerializer.Read;
		ViSerializer<string>.AppendExec = StringSerializer.Append;
		ViSerializer<string>.ReadExec = StringSerializer.Read;
		ViSerializer<string>.ReadStringExec = StringSerializer.Read;
		ViSerializer<string>.AppendDictionaryStringExec = StringSerializer.Append;
		ViSerializer<string>.ReadDictionaryStringExec = StringSerializer.Read;
	}
}

public static class ViStringSerializer<T>
{
	public delegate void DelePrintTo(T value, ref string OS);
	public static DelePrintTo PrintToExec;
	public delegate void DelePrintToBuilder(T value, ViStringBuilder OS);
	public static DelePrintToBuilder PrintToBuilderExec;
	public delegate void DeleRead(string IS, out T value);
	public static DeleRead ReadExec;

	public static void PrintTo(T value, ref string OS)
	{
		ViDebuger.AssertError(PrintToExec != null);
		PrintToExec(value, ref OS);
	}

	public static void PrintTo(T value, ViStringBuilder OS)
	{
		ViDebuger.AssertError(PrintToBuilderExec != null);
		PrintToBuilderExec(value, OS);
	}

	public static void Read(string IS, out T value)
	{
		ViDebuger.AssertError(ReadExec != null);
		try
		{
			ReadExec(IS, out value);
		}
		catch (System.Exception ex)
		{
			value = default(T);
		}
	}

	public static T Get(string IS)
	{
		ViDebuger.AssertError(ReadExec != null);
		try
		{
			T value;
			ReadExec(IS, out value);
			return value;
		}
		catch (System.Exception ex)
		{
			return default(T);
		}
	}
}

public static class ViStringSerialize
{
	public static void Read(string strValue, out bool value)
	{
		value = Convert.ToBoolean(strValue);
	}
	public static void Read(string strValue, out Int8 value)
	{
		value = Convert.ToSByte(strValue);
	}
	public static void Read(string strValue, out UInt8 value)
	{
		value = Convert.ToByte(strValue);
	}
	public static void Read(string strValue, out Int16 value)
	{
		value = Convert.ToInt16(strValue);
	}
	public static void Read(string strValue, out UInt16 value)
	{
		value = Convert.ToUInt16(strValue);
	}
	public static void Read(string strValue, out Int32 value)
	{
		value = Convert.ToInt32(strValue);
	}
	public static void Read(string strValue, out UInt32 value)
	{
		value = Convert.ToUInt32(strValue);
	}
	public static void Read(string strValue, out Int64 value)
	{
		value = Convert.ToInt64(strValue);
	}
	public static void Read(string strValue, out UInt64 value)
	{
		value = Convert.ToUInt64(strValue);
	}
	public static void Read(string strValue, out float value)
	{
		value = Convert.ToSingle(strValue);
	}
	public static void Read(string strValue, out double value)
	{
		value = Convert.ToDouble(strValue);
	}
	public static void Read(string strValue, out string value)
	{
		value = strValue;
	}
	public static void PrintTo(Int8 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<Int8> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int8 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(UInt8 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<UInt8> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt8 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(Int16 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<Int16> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int16 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(UInt16 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<UInt16> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt16 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(Int32 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<Int32> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int32 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(UInt32 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<UInt32> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt32 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(Int64 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<Int64> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int64 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(UInt64 value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<UInt64> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt64 value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(float value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<float> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			float value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(double value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<double> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			double value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}
	public static void PrintTo(string value, ref string strValue)
	{
		strValue += value;
	}
	public static void PrintTo(List<string> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			string value = list[iter];
			strValue += value;
			strValue += ",";
		}
		strValue += ")";
	}

	public static void PrintTo(Int8 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<Int8> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int8 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(UInt8 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<UInt8> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt8 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(Int16 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<Int16> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int16 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(UInt16 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<UInt16> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt16 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(Int32 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<Int32> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int32 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(UInt32 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<UInt32> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt32 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(Int64 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<Int64> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int64 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(UInt64 value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<UInt64> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt64 value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(float value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<float> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			float value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(double value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<double> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			double value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}
	public static void PrintTo(string value, ViStringBuilder strValue)
	{
		strValue.Add(value);
	}
	public static void PrintTo(List<string> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			string value = list[iter];
			strValue.Add(value);
			strValue.Add(",");
		}
		strValue.Add(")");
	}

	public static void Start()
	{
		ViStringSerializer<Int8>.PrintToExec = PrintTo;
		ViStringSerializer<Int8>.ReadExec = Read;
		ViStringSerializer<UInt8>.PrintToExec = PrintTo;
		ViStringSerializer<UInt8>.ReadExec = Read;
		ViStringSerializer<Int16>.PrintToExec = PrintTo;
		ViStringSerializer<Int16>.ReadExec = Read;
		ViStringSerializer<UInt16>.PrintToExec = PrintTo;
		ViStringSerializer<UInt16>.ReadExec = Read;
		ViStringSerializer<Int32>.PrintToExec = PrintTo;
		ViStringSerializer<Int32>.ReadExec = Read;
		ViStringSerializer<UInt32>.PrintToExec = PrintTo;
		ViStringSerializer<UInt32>.ReadExec = Read;
		ViStringSerializer<Int64>.PrintToExec = PrintTo;
		ViStringSerializer<Int64>.ReadExec = Read;
		ViStringSerializer<UInt64>.PrintToExec = PrintTo;
		ViStringSerializer<UInt64>.ReadExec = Read;
		ViStringSerializer<float>.PrintToExec = PrintTo;
		ViStringSerializer<float>.ReadExec = Read;
		ViStringSerializer<double>.PrintToExec = PrintTo;
		ViStringSerializer<double>.ReadExec = Read;
		ViStringSerializer<string>.PrintToExec = PrintTo;
		ViStringSerializer<string>.ReadExec = Read;
	}
}
