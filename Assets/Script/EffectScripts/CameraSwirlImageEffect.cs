using UnityEngine;
using System.Collections;
using System;

public class CameraSwirlImageEffect : MonoBehaviour
{
	public float Angle = 70.0f;
	public float Range = 1.0f;
	public float DeltaTimeScale = 2.0f;
	public Vector4 Center = new Vector4(0.5f, 0.8f, 0.0f, 0.0f);
	public SwirlStep CurrentStep = SwirlStep.IN;
	[Range(0.0f, 1.0f)]
	public float SampleDist = 0.17f;
	[Range(1.0f, 5.0f)]
	public float SampleStrength = 2.09f;
	public float LocalScale = 1.0f;
	public float DelayUpdatePosTime = 0.5f;
	public float DelaySwirlTime = 0.5f;
	public AnimationCurve LocalScaleUpdateCure = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 1f), new Keyframe(0.9f, 0.8f), new Keyframe(1f, 0.8f));
	public Action OnSwirlOutCompleteCallback;
	public AnimationCurve SpotLightCure = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 1f), new Keyframe(0.9f, 0.8f), new Keyframe(1f, 0.8f));
	public float SpotLightDuration = 6.0f;
	//
	public void UpdateSwirlInfo()
	{
		Clear();
		if (CurrentStep == SwirlStep.IN)
		{
			_DrawTexture();
		}
		else
		{
			_CreateSpotLight();
		}
	}

	Texture2D _CaptureCamera(Camera camera, Rect rect)
	{
		RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
		camera.targetTexture = rt;
		camera.Render();
		RenderTexture.active = rt;
		Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
		screenShot.ReadPixels(rect, 0, 0);
		screenShot.Apply();
		camera.targetTexture = null;
		RenderTexture.active = null;
		GameObject.Destroy(rt);
		return screenShot;
	}

	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh();
		Vector3[] vertices = new Vector3[]
        {
            new Vector3( 1, 1,  0),
            new Vector3( 1, -1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(-1, -1, 0),
        };
		UnityEngine.Vector2[] uv = new UnityEngine.Vector2[]
        {
            new UnityEngine.Vector2(1, 1),
            new UnityEngine.Vector2(1, 0),
            new UnityEngine.Vector2(0, 1),
            new UnityEngine.Vector2(0, 0),
        };
		int[] triangles = new int[]
        {
            0, 1, 2,
            2, 1, 3,
        };
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		return mesh;
	}

	void _DrawTexture()
	{
		if (_mat == null)
		{
			_mat = new Material(Shader.Find("Fate Shading/Swirl"));
		}
		//
		if (_mesh == null)
		{
			_mesh = CreateMesh();
		}
		//
		Camera camera = GetComponent<Camera>();
		_RT = _CaptureCamera(camera, new Rect(0, 0, Screen.width, Screen.height));
		if (_swirlEffectObj == null)
		{
			_swirlEffectObj = (GameObject)new GameObject("SwirlEffect", typeof(MeshRenderer), typeof(MeshFilter));
		}
		//
		_swirlEffectObj.GetComponent<MeshFilter>().mesh = _mesh;
		_swirlEffectObj.GetComponent<Renderer>().sharedMaterial = _mat;
		SwirlImageEffect swirlEffect = _swirlEffectObj.AddComponent<SwirlImageEffect>();
		_swirlEffectObj.SetActive(true);
		_swirlEffectObj.layer = (int)UnityLayer.UI;
		if (camera != null)
		{
			float height = camera.orthographicSize * 2;
			float width = height * camera.aspect;
			_swirlEffectObj.transform.localScale = new Vector3(width / _mesh.bounds.size.x, height / _mesh.bounds.size.y, 1.0f);
		}
		//
		swirlEffect.CurrentStep = CurrentStep;
		swirlEffect.Angle = Angle;
		swirlEffect.DeltaTimeScale = DeltaTimeScale;
		swirlEffect.Range = Range;
		swirlEffect.Center = Center;
		swirlEffect.SampleDist = SampleDist;
		swirlEffect.SampleStrength = SampleStrength;
		swirlEffect.LocalScale = LocalScale;
		swirlEffect.DelayUpdatePosTime = DelayUpdatePosTime;
		swirlEffect.DelaySwirlTime = DelaySwirlTime;
		swirlEffect.LocalScaleCure = LocalScaleUpdateCure;
		swirlEffect.OnSwirlOutComplete = OnSwirlOutComplete;
		if (_mat != null)
		{
			_mat.SetTexture("_SwirlTexture", _RT);
		}
		//
	}

	void OnSwirlOutComplete()
	{
		Clear();
		if (OnSwirlOutCompleteCallback != null)
		{
			OnSwirlOutCompleteCallback();
			OnSwirlOutCompleteCallback = null;
		}
	}

	void _ScreenShot()
	{
		int width = Screen.width;
		int height = Screen.height;
		_RT = new Texture2D(width, height, TextureFormat.RGB24, false);
		_RT.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		_RT.Apply();
	}

	void _CreateSpotLight()
	{
		if (_mesh == null)
		{
			_mesh = CreateMesh();
		}
		//
		if (_mat == null)
		{
			_mat = new Material(Shader.Find("Fate Shading/TintColor Cover Always"));
		}
		//
		if (_swirlEffectObj == null)
		{
			_swirlEffectObj = (GameObject)new GameObject("SwirlEffect", typeof(MeshRenderer), typeof(MeshFilter));
		}
		//
		_swirlEffectObj.GetComponent<MeshFilter>().mesh = _mesh;
		_swirlEffectObj.GetComponent<Renderer>().material = _mat;
		SpotLightScript spotLightScript = _swirlEffectObj.AddComponent<SpotLightScript>();
		_swirlEffectObj.SetActive(true);
		_swirlEffectObj.layer = (int)UnityLayer.UI;
		Camera camera = GetComponent<Camera>();
		if (camera != null)
		{
			float height = camera.orthographicSize * 2;
			float width = height * camera.aspect;
			_swirlEffectObj.transform.localScale = new Vector3(width / _mesh.bounds.size.x, height / _mesh.bounds.size.y, 1.0f);
		}
		//
		spotLightScript.LightPower = SpotLightCure;
		spotLightScript.DurationTime = SpotLightDuration;
		spotLightScript.Density = 1.0f;
		spotLightScript.IsActive = true;
		spotLightScript.OnSpotLightEndCallback = this.OnSwirlOutComplete;
	}

	public void Clear()
	{
		if (_RT != null)
		{
			DestroyImmediate(_RT);
			_RT = null;
		}
		if (_swirlEffectObj != null)
		{
			DestroyImmediate(_swirlEffectObj);
			_swirlEffectObj = null;
		}
		if (_mesh != null)
		{
			DestroyImmediate(_mesh);
			_mesh = null;
		}
		if (_mat != null)
		{
			DestroyImmediate(_mat);
			_mat = null;
		}
	}

	Texture2D _RT;
	Material _mat;
	Mesh _mesh;
	GameObject _swirlEffectObj;
}