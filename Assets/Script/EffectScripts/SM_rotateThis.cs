using UnityEngine;
using System.Collections;

public class SM_rotateThis : MonoBehaviour
{
	public float rotationSpeedX = 90.0f;
	public float rotationSpeedY = 0.0f;
	public float rotationSpeedZ = 0.0f;

	void Start()
	{
		_rotationVector = new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
	}

	void Update()
	{
		transform.Rotate(_rotationVector * Time.deltaTime);
	}

	Vector3 _rotationVector = Vector3.zero;
}
