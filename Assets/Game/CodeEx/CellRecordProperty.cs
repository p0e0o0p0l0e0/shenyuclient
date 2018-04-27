using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellRecordProperty
{
	public static readonly int TYPE_SIZE = 13;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public Int64 StartTime;//ALL_CLIENT
	public Int64 StartTime1970;//
	public Int32 OnlineCount;//CENTER
	public Dictionary<UInt32, Int32Property> SpaceList;//CENTER
	public Int32 EntityCount;//
	public Int32 EntityIDCount;//
	public Int32 EntityPackIDCount;//
	public Int32 SpaceCount;//
	public Dictionary<UInt64, PlayerOnlineProperty> OnlinePlayerList;//
	public List<StringProperty> RPCExecNameList;//
	public List<Int64Property> RPCExecCountList;//
	public List<MemoryUseProperty> MemoryCountList0;//
	public List<MemoryUseProperty> MemoryCountList1;//
	public void Read(ViIStream IS)
	{
		ViGameSerializer<Int64>.Read(IS, out StartTime);
		ViGameSerializer<Int64>.Read(IS, out StartTime1970);
		ViGameSerializer<Int32>.Read(IS, out OnlineCount);
		ViGameSerializer<Int32Property>.Read(IS, out SpaceList);
		ViGameSerializer<Int32>.Read(IS, out EntityCount);
		ViGameSerializer<Int32>.Read(IS, out EntityIDCount);
		ViGameSerializer<Int32>.Read(IS, out EntityPackIDCount);
		ViGameSerializer<Int32>.Read(IS, out SpaceCount);
		ViGameSerializer<PlayerOnlineProperty>.Read(IS, out OnlinePlayerList);
		ViGameSerializer<StringProperty>.Read(IS, out RPCExecNameList);
		ViGameSerializer<Int64Property>.Read(IS, out RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out MemoryCountList1);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<Int64>.Append(OS, head + "StartTime", StartTime);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime1970", StartTime1970);
		ViGameSerializer<Int32>.Append(OS, head + "OnlineCount", OnlineCount);
		ViGameSerializer<Int32Property>.Append(OS, head + "SpaceList", SpaceList);
		ViGameSerializer<Int32>.Append(OS, head + "EntityCount", EntityCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityIDCount", EntityIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityPackIDCount", EntityPackIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "SpaceCount", SpaceCount);
		ViGameSerializer<PlayerOnlineProperty>.Append(OS, head + "OnlinePlayerList", OnlinePlayerList);
		ViGameSerializer<StringProperty>.Append(OS, head + "RPCExecNameList", RPCExecNameList);
		ViGameSerializer<Int64Property>.Append(OS, head + "RPCExecCountList", RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + "MemoryCountList0", MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + "MemoryCountList1", MemoryCountList1);
	}
}

public class CellRecordReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 13;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();//ALL_CLIENT
	private ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();//
	private ViReceiveDataInt32 OnlineCount = new ViReceiveDataInt32();//CENTER
	private ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property> SpaceList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property>();//CENTER
	private ViReceiveDataInt32 EntityCount = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 EntityIDCount = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 EntityPackIDCount = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SpaceCount = new ViReceiveDataInt32();//
	private ViReceiveDataDictionary<UInt64, ReceiveDataPlayerOnlineProperty, PlayerOnlineProperty> OnlinePlayerList = new ViReceiveDataDictionary<UInt64, ReceiveDataPlayerOnlineProperty, PlayerOnlineProperty>();//
	private ViReceiveDataArray<ReceiveDataStringProperty, StringProperty> RPCExecNameList = new ViReceiveDataArray<ReceiveDataStringProperty, StringProperty>();//
	private ViReceiveDataArray<ReceiveDataInt64Property, Int64Property> RPCExecCountList = new ViReceiveDataArray<ReceiveDataInt64Property, Int64Property>();//
	private ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty> MemoryCountList0 = new ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty>();//
	private ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty> MemoryCountList1 = new ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty>();//
	//
	public CellRecordReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		StartTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		StartTime1970.RegisterAsChild((UInt16)(0), this, ChildList);
		OnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		SpaceList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		EntityCount.RegisterAsChild((UInt16)(0), this, ChildList);
		EntityIDCount.RegisterAsChild((UInt16)(0), this, ChildList);
		EntityPackIDCount.RegisterAsChild((UInt16)(0), this, ChildList);
		SpaceCount.RegisterAsChild((UInt16)(0), this, ChildList);
		OnlinePlayerList.RegisterAsChild((UInt16)(0), this, ChildList);
		RPCExecNameList.RegisterAsChild((UInt16)(0), this, ChildList);
		RPCExecCountList.RegisterAsChild((UInt16)(0), this, ChildList);
		MemoryCountList0.RegisterAsChild((UInt16)(0), this, ChildList);
		MemoryCountList1.RegisterAsChild((UInt16)(0), this, ChildList);
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
		StartTime.Start(channelMask, IS, entity);
		StartTime1970.Start(channelMask, IS, entity);
		OnlineCount.Start(channelMask, IS, entity);
		SpaceList.Start(channelMask, IS, entity);
		EntityCount.Start(channelMask, IS, entity);
		EntityIDCount.Start(channelMask, IS, entity);
		EntityPackIDCount.Start(channelMask, IS, entity);
		SpaceCount.Start(channelMask, IS, entity);
		OnlinePlayerList.Start(channelMask, IS, entity);
		RPCExecNameList.Start(channelMask, IS, entity);
		RPCExecCountList.Start(channelMask, IS, entity);
		MemoryCountList0.Start(channelMask, IS, entity);
		MemoryCountList1.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		StartTime.End(entity);
		StartTime1970.End(entity);
		OnlineCount.End(entity);
		SpaceList.End(entity);
		EntityCount.End(entity);
		EntityIDCount.End(entity);
		EntityPackIDCount.End(entity);
		SpaceCount.End(entity);
		OnlinePlayerList.End(entity);
		RPCExecNameList.End(entity);
		RPCExecCountList.End(entity);
		MemoryCountList0.End(entity);
		MemoryCountList1.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		StartTime.Clear();
		StartTime1970.Clear();
		OnlineCount.Clear();
		SpaceList.Clear();
		EntityCount.Clear();
		EntityIDCount.Clear();
		EntityPackIDCount.Clear();
		SpaceCount.Clear();
		OnlinePlayerList.Clear();
		RPCExecNameList.Clear();
		RPCExecCountList.Clear();
		MemoryCountList0.Clear();
		MemoryCountList1.Clear();
	}
}
