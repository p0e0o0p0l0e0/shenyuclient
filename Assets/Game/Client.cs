using System;
using System.Collections.Generic;
using UnityEngine;

using UInt8 = System.Byte;
using ViTime64 = System.Int64;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;

public class Client
{
    public static ViConstValue<bool> VALUE_ClientTryCatch = new ViConstValue<bool>("ClientTryCatch", false);
    public static ViConstValue<float> VALUE_PingExpireNetSpan = new ViConstValue<float>("PingExpireNetSpan", 10.0f);
    public static ViConstValue<float> VALUE_PingWaitConnect = new ViConstValue<float>("PingWaitConnect", 3.0f);
    public static ViConstValue<string> VALUE_ClientSessionPassword = new ViConstValue<string>("ClientSessionPassword", "WarX");
    public static ViConstValue<string> VALUE_NewVersionURL = new ViConstValue<string>("NewVersionURL", "");
    public static ViConstValue<uint> VALUE_MainCitySpaceId = new ViConstValue<uint>("MainCitySpaceId", 10);

    public static ViFomatString NewLoginConfireLog = new ViFomatString("账号在别处登录!");
    public static ViFomatString ErrorAccountConfireLog = new ViFomatString("账号或密码错误!");
    public static ViFomatString DisableAccountConfireLog = new ViFomatString("账号被暂时屏蔽(&)!");
    public static ViFomatString DisableIPConfireLog = new ViFomatString("网络异常(&)!");
    public static ViFomatString VersionErrorConfireLog = new ViFomatString("需要更新至最新版本\n(本地:&/服务器:&)!");
    public static ViFomatString NetDisconnectConfireLog = new ViFomatString("网络失去连接,点击重新登录!");
    public static ViFomatString ReconnentFailConfireLog = new ViFomatString("无法连接到服务器!");
    public static ViFomatString WaitingForLogin = new ViFomatString("排队中!");
    public static ViFomatString LocalSeverListError = new ViFomatString("本地缺少服务器列表!请更新SVN");

    public static Client Current;

    public ViRakNet Net { get { return _net; } }
    public ViEntityManager EntityManager { get { return _RPCManager.EntityManager; } }
    public Int64 PingValue
    {
        get
        {
            if (_lastPingWaiting)
            {
                return ViMathDefine.Max((Int64)(Time.realtimeSinceStartup * 1000) - _lastPingSendTime, _pingValue);
            }
            else
            {
                return _pingValue;
            }
        }
    }
    public CellHero LocalHero { get { return _localHero; } }

    public void Start()
    {
        _RPCManager.SystemMessageExecer = this.OnSystemMessage;
        _RPCManager.OnLoginResult = this.OnLoginResult;
        _RPCManager.OnSelfCreatedExecer = this.OnSelfEntityCreated;
        _RPCManager.OnSelfMessageExecer = this.OnSelfMessage;
        _RPCManager.OnExecBusyExecer = this.OnRPCExecBusy;
        _RPCManager.OnEntityEnterExecer = this.OnEntityEnter;
        _RPCManager.OnEntityLeaveExecer = this.OnEntityLeave;
        _RPCManager.OnGameStartExecer = GameApplication.Instance.OnGameStart;
        _RPCManager.OnGameTimeExecer = GameApplication.Instance.OnGameTime;
        _RPCManager.OnScriptStream = RPCScriptEx.OnExec;
        _RPCManager.OnPing = this.OnPing;
        _RPCManager.SELF_PROPERTY_MASK = (UInt16)(1 << (int)(ProjectAChannel.OWN_CLIENT)) + (UInt16)(1 << (int)(ProjectAChannel.ALL_CLIENT));
        _RPCManager.OTHER_PROPERTY_MASK = (UInt16)(1 << (int)(ProjectAChannel.ALL_CLIENT));
        //

    }

    public void End()
    {
        ClearCameraWorkFlow();
    }

    public void Update0(float deltaTime)
    {
        NetWorkProcess.Instance.UpdateNetReceive();
    }

    public void Update1(float deltaTime)
    {
        if (_net != null)
        {
            _net.FreshSendCache();
        }
        //
        HeroController.Instance.Update(deltaTime);
    }

    public void SetLoginContent(string content)
    {
        _loginContent = content;
    }


