using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public struct AuraCasterProperty
{
	public UInt32 Value;
}
public struct AuraCasterPtrProperty
{
	public ViNormalDataPtr<AuraCasterProperty> Value;
}
public struct LogicAuraValueArray
{
	public static readonly int TYPE_SIZE = 5;
	public static readonly int Length = 5;
	//
	public int GetLength() { return Length; }
	//
	public Int32 E0;
	public Int32 E1;
	public Int32 E2;
	public Int32 E3;
	public Int32 E4;
	//
	public Int32 this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
			}
		}
	}
}

public struct LogicAuraCasterValueArray
{
	public static readonly int TYPE_SIZE = 5;
	public static readonly int Length = 5;
	//
	public int GetLength() { return Length; }
	//
	public Int32 E0;
	public Int32 E1;
	public Int32 E2;
	public Int32 E3;
	public Int32 E4;
	//
	public Int32 this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
			}
			ViDebuger.Error("");
			return E0;
		}
		set
		{
			switch(index)
			{
				case 0:
					E0 = value;
					return;
				case 1:
					E1 = value;
					return;
				case 2:
					E2 = value;
					return;
				case 3:
					E3 = value;
					return;
				case 4:
					E4 = value;
					return;
			}
		}
	}
}

public struct DisSpellProperty
{
	public Int64 EndTime;
}
public struct VisualAuraProperty
{
	public UInt32 Effect;
	public Int32 EndTime;
	public AuraCasterPtrProperty Caster;
}
public struct LogicAuraProperty
{
	public UInt32 Effect;
	public Int32 EndTime;
	public Int32 LevelValue;
	public LogicAuraCasterValueArray CasterValue;
	public LogicAuraValueArray Value;
}
public struct TestStruct
{
	public UInt32 Effect;
	public Int64 EndTime;
	public ViNormalDataPtr<VisualAuraProperty> TestPtr;
}
