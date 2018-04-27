using UnityEngine;
using System.Collections;

public class AvatarFaceAnimator : MonoBehaviour
{
	public GameObject Default;
	public GameObject[] ActionList;

	public void Start()
	{
		if (_current == null)
		{
			Replace(Default);
		}
		else if (!System.Object.ReferenceEquals(Default, _current))
		{
			if (Default != null)
			{
				Default.SetActive(false);
			}
		}
	}

	public void Play(string name, float duration)
	{
		GameObject newFace = Find(Default.name + name);
		if (newFace == null)
		{
			return;
		}
		//
		Replace(newFace);
	}

	public void Stop()
	{
		Replace(Default);
		_actionEndTime.Detach();
	}

	public void Clear()
	{
		Replace(Default);
		_actionEndTime.Detach();
	}

	ViTimeNode1 _actionEndTime = new ViTimeNode1();
	void OnActionEndTime(ViTimeNodeInterface node)
	{
		Replace(Default);
	}

	GameObject Find(string name)
	{
		for (int iter = 0; iter < ActionList.Length; ++iter)
		{
			GameObject iterObj = ActionList[iter];
			if (iterObj == null)
			{
				continue;
			}
			//
			if (StandardAssisstant.EqualsIgnoreCase(iterObj.name, name))
			{
				return iterObj;
			}
		}
		return null;
	}

	void Replace(GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		//
		for (int iter = 0; iter < ActionList.Length; ++iter)
		{
			GameObject iterObj = ActionList[iter];
			if (!System.Object.ReferenceEquals(iterObj ,obj))
			{
				iterObj.SetActive(false);
			}
		}
		//
		_current = obj;
		_current.SetActive(true);
	}

	GameObject _current;
}
