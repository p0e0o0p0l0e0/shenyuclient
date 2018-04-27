using UnityEngine;
using System.Collections;
using System;

public class UIStoryBlackBackground : UIStoryBase
{
    #region ui control name define
    private const string TXTCONTEXT = "/txt_Context";
    #endregion

    public VoidDelegate _callBack;
    
    private StoryFunctionBlackBackgroundData _data;
    private StoryFunctionData _functionData;
    private ExText _txtContext = null;

    private StoryPlayDialog _playDialog = new StoryPlayDialog();

    public override void Initial(UIStoryWindow window, string topPath)
    {
        base.Initial(window, topPath);

        _txtContext = this.GetComponent<ExText>(TXTCONTEXT);
    }

    public override void ShowUI(StoryFunctionData data, VoidDelegate callBack)
    {
        _functionData = data;
        _data = data.blackBackgroundData;
        _callBack = callBack;
        Open();
        Play();

    }
    private void Play()
    {
        StorySoundData dialogAndSoundData = _data.blackBackgroundData.dialogData;

        _playDialog.SetStoryTextData(_txtContext.gameObject, _txtContext, dialogAndSoundData.storyTextArray, dialogAndSoundData.waitTime, true);
        _playDialog.PlayDialog(_OnDialogEndCallBack,false);
        //语音部分
        audioLength = dialogAndSoundData.soundDuration;
        StoryManager.GetInstance.PlaySound(dialogAndSoundData.soundID);

        StoryManager.GetInstance.SetTime(_node1, _data.blackBackgroundData.duration,TimeEndCallBack);
    }

    private void TimeEndCallBack(ViTimeNodeInterface node)
    {
        if (_playDialog.isPlayingDialog)
        {
            _playDialog.Reset();
        }
        EndCallBack();
    }

    private void _OnDialogEndCallBack()
    {
        
    }

    public void Stop()
    {
        EndCallBack();
        Close();
    }
    private void EndCallBack()
    {
        if (_callBack != null)
            _callBack();
        _callBack = null;
        _playDialog.Reset();
    }
}

