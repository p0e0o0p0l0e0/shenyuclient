using System;
using System.Collections.Generic;
using UnityEngine;


public class GameObjectPath
{
	public static GameObjectPath Instance { get { return _instance; } }
	static GameObjectPath _instance = new GameObjectPath();

	public static void AppendTo(GameObject child, GameObject parent)
	{
		child.transform.parent = parent.transform;
	}

	public GameObject MoveDestHinter { get { return _moveDestHinter; } }
	public GameObject RouteHinter { get { return _routeHinter; } }
	public GameObject GlobalPath { get { return _globalPath; } }
	public GameObject NavigateShow { get { return _navigateShow; } }
	public GameObject SpaceHideSlot { get { return _spaceHideSlot; } }
	public GameObject SpaceBlockSlot { get { return _spaceBlockSlot; } }

	public void Start()
	{
		_globalPath = Create("GlobalPath");
		_moveDestHinter = Create("MoveDestHinter");
		_routeHinter = Create("RouteHinter");
		_navigateShow = Create("NavigateShow");
		_spaceHideSlot = Create("SpaceHideSlot");
		_spaceBlockSlot = Create("SpaceBlockSlot");
	}

	public void End()
	{

	}

	static GameObject Create(string name)
	{
		GameObject obj = new GameObject(name);
		obj.transform.localPosition = Vector3.zero;
		return obj;
	}

	GameObject _globalPath;
	GameObject _moveDestHinter;
	GameObject _routeHinter;
	GameObject _navigateShow;
	GameObject _spaceHideSlot;
	GameObject _spaceBlockSlot;
}