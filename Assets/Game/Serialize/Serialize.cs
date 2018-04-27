using System;
using System.Collections.Generic;

using ViEntityID = System.UInt64;
using ViArrayIdx = System.Int32;

public static class SealedDataSerializer
{
	public static void Append<TSealedData>(ViOStream OS, TSealedData value) where TSealedData : ViSealedData
	{
		if (value != null)
		{
			OS.Append(value.ID);
		}
		else
		{
			ViEntityID id = 0;
			OS.Append(id);
		}
	}
	public static void Append<TSealedData>(ViOStream OS, List<TSealedData> list) where TSealedData : ViSealedData
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		foreach (TSealedData value in list)
		{
			Append(OS, value);
		}
	}
	public static void Read<TSealedData>(ViIStream IS, out TSealedData value) where TSealedData : ViSealedData, new()
	{
		Int32 sealedID;
		IS.Read(out sealedID);
		value = ViSealedDB<TSealedData>.Data(sealedID);
	}
	public static void Read<TSealedData>(ViIStream IS, out List<TSealedData> list) where TSealedData : ViSealedData, new()
	{
		ViArrayIdx size;
		IS.ReadPacked(out size);
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("Read List<TSealedData>.size Error");
			list = new List<TSealedData>();
			return;
		}
		list = new List<TSealedData>();
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TSealedData value;
			Read(IS, out value);
			list.Add(value);
		}
	}
	public static void PrintTo<TSealedData>(TSealedData value, ViStringBuilder strValue) where TSealedData : ViSealedData, new()
	{
		if (value != null)
		{
			strValue.Add(value.Name);
		}
	}
	public static void PrintTo<TSealedData>(List<TSealedData> list, ViStringBuilder strValue) where TSealedData : ViSealedData, new()
	{
		bool first = true;
		foreach (TSealedData value in list)
		{
			if (value == null)
			{
				continue;
			}
			if (first)
			{
				first = false;
			}
			else
			{
				strValue.Add(",");
			}
			PrintTo(value, strValue);
		}
	}
}

//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
//+-----------------------------------------------------------------------------------------------------------------------------------------------------------

