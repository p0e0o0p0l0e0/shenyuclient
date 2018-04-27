using System;

public struct LoopCountStruct
{
	public bool Empty()
	{
		return Value == 0;
	}
	public bool NotEmpty()
	{
		return Value != 0;
	}
	public Int32 Value;
	public ViEnum32<ViDateLoopType> Reset;
}

public struct ItemCountStruct
{
	public bool IsEmpty() { return (Item == 0 || Count == 0); }
	public string CountStr() { return Count > 1 ? Count.ToString() : string.Empty; }
	public ViForeignKey<ItemStruct> Item;
	public Int32 Count;
}

public struct ItemCountRangeStruct
{
	public bool IsEmpty() { return (Item == 0 || Count.Sup == 0); }
	public string CountStr() { return Count.Sup > 1 ? Count.Sup.ToString() : string.Empty; }
	public ViForeignKey<ItemStruct> Item;
	public ViValueRange Count;
}

public struct LootCountStruct
{
	public bool Empty()
	{
		return Count == 0;
	}
	public bool NotEmpty()
	{
		return Count != 0;
	}

	public ViForeignKey<LootStruct> Loot;
	public Int32 Count;
}

public struct AttributeModValueStruct
{
	public ViForeignKey<AttributeTypeStruct> Type;
	public Int32 Value;
}

public class ProbabilityValue<T>
	where T : new()
{
	public Int32 Probability;
	public  T Data = new T();
}

public class ProbabilityValue2<T>
	where T : new()
{
	public Int32 Probability;
	public ViValueRange ReqLevel;
	public T Data = new T();
}
