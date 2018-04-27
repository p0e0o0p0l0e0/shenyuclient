using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(AnimationControllerExProperty))]
public class AnimationControllerExEditor : Editor
{
	SerializedObject serObj;
	SerializedProperty AnimationClips;

	void OnEnable()
	{
		serObj = new SerializedObject(target);
		AnimationClips = serObj.FindProperty("AnimationClips");
	}

	public override void OnInspectorGUI()
	{
		serObj.Update();
		EditorGUILayout.PropertyField(AnimationClips, true);
		serObj.ApplyModifiedProperties();
	}
}
