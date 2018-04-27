using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RealTimeMirror : MonoBehaviour
{
	public Camera MianCamera;
	public bool DisablePixelLights = true;
	public int TextureSize = 256;
	public float ClipPlaneOffset = 0.00f;
	public bool IsFlatMirror = true;
	public bool IsRenderOnce = false;

	public void OnWillRenderObject()
	{
		if (!enabled || !GetComponent<Renderer>() || !GetComponent<Renderer>().sharedMaterial || !GetComponent<Renderer>().enabled)
		{
			return;
		}
		Camera cam = MianCamera;
		if (!cam)
		{
			return;
		}
		if (_isRender)
		{
			return;
		}
		//
		_isRender = true;
		//
		_CreateMirrorObjects(cam, ref _reflectionCamera);
		Vector3 pos = transform.position;
		Vector3 normal;
		if (IsFlatMirror)
		{
			normal = transform.up;
		}
		else
		{
			normal = transform.position - cam.transform.position;
			normal.Normalize();
		}
		//
		int oldPixelLightCount = QualitySettings.pixelLightCount;
		if (DisablePixelLights)
		{
			QualitySettings.pixelLightCount = 0;
		}
		//
		_UpdateCameraModes(cam, _reflectionCamera);
		float d = -Vector3.Dot(normal, pos) - ClipPlaneOffset;
		Vector4 reflectionPlane = new Vector4(normal.x, normal.y, normal.z, d);
		Matrix4x4 reflection = Matrix4x4.zero;
		_CalculateReflectionMatrix(ref reflection, reflectionPlane);
		Vector3 oldpos = cam.transform.position;
		Vector3 newpos = reflection.MultiplyPoint(oldpos);
		_reflectionCamera.worldToCameraMatrix = cam.worldToCameraMatrix * reflection;
		Vector4 clipPlane = _CameraSpacePlane(_reflectionCamera, pos, normal, 1.0f);
		Matrix4x4 projection = cam.projectionMatrix;
		_CalculateObliqueMatrix(ref projection, clipPlane);
		_reflectionCamera.projectionMatrix = projection;
		_reflectionCamera.cullingMask = (int)UnityLayer.MIRROR_SHADOW_MASK;
		_reflectionCamera.clearFlags = CameraClearFlags.SolidColor;
		_reflectionCamera.backgroundColor = Color.black;
		_reflectionCamera.targetTexture = _reflectionTexture;
		GL.invertCulling = true;
		_reflectionCamera.transform.position = newpos;
		Vector3 euler = cam.transform.eulerAngles;
		_reflectionCamera.transform.eulerAngles = new Vector3(0, euler.y, euler.z);
		_reflectionCamera.Render();
		_reflectionCamera.transform.position = oldpos;
		GL.invertCulling = false;
		Material[] materials = GetComponent<Renderer>().sharedMaterials;
		for (int iter = 0; iter < materials.Length; ++iter)
		{
			Material iterMaterial = materials[iter];
			if (iterMaterial.HasProperty("_RefTex"))
			{
				iterMaterial.SetTexture("_RefTex", _reflectionTexture);
			}
		}
		if (DisablePixelLights)
		{
			QualitySettings.pixelLightCount = oldPixelLightCount;
		}
		//
		_isRender = IsRenderOnce;
	}

	void OnDisable()
	{
		if (_reflectionTexture)
		{
			_reflectionTexture.Release();
			DestroyImmediate(_reflectionTexture);
			_reflectionTexture = null;
		}
		//
		if (_reflectionCamera != null)
		{
			DestroyImmediate(_reflectionCamera.gameObject);
		}
	}

	void _CreateMirrorObjects(Camera currentCamera, ref Camera reflectionCamera)
	{
		if (_reflectionTexture == null || _oldReflectionTextureSize != TextureSize)
		{
			if (_reflectionTexture)
			{
				_reflectionTexture.Release();
				DestroyImmediate(_reflectionTexture);
			}
			//
			_reflectionTexture = new RenderTexture(TextureSize, TextureSize, 16);
			_reflectionTexture.name = "__MirrorReflection" + GetInstanceID();
			_reflectionTexture.isPowerOfTwo = true;
			_oldReflectionTextureSize = TextureSize;
		}
		//
		if (_reflectionCamera == null)
		{
			GameObject go = new GameObject("Mirror Refl Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(), typeof(Camera), typeof(Skybox));
			reflectionCamera = go.GetComponent<Camera>();
			reflectionCamera.enabled = false;
			reflectionCamera.transform.position = transform.position;
			reflectionCamera.transform.rotation = transform.rotation;
			_reflectionCamera = reflectionCamera;
		}
	}

	void _UpdateCameraModes(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		//
		dest.clearFlags = src.clearFlags;
		dest.backgroundColor = src.backgroundColor;
		if (src.clearFlags == CameraClearFlags.Skybox)
		{
			Skybox sky = src.GetComponent<Skybox>();
			Skybox mysky = dest.GetComponent<Skybox>();
			if (!sky || !sky.material)
			{
				mysky.enabled = false;
			}
			else
			{
				mysky.enabled = true;
				mysky.material = sky.material;
			}
		}
		//
		dest.farClipPlane = src.farClipPlane;
		dest.nearClipPlane = src.nearClipPlane;
		dest.orthographic = src.orthographic;
		dest.fieldOfView = src.fieldOfView;
		dest.aspect = src.aspect;
		dest.orthographicSize = src.orthographicSize;
		dest.renderingPath = src.renderingPath;
	}

	#region 斜视锥体深度投影和裁剪
	static float _sgn(float a)
	{
		if (a > 0.0f) return 1.0f;
		if (a < 0.0f) return -1.0f;
		return 0.0f;
	}

	Vector4 _CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 offsetPos = pos + normal * ClipPlaneOffset;
		Matrix4x4 m = cam.worldToCameraMatrix;
		Vector3 cpos = m.MultiplyPoint(offsetPos);
		Vector3 cnormal = m.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(cnormal.x, cnormal.y, cnormal.z, -Vector3.Dot(cpos, cnormal));
	}

	static void _CalculateObliqueMatrix(ref Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 q = projection.inverse * new Vector4(
			_sgn(clipPlane.x),
			_sgn(clipPlane.y),
			1.0f,
			1.0f
		);
		Vector4 c = clipPlane * (2.0f / (Vector4.Dot(clipPlane, q)));
		projection[2] = c.x - projection[3];
		projection[6] = c.y - projection[7];
		projection[10] = c.z - projection[11];
		projection[14] = c.w - projection[15];
	}
	#endregion

	#region 反射矩阵
	static void _CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = (1f - 2f * plane[0] * plane[0]);
		reflectionMat.m01 = (-2f * plane[0] * plane[1]);
		reflectionMat.m02 = (-2f * plane[0] * plane[2]);
		reflectionMat.m03 = (-2f * plane[3] * plane[0]);
		//
		reflectionMat.m10 = (-2f * plane[1] * plane[0]);
		reflectionMat.m11 = (1f - 2f * plane[1] * plane[1]);
		reflectionMat.m12 = (-2f * plane[1] * plane[2]);
		reflectionMat.m13 = (-2f * plane[3] * plane[1]);
		//
		reflectionMat.m20 = (-2f * plane[2] * plane[0]);
		reflectionMat.m21 = (-2f * plane[2] * plane[1]);
		reflectionMat.m22 = (1f - 2f * plane[2] * plane[2]);
		reflectionMat.m23 = (-2f * plane[3] * plane[2]);
		//
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
	}
	#endregion

	RenderTexture _reflectionTexture = null;
	int _oldReflectionTextureSize = 0;
	bool _isRender = false;
	Camera _reflectionCamera = null;
}
