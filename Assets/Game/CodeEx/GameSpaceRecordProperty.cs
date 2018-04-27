using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameSpaceRecordProperty
{
	public static readonly int TYPE_SIZE = 42;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 ID;//
	public ViForeignKey<SpaceStruct> Info;//ALL_CLIENT
	public UInt8 Public;//ALL_CLIENT
	public PlayerIdentificationProperty Owner;//ALL_CLIENT
	public Int16 OwnerLevel;//ALL_CLIENT
	public Int64 StartTime;//ALL_CLIENT
	public Int64 EndTime;//ALL_CLIENT
	public UInt8 State;//ALL_CLIENT
	public Int16 Level;//ALL_CLIENT
	public Int16 ModLevel;//ALL_CLIENT
	public UInt8 MatchType;//ALL_CLIENT
	public UInt8 PKType;//ALL_CLIENT
	public Int8 FactionCount;//ALL_CLIENT
	public UInt8 Exitable;//ALL_CLIENT
	public UInt8 EraseExitMember;//ALL_CLIENT
	public Int16 MemberCountSup;//ALL_CLIENT
	public UInt8 BroadcastPropertyToCenter;//ALL_CLIENT
	public double HeroHPMaxScale;//ALL_CLIENT
	public double NPCHPPercScale;//ALL_CLIENT
	public double Progress;//ALL_CLIENT
	public Dictionary<UInt64, SpacePlayerMemberProperty> PlayerList;//ALL_CLIENT
	public Dictionary<UInt64, SpaceHeroMemberProperty> HeroList;//ALL_CLIENT
	public Dictionary<UInt64, SpaceDamageOutProperty> PlayerDamageOutList;//ALL_CLIENT
	public Dictionary<UInt32, SpaceBirthControllerProperty> BirthControllerList;//ALL_CLIENT
	public Dictionary<UInt32, SpaceBirthControllerShowProperty> BirthControllerShowList;//ALL_CLIENT
	public Dictionary<UInt32, SpaceEventProperty> EventList;//ALL_CLIENT
	public List<SpaceEventCacheProperty> EventCacheList;//ALL_CLIENT
	public List<SpaceBlockSlotProperty> BlockSlotList;//ALL_CLIENT
	public List<SpaceHideSlotProperty> HideSlotList;//ALL_CLIENT
	public HashSet<UInt32> CompletedStoryList;//ALL_CLIENT
	public List<Int64Property> FactionScoreList;//ALL_CLIENT
	public Dictionary<UInt32, ProgressProperty> ScriptProgressList;//ALL_CLIENT
	public HashSet<ViString> ScriptList;//ALL_CLIENT
	public Dictionary<ViString, Int64Property> ScriptValueList;//ALL_CLIENT
	public Dictionary<UInt64, MatchSpaceMemberScoreProperty> MatchScoreList;//ALL_CLIENT
	public Int32 NPCCount;//
	public Int32 NPCAccumulateCount;//
	public Int32 SpaceObjectCount;//
	public Int32 SpaceObjectAccumulateCount;//
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out ID);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Read(IS, out Info);
		ViGameSerializer<UInt8>.Read(IS, out Public);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Owner);
		ViGameSerializer<Int16>.Read(IS, out OwnerLevel);
		ViGameSerializer<Int64>.Read(IS, out StartTime);
		ViGameSerializer<Int64>.Read(IS, out EndTime);
		ViGameSerializer<UInt8>.Read(IS, out State);
		ViGameSerializer<Int16>.Read(IS, out Level);
		ViGameSerializer<Int16>.Read(IS, out ModLevel);
		ViGameSerializer<UInt8>.Read(IS, out MatchType);
		ViGameSerializer<UInt8>.Read(IS, out PKType);
		ViGameSerializer<Int8>.Read(IS, out FactionCount);
		ViGameSerializer<UInt8>.Read(IS, out Exitable);
		ViGameSerializer<UInt8>.Read(IS, out EraseExitMember);
		ViGameSerializer<Int16>.Read(IS, out MemberCountSup);
		ViGameSerializer<UInt8>.Read(IS, out BroadcastPropertyToCenter);
		ViGameSerializer<double>.Read(IS, out HeroHPMaxScale);
		ViGameSerializer<double>.Read(IS, out NPCHPPercScale);
		ViGameSerializer<double>.Read(IS, out Progress);
		ViGameSerializer<SpacePlayerMemberProperty>.Read(IS, out PlayerList);
		ViGameSerializer<SpaceHeroMemberProperty>.Read(IS, out HeroList);
		ViGameSerializer<SpaceDamageOutProperty>.Read(IS, out PlayerDamageOutList);
		ViGameSerializer<SpaceBirthControllerProperty>.Read(IS, out BirthControllerList);
		ViGameSerializer<SpaceBirthControllerShowProperty>.Read(IS, out BirthControllerShowList);
		ViGameSerializer<SpaceEventProperty>.Read(IS, out EventList);
		ViGameSerializer<SpaceEventCacheProperty>.Read(IS, out EventCacheList);
		ViGameSerializer<SpaceBlockSlotProperty>.Read(IS, out BlockSlotList);
		ViGameSerializer<SpaceHideSlotProperty>.Read(IS, out HideSlotList);
		ViGameSerializer<UInt32>.Read(IS, out CompletedStoryList);
		ViGameSerializer<Int64Property>.Read(IS, out FactionScoreList);
		ViGameSerializer<ProgressProperty>.Read(IS, out ScriptProgressList);
		ViGameSerializer<ViString>.Read(IS, out ScriptList);
		ViGameSerializer<Int64Property>.Read(IS, out ScriptValueList);
		ViGameSerializer<MatchSpaceMemberScoreProperty>.Read(IS, out MatchScoreList);
		ViGameSerializer<Int32>.Read(IS, out NPCCount);
		ViGameSerializer<Int32>.Read(IS, out NPCAccumulateCount);
		ViGameSerializer<Int32>.Read(IS, out SpaceObjectCount);
		ViGameSerializer<Int32>.Read(IS, out SpaceObjectAccumulateCount);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "ID", ID);
		ViGameSerializer<ViForeignKey<SpaceStruct>>.Append(OS, head + "Info", Info);
		ViGameSerializer<UInt8>.Append(OS, head + "Public", Public);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "Owner", Owner);
		ViGameSerializer<Int16>.Append(OS, head + "OwnerLevel", OwnerLevel);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime", StartTime);
		ViGameSerializer<Int64>.Append(OS, head + "EndTime", EndTime);
		ViGameSerializer<UInt8>.Append(OS, head + "State", State);
		ViGameSerializer<Int16>.Append(OS, head + "Level", Level);
		ViGameSerializer<Int16>.Append(OS, head + "ModLevel", ModLevel);
		ViGameSerializer<UInt8>.Append(OS, head + "MatchType", MatchType);
		ViGameSerializer<UInt8>.Append(OS, head + "PKType", PKType);
		ViGameSerializer<Int8>.Append(OS, head + "FactionCount", FactionCount);
		ViGameSerializer<UInt8>.Append(OS, head + "Exitable", Exitable);
		ViGameSerializer<UInt8>.Append(OS, head + "EraseExitMember", EraseExitMember);
		ViGameSerializer<Int16>.Append(OS, head + "MemberCountSup", MemberCountSup);
		ViGameSerializer<UInt8>.Append(OS, head + "BroadcastPropertyToCenter", BroadcastPropertyToCenter);
		ViGameSerializer<double>.Append(OS, head + "HeroHPMaxScale", HeroHPMaxScale);
		ViGameSerializer<double>.Append(OS, head + "NPCHPPercScale", NPCHPPercScale);
		ViGameSerializer<double>.Append(OS, head + "Progress", Progress);
		ViGameSerializer<SpacePlayerMemberProperty>.Append(OS, head + "PlayerList", PlayerList);
		ViGameSerializer<SpaceHeroMemberProperty>.Append(OS, head + "HeroList", HeroList);
		ViGameSerializer<SpaceDamageOutProperty>.Append(OS, head + "PlayerDamageOutList", PlayerDamageOutList);
		ViGameSerializer<SpaceBirthControllerProperty>.Append(OS, head + "BirthControllerList", BirthControllerList);
		ViGameSerializer<SpaceBirthControllerShowProperty>.Append(OS, head + "BirthControllerShowList", BirthControllerShowList);
		ViGameSerializer<SpaceEventProperty>.Append(OS, head + "EventList", EventList);
		ViGameSerializer<SpaceEventCacheProperty>.Append(OS, head + "EventCacheList", EventCacheList);
		ViGameSerializer<SpaceBlockSlotProperty>.Append(OS, head + "BlockSlotList", BlockSlotList);
		ViGameSerializer<SpaceHideSlotProperty>.Append(OS, head + "HideSlotList", HideSlotList);
		ViGameSerializer<UInt32>.Append(OS, head + "CompletedStoryList", CompletedStoryList);
		ViGameSerializer<Int64Property>.Append(OS, head + "FactionScoreList", FactionScoreList);
		ViGameSerializer<ProgressProperty>.Append(OS, head + "ScriptProgressList", ScriptProgressList);
		ViGameSerializer<ViString>.Append(OS, head + "ScriptList", ScriptList);
		ViGameSerializer<Int64Property>.Append(OS, head + "ScriptValueList", ScriptValueList);
		ViGameSerializer<MatchSpaceMemberScoreProperty>.Append(OS, head + "MatchScoreList", MatchScoreList);
		ViGameSerializer<Int32>.Append(OS, head + "NPCCount", NPCCount);
		ViGameSerializer<Int32>.Append(OS, head + "NPCAccumulateCount", NPCAccumulateCount);
		ViGameSerializer<Int32>.Append(OS, head + "SpaceObjectCount", SpaceObjectCount);
		ViGameSerializer<Int32>.Append(OS, head + "SpaceObjectAccumulateCount", SpaceObjectAccumulateCount);
	}
}

