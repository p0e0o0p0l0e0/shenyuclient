using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

public class SpaceInspectorAssisstant
{
	public static void BeginGroup(int padding = 0)
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(padding);
		EditorGUILayout.BeginHorizontal("As TextArea", GUILayout.MinHeight(10f));
		GUILayout.BeginVertical();
		GUILayout.Space(2f);
	}

	public static void EndGroup(bool endSpace = true)
	{
		GUILayout.Space(3f);
		GUILayout.EndVertical();
		EditorGUILayout.EndHorizontal();
		GUILayout.Space(3f);
		GUILayout.EndHorizontal();

		if (endSpace)
		{
			GUILayout.Space(10f);
		}
	}

	public static bool BeginFoldOut(string text, bool foldOut, bool endSpace = true)
	{
		text = "<b><size=11>" + text + "</size></b>";
		if (foldOut)
		{
			text = "\u25BC " + text;
		}
		else
		{
			text = "\u25BA " + text;
		}

		if (!GUILayout.Toggle(true, text, "dragtab"))
		{
			foldOut = !foldOut;
		}

		if (!foldOut && endSpace) GUILayout.Space(5f);

		return foldOut;
	}

	public static bool Draw(string label, ref int oldValue)
	{
		int value = EditorGUILayout.IntField(label, oldValue);
		if (value != oldValue)
		{
			oldValue = value;
			return true;
		}
		else
		{
			return false;
		}
	}

	public static bool Draw(string label, ref string oldValue)
	{
		string value = EditorGUILayout.TextField(label, oldValue);
		if (value != oldValue)
		{
			oldValue = value;
			return true;
		}
		else
		{
			return false;
		}
	}

	public static bool Draw(string label, ref ViLazyString oldValue)
	{
		string value = EditorGUILayout.TextField(label, oldValue.Value);
		if (value != oldValue)
		{
			oldValue.SetValue(value);
			return true;
		}
		else
		{
			return false;
		}
	}

	public static bool Draw<T>(string label, ref ViForeignKey<T> oldValue)
		where T : ViSealedData, new()
	{
		Dictionary<int, string> optionsDict = new Dictionary<int, string>();
		GetPopupDataDict<T>(optionsDict);
		int newValue = EditorGUILayout.IntPopup(label, oldValue.Value, optionsDict.Values.ToArray(), optionsDict.Keys.ToArray());
		if (newValue != oldValue.Value)
		{
			oldValue = new ViForeignKey<T>(newValue);
			return true;
		}
		else
		{
			return false;
		}
	}

	public static bool Draw<T>(string label, ref ViForeignKeyStruct<T> oldValue)
	where T : ViSealedData, new()
	{
		Dictionary<int, string> optionsDict = new Dictionary<int, string>();
		GetPopupDataDict<T>(optionsDict);
		int newValue = EditorGUILayout.IntPopup(label, oldValue.Value, optionsDict.Values.ToArray(), optionsDict.Keys.ToArray());
		if (newValue != oldValue.Value)
		{
			ViForeignKeyStruct<T> value = new ViForeignKeyStruct<T>();
			value.Set(newValue);
			oldValue = value;
			return true;
		}
		else
		{
			return false;
		}
	}

	static void GetPopupDataDict<T>(Dictionary<int, string> result)
		where T : ViSealedData, new()
	{
		if (result == null)
		{
			result = new Dictionary<int, string>();
		}
		//
		if (ViSealedDB<T>.IsLoaded)
		{
			foreach (KeyValuePair<int, T> pair in ViSealedDB<T>.Dict)
			{
				string valueStr = pair.Key.ToString() + " | " + pair.Value.Name;
				result[pair.Key] = valueStr;
			}
		}
	}


	public static bool Draw<T>(string label, ref ViEnum32<T> oldValue)
	{
		int newValue = EditorGUILayout.IntPopup(label, oldValue.Value, Enum.GetNames(typeof(T)), (int[])Enum.GetValues(typeof(T)));
		if (newValue != oldValue.Value)
		{
			oldValue = new ViEnum32<T>(newValue);
			return true;
		}
		else
		{
			return false;
		}
	}
}
