using UnityEngine;
using System.Collections.Generic;
using System;

public class DissolvedVerticalCompent : MonoBehaviour
{
	public float TimeScale = 1.0f;
	public float Height = 2.0f;
	public Action<object> OnDissloveCompleteCallback;
	public object Tagert;
	public float HeightDelta = 1.1f;

	void Start()
	{
		 GetComponentsInChildren<Renderer>(true, _renderers);
		if (_renderers.Count != 0)
		{
			StartHeight += Time.deltaTime * TimeScale;
			for (Int32 iter = 0; iter < _renderers.Count; ++iter)
			{
				Material[] materials = _renderers[iter].materials;
				for (int innIter = 0; innIter < materials.Length; ++innIter)
				{
					Material iterMaterial = materials[innIter];
					if (iterMaterial != null)
					{
						iterMaterial.EnableKeyword("VERTICAL_DISSOLVE_ON");
						iterMaterial.DisableKeyword("DISSOLVE_OFF");
						iterMaterial.DisableKeyword("RANDOM_DISSOLVE_ON");
					}
				}
			}
		}
		StartHeight = 0.0f;
	}

	void LateUpdate()
	{
		if (_renderers.Count != 0)
		{
			StartHeight += Time.deltaTime * TimeScale;
			for (Int32 iter = 0; iter < _renderers.Count; ++iter)
			{
				Material[] materials = _renderers[iter].materials;
				for (int innIter = 0; innIter < materials.Length; ++innIter)
				{
					Material iterMaterial = materials[innIter];
					if (iterMaterial != null)
					{
						iterMaterial.SetFloat("_StartHeight", StartHeight);
						iterMaterial.SetFloat("_HeightDelta", HeightDelta);
					}
				}
			}
		}
		//
		if (StartHeight > Height)
		{
			if (OnDissloveCompleteCallback != null)
			{
				OnDissloveCompleteCallback(Tagert);
				OnDissloveCompleteCallback = null;
			}
			//
			this.enabled = false;
		}
	}

	List<Renderer> _renderers = new List<Renderer>();
	float StartHeight;
}
