using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ItemTradeRecorderProperty
{
	public static readonly int TYPE_SIZE = 7;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public PlayerIdentificationProperty Creator;//DB
	public Int64 CreateTime1970;//DB
	public List<ItemTradeRecordProperty> RecordList;//DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Creator);
		ViGameSerializer<Int64>.Read(IS, out CreateTime1970);
		ViGameSerializer<ItemTradeRecordProperty>.Read(IS, out RecordList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Creator", Creator);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime1970", CreateTime1970);
		ViGameSerializer<ItemTradeRecordProperty>.Append(OS, head + "RecordList", RecordList);
	}
}

public class ItemTradeRecorderReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 7;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ReceiveDataPlayerIdentificationProperty Creator = new ReceiveDataPlayerIdentificationProperty();//DB
	private ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();//DB
	private ViReceiveDataArray<ReceiveDataItemTradeRecordProperty, ItemTradeRecordProperty> RecordList = new ViReceiveDataArray<ReceiveDataItemTradeRecordProperty, ItemTradeRecordProperty>();//DB
	//
	public ItemTradeRecorderReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Creator.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		Creator.Start(channelMask, IS, entity);
		CreateTime1970.Start(channelMask, IS, entity);
		RecordList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		Creator.End(entity);
		CreateTime1970.End(entity);
		RecordList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		Creator.Clear();
		CreateTime1970.Clear();
		RecordList.Clear();
	}
}
