using System;

public class MarketItemStruct : ViSealedData
{
	public struct RequestStruct
	{
		public ViForeignKey<GameFuncStruct> Func;
		public ViValueRange Level;
	}
	//
	public ItemCountStruct Item;
	public MoneyStruct Price;
	public LoopCountStruct Count;
	public RequestStruct Request;
}

public class  ItemComposeStruct: ViSealedData
{
	public ViForeignKey<ItemStruct> Dest;
	public ViStaticArray<ItemCountStruct> CostItem = new ViStaticArray<ItemCountStruct>(4);
	public MoneyStruct CostMoney;
}

public class RechargeItemStruct : ViSealedData
{
	public string Icon;
	public Int32 AppendJinZi;
	public Int32 Price;
}