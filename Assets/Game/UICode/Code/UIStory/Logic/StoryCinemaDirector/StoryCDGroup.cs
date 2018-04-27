using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class StoryCDGroup : MonoBehaviour
{
    [HideInInspector]
    public List<StoryCDItem> ItemList = new List<StoryCDItem>();

    public virtual void Init()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            if (ItemList[i] == null)
            {
                continue;
            }
            ItemList[i].Init();
        }
    }

    public virtual void Clear()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            if (ItemList[i] == null)
            {
                continue;
            }
            ItemList[i].Clear();
        }
        ItemList.Clear();
    }

    protected virtual void Operate<T>(T t, object obj = null)
    {

    }

    public T[] GetArray<T>(ref List<T> list)
    {
        list.Clear();
        T[] array = GetComponentsInChildren<T>();
        for (int j = 0; j < array.Length; j++)
        {
            list.Add(array[j]);
        }
        return list.ToArray();
    }

    public void Add<T>(ref List<StoryCDItem> list,string name,object obj = null) where T : StoryCDItem
    {
        GameObject newGameObj = new GameObject(name + "_" + (gameObject.transform.childCount));
        newGameObj.transform.SetParent(gameObject.transform);
        T t = newGameObj.GetComponent<T>();
        if (t == null)
            t = newGameObj.AddComponent<T>();
        Operate(t,obj);
        Add(ref list, t);
    }

    protected void Add<T>(ref List<T> list, T t)
    {
        list.Add(t);
    }

}
