using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;

// Streaming2Persistent >> APKUpdate >> Web2Persistent
public class UpdatorScript : MonoBehaviour
{
	public static string ShowMessage { get { return _showMessage; } }
	static string _showMessage = string.Empty;

	public string WebRoot = "http://192.168.100.71:8080/Fate/";
	public Int32 SizeScale = 1024;
	public bool UsePresistentPath;
	public bool UsePublishSDK;
	public bool PrintSystem;
	public bool UpdateRes;
	public bool UpdateMsg;
	public bool SealedDataEditor;

    public bool UpdateSeverList;

    public bool OnlyLoadHead { get { return _onlyLoadHead; } }

	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		ApplicationPlatform.SetWebRoot(WebRoot);
		//GameUpdateController.Instance.Start();
		//
		if (UpdateMsg)
		{
			//_updateMessage.Start(ApplicationPlatform.WWWURL + "UpdateMessage.ini", this.UpdateMessage);
		}

        if (UpdateSeverList)
        {
            if (File.Exists(UILoginWindow.SeverListLocalPath + UILoginWindow.SeverListName))
            {
                File.Delete(UILoginWindow.SeverListLocalPath + UILoginWindow.SeverListName);
            }
            StartCoroutine(LoadSeverList());
        }
       
		if (UpdateRes)
		{
			StartUpdateRes();
		}
		else
		{
			OnLoadComplete();
		}
	}

	void StartUpdateRes()
	{
		_onlyLoadHead = true;
		_webFailCount = 0;
        //GameUpdateController.Instance.Open();
        //GameUpdateController.Instance.SetConfirmVisible(false);
        //GameUpdateController.Instance.SetLoadingDesc("本地数据优化...");
        Streaming2Persistent();
	}

	void Update()
	{
		UpdateWork();
        //
        //GameUpdateController.Instance.UpdateLoading(_workingSize / SizeScale, _totalSize / SizeScale);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //GameUpdateController.Instance.SetConfirmMessage("是否退出游戏", "");
            //GameUpdateController.Instance.SetConfirmVisible(true);
            //GameUpdateController.Instance.SetLeftCallback("退出", this.ClickExit);
            //GameUpdateController.Instance.SetRightCallback("取消", this.ClickCancel);
        }
    }

	void ReadPersistent()
	{
		Debug.Log("UpdatorScript.ReadPersistent");
		//
		List<string> fileList = new List<string>();
		IOAssisstant.SelectPresistentFiles("", "*", SearchOption.AllDirectories, fileList);
		for (int iter = 0; iter < fileList.Count; ++iter)
		{
			string iterFile = fileList[iter];
			Debug.Log(iterFile);
		}
		Debug.Log("SelectFiles.Count = " + fileList.Count);
	}

	void ClearPersistent()
	{
		Debug.Log("UpdatorScript.ClearPersistent");
		//
		IOAssisstant.DelPresistentFile(IOAssisstant.DataVersionFullFile);
		IOAssisstant.DelPresistentPath(UnityAssisstant.GROUP_PRO);
		IOAssisstant.DelPresistentPath(UnityAssisstant.GROUP_RES);
		IOAssisstant.DelPresistentPath(UnityAssisstant.GROUP_VIB);
		IOAssisstant.DelPresistentPath("APK");
	}

	void StartLoadProgress(PersistentWriter writer, Int32 size, bool loadFull)
	{
		_totalSize = size;
		_workingSize = 0;
        //if (size > 0 && loadFull)
        //{
        //    GameUpdateController.Instance.SetLoadingVisible(true);
        //}
        //else
        //{
        //    GameUpdateController.Instance.SetLoadingVisible(false);
        //}
    }

	void Streaming2Persistent()
	{
		Debug.Log("UpdatorScript.Streaming2Persistent");
		//
		AssetBundlePersistentWriter writeRes = new AssetBundlePersistentWriter();
		writeRes.Start(ApplicationPlatform.StreamingDataURL, false);
		_workingWriter = writeRes;
		ActiveWork(writeRes, this.OnCompleted_Streaming2Persistent, this.StartLoadProgress);
	}

	void Web2Persistent()
	{
		Debug.Log("UpdatorScript.Web2Persistent");
		//
		AssetBundlePersistentWriter writeRes = new AssetBundlePersistentWriter();
		writeRes.Start(ApplicationPlatform.WWWStreamingDataURL, OnlyLoadHead);
		ActiveWork(writeRes, this.OnCompleted_Web2Persistent, this.StartLoadProgress);
	}

	void UpdateWebAPK2Persistent()
	{
		Debug.Log("UpdatorScript.UpdateWebAPK2Persistent");
		//
		APKPersistentWriter writeRes = new APKPersistentWriter();
		writeRes.Start(ApplicationPlatform.WWWURL, OnlyLoadHead);
		ActiveWork(writeRes, this.OnCompleted_WebAPKUpdate, this.StartLoadProgress);
	}

	void OnCompleted_WebAPKUpdate(PersistentWriter writer)
	{
		Debug.Log("UpdatorScript.OnCompleted_APKUpdate");
		//
		_apkUpdateSize = writer.TotalSize;
		_webFailCount += writer.FailCount;
		//
		Web2Persistent();
	}

	void OnCompleted_Web2Persistent(PersistentWriter writer)
	{
		Debug.Log("UpdatorScript.OnCompleted_Web2Persistent");
		//
		_resUpdateSize = writer.TotalSize;
		_webFailCount += writer.FailCount;
		//
		if (_webFailCount > 0)
		{
            //GameUpdateController.Instance.SetConfirmMessage("网络信号出错, 请再次重试", "当前网络为: " + ApplicationPlatform.NetDesc);
            //GameUpdateController.Instance.SetConfirmVisible(true);
            //GameUpdateController.Instance.SetLeftCallback("退出", this.ClickExit);
            //GameUpdateController.Instance.SetRightCallback("重试", this.ClickRetry);
        }
		else
		{
			Int32 totalSize = _apkUpdateSize + _resUpdateSize;
			if (_onlyLoadHead && totalSize > 0)
			{
				OnReadHeadComplete();
			}
			else
			{
				OnLoadComplete();
			}
		}
	}

	void OnCompleted_Streaming2Persistent(PersistentWriter writer)
	{
		Debug.Log("UpdatorScript.OnCompleted_Streaming2Persistent");
		//
		UpdateWebAPK2Persistent();
	}

	void OnReadHeadComplete()
	{
		Debug.Log("OnReadHeadComplete(APKUpdateSize=" + _apkUpdateSize + ", ResUpdateSize=" + _resUpdateSize + ", TotalSize+" + (_apkUpdateSize + _resUpdateSize) + ", WebFailCount=" + _webFailCount + ")");
        //
        //GameUpdateController.Instance.SetConfirmMessage("下载大小=" + (_apkUpdateSize + _resUpdateSize) / SizeScale + "K", "当前网络为: " + ApplicationPlatform.NetDesc);
        //GameUpdateController.Instance.SetConfirmVisible(true);
        //GameUpdateController.Instance.SetLeftCallback("退出", this.ClickExit);
        //GameUpdateController.Instance.SetRightCallback("继续", this.ClickContinue);
    }

	void OnLoadComplete()
	{
		if (ApplicationPlatform.VersionUpThan(IOAssisstant.LocalVersion(Application.version), Application.version) && UpdateRes)
		{
            //GameUpdateController.Instance.SetConfirmMessage("本次更新需要执行快速安装", "请确认安装");
            //GameUpdateController.Instance.SetConfirmVisible(true);
            //GameUpdateController.Instance.SetLeftCallback("退出", this.ClickExit);
            //GameUpdateController.Instance.SetRightCallback("安装", this.ClickInstall);
        }
		else
		{
			//GameUpdateController.Instance.Close();
			enabled = false;// 关闭自己
#if SCRIPT_DLL
		GameObject root = GameObject.Find("DLLStartScript");
		DLLStartScript script = root.AddComponent<DLLStartScript>();
		script.UsePresistentPath = UsePresistentPath;
		script.UsePublishSDK = UsePublishSDK;
		script.PrintSystem = PrintSystem;
		script.SealedDataEditor = SealedDataEditor;
#else
			GameObject root = GameObject.Find("Game");
			MainScript script = root.AddComponent<MainScript>();
			script.UsePresistentPath = UsePresistentPath;
			script.UsePublishSDK = UsePublishSDK;
			script.PrintSystem = PrintSystem;
			script.SealedDataEditor = SealedDataEditor;
#endif
        }
	}

	void UpdateWork()
	{
		if (_workingWriter != null)
		{
			_workingWriter.TickLoad(ref _workingSize);
			if (!_workingWriter.IsWorking)
			{
				_workingWriter = null;
			}
		}
		//if (_updateMessage != null)
		//{
		//	_updateMessage.TickLoad();
		//	if (!_updateMessage.IsWorking)
		//	{
		//		_updateMessage = null;
		//	}
		//}
	}

	void ActiveWork(PersistentWriter writer, ViDelegateAssisstant.Dele<PersistentWriter> completeCallback, ViDelegateAssisstant.Dele<PersistentWriter, Int32, bool> headCallback)
	{
		_workingWriter = writer;
		_workingWriter.CompleteCallback = completeCallback;
		_workingWriter.HeadCallback = headCallback;
	}

	public void UpdateMessage(string txt)
	{
		_showMessage = txt;
		if (txt != null)
		{
			Debug.Log("UpdateMessage: " + txt);
		}
		else
		{
			ViDebuger.Warning("UpdateMessage Fail!");
		}
	}

	public void ClickContinue()
	{
		Debug.Log("Update.ClickContinue");
		//
		_onlyLoadHead = false;
        //GameUpdateController.Instance.SetConfirmVisible(false);
        //GameUpdateController.Instance.SetLoadingDesc("数据更新...");
        UpdateWebAPK2Persistent();
	}

	public void ClickCancel()
	{
		Debug.Log("Updator.ClickCancel");
		//
		//GameUpdateController.Instance.SetConfirmVisible(false);
	}

	public void ClickExit()
	{
		Debug.Log("Updator.ClickExit");
		//
		if (!Application.isEditor)
		{
			Application.Quit();
		}
	}

	public void ClickRetry()
	{
		Debug.Log("Updator.ClickRetry");
		//
		//GameUpdateController.Instance.SetConfirmVisible(false);
		//
		StartUpdateRes();
	}

	public void ClickInstall()
	{
		Debug.Log("Updator.ClickInstall");
		//
		//if (MtlibSDK.IsCanWrite())
		//{
		//    MtlibSDK.InstallAPK(ApplicationPlatform.PersistentDataPath + IOAssisstant.APKFile);
		//}
		//else
		{
			Application.OpenURL(ApplicationPlatform.WWWURL + IOAssisstant.APKFile);
		}
	}

    /// <summary>
    /// 加载服务器列表
    /// </summary>
    /// <returns></returns>
     private IEnumerator LoadSeverList()
    {
        WWW obj = new WWW(UILoginWindow.SeverListSeverPath);
        yield return obj;
        if (obj.error == null&&obj.isDone)
        {
            File.WriteAllBytes(UILoginWindow.SeverListLocalPath + UILoginWindow.SeverListName, obj.bytes);
            obj.Dispose();
        }
    }
    
	PersistentWriter _workingWriter;
	bool _onlyLoadHead;
	Int32 _apkUpdateSize;
	Int32 _resUpdateSize;
	//
	Int32 _totalSize;
	Int32 _workingSize;
	//
	Int32 _webFailCount;
}