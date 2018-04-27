using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

public static class GMExecer
{
	static readonly string[] lineSign = new string[] { "\n", "\\n", };
	static readonly char[] splitParamSign = new char[] { ' ' };
	static readonly char[] splitFuncSign = new char[] { '.', '/' };

	public static bool Exec(string content)
	{
		bool result = false;
		string[] lineList = content.Split(lineSign, StringSplitOptions.RemoveEmptyEntries);
		for (int iter = 0; iter < lineList.Length; ++iter)
		{
			if (_Exec(lineList[iter]))
			{
				result = true;
			}
		}
		return result;
	}

	static bool _Exec(string content)
	{
		if (content.Length <= 1)
		{
			return false;
		}
		string[] description = content.Split(splitParamSign, StringSplitOptions.RemoveEmptyEntries);
		if (description.Length <= 0)
		{
			return false;
		}
		List<string> paramList = new List<string>();
		string command = description[0];
		for (UInt32 idx = 1; idx < description.Length; ++idx)
		{
			paramList.Add(description[idx]);
		}
		if (_ExecEntity(command, paramList))
		{
			return true;
		}
		if (_ExecScript(command, paramList))
		{
			return true;
		}
		//
		return false;
	}

	static TEntity _SelectEntity<TEntity>() where TEntity : GameUnit
	{
		TEntity entity = null;
		if (entity == null)
		{
			if (HeroController.Instance.FocusEntity != null)
			{
				entity = HeroController.Instance.FocusEntity as TEntity;
			}
		}
		if (entity == null)
		{
			if (CellHero.LocalHero != null)
			{
				entity = CellHero.LocalHero as TEntity;
			}
		}
		return entity;
	}

