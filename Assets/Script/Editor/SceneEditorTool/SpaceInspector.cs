using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class SpaceScript_Inspector : Editor
{
	int nextID = 0;

	protected void DrawHead(string label, int ID)
	{
		GUILayout.Label(label, "HeaderLabel");
		GUIStyle style = new GUIStyle();
		style.padding = new RectOffset(0, 0, 4, 4);
		GUILayout.BeginHorizontal(style);
		GUILayout.Label("ID: ");
		style = new GUIStyle();
		style.normal.textColor = Color.yellow;
		GUILayout.Label(ID.ToString(), style);
		if (GUILayout.Button("Copy ID"))
		{
			TextEditor editor = new TextEditor();
			editor.text = ID.ToString();
			editor.OnFocus();
			editor.Copy();
		}
		GUILayout.EndHorizontal();
	}

	protected void DrawCopyButton()
	{
		GUILayout.Label("", "HeaderLabel");
		SpaceInspectorAssisstant.Draw("NewID（用于拷贝）", ref nextID);
		if (GUILayout.Button("拷贝 （可在上方输入自定义ID）"))
		{
			OnExecCopy(nextID, target);
		}
	}

	protected abstract void OnExecCopy(int nextID, UnityEngine.Object target);
}

/// ///////////////////////////////////////////////////////////////////////////////////////////////////////
[CustomEditor(typeof(SpaceScript_Route))]
public class SpaceScript_Route_Inspector : SpaceScript_Inspector
{
	public override void OnInspectorGUI()
	{
		SpaceScript_Route dataScript = target as SpaceScript_Route;
		//
		DrawHead("表：SpaceRouteStruct", dataScript.LogicData.ID);
		SpaceInspectorAssisstant.Draw("Name", ref dataScript.LogicData.Name);
		SpaceInspectorAssisstant.Draw("Loop", ref dataScript.LogicData.Loop);
		SpaceInspectorAssisstant.Draw("EndEvent", ref dataScript.LogicData.EndEvent);
		//
		DrawCopyButton();
	}

	protected override void OnExecCopy(int nextID, UnityEngine.Object target)
	{
		SpaceScript_Route dataScript = target as SpaceScript_Route;
		SpaceScript_Route.Clone(dataScript, nextID);
	}
}

[CustomEditor(typeof(SpaceScript_NPCBirthPos))]
public class SpaceScript_NPCBirthPos_Inspector : SpaceScript_Inspector
{
	public override void OnInspectorGUI()
	{
		SpaceScript_NPCBirthPos dataScript = target as SpaceScript_NPCBirthPos;
		//
		DrawHead("表：NPCBirthPositionStruct", dataScript.LogicData.ID);
		SpaceInspectorAssisstant.Draw("Name", ref dataScript.LogicData.Name);
		SpaceInspectorAssisstant.Draw("Space", ref dataScript.LogicData.Space);
		SpaceInspectorAssisstant.Draw("NPC", ref dataScript.LogicData.NPC);
		SpaceInspectorAssisstant.Draw("Route", ref dataScript.LogicData.Route);
		SpaceInspectorAssisstant.Draw("Count", ref dataScript.LogicData.Count);
		SpaceInspectorAssisstant.Draw("RouteClip", ref dataScript.LogicData.RouteClip);
		//
		DrawCopyButton();
	}

