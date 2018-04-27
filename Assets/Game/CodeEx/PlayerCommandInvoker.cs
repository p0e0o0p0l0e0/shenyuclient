using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerCommandInvoker : ViEntityCommandInvoker<Player>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".Exec", Server_0_Exec);
		AddFunc(".Exec", Server_1_Exec);
		AddFunc(".PrintMappingValue", Server_2_PrintMappingValue);
		AddFunc(".OnPing", Server_3_OnPing);
		AddFunc(".SetVisualScriptValue", Server_4_SetVisualScriptValue);
		AddFunc(".ClearVisualScriptValue", Server_5_ClearVisualScriptValue);
		AddFunc(".SetPresistentScriptValue", Server_6_SetPresistentScriptValue);
		AddFunc(".ClearPresistentScriptValue", Server_7_ClearPresistentScriptValue);
		AddFunc(".SetNameAlias", Server_8_SetNameAlias);
		AddFunc(".SetPhoto", Server_9_SetPhoto);
		AddFunc(".AddPhoto", Server_10_AddPhoto);
		AddFunc(".DelPhoto", Server_11_DelPhoto);
		AddFunc(".ClearPhoto", Server_12_ClearPhoto);
		AddFunc(".ModLevel", Server_13_ModLevel);
		AddFunc(".ModXP", Server_14_ModXP);
		AddFunc(".SetAccumulateLoginDayCount", Server_15_SetAccumulateLoginDayCount);
		AddFunc(".ModAccumulateLoginDayCount", Server_16_ModAccumulateLoginDayCount);
		AddFunc(".SetAccumulateOnlineDuration", Server_17_SetAccumulateOnlineDuration);
		AddFunc(".ModAccumulateOnlineDuration", Server_18_ModAccumulateOnlineDuration);
		AddFunc(".SetDayOnlineDuration", Server_19_SetDayOnlineDuration);
		AddFunc(".AddLoginStreak", Server_20_AddLoginStreak);
		AddFunc(".ResetLoginStreak", Server_21_ResetLoginStreak);
		AddFunc(".OnNewDay", Server_22_OnNewDay);
		AddFunc(".OnNewWeek", Server_23_OnNewWeek);
		AddFunc(".OnNewMonth", Server_24_OnNewMonth);
		AddFunc(".PrintProperty", Server_25_PrintProperty);
		AddFunc(".PrintProperty", Server_26_PrintProperty);
		AddFunc(".PrintComponentProperty", Server_27_PrintComponentProperty);
		AddFunc(".PrintComponentProperty", Server_28_PrintComponentProperty);
		AddFunc(".PrintAccountProperty", Server_29_PrintAccountProperty);
		AddFunc(".PrintAccountProperty", Server_30_PrintAccountProperty);
		AddFunc(".PrintGuildProperty", Server_31_PrintGuildProperty);
		AddFunc(".PrintGuildProperty", Server_32_PrintGuildProperty);
		AddFunc(".PrintPublicSpaceEnterProperty", Server_33_PrintPublicSpaceEnterProperty);
		AddFunc(".PrintPublicSpaceEnterProperty", Server_34_PrintPublicSpaceEnterProperty);
		AddFunc(".PrintPartyProperty", Server_35_PrintPartyProperty);
		AddFunc(".PrintPartyProperty", Server_36_PrintPartyProperty);
		AddFunc(".PrintSpaceMatchEnterGroupProperty", Server_37_PrintSpaceMatchEnterGroupProperty);
		AddFunc(".PrintSpaceMatchEnterGroupProperty", Server_38_PrintSpaceMatchEnterGroupProperty);
		AddFunc(".PrintActivityProperty", Server_39_PrintActivityProperty);
		AddFunc(".PrintGlobalProperty", Server_40_PrintGlobalProperty);
		AddFunc(".CopyPropertyFrom", Server_41_CopyPropertyFrom);
		AddFunc(".CopyPropertyFrom", Server_42_CopyPropertyFrom);
		AddFunc(".EndClientWatchIgnore", Server_43_EndClientWatchIgnore);
		AddFunc(".ClearClientWatchIgnore", Server_44_ClearClientWatchIgnore);
		AddFunc(".EnterPrivateSpace", Server_45_EnterPrivateSpace);
		AddFunc(".GotoBigSpace", Server_46_GotoBigSpace);
		AddFunc(".LeaveSpace", Server_47_LeaveSpace);
		AddFunc(".EnterBigSpace", Server_48_EnterBigSpace);
		AddFunc(".EnterBigSpace", Server_49_EnterBigSpace);
		AddFunc(".ExitSpace", Server_50_ExitSpace);
		AddFunc(".ExitSpace", Server_51_ExitSpace);
		AddFunc(".OnSpaceEnter", Server_52_OnSpaceEnter);
		AddFunc(".OnSmallSpaceEvent", Server_53_OnSmallSpaceEvent);
		AddFunc(".OnSmallSpaceResult", Server_54_OnSmallSpaceResult);
		AddFunc(".OnSmallSpacePVEWin", Server_55_OnSmallSpacePVEWin);
		AddFunc(".OnSmallSpacePVELose", Server_56_OnSmallSpacePVELose);
		AddFunc(".OnSmallSpacePVPWin", Server_57_OnSmallSpacePVPWin);
		AddFunc(".OnSmallSpacePVPLose", Server_58_OnSmallSpacePVPLose);
		AddFunc(".UpdateSpaceRecord", Server_59_UpdateSpaceRecord);
		AddFunc(".SaveCellProperty", Server_60_SaveCellProperty);
		AddFunc(".OnCellHeroStart", Server_61_OnCellHeroStart);
		AddFunc(".OnCellHeroEnd", Server_62_OnCellHeroEnd);
		AddFunc(".SetLastSmallSpace", Server_63_SetLastSmallSpace);
		AddFunc(".AddNPCLoot", Server_64_AddNPCLoot);
		AddFunc(".AddSpaceLoot", Server_65_AddSpaceLoot);
		AddFunc(".AddSpaceLootScore", Server_66_AddSpaceLootScore);
		AddFunc(".AddSpaceChangableMask", Server_67_AddSpaceChangableMask);
		AddFunc(".DelSpaceChangableMask", Server_68_DelSpaceChangableMask);
		AddFunc(".EndCellPlayer", Server_69_EndCellPlayer);
		AddFunc(".CreatePublicSpaceEnter", Server_70_CreatePublicSpaceEnter);
		AddFunc(".EnterPublicSpaceEnter", Server_71_EnterPublicSpaceEnter);
		AddFunc(".ChangePublicSpaceEnterFaction", Server_72_ChangePublicSpaceEnterFaction);
		AddFunc(".AddPublicSpaceEnterFakePlayer", Server_73_AddPublicSpaceEnterFakePlayer);
		AddFunc(".SetPublicSpaceEnterReady", Server_74_SetPublicSpaceEnterReady);
		AddFunc(".FirePublicSpaceEnterMember", Server_75_FirePublicSpaceEnterMember);
		AddFunc(".ExitPublicSpaceEnter", Server_76_ExitPublicSpaceEnter);
		AddFunc(".GotoPublicSpaceEnter", Server_77_GotoPublicSpaceEnter);
		AddFunc(".PublicSpaceManagerWatchStart", Server_78_PublicSpaceManagerWatchStart);
		AddFunc(".PublicSpaceManagerWatchEnd", Server_79_PublicSpaceManagerWatchEnd);
		AddFunc(".SetChatEndTime", Server_80_SetChatEndTime);
		AddFunc(".ChatGroupWatchStart", Server_81_ChatGroupWatchStart);
		AddFunc(".ChatGroupWatchEnd", Server_82_ChatGroupWatchEnd);
		AddFunc(".ChatScriptBegin", Server_83_ChatScriptBegin);
		AddFunc(".ChatScriptBegin", Server_84_ChatScriptBegin);
		AddFunc(".ChatScriptBegin", Server_85_ChatScriptBegin);
		AddFunc(".ChatScriptEnd", Server_86_ChatScriptEnd);
		AddFunc(".ChatScriptShowItem", Server_87_ChatScriptShowItem);
		AddFunc(".ChatScriptWatchItem", Server_88_ChatScriptWatchItem);
		AddFunc(".ChatOffline", Server_89_ChatOffline);
		AddFunc(".ClearOfflineChat", Server_90_ClearOfflineChat);
		AddFunc(".ChatMessage", Server_91_ChatMessage);
		AddFunc(".ChatMessage", Server_92_ChatMessage);
		AddFunc(".ChatMessage", Server_93_ChatMessage);
		AddFunc(".OpenFunc", Server_94_OpenFunc);
		AddFunc(".CloseFunc", Server_95_CloseFunc);
		AddFunc(".AddFuncPolicy", Server_96_AddFuncPolicy);
		AddFunc(".DelFuncPolicy", Server_97_DelFuncPolicy);
		AddFunc(".ClearFuncPolicy", Server_98_ClearFuncPolicy);
		AddFunc(".EnterActivity", Server_99_EnterActivity);
		AddFunc(".ExitActivity", Server_100_ExitActivity);
		AddFunc(".ModActivityEnterCount", Server_101_ModActivityEnterCount);
		AddFunc(".ModScore", Server_102_ModScore);
		AddFunc(".BuyScoreMarketItem", Server_103_BuyScoreMarketItem);
		AddFunc(".AddCoolingDown", Server_104_AddCoolingDown);
		AddFunc(".DelCoolingDown", Server_105_DelCoolingDown);
		AddFunc(".DelAllCoolingDown", Server_106_DelAllCoolingDown);
		AddFunc(".AddScriptDuration", Server_107_AddScriptDuration);
		AddFunc(".SetScriptDuration", Server_108_SetScriptDuration);
		AddFunc(".ModScriptDuration", Server_109_ModScriptDuration);
		AddFunc(".DelScriptDuration", Server_110_DelScriptDuration);
		AddFunc(".DelAllScriptDuration", Server_111_DelAllScriptDuration);
		AddFunc(".TradeManagerWatchStart", Server_112_TradeManagerWatchStart);
		AddFunc(".TradeManagerWatchEnd", Server_113_TradeManagerWatchEnd);
		AddFunc(".AddItemTrade", Server_114_AddItemTrade);
		AddFunc(".DelItemTrade", Server_115_DelItemTrade);
		AddFunc(".SearchItemTrade", Server_116_SearchItemTrade);
		AddFunc(".UpdateItemTrade", Server_117_UpdateItemTrade);
		AddFunc(".BuyTradeItem", Server_118_BuyTradeItem);
		AddFunc(".AuctionTradeItem", Server_119_AuctionTradeItem);
		AddFunc(".CommitTradeItemTime", Server_120_CommitTradeItemTime);
		AddFunc(".UpdateItemTradeOwnList", Server_121_UpdateItemTradeOwnList);
		AddFunc(".UpdateItemTradeAuctionList", Server_122_UpdateItemTradeAuctionList);
		AddFunc(".RevertItemTradeRecord", Server_123_RevertItemTradeRecord);
		AddFunc(".ClearDailyItemTradeOutCount", Server_124_ClearDailyItemTradeOutCount);
		AddFunc(".ClearDailyItemTradeOutCount", Server_125_ClearDailyItemTradeOutCount);
		AddFunc(".CostItemTradeReserveCount", Server_126_CostItemTradeReserveCount);
		AddFunc(".CreateGuild", Server_127_CreateGuild);
		AddFunc(".UpdateGuildList", Server_128_UpdateGuildList);
		AddFunc(".UpdateGuildRecommand", Server_129_UpdateGuildRecommand);
		AddFunc(".SearchGuildName", Server_130_SearchGuildName);
		AddFunc(".ApplyGuild", Server_131_ApplyGuild);
		AddFunc(".ApplyGuild", Server_132_ApplyGuild);
		AddFunc(".CancelGuildApply", Server_133_CancelGuildApply);
		AddFunc(".UpdateGuildApplyRecord", Server_134_UpdateGuildApplyRecord);
		AddFunc(".AgreeGuildApply", Server_135_AgreeGuildApply);
		AddFunc(".AgreeGuildAllApply", Server_136_AgreeGuildAllApply);
		AddFunc(".DisagreeGuildApply", Server_137_DisagreeGuildApply);
		AddFunc(".DisagreeGuildAllApply", Server_138_DisagreeGuildAllApply);
		AddFunc(".GuildMail", Server_139_GuildMail);
		AddFunc(".EnterGuild", Server_140_EnterGuild);
		AddFunc(".ExitGuild", Server_141_ExitGuild);
		AddFunc(".FireGuildMember", Server_142_FireGuildMember);
		AddFunc(".GuildImpeach", Server_143_GuildImpeach);
		AddFunc(".SetGuildLeader", Server_144_SetGuildLeader);
		AddFunc(".SetGuildLeader", Server_145_SetGuildLeader);
		AddFunc(".SetGuildLeader", Server_146_SetGuildLeader);
		AddFunc(".HandOverGuildLeader", Server_147_HandOverGuildLeader);
		AddFunc(".SetGuildMemberPosition", Server_148_SetGuildMemberPosition);
		AddFunc(".ClearGuildMemberPosition", Server_149_ClearGuildMemberPosition);
		AddFunc(".SetGuildLevel", Server_150_SetGuildLevel);
		AddFunc(".ModGuildXP", Server_151_ModGuildXP);
		AddFunc(".SetGuildIntrodution", Server_152_SetGuildIntrodution);
		AddFunc(".SetGuildBoard", Server_153_SetGuildBoard);
		AddFunc(".SetGuildResponseType", Server_154_SetGuildResponseType);
		AddFunc(".SetGuildReqEnterLevel", Server_155_SetGuildReqEnterLevel);
		AddFunc(".GuildRecruit", Server_156_GuildRecruit);
		AddFunc(".GotoGuildSmallSpace", Server_157_GotoGuildSmallSpace);
		AddFunc(".ConvokeGuildSmallSpace", Server_158_ConvokeGuildSmallSpace);
		AddFunc(".ConvokeGuildSmallSpace", Server_159_ConvokeGuildSmallSpace);
		AddFunc(".EnterGuildActivitySeat", Server_160_EnterGuildActivitySeat);
		AddFunc(".ExitGuildActivitySeat", Server_161_ExitGuildActivitySeat);
		AddFunc(".FireGuildActivitySeat", Server_162_FireGuildActivitySeat);
		AddFunc(".ConvokeGuildActivity", Server_163_ConvokeGuildActivity);
		AddFunc(".ConvokeGuildActivity", Server_164_ConvokeGuildActivity);
		AddFunc(".StartGuildActivity", Server_165_StartGuildActivity);
		AddFunc(".EndGuildActivity", Server_166_EndGuildActivity);
		AddFunc(".EnterGuildActivity", Server_167_EnterGuildActivity);
		AddFunc(".SetGuildActivityEnterProperty", Server_168_SetGuildActivityEnterProperty);
		AddFunc(".AddPartyPartnerRecord", Server_169_AddPartyPartnerRecord);
		AddFunc(".DelPartyPartnerRecord", Server_170_DelPartyPartnerRecord);
		AddFunc(".ClearPartyPartnerRecord", Server_171_ClearPartyPartnerRecord);
		AddFunc(".CreateParty", Server_172_CreateParty);
		AddFunc(".CreateParty", Server_173_CreateParty);
		AddFunc(".ExitParty", Server_174_ExitParty);
		AddFunc(".InvitePartyMember", Server_175_InvitePartyMember);
		AddFunc(".InvitePartyMember", Server_176_InvitePartyMember);
		AddFunc(".CancelInvitePartyMember", Server_177_CancelInvitePartyMember);
		AddFunc(".CancelInvitePartyMemberAll", Server_178_CancelInvitePartyMemberAll);
		AddFunc(".AgreePartyInvite", Server_179_AgreePartyInvite);
		AddFunc(".DisagreePartyInvite", Server_180_DisagreePartyInvite);
		AddFunc(".DisagreePartyInviteAll", Server_181_DisagreePartyInviteAll);
		AddFunc(".DelPartyMember", Server_182_DelPartyMember);
		AddFunc(".SetPartyMemberState", Server_183_SetPartyMemberState);
		AddFunc(".SetPartyMemberAutoReady", Server_184_SetPartyMemberAutoReady);
		AddFunc(".RecommandParty", Server_185_RecommandParty);
		AddFunc(".RecommandParty", Server_186_RecommandParty);
		AddFunc(".DelPartyRecommand", Server_187_DelPartyRecommand);
		AddFunc(".EnterParty", Server_188_EnterParty);
		AddFunc(".SetPartyMatchSpace", Server_189_SetPartyMatchSpace);
		AddFunc(".StartPartyMatching", Server_190_StartPartyMatching);
		AddFunc(".EndPartyMatching", Server_191_EndPartyMatching);
		AddFunc(".SetPartyTarget", Server_192_SetPartyTarget);
		AddFunc(".PartyList", Server_193_PartyList);
		AddFunc(".AgreePartyInvite", Server_194_AgreePartyInvite);
		AddFunc(".DisagreePartyInvite", Server_195_DisagreePartyInvite);
		AddFunc(".AgreeJoinPartyLazy", Server_196_AgreeJoinPartyLazy);
		AddFunc(".DelPartyMember", Server_197_DelPartyMember);
		AddFunc(".RequestJoinParty", Server_198_RequestJoinParty);
		AddFunc(".RequestJoinPartyLazy", Server_199_RequestJoinPartyLazy);
		AddFunc(".AgreeJoinParty", Server_200_AgreeJoinParty);
		AddFunc(".DisagreeJoinParty", Server_201_DisagreeJoinParty);
		AddFunc(".DeputePartyLeader", Server_202_DeputePartyLeader);
		AddFunc(".GotoBigSpaceWithParty", Server_203_GotoBigSpaceWithParty);
		AddFunc(".VoteDelPartyMember", Server_204_VoteDelPartyMember);
		AddFunc(".ReplyVoteDelPartyMember", Server_205_ReplyVoteDelPartyMember);
		AddFunc(".SpaceMatchEnterGroupReady", Server_206_SpaceMatchEnterGroupReady);
		AddFunc(".SpaceMatchEnterGroupSelectHero", Server_207_SpaceMatchEnterGroupSelectHero);
		AddFunc(".SpaceMatchEnterGroupSelectHeroReady", Server_208_SpaceMatchEnterGroupSelectHeroReady);
		AddFunc(".AddFriend", Server_209_AddFriend);
		AddFunc(".AddFriend", Server_210_AddFriend);
		AddFunc(".DelFriend", Server_211_DelFriend);
		AddFunc(".DelFriend", Server_212_DelFriend);
		AddFunc(".SetFriendNote", Server_213_SetFriendNote);
		AddFunc(".AddBlackFriend", Server_214_AddBlackFriend);
		AddFunc(".AddBlackFriend", Server_215_AddBlackFriend);
		AddFunc(".DelBlackFriend", Server_216_DelBlackFriend);
		AddFunc(".DelBlackFriend", Server_217_DelBlackFriend);
		AddFunc(".UnblockBlackFriend", Server_218_UnblockBlackFriend);
		AddFunc(".UnblockBlackFriend", Server_219_UnblockBlackFriend);
		AddFunc(".FriendInvite", Server_220_FriendInvite);
		AddFunc(".FriendInvite", Server_221_FriendInvite);
		AddFunc(".FriendInvite", Server_222_FriendInvite);
		AddFunc(".FriendInvite", Server_223_FriendInvite);
		AddFunc(".FriendInvitedResponse", Server_224_FriendInvitedResponse);
		AddFunc(".FriendInvitedResponseAll", Server_225_FriendInvitedResponseAll);
		AddFunc(".FriendUpdateRecommand", Server_226_FriendUpdateRecommand);
		AddFunc(".FriendSearchName", Server_227_FriendSearchName);
		AddFunc(".FriendSearchNameAlias", Server_228_FriendSearchNameAlias);
		AddFunc(".WatchPlayerProperty", Server_229_WatchPlayerProperty);
		AddFunc(".ReadMail", Server_230_ReadMail);
		AddFunc(".ReadMails", Server_231_ReadMails);
		AddFunc(".ReadAllMail", Server_232_ReadAllMail);
		AddFunc(".DeleteMail", Server_233_DeleteMail);
		AddFunc(".DeleteMails", Server_234_DeleteMails);
		AddFunc(".DeleteAllMail", Server_235_DeleteAllMail);
		AddFunc(".ReceiveMail", Server_236_ReceiveMail);
		AddFunc(".ReceiveMails", Server_237_ReceiveMails);
		AddFunc(".ReceiveAllMail", Server_238_ReceiveAllMail);
		AddFunc(".SendMail", Server_239_SendMail);
		AddFunc(".AddMail", Server_240_AddMail);
		AddFunc(".ClearUpMailbox", Server_241_ClearUpMailbox);
		AddFunc(".ModYinPiao", Server_242_ModYinPiao);
		AddFunc(".BuyYinPiao", Server_243_BuyYinPiao);
		AddFunc(".ModJinPiao", Server_244_ModJinPiao);
		AddFunc(".ModJinZi", Server_245_ModJinZi);
		AddFunc(".TransferJinZi", Server_246_TransferJinZi);
		AddFunc(".TransferJinZi", Server_247_TransferJinZi);
		AddFunc(".AddJinPiaoPaymentRecord", Server_248_AddJinPiaoPaymentRecord);
		AddFunc(".ClearJinPiaoPaymentRecord", Server_249_ClearJinPiaoPaymentRecord);
		AddFunc(".AddJinZiPaymentRecord", Server_250_AddJinZiPaymentRecord);
		AddFunc(".ClearJinZiPaymentRecord", Server_251_ClearJinZiPaymentRecord);
		AddFunc(".AddYinPiaoPaymentRecord", Server_252_AddYinPiaoPaymentRecord);
		AddFunc(".ClearYinPiaoPaymentRecord", Server_253_ClearYinPiaoPaymentRecord);
		AddFunc(".SetPaymentState", Server_254_SetPaymentState);
		AddFunc(".SetPaymentState", Server_255_SetPaymentState);
		AddFunc(".SetPaymentState", Server_256_SetPaymentState);
		AddFunc(".AddStatistics", Server_257_AddStatistics);
		AddFunc(".ClearStatistics", Server_258_ClearStatistics);
		AddFunc(".ClearStatistics", Server_259_ClearStatistics);
		AddFunc(".AddItem", Server_260_AddItem);
		AddFunc(".AddItem", Server_261_AddItem);
		AddFunc(".AddItem", Server_262_AddItem);
		AddFunc(".AddItem", Server_263_AddItem);
		AddFunc(".AddItems", Server_264_AddItems);
		AddFunc(".AddItems", Server_265_AddItems);
		AddFunc(".RevertDelItem", Server_266_RevertDelItem);
		AddFunc(".DelItem", Server_267_DelItem);
		AddFunc(".DestroyItem", Server_268_DestroyItem);
		AddFunc(".DropItem", Server_269_DropItem);
		AddFunc(".ClearBag", Server_270_ClearBag);
		AddFunc(".CopyItem", Server_271_CopyItem);
		AddFunc(".MoveBagItem", Server_272_MoveBagItem);
		AddFunc(".MoveBagItem", Server_273_MoveBagItem);
		AddFunc(".SortBagItem", Server_274_SortBagItem);
		AddFunc(".DrawOutItem", Server_275_DrawOutItem);
		AddFunc(".UseBagItem", Server_276_UseBagItem);
		AddFunc(".UseBagItemTemplate", Server_277_UseBagItemTemplate);
		AddFunc(".UseBagItemTemplate", Server_278_UseBagItemTemplate);
		AddFunc(".UseBagItemTemplate", Server_279_UseBagItemTemplate);
		AddFunc(".AddItemToPackage", Server_280_AddItemToPackage);
		AddFunc(".MoveItemFromPackageToBag", Server_281_MoveItemFromPackageToBag);
		AddFunc(".MoveItemFromPackageToBag", Server_282_MoveItemFromPackageToBag);
		AddFunc(".ClearItemPackage", Server_283_ClearItemPackage);
		AddFunc(".SellItem", Server_284_SellItem);
		AddFunc(".SellItem", Server_285_SellItem);
		AddFunc(".AddSaledItem", Server_286_AddSaledItem);
		AddFunc(".BuyBackItem", Server_287_BuyBackItem);
		AddFunc(".SellPackageItem", Server_288_SellPackageItem);
		AddFunc(".BuyBackPackageItem", Server_289_BuyBackPackageItem);
		AddFunc(".CostItemUseCount", Server_290_CostItemUseCount);
		AddFunc(".SetItemUseCount", Server_291_SetItemUseCount);
		AddFunc(".ClearItemUseCount", Server_292_ClearItemUseCount);
		AddFunc(".ClearItemUseCount", Server_293_ClearItemUseCount);
		AddFunc(".SetItemReceiveCount", Server_294_SetItemReceiveCount);
		AddFunc(".ClearItemReceiveCount", Server_295_ClearItemReceiveCount);
		AddFunc(".ClearItemReceiveCount", Server_296_ClearItemReceiveCount);
		AddFunc(".CostItemReceiveReserveCount", Server_297_CostItemReceiveReserveCount);
		AddFunc(".ItemCompose", Server_298_ItemCompose);
		AddFunc(".DeEquipItem", Server_299_DeEquipItem);
		AddFunc(".DeEquipItem", Server_300_DeEquipItem);
		AddFunc(".TakeItemWithLicence", Server_301_TakeItemWithLicence);
		AddFunc(".AddItemLicenceRecord", Server_302_AddItemLicenceRecord);
		AddFunc(".AddItemLicenceCD", Server_303_AddItemLicenceCD);
		AddFunc(".ClearItemLicenceCD", Server_304_ClearItemLicenceCD);
		AddFunc(".ClearMarketItemBuyCount", Server_305_ClearMarketItemBuyCount);
		AddFunc(".ClearMarketItemBuyCount", Server_306_ClearMarketItemBuyCount);
		AddFunc(".UpdateMarketItem", Server_307_UpdateMarketItem);
		AddFunc(".BuyMarketItem", Server_308_BuyMarketItem);
		AddFunc(".BuyMarketItemToOther", Server_309_BuyMarketItemToOther);
		AddFunc(".SendMarketItemTo", Server_310_SendMarketItemTo);
		AddFunc(".AddStateMask", Server_311_AddStateMask);
		AddFunc(".DelStateMask", Server_312_DelStateMask);
		AddFunc(".AddGoal", Server_313_AddGoal);
		AddFunc(".AddGoal", Server_314_AddGoal);
		AddFunc(".DelGoal", Server_315_DelGoal);
		AddFunc(".DelGoal", Server_316_DelGoal);
		AddFunc(".DelAllGoal", Server_317_DelAllGoal);
		AddFunc(".CompleteGoal", Server_318_CompleteGoal);
		AddFunc(".CompleteGoal", Server_319_CompleteGoal);
		AddFunc(".ResponseGoal", Server_320_ResponseGoal);
		AddFunc(".ClickReward", Server_321_ClickReward);
		AddFunc(".AddGoalReward", Server_322_AddGoalReward);
		AddFunc(".TakeGoalReward", Server_323_TakeGoalReward);
		AddFunc(".TakeGoalAllReward", Server_324_TakeGoalAllReward);
		AddFunc(".EnterStoryModel", Server_325_EnterStoryModel);
		AddFunc(".GoalJumpSpace", Server_326_GoalJumpSpace);
		AddFunc(".TurnInGoal", Server_327_TurnInGoal);
		AddFunc(".JumpGoal", Server_328_JumpGoal);
		AddFunc(".UpdateScoreRankProperty", Server_329_UpdateScoreRankProperty);
		AddFunc(".SetScoreRankScore", Server_330_SetScoreRankScore);
		AddFunc(".ModScoreRankScore", Server_331_ModScoreRankScore);
		AddFunc(".SetScoreRankMatchScore", Server_332_SetScoreRankMatchScore);
		AddFunc(".ModScoreRankMatchScore", Server_333_ModScoreRankMatchScore);
		AddFunc(".SetScoreRankCount", Server_334_SetScoreRankCount);
		AddFunc(".ModScoreRankCount", Server_335_ModScoreRankCount);
		AddFunc(".SetScoreRankWinCount", Server_336_SetScoreRankWinCount);
		AddFunc(".ModScoreRankWinCount", Server_337_ModScoreRankWinCount);
		AddFunc(".SetScoreRankLoseCount", Server_338_SetScoreRankLoseCount);
		AddFunc(".ModScoreRankLoseCount", Server_339_ModScoreRankLoseCount);
		AddFunc(".SetScoreRankContinueWinCount", Server_340_SetScoreRankContinueWinCount);
		AddFunc(".ModScoreRankContinueWinCount", Server_341_ModScoreRankContinueWinCount);
		AddFunc(".SetScoreRankContinueLoseCount", Server_342_SetScoreRankContinueLoseCount);
		AddFunc(".ModScoreRankContinueLoseCount", Server_343_ModScoreRankContinueLoseCount);
		AddFunc(".PrintScoreRankPosition", Server_344_PrintScoreRankPosition);
		AddFunc(".ModPower", Server_345_ModPower);
		AddFunc(".BuyPower", Server_346_BuyPower);
		AddFunc(".TakeLoot", Server_347_TakeLoot);
		AddFunc(".TakeLoot", Server_348_TakeLoot);
		AddFunc(".TakeLoot", Server_349_TakeLoot);
		AddFunc(".MailLoot", Server_350_MailLoot);
		AddFunc(".MailLoot", Server_351_MailLoot);
		AddFunc(".MailLoot", Server_352_MailLoot);
		AddFunc(".PrintLoot", Server_353_PrintLoot);
		AddFunc(".ClearOnceLoot", Server_354_ClearOnceLoot);
		AddFunc(".ClearOnceLoot", Server_355_ClearOnceLoot);
		AddFunc(".AddHero", Server_356_AddHero);
		AddFunc(".AddAllHero", Server_357_AddAllHero);
		AddFunc(".DelHero", Server_358_DelHero);
		AddFunc(".ClearHero", Server_359_ClearHero);
		AddFunc(".TakeHero", Server_360_TakeHero);
		AddFunc(".SetSpaceWorkingHero", Server_361_SetSpaceWorkingHero);
		AddFunc(".SetHeroOwnSpellLevel", Server_362_SetHeroOwnSpellLevel);
		AddFunc(".SetHeroLevel", Server_363_SetHeroLevel);
		AddFunc(".ModHeroLevel", Server_364_ModHeroLevel);
		AddFunc(".ModHeroXP", Server_365_ModHeroXP);
		AddFunc(".UseHeroXPStone", Server_366_UseHeroXPStone);
		AddFunc(".ResetSpell", Server_367_ResetSpell);
		AddFunc(".AddSpell", Server_368_AddSpell);
		AddFunc(".SetupSpell", Server_369_SetupSpell);
		AddFunc(".SwapSpell", Server_370_SwapSpell);
		AddFunc(".OnEvent_KillNPC", Server_371_OnEvent_KillNPC);
		AddFunc(".OnEvent_InteractSpaceObject", Server_372_OnEvent_InteractSpaceObject);
		AddFunc(".OnEvent_SpaceEvent", Server_373_OnEvent_SpaceEvent);
		AddFunc(".OnEvent_SpaceWin", Server_374_OnEvent_SpaceWin);
		AddFunc(".OnEvent_TalkToNPC", Server_375_OnEvent_TalkToNPC);
		AddFunc(".OnEvent_CollectSpaceObject", Server_376_OnEvent_CollectSpaceObject);
		AddFunc(".OnEvent_OpenFunctionUI", Server_377_OnEvent_OpenFunctionUI);
		AddFunc(".OnEvent_JumpSpace", Server_378_OnEvent_JumpSpace);
		AddFunc(".OnEvent_GetItems", Server_379_OnEvent_GetItems);
		AddFunc(".EnterSpaceObjLoadNPC", Server_380_EnterSpaceObjLoadNPC);
		AddFunc(".CompleteHint", Server_381_CompleteHint);
		AddFunc(".ClearHint", Server_382_ClearHint);
		AddFunc(".ClearHint", Server_383_ClearHint);
		AddFunc(".TakeDayGift", Server_384_TakeDayGift);
		AddFunc(".TakeAccumulateLoginReward", Server_385_TakeAccumulateLoginReward);
		AddFunc(".ResetAccumulateLoginReward", Server_386_ResetAccumulateLoginReward);
		AddFunc(".TakeAccumulateLoginInActivityReward", Server_387_TakeAccumulateLoginInActivityReward);
		AddFunc(".ResetAccumulateLoginInActivityReward", Server_388_ResetAccumulateLoginInActivityReward);
		AddFunc(".ResetClientSetting", Server_389_ResetClientSetting);
		AddFunc(".UpdateClientSetting", Server_390_UpdateClientSetting);
		AddFunc("/OnPing", Client_0_OnPing);
		AddFunc("/ShakeCamera", Client_1_ShakeCamera);
		AddFunc("/ShakeCameraSpring", Client_2_ShakeCameraSpring);
		AddFunc("/ShakeCameraRandom", Client_3_ShakeCameraRandom);
		AddFunc("/MessageBox", Client_4_MessageBox);
		AddFunc("/DebugMessage", Client_5_DebugMessage);
		AddFunc("/ContainReserveWord", Client_6_ContainReserveWord);
		AddFunc("/OnReceiveMessage", Client_7_OnReceiveMessage);
		AddFunc("/OnLevelUpdated", Client_8_OnLevelUpdated);
		AddFunc("/OnFuncOpen", Client_9_OnFuncOpen);
		AddFunc("/OnActivityEnter", Client_10_OnActivityEnter);
		AddFunc("/OnActivityExit", Client_11_OnActivityExit);
		AddFunc("/OnUpdateMarketItem", Client_12_OnUpdateMarketItem);
		AddFunc("/OnUpdateItemTradeList", Client_13_OnUpdateItemTradeList);
		AddFunc("/OnAddItemTrade", Client_14_OnAddItemTrade);
		AddFunc("/OnUpdateItemTradeOwnList", Client_15_OnUpdateItemTradeOwnList);
		AddFunc("/OnUpdateItemTradeAuctionList", Client_16_OnUpdateItemTradeAuctionList);
		AddFunc("/OnItemTradeBuySuc", Client_17_OnItemTradeBuySuc);
		AddFunc("/OnGuildListUpdated", Client_18_OnGuildListUpdated);
		AddFunc("/OnGuildSearchResult", Client_19_OnGuildSearchResult);
		AddFunc("/OnGuildApplyRecordUpdated", Client_20_OnGuildApplyRecordUpdated);
		AddFunc("/OnGuildRecommandUpdated", Client_21_OnGuildRecommandUpdated);
		AddFunc("/OnPartyInvite", Client_22_OnPartyInvite);
		AddFunc("/OnPartyDisagreeRequest", Client_23_OnPartyDisagreeRequest);
		AddFunc("/OnPartyFire", Client_24_OnPartyFire);
		AddFunc("/OnPartyDisband", Client_25_OnPartyDisband);
		AddFunc("/OnPartyList", Client_26_OnPartyList);
		AddFunc("/OnGotoBigSpaceWithParty", Client_27_OnGotoBigSpaceWithParty);
		AddFunc("/OnVoteDelPartyMember", Client_28_OnVoteDelPartyMember);
		AddFunc("/OnFriendInvitedStart", Client_29_OnFriendInvitedStart);
		AddFunc("/OnFriendInvitedEnd", Client_30_OnFriendInvitedEnd);
		AddFunc("/OnFriendSearchResult", Client_31_OnFriendSearchResult);
		AddFunc("/OnChatRecordList", Client_32_OnChatRecordList);
		AddFunc("/OnTransferJinZiResult", Client_33_OnTransferJinZiResult);
		AddFunc("/OnNPCLoot", Client_34_OnNPCLoot);
		AddFunc("/OnSmallSpacePVERecordUpdate", Client_35_OnSmallSpacePVERecordUpdate);
		AddFunc("/OnSmallSpacePVEWin", Client_36_OnSmallSpacePVEWin);
		AddFunc("/OnSmallSpacePVELose", Client_37_OnSmallSpacePVELose);
		AddFunc("/OnSmallSpacePVPWin", Client_38_OnSmallSpacePVPWin);
		AddFunc("/OnSmallSpacePVPLose", Client_39_OnSmallSpacePVPLose);
		AddFunc("/OnScoreRankUpdate", Client_40_OnScoreRankUpdate);
		AddFunc("/UIEvent", Client_41_UIEvent);
		AddFunc("/UIEvent", Client_42_UIEvent);
		AddFunc("/OnGoalEndNeedClick", Client_43_OnGoalEndNeedClick);
		AddFunc("/EnterStoryModel", Client_44_EnterStoryModel);
		AddFunc("/ExitStoryModel", Client_45_ExitStoryModel);
	}
	public static new bool Exec(Player entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<Player>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		Player deriveEntity = entity as Player;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void Exec(Player entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_0_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void Exec(Player entity, ViString Script, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_0_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void Exec(Player entity, ViString Script, ViString Param)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_1_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ", " + Param + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void Exec(Player entity, ViString Script, ViString Param, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_1_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ", " + Param + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintMappingValue(Player entity, UInt32 ID, float Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_2_PrintMappingValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintMappingValue(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintMappingValue(Player entity, UInt32 ID, float Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_2_PrintMappingValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintMappingValue(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnPing(Player entity, Int64 Time)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_3_OnPing;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnPing(" + entity  + ", " + Time + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnPing(Player entity, Int64 Time, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_3_OnPing;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnPing(" + entity  + ", " + Time + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetVisualScriptValue(Player entity, ViString Name, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_4_SetVisualScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetVisualScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetVisualScriptValue(Player entity, ViString Name, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_4_SetVisualScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetVisualScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearVisualScriptValue(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_5_ClearVisualScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearVisualScriptValue(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearVisualScriptValue(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_5_ClearVisualScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearVisualScriptValue(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPresistentScriptValue(Player entity, ViString Name, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_6_SetPresistentScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPresistentScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPresistentScriptValue(Player entity, ViString Name, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_6_SetPresistentScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPresistentScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearPresistentScriptValue(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_7_ClearPresistentScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearPresistentScriptValue(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearPresistentScriptValue(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_7_ClearPresistentScriptValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearPresistentScriptValue(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPhoto(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_10_AddPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPhoto(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddPhoto(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_10_AddPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPhoto(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPhoto(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_11_DelPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPhoto(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelPhoto(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_11_DelPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPhoto(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearPhoto(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_12_ClearPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearPhoto(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearPhoto(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_12_ClearPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearPhoto(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModLevel(Player entity, Int16 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_13_ModLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModLevel(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModLevel(Player entity, Int16 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_13_ModLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModLevel(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModXP(Player entity, Int64 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_14_ModXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModXP(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModXP(Player entity, Int64 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_14_ModXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModXP(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetAccumulateLoginDayCount(Player entity, Int16 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_15_SetAccumulateLoginDayCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetAccumulateLoginDayCount(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetAccumulateLoginDayCount(Player entity, Int16 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_15_SetAccumulateLoginDayCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetAccumulateLoginDayCount(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModAccumulateLoginDayCount(Player entity, Int16 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_16_ModAccumulateLoginDayCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModAccumulateLoginDayCount(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModAccumulateLoginDayCount(Player entity, Int16 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_16_ModAccumulateLoginDayCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModAccumulateLoginDayCount(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetAccumulateOnlineDuration(Player entity, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_17_SetAccumulateOnlineDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetAccumulateOnlineDuration(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetAccumulateOnlineDuration(Player entity, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_17_SetAccumulateOnlineDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetAccumulateOnlineDuration(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModAccumulateOnlineDuration(Player entity, Int64 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_18_ModAccumulateOnlineDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModAccumulateOnlineDuration(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModAccumulateOnlineDuration(Player entity, Int64 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_18_ModAccumulateOnlineDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModAccumulateOnlineDuration(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetDayOnlineDuration(Player entity, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_19_SetDayOnlineDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetDayOnlineDuration(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetDayOnlineDuration(Player entity, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_19_SetDayOnlineDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetDayOnlineDuration(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddLoginStreak(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_20_AddLoginStreak;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddLoginStreak(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddLoginStreak(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_20_AddLoginStreak;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddLoginStreak(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetLoginStreak(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_21_ResetLoginStreak;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetLoginStreak(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetLoginStreak(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_21_ResetLoginStreak;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetLoginStreak(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnNewDay(Player entity, Int16 DeltaDay)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_22_OnNewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewDay(" + entity  + ", " + DeltaDay + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaDay);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnNewDay(Player entity, Int16 DeltaDay, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_22_OnNewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewDay(" + entity  + ", " + DeltaDay + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaDay);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnNewWeek(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_23_OnNewWeek;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewWeek(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnNewWeek(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_23_OnNewWeek;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewWeek(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnNewMonth(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_24_OnNewMonth;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewMonth(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnNewMonth(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_24_OnNewMonth;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewMonth(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_25_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_25_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_26_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_26_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintComponentProperty(Player entity, ViString Component)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_27_PrintComponentProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintComponentProperty(" + entity  + ", " + Component + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintComponentProperty(Player entity, ViString Component, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_27_PrintComponentProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintComponentProperty(" + entity  + ", " + Component + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintComponentProperty(Player entity, ViString Name, ViString Component)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_28_PrintComponentProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintComponentProperty(" + entity  + ", " + Name + ", " + Component + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintComponentProperty(Player entity, ViString Name, ViString Component, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_28_PrintComponentProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintComponentProperty(" + entity  + ", " + Name + ", " + Component + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintAccountProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_29_PrintAccountProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintAccountProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintAccountProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_29_PrintAccountProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintAccountProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintAccountProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_30_PrintAccountProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintAccountProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintAccountProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_30_PrintAccountProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintAccountProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintGuildProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_31_PrintGuildProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGuildProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintGuildProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_31_PrintGuildProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGuildProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintGuildProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_32_PrintGuildProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGuildProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintGuildProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_32_PrintGuildProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGuildProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintPublicSpaceEnterProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_33_PrintPublicSpaceEnterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPublicSpaceEnterProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintPublicSpaceEnterProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_33_PrintPublicSpaceEnterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPublicSpaceEnterProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintPublicSpaceEnterProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_34_PrintPublicSpaceEnterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPublicSpaceEnterProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintPublicSpaceEnterProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_34_PrintPublicSpaceEnterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPublicSpaceEnterProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintPartyProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_35_PrintPartyProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPartyProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintPartyProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_35_PrintPartyProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPartyProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintPartyProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_36_PrintPartyProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPartyProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintPartyProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_36_PrintPartyProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintPartyProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintSpaceMatchEnterGroupProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_37_PrintSpaceMatchEnterGroupProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceMatchEnterGroupProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintSpaceMatchEnterGroupProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_37_PrintSpaceMatchEnterGroupProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceMatchEnterGroupProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintSpaceMatchEnterGroupProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_38_PrintSpaceMatchEnterGroupProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceMatchEnterGroupProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintSpaceMatchEnterGroupProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_38_PrintSpaceMatchEnterGroupProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintSpaceMatchEnterGroupProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintActivityProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_39_PrintActivityProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintActivityProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintActivityProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_39_PrintActivityProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintActivityProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintGlobalProperty(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_40_PrintGlobalProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintGlobalProperty(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_40_PrintGlobalProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CopyPropertyFrom(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_41_CopyPropertyFrom;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyPropertyFrom(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CopyPropertyFrom(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_41_CopyPropertyFrom;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyPropertyFrom(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CopyPropertyFrom(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_42_CopyPropertyFrom;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyPropertyFrom(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CopyPropertyFrom(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_42_CopyPropertyFrom;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyPropertyFrom(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearClientWatchIgnore(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_44_ClearClientWatchIgnore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearClientWatchIgnore(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearClientWatchIgnore(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_44_ClearClientWatchIgnore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearClientWatchIgnore(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterPrivateSpace(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_45_EnterPrivateSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPrivateSpace(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterPrivateSpace(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_45_EnterPrivateSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPrivateSpace(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterBigSpace(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_48_EnterBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterBigSpace(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterBigSpace(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_48_EnterBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterBigSpace(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterBigSpace(Player entity, UInt32 Space, ViVector3 Pos)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_49_EnterBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterBigSpace(" + entity  + ", " + Space + ", " + Pos + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterBigSpace(Player entity, UInt32 Space, ViVector3 Pos, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_49_EnterBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterBigSpace(" + entity  + ", " + Space + ", " + Pos + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitSpace(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_50_ExitSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitSpace(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExitSpace(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_50_ExitSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitSpace(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitSpace(Player entity, Int32 Delay)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_51_ExitSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitSpace(" + entity  + ", " + Delay + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Delay);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExitSpace(Player entity, Int32 Delay, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_51_ExitSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitSpace(" + entity  + ", " + Delay + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Delay);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSpaceEnter(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_52_OnSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSpaceEnter(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSpaceEnter(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_52_OnSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSpaceEnter(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpaceEvent(Player entity, UInt32 Space, UInt32 Event)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_53_OnSmallSpaceEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceEvent(" + entity  + ", " + Space + ", " + Event + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSmallSpaceEvent(Player entity, UInt32 Space, UInt32 Event, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_53_OnSmallSpaceEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceEvent(" + entity  + ", " + Space + ", " + Event + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpaceResult(Player entity, UInt32 Space, UInt8 Result, HashSet<ViString> ScriptList, Dictionary<ViString, Int64Property> ScriptValueList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_54_OnSmallSpaceResult;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceResult(" + entity  + ", " + Space + ", " + Result + ", " + ScriptList + ", " + ScriptValueList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ScriptList);
		ViGameSerializer<Int64Property>.Append(entity.RPC.OS, ScriptValueList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSmallSpaceResult(Player entity, UInt32 Space, UInt8 Result, HashSet<ViString> ScriptList, Dictionary<ViString, Int64Property> ScriptValueList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_54_OnSmallSpaceResult;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpaceResult(" + entity  + ", " + Space + ", " + Result + ", " + ScriptList + ", " + ScriptValueList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ScriptList);
		ViGameSerializer<Int64Property>.Append(entity.RPC.OS, ScriptValueList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpacePVEWin(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_55_OnSmallSpacePVEWin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVEWin(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSmallSpacePVEWin(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_55_OnSmallSpacePVEWin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVEWin(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpacePVELose(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_56_OnSmallSpacePVELose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVELose(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSmallSpacePVELose(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_56_OnSmallSpacePVELose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVELose(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpacePVPWin(Player entity, UInt32 Space, Int32 RankScore)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_57_OnSmallSpacePVPWin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVPWin(" + entity  + ", " + Space + ", " + RankScore + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, RankScore);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSmallSpacePVPWin(Player entity, UInt32 Space, Int32 RankScore, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_57_OnSmallSpacePVPWin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVPWin(" + entity  + ", " + Space + ", " + RankScore + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, RankScore);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnSmallSpacePVPLose(Player entity, UInt32 Space, Int32 RankScore)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_58_OnSmallSpacePVPLose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVPLose(" + entity  + ", " + Space + ", " + RankScore + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, RankScore);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnSmallSpacePVPLose(Player entity, UInt32 Space, Int32 RankScore, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_58_OnSmallSpacePVPLose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSmallSpacePVPLose(" + entity  + ", " + Space + ", " + RankScore + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, RankScore);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateSpaceRecord(Player entity, UInt32 Space, SpaceRecordProperty Record)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_59_UpdateSpaceRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateSpaceRecord(" + entity  + ", " + Space + ", " + Record + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<SpaceRecordProperty>.Append(entity.RPC.OS, Record);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateSpaceRecord(Player entity, UInt32 Space, SpaceRecordProperty Record, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_59_UpdateSpaceRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateSpaceRecord(" + entity  + ", " + Space + ", " + Record + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<SpaceRecordProperty>.Append(entity.RPC.OS, Record);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SaveCellProperty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_60_SaveCellProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SaveCellProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SaveCellProperty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_60_SaveCellProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SaveCellProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnCellHeroStart(Player entity, UInt64 ID, UInt32 PackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_61_OnCellHeroStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnCellHeroStart(" + entity  + ", " + ID + ", " + PackID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, PackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnCellHeroStart(Player entity, UInt64 ID, UInt32 PackID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_61_OnCellHeroStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnCellHeroStart(" + entity  + ", " + ID + ", " + PackID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, PackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnCellHeroEnd(Player entity, UInt64 ID, UInt32 PackID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_62_OnCellHeroEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnCellHeroEnd(" + entity  + ", " + ID + ", " + PackID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, PackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnCellHeroEnd(Player entity, UInt64 ID, UInt32 PackID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_62_OnCellHeroEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnCellHeroEnd(" + entity  + ", " + ID + ", " + PackID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, PackID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetLastSmallSpace(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_63_SetLastSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetLastSmallSpace(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetLastSmallSpace(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_63_SetLastSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetLastSmallSpace(" + entity  + ", " + Space + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNPCLoot(Player entity, UInt32 NPCPackedID, Int16 NPCLevel, UInt8 ReceiveImmediate, UInt32 Loot, Int32 YinPiao, Int32 XP)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_64_AddNPCLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPCLoot(" + entity  + ", " + NPCPackedID + ", " + NPCLevel + ", " + ReceiveImmediate + ", " + Loot + ", " + YinPiao + ", " + XP + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPCPackedID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, NPCLevel);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ReceiveImmediate);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, YinPiao);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, XP);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddNPCLoot(Player entity, UInt32 NPCPackedID, Int16 NPCLevel, UInt8 ReceiveImmediate, UInt32 Loot, Int32 YinPiao, Int32 XP, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_64_AddNPCLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNPCLoot(" + entity  + ", " + NPCPackedID + ", " + NPCLevel + ", " + ReceiveImmediate + ", " + Loot + ", " + YinPiao + ", " + XP + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPCPackedID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, NPCLevel);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ReceiveImmediate);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, YinPiao);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, XP);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSpaceLoot(Player entity, Int16 Level, UInt8 ReceiveImmediate, UInt32 Loot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_65_AddSpaceLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceLoot(" + entity  + ", " + Level + ", " + ReceiveImmediate + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ReceiveImmediate);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddSpaceLoot(Player entity, Int16 Level, UInt8 ReceiveImmediate, UInt32 Loot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_65_AddSpaceLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceLoot(" + entity  + ", " + Level + ", " + ReceiveImmediate + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ReceiveImmediate);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSpaceLootScore(Player entity, UInt32 ID, Int32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_66_AddSpaceLootScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceLootScore(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddSpaceLootScore(Player entity, UInt32 ID, Int32 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_66_AddSpaceLootScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceLootScore(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSpaceChangableMask(Player entity, ViString Name, Int32 Weight, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_67_AddSpaceChangableMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceChangableMask(" + entity  + ", " + Name + ", " + Weight + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddSpaceChangableMask(Player entity, ViString Name, Int32 Weight, UInt8 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_67_AddSpaceChangableMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpaceChangableMask(" + entity  + ", " + Name + ", " + Weight + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelSpaceChangableMask(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_68_DelSpaceChangableMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSpaceChangableMask(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelSpaceChangableMask(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_68_DelSpaceChangableMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelSpaceChangableMask(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EndCellPlayer(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_69_EndCellPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndCellPlayer(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EndCellPlayer(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_69_EndCellPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndCellPlayer(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetChatEndTime(Player entity, Int32 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_80_SetChatEndTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetChatEndTime(" + entity  + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetChatEndTime(Player entity, Int32 Duration, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_80_SetChatEndTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetChatEndTime(" + entity  + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OpenFunc(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_94_OpenFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OpenFunc(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OpenFunc(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_94_OpenFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OpenFunc(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CloseFunc(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_95_CloseFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseFunc(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CloseFunc(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_95_CloseFunc;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseFunc(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddFuncPolicy(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_96_AddFuncPolicy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFuncPolicy(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddFuncPolicy(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_96_AddFuncPolicy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFuncPolicy(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelFuncPolicy(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_97_DelFuncPolicy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFuncPolicy(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelFuncPolicy(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_97_DelFuncPolicy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFuncPolicy(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearFuncPolicy(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_98_ClearFuncPolicy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearFuncPolicy(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearFuncPolicy(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_98_ClearFuncPolicy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearFuncPolicy(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModActivityEnterCount(Player entity, UInt32 Activity, Int16 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_101_ModActivityEnterCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModActivityEnterCount(" + entity  + ", " + Activity + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Activity);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModActivityEnterCount(Player entity, UInt32 Activity, Int16 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_101_ModActivityEnterCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModActivityEnterCount(" + entity  + ", " + Activity + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Activity);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScore(Player entity, UInt32 ID, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_102_ModScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScore(" + entity  + ", " + ID + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScore(Player entity, UInt32 ID, Int32 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_102_ModScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScore(" + entity  + ", " + ID + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddCoolingDown(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_104_AddCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddCoolingDown(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddCoolingDown(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_104_AddCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddCoolingDown(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelCoolingDown(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_105_DelCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelCoolingDown(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelCoolingDown(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_105_DelCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelCoolingDown(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelAllCoolingDown(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_106_DelAllCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelAllCoolingDown(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelAllCoolingDown(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_106_DelAllCoolingDown;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelAllCoolingDown(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddScriptDuration(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_107_AddScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddScriptDuration(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddScriptDuration(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_107_AddScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddScriptDuration(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScriptDuration(Player entity, UInt32 ID, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_108_SetScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScriptDuration(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScriptDuration(Player entity, UInt32 ID, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_108_SetScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScriptDuration(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScriptDuration(Player entity, UInt32 ID, Int64 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_109_ModScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScriptDuration(" + entity  + ", " + ID + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScriptDuration(Player entity, UInt32 ID, Int64 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_109_ModScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScriptDuration(" + entity  + ", " + ID + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelScriptDuration(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_110_DelScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelScriptDuration(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelScriptDuration(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_110_DelScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelScriptDuration(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelAllScriptDuration(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_111_DelAllScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelAllScriptDuration(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelAllScriptDuration(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_111_DelAllScriptDuration;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelAllScriptDuration(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CommitTradeItemTime(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_120_CommitTradeItemTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CommitTradeItemTime(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CommitTradeItemTime(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_120_CommitTradeItemTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CommitTradeItemTime(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RevertItemTradeRecord(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_123_RevertItemTradeRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RevertItemTradeRecord(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RevertItemTradeRecord(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_123_RevertItemTradeRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RevertItemTradeRecord(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearDailyItemTradeOutCount(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_124_ClearDailyItemTradeOutCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDailyItemTradeOutCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearDailyItemTradeOutCount(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_124_ClearDailyItemTradeOutCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDailyItemTradeOutCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearDailyItemTradeOutCount(Player entity, UInt32 Item)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_125_ClearDailyItemTradeOutCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDailyItemTradeOutCount(" + entity  + ", " + Item + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearDailyItemTradeOutCount(Player entity, UInt32 Item, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_125_ClearDailyItemTradeOutCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearDailyItemTradeOutCount(" + entity  + ", " + Item + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CostItemTradeReserveCount(Player entity, UInt32 ID, Int32 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_126_CostItemTradeReserveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CostItemTradeReserveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CostItemTradeReserveCount(Player entity, UInt32 ID, Int32 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_126_CostItemTradeReserveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CostItemTradeReserveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterGuild(Player entity, ViString Guild)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_140_EnterGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterGuild(" + entity  + ", " + Guild + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Guild);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterGuild(Player entity, ViString Guild, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_140_EnterGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterGuild(" + entity  + ", " + Guild + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Guild);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildLeader(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_144_SetGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLeader(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildLeader(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_144_SetGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLeader(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildLeader(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_145_SetGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLeader(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildLeader(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_145_SetGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLeader(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildLeader(Player entity, ViString Guild, ViString Entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_146_SetGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLeader(" + entity  + ", " + Guild + ", " + Entity + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Guild);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildLeader(Player entity, ViString Guild, ViString Entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_146_SetGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLeader(" + entity  + ", " + Guild + ", " + Entity + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Guild);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildLevel(Player entity, Int16 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_150_SetGuildLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLevel(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildLevel(Player entity, Int16 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_150_SetGuildLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildLevel(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModGuildXP(Player entity, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_151_ModGuildXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModGuildXP(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModGuildXP(Player entity, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_151_ModGuildXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModGuildXP(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildActivityEnterProperty(Player entity, UInt32 ID, Int16 EnterCount, Int16 BuyCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_168_SetGuildActivityEnterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildActivityEnterProperty(" + entity  + ", " + ID + ", " + EnterCount + ", " + BuyCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, EnterCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, BuyCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildActivityEnterProperty(Player entity, UInt32 ID, Int16 EnterCount, Int16 BuyCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_168_SetGuildActivityEnterProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildActivityEnterProperty(" + entity  + ", " + ID + ", " + EnterCount + ", " + BuyCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, EnterCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, BuyCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPartyPartnerRecord(Player entity, ViString Entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_169_AddPartyPartnerRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPartyPartnerRecord(" + entity  + ", " + Entity + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddPartyPartnerRecord(Player entity, ViString Entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_169_AddPartyPartnerRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPartyPartnerRecord(" + entity  + ", " + Entity + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPartyPartnerRecord(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_170_DelPartyPartnerRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyPartnerRecord(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelPartyPartnerRecord(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_170_DelPartyPartnerRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyPartnerRecord(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearPartyPartnerRecord(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_171_ClearPartyPartnerRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearPartyPartnerRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearPartyPartnerRecord(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_171_ClearPartyPartnerRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearPartyPartnerRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterParty(Player entity, ViString Entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_188_EnterParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterParty(" + entity  + ", " + Entity + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterParty(Player entity, ViString Entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_188_EnterParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterParty(" + entity  + ", " + Entity + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddFriend(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_209_AddFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFriend(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddFriend(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_209_AddFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFriend(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddFriend(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_210_AddFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFriend(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddFriend(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_210_AddFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddFriend(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddMail(Player entity, MailProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_240_AddMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMail(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddMail(Player entity, MailProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_240_AddMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddMail(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModYinPiao(Player entity, Int64 DeltaMoney)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_242_ModYinPiao;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModYinPiao(" + entity  + ", " + DeltaMoney + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModYinPiao(Player entity, Int64 DeltaMoney, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_242_ModYinPiao;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModYinPiao(" + entity  + ", " + DeltaMoney + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModJinPiao(Player entity, Int64 DeltaMoney)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_244_ModJinPiao;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModJinPiao(" + entity  + ", " + DeltaMoney + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModJinPiao(Player entity, Int64 DeltaMoney, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_244_ModJinPiao;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModJinPiao(" + entity  + ", " + DeltaMoney + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModJinZi(Player entity, Int64 DeltaMoney)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_245_ModJinZi;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModJinZi(" + entity  + ", " + DeltaMoney + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModJinZi(Player entity, Int64 DeltaMoney, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_245_ModJinZi;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModJinZi(" + entity  + ", " + DeltaMoney + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddJinPiaoPaymentRecord(Player entity, UInt32 ID, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_248_AddJinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddJinPiaoPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddJinPiaoPaymentRecord(Player entity, UInt32 ID, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_248_AddJinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddJinPiaoPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearJinPiaoPaymentRecord(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_249_ClearJinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearJinPiaoPaymentRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearJinPiaoPaymentRecord(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_249_ClearJinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearJinPiaoPaymentRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddJinZiPaymentRecord(Player entity, UInt32 ID, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_250_AddJinZiPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddJinZiPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddJinZiPaymentRecord(Player entity, UInt32 ID, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_250_AddJinZiPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddJinZiPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearJinZiPaymentRecord(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_251_ClearJinZiPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearJinZiPaymentRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearJinZiPaymentRecord(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_251_ClearJinZiPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearJinZiPaymentRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddYinPiaoPaymentRecord(Player entity, UInt32 ID, Int64 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_252_AddYinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddYinPiaoPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddYinPiaoPaymentRecord(Player entity, UInt32 ID, Int64 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_252_AddYinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddYinPiaoPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearYinPiaoPaymentRecord(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_253_ClearYinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearYinPiaoPaymentRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearYinPiaoPaymentRecord(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_253_ClearYinPiaoPaymentRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearYinPiaoPaymentRecord(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddStatistics(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_257_AddStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddStatistics(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddStatistics(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_257_AddStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddStatistics(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearStatistics(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_258_ClearStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearStatistics(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearStatistics(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_258_ClearStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearStatistics(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearStatistics(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_259_ClearStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearStatistics(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearStatistics(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_259_ClearStatistics;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearStatistics(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItem(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_262_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItem(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_262_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItem(Player entity, ViString Name, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_263_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Name + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItem(Player entity, ViString Name, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_263_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Name + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItems(Player entity, UInt32 TemplateInf, UInt32 TemplateSup)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_264_AddItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItems(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItems(Player entity, UInt32 TemplateInf, UInt32 TemplateSup, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_264_AddItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItems(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItems(Player entity, UInt32 TemplateInf, UInt32 TemplateSup, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_265_AddItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItems(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItems(Player entity, UInt32 TemplateInf, UInt32 TemplateSup, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_265_AddItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItems(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RevertDelItem(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_266_RevertDelItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RevertDelItem(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RevertDelItem(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_266_RevertDelItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RevertDelItem(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DestroyItem(Player entity, UInt8 Bag, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_268_DestroyItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DestroyItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DestroyItem(Player entity, UInt8 Bag, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_268_DestroyItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DestroyItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearBag(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_270_ClearBag;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearBag(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearBag(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_270_ClearBag;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearBag(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CopyItem(Player entity, UInt8 Bag, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_271_CopyItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CopyItem(Player entity, UInt8 Bag, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_271_CopyItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CopyItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItemToPackage(Player entity, UInt32 Template, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_280_AddItemToPackage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemToPackage(" + entity  + ", " + Template + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItemToPackage(Player entity, UInt32 Template, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_280_AddItemToPackage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemToPackage(" + entity  + ", " + Template + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemPackage(Player entity, UInt8 Notify)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_283_ClearItemPackage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemPackage(" + entity  + ", " + Notify + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Notify);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearItemPackage(Player entity, UInt8 Notify, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_283_ClearItemPackage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemPackage(" + entity  + ", " + Notify + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Notify);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSaledItem(Player entity, ItemProperty Item)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_286_AddSaledItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSaledItem(" + entity  + ", " + Item + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ItemProperty>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddSaledItem(Player entity, ItemProperty Item, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_286_AddSaledItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSaledItem(" + entity  + ", " + Item + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ItemProperty>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CostItemUseCount(Player entity, UInt32 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_290_CostItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CostItemUseCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CostItemUseCount(Player entity, UInt32 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_290_CostItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CostItemUseCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetItemUseCount(Player entity, UInt32 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_291_SetItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetItemUseCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetItemUseCount(Player entity, UInt32 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_291_SetItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetItemUseCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemUseCount(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_292_ClearItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemUseCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearItemUseCount(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_292_ClearItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemUseCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemUseCount(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_293_ClearItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemUseCount(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearItemUseCount(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_293_ClearItemUseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemUseCount(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetItemReceiveCount(Player entity, UInt32 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_294_SetItemReceiveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetItemReceiveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetItemReceiveCount(Player entity, UInt32 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_294_SetItemReceiveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetItemReceiveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemReceiveCount(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_295_ClearItemReceiveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemReceiveCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearItemReceiveCount(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_295_ClearItemReceiveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemReceiveCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemReceiveCount(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_296_ClearItemReceiveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemReceiveCount(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearItemReceiveCount(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_296_ClearItemReceiveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemReceiveCount(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CostItemReceiveReserveCount(Player entity, UInt32 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_297_CostItemReceiveReserveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CostItemReceiveReserveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CostItemReceiveReserveCount(Player entity, UInt32 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_297_CostItemReceiveReserveCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CostItemReceiveReserveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItemLicenceRecord(Player entity, ViString Licence, UInt32 Item, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_302_AddItemLicenceRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemLicenceRecord(" + entity  + ", " + Licence + ", " + Item + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Licence);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItemLicenceRecord(Player entity, ViString Licence, UInt32 Item, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_302_AddItemLicenceRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemLicenceRecord(" + entity  + ", " + Licence + ", " + Item + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Licence);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItemLicenceCD(Player entity, UInt32 Item, Int32 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_303_AddItemLicenceCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemLicenceCD(" + entity  + ", " + Item + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItemLicenceCD(Player entity, UInt32 Item, Int32 Duration, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_303_AddItemLicenceCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemLicenceCD(" + entity  + ", " + Item + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearItemLicenceCD(Player entity, UInt32 Item)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_304_ClearItemLicenceCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemLicenceCD(" + entity  + ", " + Item + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearItemLicenceCD(Player entity, UInt32 Item, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_304_ClearItemLicenceCD;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearItemLicenceCD(" + entity  + ", " + Item + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearMarketItemBuyCount(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_305_ClearMarketItemBuyCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearMarketItemBuyCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearMarketItemBuyCount(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_305_ClearMarketItemBuyCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearMarketItemBuyCount(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearMarketItemBuyCount(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_306_ClearMarketItemBuyCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearMarketItemBuyCount(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearMarketItemBuyCount(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_306_ClearMarketItemBuyCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearMarketItemBuyCount(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SendMarketItemTo(Player entity, UInt64 ReceiverID, UInt32 Item, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_310_SendMarketItemTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMarketItemTo(" + entity  + ", " + ReceiverID + ", " + Item + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ReceiverID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SendMarketItemTo(Player entity, UInt64 ReceiverID, UInt32 Item, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_310_SendMarketItemTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMarketItemTo(" + entity  + ", " + ReceiverID + ", " + Item + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ReceiverID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddStateMask(Player entity, ViString Name, UInt32 Mask)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_311_AddStateMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddStateMask(" + entity  + ", " + Name + ", " + Mask + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Mask);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddStateMask(Player entity, ViString Name, UInt32 Mask, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_311_AddStateMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddStateMask(" + entity  + ", " + Name + ", " + Mask + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Mask);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelStateMask(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_312_DelStateMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelStateMask(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelStateMask(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_312_DelStateMask;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelStateMask(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGoal(Player entity, UInt32 IDInf, UInt32 IDSup)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_314_AddGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddGoal(Player entity, UInt32 IDInf, UInt32 IDSup, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_314_AddGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelGoal(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_315_DelGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGoal(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelGoal(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_315_DelGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGoal(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelGoal(Player entity, UInt32 IDInf, UInt32 IDSup)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_316_DelGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelGoal(Player entity, UInt32 IDInf, UInt32 IDSup, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_316_DelGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelAllGoal(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_317_DelAllGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelAllGoal(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelAllGoal(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_317_DelAllGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelAllGoal(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CompleteGoal(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_318_CompleteGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteGoal(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CompleteGoal(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_318_CompleteGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteGoal(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CompleteGoal(Player entity, UInt32 IDInf, UInt32 IDSup)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_319_CompleteGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CompleteGoal(Player entity, UInt32 IDInf, UInt32 IDSup, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_319_CompleteGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGoalReward(Player entity, UInt32 Template)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_322_AddGoalReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGoalReward(" + entity  + ", " + Template + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddGoalReward(Player entity, UInt32 Template, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_322_AddGoalReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGoalReward(" + entity  + ", " + Template + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void JumpGoal(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_328_JumpGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> JumpGoal(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void JumpGoal(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_328_JumpGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> JumpGoal(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateScoreRankProperty(Player entity, UInt32 Rank, ScoreRankStasticsProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_329_UpdateScoreRankProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateScoreRankProperty(" + entity  + ", " + Rank + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<ScoreRankStasticsProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateScoreRankProperty(Player entity, UInt32 Rank, ScoreRankStasticsProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_329_UpdateScoreRankProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateScoreRankProperty(" + entity  + ", " + Rank + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<ScoreRankStasticsProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankScore(Player entity, UInt32 Rank, Int32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_330_SetScoreRankScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankScore(" + entity  + ", " + Rank + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankScore(Player entity, UInt32 Rank, Int32 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_330_SetScoreRankScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankScore(" + entity  + ", " + Rank + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankScore(Player entity, UInt32 Rank, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_331_ModScoreRankScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankScore(" + entity  + ", " + Rank + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankScore(Player entity, UInt32 Rank, Int32 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_331_ModScoreRankScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankScore(" + entity  + ", " + Rank + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankMatchScore(Player entity, UInt32 Rank, Int32 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_332_SetScoreRankMatchScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankMatchScore(" + entity  + ", " + Rank + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankMatchScore(Player entity, UInt32 Rank, Int32 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_332_SetScoreRankMatchScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankMatchScore(" + entity  + ", " + Rank + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankMatchScore(Player entity, UInt32 Rank, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_333_ModScoreRankMatchScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankMatchScore(" + entity  + ", " + Rank + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankMatchScore(Player entity, UInt32 Rank, Int32 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_333_ModScoreRankMatchScore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankMatchScore(" + entity  + ", " + Rank + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankCount(Player entity, UInt32 Rank, Int32 TotalCount, Int32 VersionCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_334_SetScoreRankCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankCount(Player entity, UInt32 Rank, Int32 TotalCount, Int32 VersionCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_334_SetScoreRankCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankCount(Player entity, UInt32 Rank, Int32 DeltaCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_335_ModScoreRankCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankCount(Player entity, UInt32 Rank, Int32 DeltaCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_335_ModScoreRankCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankWinCount(Player entity, UInt32 Rank, Int32 TotalCount, Int32 VersionCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_336_SetScoreRankWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankWinCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankWinCount(Player entity, UInt32 Rank, Int32 TotalCount, Int32 VersionCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_336_SetScoreRankWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankWinCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankWinCount(Player entity, UInt32 Rank, Int32 DeltaCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_337_ModScoreRankWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankWinCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankWinCount(Player entity, UInt32 Rank, Int32 DeltaCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_337_ModScoreRankWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankWinCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankLoseCount(Player entity, UInt32 Rank, Int32 TotalCount, Int32 VersionCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_338_SetScoreRankLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankLoseCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankLoseCount(Player entity, UInt32 Rank, Int32 TotalCount, Int32 VersionCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_338_SetScoreRankLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankLoseCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankLoseCount(Player entity, UInt32 Rank, Int32 DeltaCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_339_ModScoreRankLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankLoseCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankLoseCount(Player entity, UInt32 Rank, Int32 DeltaCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_339_ModScoreRankLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankLoseCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankContinueWinCount(Player entity, UInt32 Rank, Int32 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_340_SetScoreRankContinueWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankContinueWinCount(" + entity  + ", " + Rank + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankContinueWinCount(Player entity, UInt32 Rank, Int32 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_340_SetScoreRankContinueWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankContinueWinCount(" + entity  + ", " + Rank + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankContinueWinCount(Player entity, UInt32 Rank, Int32 DeltaCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_341_ModScoreRankContinueWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankContinueWinCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankContinueWinCount(Player entity, UInt32 Rank, Int32 DeltaCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_341_ModScoreRankContinueWinCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankContinueWinCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetScoreRankContinueLoseCount(Player entity, UInt32 Rank, Int32 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_342_SetScoreRankContinueLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankContinueLoseCount(" + entity  + ", " + Rank + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetScoreRankContinueLoseCount(Player entity, UInt32 Rank, Int32 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_342_SetScoreRankContinueLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetScoreRankContinueLoseCount(" + entity  + ", " + Rank + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModScoreRankContinueLoseCount(Player entity, UInt32 Rank, Int32 DeltaCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_343_ModScoreRankContinueLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankContinueLoseCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModScoreRankContinueLoseCount(Player entity, UInt32 Rank, Int32 DeltaCount, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_343_ModScoreRankContinueLoseCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModScoreRankContinueLoseCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintScoreRankPosition(Player entity, UInt32 Rank, Int32 Score)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_344_PrintScoreRankPosition;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintScoreRankPosition(" + entity  + ", " + Rank + ", " + Score + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Score);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintScoreRankPosition(Player entity, UInt32 Rank, Int32 Score, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_344_PrintScoreRankPosition;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintScoreRankPosition(" + entity  + ", " + Rank + ", " + Score + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Score);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModPower(Player entity, Int16 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_345_ModPower;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModPower(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModPower(Player entity, Int16 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_345_ModPower;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModPower(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeLoot(Player entity, UInt32 Loot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_347_TakeLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeLoot(" + entity  + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeLoot(Player entity, UInt32 Loot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_347_TakeLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeLoot(" + entity  + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeLoot(Player entity, UInt32 Loot, float Scale)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_348_TakeLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeLoot(" + entity  + ", " + Loot + ", " + Scale + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeLoot(Player entity, UInt32 Loot, float Scale, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_348_TakeLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeLoot(" + entity  + ", " + Loot + ", " + Scale + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeLoot(Player entity, UInt32 Loot, float Scale, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_349_TakeLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeLoot(" + entity  + ", " + Loot + ", " + Scale + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeLoot(Player entity, UInt32 Loot, float Scale, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_349_TakeLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeLoot(" + entity  + ", " + Loot + ", " + Scale + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MailLoot(Player entity, UInt32 Loot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_350_MailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MailLoot(" + entity  + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void MailLoot(Player entity, UInt32 Loot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_350_MailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MailLoot(" + entity  + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MailLoot(Player entity, UInt32 Loot, float Scale)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_351_MailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MailLoot(" + entity  + ", " + Loot + ", " + Scale + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void MailLoot(Player entity, UInt32 Loot, float Scale, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_351_MailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MailLoot(" + entity  + ", " + Loot + ", " + Scale + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MailLoot(Player entity, UInt32 Loot, float Scale, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_352_MailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MailLoot(" + entity  + ", " + Loot + ", " + Scale + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void MailLoot(Player entity, UInt32 Loot, float Scale, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_352_MailLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MailLoot(" + entity  + ", " + Loot + ", " + Scale + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintLoot(Player entity, UInt32 Loot, Int16 Level, float Scale, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_353_PrintLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintLoot(" + entity  + ", " + Loot + ", " + Level + ", " + Scale + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintLoot(Player entity, UInt32 Loot, Int16 Level, float Scale, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_353_PrintLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintLoot(" + entity  + ", " + Loot + ", " + Level + ", " + Scale + ", " + Count + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearOnceLoot(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_354_ClearOnceLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOnceLoot(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearOnceLoot(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_354_ClearOnceLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOnceLoot(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearOnceLoot(Player entity, UInt32 Loot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_355_ClearOnceLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOnceLoot(" + entity  + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearOnceLoot(Player entity, UInt32 Loot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_355_ClearOnceLoot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOnceLoot(" + entity  + ", " + Loot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddHero(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_356_AddHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddHero(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddHero(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_356_AddHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddHero(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddAllHero(Player entity, Int16 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_357_AddAllHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddAllHero(" + entity  + ", " + Level + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddAllHero(Player entity, Int16 Level, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_357_AddAllHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddAllHero(" + entity  + ", " + Level + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelHero(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_358_DelHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelHero(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelHero(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_358_DelHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelHero(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearHero(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_359_ClearHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHero(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearHero(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_359_ClearHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHero(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetHeroOwnSpellLevel(Player entity, UInt32 Hero, UInt16 SpellIdx, Int16 Level)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_362_SetHeroOwnSpellLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetHeroOwnSpellLevel(" + entity  + ", " + Hero + ", " + SpellIdx + ", " + Level + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, SpellIdx);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetHeroOwnSpellLevel(Player entity, UInt32 Hero, UInt16 SpellIdx, Int16 Level, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_362_SetHeroOwnSpellLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetHeroOwnSpellLevel(" + entity  + ", " + Hero + ", " + SpellIdx + ", " + Level + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, SpellIdx);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetHeroLevel(Player entity, Int16 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_363_SetHeroLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetHeroLevel(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetHeroLevel(Player entity, Int16 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_363_SetHeroLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetHeroLevel(" + entity  + ", " + Value + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModHeroLevel(Player entity, Int16 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_364_ModHeroLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModHeroLevel(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModHeroLevel(Player entity, Int16 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_364_ModHeroLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModHeroLevel(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ModHeroXP(Player entity, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_365_ModHeroXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModHeroXP(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ModHeroXP(Player entity, Int32 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_365_ModHeroXP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ModHeroXP(" + entity  + ", " + DeltaValue + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetSpell(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_367_ResetSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetSpell(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetSpell(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_367_ResetSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetSpell(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddSpell(Player entity, HeroSpellProperty StudySpell)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_368_AddSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpell(" + entity  + ", " + StudySpell + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpell);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddSpell(Player entity, HeroSpellProperty StudySpell, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_368_AddSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddSpell(" + entity  + ", " + StudySpell + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpell);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetupSpell(Player entity, List<HeroSpellProperty> SpellList, List<HeroSpellProperty> StudySpellList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_369_SetupSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetupSpell(" + entity  + ", " + SpellList + ", " + StudySpellList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpellList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetupSpell(Player entity, List<HeroSpellProperty> SpellList, List<HeroSpellProperty> StudySpellList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_369_SetupSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetupSpell(" + entity  + ", " + SpellList + ", " + StudySpellList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpellList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SwapSpell(Player entity, List<HeroSpellProperty> SpellList, List<HeroSpellProperty> StudySpellList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_370_SwapSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SwapSpell(" + entity  + ", " + SpellList + ", " + StudySpellList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpellList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SwapSpell(Player entity, List<HeroSpellProperty> SpellList, List<HeroSpellProperty> StudySpellList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_370_SwapSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SwapSpell(" + entity  + ", " + SpellList + ", " + StudySpellList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpellList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_KillNPC(Player entity, GoalEventStruct Data)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_371_OnEvent_KillNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_KillNPC(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_KillNPC(Player entity, GoalEventStruct Data, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_371_OnEvent_KillNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_KillNPC(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_InteractSpaceObject(Player entity, UInt32 SpaceObjectConfigID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_372_OnEvent_InteractSpaceObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_InteractSpaceObject(" + entity  + ", " + SpaceObjectConfigID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceObjectConfigID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_InteractSpaceObject(Player entity, UInt32 SpaceObjectConfigID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_372_OnEvent_InteractSpaceObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_InteractSpaceObject(" + entity  + ", " + SpaceObjectConfigID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceObjectConfigID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_SpaceEvent(Player entity, UInt32 NPC)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_373_OnEvent_SpaceEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_SpaceEvent(" + entity  + ", " + NPC + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPC);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_SpaceEvent(Player entity, UInt32 NPC, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_373_OnEvent_SpaceEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_SpaceEvent(" + entity  + ", " + NPC + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPC);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_SpaceWin(Player entity, UInt32 NPC)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_374_OnEvent_SpaceWin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_SpaceWin(" + entity  + ", " + NPC + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPC);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_SpaceWin(Player entity, UInt32 NPC, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_374_OnEvent_SpaceWin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_SpaceWin(" + entity  + ", " + NPC + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPC);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_TalkToNPC(Player entity, GoalEventStruct Data)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_375_OnEvent_TalkToNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_TalkToNPC(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_TalkToNPC(Player entity, GoalEventStruct Data, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_375_OnEvent_TalkToNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_TalkToNPC(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_CollectSpaceObject(Player entity, GoalEventStruct Data)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_376_OnEvent_CollectSpaceObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_CollectSpaceObject(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_CollectSpaceObject(Player entity, GoalEventStruct Data, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_376_OnEvent_CollectSpaceObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_CollectSpaceObject(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_OpenFunctionUI(Player entity, GoalEventStruct Data)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_377_OnEvent_OpenFunctionUI;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_OpenFunctionUI(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_OpenFunctionUI(Player entity, GoalEventStruct Data, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_377_OnEvent_OpenFunctionUI;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_OpenFunctionUI(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_JumpSpace(Player entity, GoalEventStruct Data)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_378_OnEvent_JumpSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_JumpSpace(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_JumpSpace(Player entity, GoalEventStruct Data, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_378_OnEvent_JumpSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_JumpSpace(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnEvent_GetItems(Player entity, GoalEventStruct Data)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_379_OnEvent_GetItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_GetItems(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnEvent_GetItems(Player entity, GoalEventStruct Data, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_379_OnEvent_GetItems;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnEvent_GetItems(" + entity  + ", " + Data + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_Exec(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Exec(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_0_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_Exec(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViString Param = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Param) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Exec(" + entity  + ", " + Script + ", " + Param + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_1_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Param);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_PrintMappingValue(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		float Value = default(float); if (ViGameSerializer<float>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintMappingValue(" + entity  + ", " + ID + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_2_PrintMappingValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_OnPing(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Time = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnPing(" + entity  + ", " + Time + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_3_OnPing;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_SetVisualScriptValue(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetVisualScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_4_SetVisualScriptValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_ClearVisualScriptValue(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearVisualScriptValue(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_5_ClearVisualScriptValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_SetPresistentScriptValue(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPresistentScriptValue(" + entity  + ", " + Name + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_6_SetPresistentScriptValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_ClearPresistentScriptValue(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearPresistentScriptValue(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_7_ClearPresistentScriptValue;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_SetNameAlias(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetNameAlias(" + entity  + ", " + Name + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_8_SetNameAlias;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_SetPhoto(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 ID = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPhoto(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_9_SetPhoto;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_AddPhoto(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPhoto(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_10_AddPhoto;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_DelPhoto(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPhoto(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_11_DelPhoto;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_ClearPhoto(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearPhoto(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_12_ClearPhoto;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_ModLevel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaValue = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModLevel(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_13_ModLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_ModXP(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 DeltaValue = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModXP(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_14_ModXP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_SetAccumulateLoginDayCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Value = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetAccumulateLoginDayCount(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_15_SetAccumulateLoginDayCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_ModAccumulateLoginDayCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaValue = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModAccumulateLoginDayCount(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_16_ModAccumulateLoginDayCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_SetAccumulateOnlineDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetAccumulateOnlineDuration(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_17_SetAccumulateOnlineDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_ModAccumulateOnlineDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 DeltaValue = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModAccumulateOnlineDuration(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_18_ModAccumulateOnlineDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_19_SetDayOnlineDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetDayOnlineDuration(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_19_SetDayOnlineDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_20_AddLoginStreak(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddLoginStreak(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_20_AddLoginStreak;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_21_ResetLoginStreak(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetLoginStreak(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_21_ResetLoginStreak;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_22_OnNewDay(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaDay = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaDay) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewDay(" + entity  + ", " + DeltaDay + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_22_OnNewDay;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaDay);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_23_OnNewWeek(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewWeek(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_23_OnNewWeek;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_24_OnNewMonth(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnNewMonth(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_24_OnNewMonth;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_25_PrintProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_25_PrintProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_26_PrintProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_26_PrintProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_27_PrintComponentProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Component = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Component) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintComponentProperty(" + entity  + ", " + Component + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_27_PrintComponentProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_28_PrintComponentProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViString Component = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Component) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintComponentProperty(" + entity  + ", " + Name + ", " + Component + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_28_PrintComponentProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Component);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_29_PrintAccountProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintAccountProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_29_PrintAccountProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_30_PrintAccountProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintAccountProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_30_PrintAccountProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_31_PrintGuildProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintGuildProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_31_PrintGuildProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_32_PrintGuildProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintGuildProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_32_PrintGuildProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_33_PrintPublicSpaceEnterProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintPublicSpaceEnterProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_33_PrintPublicSpaceEnterProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_34_PrintPublicSpaceEnterProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintPublicSpaceEnterProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_34_PrintPublicSpaceEnterProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_35_PrintPartyProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintPartyProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_35_PrintPartyProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_36_PrintPartyProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintPartyProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_36_PrintPartyProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_37_PrintSpaceMatchEnterGroupProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintSpaceMatchEnterGroupProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_37_PrintSpaceMatchEnterGroupProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_38_PrintSpaceMatchEnterGroupProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintSpaceMatchEnterGroupProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_38_PrintSpaceMatchEnterGroupProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_39_PrintActivityProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintActivityProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_39_PrintActivityProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_40_PrintGlobalProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_40_PrintGlobalProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_41_CopyPropertyFrom(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CopyPropertyFrom(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_41_CopyPropertyFrom;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_42_CopyPropertyFrom(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CopyPropertyFrom(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_42_CopyPropertyFrom;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_43_EndClientWatchIgnore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Func = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Func) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EndClientWatchIgnore(" + entity  + ", " + Func + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_43_EndClientWatchIgnore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Func);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_44_ClearClientWatchIgnore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearClientWatchIgnore(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_44_ClearClientWatchIgnore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_45_EnterPrivateSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterPrivateSpace(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_45_EnterPrivateSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_46_GotoBigSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GotoBigSpace(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_46_GotoBigSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_47_LeaveSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> LeaveSpace(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_47_LeaveSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_48_EnterBigSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterBigSpace(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_48_EnterBigSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_49_EnterBigSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterBigSpace(" + entity  + ", " + Space + ", " + Pos + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_49_EnterBigSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_50_ExitSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitSpace(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_50_ExitSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_51_ExitSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 Delay = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Delay) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitSpace(" + entity  + ", " + Delay + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_51_ExitSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Delay);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_52_OnSpaceEnter(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSpaceEnter(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_52_OnSpaceEnter;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_53_OnSmallSpaceEvent(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		UInt32 Event = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Event) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpaceEvent(" + entity  + ", " + Space + ", " + Event + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_53_OnSmallSpaceEvent;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Event);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_54_OnSmallSpaceResult(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		UInt8 Result = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Result) == false) { return false; }
		HashSet<ViString> ScriptList = default(HashSet<ViString>); if (ViGameSerializer<ViString>.Read(IS, out ScriptList) == false) { return false; }
		Dictionary<ViString, Int64Property> ScriptValueList = default(Dictionary<ViString, Int64Property>); if (ViGameSerializer<Int64Property>.Read(IS, out ScriptValueList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpaceResult(" + entity  + ", " + Space + ", " + Result + ", " + ScriptList + ", " + ScriptValueList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_54_OnSmallSpaceResult;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Result);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ScriptList);
		ViGameSerializer<Int64Property>.Append(entity.RPC.OS, ScriptValueList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_55_OnSmallSpacePVEWin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpacePVEWin(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_55_OnSmallSpacePVEWin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_56_OnSmallSpacePVELose(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpacePVELose(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_56_OnSmallSpacePVELose;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_57_OnSmallSpacePVPWin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		Int32 RankScore = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out RankScore) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpacePVPWin(" + entity  + ", " + Space + ", " + RankScore + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_57_OnSmallSpacePVPWin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, RankScore);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_58_OnSmallSpacePVPLose(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		Int32 RankScore = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out RankScore) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSmallSpacePVPLose(" + entity  + ", " + Space + ", " + RankScore + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_58_OnSmallSpacePVPLose;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, RankScore);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_59_UpdateSpaceRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		SpaceRecordProperty Record = default(SpaceRecordProperty); if (ViGameSerializer<SpaceRecordProperty>.Read(IS, out Record) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateSpaceRecord(" + entity  + ", " + Space + ", " + Record + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_59_UpdateSpaceRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<SpaceRecordProperty>.Append(entity.RPC.OS, Record);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_60_SaveCellProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SaveCellProperty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_60_SaveCellProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_61_OnCellHeroStart(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt32 PackID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out PackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnCellHeroStart(" + entity  + ", " + ID + ", " + PackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_61_OnCellHeroStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, PackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_62_OnCellHeroEnd(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt32 PackID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out PackID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnCellHeroEnd(" + entity  + ", " + ID + ", " + PackID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_62_OnCellHeroEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, PackID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_63_SetLastSmallSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetLastSmallSpace(" + entity  + ", " + Space + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_63_SetLastSmallSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_64_AddNPCLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 NPCPackedID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out NPCPackedID) == false) { return false; }
		Int16 NPCLevel = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out NPCLevel) == false) { return false; }
		UInt8 ReceiveImmediate = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out ReceiveImmediate) == false) { return false; }
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		Int32 YinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out YinPiao) == false) { return false; }
		Int32 XP = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out XP) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddNPCLoot(" + entity  + ", " + NPCPackedID + ", " + NPCLevel + ", " + ReceiveImmediate + ", " + Loot + ", " + YinPiao + ", " + XP + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_64_AddNPCLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPCPackedID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, NPCLevel);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ReceiveImmediate);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, YinPiao);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, XP);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_65_AddSpaceLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		UInt8 ReceiveImmediate = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out ReceiveImmediate) == false) { return false; }
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpaceLoot(" + entity  + ", " + Level + ", " + ReceiveImmediate + ", " + Loot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_65_AddSpaceLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ReceiveImmediate);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_66_AddSpaceLootScore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int32 Value = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpaceLootScore(" + entity  + ", " + ID + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_66_AddSpaceLootScore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_67_AddSpaceChangableMask(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int32 Weight = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Weight) == false) { return false; }
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpaceChangableMask(" + entity  + ", " + Name + ", " + Weight + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_67_AddSpaceChangableMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Weight);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_68_DelSpaceChangableMask(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelSpaceChangableMask(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_68_DelSpaceChangableMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_69_EndCellPlayer(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EndCellPlayer(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_69_EndCellPlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_70_CreatePublicSpaceEnter(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		ViString Password = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Password) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreatePublicSpaceEnter(" + entity  + ", " + Space + ", " + Password + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_70_CreatePublicSpaceEnter;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Password);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_71_EnterPublicSpaceEnter(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Password = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Password) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterPublicSpaceEnter(" + entity  + ", " + ID + ", " + Password + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_71_EnterPublicSpaceEnter;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Password);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_72_ChangePublicSpaceEnterFaction(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChangePublicSpaceEnterFaction(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_72_ChangePublicSpaceEnterFaction;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_73_AddPublicSpaceEnterFakePlayer(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 FactionIdx = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out FactionIdx) == false) { return false; }
		UInt8 AIType = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out AIType) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPublicSpaceEnterFakePlayer(" + entity  + ", " + FactionIdx + ", " + AIType + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_73_AddPublicSpaceEnterFakePlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, FactionIdx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, AIType);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_74_SetPublicSpaceEnterReady(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPublicSpaceEnterReady(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_74_SetPublicSpaceEnterReady;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_75_FirePublicSpaceEnterMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FirePublicSpaceEnterMember(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_75_FirePublicSpaceEnterMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_76_ExitPublicSpaceEnter(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitPublicSpaceEnter(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_76_ExitPublicSpaceEnter;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_77_GotoPublicSpaceEnter(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GotoPublicSpaceEnter(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_77_GotoPublicSpaceEnter;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_78_PublicSpaceManagerWatchStart(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PublicSpaceManagerWatchStart(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_78_PublicSpaceManagerWatchStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_79_PublicSpaceManagerWatchEnd(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PublicSpaceManagerWatchEnd(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_79_PublicSpaceManagerWatchEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_80_SetChatEndTime(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 Duration = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetChatEndTime(" + entity  + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_80_SetChatEndTime;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_81_ChatGroupWatchStart(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt8> ChannelList = default(List<UInt8>); if (ViGameSerializer<UInt8>.Read(IS, out ChannelList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatGroupWatchStart(" + entity  + ", " + ChannelList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_81_ChatGroupWatchStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ChannelList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_82_ChatGroupWatchEnd(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt8> ChannelList = default(List<UInt8>); if (ViGameSerializer<UInt8>.Read(IS, out ChannelList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatGroupWatchEnd(" + entity  + ", " + ChannelList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_82_ChatGroupWatchEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ChannelList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_83_ChatScriptBegin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptBegin(" + entity  + ", " + Channel + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_83_ChatScriptBegin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_84_ChatScriptBegin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptBegin(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_84_ChatScriptBegin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_85_ChatScriptBegin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptBegin(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_85_ChatScriptBegin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_86_ChatScriptEnd(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptEnd(" + entity  + ", " + Script + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_86_ChatScriptEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_87_ChatScriptShowItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Bag = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Bag) == false) { return false; }
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptShowItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_87_ChatScriptShowItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_88_ChatScriptWatchItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatScriptWatchItem(" + entity  + ", " + Channel + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_88_ChatScriptWatchItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_89_ChatOffline(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatOffline(" + entity  + ", " + ID + ", " + Content + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_89_ChatOffline;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_90_ClearOfflineChat(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearOfflineChat(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_90_ClearOfflineChat;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_91_ChatMessage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatMessage(" + entity  + ", " + Channel + ", " + Script + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_91_ChatMessage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_92_ChatMessage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatMessage(" + entity  + ", " + Name + ", " + Script + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_92_ChatMessage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_93_ChatMessage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ChatMessage(" + entity  + ", " + ID + ", " + Script + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_93_ChatMessage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_94_OpenFunc(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OpenFunc(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_94_OpenFunc;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_95_CloseFunc(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CloseFunc(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_95_CloseFunc;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_96_AddFuncPolicy(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddFuncPolicy(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_96_AddFuncPolicy;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_97_DelFuncPolicy(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelFuncPolicy(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_97_DelFuncPolicy;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_98_ClearFuncPolicy(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearFuncPolicy(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_98_ClearFuncPolicy;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_99_EnterActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterActivity(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_99_EnterActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_100_ExitActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitActivity(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_100_ExitActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_101_ModActivityEnterCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Activity = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Activity) == false) { return false; }
		Int16 DeltaValue = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModActivityEnterCount(" + entity  + ", " + Activity + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_101_ModActivityEnterCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Activity);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_102_ModScore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScore(" + entity  + ", " + ID + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_102_ModScore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_103_BuyScoreMarketItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyScoreMarketItem(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_103_BuyScoreMarketItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_104_AddCoolingDown(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddCoolingDown(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_104_AddCoolingDown;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_105_DelCoolingDown(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelCoolingDown(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_105_DelCoolingDown;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_106_DelAllCoolingDown(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelAllCoolingDown(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_106_DelAllCoolingDown;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_107_AddScriptDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddScriptDuration(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_107_AddScriptDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_108_SetScriptDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScriptDuration(" + entity  + ", " + ID + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_108_SetScriptDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_109_ModScriptDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int64 DeltaValue = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScriptDuration(" + entity  + ", " + ID + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_109_ModScriptDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_110_DelScriptDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelScriptDuration(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_110_DelScriptDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_111_DelAllScriptDuration(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelAllScriptDuration(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_111_DelAllScriptDuration;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_112_TradeManagerWatchStart(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TradeManagerWatchStart(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_112_TradeManagerWatchStart;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_113_TradeManagerWatchEnd(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TradeManagerWatchEnd(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_113_TradeManagerWatchEnd;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_114_AddItemTrade(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 BagSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out BagSlot) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		Int32 Price = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Price) == false) { return false; }
		Int32 AuctionPrice = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out AuctionPrice) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItemTrade(" + entity  + ", " + BagSlot + ", " + Count + ", " + Price + ", " + AuctionPrice + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_114_AddItemTrade;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, BagSlot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Price);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, AuctionPrice);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_115_DelItemTrade(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelItemTrade(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_115_DelItemTrade;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_116_SearchItemTrade(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 SortType = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out SortType) == false) { return false; }
		UInt8 ItemType = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out ItemType) == false) { return false; }
		List<UInt32> ItemTemplateList = default(List<UInt32>); if (ViGameSerializer<UInt32>.Read(IS, out ItemTemplateList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SearchItemTrade(" + entity  + ", " + SortType + ", " + ItemType + ", " + ItemTemplateList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_116_SearchItemTrade;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, SortType);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ItemType);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ItemTemplateList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_117_UpdateItemTrade(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Page = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Page) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateItemTrade(" + entity  + ", " + Page + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_117_UpdateItemTrade;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Page);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_118_BuyTradeItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyTradeItem(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_118_BuyTradeItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_119_AuctionTradeItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		Int32 Price = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Price) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AuctionTradeItem(" + entity  + ", " + ID + ", " + Price + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_119_AuctionTradeItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Price);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_120_CommitTradeItemTime(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CommitTradeItemTime(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_120_CommitTradeItemTime;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_121_UpdateItemTradeOwnList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateItemTradeOwnList(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_121_UpdateItemTradeOwnList;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_122_UpdateItemTradeAuctionList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateItemTradeAuctionList(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_122_UpdateItemTradeAuctionList;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_123_RevertItemTradeRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RevertItemTradeRecord(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_123_RevertItemTradeRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_124_ClearDailyItemTradeOutCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearDailyItemTradeOutCount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_124_ClearDailyItemTradeOutCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_125_ClearDailyItemTradeOutCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearDailyItemTradeOutCount(" + entity  + ", " + Item + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_125_ClearDailyItemTradeOutCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_126_CostItemTradeReserveCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int32 Count = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CostItemTradeReserveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_126_CostItemTradeReserveCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_127_CreateGuild(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreateGuild(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_127_CreateGuild;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_128_UpdateGuildList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Page = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Page) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateGuildList(" + entity  + ", " + Page + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_128_UpdateGuildList;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Page);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_129_UpdateGuildRecommand(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateGuildRecommand(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_129_UpdateGuildRecommand;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_130_SearchGuildName(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SearchGuildName(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_130_SearchGuildName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_131_ApplyGuild(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ApplyGuild(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_131_ApplyGuild;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_132_ApplyGuild(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ApplyGuild(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_132_ApplyGuild;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_133_CancelGuildApply(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CancelGuildApply(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_133_CancelGuildApply;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_134_UpdateGuildApplyRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateGuildApplyRecord(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_134_UpdateGuildApplyRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_135_AgreeGuildApply(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AgreeGuildApply(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_135_AgreeGuildApply;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_136_AgreeGuildAllApply(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AgreeGuildAllApply(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_136_AgreeGuildAllApply;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_137_DisagreeGuildApply(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisagreeGuildApply(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_137_DisagreeGuildApply;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_138_DisagreeGuildAllApply(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisagreeGuildAllApply(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_138_DisagreeGuildAllApply;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_139_GuildMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GuildMail(" + entity  + ", " + Title + ", " + Content + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_139_GuildMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_140_EnterGuild(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Guild = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Guild) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterGuild(" + entity  + ", " + Guild + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_140_EnterGuild;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Guild);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_141_ExitGuild(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitGuild(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_141_ExitGuild;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_142_FireGuildMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FireGuildMember(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_142_FireGuildMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_143_GuildImpeach(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GuildImpeach(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_143_GuildImpeach;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_144_SetGuildLeader(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildLeader(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_144_SetGuildLeader;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_145_SetGuildLeader(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildLeader(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_145_SetGuildLeader;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_146_SetGuildLeader(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Guild = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Guild) == false) { return false; }
		ViString Entity = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Entity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildLeader(" + entity  + ", " + Guild + ", " + Entity + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_146_SetGuildLeader;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Guild);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_147_HandOverGuildLeader(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> HandOverGuildLeader(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_147_HandOverGuildLeader;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_148_SetGuildMemberPosition(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		UInt8 Position = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Position) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildMemberPosition(" + entity  + ", " + ID + ", " + Position + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_148_SetGuildMemberPosition;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Position);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_149_ClearGuildMemberPosition(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearGuildMemberPosition(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_149_ClearGuildMemberPosition;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_150_SetGuildLevel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Value = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildLevel(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_150_SetGuildLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_151_ModGuildXP(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModGuildXP(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_151_ModGuildXP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_152_SetGuildIntrodution(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildIntrodution(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_152_SetGuildIntrodution;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_153_SetGuildBoard(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildBoard(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_153_SetGuildBoard;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_154_SetGuildResponseType(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildResponseType(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_154_SetGuildResponseType;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_155_SetGuildReqEnterLevel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Value = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildReqEnterLevel(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_155_SetGuildReqEnterLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_156_GuildRecruit(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GuildRecruit(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_156_GuildRecruit;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_157_GotoGuildSmallSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GotoGuildSmallSpace(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_157_GotoGuildSmallSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_158_ConvokeGuildSmallSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ConvokeGuildSmallSpace(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_158_ConvokeGuildSmallSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_159_ConvokeGuildSmallSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ConvokeGuildSmallSpace(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_159_ConvokeGuildSmallSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_160_EnterGuildActivitySeat(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterGuildActivitySeat(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_160_EnterGuildActivitySeat;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_161_ExitGuildActivitySeat(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitGuildActivitySeat(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_161_ExitGuildActivitySeat;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_162_FireGuildActivitySeat(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FireGuildActivitySeat(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_162_FireGuildActivitySeat;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_163_ConvokeGuildActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ConvokeGuildActivity(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_163_ConvokeGuildActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_164_ConvokeGuildActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ConvokeGuildActivity(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_164_ConvokeGuildActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_165_StartGuildActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> StartGuildActivity(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_165_StartGuildActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_166_EndGuildActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EndGuildActivity(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_166_EndGuildActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_167_EnterGuildActivity(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterGuildActivity(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_167_EnterGuildActivity;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_168_SetGuildActivityEnterProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 EnterCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out EnterCount) == false) { return false; }
		Int16 BuyCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out BuyCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetGuildActivityEnterProperty(" + entity  + ", " + ID + ", " + EnterCount + ", " + BuyCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_168_SetGuildActivityEnterProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, EnterCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, BuyCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_169_AddPartyPartnerRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Entity = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Entity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPartyPartnerRecord(" + entity  + ", " + Entity + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_169_AddPartyPartnerRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_170_DelPartyPartnerRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPartyPartnerRecord(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_170_DelPartyPartnerRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_171_ClearPartyPartnerRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearPartyPartnerRecord(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_171_ClearPartyPartnerRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_172_CreateParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Target = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreateParty(" + entity  + ", " + Target + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_172_CreateParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_173_CreateParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<PartySpaceSelectProperty> SpaceList = default(List<PartySpaceSelectProperty>); if (ViGameSerializer<PartySpaceSelectProperty>.Read(IS, out SpaceList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreateParty(" + entity  + ", " + SpaceList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_173_CreateParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<PartySpaceSelectProperty>.Append(entity.RPC.OS, SpaceList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_174_ExitParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ExitParty(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_174_ExitParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_175_InvitePartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Entity = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Entity) == false) { return false; }
		UInt8 Chanel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Chanel) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> InvitePartyMember(" + entity  + ", " + Entity + ", " + Chanel + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_175_InvitePartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Entity);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Chanel);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_176_InvitePartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Entity = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Entity) == false) { return false; }
		UInt8 Chanel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Chanel) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> InvitePartyMember(" + entity  + ", " + Entity + ", " + Chanel + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_176_InvitePartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Chanel);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_177_CancelInvitePartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CancelInvitePartyMember(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_177_CancelInvitePartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_178_CancelInvitePartyMemberAll(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CancelInvitePartyMemberAll(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_178_CancelInvitePartyMemberAll;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_179_AgreePartyInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AgreePartyInvite(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_179_AgreePartyInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_180_DisagreePartyInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisagreePartyInvite(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_180_DisagreePartyInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_181_DisagreePartyInviteAll(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisagreePartyInviteAll(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_181_DisagreePartyInviteAll;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_182_DelPartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPartyMember(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_182_DelPartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_183_SetPartyMemberState(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Ready = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Ready) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPartyMemberState(" + entity  + ", " + Ready + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_183_SetPartyMemberState;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Ready);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_184_SetPartyMemberAutoReady(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 AutoReady = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out AutoReady) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPartyMemberAutoReady(" + entity  + ", " + AutoReady + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_184_SetPartyMemberAutoReady;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, AutoReady);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_185_RecommandParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Entity = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Entity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RecommandParty(" + entity  + ", " + Entity + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_185_RecommandParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_186_RecommandParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Entity = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Entity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RecommandParty(" + entity  + ", " + Entity + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_186_RecommandParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_187_DelPartyRecommand(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPartyRecommand(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_187_DelPartyRecommand;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_188_EnterParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Entity = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Entity) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterParty(" + entity  + ", " + Entity + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_188_EnterParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_189_SetPartyMatchSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<PartySpaceSelectProperty> SpaceList = default(List<PartySpaceSelectProperty>); if (ViGameSerializer<PartySpaceSelectProperty>.Read(IS, out SpaceList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPartyMatchSpace(" + entity  + ", " + SpaceList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_189_SetPartyMatchSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<PartySpaceSelectProperty>.Append(entity.RPC.OS, SpaceList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_190_StartPartyMatching(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> StartPartyMatching(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_190_StartPartyMatching;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_191_EndPartyMatching(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EndPartyMatching(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_191_EndPartyMatching;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_192_SetPartyTarget(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 NewTarget = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out NewTarget) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPartyTarget(" + entity  + ", " + NewTarget + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_192_SetPartyTarget;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, NewTarget);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_193_PartyList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PartyList(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_193_PartyList;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_194_AgreePartyInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PartyID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PartyID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AgreePartyInvite(" + entity  + ", " + PartyID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_194_AgreePartyInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_195_DisagreePartyInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PartyID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PartyID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisagreePartyInvite(" + entity  + ", " + PartyID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_195_DisagreePartyInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_196_AgreeJoinPartyLazy(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Apply = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Apply) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AgreeJoinPartyLazy(" + entity  + ", " + Apply + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_196_AgreeJoinPartyLazy;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Apply);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_197_DelPartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPartyMember(" + entity  + ", " + PlayerID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_197_DelPartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_198_RequestJoinParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PartyID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PartyID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RequestJoinParty(" + entity  + ", " + PartyID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_198_RequestJoinParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_199_RequestJoinPartyLazy(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> tagrets = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out tagrets) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RequestJoinPartyLazy(" + entity  + ", " + tagrets + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_199_RequestJoinPartyLazy;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, tagrets);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_200_AgreeJoinParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AgreeJoinParty(" + entity  + ", " + PlayerID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_200_AgreeJoinParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_201_DisagreeJoinParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DisagreeJoinParty(" + entity  + ", " + PlayerID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_201_DisagreeJoinParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_202_DeputePartyLeader(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DeputePartyLeader(" + entity  + ", " + PlayerID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_202_DeputePartyLeader;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_203_GotoBigSpaceWithParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		UInt64 Target = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GotoBigSpaceWithParty(" + entity  + ", " + Space + ", " + Target + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_203_GotoBigSpaceWithParty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_204_VoteDelPartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> VoteDelPartyMember(" + entity  + ", " + PlayerID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_204_VoteDelPartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_205_ReplyVoteDelPartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		UInt8 Confirm = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Confirm) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReplyVoteDelPartyMember(" + entity  + ", " + PlayerID + ", " + Confirm + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_205_ReplyVoteDelPartyMember;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Confirm);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_206_SpaceMatchEnterGroupReady(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceMatchEnterGroupReady(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_206_SpaceMatchEnterGroupReady;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_207_SpaceMatchEnterGroupSelectHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Hero = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Hero) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceMatchEnterGroupSelectHero(" + entity  + ", " + Hero + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_207_SpaceMatchEnterGroupSelectHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_208_SpaceMatchEnterGroupSelectHeroReady(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Value = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SpaceMatchEnterGroupSelectHeroReady(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_208_SpaceMatchEnterGroupSelectHeroReady;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_209_AddFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddFriend(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_209_AddFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_210_AddFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddFriend(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_210_AddFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_211_DelFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelFriend(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_211_DelFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_212_DelFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelFriend(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_212_DelFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_213_SetFriendNote(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViString Note = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Note) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetFriendNote(" + entity  + ", " + ID + ", " + Note + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_213_SetFriendNote;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_214_AddBlackFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddBlackFriend(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_214_AddBlackFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_215_AddBlackFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddBlackFriend(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_215_AddBlackFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_216_DelBlackFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelBlackFriend(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_216_DelBlackFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_217_DelBlackFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelBlackFriend(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_217_DelBlackFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_218_UnblockBlackFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UnblockBlackFriend(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_218_UnblockBlackFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_219_UnblockBlackFriend(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UnblockBlackFriend(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_219_UnblockBlackFriend;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_220_FriendInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendInvite(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_220_FriendInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_221_FriendInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt64> IDList = default(List<UInt64>); if (ViGameSerializer<UInt64>.Read(IS, out IDList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendInvite(" + entity  + ", " + IDList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_221_FriendInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_222_FriendInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendInvite(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_222_FriendInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_223_FriendInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViString> NameList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out NameList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendInvite(" + entity  + ", " + NameList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_223_FriendInvite;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_224_FriendInvitedResponse(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		UInt8 OK = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out OK) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendInvitedResponse(" + entity  + ", " + Idx + ", " + OK + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_224_FriendInvitedResponse;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, OK);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_225_FriendInvitedResponseAll(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 OK = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out OK) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendInvitedResponseAll(" + entity  + ", " + OK + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_225_FriendInvitedResponseAll;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, OK);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_226_FriendUpdateRecommand(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendUpdateRecommand(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_226_FriendUpdateRecommand;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_227_FriendSearchName(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendSearchName(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_227_FriendSearchName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_228_FriendSearchNameAlias(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> FriendSearchNameAlias(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_228_FriendSearchNameAlias;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_229_WatchPlayerProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		ViRPCCallback<PlayerShotProperty> Result = default(ViRPCCallback<PlayerShotProperty>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> WatchPlayerProperty(" + entity  + ", " + ID + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_229_WatchPlayerProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_230_ReadMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReadMail(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_230_ReadMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_231_ReadMails(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> IdxList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out IdxList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReadMails(" + entity  + ", " + IdxList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_231_ReadMails;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_232_ReadAllMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReadAllMail(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_232_ReadAllMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_233_DeleteMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DeleteMail(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_233_DeleteMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_234_DeleteMails(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> IdxList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out IdxList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DeleteMails(" + entity  + ", " + IdxList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_234_DeleteMails;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_235_DeleteAllMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DeleteAllMail(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_235_DeleteAllMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_236_ReceiveMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReceiveMail(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_236_ReceiveMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_237_ReceiveMails(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> IdxList = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out IdxList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReceiveMails(" + entity  + ", " + IdxList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_237_ReceiveMails;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_238_ReceiveAllMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReceiveAllMail(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_238_ReceiveAllMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_239_SendMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Target = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Target) == false) { return false; }
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SendMail(" + entity  + ", " + Target + ", " + Title + ", " + Content + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_239_SendMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Target);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_240_AddMail(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		MailProperty Property = default(MailProperty); if (ViGameSerializer<MailProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddMail(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_240_AddMail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_241_ClearUpMailbox(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearUpMailbox(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_241_ClearUpMailbox;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_242_ModYinPiao(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 DeltaMoney = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaMoney) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModYinPiao(" + entity  + ", " + DeltaMoney + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_242_ModYinPiao;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_243_BuyYinPiao(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyYinPiao(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_243_BuyYinPiao;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_244_ModJinPiao(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 DeltaMoney = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaMoney) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModJinPiao(" + entity  + ", " + DeltaMoney + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_244_ModJinPiao;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_245_ModJinZi(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 DeltaMoney = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out DeltaMoney) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModJinZi(" + entity  + ", " + DeltaMoney + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_245_ModJinZi;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, DeltaMoney);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_246_TransferJinZi(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Receiver = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Receiver) == false) { return false; }
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TransferJinZi(" + entity  + ", " + Receiver + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_246_TransferJinZi;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_247_TransferJinZi(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Receiver = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Receiver) == false) { return false; }
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TransferJinZi(" + entity  + ", " + Receiver + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_247_TransferJinZi;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_248_AddJinPiaoPaymentRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddJinPiaoPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_248_AddJinPiaoPaymentRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_249_ClearJinPiaoPaymentRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearJinPiaoPaymentRecord(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_249_ClearJinPiaoPaymentRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_250_AddJinZiPaymentRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddJinZiPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_250_AddJinZiPaymentRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_251_ClearJinZiPaymentRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearJinZiPaymentRecord(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_251_ClearJinZiPaymentRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_252_AddYinPiaoPaymentRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int64 Value = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddYinPiaoPaymentRecord(" + entity  + ", " + ID + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_252_AddYinPiaoPaymentRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_253_ClearYinPiaoPaymentRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearYinPiaoPaymentRecord(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_253_ClearYinPiaoPaymentRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_254_SetPaymentState(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt8 State = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out State) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPaymentState(" + entity  + ", " + Name + ", " + State + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_254_SetPaymentState;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_255_SetPaymentState(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 State = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out State) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPaymentState(" + entity  + ", " + ID + ", " + State + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_255_SetPaymentState;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_256_SetPaymentState(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<PaymentStateProperty> StateList = default(List<PaymentStateProperty>); if (ViGameSerializer<PaymentStateProperty>.Read(IS, out StateList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetPaymentState(" + entity  + ", " + StateList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_256_SetPaymentState;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<PaymentStateProperty>.Append(entity.RPC.OS, StateList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_257_AddStatistics(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddStatistics(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_257_AddStatistics;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_258_ClearStatistics(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearStatistics(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_258_ClearStatistics;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_259_ClearStatistics(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearStatistics(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_259_ClearStatistics;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_260_AddItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItem(" + entity  + ", " + Template + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_260_AddItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_261_AddItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItem(" + entity  + ", " + Template + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_261_AddItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_262_AddItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItem(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_262_AddItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_263_AddItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItem(" + entity  + ", " + Name + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_263_AddItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_264_AddItems(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 TemplateInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateInf) == false) { return false; }
		UInt32 TemplateSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateSup) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItems(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_264_AddItems;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_265_AddItems(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 TemplateInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateInf) == false) { return false; }
		UInt32 TemplateSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out TemplateSup) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItems(" + entity  + ", " + TemplateInf + ", " + TemplateSup + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_265_AddItems;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, TemplateSup);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_266_RevertDelItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RevertDelItem(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_266_RevertDelItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_267_DelItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelItem(" + entity  + ", " + Template + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_267_DelItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_268_DestroyItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Bag = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Bag) == false) { return false; }
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DestroyItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_268_DestroyItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_269_DropItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Bag = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Bag) == false) { return false; }
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DropItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_269_DropItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_270_ClearBag(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearBag(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_270_ClearBag;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_271_CopyItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Bag = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Bag) == false) { return false; }
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CopyItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_271_CopyItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_272_MoveBagItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 FromSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out FromSlot) == false) { return false; }
		UInt16 ToSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out ToSlot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MoveBagItem(" + entity  + ", " + FromSlot + ", " + ToSlot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_272_MoveBagItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, FromSlot);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ToSlot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_273_MoveBagItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ItemTransportProperty> List = default(List<ItemTransportProperty>); if (ViGameSerializer<ItemTransportProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MoveBagItem(" + entity  + ", " + List + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_273_MoveBagItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ItemTransportProperty>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_274_SortBagItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<UInt16> List = default(List<UInt16>); if (ViGameSerializer<UInt16>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SortBagItem(" + entity  + ", " + List + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_274_SortBagItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_275_DrawOutItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DrawOutItem(" + entity  + ", " + Slot + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_275_DrawOutItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_276_UseBagItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UseBagItem(" + entity  + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_276_UseBagItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_277_UseBagItemTemplate(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UseBagItemTemplate(" + entity  + ", " + Template + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_277_UseBagItemTemplate;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_278_UseBagItemTemplate(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UseBagItemTemplate(" + entity  + ", " + Template + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_278_UseBagItemTemplate;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_279_UseBagItemTemplate(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UseBagItemTemplate(" + entity  + ", " + Slot + ", " + Template + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_279_UseBagItemTemplate;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_280_AddItemToPackage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItemToPackage(" + entity  + ", " + Template + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_280_AddItemToPackage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_281_MoveItemFromPackageToBag(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 FromSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out FromSlot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MoveItemFromPackageToBag(" + entity  + ", " + FromSlot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_281_MoveItemFromPackageToBag;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, FromSlot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_282_MoveItemFromPackageToBag(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MoveItemFromPackageToBag(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_282_MoveItemFromPackageToBag;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_283_ClearItemPackage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Notify = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Notify) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemPackage(" + entity  + ", " + Notify + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_283_ClearItemPackage;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Notify);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_284_SellItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SellItem(" + entity  + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_284_SellItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_285_SellItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SellItem(" + entity  + ", " + Slot + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_285_SellItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_286_AddSaledItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ItemProperty Item = default(ItemProperty); if (ViGameSerializer<ItemProperty>.Read(IS, out Item) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSaledItem(" + entity  + ", " + Item + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_286_AddSaledItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ItemProperty>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_287_BuyBackItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyBackItem(" + entity  + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_287_BuyBackItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_288_SellPackageItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SellPackageItem(" + entity  + ", " + Slot + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_288_SellPackageItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_289_BuyBackPackageItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyBackPackageItem(" + entity  + ", " + Slot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_289_BuyBackPackageItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_290_CostItemUseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CostItemUseCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_290_CostItemUseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_291_SetItemUseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetItemUseCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_291_SetItemUseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_292_ClearItemUseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemUseCount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_292_ClearItemUseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_293_ClearItemUseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemUseCount(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_293_ClearItemUseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_294_SetItemReceiveCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetItemReceiveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_294_SetItemReceiveCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_295_ClearItemReceiveCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemReceiveCount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_295_ClearItemReceiveCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_296_ClearItemReceiveCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemReceiveCount(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_296_ClearItemReceiveCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_297_CostItemReceiveReserveCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CostItemReceiveReserveCount(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_297_CostItemReceiveReserveCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_298_ItemCompose(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ComposeID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ComposeID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ItemCompose(" + entity  + ", " + ComposeID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_298_ItemCompose;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ComposeID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_299_DeEquipItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 EquipSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out EquipSlot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DeEquipItem(" + entity  + ", " + EquipSlot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_299_DeEquipItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, EquipSlot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_300_DeEquipItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 EquipSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out EquipSlot) == false) { return false; }
		UInt16 BagSlot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out BagSlot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DeEquipItem(" + entity  + ", " + EquipSlot + ", " + BagSlot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_300_DeEquipItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, EquipSlot);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, BagSlot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_301_TakeItemWithLicence(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Licence = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Licence) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeItemWithLicence(" + entity  + ", " + Licence + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_301_TakeItemWithLicence;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Licence);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_302_AddItemLicenceRecord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Licence = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Licence) == false) { return false; }
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItemLicenceRecord(" + entity  + ", " + Licence + ", " + Item + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_302_AddItemLicenceRecord;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Licence);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_303_AddItemLicenceCD(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		Int32 Duration = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Duration) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddItemLicenceCD(" + entity  + ", " + Item + ", " + Duration + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_303_AddItemLicenceCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_304_ClearItemLicenceCD(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearItemLicenceCD(" + entity  + ", " + Item + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_304_ClearItemLicenceCD;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_305_ClearMarketItemBuyCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearMarketItemBuyCount(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_305_ClearMarketItemBuyCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_306_ClearMarketItemBuyCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearMarketItemBuyCount(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_306_ClearMarketItemBuyCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_307_UpdateMarketItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateMarketItem(" + entity  + ", " + Tag + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_307_UpdateMarketItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_308_BuyMarketItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyMarketItem(" + entity  + ", " + ID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_308_BuyMarketItem;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_309_BuyMarketItemToOther(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		UInt64 ReceiverID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ReceiverID) == false) { return false; }
		ViString ReceiverName = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out ReceiverName) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyMarketItemToOther(" + entity  + ", " + ID + ", " + Count + ", " + ReceiverID + ", " + ReceiverName + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_309_BuyMarketItemToOther;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ReceiverID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ReceiverName);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_310_SendMarketItemTo(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ReceiverID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ReceiverID) == false) { return false; }
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SendMarketItemTo(" + entity  + ", " + ReceiverID + ", " + Item + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_310_SendMarketItemTo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ReceiverID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_311_AddStateMask(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		UInt32 Mask = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Mask) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddStateMask(" + entity  + ", " + Name + ", " + Mask + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_311_AddStateMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Mask);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_312_DelStateMask(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelStateMask(" + entity  + ", " + Name + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_312_DelStateMask;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_313_AddGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGoal(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_313_AddGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_314_AddGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 IDInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out IDInf) == false) { return false; }
		UInt32 IDSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out IDSup) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_314_AddGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_315_DelGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelGoal(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_315_DelGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_316_DelGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 IDInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out IDInf) == false) { return false; }
		UInt32 IDSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out IDSup) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_316_DelGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_317_DelAllGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelAllGoal(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_317_DelAllGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_318_CompleteGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CompleteGoal(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_318_CompleteGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_319_CompleteGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 IDInf = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out IDInf) == false) { return false; }
		UInt32 IDSup = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out IDSup) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CompleteGoal(" + entity  + ", " + IDInf + ", " + IDSup + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_319_CompleteGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDInf);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, IDSup);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_320_ResponseGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResponseGoal(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_320_ResponseGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_321_ClickReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClickReward(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_321_ClickReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_322_AddGoalReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddGoalReward(" + entity  + ", " + Template + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_322_AddGoalReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_323_TakeGoalReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Template = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Template) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeGoalReward(" + entity  + ", " + Template + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_323_TakeGoalReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_324_TakeGoalAllReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeGoalAllReward(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_324_TakeGoalAllReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_325_EnterStoryModel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 GoalID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GoalID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterStoryModel(" + entity  + ", " + GoalID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_325_EnterStoryModel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_326_GoalJumpSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 GoalID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GoalID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> GoalJumpSpace(" + entity  + ", " + GoalID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_326_GoalJumpSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_327_TurnInGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TurnInGoal(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_327_TurnInGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_328_JumpGoal(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> JumpGoal(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_328_JumpGoal;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_329_UpdateScoreRankProperty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		ScoreRankStasticsProperty Property = default(ScoreRankStasticsProperty); if (ViGameSerializer<ScoreRankStasticsProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateScoreRankProperty(" + entity  + ", " + Rank + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_329_UpdateScoreRankProperty;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<ScoreRankStasticsProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_330_SetScoreRankScore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 Value = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankScore(" + entity  + ", " + Rank + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_330_SetScoreRankScore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_331_ModScoreRankScore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankScore(" + entity  + ", " + Rank + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_331_ModScoreRankScore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_332_SetScoreRankMatchScore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 Value = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankMatchScore(" + entity  + ", " + Rank + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_332_SetScoreRankMatchScore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_333_ModScoreRankMatchScore(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankMatchScore(" + entity  + ", " + Rank + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_333_ModScoreRankMatchScore;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_334_SetScoreRankCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 TotalCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out TotalCount) == false) { return false; }
		Int32 VersionCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out VersionCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_334_SetScoreRankCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_335_ModScoreRankCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_335_ModScoreRankCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_336_SetScoreRankWinCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 TotalCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out TotalCount) == false) { return false; }
		Int32 VersionCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out VersionCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankWinCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_336_SetScoreRankWinCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_337_ModScoreRankWinCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankWinCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_337_ModScoreRankWinCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_338_SetScoreRankLoseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 TotalCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out TotalCount) == false) { return false; }
		Int32 VersionCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out VersionCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankLoseCount(" + entity  + ", " + Rank + ", " + TotalCount + ", " + VersionCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_338_SetScoreRankLoseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, TotalCount);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, VersionCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_339_ModScoreRankLoseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankLoseCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_339_ModScoreRankLoseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_340_SetScoreRankContinueWinCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 Count = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankContinueWinCount(" + entity  + ", " + Rank + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_340_SetScoreRankContinueWinCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_341_ModScoreRankContinueWinCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankContinueWinCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_341_ModScoreRankContinueWinCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_342_SetScoreRankContinueLoseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 Count = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetScoreRankContinueLoseCount(" + entity  + ", " + Rank + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_342_SetScoreRankContinueLoseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_343_ModScoreRankContinueLoseCount(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 DeltaCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModScoreRankContinueLoseCount(" + entity  + ", " + Rank + ", " + DeltaCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_343_ModScoreRankContinueLoseCount;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_344_PrintScoreRankPosition(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		Int32 Score = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out Score) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintScoreRankPosition(" + entity  + ", " + Rank + ", " + Score + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_344_PrintScoreRankPosition;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Rank);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Score);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_345_ModPower(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaValue = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModPower(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_345_ModPower;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_346_BuyPower(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BuyPower(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_346_BuyPower;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_347_TakeLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeLoot(" + entity  + ", " + Loot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_347_TakeLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_348_TakeLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeLoot(" + entity  + ", " + Loot + ", " + Scale + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_348_TakeLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_349_TakeLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeLoot(" + entity  + ", " + Loot + ", " + Scale + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_349_TakeLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_350_MailLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MailLoot(" + entity  + ", " + Loot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_350_MailLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_351_MailLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MailLoot(" + entity  + ", " + Loot + ", " + Scale + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_351_MailLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_352_MailLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> MailLoot(" + entity  + ", " + Loot + ", " + Scale + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_352_MailLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_353_PrintLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		float Scale = default(float); if (ViGameSerializer<float>.Read(IS, out Scale) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> PrintLoot(" + entity  + ", " + Loot + ", " + Level + ", " + Scale + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_353_PrintLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		ViGameSerializer<float>.Append(entity.RPC.OS, Scale);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_354_ClearOnceLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearOnceLoot(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_354_ClearOnceLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_355_ClearOnceLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearOnceLoot(" + entity  + ", " + Loot + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_355_ClearOnceLoot;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Loot);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_356_AddHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddHero(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_356_AddHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_357_AddAllHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddAllHero(" + entity  + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_357_AddAllHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_358_DelHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelHero(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_358_DelHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_359_ClearHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearHero(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_359_ClearHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_360_TakeHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeHero(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_360_TakeHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_361_SetSpaceWorkingHero(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetSpaceWorkingHero(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_361_SetSpaceWorkingHero;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_362_SetHeroOwnSpellLevel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Hero = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Hero) == false) { return false; }
		UInt16 SpellIdx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out SpellIdx) == false) { return false; }
		Int16 Level = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Level) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetHeroOwnSpellLevel(" + entity  + ", " + Hero + ", " + SpellIdx + ", " + Level + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_362_SetHeroOwnSpellLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, SpellIdx);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Level);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_363_SetHeroLevel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 Value = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetHeroLevel(" + entity  + ", " + Value + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_363_SetHeroLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_364_ModHeroLevel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 DeltaValue = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModHeroLevel(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_364_ModHeroLevel;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_365_ModHeroXP(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 DeltaValue = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out DeltaValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ModHeroXP(" + entity  + ", " + DeltaValue + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_365_ModHeroXP;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_366_UseHeroXPStone(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Hero = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Hero) == false) { return false; }
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		Int16 INT16 = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out INT16) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UseHeroXPStone(" + entity  + ", " + Hero + ", " + Item + ", " + INT16 + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_366_UseHeroXPStone;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, INT16);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_367_ResetSpell(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetSpell(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_367_ResetSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_368_AddSpell(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		HeroSpellProperty StudySpell = default(HeroSpellProperty); if (ViGameSerializer<HeroSpellProperty>.Read(IS, out StudySpell) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddSpell(" + entity  + ", " + StudySpell + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_368_AddSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpell);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_369_SetupSpell(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<HeroSpellProperty> SpellList = default(List<HeroSpellProperty>); if (ViGameSerializer<HeroSpellProperty>.Read(IS, out SpellList) == false) { return false; }
		List<HeroSpellProperty> StudySpellList = default(List<HeroSpellProperty>); if (ViGameSerializer<HeroSpellProperty>.Read(IS, out StudySpellList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SetupSpell(" + entity  + ", " + SpellList + ", " + StudySpellList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_369_SetupSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpellList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_370_SwapSpell(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<HeroSpellProperty> SpellList = default(List<HeroSpellProperty>); if (ViGameSerializer<HeroSpellProperty>.Read(IS, out SpellList) == false) { return false; }
		List<HeroSpellProperty> StudySpellList = default(List<HeroSpellProperty>); if (ViGameSerializer<HeroSpellProperty>.Read(IS, out StudySpellList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SwapSpell(" + entity  + ", " + SpellList + ", " + StudySpellList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_370_SwapSpell;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, SpellList);
		ViGameSerializer<HeroSpellProperty>.Append(entity.RPC.OS, StudySpellList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_371_OnEvent_KillNPC(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GoalEventStruct Data = default(GoalEventStruct); if (ViGameSerializer<GoalEventStruct>.Read(IS, out Data) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_KillNPC(" + entity  + ", " + Data + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_371_OnEvent_KillNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_372_OnEvent_InteractSpaceObject(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceObjectConfigID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceObjectConfigID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_InteractSpaceObject(" + entity  + ", " + SpaceObjectConfigID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_372_OnEvent_InteractSpaceObject;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceObjectConfigID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_373_OnEvent_SpaceEvent(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 NPC = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out NPC) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_SpaceEvent(" + entity  + ", " + NPC + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_373_OnEvent_SpaceEvent;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPC);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_374_OnEvent_SpaceWin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 NPC = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out NPC) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_SpaceWin(" + entity  + ", " + NPC + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_374_OnEvent_SpaceWin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, NPC);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_375_OnEvent_TalkToNPC(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GoalEventStruct Data = default(GoalEventStruct); if (ViGameSerializer<GoalEventStruct>.Read(IS, out Data) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_TalkToNPC(" + entity  + ", " + Data + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_375_OnEvent_TalkToNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_376_OnEvent_CollectSpaceObject(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GoalEventStruct Data = default(GoalEventStruct); if (ViGameSerializer<GoalEventStruct>.Read(IS, out Data) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_CollectSpaceObject(" + entity  + ", " + Data + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_376_OnEvent_CollectSpaceObject;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_377_OnEvent_OpenFunctionUI(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GoalEventStruct Data = default(GoalEventStruct); if (ViGameSerializer<GoalEventStruct>.Read(IS, out Data) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_OpenFunctionUI(" + entity  + ", " + Data + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_377_OnEvent_OpenFunctionUI;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_378_OnEvent_JumpSpace(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GoalEventStruct Data = default(GoalEventStruct); if (ViGameSerializer<GoalEventStruct>.Read(IS, out Data) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_JumpSpace(" + entity  + ", " + Data + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_378_OnEvent_JumpSpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_379_OnEvent_GetItems(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		GoalEventStruct Data = default(GoalEventStruct); if (ViGameSerializer<GoalEventStruct>.Read(IS, out Data) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnEvent_GetItems(" + entity  + ", " + Data + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_379_OnEvent_GetItems;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<GoalEventStruct>.Append(entity.RPC.OS, Data);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_380_EnterSpaceObjLoadNPC(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 GoalID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GoalID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> EnterSpaceObjLoadNPC(" + entity  + ", " + GoalID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_380_EnterSpaceObjLoadNPC;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_381_CompleteHint(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CompleteHint(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_381_CompleteHint;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_382_ClearHint(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearHint(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_382_ClearHint;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_383_ClearHint(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClearHint(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_383_ClearHint;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_384_TakeDayGift(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeDayGift(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_384_TakeDayGift;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_385_TakeAccumulateLoginReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeAccumulateLoginReward(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_385_TakeAccumulateLoginReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_386_ResetAccumulateLoginReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetAccumulateLoginReward(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_386_ResetAccumulateLoginReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_387_TakeAccumulateLoginInActivityReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TakeAccumulateLoginInActivityReward(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_387_TakeAccumulateLoginInActivityReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_388_ResetAccumulateLoginInActivityReward(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetAccumulateLoginInActivityReward(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_388_ResetAccumulateLoginInActivityReward;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_389_ResetClientSetting(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetClientSetting(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_389_ResetClientSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_390_UpdateClientSetting(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ClientSettingForPlayerProperty PlayerProperty = default(ClientSettingForPlayerProperty); if (ViGameSerializer<ClientSettingForPlayerProperty>.Read(IS, out PlayerProperty) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateClientSetting(" + entity  + ", " + PlayerProperty + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_390_UpdateClientSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ClientSettingForPlayerProperty>.Append(entity.RPC.OS, PlayerProperty);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnPing(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int64 Time = default(Int64); if (ViGameSerializer<Int64>.Read(IS, out Time) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPing(Time);
		return true;
	}
	static bool Client_1_ShakeCamera(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ShakeCamera(ID);
		return true;
	}
	static bool Client_2_ShakeCameraSpring(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float SpirngRange = default(float); if (ViGameSerializer<float>.Read(IS, out SpirngRange) == false) { return false; }
		float SpirngRate = default(float); if (ViGameSerializer<float>.Read(IS, out SpirngRate) == false) { return false; }
		float SpeedFriction = default(float); if (ViGameSerializer<float>.Read(IS, out SpeedFriction) == false) { return false; }
		float TimeScale = default(float); if (ViGameSerializer<float>.Read(IS, out TimeScale) == false) { return false; }
		Int32 SprintCount = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out SprintCount) == false) { return false; }
		float LookAtScale = default(float); if (ViGameSerializer<float>.Read(IS, out LookAtScale) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ShakeCameraSpring(SpirngRange, SpirngRate, SpeedFriction, TimeScale, SprintCount, LookAtScale);
		return true;
	}
	static bool Client_3_ShakeCameraRandom(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Duration = default(float); if (ViGameSerializer<float>.Read(IS, out Duration) == false) { return false; }
		float Intensity = default(float); if (ViGameSerializer<float>.Read(IS, out Intensity) == false) { return false; }
		float LookAtScale = default(float); if (ViGameSerializer<float>.Read(IS, out LookAtScale) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ShakeCameraRandom(Duration, Intensity, LookAtScale);
		return true;
	}
	static bool Client_4_MessageBox(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.MessageBox(Title, Content);
		return true;
	}
	static bool Client_5_DebugMessage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.DebugMessage(Title, Content);
		return true;
	}
	static bool Client_6_ContainReserveWord(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString OrgValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out OrgValue) == false) { return false; }
		ViString FmtValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out FmtValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ContainReserveWord(OrgValue, FmtValue);
		return true;
	}
	static bool Client_7_OnReceiveMessage(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Loot = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Loot) == false) { return false; }
		UInt32 Message = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Message) == false) { return false; }
		Int32 XP = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out XP) == false) { return false; }
		Int32 JinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out JinPiao) == false) { return false; }
		Int32 YinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out YinPiao) == false) { return false; }
		List<ItemCountProperty> ItemList = default(List<ItemCountProperty>); if (ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnReceiveMessage(Loot, Message, XP, JinPiao, YinPiao, ItemList);
		return true;
	}
	static bool Client_8_OnLevelUpdated(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		LevelUpdateProperty OldProperty = default(LevelUpdateProperty); if (ViGameSerializer<LevelUpdateProperty>.Read(IS, out OldProperty) == false) { return false; }
		LevelUpdateProperty NewProperty = default(LevelUpdateProperty); if (ViGameSerializer<LevelUpdateProperty>.Read(IS, out NewProperty) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLevelUpdated(OldProperty, NewProperty);
		return true;
	}
	static bool Client_9_OnFuncOpen(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnFuncOpen(ID);
		return true;
	}
	static bool Client_10_OnActivityEnter(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt8 First = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out First) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnActivityEnter(ID, First);
		return true;
	}
	static bool Client_11_OnActivityExit(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnActivityExit(ID);
		return true;
	}
	static bool Client_12_OnUpdateMarketItem(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		List<MarketSellItemProperty> List = default(List<MarketSellItemProperty>); if (ViGameSerializer<MarketSellItemProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateMarketItem(Tag, List);
		return true;
	}
	static bool Client_13_OnUpdateItemTradeList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ItemTradeProperty> LocalList = default(List<ItemTradeProperty>); if (ViGameSerializer<ItemTradeProperty>.Read(IS, out LocalList) == false) { return false; }
		UInt16 TotalCount = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out TotalCount) == false) { return false; }
		UInt8 PlayerFlag = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out PlayerFlag) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateItemTradeList(LocalList, TotalCount, PlayerFlag);
		return true;
	}
	static bool Client_14_OnAddItemTrade(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Result = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnAddItemTrade(Result);
		return true;
	}
	static bool Client_15_OnUpdateItemTradeOwnList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ItemTradeProperty> List = default(List<ItemTradeProperty>); if (ViGameSerializer<ItemTradeProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateItemTradeOwnList(List);
		return true;
	}
	static bool Client_16_OnUpdateItemTradeAuctionList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ItemTradeProperty> List = default(List<ItemTradeProperty>); if (ViGameSerializer<ItemTradeProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateItemTradeAuctionList(List);
		return true;
	}
	static bool Client_17_OnItemTradeBuySuc(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnItemTradeBuySuc(ID);
		return true;
	}
	static bool Client_18_OnGuildListUpdated(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int16 TotalCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out TotalCount) == false) { return false; }
		List<GuildViewProperty> GuildList = default(List<GuildViewProperty>); if (ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnGuildListUpdated(TotalCount, GuildList);
		return true;
	}
	static bool Client_19_OnGuildSearchResult(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<GuildViewProperty> GuildList = default(List<GuildViewProperty>); if (ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnGuildSearchResult(GuildList);
		return true;
	}
	static bool Client_20_OnGuildApplyRecordUpdated(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<GuildViewProperty> GuildList = default(List<GuildViewProperty>); if (ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnGuildApplyRecordUpdated(GuildList);
		return true;
	}
	static bool Client_21_OnGuildRecommandUpdated(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<GuildViewProperty> GuildList = default(List<GuildViewProperty>); if (ViGameSerializer<GuildViewProperty>.Read(IS, out GuildList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnGuildRecommandUpdated(GuildList);
		return true;
	}
	static bool Client_22_OnPartyInvite(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PartyID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PartyID) == false) { return false; }
		ViString PartyName = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out PartyName) == false) { return false; }
		UInt64 LeaderID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out LeaderID) == false) { return false; }
		ViString LeaderName = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out LeaderName) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPartyInvite(PartyID, PartyName, LeaderID, LeaderName);
		return true;
	}
	static bool Client_23_OnPartyDisagreeRequest(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PartyID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PartyID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPartyDisagreeRequest(PartyID);
		return true;
	}
	static bool Client_24_OnPartyFire(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Party = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Party) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPartyFire(Party);
		return true;
	}
	static bool Client_25_OnPartyDisband(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Party = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Party) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPartyDisband(Party);
		return true;
	}
	static bool Client_26_OnPartyList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<PartyDetail> partyList = default(List<PartyDetail>); if (ViGameSerializer<PartyDetail>.Read(IS, out partyList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPartyList(partyList);
		return true;
	}
	static bool Client_27_OnGotoBigSpaceWithParty(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		UInt64 Target = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Target) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnGotoBigSpaceWithParty(Space, Target);
		return true;
	}
	static bool Client_28_OnVoteDelPartyMember(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 PlayerID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out PlayerID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnVoteDelPartyMember(PlayerID);
		return true;
	}
	static bool Client_29_OnFriendInvitedStart(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString InvitorName = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out InvitorName) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnFriendInvitedStart(InvitorName);
		return true;
	}
	static bool Client_30_OnFriendInvitedEnd(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnFriendInvitedEnd();
		return true;
	}
	static bool Client_31_OnFriendSearchResult(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<PlayerShotProperty> List = default(List<PlayerShotProperty>); if (ViGameSerializer<PlayerShotProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnFriendSearchResult(List);
		return true;
	}
	static bool Client_32_OnChatRecordList(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Channel = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Channel) == false) { return false; }
		UInt32 Count = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Count) == false) { return false; }
		UInt32 Start = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Start) == false) { return false; }
		List<ChatRecordProperty> RecordList = default(List<ChatRecordProperty>); if (ViGameSerializer<ChatRecordProperty>.Read(IS, out RecordList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChatRecordList(Channel, Count, Start, RecordList);
		return true;
	}
	static bool Client_33_OnTransferJinZiResult(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Success = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Success) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnTransferJinZiResult(Success);
		return true;
	}
	static bool Client_34_OnNPCLoot(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 EntityPackedID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out EntityPackedID) == false) { return false; }
		Int32 XP = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out XP) == false) { return false; }
		Int32 YinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out YinPiao) == false) { return false; }
		List<ItemCountProperty> ItemList = default(List<ItemCountProperty>); if (ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnNPCLoot(EntityPackedID, XP, YinPiao, ItemList);
		return true;
	}
	static bool Client_35_OnSmallSpacePVERecordUpdate(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		SpaceRecordProperty Record = default(SpaceRecordProperty); if (ViGameSerializer<SpaceRecordProperty>.Read(IS, out Record) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSmallSpacePVERecordUpdate(Space, Record);
		return true;
	}
	static bool Client_36_OnSmallSpacePVEWin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		Int32 XP = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out XP) == false) { return false; }
		Int32 YinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out YinPiao) == false) { return false; }
		List<ItemCountProperty> ItemList = default(List<ItemCountProperty>); if (ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSmallSpacePVEWin(Space, XP, YinPiao, ItemList);
		return true;
	}
	static bool Client_37_OnSmallSpacePVELose(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSmallSpacePVELose(Space);
		return true;
	}
	static bool Client_38_OnSmallSpacePVPWin(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		Int32 RankScore = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out RankScore) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSmallSpacePVPWin(Space, RankScore);
		return true;
	}
	static bool Client_39_OnSmallSpacePVPLose(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		Int32 RankScore = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out RankScore) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSmallSpacePVPLose(Space, RankScore);
		return true;
	}
	static bool Client_40_OnScoreRankUpdate(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Rank = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Rank) == false) { return false; }
		UInt32 Position = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Position) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnScoreRankUpdate(Rank, Position);
		return true;
	}
	static bool Client_41_UIEvent(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.UIEvent(ID);
		return true;
	}
	static bool Client_42_UIEvent(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		UInt16 Slot = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Slot) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.UIEvent(ID, Slot);
		return true;
	}
	static bool Client_43_OnGoalEndNeedClick(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnGoalEndNeedClick(ID);
		return true;
	}
	static bool Client_44_EnterStoryModel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 GoalID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GoalID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.EnterStoryModel(GoalID);
		return true;
	}
	static bool Client_45_ExitStoryModel(Player entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 GoalID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out GoalID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ExitStoryModel(GoalID);
		return true;
	}
}
