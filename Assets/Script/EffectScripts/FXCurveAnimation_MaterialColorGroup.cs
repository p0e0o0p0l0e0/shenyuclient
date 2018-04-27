using UnityEngine;
using System.Collections.Generic;
using System;

public class FXCurveAnimation_MaterialColorGroup : FXCurveAnimation_GroupBase
{
	public AnimationCurve ColorChangeCurve = new AnimationCurve();
	public bool R = true;
	public bool G = true;
	public bool B = true;
	public bool A = true;
	public Color ToColor = Color.white;

	public override void InitAnimation()
	{
		base.InitAnimation();
		//
		if (MainMaterial == null)
		{
			return;
		}
		//
		_orginColor = GetMaterialColor(MainMaterial);
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (!base.UpdateAnimation (deltaTime)) 
		{
			return false;
		}
		if (property.ShareObj != null && Hide)
		{
			for (Int32 iter = 0; iter < property.ShareObj.Count; ++iter)
			{
				Renderer iterRender = property.ShareObj[iter];
				iterRender.enabled = true;
			}
			//
			Hide = false;
		}
		//
		if (MainMaterial == null)
		{
			return false;
		}
		if (DurationTime == 0.0f)
		{
			return false;
		}
		//
		DurationTime = Mathf.Max(0.01f, DurationTime);
		float scaleValue = ColorChangeCurve.Evaluate(_elapseTime / DurationTime);
		Color color;
		color.r = R ? Mathf.Lerp(_orginColor.r, ToColor.r, scaleValue) : _orginColor.r;
		color.g = G ? Mathf.Lerp(_orginColor.g, ToColor.g, scaleValue) : _orginColor.g;
		color.b = B ? Mathf.Lerp(_orginColor.b, ToColor.b, scaleValue) : _orginColor.b;
		color.a = A ? Mathf.Lerp(_orginColor.a, ToColor.a, scaleValue) : _orginColor.a;
		MainMaterial.SetColor(GetMaterialColorName(MainMaterial), color);
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
		return Color.white;
	}

	public override void Clear()
	{
		base.Clear();
		if(MainMaterial != null)
		{
			MainMaterial.SetColor(GetMaterialColorName(MainMaterial), _orginColor);
		}
	}

	string[] propertyNames = { "_Color", "_TintColor", "_EmisColor" };
	Color _orginColor;
}
