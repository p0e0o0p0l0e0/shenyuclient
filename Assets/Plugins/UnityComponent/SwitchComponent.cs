using System;
using UnityEngine;

[System.Serializable]
public struct SwitchNode
{
	public string Name;
	public GameObject Object;
}

public class SwitchComponent: MonoBehaviour
{
	public GameObject Current;
	public SwitchNode[] ElementList = new SwitchNode[0];
	//
	void OnEnable()
	{
		for (int iter = 0; iter < ElementList.Length; ++iter)
		{
			if (!System.Object.ReferenceEquals(Current, ElementList[iter].Object))
			{
				ElementList[iter].Object.SetActive(false);
			}
		}
	}
	//
	public void Set(string name, bool force)
	{
		if(ElementList == null)
		{
			return;
		}
		for (int iter = 0; iter < ElementList.Length; ++iter)
		{
			if (string.Compare(ElementList[iter].Name, name, true) == 0)
			{
				if (force || !System.Object.ReferenceEquals(Current, ElementList[iter].Object))
				{
					if (Current != null)
					{
						Current.SetActive(false);
					}
					Current = ElementList[iter].Object;
					if (Current != null)
					{
						Current.SetActive(true);
					}
				}
			}
		}
	}
}
