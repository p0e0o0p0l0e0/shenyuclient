using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class Screenshot : MonoBehaviour
{
	public Material FullScreenMaterial
	{
		get
		{
			return _fullScreenMaterial;
		}
	}

	void Start()
	{
		_screenshotCamera = GetComponent<Camera>();
	}

	public void ScreenshotTexture()
	{
		if (_fullScreenMaterial == null)
		{
			_fullScreenMaterial = new Material(Shader.Find("Fate Shading/FullScreenColor"));
		}
		if (_mesh == null)
		{
			_mesh = CreateMesh();
		}
		if (_fullScreenObj == null)
		{
			_fullScreenObj = (GameObject)new GameObject("FullScreen", typeof(MeshRenderer), typeof(MeshFilter));
		}
		//
		_fullScreenObj.GetComponent<MeshFilter>().mesh = _mesh;
		_fullScreenObj.GetComponent<Renderer>().material = _fullScreenMaterial;
		if (_fullScreenMaterial)
		{
			_fullScreenMaterial.mainTexture = _Screenshot(_screenshotCamera, new Rect(0, 0, Screen.width, Screen.height));
		}
	}

	RenderTexture _Screenshot(Camera camera, Rect rect)
	{
		if (_screenshotTexture == null)
		{
			_screenshotTexture = new RenderTexture((int)rect.width, (int)rect.height, 0, RenderTextureFormat.ARGB32, 0);
		}
		//
		_screenshotTexture.DiscardContents();
		camera.targetTexture = _screenshotTexture;
		camera.Render();
		camera.targetTexture = null;
		return _screenshotTexture;
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

	void OnDisable()
	{

	}

	public void End()
	{
		if (_fullScreenObj != null)
		{
			GameObject.DestroyImmediate(_fullScreenObj);
			_fullScreenObj = null;
		}
	}

	public void Clear()
	{
		if (_screenshotTexture != null)
		{
			_screenshotTexture.Release();
			GameObject.DestroyImmediate(_screenshotTexture);
			_screenshotTexture = null;
		}
		if (_screenshotTexture != null)
		{
			_screenshotTexture.Release();
			GameObject.DestroyImmediate(_screenshotTexture);
			_screenshotTexture = null;
		}
		if (_mesh != null)
		{
			GameObject.DestroyImmediate(_mesh);
			_mesh = null;
		}
		if (_fullScreenMaterial != null)
		{
			GameObject.DestroyImmediate(_fullScreenMaterial);
			_fullScreenMaterial = null;
		}
		if (_fullScreenObj != null)
		{
			GameObject.DestroyImmediate(_fullScreenObj);
			_fullScreenObj = null;
		}
	}

	RenderTexture _screenshotTexture;
	Camera _screenshotCamera;
	GameObject _fullScreenObj;
	Material _fullScreenMaterial;
	Mesh _mesh;
}
