using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EditorSupport
{
    public static Vector3 GetPos(Vector2 pos)
    {
        Vector3 p = new Vector3(pos.x, 0.0f, pos.y);
        RaycastHit hit;
        if (Physics.Raycast(p + Vector3.up * 2000.0f, Vector3.down, out hit, 5000.0f, 1 << (int)UnityLayer.GROUND))
        {
            return hit.point + Vector3.up * 0.1f;
        }
        return p;
    }
}

public class AABB
{
    public Vector2 min;
    public Vector2 max;
    public AABB()
    {
        min = new Vector2(float.MaxValue, float.MaxValue);
        max = new Vector2(float.MinValue, float.MinValue);
    }

    public Vector2 Center
    {
        get
        {
            return new Vector2(min.x + (max.x - min.x) * 0.5f, min.y + (max.y - min.y) * 0.5f);
        }
    }
}

public class AreaData
{
    public List<Vector2> mPointList = new List<Vector2>();
    public List<Vector3> mDrawPoint = new List<Vector3>();

    LineRenderer pLineRender = null;
    public AABB mAABB = new AABB();
    public int Count { get { return mPointList.Count; } }

    public AreaData()
    {
        mAABB.min = new Vector3(float.MaxValue, float.MaxValue);
        mAABB.max = new Vector3(float.MinValue, float.MinValue);
        GameObject mLineObj = new GameObject("Line");
        pLineRender = mLineObj.AddComponent<LineRenderer>();
        mLineObj.transform.parent = NavPaint.Instance.mLineRoot.transform;
        pLineRender.material = NavPaint.mNormalLine;
        pLineRender.startWidth = pLineRender.endWidth = 0.1f;
    }
    public int AddPoint(Vector2 vPoint)
    {
        mPointList.Add(vPoint);
        mDrawPoint.Add(EditorSupport.GetPos(vPoint));
        ReBuilt();
        return mPointList.Count - 1;
    }

    public int DeletePoint(int vIndex)
    {
        if (vIndex > -1 && vIndex < Count)
        {
            mPointList.RemoveAt(vIndex);
            mDrawPoint.RemoveAt(vIndex);
            ReBuilt();
        }

        return Mathf.Clamp(vIndex, 0, mPointList.Count - 1);
    }

    public void ModifyPoint(int vIndex, Vector2 vPos)
    {
        mPointList[vIndex] = vPos;
        mDrawPoint[vIndex] = EditorSupport.GetPos(vPos);
        ReBuilt();
    }

    public void ReBuilt()
    {
        for (int i = 0; i < Count; ++i)
        {
            Vector2 p = mPointList[i];
            mAABB.min.x = Mathf.Min(mAABB.min.x, p.x);
            mAABB.min.y = Mathf.Min(mAABB.min.y, p.y);
            mAABB.max.x = Mathf.Max(mAABB.max.x, p.x);
            mAABB.max.y = Mathf.Max(mAABB.max.y, p.y);
        }
        pLineRender.positionCount = Count;
        pLineRender.SetPositions(mDrawPoint.ToArray());
    }

    public Vector2 GetPoint(int vIndex)
    {
        if (vIndex > -1 && vIndex < mPointList.Count)
        {
            return mPointList[vIndex];
        }
        return Vector2.zero;
    }

    public void Delete()
    {
        GameObject.DestroyImmediate(pLineRender.gameObject);
    }

    public void SetLineVisible(bool bSetting)
    {
        if (pLineRender != null)
        {
            pLineRender.enabled = bSetting;
        }
    }

    public void SetLineWidth(float vWidth)
    {
        if (pLineRender != null)
        {
            pLineRender.startWidth = pLineRender.endWidth = vWidth;
        }
    }

    public void BeginEditor()
    {
        pLineRender.material = NavPaint.mEditorLine;
        pLineRender.positionCount = mDrawPoint.Count;
        pLineRender.SetPositions(mDrawPoint.ToArray());
    }
    public void EndEditor()
    {
        pLineRender.material = NavPaint.mNormalLine;
        if (pLineRender.positionCount == mDrawPoint.Count)
        {
            pLineRender.positionCount = mDrawPoint.Count + 1;
            pLineRender.SetPositions(mDrawPoint.ToArray());
            pLineRender.SetPosition(mDrawPoint.Count, mDrawPoint[0]);
        }
    }
}

