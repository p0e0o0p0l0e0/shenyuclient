using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
//
public class Player : ViRPCEntity, ViEntity
{
    public static ViConstValue<Int32> LevelUpEffectId = new ViConstValue<Int32>("LevelUpEffectId", (Int32)1221);

    public static Player Instance { get { return _instance; } }
    static Player _instance;
    //
    public ViRPCInvoker RPC { get { return _RPC; } }
    ViRPCInvoker _RPC = new ViRPCInvoker();
    public string Name { get { return "Player"; } }
    public ViEntityID ID { get { return _ID; } }
    public UInt32 PackID { get { return _PackID; } }
    public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
    public bool IsLocal { get { return _asLocal; } }
    public bool Active { get { return _active; } }
    public PlayerReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
    public int Level
    {
        get
        {
            return CellHero.LocalHero.Property.Level;
        }
    }
    public Int64 LevelUpXP
    {
        get
        {
            int hClass = CellHero.LocalHero.Property.Info.Value.HeroClass.Value;
            int level = CellHero.LocalHero.Property.Level;
            var list = ViSealedDB<HeroLevelStruct>.Array;
            for (int i = 1; i < list.Count; i++)
            {
                if (level == list[i].Level && hClass == list[i].HeroClass)
                    return list[i].XPToLeave;
            }
            return Int32.MaxValue;
        }
    }

    public PlayerIdentificationProperty Identification()
    {
        PlayerIdentificationProperty property = new PlayerIdentificationProperty();
        property.ID = ID;
        property.Name = Property.GUName;
        property.NameAlias = Property.NameAlias;
        property.Photo = Property.Photo;
        return property;
    }

    public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
    {
        _ID = ID;
        _PackID = PackID;
        _asLocal = asLocal;
    }
    public void SetActive(bool value)
    {
        _active = value;
    }
    public void PreStart() { }
    public void Start()
    {
        PlayerPropertyWatcherCreator.Start(Property, this);
        _instance = this;
#if PARTY
        for (int i = 0; i < Property.PartyInviteList.Count; i++)
        {
            ViDebuger.Record("-------> BeInvited " + Property.PartyInviteList[i].Property.Leader.NameAlias + "," + Property.PartyInviteList[i].Property.PartyID);
        }
        for (int i = 0; i < Property.PartyPartnerRecordList.Count; i++)
        {
            ViDebuger.Record("------->PartyPartnerRecordList ....." + Property.PartyPartnerRecordList[i].Property.Identification.NameAlias);
        }
        for (int i = 0; i < Property.RequestPartyList.Count; i ++)
        {
            ViDebuger.Record("------->RequestPartyList ....." + Property.RequestPartyList[i].Property.ID);
        }
#endif
        //Property.AgreeJoinPartyLazy.CallbackList.Attach(_agreeFastMatchCallback, _OnAgreeFastMatchUpdated);

        //
        Property.HintList.UpdateArrayCallbackList.Attach(_hintListCallback, this._OnGameHintUpdated);
        Property.SpaceRecordList.UpdateArrayCallbackList.Attach(_spaceRecordListCallback, this._OnSpaceRecordUpdated);
        Property.RequestPartyList.CallbackList.Attach(_partyRequestListCallback, this._OnPartyRequestListUpdated);
        Property.PartyInviteList.CallbackList.Attach(_partyInviteListCallback, this._OnPartyInviteListUpdated);
        Property.Inventory.CallbackList.Attach(_InventoryListCallback, this._OnInventoryUpdate);
        Property.Equipments.CallbackList.Attach(_EquipListCallback, this._OnEquipListUpdate);

        GoalManager.GetInstance.Start();
    }
    public void AftStart()
    {
        //
    }

    public void ClearCallback()
    {   //party
        //_agreeFastMatchCallback.End();
        _partyInviteListCallback.End();
        _partyRequestListCallback.End();
        _hintListCallback.End();
        _spaceGroupListCallback.End();
        _InventoryListCallback.End();
        _EquipListCallback.End();
    }

