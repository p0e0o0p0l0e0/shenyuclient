using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 0414 // 已被赋值，但从未使用过它的值;

public class AssetbundlesMenuItems
{
	[MenuItem("Assets/AssetBundle/Create")]
	static void CreateAssetBundle()
	{
		BuildScript.CreateAssetBundle();
	}

	[MenuItem("Assets/AssetBundle/Clear")]
	static void ClearAssetBundle()
	{
		BuildScript.ClearAssetBundle();
	}

	[MenuItem("Assets/AssetBundle/ClearChildren")]
	static void ClearAssetBundleForChildren()
	{
		BuildScript.ClearAssetBundleForChildren();
	}

	[MenuItem("Assets/AssetBundle/CreateChildren/Prefab")]
	public static void CreateAssetBundleForChildrenPrefab()
	{
		BuildScript.CreateAssetBundleForChildrenPrefab();
	}

	[MenuItem("Assets/AssetBundle/CreateChildren/Material")]
	public static void CreateAssetBundleForChildrenMaterial()
	{
		BuildScript.CreateAssetBundleForChildrenMaterial();
	}

	[MenuItem("Assets/AssetBundle/CreateChildren/Texture")]
	public static void CreateAssetBundleForChildrenTexture()
	{
		BuildScript.CreateAssetBundleForChildrenTexture();
	}

	[MenuItem("Assets/AssetBundle/CreateCharacter")]
	public static void CreateCharacter()
	{
		//BuildAvatar.Export();
	}

	//[MenuItem("VIPlugin/Pro")]
	static public void BuildAssetBundles()
	{
		BuildScript.BuildAssetBundles();
	}
	[MenuItem("VIPlugin/更新策划数据 服务器列表")]
	public static void ExportVIB()
	{
		BuildScriptStream.ExportVIB();
	}
    //[MenuItem("VIPlugin/更新服务器列表[即将废弃]")]
    public static void ExportConfig()
    {
        BuildingConfig.ExportConfig();
    }
    //[MenuItem("VIPlugin/AutoCopyPro")]
    static public void AutoCopyPro()
    {
        FileUtils.MoveAllDirectory(FileUtils.GetSourcePath(UnityAssisstant.GROUP_PRO), FileUtils.GetDesPath(UnityAssisstant.GROUP_PRO));
    }
    //[MenuItem("VIPlugin/AutoCopyVIB")]
    public static void AutoCopyVIB()
    {
        FileUtils.MoveAllDirectory(FileUtils.GetSourcePath(UnityAssisstant.GROUP_VIB), FileUtils.GetDesPath(UnityAssisstant.GROUP_VIB));
    }
    [MenuItem("VIPlugin/MakeVersion")]
	static public void MakeAssetBundleVersion()
	{
		BuildScript.MakeAssetBundleVersion();
	}
	//[MenuItem("VIPlugin/UpdateAssetbundleName")]
	//public static void ConvertAssetbundleName()
	//{
	//	List<UnityEngine.Object> objList = BuildAssisstant.CollectAll<UnityEngine.Object>("Assets", true);
	//	for (int iter = 0; iter < objList.Count; ++iter)
	//	{
	//		UnityEngine.Object iterObj = objList[iter];
	//		string iterPath = UnityEditor.AssetDatabase.GetAssetPath(iterObj);
	//		UnityEditor.AssetImporter importer = UnityEditor.AssetImporter.GetAtPath(iterPath);
	//		if (importer != null && !string.IsNullOrEmpty(importer.assetBundleName))
	//		{
	//			string name = BuildAssisstant.GetName(iterObj);
	//			if (string.Compare(importer.assetBundleName, name) != 0)
	//			{
	//				importer.assetBundleName = name;
	//				importer.SaveAndReimport();
	//			}
	//		}
	//	}
	//}
	//[UnityEditor.MenuItem("VIPlugin/SelectAssetBundleLazier")]
	static public void SelectAssetBundleLazier()
	{
		BuildScript.SelectAssetBundleLazier("Assets", false, false);
	}
	//[UnityEditor.MenuItem("VIPlugin/SelectAssetBundleLazier_CreateAndClear")]
	static public void SelectAndCreateAssetBundleLazier()
	{
		BuildScript.SelectAssetBundleLazier("Assets", true, true);
	}
	[UnityEditor.MenuItem("VIPlugin/FindErrorShader")]
	static public void FindErrorShader()
	{
		List<Shader> errorShaderList = new List<Shader>();
		errorShaderList.Add(Shader.Find("Standard"));
		BuildScript.FindErrorShader(errorShaderList);
	}
	[MenuItem("VIPlugin/CleanCache")]
	public static void OpenCacheDir()
	{
		Debug.Log("CleanCache.Size=" + Caching.spaceOccupied);
		Caching.CleanCache();
	}

