using UnityEngine;
using System;
using System.Collections.Generic;

public static class GroundHeight
{
	public static Int32 LayerMask = ViMask32.Mask((Int32)UnityLayer.GROUND);


	public static bool GetGroundHeight(ref ViVector3 pos)
	{
		float nearPickLen = 200.0f;
		Vector3 pickPos = new Vector3(pos.x, pos.z + nearPickLen, pos.y);
		RaycastHit hitInfo;
		if (UnityEngine.Physics.Raycast(pickPos, Vector3.down, out hitInfo, nearPickLen * 2.0f, LayerMask))
		{
			pos.z = hitInfo.point.y;
			return true;
		}
		//pos.z = ViMathDefine.Clamp(pos.z, -nearPickLen, nearPickLen);
		return false;
	}
	public static bool GetGroundHeight(float radius, ref ViVector3 pos)
	{
		float nearPickLen = 200.0f;
		Vector3 pickPos = new Vector3(pos.x, pos.z + nearPickLen, pos.y);
		RaycastHit hitInfo;
		if (UnityEngine.Physics.SphereCast(pickPos, radius, Vector3.down, out hitInfo, nearPickLen * 2.0f, LayerMask))
		{
			pos.z = hitInfo.point.y;
			return true;
		}
		//pos.z = ViMathDefine.Clamp(pos.z, -nearPickLen, nearPickLen);
		return false;
	}
	public static bool GetGroundHeight(float radius, ref ViVector3 pos, ref ViVector3 nomal)
	{
		float nearPickLen = 200.0f;
		Vector3 pickPos = new Vector3(pos.x, pos.z + nearPickLen, pos.y);
		RaycastHit hitInfo;
		if (UnityEngine.Physics.SphereCast(pickPos, radius, Vector3.down, out hitInfo, nearPickLen * 2.0f, LayerMask))
		{
			pos.z = hitInfo.point.y;
			nomal = hitInfo.normal.Convert();
			return true;
		}
		//float MaxHeight = 60.0f;
		//pickPos = new Vector3(pos.x, MaxHeight, pos.y);
		//if (UnityEngine.Physics.SphereCast(pickPos, radius, Vector3.down, out hitInfo, MaxHeight, LayerMask))
		//{
		//    pos.z = hitInfo.point.y;
		//    nomal = hitInfo.normal.Convert();
		//    return;
		//}
		//pos.z = ViMathDefine.Clamp(pos.z, -nearPickLen, nearPickLen);
		return false;
	}

	public static bool GetGroundHeight(ref ViVector3 pos, ref ViVector3 nomal)
	{
		float nearPickLen = 200.0f;
		Vector3 pickPos = new Vector3(pos.x, pos.z + nearPickLen, pos.y);
		RaycastHit hitInfo;
		if (UnityEngine.Physics.Raycast(pickPos, Vector3.down, out hitInfo, nearPickLen * 2.0f, LayerMask))
		{
			pos.z = hitInfo.point.y;
			nomal = hitInfo.normal.Convert();
			return true;
		}
		//float MaxHeight = 60.0f;
		//pickPos = new Vector3(pos.x, MaxHeight, pos.y);
		//if (UnityEngine.Physics.Raycast(pickPos, Vector3.down, out hitInfo, MaxHeight, LayerMask))
		//{
		//    pos.z = hitInfo.point.y;
		//    nomal = hitInfo.normal.Convert();
		//    return;
		//}
		//pos.z = ViMathDefine.Clamp(pos.z, -nearPickLen, nearPickLen);
		return false;
	}

	public static void GetGroundHeight(List<ViVector3> posList, float height)
	{
		for (int iter = 0; iter < posList.Count; ++iter)
		{
			ViVector3 iterPos = posList[iter];
			GetGroundHeight(ref iterPos);
			iterPos.z += height;
			posList[iter] = iterPos;
		}
	}
}