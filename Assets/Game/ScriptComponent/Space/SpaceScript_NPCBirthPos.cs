using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript_NPCBirthPos : MonoBehaviour
{
	//public int Vi_ID;
	//public string Vi_Name;
	//public int Vi_Space;
	//public int Vi_NPC;
	//public int Vi_Count;
	//public int Vi_Route;
	//public BoolValue Vi_RouteClip;

	public NPCBirthPositionStruct LogicData
	{
		get
		{
			if (_logicData == null)
			{
				_logicData = new NPCBirthPositionStruct();
				ViBinaryCopy.Copy<NPCBirthPositionStruct>(ViSealedDB<NPCBirthPositionStruct>.Data(0), _logicData);
			}
			//_logicData.ID = Vi_ID;
			//_logicData.Name = Vi_Name;
			//_logicData.Space = new ViForeignKey<SpaceStruct>(Vi_Space);
			//_logicData.NPC = new ViForeignKey<NPCStruct>(Vi_NPC);
			//_logicData.Count = Vi_Count;
			//_logicData.Route = new ViForeignKey<SpaceRouteStruct>(Vi_Route);
			//_logicData.RouteClip = new ViEnum32<BoolValue>((int)Vi_RouteClip);
			//
			ViVector3 pos = transform.position.Convert();
			_logicData.Position.X = ViMathDefine.RoundToInt(pos.x * 100f);
			_logicData.Position.Y = ViMathDefine.RoundToInt(pos.y * 100f);
			_logicData.Position.Z = ViMathDefine.RoundToInt(pos.z * 100f);
			float angle = transform.eulerAngles.y;
			angle = (180.0f - angle) * ViMathDefine.PI / 180.0f;
			_logicData.Yaw = ViMathDefine.RoundToInt(angle * 100f);
			return _logicData;
		}
		set
		{
			_logicData = value;
			//
			if (value != null)
			{
				//Vi_ID = value.ID;
				//Vi_Name = value.Name;
				//Vi_Space = value.Space.Value;
				//Vi_Route = value.Route.Value;
				//Vi_NPC = value.NPC.Value;
				//Vi_Count = value.Count;
				//Vi_RouteClip = (BoolValue)value.RouteClip.Value;
				//  
				ViVector3 tmpPostition = value.Position;
				transform.position = tmpPostition.Convert();
				float angle = 180f - value.Yaw * 0.01f / ViMathDefine.PI * 180f;
				transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
			}
			_autoAssignID = false;
		}
	}
	NPCBirthPositionStruct _logicData;
	bool _autoAssignID = true;

	void Start()
	{
		if (ViSealedDB<NPCBirthPositionStruct>.IsLoaded)
		{
			if (MaxID_ALL <= 0)
			{
				MaxID_ALL = ViSealedDB<NPCBirthPositionStruct>.MaxID;
			}
		}
		if (_autoAssignID)
		{
			LogicData.ID = MaxID_ALL + 1;
			++MaxID_ALL;
		}
	}

	////////////////////////////////////
	public static int MaxID_ALL = 0;
	static Dictionary<int, int> MaxID_Space = new Dictionary<int, int>();

	static int GetMaxID(int space)
	{
		int maxID = 0;
		if (MaxID_Space.TryGetValue(space, out maxID))
		{
			maxID++;
		}
		else
		{
			foreach (KeyValuePair<int, NPCBirthPositionStruct> pair in ViSealedDB<NPCBirthPositionStruct>.Dict)
			{
				if (pair.Value.Space != space)
				{
					continue;
				}
				if (pair.Key > maxID)
				{
					maxID = pair.Key;
				}
			}
			maxID++;
		}
		MaxID_Space[space] = maxID;
		return maxID;
	}

	static void UpdateMaxID(int space, int ID)
	{
		int maxID = 0;
		if (!MaxID_Space.TryGetValue(space, out maxID) || maxID < ID)
		{
			MaxID_Space[space] = ID;
		}
	}

	public static void Clone(SpaceScript_NPCBirthPos srcScript, int nextID)
	{
		if (srcScript == null)
		{
			return;
		}
		GameObject obj = UnityEngine.Object.Instantiate(srcScript.gameObject);
		obj.transform.SetParent(srcScript.transform.parent);
		SpaceScript_NPCBirthPos script = obj.GetComponent<SpaceScript_NPCBirthPos>();
		NPCBirthPositionStruct logicData = _CloneData(srcScript.LogicData);
		if (nextID <= 0)
		{
			nextID = GetMaxID(srcScript.LogicData.Space);
		}
		else
		{
			UpdateMaxID(srcScript.LogicData.Space, nextID);
		}
		logicData.ID = nextID;
		script.LogicData = logicData;
		obj.name = logicData.ID.ToString() + " | " + logicData.Name;
	}

	static NPCBirthPositionStruct _CloneData(NPCBirthPositionStruct src)
	{
		NPCBirthPositionStruct info = new NPCBirthPositionStruct();
		ViBinaryCopy.Copy<NPCBirthPositionStruct>(src, info);
		return info;
	}
}
