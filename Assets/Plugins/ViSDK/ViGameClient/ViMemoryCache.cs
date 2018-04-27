
//using System;
//using System.Collections.Generic;

//public static class ViPropertyCache<T>
//    where T : ViReceiveProperty, new()
//{
//    public static T Alloc()
//    {
//        if (_list.Count > 0)
//        {
//            T obj = _list[_list.Count - 1];
//            _list.RemoveAt(_list.Count - 1);
//            return obj;
//        }
//        else
//        {
//            return new T();
//        }
//    }

//    public static void Free(T obj)
//    {
//        _list.Add(obj);
//    }

//    public static void Clear()
//    {
//        foreach (T obj in _list)
//        {
//            obj.Clear();
//        }
//        _list.Clear();
//    }

//    static List<T> _list = new List<T>();
//}
