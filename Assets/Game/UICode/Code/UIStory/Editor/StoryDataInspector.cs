using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
/********************************************************************
	created:	2016/09/24
	created:	24:9:2016   14:24
	filename: 	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story\StoryDataInspector.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story
	file base:	StoryDataInspector
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/

public class StoryDataInspector : Editor
{
    protected void IntField(string title, ref int value)
    {
        value = EditorGUILayout.IntField(title, value);
        EditorGUILayout.Space();
    }
    protected void FloatField(string title,ref float value)
    {
        value = EditorGUILayout.FloatField(title,value);
    }
    protected void DoubleField(string title, ref double value)
    {
        value = EditorGUILayout.DoubleField(title, value);
        EditorGUILayout.Space();
    }
    protected void CurveField(string title, ref AnimationCurve value)
    {
        value = EditorGUILayout.CurveField(title, value);
        EditorGUILayout.Space();
    }
    protected void ColorField(string title, ref Color value)
    {
        value = EditorGUILayout.ColorField(title, value);
        EditorGUILayout.Space();
    }
    
    protected void BoundsField(string title, ref Bounds value)
    {
        value = EditorGUILayout.BoundsField(title, value);
        EditorGUILayout.Space(); 
    }
    protected void TextField(string title, ref string value)
    {
        value = EditorGUILayout.TextField(title, value);
        EditorGUILayout.Space();
    }
    protected void BoolField(string title, ref bool value)
    {
        value = EditorGUILayout.Toggle(title, value);
    }
    protected void Vector2Field(string title, ref Vector2 value)
    {
        value = EditorGUILayout.Vector2Field(title, value);
        EditorGUILayout.Space();
    }
    protected void Vector3Field(string title, ref Vector3 value)
    {
        value = EditorGUILayout.Vector3Field(title, value);
        EditorGUILayout.Space();
    }
    protected void Vector4Field(string title, ref Vector4 value)
    {
        value = EditorGUILayout.Vector4Field(title, value);
        EditorGUILayout.Space();
    }
    protected void SliderField(ref float currentValue,float minValue,float maxValue)
    {
        currentValue = EditorGUILayout.Slider(currentValue, minValue, maxValue);
    }
    protected void Label(string context)
    {
        GUILayout.Label(context);
    }
    protected void Label(string context,Color color)
    {
        GUI.color = color;
        GUILayout.Label(context);
        GUI.color = Color.white;
    }
    /// <summary>
    ///角色类型编辑
    /// </summary>
    protected void EditRoleMenu(StoryRoleData data)
    {
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("人物类型：");

        data.controlType = (StoryRoleData.ROLETYPE)GUILayout.Toolbar((int)data.controlType, data.roleTypeNames);
        switch (data.controlType)
        {
            ///为主角时
            case StoryRoleData.ROLETYPE.LEAD:
                break;
            ///为英雄时
            case StoryRoleData.ROLETYPE.HERO:
                //EditHeroMenu(data);
                break;
            ///为怪物时
            case StoryRoleData.ROLETYPE.ENEMY:
                EditEnemyMenu(data);
                break;
            ///为援军时
            case StoryRoleData.ROLETYPE.SceneNPC:
                EditSceneNPCMenu(data);
                break;
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 添加英雄数据
    /// </summary>
    /// <param name="roleData"></param>
    protected void EditHeroMenu(StoryRoleData roleData)
    {
        roleData.roleId = EditorGUILayout.IntField("英雄的ID:", roleData.roleId);
    }
    /// <summary>
    /// 添加援军数据
    /// </summary>
    /// <param name="roleData"></param>
    protected void EditSceneNPCMenu(StoryRoleData roleData)
    {
        EditorGUILayout.BeginVertical("box");
        roleData.controlType = StoryRoleData.ROLETYPE.SceneNPC;
        roleData.npcBirthPositionID = EditorGUILayout.IntField("援军出生点ID:", roleData.npcBirthPositionID);
        roleData.npcBirthPositionIndex = EditorGUILayout.IntField("援军出生点Index:", roleData.npcBirthPositionIndex);
        BoolField("是否为本地角色", ref roleData.isLocal);
        EditorGUILayout.EndVertical();
    }
    protected void EditEnemyMenu(StoryRoleData roleData)
    {
        EditorGUILayout.BeginVertical("box");
        roleData.controlType = StoryRoleData.ROLETYPE.ENEMY;
        roleData.npcBirthPositionID = EditorGUILayout.IntField("NPC出生点ID:", roleData.npcBirthPositionID);
        roleData.npcBirthPositionIndex = EditorGUILayout.IntField("NPC出生点Index:", roleData.npcBirthPositionIndex);
        BoolField("是否为本地角色",ref roleData.isLocal);
        EditorGUILayout.EndVertical();
    }
    /// <summary>
    /// 添加敌人数据
    /// </summary>
    /// <param name="roleData"></param>
    protected void EditEnemyOldMenu(StoryRoleData roleData)
    {
        roleData.isShowDetail = EditorGUILayout.Foldout(roleData.isShowDetail, "数据详情");
        if (!roleData.isShowDetail)
            return;

        //EditorGUILayout.LabelField("当前场景:", SceneManager.GetActiveScene().name);
        //EditorGUILayout.LabelField("当前场景路径:", SceneManager.GetActiveScene().path);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("地编文件:");
        roleData.battleGroupPrefab = EditorGUILayout.ObjectField(roleData.battleGroupPrefab, typeof(GameObject), false) as GameObject;
        EditorGUILayout.EndHorizontal();
        if (roleData.battleGroupPrefab != null)
        {
            if (string.IsNullOrEmpty(roleData.battleGroupPrefabPath) || 
                !roleData.battleGroupPrefabPath.Contains(roleData.battleGroupPrefab.name))
                roleData.battleGroupPrefabPath = AssetDatabase.GetAssetPath(roleData.battleGroupPrefab);

            if (string.IsNullOrEmpty(roleData.battleGroupPrefabName) ||
                !roleData.battleGroupPrefabName.Equals(roleData.battleGroupPrefab.name))
                roleData.battleGroupPrefabName = roleData.battleGroupPrefab.name;
        }
        EditorGUILayout.LabelField("地编文件路径:", roleData.battleGroupPrefabPath);
        roleData.enenmyCellIndex = EditorGUILayout.IntField("波次:", roleData.enenmyCellIndex);
        roleData.enemyPosition = EditorGUILayout.IntField("位置:", roleData.enemyPosition);
    }
    /// <summary>
    /// 添加角色数据列表
    /// </summary>
    /// <param name="roleDataList"></param>
    protected void EditRoleListMenu(ref List<StoryRoleData> roleDataList)
    {
        int deleFlagIndex = -1;
        for (int i = 0; i < roleDataList.Count; i++)
        {
            EditorGUILayout.BeginVertical("box");
            EditRoleMenu(roleDataList[i]);
            Vector3Field("重置位置(不填读表)：", ref roleDataList[i].position);
            Vector3Field("重置角度(不填读表)：", ref roleDataList[i].angle);
            EditorGUILayout.BeginHorizontal();
            BoolField("是否结束删除",ref roleDataList[i].isDestory);
            if (GUILayout.Button("删除角色数据"))
                deleFlagIndex = i;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }
        GUI.color = Color.yellow;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("添加角色数据"))
        {
            if (roleDataList.Count >= 20)
                EditorUtility.DisplayDialog("提示", "角色数据已达上限", "确定");
            else
                roleDataList.Add(new StoryRoleData());
        }
        if (deleFlagIndex >= 0)
        {
            if (roleDataList.Count > 0)
                roleDataList.RemoveAt(deleFlagIndex);
        }
        GUILayout.EndHorizontal();
        GUI.color = Color.white;
    }
    /// <summary>
    /// 添加敌人数据列表
    /// </summary>
    /// <param name="roleDataList"></param>
    protected void EditEnemyListMenu(ref List<StoryRoleData> roleDataList)
    {
        for (int i = 0; i < roleDataList.Count; i++)
            EditEnemyMenu(roleDataList[i]);
        GUI.color = Color.yellow;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("添加怪物数据"))
        {
            roleDataList.Add(new StoryRoleData());
        }
        if (GUILayout.Button("删除怪物数据"))
        {
            if (roleDataList.Count > 0)
            {
                roleDataList.RemoveAt(roleDataList.Count - 1);
            }
        }
        GUILayout.EndHorizontal();
        GUI.color = Color.white;
    }
}

