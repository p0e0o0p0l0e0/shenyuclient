using System;
using UnityEngine;



//! 地效飞行模拟(Wing in ground)
public static class GroundWinger
{

	public static ViVector3 Wing(TangercyType eType, ViVector3 normal, float yaw)
	{
		switch (eType)
		{
			case TangercyType.POINT:
				return ViVector3.UNIT_Z;
			case TangercyType.LINE:
				{
					ViVector3 front = ViVector3.ZERO;
					ViGeographicObject.GetRotate(yaw, ref front.x, ref front.y);
					front.Normalize();
					ViVector3 rot = ViVector3.Cross(front, normal);
					ViVector3 frontGround = ViVector3.Cross(normal, rot);
					frontGround.Normalize();
					ViVector3 newNormal = normal;
					newNormal.z = 0;
					newNormal.Normalize();
					newNormal *= (float)Math.Abs(frontGround.z);
					newNormal.z = (float)Math.Sqrt(1 - frontGround.z * frontGround.z);
					return newNormal;
				}
			case TangercyType.PLANE:
				return normal;
			default:
				return normal;
		}
	}


	public static void Update(ViVector3 position, ViVector3 direction, float roll, Transform transform)
	{
		Update(position, direction, roll, transform, transform);
	}
	public static void Update(ViVector3 position, ViVector3 direction, float roll, Transform posTransform, Transform rotTransform)
	{
		Vector3 newPos = position.Convert();
		Vector3 front = direction.Convert();
		Vector3 lookAtPos = newPos + front;
		Vector3 up = Vector3.up;
		Quaternion rollQuat = Quaternion.AngleAxis(ViMathDefine.Rad2Deg * roll, front);
		up = rollQuat * up;
		//
		if (posTransform != null)
		{
			posTransform.localPosition = newPos;
		}
		if (rotTransform != null)
		{
			rotTransform.LookAt(lookAtPos, up);
		}
	}

	public static void Update(ViVector3 position, float yaw, ViVector3 normal, Transform transform)
	{
		Update(position, yaw, normal, transform, transform);
	}
	public static void Update(ViVector3 position, float yaw, ViVector3 normal, Transform posTransform, Transform rotTransform)
	{
		if (normal == ViVector3.UNIT_Z)
		{
			if (posTransform != null)
			{
				posTransform.localPosition = position.Convert();
			}
			if (rotTransform != null)
			{
				rotTransform.rotation = UnityEngine.Quaternion.AngleAxis(ViMathDefine.Radius2Degree(yaw), Vector3.up);
			}
		}
		else
		{
			float angle = ViVector3.Angle(ViVector3.UNIT_Z, normal);
			ViVector3 rotateAxis = ViVector3.Cross(ViVector3.UNIT_Z, normal);
			rotateAxis.Normalize();
			ViQuaternion rotateQuat = ViQuaternion.FromAxisAngle(rotateAxis, angle);
			ViVector3 front = ViVector3.ZERO;
			ViGeographicObject.GetRotate(yaw, ref front.x, ref front.y);
			front.Normalize();
			front = rotateQuat * front;
			ViVector3 lookAtPos = position + front;
			//
			if (posTransform != null)
			{
				posTransform.localPosition = position.Convert();
			}
			if (rotTransform != null)
			{
				rotTransform.LookAt(lookAtPos.Convert(), normal.Convert());
			}
		}
	}

	public static UnityEngine.Quaternion GetQuat(float yaw, ViVector3 normal)
	{
		if (normal == ViVector3.UNIT_Z)
		{
			return UnityEngine.Quaternion.AngleAxis(ViMathDefine.Radius2Degree(yaw), Vector3.up);
		}
		else
		{
			float angle = ViVector3.Angle(ViVector3.UNIT_Z, normal);
			ViVector3 rotateAxis = ViVector3.Cross(ViVector3.UNIT_Z, normal);
			rotateAxis.Normalize();
			ViQuaternion rotateQuat = ViQuaternion.FromAxisAngle(rotateAxis, angle);
			ViVector3 front = ViVector3.ZERO;
			ViGeographicObject.GetRotate(yaw, ref front.x, ref front.y);
			front.Normalize();
			front = rotateQuat * front;
			//
			return Quaternion.LookRotation(front.Convert());
		}
	}

}
