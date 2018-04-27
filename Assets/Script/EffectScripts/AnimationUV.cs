using UnityEngine;
using System.Collections;
using System;

public class AnimationUV : MonoBehaviour
{
	public int uvAnimationTileX = 24;
	public int uvAnimationTileY = 1;
	public float framesPerSecond = 10.0f;
	public bool Loop;
	public bool Play = true;
	public bool Hidewhenstopplaying;

	void Start()
	{
		_offsettime = Time.time;
	}

	void Update()
	{
		_index = (Int32)((Time.time - _offsettime) * framesPerSecond);
		if (Play)
		{
			_index = _index % (uvAnimationTileX * uvAnimationTileY);
			Vector2 size = new Vector2(1.0f / uvAnimationTileY * 1.0f, 1.0f / uvAnimationTileX * 1.0f);
			var uIndex = _index % uvAnimationTileX;
			var vIndex = _index / uvAnimationTileX;
			var offset = new Vector2(uIndex * size.x, 1.0f - size.y - vIndex * size.y);
			GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
			GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
		}
		//
		if (!Loop)
		{
			if (_index >= (uvAnimationTileX * uvAnimationTileY) - 1)
			{
				Play = false;
				if (Hidewhenstopplaying)
				{
					GetComponent<Renderer>().gameObject.SetActive(false);
				}
			}
		}
	}

	Int32 _index;
	float _offsettime = 0.0f;
}
