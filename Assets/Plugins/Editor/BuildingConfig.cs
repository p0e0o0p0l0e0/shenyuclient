using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

public class BuildingConfig 
{
    static string InputPath;
    static string OutputPath;
    static string PrefabPath = "Assets/VIBPrefab";

    public static void ExportConfig()
    {
        InputPath = "../Binaries/Data/Config";//原地址
        OutputPath =Application.dataPath.Replace("Assets", BuildScript.AssetBundlesOutputPath + "/" + UnityAssisstant.GROUP_FIG) ;//输出路径
        if (!Directory.Exists(OutputPath))
        {
            Directory.CreateDirectory(OutputPath);
        }
        if (!Directory.Exists(PrefabPath))
        {
            Directory.CreateDirectory(PrefabPath);
        }
        AssetBundleBuild [] assetBundleList= new  AssetBundleBuild[1];
        List<string> sectionList = new List<string>();

       AttachStream(InputPath, "SeverList", "Json", sectionList);


        assetBundleList[0].assetBundleName = "ConfigStream";
        assetBundleList[0].assetBundleVariant = string.Empty;
        assetBundleList[0].assetNames = sectionList.ToArray();
        BuildPipeline.BuildAssetBundles(OutputPath, assetBundleList, BuildAssetBundleOptions.IgnoreTypeTreeChanges, EditorUserBuildSettings.activeBuildTarget);
        FileStream fs = new FileStream("LastImportTime.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        DateTime importTime = DateTime.Now;
        sw.WriteLine(importTime.ToString());
        sw.Flush();
        sw.Close();
        fs.Close();
    }

    public static void AttachStream(string path, string name, string extension, List<string> exportSectionList)
    {
        string prefabFullFile = PrefabPath + "/" + name + ".Prefab"; 
        exportSectionList.Add(prefabFullFile); 
                                               //
        Byte[] data = BuildAssisstant.ReadFile(path + "/" + name + "." + extension); 
        if (BuildAssisstant.SameExist(prefabFullFile, data))
        {
            return;
        }
        name = name.ToLower();
        GameObject obj = new GameObject(name);
        BlobStream blob = obj.AddComponent<BlobStream>();
        blob.Reset();
        blob.SetData(data);
        BuildAssisstant.CreatePrefab(obj, PrefabPath, name);
        GameObject.DestroyImmediate(obj);
    }
}
