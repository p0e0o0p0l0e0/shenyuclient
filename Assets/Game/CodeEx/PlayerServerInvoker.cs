using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerServerInvoker
{
	public static void SetNameAlias(Player entity, ViString Name, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_8_SetNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetNameAlias(" + entity  + ", " + Name + ", " + Result + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetNameAlias(Player entity, ViString Name, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_8_SetNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetNameAlias(" + entity  + ", " + Name + ", " + Result + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPhoto(Player entity, UInt8 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_9_SetPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPhoto(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPhoto(Player entity, UInt8 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_9_SetPhoto;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPhoto(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EndClientWatchIgnore(Player entity, UInt32 Func)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_43_EndClientWatchIgnore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndClientWatchIgnore(" + entity  + ", " + Func + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Func);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EndClientWatchIgnore(Player entity, UInt32 Func, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_43_EndClientWatchIgnore;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndClientWatchIgnore(" + entity  + ", " + Func + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Func);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void GotoBigSpace(Player entity, UInt32 Space)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_46_GotoBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoBigSpace(" + entity  + ", " + Space + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void GotoBigSpace(Player entity, UInt32 Space, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_46_GotoBigSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoBigSpace(" + entity  + ", " + Space + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void LeaveSpace(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_47_LeaveSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LeaveSpace(" + entity  + ")");
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
	public static void LeaveSpace(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_47_LeaveSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LeaveSpace(" + entity  + ")");
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

	public static void CreatePublicSpaceEnter(Player entity, UInt32 Space, ViString Password)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_70_CreatePublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreatePublicSpaceEnter(" + entity  + ", " + Space + ", " + Password + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Password);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CreatePublicSpaceEnter(Player entity, UInt32 Space, ViString Password, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_70_CreatePublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreatePublicSpaceEnter(" + entity  + ", " + Space + ", " + Password + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Password);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterPublicSpaceEnter(Player entity, UInt64 ID, ViString Password)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_71_EnterPublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPublicSpaceEnter(" + entity  + ", " + ID + ", " + Password + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Password);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterPublicSpaceEnter(Player entity, UInt64 ID, ViString Password, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_71_EnterPublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterPublicSpaceEnter(" + entity  + ", " + ID + ", " + Password + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Password);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChangePublicSpaceEnterFaction(Player entity, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_72_ChangePublicSpaceEnterFaction;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChangePublicSpaceEnterFaction(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChangePublicSpaceEnterFaction(Player entity, UInt8 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_72_ChangePublicSpaceEnterFaction;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChangePublicSpaceEnterFaction(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPublicSpaceEnterFakePlayer(Player entity, UInt8 FactionIdx, UInt8 AIType)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_73_AddPublicSpaceEnterFakePlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPublicSpaceEnterFakePlayer(" + entity  + ", " + FactionIdx + ", " + AIType + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, FactionIdx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, AIType);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddPublicSpaceEnterFakePlayer(Player entity, UInt8 FactionIdx, UInt8 AIType, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_73_AddPublicSpaceEnterFakePlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPublicSpaceEnterFakePlayer(" + entity  + ", " + FactionIdx + ", " + AIType + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, FactionIdx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, AIType);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPublicSpaceEnterReady(Player entity, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_74_SetPublicSpaceEnterReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPublicSpaceEnterReady(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPublicSpaceEnterReady(Player entity, UInt8 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_74_SetPublicSpaceEnterReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPublicSpaceEnterReady(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FirePublicSpaceEnterMember(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_75_FirePublicSpaceEnterMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FirePublicSpaceEnterMember(" + entity  + ", " + ID + ")");
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
	public static void FirePublicSpaceEnterMember(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_75_FirePublicSpaceEnterMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FirePublicSpaceEnterMember(" + entity  + ", " + ID + ")");
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

	public static void ExitPublicSpaceEnter(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_76_ExitPublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitPublicSpaceEnter(" + entity  + ")");
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
	public static void ExitPublicSpaceEnter(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_76_ExitPublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitPublicSpaceEnter(" + entity  + ")");
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

	public static void GotoPublicSpaceEnter(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_77_GotoPublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoPublicSpaceEnter(" + entity  + ")");
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
	public static void GotoPublicSpaceEnter(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_77_GotoPublicSpaceEnter;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoPublicSpaceEnter(" + entity  + ")");
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

	public static void PublicSpaceManagerWatchStart(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_78_PublicSpaceManagerWatchStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PublicSpaceManagerWatchStart(" + entity  + ")");
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
	public static void PublicSpaceManagerWatchStart(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_78_PublicSpaceManagerWatchStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PublicSpaceManagerWatchStart(" + entity  + ")");
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

	public static void PublicSpaceManagerWatchEnd(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_79_PublicSpaceManagerWatchEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PublicSpaceManagerWatchEnd(" + entity  + ")");
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
	public static void PublicSpaceManagerWatchEnd(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_79_PublicSpaceManagerWatchEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PublicSpaceManagerWatchEnd(" + entity  + ")");
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

	public static void ChatGroupWatchStart(Player entity, List<UInt8> ChannelList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_81_ChatGroupWatchStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatGroupWatchStart(" + entity  + ", " + ChannelList + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ChannelList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatGroupWatchStart(Player entity, List<UInt8> ChannelList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_81_ChatGroupWatchStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatGroupWatchStart(" + entity  + ", " + ChannelList + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ChannelList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatGroupWatchEnd(Player entity, List<UInt8> ChannelList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_82_ChatGroupWatchEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatGroupWatchEnd(" + entity  + ", " + ChannelList + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ChannelList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatGroupWatchEnd(Player entity, List<UInt8> ChannelList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_82_ChatGroupWatchEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatGroupWatchEnd(" + entity  + ", " + ChannelList + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ChannelList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptBegin(Player entity, UInt8 Channel)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_83_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + Channel + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatScriptBegin(Player entity, UInt8 Channel, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_83_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + Channel + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptBegin(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_84_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + Name + ")");
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
	public static void ChatScriptBegin(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_84_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + Name + ")");
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

	public static void ChatScriptBegin(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_85_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + ID + ")");
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
	public static void ChatScriptBegin(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_85_ChatScriptBegin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptBegin(" + entity  + ", " + ID + ")");
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

	public static void ChatScriptEnd(Player entity, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_86_ChatScriptEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptEnd(" + entity  + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatScriptEnd(Player entity, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_86_ChatScriptEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptEnd(" + entity  + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptShowItem(Player entity, UInt8 Bag, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_87_ChatScriptShowItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptShowItem(" + entity  + ", " + Bag + ", " + Slot + ")");
		}
		if (entity == null)
		{
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		entity.RPC.PreMessage(entity, funcID);
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatScriptWatchItem(Player entity, UInt8 Channel, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_88_ChatScriptWatchItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptWatchItem(" + entity  + ", " + Channel + ", " + ID + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatScriptWatchItem(Player entity, UInt8 Channel, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_88_ChatScriptWatchItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatScriptWatchItem(" + entity  + ", " + Channel + ", " + ID + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatOffline(Player entity, UInt64 ID, ViString Content, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_89_ChatOffline;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatOffline(" + entity  + ", " + ID + ", " + Content + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatOffline(Player entity, UInt64 ID, ViString Content, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_89_ChatOffline;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatOffline(" + entity  + ", " + ID + ", " + Content + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearOfflineChat(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_90_ClearOfflineChat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOfflineChat(" + entity  + ", " + ID + ")");
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
	public static void ClearOfflineChat(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_90_ClearOfflineChat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearOfflineChat(" + entity  + ", " + ID + ")");
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

	public static void ChatMessage(Player entity, UInt8 Channel, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_91_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Channel + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatMessage(Player entity, UInt8 Channel, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_91_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Channel + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Channel);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatMessage(Player entity, ViString Name, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_92_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Name + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatMessage(Player entity, ViString Name, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_92_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + Name + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ChatMessage(Player entity, UInt64 ID, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_93_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + ID + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ChatMessage(Player entity, UInt64 ID, ViString Script, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_93_ChatMessage;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ChatMessage(" + entity  + ", " + ID + ", " + Script + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterActivity(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_99_EnterActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterActivity(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_99_EnterActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitActivity(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_100_ExitActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitActivity(" + entity  + ")");
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
	public static void ExitActivity(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_100_ExitActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitActivity(" + entity  + ")");
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

	public static void BuyScoreMarketItem(Player entity, UInt32 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_103_BuyScoreMarketItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyScoreMarketItem(" + entity  + ", " + ID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BuyScoreMarketItem(Player entity, UInt32 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_103_BuyScoreMarketItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyScoreMarketItem(" + entity  + ", " + ID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TradeManagerWatchStart(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_112_TradeManagerWatchStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TradeManagerWatchStart(" + entity  + ")");
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
	public static void TradeManagerWatchStart(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_112_TradeManagerWatchStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TradeManagerWatchStart(" + entity  + ")");
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

	public static void TradeManagerWatchEnd(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_113_TradeManagerWatchEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TradeManagerWatchEnd(" + entity  + ")");
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
	public static void TradeManagerWatchEnd(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_113_TradeManagerWatchEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TradeManagerWatchEnd(" + entity  + ")");
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

	public static void AddItemTrade(Player entity, UInt16 BagSlot, Int16 Count, Int32 Price, Int32 AuctionPrice)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_114_AddItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemTrade(" + entity  + ", " + BagSlot + ", " + Count + ", " + Price + ", " + AuctionPrice + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, BagSlot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Price);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, AuctionPrice);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItemTrade(Player entity, UInt16 BagSlot, Int16 Count, Int32 Price, Int32 AuctionPrice, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_114_AddItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItemTrade(" + entity  + ", " + BagSlot + ", " + Count + ", " + Price + ", " + AuctionPrice + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, BagSlot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Price);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, AuctionPrice);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelItemTrade(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_115_DelItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelItemTrade(" + entity  + ", " + ID + ")");
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
	public static void DelItemTrade(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_115_DelItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelItemTrade(" + entity  + ", " + ID + ")");
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

	public static void SearchItemTrade(Player entity, UInt8 SortType, UInt8 ItemType, List<UInt32> ItemTemplateList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_116_SearchItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SearchItemTrade(" + entity  + ", " + SortType + ", " + ItemType + ", " + ItemTemplateList + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, SortType);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ItemType);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ItemTemplateList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SearchItemTrade(Player entity, UInt8 SortType, UInt8 ItemType, List<UInt32> ItemTemplateList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_116_SearchItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SearchItemTrade(" + entity  + ", " + SortType + ", " + ItemType + ", " + ItemTemplateList + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, SortType);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, ItemType);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ItemTemplateList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateItemTrade(Player entity, UInt16 Page)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_117_UpdateItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateItemTrade(" + entity  + ", " + Page + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Page);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateItemTrade(Player entity, UInt16 Page, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_117_UpdateItemTrade;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateItemTrade(" + entity  + ", " + Page + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Page);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BuyTradeItem(Player entity, UInt64 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_118_BuyTradeItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyTradeItem(" + entity  + ", " + ID + ", " + Count + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BuyTradeItem(Player entity, UInt64 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_118_BuyTradeItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyTradeItem(" + entity  + ", " + ID + ", " + Count + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AuctionTradeItem(Player entity, UInt64 ID, Int32 Price)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_119_AuctionTradeItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AuctionTradeItem(" + entity  + ", " + ID + ", " + Price + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Price);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AuctionTradeItem(Player entity, UInt64 ID, Int32 Price, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_119_AuctionTradeItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AuctionTradeItem(" + entity  + ", " + ID + ", " + Price + ")");
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Price);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateItemTradeOwnList(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_121_UpdateItemTradeOwnList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateItemTradeOwnList(" + entity  + ")");
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
	public static void UpdateItemTradeOwnList(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_121_UpdateItemTradeOwnList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateItemTradeOwnList(" + entity  + ")");
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

	public static void UpdateItemTradeAuctionList(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_122_UpdateItemTradeAuctionList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateItemTradeAuctionList(" + entity  + ")");
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
	public static void UpdateItemTradeAuctionList(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_122_UpdateItemTradeAuctionList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateItemTradeAuctionList(" + entity  + ")");
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

	public static void CreateGuild(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_127_CreateGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateGuild(" + entity  + ", " + Name + ")");
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
	public static void CreateGuild(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_127_CreateGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateGuild(" + entity  + ", " + Name + ")");
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

	public static void UpdateGuildList(Player entity, UInt16 Page)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_128_UpdateGuildList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateGuildList(" + entity  + ", " + Page + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Page);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateGuildList(Player entity, UInt16 Page, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_128_UpdateGuildList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateGuildList(" + entity  + ", " + Page + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Page);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateGuildRecommand(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_129_UpdateGuildRecommand;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateGuildRecommand(" + entity  + ")");
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
	public static void UpdateGuildRecommand(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_129_UpdateGuildRecommand;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateGuildRecommand(" + entity  + ")");
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

	public static void SearchGuildName(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_130_SearchGuildName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SearchGuildName(" + entity  + ", " + Name + ")");
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
	public static void SearchGuildName(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_130_SearchGuildName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SearchGuildName(" + entity  + ", " + Name + ")");
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

	public static void ApplyGuild(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_131_ApplyGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ApplyGuild(" + entity  + ", " + ID + ")");
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
	public static void ApplyGuild(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_131_ApplyGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ApplyGuild(" + entity  + ", " + ID + ")");
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

	public static void ApplyGuild(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_132_ApplyGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ApplyGuild(" + entity  + ", " + Name + ")");
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
	public static void ApplyGuild(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_132_ApplyGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ApplyGuild(" + entity  + ", " + Name + ")");
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

	public static void CancelGuildApply(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_133_CancelGuildApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CancelGuildApply(" + entity  + ", " + ID + ")");
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
	public static void CancelGuildApply(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_133_CancelGuildApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CancelGuildApply(" + entity  + ", " + ID + ")");
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

	public static void UpdateGuildApplyRecord(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_134_UpdateGuildApplyRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateGuildApplyRecord(" + entity  + ")");
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
	public static void UpdateGuildApplyRecord(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_134_UpdateGuildApplyRecord;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateGuildApplyRecord(" + entity  + ")");
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

	public static void AgreeGuildApply(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_135_AgreeGuildApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeGuildApply(" + entity  + ", " + ID + ")");
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
	public static void AgreeGuildApply(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_135_AgreeGuildApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeGuildApply(" + entity  + ", " + ID + ")");
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

	public static void AgreeGuildAllApply(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_136_AgreeGuildAllApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeGuildAllApply(" + entity  + ")");
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
	public static void AgreeGuildAllApply(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_136_AgreeGuildAllApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeGuildAllApply(" + entity  + ")");
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

	public static void DisagreeGuildApply(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_137_DisagreeGuildApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreeGuildApply(" + entity  + ", " + ID + ")");
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
	public static void DisagreeGuildApply(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_137_DisagreeGuildApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreeGuildApply(" + entity  + ", " + ID + ")");
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

	public static void DisagreeGuildAllApply(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_138_DisagreeGuildAllApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreeGuildAllApply(" + entity  + ")");
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
	public static void DisagreeGuildAllApply(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_138_DisagreeGuildAllApply;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreeGuildAllApply(" + entity  + ")");
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

	public static void GuildMail(Player entity, ViString Title, ViString Content)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_139_GuildMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GuildMail(" + entity  + ", " + Title + ", " + Content + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void GuildMail(Player entity, ViString Title, ViString Content, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_139_GuildMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GuildMail(" + entity  + ", " + Title + ", " + Content + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitGuild(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_141_ExitGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitGuild(" + entity  + ")");
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
	public static void ExitGuild(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_141_ExitGuild;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitGuild(" + entity  + ")");
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

	public static void FireGuildMember(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_142_FireGuildMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FireGuildMember(" + entity  + ", " + ID + ")");
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
	public static void FireGuildMember(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_142_FireGuildMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FireGuildMember(" + entity  + ", " + ID + ")");
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

	public static void GuildImpeach(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_143_GuildImpeach;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GuildImpeach(" + entity  + ")");
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
	public static void GuildImpeach(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_143_GuildImpeach;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GuildImpeach(" + entity  + ")");
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

	public static void HandOverGuildLeader(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_147_HandOverGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> HandOverGuildLeader(" + entity  + ", " + ID + ")");
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
	public static void HandOverGuildLeader(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_147_HandOverGuildLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> HandOverGuildLeader(" + entity  + ", " + ID + ")");
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

	public static void SetGuildMemberPosition(Player entity, UInt64 ID, UInt8 Position)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_148_SetGuildMemberPosition;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildMemberPosition(" + entity  + ", " + ID + ", " + Position + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Position);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildMemberPosition(Player entity, UInt64 ID, UInt8 Position, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_148_SetGuildMemberPosition;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildMemberPosition(" + entity  + ", " + ID + ", " + Position + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Position);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearGuildMemberPosition(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_149_ClearGuildMemberPosition;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearGuildMemberPosition(" + entity  + ", " + ID + ")");
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
	public static void ClearGuildMemberPosition(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_149_ClearGuildMemberPosition;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearGuildMemberPosition(" + entity  + ", " + ID + ")");
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

	public static void SetGuildIntrodution(Player entity, ViString Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_152_SetGuildIntrodution;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildIntrodution(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildIntrodution(Player entity, ViString Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_152_SetGuildIntrodution;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildIntrodution(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildBoard(Player entity, ViString Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_153_SetGuildBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildBoard(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildBoard(Player entity, ViString Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_153_SetGuildBoard;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildBoard(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildResponseType(Player entity, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_154_SetGuildResponseType;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildResponseType(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildResponseType(Player entity, UInt8 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_154_SetGuildResponseType;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildResponseType(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetGuildReqEnterLevel(Player entity, Int16 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_155_SetGuildReqEnterLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildReqEnterLevel(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetGuildReqEnterLevel(Player entity, Int16 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_155_SetGuildReqEnterLevel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetGuildReqEnterLevel(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void GuildRecruit(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_156_GuildRecruit;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GuildRecruit(" + entity  + ")");
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
	public static void GuildRecruit(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_156_GuildRecruit;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GuildRecruit(" + entity  + ")");
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

	public static void GotoGuildSmallSpace(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_157_GotoGuildSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoGuildSmallSpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void GotoGuildSmallSpace(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_157_GotoGuildSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoGuildSmallSpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ConvokeGuildSmallSpace(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_158_ConvokeGuildSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildSmallSpace(" + entity  + ")");
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
	public static void ConvokeGuildSmallSpace(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_158_ConvokeGuildSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildSmallSpace(" + entity  + ")");
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

	public static void ConvokeGuildSmallSpace(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_159_ConvokeGuildSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildSmallSpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ConvokeGuildSmallSpace(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_159_ConvokeGuildSmallSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildSmallSpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterGuildActivitySeat(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_160_EnterGuildActivitySeat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterGuildActivitySeat(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterGuildActivitySeat(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_160_EnterGuildActivitySeat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterGuildActivitySeat(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitGuildActivitySeat(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_161_ExitGuildActivitySeat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitGuildActivitySeat(" + entity  + ")");
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
	public static void ExitGuildActivitySeat(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_161_ExitGuildActivitySeat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitGuildActivitySeat(" + entity  + ")");
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

	public static void FireGuildActivitySeat(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_162_FireGuildActivitySeat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FireGuildActivitySeat(" + entity  + ", " + ID + ")");
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
	public static void FireGuildActivitySeat(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_162_FireGuildActivitySeat;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FireGuildActivitySeat(" + entity  + ", " + ID + ")");
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

	public static void ConvokeGuildActivity(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_163_ConvokeGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildActivity(" + entity  + ")");
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
	public static void ConvokeGuildActivity(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_163_ConvokeGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildActivity(" + entity  + ")");
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

	public static void ConvokeGuildActivity(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_164_ConvokeGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ConvokeGuildActivity(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_164_ConvokeGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ConvokeGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void StartGuildActivity(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_165_StartGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> StartGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void StartGuildActivity(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_165_StartGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> StartGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EndGuildActivity(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_166_EndGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EndGuildActivity(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_166_EndGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterGuildActivity(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_167_EnterGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterGuildActivity(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_167_EnterGuildActivity;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterGuildActivity(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CreateParty(Player entity, UInt64 Target)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_172_CreateParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateParty(" + entity  + ", " + Target + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CreateParty(Player entity, UInt64 Target, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_172_CreateParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateParty(" + entity  + ", " + Target + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CreateParty(Player entity, List<PartySpaceSelectProperty> SpaceList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_173_CreateParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateParty(" + entity  + ", " + SpaceList + ")");
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
		ViGameSerializer<PartySpaceSelectProperty>.Append(entity.RPC.OS, SpaceList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CreateParty(Player entity, List<PartySpaceSelectProperty> SpaceList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_173_CreateParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateParty(" + entity  + ", " + SpaceList + ")");
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
		ViGameSerializer<PartySpaceSelectProperty>.Append(entity.RPC.OS, SpaceList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ExitParty(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_174_ExitParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitParty(" + entity  + ")");
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
	public static void ExitParty(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_174_ExitParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ExitParty(" + entity  + ")");
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

	public static void InvitePartyMember(Player entity, UInt64 Entity, UInt8 Chanel)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_175_InvitePartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> InvitePartyMember(" + entity  + ", " + Entity + ", " + Chanel + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Entity);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Chanel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void InvitePartyMember(Player entity, UInt64 Entity, UInt8 Chanel, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_175_InvitePartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> InvitePartyMember(" + entity  + ", " + Entity + ", " + Chanel + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Entity);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Chanel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void InvitePartyMember(Player entity, ViString Entity, UInt8 Chanel)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_176_InvitePartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> InvitePartyMember(" + entity  + ", " + Entity + ", " + Chanel + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Chanel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void InvitePartyMember(Player entity, ViString Entity, UInt8 Chanel, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_176_InvitePartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> InvitePartyMember(" + entity  + ", " + Entity + ", " + Chanel + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Chanel);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CancelInvitePartyMember(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_177_CancelInvitePartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CancelInvitePartyMember(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CancelInvitePartyMember(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_177_CancelInvitePartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CancelInvitePartyMember(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CancelInvitePartyMemberAll(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_178_CancelInvitePartyMemberAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CancelInvitePartyMemberAll(" + entity  + ")");
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
	public static void CancelInvitePartyMemberAll(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_178_CancelInvitePartyMemberAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CancelInvitePartyMemberAll(" + entity  + ")");
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

	public static void AgreePartyInvite(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_179_AgreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreePartyInvite(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AgreePartyInvite(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_179_AgreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreePartyInvite(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisagreePartyInvite(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_180_DisagreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreePartyInvite(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisagreePartyInvite(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_180_DisagreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreePartyInvite(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisagreePartyInviteAll(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_181_DisagreePartyInviteAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreePartyInviteAll(" + entity  + ")");
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
	public static void DisagreePartyInviteAll(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_181_DisagreePartyInviteAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreePartyInviteAll(" + entity  + ")");
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

	public static void DelPartyMember(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_182_DelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyMember(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelPartyMember(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_182_DelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyMember(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPartyMemberState(Player entity, UInt8 Ready)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_183_SetPartyMemberState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyMemberState(" + entity  + ", " + Ready + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Ready);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPartyMemberState(Player entity, UInt8 Ready, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_183_SetPartyMemberState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyMemberState(" + entity  + ", " + Ready + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Ready);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPartyMemberAutoReady(Player entity, UInt8 AutoReady)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_184_SetPartyMemberAutoReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyMemberAutoReady(" + entity  + ", " + AutoReady + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, AutoReady);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPartyMemberAutoReady(Player entity, UInt8 AutoReady, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_184_SetPartyMemberAutoReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyMemberAutoReady(" + entity  + ", " + AutoReady + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, AutoReady);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RecommandParty(Player entity, UInt64 Entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_185_RecommandParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RecommandParty(" + entity  + ", " + Entity + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RecommandParty(Player entity, UInt64 Entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_185_RecommandParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RecommandParty(" + entity  + ", " + Entity + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RecommandParty(Player entity, ViString Entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_186_RecommandParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RecommandParty(" + entity  + ", " + Entity + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RecommandParty(Player entity, ViString Entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_186_RecommandParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RecommandParty(" + entity  + ", " + Entity + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Entity);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPartyRecommand(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_187_DelPartyRecommand;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyRecommand(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelPartyRecommand(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_187_DelPartyRecommand;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyRecommand(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPartyMatchSpace(Player entity, List<PartySpaceSelectProperty> SpaceList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_189_SetPartyMatchSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyMatchSpace(" + entity  + ", " + SpaceList + ")");
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
		ViGameSerializer<PartySpaceSelectProperty>.Append(entity.RPC.OS, SpaceList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPartyMatchSpace(Player entity, List<PartySpaceSelectProperty> SpaceList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_189_SetPartyMatchSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyMatchSpace(" + entity  + ", " + SpaceList + ")");
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
		ViGameSerializer<PartySpaceSelectProperty>.Append(entity.RPC.OS, SpaceList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void StartPartyMatching(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_190_StartPartyMatching;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> StartPartyMatching(" + entity  + ")");
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
	public static void StartPartyMatching(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_190_StartPartyMatching;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> StartPartyMatching(" + entity  + ")");
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

	public static void EndPartyMatching(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_191_EndPartyMatching;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndPartyMatching(" + entity  + ")");
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
	public static void EndPartyMatching(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_191_EndPartyMatching;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EndPartyMatching(" + entity  + ")");
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

	public static void SetPartyTarget(Player entity, UInt64 NewTarget)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_192_SetPartyTarget;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyTarget(" + entity  + ", " + NewTarget + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, NewTarget);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPartyTarget(Player entity, UInt64 NewTarget, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_192_SetPartyTarget;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPartyTarget(" + entity  + ", " + NewTarget + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, NewTarget);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void PartyList(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_193_PartyList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PartyList(" + entity  + ")");
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
	public static void PartyList(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_193_PartyList;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> PartyList(" + entity  + ")");
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

	public static void AgreePartyInvite(Player entity, UInt64 PartyID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_194_AgreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreePartyInvite(" + entity  + ", " + PartyID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AgreePartyInvite(Player entity, UInt64 PartyID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_194_AgreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreePartyInvite(" + entity  + ", " + PartyID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisagreePartyInvite(Player entity, UInt64 PartyID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_195_DisagreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreePartyInvite(" + entity  + ", " + PartyID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisagreePartyInvite(Player entity, UInt64 PartyID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_195_DisagreePartyInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreePartyInvite(" + entity  + ", " + PartyID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AgreeJoinPartyLazy(Player entity, UInt8 Apply)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_196_AgreeJoinPartyLazy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeJoinPartyLazy(" + entity  + ", " + Apply + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Apply);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AgreeJoinPartyLazy(Player entity, UInt8 Apply, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_196_AgreeJoinPartyLazy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeJoinPartyLazy(" + entity  + ", " + Apply + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Apply);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPartyMember(Player entity, UInt64 PlayerID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_197_DelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyMember(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelPartyMember(Player entity, UInt64 PlayerID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_197_DelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPartyMember(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RequestJoinParty(Player entity, UInt64 PartyID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_198_RequestJoinParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RequestJoinParty(" + entity  + ", " + PartyID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RequestJoinParty(Player entity, UInt64 PartyID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_198_RequestJoinParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RequestJoinParty(" + entity  + ", " + PartyID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PartyID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void RequestJoinPartyLazy(Player entity, List<UInt64> tagrets)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_199_RequestJoinPartyLazy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RequestJoinPartyLazy(" + entity  + ", " + tagrets + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, tagrets);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RequestJoinPartyLazy(Player entity, List<UInt64> tagrets, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_199_RequestJoinPartyLazy;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RequestJoinPartyLazy(" + entity  + ", " + tagrets + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, tagrets);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AgreeJoinParty(Player entity, UInt64 PlayerID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_200_AgreeJoinParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeJoinParty(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AgreeJoinParty(Player entity, UInt64 PlayerID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_200_AgreeJoinParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AgreeJoinParty(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DisagreeJoinParty(Player entity, UInt64 PlayerID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_201_DisagreeJoinParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreeJoinParty(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DisagreeJoinParty(Player entity, UInt64 PlayerID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_201_DisagreeJoinParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DisagreeJoinParty(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DeputePartyLeader(Player entity, UInt64 PlayerID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_202_DeputePartyLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeputePartyLeader(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DeputePartyLeader(Player entity, UInt64 PlayerID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_202_DeputePartyLeader;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeputePartyLeader(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void GotoBigSpaceWithParty(Player entity, UInt32 Space, UInt64 Target)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_203_GotoBigSpaceWithParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoBigSpaceWithParty(" + entity  + ", " + Space + ", " + Target + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void GotoBigSpaceWithParty(Player entity, UInt32 Space, UInt64 Target, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_203_GotoBigSpaceWithParty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GotoBigSpaceWithParty(" + entity  + ", " + Space + ", " + Target + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Space);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void VoteDelPartyMember(Player entity, UInt64 PlayerID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_204_VoteDelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> VoteDelPartyMember(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void VoteDelPartyMember(Player entity, UInt64 PlayerID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_204_VoteDelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> VoteDelPartyMember(" + entity  + ", " + PlayerID + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ReplyVoteDelPartyMember(Player entity, UInt64 PlayerID, UInt8 Confirm)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_205_ReplyVoteDelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReplyVoteDelPartyMember(" + entity  + ", " + PlayerID + ", " + Confirm + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Confirm);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ReplyVoteDelPartyMember(Player entity, UInt64 PlayerID, UInt8 Confirm, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_205_ReplyVoteDelPartyMember;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReplyVoteDelPartyMember(" + entity  + ", " + PlayerID + ", " + Confirm + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, PlayerID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Confirm);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SpaceMatchEnterGroupReady(Player entity, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_206_SpaceMatchEnterGroupReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceMatchEnterGroupReady(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SpaceMatchEnterGroupReady(Player entity, UInt8 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_206_SpaceMatchEnterGroupReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceMatchEnterGroupReady(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SpaceMatchEnterGroupSelectHero(Player entity, UInt32 Hero)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_207_SpaceMatchEnterGroupSelectHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceMatchEnterGroupSelectHero(" + entity  + ", " + Hero + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SpaceMatchEnterGroupSelectHero(Player entity, UInt32 Hero, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_207_SpaceMatchEnterGroupSelectHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceMatchEnterGroupSelectHero(" + entity  + ", " + Hero + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SpaceMatchEnterGroupSelectHeroReady(Player entity, UInt8 Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_208_SpaceMatchEnterGroupSelectHeroReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceMatchEnterGroupSelectHeroReady(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SpaceMatchEnterGroupSelectHeroReady(Player entity, UInt8 Value, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_208_SpaceMatchEnterGroupSelectHeroReady;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SpaceMatchEnterGroupSelectHeroReady(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelFriend(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_211_DelFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFriend(" + entity  + ", " + ID + ")");
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
	public static void DelFriend(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_211_DelFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFriend(" + entity  + ", " + ID + ")");
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

	public static void DelFriend(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_212_DelFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFriend(" + entity  + ", " + Name + ")");
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
	public static void DelFriend(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_212_DelFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelFriend(" + entity  + ", " + Name + ")");
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

	public static void SetFriendNote(Player entity, UInt64 ID, ViString Note)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_213_SetFriendNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetFriendNote(" + entity  + ", " + ID + ", " + Note + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetFriendNote(Player entity, UInt64 ID, ViString Note, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_213_SetFriendNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetFriendNote(" + entity  + ", " + ID + ", " + Note + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Note);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddBlackFriend(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_214_AddBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBlackFriend(" + entity  + ", " + ID + ")");
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
	public static void AddBlackFriend(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_214_AddBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBlackFriend(" + entity  + ", " + ID + ")");
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

	public static void AddBlackFriend(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_215_AddBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBlackFriend(" + entity  + ", " + Name + ")");
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
	public static void AddBlackFriend(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_215_AddBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddBlackFriend(" + entity  + ", " + Name + ")");
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

	public static void DelBlackFriend(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_216_DelBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBlackFriend(" + entity  + ", " + ID + ")");
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
	public static void DelBlackFriend(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_216_DelBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBlackFriend(" + entity  + ", " + ID + ")");
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

	public static void DelBlackFriend(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_217_DelBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBlackFriend(" + entity  + ", " + Name + ")");
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
	public static void DelBlackFriend(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_217_DelBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelBlackFriend(" + entity  + ", " + Name + ")");
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

	public static void UnblockBlackFriend(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_218_UnblockBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UnblockBlackFriend(" + entity  + ", " + ID + ")");
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
	public static void UnblockBlackFriend(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_218_UnblockBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UnblockBlackFriend(" + entity  + ", " + ID + ")");
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

	public static void UnblockBlackFriend(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_219_UnblockBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UnblockBlackFriend(" + entity  + ", " + Name + ")");
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
	public static void UnblockBlackFriend(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_219_UnblockBlackFriend;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UnblockBlackFriend(" + entity  + ", " + Name + ")");
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

	public static void FriendInvite(Player entity, UInt64 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_220_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + ID + ")");
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
	public static void FriendInvite(Player entity, UInt64 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_220_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + ID + ")");
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

	public static void FriendInvite(Player entity, List<UInt64> IDList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_221_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + IDList + ")");
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
	public static void FriendInvite(Player entity, List<UInt64> IDList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_221_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + IDList + ")");
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

	public static void FriendInvite(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_222_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + Name + ")");
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
	public static void FriendInvite(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_222_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + Name + ")");
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

	public static void FriendInvite(Player entity, List<ViString> NameList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_223_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + NameList + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FriendInvite(Player entity, List<ViString> NameList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_223_FriendInvite;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvite(" + entity  + ", " + NameList + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, NameList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FriendInvitedResponse(Player entity, UInt16 Idx, UInt8 OK)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_224_FriendInvitedResponse;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvitedResponse(" + entity  + ", " + Idx + ", " + OK + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, OK);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FriendInvitedResponse(Player entity, UInt16 Idx, UInt8 OK, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_224_FriendInvitedResponse;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvitedResponse(" + entity  + ", " + Idx + ", " + OK + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, OK);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FriendInvitedResponseAll(Player entity, UInt8 OK)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_225_FriendInvitedResponseAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvitedResponseAll(" + entity  + ", " + OK + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, OK);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void FriendInvitedResponseAll(Player entity, UInt8 OK, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_225_FriendInvitedResponseAll;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendInvitedResponseAll(" + entity  + ", " + OK + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, OK);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void FriendUpdateRecommand(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_226_FriendUpdateRecommand;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendUpdateRecommand(" + entity  + ")");
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
	public static void FriendUpdateRecommand(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_226_FriendUpdateRecommand;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendUpdateRecommand(" + entity  + ")");
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

	public static void FriendSearchName(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_227_FriendSearchName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendSearchName(" + entity  + ", " + Name + ")");
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
	public static void FriendSearchName(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_227_FriendSearchName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendSearchName(" + entity  + ", " + Name + ")");
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

	public static void FriendSearchNameAlias(Player entity, ViString Name)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_228_FriendSearchNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendSearchNameAlias(" + entity  + ", " + Name + ")");
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
	public static void FriendSearchNameAlias(Player entity, ViString Name, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_228_FriendSearchNameAlias;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> FriendSearchNameAlias(" + entity  + ", " + Name + ")");
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

	public static void WatchPlayerProperty(Player entity, UInt64 ID, ViRPCResultExecer<PlayerShotProperty> Result, ViRPCResultExecer<PlayerShotProperty>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_229_WatchPlayerProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> WatchPlayerProperty(" + entity  + ", " + ID + ", " + Result + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void WatchPlayerProperty(Player entity, UInt64 ID, ViRPCResultExecer<PlayerShotProperty> Result, ViRPCResultExecer<PlayerShotProperty>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_229_WatchPlayerProperty;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> WatchPlayerProperty(" + entity  + ", " + ID + ", " + Result + ")");
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ReadMail(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_230_ReadMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadMail(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ReadMail(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_230_ReadMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadMail(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ReadMails(Player entity, List<UInt16> IdxList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_231_ReadMails;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadMails(" + entity  + ", " + IdxList + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ReadMails(Player entity, List<UInt16> IdxList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_231_ReadMails;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadMails(" + entity  + ", " + IdxList + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ReadAllMail(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_232_ReadAllMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadAllMail(" + entity  + ")");
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
	public static void ReadAllMail(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_232_ReadAllMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadAllMail(" + entity  + ")");
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

	public static void DeleteMail(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_233_DeleteMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeleteMail(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DeleteMail(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_233_DeleteMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeleteMail(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DeleteMails(Player entity, List<UInt16> IdxList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_234_DeleteMails;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeleteMails(" + entity  + ", " + IdxList + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DeleteMails(Player entity, List<UInt16> IdxList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_234_DeleteMails;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeleteMails(" + entity  + ", " + IdxList + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DeleteAllMail(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_235_DeleteAllMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeleteAllMail(" + entity  + ")");
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
	public static void DeleteAllMail(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_235_DeleteAllMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeleteAllMail(" + entity  + ")");
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

	public static void ReceiveMail(Player entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_236_ReceiveMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReceiveMail(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ReceiveMail(Player entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_236_ReceiveMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReceiveMail(" + entity  + ", " + Idx + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ReceiveMails(Player entity, List<UInt16> IdxList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_237_ReceiveMails;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReceiveMails(" + entity  + ", " + IdxList + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ReceiveMails(Player entity, List<UInt16> IdxList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_237_ReceiveMails;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReceiveMails(" + entity  + ", " + IdxList + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, IdxList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ReceiveAllMail(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_238_ReceiveAllMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReceiveAllMail(" + entity  + ")");
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
	public static void ReceiveAllMail(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_238_ReceiveAllMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReceiveAllMail(" + entity  + ")");
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

	public static void SendMail(Player entity, ViString Target, ViString Title, ViString Content, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_239_SendMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMail(" + entity  + ", " + Target + ", " + Title + ", " + Content + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Target);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SendMail(Player entity, ViString Target, ViString Title, ViString Content, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_239_SendMail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SendMail(" + entity  + ", " + Target + ", " + Title + ", " + Content + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Target);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Title);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Content);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearUpMailbox(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_241_ClearUpMailbox;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearUpMailbox(" + entity  + ")");
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
	public static void ClearUpMailbox(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_241_ClearUpMailbox;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearUpMailbox(" + entity  + ")");
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

	public static void BuyYinPiao(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_243_BuyYinPiao;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyYinPiao(" + entity  + ")");
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
	public static void BuyYinPiao(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_243_BuyYinPiao;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyYinPiao(" + entity  + ")");
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

	public static void TransferJinZi(Player entity, UInt64 Receiver, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_246_TransferJinZi;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TransferJinZi(" + entity  + ", " + Receiver + ", " + DeltaValue + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TransferJinZi(Player entity, UInt64 Receiver, Int32 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_246_TransferJinZi;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TransferJinZi(" + entity  + ", " + Receiver + ", " + DeltaValue + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TransferJinZi(Player entity, ViString Receiver, Int32 DeltaValue)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_247_TransferJinZi;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TransferJinZi(" + entity  + ", " + Receiver + ", " + DeltaValue + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TransferJinZi(Player entity, ViString Receiver, Int32 DeltaValue, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_247_TransferJinZi;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TransferJinZi(" + entity  + ", " + Receiver + ", " + DeltaValue + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Receiver);
		ViGameSerializer<Int32>.Append(entity.RPC.OS, DeltaValue);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPaymentState(Player entity, ViString Name, UInt8 State)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_254_SetPaymentState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPaymentState(" + entity  + ", " + Name + ", " + State + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPaymentState(Player entity, ViString Name, UInt8 State, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_254_SetPaymentState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPaymentState(" + entity  + ", " + Name + ", " + State + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPaymentState(Player entity, UInt32 ID, UInt8 State)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_255_SetPaymentState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPaymentState(" + entity  + ", " + ID + ", " + State + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPaymentState(Player entity, UInt32 ID, UInt8 State, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_255_SetPaymentState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPaymentState(" + entity  + ", " + ID + ", " + State + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, State);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetPaymentState(Player entity, List<PaymentStateProperty> StateList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_256_SetPaymentState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPaymentState(" + entity  + ", " + StateList + ")");
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
		ViGameSerializer<PaymentStateProperty>.Append(entity.RPC.OS, StateList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetPaymentState(Player entity, List<PaymentStateProperty> StateList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_256_SetPaymentState;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetPaymentState(" + entity  + ", " + StateList + ")");
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
		ViGameSerializer<PaymentStateProperty>.Append(entity.RPC.OS, StateList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItem(Player entity, UInt32 Template)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_260_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItem(Player entity, UInt32 Template, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_260_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddItem(Player entity, UInt32 Template, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_261_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddItem(Player entity, UInt32 Template, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_261_AddItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddItem(" + entity  + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelItem(Player entity, UInt32 Template, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_267_DelItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelItem(" + entity  + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DelItem(Player entity, UInt32 Template, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_267_DelItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelItem(" + entity  + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DropItem(Player entity, UInt8 Bag, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_269_DropItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DropItem(" + entity  + ", " + Bag + ", " + Slot + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DropItem(Player entity, UInt8 Bag, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_269_DropItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DropItem(" + entity  + ", " + Bag + ", " + Slot + ")");
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Bag);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MoveBagItem(Player entity, UInt16 FromSlot, UInt16 ToSlot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_272_MoveBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveBagItem(" + entity  + ", " + FromSlot + ", " + ToSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, FromSlot);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ToSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void MoveBagItem(Player entity, UInt16 FromSlot, UInt16 ToSlot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_272_MoveBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveBagItem(" + entity  + ", " + FromSlot + ", " + ToSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, FromSlot);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, ToSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MoveBagItem(Player entity, List<ItemTransportProperty> List)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_273_MoveBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveBagItem(" + entity  + ", " + List + ")");
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
		ViGameSerializer<ItemTransportProperty>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void MoveBagItem(Player entity, List<ItemTransportProperty> List, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_273_MoveBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveBagItem(" + entity  + ", " + List + ")");
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
		ViGameSerializer<ItemTransportProperty>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SortBagItem(Player entity, List<UInt16> List)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_274_SortBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SortBagItem(" + entity  + ", " + List + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SortBagItem(Player entity, List<UInt16> List, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_274_SortBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SortBagItem(" + entity  + ", " + List + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DrawOutItem(Player entity, UInt16 Slot, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_275_DrawOutItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DrawOutItem(" + entity  + ", " + Slot + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DrawOutItem(Player entity, UInt16 Slot, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_275_DrawOutItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DrawOutItem(" + entity  + ", " + Slot + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UseBagItem(Player entity, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_276_UseBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UseBagItem(Player entity, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_276_UseBagItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UseBagItemTemplate(Player entity, UInt32 Template)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_277_UseBagItemTemplate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItemTemplate(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UseBagItemTemplate(Player entity, UInt32 Template, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_277_UseBagItemTemplate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItemTemplate(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UseBagItemTemplate(Player entity, UInt32 Template, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_278_UseBagItemTemplate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItemTemplate(" + entity  + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UseBagItemTemplate(Player entity, UInt32 Template, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_278_UseBagItemTemplate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItemTemplate(" + entity  + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UseBagItemTemplate(Player entity, UInt16 Slot, UInt32 Template, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_279_UseBagItemTemplate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItemTemplate(" + entity  + ", " + Slot + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UseBagItemTemplate(Player entity, UInt16 Slot, UInt32 Template, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_279_UseBagItemTemplate;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseBagItemTemplate(" + entity  + ", " + Slot + ", " + Template + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MoveItemFromPackageToBag(Player entity, UInt16 FromSlot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_281_MoveItemFromPackageToBag;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveItemFromPackageToBag(" + entity  + ", " + FromSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, FromSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void MoveItemFromPackageToBag(Player entity, UInt16 FromSlot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_281_MoveItemFromPackageToBag;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveItemFromPackageToBag(" + entity  + ", " + FromSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, FromSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void MoveItemFromPackageToBag(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_282_MoveItemFromPackageToBag;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveItemFromPackageToBag(" + entity  + ")");
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
	public static void MoveItemFromPackageToBag(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_282_MoveItemFromPackageToBag;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> MoveItemFromPackageToBag(" + entity  + ")");
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

	public static void SellItem(Player entity, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_284_SellItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SellItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SellItem(Player entity, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_284_SellItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SellItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SellItem(Player entity, UInt16 Slot, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_285_SellItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SellItem(" + entity  + ", " + Slot + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SellItem(Player entity, UInt16 Slot, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_285_SellItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SellItem(" + entity  + ", " + Slot + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BuyBackItem(Player entity, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_287_BuyBackItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyBackItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BuyBackItem(Player entity, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_287_BuyBackItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyBackItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SellPackageItem(Player entity, UInt16 Slot, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_288_SellPackageItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SellPackageItem(" + entity  + ", " + Slot + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SellPackageItem(Player entity, UInt16 Slot, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_288_SellPackageItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SellPackageItem(" + entity  + ", " + Slot + ", " + Count + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BuyBackPackageItem(Player entity, UInt16 Slot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_289_BuyBackPackageItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyBackPackageItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BuyBackPackageItem(Player entity, UInt16 Slot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_289_BuyBackPackageItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyBackPackageItem(" + entity  + ", " + Slot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Slot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ItemCompose(Player entity, UInt32 ComposeID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_298_ItemCompose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ItemCompose(" + entity  + ", " + ComposeID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ComposeID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ItemCompose(Player entity, UInt32 ComposeID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_298_ItemCompose;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ItemCompose(" + entity  + ", " + ComposeID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ComposeID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DeEquipItem(Player entity, UInt16 EquipSlot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_299_DeEquipItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeEquipItem(" + entity  + ", " + EquipSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, EquipSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DeEquipItem(Player entity, UInt16 EquipSlot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_299_DeEquipItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeEquipItem(" + entity  + ", " + EquipSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, EquipSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DeEquipItem(Player entity, UInt16 EquipSlot, UInt16 BagSlot)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_300_DeEquipItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeEquipItem(" + entity  + ", " + EquipSlot + ", " + BagSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, EquipSlot);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, BagSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void DeEquipItem(Player entity, UInt16 EquipSlot, UInt16 BagSlot, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_300_DeEquipItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DeEquipItem(" + entity  + ", " + EquipSlot + ", " + BagSlot + ")");
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
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, EquipSlot);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, BagSlot);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeItemWithLicence(Player entity, ViString Licence, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_301_TakeItemWithLicence;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeItemWithLicence(" + entity  + ", " + Licence + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Licence);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeItemWithLicence(Player entity, ViString Licence, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_301_TakeItemWithLicence;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeItemWithLicence(" + entity  + ", " + Licence + ", " + Result + ")");
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Licence);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateMarketItem(Player entity, ViString Tag)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_307_UpdateMarketItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateMarketItem(" + entity  + ", " + Tag + ")");
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
	public static void UpdateMarketItem(Player entity, ViString Tag, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_307_UpdateMarketItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateMarketItem(" + entity  + ", " + Tag + ")");
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

	public static void BuyMarketItem(Player entity, UInt32 ID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_308_BuyMarketItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyMarketItem(" + entity  + ", " + ID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BuyMarketItem(Player entity, UInt32 ID, Int16 Count, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_308_BuyMarketItem;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyMarketItem(" + entity  + ", " + ID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BuyMarketItemToOther(Player entity, UInt32 ID, Int16 Count, UInt64 ReceiverID, ViString ReceiverName)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_309_BuyMarketItemToOther;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyMarketItemToOther(" + entity  + ", " + ID + ", " + Count + ", " + ReceiverID + ", " + ReceiverName + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ReceiverID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ReceiverName);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BuyMarketItemToOther(Player entity, UInt32 ID, Int16 Count, UInt64 ReceiverID, ViString ReceiverName, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_309_BuyMarketItemToOther;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyMarketItemToOther(" + entity  + ", " + ID + ", " + Count + ", " + ReceiverID + ", " + ReceiverName + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, ReceiverID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ReceiverName);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddGoal(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_313_AddGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGoal(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void AddGoal(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_313_AddGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddGoal(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResponseGoal(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_320_ResponseGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResponseGoal(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResponseGoal(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_320_ResponseGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResponseGoal(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClickReward(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_321_ClickReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClickReward(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClickReward(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_321_ClickReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClickReward(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeGoalReward(Player entity, UInt32 Template)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_323_TakeGoalReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeGoalReward(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeGoalReward(Player entity, UInt32 Template, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_323_TakeGoalReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeGoalReward(" + entity  + ", " + Template + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Template);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeGoalAllReward(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_324_TakeGoalAllReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeGoalAllReward(" + entity  + ")");
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
	public static void TakeGoalAllReward(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_324_TakeGoalAllReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeGoalAllReward(" + entity  + ")");
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

	public static void EnterStoryModel(Player entity, UInt32 GoalID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_325_EnterStoryModel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterStoryModel(" + entity  + ", " + GoalID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterStoryModel(Player entity, UInt32 GoalID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_325_EnterStoryModel;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterStoryModel(" + entity  + ", " + GoalID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void GoalJumpSpace(Player entity, UInt32 GoalID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_326_GoalJumpSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GoalJumpSpace(" + entity  + ", " + GoalID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void GoalJumpSpace(Player entity, UInt32 GoalID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_326_GoalJumpSpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> GoalJumpSpace(" + entity  + ", " + GoalID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TurnInGoal(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_327_TurnInGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TurnInGoal(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TurnInGoal(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_327_TurnInGoal;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TurnInGoal(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void BuyPower(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_346_BuyPower;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyPower(" + entity  + ")");
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
	public static void BuyPower(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_346_BuyPower;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BuyPower(" + entity  + ")");
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

	public static void TakeHero(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_360_TakeHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeHero(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeHero(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_360_TakeHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeHero(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SetSpaceWorkingHero(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_361_SetSpaceWorkingHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetSpaceWorkingHero(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void SetSpaceWorkingHero(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_361_SetSpaceWorkingHero;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SetSpaceWorkingHero(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UseHeroXPStone(Player entity, UInt32 Hero, UInt32 Item, Int16 INT16)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_366_UseHeroXPStone;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseHeroXPStone(" + entity  + ", " + Hero + ", " + Item + ", " + INT16 + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, INT16);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UseHeroXPStone(Player entity, UInt32 Hero, UInt32 Item, Int16 INT16, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_366_UseHeroXPStone;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UseHeroXPStone(" + entity  + ", " + Hero + ", " + Item + ", " + INT16 + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Hero);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Item);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, INT16);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void EnterSpaceObjLoadNPC(Player entity, UInt32 GoalID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_380_EnterSpaceObjLoadNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterSpaceObjLoadNPC(" + entity  + ", " + GoalID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void EnterSpaceObjLoadNPC(Player entity, UInt32 GoalID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_380_EnterSpaceObjLoadNPC;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> EnterSpaceObjLoadNPC(" + entity  + ", " + GoalID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, GoalID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CompleteHint(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_381_CompleteHint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteHint(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CompleteHint(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_381_CompleteHint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteHint(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClearHint(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_382_ClearHint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHint(" + entity  + ")");
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
	public static void ClearHint(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_382_ClearHint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHint(" + entity  + ")");
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

	public static void ClearHint(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_383_ClearHint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHint(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ClearHint(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_383_ClearHint;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClearHint(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TakeDayGift(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_384_TakeDayGift;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeDayGift(" + entity  + ")");
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
	public static void TakeDayGift(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_384_TakeDayGift;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeDayGift(" + entity  + ")");
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

	public static void TakeAccumulateLoginReward(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_385_TakeAccumulateLoginReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeAccumulateLoginReward(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeAccumulateLoginReward(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_385_TakeAccumulateLoginReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeAccumulateLoginReward(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetAccumulateLoginReward(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_386_ResetAccumulateLoginReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetAccumulateLoginReward(" + entity  + ")");
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
	public static void ResetAccumulateLoginReward(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_386_ResetAccumulateLoginReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetAccumulateLoginReward(" + entity  + ")");
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

	public static void TakeAccumulateLoginInActivityReward(Player entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_387_TakeAccumulateLoginInActivityReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeAccumulateLoginInActivityReward(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TakeAccumulateLoginInActivityReward(Player entity, UInt32 ID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_387_TakeAccumulateLoginInActivityReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TakeAccumulateLoginInActivityReward(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetAccumulateLoginInActivityReward(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_388_ResetAccumulateLoginInActivityReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetAccumulateLoginInActivityReward(" + entity  + ")");
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
	public static void ResetAccumulateLoginInActivityReward(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_388_ResetAccumulateLoginInActivityReward;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetAccumulateLoginInActivityReward(" + entity  + ")");
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

	public static void ResetClientSetting(Player entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_389_ResetClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetClientSetting(" + entity  + ")");
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
	public static void ResetClientSetting(Player entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_389_ResetClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetClientSetting(" + entity  + ")");
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

	public static void UpdateClientSetting(Player entity, ClientSettingForPlayerProperty PlayerProperty)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_390_UpdateClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateClientSetting(" + entity  + ", " + PlayerProperty + ")");
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
		ViGameSerializer<ClientSettingForPlayerProperty>.Append(entity.RPC.OS, PlayerProperty);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateClientSetting(Player entity, ClientSettingForPlayerProperty PlayerProperty, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)PlayerServerMethod.METHOD_390_UpdateClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateClientSetting(" + entity  + ", " + PlayerProperty + ")");
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
		ViGameSerializer<ClientSettingForPlayerProperty>.Append(entity.RPC.OS, PlayerProperty);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

}
