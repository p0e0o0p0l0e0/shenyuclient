using System;

public class GuildPositionStruct : ViSealedData
{
	public Int32 MemberCount;
	//
	public string Desc;
	public string Icon;
	public Int32 RankLootScale;
	public Int32 Reserve_3;
	public Int32 Reserve_4;
	//
	public ViForeignKey<GuildPositionStruct> AuthorizePosition;
}

public class GuildLevelStruct : ViSealedData
{
	public Int32 XP;
	public Int32 Reserve_0;

	public Int32 MemberCount;
	public Int64 YinPiaoMax;
	public Int32 DailyQuestCount;

	public string Desc;
	public string Icon;
}

public class GuildActivityStruct : ViSealedData
{
	public struct RequestStruct
	{
		public ViValueRange MemberCount;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
	}

	public struct _SpaceStruct
	{
		public ViForeignKey<SpaceStruct> Space;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
	}

	public struct LootCountPositionStruct
	{
		public ViForeignKey<GuildPositionStruct> Pos;
		public Int32 Count;
	}

	public struct LootCountRankStruct
	{
		public Int32 Rank;
		public Int32 Count;
	}

	public class LootCountStruct
	{
		public Int32 Count;
		public Int32 PositionSize;
		public ViStaticArray<LootCountPositionStruct> Position = new ViStaticArray<LootCountPositionStruct>(10);
		public Int32 RankSize;
		public ViStaticArray<LootCountRankStruct> Rank = new ViStaticArray<LootCountRankStruct>(10);
	}

	public ViEnum32<GuildActivityType> Type;
	public LoopCountStruct Count = new LoopCountStruct();
	public RequestStruct Request = new RequestStruct();
	public _SpaceStruct Space = new _SpaceStruct();
	public ViForeignKey<GuildPositionStruct> OpenPosition;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
	public string Title;
	public string Desc;
	public ViForeignKey<ActivityStruct> ReqActivity;
	public LootCountStruct LootCount = new LootCountStruct();
}

