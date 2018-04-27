
using System;
using System.Collections.Generic;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class GameSpaceRecordPropertyAssisstant
{
	public static GameSpaceRecordReceiveProperty DefaultProperty { get { return _property; } }
	public static void SetProperty(GameSpaceRecordReceiveProperty property)
	{
		_property = property;
	}
	static GameSpaceRecordReceiveProperty _property;

	//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	public static UInt32 GetLastEvent(GameSpaceRecordReceiveProperty property)
	{
		Int64 maxTime = Int64.MinValue;
		UInt32 lastEvent = 0;
		Dictionary<UInt32, ViReceiveDataDictionaryNode<UInt32, ReceiveDataSpaceEventProperty>> list = property.EventList.Array;
		foreach (KeyValuePair<UInt32, ViReceiveDataDictionaryNode<UInt32, ReceiveDataSpaceEventProperty>> iter in list)
		{
			ReceiveDataSpaceEventProperty iterEvent = iter.Value.Property;
			if (iterEvent.Time > maxTime)
			{
				maxTime = iterEvent.Time;
				lastEvent = iter.Key;
			}
		}
		return lastEvent;
	}

}