public class NavPaint : MonoBehaviour
{
    public static NavPaint Instance = null;

    private Camera mMainCamera = null;
    private Transform mCameraTrans;

    private float mClickTime1 = 0.0f;
    private float mClickTime2 = 0.0f;
    private GUIStyle mPointcolor = new GUIStyle();
    private GUIStyle mPointSel = new GUIStyle();
    private GUIStyle mAreaColor = new GUIStyle();

    private Vector2 mClickPos;

    private List<AreaData> mAreaList = new List<AreaData>();
    private int mSelAreaIndex = 0;
    private int mSelPointIndex = 0;
    private bool mEditorArea = false;
    private bool mEditorPoint = false;
    private bool mOnlyShowSelect = false;
    private bool mFocusSelect = true;
    private float mLineWidth = 0.1f;
    private Color mNormalColor = Color.blue;
    private Color mEditorColor = Color.red;

    public static Material mNormalLine = null;
    public static Material mEditorLine = null;

    bool EditorArea
    {
        get
        {
            return mEditorArea;
        }
        set
        {
            mEditorArea = value;
            for (int i = 0; i < mAreaList.Count; ++i)
            {
                if (mEditorArea && i == mSelAreaIndex)
                {
                    mAreaList[i].BeginEditor();
                }
                else
                {
                    mAreaList[i].EndEditor();
                }
            }
        }
    }

    public bool OnlyShowSelect
    {
        get
        {
            return mOnlyShowSelect;
        }
        set
        {
            if (mOnlyShowSelect != value)
            {
                mOnlyShowSelect = value;
                SetLineVisible();
                PlayerPrefs.SetString("E_Nav_ShowSelect", value.ToString());
            }
        }
    }

    public bool FocusSelect
    {
        get
        {
            return mFocusSelect;
        }
        set
        {
            if (mFocusSelect != value)
            {
                mFocusSelect = value;
                PlayerPrefs.SetString("E_Nav_FocusSelect", value.ToString());
            }
        }
    }

    public float LineWidth
    {
        get
        {
            return mLineWidth;
        }
        set
        {
            if (mLineWidth != value)
            {
                mLineWidth = value;
                SetLineWidth();
                PlayerPrefs.SetString("E_Nav_LineWidth", value.ToString());
            }
        }
    }

    public Color NormalColor
    {
        get
        {
            return mNormalColor;
        }
        set
        {
            if (mNormalColor != value)
            {
                mNormalColor = value;
                mNormalLine.color = NormalColor;
                PlayerPrefs.SetString("E_Nav_NormalColor", value.ToString());
            }
        }
    }

    public Color EditorColor
    {
        get
        {
            return mEditorColor;
        }
        set
        {
            if (mEditorColor != value)
            {
                mEditorColor = value;
                mEditorLine.color = mEditorColor;
                PlayerPrefs.SetString("E_Nav_EditorColor", value.ToString());
            }
        }
    }

