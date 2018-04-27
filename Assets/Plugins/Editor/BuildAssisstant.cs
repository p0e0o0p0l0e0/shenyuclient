using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class BuildAssisstant
{
	static readonly string AssetPathHead = "Assets/";
	//
	public static UnityEngine.Object CreatePrefab(UnityEngine.GameObject go, string path, string name)
	{
		string fullName = (path + "/" + name + ".prefab").ToLower();
		UnityEngine.Object tempPrefab = PrefabUtility.CreateEmptyPrefab(fullName);
		tempPrefab = PrefabUtility.ReplacePrefab(go, tempPrefab);
		return tempPrefab;
	}

	public static string GetName(UnityEngine.Object obj)
	{
		string path = UnityEditor.AssetDatabase.GetAssetPath(obj);
		return GetName(path);
	}

	public static string GetName(string path)
	{
		UnityEditor.AssetImporter importer = UnityEditor.AssetImporter.GetAtPath(path);
		if (importer != null)
		{
			string append = string.Empty;
			Type iterType = AssetDatabase.GetMainAssetTypeAtPath(path);
			if (BuildAssisstant.IsBaseType(iterType, typeof(Material)))
			{
				append = "_material";
			}
			else if (BuildAssisstant.IsBaseType(iterType, typeof(Texture)))
			{
				append = "_texture";
			}
			else if (BuildAssisstant.IsBaseType(iterType, typeof(Shader)))
			{
				append = "_shader";
			}
			//
			string name = path.Replace(AssetPathHead, string.Empty);
			int fixIdxPos = name.IndexOf('.');
			if (fixIdxPos != -1)
			{
				name = name.Substring(0, fixIdxPos);
			}
			return name.ToLower() + append;
		}
		else
		{
			return string.Empty;
		}
	}
	public static string PathConvert(string path)
	{
		path = path.Replace("\\\\", "/");
		path = path.Replace("\\", "/");
		return path;
	}

	public static void CreateAssetBundle(string pathFile)
	{
		UnityEditor.AssetImporter importer = UnityEditor.AssetImporter.GetAtPath(pathFile);
		if (importer != null)
		{
			string name = BuildAssisstant.GetName(pathFile);
			if (string.Compare(importer.assetBundleName, name) != 0)
			{
				importer.assetBundleName = name;
				importer.SaveAndReimport();
			}
		}
	}

	public static void CreateAssetBundle(UnityEngine.Object obj)
	{
		string path = UnityEditor.AssetDatabase.GetAssetPath(obj);
		CreateAssetBundle(path);
	}

	public static void ClearAssetBundle(UnityEngine.Object obj)
	{
		string path = UnityEditor.AssetDatabase.GetAssetPath(obj);
		UnityEditor.AssetImporter importer = UnityEditor.AssetImporter.GetAtPath(path);
		if (importer != null)
		{
			importer.assetBundleName = string.Empty;
			importer.SaveAndReimport();
		}
	}

	public static void ClearAssetBundle<T>(List<T> objList) where T : UnityEngine.Object
	{
		foreach (T iterObject in objList)
		{
			ClearAssetBundle(iterObject);
		}
	}

	public static List<T> CollectAll<T>(string path, bool recursive) where T : UnityEngine.Object
	{
		return CollectAll<T>(path, "*", recursive);
	}

	public static List<T> CollectAll<T>(string path, string filter, bool recursive) where T : UnityEngine.Object
	{
		if (!Directory.Exists(path))
		{
			return new List<T>();
		}
		List<T> list = new List<T>();
		string[] files = Directory.GetFiles(path, filter, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
		foreach (string file in files)
		{
			if (file.Contains(".meta")) continue;
			T asset = (T)AssetDatabase.LoadAssetAtPath(file, typeof(T));
			if (asset != null)
			{
				list.Add(asset);
			}
		}
		return list;
	}

	public static List<string> CollectAllFile<T>(string path, bool recursive) where T : UnityEngine.Object
	{
		return CollectAllFile<T>(path, "*", recursive);
	}

	public static List<string> CollectAllFile<T>(string path, string filter, bool recursive) where T : UnityEngine.Object
	{
		List<string> list = new List<string>();
		Type type = typeof(T);
		string[] files = Directory.GetFiles(path, filter, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
		foreach (string iterFile in files)
		{
			if (iterFile.Contains(".meta")) continue;
			//
			Type iterType = AssetDatabase.GetMainAssetTypeAtPath(iterFile);
			if (IsBaseType(iterType, type))
			{
				list.Add(BuildAssisstant.PathConvert(iterFile));
			}
		}
		return list;
	}

	public static bool IsBaseType(Type deriveType, Type baseType)
	{
		if (deriveType != null)
		{
			return deriveType == baseType || deriveType.IsSubclassOf(baseType);
		}
		else
		{
			return false;
		}
	}


	public static Byte[] ReadFile(string file)
	{
		if (File.Exists(file) == false)
		{
			Debug.Log("Not find file: " + file);
			return null;
		}
		FileStream br = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read);
		if (br == null)
		{
			return null;
		}
		Byte[] data = new Byte[br.Length];
		br.Read(data, 0, data.Length);
		br.Close();
		return data;
	}

	public static void SaveFile(string file, Byte[] data)
	{
		FileStream bw = File.Create(file);
		if (bw != null)
		{
			bw.Write(data, 0, data.Length);
			bw.Close();
		}
	}


	public static bool SameExist(string prefabFile, Byte[] data)
	{
		GameObject existObj = AssetDatabase.LoadAssetAtPath<GameObject>(prefabFile);
		if (existObj == null)
		{
			return false;
		}
		BlobStream existBlob = existObj.GetComponent<BlobStream>();
		if (existBlob == null)
		{
			return false;
		}
		return Equals(existBlob.GetData(), data);
	}

	//public static bool SameMiniMap(string prefabFile, string md5Data)
	//{
	//    GameObject existObj = AssetDatabase.LoadAssetAtPath<GameObject>(prefabFile);
	//    if (existObj == null)
	//    {
	//        return false;
	//    }
	//    UIPrefabScript existBlob = existObj.GetComponent<UIPrefabScript>();
	//    if (existBlob == null)
	//    {
	//        return false;
	//    }
	//    return existBlob.MD5Data == md5Data;
	//}

	public static bool Equals(Byte[] left, Byte[] right)
	{
		if (left == null || right == null)
		{
			return false;
		}
		if (left.Length != right.Length)
		{
			return false;
		}
		for (int iter = 0; iter < left.Length; ++iter)
		{
			if (left[iter] != right[iter])
			{
				return false;
			}
		}
		return true;
	}

	public static void Read(ViIStream stream, Dictionary<string, VersionStruct> versionList)
	{
		UInt32 count;
		stream.Read(out count);
		for (int iter = 0; iter < count; ++iter)
		{
			string iterKey;
			VersionStruct iterValue = new VersionStruct();
			stream.Read(out iterKey);
			stream.Read(out iterValue.Hash);
			stream.Read(out iterValue.Version);
			versionList.Add(iterKey, iterValue);
		}
	}

	public static void Write(Dictionary<string, VersionStruct> versionList, ViOStream stream)
	{
		UInt32 count = (UInt32)versionList.Count;
		stream.Append(count);
		foreach (KeyValuePair<string, VersionStruct> iterPair in versionList)
		{
			stream.Append(iterPair.Key);
			stream.Append(iterPair.Value.Hash);
			stream.Append(iterPair.Value.Version);
		}
	}

	public static string MD5_Content(Byte[] content)
	{
		MD5 md5 = MD5.Create();
		Byte[] data = md5.ComputeHash(content);
		StringBuilder sBuilder = new StringBuilder();
		for (int i = 0; i < data.Length; i++)
		{
			sBuilder.Append(data[i].ToString("X2"));
		}
		return sBuilder.ToString();
	}
}
