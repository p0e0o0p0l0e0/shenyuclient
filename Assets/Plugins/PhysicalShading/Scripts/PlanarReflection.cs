using System.Collections.Generic;
using UnityEngine;

namespace PhysicalShading
{
	[RequireComponent(typeof(GameObject))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Physical Shading/Planar Reflection")]
	[ExecuteInEditMode]
	public class PlanarReflection : MonoBehaviour
	{
		public int stencilRef = 0;
		public List<GameObject> staticAgents = new List<GameObject>();
		public Vector4 plane = new Vector4(0, 1, 0, 0);
		[Range(0.0f, 1.0f)]
		public float fade = 0.25f;
		[Range(0.0f, 10.0f)]
		public float gamma = 1.5f;

		public struct ManualRenderable
		{
			public Mesh mesh;
			public Matrix4x4 transform;
			public Material material;
			public int submeshIndex;
		}

		private ManualRenderable[] renderableAgents = null;

		private void _UpdateRenderables()
		{
			var renderableList = new List<ManualRenderable>();
			foreach (GameObject obj in staticAgents)
			{
				if (obj)
				{
					MeshFilter filter = obj.GetComponent<MeshFilter>();
					if (!filter) continue;
					Mesh mesh = filter.sharedMesh;
					if (!mesh) continue;
					Renderer renderer = obj.GetComponent<Renderer>();
					if (!renderer) continue;
					if (renderer.sharedMaterials == null) continue;
					for (int i = 0; i < mesh.subMeshCount; ++i)
					{
						if (i >= renderer.sharedMaterials.Length)
							break;
						var renderable = new ManualRenderable();
						renderable.mesh = mesh;
						renderable.transform = obj.transform.localToWorldMatrix;
						renderable.material = renderer.sharedMaterials[i];
						renderable.submeshIndex = i;
						renderableList.Add(renderable);
					}
				}
			}
			if (renderableList.Count > 0)
			{
				renderableAgents = renderableList.ToArray();
			}
			else
			{
				renderableAgents = null;
			}
		}

		private void OnWillRenderObject()
		{
			if (renderableAgents != null)
			{
				foreach (var agent in renderableAgents)
				{
					RenderPipeline.RenderMirror(agent.mesh, agent.transform, agent.material, agent.submeshIndex);
				}
			}
		}

#if UNITY_EDITOR

        private Material planeMaterial = null;

		public void SetPlane(Transform trans)
		{
			Vector3 pos = trans.position;
			Vector3 normal = trans.up;
			float d = -Vector3.Dot(normal, pos);
			plane.x = normal.x;
			plane.y = normal.y;
			plane.z = normal.z;
			plane.w = d;
			_Refresh();
		}

		private void OnEnable()
		{
			_Refresh();
		}

		private void OnDisable()
		{
			planeMaterial = null;
			_UpdatePlaneMaterials(gameObject);
		}

		private void OnValidate()
		{
			_Refresh();
		}

		private void _Refresh()
        {
            gameObject.layer = (int)RenderPipeline.SpecialLayer.LAYER_REF_PLANE;

			if (!planeMaterial)
			{
				planeMaterial = new Material(RenderPipeline.PlanarPlaneShader());
			}

			planeMaterial.SetInt("_Stencil", stencilRef);
            _UpdatePlaneMaterials(gameObject);
			_UpdateAgentMaterials();
			_UpdateRenderables();
		}

		private void _UpdatePlaneMaterials(GameObject obj)
		{
			if (obj)
			{
				Renderer renderer = obj.GetComponent<Renderer>();
				if (renderer) renderer.material = planeMaterial;
				foreach (Transform child in obj.transform)
				{
					_UpdatePlaneMaterials(child.gameObject);
				}
			}
		}

		private void _UpdateAgentMaterials()
		{
			foreach (GameObject agent in staticAgents)
			{
				if (agent)
				{
					Renderer renderer = agent.GetComponent<Renderer>();
					if (renderer && renderer.sharedMaterials != null)
					{
						var copiedMaterials = renderer.sharedMaterials;
						foreach (var mat in copiedMaterials)
						{
							mat.shader = RenderPipeline.PlanarMirrorShader();
							mat.SetInt("_Stencil", stencilRef);
							mat.SetVector("_MirrorPlane", plane);
							mat.SetVector("_MirrorParams", new Vector4(fade, gamma, 0, 0));
						}
						renderer.sharedMaterials = copiedMaterials;
					}
				}
			}
		}

#else
		private void Awake()
        {
			_UpdateRenderables();
		}

#endif

	}
}
