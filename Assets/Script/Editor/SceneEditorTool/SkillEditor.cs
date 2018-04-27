using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using PhysicalShading;

public class EditorDataManager
{
    public static EditorDataManager Instance = new EditorDataManager();
    public void Init()
    {
        EnumManager.RegisterAsMask(typeof(ViStateConditionStruct), "reqActionState", typeof(ActionStateMask));
        EnumManager.RegisterAsMask(typeof(ViStateConditionStruct), "notActionState", typeof(ActionStateMask));
        EnumManager.RegisterAsMask(typeof(ViStateConditionStruct), "reqAuraState", typeof(AuraStateMask));
        EnumManager.RegisterAsMask(typeof(ViStateConditionStruct), "notAuraState", typeof(AuraStateMask));
        EnumManager.RegisterAsMask(typeof(ViStateConditionStruct), "reqSpaceState", typeof(SpaceStateMask));
        EnumManager.RegisterAsMask(typeof(ViStateConditionStruct), "notSpaceState", typeof(SpaceStateMask));
        EnumManager.RegisterAsMask(typeof(ViAttachExpressStruct), "attachMask", typeof(ExpressAttachMask));
        EnumManager.RegisterAsMask(typeof(ViTargetSelectStruct), "NatureIgnoreMask", typeof(UnitNatureMask));

        EnumManager.RegisterAsValue(typeof(ViHitEffectStruct), "template", typeof(ViHitEffectTemplate));
        EnumManager.RegisterAsValue(typeof(ViHitEffectStruct), "template", typeof(HitEffectTemplate));
        EnumManager.RegisterAsValue(typeof(ViHitEffectStruct), "EntityType", typeof(GameUnitEntityType));
        EnumManager.RegisterAsValue(typeof(ViAuraStruct), "template", typeof(ViAuraTemplate));
        EnumManager.RegisterAsValue(typeof(ViAuraStruct), "template", typeof(AuraTemplate));
        EnumManager.RegisterAsValue(typeof(ViAuraStruct), "EntityType", typeof(GameUnitEntityType));
        EnumManager.RegisterAsValue(typeof(ViAvatarDurationVisualStruct), "type", typeof(DurationVisualType));
        EnumManager.RegisterAsValue(typeof(ViAttachExpressStruct), "attachPos", typeof(AvatarAttachNode));
        EnumManager.RegisterAsValue(typeof(ViAttachExpressStruct), "fadeType", typeof(ExpressFadeType));
        EnumManager.RegisterAsValue(typeof(ViLinkExpressStruct), "fromPos", typeof(AvatarAttachNode));
        EnumManager.RegisterAsValue(typeof(ViLinkExpressStruct), "toPos", typeof(AvatarAttachNode));
        EnumManager.RegisterAsValue(typeof(ViTravelExpressStruct), "srcPos", typeof(AvatarAttachNode));
        EnumManager.RegisterAsValue(typeof(ViTravelExpressStruct), "destPos", typeof(AvatarAttachNode));
        EnumManager.RegisterAsValue(typeof(AttributeTypeStruct), "Property", typeof(AttributeIndex));
        EnumManager.RegisterAsMask(typeof(ViSpellProcStruct), "addStateMask", typeof(SpellAction));
        EnumManager.RegisterAsMask(typeof(ViSpellProcStruct), "ActionStateMask", typeof(ActionStateMask));
        EnumManager.RegisterAsMask(typeof(ViSpellProcStruct), "focusNatureIgnoreMask", typeof(UnitNatureMask));

        StructHandler<ViAuraTypeStruct>.Instance.Load();
        StructHandler<PathFileResStruct>.Instance.Load();
        StructHandler<ViSealedDataTypeStruct>.Instance.Load();
        StructHandler<ViAttackForceStruct>.Instance.Load();
        StructHandler<ViStateConditionStruct>.Instance.Load();
        StructHandler<ViEmptySealedData>.Instance.Load();
        StructHandler<ViEmptySealedData >.Instance.Load();
        StructHandler<ViSpellStruct>.Instance.Load();
        StructHandler<ViTravelExpressStruct>.Instance.Load();
        StructHandler<ViVisualAuraStruct>.Instance.Load();
        StructHandler<ViCameraShakeStruct>.Instance.Load();
        StructHandler<VisualSpellStruct>.Instance.Load();
        StructHandler<ViVisualHitEffectStruct>.Instance.Load();
        StructHandler<VisualHeroStruct>.Instance.Load();
        StructHandler<VisualNPCStruct>.Instance.Load();
    }
}

