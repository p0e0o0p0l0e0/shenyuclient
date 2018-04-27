using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:08
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunCamera.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunCamera
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class StoryFunCamera : StoryFunBase
{
    private StoryFunctionCameraData _cameraData;

    private bool IsCameraEnd = false;

    private string currentLayer = null;

    private CameraShake shake = CameraShake.instance;

    private ViTimeNode1 _node1 = new ViTimeNode1();

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);
        _cameraData = data.cameraData;

        PlayCamera();
    }

    /// <summary>
    /// 播放相机路径
    /// </summary>
    public void PlayCamera()
    {
        //播放相机路径
        if (string.IsNullOrEmpty(_cameraData.cameraAnimatorData.cameraPath))
        {
            CameraEnd();
        }
        else
        {
            Camera camera = CameraEffectMgr.Instance.PlayCameraPath(_cameraData.cameraAnimatorData, CameraEndCallBack);
            if (camera != null)
            {
                if (_cameraData.isHidePlayer)
                    StoryManager.GetInstance.SetPlayerState(false);
                if (_cameraData.cameraAnimatorData.audioListenerPos != Vector3.zero)
                    EventDispatcher.TriggerEvent<bool, Vector3>(Events.StoryEvent.ChangeCamera, true, _cameraData.cameraAnimatorData.audioListenerPos);
                SetLayer(camera, Layers.Story, _cameraData.highOffset);
                camera.depth = 1;

                PlayCameraShake();
            }
        }
    }
    public void PlayCameraShake()
    {
        if (_cameraData.cameraShakeInfos.Count > 0)
        {
            _cameraData.cameraShakeInfos.Sort();

            NextShakeCamera(0, 0);
        }
    }
    /// <summary>
    /// 播放晃动
    /// </summary>
    /// <returns></returns>
    private void NextShakeCamera(int flag, float pretime)
    {
        if (_cameraData.cameraShakeInfos.Count > flag)
            StoryManager.GetInstance.SetTime(_node1,
                _cameraData.cameraShakeInfos[flag].ShakeTime - pretime,
                (noteInterface) => { ShakeCamera(flag, pretime); });
    }
    private void ShakeCamera(int flag, float pretime)
    {
        pretime = _cameraData.cameraShakeInfos[flag].ShakeTime;
        if (!shake.IsShakeing)
        {
            shake.IsShakeing = true;
            if (!shake.IsDebug)
            {
                shake.numberOfShakes = _cameraData.cameraShakeInfos[flag].numberOfShakes;
                shake.shakeAmount = _cameraData.cameraShakeInfos[flag].shakeAmount;
                shake.rotationAmount = _cameraData.cameraShakeInfos[flag].rotationAmount;
                shake.distance = _cameraData.cameraShakeInfos[flag].distance;
                shake.speed = _cameraData.cameraShakeInfos[flag].speed;
                shake.decay = _cameraData.cameraShakeInfos[flag].decay;
            }
            CameraShake.Shake();
        }
        NextShakeCamera(++flag, pretime);
    }
    public void CameraEndCallBack()
    {
        if (!CameraEffectMgr.Instance.IsPlayingCameraPath())
        {
            EventDispatcher.TriggerEvent<bool, Vector3>(Events.StoryEvent.ChangeCamera, false, Vector3.zero);
            SetLayer(StoryManager.GetInstance.GetMainCamera(), Layers.UI, 3.5f);
        }
        if (_cameraData.isHidePlayer)
            StoryManager.GetInstance.SetPlayerState(true);

        CameraEnd();
    }
    public bool IsEnd()
    {
        return  IsCameraEnd;
    }
    public void CameraEnd()
    {
        IsCameraEnd = true;
        if (IsEnd())
            End();
    }
    /// <summary>
    /// 设置层级
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="layerName"></param>
    public void SetLayer(Camera camera, int layer, float highOffset)
    {
        currentLayer = LayerMask.LayerToName(layer);
        Camera cam = StoryManager.GetInstance.GetUICamera();
        if (cam != null)
            cam.cullingMask = 1 << layer;
        StoryManager.GetInstance.UIController.SetLayer(layer);
        //修改冒泡层级
        if (camera != null)
        {
            StoryCharacterFactory.ChangeCharacterBubblingLayer(layer, camera, highOffset);
            UConsole.Log("设置相机层级: " + currentLayer + ",CameraName:" + camera.gameObject.name + "," + camera.transform.parent + "," + highOffset);
        }
        else
            UConsole.LogError("设置相机层级:" + currentLayer + ",没有找到相机");
    }

    public void End()
    {
        EndCallBack();
        Clear();
    }

    public void Clear()
    {
        IsCameraEnd = false;
        
        _callBack = null;

        _node1.Detach();

        currentLayer = null;
    }

    public override void Stop()
    {
        if (!CameraEffectMgr.Instance.IsPlayingCameraPath())
        {
            EventDispatcher.TriggerEvent<bool, Vector3>(Events.StoryEvent.ChangeCamera, false, Vector3.zero);
            SetLayer(StoryManager.GetInstance.GetMainCamera(), Layers.UI, 3.5f);
        }
        if (_cameraData.isHidePlayer)
            StoryManager.GetInstance.SetPlayerState(true);

        End();
    }
}
