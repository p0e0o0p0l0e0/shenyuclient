using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

namespace PhysicalShading
{
	[CustomEditor(typeof(PlanarReflection))]
	public class PlanarReflectionEditor : Editor
	{
		SerializedProperty stencilRef;
		ReorderableList staticAgents;
		SerializedProperty plane;
		SerializedProperty fade;
		SerializedProperty gamma;

		void OnEnable()
		{
			stencilRef = serializedObject.FindProperty("stencilRef");

			staticAgents = new ReorderableList(serializedObject,
				serializedObject.FindProperty("staticAgents"),
				true, true, true, true);

			staticAgents.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				var element = staticAgents.serializedProperty.GetArrayElementAtIndex(index);
				EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
					element, GUIContent.none);
			};

			staticAgents.drawHeaderCallback = (Rect rect) =>
			{
				EditorGUI.LabelField(rect, "Reflection Agents");
			};

			plane = serializedObject.FindProperty("plane");
			fade = serializedObject.FindProperty("fade");
			gamma = serializedObject.FindProperty("gamma");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorGUILayout.PropertyField(stencilRef, new GUIContent("Stencil Reference"));
			staticAgents.DoLayoutList();
			EditorGUILayout.Separator();

			var title = new GUIStyle(GUI.skin.label);
			title.fontStyle = FontStyle.Bold;
			EditorGUILayout.LabelField("Plane: ", title);
			EditorGUILayout.BeginHorizontal();
			GameObject obj = EditorGUILayout.ObjectField(GUIContent.none, null, typeof(GameObject), true) as GameObject;
			if (obj)
			{
				//(target as PlanarReflection).SetPlane(obj.transform);
			}
			EditorGUILayout.PropertyField(plane.FindPropertyRelative("x"), GUIContent.none);
			EditorGUILayout.PropertyField(plane.FindPropertyRelative("y"), GUIContent.none);
			EditorGUILayout.PropertyField(plane.FindPropertyRelative("z"), GUIContent.none);
			EditorGUILayout.PropertyField(plane.FindPropertyRelative("w"), GUIContent.none);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Separator();

			EditorGUILayout.PropertyField(fade);
			EditorGUILayout.PropertyField(gamma);

			serializedObject.ApplyModifiedProperties();
		}
	}
}
