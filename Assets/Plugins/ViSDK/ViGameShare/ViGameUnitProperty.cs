using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ViGameUnitProperty
{
	public static readonly int TYPE_SIZE = 6;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt32 ActionStateMask;//ALL_CLIENT
	public UInt32 AuraStateMask;//OWN_CLIENT
	public UInt32 SpaceStateMask;//OWN_CLIENT
	public List<VisualAuraProperty> VisualAuraPropertyList;//ALL_CLIENT
	public List<LogicAuraProperty> LogicAuraPropertyList;//
	public Dictionary<UInt32, DisSpellProperty> DisSpellList;//
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt32>.Read(IS, out ActionStateMask);
		ViGameSerializer<UInt32>.Read(IS, out AuraStateMask);
		ViGameSerializer<UInt32>.Read(IS, out SpaceStateMask);
		ViGameSerializer<VisualAuraProperty>.Read(IS, out VisualAuraPropertyList);
		ViGameSerializer<LogicAuraProperty>.Read(IS, out LogicAuraPropertyList);
		ViGameSerializer<DisSpellProperty>.Read(IS, out DisSpellList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt32>.Append(OS, head + "ActionStateMask", ActionStateMask);
		ViGameSerializer<UInt32>.Append(OS, head + "AuraStateMask", AuraStateMask);
		ViGameSerializer<UInt32>.Append(OS, head + "SpaceStateMask", SpaceStateMask);
		ViGameSerializer<VisualAuraProperty>.Append(OS, head + "VisualAuraPropertyList", VisualAuraPropertyList);
		ViGameSerializer<LogicAuraProperty>.Append(OS, head + "LogicAuraPropertyList", LogicAuraPropertyList);
		ViGameSerializer<DisSpellProperty>.Append(OS, head + "DisSpellList", DisSpellList);
	}
}

public class ViGameUnitReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 6;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataUInt32 ActionStateMask = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataUInt32 AuraStateMask = new ViReceiveDataUInt32();//OWN_CLIENT
	public ViReceiveDataUInt32 SpaceStateMask = new ViReceiveDataUInt32();//OWN_CLIENT
	public ViReceiveDataArray<ReceiveDataVisualAuraProperty, VisualAuraProperty> VisualAuraPropertyList = new ViReceiveDataArray<ReceiveDataVisualAuraProperty, VisualAuraProperty>();//ALL_CLIENT
	private ViReceiveDataArray<ReceiveDataLogicAuraProperty, LogicAuraProperty> LogicAuraPropertyList = new ViReceiveDataArray<ReceiveDataLogicAuraProperty, LogicAuraProperty>();//
	private ViReceiveDataDictionary<UInt32, ReceiveDataDisSpellProperty, DisSpellProperty> DisSpellList = new ViReceiveDataDictionary<UInt32, ReceiveDataDisSpellProperty, DisSpellProperty>();//
	//
	public ViGameUnitReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		ActionStateMask.RegisterAsChild((UInt16)((1 << (int)ViGameLogicChannel.ALL_CLIENT)), this, ChildList);
		AuraStateMask.RegisterAsChild((UInt16)((1 << (int)ViGameLogicChannel.OWN_CLIENT)), this, ChildList);
		SpaceStateMask.RegisterAsChild((UInt16)((1 << (int)ViGameLogicChannel.OWN_CLIENT)), this, ChildList);
		VisualAuraPropertyList.RegisterAsChild((UInt16)((1 << (int)ViGameLogicChannel.ALL_CLIENT)), this, ChildList);
		LogicAuraPropertyList.RegisterAsChild((UInt16)(0), this, ChildList);
		DisSpellList.RegisterAsChild((UInt16)(0), this, ChildList);
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
		ActionStateMask.Start(channelMask, IS, entity);
		AuraStateMask.Start(channelMask, IS, entity);
		SpaceStateMask.Start(channelMask, IS, entity);
		VisualAuraPropertyList.Start(channelMask, IS, entity);
		LogicAuraPropertyList.Start(channelMask, IS, entity);
		DisSpellList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		ActionStateMask.End(entity);
		AuraStateMask.End(entity);
		SpaceStateMask.End(entity);
		VisualAuraPropertyList.End(entity);
		LogicAuraPropertyList.End(entity);
		DisSpellList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		ActionStateMask.Clear();
		AuraStateMask.Clear();
		SpaceStateMask.Clear();
		VisualAuraPropertyList.Clear();
		LogicAuraPropertyList.Clear();
		DisSpellList.Clear();
	}
}
