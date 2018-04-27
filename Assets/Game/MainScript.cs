using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    static ViConstValue<float> VALUE_CameraYawSpeed = new ViConstValue<float>("CameraYawSpeed", 1.0f);
    static ViConstValue<bool> VALUE_QuitClearCache = new ViConstValue<bool>("QuitClearCache", true);
    static ViConstValue<bool> VALUE_InputEscShow = new ViConstValue<bool>("InputEscShow", true);
    static ViConstValue<float> VALUE_SDKLoginDelay = new ViConstValue<float>("SDKLoginDelay", 2.0f);
    public static ViFomatString FOMAT_ExitGame = new ViFomatString("是否退出游戏!");

    public bool UsePresistentPath = false;
    public bool UsePublishSDK = false;
    public bool PrintSystem = false;
    public bool SealedDataEditor = false;

    void Start()
    {
        if (!GameApplication.Instance.IsEditor)
        {
            UIManager.Instance.Inital();
        }
        
        ViDebuger.Record("MainScript.Start");
        //
        GameObjectPath.Instance.Start();
        //
        GlobalScriptObject.Instance.Start(gameObject);
        GlobalGameObject.Instance.Start(gameObject);
        //
        GameApplication.Instance.InitLog();
        GameApplication.Instance.UsePublishSDK = UsePublishSDK;
        //
        //ResourceManager.DataPath = UsePresistentPath ? ApplicationPlatform.PersistentDataPath : ApplicationPlatform.StreamingDataPath;
        //ResourceManager.DataURL = UsePresistentPath ? ApplicationPlatform.PersistentDataURL : ApplicationPlatform.StreamingDataURL;
        //
        if (PrintSystem)
        {
            ViDebuger.Record("Application.platform=" + Application.platform);
            ViDebuger.Record("Application.dataPath=" + Application.dataPath);
            ViDebuger.Record("Application.streamingAssetsPath=" + Application.streamingAssetsPath);
            ViDebuger.Record("Application.persistentDataPath=" + Application.persistentDataPath);
            ViDebuger.Record("Application.temporaryCachePath=" + Application.temporaryCachePath);
            ViDebuger.Record("Application.version=" + Application.version);
            ViDebuger.Record("ApplicationPlatform.WWWURL=" + ApplicationPlatform.WWWURL);
            ViDebuger.Record("ApplicationPlatform.WWWStreamingDataURL=" + ApplicationPlatform.WWWStreamingDataURL);
            ViDebuger.Record("ApplicationPlatform.StreamingDataPath=" + ApplicationPlatform.StreamingDataPath);
            ViDebuger.Record("ApplicationPlatform.StreamingDataURL=" + ApplicationPlatform.StreamingDataURL);
            ViDebuger.Record("ApplicationPlatform.PersistentDataPath=" + ApplicationPlatform.PersistentDataPath);
            ViDebuger.Record("ApplicationPlatform.PersistentDataURL=" + ApplicationPlatform.PersistentDataURL);
            //ViDebuger.Record("ResourceManager.URL=" + ResourceManager.DataURL);
            //
#if UNITY_EDITOR
            ViDebuger.Record("MACRO_PROC:UNITY_EDITOR");
#endif
#if UNITY_ANDROID
			ViDebuger.Record("MACRO_PROC:UNITY_ANDROID");
#endif
#if UNITY_IPHONE
		ViDebuger.Record("MACRO_PROC:UNITY_IPHONE");
#endif
        }
        //
        InitPhysics();
        //
        if (!Application.isWebPlayer || Application.isEditor)
        {
            string signFile = "Sign.vib";
            if (File.Exists(signFile))
            {
                StreamReader stream = File.OpenText(signFile);
                string content = stream.ReadToEnd();
                stream.Close();
            }
        }
        //
#if !UNITY_WEBPLAYER
        GMExecer.PrintUnityCaching();
        Caching.CleanCache();
#endif
        //
        GameApplication.Instance.Start();
        GameApplication.Instance.DataCompleteCallback = this.OnDataCompleted;
        GameApplication.Instance.DataManager.SealedDataEditor = SealedDataEditor;

        gameObject.AddComponent<ResourceLoadManager>();
        ResourceLoadManager.Instance.ReadyCallBack = GameApplication.Instance.LoadData;
        FingerManager.Instance.Init();
        FilePackage.Instance.Initialize();
        //
        //ResourceManagerInstance.Start();
        //ResourceManagerInstance.Instance.UpdateNessessary(1.0f);
        //ResourceManagerInstance.ReadyCallback = GameApplication.Instance.LoadData;
        //
        //GlobalGameObject.Instance.UIRoot.SetActive(true);
        //
        //ViewControllerManager.Start();
        //ViewControllerManager.OnTouchStart2 = this.OnTouchStart2;
        //ViewControllerManager.OnTouching2 = this.OnTouching2;
        //ViewControllerManager.OnTouchEnd2 = this.OnTouchEnd2;
        EventsRegister.Register();
        gameObject.AddComponent<ShowLogManager>();
    }


    void OnApplicationPause(bool pause)
    {
        ViDebuger.Record("OnApplicationPause(" + pause + ")/TIME=" + Time.time);
        //
        GameApplication.Instance.Client.OnApplicationPause(pause);
        if (pause)
        {
            GameApplication.Instance.ClearLogProcess();
            NetWorkProcess.Instance.Start();
        }
        else
        {
            GameApplication.Instance.ResetLogProcess();
            NetWorkProcess.Instance.End(GameApplication.Instance.Client.UpdateNetInput);
        }
        //
        if (MtlibSDK.Inited)
        {
            if (pause)
            {
                MtlibSDK.OnPause();
            }
            else
            {
                if (MtlibSDK.Pausing)
                {
                    MtlibSDK.OnResume();
                }
            }
            MtlibSDK.Pausing = pause;
        }
    }

    void OnApplicationQuit()
    {
        ViDebuger.Record("OnApplicationQuit()/TIME=" + Time.time);
        if (Account.Instance != null)
        {
            //AccountServerInvoker.UpdateAppFocus(Account.Instance, Convert.ToByte(pause));
        }
        //
        GameApplication.Instance.Client.CloseConnect();
        //
        if (MtlibSDK.Inited)
        {
            MtlibSDK.OnDestroy();
        }
        //
        if (VALUE_QuitClearCache)
        {
#if !UNITY_WEBPLAYER
            Caching.CleanCache();
#endif
        }
    }

    void Update()
    {
        if (GlobalGameObject.Instance != null)
        {
            GameApplication.Instance.Update0();
            //
            if (GameApplication.Instance.DataManager.Completed)
            {
                UpdateInput();
            }
        }
    }

    void LateUpdate()
    {
        if (GlobalGameObject.Instance != null)
        {
            GameApplication.Instance.Update1();
        }
    }

    void FixedUpdate()
    {
        if (GlobalGameObject.Instance != null)
        {
            GameApplication.Instance.FixedUpdate();
        }
    }

    void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!UICamera.isOverUI)
            {
                HeroController.Instance.OnTouchStart(Input.mousePosition);
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (!UICamera.isOverUI)
            {
                HeroController.Instance.OnTouchDrag(Input.mousePosition, Vector3.zero);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!UICamera.isOverUI)
            {
                HeroController.Instance.OnTouchEnd(Input.mousePosition);
            }
            else
            {
                HeroController.Instance.OnTouchBreak(Input.mousePosition);
            }
        }
        //
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
        }
        //
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _pickTime.Start(ViTimerInstance.Timer, 5, this.PickTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _pickTime.Detach();
        }
        //
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CursorCamera cameraCursor = CameraController.Instance.CameraPosDir as CursorCamera;
            if (cameraCursor != null)
            {
                cameraCursor.Yaw -= Time.deltaTime * VALUE_CameraYawSpeed;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CursorCamera cameraCursor = CameraController.Instance.CameraPosDir as CursorCamera;
            if (cameraCursor != null)
            {
                cameraCursor.Yaw += Time.deltaTime * VALUE_CameraYawSpeed;
            }
        }
        //
        float xScroll = Input.GetAxis("Mouse ScrollWheel");
        if (xScroll != 0.0f)
        {
            HeroController.Instance.OnMouseScrolled(xScroll);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEsc();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (GameSpace.ActiveInstance != null)
            {
                GameSpace.ActiveInstance.Navigator.ShowNavigate();
            }
        }
        //
        UpdateWASD();

        if (Input.GetKeyDown(KeyCode.B))
        {
            isShow = !isShow;
        }
    }
    bool isShow = false;
    void OnGUI()
    {
        if (isShow)
        {
            if (GUILayout.Button("增加一件装备"))
            {
                PlayerServerInvoker.AddItem(Player.Instance, (uint)UnityEngine.Random.Range(10010101, 10010106));//测试数据    
            }
            if (GUILayout.Button("减少一件装备"))
            {
                //PlayerServerInvoker.DelItemTrade(Player.Instance, 10003, 1);//测试数据    
            }
            if (GUILayout.Button("显示或隐藏UIlog"))
            {
                XLColorDebug.showLog = !XLColorDebug.showLog;
            }
        }  
    }
    void UpdateWASD()
    {
        bool lastWorking = _KeyNode_WS.IsNotEmpty() || _KeyNode_AD.IsNotEmpty();
        //
        if (Input.GetKeyDown(KeyCode.W))
        {
            _KeyNode_WS.PushFront(_KeyNode_W);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _KeyNode_W.Detach();
        }
        //
        if (Input.GetKeyDown(KeyCode.S))
        {
            _KeyNode_WS.PushFront(_KeyNode_S);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _KeyNode_S.Detach();
        }
        //
        if (Input.GetKeyDown(KeyCode.A))
        {
            _KeyNode_AD.PushFront(_KeyNode_A);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _KeyNode_A.Detach();
        }
        //
        if (Input.GetKeyDown(KeyCode.D))
        {
            _KeyNode_AD.PushFront(_KeyNode_D);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _KeyNode_D.Detach();
        }
        //
        Vector3 direction = Vector3.zero;
        if (_KeyNode_WS.IsNotEmpty())
        {
            direction += _KeyNode_WS.GetHead().Data;
        }
        if (_KeyNode_AD.IsNotEmpty())
        {
            direction += _KeyNode_AD.GetHead().Data;
        }
        //
        if (CellHero.LocalHero != null)
        {
            if (lastWorking)
            {
                if (_KeyNode_WS.IsEmpty() && _KeyNode_AD.IsEmpty())
                {
                    //ViewControllerManager.FightCtrlView.MoveEnd();
                    PlayerActionManager.Instance.OnEndMove();
                }
            }
            else
            {
                if (_KeyNode_WS.IsNotEmpty() || _KeyNode_AD.IsNotEmpty())
                {
                    //ViewControllerManager.FightCtrlView.MoveStart();
                    //UIManagerUtility.GetFightController().OnMoveBegin();
                    PlayerActionManager.Instance.OnBeginMove();
                }
            }
            //
            if (direction != Vector3.zero)
            {
                direction = PickAssisstant.OffsetCamera2World(CellHero.LocalHero.Position.Convert(), direction).normalized;
                float yaw = ViGeographicObject.GetDirection(direction.x, direction.z);
                //ViewControllerManager.FightCtrlView.UpdateMoveYaw(yaw, 1.0f);
                PlayerActionManager.Instance.UpdateMoveYaw(yaw, 1.0f);

            }
        }
    }
    ViDoubleLink2<Vector3> _KeyNode_WS = new ViDoubleLink2<Vector3>();
    ViDoubleLink2<Vector3> _KeyNode_AD = new ViDoubleLink2<Vector3>();
    ViDoubleLinkNode2<Vector3> _KeyNode_W = new ViDoubleLinkNode2<Vector3>(new Vector3(0.0f, 1.0f, 0.0f));
    ViDoubleLinkNode2<Vector3> _KeyNode_S = new ViDoubleLinkNode2<Vector3>(new Vector3(0.0f, -1.0f, 0.0f));
    ViDoubleLinkNode2<Vector3> _KeyNode_A = new ViDoubleLinkNode2<Vector3>(new Vector3(-1.0f, 0.0f, 0.0f));
    ViDoubleLinkNode2<Vector3> _KeyNode_D = new ViDoubleLinkNode2<Vector3>(new Vector3(1.0f, 0.0f, 0.0f));

    public bool OnEsc()
    {
        if (Application.isEditor)
        {
            //if (ViewEscProperty.TopView != null)
            {
            //    return ViewEscProperty.TopView.OnEsc();
            }
            if (HeroController.Instance.OnEsc())
            {
                return true;
            }
        }
        //
        if (VALUE_InputEscShow)
        {
            //UIConfirmParam pram = new UIConfirmParam();
            //pram.Text = FOMAT_ExitGame.Print();
            //pram.Style = UIConfirmParam.ConfirmStyle.OK_CANCEL;
            //pram.OnOKCallback = this.OnExitGame;
            //pram.ButtonSwap = true;
            //pram.CancelButtonText = CommonTextAssisstant.CANCEL;
            //pram.OKButtonText = CommonTextAssisstant.OK;
            //ViewControllerManager.ConfirmView.ShowConfirm(pram);
        }
        //
        return false;
    }

    void OnExitGame(System.Object obj)
    {
        GameApplication.Instance.ExitApp();
    }


    //    void ReadConfig(string value)
    //    {
    //        ResourceManager.Cached = StandardAssisstant.GetStrValue(value, "WWWCache=").StartsWith("true");
    //        ResourceManager.CacheSize = (Int64.Parse(StandardAssisstant.GetStrValue(value, "WWWCacheSize="))) * 1024 * 1024;
    //        AssetBundleWWW.LoadCountSup = Int32.Parse(StandardAssisstant.GetStrValue(value, "WWWLoadCountSup="));
    //        ResourceRequestInterface.ForceAsynLoad = StandardAssisstant.GetStrValue(value, "ForceAsynLoad=").StartsWith("true");
    //        bool clearCache = StandardAssisstant.GetStrValue(value, "WWWCacheClear=").StartsWith("true");
    //        RPCScriptEx.ReconnectRestart = StandardAssisstant.GetStrValue(value, "ReconnectRestart=").StartsWith("true");
    //        //
    //#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    //        Caching.maximumAvailableDiskSpace = ResourceManager.CacheSize;
    //        if (clearCache)
    //        {
    //            UnityEngine.Caching.CleanCache();
    //        }
    //#endif
    //    }

    void InitPhysics()
    {
        for (int iterFrom = 0; iterFrom < 32; ++iterFrom)
        {
            for (int iterTo = 0; iterTo < 32; ++iterTo)
            {
                Physics.IgnoreLayerCollision(iterFrom, iterTo);
            }
        }
        Physics.IgnoreLayerCollision((int)UnityLayer.ENTITY_EXPLORE, (int)UnityLayer.GROUND, false);
        Physics.IgnoreLayerCollision((int)UnityLayer.ENTITY_EXPLORE, (int)UnityLayer.SCENE, false);
        Physics.IgnoreLayerCollision((int)UnityLayer.LOOT, (int)UnityLayer.LOOT, false);
        Physics.IgnoreLayerCollision((int)UnityLayer.LOOT, (int)UnityLayer.GROUND, false);
        Physics.IgnoreLayerCollision((int)UnityLayer.LOOT, (int)UnityLayer.SCENE, false);

        //zlj change
        Physics.IgnoreLayerCollision((int)UnityLayer.DEFAULT, (int)UnityLayer.ENTITY, false);
    }

    void PickTime(ViTimeNodeInterface node)
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    Camera camera = GlobalGameObject.Instance.SceneCamera;
        //    if (CellHero.LocalHero != null && camera != null)
        //    {
        //        Pick(camera, CellHero.LocalHero);
        //    }
        //}
    }
    ViTimeNode4 _pickTime = new ViTimeNode4();

    void OnDataCompleted()
    {
    }


    #region Log

    //void OnGUI()
    //{
    //    string title = string.Empty;
    //    title += "Time = " + Time.time;
    //    GUI.Label(new Rect(0, 0, 500, 500), title);
    //    //
    //    GUI.Label(new Rect(0, 100, 500, 500), GameApplication.Instance.GUILog);
    //}

    #endregion


    #region TouchLine

    Vector3 _touchLineValue;
    void OnTouchStart2(List<Vector3> posList)
    {
        Vector3 from = posList[0];
        Vector3 to = posList[1];
        ViDebuger.Note("");
        _touchLineValue = to - from;
    }

    void OnTouchEnd2(List<Vector3> posList)
    {

    }

    void OnTouching2(List<Vector3> posList)
    {
        Vector3 from = posList[0];
        Vector3 to = posList[1];
        Vector3 newValue = to - from;
        if (_touchLineValue.magnitude == 0)
        {
            _touchLineValue = newValue;
            return;
        }
        //
        float deltaScale = (newValue.magnitude / _touchLineValue.magnitude);
        //
        _touchLineValue = newValue;
    }

    #endregion
}