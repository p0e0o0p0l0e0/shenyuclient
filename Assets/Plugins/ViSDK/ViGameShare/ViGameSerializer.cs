
using System;
using System.Collections.Generic;
using ViArrayIdx = System.Int32;
using UInt8 = System.Byte;

public class ViGameSerializer<T> : ViSerializer<T>
{
	public static void Append(ViOStream OS, ViNormalDataPtr<T> ptr)
	{
		ptr.Print(OS);
	}
	public static void Append(ViOStream OS, List<ViNormalDataPtr<T>> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Append(OS, list[iter]);
		}
	}
	public static void Append(ViOStream OS, HashSet<ViNormalDataPtr<T>> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		foreach (ViNormalDataPtr<T> iter in list)
		{
			Append(OS, iter);
		}
	}
	public static void Append<TKey>(ViOStream OS, Dictionary<TKey, ViNormalDataPtr<T>> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		foreach (KeyValuePair<TKey, ViNormalDataPtr<T>> iter in list)
		{
			ViSerializer<TKey>.Append(OS, iter.Key);
			Append(OS, iter.Value);
		}
	}

	public static void Read(ViIStream IS, out ViNormalDataPtr<T> ptr)
	{
		ViDebuger.AssertError(ReadExec != null);
		ptr = new ViNormalDataPtr<T>();
		ptr.Load(IS);
	}

	public static void Read(ViIStream IS, out List<ViNormalDataPtr<T>> list)
	{
		ViArrayIdx size;
		list = new List<ViNormalDataPtr<T>>();
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
			ViNormalDataPtr<T> value;
			Read(IS, out value);
			list.Add(value);
		}
	}
	public static void Read(ViIStream IS, out HashSet<ViNormalDataPtr<T>> list)
	{
		ViArrayIdx size;
		list = new HashSet<ViNormalDataPtr<T>>();
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
			ViNormalDataPtr<T> value;
			Read(IS, out value);
			list.Add(value);
		}
	}
	public static void Read<TKey>(ViIStream IS, out Dictionary<TKey, ViNormalDataPtr<T>> list)
	{
		ViDebuger.AssertError(ReadExec != null);
		ViArrayIdx size;
		list = new Dictionary<TKey, ViNormalDataPtr<T>>();
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
			ViNormalDataPtr<T> value;
			ViSerializer<TKey>.Read(IS, out key);
			Read(IS, out value);
			list.Add(key, value);
		}
	}

	public static bool Read(ViStringIStream IS, out ViNormalDataPtr<T> value)
	{
		value = new ViNormalDataPtr<T>();
		return true;
	}
	
	public static void Append(ViStringDictionaryStream OS, string head, ViNormalDataPtr<T> ptr)
	{
		ptr.Print(head, OS);
	}

	public static void Read(ViStringDictionaryStream IS, string head, out ViNormalDataPtr<T> ptr)
	{
		ptr = new ViNormalDataPtr<T>();
		ptr.Load(head, IS);
	}
}