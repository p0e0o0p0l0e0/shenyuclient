using System;
using System.Collections.Generic;
using UnityEngine;

public class FXDelayGroupManager : MonoBehaviour
{
	[System.Serializable]
	public class DelayStruct
	{
		public GameObject Tagert;
		public float DelayTime;

		public bool DelayEnd(float startTime)
		{
			return startTime + DelayTime > Time.time;
		}
	}

	public DelayStruct[] DelayStructs;

	void Awake()
	{
		_startTime = Time.time;
		for (Int32 iter = 0; iter < DelayStructs.Length; ++iter)
		{
			DelayStruct iterDelay = DelayStructs[iter];
			if (iterDelay.Tagert != null)
			{
				iterDelay.Tagert.SetActive(false);
			}
		}
	}

	void Update()
	{
		if (DelayStructs == null)
		{
			return;
		}
		if (DelayStructs.Length == 0)
		{
			return;
		}
		//
		for (Int32 iter = 0; iter < DelayStructs.Length; ++iter)
		{
			DelayStruct iterDelay = DelayStructs[iter];
			if (!iterDelay.DelayEnd(_startTime))
			{
				if (iterDelay.Tagert != null && !iterDelay.Tagert.activeInHierarchy)
				{
					iterDelay.Tagert.SetActive(true);
				}
			}
		}
	}

	float _startTime = 0.0f;
}
