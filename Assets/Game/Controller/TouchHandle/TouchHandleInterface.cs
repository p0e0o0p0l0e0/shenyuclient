using System;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandleInterface
{
	public virtual bool Receivable(HeroController controller)
	{
		if (GlobalGameObject.Instance.SceneCamera == null)
		{
			return false;
		}
		//
		return true;
	}
	public virtual bool IsPause(HeroController controller) { return false; }
	public virtual void OnPress(HeroController controller, Vector3 pos) { }
	public virtual void OnDrag(HeroController controller, Vector3 pos, Vector3 deltaPos) { }
	public virtual void OnRelease(HeroController controller, Vector3 pos) { }
	public virtual void OnBreak(HeroController controller, Vector3 pos) { }
	public virtual void OnEnd(HeroController controller) { }
}

public class TouchHandle_Default: TouchHandleInterface
{
	public static TouchHandle_Default Instace { get { return _instance; } }
	static TouchHandle_Default _instance = new TouchHandle_Default();

	public override void OnPress(HeroController controller, Vector3 pos)
	{

        GameUnit gameUnit = PickManager.Instance.Entity as GameUnit;
        if(gameUnit != null)
        {
            controller.OnFocusEntity(gameUnit.PackID);
            CellNPC npc = gameUnit as CellNPC;
            if (npc != null &&
                (npc.LogicInfo.DataEx.Data.entityCategory == (int)EntityCategory.NORMAL_NPC ||
                npc.LogicInfo.DataEx.Data.entityCategory == (int)EntityCategory.PLOT_NPC))
                controller.OnMoveToNpc(npc.Position);
        }
        SpaceObject spaceObj = PickManager.Instance.Entity as SpaceObject;

        if (spaceObj.IsNotNull() && spaceObj.Info.IsNotNull())
        {
            if (spaceObj.Info.Type == (int)SpaceObjectType.COLLECT)
                controller.OnFocusSpaceObject(spaceObj.PackID);
        }
    }

	public override void OnDrag(HeroController controller, Vector3 pos, Vector3 deltaPos)
	{

	}

	public override void OnRelease(HeroController controller, Vector3 pos)
	{

	}

	public override void OnBreak(HeroController controller, Vector3 pos)
	{

	}

	public override void OnEnd(HeroController controller)
	{

	}
}