    public void PreEnd()
    {
        _instance = null;
        //
        //ViewControllerManager.OnPlayerDestroyed();
    }
    public void End()
    {
        GoalManager.GetInstance.End();
    }
    public void AftEnd() { }

    public void Tick(float fDeltaTime)
    {

    }

    public void StartProperty(UInt16 channelMask, ViIStream IS)
    {
        _property = ViReceiveDataCache<PlayerReceiveProperty>.Alloc();
        _property.StartProperty(channelMask, IS, this);
        PlayerPropertyAssisstant.SetProperty(_property);

    }
    public void EndProperty()
    {
        _property.EndProperty(this);
    }
    public void ClearProperty()
    {
        PlayerPropertyAssisstant.SetProperty(null);
        ViReceiveDataCache<PlayerReceiveProperty>.Free(_property);
        _property = null;
    }
    public void OnPropertyUpdateStart(UInt8 channel) { }
    public void OnPropertyUpdateEnd(UInt8 channel) { }
    public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
    {
        _property.OnPropertyUpdate(channel, IS, this);
    }


    ViAsynCallback<UInt32> _hintListCallback = new ViAsynCallback<UInt32>();
    void _OnGameHintUpdated(UInt32 type, UInt32 ID)
    {
        //if (type == (UInt32)ViDataArrayOperator.INSERT)
        //{
        //	GameHintController.Instance.End(ID);
        //}
        //else
        //{
        //	GameHintController.Instance.End();
        //}
    }

    ViAsynCallback<UInt32> _spaceGroupListCallback = new ViAsynCallback<UInt32>();
    void _OnSpaceGroupUpdated(UInt32 type, UInt32 ID)
    {
    }

    ViAsynCallback<UInt32, ReceiveDataSpaceRecordProperty> _spaceRecordListCallback = new ViAsynCallback<UInt32, ReceiveDataSpaceRecordProperty>();
    void _OnSpaceRecordUpdated(UInt32 type, UInt32 space, ReceiveDataSpaceRecordProperty property)
    {
    }

    ViAsynCallback<ViReceiveDataNode, object> _InventoryListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnInventoryUpdate(UInt32 dele, ViReceiveDataNode before, object after)
    {
        UIBagDataMgr.GetInstance.OnItemDateChange(before, after);
    }
    ViAsynCallback<ViReceiveDataNode, object> _EquipListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnEquipListUpdate(UInt32 dele, ViReceiveDataNode before, object after)
    {
        UIBagDataMgr.GetInstance.OnWearEquipDateChange(before, after);
    }
    public void OnPing(Int64 time)
    {
        Int64 span = (Int64)(UnityEngine.Time.realtimeSinceStartup * 1000) - time;
        ViDebuger.CritOK("Ceter.PING=" + span + " @" + time);
    }

    public void ShakeCamera(UInt32 ID)
    {
        ViCameraShakeStruct info = ViSealedDB<ViCameraShakeStruct>.GetData(ID);
        if (info != null)
        {
            CameraController.Instance.SpringShaker.Start(info.Spring.Range * 0.01f * ViVector3.UNIT_Z, info.Spring.SpirngRate * 0.01f, info.Spring.SpeedFriction * 0.01f, info.Spring.TimeScale * 0.01f, info.Spring.SpringCount, info.LookAtScale * 0.01f);
            CameraController.Instance.RandomShaker.Start(info.Random.Duration * 0.01f, info.Random.Intensity * 0.01f, info.LookAtScale * 0.01f);
        }
    }

    public void ShakeCameraSpring(float springRange, float spirngRate, float speedFriction, float timeScale, int sprintCount, float lootAtScale)
    {
        CameraController.Instance.SpringShaker.Start(springRange * ViVector3.UNIT_Z, spirngRate, speedFriction, timeScale, sprintCount, lootAtScale);
    }

    public void ShakeCameraRandom(float duration, float instensity, float lootAtScale)
    {
        CameraController.Instance.RandomShaker.Start(duration, instensity, lootAtScale);
    }

