using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(STMQuadData), true)]
[CanEditMultipleObjects]
public class STMQuadDataEditor : Editor
{
    const string Atlas = "Atlas";
    const string SpriteName = "SpriteName";
    public override void OnInspectorGUI()
    {
        GUI.color = Color.green;
        GUILayout.BeginHorizontal();
        if (NGUIEditorTools.DrawPrefixButton("Atlas"))
            ComponentSelector.Show<UIAtlas>(OnSelectAtlas);
        SerializedProperty atlas = NGUIEditorTools.DrawProperty("", serializedObject, Atlas, GUILayout.MinWidth(20f));
        GUILayout.EndHorizontal();
        SerializedProperty sp = serializedObject.FindProperty(SpriteName);
        NGUIEditorTools.DrawAdvancedSpriteField(atlas.objectReferenceValue as UIAtlas, sp.stringValue, SelectSprite, false);
        serializedObject.ApplyModifiedProperties();

        GUI.color = Color.white;
        _STMQuadData();
    }
    private void _STMQuadData()
    {
        //serializedObject.Update();
        ////gather parts for this data:
        //UIAtlas atlas = null;
        //STMQuadData quadData = this.target as STMQuadData;
        //if (quadData != null)
        //    atlas = quadData.Atlas;
        ////SerializedProperty filterMode = serializedObject.FindProperty("filterMode");
        //SerializedProperty columns = serializedObject.FindProperty("columns");
        //SerializedProperty rows = serializedObject.FindProperty("rows");
        //SerializedProperty iconIndex = serializedObject.FindProperty("iconIndex");
        //SerializedProperty size = serializedObject.FindProperty("size");
        //SerializedProperty offset = serializedObject.FindProperty("offset");
        //SerializedProperty advance = serializedObject.FindProperty("advance");
        //SerializedProperty animDelay = serializedObject.FindProperty("animDelay");
        //SerializedProperty frames = serializedObject.FindProperty("frames");
        //SerializedProperty silhouette = serializedObject.FindProperty("silhouette");
        ////the rest:
        //if (atlas != null)
        //{
        //    Settings();
        //    EditorGUILayout.PropertyField(silhouette, new GUIContent("是否应用文字颜色"));
        //    //EditorGUILayout.PropertyField(filterMode);
        //    EditorGUILayout.Space(); //////////////////SPACE
        //    //EditorGUILayout.PropertyField(columns);
        //    //EditorGUILayout.PropertyField(rows);
        //    EditorGUILayout.Space(); //////////////////SPACE
        //    if (animDelay.floatValue <= 0f)
        //    {
        //        EditorGUILayout.PropertyField(iconIndex); //use single icon index
        //    }
        //    if (columns.intValue > 1)
        //    {
        //        EditorGUILayout.PropertyField(animDelay);
        //        if (animDelay.floatValue > 0f)
        //        {
        //            EditorGUILayout.PropertyField(frames, true); //iterate thru multiple
        //        }
        //    }
        //    EditorGUILayout.Space(); //////////////////SPACE
        //    EditorGUILayout.PropertyField(size);
        //    EditorGUILayout.PropertyField(offset);
        //    EditorGUILayout.PropertyField(advance);
        //}

        //EditorGUILayout.Space(); //////////////////SPACE
        ////FixColumnCount();
        //if (this != null) serializedObject.ApplyModifiedProperties(); //since break; cant be called
    }
    void SelectSprite(string spriteName)
    {
        serializedObject.Update();
        SerializedProperty sp = serializedObject.FindProperty(SpriteName);
        sp.stringValue = spriteName;
        serializedObject.ApplyModifiedProperties();
        NGUITools.SetDirty(serializedObject.targetObject);
        NGUISettings.selectedSprite = spriteName;
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
    void Settings()
    {
        //STMQuadData quadData = this.target as STMQuadData;
        //UIAtlas atlas = quadData.Atlas;
        //quadData.texture = atlas.texture;
        
        //if (!string.IsNullOrEmpty(quadData.SpriteName))
        //{
        //    UISpriteData spriteData = atlas.GetSprite(quadData.SpriteName);
        //    if (spriteData != null)
        //    {
        //        //convert to stmquad data setting
        //        int width = spriteData.width;
        //        int height = spriteData.height;

        //    }
        //}
    }
}
