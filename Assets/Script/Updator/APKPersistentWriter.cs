using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class APKPersistentWriter : PersistentWriter
{
	public void Start(string url, bool onlyLoadHead)
	{
		string apkVersion = ApplicationPlatform.MaxVersion(IOAssisstant.LocalVersion(Application.version), Application.version);
		Start(url, onlyLoadHead, apkVersion);
	}

	public void Start(string url, bool onlyLoadHead, string localVersion)
	{
		Debug.Log("APKPersistentWriter.Start(" + url + ", " + localVersion + ")");
		//
		_url = url;
		_localVersion = localVersion;
		LoadFull = !onlyLoadHead;
		//
		AddLoad(IOAssisstant.APKVersionFile, this.OnVersionLoaded);
		//
		LoadPop();
	}

	void OnVersionLoaded(string name, WWW loader, ref bool saveToPresistent)
	{
		saveToPresistent = false;
		//
		if (!string.IsNullOrEmpty(loader.error))
		{
			Debug.Log("APKPersistentWriter.OnVersionLoaded Fail");
			return;
		}
		//
		string versionStr = loader.text;
		Debug.Log("APKPersistentWriter.OnVersionLoaded.VersionStr=" + versionStr + "/LocalVersion=" + _localVersion);
		string version = StandardAssisstant.GetStrValue(versionStr, "Version=");
		if (ApplicationPlatform.VersionUpThan(version, _localVersion))
		{
			_localVersion = version;
			SetTotalSize(Int32.Parse(StandardAssisstant.GetStrValue(versionStr, "Size=")));
			if (LoadFull)
			{
				AddLoad(IOAssisstant.APKFile, this.OnAPKLoaded);
				_writeVersion = true;
				IOAssisstant.DelPresistentFile(IOAssisstant.APKVersionFile);
			}
		}
		else
		{
			SetTotalSize(0);
		}
	}

	void OnAPKLoaded(string name, WWW loader, ref bool saveToPresistent)
	{
		saveToPresistent = false;
		//
		if (!string.IsNullOrEmpty(loader.error))
		{
			Debug.Log("APKPersistentWriter.OnAPKLoaded Fail");
			return;
		}
		//
		Debug.Log("APKPersistentWriter.OnAPKLoaded.NewVersion=" + _localVersion);
		//
		IOAssisstant.WriteToPresistent(IOAssisstant.APKFile, loader.bytes, false);
	}

	public override void OnCompleted(Int32 failCount)
	{
		if (_writeVersion && failCount <= 0)
		{
			IOAssisstant.WriteToPresistent(IOAssisstant.APKVersionFile, _localVersion, true);
		}
	}

	string _localVersion;
	bool _writeVersion;
}