using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class BuildScriptStream
{
	static string InputPath;
	static string OutputPath;
	static string PrefabPath;
	static List<string> UpdatedList = new List<string>();
    static List<string> existedFiles = null;
    //
    public static void ExportVIB()
	{
		InputPath = "../Binaries/Data";
		OutputPath = BuildScript.AssetBundlesOutputPath + "/res/" + UnityAssisstant.GROUP_VIB;
		PrefabPath = "Assets/VIBPrefab";
		UpdatedList.Clear();
		if (!Directory.Exists(OutputPath))
		{
			Directory.CreateDirectory(OutputPath);
		}
		if (!Directory.Exists(PrefabPath))
		{
			Directory.CreateDirectory(PrefabPath);
		}
        existedFiles = new List<string>(Directory.GetFiles(PrefabPath, "*.prefab", SearchOption.AllDirectories));
        existedFiles = existedFiles.ConvertAll<string>((m => m.Replace('\\', '/')));
        //
        //AssetBundleBuild[] assetBundleList = new AssetBundleBuild[1];
        List<string> sectionList = new List<string>();
		//
		string[] files = Directory.GetFiles(InputPath + "/BinaryStream/", "*.vib");
		foreach (string file in files)
		{
			string iterPath = Path.GetDirectoryName(file);
			string iterName = Path.GetFileNameWithoutExtension(file);
			if (Ignore(iterName))
			{
				continue;
			}
			AttachStream(iterPath, iterName, "vib", sectionList);
           
        }
		AttachStream(InputPath, "ConstValue", "xml", sectionList);
		//AttachStream(InputPath, "ConstValueClientEditor", "xml", sectionList);
		//AttachStream(InputPath, "ConstValueClientWeb", "xml", sectionList);
		//AttachStream(InputPath, "ConstValueClientWinPC", "xml", sectionList);
		//AttachStream(InputPath, "ConstValueClientAndroid", "xml", sectionList);
		//AttachStream(InputPath, "ConstValueClientIOS", "xml", sectionList);

        AttachStream("../Binaries/Data/Config", "ServerList", "Json", sectionList);

        //assetBundleList[0].assetBundleName = "VIBStream";
        //assetBundleList[0].assetBundleVariant = string.Empty;
        //assetBundleList[0].assetNames = sectionList.ToArray();
        //BuildPipeline.BuildAssetBundles(OutputPath, assetBundleList, BuildAssetBundleOptions.IgnoreTypeTreeChanges, EditorUserBuildSettings.activeBuildTarget);
        //
        Debug.Log("VIBStream.Update.Count = " + UpdatedList.Count);

        //删除不用的vib
        for (int i = 0; i < existedFiles.Count; ++i)
        {
            string filePath = existedFiles[i];
            //File.Delete(filePath);
            //Debug.Log("删除了多余的表"+ filePath);
        }
        existedFiles.Clear();

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

        //记录不用的删除列表
        int index = existedFiles.FindIndex(0, delegate (string fileName) { if (fileName.Contains(name.ToLower() + ".prefab")) return true; else return false; });
        if (index >= 0)
            existedFiles.RemoveAt(index);

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
		UpdatedList.Add(name);
    }

	static List<string> RemoveIgnore(string[] files)
	{
		List<string> result = new List<string>();
		foreach (string file in files)
		{
			if (!Ignore(file))
			{
				result.Add(file);
			}
		}
		return result;
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
}