using UnityEngine;
using System.Collections;

public class CS_moveThis : MonoBehaviour
{
	public float translationSpeedX = 0;
	public float translationSpeedY = 1;
	public float translationSpeedZ = 0;
	public float daily = 0;
	public float StopTime = 0;
	public bool local = true;
	private Transform _myTransform;
	private Vector3 _position;
	private float startTime;

	void Start()
	{
		_myTransform = transform;
		_position = new Vector3(translationSpeedX, translationSpeedY, translationSpeedZ);
		startTime = Time.time;

	}

	
	void Update()
	{
		if (StopTime > 0 && Time.time - startTime>StopTime) 
		{
			return;
		}

		if(Time.time - startTime < daily)
		{
			return;
		}

		if (local)
		{
			_myTransform.Translate(_position * Time.deltaTime);
		}

		else
		{
			_myTransform.Translate(_position * Time.deltaTime, UnityEngine.Space.World);
		}
	}
}
