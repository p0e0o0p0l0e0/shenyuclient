using System;
using System.Collections.Generic;
using UnityEngine;

public class FxDeStruct : FXCurveAnimation_Base
{
	public override void InitAnimation()
	{
		AutoDestory = true;
		base.InitAnimation();
		//_currentRender = GetComponent<Renderer>();
		//if (_currentRender != null)
		//{
		//    _currentRender.enabled = false;
		//}
	}

	public override bool UpdateAnimation(float deltaTime)
	{
		if (!base.UpdateAnimation(deltaTime))
		{
			return false;
		}
		//if (Hide)
		//{
		//    if (_currentRender != null)
		//    {
		//        _currentRender.enabled = true;
		//    }
		//    //
		//    Hide = false;
		//}
		return true;
	}
}
