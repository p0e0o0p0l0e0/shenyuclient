using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

public class BuildScript
{
	public static string AssetBundlesOutputPath
	{
		get
		{
            //return "Assets/StreamingAssets";
            //if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android || EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
            //{
            //	return "Assets/StreamingAssets";
            //}
            //else
            //{
            	return "AssetBundles";
            //}
        }
	}

	public static bool ValidateResource(UnityEngine.Object obj)
	{
		if (obj == null)
		{
			return false;
		}
		PrefabType prefabType = PrefabUtility.GetPrefabType(obj);

		if (prefabType != PrefabType.Prefab && !(obj is Texture) && !(obj is Material))
		{
			return false;
		}
		return true;
	}

	public static void BuildAssetBundles()
	{
		string outputPath = AssetBundlesOutputPath;
		if (!Directory.Exists(outputPath))
		{
			Directory.CreateDirectory(outputPath);
		}
		//
		AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.IgnoreTypeTreeChanges, EditorUserBuildSettings.activeBuildTarget);
	}

	public static void CreateAssetBundle()
	{
		foreach (UnityEngine.Object iterObject in Selection.objects)
		{
			BuildAssisstant.CreateAssetBundle(iterObject);
		}
	}

	public static void ClearAssetBundle()
	{
		foreach (UnityEngine.Object iterObject in Selection.objects)
		{
			BuildAssisstant.ClearAssetBundle(iterObject);
		}
	}

	public static void ClearAssetBundleForChildren()
	{
		string path = UnityEditor.AssetDatabase.GetAssetPath(Selection.activeObject);
		List<UnityEngine.Object> objList = BuildAssisstant.CollectAll<UnityEngine.Object>(path, true);
		foreach (UnityEngine.Object iterObject in objList)
		{
			BuildAssisstant.ClearAssetBundle(iterObject);
		}
	}

	public static void CreateAssetBundleForChildren<T>()
		where T : UnityEngine.Object
	{
		string path = UnityEditor.AssetDatabase.GetAssetPath(Selection.activeObject);
		List<T> objList = BuildAssisstant.CollectAll<T>(path, true);
		foreach (UnityEngine.Object iterObject in objList)
		{
			BuildAssisstant.CreateAssetBundle(iterObject);
		}
	}

	public static void CreateAssetBundleForChildrenPrefab()
	{
		//UnityEngine.Object[] prefabs = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
		//foreach (UnityEngine.Object iterObject in prefabs)
		//{
		//    PrefabType prefabType = PrefabUtility.GetPrefabType(iterObject);
		//    if (prefabType != PrefabType.Prefab)
		//    {
		//        continue;
		//    }
		//    //
		//    BuildAssisstant.CreateAssetBundle(iterObject);
		//}
		string path = UnityEditor.AssetDatabase.GetAssetPath(Selection.activeObject);
		List<GameObject> objList = BuildAssisstant.CollectAll<GameObject>(path, true);
		foreach (UnityEngine.Object iterObject in objList)
		{
			PrefabType prefabType = PrefabUtility.GetPrefabType(iterObject);
			if (prefabType != PrefabType.Prefab)
			{
				continue;
			}
			BuildAssisstant.CreateAssetBundle(iterObject);
		}
	}

	public static void CreateAssetBundleForChildrenMaterial()
	{
		CreateAssetBundleForChildren<Material>();
	}

	public static void CreateAssetBundleForChildrenTexture()
	{
		CreateAssetBundleForChildren<Texture>();
	}

	public static void MakeAssetBundleVersion()
	{
		string versionFile = ApplicationPlatform.StreamingDataPath + IOAssisstant.DataVersionFullFile;
		Int32 oldVersion = 0;
		Dictionary<string, FileVersionStruct> oldVersionList = new Dictionary<string, FileVersionStruct>();
		if (File.Exists(versionFile))
		{
			IOAssisstant.ReadVersionList(File.ReadAllText(versionFile), out oldVersion, oldVersionList);
		}
		Int32 newVersion = oldVersion + 1;
		Dictionary<string, FileVersionStruct> newVersionList = new Dictionary<string, FileVersionStruct>();
		Int32 newVersionCount = 0;
		IOAssisstant.FileMD5(ApplicationPlatform.StreamingDataPath, UnityAssisstant.GROUP_PRO, "*", SearchOption.AllDirectories, oldVersionList, newVersion, newVersionList, ref newVersionCount);
		IOAssisstant.FileMD5(ApplicationPlatform.StreamingDataPath, UnityAssisstant.GROUP_RES, "*", SearchOption.AllDirectories, oldVersionList, newVersion, newVersionList, ref newVersionCount);
		IOAssisstant.FileMD5(ApplicationPlatform.StreamingDataPath, UnityAssisstant.GROUP_VIB, "*", SearchOption.AllDirectories, oldVersionList, newVersion, newVersionList, ref newVersionCount);
		//
		Int32 version = (newVersionCount > 0) ? newVersion : oldVersion;
		File.WriteAllText(ApplicationPlatform.StreamingDataPath + IOAssisstant.DataVersionHeadFile, "&Version=" + version + "&Count=" + newVersionList.Count);
		File.WriteAllText(ApplicationPlatform.StreamingDataPath + IOAssisstant.DataVersionFullFile, IOAssisstant.PrintVersionList(version, newVersionList));
		//
		Debug.Log("MakeAssetBundleVersion.Count=" + newVersionList.Count + "/NewCount=" + newVersionCount);
	}

	public static void StaticBatch()
	{
		GameObject gameObject = Selection.activeGameObject;
		if (gameObject == null)
		{
			return;
		}
		StaticBatchingUtility.Combine(gameObject);
	}


	static void PushBackValue(Dictionary<string, List<string>> list, string key, string value, bool disInsert)
	{
		if (list == null)
		{
			return;
		}
		//
		List<string> element;
		if (list.TryGetValue(key, out element))
		{
			if (!element.Contains(value))
			{
				element.Add(value);
			}
		}
		else if (!disInsert)
		{
			element = new List<string>();
			element.Add(value);
			list.Add(key, element);
		}
	}

	static void SelectDependencies(string pathFile, Dictionary<string, List<string>> dependencyMaterialList, Dictionary<string, List<string>> dependencyTextureList, Dictionary<string, List<string>> countList)
	{
		Type materialType = typeof(Material);
		string[] fileArray = AssetDatabase.GetDependencies(pathFile, false);
		foreach (string iterFile in fileArray)
		{
			PushBackValue(countList, iterFile, pathFile, true);
			AssetImporter iterImporter = AssetImporter.GetAtPath(iterFile);
			if (!string.IsNullOrEmpty(iterImporter.assetBundleName))
			{
				continue;
			}
			Type iterType = AssetDatabase.GetMainAssetTypeAtPath(iterFile);
			if (BuildAssisstant.IsBaseType(iterType, materialType))
			{
				PushBackValue(dependencyMaterialList, iterFile, pathFile, false);
				SelectDependencies(iterFile, pathFile, dependencyTextureList, countList);
			}
		}
	}

	static void SelectDependencies(string pathFile, string rootFile, Dictionary<string, List<string>> dependencyTextureList, Dictionary<string, List<string>> countList)
	{
		Type textureType = typeof(Texture);
		string[] fileArray = AssetDatabase.GetDependencies(pathFile, false);
		foreach (string iterFile in fileArray)
		{
			PushBackValue(countList, iterFile, rootFile, true);
			AssetImporter iterImporter = AssetImporter.GetAtPath(iterFile);
			if (!string.IsNullOrEmpty(iterImporter.assetBundleName))
			{
				continue;
			}
			Type iterType = AssetDatabase.GetMainAssetTypeAtPath(iterFile);
			if (BuildAssisstant.IsBaseType(iterType, textureType))
			{
				PushBackValue(dependencyTextureList, iterFile, rootFile, false);
			}
		}
	}

	static void PrintDependency(Dictionary<string, List<string>> dependencyList, StringBuilder strBuilder, bool createAssetBundle, ref Int32 overResCount)
	{
		foreach (KeyValuePair<string, List<string>> iter in dependencyList)
		{
			AssetImporter iterImporter = AssetImporter.GetAtPath(iter.Key);
			if (iterImporter == null)
			{
				continue;
			}
			if (string.IsNullOrEmpty(iterImporter.assetBundleName) && iter.Value.Count > 1)
			{
				if (createAssetBundle)
				{
					BuildAssisstant.CreateAssetBundle(iter.Key);
				}
				strBuilder.Append("RefCount=");
				strBuilder.Append(iter.Value.Count.ToString());
				strBuilder.Append('\t');
				strBuilder.Append(iter.Key);
				foreach (string iterElement in iter.Value)
				{
					strBuilder.Append("\n\t\t\t\t\t");
					strBuilder.Append(iterElement);
				}
				strBuilder.Append('\n');
				++overResCount;
			}
		}
	}

	static void SelectAssetBundleExported<T>(string path, Dictionary<string, List<string>> list) where T : UnityEngine.Object
	{
		List<string> fileList = BuildAssisstant.CollectAllFile<T>(path, true);
		foreach (string iterFile in fileList)
		{
			AssetImporter iterImporter = AssetImporter.GetAtPath(iterFile);
			if (!string.IsNullOrEmpty(iterImporter.assetBundleName))
			{
				list.Add(iterFile, new List<string>());
			}
		}
	}

	public static void SelectAssetBundleLazier(string path, bool createAssetBundle, bool clearAssetBundle)
	{
		Dictionary<string, List<string>> exportedCountList = new Dictionary<string, List<string>>();
		SelectAssetBundleExported<Material>(path, exportedCountList);
		SelectAssetBundleExported<Texture>(path, exportedCountList);
		//
		Dictionary<string, List<string>> dependencyMaterialList = new Dictionary<string, List<string>>();
		Dictionary<string, List<string>> dependencyTextureList = new Dictionary<string, List<string>>();
		{
			List<string> fileList = BuildAssisstant.CollectAllFile<GameObject>(path, true);
			foreach (string iterFile in fileList)
			{
				AssetImporter iterImporter = AssetImporter.GetAtPath(iterFile);
				if (!string.IsNullOrEmpty(iterImporter.assetBundleName))
				{
					SelectDependencies(iterFile, dependencyMaterialList, dependencyTextureList, exportedCountList);
				}
			}
		}
		{
			List<string> fileList = BuildAssisstant.CollectAllFile<Material>(path, true);
			foreach (string iterFile in fileList)
			{
				AssetImporter iterImporter = AssetImporter.GetAtPath(iterFile);
				if (!string.IsNullOrEmpty(iterImporter.assetBundleName))
				{
					SelectDependencies(iterFile, iterFile, dependencyTextureList, exportedCountList);
				}
			}
		}
		//
		Int32 overResCount = 0;
		StringBuilder strBuilder = new StringBuilder();
		PrintDependency(dependencyMaterialList, strBuilder, createAssetBundle, ref overResCount);
		PrintDependency(dependencyTextureList, strBuilder, createAssetBundle, ref overResCount);
		//
		int freeResCount = 0;
		strBuilder.AppendLine("FreeList>>");
		foreach (KeyValuePair<string, List<string>> iter in exportedCountList)
		{
			List<string> fileList = iter.Value;
			if (fileList.Count <= 1)
			{
				if (clearAssetBundle)
				{
					AssetImporter iterImporter = AssetImporter.GetAtPath(iter.Key);
					if (iterImporter != null)
					{
						iterImporter.assetBundleName = string.Empty;
						iterImporter.SaveAndReimport();
					}
				}
				strBuilder.Append("RefCount=");
				strBuilder.Append(fileList.Count.ToString());
				strBuilder.Append('\t');
				strBuilder.Append(iter.Key);
				strBuilder.Append('\n');
				++freeResCount;
			}
		}
		//
		strBuilder.AppendLine("AllReferenceInfo>>");
		foreach (KeyValuePair<string, List<string>> iter in exportedCountList)
		{
			List<string> fileList = iter.Value;
			if (fileList.Count > 0)
			{
				strBuilder.Append("RefCount=").Append(fileList.Count.ToString());
				strBuilder.Append('\t');
				strBuilder.Append(iter.Key);
				strBuilder.Append('\n');
				foreach (string iterFile in fileList)
				{
					strBuilder.Append('\t');
					strBuilder.Append(iterFile);
					strBuilder.Append('\n');
				}
			}
		}
		//
		Debug.Log("OverResCount:" + overResCount);
		Debug.Log("FreeResCount:" + freeResCount);
		//
		TextEditor editor = new TextEditor();
		editor.text = strBuilder.ToString();
		editor.OnFocus();
		editor.Copy();
	}

	public static void FindErrorShader(List<Shader> errorShaderList)
	{
		Material defaultMaterial = AssetDatabase.LoadAssetAtPath<Material>("Assets/ResEx/Effect/Demo/SimpleDefaultMaterial.mat");
		List<GameObject> objList = BuildAssisstant.CollectAll<GameObject>("Assets", true);
		List<Renderer> rendererList = new List<Renderer>();
		StringBuilder log = new StringBuilder();
		for (int iter = 0; iter < objList.Count; ++iter)
		{
			GameObject iterObj = objList[iter];
			string iterPathFile = UnityEditor.AssetDatabase.GetAssetPath(iterObj);
			UnityEditor.AssetImporter iterImporter = UnityEditor.AssetImporter.GetAtPath(iterPathFile);
			if (!string.IsNullOrEmpty(iterImporter.assetBundleName))
			{
				rendererList.Clear();
				iterObj.GetComponentsInChildren<Renderer>(rendererList);
				FindErrorShader(iterObj, rendererList, errorShaderList, defaultMaterial, log);
			}
		}
		//
		if (log.Length <= 0)
		{
			log.Append("Congratulation!");
		}
		Debug.Log(log.ToString());
	}

	static void FindErrorShader(GameObject root, List<Renderer> rendererList, List<Shader> errorShaderList, Material defaultMaterial, StringBuilder log)
	{
		foreach (Renderer iter in rendererList)
		{
			FindErrorShader(root, iter, errorShaderList, defaultMaterial, log);
		}
	}

	static void FindErrorShader(GameObject root, Renderer renderer, List<Shader> errorShaderList, Material defaultMaterial, StringBuilder log)
	{
		if (renderer.sharedMaterials == null)
		{
			return;
		}
		if (renderer.sharedMaterials.Length == 0)
		{
			return;
		}
		for (int iter = 0; iter < renderer.sharedMaterials.Length; ++iter)
		{
			Material iterMaterial = renderer.sharedMaterials[iter];
			if (iterMaterial == null)
			{
				log.Append(root.name).Append(".").Append(renderer.gameObject.name).Append(": isNull\n");
				UnityEngine.Material[] updateMaterialList = renderer.sharedMaterials;
				updateMaterialList[iter] = defaultMaterial;
				renderer.sharedMaterials = updateMaterialList;
			}
			else if (errorShaderList.Contains(iterMaterial.shader))
			{
				log.Append(root.name).Append(".").Append(renderer.gameObject.name).Append(": Contain ").Append(iterMaterial.shader.name).Append("\n");
			}
		}
	}
}
