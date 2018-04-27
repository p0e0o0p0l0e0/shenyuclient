using UnityEngine;
using UnityEditor;

/********************************************************************
	created:	2016/09/24
	created:	24:9:2016   11:19
	filename: 	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story\StoryEditorUtils.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story
	file base:	StoryEditorUtils
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class StoryEditorUtils
{
    /// <summary>
    /// 打开文件框
    /// </summary>
    /// <param name="title"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string OpenFilePanel(string title, ResType type)
    {
        return EditorUtility.OpenFilePanel(title, StoryManager.GetEditorStoryPath(type), "");
    }
    /// <summary>
    /// 打开文件夹
    /// </summary>
    /// <param name="title"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string OpenFolderPanel(string title, ResType type)
    {
        return EditorUtility.OpenFolderPanel(title, StoryManager.GetEditorStoryPath(type), "");
    }
    /// <summary>
    /// 显示选择文件类型路径
    /// </summary>
    /// <param name="type"></param>
    /// <param name="texPath"></param>
    /// <param name="title1"></param>
    /// <param name="title2"></param>
    /// <param name="title3"></param>
    /// <returns></returns>
    public static string ShowSelectResMenu(ResType type, string texPath, string title1, string title2, string title3)
    {
        GUILayout.BeginHorizontal();
        if (!string.IsNullOrEmpty(texPath))
        {
            EditorGUILayout.TextField(title3, texPath);
            title1 = "换";
        }
        if (GUILayout.Button(title1))
        {
            texPath = OpenFilePanel(title2, type);
            texPath = texPath.Replace(string.Format("{0}/Resources/", Application.dataPath), "");
            string[] str = texPath.Split('.');
            texPath = str[0];
        }
        GUILayout.EndHorizontal();
        return texPath;
    }
    /// <summary>
    /// 显示枚举类型数据
    /// </summary>
    /// <returns></returns>
    public static int ShowEnumDataMenu(string title, string[] typeNames, int typeIndex)
    {
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(title);
        typeIndex = EditorGUILayout.Popup(typeIndex, typeNames);
        GUILayout.EndHorizontal();
        return typeIndex;
    }
    public static void ShowPrompt(string context)
    {
        GUI.color = Color.yellow;
        EditorGUILayout.HelpBox(context, MessageType.Info);
        //EditorGUILayout.HelpBox(context, MessageType.LogError);
        //EditorGUILayout.HelpBox(context, MessageType.None);
        //EditorGUILayout.HelpBox(context, MessageType.LogWarning);
        //EditorGUILayout.LabelField(context);
        GUI.color = Color.white;
    }
    public static void UnfoldScript()
    {
        ActiveEditorTracker editorTracker = ActiveEditorTracker.sharedTracker;
        Editor[] editors = editorTracker.activeEditors;
        for (int i = 1; i < editors.Length; i++)
        {
            editorTracker.SetVisible(i, 1);
        }
    }
    public static GameObject FloderCreatePrefab(string path, GameObject obj,bool relevancePrefab = true)
    {
        if (string.IsNullOrEmpty(path) || obj == null)
        {
            UConsole.Log("导出失败." + path, Color.red);
            return null;
        }
        if (relevancePrefab)
        {
            Object prefab = PrefabUtility.CreateEmptyPrefab(path);
            GameObject assetObj = PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return assetObj;
        }
        else
        {
            GameObject assetObj = PrefabUtility.CreatePrefab(path, obj);
            PrefabUtility.DisconnectPrefabInstance(obj);
            //PrefabUtility.ConnectGameObjectToPrefab(obj, assetObj);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return assetObj;
        }
    }
    /// <summary>
    /// 设置脚本状态
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="enable"></param>
    /// <returns></returns>
    public static T SetScriptState<T>(GameObject go, bool enable) where T : Behaviour
    {
        if (enable)
        {
            T t = go.AddComponentOnce<T>();
            t.enabled = enable;
            return t;
        }
        else
        {
            T t = go.GetComponent<T>();
            if (t != null)
                t.enabled = enable;
            return t;
        }
    }
}
