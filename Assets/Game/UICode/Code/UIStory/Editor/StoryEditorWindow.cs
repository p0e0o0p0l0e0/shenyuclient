using UnityEngine;
using UnityEditor;
using System.IO;

/********************************************************************
	created:	2016/04/20
	created:	22:4:2016   19:11
	filename: 	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\StoryEditorWindow.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Editor\Scripts
	file base:	StoryEditorWindow
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class StoryEditorWindow : EditorWindow
{
    private const string child1Name = "ConditionData1";
    private const string child2Name = "Concurrency1"; 
    private const string child3Name = "FunctionData1";

    public static string newStoryName = "BattleStory_0";
    public static bool isCreatePrefab = false;
    public static bool isCreateInHierarchy = true;

    private static string storyPath = "Assets/Resources/StoryResource/Story/{0}.prefab";
    private static string storyLocPath = "Assets/Resources/StoryResource/Story";


    public const string Camera = "Camera";
    public const string Model = "Model";
    public const string Particle = "Particle";
    public const string Audio = "Audio";
    public const string Text = "Text";

    private static string newStoryCDName = "StoryCinemaDirector_0";
    private static string[] defaultCDChildrenNames = { "Cameras", "Models", "Particles", "Audios", "Texts" };
    private static string[] storyCDChildrenNames = { "Cameras", "Models", "Particles", "Audios", "Texts" };


    [MenuItem("Tools/StoryTool/Test(Window)",false,210)]
    public static void CreateExplosion()
    {
        ScriptableWizard.DisplayWizard<ScriptableWizard>("CreateExplosion");
    }

    [MenuItem("Tools/StoryTool/CreatStory(Window) %&c", false, 200)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(StoryEditorWindow), false, "剧情工具");
    }
    public static void CreateStory()
    {
        string path = string.Format(storyPath,newStoryName);

        if (File.Exists(path))
        {
            EditorUtility.DisplayDialog("提示", "It has exist,please change a new name.", "确定");
            //EditorUtility.DisplayCustomMenu(new Rect(Screen.width/2 - 300,Screen.height/2 - 200,600,400),null,1,null,null);
            //EditorUtility.OpenFolderPanel("open", storyLocPath, "234");
            //XLGameDebugLog.Log("It has exist,please change a new name.", Color.red);
            return;
        }

        GameObject root = CreateScriptObject<StoryControl>(newStoryName);
        GameObject child = CreateScriptObject<StoryCondition>(child1Name, root.transform, true); 
        //GameObject childChild = CreateScriptObject<StoryConcurrencyFunction>(child2Name, child.transform);
        //GameObject childChildChild = CreateScriptObject<StoryFunction>(child3Name, child.transform);

        if (isCreatePrefab)
        {
            GameObject assetObj = PrefabUtility.CreatePrefab(path, root);
            //AssetDatabase.CreateAsset(,storyLocPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        if (!isCreateInHierarchy)
            DestroyImmediate(root);

        UConsole.Log("CreateStory Done.", Color.green);
    }
    /// <summary>
    /// 创建脚本物体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objName"></param>
    /// <param name="parent"></param>
    /// <param name="addCollider"></param>
    /// <returns></returns>
    private static GameObject CreateScriptObject<T>(string objName, Transform parent = null,bool addCollider = false) where T : Component
    {
        GameObject obj = new GameObject(objName);

        obj.AddComponent<T>();

        if (addCollider)
        {
            BoxCollider box = obj.AddComponent<BoxCollider>();
            box.isTrigger = true;
        }

        if (parent != null)
            obj.transform.SetParent(parent);

        return obj;
    }
    void OnGUI()
    {
        GUILayout.Label("请输入要创建的剧情根节点名字", EditorStyles.boldLabel);
        newStoryName = EditorGUILayout.TextField("剧情根节点名字:", newStoryName);
        EditorGUILayout.TextField("文件存储路径为:", storyLocPath);
        GUILayout.BeginHorizontal();
        GUILayout.Label("是否在场景中创建剧情预制体.", EditorStyles.boldLabel);
        isCreateInHierarchy = EditorGUILayout.Toggle(isCreateInHierarchy);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("是否在文件夹中创建剧情预制体.", EditorStyles.boldLabel);
        isCreatePrefab = EditorGUILayout.Toggle(isCreatePrefab);
        GUILayout.EndHorizontal();

        //GUILayout.BeginScrollView(Vector2.zero);
        //GUILayout.Label("现在已经创建的剧情：", EditorStyles.boldLabel);
        //GUILayout.Label("1.", EditorStyles.boldLabel);
        //GUILayout.Label("2.", EditorStyles.boldLabel);
        //GUILayout.Label("3.", EditorStyles.boldLabel);
        //GUILayout.EndScrollView();

        GUILayout.BeginHorizontal();
        GUILayout.Label("点击按钮创建的剧情根节点", EditorStyles.boldLabel);
        if (GUILayout.Button("创建剧情文件", GUILayout.Width(160)))
            CreateStory();
        GUILayout.EndHorizontal();


        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        GUILayout.Label("请输入剧情动画文件名", EditorStyles.boldLabel);
        newStoryCDName = EditorGUILayout.TextField("剧情动画根节点名字:", newStoryCDName);
        for (int i = 0; i < storyCDChildrenNames.Length; i++)
        {
            storyCDChildrenNames[i] = EditorGUILayout.TextField("剧情动画子节点名字:", storyCDChildrenNames[i]);
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("添加剧情动画子节点", GUILayout.Width(140)))
            AddStoryCDChildRoot();
        if (GUILayout.Button("移除剧情动画子节点", GUILayout.Width(140)))
            RemoveStoryCDChildRoot();
        if (GUILayout.Button("恢复默认剧情动画子节点", GUILayout.Width(150)))
            RevertDefaultChildRoot();
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        GUILayout.Label("点击按钮创建的剧情动画文件", EditorStyles.boldLabel);
        if (GUILayout.Button("创建剧情动画文件", GUILayout.Width(180)))
            CreateStoryCinemaDirector();
        GUILayout.EndHorizontal();

    }

    public static void CreateStoryCinemaDirector()
    {
        GameObject root = new GameObject(newStoryCDName);
        StoryCinemaDirector scd = root.AddComponent<StoryCinemaDirector>();

        CutsceneCreatorWindow ccw = CreateInstance<CutsceneCreatorWindow>();
        scd.Cutscene = ccw.CreateEmptyCutscene();
        scd.Cutscene.transform.SetParent(root.transform);

        //CinemaDirector.CutsceneTrigger ct = root.AddComponent<CinemaDirector.CutsceneTrigger>();
        //ct.Cutscene = scd.Cutscene;

        scd.Parents = new StoryCDGroup[storyCDChildrenNames.Length];

        for (int i = 0; i < storyCDChildrenNames.Length; i++)
        {
            GameObject child = new GameObject(storyCDChildrenNames[i]);
            child.transform.SetParent(root.transform);
            scd.Parents[i] = AddChildrenComponent(ref child, storyCDChildrenNames[i]);
        }

        UConsole.Log("CreateStoryCinemaDirector Done.", Color.green);
    }

    private static StoryCDGroup AddChildrenComponent(ref GameObject obj,string name)
    {
        if (name.Contains(Camera))
        {
            return obj.AddComponent<StoryCDCameraGroup>();
        }
        else if (name.Contains(Model))
        {
            return obj.AddComponent<StoryCDModelGroup>();
        }
        else if (name.Contains(Particle))
        {
            return obj.AddComponent<StoryCDParticleGroup>();
        }
        else if (name.Contains(Audio))
        {
            return obj.AddComponent<StoryCDAudioGroup>();
        }
        else if (name.Contains(Text))
        {
            return obj.AddComponent<StoryCDTextGroup>();
        }
        else
        {
            return obj.AddComponent<StoryCDDefaultGroup>();
        }
    }

    public static void AddStoryCDChildRoot()
    {
        string[] newNames = new string[storyCDChildrenNames.Length + 1];

        for (int i = 0; i < storyCDChildrenNames.Length; i++)
        {
            newNames[i] = storyCDChildrenNames[i];
        }

        newNames[storyCDChildrenNames.Length] = "Empty";

        storyCDChildrenNames = newNames;
    }

    public static void RemoveStoryCDChildRoot()
    {
        if (storyCDChildrenNames.Length <= 0)
        {
            return;
        }

        string[] newNames = new string[storyCDChildrenNames.Length - 1];

        for (int i = 0; i < newNames.Length; i++)
        {
            newNames[i] = storyCDChildrenNames[i];
        }

        storyCDChildrenNames = newNames;
    }

    public static void RevertDefaultChildRoot()
    {
        storyCDChildrenNames = defaultCDChildrenNames;
    }
}
