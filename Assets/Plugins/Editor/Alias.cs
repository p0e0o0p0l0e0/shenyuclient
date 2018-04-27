using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;
using System.Text;

public static class Alias
{
	public static void Start()
	{
		XmlDocument xml = new XmlDocument();
		xml.Load("./Assets/Script/Editor/SceneEditorTool/Alias.xml");
		if (xml["root"]["Used"].InnerText == "false")
		{
			return;
		}

        _names.Clear();
        _nameMerge.Clear();

        XmlNodeList nodeList = xml["root"].SelectNodes("Element");
		foreach (XmlNode node in nodeList)
		{
			Parse(node);
		}

	}
	public static string Get(string oldName)
	{
		string newName;
		if (_names.TryGetValue(oldName.ToLower(), out newName))
		{
			return newName;
		}
		else
		{
			return oldName;
		}
	}
	public static string GetMergeStr(string key, string type)
	{
		string newName;
		StringBuilder tempBuild = new StringBuilder(key);
		tempBuild.Append(type);
		if (_nameMerge.TryGetValue(tempBuild.ToString(), out newName))
		{
			return newName;
		}
		else
		{
			StringBuilder strName = new StringBuilder();
			strName.Append(Alias.Get(key));
			strName.Append("[");
			strName.Append(key);
			strName.Append("] ");
			strName.Append(type);
			_nameMerge.Add(tempBuild.ToString(), strName.ToString());
			return strName.ToString();
		}
	}
	public static string GetMergeStr(string key, string viType, string genericTypeName)
	{
		string newName;
		StringBuilder tempBuild = new StringBuilder(key);
		tempBuild.Append(viType);
		if (_nameMerge.TryGetValue(tempBuild.ToString(), out newName))
		{
			return newName;
		}
		else
		{
			StringBuilder strName = new StringBuilder();
			strName.Append(Alias.Get(key));
			strName.Append("[");
			strName.Append(key);
			strName.Append("] ");
			strName.Append(viType);
			strName.Append("<");
			strName.Append(genericTypeName);
			strName.Append(">");
			_nameMerge.Add(tempBuild.ToString(), strName.ToString());
			return strName.ToString();
		}
	}
	static void Parse(XmlNode node)
	{
		string oldName = node["Old"].InnerText.ToLower();
		string newName = node["New"].InnerText;
		if (_names.ContainsKey(oldName))
		{
			//Debug.Assert(false);
			_names[oldName] = _names[oldName] + " / " + newName;
		}
		else
		{
			_names[oldName] = newName;
		}
	}

	static bool TryGet(string oldName, out string newName)
	{
		return _names.TryGetValue(oldName, out newName);
	}

	static Dictionary<string, string> _names = new Dictionary<string, string>();
	static Dictionary<string, string> _nameMerge = new Dictionary<string, string>();

}