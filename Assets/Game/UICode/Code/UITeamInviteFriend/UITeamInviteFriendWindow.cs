using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITeamInviteFriendWindow : UIWindow<UITeamInviteFriendWindow, UITeamInviteFriendController>
{

    public class InviteStruct
    {
        public ulong ID;
        public string name;
        public byte heroPlayer;
        public byte heroGender;
        public int level;
        public int battle;
    }

    public enum Tag
    {
        None,
        Near,
        Friend,
        Army
    }
    #region ui control name define
    private const string BtnClose = "CloseBtn";

    private const string NearBtn = "NearbyBtn";
    private const string FriendBtn = "FriendBtn";
    private const string ArmyGroupBtn = "ArmyGroupBtn";
    private const string ShowObj = "/Show";

    private const string TeamList = "TeamList";
    private const string Content = "/Content";
    private const string Head = "/Head";
    private const string Job = "/Job";
    private const string Level = "/Level";
    private const string Name = "/Name";
    private const string InviteBtn = "/InviteBtn";
    private const string BattleNumText = "/BattleNumText";

    #endregion

    private Tag nowClick = Tag.None;

    private List<InviteStruct> inviteList = new List<InviteStruct>();
    private List<ulong> haveInviteList = new List<ulong>();
    //private int
    protected override void Initial()
    {
        base.Initial();
        this.GetComponent<Button>(BtnClose).onClick.AddListener(_OnCloseClick);
        this.GetComponent<Button>(NearBtn).onClick.AddListener(ShowNear);
        this.GetComponent<Button>(FriendBtn).onClick.AddListener(ShowFriend);
        this.GetComponent<Button>(ArmyGroupBtn).onClick.AddListener(ShowArmy);
        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(TeamList);
        loop.Init(RushItem, 0);
    }

    public override void Show()
    {
        base.Show();
        ShowNear();
    }
    public override void Hide()
    {
        base.Hide();
        nowClick = Tag.None;
    }
    /// <summary>
    /// 显示附近的人
    /// </summary>
    private void ShowNear()
    {
        if (nowClick != Tag.Near)
        {
            nowClick = Tag.Near;
            ShowOrHildNear(true);
            ShowOrHildFriend(false);
            ShowOrHildArmy(false);
        }

    }

    /// <summary>
    /// 显示好友的人
    /// </summary>
    private void ShowFriend()
    {
        if (nowClick != Tag.Friend)
        {
            nowClick = Tag.Friend;
            ShowOrHildNear(false);
            ShowOrHildFriend(true);
            ShowOrHildArmy(false);
        }
    }
    /// <summary>
    /// 显示军团的人
    /// </summary>
    private void ShowArmy()
    {
        if (nowClick != Tag.Army)
        {
            nowClick = Tag.Army;
            ShowOrHildNear(false);
            ShowOrHildFriend(false);
            ShowOrHildArmy(true);
        }
    }
    /// <summary>
    /// 控制显示附近
    /// </summary>
    /// <param name="isShow"></param>
    private void ShowOrHildNear(bool isShow)
    {
        this.GetComponent<Transform>(NearBtn + ShowObj).SetActive(isShow);
        if (isShow)
            RushList();
    }
    /// <summary>
    /// 控制显示好友
    /// </summary>
    /// <param name="isShow"></param>
    private void ShowOrHildFriend(bool isShow)
    {
        this.GetComponent<Transform>(FriendBtn + ShowObj).SetActive(isShow);
        if (isShow)
            RushList();
    }
    /// <summary>
    /// 控制显示军团
    /// </summary>
    /// <param name="isShow"></param>
    private void ShowOrHildArmy(bool isShow)
    {
        this.GetComponent<Transform>(ArmyGroupBtn + ShowObj).SetActive(isShow);
        if (isShow)
            RushList();
    }
    private void _OnCloseClick()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_TeamInviteFriend);
    }



    private void RushList()
    {
        ChangeUseList();
        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(TeamList);
        loop.ChangeTotalCount(inviteList.Count);
        loop.RefillCells();
    }

    /// <summary>
    /// 进行数据转化
    /// </summary>
    private void ChangeUseList()
    {
        inviteList.Clear();
        switch (nowClick)
        {
            case Tag.Near:

                List<CellHero> playerList = HeroController.Instance.GetNearPlayerByDistence(20);
                playerList.Sort((CellHero a, CellHero b) =>
                {
                    float disa = ViVector3.Distance2(CellHero.LocalHero.Position, a.Position);
                    float disb = ViVector3.Distance2(CellHero.LocalHero.Position, b.Position);
                    if (disa > disb)
                        return 1;
                    else
                        return -1;
                });

                for (int i = 0; i < playerList.Count; i++)
                {

                    if (playerList[i].Name != Player.Instance.Property.NameAlias)
                    {
                        InviteStruct str = new InviteStruct();
                        str.ID = playerList[i].Property.OwnerPlayerIdentity.ID.Value;
                        str.name = playerList[i].Name;
                        str.level = playerList[i].Property.Level;
                        str.heroPlayer = (byte)playerList[i].Property.Info.Value.HeroClass.Value;
                        str.heroGender = (byte)playerList[i].Property.Info.Value.Gender.Value;
                        str.battle = 0;
                        inviteList.Add(str);
                    }
                }
                break;

            case Tag.Friend:
                foreach (KeyValuePair<ulong, ViReceiveDataDictionaryNode<ulong, ReceiveDataFriendViewProperty>> party in PlayerFriendList.Instance.Property.FriendViewPropertyList.Array)
                {
                    ReceiveDataFriendViewProperty pro = party.Value.Property;
                    InviteStruct str = new InviteStruct();
                    str.ID = party.Key;
                    str.name = pro.Identification.NameAlias;
                    str.level = pro.Level;
                    str.heroPlayer = pro.Class;
                    str.heroGender = pro.Gender;
                    str.battle = pro.FightPower;
                    inviteList.Add(str);
                }
                break;

            case Tag.Army:
                break;
        }
    }
    /// <summary>
    /// 刷新格子的逻辑
    /// </summary>
    /// <param name="path"></param>
    /// <param name=""></param>
    private void RushItem(string path, int index)
    {
        path = _mWinTran.name + "/" + TeamList + Content + "/" + path;
        InviteStruct stru = inviteList[index];
        VisualCorner corner = ViSealedDB<VisualCorner>.Data(stru.heroGender * 6 + stru.heroPlayer);
        this.GetComponent<ExUISprite>(path + Head).SpriteName = corner.iconName;
        this.GetComponent<ExUISprite>(path + Job).SpriteName = ViSealedDB<VisualCorner>.Data(stru.heroGender * 6 + stru.heroPlayer).professionIcon + "1";
        this.GetComponent<ExText>(path + Name).text = stru.name;
        this.GetComponent<ExText>(path + Level).text = stru.level.ToString();
        this.GetComponent<ExText>(path + BattleNumText).text = stru.battle.ToString();
        ExUIButton button = this.GetComponent<ExUIButton>(path + InviteBtn);

        button.Id = index;
        button.onClickEx = OnClickInvite;
    }

    private void OnClickInvite(int id, object obj)
    {
        PartyInstance.InviteMemberToParty(inviteList[id].ID);
    }
}