    public void MessageBox(ViString title, ViString content)
    {
        //ViewControllerManager.PrintMSGView.SetMessage(content);
    }

    public void DebugMessage(ViString title, ViString content)
    {
        EntityMessageController.OnDebugMessage(title, content);
    }

    public void ContainReserveWord(ViString orgValue, ViString fmtValue)
    {
        //ViewControllerManager.ConfirmView.ShowConfirm1("包含禁用词汇(" + orgValue + "->" + fmtValue + ")");
    }

    public static ViConstValue<float> VALUE_RankUpDelayTime = new ViConstValue<float>("RankUpDelayTime", 10.0f);
    public void OnReceiveMessage(UInt32 loot, UInt32 message, Int32 XP, Int32 jinPiao, Int32 yinPiao, List<ItemCountProperty> itemList)
    {

    }

    public void OnLevelUpdated(LevelUpdateProperty oldProperty, LevelUpdateProperty newProperty)
    {
        EventDispatcher.TriggerEvent<int>(Events.PlayerEvent.PlayerLevelUpdated, Property.Level.Value);
    }

    public void ShowLevel()
    {
        ViVisualHitEffectStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(LevelUpEffectId.Value);
        for (int iter = 0; iter < visualInfo.express.Length; ++iter)
        {
            ViAttachExpressStruct iterInfo = visualInfo.express[iter];
            if (!iterInfo.IsEmpty())
            {
                CellHero.LocalHero.OnEffectVisual(null, iterInfo, ViVector3.ZERO, null);
            }
        }
    }

    public void OnUpdateMarketItem(string tag, List<MarketSellItemProperty> list)
    {
        //ViewControllerManager.ShowMarketItemList(tag, list);
    }

    public Int32 GetItemCount(Int32 item)
    {
        return PlayerPropertyAssisstant.GetItemCount(Property, item);
    }

    #region Activity

    public void OnActivityEnter(UInt32 ID, UInt8 first)
    {

    }

    public void OnActivityExit(UInt32 ID)
    {

    }

    public bool ReqScore(UInt32 score, Int64 value, bool notify)
    {
        if (PlayerPropertyAssisstant.ReqActivityScore(Property, score, value))
        {
            return true;
        }
        else
        {
            if (notify)
            {
                EntityMessager messager = new EntityMessager();
                ScoreStruct info = ViSealedDB<ScoreStruct>.Data(score);
                messager.Append(info.Name);
                messager.Append(value);
                messager.Send(EntityMessage.SCORE_NOT_ENOUGH, true);
            }
            return false;
        }
    }

    #endregion

    #region Trade

    public void OnAddItemTrade(UInt8 result)
    {
        if (result == 1)
        {
            ////ViewControllerManager.AddTradeItemController.Close();
        }
    }

    public void OnUpdateItemTradeOwnList(List<ItemTradeProperty> list)
    {

    }

    public void OnUpdateItemTradeAuctionList(List<ItemTradeProperty> list)
    {

    }

    public void OnItemTradeBuySuc(UInt64 ID)
    {

    }

    public void OnUpdateItemTradeList(List<ItemTradeProperty> localList, UInt16 totalCount, UInt8 playerFlag)
    {
        ////ViewControllerManager.TradeController.UpdateTradeItems(localList, totalCount);
    }

    #endregion

    #region Guild
    public void OnGuildListUpdated(Int16 totalCount, List<GuildViewProperty> list)
    {

    }

    public void OnGuildSearchResult(List<GuildViewProperty> list)
    {

    }

    public void OnGuildApplyRecordUpdated(List<GuildViewProperty> list)
    {

    }

    public void OnGuildRecommandUpdated(List<GuildViewProperty> list)
    {
    }

    #endregion

    #region Friend

    public void OnFriendInvitedStart(ViString invitorName)
    {

    }

    public void OnFriendInvitedEnd()
    {

    }

