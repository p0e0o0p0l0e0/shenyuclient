using System;
using System.Collections.Generic;
using System.Text;

using ViTime64 = System.Int64;
using UInt8 = System.Byte;

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
public static class PlayerPropertyWatcherCreator
{
	public static void Start(PlayerReceiveProperty property, ViEntity entity)
	{
		property.Inventory.Creator = CreateItemPropertyWatcher;
		property.Inventory.UpdateWatcher(CreateItemPropertyWatcher, entity);
        property.Equipments.Creator = CreateItemPropertyWatcher;
        property.Equipments.UpdateWatcher(CreateItemPropertyWatcher, entity);
        property.HeroList.Creator = CreateHeroPropertyWatcher;
		property.HeroList.UpdateWatcher(CreateHeroPropertyWatcher, entity);
	}
	//
	public static ViReceiveDataArrayNodeWatcher<ReceiveDataItemProperty> CreateItemPropertyWatcher()
	{
		return new ItemWatcher();
	}
	//
	public static ViReceiveDataDictionaryNodeWatcher<UInt32, ReceiveDataHeroProperty> CreateHeroPropertyWatcher()
	{
		return new HeroWatcher();
	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
public static class PlayerMailBoxPropertyWatcherCreator
{
	public static void Start(PlayerMailboxReceiveProperty property, ViEntity entity)
	{
		property.MailList.Creator = CreateMailPropertyWatcher;
		property.MailList.UpdateWatcher(CreateMailPropertyWatcher, entity);
	}
	//
	public static ViReceiveDataArrayNodeWatcher<ReceiveDataMailProperty> CreateMailPropertyWatcher()
	{
		return new MailWatcher();
	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
public static class PlayerFriendListPropertyWatcherCreator
{
	public static void Start(PlayerFriendListReceiveProperty property, ViEntity entity)
	{
		property.FriendPropertyList.Creator = CreateFriendPropertyWatcher;
		property.FriendPropertyList.UpdateWatcher(CreateFriendPropertyWatcher, entity);
	}
	//
	public static ViReceiveDataDictionaryNodeWatcher<UInt64, ReceiveDataFriendProperty> CreateFriendPropertyWatcher()
	{
		return new FriendWatcher();
	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
public static class GameUnitPropertyWatcherCreator
{
	public static void Start(GameUnitReceiveProperty property, ViEntity entity)
	{
		property.VisualAuraPropertyList.Creator = CreateVisualAuraPropertyWatcher;
		property.VisualAuraPropertyList.UpdateWatcher(CreateVisualAuraPropertyWatcher, entity);
	}
	//
	public static ViReceiveDataArrayNodeWatcher<ReceiveDataVisualAuraProperty> CreateVisualAuraPropertyWatcher()
	{
		return new VisualAuraWatcher();
	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
public static class GameSpaceRecordPropertyWatcherCreator
{
	public static void Start(GameSpaceRecordReceiveProperty property, ViEntity entity)
	{
		property.BirthControllerShowList.Creator = CreateSpaceBirthControllerShowWatcher;
		property.BirthControllerShowList.UpdateWatcher(CreateSpaceBirthControllerShowWatcher, entity);
		property.BlockSlotList.Creator = CreateSpaceBlockSlotWatcher;
		property.BlockSlotList.UpdateWatcher(CreateSpaceBlockSlotWatcher, entity);
		property.HideSlotList.Creator = CreateSpaceHideSlotWatcher;
		property.HideSlotList.UpdateWatcher(CreateSpaceHideSlotWatcher, entity);
	}
	//
	public static ViReceiveDataDictionaryNodeWatcher<UInt32, ReceiveDataSpaceBirthControllerShowProperty> CreateSpaceBirthControllerShowWatcher()
	{
		return new SpaceBirthControllerShowWatcher();
	}
	//
	public static ViReceiveDataArrayNodeWatcher<ReceiveDataSpaceBlockSlotProperty> CreateSpaceBlockSlotWatcher()
	{
		return new SpaceBlockSlotWatcher();
	}
	//
	public static ViReceiveDataArrayNodeWatcher<ReceiveDataSpaceHideSlotProperty> CreateSpaceHideSlotWatcher()
	{
		return new SpaceHideSlotWatcher();
	}
}

//+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
public static class GameSpaceFactionPropertyWatcherCreator
{
	public static void Start(GameSpaceFactionRecordReceiveProperty property, ViEntity entity)
	{
		property.HeroList.Creator = CreateSpaceFactionHeroPropertyWatcher;
		property.HeroList.UpdateWatcher(CreateSpaceFactionHeroPropertyWatcher, entity);
	}
	//
	public static ViReceiveDataDictionaryNodeWatcher<UInt64, ReceiveDataSpaceFactionHeroMemberProperty> CreateSpaceFactionHeroPropertyWatcher()
	{
		return new SpaceFactionHeroWatcher();
	}
}
