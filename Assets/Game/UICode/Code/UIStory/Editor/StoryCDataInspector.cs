using UnityEngine;
using UnityEditor;
/********************************************************************
	created:	2016/09/24
	created:	24:9:2016   11:18
	filename: 	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story\StoryCDataINspector.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story
	file base:	StoryCDataINspector
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
[CustomEditor(typeof(StoryConditionData))]
public class StoryCDataInspector : StoryDataInspector
{
    private SerializedProperty typeP;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUI.enabled = true;
        StoryConditionData data = (StoryConditionData)target;
        GUI.color = Color.cyan;
        data.type = (StoryConditionData.CONDITION_TYPE)EditorGUILayout.Popup("触发者条件类型:", (int)data.type, data.conStr);
        GUI.color = Color.white;
        EditorGUILayout.Space();
        switch (data.type)
        {
            case StoryConditionData.CONDITION_TYPE.RECT:
                EditRoleType(data);
                break;
            case StoryConditionData.CONDITION_TYPE.GROUPDEAD:
            case StoryConditionData.CONDITION_TYPE.LOADEDWAVEROLES:
            case StoryConditionData.CONDITION_TYPE.ARRIVEWAVECENTER:
                EditWaveData(data.waveData);
                break;
            case StoryConditionData.CONDITION_TYPE.BLOODMINLIMIT:
                EditBloodLimitData(data);
                break;
            case StoryConditionData.CONDITION_TYPE.ENTER:
                break;
            case StoryConditionData.CONDITION_TYPE.RESUILTEND:
                break;
            case StoryConditionData.CONDITION_TYPE.PLAYSKILL:
                EditPlaySkillData(data);
                break;
            case StoryConditionData.CONDITION_TYPE.AUTOPLAY:
                break;
            case StoryConditionData.CONDITION_TYPE.TRIGGERCONDITION:
                EditTriggerConditionData(data);
                break;
            case StoryConditionData.CONDITION_TYPE.GOALCOMPLETE:
                EditGoalCompleteData(data);
                break;
            case StoryConditionData.CONDITION_TYPE.TEST:
                break;
        }
        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical("box");
        Label("附加条件:");
        EditorGUILayout.BeginVertical("box");
        BoolField("特殊剧情模式下触发:", ref data.playInStoryModel);
        BoolField("是否强制转向主角:", ref data.isBroadCast);
        BoolField("播放完此条件删除剧情文件:", ref data.isEndForceDestory);
        EditorGUILayout.EndVertical();
        Label("触发事件:");
        EditorGUILayout.BeginVertical("box");
        BoolField("通知服务器进入剧情模式:", ref data.isNoticeServerEnterStoryModel);
        if (data.isNoticeServerEnterStoryModel)
            IntField("此剧情模式的任务ID:", ref data.goalID);
        BoolField("通知服务器加载NPC:" ,ref data.isNoticeServerLoadNPC);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        Label("本地添加角色列表:");
        EditRoleListMenu(ref data.roleDataList);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();

        serializedObject.ApplyModifiedProperties();
    }
    /// <summary>
    /// 编辑区域触发
    /// </summary>
    private void EditRoleType(StoryConditionData data)
    {
        EditorGUILayout.BeginVertical("box");
        EditRoleMenu(data.roleData);
        IntField("附加触发条件ID:", ref data.rectConditionID);
        StoryEditorUtils.ShowPrompt("本对象的位置为触发区域的中心位置,下面的BOX可以改变触发区域的大小");
        StoryEditorUtils.ShowPrompt("附加触发条件ID : -1 进入区域自动触发 1 进入区域事件触发");
        EditorGUILayout.EndVertical();
    }
    /// <summary>
    ///  编辑波次
    /// </summary>
    /// <param name="data"></param>
    protected void EditWaveData(StoryWaveData data)
    {
        //EditorGUILayout.BeginHorizontal();
        //GUILayout.Label("地编文件:");
        //data.battleGroupPrefab = EditorGUILayout.ObjectField(data.battleGroupPrefab, typeof(GameObject), false) as GameObject;
        //EditorGUILayout.EndHorizontal();
        //if (data.battleGroupPrefab != null)
        //{
        //    if (string.IsNullOrEmpty(data.battleGroupPrefabPath) ||
        //        !data.battleGroupPrefabPath.Contains(data.battleGroupPrefab.name))
        //        data.battleGroupPrefabPath = AssetDatabase.GetAssetPath(data.battleGroupPrefab);
        //    if (string.IsNullOrEmpty(data.battleGroupPrefabName) ||
        //        !data.battleGroupPrefabName.Equals(data.battleGroupPrefab.name))
        //        data.battleGroupPrefabName = data.battleGroupPrefab.name;
        //}
        //EditorGUILayout.LabelField("地编文件路径:", data.battleGroupPrefabPath);
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        EditWaveListMenu(data);
        GUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    private void EditWaveListMenu(StoryWaveData data)
    {
        int deleFlagIndex = -1;
        for (int i = 0; i < data.waveBirthPosList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal("box");
            data.waveBirthPosList[i] = (EditorGUILayout.IntField("NPCBirthPositionID:", data.waveBirthPosList[i]));

            if (GUILayout.Button("删除"))
                deleFlagIndex = i;
            EditorGUILayout.EndVertical();
        }
        if (GUILayout.Button("添加NPC出生点ID"))
        {
            data.waveBirthPosList.Add(0);
        }
        if (deleFlagIndex >= 0)
        {
            if (data.waveBirthPosList.Count > 0)
            {
                data.waveBirthPosList.RemoveAt(deleFlagIndex);
            }
        }
    }
    /// <summary>
    /// 某波中的某个角色
    /// </summary>
    /// <param name="data"></param>
    protected void EditWaveCharacterData(StoryWaveData data)
    {
        GUILayout.Label("波次角色类型：");
        EditEnemyMenu(data.roleData);
    }
    /// <summary>
    /// 血量低于百分之多少
    /// </summary>
    /// <param name="data"></param>
    protected void EditBloodLimitData(StoryConditionData data)
    {
        EditorGUILayout.BeginVertical("box");
        EditWaveCharacterData(data.waveData);
        EditorGUILayout.Space();
        FloatField("血量低于百分比:", ref data.bloodLimitPercent);
        StoryEditorUtils.ShowPrompt("所填数值在0到1之间，0为死亡，1为满血");
        GUILayout.EndVertical();
    }
    /// <summary>
    /// 播放技能数据
    /// </summary>
    /// <param name="data"></param>
    protected void EditPlaySkillData(StoryConditionData data)
    {
        IntField("技能ID:", ref data.skillID);
        EditRoleMenu(data.roleData);
    }
    /// <summary>
    /// 其他条件完成触发此条件
    /// </summary>
    /// <param name="data"></param>
    protected void EditTriggerConditionData(StoryConditionData data)
    {
        IntField("剧情ID:", ref data.storyConditionID);
    }
    /// <summary>
    /// 任务完成触发此条件
    /// </summary>
    /// <param name="data"></param>
    protected void EditGoalCompleteData(StoryConditionData data)
    {
        IntField("任务ID:", ref data.goalID);
    }
}