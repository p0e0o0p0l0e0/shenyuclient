using System;
using UnityEngine;


[AddComponentMenu("ViRender/RenderLine")]

public class RenderLine : MonoBehaviour
{
	public GameObject From = null;
	public GameObject To = null;
	public float UVLen = 0;

	void Awake()
	{
		_render = gameObject.GetComponent<LineRenderer>();
		_render.useWorldSpace = true;
		_fromTran = From.transform;
		_toTran = To.transform;
		_material = _render.material;
		//
		if (UVLen > 0.01f)
		{
			Vector3 fromPos = _fromTran.position;
			Vector3 toPos = _toTran.position;
			float distance = Vector3.Distance(fromPos, toPos);
			_UVScale = distance / UVLen;
		}
	}

	void Update()
	{
		if (_render != null)
		{
			Vector3 fromPos = _fromTran.position;
			Vector3 toPos = _toTran.position;
			_render.SetPosition(0, fromPos);
			_render.SetPosition(1, toPos);
			//
			if (UVLen > 0.01f)
			{
				float distance = Vector3.Distance(fromPos, toPos);
				float UVScale = distance / UVLen;
				if (UVScale != _UVScale)
				{
					_UVScale = UVScale;
					_material.mainTextureScale = new Vector2(UVScale, 1);
				}
			}
		}
	}

	LineRenderer _render;
	Material _material;
	Transform _fromTran;
	Transform _toTran;
	float _UVScale = 1.0f;

}