	protected override void OnExecCopy(int nextID, UnityEngine.Object target)
	{
		SpaceScript_NPCBirthPos dataScript = target as SpaceScript_NPCBirthPos;
		SpaceScript_NPCBirthPos.Clone(dataScript, nextID);
	}

}
//+------------------------------------------------------------------------------------------------------------------------
[CustomEditor(typeof(SpaceScript_BirthController))]
public class SpaceScript_BirthController_Inspector : SpaceScript_Inspector
{
	bool showBaseInspector = false;
	bool showStartEventInspector = false;
	bool showEndEventInspector = false;
	bool showRandomInspector = false;
	public override void OnInspectorGUI()
	{
		SpaceScript_BirthController dataScript = target as SpaceScript_BirthController;
		GUILayout.Label("表：BirthControllerStruct", "HeaderLabel");
		//Base Attribute

		showBaseInspector = SpaceInspectorAssisstant.BeginFoldOut("Base Attribute", showBaseInspector);
		if (showBaseInspector)
		{
			SpaceInspectorAssisstant.BeginGroup();
			{
				SpaceInspectorAssisstant.Draw("ID(不建议修改)", ref dataScript.controllerData.ID);
				SpaceInspectorAssisstant.Draw("Name", ref dataScript.controllerData.Name);
				SpaceInspectorAssisstant.Draw("State[状态]", ref dataScript.controllerData.State);
				SpaceInspectorAssisstant.Draw("Type[类型]", ref dataScript.controllerData.Type);
			}
			SpaceInspectorAssisstant.EndGroup();
		}

		showStartEventInspector = SpaceInspectorAssisstant.BeginFoldOut("StartEvent", showStartEventInspector);
		if (showStartEventInspector)
		{
			SpaceInspectorAssisstant.BeginGroup();
			{
				SpaceInspectorAssisstant.Draw("StartEvent[0]", ref dataScript.controllerData.StartEvent.Array[0]);
				SpaceInspectorAssisstant.Draw("StartEvent[1]", ref dataScript.controllerData.StartEvent.Array[1]);
				SpaceInspectorAssisstant.Draw("StartEvent[2]", ref dataScript.controllerData.StartEvent.Array[2]);
			}
			SpaceInspectorAssisstant.EndGroup();
		}

		showEndEventInspector = SpaceInspectorAssisstant.BeginFoldOut("EndEvent", showEndEventInspector);
		if (showEndEventInspector)
		{
			SpaceInspectorAssisstant.BeginGroup();
			{
				SpaceInspectorAssisstant.Draw("EndEvent[0]", ref dataScript.controllerData.EndEvent.Array[0].Event);
				SpaceInspectorAssisstant.Draw("EndEvent[1]", ref dataScript.controllerData.EndEvent.Array[1].Event);
				SpaceInspectorAssisstant.Draw("EndEvent[2]", ref dataScript.controllerData.EndEvent.Array[2].Event);
			}
			SpaceInspectorAssisstant.EndGroup();
		}


		showRandomInspector = SpaceInspectorAssisstant.BeginFoldOut("Random", showRandomInspector);
		if (showRandomInspector)
		{
			SpaceInspectorAssisstant.BeginGroup();
			{
				SpaceInspectorAssisstant.Draw("Span[间隔]", ref dataScript.controllerData.Span);
				SpaceInspectorAssisstant.Draw("NPCRandomPosCount[]", ref dataScript.controllerData.NPCRandomPosCount);
				SpaceInspectorAssisstant.Draw("ServantRandomPosCount[]", ref dataScript.controllerData.ServantRandomPosCount);
				SpaceInspectorAssisstant.Draw("ObjectRandomPosCount[]", ref dataScript.controllerData.ObjectRandomPosCount);
				SpaceInspectorAssisstant.Draw("AreaAuraRandomPosCount[]", ref dataScript.controllerData.AreaAuraRandomPosCount);
				SpaceInspectorAssisstant.Draw("NPCMaxCount[]", ref dataScript.controllerData.NPCMaxCount);
				SpaceInspectorAssisstant.Draw("ObjectMaxCount[]", ref dataScript.controllerData.ObjectMaxCount);
				SpaceInspectorAssisstant.Draw("AreaAuraMaxCount[]", ref dataScript.controllerData.AreaAuraMaxCount);
				SpaceInspectorAssisstant.Draw("DieOutBorn[死光再生]", ref dataScript.controllerData.DieOutBorn);
			}
			SpaceInspectorAssisstant.EndGroup();
		}
	}

	protected override void OnExecCopy(int nextID, UnityEngine.Object target)
	{
	}

}
