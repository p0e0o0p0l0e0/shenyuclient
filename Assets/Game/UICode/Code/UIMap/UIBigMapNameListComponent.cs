using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIBigMapNameListComponent : UIWindowComponent<UIMiniMapWindow, UIMiniMapController> {
    #region ui control name define
    private const string RootName = "Type";
    private const string MonsterBtn = "/Type/MonsterBtn";
    private const string NameList = "/Type/NameList";
    private const string NameToList1 = "NameList1";
    private const string NameList1 = "/Type/" + NameToList1;
    private const string MonsterItemPath = NameList + "/Content/";
    private const string NpcItemPath = NameList1 + "/Content/";
    private const string TextPath = "/Text";
    private const string NpcBtn = "/Type/NPCBtn";
    private const string NameItem = "/Type/NameList/Content/NameBtn1";
	#endregion
	enum LabelIndex
	{
		Monster = 0,
		Npc = 1,
		Postion = 2,
		Collect = 3
	}

	private ExUIButton[] _labelButtons;
    private ExUIButton _monsterBtn;
    private ExUIButton _npcBtn;
    private ExUIButton _nameItem;
    private LoopVerticalScrollRect _nameList;
    private LoopVerticalScrollRect _npcNameList;
	private UILabelScrollComponent[]_scrollComponent;
	struct NpcItem
    {
        public Int32 id;
        public TargetEnum targetType;
    }
	
    public override void Initial(UIMiniMapWindow window, string topPath)
    {
        base.Initial(window, topPath);
		UIGoManager.Instance.Load("UIBigMapNameListComponent", (string name, object obj1) => _OnNameListLoaded(name, obj1)); 
    }
	private Transform _listRoot;
    private void _OnNameListLoaded(string name, object obj1)
    {
        if (this._mWindow == null || !this._mWindow.IsResAvaliable()) return;//放置资源异步加载回来后界面已经被删除了
		if (obj1 != null)
        {
			GameObject go = obj1 as GameObject;
            RectTransform rt = go.GetComponent<RectTransform>();
			_listRoot = go.transform;

			if (rt != null)
            {
                Vector3 pos = new Vector3(rt.anchoredPosition3D.x, rt.anchoredPosition3D.y, rt.anchoredPosition3D.z);
                Vector3 scale = new Vector3(rt.localScale.x, rt.localScale.y, rt.localScale.z);
                rt.SetParent(_rootTran); 
                rt.anchoredPosition3D = pos;
                rt.localScale = scale;
                go.name = RootName;

				_labelButtons = new ExUIButton[go.transform.childCount - 1];
				_scrollComponent = new UILabelScrollComponent[_labelButtons.Length];
				_nameList = this.GetComponent<LoopVerticalScrollRect>(NameList);
				for (int i = 0; i < _nameList.transform.GetChild(0).childCount; i++)
				{
					_nameList.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
				}

				#region 调整按钮次序，添加list
				for (int i = 0, index = 0; i < go.transform.childCount; i ++)
				{
					Transform t = go.transform.GetChild(i);
					ExUIButton exUIButton = t.GetComponent<ExUIButton>();
					if (exUIButton != null)
					{
						exUIButton.Id = index;
						exUIButton.onClickEx = OnLabelBtnClick;
						_scrollComponent[index] = new UILabelScrollComponent();
						_scrollComponent[index].Initial(_mWindow, _topPath + "/" + RootName + "/" +  exUIButton.gameObject.name);
						_labelButtons[index ++] = exUIButton;
					}	
				}

				InitList();    // ↑ 上面初始化 UILabelScrollComponent    

				_nameList.Init(null, 1);
				#endregion
				
			}

        }
	}
	public void ShowList(int index)
	{
		_nameList.transform.SetParent(null);
		_nameList.transform.SetActive<Transform>(false);
		for (int i = _labelButtons.Length - 1; i > index; i--)
		{
			_labelButtons[i].transform.SetParent(null);
		}
		_nameList.transform.SetParent(_listRoot);
		for (int i = index + 1; i < _labelButtons.Length; i++)
		{
			_labelButtons[i].transform.SetParent(_listRoot);
		}
		_scrollComponent[index].SetLabelAndScroll(_nameList, index == (int)LabelIndex.Monster);
	}
	private int _selectLabel = -1;
    private void OnLabelBtnClick(int val, object obj)
    {
		if(_selectLabel == val)
		{
			_nameList.gameObject.SetActive(!_nameList.gameObject.activeSelf);
		}
		else
		{
			ShowList(val);
		}
		_selectLabel = val;
	}

    private void InitList()
    {
        ViForeignGroup<NPCBirthPositionStruct> npcPoints = GameSpace.ActiveInstance.LogicInfo.FreeNPCBirthList;
        if (npcPoints != null)
        {
            List<NPCBirthPositionStruct> pointList = npcPoints.List;
            for (int i = 0; i < pointList.Count; ++i)
            {
                NPCBirthPositionStruct point = pointList[i];
                EntityCategory entityCate = (EntityCategory)point.NPC.Data.DataEx.Data.entityCategory.Value;
                if (entityCate == EntityCategory.BOSS_VILLAIN || entityCate == EntityCategory.NORMAL_VILLAIN)
                {
					_scrollComponent[(int)LabelIndex.Monster].InitList(point);
                }
                else if(entityCate == EntityCategory.NORMAL_NPC && point.AutoLoad.IsTrue())
                {
					_scrollComponent[(int)LabelIndex.Npc].InitList(point);
				}
            }
        }
    }

    public override void Dispose()
    {
        if(_labelButtons!= null && _scrollComponent != null)
		    for (int i = 0; i < _labelButtons.Length; i ++)
		    {
                _labelButtons[i].onClickEx = null;
                _labelButtons[i].RemoveButtonAllListener();
			    _labelButtons[i] = null;
			    _scrollComponent[i].Dispose();
			    _scrollComponent[i] = null;
		    }
		_labelButtons = null;
		_scrollComponent = null;
        UIGoManager.Instance.UnLoad("UIBigMapNameListComponent");
    }

	

}
