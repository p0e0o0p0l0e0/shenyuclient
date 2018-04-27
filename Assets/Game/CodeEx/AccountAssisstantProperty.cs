using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AccountAssisstantProperty
{
	public static readonly int TYPE_SIZE = 3;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Int16 MergeCount;//DB
	public List<RechargeProperty> RechargeList;//DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<Int16>.Read(IS, out MergeCount);
		ViGameSerializer<RechargeProperty>.Read(IS, out RechargeList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<Int16>.Append(OS, head + "MergeCount", MergeCount);
		ViGameSerializer<RechargeProperty>.Append(OS, head + "RechargeList", RechargeList);
	}
}

public class AccountAssisstantReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 3;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataInt16 MergeCount = new ViReceiveDataInt16();//DB
	private ViReceiveDataArray<ReceiveDataRechargeProperty, RechargeProperty> RechargeList = new ViReceiveDataArray<ReceiveDataRechargeProperty, RechargeProperty>();//DB
	//
	public AccountAssisstantReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MergeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RechargeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		MergeCount.Start(channelMask, IS, entity);
		RechargeList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		MergeCount.End(entity);
		RechargeList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		MergeCount.Clear();
		RechargeList.Clear();
	}
}
