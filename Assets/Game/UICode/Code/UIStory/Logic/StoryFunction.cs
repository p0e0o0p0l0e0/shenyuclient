using UnityEngine;

/// <summary>
/// 剧情功能实现者
/// zlj
/// </summary>
[RequireComponent(typeof(StoryFunctionData))]
public class StoryFunction : MonoBehaviour
{
    /// <summary>
    /// 数据
    /// </summary>
    private StoryFunctionData _data;
    public StoryFunctionData FunData {
        get { return _data; }
    }
    private FunctionDelegate _callBack;
    
    /// 冒泡
    private StoryFunBubbling bubblingFun = null;
    /// 游戏速度
    private StoryFunGameSpeed gameSpeedFun = null;
    /// 位移
    private StoryFunDisplacement displacementFun = null;
    /// 背景音
    private StoryFunBackMusic backMusicFun = null; 
    //相机
    private StoryFunCamera cameraFun = null;
    //动作 技能
    private StoryFunAnimation animationFun = null;
    //眨眼
    private StoryFunBlinkOfAnEye blinkOfAnEyeFun = null;
    //剧情动画
    private StoryFunCinemaDirector cinemaDirector = null;

    protected ViTimeNode1 _node1 = new ViTimeNode1();
    [HideInInspector]
    public bool isAutoPlay = true;

    /// <summary>
    /// 播放剧情
    /// </summary>
    /// <param name="playDoneCallBack">当期剧情完成的回调.</param>
    public void Play(int _index, FunctionDelegate playDoneCallBack)
    {
        _callBack = playDoneCallBack;
        if (_data == null)
        {
            _data = GetComponent<StoryFunctionData>();
            _data.index = _index;
        }

        if(_data.type != StoryFunctionData.FUCTION_TYPE.TEXTURE &&
           _data.type != StoryFunctionData.FUCTION_TYPE.BUBBLING)
            WaitSomeTime();
        else
            ProFunction();
    }
    private void WaitSomeTime()
    {
        if (_data.startWaitTime > 0)
            StoryManager.GetInstance.SetTime(_node1, _data.startWaitTime,(node)=> { ProFunction(); });
        else
            ProFunction();
    }
    private void ShowStoryUI(UICallback.VV_CB callBack)
    {
        if (StoryManager.GetInstance.UIController == null)
            UIManager.Instance.Show(UIControllerDefine.WIN_Story, callBack);
        else
        {
            if (!StoryManager.GetInstance.UIController.IsShow)
                StoryManager.GetInstance.UIController.Show();
            if (callBack != null)
                callBack();
        }
    }
    /// <summary>
    /// 显示UI
    /// </summary>
    private void ProFunction()
    {
        switch (_data.type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                ShowStoryUI(()=>
                {
                    if (_data.textData.appearanceData.appearanceMode == StoryAppearanceData.AppearanceMode.Normal)
                        StoryManager.GetInstance.AddGamePause();
                    StoryManager.GetInstance.UIController.ShowUI(_data.type,_data, ProNextFunction);
                });
                break;
            case StoryFunctionData.FUCTION_TYPE.BUBBLING:
                ShowStoryUI(() =>
                {
                    if (bubblingFun == null)
                        bubblingFun = new StoryFunBubbling();
                    bubblingFun.Run(_data, ProNextFunction);
                });
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                ShowStoryUI(()=>
                {
                    StoryManager.GetInstance.AddGamePause();
                    StoryManager.GetInstance.UIController.ShowUI(_data.type,_data, ProNextFunction);
                });
                break;
            case StoryFunctionData.FUCTION_TYPE.DISPLACEMENT:
                {
                    if (displacementFun == null)
                        displacementFun = new StoryFunDisplacement();
                    displacementFun.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.GAMESPEED:
                {
                    if (gameSpeedFun == null)
                        gameSpeedFun = new StoryFunGameSpeed();
                    gameSpeedFun.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.BACKMUSIC:
                {
                    if (backMusicFun == null)
                        backMusicFun = new StoryFunBackMusic();
                    backMusicFun.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.CAMERA:
                {
                    StoryManager.GetInstance.AddGamePause();
                    if (cameraFun == null)
                        cameraFun = new StoryFunCamera();
                    cameraFun.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.ANIMATION:
                {
                    if (animationFun == null)
                        animationFun = new StoryFunAnimation();
                    animationFun.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.BLINKOFANEYE:
                {
                    if (blinkOfAnEyeFun == null)
                        blinkOfAnEyeFun = new StoryFunBlinkOfAnEye();
                    blinkOfAnEyeFun.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.CINEMADIRECTOR:
                {
                    if (cinemaDirector == null)
                        cinemaDirector = new StoryFunCinemaDirector();
                    StoryManager.GetInstance.AddGamePause();
                    cinemaDirector.Run(_data, ProNextFunction);
                }
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                {
                    ShowStoryUI(() =>
                    {
                        StoryManager.GetInstance.AddGamePause();
                        StoryManager.GetInstance.UIController.ShowUI(_data.type, _data, ProNextFunction);
                    });
                }
                break;
        }
    }
    /// <summary>
    /// 显示完成回调下一个剧情
    /// </summary>
    private void ProNextFunction()
    {
        switch (_data.type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                StoryManager.GetInstance.UIController.CloseUI(_data.type);
                if (_data.textData.appearanceData.appearanceMode == StoryAppearanceData.AppearanceMode.Normal)
                    StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                StoryManager.GetInstance.UIController.CloseUI(_data.type);
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.CAMERA:
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.CINEMADIRECTOR:
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                {
                    StoryManager.GetInstance.UIController.CloseUI(_data.type);
                    StoryManager.GetInstance.RemoveGamePause();
                }
                break;
            default:
                break;
        }
        if (_callBack != null)
            _callBack(this);
    }
    public void Stop()
    {
        if (_data == null)
            return;
        switch (_data.type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                StoryManager.GetInstance.UIController.Stop(_data.type);
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.BUBBLING:
                if (bubblingFun != null)
                    bubblingFun.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                StoryManager.GetInstance.UIController.Stop(_data.type);
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.DISPLACEMENT:
                if(displacementFun != null)
                    displacementFun.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.GAMESPEED:
                if (gameSpeedFun != null)
                    gameSpeedFun.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.BACKMUSIC:
                if (backMusicFun != null)
                    backMusicFun.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.CAMERA:
                if (cameraFun != null)
                    cameraFun.Stop();
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.ANIMATION:
                if (animationFun != null)
                    animationFun.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.BLINKOFANEYE:
                if (blinkOfAnEyeFun != null)
                    blinkOfAnEyeFun.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.CINEMADIRECTOR:
                if (cinemaDirector != null)
                    cinemaDirector.Stop();
                StoryManager.GetInstance.RemoveGamePause();
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                {
                    StoryManager.GetInstance.UIController.Stop(_data.type);
                    StoryManager.GetInstance.RemoveGamePause();
                }
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 是否切换主相机视野
    /// </summary>
    /// <returns></returns>
    public bool IsChangCameraView()
    {
        return _data != null &&  
            _data.type == StoryFunctionData.FUCTION_TYPE.TEXTURE && 
            _data.textData.appearanceData.appearanceMode == StoryAppearanceData.AppearanceMode.Normal &&
            _data.textData.appearanceData.isChangeCameraView;
    }
    public bool IsCanNotNext()
    {
        if (_data == null)
        {
            _data = GetComponent<StoryFunctionData>();
        }
        if (_data == null)
        {
            return true;
        }
        return  _data.type == StoryFunctionData.FUCTION_TYPE.TEXTURE;
    }
}
