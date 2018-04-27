using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FXLODLevel))]
public class FXLODLevelEditor : Editor
{
	SerializedObject SerObj;
	SerializedProperty Level;

	void OnEnable()
	{
		SerObj = new SerializedObject(target);
		Level = SerObj.FindProperty("Level");
	}

	public override void OnInspectorGUI()
	{
		SerObj.Update();
		EditorGUILayout.PropertyField(Level, true);
		SerObj.ApplyModifiedProperties();
	}
}

[CustomEditor(typeof(LODLevel))]
public class LODLevelEditor : Editor
{
	SerializedObject SerObj;
	SerializedProperty Objects;
	SerializedProperty ParticleSystemInfos;
	SerializedProperty DistortObjects;

	void OnEnable()
	{
		SerObj = new SerializedObject(target);
		Objects = SerObj.FindProperty("Objects");
		ParticleSystemInfos = SerObj.FindProperty("ParticleSystemInfos");
		DistortObjects = SerObj.FindProperty("DistortObjects");
	}

	public override void OnInspectorGUI()
	{
		SerObj.Update();
		EditorGUILayout.PropertyField(Objects, true);
		EditorGUILayout.PropertyField(ParticleSystemInfos, true);
		EditorGUILayout.PropertyField(DistortObjects, true);
		SerObj.ApplyModifiedProperties();
	}
}

[CustomEditor(typeof(ParticleSystemBurst))]
public class ParticleSystemBurstEditor : Editor
{
	SerializedObject SerObj;
	SerializedProperty CountPre;

	void OnEnable()
	{
		SerObj = new SerializedObject(target);
		CountPre = SerObj.FindProperty("CountPre");
	}

	public override void OnInspectorGUI()
	{
		SerObj.Update();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(CountPre, true);
		SerObj.ApplyModifiedProperties();
	}
}

[CustomEditor(typeof(GameObjectLevel))]
public class GameObjectLevelEditor : Editor
{
	SerializedObject SerObj;
	SerializedProperty High;
	SerializedProperty Middle;
	SerializedProperty Low;
	SerializedProperty Object;

	void OnEnable()
	{
		SerObj = new SerializedObject(target);
		High = SerObj.FindProperty("High");
		Middle = SerObj.FindProperty("Middle");
		Low = SerObj.FindProperty("Low");
		Object = SerObj.FindProperty("Object");
	}

	public override void OnInspectorGUI()
	{
		SerObj.Update();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(High, true);
		EditorGUILayout.PropertyField(Middle, true);
		EditorGUILayout.PropertyField(Low, true);
		EditorGUILayout.PropertyField(Object, true);
		SerObj.ApplyModifiedProperties();
	}
}

[CustomEditor(typeof(ParticleSystemInfo))]
public class ParticleSystemInfoEditor : Editor
{
	SerializedObject SerObj;
	SerializedProperty High;
	SerializedProperty Middle;
	SerializedProperty Low;
	SerializedProperty ParticleSystemBurstPre;

	void OnEnable()
	{
		SerObj = new SerializedObject(target);
		High = SerObj.FindProperty("High");
		Middle = SerObj.FindProperty("Middle");
		Low = SerObj.FindProperty("Low");
		ParticleSystemBurstPre = SerObj.FindProperty("ParticleSystemBurstPre");
	}

	public override void OnInspectorGUI()
	{
		SerObj.Update();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(High, true);
		EditorGUILayout.PropertyField(Middle, true);
		EditorGUILayout.PropertyField(Low, true);
		EditorGUILayout.PropertyField(ParticleSystemBurstPre, true);
		SerObj.ApplyModifiedProperties();
	}
}

[CustomEditor(typeof(ParticleSystemObject))]
public class ParticleSystemObjectEditor : Editor
{
	SerializedObject SerObj;
	SerializedProperty Rate;
	SerializedProperty Bursts;
	SerializedProperty ParticleSystemData;

	void OnEnable()
	{
		SerObj = new SerializedObject(target);
		Rate = SerObj.FindProperty("Rate");
		Bursts = SerObj.FindProperty("Bursts");
		ParticleSystemData = SerObj.FindProperty("ParticleSystemData");
	}

	public override void OnInspectorGUI()
	{
		SerObj.Update();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(Rate, true);
		EditorGUILayout.PropertyField(Bursts, true);
		EditorGUILayout.PropertyField(ParticleSystemData, true);
		SerObj.ApplyModifiedProperties();
	}
}