using UnityEngine;
using System.Collections.Generic;

public class RenderFromToInfo
{
	public Renderer Render;
}

public class FXCurveAnimation_MaterialFromToColor : FXCurveAnimation_Base
{
	public AnimationCurve ColorChangeCurve = new AnimationCurve();
	public bool R = true;
	public bool G = true;
	public bool B = true;
	public bool A = true;
	public Color FromColor = new Color(255.0f, 255.0f, 255.0f, 0.0f);
	public Color ToColor = Color.white;
	public bool Recursively = false;
	public bool Loop = false;

	public override void InitAnimation()
	{
		base.InitAnimation();
		//
		_renders = new List<RenderFromToInfo>();
		if (Recursively)
		{
			UnityComponentList<Renderer>.Begin(gameObject);
			for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
			{
				RenderFromToInfo render = new RenderFromToInfo();
				Renderer iterRender = UnityComponentList<Renderer>.List[iter];
				iterRender.enabled = false;
				render.Render = iterRender;
				_renders.Add(render);
			}
			UnityComponentList<Renderer>.End();
		}
		else
		{
			RenderFromToInfo renderInfo = new RenderFromToInfo();
			Renderer render = gameObject.GetComponent<Renderer>();
			render.enabled = false;
			renderInfo.Render = render;
			_renders.Add(renderInfo);
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (Time.time < _startTime + DelayTime)
		{
			return false;
		}
		if (_elapseTime > DurationTime)
		{
			if (!Loop)
			{
				if (AutoDestory)
				{
					GameObject.Destroy(gameObject);
				}
				//
				return false;
			}
			//
			_elapseTime = 0.0f;
		}
		//
		if (_renders == null)
		{
			return false;
		}
		if (Hide)
		{
			for (int iter = 0; iter < _renders.Count; ++iter)
			{
				RenderFromToInfo iterRender = _renders[iter];
				iterRender.Render.enabled = true;
			}
			//
			Hide = false;
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float scaleValue = ColorChangeCurve.Evaluate(_elapseTime / DurationTime);
		//
		for (int iter = 0; iter < _renders.Count; ++iter)
		{
            return true;
			RenderFromToInfo iterRender = _renders[iter];
			string iterColorName = GetMaterialColorName(iterRender.Render.material);
			if (string.IsNullOrEmpty(iterColorName))
			{
				continue;
			}
			Color color = iterRender.Render.material.GetColor(iterColorName);
			if (R)
			{
				color.r = Mathf.Lerp(FromColor.r, ToColor.r, scaleValue);
			}
			if (G)
			{
				color.g = Mathf.Lerp(FromColor.g, ToColor.g, scaleValue);
			}
			if (B)
			{
				color.b = Mathf.Lerp(FromColor.b, ToColor.b, scaleValue);
			}
			if (A)
			{
				color.a = Mathf.Lerp(FromColor.a, ToColor.a, scaleValue);
			}
			iterRender.Render.material.SetColor(GetMaterialColorName(iterRender.Render.material), color);
		}
		//
		_elapseTime += deltaTime;
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

	public override void Clear()
	{
		base.Clear();
	}

	List<RenderFromToInfo> _renders;
	string[] propertyNames = { "_Color", "_TintColor", "_EmisColor" };
}
