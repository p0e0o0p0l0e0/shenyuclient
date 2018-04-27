using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public static class AuraCasterPropertySerializer
{
	public static void Append(ViOStream OS, AuraCasterProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out AuraCasterProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out AuraCasterProperty value)
	{
		value = default(AuraCasterProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, AuraCasterProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out AuraCasterProperty value)
	{
		value = new AuraCasterProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Value);
	}
}
public static class AuraCasterPtrPropertySerializer
{
	public static void Append(ViOStream OS, AuraCasterPtrProperty value)
	{
		ViGameSerializer<AuraCasterProperty>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out AuraCasterPtrProperty value)
	{
		ViGameSerializer<AuraCasterProperty>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out AuraCasterPtrProperty value)
	{
		value = default(AuraCasterPtrProperty);
		if(ViGameSerializer<AuraCasterProperty>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, AuraCasterPtrProperty value)
	{
		ViGameSerializer<AuraCasterProperty>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out AuraCasterPtrProperty value)
	{
		value = new AuraCasterPtrProperty();
		ViGameSerializer<AuraCasterProperty>.Read(IS, head, out value.Value);
	}
}
public static class LogicAuraValueArraySerializer
{
	public static void Append(ViOStream OS, LogicAuraValueArray value)
	{
		ViGameSerializer<Int32>.Append(OS, value.E0);
		ViGameSerializer<Int32>.Append(OS, value.E1);
		ViGameSerializer<Int32>.Append(OS, value.E2);
		ViGameSerializer<Int32>.Append(OS, value.E3);
		ViGameSerializer<Int32>.Append(OS, value.E4);
	}
	public static void Read(ViIStream IS, out LogicAuraValueArray value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.E0);
		ViGameSerializer<Int32>.Read(IS, out value.E1);
		ViGameSerializer<Int32>.Read(IS, out value.E2);
		ViGameSerializer<Int32>.Read(IS, out value.E3);
		ViGameSerializer<Int32>.Read(IS, out value.E4);
	}
	public static bool Read(ViStringIStream IS, out LogicAuraValueArray value)
	{
		value = default(LogicAuraValueArray);
		if(ViGameSerializer<Int32>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E4) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, LogicAuraValueArray value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<Int32>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<Int32>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<Int32>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<Int32>.Append(OS, head + ".E4", value.E4);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out LogicAuraValueArray value)
	{
		value = new LogicAuraValueArray();
		ViGameSerializer<Int32>.Read(IS, head, out value.E0);
		ViGameSerializer<Int32>.Read(IS, head, out value.E1);
		ViGameSerializer<Int32>.Read(IS, head, out value.E2);
		ViGameSerializer<Int32>.Read(IS, head, out value.E3);
		ViGameSerializer<Int32>.Read(IS, head, out value.E4);
	}
}
public static class LogicAuraCasterValueArraySerializer
{
	public static void Append(ViOStream OS, LogicAuraCasterValueArray value)
	{
		ViGameSerializer<Int32>.Append(OS, value.E0);
		ViGameSerializer<Int32>.Append(OS, value.E1);
		ViGameSerializer<Int32>.Append(OS, value.E2);
		ViGameSerializer<Int32>.Append(OS, value.E3);
		ViGameSerializer<Int32>.Append(OS, value.E4);
	}
	public static void Read(ViIStream IS, out LogicAuraCasterValueArray value)
	{
		ViGameSerializer<Int32>.Read(IS, out value.E0);
		ViGameSerializer<Int32>.Read(IS, out value.E1);
		ViGameSerializer<Int32>.Read(IS, out value.E2);
		ViGameSerializer<Int32>.Read(IS, out value.E3);
		ViGameSerializer<Int32>.Read(IS, out value.E4);
	}
	public static bool Read(ViStringIStream IS, out LogicAuraCasterValueArray value)
	{
		value = default(LogicAuraCasterValueArray);
		if(ViGameSerializer<Int32>.Read(IS, out value.E0) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E1) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E2) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E3) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.E4) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, LogicAuraCasterValueArray value)
	{
		ViGameSerializer<Int32>.Append(OS, head + ".E0", value.E0);
		ViGameSerializer<Int32>.Append(OS, head + ".E1", value.E1);
		ViGameSerializer<Int32>.Append(OS, head + ".E2", value.E2);
		ViGameSerializer<Int32>.Append(OS, head + ".E3", value.E3);
		ViGameSerializer<Int32>.Append(OS, head + ".E4", value.E4);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out LogicAuraCasterValueArray value)
	{
		value = new LogicAuraCasterValueArray();
		ViGameSerializer<Int32>.Read(IS, head, out value.E0);
		ViGameSerializer<Int32>.Read(IS, head, out value.E1);
		ViGameSerializer<Int32>.Read(IS, head, out value.E2);
		ViGameSerializer<Int32>.Read(IS, head, out value.E3);
		ViGameSerializer<Int32>.Read(IS, head, out value.E4);
	}
}
public static class DisSpellPropertySerializer
{
	public static void Append(ViOStream OS, DisSpellProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
	}
	public static void Read(ViIStream IS, out DisSpellProperty value)
	{
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
	}
	public static bool Read(ViStringIStream IS, out DisSpellProperty value)
	{
		value = default(DisSpellProperty);
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, DisSpellProperty value)
	{
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out DisSpellProperty value)
	{
		value = new DisSpellProperty();
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
	}
}
public static class VisualAuraPropertySerializer
{
	public static void Append(ViOStream OS, VisualAuraProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Effect);
		ViGameSerializer<Int32>.Append(OS, value.EndTime);
		ViGameSerializer<AuraCasterPtrProperty>.Append(OS, value.Caster);
	}
	public static void Read(ViIStream IS, out VisualAuraProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Effect);
		ViGameSerializer<Int32>.Read(IS, out value.EndTime);
		ViGameSerializer<AuraCasterPtrProperty>.Read(IS, out value.Caster);
	}
	public static bool Read(ViStringIStream IS, out VisualAuraProperty value)
	{
		value = default(VisualAuraProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Effect) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<AuraCasterPtrProperty>.Read(IS, out value.Caster) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, VisualAuraProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Effect", value.Effect);
		ViGameSerializer<Int32>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<AuraCasterPtrProperty>.Append(OS, head + ".Caster", value.Caster);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out VisualAuraProperty value)
	{
		value = new VisualAuraProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Effect);
		ViGameSerializer<Int32>.Read(IS, head, out value.EndTime);
		ViGameSerializer<AuraCasterPtrProperty>.Read(IS, head, out value.Caster);
	}
}
public static class LogicAuraPropertySerializer
{
	public static void Append(ViOStream OS, LogicAuraProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Effect);
		ViGameSerializer<Int32>.Append(OS, value.EndTime);
		ViGameSerializer<Int32>.Append(OS, value.LevelValue);
		ViGameSerializer<LogicAuraCasterValueArray>.Append(OS, value.CasterValue);
		ViGameSerializer<LogicAuraValueArray>.Append(OS, value.Value);
	}
	public static void Read(ViIStream IS, out LogicAuraProperty value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Effect);
		ViGameSerializer<Int32>.Read(IS, out value.EndTime);
		ViGameSerializer<Int32>.Read(IS, out value.LevelValue);
		ViGameSerializer<LogicAuraCasterValueArray>.Read(IS, out value.CasterValue);
		ViGameSerializer<LogicAuraValueArray>.Read(IS, out value.Value);
	}
	public static bool Read(ViStringIStream IS, out LogicAuraProperty value)
	{
		value = default(LogicAuraProperty);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Effect) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<Int32>.Read(IS, out value.LevelValue) == false){return false;}
		if(ViGameSerializer<LogicAuraCasterValueArray>.Read(IS, out value.CasterValue) == false){return false;}
		if(ViGameSerializer<LogicAuraValueArray>.Read(IS, out value.Value) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, LogicAuraProperty value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Effect", value.Effect);
		ViGameSerializer<Int32>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<Int32>.Append(OS, head + ".LevelValue", value.LevelValue);
		ViGameSerializer<LogicAuraCasterValueArray>.Append(OS, head + ".CasterValue", value.CasterValue);
		ViGameSerializer<LogicAuraValueArray>.Append(OS, head + ".Value", value.Value);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out LogicAuraProperty value)
	{
		value = new LogicAuraProperty();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Effect);
		ViGameSerializer<Int32>.Read(IS, head, out value.EndTime);
		ViGameSerializer<Int32>.Read(IS, head, out value.LevelValue);
		ViGameSerializer<LogicAuraCasterValueArray>.Read(IS, head, out value.CasterValue);
		ViGameSerializer<LogicAuraValueArray>.Read(IS, head, out value.Value);
	}
}
public static class TestStructSerializer
{
	public static void Append(ViOStream OS, TestStruct value)
	{
		ViGameSerializer<UInt32>.Append(OS, value.Effect);
		ViGameSerializer<Int64>.Append(OS, value.EndTime);
		ViGameSerializer<VisualAuraProperty>.Append(OS, value.TestPtr);
	}
	public static void Read(ViIStream IS, out TestStruct value)
	{
		ViGameSerializer<UInt32>.Read(IS, out value.Effect);
		ViGameSerializer<Int64>.Read(IS, out value.EndTime);
		ViGameSerializer<VisualAuraProperty>.Read(IS, out value.TestPtr);
	}
	public static bool Read(ViStringIStream IS, out TestStruct value)
	{
		value = default(TestStruct);
		if(ViGameSerializer<UInt32>.Read(IS, out value.Effect) == false){return false;}
		if(ViGameSerializer<Int64>.Read(IS, out value.EndTime) == false){return false;}
		if(ViGameSerializer<VisualAuraProperty>.Read(IS, out value.TestPtr) == false){return false;}
		return true;
	}
	public static void Append(ViStringDictionaryStream OS, string head, TestStruct value)
	{
		ViGameSerializer<UInt32>.Append(OS, head + ".Effect", value.Effect);
		ViGameSerializer<Int64>.Append(OS, head + ".EndTime", value.EndTime);
		ViGameSerializer<VisualAuraProperty>.Append(OS, head + ".TestPtr", value.TestPtr);
	}
	public static void Read(ViStringDictionaryStream IS, string head, out TestStruct value)
	{
		value = new TestStruct();
		ViGameSerializer<UInt32>.Read(IS, head, out value.Effect);
		ViGameSerializer<Int64>.Read(IS, head, out value.EndTime);
		ViGameSerializer<VisualAuraProperty>.Read(IS, head, out value.TestPtr);
	}
}
