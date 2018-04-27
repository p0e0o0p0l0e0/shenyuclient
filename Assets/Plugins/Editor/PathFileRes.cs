using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.InteropServices;
using System.IO;
using PhysicalShading;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

public class PathFileRes
{
    class ResInfo
    {
        public ResInfo()
        {

        }
        public int nID;
        public string sName;
        public string sPath;
        public string sNote;
    }

    class YamlReplace
    {
        public YamlReplace(long nID, string sGUID)
        {
            nFileID = nID;
            mGUID = sGUID;
            nType = 0;
        }
        public long nFileID;
        public string mGUID;
        public int nType;
    }

    class DependInfo
    {
        public DependInfo()
        { }
        public string mName = "";
        public string mType = "";
        public List<string> mUsers = new List<string>();
    }

    enum BuildABState
    {
        eNone,
        eParseResFile,          // 分析资源表
        eReadBuiltinFile,       // 读取内置资源
        eTraversalFile,         // 遍历客户端资源
        eParseDepend,           // 处理依赖分析冗余
        eSetABNAme,             // 设置AB名字
        eBuildAB,               // 打AB
        eRecoverAB,             // AB名字还原
        eSaveVIS,               // 输出VIS表
    }

    private static Dictionary<string, ResInfo> mResList = new Dictionary<string, ResInfo>();    // 资源配置表
    private static List<string> mNeedSingle = new List<string>();                               // 需要单独打包的资源

    private static Dictionary<int, string> mResMap = new Dictionary<int, string>();             // 资源表重复ID和名字验证

    static Dictionary<long, string> mBuiltinMap = new Dictionary<long, string>();               // 内置资源对应列表
    static Dictionary<string, DependInfo> mRedundMap = new Dictionary<string, DependInfo>();    // 引用资源计数

    static Dictionary<string, List<string>> mDependBuiltin = new Dictionary<string, List<string>>();   // 引用了内部资源的文件

    static List<AssetImporter> mAssetAB = new List<AssetImporter>();

    static float mCheckTime = 0.0f;
    static BuildABState mProgress = BuildABState.eNone;

    [UnityEditor.MenuItem("Assets/RemoveHideFlags")]
    public static void RemoveHideFlags()
    {
        for (int i = 0; i < Selection.objects.Length; i++)
        {
            Selection.objects[i].hideFlags = HideFlags.None;
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [UnityEditor.MenuItem("Assets/TestXL")]
    public static void TestXL()
    {
        //GameObject obj = Selection.activeObject as GameObject;
        //if (obj != null)
        //{
        //    Animator ator = obj.GetComponent<Animator>();
        //    if (ator != null)
        //    {
        //        UnityEngine.Object.DestroyImmediate(ator, true);
        //    }
        //}
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
        //FileBuilder.Instance.MakePackage();
        FilePackage.Instance.Initialize();
        //FilePackage.Instance.GetFileMemory("AssetBundles");
    }

    [UnityEditor.MenuItem("Assets/获取路径")]
    public static void GetFilePath()
    {
        GameObject obj = Selection.activeObject as GameObject;
        if (obj != null)
        {
            string sPath = AssetDatabase.GetAssetPath(obj);
            sPath = sPath.Replace("Assets/", string.Empty);
            sPath = sPath.Substring(0, sPath.LastIndexOf("."));

            TextEditor t = new TextEditor();
            t.text = sPath;
            t.OnFocus();
            t.Copy();

            Debug.Log(sPath);
        }
    }

    //[UnityEditor.MenuItem("VIPlugin/ExportSplatAlpha")]
    public static void ExportSplatAlpha()
    {
        GameObject obj = GameObject.Find("Terrain");
        if (obj != null)
        {
            Terrain pTerrain = obj.GetComponent<Terrain>();
            if (pTerrain == null)
            {
                return;
            }

            int nWidth = pTerrain.terrainData.alphamapWidth;
            int nHeight = pTerrain.terrainData.alphamapHeight;

            Texture2D[] pTextures = pTerrain.terrainData.alphamapTextures;

            for (int i = 0; i < pTextures.Length; ++i)
            {
                Texture2D texture = new Texture2D(nWidth, nHeight, TextureFormat.RGBA32, false);

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        Color c = pTextures[i].GetPixel(x, y);

                        texture.SetPixel(x, y, new Color(c.b, c.g, c.r, c.a));
                    }
                }
                SaveTGA("alpha_" + i, nWidth, nHeight, texture.GetRawTextureData());
            }
        }
    }

