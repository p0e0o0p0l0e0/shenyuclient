using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SerializableDictionary<TKey, TValue>: Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> _keys = new List<TKey>();
    [SerializeField] private List<TValue> _values = new List<TValue>();

    public void OnBeforeSerialize()
    {
        //_keys.Clear();
        //_values.Clear();
        //int count = Mathf.Min(_keys.Count, _values.Count);
        //_keys.Capacity = count;
        //_values.Capacity = count;
        //for (int i = 0; i < count; ++i)
        //{
        //    _keys.Add(_keys[i]);
        //    _values.Add(_values[i]);
        //}
    }
    public void OnAfterDeserialize()
    {
        this.Clear();
        int count = Mathf.Min(_keys.Count, _values.Count);
        for (int i = 0; i < count; ++i)
        {
            this.Add(_keys[i], _values[i]);
        }
    }
}
