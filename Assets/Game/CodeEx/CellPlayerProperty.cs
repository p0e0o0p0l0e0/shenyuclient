using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellPlayerProperty
{
	public static readonly int TYPE_SIZE = 12;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt32 CenterPackID;//
	public PlayerIdentificationProperty Identification;//
	public UInt32 Space;//CENTER+OWN_CLIENT
	public UInt8 Faction;//CENTER+OWN_CLIENT
	public float LevelRewardScale;//CENTER+OWN_CLIENT
	public ViVector3 Pos;//CENTER
	public UInt64 FocusPlayer;//CENTER
	public UInt8 AutoAct;//OWN_CLIENT
	public Dictionary<UInt32, ProgressProperty> ScriptProgressList;//OWN_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt32>.Read(IS, out CenterPackID);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Identification);
		ViGameSerializer<UInt32>.Read(IS, out Space);
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		ViGameSerializer<float>.Read(IS, out LevelRewardScale);
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		ViGameSerializer<UInt64>.Read(IS, out FocusPlayer);
		ViGameSerializer<UInt8>.Read(IS, out AutoAct);
		ViGameSerializer<ProgressProperty>.Read(IS, out ScriptProgressList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt32>.Append(OS, head + "CenterPackID", CenterPackID);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Identification", Identification);
		ViGameSerializer<UInt32>.Append(OS, head + "Space", Space);
		ViGameSerializer<UInt8>.Append(OS, head + "Faction", Faction);
		ViGameSerializer<float>.Append(OS, head + "LevelRewardScale", LevelRewardScale);
		ViGameSerializer<ViVector3>.Append(OS, head + "Pos", Pos);
		ViGameSerializer<UInt64>.Append(OS, head + "FocusPlayer", FocusPlayer);
		ViGameSerializer<UInt8>.Append(OS, head + "AutoAct", AutoAct);
		ViGameSerializer<ProgressProperty>.Append(OS, head + "ScriptProgressList", ScriptProgressList);
	}
}

public class CellPlayerReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 12;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt32 CenterPackID = new ViReceiveDataUInt32();//
	private ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();//
	public ViReceiveDataUInt32 Space = new ViReceiveDataUInt32();//CENTER+OWN_CLIENT
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();//CENTER+OWN_CLIENT
	public ViReceiveDataFloat LevelRewardScale = new ViReceiveDataFloat();//CENTER+OWN_CLIENT
	private ViReceiveDataVector3 Pos = new ViReceiveDataVector3();//CENTER
	private ViReceiveDataUInt64 FocusPlayer = new ViReceiveDataUInt64();//CENTER
	public ViReceiveDataUInt8 AutoAct = new ViReceiveDataUInt8();//OWN_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty> ScriptProgressList = new ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty>();//OWN_CLIENT
	//
	public CellPlayerReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		CenterPackID.RegisterAsChild((UInt16)(0), this, ChildList);
		Identification.RegisterAsChild((UInt16)(0), this, ChildList);
		Space.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		Faction.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		LevelRewardScale.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER) | (1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		Pos.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		FocusPlayer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		AutoAct.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		ScriptProgressList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
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
		CenterPackID.Start(channelMask, IS, entity);
		Identification.Start(channelMask, IS, entity);
		Space.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
		LevelRewardScale.Start(channelMask, IS, entity);
		Pos.Start(channelMask, IS, entity);
		FocusPlayer.Start(channelMask, IS, entity);
		AutoAct.Start(channelMask, IS, entity);
		ScriptProgressList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		CenterPackID.End(entity);
		Identification.End(entity);
		Space.End(entity);
		Faction.End(entity);
		LevelRewardScale.End(entity);
		Pos.End(entity);
		FocusPlayer.End(entity);
		AutoAct.End(entity);
		ScriptProgressList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		CenterPackID.Clear();
		Identification.Clear();
		Space.Clear();
		Faction.Clear();
		LevelRewardScale.Clear();
		Pos.Clear();
		FocusPlayer.Clear();
		AutoAct.Clear();
		ScriptProgressList.Clear();
	}
}
