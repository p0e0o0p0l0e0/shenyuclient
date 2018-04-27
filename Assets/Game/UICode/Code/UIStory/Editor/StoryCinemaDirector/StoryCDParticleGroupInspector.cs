using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StoryCDParticleGroup))]
public class StoryCDParticleGroupInspector : StoryCDGroupInspector
{
    protected override GUIContent Content { get { return new GUIContent("粒子列表", "包含所有的粒子."); } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        if (GUILayout.Button("添加粒子(暂未实现)"))
        {
            StoryCDParticleGroup group = base.serializedObject.targetObject as StoryCDParticleGroup;
            group.Add<StoryCDDefualtItem>(ref group.ItemList, StoryEditorWindow.Particle);
        }

        serializedObject.ApplyModifiedProperties();
    }
}