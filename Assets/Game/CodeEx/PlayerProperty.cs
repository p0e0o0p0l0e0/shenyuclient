using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerProperty
{
	public static readonly int TYPE_SIZE = 154;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public UInt64 OnlineVersion;//DB
	public Int16 MergeCount;//DB
	public ViString NameAlias;//OWN_CLIENT+CELL+DB
	public Int16 NameAliasUpdateCount;//OWN_CLIENT+DB
	public UInt8 Photo;//OWN_CLIENT+CELL+DB
	public HashSet<UInt32> PhotoList;//OWN_CLIENT+DB
	public UInt8 Gender;//OWN_CLIENT+CELL+DB
	public Int16 Level;//OWN_CLIENT+CELL+DB
	public Int64 XP;//OWN_CLIENT+CELL+DB
	public Int32 HeroFightPowerSum;//
	public UInt32 StateMask;//OWN_CLIENT+CELL
	public EntityServerProperty Server;//DB
	public ViString GUName;//OWN_CLIENT+CELL
	public UInt64 AccountID;//DB
	public ViString AccountName;//DB
	public UInt8 GMLevel;//OWN_CLIENT+CELL+DB
	public ViString SourceTag;//DB
	public ViString SourceDate;//DB
	public ViString CDKey;//DB
	public ViString CDKeyTag;//DB
	public ViString IP;//DB
	public ViString MacAdress;//DB
	public Int64 ActiveTime;//OWN_CLIENT
	public Int64 CreateTime;//OWN_CLIENT+DB
	public Int64 CreateTime1970;//OWN_CLIENT+DB
	public Int64 LoginCount;//OWN_CLIENT+DB
	public Int64 LoginTime;//OWN_CLIENT+DB
	public Int64 AccumulateOnlineDuration;//OWN_CLIENT+DB
	public Int64 LastDayOnlineDuration;//OWN_CLIENT+DB
	public Int64 LastOnlineTime1970;//OWN_CLIENT+DB
	public Int32 CreateDayNumber1970;//DB
	public Int32 CurrentDayNumber1970;//DB
	public Int32 CurrentDayNumber1970InComponent;//DB
	public Int16 ContinuousLoginDayCount;//OWN_CLIENT+DB
	public Int16 ContinuousLoginDayMaxCount;//OWN_CLIENT+DB
	public Int16 AccumulateLoginDayCount;//OWN_CLIENT+DB
	public UInt8 ClientState;//OWN_CLIENT
	public ViString CellServer;//OWN_CLIENT
	public ViString BaseServer;//OWN_CLIENT
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
	public Dictionary<UInt32, UInt8Property> PaymentStateList;//OWN_CLIENT+DB
	public Dictionary<UInt32, StatisticsValueProperty> JinPiaoPaymentRecordList;//OWN_CLIENT+DB
	public Dictionary<UInt32, StatisticsValueProperty> JinZiPaymentRecordList;//OWN_CLIENT+DB
	public Dictionary<UInt32, StatisticsValueProperty> YinPiaoPaymentRecordList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int64Property> StatisticsList;//OWN_CLIENT+DB
	public Dictionary<ViString, Int32Property> BackupList;//DB
	public List<MailProperty> MailCacheList;//DB
	public HashSet<UInt32> FuncOpenList;//OWN_CLIENT+CELL+DB
	public HashSet<UInt32> FuncDynamicActiveList;//OWN_CLIENT+CELL
	public HashSet<UInt32> FuncDynamicDeactiveist;//OWN_CLIENT+CELL
	public List<ShortCutProperty> ShortCutList;//OWN_CLIENT+DB
	public ClientSettingForPlayerProperty ClientSetting;//OWN_CLIENT+DB
	public ViString ChatChannelName;//OWN_CLIENT+DB
	public UInt32 ChatChannelMask;//OWN_CLIENT+DB
	public Dictionary<ViString, Int64Property> VisualScriptValueList;//OWN_CLIENT
	public Dictionary<ViString, Int64Property> PresistentScriptValueList;//OWN_CLIENT+DB
	public Dictionary<UInt32, ProgressProperty> ScriptProgressList;//OWN_CLIENT
	public Dictionary<UInt32, TimeProperty> CoolingDownList;//OWN_CLIENT+DB
	public HashSet<UInt32> OnceLootList;//DB
	public Dictionary<UInt32, ScriptDurationProperty> ScriptDurationList;//OWN_CLIENT+CELL+DB
	public Int64 ChatInWorldEndTime1970;//OWN_CLIENT+DB
	public Int64 ChatInSpaceEndTime1970;//OWN_CLIENT+DB
	public Int64 ChatEndTime1970;//OWN_CLIENT+DB
	public Int16 ChatOfflineReserveCount;//DB
	public Dictionary<UInt32, ActivityEnterProperty> ActivityEnterList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int64Property> ScoreList;//OWN_CLIENT+DB
	public Dictionary<UInt32, LoopCountProperty> ScoreMarketItemBuyCountList;//OWN_CLIENT+DB
	public Dictionary<UInt32, NotifyProperty> NotifyList;//OWN_CLIENT+DB
	public HashSet<UInt32> HintList;//OWN_CLIENT+DB
	public ViString GuildName;//OWN_CLIENT+DB
	public Dictionary<UInt32, GuildActivityEnterProperty> GuildActivityEnterList;//OWN_CLIENT+DB
	public Int64 PartyID;//OWN_CLIENT+DB
	public List<PartyInvitorProperty> PartyInviteList;//OWN_CLIENT
	public List<PartyPartnerRecordProperty> PartyPartnerRecordList;//OWN_CLIENT+DB
	public List<PartyDetailLite> RequestPartyList;//OWN_CLIENT
	public UInt8 CellState;//OWN_CLIENT
	public UInt8 SpaceState;//OWN_CLIENT
	public UInt8 SpaceChangable;//OWN_CLIENT+CELL
	public UInt32 LastSmallSpace;//OWN_CLIENT+DB
	public Dictionary<UInt32, SpaceRecordProperty> SpaceRecordList;//OWN_CLIENT+DB
	public UInt32 LastBigSpace;//OWN_CLIENT+DB
	public ViVector3 LastBigSpacePosition;//OWN_CLIENT+DB
	public Int64 YinPiao;//OWN_CLIENT+DB
	public Int64 JinPiao;//OWN_CLIENT+DB
	public Int64 JinZiInAccount;//OWN_CLIENT+DB
	public Int64 JinZiTotalTransfer;//OWN_CLIENT+DB
	public Int64 JinZiDayTransfer;//OWN_CLIENT+DB
	public Int64 YinPiaoAccumulate;//OWN_CLIENT+DB
	public Int64 JinPiaoAccumulate;//OWN_CLIENT+DB
	public Int64 JinZiAccumulate;//OWN_CLIENT+DB
	public List<MoneyModRecordProperty> YinPiaoModRecordList;//OWN_CLIENT+DB
	public List<MoneyModRecordProperty> JinPiaoModRecordList;//OWN_CLIENT+DB
	public List<MoneyModRecordProperty> JinZiModRecordList;//OWN_CLIENT+DB
	public Int16 YinPiaoDayBuyCount;//OWN_CLIENT+DB
	public Int64 YinPiaoAccumulateBuyCount;//OWN_CLIENT+DB
	public Int64 QuestAdventureXP;//OWN_CLIENT+DB
	public Int64 QuestAdventureCoin;//OWN_CLIENT+DB
	public Int16 Power;//OWN_CLIENT+DB
	public Int16 PowerSup;//OWN_CLIENT+DB
	public Int64 PowerRecoverTime;//OWN_CLIENT+DB
	public Int16 PowerDayBuyCount;//OWN_CLIENT+DB
	public Int64 PowerAccumulateBuyCount;//OWN_CLIENT+DB
	public Int16 BagSize;//OWN_CLIENT+DB
	public List<ItemProperty> Inventory;//CELL+OWN_CLIENT+DB
	public List<ItemProperty> Equipments;//CELL+OWN_CLIENT+DB
	public List<ItemSaledProperty> ItemSaledList;//OWN_CLIENT+DB
	public List<PackageSlotProperty> PackageSlotPropertyList;//OWN_CLIENT+DB
	public List<PackageSlotProperty> PackageSlotSaledList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int32Property> ItemUseCountList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int32Property> ItemExchageCountList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int32Property> DailyItemBuyCountList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Int32Property> DailyItemReceiveCountList;//OWN_CLIENT+DB
	public List<ItemDelRecordProperty> ItemDelRecordList;//OWN_CLIENT+DB
	public List<ItemDelCountProperty> ItemDelCountList;//OWN_CLIENT+DB
	public Dictionary<UInt32, Time1970Property> ItemLicenceCDList;//DB
	public List<ItemLicenceRecordProperty> ItemLicenceRecordList;//OWN_CLIENT+DB
	public Dictionary<UInt32, LoopCountProperty> MarketItemBuyCountList;//OWN_CLIENT+DB
	public Dictionary<UInt32, GoalProperty> GoalList;//OWN_CLIENT+DB
	public HashSet<UInt32> GoalRewardList;//OWN_CLIENT+DB
	public HashSet<UInt32> GoalCompletedList;//OWN_CLIENT+DB
	public Dictionary<UInt32, ScoreRankStasticsProperty> ScoreRankStasticsList;//OWN_CLIENT+CELL+DB
	public Dictionary<UInt32, HeroProperty> HeroList;//CELL+OWN_CLIENT+DB
	public List<HeroSpellProperty> StudySpellList;//OWN_CLIENT+CELL+DB
	public Dictionary<UInt32, GameUnitIndexProperty> HeroPropertyList;//OWN_CLIENT
	public UInt32 SpaceWorkingHero;//OWN_CLIENT+DB
	public Int16 DayGiftReserveCount;//OWN_CLIENT+DB
	public Int16 DayGiftTakedAccumulateCount;//OWN_CLIENT+DB
	public HashSet<UInt32> AccumulateLoginRewardTakedList;//OWN_CLIENT+DB
	public HashSet<UInt32> AccumulateLoginInActivityRewardTakedList;//OWN_CLIENT+DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<UInt64>.Read(IS, out OnlineVersion);
		ViGameSerializer<Int16>.Read(IS, out MergeCount);
		ViGameSerializer<ViString>.Read(IS, out NameAlias);
		ViGameSerializer<Int16>.Read(IS, out NameAliasUpdateCount);
		ViGameSerializer<UInt8>.Read(IS, out Photo);
		ViGameSerializer<UInt32>.Read(IS, out PhotoList);
		ViGameSerializer<UInt8>.Read(IS, out Gender);
		ViGameSerializer<Int16>.Read(IS, out Level);
		ViGameSerializer<Int64>.Read(IS, out XP);
		ViGameSerializer<Int32>.Read(IS, out HeroFightPowerSum);
		ViGameSerializer<UInt32>.Read(IS, out StateMask);
		ViGameSerializer<EntityServerProperty>.Read(IS, out Server);
		ViGameSerializer<ViString>.Read(IS, out GUName);
		ViGameSerializer<UInt64>.Read(IS, out AccountID);
		ViGameSerializer<ViString>.Read(IS, out AccountName);
		ViGameSerializer<UInt8>.Read(IS, out GMLevel);
		ViGameSerializer<ViString>.Read(IS, out SourceTag);
		ViGameSerializer<ViString>.Read(IS, out SourceDate);
		ViGameSerializer<ViString>.Read(IS, out CDKey);
		ViGameSerializer<ViString>.Read(IS, out CDKeyTag);
		ViGameSerializer<ViString>.Read(IS, out IP);
		ViGameSerializer<ViString>.Read(IS, out MacAdress);
		ViGameSerializer<Int64>.Read(IS, out ActiveTime);
		ViGameSerializer<Int64>.Read(IS, out CreateTime);
		ViGameSerializer<Int64>.Read(IS, out CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, out LoginCount);
		ViGameSerializer<Int64>.Read(IS, out LoginTime);
		ViGameSerializer<Int64>.Read(IS, out AccumulateOnlineDuration);
		ViGameSerializer<Int64>.Read(IS, out LastDayOnlineDuration);
		ViGameSerializer<Int64>.Read(IS, out LastOnlineTime1970);
		ViGameSerializer<Int32>.Read(IS, out CreateDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out CurrentDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out CurrentDayNumber1970InComponent);
		ViGameSerializer<Int16>.Read(IS, out ContinuousLoginDayCount);
		ViGameSerializer<Int16>.Read(IS, out ContinuousLoginDayMaxCount);
		ViGameSerializer<Int16>.Read(IS, out AccumulateLoginDayCount);
		ViGameSerializer<UInt8>.Read(IS, out ClientState);
		ViGameSerializer<ViString>.Read(IS, out CellServer);
		ViGameSerializer<ViString>.Read(IS, out BaseServer);
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
		ViGameSerializer<UInt8Property>.Read(IS, out PaymentStateList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Read(IS, out YinPiaoPaymentRecordList);
		ViGameSerializer<Int64Property>.Read(IS, out StatisticsList);
		ViGameSerializer<Int32Property>.Read(IS, out BackupList);
		ViGameSerializer<MailProperty>.Read(IS, out MailCacheList);
		ViGameSerializer<UInt32>.Read(IS, out FuncOpenList);
		ViGameSerializer<UInt32>.Read(IS, out FuncDynamicActiveList);
		ViGameSerializer<UInt32>.Read(IS, out FuncDynamicDeactiveist);
		ViGameSerializer<ShortCutProperty>.Read(IS, out ShortCutList);
		ViGameSerializer<ClientSettingForPlayerProperty>.Read(IS, out ClientSetting);
		ViGameSerializer<ViString>.Read(IS, out ChatChannelName);
		ViGameSerializer<UInt32>.Read(IS, out ChatChannelMask);
		ViGameSerializer<Int64Property>.Read(IS, out VisualScriptValueList);
		ViGameSerializer<Int64Property>.Read(IS, out PresistentScriptValueList);
		ViGameSerializer<ProgressProperty>.Read(IS, out ScriptProgressList);
		ViGameSerializer<TimeProperty>.Read(IS, out CoolingDownList);
		ViGameSerializer<UInt32>.Read(IS, out OnceLootList);
		ViGameSerializer<ScriptDurationProperty>.Read(IS, out ScriptDurationList);
		ViGameSerializer<Int64>.Read(IS, out ChatInWorldEndTime1970);
		ViGameSerializer<Int64>.Read(IS, out ChatInSpaceEndTime1970);
		ViGameSerializer<Int64>.Read(IS, out ChatEndTime1970);
		ViGameSerializer<Int16>.Read(IS, out ChatOfflineReserveCount);
		ViGameSerializer<ActivityEnterProperty>.Read(IS, out ActivityEnterList);
		ViGameSerializer<Int64Property>.Read(IS, out ScoreList);
		ViGameSerializer<LoopCountProperty>.Read(IS, out ScoreMarketItemBuyCountList);
		ViGameSerializer<NotifyProperty>.Read(IS, out NotifyList);
		ViGameSerializer<UInt32>.Read(IS, out HintList);
		ViGameSerializer<ViString>.Read(IS, out GuildName);
		ViGameSerializer<GuildActivityEnterProperty>.Read(IS, out GuildActivityEnterList);
		ViGameSerializer<Int64>.Read(IS, out PartyID);
		ViGameSerializer<PartyInvitorProperty>.Read(IS, out PartyInviteList);
		ViGameSerializer<PartyPartnerRecordProperty>.Read(IS, out PartyPartnerRecordList);
		ViGameSerializer<PartyDetailLite>.Read(IS, out RequestPartyList);
		ViGameSerializer<UInt8>.Read(IS, out CellState);
		ViGameSerializer<UInt8>.Read(IS, out SpaceState);
		ViGameSerializer<UInt8>.Read(IS, out SpaceChangable);
		ViGameSerializer<UInt32>.Read(IS, out LastSmallSpace);
		ViGameSerializer<SpaceRecordProperty>.Read(IS, out SpaceRecordList);
		ViGameSerializer<UInt32>.Read(IS, out LastBigSpace);
		ViGameSerializer<ViVector3>.Read(IS, out LastBigSpacePosition);
		ViGameSerializer<Int64>.Read(IS, out YinPiao);
		ViGameSerializer<Int64>.Read(IS, out JinPiao);
		ViGameSerializer<Int64>.Read(IS, out JinZiInAccount);
		ViGameSerializer<Int64>.Read(IS, out JinZiTotalTransfer);
		ViGameSerializer<Int64>.Read(IS, out JinZiDayTransfer);
		ViGameSerializer<Int64>.Read(IS, out YinPiaoAccumulate);
		ViGameSerializer<Int64>.Read(IS, out JinPiaoAccumulate);
		ViGameSerializer<Int64>.Read(IS, out JinZiAccumulate);
		ViGameSerializer<MoneyModRecordProperty>.Read(IS, out YinPiaoModRecordList);
		ViGameSerializer<MoneyModRecordProperty>.Read(IS, out JinPiaoModRecordList);
		ViGameSerializer<MoneyModRecordProperty>.Read(IS, out JinZiModRecordList);
		ViGameSerializer<Int16>.Read(IS, out YinPiaoDayBuyCount);
		ViGameSerializer<Int64>.Read(IS, out YinPiaoAccumulateBuyCount);
		ViGameSerializer<Int64>.Read(IS, out QuestAdventureXP);
		ViGameSerializer<Int64>.Read(IS, out QuestAdventureCoin);
		ViGameSerializer<Int16>.Read(IS, out Power);
		ViGameSerializer<Int16>.Read(IS, out PowerSup);
		ViGameSerializer<Int64>.Read(IS, out PowerRecoverTime);
		ViGameSerializer<Int16>.Read(IS, out PowerDayBuyCount);
		ViGameSerializer<Int64>.Read(IS, out PowerAccumulateBuyCount);
		ViGameSerializer<Int16>.Read(IS, out BagSize);
		ViGameSerializer<ItemProperty>.Read(IS, out Inventory);
		ViGameSerializer<ItemProperty>.Read(IS, out Equipments);
		ViGameSerializer<ItemSaledProperty>.Read(IS, out ItemSaledList);
		ViGameSerializer<PackageSlotProperty>.Read(IS, out PackageSlotPropertyList);
		ViGameSerializer<PackageSlotProperty>.Read(IS, out PackageSlotSaledList);
		ViGameSerializer<Int32Property>.Read(IS, out ItemUseCountList);
		ViGameSerializer<Int32Property>.Read(IS, out ItemExchageCountList);
		ViGameSerializer<Int32Property>.Read(IS, out DailyItemBuyCountList);
		ViGameSerializer<Int32Property>.Read(IS, out DailyItemReceiveCountList);
		ViGameSerializer<ItemDelRecordProperty>.Read(IS, out ItemDelRecordList);
		ViGameSerializer<ItemDelCountProperty>.Read(IS, out ItemDelCountList);
		ViGameSerializer<Time1970Property>.Read(IS, out ItemLicenceCDList);
		ViGameSerializer<ItemLicenceRecordProperty>.Read(IS, out ItemLicenceRecordList);
		ViGameSerializer<LoopCountProperty>.Read(IS, out MarketItemBuyCountList);
		ViGameSerializer<GoalProperty>.Read(IS, out GoalList);
		ViGameSerializer<UInt32>.Read(IS, out GoalRewardList);
		ViGameSerializer<UInt32>.Read(IS, out GoalCompletedList);
		ViGameSerializer<ScoreRankStasticsProperty>.Read(IS, out ScoreRankStasticsList);
		ViGameSerializer<HeroProperty>.Read(IS, out HeroList);
		ViGameSerializer<HeroSpellProperty>.Read(IS, out StudySpellList);
		ViGameSerializer<GameUnitIndexProperty>.Read(IS, out HeroPropertyList);
		ViGameSerializer<UInt32>.Read(IS, out SpaceWorkingHero);
		ViGameSerializer<Int16>.Read(IS, out DayGiftReserveCount);
		ViGameSerializer<Int16>.Read(IS, out DayGiftTakedAccumulateCount);
		ViGameSerializer<UInt32>.Read(IS, out AccumulateLoginRewardTakedList);
		ViGameSerializer<UInt32>.Read(IS, out AccumulateLoginInActivityRewardTakedList);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<UInt64>.Append(OS, head + "OnlineVersion", OnlineVersion);
		ViGameSerializer<Int16>.Append(OS, head + "MergeCount", MergeCount);
		ViGameSerializer<ViString>.Append(OS, head + "NameAlias", NameAlias);
		ViGameSerializer<Int16>.Append(OS, head + "NameAliasUpdateCount", NameAliasUpdateCount);
		ViGameSerializer<UInt8>.Append(OS, head + "Photo", Photo);
		ViGameSerializer<UInt32>.Append(OS, head + "PhotoList", PhotoList);
		ViGameSerializer<UInt8>.Append(OS, head + "Gender", Gender);
		ViGameSerializer<Int16>.Append(OS, head + "Level", Level);
		ViGameSerializer<Int64>.Append(OS, head + "XP", XP);
		ViGameSerializer<Int32>.Append(OS, head + "HeroFightPowerSum", HeroFightPowerSum);
		ViGameSerializer<UInt32>.Append(OS, head + "StateMask", StateMask);
		ViGameSerializer<EntityServerProperty>.Append(OS, head + "Server", Server);
		ViGameSerializer<ViString>.Append(OS, head + "GUName", GUName);
		ViGameSerializer<UInt64>.Append(OS, head + "AccountID", AccountID);
		ViGameSerializer<ViString>.Append(OS, head + "AccountName", AccountName);
		ViGameSerializer<UInt8>.Append(OS, head + "GMLevel", GMLevel);
		ViGameSerializer<ViString>.Append(OS, head + "SourceTag", SourceTag);
		ViGameSerializer<ViString>.Append(OS, head + "SourceDate", SourceDate);
		ViGameSerializer<ViString>.Append(OS, head + "CDKey", CDKey);
		ViGameSerializer<ViString>.Append(OS, head + "CDKeyTag", CDKeyTag);
		ViGameSerializer<ViString>.Append(OS, head + "IP", IP);
		ViGameSerializer<ViString>.Append(OS, head + "MacAdress", MacAdress);
		ViGameSerializer<Int64>.Append(OS, head + "ActiveTime", ActiveTime);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime", CreateTime);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime1970", CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, head + "LoginCount", LoginCount);
		ViGameSerializer<Int64>.Append(OS, head + "LoginTime", LoginTime);
		ViGameSerializer<Int64>.Append(OS, head + "AccumulateOnlineDuration", AccumulateOnlineDuration);
		ViGameSerializer<Int64>.Append(OS, head + "LastDayOnlineDuration", LastDayOnlineDuration);
		ViGameSerializer<Int64>.Append(OS, head + "LastOnlineTime1970", LastOnlineTime1970);
		ViGameSerializer<Int32>.Append(OS, head + "CreateDayNumber1970", CreateDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "CurrentDayNumber1970", CurrentDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "CurrentDayNumber1970InComponent", CurrentDayNumber1970InComponent);
		ViGameSerializer<Int16>.Append(OS, head + "ContinuousLoginDayCount", ContinuousLoginDayCount);
		ViGameSerializer<Int16>.Append(OS, head + "ContinuousLoginDayMaxCount", ContinuousLoginDayMaxCount);
		ViGameSerializer<Int16>.Append(OS, head + "AccumulateLoginDayCount", AccumulateLoginDayCount);
		ViGameSerializer<UInt8>.Append(OS, head + "ClientState", ClientState);
		ViGameSerializer<ViString>.Append(OS, head + "CellServer", CellServer);
		ViGameSerializer<ViString>.Append(OS, head + "BaseServer", BaseServer);
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
		ViGameSerializer<UInt8Property>.Append(OS, head + "PaymentStateList", PaymentStateList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "JinPiaoPaymentRecordList", JinPiaoPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "JinZiPaymentRecordList", JinZiPaymentRecordList);
		ViGameSerializer<StatisticsValueProperty>.Append(OS, head + "YinPiaoPaymentRecordList", YinPiaoPaymentRecordList);
		ViGameSerializer<Int64Property>.Append(OS, head + "StatisticsList", StatisticsList);
		ViGameSerializer<Int32Property>.Append(OS, head + "BackupList", BackupList);
		ViGameSerializer<MailProperty>.Append(OS, head + "MailCacheList", MailCacheList);
		ViGameSerializer<UInt32>.Append(OS, head + "FuncOpenList", FuncOpenList);
		ViGameSerializer<UInt32>.Append(OS, head + "FuncDynamicActiveList", FuncDynamicActiveList);
		ViGameSerializer<UInt32>.Append(OS, head + "FuncDynamicDeactiveist", FuncDynamicDeactiveist);
		ViGameSerializer<ShortCutProperty>.Append(OS, head + "ShortCutList", ShortCutList);
		ViGameSerializer<ClientSettingForPlayerProperty>.Append(OS, head + "ClientSetting", ClientSetting);
		ViGameSerializer<ViString>.Append(OS, head + "ChatChannelName", ChatChannelName);
		ViGameSerializer<UInt32>.Append(OS, head + "ChatChannelMask", ChatChannelMask);
		ViGameSerializer<Int64Property>.Append(OS, head + "VisualScriptValueList", VisualScriptValueList);
		ViGameSerializer<Int64Property>.Append(OS, head + "PresistentScriptValueList", PresistentScriptValueList);
		ViGameSerializer<ProgressProperty>.Append(OS, head + "ScriptProgressList", ScriptProgressList);
		ViGameSerializer<TimeProperty>.Append(OS, head + "CoolingDownList", CoolingDownList);
		ViGameSerializer<UInt32>.Append(OS, head + "OnceLootList", OnceLootList);
		ViGameSerializer<ScriptDurationProperty>.Append(OS, head + "ScriptDurationList", ScriptDurationList);
		ViGameSerializer<Int64>.Append(OS, head + "ChatInWorldEndTime1970", ChatInWorldEndTime1970);
		ViGameSerializer<Int64>.Append(OS, head + "ChatInSpaceEndTime1970", ChatInSpaceEndTime1970);
		ViGameSerializer<Int64>.Append(OS, head + "ChatEndTime1970", ChatEndTime1970);
		ViGameSerializer<Int16>.Append(OS, head + "ChatOfflineReserveCount", ChatOfflineReserveCount);
		ViGameSerializer<ActivityEnterProperty>.Append(OS, head + "ActivityEnterList", ActivityEnterList);
		ViGameSerializer<Int64Property>.Append(OS, head + "ScoreList", ScoreList);
		ViGameSerializer<LoopCountProperty>.Append(OS, head + "ScoreMarketItemBuyCountList", ScoreMarketItemBuyCountList);
		ViGameSerializer<NotifyProperty>.Append(OS, head + "NotifyList", NotifyList);
		ViGameSerializer<UInt32>.Append(OS, head + "HintList", HintList);
		ViGameSerializer<ViString>.Append(OS, head + "GuildName", GuildName);
		ViGameSerializer<GuildActivityEnterProperty>.Append(OS, head + "GuildActivityEnterList", GuildActivityEnterList);
		ViGameSerializer<Int64>.Append(OS, head + "PartyID", PartyID);
		ViGameSerializer<PartyInvitorProperty>.Append(OS, head + "PartyInviteList", PartyInviteList);
		ViGameSerializer<PartyPartnerRecordProperty>.Append(OS, head + "PartyPartnerRecordList", PartyPartnerRecordList);
		ViGameSerializer<PartyDetailLite>.Append(OS, head + "RequestPartyList", RequestPartyList);
		ViGameSerializer<UInt8>.Append(OS, head + "CellState", CellState);
		ViGameSerializer<UInt8>.Append(OS, head + "SpaceState", SpaceState);
		ViGameSerializer<UInt8>.Append(OS, head + "SpaceChangable", SpaceChangable);
		ViGameSerializer<UInt32>.Append(OS, head + "LastSmallSpace", LastSmallSpace);
		ViGameSerializer<SpaceRecordProperty>.Append(OS, head + "SpaceRecordList", SpaceRecordList);
		ViGameSerializer<UInt32>.Append(OS, head + "LastBigSpace", LastBigSpace);
		ViGameSerializer<ViVector3>.Append(OS, head + "LastBigSpacePosition", LastBigSpacePosition);
		ViGameSerializer<Int64>.Append(OS, head + "YinPiao", YinPiao);
		ViGameSerializer<Int64>.Append(OS, head + "JinPiao", JinPiao);
		ViGameSerializer<Int64>.Append(OS, head + "JinZiInAccount", JinZiInAccount);
		ViGameSerializer<Int64>.Append(OS, head + "JinZiTotalTransfer", JinZiTotalTransfer);
		ViGameSerializer<Int64>.Append(OS, head + "JinZiDayTransfer", JinZiDayTransfer);
		ViGameSerializer<Int64>.Append(OS, head + "YinPiaoAccumulate", YinPiaoAccumulate);
		ViGameSerializer<Int64>.Append(OS, head + "JinPiaoAccumulate", JinPiaoAccumulate);
		ViGameSerializer<Int64>.Append(OS, head + "JinZiAccumulate", JinZiAccumulate);
		ViGameSerializer<MoneyModRecordProperty>.Append(OS, head + "YinPiaoModRecordList", YinPiaoModRecordList);
		ViGameSerializer<MoneyModRecordProperty>.Append(OS, head + "JinPiaoModRecordList", JinPiaoModRecordList);
		ViGameSerializer<MoneyModRecordProperty>.Append(OS, head + "JinZiModRecordList", JinZiModRecordList);
		ViGameSerializer<Int16>.Append(OS, head + "YinPiaoDayBuyCount", YinPiaoDayBuyCount);
		ViGameSerializer<Int64>.Append(OS, head + "YinPiaoAccumulateBuyCount", YinPiaoAccumulateBuyCount);
		ViGameSerializer<Int64>.Append(OS, head + "QuestAdventureXP", QuestAdventureXP);
		ViGameSerializer<Int64>.Append(OS, head + "QuestAdventureCoin", QuestAdventureCoin);
		ViGameSerializer<Int16>.Append(OS, head + "Power", Power);
		ViGameSerializer<Int16>.Append(OS, head + "PowerSup", PowerSup);
		ViGameSerializer<Int64>.Append(OS, head + "PowerRecoverTime", PowerRecoverTime);
		ViGameSerializer<Int16>.Append(OS, head + "PowerDayBuyCount", PowerDayBuyCount);
		ViGameSerializer<Int64>.Append(OS, head + "PowerAccumulateBuyCount", PowerAccumulateBuyCount);
		ViGameSerializer<Int16>.Append(OS, head + "BagSize", BagSize);
		ViGameSerializer<ItemProperty>.Append(OS, head + "Inventory", Inventory);
		ViGameSerializer<ItemProperty>.Append(OS, head + "Equipments", Equipments);
		ViGameSerializer<ItemSaledProperty>.Append(OS, head + "ItemSaledList", ItemSaledList);
		ViGameSerializer<PackageSlotProperty>.Append(OS, head + "PackageSlotPropertyList", PackageSlotPropertyList);
		ViGameSerializer<PackageSlotProperty>.Append(OS, head + "PackageSlotSaledList", PackageSlotSaledList);
		ViGameSerializer<Int32Property>.Append(OS, head + "ItemUseCountList", ItemUseCountList);
		ViGameSerializer<Int32Property>.Append(OS, head + "ItemExchageCountList", ItemExchageCountList);
		ViGameSerializer<Int32Property>.Append(OS, head + "DailyItemBuyCountList", DailyItemBuyCountList);
		ViGameSerializer<Int32Property>.Append(OS, head + "DailyItemReceiveCountList", DailyItemReceiveCountList);
		ViGameSerializer<ItemDelRecordProperty>.Append(OS, head + "ItemDelRecordList", ItemDelRecordList);
		ViGameSerializer<ItemDelCountProperty>.Append(OS, head + "ItemDelCountList", ItemDelCountList);
		ViGameSerializer<Time1970Property>.Append(OS, head + "ItemLicenceCDList", ItemLicenceCDList);
		ViGameSerializer<ItemLicenceRecordProperty>.Append(OS, head + "ItemLicenceRecordList", ItemLicenceRecordList);
		ViGameSerializer<LoopCountProperty>.Append(OS, head + "MarketItemBuyCountList", MarketItemBuyCountList);
		ViGameSerializer<GoalProperty>.Append(OS, head + "GoalList", GoalList);
		ViGameSerializer<UInt32>.Append(OS, head + "GoalRewardList", GoalRewardList);
		ViGameSerializer<UInt32>.Append(OS, head + "GoalCompletedList", GoalCompletedList);
		ViGameSerializer<ScoreRankStasticsProperty>.Append(OS, head + "ScoreRankStasticsList", ScoreRankStasticsList);
		ViGameSerializer<HeroProperty>.Append(OS, head + "HeroList", HeroList);
		ViGameSerializer<HeroSpellProperty>.Append(OS, head + "StudySpellList", StudySpellList);
		ViGameSerializer<GameUnitIndexProperty>.Append(OS, head + "HeroPropertyList", HeroPropertyList);
		ViGameSerializer<UInt32>.Append(OS, head + "SpaceWorkingHero", SpaceWorkingHero);
		ViGameSerializer<Int16>.Append(OS, head + "DayGiftReserveCount", DayGiftReserveCount);
		ViGameSerializer<Int16>.Append(OS, head + "DayGiftTakedAccumulateCount", DayGiftTakedAccumulateCount);
		ViGameSerializer<UInt32>.Append(OS, head + "AccumulateLoginRewardTakedList", AccumulateLoginRewardTakedList);
		ViGameSerializer<UInt32>.Append(OS, head + "AccumulateLoginInActivityRewardTakedList", AccumulateLoginInActivityRewardTakedList);
	}
}

