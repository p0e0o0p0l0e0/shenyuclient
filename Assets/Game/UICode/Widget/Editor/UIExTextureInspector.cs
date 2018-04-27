using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(ExUITexture), true)]
[CanEditMultipleObjects]

public class UIExTextureInspector : RawImageEditor 
{
    protected override void OnEnable()
    {
        base.OnEnable();

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SerializedProperty sp = null;
        //SerializedProperty sp = serializedObject.FindProperty("isGrandient");
        //EditorGUILayout.PropertyField(sp, new GUIContent("是否尾部渐变"));
        GameObject go = ((ExUITexture)serializedObject.targetObject).gameObject;
        Canvas canvas = NGUITools.FindInParents<Canvas>(go);
        //if (sp.boolValue)
        //{
        //    if (canvas != null)
        //        canvas.additionalShaderChannels = (canvas.additionalShaderChannels | AdditionalCanvasShaderChannels.Normal);
        //    sp = serializedObject.FindProperty("_gradientFactor");
        //    EditorGUILayout.PropertyField(sp, new GUIContent("渐变分隔点"));
        //    sp = serializedObject.FindProperty("_gradientFactorScale");
        //    EditorGUILayout.PropertyField(sp, new GUIContent("渐变放大系数"));
        //}
        //else
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
