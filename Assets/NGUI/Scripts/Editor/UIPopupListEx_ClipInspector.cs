//----------------------------------------------
//       Custom 
//----------------------------------------------

#if !UNITY_3_5 && !UNITY_FLASH
#define DYNAMIC_FONT
#endif

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Inspector class used to edit UIPopupLists.
/// </summary>

[CustomEditor(typeof(UIPopupListEx_Clip))]
public class UIPopupListEx_ClipInspector : UIPopupListInspector
{
	UIPopupListEx_Clip popupListClip;

	protected override void OnEnable()
	{
		base.OnEnable();
		popupListClip = target as UIPopupListEx_Clip;
	}

	protected override void DrawEx()
	{
		if (NGUIEditorTools.DrawHeader("Extend"))
		{
			NGUIEditorTools.BeginContents();
			SerializedProperty result = NGUIEditorTools.DrawProperty("Limit Height", serializedObject, "LimitHeight");
			NGUIEditorTools.SetLabelWidth(120f);
			NGUIEditorTools.EndContents();
			//
			if (result.intValue > 0 && NGUIEditorTools.DrawHeader("Scroll Bar Atlas"))
			{
				NGUIEditorTools.BeginContents();
				//
				GUILayout.BeginHorizontal();
				{
					if (NGUIEditorTools.DrawPrefixButton("Atlas"))
						ComponentSelector.Show<UIAtlas>(OnSelectAtlas);
					NGUIEditorTools.DrawProperty("", serializedObject, "ScrollBarAtlas");
				}
				GUILayout.EndHorizontal();
				//
				NGUIEditorTools.DrawPaddedSpriteField("Background (Scroll Bar)", popupListClip.ScrollBarAtlas, popupListClip.ScrollBarBG, OnBackground);
				NGUIEditorTools.DrawPaddedSpriteField("Foreground (Scroll Bar)", popupListClip.ScrollBarAtlas, popupListClip.ScrollBarFG, OnForeground);
				NGUIEditorTools.DrawProperty("ScrollBar Width", serializedObject, "ScrollBarWidth");
				NGUIEditorTools.SetLabelWidth(120f);
				NGUIEditorTools.DrawProperty("FG Padding Left", serializedObject, "ScrollBarFGPaddingLeft");
				NGUIEditorTools.SetLabelWidth(120f);
				NGUIEditorTools.DrawProperty("FG Padding Right", serializedObject, "ScrollBarFGPaddingRight");
				NGUIEditorTools.SetLabelWidth(120f);
				NGUIEditorTools.DrawProperty("FG Padding Top", serializedObject, "ScrollBarFGPaddingTop");
				NGUIEditorTools.SetLabelWidth(120f);
				NGUIEditorTools.DrawProperty("FG Padding Bottom", serializedObject, "ScrollBarFGPaddingBottom");
				NGUIEditorTools.SetLabelWidth(120f);
				//
				EditorGUILayout.Space();
				NGUIEditorTools.EndContents();
			}
		}
	}

	void OnSelectAtlas(Object obj)
	{
		RegisterUndo();
		popupListClip.ScrollBarAtlas = obj as UIAtlas;
		NGUISettings.atlas = popupListClip.ScrollBarAtlas;
	}

	void OnBackground(string spriteName)
	{
		RegisterUndo();
		popupListClip.ScrollBarBG = spriteName;
		Repaint();
	}

	void OnForeground(string spriteName)
	{
		RegisterUndo();
		popupListClip.ScrollBarFG = spriteName;
		Repaint();
	}
}
