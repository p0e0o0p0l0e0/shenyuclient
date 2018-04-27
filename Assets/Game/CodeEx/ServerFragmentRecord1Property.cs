using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ServerFragmentRecord1Property
{
	public static readonly int TYPE_SIZE = 58;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public UInt32 StartNumber;//DB
	public ViString Note;//DB
	public Int64 Time;//DB
	public Int64 Time1970;//DB
	public Int32 DayNumber1970;//DB
	public Int32 NewAccount;//DB
	public Int32 NewPlayer;//DB
	public Int32 NewGuild;//DB
	public Int32 OnlineCount;//DB
	public Int32 DayLoginCount;//DB
	public Int32 WeekLoginCount;//DB
	public Int32 MonthLoginCount;//DB
	public Int32 DayNewAccountCount;//DB
	public Int32 WeekNewAccountCount;//DB
	public Int32 MonthNewAccountCount;//DB
	public Int32 DayNewPlayerCount;//DB
	public Int32 WeekNewPlayerCount;//DB
	public Int32 MonthNewPlayerCount;//DB
	public Int32 DayNewGuildCount;//DB
	public Int32 WeekNewGuildCount;//DB
	public Int32 MonthNewGuildCount;//DB
	public Int32 EntityCount;//DB
	public Int32 EntityIDCount;//DB
	public Int32 EntityPackIDCount;//DB
	public Int32 SpaceCount;//DB
	public Dictionary<UInt64, PlayerOnlineProperty> OnlinePlayerList;//DB
	public Dictionary<UInt8, CellStateProperty> CellStateList;//DB
	public List<StringProperty> RPCExecNameList;//DB
	public List<Int64Property> RPCExecCountList;//DB
	public List<MemoryUseProperty> MemoryCountList0;//DB
	public List<MemoryUseProperty> MemoryCountList1;//DB
	public Dictionary<UInt32, StatisticsValueProperty> YinPiaoPaymentRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> JinPiaoPaymentRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> JinZiPaymentRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> ItemMarketRecordList;//DB
	public Dictionary<UInt32, StatisticsValueProperty> ItemShopRecordList;//DB
	public Dictionary<UInt32, Int64Property> StatisticsList;//DB
	public Dictionary<ViString, RechargeInGameRecordProperty> RechargeList;//DB
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
		ViGameSerializer<UInt32>.Read(IS, out StartNumber);
		ViGameSerializer<ViString>.Read(IS, out Note);
		ViGameSerializer<Int64>.Read(IS, out Time);
		ViGameSerializer<Int64>.Read(IS, out Time1970);
		ViGameSerializer<Int32>.Read(IS, out DayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out NewAccount);
		ViGameSerializer<Int32>.Read(IS, out NewPlayer);
		ViGameSerializer<Int32>.Read(IS, out NewGuild);
		ViGameSerializer<Int32>.Read(IS, out OnlineCount);
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
		ViGameSerializer<Int32>.Read(IS, out EntityCount);
		ViGameSerializer<Int32>.Read(IS, out EntityIDCount);
		ViGameSerializer<Int32>.Read(IS, out EntityPackIDCount);
		ViGameSerializer<Int32>.Read(IS, out SpaceCount);
		ViGameSerializer<PlayerOnlineProperty>.Read(IS, out OnlinePlayerList);
		ViGameSerializer<CellStateProperty>.Read(IS, out CellStateList);
		ViGameSerializer<StringProperty>.Read(IS, out RPCExecNameList);
		ViGameSerializer<Int64Property>.Read(IS, out RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Read(IS, out MemoryCountList1);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out ItemShopRecordList);
		ViGameSerializer<Int64Property>.Read(IS, out StatisticsList);
		ViGameSerializer<RechargeInGameRecordProperty>.Read(IS, out RechargeList);
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
		ViGameSerializer<UInt32>.Append(OS, head + "StartNumber", StartNumber);
		ViGameSerializer<ViString>.Append(OS, head + "Note", Note);
		ViGameSerializer<Int64>.Append(OS, head + "Time", Time);
		ViGameSerializer<Int64>.Append(OS, head + "Time1970", Time1970);
		ViGameSerializer<Int32>.Append(OS, head + "DayNumber1970", DayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "NewAccount", NewAccount);
		ViGameSerializer<Int32>.Append(OS, head + "NewPlayer", NewPlayer);
		ViGameSerializer<Int32>.Append(OS, head + "NewGuild", NewGuild);
		ViGameSerializer<Int32>.Append(OS, head + "OnlineCount", OnlineCount);
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
		ViGameSerializer<Int32>.Append(OS, head + "EntityCount", EntityCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityIDCount", EntityIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "EntityPackIDCount", EntityPackIDCount);
		ViGameSerializer<Int32>.Append(OS, head + "SpaceCount", SpaceCount);
		ViGameSerializer<PlayerOnlineProperty>.Append(OS, head + "OnlinePlayerList", OnlinePlayerList);
		ViGameSerializer<CellStateProperty>.Append(OS, head + "CellStateList", CellStateList);
		ViGameSerializer<StringProperty>.Append(OS, head + "RPCExecNameList", RPCExecNameList);
		ViGameSerializer<Int64Property>.Append(OS, head + "RPCExecCountList", RPCExecCountList);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + "MemoryCountList0", MemoryCountList0);
		ViGameSerializer<MemoryUseProperty>.Append(OS, head + "MemoryCountList1", MemoryCountList1);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "YinPiaoPaymentRecordList", YinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "JinPiaoPaymentRecordList", JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "JinZiPaymentRecordList", JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "ItemMarketRecordList", ItemMarketRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "ItemShopRecordList", ItemShopRecordList);
		ViGameSerializer<Int64Property>.Append(OS, head + "StatisticsList", StatisticsList);
		ViGameSerializer<RechargeInGameRecordProperty>.Append(OS, head + "RechargeList", RechargeList);
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

