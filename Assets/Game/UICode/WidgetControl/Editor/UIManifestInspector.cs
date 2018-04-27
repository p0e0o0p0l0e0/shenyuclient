using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
[CanEditMultipleObjects]
[CustomEditor(typeof(UIManifest), true)]
public class UIManifestInspector : Editor
{
    bool isShowCach = false;
    bool isShowMat = false;
    public override void OnInspectorGUI()
    {
        SerializedProperty sp_path = serializedObject.FindProperty("_pathes");
        SerializedProperty sp_tran = serializedObject.FindProperty("_trans");
        GUI.color = Color.green;
        bool ret = GUILayout.Button("去除不必要的事件检测");
        if (ret)
        {
            _CheckRaycast();
        }
        GUI.color = Color.white;
        isShowCach = GUILayout.Toggle(isShowCach, "显示/关闭缓存对象");
        if (isShowCach)
        {
            GUILayout.BeginVertical();
            for (int i = 0; i < sp_path.arraySize; ++i)
            {
                SerializedProperty sp1 = sp_path.GetArrayElementAtIndex(i);
                SerializedProperty sp2 = sp_tran.GetArrayElementAtIndex(i);
                GUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(sp1, new GUIContent(""), GUILayout.MinWidth(20f));
                EditorGUILayout.PropertyField(sp2, new GUIContent(""), GUILayout.MinWidth(20f));
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        //serializedObject.ApplyModifiedProperties();
        isShowMat = GUILayout.Toggle(isShowMat, "显示/关闭引用材质");
        if (isShowMat)
        {
            _CheckReferMat();
        }
        
    }
    private void _CheckReferMat()
    {
        GameObject go = Selection.gameObjects[0];
        if (go != null)
        {
            GUILayout.BeginVertical();
            Graphic[] graphics = go.GetComponentsInChildren<Graphic>(true);
            for (int i = 0; i < graphics.Length; ++i)
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(graphics[i].gameObject, typeof(GameObject));
                EditorGUILayout.ObjectField(graphics[i].material, typeof(Material));
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
    }
    private void _CheckRaycast()
    {
        GameObject go = Selection.gameObjects[0];
        if (go != null)
        {
            Graphic[] gs = go.GetComponentsInChildren<Graphic>(true);
            List<Graphic> gsList = new List<Graphic>(gs);
            Selectable[] bts = go.GetComponentsInChildren<Selectable>();
            for (int j = 0; j < bts.Length; ++j)
            {
                Selectable curElement = bts[j];
                if (curElement is ExUIButton || curElement is Button || curElement is Toggle || curElement is ExUIToggle)
                {
                    Graphic target = curElement.targetGraphic;
                    if (target != null && gsList.Contains(target))
                    {
                        gsList.Remove(target);
                    }
                }
                else
                {
                    curElement.interactable = false;
                }
            }
            UIPointerListener[] pointers = go.GetComponentsInChildren<UIPointerListener>(true);
            for (int i = 0; i < pointers.Length; ++i)
            {
                UIPointerListener pointer = pointers[i];
                Graphic graphic = pointer.gameObject.GetComponent<Graphic>();
                if (graphic != null)
                    gsList.Remove(graphic);
            }
            for (int i = 0; i < gsList.Count; ++i)
                gsList[i].raycastTarget = false;
        }
    }
}
