using UnityEngine;
using System.Collections;

public class LockRotationComponent : MonoBehaviour
{
	void Awake()
	{
		_startQuaternion = transform.rotation;
	}

	void Update()
	{
		if (_startQuaternion != transform.rotation)
		{
			transform.rotation = _startQuaternion;
		}
	}

	Quaternion _startQuaternion; 
}
