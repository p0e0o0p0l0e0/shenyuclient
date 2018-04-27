using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameSpaceFactionRecordProperty
{
	public static readonly int TYPE_SIZE = 8;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt8 Faction;//ALL_CLIENT
	public UInt8 EraseExitMember;//ALL_CLIENT
	public Int64 Score;//ALL_CLIENT
	public Int16 Step;//ALL_CLIENT
	public Dictionary<UInt64, SpaceFactionHeroMemberProperty> HeroList;//ALL_CLIENT
	public Dictionary<UInt32, ProgressProperty> ScriptProgressList;//ALL_CLIENT
	public Dictionary<UInt32, Int64Property> NPCKilledList;//ALL_CLIENT
	public HashSet<UInt64> PlayerWorkingList;//ALL_CLIENT
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		ViGameSerializer<UInt8>.Read(IS, out EraseExitMember);
		ViGameSerializer<Int64>.Read(IS, out Score);
		ViGameSerializer<Int16>.Read(IS, out Step);
		ViGameSerializer<SpaceFactionHeroMemberProperty>.Read(IS, out HeroList);
		ViGameSerializer<ProgressProperty>.Read(IS, out ScriptProgressList);
		ViGameSerializer<Int64Property>.Read(IS, out NPCKilledList);
		ViGameSerializer<UInt64>.Read(IS, out PlayerWorkingList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt8>.Append(OS, head + "Faction", Faction);
		ViGameSerializer<UInt8>.Append(OS, head + "EraseExitMember", EraseExitMember);
		ViGameSerializer<Int64>.Append(OS, head + "Score", Score);
		ViGameSerializer<Int16>.Append(OS, head + "Step", Step);
		ViGameSerializer<SpaceFactionHeroMemberProperty>.Append(OS, head + "HeroList", HeroList);
		ViGameSerializer<ProgressProperty>.Append(OS, head + "ScriptProgressList", ScriptProgressList);
		ViGameSerializer<Int64Property>.Append(OS, head + "NPCKilledList", NPCKilledList);
		ViGameSerializer<UInt64>.Append(OS, head + "PlayerWorkingList", PlayerWorkingList);
	}
}

public class GameSpaceFactionRecordReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 8;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataUInt8 EraseExitMember = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt64 Score = new ViReceiveDataInt64();//ALL_CLIENT
	public ViReceiveDataInt16 Step = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataSpaceFactionHeroMemberProperty, SpaceFactionHeroMemberProperty> HeroList = new ViReceiveDataDictionary<UInt64, ReceiveDataSpaceFactionHeroMemberProperty, SpaceFactionHeroMemberProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty> ScriptProgressList = new ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property> NPCKilledList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property>();//ALL_CLIENT
	public ViReceiveDataSet<UInt64> PlayerWorkingList = new ViReceiveDataSet<UInt64>();//ALL_CLIENT
	//
	public GameSpaceFactionRecordReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Faction.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EraseExitMember.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Score.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Step.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		HeroList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ScriptProgressList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		NPCKilledList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PlayerWorkingList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		Faction.Start(channelMask, IS, entity);
		EraseExitMember.Start(channelMask, IS, entity);
		Score.Start(channelMask, IS, entity);
		Step.Start(channelMask, IS, entity);
		HeroList.Start(channelMask, IS, entity);
		ScriptProgressList.Start(channelMask, IS, entity);
		NPCKilledList.Start(channelMask, IS, entity);
		PlayerWorkingList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Faction.End(entity);
		EraseExitMember.End(entity);
		Score.End(entity);
		Step.End(entity);
		HeroList.End(entity);
		ScriptProgressList.End(entity);
		NPCKilledList.End(entity);
		PlayerWorkingList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Faction.Clear();
		EraseExitMember.Clear();
		Score.Clear();
		Step.Clear();
		HeroList.Clear();
		ScriptProgressList.Clear();
		NPCKilledList.Clear();
		PlayerWorkingList.Clear();
	}
}
