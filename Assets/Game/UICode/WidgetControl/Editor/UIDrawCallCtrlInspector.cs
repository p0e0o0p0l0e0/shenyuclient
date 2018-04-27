using System.Collections;
/******************************************************************************** 
** Copyright(c)
** auth: HooVan
** mail: opecwang@sina.com
** date: 2017.8.22
** desc: 存储控件的depth  
** Ver : V1.0.0 
*********************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIDrawCallCtrl), true)]
public class UIDrawCallCtrlInspector : Editor
{
    public override void OnInspectorGUI()
    {
        SerializedProperty sp = serializedObject.FindProperty("_mDepth");
        
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Depth");
        if (GUILayout.Button("Back", GUILayout.MinWidth(46f)))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                UIDrawCallCtrl pw = go.GetComponent<UIDrawCallCtrl>();
                if (pw != null) pw.Depth = pw.Depth - 1;
            }
        }
        EditorGUILayout.PropertyField(sp, new GUIContent(""), GUILayout.MinWidth(20f));
        if (GUILayout.Button("Forward", GUILayout.MinWidth(60f)))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                UIDrawCallCtrl pw = go.GetComponent<UIDrawCallCtrl>();
                if (pw != null) pw.Depth = pw.Depth + 1;
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        sp = serializedObject.FindProperty("_mRenderQ");
        GUILayout.Label("RenderQueue:" + sp.intValue);
        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
}
