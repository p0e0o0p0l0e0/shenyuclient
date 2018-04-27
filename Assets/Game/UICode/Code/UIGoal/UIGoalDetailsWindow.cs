using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIGoalDetailsWindow : UIWindow<UIGoalDetailsWindow, UIGoalDetailsController>
{
    #region ui control name define 
    private const string BtnExit = "UIGoalDetailsWindow/CloseBtn";

    private const string TransGoalTypeItem = "UIGoalDetailsWindow/Left/LeftTagList/Viewport/Grid/GoalType";
    private const string TransGoalItem = "UIGoalDetailsWindow/Left/DetailsTask/GoalItem";
    private const string TransGoalItemParent = "UIGoalDetailsWindow/Left/DetailsTask";
    
    private const string TransGoalGoPrice = "UIGoalDetailsWindow/Right/RightBottom";
    private const string TransLootItem = "UIGoalDetailsWindow/Right/RightBottom/PriceList/Viewport/Grid/LootItem";
    private const string TxtGoalDescribe = "UIGoalDetailsWindow/Right/DescPic/TaskDescText";
    private const string TxtGoalName = "UIGoalDetailsWindow/Right/DescPic/TaskNameText";
    private const string BtnGo = "UIGoalDetailsWindow/Right/RightBottom/GoButton";
    #endregion
    //Main
    private Button _btnExit;
    //Left
    private Dictionary<GoalCategory, GoalTypeItem> _goalTypeDict = new Dictionary<GoalCategory,GoalTypeItem>();
    private List<GoalInfoItem> _goalInfoList = new List<GoalInfoItem>();
    private Transform _transGoalItemParent = null;
    private Transform _transGoalTypeItem = null;
    private Transform _transGoalItem = null;
    //Right
    private List<GoalLootItem> _goalLootList = new List<GoalLootItem>();
    private Transform _transGoalGoPrice = null;
    private Transform _transLootItem = null;
    private ExText _txtGoalDescribe;
    private ExText _txtGoalName;
    private ExUIButton _btnGo;
    /// <summary>
    /// 当前选中类型
    /// </summary>
    private GoalCategory _currentType = GoalCategory.MAINLINE;
    /// <summary>
    /// 当前选中任务
    /// </summary>
    private GoalInfo _currentGoal;

    protected override void Initial()
    {
        base.Initial();

        _btnExit = this.GetComponent<Button>(BtnExit);
        _btnExit.onClick.AddListener(_OnBtnExitCallBack);

        _transGoalTypeItem = this.GetComponent<Transform>(TransGoalTypeItem);
        _transGoalItemParent = this.GetComponent<Transform>(TransGoalItemParent);
        _transGoalItem = this.GetComponent<Transform>(TransGoalItem);
        _transGoalTypeItem.SetActive(false);
        _transGoalItem.SetActive(false);
        InitLeft();

        _transGoalGoPrice = this.GetComponent<Transform>(TransGoalGoPrice);
        _txtGoalName = this.GetComponent<ExText>(TxtGoalName);
        _txtGoalDescribe = this.GetComponent<ExText>(TxtGoalDescribe);
        _btnGo = this.GetComponent<ExUIButton>(BtnGo);
        _btnGo.onClick.AddListener(_OnBtnGoCallBack);
        _transLootItem = this.GetComponent<Transform>(TransLootItem);
        _transLootItem.SetActive(false);
    }
    public override void Destroy()
    {
        _btnExit.onClick.RemoveAllListeners();
        _btnExit = null;

        _transGoalTypeItem = null;
        _transGoalItemParent = null;
        _transGoalItem = null;
        _transLootItem = null;

        _txtGoalName = null;
        _txtGoalDescribe = null;
        _btnGo.onClick.RemoveAllListeners();
        _btnGo = null;

        foreach (KeyValuePair<GoalCategory,GoalTypeItem> item in _goalTypeDict)
            item.Value.Clear();

        for (int i = 0; i < _goalInfoList.Count; i++)
            _goalInfoList[i].Clear();

        for (int i = 0; i < _goalLootList.Count; i++)
            _goalLootList[i].Clear();

        _goalTypeDict.Clear();
        _goalInfoList.Clear();
        _goalLootList.Clear();

        _currentType = GoalCategory.MAINLINE;
        _currentGoal = null;

        base.Destroy();
    }
    /// <summary>
    /// 初始化左侧任务类型界面
    /// </summary>
    public void InitLeft()
    {
        if (_transGoalTypeItem == null)
        {
            UConsole.LogError("没有找到克隆体");
            return;
        }

        string[] names =  Enum.GetNames(typeof(GoalCategory));

        for (int i = 0; i < names.Length; i++)
        {
            GameObject obj = UICommonFuntion.Copy(_transGoalTypeItem.gameObject, _transGoalTypeItem.transform.parent, names[i]);
            if (obj.NotNull())
            {
                obj.SetActive(true);
                GoalCategory type = (GoalCategory)Enum.Parse(typeof(GoalCategory), names[i]);
                GoalTypeItem item = new GoalTypeItem(type, obj.transform);
                item.Init(_OnBtnGoalTypeCallBack);
                _goalTypeDict.Add(type, item);
            }
        }
    }
    /// <summary>
    /// 刷新数据和界面 
    /// </summary>
    /// <param name="goalList"></param>
    public void UpdateGoalList(List<GoalObject> goalList)
    {
        //清空旧数据
        foreach (KeyValuePair<GoalCategory, GoalTypeItem> item in _goalTypeDict)
        {
            item.Value.ClearGoalList();
        }
        //添加最新数据
        for (int i = 0; i < goalList.Count; i++)
        {
            GoalTypeItem item = null;
            if (_goalTypeDict.TryGetValue(goalList[i].Category,out item))
            {
                GoalInfo info = new GoalInfo(
                    goalList[i].ID, 
                    goalList[i].Name,
                    goalList[i].Description, 
                    goalList[i].LootItemInfoList,
                    goalList[i].IsEnd);
                item.AddGoalInfo(info);
            }
        }
        //任务个数为0的分类不显示
        foreach (KeyValuePair<GoalCategory, GoalTypeItem> item in _goalTypeDict)
        {
            item.Value.SetActive(item.Value.ChildCount() != 0);
        }
        GoalCategory tempDefault = GoalCategory.MAINLINE;
        GoalInfo tempGoalInfo = null;
        //更新当前选中显示
        foreach (KeyValuePair<GoalCategory, GoalTypeItem> item in _goalTypeDict)
        {
            if (item.Value.ChildCount() == 0)
                continue;
            _currentType = item.Key;
            _currentGoal = item.Value.GetDoingGoalInfo();

            if (_currentGoal == null)
            {
                tempDefault = item.Key;
                tempGoalInfo = item.Value.GoalInfoList[0];
            }
            break;
        }
        //假如选中默认显示为空，选中已完成的任务
        if (_currentGoal == null)
        {
            _currentType = tempDefault;
            _currentGoal = tempGoalInfo;
            tempGoalInfo = null;
        }

        //更新左侧面板
        UpdateLeft(_currentType);
        //更新右侧显示信息
        UpdateRight(_currentGoal);
    }
    /// <summary>
    /// 刷新左侧界面
    /// </summary>
    /// <param name="type"></param>
    private void UpdateLeft(GoalCategory type)
    {
        if (_transGoalItem == null)
        {
            UConsole.LogError("_transGoalItem == null");
            return;
        }
        if (_transGoalItemParent == null)
        {
            UConsole.LogError("_transGoalItemParent == null");
            return;
        }
        GoalTypeItem item = null;
        if (_goalTypeDict.TryGetValue(type,out item))
        {
            foreach (KeyValuePair<GoalCategory,GoalTypeItem> goalTypeItem in _goalTypeDict)
            {
                goalTypeItem.Value.SetHigh(type);
                goalTypeItem.Value.UpdateBGState(_currentType == type);
            }
            _transGoalItemParent.SetParent(item.TransItem);
            _transGoalItemParent.localPosition = new Vector3(-5, -40, 0);
            UICommonFuntion.UpdateInfo<GoalInfoItem, GoalInfo>(ref _goalInfoList, item.GoalInfoList, _transGoalItem, _transGoalItemParent, _OnBtnGoalCallBack);
            //force refresh
            _transGoalTypeItem.transform.parent.SetActive(false);
            _transGoalTypeItem.transform.parent.SetActive(true);
        }
    }
    /// <summary>
    /// 刷新右侧界面
    /// </summary>
    /// <param name="info"></param>
    private void UpdateRight(GoalInfo info)
    {
        if (info == null)
        {
            UConsole.LogError("当前没有选中");
            return;
        }

        for (int i = 0; i < _goalInfoList.Count; i++)
        {
            _goalInfoList[i].UpdateBGState(_goalInfoList[i].IsThisGoalInfo(info));
        }

        _currentGoal = info;
        _txtGoalName.SetTextContent(_currentGoal.Name);
        _txtGoalDescribe.SetTextContent(_currentGoal.Describe);
        
        if (_transLootItem == null)
        {
            UConsole.LogError("_transLootItem == null");
            return;
        }
        UICommonFuntion.UpdateInfo<GoalLootItem,LootItemInfo>(ref _goalLootList, info.LootItemInfoList,_transLootItem,_transLootItem.parent, _OnBtnGoalLootCallBack);
        
        _transGoalGoPrice.SetActive(!info.Complete);
    }
    /// <summary>
    /// 任务类型按钮
    /// </summary>
    /// <param name="clickType"></param>
    private void _OnBtnGoalTypeCallBack(GoalCategory clickType)
    {
        if (clickType == _currentType)
            return;

        _currentType = clickType;
        UpdateLeft(clickType);
    }
    /// <summary>
    /// 任务按钮
    /// </summary>
    /// <param name="info"></param>
    private void _OnBtnGoalCallBack(GoalInfo info)
    {
        UpdateRight(info);
    }
    /// <summary>
    /// 物品图标
    /// </summary>
    /// <param name="info"></param>
    private void _OnBtnGoalLootCallBack(LootItemInfo info)
    {
        UIManagerUtility.ShowTips(false,info.ID,0,false);
    }
    /// <summary>
    /// 退出按钮
    /// </summary>
    private void _OnBtnExitCallBack()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_GoalDetail);
    }
    /// <summary>
    /// 前往按钮
    /// </summary>
    private void _OnBtnGoCallBack()
    {
        if (_currentGoal != null)
        {
            this._mController.DoGoal(_currentGoal.GoalID);
            _OnBtnExitCallBack();
        }
    }

    public class GoalTypeItem
    {
        private const string SpriteGoalTypeBG = "Show";
        private const string TxtGoalTypeName = "Show/txtGoalTypeName";
        private const int Spacing = 2;
        private const int ChildItemHigh = 60;
        private const int High = 76;

        public GoalCategory Category;
        public string Name;
        public Transform TransItem;
        public List<GoalInfo> GoalInfoList = new List<GoalInfo>();

        private ExText txtGoalTypeName;
        private ExUIButton btnGoalType;
        private RectTransform rectTrans;
        private ExUISprite spriteGoalTypeBG;

        public GoalTypeItem(GoalCategory type, Transform trans)
        {
            Category = type;
            Name = GetName(Category);
            TransItem = trans;
            rectTrans = trans as RectTransform;
        }
        public void Init(Action<GoalCategory> callBack)
        {
            btnGoalType = TransItem.GetComponent<ExUIButton>();
            btnGoalType.onClick.AddListener(() =>
            {
                if (callBack != null)
                    callBack(Category);
            });
            txtGoalTypeName = TransItem.GetComponentPro<ExText>(TxtGoalTypeName);
            txtGoalTypeName.SetTextContent(Name);
            spriteGoalTypeBG = TransItem.GetComponentPro<ExUISprite>(SpriteGoalTypeBG);
            UpdateBGState(false);
        }
        public void UpdateBGState(bool enable)
        {
            if (spriteGoalTypeBG != null)
                spriteGoalTypeBG.enabled = enable;
        }
        public void SetActive(bool enable)
        {
            TransItem.SetActive(enable);
        }
        public void SetHigh(GoalCategory type)
        {
            if (type == Category)
            {
                int count = GoalInfoList.Count;
                if (count > 0)
                {
                    int high = High + (ChildItemHigh) * count;
                    rectTrans.SetRectTransformHigh(high);
                }
            }
            else
                rectTrans.SetRectTransformHigh(High);
        }
        public void ClearGoalList()
        {
            for (int i = 0; i < GoalInfoList.Count; i++)
            {
                GoalInfoList[i].Clear();
                GoalInfoList[i] = null;
            }
            GoalInfoList.Clear();
        }
        public void AddGoalInfo(GoalInfo info)
        {
            GoalInfoList.Add(info);
        }
        public int ChildCount()
        {
            return GoalInfoList.Count;
        }

        public GoalInfo GetDoingGoalInfo()
        {
            return GoalInfoList.Find(_index =>_index.Complete == false);
        }

        public string GetName(GoalCategory type)
        {
            switch (type)
            {
                case GoalCategory.MAINLINE:
                    return "主线任务";
                case GoalCategory.BRANCHLINE:
                    return "支线任务";
                case GoalCategory.ACTIVITY:
                    return "活动任务";
                case GoalCategory.WEEKLY:
                    return "周常任务";
                case GoalCategory.ORIENTATION:
                    return "定向任务";
                case GoalCategory.TEAM:
                    return "组队任务";
                case GoalCategory.TRANSFER:
                    return "转职任务";
                case GoalCategory.LOVE:
                    return "情缘任务";
                case GoalCategory.ADVENTURER:
                    return "冒险者任务";
                case GoalCategory.UNION:
                    return "盟任务";
            }
            return "";
        }

        public void Clear()
        {
            TransItem = null ;
            txtGoalTypeName = null;
            btnGoalType.RemoveButtonAllListener();
            btnGoalType = null;
            rectTrans = null;
            ClearGoalList();
        }
    }
    public class GoalInfo
    {
        public uint GoalID { get; private set; }
        public string Name { get; private set; }
        public string Describe { get; private set; }
        public List<LootItemInfo> LootItemInfoList { get; private set; }

        public bool Complete { get; private set; }

        public GoalInfo(uint goalID, string name, string describe, List<LootItemInfo> lootItemInfoList,bool complete)
        {
            GoalID = goalID;
            Name = name;
            Describe = describe;
            LootItemInfoList = lootItemInfoList;
            Complete = complete;
        }
        public void Clear()
        {
            LootItemInfoList = null;
        }
    }
    public class GoalInfoItem : CloneItem<GoalInfo>
    {
        private const string SpriteGoalBG = "Show";
        private const string TxtGoalName = "Show/txtGoalName";

        private ExText txtGoalName;
        private ExUIButton btnGoal;
        private ExUISprite spriteGoalBG;

        public override void Init(Action<GoalInfo> callBack)
        {
            btnGoal = Trans.GetComponent<ExUIButton>();
            btnGoal.AddButtonListener(()=>
            {
                if (callBack != null)
                    callBack(t);
            });
            txtGoalName = Trans.GetComponentPro<ExText>(TxtGoalName);
            spriteGoalBG = Trans.GetComponentPro<ExUISprite>(SpriteGoalBG);
            UpdateBGState(false);
        }
        public override void UpdateInfo(GoalInfo info)
        {
            base.UpdateInfo(info);
            txtGoalName.SetTextContent(info.Name);
        }
        public void UpdateBGState(bool enable)
        {
            if(spriteGoalBG != null)
                spriteGoalBG.enabled = enable;
        }
        public bool IsThisGoalInfo(GoalInfo info)
        {
            return t.Equals(info);
        }
        public override void Clear()
        {
            base.Clear();
            txtGoalName = null;
            if(btnGoal != null)
                btnGoal.RemoveButtonAllListener();
            btnGoal = null;
            spriteGoalBG = null;
        }
    }
    public class GoalLootItem : CloneItem<LootItemInfo>
    {
        private const string SpriteItemIcon = "QualitySprite";

        private ExUITexture spriteItemIcon;
        private ExUIButton btnItem;
        
        public override void Init(Action<LootItemInfo> callBack)
        {
            spriteItemIcon = Trans.GetComponentPro<ExUITexture>(SpriteItemIcon);
            if (spriteItemIcon.NotNull())
            {
                btnItem = spriteItemIcon.GetComponent<ExUIButton>();
                btnItem.AddButtonListener(() =>
                {
                    if (callBack != null)
                        callBack(t);
                });
            }
        }
        public override void UpdateInfo(LootItemInfo info)
        {
            base.UpdateInfo(info);

            if (info.IconPath.IsNotNullOrEmpty())
            {
                spriteItemIcon.LoadIcon(info.IconPath, info.Quality, ExUITexture_Extend.IconStyle.RECT);
            }
            else
                UConsole.LogError("info.IconPath.IsNullOrEmpty");
        }
        public override void Clear()
        {
            base.Clear();
            if(spriteItemIcon != null)
                spriteItemIcon.UnLoadIcon();
            spriteItemIcon = null;
            btnItem.RemoveButtonAllListener();
            btnItem = null;
        }
    }
}
public class LootItemInfo
{
    public int ID;
    public string Name;
    public string IconPath;
    public ItemQualityEnum Quality;

    public string IconName;
    public string AltasName;

    public LootItemInfo(ItemStruct item)
    {
        ID = item.ID;
        Name = item.Name;
        Quality = (ItemQualityEnum)item.Quality.Data.ItemQualityEnum.Value;

        VisualItemStruct visualItem = ViSealedDB<VisualItemStruct>.Data(item.ID);
        if (visualItem != null)
        {
            if (visualItem.Icon.IsNotNullOrEmpty())
                IconPath = visualItem.Icon;
            else
                UConsole.LogError("visualItem.Icon为空,id=" + item.ID);
        }
        else
            UConsole.LogError("visualItem为空,id=" + item.ID);
    }
}
