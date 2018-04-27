using UnityEngine;
using System.Collections;

public class StoryCDCameraItem : StoryCDItem
{
    public Camera Camera;
    private StoryCDCameraInfo Info = new StoryCDCameraInfo();
    private ViTimeNode4 timeCallBack;

    public void SetInfo(StoryCDCameraInfo info)
    {
        Info = info;

        if (Camera.IsNotNull())
        {
            Camera.allowHDR = info.AllowHDR;
            Camera.allowMSAA = info.AllowMSAA;
        }
    }

    [ContextMenu("Init")]
    public override void Init()
    {
        if (Info == null)
        {
            return;
        }
        EventDispatcher.AddEventListener<Camera, bool>(Events.StoryEvent.CinemaDirectorCameraEvent,CallBack);
    }

    public override void Clear()
    {
        EventDispatcher.RemoveEventListener<Camera, bool>(Events.StoryEvent.CinemaDirectorCameraEvent, CallBack);

        Info = null;
    }

    private void CallBack(Camera camera,bool start)
    {
        if (camera == null)
        {
            return;
        }
        if (!camera.Equals(Camera))
        {
            return;
        }
        if (start)
        {
            AddCameraController();
        }
        else
        {
            RemoveCameraController();
        }
    }

    private void AddCameraController()
    {
        if (CameraController.Instance == null || 
            CameraController.Instance.Camera == null)
        {
            return;
        }

        timeCallBack = new ViTimeNode4();
        timeCallBack.Start(ViTimerRealInstance.Timer, 1, this.SetCameraPos);

        CameraController.Instance.IsPlayStoryCam = true;

        Info.FieldOfView = CameraController.Instance.Camera.fieldOfView;
        Info.NearClipPlane = CameraController.Instance.Camera.nearClipPlane;
        Info.FarClipPlane = CameraController.Instance.Camera.farClipPlane;

        CameraController.Instance.Camera.fieldOfView = Camera.fieldOfView;
        CameraController.Instance.Camera.nearClipPlane = Camera.nearClipPlane;
        CameraController.Instance.Camera.farClipPlane = Camera.farClipPlane;
    }
    private void RemoveCameraController()
    {
        if (CameraController.Instance == null ||
            CameraController.Instance.Camera == null)
        {
            return;
        }

        timeCallBack.Detach();

        CameraController.Instance.IsPlayStoryCam = false;

        CameraController.Instance.Camera.fieldOfView = Info.FieldOfView;
        CameraController.Instance.Camera.nearClipPlane = Info.NearClipPlane;
        CameraController.Instance.Camera.farClipPlane = Info.FarClipPlane;
    }

    private void SetCameraPos(ViTimeNodeInterface node)
    {
        GlobalGameObject.Instance.SceneCamera.transform.position = transform.position;
        GlobalGameObject.Instance.SceneCamera.transform.rotation = transform.rotation;
    }
}
