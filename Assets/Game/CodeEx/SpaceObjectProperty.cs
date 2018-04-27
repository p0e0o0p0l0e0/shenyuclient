using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceObjectProperty
{
	public static readonly int TYPE_SIZE = 5;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt32 Template;//ALL_CLIENT
	public UInt32 BirthPosID;//ALL_CLIENT
	public UInt8 State;//ALL_CLIENT
	public Int64 EndTime;//ALL_CLIENT
	public Dictionary<ViString, Int64Property> VisibleIntValueList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt32>.Read(IS, out Template);
		ViGameSerializer<UInt32>.Read(IS, out BirthPosID);
		ViGameSerializer<UInt8>.Read(IS, out State);
		ViGameSerializer<Int64>.Read(IS, out EndTime);
		ViGameSerializer<Int64Property>.Read(IS, out VisibleIntValueList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt32>.Append(OS, head + "Template", Template);
		ViGameSerializer<UInt32>.Append(OS, head + "BirthPosID", BirthPosID);
		ViGameSerializer<UInt8>.Append(OS, head + "State", State);
		ViGameSerializer<Int64>.Append(OS, head + "EndTime", EndTime);
		ViGameSerializer<Int64Property>.Append(OS, head + "VisibleIntValueList", VisibleIntValueList);
	}
}

public class SpaceObjectReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 5;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataUInt32 Template = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataUInt32 BirthPosID = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();//ALL_CLIENT
	public ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property> VisibleIntValueList = new ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property>();//ALL_CLIENT
	//
	public SpaceObjectReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Template.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BirthPosID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		State.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EndTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		VisibleIntValueList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		BirthPosID.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		VisibleIntValueList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Template.End(entity);
		BirthPosID.End(entity);
		State.End(entity);
		EndTime.End(entity);
		VisibleIntValueList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Template.Clear();
		BirthPosID.Clear();
		State.Clear();
		EndTime.Clear();
		VisibleIntValueList.Clear();
	}
}
