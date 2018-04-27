using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:08
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunBlinkOfAnEye.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunBlinkOfAnEye
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class StoryFunBlinkOfAnEye : StoryFunBase
{
    private StoryFunctionCameraBlinkOfAnEyeData _blinkEyeData;
    /// 眨眼是否结束
    private bool IsPlayCameraBlinkOfAnEyeEnd = false;

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);
        _blinkEyeData = data.blinkOfAnEyeData;
        //眨眼
        PlayCameraBlinkOfAnEye();
    }

    /// <summary>
    /// 播放眨眼
    /// </summary>
    public void PlayCameraBlinkOfAnEye()
    {
        CameraEffectMgr.Instance.PlayBlinkOfAnEye(_blinkEyeData.cameraBlinkOfAnEyeInfo, CameraBlinkOfAnEyeCallBack);
    }

    public void CameraBlinkOfAnEyeCallBack()
    {
        End();
    }

    public void End()
    {
        EndCallBack();
        Clear();
    }

    public void Clear()
    {
        _callBack = null;
    }

    public override void Stop()
    {
        End();
    }
}
