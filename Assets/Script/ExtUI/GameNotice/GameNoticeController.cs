using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameNoticeController
{
	public static readonly string WIN_RES = "UIGameNoticeRoot";
	public static readonly string LOAD_PATH = "uiresource/uiprefabs";

	public static GameNoticeController Instance { get { return _instance; } }
	static GameNoticeController _instance = new GameNoticeController();

	public void Open()
	{
		_winRoot = GameObject.Find(WIN_RES);
		if (_winRoot != null)
		{
			UIGameNoticeWindow winScript = _winRoot.GetComponent<UIGameNoticeWindow>();
			_UpdateNotice(winScript);
		}
		else
		{
            mResLoader.Start(LOAD_PATH + "/" + WIN_RES, WIN_RES, _OnResourceLoaded);
		}
	}

	void _OnResourceLoaded(UnityEngine.Object pAsset)
	{
		_winRoot = UnityAssisstant.Instantiate(pAsset as GameObject);
		//
		UIGameNoticeWindow winScript = _winRoot.GetComponent<UIGameNoticeWindow>();
		winScript.OnCloseCallback = this.Close;
		_UpdateNotice(winScript);
	}

	void _UpdateNotice(UIGameNoticeWindow winScript)
	{
		string[] elementList = UpdatorScript.ShowMessage.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
		for (int iter = 0; iter < elementList.Length; ++iter)
		{
			string iterElement = elementList[iter];
			string iterTitle = StandardAssisstant.GetStrValue(iterElement, "Title=");
			string iterDesc = StandardAssisstant.GetStrValue(iterElement, "Desc=");
			string iterDate = StandardAssisstant.GetStrValue(iterElement, "Date=");
			string iterState = StandardAssisstant.GetStrValue(iterElement, "State=");
			winScript.AddNotice(iter, iterDate, iterTitle, iterDesc);
		}
		winScript.ResizeNotices(elementList.Length);
	}

	void Close()
	{
		_winRoot.SetActive(false);
	}

	public void Destroy()
	{
		UnityAssisstant.Destroy(ref _winRoot);
        mResLoader.End();
    }

	GameObject _winRoot = null;
    ResourceRequest mResLoader = new ResourceRequest();
}