    public void OnFriendSearchResult(List<PlayerShotProperty> list)
    {
        EventDispatcher.TriggerEvent<List<PlayerShotProperty>>(Events.FriendEvent.FriendSearchResult, list);
    }

    #endregion

    #region Chat

    public void OnChatRecordList(UInt8 channel, UInt32 count, UInt32 start, List<ChatRecordProperty> recordList)
    {
        ChatChannelType type = (ChatChannelType)channel;
        //
        //
        CenterChatGroup chatGroup = ChatGroupManager<CenterChatGroup>.Instance.Get(type);
        if (chatGroup != null)
        {
            List<ChatRecordProperty> sortList = new List<ChatRecordProperty>();
            StandardAssisstant.LoopListCopyTo(recordList, start, count, sortList);
            for (Int32 iter = 0; iter < sortList.Count; ++iter)
            {
                ChatRecordProperty iterRecord = sortList[iter];
                chatGroup.ContentList.Begin(iterRecord.Sayer);
                string chatText = chatGroup.ContentList.End(iterRecord.Content);
                chatText = WordFilterInstance.Instance.Filter(chatText);
            }
        }
    }

    #endregion

    #region Party
	public void OnGotoBigSpaceWithParty(UInt32 uiSpace, UInt64 uiTaget){
        ViDebuger.Record("----> OnGotoBigSpaceWithParty ");
    }
	public void OnVoteDelPartyMember(ViEntityID PlayerID)
    {
        ViDebuger.Record("----> OnVoteDelPartyMember ");
        PartyInstance.ReceiveTeamPleaseLeave(PlayerID);
    }
	//拒绝加入队伍请求
	public void OnPartyDisagreeRequest(ViEntityID PartyID)
	{
		ViDebuger.Record("----> OnPartyDisagreeRequest ");
        ViDebuger.Record("您被队伍拒绝了");
        //RemoveFromPartyRequestList(PartyID);
        //EventDispatcher.TriggerEvent(Events.PartyEvent.BeDisagree);
    }

