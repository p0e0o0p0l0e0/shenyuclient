using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityTypeID = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public static class ViGameLogicScript
{
	public static void Start()
	{
		//
		ViGameSerializer<ViGameUnit>.AppendExec = ViGameUnitSerializer.Append;
		ViGameSerializer<ViGameUnit>.ReadExec = ViGameUnitSerializer.Read;
		ViGameSerializer<ViGameUnit>.ReadStringExec = ViGameUnitSerializer.Read;
	}
	
	public static void StartCommand()
	{
		ViGameUnitCommandInvoker.Start();
	}
	
	public static void End()
	{
		
	}
}
