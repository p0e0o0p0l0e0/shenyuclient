using System;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class VFXShaderInspector : ShaderGUI
{
	public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
	{
		base.OnGUI(materialEditor, properties);
		Material targetMat = materialEditor.target as Material;
		//
		EditorGUILayout.BeginHorizontal();
		MaterialProperty renderQueueProperty = FindProperty("_RenderQueue", properties);
		Int32 renderQueue = (Int32)renderQueueProperty.floatValue;
		if (renderQueue != targetMat.renderQueue)
		{
			targetMat.renderQueue = renderQueue;
		}
		EditorGUILayout.EndHorizontal();
	}
}
