using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ItemLicenceProperty
{
	public static readonly int TYPE_SIZE = 4;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public ViForeignKey<ItemStruct> Info;//DB
	public Int16 Count;//DB
	public Int64 CD;//DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Read(IS, out Info);
		ViGameSerializer<Int16>.Read(IS, out Count);
		ViGameSerializer<Int64>.Read(IS, out CD);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<ViForeignKey<ItemStruct>>.Append(OS, head + "Info", Info);
		ViGameSerializer<Int16>.Append(OS, head + "Count", Count);
		ViGameSerializer<Int64>.Append(OS, head + "CD", CD);
	}
}

public class ItemLicenceReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 4;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataForeignKey<ItemStruct> Info = new ViReceiveDataForeignKey<ItemStruct>();//DB
	private ViReceiveDataInt16 Count = new ViReceiveDataInt16();//DB
	private ViReceiveDataInt64 CD = new ViReceiveDataInt64();//DB
	//
	public ItemLicenceReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Info.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Count.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CD.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		Info.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
		CD.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		Info.End(entity);
		Count.End(entity);
		CD.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		Info.Clear();
		Count.Clear();
		CD.Clear();
	}
}
