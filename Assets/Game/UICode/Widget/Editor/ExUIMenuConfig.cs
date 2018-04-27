using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ExUIMenuConfig
{

    [MenuItem("GameObject/UI/Extends/ExUISprite", false, 1)]
    static public void AddExUISprite(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<ExUISprite>();
        }
    }
    [MenuItem("GameObject/UI/Extends/ExText", false, 1)]
    static public void AddExTextSprite(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<ExText>();
        }
    }
    [MenuItem("GameObject/UI/Extends/ExUIButton", false, 1)]
    static public void AddExUIButton(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<ExUIButton>();
        }
    }
    [MenuItem("GameObject/UI/Extends/ExUIToggle", false, 1)]
    static public void AddExUIToggle(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<ExUIToggle>();
        }
    }
    [MenuItem("GameObject/UI/Extends/ExUITexture", false, 1)]
    static public void AddExUITexture(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<ExUITexture>();
        }
    }
    [MenuItem("GameObject/UI/Extends/UIBlock", false, 1)]
    static public void AddUIBlock(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<UIBlock>();
        }
    }
    [MenuItem("GameObject/UI/Extends/UIPanelCtrl", false, 1)]
    static public void AddUIPanelCtrl(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<UIPanelCtrl>();
        }
    }
    [MenuItem("GameObject/UI/Extends/UISubPanel", false, 1)]
    static public void AddUISubPanel(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<UISubPanel>();
        }
    }
    [MenuItem("GameObject/UI/Effects/FontGradient", false, 1)]
    static public void AddFontGradient(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<FontGradient>();
        }
    }
    [MenuItem("GameObject/UI/Effects/TweenAnim_alpha", false, 1)]
    static public void AddTweenAnim_alpha(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<TweenAnim_alpha>();
        }
    }
    [MenuItem("GameObject/UI/Effects/TweenAnim_position", false, 1)]
    static public void AddTweenAnim_position(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<TweenAnim_position>();
        }
    }
    [MenuItem("GameObject/UI/Effects/TweenScale", false, 1)]
    static public void AddTweenScale(MenuCommand menuCommand)
    {
        if (Selection.gameObjects.Length == 1)
        {
            GameObject go = Selection.gameObjects[0];
            go.AddComponent<TweenScale>();
        }
    }
    [MenuItem("Tools/UI/关闭所有界面的Canvas脚本", false, 1)]
    static public void DisableAllPanelCanvas(MenuCommand menuCommand)
    {
        string rootPath = Application.dataPath + "/UIResource/UIPrefabs/";
        foreach (string path in Directory.GetFiles(rootPath, "*.prefab"))
        {
            string assetPath = path.Substring(path.IndexOf("Assets"));
            if (assetPath.Contains("UIRoot")) continue;
            GameObject _prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            if (_prefab != null)
            {
                GameObject prefabGameobject = PrefabUtility.InstantiatePrefab(_prefab) as GameObject;
                Canvas canvas = prefabGameobject.GetComponentInChildren<Canvas>();
                if (canvas != null && canvas.enabled)
                {
                    canvas.enabled = false;
                    PrefabUtility.ReplacePrefab(prefabGameobject, _prefab, ReplacePrefabOptions.Default);                  
                }
                MonoBehaviour.DestroyImmediate(prefabGameobject);
            }

                
        }
    }
}
