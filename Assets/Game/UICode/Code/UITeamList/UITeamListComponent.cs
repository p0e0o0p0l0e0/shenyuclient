using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UITeamListComponent : UIWindowComponent<UITeamListWindow, UITeamListController>
{
    #region ui control name define
    private const string BtnRefresh = "/RefreshBtn";
    private const string BtnCreateTeam = "/CreateTeamBtn";
    private const string TeamList = "/TeamList";
    private const string TeamListContent = "/TeamList/Content/";
    private const string NoTeam = "/NoTeamText";
    private const string TeamLimit = "/TopTab/SelectLimit";
    private const string TeamLimitArrow = "/TopTab/SelectLimit/Arrow";
    private const string TeamNum = "/TopTab/SelectNum";
    private const string TeamNumArrow = "/TopTab/SelectNum/Arrow";
    private const string FastMatching = "/FastMatchingBtn";
    private const string FastMatchingText = "/FastMatchingBtn/Text";
    private const string FilterAll = "/Right/TotalToggle";
    private const string LoopFilter = "/Right/GameplayTypeList";
    private const string LoopFilterContent = "/Right/GameplayTypeList/Content";

    //an item of teamList 
    private const string ItemName = "/Name";
    //private const string TaskGridHead = "/GridHead";
    private const string ItemHead = "/Head";
    private const string AppleyBtn = "/AppleyBtn";
    private const string LimitText = "/LimitText";
    private const string LeaderJobSprite = "/JobSprite";
    private const string JobSpriteBG = "/GridJob/JobSpriteBg";
    private const string JobSprite = "/JobSprite";
    private const string LevelText = "/Level";
    private const string ItemBg = "/BgLight";
    private const string CopyName = "/CopyName";

    private const string FilterLabel = "Toggle/Label";
    private const string ListToggle = "/Toggle";
    private const string FirstFilterItem = "/Right/GameplayTypeList/Content/0";
    private const string SecondFilterItem = "/Right/GameplayTypeList/Content/Second";
    private const string ArrowSprite = "Arrow";
    private const string LockSpite = "Sock";
    //private const string TaskList = "UITeamListWindow/TaskList";
    //private const string TaskContent = "UITeamListWindow/TaskList/Content/";

    //private const string ShadowText = "UITeamListWindow/TotalList/Content/Task0/AppleyBtn/Text";
    #endregion
    private ExUIButton _createTeamBtn;
    private List<PartyDetail> _partyList;
    private List<PartyDetail> _partyBakList;//备份的
    private GameObject _noTeam;
    private LoopVerticalScrollRect _teamList;
    private Toggle _limitToggle;
    private Toggle _numToggle;
    private ExUISprite _limitArrow;
    private ExUISprite _numArrow;
    private ExUIButton _fastMatchBtn;
    private ExText _fastMatchText;
    private ExUIButton _refreshBtn;
    private Toggle _toggleTotal;
    private Toggle[] _toggleFilter;
    //private LoopVerticalScrollRect _totalList;
    private ScrollRect _filterList;
    private GameObject _firstItem, _secondItem;
    private Transform _filterContent;
    private int _filterCount = 0;
    static Color ShadowColor1;
    static Color ShadowColor2 = new Color(0x3e / 255f, 0x3e / 255f, 0x3e / 255f, 1);
    public override void Initial(UITeamListWindow window, string topPath)
    {
        base.Initial(window, topPath);
        _createTeamBtn = GetComponent<ExUIButton>(BtnCreateTeam);
        _createTeamBtn.AddButtonListener(window.OnBtnCreateTeamClick);
        _teamList = GetComponent<LoopVerticalScrollRect>(TeamList);
        _teamList.Init(_OnTotalLoopRefresh, 0);
        _noTeam = GetComponent<Transform>(NoTeam).gameObject;

        _limitToggle = GetComponent<Toggle>(TeamLimit);
        _limitToggle.onValueChanged.AddListener(_OnTeamLimitToggleChanged);
        _numToggle = GetComponent<Toggle>(TeamNum);
        _numToggle.onValueChanged.AddListener(_OnTeamNumToggleChanged);
        _limitArrow = GetComponent<ExUISprite>(TeamLimitArrow);
        _numArrow = GetComponent<ExUISprite>(TeamNumArrow);

        _fastMatchBtn = GetComponent<ExUIButton>(FastMatching);
        _fastMatchBtn.AddButtonListener(_OnFastMatchingBtnClick);
        _fastMatchText = GetComponent<ExText>(FastMatchingText);
        _FastMatchingText();
        _filterList = GetComponent<ScrollRect>(LoopFilter);
        _filterContent = GetComponent<Transform>(LoopFilterContent);
        //_filterList.Init(_LoopRefresh, _filtersInfo.Count - 1);  //
        //_filterList.RefillCells();
        _OnFilterConstruct();
        //_filterList.vertical = _filterCount.Count > 7;

        _toggleTotal = GetComponent<Toggle>(FilterAll);
        _toggleTotal.isOn = _filtersInfo[0].value;
        _toggleTotal.onValueChanged.AddListener(_OnToggleTotalValueChanged);
        //for (int i = 1; i < _filtersInfo.Count; i++)
        //{
        //    _filtersInfo[_filtersInfo.Keys[i]].callback = _OnFilterValueChange;
        //}

        //for (int i = 0; i < _filtersInfo.Count; i ++)
        //{
        //    _filters[(ushort)_filtersInfo[i].partyType] = _filtersInfo[i];
        //}
        _refreshBtn = GetComponent<ExUIButton>(BtnRefresh);
        _refreshBtn.onClick.AddListener(_OnRefreshBtnClick);
        EventDispatcher.AddEventListener(Events.PartyEvent.BeDisagree, OnDisagree);
        EventDispatcher.AddEventListener(Events.PartyEvent.FastMatching, _FastMatchingText);
        //ShadowColor1 = this.GetComponent<Shadow>(ShadowText).effectColor;
    }
    public void SetActive(bool isTrue)
    {
        _rootTran.gameObject.SetActive(isTrue);
        if (isTrue)
        {
            OnExitTeam();
        }
    }
    public void OnPartyListUpdate(List<PartyDetail> partyList)
    {
        _partyBakList = partyList;
        _partyList = _FilterPartyList();
        _RefreshTeamList();
    }
    private void _RefreshTeamList()
    {

        if (_partyList != null && _partyList.Count > 0)
        {
            _PartyListSort();

            //Debug.LogError("partyList[0]:" + partyList[0].member.Count);
            _teamList.ChangeTotalCount(_partyList.Count);
            //_teamList.RefillCells();
            _teamList.gameObject.SetActive(true);
            _noTeam.SetActive(false);
        }
        else
        {
            _teamList.gameObject.SetActive(false);
            _noTeam.SetActive(true);
        }
    }

    /// <summary>
    /// 删选队伍列表
    /// </summary>
    /// <returns></returns>
    private List<PartyDetail> _FilterPartyList()
    {
        if (_partyBakList == null || _partyBakList.Count == 0)
        {
            return _partyBakList;
        }
        List<PartyDetail> result = _partyBakList.FindAll(delegate (PartyDetail m)
        {
            if (_filters.ContainsKey((UInt32)m.Type))
            {
                if (String.IsNullOrEmpty(m.Leader.Name))//去掉名字为“”的人
                    return false;

                if (PartyInstance.IsMyParty(m.ID)) //判断是否为自己的队伍
                    return false;

                if (m.member.Count == 0) //可能出现有队长信息，但是没有队员的操作
                    return false;
                if (_filters[(UInt32)m.Type].value == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        });
        ViDebuger.Record("TeamList Filter: " + _partyBakList.Count + " partys -> " + (result == null ? 0 : result.Count) + " partys");
        if (result == null)
            return new List<PartyDetail>();
        else
            return result;
    }
    private void _ApplyButtonClick(int val, object obj)
    {
        if (_partyList == null || val >= _partyList.Count)
        {
            ViDebuger.Record("Apply invalid Party");
        }
        else
        {
            if (!PartyInstance.IsInParty)
            {
                int level = 0;
                if (_filters.ContainsKey((UInt32)_partyList[val].Type))
                {
                    level = _filters[(UInt32)_partyList[val].Type].LevelLimit;
                }
                if (Player.Instance.Level < level)
                {
                    ViDebuger.Record("您不符合队伍的等级要求");
                    return;
                }
                PlayerServerInvoker.RequestJoinParty(Player.Instance, _partyList[val].ID, () =>
                {
                    ExUIButton eButton = (ExUIButton)obj;
                    eButton.SetCanClick(false);
                    eButton.GetComponentInChildren<ExText>().text = I18NManager.Instance.GetWord("tips_101"); //已申请
                    eButton.GetComponentInChildren<Shadow>().effectColor = ShadowColor2;
                    //Player.Instance.AddToPartyRequestList(_partyList[val].ID);
                });
            }
            else
                ViDebuger.Record("您已经身处一个队伍中");
        }
    }
    /// <summary>
    /// 临时先这么写，将来可能会放到表格中
    /// </summary>
    /// <returns></returns>
    private string _GetClassNameIconWithHeroClass(HeroClass heroClass)
    {
        string sname = null;

        switch (heroClass)
        {
            case HeroClass.Cleric:
                sname = "pic_shengtu";
                break;
            case HeroClass.Fighter:
                sname = "pic_jianshi";
                break;
            case HeroClass.Ranger:
                sname = "pic_youxia";
                break;
            case HeroClass.Rogue:
                sname = "pic_fashi";
                break;
            case HeroClass.Wizard:
                sname = "pic_fashi";
                break;
            case HeroClass.Knight:
                sname = "pic_qishi";
                break;
            default:
                sname = "pic_fashi";
                ViDebuger.Record("_GetClassNameIconWithHeroClass Unkown Hero Class " + heroClass);
                break;
        }
        return sname;
    }

    private void SetPlayerClassNameAndColor(Byte clase, Byte gender, ExText exText)
    {
        VisualCorner visualCorner = ViSealedDB<VisualCorner>.Data(gender * 6 + clase);

        exText.text = visualCorner.professionName;
        exText.color = new Color(visualCorner.professionNameColorsR / 256f, visualCorner.professionNameColorsG / 256f, visualCorner.professionNameColorsB / 256f);
    }

    private string _GetClassSpriteIconWithHeroClass(HeroClass heroClass)
    {
        return _GetClassNameIconWithHeroClass(heroClass) + "_small";
    }

    private void _SetMemberHead(int id, string path)
    {
        PartyDetail p = _partyList[id];
        for (int i = 0; i < p.MaxPlayer; i++)
        {
            ExUISprite sprite = GetComponent<ExUISprite>(path + JobSpriteBG + i + JobSprite);
            if (i < p.member.Count)
            {
                sprite.SpriteName = _GetClassSpriteIconWithHeroClass((HeroClass)p.member[i].Class);
                sprite.gameObject.SetActive(true);
                //p.member[0].Class
            }
            else
            {
                sprite.gameObject.SetActive(false);
            }
        }

    }
    private void _OnTotalLoopRefresh(string path, int id)
    {
        string sname = TeamListContent + path;
        Transform tr = this.GetComponent<Transform>(sname);
        if (_partyList == null || id >= _partyList.Count)
        {
            tr.SetActive<Transform>(false);
        }
        else
        {
            this.GetComponent<ExText>(sname + ItemName).text = _partyList[id].Leader.NameAlias;
            this.GetComponent<ExCircleSprite>(sname + ItemHead).SpriteName = ViSealedDB<VisualCorner>.Data(PartyInstance.FindPartyLeaderGenderInParty(_partyList[id], _partyList[id].Leader) * 6 + (int)PartyInstance.FindPartyLeaderHeroClassInParty(_partyList[id], _partyList[id].Leader)).iconName;
            ExUIButton exbutton = this.GetComponent<ExUIButton>(sname + AppleyBtn);
            exbutton.Id = id;
            exbutton.onClickEx = _ApplyButtonClick;
            this.GetComponent<ExText>(sname + LevelText).text = "" + PartyInstance.FindPartyLeaderLevel(_partyList[id], _partyList[id].Leader);
            if (Player.Instance.IsPartyAlreadyRequested(_partyList[id].ID))
            {
                exbutton.GetComponentInChildren<Text>().text = I18NManager.Instance.GetWord("tips_101"); //已申请
                exbutton.SetCanClick(false);
            }
            else
            {
                exbutton.GetComponentInChildren<Text>().text = I18NManager.Instance.GetWord("tips_100"); //申请
                exbutton.SetCanClick(true);
            }
            TaskStruct ts = ViSealedDB<TaskStruct>.Data((int)_partyList[id].Type);
            int levelLimit = ts.LowLevel;
            if (levelLimit == 0)
                this.GetComponent<ExText>(sname + LimitText).text = "无限制";
            else
                this.GetComponent<ExText>(sname + LimitText).text = "" + levelLimit;
            if (PartyInstance.IsMyParty(_partyList[id].ID))
                exbutton.gameObject.SetActive(false);
            else
                exbutton.gameObject.SetActive(true);
            GetComponent<ExText>(sname + CopyName).text = ts.TypeName; //临时这么用
            GetComponent<Transform>(sname + ItemBg).SetActive<Transform>(id % 2 == 0);

            SetPlayerClassNameAndColor((Byte)PartyInstance.FindPartyLeaderHeroClassInParty(_partyList[id], _partyList[id].Leader)
                , PartyInstance.FindPartyLeaderGenderInParty(_partyList[id], _partyList[id].Leader), GetComponent<ExText>(sname + LeaderJobSprite));

            //exbutton.GetComponentInChildren<Shadow>().effectColor = ShadowColor1;
            _SetMemberHead(id, sname);
            tr.SetActive<Transform>(true);
        }
    }
    /// <summary>
    /// 队伍限制排序
    /// </summary>
    /// <param name="isOn"></param>
    private void _OnTeamLimitToggleChanged(bool isOn)
    {
        if (isOn)
        {
            _limitArrow.transform.localEulerAngles = new Vector3(_limitArrow.transform.localEulerAngles.x, _limitArrow.transform.localEulerAngles.y, 180);
            _PartyListSort();
        }
        else
        {
            _limitArrow.transform.localEulerAngles = new Vector3(_limitArrow.transform.localEulerAngles.x, _limitArrow.transform.localEulerAngles.y, 0);
            _PartyListSort();
        }
    }
    /// <summary>
    /// 队伍人数排序
    /// </summary>
    /// <param name="isOn"></param>
    private void _OnTeamNumToggleChanged(bool isOn)
    {
        if (isOn)
        {
            _numArrow.transform.localEulerAngles = new Vector3(_numArrow.transform.localEulerAngles.x, _numArrow.transform.localEulerAngles.y, 180);
            _PartyListSort();
        }
        else
        {
            _numArrow.transform.localEulerAngles = new Vector3(_numArrow.transform.localEulerAngles.x, _numArrow.transform.localEulerAngles.y, 0);
            _PartyListSort();
        }

    }
    /// <summary>
    /// 快速匹配
    /// </summary>
    private void _OnFastMatchingBtnClick()
    {
        if (!PartyInstance.IsInParty)
        {
            if (!PartyInstance.IsFastMatching)
            {
                List<ulong> idList = new List<ulong>();
                for (int i = 1; i < _filtersInfo.Count; i++)
                {
                    if (_filtersInfo[i].value && _filtersInfo[i].childs != null && _filtersInfo[i].childs.Count > 0)//点开并且存在子id
                    {
                        for (int j = 0; j < _filtersInfo[i].childs.Count; j++)
                        {
                            if (_filtersInfo[i].childs[j].value)
                                idList.Add(_filtersInfo[i].childs[j].TargetID);
                        }
                    }

                }

                PartyInstance.FastMatching();
            }

        }
        else
        {
            UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_223"));
        }
    }
    private void _FastMatchingText()
    {
        if (PartyInstance.IsFastMatching)
            _fastMatchText.text = I18NManager.Instance.GetWord("tips_167"); //取消匹配 
        else
            _fastMatchText.text = I18NManager.Instance.GetWord("tips_155"); //快速匹配 
    }
    private void _PartyListSort()
    {
        if (_partyList.Count >= 2)
        {
            if (_numToggle.isOn)
            {
                if (!_limitToggle.isOn)
                {
                    _partyList.Sort(delegate (PartyDetail p1, PartyDetail p2)
                    {
                        return p1.member.Count.CompareTo(p2.member.Count);
                    });
                }
                else
                {
                    _partyList.Sort(delegate (PartyDetail p1, PartyDetail p2)
                    {
                        return _filters[(UInt32)p1.Type].LevelLimit.CompareTo(_filters[(UInt32)p2.Type].LevelLimit) * 10 + p1.member.Count.CompareTo(p2.member.Count);
                    });
                }
            }
            else
            {
                if (!_limitToggle.isOn)
                {
                    _partyList.Sort(delegate (PartyDetail p1, PartyDetail p2)
                    {

                        return -_filters[(UInt32)p1.Type].LevelLimit.CompareTo(_filters[(UInt32)p2.Type].LevelLimit) - p1.member.Count.CompareTo(p2.member.Count) * 1000;
                    });
                }
                else
                {
                    _partyList.Sort(delegate (PartyDetail p1, PartyDetail p2)
                    {
                        return _filters[(UInt32)p1.Type].LevelLimit.CompareTo(_filters[(UInt32)p2.Type].LevelLimit) * 10 - p1.member.Count.CompareTo(p2.member.Count);
                    });
                }
            }

            _teamList.RefillCells();
        }

    }
    //All filters
    private List<FilterStruct> _filtersInfo = new List<FilterStruct>();

    private Dictionary<UInt32, FilterStruct> _filters;


    private void _OnToggleTotalValueChanged(bool isTrue)
    {
        _filtersInfo[0].value = isTrue;
        if (isTrue)
        {
            foreach (FilterStruct fs in _filtersInfo)
            {
                if (Player.Instance.Level < fs.LevelLimit)
                    continue;
                fs.ChangeToggleValue(true);
                if (fs.Count > 0)
                {
                    foreach (FilterStruct child in fs.childs)
                        if (Player.Instance.Level >= child.LevelLimit)
                            child.ChangeToggleValue(true);
                }
            }
            //_filterList.RefillCells();
        }
        _partyList = _FilterPartyList();
        _RefreshTeamList();
    }
    private void _OnFilterValueChange()
    {
        if (_toggleTotal.isOn)
        {
            _filtersInfo[0].value = false;
            _toggleTotal.onValueChanged.RemoveAllListeners();
            _toggleTotal.isOn = false;
            _toggleTotal.onValueChanged.AddListener(_OnToggleTotalValueChanged);
        }
        _partyList = _FilterPartyList();
        _RefreshTeamList();
    }
    bool isRefreshing;
    private void _OnRefreshBtnClick()
    {
        if (!isRefreshing)
        {
            isRefreshing = true;
            _mWindow.RefreshPartyList(() => { isRefreshing = false; });
        }
    }
    public void OnDisagree()
    {
        _RefreshTeamList();
    }
    public void OnExitTeam()
    {
        if (PartyInstance.IsInParty)
            _createTeamBtn.GetComponentInChildren<ExText>().text = I18NManager.Instance.GetWord("tips_112"); //退出队伍
        else
            _createTeamBtn.GetComponentInChildren<ExText>().text = I18NManager.Instance.GetWord("tips_103"); //创建队伍
    }


    //右侧筛选条件的获取
    private void _OnFilterConstruct()
    {
        _firstItem = GetComponent<Transform>(FirstFilterItem).gameObject;
        _secondItem = GetComponent<Transform>(SecondFilterItem).gameObject;
        Dictionary<string, FilterStruct> filterDict = new Dictionary<string, FilterStruct>();

        _filtersInfo.Clear();
        _filters = new Dictionary<UInt32, FilterStruct>();
        FilterStruct listTemp;

        //所有节点数据组织完成
        foreach (TaskStruct t in ViSealedDB<TaskStruct>.Array) //从表格获取类型
        {
            if (filterDict.ContainsKey(t.TypeName))
                listTemp = filterDict[t.TypeName];
            else
            {
                bool v = Player.Instance.Level >= t.LowLevel;
                if (v)
                {
                    v = FilterList.GetValue((UInt32)t.ID, 0);
                }
                FilterStruct fs = new FilterStruct((UInt32)t.ID, t.TypeName, t.LowLevel, v);
                listTemp = fs;
                filterDict[t.TypeName] = listTemp;
            }
            listTemp.AddChild((UInt32)t.ID);//添加子节点
        }


        Transform content = _filterContent;
        foreach (Transform t in content)
        {
            t.gameObject.SetActive(false);
        }
        FilterStruct filterOutdoor = null;

        _filtersInfo.Add(new FilterStruct((UInt32)PartyType.ALL, "全部", 0, FilterList.GetValue((UInt32)PartyType.ALL, 0)));
        _filtersInfo.Add(new FilterStruct((UInt32)PartyType.NEARBY, "附近的队伍", 0, FilterList.GetValue((UInt32)PartyType.NEARBY, 0)));
        foreach (string key in filterDict.Keys)
        {
            _AddFilter(filterDict[key]);
            if (key == "野外")
            {
                filterOutdoor = filterDict[key];
                continue;
            }
            _filtersInfo.Add(filterDict[key]);
        }
        _filtersInfo.Add(filterOutdoor);  //OutDoor is the last One

        for (int key = 1, index = 0; key < _filtersInfo.Count; key++)
        {
            Transform t = content.Find("" + index);
            if (t == null)
            {
                t = GameObject.Instantiate<GameObject>(_firstItem).transform;
                t.name = "" + index;
                t.SetParentAndReset(content);
            }
            _filtersInfo[key].RootNode = t;
            _filtersInfo[key].callback = _OnFilterValueChange;
            Toggle toggle = t.GetComponentInChildren<Toggle>();
            _filtersInfo[key].SetToggle(toggle);
            ExUIButton labelButton = t.Find(FilterLabel).GetComponent<ExUIButton>();
            if (Player.Instance.Level >= _filtersInfo[key].LevelLimit)
            {
                t.Find(LockSpite).gameObject.SetActive(Player.Instance.Level < _filtersInfo[key].LevelLimit);
                toggle.interactable = true;
                if (_filtersInfo[key].Count > 0)
                {
                    labelButton.Id = key;
                    labelButton.onClickEx = _OnLabelButtonClick;
                }
            }
            else
            {
                t.GetComponentInChildren<Toggle>().interactable = false;
            }
            Transform arrow = t.Find(ArrowSprite);
            arrow.gameObject.SetActive(_filtersInfo[key].Count > 0);

            if (_filtersInfo[key].Count > 0)
            {
                _filtersInfo[key].Arrow = arrow;
            }

            labelButton.GetComponent<ExText>().text = _filtersInfo[key].labelText;
            t.gameObject.SetActive(true);
            index++;
        }
        _filterCount = _filtersInfo.Count - 1;
        //_filterList.vertical = _filterCount > 7;
    }
    private void _AddFilter(FilterStruct fs)
    {
        if (fs.Count > 0)
        {
            foreach (FilterStruct child in fs.childs)
            {
                _filters[child.TargetID] = child;
            }
        }
        else
            _filters[fs.TargetID] = fs;
    }
    private void _OnLabelButtonClick(int val, object obj)
    {
        //插入二级选项
        if (val >= 0 && val < _filtersInfo.Count && _filtersInfo[val].Count > 0)
        {

            if (_filtersInfo[val].ChildNode != null)
            {
                _filtersInfo[val].ChildNode.gameObject.SetActive(!_filtersInfo[val].ChildNode.gameObject.activeSelf);
                if (_filtersInfo[val].ChildNode.gameObject.activeSelf)
                {
                    _filterCount += _filtersInfo[val].Count;
                }
                else
                {
                    _filterCount -= _filtersInfo[val].Count;
                }
            }
            else
            {
                Transform t = null;
                t = GameObject.Instantiate<GameObject>(_secondItem).transform;

                for (int i = 0; i < _filtersInfo[val].Count; i++)
                {
                    Transform child = null;
                    if (i < t.childCount)
                    {
                        child = t.GetChild(i);
                    }
                    else
                    {
                        child = GameObject.Instantiate<GameObject>(t.GetChild(0).gameObject).transform;
                        child.SetParentAndReset(t);
                        child.name = "" + i;
                    }
                    //_filtersInfo[val].childs[i].ChangeToggleValue(_filtersInfo[val].childs[i].value);

                    child.Find(FilterLabel).GetComponent<ExText>().text = _filtersInfo[val].childs[i].labelText;
                }
                _filtersInfo[val].ChildNode = t;

                t.gameObject.SetActive(true);
                _filterCount += _filtersInfo[val].Count;
                List<Transform> tempList = new List<Transform>();
                for (int i = _filtersInfo.Count - 1; i > val; i--)
                {
                    if (_filtersInfo[i].Count > 0 && _filtersInfo[i].ChildNode != null)
                    {
                        _filtersInfo[i].ChildNode.SetParent(null);
                    }
                    _filtersInfo[i].RootNode.SetParent(null);
                }
                t.SetParentAndReset(_filterContent);
                for (int i = val + 1; i < _filtersInfo.Count; i++)
                {
                    _filtersInfo[i].RootNode.SetParent(_filterContent);
                    if (_filtersInfo[i].Count > 0 && _filtersInfo[i].ChildNode != null)
                    {
                        _filtersInfo[i].ChildNode.SetParent(_filterContent);
                    }
                }
            }
            if (_filtersInfo[val].ChildNode.gameObject.activeSelf)
            {
                _filtersInfo[val].Arrow.eulerAngles = new Vector3(180, 0, 0);
            }
            else
            {
                _filtersInfo[val].Arrow.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        //_filterList.vertical = _filterCount > 7;

    }
    //private static Dictionary<PartyType,>



    //一个id作为一个对象


    public override void Dispose()
    {
        SaveFilters();
        _filtersInfo.Clear();
        _filters.Clear();
        _createTeamBtn.RemoveButtonAllListener();
        _refreshBtn.RemoveButtonAllListener();
        _fastMatchBtn.RemoveButtonAllListener();
        EventDispatcher.RemoveEventListener(Events.PartyEvent.BeDisagree, OnDisagree);
        EventDispatcher.RemoveEventListener(Events.PartyEvent.FastMatching, _FastMatchingText);
        base.Dispose();
    }
    void SaveFilters()
    {
        Dictionary<UInt32, List<bool>> saver = FilterList.FilterValues;
        for (int i = 0; i < _filtersInfo.Count; i++)
        {
            FilterList.SetValue(_filtersInfo[i].TargetID, _filtersInfo[i].value, 0);

            if (_filtersInfo[i].Count > 0)
            {
                int index = 1;
                foreach (FilterStruct child in _filtersInfo[i].childs)
                {
                    FilterList.SetValue(_filtersInfo[i].TargetID, child.value, index++);
                }
            }
        }
    }
    /// <summary>
    ///只打开附近
    /// </summary>
    public void SetNearTrue()
    {
        for (int i = 0; i < _filtersInfo.Count; i++)
        {
            if (i != 1)
            {
                _filtersInfo[i].ChangeToggleValue(false, true);
            }
        }
    }


    class FilterStruct
    {
        public UInt32 TargetID; //类型
        public string labelText; //标签值
        public bool value; //存储toggle值
        public List<FilterStruct> childs;
        public int LevelLimit;
        //public int TargetID;
        public UICallback.VV_CB callback;
        FilterStruct _father;
        private Toggle _toggle;
        public FilterStruct(UInt32 id, string text, int level, bool b, FilterStruct fatherStuct = null)
        {
            TargetID = id;
            labelText = text;
            value = b;
            this._father = fatherStuct;
            this.LevelLimit = level;
        }
        public void SetToggle(Toggle toggle)
        {
            _toggle = toggle;
            _toggle.isOn = value;
            _toggle.onValueChanged.AddListener(_OnFilterChanged);
        }
        //强行修改toggle的值，isCallback是否走回调
        public void ChangeToggleValue(bool isTrue, bool isCallback = false)
        {
            value = isTrue;
            if (_toggle != null)
            {
                if (_toggle.isOn != isTrue)
                {
                    if (!isCallback)
                    {
                        _toggle.onValueChanged.RemoveListener(_OnFilterChanged);
                        _toggle.isOn = isTrue;
                        _toggle.onValueChanged.AddListener(_OnFilterChanged);
                    }
                    else
                    {
                        _toggle.isOn = isTrue;
                    }
                }
            }
        }

        private void _OnFilterChanged(bool isTrue)
        {
            value = isTrue;
            if (this._father == null)
            {
                if (childs != null)
                    foreach (FilterStruct child in childs)
                    {
                        child.ChangeToggleValue(isTrue);
                    }
            }
            else // child Node
            {
                if (!isTrue)
                {
                    if (_father.childs != null)
                    {
                        int result = -1;
                        foreach (FilterStruct child in _father.childs)
                        {
                            if (child.value == true)
                            {
                                result = 1;
                                break;
                            }
                        }
                        if (result == 1)
                            _father.ChangeToggleValue(true);
                        else
                            _father.ChangeToggleValue(false);
                    }
                }
                else
                {
                    _father.ChangeToggleValue(true);
                }
            }
            if (callback != null)
                callback();
        }
        public Transform Arrow
        {
            get; set;
        }
        public void AddChild(UInt32 id)
        {
            if (childs == null)
                childs = new List<FilterStruct>();
            TaskStruct ts = ViSealedDB<TaskStruct>.Data(id);
            //if (Player.Instance.Level < ts.LowLevel)
            //    return;
            bool v = Player.Instance.Level >= ts.LowLevel;
            if (v)
            {
                v = FilterList.GetValue(this.TargetID, childs.Count + 1);
            }
            childs.Add(new FilterStruct(id, ts.TaskName, ts.LowLevel, v, this));
        }
        public int Count
        {
            get
            {
                return childs == null ? 0 : childs.Count;
            }
        }
        public Transform RootNode
        {
            get; set;
        }
        public int ShowCount
        {
            get; set;
        }
        private Transform _childNode;
        public Transform ChildNode
        {
            get
            {
                return _childNode;
            }
            set
            {
                _childNode = value;
                ShowCount = 0;
                for (int i = 0; i < childs.Count; i++)
                {
                    Transform t = _childNode.GetChild(i);
                    if (t.gameObject.activeSelf)
                    {
                        if (childs[i].LevelLimit <= Player.Instance.Level)
                        {
                            childs[i].callback = this.callback;
                            Toggle toggle = t.GetChild(0).GetComponent<Toggle>();
                            childs[i].SetToggle(toggle);
                            toggle.interactable = true;
                            ShowCount++;
                        }
                        else
                        {
                            t.GetChild(0).GetComponent<Toggle>().interactable = false;
                        }
                    }
                }
                for (int i = ShowCount; i < _childNode.childCount; i++)
                {
                    _childNode.GetChild(i).gameObject.SetActive(false);
                }
                RectTransform rt = (RectTransform)value;
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, ((RectTransform)rt.GetChild(0)).sizeDelta.y * ShowCount);
            }
        }
    }
}






/// <summary>
/// 所有类型数据保存点（但是没有数据）
/// </summary>
public class FilterList
{
    public static Dictionary<UInt32, List<bool>> FilterValues = new Dictionary<UInt32, List<bool>>();
    /// <summary>
    /// Only use father's ID to get value
    /// </summary>
    /// <param name="index">Father's ID</param>
    /// <param name="no">father is 0 , child from 1</param>
    /// <returns></returns>
    public static bool GetValue(UInt32 index, int no)
    {
        if (FilterValues.ContainsKey(index))
        {
            if (FilterValues[index] != null && no < FilterValues[index].Count)
                return FilterValues[index][no];
        }
        return true;
    }
    public static void SetValue(UInt32 index, bool value, int no)
    {
        List<bool> values;
        if (FilterValues.ContainsKey(index) && FilterValues[index] != null)
            values = FilterValues[index];
        else
        {
            values = new List<bool>();
            FilterValues[index] = values;
        }
        if (no < values.Count)
            values[no] = value;
        else
            values.Add(value);
    }
}
