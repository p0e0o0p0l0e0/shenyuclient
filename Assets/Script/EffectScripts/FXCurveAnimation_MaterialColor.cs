using UnityEngine;
using System.Collections.Generic;

public class RenderInfo
{
	public Color OrginColor;
	public Renderer Render;
}

public class FXCurveAnimation_MaterialColor : FXCurveAnimation_Base
{
	[Tooltip("0 : 材质球的颜色. 1 : ToColor的颜色")]
	public AnimationCurve ColorChangeCurve = new AnimationCurve();
	public bool R = true;
	public bool G = true;
	public bool B = true;
	public bool A = true;
	public Color ToColor = Color.white;
	public bool Recursively = false;

	public override void InitAnimation()
	{
		base.InitAnimation();
		//
		if (Recursively)
		{
			UnityComponentList<Renderer>.Begin(gameObject);
			for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
			{
				RenderInfo render = new RenderInfo();
				Renderer iterRender = UnityComponentList<Renderer>.List[iter];
				render.OrginColor = GetMaterialColor(iterRender.material);
				iterRender.enabled = false;
				render.Render = iterRender;
				_renders.Add(render);
			}
			UnityComponentList<Renderer>.End();
		}
		else
		{
			RenderInfo renderInfo = new RenderInfo();
			Renderer render = gameObject.GetComponent<Renderer>();
			render.enabled = false;
			renderInfo.OrginColor = GetMaterialColor(render.material);
			renderInfo.Render = render;
			_renders.Add(renderInfo);
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (!base.UpdateAnimation (deltaTime)) 
		{
			return false;
		}
		if (Hide)
		{
			for (int iter = 0; iter < _renders.Count; ++iter)
			{
				RenderInfo iterRender = _renders[iter];
				iterRender.Render.enabled = true;
			}
			//
			Hide = false;
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float scaleValue = ColorChangeCurve.Evaluate(_elapseTime / DurationTime);
		Color color;
		for (int iter = 0; iter < _renders.Count; ++iter)
		{
			RenderInfo iterRender = _renders[iter];
			Color orginColor = iterRender.OrginColor;
			color.r = R ? Mathf.Lerp(orginColor.r, ToColor.r, scaleValue) : orginColor.r;
			color.g = G ? Mathf.Lerp(orginColor.g, ToColor.g, scaleValue) : orginColor.g;
			color.b = B ? Mathf.Lerp(orginColor.b, ToColor.b, scaleValue) : orginColor.b;
			color.a = A ? Mathf.Lerp(orginColor.a, ToColor.a, scaleValue) : orginColor.a;
			Material material = iterRender.Render.material;
			material.SetColor(GetMaterialColorName(iterRender.Render.material), color);
		}
		//
		return true;
	}

	public string GetMaterialColorName(Material mat)
	{
		if (mat == null)
		{
			return string.Empty;
		}
		//
		if (Shader.IsKeywordEnabled("HDR_ON"))
		{
			return "_TintHDRColor";
		}
		else
		{
			for (int iter = 0; iter < propertyNames.Length; ++iter)
			{
				string iterName = propertyNames[iter];
				if (mat.HasProperty(iterName))
				{
					return iterName;
				}
			}
		}
		//
		return string.Empty;
	}

	public Color GetMaterialColor(Material mat)
	{
		if (mat == null)
		{
			return Color.white;
		}
		//
		if (Shader.IsKeywordEnabled("HDR_ON"))
		{
			if (mat.HasProperty("_TintHDRColor"))
			{
				return mat.GetColor("_TintHDRColor");
			}
		}
		else
		{
			for (int iter = 0; iter < propertyNames.Length; ++iter)
			{
				string iterName = propertyNames[iter];
				if (mat.HasProperty(iterName))
				{
					return mat.GetColor(iterName);
				}
			}
		}
		//
		return Color.white;
	}

	public override void Clear()
	{
		base.Clear();
		for (int iter = 0; iter < _renders.Count; ++iter)
		{
			RenderInfo iterRender = _renders[iter];
			iterRender.Render.material.SetColor(GetMaterialColorName(iterRender.Render.material), iterRender.OrginColor);
		}
	}

	List<RenderInfo> _renders = new List<RenderInfo>();
	string[] propertyNames = { "_Color", "_TintColor", "_EmisColor" };
}
