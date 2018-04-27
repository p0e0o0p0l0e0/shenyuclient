using System;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationPlatform
{
	public static string WWWURL = "NONE";
	public static string WWWStreamingDataURL = "NONE";
	public static string StreamingDataPath = "NONE";
	public static string StreamingDataURL = "NONE";
	public static string PersistentDataPath = "NONE";
	public static string PersistentDataURL = "NONE";
	public static string NetDesc
	{
		get
		{
			switch (Application.internetReachability)
			{
				case NetworkReachability.ReachableViaCarrierDataNetwork:
					return "3G/4G";
				case NetworkReachability.ReachableViaLocalAreaNetwork:
					return "WiFi";
				default:
					return "无信号";
			}
		}
	}
	
	public static string Name()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.OSXEditor:
				return "OSXEditor";
			case RuntimePlatform.OSXPlayer:
				return "OSXPlayer";
			case RuntimePlatform.WindowsPlayer:
				return "WindowsPlayer";
			case RuntimePlatform.WindowsEditor:
				return "WindowsEditor";
			case RuntimePlatform.IPhonePlayer:
				return "IPhonePlayer";
			case RuntimePlatform.WebGLPlayer:
				return "WebGLPlayer";
			default:
				return "NONE";
		}
	}

	static ApplicationPlatform()
	{
		Init();
	}

	public static void Init()
	{
		switch (Application.platform)
		{
			case RuntimePlatform.WindowsPlayer:
				{
					StreamingDataPath = Application.dataPath + "/assetbundles/";
					PersistentDataPath = Application.persistentDataPath + "/";
				}
				break;
			case RuntimePlatform.WindowsEditor:
				{
					StreamingDataPath = System.IO.Path.Combine(Application.streamingAssetsPath, "") + "/";
					PersistentDataPath = System.IO.Path.Combine(Application.persistentDataPath, "") + "/";
				}
				break;
			case RuntimePlatform.Android:
				{
					StreamingDataPath = System.IO.Path.Combine(Application.streamingAssetsPath, "") + "/";
					PersistentDataPath = System.IO.Path.Combine(Application.persistentDataPath, "") + "/";
				}
				break;
			case RuntimePlatform.OSXEditor:
				{
					StreamingDataPath = System.IO.Path.Combine(Application.streamingAssetsPath, "") + "/";
					PersistentDataPath = System.IO.Path.Combine(Application.persistentDataPath, "") + "/";
				}
				break;
			case RuntimePlatform.IPhonePlayer:
				{
					StreamingDataPath = System.IO.Path.Combine(Application.dataPath, "Raw") + "/";
					PersistentDataPath = System.IO.Path.Combine(Application.persistentDataPath, "") + "/";
				}
				break;
		}
		//
		StreamingDataURL = GetURL(StreamingDataPath);
		PersistentDataURL = GetURL(PersistentDataPath);
		SetWebRoot("http://192.168.100.71:8080/Fate/");
	}

	public static void SetWebRoot(string path)
	{
		WWWURL = path;
		WWWStreamingDataURL = WWWURL + "StreamingAssets/";
	}

	static string GetURL(string path)
	{
		if (path.Contains("file:"))
		{
			return path;
		}
		else
		{
			return "file:" + path;
		}
	}

	public static bool VersionUpThan(string left, string right)
	{
		string[] leftFragmentList = left.Split('.');
		string[] rightFragmentList = right.Split('.');
		if (leftFragmentList.Length != rightFragmentList.Length)
		{
			return leftFragmentList.Length > rightFragmentList.Length;
		}
		//
		for (int iter = 0; iter < leftFragmentList.Length; ++iter)
		{
			int iterLeftFragment = Int32.Parse(leftFragmentList[iter]);
			int iterRightFragment = Int32.Parse(rightFragmentList[iter]);
			if (iterLeftFragment == iterRightFragment)
			{
				continue;
			}
			//
			return iterLeftFragment > iterRightFragment;
		}
		//
		return false;
	}

	public static string MaxVersion(string version0, string version1)
	{
		if (VersionUpThan(version0, version1))
		{
			return version0;
		}
		else
		{
			return version1;
		}
	}
}