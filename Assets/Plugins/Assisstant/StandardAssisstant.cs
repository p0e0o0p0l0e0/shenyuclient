using System;
using System.Collections.Generic;


public static class StandardAssisstant
{
	public static Int32 CountUp(Int32 value, List<Int32> list)
	{
		Int32 count = 0;
		for (Int32 idx = 0; idx < list.Count; ++idx)
		{
			if (value >= list[idx])
			{
				++count;
			}
		}
		return count;
	}

	public static Int32 CountUp(UInt32 value, List<UInt32> list)
	{
		Int32 count = 0;
		for (Int32 idx = 0; idx < list.Count; ++idx)
		{
			if (value >= list[idx])
			{
				++count;
			}
		}
		return count;
	}

	public static TValue Value<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue DEFAULT_VALUE)
	{
		TValue value;
		if (dict.TryGetValue(key, out value))
		{
			return value;
		}
		return DEFAULT_VALUE;
	}

	public static string Combine(List<string> list, string front, string back, string split, int startIdx, int endIdx)
	{
		string result = string.Empty;
		endIdx = ViMathDefine.Min(endIdx, list.Count);
		for (int iter = startIdx; iter < endIdx; ++iter)
		{
			if (iter != startIdx)
			{
				result += split;
			}
			result += front + list[iter] + back;
		}
		return result;
	}

	public static string Combine(List<string> list, string front, string back, string split)
	{
		return Combine(list, front, back, split, 0, list.Count);
	}

	public static TDerive DynamicCast<TDerive>(object obj)
		where TDerive : class
	{
		if (obj == null)
		{
			return null;
		}
		return obj as TDerive;
	}

	public static TDerive DynamicCast<TDerive, TBase>(TBase obj)
		where TBase : class
		where TDerive : class
	{
		if (obj == null)
		{
			return null;
		}
		return obj as TDerive;
	}

	public static void AddValue<T>(List<T> list, int size, T value)
	{
		list.Capacity = list.Capacity + size;
		for (int iter = 0; iter < size; ++iter)
		{
			list.Add(value);
		}
	}

	public static void SetValue<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key, TValue value, bool insert)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] = value;
		}
		else if (insert)
		{
			dict.Add(key, value);
		}
	}

	public static bool EqualsIgnoreCase(string left, string right)
	{
		return string.Equals(left, right, StringComparison.CurrentCultureIgnoreCase);
	}

	public static string GetStrValue(string str, string key)
	{
		int startIdx = str.IndexOf(key);
		if (startIdx == -1)
		{
			return string.Empty;
		}
		startIdx += key.Length;
		int endIdx = str.IndexOf('&', startIdx);
		if (endIdx == -1)
		{
			endIdx = str.Length;
		}
		return str.Substring(startIdx, endIdx - startIdx);
	}

	public static void LoopListCopyTo<T>(List<T> fromList, UInt32 start, UInt32 count, List<T> toList)
	{
		Int32 size = fromList.Count;
		Int32 end = (Int32)(start + count);
		Int32 end0 = ViMathDefine.Min(end, size);
		for (Int32 iter = (Int32)start; iter < end0; ++iter)
		{
			toList.Add(fromList[iter]);
		}
		//
		if (end > size)
		{
			Int32 end1 = end - size;
			for (Int32 iter = 0; iter < end1; ++iter)
			{
				toList.Add(fromList[iter]);
			}
		}
	}

}
