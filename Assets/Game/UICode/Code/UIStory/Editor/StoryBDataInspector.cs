using UnityEngine;
using UnityEditor;

/********************************************************************
	created:	2016/09/24
	created:	24:9:2016   11:19
	filename: 	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story\StoryBDataInspector.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story
	file base:	StoryBDataInspector
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/

[CustomEditor(typeof(StoryControlData))]
public class StoryBDataInspector : StoryDataInspector
{
    private const string storyPath = "Assets/Resources/StoryResource/Story/{0}.prefab";
    private string path = "";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUI.enabled = true;

        base.DrawDefaultInspector();
        GUI.color = Color.green;
        if (GUILayout.Button("导出预制体"))
        {
            StoryControlData data = (StoryControlData)target;

            GameObject obj = data.gameObject;
            //处理Camera
            Camera[] cams = obj.GetComponentsInChildren<Camera>();
            for (int i = 0; i < cams.Length; i++)
                cams[i].enabled = false;
            //处理storyfunction
            StoryFunctionData[] functionDatas = obj.GetComponentsInChildren<StoryFunctionData>();
            for (int i = 0; i < functionDatas.Length; i++)
            {
                StoryFunction sf = functionDatas[i].GetComponent<StoryFunction>();
                if (sf != null)
                    sf.isAutoPlay = functionDatas[i].reqStoryFunction == null;
            }

            path = string.Format(storyPath, obj.name);
            StoryEditorUtils.FloderCreatePrefab(path, obj);
        }
        GUI.color = Color.white;
        serializedObject.ApplyModifiedProperties();

    }
}
