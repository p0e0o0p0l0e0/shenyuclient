using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(FXDelayGroupManager))]
public class FXDelayGroupManagerEditor : Editor
{
	SerializedObject serObj;
	SerializedProperty delayStructs;

	void OnEnable()
	{
		serObj = new SerializedObject(target);
		delayStructs = serObj.FindProperty("DelayStructs");
	}

	public override void OnInspectorGUI()
	{
		serObj.Update();
		EditorGUILayout.PropertyField(delayStructs, true);
		serObj.ApplyModifiedProperties();
	}
}
