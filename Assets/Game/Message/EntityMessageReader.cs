using System;
using System.Collections;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;


public enum EntityMessageParamType
{
	TP_ERROR,
	TP_FLOAT,
	TP_INT8,
	TP_INT16,
	TP_INT32,
	TP_INT64,
	TP_UINT8,
	TP_UINT16,
	TP_UINT32,
	TP_UINT64,
	TP_BOOL,
	TP_VECTOR2,
	TP_VECTOR3,
	TP_VECTOR4,
	TP_STR,
	TP_LIST_FLOAT,
	TP_LIST_INT8,
	TP_LIST_INT16,
	TP_LIST_INT32,
	TP_LIST_INT64,
	TP_LIST_UINT8,
	TP_LIST_UINT16,
	TP_LIST_UINT32,
	TP_LIST_UINT64,
	TP_LIST_BOOL,
	TP_LIST_VECTOR2,
	TP_LIST_VECTOR3,
	TP_LIST_VECTOR4,
	TP_LIST_STR,

	TP_GAME_UNIT = 100,
	TP_GAME_UNIT_LIST,
	TP_CELL_HERO,
	TP_CELL_HERO_LIST,
	TP_CELL_PLAYER,
	TP_CELL_PLAYER_LIST,
	TP_CELL_NPC,
	TP_CELL_NPC_LIST,
	TP_SPACE_OBJECT,
	TP_SPACE_OBJECT_LIST,
	TP_AREA_AURA,
	TP_AREA_AURA_LIST,
	TP_PLAYER,
	TP_PLAYER_LIST,

	TP_COOLINGDOWN_INFO = 200,
	TP_COOLINGDOWN_INFO_LIST,
	TP_ITEM_INFO,
	TP_ITEM_INFO_LIST,
	TP_QUEST_INFO,
	TP_QUEST_INFO_LIST,
	TP_GOAL_INFO,
	TP_GOAL_INFO_LIST,
	TP_FUNC_INFO,
	TP_FUNC_INFO_LIST,
	TP_SPELL_INFO,
	TP_SPELL_INFO_LIST,
	TP_AURA_INFO,
	TP_AURA_INFO_LIST,
	TP_OWN_SPELL_INFO,
	TP_OWN_SPELL_INFO_LIST,
	TP_NPC_INFO,
	TP_NPC_INFO_LIST,
	TP_HERO_INFO,
	TP_HERO_INFO_LIST,
	TP_SPACE_OBJECT_INFO,
	TP_SPACE_OBJECT_INFO_LIST,
	TP_SPACE_INFO,
	TP_SPACE_INFO_LIST,
	TP_SPACE_BIRTH_CONTROLLER_INFO,
	TP_SPACE_BIRTH_CONTROLLER_INFO_LIST,
	TP_SPACE_EVENT_INFO,
	TP_SPACE_EVENT_INFO_LIST,
	TP_SPACE_HERO_LEVEL_EFFECT_INFO,
	TP_SPACE_HERO_LEVEL_EFFECT_INFO_LIST,
	TP_ACTIVITY_INFO,
	TP_ACTIVITY_INFO_LIST,
	TP_SCORE_INFO,
	TP_SCORE_INFO_LIST,

	TP_TIME = 300,
	TP_TIME_LIST,

	TP_PLAYER_IDENTIFICATION = 400,
	TP_PLAYER_IDENTIFICATION_LIST,
	TP_ITEM_COUNT,
	TP_ITEM_COUNT_LIST,

	TOTAL,
}

public static class EntityMessageReader
{
	public delegate bool DeleRead(ViIStream IS, ViStringBuilder str, ref object obj);