    //private ViAsynCallback<ViReceiveDataNode, object> _agreeFastMatchCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    //private void _OnAgreeFastMatchUpdated(UInt32 dele, ViReceiveDataNode before, object after)
    //{
    //    ViDebuger.Record("----> _OnAgreeFastMatchUpdated " + (int)Property.AgreeJoinPartyLazy);
    //}
    public bool IsPartyAlreadyRequested(ViEntityID id)
    {
        if (requestList.ContainsKey(id))
            return true;
        return false;
    }
    public void AddToPartyRequestList(ViEntityID id)
    {
        if (!requestList.ContainsKey(id))
        {
            requestList.Add(id, 0);
        }
    }
    public void RemoveFromPartyRequestList(ViEntityID id)
    {
        if (requestList.ContainsKey(id))
        {
            requestList.Remove(id);
        }
    }
    private Dictionary<ViEntityID, int> requestList = new Dictionary<ViEntityID, ViArrayIdx>();
    private ViAsynCallback<ViReceiveDataNode, object> _partyRequestListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private void _OnPartyRequestListUpdated(UInt32 dele, ViReceiveDataNode before, object after) {
        ViDebuger.Record("------> _OnPartyRequestListUpdated " + Property.RequestPartyList.Count);
        for (int i = 0; i < Property.RequestPartyList.Count; i++)
        {
            AddToPartyRequestList(Property.RequestPartyList[i].Property.ID);
        }
        int result = -1;
        List<ViEntityID> toRemove = new List<ViEntityID>();
        foreach(ViEntityID key in requestList.Keys) //检测并移除缓存的申请id
        {
            result = -1;
            for (int j = 0; j < Property.RequestPartyList.Count; j++)
            {
                if(Property.RequestPartyList[j].Property.ID == key)
                {
                    result = 1;
                    break;
                }
            }
            if (result == -1)
            {
                toRemove.Add(key);
            }
        }
        foreach (ViEntityID key in toRemove)
        {
            RemoveFromPartyRequestList(key);
        }
    }
    private ViAsynCallback<ViReceiveDataNode, object> _partyInviteListCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    private void _OnPartyInviteListUpdated(UInt32 dele, ViReceiveDataNode before, object after)
    {
        ViDebuger.Record("----->Player _OnPartyInviteListUpdated" + (int)Property.PartyInviteList.Count);
        if (Property.PartyInviteList.Count > 0 /*&& !isOnInviting */&& !PartyInstance.IsInParty)
        {
            //isOnInviting = true;
            List<PartyInfoStruct> inviteList = new List<PartyInfoStruct>();
            for(int i = 0; i < Property.PartyInviteList.Count; i++)
            {
                partyInvite = new PartyInfoStruct()
                {
                    ID = Property.PartyInviteList[i].Property.PartyID,
                    LeaderID = Property.PartyInviteList[i].Property.Leader.ID,
                    Leader = new PartyMemberStruct()
                    {
                        NameAlias = Property.PartyInviteList[i].Property.Leader.NameAlias,
                        Level = Property.PartyInviteList[i].Property.PlayerDetailLite.Level, //Property.PartyInviteList[0].Property.Leader.  缺级别
                        Photo = Property.PartyInviteList[i].Property.Leader.Photo
                    }
                    
                };
                inviteList.Add(partyInvite);
            }

            UIManagerUtility.ShowTeamInvite(true, inviteList, DisagreeJoinToParty, AgreeJoinToParty);
            //UIManagerUtility.ShowTeamInviteTip(partyInvite.ID, TeamInviteTipType.InviteJoinTeam, 
            //DisagreeJoinToParty,AgreeJoinToParty,partyInvite.Leader);
        }
        else
        {
            UIManagerUtility.ShowTeamInvite(false, null,null,null);
        } 
    }
    private bool isOnInviting;
    private PartyInfoStruct partyInvite;
    public void AgreeJoinToParty(object partyId)
    {
        //if(/*isOnInviting && */partyInvite != null && !PartyInstance.IsInParty)
        {
            ViDebuger.Record("----->Player AgreeJoinToParty " + (ViEntityID)partyId);
            if(!PartyInstance.IsInParty)
                PlayerServerInvoker.AgreePartyInvite(Player.Instance, (ViEntityID)partyId);
            //isOnInviting = false;
            //partyInvite = null;
        }
    }
    public void DisagreeJoinToParty(object partyId)
    {
        //if (/*isOnInviting &&*/ partyInvite != null)
        {
            ViDebuger.Record("----->Player DisagreeJoinToParty " + (ViEntityID)partyId);
            PlayerServerInvoker.DisagreePartyInvite(Player.Instance, (ViEntityID)partyId);
            //isOnInviting = false;
            //partyInvite = null;
        }
    }
    //private Dictionary<UInt64, PartyInfoStruct> _inviteList = new Dictionary<ViEntityID, PartyInfoStruct>();
    //public PartyInfoStruct GetInviteInfo(UInt64 leaderID)
    //{
    //    if (_inviteList.ContainsKey(leaderID))
    //    {
    //        return _inviteList[leaderID];
    //    }
    //    return null;
    //}
    //这个方法目前没有用
    public void OnPartyInvite(UInt64 partyID, string partyName, UInt64 leaderID, string leaderName)
	{
        ViDebuger.Record("----->NO USE METHOD OnPartyInvite : Player be invite:" + leaderName);
        //PartyInfoStruct partyInfo = GetInviteInfo(leaderID);
        //if(partyInfo == null)
        //{
        //    partyInfo = new PartyInfoStruct();
        //    _inviteList.Add(leaderID, partyInfo);
        //}
        //PlayerServerInvoker.AgreePartyInvite(Player.Instance, partyID);
	}

	public void OnPartyFire(string party)
	{
		ViDebuger.Record("----->Player OnPartyFire");
	}

	public void OnPartyDisband(string party)
	{
		ViDebuger.Record("----->Player OnPartyDisband");
	}

