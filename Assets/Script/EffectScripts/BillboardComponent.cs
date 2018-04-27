using UnityEngine;
using System.Collections;

public class BillboardComponent : MonoBehaviour
{
	public enum Axies
	{
		UP,
		DOWN,
	}

	public Axies CurrentAxies = Axies.UP;

	public void Awake()
	{
		
	}

	void OnWillRenderObject()
	{
		Vector3 axies = _GetAxies();
		transform.LookAt(Camera.current.transform.position);
	}

	Vector3 _GetAxies()
	{
		switch (CurrentAxies)
		{
		case Axies.UP:
			{
				return Vector3.up;
			}
		case Axies.DOWN:
			{
				return Vector3.down;
			}
		default:
			{
				return Vector3.up;
			}
		}
	}
}