	static bool _ExecEntity(string command, List<string> paramList)
	{
		command = _ReplaceGM(command, paramList);
		//
		if (command.StartsWith(".") || command.StartsWith("/"))
		{
			if (PlayerCommandInvoker.Exec(Player.Instance, command, paramList))
			{
				ViDebuger.Note("Player.OnGMExec(" + command + ")");
				return true;
			}
			else if (CellPlayerCommandInvoker.Exec(CellPlayer.Instance, command, paramList))
			{
				ViDebuger.Note("CellPlayer.OnGMExec(" + command + ")");
				return true;
			}
			else if (AccountCommandInvoker.Exec(Account.Instance, command, paramList))
			{
				ViDebuger.Note("Account.OnGMExec(" + command + ")");
				return true;
			}
			else if (GameRecordCommandInvoker.Exec(GameRecord.Instance, command, paramList))
			{
				ViDebuger.Note("GameRecord.OnGMExec(" + command + ")");
				return true;
			}
			else
			{
				GameUnit entity = _SelectEntity<GameUnit>();
				if (entity != null)
				{
					if (ViEntityCommandInvoker.Exec(entity, command, paramList))
					{
						ViDebuger.Note(entity.Name + ".OnGMExec(" + command + ")");
						return true;
					}
				}
			}
		}
		else if (command.StartsWith(">"))
		{
			int splitPos = command.IndexOfAny(splitFuncSign);
			if (splitPos == -1)
			{
				return false;
			}
			string entityName = command.Substring(1, splitPos - 1);
			command = command.Substring(splitPos);
			ViEntity entity = null;
			if (StandardAssisstant.EqualsIgnoreCase(entityName, "Account"))
			{
				entity = Account.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "Player"))
			{
				entity = Player.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "CellPlayer"))
			{
				entity = CellPlayer.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "CellHero"))
			{
				entity = _SelectEntity<CellHero>();
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "GameUnit"))
			{
				entity = _SelectEntity<GameUnit>();
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "CellNPC"))
			{
				entity = _SelectEntity<CellNPC>();
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PlayerMailbox"))
			{
				entity = PlayerMailbox.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PlayerFriendList"))
			{
				entity = PlayerFriendList.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PlayerGuild"))
			{
				entity = PlayerGuild.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PlayerOfflineBox"))
			{
				entity = PlayerOfflineBox.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PlayerTrader"))
			{
				entity = PlayerTrader.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "Guild"))
			{
				entity = GuildInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "Party"))
			{
				entity = PartyInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "GameSpaceRecord"))
			{
				entity = GameSpaceRecordInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "GameSpaceFactionRecord"))
			{
				entity = GameSpaceFactionRecordInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PublicSpaceEnter"))
			{
				entity = PublicSpaceEnterInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "PublicSpaceManager"))
			{
				entity = PublicSpaceManagerInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "SpaceMatchManager"))
			{
				entity = SpaceMatchManagerInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "GameRecord"))
			{
				entity = GameRecord.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "TradeManager"))
			{
				entity = TradeManagerInstance.Instance;
			}
			else if (StandardAssisstant.EqualsIgnoreCase(entityName, "CellRecord"))
			{
				entity = CellRecord.Instance;
			}
			else
			{
				entity = GameRecord.Instance;
			}
			//
			if (entity != null)
			{
				if (ViEntityCommandInvoker.Exec(entity, command, paramList))
				{
					ViDebuger.Note(entityName + ".OnGMExec(" + command + ")");
					return true;
				}
			}
		}
		//
		return false;
	}

	static string _ReplaceGM(string command, List<string> paramList)
	{
		GMCommandAliasStruct info = ViSealedDB<GMCommandAliasStruct>.GetData(command.ToLower());
		if (info != null)
		{
			command = info.Func;
			//
			List<string> paramLocalList = new List<string>();
			foreach (GMCommandAliasStruct.ParamStruct iterParam in info.Param.Array)
			{
				if (!string.IsNullOrEmpty(iterParam.Value))
				{
					paramLocalList.Add(iterParam.Value);
				}
			}
			paramList.InsertRange(0, paramLocalList);
		}
		return command;
	}

	static bool _ExecScript(string command, List<string> paramList)
	{
		if (StandardAssisstant.EqualsIgnoreCase(command, "/GC"))
		{
			GameApplication.Instance.GarbageCollection();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ResDeepUnload0"))
		{
			//ResourceManagerInstance.Instance.FreeUseless(true);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ResDeepUnload1"))
		{
			//ResourceManagerInstance.Instance.FreeUseless(false);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintResHold"))
		{
			//ViDebuger.Record("PrintHoldResource:\n" + ResourceHolder.Print());
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintResManager"))
		{
			//StringBuilder strBuilder = new StringBuilder();
			//strBuilder.Append("ResCount=").Append(ResourceManagerInstance.Instance.ResList.Count).Append("/Size=").Append(ResourceManager.TotalSize(ResourceManagerInstance.Instance.ResList)).Append("\n");
			//foreach (KeyValuePair<string, AssetBundleResource> iter in ResourceManagerInstance.Instance.ResList)
			//{
			//	strBuilder.Append(iter.Key).Append(".Size=").Append(iter.Value.Size).Append("/RefCount=").Append(iter.Value.RefCount).Append("\n");
			//}
			//ViDebuger.Record(strBuilder.ToString());
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintResDependency") && paramList.Count == 1)
		{
			//StringBuilder strBuilder = new StringBuilder();
			//string resName = paramList[0];
			//AssetBundleResource res;
			//if (ResourceManagerInstance.Instance.ResList.TryGetValue(resName, out res))
			//{
			//	if (res.Dependencies != null)
			//	{
			//		strBuilder.Append(res.Name).Append(".ResDependencyCount=").Append(res.Dependencies.Count).Append("\n");
			//		for (int iter = 0; iter < res.Dependencies.Count; ++iter)
			//		{
			//			AssetBundleResource iterRes = res.Dependencies[iter];
			//			strBuilder.Append(iterRes.Name).Append("\n");
			//		}
			//	}
			//	else
			//	{
			//		strBuilder.Append(res.Name).Append(".ResDependencyCount=0").Append("\n");
			//	}
			//}
			//else
			//{
			//	strBuilder.Append(resName).Append(" not Exist!").Append("\n");
			//}
			//ViDebuger.Record(strBuilder.ToString());
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintResOwner") && paramList.Count == 1)
		{
			//StringBuilder strBuilder = new StringBuilder();
			//string resName = paramList[0];
			//strBuilder.Append(resName).Append(".ResOwner:").Append("\n");
			//foreach (KeyValuePair<string, AssetBundleResource> iter in ResourceManagerInstance.Instance.ResList)
			//{
			//	if (iter.Value.ContainDependency(resName))
			//	{
			//		strBuilder.Append(iter.Key).Append("\n");
			//	}
			//}
			//ViDebuger.Record(strBuilder.ToString());
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintUnityCache"))
		{
			PrintUnityCaching();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ClearUnityCache"))
		{
#if !UNITY_WEBPLAYER
			PrintUnityCaching();
			Caching.CleanCache();
#endif
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Dump"))
		{
			Player nullPlayer = null;
			nullPlayer.Start();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ReadRunTimeLog"))
		{
			ViDebuger.Record(IOAssisstant.ReadFromPresistent(IOAssisstant.RunTimeLog, "NotExist"));
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Print") && paramList.Count == 1)
		{
			//ViewControllerManager.PrintMSGView.SetMessage(paramList[0]);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/DragDis") && paramList.Count >= 1)
		{
			float value = float.Parse(paramList[0]);
			UICamera camera = GlobalGameObject.Instance.UICamera.GetComponent<UICamera>();
			camera.mouseDragThreshold = value;
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/FitWidth"))
		{
			//UIRoot root = GlobalGameObject.Instance.NGUIRoot;
			//root.fitWidth = !root.fitWidth;
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/RootScale"))
		{
			//UIRoot root = GlobalGameObject.Instance.NGUIRoot;
			//float vale = root.pixelSizeAdjustment;
			//Debug.Log("UIRoot.pixelSizeAdjustment: " + vale);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/InertiaScale") && paramList.Count >= 1)
		{
			float scale;
			if (float.TryParse(paramList[0], out scale))
			{
				UICamera.InertiaDeltaScale = scale;
				ViDebuger.Record("UICamera.InertiaDeltaScale = " + scale);
				return true;
			}
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/HideUI"))
		{
			GlobalGameObject.Instance.UICamera.enabled = false;
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Angle"))
		{
			Vector3 temp = new Vector3(1f, 1f, 0);
			float anle = Vector3.Angle(Vector3.zero, temp);
			ViDebuger.Record(anle.ToString());
			anle = Vector3.Angle(new Vector3(1f, 0, 0), temp);
			ViDebuger.Record(anle.ToString());
			anle = Vector3.Angle(new Vector3(1f, 0, 0), new Vector3(1f, -1f, 0));
			ViDebuger.Record(anle.ToString());
			Quaternion q1 = Quaternion.Euler(0, 0, 10f);
			Quaternion q2 = Quaternion.Euler(0, 0, -10f);
			ViDebuger.Record("q1---->q2: " + Quaternion.Angle(q1, q2));
			ViDebuger.Record("q2---->q1: " + Quaternion.Angle(q2, q1));
			ViDebuger.Record("q1---->q2: " + Quaternion.Lerp(q1, q2, 0.2f).eulerAngles.ToString());
			ViDebuger.Record("q2---->q1: " + Quaternion.Lerp(q2, q1, 0.2f).eulerAngles);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/DPI"))
		{
			ViDebuger.Record("DPI: " + Screen.dpi);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/TimeScale"))
		{
			ViDebuger.Record("TimeScale: " + Time.timeScale + "; TimeDelta: " + Time.deltaTime);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Login"))
		{
			//ViewControllerManager.LoginView.Open();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Debug"))
		{
			//ViewControllerManager.DebugView.Open();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ClearDebugWin"))
		{
			//ViewControllerManager.DebugView.ClearLog();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/CopyDebugWin"))
		{
			//ViewControllerManager.DebugView.CopyLog();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Message") && paramList.Count >= 1)
		{
			//ViewControllerManager.CenterMessageView.ShowMessage(paramList[0]);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/RimStart"))
		{
			if (CellHero.LocalHero != null)
			{
				CellHero.LocalHero.VisualBody.CreateGhost("RimLatent", true, null, null);
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/RimEnd"))
		{
			if (CellHero.LocalHero != null)
			{
				CellHero.LocalHero.VisualBody.ClearGhost("RimLatent");
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Ping"))
		{
			UInt64 time = (UInt64)(UnityEngine.Time.realtimeSinceStartup * 1000);
			Exec(">CellPlayer.OnPing " + time);
			Exec(">Player.OnPing " + time);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetLogLevel"))
		{
			Int32 level = Int32.Parse(paramList[0]);
			ViDebuger.LogLevel = (ViLogLevel)level;
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetQualityLevel"))
		{
			Int32 level = Int32.Parse(paramList[0]);
			QualitySettings.SetQualityLevel(level);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ShowNav"))
		{
			if (GameSpace.ActiveInstance != null)
			{
				GameSpace.ActiveInstance.Navigator.ShowNavigate();
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/HideNav"))
		{
			if (GameSpace.ActiveInstance != null)
			{
				GameSpace.ActiveInstance.Navigator.ClearNavigateShow();
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ModNavBlock") && paramList.Count == 2)
		{
			Int32 range, deltaValue;
			if (Int32.TryParse(paramList[0], out range) && Int32.TryParse(paramList[1], out deltaValue))
			{
				if (GameSpace.ActiveInstance != null)
				{
					GameSpace.ActiveInstance.Navigator.ModNavigateBlock(CellHero.LocalHero.Position, range, deltaValue);
				}
				return true;
			}
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetFrameRate") && paramList.Count == 1)
		{
			Int32 value;
			if (Int32.TryParse(paramList[0], out value))
			{
				Application.targetFrameRate = value;
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/vSyncCount") && paramList.Count == 1)
		{
			Int32 type;
			if (Int32.TryParse(paramList[0], out type))
			{
				QualitySettings.vSyncCount = type;
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetResolution") && paramList.Count == 2)
		{
			Int32 widthX;
			Int32 widthY;
			if (Int32.TryParse(paramList[0], out widthX) && Int32.TryParse(paramList[1], out widthY))
			{
				Screen.SetResolution(widthX, widthY, true);
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetCameraDistance") && paramList.Count == 2)
		{
			float distanceInf;
			float distanceSup;
			if (float.TryParse(paramList[0], out distanceInf) && float.TryParse(paramList[1], out distanceSup))
			{
				CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
				if (camera != null)
				{
					CursorCamera.ConfigStruct inf = camera.Inf;
					CursorCamera.ConfigStruct sup = camera.Sup;
					inf.Distance = distanceInf;
					sup.Distance = distanceSup;
					camera.SetConfig(inf, sup);
				}
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetCameraPitch") && paramList.Count == 2)
		{
			float pitchInf;
			float pitchSup;
			if (float.TryParse(paramList[0], out pitchInf) && float.TryParse(paramList[1], out pitchSup))
			{
				CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
				if (camera != null)
				{
					CursorCamera.ConfigStruct inf = camera.Inf;
					CursorCamera.ConfigStruct sup = camera.Sup;
					inf.Pitch = pitchInf;
					sup.Pitch = pitchSup;
					camera.SetConfig(inf, sup);
				}
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/BroadcastPing") && paramList.Count == 2)
		{
			UInt32 count;
			UInt32 span;
			if (UInt32.TryParse(paramList[0], out count) && UInt32.TryParse(paramList[1], out span))
			{
				_tickPing.Delegate = OnTimePing;
				_tickPing.Start(ViTimerInstance.Timer, count, span);
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/SetTimeScale") && paramList.Count == 1)
		{
			float scale;
			if (float.TryParse(paramList[0], out scale))
			{
				GameTimeScale.SetVisual(scale);
			}
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintSystemInfo"))
		{
			string log = string.Empty;
			log += "deviceModel:" + SystemInfo.deviceModel + "\n";
			log += "deviceName:" + SystemInfo.deviceName + "\n";
			log += "deviceType:" + SystemInfo.deviceType + "\n";
			log += "deviceUniqueIdentifier:" + SystemInfo.deviceUniqueIdentifier + "\n";
			log += "graphicsDeviceID:" + SystemInfo.graphicsDeviceID + "\n";
			log += "graphicsDeviceName:" + SystemInfo.graphicsDeviceName + "\n";
			log += "graphicsDeviceType:" + SystemInfo.graphicsDeviceType + "\n";
			log += "graphicsDeviceVendor:" + SystemInfo.graphicsDeviceVendor + "\n";
			log += "graphicsDeviceVendorID:" + SystemInfo.graphicsDeviceVendorID + "\n";
			log += "graphicsDeviceVersion:" + SystemInfo.graphicsDeviceVersion + "\n";
			log += "graphicsMemorySize:" + SystemInfo.graphicsMemorySize + "\n";
			log += "graphicsMultiThreaded:" + SystemInfo.graphicsMultiThreaded + "\n";
			log += "graphicsShaderLevel:" + SystemInfo.graphicsShaderLevel + "\n";
			log += "maxTextureSize:" + SystemInfo.maxTextureSize + "\n";
			log += "npotSupport:" + SystemInfo.npotSupport + "\n";
			log += "operatingSystem:" + SystemInfo.operatingSystem + "\n";
			log += "processorCount:" + SystemInfo.processorCount + "\n";
			log += "processorFrequency:" + SystemInfo.processorFrequency + "\n";
			log += "processorType:" + SystemInfo.processorType + "\n";
			log += "supportedRenderTargetCount:" + SystemInfo.supportedRenderTargetCount + "\n";
			log += "supports3DTextures:" + SystemInfo.supports3DTextures + "\n";
			log += "supportsAccelerometer:" + SystemInfo.supportsAccelerometer + "\n";
			log += "supportsComputeShaders:" + SystemInfo.supportsComputeShaders + "\n";
			log += "supportsGyroscope:" + SystemInfo.supportsGyroscope + "\n";
			log += "supportsImageEffects:" + SystemInfo.supportsImageEffects + "\n";
			log += "supportsInstancing:" + SystemInfo.supportsInstancing + "\n";
			log += "supportsLocationService:" + SystemInfo.supportsLocationService + "\n";
			log += "supportsRawShadowDepthSampling:" + SystemInfo.supportsRawShadowDepthSampling + "\n";
			log += "supportsRenderTextures:" + SystemInfo.supportsRenderTextures + "\n";
			log += "supportsRenderToCubemap:" + SystemInfo.supportsRenderToCubemap + "\n";
			log += "supportsShadows:" + SystemInfo.supportsShadows + "\n";
			log += "supportsSparseTextures:" + SystemInfo.supportsSparseTextures + "\n";
			log += "supportsStencil:" + SystemInfo.supportsStencil + "\n";
			log += "supportsVibration:" + SystemInfo.supportsVibration + "\n";
			log += "systemMemorySize:" + SystemInfo.systemMemorySize + "\n";
			Print(ref log, TextureFormat.DXT1);
			Print(ref log, TextureFormat.DXT5);
#if UNITY_EDITOR_WIN
			Print(ref log, TextureFormat.DXT1Crunched);
			Print(ref log, TextureFormat.DXT5Crunched);
#endif
			Print(ref log, TextureFormat.PVRTC_RGB2);
			Print(ref log, TextureFormat.PVRTC_RGBA2);
			Print(ref log, TextureFormat.PVRTC_RGB4);
			Print(ref log, TextureFormat.PVRTC_RGBA4);
			Print(ref log, TextureFormat.ETC_RGB4);
			Print(ref log, TextureFormat.ATC_RGB4);
			Print(ref log, TextureFormat.ATC_RGBA8);
			Print(ref log, TextureFormat.ETC2_RGB);
			Print(ref log, TextureFormat.ETC2_RGBA1);
			Print(ref log, TextureFormat.ETC2_RGBA8);
			Print(ref log, TextureFormat.RGBAHalf);
			Print(ref log, TextureFormat.RGBAFloat);
			ViDebuger.Record(log);
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintScreen"))
		{
			string log = string.Empty;
			log += "currentResolution:" + Screen.currentResolution + "\n";
			log += "dpi:" + Screen.dpi + "\n";
			log += "height:" + Screen.height + "\n";
			log += "width:" + Screen.width + "\n";
			log += "sleepTimeout:" + Screen.sleepTimeout + "\n";
			ViDebuger.Record(log);
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/PrintNet"))
		{
			ViDebuger.Record("Net: " + Application.internetReachability);
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/Reconnect"))
		{
			//ViewControllerManager.OnNetDisconnnect("Reconnect");
			Client.Current.CloseConnect();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ReLogin"))
		{
			//ViewControllerManager.OnReconnectFailed("ReLogin");
			Client.Current.CloseConnect();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/ActiveGameObject") && paramList.Count == 1)
		{
			List<GameObject> objList = new List<GameObject>();
			SelectGameObject(paramList[0], objList);
			SetActive(objList, true);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/DeactiveGameObject") && paramList.Count == 1)
		{
			List<GameObject> objList = new List<GameObject>();
			SelectGameObject(paramList[0], objList);
			SetActive(objList, false);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/GMMail"))
		{
			MailProperty mail = new MailProperty();
			mail.Title = "16:00临时维护公告";
			mail.Content = " 很抱歉，我们将于16:15进行不停机维护。重新登入游戏即可。\n本次维护主要修复暴走玩偶的积分商城中部分道具价格错误。\n本次维护后每个玩家将补偿：晶石代抽券（十连） *1\n感谢您对我们游戏的支持。";
			mail.Time1970 = ViTimerInstance.Time1970;
			mail.AttachmentItems.E0.Info.Set(110004);
			mail.AttachmentItems.E0.Count = 1;
			mail.Type = 3;
			GMRequestProperty request = new GMRequestProperty();
			request.LevelInf = 0;
			request.LevelSup = 100;
			GameRecordCommandInvoker.AddMail(GameRecord.Instance, 1, request, mail);
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/NetSleep"))
		{
			GameApplication.Instance.ClearLogProcess();
			NetWorkProcess.Instance.Start();
			return true;
		}
		else if (StandardAssisstant.EqualsIgnoreCase(command, "/NetAwake"))
		{
			GameApplication.Instance.ResetLogProcess();
			NetWorkProcess.Instance.End(GameApplication.Instance.Client.UpdateNetInput);
			return true;
		}
		//
		return false;
	}

	static void SelectGameObject(string name, List<GameObject> list)
	{
		UnityEngine.Object[] objArray = UnityEngine.Resources.FindObjectsOfTypeAll(typeof(Transform));
		for (int iter = 0; iter < objArray.Length; ++iter)
		{
			Transform iterTran = (Transform)objArray[iter];
			GameObject iterObj = iterTran.gameObject;
			if (StandardAssisstant.EqualsIgnoreCase(iterObj.name, name))
			{
				list.Add(iterObj);
			}
		}
	}

	static void SetActive(List<GameObject> list, bool value)
	{
		for (int iter = 0; iter < list.Count; ++iter)
		{
			list[iter].SetActive(value);
		}
	}

	//+-

	public static void PrintUnityCaching()
	{
		StringBuilder log = new StringBuilder();
		log.Append("compressionEnabled:").Append(Caching.compressionEnabled).Append("\n");
		log.Append("enabled:").Append(Caching.enabled).Append("\n");
		log.Append("expirationDelay:").Append(Caching.expirationDelay).Append("\n");
		log.Append("maximumAvailableDiskSpace:").Append(Caching.maximumAvailableDiskSpace).Append("\n");
		log.Append("ready:").Append(Caching.ready).Append("\n");
		log.Append("spaceFree:").Append(Caching.spaceFree).Append("\n");
		log.Append("spaceOccupied:").Append(Caching.spaceOccupied).Append("\n");
		ViDebuger.Record(log.ToString());
	}

	static ViTimeNode2 _tickPing = new ViTimeNode2();
	static void OnTimePing(ViTimeNodeInterface node)
	{
		Exec(">CellHero.BroadcastPing");
	}

	static void Print(ref string log, TextureFormat format)
	{
		log += "SupportsTextureFormat(" + format + ") = " + SystemInfo.SupportsTextureFormat(format) + "\n";
	}


}