using System;
using System.Collections.Generic;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class PlayerPropertyAssisstant
{
	public static PlayerReceiveProperty DefaultProperty { get { return _property; } }
	public static void SetProperty(PlayerReceiveProperty property)
	{
		_property = property;
	}
	static PlayerReceiveProperty _property;

	//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public static bool ReqLevel(PlayerReceiveProperty entityProperty, Int32 level)
	{
		return entityProperty.Level >= level;
	}

	public static bool ReqGMLevel(PlayerReceiveProperty entityProperty, Int32 level)
	{
		return entityProperty.GMLevel >= level;
	}

	public static bool IsFunctionOpen(PlayerReceiveProperty entityProperty, GameFuncStruct info)
	{
		if (info == null)
		{
			return true;
		}
		//
		if (GameRecordPropertyAssisstant.Property != null)
		{
			if (info.ReqActivity != 0)
			{
				ReceiveDataActivityProperty activityProperty;
				if (GameRecordPropertyAssisstant.Property.ActivityList.TryGetValue(info.ReqActivity, out activityProperty) && activityProperty.State == (UInt8)ActivityState.DEACTIVE)
				{
					return false;
				}
			}
			if (GameRecordPropertyAssisstant.Property.GameFuncClosedList.Contain((UInt32)info.ID))
			{
				return false;
			}
		}
		if (entityProperty.FuncDynamicDeactiveist.Contain((UInt32)info.ID))
		{
			return false;
		}
		if (!entityProperty.FuncOpenList.Contain((UInt32)info.ID) && !entityProperty.FuncDynamicActiveList.Contain((UInt32)info.ID))
		{
			return false;
		}
		//
		return true;
	}

	public static bool IsActivityOpen(PlayerReceiveProperty entityProperty, ActivityStruct info)
	{
		if (info == null)
		{
			return true;
		}
		//
		if (entityProperty.Level < info.Request.Level.Inf || entityProperty.Level > info.Request.Level.Sup)
		{
			return false;
		}
		//
		return true;
	}

	#region Space

	public static bool SpaceEnterable(PlayerReceiveProperty entityProperty, SpaceStruct info)
	{
		if (info == null)
		{
			return true;
		}
		//
		if (info.Request.Space.NotEmpty() && !SpacePassed(entityProperty, info.Request.Space.Data))
		{
			return false;
		}
		if (!ReqGMLevel(entityProperty, info.Request.GMLevel))
		{
			return false;
		}
		if (info.Request.Func.NotEmpty() && !IsFunctionOpen(entityProperty, info.Request.Func.Data))
		{
			return false;
		}
		return true;
	}

	public static bool SpacePassed(PlayerReceiveProperty entityProperty, SpaceStruct info)
	{
		if (info == null)
		{
			return true;
		}
		//
		ReceiveDataSpaceRecordProperty recordProperty;
		if (entityProperty.SpaceRecordList.TryGetValue((UInt32)info.ID, out recordProperty))
		{
			return recordProperty.WinCount > 0;
		}
		else
		{
			return false;
		}
	}

	#endregion


	#region Goal

	public static bool EnableTakeGoalReward(PlayerReceiveProperty entityProperty)
	{
		return EnableTakeGoalReward(entityProperty, ViDateLoopType.TOTAL);
	}
	public static bool EnableTakeGoalReward(PlayerReceiveProperty entityProperty, ViDateLoopType lootType)
	{
		foreach (KeyValuePair<UInt32, ViReceiveDataSetNode<UInt32>> pair in entityProperty.GoalRewardList.Array)
		{
			GoalStruct logicInfo = ViSealedDB<GoalStruct>.Data(pair.Key);
			if (logicInfo.Class.Value == GameSealedDataTypeInstance.HomeGoal.ID)
			{
				continue;
			}
			if (lootType != ViDateLoopType.TOTAL && logicInfo.Loop.Value != (int)lootType)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool HasGoal(PlayerReceiveProperty entityProperty, UInt32 uiTemplate, GoalState eState)
	{
		foreach (KeyValuePair<UInt32, ViReceiveDataDictionaryNode<UInt32, ReceiveDataGoalProperty>> pair in entityProperty.GoalList.Array)
		{
			ReceiveDataGoalProperty property = pair.Value.Property;
			if (pair.Key == uiTemplate && eState == (GoalState)property.State.Value)
			{
				return true;
			}
		}
		return false;
	}

	#endregion

#region Day Gift
	public static bool EnableTakeDayGift(PlayerReceiveProperty entityProperty)
	{
		return entityProperty.DayGiftReserveCount > 0;
	}

	public static bool EnableTakeAccumulateDayGift(PlayerReceiveProperty entityProperty)
	{
		ViSealedDB<AccumulateLoginRewardStruct>.IncludeZero = false;
		List<AccumulateLoginRewardStruct> list = ViSealedDB<AccumulateLoginRewardStruct>.Array;
		for (int iter = 0; iter < list.Count; ++iter)
		{
			if (!entityProperty.AccumulateLoginRewardTakedList.Contain((UInt32)list[iter].ID) && list[iter].ID <= entityProperty.AccumulateLoginDayCount)
			{
				return true;
			}
		}
		return false;
	}
#endregion


	#region Item
	public static bool ReqItem(PlayerReceiveProperty entityProperty, ItemCountStruct info)
	{
		if (info.IsEmpty())
		{
			return true;
		}
		int count = GetItemCount(entityProperty, info.Item);
		return count >= info.Count;
	}

	public static bool ReqComposeElement(PlayerReceiveProperty entityProperty, UInt32 targetItem, int targetCount)
	{
		ItemComposeStruct composeInfo = GetItemComposeInfo(targetItem);
		if (composeInfo != null)
		{
			if (!ReqMoeny(entityProperty, composeInfo.CostMoney))
			{
				return false;
			}
			//
			for (int iter = 0; iter < composeInfo.CostItem.Array.Length; ++iter)
			{
				int have = GetItemCount(entityProperty, composeInfo.CostItem[iter].Item);
				if (have < composeInfo.CostItem[iter].Count * targetCount)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public static ItemComposeStruct GetItemComposeInfo(UInt32 destItem)
	{
		if (destItem == 0)
		{
			return null;
		}
		List<ItemComposeStruct> infoList = ViSealedDB<ItemComposeStruct>.Array;
		for (int iter = 0; iter < infoList.Count; ++iter)
		{
			ItemComposeStruct composeInfo = infoList[iter];
			if (composeInfo.Dest == destItem)
			{
				return composeInfo;
			}
		}
		return null;
	}

	public static int GetItemCount(PlayerReceiveProperty entityProperty, Int32 item)
	{
		int count = 0;
		for (int iter = 0; iter < entityProperty.Inventory.Count; ++iter)
		{
			ReceiveDataItemProperty iterProperty = entityProperty.Inventory[iter].Property;
			if (iterProperty.Info == item)
			{
				count += iterProperty.StackCount;
			}
		}
		return count;
	}
	#endregion

	#region Money
	public static bool ReqMoeny(PlayerReceiveProperty entityProperty, MoneyStruct info)
	{
		return ReqMoeny(entityProperty, (MoneyType)info.Type.Value, info.Value);
	}
	public static bool ReqMoeny(PlayerReceiveProperty entityProperty, MoneyType type, Int64 value)
	{
		switch (type)
		{
			case MoneyType.YINPIAO:
				return entityProperty.YinPiao >= value;
			case MoneyType.JINPIAO:
				return (entityProperty.JinPiao + entityProperty.JinZiInAccount) >= value;
			case MoneyType.JINZI:
			default:
				return false;
		}
	}

	public static bool ReqActivityScore(PlayerReceiveProperty entityProperty, UInt32 activity, Int64 value)
	{
		ReceiveDataInt64Property property;
		if (entityProperty.ScoreList.TryGetValue(activity, out property))
		{
			return property.Value >= value;
		}
		else
		{
			return false;
		}
	}

	#endregion
}