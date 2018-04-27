using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameFriendComponent : UIWindowComponent<UIFriendWindow, UIFriendContoller>
{
    #region ui define
    private const string FriendNumText = "/FriendNumText";
    private const string FriendText = "/FriendText";
    private const string FriendList = "/FriendList";
    private const string FriendListContent = "/FriendList/Content/";
    private const string AddFriendBtn = "/AddFriendBtn";
    private const string AddFriendBtnText = "/AddFriendBtn/Text";
    private const string DeleteFriendBtn = "/DeleteFriendBtn";
    private const string DeleteFriendBtnText = "/DeleteFriendBtn/Text";
    //item
    private const string Head = "/Head";
    private const string Job = "/Job";
    private const string Level = "/Level";
    private const string Name = "/Name";
    private const string BattleText = "/BattleText";
    private const string BattleNumText = "/BattleNumText";
    private const string ArmyGroupNameText = "/ArmyGroupNameText";
    private const string ChatBtn = "/ChatBtn";
    private const string ChatBtnText = "/ChatBtn/Text";
    private const string Select = "Select";
    #endregion

    private ExText friendNumText;
    private ExText friendText;
    private LoopVerticalScrollRect friendList;
    private ExUIButton addFriendBtn;
    private ExText addFriendBtnText;
    private ExUIButton deleteFriendBtn;
    private ExText deleteFriendBtnText;
    //item
    private ExUISprite head;
    private ExUISprite job;
    private ExText level;
    private ExText name;
    private ExText battleText;
    private ExText battleNumText;
    private ExText armyGroupNameText;
    private ExUIButton chatBtn;
    private ExText chatBtnText;

    private List<UInt64> friendViewKeyList = new List<UInt64>();

    private const string CareerIconAtlas = "CareerIconAtlas";
    private const string HeroIconAtlas = "HeroIconAtlas";

    private int _selectIndex = -1;

    public override void Initial(UIFriendWindow window, string topPath)
    {
        base.Initial(window, topPath);

        friendNumText = GetComponent<ExText>(FriendNumText);

        friendText = GetComponent<ExText>(FriendText);

        friendList = GetComponent<LoopVerticalScrollRect>(FriendList);
        friendList.Init(OnFriendListRefresh, 0);

        addFriendBtn = GetComponent<ExUIButton>(AddFriendBtn);
        addFriendBtn.onClickEx = OnAddFriendBtnClick;

        addFriendBtnText = GetComponent<ExText>(AddFriendBtnText);

        deleteFriendBtn = GetComponent<ExUIButton>(DeleteFriendBtn);        
        deleteFriendBtn.onClickEx = OnDeleteFriendBtnClick;

        deleteFriendBtnText = GetComponent<ExText>(DeleteFriendBtnText);
    }

    public override void Dispose()
    {
        base.Dispose();
        UIAtlasManager.Instance.UnLoad(CareerIconAtlas);
        UIAtlasManager.Instance.UnLoad(HeroIconAtlas);
    }

    public void Show()
    {
        RefreshGameFriendList();
        EventDispatcher.AddEventListener(Events.FriendEvent.GameFriendRefresh, RefreshGameFriendList);
    }

    public void Hide()
    {
        EventDispatcher.RemoveEventListener(Events.FriendEvent.GameFriendRefresh, RefreshGameFriendList);
    }

    private void RefreshGameFriendList()
    {
        _selectIndex = -1;
        friendViewKeyList.Clear();
        foreach (var item in PlayerFriendList.Instance.Property.FriendViewPropertyList.Array.Keys)
        {
            friendViewKeyList.Add(item);
        }
        friendNumText.text = friendViewKeyList.Count.ToString();
        friendList.ChangeTotalCount(friendViewKeyList.Count);
        friendList.RefillCells();
    }

    private void OnAddFriendBtnClick(int val, object obj)
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_FriendAdd);
    }

    private void OnDeleteFriendBtnClick(int val, object obj)
    {
        if (friendViewKeyList.Count <= 0 || _selectIndex == -1)
        {
            return;
        }

        UIManagerUtility.ShowConfirm(string.Format("是否确认删除好友\"{0}\"?", PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[val]].Property.Identification.NameAlias.Value),
            (int val1, object obj1) =>
            {
                PlayerServerInvoker.DelFriend(Player.Instance, PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[val]].Property.Identification.ID,
                () =>
                {
                    friendList.GetTransformByIndex(val).SetActive<Transform>(false);
                });
            },
            (int val2, object obj2) => { });
    }

    private void OnFriendListRefresh(string str,int index)
    {
        string sName = FriendListContent + str;
        Transform tran = GetComponent<Transform>(sName);
        if (index >= friendViewKeyList.Count)
        {
            tran.SetActive<Transform>(false);
        }
        else
        {
            UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
                 {
                     UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.Gender,
                        PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.Class), HeroIconAtlas);
                 });
            UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.Gender,
                        PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.Class), CareerIconAtlas);
                });

            GetComponent<ExText>(sName + Level).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.Level.Value.ToString();
            GetComponent<ExText>(sName + Name).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.Identification.NameAlias.Value;
            GetComponent<ExText>(sName + BattleNumText).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.FightPower.Value.ToString();

            if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.HasGuild == 0)
            {
                GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
            }
            else if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.HasGuild == 1)
            {
                GetComponent<ExText>(sName + ArmyGroupNameText).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[friendViewKeyList[index]].Property.GuildName.Value;
            }
            
            ExUIButton btn = GetComponent<ExUIButton>(sName + ChatBtn);
            btn.Id = index;
            btn.onClickEx = OnItemChatBtnClick;
            UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
            uIPointerListener.OnTouchUpCallBack = OnItemClick;
        }
    }

    private void OnItemChatBtnClick(int val,object obj)
    {
        Debug.Log("OnItemChatBtnClick");
    }

    private void OnItemClick(int val, object obj)
    {
        for (int i = 0; i < friendViewKeyList.Count; i++)
        {
            if (i == val)
            {
                friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(true);
                _selectIndex = val;
                continue;
            }
            friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(false);
        }
    }

    private  string GetIconStr(Byte _gender,Byte _class)
    {        
        return ViSealedDB<VisualCorner>.Data(_gender * 6 + _class).iconName;
    }

    private string GetProfessionIconStr(Byte _gender, Byte _class)
    {        
        return ViSealedDB<VisualCorner>.Data(_gender * 6 + _class).professionIcon + "1";
    }
}
