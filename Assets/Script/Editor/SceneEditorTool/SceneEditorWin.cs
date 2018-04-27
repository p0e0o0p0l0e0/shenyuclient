using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

public class SceneEditorWin : EditorWindow
{
	public static SceneEditorWin Instance;
    private Vector2 mScrollPosition;

    private List<string> mMapList = new List<string>();
    private List<string> mBirthList = new List<string>();
    private List<ViewData> mViewDataList = new List<ViewData>();

    private List<string> mShowProperty = new List<string>();

    int mMapIndex = 1;
    int mLastIndex = 1;
    int mEditorIndex = 0;

    private Texture2D mLineTex = null;
    private Texture2D mEmptyTex = null;
    private Texture2D mSelectTex = null;
    private Texture2D mEditorTex = null;

    GameObject _staticRes;
    GameObject _root = null;
    ResourceRequest mResLoader = new ResourceRequest();

    Transform mLogicRoot = null;

    [MenuItem("Scene/布怪工具")]
	static void Execute()
	{
        if (!Application.isPlaying || !GameApplication.Instance.IsEditor)
        {
            Debug.LogError("需要运行! 并运行Editor场景");
            return;
        }

        SceneEditorWin pWin = (SceneEditorWin)EditorWindow.GetWindow(typeof(SceneEditorWin));
        pWin.titleContent = new GUIContent("场景布怪编辑器");
        pWin.Init();
        pWin.Show();
	}

    GameObject GetChildByName(Transform pTrans, string sName)
    {
        if (pTrans != null)
        {
            for (int i = 0; i < pTrans.childCount; ++i)
            {
                if (pTrans.GetChild(i).name == sName)
                {
                    return pTrans.GetChild(i).gameObject;
                }
            }
        }

        return null;
    }

    void Init()
    {
        Instance = this;

        GameObject objGame = GameObject.Find("Game");
        if (objGame != null)
        {
            NavPaint np = objGame.GetComponent<NavPaint>();
            if (np != null)
            {
                np.enabled = false;
            }
        }

        GameObject objPlane = GetChildByName(objGame.transform, "Plane");
        if (objPlane != null)
        {
            objPlane.SetActive(false);
        }

        StructHandler<SimpleAvatarStruct>.Instance.Load();
        StructHandler<VisualNPCStruct>.Instance.Load();
        StructHandler<SpaceStruct>.Instance.Load();
        StructHandler<NPCStruct>.Instance.Load();
        StructHandler<SpaceNPCReplacerStruct>.Instance.Load();
        StructHandler<NPCEnterSpaceStruct>.Instance.Load();
        StructHandler<NPCBirthPropertyStruct>.Instance.Load();
        StructHandler<SpaceRouteStruct>.Instance.Load();
        StructHandler<SpaceBirthControllerStruct>.Instance.Load();
        StructHandler<PathFileResStruct>.Instance.Load();
        StructHandler<SpaceConfigStruct>.Instance.Load();
        StructHandler<NPCBirthPositionStruct>.Instance.Load();

        List<ViewData> pDataList = DataEditor.GetDatas<SpaceStruct>();
        mMapList.Clear();
        for (int i = 0; i < pDataList.Count; ++i)
        {
            mMapList.Add(pDataList[i].data.ID + "<->" + pDataList[i].data.Name + "[" + pDataList[i].data.Note + "]");
        }
        mMapIndex = Mathf.Clamp(mMapIndex, 1, mMapList.Count - 1);
        InitBirthPosition();

        mLineTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Line.jpg", typeof(Texture2D)) as Texture2D;
        mSelectTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Select.jpg", typeof(Texture2D)) as Texture2D;
        mEmptyTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Empty.jpg", typeof(Texture2D)) as Texture2D;
        mEditorTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Editor.jpg", typeof(Texture2D)) as Texture2D;

        mShowProperty.Clear();
        mShowProperty.AddRange(new string[]{"Range", "NPC", "Count"});

        mLogicRoot = GameObject.Find("LogicRoot").transform;
        mLogicRoot.DestroyChildren();

        mEditorIndex = 0;
    }

