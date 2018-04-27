using System;
using System.Text;
using System.Collections.Generic;

using ViArrayIdx = System.Int32;
using Int8 = System.SByte;

#pragma warning disable 0168 //声明了变量,但从未使用过;

public struct FormatTime
{
	public string Print()
	{
		return Print(Value, 2);
	}
	static void Print(ViStringBuilder str, Int32 value, string desc, ref Int32 count, ref bool started)
	{
		if (count > 0 && value > 0)
		{
			str.Add(value);
			str.Add(desc);
			started = true;
		}
		if (started)
		{
			--count;
		}
	}

	public static string Print(Int64 time, Int32 tagCount)
	{
		return Print(time, tagCount, false);
	}

	public static string Print(Int64 time, Int32 tagCount, bool isAccurate)
	{
		_printBuilder.Clear();
		Print(time, tagCount, isAccurate, _printBuilder);
		return _printBuilder.Value;
	}

	public static void Print(Int64 time, Int32 tagCount, bool isAccurate, ViStringBuilder str)
	{
		Int32 day;
		Int32 hour;
		Int32 minute;
		Int32 second;
		ViTickCount.GetTime(time, out day, out hour, out minute, out second);
		bool started = false;
		Print(str, day, VisualKeyString.Day, ref tagCount, ref started);
		Print(str, hour, VisualKeyString.Hour, ref tagCount, ref started);
		Print(str, minute, VisualKeyString.Minute, ref tagCount, ref started);
		Print(str, second, VisualKeyString.Second, ref tagCount, ref started);
		if (isAccurate)
		{
			if (tagCount > 0 && second == 0)
			{
				str.Add('.');
				str.Add(time % ViTickCount.SECOND / 10);
				str.Add(VisualKeyString.Second);
				--tagCount;
			}
		}
	}

	public static string SimplePrintZeroTime(Int32 tagCount)
	{
		switch (tagCount)
		{
			case 1:
				return "00";
			case 2:
				return "00:00";
			case 3:
				return "00:00:00";
			case 4:
				return "00:00:00:00";
			default:
				return "00:00:00:00";
		}
	}

	public static string SimplePrint(Int64 time, Int32 tagCount)
	{
		if (time <= 0)
		{
			return SimplePrintZeroTime(tagCount);
		}
		_printBuilder.Clear();
		SimplePrint(time, tagCount, _printBuilder);
		return _printBuilder.Value;
	}
	public static void SimplePrint(Int64 time, Int32 tagCount, ViStringBuilder str)
	{
		if (time <= 0)
		{
			str.Add(SimplePrintZeroTime(tagCount));
			return;
		}
		//
		Int32 day;
		Int32 hour;
		Int32 minute;
		Int32 second;
		ViTickCount.GetTime(time, out day, out hour, out minute, out second);
		switch (tagCount)
		{
			case 1:
				str.Add((day * 24 * 60 * 60 + hour * 60 * 60 + minute * 60 + second).ToString("00"));
				break;
			case 2:
				str.Add((day * 24 * 60 + hour * 60 + minute).ToString("00")).Add(":").Add(second.ToString("00"));
				break;
			case 3:
				str.Add((day * 24 + hour).ToString("00")).Add(":").Add(minute.ToString("00")).Add(":").Add(second.ToString("00"));
				break;
			case 4:
				str.Add(day.ToString("00")).Add(":").Add(hour.ToString("00")).Add(":").Add(minute.ToString("00")).Add(":").Add(second.ToString("00"));
				break;
			default:
				str.Add(day.ToString("00")).Add(":").Add(hour.ToString("00")).Add(":").Add(minute.ToString("00")).Add(":").Add(second.ToString("00"));
				break;
		}
	}

	/// <summary>
	///  Output : 月 日 时 分
	/// </summary>
	public static string Print(System.DateTime time)
	{
		return time.Month.ToString() + VisualKeyString.Month
			+ time.Day.ToString() + VisualKeyString.Day2
			+ time.Hour.ToString() + VisualKeyString.Hour2
			+ time.Minute.ToString() + VisualKeyString.Minute;
	}

	public static string Print(System.DateTime time, Int32 tagStart, Int32 tagCount)
	{
		_printBuilder.Clear();
		Print(time, tagStart, tagCount, _printBuilder);
		return _printBuilder.Value;
	}

