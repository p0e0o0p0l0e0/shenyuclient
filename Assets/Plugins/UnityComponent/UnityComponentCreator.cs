using System;
using System.Collections.Generic;
using UnityEngine;

public static class UnityComponentCreator
{
	public static void Register<TComponent>()
		where TComponent : Component
	{
		NodeStruct node = new NodeStruct();
		node.CreateExec = Create<TComponent>;
		node.GetExec = Get<TComponent>;
		_list[typeof(TComponent).Name] = node;
	}

	public static Component Create(GameObject obj, string name)
	{
		NodeStruct node;
		if (_list.TryGetValue(name, out node))
		{
			return ViDelegateAssisstant.Invoke(node.CreateExec, null, obj);
		}
		else
		{
			return null;
		}
	}

	public static Component Get(GameObject obj, string name)
	{
		NodeStruct node;
		if (_list.TryGetValue(name, out node))
		{
			return ViDelegateAssisstant.Invoke(node.GetExec, null, obj);
		}
		else
		{
			return null;
		}
	}

	public static TComponent Create<TComponent>(GameObject obj)
		where TComponent : Component
	{
		if (obj != null)
		{
			return obj.AddComponent<TComponent>();
		}
		else
		{
			return null;
		}
	}

	public static TComponent Get<TComponent>(GameObject obj)
		where TComponent : Component
	{
		if (obj != null)
		{
			return obj.GetComponent<TComponent>();
		}
		else
		{
			return null;
		}
	}

	struct NodeStruct
	{
		public ViDelegateAssisstant.RTDele<Component, GameObject> CreateExec;
		public ViDelegateAssisstant.RTDele<Component, GameObject> GetExec;
	}

	static Dictionary<string, NodeStruct> _list = new Dictionary<string, NodeStruct>();
}