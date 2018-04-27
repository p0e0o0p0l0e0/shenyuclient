using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveDestHinter_OnceExpress
{
	public bool Active { get { return _endTimeNode.IsAttach(); } }
	public GameObject Object { get { return _object; } }
	public void Start(ViVector3 pos, GameObject gameobject, float duration)
	{
		if (_object == null)
		{
			_object = UnityAssisstant.Instantiate(gameobject, pos.Convert(), Quaternion.identity);
		}
		else
		{
			_object.SetActive(true);
			_object.transform.localPosition = pos.Convert();
		}
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnTimeEnd);
	}
	void OnTimeEnd(ViTimeNodeInterface node)
	{
		_object.SetActive(false);
	}
	public void Clear()
	{
		UnityAssisstant.Destroy(ref _object);
	}
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	GameObject _object;
}

public class MoveDestHinter
{
	public static MoveDestHinter Instance { get { return _instance; } }
	static MoveDestHinter _instance = new MoveDestHinter();

	public void Start(ViVector3 pos)
	{
		GlobalGameObject.Instance.MoveDestHintLoop.GameObject.SetActive(false);
		GlobalGameObject.Instance.MoveDestHintLoop.GameObject.transform.localPosition = pos.Convert();
		GlobalGameObject.Instance.MoveDestHintLoop.GameObject.SetActive(true);
		UnityAssisstant.Rewind(GlobalGameObject.Instance.MoveDestHintLoop.GameObject);
		//
		ActiveOnceExpress(pos, 2.0f);
	}

	public void End()
	{
		GlobalGameObject.Instance.MoveDestHintLoop.GameObject.SetActive(false);
	}

	void ActiveOnceExpress(ViVector3 pos, float duration)
	{
		for (int iter = 0; iter < _onceExpressList.Count; ++iter)
		{
			MoveDestHinter_OnceExpress iterExpress = _onceExpressList[iter];
			if (iterExpress.Active == false)
			{
				iterExpress.Start(pos, GlobalGameObject.Instance.MoveDestHintOnce.GameObject, duration);
				return;
			}
		}
		MoveDestHinter_OnceExpress onceExpress = new MoveDestHinter_OnceExpress();
		onceExpress.Start(pos, GlobalGameObject.Instance.MoveDestHintOnce.GameObject, duration);
		GameObjectPath.AppendTo(onceExpress.Object, GameObjectPath.Instance.MoveDestHinter);
		_onceExpressList.Add(onceExpress);
	}

	List<MoveDestHinter_OnceExpress> _onceExpressList = new List<MoveDestHinter_OnceExpress>();
}