	public static void Print(System.DateTime time, Int32 tagStart, Int32 tagCount, ViStringBuilder str)
	{
		if (tagStart <= 0 && tagCount > 0)
		{
			str.Add(time.Year);
			str.Add(VisualKeyString.Year);
			--tagCount;
		}
		if (tagStart <= 1 && tagCount > 0)
		{
			str.Add(time.Month);
			str.Add(VisualKeyString.Month);
			--tagCount;
		}
		if (tagStart <= 2 && tagCount > 0)
		{
			str.Add(time.Day);
			str.Add(VisualKeyString.Day2);
			--tagCount;
		}
		if (tagStart <= 3 && tagCount > 0)
		{
			str.Add(time.Hour);
			str.Add(VisualKeyString.Hour2);
			--tagCount;
		}
		if (tagStart <= 4 && tagCount > 0)
		{
			str.Add(time.Minute);
			str.Add(VisualKeyString.Minute);
			--tagCount;
		}
		if (tagStart <= 5 && tagCount > 0)
		{
			str.Add(time.Second);
			str.Add(VisualKeyString.Second);
			--tagCount;
		}
	}

	/// <summary>
	/// Output : yyyy-mm-dd hh:mm:ss
	/// </summary>
	public static string SimplePrint(System.DateTime time, Int32 tagStart, Int32 tagCount)
	{
		_printBuilder.Clear();
		SimplePrint(time, tagStart, tagCount, _printBuilder);
		return _printBuilder.Value;
	}
	public static void SimplePrint(System.DateTime time, Int32 tagStart, Int32 tagCount, ViStringBuilder str)
	{
		if (tagStart <= 0 && tagCount > 0)
		{
			str.Add(time.Year);
			--tagCount;
		}
		if (tagStart <= 1 && tagCount > 0)
		{
			if (tagStart < 1)
			{
				str.Add("-");
			}
			str.Add(time.Month.ToString("00"));
			--tagCount;
		}
		if (tagStart <= 2 && tagCount > 0)
		{
			if (tagStart < 2)
			{
				str.Add("-");
			}
			str.Add(time.Day.ToString("00"));
			--tagCount;
		}
		if (tagStart <= 3 && tagCount > 0)
		{
			if (tagStart < 3)
			{
				str.Add(" ");
			}
			str.Add(time.Hour.ToString("00"));
			--tagCount;
		}
		if (tagStart <= 4 && tagCount > 0)
		{
			if (tagStart < 4)
			{
				str.Add(":");
			}
			str.Add(time.Minute.ToString("00"));
			--tagCount;
		}
		if (tagStart <= 5 && tagCount > 0)
		{
			if (tagStart < 5)
			{
				str.Add(":");
			}
			str.Add(time.Second.ToString("00"));
			--tagCount;
		}
	}

	public Int64 Value;
	static ViStringBuilder _printBuilder = new ViStringBuilder();
}

public struct MoneyStruct
{
	public ViEnum32<MoneyType> Type;
	public Int64 Value;
}

public class GameStaticsPointStruct : ViSealedData
{
	public string Icon;
	public string Description;
	public ViForeignKey<ColorStruct> Color;
	public ViForeignKey<GameFuncStruct> Func;
}

public class CoolingDownStruct : ViSealedData
{
	public Int32 Duration;
	public Int32 AccumulateCount;
	public ViEnum32<ViAccumulateTimeType> Type;
	public ViEnum32<ViDateLoopType> DateClear;
}

public class ScriptDurationStruct : ViSealedData
{
	public ViEnum32<ViAccumulateTimeType> Accumulate;
	public ViDurationStruct Duration;
	public ViEnum32<ViDateLoopType> DateClear;
	public ViStaticArray<ViForeignKeyStruct<ViAuraStruct>> Aura = new ViStaticArray<ViForeignKeyStruct<ViAuraStruct>>(3);
}

public class ViewAssisstant
{
	public static void ReadSimple(ViIStream IS, out ViVector3 pos)
	{
		Int16 iX;
		Int16 iY;
		IS.Read(out iX);
		pos = ViVector3.ZERO;
		pos.x = iX * 0.1f;
		IS.Read(out iY);
		pos.y = iY * 0.1f;
	}
	public static void ReadSimple(ViIStream IS, out List<ViVector3> posList)
	{
		ViArrayIdx size;
		IS.ReadPacked(out size);
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("Read List<ViVector3>.size Error");
			posList = new List<ViVector3>();
			return;
		}
		posList = new List<ViVector3>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			ViVector3 value;
			ReadSimple(IS, out value);
			posList.Add(value);
		}
	}
}

public struct SpaceObjectInViewData
{
	public ViVector3 Pos;
	public float Yaw;
	public List<ViVector3> Route;

	public void Load(ViIStream IS)
	{
		ViVector3 pos;
		Int8 iYaw;
		List<ViVector3> route;
		ViewAssisstant.ReadSimple(IS, out Pos);
		IS.Read(out iYaw);
		Yaw = iYaw * 0.025f;
		ViewAssisstant.ReadSimple(IS, out Route);
	}
}