	static EntityMessageReader()
	{
		Register((UInt16)EntityMessageParamType.TP_FLOAT, ReadFloat);
		Register((UInt16)EntityMessageParamType.TP_LIST_FLOAT, ReadFloatList);

		Register((UInt16)EntityMessageParamType.TP_INT8, ReadInt8);
		Register((UInt16)EntityMessageParamType.TP_LIST_INT8, ReadInt8List);
		Register((UInt16)EntityMessageParamType.TP_UINT8, ReadUInt8);
		Register((UInt16)EntityMessageParamType.TP_LIST_UINT8, ReadUInt8List);

		Register((UInt16)EntityMessageParamType.TP_INT16, ReadInt16);
		Register((UInt16)EntityMessageParamType.TP_LIST_INT16, ReadInt16List);
		Register((UInt16)EntityMessageParamType.TP_UINT16, ReadUInt16);
		Register((UInt16)EntityMessageParamType.TP_LIST_UINT16, ReadUInt16List);

		Register((UInt16)EntityMessageParamType.TP_INT32, ReadInt32);
		Register((UInt16)EntityMessageParamType.TP_LIST_INT32, ReadInt32List);
		Register((UInt16)EntityMessageParamType.TP_UINT32, ReadUInt32);
		Register((UInt16)EntityMessageParamType.TP_LIST_UINT32, ReadUInt32List);

		Register((UInt16)EntityMessageParamType.TP_INT64, ReadInt64);
		Register((UInt16)EntityMessageParamType.TP_LIST_INT64, ReadInt64List);
		Register((UInt16)EntityMessageParamType.TP_UINT64, ReadUInt64);
		Register((UInt16)EntityMessageParamType.TP_LIST_UINT64, ReadUInt64List);

		Register((UInt16)EntityMessageParamType.TP_STR, ReadString);
		Register((UInt16)EntityMessageParamType.TP_LIST_STR, ReadStringList);

		Register((UInt16)EntityMessageParamType.TP_VECTOR3, ReadVector3);
		Register((UInt16)EntityMessageParamType.TP_LIST_VECTOR3, ReadVector3List);

		Register((UInt16)EntityMessageParamType.TP_GAME_UNIT, ReadGameUnit);
		Register((UInt16)EntityMessageParamType.TP_GAME_UNIT_LIST, ReadGameUnitList);

		Register((UInt16)EntityMessageParamType.TP_CELL_HERO, ReadCellHero);
		Register((UInt16)EntityMessageParamType.TP_CELL_HERO_LIST, ReadCellHeroList);

		Register((UInt16)EntityMessageParamType.TP_CELL_PLAYER, ReadCellPlayer);
		Register((UInt16)EntityMessageParamType.TP_CELL_PLAYER_LIST, ReadCellPlayerList);

		Register((UInt16)EntityMessageParamType.TP_CELL_NPC, ReadCellNPC);
		Register((UInt16)EntityMessageParamType.TP_CELL_NPC_LIST, ReadCellNPCList);

		Register((UInt16)EntityMessageParamType.TP_SPACE_OBJECT, ReadSpaceObject);
		Register((UInt16)EntityMessageParamType.TP_SPACE_OBJECT_LIST, ReadSpaceObjectList);

		Register((UInt16)EntityMessageParamType.TP_AREA_AURA, ReadAreaAura);
		Register((UInt16)EntityMessageParamType.TP_AREA_AURA_LIST, ReadAreaAuraList);

		Register((UInt16)EntityMessageParamType.TP_PLAYER, ReadPlayer);
		Register((UInt16)EntityMessageParamType.TP_PLAYER_LIST, ReadPlayerList);

		Register((UInt16)EntityMessageParamType.TP_COOLINGDOWN_INFO, ReadChannelCoolingInfoDown);
		Register((UInt16)EntityMessageParamType.TP_COOLINGDOWN_INFO_LIST, ReadChannelCoolingDownInfoList);

		Register((UInt16)EntityMessageParamType.TP_ITEM_INFO, ReadInfoItem);
		Register((UInt16)EntityMessageParamType.TP_ITEM_INFO_LIST, ReadItemInfoList);

		Register((UInt16)EntityMessageParamType.TP_GOAL_INFO, ReadGoalInfo);
		Register((UInt16)EntityMessageParamType.TP_GOAL_INFO_LIST, ReadGoalInfoList);

		Register((UInt16)EntityMessageParamType.TP_FUNC_INFO, ReadFuncOpenInfo);
		Register((UInt16)EntityMessageParamType.TP_FUNC_INFO_LIST, ReadFuncOpenInfoList);

		Register((UInt16)EntityMessageParamType.TP_SPELL_INFO, ReadSpellInfo);
		Register((UInt16)EntityMessageParamType.TP_SPELL_INFO_LIST, ReadSpellInfoList);

		Register((UInt16)EntityMessageParamType.TP_AURA_INFO, ReadAuraInfo);
		Register((UInt16)EntityMessageParamType.TP_AURA_INFO_LIST, ReadAuraInfoList);

		Register((UInt16)EntityMessageParamType.TP_NPC_INFO, ReadNPCInfo);
		Register((UInt16)EntityMessageParamType.TP_NPC_INFO_LIST, ReadNPCInfoList);

		Register((UInt16)EntityMessageParamType.TP_HERO_INFO, ReadHeroInfo);
		Register((UInt16)EntityMessageParamType.TP_HERO_INFO_LIST, ReadHeroInfoList);

		Register((UInt16)EntityMessageParamType.TP_OWN_SPELL_INFO, ReadOwnSpellInfo);
		Register((UInt16)EntityMessageParamType.TP_OWN_SPELL_INFO_LIST, ReadOwnSpellInfoList);

		Register((UInt16)EntityMessageParamType.TP_SPACE_OBJECT_INFO, ReadSpaceObjectInfo);
		Register((UInt16)EntityMessageParamType.TP_SPACE_OBJECT_INFO_LIST, ReadSpaceObjectInfoList);

		Register((UInt16)EntityMessageParamType.TP_SPACE_INFO, ReadSpaceInfo);
		Register((UInt16)EntityMessageParamType.TP_SPACE_INFO_LIST, ReadSpaceInfoList);

		Register((UInt16)EntityMessageParamType.TP_SPACE_BIRTH_CONTROLLER_INFO, ReadSpaceBirthControllerInfo);
		Register((UInt16)EntityMessageParamType.TP_SPACE_BIRTH_CONTROLLER_INFO_LIST, ReadSpaceBirthControllerInfoList);

		Register((UInt16)EntityMessageParamType.TP_SPACE_EVENT_INFO, ReadSpaceEventInfo);
		Register((UInt16)EntityMessageParamType.TP_SPACE_EVENT_INFO_LIST, ReadSpaceEventInfoList);

		Register((UInt16)EntityMessageParamType.TP_SPACE_HERO_LEVEL_EFFECT_INFO, ReadSpaceHeroLevelEffectInfo);
		Register((UInt16)EntityMessageParamType.TP_SPACE_HERO_LEVEL_EFFECT_INFO_LIST, ReadSpaceHeroLevelEffectInfoList);

		Register((UInt16)EntityMessageParamType.TP_ACTIVITY_INFO, ReadActivityInfo);
		Register((UInt16)EntityMessageParamType.TP_ACTIVITY_INFO_LIST, ReadActivityInfoList);

		Register((UInt16)EntityMessageParamType.TP_SCORE_INFO, ReadScoreInfo);
		Register((UInt16)EntityMessageParamType.TP_SCORE_INFO_LIST, ReadScoreInfoList);

		Register((UInt16)EntityMessageParamType.TP_TIME, ReadTime);
		Register((UInt16)EntityMessageParamType.TP_TIME_LIST, ReadTimeList);

		Register((UInt16)EntityMessageParamType.TP_PLAYER_IDENTIFICATION, ReadPlayerIdentification);
		Register((UInt16)EntityMessageParamType.TP_PLAYER_IDENTIFICATION_LIST, ReadPlayerIdentificationList);

		Register((UInt16)EntityMessageParamType.TP_ITEM_COUNT, ReadItemCount);
		Register((UInt16)EntityMessageParamType.TP_ITEM_COUNT_LIST, ReadItemListCount);

	}

