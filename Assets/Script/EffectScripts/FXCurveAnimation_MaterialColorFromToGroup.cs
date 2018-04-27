using UnityEngine;
using System.Collections.Generic;

public class FXCurveAnimation_MaterialColorFromToGroup : FXCurveAnimation_GroupBase
{
	public AnimationCurve ColorChangeCurve = new AnimationCurve();
	public bool R = true;
	public bool G = true;
	public bool B = true;
	public bool A = true;
	public Color FromColor = new Color(255.0f, 255.0f, 255.0f, 0.0f);
	public Color ToColor = Color.white;

	public override void InitAnimation()
	{
		base.InitAnimation();
		//
		if (MainMaterial == null)
		{
			return;
		}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (!base.UpdateAnimation(deltaTime))
		{
			return false;
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
		color.r = R ? Mathf.Lerp(FromColor.r, ToColor.r, scaleValue) : FromColor.r;
		color.g = G ? Mathf.Lerp(FromColor.g, ToColor.g, scaleValue) : FromColor.g;
		color.b = B ? Mathf.Lerp(FromColor.b, ToColor.b, scaleValue) : FromColor.b;
		color.a = A ? Mathf.Lerp(FromColor.a, ToColor.a, scaleValue) : FromColor.a;
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
		//
		return string.Empty;
	}

	public override void Clear()
	{
		base.Clear();
	}

	string[] propertyNames = { "_Color", "_TintColor", "_EmisColor" };
}