public class ServerFragmentRecord1ReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 58;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt32 StartNumber = new ViReceiveDataUInt32();//DB
	private ViReceiveDataString Note = new ViReceiveDataString();//DB
	private ViReceiveDataInt64 Time = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();//DB
	private ViReceiveDataInt32 DayNumber1970 = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 NewAccount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 NewPlayer = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 NewGuild = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 OnlineCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayLoginCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekLoginCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthLoginCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayNewAccountCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekNewAccountCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthNewAccountCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayNewPlayerCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekNewPlayerCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthNewPlayerCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 DayNewGuildCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 WeekNewGuildCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 MonthNewGuildCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityIDCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 EntityPackIDCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 SpaceCount = new ViReceiveDataInt32();//DB
	private ViReceiveDataDictionary<UInt64, ReceiveDataPlayerOnlineProperty, PlayerOnlineProperty> OnlinePlayerList = new ViReceiveDataDictionary<UInt64, ReceiveDataPlayerOnlineProperty, PlayerOnlineProperty>();//DB
	private ViReceiveDataDictionary<UInt8, ReceiveDataCellStateProperty, CellStateProperty> CellStateList = new ViReceiveDataDictionary<UInt8, ReceiveDataCellStateProperty, CellStateProperty>();//DB
	private ViReceiveDataArray<ReceiveDataStringProperty, StringProperty> RPCExecNameList = new ViReceiveDataArray<ReceiveDataStringProperty, StringProperty>();//DB
	private ViReceiveDataArray<ReceiveDataInt64Property, Int64Property> RPCExecCountList = new ViReceiveDataArray<ReceiveDataInt64Property, Int64Property>();//DB
	private ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty> MemoryCountList0 = new ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty>();//DB
	private ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty> MemoryCountList1 = new ViReceiveDataArray<ReceiveDataMemoryUseProperty, MemoryUseProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> YinPiaoPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> JinPiaoPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> JinZiPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> ItemMarketRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> ItemShopRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property> StatisticsList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property>();//DB
	private ViReceiveDataDictionary<ViString, ReceiveDataRechargeInGameRecordProperty, RechargeInGameRecordProperty> RechargeList = new ViReceiveDataDictionary<ViString, ReceiveDataRechargeInGameRecordProperty, RechargeInGameRecordProperty>();//DB
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
	public ServerFragmentRecord1ReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		StartNumber.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Note.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Time1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NewAccount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NewPlayer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NewGuild.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlineCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthLoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewAccountCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewPlayerCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		WeekNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MonthNewGuildCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityIDCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		EntityPackIDCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		SpaceCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlinePlayerList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CellStateList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RPCExecNameList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RPCExecCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MemoryCountList0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MemoryCountList1.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinPiaoPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemMarketRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemShopRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		StatisticsList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		RechargeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		StartNumber.Start(channelMask, IS, entity);
		Note.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		DayNumber1970.Start(channelMask, IS, entity);
		NewAccount.Start(channelMask, IS, entity);
		NewPlayer.Start(channelMask, IS, entity);
		NewGuild.Start(channelMask, IS, entity);
		OnlineCount.Start(channelMask, IS, entity);
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
		EntityCount.Start(channelMask, IS, entity);
		EntityIDCount.Start(channelMask, IS, entity);
		EntityPackIDCount.Start(channelMask, IS, entity);
		SpaceCount.Start(channelMask, IS, entity);
		OnlinePlayerList.Start(channelMask, IS, entity);
		CellStateList.Start(channelMask, IS, entity);
		RPCExecNameList.Start(channelMask, IS, entity);
		RPCExecCountList.Start(channelMask, IS, entity);
		MemoryCountList0.Start(channelMask, IS, entity);
		MemoryCountList1.Start(channelMask, IS, entity);
		YinPiaoPaymentRecordList.Start(channelMask, IS, entity);
		JinPiaoPaymentRecordList.Start(channelMask, IS, entity);
		JinZiPaymentRecordList.Start(channelMask, IS, entity);
		ItemMarketRecordList.Start(channelMask, IS, entity);
		ItemShopRecordList.Start(channelMask, IS, entity);
		StatisticsList.Start(channelMask, IS, entity);
		RechargeList.Start(channelMask, IS, entity);
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
		StartNumber.End(entity);
		Note.End(entity);
		Time.End(entity);
		Time1970.End(entity);
		DayNumber1970.End(entity);
		NewAccount.End(entity);
		NewPlayer.End(entity);
		NewGuild.End(entity);
		OnlineCount.End(entity);
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
		EntityCount.End(entity);
		EntityIDCount.End(entity);
		EntityPackIDCount.End(entity);
		SpaceCount.End(entity);
		OnlinePlayerList.End(entity);
		CellStateList.End(entity);
		RPCExecNameList.End(entity);
		RPCExecCountList.End(entity);
		MemoryCountList0.End(entity);
		MemoryCountList1.End(entity);
		YinPiaoPaymentRecordList.End(entity);
		JinPiaoPaymentRecordList.End(entity);
		JinZiPaymentRecordList.End(entity);
		ItemMarketRecordList.End(entity);
		ItemShopRecordList.End(entity);
		StatisticsList.End(entity);
		RechargeList.End(entity);
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
		StartNumber.Clear();
		Note.Clear();
		Time.Clear();
		Time1970.Clear();
		DayNumber1970.Clear();
		NewAccount.Clear();
		NewPlayer.Clear();
		NewGuild.Clear();
		OnlineCount.Clear();
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
		EntityCount.Clear();
		EntityIDCount.Clear();
		EntityPackIDCount.Clear();
		SpaceCount.Clear();
		OnlinePlayerList.Clear();
		CellStateList.Clear();
		RPCExecNameList.Clear();
		RPCExecCountList.Clear();
		MemoryCountList0.Clear();
		MemoryCountList1.Clear();
		YinPiaoPaymentRecordList.Clear();
		JinPiaoPaymentRecordList.Clear();
		JinZiPaymentRecordList.Clear();
		ItemMarketRecordList.Clear();
		ItemShopRecordList.Clear();
		StatisticsList.Clear();
		RechargeList.Clear();
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
