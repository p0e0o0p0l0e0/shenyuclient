using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine.Rendering;
using PhysicalShading;

public class NavTexture : EditorWindow
{
    private int mAreaIndex = 0;
    private int mPointIndex = 0;

    private Texture2D mLineTex = null;
    private Texture2D mEmptyTex = null;
    private Texture2D mSelectTex = null;
    private Texture2D mEditorTex = null;

    private Vector2 mScrollPosition;
    private Vector2 mRightScroll;

    private List<string> mMapList = new List<string>();
    private int mMapIndex = 0;

    public static NavTexture Instance = null;

    GameObject _staticRes;
    GameObject _root = null;
    ResourceRequest mResLoader = new ResourceRequest();

    [MenuItem("Scene/NavTexture")]
    private static void EditorNavTexture()
    {
        if (!Application.isPlaying || !GameApplication.Instance.IsEditor)
        {
            Debug.LogError("需要运行! 并运行Editor场景");
            return;
        }

        NavTexture pWin = (NavTexture)EditorWindow.GetWindow(typeof(NavTexture));

        pWin.Init();
        pWin.Show();
    }

    void Init()
    {
        Instance = this;
        if (SkillEditor.Instance != null)
        {
            SkillEditor.Instance.Close();
        }

        GameObject objPlane = GameObject.Find("Plane");
        if (objPlane != null)
        {
            objPlane.SetActive(false);
        }
        GameObject objGame = GameObject.Find("Game");
        if (objGame != null)
        {
            NavPaint np = objGame.GetComponent<NavPaint>();
            if (np == null)
            {
                np = objGame.AddComponent<NavPaint>();
            }
            np.enabled = true;

            EditorGameSupport egs = objGame.GetComponent<EditorGameSupport>();
            if (egs == null)
            {
                egs = objGame.AddComponent<EditorGameSupport>();
            }
        }

        GameObject objUIRoot = GameObject.Find("UIRoot");
        if (objUIRoot != null)
        {
            objUIRoot.SetActive(false);
        }
        RenderPipeline rp = GlobalGameObject.Instance.SceneCamera.GetComponent<RenderPipeline>();
        rp.postFX = false;
        rp.enablePlanarFX = false;
        rp._Refresh();

        mLineTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Line.jpg", typeof(Texture2D)) as Texture2D;
        mSelectTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Select.jpg", typeof(Texture2D)) as Texture2D;
        mEmptyTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Empty.jpg", typeof(Texture2D)) as Texture2D;
        mEditorTex = AssetDatabase.LoadAssetAtPath("Assets/Script/Editor/Res/Editor.jpg", typeof(Texture2D)) as Texture2D;

        StructHandler<PathFileResStruct>.Instance.Load();
        StructHandler<SpaceConfigStruct>.Instance.Load();
        List<ViewData> pDataList = DataEditor.GetDatas<SpaceConfigStruct>();
        mMapList.Clear();
        for (int i = 0; i < pDataList.Count; ++i)
        {
            mMapList.Add(pDataList[i].data.ID + "<->" + pDataList[i].data.Name);
        }
        
        if (NavPaint.Instance != null)
        {
            NavPaint.Instance.Init();
        }

        CameraController.Instance.Clear();
    }

    void OnDestroy()
    {
        if (NavPaint.Instance != null)
        {
            NavPaint.Instance.Destroy();
        }
        if (_root != null)
        {
            GameObject.Destroy(_root);
        }
        Instance = null;
    }

    void LoadScene(SpaceConfigStruct info)
    {
        mResLoader.Start(info.StaticResource.Data, OnLoad);
    }

    static void SetLayer(GameObject obj, string childName, Int32 value)
    {
        Transform childTransform = obj.transform.Find(childName);
        if (childTransform != null)
        {
            UnityAssisstant.SetLayerRecursively(childTransform.gameObject, value);
        }
    }

    void OnLoad(UnityEngine.Object pAsset)
    {
        UnityAssisstant.Destroy(ref _staticRes);
        _root = GameObject.Find("Scene");
        if (_root == null)
        {
            _root = new GameObject("Scene");
        }
        _staticRes = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _root.transform);

