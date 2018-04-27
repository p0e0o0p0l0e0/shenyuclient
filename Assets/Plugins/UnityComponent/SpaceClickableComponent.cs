using System;
using UnityEngine;

[AddComponentMenu("Click/SpaceClickableComponent")]

public class SpaceClickableComponent : MonoBehaviour
{
	public static SpaceClickableComponent Select(Ray ray, float distance)
	{
		RaycastHit hitResult;
		float minDistance = float.MaxValue;
		SpaceClickableComponent minComponent = null;
		ViDoubleLinkNode2<SpaceClickableComponent> iter = s_list.GetHead();
		while (!s_list.IsEnd(iter))
		{
			SpaceClickableComponent iterComponent = iter.Data;
			ViDoubleLink2<SpaceClickableComponent>.Next(ref iter);
			//
			if (iterComponent.Collider == null)
			{
				continue;
			}
			//
			if (iterComponent.Collider.Raycast(ray, out hitResult, distance))
			{
				if (hitResult.distance < minDistance)
				{
					minDistance = hitResult.distance;
					minComponent = iterComponent;
				}
			}
		}
		return minComponent;
	}

	static ViDoubleLink2<SpaceClickableComponent> s_list = new ViDoubleLink2<SpaceClickableComponent>();

	void OnEnable()
	{
		_collider = GetComponentInChildren<Collider>();
		ViDebuger.AssertError(_collider);
		//
		_node.Data = this;
		s_list.PushBack(_node);
	}

	void OnDisable()
	{
		_node.Detach();
	}

	public void Invoke()
	{
		ViDelegateAssisstant.Invoke(_callback);
	}

	public string Script;
	public Color ModColor = new Color(0, 0, 0);
	public GameObject Obj;
	public Collider Collider { get { return _collider; } }
	public ViDelegateAssisstant.Dele Callback { set { _callback = value; } }

	//
	Collider _collider;
	ViDelegateAssisstant.Dele _callback;
	ViDoubleLinkNode2<SpaceClickableComponent> _node = new ViDoubleLinkNode2<SpaceClickableComponent>();
}