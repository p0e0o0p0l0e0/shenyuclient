using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public static class Int8PropertySerializer
{
	public static void Append(ViOStream OS, Int8Property value)
	{
		ViGameSerializer<Int8>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out Int8Property value)
	{
		ViGameSerializer<Int8>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out Int8Property value)
	{
		value = default(Int8Property);
		if(ViGameSerializer<Int8>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int8Property value)
	{
		ViGameSerializer<Int8>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int8Property value)
	{
		value = new Int8Property();
		ViGameSerializer<Int8>.Read(IS, head, out value.Value);
	}
}
public static class UInt8PropertySerializer
{
	public static void Append(ViOStream OS, UInt8Property value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out UInt8Property value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out UInt8Property value)
	{
		value = default(UInt8Property);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt8Property value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt8Property value)
	{
		value = new UInt8Property();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Value);
	}
}
public static class Int16PropertySerializer
{
	public static void Append(ViOStream OS, Int16Property value)
	{
		ViGameSerializer<Int16>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out Int16Property value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out Int16Property value)
	{
		value = default(Int16Property);
		if(ViGameSerializer<Int16>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int16Property value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int16Property value)
	{
		value = new Int16Property();
		ViGameSerializer<Int16>.Read(IS, head, out value.Value);
	}
}
public static class UInt16PropertySerializer
{
	public static void Append(ViOStream OS, UInt16Property value)
	{
		ViGameSerializer<UInt16>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out UInt16Property value)
	{
		ViGameSerializer<UInt16>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out UInt16Property value)
	{
		value = default(UInt16Property);
		if(ViGameSerializer<UInt16>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt16Property value)
	{
		ViGameSerializer<UInt16>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt16Property value)
	{
		value = new UInt16Property();
		ViGameSerializer<UInt16>.Read(IS, head, out value.Value);
	}
}
public static class Int32PropertySerializer
{
	public static void Append(ViOStream OS, Int32Property value)
	{
		ViGameSerializer<Int32>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out Int32Property value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out Int32Property value)
	{
		value = default(Int32Property);
		if(ViGameSerializer<Int32>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int32Property value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int32Property value)
	{
		value = new Int32Property();
		ViGameSerializer<Int32>.Read(IS, head, out value.Value);
	}
}
public static class UInt32PropertySerializer
{
	public static void Append(ViOStream OS, UInt32Property value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out UInt32Property value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out UInt32Property value)
	{
		value = default(UInt32Property);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt32Property value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt32Property value)
	{
		value = new UInt32Property();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Value);
	}
}
public static class Int64PropertySerializer
{
	public static void Append(ViOStream OS, Int64Property value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out Int64Property value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out Int64Property value)
	{
		value = default(Int64Property);
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int64Property value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int64Property value)
	{
		value = new Int64Property();
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class UInt64PropertySerializer
{
	public static void Append(ViOStream OS, UInt64Property value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out UInt64Property value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out UInt64Property value)
	{
		value = default(UInt64Property);
		if(ViGameSerializer<UInt64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt64Property value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt64Property value)
	{
		value = new UInt64Property();
		ViGameSerializer<UInt64>.Read(IS, head, out value.Value);
	}
}
public static class FloatPropertySerializer
{
	public static void Append(ViOStream OS, FloatProperty value)
	{
		ViGameSerializer<float>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out FloatProperty value)
	{
		ViGameSerializer<float>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out FloatProperty value)
	{
		value = default(FloatProperty);
		if(ViGameSerializer<float>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, FloatProperty value)
	{
		ViGameSerializer<float>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out FloatProperty value)
	{
		value = new FloatProperty();
		ViGameSerializer<float>.Read(IS, head, out value.Value);
	}
}
public static class StringPropertySerializer
{
	public static void Append(ViOStream OS, StringProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out StringProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out StringProperty value)
	{
		value = default(StringProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, StringProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out StringProperty value)
	{
		value = new StringProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Value);
	}
}
public static class Int8PtrPropertySerializer
{
	public static void Append(ViOStream OS, Int8PtrProperty value)
	{
		ViGameSerializer<Int8Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out Int8PtrProperty value)
	{
		ViGameSerializer<Int8Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out Int8PtrProperty value)
	{
		value = default(Int8PtrProperty);
		if(ViGameSerializer<Int8Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int8PtrProperty value)
	{
		ViGameSerializer<Int8Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int8PtrProperty value)
	{
		value = new Int8PtrProperty();
		ViGameSerializer<Int8Property>.Read(IS, head, out value.Ptr);
	}
}
public static class UInt8PtrPropertySerializer
{
	public static void Append(ViOStream OS, UInt8PtrProperty value)
	{
		ViGameSerializer<UInt8Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out UInt8PtrProperty value)
	{
		ViGameSerializer<UInt8Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out UInt8PtrProperty value)
	{
		value = default(UInt8PtrProperty);
		if(ViGameSerializer<UInt8Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt8PtrProperty value)
	{
		ViGameSerializer<UInt8Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt8PtrProperty value)
	{
		value = new UInt8PtrProperty();
		ViGameSerializer<UInt8Property>.Read(IS, head, out value.Ptr);
	}
}
public static class Int16PtrPropertySerializer
{
	public static void Append(ViOStream OS, Int16PtrProperty value)
	{
		ViGameSerializer<Int16Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out Int16PtrProperty value)
	{
		ViGameSerializer<Int16Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out Int16PtrProperty value)
	{
		value = default(Int16PtrProperty);
		if(ViGameSerializer<Int16Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int16PtrProperty value)
	{
		ViGameSerializer<Int16Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int16PtrProperty value)
	{
		value = new Int16PtrProperty();
		ViGameSerializer<Int16Property>.Read(IS, head, out value.Ptr);
	}
}
public static class UInt16PtrPropertySerializer
{
	public static void Append(ViOStream OS, UInt16PtrProperty value)
	{
		ViGameSerializer<UInt16Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out UInt16PtrProperty value)
	{
		ViGameSerializer<UInt16Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out UInt16PtrProperty value)
	{
		value = default(UInt16PtrProperty);
		if(ViGameSerializer<UInt16Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt16PtrProperty value)
	{
		ViGameSerializer<UInt16Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt16PtrProperty value)
	{
		value = new UInt16PtrProperty();
		ViGameSerializer<UInt16Property>.Read(IS, head, out value.Ptr);
	}
}
public static class Int32PtrPropertySerializer
{
	public static void Append(ViOStream OS, Int32PtrProperty value)
	{
		ViGameSerializer<Int32Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out Int32PtrProperty value)
	{
		ViGameSerializer<Int32Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out Int32PtrProperty value)
	{
		value = default(Int32PtrProperty);
		if(ViGameSerializer<Int32Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Int32PtrProperty value)
	{
		ViGameSerializer<Int32Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Int32PtrProperty value)
	{
		value = new Int32PtrProperty();
		ViGameSerializer<Int32Property>.Read(IS, head, out value.Ptr);
	}
}
public static class UInt32PtrPropertySerializer
{
	public static void Append(ViOStream OS, UInt32PtrProperty value)
	{
		ViGameSerializer<UInt32Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out UInt32PtrProperty value)
	{
		ViGameSerializer<UInt32Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out UInt32PtrProperty value)
	{
		value = default(UInt32PtrProperty);
		if(ViGameSerializer<UInt32Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt32PtrProperty value)
	{
		ViGameSerializer<UInt32Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt32PtrProperty value)
	{
		value = new UInt32PtrProperty();
		ViGameSerializer<UInt32Property>.Read(IS, head, out value.Ptr);
	}
}
public static class UInt64PtrPropertySerializer
{
	public static void Append(ViOStream OS, UInt64PtrProperty value)
	{
		ViGameSerializer<UInt64Property>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out UInt64PtrProperty value)
	{
		ViGameSerializer<UInt64Property>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out UInt64PtrProperty value)
	{
		value = default(UInt64PtrProperty);
		if(ViGameSerializer<UInt64Property>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt64PtrProperty value)
	{
		ViGameSerializer<UInt64Property>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt64PtrProperty value)
	{
		value = new UInt64PtrProperty();
		ViGameSerializer<UInt64Property>.Read(IS, head, out value.Ptr);
	}
}
public static class StringPtrPropertySerializer
{
	public static void Append(ViOStream OS, StringPtrProperty value)
	{
		ViGameSerializer<StringProperty>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out StringPtrProperty value)
	{
		ViGameSerializer<StringProperty>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out StringPtrProperty value)
	{
		value = default(StringPtrProperty);
		if(ViGameSerializer<StringProperty>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, StringPtrProperty value)
	{
		ViGameSerializer<StringProperty>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out StringPtrProperty value)
	{
		value = new StringPtrProperty();
		ViGameSerializer<StringProperty>.Read(IS, head, out value.Ptr);
	}
}
public static class TimePropertySerializer
{
	public static void Append(ViOStream OS, TimeProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out TimeProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out TimeProperty value)
	{
		value = default(TimeProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, TimeProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out TimeProperty value)
	{
		value = new TimeProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class Time1970PropertySerializer
{
	public static void Append(ViOStream OS, Time1970Property value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out Time1970Property value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out Time1970Property value)
	{
		value = default(Time1970Property);
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, Time1970Property value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out Time1970Property value)
	{
		value = new Time1970Property();
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class LoopCountPropertySerializer
{
	public static void Append(ViOStream OS, LoopCountProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.AccumulateCount);
	}
	public static void Read(ViIStream IS, out LoopCountProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.AccumulateCount);
	}
	public static bool Read(ViStringIStream IS, out LoopCountProperty value)
	{
		value = default(LoopCountProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AccumulateCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, LoopCountProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".AccumulateCount", value.AccumulateCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out LoopCountProperty value)
	{
		value = new LoopCountProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.AccumulateCount);
	}
}
public static class ShortCutPropertySerializer
{
	public static void Append(ViOStream OS, ShortCutProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Type);
		ViGameSerializer<UInt64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out ShortCutProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Type);
		ViGameSerializer<UInt64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out ShortCutProperty value)
	{
		value = default(ShortCutProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ShortCutProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<UInt64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ShortCutProperty value)
	{
		value = new ShortCutProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Type);
		ViGameSerializer<UInt64>.Read(IS, head, out value.Value);
	}
}
public static class KeyboardValuePropertySerializer
{
	public static void Append(ViOStream OS, KeyboardValueProperty value)
	{
		ViGameSerializer<UInt16>.Append(OS, value.Value0);
		ViGameSerializer<UInt16>.Append(OS, value.Value1);
	}
	public static void Read(ViIStream IS, out KeyboardValueProperty value)
	{
		ViGameSerializer<UInt16>.Read(IS, out value.Value0);
		ViGameSerializer<UInt16>.Read(IS, out value.Value1);
	}
	public static bool Read(ViStringIStream IS, out KeyboardValueProperty value)
	{
		value = default(KeyboardValueProperty);
		if(ViGameSerializer<UInt16>.Read(IS, out value.Value0) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Value1) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, KeyboardValueProperty value)
	{
		ViGameSerializer<UInt16>.Append(OS, head + ".Value0", value.Value0);
		ViGameSerializer<UInt16>.Append(OS, head + ".Value1", value.Value1);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out KeyboardValueProperty value)
	{
		value = new KeyboardValueProperty();
		ViGameSerializer<UInt16>.Read(IS, head, out value.Value0);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Value1);
	}
}
public static class KeyboardSlotPropertySerializer
{
	public static void Append(ViOStream OS, KeyboardSlotProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Key);
		ViGameSerializer<UInt16>.Append(OS, value.Value0);
		ViGameSerializer<UInt16>.Append(OS, value.Value1);
	}
	public static void Read(ViIStream IS, out KeyboardSlotProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Key);
		ViGameSerializer<UInt16>.Read(IS, out value.Value0);
		ViGameSerializer<UInt16>.Read(IS, out value.Value1);
	}
	public static bool Read(ViStringIStream IS, out KeyboardSlotProperty value)
	{
		value = default(KeyboardSlotProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Key) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Value0) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Value1) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, KeyboardSlotProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Key", value.Key);
		ViGameSerializer<UInt16>.Append(OS, head + ".Value0", value.Value0);
		ViGameSerializer<UInt16>.Append(OS, head + ".Value1", value.Value1);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out KeyboardSlotProperty value)
	{
		value = new KeyboardSlotProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Key);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Value0);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Value1);
	}
}
public static class MessagePropertySerializer
{
	public static void Append(ViOStream OS, MessageProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ViString>.Append(OS, value.Content);
	}
	public static void Read(ViIStream IS, out MessageProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, out value.Content);
	}
	public static bool Read(ViStringIStream IS, out MessageProperty value)
	{
		value = default(MessageProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Content) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MessageProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ViString>.Append(OS, head + ".Content", value.Content);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MessageProperty value)
	{
		value = new MessageProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, head, out value.Content);
	}
}
public static class EntityIDNamePropertySerializer
{
	public static void Append(ViOStream OS, EntityIDNameProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ViString>.Append(OS, value.Name);
	}
	public static void Read(ViIStream IS, out EntityIDNameProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ViString>.Read(IS, out value.Name);
	}
	public static bool Read(ViStringIStream IS, out EntityIDNameProperty value)
	{
		value = default(EntityIDNameProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, EntityIDNameProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out EntityIDNameProperty value)
	{
		value = new EntityIDNameProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
	}
}
public static class PlayerIdentificationPropertySerializer
{
	public static void Append(ViOStream OS, PlayerIdentificationProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<ViString>.Append(OS, value.NameAlias);
		ViGameSerializer<UInt8>.Append(OS, value.Photo);
	}
	public static void Read(ViIStream IS, out PlayerIdentificationProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<ViString>.Read(IS, out value.NameAlias);
		ViGameSerializer<UInt8>.Read(IS, out value.Photo);
	}
	public static bool Read(ViStringIStream IS, out PlayerIdentificationProperty value)
	{
		value = default(PlayerIdentificationProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.NameAlias) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Photo) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerIdentificationProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<ViString>.Append(OS, head + ".NameAlias", value.NameAlias);
		ViGameSerializer<UInt8>.Append(OS, head + ".Photo", value.Photo);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerIdentificationProperty value)
	{
		value = new PlayerIdentificationProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<ViString>.Read(IS, head, out value.NameAlias);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Photo);
	}
}
public static class StringInt32PropertySerializer
{
	public static void Append(ViOStream OS, StringInt32Property value)
	{
		ViGameSerializer<ViString>.Append(OS, value.StrValue);
		ViGameSerializer<Int32>.Append(OS, value.Int32Value);
	}
	public static void Read(ViIStream IS, out StringInt32Property value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.StrValue);
		ViGameSerializer<Int32>.Read(IS, out value.Int32Value);
	}
	public static bool Read(ViStringIStream IS, out StringInt32Property value)
	{
		value = default(StringInt32Property);
		if(ViGameSerializer<ViString>.Read(IS, out value.StrValue) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Int32Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, StringInt32Property value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".StrValue", value.StrValue);
		ViGameSerializer<Int32>.Append(OS, head + ".Int32Value", value.Int32Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out StringInt32Property value)
	{
		value = new StringInt32Property();
		ViGameSerializer<ViString>.Read(IS, head, out value.StrValue);
		ViGameSerializer<Int32>.Read(IS, head, out value.Int32Value);
	}
}
public static class StringInt64PropertySerializer
{
	public static void Append(ViOStream OS, StringInt64Property value)
	{
		ViGameSerializer<ViString>.Append(OS, value.StrValue);
		ViGameSerializer<Int64>.Append(OS, value.Int64Value);
	}
	public static void Read(ViIStream IS, out StringInt64Property value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.StrValue);
		ViGameSerializer<Int64>.Read(IS, out value.Int64Value);
	}
	public static bool Read(ViStringIStream IS, out StringInt64Property value)
	{
		value = default(StringInt64Property);
		if(ViGameSerializer<ViString>.Read(IS, out value.StrValue) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Int64Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, StringInt64Property value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".StrValue", value.StrValue);
		ViGameSerializer<Int64>.Append(OS, head + ".Int64Value", value.Int64Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out StringInt64Property value)
	{
		value = new StringInt64Property();
		ViGameSerializer<ViString>.Read(IS, head, out value.StrValue);
		ViGameSerializer<Int64>.Read(IS, head, out value.Int64Value);
	}
}
public static class UInt64Int32PropertySerializer
{
	public static void Append(ViOStream OS, UInt64Int32Property value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.UInt64Value);
		ViGameSerializer<Int32>.Append(OS, value.Int32Value);
	}
	public static void Read(ViIStream IS, out UInt64Int32Property value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.UInt64Value);
		ViGameSerializer<Int32>.Read(IS, out value.Int32Value);
	}
	public static bool Read(ViStringIStream IS, out UInt64Int32Property value)
	{
		value = default(UInt64Int32Property);
		if(ViGameSerializer<UInt64>.Read(IS, out value.UInt64Value) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Int32Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt64Int32Property value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".UInt64Value", value.UInt64Value);
		ViGameSerializer<Int32>.Append(OS, head + ".Int32Value", value.Int32Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt64Int32Property value)
	{
		value = new UInt64Int32Property();
		ViGameSerializer<UInt64>.Read(IS, head, out value.UInt64Value);
		ViGameSerializer<Int32>.Read(IS, head, out value.Int32Value);
	}
}
public static class UInt32Int16PropertySerializer
{
	public static void Append(ViOStream OS, UInt32Int16Property value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.UInt64Value);
		ViGameSerializer<Int32>.Append(OS, value.Int32Value);
	}
	public static void Read(ViIStream IS, out UInt32Int16Property value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.UInt64Value);
		ViGameSerializer<Int32>.Read(IS, out value.Int32Value);
	}
	public static bool Read(ViStringIStream IS, out UInt32Int16Property value)
	{
		value = default(UInt32Int16Property);
		if(ViGameSerializer<UInt64>.Read(IS, out value.UInt64Value) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Int32Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, UInt32Int16Property value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".UInt64Value", value.UInt64Value);
		ViGameSerializer<Int32>.Append(OS, head + ".Int32Value", value.Int32Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out UInt32Int16Property value)
	{
		value = new UInt32Int16Property();
		ViGameSerializer<UInt64>.Read(IS, head, out value.UInt64Value);
		ViGameSerializer<Int32>.Read(IS, head, out value.Int32Value);
	}
}
public static class CountValue64PropertySerializer
{
	public static void Append(ViOStream OS, CountValue64Property value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out CountValue64Property value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out CountValue64Property value)
	{
		value = default(CountValue64Property);
		if(ViGameSerializer<Int64>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, CountValue64Property value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out CountValue64Property value)
	{
		value = new CountValue64Property();
		ViGameSerializer<Int64>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class StatisticsValuePropertySerializer
{
	public static void Append(ViOStream OS, StatisticsValueProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.Sum);
	}
	public static void Read(ViIStream IS, out StatisticsValueProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.Sum);
	}
	public static bool Read(ViStringIStream IS, out StatisticsValueProperty value)
	{
		value = default(StatisticsValueProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Sum) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, StatisticsValueProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".Sum", value.Sum);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out StatisticsValueProperty value)
	{
		value = new StatisticsValueProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.Sum);
	}
}
public static class ProgressPropertySerializer
{
	public static void Append(ViOStream OS, ProgressProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out ProgressProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out ProgressProperty value)
	{
		value = default(ProgressProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ProgressProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ProgressProperty value)
	{
		value = new ProgressProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class VisualAuraProperty_AliasSerializer
{
	public static void Append(ViOStream OS, VisualAuraProperty_Alias value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Effect);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
		ViGameSerializer<Int8>.Append(OS, value.Level);
		ViGameSerializer<UInt64>.Append(OS, value.Caster);
	}
	public static void Read(ViIStream IS, out VisualAuraProperty_Alias value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Effect);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
		ViGameSerializer<Int8>.Read(IS, out value.Level);
		ViGameSerializer<UInt64>.Read(IS, out value.Caster);
	}
	public static bool Read(ViStringIStream IS, out VisualAuraProperty_Alias value)
	{
		value = default(VisualAuraProperty_Alias);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Effect) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<Int8>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.Caster) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, VisualAuraProperty_Alias value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Effect", value.Effect);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<Int8>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt64>.Append(OS, head + ".Caster", value.Caster);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out VisualAuraProperty_Alias value)
	{
		value = new VisualAuraProperty_Alias();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Effect);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
		ViGameSerializer<Int8>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt64>.Read(IS, head, out value.Caster);
	}
}
public static class DatePropertySerializer
{
	public static void Append(ViOStream OS, DateProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Year);
		ViGameSerializer<UInt8>.Append(OS, value.Month);
		ViGameSerializer<UInt8>.Append(OS, value.Day);
		ViGameSerializer<UInt8>.Append(OS, value.Hour);
		ViGameSerializer<UInt8>.Append(OS, value.Minute);
		ViGameSerializer<UInt8>.Append(OS, value.WeakDay);
	}
	public static void Read(ViIStream IS, out DateProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Year);
		ViGameSerializer<UInt8>.Read(IS, out value.Month);
		ViGameSerializer<UInt8>.Read(IS, out value.Day);
		ViGameSerializer<UInt8>.Read(IS, out value.Hour);
		ViGameSerializer<UInt8>.Read(IS, out value.Minute);
		ViGameSerializer<UInt8>.Read(IS, out value.WeakDay);
	}
	public static bool Read(ViStringIStream IS, out DateProperty value)
	{
		value = default(DateProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Year) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Month) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Day) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Hour) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Minute) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.WeakDay) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, DateProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Year", value.Year);
		ViGameSerializer<UInt8>.Append(OS, head + ".Month", value.Month);
		ViGameSerializer<UInt8>.Append(OS, head + ".Day", value.Day);
		ViGameSerializer<UInt8>.Append(OS, head + ".Hour", value.Hour);
		ViGameSerializer<UInt8>.Append(OS, head + ".Minute", value.Minute);
		ViGameSerializer<UInt8>.Append(OS, head + ".WeakDay", value.WeakDay);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out DateProperty value)
	{
		value = new DateProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Year);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Month);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Day);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Hour);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Minute);
		ViGameSerializer<UInt8>.Read(IS, head, out value.WeakDay);
	}
}
public static class AccmulateDurationPropertySerializer
{
	public static void Append(ViOStream OS, AccmulateDurationProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<Int64>.Append(OS, value.Duration);
	}
	public static void Read(ViIStream IS, out AccmulateDurationProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, out value.Duration);
	}
	public static bool Read(ViStringIStream IS, out AccmulateDurationProperty value)
	{
		value = default(AccmulateDurationProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Duration) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, AccmulateDurationProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<Int64>.Append(OS, head + ".Duration", value.Duration);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out AccmulateDurationProperty value)
	{
		value = new AccmulateDurationProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.Duration);
	}
}
public static class TimeDurationPropertySerializer
{
	public static void Append(ViOStream OS, TimeDurationProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out TimeDurationProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out TimeDurationProperty value)
	{
		value = default(TimeDurationProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, TimeDurationProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out TimeDurationProperty value)
	{
		value = new TimeDurationProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class ChatRecordPropertySerializer
{
	public static void Append(ViOStream OS, ChatRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Sayer);
		ViGameSerializer<ViString>.Append(OS, value.Content);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
	}
	public static void Read(ViIStream IS, out ChatRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Sayer);
		ViGameSerializer<ViString>.Read(IS, out value.Content);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
	}
	public static bool Read(ViStringIStream IS, out ChatRecordProperty value)
	{
		value = default(ChatRecordProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Sayer) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Content) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ChatRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Sayer", value.Sayer);
		ViGameSerializer<ViString>.Append(OS, head + ".Content", value.Content);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ChatRecordProperty value)
	{
		value = new ChatRecordProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Sayer);
		ViGameSerializer<ViString>.Read(IS, head, out value.Content);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
	}
}
public static class PlayerShotHeroPropertySerializer
{
	public static void Append(ViOStream OS, PlayerShotHeroProperty value)
	{
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int16>.Append(OS, value.Star);
		ViGameSerializer<Int16>.Append(OS, value.Quality);
		ViGameSerializer<Int16>.Append(OS, value.WeaponLevel);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
	}
	public static void Read(ViIStream IS, out PlayerShotHeroProperty value)
	{
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int16>.Read(IS, out value.Star);
		ViGameSerializer<Int16>.Read(IS, out value.Quality);
		ViGameSerializer<Int16>.Read(IS, out value.WeaponLevel);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
	}
	public static bool Read(ViStringIStream IS, out PlayerShotHeroProperty value)
	{
		value = default(PlayerShotHeroProperty);
		if(ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Star) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Quality) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.WeaponLevel) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerShotHeroProperty value)
	{
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int16>.Append(OS, head + ".Star", value.Star);
		ViGameSerializer<Int16>.Append(OS, head + ".Quality", value.Quality);
		ViGameSerializer<Int16>.Append(OS, head + ".WeaponLevel", value.WeaponLevel);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerShotHeroProperty value)
	{
		value = new PlayerShotHeroProperty();
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int16>.Read(IS, head, out value.Star);
		ViGameSerializer<Int16>.Read(IS, head, out value.Quality);
		ViGameSerializer<Int16>.Read(IS, head, out value.WeaponLevel);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
	}
}
public static class PlayerShotHeroArrayPropertySerializer
{
	public static void Append(ViOStream OS, PlayerShotHeroArrayProperty value)
	{
		ViGameSerializer<PlayerShotHeroProperty>.Append(OS, value.E0);
		ViGameSerializer<PlayerShotHeroProperty>.Append(OS, value.E1);
		ViGameSerializer<PlayerShotHeroProperty>.Append(OS, value.E2);
	}
	public static void Read(ViIStream IS, out PlayerShotHeroArrayProperty value)
	{
		ViGameSerializer<PlayerShotHeroProperty>.Read(IS, out value.E0);
		ViGameSerializer<PlayerShotHeroProperty>.Read(IS, out value.E1);
		ViGameSerializer<PlayerShotHeroProperty>.Read(IS, out value.E2);
	}
	public static bool Read(ViStringIStream IS, out PlayerShotHeroArrayProperty value)
	{
		value = default(PlayerShotHeroArrayProperty);
		if(ViGameSerializer<PlayerShotHeroProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<PlayerShotHeroProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<PlayerShotHeroProperty>.Read(IS, out value.E2) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerShotHeroArrayProperty value)
	{
		ViGameSerializer<PlayerShotHeroProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<PlayerShotHeroProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<PlayerShotHeroProperty>.Append(OS, head + ".E2", value.E2);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerShotHeroArrayProperty value)
	{
		value = new PlayerShotHeroArrayProperty();
		ViGameSerializer<PlayerShotHeroProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<PlayerShotHeroProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<PlayerShotHeroProperty>.Read(IS, head, out value.E2);
	}
}
public static class PlayerShotPropertySerializer
{
	public static void Append(ViOStream OS, PlayerShotProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identify);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Class);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int64>.Append(OS, value.LastActiveTime1970);
		ViGameSerializer<ViString>.Append(OS, value.Guild);
		ViGameSerializer<PlayerShotHeroArrayProperty>.Append(OS, value.HeroList);
	}
	public static void Read(ViIStream IS, out PlayerShotProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identify);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Class);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int64>.Read(IS, out value.LastActiveTime1970);
		ViGameSerializer<ViString>.Read(IS, out value.Guild);
		ViGameSerializer<PlayerShotHeroArrayProperty>.Read(IS, out value.HeroList);
	}
	public static bool Read(ViStringIStream IS, out PlayerShotProperty value)
	{
		value = default(PlayerShotProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identify) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Class) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastActiveTime1970) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Guild) == false){return false;}
		if(ViGameSerializer<PlayerShotHeroArrayProperty>.Read(IS, out value.HeroList) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerShotProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identify", value.Identify);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Class", value.Class);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int64>.Append(OS, head + ".LastActiveTime1970", value.LastActiveTime1970);
		ViGameSerializer<ViString>.Append(OS, head + ".Guild", value.Guild);
		ViGameSerializer<PlayerShotHeroArrayProperty>.Append(OS, head + ".HeroList", value.HeroList);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerShotProperty value)
	{
		value = new PlayerShotProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identify);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Class);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastActiveTime1970);
		ViGameSerializer<ViString>.Read(IS, head, out value.Guild);
		ViGameSerializer<PlayerShotHeroArrayProperty>.Read(IS, head, out value.HeroList);
	}
}
public static class LevelUpdatePropertySerializer
{
	public static void Append(ViOStream OS, LevelUpdateProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int16>.Append(OS, value.Power);
	}
	public static void Read(ViIStream IS, out LevelUpdateProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int16>.Read(IS, out value.Power);
	}
	public static bool Read(ViStringIStream IS, out LevelUpdateProperty value)
	{
		value = default(LevelUpdateProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Power) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, LevelUpdateProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int16>.Append(OS, head + ".Power", value.Power);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out LevelUpdateProperty value)
	{
		value = new LevelUpdateProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int16>.Read(IS, head, out value.Power);
	}
}
public static class LevelXPUpdatePropertySerializer
{
	public static void Append(ViOStream OS, LevelXPUpdateProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int64>.Append(OS, value.XP);
	}
	public static void Read(ViIStream IS, out LevelXPUpdateProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int64>.Read(IS, out value.XP);
	}
	public static bool Read(ViStringIStream IS, out LevelXPUpdateProperty value)
	{
		value = default(LevelXPUpdateProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.XP) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, LevelXPUpdateProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int64>.Append(OS, head + ".XP", value.XP);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out LevelXPUpdateProperty value)
	{
		value = new LevelXPUpdateProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int64>.Read(IS, head, out value.XP);
	}
}
public static class ScorePropertySerializer
{
	public static void Append(ViOStream OS, ScoreProperty value)
	{
		ViGameSerializer<ViForeignKey<ScoreStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int32>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out ScoreProperty value)
	{
		ViGameSerializer<ViForeignKey<ScoreStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int32>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out ScoreProperty value)
	{
		value = default(ScoreProperty);
		if(ViGameSerializer<ViForeignKey<ScoreStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ScoreProperty value)
	{
		ViGameSerializer<ViForeignKey<ScoreStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int32>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ScoreProperty value)
	{
		value = new ScoreProperty();
		ViGameSerializer<ViForeignKey<ScoreStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int32>.Read(IS, head, out value.Value);
	}
}
public static class ScoreArray6PropertySerializer
{
	public static void Append(ViOStream OS, ScoreArray6Property value)
	{
		ViGameSerializer<ScoreProperty>.Append(OS, value.E0);
		ViGameSerializer<ScoreProperty>.Append(OS, value.E1);
		ViGameSerializer<ScoreProperty>.Append(OS, value.E2);
		ViGameSerializer<ScoreProperty>.Append(OS, value.E3);
		ViGameSerializer<ScoreProperty>.Append(OS, value.E4);
		ViGameSerializer<ScoreProperty>.Append(OS, value.E5);
	}
	public static void Read(ViIStream IS, out ScoreArray6Property value)
	{
		ViGameSerializer<ScoreProperty>.Read(IS, out value.E0);
		ViGameSerializer<ScoreProperty>.Read(IS, out value.E1);
		ViGameSerializer<ScoreProperty>.Read(IS, out value.E2);
		ViGameSerializer<ScoreProperty>.Read(IS, out value.E3);
		ViGameSerializer<ScoreProperty>.Read(IS, out value.E4);
		ViGameSerializer<ScoreProperty>.Read(IS, out value.E5);
	}
	public static bool Read(ViStringIStream IS, out ScoreArray6Property value)
	{
		value = default(ScoreArray6Property);
		if(ViGameSerializer<ScoreProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<ScoreProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<ScoreProperty>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<ScoreProperty>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<ScoreProperty>.Read(IS, out value.E4) == false){return false;}
		if(ViGameSerializer<ScoreProperty>.Read(IS, out value.E5) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ScoreArray6Property value)
	{
		ViGameSerializer<ScoreProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<ScoreProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<ScoreProperty>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<ScoreProperty>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<ScoreProperty>.Append(OS, head + ".E4", value.E4);
		ViGameSerializer<ScoreProperty>.Append(OS, head + ".E5", value.E5);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ScoreArray6Property value)
	{
		value = new ScoreArray6Property();
		ViGameSerializer<ScoreProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<ScoreProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<ScoreProperty>.Read(IS, head, out value.E2);
		ViGameSerializer<ScoreProperty>.Read(IS, head, out value.E3);
		ViGameSerializer<ScoreProperty>.Read(IS, head, out value.E4);
		ViGameSerializer<ScoreProperty>.Read(IS, head, out value.E5);
	}
}
public static class ItemCountPropertySerializer
{
	public static void Append(ViOStream OS, ItemCountProperty value)
	{
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out ItemCountProperty value)
	{
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out ItemCountProperty value)
	{
		value = default(ItemCountProperty);
		if(ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemCountProperty value)
	{
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemCountProperty value)
	{
		value = new ItemCountProperty();
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
	}
}
public static class ItemCountWithColorPropertySerializer
{
	public static void Append(ViOStream OS, ItemCountWithColorProperty value)
	{
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int32>.Append(OS, value.Count);
		ViGameSerializer<UInt8>.Append(OS, value.Color);
	}
	public static void Read(ViIStream IS, out ItemCountWithColorProperty value)
	{
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
		ViGameSerializer<UInt8>.Read(IS, out value.Color);
	}
	public static bool Read(ViStringIStream IS, out ItemCountWithColorProperty value)
	{
		value = default(ItemCountWithColorProperty);
		if(ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Color) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemCountWithColorProperty value)
	{
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<UInt8>.Append(OS, head + ".Color", value.Color);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemCountWithColorProperty value)
	{
		value = new ItemCountWithColorProperty();
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Color);
	}
}
public static class ItemCountArray6PropertySerializer
{
	public static void Append(ViOStream OS, ItemCountArray6Property value)
	{
		ViGameSerializer<ItemCountProperty>.Append(OS, value.E0);
		ViGameSerializer<ItemCountProperty>.Append(OS, value.E1);
		ViGameSerializer<ItemCountProperty>.Append(OS, value.E2);
		ViGameSerializer<ItemCountProperty>.Append(OS, value.E3);
		ViGameSerializer<ItemCountProperty>.Append(OS, value.E4);
		ViGameSerializer<ItemCountProperty>.Append(OS, value.E5);
	}
	public static void Read(ViIStream IS, out ItemCountArray6Property value)
	{
		ViGameSerializer<ItemCountProperty>.Read(IS, out value.E0);
		ViGameSerializer<ItemCountProperty>.Read(IS, out value.E1);
		ViGameSerializer<ItemCountProperty>.Read(IS, out value.E2);
		ViGameSerializer<ItemCountProperty>.Read(IS, out value.E3);
		ViGameSerializer<ItemCountProperty>.Read(IS, out value.E4);
		ViGameSerializer<ItemCountProperty>.Read(IS, out value.E5);
	}
	public static bool Read(ViStringIStream IS, out ItemCountArray6Property value)
	{
		value = default(ItemCountArray6Property);
		if(ViGameSerializer<ItemCountProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<ItemCountProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<ItemCountProperty>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<ItemCountProperty>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<ItemCountProperty>.Read(IS, out value.E4) == false){return false;}
		if(ViGameSerializer<ItemCountProperty>.Read(IS, out value.E5) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemCountArray6Property value)
	{
		ViGameSerializer<ItemCountProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<ItemCountProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<ItemCountProperty>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<ItemCountProperty>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<ItemCountProperty>.Append(OS, head + ".E4", value.E4);
		ViGameSerializer<ItemCountProperty>.Append(OS, head + ".E5", value.E5);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemCountArray6Property value)
	{
		value = new ItemCountArray6Property();
		ViGameSerializer<ItemCountProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<ItemCountProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<ItemCountProperty>.Read(IS, head, out value.E2);
		ViGameSerializer<ItemCountProperty>.Read(IS, head, out value.E3);
		ViGameSerializer<ItemCountProperty>.Read(IS, head, out value.E4);
		ViGameSerializer<ItemCountProperty>.Read(IS, head, out value.E5);
	}
}
public static class BagSlotSerializer
{
	public static void Append(ViOStream OS, BagSlot value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Bag);
		ViGameSerializer<UInt16>.Append(OS, value.Slot);
	}
	public static void Read(ViIStream IS, out BagSlot value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Bag);
		ViGameSerializer<UInt16>.Read(IS, out value.Slot);
	}
	public static bool Read(ViStringIStream IS, out BagSlot value)
	{
		value = default(BagSlot);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Bag) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Slot) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, BagSlot value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Bag", value.Bag);
		ViGameSerializer<UInt16>.Append(OS, head + ".Slot", value.Slot);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out BagSlot value)
	{
		value = new BagSlot();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Bag);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Slot);
	}
}
public static class ItemSlotCountSerializer
{
	public static void Append(ViOStream OS, ItemSlotCount value)
	{
		ViGameSerializer<UInt16>.Append(OS, value.Slot);
		ViGameSerializer<Int16>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out ItemSlotCount value)
	{
		ViGameSerializer<UInt16>.Read(IS, out value.Slot);
		ViGameSerializer<Int16>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out ItemSlotCount value)
	{
		value = default(ItemSlotCount);
		if(ViGameSerializer<UInt16>.Read(IS, out value.Slot) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemSlotCount value)
	{
		ViGameSerializer<UInt16>.Append(OS, head + ".Slot", value.Slot);
		ViGameSerializer<Int16>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemSlotCount value)
	{
		value = new ItemSlotCount();
		ViGameSerializer<UInt16>.Read(IS, head, out value.Slot);
		ViGameSerializer<Int16>.Read(IS, head, out value.Count);
	}
}
public static class ItemScriptValuePropertyListSerializer
{
	public static void Append(ViOStream OS, ItemScriptValuePropertyList value)
	{
		ViGameSerializer<Int32>.Append(OS, value.E0);
		ViGameSerializer<Int32>.Append(OS, value.E1);
		ViGameSerializer<Int32>.Append(OS, value.E2);
		ViGameSerializer<Int32>.Append(OS, value.E3);
	}
	public static void Read(ViIStream IS, out ItemScriptValuePropertyList value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.E0);
		ViGameSerializer<Int32>.Read(IS, out value.E1);
		ViGameSerializer<Int32>.Read(IS, out value.E2);
		ViGameSerializer<Int32>.Read(IS, out value.E3);
	}
	public static bool Read(ViStringIStream IS, out ItemScriptValuePropertyList value)
	{
		value = default(ItemScriptValuePropertyList);
		if(ViGameSerializer<Int32>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E3) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemScriptValuePropertyList value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<Int32>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<Int32>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<Int32>.Append(OS, head + ".E3", value.E3);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemScriptValuePropertyList value)
	{
		value = new ItemScriptValuePropertyList();
		ViGameSerializer<Int32>.Read(IS, head, out value.E0);
		ViGameSerializer<Int32>.Read(IS, head, out value.E1);
		ViGameSerializer<Int32>.Read(IS, head, out value.E2);
		ViGameSerializer<Int32>.Read(IS, head, out value.E3);
	}
}
public static class EquipAttrSerializer
{
	public static void Append(ViOStream OS, EquipAttr value)
	{
		ViGameSerializer<Int32>.Append(OS, value.HPMax);
	}
	public static void Read(ViIStream IS, out EquipAttr value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.HPMax);
	}
	public static bool Read(ViStringIStream IS, out EquipAttr value)
	{
		value = default(EquipAttr);
		if(ViGameSerializer<Int32>.Read(IS, out value.HPMax) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, EquipAttr value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".HPMax", value.HPMax);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out EquipAttr value)
	{
		value = new EquipAttr();
		ViGameSerializer<Int32>.Read(IS, head, out value.HPMax);
	}
}
public static class ItemPropertySerializer
{
	public static void Append(ViOStream OS, ItemProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, value.Info);
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<BagSlot>.Append(OS, value.Slot);
		ViGameSerializer<Int64>.Append(OS, value.CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
		ViGameSerializer<Int64>.Append(OS, value.RecoverTime);
		ViGameSerializer<Int32>.Append(OS, value.StackCount);
		ViGameSerializer<UInt8>.Append(OS, value.Color);
		ViGameSerializer<Int16>.Append(OS, value.Durability);
		ViGameSerializer<ItemScriptValuePropertyList>.Append(OS, value.ScriptValues);
		ViGameSerializer<UInt16>.Append(OS, value.OperateMask0);
		ViGameSerializer<UInt16>.Append(OS, value.OperateMask1);
	}
	public static void Read(ViIStream IS, out ItemProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<BagSlot>.Read(IS, out value.Slot);
		ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
		ViGameSerializer<Int64>.Read(IS, out value.RecoverTime);
		ViGameSerializer<Int32>.Read(IS, out value.StackCount);
		ViGameSerializer<UInt8>.Read(IS, out value.Color);
		ViGameSerializer<Int16>.Read(IS, out value.Durability);
		ViGameSerializer<ItemScriptValuePropertyList>.Read(IS, out value.ScriptValues);
		ViGameSerializer<UInt16>.Read(IS, out value.OperateMask0);
		ViGameSerializer<UInt16>.Read(IS, out value.OperateMask1);
	}
	public static bool Read(ViStringIStream IS, out ItemProperty value)
	{
		value = default(ItemProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<BagSlot>.Read(IS, out value.Slot) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.RecoverTime) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.StackCount) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Color) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Durability) == false){return false;}
		if(ViGameSerializer<ItemScriptValuePropertyList>.Read(IS, out value.ScriptValues) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.OperateMask0) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.OperateMask1) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<BagSlot>.Append(OS, head + ".Slot", value.Slot);
		ViGameSerializer<Int64>.Append(OS, head + ".CreateTime1970", value.CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<Int64>.Append(OS, head + ".RecoverTime", value.RecoverTime);
		ViGameSerializer<Int32>.Append(OS, head + ".StackCount", value.StackCount);
		ViGameSerializer<UInt8>.Append(OS, head + ".Color", value.Color);
		ViGameSerializer<Int16>.Append(OS, head + ".Durability", value.Durability);
		ViGameSerializer<ItemScriptValuePropertyList>.Append(OS, head + ".ScriptValues", value.ScriptValues);
		ViGameSerializer<UInt16>.Append(OS, head + ".OperateMask0", value.OperateMask0);
		ViGameSerializer<UInt16>.Append(OS, head + ".OperateMask1", value.OperateMask1);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemProperty value)
	{
		value = new ItemProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<BagSlot>.Read(IS, head, out value.Slot);
		ViGameSerializer<Int64>.Read(IS, head, out value.CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.RecoverTime);
		ViGameSerializer<Int32>.Read(IS, head, out value.StackCount);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Color);
		ViGameSerializer<Int16>.Read(IS, head, out value.Durability);
		ViGameSerializer<ItemScriptValuePropertyList>.Read(IS, head, out value.ScriptValues);
		ViGameSerializer<UInt16>.Read(IS, head, out value.OperateMask0);
		ViGameSerializer<UInt16>.Read(IS, head, out value.OperateMask1);
	}
}
public static class ItemSaledPropertySerializer
{
	public static void Append(ViOStream OS, ItemSaledProperty value)
	{
		ViGameSerializer<ItemProperty>.Append(OS, value.Item);
		ViGameSerializer<Int64>.Append(OS, value.Time);
	}
	public static void Read(ViIStream IS, out ItemSaledProperty value)
	{
		ViGameSerializer<ItemProperty>.Read(IS, out value.Item);
		ViGameSerializer<Int64>.Read(IS, out value.Time);
	}
	public static bool Read(ViStringIStream IS, out ItemSaledProperty value)
	{
		value = default(ItemSaledProperty);
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.Item) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemSaledProperty value)
	{
		ViGameSerializer<ItemProperty>.Append(OS, head + ".Item", value.Item);
		ViGameSerializer<Int64>.Append(OS, head + ".Time", value.Time);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemSaledProperty value)
	{
		value = new ItemSaledProperty();
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.Item);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time);
	}
}
public static class ItemTransportPropertySerializer
{
	public static void Append(ViOStream OS, ItemTransportProperty value)
	{
		ViGameSerializer<UInt16>.Append(OS, value.From);
		ViGameSerializer<UInt16>.Append(OS, value.To);
		ViGameSerializer<Int16>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out ItemTransportProperty value)
	{
		ViGameSerializer<UInt16>.Read(IS, out value.From);
		ViGameSerializer<UInt16>.Read(IS, out value.To);
		ViGameSerializer<Int16>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out ItemTransportProperty value)
	{
		value = default(ItemTransportProperty);
		if(ViGameSerializer<UInt16>.Read(IS, out value.From) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.To) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemTransportProperty value)
	{
		ViGameSerializer<UInt16>.Append(OS, head + ".From", value.From);
		ViGameSerializer<UInt16>.Append(OS, head + ".To", value.To);
		ViGameSerializer<Int16>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemTransportProperty value)
	{
		value = new ItemTransportProperty();
		ViGameSerializer<UInt16>.Read(IS, head, out value.From);
		ViGameSerializer<UInt16>.Read(IS, head, out value.To);
		ViGameSerializer<Int16>.Read(IS, head, out value.Count);
	}
}
public static class PackageSlotPropertySerializer
{
	public static void Append(ViOStream OS, PackageSlotProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Item);
		ViGameSerializer<Int32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out PackageSlotProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Item);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out PackageSlotProperty value)
	{
		value = default(PackageSlotProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Item) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PackageSlotProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Item", value.Item);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PackageSlotProperty value)
	{
		value = new PackageSlotProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Item);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
	}
}
public static class ItemDelRecordPropertySerializer
{
	public static void Append(ViOStream OS, ItemDelRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Type);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ItemProperty>.Append(OS, value.Item);
	}
	public static void Read(ViIStream IS, out ItemDelRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Type);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ItemProperty>.Read(IS, out value.Item);
	}
	public static bool Read(ViStringIStream IS, out ItemDelRecordProperty value)
	{
		value = default(ItemDelRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.Item) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemDelRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".Item", value.Item);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemDelRecordProperty value)
	{
		value = new ItemDelRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Type);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.Item);
	}
}
public static class ItemDelCountPropertySerializer
{
	public static void Append(ViOStream OS, ItemDelCountProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Type);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out ItemDelCountProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Type);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out ItemDelCountProperty value)
	{
		value = default(ItemDelCountProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemDelCountProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemDelCountProperty value)
	{
		value = new ItemDelCountProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Type);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
	}
}
public static class ItemVersionPropertySerializer
{
	public static void Append(ViOStream OS, ItemVersionProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Version);
		ViGameSerializer<ItemProperty>.Append(OS, value.Item);
	}
	public static void Read(ViIStream IS, out ItemVersionProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Version);
		ViGameSerializer<ItemProperty>.Read(IS, out value.Item);
	}
	public static bool Read(ViStringIStream IS, out ItemVersionProperty value)
	{
		value = default(ItemVersionProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.Version) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.Item) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemVersionProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Version", value.Version);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".Item", value.Item);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemVersionProperty value)
	{
		value = new ItemVersionProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.Version);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.Item);
	}
}
public static class ItemLicenceRecordPropertySerializer
{
	public static void Append(ViOStream OS, ItemLicenceRecordProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Licence);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out ItemLicenceRecordProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Licence);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out ItemLicenceRecordProperty value)
	{
		value = default(ItemLicenceRecordProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Licence) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemLicenceRecordProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Licence", value.Licence);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemLicenceRecordProperty value)
	{
		value = new ItemLicenceRecordProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Licence);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
	}
}
public static class HeroEquipPropertySerializer
{
	public static void Append(ViOStream OS, HeroEquipProperty value)
	{
		ViGameSerializer<ItemProperty>.Append(OS, value.ItemInfo);
	}
	public static void Read(ViIStream IS, out HeroEquipProperty value)
	{
		ViGameSerializer<ItemProperty>.Read(IS, out value.ItemInfo);
	}
	public static bool Read(ViStringIStream IS, out HeroEquipProperty value)
	{
		value = default(HeroEquipProperty);
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.ItemInfo) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HeroEquipProperty value)
	{
		ViGameSerializer<ItemProperty>.Append(OS, head + ".ItemInfo", value.ItemInfo);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HeroEquipProperty value)
	{
		value = new HeroEquipProperty();
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.ItemInfo);
	}
}
public static class HeroEquipArrayPropertySerializer
{
	public static void Append(ViOStream OS, HeroEquipArrayProperty value)
	{
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E0);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E1);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E2);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E3);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E4);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E5);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E6);
		ViGameSerializer<HeroEquipProperty>.Append(OS, value.E7);
	}
	public static void Read(ViIStream IS, out HeroEquipArrayProperty value)
	{
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E0);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E1);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E2);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E3);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E4);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E5);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E6);
		ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E7);
	}
	public static bool Read(ViStringIStream IS, out HeroEquipArrayProperty value)
	{
		value = default(HeroEquipArrayProperty);
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E4) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E5) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E6) == false){return false;}
		if(ViGameSerializer<HeroEquipProperty>.Read(IS, out value.E7) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HeroEquipArrayProperty value)
	{
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E4", value.E4);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E5", value.E5);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E6", value.E6);
		ViGameSerializer<HeroEquipProperty>.Append(OS, head + ".E7", value.E7);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HeroEquipArrayProperty value)
	{
		value = new HeroEquipArrayProperty();
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E2);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E3);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E4);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E5);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E6);
		ViGameSerializer<HeroEquipProperty>.Read(IS, head, out value.E7);
	}
}
public static class MarketItemBuyRecordPropertySerializer
{
	public static void Append(ViOStream OS, MarketItemBuyRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Receiver);
		ViGameSerializer<UInt32>.Append(OS, value.Item);
		ViGameSerializer<Int32>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.Cost);
		ViGameSerializer<Int64>.Append(OS, value.ReserveMoney);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
	}
	public static void Read(ViIStream IS, out MarketItemBuyRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Receiver);
		ViGameSerializer<UInt32>.Read(IS, out value.Item);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.Cost);
		ViGameSerializer<Int64>.Read(IS, out value.ReserveMoney);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
	}
	public static bool Read(ViStringIStream IS, out MarketItemBuyRecordProperty value)
	{
		value = default(MarketItemBuyRecordProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Receiver) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Item) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Cost) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ReserveMoney) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MarketItemBuyRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Receiver", value.Receiver);
		ViGameSerializer<UInt32>.Append(OS, head + ".Item", value.Item);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".Cost", value.Cost);
		ViGameSerializer<Int64>.Append(OS, head + ".ReserveMoney", value.ReserveMoney);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MarketItemBuyRecordProperty value)
	{
		value = new MarketItemBuyRecordProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Receiver);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Item);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.Cost);
		ViGameSerializer<Int64>.Read(IS, head, out value.ReserveMoney);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
	}
}
public static class MarketSellItemPropertySerializer
{
	public static void Append(ViOStream OS, MarketSellItemProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.MarketItem);
		ViGameSerializer<Int64>.Append(OS, value.Price);
		ViGameSerializer<Int16>.Append(OS, value.MaxCount);
	}
	public static void Read(ViIStream IS, out MarketSellItemProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.MarketItem);
		ViGameSerializer<Int64>.Read(IS, out value.Price);
		ViGameSerializer<Int16>.Read(IS, out value.MaxCount);
	}
	public static bool Read(ViStringIStream IS, out MarketSellItemProperty value)
	{
		value = default(MarketSellItemProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.MarketItem) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Price) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.MaxCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MarketSellItemProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".MarketItem", value.MarketItem);
		ViGameSerializer<Int64>.Append(OS, head + ".Price", value.Price);
		ViGameSerializer<Int16>.Append(OS, head + ".MaxCount", value.MaxCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MarketSellItemProperty value)
	{
		value = new MarketSellItemProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.MarketItem);
		ViGameSerializer<Int64>.Read(IS, head, out value.Price);
		ViGameSerializer<Int16>.Read(IS, head, out value.MaxCount);
	}
}
public static class ShopItemBuyRecordPropertySerializer
{
	public static void Append(ViOStream OS, ShopItemBuyRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.ID);
		ViGameSerializer<Int32>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.Cost);
		ViGameSerializer<Int64>.Append(OS, value.ReserveMoney);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
	}
	public static void Read(ViIStream IS, out ShopItemBuyRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.ID);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.Cost);
		ViGameSerializer<Int64>.Read(IS, out value.ReserveMoney);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
	}
	public static bool Read(ViStringIStream IS, out ShopItemBuyRecordProperty value)
	{
		value = default(ShopItemBuyRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Cost) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ReserveMoney) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ShopItemBuyRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".Cost", value.Cost);
		ViGameSerializer<Int64>.Append(OS, head + ".ReserveMoney", value.ReserveMoney);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ShopItemBuyRecordProperty value)
	{
		value = new ShopItemBuyRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.ID);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.Cost);
		ViGameSerializer<Int64>.Read(IS, head, out value.ReserveMoney);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
	}
}
public static class ShopItemPropertySerializer
{
	public static void Append(ViOStream OS, ShopItemProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.ID);
		ViGameSerializer<Int64>.Append(OS, value.Price);
		ViGameSerializer<Int16>.Append(OS, value.ReserveCount);
	}
	public static void Read(ViIStream IS, out ShopItemProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.ID);
		ViGameSerializer<Int64>.Read(IS, out value.Price);
		ViGameSerializer<Int16>.Read(IS, out value.ReserveCount);
	}
	public static bool Read(ViStringIStream IS, out ShopItemProperty value)
	{
		value = default(ShopItemProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Price) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.ReserveCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ShopItemProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<Int64>.Append(OS, head + ".Price", value.Price);
		ViGameSerializer<Int16>.Append(OS, head + ".ReserveCount", value.ReserveCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ShopItemProperty value)
	{
		value = new ShopItemProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.ID);
		ViGameSerializer<Int64>.Read(IS, head, out value.Price);
		ViGameSerializer<Int16>.Read(IS, head, out value.ReserveCount);
	}
}
public static class ItemTradeRecordPropertySerializer
{
	public static void Append(ViOStream OS, ItemTradeRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.FromPlayer);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.ToPlayer);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<Int64>.Append(OS, value.Price);
		ViGameSerializer<ItemProperty>.Append(OS, value.ItemProperty);
	}
	public static void Read(ViIStream IS, out ItemTradeRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.FromPlayer);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.ToPlayer);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<Int64>.Read(IS, out value.Price);
		ViGameSerializer<ItemProperty>.Read(IS, out value.ItemProperty);
	}
	public static bool Read(ViStringIStream IS, out ItemTradeRecordProperty value)
	{
		value = default(ItemTradeRecordProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.FromPlayer) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.ToPlayer) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Price) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.ItemProperty) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemTradeRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".FromPlayer", value.FromPlayer);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".ToPlayer", value.ToPlayer);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<Int64>.Append(OS, head + ".Price", value.Price);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".ItemProperty", value.ItemProperty);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemTradeRecordProperty value)
	{
		value = new ItemTradeRecordProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.FromPlayer);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.ToPlayer);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.Price);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.ItemProperty);
	}
}
public static class ItemTradePropertySerializer
{
	public static void Append(ViOStream OS, ItemTradeProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ItemProperty>.Append(OS, value.ItemProperty);
		ViGameSerializer<Int64>.Append(OS, value.Price);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Player);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
		ViGameSerializer<Int64>.Append(OS, value.AuctionPrice);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Auctioner);
	}
	public static void Read(ViIStream IS, out ItemTradeProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ItemProperty>.Read(IS, out value.ItemProperty);
		ViGameSerializer<Int64>.Read(IS, out value.Price);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
		ViGameSerializer<Int64>.Read(IS, out value.AuctionPrice);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Auctioner);
	}
	public static bool Read(ViStringIStream IS, out ItemTradeProperty value)
	{
		value = default(ItemTradeProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.ItemProperty) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Price) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AuctionPrice) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Auctioner) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemTradeProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".ItemProperty", value.ItemProperty);
		ViGameSerializer<Int64>.Append(OS, head + ".Price", value.Price);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Player", value.Player);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<Int64>.Append(OS, head + ".AuctionPrice", value.AuctionPrice);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Auctioner", value.Auctioner);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemTradeProperty value)
	{
		value = new ItemTradeProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.ItemProperty);
		ViGameSerializer<Int64>.Read(IS, head, out value.Price);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Player);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.AuctionPrice);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Auctioner);
	}
}
public static class ItemTradeOfficialPricePropertySerializer
{
	public static void Append(ViOStream OS, ItemTradeOfficialPriceProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.Inf);
		ViGameSerializer<Int32>.Append(OS, value.Sup);
		ViGameSerializer<Int32>.Append(OS, value.Standard);
		ViGameSerializer<Int32>.Append(OS, value.Current);
	}
	public static void Read(ViIStream IS, out ItemTradeOfficialPriceProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.Inf);
		ViGameSerializer<Int32>.Read(IS, out value.Sup);
		ViGameSerializer<Int32>.Read(IS, out value.Standard);
		ViGameSerializer<Int32>.Read(IS, out value.Current);
	}
	public static bool Read(ViStringIStream IS, out ItemTradeOfficialPriceProperty value)
	{
		value = default(ItemTradeOfficialPriceProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.Inf) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Sup) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Standard) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Current) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemTradeOfficialPriceProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".Inf", value.Inf);
		ViGameSerializer<Int32>.Append(OS, head + ".Sup", value.Sup);
		ViGameSerializer<Int32>.Append(OS, head + ".Standard", value.Standard);
		ViGameSerializer<Int32>.Append(OS, head + ".Current", value.Current);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemTradeOfficialPriceProperty value)
	{
		value = new ItemTradeOfficialPriceProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.Inf);
		ViGameSerializer<Int32>.Read(IS, head, out value.Sup);
		ViGameSerializer<Int32>.Read(IS, head, out value.Standard);
		ViGameSerializer<Int32>.Read(IS, head, out value.Current);
	}
}
public static class MoneyPropertySerializer
{
	public static void Append(ViOStream OS, MoneyProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Type);
		ViGameSerializer<Int32>.Append(OS, value.Money);
	}
	public static void Read(ViIStream IS, out MoneyProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Type);
		ViGameSerializer<Int32>.Read(IS, out value.Money);
	}
	public static bool Read(ViStringIStream IS, out MoneyProperty value)
	{
		value = default(MoneyProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Money) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MoneyProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int32>.Append(OS, head + ".Money", value.Money);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MoneyProperty value)
	{
		value = new MoneyProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Type);
		ViGameSerializer<Int32>.Read(IS, head, out value.Money);
	}
}
public static class MoneyModRecordPropertySerializer
{
	public static void Append(ViOStream OS, MoneyModRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Type);
		ViGameSerializer<Int64>.Append(OS, value.FromMoney);
		ViGameSerializer<Int64>.Append(OS, value.ToMoney);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
	}
	public static void Read(ViIStream IS, out MoneyModRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Type);
		ViGameSerializer<Int64>.Read(IS, out value.FromMoney);
		ViGameSerializer<Int64>.Read(IS, out value.ToMoney);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
	}
	public static bool Read(ViStringIStream IS, out MoneyModRecordProperty value)
	{
		value = default(MoneyModRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.FromMoney) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ToMoney) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MoneyModRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int64>.Append(OS, head + ".FromMoney", value.FromMoney);
		ViGameSerializer<Int64>.Append(OS, head + ".ToMoney", value.ToMoney);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MoneyModRecordProperty value)
	{
		value = new MoneyModRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Type);
		ViGameSerializer<Int64>.Read(IS, head, out value.FromMoney);
		ViGameSerializer<Int64>.Read(IS, head, out value.ToMoney);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
	}
}
public static class ScriptDurationPropertySerializer
{
	public static void Append(ViOStream OS, ScriptDurationProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out ScriptDurationProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out ScriptDurationProperty value)
	{
		value = default(ScriptDurationProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ScriptDurationProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ScriptDurationProperty value)
	{
		value = new ScriptDurationProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class CreateRolePropertySerializer
{
	public static void Append(ViOStream OS, CreateRoleProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.NameAlias);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.FaceType);
		ViGameSerializer<UInt8>.Append(OS, value.HairType);
		ViGameSerializer<UInt8>.Append(OS, value.PlayerInitConfigID);
	}
	public static void Read(ViIStream IS, out CreateRoleProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.NameAlias);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.FaceType);
		ViGameSerializer<UInt8>.Read(IS, out value.HairType);
		ViGameSerializer<UInt8>.Read(IS, out value.PlayerInitConfigID);
	}
	public static bool Read(ViStringIStream IS, out CreateRoleProperty value)
	{
		value = default(CreateRoleProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.NameAlias) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FaceType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HairType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.PlayerInitConfigID) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, CreateRoleProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".NameAlias", value.NameAlias);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".FaceType", value.FaceType);
		ViGameSerializer<UInt8>.Append(OS, head + ".HairType", value.HairType);
		ViGameSerializer<UInt8>.Append(OS, head + ".PlayerInitConfigID", value.PlayerInitConfigID);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out CreateRoleProperty value)
	{
		value = new CreateRoleProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.NameAlias);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FaceType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HairType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.PlayerInitConfigID);
	}
}
public static class AccountRolePropertySerializer
{
	public static void Append(ViOStream OS, AccountRoleProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.FaceType);
		ViGameSerializer<UInt8>.Append(OS, value.HairType);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, value.HeroConfig);
		ViGameSerializer<HeroEquipArrayProperty>.Append(OS, value.EquipList);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out AccountRoleProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.FaceType);
		ViGameSerializer<UInt8>.Read(IS, out value.HairType);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.HeroConfig);
		ViGameSerializer<HeroEquipArrayProperty>.Read(IS, out value.EquipList);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out AccountRoleProperty value)
	{
		value = default(AccountRoleProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FaceType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HairType) == false){return false;}
		if(ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.HeroConfig) == false){return false;}
		if(ViGameSerializer<HeroEquipArrayProperty>.Read(IS, out value.EquipList) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, AccountRoleProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".FaceType", value.FaceType);
		ViGameSerializer<UInt8>.Append(OS, head + ".HairType", value.HairType);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, head + ".HeroConfig", value.HeroConfig);
		ViGameSerializer<HeroEquipArrayProperty>.Append(OS, head + ".EquipList", value.EquipList);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out AccountRoleProperty value)
	{
		value = new AccountRoleProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FaceType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HairType);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, head, out value.HeroConfig);
		ViGameSerializer<HeroEquipArrayProperty>.Read(IS, head, out value.EquipList);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class RechargePropertySerializer
{
	public static void Append(ViOStream OS, RechargeProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.OrderNo);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<Int64>.Append(OS, value.Money);
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out RechargeProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.OrderNo);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<Int64>.Read(IS, out value.Money);
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out RechargeProperty value)
	{
		value = default(RechargeProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.OrderNo) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Money) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, RechargeProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".OrderNo", value.OrderNo);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<Int64>.Append(OS, head + ".Money", value.Money);
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out RechargeProperty value)
	{
		value = new RechargeProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.OrderNo);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.Money);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class RechargeExecPropertySerializer
{
	public static void Append(ViOStream OS, RechargeExecProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.CreateTime1970);
		ViGameSerializer<Int32>.Append(OS, value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, value.ExecTime1970);
		ViGameSerializer<Int32>.Append(OS, value.ExecDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out RechargeExecProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970);
		ViGameSerializer<Int32>.Read(IS, out value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, out value.ExecTime1970);
		ViGameSerializer<Int32>.Read(IS, out value.ExecDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out RechargeExecProperty value)
	{
		value = default(RechargeExecProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CreateDayNumber1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ExecTime1970) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ExecDayNumber1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, RechargeExecProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".CreateTime1970", value.CreateTime1970);
		ViGameSerializer<Int32>.Append(OS, head + ".CreateDayNumber1970", value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, head + ".ExecTime1970", value.ExecTime1970);
		ViGameSerializer<Int32>.Append(OS, head + ".ExecDayNumber1970", value.ExecDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out RechargeExecProperty value)
	{
		value = new RechargeExecProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.CreateTime1970);
		ViGameSerializer<Int32>.Read(IS, head, out value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.ExecTime1970);
		ViGameSerializer<Int32>.Read(IS, head, out value.ExecDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class HTTPGiftPropertySerializer
{
	public static void Append(ViOStream OS, HTTPGiftProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.OrderNo);
		ViGameSerializer<Int64>.Append(OS, value.CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, value.ExecTime1970);
		ViGameSerializer<Int32>.Append(OS, value.Gift);
	}
	public static void Read(ViIStream IS, out HTTPGiftProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.OrderNo);
		ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.ExecTime1970);
		ViGameSerializer<Int32>.Read(IS, out value.Gift);
	}
	public static bool Read(ViStringIStream IS, out HTTPGiftProperty value)
	{
		value = default(HTTPGiftProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.OrderNo) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ExecTime1970) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Gift) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HTTPGiftProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".OrderNo", value.OrderNo);
		ViGameSerializer<Int64>.Append(OS, head + ".CreateTime1970", value.CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".ExecTime1970", value.ExecTime1970);
		ViGameSerializer<Int32>.Append(OS, head + ".Gift", value.Gift);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HTTPGiftProperty value)
	{
		value = new HTTPGiftProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.OrderNo);
		ViGameSerializer<Int64>.Read(IS, head, out value.CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.ExecTime1970);
		ViGameSerializer<Int32>.Read(IS, head, out value.Gift);
	}
}
public static class GameUnitIndexPropertySerializer
{
	public static void Append(ViOStream OS, GameUnitIndexProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.HPMax0);
		ViGameSerializer<Int32>.Append(OS, value.HPMax1);
		ViGameSerializer<Int32>.Append(OS, value.HPMax2);
		ViGameSerializer<Int32>.Append(OS, value.MPMax0);
		ViGameSerializer<Int32>.Append(OS, value.MPMax1);
		ViGameSerializer<Int32>.Append(OS, value.MPMax2);
		ViGameSerializer<Int32>.Append(OS, value.SPMax0);
		ViGameSerializer<Int32>.Append(OS, value.SPMax1);
		ViGameSerializer<Int32>.Append(OS, value.SPMax2);
		ViGameSerializer<Int32>.Append(OS, value.HPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, value.HPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, value.HPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, value.MPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, value.MPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, value.MPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, value.SPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, value.SPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, value.SPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, value.PhysicsAttack0);
		ViGameSerializer<Int32>.Append(OS, value.PhysicsAttack1);
		ViGameSerializer<Int32>.Append(OS, value.PhysicsAttack2);
		ViGameSerializer<Int32>.Append(OS, value.PhysicsDefence0);
		ViGameSerializer<Int32>.Append(OS, value.PhysicsDefence1);
		ViGameSerializer<Int32>.Append(OS, value.PhysicsDefence2);
		ViGameSerializer<Int32>.Append(OS, value.MagicAttack0);
		ViGameSerializer<Int32>.Append(OS, value.MagicAttack1);
		ViGameSerializer<Int32>.Append(OS, value.MagicAttack2);
		ViGameSerializer<Int32>.Append(OS, value.MagicDefence0);
		ViGameSerializer<Int32>.Append(OS, value.MagicDefence1);
		ViGameSerializer<Int32>.Append(OS, value.MagicDefence2);
		ViGameSerializer<Int32>.Append(OS, value.MoveSpeed0);
		ViGameSerializer<Int32>.Append(OS, value.MoveSpeed1);
		ViGameSerializer<Int32>.Append(OS, value.MoveSpeed2);
		ViGameSerializer<Int32>.Append(OS, value.CriticalHit0);
		ViGameSerializer<Int32>.Append(OS, value.CriticalHit1);
		ViGameSerializer<Int32>.Append(OS, value.CriticalHit2);
		ViGameSerializer<Int32>.Append(OS, value.CriticalMiss0);
		ViGameSerializer<Int32>.Append(OS, value.CriticalMiss1);
		ViGameSerializer<Int32>.Append(OS, value.CriticalMiss2);
		ViGameSerializer<Int32>.Append(OS, value.CriticalHitRate0);
		ViGameSerializer<Int32>.Append(OS, value.CriticalHitRate1);
		ViGameSerializer<Int32>.Append(OS, value.CriticalHitRate2);
		ViGameSerializer<Int32>.Append(OS, value.CriticalMissRate0);
		ViGameSerializer<Int32>.Append(OS, value.CriticalMissRate1);
		ViGameSerializer<Int32>.Append(OS, value.CriticalMissRate2);
		ViGameSerializer<Int32>.Append(OS, value.CriticalDamageAttack0);
		ViGameSerializer<Int32>.Append(OS, value.CriticalDamageAttack1);
		ViGameSerializer<Int32>.Append(OS, value.CriticalDamageAttack2);
		ViGameSerializer<Int32>.Append(OS, value.CriticalDamageDefence0);
		ViGameSerializer<Int32>.Append(OS, value.CriticalDamageDefence1);
		ViGameSerializer<Int32>.Append(OS, value.CriticalDamageDefence2);
		ViGameSerializer<Int32>.Append(OS, value.Penetrate0);
		ViGameSerializer<Int32>.Append(OS, value.Penetrate1);
		ViGameSerializer<Int32>.Append(OS, value.Penetrate2);
		ViGameSerializer<Int32>.Append(OS, value.AttackVampire0);
		ViGameSerializer<Int32>.Append(OS, value.AttackVampire1);
		ViGameSerializer<Int32>.Append(OS, value.AttackVampire2);
		ViGameSerializer<Int32>.Append(OS, value.AttackSpeedMultiply0);
		ViGameSerializer<Int32>.Append(OS, value.AttackSpeedMultiply1);
		ViGameSerializer<Int32>.Append(OS, value.AttackSpeedMultiply2);
	}
	public static void Read(ViIStream IS, out GameUnitIndexProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.HPMax0);
		ViGameSerializer<Int32>.Read(IS, out value.HPMax1);
		ViGameSerializer<Int32>.Read(IS, out value.HPMax2);
		ViGameSerializer<Int32>.Read(IS, out value.MPMax0);
		ViGameSerializer<Int32>.Read(IS, out value.MPMax1);
		ViGameSerializer<Int32>.Read(IS, out value.MPMax2);
		ViGameSerializer<Int32>.Read(IS, out value.SPMax0);
		ViGameSerializer<Int32>.Read(IS, out value.SPMax1);
		ViGameSerializer<Int32>.Read(IS, out value.SPMax2);
		ViGameSerializer<Int32>.Read(IS, out value.HPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, out value.HPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, out value.HPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, out value.MPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, out value.MPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, out value.MPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, out value.SPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, out value.SPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, out value.SPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, out value.PhysicsAttack0);
		ViGameSerializer<Int32>.Read(IS, out value.PhysicsAttack1);
		ViGameSerializer<Int32>.Read(IS, out value.PhysicsAttack2);
		ViGameSerializer<Int32>.Read(IS, out value.PhysicsDefence0);
		ViGameSerializer<Int32>.Read(IS, out value.PhysicsDefence1);
		ViGameSerializer<Int32>.Read(IS, out value.PhysicsDefence2);
		ViGameSerializer<Int32>.Read(IS, out value.MagicAttack0);
		ViGameSerializer<Int32>.Read(IS, out value.MagicAttack1);
		ViGameSerializer<Int32>.Read(IS, out value.MagicAttack2);
		ViGameSerializer<Int32>.Read(IS, out value.MagicDefence0);
		ViGameSerializer<Int32>.Read(IS, out value.MagicDefence1);
		ViGameSerializer<Int32>.Read(IS, out value.MagicDefence2);
		ViGameSerializer<Int32>.Read(IS, out value.MoveSpeed0);
		ViGameSerializer<Int32>.Read(IS, out value.MoveSpeed1);
		ViGameSerializer<Int32>.Read(IS, out value.MoveSpeed2);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalHit0);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalHit1);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalHit2);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalMiss0);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalMiss1);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalMiss2);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalHitRate0);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalHitRate1);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalHitRate2);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalMissRate0);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalMissRate1);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalMissRate2);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageAttack0);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageAttack1);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageAttack2);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageDefence0);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageDefence1);
		ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageDefence2);
		ViGameSerializer<Int32>.Read(IS, out value.Penetrate0);
		ViGameSerializer<Int32>.Read(IS, out value.Penetrate1);
		ViGameSerializer<Int32>.Read(IS, out value.Penetrate2);
		ViGameSerializer<Int32>.Read(IS, out value.AttackVampire0);
		ViGameSerializer<Int32>.Read(IS, out value.AttackVampire1);
		ViGameSerializer<Int32>.Read(IS, out value.AttackVampire2);
		ViGameSerializer<Int32>.Read(IS, out value.AttackSpeedMultiply0);
		ViGameSerializer<Int32>.Read(IS, out value.AttackSpeedMultiply1);
		ViGameSerializer<Int32>.Read(IS, out value.AttackSpeedMultiply2);
	}
	public static bool Read(ViStringIStream IS, out GameUnitIndexProperty value)
	{
		value = default(GameUnitIndexProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.HPMax0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HPMax1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HPMax2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MPMax0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MPMax1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MPMax2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SPMax0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SPMax1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SPMax2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HPRegenerate0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HPRegenerate1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HPRegenerate2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MPRegenerate0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MPRegenerate1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MPRegenerate2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SPRegenerate0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SPRegenerate1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SPRegenerate2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PhysicsAttack0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PhysicsAttack1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PhysicsAttack2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PhysicsDefence0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PhysicsDefence1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PhysicsDefence2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MagicAttack0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MagicAttack1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MagicAttack2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MagicDefence0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MagicDefence1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MagicDefence2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MoveSpeed0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MoveSpeed1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MoveSpeed2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalHit0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalHit1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalHit2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalMiss0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalMiss1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalMiss2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalHitRate0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalHitRate1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalHitRate2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalMissRate0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalMissRate1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalMissRate2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageAttack0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageAttack1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageAttack2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageDefence0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageDefence1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.CriticalDamageDefence2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Penetrate0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Penetrate1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Penetrate2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AttackVampire0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AttackVampire1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AttackVampire2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AttackSpeedMultiply0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AttackSpeedMultiply1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AttackSpeedMultiply2) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GameUnitIndexProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".HPMax0", value.HPMax0);
		ViGameSerializer<Int32>.Append(OS, head + ".HPMax1", value.HPMax1);
		ViGameSerializer<Int32>.Append(OS, head + ".HPMax2", value.HPMax2);
		ViGameSerializer<Int32>.Append(OS, head + ".MPMax0", value.MPMax0);
		ViGameSerializer<Int32>.Append(OS, head + ".MPMax1", value.MPMax1);
		ViGameSerializer<Int32>.Append(OS, head + ".MPMax2", value.MPMax2);
		ViGameSerializer<Int32>.Append(OS, head + ".SPMax0", value.SPMax0);
		ViGameSerializer<Int32>.Append(OS, head + ".SPMax1", value.SPMax1);
		ViGameSerializer<Int32>.Append(OS, head + ".SPMax2", value.SPMax2);
		ViGameSerializer<Int32>.Append(OS, head + ".HPRegenerate0", value.HPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, head + ".HPRegenerate1", value.HPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, head + ".HPRegenerate2", value.HPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, head + ".MPRegenerate0", value.MPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, head + ".MPRegenerate1", value.MPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, head + ".MPRegenerate2", value.MPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, head + ".SPRegenerate0", value.SPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, head + ".SPRegenerate1", value.SPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, head + ".SPRegenerate2", value.SPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, head + ".PhysicsAttack0", value.PhysicsAttack0);
		ViGameSerializer<Int32>.Append(OS, head + ".PhysicsAttack1", value.PhysicsAttack1);
		ViGameSerializer<Int32>.Append(OS, head + ".PhysicsAttack2", value.PhysicsAttack2);
		ViGameSerializer<Int32>.Append(OS, head + ".PhysicsDefence0", value.PhysicsDefence0);
		ViGameSerializer<Int32>.Append(OS, head + ".PhysicsDefence1", value.PhysicsDefence1);
		ViGameSerializer<Int32>.Append(OS, head + ".PhysicsDefence2", value.PhysicsDefence2);
		ViGameSerializer<Int32>.Append(OS, head + ".MagicAttack0", value.MagicAttack0);
		ViGameSerializer<Int32>.Append(OS, head + ".MagicAttack1", value.MagicAttack1);
		ViGameSerializer<Int32>.Append(OS, head + ".MagicAttack2", value.MagicAttack2);
		ViGameSerializer<Int32>.Append(OS, head + ".MagicDefence0", value.MagicDefence0);
		ViGameSerializer<Int32>.Append(OS, head + ".MagicDefence1", value.MagicDefence1);
		ViGameSerializer<Int32>.Append(OS, head + ".MagicDefence2", value.MagicDefence2);
		ViGameSerializer<Int32>.Append(OS, head + ".MoveSpeed0", value.MoveSpeed0);
		ViGameSerializer<Int32>.Append(OS, head + ".MoveSpeed1", value.MoveSpeed1);
		ViGameSerializer<Int32>.Append(OS, head + ".MoveSpeed2", value.MoveSpeed2);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalHit0", value.CriticalHit0);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalHit1", value.CriticalHit1);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalHit2", value.CriticalHit2);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalMiss0", value.CriticalMiss0);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalMiss1", value.CriticalMiss1);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalMiss2", value.CriticalMiss2);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalHitRate0", value.CriticalHitRate0);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalHitRate1", value.CriticalHitRate1);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalHitRate2", value.CriticalHitRate2);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalMissRate0", value.CriticalMissRate0);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalMissRate1", value.CriticalMissRate1);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalMissRate2", value.CriticalMissRate2);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalDamageAttack0", value.CriticalDamageAttack0);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalDamageAttack1", value.CriticalDamageAttack1);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalDamageAttack2", value.CriticalDamageAttack2);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalDamageDefence0", value.CriticalDamageDefence0);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalDamageDefence1", value.CriticalDamageDefence1);
		ViGameSerializer<Int32>.Append(OS, head + ".CriticalDamageDefence2", value.CriticalDamageDefence2);
		ViGameSerializer<Int32>.Append(OS, head + ".Penetrate0", value.Penetrate0);
		ViGameSerializer<Int32>.Append(OS, head + ".Penetrate1", value.Penetrate1);
		ViGameSerializer<Int32>.Append(OS, head + ".Penetrate2", value.Penetrate2);
		ViGameSerializer<Int32>.Append(OS, head + ".AttackVampire0", value.AttackVampire0);
		ViGameSerializer<Int32>.Append(OS, head + ".AttackVampire1", value.AttackVampire1);
		ViGameSerializer<Int32>.Append(OS, head + ".AttackVampire2", value.AttackVampire2);
		ViGameSerializer<Int32>.Append(OS, head + ".AttackSpeedMultiply0", value.AttackSpeedMultiply0);
		ViGameSerializer<Int32>.Append(OS, head + ".AttackSpeedMultiply1", value.AttackSpeedMultiply1);
		ViGameSerializer<Int32>.Append(OS, head + ".AttackSpeedMultiply2", value.AttackSpeedMultiply2);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GameUnitIndexProperty value)
	{
		value = new GameUnitIndexProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.HPMax0);
		ViGameSerializer<Int32>.Read(IS, head, out value.HPMax1);
		ViGameSerializer<Int32>.Read(IS, head, out value.HPMax2);
		ViGameSerializer<Int32>.Read(IS, head, out value.MPMax0);
		ViGameSerializer<Int32>.Read(IS, head, out value.MPMax1);
		ViGameSerializer<Int32>.Read(IS, head, out value.MPMax2);
		ViGameSerializer<Int32>.Read(IS, head, out value.SPMax0);
		ViGameSerializer<Int32>.Read(IS, head, out value.SPMax1);
		ViGameSerializer<Int32>.Read(IS, head, out value.SPMax2);
		ViGameSerializer<Int32>.Read(IS, head, out value.HPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, head, out value.HPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, head, out value.HPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, head, out value.MPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, head, out value.MPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, head, out value.MPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, head, out value.SPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, head, out value.SPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, head, out value.SPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, head, out value.PhysicsAttack0);
		ViGameSerializer<Int32>.Read(IS, head, out value.PhysicsAttack1);
		ViGameSerializer<Int32>.Read(IS, head, out value.PhysicsAttack2);
		ViGameSerializer<Int32>.Read(IS, head, out value.PhysicsDefence0);
		ViGameSerializer<Int32>.Read(IS, head, out value.PhysicsDefence1);
		ViGameSerializer<Int32>.Read(IS, head, out value.PhysicsDefence2);
		ViGameSerializer<Int32>.Read(IS, head, out value.MagicAttack0);
		ViGameSerializer<Int32>.Read(IS, head, out value.MagicAttack1);
		ViGameSerializer<Int32>.Read(IS, head, out value.MagicAttack2);
		ViGameSerializer<Int32>.Read(IS, head, out value.MagicDefence0);
		ViGameSerializer<Int32>.Read(IS, head, out value.MagicDefence1);
		ViGameSerializer<Int32>.Read(IS, head, out value.MagicDefence2);
		ViGameSerializer<Int32>.Read(IS, head, out value.MoveSpeed0);
		ViGameSerializer<Int32>.Read(IS, head, out value.MoveSpeed1);
		ViGameSerializer<Int32>.Read(IS, head, out value.MoveSpeed2);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalHit0);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalHit1);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalHit2);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalMiss0);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalMiss1);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalMiss2);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalHitRate0);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalHitRate1);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalHitRate2);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalMissRate0);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalMissRate1);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalMissRate2);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalDamageAttack0);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalDamageAttack1);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalDamageAttack2);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalDamageDefence0);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalDamageDefence1);
		ViGameSerializer<Int32>.Read(IS, head, out value.CriticalDamageDefence2);
		ViGameSerializer<Int32>.Read(IS, head, out value.Penetrate0);
		ViGameSerializer<Int32>.Read(IS, head, out value.Penetrate1);
		ViGameSerializer<Int32>.Read(IS, head, out value.Penetrate2);
		ViGameSerializer<Int32>.Read(IS, head, out value.AttackVampire0);
		ViGameSerializer<Int32>.Read(IS, head, out value.AttackVampire1);
		ViGameSerializer<Int32>.Read(IS, head, out value.AttackVampire2);
		ViGameSerializer<Int32>.Read(IS, head, out value.AttackSpeedMultiply0);
		ViGameSerializer<Int32>.Read(IS, head, out value.AttackSpeedMultiply1);
		ViGameSerializer<Int32>.Read(IS, head, out value.AttackSpeedMultiply2);
	}
}
public static class HeroSpellPropertySerializer
{
	public static void Append(ViOStream OS, HeroSpellProperty value)
	{
		ViGameSerializer<ViForeignKey<OwnSpellStruct>>.Append(OS, value.Info);
		ViGameSerializer<ViForeignKey<ViSpellStruct>>.Append(OS, value.WorkingInfo);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int32>.Append(OS, value.LevelValue);
		ViGameSerializer<Int16>.Append(OS, value.SetupIdx);
	}
	public static void Read(ViIStream IS, out HeroSpellProperty value)
	{
		ViGameSerializer<ViForeignKey<OwnSpellStruct>>.Read(IS, out value.Info);
		ViGameSerializer<ViForeignKey<ViSpellStruct>>.Read(IS, out value.WorkingInfo);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int32>.Read(IS, out value.LevelValue);
		ViGameSerializer<Int16>.Read(IS, out value.SetupIdx);
	}
	public static bool Read(ViStringIStream IS, out HeroSpellProperty value)
	{
		value = default(HeroSpellProperty);
		if(ViGameSerializer<ViForeignKey<OwnSpellStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<ViForeignKey<ViSpellStruct>>.Read(IS, out value.WorkingInfo) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.LevelValue) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.SetupIdx) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HeroSpellProperty value)
	{
		ViGameSerializer<ViForeignKey<OwnSpellStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<ViForeignKey<ViSpellStruct>>.Append(OS, head + ".WorkingInfo", value.WorkingInfo);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int32>.Append(OS, head + ".LevelValue", value.LevelValue);
		ViGameSerializer<Int16>.Append(OS, head + ".SetupIdx", value.SetupIdx);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HeroSpellProperty value)
	{
		value = new HeroSpellProperty();
		ViGameSerializer<ViForeignKey<OwnSpellStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<ViForeignKey<ViSpellStruct>>.Read(IS, head, out value.WorkingInfo);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int32>.Read(IS, head, out value.LevelValue);
		ViGameSerializer<Int16>.Read(IS, head, out value.SetupIdx);
	}
}
public static class HeroSpellArrayPropertySerializer
{
	public static void Append(ViOStream OS, HeroSpellArrayProperty value)
	{
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E0);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E1);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E2);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E3);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E4);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E5);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E6);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E7);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E8);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.E9);
	}
	public static void Read(ViIStream IS, out HeroSpellArrayProperty value)
	{
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E0);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E1);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E2);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E3);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E4);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E5);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E6);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E7);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E8);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E9);
	}
	public static bool Read(ViStringIStream IS, out HeroSpellArrayProperty value)
	{
		value = default(HeroSpellArrayProperty);
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E4) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E5) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E6) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E7) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E8) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.E9) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HeroSpellArrayProperty value)
	{
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E4", value.E4);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E5", value.E5);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E6", value.E6);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E7", value.E7);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E8", value.E8);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".E9", value.E9);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HeroSpellArrayProperty value)
	{
		value = new HeroSpellArrayProperty();
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E2);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E3);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E4);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E5);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E6);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E7);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E8);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.E9);
	}
}
public static class HeroPropertySerializer
{
	public static void Append(ViOStream OS, HeroProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Note);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int64>.Append(OS, value.XP);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<HeroSpellArrayProperty>.Append(OS, value.SpellList);
		ViGameSerializer<HeroEquipArrayProperty>.Append(OS, value.EquipList);
		ViGameSerializer<UInt8>.Append(OS, value.FaceType);
		ViGameSerializer<UInt8>.Append(OS, value.HairType);
	}
	public static void Read(ViIStream IS, out HeroProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Note);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int64>.Read(IS, out value.XP);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<HeroSpellArrayProperty>.Read(IS, out value.SpellList);
		ViGameSerializer<HeroEquipArrayProperty>.Read(IS, out value.EquipList);
		ViGameSerializer<UInt8>.Read(IS, out value.FaceType);
		ViGameSerializer<UInt8>.Read(IS, out value.HairType);
	}
	public static bool Read(ViStringIStream IS, out HeroProperty value)
	{
		value = default(HeroProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Note) == false){return false;}
		if(ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.XP) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<HeroSpellArrayProperty>.Read(IS, out value.SpellList) == false){return false;}
		if(ViGameSerializer<HeroEquipArrayProperty>.Read(IS, out value.EquipList) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FaceType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HairType) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HeroProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Note", value.Note);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int64>.Append(OS, head + ".XP", value.XP);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<HeroSpellArrayProperty>.Append(OS, head + ".SpellList", value.SpellList);
		ViGameSerializer<HeroEquipArrayProperty>.Append(OS, head + ".EquipList", value.EquipList);
		ViGameSerializer<UInt8>.Append(OS, head + ".FaceType", value.FaceType);
		ViGameSerializer<UInt8>.Append(OS, head + ".HairType", value.HairType);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HeroProperty value)
	{
		value = new HeroProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Note);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int64>.Read(IS, head, out value.XP);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<HeroSpellArrayProperty>.Read(IS, head, out value.SpellList);
		ViGameSerializer<HeroEquipArrayProperty>.Read(IS, head, out value.EquipList);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FaceType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HairType);
	}
}
public static class HeroWorkingPropertySerializer
{
	public static void Append(ViOStream OS, HeroWorkingProperty value)
	{
		ViGameSerializer<HeroProperty>.Append(OS, value.Property);
		ViGameSerializer<HeroSpellProperty>.Append(OS, value.StudySpellList);
		ViGameSerializer<GameUnitIndexProperty>.Append(OS, value.IndexProperty);
		ViGameSerializer<Int32>.Append(OS, value.HP);
		ViGameSerializer<Int8>.Append(OS, value.HPPerc);
		ViGameSerializer<Int32>.Append(OS, value.MP);
		ViGameSerializer<Int32>.Append(OS, value.SP);
		ViGameSerializer<UInt32>.Append(OS, value.ActionStateMask);
		ViGameSerializer<UInt32>.Append(OS, value.AuraStateMask);
		ViGameSerializer<Int64>.Append(OS, value.CDEndTime);
	}
	public static void Read(ViIStream IS, out HeroWorkingProperty value)
	{
		ViGameSerializer<HeroProperty>.Read(IS, out value.Property);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out value.StudySpellList);
		ViGameSerializer<GameUnitIndexProperty>.Read(IS, out value.IndexProperty);
		ViGameSerializer<Int32>.Read(IS, out value.HP);
		ViGameSerializer<Int8>.Read(IS, out value.HPPerc);
		ViGameSerializer<Int32>.Read(IS, out value.MP);
		ViGameSerializer<Int32>.Read(IS, out value.SP);
		ViGameSerializer<UInt32>.Read(IS, out value.ActionStateMask);
		ViGameSerializer<UInt32>.Read(IS, out value.AuraStateMask);
		ViGameSerializer<Int64>.Read(IS, out value.CDEndTime);
	}
	public static bool Read(ViStringIStream IS, out HeroWorkingProperty value)
	{
		value = default(HeroWorkingProperty);
		if(ViGameSerializer<HeroProperty>.Read(IS, out value.Property) == false){return false;}
		if(ViGameSerializer<HeroSpellProperty>.Read(IS, out value.StudySpellList) == false){return false;}
		if(ViGameSerializer<GameUnitIndexProperty>.Read(IS, out value.IndexProperty) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HP) == false){return false;}
		if(ViGameSerializer<Int8>.Read(IS, out value.HPPerc) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MP) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SP) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.ActionStateMask) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.AuraStateMask) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CDEndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, HeroWorkingProperty value)
	{
		ViGameSerializer<HeroProperty>.Append(OS, head + ".Property", value.Property);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + ".StudySpellList", value.StudySpellList);
		ViGameSerializer<GameUnitIndexProperty>.Append(OS, head + ".IndexProperty", value.IndexProperty);
		ViGameSerializer<Int32>.Append(OS, head + ".HP", value.HP);
		ViGameSerializer<Int8>.Append(OS, head + ".HPPerc", value.HPPerc);
		ViGameSerializer<Int32>.Append(OS, head + ".MP", value.MP);
		ViGameSerializer<Int32>.Append(OS, head + ".SP", value.SP);
		ViGameSerializer<UInt32>.Append(OS, head + ".ActionStateMask", value.ActionStateMask);
		ViGameSerializer<UInt32>.Append(OS, head + ".AuraStateMask", value.AuraStateMask);
		ViGameSerializer<Int64>.Append(OS, head + ".CDEndTime", value.CDEndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out HeroWorkingProperty value)
	{
		value = new HeroWorkingProperty();
		ViGameSerializer<HeroProperty>.Read(IS, head, out value.Property);
		ViGameSerializer<HeroSpellProperty>.Read(IS, head, out value.StudySpellList);
		ViGameSerializer<GameUnitIndexProperty>.Read(IS, head, out value.IndexProperty);
		ViGameSerializer<Int32>.Read(IS, head, out value.HP);
		ViGameSerializer<Int8>.Read(IS, head, out value.HPPerc);
		ViGameSerializer<Int32>.Read(IS, head, out value.MP);
		ViGameSerializer<Int32>.Read(IS, head, out value.SP);
		ViGameSerializer<UInt32>.Read(IS, head, out value.ActionStateMask);
		ViGameSerializer<UInt32>.Read(IS, head, out value.AuraStateMask);
		ViGameSerializer<Int64>.Read(IS, head, out value.CDEndTime);
	}
}
public static class SpaceRecordPropertySerializer
{
	public static void Append(ViOStream OS, SpaceRecordProperty value)
	{
		ViGameSerializer<Int8>.Append(OS, value.Score);
		ViGameSerializer<Int32>.Append(OS, value.WinCount);
		ViGameSerializer<Int32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out SpaceRecordProperty value)
	{
		ViGameSerializer<Int8>.Read(IS, out value.Score);
		ViGameSerializer<Int32>.Read(IS, out value.WinCount);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out SpaceRecordProperty value)
	{
		value = default(SpaceRecordProperty);
		if(ViGameSerializer<Int8>.Read(IS, out value.Score) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WinCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceRecordProperty value)
	{
		ViGameSerializer<Int8>.Append(OS, head + ".Score", value.Score);
		ViGameSerializer<Int32>.Append(OS, head + ".WinCount", value.WinCount);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceRecordProperty value)
	{
		value = new SpaceRecordProperty();
		ViGameSerializer<Int8>.Read(IS, head, out value.Score);
		ViGameSerializer<Int32>.Read(IS, head, out value.WinCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
	}
}
public static class SpaceImmediateCompletePropertySerializer
{
	public static void Append(ViOStream OS, SpaceImmediateCompleteProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out SpaceImmediateCompleteProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out SpaceImmediateCompleteProperty value)
	{
		value = default(SpaceImmediateCompleteProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceImmediateCompleteProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceImmediateCompleteProperty value)
	{
		value = new SpaceImmediateCompleteProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class SpaceBirthControllerPropertySerializer
{
	public static void Append(ViOStream OS, SpaceBirthControllerProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int16>.Append(OS, value.ReserveCount);
		ViGameSerializer<ViVector3>.Append(OS, value.Position);
		ViGameSerializer<UInt8>.Append(OS, value.Faction);
		ViGameSerializer<Int64>.Append(OS, value.FactionStartTime);
		ViGameSerializer<UInt64Property>.Append(OS, value.Team);
		ViGameSerializer<Int16>.Append(OS, value.Level);
	}
	public static void Read(ViIStream IS, out SpaceBirthControllerProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int16>.Read(IS, out value.ReserveCount);
		ViGameSerializer<ViVector3>.Read(IS, out value.Position);
		ViGameSerializer<UInt8>.Read(IS, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, out value.FactionStartTime);
		ViGameSerializer<UInt64Property>.Read(IS, out value.Team);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
	}
	public static bool Read(ViStringIStream IS, out SpaceBirthControllerProperty value)
	{
		value = default(SpaceBirthControllerProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.ReserveCount) == false){return false;}
		if(ViGameSerializer<ViVector3>.Read(IS, out value.Position) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Faction) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.FactionStartTime) == false){return false;}
		if(ViGameSerializer<UInt64Property>.Read(IS, out value.Team) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceBirthControllerProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int16>.Append(OS, head + ".ReserveCount", value.ReserveCount);
		ViGameSerializer<ViVector3>.Append(OS, head + ".Position", value.Position);
		ViGameSerializer<UInt8>.Append(OS, head + ".Faction", value.Faction);
		ViGameSerializer<Int64>.Append(OS, head + ".FactionStartTime", value.FactionStartTime);
		ViGameSerializer<UInt64Property>.Append(OS, head + ".Team", value.Team);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceBirthControllerProperty value)
	{
		value = new SpaceBirthControllerProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int16>.Read(IS, head, out value.ReserveCount);
		ViGameSerializer<ViVector3>.Read(IS, head, out value.Position);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, head, out value.FactionStartTime);
		ViGameSerializer<UInt64Property>.Read(IS, head, out value.Team);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
	}
}
public static class SpaceBirthControllerShowPropertySerializer
{
	public static void Append(ViOStream OS, SpaceBirthControllerShowProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Show);
		ViGameSerializer<ViVector3>.Append(OS, value.Position);
	}
	public static void Read(ViIStream IS, out SpaceBirthControllerShowProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Show);
		ViGameSerializer<ViVector3>.Read(IS, out value.Position);
	}
	public static bool Read(ViStringIStream IS, out SpaceBirthControllerShowProperty value)
	{
		value = default(SpaceBirthControllerShowProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Show) == false){return false;}
		if(ViGameSerializer<ViVector3>.Read(IS, out value.Position) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceBirthControllerShowProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Show", value.Show);
		ViGameSerializer<ViVector3>.Append(OS, head + ".Position", value.Position);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceBirthControllerShowProperty value)
	{
		value = new SpaceBirthControllerShowProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Show);
		ViGameSerializer<ViVector3>.Read(IS, head, out value.Position);
	}
}
public static class SpaceEventCachePropertySerializer
{
	public static void Append(ViOStream OS, SpaceEventCacheProperty value)
	{
		ViGameSerializer<ViForeignKey<SpaceEventStruct>>.Append(OS, value.Info);
		ViGameSerializer<UInt8>.Append(OS, value.Faction);
		ViGameSerializer<Int64>.Append(OS, value.Time);
		ViGameSerializer<ViVector3>.Append(OS, value.Position);
		ViGameSerializer<float>.Append(OS, value.Yaw);
	}
	public static void Read(ViIStream IS, out SpaceEventCacheProperty value)
	{
		ViGameSerializer<ViForeignKey<SpaceEventStruct>>.Read(IS, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, out value.Time);
		ViGameSerializer<ViVector3>.Read(IS, out value.Position);
		ViGameSerializer<float>.Read(IS, out value.Yaw);
	}
	public static bool Read(ViStringIStream IS, out SpaceEventCacheProperty value)
	{
		value = default(SpaceEventCacheProperty);
		if(ViGameSerializer<ViForeignKey<SpaceEventStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Faction) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time) == false){return false;}
		if(ViGameSerializer<ViVector3>.Read(IS, out value.Position) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.Yaw) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceEventCacheProperty value)
	{
		ViGameSerializer<ViForeignKey<SpaceEventStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<UInt8>.Append(OS, head + ".Faction", value.Faction);
		ViGameSerializer<Int64>.Append(OS, head + ".Time", value.Time);
		ViGameSerializer<ViVector3>.Append(OS, head + ".Position", value.Position);
		ViGameSerializer<float>.Append(OS, head + ".Yaw", value.Yaw);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceEventCacheProperty value)
	{
		value = new SpaceEventCacheProperty();
		ViGameSerializer<ViForeignKey<SpaceEventStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time);
		ViGameSerializer<ViVector3>.Read(IS, head, out value.Position);
		ViGameSerializer<float>.Read(IS, head, out value.Yaw);
	}
}
public static class SpaceEventPropertySerializer
{
	public static void Append(ViOStream OS, SpaceEventProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Faction);
		ViGameSerializer<Int64>.Append(OS, value.Time);
		ViGameSerializer<Int16>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out SpaceEventProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, out value.Time);
		ViGameSerializer<Int16>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out SpaceEventProperty value)
	{
		value = default(SpaceEventProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Faction) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceEventProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Faction", value.Faction);
		ViGameSerializer<Int64>.Append(OS, head + ".Time", value.Time);
		ViGameSerializer<Int16>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceEventProperty value)
	{
		value = new SpaceEventProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time);
		ViGameSerializer<Int16>.Read(IS, head, out value.Count);
	}
}
public static class SpaceBlockSlotPropertySerializer
{
	public static void Append(ViOStream OS, SpaceBlockSlotProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.X);
		ViGameSerializer<Int16>.Append(OS, value.Y);
		ViGameSerializer<ViForeignKey<SpaceBlockSlotStruct>>.Append(OS, value.Info);
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int64>.Append(OS, value.RecoverTime);
	}
	public static void Read(ViIStream IS, out SpaceBlockSlotProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.X);
		ViGameSerializer<Int16>.Read(IS, out value.Y);
		ViGameSerializer<ViForeignKey<SpaceBlockSlotStruct>>.Read(IS, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int64>.Read(IS, out value.RecoverTime);
	}
	public static bool Read(ViStringIStream IS, out SpaceBlockSlotProperty value)
	{
		value = default(SpaceBlockSlotProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.X) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Y) == false){return false;}
		if(ViGameSerializer<ViForeignKey<SpaceBlockSlotStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.RecoverTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceBlockSlotProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".X", value.X);
		ViGameSerializer<Int16>.Append(OS, head + ".Y", value.Y);
		ViGameSerializer<ViForeignKey<SpaceBlockSlotStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int64>.Append(OS, head + ".RecoverTime", value.RecoverTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceBlockSlotProperty value)
	{
		value = new SpaceBlockSlotProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.X);
		ViGameSerializer<Int16>.Read(IS, head, out value.Y);
		ViGameSerializer<ViForeignKey<SpaceBlockSlotStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int64>.Read(IS, head, out value.RecoverTime);
	}
}
public static class SpaceHideSlotPropertySerializer
{
	public static void Append(ViOStream OS, SpaceHideSlotProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.X);
		ViGameSerializer<Int16>.Append(OS, value.Y);
		ViGameSerializer<ViForeignKey<SpaceHideSlotStruct>>.Append(OS, value.Info);
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int64>.Append(OS, value.RecoverTime);
	}
	public static void Read(ViIStream IS, out SpaceHideSlotProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.X);
		ViGameSerializer<Int16>.Read(IS, out value.Y);
		ViGameSerializer<ViForeignKey<SpaceHideSlotStruct>>.Read(IS, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int64>.Read(IS, out value.RecoverTime);
	}
	public static bool Read(ViStringIStream IS, out SpaceHideSlotProperty value)
	{
		value = default(SpaceHideSlotProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.X) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Y) == false){return false;}
		if(ViGameSerializer<ViForeignKey<SpaceHideSlotStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.RecoverTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceHideSlotProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".X", value.X);
		ViGameSerializer<Int16>.Append(OS, head + ".Y", value.Y);
		ViGameSerializer<ViForeignKey<SpaceHideSlotStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int64>.Append(OS, head + ".RecoverTime", value.RecoverTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceHideSlotProperty value)
	{
		value = new SpaceHideSlotProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.X);
		ViGameSerializer<Int16>.Read(IS, head, out value.Y);
		ViGameSerializer<ViForeignKey<SpaceHideSlotStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int64>.Read(IS, head, out value.RecoverTime);
	}
}
public static class SpacePlayerWorkingHeroSpellCDPropertySerializer
{
	public static void Append(ViOStream OS, SpacePlayerWorkingHeroSpellCDProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Spell);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out SpacePlayerWorkingHeroSpellCDProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Spell);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out SpacePlayerWorkingHeroSpellCDProperty value)
	{
		value = default(SpacePlayerWorkingHeroSpellCDProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Spell) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpacePlayerWorkingHeroSpellCDProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Spell", value.Spell);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpacePlayerWorkingHeroSpellCDProperty value)
	{
		value = new SpacePlayerWorkingHeroSpellCDProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Spell);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class SpacePlayerWorkingHeroSpellCDArrayPropertySerializer
{
	public static void Append(ViOStream OS, SpacePlayerWorkingHeroSpellCDArrayProperty value)
	{
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, value.E0);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, value.E1);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, value.E2);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, value.E3);
	}
	public static void Read(ViIStream IS, out SpacePlayerWorkingHeroSpellCDArrayProperty value)
	{
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E0);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E1);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E2);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E3);
	}
	public static bool Read(ViStringIStream IS, out SpacePlayerWorkingHeroSpellCDArrayProperty value)
	{
		value = default(SpacePlayerWorkingHeroSpellCDArrayProperty);
		if(ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, out value.E3) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpacePlayerWorkingHeroSpellCDArrayProperty value)
	{
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Append(OS, head + ".E3", value.E3);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpacePlayerWorkingHeroSpellCDArrayProperty value)
	{
		value = new SpacePlayerWorkingHeroSpellCDArrayProperty();
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, head, out value.E2);
		ViGameSerializer<SpacePlayerWorkingHeroSpellCDProperty>.Read(IS, head, out value.E3);
	}
}
public static class SpacePlayerMemberPropertySerializer
{
	public static void Append(ViOStream OS, SpacePlayerMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<UInt8>.Append(OS, value.ClientState);
		ViGameSerializer<float>.Append(OS, value.LoadProgress);
		ViGameSerializer<UInt8>.Append(OS, value.ClientSpaceCompleted);
		ViGameSerializer<ViString>.Append(OS, value.Guild);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Faction);
	}
	public static void Read(ViIStream IS, out SpacePlayerMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientState);
		ViGameSerializer<float>.Read(IS, out value.LoadProgress);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientSpaceCompleted);
		ViGameSerializer<ViString>.Read(IS, out value.Guild);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Faction);
	}
	public static bool Read(ViStringIStream IS, out SpacePlayerMemberProperty value)
	{
		value = default(SpacePlayerMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientState) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.LoadProgress) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientSpaceCompleted) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Guild) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Faction) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpacePlayerMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientState", value.ClientState);
		ViGameSerializer<float>.Append(OS, head + ".LoadProgress", value.LoadProgress);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientSpaceCompleted", value.ClientSpaceCompleted);
		ViGameSerializer<ViString>.Append(OS, head + ".Guild", value.Guild);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Faction", value.Faction);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpacePlayerMemberProperty value)
	{
		value = new SpacePlayerMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientState);
		ViGameSerializer<float>.Read(IS, head, out value.LoadProgress);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientSpaceCompleted);
		ViGameSerializer<ViString>.Read(IS, head, out value.Guild);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Faction);
	}
}
public static class SpacePlayerMemberPtrPropertySerializer
{
	public static void Append(ViOStream OS, SpacePlayerMemberPtrProperty value)
	{
		ViGameSerializer<SpacePlayerMemberProperty>.Append(OS, value.Ptr);
	}
	public static void Read(ViIStream IS, out SpacePlayerMemberPtrProperty value)
	{
		ViGameSerializer<SpacePlayerMemberProperty>.Read(IS, out value.Ptr);
	}
	public static bool Read(ViStringIStream IS, out SpacePlayerMemberPtrProperty value)
	{
		value = default(SpacePlayerMemberPtrProperty);
		if(ViGameSerializer<SpacePlayerMemberProperty>.Read(IS, out value.Ptr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpacePlayerMemberPtrProperty value)
	{
		ViGameSerializer<SpacePlayerMemberProperty>.Append(OS, head + ".Ptr", value.Ptr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpacePlayerMemberPtrProperty value)
	{
		value = new SpacePlayerMemberPtrProperty();
		ViGameSerializer<SpacePlayerMemberProperty>.Read(IS, head, out value.Ptr);
	}
}
public static class SpaceHeroMemberPropertySerializer
{
	public static void Append(ViOStream OS, SpaceHeroMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, value.Info);
		ViGameSerializer<ViString>.Append(OS, value.Guild);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Faction);
	}
	public static void Read(ViIStream IS, out SpaceHeroMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.Info);
		ViGameSerializer<ViString>.Read(IS, out value.Guild);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Faction);
	}
	public static bool Read(ViStringIStream IS, out SpaceHeroMemberProperty value)
	{
		value = default(SpaceHeroMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Guild) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Faction) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceHeroMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<ViString>.Append(OS, head + ".Guild", value.Guild);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Faction", value.Faction);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceHeroMemberProperty value)
	{
		value = new SpaceHeroMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<ViString>.Read(IS, head, out value.Guild);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Faction);
	}
}
public static class SpaceHeroLevelRandomEffectPropertySerializer
{
	public static void Append(ViOStream OS, SpaceHeroLevelRandomEffectProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.E0);
		ViGameSerializer<UInt32>.Append(OS, value.E1);
		ViGameSerializer<UInt32>.Append(OS, value.E2);
	}
	public static void Read(ViIStream IS, out SpaceHeroLevelRandomEffectProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.E0);
		ViGameSerializer<UInt32>.Read(IS, out value.E1);
		ViGameSerializer<UInt32>.Read(IS, out value.E2);
	}
	public static bool Read(ViStringIStream IS, out SpaceHeroLevelRandomEffectProperty value)
	{
		value = default(SpaceHeroLevelRandomEffectProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.E2) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceHeroLevelRandomEffectProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<UInt32>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<UInt32>.Append(OS, head + ".E2", value.E2);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceHeroLevelRandomEffectProperty value)
	{
		value = new SpaceHeroLevelRandomEffectProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.E0);
		ViGameSerializer<UInt32>.Read(IS, head, out value.E1);
		ViGameSerializer<UInt32>.Read(IS, head, out value.E2);
	}
}
public static class SpaceDamageOutPropertySerializer
{
	public static void Append(ViOStream OS, SpaceDamageOutProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Faction);
		ViGameSerializer<Int64>.Append(OS, value.CurrentDamageOut);
		ViGameSerializer<Int64>.Append(OS, value.AccumulateDamageOut);
	}
	public static void Read(ViIStream IS, out SpaceDamageOutProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, out value.CurrentDamageOut);
		ViGameSerializer<Int64>.Read(IS, out value.AccumulateDamageOut);
	}
	public static bool Read(ViStringIStream IS, out SpaceDamageOutProperty value)
	{
		value = default(SpaceDamageOutProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Faction) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CurrentDamageOut) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AccumulateDamageOut) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceDamageOutProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Faction", value.Faction);
		ViGameSerializer<Int64>.Append(OS, head + ".CurrentDamageOut", value.CurrentDamageOut);
		ViGameSerializer<Int64>.Append(OS, head + ".AccumulateDamageOut", value.AccumulateDamageOut);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceDamageOutProperty value)
	{
		value = new SpaceDamageOutProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Faction);
		ViGameSerializer<Int64>.Read(IS, head, out value.CurrentDamageOut);
		ViGameSerializer<Int64>.Read(IS, head, out value.AccumulateDamageOut);
	}
}
public static class SpaceFactionHeroMemberPropertySerializer
{
	public static void Append(ViOStream OS, SpaceFactionHeroMemberProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.ActionState);
		ViGameSerializer<Int32>.Append(OS, value.HP);
		ViGameSerializer<Int32>.Append(OS, value.HPMax);
		ViGameSerializer<ViVector3>.Append(OS, value.Position);
	}
	public static void Read(ViIStream IS, out SpaceFactionHeroMemberProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.ActionState);
		ViGameSerializer<Int32>.Read(IS, out value.HP);
		ViGameSerializer<Int32>.Read(IS, out value.HPMax);
		ViGameSerializer<ViVector3>.Read(IS, out value.Position);
	}
	public static bool Read(ViStringIStream IS, out SpaceFactionHeroMemberProperty value)
	{
		value = default(SpaceFactionHeroMemberProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.ActionState) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HP) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.HPMax) == false){return false;}
		if(ViGameSerializer<ViVector3>.Read(IS, out value.Position) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceFactionHeroMemberProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".ActionState", value.ActionState);
		ViGameSerializer<Int32>.Append(OS, head + ".HP", value.HP);
		ViGameSerializer<Int32>.Append(OS, head + ".HPMax", value.HPMax);
		ViGameSerializer<ViVector3>.Append(OS, head + ".Position", value.Position);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceFactionHeroMemberProperty value)
	{
		value = new SpaceFactionHeroMemberProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.ActionState);
		ViGameSerializer<Int32>.Read(IS, head, out value.HP);
		ViGameSerializer<Int32>.Read(IS, head, out value.HPMax);
		ViGameSerializer<ViVector3>.Read(IS, head, out value.Position);
	}
}
public static class PublicSpaceEnterMemberPropertySerializer
{
	public static void Append(ViOStream OS, PublicSpaceEnterMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.FactionIdx);
		ViGameSerializer<ViString>.Append(OS, value.Guild);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int64>.Append(OS, value.EnterTime);
		ViGameSerializer<UInt8>.Append(OS, value.Ready);
	}
	public static void Read(ViIStream IS, out PublicSpaceEnterMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.FactionIdx);
		ViGameSerializer<ViString>.Read(IS, out value.Guild);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int64>.Read(IS, out value.EnterTime);
		ViGameSerializer<UInt8>.Read(IS, out value.Ready);
	}
	public static bool Read(ViStringIStream IS, out PublicSpaceEnterMemberProperty value)
	{
		value = default(PublicSpaceEnterMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FactionIdx) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Guild) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EnterTime) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Ready) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PublicSpaceEnterMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".FactionIdx", value.FactionIdx);
		ViGameSerializer<ViString>.Append(OS, head + ".Guild", value.Guild);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int64>.Append(OS, head + ".EnterTime", value.EnterTime);
		ViGameSerializer<UInt8>.Append(OS, head + ".Ready", value.Ready);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PublicSpaceEnterMemberProperty value)
	{
		value = new PublicSpaceEnterMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FactionIdx);
		ViGameSerializer<ViString>.Read(IS, head, out value.Guild);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int64>.Read(IS, head, out value.EnterTime);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Ready);
	}
}
public static class PublicSpaceEnterGroupMemberPropertySerializer
{
	public static void Append(ViOStream OS, PublicSpaceEnterGroupMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.FactionIdx);
	}
	public static void Read(ViIStream IS, out PublicSpaceEnterGroupMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.FactionIdx);
	}
	public static bool Read(ViStringIStream IS, out PublicSpaceEnterGroupMemberProperty value)
	{
		value = default(PublicSpaceEnterGroupMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FactionIdx) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PublicSpaceEnterGroupMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".FactionIdx", value.FactionIdx);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PublicSpaceEnterGroupMemberProperty value)
	{
		value = new PublicSpaceEnterGroupMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FactionIdx);
	}
}
public static class PublicSpaceEnterGroupMemberArrayPropertySerializer
{
	public static void Append(ViOStream OS, PublicSpaceEnterGroupMemberArrayProperty value)
	{
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E0);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E1);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E2);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E3);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E4);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E5);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E6);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E7);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E8);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, value.E9);
	}
	public static void Read(ViIStream IS, out PublicSpaceEnterGroupMemberArrayProperty value)
	{
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E0);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E1);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E2);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E3);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E4);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E5);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E6);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E7);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E8);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E9);
	}
	public static bool Read(ViStringIStream IS, out PublicSpaceEnterGroupMemberArrayProperty value)
	{
		value = default(PublicSpaceEnterGroupMemberArrayProperty);
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E4) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E5) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E6) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E7) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E8) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, out value.E9) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PublicSpaceEnterGroupMemberArrayProperty value)
	{
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E4", value.E4);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E5", value.E5);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E6", value.E6);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E7", value.E7);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E8", value.E8);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Append(OS, head + ".E9", value.E9);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PublicSpaceEnterGroupMemberArrayProperty value)
	{
		value = new PublicSpaceEnterGroupMemberArrayProperty();
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E0);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E1);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E2);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E3);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E4);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E5);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E6);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E7);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E8);
		ViGameSerializer<PublicSpaceEnterGroupMemberProperty>.Read(IS, head, out value.E9);
	}
}
public static class PublicSpaceEnterGroupPropertySerializer
{
	public static void Append(ViOStream OS, PublicSpaceEnterGroupProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Append(OS, value.Space);
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Leader);
		ViGameSerializer<PublicSpaceEnterGroupMemberArrayProperty>.Append(OS, value.MemberList);
		ViGameSerializer<Int8>.Append(OS, value.FactionCount);
		ViGameSerializer<Int16>.Append(OS, value.FactionMemberCount);
		ViGameSerializer<Int16>.Append(OS, value.MemberCount);
		ViGameSerializer<Int16>.Append(OS, value.WatcherCount);
		ViGameSerializer<UInt8>.Append(OS, value.HasPassword);
	}
	public static void Read(ViIStream IS, out PublicSpaceEnterGroupProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Read(IS, out value.Space);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader);
		ViGameSerializer<PublicSpaceEnterGroupMemberArrayProperty>.Read(IS, out value.MemberList);
		ViGameSerializer<Int8>.Read(IS, out value.FactionCount);
		ViGameSerializer<Int16>.Read(IS, out value.FactionMemberCount);
		ViGameSerializer<Int16>.Read(IS, out value.MemberCount);
		ViGameSerializer<Int16>.Read(IS, out value.WatcherCount);
		ViGameSerializer<UInt8>.Read(IS, out value.HasPassword);
	}
	public static bool Read(ViStringIStream IS, out PublicSpaceEnterGroupProperty value)
	{
		value = default(PublicSpaceEnterGroupProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<ViForeignKey<SpaceStruct>>.Read(IS, out value.Space) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader) == false){return false;}
		if(ViGameSerializer<PublicSpaceEnterGroupMemberArrayProperty>.Read(IS, out value.MemberList) == false){return false;}
		if(ViGameSerializer<Int8>.Read(IS, out value.FactionCount) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.FactionMemberCount) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.MemberCount) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.WatcherCount) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HasPassword) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PublicSpaceEnterGroupProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Append(OS, head + ".Space", value.Space);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Leader", value.Leader);
		ViGameSerializer<PublicSpaceEnterGroupMemberArrayProperty>.Append(OS, head + ".MemberList", value.MemberList);
		ViGameSerializer<Int8>.Append(OS, head + ".FactionCount", value.FactionCount);
		ViGameSerializer<Int16>.Append(OS, head + ".FactionMemberCount", value.FactionMemberCount);
		ViGameSerializer<Int16>.Append(OS, head + ".MemberCount", value.MemberCount);
		ViGameSerializer<Int16>.Append(OS, head + ".WatcherCount", value.WatcherCount);
		ViGameSerializer<UInt8>.Append(OS, head + ".HasPassword", value.HasPassword);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PublicSpaceEnterGroupProperty value)
	{
		value = new PublicSpaceEnterGroupProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Read(IS, head, out value.Space);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Leader);
		ViGameSerializer<PublicSpaceEnterGroupMemberArrayProperty>.Read(IS, head, out value.MemberList);
		ViGameSerializer<Int8>.Read(IS, head, out value.FactionCount);
		ViGameSerializer<Int16>.Read(IS, head, out value.FactionMemberCount);
		ViGameSerializer<Int16>.Read(IS, head, out value.MemberCount);
		ViGameSerializer<Int16>.Read(IS, head, out value.WatcherCount);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HasPassword);
	}
}
public static class GoalPropertySerializer
{
	public static void Append(ViOStream OS, GoalProperty value)
	{
		ViGameSerializer<ViForeignKey<GoalStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int64>.Append(OS, value.CompleteTime1970);
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int32>.Append(OS, value.Value);
		ViGameSerializer<Int32>.Append(OS, value.ValueSup);
	}
	public static void Read(ViIStream IS, out GoalProperty value)
	{
		ViGameSerializer<ViForeignKey<GoalStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int64>.Read(IS, out value.CompleteTime1970);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int32>.Read(IS, out value.Value);
		ViGameSerializer<Int32>.Read(IS, out value.ValueSup);
	}
	public static bool Read(ViStringIStream IS, out GoalProperty value)
	{
		value = default(GoalProperty);
		if(ViGameSerializer<ViForeignKey<GoalStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CompleteTime1970) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Value) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ValueSup) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GoalProperty value)
	{
		ViGameSerializer<ViForeignKey<GoalStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int64>.Append(OS, head + ".CompleteTime1970", value.CompleteTime1970);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int32>.Append(OS, head + ".Value", value.Value);
		ViGameSerializer<Int32>.Append(OS, head + ".ValueSup", value.ValueSup);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GoalProperty value)
	{
		value = new GoalProperty();
		ViGameSerializer<ViForeignKey<GoalStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int64>.Read(IS, head, out value.CompleteTime1970);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int32>.Read(IS, head, out value.Value);
		ViGameSerializer<Int32>.Read(IS, head, out value.ValueSup);
	}
}
public static class ClientSettingForPlayerPropertySerializer
{
	public static void Append(ViOStream OS, ClientSettingForPlayerProperty value)
	{
		ViGameSerializer<float>.Append(OS, value.CameraDistance);
		ViGameSerializer<UInt8>.Append(OS, value.MinMap);
		ViGameSerializer<UInt8>.Append(OS, value.MouseControllerType);
		ViGameSerializer<UInt8>.Append(OS, value.AutoAct);
	}
	public static void Read(ViIStream IS, out ClientSettingForPlayerProperty value)
	{
		ViGameSerializer<float>.Read(IS, out value.CameraDistance);
		ViGameSerializer<UInt8>.Read(IS, out value.MinMap);
		ViGameSerializer<UInt8>.Read(IS, out value.MouseControllerType);
		ViGameSerializer<UInt8>.Read(IS, out value.AutoAct);
	}
	public static bool Read(ViStringIStream IS, out ClientSettingForPlayerProperty value)
	{
		value = default(ClientSettingForPlayerProperty);
		if(ViGameSerializer<float>.Read(IS, out value.CameraDistance) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.MinMap) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.MouseControllerType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.AutoAct) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ClientSettingForPlayerProperty value)
	{
		ViGameSerializer<float>.Append(OS, head + ".CameraDistance", value.CameraDistance);
		ViGameSerializer<UInt8>.Append(OS, head + ".MinMap", value.MinMap);
		ViGameSerializer<UInt8>.Append(OS, head + ".MouseControllerType", value.MouseControllerType);
		ViGameSerializer<UInt8>.Append(OS, head + ".AutoAct", value.AutoAct);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ClientSettingForPlayerProperty value)
	{
		value = new ClientSettingForPlayerProperty();
		ViGameSerializer<float>.Read(IS, head, out value.CameraDistance);
		ViGameSerializer<UInt8>.Read(IS, head, out value.MinMap);
		ViGameSerializer<UInt8>.Read(IS, head, out value.MouseControllerType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.AutoAct);
	}
}
public static class ClientSettingForAccountPropertySerializer
{
	public static void Append(ViOStream OS, ClientSettingForAccountProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.SpellLODLevel);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsMainLevel);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsMirrorCharacter);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsMirrorScene);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsShadow);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsColorEnhance);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsBloom);
		ViGameSerializer<UInt8>.Append(OS, value.GraphicsDistort);
		ViGameSerializer<float>.Append(OS, value.CameraShakeScale);
		ViGameSerializer<UInt8>.Append(OS, value.FPSLevel);
		ViGameSerializer<UInt8>.Append(OS, value.EnergySave);
		ViGameSerializer<float>.Append(OS, value.MainVolume);
		ViGameSerializer<float>.Append(OS, value.MusicVolume);
		ViGameSerializer<float>.Append(OS, value.SoundVolume);
		ViGameSerializer<float>.Append(OS, value.CharacterVolume);
		ViGameSerializer<float>.Append(OS, value.AutoLockFocusScale);
	}
	public static void Read(ViIStream IS, out ClientSettingForAccountProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.SpellLODLevel);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsMainLevel);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsMirrorCharacter);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsMirrorScene);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsShadow);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsColorEnhance);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsBloom);
		ViGameSerializer<UInt8>.Read(IS, out value.GraphicsDistort);
		ViGameSerializer<float>.Read(IS, out value.CameraShakeScale);
		ViGameSerializer<UInt8>.Read(IS, out value.FPSLevel);
		ViGameSerializer<UInt8>.Read(IS, out value.EnergySave);
		ViGameSerializer<float>.Read(IS, out value.MainVolume);
		ViGameSerializer<float>.Read(IS, out value.MusicVolume);
		ViGameSerializer<float>.Read(IS, out value.SoundVolume);
		ViGameSerializer<float>.Read(IS, out value.CharacterVolume);
		ViGameSerializer<float>.Read(IS, out value.AutoLockFocusScale);
	}
	public static bool Read(ViStringIStream IS, out ClientSettingForAccountProperty value)
	{
		value = default(ClientSettingForAccountProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.SpellLODLevel) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsMainLevel) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsMirrorCharacter) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsMirrorScene) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsShadow) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsColorEnhance) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsBloom) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.GraphicsDistort) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.CameraShakeScale) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FPSLevel) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.EnergySave) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.MainVolume) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.MusicVolume) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.SoundVolume) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.CharacterVolume) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.AutoLockFocusScale) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ClientSettingForAccountProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".SpellLODLevel", value.SpellLODLevel);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsMainLevel", value.GraphicsMainLevel);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsMirrorCharacter", value.GraphicsMirrorCharacter);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsMirrorScene", value.GraphicsMirrorScene);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsShadow", value.GraphicsShadow);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsColorEnhance", value.GraphicsColorEnhance);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsBloom", value.GraphicsBloom);
		ViGameSerializer<UInt8>.Append(OS, head + ".GraphicsDistort", value.GraphicsDistort);
		ViGameSerializer<float>.Append(OS, head + ".CameraShakeScale", value.CameraShakeScale);
		ViGameSerializer<UInt8>.Append(OS, head + ".FPSLevel", value.FPSLevel);
		ViGameSerializer<UInt8>.Append(OS, head + ".EnergySave", value.EnergySave);
		ViGameSerializer<float>.Append(OS, head + ".MainVolume", value.MainVolume);
		ViGameSerializer<float>.Append(OS, head + ".MusicVolume", value.MusicVolume);
		ViGameSerializer<float>.Append(OS, head + ".SoundVolume", value.SoundVolume);
		ViGameSerializer<float>.Append(OS, head + ".CharacterVolume", value.CharacterVolume);
		ViGameSerializer<float>.Append(OS, head + ".AutoLockFocusScale", value.AutoLockFocusScale);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ClientSettingForAccountProperty value)
	{
		value = new ClientSettingForAccountProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.SpellLODLevel);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsMainLevel);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsMirrorCharacter);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsMirrorScene);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsShadow);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsColorEnhance);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsBloom);
		ViGameSerializer<UInt8>.Read(IS, head, out value.GraphicsDistort);
		ViGameSerializer<float>.Read(IS, head, out value.CameraShakeScale);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FPSLevel);
		ViGameSerializer<UInt8>.Read(IS, head, out value.EnergySave);
		ViGameSerializer<float>.Read(IS, head, out value.MainVolume);
		ViGameSerializer<float>.Read(IS, head, out value.MusicVolume);
		ViGameSerializer<float>.Read(IS, head, out value.SoundVolume);
		ViGameSerializer<float>.Read(IS, head, out value.CharacterVolume);
		ViGameSerializer<float>.Read(IS, head, out value.AutoLockFocusScale);
	}
}
public static class ClientDevicePropertySerializer
{
	public static void Append(ViOStream OS, ClientDeviceProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Platform);
		ViGameSerializer<ViString>.Append(OS, value.DeviceName);
		ViGameSerializer<ViString>.Append(OS, value.DeviceModel);
		ViGameSerializer<ViString>.Append(OS, value.DeviceUniqueIdentifier);
		ViGameSerializer<ViString>.Append(OS, value.OperatingSystem);
		ViGameSerializer<Int8>.Append(OS, value.OperatingSystemAPILevel);
		ViGameSerializer<Int32>.Append(OS, value.SystemMemorySize);
		ViGameSerializer<ViString>.Append(OS, value.ProcessorType);
		ViGameSerializer<Int8>.Append(OS, value.ProcessorCount);
		ViGameSerializer<Int32>.Append(OS, value.ProcessorFrequency);
		ViGameSerializer<ViString>.Append(OS, value.GraphicsDeviceName);
		ViGameSerializer<ViString>.Append(OS, value.GraphicsDeviceVendor);
		ViGameSerializer<ViString>.Append(OS, value.GraphicsDeviceVersion);
		ViGameSerializer<Int32>.Append(OS, value.GraphicsMemorySize);
		ViGameSerializer<Int16>.Append(OS, value.ScreenX);
		ViGameSerializer<Int16>.Append(OS, value.ScreenY);
	}
	public static void Read(ViIStream IS, out ClientDeviceProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Platform);
		ViGameSerializer<ViString>.Read(IS, out value.DeviceName);
		ViGameSerializer<ViString>.Read(IS, out value.DeviceModel);
		ViGameSerializer<ViString>.Read(IS, out value.DeviceUniqueIdentifier);
		ViGameSerializer<ViString>.Read(IS, out value.OperatingSystem);
		ViGameSerializer<Int8>.Read(IS, out value.OperatingSystemAPILevel);
		ViGameSerializer<Int32>.Read(IS, out value.SystemMemorySize);
		ViGameSerializer<ViString>.Read(IS, out value.ProcessorType);
		ViGameSerializer<Int8>.Read(IS, out value.ProcessorCount);
		ViGameSerializer<Int32>.Read(IS, out value.ProcessorFrequency);
		ViGameSerializer<ViString>.Read(IS, out value.GraphicsDeviceName);
		ViGameSerializer<ViString>.Read(IS, out value.GraphicsDeviceVendor);
		ViGameSerializer<ViString>.Read(IS, out value.GraphicsDeviceVersion);
		ViGameSerializer<Int32>.Read(IS, out value.GraphicsMemorySize);
		ViGameSerializer<Int16>.Read(IS, out value.ScreenX);
		ViGameSerializer<Int16>.Read(IS, out value.ScreenY);
	}
	public static bool Read(ViStringIStream IS, out ClientDeviceProperty value)
	{
		value = default(ClientDeviceProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Platform) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.DeviceName) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.DeviceModel) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.DeviceUniqueIdentifier) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.OperatingSystem) == false){return false;}
		if(ViGameSerializer<Int8>.Read(IS, out value.OperatingSystemAPILevel) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SystemMemorySize) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.ProcessorType) == false){return false;}
		if(ViGameSerializer<Int8>.Read(IS, out value.ProcessorCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ProcessorFrequency) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GraphicsDeviceName) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GraphicsDeviceVendor) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GraphicsDeviceVersion) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.GraphicsMemorySize) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.ScreenX) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.ScreenY) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ClientDeviceProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Platform", value.Platform);
		ViGameSerializer<ViString>.Append(OS, head + ".DeviceName", value.DeviceName);
		ViGameSerializer<ViString>.Append(OS, head + ".DeviceModel", value.DeviceModel);
		ViGameSerializer<ViString>.Append(OS, head + ".DeviceUniqueIdentifier", value.DeviceUniqueIdentifier);
		ViGameSerializer<ViString>.Append(OS, head + ".OperatingSystem", value.OperatingSystem);
		ViGameSerializer<Int8>.Append(OS, head + ".OperatingSystemAPILevel", value.OperatingSystemAPILevel);
		ViGameSerializer<Int32>.Append(OS, head + ".SystemMemorySize", value.SystemMemorySize);
		ViGameSerializer<ViString>.Append(OS, head + ".ProcessorType", value.ProcessorType);
		ViGameSerializer<Int8>.Append(OS, head + ".ProcessorCount", value.ProcessorCount);
		ViGameSerializer<Int32>.Append(OS, head + ".ProcessorFrequency", value.ProcessorFrequency);
		ViGameSerializer<ViString>.Append(OS, head + ".GraphicsDeviceName", value.GraphicsDeviceName);
		ViGameSerializer<ViString>.Append(OS, head + ".GraphicsDeviceVendor", value.GraphicsDeviceVendor);
		ViGameSerializer<ViString>.Append(OS, head + ".GraphicsDeviceVersion", value.GraphicsDeviceVersion);
		ViGameSerializer<Int32>.Append(OS, head + ".GraphicsMemorySize", value.GraphicsMemorySize);
		ViGameSerializer<Int16>.Append(OS, head + ".ScreenX", value.ScreenX);
		ViGameSerializer<Int16>.Append(OS, head + ".ScreenY", value.ScreenY);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ClientDeviceProperty value)
	{
		value = new ClientDeviceProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Platform);
		ViGameSerializer<ViString>.Read(IS, head, out value.DeviceName);
		ViGameSerializer<ViString>.Read(IS, head, out value.DeviceModel);
		ViGameSerializer<ViString>.Read(IS, head, out value.DeviceUniqueIdentifier);
		ViGameSerializer<ViString>.Read(IS, head, out value.OperatingSystem);
		ViGameSerializer<Int8>.Read(IS, head, out value.OperatingSystemAPILevel);
		ViGameSerializer<Int32>.Read(IS, head, out value.SystemMemorySize);
		ViGameSerializer<ViString>.Read(IS, head, out value.ProcessorType);
		ViGameSerializer<Int8>.Read(IS, head, out value.ProcessorCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.ProcessorFrequency);
		ViGameSerializer<ViString>.Read(IS, head, out value.GraphicsDeviceName);
		ViGameSerializer<ViString>.Read(IS, head, out value.GraphicsDeviceVendor);
		ViGameSerializer<ViString>.Read(IS, head, out value.GraphicsDeviceVersion);
		ViGameSerializer<Int32>.Read(IS, head, out value.GraphicsMemorySize);
		ViGameSerializer<Int16>.Read(IS, head, out value.ScreenX);
		ViGameSerializer<Int16>.Read(IS, head, out value.ScreenY);
	}
}
public static class FriendPropertySerializer
{
	public static void Append(ViOStream OS, FriendProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<ViString>.Append(OS, value.Note);
	}
	public static void Read(ViIStream IS, out FriendProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<ViString>.Read(IS, out value.Note);
	}
	public static bool Read(ViStringIStream IS, out FriendProperty value)
	{
		value = default(FriendProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Note) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, FriendProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<ViString>.Append(OS, head + ".Note", value.Note);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out FriendProperty value)
	{
		value = new FriendProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<ViString>.Read(IS, head, out value.Note);
	}
}
public static class FriendViewPropertySerializer
{
	public static void Append(ViOStream OS, FriendViewProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.Class);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, value.GuildName);
		ViGameSerializer<UInt8>.Append(OS, value.Photo);
		ViGameSerializer<Int64>.Append(OS, value.LastActiveTime1970);
		ViGameSerializer<UInt32>.Append(OS, value.Space);
	}
	public static void Read(ViIStream IS, out FriendViewProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.Class);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, out value.GuildName);
		ViGameSerializer<UInt8>.Read(IS, out value.Photo);
		ViGameSerializer<Int64>.Read(IS, out value.LastActiveTime1970);
		ViGameSerializer<UInt32>.Read(IS, out value.Space);
	}
	public static bool Read(ViStringIStream IS, out FriendViewProperty value)
	{
		value = default(FriendViewProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Class) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientState) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HasGuild) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GuildName) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Photo) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastActiveTime1970) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Space) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, FriendViewProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".Class", value.Class);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientState", value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, head + ".HasGuild", value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, head + ".GuildName", value.GuildName);
		ViGameSerializer<UInt8>.Append(OS, head + ".Photo", value.Photo);
		ViGameSerializer<Int64>.Append(OS, head + ".LastActiveTime1970", value.LastActiveTime1970);
		ViGameSerializer<UInt32>.Append(OS, head + ".Space", value.Space);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out FriendViewProperty value)
	{
		value = new FriendViewProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Class);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, head, out value.GuildName);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Photo);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastActiveTime1970);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Space);
	}
}
public static class FriendInvitorPropertySerializer
{
	public static void Append(ViOStream OS, FriendInvitorProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.Class);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, value.GuildName);
	}
	public static void Read(ViIStream IS, out FriendInvitorProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.Class);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, out value.GuildName);
	}
	public static bool Read(ViStringIStream IS, out FriendInvitorProperty value)
	{
		value = default(FriendInvitorProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Class) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientState) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HasGuild) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GuildName) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, FriendInvitorProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".Class", value.Class);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientState", value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, head + ".HasGuild", value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, head + ".GuildName", value.GuildName);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out FriendInvitorProperty value)
	{
		value = new FriendInvitorProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Class);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, head, out value.GuildName);
	}
}
public static class FriendInviteePropertySerializer
{
	public static void Append(ViOStream OS, FriendInviteeProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.Class);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, value.GuildName);
	}
	public static void Read(ViIStream IS, out FriendInviteeProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.Class);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, out value.GuildName);
	}
	public static bool Read(ViStringIStream IS, out FriendInviteeProperty value)
	{
		value = default(FriendInviteeProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Class) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientState) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HasGuild) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GuildName) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, FriendInviteeProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".Class", value.Class);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientState", value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, head + ".HasGuild", value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, head + ".GuildName", value.GuildName);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out FriendInviteeProperty value)
	{
		value = new FriendInviteeProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Class);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, head, out value.GuildName);
	}
}
public static class BlackFriendPropertySerializer
{
	public static void Append(ViOStream OS, BlackFriendProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.Class);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, value.GuildName);
	}
	public static void Read(ViIStream IS, out BlackFriendProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.Class);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, out value.GuildName);
	}
	public static bool Read(ViStringIStream IS, out BlackFriendProperty value)
	{
		value = default(BlackFriendProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Class) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientState) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HasGuild) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.GuildName) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, BlackFriendProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".Class", value.Class);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientState", value.ClientState);
		ViGameSerializer<UInt8>.Append(OS, head + ".HasGuild", value.HasGuild);
		ViGameSerializer<ViString>.Append(OS, head + ".GuildName", value.GuildName);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out BlackFriendProperty value)
	{
		value = new BlackFriendProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Class);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientState);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HasGuild);
		ViGameSerializer<ViString>.Read(IS, head, out value.GuildName);
	}
}
public static class MailPropertySerializer
{
	public static void Append(ViOStream OS, MailProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<UInt8>.Append(OS, value.Type);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ViString>.Append(OS, value.Title);
		ViGameSerializer<ViString>.Append(OS, value.Content);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Sender);
		ViGameSerializer<Int64>.Append(OS, value.AttachmentReceiveTime1970);
		ViGameSerializer<Int64>.Append(OS, value.AttachmentXP);
		ViGameSerializer<Int64>.Append(OS, value.AttachmentYinPiao);
		ViGameSerializer<Int64>.Append(OS, value.AttachmentJinPiao);
		ViGameSerializer<Int64>.Append(OS, value.AttachmentJinZi);
		ViGameSerializer<ScoreArray6Property>.Append(OS, value.AttachmentScores);
		ViGameSerializer<ItemCountArray6Property>.Append(OS, value.AttachmentItems);
		ViGameSerializer<ItemProperty>.Append(OS, value.AttachmentItem);
	}
	public static void Read(ViIStream IS, out MailProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<UInt8>.Read(IS, out value.Type);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, out value.Title);
		ViGameSerializer<ViString>.Read(IS, out value.Content);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Sender);
		ViGameSerializer<Int64>.Read(IS, out value.AttachmentReceiveTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.AttachmentXP);
		ViGameSerializer<Int64>.Read(IS, out value.AttachmentYinPiao);
		ViGameSerializer<Int64>.Read(IS, out value.AttachmentJinPiao);
		ViGameSerializer<Int64>.Read(IS, out value.AttachmentJinZi);
		ViGameSerializer<ScoreArray6Property>.Read(IS, out value.AttachmentScores);
		ViGameSerializer<ItemCountArray6Property>.Read(IS, out value.AttachmentItems);
		ViGameSerializer<ItemProperty>.Read(IS, out value.AttachmentItem);
	}
	public static bool Read(ViStringIStream IS, out MailProperty value)
	{
		value = default(MailProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Title) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Content) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Sender) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AttachmentReceiveTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AttachmentXP) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AttachmentYinPiao) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AttachmentJinPiao) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AttachmentJinZi) == false){return false;}
		if(ViGameSerializer<ScoreArray6Property>.Read(IS, out value.AttachmentScores) == false){return false;}
		if(ViGameSerializer<ItemCountArray6Property>.Read(IS, out value.AttachmentItems) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.AttachmentItem) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MailProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<UInt8>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ViString>.Append(OS, head + ".Title", value.Title);
		ViGameSerializer<ViString>.Append(OS, head + ".Content", value.Content);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Sender", value.Sender);
		ViGameSerializer<Int64>.Append(OS, head + ".AttachmentReceiveTime1970", value.AttachmentReceiveTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".AttachmentXP", value.AttachmentXP);
		ViGameSerializer<Int64>.Append(OS, head + ".AttachmentYinPiao", value.AttachmentYinPiao);
		ViGameSerializer<Int64>.Append(OS, head + ".AttachmentJinPiao", value.AttachmentJinPiao);
		ViGameSerializer<Int64>.Append(OS, head + ".AttachmentJinZi", value.AttachmentJinZi);
		ViGameSerializer<ScoreArray6Property>.Append(OS, head + ".AttachmentScores", value.AttachmentScores);
		ViGameSerializer<ItemCountArray6Property>.Append(OS, head + ".AttachmentItems", value.AttachmentItems);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".AttachmentItem", value.AttachmentItem);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MailProperty value)
	{
		value = new MailProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Type);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, head, out value.Title);
		ViGameSerializer<ViString>.Read(IS, head, out value.Content);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Sender);
		ViGameSerializer<Int64>.Read(IS, head, out value.AttachmentReceiveTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.AttachmentXP);
		ViGameSerializer<Int64>.Read(IS, head, out value.AttachmentYinPiao);
		ViGameSerializer<Int64>.Read(IS, head, out value.AttachmentJinPiao);
		ViGameSerializer<Int64>.Read(IS, head, out value.AttachmentJinZi);
		ViGameSerializer<ScoreArray6Property>.Read(IS, head, out value.AttachmentScores);
		ViGameSerializer<ItemCountArray6Property>.Read(IS, head, out value.AttachmentItems);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.AttachmentItem);
	}
}
public static class GuildMemberPropertySerializer
{
	public static void Append(ViOStream OS, GuildMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<UInt8>.Append(OS, value.Position);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
		ViGameSerializer<Int32>.Append(OS, value.DailyContribution);
		ViGameSerializer<Int32>.Append(OS, value.TotalContribution);
		ViGameSerializer<Int32>.Append(OS, value.TotalContributionBadgeCount);
		ViGameSerializer<UInt8>.Append(OS, value.ClientState);
		ViGameSerializer<Int64>.Append(OS, value.LastOnlineTime);
		ViGameSerializer<Int64>.Append(OS, value.LastOnlineTime1970);
	}
	public static void Read(ViIStream IS, out GuildMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, out value.Position);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
		ViGameSerializer<Int32>.Read(IS, out value.DailyContribution);
		ViGameSerializer<Int32>.Read(IS, out value.TotalContribution);
		ViGameSerializer<Int32>.Read(IS, out value.TotalContributionBadgeCount);
		ViGameSerializer<UInt8>.Read(IS, out value.ClientState);
		ViGameSerializer<Int64>.Read(IS, out value.LastOnlineTime);
		ViGameSerializer<Int64>.Read(IS, out value.LastOnlineTime1970);
	}
	public static bool Read(ViStringIStream IS, out GuildMemberProperty value)
	{
		value = default(GuildMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Position) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.DailyContribution) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.TotalContribution) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.TotalContributionBadgeCount) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ClientState) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastOnlineTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastOnlineTime1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<UInt8>.Append(OS, head + ".Position", value.Position);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
		ViGameSerializer<Int32>.Append(OS, head + ".DailyContribution", value.DailyContribution);
		ViGameSerializer<Int32>.Append(OS, head + ".TotalContribution", value.TotalContribution);
		ViGameSerializer<Int32>.Append(OS, head + ".TotalContributionBadgeCount", value.TotalContributionBadgeCount);
		ViGameSerializer<UInt8>.Append(OS, head + ".ClientState", value.ClientState);
		ViGameSerializer<Int64>.Append(OS, head + ".LastOnlineTime", value.LastOnlineTime);
		ViGameSerializer<Int64>.Append(OS, head + ".LastOnlineTime1970", value.LastOnlineTime1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildMemberProperty value)
	{
		value = new GuildMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Position);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
		ViGameSerializer<Int32>.Read(IS, head, out value.DailyContribution);
		ViGameSerializer<Int32>.Read(IS, head, out value.TotalContribution);
		ViGameSerializer<Int32>.Read(IS, head, out value.TotalContributionBadgeCount);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ClientState);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastOnlineTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastOnlineTime1970);
	}
}
public static class GuildMessagePropertySerializer
{
	public static void Append(ViOStream OS, GuildMessageProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.Type);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Member);
		ViGameSerializer<Int64>.Append(OS, value.IntValue0);
		ViGameSerializer<Int64>.Append(OS, value.IntValue1);
		ViGameSerializer<ViString>.Append(OS, value.StringValue0);
		ViGameSerializer<ViString>.Append(OS, value.StringValue1);
	}
	public static void Read(ViIStream IS, out GuildMessageProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.Type);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Member);
		ViGameSerializer<Int64>.Read(IS, out value.IntValue0);
		ViGameSerializer<Int64>.Read(IS, out value.IntValue1);
		ViGameSerializer<ViString>.Read(IS, out value.StringValue0);
		ViGameSerializer<ViString>.Read(IS, out value.StringValue1);
	}
	public static bool Read(ViStringIStream IS, out GuildMessageProperty value)
	{
		value = default(GuildMessageProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Member) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.IntValue0) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.IntValue1) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.StringValue0) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.StringValue1) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildMessageProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Member", value.Member);
		ViGameSerializer<Int64>.Append(OS, head + ".IntValue0", value.IntValue0);
		ViGameSerializer<Int64>.Append(OS, head + ".IntValue1", value.IntValue1);
		ViGameSerializer<ViString>.Append(OS, head + ".StringValue0", value.StringValue0);
		ViGameSerializer<ViString>.Append(OS, head + ".StringValue1", value.StringValue1);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildMessageProperty value)
	{
		value = new GuildMessageProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.Type);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Member);
		ViGameSerializer<Int64>.Read(IS, head, out value.IntValue0);
		ViGameSerializer<Int64>.Read(IS, head, out value.IntValue1);
		ViGameSerializer<ViString>.Read(IS, head, out value.StringValue0);
		ViGameSerializer<ViString>.Read(IS, head, out value.StringValue1);
	}
}
public static class GuildApplyPropertySerializer
{
	public static void Append(ViOStream OS, GuildApplyProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
	}
	public static void Read(ViIStream IS, out GuildApplyProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
	}
	public static bool Read(ViStringIStream IS, out GuildApplyProperty value)
	{
		value = default(GuildApplyProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildApplyProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildApplyProperty value)
	{
		value = new GuildApplyProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
	}
}
public static class GuildViewPropertySerializer
{
	public static void Append(ViOStream OS, GuildViewProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Leader);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int16>.Append(OS, value.MemberCount);
		ViGameSerializer<UInt8>.Append(OS, value.ResponseType);
		ViGameSerializer<Int16>.Append(OS, value.ReqEnterLevel);
		ViGameSerializer<ViString>.Append(OS, value.Introdution);
		ViGameSerializer<Int32>.Append(OS, value.FightPower);
	}
	public static void Read(ViIStream IS, out GuildViewProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int16>.Read(IS, out value.MemberCount);
		ViGameSerializer<UInt8>.Read(IS, out value.ResponseType);
		ViGameSerializer<Int16>.Read(IS, out value.ReqEnterLevel);
		ViGameSerializer<ViString>.Read(IS, out value.Introdution);
		ViGameSerializer<Int32>.Read(IS, out value.FightPower);
	}
	public static bool Read(ViStringIStream IS, out GuildViewProperty value)
	{
		value = default(GuildViewProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.MemberCount) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.ResponseType) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.ReqEnterLevel) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Introdution) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.FightPower) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildViewProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Leader", value.Leader);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int16>.Append(OS, head + ".MemberCount", value.MemberCount);
		ViGameSerializer<UInt8>.Append(OS, head + ".ResponseType", value.ResponseType);
		ViGameSerializer<Int16>.Append(OS, head + ".ReqEnterLevel", value.ReqEnterLevel);
		ViGameSerializer<ViString>.Append(OS, head + ".Introdution", value.Introdution);
		ViGameSerializer<Int32>.Append(OS, head + ".FightPower", value.FightPower);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildViewProperty value)
	{
		value = new GuildViewProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Leader);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int16>.Read(IS, head, out value.MemberCount);
		ViGameSerializer<UInt8>.Read(IS, head, out value.ResponseType);
		ViGameSerializer<Int16>.Read(IS, head, out value.ReqEnterLevel);
		ViGameSerializer<ViString>.Read(IS, head, out value.Introdution);
		ViGameSerializer<Int32>.Read(IS, head, out value.FightPower);
	}
}
public static class GuildActivitySeatPropertySerializer
{
	public static void Append(ViOStream OS, GuildActivitySeatProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Activity);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
	}
	public static void Read(ViIStream IS, out GuildActivitySeatProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Activity);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
	}
	public static bool Read(ViStringIStream IS, out GuildActivitySeatProperty value)
	{
		value = default(GuildActivitySeatProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Activity) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildActivitySeatProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Activity", value.Activity);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildActivitySeatProperty value)
	{
		value = new GuildActivitySeatProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Activity);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
	}
}
public static class GuildActivityPropertySerializer
{
	public static void Append(ViOStream OS, GuildActivityProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.Leader);
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int64>.Append(OS, value.StartTime1970);
		ViGameSerializer<Int16>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out GuildActivityProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.Leader);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime1970);
		ViGameSerializer<Int16>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out GuildActivityProperty value)
	{
		value = default(GuildActivityProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.Leader) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime1970) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildActivityProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".Leader", value.Leader);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime1970", value.StartTime1970);
		ViGameSerializer<Int16>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildActivityProperty value)
	{
		value = new GuildActivityProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.Leader);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime1970);
		ViGameSerializer<Int16>.Read(IS, head, out value.Count);
	}
}
public static class GuildActivityEnterPropertySerializer
{
	public static void Append(ViOStream OS, GuildActivityEnterProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.EnterCount);
		ViGameSerializer<Int16>.Append(OS, value.BuyCount);
	}
	public static void Read(ViIStream IS, out GuildActivityEnterProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.EnterCount);
		ViGameSerializer<Int16>.Read(IS, out value.BuyCount);
	}
	public static bool Read(ViStringIStream IS, out GuildActivityEnterProperty value)
	{
		value = default(GuildActivityEnterProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.EnterCount) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.BuyCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GuildActivityEnterProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".EnterCount", value.EnterCount);
		ViGameSerializer<Int16>.Append(OS, head + ".BuyCount", value.BuyCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GuildActivityEnterProperty value)
	{
		value = new GuildActivityEnterProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.EnterCount);
		ViGameSerializer<Int16>.Read(IS, head, out value.BuyCount);
	}
}
public static class ActivityPropertySerializer
{
	public static void Append(ViOStream OS, ActivityProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int64>.Append(OS, value.EndTime1970);
		ViGameSerializer<Int64>.Append(OS, value.Version);
	}
	public static void Read(ViIStream IS, out ActivityProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.Version);
	}
	public static bool Read(ViStringIStream IS, out ActivityProperty value)
	{
		value = default(ActivityProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Version) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ActivityProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime1970", value.EndTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".Version", value.Version);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ActivityProperty value)
	{
		value = new ActivityProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.Version);
	}
}
public static class ActivityStatisticsPropertySerializer
{
	public static void Append(ViOStream OS, ActivityStatisticsProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Version);
		ViGameSerializer<Int32>.Append(OS, value.EnterCount);
		ViGameSerializer<Int32>.Append(OS, value.ExistCount);
		ViGameSerializer<Int32>.Append(OS, value.MaxExistCount);
	}
	public static void Read(ViIStream IS, out ActivityStatisticsProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Version);
		ViGameSerializer<Int32>.Read(IS, out value.EnterCount);
		ViGameSerializer<Int32>.Read(IS, out value.ExistCount);
		ViGameSerializer<Int32>.Read(IS, out value.MaxExistCount);
	}
	public static bool Read(ViStringIStream IS, out ActivityStatisticsProperty value)
	{
		value = default(ActivityStatisticsProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.Version) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.EnterCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ExistCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MaxExistCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ActivityStatisticsProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Version", value.Version);
		ViGameSerializer<Int32>.Append(OS, head + ".EnterCount", value.EnterCount);
		ViGameSerializer<Int32>.Append(OS, head + ".ExistCount", value.ExistCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MaxExistCount", value.MaxExistCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ActivityStatisticsProperty value)
	{
		value = new ActivityStatisticsProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.Version);
		ViGameSerializer<Int32>.Read(IS, head, out value.EnterCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.ExistCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MaxExistCount);
	}
}
public static class ActivityStatisticsRecordPropertySerializer
{
	public static void Append(ViOStream OS, ActivityStatisticsRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.ID);
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<Int64>.Append(OS, value.StartTime1970);
		ViGameSerializer<Int64>.Append(OS, value.Duration);
		ViGameSerializer<ActivityStatisticsProperty>.Append(OS, value.Statistics);
	}
	public static void Read(ViIStream IS, out ActivityStatisticsRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.ID);
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.Duration);
		ViGameSerializer<ActivityStatisticsProperty>.Read(IS, out value.Statistics);
	}
	public static bool Read(ViStringIStream IS, out ActivityStatisticsRecordProperty value)
	{
		value = default(ActivityStatisticsRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Duration) == false){return false;}
		if(ViGameSerializer<ActivityStatisticsProperty>.Read(IS, out value.Statistics) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ActivityStatisticsRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime1970", value.StartTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".Duration", value.Duration);
		ViGameSerializer<ActivityStatisticsProperty>.Append(OS, head + ".Statistics", value.Statistics);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ActivityStatisticsRecordProperty value)
	{
		value = new ActivityStatisticsRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.ID);
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.Duration);
		ViGameSerializer<ActivityStatisticsProperty>.Read(IS, head, out value.Statistics);
	}
}
public static class ActivityEnterPropertySerializer
{
	public static void Append(ViOStream OS, ActivityEnterProperty value)
	{
		ViGameSerializer<ViForeignKey<ActivityStruct>>.Append(OS, value.Info);
		ViGameSerializer<Int16>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.AccumulateCount);
		ViGameSerializer<Int64>.Append(OS, value.LastVersion);
		ViGameSerializer<UInt32>.Append(OS, value.Rank);
		ViGameSerializer<AccmulateDurationProperty>.Append(OS, value.Duration);
	}
	public static void Read(ViIStream IS, out ActivityEnterProperty value)
	{
		ViGameSerializer<ViForeignKey<ActivityStruct>>.Read(IS, out value.Info);
		ViGameSerializer<Int16>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.AccumulateCount);
		ViGameSerializer<Int64>.Read(IS, out value.LastVersion);
		ViGameSerializer<UInt32>.Read(IS, out value.Rank);
		ViGameSerializer<AccmulateDurationProperty>.Read(IS, out value.Duration);
	}
	public static bool Read(ViStringIStream IS, out ActivityEnterProperty value)
	{
		value = default(ActivityEnterProperty);
		if(ViGameSerializer<ViForeignKey<ActivityStruct>>.Read(IS, out value.Info) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AccumulateCount) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastVersion) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Rank) == false){return false;}
		if(ViGameSerializer<AccmulateDurationProperty>.Read(IS, out value.Duration) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ActivityEnterProperty value)
	{
		ViGameSerializer<ViForeignKey<ActivityStruct>>.Append(OS, head + ".Info", value.Info);
		ViGameSerializer<Int16>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".AccumulateCount", value.AccumulateCount);
		ViGameSerializer<Int64>.Append(OS, head + ".LastVersion", value.LastVersion);
		ViGameSerializer<UInt32>.Append(OS, head + ".Rank", value.Rank);
		ViGameSerializer<AccmulateDurationProperty>.Append(OS, head + ".Duration", value.Duration);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ActivityEnterProperty value)
	{
		value = new ActivityEnterProperty();
		ViGameSerializer<ViForeignKey<ActivityStruct>>.Read(IS, head, out value.Info);
		ViGameSerializer<Int16>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.AccumulateCount);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastVersion);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Rank);
		ViGameSerializer<AccmulateDurationProperty>.Read(IS, head, out value.Duration);
	}
}
public static class ActivityRankPropertySerializer
{
	public static void Append(ViOStream OS, ActivityRankProperty value)
	{
		ViGameSerializer<PlayerShotProperty>.Append(OS, value.Property);
		ViGameSerializer<Int64>.Append(OS, value.Score);
		ViGameSerializer<Int64>.Append(OS, value.Value0);
		ViGameSerializer<Int64>.Append(OS, value.Value1);
		ViGameSerializer<Int64>.Append(OS, value.Value2);
	}
	public static void Read(ViIStream IS, out ActivityRankProperty value)
	{
		ViGameSerializer<PlayerShotProperty>.Read(IS, out value.Property);
		ViGameSerializer<Int64>.Read(IS, out value.Score);
		ViGameSerializer<Int64>.Read(IS, out value.Value0);
		ViGameSerializer<Int64>.Read(IS, out value.Value1);
		ViGameSerializer<Int64>.Read(IS, out value.Value2);
	}
	public static bool Read(ViStringIStream IS, out ActivityRankProperty value)
	{
		value = default(ActivityRankProperty);
		if(ViGameSerializer<PlayerShotProperty>.Read(IS, out value.Property) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Score) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value0) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value1) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value2) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ActivityRankProperty value)
	{
		ViGameSerializer<PlayerShotProperty>.Append(OS, head + ".Property", value.Property);
		ViGameSerializer<Int64>.Append(OS, head + ".Score", value.Score);
		ViGameSerializer<Int64>.Append(OS, head + ".Value0", value.Value0);
		ViGameSerializer<Int64>.Append(OS, head + ".Value1", value.Value1);
		ViGameSerializer<Int64>.Append(OS, head + ".Value2", value.Value2);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ActivityRankProperty value)
	{
		value = new ActivityRankProperty();
		ViGameSerializer<PlayerShotProperty>.Read(IS, head, out value.Property);
		ViGameSerializer<Int64>.Read(IS, head, out value.Score);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value0);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value1);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value2);
	}
}
public static class PaymentStatePropertySerializer
{
	public static void Append(ViOStream OS, PaymentStateProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.ID);
		ViGameSerializer<UInt8>.Append(OS, value.State);
	}
	public static void Read(ViIStream IS, out PaymentStateProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.ID);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
	}
	public static bool Read(ViStringIStream IS, out PaymentStateProperty value)
	{
		value = default(PaymentStateProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PaymentStateProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PaymentStateProperty value)
	{
		value = new PaymentStateProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.ID);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
	}
}
public static class PartyMemberPropertySerializer
{
	public static void Append(ViOStream OS, PartyMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Recommander);
		ViGameSerializer<UInt8>.Append(OS, value.Ready);
		ViGameSerializer<UInt8>.Append(OS, value.AutoReady);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Online);
		ViGameSerializer<UInt8>.Append(OS, value.Class);
		ViGameSerializer<UInt16>.Append(OS, value.Power);
		ViGameSerializer<UInt8>.Append(OS, value.Channel);
		ViGameSerializer<UInt32>.Append(OS, value.SpaceID);
		ViGameSerializer<UInt8>.Append(OS, value.KickOutTimes);
	}
	public static void Read(ViIStream IS, out PartyMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Recommander);
		ViGameSerializer<UInt8>.Read(IS, out value.Ready);
		ViGameSerializer<UInt8>.Read(IS, out value.AutoReady);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Online);
		ViGameSerializer<UInt8>.Read(IS, out value.Class);
		ViGameSerializer<UInt16>.Read(IS, out value.Power);
		ViGameSerializer<UInt8>.Read(IS, out value.Channel);
		ViGameSerializer<UInt32>.Read(IS, out value.SpaceID);
		ViGameSerializer<UInt8>.Read(IS, out value.KickOutTimes);
	}
	public static bool Read(ViStringIStream IS, out PartyMemberProperty value)
	{
		value = default(PartyMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Recommander) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Ready) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.AutoReady) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Online) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Class) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Power) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Channel) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.SpaceID) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.KickOutTimes) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartyMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Recommander", value.Recommander);
		ViGameSerializer<UInt8>.Append(OS, head + ".Ready", value.Ready);
		ViGameSerializer<UInt8>.Append(OS, head + ".AutoReady", value.AutoReady);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Online", value.Online);
		ViGameSerializer<UInt8>.Append(OS, head + ".Class", value.Class);
		ViGameSerializer<UInt16>.Append(OS, head + ".Power", value.Power);
		ViGameSerializer<UInt8>.Append(OS, head + ".Channel", value.Channel);
		ViGameSerializer<UInt32>.Append(OS, head + ".SpaceID", value.SpaceID);
		ViGameSerializer<UInt8>.Append(OS, head + ".KickOutTimes", value.KickOutTimes);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartyMemberProperty value)
	{
		value = new PartyMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Recommander);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Ready);
		ViGameSerializer<UInt8>.Read(IS, head, out value.AutoReady);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Online);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Class);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Power);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Channel);
		ViGameSerializer<UInt32>.Read(IS, head, out value.SpaceID);
		ViGameSerializer<UInt8>.Read(IS, head, out value.KickOutTimes);
	}
}
public static class PartySpaceSelectPropertySerializer
{
	public static void Append(ViOStream OS, PartySpaceSelectProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Space);
		ViGameSerializer<UInt8>.Append(OS, value.MatchType);
	}
	public static void Read(ViIStream IS, out PartySpaceSelectProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Space);
		ViGameSerializer<UInt8>.Read(IS, out value.MatchType);
	}
	public static bool Read(ViStringIStream IS, out PartySpaceSelectProperty value)
	{
		value = default(PartySpaceSelectProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Space) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.MatchType) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartySpaceSelectProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Space", value.Space);
		ViGameSerializer<UInt8>.Append(OS, head + ".MatchType", value.MatchType);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartySpaceSelectProperty value)
	{
		value = new PartySpaceSelectProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Space);
		ViGameSerializer<UInt8>.Read(IS, head, out value.MatchType);
	}
}
public static class PartySpaceMatchPropertySerializer
{
	public static void Append(ViOStream OS, PartySpaceMatchProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.AverageScore);
		ViGameSerializer<UInt32>.Append(OS, value.Space);
		ViGameSerializer<UInt8>.Append(OS, value.MatchType);
		ViGameSerializer<Int64>.Append(OS, value.StartTime);
		ViGameSerializer<float>.Append(OS, value.Progress);
	}
	public static void Read(ViIStream IS, out PartySpaceMatchProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.AverageScore);
		ViGameSerializer<UInt32>.Read(IS, out value.Space);
		ViGameSerializer<UInt8>.Read(IS, out value.MatchType);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime);
		ViGameSerializer<float>.Read(IS, out value.Progress);
	}
	public static bool Read(ViStringIStream IS, out PartySpaceMatchProperty value)
	{
		value = default(PartySpaceMatchProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.AverageScore) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Space) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.MatchType) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<float>.Read(IS, out value.Progress) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartySpaceMatchProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".AverageScore", value.AverageScore);
		ViGameSerializer<UInt32>.Append(OS, head + ".Space", value.Space);
		ViGameSerializer<UInt8>.Append(OS, head + ".MatchType", value.MatchType);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<float>.Append(OS, head + ".Progress", value.Progress);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartySpaceMatchProperty value)
	{
		value = new PartySpaceMatchProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.AverageScore);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Space);
		ViGameSerializer<UInt8>.Read(IS, head, out value.MatchType);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<float>.Read(IS, head, out value.Progress);
	}
}
public static class PartyInvitorPropertySerializer
{
	public static void Append(ViOStream OS, PartyInvitorProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.PartyID);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Leader);
		ViGameSerializer<PartyMemberProperty>.Append(OS, value.PlayerDetailLite);
	}
	public static void Read(ViIStream IS, out PartyInvitorProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.PartyID);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader);
		ViGameSerializer<PartyMemberProperty>.Read(IS, out value.PlayerDetailLite);
	}
	public static bool Read(ViStringIStream IS, out PartyInvitorProperty value)
	{
		value = default(PartyInvitorProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.PartyID) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader) == false){return false;}
		if(ViGameSerializer<PartyMemberProperty>.Read(IS, out value.PlayerDetailLite) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartyInvitorProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".PartyID", value.PartyID);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Leader", value.Leader);
		ViGameSerializer<PartyMemberProperty>.Append(OS, head + ".PlayerDetailLite", value.PlayerDetailLite);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartyInvitorProperty value)
	{
		value = new PartyInvitorProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.PartyID);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Leader);
		ViGameSerializer<PartyMemberProperty>.Read(IS, head, out value.PlayerDetailLite);
	}
}
public static class PartyPartnerRecordPropertySerializer
{
	public static void Append(ViOStream OS, PartyPartnerRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Identification);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<UInt8>.Append(OS, value.State);
	}
	public static void Read(ViIStream IS, out PartyPartnerRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, out value.State);
	}
	public static bool Read(ViStringIStream IS, out PartyPartnerRecordProperty value)
	{
		value = default(PartyPartnerRecordProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Identification) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartyPartnerRecordProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Identification", value.Identification);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartyPartnerRecordProperty value)
	{
		value = new PartyPartnerRecordProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Identification);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
	}
}
public static class PartyDetailSerializer
{
	public static void Append(ViOStream OS, PartyDetail value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<UInt16>.Append(OS, value.MaxPlayer);
		ViGameSerializer<UInt64>.Append(OS, value.Type);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Leader);
		ViGameSerializer<PartyMemberProperty>.Append(OS, value.member);
	}
	public static void Read(ViIStream IS, out PartyDetail value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<UInt16>.Read(IS, out value.MaxPlayer);
		ViGameSerializer<UInt64>.Read(IS, out value.Type);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader);
		ViGameSerializer<PartyMemberProperty>.Read(IS, out value.member);
	}
	public static bool Read(ViStringIStream IS, out PartyDetail value)
	{
		value = default(PartyDetail);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.MaxPlayer) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Leader) == false){return false;}
		if(ViGameSerializer<PartyMemberProperty>.Read(IS, out value.member) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartyDetail value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<UInt16>.Append(OS, head + ".MaxPlayer", value.MaxPlayer);
		ViGameSerializer<UInt64>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Leader", value.Leader);
		ViGameSerializer<PartyMemberProperty>.Append(OS, head + ".member", value.member);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartyDetail value)
	{
		value = new PartyDetail();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<UInt16>.Read(IS, head, out value.MaxPlayer);
		ViGameSerializer<UInt64>.Read(IS, head, out value.Type);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Leader);
		ViGameSerializer<PartyMemberProperty>.Read(IS, head, out value.member);
	}
}
public static class PartyDetailLiteSerializer
{
	public static void Append(ViOStream OS, PartyDetailLite value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.ID);
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<UInt16>.Append(OS, value.MaxPlayer);
		ViGameSerializer<UInt16>.Append(OS, value.Type);
	}
	public static void Read(ViIStream IS, out PartyDetailLite value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.ID);
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<UInt16>.Read(IS, out value.MaxPlayer);
		ViGameSerializer<UInt16>.Read(IS, out value.Type);
	}
	public static bool Read(ViStringIStream IS, out PartyDetailLite value)
	{
		value = default(PartyDetailLite);
		if(ViGameSerializer<UInt64>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.MaxPlayer) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Type) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PartyDetailLite value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<UInt16>.Append(OS, head + ".MaxPlayer", value.MaxPlayer);
		ViGameSerializer<UInt16>.Append(OS, head + ".Type", value.Type);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PartyDetailLite value)
	{
		value = new PartyDetailLite();
		ViGameSerializer<UInt64>.Read(IS, head, out value.ID);
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<UInt16>.Read(IS, head, out value.MaxPlayer);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Type);
	}
}
public static class PlayerScoreRankPropertySerializer
{
	public static void Append(ViOStream OS, PlayerScoreRankProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Player);
		ViGameSerializer<Int32>.Append(OS, value.Score);
		ViGameSerializer<UInt32>.Append(OS, value.Position);
	}
	public static void Read(ViIStream IS, out PlayerScoreRankProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player);
		ViGameSerializer<Int32>.Read(IS, out value.Score);
		ViGameSerializer<UInt32>.Read(IS, out value.Position);
	}
	public static bool Read(ViStringIStream IS, out PlayerScoreRankProperty value)
	{
		value = default(PlayerScoreRankProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Score) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Position) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerScoreRankProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Player", value.Player);
		ViGameSerializer<Int32>.Append(OS, head + ".Score", value.Score);
		ViGameSerializer<UInt32>.Append(OS, head + ".Position", value.Position);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerScoreRankProperty value)
	{
		value = new PlayerScoreRankProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Player);
		ViGameSerializer<Int32>.Read(IS, head, out value.Score);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Position);
	}
}
public static class ScoreRankStasticsPropertySerializer
{
	public static void Append(ViOStream OS, ScoreRankStasticsProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.Score);
		ViGameSerializer<UInt32>.Append(OS, value.RankPosition);
		ViGameSerializer<UInt32>.Append(OS, value.RankPositionBest);
		ViGameSerializer<Int32>.Append(OS, value.MatchScore);
		ViGameSerializer<Int32>.Append(OS, value.ContinueWinCount);
		ViGameSerializer<Int32>.Append(OS, value.ContinueLoseCount);
		ViGameSerializer<Int32>.Append(OS, value.TotalCount);
		ViGameSerializer<Int32>.Append(OS, value.TotalWinCount);
		ViGameSerializer<Int32>.Append(OS, value.TotalLoseCount);
		ViGameSerializer<Int32>.Append(OS, value.VersionCount);
		ViGameSerializer<Int32>.Append(OS, value.VersionWinCount);
		ViGameSerializer<Int32>.Append(OS, value.VersionLoseCount);
		ViGameSerializer<Int64>.Append(OS, value.Version);
		ViGameSerializer<Int64>.Append(OS, value.RewardVersion);
	}
	public static void Read(ViIStream IS, out ScoreRankStasticsProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.Score);
		ViGameSerializer<UInt32>.Read(IS, out value.RankPosition);
		ViGameSerializer<UInt32>.Read(IS, out value.RankPositionBest);
		ViGameSerializer<Int32>.Read(IS, out value.MatchScore);
		ViGameSerializer<Int32>.Read(IS, out value.ContinueWinCount);
		ViGameSerializer<Int32>.Read(IS, out value.ContinueLoseCount);
		ViGameSerializer<Int32>.Read(IS, out value.TotalCount);
		ViGameSerializer<Int32>.Read(IS, out value.TotalWinCount);
		ViGameSerializer<Int32>.Read(IS, out value.TotalLoseCount);
		ViGameSerializer<Int32>.Read(IS, out value.VersionCount);
		ViGameSerializer<Int32>.Read(IS, out value.VersionWinCount);
		ViGameSerializer<Int32>.Read(IS, out value.VersionLoseCount);
		ViGameSerializer<Int64>.Read(IS, out value.Version);
		ViGameSerializer<Int64>.Read(IS, out value.RewardVersion);
	}
	public static bool Read(ViStringIStream IS, out ScoreRankStasticsProperty value)
	{
		value = default(ScoreRankStasticsProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.Score) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.RankPosition) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.RankPositionBest) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MatchScore) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ContinueWinCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ContinueLoseCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.TotalCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.TotalWinCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.TotalLoseCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.VersionCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.VersionWinCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.VersionLoseCount) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Version) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.RewardVersion) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ScoreRankStasticsProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".Score", value.Score);
		ViGameSerializer<UInt32>.Append(OS, head + ".RankPosition", value.RankPosition);
		ViGameSerializer<UInt32>.Append(OS, head + ".RankPositionBest", value.RankPositionBest);
		ViGameSerializer<Int32>.Append(OS, head + ".MatchScore", value.MatchScore);
		ViGameSerializer<Int32>.Append(OS, head + ".ContinueWinCount", value.ContinueWinCount);
		ViGameSerializer<Int32>.Append(OS, head + ".ContinueLoseCount", value.ContinueLoseCount);
		ViGameSerializer<Int32>.Append(OS, head + ".TotalCount", value.TotalCount);
		ViGameSerializer<Int32>.Append(OS, head + ".TotalWinCount", value.TotalWinCount);
		ViGameSerializer<Int32>.Append(OS, head + ".TotalLoseCount", value.TotalLoseCount);
		ViGameSerializer<Int32>.Append(OS, head + ".VersionCount", value.VersionCount);
		ViGameSerializer<Int32>.Append(OS, head + ".VersionWinCount", value.VersionWinCount);
		ViGameSerializer<Int32>.Append(OS, head + ".VersionLoseCount", value.VersionLoseCount);
		ViGameSerializer<Int64>.Append(OS, head + ".Version", value.Version);
		ViGameSerializer<Int64>.Append(OS, head + ".RewardVersion", value.RewardVersion);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ScoreRankStasticsProperty value)
	{
		value = new ScoreRankStasticsProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.Score);
		ViGameSerializer<UInt32>.Read(IS, head, out value.RankPosition);
		ViGameSerializer<UInt32>.Read(IS, head, out value.RankPositionBest);
		ViGameSerializer<Int32>.Read(IS, head, out value.MatchScore);
		ViGameSerializer<Int32>.Read(IS, head, out value.ContinueWinCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.ContinueLoseCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.TotalCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.TotalWinCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.TotalLoseCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.VersionCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.VersionWinCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.VersionLoseCount);
		ViGameSerializer<Int64>.Read(IS, head, out value.Version);
		ViGameSerializer<Int64>.Read(IS, head, out value.RewardVersion);
	}
}
public static class SpaceMatchPropertySerializer
{
	public static void Append(ViOStream OS, SpaceMatchProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Space);
		ViGameSerializer<Int32>.Append(OS, value.Size);
		ViGameSerializer<Int32>.Append(OS, value.PlayerCount);
	}
	public static void Read(ViIStream IS, out SpaceMatchProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Space);
		ViGameSerializer<Int32>.Read(IS, out value.Size);
		ViGameSerializer<Int32>.Read(IS, out value.PlayerCount);
	}
	public static bool Read(ViStringIStream IS, out SpaceMatchProperty value)
	{
		value = default(SpaceMatchProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Space) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Size) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PlayerCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceMatchProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Space", value.Space);
		ViGameSerializer<Int32>.Append(OS, head + ".Size", value.Size);
		ViGameSerializer<Int32>.Append(OS, head + ".PlayerCount", value.PlayerCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceMatchProperty value)
	{
		value = new SpaceMatchProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Space);
		ViGameSerializer<Int32>.Read(IS, head, out value.Size);
		ViGameSerializer<Int32>.Read(IS, head, out value.PlayerCount);
	}
}
public static class MatchSpaceMemberScorePropertySerializer
{
	public static void Append(ViOStream OS, MatchSpaceMemberScoreProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.Score);
		ViGameSerializer<Int32>.Append(OS, value.PartyScore);
		ViGameSerializer<Int32>.Append(OS, value.ScoreMod);
	}
	public static void Read(ViIStream IS, out MatchSpaceMemberScoreProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.Score);
		ViGameSerializer<Int32>.Read(IS, out value.PartyScore);
		ViGameSerializer<Int32>.Read(IS, out value.ScoreMod);
	}
	public static bool Read(ViStringIStream IS, out MatchSpaceMemberScoreProperty value)
	{
		value = default(MatchSpaceMemberScoreProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.Score) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PartyScore) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ScoreMod) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MatchSpaceMemberScoreProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".Score", value.Score);
		ViGameSerializer<Int32>.Append(OS, head + ".PartyScore", value.PartyScore);
		ViGameSerializer<Int32>.Append(OS, head + ".ScoreMod", value.ScoreMod);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MatchSpaceMemberScoreProperty value)
	{
		value = new MatchSpaceMemberScoreProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.Score);
		ViGameSerializer<Int32>.Read(IS, head, out value.PartyScore);
		ViGameSerializer<Int32>.Read(IS, head, out value.ScoreMod);
	}
}
public static class SpaceMatchEnterMemberPropertySerializer
{
	public static void Append(ViOStream OS, SpaceMatchEnterMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Player);
		ViGameSerializer<UInt8>.Append(OS, value.FactionIdx);
		ViGameSerializer<UInt8>.Append(OS, value.Ready);
		ViGameSerializer<UInt32>.Append(OS, value.Hero);
		ViGameSerializer<UInt8>.Append(OS, value.HeroReady);
	}
	public static void Read(ViIStream IS, out SpaceMatchEnterMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player);
		ViGameSerializer<UInt8>.Read(IS, out value.FactionIdx);
		ViGameSerializer<UInt8>.Read(IS, out value.Ready);
		ViGameSerializer<UInt32>.Read(IS, out value.Hero);
		ViGameSerializer<UInt8>.Read(IS, out value.HeroReady);
	}
	public static bool Read(ViStringIStream IS, out SpaceMatchEnterMemberProperty value)
	{
		value = default(SpaceMatchEnterMemberProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.FactionIdx) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Ready) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Hero) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.HeroReady) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceMatchEnterMemberProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Player", value.Player);
		ViGameSerializer<UInt8>.Append(OS, head + ".FactionIdx", value.FactionIdx);
		ViGameSerializer<UInt8>.Append(OS, head + ".Ready", value.Ready);
		ViGameSerializer<UInt32>.Append(OS, head + ".Hero", value.Hero);
		ViGameSerializer<UInt8>.Append(OS, head + ".HeroReady", value.HeroReady);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceMatchEnterMemberProperty value)
	{
		value = new SpaceMatchEnterMemberProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Player);
		ViGameSerializer<UInt8>.Read(IS, head, out value.FactionIdx);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Ready);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Hero);
		ViGameSerializer<UInt8>.Read(IS, head, out value.HeroReady);
	}
}
public static class SpaceCreatePropertySerializer
{
	public static void Append(ViOStream OS, SpaceCreateProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Owner);
		ViGameSerializer<Int16>.Append(OS, value.OwnerLevel);
		ViGameSerializer<ViString>.Append(OS, value.Note);
		ViGameSerializer<Int16>.Append(OS, value.ModLevel);
		ViGameSerializer<UInt8>.Append(OS, value.MatchType);
		ViGameSerializer<UInt8>.Append(OS, value.PKType);
		ViGameSerializer<UInt8>.Append(OS, value.Exitable);
		ViGameSerializer<UInt8>.Append(OS, value.EmptyDestroy);
		ViGameSerializer<UInt8>.Append(OS, value.EraseExitMember);
		ViGameSerializer<Int16>.Append(OS, value.MemberCountSup);
		ViGameSerializer<UInt8>.Append(OS, value.BroadcastPropertyToCenter);
		ViGameSerializer<double>.Append(OS, value.HeroHPMaxScale);
		ViGameSerializer<double>.Append(OS, value.NPCHPPercScale);
		ViGameSerializer<ViString>.Append(OS, value.ScriptList);
		ViGameSerializer<Int64Property>.Append(OS, value.ScriptValueList);
		ViGameSerializer<MatchSpaceMemberScoreProperty>.Append(OS, value.MatchScoreList);
	}
	public static void Read(ViIStream IS, out SpaceCreateProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Owner);
		ViGameSerializer<Int16>.Read(IS, out value.OwnerLevel);
		ViGameSerializer<ViString>.Read(IS, out value.Note);
		ViGameSerializer<Int16>.Read(IS, out value.ModLevel);
		ViGameSerializer<UInt8>.Read(IS, out value.MatchType);
		ViGameSerializer<UInt8>.Read(IS, out value.PKType);
		ViGameSerializer<UInt8>.Read(IS, out value.Exitable);
		ViGameSerializer<UInt8>.Read(IS, out value.EmptyDestroy);
		ViGameSerializer<UInt8>.Read(IS, out value.EraseExitMember);
		ViGameSerializer<Int16>.Read(IS, out value.MemberCountSup);
		ViGameSerializer<UInt8>.Read(IS, out value.BroadcastPropertyToCenter);
		ViGameSerializer<double>.Read(IS, out value.HeroHPMaxScale);
		ViGameSerializer<double>.Read(IS, out value.NPCHPPercScale);
		ViGameSerializer<ViString>.Read(IS, out value.ScriptList);
		ViGameSerializer<Int64Property>.Read(IS, out value.ScriptValueList);
		ViGameSerializer<MatchSpaceMemberScoreProperty>.Read(IS, out value.MatchScoreList);
	}
	public static bool Read(ViStringIStream IS, out SpaceCreateProperty value)
	{
		value = default(SpaceCreateProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Owner) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.OwnerLevel) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Note) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.ModLevel) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.MatchType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.PKType) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Exitable) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.EmptyDestroy) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.EraseExitMember) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.MemberCountSup) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.BroadcastPropertyToCenter) == false){return false;}
		if(ViGameSerializer<double>.Read(IS, out value.HeroHPMaxScale) == false){return false;}
		if(ViGameSerializer<double>.Read(IS, out value.NPCHPPercScale) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.ScriptList) == false){return false;}
		if(ViGameSerializer<Int64Property>.Read(IS, out value.ScriptValueList) == false){return false;}
		if(ViGameSerializer<MatchSpaceMemberScoreProperty>.Read(IS, out value.MatchScoreList) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, SpaceCreateProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Owner", value.Owner);
		ViGameSerializer<Int16>.Append(OS, head + ".OwnerLevel", value.OwnerLevel);
		ViGameSerializer<ViString>.Append(OS, head + ".Note", value.Note);
		ViGameSerializer<Int16>.Append(OS, head + ".ModLevel", value.ModLevel);
		ViGameSerializer<UInt8>.Append(OS, head + ".MatchType", value.MatchType);
		ViGameSerializer<UInt8>.Append(OS, head + ".PKType", value.PKType);
		ViGameSerializer<UInt8>.Append(OS, head + ".Exitable", value.Exitable);
		ViGameSerializer<UInt8>.Append(OS, head + ".EmptyDestroy", value.EmptyDestroy);
		ViGameSerializer<UInt8>.Append(OS, head + ".EraseExitMember", value.EraseExitMember);
		ViGameSerializer<Int16>.Append(OS, head + ".MemberCountSup", value.MemberCountSup);
		ViGameSerializer<UInt8>.Append(OS, head + ".BroadcastPropertyToCenter", value.BroadcastPropertyToCenter);
		ViGameSerializer<double>.Append(OS, head + ".HeroHPMaxScale", value.HeroHPMaxScale);
		ViGameSerializer<double>.Append(OS, head + ".NPCHPPercScale", value.NPCHPPercScale);
		ViGameSerializer<ViString>.Append(OS, head + ".ScriptList", value.ScriptList);
		ViGameSerializer<Int64Property>.Append(OS, head + ".ScriptValueList", value.ScriptValueList);
		ViGameSerializer<MatchSpaceMemberScoreProperty>.Append(OS, head + ".MatchScoreList", value.MatchScoreList);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out SpaceCreateProperty value)
	{
		value = new SpaceCreateProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Owner);
		ViGameSerializer<Int16>.Read(IS, head, out value.OwnerLevel);
		ViGameSerializer<ViString>.Read(IS, head, out value.Note);
		ViGameSerializer<Int16>.Read(IS, head, out value.ModLevel);
		ViGameSerializer<UInt8>.Read(IS, head, out value.MatchType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.PKType);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Exitable);
		ViGameSerializer<UInt8>.Read(IS, head, out value.EmptyDestroy);
		ViGameSerializer<UInt8>.Read(IS, head, out value.EraseExitMember);
		ViGameSerializer<Int16>.Read(IS, head, out value.MemberCountSup);
		ViGameSerializer<UInt8>.Read(IS, head, out value.BroadcastPropertyToCenter);
		ViGameSerializer<double>.Read(IS, head, out value.HeroHPMaxScale);
		ViGameSerializer<double>.Read(IS, head, out value.NPCHPPercScale);
		ViGameSerializer<ViString>.Read(IS, head, out value.ScriptList);
		ViGameSerializer<Int64Property>.Read(IS, head, out value.ScriptValueList);
		ViGameSerializer<MatchSpaceMemberScoreProperty>.Read(IS, head, out value.MatchScoreList);
	}
}
public static class NotifyPropertySerializer
{
	public static void Append(ViOStream OS, NotifyProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<Int64>.Append(OS, value.EndTime1970);
	}
	public static void Read(ViIStream IS, out NotifyProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime1970);
	}
	public static bool Read(ViStringIStream IS, out NotifyProperty value)
	{
		value = default(NotifyProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, NotifyProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime1970", value.EndTime1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out NotifyProperty value)
	{
		value = new NotifyProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime1970);
	}
}
public static class CellStatePropertySerializer
{
	public static void Append(ViOStream OS, CellStateProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, value.OnlineCount);
		ViGameSerializer<Int32>.Append(OS, value.BigSpaceCount);
		ViGameSerializer<Int32>.Append(OS, value.ActivitySpaceCount);
		ViGameSerializer<Int32>.Append(OS, value.PublicSmallSpaceCount);
		ViGameSerializer<Int32>.Append(OS, value.PrivateSmallSpaceCount);
	}
	public static void Read(ViIStream IS, out CellStateProperty value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.OnlineCount);
		ViGameSerializer<Int32>.Read(IS, out value.BigSpaceCount);
		ViGameSerializer<Int32>.Read(IS, out value.ActivitySpaceCount);
		ViGameSerializer<Int32>.Read(IS, out value.PublicSmallSpaceCount);
		ViGameSerializer<Int32>.Read(IS, out value.PrivateSmallSpaceCount);
	}
	public static bool Read(ViStringIStream IS, out CellStateProperty value)
	{
		value = default(CellStateProperty);
		if(ViGameSerializer<Int32>.Read(IS, out value.OnlineCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.BigSpaceCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ActivitySpaceCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PublicSmallSpaceCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PrivateSmallSpaceCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, CellStateProperty value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".OnlineCount", value.OnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + ".BigSpaceCount", value.BigSpaceCount);
		ViGameSerializer<Int32>.Append(OS, head + ".ActivitySpaceCount", value.ActivitySpaceCount);
		ViGameSerializer<Int32>.Append(OS, head + ".PublicSmallSpaceCount", value.PublicSmallSpaceCount);
		ViGameSerializer<Int32>.Append(OS, head + ".PrivateSmallSpaceCount", value.PrivateSmallSpaceCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out CellStateProperty value)
	{
		value = new CellStateProperty();
		ViGameSerializer<Int32>.Read(IS, head, out value.OnlineCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.BigSpaceCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.ActivitySpaceCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.PublicSmallSpaceCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.PrivateSmallSpaceCount);
	}
}
public static class DisableRecordPropertySerializer
{
	public static void Append(ViOStream OS, DisableRecordProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Value);
		ViGameSerializer<ViString>.Append(OS, value.Note);
		ViGameSerializer<Int64>.Append(OS, value.EndTime1970);
	}
	public static void Read(ViIStream IS, out DisableRecordProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Value);
		ViGameSerializer<ViString>.Read(IS, out value.Note);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime1970);
	}
	public static bool Read(ViStringIStream IS, out DisableRecordProperty value)
	{
		value = default(DisableRecordProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Value) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Note) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, DisableRecordProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Value", value.Value);
		ViGameSerializer<ViString>.Append(OS, head + ".Note", value.Note);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime1970", value.EndTime1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out DisableRecordProperty value)
	{
		value = new DisableRecordProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Value);
		ViGameSerializer<ViString>.Read(IS, head, out value.Note);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime1970);
	}
}
public static class EntityServerPropertySerializer
{
	public static void Append(ViOStream OS, EntityServerProperty value)
	{
		ViGameSerializer<UInt16>.Append(OS, value.Create);
		ViGameSerializer<UInt16>.Append(OS, value.Current);
		ViGameSerializer<Int64>.Append(OS, value.Time);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
	}
	public static void Read(ViIStream IS, out EntityServerProperty value)
	{
		ViGameSerializer<UInt16>.Read(IS, out value.Create);
		ViGameSerializer<UInt16>.Read(IS, out value.Current);
		ViGameSerializer<Int64>.Read(IS, out value.Time);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
	}
	public static bool Read(ViStringIStream IS, out EntityServerProperty value)
	{
		value = default(EntityServerProperty);
		if(ViGameSerializer<UInt16>.Read(IS, out value.Create) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.Current) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, EntityServerProperty value)
	{
		ViGameSerializer<UInt16>.Append(OS, head + ".Create", value.Create);
		ViGameSerializer<UInt16>.Append(OS, head + ".Current", value.Current);
		ViGameSerializer<Int64>.Append(OS, head + ".Time", value.Time);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out EntityServerProperty value)
	{
		value = new EntityServerProperty();
		ViGameSerializer<UInt16>.Read(IS, head, out value.Create);
		ViGameSerializer<UInt16>.Read(IS, head, out value.Current);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
	}
}
public static class MemoryUsePropertySerializer
{
	public static void Append(ViOStream OS, MemoryUseProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<UInt32>.Append(OS, value.Size);
		ViGameSerializer<Int32>.Append(OS, value.UseCount);
		ViGameSerializer<Int32>.Append(OS, value.ReserveCount);
	}
	public static void Read(ViIStream IS, out MemoryUseProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<UInt32>.Read(IS, out value.Size);
		ViGameSerializer<Int32>.Read(IS, out value.UseCount);
		ViGameSerializer<Int32>.Read(IS, out value.ReserveCount);
	}
	public static bool Read(ViStringIStream IS, out MemoryUseProperty value)
	{
		value = default(MemoryUseProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Size) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.UseCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ReserveCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, MemoryUseProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<UInt32>.Append(OS, head + ".Size", value.Size);
		ViGameSerializer<Int32>.Append(OS, head + ".UseCount", value.UseCount);
		ViGameSerializer<Int32>.Append(OS, head + ".ReserveCount", value.ReserveCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out MemoryUseProperty value)
	{
		value = new MemoryUseProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Size);
		ViGameSerializer<Int32>.Read(IS, head, out value.UseCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.ReserveCount);
	}
}
public static class AccountWithPlayerPropertySerializer
{
	public static void Append(ViOStream OS, AccountWithPlayerProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.AccountID);
		ViGameSerializer<ViString>.Append(OS, value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.RoleList);
		ViGameSerializer<ViString>.Append(OS, value.LastIP);
		ViGameSerializer<ViString>.Append(OS, value.LastMacAdress);
		ViGameSerializer<ViString>.Append(OS, value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, value.CDKey);
		ViGameSerializer<ViString>.Append(OS, value.CDKeyTag);
		ViGameSerializer<UInt64>.Append(OS, value.OnlineVersion);
		ViGameSerializer<ClientDeviceProperty>.Append(OS, value.ClientDeviceList);
	}
	public static void Read(ViIStream IS, out AccountWithPlayerProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.AccountID);
		ViGameSerializer<ViString>.Read(IS, out value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.RoleList);
		ViGameSerializer<ViString>.Read(IS, out value.LastIP);
		ViGameSerializer<ViString>.Read(IS, out value.LastMacAdress);
		ViGameSerializer<ViString>.Read(IS, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag);
		ViGameSerializer<UInt64>.Read(IS, out value.OnlineVersion);
		ViGameSerializer<ClientDeviceProperty>.Read(IS, out value.ClientDeviceList);
	}
	public static bool Read(ViStringIStream IS, out AccountWithPlayerProperty value)
	{
		value = default(AccountWithPlayerProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.AccountID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.AccountName) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.RoleList) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.LastIP) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.LastMacAdress) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceTag) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceDate) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKey) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.OnlineVersion) == false){return false;}
		if(ViGameSerializer<ClientDeviceProperty>.Read(IS, out value.ClientDeviceList) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, AccountWithPlayerProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".AccountID", value.AccountID);
		ViGameSerializer<ViString>.Append(OS, head + ".AccountName", value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".RoleList", value.RoleList);
		ViGameSerializer<ViString>.Append(OS, head + ".LastIP", value.LastIP);
		ViGameSerializer<ViString>.Append(OS, head + ".LastMacAdress", value.LastMacAdress);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceTag", value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceDate", value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKey", value.CDKey);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKeyTag", value.CDKeyTag);
		ViGameSerializer<UInt64>.Append(OS, head + ".OnlineVersion", value.OnlineVersion);
		ViGameSerializer<ClientDeviceProperty>.Append(OS, head + ".ClientDeviceList", value.ClientDeviceList);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out AccountWithPlayerProperty value)
	{
		value = new AccountWithPlayerProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.AccountID);
		ViGameSerializer<ViString>.Read(IS, head, out value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.RoleList);
		ViGameSerializer<ViString>.Read(IS, head, out value.LastIP);
		ViGameSerializer<ViString>.Read(IS, head, out value.LastMacAdress);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKeyTag);
		ViGameSerializer<UInt64>.Read(IS, head, out value.OnlineVersion);
		ViGameSerializer<ClientDeviceProperty>.Read(IS, head, out value.ClientDeviceList);
	}
}
public static class PlayerWithAccountPropertySerializer
{
	public static void Append(ViOStream OS, PlayerWithAccountProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, value.AccountID);
		ViGameSerializer<ViString>.Append(OS, value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Player);
		ViGameSerializer<ViString>.Append(OS, value.LastIP);
		ViGameSerializer<ViString>.Append(OS, value.LastMacAdress);
		ViGameSerializer<ViString>.Append(OS, value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, value.CDKey);
		ViGameSerializer<ViString>.Append(OS, value.CDKeyTag);
		ViGameSerializer<UInt64>.Append(OS, value.OnlineVersion);
	}
	public static void Read(ViIStream IS, out PlayerWithAccountProperty value)
	{
		ViGameSerializer<UInt64>.Read(IS, out value.AccountID);
		ViGameSerializer<ViString>.Read(IS, out value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player);
		ViGameSerializer<ViString>.Read(IS, out value.LastIP);
		ViGameSerializer<ViString>.Read(IS, out value.LastMacAdress);
		ViGameSerializer<ViString>.Read(IS, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag);
		ViGameSerializer<UInt64>.Read(IS, out value.OnlineVersion);
	}
	public static bool Read(ViStringIStream IS, out PlayerWithAccountProperty value)
	{
		value = default(PlayerWithAccountProperty);
		if(ViGameSerializer<UInt64>.Read(IS, out value.AccountID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.AccountName) == false){return false;}
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.LastIP) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.LastMacAdress) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceTag) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceDate) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKey) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.OnlineVersion) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerWithAccountProperty value)
	{
		ViGameSerializer<UInt64>.Append(OS, head + ".AccountID", value.AccountID);
		ViGameSerializer<ViString>.Append(OS, head + ".AccountName", value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Player", value.Player);
		ViGameSerializer<ViString>.Append(OS, head + ".LastIP", value.LastIP);
		ViGameSerializer<ViString>.Append(OS, head + ".LastMacAdress", value.LastMacAdress);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceTag", value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceDate", value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKey", value.CDKey);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKeyTag", value.CDKeyTag);
		ViGameSerializer<UInt64>.Append(OS, head + ".OnlineVersion", value.OnlineVersion);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerWithAccountProperty value)
	{
		value = new PlayerWithAccountProperty();
		ViGameSerializer<UInt64>.Read(IS, head, out value.AccountID);
		ViGameSerializer<ViString>.Read(IS, head, out value.AccountName);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Player);
		ViGameSerializer<ViString>.Read(IS, head, out value.LastIP);
		ViGameSerializer<ViString>.Read(IS, head, out value.LastMacAdress);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKeyTag);
		ViGameSerializer<UInt64>.Read(IS, head, out value.OnlineVersion);
	}
}
public static class PlayerOnlinePropertySerializer
{
	public static void Append(ViOStream OS, PlayerOnlineProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value.Player);
		ViGameSerializer<ViString>.Append(OS, value.AccountName);
		ViGameSerializer<ViString>.Append(OS, value.IP);
		ViGameSerializer<ViString>.Append(OS, value.MacAdress);
		ViGameSerializer<UInt32>.Append(OS, value.Space);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt32>.Append(OS, value.OnlineNumber);
		ViGameSerializer<ViString>.Append(OS, value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, value.CDKey);
		ViGameSerializer<ViString>.Append(OS, value.CDKeyTag);
		ViGameSerializer<UInt16>.Append(OS, value.AccessServerID);
		ViGameSerializer<UInt16>.Append(OS, value.HomeServerID);
		ViGameSerializer<UInt16>.Append(OS, value.ServerBaseID);
		ViGameSerializer<UInt16>.Append(OS, value.ServerCellID);
	}
	public static void Read(ViIStream IS, out PlayerOnlineProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player);
		ViGameSerializer<ViString>.Read(IS, out value.AccountName);
		ViGameSerializer<ViString>.Read(IS, out value.IP);
		ViGameSerializer<ViString>.Read(IS, out value.MacAdress);
		ViGameSerializer<UInt32>.Read(IS, out value.Space);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt32>.Read(IS, out value.OnlineNumber);
		ViGameSerializer<ViString>.Read(IS, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag);
		ViGameSerializer<UInt16>.Read(IS, out value.AccessServerID);
		ViGameSerializer<UInt16>.Read(IS, out value.HomeServerID);
		ViGameSerializer<UInt16>.Read(IS, out value.ServerBaseID);
		ViGameSerializer<UInt16>.Read(IS, out value.ServerCellID);
	}
	public static bool Read(ViStringIStream IS, out PlayerOnlineProperty value)
	{
		value = default(PlayerOnlineProperty);
		if(ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value.Player) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.AccountName) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.IP) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.MacAdress) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Space) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.OnlineNumber) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceTag) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceDate) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKey) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.AccessServerID) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.HomeServerID) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.ServerBaseID) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.ServerCellID) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerOnlineProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + ".Player", value.Player);
		ViGameSerializer<ViString>.Append(OS, head + ".AccountName", value.AccountName);
		ViGameSerializer<ViString>.Append(OS, head + ".IP", value.IP);
		ViGameSerializer<ViString>.Append(OS, head + ".MacAdress", value.MacAdress);
		ViGameSerializer<UInt32>.Append(OS, head + ".Space", value.Space);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt32>.Append(OS, head + ".OnlineNumber", value.OnlineNumber);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceTag", value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceDate", value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKey", value.CDKey);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKeyTag", value.CDKeyTag);
		ViGameSerializer<UInt16>.Append(OS, head + ".AccessServerID", value.AccessServerID);
		ViGameSerializer<UInt16>.Append(OS, head + ".HomeServerID", value.HomeServerID);
		ViGameSerializer<UInt16>.Append(OS, head + ".ServerBaseID", value.ServerBaseID);
		ViGameSerializer<UInt16>.Append(OS, head + ".ServerCellID", value.ServerCellID);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerOnlineProperty value)
	{
		value = new PlayerOnlineProperty();
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, head, out value.Player);
		ViGameSerializer<ViString>.Read(IS, head, out value.AccountName);
		ViGameSerializer<ViString>.Read(IS, head, out value.IP);
		ViGameSerializer<ViString>.Read(IS, head, out value.MacAdress);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Space);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt32>.Read(IS, head, out value.OnlineNumber);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKeyTag);
		ViGameSerializer<UInt16>.Read(IS, head, out value.AccessServerID);
		ViGameSerializer<UInt16>.Read(IS, head, out value.HomeServerID);
		ViGameSerializer<UInt16>.Read(IS, head, out value.ServerBaseID);
		ViGameSerializer<UInt16>.Read(IS, head, out value.ServerCellID);
	}
}
public static class GMStatisticValuePropertySerializer
{
	public static void Append(ViOStream OS, GMStatisticValueProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.ID);
		ViGameSerializer<Int64>.Append(OS, value.Count);
		ViGameSerializer<Int64>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out GMStatisticValueProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.ID);
		ViGameSerializer<Int64>.Read(IS, out value.Count);
		ViGameSerializer<Int64>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out GMStatisticValueProperty value)
	{
		value = default(GMStatisticValueProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Count) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GMStatisticValueProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<Int64>.Append(OS, head + ".Count", value.Count);
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GMStatisticValueProperty value)
	{
		value = new GMStatisticValueProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.ID);
		ViGameSerializer<Int64>.Read(IS, head, out value.Count);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
	}
}
public static class GMStatisticValuePropertyListSerializer
{
	public static void Append(ViOStream OS, GMStatisticValuePropertyList value)
	{
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveXPListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveXPListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveXPListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveXPListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveYinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveYinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveYinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveYinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveJinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveJinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveJinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveJinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveItemListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveItemListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveItemListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveItemListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveItemListInShop);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.ReceiveItemListInMarket);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, value.TradeItemListInMarket);
	}
	public static void Read(ViIStream IS, out GMStatisticValuePropertyList value)
	{
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInShop);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInMarket);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.TradeItemListInMarket);
	}
	public static bool Read(ViStringIStream IS, out GMStatisticValuePropertyList value)
	{
		value = default(GMStatisticValuePropertyList);
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInNPC) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInQuest) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInLoot) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveXPListInActivity) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInNPC) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInQuest) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInLoot) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveYinPiaoListInActivity) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInNPC) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInQuest) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInLoot) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveJinPiaoListInActivity) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInNPC) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInQuest) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInLoot) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInActivity) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInShop) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.ReceiveItemListInMarket) == false){return false;}
		if(ViGameSerializer<GMStatisticValueProperty>.Read(IS, out value.TradeItemListInMarket) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GMStatisticValuePropertyList value)
	{
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveXPListInNPC", value.ReceiveXPListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveXPListInQuest", value.ReceiveXPListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveXPListInLoot", value.ReceiveXPListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveXPListInActivity", value.ReceiveXPListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveYinPiaoListInNPC", value.ReceiveYinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveYinPiaoListInQuest", value.ReceiveYinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveYinPiaoListInLoot", value.ReceiveYinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveYinPiaoListInActivity", value.ReceiveYinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveJinPiaoListInNPC", value.ReceiveJinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveJinPiaoListInQuest", value.ReceiveJinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveJinPiaoListInLoot", value.ReceiveJinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveJinPiaoListInActivity", value.ReceiveJinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveItemListInNPC", value.ReceiveItemListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveItemListInQuest", value.ReceiveItemListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveItemListInLoot", value.ReceiveItemListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveItemListInActivity", value.ReceiveItemListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveItemListInShop", value.ReceiveItemListInShop);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".ReceiveItemListInMarket", value.ReceiveItemListInMarket);
		ViGameSerializer<GMStatisticValueProperty>.Append(OS, head + ".TradeItemListInMarket", value.TradeItemListInMarket);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GMStatisticValuePropertyList value)
	{
		value = new GMStatisticValuePropertyList();
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveXPListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveXPListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveXPListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveXPListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveYinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveYinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveYinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveYinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveJinPiaoListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveJinPiaoListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveJinPiaoListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveJinPiaoListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveItemListInNPC);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveItemListInQuest);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveItemListInLoot);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveItemListInActivity);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveItemListInShop);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.ReceiveItemListInMarket);
		ViGameSerializer<GMStatisticValueProperty>.Read(IS, head, out value.TradeItemListInMarket);
	}
}
public static class PlayerGMViewPropertySerializer
{
	public static void Append(ViOStream OS, PlayerGMViewProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Name);
		ViGameSerializer<ViString>.Append(OS, value.NameAlias);
		ViGameSerializer<UInt64>.Append(OS, value.AccountID);
		ViGameSerializer<ViString>.Append(OS, value.AccountName);
		ViGameSerializer<ViString>.Append(OS, value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, value.CDKey);
		ViGameSerializer<ViString>.Append(OS, value.CDKeyTag);
		ViGameSerializer<UInt8>.Append(OS, value.Online);
		ViGameSerializer<UInt64>.Append(OS, value.OnlineVersion);
		ViGameSerializer<Int64>.Append(OS, value.CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, value.LastOnlineTime1970);
		ViGameSerializer<Int64>.Append(OS, value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, value.CurrentDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, value.AccumulateLoginDayCount);
		ViGameSerializer<Int64>.Append(OS, value.AccumulateOnlineDuration);
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<UInt8>.Append(OS, value.Gender);
		ViGameSerializer<ItemProperty>.Append(OS, value.Inventory);
		ViGameSerializer<ItemProperty>.Append(OS, value.Equipments);
		ViGameSerializer<UInt8Property>.Append(OS, value.PaymentStateList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.JinZiPaymentRecordList);
		ViGameSerializer<GMStatisticValuePropertyList>.Append(OS, value.StatisticsValueList);
		ViGameSerializer<SpaceRecordProperty>.Append(OS, value.SpaceRecordList);
	}
	public static void Read(ViIStream IS, out PlayerGMViewProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Name);
		ViGameSerializer<ViString>.Read(IS, out value.NameAlias);
		ViGameSerializer<UInt64>.Read(IS, out value.AccountID);
		ViGameSerializer<ViString>.Read(IS, out value.AccountName);
		ViGameSerializer<ViString>.Read(IS, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag);
		ViGameSerializer<UInt8>.Read(IS, out value.Online);
		ViGameSerializer<UInt64>.Read(IS, out value.OnlineVersion);
		ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.LastOnlineTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, out value.CurrentDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out value.AccumulateLoginDayCount);
		ViGameSerializer<Int64>.Read(IS, out value.AccumulateOnlineDuration);
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, out value.Gender);
		ViGameSerializer<ItemProperty>.Read(IS, out value.Inventory);
		ViGameSerializer<ItemProperty>.Read(IS, out value.Equipments);
		ViGameSerializer<UInt8Property>.Read(IS, out value.PaymentStateList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinZiPaymentRecordList);
		ViGameSerializer<GMStatisticValuePropertyList>.Read(IS, out value.StatisticsValueList);
		ViGameSerializer<SpaceRecordProperty>.Read(IS, out value.SpaceRecordList);
	}
	public static bool Read(ViStringIStream IS, out PlayerGMViewProperty value)
	{
		value = default(PlayerGMViewProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Name) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.NameAlias) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.AccountID) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.AccountName) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceTag) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.SourceDate) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKey) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.CDKeyTag) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Online) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.OnlineVersion) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CreateTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastOnlineTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CreateDayNumber1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CurrentDayNumber1970) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AccumulateLoginDayCount) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AccumulateOnlineDuration) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.Gender) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.Inventory) == false){return false;}
		if(ViGameSerializer<ItemProperty>.Read(IS, out value.Equipments) == false){return false;}
		if(ViGameSerializer<UInt8Property>.Read(IS, out value.PaymentStateList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.YinPiaoPaymentRecordList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinPiaoPaymentRecordList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinZiPaymentRecordList) == false){return false;}
		if(ViGameSerializer<GMStatisticValuePropertyList>.Read(IS, out value.StatisticsValueList) == false){return false;}
		if(ViGameSerializer<SpaceRecordProperty>.Read(IS, out value.SpaceRecordList) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerGMViewProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Name", value.Name);
		ViGameSerializer<ViString>.Append(OS, head + ".NameAlias", value.NameAlias);
		ViGameSerializer<UInt64>.Append(OS, head + ".AccountID", value.AccountID);
		ViGameSerializer<ViString>.Append(OS, head + ".AccountName", value.AccountName);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceTag", value.SourceTag);
		ViGameSerializer<ViString>.Append(OS, head + ".SourceDate", value.SourceDate);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKey", value.CDKey);
		ViGameSerializer<ViString>.Append(OS, head + ".CDKeyTag", value.CDKeyTag);
		ViGameSerializer<UInt8>.Append(OS, head + ".Online", value.Online);
		ViGameSerializer<UInt64>.Append(OS, head + ".OnlineVersion", value.OnlineVersion);
		ViGameSerializer<Int64>.Append(OS, head + ".CreateTime1970", value.CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".LastOnlineTime1970", value.LastOnlineTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".CreateDayNumber1970", value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, head + ".CurrentDayNumber1970", value.CurrentDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + ".AccumulateLoginDayCount", value.AccumulateLoginDayCount);
		ViGameSerializer<Int64>.Append(OS, head + ".AccumulateOnlineDuration", value.AccumulateOnlineDuration);
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<UInt8>.Append(OS, head + ".Gender", value.Gender);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".Inventory", value.Inventory);
		ViGameSerializer<ItemProperty>.Append(OS, head + ".Equipments", value.Equipments);
		ViGameSerializer<UInt8Property>.Append(OS, head + ".PaymentStateList", value.PaymentStateList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".YinPiaoPaymentRecordList", value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".JinPiaoPaymentRecordList", value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".JinZiPaymentRecordList", value.JinZiPaymentRecordList);
		ViGameSerializer<GMStatisticValuePropertyList>.Append(OS, head + ".StatisticsValueList", value.StatisticsValueList);
		ViGameSerializer<SpaceRecordProperty>.Append(OS, head + ".SpaceRecordList", value.SpaceRecordList);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerGMViewProperty value)
	{
		value = new PlayerGMViewProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Name);
		ViGameSerializer<ViString>.Read(IS, head, out value.NameAlias);
		ViGameSerializer<UInt64>.Read(IS, head, out value.AccountID);
		ViGameSerializer<ViString>.Read(IS, head, out value.AccountName);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceTag);
		ViGameSerializer<ViString>.Read(IS, head, out value.SourceDate);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKey);
		ViGameSerializer<ViString>.Read(IS, head, out value.CDKeyTag);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Online);
		ViGameSerializer<UInt64>.Read(IS, head, out value.OnlineVersion);
		ViGameSerializer<Int64>.Read(IS, head, out value.CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastOnlineTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.CreateDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.CurrentDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, head, out value.AccumulateLoginDayCount);
		ViGameSerializer<Int64>.Read(IS, head, out value.AccumulateOnlineDuration);
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<UInt8>.Read(IS, head, out value.Gender);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.Inventory);
		ViGameSerializer<ItemProperty>.Read(IS, head, out value.Equipments);
		ViGameSerializer<UInt8Property>.Read(IS, head, out value.PaymentStateList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.JinZiPaymentRecordList);
		ViGameSerializer<GMStatisticValuePropertyList>.Read(IS, head, out value.StatisticsValueList);
		ViGameSerializer<SpaceRecordProperty>.Read(IS, head, out value.SpaceRecordList);
	}
}
public static class QuestGameRecordPropertySerializer
{
	public static void Append(ViOStream OS, QuestGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Quest);
		ViGameSerializer<Int64>.Append(OS, value.ReceiveCount);
		ViGameSerializer<Int64>.Append(OS, value.CommitCount);
	}
	public static void Read(ViIStream IS, out QuestGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Quest);
		ViGameSerializer<Int64>.Read(IS, out value.ReceiveCount);
		ViGameSerializer<Int64>.Read(IS, out value.CommitCount);
	}
	public static bool Read(ViStringIStream IS, out QuestGameRecordProperty value)
	{
		value = default(QuestGameRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Quest) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ReceiveCount) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.CommitCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, QuestGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Quest", value.Quest);
		ViGameSerializer<Int64>.Append(OS, head + ".ReceiveCount", value.ReceiveCount);
		ViGameSerializer<Int64>.Append(OS, head + ".CommitCount", value.CommitCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out QuestGameRecordProperty value)
	{
		value = new QuestGameRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Quest);
		ViGameSerializer<Int64>.Read(IS, head, out value.ReceiveCount);
		ViGameSerializer<Int64>.Read(IS, head, out value.CommitCount);
	}
}
public static class ItemGameRecordPropertySerializer
{
	public static void Append(ViOStream OS, ItemGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Item);
		ViGameSerializer<Int64>.Append(OS, value.ReceiveCount);
		ViGameSerializer<Int64>.Append(OS, value.ComsumeCount);
		ViGameSerializer<Int64>.Append(OS, value.AbandonCount);
	}
	public static void Read(ViIStream IS, out ItemGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Item);
		ViGameSerializer<Int64>.Read(IS, out value.ReceiveCount);
		ViGameSerializer<Int64>.Read(IS, out value.ComsumeCount);
		ViGameSerializer<Int64>.Read(IS, out value.AbandonCount);
	}
	public static bool Read(ViStringIStream IS, out ItemGameRecordProperty value)
	{
		value = default(ItemGameRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Item) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ReceiveCount) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.ComsumeCount) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.AbandonCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ItemGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Item", value.Item);
		ViGameSerializer<Int64>.Append(OS, head + ".ReceiveCount", value.ReceiveCount);
		ViGameSerializer<Int64>.Append(OS, head + ".ComsumeCount", value.ComsumeCount);
		ViGameSerializer<Int64>.Append(OS, head + ".AbandonCount", value.AbandonCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ItemGameRecordProperty value)
	{
		value = new ItemGameRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Item);
		ViGameSerializer<Int64>.Read(IS, head, out value.ReceiveCount);
		ViGameSerializer<Int64>.Read(IS, head, out value.ComsumeCount);
		ViGameSerializer<Int64>.Read(IS, head, out value.AbandonCount);
	}
}
public static class PaymentGameRecordPropertySerializer
{
	public static void Append(ViOStream OS, PaymentGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Type);
		ViGameSerializer<Int64>.Append(OS, value.Value);
		ViGameSerializer<Int64>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out PaymentGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Type);
		ViGameSerializer<Int64>.Read(IS, out value.Value);
		ViGameSerializer<Int64>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out PaymentGameRecordProperty value)
	{
		value = default(PaymentGameRecordProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Type) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Value) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PaymentGameRecordProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Type", value.Type);
		ViGameSerializer<Int64>.Append(OS, head + ".Value", value.Value);
		ViGameSerializer<Int64>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PaymentGameRecordProperty value)
	{
		value = new PaymentGameRecordProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Type);
		ViGameSerializer<Int64>.Read(IS, head, out value.Value);
		ViGameSerializer<Int64>.Read(IS, head, out value.Count);
	}
}
public static class PlayerLevelCountPropertySerializer
{
	public static void Append(ViOStream OS, PlayerLevelCountProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, value.Level);
		ViGameSerializer<Int32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out PlayerLevelCountProperty value)
	{
		ViGameSerializer<Int16>.Read(IS, out value.Level);
		ViGameSerializer<Int32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out PlayerLevelCountProperty value)
	{
		value = default(PlayerLevelCountProperty);
		if(ViGameSerializer<Int16>.Read(IS, out value.Level) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, PlayerLevelCountProperty value)
	{
		ViGameSerializer<Int16>.Append(OS, head + ".Level", value.Level);
		ViGameSerializer<Int32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out PlayerLevelCountProperty value)
	{
		value = new PlayerLevelCountProperty();
		ViGameSerializer<Int16>.Read(IS, head, out value.Level);
		ViGameSerializer<Int32>.Read(IS, head, out value.Count);
	}
}
public static class BoardPropertySerializer
{
	public static void Append(ViOStream OS, BoardProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.StartTime1970);
		ViGameSerializer<Int64>.Append(OS, value.EndTime1970);
		ViGameSerializer<Int64>.Append(OS, value.Span);
		ViGameSerializer<UInt8>.Append(OS, value.LoopType);
		ViGameSerializer<ViString>.Append(OS, value.Content);
	}
	public static void Read(ViIStream IS, out BoardProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.StartTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime1970);
		ViGameSerializer<Int64>.Read(IS, out value.Span);
		ViGameSerializer<UInt8>.Read(IS, out value.LoopType);
		ViGameSerializer<ViString>.Read(IS, out value.Content);
	}
	public static bool Read(ViStringIStream IS, out BoardProperty value)
	{
		value = default(BoardProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Span) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.LoopType) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Content) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, BoardProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime1970", value.StartTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime1970", value.EndTime1970);
		ViGameSerializer<Int64>.Append(OS, head + ".Span", value.Span);
		ViGameSerializer<UInt8>.Append(OS, head + ".LoopType", value.LoopType);
		ViGameSerializer<ViString>.Append(OS, head + ".Content", value.Content);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out BoardProperty value)
	{
		value = new BoardProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.Span);
		ViGameSerializer<UInt8>.Read(IS, head, out value.LoopType);
		ViGameSerializer<ViString>.Read(IS, head, out value.Content);
	}
}
public static class GameNotePropertySerializer
{
	public static void Append(ViOStream OS, GameNoteProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ViString>.Append(OS, value.Title);
		ViGameSerializer<ViString>.Append(OS, value.Content);
	}
	public static void Read(ViIStream IS, out GameNoteProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, out value.Title);
		ViGameSerializer<ViString>.Read(IS, out value.Content);
	}
	public static bool Read(ViStringIStream IS, out GameNoteProperty value)
	{
		value = default(GameNoteProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Title) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Content) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GameNoteProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ViString>.Append(OS, head + ".Title", value.Title);
		ViGameSerializer<ViString>.Append(OS, head + ".Content", value.Content);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GameNoteProperty value)
	{
		value = new GameNoteProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, head, out value.Title);
		ViGameSerializer<ViString>.Read(IS, head, out value.Content);
	}
}
public static class RechargeInGameRecordPropertySerializer
{
	public static void Append(ViOStream OS, RechargeInGameRecordProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.Account);
		ViGameSerializer<Int64>.Append(OS, value.LastTime);
		ViGameSerializer<Int64>.Append(OS, value.LastValue);
		ViGameSerializer<Int64>.Append(OS, value.TotalValue);
	}
	public static void Read(ViIStream IS, out RechargeInGameRecordProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.Account);
		ViGameSerializer<Int64>.Read(IS, out value.LastTime);
		ViGameSerializer<Int64>.Read(IS, out value.LastValue);
		ViGameSerializer<Int64>.Read(IS, out value.TotalValue);
	}
	public static bool Read(ViStringIStream IS, out RechargeInGameRecordProperty value)
	{
		value = default(RechargeInGameRecordProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.Account) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastTime) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.LastValue) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.TotalValue) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, RechargeInGameRecordProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".Account", value.Account);
		ViGameSerializer<Int64>.Append(OS, head + ".LastTime", value.LastTime);
		ViGameSerializer<Int64>.Append(OS, head + ".LastValue", value.LastValue);
		ViGameSerializer<Int64>.Append(OS, head + ".TotalValue", value.TotalValue);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out RechargeInGameRecordProperty value)
	{
		value = new RechargeInGameRecordProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.Account);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastTime);
		ViGameSerializer<Int64>.Read(IS, head, out value.LastValue);
		ViGameSerializer<Int64>.Read(IS, head, out value.TotalValue);
	}
}
public static class ServerBaseViewPropertySerializer
{
	public static void Append(ViOStream OS, ServerBaseViewProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.ServerName);
		ViGameSerializer<UInt16>.Append(OS, value.ID);
		ViGameSerializer<Int64>.Append(OS, value.Time);
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<Int64>.Append(OS, value.StartTime1970);
		ViGameSerializer<UInt64>.Append(OS, value.Fragment0RecordID);
		ViGameSerializer<UInt64>.Append(OS, value.Fragment1RecordID);
		ViGameSerializer<Int32>.Append(OS, value.PlayerCount);
		ViGameSerializer<Int32>.Append(OS, value.AccountCount);
		ViGameSerializer<Int32>.Append(OS, value.GuildCount);
		ViGameSerializer<Int32>.Append(OS, value.OnlineCount);
		ViGameSerializer<Int32>.Append(OS, value.MaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, value.DayMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, value.WeekMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, value.MonthMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, value.DayLoginCount);
		ViGameSerializer<Int32>.Append(OS, value.WeekLoginCount);
		ViGameSerializer<Int32>.Append(OS, value.MonthLoginCount);
		ViGameSerializer<Int32>.Append(OS, value.DayNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, value.WeekNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, value.MonthNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, value.DayNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, value.WeekNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, value.MonthNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, value.DayNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, value.WeekNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, value.MonthNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, value.LuckLootDayCount);
		ViGameSerializer<Int32>.Append(OS, value.LuckLootAccumulateCount);
		ViGameSerializer<Int32>.Append(OS, value.EntityCount);
		ViGameSerializer<Int32>.Append(OS, value.EntityIDCount);
		ViGameSerializer<Int32>.Append(OS, value.EntityPackIDCount);
		ViGameSerializer<Int32>.Append(OS, value.SpaceCount);
	}
	public static void Read(ViIStream IS, out ServerBaseViewProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.ServerName);
		ViGameSerializer<UInt16>.Read(IS, out value.ID);
		ViGameSerializer<Int64>.Read(IS, out value.Time);
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<Int64>.Read(IS, out value.StartTime1970);
		ViGameSerializer<UInt64>.Read(IS, out value.Fragment0RecordID);
		ViGameSerializer<UInt64>.Read(IS, out value.Fragment1RecordID);
		ViGameSerializer<Int32>.Read(IS, out value.PlayerCount);
		ViGameSerializer<Int32>.Read(IS, out value.AccountCount);
		ViGameSerializer<Int32>.Read(IS, out value.GuildCount);
		ViGameSerializer<Int32>.Read(IS, out value.OnlineCount);
		ViGameSerializer<Int32>.Read(IS, out value.MaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out value.DayMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out value.WeekMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out value.MonthMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out value.DayLoginCount);
		ViGameSerializer<Int32>.Read(IS, out value.WeekLoginCount);
		ViGameSerializer<Int32>.Read(IS, out value.MonthLoginCount);
		ViGameSerializer<Int32>.Read(IS, out value.DayNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out value.WeekNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out value.MonthNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out value.DayNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out value.WeekNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out value.MonthNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out value.DayNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out value.WeekNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out value.MonthNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out value.LuckLootDayCount);
		ViGameSerializer<Int32>.Read(IS, out value.LuckLootAccumulateCount);
		ViGameSerializer<Int32>.Read(IS, out value.EntityCount);
		ViGameSerializer<Int32>.Read(IS, out value.EntityIDCount);
		ViGameSerializer<Int32>.Read(IS, out value.EntityPackIDCount);
		ViGameSerializer<Int32>.Read(IS, out value.SpaceCount);
	}
	public static bool Read(ViStringIStream IS, out ServerBaseViewProperty value)
	{
		value = default(ServerBaseViewProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.ServerName) == false){return false;}
		if(ViGameSerializer<UInt16>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.StartTime1970) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.Fragment0RecordID) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.Fragment1RecordID) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.PlayerCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.AccountCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.GuildCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.OnlineCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MaxOnlineCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.DayMaxOnlineCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WeekMaxOnlineCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MonthMaxOnlineCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.DayLoginCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WeekLoginCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MonthLoginCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.DayNewAccountCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WeekNewAccountCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MonthNewAccountCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.DayNewPlayerCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WeekNewPlayerCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MonthNewPlayerCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.DayNewGuildCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WeekNewGuildCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.MonthNewGuildCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.LuckLootDayCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.LuckLootAccumulateCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.EntityCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.EntityIDCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.EntityPackIDCount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.SpaceCount) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ServerBaseViewProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".ServerName", value.ServerName);
		ViGameSerializer<UInt16>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<Int64>.Append(OS, head + ".Time", value.Time);
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<Int64>.Append(OS, head + ".StartTime1970", value.StartTime1970);
		ViGameSerializer<UInt64>.Append(OS, head + ".Fragment0RecordID", value.Fragment0RecordID);
		ViGameSerializer<UInt64>.Append(OS, head + ".Fragment1RecordID", value.Fragment1RecordID);
		ViGameSerializer<Int32>.Append(OS, head + ".PlayerCount", value.PlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + ".AccountCount", value.AccountCount);
		ViGameSerializer<Int32>.Append(OS, head + ".GuildCount", value.GuildCount);
		ViGameSerializer<Int32>.Append(OS, head + ".OnlineCount", value.OnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MaxOnlineCount", value.MaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + ".DayMaxOnlineCount", value.DayMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + ".WeekMaxOnlineCount", value.WeekMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MonthMaxOnlineCount", value.MonthMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + ".DayLoginCount", value.DayLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + ".WeekLoginCount", value.WeekLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MonthLoginCount", value.MonthLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + ".DayNewAccountCount", value.DayNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + ".WeekNewAccountCount", value.WeekNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MonthNewAccountCount", value.MonthNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + ".DayNewPlayerCount", value.DayNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + ".WeekNewPlayerCount", value.WeekNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MonthNewPlayerCount", value.MonthNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + ".DayNewGuildCount", value.DayNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + ".WeekNewGuildCount", value.WeekNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + ".MonthNewGuildCount", value.MonthNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + ".LuckLootDayCount", value.LuckLootDayCount);
		ViGameSerializer<Int32>.Append(OS, head + ".LuckLootAccumulateCount", value.LuckLootAccumulateCount);
		ViGameSerializer<Int32>.Append(OS, head + ".EntityCount", value.EntityCount);
		ViGameSerializer<Int32>.Append(OS, head + ".EntityIDCount", value.EntityIDCount);
		ViGameSerializer<Int32>.Append(OS, head + ".EntityPackIDCount", value.EntityPackIDCount);
		ViGameSerializer<Int32>.Append(OS, head + ".SpaceCount", value.SpaceCount);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ServerBaseViewProperty value)
	{
		value = new ServerBaseViewProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.ServerName);
		ViGameSerializer<UInt16>.Read(IS, head, out value.ID);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time);
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<Int64>.Read(IS, head, out value.StartTime1970);
		ViGameSerializer<UInt64>.Read(IS, head, out value.Fragment0RecordID);
		ViGameSerializer<UInt64>.Read(IS, head, out value.Fragment1RecordID);
		ViGameSerializer<Int32>.Read(IS, head, out value.PlayerCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.AccountCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.GuildCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.OnlineCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.DayMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.WeekMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MonthMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.DayLoginCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.WeekLoginCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MonthLoginCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.DayNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.WeekNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MonthNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.DayNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.WeekNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MonthNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.DayNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.WeekNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.MonthNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.LuckLootDayCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.LuckLootAccumulateCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.EntityCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.EntityIDCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.EntityPackIDCount);
		ViGameSerializer<Int32>.Read(IS, head, out value.SpaceCount);
	}
}
public static class GMContentPropertySerializer
{
	public static void Append(ViOStream OS, GMContentProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, value.State);
		ViGameSerializer<UInt64>.Append(OS, value.Time1970);
		ViGameSerializer<ViString>.Append(OS, value.Requestor);
		ViGameSerializer<ViString>.Append(OS, value.Confirmer);
		ViGameSerializer<UInt64>.Append(OS, value.StartTime);
		ViGameSerializer<UInt64>.Append(OS, value.EndTime);
		ViGameSerializer<ViString>.Append(OS, value.Func);
		ViGameSerializer<ViString>.Append(OS, value.Params);
	}
	public static void Read(ViIStream IS, out GMContentProperty value)
	{
		ViGameSerializer<UInt8>.Read(IS, out value.State);
		ViGameSerializer<UInt64>.Read(IS, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, out value.Requestor);
		ViGameSerializer<ViString>.Read(IS, out value.Confirmer);
		ViGameSerializer<UInt64>.Read(IS, out value.StartTime);
		ViGameSerializer<UInt64>.Read(IS, out value.EndTime);
		ViGameSerializer<ViString>.Read(IS, out value.Func);
		ViGameSerializer<ViString>.Read(IS, out value.Params);
	}
	public static bool Read(ViStringIStream IS, out GMContentProperty value)
	{
		value = default(GMContentProperty);
		if(ViGameSerializer<UInt8>.Read(IS, out value.State) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Requestor) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Confirmer) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.StartTime) == false){return false;}
		if(ViGameSerializer<UInt64>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Func) == false){return false;}
		if(ViGameSerializer<ViString>.Read(IS, out value.Params) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GMContentProperty value)
	{
		ViGameSerializer<UInt8>.Append(OS, head + ".State", value.State);
		ViGameSerializer<UInt64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ViString>.Append(OS, head + ".Requestor", value.Requestor);
		ViGameSerializer<ViString>.Append(OS, head + ".Confirmer", value.Confirmer);
		ViGameSerializer<UInt64>.Append(OS, head + ".StartTime", value.StartTime);
		ViGameSerializer<UInt64>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<ViString>.Append(OS, head + ".Func", value.Func);
		ViGameSerializer<ViString>.Append(OS, head + ".Params", value.Params);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GMContentProperty value)
	{
		value = new GMContentProperty();
		ViGameSerializer<UInt8>.Read(IS, head, out value.State);
		ViGameSerializer<UInt64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ViString>.Read(IS, head, out value.Requestor);
		ViGameSerializer<ViString>.Read(IS, head, out value.Confirmer);
		ViGameSerializer<UInt64>.Read(IS, head, out value.StartTime);
		ViGameSerializer<UInt64>.Read(IS, head, out value.EndTime);
		ViGameSerializer<ViString>.Read(IS, head, out value.Func);
		ViGameSerializer<ViString>.Read(IS, head, out value.Params);
	}
}
public static class GMRequestPropertySerializer
{
	public static void Append(ViOStream OS, GMRequestProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.OccupationMask);
		ViGameSerializer<Int16>.Append(OS, value.LevelInf);
		ViGameSerializer<Int16>.Append(OS, value.LevelSup);
		ViGameSerializer<UInt32>.Append(OS, value.QuestReceived);
		ViGameSerializer<UInt32>.Append(OS, value.QuestNotReceived);
		ViGameSerializer<UInt32>.Append(OS, value.QuestCompleted);
		ViGameSerializer<UInt32>.Append(OS, value.QuestNotCompleted);
		ViGameSerializer<UInt32>.Append(OS, value.FuncOpened);
		ViGameSerializer<UInt32>.Append(OS, value.FuncNotOpened);
	}
	public static void Read(ViIStream IS, out GMRequestProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.OccupationMask);
		ViGameSerializer<Int16>.Read(IS, out value.LevelInf);
		ViGameSerializer<Int16>.Read(IS, out value.LevelSup);
		ViGameSerializer<UInt32>.Read(IS, out value.QuestReceived);
		ViGameSerializer<UInt32>.Read(IS, out value.QuestNotReceived);
		ViGameSerializer<UInt32>.Read(IS, out value.QuestCompleted);
		ViGameSerializer<UInt32>.Read(IS, out value.QuestNotCompleted);
		ViGameSerializer<UInt32>.Read(IS, out value.FuncOpened);
		ViGameSerializer<UInt32>.Read(IS, out value.FuncNotOpened);
	}
	public static bool Read(ViStringIStream IS, out GMRequestProperty value)
	{
		value = default(GMRequestProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.OccupationMask) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.LevelInf) == false){return false;}
		if(ViGameSerializer<Int16>.Read(IS, out value.LevelSup) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.QuestReceived) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.QuestNotReceived) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.QuestCompleted) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.QuestNotCompleted) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.FuncOpened) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.FuncNotOpened) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GMRequestProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".OccupationMask", value.OccupationMask);
		ViGameSerializer<Int16>.Append(OS, head + ".LevelInf", value.LevelInf);
		ViGameSerializer<Int16>.Append(OS, head + ".LevelSup", value.LevelSup);
		ViGameSerializer<UInt32>.Append(OS, head + ".QuestReceived", value.QuestReceived);
		ViGameSerializer<UInt32>.Append(OS, head + ".QuestNotReceived", value.QuestNotReceived);
		ViGameSerializer<UInt32>.Append(OS, head + ".QuestCompleted", value.QuestCompleted);
		ViGameSerializer<UInt32>.Append(OS, head + ".QuestNotCompleted", value.QuestNotCompleted);
		ViGameSerializer<UInt32>.Append(OS, head + ".FuncOpened", value.FuncOpened);
		ViGameSerializer<UInt32>.Append(OS, head + ".FuncNotOpened", value.FuncNotOpened);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GMRequestProperty value)
	{
		value = new GMRequestProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.OccupationMask);
		ViGameSerializer<Int16>.Read(IS, head, out value.LevelInf);
		ViGameSerializer<Int16>.Read(IS, head, out value.LevelSup);
		ViGameSerializer<UInt32>.Read(IS, head, out value.QuestReceived);
		ViGameSerializer<UInt32>.Read(IS, head, out value.QuestNotReceived);
		ViGameSerializer<UInt32>.Read(IS, head, out value.QuestCompleted);
		ViGameSerializer<UInt32>.Read(IS, head, out value.QuestNotCompleted);
		ViGameSerializer<UInt32>.Read(IS, head, out value.FuncOpened);
		ViGameSerializer<UInt32>.Read(IS, head, out value.FuncNotOpened);
	}
}
public static class GMRequestContentPropertySerializer
{
	public static void Append(ViOStream OS, GMRequestContentProperty value)
	{
		ViGameSerializer<GMRequestProperty>.Append(OS, value.Request);
		ViGameSerializer<GMContentProperty>.Append(OS, value.Content);
	}
	public static void Read(ViIStream IS, out GMRequestContentProperty value)
	{
		ViGameSerializer<GMRequestProperty>.Read(IS, out value.Request);
		ViGameSerializer<GMContentProperty>.Read(IS, out value.Content);
	}
	public static bool Read(ViStringIStream IS, out GMRequestContentProperty value)
	{
		value = default(GMRequestContentProperty);
		if(ViGameSerializer<GMRequestProperty>.Read(IS, out value.Request) == false){return false;}
		if(ViGameSerializer<GMContentProperty>.Read(IS, out value.Content) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GMRequestContentProperty value)
	{
		ViGameSerializer<GMRequestProperty>.Append(OS, head + ".Request", value.Request);
		ViGameSerializer<GMContentProperty>.Append(OS, head + ".Content", value.Content);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GMRequestContentProperty value)
	{
		value = new GMRequestContentProperty();
		ViGameSerializer<GMRequestProperty>.Read(IS, head, out value.Request);
		ViGameSerializer<GMContentProperty>.Read(IS, head, out value.Content);
	}
}
public static class GMRequestMailPropertySerializer
{
	public static void Append(ViOStream OS, GMRequestMailProperty value)
	{
		ViGameSerializer<GMRequestProperty>.Append(OS, value.Request);
		ViGameSerializer<MailProperty>.Append(OS, value.Content);
	}
	public static void Read(ViIStream IS, out GMRequestMailProperty value)
	{
		ViGameSerializer<GMRequestProperty>.Read(IS, out value.Request);
		ViGameSerializer<MailProperty>.Read(IS, out value.Content);
	}
	public static bool Read(ViStringIStream IS, out GMRequestMailProperty value)
	{
		value = default(GMRequestMailProperty);
		if(ViGameSerializer<GMRequestProperty>.Read(IS, out value.Request) == false){return false;}
		if(ViGameSerializer<MailProperty>.Read(IS, out value.Content) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GMRequestMailProperty value)
	{
		ViGameSerializer<GMRequestProperty>.Append(OS, head + ".Request", value.Request);
		ViGameSerializer<MailProperty>.Append(OS, head + ".Content", value.Content);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GMRequestMailProperty value)
	{
		value = new GMRequestMailProperty();
		ViGameSerializer<GMRequestProperty>.Read(IS, head, out value.Request);
		ViGameSerializer<MailProperty>.Read(IS, head, out value.Content);
	}
}
public static class ServerViewPropertySerializer
{
	public static void Append(ViOStream OS, ServerViewProperty value)
	{
		ViGameSerializer<ServerBaseViewProperty>.Append(OS, value.Base);
		ViGameSerializer<UInt16Property>.Append(OS, value.MergeList);
		ViGameSerializer<StringProperty>.Append(OS, value.RPCExecNameList);
		ViGameSerializer<Int64Property>.Append(OS, value.RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Append(OS, value.MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Append(OS, value.MemoryCountList1);
		ViGameSerializer<PlayerOnlineProperty>.Append(OS, value.OnlinePlayerList);
		ViGameSerializer<GMRequestContentProperty>.Append(OS, value.GlobalGMRecordList);
		ViGameSerializer<GMRequestMailProperty>.Append(OS, value.GlobalMailList);
		ViGameSerializer<DisableRecordProperty>.Append(OS, value.IPDisableList);
		ViGameSerializer<DisableRecordProperty>.Append(OS, value.AccountDisableList);
		ViGameSerializer<UInt32Property>.Append(OS, value.GameFuncClosedList);
		ViGameSerializer<BoardProperty>.Append(OS, value.BoardList);
		ViGameSerializer<GameNoteProperty>.Append(OS, value.NoteList);
		ViGameSerializer<QuestGameRecordProperty>.Append(OS, value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Append(OS, value.ItemRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Append(OS, value.PlayerLevelCountList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, value.ItemShopRecordList);
		ViGameSerializer<RechargeInGameRecordProperty>.Append(OS, value.RechargeList);
		ViGameSerializer<GMStatisticValuePropertyList>.Append(OS, value.StatisticsValueList);
	}
	public static void Read(ViIStream IS, out ServerViewProperty value)
	{
		ViGameSerializer<ServerBaseViewProperty>.Read(IS, out value.Base);
		ViGameSerializer<UInt16Property>.Read(IS, out value.MergeList);
		ViGameSerializer<StringProperty>.Read(IS, out value.RPCExecNameList);
		ViGameSerializer<Int64Property>.Read(IS, out value.RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out value.MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out value.MemoryCountList1);
		ViGameSerializer<PlayerOnlineProperty>.Read(IS, out value.OnlinePlayerList);
		ViGameSerializer<GMRequestContentProperty>.Read(IS, out value.GlobalGMRecordList);
		ViGameSerializer<GMRequestMailProperty>.Read(IS, out value.GlobalMailList);
		ViGameSerializer<DisableRecordProperty>.Read(IS, out value.IPDisableList);
		ViGameSerializer<DisableRecordProperty>.Read(IS, out value.AccountDisableList);
		ViGameSerializer<UInt32Property>.Read(IS, out value.GameFuncClosedList);
		ViGameSerializer<BoardProperty>.Read(IS, out value.BoardList);
		ViGameSerializer<GameNoteProperty>.Read(IS, out value.NoteList);
		ViGameSerializer<QuestGameRecordProperty>.Read(IS, out value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Read(IS, out value.ItemRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Read(IS, out value.PlayerLevelCountList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.ItemShopRecordList);
		ViGameSerializer<RechargeInGameRecordProperty>.Read(IS, out value.RechargeList);
		ViGameSerializer<GMStatisticValuePropertyList>.Read(IS, out value.StatisticsValueList);
	}
	public static bool Read(ViStringIStream IS, out ServerViewProperty value)
	{
		value = default(ServerViewProperty);
		if(ViGameSerializer<ServerBaseViewProperty>.Read(IS, out value.Base) == false){return false;}
		if(ViGameSerializer<UInt16Property>.Read(IS, out value.MergeList) == false){return false;}
		if(ViGameSerializer<StringProperty>.Read(IS, out value.RPCExecNameList) == false){return false;}
		if(ViGameSerializer<Int64Property>.Read(IS, out value.RPCExecCountList) == false){return false;}
		if(ViGameSerializer<MemoryUseProperty>.Read(IS, out value.MemoryCountList0) == false){return false;}
		if(ViGameSerializer<MemoryUseProperty>.Read(IS, out value.MemoryCountList1) == false){return false;}
		if(ViGameSerializer<PlayerOnlineProperty>.Read(IS, out value.OnlinePlayerList) == false){return false;}
		if(ViGameSerializer<GMRequestContentProperty>.Read(IS, out value.GlobalGMRecordList) == false){return false;}
		if(ViGameSerializer<GMRequestMailProperty>.Read(IS, out value.GlobalMailList) == false){return false;}
		if(ViGameSerializer<DisableRecordProperty>.Read(IS, out value.IPDisableList) == false){return false;}
		if(ViGameSerializer<DisableRecordProperty>.Read(IS, out value.AccountDisableList) == false){return false;}
		if(ViGameSerializer<UInt32Property>.Read(IS, out value.GameFuncClosedList) == false){return false;}
		if(ViGameSerializer<BoardProperty>.Read(IS, out value.BoardList) == false){return false;}
		if(ViGameSerializer<GameNoteProperty>.Read(IS, out value.NoteList) == false){return false;}
		if(ViGameSerializer<QuestGameRecordProperty>.Read(IS, out value.QuestRecordList) == false){return false;}
		if(ViGameSerializer<ItemGameRecordProperty>.Read(IS, out value.ItemRecordList) == false){return false;}
		if(ViGameSerializer<PlayerLevelCountProperty>.Read(IS, out value.PlayerLevelCountList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.YinPiaoPaymentRecordList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinPiaoPaymentRecordList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.JinZiPaymentRecordList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.ItemMarketRecordList) == false){return false;}
		if(ViGameSerializer<StatisticsValueProperty>.Read(IS, out value.ItemShopRecordList) == false){return false;}
		if(ViGameSerializer<RechargeInGameRecordProperty>.Read(IS, out value.RechargeList) == false){return false;}
		if(ViGameSerializer<GMStatisticValuePropertyList>.Read(IS, out value.StatisticsValueList) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ServerViewProperty value)
	{
		ViGameSerializer<ServerBaseViewProperty>.Append(OS, head + ".Base", value.Base);
		ViGameSerializer<UInt16Property>.Append(OS, head + ".MergeList", value.MergeList);
		ViGameSerializer<StringProperty>.Append(OS, head + ".RPCExecNameList", value.RPCExecNameList);
		ViGameSerializer<Int64Property>.Append(OS, head + ".RPCExecCountList", value.RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + ".MemoryCountList0", value.MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + ".MemoryCountList1", value.MemoryCountList1);
		ViGameSerializer<PlayerOnlineProperty>.Append(OS, head + ".OnlinePlayerList", value.OnlinePlayerList);
		ViGameSerializer<GMRequestContentProperty>.Append(OS, head + ".GlobalGMRecordList", value.GlobalGMRecordList);
		ViGameSerializer<GMRequestMailProperty>.Append(OS, head + ".GlobalMailList", value.GlobalMailList);
		ViGameSerializer<DisableRecordProperty>.Append(OS, head + ".IPDisableList", value.IPDisableList);
		ViGameSerializer<DisableRecordProperty>.Append(OS, head + ".AccountDisableList", value.AccountDisableList);
		ViGameSerializer<UInt32Property>.Append(OS, head + ".GameFuncClosedList", value.GameFuncClosedList);
		ViGameSerializer<BoardProperty>.Append(OS, head + ".BoardList", value.BoardList);
		ViGameSerializer<GameNoteProperty>.Append(OS, head + ".NoteList", value.NoteList);
		ViGameSerializer<QuestGameRecordProperty>.Append(OS, head + ".QuestRecordList", value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Append(OS, head + ".ItemRecordList", value.ItemRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Append(OS, head + ".PlayerLevelCountList", value.PlayerLevelCountList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".YinPiaoPaymentRecordList", value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".JinPiaoPaymentRecordList", value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".JinZiPaymentRecordList", value.JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".ItemMarketRecordList", value.ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + ".ItemShopRecordList", value.ItemShopRecordList);
		ViGameSerializer<RechargeInGameRecordProperty>.Append(OS, head + ".RechargeList", value.RechargeList);
		ViGameSerializer<GMStatisticValuePropertyList>.Append(OS, head + ".StatisticsValueList", value.StatisticsValueList);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ServerViewProperty value)
	{
		value = new ServerViewProperty();
		ViGameSerializer<ServerBaseViewProperty>.Read(IS, head, out value.Base);
		ViGameSerializer<UInt16Property>.Read(IS, head, out value.MergeList);
		ViGameSerializer<StringProperty>.Read(IS, head, out value.RPCExecNameList);
		ViGameSerializer<Int64Property>.Read(IS, head, out value.RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Read(IS, head, out value.MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Read(IS, head, out value.MemoryCountList1);
		ViGameSerializer<PlayerOnlineProperty>.Read(IS, head, out value.OnlinePlayerList);
		ViGameSerializer<GMRequestContentProperty>.Read(IS, head, out value.GlobalGMRecordList);
		ViGameSerializer<GMRequestMailProperty>.Read(IS, head, out value.GlobalMailList);
		ViGameSerializer<DisableRecordProperty>.Read(IS, head, out value.IPDisableList);
		ViGameSerializer<DisableRecordProperty>.Read(IS, head, out value.AccountDisableList);
		ViGameSerializer<UInt32Property>.Read(IS, head, out value.GameFuncClosedList);
		ViGameSerializer<BoardProperty>.Read(IS, head, out value.BoardList);
		ViGameSerializer<GameNoteProperty>.Read(IS, head, out value.NoteList);
		ViGameSerializer<QuestGameRecordProperty>.Read(IS, head, out value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Read(IS, head, out value.ItemRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Read(IS, head, out value.PlayerLevelCountList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, head, out value.ItemShopRecordList);
		ViGameSerializer<RechargeInGameRecordProperty>.Read(IS, head, out value.RechargeList);
		ViGameSerializer<GMStatisticValuePropertyList>.Read(IS, head, out value.StatisticsValueList);
	}
}
public static class ServerFragment0PropertySerializer
{
	public static void Append(ViOStream OS, ServerFragment0Property value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<Int32>.Append(OS, value.NewAccount);
		ViGameSerializer<Int32>.Append(OS, value.NewPlayer);
		ViGameSerializer<Int32>.Append(OS, value.WebOnline);
		ViGameSerializer<Int32>.Append(OS, value.ClientOnline);
	}
	public static void Read(ViIStream IS, out ServerFragment0Property value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<Int32>.Read(IS, out value.NewAccount);
		ViGameSerializer<Int32>.Read(IS, out value.NewPlayer);
		ViGameSerializer<Int32>.Read(IS, out value.WebOnline);
		ViGameSerializer<Int32>.Read(IS, out value.ClientOnline);
	}
	public static bool Read(ViStringIStream IS, out ServerFragment0Property value)
	{
		value = default(ServerFragment0Property);
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.NewAccount) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.NewPlayer) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.WebOnline) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.ClientOnline) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ServerFragment0Property value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<Int32>.Append(OS, head + ".NewAccount", value.NewAccount);
		ViGameSerializer<Int32>.Append(OS, head + ".NewPlayer", value.NewPlayer);
		ViGameSerializer<Int32>.Append(OS, head + ".WebOnline", value.WebOnline);
		ViGameSerializer<Int32>.Append(OS, head + ".ClientOnline", value.ClientOnline);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ServerFragment0Property value)
	{
		value = new ServerFragment0Property();
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<Int32>.Read(IS, head, out value.NewAccount);
		ViGameSerializer<Int32>.Read(IS, head, out value.NewPlayer);
		ViGameSerializer<Int32>.Read(IS, head, out value.WebOnline);
		ViGameSerializer<Int32>.Read(IS, head, out value.ClientOnline);
	}
}
public static class ServerFragment0WithNamePropertySerializer
{
	public static void Append(ViOStream OS, ServerFragment0WithNameProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.ServerName);
		ViGameSerializer<ServerFragment0Property>.Append(OS, value.Property);
	}
	public static void Read(ViIStream IS, out ServerFragment0WithNameProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.ServerName);
		ViGameSerializer<ServerFragment0Property>.Read(IS, out value.Property);
	}
	public static bool Read(ViStringIStream IS, out ServerFragment0WithNameProperty value)
	{
		value = default(ServerFragment0WithNameProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.ServerName) == false){return false;}
		if(ViGameSerializer<ServerFragment0Property>.Read(IS, out value.Property) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ServerFragment0WithNameProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".ServerName", value.ServerName);
		ViGameSerializer<ServerFragment0Property>.Append(OS, head + ".Property", value.Property);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ServerFragment0WithNameProperty value)
	{
		value = new ServerFragment0WithNameProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.ServerName);
		ViGameSerializer<ServerFragment0Property>.Read(IS, head, out value.Property);
	}
}
public static class ServerFragment1PropertySerializer
{
	public static void Append(ViOStream OS, ServerFragment1Property value)
	{
		ViGameSerializer<Int64>.Append(OS, value.Time1970);
		ViGameSerializer<ServerFragment0Property>.Append(OS, value.Base);
		ViGameSerializer<QuestGameRecordProperty>.Append(OS, value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Append(OS, value.ItemRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Append(OS, value.YinPiaoPaymentRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Append(OS, value.JinPiaoPaymentRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Append(OS, value.PlayerLevelCountList);
	}
	public static void Read(ViIStream IS, out ServerFragment1Property value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.Time1970);
		ViGameSerializer<ServerFragment0Property>.Read(IS, out value.Base);
		ViGameSerializer<QuestGameRecordProperty>.Read(IS, out value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Read(IS, out value.ItemRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Read(IS, out value.YinPiaoPaymentRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Read(IS, out value.JinPiaoPaymentRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Read(IS, out value.PlayerLevelCountList);
	}
	public static bool Read(ViStringIStream IS, out ServerFragment1Property value)
	{
		value = default(ServerFragment1Property);
		if(ViGameSerializer<Int64>.Read(IS, out value.Time1970) == false){return false;}
		if(ViGameSerializer<ServerFragment0Property>.Read(IS, out value.Base) == false){return false;}
		if(ViGameSerializer<QuestGameRecordProperty>.Read(IS, out value.QuestRecordList) == false){return false;}
		if(ViGameSerializer<ItemGameRecordProperty>.Read(IS, out value.ItemRecordList) == false){return false;}
		if(ViGameSerializer<PaymentGameRecordProperty>.Read(IS, out value.YinPiaoPaymentRecordList) == false){return false;}
		if(ViGameSerializer<PaymentGameRecordProperty>.Read(IS, out value.JinPiaoPaymentRecordList) == false){return false;}
		if(ViGameSerializer<PlayerLevelCountProperty>.Read(IS, out value.PlayerLevelCountList) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ServerFragment1Property value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".Time1970", value.Time1970);
		ViGameSerializer<ServerFragment0Property>.Append(OS, head + ".Base", value.Base);
		ViGameSerializer<QuestGameRecordProperty>.Append(OS, head + ".QuestRecordList", value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Append(OS, head + ".ItemRecordList", value.ItemRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Append(OS, head + ".YinPiaoPaymentRecordList", value.YinPiaoPaymentRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Append(OS, head + ".JinPiaoPaymentRecordList", value.JinPiaoPaymentRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Append(OS, head + ".PlayerLevelCountList", value.PlayerLevelCountList);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ServerFragment1Property value)
	{
		value = new ServerFragment1Property();
		ViGameSerializer<Int64>.Read(IS, head, out value.Time1970);
		ViGameSerializer<ServerFragment0Property>.Read(IS, head, out value.Base);
		ViGameSerializer<QuestGameRecordProperty>.Read(IS, head, out value.QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Read(IS, head, out value.ItemRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Read(IS, head, out value.YinPiaoPaymentRecordList);
		ViGameSerializer<PaymentGameRecordProperty>.Read(IS, head, out value.JinPiaoPaymentRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Read(IS, head, out value.PlayerLevelCountList);
	}
}
public static class ServerFragment1WithNamePropertySerializer
{
	public static void Append(ViOStream OS, ServerFragment1WithNameProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, value.ServerName);
		ViGameSerializer<ServerFragment1Property>.Append(OS, value.Property);
	}
	public static void Read(ViIStream IS, out ServerFragment1WithNameProperty value)
	{
		ViGameSerializer<ViString>.Read(IS, out value.ServerName);
		ViGameSerializer<ServerFragment1Property>.Read(IS, out value.Property);
	}
	public static bool Read(ViStringIStream IS, out ServerFragment1WithNameProperty value)
	{
		value = default(ServerFragment1WithNameProperty);
		if(ViGameSerializer<ViString>.Read(IS, out value.ServerName) == false){return false;}
		if(ViGameSerializer<ServerFragment1Property>.Read(IS, out value.Property) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ServerFragment1WithNameProperty value)
	{
		ViGameSerializer<ViString>.Append(OS, head + ".ServerName", value.ServerName);
		ViGameSerializer<ServerFragment1Property>.Append(OS, head + ".Property", value.Property);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ServerFragment1WithNameProperty value)
	{
		value = new ServerFragment1WithNameProperty();
		ViGameSerializer<ViString>.Read(IS, head, out value.ServerName);
		ViGameSerializer<ServerFragment1Property>.Read(IS, head, out value.Property);
	}
}
public static class GoalEventStructSerializer
{
	public static void Append(ViOStream OS, GoalEventStruct value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Space);
		ViGameSerializer<ViVector3>.Append(OS, value.Position);
		ViGameSerializer<UInt32>.Append(OS, value.ID);
		ViGameSerializer<UInt8>.Append(OS, value.MatchType);
		ViGameSerializer<UInt32>.Append(OS, value.Count);
	}
	public static void Read(ViIStream IS, out GoalEventStruct value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Space);
		ViGameSerializer<ViVector3>.Read(IS, out value.Position);
		ViGameSerializer<UInt32>.Read(IS, out value.ID);
		ViGameSerializer<UInt8>.Read(IS, out value.MatchType);
		ViGameSerializer<UInt32>.Read(IS, out value.Count);
	}
	public static bool Read(ViStringIStream IS, out GoalEventStruct value)
	{
		value = default(GoalEventStruct);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Space) == false){return false;}
		if(ViGameSerializer<ViVector3>.Read(IS, out value.Position) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.ID) == false){return false;}
		if(ViGameSerializer<UInt8>.Read(IS, out value.MatchType) == false){return false;}
		if(ViGameSerializer<UInt32>.Read(IS, out value.Count) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, GoalEventStruct value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Space", value.Space);
		ViGameSerializer<ViVector3>.Append(OS, head + ".Position", value.Position);
		ViGameSerializer<UInt32>.Append(OS, head + ".ID", value.ID);
		ViGameSerializer<UInt8>.Append(OS, head + ".MatchType", value.MatchType);
		ViGameSerializer<UInt32>.Append(OS, head + ".Count", value.Count);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out GoalEventStruct value)
	{
		value = new GoalEventStruct();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Space);
		ViGameSerializer<ViVector3>.Read(IS, head, out value.Position);
		ViGameSerializer<UInt32>.Read(IS, head, out value.ID);
		ViGameSerializer<UInt8>.Read(IS, head, out value.MatchType);
		ViGameSerializer<UInt32>.Read(IS, head, out value.Count);
	}
}
public static class ViForeignKeyViSpellStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<ViSpellStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<ViSpellStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<ViSpellStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<ViSpellStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<ViSpellStruct>(0);
			return false;
		}
		value = new ViForeignKey<ViSpellStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<ViSpellStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<ViSpellStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<ViSpellStruct>(dataID);
	}
}
public static class ViForeignKeyScoreStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<ScoreStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<ScoreStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<ScoreStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<ScoreStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<ScoreStruct>(0);
			return false;
		}
		value = new ViForeignKey<ScoreStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<ScoreStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<ScoreStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<ScoreStruct>(dataID);
	}
}
public static class ViForeignKeyItemStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<ItemStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<ItemStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<ItemStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<ItemStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<ItemStruct>(0);
			return false;
		}
		value = new ViForeignKey<ItemStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<ItemStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<ItemStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<ItemStruct>(dataID);
	}
}
public static class ViForeignKeyHeroNatureStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<HeroNatureStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<HeroNatureStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<HeroNatureStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<HeroNatureStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<HeroNatureStruct>(0);
			return false;
		}
		value = new ViForeignKey<HeroNatureStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<HeroNatureStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<HeroNatureStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<HeroNatureStruct>(dataID);
	}
}
public static class ViForeignKeySpaceStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<SpaceStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<SpaceStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<SpaceStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<SpaceStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<SpaceStruct>(0);
			return false;
		}
		value = new ViForeignKey<SpaceStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<SpaceStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<SpaceStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<SpaceStruct>(dataID);
	}
}
public static class ViForeignKeySpaceEventStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<SpaceEventStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<SpaceEventStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<SpaceEventStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<SpaceEventStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<SpaceEventStruct>(0);
			return false;
		}
		value = new ViForeignKey<SpaceEventStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<SpaceEventStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<SpaceEventStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<SpaceEventStruct>(dataID);
	}
}
public static class ViForeignKeySpaceBlockSlotStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<SpaceBlockSlotStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<SpaceBlockSlotStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<SpaceBlockSlotStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<SpaceBlockSlotStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<SpaceBlockSlotStruct>(0);
			return false;
		}
		value = new ViForeignKey<SpaceBlockSlotStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<SpaceBlockSlotStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<SpaceBlockSlotStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<SpaceBlockSlotStruct>(dataID);
	}
}
public static class ViForeignKeySpaceHideSlotStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<SpaceHideSlotStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<SpaceHideSlotStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<SpaceHideSlotStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<SpaceHideSlotStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<SpaceHideSlotStruct>(0);
			return false;
		}
		value = new ViForeignKey<SpaceHideSlotStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<SpaceHideSlotStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<SpaceHideSlotStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<SpaceHideSlotStruct>(dataID);
	}
}
public static class ViForeignKeyActivityStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<ActivityStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<ActivityStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<ActivityStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<ActivityStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<ActivityStruct>(0);
			return false;
		}
		value = new ViForeignKey<ActivityStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<ActivityStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<ActivityStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<ActivityStruct>(dataID);
	}
}
public static class ViForeignKeyHeroStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<HeroStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<HeroStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<HeroStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<HeroStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<HeroStruct>(0);
			return false;
		}
		value = new ViForeignKey<HeroStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<HeroStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<HeroStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<HeroStruct>(dataID);
	}
}
public static class ViForeignKeyOwnSpellStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<OwnSpellStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<OwnSpellStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<OwnSpellStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<OwnSpellStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<OwnSpellStruct>(0);
			return false;
		}
		value = new ViForeignKey<OwnSpellStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<OwnSpellStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<OwnSpellStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<OwnSpellStruct>(dataID);
	}
}
public static class ViForeignKeyGoalStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<GoalStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<GoalStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<GoalStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<GoalStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<GoalStruct>(0);
			return false;
		}
		value = new ViForeignKey<GoalStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<GoalStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<GoalStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<GoalStruct>(dataID);
	}
}
public static class ViForeignKeyBulletStructSerializer
{
	public static void Append(ViOStream OS, ViForeignKey<BulletStruct> value)
	{
		OS.Append(value.Value);
	}
	public static void Read(ViIStream IS, out ViForeignKey<BulletStruct> value)
	{
		Int32 dataID;
		IS.Read(out dataID);
		value = new ViForeignKey<BulletStruct>(dataID);
	}
	public static bool Read(ViStringIStream IS, out ViForeignKey<BulletStruct> value)
	{
		Int32 dataID;
		if (IS.Read(out dataID))
		{
			value = new ViForeignKey<BulletStruct>(0);
			return false;
		}
		value = new ViForeignKey<BulletStruct>(dataID);
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, ViForeignKey<BulletStruct> value)
	{
		ViGameSerializer<Int32>.Append(OS, head, value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out ViForeignKey<BulletStruct> value)
	{
		Int32 dataID;
		ViGameSerializer<Int32>.Read(IS, head, out dataID);
		value = new ViForeignKey<BulletStruct>(dataID);
	}
}