	public static Int32 Read(UInt64 types, ViIStream IS, List<ViStringBuilder> strList, List<object> objList)
	{
		for (int iter = 0; iter < strList.Count; ++iter)
		{
			strList[iter].Clear();
		}
		for (int iter = 0; iter < objList.Count; ++iter)
		{
			objList[iter] = null;
		}
		Int32 count = 0;
		UInt16 type0 = (UInt16)(types);
		if (type0 != 0)
		{
			object obj = null;
			Read(type0, IS, strList[count], ref obj);
			objList[count] = obj;
			++count;
		}
		UInt16 type1 = (UInt16)(types >> 16);
		if (type1 != 0)
		{
			object obj = null;
			Read(type1, IS, strList[count], ref obj);
			objList[count] = obj;
			++count;
		}
		UInt16 type2 = (UInt16)(types >> 32);
		if (type2 != 0)
		{
			object obj = null;
			Read(type2, IS, strList[count], ref obj);
			objList[count] = obj;
			++count;
		}
		UInt16 type3 = (UInt16)(types >> 48);
		if (type3 != 0)
		{
			object obj = null;
			Read(type3, IS, strList[count], ref obj);
			objList[count] = obj;
			++count;
		}
		return count;
	}

	public static void Register(UInt16 typeID, DeleRead dele)
	{
		ViDebuger.AssertError(!TypeReadList.ContainsKey(typeID), "重复定义");
		ViDebuger.AssertError(!TypeReadList.ContainsValue(dele), "重复定义");
		TypeReadList[typeID] = dele;
	}