	[MenuItem("Scene/StaticBatch")]
	public static void StaticBatch()
	{
		BuildScript.StaticBatch();
	}

	[MenuItem("Scene/NavMap")]
	public static void ExportNavMap()
	{
		BuildNavMap.Export();
	}

	[MenuItem("OpenDir/Persistent")]
	public static void OpenPersistentDir()
	{
		OpenDir(Application.persistentDataPath);
	}
	[MenuItem("OpenDir/Streaming")]
	public static void OpenStreamingDir()
	{
		OpenDir(Application.streamingAssetsPath);
	}
	public static void OpenDir(string path)
	{
		path = path.Replace('/', '\\');
		System.Diagnostics.Process.Start("Explorer.exe", path);
	}

	//[MenuItem("Scene/保存Lightmaps")]
	//public static void RecordLightmaps()
	//{
	//    BuildScript.RecordLightmaps();
	//}

	//[MenuItem("Export/GenerateUIMiniMap")]
	//public static void GenerateMiniMapPrefabs()
	//{
	//    List<Texture2D> textures2 = BuildAssisstant.CollectAll<Texture2D>(_FilePath, "*.png");
	//    foreach (Texture2D iterTexture in textures2)
	//    {
	//        string name = _UIPrefix + iterTexture.name;
	//        int index = name.IndexOf("NavMap");
	//        name = name.Substring(0, index) + "MiniMap";
	//        //
	//        _GeneratorMiniMap(iterTexture, name, "_Map", _Shader_MiniMap2);
	//    }
	//}
	//static void _GeneratorMiniMap(Texture2D texture, string name, string texturePropertyName, string shader)
	//{
	//    string md5 = BuildAssisstant.MD5_Content(texture.GetRawTextureData());
	//    if (BuildAssisstant.SameMiniMap(_PrefabPath + "/" + name + ".Prefab", md5))
	//    {
	//        return;
	//    }
	//    //
	//    Material m = new Material(Shader.Find(shader));
	//    m.SetTexture(texturePropertyName, texture);
	//    m.name = name;
	//    AssetDatabase.CreateAsset(m, _MaterialPath + "/" + name + _MaterialFlag + ".mat");
	//    //
	//    GameObject obj = new GameObject(name);
	//    UIPrefabScript script = obj.AddComponent<UIPrefabScript>();
	//    script.mMaterial = m;
	//    script.MD5Data = md5;
	//    UnityEngine.Object prefab = BuildAssisstant.GetPrefab(obj, _PrefabPath, name);
	//    BuildAssisstant.CreateAssetBundle(prefab);
	//    GameObject.DestroyImmediate(obj);
	//    obj = null;
	//}

	static string _MaterialPath = "Assets/NGUIResource/Materials/MiniMap";
	static string _PrefabPath = "Assets/NGUIResource/Prefabs/MiniMap";
	static string _FilePath = "Assets/NGUIResource/Textures/MiniMap";
	static string _Shader = "Unlit/Transparent Colored";
	static string _Shader_MiniMap2 = "Shader Forge/MapGenerator";
	static string _UIPrefix = "UI";
	static string _MaterialFlag = "";
}
