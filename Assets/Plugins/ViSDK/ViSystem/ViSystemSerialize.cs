using System;
using System.Collections;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViArrayIdx = System.Int32;

//+----------------------------------------------------------------------------------------------------------------
public static class Int8Serializer
{
	public static void Append(ViOStream OS, Int8 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<Int8> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out Int8 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<Int8> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out Int8 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<Int8> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int8 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int8 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class UInt8Serializer
{
	public static void Append(ViOStream OS, UInt8 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<UInt8> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out UInt8 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<UInt8> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out UInt8 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<UInt8> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt8 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt8 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class Int16Serializer
{
	public static void Append(ViOStream OS, Int16 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<Int16> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out Int16 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<Int16> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out Int16 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<Int16> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int16 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int16 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class UInt16Serializer
{
	public static void Append(ViOStream OS, UInt16 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<UInt16> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out UInt16 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<UInt16> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out UInt16 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<UInt16> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt16 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt16 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class Int32Serializer
{
	public static void Append(ViOStream OS, Int32 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<Int32> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out Int32 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<Int32> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out Int32 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<Int32> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int32 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int32 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class UInt32Serializer
{
	public static void Append(ViOStream OS, UInt32 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<UInt32> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out UInt32 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<UInt32> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out UInt32 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<UInt32> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt32 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt32 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class Int64Serializer
{
	public static void Append(ViOStream OS, Int64 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<Int64> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out Int64 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<Int64> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out Int64 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<Int64> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int64 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int64 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class UInt64Serializer
{
	public static void Append(ViOStream OS, UInt64 value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<UInt64> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out UInt64 value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<UInt64> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out UInt64 value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<UInt64> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt64 value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt64 value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class FloatSerializer
{
	public static void Append(ViOStream OS, float value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<float> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out float value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<float> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out float value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<float> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, float value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out float value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class DoubleSerializer
{
	public static void Append(ViOStream OS, double value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<double> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out double value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<double> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out double value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<double> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, double value)
	{
		OS.Add(head, value.ToString());
	}
	public static void Read(ViStringDictionaryStream IS, string head, out double value)
	{
		string valueString = string.Empty;
		valueString = IS.Get(head, string.Empty);
		ViStringSerialize.Read(valueString, out value);
	}
}

//+----------------------------------------------------------------------------------------------------------------
public static class StringSerializer
{
	public static void Append(ViOStream OS, string value)
	{
		OS.Append(value);
	}
	public static void Append(ViOStream OS, List<string> list)
	{
		OS.Append(list);
	}
	public static void Read(ViIStream IS, out string value)
	{
		IS.Read(out value);
	}
	public static void Read(ViIStream IS, out List<string> list)
	{
		IS.Read(out list);
	}
	public static bool Read(ViStringIStream IS, out string value)
	{
		return IS.Read(out value);
	}
	public static bool Read(ViStringIStream IS, out List<string> list)
	{
		return IS.Read(out list);
	}
	public static void Append(ViStringDictionaryStream OS, string head, string value)
	{
		OS.Add(head, value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out string value)
	{
		value = IS.Get(head, string.Empty);
	}
}
