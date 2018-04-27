using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIPartyComponent  : UIWindowComponent<UIGoalWindow, UIGoalController>
{
	#region ui control name define
	private const string AddMemberBtn = "AddMember";
	private const string InputField = "InputField";
	private const string AgreeButton = "Agree";
	private const string DisAgreeButton = "DisAgree";
	private const string DeleButton = "DelMember";
	private const string ExitBtn = "Button";

	private const string InfoHead = "Info/Head";
	private const string InfoName = "Info/Name";
	private const string InfoLevel = "Info/Level";
	private const string InfoLead = "Info/Lead";

	private const string SelectPlayer = "SelectPlayer";
	#endregion
	private Transform _memberList;

#if PARTY
    //临时UI
    private Button _addMember;
	private InputField inputField;
	private GameObject TestUI;
	private Button _agreeJoin;
	private Button _disAgree;
	private Button _removeMember;
#endif
    public override void Initial(UIGoalWindow window, string topPath)
	{
		base.Initial(window, topPath);
		_memberList = _rootTran;
		int index = 0;
		foreach (Transform t in _memberList)
		{
			ExUIButton ex = t.GetComponent<ExUIButton>();
			ex.Id = index++;
			//ex.onClickEx = _OnMemberBtnClick;
			t.SetActive<Transform>(false);
		}

        //_OnMemberChanged();
#if PARTY
        if(TestUI == null)
			UIGoManager.Instance.Load("UIPartyComponent", (string name, object obj1) => _OnUIPartyLoaded(name, obj1));
#endif
        EventDispatcher.AddEventListener(Events.PartyEvent.MemberChange, _OnMemberChanged);
		EventDispatcher.AddEventListener(Events.PartyEvent.LeaderChange, _OnLeaderChange);
		EventDispatcher.AddEventListener(Events.PartyEvent.ExitTeam, _OnExitParty);
		
	}
	public override void Dispose()
	{
		EventDispatcher.RemoveEventListener(Events.PartyEvent.MemberChange, _OnMemberChanged);
		EventDispatcher.RemoveEventListener(Events.PartyEvent.LeaderChange, _OnLeaderChange);
		EventDispatcher.RemoveEventListener(Events.PartyEvent.ExitTeam, _OnExitParty);
#if PARTY
        #region 测试代码
        UIGoManager.Instance.UnLoad("UIPartyComponent");
        #endregion
#endif
        base.Dispose();
	}
	public void SetActive(bool isShow)
	{
		_rootTran.gameObject.SetActive(isShow);
		if (isShow)
		{
			//_OnLeaderChange();
			_OnMemberChanged();
		}
		else
		{
			_mWindow.ShowInviteBtn(false);
            _mWindow.ShowPartyEntrance(true);
        }
#if PARTY
        if (TestUI)
			TestUI.SetActive(isShow);
#endif
    }
#if PARTY
    private void _OnUIPartyLoaded(string name, object obj1)
	{
		if (obj1 != null)
		{
			GameObject root = obj1 as GameObject;

			_addMember = root.transform.Find(AddMemberBtn).GetComponent<Button>();
			_addMember.onClick.AddListener(_InviteMember);

			_agreeJoin = root.transform.Find(AgreeButton).GetComponent<Button>();
			_agreeJoin.onClick.AddListener(_AgreeJoinParty);
			_disAgree = root.transform.Find(DisAgreeButton).GetComponent<Button>();
			_disAgree.onClick.AddListener(_DisAgreeJoinParty);
			_removeMember = root.transform.Find(DeleButton).GetComponent<Button>();
			_removeMember.onClick.AddListener(_DeleteMemberParty);
			Button exitBtn = root.transform.Find(ExitBtn).GetComponent<Button>();
			exitBtn.onClick.AddListener(_OnExitBtnClick);

			inputField = root.transform.Find(InputField).GetComponent<InputField>();

			RectTransform rt = root.GetComponent<RectTransform>();
			if (rt != null)
			{
				Vector3 pos = new Vector3(rt.anchoredPosition3D.x, rt.anchoredPosition3D.y, rt.anchoredPosition3D.z);
				Vector3 scale = new Vector3(rt.localScale.x, rt.localScale.y, rt.localScale.z);
				rt.SetParent(_rootTran.parent);
				rt.anchoredPosition3D = pos;
				rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y, 0);
				rt.localScale = scale;
				//go.name = RootName;
			}
			TestUI = root;
		}
	}

    private void _DeleteMemberParty()
	{
		if (PartyInstance.IsLeader && PartyInstance.MemberCount >= 2)
		{
			for (int i = 0; i < PartyInstance.MemberCount; i ++)
			{
				if(PartyInstance.GetMember(i).ID != Player.Instance.ID)
				{
					PartyInstance.RemoveMemberFromParty(PartyInstance.GetMember(i).ID);
					break;
				}
			}
		}
	}

    #region 测试代码
    private void _DisAgreeJoinParty()
	{
        if (PartyInstance.IsLeader)
            PartyInstance.DisagreeHeJoinParty(0);
        //else
            //Player.Instance.DisagreeJoinToParty();

    }
	private void _AgreeJoinParty()
	{
        if (PartyInstance.IsLeader)
            PartyInstance.AgreeHeJoinParty(0);
        //else
            //Player.Instance.AgreeJoinToParty();

    }
