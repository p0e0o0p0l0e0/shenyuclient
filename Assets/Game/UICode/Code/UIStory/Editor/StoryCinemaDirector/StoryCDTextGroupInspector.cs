using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StoryCDTextGroup))]
public class StoryCDTextGroupInspector : StoryCDGroupInspector
{
    protected override GUIContent Content { get { return new GUIContent("文本列表", "包含所有的文本."); } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        if (GUILayout.Button("添加文本(暂未实现)"))
        {
            StoryCDTextGroup group = base.serializedObject.targetObject as StoryCDTextGroup;
            group.Add<StoryCDDefualtItem>(ref group.ItemList, StoryEditorWindow.Text);
        }

        serializedObject.ApplyModifiedProperties();
    }
}