using UnityEngine;
using System.Collections;

public class CS_UVScroller : MonoBehaviour
{
	public int targetMaterialSlot = 0;
	public float speedY = 0.5f;
	public float speedX = 0.0f;
	private float _timeWentX = 0.0f;
	private float _timewentY = 0.0f;
	private Material _targetMaterial;
	private Vector2 UVOffSet = new Vector2();


	void Start()
	{
		_targetMaterial = GetComponent<Renderer>().materials[targetMaterialSlot];
	}

	void Update()
	{
		_timeWentX += Time.deltaTime * speedX;
		_timewentY += Time.deltaTime * speedY;
		UVOffSet.x = _timeWentX;
		UVOffSet.y = _timewentY;
		_targetMaterial.SetTextureOffset("_MainTex", UVOffSet);
	
	}

	void OnDestroy()
	{
		if (_targetMaterial != null)
		{
			DestroyImmediate(_targetMaterial, true);
		}		
	}
}
