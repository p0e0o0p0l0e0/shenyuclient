using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CenterChatGroupProperty
{
	public static readonly int TYPE_SIZE = 2;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public ViString Name;//ALL_CLIENT
	public UInt8 Channel;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<ViString>.Read(IS, out Name);
		ViGameSerializer<UInt8>.Read(IS, out Channel);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<ViString>.Append(OS, head + "Name", Name);
		ViGameSerializer<UInt8>.Append(OS, head + "Channel", Channel);
	}
}

public class CenterChatGroupReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 2;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataString Name = new ViReceiveDataString();//ALL_CLIENT
	public ViReceiveDataUInt8 Channel = new ViReceiveDataUInt8();//ALL_CLIENT
	//
	public CenterChatGroupReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Name.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Channel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		Channel.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Name.End(entity);
		Channel.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Name.Clear();
		Channel.Clear();
	}
}
