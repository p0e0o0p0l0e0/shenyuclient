using System;
using System.Collections.Generic;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class PlayerFriendListPropertyAssisstant
{
	public static PlayerFriendListReceiveProperty DefaultProperty { get { return _property; } }
	public static void SetProperty(PlayerFriendListReceiveProperty property)
	{
		_property = property;
	}
	static PlayerFriendListReceiveProperty _property;

	//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public static bool HasFriendInvitor(PlayerFriendListReceiveProperty entityProperty)
	{
		return entityProperty.FriendInvitorList.Count > 0;
	}

}