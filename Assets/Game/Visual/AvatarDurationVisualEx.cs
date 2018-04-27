using System;
using System.Collections.Generic;
using UnityEngine;

using ViEntityID = System.UInt64;

public static class DurationVisualEx
{
	public static void Start()
	{
		ViAvatarDurationVisualOwnList<Avatar>._deleGetEffectController = GetController;
		ViAvatarDurationVisualOwnList<Avatar>._deleCerateDurationVisual = CreateDurationVisual;
		//
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.ANIMATION, (Int32)DurationVisualChannel.ANIMATION);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.ANIMATION_SCALE, (Int32)DurationVisualChannel.ANIMATION_SCALE);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.ANIMATION_REPLACE, (Int32)DurationVisualChannel.ANIMATION_REPLACE);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.SCALE, (Int32)DurationVisualChannel.SCALE);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.HIDE, (Int32)DurationVisualChannel.AVATAR_GHOST);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.CAMERA_FIELD, (Int32)DurationVisualChannel.CAMERA_FIELD);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.HIDERENDER, (Int32)DurationVisualChannel.AVATAR_GHOST);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.SCREEN_GRAY, (Int32)DurationVisualChannel.SCREEN_COLOR);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.HP_PERC_AVATAR, (Int32)DurationVisualChannel.AVATAR_GHOST);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.TRANSPARENTRIM, (Int32)DurationVisualChannel.AVATAR_GHOST);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.HEXAGON, (Int32)DurationVisualChannel.AVATAR_GHOST);
		ViAvatarDurationVisualChannelManager.Register((Int32)DurationVisualType.HEXAGON_RANDOM, (Int32)DurationVisualChannel.AVATAR_GHOST);
	}

	public static ViAvatarDurationVisualInterface<Avatar> CreateDurationVisual(Int32 type)
	{
		switch ((DurationVisualType)type)
		{
			case DurationVisualType.ANIMATION:
				return new DurationVisual_StateAnimation();
			case DurationVisualType.ANIMATION_SCALE:
				return new DurationVisual_AnimationScale();
			case DurationVisualType.ANIMATION_REPLACE:
				return new DurationVisual_AnimationReplace();
			case DurationVisualType.SCALE:
				return new DurationVisual_Scale();
			case DurationVisualType.HIDE:
				return new DurationVisual_Hide();
			case DurationVisualType.CAMERA_FIELD:
				return new DurationVisual_CameraField();
			case DurationVisualType.HIDERENDER:
				return new DurationVisual_HideRender();
			case DurationVisualType.SCREEN_GRAY:
				return new DurationVisual_ScreenGray();
			case DurationVisualType.HP_PERC_AVATAR:
				return new DurationVisual_HPPerc();
			case DurationVisualType.TRANSPARENTRIM:
				return new DurationVisual_TransparentRim();
			case DurationVisualType.HEXAGON:
				return new DurationVisual_Hexagon();
			case DurationVisualType.HEXAGON_RANDOM:
				return new DurationVisual_HexagonRandom();
			default:
				return null;
		}
	}

	public static ViAvatarDurationVisualController<Avatar> GetController(Avatar avatar, Int32 type)
	{
		return avatar.DurationVisualControllers.GetEffectController((UInt32)type);
	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_AnimationScale : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			float scale = ViMiscInt32Assisstant.Value(Info.MiscInt, "Scale", 0) * 0.01f;
			avatar.SetAnimSpeed(scale);
			if (scale <= 0.0f && avatar.Anim != null)
			{
				avatar.Anim.enabled = false;
			}
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			if (avatar.Anim != null)
			{
				avatar.Anim.enabled = true;
			}
			avatar.StopActionAnim();
			GameUnit entity = GetEntity<GameUnit>();
			if (entity != null)
			{
				avatar.SetAnimSpeed(entity.AnimationSpeed);
				entity.OnUpdateMoveSpeed();
			}
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_AnimationReplace : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			for (int iter = 0; iter < Info.MiscString.Length; ++iter)
			{
				ViMiscString iterValue = Info.MiscString[iter];
				if (string.IsNullOrEmpty(iterValue.name) || string.IsNullOrEmpty(iterValue.value))
				{
					continue;
				}
				//entity.RealBody.AnimReplacer.Add(iterValue.name, iterValue.value);
				//if (string.Compare(iterValue.name, AnimationData.Idle, true) == 0)
				//{
				//    entity.IdleAnimType.Add("DurationVisual_AnimationReplace", 20, iterValue.value);
				//}
			}
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			for (int iter = 0; iter < Info.MiscString.Length; ++iter)
			{
				ViMiscString iterValue = Info.MiscString[iter];
				if (string.IsNullOrEmpty(iterValue.name) || string.IsNullOrEmpty(iterValue.value))
				{
					continue;
				}
				//entity.RealBody.AnimReplacer.Remove(iterValue.name);
				//if (string.Compare(iterValue.name, AnimationData.Idle, true) == 0)
				//{
				//    entity.IdleAnimType.Del("DurationVisual_AnimationReplace");
				//}
			}
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}
//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_Scale : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			GameUnit entity = GetEntity<GameUnit>();
			if (entity != null)
			{
				float scale = entity.Scale.DefaultValue * (ViMiscInt32Assisstant.Value(Info.MiscInt, "Scale", 0) * 0.01f);
				entity.Scale.Add("DurationVisual_Scale", 20, scale);
			}
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			GameUnit entity = GetEntity<GameUnit>();
			if (entity != null)
			{
				entity.Scale.Del("DurationVisual_Scale");
			}
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_StateAnimation : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			avatar.PlayStateAnim(animationName);
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			avatar.StopStateAnim(animationName);
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

	public string animationName = string.Empty;
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_Hide : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			GameUnit entity = GetEntity<GameUnit>();
			if (entity != null)
			{
				entity.VisualActive.Add("Aura", 40, false);
			}
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			GameUnit entity = GetEntity<GameUnit>();
			if (entity != null)
			{
				entity.VisualActive.Del("Aura");
			}
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_HideRender : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			UnityComponentList<Renderer>.Begin(avatar.Visual);
			for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
			{
				Renderer iterRender = UnityComponentList<Renderer>.List[iter];
				iterRender.enabled = false;
			}
			UnityComponentList<Renderer>.End();
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			UnityComponentList<Renderer>.Begin(avatar.Visual);
			for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
			{
				Renderer iterRender = UnityComponentList<Renderer>.List[iter];
				iterRender.enabled = true;
			}
			UnityComponentList<Renderer>.End();
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_CameraField : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
		if (camera != null)
		{
			camera.FieldEx.Add("Aura", 10, Info.MiscInt.Value("Field", 10));
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
		if (camera != null)
		{
			camera.FieldEx.Del("Aura");
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_ScreenGray : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!Entity.IsLocal)
		{
			return;
		}
		if (GameSpace.ActiveInstance == null)
		{
			return;
		}
		//
		Camera camera = GameSpace.ActiveInstance.Controller.Camera;
		if (camera != null)
		{
			FatePostEffect postEffect = camera.gameObject.GetComponent<FatePostEffect>();
			if (postEffect == null)
			{
				postEffect = camera.gameObject.AddComponent<FatePostEffect>();
				postEffect.Scale = 0;
			}
			//
			postEffect.enabled = true;
			postEffect.ScaleSup = Info.MiscInt.Value("ProgressSup", 70) * 0.01f;
			postEffect.ScaleSpeed = Info.MiscInt.Value("Speed", 100) * 0.01f;
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!Entity.IsLocal)
		{
			return;
		}
		if (GameSpace.ActiveInstance == null)
		{
			return;
		}
		//
		Camera camera = GameSpace.ActiveInstance.Controller.Camera;
		if (camera != null)
		{
			FatePostEffect postEffect = camera.gameObject.GetComponent<FatePostEffect>();
			if (postEffect != null)
			{
				postEffect.ScaleSpeed = -Info.MiscInt.Value("Speed", 100) * 0.01f;
			}
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}

}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_HPPerc: ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			UpdateHPPerc(avatar);
			//
			GameUnit entity = Entity as GameUnit;
			if (entity != null)
			{
				entity.Property.HP.CallbackList.Attach(_propertyCallbackHP, this._HPPercUpdated);
				entity.Property.HPMax0.CallbackList.Attach(_propertyCallbackHPMax, this._HPPercUpdated);
			}
		}
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		_propertyCallbackHP.End();
		_propertyCallbackHPMax.End();
		//
		if (!destroying)
		{

		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{
		
	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{
		
	}

	Int32 _lastStep = -1;
	void UpdateHPPerc(Avatar avatar)
	{
		GameUnit entity = Entity as GameUnit;
		if (entity == null)
		{
			return;
		}
		Int32 span = ViMathDefine.IntNear(entity.Property.HPMax0.Value * 0.33f);
		Int32 newStep = ViMathDefine.Clamp((entity.Property.HP + span - 1) / span, 0, 3);
		if (newStep == _lastStep)
		{
			return;
		}
		_lastStep = newStep;
		if (avatar.Face != null)
		{
			if (newStep == 0)
			{
				avatar.Face.Stop();
			}
			else
			{
				avatar.Face.Play(newStep.ToString("00"), Int32.MaxValue);
			}
		}
	}

	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackHP = new ViAsynCallback<ViReceiveDataNode, object>();
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackHPMax = new ViAsynCallback<ViReceiveDataNode, object>();
	void _HPPercUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		GameUnit entity = Entity as GameUnit;
		if (entity != null)
		{
			UpdateHPPerc(entity.VisualBody);
		}
	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_TransparentRim : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			if (avatar.Visual != null)
			{
				GameObject ghostObj = avatar.CreateGhost("TransparentRim", true, GhostMaterialReplace, null);
				ghostObj.transform.position = avatar.RootTran.position;
				UnityAssisstant.SetLayerRecursively(ghostObj, (Int32)UnityLayer.ENTITY);
			}
		}
	}

	public Material GhostMaterialReplace(Material old, Material newTemplate)
	{
		return newTemplate;
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			string name = Info.MiscString.Value("PrefabName", string.Empty);
			avatar.ClearGhost(name);
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_HexagonRandom : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			if (avatar.Visual != null)
			{
				GameObject ghostObj = avatar.CreateGhost("RimHexagonRandom", false, GhostMaterialReplace, null);
				ghostObj.transform.position = avatar.RootTran.position;
				UnityAssisstant.SetLayerRecursively(ghostObj, (Int32)UnityLayer.ENTITY);
			}
		}
	}

	public Material GhostMaterialReplace(Material old, Material newTemplate)
	{
		return newTemplate;
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			string name = Info.MiscString.Value("PrefabName", string.Empty);
			avatar.ClearGhost(name);
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class DurationVisual_Hexagon : ViAvatarDurationVisualInterface<Avatar>
{
	public override void OnActive(Avatar avatar, bool destroying, ref object scriptObj)
	{
		if (!destroying)
		{
			if (avatar.Visual != null)
			{
				GameObject ghostObj = avatar.CreateGhost("RimHexagon", false, GhostMaterialReplace, null);
				ghostObj.transform.position = avatar.RootTran.position;
				UnityAssisstant.SetLayerRecursively(ghostObj, (Int32)UnityLayer.ENTITY);
			}
		}
	}

	public Material GhostMaterialReplace(Material old, Material newTemplate)
	{
		return newTemplate;
	}

	public override void OnDeactive(Avatar avatar, bool destroying, ref object obj)
	{
		if (!destroying)
		{
			string name = Info.MiscString.Value("PrefabName", string.Empty);
			avatar.ClearGhost(name);
		}
	}

	public override void OnStart(Avatar avatar, bool destroying)
	{

	}

	public override void OnEnd(Avatar avatar, bool destroying)
	{

	}
}