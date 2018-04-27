using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GuildProperty
{
	public static readonly int TYPE_SIZE = 27;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Int16 MergeCount;//DB
	public ViString Name;//ALL_CLIENT
	public Int16 Level;//ALL_CLIENT+DB
	public Int64 XP;//ALL_CLIENT+DB
	public UInt32 Rank;//ALL_CLIENT+DB
	public Int32 FightPower;//ALL_CLIENT+DB
	public PlayerIdentificationProperty Creator;//ALL_CLIENT+DB
	public Int64 CreateTime1970;//ALL_CLIENT+DB
	public PlayerIdentificationProperty Leader;//ALL_CLIENT+DB
	public Int64 LeaderRMB;//ALL_CLIENT+DB
	public ViString Introdution;//ALL_CLIENT+DB
	public ViString BoardMessage;//ALL_CLIENT+DB
	public UInt8 ResponseType;//ALL_CLIENT+DB
	public Int16 ReqEnterLevel;//ALL_CLIENT+DB
	public Int16 MemberMaxCount;//ALL_CLIENT+DB
	public Dictionary<UInt64, GuildMemberProperty> MemberList;//ALL_CLIENT+DB
	public List<GuildMessageProperty> MessageList;//ALL_CLIENT+DB
	public Dictionary<UInt64, GuildApplyProperty> ApplyList;//ALL_CLIENT+DB
	public Dictionary<UInt32, GuildActivityProperty> ActivityList;//ALL_CLIENT
	public Dictionary<UInt64, GuildActivitySeatProperty> ActivitySeatList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<Int16>.Read(IS, out MergeCount);
		ViGameSerializer<ViString>.Read(IS, out Name);
		ViGameSerializer<Int16>.Read(IS, out Level);
		ViGameSerializer<Int64>.Read(IS, out XP);
		ViGameSerializer<UInt32>.Read(IS, out Rank);
		ViGameSerializer<Int32>.Read(IS, out FightPower);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Creator);
		ViGameSerializer<Int64>.Read(IS, out CreateTime1970);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Leader);
		ViGameSerializer<Int64>.Read(IS, out LeaderRMB);
		ViGameSerializer<ViString>.Read(IS, out Introdution);
		ViGameSerializer<ViString>.Read(IS, out BoardMessage);
		ViGameSerializer<UInt8>.Read(IS, out ResponseType);
		ViGameSerializer<Int16>.Read(IS, out ReqEnterLevel);
		ViGameSerializer<Int16>.Read(IS, out MemberMaxCount);
		ViGameSerializer<GuildMemberProperty>.Read(IS, out MemberList);
		ViGameSerializer<GuildMessageProperty>.Read(IS, out MessageList);
		ViGameSerializer<GuildApplyProperty>.Read(IS, out ApplyList);
		ViGameSerializer<GuildActivityProperty>.Read(IS, out ActivityList);
		ViGameSerializer<GuildActivitySeatProperty>.Read(IS, out ActivitySeatList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<Int16>.Append(OS, head + "MergeCount", MergeCount);
		ViGameSerializer<ViString>.Append(OS, head + "Name", Name);
		ViGameSerializer<Int16>.Append(OS, head + "Level", Level);
		ViGameSerializer<Int64>.Append(OS, head + "XP", XP);
		ViGameSerializer<UInt32>.Append(OS, head + "Rank", Rank);
		ViGameSerializer<Int32>.Append(OS, head + "FightPower", FightPower);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Creator", Creator);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime1970", CreateTime1970);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Leader", Leader);
		ViGameSerializer<Int64>.Append(OS, head + "LeaderRMB", LeaderRMB);
		ViGameSerializer<ViString>.Append(OS, head + "Introdution", Introdution);
		ViGameSerializer<ViString>.Append(OS, head + "BoardMessage", BoardMessage);
		ViGameSerializer<UInt8>.Append(OS, head + "ResponseType", ResponseType);
		ViGameSerializer<Int16>.Append(OS, head + "ReqEnterLevel", ReqEnterLevel);
		ViGameSerializer<Int16>.Append(OS, head + "MemberMaxCount", MemberMaxCount);
		ViGameSerializer<GuildMemberProperty>.Append(OS, head + "MemberList", MemberList);
		ViGameSerializer<GuildMessageProperty>.Append(OS, head + "MessageList", MessageList);
		ViGameSerializer<GuildApplyProperty>.Append(OS, head + "ApplyList", ApplyList);
		ViGameSerializer<GuildActivityProperty>.Append(OS, head + "ActivityList", ActivityList);
		ViGameSerializer<GuildActivitySeatProperty>.Append(OS, head + "ActivitySeatList", ActivitySeatList);
	}
}