    public int mWidth = 0;
    public int mHeight = 0;
    public string mName = "Empty";
    public GameObject mLineRoot = null;
    string sMapPath = "/../../Binaries/Data/Map/";
    public static bool IsInPolygon2(Vector2 checkPoint, List<Vector2> polygonPoints)
    {
        int counter = 0;
        int i;
        double xinters;
        Vector2 p1, p2;
        int pointCount = polygonPoints.Count;
        if (pointCount <= 0)
        {
            return false;
        }
        p1 = polygonPoints[0] * 2;
        for (i = 1; i <= pointCount; i++)
        {
            p2 = polygonPoints[i % pointCount] * 2;
            if (checkPoint.y >= Mathf.Min(p1.y, p2.y)//校验点的Y大于线段端点的最小Y  
                && checkPoint.y <= Mathf.Max(p1.y, p2.y))//校验点的Y小于线段端点的最大Y  
            {
                if (checkPoint.x <= Mathf.Max(p1.x, p2.x))//校验点的X小于等线段端点的最大X(使用校验点的左射线判断).  
                {
                    if (p1.y != p2.y)//线段不平行于X轴  
                    {
                        xinters = (checkPoint.y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) + p1.x;
                        if (p1.x == p2.x || checkPoint.x <= xinters)
                        {
                            counter++;
                        }
                    }
                }

            }
            p1 = p2;
        }

        if (counter % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        ResourceRequest mMat1 = new ResourceRequest();
        mMat1.Start("Script/Editor/Materials/LineN.mat", "", (UnityEngine.Object pAsset) =>
        {
            mNormalLine = pAsset as Material;
            mNormalLine.color = NormalColor;
            mMat1.End();
        });

        ResourceRequest mMat2 = new ResourceRequest();
        mMat2.Start("Script/Editor/Materials/LineS.mat", "", (UnityEngine.Object pAsset) =>
        {
            mEditorLine = pAsset as Material;
            mEditorLine.color = mEditorColor;
            mMat2.End();
        });

        if (PlayerPrefs.HasKey("E_Nav_ShowSelect"))
        {
            OnlyShowSelect = bool.Parse(PlayerPrefs.GetString("E_Nav_ShowSelect"));
        }
        if (PlayerPrefs.HasKey("E_Nav_FocusSelect"))
        {
            FocusSelect = bool.Parse(PlayerPrefs.GetString("E_Nav_FocusSelect"));
        }
        if (PlayerPrefs.HasKey("E_Nav_LineWidth"))
        {
            mLineWidth = float.Parse(PlayerPrefs.GetString("E_Nav_LineWidth"));
        }
        if (PlayerPrefs.HasKey("E_Nav_NormalColor"))
        {
            mNormalColor = ParseColor(PlayerPrefs.GetString("E_Nav_NormalColor"));
        }
        if (PlayerPrefs.HasKey("E_Nav_EditorColor"))
        {
            mEditorColor = ParseColor(PlayerPrefs.GetString("E_Nav_EditorColor"));
        }
        mLineRoot = GameObject.Find("LineRoot");
        if (mLineRoot == null)
        {
            mLineRoot = new GameObject("LineRoot");
        }

        mMainCamera = GameObject.Find("GameMainCamera").GetComponent<Camera>();

        mCameraTrans = mMainCamera.transform;
        RenderSettings.fog = false;

        mAreaColor.normal.textColor = Color.yellow;
        mAreaColor.fontSize = 45;
        mPointcolor.normal.textColor = Color.green;
        mPointcolor.fontSize = 45;
        mPointSel.normal.textColor = Color.magenta;
        mPointSel.fontSize = 45;
    }

    public Color ParseColor(string text)
    {
        Color c = Color.white;
        if (string.IsNullOrEmpty(text))
        {
            return c;
        }
        text = text.Replace("RGBA(", string.Empty);
        text = text.Replace(")", string.Empty);
        string[] sc = text.Split(',');

        c.r = float.Parse(sc[0]);
        c.g = float.Parse(sc[1]);
        c.b = float.Parse(sc[2]);
        c.a = float.Parse(sc[3]);

        return c;
    }

    public void Destroy()
    {
        mWidth = 0;
        mHeight = 0;
        mName = "Empty";
        for (int i = 0; i < mAreaList.Count; ++i)
        {
            mAreaList[i].Delete();
        }
        mAreaList.Clear();
    }

    public int AddArea()
    {
        mAreaList.Add(new AreaData());
        SetSelIndex(mAreaList.Count - 1, true);
        return mAreaList.Count - 1;
    }

    public int DeleteArea()
    {
        if (IsVaildIndex() && mAreaList.Count > 0)
        {
            mAreaList[mSelAreaIndex].Delete();
            mAreaList.RemoveAt(mSelAreaIndex);
        }
        int nLastIndex = mSelAreaIndex;
        int vIndex = Mathf.Clamp(mSelAreaIndex, 0, mAreaList.Count - 1);
        if (vIndex != nLastIndex)
        {
            SetSelIndex(vIndex);
        }
        return vIndex;
    }

    public int DeletePoint(int vIndex)
    {
        AreaData pData = GetCurSelectArea();
        if (pData != null)
        {
            return pData.DeletePoint(vIndex);
        }
        return 0;
    }

    public int GetAreaCount()
    {
        return mAreaList.Count;
    }

    public int GetAreaPointCount(int vIndex)
    {
        if (vIndex > -1 && vIndex < mAreaList.Count)
        {
            return mAreaList[vIndex].Count;
        }
        return 0;
    }

    public int GetSelAreaPointCount()
    {
        if (IsVaildIndex())
        {
            return mAreaList[mSelAreaIndex].Count;
        }
        return 0;
    }

    public Vector2 GetSelAreaPoint(int vIndex)
    {
        if (IsVaildIndex())
        {
            return mAreaList[mSelAreaIndex].GetPoint(vIndex);
        }
        return Vector2.zero;
    }

    public void SetSelIndex(int vIndex, bool bAdd = false)
    {
        EditorArea = false;
        mEditorPoint = false;
        if (vIndex > -1 && vIndex < mAreaList.Count)
        {
            if (mSelAreaIndex != vIndex)
            {
                mSelAreaIndex = vIndex;
                if (!bAdd)
                {
                    FocusToArea(vIndex);
                }
                SetLineVisible();
            }
        }
    }

    public void FocusToArea(int vIndex)
    {
        if (FocusSelect && vIndex > -1 && vIndex < mAreaList.Count)
        {
            Vector3 pos = EditorSupport.GetPos(mAreaList[vIndex].mAABB.Center);
            Vector3 vTarPos = pos;
            vTarPos.z -= 10.0f;
            vTarPos.y += 10.0f / Mathf.Cos(Mathf.PI / 4.0f);
            mMainCamera.transform.position = vTarPos;
            mMainCamera.transform.LookAt(pos);
        }
    }

    public void SetSelPointIndex(int vIndex)
    {
        EditorArea = false;
        mEditorPoint = false;
        if (vIndex > -1 && vIndex < mAreaList[mSelAreaIndex].Count)
        {
            mSelPointIndex = vIndex;
        }
    }

    public bool IsVaildIndex()
    {
        return mSelAreaIndex > -1 && mSelAreaIndex < mAreaList.Count;
    }

    public AreaData GetCurSelectArea()
    {
        if (IsVaildIndex())
        {
            return mAreaList[mSelAreaIndex];
        }
        return null;
    }

    public int AddPointToArea(Vector2 vPoint)
    {
        AreaData pData = GetCurSelectArea();
        if (pData != null)
        {
            return pData.AddPoint(vPoint);
        }
        return -1;
    }

    public void BeginEditorArea(int nIndex)
    {
        if (nIndex != mSelAreaIndex)
        {
            Debug.LogError("编辑的区域索引和选中的索引不一致! BUG");
            return;
        }
        EditorArea = true;
        mEditorPoint = false;
    }

    public void BeginEditorPoint(int nIndex)
    {
        if (nIndex != mSelPointIndex)
        {
            //Debug.LogError("编辑的顶点索引和选中的索引不一致! BUG");
            return;
        }
        EditorArea = false;
        mEditorPoint = true;
    }

    public bool IsEditorArea()
    {
        return mEditorArea;
    }

    public bool IsEditorPoint()
    {
        return mEditorPoint;
    }

    public void CloseArea()
    {
        EditorArea = false;
        mEditorPoint = false;
    }

    public bool IsInArea(Vector2 vPoint)
    {
        for (int i = 0; i < mAreaList.Count; ++i)
        {
            if (IsInPolygon2(vPoint, mAreaList[i].mPointList))
            {
                return true;
            }
        }
        return false;
    }

    public void SetLineWidth()
    {
        for (int i = 0; i < mAreaList.Count; ++i)
        {
            mAreaList[i].SetLineWidth(LineWidth);
        }
    }

    public void SetLineVisible()
    {
        for (int i = 0; i < mAreaList.Count; ++i)
        {
            mAreaList[i].SetLineVisible(OnlyShowSelect ? i == mSelAreaIndex : true);
        }
    }

    public void Save()
    {
        if (string.IsNullOrEmpty(mName))
        {
            Debug.LogError("场景名字不能为空！");
            return;
        }

        if (mWidth == 0 || mHeight == 0 || mWidth % 2 != 0 || mHeight % 2 != 0)
        {
            Debug.LogError("场景宽高必须是2的倍数！");
            return;
        }

        FileStream fs = new FileStream(Application.dataPath + sMapPath + mName + ".bytes", FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs);

        bw.Write(mName);
        bw.Write(mWidth);
        bw.Write(mHeight);

        bw.Write(mAreaList.Count);
        for (int i = 0; i < mAreaList.Count; i++)
        {
            AreaData pData = mAreaList[i];
            bw.Write(pData.Count);
            for (int p = 0; p < pData.Count; ++p)
            {
                bw.Write(pData.mPointList[p].x);
                bw.Write(pData.mPointList[p].y);
            }
        }
        bw.Close();
        fs.Close();

        Texture2D texture = new Texture2D(mWidth * 2, mHeight * 2, TextureFormat.RGB24, false);
        for (int y = -mHeight; y < mHeight; ++y)
        {
            for (int x = -mWidth; x < mWidth; ++x)
            {
                texture.SetPixel(y + mHeight, x + mWidth, IsInArea(new Vector2(y, x)) ? Color.black : Color.white);
            }
        }
        byte[] byt = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + sMapPath + mName + ".png", byt);

        Debug.Log("保存成功!!!");
    }

