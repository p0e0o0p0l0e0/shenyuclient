using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerFriendListProperty : PlayerComponentProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentProperty.TYPE_SIZE + 8;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public Int16 FriendMaxCount;//OWN_CLIENT+DB
	public Dictionary<UInt64, FriendProperty> FriendPropertyList;//OWN_CLIENT+DB
	public Dictionary<UInt64, FriendViewProperty> FriendViewPropertyList;//OWN_CLIENT
	public Dictionary<UInt64, BlackFriendProperty> BlackFriendPropertyList;//OWN_CLIENT+DB
	public List<FriendInvitorProperty> FriendInvitorList;//OWN_CLIENT+DB
	public List<FriendInviteeProperty> FriendInviteeList;//OWN_CLIENT
	public Int64 NextRecommandTime;//OWN_CLIENT+DB
	public List<FriendInviteeProperty> RecommandList;//OWN_CLIENT+DB
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<Int16>.Read(IS, out FriendMaxCount);
		ViGameSerializer<FriendProperty>.Read(IS, out FriendPropertyList);
		ViGameSerializer<FriendViewProperty>.Read(IS, out FriendViewPropertyList);
		ViGameSerializer<BlackFriendProperty>.Read(IS, out BlackFriendPropertyList);
		ViGameSerializer<FriendInvitorProperty>.Read(IS, out FriendInvitorList);
		ViGameSerializer<FriendInviteeProperty>.Read(IS, out FriendInviteeList);
		ViGameSerializer<Int64>.Read(IS, out NextRecommandTime);
		ViGameSerializer<FriendInviteeProperty>.Read(IS, out RecommandList);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<Int16>.Append(OS, head + "FriendMaxCount", FriendMaxCount);
		ViGameSerializer<FriendProperty>.Append(OS, head + "FriendPropertyList", FriendPropertyList);
		ViGameSerializer<FriendViewProperty>.Append(OS, head + "FriendViewPropertyList", FriendViewPropertyList);
		ViGameSerializer<BlackFriendProperty>.Append(OS, head + "BlackFriendPropertyList", BlackFriendPropertyList);
		ViGameSerializer<FriendInvitorProperty>.Append(OS, head + "FriendInvitorList", FriendInvitorList);
		ViGameSerializer<FriendInviteeProperty>.Append(OS, head + "FriendInviteeList", FriendInviteeList);
		ViGameSerializer<Int64>.Append(OS, head + "NextRecommandTime", NextRecommandTime);
		ViGameSerializer<FriendInviteeProperty>.Append(OS, head + "RecommandList", RecommandList);
	}
}

public class PlayerFriendListReceiveProperty : PlayerComponentReceiveProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentReceiveProperty.TYPE_SIZE + 8;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public ViReceiveDataInt16 FriendMaxCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt64, ReceiveDataFriendProperty, FriendProperty> FriendPropertyList = new ViReceiveDataDictionary<UInt64, ReceiveDataFriendProperty, FriendProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt64, ReceiveDataFriendViewProperty, FriendViewProperty> FriendViewPropertyList = new ViReceiveDataDictionary<UInt64, ReceiveDataFriendViewProperty, FriendViewProperty>();//OWN_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataBlackFriendProperty, BlackFriendProperty> BlackFriendPropertyList = new ViReceiveDataDictionary<UInt64, ReceiveDataBlackFriendProperty, BlackFriendProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataFriendInvitorProperty, FriendInvitorProperty> FriendInvitorList = new ViReceiveDataArray<ReceiveDataFriendInvitorProperty, FriendInvitorProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataFriendInviteeProperty, FriendInviteeProperty> FriendInviteeList = new ViReceiveDataArray<ReceiveDataFriendInviteeProperty, FriendInviteeProperty>();//OWN_CLIENT
	public ViReceiveDataInt64 NextRecommandTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataFriendInviteeProperty, FriendInviteeProperty> RecommandList = new ViReceiveDataArray<ReceiveDataFriendInviteeProperty, FriendInviteeProperty>();//OWN_CLIENT+DB
	//
	public PlayerFriendListReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		FriendMaxCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		FriendPropertyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		FriendViewPropertyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		BlackFriendPropertyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		FriendInvitorList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		FriendInviteeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		NextRecommandTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RecommandList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		FriendMaxCount.Start(channelMask, IS, entity);
		FriendPropertyList.Start(channelMask, IS, entity);
		FriendViewPropertyList.Start(channelMask, IS, entity);
		BlackFriendPropertyList.Start(channelMask, IS, entity);
		FriendInvitorList.Start(channelMask, IS, entity);
		FriendInviteeList.Start(channelMask, IS, entity);
		NextRecommandTime.Start(channelMask, IS, entity);
		RecommandList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		FriendMaxCount.End(entity);
		FriendPropertyList.End(entity);
		FriendViewPropertyList.End(entity);
		BlackFriendPropertyList.End(entity);
		FriendInvitorList.End(entity);
		FriendInviteeList.End(entity);
		NextRecommandTime.End(entity);
		RecommandList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		FriendMaxCount.Clear();
		FriendPropertyList.Clear();
		FriendViewPropertyList.Clear();
		BlackFriendPropertyList.Clear();
		FriendInvitorList.Clear();
		FriendInviteeList.Clear();
		NextRecommandTime.Clear();
		RecommandList.Clear();
	}
}
