using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ActivityRecordProperty
{
	public static readonly int TYPE_SIZE = 8;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public ViForeignKey<ActivityStruct> Info;//ALL_CLIENT
	public Int64 StartTime1970;//ALL_CLIENT
	public ActivityStatisticsProperty Statistics;//ALL_CLIENT
	public Dictionary<UInt64, AccmulateDurationProperty> EntityDurationList;//ALL_CLIENT
	public Dictionary<UInt32, ProgressProperty> ScriptProgressList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<ViForeignKey<ActivityStruct>>.Read(IS, out Info);
		ViGameSerializer<Int64>.Read(IS, out StartTime1970);
		ViGameSerializer<ActivityStatisticsProperty>.Read(IS, out Statistics);
		ViGameSerializer<AccmulateDurationProperty>.Read(IS, out EntityDurationList);
		ViGameSerializer<ProgressProperty>.Read(IS, out ScriptProgressList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<ViForeignKey<ActivityStruct>>.Append(OS, head + "Info", Info);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime1970", StartTime1970);
		ViGameSerializer<ActivityStatisticsProperty>.Append(OS, head + "Statistics", Statistics);
		ViGameSerializer<AccmulateDurationProperty>.Append(OS, head + "EntityDurationList", EntityDurationList);
		ViGameSerializer<ProgressProperty>.Append(OS, head + "ScriptProgressList", ScriptProgressList);
	}
}

public class ActivityRecordReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 8;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataForeignKey<ActivityStruct> Info = new ViReceiveDataForeignKey<ActivityStruct>();//ALL_CLIENT
	public ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();//ALL_CLIENT
	public ReceiveDataActivityStatisticsProperty Statistics = new ReceiveDataActivityStatisticsProperty();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataAccmulateDurationProperty, AccmulateDurationProperty> EntityDurationList = new ViReceiveDataDictionary<UInt64, ReceiveDataAccmulateDurationProperty, AccmulateDurationProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty> ScriptProgressList = new ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty>();//ALL_CLIENT
	//
	public ActivityRecordReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Info.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		StartTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Statistics.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EntityDurationList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ScriptProgressList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		StartTime1970.Start(channelMask, IS, entity);
		Statistics.Start(channelMask, IS, entity);
		EntityDurationList.Start(channelMask, IS, entity);
		ScriptProgressList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Info.End(entity);
		StartTime1970.End(entity);
		Statistics.End(entity);
		EntityDurationList.End(entity);
		ScriptProgressList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Info.Clear();
		StartTime1970.Clear();
		Statistics.Clear();
		EntityDurationList.Clear();
		ScriptProgressList.Clear();
	}
}
