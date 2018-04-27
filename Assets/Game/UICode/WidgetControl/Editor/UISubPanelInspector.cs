using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CanEditMultipleObjects]
[CustomEditor(typeof(UISubPanel), true)]
public class UISubPanelInspector : Editor
{
    public override void OnInspectorGUI()
    {
        SerializedProperty sp = serializedObject.FindProperty("_mIsControlDepth");
        EditorGUILayout.PropertyField(sp, new GUIContent("手动调整渲染层次"), GUILayout.MinWidth(20f));
        GameObject go = Selection.gameObjects[0];
        UIPanelCtrl panCtrl = go.GetComponent<UIPanelCtrl>();
        UISubPanel group = go.GetComponent<UISubPanel>();

        if (sp.boolValue)
        {
            if (panCtrl == null)
                go.AddComponent<UIPanelCtrl>();
            Transform[] trans = go.GetComponentsInChildren<Transform>();
            for (int i = 0; i < trans.Length; i++)
            {
                Graphic gs = trans[i].GetComponent<Graphic>();
                if (gs != null)
                {
                    DoGraphicReplace(gs, trans[i]);
                }
                else
                {
                    ParticleSystem ps = trans[i].GetComponent<ParticleSystem>();
                    if (ps != null)
                    {
                        UIDrawCallCtrl dC = trans[i].GetComponent<UIDrawCallCtrl>();
                        if (dC == null)
                            trans[i].gameObject.AddComponent<UIDrawCallCtrl>();
                    }
                    else
                    {
                        Renderer render = trans[i].GetComponent<Renderer>();
                        if (render != null)
                            trans[i].gameObject.AddComponent<UIDrawCallCtrl>();
                    }
                }
            }

        }
        else
        {
            if (panCtrl != null)
            {
                GameObject.DestroyImmediate(panCtrl);
            }

            Transform[] trans = go.GetComponentsInChildren<Transform>();
            for (int i = 0; i < trans.Length; i++)
            {
                UndoGraphicReplace(trans[i]);
            }
        }

        sp = serializedObject.FindProperty("_mIsCollider");
        EditorGUILayout.PropertyField(sp, new GUIContent("是否生成事件阻挡层"), GUILayout.MinWidth(20f));
        group.MakeChange();
        sp = serializedObject.FindProperty("_mIsBlocking");
        EditorGUILayout.PropertyField(sp, new GUIContent("当前是否被阻挡"), GUILayout.MinWidth(20f));
        serializedObject.ApplyModifiedProperties();
    }
    void DoGraphicReplace(Graphic gs, Transform tran)
    {
        if (gs is Image)
        {
            Image image = tran.gameObject.GetComponent<Image>();
            
            if (image != null && !(image is ExUISprite))
            {
                GameObject.DestroyImmediate(image);
                tran.gameObject.AddComponent<ExUISprite>();
            }
            UIMerDrawCallCtrl merDC = tran.GetComponent<UIMerDrawCallCtrl>();
            if (merDC == null)
                tran.gameObject.AddComponent<UIMerDrawCallCtrl>();
        }
        else
        {
            RawImage rawImage = tran.GetComponent<RawImage>();
            if (rawImage != null && !(rawImage is ExUITexture))
            {
                GameObject.DestroyImmediate(rawImage);
                tran.gameObject.AddComponent<ExUITexture>();               
            }
            UIDrawCallCtrl dC = tran.GetComponent<UIDrawCallCtrl>();
            if (dC == null)
                tran.gameObject.AddComponent<UIDrawCallCtrl>();
        }
    }
    void UndoGraphicReplace(Transform tran)
    {
        UIDrawCallCtrl[] dcs = tran.GetComponents<UIDrawCallCtrl>();
        for (int i = 0; i < dcs.Length; i++)
        {
            if (dcs[i] is UIMerDrawCallCtrl)
                GameObject.DestroyImmediate((UIMerDrawCallCtrl)dcs[i]);
            else
                GameObject.DestroyImmediate(dcs[i]);
        }
    }
}
