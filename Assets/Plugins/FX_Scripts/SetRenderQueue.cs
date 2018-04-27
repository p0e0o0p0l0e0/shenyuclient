using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetRenderQueue : MonoBehaviour
{
	public int mRendererQueue;
	ParticleSystem[] _renders;
	List<Material> _changedMaterials = new List<Material>();

	void Start ()
	{
		_renders = GetComponentsInChildren<ParticleSystem> ();

		for (int iter = 0; iter < _renders.Length; ++iter) 
		{
			Renderer tmpRender = _renders [iter].GetComponent<Renderer>();
			if(tmpRender !=null && tmpRender.enabled)
			{
				for (int index = 0; index < tmpRender.materials.Length; ++index) 
				{				
					Material tmpMaterial = tmpRender.materials [index];
					tmpMaterial.renderQueue = tmpMaterial.shader.renderQueue + mRendererQueue;
					_changedMaterials.Add(tmpMaterial);
				}
			}
		}
	}

	void OnDestroy()
	{
		for (int iter = 0, count = _changedMaterials.Count; iter < count; ++iter)
		{
			Material mat = _changedMaterials[iter];
			if(mat != null)
			{
				DestroyImmediate(mat,true);
			}			
		}
		_changedMaterials.Clear();
	}
}