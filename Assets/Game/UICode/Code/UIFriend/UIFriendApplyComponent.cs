using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendApplyComponent : UIWindowComponent<UIFriendWindow, UIFriendContoller>
{
    #region ui define
    private const string FriendText = "/FriendText";
    private const string FriendNumText = "/FriendNumText";
    private const string TotalRefuseBtn = "/TotalRefuseBtn";
    private const string TotalRefuseBtnText = "/TotalRefuseBtn/Text";
    private const string TotalAcceptBtn = "/TotalAcceptBtn";
    private const string TotalAcceptBtnText = "/TotalAcceptBtn/Text";
    private const string FriendList = "/FriendList";
    private const string FriendListContent = "/FriendList/Content/";
    //item
    private const string Head = "/Head";
    private const string Job = "/Job";
    private const string Level = "/Level";
    private const string Name = "/Name";
    private const string BattleText = "/BattleText";
    private const string BattleNumText = "/BattleNumText";
    private const string ArmyGroupNameText = "/ArmyGroupNameText";
    private const string AcceptBtn = "/AcceptBtn";
    private const string AcceptBtnText = "/AcceptBtn/Text";
    private const string RefuseBtn = "/RefuseBtn";
    private const string RefuseBtnText = "/RefuseBtn/Text";
    private const string Select = "Select";
    #endregion

    private ExText friendText;
    private ExText friendNumText;
    private ExUIButton totalRefuseBtn;
    private ExText totalRefuseBtnText;
    private ExUIButton totalAcceptBtn;
    private ExText totalAcceptBtnText;

    //item
    private ExUISprite head;
    private ExUISprite job;
    private ExText level;
    private ExText name;
    private ExText battleText;
    private ExText battleNumText;
    private ExText armyGroupNameText;
    private ExUIButton acceptBtn;
    private ExText acceptBtnText;
    private ExUIButton refuseBtn;
    private ExText refuseBtnText;

    private LoopVerticalScrollRect friendList;

    private int _listCount = 0;

    private const string CareerIconAtlas = "CareerIconAtlas";
    private const string HeroIconAtlas = "HeroIconAtlas";

    public override void Initial(UIFriendWindow window, string topPath)
    {
        base.Initial(window, topPath);

        friendText = GetComponent<ExText>(FriendText);

        friendNumText = GetComponent<ExText>(FriendNumText);

        totalRefuseBtn = GetComponent<ExUIButton>(TotalRefuseBtn);
        totalRefuseBtn.onClickEx = OnTotalRefuseBtnClick;

        totalRefuseBtnText = GetComponent<ExText>(TotalRefuseBtnText);

        totalAcceptBtn = GetComponent<ExUIButton>(TotalAcceptBtn);
        totalAcceptBtn.onClickEx = OnTotalAcceptBtnClick;

        totalAcceptBtnText = GetComponent<ExText>(TotalAcceptBtnText);

        friendList = GetComponent<LoopVerticalScrollRect>(FriendList);
        friendList.Init(OnFriendListRefresh, 0);
    }

    public override void Dispose()
    {
        base.Dispose();
        UIAtlasManager.Instance.UnLoad(CareerIconAtlas);
        UIAtlasManager.Instance.UnLoad(HeroIconAtlas);
    }

    public void Show()
    {
        RefreshFriendApplyList();
        EventDispatcher.AddEventListener(Events.FriendEvent.FriendApplyRefresh, RefreshFriendApplyList);
    }

    public void Hide()
    {
        EventDispatcher.RemoveEventListener(Events.FriendEvent.FriendApplyRefresh, RefreshFriendApplyList);
    }

    private void RefreshFriendApplyList()
    {
        _listCount = PlayerFriendList.Instance.Property.FriendInvitorList.Count;
        friendNumText.text = _listCount.ToString();
        friendList.ChangeTotalCount(_listCount);
        friendList.RefillCells();
    }

    private void OnFriendListRefresh(string str, int index)
    {
        string sName = FriendListContent + str;
        Transform tran = GetComponent<Transform>(sName);
        if (index >= _listCount)
        {
            tran.SetActive<Transform>(false);
        }
        else
        {
            UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
            {
                UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.Gender,
                   PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.Class), HeroIconAtlas);
            });
            UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
            {
                UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.Gender,
                    PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.Class), CareerIconAtlas);
            });

            GetComponent<ExText>(sName + Level).text = PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.Level.Value.ToString();
            GetComponent<ExText>(sName + Name).text = PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.Identification.NameAlias.Value;
            GetComponent<ExText>(sName + BattleNumText).text = PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.FightPower.Value.ToString();

            if (PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.HasGuild == 0)
            {
                GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
            }
            else if (PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.HasGuild == 1)
            {
                GetComponent<ExText>(sName + ArmyGroupNameText).text = PlayerFriendList.Instance.Property.FriendInvitorList[index].Property.GuildName.Value;
            }

            ExUIButton acceptBtn = GetComponent<ExUIButton>(sName + AcceptBtn);
            acceptBtn.Id = index;
            acceptBtn.onClickEx = OnItemAcceptBtnClick;
            ExUIButton refuseBtn = GetComponent<ExUIButton>(sName + RefuseBtn);
            refuseBtn.Id = index;
            refuseBtn.onClickEx = OnItemRefuseBtnClick;
            UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
            uIPointerListener.OnTouchUpCallBack = OnItemClick;
        }
    }

    private void OnItemClick(int val, object obj)
    {
        for (int i = 0; i < _listCount; i++)
        {
            if (i == val)
            {
                friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(true);
                continue;
            }
            friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(false);
        }
    }

    private string GetIconStr(Byte _gender, Byte _class)
    {
        return ViSealedDB<VisualCorner>.Data(_gender * 6 + _class).iconName;
    }

    private string GetProfessionIconStr(Byte _gender, Byte _class)
    {
        return ViSealedDB<VisualCorner>.Data(_gender * 6 + _class).professionIcon + "1";
    }

    private void OnItemAcceptBtnClick(int val,object obj)
    {        
        PlayerServerInvoker.FriendInvitedResponse(Player.Instance, (UInt16)val, 1);
        friendList.GetTransformByIndex(val).SetActive(false);
    }

    private void OnItemRefuseBtnClick(int val,object obj)
    {        
        PlayerServerInvoker.FriendInvitedResponse(Player.Instance, (UInt16)val, 0);
        friendList.GetTransformByIndex(val).SetActive(false);
    }

    private void OnTotalRefuseBtnClick(int val, object obj)
    {
        PlayerServerInvoker.FriendInvitedResponseAll(Player.Instance, 0, HideAllItem);        
    }

    private void OnTotalAcceptBtnClick(int val, object obj)
    {
        PlayerServerInvoker.FriendInvitedResponseAll(Player.Instance, 1, HideAllItem);        
    }

    private void HideAllItem()
    {
        for (int i = 0; i < _listCount; i++)
        {
            friendList.GetTransformByIndex(i).SetActive(false);
        }
        friendNumText.text = "0";
    }
}
