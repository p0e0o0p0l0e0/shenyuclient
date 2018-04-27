using UnityEngine;
using System.Collections;

public class ForwardCamera : MonoBehaviour
{
	void OnEnable()
	{
		_orgin = transform.rotation;
	}

	void OnWillRenderObject()
	{
		Vector3 cameraPos = Camera.current.transform.position;
		Vector3 currentPos = transform.position;
		Vector3 dir = cameraPos - currentPos;
		float distance = Vector3.Dot(dir, -transform.forward);
		Vector3 tagertPos = currentPos + distance * (-transform.forward);
		Vector3 dir01 = cameraPos - tagertPos;
		dir01.Normalize();
		transform.up = dir01;
		transform.rotation *= _orgin;
	}

	Quaternion _orgin;
}
