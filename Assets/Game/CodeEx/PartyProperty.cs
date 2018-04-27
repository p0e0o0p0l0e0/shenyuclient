using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PartyProperty
{
	public static readonly int TYPE_SIZE = 16;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public PlayerIdentificationProperty Leader;//ALL_CLIENT
	public ViString PartyName;//ALL_CLIENT+DB
	public Int64 Target;//ALL_CLIENT+DB
	public Int8 AgreeJoinPartyLazy;//ALL_CLIENT+DB
	public Int16 MaxMemberCount;//ALL_CLIENT+DB
	public List<PartyMemberProperty> RecommandList;//ALL_CLIENT
	public List<PartyMemberProperty> RequestList;//ALL_CLIENT
	public List<PartyMemberProperty> InviteeList;//ALL_CLIENT
	public List<PartyMemberProperty> MemberList;//ALL_CLIENT+DB
	public UInt8 Matching;//ALL_CLIENT
	public List<PartySpaceMatchProperty> MatchingList;//ALL_CLIENT
	public UInt8 IsCancelMatchTeam;//
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Leader);
		ViGameSerializer<ViString>.Read(IS, out PartyName);
		ViGameSerializer<Int64>.Read(IS, out Target);
		ViGameSerializer<Int8>.Read(IS, out AgreeJoinPartyLazy);
		ViGameSerializer<Int16>.Read(IS, out MaxMemberCount);
		ViGameSerializer<PartyMemberProperty>.Read(IS, out RecommandList);
		ViGameSerializer<PartyMemberProperty>.Read(IS, out RequestList);
		ViGameSerializer<PartyMemberProperty>.Read(IS, out InviteeList);
		ViGameSerializer<PartyMemberProperty>.Read(IS, out MemberList);
		ViGameSerializer<UInt8>.Read(IS, out Matching);
		ViGameSerializer<PartySpaceMatchProperty>.Read(IS, out MatchingList);
		ViGameSerializer<UInt8>.Read(IS, out IsCancelMatchTeam);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Leader", Leader);
		ViGameSerializer<ViString>.Append(OS, head + "PartyName", PartyName);
		ViGameSerializer<Int64>.Append(OS, head + "Target", Target);
		ViGameSerializer<Int8>.Append(OS, head + "AgreeJoinPartyLazy", AgreeJoinPartyLazy);
		ViGameSerializer<Int16>.Append(OS, head + "MaxMemberCount", MaxMemberCount);
		ViGameSerializer<PartyMemberProperty>.Append(OS, head + "RecommandList", RecommandList);
		ViGameSerializer<PartyMemberProperty>.Append(OS, head + "RequestList", RequestList);
		ViGameSerializer<PartyMemberProperty>.Append(OS, head + "InviteeList", InviteeList);
		ViGameSerializer<PartyMemberProperty>.Append(OS, head + "MemberList", MemberList);
		ViGameSerializer<UInt8>.Append(OS, head + "Matching", Matching);
		ViGameSerializer<PartySpaceMatchProperty>.Append(OS, head + "MatchingList", MatchingList);
		ViGameSerializer<UInt8>.Append(OS, head + "IsCancelMatchTeam", IsCancelMatchTeam);
	}
}

public class PartyReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 16;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	public ReceiveDataPlayerIdentificationProperty Leader = new ReceiveDataPlayerIdentificationProperty();//ALL_CLIENT
	public ViReceiveDataString PartyName = new ViReceiveDataString();//ALL_CLIENT+DB
	public ViReceiveDataInt64 Target = new ViReceiveDataInt64();//ALL_CLIENT+DB
	public ViReceiveDataInt8 AgreeJoinPartyLazy = new ViReceiveDataInt8();//ALL_CLIENT+DB
	public ViReceiveDataInt16 MaxMemberCount = new ViReceiveDataInt16();//ALL_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty> RecommandList = new ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty> RequestList = new ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty> InviteeList = new ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty> MemberList = new ViReceiveDataArray<ReceiveDataPartyMemberProperty, PartyMemberProperty>();//ALL_CLIENT+DB
	public ViReceiveDataUInt8 Matching = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataPartySpaceMatchProperty, PartySpaceMatchProperty> MatchingList = new ViReceiveDataArray<ReceiveDataPartySpaceMatchProperty, PartySpaceMatchProperty>();//ALL_CLIENT
	private ViReceiveDataUInt8 IsCancelMatchTeam = new ViReceiveDataUInt8();//
	//
	public PartyReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Leader.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PartyName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Target.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AgreeJoinPartyLazy.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MaxMemberCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RecommandList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		RequestList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		InviteeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MemberList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Matching.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MatchingList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		IsCancelMatchTeam.RegisterAsChild((UInt16)(0), this, ChildList);
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
		Leader.Start(channelMask, IS, entity);
		PartyName.Start(channelMask, IS, entity);
		Target.Start(channelMask, IS, entity);
		AgreeJoinPartyLazy.Start(channelMask, IS, entity);
		MaxMemberCount.Start(channelMask, IS, entity);
		RecommandList.Start(channelMask, IS, entity);
		RequestList.Start(channelMask, IS, entity);
		InviteeList.Start(channelMask, IS, entity);
		MemberList.Start(channelMask, IS, entity);
		Matching.Start(channelMask, IS, entity);
		MatchingList.Start(channelMask, IS, entity);
		IsCancelMatchTeam.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		Leader.End(entity);
		PartyName.End(entity);
		Target.End(entity);
		AgreeJoinPartyLazy.End(entity);
		MaxMemberCount.End(entity);
		RecommandList.End(entity);
		RequestList.End(entity);
		InviteeList.End(entity);
		MemberList.End(entity);
		Matching.End(entity);
		MatchingList.End(entity);
		IsCancelMatchTeam.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		Leader.Clear();
		PartyName.Clear();
		Target.Clear();
		AgreeJoinPartyLazy.Clear();
		MaxMemberCount.Clear();
		RecommandList.Clear();
		RequestList.Clear();
		InviteeList.Clear();
		MemberList.Clear();
		Matching.Clear();
		MatchingList.Clear();
		IsCancelMatchTeam.Clear();
	}
}
