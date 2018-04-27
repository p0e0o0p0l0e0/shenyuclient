using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class BuildNavMap
{
	static string InputPath;
	static string OutputPath;
	static string PrefabPath;
	static List<string> UpdatedList = new List<string>();
	//
	public static void Export()
	{
		InputPath = "../Binaries/Data/Map";
		OutputPath = "../Binaries/Data/Map";
		PrefabPath = "Assets/NavMapPrefab";
		UpdatedList.Clear();
		if (!Directory.Exists(OutputPath))
		{
			Directory.CreateDirectory(OutputPath);
		}
		if (!Directory.Exists(PrefabPath))
		{
			Directory.CreateDirectory(PrefabPath);
		}
		//
		string[] files = Directory.GetFiles(InputPath, "*_NavMap.png");
		foreach (string file in files)
		{
			string iterName = Path.GetFileNameWithoutExtension(file);
			Export(file, iterName);
		}
		//
		Debug.Log("NavMap.Update.Count = " + UpdatedList.Count);
	}

	public static void Export(string file, string name)
	{
		if (File.Exists(file) == false)
		{
			Debug.Log("Not find file: " + file);
			return;
		}
		FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read);
		if (stream == null)
		{
			return;
		}
		Texture2D texture = new Texture2D(32, 32);
		byte[] datas = new byte[stream.Length];
		stream.Read(datas, 0, datas.Length);
		stream.Close();
		texture.LoadImage(datas);
		Int32 width = texture.width;
		Int32 height = texture.height;
		ViOStream os = new ViOStream(sizeof(Int32) + sizeof(Int32) + sizeof(UInt32) * width * height);
		os.Append(width);
		os.Append(height);
		for (int y = 0; y < height; ++y)
		{
			for (int x = 0; x < width; ++x)
			{
				UInt32 value = 0;
				if (texture.GetPixel(x, y).r < 0.8f)
				{
					value = 1;
				}
				os.Append(value);
			}
		}
		BuildAssisstant.SaveFile(OutputPath + "/" + name + ".vib", os.Cache);
		//
		if (!BuildAssisstant.SameExist(PrefabPath + "/" + name + ".Prefab", os.Cache))
		{
			GameObject obj = new GameObject(name);
			BlobStream blob = obj.AddComponent<BlobStream>();
			blob.Reset();
			blob.SetData(os.Cache);
			UnityEngine.Object prefab = BuildAssisstant.CreatePrefab(obj, PrefabPath, name);
			BuildAssisstant.CreateAssetBundle(prefab);
			GameObject.DestroyImmediate(obj);
			Debug.Log("NavMap.Update(" + name + ")");
			UpdatedList.Add(name);
		}
	}

}