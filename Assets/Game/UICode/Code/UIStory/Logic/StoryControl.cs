using UnityEngine;

/// <summary>
/// 游戏剧情管理器
/// 功能实现层,实现本体的功能
/// zlj
/// </summary>
[RequireComponent(typeof(StoryControlData))]
public class StoryControl : MonoBehaviour
{
    private StoryControlData data;

    private StoryCondition[] conditionArray;

    private int conditionCount = 0;

    private object obj = null;

    public void InitData(object arg = null)
    {
        RefreshData(arg);
        transform.position = Vector3.zero;
        if (data == null)
        {
            data = GetComponent<StoryControlData>();
            data.InitData();
        }
        if (conditionArray == null)
            conditionArray = transform.GetComponentsInChildren<StoryCondition>();

        conditionCount = conditionArray.Length;
    }
    public void RefreshData(object arg = null)
    {
        obj = arg;
    }
    /// <summary>
    /// 启动剧情触发条件
    /// </summary>
    public void Play()
    {
        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            conditionArray [i].StartRun(PlayEndCallBack);
        }
    }
    public bool HasResultEnd()
    {
        bool hasResultEnd = false;

        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            if (conditionArray[i].IsResultEndType())
                hasResultEnd = true;
        }

        return hasResultEnd;
    }
    public bool HasBattleWin()
    {
        bool hasBattleWin = false;

        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            if (conditionArray[i].IsBattleWinType())
                hasBattleWin = true;
        }

        return hasBattleWin;
    }
    public bool IsRunningStory()
    {
        bool isRunningStory = false;

        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            if (conditionArray[i].IsRunningStory())
                isRunningStory = true;
        }

        return isRunningStory;
    }
    public void EnterStoryModel()
    {
        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            conditionArray[i].EnterStoryModel();
        }
    }
    public void ExitStoryModel()
    {
        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            conditionArray[i].ExitStoryModel();
        }
    }
    /// <summary>
    /// 关闭所有剧情
    /// </summary>
    public void Stop()
    {
        for (int i = conditionArray.Length - 1; i >= 0; i--)
        {
            conditionArray [i].Stop();
        }
    }
    public void EndNotCallBack(StoryConditionData.CONDITION_TYPE type, string conditionName, bool forceDestory)
    {
        conditionCount--;
        if (conditionCount <= 0 || forceDestory)
        {
            StoryManager.GetInstance.SomeoneStoryEnd(type, gameObject.name, conditionName, true, obj);
        }
    }
    /// <summary>
    /// 播放剧情结束回调
    /// </summary>
    /// <param name="type"></param>
    public void PlayEndCallBack(StoryConditionData.CONDITION_TYPE type,string conditionName,bool forceDestory)
    {
        conditionCount--;
        StoryManager.GetInstance.SomeoneStoryEnd(type,gameObject.name, conditionName, conditionCount <= 0 || forceDestory, obj);
    }
    void OnDrawGizmos() { }
}
