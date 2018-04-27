using System;
using System.Collections.Generic;


public static class WordFilterInstance
{
	public static ViWordFilter Instance { get { return _instance; } }
	public static void Start()
	{
		int maxLen = 0;
		List<ForbidedStringStruct> infoList = ViSealedDB<ForbidedStringStruct>.Array;
		for (int iter = 0; iter < infoList.Count; ++iter)
		{
			ForbidedStringStruct iterInfo = infoList[iter];
			maxLen = Math.Max(iterInfo.Name.Length, maxLen);
		}
		_instance.SetMaxLen(maxLen);
		string[] replaceList = new string[maxLen + 1];
		for (int iter = 0; iter < maxLen + 1; ++iter)
		{
			replaceList[iter] = ReplaceStr(iter);
		}
		for (int iter = 0; iter < infoList.Count; ++iter)
		{
			ForbidedStringStruct iterInfo = infoList[iter];
			string word = iterInfo.Name;
			if (word.Length > 0)
			{
				_instance.AddWord(word, replaceList[word.Length]);
			}
		}
		//
		ViSealedDB<ForbidedStringStruct>.Clear();
	}

	static string ReplaceStr(int len)
	{
		if (len == 0)
		{
			return "";
		}
		string str = "";
		for (int iter = 0; iter < len; ++iter)
		{
			str += "*";
		}
		return str;
	}
	static ViWordFilter _instance = new ViWordFilter();
}