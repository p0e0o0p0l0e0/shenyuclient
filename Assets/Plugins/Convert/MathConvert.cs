using UnityEngine;
using System.Collections;

public static class MathConvert
{
	public static UnityEngine.Vector3 Convert(this ViVector3 vector3)
	{
		return new UnityEngine.Vector3(vector3.x, vector3.z, vector3.y);
	}
	public static ViVector3 Convert(this UnityEngine.Vector3 vector3)
	{
		return new ViVector3(vector3.x, vector3.z, vector3.y);
	}
}