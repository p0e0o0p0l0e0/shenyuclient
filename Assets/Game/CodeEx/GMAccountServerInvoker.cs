using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GMAccountServerInvoker
{
	public static void DisplayServerList(GMAccount entity, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_0_DisplayServerList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisplayServerList(" + entity  + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisplayServerList(GMAccount entity, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_0_DisplayServerList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisplayServerList(" + entity  + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisplayPlayer(GMAccount entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_1_DisplayPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisplayPlayer(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisplayPlayer(GMAccount entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_1_DisplayPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisplayPlayer(" + entity  + ", " + ID + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByID(GMAccount entity, List<UInt64> IDList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_2_FindPlayerByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByID(" + entity  + ", " + IDList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FindPlayerByID(GMAccount entity, List<UInt64> IDList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_2_FindPlayerByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByID(" + entity  + ", " + IDList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByName(GMAccount entity, UInt16 Server, List<ViString> NameList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_3_FindPlayerByName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByName(" + entity  + ", " + Server + ", " + NameList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Server);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FindPlayerByName(GMAccount entity, UInt16 Server, List<ViString> NameList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_3_FindPlayerByName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByName(" + entity  + ", " + Server + ", " + NameList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Server);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByAccountID(GMAccount entity, List<UInt64> IDList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_4_FindPlayerByAccountID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByAccountID(" + entity  + ", " + IDList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FindPlayerByAccountID(GMAccount entity, List<UInt64> IDList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_4_FindPlayerByAccountID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByAccountID(" + entity  + ", " + IDList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, IDList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FindPlayerByAccountName(GMAccount entity, UInt16 Server, List<ViString> NameList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_5_FindPlayerByAccountName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByAccountName(" + entity  + ", " + Server + ", " + NameList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Server);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FindPlayerByAccountName(GMAccount entity, UInt16 Server, List<ViString> NameList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_5_FindPlayerByAccountName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FindPlayerByAccountName(" + entity  + ", " + Server + ", " + NameList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Server);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnNewDay(GMAccount entity, List<UInt16> ServerList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_6_OnNewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewDay(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnNewDay(GMAccount entity, List<UInt16> ServerList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_6_OnNewDay;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnNewDay(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetData(GMAccount entity, List<UInt16> ServerList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_7_ResetData;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetData(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetData(GMAccount entity, List<UInt16> ServerList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_7_ResetData;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetData(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetConstValue(GMAccount entity, List<UInt16> ServerList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_8_ResetConstValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetConstValue(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetConstValue(GMAccount entity, List<UInt16> ServerList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_8_ResetConstValue;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetConstValue(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddBoard(GMAccount entity, List<UInt16> ServerList, UInt8 Type, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_9_AddBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBoard(" + entity  + ", " + ServerList + ", " + Type + ", " + Content + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddBoard(GMAccount entity, List<UInt16> ServerList, UInt8 Type, ViString Content, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_9_AddBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBoard(" + entity  + ", " + ServerList + ", " + Type + ", " + Content + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddBoard(GMAccount entity, List<UInt16> ServerList, UInt8 Type, Int64 StartTime1970, Int64 EndTime1970, Int64 Span, UInt8 Loop, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_10_AddBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBoard(" + entity  + ", " + ServerList + ", " + Type + ", " + StartTime1970 + ", " + EndTime1970 + ", " + Span + ", " + Loop + ", " + Content + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, StartTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, EndTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Span);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Loop);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddBoard(GMAccount entity, List<UInt16> ServerList, UInt8 Type, Int64 StartTime1970, Int64 EndTime1970, Int64 Span, UInt8 Loop, ViString Content, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_10_AddBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBoard(" + entity  + ", " + ServerList + ", " + Type + ", " + StartTime1970 + ", " + EndTime1970 + ", " + Span + ", " + Loop + ", " + Content + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Type);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, StartTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, EndTime1970);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Span);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Loop);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelBoard(GMAccount entity, List<UInt16> ServerList, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_11_DelBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBoard(" + entity  + ", " + ServerList + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelBoard(GMAccount entity, List<UInt16> ServerList, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_11_DelBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBoard(" + entity  + ", " + ServerList + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddNote(GMAccount entity, List<UInt16> ServerList, ViString Title, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_12_AddNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNote(" + entity  + ", " + ServerList + ", " + Title + ", " + Content + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddNote(GMAccount entity, List<UInt16> ServerList, ViString Title, ViString Content, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_12_AddNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddNote(" + entity  + ", " + ServerList + ", " + Title + ", " + Content + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelNote(GMAccount entity, List<UInt16> ServerList, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_13_DelNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelNote(" + entity  + ", " + ServerList + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelNote(GMAccount entity, List<UInt16> ServerList, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_13_DelNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelNote(" + entity  + ", " + ServerList + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SendMail(GMAccount entity, List<UInt16> ServerList, UInt8 BroadcastRange, GMRequestProperty Request, MailProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_14_SendMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMail(" + entity  + ", " + ServerList + ", " + BroadcastRange + ", " + Request + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, BroadcastRange);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SendMail(GMAccount entity, List<UInt16> ServerList, UInt8 BroadcastRange, GMRequestProperty Request, MailProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_14_SendMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMail(" + entity  + ", " + ServerList + ", " + BroadcastRange + ", " + Request + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, BroadcastRange);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetActivityTime(GMAccount entity, List<UInt16> ServerList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_15_ResetActivityTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetActivityTime(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetActivityTime(GMAccount entity, List<UInt16> ServerList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_15_ResetActivityTime;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetActivityTime(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OpenActivity(GMAccount entity, List<UInt16> ServerList, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_16_OpenActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OpenActivity(" + entity  + ", " + ServerList + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OpenActivity(GMAccount entity, List<UInt16> ServerList, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_16_OpenActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OpenActivity(" + entity  + ", " + ServerList + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CloseActivity(GMAccount entity, List<UInt16> ServerList, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_17_CloseActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseActivity(" + entity  + ", " + ServerList + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CloseActivity(GMAccount entity, List<UInt16> ServerList, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_17_CloseActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CloseActivity(" + entity  + ", " + ServerList + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetTimeBoard(GMAccount entity, List<UInt16> ServerList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_18_ResetTimeBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetTimeBoard(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetTimeBoard(GMAccount entity, List<UInt16> ServerList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_18_ResetTimeBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetTimeBoard(" + entity  + ", " + ServerList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddCDKey(GMAccount entity, List<UInt16> ServerList, List<ViString> KeyList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_19_AddCDKey;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddCDKey(" + entity  + ", " + ServerList + ", " + KeyList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, KeyList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddCDKey(GMAccount entity, List<UInt16> ServerList, List<ViString> KeyList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_19_AddCDKey;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddCDKey(" + entity  + ", " + ServerList + ", " + KeyList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, KeyList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableIP(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AddressList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_20_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + ServerList + ", " + AddressList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisableIP(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AddressList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_20_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + ServerList + ", " + AddressList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableIP(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AddressList, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_21_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + ServerList + ", " + AddressList + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisableIP(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AddressList, Int64 Duration, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_21_DisableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableIP(" + entity  + ", " + ServerList + ", " + AddressList + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AddressList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnableIP(GMAccount entity, List<UInt16> ServerList, List<ViString> AddressList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_22_EnableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableIP(" + entity  + ", " + ServerList + ", " + AddressList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnableIP(GMAccount entity, List<UInt16> ServerList, List<ViString> AddressList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_22_EnableIP;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableIP(" + entity  + ", " + ServerList + ", " + AddressList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AddressList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableAccount(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AccountList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_23_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisableAccount(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AccountList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_23_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisableAccount(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AccountList, Int64 Duration)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_24_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisableAccount(GMAccount entity, List<UInt16> ServerList, List<DisableRecordProperty> AccountList, Int64 Duration, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_24_DisableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ", " + Duration + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<DisableRecordProperty>.Append(entity.RPC.OS, AccountList);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Duration);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnableAccount(GMAccount entity, List<UInt16> ServerList, List<ViString> AccountList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_25_EnableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnableAccount(GMAccount entity, List<UInt16> ServerList, List<ViString> AccountList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_25_EnableAccount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnableAccount(" + entity  + ", " + ServerList + ", " + AccountList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, AccountList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGameFuncClosed(GMAccount entity, List<UInt16> ServerList, List<UInt32> FuncList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_26_AddGameFuncClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGameFuncClosed(" + entity  + ", " + ServerList + ", " + FuncList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FuncList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddGameFuncClosed(GMAccount entity, List<UInt16> ServerList, List<UInt32> FuncList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_26_AddGameFuncClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGameFuncClosed(" + entity  + ", " + ServerList + ", " + FuncList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FuncList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelGameFuncClosed(GMAccount entity, List<UInt16> ServerList, List<UInt32> FuncList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_27_DelGameFuncClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGameFuncClosed(" + entity  + ", " + ServerList + ", " + FuncList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FuncList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelGameFuncClosed(GMAccount entity, List<UInt16> ServerList, List<UInt32> FuncList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_27_DelGameFuncClosed;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelGameFuncClosed(" + entity  + ", " + ServerList + ", " + FuncList + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, FuncList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecScript(GMAccount entity, List<UInt16> ServerList, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_28_ExecScript;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecScript(" + entity  + ", " + ServerList + ", " + Func + ", " + Params + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExecScript(GMAccount entity, List<UInt16> ServerList, ViString Func, ViString Params, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_28_ExecScript;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecScript(" + entity  + ", " + ServerList + ", " + Func + ", " + Params + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecScriptToPlayer(GMAccount entity, List<UInt16> ServerList, UInt8 BroadcastRange, GMRequestProperty Request, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_29_ExecScriptToPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecScriptToPlayer(" + entity  + ", " + ServerList + ", " + BroadcastRange + ", " + Request + ", " + Func + ", " + Params + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, BroadcastRange);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExecScriptToPlayer(GMAccount entity, List<UInt16> ServerList, UInt8 BroadcastRange, GMRequestProperty Request, ViString Func, ViString Params, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_29_ExecScriptToPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecScriptToPlayer(" + entity  + ", " + ServerList + ", " + BroadcastRange + ", " + Request + ", " + Func + ", " + Params + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerList);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, BroadcastRange);
		ViGameSerializer<GMRequestProperty>.Append(entity.RPC.OS, Request);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintProperty(GMAccount entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_30_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintProperty(GMAccount entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_30_PrintProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintProperty(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PrintGlobalProperty(GMAccount entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_31_PrintGlobalProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void PrintGlobalProperty(GMAccount entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_31_PrintGlobalProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PrintGlobalProperty(" + entity  + ", " + Name + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Name);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SendMail(GMAccount entity, List<UInt64> PlayerList, MailProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_32_SendMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMail(" + entity  + ", " + PlayerList + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SendMail(GMAccount entity, List<UInt64> PlayerList, MailProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_32_SendMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMail(" + entity  + ", " + PlayerList + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<MailProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExecScriptToPlayer(GMAccount entity, List<UInt64> PlayerList, ViString Func, ViString Params)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_33_ExecScriptToPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecScriptToPlayer(" + entity  + ", " + PlayerList + ", " + Func + ", " + Params + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ExecScriptToPlayer(GMAccount entity, List<UInt64> PlayerList, ViString Func, ViString Params, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_33_ExecScriptToPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExecScriptToPlayer(" + entity  + ", " + PlayerList + ", " + Func + ", " + Params + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Func);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Params);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_OnlineCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_34_SQL_OnlineCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_OnlineCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_OnlineCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_34_SQL_OnlineCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_OnlineCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_NewAccountCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_35_SQL_NewAccountCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_NewAccountCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_NewAccountCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_35_SQL_NewAccountCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_NewAccountCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_RechargeAccountStatistic(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_36_SQL_RechargeAccountStatistic;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_RechargeAccountStatistic(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_RechargeAccountStatistic(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_36_SQL_RechargeAccountStatistic;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_RechargeAccountStatistic(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_RechargeStatistic(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_37_SQL_RechargeStatistic;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_RechargeStatistic(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_RechargeStatistic(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_37_SQL_RechargeStatistic;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_RechargeStatistic(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_LoginCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_38_SQL_LoginCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_LoginCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_LoginCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_38_SQL_LoginCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_LoginCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_NewRechargeAccountCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_39_SQL_NewRechargeAccountCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_NewRechargeAccountCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_NewRechargeAccountCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_39_SQL_NewRechargeAccountCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_NewRechargeAccountCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_MaxAndAvgOnlineCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_40_SQL_MaxAndAvgOnlineCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_MaxAndAvgOnlineCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_MaxAndAvgOnlineCount(GMAccount entity, UInt16 ServerID, Int64 Time1970Left, Int64 Time1970Right, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_40_SQL_MaxAndAvgOnlineCount;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_MaxAndAvgOnlineCount(" + entity  + ", " + ServerID + ", " + Time1970Left + ", " + Time1970Right + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Left);
		ViGameSerializer<Int64>.Append(entity.RPC.OS, Time1970Right);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_FindNameByNameAlias(GMAccount entity, UInt16 ServerID, ViString NameAlias, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_41_SQL_FindNameByNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_FindNameByNameAlias(" + entity  + ", " + ServerID + ", " + NameAlias + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameAlias);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_FindNameByNameAlias(GMAccount entity, UInt16 ServerID, ViString NameAlias, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_41_SQL_FindNameByNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_FindNameByNameAlias(" + entity  + ", " + ServerID + ", " + NameAlias + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameAlias);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SQL_FindNameByNameAlias(GMAccount entity, UInt16 ServerID, List<ViString> NameAliasList, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_42_SQL_FindNameByNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_FindNameByNameAlias(" + entity  + ", " + ServerID + ", " + NameAliasList + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameAliasList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SQL_FindNameByNameAlias(GMAccount entity, UInt16 ServerID, List<ViString> NameAliasList, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMAccountServerMethod.METHOD_42_SQL_FindNameByNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SQL_FindNameByNameAlias(" + entity  + ", " + ServerID + ", " + NameAliasList + ", " + Tag + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!"); 
			return;
		}
		entity.RPC.ACK.Add(funcID, callback);
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ServerID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameAliasList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

}
