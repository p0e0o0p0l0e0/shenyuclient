using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerMailboxProperty : PlayerComponentProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentProperty.TYPE_SIZE + 5;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public UInt32 GlobalMailIdx;//DB
	public UInt32 GlobalMailIdxAtCreateTime;//DB
	public UInt16 MaxSize;//OWN_CLIENT+DB
	public List<MailProperty> MailList;//OWN_CLIENT+DB
	public List<PlayerIdentificationProperty> MailTargetList;//OWN_CLIENT+DB
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<UInt32>.Read(IS, out GlobalMailIdx);
		ViGameSerializer<UInt32>.Read(IS, out GlobalMailIdxAtCreateTime);
		ViGameSerializer<UInt16>.Read(IS, out MaxSize);
		ViGameSerializer<MailProperty>.Read(IS, out MailList);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out MailTargetList);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<UInt32>.Append(OS, head + "GlobalMailIdx", GlobalMailIdx);
		ViGameSerializer<UInt32>.Append(OS, head + "GlobalMailIdxAtCreateTime", GlobalMailIdxAtCreateTime);
		ViGameSerializer<UInt16>.Append(OS, head + "MaxSize", MaxSize);
		ViGameSerializer<MailProperty>.Append(OS, head + "MailList", MailList);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "MailTargetList", MailTargetList);
	}
}

public class PlayerMailboxReceiveProperty : PlayerComponentReceiveProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentReceiveProperty.TYPE_SIZE + 5;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	private ViReceiveDataUInt32 GlobalMailIdx = new ViReceiveDataUInt32();//DB
	private ViReceiveDataUInt32 GlobalMailIdxAtCreateTime = new ViReceiveDataUInt32();//DB
	public ViReceiveDataUInt16 MaxSize = new ViReceiveDataUInt16();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataMailProperty, MailProperty> MailList = new ViReceiveDataArray<ReceiveDataMailProperty, MailProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataPlayerIdentificationProperty, PlayerIdentificationProperty> MailTargetList = new ViReceiveDataArray<ReceiveDataPlayerIdentificationProperty, PlayerIdentificationProperty>();//OWN_CLIENT+DB
	//
	public PlayerMailboxReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		GlobalMailIdx.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GlobalMailIdxAtCreateTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MaxSize.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MailList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MailTargetList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		GlobalMailIdx.Start(channelMask, IS, entity);
		GlobalMailIdxAtCreateTime.Start(channelMask, IS, entity);
		MaxSize.Start(channelMask, IS, entity);
		MailList.Start(channelMask, IS, entity);
		MailTargetList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		GlobalMailIdx.End(entity);
		GlobalMailIdxAtCreateTime.End(entity);
		MaxSize.End(entity);
		MailList.End(entity);
		MailTargetList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		GlobalMailIdx.Clear();
		GlobalMailIdxAtCreateTime.Clear();
		MaxSize.Clear();
		MailList.Clear();
		MailTargetList.Clear();
	}
}
