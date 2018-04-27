using UnityEngine;
using System.Collections;

public class AirFlow : MonoBehaviour
{
	public Vector2 UVDefaultTiling = Vector2.one;
	public Vector2 UVDefaultOffset = Vector2.zero;
	public Vector2 UVOffsetSpeed = Vector2.zero;
	public Color DefaultColor = Color.white;
	public float Depth;
	public Camera Camera;

	void OnEnable()
	{
		_renderer = GetComponent<Renderer>();
		if (_renderer != null && _renderer.material != null)
		{
			_renderer.material.mainTextureOffset = UVDefaultOffset;
			_renderer.material.mainTextureScale = UVDefaultTiling;
		}
		//
		if (Camera.depthTextureMode != DepthTextureMode.Depth) 
		{
			Camera.depthTextureMode = DepthTextureMode.Depth;
		}
	}

	void Update()
	{
		if (_renderer == null)
		{
			return;
		}
		//
		if (UVOffsetSpeed.x != 0 || UVOffsetSpeed.y != 0)
		{
			m_offset.x += UVOffsetSpeed.x * Time.deltaTime;
			if (m_offset.x > 1)
			{
				m_offset.x -= 1;
			}
			else if (m_offset.x < -1)
			{
				m_offset.x += 1;
			}
			m_offset.y += UVOffsetSpeed.y * Time.deltaTime;
			if (m_offset.y > 1)
			{
				m_offset.y -= 1;
			}
			else if (m_offset.y < -1)
			{
				m_offset.y += 1;
			}
			if (_renderer.material != null)
			{
				_renderer.material.mainTextureOffset = m_offset;
				_renderer.material.SetColor("_TintColor", DefaultColor);
				_renderer.material.SetFloat("_farClip", Camera.farClipPlane);
				_renderer.material.SetFloat("_Depth", Depth);
			}
		}
	}

	Renderer _renderer;
	Vector2 m_offset = new Vector2();
}
