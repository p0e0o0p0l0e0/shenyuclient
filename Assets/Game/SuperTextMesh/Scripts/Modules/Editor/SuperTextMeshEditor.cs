using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SuperTextMesh), true)]
public class SuperTextMeshEditor : Editor
{
    SuperTextManager stm = null;
    public override void OnInspectorGUI()
    {
        SerializedProperty text = serializedObject.FindProperty("_text");
        SerializedProperty gradientCol = serializedObject.FindProperty("GradientColor");
        SerializedProperty isUseGradient = serializedObject.FindProperty("IsUseGradientColor");
        SerializedProperty gradientDir = serializedObject.FindProperty("CurGradientDirection");
        SerializedProperty isUseOutLine = serializedObject.FindProperty("IsUseOutLine");
        SerializedProperty outLineCol = serializedObject.FindProperty("OutLineColor");
        SerializedProperty outLineWidth = serializedObject.FindProperty("OutLineWidth");
        SerializedProperty shaderLineWidth = serializedObject.FindProperty("shaderOutLineWidth");
        SerializedProperty font = serializedObject.FindProperty("font");
        SerializedProperty outLineType = serializedObject.FindProperty("outLineType");
        SerializedProperty autoWrapWidth = serializedObject.FindProperty("autoWrap");
        SerializedProperty atlas = serializedObject.FindProperty("Atlas");
        SerializedProperty anchor = serializedObject.FindProperty("anchor");
        SerializedProperty style = serializedObject.FindProperty("style");
        SerializedProperty isUIMode = serializedObject.FindProperty("isUIMode");

        SuperTextMesh st = null;
        if (st == null && Selection.gameObjects.Length > 0)
        {
            st = Selection.gameObjects[0].GetComponent<SuperTextMesh>();
            if (Application.isPlaying)
                stm = SuperTextManager.Instance;
            else
                stm = NGUITools.FindInParents<SuperTextManager>(Selection.gameObjects[0]);
        }

        EditorGUILayout.PropertyField(text);
        EditorGUILayout.PropertyField(font);
        EditorGUILayout.PropertyField(style, new GUIContent("字体style"));
        EditorGUILayout.PropertyField(atlas);
        EditorGUILayout.PropertyField(anchor, new GUIContent("锚点"));
        EditorGUILayout.PropertyField(isUseGradient, new GUIContent("是否使用渐变"));
        EditorGUILayout.PropertyField(autoWrapWidth, new GUIContent("最大宽度(单位unit)"));
        
        if (isUseGradient.boolValue)
        {
            EditorGUILayout.PropertyField(gradientCol, new GUIContent("渐变颜色"));
            EditorGUILayout.PropertyField(gradientDir, new GUIContent("渐变方向"));
        }
        EditorGUILayout.PropertyField(isUseOutLine, new GUIContent("是否使用边框"));
        if (isUseOutLine.boolValue)
        {
            EditorGUILayout.PropertyField(outLineType, new GUIContent("采用描边方式"));
            EditorGUILayout.PropertyField(outLineCol, new GUIContent("边框颜色"));
            if (outLineType.intValue == (int)SuperTextMesh.OutLineType.MESH_CREATE)
                EditorGUILayout.PropertyField(outLineWidth, new GUIContent("边框宽度"));
            else
                EditorGUILayout.PropertyField(shaderLineWidth, new GUIContent("边框宽度"));
        }
        EditorGUILayout.PropertyField(isUIMode, new GUIContent("是否UI模式"));
        stm = EditorGUILayout.ObjectField("演示SuperTextManager", stm, typeof(SuperTextManager), true) as SuperTextManager;
        if (stm != null && st != null)
        {
            if (!Application.isPlaying)
            {
                if (st.font != null)
                {
                    Material _shareMat = new Material(stm.ShareShader);
                    _shareMat.SetTexture("_MainTex", st.font.material.mainTexture);
                    if (st.Atlas != null)
                        _shareMat.SetTexture("_SecondTex", st.Atlas.texture);
                    st.editorMat = _shareMat;
                    SuperTextMesh.stm = stm;
                }
                EditorGUILayout.ObjectField("材质球", st.r.sharedMaterial, typeof(Material), true);
            }
            

        }
        if (!Application.isPlaying && st != null && stm != null)
            st.Rebuild();
        serializedObject.ApplyModifiedProperties();
    }
}
