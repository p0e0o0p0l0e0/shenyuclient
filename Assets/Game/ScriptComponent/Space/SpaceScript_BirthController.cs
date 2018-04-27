using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript_BirthController : MonoBehaviour
{
	public SpaceBirthControllerStruct controllerData
	{
		get
		{
			if (_controllerData == null)
			{
				_controllerData = new SpaceBirthControllerStruct();
				_controllerData.State = new ViEnum32<ViSealDataState>((Int32)ViSealDataState.ACTIVE);
			}
			//
			ViVector3 pos = this.transform.position.Convert();
			_controllerData.Position.X = ViMathDefine.RoundToInt(pos.x * 100f);
			_controllerData.Position.Y = ViMathDefine.RoundToInt(pos.y * 100f);
			_controllerData.Position.Z = ViMathDefine.RoundToInt(pos.z * 100f);
			return _controllerData;
		}
		set
		{
			_controllerData = value;
			//
			if (value != null)
			{
				ViVector3 tmpPosition = value.Position;
				transform.position = tmpPosition.Convert();
			}
		}
	}
	SpaceBirthControllerStruct _controllerData;

	void Start()
	{
		if (MaxID <= 0 && ViSealedDB<SpaceBirthControllerStruct>.IsLoaded)
		{
			MaxID = ViSealedDB<SpaceBirthControllerStruct>.MaxID;
		}
	}
	public static Int32 MaxID = 0;
}
