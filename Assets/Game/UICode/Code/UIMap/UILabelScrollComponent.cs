using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
class UILabelScrollComponent : UIWindowComponent<UIMiniMapWindow, UIMiniMapController>
{
	#region ui control name define
	private const string TextPath = "Text";
	#endregion
	private LoopVerticalScrollRect lrect;
	private bool isSpecShow;
	private List<NPCBirthPositionStruct> _dataList = new List<NPCBirthPositionStruct>();
	private Dictionary<string, Transform> _listTrans = new Dictionary<string, Transform>();
	public void InitList(NPCBirthPositionStruct point)
	{
		_dataList.Add(point);
	}
	public void SetLabelAndScroll(LoopVerticalScrollRect scroll, bool specShowText)
	{
		lrect = scroll;
		isSpecShow = specShowText;
		SetGridLayoutHeight();//
	}
	const int showLines = 4;
	private void SetGridLayoutHeight()
	{
		_listTrans.Clear();
		foreach (Transform t in lrect.transform.GetChild(0))
		{
			_listTrans[t.name] = t;
		}
	    int count = _dataList.Count == 0 ? 1 : _dataList.Count;
		lrect.OnRefresh = _LoopRefreshNpc;
		lrect.ChangeTotalCount(count);
		//lrectRefillAllCells();
		lrect.RefillCells();
		//lrect.SetCanDrag(count > 4);
		RectTransform rt = lrect.GetComponent<RectTransform>();
		RectTransform rtcon = lrect.transform.GetChild(0).GetComponent<RectTransform>();
		GridLayoutGroup glg = rtcon.GetComponent<GridLayoutGroup>();
		if (count <= showLines && count > 0)
		{
			rt.sizeDelta = new Vector2(rt.rect.width, glg.cellSize.y * count + (count - 1) * glg.spacing.y);
			lrect.vertical = false;
		}
		else
		{
			rt.sizeDelta = new Vector2(rt.rect.width, glg.cellSize.y * (showLines + 0.5f) + (showLines * glg.spacing.y));
			lrect.vertical = true;
		}
		lrect.gameObject.SetActive(true);
	}
	private Transform FindListNode(string path)
	{
		if (_listTrans.ContainsKey(path))
		{
			return _listTrans[path];
		}
		else
		{
			Transform t = lrect.transform.GetChild(0).Find(path);
			if (t != null)
			{
				_listTrans[path] = t;
				return t;
			}
			ViDebuger.Record("UILabelScrollCompnet : Not find Transform node Path" + path);	
			return null;
		}
		
		
	}
	private void _LoopRefreshNpc(string path, int id)
	{
		Transform tran = FindListNode(path);
		if (tran != null)
		{
			ExText text = tran.GetComponentInChildren<ExText>();
			if (_dataList.Count == 0 && id == 0)
				text.text = I18NManager.Instance.GetWord("tips_71"); //"空";
			else
			{
				if (id < _dataList.Count)
				{
					if (isSpecShow)
						text.text = _dataList[id].NPC.Data.DataEx.Data.Name + I18NManager.Instance.GetWord("tips_72")/*"【"*/ + _dataList[id].NPC.Data.Level + I18NManager.Instance.GetWord("tips_73")/*"级】"*/;
					else
						text.text = _dataList[id].NPC.Data.DataEx.Data.Name;
					ExUIButton itemBtn = tran.GetComponent<ExUIButton>();
					if (itemBtn.onClickEx == null)
						itemBtn.onClickEx = _OnItemClick;
					itemBtn.Id = id;
				}

			}
		}


	}
	private void _OnItemClick(int val, object obj)
	{
		if (val < _dataList.Count)
		{
			EventDispatcher.TriggerEvent<UInt64, TargetEnum>(Events.SceneCommonEvent.OnNavTo,
				(UInt64)_dataList[val].ID, (TargetEnum)_dataList[val].NPC.Data.DataEx.Data.entityCategory.Value);
		}
	}
	public override void Dispose()
	{
		_listTrans.Clear();
		_dataList.Clear();
		_dataList = null;
		lrect = null;
	}
	public void SetActive(bool isTrue)
	{
		lrect.gameObject.SetActive(isTrue);
	}
	public bool IsActive()
	{
		return lrect.gameObject.activeSelf;
	}
}
