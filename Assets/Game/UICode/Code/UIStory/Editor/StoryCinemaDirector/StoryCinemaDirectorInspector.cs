using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StoryCinemaDirector))]
public class StoryCinemaDirectorInspector : Editor
{
    private static string storyPath = "Assets/Resources/StoryResource/Story/";
    private static string storyBackupsPath = "Assets/Resources/StoryResource/Story/Origin/";
    private const string PrefabName = "{0}.prefab";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUI.enabled = true;
        base.DrawDefaultInspector();

        EditorGUILayout.Space();
        storyPath = EditorGUILayout.TextField("文件路径：",storyPath);
        GUI.color = Color.green;
        if (GUILayout.Button("导出预制体"))
        {
            StoryCinemaDirector scd = (StoryCinemaDirector)target;

            GameObject obj = scd.gameObject;
            //备份原始
            string path0 = string.Format(storyBackupsPath + PrefabName, obj.name);
            GameObject backupObj = StoryEditorUtils.FloderCreatePrefab(path0, obj, false);

            GameObject newObj = Instantiate(obj,obj.transform.position,obj.transform.rotation);
            newObj.name = obj.name;
            PrefabUtility.ConnectGameObjectToPrefab(newObj, backupObj);

            //处理Camera
            Camera[] cams = obj.GetComponentsInChildren<Camera>();
            for (int i = 0; i < cams.Length; i++)
            {
                cams[i].enabled = false;
            }

            //处理model
            StoryCDModelItem[] modelItems = obj.GetComponentsInChildren<StoryCDModelItem>();
            for (int i = 0; i < modelItems.Length; i++)
            {
                if (modelItems[i] == null)
                {
                    continue;
                }
                if (modelItems[i].IsPlayer)
                {
                    foreach (Transform child in modelItems[i].transform)
                    {
                        GameObject.DestroyImmediate(child.gameObject);
                    }
                }
            }
            //处理audio
            AudioSource[] audios = obj.GetComponentsInChildren<AudioSource>();
            for (int i = 0; i < audios.Length; i++)
            {
                if (audios[i] == null)
                {
                    continue;
                }
                audios[i].clip = null;
                audios[i].playOnAwake = false;
            }

            string path = string.Format(storyPath + PrefabName, obj.name);
            StoryEditorUtils.FloderCreatePrefab(path, obj);
            GameObject.DestroyImmediate(obj);
        }
        GUI.color = Color.white;
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUI.color = Color.yellow;
        if (GUILayout.Button("初始化(运行下测试)"))
        {
            StoryCinemaDirector scd = (StoryCinemaDirector)target;

            scd.Init();
        }
        if (GUILayout.Button("播放(运行下测试)"))
        {
            StoryCinemaDirector scd = (StoryCinemaDirector)target;

            scd.Play();
        }
        if (GUILayout.Button("暂停(运行下测试)"))
        {
            StoryCinemaDirector scd = (StoryCinemaDirector)target;

            scd.Pause();
        }
        if (GUILayout.Button("停止(运行下测试)"))
        {
            StoryCinemaDirector scd = (StoryCinemaDirector)target;

            scd.Stop();
        }
        GUI.color = Color.white;

        if (serializedObject.targetObject != null)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}