//----------------------------------------------
//       Custom 
//----------------------------------------------

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIScrollViewEx_Spring))]
public class UIScrollViewEx_SpringEditor : UIScrollViewEditor
{
	protected override bool DrawDragEffect { get { return false; } }

	protected override void DrawPropertyEx()
	{
		if (NGUIEditorTools.DrawHeader("Inertia"))
		{
			NGUIEditorTools.BeginContents();
			NGUIEditorTools.DrawProperty("Inertia Max Speed", serializedObject, "InertiaMaxSpeed");
			NGUIEditorTools.DrawProperty("Inertia Accerlate", serializedObject, "InertiaAccerlate");
			NGUIEditorTools.DrawProperty("Inertia Scale", serializedObject, "InertiaScale");
			NGUIEditorTools.EndContents();
		}
	}
}