    static void SaveTGA(string filename, int width, int height, byte[] data)
    {
        FileStream bw = new FileStream(Application.dataPath + "/" + filename + ".tga", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

        byte[] type_header = { 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        bw.Write(type_header, 0, 12);

        byte[] header = { (byte)(width % 256), (byte)(width / 256), (byte)(height % 256), (byte)(height / 256), 32, 8 };
        bw.Write(header, 0, 6);
        bw.Write(data, 0, 4 * width * height);
        bw.Close();
    }

    [MenuItem("VIPlugin/清理所有资源AB名字")]
    static void ClearName()
    {
        string[] files = Directory.GetFiles("Assets", "*", SearchOption.AllDirectories);

        EditorApplication.CallbackFunction myUpdate = null;
        int nIndex = 0;
        myUpdate = () =>
        {
            string file = files[nIndex];
            try
            {
                if (file.EndsWith(".meta") || file.EndsWith(".cs"))
                {
                    bool isEnd = EditorUtility.DisplayCancelableProgressBar(nIndex + "/" + files.Length, file, (float)nIndex++ / (float)files.Length);

                    if (isEnd || nIndex >= files.Length)
                    {
                        EditorUtility.ClearProgressBar();
                        EditorApplication.update -= myUpdate;
                        AssetDatabase.Refresh();
                    }
                    return;
                }
                AssetImporter importer = AssetImporter.GetAtPath(file);
                if (importer != null)
                {
                    importer.assetBundleName = "";
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error:" + e.StackTrace);
            }

            bool isFinish = EditorUtility.DisplayCancelableProgressBar(nIndex + "/" + files.Length, file, (float)nIndex++ / (float)files.Length);

            if (isFinish || nIndex >= files.Length)
            {
                EditorUtility.ClearProgressBar();
                EditorApplication.update -= myUpdate;
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        };

        EditorApplication.update += myUpdate;
    }

    // 0 是内部资源 2 外部资源 3 基础类型的外部资源以及Missing Reference
    //[MenuItem("VIPlugin/unity_builtin")]
    static void check_unity_builtin()
    {
        string sBuiltinpath = "Assets/BuiltinRes";
        if (!Directory.Exists(sBuiltinpath))
        {
            Directory.CreateDirectory(sBuiltinpath);
            Directory.CreateDirectory(sBuiltinpath + "/builtin_materials");
            Directory.CreateDirectory(sBuiltinpath + "/builtin_textures");
            Directory.CreateDirectory(sBuiltinpath + "/default_material");
            Directory.CreateDirectory(sBuiltinpath + "/builtin_meshs");
            Directory.CreateDirectory(sBuiltinpath + "/builtin_texture");
        }

        string builtin_file = Application.dataPath + "/BuiltinRes/builtin_file_info.txt";
        if (!File.Exists(builtin_file))
        {
            File.Create(builtin_file).Close();
        }

        string[] builtin_paths = new string[] { "Resources/unity_builtin_extra", "Library/unity default resources" };

        StreamWriter sw = new StreamWriter(builtin_file, false, Encoding.Default);
        foreach (string path in builtin_paths)
        {
            UnityEngine.Object[] unityAssets = AssetDatabase.LoadAllAssetsAtPath(path);
            foreach (var asset in unityAssets)
            {
                if (asset is Material)
                {
                    Material bRes = asset as Material;
                    Material pMat = new Material(Shader.Find(bRes.shader.name));
                    string sPath = sBuiltinpath + "/builtin_materials/" + asset.name + ".mat";
                    AssetDatabase.CreateAsset(pMat, sPath);

                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(sPath);
                }
                else if (asset is Shader)
                {
                    Shader s = Shader.Find(asset.name);
                    long id = GetFileID(asset);
                    if ((id == 68 || id == 69 || id == 10755) && path == builtin_paths[1])
                    {
                        // 这3个ID 两个路径下都有，过滤点后面的
                        continue;
                    }
                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(AssetDatabase.GetAssetPath(s));
                }
                else if (asset is Texture)
                {
                    Texture2D bRes = asset as Texture2D;
                    if (bRes.format == TextureFormat.DXT1 || bRes.format == TextureFormat.DXT5)
                    {

                    }
                    else
                    {
                        Texture2D pNew = new Texture2D(bRes.width, bRes.height, bRes.format, false);
                        pNew.LoadRawTextureData(bRes.GetRawTextureData());
                        byte[] byt = pNew.EncodeToPNG();

                        File.WriteAllBytes(Application.dataPath + "/BuiltinRes/builtin_textures/" + bRes.name + ".png", byt);

                        sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine("Assets/BuiltinRes/builtin_textures/" + bRes.name + ".png");
                    }
                }
                else if (asset is Sprite)
                {
                    Sprite bRes = asset as Sprite;
                    Texture2D pTex = bRes.texture;
                    if (pTex.format == TextureFormat.DXT1 || pTex.format == TextureFormat.DXT5)
                    {

                    }
                    else
                    {
                        Texture2D pNew = new Texture2D(pTex.width, pTex.height, pTex.format, false);
                        pNew.LoadRawTextureData(pTex.GetRawTextureData());
                        byte[] byt = pNew.EncodeToPNG();
                        File.WriteAllBytes(Application.dataPath + "/BuiltinRes/builtin_textures/" + bRes.name + ".png", byt);

                        sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine("Assets/BuiltinRes/builtin_textures/" + bRes.name + ".png");
                    }
                }
                else if (asset is Mesh)
                {
                    Mesh bRes = asset as Mesh;
                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine("Assets/BuiltinRes/builtin_meshs/" + bRes.name + ".fbx");
                }
            }
        }

        sw.Flush();
        sw.Close();
        Debug.Log("Done!!!");
    }

    //[MenuItem("VIPlugin/生成内资表")]
    static void create_builtin()
    {
        string builtin_file = Application.dataPath + "/../../Binaries/ResConfig/builtin_file_info.txt";
        if (!File.Exists(builtin_file))
        {
            File.Create(builtin_file).Close();
        }

        string[] builtin_paths = new string[] { "Resources/unity_builtin_extra", "Library/unity default resources" };

        StreamWriter sw = new StreamWriter(builtin_file, false, Encoding.Default);
        foreach (string path in builtin_paths)
        {
            UnityEngine.Object[] unityAssets = AssetDatabase.LoadAllAssetsAtPath(path);
            foreach (var asset in unityAssets)
            {
                if (asset is Material)
                {
                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(asset.name + ".mat");
                }
                else if (asset is Shader)
                {
                    Shader s = Shader.Find(asset.name);
                    long id = GetFileID(asset);
                    if ((id == 68 || id == 69 || id == 10755) && path == builtin_paths[1])
                    {
                        // 这3个ID 两个路径下都有，过滤点后面的
                        continue;
                    }
                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(asset.name + ".shader");
                }
                else if (asset is Texture)
                {
                    Texture2D bRes = asset as Texture2D;
                    if (bRes.format == TextureFormat.DXT1 || bRes.format == TextureFormat.DXT5)
                    {

                    }
                    else
                    {
                        sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(bRes.name + ".png");
                    }
                }
                else if (asset is Sprite)
                {
                    Sprite bRes = asset as Sprite;
                    Texture2D pTex = bRes.texture;
                    if (pTex.format == TextureFormat.DXT1 || pTex.format == TextureFormat.DXT5)
                    {

                    }
                    else
                    {
                        sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(bRes.name + ".png");
                    }
                }
                else if (asset is Mesh)
                {
                    Mesh bRes = asset as Mesh;
                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(bRes.name + ".fbx");
                }
                else if (asset is Font)
                {
                    sw.Write(GetFileID(asset)); sw.Write("\t"); sw.WriteLine(asset.name + ".ttf");
                }
            }
        }

        sw.Flush();
        sw.Close();
        Debug.Log("Done!!!");
    }

    [MenuItem("VIPlugin/一键AB")]
    private static void AB()
    {
        mCheckTime = Time.realtimeSinceStartup;

        mResList.Clear();
        mNeedSingle.Clear();
        mResMap.Clear();
        mRedundMap.Clear();
        mAssetAB.Clear();
        mBuiltinMap.Clear();
        mDependBuiltin.Clear();

        ParseResFile();     // 资源列表
        BuiltinFile();      // 内置资源
        UpdateABName();
    }


    static string IsFileExists(string sPath)
    {
        string sFullPath = "Assets/" + sPath;
        string[] sExtensions = new string[] { ".prefab", ".mat", ".png", ".ogg", ".mp4", ".ttf", ".asset" };

        for (int i = 0; i < sExtensions.Length; ++i)
        {
            if (File.Exists(sFullPath + sExtensions[i]))
            {
                return sFullPath + sExtensions[i];
            }
        }

        return string.Empty;
    }

    // 资源表
    private static void ParseResFile()
    {
        string sResConfigPath = Application.dataPath + "/../../Binaries/Data/VIS/PathFileResStruct.vis";
        if (!File.Exists(sResConfigPath))
        {
            throw new NotImplementedException("资源配置表不存在!!!");
        }

        StringBuilder mNoPath = new StringBuilder();
        StreamReader sFile = new StreamReader(sResConfigPath, Encoding.Default);
        try
        {
            string line = string.Empty;
            sFile.ReadLine();
            sFile.ReadLine();
            sFile.ReadLine();
            while ((line = sFile.ReadLine()) != null)
            {
                string[] s = line.Split('\t');
                int ID = int.Parse(s[0]);
                string Name = s[5].ToLower();

                if (mResMap.ContainsKey(ID))
                {
                    Debug.LogError("ID = " + ID + " 重复!");
                    continue;
                }
                if (mResMap.ContainsValue(Name))
                {
                    Debug.LogError("Name = " + Name + " 重复!");
                    continue;
                }

                string sFilePath = IsFileExists(s[4]);
                if (string.IsNullOrEmpty(sFilePath))
                {
                    mNoPath.AppendLine(ID + "\t" + Name);
                    continue;
                }

                mResMap.Add(ID, Name);

                ResInfo pRes = new ResInfo();
                pRes.nID = ID;
                pRes.sName = Name;
                pRes.sNote = s[2];
                pRes.sPath = sFilePath;
                mResList.Add(Name, pRes);
            }
        }
        catch (System.Exception ex)
        {
            sFile.Close();
            Debug.LogError("ParseResFile " + ex.Message);
        }

        sFile.Close();

        if (mNoPath.Length > 0)
        {
            Debug.Log("以下资源没有找到！！\n" + mNoPath.ToString());
        }

        ParseResPathFile();
    }

    static int GetFreeID()
    {
        int i = 1;
        while (mResMap.ContainsKey(i))
        {
            ++i;
        }

        return i;
    }

    // 配置的资源路径
    private static void ParseResPathFile()
    {
        string sConfigPath = Application.dataPath + "/../../Binaries/ResConfig/LoadResPath.txt";
        if (!File.Exists(sConfigPath))
        {
            throw new NotImplementedException("路径资源置表不存在!!!");
        }

        StreamReader sFile = new StreamReader(sConfigPath, Encoding.Default);
        try
        {
            var searchPattern = new Regex(@"$(?<=\.(prefab|png|ogg|mp4|ttf|asset))", RegexOptions.IgnoreCase);

            string line = string.Empty;
            while ((line = sFile.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                List<string> files = null;
                string[] s = line.Split('\t');

                if (s.Length > 1)
                {
                    var sMatch = new Regex(@"$(?<=\.(" + s[1] + "))", RegexOptions.IgnoreCase);
                    files = Directory.GetFiles(s[0], "*.*", SearchOption.AllDirectories).Where(f => sMatch.IsMatch(f)).ToList();
                }
                else
                {
                    files = Directory.GetFiles(s[0], "*.*", SearchOption.AllDirectories).Where(f => searchPattern.IsMatch(f)).ToList();
                }

                for (int i = 0; i < files.Count; ++i)
                {
                    ResInfo pRes = new ResInfo();
                    pRes.nID = GetFreeID();
                    pRes.sName = Path.GetFileName(files[i]).Replace(Path.GetExtension(files[i]), "").ToLower();
                    pRes.sNote = files[i];
                    pRes.sPath = files[i];
                    if (mResMap.ContainsValue(pRes.sName))
                    {
                        Debug.LogError(files + "   " + pRes.sName + " 重复!");
                        continue;
                    }

                    mResMap.Add(pRes.nID, pRes.sName);
                    mResList.Add(pRes.sName, pRes);
                    mNeedSingle.Add(pRes.sName);
                }
            }
        }
        catch (System.Exception ex)
        {
            sFile.Close();
            Debug.LogError("ParseResFile " + ex.Message);
        }
        sFile.Close();
    }

    // 解析内置资源
    static void BuiltinFile()
    {
        mBuiltinMap.Clear();
        string sBuiltinFile = Application.dataPath + "/../../Binaries/ResConfig/builtin_file_info.txt";
        if (!File.Exists(sBuiltinFile))
        {
            Debug.LogError("内置资源配置文件不存在 是不是没有提取！！！");
            return;
        }

        StreamReader sFile = File.OpenText(sBuiltinFile);
        string line = string.Empty;
        while ((line = sFile.ReadLine()) != null)
        {
            string[] s = line.Split('\t');
            mBuiltinMap.Add(long.Parse(s[0]), s[1]);
        }
        sFile.Close();
    }

    static bool IsCompound(string sPath)
    {
        return false;
        return (sPath.EndsWith(".prefab") || sPath.EndsWith(".mat") || sPath.EndsWith(".unity") || sPath.EndsWith(".asset"));
    }

    static void ParseYaml(string sPath)
    {
        string sFilePath = sPath.ToLower();
        sFilePath = sFilePath.Replace("\\", "/");
        if (mDependBuiltin.ContainsKey(sFilePath))
        {
            return;
        }

        if (!File.Exists(sPath))
        {
            Debug.Log("依赖文件不存在!!    " + sPath);
            return;
        }

        StreamReader yamlReader = File.OpenText(sPath);
        string sYaml = yamlReader.ReadToEnd();
        yamlReader.Close();

        int index = 0;
        while (index != -1)
        {
            index = sYaml.IndexOf(", type: 0}", index);
            if (index != -1)
            {
                int guidBegin = sYaml.LastIndexOf(" ", index - 2);
                int fileidend = sYaml.LastIndexOf(",", guidBegin);
                int fileidbegin = sYaml.LastIndexOf(" ", fileidend);

                long nFileID = long.Parse(sYaml.Substring(fileidbegin, fileidend - fileidbegin));

                List<string> bMapList = null;
                if (mDependBuiltin.TryGetValue(sFilePath, out bMapList))
                {
                    bMapList.Add(mBuiltinMap[nFileID]);
                }
                else
                {
                    bMapList = new List<string>();
                    bMapList.Add(mBuiltinMap[nFileID]);
                    mDependBuiltin.Add(sFilePath, bMapList);
                }

                ++index;
            }
        }

        return;

        //List<YamlReplace> ReplaceList = new List<YamlReplace>();
        //int index = 0;
        //while (index != -1)
        //{
        //    index = sYaml.IndexOf(", type: 0}", index);
        //    if (index != -1)
        //    {
        //        int guidBegin = sYaml.LastIndexOf(" ", index - 2);
        //        string sGUID = sYaml.Substring(guidBegin + 1, index - guidBegin - 1);

        //        int fileidend = sYaml.LastIndexOf(",", guidBegin);
        //        int fileidbegin = sYaml.LastIndexOf(" ", fileidend);

        //        string sFileID = sYaml.Substring(fileidbegin, fileidend - fileidbegin);

        //        ReplaceList.Add(new YamlReplace(long.Parse(sFileID), sGUID));

        //        ++index;
        //    }
        //}

        //if (ReplaceList.Count <= 0)
        //{
        //    return;
        //}

        //for (int i = 0; i < ReplaceList.Count; ++i)
        //{
        //    string src = string.Format("fileID: {0}, guid: {1}, type: 0", ReplaceList[i].nFileID, ReplaceList[i].mGUID);
        //    string des = GetReplaceString(ReplaceList[i].nFileID);

        //    sYaml = sYaml.Replace(src, des);
        //}

        //Debug.Log("引用了内部资源 被修改 " + sPath);

        //FileStream fs = new FileStream(sPath, FileMode.Truncate);
        //StreamWriter sw = new StreamWriter(fs);
        //sw.Write(sYaml);
        //sw.Flush();
        //sw.Close();
        //fs.Close();
    }

    static string GetReplaceString(long nFileID)
    {
        string sPath = string.Empty;
        if (!mBuiltinMap.TryGetValue(nFileID, out sPath))
        {
            Debug.Log(String.Format("内置资源ID = {0} 没有找到!", nFileID));
            return "";
        }
        UnityEngine.Object obj = AssetDatabase.LoadMainAssetAtPath(sPath);
        if (sPath.EndsWith("fbx"))
        {
            GameObject pFBX = obj as GameObject;
            if (pFBX != null)
            {
                MeshFilter pMesh = pFBX.GetComponent<MeshFilter>();
                obj = pMesh.sharedMesh != null ? pMesh.sharedMesh : obj;
            }
        }
        return string.Format("fileID: {0}, guid: {1}, type: {2}", GetFileID(obj), AssetDatabase.AssetPathToGUID(sPath), IsCompound(sPath) ? 2 : 3);
    }

    static PropertyInfo inspectorMode = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
    static long GetFileID(UnityEngine.Object target)
    {
        SerializedObject serializedObject = new SerializedObject(target);
        inspectorMode.SetValue(serializedObject, InspectorMode.Debug, null);
        SerializedProperty localIdProp = serializedObject.FindProperty("m_LocalIdentfierInFile");
        return localIdProp.longValue;
    }

    static void UpdateABName()
    {
        if (mResList.Count <= 0)
        {
            throw new NotImplementedException("没有任何资源输出???");
        }

        List<ResInfo> mNeedBuilds = mResList.Values.ToList<ResInfo>();
        EditorApplication.CallbackFunction myUpdate = null;

        int nIndex = 0;
        myUpdate = () =>
        {
            ResInfo pFile = mNeedBuilds[nIndex];
            try
            {
                string sPath = pFile.sPath;
                if (IsCompound(sPath))
                {
                    ParseYaml(sPath);
                }
                // 主资源必打AB
                SetABName(sPath);

                // 引用资源 引用大于1 打AB
                string[] dependencies = AssetDatabase.GetDependencies(sPath);
                for (int i = 0; i < dependencies.Length; ++i)
                {
                    string sDepName = dependencies[i].ToLower();
                    if (sDepName.EndsWith(".cs"))
                    {
                        continue;
                    }

                    if (!mRedundMap.ContainsKey(sDepName))
                    {
                        if (IsCompound(sDepName))
                        {
                            ParseYaml(sDepName);
                        }

                        DependInfo pRedInfo = new DependInfo();
                        pRedInfo.mName = sDepName;
                        pRedInfo.mType = AssetDatabase.GetMainAssetTypeAtPath(sDepName).ToString();
                        mRedundMap.Add(sDepName, pRedInfo);
                        pRedInfo.mUsers.Add(sPath);
                    }
                    else
                    {
                        DependInfo pRedInfo = mRedundMap[sDepName];
                        pRedInfo.mUsers.Add(sPath);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error:" + e.StackTrace);
            }

            bool isFinish = EditorUtility.DisplayCancelableProgressBar("处理依赖 (" + nIndex + "/" + mNeedBuilds.Count + ")", pFile.sName, (float)nIndex++ / (float)mNeedBuilds.Count);

            if (isFinish || nIndex >= mNeedBuilds.Count)
            {
                EditorUtility.ClearProgressBar();
                EditorApplication.update -= myUpdate;
                AssetDatabase.Refresh();

                if (nIndex >= mNeedBuilds.Count)
                {
                    bool bGoOn = true;
                    if (mDependBuiltin.Count > 0)
                    {
                        //bGoOn = false;
                        StringBuilder sb = new StringBuilder();
                        foreach (var kInfo in mDependBuiltin)
                        {
                            sb.AppendLine(kInfo.Key);
                            for (int k = 0; k < kInfo.Value.Count; ++k)
                            {
                                sb.Append("\t");
                                sb.AppendLine(kInfo.Value[k]);
                            }
                        }
                        Debug.Log("以下文件引用了内部资源!!!请修改!!! 共" + mDependBuiltin.Count + " 个\n" + sb.ToString());
                    }

                    if (true)
                    {
                        // 去掉唯一引用的资源 并 设置ABNmae
                        Neaten();
                    }
                }
            }
        };

        EditorApplication.update += myUpdate;
    }

    static void Neaten()
    {
        List<string> keys = new List<string>();
        foreach (var pInfo in mRedundMap)
        {
            if (pInfo.Value.mUsers.Count <= 1 && !mNeedSingle.Contains(pInfo.Key))
            {
                keys.Add(pInfo.Key);
            }
        }
        foreach (var value in keys)
        {
            mRedundMap.Remove(value);
        }

        List<DependInfo> raList = mRedundMap.Values.ToList<DependInfo>();
        EditorApplication.CallbackFunction myUpdate = null;

        if (raList.Count <= 0)
        {
            return;
        }
        int nIndex = 0;
        myUpdate = () =>
        {
            string sPath = raList[nIndex].mName;

            SetABName(sPath);

            bool isFinish = EditorUtility.DisplayCancelableProgressBar("Set AssetBundles Name (" + nIndex + "/" + raList.Count + ")", sPath, (float)nIndex++ / (float)raList.Count);

            if (isFinish || nIndex >= raList.Count)
            {
                EditorUtility.ClearProgressBar();
                EditorApplication.update -= myUpdate;
                if (isFinish)
                {
                    foreach (AssetImporter asset in mAssetAB)
                    {
                        asset.assetBundleName = "";
                    }
                }
                if (nIndex >= raList.Count)
                {
                    BuildAB();
                }
            }
        };

        EditorApplication.update += myUpdate;
    }

    public static void UpdateVIB()
    {
        string InputPath = "../Binaries/Data";
        string OutputPath = BuildScript.AssetBundlesOutputPath + "/res/" + UnityAssisstant.GROUP_VIB;
        string PrefabPath = "Assets/VIBPrefab";

        if (!Directory.Exists(OutputPath))
        {
            Directory.CreateDirectory(OutputPath);
        }
        if (!Directory.Exists(PrefabPath))
        {
            Directory.CreateDirectory(PrefabPath);
        }

        string[] files = Directory.GetFiles(InputPath + "/BinaryStream/", "*.vib");
        foreach (string file in files)
        {
            string iterPath = Path.GetDirectoryName(file);
            string iterName = Path.GetFileNameWithoutExtension(file);
            if (Ignore(iterName))
            {
                continue;
            }
            AttachStream(iterPath, iterName, "vib");
        }
        AttachStream(InputPath, "ConstValue", "xml");
        AttachStream("../Binaries/Data/Config", "ServerList", "Json");
    }

    public static void AttachStream(string path, string name, string extension)
    {
        string prefabFullFile = "Assets/VIBPrefab/" + name + ".prefab";

        Byte[] data = BuildAssisstant.ReadFile(path + "/" + name + "." + extension);
        if (BuildAssisstant.SameExist(prefabFullFile, data))
        {
            AssetImporter imp = AssetImporter.GetAtPath(prefabFullFile);
            if (imp != null)
            {
                imp.assetBundleName = "vib/vibstream";
                mAssetAB.Add(imp);
            }
            return;
        }
        name = name.ToLower();
        GameObject obj = new GameObject(name);
        BlobStream blob = obj.AddComponent<BlobStream>();
        blob.Reset();
        blob.SetData(data);
        BuildAssisstant.CreatePrefab(obj, "Assets/VIBPrefab", name);
        GameObject.DestroyImmediate(obj);

        AssetImporter importer = AssetImporter.GetAtPath(prefabFullFile);
        if (importer != null)
        {
            importer.assetBundleName = "vib/vibstream";
            mAssetAB.Add(importer);
        }
    }

    static bool Ignore(string name)
    {
        foreach (string element in IgnoreList)
        {
            if (name.Contains(element))
            {
                return true;
            }
        }
        return false;
    }

    static string[] IgnoreList =
    {
        "ServerConfigStruct" ,
        "RPCStruct",
    };

    static void BuildAB()
    {
        UpdateVIB();

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        BuildScript.BuildAssetBundles();

        foreach (AssetImporter asset in mAssetAB)
        {
            asset.assetBundleName = "";
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        //FileBuilder.Instance.MakePackage();

        Debug.Log("全部完成!!!  总耗时:  " + (Time.realtimeSinceStartup - mCheckTime));
    }

    public static string GetName(string path)
    {
        string name = path.ToLower();
        name = name.Replace("\\", "/");
        name = name.Replace("assets/", string.Empty);
        int fixIdxPos = name.IndexOf('.');
        if (fixIdxPos != -1)
        {
            name = name.Substring(0, fixIdxPos);
        }
        return name;
    }

    static void SetABName(string sPath)
    {
        AssetImporter importer = AssetImporter.GetAtPath(sPath);
        if (importer != null)
        {
            importer.assetBundleName = GetName(sPath);
            mAssetAB.Add(importer);
        }
    }
}