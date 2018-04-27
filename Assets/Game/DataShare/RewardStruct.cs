using System;

public class AccumulateLoginRewardStruct : ViSealedData
{
	public string Description;
	public string Icon;
	public string Color;
	public ViForeignKey<LootStruct> Loot;
}

public class AccumulateLoginInActivityRewardStruct : ViSealedData
{
	public Int32 Day;
	public ViForeignKey<ActivityScriptStruct> ReqActivity;
	public string Description;
	public string Icon;
	public string Color;
	public ViForeignKey<LootStruct> Loot;
}

public class DayGiftStruct : ViSealedData
{
	public string Icon;
	public Int32 m_iReserve_0;
	public Int32 m_iReserve_1;
	public Int32 m_iReserve_2;
	public Int32 m_iReserve_3;
	public Int32 m_iReserve_4;
	public ViForeignKey<LootStruct> Loot;
}
