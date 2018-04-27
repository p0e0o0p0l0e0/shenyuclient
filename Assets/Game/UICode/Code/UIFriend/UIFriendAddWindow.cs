using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendAddWindow : UIWindow<UIFriendAddWindow, UIFriendAddController>
{
    #region ui define
    private const string TopTitleText = "UIFriendAddWindow/BG/Top_Title/Text";
    private const string CloseBtn = "UIFriendAddWindow/BG/CloseBtn";
    private const string FriendList = "UIFriendAddWindow/BG/FriendList";
    private const string FriendListContent = "UIFriendAddWindow/BG/FriendList/Content/";
    private const string FindBtn = "UIFriendAddWindow/BG/FindBtn";
    private const string FindBtnText = "UIFriendAddWindow/BG/FindBtn/Text";
    private const string ChangeBatchBtn = "UIFriendAddWindow/BG/ChangeBatchBtn";
    private const string ChangeBatchBtnText = "UIFriendAddWindow/BG/ChangeBatchBtn/Text";
    private const string Input = "UIFriendAddWindow/BG/Input";
    private const string Placeholder = "UIFriendAddWindow/BG/Input/Placeholder";
    //item
    private const string Head = "/Head";
    private const string Job = "/Job";
    private const string Level = "/Level";
    private const string Name = "/Name";
    private const string BattleText = "/BattleText";
    private const string BattleNumText = "/BattleNumText";
    private const string ArmyGroupNameText = "/ArmyGroupNameText";
    private const string AddFriendBtn = "/AddFriendBtn";
    private const string AddFriendBtnText = "/AddFriendBtn/Text";
    private const string On_Line = "/On_Line";
    private const string Select = "Select";
    #endregion

    private const string CareerIconAtlas = "CareerIconAtlas";
    private const string HeroIconAtlas = "HeroIconAtlas";

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
    private GameObject onLine;

    private int _listCount = 0;
    private bool isSearching = false;
    private List<PlayerShotProperty> searchResultList = new List<PlayerShotProperty>();

    protected override void Initial()
    {
        base.Initial();
        topTitleText = GetComponent<ExText>(TopTitleText);
        topTitleText.text = I18NManager.Instance.GetWord("tips_214");

        closeBtn = GetComponent<Button>(CloseBtn);
        closeBtn.onClick.AddListener(OnCloseBtnClick);

        friendList = GetComponent<LoopVerticalScrollRect>(FriendList);
        friendList.Init(OnFriendListRefresh, 0);

        findBtn = GetComponent<ExUIButton>(FindBtn);
        findBtn.onClickEx = OnFindBtnClick;

        findBtnText = GetComponent<ExText>(FindBtnText);
        findBtnText.text = I18NManager.Instance.GetWord("tips_210");

        changeBatchBtn = GetComponent<ExUIButton>(ChangeBatchBtn);
        changeBatchBtn.onClickEx = OnChangeBatchBtnClick;

        changeBatchBtnText = GetComponent<ExText>(ChangeBatchBtnText);
        changeBatchBtnText.text = I18NManager.Instance.GetWord("tips_211");

        input = GetComponent<InputField>(Input);

        placeholder = GetComponent<ExText>(Placeholder);
        placeholder.text = I18NManager.Instance.GetWord("tips_212");
    }

    public override void Show()
    {
        base.Show();
        isSearching = false;
        RefreshRecommandList();
        EventDispatcher.AddEventListener<List<PlayerShotProperty>>(Events.FriendEvent.FriendSearchResult, OnFriendSearchResult);
        EventDispatcher.AddEventListener(Events.FriendEvent.RecommandListRefresh, RefreshRecommandList);
    }

    public override void Hide()
    {
        base.Hide();
        EventDispatcher.RemoveEventListener<List<PlayerShotProperty>>(Events.FriendEvent.FriendSearchResult, OnFriendSearchResult);
        EventDispatcher.RemoveEventListener(Events.FriendEvent.RecommandListRefresh, RefreshRecommandList);
    }

    public override void Destroy()
    {
        base.Destroy();
        UIAtlasManager.Instance.UnLoad(CareerIconAtlas);
        UIAtlasManager.Instance.UnLoad(HeroIconAtlas);
    }

    private void OnFriendSearchResult(List<PlayerShotProperty> list)
    {
        searchResultList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            searchResultList.Add(list[i]);
        }
        friendList.ChangeTotalCount(searchResultList.Count);
        friendList.RefillCells();
    }

    private void RefreshRecommandList()
    {
        _listCount = PlayerFriendList.Instance.Property.RecommandList.Count;
        friendList.ChangeTotalCount(_listCount);
        friendList.RefillCells();
    }

    private void OnCloseBtnClick()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_FriendAdd);
    }

    private void OnFriendListRefresh(string str, int index)
    {
        string sName = FriendListContent + str;
        Transform tran = GetComponent<Transform>(sName);
        if (isSearching)
        {
            if (index >= searchResultList.Count)
            {
                tran.SetActive<Transform>(false);
            }
            else
            {
                UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(searchResultList[index].Gender,searchResultList[index].Class), HeroIconAtlas);
                });
                UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(searchResultList[index].Gender, searchResultList[index].Class), CareerIconAtlas);
                });

                GetComponent<ExText>(sName + Level).text = searchResultList[index].Level.ToString();
                GetComponent<ExText>(sName + Name).text = searchResultList[index].Identify.NameAlias;
                GetComponent<ExText>(sName + BattleNumText).text = searchResultList[index].FightPower.ToString();

                if (string.IsNullOrEmpty(searchResultList[index].Guild))
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
                }
                else
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = searchResultList[index].Guild;
                }
                
                ExUIButton addFriendBtn = GetComponent<ExUIButton>(AddFriendBtn);
                addFriendBtn.Id = index;
                addFriendBtn.onClickEx = OnAddFriendBtnClick;
                // todo onLine ?
                UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
                uIPointerListener.OnTouchUpCallBack = OnItemClickSearching;
            }
        }
        else
        {
            if (index >= _listCount)
            {
                tran.SetActive<Transform>(false);
            }
            else
            {
                UIAtlasManager.Instance.Load(HeroIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Head), GetIconStr(PlayerFriendList.Instance.Property.RecommandList[index].Property.Gender,
                        PlayerFriendList.Instance.Property.RecommandList[index].Property.Class), HeroIconAtlas);
                });
                UIAtlasManager.Instance.Load(CareerIconAtlas, (string name, object go) =>
                {
                    UIUtility.SetSprite(GetComponent<ExUISprite>(sName + Job), GetProfessionIconStr(PlayerFriendList.Instance.Property.RecommandList[index].Property.Gender,
                        PlayerFriendList.Instance.Property.RecommandList[index].Property.Class), CareerIconAtlas);
                });

                GetComponent<ExText>(sName + Level).text = PlayerFriendList.Instance.Property.RecommandList[index].Property.Level.Value.ToString();
                GetComponent<ExText>(sName + Name).text = PlayerFriendList.Instance.Property.RecommandList[index].Property.Identification.NameAlias.Value;
                GetComponent<ExText>(sName + BattleNumText).text = PlayerFriendList.Instance.Property.RecommandList[index].Property.FightPower.Value.ToString();

                if (PlayerFriendList.Instance.Property.RecommandList[index].Property.HasGuild == 0)
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = "军团名称";
                }
                else if (PlayerFriendList.Instance.Property.RecommandList[index].Property.HasGuild == 1)
                {
                    GetComponent<ExText>(sName + ArmyGroupNameText).text = PlayerFriendList.Instance.Property.RecommandList[index].Property.GuildName.Value;
                }
                
                ExUIButton addFriendBtn = GetComponent<ExUIButton>(AddFriendBtn);
                addFriendBtn.Id = index;
                addFriendBtn.onClickEx = OnAddFriendBtnClick;

                if (PlayerFriendList.Instance.Property.RecommandList[index].Property.ClientState == 0)
                {
                    FindTransform(On_Line).gameObject.gameObject.SetActive(true);
                }
                else
                {
                    FindTransform(On_Line).gameObject.gameObject.SetActive(false);
                }
                                
                UIPointerListener uIPointerListener = GetComponent<UIPointerListener>(sName);
                uIPointerListener.OnTouchUpCallBack = OnItemClick;
            }
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

    private void OnItemClickSearching(int val, object obj)
    {
        for (int i = 0; i < searchResultList.Count; i++)
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

    private void OnFindBtnClick(int val, object obj)
    {
        //PlayerCommandInvoker.AddFriend(Player.Instance, System.Convert.ToUInt64(input.text));
        if (!string.IsNullOrEmpty(input.text))
        {
            isSearching = true;
            PlayerServerInvoker.FriendSearchNameAlias(Player.Instance, input.text);
        }
        else
        {
            isSearching = false;            
        }
    }

    private void OnChangeBatchBtnClick(int val, object obj)
    {
        PlayerServerInvoker.FriendUpdateRecommand(Player.Instance);
    }

    private void OnAddFriendBtnClick(int val, object obj)
    {
        if (isSearching)
        {
            PlayerServerInvoker.FriendInvite(Player.Instance, searchResultList[val].Identify.ID,
                () =>
                {
                    friendList.GetTransformByIndex(val).SetActive<Transform>(false);
                });
        }
        else
        {
            PlayerServerInvoker.FriendInvite(Player.Instance, PlayerFriendList.Instance.Property.RecommandList[val].Property.Identification.ID,
                () =>
                {
                    friendList.GetTransformByIndex(val).SetActive<Transform>(false);
                });
        }

    }
}
