using UnityEngine;
using System.Collections.Generic;
using System;

public interface CameraPosDirInterface
{
	ViVector3 Position { get; }
	ViVector3 LookAt { get; }
	float Distance { get; set; }
	float Field { get; }
	void Update(float deltaTime);
}


public class CameraPosDirNode
{
	public CameraPosDirInterface PosDir;
	public Int32 Weight;
	public string Name;
	public bool Active;
}

public class CameraController
{
	public static ViConstValue<float> VALUE_CameraShakeStandardDistance = new ViConstValue<float>("CameraShakeStandardDistance", 20.0f);
	public static ViConstValue<float> VALUE_CameraShakeScale = new ViConstValue<float>("CameraShakeScale", 1.0f);
	public static ViConstValue<float> VALUE_CameraMinSpeed = new ViConstValue<float>("CameraMinSpeed", 0.0f);
	public static ViConstValue<float> VALUE_CameraMaxSpeed = new ViConstValue<float>("CameraMaxSpeed", 1.0f);
	public static ViConstValue<float> VALUE_CameraAccelerate = new ViConstValue<float>("CameraAccelerate", 0.0f);
	public static ViConstValue<float> VALUE_CameraFieldMinSpeed = new ViConstValue<float>("CameraFieldMinSpeed", 0.0f);
	public static ViConstValue<float> VALUE_CameraFieldMaxSpeed = new ViConstValue<float>("CameraFieldMaxSpeed", 0.0f);
	public static ViConstValue<float> VALUE_CameraFieldAccelerate = new ViConstValue<float>("CameraFieldAccelerate", 0.0f);

	public static CameraController Instance { get { ViDebuger.AssertError(_instance); return _instance; } }
	static CameraController _instance = new CameraController();

	public Camera Camera { get { return _camera; } }
	public CameraSpringShaker SpringShaker { get { return _shaker0; } }
	public CameraRandomShaker RandomShaker { get { return _shaker1; } }
	public CameraPosDirInterface CameraPosDir { get { return _posDir; } }
    public bool IsPlayStoryCam { get; set; }

	public void Clear()
	{
		_camera = null;
		_cameraTran = null;
		_posDirList.Clear();
		_posDir = null;
	}

	public float ShakeScale(ViVector3 pos)
	{
		if (CameraPosDir != null)
		{
			float distance = ViVector3.Distance(CameraPosDir.LookAt, pos);
			return ViMathDefine.Max(1.0f - distance / VALUE_CameraShakeStandardDistance, 0.0f) * VALUE_CameraShakeScale;
		}
		else
		{
			return 1.0f;
		}
	}

	public void SetCamera(Camera camera, Transform tran)
	{
		_camera = camera;

        _cameraTran = tran;
       // _cameraTran.position = (new Vector3(-8.11f, 3.47f, -3.01f));
       // _cameraTran.eulerAngles = new Vector3(11.34266f, 95.24854f, 1.035052f);

       // _cameraTran = cameraTran;
		//_skyBox = skyBox;
		//
		_posSmooth.MinSpeed = VALUE_CameraMinSpeed;
		_posSmooth.MaxSpeed = VALUE_CameraMaxSpeed;
		_posSmooth.Accelerate = VALUE_CameraAccelerate;
		_lootAtSmooth.MinSpeed = VALUE_CameraMinSpeed;
		_lootAtSmooth.MaxSpeed = VALUE_CameraMaxSpeed;
		_lootAtSmooth.Accelerate = VALUE_CameraAccelerate;
		_fieldSmooth.MinSpeed = VALUE_CameraFieldMinSpeed;
		_fieldSmooth.MaxSpeed = VALUE_CameraFieldMaxSpeed;
		_fieldSmooth.Accelerate = VALUE_CameraFieldAccelerate;
		//
		Update(0.0f, true);
	}

