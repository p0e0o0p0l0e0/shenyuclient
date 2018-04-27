using UnityEngine;
using System.Collections;

public class CameraFrustum : MonoBehaviour
{
	public float Distance = 1.0f;

	void Awake()
	{
		_meshFilter = gameObject.GetComponent<MeshFilter>();
		_orginQuaternion = gameObject.transform.rotation;
		_orginScale = gameObject.transform.localScale;
		if (_meshFilter != null && _meshFilter.mesh != null)
		{
			_height = _meshFilter.mesh.bounds.size.z * gameObject.transform.localScale.z;
			_width = _meshFilter.mesh.bounds.size.y * gameObject.transform.localScale.y;
		}
	}

	void OnWillRenderObject()
	{
		if (_meshFilter == null || _meshFilter.mesh == null)
		{
			return;
		}
		//
		Camera camera = Camera.current;
		Quaternion cameraRat = camera.transform.rotation;
		if (camera.orthographic)
		{
			gameObject.transform.position = camera.transform.position + camera.transform.forward * Distance;
			gameObject.transform.rotation = cameraRat * _orginQuaternion;
			float height = camera.orthographicSize * 2;
			float width = height * camera.aspect;
			gameObject.transform.localScale = new Vector3(_orginScale.x, width / _width * _orginScale.y, height / _height * _orginScale.z);
		}
		else
		{
			float frustumHeight = 2 * Distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
			float frustumWidth = frustumHeight * camera.aspect;
			gameObject.transform.position = camera.transform.position + camera.transform.forward * Distance;
			gameObject.transform.rotation = cameraRat * _orginQuaternion;
			gameObject.transform.localScale = new Vector3(_orginScale.x, frustumWidth / _width * _orginScale.y, frustumHeight / _height * _orginScale.z);
		}
	}

	float _width;
	float _height;
	Vector3 _orginScale;
	MeshFilter _meshFilter;
	Quaternion _orginQuaternion;
}
