using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(StoryCDCameraGroup))]
public class StoryCDCameraGroupInspector : StoryCDGroupInspector
{
    protected override GUIContent Content { get { return new GUIContent("相机列表", "包含所有的相机."); } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        
        if (GUILayout.Button("添加相机"))
        {
            StoryCDCameraGroup camGroup = base.serializedObject.targetObject as StoryCDCameraGroup;
            camGroup.Add<StoryCDCameraItem>(ref camGroup.ItemList, StoryEditorWindow.Camera,new StoryCDCameraInfo());
        }
        
        serializedObject.ApplyModifiedProperties();

    }
}