    public void Login(string serverName, string account, string time, string sign)
    {
        ServerConfigViewStruct serverConfig = ViSealedDB<ServerConfigViewStruct>.Data(serverName);
        ServerConfigPortStruct portInfo = serverConfig.Merge.GetData(serverConfig).BasePort.Data;
        //
        _loginContent = "?account=" + account + "&time=" + time + "&sign=" + sign + "&devicePlatform=" + ApplicationPlatform.Name();
        _loginIP = serverConfig.LoginIP;
        _loginPort = (UInt16)portInfo.Port;
        ExecLogin(false, 0.0f);
    }

    /// <summary>
    /// 新的连接重载方法
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="point"></param>
    /// <param name="account"></param>
    /// <param name="time"></param>
    /// <param name="sign"></param>
    public void Login(string ip,ushort point, string account, string time, string sign)
    {
        _loginContent = "?account=" + account + "&time=" + time + "&sign=" + sign + "&devicePlatform=" + ApplicationPlatform.Name();
        _loginIP = ip;
        _loginPort = (UInt16)point;
        ExecLogin(false, 0.0f);
    }



    public void LoginEx(string content)
    {
        string loginIP = StandardAssisstant.GetStrValue(content, "loginIP=");
        string serverName = StandardAssisstant.GetStrValue(content, "serverID=");
        string serverBaseName = StandardAssisstant.GetStrValue(content, "serverBase=");
        ServerConfigViewStruct serverConfig = ViSealedDB<ServerConfigViewStruct>.Data(serverName);
        ServerConfigPortStruct portInfo = serverConfig.Merge.GetData(serverConfig).GetBase(serverBaseName);
        //
        _loginContent = content;
        _loginIP = loginIP;
        _loginPort = (UInt16)portInfo.Port;
        ExecLogin(false, 0.0f);
    }

    public void ExecLogin(bool showReconnectUI, float delay)
    {
        if (_net != null)
        {
            return;
        }
        //
        ViDebuger.Record("Client.Login(" + _loginContent + ")TIME=" + Time.time);
        //
        CloseConnect();
        _net = new ViRakNet();
        _net.ConnectCallback = this.OnConnected;
        _net.ConnectFailedCallback = this.OnConnectException;
        _net.DisconnectCallback = this.OnDisconnect;
        _net.ReceiveCallback = this.UpdateNetInput;
        _net.Start();
        _net.Connect(_loginIP, _loginPort, VALUE_ClientSessionPassword);
        NetWorkProcess.Instance.SetNet(_net);
        //
        if (showReconnectUI)
        {
            ////ViewControllerManager.ReConnectView.Open();
            UIManagerUtility.ShowLoading();
        }
    }

    public void OnConnected()
    {
        UInt8 emptyLicence = 0;
        UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
        UInt16 funcID = (UInt16)ViRPCMessage.LOGIN;
        Net.ResetSendStream();
        Net.OS.Append(emptyLicence);
        Net.OS.Append(receiverSide);
        Net.OS.Append(funcID);
        Net.OS.Append(ProjectAVersion.ID);
        Net.OS.Append(_loginContent);
        Net.SendStream();
        //
        ////ViewControllerManager.ReConnectView.Close();
        //UIManagerUtility.HideLoading();
    }

    void OnConnectException()
    {
        //UIManagerUtility.ShowConfirm(ReconnentFailConfireLog, null);
        UIManagerUtility.ShowHint(ReconnentFailConfireLog);
        EventDispatcher.TriggerEvent<bool>(Events.SceneCommonEvent.WaitConnectUI, false);
        //ViewControllerManager.OnReconnectFailed(ReconnentFailConfireLog);
        //
        CloseConnect();
    }

    void OnDisconnect()
    {
        UIManagerUtility.ShowConfirm(NetDisconnectConfireLog, null);
        //ViewControllerManager.OnNetDisconnnect(NetDisconnectConfireLog);
        //
        CloseConnect();
    }

    public void CloseConnect()
    {
        ClearCameraWorkFlow();
        //
        _pingTimeNode.Detach();
        //
        NetWorkProcess.Instance.SetNet(null);
        //
        if (_net != null)
        {
            _net.ConnectCallback = null;
            _net.ConnectFailedCallback = null;
            _net.DisconnectCallback = null;
            _net.Close();
            _net = null;
        }
    }

    static void ResetRPC(ViRPCExecerManager manager, ViRakNet net, ref Int32 RPCActiveCount)
    {
        if (RPCActiveCount > 0)
        {
            ViRPCExecerManagerEnd(manager);
        }
        //
        ++RPCActiveCount;
        manager.Start(net);
    }

