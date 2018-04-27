using System;
using System.Collections.Generic;
using UnityEngine;

public class PersistentWriter
{
	public delegate void DeleLoadCompleteHandle(string name, WWW loader, ref bool saveToPresistent);

	public ViDelegateAssisstant.Dele<PersistentWriter> CompleteCallback;
	public ViDelegateAssisstant.Dele<PersistentWriter, Int32, bool> HeadCallback;
	public bool IsWorking { get { return _loader != null; } }
	public Int32 FailCount { get { return _failCount; } }
	public Int32 TotalSize { get { return _totalSize; } }
	public Int32 CompleteSize { get { return _loadedTotalSizeIncludeCurrent; } }
	public bool LoadFull;

	public virtual void OnCompleted(Int32 failCount) { }

	void UpdateLoadingSize(WWW loader, ref Int32 completeSize)
	{
		Int32 currentWWWCompleteSize = _loadedTotalSizeIncludeCurrent - _loadedTotalSizeExcluedCurrent;
		completeSize += _loader.bytesDownloaded - currentWWWCompleteSize;
		if (!loader.isDone)
		{
			_loadedTotalSizeIncludeCurrent = _loadedTotalSizeExcluedCurrent + _loader.bytesDownloaded;
			return;
		}
		//
		//Debug.Log("AssetBundlePersistentWriter.OnLoaded: " + _loader.url);
		//
		_loadedTotalSizeExcluedCurrent += _loader.bytesDownloaded;
		_loadedTotalSizeIncludeCurrent = _loadedTotalSizeExcluedCurrent;
	}

	public void TickLoad(ref Int32 completeSize)
	{
		if (LoadFull)
		{
			UpdateLoadingSize(_loader, ref completeSize);
		}
		if (!_loader.isDone)
		{
			return;
		}
		//
		//Debug.Log("AssetBundlePersistentWriter.OnLoaded: " + _loader.url);
		//
		bool saveToPresistent = true;
		if (_lastLoadHandle != null)
		{
			DeleLoadCompleteHandle handle = _lastLoadHandle;
			_lastLoadHandle = null;
			handle(_loaderName, _loader, ref saveToPresistent);
		}
		if (string.IsNullOrEmpty(_loader.error))
		{
			++_successCount;
			if (saveToPresistent)
			{
				IOAssisstant.WriteToPresistent(_loaderName, _loader.bytes, false);
			}
			if (_loader.assetBundle != null)
			{
				_loader.assetBundle.Unload(false);
			}
		}
		else
		{
			++_failCount;
		}
		//
		_loader.Dispose();
		_loader = null;
		//
		if (_reserveList.Count > 0)
		{
			LoadPop();
		}
		else
		{
			Debug.Log("AssetBundlePersistentWriter.Complete: SuccessCount=" + _successCount + "/FailCount=" + _failCount);
			//
			OnCompleted(FailCount);
			//
			ViDelegateAssisstant.Invoke(CompleteCallback, this);
		}
	}

	protected void LoadPop()
	{
		if (_reserveList.Count <= 0)
		{
			return;
		}
		//
		Int32 popIdx = _reserveList.Count - 1;
		string res = _reserveList[popIdx].Key;
		_lastLoadHandle = _reserveList[popIdx].Value;
		_reserveList.RemoveAt(popIdx);
		//
		_loaderName = res;
		_loader = new WWW(_url + _loaderName);
	}

	protected void AddLoad(string res, DeleLoadCompleteHandle handle)
	{
		_reserveList.Add(new KeyValuePair<string, DeleLoadCompleteHandle>(res, handle));
	}

	protected void SetTotalSize(int value)
	{
		_totalSize = value;
		ViDelegateAssisstant.Invoke(HeadCallback, this, value, LoadFull);
	}

	protected string _url;
	protected List<KeyValuePair<string, DeleLoadCompleteHandle>> _reserveList = new List<KeyValuePair<string, DeleLoadCompleteHandle>>();
	DeleLoadCompleteHandle _lastLoadHandle;
	Int32 _successCount;
	Int32 _failCount;
	WWW _loader;
	string _loaderName;
	Int32 _totalSize;
	Int32 _loadedTotalSizeExcluedCurrent;
	Int32 _loadedTotalSizeIncludeCurrent;
}
