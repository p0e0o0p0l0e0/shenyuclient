using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript_Route : MonoBehaviour
{
	public SpaceRouteStruct LogicData
	{
		get
		{
			if (_logicData == null)
			{
				_logicData = new SpaceRouteStruct();
				_logicData.State = new ViEnum32<ViSealDataState>((int)ViSealDataState.ACTIVE);
			}
			//
			_logicData.Points = new ViStaticArray<SpacePointStruct>(SpaceRouteStruct.POINT_COUNT);
			for (int iter = 0; iter < transform.childCount; ++iter)
			{
				Transform iterTran = transform.GetChild(iter);
				SpacePointStruct pointInfo = new SpacePointStruct();
				pointInfo.Active = new ViEnum32<SpacePointStruct.UseFlag>((int)SpacePointStruct.UseFlag.ACTIVE);
				ViVector3 pos = iterTran.position.Convert();
				pointInfo.Position.X = ViMathDefine.RoundToInt(pos.x * 100f);
				pointInfo.Position.Y = ViMathDefine.RoundToInt(pos.y * 100f);
				pointInfo.Position.Z = ViMathDefine.RoundToInt(pos.z * 100f);
				ViArrayParser.SetObject(_logicData.Points, iter, pointInfo);
			}
			return _logicData;
		}
		set
		{
			_logicData = value;
			_autoAssignID = false;
		}
	}
	SpaceRouteStruct _logicData;
	bool _autoAssignID = true;

	void Start()
	{
		if (MaxID <= 0 && ViSealedDB<SpaceRouteStruct>.IsLoaded)
		{
			MaxID = ViSealedDB<SpaceRouteStruct>.MaxID;
		}
		if (_autoAssignID)
		{
			LogicData.ID = MaxID + 1;
			++MaxID;
		}
	}

	/////////////////////
	public static int MaxID = 0;

	static void UpdateMaxID(int ID)
	{
		if (MaxID <= 0)
		{
			MaxID = ViSealedDB<SpaceRouteStruct>.MaxID;
		}
		if (MaxID < ID)
		{
			MaxID = ID;
		}
	}

	public static void Clone(SpaceScript_Route srcScript, int nextID)
	{
		if (srcScript == null)
		{
			return;
		}
		GameObject obj = UnityEngine.Object.Instantiate(srcScript.gameObject);
		obj.transform.SetParent(srcScript.transform.parent);
		SpaceScript_Route script = obj.GetComponent<SpaceScript_Route>();
		SpaceRouteStruct logicData = _CloneData(srcScript.LogicData);
		UpdateMaxID(nextID);
		logicData.ID = MaxID;
		script.LogicData = logicData;
		obj.name =  "路径 [" + logicData.ID + " | " + logicData.Name + "]";
	}

	static SpaceRouteStruct _CloneData(SpaceRouteStruct src)
	{
		SpaceRouteStruct info = new SpaceRouteStruct();
		ViBinaryCopy.Copy<SpaceRouteStruct>(src, info);
		return info;
	}
}
