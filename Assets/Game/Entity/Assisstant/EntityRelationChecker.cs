using System;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;

public static class EntityRelationChecker
{
	public static void Start()
	{
		EntityRelationType eEmptyValue = EntityRelationType.NEUTRAL;
		EntityRelationType eMapValue = EntityRelationType.TOTAL;
		StandardAssisstant.AddValue(EntityRelationList, (int)Faction.TOTAL * (int)Faction.TOTAL, eEmptyValue);
		//
		Faction eSelf = Faction.FRIEND;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_0, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_1, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_2, EntityRelationType.FRIEND);
		//
		eSelf = Faction.NEUTRAL;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.PLAYER_0, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.PLAYER_1, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.PLAYER_2, EntityRelationType.NEUTRAL);
		//
		eSelf = Faction.ENEMY;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_0, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_1, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_2, EntityRelationType.ENEMY);
		//
		eSelf = Faction.PLAYER_FRIEND;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_0, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_1, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_2, EntityRelationType.FRIEND);
		//
		eSelf = Faction.PLAYER_0;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_0, eMapValue);
		SetRelation(eSelf, Faction.PLAYER_1, eMapValue);
		SetRelation(eSelf, Faction.PLAYER_2, eMapValue);
		//
		eSelf = Faction.PLAYER_1;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_0, eMapValue);
		SetRelation(eSelf, Faction.PLAYER_1, eMapValue);
		SetRelation(eSelf, Faction.PLAYER_2, eMapValue);
		//
		eSelf = Faction.PLAYER_2;
		SetRelation(eSelf, Faction.FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.NEUTRAL, EntityRelationType.NEUTRAL);
		SetRelation(eSelf, Faction.ENEMY, EntityRelationType.ENEMY);
		SetRelation(eSelf, Faction.PLAYER_FRIEND, EntityRelationType.FRIEND);
		SetRelation(eSelf, Faction.PLAYER_0, eMapValue);
		SetRelation(eSelf, Faction.PLAYER_1, eMapValue);
		SetRelation(eSelf, Faction.PLAYER_2, eMapValue);
		//
	}

	public static bool IsFriend(GameUnit self, GameUnit target)
	{
		if ((self.ID == target.ID))
		{
			return true;
		}
		if ((self.Property.Owner == target.PackID) || target.Property.Owner == self.PackID)
		{
			return true;
		}
		EntityRelationType eRelation = GetRelation(self.Faction, target.Faction);
		if (eRelation != EntityRelationType.TOTAL)
		{
			return eRelation == EntityRelationType.FRIEND;
		}
		return _IsFriend(GameSpaceRecordInstance.Instance.PKType, self.Faction, target.Faction);
	}

	public static bool IsFriend(Faction self, Faction target)
	{
		EntityRelationType eRelation = GetRelation(self, target);
		if (eRelation != EntityRelationType.TOTAL)
		{
			return eRelation == EntityRelationType.FRIEND;
		}
		return _IsFriend(GameSpaceRecordInstance.Instance.PKType, self, target);
	}

	public static bool IsEnemy(Faction self, Faction target)
	{
		EntityRelationType eRelation = GetRelation(self, target);
		if (eRelation != EntityRelationType.TOTAL)
		{
			return eRelation == EntityRelationType.ENEMY;
		}
		return _IsEnemy(GameSpaceRecordInstance.Instance.PKType, self, target);
	}

	public static bool IsEnemy(GameUnit self, GameUnit target)
	{
		if ((self.ID == target.ID))
		{
			return false;
		}
		if ((self.Property.Owner == target.PackID) || target.Property.Owner == self.PackID)
		{
			return false;
		}
		EntityRelationType eRelation = GetRelation(self.Faction, target.Faction);
		if (eRelation != EntityRelationType.TOTAL)
		{
			return eRelation == EntityRelationType.ENEMY;
		}
		return _IsEnemy(GameSpaceRecordInstance.Instance.PKType, self.Faction, target.Faction);
	}

	public static bool IsNeutral(Faction self, Faction target)
	{
		EntityRelationType eRelation = GetRelation(self, target);
		if (eRelation != EntityRelationType.TOTAL)
		{
			return eRelation == EntityRelationType.NEUTRAL;
		}
		return _IsNeutral(GameSpaceRecordInstance.Instance.PKType, self, target);
	}

	public static bool IsNeutral(GameUnit self, GameUnit target)
	{
		if ((self.ID == target.ID))
		{
			return false;
		}
		if ((self.Property.Owner == target.PackID) || target.Property.Owner == self.PackID)
		{
			return false;
		}
		EntityRelationType eRelation = GetRelation(self.Faction, target.Faction);
		if (eRelation != EntityRelationType.TOTAL)
		{
			return eRelation == EntityRelationType.NEUTRAL;
		}
		return _IsNeutral(GameSpaceRecordInstance.Instance.PKType, self.Faction, target.Faction);
	}

	static bool _IsFriend(SpacePKType eMapPK, Faction self, Faction target)
	{
		switch (eMapPK)
		{
			case SpacePKType.PLAYER_NEUTRAL_ZONE:
				return false;
			case SpacePKType.PLAYER_FRIEND_ZONE:
				return true;
			case SpacePKType.PLAYER_ENEMY_ZONE:
				return false;
			case SpacePKType.FACTION_ZONE:
				return self == target;
			//case SpacePKType.TEAM_ZONE:
			//    return self.Team == target.Team;
			default:
				return true;
		}
	}

	static bool _IsEnemy(SpacePKType eMapPK, Faction self, Faction target)
	{
		switch (eMapPK)
		{
			case SpacePKType.PLAYER_NEUTRAL_ZONE:
				return false;
			case SpacePKType.PLAYER_FRIEND_ZONE:
				return false;
			case SpacePKType.PLAYER_ENEMY_ZONE:
				return true;
			case SpacePKType.FACTION_ZONE:
				return self != target;
			//case SpacePKType.TEAM_ZONE:
			//    return self.Team != target.Team;
			default:
				return false;
		}
	}

	static bool _IsNeutral(SpacePKType eMapPK, Faction self, Faction target)
	{
		switch (eMapPK)
		{
			case SpacePKType.PLAYER_NEUTRAL_ZONE:
				return true;
			case SpacePKType.PLAYER_FRIEND_ZONE:
				return false;
			case SpacePKType.PLAYER_ENEMY_ZONE:
				return true;
			case SpacePKType.FACTION_ZONE:
				return false;
			//case SpacePKType.TEAM_ZONE:
			//    return self.Team != target.Team;
			default:
				return false;
		}
	}

	public static EntityRelationType GetRelation(Faction eSelf, Faction eTarget)
	{
		return EntityRelationList[(int)eSelf * (int)Faction.TOTAL + (int)eTarget];
	}

	static void SetRelation(Faction eSelf, Faction eTarget, EntityRelationType eType)
	{
		EntityRelationList[(int)eSelf * (int)Faction.TOTAL + (int)eTarget] = eType;
	}

	public static bool IsMatch(GameUnit self, GameUnit target, UInt32 mask)
	{
		if (ViMask32.HasAny(mask, (Int32)ViUnitSocietyMask.SELF))
		{
			if (System.Object.ReferenceEquals(self, target))
			{
				return true;
			}
		}
		//
		if (ViMask32.HasAny(mask, (Int32)ViUnitSocietyMask.FRIEND))
		{
			if (IsFriend(self, target))
			{
				return true;
			}
		}
		//
		if (ViMask32.HasAny(mask, (Int32)ViUnitSocietyMask.ENEMY))
		{
			if (IsEnemy(self, target))
			{
				return true;
			}
		}
		//
		if (ViMask32.HasAny(mask, (Int32)ViUnitSocietyMask.NEUTRAL))
		{
			if (IsNeutral(self, target))
			{
				return true;
			}
		}
		//
		return false;
	}

	static List<EntityRelationType> EntityRelationList = new List<EntityRelationType>();
}

