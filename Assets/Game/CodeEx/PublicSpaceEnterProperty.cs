using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PublicSpaceEnterProperty
{
	public static readonly int TYPE_SIZE = 13;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public ViString Name;//ALL_CLIENT
	public ViForeignKey<SpaceStruct> Space;//ALL_CLIENT
	public Int64 StartTime;//ALL_CLIENT
	public PlayerIdentificationProperty Leader;//ALL_CLIENT
	public ViString BoardMessage;//ALL_CLIENT
	public ViString Password;//
	public Int8 FactionCount;//ALL_CLIENT
	public Int16 FactionMemberCount;//ALL_CLIENT
	public Dictionary<UInt64, PublicSpaceEnterMemberProperty> MemberList;//ALL_CLIENT
	public Dictionary<UInt64, PlayerIdentificationProperty> WatcherList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<ViString>.Read(IS, out Name);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Read(IS, out Space);
		ViGameSerializer<Int64>.Read(IS, out StartTime);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Leader);
		ViGameSerializer<ViString>.Read(IS, out BoardMessage);
		ViGameSerializer<ViString>.Read(IS, out Password);
		ViGameSerializer<Int8>.Read(IS, out FactionCount);
		ViGameSerializer<Int16>.Read(IS, out FactionMemberCount);
		ViGameSerializer<PublicSpaceEnterMemberProperty>.Read(IS, out MemberList);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out WatcherList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<ViString>.Append(OS, head + "Name", Name);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Append(OS, head + "Space", Space);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime", StartTime);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Leader", Leader);
		ViGameSerializer<ViString>.Append(OS, head + "BoardMessage", BoardMessage);
		ViGameSerializer<ViString>.Append(OS, head + "Password", Password);
		ViGameSerializer<Int8>.Append(OS, head + "FactionCount", FactionCount);
		ViGameSerializer<Int16>.Append(OS, head + "FactionMemberCount", FactionMemberCount);
		ViGameSerializer<PublicSpaceEnterMemberProperty>.Append(OS, head + "MemberList", MemberList);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "WatcherList", WatcherList);
	}
}

public class PublicSpaceEnterReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 13;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataString Name = new ViReceiveDataString();//ALL_CLIENT
	public ViReceiveDataForeignKey<SpaceStruct> Space = new ViReceiveDataForeignKey<SpaceStruct>();//ALL_CLIENT
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();//ALL_CLIENT
	public ReceiveDataPlayerIdentificationProperty Leader = new ReceiveDataPlayerIdentificationProperty();//ALL_CLIENT
	public ViReceiveDataString BoardMessage = new ViReceiveDataString();//ALL_CLIENT
	private ViReceiveDataString Password = new ViReceiveDataString();//
	public ViReceiveDataInt8 FactionCount = new ViReceiveDataInt8();//ALL_CLIENT
	public ViReceiveDataInt16 FactionMemberCount = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataPublicSpaceEnterMemberProperty, PublicSpaceEnterMemberProperty> MemberList = new ViReceiveDataDictionary<UInt64, ReceiveDataPublicSpaceEnterMemberProperty, PublicSpaceEnterMemberProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataPlayerIdentificationProperty, PlayerIdentificationProperty> WatcherList = new ViReceiveDataDictionary<UInt64, ReceiveDataPlayerIdentificationProperty, PlayerIdentificationProperty>();//ALL_CLIENT
	//
	public PublicSpaceEnterReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Name.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Space.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		StartTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Leader.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BoardMessage.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Password.RegisterAsChild((UInt16)(0), this, ChildList);
		FactionCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		FactionMemberCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MemberList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		WatcherList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		Name.Start(channelMask, IS, entity);
		Space.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		Leader.Start(channelMask, IS, entity);
		BoardMessage.Start(channelMask, IS, entity);
		Password.Start(channelMask, IS, entity);
		FactionCount.Start(channelMask, IS, entity);
		FactionMemberCount.Start(channelMask, IS, entity);
		MemberList.Start(channelMask, IS, entity);
		WatcherList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Name.End(entity);
		Space.End(entity);
		StartTime.End(entity);
		Leader.End(entity);
		BoardMessage.End(entity);
		Password.End(entity);
		FactionCount.End(entity);
		FactionMemberCount.End(entity);
		MemberList.End(entity);
		WatcherList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Name.Clear();
		Space.Clear();
		StartTime.Clear();
		Leader.Clear();
		BoardMessage.Clear();
		Password.Clear();
		FactionCount.Clear();
		FactionMemberCount.Clear();
		MemberList.Clear();
		WatcherList.Clear();
	}
}
