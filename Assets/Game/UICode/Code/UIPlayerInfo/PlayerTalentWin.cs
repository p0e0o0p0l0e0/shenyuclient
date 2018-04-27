using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerTalentWin : UISubWindow<UIPlayerInfoWindow, UIPlayerInfoController>
{
    private const string ResetBtn = "/Left/SkillResetBtn";
    private const string ScrollRect = "/Left/SkillList";
    private const string ScrollContent = "/Left/SkillList/Content";
    private const string JobName = "JobName";
    private const string SkillName = "Skill";

    private ExUIButton resetBtn;
    private LoopVerticalScrollRect scrollRect;

    private DetailInfoWin detailWin;
    private SetUpWin setWin;
    private skillBtnInfo curSkillBtn;
    private bool initScroll;
    private bool isSetWinShowing;

    public int curSpellId;

    public override void Initial(UIPlayerInfoWindow window, UIPlayerInfoController controller, string topPath = "")
    {
        base.Initial(window, controller, topPath);
        resetBtn = GetComponent<ExUIButton>(ResetBtn);
        resetBtn.onClickEx = (val, o) => {
        {
                UIManagerUtility.ShowConfirm(window.ResetSpellText, (i, o1) => CellHeroCommandInvoker.ResetSpell(CellHero.LocalHero), (a, b) => { });
        } };

        scrollRect = GetComponent<LoopVerticalScrollRect>(ScrollRect);
        scrollRect.Init(RefreshScroll, 2, topPath+ ScrollContent); ;

        detailWin = new DetailInfoWin(window,this);
        setWin = new SetUpWin(window,this);
        setWin.Initial(window, "UIPlayerInfoWindow/ShowList/PlayerTalent/tween");
    }

    public void ShowDetail(OwnSpellStruct spell)
    {
        
        detailWin.Show(spell);
    }

    public void ShowSet(OwnSpellStruct spell)
    {
        
        setWin.Show(spell);
    }

    public override void Show()
    {
        base.Show();
        detailWin.Hide();
        setWin.Hide();
        initScroll = true;
    }

    public override void Hide()
    {
        if (curSkillBtn.NotNull())
            curSkillBtn.selectObj.SetActive(false);
        curSpellId = -1;
        detailWin.Hide();
        setWin.Hide();
        isSetWinShowing = false;
        base.Hide();
    }

    private void RefreshScroll(string root, int index)
    {
        if (index == 0)
        {
            //职业名
            string name = root.ToNodePath("JobName/JobNameText");
            Text nameText = _mWindow.GetComponent<Text>(name);
            nameText.SetTextContent(CellHero.LocalHero.LogicInfo.HeroClass.Value.ToHeroClass(false));
            //技能
            for (int i = 0; i < BasicSpellCount; i++)
            {
                string path = root.ToNodePath(SkillName + (i + 1)).ToNodePath("LvBg");
                ControlVisible(path, TalentDataMgr.GetInstance.GetSpellByFloor(i));
                for (int j = 0; j < TalentDataMgr.GetInstance.GetSpellByFloor(i).Count; j++)
                {
                    SetSkill(path.ToNodePath("SkillBg" + (TalentDataMgr.GetInstance.GetSpellByFloor(i)[j].Position + 1)), TalentDataMgr.GetInstance.GetSpellByFloor(i)[j],path+ "/" + "SkillSelect" + (TalentDataMgr.GetInstance.GetSpellByFloor(i)[j].Position + 1).ToString());
                }
                //lvbg
                SetLV(path,TalentDataMgr.GetInstance.GetSpellByFloor(i)[0]);
            }
        }

        if (index == 1)
        {
            //职业名
            string name = root.ToNodePath("JobName1/JobNameText");
            Text nameText = _mWindow.GetComponent<Text>(name);
            nameText.SetTextContent(CellHero.LocalHero.LogicInfo.HeroClass.Value.ToHeroClass(true));
            //技能
            for (int i = 0; i < AdvSpellCount; i++)
            {
                string path = root.ToNodePath(SkillName + (i + 1+BasicSpellCount));
                XLColorDebug.LogBattle(path);
                ControlVisible(path.ToNodePath("LvBg"), TalentDataMgr.GetInstance.GetSpellByFloor(i));
                for (int j = 0; j < TalentDataMgr.GetInstance.GetSpellByFloor(i).Count; j++)
                {
                    SetSkill(path.ToNodePath("SkillBg" + (j + 1)), TalentDataMgr.GetInstance.GetSpellByFloor(i)[j], path +"/+"+ "SkillBg_Left" + (TalentDataMgr.GetInstance.GetSpellByFloor(i)[j].Position + 1).ToString());
                }
                //lvbg
                SetLV(path, TalentDataMgr.GetInstance.GetSpellByFloor(i)[0]);
            }
        }
    }

    private void SetSkill(string node, OwnSpellStruct spell,string selectPath)
    {
        GameObject select = _mWindow.FindTransform(selectPath).gameObject;
        GameObject unEquip = _mWindow.FindTransform(node.ToNodePath("UnequippedSkillText")).gameObject;
        GameObject equip = _mWindow.FindTransform(node.ToNodePath("EquippedSkill")).gameObject;
        GameObject learn = _mWindow.FindTransform(node.ToNodePath("LearnSkillText")).gameObject;
        ExCircleSprite icon = _mWindow.GetComponent<ExCircleSprite>(node.ToNodePath("Skill"));
        ExUIButton btn = _mWindow.GetComponent<ExUIButton>(node.ToNodePath("Skill"));
        btn.onClickEx = ClickSkillBtn;

        if (!initScroll)
        {
            skillBtnInfo info = new skillBtnInfo();
            info.id = spell.ID;
            info.selectObj = select;
            info.unEquip = unEquip;
            info.equip = equip;
            info.learn = learn;
            if (skillBtnDic.ContainsKey(btn))
                ViDebuger.Error("ownspell配置错误   同一层一个技能位置有多个技能");
            else
                skillBtnDic.Add(btn, info);
        }
        foreach (var value in skillBtnDic.Values)
        {
            value.Refresh(_mController);
        }
        IconData iconData = IconDataManager.GetIcon(spell.Icon);
        UIUtility.SetSprite(icon, iconData);
    }

    private void ClickSkillBtn(int val, object obj)
    {
        var btn = obj as ExUIButton;
        if (!skillBtnDic.ContainsKey(btn))
        {
            Debug.LogError("unknow skill btn"+btn.name);
            return;
        }
        curSkillBtn = skillBtnDic[btn];
        if (curSpellId == curSkillBtn.id)
            return;
        curSpellId = curSkillBtn.id;
        if (lastClickBtn.NotNull())
        {
            var lastInfo = skillBtnDic[lastClickBtn];
            lastInfo.selectObj.SetActive(false);
        }
        lastClickBtn = btn;
        XLColorDebug.LogUI(curSkillBtn.id.ToString());
        curSkillBtn.selectObj.SetActive(true);
        if (isSetWinShowing)
        {
            setWin.Show(ViSealedDB<OwnSpellStruct>.GetData(curSkillBtn.id));
            detailWin.Hide();
        }
        else
        {
            detailWin.Show(ViSealedDB<OwnSpellStruct>.GetData(curSkillBtn.id));
            setWin.Hide();
        }
    }

    private void ControlVisible(string node,List<OwnSpellStruct> spellList)
    {
        List<GameObject> objList = new List<GameObject>();
        objList.Add(_mWindow.FindTransform(node.ToNodePath("SkillBg1")).gameObject);
        objList.Add(_mWindow.FindTransform(node.ToNodePath("SkillBg2")).gameObject);
        objList.Add(_mWindow.FindTransform(node.ToNodePath("SkillBg3")).gameObject);

        List<ExUISprite> alphaList = new List<ExUISprite>();
        alphaList.Add(_mWindow.GetComponent<ExUISprite>(node.ToNodePath("SkillBg_Left1")));
        alphaList.Add(_mWindow.GetComponent<ExUISprite>(node.ToNodePath("SkillBg_Left2")));
        alphaList.Add(_mWindow.GetComponent<ExUISprite>(node.ToNodePath("SkillBg_Left3")));

        for (int i = 0; i < objList.Count; i++)
        {
            objList[i].SetActive(false);
            alphaList[i].gameObject.SetActive(false);
        }
        int count = spellList.Count;
        if (spellList.Count > objList.Count)
            ViDebuger.Error("ownspell配置错误  某一层技能数超过UI上限");
        for (int i = 0; i < count; i++)
        {
            objList[spellList[i].Position].SetActive(true);
            alphaList[i].gameObject.SetActive(true);

            bool reached = CellHero.LocalHero.Property.Level.Value >= spellList[i].NeedLevel;
            Color color = alphaList[i].color;
            color.a = reached ? ActiveAlpha : UnlockAlpha;
            alphaList[i].color= color;
        }
    }

    private void SetLV(string root, OwnSpellStruct spell)
    {
        string reach = root.ToNodePath("Reach");
        GameObject reachObj = _mWindow.FindTransform(reach).gameObject;
        bool reached;
        //aaa  转职后加
        reached = CellHero.LocalHero.Property.Level.Value >= spell.NeedLevel;
        reachObj.SetActive(reached);
        ExUISprite sp = _mWindow.GetComponent<ExUISprite>(root.ToNodePath("Bg"));
        Color color = sp.color;
        color.a = reached ? ActiveAlpha : UnlockAlpha;
        sp.color = color;

        string levelPath = root.ToNodePath("LvText");
        Text level = _mWindow.GetComponent<Text>(levelPath);
        level.SetTextContent(spell.NeedLevel);
    }

    public override void Refresh()
    {
        scrollRect.RefreshAllCells();
    }

    public void UpdateInfo()
    {
        if (isSetWinShowing)
        {
            setWin.Show(ViSealedDB<OwnSpellStruct>.GetData(curSpellId));
        }
        else
        {
            detailWin.Show(ViSealedDB<OwnSpellStruct>.GetData(curSpellId));
        }
    }

    public void CloseRight()
    {
        if (curSkillBtn.NotNull())
            curSkillBtn.selectObj.SetActive(false);
        curSpellId = -1;
        isSetWinShowing = false;
        setWin.Hide();
        detailWin.Hide();
    }

    private class skillBtnInfo
    {
        public int id { get; set; }
        public GameObject selectObj;
        public GameObject unEquip;
        public GameObject equip;
        public GameObject learn;
        public bool canLearn;

        public void Refresh(UIPlayerInfoController controller)
        {
            canLearn = false;
            unEquip.SetActive(false);
            equip.SetActive(false);
            learn.SetActive(false);
            if (controller.SpellUnlock(id))
                return;
            if (controller.SpellEquiped(id))
            {
                equip.SetActive(true);
                return;
            }
            if (controller.SpellCanLearn(id))
            {
                learn.SetActive(true);
                canLearn = true;
                return;
            }
            if (controller.SpellUnEquiped(id))
            {
                unEquip.SetActive(true);
                return;
            }
        }
    }

    private ExUIButton lastClickBtn;
    private ExUIButton curClickBtn;

    private Dictionary<ExUIButton,skillBtnInfo> skillBtnDic = new Dictionary<ExUIButton, skillBtnInfo>();

    private const int BasicSpellCount = 6;
    private const int AdvSpellCount = 0;
    private const int ActiveAlpha = 1;
    private const float UnlockAlpha = 89.0f/255.0f;

    private class DetailInfoWin
    {
        private const string Root = "/tween/Right";
        private const string VidioClip = "/tween/Right/VidioBg/Vidio";
        private const string VidioBtn = "/tween/Right/VidioBg/StartButton";
        private const string SpellType = "/tween/Right/SkillTypeSign/TypeText";
        private const string CDTime = "/tween/Right/CoolingTimeSign/TimeText";
        private const string SpellDes = "/tween/Right/SkillDecsSign/DecsText";
        private const string EquipSkillBtn = "/tween/Right/EquipBtn";
        private const string EquipBtnText = "/tween/Right/EquipBtn/Text";

        private GameObject root;
        private VideoPlayer vidioClip;
        private ExUITexture videoTexture;
        private ExUIButton vidioBtn;
        private Text spellType;
        private Text cdTime;
        private Text spellDes;
        private ExUIButton equipSkillBtn;
        private Text equipBtnText;
        private DOTweenAnimation tween;
        private UITweenHelper tweener;

        private RenderTexture renderTexture;
        private float tickTime;
        private PlayerTalentWin win;
        private OwnSpellStruct spellStruct;
        private Vector3 tweenStartValue;
        private Vector3 tweenEndValue;

        public DetailInfoWin(UIPlayerInfoWindow window, PlayerTalentWin win)
        {
            this.win = win;
            root = window.FindTransform(Root).gameObject;
            vidioClip = window.GetComponent<VideoPlayer>(VidioClip);
            videoTexture = window.GetComponent<ExUITexture>(VidioClip);
            vidioBtn = window.GetComponent<ExUIButton>(VidioBtn);
            vidioBtn.onClickEx = (val, o) =>
            {
                vidioBtn.gameObject.SetActive(false);
                vidioClip.Play();
                vidioClip.loopPointReached += source => vidioBtn.gameObject.SetActive(true);
            };
            spellType = window.GetComponent<Text>(SpellType);
            cdTime = window.GetComponent<Text>(CDTime);
            spellDes = window.GetComponent<Text>(SpellDes);
            equipSkillBtn = window.GetComponent<ExUIButton>(EquipSkillBtn);
            equipBtnText = window.GetComponent<Text>(EquipBtnText);
            tween = window.GetComponent<DOTweenAnimation>(Root);
            tweenStartValue = tween.transform.localPosition;
            tweenEndValue = tween.endValueV3;
            tweener = new UITweenHelper(root.transform,tweenEndValue,tween.duration);

            renderTexture = new RenderTexture(512, 512, 0);
            vidioClip.targetTexture = renderTexture;
            videoTexture.texture = renderTexture;
        }

        public void Show(OwnSpellStruct info)
        {
            if (info.Null())
            {
                XLColorDebug.LogUI("不该打开界面   检查逻辑");
                return; 
            }

            win.isSetWinShowing = false;
            if (!tweener.playing && root.transform.localPosition != tweenEndValue)
                tweener.LocalMove(null);

            spellStruct = info;
            spellType.SetTextContent(TalentDataMgr.GetInstance.GetSpellType(info.EffectType));
            VideoClip clip = Resources.Load(info.VideoPath) as VideoClip;
            vidioClip.clip = clip;
            cdTime.SetTextContent(info.Spell.Data.proc.coolDuration);
            spellDes.SetTextContent(info.Description);
            vidioBtn.gameObject.SetActive(true);
            vidioClip.Stop();
            bool canUse, canLearn;
            string name = win._mController.GetEquipBtnName(info, out canUse, out canLearn);
            equipBtnText.SetTextContent(name);
            equipSkillBtn.spriteState = new SpriteState();
            equipSkillBtn.SetCanClick(canUse);
            equipSkillBtn.onClickEx = (val, o) =>
            {
                if (canLearn)
                {
                    var spell = ViSealedDB<OwnSpellStruct>.GetData(win.curSpellId);
                    var floorSpell = TalentDataMgr.GetInstance.GetSpellByFloor(spell.Floor);
                    string learnText = String.Empty;
                    if (floorSpell.Count == 1)
                        learnText = string.Format(win._mWindow.LearnSpellTextOne, spell.Name);
                    if (floorSpell.Count == 2)
                        learnText = string.Format(win._mWindow.LearnSpellTextTwo, floorSpell[0].Name,
                            floorSpell[1].Name,
                            spell.Name);
                    if (floorSpell.Count == 3)
                        learnText = learnText = string.Format(win._mWindow.LearnSpellTextThree, floorSpell[0].Name,
                            floorSpell[1].Name,
                            floorSpell[2].Name, spell.Name);
                    UIManagerUtility.ShowConfirm(learnText,
                        (i, o1) => CellHeroCommandInvoker.AddSpell(CellHero.LocalHero, (uint) win.curSpellId),(a,b)=>{});
                }
                else
                {
                    if (!tweener.playing)
                        tweener.LocalMove(() =>
                        {
                            win.ShowSet(spellStruct);
                        }, false);
                }
            };
        }

        public void Hide()
        {
            tweener.Stop(tweenStartValue);
        }
    }

    private class SetUpWin: UISubWindow<UIPlayerInfoWindow, UIPlayerInfoController>
    {
        private const string Root= "/EquipRight";
        private const string Name= "/EquipRight/SkillNameText";
        private const string Type= "/EquipRight/SkillTypeText";
        private const string Des= "/EquipRight/SkillDescText";
        private const string Lock= "/EquipRight/Skills/SkillEmpty";
        private const string EquipBtn= "/EquipRight/Skills/SkillBack/Back";
        private const string SkillRoot= "/EquipRight/Skills/Skill";
        private const string BackBtn= "/EquipRight/BackBtn";

        private GameObject root;
        private Text name;
        private Text type;
        private Text des;
        private ExUIButton backBtn;
        private SkillItem[] skillArray;
        private DOTweenAnimation tween;
        private UITweenHelper tweener;

        private Dictionary<ExUIButton, SkillItem> gridDic;
        private PlayerTalentWin win;
        private OwnSpellStruct spellStruct;
        private Vector3 tweenStartValue;
        private Vector3 tweenEndValue;

        public SetUpWin(UIPlayerInfoWindow window,PlayerTalentWin dWin)
        {
            win = dWin;
        }
        public new void Initial(UIPlayerInfoWindow window, string topPath)
        {
            base.Initial(window, topPath);
            
            root = FindTransform(Root).gameObject;
            name = GetComponent<Text>(Name);
            type = GetComponent<Text>(Type);
            des = GetComponent<Text>(Des);
            backBtn = GetComponent<ExUIButton>(BackBtn);
            backBtn.onClickEx = (val, o) =>
            {
                if(!tweener.playing)
                tweener.LocalMove(() =>
                {
                    win.ShowDetail(spellStruct);
                }, false);
            };
            tween = GetComponent<DOTweenAnimation>(Root);
            tweenStartValue = tween.transform.localPosition;
            tweenEndValue = tween.endValueV3;
            tweener = new UITweenHelper(root.transform, tweenEndValue, tween.duration);

            skillArray = new SkillItem[SkillCount];
            gridDic = new Dictionary<ExUIButton, SkillItem>(5);

            for (int i = 0; i < SkillCount; i++)
            {
                ExUIButton lockO =GetComponent<ExUIButton>(Lock + (i + 1));
                GameObject selectO = FindTransform(SkillRoot + (i + 1) + "/CD").gameObject;
                ExCircleSprite icon = GetComponent<ExCircleSprite>(SkillRoot + (i + 1));
                SkillItem item = new SkillItem(icon, lockO, selectO, i);
                skillArray[i] = item;
                ExUIButton btn = GetComponent<ExUIButton>(EquipBtn + (i + 1));
                btn.onClickEx = (val, o) =>
                {
                    ExUIButton uibtn = o as ExUIButton;
                    SkillItem sItem;
                    if (gridDic.TryGetValue(uibtn, out sItem))
                    {
                        if (sItem.id.InValid())
                            CellHeroCommandInvoker.SetupSpell(CellHero.LocalHero, (uint)win.curSpellId,
                                (ushort)sItem.index);
                        else
                            CellHeroCommandInvoker.SwapSpell(CellHero.LocalHero, (uint)win.curSpellId,
                                (uint)sItem.id);
                    }
                };
                gridDic.Add(btn, item);
            }
        }
        public void Show(OwnSpellStruct curSpell)
        {
            win.isSetWinShowing = true;
            if (!tweener.playing)
                tweener.LocalMove(null);

            spellStruct = curSpell;
            name.SetTextContent(curSpell.Name);
            type.SetTextContent(TalentDataMgr.GetInstance.GetSpellType(curSpell.EffectType));
            des.SetTextContent(curSpell.Description);
            for (int i = 0; i < skillArray.Length; i++)
            {
                bool equiped = false;
                var spell = TalentDataMgr.GetInstance.GetEquipSpellByIndex(i);
                if (spell.NotNull())
                {
                    equiped = true;
                    skillArray[i].Refresh(IconDataManager.GetIcon(spell.Icon), TalentDataMgr.GetInstance.SpellGridLock(i),
                        spell.ID == win.curSpellId, spell.ID);
                }
                if (!equiped)
                {
                    skillArray[i].Refresh(null, TalentDataMgr.GetInstance.SpellGridLock(i),
                        false, 0);
                }
            }
        }

        public override void Hide()
        {
            tweener.Stop(tweenStartValue);
        }

        public override  void Refresh()
        {
            
        }
        private const int SkillCount = 5;
    }

    private class SkillItem
    {
        private ExCircleSprite icon;
        private ExUIButton lockIcon;
        private GameObject selectObj;
        public int id { get; private set; }
        public readonly int index;
        public SkillItem(ExCircleSprite icon, ExUIButton lockIcon,GameObject selectObj,int index)
        {
            this.icon = icon;
            this.lockIcon = lockIcon;
            this.selectObj = selectObj;
            this.index = index;
            this.lockIcon.onClickEx = (val, o) => { UIManagerUtility.ShowHint(TalentDataMgr.GetInstance.GetSpellLockTips(this.index)); };
        }

        public void Refresh(IconData data,bool locked,bool selected,int id)
        {
            if (data.Null()|| locked)
                icon.gameObject.SetActive(false);
            else
            {
                icon.gameObject.SetActive(true);
                UIUtility.SetSprite(icon, data);
            }
            lockIcon.SetActive(locked);
            selectObj.SetActive(selected);
            this.id = id;
        }
    }
}