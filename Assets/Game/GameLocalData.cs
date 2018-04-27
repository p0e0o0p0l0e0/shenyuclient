using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLocalData
{
    public static string LocalServerIdStr = "";
    public static string CurrentRoleIdStr = "";
    public static void Save(string key ,string val)
    {
        key += (LocalServerIdStr + CurrentRoleIdStr);
        PlayerPrefs.SetString(key, val);
    }
    public static string Load(string key)
    {
        key += (LocalServerIdStr + CurrentRoleIdStr);
        return PlayerPrefs.GetString(key);
    }
}
