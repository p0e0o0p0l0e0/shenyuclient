using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerComponentProperty
{
	public static readonly int TYPE_SIZE = 17;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Int16 MergeCount;//DB
	public EntityServerProperty Server;//DB
	public ViString NameAlias;//DB
	public UInt8 Photo;//DB
	public Int16 Level;//DB
	public UInt8 Gender;//DB
	public UInt8 Class;//DB
	public UInt32 FightPower;//DB
	public Int64 LastLoginTime1970;//DB
	public Int64 LastOnlineTime;//DB
	public Int64 LastOnlineTime1970;//DB
	public UInt8 ClientState;//
	public List<MessageProperty> MessageList;//DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<Int16>.Read(IS, out MergeCount);
		ViGameSerializer<EntityServerProperty>.Read(IS, out Server);
		ViGameSerializer<ViString>.Read(IS, out NameAlias);
		ViGameSerializer<UInt8>.Read(IS, out Photo);
		ViGameSerializer<Int16>.Read(IS, out Level);
		ViGameSerializer<UInt8>.Read(IS, out Gender);
		ViGameSerializer<UInt8>.Read(IS, out Class);
		ViGameSerializer<UInt32>.Read(IS, out FightPower);
		ViGameSerializer<Int64>.Read(IS, out LastLoginTime1970);
		ViGameSerializer<Int64>.Read(IS, out LastOnlineTime);
		ViGameSerializer<Int64>.Read(IS, out LastOnlineTime1970);
		ViGameSerializer<UInt8>.Read(IS, out ClientState);
		ViGameSerializer<MessageProperty>.Read(IS, out MessageList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<Int16>.Append(OS, head + "MergeCount", MergeCount);
		ViGameSerializer<EntityServerProperty>.Append(OS, head + "Server", Server);
		ViGameSerializer<ViString>.Append(OS, head + "NameAlias", NameAlias);
		ViGameSerializer<UInt8>.Append(OS, head + "Photo", Photo);
		ViGameSerializer<Int16>.Append(OS, head + "Level", Level);
		ViGameSerializer<UInt8>.Append(OS, head + "Gender", Gender);
		ViGameSerializer<UInt8>.Append(OS, head + "Class", Class);
		ViGameSerializer<UInt32>.Append(OS, head + "FightPower", FightPower);
		ViGameSerializer<Int64>.Append(OS, head + "LastLoginTime1970", LastLoginTime1970);
		ViGameSerializer<Int64>.Append(OS, head + "LastOnlineTime", LastOnlineTime);
		ViGameSerializer<Int64>.Append(OS, head + "LastOnlineTime1970", LastOnlineTime1970);
		ViGameSerializer<UInt8>.Append(OS, head + "ClientState", ClientState);
		ViGameSerializer<MessageProperty>.Append(OS, head + "MessageList", MessageList);
	}
}

public class PlayerComponentReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 17;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataInt16 MergeCount = new ViReceiveDataInt16();//DB
	private ReceiveDataEntityServerProperty Server = new ReceiveDataEntityServerProperty();//DB
	private ViReceiveDataString NameAlias = new ViReceiveDataString();//DB
	private ViReceiveDataUInt8 Photo = new ViReceiveDataUInt8();//DB
	private ViReceiveDataInt16 Level = new ViReceiveDataInt16();//DB
	private ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();//DB
	private ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();//DB
	private ViReceiveDataUInt32 FightPower = new ViReceiveDataUInt32();//DB
	private ViReceiveDataInt64 LastLoginTime1970 = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt64 LastOnlineTime = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt64 LastOnlineTime1970 = new ViReceiveDataInt64();//DB
	private ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();//
	private ViReceiveDataArray<ReceiveDataMessageProperty, MessageProperty> MessageList = new ViReceiveDataArray<ReceiveDataMessageProperty, MessageProperty>();//DB
	//
	public PlayerComponentReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MergeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Server.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NameAlias.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Photo.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Level.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Gender.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Class.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		FightPower.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastLoginTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastOnlineTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastOnlineTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ClientState.RegisterAsChild((UInt16)(0), this, ChildList);
		MessageList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		MergeCount.Start(channelMask, IS, entity);
		Server.Start(channelMask, IS, entity);
		NameAlias.Start(channelMask, IS, entity);
		Photo.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		LastLoginTime1970.Start(channelMask, IS, entity);
		LastOnlineTime.Start(channelMask, IS, entity);
		LastOnlineTime1970.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		MessageList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		MergeCount.End(entity);
		Server.End(entity);
		NameAlias.End(entity);
		Photo.End(entity);
		Level.End(entity);
		Gender.End(entity);
		Class.End(entity);
		FightPower.End(entity);
		LastLoginTime1970.End(entity);
		LastOnlineTime.End(entity);
		LastOnlineTime1970.End(entity);
		ClientState.End(entity);
		MessageList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		MergeCount.Clear();
		Server.Clear();
		NameAlias.Clear();
		Photo.Clear();
		Level.Clear();
		Gender.Clear();
		Class.Clear();
		FightPower.Clear();
		LastLoginTime1970.Clear();
		LastOnlineTime.Clear();
		LastOnlineTime1970.Clear();
		ClientState.Clear();
		MessageList.Clear();
	}
}
