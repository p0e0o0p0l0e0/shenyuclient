using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolManager<TKey, TValue> : IDisposable where TValue: PoolElement<TKey>, new()
{

    private Dictionary<TKey, List<TValue>> _pool = new Dictionary<TKey, List<TValue>>();

    public bool Spwan(TKey key , out TValue value)
    {
        List<TValue> list = null;
        value = default(TValue);
        bool isNeedCreate = false;

        if (_pool.TryGetValue(key, out list))
        {
            TValue lastElement = list[list.Count - 1];
            if (lastElement.IsClose())
            {
                value = lastElement;
                list.Remove(lastElement);
                list.Insert(0, lastElement);
                isNeedCreate = false;
            }
            else
            {
                isNeedCreate = true;
            }
        }
        else
        {
            list = new List<TValue>();
            _pool.Add(key, list);
            isNeedCreate = true;
        }
        if (isNeedCreate)
        {
            value = new TValue();
            value.KeyType = key;
            list.Add(value);
        }
        value.Open();
        return isNeedCreate;
    }
    public void Close(TKey key, TValue value)
    {
        if (_pool.ContainsKey(key))
        {
            List<TValue> list = _pool[key];
            value.Close();
            list.Remove(value);
            list.Add(value);
        }
    }
    public int GetPoolCount(TKey key)
    {
        if (_pool.ContainsKey(key))
            return _pool[key].Count;
        return 0;
    }
    public TValue GetElement(TKey key, int index)
    {
        if (_pool.ContainsKey(key) && index < _pool[key].Count)
            return _pool[key][index];
        return default(TValue);
    }
    public void Dispose()
    {
        foreach (KeyValuePair<TKey, List<TValue>> kvp in _pool)
        {
            for(int i = 0; i < kvp.Value.Count; ++i)
                kvp.Value[i].Dispose();
        }           
        _pool.Clear();
    }
}

public class PoolManager<TValue> : IDisposable where TValue : PoolElement, new()
{

    private List<TValue> _pool = new List<TValue>();

    public bool Spwan(out TValue value)
    {
        value = default(TValue);
        bool isNeedCreate = false;
        if (_pool.Count > 0)
        {
            TValue lastElement = _pool[_pool.Count - 1];
            if (lastElement.IsClose())
            {
                value = lastElement;
                _pool.Remove(lastElement);
                _pool.Insert(0, lastElement);
                isNeedCreate = false;
            }
            else
            {
                isNeedCreate = true;
                value = new TValue();
                _pool.Add(value);
            }
        }
        else
        {
            isNeedCreate = true;
            value = new TValue();
            _pool.Add(value);
        }

        value.Open();
        return isNeedCreate;
    }
    public void Close(TValue value)
    {
        if (_pool.Contains(value))
        {
            value.Close();
            _pool.Remove(value);
            _pool.Add(value);
        }
    }
    public int GetPoolCount()
    {
         return _pool.Count;
    }
    public TValue GetElement(int index)
    {
        if (index < _pool.Count)
            return _pool[index];
        return default(TValue);
    }
    public void Dispose()
    {
        for (int i = 0; i < _pool.Count; ++i)
            _pool[i].Dispose();
        _pool.Clear();
        _pool = null;
    }
}