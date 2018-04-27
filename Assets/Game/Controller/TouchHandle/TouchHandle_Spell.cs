using System;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandle_Spell : TouchHandleInterface
{
	public static TouchHandle_Spell Instace { get { return _instance; } }
	static TouchHandle_Spell _instance = new TouchHandle_Spell();

	public override void OnPress(HeroController controller, Vector3 touchPos)
	{
		ViVector3 groundPos;
		if (GetWorldPos(controller, touchPos, out groundPos))
		{
			controller.UpdateAoIHint(groundPos);
		}
	}

	public override void OnDrag(HeroController controller, Vector3 touchPos, Vector3 deltaPos)
	{
		ViVector3 groundPos;
		if (GetWorldPos(controller, touchPos, out groundPos))
		{
			controller.UpdateAoIHint(groundPos);
		}
	}

	public override bool IsPause(HeroController controller)
	{
		return controller.LocalHero.WorkingSpellInfo != null && controller.LocalHero.WorkingSpellInfo.Type != GameSealedDataTypeInstance.NormalAttack;
	}

	public override void OnRelease(HeroController controller, Vector3 touchPos)
	{
		if (controller.LocalHero.WorkingSpellInfo != null && controller.LocalHero.WorkingSpellInfo.Type != GameSealedDataTypeInstance.NormalAttack)
		{
			return;
		}
		//
		int index;
		ViVector3 groundPos;
		if (GetWorldPos(controller, touchPos, out groundPos) && CellHero.LocalHero.Property.SpellList.GetIndex(controller.SpellAoIProperty, out index))
		{
			if (controller.InAoIHintRange(groundPos))
			{
				switch (controller.SpellAoIType)
				{
					case SpellPositionSelectType.POS:
						{
							ViVector3 localHeroPos = CellHero.LocalHero.Position;
							ViVector3 offset = groundPos - localHeroPos;
							ViVector3 dir = offset.normalized;
							float yaw = ViGeographicObject.GetDirection(dir.x, dir.y);
							CellPlayerServerInvoker.REQ_DoSpellByID(CellPlayer.Instance, (uint)controller.SpellAoIProperty.Info.Value.Spell.Data.ID, yaw, offset.Length); //liupeng 2018.4.16
						}
						break;
					case SpellPositionSelectType.YAW:
						{
							ViVector3 localHeroPos = CellHero.LocalHero.Position;
							ViVector3 offset = groundPos - localHeroPos;
							ViVector3 dir = offset.normalized;
							float yaw = ViGeographicObject.GetDirection(dir.x, dir.y);
							CellPlayerServerInvoker.REQ_DoSpellByID(CellPlayer.Instance, (uint)controller.SpellAoIProperty.Info.Value.Spell.Data.ID, yaw);
						}
						break;
					case SpellPositionSelectType.SELF:
						break;
				}
			}
		}
	}

	public override void OnBreak(HeroController controller, Vector3 touchPos)
	{

	}

	public override void OnEnd(HeroController controller)
	{
		Clear(controller);
	}

	void Clear(HeroController controller)
	{
		controller.TouchHandle.Del("Spell");
		//
		controller.EndAoIHint();
	}

	bool GetWorldPos(HeroController controller, Vector3 touchPos, out ViVector3 groundPos)
	{
		Camera camera = GlobalGameObject.Instance.SceneCamera;
		UnityEngine.Ray ray = camera.ScreenPointToRay(touchPos);
		Vector3 localPlayerPos = controller.LocalHero.Position.Convert();
		float distance = camera.WorldToScreenPoint(localPlayerPos).z + GroundPickAssisstant.VALUE_GroundPickDistanceSup;
		return GroundPickAssisstant.PickPos(ray, distance, out groundPos);
	}

}