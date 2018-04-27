using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class BirthControllerCheck : EditorWindow
{
	enum InspectType
	{
		BirthController,
		NPCBirthPosition,
	}
	//
	public static GUIStyle FontStyle1 = new GUIStyle();
	public static GUIStyle FontStyle2 = new GUIStyle();
	public static GUIStyle FontStyle3 = new GUIStyle();
	static void InitFontColor()
	{
		FontStyle1.normal.background = null;
		FontStyle1.normal.textColor = new Color(1, 0, 0);  //红色;
		FontStyle1.fontSize = 15;
		FontStyle2.normal.background = null;
		FontStyle2.normal.textColor = new Color(0, 1, 0);  //绿色;
		FontStyle2.fontSize = 15;
		FontStyle3.normal.background = null;
		FontStyle3.normal.textColor = new Color(0, 1, 1); //蓝色;
		FontStyle3.fontSize = 15;
	}
	//
	public static Int32 Count = 0;
	public static Int32 SpaceID = 0;

	[MenuItem("Scene/控制器检查")]
	public static void ShowControllerCheckWindow()
	{
		InitFontColor();
		//
		if (!Application.isPlaying)
		{
			if (EditorUtility.DisplayDialog("游戏尚未启动", "必须先启动游戏", "启动游戏", "取消"))
			{
				EditorApplication.isPlaying = true;
			}
			return;
		}
		//
		EditorWindow.GetWindow(typeof(BirthControllerCheck));
	}

	void OnGUI()
	{
		if (Application.isPlaying)
		{
			GUILayout.BeginHorizontal();
			if (GameSpaceRecordInstance.Instance != null)
			{
				SpaceStruct space = GameSpaceRecordInstance.Instance.Property.Info;
				SpaceID = space.ID;
			}
			GUILayout.Label(SpaceID.ToString());
			//
			if (GUILayout.Button("查看当前地图的控制器"))
			{
				GetCurrentBirthControllerList(SpaceID);
				GetCurrentSpaceInfo();
			}
			//
			GUILayout.EndHorizontal();
			//
			_activedInspectType = (InspectType)GUILayout.Toolbar((int)_activedInspectType, _inspectToolbarStrings);
			switch (_activedInspectType)
			{
				case InspectType.BirthController:
					CreateControllerButton();
					break;
				case InspectType.NPCBirthPosition:
					ShowAllNPCBirthPosition();
					break;
			}
			//
		}
		else
		{
			this.Close();
		}
	}

	void GetCurrentBirthControllerList(Int32 spaceID)
	{
		BirthControllerList.Clear();
		foreach (SpaceBirthControllerStruct birthController in ViSealedDB<SpaceBirthControllerStruct>.Array)
		{
			if (spaceID == birthController.Space)
			{
				BirthControllerList.Add(birthController);
			}
		}
	}

	void CreateControllerButton()
	{
		EditorWindow.GetWindow(typeof(BirthControllerDetails), false, "控制器详情");
		//
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		GUILayout.Label("控制器列表");
		//
		foreach (SpaceBirthControllerStruct birthController in BirthControllerList)
		{
			SpaceBirthControllerState controllerState = GetControllerState(birthController.ID);
			if (GUILayout.Button(birthController.ID.ToString() + " | " + birthController.Name + " | " + birthController.Note + "(" + controllerState + ")"))
			{
				CurrentBirthController = birthController;
				Count++;
			}
		}
		GUILayout.EndScrollView();
	}

	public static SpaceBirthControllerState GetControllerState(Int32 controllerID)
	{
		ReceiveDataSpaceBirthControllerProperty property = null;
		if (GameSpaceRecordInstance.Instance != null &&
			GameSpaceRecordInstance.Instance.Property != null && GameSpaceRecordInstance.Instance.Property.BirthControllerList != null)
		{
			if (GameSpaceRecordInstance.Instance.Property.BirthControllerList.TryGetValue((uint)controllerID, out property))
			{
				return (SpaceBirthControllerState)property.State.Value;
			}
		}
		return SpaceBirthControllerState.SUP;
	}

	void ShowAllNPCBirthPosition()
	{
		GUILayout.Label("地图所有NPC");
		if (CurrentSpaceAllNPC.Count != 0)
		{
			foreach (NPCBirthPositionStruct npcBirthPosition in CurrentSpaceAllNPC)
			{
				_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
				GUILayout.Label("ID: " + npcBirthPosition.ID + " | " + "Name: " + npcBirthPosition.Name + "(是否有寻路: " + HasRoute(npcBirthPosition).ToString() + ")");
				GUILayout.EndScrollView();
			}
		}
	}

	bool HasRoute(NPCBirthPositionStruct npc)
	{
		if (npc.Route != 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

#region Get Event Ralate
	void GetCurrentSpaceInfo()
	{
		CurrentSpaceAllNPC.Clear();
		foreach (NPCBirthPositionStruct npcBirthPosition in ViSealedDB<NPCBirthPositionStruct>.Array)
		{
			if (npcBirthPosition.Space.Data.ID == SpaceID)
			{
				CurrentSpaceAllNPC.Add(npcBirthPosition);
			}
		}
		//
		CurrentSpaceAllObject.Clear();
		foreach (SpaceObjectBirthPositionStruct spaceObjectPosition in ViSealedDB<SpaceObjectBirthPositionStruct>.Array)
		{
			if (spaceObjectPosition.Space.Data.ID == SpaceID)
			{
				CurrentSpaceAllObject.Add(spaceObjectPosition);
			}
		}
		//
		CurrentSpaceAllEvent.Clear();
		foreach (SpaceEventStruct spaceEvent in ViSealedDB<SpaceEventStruct>.Array)
		{
			if (spaceEvent.Space == 0 || spaceEvent.Space.Data.ID == SpaceID)
			{
				CurrentSpaceAllEvent.Add(spaceEvent);
			}
		}
	}
#endregion

	public static SpaceBirthControllerStruct CurrentBirthController = null;
	public static List<SpaceBirthControllerStruct> BirthControllerList = new List<SpaceBirthControllerStruct>();
	public static List<NPCBirthPositionStruct> CurrentSpaceAllNPC = new List<NPCBirthPositionStruct>();
	public static List<SpaceObjectBirthPositionStruct> CurrentSpaceAllObject = new List<SpaceObjectBirthPositionStruct>();
	public static List<SpaceEventStruct> CurrentSpaceAllEvent = new List<SpaceEventStruct>();
	Vector2 _scrollPosition = new Vector2(0, 0);
	InspectType _activedInspectType = InspectType.BirthController;
	//

	string[] _inspectToolbarStrings = { "查看当前地图控制器", "查看当前地图NPC" };
}
