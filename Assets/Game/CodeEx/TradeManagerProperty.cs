using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class TradeManagerProperty
{
	public static readonly int TYPE_SIZE = 4;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public UInt64 FreeID;//DB
	public Dictionary<UInt64, ItemTradeProperty> ItemList;//DB
	public Dictionary<UInt32, ItemTradeOfficialPriceProperty> ItemTradeOfficialPriceList;//ALL_CLIENT+DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<UInt64>.Read(IS, out FreeID);
		ViGameSerializer<ItemTradeProperty>.Read(IS, out ItemList);
		ViGameSerializer<ItemTradeOfficialPriceProperty>.Read(IS, out ItemTradeOfficialPriceList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<UInt64>.Append(OS, head + "FreeID", FreeID);
		ViGameSerializer<ItemTradeProperty>.Append(OS, head + "ItemList", ItemList);
		ViGameSerializer<ItemTradeOfficialPriceProperty>.Append(OS, head + "ItemTradeOfficialPriceList", ItemTradeOfficialPriceList);
	}
}

public class TradeManagerReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 4;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 FreeID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataDictionary<UInt64, ReceiveDataItemTradeProperty, ItemTradeProperty> ItemList = new ViReceiveDataDictionary<UInt64, ReceiveDataItemTradeProperty, ItemTradeProperty>();//DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataItemTradeOfficialPriceProperty, ItemTradeOfficialPriceProperty> ItemTradeOfficialPriceList = new ViReceiveDataDictionary<UInt32, ReceiveDataItemTradeOfficialPriceProperty, ItemTradeOfficialPriceProperty>();//ALL_CLIENT+DB
	//
	public TradeManagerReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		FreeID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemTradeOfficialPriceList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		DataVersion.Start(channelMask, IS, entity);
		FreeID.Start(channelMask, IS, entity);
		ItemList.Start(channelMask, IS, entity);
		ItemTradeOfficialPriceList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		FreeID.End(entity);
		ItemList.End(entity);
		ItemTradeOfficialPriceList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		FreeID.Clear();
		ItemList.Clear();
		ItemTradeOfficialPriceList.Clear();
	}
}
