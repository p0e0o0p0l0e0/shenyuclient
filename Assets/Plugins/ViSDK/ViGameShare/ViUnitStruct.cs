using System;

using ViTime64 = System.Int64;

public struct PathFileStruct
{
	public PathFileStruct(string path, string file)
	{
		Path = path;
		File = file;
	}
	public static bool operator ==(PathFileStruct left, PathFileStruct right)
	{
		return string.Equals(left.Path, right.Path, StringComparison.CurrentCultureIgnoreCase) && string.Equals(left.File, right.File, StringComparison.CurrentCultureIgnoreCase);
	}
	public static bool operator !=(PathFileStruct left, PathFileStruct right)
	{
		return !string.Equals(left.Path, right.Path, StringComparison.CurrentCultureIgnoreCase) || !string.Equals(left.File, right.File, StringComparison.CurrentCultureIgnoreCase);
	}
	public static bool Equals(PathFileStruct left, PathFileStruct right)
	{
		return string.Equals(left.Path, right.Path, StringComparison.CurrentCultureIgnoreCase) && string.Equals(left.File, right.File, StringComparison.CurrentCultureIgnoreCase);
	}
	public override int GetHashCode()
	{
		return Path.GetHashCode() + File.GetHashCode();
	}
	public override bool Equals(object other)
	{
		if (!(other is ViReceiveDataInt8))
		{
			return false;
		}
		PathFileStruct data = (PathFileStruct)other;
		return string.Equals(this.Path, data.Path, StringComparison.CurrentCultureIgnoreCase) && string.Equals(this.File, data.File, StringComparison.CurrentCultureIgnoreCase);
	}
	public bool IsEmpty() { return string.IsNullOrEmpty(File); }
	public string Path;
	public string File;
}

public class PathFileResStruct : ViSealedData
{
	public enum Mask
	{
		LOW = 0X01,
		MIDDLE = 0X02,
	}

	public struct StringStruct
	{
		public StringStruct(string value) { Value = value; }
		public string Value;
	}

	static string Alias(int level, string path)
	{
		switch (level)
		{
			case 0:
				return path + "lod_low/";
			case 1:
				return path + "lod_middle/";
			default:
				return path;
		}
	}

	public override void Format()
	{
		string localPath = File.Path.ToLower();
		string localName = File.File.ToLower();

		AssetBundleSectionName = localName;
		string pathFile = localPath;
		for (int iter = 0; iter < AssetBundleName.Length; ++iter)
		{
			if (LODMask.HasAny(ViMask32.Mask(iter)))
			{
				AssetBundleName[iter] = new StringStruct(Alias(iter, localPath) + localName);
			}
			else
			{
				AssetBundleName[iter] = new StringStruct(pathFile);
			}
		}
	}

	public void GetLODAlias(Int32 level, out string name, out string section)
	{
		section = AssetBundleSectionName;
		if (level < AssetBundleName.Length)
		{
			name = AssetBundleName[level].Value;
		}
		else
		{
			name = AssetBundleName[AssetBundleName.Length - 1].Value;
		}
	}
	//
	public PathFileStruct File;
	public ViMask32<Mask> LODMask;
	public ViStaticArray<StringStruct> AssetBundleName = new ViStaticArray<StringStruct>(3);
	public string AssetBundleSectionName;
}

public struct ViUnitValue
{
	public bool IsEmpty() { return (type == 0); }
	public Int32 type;
	public Int32 value;
}

public struct ViValueRange
{
	public Int32 Value { get { return ViRandom.Value(Inf, Sup + 1); } }
	public bool IsIn(Int32 value) { return (Inf <= value && value <= Sup); }
	public bool IsInIgnoreZero(Int32 value)
	{
		if (Inf != 0 && value < Inf)
		{
			return false;
		}
		if (Sup != 0 && value > Sup)
		{
			return false;
		}
		return true;
	}
	public Int32 Inf;
	public Int32 Sup;

