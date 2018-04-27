using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GMRecordProperty
{
	public static readonly int TYPE_SIZE = 7;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Int64 Time;//CENTER+DB
	public Int64 Time1970;//CENTER+DB
	public Int64 StartTime1970;//CENTER+DB
	public Int32 StartDayNumber1970;//CENTER+DB
	public Int32 CurrentDayNumber1970;//CENTER+DB
	public Dictionary<UInt32, ServerBaseViewProperty> ServerBaseList;//ALL_CLIENT+DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<Int64>.Read(IS, out Time);
		ViGameSerializer<Int64>.Read(IS, out Time1970);
		ViGameSerializer<Int64>.Read(IS, out StartTime1970);
		ViGameSerializer<Int32>.Read(IS, out StartDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out CurrentDayNumber1970);
		ViGameSerializer<ServerBaseViewProperty>.Read(IS, out ServerBaseList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<Int64>.Append(OS, head + "Time", Time);
		ViGameSerializer<Int64>.Append(OS, head + "Time1970", Time1970);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime1970", StartTime1970);
		ViGameSerializer<Int32>.Append(OS, head + "StartDayNumber1970", StartDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "CurrentDayNumber1970", CurrentDayNumber1970);
		ViGameSerializer<ServerBaseViewProperty>.Append(OS, head + "ServerBaseList", ServerBaseList);
	}
}

public class GMRecordReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 7;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataInt64 Time = new ViReceiveDataInt64();//CENTER+DB
	private ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();//CENTER+DB
	private ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();//CENTER+DB
	private ViReceiveDataInt32 StartDayNumber1970 = new ViReceiveDataInt32();//CENTER+DB
	private ViReceiveDataInt32 CurrentDayNumber1970 = new ViReceiveDataInt32();//CENTER+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataServerBaseViewProperty, ServerBaseViewProperty> ServerBaseList = new ViReceiveDataDictionary<UInt32, ReceiveDataServerBaseViewProperty, ServerBaseViewProperty>();//ALL_CLIENT+DB
	//
	public GMRecordReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CurrentDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ServerBaseList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		Time.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		StartTime1970.Start(channelMask, IS, entity);
		StartDayNumber1970.Start(channelMask, IS, entity);
		CurrentDayNumber1970.Start(channelMask, IS, entity);
		ServerBaseList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		Time.End(entity);
		Time1970.End(entity);
		StartTime1970.End(entity);
		StartDayNumber1970.End(entity);
		CurrentDayNumber1970.End(entity);
		ServerBaseList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		Time.Clear();
		Time1970.Clear();
		StartTime1970.Clear();
		StartDayNumber1970.Clear();
		CurrentDayNumber1970.Clear();
		ServerBaseList.Clear();
	}
}