    void OnDestroy()
    {
        if (_root != null)
        {
            Destroy(_root);
        }
        mEditorIndex = 0;
        Instance = null;

        if (mLogicRoot != null)
        {
            mLogicRoot.DestroyChildren();
        }
    }

    void LoadScene(SpaceConfigStruct info)
    {
        mResLoader.Start(info.StaticResource.Data, OnLoad); 
    }

    void OnLoad(UnityEngine.Object pAssset)
    {
        UnityAssisstant.Destroy(ref _staticRes);
        _root = GameObject.Find("Scene");
        if (_root == null)
        {
            _root = new GameObject("Scene");
        }
        _staticRes = UnityAssisstant.InstantiateAsChild(pAssset as GameObject, _root.transform);

        Transform nParent = _staticRes.transform.GetChild(0);
        int nCount = nParent.childCount;
        for (int i = 0; i < nCount; ++i)
        {
            if (nParent.GetChild(i).gameObject.layer == 8)
            {
                nParent.GetChild(i).gameObject.AddComponent<BoxCollider>();
            }
        }
        mResLoader.End();
    }

    void InitBirthPosition()
    {
        List<ViewData> pMapDataList = DataEditor.GetDatas<SpaceStruct>();
        int nCurMapID = pMapDataList[mMapIndex].data.ID;

        mBirthList.Clear();
        mViewDataList.Clear();
        List<ViewData> pBirthList = DataEditor.GetDatas<NPCBirthPositionStruct>();
        for (int i = 0; i < pBirthList.Count; ++i)
        {
            NPCBirthPositionStruct pData = (NPCBirthPositionStruct)pBirthList[i].data;
            if (pData.Space.Data.ID == nCurMapID)
            {
                mBirthList.Add(pBirthList[i].data.ID + "<->" + pBirthList[i].data.Name);
                mViewDataList.Add(pBirthList[i]);
            }
        }
    }

    private int DeleteDialog()
    {
        ViSealedData pData = mViewDataList[mEditorIndex].data;
        if (pData != null)
        {
            if (EditorUtility.DisplayDialog("ViVisualAuraStruct 删除 ID = " + pData.ID, "确定要删除  " + pData.Name + "  吗?", "确定", "取消"))
            {
                int vIndex = StructHandler<NPCBirthPositionStruct>.Instance.DeleteDataByID(pData.ID);
                DeleteEntity(pData.ID);
                InitBirthPosition();
                return vIndex;
            }
        }

        return -1;
    }

    public void LoadNpcBirths()
    {
        string rootObjName = "布怪[ " + mMapList[mMapIndex] + " ] List";
        GameObject rootObj = GameObject.Find(rootObjName);
        if (rootObj == null)
        {
            rootObj = new GameObject(rootObjName);
            rootObj.transform.parent = mLogicRoot;
        }
        int childCount = rootObj.transform.childCount;
        rootObj.transform.DestroyChildren();

        Vector3 newViewDataPos = new Vector3(0, 0, 0);
        if (SceneView.lastActiveSceneView != null)
        {
            newViewDataPos = SceneView.lastActiveSceneView.camera.transform.position;
            newViewDataPos += SceneView.lastActiveSceneView.camera.transform.forward * 6f;
        }



        for (int i = 0; i < mViewDataList.Count; ++i)
        {
            EditableContainer title = mViewDataList[i].title;
            NPCBirthPositionStruct info = (NPCBirthPositionStruct)mViewDataList[i].data;

            //判断是否是新创建的Npc
            if (childCount > 0 && i >= childCount)
            {
                //设置NPC的坐标
                info.Position.X = ViMathDefine.RoundToInt(newViewDataPos.x * 100);
                info.Position.Y = ViMathDefine.RoundToInt(newViewDataPos.z * 100);
                info.Position.Z = ViMathDefine.RoundToInt((newViewDataPos.y - 1.5f) * 100);
            }

            Avatar avatar = new Avatar();
            GameObject npcObj = new GameObject(info.ID + "<>" + info.Name);
            npcObj.transform.parent = rootObj.transform;

            int nAvatarID = ((EditableDataForeignKey)title.Children[8]).Value;
            VisualNPCStruct visualNPC = ViSealedDB<VisualNPCStruct>.Data(nAvatarID);
            if (visualNPC.Avatar.Value == 0)
            {
                Debug.Log(info.Name + " Avatar 未指定");
            }
            else
            {
                AvatarCreator.Create(avatar, visualNPC.Avatar.Data);
            }

            GameObject obj = avatar.Root;
            obj.transform.parent = npcObj.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            SpaceScript_NPCBirthPos script = npcObj.AddComponent<SpaceScript_NPCBirthPos>();
            script.LogicData = info;
        }
    }

