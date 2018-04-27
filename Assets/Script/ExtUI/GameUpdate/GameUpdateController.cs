using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameUpdateController
{
	public static readonly string WIN_RES = "UIGameUpdateRoot";
	public static readonly string LOAD_PATH = "uiresource/uiprefabs";

	public static GameUpdateController Instance { get { return _instance; } }
	static GameUpdateController _instance = new GameUpdateController();

	public UIGameUpdateWindow Script { get { return _winScript; } }

	public void Start()
	{
		_winRoot = GameObject.Find(WIN_RES);
		if (_winRoot != null)
		{
			_uiRoot = _winRoot.GetComponent<UIRoot>();
			_winScript = _winRoot.GetComponent<UIGameUpdateWindow>();
			_winScript.OnOKCallback = this.OnOkCallback;
			_winScript.OnCancelCallback = this.OnCancelCallback;
		}
	}

	public void Open()
	{
		//Script.ResizeBG(_uiRoot);
		Script.SetConfirmVisible(false);
		Script.SetLoadingVisible(false);
	}

	public void Close()
	{
		if (_winRoot != null)
		{
			_winRoot.SetActive(false);
		}
	}

	void OnOkCallback()
	{
		ViDelegateAssisstant.Invoke(_rightCallback);
	}

	void OnCancelCallback()
	{
		ViDelegateAssisstant.Invoke(_leftCallback);
	}

	public void SetLeftCallback(string desc, ViDelegateAssisstant.Dele callback)
	{
		_leftCallback = callback;
		Script.SetCancelButtonText(desc);
	}

	public void SetRightCallback(string desc, ViDelegateAssisstant.Dele callback)
	{
		_rightCallback = callback;
		Script.SetOKButtonText(desc);
	}

	public void SetConfirmMessage(string contentSize, string netState)
	{
		_loadContentSize = contentSize;
		_netState = netState;
		//
		Script.SetLoadContent(_loadContentSize);
		Script.SetNetState(_netState);
	}

	public void SetConfirmVisible(bool value)
	{
		Script.SetConfirmVisible(value);
	}

	public void SetLoadingVisible(bool value)
	{
		Script.SetLoadingVisible(value);
	}

	public void SetLoadingDesc(string text)
	{
		Script.SetLoadingState(text);
	}

	public void UpdateLoading(Int32 current, Int32 max)
	{
		float progress = ((float)current) / Math.Max(max, 1);
		Script.SetLoadingPercent(progress, current + "/" + max);
	}

	public void Destroy()
	{
		UnityAssisstant.Destroy(ref _winRoot);
	}

	UIRoot _uiRoot = null;
	GameObject _winRoot = null;
	UIGameUpdateWindow _winScript;
	//
	string _loadContentSize = string.Empty;
	string _netState = string.Empty;
	//
	ViDelegateAssisstant.Dele _leftCallback;
	ViDelegateAssisstant.Dele _rightCallback;
}
