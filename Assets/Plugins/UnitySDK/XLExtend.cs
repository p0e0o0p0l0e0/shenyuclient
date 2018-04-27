using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// 扩展方法
/// </summary>
public static class XLExtend
{
    public static bool Contants(this int[] Arr, long id)
    {
        bool res = false;
        for (int i = 0; i < Arr.Length; i++)
        {
            if (Arr[i] == id)
            {
                res = true;
                break;
            }
        }
        return res;
    }
    /// <summary>
    /// 设置子物体的layer
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="layer"></param>
    public static void SetModelAndChildrenLayer(this GameObject parent, string layer)
    {
        parent.layer = LayerMask.NameToLayer(layer);
        Transform[] children = parent.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            Transform child = children[i];
            child.gameObject.layer = LayerMask.NameToLayer(layer);
        }
    }
    

    public static void SetModelAndChildrenLayer(this GameObject parent,int layer)
    {
        parent.layer = layer;
        Transform[] children = parent.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            Transform child = children[i];
            child.gameObject.layer = layer;
        }
    }

    /// <summary>
    /// 转换为中文计量单位 万，亿
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string ToCHS(this int num)
    {
        return SetCHS(num);
    }
    /// <summary>
    /// 转换为中文计量单位 万，亿
    /// </summary>
    /// <param name="num"></param>  
    /// <returns></returns>
    public static string ToCHS(this long num)
    {
        return SetCHS(num);
    }
    public static string ToCHS(this short num)
    {
        return SetCHS(num);
    }
    private static string SetCHS(long num)
    {
        string result;
        if (num >= 10000 && num < 100000000)
        {
            result = string.Format("{0}{1}", (num / 10000f).ToString("f1"), "万");
        }
        else if (num >= 100000000)
        {
            result = string.Format("{0}{1}", (num / 100000000f).ToString("f1"), "亿");
        }
        else
        {
            result = num.ToString();
        }
        if (result.Contains(".0"))
            result = result.Replace(".0", "");
        return result;
    }

    /// <summary>
    /// UI相关克隆,参照NGUITOOLS
    /// cheng
    /// </summary>
    public static GameObject Clone(this GameObject prefab, Transform parent)
    {
        return SetClone(prefab, parent);
    }
    /// <summary>
    /// UI相关克隆,参照NGUITOOLS
    /// cheng
    /// </summary>
    public static GameObject Clone(this Transform prefab, Transform parent)
    {
        return SetClone(prefab.gameObject, parent);
    }

    private static GameObject SetClone(GameObject prefab, Transform parent)
    {
        GameObject go = GameObject.Instantiate(prefab.gameObject) as GameObject;
        if (go != null && parent != null)
        {
            Transform t = go.transform;
            t.parent = parent;
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            go.layer = parent.gameObject.layer;
        }
        return go;
    }

    public static void SetParentAndReset(this Transform go, Transform parent)
    {
        go.SetParent(parent);
        go.localPosition = Vector3.zero;
        go.localRotation = Quaternion.Euler(Vector3.zero);
        go.localScale = Vector3.one;
    }

    /// <summary>
    /// 是否是无效的配置字符串
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsInvalidConfig(this string text)
    {
        return string.IsNullOrEmpty(text) || text == "-1";
    }

    public static bool Usable(this string str)
    {
        return !string.IsNullOrEmpty(str);
    }

    public static bool Null(this object obj)
    {
        return obj == null;
    }

    public static bool NotNull(this object obj)
    {
        return obj != null;
    }

    public static bool Null(this Object obj)
    {
        return obj == null || obj.name.Equals("null");
    }
    public static bool NotNull(this Object obj)
    {
        return obj != null && !obj.name.Equals("null");
    }

    /// <summary>
    /// 判断int值是否有效  <=0为无效数据
    /// </summary>
    public static bool InValid(this int num)
    {
        return num <= 0;
    }

    public static void Do(this Action action)
    {
        if (action.NotNull())
            action();
    }

    //配表里的int转成bool
    public static bool ConfigTrue(this int i)
    {
        return i == 1;
    }
    
    #region 扩展string

    //判断字符串是否是纯数字
    public static bool IsNum(this string str)
    {
        Regex objNotNumberPattern = new Regex(@"[0-9.-]");
        var result = objNotNumberPattern.Matches(str, 0);
        return result.Count == str.Length;
    }

    public static int ToInt(this string str)
    {
        if (str.IsNum())
            return int.Parse(str);
        return 0;
    }

    public static long ToLong(this string str)
    {
        if (str.IsNum())
            return long.Parse(str);
        return 0;
    }

    public static string ToNodePath(this string str, string node)
    {
        if (str.Usable())
            //            return string.Format("{0}/{1}", str, node);
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            sb.Append("/");
            sb.Append(node);
            return sb.ToString();
        }
        return node;
    }
    
    public static string ToUnityColor(this string str,string color)
    {
        return string.Format("<color={1}>{0}</color>", str, color);
    }

    #endregion

    #region 扩展list
    public static bool Useable<T>(this List<T> list)
    {
        return list != null && list.Count > 0;
    }

    public static void SmartAdd<T>(this List<T> list, T val)
    {
        if (list.Null())
            list = new List<T>();
        if (!list.Contains(val))
            list.Add(val);
    }
    public static void SmartRemove<T>(this List<T> list, T val)
    {
        if (list.Null())
        {
            Debug.LogError("列表为空");
            return;
        }
        if (list.Contains(val))
            list.Remove(val);
    }
    #endregion 扩展list

    #region 扩展字典
    public static bool Useable<K, V>(this Dictionary<K, V> list)
    {
        return list != null && list.Count > 0;
    }

    public static void SmartAdd<K, V>(this Dictionary<K, V> dic, K key, V value)
    {
        if (dic.Null())
            dic = new Dictionary<K, V>();
        if (key.Null() || value.Null())
            return;
        if (!dic.ContainsKey(key))
            dic.Add(key, value);
        else
            dic[key] = value;
    }
    #endregion 扩展字典

    #region transform

    public static void SetLocalPosZ(this Transform trs,float z)
    {
        trs.localPosition = new Vector3(trs.localPosition.x,trs.localPosition.y,z);
    }

    #endregion transform

    public const string ColorRed = "#ff433e";
    public const string ColorWhite = "#ffffff";
}