    private static void ViRPCExecerManagerEnd(ViRPCExecerManager manager)
    {
        manager.DestroyEntity<CellChatGroup>();
        manager.DestroyEntity<SpaceObject>();
        manager.DestroyEntity<AreaAura>();
        manager.DestroyEntity<GameUnit>();
        manager.DestroyEntity<GameSpaceFactionRecord>();
        manager.DestroyEntity<GameSpaceRecord>();
        manager.DestroyEntity<CellRecord>();
        //
        manager.DestroyEntity<TradeManager>();
        manager.DestroyEntity<PublicSpaceEnter>();
        manager.DestroyEntity<SpaceMatchManager>();
        manager.DestroyEntity<Guild>();
        manager.DestroyEntity<Party>();
        manager.DestroyEntity<ActivityRecord>();
        manager.DestroyEntity<CenterChatGroup>();
        manager.DestroyEntity<PlayerComponent>();
        manager.DestroyEntity<Player>();
        manager.DestroyEntity<GameRecord>();
        //
        manager.End();
        //
        ViExpressInterface.ClearAllExpress<ViSpaceExpress>();
        //
        GameApplication.Instance.MusicManager.ClearElapseList();// Unity删除声源有Bug
        //
        //ViewBlackMaskController.Clear();
        UnityDeletor.Clear();
    }

    public void UpdateNetInput(ViIStream IS)
    {
        if (VALUE_ClientTryCatch)
        {
            try
            {
                _RPCManager.OnMessage(IS);
            }
            catch (System.Exception ex)
            {
                ViDebuger.Error("Exception >> " + ex);
            }
        }
        else
        {
            //ViDebuger.Note("NetInputStream[len=" + IS.RemainLength + "]");
            _RPCManager.OnMessage(IS);
        }
        //
        if (IS.RemainLength > 0)
        {
            ViDebuger.Warning("NetInputStream.RemainLength=" + IS.RemainLength + "]");
        }
    }

#region Ping

    public void StartPing()
    {
        _lastPingWaiting = false;
        _pingResponseExpireTime = Time.realtimeSinceStartup + VALUE_PingExpireNetSpan;
        _pingWaitConnect = Time.realtimeSinceStartup + VALUE_PingWaitConnect;
        _pingTimeNode.Start(ViTimerRealInstance.Timer, (UInt32)GameApplication.VALUE_ClientPingSpan.Value, this.OnClientPing);
    }

    void Ping()
    {
        if (Net != null)
        {
            UInt8 emptyLicence = 0;
            UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
            UInt16 funcID = (UInt16)ViRPCMessage.PING;
            Net.ResetSendStream();
            Net.OS.Append(emptyLicence);
            Net.OS.Append(receiverSide);
            Net.OS.Append(funcID);
            Net.OS.Append((Int64)(Time.realtimeSinceStartup * 1000));
            Net.OS.Append((Int64)0);
            Net.SendStream();
        }
    }

    ViTimeNode4 _pingTimeNode = new ViTimeNode4();
    void OnClientPing(ViTimeNodeInterface node)
    {
        ViDebuger.Note("OnClientPing:" + UnityEngine.Time.realtimeSinceStartup);
        if (!_lastPingWaiting)
        {
            _lastPingWaiting = true;
            _lastPingSendTime = (Int64)(Time.realtimeSinceStartup * 1000);
            Ping();
            EventDispatcher.TriggerEvent<bool>(Events.SceneCommonEvent.WaitConnectUI, false);
        }
        else
        {
            if (Time.realtimeSinceStartup > _pingResponseExpireTime)
            {
                _pingTimeNode.Detach();
                //ViewControllerManager.OnNetDisconnnect(NetDisconnectConfireLog);
                UIManagerUtility.ShowConfirm(NetDisconnectConfireLog, OnTryReconnectCallback);
                EventDispatcher.TriggerEvent<bool>(Events.SceneCommonEvent.WaitConnectUI, false);
            }
            else if(Time.realtimeSinceStartup > _pingWaitConnect && Time.realtimeSinceStartup < _pingResponseExpireTime)
            {
                EventDispatcher.TriggerEvent<bool>(Events.SceneCommonEvent.WaitConnectUI, true);
            }
        }

    }

