using System;
using System.Collections.Generic;
using UnityEngine;

using UInt8 = System.Byte;


public class GameSpace
{
	public static GameSpace ActiveInstance { get { return _activeInstance; } }
	static GameSpace _activeInstance;

	public SpaceStruct LogicInfo { get { return _logicInfo; } }
	public VisualSpaceStruct VisualInfo { get { return _visualInfo; } }
	public SpaceNavigator Navigator { get { return _controller.Navigator; } }
	public SpaceController Controller { get { return _controller; } }
	public ViDelegateAssisstant.Dele LoadCompleteCallback;
	public static Transform GetCamera(GameObject ground)
	{
		return ground.transform.GetChildRecursively("View");
	}

	public void Load(SpaceStruct logicInfo, VisualSpaceStruct visualInfo)
	{
        UIManagerUtility.ShowLoading();
        EventDispatcher.TriggerEvent(Events.SpaceEvent.SpaceLoadStart);
        
        _logicInfo = logicInfo;
		_visualInfo = ViSealedDB<VisualSpaceStruct>.Data(logicInfo.ID);
		_controller.CallbackCompleted = this.OnLoad;
		_controller.Load(logicInfo.Config.Data);
		//
		GameApplication.Instance.MusicManager.Add(GameKeyWord.Space, 10, visualInfo.Music.Data);
		//
		_activeInstance = this;
	}

	public void Clear()
	{
		CameraController.Instance.Clear();
		if (_controller != null)
		{
			GameApplication.Instance.MusicManager.Del(GameKeyWord.Space);
		}
		//
		_activeInstance = null;
		//
		_controller.Clear();
        UIManagerUtility.OnLeaveSpace();
	}

	void OnLoad()
	{
        //_controller.View.SetActive(false);
        //
        
        UIGoManager.Instance.Load("SuperTextManager", (string name, object obj1) =>
        {
        });
        UIRoleDataManager.GetInstance.Clear();
		ViDelegateAssisstant.Invoke(LoadCompleteCallback);
	}

	ViProvider<ViVector3> GetCameraPos(ViProvider<ViVector3> localEntityPos)
	{
		SpaceCameraStruct cameraInfo = VisualInfo.Camera.Camera.Data;
		if (cameraInfo.Free == (Int32)BoolValue.TRUE)
		{
			return new ViSimpleProvider<ViVector3>(LogicInfo.EnterPosition);
		}
		else
		{
			return localEntityPos;
		}
	}

	ViProvider<ViAngle> GetCameraYaw(ViProvider<ViAngle> localEntityYaw)
	{
		SpaceCameraStruct cameraInfo = VisualInfo.Camera.Camera.Data;
		if (cameraInfo.Free == (Int32)BoolValue.TRUE)
		{
			return new ViSimpleProvider<ViAngle>(new ViAngle(0));
		}
		else
		{
			return localEntityYaw;
		}
	}

	public void UpdateCameraController(Int32 factionIdx, ViProvider<ViVector3> entityPos, ViProvider<ViAngle> entityYaw)
	{
        //entityYaw.SetValue(1.57f);
        //_controller.View.SetActive(true);
        //Camera camera = _controller.View.transform.GetComponentInChildren<Camera>();
        //ViDebuger.AssertError(camera);
        //
        //entityYaw.Value = new ViAngle(180.0f);
        CameraController.Instance.SetCamera(GlobalGameObject.Instance.SceneCamera, GlobalGameObject.Instance.SceneCamera.transform);
		//
		CursorCamera cursorCamera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
		if (cursorCamera == null)
		{
			cursorCamera = new CursorCamera();
			cursorCamera.FrontScale.DefaultValue = CursorCamera.VALUE_CameraHorizOffsetScale;
			if (VisualInfo.Camera.Override == (Int32)BoolValue.TRUE)
			{
				cursorCamera.Yaw = VisualInfo.Camera.Yaw[factionIdx] * 0.01f;
			}
			CameraController.Instance.AddController("CursorCamera", 5, cursorCamera);
		}
		//
		SpaceCameraStruct cameraInfo = VisualInfo.Camera.Camera.Data;
		CursorCamera.ConfigStruct inf = DataExAssisstant.Convert(cameraInfo.Inf);
		CursorCamera.ConfigStruct sup = DataExAssisstant.Convert(cameraInfo.Sup);
		cursorCamera.SetConfig(inf, sup);
		cursorCamera.SetTarget(GetCameraPos(entityPos), GetCameraYaw(entityYaw));
		cursorCamera.Update(0.0f);
		//
		CameraController.Instance.SmoothImmediate();
		CameraController.Instance.Update(0.0f, true);
		//
		ViewConfig viewConfig = GameSpace.ActiveInstance.Controller.ViewConfigProperty;
		if (viewConfig != null)
		{
			viewConfig.InitViewCameraInfo();
		}
	}

	static void SetLayer(GameObject obj, string childName, Int32 value)
	{
		Transform childTransform = obj.transform.Find(childName);
		if (childTransform != null)
		{
			UnityAssisstant.SetLayerRecursively(childTransform.gameObject, value);
		}
	}

	SpaceController _controller = new SpaceController();
	GameObject _localEntityRes;
	SpaceStruct _logicInfo;
	VisualSpaceStruct _visualInfo;
}
