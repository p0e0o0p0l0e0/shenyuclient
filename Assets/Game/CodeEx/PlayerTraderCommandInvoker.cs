using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerTraderCommandInvoker : ViEntityCommandInvoker<PlayerTrader>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
	}
	public static new bool Exec(PlayerTrader entity, string name, List<string> paramList)
	{
		if (ViEntityCommandInvoker<PlayerTrader>.Exec(entity, name, paramList) == true) { return true; }
		else { return PlayerComponentCommandInvoker.Exec(entity, name, paramList); }
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		PlayerTrader deriveEntity = entity as PlayerTrader;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
}
