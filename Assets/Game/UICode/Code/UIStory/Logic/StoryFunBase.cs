using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:16
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunBase.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunBase
	file ext:	cs
	author:		zlj
	
	purpose:	剧情功能基类
*********************************************************************/
public abstract class StoryFunBase
{
    protected StoryFunctionData _functionData;
    protected VoidDelegate _callBack;

    public virtual void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        _callBack = callBack;
        _functionData = data;
    }

    public virtual void EndCallBack()
    {
        if (_callBack != null)
            _callBack();
        _callBack = null;
    }

    public abstract void Stop();
}
