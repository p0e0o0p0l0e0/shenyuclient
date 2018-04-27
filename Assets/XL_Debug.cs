using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XL_Debug : MonoBehaviour {

    ResourceRequest mResLoader = new ResourceRequest();
    GameObject mUI = null;
    // Use this for initialization
    void Start ()
    {
        //ResourceLoadManager.Instance.Initialize();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnGUI()
    {
        if (GUILayout.Button("加载 UI"))
        {
            mResLoader.Start("uiresource/uiprefabs/uiloginwindow", "Assets/UIResource/UIPrefabs/UILoginWindow.prefab", (UnityEngine.Object pAsset) =>
            {
                mUI = GameObject.Instantiate(pAsset) as GameObject;
            });
        }
        if (GUILayout.Button("卸载 UI"))
        {
            GameObject.DestroyImmediate(mUI, true);
            mUI = null;
            Resources.UnloadUnusedAssets();
            mResLoader.End();
        }
    }
}
