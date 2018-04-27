using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPanelClipToParticle : MonoBehaviour
{
	public UIPanel NGUIPanel;

	void Start()
	{
		if (NGUIPanel == null)
		{
			NGUIPanel = UIPanel.Find(transform);
		}
		GetComponentsInChildren<Renderer>(true, _renderers);
		//
		enabled = NGUIPanel != null && NGUIPanel.clipping == UIDrawCall.Clipping.SoftClip && _renderers != null;
		if (enabled)
		{
			MeshRenderer renderer = UnityAssisstant.CreateComponent<MeshRenderer>(gameObject);
			_material = new Material(Shader.Find("Fate Shading/Character/Texture"));
			renderer.material = _material;
		}
	}

	void OnWillRenderObject()
	{
		for (int iter = 0; iter < _renderers.Count; ++iter)
		{
			Renderer iterRender = _renderers[iter];
			if (iterRender.material != null)
			{
				if(!iterRender.material.IsKeywordEnabled("CLIPON"))
				{
					iterRender.material.EnableKeyword("CLIPON");
				}
				//
				Vector4 cr = NGUIPanel.drawCallClipRange;
				Vector2 localPos = NGUIPanel.transform.InverseTransformPoint(transform.position);
				cr.x -= localPos.x;
				cr.y -= localPos.y;
				Vector2 soft = NGUIPanel.clipSoftness;
				SetClipping(iterRender.material, cr, soft, 0.0f);
			}
		}
	}

	void SetClipping(Material material, Vector4 cr, Vector2 soft, float angle)
	{
		angle *= -Mathf.Deg2Rad;
		if (soft.x > 0f)
		{
			_sharpness.x = cr.z / soft.x;
		}
		if (soft.y > 0f) 
		{
			_sharpness.y = cr.w / soft.y;
		}
		//
		material.SetVector("_ClipRange0", new Vector4(-cr.x / cr.z, -cr.y / cr.w, 1f / cr.z, 1f / cr.w));
		material.SetVector("_ClipArgs0", new Vector4(_sharpness.x, _sharpness.y, Mathf.Sin(angle), Mathf.Cos(angle)));
	}

	void OnDestory()
	{
		if (_material != null)
		{
			GameObject.Destroy(_material);
		}
		//
		UnityAssisstant.DelComponent<MeshRenderer>(gameObject);
	}

	Vector2 _sharpness = new Vector2(1000.0f, 1000.0f);
	List<Renderer> _renderers = new List<Renderer>();
	Material _material;
}
