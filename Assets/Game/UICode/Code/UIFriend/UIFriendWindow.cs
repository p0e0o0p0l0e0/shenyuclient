using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFriendWindow : UIWindow<UIFriendWindow, UIFriendContoller>
{
    #region ui define
    private const string CloseBtn = "UIFriendWindow/CloseBtn";
    private const string TitleText = "UIFriendWindow/BG/Top_Title/Text";
    private const string GameFriendBtn = "UIFriendWindow/GameFiendBtn";
    private const string GameFriendBtnText = "UIFriendWindow/GameFiendBtn/Text";
    private const string GameFriendBtnShow = "UIFriendWindow/GameFiendBtn/Show";
    private const string GameFriendBtnShowText = "UIFriendWindow/GameFiendBtn/Show/Text";
    private const string BlackBtn = "UIFriendWindow/BlackBtn";
    private const string BlackBtnText = "UIFriendWindow/BlackBtn/Text";
    private const string BlackBtnShow = "UIFriendWindow/BlackBtn/Show";
    private const string BlackBtnShowText = "UIFriendWindow/BlackBtn/Show/Text";
    private const string FriendApplyBtn = "UIFriendWindow/FriendApplyBtn";
    private const string FriendApplyBtnText = "UIFriendWindow/FriendApplyBtn/Text";
    private const string FriendApplyBtnShow = "UIFriendWindow/FriendApplyBtn/Show";
    private const string FriendApplyBtnShowText = "UIFriendWindow/FriendApplyBtn/Show/Text";
    private const string FriendApplyPanel = "UIFriendWindow/FriendApply";
    private const string GameFriendPanel = "UIFriendWindow/GameFriend";
    private const string BlackPanel = "UIFriendWindow/Black";

    #endregion

    private Button closeBtn;
    private ExText titleText;
    private ExUIButton gameFriendBtn;
    private ExText gameFriendBtnText;
    private GameObject gameFriendBtnShow;
    private ExText gameFriendBtnShowText;
    private ExUIButton blackBtn;
    private ExText blackBtnText;
    private GameObject blackBtnShow;
    private ExText blackBtnShowText;
    private ExUIButton friendApplyBtn;
    private ExText friendApplyBtnText;
    private GameObject friendApplyBtnShow;
    private ExText friendApplyBtnShowText;

    private GameObject friendApplyPanel;
    private GameObject gameFriendPanel;
    private GameObject blackPanel;

    private UIGameFriendComponent gameFriendComponent;
    private UIFriendApplyComponent friendApplyComponent;
    private UIBlackListComponent blackListComponent;

    private int lastTypeIndex = -1;

    protected override void Initial()
    {
        base.Initial();
        closeBtn = GetComponent<Button>(CloseBtn);
        closeBtn.onClick.AddListener(() => UIManager.Instance.Hide(UIControllerDefine.WIN_Friend));

        titleText = GetComponent<ExText>(TitleText);

        gameFriendBtn = GetComponent<ExUIButton>(GameFriendBtn);
        gameFriendBtn.Id = 0;
        gameFriendBtn.onClickEx = OnTypeListBtnClick;

        gameFriendBtnText = GetComponent<ExText>(GameFriendBtnText);

        gameFriendBtnShow = FindTransform(GameFriendBtnShow).gameObject;

        gameFriendBtnShowText = GetComponent<ExText>(GameFriendBtnShowText);

        blackBtn = GetComponent<ExUIButton>(BlackBtn);
        blackBtn.Id = 1;
        blackBtn.onClickEx = OnTypeListBtnClick;

        blackBtnText = GetComponent<ExText>(BlackBtnText);

        blackBtnShow = FindTransform(BlackBtnShow).gameObject;

        blackBtnShowText = GetComponent<ExText>(BlackBtnShowText);

        friendApplyBtn = GetComponent<ExUIButton>(FriendApplyBtn);
        friendApplyBtn.Id = 2;
        friendApplyBtn.onClickEx = OnTypeListBtnClick;

        friendApplyBtnText = GetComponent<ExText>(FriendApplyBtnText);

        friendApplyBtnShow = FindTransform(FriendApplyBtnShow).gameObject;

        friendApplyBtnShowText = GetComponent<ExText>(FriendApplyBtnShowText);

        friendApplyPanel = FindTransform(FriendApplyPanel).gameObject;

        gameFriendPanel = FindTransform(GameFriendPanel).gameObject;

        blackPanel = FindTransform(BlackPanel).gameObject;

        gameFriendComponent = new UIGameFriendComponent();
        gameFriendComponent.Initial(this, GameFriendPanel);

        friendApplyComponent = new UIFriendApplyComponent();
        friendApplyComponent.Initial(this, FriendApplyPanel);

        blackListComponent = new UIBlackListComponent();
        blackListComponent.Initial(this, BlackPanel);

    }

    public override void Show()
    {
        base.Show();
        SwitchTypeByIndex(0);
    }

    private void OnTypeListBtnClick(int val, object obj)
    {
        if (lastTypeIndex == val)
        {
            return;
        }

        CloseTypeByIndex(lastTypeIndex);

        SwitchTypeByIndex(val);

        lastTypeIndex = val;

    }

    private void SwitchTypeByIndex(int typeIndex)
    {
        friendApplyPanel.SetActive(false);
        gameFriendPanel.SetActive(false);
        blackPanel.SetActive(false);

        gameFriendBtnShow.SetActive(false);
        blackBtnShow.SetActive(false);
        friendApplyBtnShow.SetActive(false);

        if (typeIndex == 0)
        {
            gameFriendPanel.SetActive(true);
            gameFriendBtnShow.SetActive(true);
            gameFriendComponent.Show();
        }
        else if (typeIndex == 1)
        {
            blackPanel.SetActive(true);
            blackBtnShow.SetActive(true);
            blackListComponent.Show();
        }
        else if (typeIndex == 2)
        {
            friendApplyPanel.SetActive(true);
            friendApplyBtnShow.SetActive(true);
            friendApplyComponent.Show();
        }
    }

    private void CloseTypeByIndex(int lastIndex)
    {
        if (lastIndex == 0)
        {
            gameFriendComponent.Hide();
        }
        else if (lastIndex == 1)
        {
            blackListComponent.Hide();
        }
        else if (lastIndex == 2)
        {
            friendApplyComponent.Hide();
        }
    }

}