	public string Print()
	{
		if (Inf == Sup)
		{
			return Sup.ToString();
		}
		return Inf.ToString() + "~" + Sup.ToString();
	}
}

public struct ViUnitValueRange
{
	public bool IsEmpty() { return (type == 0); }
	public Int32 type;
	public ViValueRange value;
}

public struct ViUnitRefValue
{
	public bool IsEmpty() { return (type == 0 || scale10000 == 0); }
	public float Scale() { return scale10000 * 0.0001f; }
	public Int32 type;
	public Int32 scale10000;
}

public class ViStateConditionStruct : ViSealedData
{
	public bool IsEmpty() { return (reqAuraState | notAuraState | reqActionState | notActionState | reqSpaceState | notSpaceState) == 0; }

	public Int32 reqAuraState;
	public Int32 notAuraState;
	public Int32 reqActionState;
	public Int32 notActionState;
	public Int32 reqSpaceState;
	public Int32 notSpaceState;
}

public struct ViDurationStruct
{
	public ViTime64 Value { get { return ViTickCount.DAY * Day + ViTickCount.HOUR * Hour + ViTickCount.MINUTE * Minute + ViTickCount.SECOND * Second; } }
	public Int32 Day;
	public Int32 Hour;
	public Int32 Minute;
	public Int32 Second;
	public Int64 _Value;
}

public struct ViActiveDuration
{
	public Int64 StartTimeValue
	{
		get { return StartYearMonthValue + StartTime.Value; }
	}

	public static bool IsActive(Int64 iTime, Int64 iStartTime, Int64 iDuration)
	{
		if (iDuration == 0)
		{
			return iStartTime < iTime;
		}
		else
		{
			return iStartTime < iTime && iTime < (iStartTime + iDuration);
		}
	}

	public bool IsEmtpy()
	{
		return Duration.Value == 0;
	}

	public ViEnum32<ViStartTimeType> Start;
	public Int32 StartYear;
	public Int32 StartMonth;
	public Int64 StartYearMonthValue;
	public ViDurationStruct StartTime;
	public ViEnum32<ViAccumulateTimeType> Accumulate;
	public ViDurationStruct Duration;
}

public class ViDateTimeStruct : ViSealedData
{
	public ViTime64 GetTime()
	{
		return ViTickCount.GetCount(Day, Hour, Minute, Second);
	}
	public Int32 Day;
	public Int32 Hour;
	public Int32 Minute;
	public Int32 Second;
}

public class ViDateTimeExStruct : ViSealedData
{
	public DateTime Date()
	{
		return new DateTime(Year, Month, Day, Hour, Minute, 0);
	}
	public Int32 Year;
	public Int32 Month;
	public Int32 Day;
	public Int32 Hour;
	public Int32 Minute;
}

public class ViDistributionStruct : ViSealedData
{
	public ViStaticArray<Int32> Probability = new ViStaticArray<Int32>(10);
}

public struct ViValueMappingNodeStruct
{
	public Int32 ValueX;
	public Int32 ValueY;
}

public class ViValueMappingStruct : ViSealedData
{
	public float Get(float x)
	{
		float scaleX = ViMathDefine.Pow(10, ScalePowerX);
		float scaleY = ViMathDefine.Pow(10, ScalePowerY);
		Int32 iX = ViMathDefine.IntNear(x / scaleX);
		ViValueMappingNodeStruct fronNode = Value[0];
		Int32 xInf = fronNode.ValueX;
		Int32 yInf = fronNode.ValueY;
		if (iX <= xInf)
		{
			return yInf * scaleY;
		}
		for (Int32 iter = 1; iter < Count; ++iter)
		{
			ViValueMappingNodeStruct iterNode = Value[iter];
			if (iX > iterNode.ValueX)
			{
				xInf = iterNode.ValueX;
				yInf = iterNode.ValueY;
			}
			else
			{
				if (Type == (Int32)ViValueMappingType.LINE)
				{
					double iterXSpan = (double)(iterNode.ValueX - xInf);
					double iterYSpan = (double)(iterNode.ValueY - yInf);
					double iterProgress = ((double)(x / scaleX - xInf)) / iterXSpan;
					return (float)(yInf + iterYSpan * iterProgress) * scaleY;
				}
				else
				{
					return yInf * scaleY;
				}
			}
		}
		return yInf * scaleY;
	}
	//
	public ViEnum32<ViValueMappingType> Type;
	public Int32 ScalePowerX;
	public Int32 ScalePowerY;
	public Int32 Count;
	public ViStaticArray<ViValueMappingNodeStruct> Value = new ViStaticArray<ViValueMappingNodeStruct>(20);
}