#endregion
    private void _InviteMember()
	{
		#region TestLog
		if(PartyInstance.Instance == null)
		{
			ViDebuger.Error("NOT in A Team!");
			return;
		}
		else
		{
			if (!PartyInstance.IsLeader)
			{
				ViDebuger.Error("Not A TeamLeader!");
			}
				
		}
		if (inputField.text != null)
		{
			try
			{
				UInt64 pId = Convert.ToUInt64(inputField.text);
                PartyInstance.InviteMemberToParty(pId);
				ViDebuger.Record("InvitePartyMember with ID");
				return;
			}
			catch (Exception ex)
			{
				string name = inputField.text;
				PlayerServerInvoker.InvitePartyMember(Player.Instance, name,0);
				ViDebuger.Record("InvitePartyMember with Name");
				return;
			}
		}
		#endregion
	}
#endif
    private void _OnLeaderChange()
	{
        _OnMemberChanged();

    }
	private void _OnMemberChanged()
	{
		if (PartyInstance.IsLeader && PartyInstance.MemberCount == 1)
		{
			_mWindow.ShowInviteBtn(true);
		}
		else
		{
			_mWindow.ShowInviteBtn(false);
		}
		if (!_rootTran.gameObject.activeSelf)
			return;
		int partyCount = 1;
		if (PartyInstance.IsInParty)
		{
			int index = 0;
			ViDebuger.Record("_OnMemberChanged");
			for (int i = 0; i < PartyInstance.MemberCount; i++)
			{
				PartyMemberStruct pms = PartyInstance.GetMember(i);
				if (pms.ID != Player.Instance.ID)
				{
					SetMember(pms, _memberList.GetChild(index), index);
					index++;
				}
			}
			partyCount = PartyInstance.MemberCount;
		}

		if (partyCount - 1 < _memberList.childCount) //自己不显示在队列里
			for (int i = partyCount - 1 >= 0 ? partyCount - 1: 0; i < _memberList.childCount;i++ )
			{
				_memberList.GetChild(i).SetActive<Transform>(false);
			}
	}
	private void SetMember(PartyMemberStruct rmp,Transform t,int i)
	{
        ExUISprite sprite = t.Find(InfoHead).GetComponent<ExUISprite>();

        sprite.SpriteName=ViSealedDB<VisualCorner>.Data(rmp.Gender*6+ (byte)rmp.HeroClass).iconName;
        sprite.SetGray(!rmp.IsOnline);
        //if (!rmp.IsOnline)
        //    sprite.color = Color.gray;
        //else
        //    sprite.color = Color.white;
        t.Find(InfoName).GetComponent<ExText>().text = rmp.NameAlias;
		t.Find(InfoLevel).GetComponent<ExText>().text = "" + (int)rmp.Level;
		t.Find(InfoLead).gameObject.SetActive(rmp.IsLeader);
		t.Find(SelectPlayer).gameObject.SetActive(false);
		t.GetComponent<ExUIButton>().Id = i;
		t.SetActive<Transform>(true);
	}
#if PARTY
    private void _OnRemoveMember(int id,  object obj)
	{
        PartyInstance.RemoveMemberFromParty(PartyInstance.GetMember(id).ID);
	}
	private void _OnExitBtnClick()
	{
        PartyInstance.ExitParty();
	}
#endif
    private void _OnExitParty()
	{
		SetActive(false);
#if PARTY
        TestUI.SetActive(false);
#endif
    }
	private void _SelectMember(Transform t , bool isSelect)
	{
		t.Find(SelectPlayer).gameObject.SetActive(isSelect);
	}
	private void _OnMemberBtnClick(int id, object obj)
	{
		foreach(Transform t in _memberList)
		{
			_SelectMember(t, false);
		}

		_SelectMember(((ExUIButton)obj).transform, true);
		
		UIManagerUtility.GetFightController().ShowTeamMember(PartyInstance.GetMember(id));
	}


}
