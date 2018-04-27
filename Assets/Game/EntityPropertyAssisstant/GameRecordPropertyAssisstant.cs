using System;
using System.Collections.Generic;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
public static class GameRecordPropertyAssisstant
{
	public static GameRecordReceiveProperty Property { get { return _property; } }
	public static void SetProperty(GameRecordReceiveProperty property)
	{
		_property = property;
	}
	static GameRecordReceiveProperty _property;
	
	//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public static bool IsActivityActive(GameRecordReceiveProperty property, ActivityStruct info)
	{
		ReceiveDataActivityProperty activityProperty = property.ActivityList.GetValue((UInt32)info.ID, null);
		if (activityProperty == null)
		{
			return false;
		}
		return activityProperty.State != (UInt8)ActivityState.DEACTIVE;
	}

}