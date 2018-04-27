using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PublicSpaceManagerProperty
{
	public static readonly int TYPE_SIZE = 2;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Dictionary<UInt64, PublicSpaceEnterGroupProperty> GroupList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<PublicSpaceEnterGroupProperty>.Read(IS, out GroupList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<PublicSpaceEnterGroupProperty>.Append(OS, head + "GroupList", GroupList);
	}
}

public class PublicSpaceManagerReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 2;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	public ViReceiveDataDictionary<UInt64, ReceiveDataPublicSpaceEnterGroupProperty, PublicSpaceEnterGroupProperty> GroupList = new ViReceiveDataDictionary<UInt64, ReceiveDataPublicSpaceEnterGroupProperty, PublicSpaceEnterGroupProperty>();//ALL_CLIENT
	//
	public PublicSpaceManagerReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GroupList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		GroupList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		GroupList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		GroupList.Clear();
	}
}
