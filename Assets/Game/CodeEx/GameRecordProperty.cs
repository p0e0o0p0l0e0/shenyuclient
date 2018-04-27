using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameRecordProperty
{
	public static readonly int TYPE_SIZE = 107;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public HashSet<UInt16> MergeList;//DB
	public UInt16 ServerID;//ALL_CLIENT+GM+GLOBAL
	public ViString ServerName;//ALL_CLIENT+GM+GLOBAL
	public UInt32 StartNumber;//DB
	public Int64 Time;//CELL+GM+GLOBAL+DB
	public Int64 Time1970;//CELL+GM+GLOBAL+DB
	public Int64 CreateTime1970;//GM+GLOBAL+DB
	public Int32 CreateDayNumber1970;//GM+GLOBAL+DB
	public Int64 StartTime;//CELL+ALL_CLIENT+GM+GLOBAL+DB
	public Int64 StartTime1970;//CELL+GM+GLOBAL+DB
	public Int32 StartDayNumber1970;//CELL+GM+GLOBAL+DB
	public Int32 CurrentDayNumber1970;//CELL+GM+GLOBAL+DB
	public float TimeScale;//ALL_CLIENT+CELL
	public UInt64 PlayerID;//DB
	public UInt64 AccountID;//DB
	public UInt64 PartyID;//DB
	public UInt64 GuildID;//DB
	public UInt64 Fragment0RecordID;//DB
	public UInt64 Fragment1RecordID;//DB
	public UInt64 PVEReportID;//DB
	public UInt64 PVPReportID;//DB
	public List<PlayerShotProperty> PlayerShotList;//DB
	public List<EntityIDNameProperty> GuildList;//DB
	public Dictionary<UInt8, CellStateProperty> CellStateList;//DB
	public Int64 FakeArenaVersion;//DB
	public Int64 FakeArenaRewardVersion;//DB
	public List<Int64Property> FakeArenaRewardTimeList;//DB
	public Dictionary<UInt32, ActivityProperty> ActivityList;//ALL_CLIENT+DB
	public Dictionary<UInt32, ActivityStatisticsProperty> ActivityStatisticsList;//DB
	public List<ActivityStatisticsRecordProperty> ActivityStatisticsRecordList;//DB
	public Dictionary<UInt32, ActivityProperty> ScriptActivityList;//ALL_CLIENT+DB
	public Int64 NoteTime1970;//ALL_CLIENT+DB
	public List<GameNoteProperty> NoteList;//ALL_CLIENT+DB
	public Int32 PlayerCount;//GM+GLOBAL+DB
	public Int32 PartyCount;//GM+GLOBAL+DB
	public Int32 AccountCount;//GM+GLOBAL+DB
	public Int32 GuildCount;//GM+GLOBAL+DB
	public Int32 OnlineCount;//GM+GLOBAL+DB
	public Int32 LoginWaitCount;//GM+GLOBAL+DB
	public Int32 MaxLoginWaitCount;//GM+GLOBAL+DB
	public Int32 MaxOnlineCount;//GM+GLOBAL+DB
	public Int32 DayMaxOnlineCount;//GM+GLOBAL+DB
	public Int32 WeekMaxOnlineCount;//GM+GLOBAL+DB
	public Int32 MonthMaxOnlineCount;//GM+GLOBAL+DB
	public Int64 LoginCount;//GM+GLOBAL
	public Int32 DayLoginCount;//GM+GLOBAL+DB
	public Int32 WeekLoginCount;//GM+GLOBAL+DB
	public Int32 MonthLoginCount;//GM+GLOBAL+DB
	public Int32 DayNewAccountCount;//GM+GLOBAL+DB
	public Int32 WeekNewAccountCount;//GM+GLOBAL+DB
	public Int32 MonthNewAccountCount;//GM+GLOBAL+DB
	public Int32 DayNewPlayerCount;//GM+GLOBAL+DB
	public Int32 WeekNewPlayerCount;//GM+GLOBAL+DB
	public Int32 MonthNewPlayerCount;//GM+GLOBAL+DB
	public Int32 DayNewGuildCount;//GM+GLOBAL+DB
	public Int32 WeekNewGuildCount;//GM+GLOBAL+DB
	public Int32 MonthNewGuildCount;//GM+GLOBAL+DB
	public Dictionary<UInt32, QuestGameRecordProperty> QuestRecordList;//DB
	public Dictionary<UInt32, ItemGameRecordProperty> ItemRecordList;//DB
	public Dictionary<Int16, PlayerLevelCountProperty> PlayerLevelCountList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> YinPiaoPaymentRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> JinPiaoPaymentRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> JinZiPaymentRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> ItemMarketRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> ItemShopRecordList;//DB
	public Dictionary<UInt32, Int64Property> StatisticsList;//DB
	public Dictionary<ViString, RechargeInGameRecordProperty> RechargeList;//DB
	public List<BoardProperty> BoardList;//DB
	public List<StringProperty> CDKeyList;//DB
	public List<GMRequestContentProperty> GlobalGMRecordList;//DB
	public List<GMRequestMailProperty> GlobalMailList;//DB
	public Dictionary<ViString, DisableRecordProperty> IPDisableList;//DB
	public Dictionary<ViString, DisableRecordProperty> AccountDisableList;//DB
	public HashSet<UInt32> ItemLockedList;//ALL_CLIENT+DB
	public HashSet<UInt32> AuraLockedList;//ALL_CLIENT+DB
	public HashSet<UInt32> SpaceClosedList;//ALL_CLIENT+DB
	public HashSet<UInt32> SpellClosedList;//ALL_CLIENT+DB
	public HashSet<UInt32> GameFuncClosedList;//ALL_CLIENT+CELL+DB
	public Int32 EntityCount;//DB
	public Int32 EntityIDCount;//DB
	public Int32 EntityPackIDCount;//DB
	public Int32 SpaceCount;//DB
	public Dictionary<UInt64, PlayerOnlineProperty> OnlinePlayerList;//DB
	public List<StringProperty> RPCExecNameList;//DB
	public List<Int64Property> RPCExecCountList;//DB
	public List<MemoryUseProperty> MemoryCountList0;//DB
	public List<MemoryUseProperty> MemoryCountList1;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveXPListInNPC;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveXPListInQuest;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveXPListInLoot;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveXPListInActivity;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveYinPiaoListInNPC;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveYinPiaoListInQuest;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveYinPiaoListInLoot;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveYinPiaoListInActivity;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveJinPiaoListInNPC;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveJinPiaoListInQuest;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveJinPiaoListInLoot;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveJinPiaoListInActivity;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveItemListInNPC;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveItemListInQuest;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveItemListInLoot;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveItemListInActivity;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveItemListInShop;//DB
	public Dictionary<UInt32, CountValue64Property> ReceiveItemListInMarket;//DB
	public Dictionary<UInt32, CountValue64Property> TradeItemListInMarket;//DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<UInt16>.Read(IS, out MergeList);
		ViGameSerializer<UInt16>.Read(IS, out ServerID);
		ViGameSerializer<ViString>.Read(IS, out ServerName);
		ViGameSerializer<UInt32>.Read(IS, out StartNumber);
		ViGameSerializer<Int64>.Read(IS, out Time);
		ViGameSerializer<Int64>.Read(IS, out Time1970);
		ViGameSerializer<Int64>.Read(IS, out CreateTime1970);
		ViGameSerializer<Int32>.Read(IS, out CreateDayNumber1970);
		ViGameSerializer<Int64>.Read(IS, out StartTime);
		ViGameSerializer<Int64>.Read(IS, out StartTime1970);
		ViGameSerializer<Int32>.Read(IS, out StartDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out CurrentDayNumber1970);
		ViGameSerializer<float>.Read(IS, out TimeScale);
		ViGameSerializer<UInt64>.Read(IS, out PlayerID);
		ViGameSerializer<UInt64>.Read(IS, out AccountID);
		ViGameSerializer<UInt64>.Read(IS, out PartyID);
		ViGameSerializer<UInt64>.Read(IS, out GuildID);
		ViGameSerializer<UInt64>.Read(IS, out Fragment0RecordID);
		ViGameSerializer<UInt64>.Read(IS, out Fragment1RecordID);
		ViGameSerializer<UInt64>.Read(IS, out PVEReportID);
		ViGameSerializer<UInt64>.Read(IS, out PVPReportID);
		ViGameSerializer<PlayerShotProperty>.Read(IS, out PlayerShotList);
		ViGameSerializer<EntityIDNameProperty>.Read(IS, out GuildList);
		ViGameSerializer<CellStateProperty>.Read(IS, out CellStateList);
		ViGameSerializer<Int64>.Read(IS, out FakeArenaVersion);
		ViGameSerializer<Int64>.Read(IS, out FakeArenaRewardVersion);
		ViGameSerializer<Int64Property>.Read(IS, out FakeArenaRewardTimeList);
		ViGameSerializer<ActivityProperty>.Read(IS, out ActivityList);
		ViGameSerializer<ActivityStatisticsProperty>.Read(IS, out ActivityStatisticsList);
		ViGameSerializer<ActivityStatisticsRecordProperty>.Read(IS, out ActivityStatisticsRecordList);
		ViGameSerializer<ActivityProperty>.Read(IS, out ScriptActivityList);
		ViGameSerializer<Int64>.Read(IS, out NoteTime1970);
		ViGameSerializer<GameNoteProperty>.Read(IS, out NoteList);
		ViGameSerializer<Int32>.Read(IS, out PlayerCount);
		ViGameSerializer<Int32>.Read(IS, out PartyCount);
		ViGameSerializer<Int32>.Read(IS, out AccountCount);
		ViGameSerializer<Int32>.Read(IS, out GuildCount);
		ViGameSerializer<Int32>.Read(IS, out OnlineCount);
		ViGameSerializer<Int32>.Read(IS, out LoginWaitCount);
		ViGameSerializer<Int32>.Read(IS, out MaxLoginWaitCount);
		ViGameSerializer<Int32>.Read(IS, out MaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out DayMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out WeekMaxOnlineCount);
		ViGameSerializer<Int32>.Read(IS, out MonthMaxOnlineCount);
		ViGameSerializer<Int64>.Read(IS, out LoginCount);
		ViGameSerializer<Int32>.Read(IS, out DayLoginCount);
		ViGameSerializer<Int32>.Read(IS, out WeekLoginCount);
		ViGameSerializer<Int32>.Read(IS, out MonthLoginCount);
		ViGameSerializer<Int32>.Read(IS, out DayNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out WeekNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out MonthNewAccountCount);
		ViGameSerializer<Int32>.Read(IS, out DayNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out WeekNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out MonthNewPlayerCount);
		ViGameSerializer<Int32>.Read(IS, out DayNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out WeekNewGuildCount);
		ViGameSerializer<Int32>.Read(IS, out MonthNewGuildCount);
		ViGameSerializer<QuestGameRecordProperty>.Read(IS, out QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Read(IS, out ItemRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Read(IS, out PlayerLevelCountList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out ItemShopRecordList);
		ViGameSerializer<Int64Property>.Read(IS, out StatisticsList);
		ViGameSerializer<RechargeInGameRecordProperty>.Read(IS, out RechargeList);
		ViGameSerializer<BoardProperty>.Read(IS, out BoardList);
		ViGameSerializer<StringProperty>.Read(IS, out CDKeyList);
		ViGameSerializer<GMRequestContentProperty>.Read(IS, out GlobalGMRecordList);
		ViGameSerializer<GMRequestMailProperty>.Read(IS, out GlobalMailList);
		ViGameSerializer<DisableRecordProperty>.Read(IS, out IPDisableList);
		ViGameSerializer<DisableRecordProperty>.Read(IS, out AccountDisableList);
		ViGameSerializer<UInt32>.Read(IS, out ItemLockedList);
		ViGameSerializer<UInt32>.Read(IS, out AuraLockedList);
		ViGameSerializer<UInt32>.Read(IS, out SpaceClosedList);
		ViGameSerializer<UInt32>.Read(IS, out SpellClosedList);
		ViGameSerializer<UInt32>.Read(IS, out GameFuncClosedList);
		ViGameSerializer<Int32>.Read(IS, out EntityCount);
		ViGameSerializer<Int32>.Read(IS, out EntityIDCount);
		ViGameSerializer<Int32>.Read(IS, out EntityPackIDCount);
		ViGameSerializer<Int32>.Read(IS, out SpaceCount);
		ViGameSerializer<PlayerOnlineProperty>.Read(IS, out OnlinePlayerList);
		ViGameSerializer<StringProperty>.Read(IS, out RPCExecNameList);
		ViGameSerializer<Int64Property>.Read(IS, out RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out MemoryCountList1);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveXPListInNPC);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveXPListInQuest);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveXPListInLoot);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveXPListInActivity);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveYinPiaoListInNPC);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveYinPiaoListInQuest);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveYinPiaoListInLoot);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveYinPiaoListInActivity);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveJinPiaoListInNPC);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveJinPiaoListInQuest);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveJinPiaoListInLoot);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveJinPiaoListInActivity);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveItemListInNPC);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveItemListInQuest);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveItemListInLoot);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveItemListInActivity);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveItemListInShop);
		ViGameSerializer<CountValue64Property>.Read(IS, out ReceiveItemListInMarket);
		ViGameSerializer<CountValue64Property>.Read(IS, out TradeItemListInMarket);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<UInt16>.Append(OS, head + "MergeList", MergeList);
		ViGameSerializer<UInt16>.Append(OS, head + "ServerID", ServerID);
		ViGameSerializer<ViString>.Append(OS, head + "ServerName", ServerName);
		ViGameSerializer<UInt32>.Append(OS, head + "StartNumber", StartNumber);
		ViGameSerializer<Int64>.Append(OS, head + "Time", Time);
		ViGameSerializer<Int64>.Append(OS, head + "Time1970", Time1970);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime1970", CreateTime1970);
		ViGameSerializer<Int32>.Append(OS, head + "CreateDayNumber1970", CreateDayNumber1970);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime", StartTime);
		ViGameSerializer<Int64>.Append(OS, head + "StartTime1970", StartTime1970);
		ViGameSerializer<Int32>.Append(OS, head + "StartDayNumber1970", StartDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "CurrentDayNumber1970", CurrentDayNumber1970);
		ViGameSerializer<float>.Append(OS, head + "TimeScale", TimeScale);
		ViGameSerializer<UInt64>.Append(OS, head + "PlayerID", PlayerID);
		ViGameSerializer<UInt64>.Append(OS, head + "AccountID", AccountID);
		ViGameSerializer<UInt64>.Append(OS, head + "PartyID", PartyID);
		ViGameSerializer<UInt64>.Append(OS, head + "GuildID", GuildID);
		ViGameSerializer<UInt64>.Append(OS, head + "Fragment0RecordID", Fragment0RecordID);
		ViGameSerializer<UInt64>.Append(OS, head + "Fragment1RecordID", Fragment1RecordID);
		ViGameSerializer<UInt64>.Append(OS, head + "PVEReportID", PVEReportID);
		ViGameSerializer<UInt64>.Append(OS, head + "PVPReportID", PVPReportID);
		ViGameSerializer<PlayerShotProperty>.Append(OS, head + "PlayerShotList", PlayerShotList);
		ViGameSerializer<EntityIDNameProperty>.Append(OS, head + "GuildList", GuildList);
		ViGameSerializer<CellStateProperty>.Append(OS, head + "CellStateList", CellStateList);
		ViGameSerializer<Int64>.Append(OS, head + "FakeArenaVersion", FakeArenaVersion);
		ViGameSerializer<Int64>.Append(OS, head + "FakeArenaRewardVersion", FakeArenaRewardVersion);
		ViGameSerializer<Int64Property>.Append(OS, head + "FakeArenaRewardTimeList", FakeArenaRewardTimeList);
		ViGameSerializer<ActivityProperty>.Append(OS, head + "ActivityList", ActivityList);
		ViGameSerializer<ActivityStatisticsProperty>.Append(OS, head + "ActivityStatisticsList", ActivityStatisticsList);
		ViGameSerializer<ActivityStatisticsRecordProperty>.Append(OS, head + "ActivityStatisticsRecordList", ActivityStatisticsRecordList);
		ViGameSerializer<ActivityProperty>.Append(OS, head + "ScriptActivityList", ScriptActivityList);
		ViGameSerializer<Int64>.Append(OS, head + "NoteTime1970", NoteTime1970);
		ViGameSerializer<GameNoteProperty>.Append(OS, head + "NoteList", NoteList);
		ViGameSerializer<Int32>.Append(OS, head + "PlayerCount", PlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "PartyCount", PartyCount);
		ViGameSerializer<Int32>.Append(OS, head + "AccountCount", AccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "GuildCount", GuildCount);
		ViGameSerializer<Int32>.Append(OS, head + "OnlineCount", OnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + "LoginWaitCount", LoginWaitCount);
		ViGameSerializer<Int32>.Append(OS, head + "MaxLoginWaitCount", MaxLoginWaitCount);
		ViGameSerializer<Int32>.Append(OS, head + "MaxOnlineCount", MaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayMaxOnlineCount", DayMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekMaxOnlineCount", WeekMaxOnlineCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthMaxOnlineCount", MonthMaxOnlineCount);
		ViGameSerializer<Int64>.Append(OS, head + "LoginCount", LoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayLoginCount", DayLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekLoginCount", WeekLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthLoginCount", MonthLoginCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayNewAccountCount", DayNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekNewAccountCount", WeekNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthNewAccountCount", MonthNewAccountCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayNewPlayerCount", DayNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekNewPlayerCount", WeekNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthNewPlayerCount", MonthNewPlayerCount);
		ViGameSerializer<Int32>.Append(OS, head + "DayNewGuildCount", DayNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + "WeekNewGuildCount", WeekNewGuildCount);
		ViGameSerializer<Int32>.Append(OS, head + "MonthNewGuildCount", MonthNewGuildCount);
		ViGameSerializer<QuestGameRecordProperty>.Append(OS, head + "QuestRecordList", QuestRecordList);
		ViGameSerializer<ItemGameRecordProperty>.Append(OS, head + "ItemRecordList", ItemRecordList);
		ViGameSerializer<PlayerLevelCountProperty>.Append(OS, head + "PlayerLevelCountList", PlayerLevelCountList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "YinPiaoPaymentRecordList", YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "JinPiaoPaymentRecordList", JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "JinZiPaymentRecordList", JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "ItemMarketRecordList", ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "ItemShopRecordList", ItemShopRecordList);
		ViGameSerializer<Int64Property>.Append(OS, head + "StatisticsList", StatisticsList);
		ViGameSerializer<RechargeInGameRecordProperty>.Append(OS, head + "RechargeList", RechargeList);
		ViGameSerializer<BoardProperty>.Append(OS, head + "BoardList", BoardList);
		ViGameSerializer<StringProperty>.Append(OS, head + "CDKeyList", CDKeyList);
		ViGameSerializer<GMRequestContentProperty>.Append(OS, head + "GlobalGMRecordList", GlobalGMRecordList);
		ViGameSerializer<GMRequestMailProperty>.Append(OS, head + "GlobalMailList", GlobalMailList);
		ViGameSerializer<DisableRecordProperty>.Append(OS, head + "IPDisableList", IPDisableList);
		ViGameSerializer<DisableRecordProperty>.Append(OS, head + "AccountDisableList", AccountDisableList);
		ViGameSerializer<UInt32>.Append(OS, head + "ItemLockedList", ItemLockedList);
		ViGameSerializer<UInt32>.Append(OS, head + "AuraLockedList", AuraLockedList);
		ViGameSerializer<UInt32>.Append(OS, head + "SpaceClosedList", SpaceClosedList);
		ViGameSerializer<UInt32>.Append(OS, head + "SpellClosedList", SpellClosedList);
		ViGameSerializer<UInt32>.Append(OS, head + "GameFuncClosedList", GameFuncClosedList);
		ViGameSerializer<Int32>.Append(OS, head + "EntityCount", EntityCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityIDCount", EntityIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityPackIDCount", EntityPackIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "SpaceCount", SpaceCount);
		ViGameSerializer<PlayerOnlineProperty>.Append(OS, head + "OnlinePlayerList", OnlinePlayerList);
		ViGameSerializer<StringProperty>.Append(OS, head + "RPCExecNameList", RPCExecNameList);
		ViGameSerializer<Int64Property>.Append(OS, head + "RPCExecCountList", RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + "MemoryCountList0", MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + "MemoryCountList1", MemoryCountList1);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveXPListInNPC", ReceiveXPListInNPC);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveXPListInQuest", ReceiveXPListInQuest);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveXPListInLoot", ReceiveXPListInLoot);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveXPListInActivity", ReceiveXPListInActivity);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveYinPiaoListInNPC", ReceiveYinPiaoListInNPC);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveYinPiaoListInQuest", ReceiveYinPiaoListInQuest);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveYinPiaoListInLoot", ReceiveYinPiaoListInLoot);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveYinPiaoListInActivity", ReceiveYinPiaoListInActivity);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveJinPiaoListInNPC", ReceiveJinPiaoListInNPC);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveJinPiaoListInQuest", ReceiveJinPiaoListInQuest);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveJinPiaoListInLoot", ReceiveJinPiaoListInLoot);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveJinPiaoListInActivity", ReceiveJinPiaoListInActivity);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveItemListInNPC", ReceiveItemListInNPC);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveItemListInQuest", ReceiveItemListInQuest);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveItemListInLoot", ReceiveItemListInLoot);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveItemListInActivity", ReceiveItemListInActivity);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveItemListInShop", ReceiveItemListInShop);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "ReceiveItemListInMarket", ReceiveItemListInMarket);
		ViGameSerializer<CountValue64Property>.Append(OS, head + "TradeItemListInMarket", TradeItemListInMarket);
	}
}

