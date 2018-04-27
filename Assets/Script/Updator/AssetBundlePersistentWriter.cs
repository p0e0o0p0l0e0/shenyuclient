using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundlePersistentWriter : PersistentWriter
{
	public void Start(string url, bool onlyLoadHead)
	{
		Int32 version = 0;
		Dictionary<string, FileVersionStruct> localVersionList = new Dictionary<string, FileVersionStruct>();
		if (File.Exists(ApplicationPlatform.PersistentDataPath + IOAssisstant.DataVersionFullFile))
		{
			IOAssisstant.ReadVersionList(File.ReadAllText(ApplicationPlatform.PersistentDataPath + IOAssisstant.DataVersionFullFile), out version, localVersionList);
			IOAssisstant.EraseNotExist(ApplicationPlatform.PersistentDataPath, localVersionList);
		}
		else
		{
			IOAssisstant.FileMD5(ApplicationPlatform.PersistentDataPath, UnityAssisstant.GROUP_PRO, "*", SearchOption.AllDirectories, localVersionList);
			IOAssisstant.FileMD5(ApplicationPlatform.PersistentDataPath, UnityAssisstant.GROUP_RES, "*", SearchOption.AllDirectories, localVersionList);
			IOAssisstant.FileMD5(ApplicationPlatform.PersistentDataPath, UnityAssisstant.GROUP_VIB, "*", SearchOption.AllDirectories, localVersionList);
		}
		//
		Start(url, onlyLoadHead, version, localVersionList);
	}

	public void Start(string url, bool onlyLoadHead, Int32 localVersion, Dictionary<string, FileVersionStruct> localVersionList)
	{
		Debug.Log("AssetBundlePresistentWriter.Start(URL=" + url + ", Version=" + localVersion + ", Count=" + localVersionList.Count + ")");
		//
		_url = url;
		_localVersion = localVersion;
		_localVersionList = localVersionList;
		LoadFull = !onlyLoadHead;
		//
		AddLoad(IOAssisstant.DataVersionHeadFile, this.OnVersionHeadListLoaded);
		//
		LoadPop();
	}

	void OnVersionHeadListLoaded(string name, WWW loader, ref bool saveToPresistent)
	{
		saveToPresistent = false;
		//
		if (!string.IsNullOrEmpty(loader.error))
		{
			Debug.Log("AssetBundlePresistentWriter.OnVersionHeadListLoaded Fail");
			return;
		}
		//
		string versionStr = loader.text;
		_newVersion = Int32.Parse(StandardAssisstant.GetStrValue(versionStr, "Version="));
		Int32 newDataCount = Int32.Parse(StandardAssisstant.GetStrValue(versionStr, "Count="));
		Debug.Log("AssetBundlePresistentWriter.OnVersionHeadListLoaded.Version=" + _newVersion + "/Count=" + newDataCount);
		if (_newVersion != _localVersion || newDataCount != _localVersionList.Count)
		{
			AddLoad(IOAssisstant.DataVersionFullFile, this.OnVersionFullListLoaded);
		}
	}

	void OnVersionFullListLoaded(string name, WWW loader, ref bool saveToPresistent)
	{
		saveToPresistent = false;
		//
		if (!string.IsNullOrEmpty(loader.error))
		{
			Debug.Log("AssetBundlePresistentWriter.OnVersionFullListLoaded Fail");
			return;
		}
		//
		string newVersionScript = loader.text;
		IOAssisstant.ReadVersionList(newVersionScript, out _newVersion, _newVersionList);
		UseNewLocalVersion(_newVersionList, _localVersionList);
		//
		FileVersionStruct localVersion;
		int loadingSize = 0;
		for (int iter = 0; iter < _newVersionList.Count; ++iter)
		{
			FileVersionStruct iterNewVersion = _newVersionList[iter];
			if (_localVersionList.TryGetValue(iterNewVersion.Name, out localVersion) && localVersion.MD5 == iterNewVersion.MD5)
			{
				continue;
			}
			//
			//Debug.Log("LoadAB:" + iterFile);
			loadingSize += iterNewVersion.Size;
			if (LoadFull)
			{
				AddLoad(iterNewVersion.Name, null);
			}
		}
		SetTotalSize(loadingSize);
		Debug.Log("AssetBundlePresistentWriter.OnVersionFullListLoaded.FileCount=" + _newVersionList.Count + "/UpdateCount=" + _reserveList.Count);
		//
		if (LoadFull)
		{
			_writeVersion = true;
			IOAssisstant.DelPresistentFile(IOAssisstant.DataVersionFullFile);
		}
	}

	static void UseNewLocalVersion(List<FileVersionStruct> newList, Dictionary<string, FileVersionStruct> localList)
	{
		FileVersionStruct localVersion;
		HashSet<string> newSet = new HashSet<string>();
		for (int iter = 0; iter < newList.Count; ++iter)
		{
			FileVersionStruct iterNewVersion = newList[iter];
			newSet.Add(iterNewVersion.Name);
			if (localList.TryGetValue(iterNewVersion.Name, out localVersion))
			{
				if (localVersion.Version > iterNewVersion.Version)
				{
					newList[iter] = localVersion;
				}
			}
		}
		//
		foreach(KeyValuePair<string, FileVersionStruct> iter in localList)
		{
			if (!newSet.Contains(iter.Key))
			{
				newList.Add(iter.Value);
			}
		}
	}

	public override void OnCompleted(Int32 failCount)
	{
		if (_writeVersion && failCount <= 0)
		{
			IOAssisstant.WriteToPresistent(IOAssisstant.DataVersionFullFile, IOAssisstant.PrintVersionList(_newVersion, _newVersionList), true);
		}
	}

	Int32 _localVersion;
	Dictionary<string, FileVersionStruct> _localVersionList = new Dictionary<string, FileVersionStruct>();
	Int32 _newVersion;
	List<FileVersionStruct> _newVersionList = new List<FileVersionStruct>();
	bool _writeVersion;
}