public static class Serializer
{
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, ItemStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<ItemStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out ItemStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<ItemStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(ItemStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<ItemStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void PrintTo(ItemCountProperty value, ViStringBuilder strValue)
	{
		strValue.Add(value.Info.Data.Name).Add("*").Add(value.Count.ToString());
	}
	public static void PrintTo(List<ItemCountProperty> list, ViStringBuilder strValue)
	{
		bool first = true;
		foreach (ItemCountProperty value in list)
		{
			if (first)
			{
				first = false;
			}
			else
			{
				strValue.Add(",");
			}
			PrintTo(value, strValue);
		}
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, ViSpellStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<ViSpellStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out ViSpellStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<ViSpellStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(ViSpellStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<ViSpellStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, ViAuraStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<ViAuraStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out ViAuraStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<ViAuraStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(ViAuraStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<ViAuraStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, HeroStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<HeroStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out HeroStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<HeroStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(HeroStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<HeroStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, OwnSpellStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<OwnSpellStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out OwnSpellStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<OwnSpellStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(OwnSpellStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<OwnSpellStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, NPCStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<NPCStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out NPCStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<NPCStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(NPCStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<NPCStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, SpaceObjectStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<SpaceObjectStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out SpaceObjectStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<SpaceObjectStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(SpaceObjectStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<SpaceObjectStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, SpaceStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<SpaceStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out SpaceStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<SpaceStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(SpaceStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<SpaceStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, SpaceBirthControllerStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<SpaceBirthControllerStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out SpaceBirthControllerStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<SpaceBirthControllerStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(SpaceBirthControllerStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<SpaceBirthControllerStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, SpaceEventStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<SpaceEventStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out SpaceEventStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<SpaceEventStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(SpaceEventStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<SpaceEventStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, SpaceHeroLevelEffectStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<SpaceHeroLevelEffectStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out SpaceHeroLevelEffectStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<SpaceHeroLevelEffectStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(SpaceHeroLevelEffectStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<SpaceHeroLevelEffectStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, ActivityStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<ActivityStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out ActivityStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<ActivityStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(ActivityStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<ActivityStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, ScoreStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<ScoreStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out ScoreStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<ScoreStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(ScoreStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<ScoreStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, CoolingDownStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<CoolingDownStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out CoolingDownStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<CoolingDownStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(CoolingDownStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<CoolingDownStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, GoalStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<GoalStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out GoalStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<GoalStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(GoalStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<GoalStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, GameFuncStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<GameFuncStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out GameFuncStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<GameFuncStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(GameFuncStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<GameFuncStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, ScoreRankStruct value)
	{
		SealedDataSerializer.Append(OS, value);
	}
	public static void Append(ViOStream OS, List<ScoreRankStruct> list)
	{
		SealedDataSerializer.Append(OS, list);
	}
	public static void Read(ViIStream IS, out ScoreRankStruct value)
	{
		SealedDataSerializer.Read(IS, out value);
	}
	public static void Read(ViIStream IS, out List<ScoreRankStruct> list)
	{
		SealedDataSerializer.Read(IS, out list);
	}
	public static void PrintTo(ScoreRankStruct value, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(value, strValue);
	}
	public static void PrintTo(List<ScoreRankStruct> list, ViStringBuilder strValue)
	{
		SealedDataSerializer.PrintTo(list, strValue);
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void Append(ViOStream OS, FormatTime value)
	{
		OS.Append(value.Value);
	}
	public static void Append(ViOStream OS, List<FormatTime> list)
	{
		OS.Append((UInt32)list.Count);
		foreach (FormatTime value in list)
		{
			OS.Append(value.Value);
		}
	}
	public static void Read(ViIStream IS, out FormatTime value)
	{
		IS.Read(out value.Value);
	}
	public static void Read(ViIStream IS, out List<FormatTime> list)
	{
		Int32 count;
		IS.ReadPacked(out count);
		list = new List<FormatTime>();
		list.Capacity = count;
		FormatTime newValue = new FormatTime();
		for (int iter = 0; iter < count; ++iter)
		{
			Read(IS, out newValue);
			list.Add(newValue);
		}
	}
	public static void PrintTo(FormatTime value, ViStringBuilder strValue)
	{
		strValue.Add(value.Print());
	}
	public static void PrintTo(List<FormatTime> list, ViStringBuilder strValue)
	{
		bool first = true;
		foreach (FormatTime value in list)
		{
			if (first)
			{
				first = false;
			}
			else
			{
				strValue.Add(",");
			}
			PrintTo(value, strValue);
		}
	}
	//+-----------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void PrintTo(PlayerIdentificationProperty value, ViStringBuilder strValue)
	{
		strValue.Add(value.NameAlias);
	}
	public static void PrintTo(List<PlayerIdentificationProperty> list, ViStringBuilder strValue)
	{
		bool first = true;
		foreach (PlayerIdentificationProperty value in list)
		{
			if (first)
			{
				first = false;
			}
			else
			{
				strValue.Add(",");
			}
			PrintTo(value, strValue);
		}
	}
	public static string Desc(PlayerIdentificationProperty value)
	{
		return value.NameAlias;
	}
	public static string Desc(List<PlayerIdentificationProperty> list)
	{
		bool first = true;
		ViStringBuilder strValue = new ViStringBuilder();
		foreach (PlayerIdentificationProperty value in list)
		{
			if (first)
			{
				first = false;
			}
			else
			{
				strValue.Add(",");
			}
			PrintTo(value, strValue);
		}
		return strValue.Value;
	}
	public static string Desc(ReceiveDataPlayerIdentificationProperty value)
	{
		return value.NameAlias.Value;
	}
	public static string Desc(List<ReceiveDataPlayerIdentificationProperty> list)
	{
		bool first = true;
		ViStringBuilder strValue = new ViStringBuilder();
		foreach (ReceiveDataPlayerIdentificationProperty value in list)
		{
			if (first)
			{
				first = false;
			}
			else
			{
				strValue.Add(",");
			}
			PrintTo(value, strValue);
		}
		return strValue.Value;
	}

}