using UnityEditor;
using UnityEngine;

namespace PhysicalShading
{
    [CustomEditor(typeof(RenderPipeline))]
    class RenderPipelineEditor : Editor
    {
        SerializedProperty framerate;

        SerializedProperty postFX;
        SerializedProperty resolution;
		SerializedProperty msaa;
#if UNITY_STANDALONE
		SerializedProperty ssaa;
#endif

		SerializedProperty enableHDR;
        SerializedProperty enableBloom;
		SerializedProperty highQuality;

		SerializedProperty enablePlanarFX;
		SerializedProperty msaaPlanarRT;
		SerializedProperty blurPlanarFX;

		void OnEnable()
        {
            framerate = serializedObject.FindProperty("framerate");

            postFX = serializedObject.FindProperty("postFX");
            resolution = serializedObject.FindProperty("resolution");
			msaa = serializedObject.FindProperty("msaa");
#if UNITY_STANDALONE
			ssaa = serializedObject.FindProperty("ssaa");
#endif
			enableHDR = serializedObject.FindProperty("enableHDR");
			enableBloom = serializedObject.FindProperty("enableBloom");
			highQuality = serializedObject.FindProperty("highQuality");

			enablePlanarFX = serializedObject.FindProperty("enablePlanarFX");
			msaaPlanarRT = serializedObject.FindProperty("msaaPlanarRT");
			blurPlanarFX = serializedObject.FindProperty("blurPlanarFX");
		}

        public override void OnInspectorGUI()
        {
			serializedObject.Update();

            EditorGUILayout.PropertyField(framerate);
            EditorGUILayout.Separator();

            EditorGUILayout.PropertyField(postFX, new GUIContent("PostFX"));
            if (postFX.boolValue)
            {
                EditorGUILayout.PropertyField(resolution);
				EditorGUILayout.PropertyField(msaa, new GUIContent("MSAA"));
#if UNITY_STANDALONE
				EditorGUILayout.PropertyField(ssaa, new GUIContent("SSAA"));
#endif
				EditorGUILayout.PropertyField(enableHDR);
				if (!enableHDR.boolValue)
					EditorGUILayout.PropertyField(enableBloom);
				if (enableHDR.boolValue || enableBloom.boolValue)
				{
					EditorGUILayout.PropertyField(highQuality, new GUIContent("High Quality Bloom"));
				}
			}

			EditorGUILayout.PropertyField(enablePlanarFX, new GUIContent("Enable PlanarFX"));
			if (enablePlanarFX.boolValue)
			{
				EditorGUILayout.PropertyField(msaaPlanarRT);
				EditorGUILayout.PropertyField(blurPlanarFX);
			}

			serializedObject.ApplyModifiedProperties();
        }
    }
}