public class SkillEditor : EditorWindow
{
    bool bHorizontal = true;
    int mTab = 0;
    int mTravelSpeed = 1500;    // 飞行物速度
    int mAuraDuration = 1500;   // 持续时间

    float m_HeroScale = 1f;     // 角色缩放

    private static bool bInit = false;
    private static Dictionary<int, List<string>> mNameList = new Dictionary<int, List<string>>();
    private static List<string> mHeroList = new List<string>();
    private static List<string> mMapList = new List<string>();

    private int mCurSkillIndex = 0;         // 编辑的Spell索引
    private int mCurHitIndex = 0;           // 被击效果索引
    private int mCurTravelIndex = 0;
    private int mCurAuraIndex = 0;

    private static int mMapIndex = 2;
    private static int mLastMapIndex = 0;

    private static int mAvatarIndex = 1;
    private static int mLastAcaterIndex = 1;
    private static CellHero pHero = null;

    public static SkillEditor Instance = null;

    GameObject _staticRes;
    GameObject _root = null;
    ResourceRequest mResLoader = new ResourceRequest();

    [MenuItem("Scene/技能编辑器2.0")]
    private static void OpenSkillEditor()
    {
        if (!Application.isPlaying || !GameApplication.Instance.IsEditor)
        {
            Debug.LogError("需要运行! 并运行Editor场景");
            return;
        }

        SkillEditor pWin = (SkillEditor)EditorWindow.GetWindow(typeof(SkillEditor));
        pWin.Init();
    }

