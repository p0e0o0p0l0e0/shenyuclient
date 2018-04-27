using System;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public static class IconDataManager
{
	//+++++++++++++++++++++++++++++++++++
	public const string PATTERN = "////|\\\\";
	//public const string GRAY_PREFIX = "_Gray";
	//public const string TINT_PREFIX = "_Tint";
    const string UIFLAG = "UI";
    const string ATLAS_PREFIX = "Atlas";

    //++++++++++++++++++++

	public static IconData GetIcon(string atlas, string iconName)
	{
		IconData icon =  new IconData(atlas, iconName);
		return icon;
	}

	public static IconData GetIcon(string iconPath)
	{
        return GetAtlasIcon(iconPath);
    }
	//public static IconData GetIcon(string iconPath, bool greyIcon)
	//{
	//	string atlasTail = greyIcon ? GRAY_PREFIX : string.Empty;
	//	//
	//	return GetAtlasIcon(iconPath, atlasTail);
	//}
	public static IconData GetTintIcon(string iconPath)
	{
		return GetAtlasIcon(iconPath);
	}

	static IconData GetAtlasIcon(string iconPath)
	{
		if (string.IsNullOrEmpty(iconPath))
		{
			return IconData.Empty;
		}
		//
		string atlas = string.Empty;
		string icon = string.Empty;
		if (ParseIconPath(iconPath, out atlas, out icon))
		{
			atlas += "";
		}
		else
		{
			if (Application.isEditor)
			{
				ViDebuger.Warning("iconPath configure error: " + iconPath);
			}
		}
		//
		return GetIcon(atlas, icon);
	}

	public static bool ParseIconPath(string path, out string altas, out string icon)
	{
		string[] collections = _GetAtlasInfo(path);
		if (collections != null && collections.Length >= 2)
		{
			altas = collections[0];
			icon = collections[1];
			return true;
		}
		else
		{
			altas = string.Empty;
			icon = string.Empty;
			return false;
		}
	}
	static string[] _GetAtlasInfo(string iconPath)
	{
		string[] collections = null;
		if (_atlasCacheMap.TryGetValue(iconPath, out collections))
		{
			return collections;
		}
		Regex reg = new Regex(PATTERN);
		collections = reg.Replace(iconPath, "/").Split('/');
		_atlasCacheMap[iconPath] = collections;
		return collections;
	}

	public static void ClearAtlasCacheMap()
	{
		_atlasCacheMap.Clear();
	}

	static Dictionary<string, string[]> _atlasCacheMap = new Dictionary<string, string[]>();


}
