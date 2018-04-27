using UnityEngine;
using System.Collections;

public enum ForceDirection
{
	FORWARD,
	DOWN,
	BACK,
	UP,
	LEFT,
	RIGHT,
}

public class AddForce : MonoBehaviour
{
	public float Power = 5.0f;
	public ForceDirection Dir = ForceDirection.FORWARD;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		if (_rigidbody == null)
		{
			_rigidbody = gameObject.AddComponent<Rigidbody>();
		}
		//
		if (_rigidbody != null)
		{
			Vector3 forcePower = GetDirection() * Power - transform.up * Power / 10.0f;
			_rigidbody.AddForce(forcePower);
		}
	}

	public Vector3 GetDirection()
	{
		Vector3 pos = Vector3.one;
		switch (Dir)
		{
			case ForceDirection.FORWARD:
				{
					pos = transform.forward;
					break;
				}
			case ForceDirection.DOWN:
				{
					pos = -transform.up;
					break;
				}
			case ForceDirection.BACK:
				{
					pos = -transform.forward;
					break;
				}
			case ForceDirection.UP:
				{
					pos = transform.up;
					break;
				}
			case ForceDirection.LEFT:
				{
					pos = -transform.right;
					break;
				}
			case ForceDirection.RIGHT:
				{
					pos = transform.right;
					break;
				}
		}
		//
		return pos;
	}

	void Update()
	{

	}

	Rigidbody _rigidbody;
}
