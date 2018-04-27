using System.Collections;
using UnityEngine;

public class UIStoryWindow : UIWindow<UIStoryWindow, UIStoryController>
{
    #region ui control name define
    private const string StoryDialog = "UIStoryWindow/UIStoryDialog";
    private const string StoryMovie = "UIStoryWindow/UIStoryMovie";
    private const string StoryBubbling = "UIStoryWindow/UIStoryBubbling";
    private const string StoryBlackBackground = "UIStoryWindow/UIStoryBlackBackground";
    #endregion
    /// <summary>
    /// 插图剧情UI
    /// </summary>
    public UIStoryDialog _uiStoryDialog = new UIStoryDialog();
    /// <summary>
    /// 视频UI
    /// </summary>
    public UIStoryMovie _uiStoryMovie = new UIStoryMovie();
    /// <summary>
    /// 冒泡UI
    /// </summary>
    public UIStoryBubbling _uiStoryBubbling = new UIStoryBubbling();
    /// <summary>
    /// 黑幕UI
    /// </summary>
    public UIStoryBlackBackground _uiStoryBlackBG = new UIStoryBlackBackground();

    protected override void Initial()
    {
        base.Initial();

        _uiStoryDialog.Initial(this, StoryDialog);
        _uiStoryMovie.Initial(this, StoryMovie);
        _uiStoryBubbling.Initial(this, StoryBubbling);
        _uiStoryBlackBG.Initial(this, StoryBlackBackground);
    }
    public void ShowUI(StoryFunctionData.FUCTION_TYPE type, StoryFunctionData data, VoidDelegate callBack)
    {
        switch (type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                _uiStoryDialog.ShowUI(data, callBack);
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                _uiStoryMovie.ShowUI(data, callBack);
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                _uiStoryBlackBG.ShowUI(data, callBack);
                break;
            default:
                break;
        }
    }
    public void CloseUI(StoryFunctionData.FUCTION_TYPE type)
    {
        switch (type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                _uiStoryDialog.Close();
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                _uiStoryMovie.Close();
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                _uiStoryBlackBG.Close();
                break;
            default:
                break;
        }
    }
    public void Stop(StoryFunctionData.FUCTION_TYPE type)
    {
        switch (type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                _uiStoryDialog.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                _uiStoryMovie.Stop();
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                _uiStoryBlackBG.Stop();
                break;
            default:
                break;
        }
    }
    public void SetLayer(int layer)
    {
        if (_mWinTran.IsNotNull())
        {
            _mWinTran.gameObject.layer = layer;
        }
    }

    public GameObject CreateBubblingChild()
    {
        return _uiStoryBubbling.CreateBubblingChild();
    }
}

