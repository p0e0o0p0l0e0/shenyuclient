using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SceneEditorAssisstant
{
	public static SceneEditorAssisstant Instance { get { return _intance; } }
	static SceneEditorAssisstant _intance = new SceneEditorAssisstant();

	static string FormatName(int ID, string name)
	{
		return ID.ToString() + " | " + name;
	}

	#region  Space
	public int[] SpaceIDArr { get { return SpaceDict.Keys.ToArray(); } }
	public string[] SpaceNameArr { get { return SpaceDict.Values.ToArray(); } }
	public Dictionary<int, string> SpaceDict
	{
		get
		{
			if (_spaceDict.Count <= 0)
			{
				InitSpaces();
			}
			return _spaceDict;
		}
	}
	Dictionary<int, string> _spaceDict = new Dictionary<int, string>();

	public int SelectSpace
	{
		get
		{
			if (_selectSpace <= 0)
			{
				if (GameSpaceRecordInstance.Instance != null)
				{
					_selectSpace = GameSpaceRecordInstance.Instance.Property.Info;
				}
			}
			return _selectSpace;
		}
		set
		{
			_selectSpace = value;
		}
	}
	int _selectSpace = 0;

	public void InitSpaces()
	{
		_spaceDict.Clear();
		if (ViSealedDB<SpaceStruct>.IsLoaded)
		{
			foreach (KeyValuePair<int, SpaceStruct> pair in ViSealedDB<SpaceStruct>.Dict)
			{
				if (pair.Key == 0)
				{
					continue;
				}
				//
				string valueStr = FormatName(pair.Key, pair.Value.Name);
				_spaceDict[pair.Key] = valueStr;
			}
		}
	}

	public bool GetSelectedSpace(out string space)
	{
		space = string.Empty;
		return SpaceDict.TryGetValue(SelectSpace, out space);
	}

	#endregion

	#region NPC Route in Space
	public int[] SpaceRouteIDArr { get { return SpaceRouteDict.Keys.ToArray(); } }
	public string[] SpaceRouteNameArr { get { return SpaceRouteDict.Values.ToArray(); } }
	public Dictionary<int, string> SpaceRouteDict
	{
		get
		{
			if (_spaceRouteDict.Count <= 0)
			{
				InitSpaceRoutes();
			}
			return _spaceRouteDict;
		}
	}
	Dictionary<int, string> _spaceRouteDict = new Dictionary<int, string>();

	public int SelectSpaceRoute
	{
		get
		{
			if (_selectSpaceRoute <= 0 && SpaceRouteIDArr.Length > 0)
			{
				_selectSpaceRoute = SpaceRouteIDArr[0];
			}
			return _selectSpaceRoute;
		}
		set
		{
			_selectSpaceRoute = value;
		}
	}
	int _selectSpaceRoute = 0;

	public void InitSpaceRoutes()
	{
		_spaceRouteDict.Clear();
		if (ViSealedDB<SpaceRouteStruct>.IsLoaded)
		{
			foreach (KeyValuePair<int, SpaceRouteStruct> pair in ViSealedDB<SpaceRouteStruct>.Dict)
			{
				if (pair.Key == 0)
				{
					continue;
				}
				//
				string valueStr = FormatName(pair.Key, pair.Value.Name);
				_spaceRouteDict[pair.Key] = valueStr;
			}
		}
	}

	/// <summary>
	/// 加载选中路径
	/// </summary>
	public void LoadSpaceRoute_Selected()
	{
		LoadSpaceRoute(SelectSpaceRoute);
	}
	void LoadSpaceRoute(int route)
	{
		SpaceRouteStruct info = ViSealedDB<SpaceRouteStruct>.Data(route);
		string objName = "路径 [" + FormatName(info.ID, info.Name) + "]";
		GameObject rootObj = GameObject.Find(objName);
		if (rootObj == null)
		{
			rootObj = new GameObject(objName);
		}
		else
		{
			Debug.LogWarning("已经加载路径：" + objName);
			return;
		}
		//
		SpaceScript_Route script = rootObj.AddComponent<SpaceScript_Route>();
		script.LogicData = info;
		List<ViVector3> posList = new List<ViVector3>();
		info.GetList(posList);
		for (int iter = 0; iter < posList.Count; ++iter)
		{
			ViVector3 position = posList[iter];
			GameObject tmpGO = new GameObject(iter.ToString());
			Transform tmpTransform = tmpGO.transform;
			tmpTransform.parent = rootObj.transform;
			tmpTransform.position = position.Convert();
		}
	}

	/// <summary>
	/// 加载场景中所有NPC所用的路径
	/// </summary>
	public void LoadSpaceRoutes_AllNPC()
	{
		foreach (KeyValuePair<int, string> pair in NPCBirthPosDict)
		{
			NPCBirthPositionStruct iterInfo = ViSealedDB<NPCBirthPositionStruct>.Data(pair.Key);
			if (iterInfo.Route.Value > 0)
			{
				LoadSpaceRoute(iterInfo.Route.Value);
			}
		}
	}

	public void SaveSpaceRoutes()
	{
		SpaceScript_Route[] dataList = GameObject.FindObjectsOfType<SpaceScript_Route>();
		if (dataList == null || dataList.Length <= 0)
		{
			return;
		}
		for (int iter = 0; iter < dataList.Length; ++iter)
		{
			SpaceRouteStruct info = dataList[iter].LogicData;
			ViSealedDB<SpaceRouteStruct>.SetData(info.ID, info);
		}
		//
		VISWriter.SaveVIS<SpaceRouteStruct>();
	}
	#endregion

	#region NPC Birth Pos
	public int[] NPCBirthIDArr { get { return NPCBirthPosDict.Keys.ToArray(); } }
	public string[] NPCBirthNameArr { get { return NPCBirthPosDict.Values.ToArray(); } }
	public Dictionary<int, string> NPCBirthPosDict
	{
		get
		{
			if (_NPCBirthPosDict.Count <= 0)
			{
				UpdateNPCBirthPos();
			}
			return _NPCBirthPosDict;
		}
	}
	Dictionary<int, string> _NPCBirthPosDict = new Dictionary<int, string>();

	public int SelectedNPCBirthID
	{
		get
		{
			if (_selectedNPCBirthID <= 0 && NPCBirthIDArr.Length > 0)
			{
				_selectedNPCBirthID = NPCBirthIDArr[0];
			}
			return _selectedNPCBirthID;
		}
		set
		{
			_selectedNPCBirthID = value;
		}
	}
	int _selectedNPCBirthID = 0;

	public void UpdateNPCBirthPos()
	{
		_NPCBirthPosDict.Clear();
		if (ViSealedDB<NPCBirthPositionStruct>.IsLoaded)
		{
			foreach (KeyValuePair<int, NPCBirthPositionStruct> pair in ViSealedDB<NPCBirthPositionStruct>.Dict)
			{
				if (pair.Value.Space != SelectSpace)
				{
					continue;
				}
				//
				string valueStr = FormatName(pair.Key, pair.Value.Name);
				_NPCBirthPosDict[pair.Key] = valueStr;
			}
		}
	}

	public void LoadNPCBirths()
	{
		string rootObjName = "布怪[" + SpaceDict[SelectSpace] + "] List";
		GameObject rootObj = GameObject.Find(rootObjName);
		if (rootObj == null)
		{
			rootObj = new GameObject(rootObjName);
		}
		else
		{
			Debug.LogWarning("已经加载NPC出生点：" + rootObjName);
			return;
		}
		//
		foreach (KeyValuePair<int, string> pair in NPCBirthPosDict)
		{
			Avatar avatar = new Avatar();
			GameObject npcObj = new GameObject(pair.Value);
			npcObj.transform.parent = rootObj.transform;
			NPCBirthPositionStruct info = ViSealedDB<NPCBirthPositionStruct>.Data(pair.Key);
			VisualNPCStruct visualNPC = ViSealedDB<VisualNPCStruct>.Data(info.NPC);
			AvatarCreator.Create(avatar, visualNPC.Avatar.Data);
			GameObject obj = avatar.Root;
			obj.transform.parent = npcObj.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			//
			SpaceScript_NPCBirthPos script = npcObj.AddComponent<SpaceScript_NPCBirthPos>();
			script.LogicData = info;
		}
	}

	public void SaveNPCBirth()
	{
		SpaceScript_NPCBirthPos[] dataList = GameObject.FindObjectsOfType<SpaceScript_NPCBirthPos>();
		if (dataList == null || dataList.Length <= 0)
		{
			return;
		}
		for (int iter = 0; iter < dataList.Length; ++iter)
		{
			NPCBirthPositionStruct info = dataList[iter].LogicData;
			ViSealedDB<NPCBirthPositionStruct>.SetData(info.ID, info);
		}
		//
		VISWriter.SaveVIS<NPCBirthPositionStruct>();
	}
	#endregion

	#region Birth Controller
	public int[] SpaceBirthControllerIDArr { get { return SpaceBirthControllerDict.Keys.ToArray(); } }
	public string[] SpaceBirthControllerNameArr { get { return SpaceBirthControllerDict.Values.ToArray(); } }
	public Dictionary<int, string> SpaceBirthControllerDict
	{
		get
		{
			if (_spaceBirthControllerDict.Count <= 0)
			{
				UpdateSpaceBirthController();
			}
			return _spaceBirthControllerDict;
		}
	}
	Dictionary<int, string> _spaceBirthControllerDict = new Dictionary<int, string>();

	public void UpdateSpaceBirthController()
	{
		_spaceBirthControllerDict.Clear();
		if (ViSealedDB<SpaceBirthControllerStruct>.IsLoaded)
		{
			foreach (KeyValuePair<Int32, SpaceBirthControllerStruct> pair in ViSealedDB<SpaceBirthControllerStruct>.Dict)
			{
				if (pair.Value.Space != SelectSpace)
				{
					continue;
				}
				//
				string valueStr = FormatName(pair.Key, pair.Value.Name);
				_spaceBirthControllerDict[pair.Key] = valueStr;
			}
		}
	}

	public void LoadSpaceBirthControllers()
	{
		string rootObjName = "控制器[" + SpaceDict[SelectSpace] + "] List";
		GameObject rootObj = GameObject.Find(rootObjName);
		if (rootObj == null)
		{
			rootObj = new GameObject(rootObjName);
		}
		else
		{
			Debug.LogWarning("已经加载BirthContorller信息：" + rootObjName);
			return;
		}
		//
		foreach (KeyValuePair<Int32, string> pair in SpaceBirthControllerDict)
		{
			GameObject controllerObj = new GameObject(pair.Value);
			controllerObj.transform.parent = rootObj.transform;
			SpaceScript_BirthController script = controllerObj.AddComponent<SpaceScript_BirthController>();
			script.controllerData = ViSealedDB<SpaceBirthControllerStruct>.Data(pair.Key);
		}
	}

	public void SaveSpaceBirthControllers()
	{
		SpaceScript_BirthController[] dataList = GameObject.FindObjectsOfType<SpaceScript_BirthController>();
		if (dataList == null || dataList.Length <= 0)
		{
			return;
		}
		for (int iter = 0; iter < dataList.Length; ++iter)
		{
			SpaceBirthControllerStruct info = dataList[iter].controllerData;
			ViSealedDB<SpaceBirthControllerStruct>.SetData(info.ID, info);
		}
		//
		VISWriter.SaveVIS<SpaceBirthControllerStruct>();
	}
	#endregion
}
