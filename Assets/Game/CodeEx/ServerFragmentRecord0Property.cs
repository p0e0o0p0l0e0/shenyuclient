using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ServerFragmentRecord0Property
{
	public static readonly int TYPE_SIZE = 25;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public UInt32 StartNumber;//DB
	public Int64 Time;//DB
	public Int64 Time1970;//DB
	public Int32 DayNumber1970;//DB
	public Int32 NewAccount;//DB
	public Int32 NewPlayer;//DB
	public Int32 NewGuild;//DB
	public Int32 OnlineCount;//DB
	public Int32 DayLoginCount;//DB
	public Int32 WeekLoginCount;//DB
	public Int32 MonthLoginCount;//DB
	public Int32 DayNewAccountCount;//DB
	public Int32 WeekNewAccountCount;//DB
	public Int32 MonthNewAccountCount;//DB
	public Int32 DayNewPlayerCount;//DB
	public Int32 WeekNewPlayerCount;//DB
	public Int32 MonthNewPlayerCount;//DB
	public Int32 DayNewGuildCount;//DB
	public Int32 WeekNewGuildCount;//DB
	public Int32 MonthNewGuildCount;//DB
	public Int32 EntityCount;//DB
	public Int32 EntityIDCount;//DB
	public Int32 EntityPackIDCount;//DB
	public Int32 SpaceCount;//DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<UInt32>.Read(IS, out StartNumber);
		ViGameSerializer<Int64>.Read(IS, out Time);
		ViGameSerializer<Int64>.Read(IS, out Time1970);
		ViGameSerializer<Int32>.Read(IS, out DayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out NewAccount);
		ViGameSerializer<Int32>.Read(IS, out NewPlayer);
		ViGameSerializer<Int32>.Read(IS, out NewGuild);
		ViGameSerializer<Int32>.Read(IS, out OnlineCount);
		ViGameSerializer<Int32>.Read(IS, out DayLoginCount);
		ViGameSerializer<Int32>.Read(IS, out WeekLoginCount);
		ViGameSerializer<Int32>.Read(IS, out MonthLoginCount);
		ViGameSerializer<Int32>.Read(IS, out DayNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out WeekNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out MonthNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out DayNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out WeekNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out MonthNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out DayNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out WeekNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out MonthNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out EntityCount);
		ViGameSerializer<Int32>.Read(IS, out EntityIDCount);
		ViGameSerializer<Int32>.Read(IS, out EntityPackIDCount);
		ViGameSerializer<Int32>.Read(IS, out SpaceCount);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<UInt32>.Append(OS, head + "StartNumber", StartNumber);
		ViGameSerializer<Int64>.Append(OS, head + "Time", Time);
		ViGameSerializer<Int64>.Append(OS, head + "Time1970", Time1970);
		ViGameSerializer<Int32>.Append(OS, head + "DayNumber1970", DayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "NewAccount", NewAccount);
		ViGameSerializer<Int32>.Append(OS, head + "NewPlayer", NewPlayer);
		ViGameSerializer<Int32>.Append(OS, head + "NewGuild", NewGuild);
		ViGameSerializer<Int32>.Append(OS, head + "OnlineCount", OnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayLoginCount", DayLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekLoginCount", WeekLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthLoginCount", MonthLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayNewAccountCount", DayNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekNewAccountCount", WeekNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthNewAccountCount", MonthNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayNewPlayerCount", DayNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekNewPlayerCount", WeekNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthNewPlayerCount", MonthNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayNewGuildCount", DayNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekNewGuildCount", WeekNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthNewGuildCount", MonthNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityCount", EntityCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityIDCount", EntityIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityPackIDCount", EntityPackIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "SpaceCount", SpaceCount);
	}
}

public class ServerFragmentRecord0ReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 25;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt32 StartNumber = new ViReceiveDataUInt32();//DB
	private ViReceiveDataInt64 Time = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt32 DayNumber1970 = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 NewAccount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 NewPlayer = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 NewGuild = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 OnlineCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayLoginCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekLoginCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthLoginCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayNewAccountCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekNewAccountCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthNewAccountCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayNewPlayerCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekNewPlayerCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthNewPlayerCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayNewGuildCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekNewGuildCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthNewGuildCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityIDCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityPackIDCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 SpaceCount = new ViReceiveDataInt32();//DB
	//
	public ServerFragmentRecord0ReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartNumber.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NewAccount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NewPlayer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NewGuild.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityIDCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityPackIDCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		SpaceCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		StartNumber.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		DayNumber1970.Start(channelMask, IS, entity);
		NewAccount.Start(channelMask, IS, entity);
		NewPlayer.Start(channelMask, IS, entity);
		NewGuild.Start(channelMask, IS, entity);
		OnlineCount.Start(channelMask, IS, entity);
		DayLoginCount.Start(channelMask, IS, entity);
		WeekLoginCount.Start(channelMask, IS, entity);
		MonthLoginCount.Start(channelMask, IS, entity);
		DayNewAccountCount.Start(channelMask, IS, entity);
		WeekNewAccountCount.Start(channelMask, IS, entity);
		MonthNewAccountCount.Start(channelMask, IS, entity);
		DayNewPlayerCount.Start(channelMask, IS, entity);
		WeekNewPlayerCount.Start(channelMask, IS, entity);
		MonthNewPlayerCount.Start(channelMask, IS, entity);
		DayNewGuildCount.Start(channelMask, IS, entity);
		WeekNewGuildCount.Start(channelMask, IS, entity);
		MonthNewGuildCount.Start(channelMask, IS, entity);
		EntityCount.Start(channelMask, IS, entity);
		EntityIDCount.Start(channelMask, IS, entity);
		EntityPackIDCount.Start(channelMask, IS, entity);
		SpaceCount.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		StartNumber.End(entity);
		Time.End(entity);
		Time1970.End(entity);
		DayNumber1970.End(entity);
		NewAccount.End(entity);
		NewPlayer.End(entity);
		NewGuild.End(entity);
		OnlineCount.End(entity);
		DayLoginCount.End(entity);
		WeekLoginCount.End(entity);
		MonthLoginCount.End(entity);
		DayNewAccountCount.End(entity);
		WeekNewAccountCount.End(entity);
		MonthNewAccountCount.End(entity);
		DayNewPlayerCount.End(entity);
		WeekNewPlayerCount.End(entity);
		MonthNewPlayerCount.End(entity);
		DayNewGuildCount.End(entity);
		WeekNewGuildCount.End(entity);
		MonthNewGuildCount.End(entity);
		EntityCount.End(entity);
		EntityIDCount.End(entity);
		EntityPackIDCount.End(entity);
		SpaceCount.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		StartNumber.Clear();
		Time.Clear();
		Time1970.Clear();
		DayNumber1970.Clear();
		NewAccount.Clear();
		NewPlayer.Clear();
		NewGuild.Clear();
		OnlineCount.Clear();
		DayLoginCount.Clear();
		WeekLoginCount.Clear();
		MonthLoginCount.Clear();
		DayNewAccountCount.Clear();
		WeekNewAccountCount.Clear();
		MonthNewAccountCount.Clear();
		DayNewPlayerCount.Clear();
		WeekNewPlayerCount.Clear();
		MonthNewPlayerCount.Clear();
		DayNewGuildCount.Clear();
		WeekNewGuildCount.Clear();
		MonthNewGuildCount.Clear();
		EntityCount.Clear();
		EntityIDCount.Clear();
		EntityPackIDCount.Clear();
		SpaceCount.Clear();
	}
}
