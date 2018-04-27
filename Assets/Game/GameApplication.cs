using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameApplication
{
	public static GameApplication Instance { get { return _instance; } }
	static GameApplication _instance = new GameApplication();

	public static ViConstValue<Int32> VALUE_LogLevel = new ViConstValue<Int32>("LogLevel", (Int32)ViLogLevel.CRIT_OK);
	public static ViConstValue<bool> VALUE_DebugWin = new ViConstValue<bool>("DebugWin", true);
	public static ViConstValue<Int32> VALUE_DayExpireHour = new ViConstValue<Int32>("DayExpireHour", 5);
	public static ViConstValue<Int32> VALUE_TimerRollSize = new ViConstValue<Int32>("TimerRollSize", 300);
	public static ViConstValue<Int32> VALUE_TimerSpan = new ViConstValue<Int32>("TimerSpan", 1);
	public static ViConstValue<Int32> VALUE_ClientPingSpan = new ViConstValue<Int32>("ClientPingSpan", 100);
	public static ViConstValue<Int32> VALUE_FrameRate = new ViConstValue<Int32>("FrameRate", 60);

	public Client Client { get { return _client; } }
	public float FPS { get { return _FPSCountor.Value; } }
	public MusicManager MusicManager { get { return _musicManager; } }
	public AudioListenerManager AudioListener { get { return _audioListener; } }
	public ViDelegateAssisstant.Dele DataCompleteCallback;
	public bool UsePublishSDK;
	public GameDataManager DataManager { get { return _dataManager; } }

    public Action OnDataCompleted = null;

    public bool IsEditor
    {
        get
        {
            return SceneManager.GetActiveScene().name != "Pro";
        }
    }
    public void Start()
	{
		ViRandom.Seed = (UInt32)DateTime.Now.Ticks;
		//
		ViTimerVisualInstance.Start(0, 0, (UInt32)VALUE_TimerSpan.Value, (UInt32)VALUE_TimerRollSize.Value, (UInt32)VALUE_TimerRollSize.Value);
		ViTimerRealInstance.Start(0, 0, (UInt32)VALUE_TimerSpan.Value, (UInt32)VALUE_TimerRollSize.Value, (UInt32)VALUE_TimerRollSize.Value);
		//
		ViSerializer.Start();
		ViStringSerialize.Start();
		ViSerializer<ViVector3>.AppendExec = ViVector3Serialize.Append;
		ViSerializer<ViVector3>.ReadExec = ViVector3Serialize.Read;
		ViSerializer<ViVector3>.ReadStringExec = ViVector3Serialize.Read;
		ViSerializer<ViVector3>.AppendDictionaryStringExec = ViVector3Serialize.Append;
		ViSerializer<ViVector3>.ReadDictionaryStringExec = ViVector3Serialize.Read;
		ViStringSerializer<ViVector3>.PrintToExec = ViVector3Serialize.PrintTo;
		ViStringSerializer<ViVector3>.PrintToBuilderExec = ViVector3Serialize.PrintTo;
		ViStringSerializer<ViVector3>.ReadExec = ViVector3Serialize.Read;
		//
		ViGameLogicNormalDataEx.Start();
		ViGameLogicScript.Start();
		//
		ProjectANormalDataEx.Start();
		ProjectAScript.Start();
		//
		EntityRelationChecker.Start();
		DurationVisualEx.Start();
		//
		UnityComponentCreator.Register<AnimationControllerEx>();
		//
		Client.Start();

    }

	public void End()
	{
		Client.End();
		//
		ViExpressInterface.ClearAllExpress();
		//RoleHintInterface.EndAll();
		GameObjectPath.Instance.End();
		//
		UnityEngine.Application.logMessageReceived -= this.OnUnityLog;
		ViAsynExecer.ClearAll();
		//ResourceManagerInstance.Instance.FreeUseless(true);
		ViExpressInterface.ClearAllExpress();
		ViAsynCallback.Clear();
		ViFramEndCallbackInterface.Clear();
		MusicManager.End();
		AudioListener.End();
	}

	public void InitLog()
	{
		UnityEngine.Application.logMessageReceived += this.OnUnityLog;
		ViDebuger.LogLevel = (ViLogLevel)VALUE_LogLevel.Value;
		ViDebuger.ErrorCallback = this.OnAssertErrorCallback;
		ViDebuger.WarningCallback = this.OnAssertWarningCallback;
		ViDebuger.RecordCallback = this.OnRecordCallback;
		ViDebuger.CritOKCallback = this.OnCritOKCallback;
		ViDebuger.NoteCallback = this.OnNoteCallback;
		ViLogEx.PrintStringCallback = this.OnPrintStringCallbackByViLog;
		ViLogEx.PrintValueCallback = this.OnPrintValueCallbackByViLog;
	}

	public void ResetLogProcess()
	{
		ViDebuger.LogLevel = (ViLogLevel)VALUE_LogLevel.Value;
		ViDebuger.ErrorCallback = this.OnAssertErrorCallback;
		ViDebuger.WarningCallback = this.OnAssertWarningCallback;
		ViDebuger.RecordCallback = this.OnRecordCallback;
		ViDebuger.CritOKCallback = this.OnCritOKCallback;
		ViDebuger.NoteCallback = this.OnNoteCallback;
		ViLogEx.PrintStringCallback = this.OnPrintStringCallbackByViLog;
		ViLogEx.PrintValueCallback = this.OnPrintValueCallbackByViLog;
	}

	public void ClearLogProcess()
	{
		ViDebuger.LogLevel = (ViLogLevel)VALUE_LogLevel.Value;
		ViDebuger.ErrorCallback = null;
		ViDebuger.WarningCallback = null;
		ViDebuger.RecordCallback = null;
		ViDebuger.CritOKCallback = null;
		ViDebuger.NoteCallback = null;
		ViLogEx.PrintStringCallback = null;
		ViLogEx.PrintValueCallback = null;
	}

	public void Update0()
	{
		GameTimeScale.Update();
		float deltaTime = GameTimeScale.LogicDeltaTime;
		//
		_FPSCountor.Update(deltaTime);
		//
		Client.Current = Client;
		Client.Update0(deltaTime);
		//
		MusicManager.Update(Time.unscaledDeltaTime);
		//
		ViTimerRealInstance.Update(GameTimeScale.RealDeltaTime);
		ViTimerVisualInstance.Update(GameTimeScale.DeltaTime);
		ViTimerInstance.Update(deltaTime);
		ViTickNode.Update(GameTimeScale.DeltaTime);
		ViLodTickNode.Update(GameTimeScale.DeltaTime);
		ViAsynExecer.UpdateAll(deltaTime);
		//
		ViAsynDelegateInterface.Update();
		ViFramEndCallbackInterface.Update();
		//
		UnityDeletor.Update(GameTimeScale.DeltaTime);
		//ResourceRequestInterface.UpdateAll(GameTimeScale.DeltaTime);
		//ResourceManagerInstance.Update();
		//
		ViExpressInterface.UpdateAll(deltaTime);
		//
		//ViewControllerManager.Update();
	}

	public void Update1()
	{
		float deltaTime = GameTimeScale.LogicDeltaTime;
		//
		TickManager.Update(deltaTime);
		//
		Client.Current = Client;

		//NetWorkProcess.Instance.Init(Client);
		Client.Update1(deltaTime);
		PickManager.Instance.Update();
		//
		CameraController.Instance.Update(deltaTime);
		AudioListener.Update();
		//
		//RoleHintInterface.UpdateAll(deltaTime);
		//
		ViDistNotifier.UpdateList();
		ViDistInNotifier.UpdateList();
		ViDistOutNotifier.UpdateList();
		//
		ViAsynDelegateInterface.Update();
		ViFramEndCallbackInterface.Update();
        //
        //ViewControllerManager.LateUpdate();
        UIResManagerBase<GameObject>.Update();
        UIResManagerBase<Texture>.Update();
    }

	public void FixedUpdate()
	{

	}

	public void ExitApp()
	{
		if (Application.isEditor)
		{
			ViDebuger.Record("ExitApp");
		}
		else
		{
#if !UNITY_WEBPLAYER
			Caching.CleanCache();
#endif
			Application.Quit();
		}
	}

	public void OpenSDKLogin()
	{
		if (UsePublishSDK)
		{
			MtlibSDK.Login();
		}
		else
		{
			ViDebuger.Record("OpenSDKLogin");
		}
	}

	#region Log
	void OnUnityLog(string condition, string stackTrace, UnityEngine.LogType type)
	{
		if (!(type == LogType.Exception || type == LogType.Error))
		{
			stackTrace = string.Empty;
		}
		else
		{
			string log = DateTime.Now.ToString() + "\n" + condition + "\n" + stackTrace;
			IOAssisstant.WriteAppendPresistent(IOAssisstant.RunTimeLog, log, false);
			if (Account.Instance != null)
			{
				AccountServerInvoker.OnDebugErrorTrace(Account.Instance, condition, stackTrace);
			}
		}
		//
		//if (//ViewControllerManager.DebugView != null)
		//{
		//	if (type == LogType.Exception || type == LogType.Error)
		//	{
		//		if (UnityEngine.Application.isEditor || GameApplication.VALUE_DebugWin.Value)
		//		{
		//			//ViewControllerManager.DebugView.Open();
		//		}
		//	}
		//	//ViewControllerManager.DebugView.AddLog(condition, stackTrace, type);
		//}
		//else
		{
			AddLog(condition);
		}
	}
	void OnRecordCallback(string msg)
	{
		if (ViDebuger.LogLevel <= ViLogLevel.RECORD)
		{
			UnityEngine.Debug.Log(msg + "/Time=" + Time.time);
		}
	}
	void OnAssertWarningCallback(string msg)
	{
		if (ViDebuger.LogLevel <= ViLogLevel.WARNING)
		{
			UnityEngine.Debug.LogWarning(msg + "/Time=" + Time.time);
		}
	}
	void OnCritOKCallback(string msg)
	{
		if (ViDebuger.LogLevel <= ViLogLevel.CRIT_OK)
		{
			//ViewControllerManager.DebugView.AddLog(msg, "", UnityEngine.LogType.Log);
		}
	}
	void OnNoteCallback(string msg)
	{
		if (ViDebuger.LogLevel <= ViLogLevel.OK)
		{
			//ViewControllerManager.DebugView.AddLog(msg, "", UnityEngine.LogType.Log);
		}
	}
	void OnAssertErrorCallback(string msg)
	{
		if (ViDebuger.LogLevel <= ViLogLevel.ERROR)
		{
			UnityEngine.Debug.LogError(msg + "/Time=" + Time.time);
		}
	}

	void OnPrintStringCallbackByViLog(ViLogLevel logType, string msg)
	{
		if (ViDebuger.LogLevel > logType)
		{
			return;
		}
		//
		switch (logType)
		{
			case ViLogLevel.WARNING:
				UnityEngine.Debug.LogWarning(msg);
				break;
			case ViLogLevel.ERROR:
				UnityEngine.Debug.LogError(msg);
				break;
			case ViLogLevel.RECORD:
				UnityEngine.Debug.Log(msg);
				break;
			default:
				//ViewControllerManager.DebugView.AddLog(msg, "", UnityEngine.LogType.Log);
				break;
		}
	}

	void OnPrintValueCallbackByViLog(ViLogLevel logType, ViTupleInterface tuple)
	{

	}
	#endregion


	#region Data
	public void LoadData()
	{
        UIManagerUtility.UpdateLoadingProgress(1f);
        _dataManager.DataCompletedCallback = this.OnDataCompleted0;
		_dataManager.Load0();
    }

	void OnDataCompleted0()
	{
		//ViDebuger.Record("OnDataCompleted0/" + Time.time);
		//
		ViDebuger.LogLevel = (ViLogLevel)VALUE_LogLevel.Value;
		Application.targetFrameRate = VALUE_FrameRate;
		//
		if (VALUE_DebugWin)
		{
			//ViewControllerManager.DebugView.Open();
		}
        ////ViewControllerManager.CreateAllViewControllers();
        ////ViewControllerManager.OpenWindow();
        //UIManagerUtility.HideLoading();
        
        _dataManager.DataCompletedCallback = this.OnDataCompleted1;
		_dataManager.Load1();

        UIManager.Instance.PreLoadController();
        UIAtlasManager.Instance.PreloadAtlas();
    }

	void OnDataCompleted1()
	{
		//ViDebuger.Record("OnDataCompleted1/" + Time.time);
		//
		MusicManager.Start();
		GameApplication.Instance.MusicManager.SetVolume(PlayerPrefs.GetFloat("MusicVolumeScale", 0.5f));
		//
		AudioListener.Start(GlobalGameObject.Instance.AudioListener.transform);
		GlobalGameObject.Instance.LoadDynamic();
		//WordFilterInstance.Start();
		//
		ViDelegateAssisstant.Invoke(DataCompleteCallback);

        if (OnDataCompleted != null)
        {
            OnDataCompleted();
            OnDataCompleted = null;
        }
        UIManagerUtility.ReplaceCommonWindow();//暂时在这些，应该资源加载完毕之后重新替换uicommonwindow（uipreloadwindow）
        UIManager.Instance.Show(UIControllerDefine.WIN_Login, (() => { UIManagerUtility.HideLoading(); }));
        //StoryManager.GetInstance.Init();
    }


	#endregion

	#region Time
	public void OnGameTime(Int64 timeAccumulate)
	{
		//ViTimerInstance.SetTime(timeAccumulate);
	}

	public void OnGameStart(Int64 time1970, Int64 timeAccumulate)
	{
		string log = string.Empty;
		log += "Time1970=" + time1970 + ", AccTime=" + timeAccumulate + ", TimerSpan=" + VALUE_TimerSpan.Value + ", TimerRollSize=" + VALUE_TimerRollSize.Value + ", TimerRollSize=" + VALUE_TimerRollSize.Value;
		ViDebuger.Record(log);
		//
		ViTimerInstance.Start(time1970, timeAccumulate, (UInt32)VALUE_TimerSpan.Value, (UInt32)VALUE_TimerRollSize.Value, (UInt32)VALUE_TimerRollSize.Value);
		ViTimerInstance.SetDayOffset((Int32)(VALUE_DayExpireHour * ViTickCount.HOUR));
        //
        if (IsEditor == false)
        {
            Client.StartPing();
        }
		//
		GameTimeScale.UpdateLogicTime(timeAccumulate, VALUE_ClientPingSpan);
	}

	#endregion

	#region GUILog

	public string GUILog { get { return _GUILog; } }
	string _GUILog = string.Empty;
	public void AddLog(string value)
	{
		_GUILog = value + "\n" + _GUILog;
	}
	#endregion


#region GC
	public void GarbageCollection()
	{
#if UNITY_EDITOR
		UnityEngine.Profiling.Profiler.BeginSample("GarbageCollection");
		_GarbageCollection();
		UnityEngine.Profiling.Profiler.EndSample();
#else
		_GarbageCollection();
#endif
	}

	void _GarbageCollection()
	{
		ViDebuger.CritOK("GarbageCollection");
		//
		ViReceiveDataCacheManager.ClearCache();
		//
		UnityDeletor.Clear();
		//
		//ResourceManagerInstance.Instance.FreeUseless(true);
		//
		//UIDrawCall.GarbageCollection();
		//UIPanel.GarbageCollection();
		//IconDataManager.ClearAtlasCacheMap();
		//
		UnityDeletor.Update(0.0f);
		//
		GC.Collect();
	}
#endregion

	FPSCountor _FPSCountor = new FPSCountor(60);
	Client _client = new Client();
	GameDataManager _dataManager = new GameDataManager();
	MusicManager _musicManager = new MusicManager();
	AudioListenerManager _audioListener = new AudioListenerManager();
}