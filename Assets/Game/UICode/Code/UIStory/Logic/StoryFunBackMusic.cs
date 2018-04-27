using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:07
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunBackMusic.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunBackMusic
	file ext:	cs
	author:		zlj
	
	purpose:	修改背景音功能
*********************************************************************/
public class StoryFunBackMusic : StoryFunBase
{
    private StoryFunctionBackMusicData _backMusicData;

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);
        _backMusicData = data.backMusicData;

        StoryManager.GetInstance.SetBackMusic(_backMusicData.soundID, _backMusicData.volume);
        EndCallBack();
    }

    public override void Stop()
    {
        StoryManager.GetInstance.SetBackMusic(0, 1);
    }
}