    private static long GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }

    private void OnDestroy()
    {
        if (pHero != null)
        {
            pHero.Clear();
            GameObject.DestroyImmediate(pHero.VisualBody.Root);
            pHero = null;
        }
        Instance = null;
    }

    private static void InitNameList<T>(int nTab)
    {
        List<ViewData> pDataList = DataEditor.GetDatas<T>();

        List<string> pList = GetNameList(nTab);
        pList.Clear();
        for (int i = 0; i < pDataList.Count; ++i)
        {
            pList.Add(pDataList[i].data.ID + "<->" + pDataList[i].data.Name);
        }
    }

    private static void AddTitleName<T>(int nTab, int vIndex)
    {        
        List<ViewData> SpellData = DataEditor.GetDatas<T>();
        List<string> pList = GetNameList(nTab);
        pList.Add(SpellData[vIndex].data.ID + "<->" + SpellData[vIndex].data.Name);
    }

    private static List<string> GetNameList(int nTab)
    {
        List<string> pList = null;
        if (!mNameList.TryGetValue(nTab, out pList))
        {
            pList = new List<string>();
            mNameList[nTab] = pList;
        }
        return pList;
    }

    private static void RemoveTitleName(int nTab, int vIndex)
    {
        List<string> pList = GetNameList(nTab);
        if (vIndex > -1 && vIndex < pList.Count)
        {
            pList.RemoveAt(vIndex);
        }
    }

    static GameObject GetChildByName(Transform pTrans, string sName)
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

    // 初始化
    private void Init()
    {
        Instance = this;
        if (NavTexture.Instance != null)
        {
            NavTexture.Instance.Close();
        }

        GameObject objGame = GameObject.Find("Game");
        if (objGame != null)
        {
            NavPaint np = objGame.GetComponent<NavPaint>();
            if (np == null)
            {
                np = objGame.AddComponent<NavPaint>();
            }

            np.enabled = false;

            EditorGameSupport egs = objGame.GetComponent<EditorGameSupport>();
            if (egs == null)
            {
                egs = objGame.AddComponent<EditorGameSupport>();
            }
        }

        GameObject objPlane = GameObject.Find("Plane");
        if (objPlane != null)
        {
            objPlane.SetActive(false);
        }

        Alias.Start();
        EditorDataManager.Instance.Init();

        InitNameList<VisualSpellStruct>(0);
        InitNameList<ViVisualHitEffectStruct>(1);
        InitNameList<ViTravelExpressStruct>(2);
        InitNameList<ViVisualAuraStruct>(3);

        mHeroList.Clear();
        List<ViewData> pDataList = DataEditor.GetDatas<VisualHeroStruct>();
        for (int i = 0; i < pDataList.Count; ++i)
        {
            mHeroList.Add(pDataList[i].data.Name);
        }
        pDataList = DataEditor.GetDatas<VisualNPCStruct>();
        for (int i = 0; i < pDataList.Count; ++i)
        {
            mHeroList.Add(pDataList[i].data.Name);
        }

        mMapList.Clear();
        StructHandler<SpaceConfigStruct>.Instance.Load();
        pDataList = DataEditor.GetDatas<SpaceConfigStruct>();
        mMapList.Clear();
        for (int i = 0; i < pDataList.Count; ++i)
        {
            mMapList.Add(pDataList[i].data.ID + "<->" + pDataList[i].data.Name);
        }

        CreateShowGirl();

        ApplicationSetting.Instance.CameraShakeScale = 1.0f;
        GameApplication.Instance.OnGameStart(GetTimeStamp(), DateTime.UtcNow.Millisecond);

        EditorGameSupport.Instance.SwitchState(tCameraState.eGame);

        bInit = true;
    }

    private static void CreateShowGirl()
    {
        if (pHero != null)
        {
            pHero.Clear();
            GameObject.DestroyImmediate(pHero.VisualBody.Root);
            pHero = null;
        }

        int nHeroCount = DataEditor.GetDatas<VisualHeroStruct>().Count;

        int nType = mAvatarIndex < nHeroCount ? 0 : 1;
        int nIndex = nType == 0 ? mAvatarIndex : mAvatarIndex - nHeroCount;

        ViSealedDB<SimpleAvatarStruct>.Load("../Binaries/Data/BinaryStream/SimpleAvatarStruct" + ".vib", true);
        pHero = new CellHero();
        pHero.SetProperty(new CellHeroReceiveProperty());
        pHero.UpdateInfoForEditor(nIndex, nType);
        pHero.VisualBody.Root.name = "Entity_Spell";
        mLastAcaterIndex = mAvatarIndex;

        ViVector3 vPos = pHero.Position;
        GroundHeight.GetGroundHeight(ref vPos);
        pHero.Position = vPos;

        EditorGameSupport.Instance.SetGameHero(pHero);
    }

    void LoadScene()
    {
        List<ViewData> pMapDataList = DataEditor.GetDatas<SpaceConfigStruct>();
        SpaceConfigStruct pMapConfig = (SpaceConfigStruct)pMapDataList[mMapIndex].data;
        mResLoader.Start(pMapConfig.StaticResource.Data, OnLoad);
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
        
        if (pHero != null)
        {
            ViVector3 vPos = new ViVector3(0.0f, 8.0f, 0.0f);
            GroundHeight.GetGroundHeight(ref vPos);
            pHero.Position = vPos;
        }
        mResLoader.End();
    }

    static void SetLayer(GameObject obj, string childName, Int32 value)
    {
        Transform childTransform = obj.transform.Find(childName);
        if (childTransform != null)
        {
            UnityAssisstant.SetLayerRecursively(childTransform.gameObject, value);
        }
    }

    void Update()
    {
        if (!bInit)
        {
            return;
        }
        GameTimeScale.UpdateLogicTime(ViTimerInstance.Time, GameApplication.VALUE_ClientPingSpan);
    }

    void OnGUI()
    {
        int newTab = mTab;

        GUILayout.BeginHorizontal();
        if (GUILayout.Toggle(newTab == 0, "Spell", "ButtonLeft")) newTab = 0;
        if (GUILayout.Toggle(newTab == 1, "HitEffect", "ButtonMid")) newTab = 1;
        if (GUILayout.Toggle(newTab == 2, "Travel", "ButtonMid")) newTab = 2;
        if (GUILayout.Toggle(newTab == 3, "Aura", "ButtonRight")) newTab = 3;
        GUILayout.EndHorizontal();

        mTab = newTab;

        if (!Application.isPlaying)
        {
            return;
        }
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));
        GUILayout.Label("技能编辑:", EditorStyles.boldLabel);
        // 角色列表( 怪 )
        if (mHeroList.Count > 0)
        {
            mAvatarIndex = Mathf.Clamp(mAvatarIndex, 1, mHeroList.Count - 1);
            mAvatarIndex = EditorGUILayout.Popup(mAvatarIndex, mHeroList.ToArray(), GUILayout.Width(150));
            if (mLastAcaterIndex != mAvatarIndex)
            {
                CreateShowGirl();
            }
        }

        // 场景列表
        if (mMapList.Count > 0)
        {
            mMapIndex = Mathf.Clamp(mMapIndex, 1, mMapList.Count);
            mMapIndex = EditorGUILayout.Popup(mMapIndex, mMapList.ToArray(), GUILayout.Width(150));
            if (mLastMapIndex != mMapIndex)
            {
                LoadScene();
                mLastMapIndex = mMapIndex;
            }
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));
        if (GUILayout.Button("保存", GUILayout.Width(100)))
        {
            Save();
        }
        if (GUILayout.Button("重置", GUILayout.Width(100)))
        {
            Init();
        }
        if (GUILayout.Button("删除当前", GUILayout.Width(100)))
        {
            DeleteCur();
        }
        if (GUILayout.Button("新建", GUILayout.Width(100)))
        {
            CreateNew();
        }
        if (GUILayout.Button("Play", GUILayout.Width(100)))
        {
            Play();
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));
        if (GUILayout.Button("场景暗了点我", GUILayout.Width(100)))
        {
            if (_staticRes != null)
            {
                SceneEntry se = _staticRes.GetComponent<SceneEntry>();
                if (se)
                {
                    se.enableSunLight = false;
                    se.UpdateParams();
                    se.enableSunLight = true;
                    se.UpdateParams();
                }
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        GUILayout.Space(10);
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));
        GUILayout.Label("角色模型缩放值:", EditorStyles.boldLabel);
        m_HeroScale = EditorGUILayout.Slider(m_HeroScale, 0.1f, 6f);
        GUILayout.EndHorizontal();
        GUILayout.Space(10);

        switch (mTab)
        {
            case 0: ShowSpellWindow();break;
            case 1: ShowHitWindow(); break;
            case 2: ShowTravelWindow(); break;
            case 3: ShowAuraWindow(); break;
        }
    }

    void OnInspectorUpdate()
    {
        if (pHero != null)
        {
            pHero.transform.localScale = new Vector3(m_HeroScale, m_HeroScale, m_HeroScale);
        }
    }

    void Play()
    {
        if (mTab == 0)
        {
            VisualSpellStruct pEditData = StructHandler<VisualSpellStruct>.Instance.GetNewData(mCurSkillIndex) as VisualSpellStruct;
            if (pEditData != null)
            {
                pHero.OnSpellCastForEditor(pEditData);
            }
        }
        else if (mTab == 1)
        {
            ViVisualHitEffectStruct pEditData = StructHandler<ViVisualHitEffectStruct>.Instance.GetNewData(mCurHitIndex) as ViVisualHitEffectStruct;
            if (pEditData != null)
            {
                pHero.OnHitVisualForEditor(pEditData);
            }
        }
        else if (mTab == 2)
        {
            ViTravelExpressStruct pEditData = StructHandler<ViTravelExpressStruct>.Instance.GetNewData(mCurTravelIndex) as ViTravelExpressStruct;
            if (pEditData != null)
            {
                ViVector3 vTargetPos = new ViVector3(0.0f, 10.0f, 15.0f);
                float fDistance = ViVector3.Distance(vTargetPos, pHero.GetPosProvider(0).Value);
                float fTravelDuration = fDistance / (mTravelSpeed * 0.01f);

                pHero.TravelForEditor(pEditData, vTargetPos, fTravelDuration);
            }
        }
        else if (mTab == 3)
        {
            ViVisualAuraStruct pEditData = StructHandler<ViVisualAuraStruct>.Instance.GetNewData(mCurAuraIndex) as ViVisualAuraStruct;
            if (pEditData != null)
            {
                pHero.ShowAuraForEditor(pEditData, mAuraDuration * 0.01f);
            }
        }
    }

    void Save()
    {
        switch (mTab)
        {
            case 0: StructHandler<VisualSpellStruct>.Instance.Save(); break;
            case 1: StructHandler<ViVisualHitEffectStruct>.Instance.Save(); break;
            case 2: StructHandler<ViTravelExpressStruct>.Instance.Save(); break;
            case 3: StructHandler<ViVisualAuraStruct>.Instance.Save(); break;
        }
    }

    void CreateNew()
    {
        if (mTab == 0)
        {
            mCurSkillIndex = StructHandler<VisualSpellStruct>.Instance.AddNewData();
            AddTitleName<VisualSpellStruct>(mTab, mCurSkillIndex);
        }
        else if (mTab == 1)
        {
            mCurHitIndex = StructHandler<ViVisualHitEffectStruct>.Instance.AddNewData();
            AddTitleName<ViVisualHitEffectStruct>(mTab, mCurHitIndex);
        }
        else if (mTab == 2)
        {
            mCurTravelIndex = StructHandler<ViTravelExpressStruct>.Instance.AddNewData();
            AddTitleName<ViTravelExpressStruct>(mTab, mCurTravelIndex);
        }
        else if (mTab == 3)
        {
            mCurAuraIndex = StructHandler<ViVisualAuraStruct>.Instance.AddNewData();
            AddTitleName<ViVisualAuraStruct>(mTab, mCurAuraIndex);
        }
    }

    void DeleteCur()
    {
        if (mTab == 0)
        {
            int nIndex = DeleteDialog(StructHandler<VisualSpellStruct>.Instance, mCurSkillIndex);
            mCurSkillIndex = (nIndex == -1) ? mCurSkillIndex : nIndex;
        }
        else if (mTab == 1)
        {
            int nIndex = DeleteDialog(StructHandler<ViVisualHitEffectStruct>.Instance, mCurHitIndex);
            mCurHitIndex = (nIndex == -1) ? mCurHitIndex : nIndex;
        }
        else if (mTab == 2)
        {
            int nIndex = DeleteDialog(StructHandler<ViTravelExpressStruct>.Instance, mCurTravelIndex);
            mCurTravelIndex = (nIndex == -1) ? mCurTravelIndex : nIndex;
        }
        else if (mTab == 3)
        {
            int nIndex = DeleteDialog(StructHandler<ViVisualAuraStruct>.Instance, mCurAuraIndex);
            mCurAuraIndex = (nIndex == -1) ? mCurAuraIndex : nIndex;
        }
    }

    private int DeleteDialog(DataEditor pInstance, int vIndex)
    {
        ViSealedData pData = pInstance.GetData(vIndex);
        if (pData != null)
        {
            if (EditorUtility.DisplayDialog("ViVisualAuraStruct 删除 ID = " + pData.ID, "确定要删除  " + pData.Name + "  吗?", "确定", "取消"))
            {
                RemoveTitleName(mTab, vIndex);
                return pInstance.DeleteData(vIndex);
            }
        }
        
        return -1;
    }

    private void ShowSpellWindow()
    {
        mCurSkillIndex = Mathf.Clamp(mCurSkillIndex, 0, GetNameList(mTab).Count - 1);
        mCurSkillIndex = EditorGUILayout.Popup(mCurSkillIndex, GetNameList(mTab).ToArray(), GUILayout.Width(300));
        GUILayout.Space(20);

        if (mCurSkillIndex >= 0 && mCurSkillIndex < StructHandler<VisualSpellStruct>.Instance.mDataList.Count)
        {
            ViewData pData = StructHandler<VisualSpellStruct>.Instance.mDataList[mCurSkillIndex];
            int nIndex = -1;
            for (int i = 0; i < pData.title.Children.Count; ++i)
            {
                if (pData.title.Children[i].Name == "Proc")
                {
                    nIndex = i;
                    continue;
                }
                pData.title.Children[i].OnGUI();
            }

            bHorizontal = GUILayout.Toggle(bHorizontal, "Proc垂直显示", GUILayout.Width(100));
            if (!bHorizontal)
            {
                GUILayout.BeginArea(new Rect(600, 40, 700, 1000));
            }

            pData.title.Children[nIndex].OnGUI();
            if (!bHorizontal)
            {
                GUILayout.EndArea();
            }
        }
    }

    private void ShowHitWindow()
    {
        mCurHitIndex = Mathf.Clamp(mCurHitIndex, 0, GetNameList(mTab).Count - 1);
        mCurHitIndex = EditorGUILayout.Popup(mCurHitIndex, GetNameList(mTab).ToArray(), GUILayout.Width(300));
        GUILayout.Space(20);
        if (mCurHitIndex < 0 || mCurHitIndex >= StructHandler<ViVisualHitEffectStruct>.Instance.mDataList.Count)
        {
            return;
        }
        
        ViewData pData = StructHandler<ViVisualHitEffectStruct>.Instance.mDataList[mCurHitIndex];
        for (int i = 0; i < pData.title.Children.Count; ++i)
        {
            pData.title.Children[i].OnGUI();
        }
    }

    void ShowTravelWindow()
    {
        mCurTravelIndex = Mathf.Clamp(mCurTravelIndex, 0, GetNameList(mTab).Count - 1);
        mCurTravelIndex = EditorGUILayout.Popup(mCurTravelIndex, GetNameList(mTab).ToArray(), GUILayout.Width(300));
        GUILayout.Space(20);
        if (mCurTravelIndex < 0 || mCurTravelIndex >= StructHandler<ViTravelExpressStruct>.Instance.mDataList.Count)
        {
            return;
        }

        ViewData pData = StructHandler<ViTravelExpressStruct>.Instance.mDataList[mCurTravelIndex];
        for (int i = 0; i < pData.title.Children.Count; ++i)
        {
            pData.title.Children[i].OnGUI();
        }

        mTravelSpeed = int.Parse(EditorGUILayout.TextField("速度", mTravelSpeed.ToString(), GUILayout.Width(300)));
    }

    void ShowAuraWindow()
    {
        mCurAuraIndex = Mathf.Clamp(mCurAuraIndex, 0, GetNameList(mTab).Count - 1);
        GUILayout.BeginHorizontal(GUILayout.Width(400));
        mCurAuraIndex = EditorGUILayout.Popup(mCurAuraIndex, GetNameList(mTab).ToArray(), GUILayout.Width(250));
        mAuraDuration = int.Parse(EditorGUILayout.TextField("持续时间", mAuraDuration.ToString(), GUILayout.Width(250)));
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        if (mCurAuraIndex < 0 || mCurAuraIndex >= StructHandler<ViVisualAuraStruct>.Instance.mDataList.Count)
        {
            return;
        }

        ViewData pData = StructHandler<ViVisualAuraStruct>.Instance.mDataList[mCurAuraIndex];
        for (int i = 0; i < pData.title.Children.Count; ++i)
        {
            pData.title.Children[i].OnGUI();
        }
    }
}