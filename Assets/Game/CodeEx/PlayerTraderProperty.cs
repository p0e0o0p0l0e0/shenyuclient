using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerTraderProperty : PlayerComponentProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentProperty.TYPE_SIZE + 11;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public Int64 SaleSuccessCount;//OWN_CLIENT+DB
	public Int64 SaleFailCount;//OWN_CLIENT+DB
	public Int64 BuyCount;//OWN_CLIENT+DB
	public Int64 AccumulateReceiveYinPiao;//OWN_CLIENT+DB
	public Int64 AccumulateReceiveJinPiao;//OWN_CLIENT+DB
	public Int64 AccumulateSpendYinPiao;//OWN_CLIENT+DB
	public Int64 AccumulateSpendJinPiao;//OWN_CLIENT+DB
	public HashSet<UInt64> ItemOwnList;//OWN_CLIENT+DB
	public HashSet<UInt64> ItemAuctionList;//OWN_CLIENT+DB
	public List<ItemTradeRecordProperty> ItemRecordList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int32Property> DailyItemTradeOutCountList;//OWN_CLIENT+DB
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<Int64>.Read(IS, out SaleSuccessCount);
		ViGameSerializer<Int64>.Read(IS, out SaleFailCount);
		ViGameSerializer<Int64>.Read(IS, out BuyCount);
		ViGameSerializer<Int64>.Read(IS, out AccumulateReceiveYinPiao);
		ViGameSerializer<Int64>.Read(IS, out AccumulateReceiveJinPiao);
		ViGameSerializer<Int64>.Read(IS, out AccumulateSpendYinPiao);
		ViGameSerializer<Int64>.Read(IS, out AccumulateSpendJinPiao);
		ViGameSerializer<UInt64>.Read(IS, out ItemOwnList);
		ViGameSerializer<UInt64>.Read(IS, out ItemAuctionList);
		ViGameSerializer<ItemTradeRecordProperty>.Read(IS, out ItemRecordList);
		ViGameSerializer<Int32Property>.Read(IS, out DailyItemTradeOutCountList);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<Int64>.Append(OS, head + "SaleSuccessCount", SaleSuccessCount);
		ViGameSerializer<Int64>.Append(OS, head + "SaleFailCount", SaleFailCount);
		ViGameSerializer<Int64>.Append(OS, head + "BuyCount", BuyCount);
		ViGameSerializer<Int64>.Append(OS, head + "AccumulateReceiveYinPiao", AccumulateReceiveYinPiao);
		ViGameSerializer<Int64>.Append(OS, head + "AccumulateReceiveJinPiao", AccumulateReceiveJinPiao);
		ViGameSerializer<Int64>.Append(OS, head + "AccumulateSpendYinPiao", AccumulateSpendYinPiao);
		ViGameSerializer<Int64>.Append(OS, head + "AccumulateSpendJinPiao", AccumulateSpendJinPiao);
		ViGameSerializer<UInt64>.Append(OS, head + "ItemOwnList", ItemOwnList);
		ViGameSerializer<UInt64>.Append(OS, head + "ItemAuctionList", ItemAuctionList);
		ViGameSerializer<ItemTradeRecordProperty>.Append(OS, head + "ItemRecordList", ItemRecordList);
		ViGameSerializer<Int32Property>.Append(OS, head + "DailyItemTradeOutCountList", DailyItemTradeOutCountList);
	}
}

public class PlayerTraderReceiveProperty : PlayerComponentReceiveProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentReceiveProperty.TYPE_SIZE + 11;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public ViReceiveDataInt64 SaleSuccessCount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 SaleFailCount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 BuyCount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 AccumulateReceiveYinPiao = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 AccumulateReceiveJinPiao = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 AccumulateSpendYinPiao = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 AccumulateSpendJinPiao = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt64> ItemOwnList = new ViReceiveDataSet<UInt64>();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt64> ItemAuctionList = new ViReceiveDataSet<UInt64>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataItemTradeRecordProperty, ItemTradeRecordProperty> ItemRecordList = new ViReceiveDataArray<ReceiveDataItemTradeRecordProperty, ItemTradeRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property> DailyItemTradeOutCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property>();//OWN_CLIENT+DB
	//
	public PlayerTraderReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		SaleSuccessCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		SaleFailCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		BuyCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateReceiveYinPiao.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateReceiveJinPiao.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateSpendYinPiao.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateSpendJinPiao.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemOwnList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemAuctionList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DailyItemTradeOutCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		//
		ReserveIdxPropertySize(INDEX_PROPERTY_COUNT);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		UInt16 slot;
		IS.Read(out slot);
		OnUpdateAsContainer(slot, channel, IS, entity);
	}
	public override void StartProperty(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		base.StartProperty(channelMask, IS, entity);
		SaleSuccessCount.Start(channelMask, IS, entity);
		SaleFailCount.Start(channelMask, IS, entity);
		BuyCount.Start(channelMask, IS, entity);
		AccumulateReceiveYinPiao.Start(channelMask, IS, entity);
		AccumulateReceiveJinPiao.Start(channelMask, IS, entity);
		AccumulateSpendYinPiao.Start(channelMask, IS, entity);
		AccumulateSpendJinPiao.Start(channelMask, IS, entity);
		ItemOwnList.Start(channelMask, IS, entity);
		ItemAuctionList.Start(channelMask, IS, entity);
		ItemRecordList.Start(channelMask, IS, entity);
		DailyItemTradeOutCountList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		SaleSuccessCount.End(entity);
		SaleFailCount.End(entity);
		BuyCount.End(entity);
		AccumulateReceiveYinPiao.End(entity);
		AccumulateReceiveJinPiao.End(entity);
		AccumulateSpendYinPiao.End(entity);
		AccumulateSpendJinPiao.End(entity);
		ItemOwnList.End(entity);
		ItemAuctionList.End(entity);
		ItemRecordList.End(entity);
		DailyItemTradeOutCountList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		SaleSuccessCount.Clear();
		SaleFailCount.Clear();
		BuyCount.Clear();
		AccumulateReceiveYinPiao.Clear();
		AccumulateReceiveJinPiao.Clear();
		AccumulateSpendYinPiao.Clear();
		AccumulateSpendJinPiao.Clear();
		ItemOwnList.Clear();
		ItemAuctionList.Clear();
		ItemRecordList.Clear();
		DailyItemTradeOutCountList.Clear();
	}
}
