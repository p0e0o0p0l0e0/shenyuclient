using UnityEngine;
using System.Collections;

public class CS_AnimatedTextureUV : MonoBehaviour
{
	public int uvAnimationTileX = 24;

	public int uvANimationTileY =1;

	public float framesPerSecond = 10f;

	int _index;

	int multXY;

	Vector2 _size;

	float _uIndex;
	float _vIndex;

	Vector2 _offset;

	Material _myMat;

	void Start()
	{
		multXY = uvAnimationTileX * uvANimationTileY;
		_size = new Vector2();
		_offset = new Vector2();
		_myMat = GetComponent<Renderer>().material;
	}

	void Update()
	{
		if (_myMat == null)
		{
			this.enabled = false;
			return;
		}
		_index = Mathf.RoundToInt(Time.time * framesPerSecond);
		_index = _index % multXY;
		_size.x = 1.0f / uvAnimationTileX;
		_size.y = 1.0f / uvANimationTileY;

		_uIndex = _index % uvAnimationTileX;
		_vIndex = _index / uvAnimationTileX;

		_offset.x = _uIndex * _size.x;
		_offset.y = 1.0f - _size.y - _vIndex * _size.y;

		_myMat.SetTextureOffset("_MainTex", _offset);
		_myMat.SetTextureScale("_MainTex", _size);	
	}

	void OnDestroy()
	{
		if (_myMat != null)
		{
			DestroyImmediate(_myMat, true);
		}
	}
}