    // 加载NPC绑定的路径
    void LoadNpcBindPath()
    {
        string objName = "路径";
        Transform rootObj = mLogicRoot.Find(objName);
        if (rootObj == null)
        {
            rootObj = new GameObject(objName).transform;
            rootObj.parent = mLogicRoot;
        }
        rootObj.DestroyChildren();

        for (int i = 0; i < mViewDataList.Count; ++i)
        {
            EditableContainer title = mViewDataList[i].title;
            int nRouteID = ((EditableDataForeignKey)title.Children[13]).Value;
            if (nRouteID > 0)
            {
                SpaceRouteStruct info = ViSealedDB<SpaceRouteStruct>.Data(nRouteID);

                SpaceScript_Route script = rootObj.gameObject.AddComponent<SpaceScript_Route>();
                script.LogicData = info;

                List<ViVector3> posList = new List<ViVector3>();
                info.GetList(posList);
                for (int iter = 0; iter < posList.Count; ++iter)
                {
                    ViVector3 position = posList[iter];
                    GameObject tmpGO = new GameObject("路点 - " + iter.ToString());
                    Transform tmpTransform = tmpGO.transform;
                    tmpTransform.parent = rootObj;
                    tmpTransform.position = position.Convert();
                }
            }
        }
    }

    void DeleteEntity(int vID)
    {
        string rootObjName = "布怪[ " + mMapList[mMapIndex] + " ] List";
        Transform rootObj = mLogicRoot.Find(rootObjName);
        if (rootObj == null)
        {
            return;
        }
        SpaceScript_NPCBirthPos[] data = rootObj.GetComponentsInChildren<SpaceScript_NPCBirthPos>();
        if (data == null || data.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < data.Length; ++i)
        {
            SpaceScript_NPCBirthPos np = data[i];
            if (np.LogicData.ID == vID)
            {
                GameObject.DestroyImmediate(np.gameObject);
                break;
            }
        }
    }

    void SelectEntity(int vID)
    {
        string rootObjName = "布怪[ " + mMapList[mMapIndex] + " ] List";
        Transform rootObj = mLogicRoot.Find(rootObjName);
        if (rootObj == null)
        {
            return;
        }
        SpaceScript_NPCBirthPos[] data = rootObj.GetComponentsInChildren<SpaceScript_NPCBirthPos>();
        if (data == null || data.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < data.Length; ++i)
        {
            SpaceScript_NPCBirthPos np = data[i];
            if (np.LogicData.ID == vID)
            {
                Selection.activeGameObject = np.gameObject;
                break;
            }
        }
    }

    void SyncTransform()
    {
        string rootObjName = "布怪[ " + mMapList[mMapIndex] + " ] List";
        Transform rootObj = mLogicRoot.Find(rootObjName);
        if (rootObj == null)
        {
            return;
        }
        SpaceScript_NPCBirthPos[] data = rootObj.GetComponentsInChildren<SpaceScript_NPCBirthPos>();
        if (data == null || data.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < data.Length; ++i)
        {
            SpaceScript_NPCBirthPos np = data[i];
            for (int n = 0; n < mViewDataList.Count; ++n)
            {
                if (np.LogicData.ID == mViewDataList[n].data.ID)
                {
                    EditableContainer title = mViewDataList[i].title;

                    ViVector3 pos = np.transform.position.Convert();
                    ((EditableContainer)title.Children[5]).Children[0].SetValue(ViMathDefine.RoundToInt(pos.x * 100f).ToString());
                    ((EditableContainer)title.Children[5]).Children[1].SetValue(ViMathDefine.RoundToInt(pos.y * 100f).ToString());
                    (((EditableContainer)title.Children[5]).Children[2]).SetValue(ViMathDefine.RoundToInt(pos.z * 100f).ToString());

                    float angle = np.transform.eulerAngles.y;
                    angle = (180.0f - angle) * ViMathDefine.PI / 180.0f;
                    title.Children[6].SetValue(ViMathDefine.RoundToInt(angle * 100f).ToString());
                    break;
                }
            }
        }
    }