public class GameRecordReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 107;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataSet<UInt16> MergeList = new ViReceiveDataSet<UInt16>();//DB
	public ViReceiveDataUInt16 ServerID = new ViReceiveDataUInt16();//ALL_CLIENT+GM+GLOBAL
	public ViReceiveDataString ServerName = new ViReceiveDataString();//ALL_CLIENT+GM+GLOBAL
	private ViReceiveDataUInt32 StartNumber = new ViReceiveDataUInt32();//DB
	private ViReceiveDataInt64 Time = new ViReceiveDataInt64();//CELL+GM+GLOBAL+DB
	private ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();//CELL+GM+GLOBAL+DB
	private ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();//GM+GLOBAL+DB
	private ViReceiveDataInt32 CreateDayNumber1970 = new ViReceiveDataInt32();//GM+GLOBAL+DB
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();//CELL+ALL_CLIENT+GM+GLOBAL+DB
	private ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();//CELL+GM+GLOBAL+DB
	private ViReceiveDataInt32 StartDayNumber1970 = new ViReceiveDataInt32();//CELL+GM+GLOBAL+DB
	private ViReceiveDataInt32 CurrentDayNumber1970 = new ViReceiveDataInt32();//CELL+GM+GLOBAL+DB
	public ViReceiveDataFloat TimeScale = new ViReceiveDataFloat();//ALL_CLIENT+CELL
	private ViReceiveDataUInt64 PlayerID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 AccountID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 PartyID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 GuildID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 Fragment0RecordID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 Fragment1RecordID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 PVEReportID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 PVPReportID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataArray<ReceiveDataPlayerShotProperty, PlayerShotProperty> PlayerShotList = new ViReceiveDataArray<ReceiveDataPlayerShotProperty, PlayerShotProperty>();//DB
	private ViReceiveDataArray<ReceiveDataEntityIDNameProperty, EntityIDNameProperty> GuildList = new ViReceiveDataArray<ReceiveDataEntityIDNameProperty, EntityIDNameProperty>();//DB
	private ViReceiveDataDictionary<UInt8, ReceiveDataCellStateProperty, CellStateProperty> CellStateList = new ViReceiveDataDictionary<UInt8, ReceiveDataCellStateProperty, CellStateProperty>();//DB
	private ViReceiveDataInt64 FakeArenaVersion = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt64 FakeArenaRewardVersion = new ViReceiveDataInt64();//DB
	private ViReceiveDataArray<ReceiveDataInt64Property, Int64Property> FakeArenaRewardTimeList = new ViReceiveDataArray<ReceiveDataInt64Property, Int64Property>();//DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataActivityProperty, ActivityProperty> ActivityList = new ViReceiveDataDictionary<UInt32, ReceiveDataActivityProperty, ActivityProperty>();//ALL_CLIENT+DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataActivityStatisticsProperty, ActivityStatisticsProperty> ActivityStatisticsList = new ViReceiveDataDictionary<UInt32, ReceiveDataActivityStatisticsProperty, ActivityStatisticsProperty>();//DB
	private ViReceiveDataArray<ReceiveDataActivityStatisticsRecordProperty, ActivityStatisticsRecordProperty> ActivityStatisticsRecordList = new ViReceiveDataArray<ReceiveDataActivityStatisticsRecordProperty, ActivityStatisticsRecordProperty>();//DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataActivityProperty, ActivityProperty> ScriptActivityList = new ViReceiveDataDictionary<UInt32, ReceiveDataActivityProperty, ActivityProperty>();//ALL_CLIENT+DB
	public ViReceiveDataInt64 NoteTime1970 = new ViReceiveDataInt64();//ALL_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataGameNoteProperty, GameNoteProperty> NoteList = new ViReceiveDataArray<ReceiveDataGameNoteProperty, GameNoteProperty>();//ALL_CLIENT+DB
	private ViReceiveDataInt32 PlayerCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 PartyCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 AccountCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 GuildCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 OnlineCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 LoginWaitCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MaxLoginWaitCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MaxOnlineCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 DayMaxOnlineCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 WeekMaxOnlineCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MonthMaxOnlineCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt64 LoginCount = new ViReceiveDataInt64();//GM+GLOBAL
	private ViReceiveDataInt32 DayLoginCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 WeekLoginCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MonthLoginCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 DayNewAccountCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 WeekNewAccountCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MonthNewAccountCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 DayNewPlayerCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 WeekNewPlayerCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MonthNewPlayerCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 DayNewGuildCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 WeekNewGuildCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataInt32 MonthNewGuildCount = new ViReceiveDataInt32();//GM+GLOBAL+DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataQuestGameRecordProperty, QuestGameRecordProperty> QuestRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataQuestGameRecordProperty, QuestGameRecordProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataItemGameRecordProperty, ItemGameRecordProperty> ItemRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataItemGameRecordProperty, ItemGameRecordProperty>();//DB
	private ViReceiveDataDictionary<Int16, ReceiveDataPlayerLevelCountProperty, PlayerLevelCountProperty> PlayerLevelCountList = new ViReceiveDataDictionary<Int16, ReceiveDataPlayerLevelCountProperty, PlayerLevelCountProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> YinPiaoPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> JinPiaoPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> JinZiPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> ItemMarketRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> ItemShopRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property> StatisticsList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property>();//DB
	private ViReceiveDataDictionary<ViString, ReceiveDataRechargeInGameRecordProperty, RechargeInGameRecordProperty> RechargeList = new ViReceiveDataDictionary<ViString, ReceiveDataRechargeInGameRecordProperty, RechargeInGameRecordProperty>();//DB
	private ViReceiveDataArray<ReceiveDataBoardProperty, BoardProperty> BoardList = new ViReceiveDataArray<ReceiveDataBoardProperty, BoardProperty>();//DB
	private ViReceiveDataArray<ReceiveDataStringProperty, StringProperty> CDKeyList = new ViReceiveDataArray<ReceiveDataStringProperty, StringProperty>();//DB
	private ViReceiveDataArray<ReceiveDataGMRequestContentProperty, GMRequestContentProperty> GlobalGMRecordList = new ViReceiveDataArray<ReceiveDataGMRequestContentProperty, GMRequestContentProperty>();//DB
	private ViReceiveDataArray<ReceiveDataGMRequestMailProperty, GMRequestMailProperty> GlobalMailList = new ViReceiveDataArray<ReceiveDataGMRequestMailProperty, GMRequestMailProperty>();//DB
	private ViReceiveDataDictionary<ViString, ReceiveDataDisableRecordProperty, DisableRecordProperty> IPDisableList = new ViReceiveDataDictionary<ViString, ReceiveDataDisableRecordProperty, DisableRecordProperty>();//DB
	private ViReceiveDataDictionary<ViString, ReceiveDataDisableRecordProperty, DisableRecordProperty> AccountDisableList = new ViReceiveDataDictionary<ViString, ReceiveDataDisableRecordProperty, DisableRecordProperty>();//DB
	public ViReceiveDataSet<UInt32> ItemLockedList = new ViReceiveDataSet<UInt32>();//ALL_CLIENT+DB
	public ViReceiveDataSet<UInt32> AuraLockedList = new ViReceiveDataSet<UInt32>();//ALL_CLIENT+DB
	public ViReceiveDataSet<UInt32> SpaceClosedList = new ViReceiveDataSet<UInt32>();//ALL_CLIENT+DB
	public ViReceiveDataSet<UInt32> SpellClosedList = new ViReceiveDataSet<UInt32>();//ALL_CLIENT+DB
	public ViReceiveDataSet<UInt32> GameFuncClosedList = new ViReceiveDataSet<UInt32>();//ALL_CLIENT+CELL+DB
	private ViReceiveDataInt32 EntityCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityIDCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityPackIDCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 SpaceCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataDictionary<UInt64, ReceiveDataPlayerOnlineProperty, PlayerOnlineProperty> OnlinePlayerList = new ViReceiveDataDictionary<UInt64, ReceiveDataPlayerOnlineProperty, PlayerOnlineProperty>();//DB
	private ViReceiveDataArray<ReceiveDataStringProperty, StringProperty> RPCExecNameList = new ViReceiveDataArray<ReceiveDataStringProperty, StringProperty>();//DB
	private ViReceiveDataArray<ReceiveDataInt64Property, Int64Property> RPCExecCountList = new ViReceiveDataArray<ReceiveDataInt64Property, Int64Property>();//DB
	private ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty> MemoryCountList0 = new ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty>();//DB
	private ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty> MemoryCountList1 = new ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveXPListInNPC = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveXPListInQuest = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveXPListInLoot = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveXPListInActivity = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveYinPiaoListInNPC = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveYinPiaoListInQuest = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveYinPiaoListInLoot = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveYinPiaoListInActivity = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveJinPiaoListInNPC = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveJinPiaoListInQuest = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveJinPiaoListInLoot = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveJinPiaoListInActivity = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveItemListInNPC = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveItemListInQuest = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveItemListInLoot = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveItemListInActivity = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveItemListInShop = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> ReceiveItemListInMarket = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property> TradeItemListInMarket = new ViReceiveDataDictionary<UInt32, ReceiveDataCountValue64Property, CountValue64Property>();//DB
	//
	public GameRecordReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MergeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ServerID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL)), this, ChildList);
		ServerName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL)), this, ChildList);
		StartNumber.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CurrentDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		TimeScale.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CELL)), this, ChildList);
		PlayerID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccountID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PartyID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GuildID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Fragment0RecordID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Fragment1RecordID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PVEReportID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PVPReportID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PlayerShotList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GuildList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CellStateList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		FakeArenaVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		FakeArenaRewardVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		FakeArenaRewardTimeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActivityList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActivityStatisticsList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActivityStatisticsRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ScriptActivityList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		NoteTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		NoteList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PartyCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LoginWaitCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MaxLoginWaitCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MaxOnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayMaxOnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekMaxOnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthMaxOnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL)), this, ChildList);
		DayLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.GM) | (1 << (int)ProjectAChannel.GLOBAL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		QuestRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PlayerLevelCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinPiaoPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemMarketRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemShopRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		StatisticsList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RechargeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		BoardList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CDKeyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GlobalGMRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GlobalMailList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		IPDisableList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccountDisableList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemLockedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AuraLockedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		SpaceClosedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		SpellClosedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GameFuncClosedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityIDCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityPackIDCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		SpaceCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlinePlayerList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RPCExecNameList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RPCExecCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MemoryCountList0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MemoryCountList1.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveXPListInNPC.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveXPListInQuest.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveXPListInLoot.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveXPListInActivity.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveYinPiaoListInNPC.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveYinPiaoListInQuest.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveYinPiaoListInLoot.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveYinPiaoListInActivity.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveJinPiaoListInNPC.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveJinPiaoListInQuest.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveJinPiaoListInLoot.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveJinPiaoListInActivity.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveItemListInNPC.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveItemListInQuest.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveItemListInLoot.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveItemListInActivity.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveItemListInShop.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ReceiveItemListInMarket.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		TradeItemListInMarket.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		DataVersion.Start(channelMask, IS, entity);
		MergeList.Start(channelMask, IS, entity);
		ServerID.Start(channelMask, IS, entity);
		ServerName.Start(channelMask, IS, entity);
		StartNumber.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		CreateTime1970.Start(channelMask, IS, entity);
		CreateDayNumber1970.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		StartTime1970.Start(channelMask, IS, entity);
		StartDayNumber1970.Start(channelMask, IS, entity);
		CurrentDayNumber1970.Start(channelMask, IS, entity);
		TimeScale.Start(channelMask, IS, entity);
		PlayerID.Start(channelMask, IS, entity);
		AccountID.Start(channelMask, IS, entity);
		PartyID.Start(channelMask, IS, entity);
		GuildID.Start(channelMask, IS, entity);
		Fragment0RecordID.Start(channelMask, IS, entity);
		Fragment1RecordID.Start(channelMask, IS, entity);
		PVEReportID.Start(channelMask, IS, entity);
		PVPReportID.Start(channelMask, IS, entity);
		PlayerShotList.Start(channelMask, IS, entity);
		GuildList.Start(channelMask, IS, entity);
		CellStateList.Start(channelMask, IS, entity);
		FakeArenaVersion.Start(channelMask, IS, entity);
		FakeArenaRewardVersion.Start(channelMask, IS, entity);
		FakeArenaRewardTimeList.Start(channelMask, IS, entity);
		ActivityList.Start(channelMask, IS, entity);
		ActivityStatisticsList.Start(channelMask, IS, entity);
		ActivityStatisticsRecordList.Start(channelMask, IS, entity);
		ScriptActivityList.Start(channelMask, IS, entity);
		NoteTime1970.Start(channelMask, IS, entity);
		NoteList.Start(channelMask, IS, entity);
		PlayerCount.Start(channelMask, IS, entity);
		PartyCount.Start(channelMask, IS, entity);
		AccountCount.Start(channelMask, IS, entity);
		GuildCount.Start(channelMask, IS, entity);
		OnlineCount.Start(channelMask, IS, entity);
		LoginWaitCount.Start(channelMask, IS, entity);
		MaxLoginWaitCount.Start(channelMask, IS, entity);
		MaxOnlineCount.Start(channelMask, IS, entity);
		DayMaxOnlineCount.Start(channelMask, IS, entity);
		WeekMaxOnlineCount.Start(channelMask, IS, entity);
		MonthMaxOnlineCount.Start(channelMask, IS, entity);
		LoginCount.Start(channelMask, IS, entity);
		DayLoginCount.Start(channelMask, IS, entity);
		WeekLoginCount.Start(channelMask, IS, entity);
		MonthLoginCount.Start(channelMask, IS, entity);
		DayNewAccountCount.Start(channelMask, IS, entity);
		WeekNewAccountCount.Start(channelMask, IS, entity);
		MonthNewAccountCount.Start(channelMask, IS, entity);
		DayNewPlayerCount.Start(channelMask, IS, entity);
		WeekNewPlayerCount.Start(channelMask, IS, entity);
		MonthNewPlayerCount.Start(channelMask, IS, entity);
		DayNewGuildCount.Start(channelMask, IS, entity);
		WeekNewGuildCount.Start(channelMask, IS, entity);
		MonthNewGuildCount.Start(channelMask, IS, entity);
		QuestRecordList.Start(channelMask, IS, entity);
		ItemRecordList.Start(channelMask, IS, entity);
		PlayerLevelCountList.Start(channelMask, IS, entity);
		YinPiaoPaymentRecordList.Start(channelMask, IS, entity);
		JinPiaoPaymentRecordList.Start(channelMask, IS, entity);
		JinZiPaymentRecordList.Start(channelMask, IS, entity);
		ItemMarketRecordList.Start(channelMask, IS, entity);
		ItemShopRecordList.Start(channelMask, IS, entity);
		StatisticsList.Start(channelMask, IS, entity);
		RechargeList.Start(channelMask, IS, entity);
		BoardList.Start(channelMask, IS, entity);
		CDKeyList.Start(channelMask, IS, entity);
		GlobalGMRecordList.Start(channelMask, IS, entity);
		GlobalMailList.Start(channelMask, IS, entity);
		IPDisableList.Start(channelMask, IS, entity);
		AccountDisableList.Start(channelMask, IS, entity);
		ItemLockedList.Start(channelMask, IS, entity);
		AuraLockedList.Start(channelMask, IS, entity);
		SpaceClosedList.Start(channelMask, IS, entity);
		SpellClosedList.Start(channelMask, IS, entity);
		GameFuncClosedList.Start(channelMask, IS, entity);
		EntityCount.Start(channelMask, IS, entity);
		EntityIDCount.Start(channelMask, IS, entity);
		EntityPackIDCount.Start(channelMask, IS, entity);
		SpaceCount.Start(channelMask, IS, entity);
		OnlinePlayerList.Start(channelMask, IS, entity);
		RPCExecNameList.Start(channelMask, IS, entity);
		RPCExecCountList.Start(channelMask, IS, entity);
		MemoryCountList0.Start(channelMask, IS, entity);
		MemoryCountList1.Start(channelMask, IS, entity);
		ReceiveXPListInNPC.Start(channelMask, IS, entity);
		ReceiveXPListInQuest.Start(channelMask, IS, entity);
		ReceiveXPListInLoot.Start(channelMask, IS, entity);
		ReceiveXPListInActivity.Start(channelMask, IS, entity);
		ReceiveYinPiaoListInNPC.Start(channelMask, IS, entity);
		ReceiveYinPiaoListInQuest.Start(channelMask, IS, entity);
		ReceiveYinPiaoListInLoot.Start(channelMask, IS, entity);
		ReceiveYinPiaoListInActivity.Start(channelMask, IS, entity);
		ReceiveJinPiaoListInNPC.Start(channelMask, IS, entity);
		ReceiveJinPiaoListInQuest.Start(channelMask, IS, entity);
		ReceiveJinPiaoListInLoot.Start(channelMask, IS, entity);
		ReceiveJinPiaoListInActivity.Start(channelMask, IS, entity);
		ReceiveItemListInNPC.Start(channelMask, IS, entity);
		ReceiveItemListInQuest.Start(channelMask, IS, entity);
		ReceiveItemListInLoot.Start(channelMask, IS, entity);
		ReceiveItemListInActivity.Start(channelMask, IS, entity);
		ReceiveItemListInShop.Start(channelMask, IS, entity);
		ReceiveItemListInMarket.Start(channelMask, IS, entity);
		TradeItemListInMarket.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		MergeList.End(entity);
		ServerID.End(entity);
		ServerName.End(entity);
		StartNumber.End(entity);
		Time.End(entity);
		Time1970.End(entity);
		CreateTime1970.End(entity);
		CreateDayNumber1970.End(entity);
		StartTime.End(entity);
		StartTime1970.End(entity);
		StartDayNumber1970.End(entity);
		CurrentDayNumber1970.End(entity);
		TimeScale.End(entity);
		PlayerID.End(entity);
		AccountID.End(entity);
		PartyID.End(entity);
		GuildID.End(entity);
		Fragment0RecordID.End(entity);
		Fragment1RecordID.End(entity);
		PVEReportID.End(entity);
		PVPReportID.End(entity);
		PlayerShotList.End(entity);
		GuildList.End(entity);
		CellStateList.End(entity);
		FakeArenaVersion.End(entity);
		FakeArenaRewardVersion.End(entity);
		FakeArenaRewardTimeList.End(entity);
		ActivityList.End(entity);
		ActivityStatisticsList.End(entity);
		ActivityStatisticsRecordList.End(entity);
		ScriptActivityList.End(entity);
		NoteTime1970.End(entity);
		NoteList.End(entity);
		PlayerCount.End(entity);
		PartyCount.End(entity);
		AccountCount.End(entity);
		GuildCount.End(entity);
		OnlineCount.End(entity);
		LoginWaitCount.End(entity);
		MaxLoginWaitCount.End(entity);
		MaxOnlineCount.End(entity);
		DayMaxOnlineCount.End(entity);
		WeekMaxOnlineCount.End(entity);
		MonthMaxOnlineCount.End(entity);
		LoginCount.End(entity);
		DayLoginCount.End(entity);
		WeekLoginCount.End(entity);
		MonthLoginCount.End(entity);
		DayNewAccountCount.End(entity);
		WeekNewAccountCount.End(entity);
		MonthNewAccountCount.End(entity);
		DayNewPlayerCount.End(entity);
		WeekNewPlayerCount.End(entity);
		MonthNewPlayerCount.End(entity);
		DayNewGuildCount.End(entity);
		WeekNewGuildCount.End(entity);
		MonthNewGuildCount.End(entity);
		QuestRecordList.End(entity);
		ItemRecordList.End(entity);
		PlayerLevelCountList.End(entity);
		YinPiaoPaymentRecordList.End(entity);
		JinPiaoPaymentRecordList.End(entity);
		JinZiPaymentRecordList.End(entity);
		ItemMarketRecordList.End(entity);
		ItemShopRecordList.End(entity);
		StatisticsList.End(entity);
		RechargeList.End(entity);
		BoardList.End(entity);
		CDKeyList.End(entity);
		GlobalGMRecordList.End(entity);
		GlobalMailList.End(entity);
		IPDisableList.End(entity);
		AccountDisableList.End(entity);
		ItemLockedList.End(entity);
		AuraLockedList.End(entity);
		SpaceClosedList.End(entity);
		SpellClosedList.End(entity);
		GameFuncClosedList.End(entity);
		EntityCount.End(entity);
		EntityIDCount.End(entity);
		EntityPackIDCount.End(entity);
		SpaceCount.End(entity);
		OnlinePlayerList.End(entity);
		RPCExecNameList.End(entity);
		RPCExecCountList.End(entity);
		MemoryCountList0.End(entity);
		MemoryCountList1.End(entity);
		ReceiveXPListInNPC.End(entity);
		ReceiveXPListInQuest.End(entity);
		ReceiveXPListInLoot.End(entity);
		ReceiveXPListInActivity.End(entity);
		ReceiveYinPiaoListInNPC.End(entity);
		ReceiveYinPiaoListInQuest.End(entity);
		ReceiveYinPiaoListInLoot.End(entity);
		ReceiveYinPiaoListInActivity.End(entity);
		ReceiveJinPiaoListInNPC.End(entity);
		ReceiveJinPiaoListInQuest.End(entity);
		ReceiveJinPiaoListInLoot.End(entity);
		ReceiveJinPiaoListInActivity.End(entity);
		ReceiveItemListInNPC.End(entity);
		ReceiveItemListInQuest.End(entity);
		ReceiveItemListInLoot.End(entity);
		ReceiveItemListInActivity.End(entity);
		ReceiveItemListInShop.End(entity);
		ReceiveItemListInMarket.End(entity);
		TradeItemListInMarket.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		MergeList.Clear();
		ServerID.Clear();
		ServerName.Clear();
		StartNumber.Clear();
		Time.Clear();
		Time1970.Clear();
		CreateTime1970.Clear();
		CreateDayNumber1970.Clear();
		StartTime.Clear();
		StartTime1970.Clear();
		StartDayNumber1970.Clear();
		CurrentDayNumber1970.Clear();
		TimeScale.Clear();
		PlayerID.Clear();
		AccountID.Clear();
		PartyID.Clear();
		GuildID.Clear();
		Fragment0RecordID.Clear();
		Fragment1RecordID.Clear();
		PVEReportID.Clear();
		PVPReportID.Clear();
		PlayerShotList.Clear();
		GuildList.Clear();
		CellStateList.Clear();
		FakeArenaVersion.Clear();
		FakeArenaRewardVersion.Clear();
		FakeArenaRewardTimeList.Clear();
		ActivityList.Clear();
		ActivityStatisticsList.Clear();
		ActivityStatisticsRecordList.Clear();
		ScriptActivityList.Clear();
		NoteTime1970.Clear();
		NoteList.Clear();
		PlayerCount.Clear();
		PartyCount.Clear();
		AccountCount.Clear();
		GuildCount.Clear();
		OnlineCount.Clear();
		LoginWaitCount.Clear();
		MaxLoginWaitCount.Clear();
		MaxOnlineCount.Clear();
		DayMaxOnlineCount.Clear();
		WeekMaxOnlineCount.Clear();
		MonthMaxOnlineCount.Clear();
		LoginCount.Clear();
		DayLoginCount.Clear();
		WeekLoginCount.Clear();
		MonthLoginCount.Clear();
		DayNewAccountCount.Clear();
		WeekNewAccountCount.Clear();
		MonthNewAccountCount.Clear();
		DayNewPlayerCount.Clear();
		WeekNewPlayerCount.Clear();
		MonthNewPlayerCount.Clear();
		DayNewGuildCount.Clear();
		WeekNewGuildCount.Clear();
		MonthNewGuildCount.Clear();
		QuestRecordList.Clear();
		ItemRecordList.Clear();
		PlayerLevelCountList.Clear();
		YinPiaoPaymentRecordList.Clear();
		JinPiaoPaymentRecordList.Clear();
		JinZiPaymentRecordList.Clear();
		ItemMarketRecordList.Clear();
		ItemShopRecordList.Clear();
		StatisticsList.Clear();
		RechargeList.Clear();
		BoardList.Clear();
		CDKeyList.Clear();
		GlobalGMRecordList.Clear();
		GlobalMailList.Clear();
		IPDisableList.Clear();
		AccountDisableList.Clear();
		ItemLockedList.Clear();
		AuraLockedList.Clear();
		SpaceClosedList.Clear();
		SpellClosedList.Clear();
		GameFuncClosedList.Clear();
		EntityCount.Clear();
		EntityIDCount.Clear();
		EntityPackIDCount.Clear();
		SpaceCount.Clear();
		OnlinePlayerList.Clear();
		RPCExecNameList.Clear();
		RPCExecCountList.Clear();
		MemoryCountList0.Clear();
		MemoryCountList1.Clear();
		ReceiveXPListInNPC.Clear();
		ReceiveXPListInQuest.Clear();
		ReceiveXPListInLoot.Clear();
		ReceiveXPListInActivity.Clear();
		ReceiveYinPiaoListInNPC.Clear();
		ReceiveYinPiaoListInQuest.Clear();
		ReceiveYinPiaoListInLoot.Clear();
		ReceiveYinPiaoListInActivity.Clear();
		ReceiveJinPiaoListInNPC.Clear();
		ReceiveJinPiaoListInQuest.Clear();
		ReceiveJinPiaoListInLoot.Clear();
		ReceiveJinPiaoListInActivity.Clear();
		ReceiveItemListInNPC.Clear();
		ReceiveItemListInQuest.Clear();
		ReceiveItemListInLoot.Clear();
		ReceiveItemListInActivity.Clear();
		ReceiveItemListInShop.Clear();
		ReceiveItemListInMarket.Clear();
		TradeItemListInMarket.Clear();
	}
}
