using System;
using System.Collections.Generic;


using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;

public static class EntityMessageWriter
{
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, float value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_FLOAT;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<float> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_FLOAT;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, Int8 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_INT8;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<Int8> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_INT8;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, UInt8 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_UINT8;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<UInt8> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_UINT8;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, Int16 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_INT16;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<Int16> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_INT16;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, UInt16 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_UINT16;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<UInt16> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_UINT16;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, Int32 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_INT32;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<Int32> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_INT32;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, UInt32 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_UINT32;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<UInt32> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_UINT32;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, Int64 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_INT64;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<Int64> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_INT64;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, UInt64 value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_UINT64;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<UInt64> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_UINT64;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, ViVector3 value)
	{
		ViSerializer<ViVector3>.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_VECTOR3;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<ViVector3> value)
	{
		ViSerializer<ViVector3>.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_VECTOR3;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, string value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_STR;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<string> value)
	{
		OS.Append(value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_LIST_STR;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, GameUnit value)
	{
		GameUnitSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_GAME_UNIT;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<GameUnit> value)
	{
		GameUnitSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_GAME_UNIT_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, CellHero value)
	{
		CellHeroSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_CELL_HERO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<CellHero> value)
	{
		CellHeroSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_CELL_HERO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, CellPlayer value)
	{
		CellPlayerSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_CELL_PLAYER;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<CellPlayer> value)
	{
		CellPlayerSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_CELL_PLAYER_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, CellNPC value)
	{
		CellNPCSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_CELL_NPC;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<CellNPC> value)
	{
		CellNPCSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_CELL_NPC_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, SpaceObject value)
	{
		SpaceObjectSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_OBJECT;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<SpaceObject> value)
	{
		SpaceObjectSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_OBJECT_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, AreaAura value)
	{
		AreaAuraSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_AREA_AURA;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<AreaAura> value)
	{
		AreaAuraSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_AREA_AURA_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, Player value)
	{
		PlayerSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_PLAYER;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<Player> value)
	{
		PlayerSerializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_PLAYER_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, CoolingDownStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_COOLINGDOWN_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<CoolingDownStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_COOLINGDOWN_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, ItemStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_ITEM_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<ItemStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_ITEM_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, GoalStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_GOAL_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<GoalStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_GOAL_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, GameFuncStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_FUNC_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<GameFuncStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_FUNC_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, ViSpellStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPELL_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<ViSpellStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPELL_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, ViAuraStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_AURA_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<ViAuraStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_AURA_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, NPCStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_NPC_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<NPCStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_NPC_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, HeroStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_HERO_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<HeroStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_HERO_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, SpaceObjectStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_OBJECT_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<SpaceObjectStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_OBJECT_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, SpaceStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<SpaceStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, SpaceBirthControllerStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_BIRTH_CONTROLLER_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<SpaceBirthControllerStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_SPACE_BIRTH_CONTROLLER_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, ActivityStruct value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_ACTIVITY_INFO;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<ActivityStruct> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_ACTIVITY_INFO_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, FormatTime value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_TIME;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<FormatTime> value)
	{
		Serializer.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_TIME_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, PlayerIdentificationProperty value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_PLAYER_IDENTIFICATION;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<PlayerIdentificationProperty> value)
	{
		ViGameSerializer<PlayerIdentificationProperty>.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_PLAYER_IDENTIFICATION_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, ItemCountProperty value)
	{
		ViGameSerializer<ItemCountProperty>.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_ITEM_COUNT;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
	public static void Append(ref UInt64 typeID, ViOStream OS, int idx, List<ItemCountProperty> value)
	{
		ViGameSerializer<ItemCountProperty>.Append(OS, value);
		UInt64 mask = (UInt64)EntityMessageParamType.TP_ITEM_COUNT_LIST;
		mask = mask << (int)idx * 16;
		typeID += mask;
	}
}