    void OnGUI()
	{
        GUILayout.BeginVertical();

        GUILayout.Space(30.0f);

        GUILayout.BeginHorizontal();
        GUILayout.Space(15.0f);
        mMapIndex = Mathf.Clamp(mMapIndex, 1, mMapList.Count - 1);
        mMapIndex = EditorGUILayout.Popup(mMapIndex, mMapList.ToArray(), GUILayout.Width(300));

        GUILayout.Space(15.0f);
        if (GUILayout.Button("加载场景", GUILayout.Width(120.0f), GUILayout.Height(20.0f)))
        {
            List<ViewData> pMapDataList = DataEditor.GetDatas<SpaceStruct>();
            if (pMapDataList == null)
            {
                Init();
                pMapDataList = DataEditor.GetDatas<SpaceStruct>();
            }
            if (mMapIndex > 0 && mMapIndex < pMapDataList.Count)
            {
                SpaceStruct pMapConfig = (SpaceStruct)pMapDataList[mMapIndex].data;
                if (pMapConfig != null)
                {
                    LoadScene(pMapConfig.Config);
                }
            }
        }

        if (GUILayout.Button("重置", GUILayout.Width(100)))
        {
            Init();
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        if (!Application.isPlaying || Instance == null)
        {
            return;
        }

        if (mLastIndex != mMapIndex)
        {
            InitBirthPosition();
            mEditorIndex = 0;
            mLogicRoot.DestroyChildren();
            mLastIndex = mMapIndex;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Space(15.0f);
        if (GUILayout.Button("新建", GUILayout.Width(100)))
        {
            List<ViewData> pMapDataList = DataEditor.GetDatas<SpaceStruct>();
            int nCurMapID = pMapDataList[mMapIndex].data.ID;

            NPCBirthPositionStruct pNewData = new NPCBirthPositionStruct();
            pNewData.ID = StructHandler<NPCBirthPositionStruct>.Instance.GetFreeID();
            pNewData.Name = "新建 " + pNewData.ID;
            pNewData.Space = new ViForeignKey<SpaceStruct>(nCurMapID);

            EditableContainer parse = new EditableContainer();
            parse.Parse(pNewData);
            parse.Children[4].SetValue(nCurMapID.ToString());
            parse.Children[10].SetValue("1");
            StructHandler<NPCBirthPositionStruct>.Instance.Insert(parse, pNewData);

            InitBirthPosition();

            mEditorIndex = mBirthList.Count - 1;
        }

        if (GUILayout.Button("删除当前", GUILayout.Width(100)))
        {
            mEditorIndex = DeleteDialog();
        }

        if (GUILayout.Button("保存", GUILayout.Width(100)))
        {
            SyncTransform();
            StructHandler<NPCBirthPositionStruct>.Instance.Save();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        mScrollPosition = GUI.BeginScrollView(new Rect(1.0f, 90.0f, 350.0f, 340.0f), mScrollPosition, new Rect(10.0f, 0.0f, 330.0f, 5000.0f), false, false);

        int nCount = mBirthList.Count;

        if (nCount > 0)
        {
            for (int i = 0; i < nCount; ++i)
            {
                if (GUI.Button(new Rect(10.0f, 11.0f + 20.0f * i, 350.0f, 18.0f), string.Empty))
                {
                    mEditorIndex = i;
                    SelectEntity(mViewDataList[mEditorIndex].data.ID);
                }
                //背景底
                GUI.DrawTexture(new Rect(10.0f, 11.0f + 20.0f * i, 350.0f, 18.0f), (i == mEditorIndex) ? mSelectTex : mEmptyTex);
                //边框
                GUI.DrawTexture(new Rect(10.0f, 9.0f + 20.0f * i, 350.0f, 2.0f), mLineTex);
            }
            GUI.DrawTexture(new Rect(10.0f, 9.0f + 20.0f * 10, 350.0f, 2.0f), mLineTex);
            for (int i = 0; i < nCount; i++)
            {
                GUI.Label(new Rect(40.0f, 10.0f + 20.0f * i, 300.0f, 20.0f), mBirthList[i]);
            }
        }

        GUI.EndScrollView();

        if (GUI.Button(new Rect(15.0f, 450, 150.0f, 30.0f), "加载所有Npc"))
        {
            LoadNpcBirths();
        }

        if (GUI.Button(new Rect(170.0f, 450, 150.0f, 30.0f), "加载Npc绑定路径"))
        {
            //LoadNpcBindPath();
        }
        GUILayout.EndHorizontal();

        if (mEditorIndex < mViewDataList.Count)
        {
            GUILayout.BeginArea(new Rect(400.0f, 90.0f, 550.0f, 5000.0f));
            ViewData pData = mViewDataList[mEditorIndex];

            string sLastName = ((EditableDataString)pData.title.Children[1]).Value;
            string sName = EditorGUILayout.TextField(pData.title.Children[1].Name, sLastName, GUILayout.Width(500));
            pData.title.Children[1].SetValue(sName);
            if (sLastName != sName)
            {
                mBirthList[mEditorIndex] = pData.data.ID + "<->" + sName;
            }
            
            for (int i = 7; i < pData.title.Children.Count; ++i)
            {
                if (mShowProperty.Contains(pData.title.Children[i].Name))
                {
                    pData.title.Children[i].OnGUI();
                }
            }
            GUILayout.EndArea();
        }

        //// Space Routes   /////////////////////////////////////////////
        //y += 60f;
        //GUI.Box(new Rect(5, y, position.width - 10, 22), "当前已有的路径如下");
        //y += 30f;
        //SceneEditorAssisstant.Instance.SelectSpaceRoute = EditorGUI.IntPopup(new Rect(5, y, position.width - 350, 20), "选择路径:", SceneEditorAssisstant.Instance.SelectSpaceRoute, SceneEditorAssisstant.Instance.SpaceRouteNameArr, SceneEditorAssisstant.Instance.SpaceRouteIDArr);
        //if (GUI.Button(new Rect(position.width - 150, y, 140, 22), "加载该路径"))
        //{
        //	SceneEditorAssisstant.Instance.LoadSpaceRoute_Selected();
        //}
        //y += 40f;
        //if (GUI.Button(new Rect(25, y, position.width - 50, 50), "保存所有路径数据(VIS)"))
        //{
        //	SceneEditorAssisstant.Instance.SaveSpaceRoutes();
        //	EditorUtility.DisplayDialog("提醒", "\nVis文件保存成功", "OK");
        //}
        //// 控制器相关功能; ///////////////////////////////////////
        //if (spaceExist)
        //{
        //	if (spaceChanged)
        //	{
        //		SceneEditorAssisstant.Instance.UpdateSpaceBirthController();
        //	}
        //	//
        //	y += 60;
        //	GUI.skin.box.normal.textColor = Color.yellow;
        //	GUI.Box(new Rect(5, y, position.width - 10, 22), "控制器相关");

        //	y += 30;
        //	if (GUI.Button(new Rect(5, y, 300, 30), "加载该场景中所有控制器信息"))
        //	{
        //		SceneEditorAssisstant.Instance.LoadSpaceBirthControllers();
        //	}
        //	y += 40f;
        //	if (GUI.Button(new Rect(25, y, position.width - 50, 50), "保存控制器数据(VIS)"))
        //	{
        //		SceneEditorAssisstant.Instance.SaveSpaceBirthControllers();
        //		EditorUtility.DisplayDialog("提醒", "\nVis文件保存成功", "OK");
        //	}
        //}
    }
}

