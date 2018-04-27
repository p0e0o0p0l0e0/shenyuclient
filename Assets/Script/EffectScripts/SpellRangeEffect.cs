using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellRangeEffect : MonoBehaviour
{
	void OnEnable()
	{
		_renders.Clear();
		GetComponentsInChildren<Renderer>(true, _renders);
	}

	public void SetPos(ViProvider<ViVector3> pos)
	{
		_pos = pos;
		_UpdatePos();
	}

	public void UpdateRadius(float radius)
	{
		gameObject.transform.localScale = Vector3.one * radius;
	}

	public void UpdateColor(Color color)
	{
		for (int iter = 0; iter < _renders.Count; ++iter)
		{
			Renderer iterRender = _renders[iter];
			if (iterRender != null && iterRender.material != null)
			{
				iterRender.material.SetColor(GetMaterialColorName(iterRender.material), color);
			}
		}
	}

	void Update()
	{
		_UpdatePos();
	}

	void _UpdatePos()
	{
		if (_pos != null)
		{
			gameObject.transform.position = _pos.Value.Convert() + _heightOffset;
		}
	}

	public string GetMaterialColorName(Material mat)
	{
		if (mat == null)
		{
			return string.Empty;
		}
		//
		for (int iter = 0; iter < propertyNames.Length; ++iter)
		{
			string iterName = propertyNames[iter];
			if (mat.HasProperty(iterName))
			{
				return iterName;
			}
		}
		//
		return string.Empty;
	}

	string[] propertyNames = { "_Color", "_TintColor", "_EmisColor" };
	ViProvider<ViVector3> _pos;
	List<Renderer> _renders = new List<Renderer>();
	Vector3 _heightOffset = new Vector3(0.0f, 0.2f, 0.0f);
}
