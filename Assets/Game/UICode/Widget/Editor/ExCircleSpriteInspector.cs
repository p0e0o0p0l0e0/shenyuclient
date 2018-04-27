using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ExCircleSprite), true)]
[CanEditMultipleObjects]
public class ExCircleSpriteInspector : GraphicEditor
{
    const string Atlas = "_mAtlas";
    const string RayCast = "_isRaycastTarget";
    const string FillPercent = "fillPercent";
    const string IsFill = "fill";
    const string Thickness = "thickness";
    const string Segements = "segements";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("----extend----");
        GUILayout.BeginVertical();
        SerializedProperty property = serializedObject.FindProperty(FillPercent);
        EditorGUILayout.PropertyField(property, new GUIContent("填充百分比"), GUILayout.MinWidth(20f));
        property = serializedObject.FindProperty(IsFill);
        EditorGUILayout.PropertyField(property, new GUIContent("是否填充"), GUILayout.MinWidth(20f));
        property = serializedObject.FindProperty(Thickness);
        EditorGUILayout.PropertyField(property, new GUIContent("圆环宽度"), GUILayout.MinWidth(20f));
        property = serializedObject.FindProperty(Segements);
        EditorGUILayout.PropertyField(property, new GUIContent("片段数量"), GUILayout.MinWidth(20f));
        GUILayout.EndVertical();
        GUILayout.BeginHorizontal();
        if (NGUIEditorTools.DrawPrefixButton("Atlas"))
            ComponentSelector.Show<UIAtlas>(OnSelectAtlas);
        SerializedProperty atlas = NGUIEditorTools.DrawProperty("", serializedObject, Atlas, GUILayout.MinWidth(20f));
        GUILayout.EndHorizontal();
        SerializedProperty sp = serializedObject.FindProperty("_mSpriteName");
        NGUIEditorTools.DrawAdvancedSpriteField(atlas.objectReferenceValue as UIAtlas, sp.stringValue, SelectSprite, false);
        serializedObject.ApplyModifiedProperties();

    }
    void SelectSprite(string spriteName)
    {
        serializedObject.Update();
        SerializedProperty sp = serializedObject.FindProperty("_mSpriteName");
        sp.stringValue = spriteName;
        serializedObject.ApplyModifiedProperties();
        NGUITools.SetDirty(serializedObject.targetObject);
        NGUISettings.selectedSprite = spriteName;
    }
    private void DrawProperty(SerializedProperty sp, GUIContent content)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(sp, content);
        EditorGUILayout.EndHorizontal();
    }
    void OnSelectAtlas(Object obj)
    {
        serializedObject.Update();
        SerializedProperty sp = serializedObject.FindProperty(Atlas);
        sp.objectReferenceValue = obj;
        serializedObject.ApplyModifiedProperties();
        NGUITools.SetDirty(serializedObject.targetObject);
        NGUISettings.atlas = obj as UIAtlas;
    }
}
