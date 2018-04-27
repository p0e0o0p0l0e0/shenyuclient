using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class UIGoalManager : IDisposable
{
    private const string TextGoalName = "textGoalName";
    private const string TextGoalLevel = "spriteGoadState/textGoalLevel";
    private const string TextGoalDescribe = "textGoalDescribe";
    private const string BtnDoGoal= "btnDoGoal";
    private const string SpriteState = "spriteGoadState";
    private const string SpriteIcon = "spriteGoadType";
    private const string SpriteBG = "spriteGoalBg";

    private static UIGoalManager _handler;
    public static UIGoalManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new UIGoalManager();
            return _handler;
        }
    }
    public class GoalItemElement
    {
        //TODO zlj 汉字
        private static string[] StateArray = { "可领取", "进行中", "X级开启" };
        private const string Flag = "X";

        public Transform Tran { get; set; }
        public Text TextGoalName { get; set; }
        public Text TextGoalLevel { get; set; }
        public Text TextGoalDescribe { get; set; }
        public Button BtnDoGoal { get; set; }
        public ExUISprite SpriteState { get; set; }
        public ExUISprite SpriteIcon { get; set; }
        public ExUISprite SpriteBG { get; set; }

        public GoalObject GoalInfo { get; private  set; }

        public Action<GoalStruct> ClickGoalItemCallBack = null;

        private Transform _objEffect = null;

        public void Close()
        {
            Tran.gameObject.SetActive(false);
        }
        public void Open()
        {
            Tran.gameObject.SetActive(true);
        }
        public void UpdateInfo(GoalObject goalInfo)
        {
            GoalInfo = goalInfo;
            GoalInfo.ActionUpdateCount = _OnUpdateCount;
            GoalInfo.ActionUpdateStateInfo = _OnUpdateState;
            GoalInfo.ActionPlayerEffect = _OnShowEndEffect;

            if (GoalInfo.IsGoalCountInterface)
                _OnUpdateCount(GoalInfo.Property.Value, GoalInfo.Count);
            else
                TextGoalName.SetTextContent(GetFlag() + goalInfo.Name);
          
            TextGoalDescribe.SetTextContent(goalInfo.Description);
            _OnUpdateState();
            
            //SpriteIcon.SetExUISprite(GoalInfo.Icon);
            //SpriteBG.SetExUISprite(GoalInfo.BGIcon);
        }
        private int GetStateIndex()
        {  
            if (GoalInfo.IsDone && !GoalInfo.IsAutoTurnIn)
            {
                return 0;
            }
            if (GoalInfo.IsLevelEnouth)
            {
                return 1;
            }
            return 2;
        }
        private string GetFlag()
        {
            string str = "";
            switch (GoalInfo.Category)
            {
                case GoalCategory.MAINLINE:
                    str = "[主]";
                    break;
                case GoalCategory.BRANCHLINE:
                    str = "[支]";
                    break;
                case GoalCategory.ACTIVITY:
                    str = "[活]";
                    break;
                case GoalCategory.WEEKLY:
                    str = "[周]";
                    break;
                case GoalCategory.ORIENTATION:
                    str = "[定]";
                    break;
                case GoalCategory.TEAM:
                    str = "[组]";
                    break;
                case GoalCategory.TRANSFER:
                    str = "[转]";
                    break;
                case GoalCategory.LOVE:
                    str = "[情]";
                    break;
                case GoalCategory.ADVENTURER:
                    str = "[冒]";
                    break;
                case GoalCategory.UNION:
                    str = "[盟]";
                    break;
                default:
                    str = "[主]";
                    break;
            }
            return str;
        }
        private void _OnUpdateCount(int count,int totalCount)
        {
            TextGoalName.SetTextContent(string.Format("{0}{1} {2}/{3}", GetFlag(),GoalInfo.Name,count,totalCount));
        }
        private void _OnUpdateState()
        {
            int index = GetStateIndex();
            SpriteState.SetExUISprite(UIGoalDefine.BTNARRAY[index]);
            TextGoalLevel.SetTextContent(StateArray[index].Replace(Flag, GoalInfo.NeedLevel.ToString()));
            TextGoalLevel.color = UIGoalDefine.COLORARRAY[index].ToColor();
        }
        private void _OnShowEndEffect()
        {
            if (!GoalManager.GetInstance.UIController.IsShow)
            {
                return;
            }
            //if (_objEffect == null)
            {
             //   _objEffect = UIEffectManager.Instance.Load(UIGoalDefine.EFFECT_COMPLETESMALLGOAL, _OnEffectLoadedCallBack);
            }
            RefreshEffect();
        }
        //private void _OnEffectLoadedCallBack(string name, object go)
        //{
        //    if (go == null)
        //        return;
        //    _objEffect = GameObject.Instantiate(go as GameObject);
        //    _objEffect.transform.SetParent(Tran);
        //    _objEffect.transform.localPosition = Vector3.zero;
        //    _objEffect.transform.localScale = Vector3.one;
        //    _objEffect.SetActive(false);
        //    _objEffect.AddComponent<DelayHide>().delayTime = 0.4f;

        //    RefreshEffect();
        //}
        private void RefreshEffect()
        {
            if (_objEffect != null)
            {
                _objEffect.SetActive(false);
                _objEffect.SetActive(true);
            }
        }
        public void Detach()
        {
            GoalInfo.ActionUpdateStateInfo = null;
            GoalInfo.ActionUpdateCount = null;
            GoalInfo = null;
            Tran = null;
            TextGoalName = null;
            TextGoalLevel = null;
            TextGoalDescribe = null;
            BtnDoGoal = null;
            SpriteState = null;
            SpriteIcon = null;
            SpriteBG = null;
            ClickGoalItemCallBack = null;
        }
    }

    private List<GoalItemElement> _goalItemPool = new List<GoalItemElement>();
    private Transform _goalItemTran = null;
    private int _goalItemUseCount = 0;

    private UIGoalManager() { }

    public void SetGoalItemTran(Transform tran)
    {
        _goalItemTran = tran;
    }
    public bool CreateGoalItem(int count, Action<uint> callBack)
    {
        if (_goalItemTran == null) return false;
        int createCount = count - _goalItemPool.Count;
        if (createCount > 0)
        {
            for (int i = 0; i < createCount; ++i)
            {
                GoalItemElement element = _initalGoalItemElement(_goalItemTran.gameObject, callBack);
                _goalItemPool.Add(element);
            }
        }
        return true;
    }
    private GoalItemElement _initalGoalItemElement(GameObject target, Action<uint> callBack)
    {
        GoalItemElement element = new GoalItemElement();
        GameObject go = GameObject.Instantiate(target);
        element.Tran = go.transform;
        //element.Tran.parent = target.transform.parent;
        element.Tran.SetParent(target.transform.parent);
        element.Tran.localPosition = Vector3.zero;
        element.Tran.localScale = Vector3.one;
        element.TextGoalName = go.GetComponentPro<Text>(TextGoalName);
        element.TextGoalLevel = go.GetComponentPro<Text>(TextGoalLevel);
        element.TextGoalDescribe = go.GetComponentPro<Text>(TextGoalDescribe);
        element.BtnDoGoal = go.GetComponentPro<Button>(BtnDoGoal);
        element.BtnDoGoal.onClick.AddListener(()=> { callBack(element.GoalInfo.ID); });
        element.SpriteState = go.GetComponentPro<ExUISprite>(SpriteState);
        element.SpriteIcon = go.GetComponentPro<ExUISprite>(SpriteIcon);
        element.SpriteBG = go.GetComponentPro<ExUISprite>(SpriteBG);
        return element;
    }
    public GoalItemElement SpwanGoalItem()
    {
        try
        {
            GoalItemElement element = _goalItemPool[_goalItemUseCount];
            element.Open();
            ++_goalItemUseCount;
            return element;
        }
        catch(Exception ex)
        {
            
        }
        return null;
    }
    public void RefreshPosition(GoalItemElement element)
    {
        element.Tran.SetAsLastSibling();
    }
    public void KillGoalItemElement(GoalItemElement element)
    {
        element.Close();
        --_goalItemUseCount;
        _goalItemPool.Remove(element);
        _goalItemPool.Add(element);
    }
    public void UpdateGoalItem(GoalObject goalInfo, GoalItemElement element)
    {
        if (element == null) return;
        element.UpdateInfo(goalInfo);
    }
    public void Destroy()
    {
        _goalItemTran = null;
        _goalItemUseCount = 0;

        for (int i = 0; i < _goalItemPool.Count; i++)
        {
            _goalItemPool[i].Detach();
            _goalItemPool[i] = null;
        }
        _goalItemPool.Clear();
    }
    public void Dispose()
    {
        Destroy();
    }
    
}
