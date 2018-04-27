using UnityEngine;
using System.Collections;
using System;

/********************************************************************
	created:	2017/06/26
	created:	26:6:2017   20:04
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\PlayCameraAnimator.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts
	file base:	PlayCameraAnimator
	file ext:	cs
	author:		zlj
	
	purpose:	播放相机动画
*********************************************************************/
public class PlayCameraAnimator : MonoBehaviour
{
    private Animator animator = null;
    private Action animatorEnd = null;
    private GameObject _storyCamObj = null;

    public float fieldOfView = 45;
    public float nearClippingPlanes = 0.1f;
    public float FarClippingPlanes = 300f;

    private ViTimeNode1 _node1 = new ViTimeNode1();
    ViTimeNode4 timeCallBack;

    public void Initialize()
    {
        animator = GetComponent<Animator>(); 
    }
    public void Play(PlayCameraAnimatorData cameraAnimatorData, GameObject storyCamObj, Action callBack)
    {
        _storyCamObj = storyCamObj;
        animatorEnd = callBack;
        animator.Play(cameraAnimatorData.cameraAnimatorName);
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        UConsole.Log(UConsoleDefine.Story, "Play CameraPath,animatorName:{0},duration:{1}", cameraAnimatorData.cameraAnimatorName, info.length);

        if (info.length > 0)
        {
            ViTimerInstance.SetTime(_node1, Mathf.CeilToInt(info.length * 100), _OnWaitForAnimatorEnd);
            AddCameraController();
            fieldOfView = CameraController.Instance.Camera.fieldOfView;
            nearClippingPlanes = CameraController.Instance.Camera.nearClipPlane;
            FarClippingPlanes = CameraController.Instance.Camera.farClipPlane;
            CameraController.Instance.Camera.fieldOfView = cameraAnimatorData.fieldOfView;
            CameraController.Instance.Camera.nearClipPlane = cameraAnimatorData.nearClippingPlanes;
            CameraController.Instance.Camera.farClipPlane = cameraAnimatorData.FarClippingPlanes;
        }
        else
        {
            _OnWaitForAnimatorEnd(null);
        }
    }
    [Obsolete]
    public void Play(string animatorName,GameObject storyCamObj, Action callBack)
    {
        _storyCamObj = storyCamObj;
        animatorEnd = callBack;
        animator.Play(animatorName);
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        UConsole.Log(UConsoleDefine.Story, "Play CameraPath,animatorName:{0},duration:{1}",animatorName,info.length);

        if (info.length > 0)
        {
            ViTimerInstance.SetTime(_node1, Mathf.CeilToInt(info.length * 100), _OnWaitForAnimatorEnd);
            AddCameraController();
        }
        else
        {
            _OnWaitForAnimatorEnd(null);
        }
    }

    private void _OnWaitForAnimatorEnd(ViTimeNodeInterface nodeInterface)
    {
        UConsole.Log(UConsoleDefine.Story, "_OnWaitForAnimatorEnd");
        RemoveCameraController();
        animator = null;
        CameraEffectMgr.Instance.RemoveCameraAnimator(this);
        if (animatorEnd != null)
            animatorEnd();
        animatorEnd = null;
        GameObject.Destroy(gameObject);
    }
    private void AddCameraController()
    {
        timeCallBack = new ViTimeNode4();
        timeCallBack.Start(ViTimerRealInstance.Timer, 1, this.SetCameraPos);
        CameraController.Instance.IsPlayStoryCam = true;
    }
    private void RemoveCameraController()
    {
        timeCallBack.Detach();
        CameraController.Instance.IsPlayStoryCam = false;
        CameraController.Instance.Camera.fieldOfView = fieldOfView;
        CameraController.Instance.Camera.nearClipPlane = nearClippingPlanes;
        CameraController.Instance.Camera.farClipPlane = FarClippingPlanes;
    }
    private void SetCameraPos(ViTimeNodeInterface node)
    {
        GlobalGameObject.Instance.SceneCamera.transform.position = _storyCamObj.transform.position;
        GlobalGameObject.Instance.SceneCamera.transform.rotation = _storyCamObj.transform.rotation;
    }
}