public class ViAttackForceStruct : ViSealedData
{
	public Int32 PowerH;
	public Int32 PowerV;
	public Int32 Height;
	public string Color;
	public Int32 ExploreScale;
}

public enum ViAreaType
{
	ROUND,//! 圆形
	RECT,//! 矩形
	SECTOR,//! 扇形
}

public struct ViAreaStruct
{
	public ViEnum32<ViAreaType> type;								// 范围类型
	public Int32 minRange;						// 最小距离(圆)最小半径:米(矩形)横:米(扇形)弧度
	public Int32 maxRange;						// 最大距离(圆)最大半径:米(矩形)竖:米(扇形)半径
}

public class ViAreaGroup
{
	public static ViArea Create(ViVector3 pos, float yaw, ViAreaStruct info)
	{
		return Create(pos, yaw, 0.0f, info);
	}
	public static ViArea Create(ViVector3 pos, float yaw, float bodyRadius, ViAreaStruct info)
	{
		switch ((ViAreaType)info.type.Value)
		{
			case ViAreaType.RECT:
				{
					ViRotRectArea area = new ViRotRectArea();
					area.Init(info.maxRange * 0.01f + bodyRadius, info.minRange * 0.005f + bodyRadius);
					area.Center = pos;
					area.SetDir(yaw);
					return area;
				}
			case ViAreaType.SECTOR:
				{
					ViSectorArea area = new ViSectorArea();
					area.Init(info.maxRange * 0.01f + bodyRadius, -info.minRange * 0.01f, info.minRange * 0.01f);
					area.Center = pos;
					area.SetDir(yaw);
					return area;
				}
			default:
				{
					ViRoundArea area = new ViRoundArea();
					area.Init(info.maxRange * 0.01f + bodyRadius);
					area.Center = pos;
					return area;
				}
		}
	}
	public ViArea Value(ViVector3 pos, float yaw, ViAreaStruct info)
	{
		return Value(pos, yaw, 0.0f, info);
	}
	public ViArea Value(ViVector3 pos, float yaw, float bodyRadius, ViAreaStruct info)
	{
		switch ((ViAreaType)info.type.Value)
		{
			case ViAreaType.RECT:
				{
					ViRotRectArea area = rotRect;
					area.Init(info.maxRange * 0.01f + bodyRadius, info.minRange * 0.005f + bodyRadius);
					area.Center = pos;
					area.SetDir(yaw);
					return area;
				}
			case ViAreaType.SECTOR:
				{
					ViSectorArea area = sector;
					area.Init(info.maxRange * 0.01f + bodyRadius, -info.minRange * 0.01f, info.minRange * 0.01f);
					area.Center = pos;
					area.SetDir(yaw);
					return area;
				}
			default:
				{
					ViRoundArea area = round;
					area.Init(info.maxRange * 0.01f + bodyRadius);
					area.Center = pos;
					return area;
				}
		}
	}
	ViRotRectArea rotRect = new ViRotRectArea();
	ViSectorArea sector = new ViSectorArea();
	ViRoundArea round = new ViRoundArea();
}