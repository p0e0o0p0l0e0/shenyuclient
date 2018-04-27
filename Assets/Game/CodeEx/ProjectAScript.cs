using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityTypeID = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class ProjectAScript
{
	public static void Start()
	{
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.GAMERECORD, GameRecordClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.ACCOUNT, AccountClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PLAYER, PlayerClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PLAYEROFFLINEBOX, PlayerOfflineBoxClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PLAYERMAILBOX, PlayerMailboxClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PLAYERFRIENDLIST, PlayerFriendListClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.CENTERCHATGROUP, CenterChatGroupClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.GUILD, GuildClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PLAYERGUILD, PlayerGuildClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.TRADEMANAGER, TradeManagerClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PLAYERTRADER, PlayerTraderClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.GAMESPACERECORD, GameSpaceRecordClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.GAMESPACEFACTIONRECORD, GameSpaceFactionRecordClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.CELLRECORD, CellRecordClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.CELLHERO, CellHeroClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.CELLNPC, CellNPCClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.CELLPLAYER, CellPlayerClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.CELLCHATGROUP, CellChatGroupClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.GMRECORD, GMRecordClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.GMACCOUNT, GMAccountClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PUBLICSPACEENTER, PublicSpaceEnterClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PUBLICSPACEMANAGER, PublicSpaceManagerClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.AREAAURA, AreaAuraClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.ACTIVITYRECORD, ActivityRecordClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.SPACEOBJECT, SpaceObjectClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.PARTY, PartyClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.SPACEMATCHMANAGER, SpaceMatchManagerClientExecer.Create);
		ViEntityType.Register((ViEntityTypeID)ProjectAEntityType.SPACEMATCHENTERGROUP, SpaceMatchEnterGroupClientExecer.Create);
		//
		ViGameSerializer<GameRecord>.AppendExec = GameRecordSerializer.Append;
		ViGameSerializer<GameRecord>.ReadExec = GameRecordSerializer.Read;
		ViGameSerializer<GameRecord>.ReadStringExec = GameRecordSerializer.Read;
		ViGameSerializer<Account>.AppendExec = AccountSerializer.Append;
		ViGameSerializer<Account>.ReadExec = AccountSerializer.Read;
		ViGameSerializer<Account>.ReadStringExec = AccountSerializer.Read;
		ViGameSerializer<Player>.AppendExec = PlayerSerializer.Append;
		ViGameSerializer<Player>.ReadExec = PlayerSerializer.Read;
		ViGameSerializer<Player>.ReadStringExec = PlayerSerializer.Read;
		ViGameSerializer<PlayerComponent>.AppendExec = PlayerComponentSerializer.Append;
		ViGameSerializer<PlayerComponent>.ReadExec = PlayerComponentSerializer.Read;
		ViGameSerializer<PlayerComponent>.ReadStringExec = PlayerComponentSerializer.Read;
		ViGameSerializer<PlayerOfflineBox>.AppendExec = PlayerOfflineBoxSerializer.Append;
		ViGameSerializer<PlayerOfflineBox>.ReadExec = PlayerOfflineBoxSerializer.Read;
		ViGameSerializer<PlayerOfflineBox>.ReadStringExec = PlayerOfflineBoxSerializer.Read;
		ViGameSerializer<PlayerMailbox>.AppendExec = PlayerMailboxSerializer.Append;
		ViGameSerializer<PlayerMailbox>.ReadExec = PlayerMailboxSerializer.Read;
		ViGameSerializer<PlayerMailbox>.ReadStringExec = PlayerMailboxSerializer.Read;
		ViGameSerializer<PlayerFriendList>.AppendExec = PlayerFriendListSerializer.Append;
		ViGameSerializer<PlayerFriendList>.ReadExec = PlayerFriendListSerializer.Read;
		ViGameSerializer<PlayerFriendList>.ReadStringExec = PlayerFriendListSerializer.Read;
		ViGameSerializer<CenterChatGroup>.AppendExec = CenterChatGroupSerializer.Append;
		ViGameSerializer<CenterChatGroup>.ReadExec = CenterChatGroupSerializer.Read;
		ViGameSerializer<CenterChatGroup>.ReadStringExec = CenterChatGroupSerializer.Read;
		ViGameSerializer<Guild>.AppendExec = GuildSerializer.Append;
		ViGameSerializer<Guild>.ReadExec = GuildSerializer.Read;
		ViGameSerializer<Guild>.ReadStringExec = GuildSerializer.Read;
		ViGameSerializer<PlayerGuild>.AppendExec = PlayerGuildSerializer.Append;
		ViGameSerializer<PlayerGuild>.ReadExec = PlayerGuildSerializer.Read;
		ViGameSerializer<PlayerGuild>.ReadStringExec = PlayerGuildSerializer.Read;
		ViGameSerializer<TradeManager>.AppendExec = TradeManagerSerializer.Append;
		ViGameSerializer<TradeManager>.ReadExec = TradeManagerSerializer.Read;
		ViGameSerializer<TradeManager>.ReadStringExec = TradeManagerSerializer.Read;
		ViGameSerializer<PlayerTrader>.AppendExec = PlayerTraderSerializer.Append;
		ViGameSerializer<PlayerTrader>.ReadExec = PlayerTraderSerializer.Read;
		ViGameSerializer<PlayerTrader>.ReadStringExec = PlayerTraderSerializer.Read;
		ViGameSerializer<GameSpaceRecord>.AppendExec = GameSpaceRecordSerializer.Append;
		ViGameSerializer<GameSpaceRecord>.ReadExec = GameSpaceRecordSerializer.Read;
		ViGameSerializer<GameSpaceRecord>.ReadStringExec = GameSpaceRecordSerializer.Read;
		ViGameSerializer<GameSpaceFactionRecord>.AppendExec = GameSpaceFactionRecordSerializer.Append;
		ViGameSerializer<GameSpaceFactionRecord>.ReadExec = GameSpaceFactionRecordSerializer.Read;
		ViGameSerializer<GameSpaceFactionRecord>.ReadStringExec = GameSpaceFactionRecordSerializer.Read;
		ViGameSerializer<CellRecord>.AppendExec = CellRecordSerializer.Append;
		ViGameSerializer<CellRecord>.ReadExec = CellRecordSerializer.Read;
		ViGameSerializer<CellRecord>.ReadStringExec = CellRecordSerializer.Read;
		ViGameSerializer<GameUnit>.AppendExec = GameUnitSerializer.Append;
		ViGameSerializer<GameUnit>.ReadExec = GameUnitSerializer.Read;
		ViGameSerializer<GameUnit>.ReadStringExec = GameUnitSerializer.Read;
		ViGameSerializer<CellHero>.AppendExec = CellHeroSerializer.Append;
		ViGameSerializer<CellHero>.ReadExec = CellHeroSerializer.Read;
		ViGameSerializer<CellHero>.ReadStringExec = CellHeroSerializer.Read;
		ViGameSerializer<CellNPC>.AppendExec = CellNPCSerializer.Append;
		ViGameSerializer<CellNPC>.ReadExec = CellNPCSerializer.Read;
		ViGameSerializer<CellNPC>.ReadStringExec = CellNPCSerializer.Read;
		ViGameSerializer<CellPlayer>.AppendExec = CellPlayerSerializer.Append;
		ViGameSerializer<CellPlayer>.ReadExec = CellPlayerSerializer.Read;
		ViGameSerializer<CellPlayer>.ReadStringExec = CellPlayerSerializer.Read;
		ViGameSerializer<CellChatGroup>.AppendExec = CellChatGroupSerializer.Append;
		ViGameSerializer<CellChatGroup>.ReadExec = CellChatGroupSerializer.Read;
		ViGameSerializer<CellChatGroup>.ReadStringExec = CellChatGroupSerializer.Read;
		ViGameSerializer<GMRecord>.AppendExec = GMRecordSerializer.Append;
		ViGameSerializer<GMRecord>.ReadExec = GMRecordSerializer.Read;
		ViGameSerializer<GMRecord>.ReadStringExec = GMRecordSerializer.Read;
		ViGameSerializer<GMAccount>.AppendExec = GMAccountSerializer.Append;
		ViGameSerializer<GMAccount>.ReadExec = GMAccountSerializer.Read;
		ViGameSerializer<GMAccount>.ReadStringExec = GMAccountSerializer.Read;
		ViGameSerializer<PublicSpaceEnter>.AppendExec = PublicSpaceEnterSerializer.Append;
		ViGameSerializer<PublicSpaceEnter>.ReadExec = PublicSpaceEnterSerializer.Read;
		ViGameSerializer<PublicSpaceEnter>.ReadStringExec = PublicSpaceEnterSerializer.Read;
		ViGameSerializer<PublicSpaceManager>.AppendExec = PublicSpaceManagerSerializer.Append;
		ViGameSerializer<PublicSpaceManager>.ReadExec = PublicSpaceManagerSerializer.Read;
		ViGameSerializer<PublicSpaceManager>.ReadStringExec = PublicSpaceManagerSerializer.Read;
		ViGameSerializer<AreaAura>.AppendExec = AreaAuraSerializer.Append;
		ViGameSerializer<AreaAura>.ReadExec = AreaAuraSerializer.Read;
		ViGameSerializer<AreaAura>.ReadStringExec = AreaAuraSerializer.Read;
		ViGameSerializer<ActivityRecord>.AppendExec = ActivityRecordSerializer.Append;
		ViGameSerializer<ActivityRecord>.ReadExec = ActivityRecordSerializer.Read;
		ViGameSerializer<ActivityRecord>.ReadStringExec = ActivityRecordSerializer.Read;
		ViGameSerializer<SpaceObject>.AppendExec = SpaceObjectSerializer.Append;
		ViGameSerializer<SpaceObject>.ReadExec = SpaceObjectSerializer.Read;
		ViGameSerializer<SpaceObject>.ReadStringExec = SpaceObjectSerializer.Read;
		ViGameSerializer<Party>.AppendExec = PartySerializer.Append;
		ViGameSerializer<Party>.ReadExec = PartySerializer.Read;
		ViGameSerializer<Party>.ReadStringExec = PartySerializer.Read;
		ViGameSerializer<SpaceMatchManager>.AppendExec = SpaceMatchManagerSerializer.Append;
		ViGameSerializer<SpaceMatchManager>.ReadExec = SpaceMatchManagerSerializer.Read;
		ViGameSerializer<SpaceMatchManager>.ReadStringExec = SpaceMatchManagerSerializer.Read;
		ViGameSerializer<SpaceMatchEnterGroup>.AppendExec = SpaceMatchEnterGroupSerializer.Append;
		ViGameSerializer<SpaceMatchEnterGroup>.ReadExec = SpaceMatchEnterGroupSerializer.Read;
		ViGameSerializer<SpaceMatchEnterGroup>.ReadStringExec = SpaceMatchEnterGroupSerializer.Read;
	}
	
	public static void StartCommand()
	{
		GameRecordCommandInvoker.Start();
		AccountCommandInvoker.Start();
		PlayerCommandInvoker.Start();
		PlayerComponentCommandInvoker.Start();
		PlayerOfflineBoxCommandInvoker.Start();
		PlayerMailboxCommandInvoker.Start();
		PlayerFriendListCommandInvoker.Start();
		CenterChatGroupCommandInvoker.Start();
		GuildCommandInvoker.Start();
		PlayerGuildCommandInvoker.Start();
		TradeManagerCommandInvoker.Start();
		PlayerTraderCommandInvoker.Start();
		GameSpaceRecordCommandInvoker.Start();
		GameSpaceFactionRecordCommandInvoker.Start();
		CellRecordCommandInvoker.Start();
		GameUnitCommandInvoker.Start();
		CellHeroCommandInvoker.Start();
		CellNPCCommandInvoker.Start();
		CellPlayerCommandInvoker.Start();
		CellChatGroupCommandInvoker.Start();
		GMRecordCommandInvoker.Start();
		GMAccountCommandInvoker.Start();
		PublicSpaceEnterCommandInvoker.Start();
		PublicSpaceManagerCommandInvoker.Start();
		AreaAuraCommandInvoker.Start();
		ActivityRecordCommandInvoker.Start();
		SpaceObjectCommandInvoker.Start();
		PartyCommandInvoker.Start();
		SpaceMatchManagerCommandInvoker.Start();
		SpaceMatchEnterGroupCommandInvoker.Start();
	}
	
	public static void End()
	{
		
	}
}
