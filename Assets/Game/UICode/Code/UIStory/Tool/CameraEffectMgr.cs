using UnityEngine;
using System;
using System.Collections.Generic;

/********************************************************************
	created:	2017/01/18
	created:	18:1:2017   16:28
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\CameraEffectMgr.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts
	file base:	CameraEffectMgr
	file ext:	cs
	author:		zlj
	
	purpose:	相机效果管理器
*********************************************************************/
public class CameraEffectMgr
{
    private static CameraEffectMgr instance = null;
    public static CameraEffectMgr Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new CameraEffectMgr();
            }
            return instance;
        }
    }
    /// <summary>
    /// 相机眨眼效果
    /// </summary>
    private CameraBlinkOfAnEye cameraEye = null;
    /// <summary>
    /// 相机动画列表
    /// </summary>
    private List<PlayCameraAnimator> cameraAnimaList = new List<PlayCameraAnimator>();

    /// <summary>
    /// 播放相机眨眼功能
    /// </summary>
    /// <param name="info"></param>
    /// <param name="callBack"></param>
    public void PlayBlinkOfAnEye(CameraBlinkOfAnEyeInfo info, Action callBack)
    {
        if (info == null)
        {
            if (callBack != null)
                callBack();
            return;
        }
        if (cameraEye == null)
        {
            GameObject temp = UnityTools.LoadGameObject(
                string.Format("{0}/{1}", StoryStaticData.STORYPATH, StoryStaticData.CameraBlinkOfAnEye), null);
            if (temp != null)
            {
                cameraEye = temp.AddComponent<CameraBlinkOfAnEye>();
                cameraEye.Initialize();
                cameraEye.blinkCamera = temp.GetComponentInChildren<Camera>();
            }
        }
        if (cameraEye == null)
        {
            UConsole.LogError("加载相机眨眼UI失败。");
            if (null != callBack)
                callBack();
        }
        else
            cameraEye.Play(info, callBack);
    }
    /// <summary>
    /// 播放相机动画功能
    /// </summary>
    /// <param name="info"></param>
    /// <param name="callBack"></param>
    public Camera PlayCameraPath(PlayCameraAnimatorData cameraAnimatorData,Action callBack)
    {
        PlayCameraAnimator camAnimator = null;
        //Camera cam = null;
        GameObject temp = UnityTools.LoadGameObject(cameraAnimatorData.cameraPath, null);
        GameObject obj = null;

        if (temp != null)
        {
            temp.name = "StoryCameraPath";
            camAnimator = temp.AddComponent<PlayCameraAnimator>();
            camAnimator.Initialize();

            obj = new GameObject("StoryCamera");
            //cam = obj.AddComponent<Camera>();
            obj.transform.SetParent(temp.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localEulerAngles = cameraAnimatorData.cameraAngle;
            obj.transform.localScale = Vector3.one;
        }
        else
        {
            UConsole.LogError("加载相机动画失败。");
            if (null != callBack)
                callBack();
        }
        if (camAnimator != null)
        {
            cameraAnimaList.Add(camAnimator);
            camAnimator.Play(cameraAnimatorData, obj, callBack);
        }
        return CameraController.Instance.Camera;
    }
    public void RemoveCameraAnimator(PlayCameraAnimator cameraAnimator)
    {
        if (cameraAnimator != null)
            cameraAnimaList.Remove(cameraAnimator);
    }
    public bool IsPlayingCameraPath()
    {
        return cameraAnimaList.Count > 0;
    }
}
