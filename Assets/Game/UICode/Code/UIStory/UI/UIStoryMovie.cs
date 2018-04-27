using UnityEngine;
using System.Collections;
using UnityEngine.Video;
/********************************************************************
created:	2016/09/29
created:	29:9:2016   10:53
filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\Battle\BattleStory\UIStoryMovie.cs
file path:	D:\Resource\client\trunk\Project\Assets\Scripts\Battle\BattleStory
file base:	UIStoryMovie
file ext:	cs
author:		zlj

purpose:	剧情播放视频
*********************************************************************/

public class UIStoryMovie : UIStoryBase
{
    public enum StoryMovieState
    {
        Loaded,
        Playing,
        End,
    }
    #region ui control name define
    private const string VideoManager = "/VideoManager";
    private const string BtnJump = "/btn_Jump";
    private const string TexMovie = "/tex_Movie";
    #endregion

    public VoidDelegate _callBack;

    private StoryMovieState _storyMovieState = StoryMovieState.End;
    private StoryFunctionMovieData _data;
    private StoryFunctionData _functionData;
    private VideoPlayer _mediaPlayer = null;
    //private ExUIButton _btnJump = null;
    private ExUITexture _texMovie = null;

    public override void Initial(UIStoryWindow window, string topPath)
    {
        base.Initial(window,topPath);
        
        _mediaPlayer = this.GetComponent<VideoPlayer>(VideoManager);
        if (_mediaPlayer != null)
        {
            _mediaPlayer.playOnAwake = false;
            _mediaPlayer.waitForFirstFrame = false;
            _mediaPlayer.isLooping = false;
            _mediaPlayer.aspectRatio =  VideoAspectRatio.Stretch;
            _mediaPlayer.renderMode = VideoRenderMode.RenderTexture;
            //_mediaPlayer.source = VideoSource.VideoClip;
            _mediaPlayer.source = VideoSource.Url;
            _mediaPlayer.errorReceived += _OnVideoError;
            _mediaPlayer.started += _OnStart;
            _mediaPlayer.loopPointReached += _OnEnd;
            _mediaPlayer.prepareCompleted += _OnReady;
}
        //_btnJump = this.GetComponent<ExUIButton>(BtnJump);
        //_btnJump.onClick.AddListener(Stop);

        _texMovie = this.GetComponent<ExUITexture>(TexMovie);
        RenderTexture _renderTex = StoryManager.GetInstance.CreateRenderTexture();
        _texMovie.SetRawImageTexture(_renderTex);
        _mediaPlayer.targetTexture = _renderTex;
    }

    public override void ShowUI(StoryFunctionData data, VoidDelegate callBack)
    {
        SetMovieState(StoryMovieState.End);
        _functionData = data;
        _data = data.movieData;
        _callBack = callBack;
        Open();
        //_btnJump.SetActive(_data.isCanJump);
        Play();
        
    }
    private void Play()
    {
        if (!string.IsNullOrEmpty(_data.moviePath))
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.url = Application.dataPath + "/Resources/" + _data.moviePath + ".mp4";
                //_mediaPlayer.clip = StoryManager.Instance.LoadAsset<VideoClip>(_data.moviePath);
                _mediaPlayer.Prepare();
                UConsole.Log("Load:" + _data.moviePath);
                SetMovieState(StoryMovieState.Loaded);
            }
            else
            {
                UConsole.LogError(UConsoleDefine.Story, "_mediaPlayer = null，播放失败");
                EndCallBack();
            }
        }
        else
        {
            UConsole.LogError(UConsoleDefine.Story, "视频路径为空，不播放。");
            EndCallBack();
        }
    }
    public void Stop()
    {
        if (_mediaPlayer != null)
            _mediaPlayer.Stop();
        EndCallBack();
        Close();
    }
    private void EndCallBack()
    {
        if (_callBack != null)
            _callBack();
        _callBack = null;
        SetMovieState(StoryMovieState.End);
        UConsole.Log(UConsoleDefine.Story, "结束播放视频");
    }
    private void _OnReady(VideoPlayer source)
    {
        UConsole.Log(UConsoleDefine.Story, "OnReady=>Play");
        _mediaPlayer.Play();
    }
    private void _OnStart(VideoPlayer source)
    {
        SetMovieState(StoryMovieState.Playing);
    }
    private void _OnDrop(VideoPlayer source)
    {

    }
    private void _OnEnd(VideoPlayer source)
    {
        UConsole.Log(UConsoleDefine.Story, "PlayEnd");
        StoryManager.GetInstance.SetTime(_node1,0.5f, _OnWait);
    }
    private void _OnVideoError(VideoPlayer source, string message)
    {
        UConsole.Log(UConsoleDefine.Story, "OnVideoError," + message);
        EndCallBack();
    }
    private void _OnVideoFrameReady(VideoPlayer source, long frameIdx)
    {

    }
    private void SetMovieState(StoryMovieState state)
    {
        _storyMovieState = state;
    }
    private void _OnWait(ViTimeNodeInterface node)
    {
        EndCallBack();
    }

}
