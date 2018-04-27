using System;
using System.Collections.Generic;
using UnityEngine;

public class FxTrailRenderNode
{
	public Vector3 Position;
	public float LifeTime;
	public Vector3 UP;
	public float Distance;
	public Vector3 Offset = Vector3.zero;

	public FxTrailRenderNode()
	{

	}

	public FxTrailRenderNode(Vector3 worldPosition, float lifeTime)
	{
		Position = worldPosition;
		LifeTime = lifeTime;
	}
}

[ExecuteInEditMode]
public class FxTrailRender : MonoBehaviour
{
	public AnimationCurve SizeOverLife = new AnimationCurve();
	public Gradient ColorOverLife = new Gradient();

	public bool UsingSimpleColor = false;
	public Color SimpleColorOverLifeStart;
	public Color SimpleColorOverLifeEnd;

	public bool Random = false;
	public float RandomScale = 1.0f;

	public bool FaceCamera;
	public bool UseCustomAxis = false;
	public Vector3 Axis = new Vector3(0.0f, 1.0f, 0.0f);

	public Material Material;
	public float MinDistance = 0.2f;
	public float Time = 0.14f;

	public Int32 MaxVertexCount = 512;

	void Start()
	{
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			gameObject.AddComponent<MeshFilter>();
		}
		if (_mesh == null)
		{
			_mesh = new Mesh();
		}
		MeshRenderer meshRender = GetComponent<MeshRenderer>();
		if (meshRender == null)
		{
			gameObject.AddComponent<MeshRenderer>();
		}
		//
		meshFilter.mesh = _mesh;
		//
		_vertices = new Vector3[MaxVertexCount];
		_uvs = new Vector2[MaxVertexCount];
		_colors = new Color[MaxVertexCount];
		_triangles = new Int32[MaxVertexCount * 3 - 6];
		_TrailNodes = new List<FxTrailRenderNode>(MaxVertexCount / 2);
	}

	void OnWillRenderObject()
	{
		_UpdateNodes();
		_UpdateTrails();
		//Graphics.DrawMesh(_mesh, gameObject.transform.position, gameObject.transform.rotation, Material, gameObject.layer);
	}

	void _UpdateNodes()
	{
		Vector3 currentPosition = transform.position;
		if (_TrailNodes.Count == 0 || (Vector3.Magnitude(_TrailNodes[0].Position - currentPosition) >= MinDistance * MinDistance))
		{
			FxTrailRenderNode newNode = new FxTrailRenderNode();
			newNode.Position = currentPosition;
			newNode.LifeTime = Time;
			if (UseCustomAxis)
			{
				newNode.UP = transform.TransformDirection(Axis.normalized);
			}
			else
			{
				newNode.UP = transform.TransformDirection(Vector3.up);
			}
			//
			if (_TrailNodes.Count >= MaxVertexCount / 2)
			{
				_TrailNodes.RemoveAt(_TrailNodes.Count - 1);
			}
			//
			_TrailNodes.Insert(0, newNode);
		}
		//
		FxTrailRenderNode lastNode = _TrailNodes[0];
		lastNode.Distance = 0.0f;
		for (Int32 iter = 1; iter < _TrailNodes.Count; ++iter)
		{
			FxTrailRenderNode iterNode = _TrailNodes[iter];
			iterNode.Distance = Vector3.Distance(iterNode.Position, lastNode.Position) + lastNode.Distance;
			lastNode = iterNode;
		}
		//
		if (FaceCamera)
		{
			lastNode = _TrailNodes[0];
			for (Int32 iter = 1; iter < _TrailNodes.Count; ++iter)
			{
				FxTrailRenderNode iterNode = _TrailNodes[iter];
				Vector3 faceCameraDir = (Camera.current.transform.position - iterNode.Position).normalized;
				Vector3 dir = (iterNode.Position - lastNode.Position).normalized;
				Vector3 normal = (faceCameraDir - Vector3.Dot(faceCameraDir, dir) * dir).normalized;
				iterNode.UP = Vector3.Cross(dir, normal).normalized;
				if (iter == 1 || iter == _TrailNodes.Count - 1)
				{
					lastNode.UP = iterNode.UP;
				}
				lastNode = iterNode;
			}
		}
	}

	void _UpdateTrails()
	{
		if (_mesh == null)
		{
			return;
		}
		//
		_mesh.Clear(false);
		for (Int32 iter = _TrailNodes.Count - 1; iter >= 0; --iter)
		{
			FxTrailRenderNode iterNode = _TrailNodes[iter];
			iterNode.LifeTime -= UnityEngine.Time.deltaTime;
			if (iterNode.LifeTime <= 0)
			{
				_TrailNodes.RemoveAt(iter);
			}
		}
		if (_TrailNodes.Count < 2)
		{
			return;
		}
		//
		Matrix4x4 localSpaceTransform = transform.worldToLocalMatrix;
		float farDistance = _TrailNodes[_TrailNodes.Count - 1].Distance;
		Int32 vertexIndex = 0;
		for (; vertexIndex < _TrailNodes.Count; ++vertexIndex)
		{
			FxTrailRenderNode iterNode = _TrailNodes[vertexIndex];
			float u = 0.0f;
			if (vertexIndex != 0)
			{
				u = UnityEngine.Mathf.Clamp01(iterNode.Distance / farDistance);
			}
			//
			float width = SizeOverLife.Evaluate(iterNode.LifeTime / Time);
			Vector3 offset = iterNode.UP * width;
			if (Random)
			{
				iterNode.Offset += UnityEngine.Random.onUnitSphere * UnityEngine.Time.deltaTime * RandomScale;
			}
			Int32 index =  2 * vertexIndex;
			_vertices[index] = localSpaceTransform.MultiplyPoint3x4(iterNode.Position + iterNode.Offset - offset);
			_vertices[index + 1] = localSpaceTransform.MultiplyPoint3x4(iterNode.Position + iterNode.Offset + offset);
			_uvs[index] = new Vector2(u, 0);
			_uvs[index + 1] = new Vector2(u, 1);
			Color color = UsingSimpleColor ? Color.Lerp(SimpleColorOverLifeEnd, SimpleColorOverLifeStart, iterNode.LifeTime) : ColorOverLife.Evaluate(iterNode.LifeTime / Time);
			_colors[index] = color;
			_colors[index + 1] = color;
		}
		//
		Vector3 finalPosition = _vertices[2 * vertexIndex - 1];
		for (; vertexIndex < MaxVertexCount / 2; ++vertexIndex)
		{
			Int32 index = 2 * vertexIndex;
			_vertices[index] = finalPosition;
			_vertices[index + 1] = finalPosition;
		}
		//
		Int32 triangleCount = _TrailNodes.Count * 6 - 6;
		for (int iter = 0; iter < triangleCount / 6; iter++)
		{
			Int32 index = iter * 2;
			Int32 index01 = iter * 6;
			_triangles[index01] = index;
			_triangles[index01 + 1] = index + 1;
			_triangles[index01 + 2] = index + 2;
			_triangles[index01 + 3] = index + 2;
			_triangles[index01 + 4] = index + 1;
			_triangles[index01 + 5] = index + 3;
		}
		//
		//Int32 Count = _TrailNodes.Count * 2;
		_mesh.vertices = _vertices;
		_mesh.uv = _uvs;
		_mesh.triangles = _triangles;
		_mesh.colors = _colors;
	}

	public void OnDestory()
	{
		if (_mesh != null)
		{
			GameObject.DestroyImmediate(_mesh);
		}
		//
		_TrailNodes.Clear();
	}

	Mesh _mesh;
	List<FxTrailRenderNode> _TrailNodes = new List<FxTrailRenderNode>();
	//
	Vector3[] _vertices;
	Vector2[] _uvs;
	int[] _triangles;
	Color[] _colors;
	Int32 _TrailNodesCount;
}