    void OnPing(Int64 localTime, Int64 serverTime)
    {
        _pingValue = (Int64)(Time.realtimeSinceStartup * 1000) - localTime;
        GameTimeScale.UpdateLogicTime(serverTime, GameApplication.VALUE_ClientPingSpan);
        //
        _lastPingWaiting = false;
        _pingResponseExpireTime = Time.realtimeSinceStartup + VALUE_PingExpireNetSpan;
        _pingWaitConnect = Time.realtimeSinceStartup +  VALUE_PingWaitConnect;
    }

    Int64 _pingValue = 0;
    Int64 _lastPingSendTime = 0;
    bool _lastPingWaiting;
    double _pingResponseExpireTime = 0, _pingWaitConnect = 0;

    private void OnTryReconnectCallback(int i, object data)
    {
        ViRPCExecerManagerEnd(_RPCManager);
        GameApplication.Instance.Client.CloseConnect();
        ClearDataManager.ClearAllData();
        AccountScene.Instance.Clear();
        UIManager.Instance.DestroyAllController();
        UIManager.Instance.Show(UIControllerDefine.WIN_Login);
        UIManagerUtility.HideLoading();
    }

    #endregion

    public void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if (_pingTimeNode.IsAttach())
            {
                StartPing();
            }
        }
        else
        {

        }
    }

    void OnSystemMessage(UInt16 funcID, ViIStream IS)
    {

    }

    void OnRPCExecBusy(UInt16 funcID)
    {
        EntityMessager.Message(EntityMessage.ACTION_BUSY, false);
    }


    void OnSelfEntityCreated(ViRPCExecer execer)
    {
        if (Application.isEditor)
        {
            ViDebuger.CritOK("OnSelfEntityCreated<" + execer.Entity.GetType().Name + ">(" + execer.Entity.Name + "/" + execer.Entity.ID + ")Time:" + Time.time);
        }
        //UIManagerUtility.UpdateLoadingProgress(1f);

        bool ret = _CheckPlayerData(execer);
        if (!ret)
            _CheckPlayerComponetData(execer);

    }
    private bool _CheckPlayerData(ViRPCExecer execer)
    {
        if ( execer.Entity is Account || execer.Entity is Player)
        {
            Account account = execer.Entity as Account;
            if (account != null)
            {
                AccountServerInvoker.UpdateDevice(account, ClientDevicePlatformAssisstent.GetDeviceProperty());
                //ViewControllerManager.OnAccountCreated(account);
                //UIManager.Instance.Show(UIControllerDefine.WIN_Role);
            }
            if (Account.Instance != null)
            {
                Player player = execer.Entity as Player;
                if (player != null)
                {
                    UIRoleDataManager.GetInstance.OnPlayerCreateSuccess();
                    ApplicationSetting.Instance.Start(player);
                }
                    
            }
            return true;
        }
        return false;
    }
    private bool _CheckPlayerComponetData(ViRPCExecer execer)
    {
        if (execer.Entity is PlayerMailbox || execer.Entity is PlayerFriendList || execer.Entity is PlayerOfflineBox || execer.Entity is CellPlayer || execer.Entity is CellHero || execer.Entity is AccountClientExecer)
        {
            PlayerMailbox playerMailbox = execer.Entity as PlayerMailbox;
            if (playerMailbox != null)
            {
                ////ViewControllerManager.OnPlayerMailboxCreated(playerMailbox);
            }
            PlayerFriendList playerFriendList = execer.Entity as PlayerFriendList;
            if (playerFriendList != null)
            {
                ////ViewControllerManager.OnPlayerFriendListCreated(playerFriendList);
            }
            PlayerOfflineBox playerOfflineBox = execer.Entity as PlayerOfflineBox;
            if (playerOfflineBox != null)
            {
                ////ViewControllerManager.OnPlayerOfflineBoxCreated(playerOfflineBox);
            }
            //
            CellPlayer cellPlayer = execer.Entity as CellPlayer;
            if (cellPlayer != null)
            {
                ////ViewControllerManager.OnCellPlayerCreated(cellPlayer);
            }
            //
            CellHero cellHero = execer.Entity as CellHero;
            if (cellHero != null)
            {
                _localHero = cellHero;
                //
                cellHero.PickActive.DefaultValue = false;
                //
                HeroController.Instance.Start(cellHero, this);
                //
                CompleteCellHero();
                //ViewControllerManager.OnCellHeroCreated();
                UIManagerUtility.ShowFightUIs();

                if (cellHero.Dead)
                {
                    UIManager.Instance.Show(UIControllerDefine.WIN_Resurrection);
                }
                //
                GameApplication.Instance.AudioListener.PosValue.Add(GameKeyWord.Space, 10, cellHero.PosProvider);
               // UIManagerUtility.HideLoading(true);
            }
            //UIManagerUtility.HideLoading();
            return true;
        }
        return false;
    }
	void PreRPCMessage(ViEntity entity, UInt16 funcID)
	{

	}

	void OnSelfMessage(UInt16 msgID, UInt64 types, ViIStream IS)
	{
		EntityMessageController.OnServerMessage(msgID, types, IS);
	}

	void OnEntityEnter(ViRPCExecer execer)
	{
		if (Application.isEditor)
		{
			ViDebuger.CritOK("OnEntityEnter<" + execer.Entity.GetType().Name + ">(" + execer.Entity.Name + "/" + execer.Entity.ID + ")Time:" + Time.time);
		}
		//
		if (HeroController.Instance.FocusEntityPackedID == execer.Entity.PackID)
		{
		}
	}

	void OnEntityLeave(ViRPCExecer execer)
	{
		if (Application.isEditor)
		{
			ViDebuger.CritOK("OnEntityLeave<" + execer.Entity.GetType().Name + ">(" + execer.Entity.Name + "/" + execer.Entity.ID + ")Time:" + Time.time);
		}
		//
		if (System.Object.ReferenceEquals(HeroController.Instance.LocalHero, execer.Entity))
		{
			_localHero = null;
			//
			HeroController.Instance.End();
			//
			GameApplication.Instance.AudioListener.PosValue.Del(GameKeyWord.Space);
		}
		//
		if (HeroController.Instance.FocusEntityPackedID == execer.Entity.PackID)
		{
			HeroController.Instance.UpdateFocusEntityHint();
		}
	}

	void OnLoginResult(UInt8 result, string note)
	{
        ShowHintByResult(result);
        //bool isNewLogin = Account.Instance == null ? false : true;
		ResetRPC(_RPCManager, _net, ref _PRCActiveCount);        
        //
        switch ((LoginResult)result)
		{
			case LoginResult.OK:
				ViDebuger.Record("LoginResult.OK");
                ////ViewControllerManager.ResourceLoadViewController.SetLoadingTips(LocalVisualString.FOMAT_LoginSuccess);
                //if (!isNewLogin)
                {
                    UIManagerUtility.ShowLoading();
                    UIManager.Instance.Hide(UIControllerDefine.WIN_Login);
                }            
                break;
			case LoginResult.NEW_LOGIN:
				ViDebuger.Record("LoginResult.NEW_LOGIN");
				CloseConnect();
                UIManagerUtility.ShowConfirm(NewLoginConfireLog.Print(), OnExitGame);
                UIManagerUtility.ShowHint(NewLoginConfireLog.Print());
                break;
			case LoginResult.ERROR_VERSION:
				ViDebuger.Record("LoginResult.ERROR_VERSION "+ ProjectAVersion.ID.ToString());
				CloseConnect();
                //ViewControllerManager.ConfirmView.ShowConfirm2(VersionErrorConfireLog.Print(ProjectAVersion.ID.ToString(), note), this.DownLoadNewVersion, this.OnExitGame, null);
//                UIManagerUtility.ShowHint(VersionErrorConfireLog.Print(ProjectAVersion.ID.ToString(), note));
                UIManagerUtility.ShowConfirm(VersionErrorConfireLog.Print(ProjectAVersion.ID.ToString(), note), null);
                break;
			case LoginResult.ERROR_ACCOUNT:
				ViDebuger.Record("LoginResult.ERROR_ACCOUNT");
				CloseConnect();
                UIManagerUtility.ShowConfirm(ErrorAccountConfireLog, null);
                //ViewControllerManager.ConfirmView.ShowConfirm1(ErrorAccountConfireLog.Print(), this.Relogin, null);
                break;
			case LoginResult.WAITING:
				ViDebuger.Record("LoginResult.WAITING");
				CloseConnect();
//                UIManagerUtility.ShowHint(WaitingForLogin.Print());
                UIManagerUtility.ShowConfirm(WaitingForLogin, null);
                //ViewControllerManager.ConfirmView.ShowConfirm1(WaitingForLogin.Print(), this.OnExitGame, null);
                break;
			case LoginResult.INDULGE:
				ViDebuger.Record("LoginResult.INDULGE");
				CloseConnect();
//                UIManagerUtility.ShowHint(DisableAccountConfireLog.Print());
                UIManagerUtility.ShowConfirm(DisableAccountConfireLog, null);
                //ViewControllerManager.ConfirmView.ShowConfirm1(DisableAccountConfireLog.Print(), this.OnExitGame, null);
                break;
			case LoginResult.DISABLE_ACCOUNT:
				ViDebuger.Record("LoginResult.DISABLE");
				CloseConnect();
//                UIManagerUtility.ShowHint(ErrorAccountConfireLog.Print());
                UIManagerUtility.ShowConfirm(ErrorAccountConfireLog, null);
                //ViewControllerManager.ConfirmView.ShowConfirm1(ErrorAccountConfireLog.Print(), this.OnExitGame, null);
                break;
			case LoginResult.DISABLE_IP:
				ViDebuger.Record("LoginResult.DISABLE");
				CloseConnect();
                ErrorAccountConfireLog.Print(DisableIPConfireLog.Print());
                UIManagerUtility.ShowConfirm(DisableIPConfireLog, null);
                //ViewControllerManager.ConfirmView.ShowConfirm1(DisableIPConfireLog.Print(), this.OnExitGame, null);
                break;
			default:
				ViDebuger.Warning("OnLoginResult(" + result + ") None Handle!");
				break;
		}
	}

    private void ShowHintByResult(UInt8 result)
    {
        LoginResult loginResult = (LoginResult)result;
        if (loginResult == LoginResult.OK)
        {
            UIManagerUtility.ShowHint("登陆成功!");
        }
        EventDispatcher.TriggerEvent<bool>(Events.SceneCommonEvent.WaitConnectUI, false);
    }
	void OnExitGame(int i,System.Object obj)
	{
        //GameApplication.Instance.ExitApp();
        UIManager.Instance.Show(UIControllerDefine.WIN_Login);        
        AccountScene.Instance.Clear();        
        ClearDataManager.ClearAllData();
    }

	void DownLoadNewVersion(System.Object obj)
	{
		Application.OpenURL(ApplicationPlatform.WWWURL + IOAssisstant.APKFile);
	}

	void Relogin(System.Object obj)
	{
		//ViewControllerManager.Relogin();
	}

	public void OnGameSpaceCreated(SpaceStruct spaceInfo)
	{
		//ViewControllerManager.OnEnterSpace(spaceInfo);
		//
		_cameraControllerStartEvent.Reset(this._OnSpaceCameraReady);
		_cameraControllerStartEvent.Wait("SpaceLoad");
		_cameraControllerStartEvent.Wait("CellHero");
	}

	void _OnSpaceCameraReady()
	{
		GameSpace.ActiveInstance.UpdateCameraController((Int32)CellHero.LocalFaction - (Int32)Faction.PLAYER_0, CellHero.LocalHero.CameraPosProvider, CellHero.LocalHero.CameraYawProvider);
		//
		if (GameSpaceRecordInstance.Instance.HasCacheEvent(GameSpaceEventInstance.SpaceCamearDistanceEnd))
		{
			CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
			if (camera != null)
			{
				camera.Distance = ViMathDefine.Lerp(camera.Inf.Distance, camera.Sup.Distance, GameSpaceRecord.VALUE_SpaceShowCameraDistanceProgress);
				camera.ForceDistance();
				CameraController.Instance.SmoothImmediate();
			}
		}

        UIManagerUtility.OnEnterSpace();
        EventDispatcher.TriggerEvent<bool>(Events.SpaceEvent.ChangeSpace, true);
    }

	void ClearCameraWorkFlow()
	{
		_cameraControllerStartEvent.Clear();
	}

	public void CompleteSpaceLoad()
	{
		_cameraControllerStartEvent.Complete("SpaceLoad");
	}

	public void CompleteCellHero()
	{
		_cameraControllerStartEvent.Complete("CellHero");
	}

	ViRakNet _net = null;
	string _loginContent = string.Empty;
	string _loginIP;
	UInt16 _loginPort;
	ViRPCExecerManager _RPCManager = new ViRPCExecerManager(true);
	Int32 _PRCActiveCount = 0;
	CellHero _localHero;
	//
	ViWorkFlowEvent _cameraControllerStartEvent = new ViWorkFlowEvent();
}