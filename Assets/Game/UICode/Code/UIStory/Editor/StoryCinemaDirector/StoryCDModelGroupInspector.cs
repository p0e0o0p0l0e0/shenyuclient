using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(StoryCDModelGroup))]
public class StoryCDModelGroupInspector : StoryCDGroupInspector
{
    protected override GUIContent Content { get { return new GUIContent("模型列表", "包含所有的模型."); } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        if (GUILayout.Button("添加模型"))
        {
            ShowAddContextMenu();
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void ShowAddContextMenu()
    {
        GenericMenu createMenu = new GenericMenu();

        CharacterType e = new CharacterType();
        string[] values = System.Enum.GetNames(e.GetType());

        for (int i = 0; i < values.Length; i++)
        {
            createMenu.AddItem(new GUIContent(StoryCDModelItemInspector.TypeMenu[i]), false, new GenericMenu.MenuFunction2(ClickCallBack), values[i]);
        }

        createMenu.ShowAsContext();
    }

    private void ClickCallBack(object data)
    {
        StoryCDModelGroup group = base.serializedObject.targetObject as StoryCDModelGroup;
        string value = data as String;
        CharacterType e = (CharacterType)Enum.Parse(typeof(CharacterType), value);

        group.Add<StoryCDModelItem>(ref group.ItemList, StoryEditorWindow.Model,new StoryCDModelGroupInfo(e));
    }
}