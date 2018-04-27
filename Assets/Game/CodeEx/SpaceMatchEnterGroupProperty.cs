using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceMatchEnterGroupProperty
{
	public static readonly int TYPE_SIZE = 5;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public ViForeignKey<SpaceStruct> Info;//ALL_CLIENT
	public UInt8 MatchSpaceType;//ALL_CLIENT
	public Int64 EndTime;//ALL_CLIENT
	public Int8 FactionCount;//ALL_CLIENT
	public Dictionary<UInt64, SpaceMatchEnterMemberProperty> MemberList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Read(IS, out Info);
		ViGameSerializer<UInt8>.Read(IS, out MatchSpaceType);
		ViGameSerializer<Int64>.Read(IS, out EndTime);
		ViGameSerializer<Int8>.Read(IS, out FactionCount);
		ViGameSerializer<SpaceMatchEnterMemberProperty>.Read(IS, out MemberList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Append(OS, head + "Info", Info);
		ViGameSerializer<UInt8>.Append(OS, head + "MatchSpaceType", MatchSpaceType);
		ViGameSerializer<Int64>.Append(OS, head + "EndTime", EndTime);
		ViGameSerializer<Int8>.Append(OS, head + "FactionCount", FactionCount);
		ViGameSerializer<SpaceMatchEnterMemberProperty>.Append(OS, head + "MemberList", MemberList);
	}
}

public class SpaceMatchEnterGroupReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 5;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataForeignKey<SpaceStruct> Info = new ViReceiveDataForeignKey<SpaceStruct>();//ALL_CLIENT
	public ViReceiveDataUInt8 MatchSpaceType = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();//ALL_CLIENT
	public ViReceiveDataInt8 FactionCount = new ViReceiveDataInt8();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataSpaceMatchEnterMemberProperty, SpaceMatchEnterMemberProperty> MemberList = new ViReceiveDataDictionary<UInt64, ReceiveDataSpaceMatchEnterMemberProperty, SpaceMatchEnterMemberProperty>();//ALL_CLIENT
	//
	public SpaceMatchEnterGroupReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Info.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MatchSpaceType.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EndTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		FactionCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MemberList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		Info.Start(channelMask, IS, entity);
		MatchSpaceType.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		FactionCount.Start(channelMask, IS, entity);
		MemberList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Info.End(entity);
		MatchSpaceType.End(entity);
		EndTime.End(entity);
		FactionCount.End(entity);
		MemberList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Info.Clear();
		MatchSpaceType.Clear();
		EndTime.Clear();
		FactionCount.Clear();
		MemberList.Clear();
	}
}
