using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:08
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunGameSpeed.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunGameSpeed
	file ext:	cs
	author:		zlj
	
	purpose:	修改游戏速度功能
*********************************************************************/
public class StoryFunGameSpeed : StoryFunBase
{
    private StoryFunctionGameSpeedData _gameSpeedData;

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);
        _gameSpeedData = data.gameSpeedData;

        GameTimeScale.SetLogic(_gameSpeedData.gameSpeed);
        EndCallBack();
    }

    public override void Stop()
    {
        GameTimeScale.SetLogic(StoryStaticData.DefaultGameSpeed);
    }
}
