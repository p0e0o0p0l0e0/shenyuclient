using System;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera : CameraPosDirInterface
{
	public ViVector3 Position { get { return _position; } }
	public ViVector3 LookAt { get { return _lookAt; } }
	public float Distance { set { } get { return 1.0f; } }
	public float Field { get { return _field; } }
	public void Set(ViVector3 pos, ViVector3 lookAt, float field)
	{
		_position = pos;
		_lookAt = lookAt;
		_field = field;
	}
	public void Update(float deltaTime) { }

	ViVector3 _position;
	ViVector3 _lookAt;
	float _field;
}

public class ScriptCameraComponent : MonoBehaviour
{
	public Transform LookAt;
	public float Field = 60.0f;
	public Int32 Weight = 20;
	public string Name = "ScriptCamera";

	void OnEnable()
	{

	}

	void OnDisable()
	{
		if (_isActive)
		{
			CameraController.Instance.DelController(Name);
		}
	}

	void Update()
	{
		if (_isActive)
		{
			_camera.Set(transform.position.Convert(), LookAt.position.Convert(), Field);
			//
			UpdateHint();
		}
	}

	public GameObject HintPos;
	public GameObject HintTarget;
	void InitHint()
	{
		if (HintPos == null)
		{
			HintPos = UnityAssisstant.InstantiateAsChild(UnityAssisstant.DebugHint, transform);
		}
		if (HintTarget == null)
		{
			HintTarget = UnityAssisstant.InstantiateAsChild(UnityAssisstant.DebugHint, transform);
		}
	}

	void UpdateHint()
	{
		if (HintPos != null)
		{
			HintPos.transform.position = _camera.Position.Convert();
		}
		if (HintTarget != null)
		{
			HintTarget.transform.position = _camera.LookAt.Convert();
		}
	}


	public void UpdateActiveState(bool isActive)
	{
		_isActive = isActive;
		if (_isActive)
		{
			CameraController.Instance.AddController(Name, Weight, _camera);
			InitHint();
		}
	}

	ScriptCamera _camera = new ScriptCamera();
	bool _isActive = true;
}