        Transform nParent = _staticRes.transform.GetChild(0);
        int nCount = nParent.childCount;
        SetLayer(_staticRes, "Ground", (Int32)UnityLayer.GROUND);

        mResLoader.End();
    }

    void OnGUI()
    {
        if (NavPaint.Instance == null)
        {
            return;
        }
        GUILayout.BeginVertical();

        GUILayout.Space(30.0f);

        GUILayout.BeginHorizontal();
        GUILayout.Space(15.0f);
        mMapIndex = Mathf.Clamp(mMapIndex, 1, mMapList.Count - 1);
        mMapIndex = EditorGUILayout.Popup(mMapIndex, mMapList.ToArray(), GUILayout.Width(300));

        GUILayout.Space(15.0f);
        if (GUILayout.Button("加载场景", GUILayout.Width(120.0f), GUILayout.Height(20.0f)))
        {
            List<ViewData> pMapDataList = DataEditor.GetDatas<SpaceConfigStruct>();
            if (pMapDataList == null)
            {
                Init();
                pMapDataList = DataEditor.GetDatas<SpaceConfigStruct>();
            }
            if (mMapIndex > 0 && mMapIndex < pMapDataList.Count)
            {
                SpaceConfigStruct pMapConfig = (SpaceConfigStruct)pMapDataList[mMapIndex].data;
                NavPaint.Instance.mWidth = pMapConfig.Area.WidthX / 100;
                NavPaint.Instance.mHeight = pMapConfig.Area.WidthY / 100;
                NavPaint.Instance.mName = pMapConfig.Area.NavMap;

                LoadScene(pMapConfig);
            }
        }

        GUILayout.Space(30.0f);
        if (GUILayout.Button("打开", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            OpenFileName ofn = new OpenFileName();
            ofn.structSize = Marshal.SizeOf(ofn);
            ofn.filter = "bytes|*.bytes\0\0";
            ofn.file = new string(new char[256]);
            ofn.maxFile = ofn.file.Length;
            ofn.fileTitle = new string(new char[64]);
            ofn.maxFileTitle = ofn.fileTitle.Length;
            ofn.initialDir = Application.dataPath;//默认路径
            ofn.title = "Open File";
            ofn.defExt = "bytes";//显示文件的类型
            ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

            if (FileDll.GetOpenFileName(ofn))
            {
                NavPaint.Instance.Load(ofn.file);
            }
        }

        if (GUILayout.Button("保存", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            NavPaint.Instance.Save();
        }

        if (GUILayout.Button("重载场景宽高名", GUILayout.Width(120.0f), GUILayout.Height(20.0f)))
        {
            List<ViewData> pMapDataList = DataEditor.GetDatas<SpaceConfigStruct>();
            if (pMapDataList == null)
            {
                Init();
                pMapDataList = DataEditor.GetDatas<SpaceConfigStruct>();
            }
            if (mMapIndex > 0 && mMapIndex < pMapDataList.Count)
            {
                SpaceConfigStruct pMapConfig = (SpaceConfigStruct)pMapDataList[mMapIndex].data;
                NavPaint.Instance.mWidth = pMapConfig.Area.WidthX / 100;
                NavPaint.Instance.mHeight = pMapConfig.Area.WidthY / 100;
                NavPaint.Instance.mName = pMapConfig.Area.NavMap;
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.Space(10.0f);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("添加阻挡区域", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            mAreaIndex = NavPaint.Instance.AddArea();
        }

        if (GUILayout.Button("删除阻挡区域", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            mAreaIndex = NavPaint.Instance.DeleteArea();
        }

        if (GUILayout.Button("编辑", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            NavPaint.Instance.BeginEditorArea(mAreaIndex);
        }

        if (GUILayout.Button("初始化", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            Init();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        NavPaint.Instance.OnlyShowSelect = EditorGUILayout.Toggle("只显示选中区域", NavPaint.Instance.OnlyShowSelect);
        NavPaint.Instance.FocusSelect = EditorGUILayout.Toggle("Focus选中", NavPaint.Instance.FocusSelect);
        GUILayout.EndHorizontal();
        NavPaint.Instance.LineWidth = EditorGUILayout.Slider("线-宽度", NavPaint.Instance.LineWidth, 0.05f, 0.25f);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        NavPaint.Instance.NormalColor = EditorGUILayout.ColorField("Noarmal-Color", NavPaint.Instance.NormalColor);
        NavPaint.Instance.EditorColor = EditorGUILayout.ColorField("Editor-Color", NavPaint.Instance.EditorColor);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        mScrollPosition = GUI.BeginScrollView(new Rect(0.0f, 120.0f, 350.0f, 340.0f), mScrollPosition, new Rect(10, 0, 360.0f, 5000.0f), false, false);
        int nCount = NavPaint.Instance.GetAreaCount();

        if (nCount > 0)
        {
            for (int i = 0; i < nCount; ++i)
            {
                if (GUI.Button(new Rect(10.0f, 11.0f + 20.0f * i, 350.0f, 18.0f), string.Empty))
                {
                    mAreaIndex = i;
                    NavPaint.Instance.SetSelIndex(mAreaIndex);
                }
                //背景底
                GUI.DrawTexture(new Rect(10.0f, 11.0f + 20.0f * i, 350.0f, 18.0f), (i == mAreaIndex) ? (NavPaint.Instance.IsEditorArea() ? mEditorTex : mSelectTex) : mEmptyTex);
                //边框
                GUI.DrawTexture(new Rect(10.0f, 9.0f + 20.0f * i, 350.0f, 2.0f), mLineTex);
            }
            GUI.DrawTexture(new Rect(10.0f, 9.0f + 20.0f * 10, 350.0f, 2.0f), mLineTex);
            for (int i = 0; i < nCount; i++)
            {
                GUI.Label(new Rect(40.0f, 10.0f + 20.0f * i, 60.0f, 20.0f), "区域" + (i + 1).ToString());
                GUI.Label(new Rect(200.0f, 10.0f + 20.0f * i, 200.0f, 20.0f), "顶点:" + NavPaint.Instance.GetAreaPointCount(i));
            }
        }

        GUI.EndScrollView();

        GUILayout.BeginArea(new Rect(400.0f, 60.0f, 350.0f, 5000.0f));

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("编辑", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            NavPaint.Instance.BeginEditorPoint(mPointIndex);
        }
        if (GUILayout.Button("删除选中", GUILayout.Width(80.0f), GUILayout.Height(20.0f)))
        {
            NavPaint.Instance.DeletePoint(mPointIndex);
        }
        GUILayout.EndHorizontal();
        int nPCount = NavPaint.Instance.GetSelAreaPointCount();
        mRightScroll = GUI.BeginScrollView(new Rect(0.0f, 60.0f, 350.0f, 340.0f), mRightScroll, new Rect(0.0f, 0, 360.0f, 5000.0f), false, false);
        if (nPCount > 0)
        {
            for (int i = 0; i < nPCount; ++i)
            {
                Vector2 p = NavPaint.Instance.GetSelAreaPoint(i);
                if (GUI.Button(new Rect(0.0f, 11.0f + 20.0f * i, 350.0f, 18.0f), string.Empty))
                {
                    mPointIndex = i;
                    NavPaint.Instance.SetSelPointIndex(mPointIndex);
                }
                GUI.DrawTexture(new Rect(0.0f, 11.0f + 20.0f * i, 350.0f, 18.0f), i == mPointIndex ? (NavPaint.Instance.IsEditorPoint() ? mEditorTex : mSelectTex) : mEmptyTex);
                GUI.DrawTexture(new Rect(0.0f, 9.0f + 20.0f * i, 350.0f, 2.0f), mLineTex);

                GUI.Label(new Rect(40.0f, 10.0f + 20.0f * i, 60.0f, 20.0f), "顶点" + (i + 1).ToString());
                GUI.Label(new Rect(100.0f, 10.0f + 20.0f * i, 200.0f, 20.0f), string.Format("坐标:{0},{1}", p.x, p.y));
            }
            GUI.DrawTexture(new Rect(0.0f, 9.0f + 20.0f * nPCount, 600.0f, 2.0f), mLineTex);
        }
        GUI.EndScrollView();

        GUILayout.EndArea();

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}