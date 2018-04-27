using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ExUISprite), true)]
[CanEditMultipleObjects]
public class UIExSpriteInspector : ImageEditor
{
    const string Atlas = "_mAtlas";
    const string RayCast = "_isRaycastTarget";
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("----extend----");
        GUILayout.BeginHorizontal();
        if (NGUIEditorTools.DrawPrefixButton("Atlas"))
            ComponentSelector.Show<UIAtlas>(OnSelectAtlas);
        SerializedProperty atlas = NGUIEditorTools.DrawProperty("", serializedObject, Atlas, GUILayout.MinWidth(20f));
        GUILayout.EndHorizontal();
        SerializedProperty sp = serializedObject.FindProperty("_mSpriteName");
        NGUIEditorTools.DrawAdvancedSpriteField(atlas.objectReferenceValue as UIAtlas, sp.stringValue, SelectSprite, false);
        sp = serializedObject.FindProperty("isGrandient");
        EditorGUILayout.PropertyField(sp, new GUIContent("是否尾部渐变"));
        GameObject go = ((ExUISprite)serializedObject.targetObject).gameObject;
        Canvas canvas = NGUITools.FindInParents<Canvas>(go);
        if (sp.boolValue)
        {
            if (canvas != null)
                canvas.additionalShaderChannels = (canvas.additionalShaderChannels | AdditionalCanvasShaderChannels.Normal);
            sp = serializedObject.FindProperty("_gradientFactor");
            EditorGUILayout.PropertyField(sp, new GUIContent("渐变分隔点"));
            sp = serializedObject.FindProperty("_gradientFactorScale");
            EditorGUILayout.PropertyField(sp, new GUIContent("渐变放大系数"));
        }
        else
        {
            if (canvas != null)
            {
                bool flag = CheckOther(canvas);
                if (!flag)
                    canvas.additionalShaderChannels = canvas.additionalShaderChannels & ~AdditionalCanvasShaderChannels.Normal;
            }
           
        }
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
    private bool CheckOther(Canvas canvas)
    {
        ExUITexture[] textures = canvas.gameObject.GetComponentsInChildren<ExUITexture>();
        bool flag = false;
        for (int i = 0; i < textures.Length; ++i)
        {
            if (textures[i].isGrandient)
            {
                flag = true;
                break;
            }
        }
        ExUISprite[] sprites = canvas.gameObject.GetComponentsInChildren<ExUISprite>();
        for (int i = 0; i < sprites.Length; ++i)
        {
            if (sprites[i].isGrandient)
            {
                flag = true;
                break;
            }
        }
        return flag;
    }
}
