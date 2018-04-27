using UnityEngine;
using System.Collections;
using System;

public class SpotLightScript : MonoBehaviour
{
	public Color DefaultColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
	public AnimationCurve LightPower = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 0f), new Keyframe(0.9f, 0f), new Keyframe(1f, 1f));
	public float DurationTime = 6.0f;
	public bool IsActive = false;
	public float Density = 0.0f;
	public Action OnSpotLightEndCallback;

	void Start()
	{
		Renderer render = GetComponent<MeshRenderer>();
		if (render != null && render.material != null)
		{
			_material = render.sharedMaterial;
			_material.SetColor("_Color", DefaultColor);
		}
	}

	void OnEnable()
	{
		Reset();
	}

	void LateUpdate()
	{
		if (!IsActive)
		{
			return;
		}
		if (_material == null)
		{
			return;
		}
		if (_material.shader == null)
		{
			return;
		}
		if (DurationTime <= 0.0f)
		{
			return;
		}
		if (_escapeTime > DurationTime)
		{
			if (OnSpotLightEndCallback != null)
			{
				OnSpotLightEndCallback();
				OnSpotLightEndCallback = null;
			}
		}
		else
		{
			float colorValue = LightPower.Evaluate(_escapeTime / DurationTime);
			DefaultColor.a = (1.0f - colorValue) * Density;
			_material.SetColor("_Color", DefaultColor);
			_escapeTime += Time.deltaTime;
		}
	}

	public void Reset()
	{
		DefaultColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
		_escapeTime = 0.0f;
	}

	void OnDisable()
	{
		Reset();
	}

	Material _material;
	float _escapeTime;
}
