using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GMAccountProperty
{
	public static readonly int TYPE_SIZE = 6;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public ViString Name;//OWN_CLIENT
	public ViString Password;//DB
	public UInt8 GMLevel;//OWN_CLIENT+DB
	public List<StringProperty> QueryAccountHistory;//OWN_CLIENT+DB
	public List<StringProperty> QueryPlayerHistory;//OWN_CLIENT+DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<ViString>.Read(IS, out Name);
		ViGameSerializer<ViString>.Read(IS, out Password);
		ViGameSerializer<UInt8>.Read(IS, out GMLevel);
		ViGameSerializer<StringProperty>.Read(IS, out QueryAccountHistory);
		ViGameSerializer<StringProperty>.Read(IS, out QueryPlayerHistory);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<ViString>.Append(OS, head + "Name", Name);
		ViGameSerializer<ViString>.Append(OS, head + "Password", Password);
		ViGameSerializer<UInt8>.Append(OS, head + "GMLevel", GMLevel);
		ViGameSerializer<StringProperty>.Append(OS, head + "QueryAccountHistory", QueryAccountHistory);
		ViGameSerializer<StringProperty>.Append(OS, head + "QueryPlayerHistory", QueryPlayerHistory);
	}
}

public class GMAccountReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 6;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	public ViReceiveDataString Name = new ViReceiveDataString();//OWN_CLIENT
	private ViReceiveDataString Password = new ViReceiveDataString();//DB
	public ViReceiveDataUInt8 GMLevel = new ViReceiveDataUInt8();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataStringProperty, StringProperty> QueryAccountHistory = new ViReceiveDataArray<ReceiveDataStringProperty, StringProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataStringProperty, StringProperty> QueryPlayerHistory = new ViReceiveDataArray<ReceiveDataStringProperty, StringProperty>();//OWN_CLIENT+DB
	//
	public GMAccountReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Name.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		Password.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GMLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		QueryAccountHistory.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		QueryPlayerHistory.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		Name.Start(channelMask, IS, entity);
		Password.Start(channelMask, IS, entity);
		GMLevel.Start(channelMask, IS, entity);
		QueryAccountHistory.Start(channelMask, IS, entity);
		QueryPlayerHistory.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		Name.End(entity);
		Password.End(entity);
		GMLevel.End(entity);
		QueryAccountHistory.End(entity);
		QueryPlayerHistory.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		Name.Clear();
		Password.Clear();
		GMLevel.Clear();
		QueryAccountHistory.Clear();
		QueryPlayerHistory.Clear();
	}
}
