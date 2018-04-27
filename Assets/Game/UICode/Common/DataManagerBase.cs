using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class DataManagerBase<T> where T : IRelease,new ()
{
    private static T _Instance;
    public static T GetInstance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new T();
                ClearDataManager.AddDataManager(_Instance);
            }
            return _Instance;
        }
        private set
        {
            _Instance = value;
        }
    }       
    
    public void Reset()
    {
        _Instance.Release();
        _Instance = default(T);
    }
}

public class MyDatatest : DataManagerBase<MyDatatest>, IRelease
{
    private List<int> tempList = new List<int>();
    public void Release()
    {
        tempList.Clear();
    }
}

public class ClearDataManager
{
    private static List<IRelease> managerList = new List<IRelease>();

    public static void AddDataManager(IRelease data)
    {
        managerList.Add(data);
    }

    public static void ClearAllData()
    {
        for (int i = 0; i < managerList.Count; i++)
        {
            managerList[i].Reset();            
        }
        managerList.Clear();
    }
}

public interface IRelease
{
    void Release();
    void Reset();
}
