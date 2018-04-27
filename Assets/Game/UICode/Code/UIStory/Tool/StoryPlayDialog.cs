using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
/********************************************************************
	created:	2016/10/19
	created:	19:10:2016   17:32
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryPlayDialog.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryPlayDialog
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class StoryPlayDialog
{
    public const string NameReplace = "XXX";
    /// <summary>
    /// 对话的内容
    /// </summary>
    public Text storyText;
    /// <summary>
    /// 对话父物体
    /// </summary>
    private GameObject dialogObj = null;
    #region 播放多条文字数据
    /// <summary>
    /// 是否在播放对话
    /// </summary>
    public bool isPlayingDialog = false;
    /// <summary>
    /// 对话当前是哪个
    /// </summary>
    public int index = 0;
    /// <summary>
    /// 对话的内容
    /// </summary>
    private string[] storyTextArray = null;
    /// <summary>
    /// 延迟时间列表
    /// </summary>
    private float[] waitTimeArray = null;
    /// <summary>
    /// 对话内容所有延迟时间
    /// </summary>
    public float totalWaitTime = 0;
    /// <summary>
    /// 结束是否隐藏界面
    /// </summary>
    private bool _endHide = false;
    /// <summary>
    /// 播放结束回调
    /// </summary>
    private Action EndCallBack = null;

    private ViTimeNode1 _node1 = new ViTimeNode1();

    private StoryTextOneByOne _oneByOne = new StoryTextOneByOne();

    private bool isOneByOne = false;

    #endregion

    #region 播放对话
    /// <summary>
    /// 获取所有时间延长
    /// </summary>
    /// <returns></returns>
    public float GetAllWaitTimes()
    {
        if (waitTimeArray == null ||
            waitTimeArray.Length == 0)
            return 0;
        float time = 0;
        for (int i = 0; i < waitTimeArray.Length; i++)
        {
            time += waitTimeArray[i];
            if (waitTimeArray[i] == 0)
                Debug.LogError("播放文字停留时长为0导致显示看不到，内容：" + storyTextArray[i]);
        }
        return time;
    }
    public void SetStoryTextData(GameObject _dialogObj, Text _storyText, List<string > _storyTextArray,List<float> _waitTimeArray, bool isOneByOne = false)
    {
        dialogObj = _dialogObj;
        SetStoryTextData(_storyText, _storyTextArray.ToArray(), _waitTimeArray.ToArray(),isOneByOne);
    }
    public void SetStoryTextData(GameObject _dialogObj, Text _storyText, string[] _storyTextArray, float[] _waitTimeArray, bool isOneByOne = false)
    {
        dialogObj = _dialogObj;
        SetStoryTextData(_storyText, _storyTextArray, _waitTimeArray, isOneByOne);
    }
    public void SetStoryTextData(Text _storyText, string[] _storyTextArray, float[] _waitTimeArray,bool _isOneByOne = false)
    {
        storyText = _storyText;
        storyTextArray = _storyTextArray;
        waitTimeArray = _waitTimeArray;
        isOneByOne = _isOneByOne;
    }
    /// <summary>
    /// 播放对话
    /// </summary>
    public void PlayDialog(Action callBack = null,bool isEndHide = true)
    {
        isPlayingDialog = true;
        _endHide = isEndHide;
        EndCallBack = callBack;
        if (storyText != null)
            storyText.text = "";
        if (storyTextArray == null ||
            storyTextArray.Length == 0)
        {
            End();
            return;
        }

        if (dialogObj != null)
            dialogObj.SetActive(true);
        totalWaitTime = GetAllWaitTimes();
        index = 0;
        PlayNextDialog(index);
    }
    /// <summary>
    /// 播放下一句
    /// </summary>
    /// <param name="flag"></param>
    private void PlayNextDialog(int flag)
    {
        if (IsEnd(flag))
        {
            End();
            return;
        }
        string context = storyTextArray[flag].Replace(NameReplace, StoryManager.GetInstance.GetPlayerName());

        if (isOneByOne)
        {
            _oneByOne.Init(storyText, context, waitTimeArray[flag], true);
            _oneByOne.Play(OneByOneEndCallBack);
        }
        else
        {
            storyText.SetTextContent(context);
            StoryManager.GetInstance.SetTime(_node1, waitTimeArray[flag], OnStoryPlayDialog);
        }
    }

    private bool IsEnd(int flag)
    {
        return storyText == null || storyTextArray  == null || flag >= storyTextArray.Length;
    }

    private void OneByOneEndCallBack()
    {
        if (IsEnd(index + 1))
        {
            OnStoryPlayDialog(null);
        }
        else
        {
            StoryManager.GetInstance.SetTime(_node1, 1f, OnStoryPlayDialog);
        }
    }
    private void OnStoryPlayDialog(ViTimeNodeInterface nodeInterface)
    {
        PlayNextDialog(++index);
    }
    /// <summary>
    /// 结束对话
    /// </summary>
    private void End()
    {
        if (_endHide && dialogObj != null)
            dialogObj.SetActive(false);
        if (EndCallBack != null)
            EndCallBack();
        isPlayingDialog = false;
    }
    public void Reset()
    {
        _node1.Detach();
        isPlayingDialog = false;
        index = 0;
        storyTextArray = null;
        waitTimeArray = null;
        totalWaitTime = 0;
        EndCallBack = null;
        if (_endHide && dialogObj != null)
            dialogObj.SetActive(false);
        if(isOneByOne)
            _oneByOne.ForceEnd();
        isOneByOne = false;
    }
    /// <summary>
    /// return -1 show next;0 dialog end ;1 show all text
    /// </summary>
    /// <returns></returns>
    public int ForceChangeState()
    {
        if (isPlayingDialog)
        {
            if (IsEnd(index))
            {
                return -1;
            }
            else if (isOneByOne && _oneByOne.ShowAll())
            {
                return 1;
            }
            else
            {
                _node1.Detach();
                OnStoryPlayDialog(null);
                return 1;
            }
        }
        return 0;
    }
    #endregion

}
