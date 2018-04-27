using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine.Rendering;
using PhysicalShading;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]

public class OpenFileName
{
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public String filter = null;
    public String customFilter = null;
    public int maxCustFilter = 0;
    public int filterIndex = 0;
    public String file = null;
    public int maxFile = 0;
    public String fileTitle = null;
    public int maxFileTitle = 0;
    public String initialDir = null;
    public String title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public String defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public String templateName = null;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedInt = 0;
    public int flagsEx = 0;
}

public class FileDll
{
    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);

    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);
}

public class ObjcetFormat
{
    public string sName;
    public string sFbxName;
    public string sLightMapName;
    public Vector3 vPos;
    public Vector3 vScale;
    public Quaternion qRot;
    public string mShaderName = "Physical Shading/Scene/Unreal";
    public Texture mMainTexture;
    public Texture mLightMapTexture;
}

public class LightMapFormat
{
    public string mLightMapName;
    public Vector2 mUVScale;
    public Vector2 mUVBias;

    public Vector4 mScaleLQ1;
    public Vector4 mAddLQ1;
    public Vector4 mScaleLQ2;
    public Vector4 mAddLQ2;
}

public class UEScene : Editor
{
    static List<string> LoadFile(string path)
    {
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path);
        }
        catch (Exception e)
        {
            return null;
        }
        string line;
        List<string> arrlist = new List<string>();
        while ((line = sr.ReadLine()) != null)
        {
            arrlist.Add(line);
        }

        sr.Close();
        sr.Dispose();
        return arrlist;
    }

    void LoadByIO(string sPathFile)
    {
        double startTime = (double)Time.time;
        //创建文件读取流
        FileStream fileStream = new FileStream(sPathFile, FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;


        //创建Texture
        int width = 300;
        int height = 372;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        startTime = (double)Time.time - startTime;
        Debug.Log("IO加载用时:" + startTime);
    }

    static GameObject CreateGameObject(string sName, Vector3 vPos, Quaternion vRot, Vector3 vScale)
    {
        GameObject pNewObj = new GameObject(sName);
        pNewObj.transform.localPosition = vPos;
        pNewObj.transform.localScale = vScale;
        pNewObj.transform.localRotation = vRot;
        return pNewObj;
    }

    static Vector2 ConverString2V2(string sText)
    {
        string[] list = sText.Split('\t');
        Vector2 vv = new Vector2(float.Parse(list[0]), float.Parse(list[1]));
        return vv;
    }

    static Vector3 ConverString2V3(string sText)
    {
        string[] list = sText.Split('\t');
        return new Vector3(float.Parse(list[0]), float.Parse(list[1]), float.Parse(list[2]));
    }

    static Vector3 ConverString2V3(string sText, float scale)
    {
        string[] list = sText.Split('\t');
        Vector3 vv = new Vector3(float.Parse(list[0]) * -1, float.Parse(list[1]), float.Parse(list[2]));
        return vv / scale;
    }

    static Vector4 ConverString2V4(string sText)
    {
        string[] list = sText.Split('\t');
        return new Vector4(float.Parse(list[0]), float.Parse(list[1]), float.Parse(list[2]), float.Parse(list[3]));
    }

    static Quaternion ConverString2Q(string sText)
    {
        string[] list = sText.Split('\t');
        Quaternion qq = new Quaternion(float.Parse(list[0]), float.Parse(list[1]), float.Parse(list[2]), float.Parse(list[3]));
        qq *= Quaternion.AngleAxis(-90, Vector3.right);
        return qq;
    }

    static LightMapFormat GetLightMapConfig(string sName)
    {
        if (!mLightMapConfig.ContainsKey(sName))
        {
            ParseLightMapConfig(sName);
        }

        LightMapFormat pConfig;
        mLightMapConfig.TryGetValue(sName, out pConfig);
        return pConfig;
    }

    static void BuildScene(string sLevelName)
    {
        Transform pRootTrs = CreateGameObject(sLevelName, Vector3.zero, Quaternion.identity, Vector3.one).transform;
        gRootTrs = pRootTrs;
        pRootTrs.gameObject.AddComponent<SceneEntry>();

        //IHVImageFormatImporter;
        //GameObject fff = new GameObject("111");
        //ReflectionProbe rp = fff.AddComponent<ReflectionProbe>();
        //rp.mode = ReflectionProbeMode.Custom;

        //Texture bbb = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures" + "/SphereReflectionCapture_1.DDS"); 
        //rp.customBakedTexture = bbb;

        ObjcetFormat pData = null;
        for (int i = 0; i < mObjList.Count; ++i)
        {
            pData = mObjList[i];

            GameObject pObj = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Meshes/" + gSceneName + "/" + pData.sFbxName));
            pObj.name = pData.sName;

            pObj.transform.localPosition = pData.vPos;
            pObj.transform.localRotation = pData.qRot;
            pObj.transform.localScale = pData.vScale;

            pObj.transform.parent = pRootTrs;

            MeshRenderer pRender = pObj.GetComponent<MeshRenderer>();
            if (pRender)
            {
                Material pNewMat = new Material(Shader.Find(pData.mShaderName));
                if (pNewMat)
                {
                    pNewMat.mainTexture = pData.mMainTexture;
                    pNewMat.SetTexture("_LightMap", pData.mLightMapTexture);

                    LightMapFormat pConfig = GetLightMapConfig(pData.sName);

                    if (pConfig != null)
                    {
                        Vector4 uv = new Vector4(pConfig.mUVScale.x, pConfig.mUVScale.y, pConfig.mUVBias.x, pConfig.mUVBias.y);
                        pNewMat.SetVector("_LightMapUVParams", uv);
                        pNewMat.SetVector("_LightMapScale0", pConfig.mScaleLQ1);
                        pNewMat.SetVector("_LightMapAdd0", pConfig.mAddLQ1);
                        pNewMat.SetVector("_LightMapScale1", pConfig.mScaleLQ2);
                        pNewMat.SetVector("_LightMapAdd1", pConfig.mAddLQ2);
                    }

                    AssetDatabase.CreateAsset(pNewMat, "Assets/Meshes/" + gSceneName + "/Materials/" + pData.sName + ".mat");
                    pRender.material = pNewMat;
                }
            }
        }
    }

    static void MadePrefab()
    {
        if (gRootTrs == null)
        {
            return;
        }

        UnityEngine.Object tempPrefab = PrefabUtility.CreateEmptyPrefab("Assets/ResEx/Scene/Exported/" + gRootTrs.name + "_Static.prefab");
        PrefabUtility.ReplacePrefab(gRootTrs.gameObject, tempPrefab, ReplacePrefabOptions.ConnectToPrefab);
    }

    static string gSceneName = "";
    static Transform gRootTrs = null;
    static List<ObjcetFormat> mObjList = new List<ObjcetFormat>();
    static Dictionary<string, LightMapFormat> mLightMapConfig = new Dictionary<string, LightMapFormat>();

    static void ParseSceneFile(List<string> scene)
    {
        for (int i = 1; i < scene.Count; ++i)
        {
            if (scene[i] == "GameObject:")
            {
                ObjcetFormat pObj = new ObjcetFormat();

                pObj.sName = scene[++i];
                pObj.sFbxName = scene[++i];
                string[] sTexture = scene[++i].Split('\t');
                for (int n = 0; n < sTexture.Length; ++n)
                {
                    pObj.mMainTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/" + gSceneName + "/" + sTexture[n]);
                }
                pObj.sLightMapName = scene[++i];
                pObj.mLightMapTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/LightMaps/" + gSceneName + "/" + pObj.sLightMapName);

                pObj.vPos = ConverString2V3(scene[++i], 100);
                pObj.qRot = ConverString2Q(scene[++i]);
                pObj.vScale = ConverString2V3(scene[++i]);

                mObjList.Add(pObj);
            }
        }
    }

    static void ParseLightMapConfig(string sName)
    {
        List<string> config = LoadFile(Application.dataPath + "/Temp/" + gSceneName + "/" + sName + ".txt");

        LightMapFormat cLightMap = new LightMapFormat();
        int index = 0;
        cLightMap.mLightMapName = config[index];

        cLightMap.mUVScale = ConverString2V2(config[index + 2]);
        cLightMap.mUVBias = ConverString2V2(config[index + 4]);
        cLightMap.mScaleLQ1 = ConverString2V4(config[index + 6]);
        cLightMap.mAddLQ1 = ConverString2V4(config[index + 8]);
        cLightMap.mScaleLQ2 = ConverString2V4(config[index + 10]);
        cLightMap.mAddLQ2 = ConverString2V4(config[index + 12]);

        mLightMapConfig.Add(sName, cLightMap);
    }

    static void UpdateProgressBar(string sInfo, float progress)
    {
        if (progress >= 1.0f)
        {
            EditorUtility.ClearProgressBar();
        }
        else
        {
            EditorUtility.DisplayProgressBar("进度", sInfo, progress);
        }
    }

    //[MenuItem("Scene/ImportUE")]
    private static void ImportClick()
    {
        OpenFileName ofn = new OpenFileName();
        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.filter = "All Files\0*.*\0\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = Application.dataPath;//默认路径
        ofn.title = "Open File";
        ofn.defExt = "txt";//显示文件的类型
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

        if (FileDll.GetOpenFileName(ofn))
        {
            gRootTrs = null;
            mObjList.Clear();
            mLightMapConfig.Clear();

            List<string> stringlist = LoadFile(ofn.file);
            gSceneName = stringlist[0].Split('\t')[1];

            ParseSceneFile(stringlist);
            BuildScene(gSceneName);
            MadePrefab();
        }
    }

    //[MenuItem("Scene/ExportSceneConfig")]
    private static void ExportSceneConfig()
    {
        SceneEntry pInfo = null;
        GameObject[] objlist = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < objlist.Length; ++i)
        {
            pInfo = objlist[i].GetComponent<SceneEntry>();
            if (pInfo)
            {
                break;
            }
        }

        if (pInfo)
        {

        }
    }
}