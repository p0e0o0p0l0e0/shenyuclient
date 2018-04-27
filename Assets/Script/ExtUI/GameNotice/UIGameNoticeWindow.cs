using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIGameNoticeWindow : MonoBehaviour
{

	public delegate void ClickDele();
	public ClickDele OnCloseCallback;

	public UITable NoticeListTable;
	public GameObject NoticeTemp;

	public void Initialize()
	{
		NoticeTemp.SetActive(false);
	}

	public void AddNotice(int index, string date, string name, string text)
	{
		GameObject obj;
		if (index >= _noticeList.Count)
		{
			obj = UnityAssisstant.InstantiateAsChild(NoticeTemp, NoticeListTable.transform);
			_noticeList.Add(obj);
		}
		else
		{
			obj = _noticeList[index];
			obj.SetActive(true);
		}
		//
		UILabel label = obj.GetChild("Name/Label").GetComponent<UILabel>();
		label.text = name;
		label = obj.GetChild("Date").GetComponent<UILabel>();
		label.text = date;
		label = obj.GetChild("Tween/Text").GetComponent<UILabel>();
		label.text = text;
		//
		UIEventListener listenter = UIEventListener.Get(obj);
		listenter.onClick = this.OnClickNoticeMsg;
	}

	public void ResizeNotices(int count)
	{
		for (int iter = count; iter < _noticeList.Count; ++iter)
		{
			_noticeList[iter].SetActive(false);
		}
		NoticeListTable.repositionNow = true;
	}

	void OnClickNoticeMsg(GameObject obj)
	{
		GameObject arrowObj = obj.GetChild("Arrow");
		TweenRotation tweener1 = arrowObj.GetComponent<TweenRotation>();
		tweener1.Toggle();
		//GameObject textObj = obj.GetChild("Tween");
		//TweenScale tweener2 = textObj.GetComponent<TweenScale>();
		//tweener2.Toggle();
	}

	public void OnCloseMsg()
	{
		if (OnCloseCallback != null)
		{
			OnCloseCallback();
		}
	}


	List<GameObject> _noticeList = new List<GameObject>();

}
