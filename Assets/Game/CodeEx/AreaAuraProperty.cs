using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AreaAuraProperty
{
	public static readonly int TYPE_SIZE = 8;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt32 Template;//ALL_CLIENT
	public Int32 LevelValue;//ALL_CLIENT
	public UInt8 Faction;//ALL_CLIENT
	public UInt64PtrProperty Team;//ALL_CLIENT
	public UInt64 CasterID;//ALL_CLIENT
	public UInt32 CasterPackID;//ALL_CLIENT
	public Int16 Speed;//ALL_CLIENT
	public Int64 EndTime;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt32>.Read(IS, out Template);
		ViGameSerializer<Int32>.Read(IS, out LevelValue);
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		ViGameSerializer<UInt64PtrProperty>.Read(IS, out Team);
		ViGameSerializer<UInt64>.Read(IS, out CasterID);
		ViGameSerializer<UInt32>.Read(IS, out CasterPackID);
		ViGameSerializer<Int16>.Read(IS, out Speed);
		ViGameSerializer<Int64>.Read(IS, out EndTime);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt32>.Append(OS, head + "Template", Template);
		ViGameSerializer<Int32>.Append(OS, head + "LevelValue", LevelValue);
		ViGameSerializer<UInt8>.Append(OS, head + "Faction", Faction);
		ViGameSerializer<UInt64PtrProperty>.Append(OS, head + "Team", Team);
		ViGameSerializer<UInt64>.Append(OS, head + "CasterID", CasterID);
		ViGameSerializer<UInt32>.Append(OS, head + "CasterPackID", CasterPackID);
		ViGameSerializer<Int16>.Append(OS, head + "Speed", Speed);
		ViGameSerializer<Int64>.Append(OS, head + "EndTime", EndTime);
	}
}

public class AreaAuraReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 8;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataUInt32 Template = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataInt32 LevelValue = new ViReceiveDataInt32();//ALL_CLIENT
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();//ALL_CLIENT
	public ReceiveDataUInt64PtrProperty Team = new ReceiveDataUInt64PtrProperty();//ALL_CLIENT
	public ViReceiveDataUInt64 CasterID = new ViReceiveDataUInt64();//ALL_CLIENT
	public ViReceiveDataUInt32 CasterPackID = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataInt16 Speed = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();//ALL_CLIENT
	//
	public AreaAuraReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Template.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		LevelValue.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Faction.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Team.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		CasterID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		CasterPackID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Speed.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EndTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		LevelValue.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
		Team.Start(channelMask, IS, entity);
		CasterID.Start(channelMask, IS, entity);
		CasterPackID.Start(channelMask, IS, entity);
		Speed.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Template.End(entity);
		LevelValue.End(entity);
		Faction.End(entity);
		Team.End(entity);
		CasterID.End(entity);
		CasterPackID.End(entity);
		Speed.End(entity);
		EndTime.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Template.Clear();
		LevelValue.Clear();
		Faction.Clear();
		Team.Clear();
		CasterID.Clear();
		CasterPackID.Clear();
		Speed.Clear();
		EndTime.Clear();
	}
}
