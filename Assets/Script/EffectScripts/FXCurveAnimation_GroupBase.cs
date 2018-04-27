using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FXCurveAnimation_GroupProperty))]
public class FXCurveAnimation_GroupBase : FXCurveAnimation_Base
{
	[HideInInspector]
	public FXCurveAnimation_GroupProperty property;

	public override void InitAnimation()
	{
		base.InitAnimation();
		property = GetComponent<FXCurveAnimation_GroupProperty>();
		MainMaterial = property.MainMaterial;
	}

	protected Material MainMaterial;
}
