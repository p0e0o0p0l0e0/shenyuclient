using System;
using System.Collections.Generic;

public interface ViReceiveDataMemoryObject
{
	void OnCacheAlloc();
	void OnCacheFree();
}

public static class ViReceiveDataCache<T>
	where T : ViReceiveDataMemoryObject, new()
{
	static ViReceiveDataCache()
	{
		ViReceiveDataCacheManager.RegisterClear(Clear);
	}
	public static T Alloc()
	{
		if (_list.Count > 0)
		{
			T obj = _list[_list.Count - 1];
			_list.RemoveAt(_list.Count - 1);
			return obj;
		}
		else
		{
			T newObj = new T();
			newObj.OnCacheAlloc();
			return newObj;          
		}
	}

	public static void Free(T obj)
	{
		_list.Add(obj);
	}

	public static void Clear()
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			_list[iter].OnCacheFree();
		}
		_list.Clear();
	}

	static List<T> _list = new List<T>();
}

public static class ViReceiveDataCacheManager
{
	public static void ClearCache()
	{
		for (int iter = 0; iter < _clearExecList.Count; ++iter)
		{
			ViDelegateAssisstant.Invoke(_clearExecList[iter]);
		}
	}

	public static void RegisterClear(ViDelegateAssisstant.Dele exec)
	{
		_clearExecList.Add(exec);
	}

	static List<ViDelegateAssisstant.Dele> _clearExecList = new List<ViDelegateAssisstant.Dele>();
}