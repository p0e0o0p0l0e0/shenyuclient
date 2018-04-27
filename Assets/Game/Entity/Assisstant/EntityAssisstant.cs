using System;
using System.Collections.Generic;
using UnityEngine;

using ViEntityID = System.UInt64;
using Int8 = System.SByte;

public static class EntityAssisstant
{
	public static string GetFactionColor(GameUnit attacker, GameUnit victim)
	{
		if (CellHero.LocalHero == null)
		{
			return string.Empty;
		}
		//
		if (attacker != null)
		{
			if (CellHero.LocalHero.IsFriend(attacker))
			{
				return "Blue";
			}
			else if (CellHero.LocalHero.IsEnemy(attacker))
			{
				return "Red";
			}
			else
			{
				return string.Empty;
			}
		}
		//
		if (victim != null)
		{
			if (CellHero.LocalHero.IsFriend(victim))
			{
				return "Red";
			}
			else if (CellHero.LocalHero.IsEnemy(victim))
			{
				return "Blue";
			}
			else
			{
				return string.Empty;
			}
		}
		//
		return string.Empty;
	}

    //最优解用的颜色
    public static string GetUINameColor(GameUnit attacker, GameUnit victim)
	{
		if (CellHero.LocalHero == null)
		{
			return string.Empty;
		}
		//
		if (attacker != null)
		{
			if (CellHero.LocalHero.IsFriend(attacker))
			{
				return "#9DFF86";
			}
			else if (CellHero.LocalHero.IsEnemy(attacker))
			{
				return "#FF433E";
			}
            else if (CellHero.LocalHero.IsNeutral(attacker))
			{
				return "#FFCA86";
			}
			else
			{
				return string.Empty;
			}
		}
		//
		if (victim != null)
		{
			if (CellHero.LocalHero.IsFriend(victim))
			{
				return "Red";
			}
			else if (CellHero.LocalHero.IsEnemy(victim))
			{
				return "Blue";
			}
			else
			{
				return string.Empty;
			}
		}
		//
		return string.Empty;
	}

	public static string GetFactionColor(Faction self, Faction tagert)
	{
		if (EntityRelationChecker.IsFriend(self, tagert))
		{
			return "Blue";
		}
		else if (EntityRelationChecker.IsEnemy(self, tagert))
		{
			return "Red";
		}
		else
		{
			return string.Empty;
		}
	}

	public static void UpdateGroundHeight(Dictionary<ViEntityID, ViEntity> entityList)
	{
		foreach (KeyValuePair<ViEntityID, ViEntity> iter in entityList)
		{
			SpaceEntity iterEntity = iter.Value as SpaceEntity;
			if (iterEntity != null)
			{
				iterEntity.Physics.UpdateHeight();
			}
		}
	}

	public static Int32 AvatarLODLevel(SpaceEntity entity)
	{
		if (entity.IsLocal)
		{
			return ApplicationSetting.Instance.GraphicsMainLevel;
		}
		//
		CellNPC entityNPC = entity as CellNPC;
		if (entityNPC != null)
		{
			return AvatarLODLevel(entityNPC.VisualInfo.Avatar.Data);
		}
		//
		CellHero entityHero = entity as CellHero;
		if (entityHero != null)
		{
			return AvatarLODLevel(entityHero.VisualInfo.Avatar.Data);
		}
		//
		return ApplicationSetting.Instance.GraphicsMainLevel;
	}

	static Int32 AvatarLODLevel(SimpleAvatarStruct info)
	{
		return ApplicationSetting.Instance.GraphicsMainLevel;
	}

	public static bool ActiveMirrorShadowBody(SpaceEntity entity)
	{
		if (entity != null && entity.IsLocal)
		{
			return ApplicationSetting.Instance.GraphicsMirrorCharacter != 0 || ApplicationSetting.Instance.GraphicsShadow != 0;
		}
		else
		{
			return ApplicationSetting.Instance.GraphicsMainLevel > 1 && (ApplicationSetting.Instance.GraphicsMirrorCharacter != 0 || ApplicationSetting.Instance.GraphicsShadow != 0);
		}
	}

	public static Int32 ExpressLODLevel(ViEntity entity)
	{
		if (entity != null)
		{
			if (entity.IsLocal)
			{
				return ApplicationSetting.Instance.SpellLODLevel;
			}
			else if (entity is CellNPC)
			{
				return ApplicationSetting.Instance.SpellLODLevel;
			}
			else if (entity is AreaAura)
			{
				return ApplicationSetting.Instance.SpellLODLevel;
			}
		}
		//
		return ViMathDefine.Max(((Int32)ApplicationSetting.Instance.SpellLODLevel) - 1, 0);
	}

	public static float FormatYaw(Int8 value)
	{
		return value * 0.025f;
	}
	public static void FormatYaw(ref float value)
	{
		ViAngle.Normalize(ref value);
		value = ViMathDefine.IntNear(value*40) * 0.025f;
	}

}