	public void Update(float deltaTime)
	{
		Update(deltaTime, false);
	}
	public void Update(float deltaTime, bool force)
	{
		if (_posDir != null && _camera != null && _cameraTran != null)
		{
			_posDir.Update(deltaTime);
			//
			//_posSmooth.Update(_posDir.Position, deltaTime);
			//_lootAtSmooth.Update(_posDir.LookAt, deltaTime);
			//_fieldSmooth.Update(_posDir.Field, deltaTime);
			//
			_shaker0.Update(deltaTime);
			_shaker1.Update(deltaTime);
			//
			ViVector3 pos = _posSmooth.Value + _shaker0.Offset + _shaker1.Offset;
			ViVector3 lookAt = _lootAtSmooth.Value + _shaker0.LookAtOffset + _shaker1.LookAtOffset;
			if ((pos != _lastPos || lookAt != _lastLookAt) || !IsPlayStoryCam)
			{
                _cameraTran.localPosition = _posDir.Position.Convert();
                _cameraTran.LookAt(_posDir.LookAt.Convert());
                if (_cameraTran != null)
                {
                    _cameraTran.localPosition = _posDir.Position.Convert();
                }
                ViVector3 direction = _lootAtSmooth.Value - _posSmooth.Value;
                direction.z = 0;
                direction.Normalize();
                UnityAssisstant.CameraYaw = ViGeographicObject.GetDirection(direction.x, direction.y);
                UnityAssisstant.CameraRotation = _cameraTran.rotation;
                _lastPos = pos;
                _lastLookAt = lookAt;
            }
            //
            float field = _fieldSmooth.Value;
            if (_lastField != field || force)
            {
                _camera.fieldOfView = field;
                _lastField = field;
            }
        }
	}

	public void SmoothImmediate()
	{
		_posSmooth.StopAt(_posDir.Position);
		_lootAtSmooth.StopAt(_posDir.LookAt);
		_fieldSmooth.StopAt(_posDir.Field);
	}

    public void StopAt(float fDistance)
    {
        _fieldSmooth.StopAt(fDistance);
    }

	CameraPosDirInterface GetTopCamera()
	{
		Int32 weight = 0;
		CameraPosDirInterface topPosDir = null;
		foreach (CameraPosDirNode iterNode in _posDirList)
		{
			if (!iterNode.Active)
			{
				continue;
			}
			if (iterNode.Weight > weight)
			{
				weight = iterNode.Weight;
				topPosDir = iterNode.PosDir;
			}
		}
		return topPosDir;
	}

	public void AddController(string name, Int32 weight, CameraPosDirInterface posDir)
	{
		CameraPosDirNode node = null;
		foreach (CameraPosDirNode iterNode in _posDirList)
		{
			if (iterNode.Name == name)
			{
				node = iterNode;
				break;
			}
		}
		//
		if (node == null)
		{
			node = new CameraPosDirNode();
			_posDirList.Add(node);
		}
		//
		node.Weight = weight;
		node.Active = true;
		node.Name = name;
		node.PosDir = posDir;
		//
		_posDir = GetTopCamera();
	}

	public void DelController(string name)
	{
		for (Int32 iter = 0; iter < _posDirList.Count; ++iter)
		{
			if (_posDirList[iter].Name == name)
			{
				_posDirList.RemoveAt(iter);
			}
		}
		//
		_posDir = GetTopCamera();
	}

	public void SetControllerState(string name, bool active)
	{
		for (Int32 iter = 0; iter < _posDirList.Count; ++iter)
		{
			if (_posDirList[iter].Name == name)
			{
				_posDirList[iter].Active = active;
				break;
			}
		}
		//
		_posDir = GetTopCamera();
	}

	public CameraPosDirInterface GetController(string name)
	{
		for (Int32 iter = 0; iter < _posDirList.Count; ++iter)
		{
			if (_posDirList[iter].Name == name)
			{
				return _posDirList[iter].PosDir;
			}
		}
		return null;
	}

	Camera _camera;
	Transform _cameraTran;
    //Transform cameraTran;
    //Transform _skyBox;

    List<CameraPosDirNode> _posDirList = new List<CameraPosDirNode>();
	CameraPosDirInterface _posDir;
	ViVector3 _lastPos;
	ViVector3Interpolation _posSmooth = new ViVector3Interpolation();
	ViVector3 _lastLookAt;
	ViVector3Interpolation _lootAtSmooth = new ViVector3Interpolation();
	float _lastField;
	ViValueInterpolation _fieldSmooth = new ViValueInterpolation();
	CameraSpringShaker _shaker0 = new CameraSpringShaker();
	CameraRandomShaker _shaker1 = new CameraRandomShaker();
}