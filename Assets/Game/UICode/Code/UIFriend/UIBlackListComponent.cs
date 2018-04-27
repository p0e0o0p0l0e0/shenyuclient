using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlackListComponent : UIWindowComponent<UIFriendWindow, UIFriendContoller>
{
    #region ui define
    private const string BlackNumText = "/BlackNumText";
    private const string BlackText = "/BlackText";
    private const string FriendList = "/FriendList";
    private const string FriendListContent = "/FriendList/Content/";
    private const string AddBlackBtn = "/AddBlackBtn";
    private const string AddBlackBtnText = "/AddBlackBtn/Text";
    //item
    private const string Head = "/Head";
    private const string Job = "/Job";
    private const string Level = "/Level";
    private const string Name = "/Name";
    private const string BattleText = "/BattleText";
    private const string BattleNumText = "/BattleNumText";
    private const string ArmyGroupNameText = "/ArmyGroupNameText";
    private const string RelieveBtn = "/ChatBtn";
    private const string RelieveBtnText = "/ChatBtn/Text";
    private const string Select = "Select";
    #endregion

    private ExText blackNumText;
    private ExText blackText;
    private LoopVerticalScrollRect friendList;
    private ExUIButton addBlackBtn;
    private ExText addBlackBtnText;
    //item
    private ExUISprite head;
    private ExUISprite job;
    private ExText level;
    private ExText name;
    private ExText battleText;
    private ExText battleNumText;
    private ExText armyGroupNameText;
    private ExUIButton relieveBtn;
    private ExText relieveBtnText;

    private List<UInt64> blackFriendKeyList = new List<UInt64>();

    private const string CareerIconAtlas = "CareerIconAtlas";
    private const string HeroIconAtlas = "HeroIconAtlas";

    public override void Initial(UIFriendWindow window, string topPath)
    {
        base.Initial(window, topPath);

        blackNumText = GetComponent<ExText>(BlackNumText);

        blackText = GetComponent<ExText>(BlackText);

        friendList = GetComponent<LoopVerticalScrollRect>(FriendList);
        friendList.Init(OnFriendListRefresh, 0);

        addBlackBtn = GetComponent<ExUIButton>(AddBlackBtn);
        addBlackBtn.onClickEx = OnAddBlackBtnClick;

        addBlackBtnText = GetComponent<ExText>(AddBlackBtnText);
    }

    public override void Dispose()
    {
        base.Dispose();
        UIAtlasManager.Instance.UnLoad(CareerIconAtlas);
        UIAtlasManager.Instance.UnLoad(HeroIconAtlas);
    }
    private void OnAddBlackBtnClick(int val, object obj)
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_FriendAddBlack);
    }

    public void Show()
    {
        RefreshBlackFriendList();
        EventDispatcher.AddEventListener(Events.FriendEvent.BlackListRefresh, RefreshBlackFriendList);
    }

    public void Hide()
    {
        EventDispatcher.RemoveEventListener(Events.FriendEvent.BlackListRefresh, RefreshBlackFriendList);
    }

    private void RefreshBlackFriendList()
    {
        blackFriendKeyList.Clear();
        foreach (var item in PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array.Keys)
        {
            blackFriendKeyList.Add(item);
        }
        blackNumText.text = blackFriendKeyList.Count.ToString();
        friendList.ChangeTotalCount(blackFriendKeyList.Count);
        friendList.RefillCells();        
    }

    private void OnFriendListRefresh(string str, int index)
    {
        string sName = FriendListContent + str;
        Transform tran = GetComponent<Transform>(sName);
        if (index >= blackFriendKeyList.Count)
        {
            tran.SetActive<Transform>(false);
        }
        else
        {
            UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.Gender,
                        PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.Class), HeroIconAtlas);
                });
            UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.Gender,
                        PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.Class), CareerIconAtlas);
                });
            
            GetComponent<ExText>(sName + Level).text = PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.Level.Value.ToString();
            GetComponent<ExText>(sName + Name).text = PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.Identification.NameAlias.Value;
            GetComponent<ExText>(sName + BattleNumText).text = PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.FightPower.Value.ToString();

            if (PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.HasGuild == 0)
            {
                GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
            }
            else if (PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.HasGuild == 1)
            {
                GetComponent<ExText>(sName + ArmyGroupNameText).text = PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[index]].Property.GuildName.Value;
            }
            
            ExUIButton btn = GetComponent<ExUIButton>(sName + RelieveBtn);
            btn.Id = index;
            btn.onClickEx = OnRelieveBtnClick;
            UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
            uIPointerListener.OnTouchUpCallBack = OnItemClick;
        }
    }

    private void OnItemClick(int val, object obj)
    {
        for (int i = 0; i < blackFriendKeyList.Count; i++)
        {
            if (i == val)
            {
                friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(true);
                continue;
            }
            friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(false);
        }
    }

    private void OnRelieveBtnClick(int val,object obj)
    {
        if (blackFriendKeyList.Count <= 0)
        {
            return;
        }
        PlayerServerInvoker.DelBlackFriend(Player.Instance, 
            PlayerFriendList.Instance.Property.BlackFriendPropertyList.Array[blackFriendKeyList[val]].Property.Identification.ID.Value);
        friendList.GetTransformByIndex(val).SetActive(false);
    }

    private string GetIconStr(Byte _gender, Byte _class)
    {
        return ViSealedDB<VisualCorner>.Data(_gender * 6 + _class).iconName;
    }

    private string GetProfessionIconStr(Byte _gender, Byte _class)
    {
        return ViSealedDB<VisualCorner>.Data(_gender * 6 + _class).professionIcon + "1";
    }
}
