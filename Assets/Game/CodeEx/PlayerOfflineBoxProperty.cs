using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerOfflineBoxProperty : PlayerComponentProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentProperty.TYPE_SIZE + 4;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public UInt32 GlobalGMIdx;//DB
	public UInt32 GlobalGMIdxAtCreateTime;//DB
	public List<GMContentProperty> GMRecordList;//DB
	public List<ChatRecordProperty> OfflineChatList;//OWN_CLIENT+DB
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<UInt32>.Read(IS, out GlobalGMIdx);
		ViGameSerializer<UInt32>.Read(IS, out GlobalGMIdxAtCreateTime);
		ViGameSerializer<GMContentProperty>.Read(IS, out GMRecordList);
		ViGameSerializer<ChatRecordProperty>.Read(IS, out OfflineChatList);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<UInt32>.Append(OS, head + "GlobalGMIdx", GlobalGMIdx);
		ViGameSerializer<UInt32>.Append(OS, head + "GlobalGMIdxAtCreateTime", GlobalGMIdxAtCreateTime);
		ViGameSerializer<GMContentProperty>.Append(OS, head + "GMRecordList", GMRecordList);
		ViGameSerializer<ChatRecordProperty>.Append(OS, head + "OfflineChatList", OfflineChatList);
	}
}

public class PlayerOfflineBoxReceiveProperty : PlayerComponentReceiveProperty
{
	public static readonly new int TYPE_SIZE = PlayerComponentReceiveProperty.TYPE_SIZE + 4;
	public static readonly new int INDEX_PROPERTY_COUNT = PlayerComponentReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	private ViReceiveDataUInt32 GlobalGMIdx = new ViReceiveDataUInt32();//DB
	private ViReceiveDataUInt32 GlobalGMIdxAtCreateTime = new ViReceiveDataUInt32();//DB
	private ViReceiveDataArray<ReceiveDataGMContentProperty, GMContentProperty> GMRecordList = new ViReceiveDataArray<ReceiveDataGMContentProperty, GMContentProperty>();//DB
	public ViReceiveDataArray<ReceiveDataChatRecordProperty, ChatRecordProperty> OfflineChatList = new ViReceiveDataArray<ReceiveDataChatRecordProperty, ChatRecordProperty>();//OWN_CLIENT+DB
	//
	public PlayerOfflineBoxReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		GlobalGMIdx.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GlobalGMIdxAtCreateTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GMRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OfflineChatList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		GlobalGMIdx.Start(channelMask, IS, entity);
		GlobalGMIdxAtCreateTime.Start(channelMask, IS, entity);
		GMRecordList.Start(channelMask, IS, entity);
		OfflineChatList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		GlobalGMIdx.End(entity);
		GlobalGMIdxAtCreateTime.End(entity);
		GMRecordList.End(entity);
		OfflineChatList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		GlobalGMIdx.Clear();
		GlobalGMIdxAtCreateTime.Clear();
		GMRecordList.Clear();
		OfflineChatList.Clear();
	}
}
