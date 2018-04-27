using System;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandle_RoleCreate : TouchHandleInterface
{
	public static TouchHandle_RoleCreate Instace { get { return _instance; } }
	static TouchHandle_RoleCreate _instance = new TouchHandle_RoleCreate();

    Vector3 mLastPosition;
    public override void OnPress(HeroController controller, Vector3 pos)
    {
        mLastPosition = pos;
    }

	public override void OnDrag(HeroController controller, Vector3 touchPos, Vector3 deltaPos)
	{
        Vector3 delta = touchPos - mLastPosition;
        if (delta.magnitude < 1.0f)
        {
            return;
        }
        mLastPosition = touchPos;
        AccountScene.Instance.OnDragRole(delta);
    }

    public override void OnBreak(HeroController controller, Vector3 pos)
    {

    }
    public override void OnEnd(HeroController controller)
    {

    }
}