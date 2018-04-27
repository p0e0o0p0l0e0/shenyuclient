using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class BirthControllerDetails : BirthControllerCheck
{
	enum InspectType1
	{
		BirthControllerDetail,
		SpaceDetail,
	}

	void OnGUI()
	{
		if (Application.isPlaying)
		{
			_activedInspectType1 = (InspectType1)GUILayout.Toolbar((int)_activedInspectType1, _inspectToolbarStrings1);
			switch (_activedInspectType1)
			{
				case InspectType1.BirthControllerDetail:
					ShowCurrentControllerDetail(CurrentBirthController);
					break;
				case InspectType1.SpaceDetail:
					ShowCurrentSpaceDetail(SpaceID);
					break;
			}
		}
	}

	void ShowCurrentControllerDetail(SpaceBirthControllerStruct birthController)
	{
		GUILayout.BeginVertical();
		if (birthController != null)
		{
			SpaceBirthControllerState controllerState = GetControllerState(birthController.ID);
			//
			GUILayout.Label("ID: " + birthController.ID + " | " + "名字: " + birthController.Name + " | " + "Note: " + birthController.Note + " | " + " 地图: " + SpaceID, FontStyle1);
			//
			if (birthController.Count != 0)
			{
				Int32 controllerCount = birthController.Count;
				if (controllerState == SpaceBirthControllerState.SUP || controllerState == SpaceBirthControllerState.WAITING)
				{
					GUILayout.Label("状态:" + controllerState + " | " + "数量: " + controllerCount, FontStyle1);
				}
				else if (controllerState == SpaceBirthControllerState.DIE_OUT)
				{
					GUILayout.Label("状态:" + controllerState + " | " + "数量: " + controllerCount, FontStyle3);
				}
				else
				{
					GUILayout.Label("状态:" + controllerState + " | " + "数量: " + controllerCount, FontStyle2);
				}
			}
			else
			{
				GUILayout.Label("状态:" + controllerState + " | " + "数量: " + " 无限", FontStyle1);
			}
			//
			GUILayout.Label("-------------------------------------------------------------------");
			DisplayControlerStartTime(birthController);
			GUILayout.Label("-------------------------------------------------------------------");
			GetRelateNPCOrObject(birthController.ID);
			GUILayout.Label("-------------------------------------------------------------------");
			GetPreControllerCondition(birthController);
			GUILayout.Label("-------------------------------------------------------------------");
			ShowEventSender();
			GUILayout.Label("-------------------------------------------------------------------");
			ShowEventReceiver();
			GUILayout.Label("-------------------------------------------------------------------");
			//
			GUILayout.Label(Count.ToString());
		}
		GUILayout.EndVertical();
	}

	void DisplayControlerStartTime(SpaceBirthControllerStruct birthController)
	{
		float startTime = 0.0f;
		float spanTime = 0.0f;
		string info = "";
		if (birthController.StartTime != 0)
		{
			startTime = birthController.StartTime;
			startTime *= 0.01f;
			info = "延迟开始时间: " + startTime + "秒";
		}
		if (birthController.Span != 0)
		{
			spanTime = birthController.Span * 0.01f;
			info += " | 刷新时间: " + spanTime + "秒";
		}
		if (birthController.AddAura.PData != null)
		{
			if (birthController.AddAura.PData.ID != 0)
			{
				info += " | 初始光环: " + birthController.AddAura.PData.ID + "(" + birthController.AddAura.PData.Name + ")";
			}
		}
		GUILayout.Label(info);
	}

	void GetRelateNPCOrObject(Int32 controllerID)
	{
		_RelateNpcBirthList.Clear();
		foreach (NPCBirthPositionStruct npcBirthPos in ViSealedDB<NPCBirthPositionStruct>.Array)
		{
			if (controllerID == npcBirthPos.Controller.Data.ID)
			{
				GUILayout.Label("NPCBirthPosition相关联:", FontStyle2);
				//
				_RelateNpcBirthList.Add(npcBirthPos);
				//
				GUILayout.Label("ID: " + npcBirthPos.ID + " | " + "Name: " + npcBirthPos.Name);
			}
		}
		if (_RelateNpcBirthList.Count == 0)
		{
			GUILayout.Label("没有找到相关联的NPC");
		}
		//
		GUILayout.Label("-------------------------------------------------------------------");
		//
		_RelateSpaceObjectList.Clear();
		foreach (SpaceObjectBirthPositionStruct spaceObjectPos in ViSealedDB<SpaceObjectBirthPositionStruct>.Array)
		{
			if (controllerID == spaceObjectPos.Controller.Data.ID)
			{
				GUILayout.Label("SpaceObjectBirthPosition相关联:", FontStyle2);
				_RelateSpaceObjectList.Add(spaceObjectPos);
				//
				GUILayout.Label("ID: " + spaceObjectPos.ID + " | " + "Name: " + spaceObjectPos.Name);
			}
		}
		if (_RelateSpaceObjectList.Count == 0)
		{
			GUILayout.Label("没有找到相关联的SpaceObject");
		}
	}

	void GetPreControllerCondition(SpaceBirthControllerStruct birthController)
	{
		_preControllerConditionList.Clear();
		foreach (SpaceBirthControllerStruct controller in birthController.PreCondition.Array)
		{
			if (controller == null)
			{
				continue;
			}
			_preControllerConditionList.Add(controller);
			//
			GUILayout.Label("前提状态: " + controller.ID + "(" + GetControllerState(controller.ID) + ")");
			if (controller.Count == 0)
			{
				GUILayout.Label("注意: " + controller.ID + "为无限控制器", FontStyle1);
			}
		}
		//
		if (_preControllerConditionList.Count == 0)
		{
			GUILayout.Label("前提状态: 无");
		}
	}

	void ShowEventSender()
	{
		SpaceBirthControllerStruct controller = CurrentBirthController;
		for (int iter = 0; iter < controller.StartEventor.Event.Length; iter++ )
		{
			SpaceEventStruct senderEvent = controller.StartEventor.Event[iter].Event;
			if (senderEvent != null)
			{
				GUILayout.Label("事件发射器(开始): " + senderEvent.ID + " | " + senderEvent.Name, FontStyle2);
			}
		}
		//
		for (int iter = 0; iter < controller.EndEventor.Event.Length; iter++)
		{
			SpaceEventStruct senderEvent = controller.EndEventor.Event[iter].Event;
			if (senderEvent != null)
			{
				GUILayout.Label("事件发射器(结束): " + senderEvent.ID + " | " + senderEvent.Name, FontStyle2);
			}
		}
	}

	void ShowEventReceiver()
	{
		_objectByEventList.Clear();
		SpaceBirthControllerStruct controller = CurrentBirthController;
		foreach (SpaceEventStruct receiverEvent in controller.StartEvent.Array)
		{
			if (receiverEvent != null)
			{
				GUILayout.Label("事件接收器(开始): " + receiverEvent.ID + " | " + receiverEvent.Name, FontStyle2);
				GUILayout.Label("可能来自: ");	
				GetObjectByEvent(receiverEvent.ID);
				ShowEventByObject();
			}
		}
		//
		for (int iter = 0; iter < controller.EndEvent.Length; iter++)
		{
			SpaceEventStruct receiverEvent = controller.EndEvent[iter].Event;
			if (receiverEvent != null)
			{
				GUILayout.Label("事件接收器(结束): " + receiverEvent.ID + " | " + receiverEvent.Name, FontStyle2);
				GUILayout.Label("可能来自: ");
				GetObjectByEvent(receiverEvent.ID);
				ShowEventByObject();
			}
		}
	}

	void GetObjectByEvent(Int32 spaceEventID)
	{
		foreach (NPCBirthPositionStruct npcBirthPos in CurrentSpaceAllNPC)
		{
			NPCBirthPropertyStruct birthProperty = npcBirthPos.BirthProperty.Data;
			if (birthProperty.FirstChaseEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
			if (birthProperty.FirstAttackedEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
			if (birthProperty.FirstDiscoverEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
			if (birthProperty.FirstDiscoveredEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
			if (birthProperty.KilledEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
			if (birthProperty.DieOutEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
			if (birthProperty.AttackedEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(npcBirthPos);
			}
		}
		//
		foreach (SpaceObjectBirthPositionStruct spaceObject in CurrentSpaceAllObject)
		{
			if (spaceObject.BirthProperty.FirstDiscoveredEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(spaceObject);
			}
			if (spaceObject.BirthProperty.KilledEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(spaceObject);
			}
			if (spaceObject.BirthProperty.DieOutEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(spaceObject);
			}
			if (spaceObject.BirthProperty.ActionEvent.Data.ID == spaceEventID)
			{
				_objectByEventList.Add(spaceObject);
			}
		}
		//
		foreach (SpaceEventStruct spaceEvent in CurrentSpaceAllEvent)
		{
			for (int iter = 0; iter < spaceEvent.Eventor.Length; iter++)
			{
				if (spaceEvent.Eventor[iter].Event == spaceEventID)
				{
					_objectByEventList.Add(spaceEvent);
				}
			}
		}
		//
		for (int index = 0; index < BirthControllerList.Count; index++)
		{
			SpaceBirthControllerStruct controller = BirthControllerList[index];
			for (int iter = 0; iter < controller.StartEventor.Event.Length; iter++ )
			{
				if (controller.StartEventor.Event[iter].Event == spaceEventID)
				{
					_objectByEventList.Add(controller);
				}
			}
			for (int iter = 0; iter < controller.EndEventor.Event.Length; iter++)
			{
				if (controller.EndEventor.Event[iter].Event == spaceEventID)
				{
					_objectByEventList.Add(controller);
				}
			}
		}
	}

	void ShowEventByObject()
	{
		foreach (object obj in _objectByEventList)
		{
			NPCBirthPositionStruct npcBirth = obj as NPCBirthPositionStruct;
			if (npcBirth != null)
			{
				GUILayout.Label("NPCBirthPosition" + " | " + "ID: " + npcBirth.ID + " | " + "Name: " + npcBirth.Name);
			}
			//
			SpaceObjectBirthPositionStruct spaceObject = obj as SpaceObjectBirthPositionStruct;
			if (spaceObject != null)
			{
				GUILayout.Label("SpaceObjectBirthPosition" + " | " + "ID: " + spaceObject.ID + " | " + "Name: " + spaceObject.Name);
			}
			//
			SpaceEventStruct spaceEvent = obj as SpaceEventStruct;
			if (spaceEvent != null)
			{
				GUILayout.Label("SpaceEvent" + " | " + "ID: " + spaceEvent.ID + " | " + "Name: " + spaceEvent.Name);
			}
			//
			SpaceBirthControllerStruct controller = obj as SpaceBirthControllerStruct;
			if (controller != null)
			{
				GUILayout.Label("BirthController" + " | " + "ID: " + controller.ID + " | " + "Name: " + controller.Name);
			}
		}
	}

	void ShowCurrentSpaceDetail(Int32 spaceID)
	{
		GUILayout.BeginVertical();
		GetSpaceDetail(spaceID);
		GUILayout.EndVertical();
	}

	void GetSpaceDetail(Int32 spaceID)
	{
		foreach (SpaceStruct space in ViSealedDB<SpaceStruct>.Array)
		{
			if (space.ID == spaceID)
			{
				GUILayout.Label("ID: " + space.ID + " | " + "Name: " + space.Name + " | " + space.Note);
				GUILayout.Label("NPC数量: " + CurrentSpaceAllNPC.Count + " | " + "Objects数量: " + CurrentSpaceAllObject.Count + " | " + "控制器数量: " + BirthControllerList.Count);
			}
		}
	}

	InspectType1 _activedInspectType1 = InspectType1.BirthControllerDetail;
	string[] _inspectToolbarStrings1 = { "控制器详情", "地图详情" };
	//
	static List<NPCBirthPositionStruct> _RelateNpcBirthList = new List<NPCBirthPositionStruct>();
	static List<SpaceObjectBirthPositionStruct> _RelateSpaceObjectList = new List<SpaceObjectBirthPositionStruct>();
	static List<SpaceBirthControllerStruct> _preControllerConditionList = new List<SpaceBirthControllerStruct>();
	//
	static List<object> _objectByEventList = new List<object>();
}
