using UnityEngine;
using System.Collections.Generic;
using System;

public enum DissloveType
{
	FADEIN,
	FADEOUT,
	VERTICALFADEIN,
	TOTAL,
}

public class UpdateWinDissloveScript : MonoBehaviour
{
	public float Duration = 2.0f;
	public DissloveType Type = DissloveType.FADEIN;
	public Action<object> OnDissloveCompleteCallback;
	public object Tagert;

	void Start()
	{
		_escapeTime = 0.0f;
		GetComponentsInChildren<Renderer>(true, _renders);
		for (int inIter = 0; inIter < _renders.Count; ++inIter)
		{
			Renderer render = _renders[inIter];
			for (int iter = 0; iter < render.sharedMaterials.Length; ++iter)
			{
				Material material = render.sharedMaterials[iter];
				if (material != null)
				{
					material.EnableKeyword("RANDOM_DISSOLVE_ON");
					material.DisableKeyword("DISSOLVE_OFF");
					material.DisableKeyword("VERTICAL_DISSOLVE_ON");
				}
			}
		}
	}

	void LateUpdate()
	{
		if (_renders.Count == 0)
		{
			return;
		}
		//
		_escapeTime += Time.deltaTime;
		for (int inIter = 0; inIter < _renders.Count; ++inIter)
		{
			Renderer render = _renders[inIter];
			for (int iter = 0; iter < render.sharedMaterials.Length; ++iter)
			{
				Material material = render.sharedMaterials[iter];
				float duration = 0.0f;
				if (Type == DissloveType.FADEIN)
				{
					duration = _escapeTime / Duration;
				}
				else
				{
					duration = 1.0f - _escapeTime / Duration;
				}
				//
				if (material != null)
				{
					material.SetFloat("_Duration", Mathf.Min(Mathf.Max(0.0f, duration), 1.0f));
				}
			}
		}
		if (_escapeTime >= Duration)
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

	void OnDestory()
	{
		if (_renders.Count == 0)
		{
			return;
		}
		//
		for (int inIter = 0; inIter < _renders.Count; ++inIter)
		{
			Renderer render = _renders[inIter];
			for (int iter = 0; iter < render.sharedMaterials.Length; ++iter)
			{
				//Material material = render.sharedMaterials[iter];
			}
		}
	}

	float _escapeTime;
	List<Renderer> _renders = new List<Renderer>();
}
