using UnityEngine;
using System.Collections.Generic;

public class FXCurveAnimation_GroupProperty : MonoBehaviour
{
	public List<Renderer> ShareObj;
	public Material MainMaterial;

	void Awake()
	{
		if (ShareObj == null)
		{
			return;
		}
		for (int iter = 0; iter < ShareObj.Count; ++iter)
		{
			Renderer iterObject = ShareObj[iter];
			iterObject.enabled = false;
		}
	}

	void Update()
	{
		if (MainMaterial == null)
		{
			return;
		}
		if (ShareObj == null)
		{
			return;
		}
		//
		for (int iter = 0; iter < ShareObj.Count; ++iter)
		{
			Renderer iterObject = ShareObj[iter];
			if (iterObject != null)
			{
				iterObject.sharedMaterial = MainMaterial;
			}
		}
	}

}
