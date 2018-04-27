using UnityEngine;
using System.Collections;
using System;

/********************************************************************
	created:	2017/01/18
	created:	18:1:2017   16:33
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\CameraBlinkOfAnEye.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	CameraBlinkOfAnEye
	file ext:	cs
	author:		zlj
	
	purpose:	相机眨眼功能
*********************************************************************/
public class CameraBlinkOfAnEye : MonoBehaviour
{
    /// <summary>
    /// 模糊脚本
    /// </summary>
    //private BlurEffect blurEffect = null;
    private float currentIterations = 0;
    private const int MinIterations = 0;
    private const int MaxIterations = 40;
    private const string ShaderName = "Hidden/FastBlur";
    public Camera blinkCamera;

    /// <summary>
    /// 眨眼图片
    /// </summary>
    private UITexture texEye = null;
    /// <summary>
    /// 下背景图
    /// </summary>
    private UITexture texBGDown = null;
    /// <summary>
    /// 上背景图
    /// </summary>
    private UITexture texBGUp = null;

    /// <summary>
    /// 结束回调
    /// </summary>
    private Action EndCallBack = null;

    private const float MaxHeight = 760;
    public float OpenSpeed = 40;
    public float CloseSpeed = 40;

    private bool IsPlaying = false;

    /// <summary>
    /// 初始化
    /// </summary>
    public void Initialize()
    {
        texEye = transform.Find("Eye").GetComponent<UITexture>();
        texBGDown = transform.Find("BgDown").GetComponent<UITexture>();
        texBGUp = transform.Find("BgUp").GetComponent<UITexture>();
    }
    public void Reset()
    {
        OpenSpeed = 40;
        CloseSpeed = 40;
        SetHeight(0, MaxHeight);
    }
    /// <summary>
    /// 播放
    /// </summary>
    /// <param name="callBack"></param>
    public void Play(CameraBlinkOfAnEyeInfo info,Action callBack)
    {
        if (IsPlaying)
        {
            UConsole.LogError("正在播放眨眼中，不要同时调用.");
            return;
        }
        IsPlaying = true;
        Reset();
        EndCallBack = callBack;
        gameObject.SetActive(true);
        SetActive(false);
        StartCoroutine(PlayEffect(info));
    }
    //TODO zlj 有待优化
    IEnumerator PlayEffect(CameraBlinkOfAnEyeInfo info)
    {
        float currentHeight = 0;
        float currentBGHeight = (MaxHeight - currentHeight);

        for (int i = 0; i < info.blinkOfAnEyeList.Count; i++)
        {
            InitBlurEffect();
            OpenSpeed = info.blinkOfAnEyeList[i].blinkOpenSpeed;
            CloseSpeed = info.blinkOfAnEyeList[i].blinkCloseSpeed;
            if (info.blinkOfAnEyeList[i].blinkDuration > 0)
                yield return new WaitForSeconds(info.blinkOfAnEyeList[i].blinkDuration);
            SetActive(true);
            SetBlurEffectState(true);

            while (currentHeight < MaxHeight)
            {
                SetHeight(currentHeight, currentBGHeight);
                yield return new WaitForFixedUpdate();
                currentHeight += OpenSpeed / Time.timeScale;
                if (currentHeight > MaxHeight)
                    currentHeight = MaxHeight;
                currentBGHeight = (MaxHeight - currentHeight);

                currentIterations = currentBGHeight / MaxHeight * (MaxIterations - MinIterations);
                if (currentIterations < MinIterations)
                    currentIterations = MinIterations;
                SetIterations(Mathf.FloorToInt(currentIterations));
            }

            SetBlurEffectState(false);

            SetHeight(currentHeight, currentBGHeight);
            if (info.blinkOfAnEyeList[i].blinkOpenCloseDuration > 0)
                yield return new WaitForSeconds(info.blinkOfAnEyeList[i].blinkOpenCloseDuration);

            SetBlurEffectState(true);

            while (currentHeight > 0)
            {
                SetHeight(currentHeight, currentBGHeight);
                yield return new WaitForFixedUpdate();
                currentHeight -= CloseSpeed / Time.timeScale;
                if (currentHeight < 0)
                    currentHeight = 0;
                currentBGHeight = (MaxHeight - currentHeight);

                currentIterations = 0.125f * currentBGHeight / MaxHeight * (MaxIterations - MinIterations);
                if (currentIterations > MaxIterations)
                    currentIterations = MaxIterations;
                SetIterations(Mathf.FloorToInt(currentIterations));
            }

            SetBlurEffectState(false);

            SetHeight(currentHeight, currentBGHeight);
            SetActive(false);
        }
        gameObject.SetActive(false);
        IsPlaying = false;
        if (EndCallBack != null)
            EndCallBack();
    }
    private void SetActive(bool active)
    {
        texEye.SetActive(active);
        texBGUp.SetActive(active);
        texBGDown.SetActive(active);
    }
    /// <summary>
    /// 设置图片高度
    /// </summary>
    /// <param name="currentHeight"></param>
    /// <param name="currentBGHeight"></param>
    private void SetHeight(float currentHeight, float currentBGHeight)
    {
        SetUItextureHeight(texEye, currentHeight);
        SetUItextureHeight(texBGUp, currentBGHeight);
        SetUItextureHeight(texBGDown, currentBGHeight);
    }
    /// <summary>
    /// 设置图片高度
    /// </summary>
    /// <param name="tex"></param>
    /// <param name="height"></param>
    private void SetUItextureHeight(UITexture tex, float height)
    {
        if (tex != null)
            tex.height = Mathf.FloorToInt(height);
    }
    private void InitBlurEffect()
    {
        if (blinkCamera != null)
        {
            //blurEffect = blinkCamera.gameObject.GetComponent<BlurEffect>();
            //if (blurEffect == null)
            //    blurEffect = blinkCamera.gameObject.AddComponent<BlurEffect>();

            SetBlurEffectState(false);
            SetIterations(MaxIterations);
            SetBlurShader(ShaderName);
        }
    }
    /// <summary>
    /// 设置模糊度
    /// </summary>
    /// <param name="iterations"></param>
    private void SetIterations(int iterations)
    {
        currentIterations = iterations;
        //if (blurEffect != null)
        //    blurEffect.iterations = iterations;
        SetBlurSpread(GetBlurSpread(iterations));
    }
    /// <summary>
    /// 设置模糊脚本状态
    /// </summary>
    /// <param name="enable"></param>
    private void SetBlurEffectState(bool enable)
    {
        //if (blurEffect != null)
        //    blurEffect.enabled = enable;
    }
    private void SetBlurSpread(float spread)
    {
        //if (blurEffect != null)
        //{
        //    SetBlurEffectState(spread != 0);
        //    blurEffect.blurSpread = spread;
        //}
    }
    private void SetBlurShader(string shaderName)
    {
        //if (blurEffect != null)
        //    blurEffect.blurShader = Shader.Find(shaderName);
    }
    private float GetBlurSpread(int iterations)
    {
        switch (iterations)
        {
            case 0:
                return 0;
            case 1:
                return 0;
            case 2:
                return -0.95f;
            case 3:
                return -0.57f;
            case 4:
                return -0.35f;
            case 5:
                return -0.28f;
            case 6:
                return -0.22f;
            case 7:
                return -0.18f;
            case 8:
                return -0.15f;
            case 9:
                return -0.13f;
            case 10:
                return -0.115f;
            case 11:
                return -0.105f;
            case 12:
                return -0.095f;
            case 13:
                return -0.085f;
            case 14:
                return -0.08f;
            case 15:
                return -0.075f;
            case 16:
                return -0.069f;
            case 17:
                return -0.065f;
            case 18:
                return -0.062f;
            case 19:
                return -0.058f;
            case 20:
                return -0.055f;
            case 21:
                return -0.052f;
            case 22:
                return -0.049f;
            case 23:
                return -0.047f;
            case 24:
                return -0.045f;
            case 25:
                return -0.042f;
            case 26:
                return -0.041f;
            case 27:
                return -0.04f;
            case 28:
                return -0.039f;
            case 29:
                return -0.037f;
            case 30:
                return -0.036f;
            case 31:
                return -0.034f;
            case 32:
                return -0.033f;
            case 33:
                return -0.032f;
            case 34:
                return -0.031f;
            case 35:
                return -0.03f;
            case 36:
                return -0.03f;
            case 37:
                return -0.029f;
            case 38:
                return -0.028f;
            case 39:
                return -0.027f;
            case 40:
                return -0.026f;
        }
        return -0.03f;
    }
}