public class PlayerReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 154;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataUInt64 OnlineVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataInt16 MergeCount = new ViReceiveDataInt16();//DB
	public ViReceiveDataString NameAlias = new ViReceiveDataString();//OWN_CLIENT+CELL+DB
	public ViReceiveDataInt16 NameAliasUpdateCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataUInt8 Photo = new ViReceiveDataUInt8();//OWN_CLIENT+CELL+DB
	public ViReceiveDataSet<UInt32> PhotoList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+DB
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();//OWN_CLIENT+CELL+DB
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();//OWN_CLIENT+CELL+DB
	public ViReceiveDataInt64 XP = new ViReceiveDataInt64();//OWN_CLIENT+CELL+DB
	private ViReceiveDataInt32 HeroFightPowerSum = new ViReceiveDataInt32();//
	public ViReceiveDataUInt32 StateMask = new ViReceiveDataUInt32();//OWN_CLIENT+CELL
	private ReceiveDataEntityServerProperty Server = new ReceiveDataEntityServerProperty();//DB
	public ViReceiveDataString GUName = new ViReceiveDataString();//OWN_CLIENT+CELL
	private ViReceiveDataUInt64 AccountID = new ViReceiveDataUInt64();//DB
	private ViReceiveDataString AccountName = new ViReceiveDataString();//DB
	public ViReceiveDataUInt8 GMLevel = new ViReceiveDataUInt8();//OWN_CLIENT+CELL+DB
	private ViReceiveDataString SourceTag = new ViReceiveDataString();//DB
	private ViReceiveDataString SourceDate = new ViReceiveDataString();//DB
	private ViReceiveDataString CDKey = new ViReceiveDataString();//DB
	private ViReceiveDataString CDKeyTag = new ViReceiveDataString();//DB
	private ViReceiveDataString IP = new ViReceiveDataString();//DB
	private ViReceiveDataString MacAdress = new ViReceiveDataString();//DB
	public ViReceiveDataInt64 ActiveTime = new ViReceiveDataInt64();//OWN_CLIENT
	public ViReceiveDataInt64 CreateTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 LoginCount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 LoginTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 AccumulateOnlineDuration = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 LastDayOnlineDuration = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 LastOnlineTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	private ViReceiveDataInt32 CreateDayNumber1970 = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 CurrentDayNumber1970 = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 CurrentDayNumber1970InComponent = new ViReceiveDataInt32();//DB
	public ViReceiveDataInt16 ContinuousLoginDayCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt16 ContinuousLoginDayMaxCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt16 AccumulateLoginDayCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();//OWN_CLIENT
	public ViReceiveDataString CellServer = new ViReceiveDataString();//OWN_CLIENT
	public ViReceiveDataString BaseServer = new ViReceiveDataString();//OWN_CLIENT
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
	public ViReceiveDataDictionary<UInt32, ReceiveDataUInt8Property, UInt8Property> PaymentStateList = new ViReceiveDataDictionary<UInt32, ReceiveDataUInt8Property, UInt8Property>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> JinPiaoPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> JinZiPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty> YinPiaoPaymentRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataStatisticsValueProperty, StatisticsValueProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property> StatisticsList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property>();//OWN_CLIENT+DB
	private ViReceiveDataDictionary<ViString, ReceiveDataInt32Property, Int32Property> BackupList = new ViReceiveDataDictionary<ViString, ReceiveDataInt32Property, Int32Property>();//DB
	private ViReceiveDataArray<ReceiveDataMailProperty, MailProperty> MailCacheList = new ViReceiveDataArray<ReceiveDataMailProperty, MailProperty>();//DB
	public ViReceiveDataSet<UInt32> FuncOpenList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+CELL+DB
	public ViReceiveDataSet<UInt32> FuncDynamicActiveList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+CELL
	public ViReceiveDataSet<UInt32> FuncDynamicDeactiveist = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+CELL
	public ViReceiveDataArray<ReceiveDataShortCutProperty, ShortCutProperty> ShortCutList = new ViReceiveDataArray<ReceiveDataShortCutProperty, ShortCutProperty>();//OWN_CLIENT+DB
	public ReceiveDataClientSettingForPlayerProperty ClientSetting = new ReceiveDataClientSettingForPlayerProperty();//OWN_CLIENT+DB
	public ViReceiveDataString ChatChannelName = new ViReceiveDataString();//OWN_CLIENT+DB
	public ViReceiveDataUInt32 ChatChannelMask = new ViReceiveDataUInt32();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property> VisualScriptValueList = new ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property>();//OWN_CLIENT
	public ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property> PresistentScriptValueList = new ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty> ScriptProgressList = new ViReceiveDataDictionary<UInt32, ReceiveDataProgressProperty, ProgressProperty>();//OWN_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataTimeProperty, TimeProperty> CoolingDownList = new ViReceiveDataDictionary<UInt32, ReceiveDataTimeProperty, TimeProperty>();//OWN_CLIENT+DB
	private ViReceiveDataSet<UInt32> OnceLootList = new ViReceiveDataSet<UInt32>();//DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataScriptDurationProperty, ScriptDurationProperty> ScriptDurationList = new ViReceiveDataDictionary<UInt32, ReceiveDataScriptDurationProperty, ScriptDurationProperty>();//OWN_CLIENT+CELL+DB
	public ViReceiveDataInt64 ChatInWorldEndTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 ChatInSpaceEndTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 ChatEndTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	private ViReceiveDataInt16 ChatOfflineReserveCount = new ViReceiveDataInt16();//DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataActivityEnterProperty, ActivityEnterProperty> ActivityEnterList = new ViReceiveDataDictionary<UInt32, ReceiveDataActivityEnterProperty, ActivityEnterProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property> ScoreList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt64Property, Int64Property>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataLoopCountProperty, LoopCountProperty> ScoreMarketItemBuyCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataLoopCountProperty, LoopCountProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataNotifyProperty, NotifyProperty> NotifyList = new ViReceiveDataDictionary<UInt32, ReceiveDataNotifyProperty, NotifyProperty>();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt32> HintList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+DB
	public ViReceiveDataString GuildName = new ViReceiveDataString();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataGuildActivityEnterProperty, GuildActivityEnterProperty> GuildActivityEnterList = new ViReceiveDataDictionary<UInt32, ReceiveDataGuildActivityEnterProperty, GuildActivityEnterProperty>();//OWN_CLIENT+DB
	public ViReceiveDataInt64 PartyID = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataPartyInvitorProperty, PartyInvitorProperty> PartyInviteList = new ViReceiveDataArray<ReceiveDataPartyInvitorProperty, PartyInvitorProperty>();//OWN_CLIENT
	public ViReceiveDataArray<ReceiveDataPartyPartnerRecordProperty, PartyPartnerRecordProperty> PartyPartnerRecordList = new ViReceiveDataArray<ReceiveDataPartyPartnerRecordProperty, PartyPartnerRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataPartyDetailLite, PartyDetailLite> RequestPartyList = new ViReceiveDataArray<ReceiveDataPartyDetailLite, PartyDetailLite>();//OWN_CLIENT
	public ViReceiveDataUInt8 CellState = new ViReceiveDataUInt8();//OWN_CLIENT
	public ViReceiveDataUInt8 SpaceState = new ViReceiveDataUInt8();//OWN_CLIENT
	public ViReceiveDataUInt8 SpaceChangable = new ViReceiveDataUInt8();//OWN_CLIENT+CELL
	public ViReceiveDataUInt32 LastSmallSpace = new ViReceiveDataUInt32();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataSpaceRecordProperty, SpaceRecordProperty> SpaceRecordList = new ViReceiveDataDictionary<UInt32, ReceiveDataSpaceRecordProperty, SpaceRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataUInt32 LastBigSpace = new ViReceiveDataUInt32();//OWN_CLIENT+DB
	public ViReceiveDataVector3 LastBigSpacePosition = new ViReceiveDataVector3();//OWN_CLIENT+DB
	public ViReceiveDataInt64 YinPiao = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinPiao = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinZiInAccount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinZiTotalTransfer = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinZiDayTransfer = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 YinPiaoAccumulate = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinPiaoAccumulate = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinZiAccumulate = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataMoneyModRecordProperty, MoneyModRecordProperty> YinPiaoModRecordList = new ViReceiveDataArray<ReceiveDataMoneyModRecordProperty, MoneyModRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataMoneyModRecordProperty, MoneyModRecordProperty> JinPiaoModRecordList = new ViReceiveDataArray<ReceiveDataMoneyModRecordProperty, MoneyModRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataMoneyModRecordProperty, MoneyModRecordProperty> JinZiModRecordList = new ViReceiveDataArray<ReceiveDataMoneyModRecordProperty, MoneyModRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataInt16 YinPiaoDayBuyCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt64 YinPiaoAccumulateBuyCount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 QuestAdventureXP = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 QuestAdventureCoin = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt16 Power = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt16 PowerSup = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt64 PowerRecoverTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt16 PowerDayBuyCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt64 PowerAccumulateBuyCount = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt16 BagSize = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty> Inventory = new ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty>();//CELL+OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty> Equipments = new ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty>();//CELL+OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataItemSaledProperty, ItemSaledProperty> ItemSaledList = new ViReceiveDataArray<ReceiveDataItemSaledProperty, ItemSaledProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataPackageSlotProperty, PackageSlotProperty> PackageSlotPropertyList = new ViReceiveDataArray<ReceiveDataPackageSlotProperty, PackageSlotProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataPackageSlotProperty, PackageSlotProperty> PackageSlotSaledList = new ViReceiveDataArray<ReceiveDataPackageSlotProperty, PackageSlotProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property> ItemUseCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property> ItemExchageCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property> DailyItemBuyCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property> DailyItemReceiveCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataInt32Property, Int32Property>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataItemDelRecordProperty, ItemDelRecordProperty> ItemDelRecordList = new ViReceiveDataArray<ReceiveDataItemDelRecordProperty, ItemDelRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataItemDelCountProperty, ItemDelCountProperty> ItemDelCountList = new ViReceiveDataArray<ReceiveDataItemDelCountProperty, ItemDelCountProperty>();//OWN_CLIENT+DB
	private ViReceiveDataDictionary<UInt32, ReceiveDataTime1970Property, Time1970Property> ItemLicenceCDList = new ViReceiveDataDictionary<UInt32, ReceiveDataTime1970Property, Time1970Property>();//DB
	public ViReceiveDataArray<ReceiveDataItemLicenceRecordProperty, ItemLicenceRecordProperty> ItemLicenceRecordList = new ViReceiveDataArray<ReceiveDataItemLicenceRecordProperty, ItemLicenceRecordProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataLoopCountProperty, LoopCountProperty> MarketItemBuyCountList = new ViReceiveDataDictionary<UInt32, ReceiveDataLoopCountProperty, LoopCountProperty>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataGoalProperty, GoalProperty> GoalList = new ViReceiveDataDictionary<UInt32, ReceiveDataGoalProperty, GoalProperty>();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt32> GoalRewardList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt32> GoalCompletedList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataScoreRankStasticsProperty, ScoreRankStasticsProperty> ScoreRankStasticsList = new ViReceiveDataDictionary<UInt32, ReceiveDataScoreRankStasticsProperty, ScoreRankStasticsProperty>();//OWN_CLIENT+CELL+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataHeroProperty, HeroProperty> HeroList = new ViReceiveDataDictionary<UInt32, ReceiveDataHeroProperty, HeroProperty>();//CELL+OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataHeroSpellProperty, HeroSpellProperty> StudySpellList = new ViReceiveDataArray<ReceiveDataHeroSpellProperty, HeroSpellProperty>();//OWN_CLIENT+CELL+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataGameUnitIndexProperty, GameUnitIndexProperty> HeroPropertyList = new ViReceiveDataDictionary<UInt32, ReceiveDataGameUnitIndexProperty, GameUnitIndexProperty>();//OWN_CLIENT
	public ViReceiveDataUInt32 SpaceWorkingHero = new ViReceiveDataUInt32();//OWN_CLIENT+DB
	public ViReceiveDataInt16 DayGiftReserveCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt16 DayGiftTakedAccumulateCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt32> AccumulateLoginRewardTakedList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+DB
	public ViReceiveDataSet<UInt32> AccumulateLoginInActivityRewardTakedList = new ViReceiveDataSet<UInt32>();//OWN_CLIENT+DB
	//
	public PlayerReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlineVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MergeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		NameAlias.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		NameAliasUpdateCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Photo.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PhotoList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Gender.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Level.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		XP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		HeroFightPowerSum.RegisterAsChild((UInt16)(0), this, ChildList);
		StateMask.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL)), this, ChildList);
		Server.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GUName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL)), this, ChildList);
		AccountID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccountName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GMLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		SourceTag.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		SourceDate.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CDKey.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CDKeyTag.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		IP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MacAdress.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActiveTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CreateTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LoginCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LoginTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateOnlineDuration.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastDayOnlineDuration.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastOnlineTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CurrentDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CurrentDayNumber1970InComponent.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ContinuousLoginDayCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ContinuousLoginDayMaxCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateLoginDayCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ClientState.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CellServer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		BaseServer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
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
		PaymentStateList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinPiaoPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoPaymentRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StatisticsList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		BackupList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MailCacheList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		FuncOpenList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		FuncDynamicActiveList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL)), this, ChildList);
		FuncDynamicDeactiveist.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL)), this, ChildList);
		ShortCutList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ClientSetting.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ChatChannelName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ChatChannelMask.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		VisualScriptValueList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		PresistentScriptValueList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ScriptProgressList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CoolingDownList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnceLootList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ScriptDurationList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ChatInWorldEndTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ChatInSpaceEndTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ChatEndTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ChatOfflineReserveCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActivityEnterList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ScoreList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ScoreMarketItemBuyCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		NotifyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		HintList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GuildName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GuildActivityEnterList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PartyID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PartyInviteList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		PartyPartnerRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RequestPartyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CellState.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		SpaceState.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		SpaceChangable.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL)), this, ChildList);
		LastSmallSpace.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		SpaceRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastBigSpace.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastBigSpacePosition.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiao.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinPiao.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiInAccount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiTotalTransfer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiDayTransfer.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoAccumulate.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinPiaoAccumulate.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiAccumulate.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoModRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinPiaoModRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZiModRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoDayBuyCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		YinPiaoAccumulateBuyCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		QuestAdventureXP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		QuestAdventureCoin.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Power.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PowerSup.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PowerRecoverTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PowerDayBuyCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PowerAccumulateBuyCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		BagSize.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Inventory.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		Equipments.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemSaledList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PackageSlotPropertyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PackageSlotSaledList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemUseCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemExchageCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DailyItemBuyCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DailyItemReceiveCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemDelRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemDelCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemLicenceCDList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ItemLicenceRecordList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MarketItemBuyCountList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GoalList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GoalRewardList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GoalCompletedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ScoreRankStasticsList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		HeroList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		StudySpellList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.CELL) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		HeroPropertyList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		SpaceWorkingHero.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayGiftReserveCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayGiftTakedAccumulateCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateLoginRewardTakedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateLoginInActivityRewardTakedList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
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
		OnlineVersion.Start(channelMask, IS, entity);
		MergeCount.Start(channelMask, IS, entity);
		NameAlias.Start(channelMask, IS, entity);
		NameAliasUpdateCount.Start(channelMask, IS, entity);
		Photo.Start(channelMask, IS, entity);
		PhotoList.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		XP.Start(channelMask, IS, entity);
		HeroFightPowerSum.Start(channelMask, IS, entity);
		StateMask.Start(channelMask, IS, entity);
		Server.Start(channelMask, IS, entity);
		GUName.Start(channelMask, IS, entity);
		AccountID.Start(channelMask, IS, entity);
		AccountName.Start(channelMask, IS, entity);
		GMLevel.Start(channelMask, IS, entity);
		SourceTag.Start(channelMask, IS, entity);
		SourceDate.Start(channelMask, IS, entity);
		CDKey.Start(channelMask, IS, entity);
		CDKeyTag.Start(channelMask, IS, entity);
		IP.Start(channelMask, IS, entity);
		MacAdress.Start(channelMask, IS, entity);
		ActiveTime.Start(channelMask, IS, entity);
		CreateTime.Start(channelMask, IS, entity);
		CreateTime1970.Start(channelMask, IS, entity);
		LoginCount.Start(channelMask, IS, entity);
		LoginTime.Start(channelMask, IS, entity);
		AccumulateOnlineDuration.Start(channelMask, IS, entity);
		LastDayOnlineDuration.Start(channelMask, IS, entity);
		LastOnlineTime1970.Start(channelMask, IS, entity);
		CreateDayNumber1970.Start(channelMask, IS, entity);
		CurrentDayNumber1970.Start(channelMask, IS, entity);
		CurrentDayNumber1970InComponent.Start(channelMask, IS, entity);
		ContinuousLoginDayCount.Start(channelMask, IS, entity);
		ContinuousLoginDayMaxCount.Start(channelMask, IS, entity);
		AccumulateLoginDayCount.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		CellServer.Start(channelMask, IS, entity);
		BaseServer.Start(channelMask, IS, entity);
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
		PaymentStateList.Start(channelMask, IS, entity);
		JinPiaoPaymentRecordList.Start(channelMask, IS, entity);
		JinZiPaymentRecordList.Start(channelMask, IS, entity);
		YinPiaoPaymentRecordList.Start(channelMask, IS, entity);
		StatisticsList.Start(channelMask, IS, entity);
		BackupList.Start(channelMask, IS, entity);
		MailCacheList.Start(channelMask, IS, entity);
		FuncOpenList.Start(channelMask, IS, entity);
		FuncDynamicActiveList.Start(channelMask, IS, entity);
		FuncDynamicDeactiveist.Start(channelMask, IS, entity);
		ShortCutList.Start(channelMask, IS, entity);
		ClientSetting.Start(channelMask, IS, entity);
		ChatChannelName.Start(channelMask, IS, entity);
		ChatChannelMask.Start(channelMask, IS, entity);
		VisualScriptValueList.Start(channelMask, IS, entity);
		PresistentScriptValueList.Start(channelMask, IS, entity);
		ScriptProgressList.Start(channelMask, IS, entity);
		CoolingDownList.Start(channelMask, IS, entity);
		OnceLootList.Start(channelMask, IS, entity);
		ScriptDurationList.Start(channelMask, IS, entity);
		ChatInWorldEndTime1970.Start(channelMask, IS, entity);
		ChatInSpaceEndTime1970.Start(channelMask, IS, entity);
		ChatEndTime1970.Start(channelMask, IS, entity);
		ChatOfflineReserveCount.Start(channelMask, IS, entity);
		ActivityEnterList.Start(channelMask, IS, entity);
		ScoreList.Start(channelMask, IS, entity);
		ScoreMarketItemBuyCountList.Start(channelMask, IS, entity);
		NotifyList.Start(channelMask, IS, entity);
		HintList.Start(channelMask, IS, entity);
		GuildName.Start(channelMask, IS, entity);
		GuildActivityEnterList.Start(channelMask, IS, entity);
		PartyID.Start(channelMask, IS, entity);
		PartyInviteList.Start(channelMask, IS, entity);
		PartyPartnerRecordList.Start(channelMask, IS, entity);
		RequestPartyList.Start(channelMask, IS, entity);
		CellState.Start(channelMask, IS, entity);
		SpaceState.Start(channelMask, IS, entity);
		SpaceChangable.Start(channelMask, IS, entity);
		LastSmallSpace.Start(channelMask, IS, entity);
		SpaceRecordList.Start(channelMask, IS, entity);
		LastBigSpace.Start(channelMask, IS, entity);
		LastBigSpacePosition.Start(channelMask, IS, entity);
		YinPiao.Start(channelMask, IS, entity);
		JinPiao.Start(channelMask, IS, entity);
		JinZiInAccount.Start(channelMask, IS, entity);
		JinZiTotalTransfer.Start(channelMask, IS, entity);
		JinZiDayTransfer.Start(channelMask, IS, entity);
		YinPiaoAccumulate.Start(channelMask, IS, entity);
		JinPiaoAccumulate.Start(channelMask, IS, entity);
		JinZiAccumulate.Start(channelMask, IS, entity);
		YinPiaoModRecordList.Start(channelMask, IS, entity);
		JinPiaoModRecordList.Start(channelMask, IS, entity);
		JinZiModRecordList.Start(channelMask, IS, entity);
		YinPiaoDayBuyCount.Start(channelMask, IS, entity);
		YinPiaoAccumulateBuyCount.Start(channelMask, IS, entity);
		QuestAdventureXP.Start(channelMask, IS, entity);
		QuestAdventureCoin.Start(channelMask, IS, entity);
		Power.Start(channelMask, IS, entity);
		PowerSup.Start(channelMask, IS, entity);
		PowerRecoverTime.Start(channelMask, IS, entity);
		PowerDayBuyCount.Start(channelMask, IS, entity);
		PowerAccumulateBuyCount.Start(channelMask, IS, entity);
		BagSize.Start(channelMask, IS, entity);
		Inventory.Start(channelMask, IS, entity);
		Equipments.Start(channelMask, IS, entity);
		ItemSaledList.Start(channelMask, IS, entity);
		PackageSlotPropertyList.Start(channelMask, IS, entity);
		PackageSlotSaledList.Start(channelMask, IS, entity);
		ItemUseCountList.Start(channelMask, IS, entity);
		ItemExchageCountList.Start(channelMask, IS, entity);
		DailyItemBuyCountList.Start(channelMask, IS, entity);
		DailyItemReceiveCountList.Start(channelMask, IS, entity);
		ItemDelRecordList.Start(channelMask, IS, entity);
		ItemDelCountList.Start(channelMask, IS, entity);
		ItemLicenceCDList.Start(channelMask, IS, entity);
		ItemLicenceRecordList.Start(channelMask, IS, entity);
		MarketItemBuyCountList.Start(channelMask, IS, entity);
		GoalList.Start(channelMask, IS, entity);
		GoalRewardList.Start(channelMask, IS, entity);
		GoalCompletedList.Start(channelMask, IS, entity);
		ScoreRankStasticsList.Start(channelMask, IS, entity);
		HeroList.Start(channelMask, IS, entity);
		StudySpellList.Start(channelMask, IS, entity);
		HeroPropertyList.Start(channelMask, IS, entity);
		SpaceWorkingHero.Start(channelMask, IS, entity);
		DayGiftReserveCount.Start(channelMask, IS, entity);
		DayGiftTakedAccumulateCount.Start(channelMask, IS, entity);
		AccumulateLoginRewardTakedList.Start(channelMask, IS, entity);
		AccumulateLoginInActivityRewardTakedList.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		OnlineVersion.End(entity);
		MergeCount.End(entity);
		NameAlias.End(entity);
		NameAliasUpdateCount.End(entity);
		Photo.End(entity);
		PhotoList.End(entity);
		Gender.End(entity);
		Level.End(entity);
		XP.End(entity);
		HeroFightPowerSum.End(entity);
		StateMask.End(entity);
		Server.End(entity);
		GUName.End(entity);
		AccountID.End(entity);
		AccountName.End(entity);
		GMLevel.End(entity);
		SourceTag.End(entity);
		SourceDate.End(entity);
		CDKey.End(entity);
		CDKeyTag.End(entity);
		IP.End(entity);
		MacAdress.End(entity);
		ActiveTime.End(entity);
		CreateTime.End(entity);
		CreateTime1970.End(entity);
		LoginCount.End(entity);
		LoginTime.End(entity);
		AccumulateOnlineDuration.End(entity);
		LastDayOnlineDuration.End(entity);
		LastOnlineTime1970.End(entity);
		CreateDayNumber1970.End(entity);
		CurrentDayNumber1970.End(entity);
		CurrentDayNumber1970InComponent.End(entity);
		ContinuousLoginDayCount.End(entity);
		ContinuousLoginDayMaxCount.End(entity);
		AccumulateLoginDayCount.End(entity);
		ClientState.End(entity);
		CellServer.End(entity);
		BaseServer.End(entity);
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
		PaymentStateList.End(entity);
		JinPiaoPaymentRecordList.End(entity);
		JinZiPaymentRecordList.End(entity);
		YinPiaoPaymentRecordList.End(entity);
		StatisticsList.End(entity);
		BackupList.End(entity);
		MailCacheList.End(entity);
		FuncOpenList.End(entity);
		FuncDynamicActiveList.End(entity);
		FuncDynamicDeactiveist.End(entity);
		ShortCutList.End(entity);
		ClientSetting.End(entity);
		ChatChannelName.End(entity);
		ChatChannelMask.End(entity);
		VisualScriptValueList.End(entity);
		PresistentScriptValueList.End(entity);
		ScriptProgressList.End(entity);
		CoolingDownList.End(entity);
		OnceLootList.End(entity);
		ScriptDurationList.End(entity);
		ChatInWorldEndTime1970.End(entity);
		ChatInSpaceEndTime1970.End(entity);
		ChatEndTime1970.End(entity);
		ChatOfflineReserveCount.End(entity);
		ActivityEnterList.End(entity);
		ScoreList.End(entity);
		ScoreMarketItemBuyCountList.End(entity);
		NotifyList.End(entity);
		HintList.End(entity);
		GuildName.End(entity);
		GuildActivityEnterList.End(entity);
		PartyID.End(entity);
		PartyInviteList.End(entity);
		PartyPartnerRecordList.End(entity);
		RequestPartyList.End(entity);
		CellState.End(entity);
		SpaceState.End(entity);
		SpaceChangable.End(entity);
		LastSmallSpace.End(entity);
		SpaceRecordList.End(entity);
		LastBigSpace.End(entity);
		LastBigSpacePosition.End(entity);
		YinPiao.End(entity);
		JinPiao.End(entity);
		JinZiInAccount.End(entity);
		JinZiTotalTransfer.End(entity);
		JinZiDayTransfer.End(entity);
		YinPiaoAccumulate.End(entity);
		JinPiaoAccumulate.End(entity);
		JinZiAccumulate.End(entity);
		YinPiaoModRecordList.End(entity);
		JinPiaoModRecordList.End(entity);
		JinZiModRecordList.End(entity);
		YinPiaoDayBuyCount.End(entity);
		YinPiaoAccumulateBuyCount.End(entity);
		QuestAdventureXP.End(entity);
		QuestAdventureCoin.End(entity);
		Power.End(entity);
		PowerSup.End(entity);
		PowerRecoverTime.End(entity);
		PowerDayBuyCount.End(entity);
		PowerAccumulateBuyCount.End(entity);
		BagSize.End(entity);
		Inventory.End(entity);
		Equipments.End(entity);
		ItemSaledList.End(entity);
		PackageSlotPropertyList.End(entity);
		PackageSlotSaledList.End(entity);
		ItemUseCountList.End(entity);
		ItemExchageCountList.End(entity);
		DailyItemBuyCountList.End(entity);
		DailyItemReceiveCountList.End(entity);
		ItemDelRecordList.End(entity);
		ItemDelCountList.End(entity);
		ItemLicenceCDList.End(entity);
		ItemLicenceRecordList.End(entity);
		MarketItemBuyCountList.End(entity);
		GoalList.End(entity);
		GoalRewardList.End(entity);
		GoalCompletedList.End(entity);
		ScoreRankStasticsList.End(entity);
		HeroList.End(entity);
		StudySpellList.End(entity);
		HeroPropertyList.End(entity);
		SpaceWorkingHero.End(entity);
		DayGiftReserveCount.End(entity);
		DayGiftTakedAccumulateCount.End(entity);
		AccumulateLoginRewardTakedList.End(entity);
		AccumulateLoginInActivityRewardTakedList.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		OnlineVersion.Clear();
		MergeCount.Clear();
		NameAlias.Clear();
		NameAliasUpdateCount.Clear();
		Photo.Clear();
		PhotoList.Clear();
		Gender.Clear();
		Level.Clear();
		XP.Clear();
		HeroFightPowerSum.Clear();
		StateMask.Clear();
		Server.Clear();
		GUName.Clear();
		AccountID.Clear();
		AccountName.Clear();
		GMLevel.Clear();
		SourceTag.Clear();
		SourceDate.Clear();
		CDKey.Clear();
		CDKeyTag.Clear();
		IP.Clear();
		MacAdress.Clear();
		ActiveTime.Clear();
		CreateTime.Clear();
		CreateTime1970.Clear();
		LoginCount.Clear();
		LoginTime.Clear();
		AccumulateOnlineDuration.Clear();
		LastDayOnlineDuration.Clear();
		LastOnlineTime1970.Clear();
		CreateDayNumber1970.Clear();
		CurrentDayNumber1970.Clear();
		CurrentDayNumber1970InComponent.Clear();
		ContinuousLoginDayCount.Clear();
		ContinuousLoginDayMaxCount.Clear();
		AccumulateLoginDayCount.Clear();
		ClientState.Clear();
		CellServer.Clear();
		BaseServer.Clear();
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
		PaymentStateList.Clear();
		JinPiaoPaymentRecordList.Clear();
		JinZiPaymentRecordList.Clear();
		YinPiaoPaymentRecordList.Clear();
		StatisticsList.Clear();
		BackupList.Clear();
		MailCacheList.Clear();
		FuncOpenList.Clear();
		FuncDynamicActiveList.Clear();
		FuncDynamicDeactiveist.Clear();
		ShortCutList.Clear();
		ClientSetting.Clear();
		ChatChannelName.Clear();
		ChatChannelMask.Clear();
		VisualScriptValueList.Clear();
		PresistentScriptValueList.Clear();
		ScriptProgressList.Clear();
		CoolingDownList.Clear();
		OnceLootList.Clear();
		ScriptDurationList.Clear();
		ChatInWorldEndTime1970.Clear();
		ChatInSpaceEndTime1970.Clear();
		ChatEndTime1970.Clear();
		ChatOfflineReserveCount.Clear();
		ActivityEnterList.Clear();
		ScoreList.Clear();
		ScoreMarketItemBuyCountList.Clear();
		NotifyList.Clear();
		HintList.Clear();
		GuildName.Clear();
		GuildActivityEnterList.Clear();
		PartyID.Clear();
		PartyInviteList.Clear();
		PartyPartnerRecordList.Clear();
		RequestPartyList.Clear();
		CellState.Clear();
		SpaceState.Clear();
		SpaceChangable.Clear();
		LastSmallSpace.Clear();
		SpaceRecordList.Clear();
		LastBigSpace.Clear();
		LastBigSpacePosition.Clear();
		YinPiao.Clear();
		JinPiao.Clear();
		JinZiInAccount.Clear();
		JinZiTotalTransfer.Clear();
		JinZiDayTransfer.Clear();
		YinPiaoAccumulate.Clear();
		JinPiaoAccumulate.Clear();
		JinZiAccumulate.Clear();
		YinPiaoModRecordList.Clear();
		JinPiaoModRecordList.Clear();
		JinZiModRecordList.Clear();
		YinPiaoDayBuyCount.Clear();
		YinPiaoAccumulateBuyCount.Clear();
		QuestAdventureXP.Clear();
		QuestAdventureCoin.Clear();
		Power.Clear();
		PowerSup.Clear();
		PowerRecoverTime.Clear();
		PowerDayBuyCount.Clear();
		PowerAccumulateBuyCount.Clear();
		BagSize.Clear();
		Inventory.Clear();
		Equipments.Clear();
		ItemSaledList.Clear();
		PackageSlotPropertyList.Clear();
		PackageSlotSaledList.Clear();
		ItemUseCountList.Clear();
		ItemExchageCountList.Clear();
		DailyItemBuyCountList.Clear();
		DailyItemReceiveCountList.Clear();
		ItemDelRecordList.Clear();
		ItemDelCountList.Clear();
		ItemLicenceCDList.Clear();
		ItemLicenceRecordList.Clear();
		MarketItemBuyCountList.Clear();
		GoalList.Clear();
		GoalRewardList.Clear();
		GoalCompletedList.Clear();
		ScoreRankStasticsList.Clear();
		HeroList.Clear();
		StudySpellList.Clear();
		HeroPropertyList.Clear();
		SpaceWorkingHero.Clear();
		DayGiftReserveCount.Clear();
		DayGiftTakedAccumulateCount.Clear();
		AccumulateLoginRewardTakedList.Clear();
		AccumulateLoginInActivityRewardTakedList.Clear();
	}
}
