using System;
using System.Collections.Generic;
using UnityEngine;

public static class UnityDeletor
{
	public class Node
	{
		public GameObject Obj;
		public double Time;
		//
		public void Clear()
		{
			UnityEngine.Object.Destroy(Obj);
			//for (int iter = 0; iter < _loaderList.Count; ++iter)
			//{
			//	_loaderList[iter].End();
			//}
			//_loaderList.Clear();
		}
		//
		//public void EndLoader(ResourceRequestInterface loader)
		//{
		//	loader.PauseWorking(true);
		//	_loaderList.Add(loader);
		//}
		//
		public void EndLoader()
		{

		}
		//
		//public List<ResourceRequestInterface> _loaderList = new List<ResourceRequestInterface>();
	}

	public static Node Add(GameObject obj, float delay)
	{
		Node newNode = AllocNode();
		newNode.Obj = obj;
		newNode.Time = ViTimerVisualInstance.Time + delay;
		_workingList.Add(newNode);
		return newNode;
	}

	public static void Clear()
	{
		for (int iter = _workingList.Count - 1; iter >= 0; --iter)
		{
			Node iterNode = _workingList[iter];
			iterNode.Clear();
		}
		_workingList.Clear();
		_cacheList.Clear();
	}

	public static void Update(float deltaTime)
	{
		double time = ViTimerVisualInstance.Time;
		for (int iter = _workingList.Count - 1; iter >= 0; --iter)
		{
			Node iterNode = _workingList[iter];
			if (iterNode.Time < time)
			{
				iterNode.Clear();
				_workingList.RemoveAt(iter);
				FreeNode(iterNode);
			}
		}
	}

	static Node AllocNode()
	{
		if (_cacheList.Count > 0)
		{
			Node node = _cacheList[_cacheList.Count - 1];
			_cacheList.RemoveAt(_cacheList.Count - 1);
			return node;
		}
		else
		{
			return new Node();
		}
	}

	static void FreeNode(Node node)
	{
		_cacheList.Add(node);
	}

	static List<Node> _workingList = new List<Node>();
	static List<Node> _cacheList = new List<Node>();
}