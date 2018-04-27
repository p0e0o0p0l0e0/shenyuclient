
using System;
using System.Collections.Generic;

public static class ViRandom
{
	public static UInt32 Seed { set { _seed = value; } }

	public static bool Value(float prob)
	{
		MutateSeed();
		if (prob <= 0.0f)
		{
			return false;
		}
		if (prob >= 1.0f)
		{
			return true;
		}
		UInt32 range = (UInt32)(0XFFFFFFFF * prob);
		return range > _seed;
	}

	public static Int32 Probability(List<Int32> rangeList)
	{
		Int32 sup = 0;
		foreach (Int32 range in rangeList)
		{
			sup += range;
		}
		Int32 value = Value(0, sup);
		Int32 idx = 0;
		foreach (Int32 range in rangeList)
		{
			value -= range;
			if (value < 0)
			{
				return idx;
			}
			++idx;
		}
		return 0;
	}
	static bool Probability(List<UInt32> rangeList, out UInt32 idx)
	{
		Int32 sup = 0;
		foreach (Int32 range in rangeList)
		{
			sup += range;
		}
		idx = 0;
		Int32 value = Value(0, sup);
		foreach (Int32 range in rangeList)
		{
			value -= range;
			if (value < 0)
			{
				return true;
			}
			++idx;
		}
		return false;
	}
	public static void GetValues(UInt32 range, UInt32 count, List<UInt32> values)// 取值范围[0, range)
	{
		if (range <= 0)
		{
			return;
		}
		if (count <= 0)
		{
			return;
		}
		List<UInt32> probablityList = new List<UInt32>();
		for (int iter = 0; iter < range; ++iter)
		{
			probablityList.Add(1);
		}
		//
		SelectList(probablityList, count, values);
		while (values.Count < count)
		{
			values.Add((UInt32)Value(0, (Int32)range));
		}
	}

	public static Int32 Value(Int32 min, Int32 max)// 取值范围[min, max)
	{
		MutateSeed();
		if (min >= max)
		{
			return min;
		}
		UInt32 span = (UInt32)(max - min);
		Int32 value = (Int32)(_seed % span) + min;
		return value;
	}

	static List<UInt32> CACHE_Probability = new List<UInt32>();
	public static void SelectList(List<UInt32> rangeList, UInt32 count, List<UInt32> idxList)
	{
		CACHE_Probability.Clear();
		CACHE_Probability.AddRange(rangeList);
		//
		UInt32 reserveCount = Math.Min(count, (UInt32)CACHE_Probability.Count);
		while (reserveCount > 0)
		{
			UInt32 iterIdx = 0;
			if (Probability(CACHE_Probability, out iterIdx))
			{
				CACHE_Probability[(int)iterIdx] = 0;
				idxList.Add(iterIdx);
			}
			else
			{
				break;
			}
			--reserveCount;
		}
	}

	public static void SelectList<T>(List<KeyValuePair<T, UInt32>> rangeList, UInt32 count, List<T> selected)
	{
		CACHE_Probability.Clear();
		for (int iter = 0; iter < rangeList.Count; ++iter)
		{
			CACHE_Probability.Add(rangeList[iter].Value);
		}
		//
		UInt32 reserveCount = Math.Min(count, (UInt32)CACHE_Probability.Count);
		while (reserveCount > 0)
		{
			UInt32 iterIdx = 0;
			if (Probability(CACHE_Probability, out iterIdx))
			{
				CACHE_Probability[(int)iterIdx] = 0;
				selected.Add(rangeList[(int)iterIdx].Key);
			}
			else
			{
				break;
			}
			--reserveCount;
		}
	}

	public static void Randomize<T>(List<T> list)
	{
		List<T> copyList = new List<T>();
		copyList.AddRange(list);
		list.Clear();
		//
		List<UInt32> idxList = new List<UInt32>();
		GetValues((UInt32)copyList.Count, (UInt32)copyList.Count, idxList);
		//
		for (int iter = 0; iter < idxList.Count; ++iter)
		{
			list.Add(copyList[(int)idxList[iter]]);
		}
	}

	static void MutateSeed()
	{
		_seed = (_seed * 196314165) + 907633515;
	}

	static UInt32 _seed = 0;
}

public static class Demo_Random
{
	public static void Test()
	{
		int range = 10000;
		int[] counts = new int[range];
		for (int idx = 0; idx < range * 10; ++idx)
		{
			Int32 randomValue = ViRandom.Value(0, range);
			++counts[randomValue];
		}
		for (int idx = 0; idx < range; ++idx)
		{
			//ViDebuger.Note("" + idx + ">>" + counts[idx]);
		}
	}
}