public class GuildReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 27;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataInt16 MergeCount = new ViReceiveDataInt16();//DB
	public ViReceiveDataString Name = new ViReceiveDataString();//ALL_CLIENT
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();//ALL_CLIENT+DB
	public ViReceiveDataInt64 XP = new ViReceiveDataInt64();//ALL_CLIENT+DB
	public ViReceiveDataUInt32 Rank = new ViReceiveDataUInt32();//ALL_CLIENT+DB
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();//ALL_CLIENT+DB
	public ReceiveDataPlayerIdentificationProperty Creator = new ReceiveDataPlayerIdentificationProperty();//ALL_CLIENT+DB
	public ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();//ALL_CLIENT+DB
	public ReceiveDataPlayerIdentificationProperty Leader = new ReceiveDataPlayerIdentificationProperty();//ALL_CLIENT+DB
	public ViReceiveDataInt64 LeaderRMB = new ViReceiveDataInt64();//ALL_CLIENT+DB
	public ViReceiveDataString Introdution = new ViReceiveDataString();//ALL_CLIENT+DB
	public ViReceiveDataString BoardMessage = new ViReceiveDataString();//ALL_CLIENT+DB
	public ViReceiveDataUInt8 ResponseType = new ViReceiveDataUInt8();//ALL_CLIENT+DB
	public ViReceiveDataInt16 ReqEnterLevel = new ViReceiveDataInt16();//ALL_CLIENT+DB
	public ViReceiveDataInt16 MemberMaxCount = new ViReceiveDataInt16();//ALL_CLIENT+DB
	public ViReceiveDataDictionary<UInt64, ReceiveDataGuildMemberProperty, GuildMemberProperty> MemberList = new ViReceiveDataDictionary<UInt64, ReceiveDataGuildMemberProperty, GuildMemberProperty>();//ALL_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataGuildMessageProperty, GuildMessageProperty> MessageList = new ViReceiveDataArray<ReceiveDataGuildMessageProperty, GuildMessageProperty>();//ALL_CLIENT+DB
	public ViReceiveDataDictionary<UInt64, ReceiveDataGuildApplyProperty, GuildApplyProperty> ApplyList = new ViReceiveDataDictionary<UInt64, ReceiveDataGuildApplyProperty, GuildApplyProperty>();//ALL_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataGuildActivityProperty, GuildActivityProperty> ActivityList = new ViReceiveDataDictionary<UInt32, ReceiveDataGuildActivityProperty, GuildActivityProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataGuildActivitySeatProperty, GuildActivitySeatProperty> ActivitySeatList = new ViReceiveDataDictionary<UInt64, ReceiveDataGuildActivitySeatProperty, GuildActivitySeatProperty>();//ALL_CLIENT
	//
	public GuildReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MergeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Name.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Level.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		XP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Rank.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		FightPower.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Creator.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Leader.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LeaderRMB.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Introdution.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		BoardMessage.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ResponseType.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReqEnterLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MemberMaxCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MemberList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MessageList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ApplyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActivityList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ActivitySeatList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		Name.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		XP.Start(channelMask, IS, entity);
		Rank.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		Creator.Start(channelMask, IS, entity);
		CreateTime1970.Start(channelMask, IS, entity);
		Leader.Start(channelMask, IS, entity);
		LeaderRMB.Start(channelMask, IS, entity);
		Introdution.Start(channelMask, IS, entity);
		BoardMessage.Start(channelMask, IS, entity);
		ResponseType.Start(channelMask, IS, entity);
		ReqEnterLevel.Start(channelMask, IS, entity);
		MemberMaxCount.Start(channelMask, IS, entity);
		MemberList.Start(channelMask, IS, entity);
		MessageList.Start(channelMask, IS, entity);
		ApplyList.Start(channelMask, IS, entity);
		ActivityList.Start(channelMask, IS, entity);
		ActivitySeatList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		MergeCount.End(entity);
		Name.End(entity);
		Level.End(entity);
		XP.End(entity);
		Rank.End(entity);
		FightPower.End(entity);
		Creator.End(entity);
		CreateTime1970.End(entity);
		Leader.End(entity);
		LeaderRMB.End(entity);
		Introdution.End(entity);
		BoardMessage.End(entity);
		ResponseType.End(entity);
		ReqEnterLevel.End(entity);
		MemberMaxCount.End(entity);
		MemberList.End(entity);
		MessageList.End(entity);
		ApplyList.End(entity);
		ActivityList.End(entity);
		ActivitySeatList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		MergeCount.Clear();
		Name.Clear();
		Level.Clear();
		XP.Clear();
		Rank.Clear();
		FightPower.Clear();
		Creator.Clear();
		CreateTime1970.Clear();
		Leader.Clear();
		LeaderRMB.Clear();
		Introdution.Clear();
		BoardMessage.Clear();
		ResponseType.Clear();
		ReqEnterLevel.Clear();
		MemberMaxCount.Clear();
		MemberList.Clear();
		MessageList.Clear();
		ApplyList.Clear();
		ActivityList.Clear();
		ActivitySeatList.Clear();
	}
}
