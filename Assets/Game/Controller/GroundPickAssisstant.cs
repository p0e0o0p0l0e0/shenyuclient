using System;
using System.Collections.Generic;
using UnityEngine;

public static class GroundPickAssisstant
{
	public static ViConstValue<float> VALUE_GroundPickDistanceInf = new ViConstValue<float>("GroundPickDistanceInf", 3.0f);
	public static ViConstValue<float> VALUE_GroundPickDistanceSup = new ViConstValue<float>("GroundPickDistanceSup", 15.0f);
	//
	public static bool PickPos(UnityEngine.Ray ray, float distance, out ViVector3 pos)
	{
		return PickPos(ray, distance, out pos, false);
	}
	public static bool PickPos(UnityEngine.Ray ray, float distance, out ViVector3 pos, bool attachEntity)
	{
		if (CellHero.LocalHero == null)
		{
			pos = ViVector3.ZERO;
			return false;
		}
		if (attachEntity)
		{
			//SpaceEntity picked = ObjectPicker.GetEntity<SpaceEntity>();
			//if (picked != null)
			//{
			//    GameUnit pickedGameUnit = picked as GameUnit;
			//    if (pickedGameUnit != null)
			//    {
			//        if (Player.LocalPlayer.IsEnemy(pickedGameUnit))
			//        {
			//            pos = picked.Position;
			//            return true;
			//        }
			//    }
			//}
		}
		ray = new UnityEngine.Ray(ray.GetPoint(VALUE_GroundPickDistanceInf), ray.direction);
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, distance, GroundHeight.LayerMask))
		{
			pos = hitInfo.point.Convert();
			return true;
		}
		else
		{
			Vector3 localHeroPos = CellHero.LocalHero.Position.Convert();
			pos = (ray.origin + (localHeroPos.y - ray.origin.y) / ray.direction.y * ray.direction).Convert();
			return true;
		}
	}
}