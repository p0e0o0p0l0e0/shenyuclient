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
public static class CenterChatGroupSerializer
{
	public static void Append(ViOStream OS, CenterChatGroup value)
	{
		ViEntitySerialize.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<CenterChatGroup> list)
	{
		ViEntitySerialize.Append(OS, list);
	}
	public static void Read(ViIStream IS, out CenterChatGroup value)
	{
		ViEntitySerialize.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<CenterChatGroup> list)
	{
		ViEntitySerialize.Read(IS, out list);
	}
	public static bool Read(ViStringIStream IS, out CenterChatGroup value)
	{
		return ViEntitySerialize.Read(IS, out value);
	}
	public static bool Read(ViStringIStream IS, out List<CenterChatGroup> list)
	{
		return ViEntitySerialize.Read(IS, out list);
	}
	public static void PrintTo(CenterChatGroup value, ref string strValue)
	{
		if (value != null)
		{
			strValue += value.Name;
		}
	}
	public static void PrintTo(List<CenterChatGroup> list, ref string strValue)
	{
		strValue += "(";
		for (int iter = 0; iter < list.Count; ++iter)
		{
			CenterChatGroup value = list[iter];
			if (value != null)
			{
				strValue += value.Name;
				strValue += ",";
			}
		}
		strValue += ")";
	}
	public static void PrintTo(CenterChatGroup value, ViStringBuilder strValue)
	{
		if (value != null)
		{
			strValue.Add(value.Name);
		}
	}
	public static void PrintTo(List<CenterChatGroup> list, ViStringBuilder strValue)
	{
		strValue.Add("(");
		for (int iter = 0; iter < list.Count; ++iter)
		{
			CenterChatGroup value = list[iter];
			if (value != null)
			{
				strValue.Add(value.Name);
				strValue.Add(",");
			}
		}
		strValue.Add(")");
	}
}