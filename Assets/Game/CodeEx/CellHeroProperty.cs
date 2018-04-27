using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellHeroProperty : GameUnitProperty
{
	public static readonly new int TYPE_SIZE = GameUnitProperty.TYPE_SIZE + 18;
	public static readonly new int INDEX_PROPERTY_COUNT = GameUnitProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public Int16 PersistentLevel;//ALL_CLIENT
	public ViString NameAlias;//ALL_CLIENT
	public UInt64 GuildID;//OWN_CLIENT
	public ViString GuildName;//ALL_CLIENT
	public ViForeignKey<HeroStruct> Info;//ALL_CLIENT
	public Int64 XP;//OWN_CLIENT
	public List<SpaceHeroLevelRandomEffectProperty> LevelEffectRandomList;//OWN_CLIENT
	public List<UInt32Property> LevelEffectOwnList;//OWN_CLIENT
	public List<HeroSpellProperty> SpellList;//OWN_CLIENT
	public List<HeroSpellProperty> StudySpellList;//OWN_CLIENT
	public Dictionary<UInt32, ProgressProperty> ScriptProgressList;//OWN_CLIENT
	public UInt8 DuringAutoAttack;//ALL_CLIENT
	public UInt8 DuringNormalAttack;//ALL_CLIENT
	public Int64 DashCD;//OWN_CLIENT
	public PlayerIdentificationProperty OwnerPlayerIdentity;//ALL_CLIENT
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<Int16>.Read(IS, out PersistentLevel);
		ViGameSerializer<ViString>.Read(IS, out NameAlias);
		ViGameSerializer<UInt64>.Read(IS, out GuildID);
		ViGameSerializer<ViString>.Read(IS, out GuildName);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Read(IS, out Info);
		ViGameSerializer<Int64>.Read(IS, out XP);
		ViGameSerializer<SpaceHeroLevelRandomEffectProperty>.Read(IS, out LevelEffectRandomList);
		ViGameSerializer<UInt32Property>.Read(IS, out LevelEffectOwnList);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out SpellList);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out StudySpellList);
		ViGameSerializer<ProgressProperty>.Read(IS, out ScriptProgressList);
		ViGameSerializer<UInt8>.Read(IS, out DuringAutoAttack);
		ViGameSerializer<UInt8>.Read(IS, out DuringNormalAttack);
		ViGameSerializer<Int64>.Read(IS, out DashCD);
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out OwnerPlayerIdentity);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<Int16>.Append(OS, head + "PersistentLevel", PersistentLevel);
		ViGameSerializer<ViString>.Append(OS, head + "NameAlias", NameAlias);
		ViGameSerializer<UInt64>.Append(OS, head + "GuildID", GuildID);
		ViGameSerializer<ViString>.Append(OS, head + "GuildName", GuildName);
		ViGameSerializer<ViForeignKey<HeroStruct>>.Append(OS, head + "Info", Info);
		ViGameSerializer<Int64>.Append(OS, head + "XP", XP);
		ViGameSerializer<SpaceHeroLevelRandomEffectProperty>.Append(OS, head + "LevelEffectRandomList", LevelEffectRandomList);
		ViGameSerializer<UInt32Property>.Append(OS, head + "LevelEffectOwnList", LevelEffectOwnList);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + "SpellList", SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + "StudySpellList", StudySpellList);
		ViGameSerializer<ProgressProperty>.Append(OS, head + "ScriptProgressList", ScriptProgressList);
		ViGameSerializer<UInt8>.Append(OS, head + "DuringAutoAttack", DuringAutoAttack);
		ViGameSerializer<UInt8>.Append(OS, head + "DuringNormalAttack", DuringNormalAttack);
		ViGameSerializer<Int64>.Append(OS, head + "DashCD", DashCD);
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, head + "OwnerPlayerIdentity", OwnerPlayerIdentity);
	}
}

