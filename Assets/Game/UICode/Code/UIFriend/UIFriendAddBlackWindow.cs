using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendAddBlackWindow : UIWindow<UIFriendAddBlackWindow, UIFriendAddBlackController>
{
    #region ui define
    private const string TopTitleText = "UIFriendAddBlackWindow/BG/Top_Title/Text";
    private const string CloseBtn = "UIFriendAddBlackWindow/BG/CloseBtn";
    private const string FriendList = "UIFriendAddBlackWindow/BG/FriendList";
    private const string FriendListContent = "UIFriendAddBlackWindow/BG/FriendList/Content/";
    private const string FindBtn = "UIFriendAddBlackWindow/BG/FindBtn";
    private const string FindBtnText = "UIFriendAddBlackWindow/BG/FindBtn/Text";
    private const string Input = "UIFriendAddBlackWindow/BG/Input";
    private const string Placeholder = "UIFriendAddBlackWindow/BG/Input/Placeholder";
    //item
    private const string Head = "/Head";
    private const string Job = "/Job";
    private const string Level = "/Level";
    private const string Name = "/Name";
    private const string BattleText = "/BattleText";
    private const string BattleNumText = "/BattleNumText";
    private const string ArmyGroupNameText = "/ArmyGroupNameText";
    private const string AddFriendBlackBtn = "/AddFriendBlackBtn";
    private const string AddFriendBlackBtnText = "/AddFriendBlackBtn/Text";
    private const string On_Line = "/On_Line";
    private const string Select = "Select";
    #endregion

    private ExText topTitleText;
    private Button closeBtn;
    private LoopVerticalScrollRect friendList;
    private ExUIButton findBtn;
    private ExText findBtnText;
    private ExUIButton changeBatchBtn;
    private ExText changeBatchBtnText;
    private InputField input;
    private ExText placeholder;

    private ExUISprite head;
    private ExUISprite job;
    private ExText level;
    private ExText name;
    private ExText battleText;
    private ExText battleNumText;
    private ExText armyGroupNameText;

    private List<UInt64> blackFriendPropertyList = new List<UInt64>();
    private List<UInt64> tempFriendPropertyList = new List<UInt64>();

    private const string CareerIconAtlas = "CareerIconAtlas";
    private const string HeroIconAtlas = "HeroIconAtlas";

    private bool isSearching = false;

    protected override void Initial()
    {
        base.Initial();
        topTitleText = GetComponent<ExText>(TopTitleText);
        topTitleText.text = I18NManager.Instance.GetWord("tips_213");

        closeBtn = GetComponent<Button>(CloseBtn);
        closeBtn.onClick.AddListener(OnCloseBtnClick);

        friendList = GetComponent<LoopVerticalScrollRect>(FriendList);
        friendList.Init(OnFriendListRefresh, 0);

        findBtn = GetComponent<ExUIButton>(FindBtn);
        findBtn.onClickEx = OnFindBtnClick;

        findBtnText = GetComponent<ExText>(FindBtnText);
        findBtnText.text = I18NManager.Instance.GetWord("tips_210");

        input = GetComponent<InputField>(Input);

        placeholder = GetComponent<ExText>(Placeholder);
        placeholder.text = I18NManager.Instance.GetWord("tips_212");
    }

    public override void Show()
    {
        base.Show();
        isSearching = false;
        RefreshBlackFriendPropertyList();
        EventDispatcher.AddEventListener(Events.FriendEvent.GameFriendRefresh, RefreshBlackFriendPropertyList);
    }

    public override void Hide()
    {
        base.Hide();
        EventDispatcher.RemoveEventListener(Events.FriendEvent.GameFriendRefresh, RefreshBlackFriendPropertyList);
    }

    public override void Destroy()
    {
        base.Destroy();
        UIAtlasManager.Instance.UnLoad(CareerIconAtlas);
        UIAtlasManager.Instance.UnLoad(HeroIconAtlas);
    }

    private void RefreshBlackFriendPropertyList()
    {
        blackFriendPropertyList.Clear();
        foreach (var item in PlayerFriendList.Instance.Property.FriendViewPropertyList.Array.Keys)
        {
            blackFriendPropertyList.Add(item);
        }        
        friendList.ChangeTotalCount(blackFriendPropertyList.Count);
        friendList.RefillCells();
    }

    private void RefreshTempFriendPropertyList()
    {
        tempFriendPropertyList.Clear();
        if (!string.IsNullOrEmpty(input.text))
        {
            foreach (var item in PlayerFriendList.Instance.Property.FriendViewPropertyList.Array.Keys)
            {
                if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[item].Property.Identification.NameAlias.Value.Contains(input.text) ||
                    PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[item].Property.Identification.NameAlias.Value.Equals(input.text))
                {
                    tempFriendPropertyList.Add(item);
                }
            }

            isSearching = true;
        }
    }

    private void OnCloseBtnClick()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_FriendAddBlack);
    }

    private void OnFindBtnClick(int val, object obj)
    {
        if (!string.IsNullOrEmpty(input.text))
        {
            RefreshTempFriendPropertyList();
            friendList.ChangeTotalCount(tempFriendPropertyList.Count);
            friendList.RefillCells();
        }
        else
        {
            isSearching = false;
            RefreshBlackFriendPropertyList();
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

    private void OnFriendListRefresh(string str, int index)
    {
        string sName = FriendListContent + str;
        Transform tran = GetComponent<Transform>(sName);
        if (isSearching)
        {
            if (index >= tempFriendPropertyList.Count)
            {
                tran.SetActive<Transform>(false);
            }
            else
            {
                UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
                    {
                        UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.Gender,
                            PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.Class), HeroIconAtlas);
                    });
                UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
                    {
                        UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.Gender,
                            PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.Class), CareerIconAtlas);
                    });
                
                GetComponent<ExText>(sName + Level).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.Level.Value.ToString();
                GetComponent<ExText>(sName + Name).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.Identification.NameAlias.Value;
                GetComponent<ExText>(sName + BattleNumText).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.FightPower.Value.ToString();

                if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.HasGuild == 0)
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
                }
                else if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.HasGuild == 1)
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.GuildName.Value;
                }

                if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[index]].Property.ClientState == 0)
                {
                    FindTransform(On_Line).gameObject.SetActive(true);
                }
                else
                {
                    FindTransform(On_Line).gameObject.SetActive(false);
                }
                
                ExUIButton btn = GetComponent<ExUIButton>(sName + AddFriendBlackBtn);
                btn.Id = index;
                btn.onClickEx = OnAddFriendBlackBtnClick;
                GetComponent<ExText>(sName + AddFriendBlackBtnText).text = I18NManager.Instance.GetWord("tips_213");
                UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
                uIPointerListener.OnTouchUpCallBack = OnItemClickSearching;
            }
        }
        else
        {
            if (index >= blackFriendPropertyList.Count)
            {
                tran.SetActive<Transform>(false);
            }
            else
            {
                UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
                    {
                        UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.Gender,
                            PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.Class), HeroIconAtlas);
                    });
                UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
                    {
                        UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.Gender,
                            PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.Class), CareerIconAtlas);
                    });

                GetComponent<ExText>(sName + Level).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.Level.Value.ToString();
                GetComponent<ExText>(sName + Name).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.Identification.NameAlias.Value;
                GetComponent<ExText>(sName + BattleNumText).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.FightPower.Value.ToString();

                if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.HasGuild == 0)
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
                }
                else if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.HasGuild == 1)
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.GuildName.Value;
                }

                if (PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[index]].Property.ClientState == 0)
                {
                    FindTransform(On_Line).gameObject.SetActive(true);
                }
                else
                {
                    FindTransform(On_Line).gameObject.SetActive(false);
                }
                
                ExUIButton btn = GetComponent<ExUIButton>(sName + AddFriendBlackBtn);
                btn.Id = index;
                btn.onClickEx = OnAddFriendBlackBtnClick;
                GetComponent<ExText>(sName + AddFriendBlackBtnText).text = I18NManager.Instance.GetWord("tips_213");
                UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
                uIPointerListener.OnTouchUpCallBack = OnItemClick;
            }
        }

    }

    private void OnItemClickSearching(int val, object obj)
    {
        for (int i = 0; i < tempFriendPropertyList.Count; i++)
        {
            if (i == val)
            {
                friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(true);
                continue;
            }
            friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(false);
        }
    }

    private void OnItemClick(int val, object obj)
    {
        for (int i = 0; i < blackFriendPropertyList.Count; i++)
        {
            if (i == val)
            {
                friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(true);
                continue;
            }
            friendList.GetTransformByIndex(i).Find(Select).gameObject.SetActive(false);
        }
    }

    private void OnAddFriendBlackBtnClick(int val, object obj)
    {
        if (isSearching)
        {
            PlayerServerInvoker.AddBlackFriend(Player.Instance,
                PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[tempFriendPropertyList[val]].Property.Identification.ID);
        }
        else
        {
            PlayerServerInvoker.AddBlackFriend(Player.Instance,
                PlayerFriendList.Instance.Property.FriendViewPropertyList.Array[blackFriendPropertyList[val]].Property.Identification.ID);
        }
        friendList.GetTransformByIndex(val).SetActive(false);
        isSearching = false;
    }
}
