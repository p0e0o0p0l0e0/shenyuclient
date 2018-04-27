using System;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0219 //变量已赋值，但其值从未使用过;

public interface PickalbeInterface
{
	void OnFocusOn();
	void OnFocusOff();
	void OnPressed();
	void OnReleased();
	void OnMove();
}

public static class PickAssisstant
{
	public static ViVector3 GetDefaultPick(float defaultHeight)
	{
		Camera camera = GlobalGameObject.Instance.SceneCamera;
		if (camera == null)
		{
			return ViVector3.ZERO;
		}
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		return (ray.origin + (defaultHeight - ray.origin.y) / ray.direction.y * ray.direction).Convert();
	}

	public static bool Pick(Collider collder)
	{
		Camera camera = GlobalGameObject.Instance.SceneCamera;
		if (camera == null)
		{
			return false;
		}
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitResult;
		if (collder.Raycast(ray, out hitResult, 100.0f))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public static Vector3 OffsetCamera2World(Vector3 rootPos, Vector3 cameraOffset)
	{
		Transform cameraTran = GlobalGameObject.Instance.SceneCamera.transform;
		Vector3 cameraPos = cameraTran.position;
		Vector3 lookDir = rootPos - cameraPos;
		lookDir.Normalize();
		Ray ray = new Ray(cameraTran.TransformPoint(cameraOffset), lookDir);
		Vector3 lookAtPos = (ray.origin + (rootPos.y - ray.origin.y) / ray.direction.y * ray.direction);
		return lookAtPos - rootPos;
	}

}

public class PickableNode
{
	public PickalbeInterface Entity { get { return _entity; } }
	public Collider Collider { get { return _collider; } }
	public bool Active { get { return _pickAttachNode.IsAttach(); } }
	public float Distance { get { return _distance; } }

	public void Start(GameObject gameobj, PickalbeInterface entity)
	{
		_entity = entity;
		_collider = gameobj.GetComponentInChildren<Collider>();
        if(_collider == null)
        {
            _collider = gameobj.AddComponent<BoxCollider>();
            _collider.isTrigger = true;
        }
            
   
        ViDebuger.AssertError(_collider);
		_pickAttachNode.Data = this;
		PickManager.Instance.Attach(_pickAttachNode, this);
	}

	public void End()
	{
		_pickAttachNode.Detach();
		_pickAttachNode.Data = null;
		_entity = null;
		_collider = null;
	}

	public bool Pick(Ray ray)
	{
		RaycastHit hitResult;
		if (_collider.Raycast(ray, out hitResult, 100.0f))
		{
			_distance = hitResult.distance;
            Debug.DrawLine(ray.origin, hitResult.point, Color.red);

            return true;
		}
		else
		{
			_distance = float.MaxValue;
			return false;
		}
	}

	PickalbeInterface _entity;
	Collider _collider;
	float _distance = float.MaxValue;
	ViDoubleLinkNode2<PickableNode> _pickAttachNode = new ViDoubleLinkNode2<PickableNode>();
}

public class PickManager
{
	public static PickManager Instance { get { return _instance; } }
	static PickManager _instance = new PickManager();

	public PickalbeInterface Entity
	{
		get
		{
			if (_lockEntity != null)
			{
				return _lockEntity;
			}
			else
			{
				return _focusEntity;
			}
		}
	}

	List<PickableNode> CACHE_entityList = new List<PickableNode>();
	public void Update()
	{
		Camera camera = GlobalGameObject.Instance.SceneCamera;
		if (camera == null)
		{
			return;
		}
		if (_lockEntity != null || GameApplication.Instance.IsEditor)
		{
			return;
		}
        //
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition * (1.0f * camera.targetTexture.width / Screen.width));
		PickalbeInterface oldEntity = Entity;
		//
		CACHE_entityList.Clear();
		GetEntityByLevel0(ray, CACHE_entityList);
		//
		if (CACHE_entityList.Count == 0)
		{
			_focusEntity = null;
			SendCallback(oldEntity);
			return;
		}
		//
		if (CACHE_entityList.Count == 1)
		{
			_focusEntity = CACHE_entityList[0].Entity;
			SendCallback(oldEntity);
			return;
		}
		//
		PickalbeInterface entity = GetEntityByLevel1(CACHE_entityList);
		if (entity != null)
		{
			_focusEntity = entity;
			SendCallback(oldEntity);
			return;
		}
	}

	public void Lock(bool active)
	{
		if (active)
		{
			_lockEntity = _focusEntity;
		}
		else
		{
			_lockEntity = null;
		}
	}

	public void BreakCurrentEntity()
	{
		PickalbeInterface oldEntity = Entity;
		if (oldEntity != null)
		{
			_focusEntity = null;
			_lockEntity = null;
			SendCallback(oldEntity);
		}
	}

	public void Attach(ViDoubleLinkNode2<PickableNode> node, PickableNode obj)
	{
		_entityList.PushBack(node);
	}

	void SendCallback(PickalbeInterface oldEntity)
	{
		if (oldEntity != Entity)
		{
			if (oldEntity != null)
			{
				//ViDebuger.Note("FocusOff");
				oldEntity.OnFocusOff();
			}
			if (Entity != null)
			{
				//ViDebuger.Note("FocusOn");
				Entity.OnFocusOn();
			}
		}
	}

	void GetEntityByLevel0(Ray ray, List<PickableNode> entityList)
	{
		ViDoubleLinkNode2<PickableNode> iter = _entityList.GetHead();
		while (!_entityList.IsEnd(iter))
		{
			PickableNode entity = iter.Data;
			ViDoubleLink2<PickableNode>.Next(ref iter);
			if (entity.Pick(ray))
			{
				entityList.Add(entity);
			}
		}
	}

	PickalbeInterface GetEntityByLevel1(List<PickableNode> list)
	{
		float minDistance = float.MaxValue;
		PickalbeInterface entity = null;
		for (int iter = 0; iter < list.Count; ++iter)
		{
			PickableNode iterNode = list[iter];
			ViDebuger.AssertError(iterNode);
			float distanceElement = 0.0f;
			if (iterNode.Distance < minDistance)
			{
				entity = iterNode.Entity;
				minDistance = iterNode.Distance;
			}
		}
		return entity;
	}

	ViDoubleLink2<PickableNode> _entityList = new ViDoubleLink2<PickableNode>();
	PickalbeInterface _focusEntity;
	PickalbeInterface _lockEntity;
}