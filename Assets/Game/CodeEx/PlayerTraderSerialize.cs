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
public static class PlayerTraderSerializer
{
	public static void Append(ViOStream OS, PlayerTrader value)
	{
		ViEntitySerialize.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<PlayerTrader> list)
	{
		ViEntitySerialize.Append(OS, list);
	}
	public static void Read(ViIStream IS, out PlayerTrader value)
	{
		ViEntitySerialize.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<PlayerTrader> list)
	{
		ViEntitySerialize.Read(IS, out list);
	}
	public static bool Read(ViStringIStream IS, out PlayerTrader value)
	{
		return ViEntitySerialize.Read(IS, out value);
	}
	public static bool Read(ViStringIStream IS, out List<PlayerTrader> list)
	{
		return ViEntitySerialize.Read(IS, out list);
	}
	public static void PrintTo(PlayerTrader value, ref string strValue)
	{
		if (value != null)
		{
			strValue += value.Name;
		}
	}
	public static void PrintTo(List<PlayerTrader> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			PlayerTrader value = list[iter];
			if (value != null)
			{
				strValue += value.Name;
				strValue += ",";
			}
		}
		strValue += ")";
	}
	public static void PrintTo(PlayerTrader value, ViStringBuilder strValue)
	{
		if (value != null)
		{
			strValue.Add(value.Name);
		}
	}
	public static void PrintTo(List<PlayerTrader> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			PlayerTrader value = list[iter];
			if (value != null)
			{
				strValue.Add(value.Name);
				strValue.Add(",");
			}
		}
		strValue.Add(")");
	}
}