	public static bool Read(UInt16 typeID, ViIStream IS, ViStringBuilder str, ref object obj)
	{
		DeleRead dele;
		if (TypeReadList.TryGetValue(typeID, out dele))
		{
			return dele(IS, str, ref obj);
		}
		else
		{
			EntityMessageParamType enumValue = (EntityMessageParamType)typeID;
			ViDebuger.Warning("EntityMessagerReader.Read(" + enumValue + ") Fail!");
			return false;
		}
	}

	public static bool ReadFloat(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		float value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadFloatList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<float> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt8(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		Int8 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt8List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<Int8> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt8(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		UInt8 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt8List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<UInt8> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt16(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		Int16 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt16List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<Int16> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt16(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		UInt16 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt16List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<UInt16> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt32(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		Int32 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt32List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<Int32> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt32(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		UInt32 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt32List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<UInt32> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt64(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		Int64 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadInt64List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<Int64> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt64(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		UInt64 value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadUInt64List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<UInt64> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadString(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		string value;
		IS.Read(out value);
		obj = value;
		str.Set(value);
		return true;
	}
	public static bool ReadStringList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<string> value;
		IS.Read(out value);
		obj = (object)value;
		ViStringSerialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadVector3(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ViVector3 value;
		ViSerializer<ViVector3>.Read(IS, out value);
		obj = (object)value;
		ViVector3Serialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadVector3List(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ViVector3> value;
		ViSerializer<ViVector3>.Read(IS, out value);
		obj = (object)value;
		ViVector3Serialize.PrintTo(value, str);
		return true;
	}
	public static bool ReadGameUnit(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		GameUnit value;
		GameUnitSerializer.Read(IS, out value);
		obj = (object)value;
		GameUnitSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadGameUnitList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<GameUnit> value;
		GameUnitSerializer.Read(IS, out value);
		obj = (object)value;
		GameUnitSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadCellHero(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		CellHero value;
		CellHeroSerializer.Read(IS, out value);
		obj = (object)value;
		CellHeroSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadCellHeroList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<CellHero> value;
		CellHeroSerializer.Read(IS, out value);
		obj = (object)value;
		CellHeroSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadCellPlayer(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		CellPlayer value;
		CellPlayerSerializer.Read(IS, out value);
		obj = (object)value;
		CellPlayerSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadCellPlayerList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<CellPlayer> value;
		CellPlayerSerializer.Read(IS, out value);
		obj = (object)value;
		CellPlayerSerializer.PrintTo(value, str);
		return true;
	}


	public static bool ReadCellNPC(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		CellNPC value;
		CellNPCSerializer.Read(IS, out value);
		obj = (object)value;
		CellNPCSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadCellNPCList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<CellNPC> value;
		CellNPCSerializer.Read(IS, out value);
		obj = (object)value;
		CellNPCSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceObject(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		SpaceObject value;
		SpaceObjectSerializer.Read(IS, out value);
		obj = (object)value;
		SpaceObjectSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceObjectList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<SpaceObject> value;
		SpaceObjectSerializer.Read(IS, out value);
		obj = (object)value;
		SpaceObjectSerializer.PrintTo(value, str);
		return true;
	}

	public static bool ReadAreaAura(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		AreaAura value;
		AreaAuraSerializer.Read(IS, out value);
		obj = (object)value;
		AreaAuraSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadAreaAuraList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<AreaAura> value;
		AreaAuraSerializer.Read(IS, out value);
		obj = (object)value;
		AreaAuraSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadPlayer(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		Player value;
		PlayerSerializer.Read(IS, out value);
		obj = (object)value;
		PlayerSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadPlayerList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<Player> value;
		PlayerSerializer.Read(IS, out value);
		obj = (object)value;
		PlayerSerializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadChannelCoolingInfoDown(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		CoolingDownStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadChannelCoolingDownInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<CoolingDownStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadInfoItem(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ItemStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadItemInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ItemStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadGoalInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		GoalStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadGoalInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<GoalStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadFuncOpenInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		GameFuncStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadFuncOpenInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<GameFuncStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpellInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ViSpellStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpellInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ViSpellStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadAuraInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ViAuraStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadAuraInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ViAuraStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadHeroInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		HeroStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadHeroInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<HeroStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadOwnSpellInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		OwnSpellStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadOwnSpellInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<OwnSpellStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadNPCInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		NPCStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadNPCInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<NPCStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceObjectInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		SpaceObjectStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceObjectInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<SpaceObjectStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		SpaceStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<SpaceStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceBirthControllerInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		SpaceBirthControllerStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceBirthControllerInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<SpaceBirthControllerStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceEventInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		SpaceEventStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceEventInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<SpaceEventStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceHeroLevelEffectInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		SpaceHeroLevelEffectStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadSpaceHeroLevelEffectInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<SpaceHeroLevelEffectStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadActivityInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ActivityStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadActivityInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ActivityStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadScoreInfo(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ScoreStruct value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadScoreInfoList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ScoreStruct> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadTime(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		FormatTime value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadTimeList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<FormatTime> value;
		Serializer.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadPlayerIdentification(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		PlayerIdentificationProperty value;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadPlayerIdentificationList(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<PlayerIdentificationProperty> value;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	public static bool ReadItemCount(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		ItemCountProperty value;
		ViGameSerializer<ItemCountProperty>.Read(IS, out value);
		obj = (object)value;
		Serializer.PrintTo(value, str);
		return true;
	}
	static ItemCountPropertySet _itemList = new ItemCountPropertySet();
	public static bool ReadItemListCount(ViIStream IS, ViStringBuilder str, ref object obj)
	{
		List<ItemCountProperty> value;
		ViGameSerializer<ItemCountProperty>.Read(IS, out value);
		_itemList.Clear();
		foreach (ItemCountProperty item in value)
		{
			_itemList.Add(item);
		}
		obj = (object)value;
		Serializer.PrintTo(_itemList.List, str);
		return true;
	}

	static Dictionary<UInt16, DeleRead> TypeReadList = new Dictionary<UInt16, DeleRead>();
}