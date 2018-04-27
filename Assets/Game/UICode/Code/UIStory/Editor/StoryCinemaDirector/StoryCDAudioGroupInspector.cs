using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StoryCDAudioGroup))]
public class StoryCDAudioGroupInspector : StoryCDGroupInspector
{
    protected override GUIContent Content { get { return new GUIContent("声音接收器列表", "包含所有的声音接收器."); } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.Space();

        if (GUILayout.Button("添加声音接受器"))
        {
            StoryCDAudioGroup audioGroup = base.serializedObject.targetObject as StoryCDAudioGroup;
            audioGroup.Add<StoryCDDefualtItem>(ref audioGroup.ItemList, StoryEditorWindow.Audio);
        }

        serializedObject.ApplyModifiedProperties();
    }
}