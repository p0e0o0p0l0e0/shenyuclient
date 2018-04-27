using UnityEngine;

/// <summary>
/// 剧情编辑器
/// 作者：zlj
/// 战斗剧情数据类
/// </summary>
[System.Serializable]
public class StoryControlData : MonoBehaviour
{
    [HideInInspector]
    public StoryConditionData[] dataArray;

    public void InitData()
    {
        if (dataArray.Length < 1)
        {
            dataArray = transform.GetComponentsInChildren<StoryConditionData>();
        }
    }

}