	public void OnPartyList(List<PartyDetail> partyList)
	{
		ViDebuger.Record("----->Player OnPartyList" + partyList.Count);
		EventDispatcher.TriggerEvent<List<PartyDetail>>(Events.PartyEvent.PartyListUpdate,partyList);
	}
	public void OnPartyDisagree(UInt64 PartyID)
	{
	}
	#endregion


	#region Money

	public void OnTransferJinZiResult(UInt8 result)
	{

	}

	public bool ReqMoeny(MoneyStruct info)
	{
		return ReqMoeny(info, false);
	}
	public bool ReqMoeny(MoneyStruct info, bool notify)
	{
		return ReqMoeny((MoneyType)info.Type.Value, info.Value, notify);
	}
	public bool ReqMoeny(MoneyType type, Int64 value)
	{
		return ReqMoeny(type, value, false);
	}
	public bool ReqMoeny(MoneyType type, Int64 value, bool notify)
	{
		if (PlayerPropertyAssisstant.ReqMoeny(Property, type, value))
		{
			return true;
		}
		else
		{
			if (notify)
			{
				EntityMessager messager = new EntityMessager();
				messager.Append(value);
				switch (type)
				{
					case MoneyType.YINPIAO:
						messager.Send(EntityMessage.YINPIAO_UNENOUGH, true);
						break;
					case MoneyType.JINPIAO:
						messager.Send(EntityMessage.JINPIAO_UNENOUGH, true);
						break;
					case MoneyType.JINZI:
						messager.Send(EntityMessage.JINZI_UNENOUGH, true);
						break;
				}
			}
			return false;
		}
	}

	#endregion

	#region Goal
	public void ResponseGoal(UInt32 goal)
	{
		if (!Property.GoalCompletedList.Contain(goal))
		{
			PlayerServerInvoker.ResponseGoal(this, goal);
		}
	}
	#endregion


	#region Space

	public static ViConstValue<float> VALUE_SpaceWinReportDelayTime = new ViConstValue<float>("SpaceWinReportDelayTime", 3.5f);
	public static ViConstValue<float> VALUE_SpaceLoseReportDelayTime = new ViConstValue<float>("SpaceLoseReportDelayTime", 3.5f);

	public void OnSmallSpacePVERecordUpdate(UInt32 space, SpaceRecordProperty record)
	{

	}

	public void OnSmallSpacePVEWin(UInt32 space, Int32 XP, Int32 yinPiao, List<ItemCountProperty> itemList)
	{
		//ViewControllerManager.SpaceReportView.ShowReport(true);
	}

	public void OnSmallSpacePVELose(UInt32 space)
	{
		//ViewControllerManager.SpaceReportView.ShowReport(false);
	}

	public void OnSmallSpacePVPWin(UInt32 space, Int32 rankScore)
	{
		//ViewControllerManager.SpaceReportView.ShowReport(true);
	}

	public void OnSmallSpacePVPLose(UInt32 space, Int32 rankScore)
	{
		//ViewControllerManager.SpaceReportView.ShowReport(false);
	}

	#endregion

	public void OnNPCLoot(UInt32 packedID, Int32 XP, Int32 yinPiao, List<ItemCountProperty> itemList)
	{
		CellNPC entity = Client.Current.EntityManager.GetPackEntity<CellNPC>(packedID);
		if (entity != null && CellHero.LocalHero != null)
		{
			CellHero.LocalHero.OnNPCLoot(entity, XP, yinPiao, itemList);
		}
	}

	public void UIEvent(UInt32 showID)
	{
		UIEventStruct info = ViSealedDB<UIEventStruct>.Data(showID);
		//ViewControllerInterface view = //ViewControllerManager.GetViewController(info.Window);
		//if (view != null)
		//{
		//	view.UIEventShow(showID);
		//}
	}

	public void UIEvent(UInt32 showID, UInt16 slot)
	{
		UIEventStruct info = ViSealedDB<UIEventStruct>.Data(showID);
		//ViewControllerInterface view = //ViewControllerManager.GetViewController(info.Window);
		//if (view != null)
		//{
		//	view.UIEventShow(showID, slot);
		//}
	}

