using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(ExUIToggle), true)]
    [CanEditMultipleObjects]
    public class ExToggleEditor : SelectableEditor
    {
        const string Atlas = "_mAtlas";
        SerializedProperty m_Sprite;
        SerializedProperty m_IsOnProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_Sprite = serializedObject.FindProperty("rednerSp");
            
            m_IsOnProperty = serializedObject.FindProperty("m_IsOn");
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(m_Sprite, new GUIContent("Target"), GUILayout.MinWidth(20f));
            GUILayout.BeginHorizontal();
            if (NGUIEditorTools.DrawPrefixButton("Atlas"))
                ComponentSelector.Show<UIAtlas>(OnSelectAtlas);
            SerializedProperty atlas = NGUIEditorTools.DrawProperty("", serializedObject, Atlas, GUILayout.MinWidth(20f));
            GUILayout.EndHorizontal();
            if (atlas.objectReferenceValue != null)
            {
                SerializedProperty sp = serializedObject.FindProperty("normalSpName");
                EditorGUILayout.LabelField("Normal Sprite");
                NGUIEditorTools.DrawAdvancedSpriteField(atlas.objectReferenceValue as UIAtlas, sp.stringValue, SelectNormalSprite, false);
                sp = serializedObject.FindProperty("toggleSpName");
                EditorGUILayout.LabelField("Toggle Sprite");
                NGUIEditorTools.DrawAdvancedSpriteField(atlas.objectReferenceValue as UIAtlas, sp.stringValue, SelectToggleSprite, false);
            }
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
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
        void SelectNormalSprite(string spriteName)
        {
            serializedObject.Update();
            SerializedProperty sp = serializedObject.FindProperty("normalSpName");
            sp.stringValue = spriteName;
            serializedObject.ApplyModifiedProperties();
            NGUITools.SetDirty(serializedObject.targetObject);
            NGUISettings.selectedSprite = spriteName;
        }
        void SelectToggleSprite(string spriteName)
        {
            serializedObject.Update();
            SerializedProperty sp = serializedObject.FindProperty("toggleSpName");
            sp.stringValue = spriteName;
            serializedObject.ApplyModifiedProperties();
            NGUITools.SetDirty(serializedObject.targetObject);
            NGUISettings.selectedSprite = spriteName;
        }

    }

}

