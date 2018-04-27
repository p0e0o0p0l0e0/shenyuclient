using UnityEngine;
using System.Collections;

public class DiscoverSpaceBlockComponent : MonoBehaviour
{
	public GameObject Mist;
	public Transform[] Point;

	public void Awake()
	{
		if (Point == null)
		{
			Point = new Transform[0];
		}
		if (Mist == null)
		{
			Mist = new GameObject("Mist");
			UnityAssisstant.JionTransform(gameObject, Mist, Vector3.zero, Quaternion.identity);
		}
	}

	public Transform GetPoint(int idx)
	{
		if (idx < Point.Length)
		{
			return Point[idx];
		}
		else
		{
			return transform;
		}
	}

}