public class GameSpaceRecordReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 42;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 ID = new ViReceiveDataUInt64();//
	public ViReceiveDataForeignKey<SpaceStruct> Info = new ViReceiveDataForeignKey<SpaceStruct>();//ALL_CLIENT
	public ViReceiveDataUInt8 Public = new ViReceiveDataUInt8();//ALL_CLIENT
	public ReceiveDataPlayerIdentificationProperty Owner = new ReceiveDataPlayerIdentificationProperty();//ALL_CLIENT
	public ViReceiveDataInt16 OwnerLevel = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();//ALL_CLIENT
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();//ALL_CLIENT
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataInt16 ModLevel = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataUInt8 MatchType = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataUInt8 PKType = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt8 FactionCount = new ViReceiveDataInt8();//ALL_CLIENT
	public ViReceiveDataUInt8 Exitable = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataUInt8 EraseExitMember = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt16 MemberCountSup = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataUInt8 BroadcastPropertyToCenter = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataDouble HeroHPMaxScale = new ViReceiveDataDouble();//ALL_CLIENT
	public ViReceiveDataDouble NPCHPPercScale = new ViReceiveDataDouble();//ALL_CLIENT
	public ViReceiveDataDouble Progress = new ViReceiveDataDouble();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataSpacePlayerMemberProperty, SpacePlayerMemberProperty> PlayerList = new ViReceiveDataDictionary<UInt64, ReceiveDataSpacePlayerMemberProperty, SpacePlayerMemberProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataSpaceHeroMemberProperty, SpaceHeroMemberProperty> HeroList = new ViReceiveDataDictionary<UInt64, ReceiveDataSpaceHeroMemberProperty, SpaceHeroMemberProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataSpaceDamageOutProperty, SpaceDamageOutProperty> PlayerDamageOutList = new ViReceiveDataDictionary<UInt64, ReceiveDataSpaceDamageOutProperty, SpaceDamageOutProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceBirthControllerProperty, SpaceBirthControllerProperty> BirthControllerList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceBirthControllerProperty, SpaceBirthControllerProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceBirthControllerShowProperty, SpaceBirthControllerShowProperty> BirthControllerShowList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceBirthControllerShowProperty, SpaceBirthControllerShowProperty>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceEventProperty, SpaceEventProperty> EventList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceEventProperty, SpaceEventProperty>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataSpaceEventCacheProperty, SpaceEventCacheProperty> EventCacheList = new ViReceiveDataArray<ReceiveDataSpaceEventCacheProperty, SpaceEventCacheProperty>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataSpaceBlockSlotProperty, SpaceBlockSlotProperty> BlockSlotList = new ViReceiveDataArray<ReceiveDataSpaceBlockSlotProperty, SpaceBlockSlotProperty>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataSpaceHideSlotProperty, SpaceHideSlotProperty> HideSlotList = new ViReceiveDataArray<ReceiveDataSpaceHideSlotProperty, SpaceHideSlotProperty>();//ALL_CLIENT
	public ViReceiveDataSet<UInt32> CompletedStoryList = new ViReceiveDataSet<UInt32>();//ALL_CLIENT
	public ViReceiveDataArray<ReceiveDataInt64Property, Int64Property> FactionScoreList = new ViReceiveDataArray<ReceiveDataInt64Property, Int64Property>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty> ScriptProgressList = new ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty>();//ALL_CLIENT
	public ViReceiveDataSet<ViString> ScriptList = new ViReceiveDataSet<ViString>();//ALL_CLIENT
	public ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property> ScriptValueList = new ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property>();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt64, ReceiveDataMatchSpaceMemberScoreProperty, MatchSpaceMemberScoreProperty> MatchScoreList = new ViReceiveDataDictionary<UInt64, ReceiveDataMatchSpaceMemberScoreProperty, MatchSpaceMemberScoreProperty>();//ALL_CLIENT
	private ViReceiveDataInt32 NPCCount = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 NPCAccumulateCount = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SpaceObjectCount = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SpaceObjectAccumulateCount = new ViReceiveDataInt32();//
	//
	public GameSpaceRecordReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		ID.RegisterAsChild((UInt16)(0), this, ChildList);
		Info.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Public.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Owner.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		OwnerLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		StartTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EndTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		State.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Level.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ModLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MatchType.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PKType.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		FactionCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Exitable.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EraseExitMember.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MemberCountSup.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BroadcastPropertyToCenter.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		HeroHPMaxScale.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		NPCHPPercScale.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Progress.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PlayerList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		HeroList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		PlayerDamageOutList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BirthControllerList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BirthControllerShowList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EventList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		EventCacheList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		BlockSlotList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		HideSlotList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		CompletedStoryList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		FactionScoreList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ScriptProgressList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ScriptList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ScriptValueList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MatchScoreList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		NPCCount.RegisterAsChild((UInt16)(0), this, ChildList);
		NPCAccumulateCount.RegisterAsChild((UInt16)(0), this, ChildList);
		SpaceObjectCount.RegisterAsChild((UInt16)(0), this, ChildList);
		SpaceObjectAccumulateCount.RegisterAsChild((UInt16)(0), this, ChildList);
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
		ID.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		Public.Start(channelMask, IS, entity);
		Owner.Start(channelMask, IS, entity);
		OwnerLevel.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		ModLevel.Start(channelMask, IS, entity);
		MatchType.Start(channelMask, IS, entity);
		PKType.Start(channelMask, IS, entity);
		FactionCount.Start(channelMask, IS, entity);
		Exitable.Start(channelMask, IS, entity);
		EraseExitMember.Start(channelMask, IS, entity);
		MemberCountSup.Start(channelMask, IS, entity);
		BroadcastPropertyToCenter.Start(channelMask, IS, entity);
		HeroHPMaxScale.Start(channelMask, IS, entity);
		NPCHPPercScale.Start(channelMask, IS, entity);
		Progress.Start(channelMask, IS, entity);
		PlayerList.Start(channelMask, IS, entity);
		HeroList.Start(channelMask, IS, entity);
		PlayerDamageOutList.Start(channelMask, IS, entity);
		BirthControllerList.Start(channelMask, IS, entity);
		BirthControllerShowList.Start(channelMask, IS, entity);
		EventList.Start(channelMask, IS, entity);
		EventCacheList.Start(channelMask, IS, entity);
		BlockSlotList.Start(channelMask, IS, entity);
		HideSlotList.Start(channelMask, IS, entity);
		CompletedStoryList.Start(channelMask, IS, entity);
		FactionScoreList.Start(channelMask, IS, entity);
		ScriptProgressList.Start(channelMask, IS, entity);
		ScriptList.Start(channelMask, IS, entity);
		ScriptValueList.Start(channelMask, IS, entity);
		MatchScoreList.Start(channelMask, IS, entity);
		NPCCount.Start(channelMask, IS, entity);
		NPCAccumulateCount.Start(channelMask, IS, entity);
		SpaceObjectCount.Start(channelMask, IS, entity);
		SpaceObjectAccumulateCount.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		ID.End(entity);
		Info.End(entity);
		Public.End(entity);
		Owner.End(entity);
		OwnerLevel.End(entity);
		StartTime.End(entity);
		EndTime.End(entity);
		State.End(entity);
		Level.End(entity);
		ModLevel.End(entity);
		MatchType.End(entity);
		PKType.End(entity);
		FactionCount.End(entity);
		Exitable.End(entity);
		EraseExitMember.End(entity);
		MemberCountSup.End(entity);
		BroadcastPropertyToCenter.End(entity);
		HeroHPMaxScale.End(entity);
		NPCHPPercScale.End(entity);
		Progress.End(entity);
		PlayerList.End(entity);
		HeroList.End(entity);
		PlayerDamageOutList.End(entity);
		BirthControllerList.End(entity);
		BirthControllerShowList.End(entity);
		EventList.End(entity);
		EventCacheList.End(entity);
		BlockSlotList.End(entity);
		HideSlotList.End(entity);
		CompletedStoryList.End(entity);
		FactionScoreList.End(entity);
		ScriptProgressList.End(entity);
		ScriptList.End(entity);
		ScriptValueList.End(entity);
		MatchScoreList.End(entity);
		NPCCount.End(entity);
		NPCAccumulateCount.End(entity);
		SpaceObjectCount.End(entity);
		SpaceObjectAccumulateCount.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		ID.Clear();
		Info.Clear();
		Public.Clear();
		Owner.Clear();
		OwnerLevel.Clear();
		StartTime.Clear();
		EndTime.Clear();
		State.Clear();
		Level.Clear();
		ModLevel.Clear();
		MatchType.Clear();
		PKType.Clear();
		FactionCount.Clear();
		Exitable.Clear();
		EraseExitMember.Clear();
		MemberCountSup.Clear();
		BroadcastPropertyToCenter.Clear();
		HeroHPMaxScale.Clear();
		NPCHPPercScale.Clear();
		Progress.Clear();
		PlayerList.Clear();
		HeroList.Clear();
		PlayerDamageOutList.Clear();
		BirthControllerList.Clear();
		BirthControllerShowList.Clear();
		EventList.Clear();
		EventCacheList.Clear();
		BlockSlotList.Clear();
		HideSlotList.Clear();
		CompletedStoryList.Clear();
		FactionScoreList.Clear();
		ScriptProgressList.Clear();
		ScriptList.Clear();
		ScriptValueList.Clear();
		MatchScoreList.Clear();
		NPCCount.Clear();
		NPCAccumulateCount.Clear();
		SpaceObjectCount.Clear();
		SpaceObjectAccumulateCount.Clear();
	}
}