public class CellHeroReceiveProperty : GameUnitReceiveProperty
{
	public static readonly new int TYPE_SIZE = GameUnitReceiveProperty.TYPE_SIZE + 18;
	public static readonly new int INDEX_PROPERTY_COUNT = GameUnitReceiveProperty.INDEX_PROPERTY_COUNT + 0;
	//
	public ViReceiveDataInt16 PersistentLevel = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataString NameAlias = new ViReceiveDataString();//ALL_CLIENT
	public ViReceiveDataUInt64 GuildID = new ViReceiveDataUInt64();//OWN_CLIENT
	public ViReceiveDataString GuildName = new ViReceiveDataString();//ALL_CLIENT
	public ViReceiveDataForeignKey<HeroStruct> Info = new ViReceiveDataForeignKey<HeroStruct>();//ALL_CLIENT
	public ViReceiveDataInt64 XP = new ViReceiveDataInt64();//OWN_CLIENT
	public ViReceiveDataArray<ReceiveDataSpaceHeroLevelRandomEffectProperty, SpaceHeroLevelRandomEffectProperty> LevelEffectRandomList = new ViReceiveDataArray<ReceiveDataSpaceHeroLevelRandomEffectProperty, SpaceHeroLevelRandomEffectProperty>();//OWN_CLIENT
	public ViReceiveDataArray<ReceiveDataUInt32Property, UInt32Property> LevelEffectOwnList = new ViReceiveDataArray<ReceiveDataUInt32Property, UInt32Property>();//OWN_CLIENT
	public ViReceiveDataArray<ReceiveDataHeroSpellProperty, HeroSpellProperty> SpellList = new ViReceiveDataArray<ReceiveDataHeroSpellProperty, HeroSpellProperty>();//OWN_CLIENT
	public ViReceiveDataArray<ReceiveDataHeroSpellProperty, HeroSpellProperty> StudySpellList = new ViReceiveDataArray<ReceiveDataHeroSpellProperty, HeroSpellProperty>();//OWN_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty> ScriptProgressList = new ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty>();//OWN_CLIENT
	public ViReceiveDataUInt8 DuringAutoAttack = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataUInt8 DuringNormalAttack = new ViReceiveDataUInt8();//ALL_CLIENT
	public ViReceiveDataInt64 DashCD = new ViReceiveDataInt64();//OWN_CLIENT
	public ReceiveDataPlayerIdentificationProperty OwnerPlayerIdentity = new ReceiveDataPlayerIdentificationProperty();//ALL_CLIENT
	//
	public CellHeroReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		PersistentLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		NameAlias.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		GuildID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		GuildName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Info.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		XP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		LevelEffectRandomList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		LevelEffectOwnList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		SpellList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		StudySpellList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		ScriptProgressList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		DuringAutoAttack.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		DuringNormalAttack.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		DashCD.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		OwnerPlayerIdentity.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
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
		PersistentLevel.Start(channelMask, IS, entity);
		NameAlias.Start(channelMask, IS, entity);
		GuildID.Start(channelMask, IS, entity);
		GuildName.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		XP.Start(channelMask, IS, entity);
		LevelEffectRandomList.Start(channelMask, IS, entity);
		LevelEffectOwnList.Start(channelMask, IS, entity);
		SpellList.Start(channelMask, IS, entity);
		StudySpellList.Start(channelMask, IS, entity);
		ScriptProgressList.Start(channelMask, IS, entity);
		DuringAutoAttack.Start(channelMask, IS, entity);
		DuringNormalAttack.Start(channelMask, IS, entity);
		DashCD.Start(channelMask, IS, entity);
		OwnerPlayerIdentity.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		PersistentLevel.End(entity);
		NameAlias.End(entity);
		GuildID.End(entity);
		GuildName.End(entity);
		Info.End(entity);
		XP.End(entity);
		LevelEffectRandomList.End(entity);
		LevelEffectOwnList.End(entity);
		SpellList.End(entity);
		StudySpellList.End(entity);
		ScriptProgressList.End(entity);
		DuringAutoAttack.End(entity);
		DuringNormalAttack.End(entity);
		DashCD.End(entity);
		OwnerPlayerIdentity.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		PersistentLevel.Clear();
		NameAlias.Clear();
		GuildID.Clear();
		GuildName.Clear();
		Info.Clear();
		XP.Clear();
		LevelEffectRandomList.Clear();
		LevelEffectOwnList.Clear();
		SpellList.Clear();
		StudySpellList.Clear();
		ScriptProgressList.Clear();
		DuringAutoAttack.Clear();
		DuringNormalAttack.Clear();
		DashCD.Clear();
		OwnerPlayerIdentity.Clear();
	}
}
