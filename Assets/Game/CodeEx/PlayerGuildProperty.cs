using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerGuildProperty : PlayerComponentProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentProperty.TYPE_SIZE + 5;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public UInt64 GuildID;//OWN_CLIENT+DB
	public Int64 Contribution;//OWN_CLIENT+DB
	public Dictionary<UInt64, TimeProperty> ApplyRecordList;//OWN_CLIENT+DB
	public Int64 NextRecommandTime;//OWN_CLIENT+DB
	public List<UInt64Property> RecommandList;//DB
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<UInt64>.Read(IS, out GuildID);
		ViGameSerializer<Int64>.Read(IS, out Contribution);
		ViGameSerializer<TimeProperty>.Read(IS, out ApplyRecordList);
		ViGameSerializer<Int64>.Read(IS, out NextRecommandTime);
		ViGameSerializer<UInt64Property>.Read(IS, out RecommandList);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<UInt64>.Append(OS, head + "GuildID", GuildID);
		ViGameSerializer<Int64>.Append(OS, head + "Contribution", Contribution);
		ViGameSerializer<TimeProperty>.Append(OS, head + "ApplyRecordList", ApplyRecordList);
		ViGameSerializer<Int64>.Append(OS, head + "NextRecommandTime", NextRecommandTime);
		ViGameSerializer<UInt64Property>.Append(OS, head + "RecommandList", RecommandList);
	}
}

public class PlayerGuildReceiveProperty : PlayerComponentReceiveProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentReceiveProperty.TYPE_SIZE + 5;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public ViReceiveDataUInt64 GuildID = new ViReceiveDataUInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 Contribution = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt64, ReceiveDataTimeProperty, TimeProperty> ApplyRecordList = new ViReceiveDataDictionary<UInt64, ReceiveDataTimeProperty, TimeProperty>();//OWN_CLIENT+DB
	public ViReceiveDataInt64 NextRecommandTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	private ViReceiveDataArray<ReceiveDataUInt64Property, UInt64Property> RecommandList = new ViReceiveDataArray<ReceiveDataUInt64Property, UInt64Property>();//DB
	//
	public PlayerGuildReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		GuildID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Contribution.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ApplyRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		NextRecommandTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RecommandList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		GuildID.Start(channelMask, IS, entity);
		Contribution.Start(channelMask, IS, entity);
		ApplyRecordList.Start(channelMask, IS, entity);
		NextRecommandTime.Start(channelMask, IS, entity);
		RecommandList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		GuildID.End(entity);
		Contribution.End(entity);
		ApplyRecordList.End(entity);
		NextRecommandTime.End(entity);
		RecommandList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		GuildID.Clear();
		Contribution.Clear();
		ApplyRecordList.Clear();
		NextRecommandTime.Clear();
		RecommandList.Clear();
	}
}
