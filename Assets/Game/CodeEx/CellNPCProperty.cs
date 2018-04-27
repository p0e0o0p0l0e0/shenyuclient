using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellNPCProperty : GameUnitProperty
{
	public static readonly new int TYPE_SIZE = GameUnitProperty.TYPE_SIZE + 4;
	public static readonly new int INDEX_PROPERTY_COUNT = GameUnitProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public UInt32 Template;//ALL_CLIENT
	public UInt32 BirthPos;//ALL_CLIENT
	public UInt32 BirthPosIndex;//ALL_CLIENT
	public Int64 AttackedEventCDEndTime;//
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<UInt32>.Read(IS, out Template);
		ViGameSerializer<UInt32>.Read(IS, out BirthPos);
		ViGameSerializer<UInt32>.Read(IS, out BirthPosIndex);
		ViGameSerializer<Int64>.Read(IS, out AttackedEventCDEndTime);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<UInt32>.Append(OS, head + "Template", Template);
		ViGameSerializer<UInt32>.Append(OS, head + "BirthPos", BirthPos);
		ViGameSerializer<UInt32>.Append(OS, head + "BirthPosIndex", BirthPosIndex);
		ViGameSerializer<Int64>.Append(OS, head + "AttackedEventCDEndTime", AttackedEventCDEndTime);
	}
}

public class CellNPCReceiveProperty : GameUnitReceiveProperty
{
	public static readonly new int TYPE_SIZE = GameUnitReceiveProperty.TYPE_SIZE + 4;
	public static readonly new int INDEX_PROPERTY_COUNT = GameUnitReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public ViReceiveDataUInt32 Template = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataUInt32 BirthPos = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataUInt32 BirthPosIndex = new ViReceiveDataUInt32();//ALL_CLIENT
	private ViReceiveDataInt64 AttackedEventCDEndTime = new ViReceiveDataInt64();//
	//
	public CellNPCReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Template.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BirthPos.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BirthPosIndex.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		AttackedEventCDEndTime.RegisterAsChild((UInt16)(0), this, ChildList);
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
		Template.Start(channelMask, IS, entity);
		BirthPos.Start(channelMask, IS, entity);
		BirthPosIndex.Start(channelMask, IS, entity);
		AttackedEventCDEndTime.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Template.End(entity);
		BirthPos.End(entity);
		BirthPosIndex.End(entity);
		AttackedEventCDEndTime.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Template.Clear();
		BirthPos.Clear();
		BirthPosIndex.Clear();
		AttackedEventCDEndTime.Clear();
	}
}