    public void Load(string sFilepath)
    {
        FileStream stream = File.Open(sFilepath, FileMode.Open, FileAccess.Read, FileShare.Read);
        if (stream == null)
        {
            return;
        }

        mAreaList.Clear();

        byte[] datas = new byte[stream.Length];
        stream.Read(datas, 0, datas.Length);

        MemoryStream ms = new MemoryStream(datas);
        BinaryReader br = new BinaryReader(ms);

        mName = br.ReadString();
        mWidth = br.ReadInt32();
        mHeight = br.ReadInt32();

        int nCount = br.ReadInt32();
        for (int i = 0;i < nCount; ++i)
        {
            AddArea();
            int nPointNum = br.ReadInt32();
            for (int p = 0; p < nPointNum; ++p)
            {
                mAreaList[i].AddPoint(new Vector2(br.ReadSingle(), br.ReadSingle()));
            }
        }
        stream.Close();
        br.Close();
        ms.Close();
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateHandle();
    }

    void UpdateHandle()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mMainCamera.ScreenPointToRay(Input.mousePosition), out hit, 10000.0f, 1 << 8))
            {
                if (mEditorArea)
                {
                    AddPointToArea(new Vector2(hit.point.x, hit.point.z));
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mMainCamera.ScreenPointToRay(Input.mousePosition), out hit, 10000.0f, 1 << 8))
            {
                if (mEditorPoint)
                {
                    AreaData pData = GetCurSelectArea();
                    if (pData != null)
                    {
                        pData.ModifyPoint(mSelPointIndex, new Vector2(hit.point.x, hit.point.z));
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            mClickTime2 = Time.realtimeSinceStartup;
            if (mClickTime2 - mClickTime1 < 0.2f)
            {
                if (IsEditorArea())
                {
                    CloseArea();
                }
            }
            mClickTime1 = mClickTime2;
        }
    }

    void OnGUI()
    {
        if (OnlyShowSelect)
        {
            AreaData pSelData = GetCurSelectArea();
            if (pSelData == null)
            {
                return;
            }
            Vector3 pos = mMainCamera.WorldToScreenPoint(EditorSupport.GetPos(pSelData.mAABB.Center));
            if (pos.z > 0 && pos.x > 0 && pos.x < Screen.width && pos.y > 0 && pos.y < Screen.height)
            {
                pos.y = Screen.height - pos.y;
                GUI.Label(new Rect(pos.x, pos.y, 50.0f, 20.0f), (mSelAreaIndex + 1).ToString(), mAreaColor);
            }
        }
        else
        {
            for (int i = 0; i < mAreaList.Count; ++i)
            {
                if (mAreaList[i].mPointList.Count > 0)
                {
                    Vector3 pos = mMainCamera.WorldToScreenPoint(EditorSupport.GetPos(mAreaList[i].mAABB.Center));
                    if (pos.z > 0 && pos.x > 0 && pos.x < Screen.width && pos.y > 0 && pos.y < Screen.height)
                    {
                        pos.y = Screen.height - pos.y;
                        GUI.Label(new Rect(pos.x, pos.y, 50.0f, 20.0f), (i + 1).ToString(), mAreaColor);
                    }
                }
            }
        }
        
        AreaData pData = GetCurSelectArea();
        if (pData == null)
        {
            return;
        }
        
        for (int i = 0; i < pData.Count; ++i)
        {
            Vector3 pos = mMainCamera.WorldToScreenPoint(EditorSupport.GetPos(pData.mPointList[i]));
            if (pos.z > 0 && pos.x > 0 && pos.x < Screen.width && pos.y > 0 && pos.y < Screen.height)
            {
                pos.y = Screen.height - pos.y;
                UnityEngine.GUI.Label(new Rect(pos.x, pos.y, 50.0f, 20.0f), (i + 1).ToString(), i == mSelPointIndex ? mPointSel : mPointcolor);
            }
        }
    }
}
