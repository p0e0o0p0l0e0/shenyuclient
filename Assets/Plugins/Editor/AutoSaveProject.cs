using UnityEngine;
using System.Collections;
using UnityEditor;/********************************************************************
	created:	2017/10/11
	created:	11:10:2017   17:18
	filename: 	D:\Project\trunk\Program\Program\Client\Assets\AutoSaveProject.cs
	file path:	D:\Project\trunk\Program\Program\Client\Assets
	file base:	AutoSaveProject
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class AutoSaveProject : MonoBehaviour {

    private static bool isCompiling = false;


    [InitializeOnLoadMethod]
    static void Start()
    {
        PrefabUtility.prefabInstanceUpdated = delegate
        {
            GameObject go = null;
            if (Selection.activeTransform)
            {
                go = Selection.activeGameObject;
            }
            AssetDatabase.SaveAssets();
            if (go)
            {
                EditorApplication.delayCall = delegate
                {
                    Selection.activeGameObject = go;
                };
            }
        };
        EditorApplication.update += () =>
        {
            if (EditorApplication.isCompiling)
            {
                if (!isCompiling)
                {
                    isCompiling = true;
                    if (EditorApplication.isPlaying)
                        EditorApplication.ExecuteMenuItem("Edit/Play");
                }
            }
        };
        EditorApplication.delayCall += () => { isCompiling = false; }; 
    }


    [InitializeOnLoadMethod]
    static void StartInitializeOnLoadMethod()
    {
        PrefabUtility.prefabInstanceUpdated = delegate (GameObject instance)
        {
            //prefab保存的路径
            Debug.Log("自动保存预制体到工程中(省去手动点击save prject)，路径：" + AssetDatabase.GetAssetPath(PrefabUtility.GetPrefabParent(instance)));
        };
    }
}
