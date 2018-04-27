using System;
using System.Collections.Generic;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class GuildPropertyAssisstant
{
	public static GuildReceiveProperty DefaultProperty { get { return _property; } }
	public static void SetProperty(GuildReceiveProperty property)
	{
		_property = property;
	}
	static GuildReceiveProperty _property;

	//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


}