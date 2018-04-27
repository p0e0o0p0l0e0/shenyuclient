using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class ViGameLogicNormalDataEx
{
	public static void Start()
	{
		ViGameSerializer<AuraCasterProperty>.AppendExec = AuraCasterPropertySerializer.Append;
		ViGameSerializer<AuraCasterProperty>.ReadExec = AuraCasterPropertySerializer.Read;
		ViGameSerializer<AuraCasterProperty>.ReadStringExec = AuraCasterPropertySerializer.Read;
		ViGameSerializer<AuraCasterProperty>.AppendDictionaryStringExec = AuraCasterPropertySerializer.Append;
		ViGameSerializer<AuraCasterProperty>.ReadDictionaryStringExec = AuraCasterPropertySerializer.Read;
		ViGameSerializer<AuraCasterPtrProperty>.AppendExec = AuraCasterPtrPropertySerializer.Append;
		ViGameSerializer<AuraCasterPtrProperty>.ReadExec = AuraCasterPtrPropertySerializer.Read;
		ViGameSerializer<AuraCasterPtrProperty>.ReadStringExec = AuraCasterPtrPropertySerializer.Read;
		ViGameSerializer<AuraCasterPtrProperty>.AppendDictionaryStringExec = AuraCasterPtrPropertySerializer.Append;
		ViGameSerializer<AuraCasterPtrProperty>.ReadDictionaryStringExec = AuraCasterPtrPropertySerializer.Read;
		ViGameSerializer<LogicAuraValueArray>.AppendExec = LogicAuraValueArraySerializer.Append;
		ViGameSerializer<LogicAuraValueArray>.ReadExec = LogicAuraValueArraySerializer.Read;
		ViGameSerializer<LogicAuraValueArray>.ReadStringExec = LogicAuraValueArraySerializer.Read;
		ViGameSerializer<LogicAuraValueArray>.AppendDictionaryStringExec = LogicAuraValueArraySerializer.Append;
		ViGameSerializer<LogicAuraValueArray>.ReadDictionaryStringExec = LogicAuraValueArraySerializer.Read;
		ViGameSerializer<LogicAuraCasterValueArray>.AppendExec = LogicAuraCasterValueArraySerializer.Append;
		ViGameSerializer<LogicAuraCasterValueArray>.ReadExec = LogicAuraCasterValueArraySerializer.Read;
		ViGameSerializer<LogicAuraCasterValueArray>.ReadStringExec = LogicAuraCasterValueArraySerializer.Read;
		ViGameSerializer<LogicAuraCasterValueArray>.AppendDictionaryStringExec = LogicAuraCasterValueArraySerializer.Append;
		ViGameSerializer<LogicAuraCasterValueArray>.ReadDictionaryStringExec = LogicAuraCasterValueArraySerializer.Read;
		ViGameSerializer<DisSpellProperty>.AppendExec = DisSpellPropertySerializer.Append;
		ViGameSerializer<DisSpellProperty>.ReadExec = DisSpellPropertySerializer.Read;
		ViGameSerializer<DisSpellProperty>.ReadStringExec = DisSpellPropertySerializer.Read;
		ViGameSerializer<DisSpellProperty>.AppendDictionaryStringExec = DisSpellPropertySerializer.Append;
		ViGameSerializer<DisSpellProperty>.ReadDictionaryStringExec = DisSpellPropertySerializer.Read;
		ViGameSerializer<VisualAuraProperty>.AppendExec = VisualAuraPropertySerializer.Append;
		ViGameSerializer<VisualAuraProperty>.ReadExec = VisualAuraPropertySerializer.Read;
		ViGameSerializer<VisualAuraProperty>.ReadStringExec = VisualAuraPropertySerializer.Read;
		ViGameSerializer<VisualAuraProperty>.AppendDictionaryStringExec = VisualAuraPropertySerializer.Append;
		ViGameSerializer<VisualAuraProperty>.ReadDictionaryStringExec = VisualAuraPropertySerializer.Read;
		ViGameSerializer<LogicAuraProperty>.AppendExec = LogicAuraPropertySerializer.Append;
		ViGameSerializer<LogicAuraProperty>.ReadExec = LogicAuraPropertySerializer.Read;
		ViGameSerializer<LogicAuraProperty>.ReadStringExec = LogicAuraPropertySerializer.Read;
		ViGameSerializer<LogicAuraProperty>.AppendDictionaryStringExec = LogicAuraPropertySerializer.Append;
		ViGameSerializer<LogicAuraProperty>.ReadDictionaryStringExec = LogicAuraPropertySerializer.Read;
		ViGameSerializer<TestStruct>.AppendExec = TestStructSerializer.Append;
		ViGameSerializer<TestStruct>.ReadExec = TestStructSerializer.Read;
		ViGameSerializer<TestStruct>.ReadStringExec = TestStructSerializer.Read;
		ViGameSerializer<TestStruct>.AppendDictionaryStringExec = TestStructSerializer.Append;
		ViGameSerializer<TestStruct>.ReadDictionaryStringExec = TestStructSerializer.Read;
	}

	public static void End()
	{

	}
}
