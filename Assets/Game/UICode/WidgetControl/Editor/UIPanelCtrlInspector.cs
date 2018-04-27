using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIPanelCtrl), true)]
public class UIPanelCtrlInspector : Editor
{
    public override void OnInspectorGUI()
    {
        SerializedProperty sp = serializedObject.FindProperty("_mDepth");
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("面板基础Depth");
        if (GUILayout.Button("Back", GUILayout.MinWidth(46f)))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                UIPanelCtrl pw = go.GetComponent<UIPanelCtrl>();
                if (pw != null) pw.Depth = pw.Depth - 1;
            }
        }
        EditorGUILayout.PropertyField(sp, new GUIContent(""), GUILayout.MinWidth(20f));
        if (GUILayout.Button("Forward", GUILayout.MinWidth(60f)))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                UIPanelCtrl pw = go.GetComponent<UIPanelCtrl>();
                if (pw != null) pw.Depth = pw.Depth + 1;
            }
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.LabelField("绘制顺序:");
        GUILayout.BeginVertical();
        GUI.color = Color.green;
        if (Selection.gameObjects.Length > 0)
        {
            UIPanelCtrl pw = Selection.gameObjects[0].GetComponent<UIPanelCtrl>();
            List<UIDrawCallCtrl> list = pw.DrawList;
            for (int i = 0; i < list.Count; ++i)
            {
                string name = list[i].name;
                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("\t↓"+name);
                bool ret = DrawDCDepth(list[i]);
                if (ret)
                {
                    pw.ForceImmediate();
                    break;
                }
                    
                GUILayout.EndHorizontal();
            }
        }
        GUI.color = Color.white;
        GUILayout.EndVertical();
        GUILayout.BeginHorizontal();
        GUI.color = Color.yellow;
        if (Selection.gameObjects.Length > 0)
        {
            UIPanelCtrl pw = Selection.gameObjects[0].GetComponent<UIPanelCtrl>();
            int count = FindBatchCount(pw);
            EditorGUILayout.LabelField("发现可以批处理的数量:" + count);
        }
        
        GUI.color = Color.white;
        GUILayout.EndHorizontal();

        
        GUILayout.BeginHorizontal();
        GUI.color = Color.red;
        if (Selection.gameObjects.Length > 0)
        {
            UIPanelCtrl pw = Selection.gameObjects[0].GetComponent<UIPanelCtrl>();
            bool ret = IsFindMutilSameDepth(pw);
            if (ret)
                EditorGUILayout.LabelField("Depth有重复");
        }

        GUI.color = Color.white;
        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
    bool DrawDCDepth(UIDrawCallCtrl dcc)
    {
        bool ret = false;
        if (GUILayout.Button("Back", GUILayout.MinWidth(46f)))
        {
            if (dcc != null) dcc.Depth = dcc.Depth - 1;
            ret = true;
        }
        EditorGUILayout.TextField(dcc.Depth.ToString());
        if (GUILayout.Button("Forward", GUILayout.MinWidth(60f)))
        {
            if (dcc != null) dcc.Depth = dcc.Depth + 1;
            ret = true;
        }
        return ret;
    }
    int FindBatchCount(UIPanelCtrl pc)
    {
        int count = 0;
        List<UIDrawCallCtrl> list = pc.DrawList;
        Dictionary<string, int> useTag = new Dictionary<string, int>();
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i] is UIMerDrawCallCtrl)
            {
                UIMerDrawCallCtrl mDCC = list[i] as UIMerDrawCallCtrl;
                int index = -1;
                if (useTag.TryGetValue(mDCC.TAG, out index))
                {
                    if (index != ( i-1 ))
                        count++;
                }
                else useTag.Add(mDCC.TAG, i);
            }
        }
        return count;
    }
    bool IsFindMutilSameDepth(UIPanelCtrl pc)
    {
        //List<UIDrawCallCtrl> list = pc.DrawList;
        //Dictionary<int, int> depths = new Dictionary<int, int>();
        //for (int i = 0; i < list.Count; ++i)
        //{
        //    int index = -1;
        //    if (depths.TryGetValue(list[i].Depth, out index))
        //    {
        //        if()
        //        return true;
        //    }
        //    else
        //        depths.Add(list[i].Depth, i);
        //}
        return false;
    }

}