    public void OnGoalEndNeedClick(UInt32 id)
    {
        EventDispatcher.TriggerEvent<uint>(Events.GoalEvent.OnGoalEndNeedClick,id);
    }
    public void EnterStoryModel(uint goalID)
    {
        EventDispatcher.TriggerEvent<uint, bool>(Events.StoryEvent.SetStoryModel, goalID, true);
    }
    public void ExitStoryModel(uint goalID)
    {
        EventDispatcher.TriggerEvent<uint, bool>(Events.StoryEvent.SetStoryModel, goalID, false);
    }

    public void OnScoreRankUpdate(UInt32 rank, UInt32 position)
	{

	}

	#region Game Func

	public void OnFuncOpen(UInt32 funcID)
	{
		//
	}

	public bool IsFunctionOpen(GameFuncStruct func)
	{
		return PlayerPropertyAssisstant.IsFunctionOpen(Property, func);
	}
	public bool IsFunctionOpen(GameFuncStruct func, bool notify)
	{
		bool open = PlayerPropertyAssisstant.IsFunctionOpen(Property, func);
		if (!open && notify)
		{
			if (func.ReqPlayerLevel.NotEmpty() && func.ReqPlayerLevel < 999 && Property.Level.Value < func.ReqPlayerLevel.Value)
			{
				EntityMessager messager = new EntityMessager();
				messager.Append(func.ReqPlayerLevel.Value);
				messager.Send(EntityMessage.LEVEL_NOT_ENOUGH1, true);
			}
			else
			{
				EntityMessager messager = new EntityMessager();
				messager.Append(func.Name);
				messager.Send(EntityMessage.FUNC_CLOSED, true);
			}
		}
		return open;
	}
	#endregion

	#region Time
	public Int64 OnceOnlineDuration
	{
		get
		{
			return ViTimerInstance.Time - Property.ActiveTime;
		}

	}

	public Int64 AccumulateDuration
	{
		get { return Property.AccumulateOnlineDuration + OnceOnlineDuration; }
	}

	public Int64 WorldTime
	{
		get
		{
			return Property.LoginTime + OnceOnlineDuration;
		}

	}

	public Int64 CreateDuration
	{
		get { return WorldTime - Property.CreateTime; }

	}

	public bool IsActiveTime(ViActiveDuration kDuration)
	{
		return IsActiveTime((ViStartTimeType)kDuration.Start.Value, (ViAccumulateTimeType)kDuration.Accumulate.Value, kDuration.StartTimeValue, kDuration.Duration.Value);
	}

	public bool IsActiveTime(ViStartTimeType eStart, ViAccumulateTimeType eAccumulate, Int64 iStartTime, Int64 iDuration)
	{
		switch (eStart)
		{
			case ViStartTimeType.WORLD:
				{
					return ViActiveDuration.IsActive(WorldTime, iStartTime, iDuration);
				}
			case ViStartTimeType.ENTITY:
				{
					if (eAccumulate == ViAccumulateTimeType.WORLD)
					{
						return ViActiveDuration.IsActive(CreateDuration, iStartTime, iDuration);
					}
					else
					{
						return ViActiveDuration.IsActive(AccumulateDuration, iStartTime, iDuration);
					}
				}
			case ViStartTimeType.WORLD1970:
				{
					return ViActiveDuration.IsActive(ViTimerInstance.Time1970, iStartTime, iDuration);
				}
			default:
				return ViActiveDuration.IsActive(WorldTime, iStartTime, iDuration);
		}
	}
    #endregion

    public static void SendCompleteHint(HintStruct info)
	{
		if (Instance != null && info != null && !Instance.Property.HintList.Contain((UInt32)info.ID))
		{
			PlayerServerInvoker.CompleteHint(Instance, (UInt32)info.ID);
		}
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _asLocal;
	bool _active;
	PlayerReceiveProperty _property;
}
