using System;
using System.Collections.Generic;
using UnityEngine;

public class VRViewer : MonoBehaviour
{
	public bool trackRotation = true;
	public bool trackPosition = true;
	public float neckModelScale = 0.0f;
	public float EyehalfWidth = 0.03f;
	//public Pose3D HeadPose;
	public Camera Camera;
	public Camera CameraLeft;
	public Camera CameraRight;
	public bool LookAt;
	public bool LookAtPhysics;
	public float LookAtDistance;
	public float LootAtDistanceSup = 100.0f;

	void OnEnable()
	{
		//_device.OnPause(false);
	}

	void OnDisable()
	{
		//_device.OnPause(true);
	}

	void OnApplicationPause(bool pause)
	{
		//_device.OnPause(pause);
	}

	void OnApplicationFocus(bool focus)
	{
		//_device.OnFocus(focus);
	}

	void OnApplicationQuit()
	{
		//_device.OnApplicationQuit();
	}

	void OnDestroy()
	{
		DestroyCamera(CameraLeft);
		DestroyCamera(CameraRight);
//#if !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
//        _device.SetVRModeEnabled(false);
//#endif  // !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
//        if (_device != null)
//        {
//            _device.Destroy();
//        }
	}

	public void InitDevice()
	{
//        if (_device != null)
//        {
//            _device.Destroy();
//        }
//        _device = VRDeviceCreator.CreateDevice();
//        _device.Init();
//        _device.SetDistortionCorrectionEnabled(false);
//        _device.SetNeckModelScale(neckModelScale);
//#if !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
//        _device.SetVRModeEnabled(true);
//#endif  // !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
//        _device.UpdateScreenData();
		//        //
		Camera.rect = new Rect(0, 0, 0.5f, 1.0f);
		CameraLeft = CreateCamera("LeftCamera", 0, -0.03f, Camera);
		CameraRight = CreateCamera("RightCamera", 0.5f, 0.03f, Camera);
		Camera.cullingMask = 0;
	}

	void Update()
	{

	}

	void LateUpdate()
	{
		//_device.UpdateState();
		//HeadPose = _device.GetHeadPose();
		//if (trackRotation)
		//{
		//    Quaternion rot = HeadPose.Orientation;
		//    transform.localRotation = rot;
		//}
		//if (trackPosition)
		//{
		//    Vector3 pos = HeadPose.Position;
		//    transform.localPosition = pos;
		//}
		//
		CameraLeft.fieldOfView = Camera.fieldOfView;
		CameraRight.fieldOfView = Camera.fieldOfView;
		UpdateLookAt();
	}

	void UpdateLookAt()
	{
		LookAtDistance = GetLookAtDistance();
		float angle = (float)Math.Atan2(EyehalfWidth, LookAtDistance) * 360.0f / 6.28f;
		CameraLeft.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
		CameraRight.transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.up);
	}

	float GetLookAtDistance()
	{
		if (!LookAt)
		{
			return float.MaxValue;
		}
		//
		RaycastHit hitInfo;
		if (LookAtPhysics && Physics.Raycast(transform.position, transform.forward, out hitInfo))
		{
			return Math.Min(hitInfo.distance, LootAtDistanceSup);
		}
		else
		{
			return LootAtDistanceSup;
		}
	}

	Camera CreateCamera(string name, float horizOffset, float eyeHalfDistance, Camera mainCamera)
	{
		Transform parentTran = mainCamera.transform.parent;
		GameObject obj = UnityAssisstant.Instantiate(mainCamera.gameObject, parentTran.position + new Vector3(eyeHalfDistance, 0, 0), parentTran.rotation);
		obj.name = name;
		obj.transform.parent = parentTran;
		//UnityAssisstant.DelComponent<PostFX>(obj);
		Camera halfCamera = obj.GetComponent<Camera>();
		halfCamera.rect = new Rect(horizOffset, 0, 0.5f, 1.0f);
		return halfCamera;
	}

	static void DestroyCamera(Camera camera)
	{
		if (camera != null)
		{
			GameObject.Destroy(camera.gameObject);
		}
	}

}