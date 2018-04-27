using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
public static class CellHeroSerializer
{
	public static void Append(ViOStream OS, CellHero value)
	{
		ViEntitySerialize.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<CellHero> list)
	{
		ViEntitySerialize.Append(OS, list);
	}
	public static void Read(ViIStream IS, out CellHero value)
	{
		ViEntitySerialize.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<CellHero> list)
	{
		ViEntitySerialize.Read(IS, out list);
	}
	public static bool Read(ViStringIStream IS, out CellHero value)
	{
		return ViEntitySerialize.Read(IS, out value);
	}
	public static bool Read(ViStringIStream IS, out List<CellHero> list)
	{
		return ViEntitySerialize.Read(IS, out list);
	}
	public static void PrintTo(CellHero value, ref string strValue)
	{
		if (value != null)
		{
			strValue += value.Name;
		}
	}
	public static void PrintTo(List<CellHero> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			CellHero value = list[iter];
			if (value != null)
			{
				strValue += value.Name;
				strValue += ",";
			}
		}
		strValue += ")";
	}
	public static void PrintTo(CellHero value, ViStringBuilder strValue)
	{
		if (value != null)
		{
			strValue.Add(value.Name);
		}
	}
	public static void PrintTo(List<CellHero> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			CellHero value = list[iter];
			if (value != null)
			{
				strValue.Add(value.Name);
				strValue.Add(",");
			}
		}
		strValue.Add(")");
	}
}
