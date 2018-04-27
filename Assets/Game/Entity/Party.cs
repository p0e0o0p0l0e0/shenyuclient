using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public class PartyInfoStruct
{
    public UInt64 ID { get; set; }
    public ViString Name { get; set; }
    public UInt64 LeaderID { get; set; }

    public PartyMemberStruct Leader;
}
public class PartyMemberStruct
{
    public UInt64 ID { get; set; }
    public byte Gender { get; set; }
    public ViString Name { get; set; }
    public ViString NameAlias { get; set; }
    public UInt8 Photo { get; set; }
    public HeroClass HeroClass { get; set; }
    public int Level { get; set; }
    public bool IsLeader { get; set; }
    public bool IsOnline { get; set; }
}
//
//
public class Party : ViRPCEntity, ViEntity
{
    public ViRPCInvoker RPC { get { return _RPC; } }
    ViRPCInvoker _RPC = new ViRPCInvoker();
    public string Name { get { return "Party"; } }
    public ViEntityID ID { get { return _ID; } }
    public UInt32 PackID { get { return _PackID; } }
    public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
    public bool IsLocal { get { return false; } }
    public bool Active { get { return _active; } }
    public PartyReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }

    public bool IsLeader { get { return Property.Leader.ID == Player.Instance.ID; } }
    public bool IsGroup { get { return Property.MaxMemberCount == 9; } }
    public int MaxMemberCount { get { return Property.MaxMemberCount; } }
    public int MemberCount
    {
        get
        {
            return (int)Property.MemberList.Count;
        }
    }

    private void _GetMember(int index, ref PartyMemberStruct m)
    {
        m.ID = Property.MemberList[index].Property.Identification.ID;
        m.Gender = Property.MemberList[index].Property.Gender;
        m.Level = Property.MemberList[index].Property.Level;
        m.Name = Property.MemberList[index].Property.Identification.Name;
        m.NameAlias = Property.MemberList[index].Property.Identification.NameAlias;
        m.Photo = Property.MemberList[index].Property.Identification.Photo;
        m.HeroClass = (HeroClass)(Property.MemberList[index].Property.Class.Value);
        m.IsLeader = Property.Leader.ID == m.ID;
        m.IsOnline = Property.MemberList[index].Property.Online == 1;
        ViDebuger.Record("" + (int)Property.MemberList[index].Property.Online);
    }
    private PartyMemberStruct[] _partyMember;
    private PartyMemberStruct _Leader;
    public PartyMemberStruct GetMember(int index)
    {
        if (index >= 0 && index < _partyMember.Length)
        {
            return _partyMember[index];
        }
        return null;
    }
    public PartyMemberStruct GetMemberById(ulong id)
    {
        for (int i = 0; i < _partyMember.Length; i++)
        {
            if (_partyMember[i].ID == id)
                return _partyMember[i];
        }
        return null;
    }
    public PartyMemberStruct[] GetAllMember()
    {
        return _partyMember;
    }
    public bool SelfReady
    {
        get
        {
            for (Int32 iter = 0; iter < Property.MemberList.Count; ++iter)
            {
                if (Property.MemberList[iter].Property.Identification.ID == Player.Instance.ID)
                {
                    return Property.MemberList[iter].Property.Ready == 1;
                }
            }
            return false;
        }
    }

    public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
    {
        _ID = ID;
        _PackID = PackID;
    }
    public void SetActive(bool value)
    {
        _active = value;
    }
    public void PreStart() { }
    public void Start()
    {
        ViDebuger.Record("=================Party Start===============");
        PartyInstance.Start(this);
        EventDispatcher.TriggerEvent(Events.PartyEvent.EnterParty); //这个在先，memberchange在后
        //EventDispatcher.TriggerEvent(Events.PartyEvent.MemberChange);
        //EventDispatcher.TriggerEvent(Events.PartyEvent.LeaderChange);
        Property.Leader.CallbackList.Attach(_leaderCallback, _OnLeaderUpdated);
        Property.MemberList.CallbackList.Attach(_memberlistCallback, _OnMemberListUpdated);
        Property.RequestList.CallbackList.Attach(_requestlistCallback, _OnRequestListUpdated);
        Property.RecommandList.CallbackList.Attach(_recommandlistCallback, _OnRecommandListUpdated);
        Property.InviteeList.CallbackList.Attach(_inviteelistCallback, _OnInviteeListUpdated);
        Property.Target.CallbackList.Attach(_targetCallback, _OnTargetUpdated);
        Property.AgreeJoinPartyLazy.CallbackList.Attach(_JoinPartyCallback, _OnJoinPartyUpdated);
    }
    public void AftStart()
    {
        Property.Matching.CallbackList.Attach(_matchingCallback, this._OnMatchingUpdated);
    }
    public void ClearCallback()
    {
        _leaderCallback.End();
        _memberlistCallback.End();
        _requestlistCallback.End();
        _recommandlistCallback.End();
        _inviteelistCallback.End();
    }
    public void PreEnd()
    {
        _matchingCallback.End();
    }
    public void End()
    {

        ViDebuger.Record("=================Party End===============");
        for (int i = 0; i < _partyMember.Length; i++)
            _partyMember[i] = null;
        _partyMember = null;


        PartyInstance.End();
        EventDispatcher.TriggerEvent(Events.PartyEvent.ExitTeam);
    }
    public void AftEnd() { }
    public void Tick(float fDeltaTime) { }
    public void StartProperty(UInt16 channelMask, ViIStream IS)
    {
        ViDebuger.Record("=================Party StartProperty===============");
        _property = ViReceiveDataCache<PartyReceiveProperty>.Alloc();
        _property.StartProperty(channelMask, IS, this);
        _partyMember = new PartyMemberStruct[_property.MaxMemberCount];
        #region TEST
        ViDebuger.Record("Party Start Leader " + (int)(Property.Leader.ID.Value) + "," + (UInt8)(Property.Leader.Photo));
        ViDebuger.Record("Party Start Count " + (int)(Property.MaxMemberCount));
        ViDebuger.Record("Party Start Match " + (int)(Property.Matching));
        ViDebuger.Record("Party Start members " + (int)(Property.MemberList.Count));
        #endregion
        _PartyMemberUpdate();
    }
    private void _PartyMemberUpdate()
    {
        int leaderIndex = -1;
        for (int i = 0; i < Property.MemberList.Count; i++)
        {
            if (Property.Leader.ID == Property.MemberList[i].Property.Identification.ID)
            {
                leaderIndex = i;
                if (_partyMember[0] == null)
                    _partyMember[0] = new PartyMemberStruct();
                _GetMember(leaderIndex, ref _partyMember[0]);
            }
        }
        int changedIndex = -1;
        for (Int32 iter = 0; iter < Property.MemberList.Count; ++iter)
        {
            if (iter != leaderIndex)
            {
                if (iter < leaderIndex)
                    changedIndex = iter + 1; //第一个位置是主角，所以后移一位
                else
                    changedIndex = iter; //主角数据位置隔过去了，所以位置变为正确的
                ViDebuger.Record("member Id == " + (int)Property.MemberList[iter].Property.Identification.ID.Value + "," + (Property.MemberList[iter].Property.Identification.ID.Value == Player.Instance.ID));
                if (_partyMember[changedIndex] == null)
                    _partyMember[changedIndex] = new PartyMemberStruct();
                _GetMember(iter, ref _partyMember[changedIndex]);
            }
        }
        for (int i = Property.MemberList.Count; i < _property.MaxMemberCount; i++)
        {
            _partyMember[i] = null;
        }
    }
    public void EndProperty()
    {
        _property.EndProperty(this);
    }
    public void ClearProperty()
    {
        ViReceiveDataCache<PartyReceiveProperty>.Free(_property);
        _property = null;
    }
    public void OnPropertyUpdateStart(UInt8 channel) { }
    public void OnPropertyUpdateEnd(UInt8 channel) { }
    public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
    {
        _property.OnPropertyUpdate(channel, IS, this);
    }

    public bool IsMatching
    {
        get
        {
            return Property.Matching == (UInt8)1;
        }
    }
    #region 队伍信息监听回调
    ViAsynCallback<ViReceiveDataNode, object> _leaderCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnLeaderUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnLeaderUpdated " + Property.Leader.NameAlias);
        _PartyMemberUpdate();
        EventDispatcher.TriggerEvent(Events.PartyEvent.LeaderChange);
    }

    ViAsynCallback<ViReceiveDataNode, object> _requestlistCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnRequestListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnRequestListUpdated" + Property.RequestList.Count);
        EventDispatcher.TriggerEvent(Events.PartyEvent.PartyApplyChange);
    }

    ViAsynCallback<ViReceiveDataNode, object> _recommandlistCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnRecommandListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnRecommandListUpdated 暂时未用到" + Property.MemberList.Count);
    }
    ViAsynCallback<ViReceiveDataNode, object> _inviteelistCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnInviteeListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnInviteeListUpdated" + Property.InviteeList.Count);
        for (int i = 0; i < Property.InviteeList.Count; i++)
        {
            ViDebuger.Record("invite:" + (UInt64)Property.InviteeList[i].Property.Identification.ID + " " + Property.InviteeList[i].Property.Identification.Name + " " + Property.InviteeList[i].Property.Identification.NameAlias);
        }
    }
    ViAsynCallback<ViReceiveDataNode, object> _memberlistCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnMemberListUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnMemberListUpdated" + Property.MemberList.Count);
        _PartyMemberUpdate();
        EventDispatcher.TriggerEvent(Events.PartyEvent.MemberChange);

    }
    #endregion
    ViAsynCallback<ViReceiveDataNode, object> _matchingCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnMatchingUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > 匹配，暂时未开启");
        if (IsMatching)
        {
            //ViewControllerManager.PartyMatchingView.Open();
        }
        else
        {
            //ViewControllerManager.PartyMatchingView.Close();
        }
    }

    ViAsynCallback<ViReceiveDataNode, object> _targetCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnTargetUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnLeaderUpdated " + Property.Leader.NameAlias);
        EventDispatcher.TriggerEvent(Events.PartyEvent.PartyTargetChange);
    }

    ViAsynCallback<ViReceiveDataNode, object> _JoinPartyCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnJoinPartyUpdated(UInt32 dele, ViReceiveDataNode old, object now)
    {
        ViDebuger.Record("---- > _OnLeaderUpdated " + Property.Leader.NameAlias);
        EventDispatcher.TriggerEvent(Events.PartyEvent.PartyJoinChange);
    }
    public bool IsPartyLeader(UInt64 id)
    {
        return (id == Property.Leader.ID);
    }
    public bool IsMe(UInt64 id)
    {
        return (id == Player.Instance.ID);
    }
    public bool HasSpace(UInt32 space)
    {
        for (int iter = 0; iter < Property.MatchingList.Count; ++iter)
        {
            ReceiveDataPartySpaceMatchProperty iterProperty = Property.MatchingList[iter].Property;
            if (space == iterProperty.Space)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasMember(UInt64 player)
    {
        for (int iter = 0; iter < Property.MemberList.Count; ++iter)
        {
            ReceiveDataPartyMemberProperty iterProperty = Property.MemberList[iter].Property;
            if (player == iterProperty.Identification.ID)
            {
                return true;
            }
        }
        return false;
    }
    public bool HasMember(string name)
    {
        for (int iter = 0; iter < Property.MemberList.Count; ++iter)
        {
            ReceiveDataPartyMemberProperty iterProperty = Property.MemberList[iter].Property;
            if (name == iterProperty.Identification.NameAlias)
            {
                return true;
            }
        }
        return false;
    }

    ViEntityID _ID;
    UInt32 _PackID;
    bool _active;
    PartyReceiveProperty _property;
}

public class PartyInstance
{
    public static bool IsInParty
    {
        get { return _instance != null; }
    }
    /// <summary>
    /// 获取列表中的第几个队伍成员
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static PartyMemberStruct GetMember(int index)
    {
        return Instance.GetMember(index);
    }
    public static PartyMemberStruct[] GetAllMember()
    {
        return Instance.GetAllMember();
    }
    /// <summary>
    /// 当前的我是不是队长
    /// </summary>
    /// <returns></returns>
    public static bool IsLeader
    {
        get
        {
            return IsInParty && _instance.IsLeader;
        }
    }
    public static bool IsMe(UInt64 id)
    {
        return _instance.IsMe(id);
    }
    public static bool IsMyParty(UInt64 id)
    {
        return IsInParty && id == _instance.ID;
    }
    public static bool IsPartyLeader(UInt64 id)
    {
        return _instance.IsPartyLeader(id);
    }
    public static int MemberCount
    {
        get
        {
            return _instance.MemberCount;
        }
    }
    /// <summary>
    /// 临时这么取，看将来服务器结构
    /// </summary>
    /// <param name="party"></param>
    public static HeroClass FindPartyLeaderHeroClassInParty(PartyDetail party, PlayerIdentificationProperty leader)
    {
        PartyMemberProperty p = party.member.Find(m =>
        {
            return m.Identification.ID == leader.ID;
        });
        return (HeroClass)p.Class;
    }

    public static UInt8 FindPartyLeaderGenderInParty(PartyDetail party, PlayerIdentificationProperty leader)
    {
        PartyMemberProperty p = party.member.Find(m =>
        {
            return m.Identification.ID == leader.ID;
        });
        return p.Gender;
    }
    public static int FindPartyLeaderLevel(PartyDetail party, PlayerIdentificationProperty leader)
    {
        PartyMemberProperty p = party.member.Find(m =>
        {
            return m.Identification.ID == leader.ID;
        });
        if (p.IsNull<PartyMemberProperty>())
        {
            ViDebuger.Error("Not Find Leader in Party!");
            return 0;
        }

        return p.Level;
    }
    public static bool IsFastMatching
    {
        get; set;
    }
    /// <summary>
    /// 是否是团队
    /// </summary>
    public static bool IsGroup
    {
        get
        {
            return _instance.IsGroup;
        }
    }
    #region 目前不用的旧代码
    //以前的回调机制，即将废除          ↓
    public static ViEventList EventCreate { get { return _CreateEvent; } }
    public static ViEventList EventExit { get { return _ExitEvent; } }
    static ViEventList _CreateEvent = new ViEventList();
    static ViEventList _ExitEvent = new ViEventList();
    #endregion
    #region 单例&出入口
    public static Party Instance { get { return _instance; } }
    private static Party _instance;
    public static void Start(Party record)
    {
        _instance = record;
        //if (_instance != null)
        //{
        //	EventCreate.Invoke(0);
        //}
    }
    public static void End()
    {
        _instance = null;
        //EventExit.Invoke(0);
    }
    #endregion

    #region 消息接口
    public static void InviteMemberToParty(UInt64 memberId)
    {
        if (IsLeader && !_instance.HasMember(memberId))
        {
            PlayerServerInvoker.InvitePartyMember(Player.Instance, memberId, 0);
        }
#if UNITY_EDITOR
        else
        {
            ViDebuger.Record("Not leader or Invited this member already");
        }
#endif
    }

    public static void InviteMemberToParty(string memberName)
    {
        if (IsLeader && !_instance.HasMember(memberName))
        {
            PlayerServerInvoker.InvitePartyMember(Player.Instance, memberName, 0);
        }
#if UNITY_EDITOR
        else
        {
            ViDebuger.Record("Not leader or Invited this member already");
        }
#endif
    }
    public static void RemoveMemberFromParty(UInt64 memberId)
    {
        if (IsLeader && _instance.HasMember(memberId))
        {
            PlayerServerInvoker.DelPartyMember(Player.Instance, memberId);
        }
#if UNITY_EDITOR
        else
        {
            ViDebuger.Record("Not leader or Not Have this member");
        }
#endif
    }
    public static void CreateParty(ViEntityACK.DeleACKCallback callback)
    {
        if (!PartyInstance.IsInParty)
        {
            ViDebuger.Record("-----> Create Party");
            PlayerServerInvoker.CreateParty(Player.Instance, (ushort)PartyType.OUTDOOR, callback);
        }
#if UNITY_EDITOR
        else
        {
            ViDebuger.Record("Already in Party");
        }
#endif
    }
    public static void ExitParty()
    {
        if (IsInParty && _instance.HasMember(Player.Instance.ID))
        {
            PlayerServerInvoker.ExitParty(Player.Instance);
        }
#if UNITY_EDITOR
        else
        {
            ViDebuger.Record("Not In Party");
        }
#endif
    }
    public static void AgreeHeJoinParty(int index)
    {
        if (index >= 0 && index < _instance.Property.RequestList.Count && IsLeader && MemberCount < _instance.MaxMemberCount)
        {
            ViEntityID memberId = _instance.Property.RequestList[index].Property.Identification.ID;
            if (!_instance.HasMember(memberId))
            {
                ViDebuger.Record("To Agree the requst");
                PlayerServerInvoker.AgreeJoinParty(Player.Instance, memberId);
            }
#if UNITY_EDITOR
            else
            {
                ViDebuger.Record("Not Leader or Member already Join");
            }
#endif
        }
#if UNITY_EDITOR        
        else
        {
            ViDebuger.Record("member index out of range");
        }
#endif
    }

    public static void DisagreeHeJoinParty(int index)
    {
        if (IsLeader && _instance.Property.RequestList.Count > 0)
        {
            ViDebuger.Record("To DisAgree the First Request");
            PlayerServerInvoker.DisagreeJoinParty(Player.Instance, _instance.Property.RequestList[index].Property.Identification.ID);
        }
        else
        {
            ViDebuger.Record("Not have an Request");
        }
    }

    public static void FastMatching(List<ulong> targetList = null)
    {
        if (targetList == null)
            targetList = new List<ulong>();
        PlayerServerInvoker.RequestJoinPartyLazy(Player.Instance, targetList);
    }


    public static void ChangeMatchingStage(bool isMat)
    {
        IsFastMatching = isMat;
        EventDispatcher.TriggerEvent(Events.PartyEvent.FastMatching, IsFastMatching);
    }

    //战斗中请离投票
    public static void ReceiveTeamPleaseLeave(ViEntityID PlayerID)
    {
        PartyMemberStruct member = _instance.GetMemberById(PlayerID);

        if (member != null)
        {
            PartyInfoStruct info = new PartyInfoStruct();
            info.Leader = member;
            info.ID = member.ID;
            UIManagerUtility.ShowPleaseLeaveTip(
                (obj) =>
                {
                    SendTeamPleaseLeave((ulong)obj, false);
                },
                (obj) =>
                {
                    SendTeamPleaseLeave((ulong)obj, true);
                }, info);
        }
    }

    public static void SendTeamPleaseLeave(ulong id, bool isDel)
    {
        PlayerServerInvoker.ReplyVoteDelPartyMember(Player.Instance, id, (byte)(isDel ? 1 : 0));
    }
    #endregion
}