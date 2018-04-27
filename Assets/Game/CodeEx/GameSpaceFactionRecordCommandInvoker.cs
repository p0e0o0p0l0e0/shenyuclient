using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameSpaceFactionRecordCommandInvoker : ViEntityCommandInvoker<GameSpaceFactionRecord>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
	}
	public static new bool Exec(GameSpaceFactionRecord entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<GameSpaceFactionRecord>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		GameSpaceFactionRecord deriveEntity = entity as GameSpaceFactionRecord;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
}
