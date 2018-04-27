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
public static class PlayerGuildSerializer
{
	public static void Append(ViOStream OS, PlayerGuild value)
	{
		ViEntitySerialize.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<PlayerGuild> list)
	{
		ViEntitySerialize.Append(OS, list);
	}
	public static void Read(ViIStream IS, out PlayerGuild value)
	{
		ViEntitySerialize.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<PlayerGuild> list)
	{
		ViEntitySerialize.Read(IS, out list);
	}
	public static bool Read(ViStringIStream IS, out PlayerGuild value)
	{
		return ViEntitySerialize.Read(IS, out value);
	}
	public static bool Read(ViStringIStream IS, out List<PlayerGuild> list)
	{
		return ViEntitySerialize.Read(IS, out list);
	}
	public static void PrintTo(PlayerGuild value, ref string strValue)
	{
		if (value != null)
		{
			strValue += value.Name;
		}
	}
	public static void PrintTo(List<PlayerGuild> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			PlayerGuild value = list[iter];
			if (value != null)
			{
				strValue += value.Name;
				strValue += ",";
			}
		}
		strValue += ")";
	}
	public static void PrintTo(PlayerGuild value, ViStringBuilder strValue)
	{
		if (value != null)
		{
			strValue.Add(value.Name);
		}
	}
	public static void PrintTo(List<PlayerGuild> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			PlayerGuild value = list[iter];
			if (value != null)
			{
				strValue.Add(value.Name);
				strValue.Add(",");
			}
		}
		strValue.Add(")");
	}
}
