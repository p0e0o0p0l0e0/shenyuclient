using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ActivityRecordCommandInvoker : ViEntityCommandInvoker<ActivityRecord>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
	}
	public static new bool Exec(ActivityRecord entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<ActivityRecord>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		ActivityRecord deriveEntity = entity as ActivityRecord;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
}