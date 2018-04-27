using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerClientExecer : ViRPCExecer
{
	public static PlayerClientExecer Create() { return new PlayerClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(Player entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new Player();
		SetEntity(_entity);
		_entity.Enable(ID, PackID, asLocal);
		_entity.StartProperty(channelMask, IS);
		entityManager.AddEntity(ID, PackID, _entity);
		_entity.SetActive(true);
	}
	public override void OnPropertyUpdateStart(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateStart(channel);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdate(channel, IS);
	}
	public override void OnPropertyUpdateEnd(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateEnd(channel);
	}
	public override void End(ViEntityManager entityManager)
	{
		ViDebuger.AssertError(_entity);
		_entity.SetActive(false);
		_entity.EndProperty();
		entityManager.DelEntity(_entity);
		_entity.ClearProperty();
		_entity = null;
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((PlayerClientMethod)funcIdx)
		{
			case PlayerClientMethod.METHOD_0_OnPing: 
				_0_OnPing(IS);
				break;
			case PlayerClientMethod.METHOD_1_ShakeCamera: 
				_1_ShakeCamera(IS);
				break;
			case PlayerClientMethod.METHOD_2_ShakeCameraSpring: 
				_2_ShakeCameraSpring(IS);
				break;
			case PlayerClientMethod.METHOD_3_ShakeCameraRandom: 
				_3_ShakeCameraRandom(IS);
				break;
			case PlayerClientMethod.METHOD_4_MessageBox: 
				_4_MessageBox(IS);
				break;
			case PlayerClientMethod.METHOD_5_DebugMessage: 
				_5_DebugMessage(IS);
				break;
			case PlayerClientMethod.METHOD_6_ContainReserveWord: 
				_6_ContainReserveWord(IS);
				break;
			case PlayerClientMethod.METHOD_7_OnReceiveMessage: 
				_7_OnReceiveMessage(IS);
				break;
			case PlayerClientMethod.METHOD_8_OnLevelUpdated: 
				_8_OnLevelUpdated(IS);
				break;
			case PlayerClientMethod.METHOD_9_OnFuncOpen: 
				_9_OnFuncOpen(IS);
				break;
			case PlayerClientMethod.METHOD_10_OnActivityEnter: 
				_10_OnActivityEnter(IS);
				break;
			case PlayerClientMethod.METHOD_11_OnActivityExit: 
				_11_OnActivityExit(IS);
				break;
			case PlayerClientMethod.METHOD_12_OnUpdateMarketItem: 
				_12_OnUpdateMarketItem(IS);
				break;
			case PlayerClientMethod.METHOD_13_OnUpdateItemTradeList: 
				_13_OnUpdateItemTradeList(IS);
				break;
			case PlayerClientMethod.METHOD_14_OnAddItemTrade: 
				_14_OnAddItemTrade(IS);
				break;
			case PlayerClientMethod.METHOD_15_OnUpdateItemTradeOwnList: 
				_15_OnUpdateItemTradeOwnList(IS);
				break;
			case PlayerClientMethod.METHOD_16_OnUpdateItemTradeAuctionList: 
				_16_OnUpdateItemTradeAuctionList(IS);
				break;
			case PlayerClientMethod.METHOD_17_OnItemTradeBuySuc: 
				_17_OnItemTradeBuySuc(IS);
				break;
			case PlayerClientMethod.METHOD_18_OnGuildListUpdated: 
				_18_OnGuildListUpdated(IS);
				break;
			case PlayerClientMethod.METHOD_19_OnGuildSearchResult: 
				_19_OnGuildSearchResult(IS);
				break;
			case PlayerClientMethod.METHOD_20_OnGuildApplyRecordUpdated: 
				_20_OnGuildApplyRecordUpdated(IS);
				break;
			case PlayerClientMethod.METHOD_21_OnGuildRecommandUpdated: 
				_21_OnGuildRecommandUpdated(IS);
				break;
			case PlayerClientMethod.METHOD_22_OnPartyInvite: 
				_22_OnPartyInvite(IS);
				break;
			case PlayerClientMethod.METHOD_23_OnPartyDisagreeRequest: 
				_23_OnPartyDisagreeRequest(IS);
				break;
			case PlayerClientMethod.METHOD_24_OnPartyFire: 
				_24_OnPartyFire(IS);
				break;
			case PlayerClientMethod.METHOD_25_OnPartyDisband: 
				_25_OnPartyDisband(IS);
				break;
			case PlayerClientMethod.METHOD_26_OnPartyList: 
				_26_OnPartyList(IS);
				break;
			case PlayerClientMethod.METHOD_27_OnGotoBigSpaceWithParty: 
				_27_OnGotoBigSpaceWithParty(IS);
				break;
			case PlayerClientMethod.METHOD_28_OnVoteDelPartyMember: 
				_28_OnVoteDelPartyMember(IS);
				break;
			case PlayerClientMethod.METHOD_29_OnFriendInvitedStart: 
				_29_OnFriendInvitedStart(IS);
				break;
			case PlayerClientMethod.METHOD_30_OnFriendInvitedEnd: 
				_30_OnFriendInvitedEnd(IS);
				break;
			case PlayerClientMethod.METHOD_31_OnFriendSearchResult: 
				_31_OnFriendSearchResult(IS);
				break;
			case PlayerClientMethod.METHOD_32_OnChatRecordList: 
				_32_OnChatRecordList(IS);
				break;
			case PlayerClientMethod.METHOD_33_OnTransferJinZiResult: 
				_33_OnTransferJinZiResult(IS);
				break;
			case PlayerClientMethod.METHOD_34_OnNPCLoot: 
				_34_OnNPCLoot(IS);
				break;
			case PlayerClientMethod.METHOD_35_OnSmallSpacePVERecordUpdate: 
				_35_OnSmallSpacePVERecordUpdate(IS);
				break;
			case PlayerClientMethod.METHOD_36_OnSmallSpacePVEWin: 
				_36_OnSmallSpacePVEWin(IS);
				break;
			case PlayerClientMethod.METHOD_37_OnSmallSpacePVELose: 
				_37_OnSmallSpacePVELose(IS);
				break;
			case PlayerClientMethod.METHOD_38_OnSmallSpacePVPWin: 
				_38_OnSmallSpacePVPWin(IS);
				break;
			case PlayerClientMethod.METHOD_39_OnSmallSpacePVPLose: 
				_39_OnSmallSpacePVPLose(IS);
				break;
			case PlayerClientMethod.METHOD_40_OnScoreRankUpdate: 
				_40_OnScoreRankUpdate(IS);
				break;
			case PlayerClientMethod.METHOD_41_UIEvent: 
				_41_UIEvent(IS);
				break;
			case PlayerClientMethod.METHOD_42_UIEvent: 
				_42_UIEvent(IS);
				break;
			case PlayerClientMethod.METHOD_43_OnGoalEndNeedClick: 
				_43_OnGoalEndNeedClick(IS);
				break;
			case PlayerClientMethod.METHOD_44_EnterStoryModel: 
				_44_EnterStoryModel(IS);
				break;
			case PlayerClientMethod.METHOD_45_ExitStoryModel: 
				_45_ExitStoryModel(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnPing(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int64 Time;
		ViGameSerializer<Int64>.Read(IS, out Time);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPing(" + ", " + Time + ")");
		}
		_entity.OnPing(Time);
	}

	void _1_ShakeCamera(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ShakeCamera(" + ", " + ID + ")");
		}
		_entity.ShakeCamera(ID);
	}

	void _2_ShakeCameraSpring(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float SpirngRange;
		ViGameSerializer<float>.Read(IS, out SpirngRange);
		float SpirngRate;
		ViGameSerializer<float>.Read(IS, out SpirngRate);
		float SpeedFriction;
		ViGameSerializer<float>.Read(IS, out SpeedFriction);
		float TimeScale;
		ViGameSerializer<float>.Read(IS, out TimeScale);
		Int32 SprintCount;
		ViGameSerializer<Int32>.Read(IS, out SprintCount);
		float LookAtScale;
		ViGameSerializer<float>.Read(IS, out LookAtScale);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ShakeCameraSpring(" + ", " + SpirngRange + ", " + SpirngRate + ", " + SpeedFriction + ", " + TimeScale + ", " + SprintCount + ", " + LookAtScale + ")");
		}
		_entity.ShakeCameraSpring(SpirngRange, SpirngRate, SpeedFriction, TimeScale, SprintCount, LookAtScale);
	}

	void _3_ShakeCameraRandom(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		float Intensity;
		ViGameSerializer<float>.Read(IS, out Intensity);
		float LookAtScale;
		ViGameSerializer<float>.Read(IS, out LookAtScale);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ShakeCameraRandom(" + ", " + Duration + ", " + Intensity + ", " + LookAtScale + ")");
		}
		_entity.ShakeCameraRandom(Duration, Intensity, LookAtScale);
	}

	void _4_MessageBox(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Title;
		ViGameSerializer<ViString>.Read(IS, out Title);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].MessageBox(" + ", " + Title + ", " + Content + ")");
		}
		_entity.MessageBox(Title, Content);
	}

	void _5_DebugMessage(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Title;
		ViGameSerializer<ViString>.Read(IS, out Title);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].DebugMessage(" + ", " + Title + ", " + Content + ")");
		}
		_entity.DebugMessage(Title, Content);
	}

	void _6_ContainReserveWord(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString OrgValue;
		ViGameSerializer<ViString>.Read(IS, out OrgValue);
		ViString FmtValue;
		ViGameSerializer<ViString>.Read(IS, out FmtValue);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ContainReserveWord(" + ", " + OrgValue + ", " + FmtValue + ")");
		}
		_entity.ContainReserveWord(OrgValue, FmtValue);
	}

	void _7_OnReceiveMessage(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Loot;
		ViGameSerializer<UInt32>.Read(IS, out Loot);
		UInt32 Message;
		ViGameSerializer<UInt32>.Read(IS, out Message);
		Int32 XP;
		ViGameSerializer<Int32>.Read(IS, out XP);
		Int32 JinPiao;
		ViGameSerializer<Int32>.Read(IS, out JinPiao);
		Int32 YinPiao;
		ViGameSerializer<Int32>.Read(IS, out YinPiao);
		List<ItemCountProperty> ItemList;
		ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnReceiveMessage(" + ", " + Loot + ", " + Message + ", " + XP + ", " + JinPiao + ", " + YinPiao + ", " + ItemList + ")");
		}
		_entity.OnReceiveMessage(Loot, Message, XP, JinPiao, YinPiao, ItemList);
	}

	void _8_OnLevelUpdated(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		LevelUpdateProperty OldProperty;
		ViGameSerializer<LevelUpdateProperty>.Read(IS, out OldProperty);
		LevelUpdateProperty NewProperty;
		ViGameSerializer<LevelUpdateProperty>.Read(IS, out NewProperty);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLevelUpdated(" + ", " + OldProperty + ", " + NewProperty + ")");
		}
		_entity.OnLevelUpdated(OldProperty, NewProperty);
	}

	void _9_OnFuncOpen(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFuncOpen(" + ", " + ID + ")");
		}
		_entity.OnFuncOpen(ID);
	}

	void _10_OnActivityEnter(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt8 First;
		ViGameSerializer<UInt8>.Read(IS, out First);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnActivityEnter(" + ", " + ID + ", " + First + ")");
		}
		_entity.OnActivityEnter(ID, First);
	}

	void _11_OnActivityExit(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnActivityExit(" + ", " + ID + ")");
		}
		_entity.OnActivityExit(ID);
	}

	void _12_OnUpdateMarketItem(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Tag;
		ViGameSerializer<ViString>.Read(IS, out Tag);
		List<MarketSellItemProperty> List;
		ViGameSerializer<MarketSellItemProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateMarketItem(" + ", " + Tag + ", " + List + ")");
		}
		_entity.OnUpdateMarketItem(Tag, List);
	}

	void _13_OnUpdateItemTradeList(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ItemTradeProperty> LocalList;
		ViGameSerializer<ItemTradeProperty>.Read(IS, out LocalList);
		UInt16 TotalCount;
		ViGameSerializer<UInt16>.Read(IS, out TotalCount);
		UInt8 PlayerFlag;
		ViGameSerializer<UInt8>.Read(IS, out PlayerFlag);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateItemTradeList(" + ", " + LocalList + ", " + TotalCount + ", " + PlayerFlag + ")");
		}
		_entity.OnUpdateItemTradeList(LocalList, TotalCount, PlayerFlag);
	}

	void _14_OnAddItemTrade(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Result;
		ViGameSerializer<UInt8>.Read(IS, out Result);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnAddItemTrade(" + ", " + Result + ")");
		}
		_entity.OnAddItemTrade(Result);
	}

	void _15_OnUpdateItemTradeOwnList(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ItemTradeProperty> List;
		ViGameSerializer<ItemTradeProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateItemTradeOwnList(" + ", " + List + ")");
		}
		_entity.OnUpdateItemTradeOwnList(List);
	}

	void _16_OnUpdateItemTradeAuctionList(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ItemTradeProperty> List;
		ViGameSerializer<ItemTradeProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateItemTradeAuctionList(" + ", " + List + ")");
		}
		_entity.OnUpdateItemTradeAuctionList(List);
	}

	void _17_OnItemTradeBuySuc(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt64 ID;
		ViGameSerializer<UInt64>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnItemTradeBuySuc(" + ", " + ID + ")");
		}
		_entity.OnItemTradeBuySuc(ID);
	}

	void _18_OnGuildListUpdated(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int16 TotalCount;
		ViGameSerializer<Int16>.Read(IS, out TotalCount);
		List<GuildViewProperty> GuildList;
		ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnGuildListUpdated(" + ", " + TotalCount + ", " + GuildList + ")");
		}
		_entity.OnGuildListUpdated(TotalCount, GuildList);
	}

	void _19_OnGuildSearchResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<GuildViewProperty> GuildList;
		ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnGuildSearchResult(" + ", " + GuildList + ")");
		}
		_entity.OnGuildSearchResult(GuildList);
	}

	void _20_OnGuildApplyRecordUpdated(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<GuildViewProperty> GuildList;
		ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnGuildApplyRecordUpdated(" + ", " + GuildList + ")");
		}
		_entity.OnGuildApplyRecordUpdated(GuildList);
	}

	void _21_OnGuildRecommandUpdated(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<GuildViewProperty> GuildList;
		ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnGuildRecommandUpdated(" + ", " + GuildList + ")");
		}
		_entity.OnGuildRecommandUpdated(GuildList);
	}

	void _22_OnPartyInvite(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt64 PartyID;
		ViGameSerializer<UInt64>.Read(IS, out PartyID);
		ViString PartyName;
		ViGameSerializer<ViString>.Read(IS, out PartyName);
		UInt64 LeaderID;
		ViGameSerializer<UInt64>.Read(IS, out LeaderID);
		ViString LeaderName;
		ViGameSerializer<ViString>.Read(IS, out LeaderName);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPartyInvite(" + ", " + PartyID + ", " + PartyName + ", " + LeaderID + ", " + LeaderName + ")");
		}
		_entity.OnPartyInvite(PartyID, PartyName, LeaderID, LeaderName);
	}

	void _23_OnPartyDisagreeRequest(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt64 PartyID;
		ViGameSerializer<UInt64>.Read(IS, out PartyID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPartyDisagreeRequest(" + ", " + PartyID + ")");
		}
		_entity.OnPartyDisagreeRequest(PartyID);
	}

	void _24_OnPartyFire(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Party;
		ViGameSerializer<ViString>.Read(IS, out Party);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPartyFire(" + ", " + Party + ")");
		}
		_entity.OnPartyFire(Party);
	}

	void _25_OnPartyDisband(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Party;
		ViGameSerializer<ViString>.Read(IS, out Party);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPartyDisband(" + ", " + Party + ")");
		}
		_entity.OnPartyDisband(Party);
	}

	void _26_OnPartyList(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<PartyDetail> partyList;
		ViGameSerializer<PartyDetail>.Read(IS, out partyList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPartyList(" + ", " + partyList + ")");
		}
		_entity.OnPartyList(partyList);
	}

	void _27_OnGotoBigSpaceWithParty(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		UInt64 Target;
		ViGameSerializer<UInt64>.Read(IS, out Target);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnGotoBigSpaceWithParty(" + ", " + Space + ", " + Target + ")");
		}
		_entity.OnGotoBigSpaceWithParty(Space, Target);
	}

	void _28_OnVoteDelPartyMember(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt64 PlayerID;
		ViGameSerializer<UInt64>.Read(IS, out PlayerID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnVoteDelPartyMember(" + ", " + PlayerID + ")");
		}
		_entity.OnVoteDelPartyMember(PlayerID);
	}

	void _29_OnFriendInvitedStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString InvitorName;
		ViGameSerializer<ViString>.Read(IS, out InvitorName);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFriendInvitedStart(" + ", " + InvitorName + ")");
		}
		_entity.OnFriendInvitedStart(InvitorName);
	}

	void _30_OnFriendInvitedEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFriendInvitedEnd(" + ")");
		}
		_entity.OnFriendInvitedEnd();
	}

	void _31_OnFriendSearchResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<PlayerShotProperty> List;
		ViGameSerializer<PlayerShotProperty>.Read(IS, out List);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFriendSearchResult(" + ", " + List + ")");
		}
		_entity.OnFriendSearchResult(List);
	}

	void _32_OnChatRecordList(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Channel;
		ViGameSerializer<UInt8>.Read(IS, out Channel);
		UInt32 Count;
		ViGameSerializer<UInt32>.Read(IS, out Count);
		UInt32 Start;
		ViGameSerializer<UInt32>.Read(IS, out Start);
		List<ChatRecordProperty> RecordList;
		ViGameSerializer<ChatRecordProperty>.Read(IS, out RecordList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChatRecordList(" + ", " + Channel + ", " + Count + ", " + Start + ", " + RecordList + ")");
		}
		_entity.OnChatRecordList(Channel, Count, Start, RecordList);
	}

	void _33_OnTransferJinZiResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Success;
		ViGameSerializer<UInt8>.Read(IS, out Success);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnTransferJinZiResult(" + ", " + Success + ")");
		}
		_entity.OnTransferJinZiResult(Success);
	}

	void _34_OnNPCLoot(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 EntityPackedID;
		ViGameSerializer<UInt32>.Read(IS, out EntityPackedID);
		Int32 XP;
		ViGameSerializer<Int32>.Read(IS, out XP);
		Int32 YinPiao;
		ViGameSerializer<Int32>.Read(IS, out YinPiao);
		List<ItemCountProperty> ItemList;
		ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnNPCLoot(" + ", " + EntityPackedID + ", " + XP + ", " + YinPiao + ", " + ItemList + ")");
		}
		_entity.OnNPCLoot(EntityPackedID, XP, YinPiao, ItemList);
	}

	void _35_OnSmallSpacePVERecordUpdate(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		SpaceRecordProperty Record;
		ViGameSerializer<SpaceRecordProperty>.Read(IS, out Record);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSmallSpacePVERecordUpdate(" + ", " + Space + ", " + Record + ")");
		}
		_entity.OnSmallSpacePVERecordUpdate(Space, Record);
	}

	void _36_OnSmallSpacePVEWin(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		Int32 XP;
		ViGameSerializer<Int32>.Read(IS, out XP);
		Int32 YinPiao;
		ViGameSerializer<Int32>.Read(IS, out YinPiao);
		List<ItemCountProperty> ItemList;
		ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSmallSpacePVEWin(" + ", " + Space + ", " + XP + ", " + YinPiao + ", " + ItemList + ")");
		}
		_entity.OnSmallSpacePVEWin(Space, XP, YinPiao, ItemList);
	}

	void _37_OnSmallSpacePVELose(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSmallSpacePVELose(" + ", " + Space + ")");
		}
		_entity.OnSmallSpacePVELose(Space);
	}

	void _38_OnSmallSpacePVPWin(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		Int32 RankScore;
		ViGameSerializer<Int32>.Read(IS, out RankScore);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSmallSpacePVPWin(" + ", " + Space + ", " + RankScore + ")");
		}
		_entity.OnSmallSpacePVPWin(Space, RankScore);
	}

	void _39_OnSmallSpacePVPLose(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Space;
		ViGameSerializer<UInt32>.Read(IS, out Space);
		Int32 RankScore;
		ViGameSerializer<Int32>.Read(IS, out RankScore);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSmallSpacePVPLose(" + ", " + Space + ", " + RankScore + ")");
		}
		_entity.OnSmallSpacePVPLose(Space, RankScore);
	}

	void _40_OnScoreRankUpdate(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Rank;
		ViGameSerializer<UInt32>.Read(IS, out Rank);
		UInt32 Position;
		ViGameSerializer<UInt32>.Read(IS, out Position);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnScoreRankUpdate(" + ", " + Rank + ", " + Position + ")");
		}
		_entity.OnScoreRankUpdate(Rank, Position);
	}

	void _41_UIEvent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].UIEvent(" + ", " + ID + ")");
		}
		_entity.UIEvent(ID);
	}

	void _42_UIEvent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt16 Slot;
		ViGameSerializer<UInt16>.Read(IS, out Slot);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].UIEvent(" + ", " + ID + ", " + Slot + ")");
		}
		_entity.UIEvent(ID, Slot);
	}

	void _43_OnGoalEndNeedClick(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnGoalEndNeedClick(" + ", " + ID + ")");
		}
		_entity.OnGoalEndNeedClick(ID);
	}

	void _44_EnterStoryModel(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 GoalID;
		ViGameSerializer<UInt32>.Read(IS, out GoalID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].EnterStoryModel(" + ", " + GoalID + ")");
		}
		_entity.EnterStoryModel(GoalID);
	}

	void _45_ExitStoryModel(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 GoalID;
		ViGameSerializer<UInt32>.Read(IS, out GoalID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ExitStoryModel(" + ", " + GoalID + ")");
		}
		_entity.ExitStoryModel(GoalID);
	}

	protected Player _entity;
}
