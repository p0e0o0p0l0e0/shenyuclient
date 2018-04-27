using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceMatchManagerProperty
{
	public static readonly int TYPE_SIZE = 4;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Dictionary<UInt32, SpaceMatchProperty> PVPMatchList;//ALL_CLIENT
	public Dictionary<UInt32, SpaceMatchProperty> PVAMatchList;//ALL_CLIENT
	public Dictionary<UInt32, SpaceMatchProperty> PVEMatchList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<SpaceMatchProperty>.Read(IS, out PVPMatchList);
		ViGameSerializer<SpaceMatchProperty>.Read(IS, out PVAMatchList);
		ViGameSerializer<SpaceMatchProperty>.Read(IS, out PVEMatchList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<SpaceMatchProperty>.Append(OS, head + "PVPMatchList", PVPMatchList);
		ViGameSerializer<SpaceMatchProperty>.Append(OS, head + "PVAMatchList", PVAMatchList);
		ViGameSerializer<SpaceMatchProperty>.Append(OS, head + "PVEMatchList", PVEMatchList);
	}
}

public class SpaceMatchManagerReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 4;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceMatchProperty, SpaceMatchProperty> PVPMatchList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceMatchProperty, SpaceMatchProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceMatchProperty, SpaceMatchProperty> PVAMatchList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceMatchProperty, SpaceMatchProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceMatchProperty, SpaceMatchProperty> PVEMatchList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceMatchProperty, SpaceMatchProperty>();//ALL_CLIENT
	//
	public SpaceMatchManagerReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PVPMatchList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PVAMatchList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PVEMatchList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		PVPMatchList.Start(channelMask, IS, entity);
		PVAMatchList.Start(channelMask, IS, entity);
		PVEMatchList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		PVPMatchList.End(entity);
		PVAMatchList.End(entity);
		PVEMatchList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		PVPMatchList.Clear();
		PVAMatchList.Clear();
		PVEMatchList.Clear();
	}
}
