using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(StoryCDGroup))]
public abstract class StoryCDGroupInspector : Editor
{
    protected abstract GUIContent Content { get; }
    private bool containerFoldout = true;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUI.enabled = true;
        base.DrawDefaultInspector();

        EditorGUILayout.Space();

        StoryCDGroup group = base.serializedObject.targetObject as StoryCDGroup;
        Refresh(group.GetArray(ref group.ItemList), Content);
    }

    protected void Refresh(StoryCDItem[] tArray, GUIContent content)
    {
        if (tArray.Length > 0)
        {
            containerFoldout = EditorGUILayout.Foldout(containerFoldout, content);
            if (containerFoldout)
            {
                EditorGUI.indentLevel++;

                for (int i = 0; i < tArray.Length; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    tArray[i].name = EditorGUILayout.TextField(tArray[i].name);
                    if (GUILayout.Button("i", GUILayout.Width(24)))
                    {
                        Selection.activeObject = tArray[i];
                    }
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUI.indentLevel--;
            }
        }
    }
}