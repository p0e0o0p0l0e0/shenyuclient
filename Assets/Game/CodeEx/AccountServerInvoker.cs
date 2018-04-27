using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AccountServerInvoker
{
	public static void RandomName(Account entity, UInt8 Gender)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_2_RandomName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RandomName(" + entity  + ", " + Gender + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Gender);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void RandomName(Account entity, UInt8 Gender, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_2_RandomName;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RandomName(" + entity  + ", " + Gender + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Gender);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CreateRole(Account entity, CreateRoleProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_3_CreateRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateRole(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<CreateRoleProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CreateRole(Account entity, CreateRoleProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_3_CreateRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreateRole(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<CreateRoleProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SelectRole(Account entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_4_SelectRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SelectRole(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void SelectRole(Account entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_4_SelectRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SelectRole(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void DestroyRole(Account entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_5_DestroyRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DestroyRole(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void DestroyRole(Account entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_5_DestroyRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DestroyRole(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void RevertRole(Account entity, UInt16 Idx)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_6_RevertRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RevertRole(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void RevertRole(Account entity, UInt16 Idx, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_6_RevertRole;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> RevertRole(" + entity  + ", " + Idx + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void BackToLogin(Account entity, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_7_BackToLogin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BackToLogin(" + entity  + ", " + Result + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void BackToLogin(Account entity, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_7_BackToLogin;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> BackToLogin(" + entity  + ", " + Result + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnDebugWarningTrace(Account entity, ViString Log, ViString Stack)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_8_OnDebugWarningTrace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnDebugWarningTrace(" + entity  + ", " + Log + ", " + Stack + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Log);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Stack);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnDebugWarningTrace(Account entity, ViString Log, ViString Stack, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_8_OnDebugWarningTrace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnDebugWarningTrace(" + entity  + ", " + Log + ", " + Stack + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Log);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Stack);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnDebugErrorTrace(Account entity, ViString Log, ViString Stack)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_9_OnDebugErrorTrace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnDebugErrorTrace(" + entity  + ", " + Log + ", " + Stack + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Log);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Stack);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void OnDebugErrorTrace(Account entity, ViString Log, ViString Stack, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_9_OnDebugErrorTrace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnDebugErrorTrace(" + entity  + ", " + Log + ", " + Stack + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Log);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Stack);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateDevice(Account entity, ClientDeviceProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_10_UpdateDevice;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateDevice(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ClientDeviceProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateDevice(Account entity, ClientDeviceProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_10_UpdateDevice;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateDevice(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ClientDeviceProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateKeyboardSetting(Account entity, UInt32 Key, UInt16 Value0, UInt16 Value1)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_11_UpdateKeyboardSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateKeyboardSetting(" + entity  + ", " + Key + ", " + Value0 + ", " + Value1 + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Key);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Value0);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Value1);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateKeyboardSetting(Account entity, UInt32 Key, UInt16 Value0, UInt16 Value1, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_11_UpdateKeyboardSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateKeyboardSetting(" + entity  + ", " + Key + ", " + Value0 + ", " + Value1 + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Key);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Value0);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Value1);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateKeyboardSetting(Account entity, List<KeyboardSlotProperty> List)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_12_UpdateKeyboardSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateKeyboardSetting(" + entity  + ", " + List + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<KeyboardSlotProperty>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateKeyboardSetting(Account entity, List<KeyboardSlotProperty> List, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_12_UpdateKeyboardSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateKeyboardSetting(" + entity  + ", " + List + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<KeyboardSlotProperty>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ResetKeyboardSetting(Account entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_13_ResetKeyboardSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetKeyboardSetting(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void ResetKeyboardSetting(Account entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_13_ResetKeyboardSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetKeyboardSetting(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void ReadGameNote(Account entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_14_ReadGameNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadGameNote(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void ReadGameNote(Account entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_14_ReadGameNote;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ReadGameNote(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void ResetClientSetting(Account entity, ClientDeviceProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_15_ResetClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetClientSetting(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ClientDeviceProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void ResetClientSetting(Account entity, ClientDeviceProperty Property, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_15_ResetClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ResetClientSetting(" + entity  + ", " + Property + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ClientDeviceProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void UpdateClientSetting(Account entity, ClientSettingForAccountProperty AccountProperty)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_16_UpdateClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateClientSetting(" + entity  + ", " + AccountProperty + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ClientSettingForAccountProperty>.Append(entity.RPC.OS, AccountProperty);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateClientSetting(Account entity, ClientSettingForAccountProperty AccountProperty, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_16_UpdateClientSetting;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateClientSetting(" + entity  + ", " + AccountProperty + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<ClientSettingForAccountProperty>.Append(entity.RPC.OS, AccountProperty);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void TestCallback(Account entity, UInt32 Param, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_17_TestCallback;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TestCallback(" + entity  + ", " + Param + ", " + Result + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Param);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void TestCallback(Account entity, UInt32 Param, ViRPCResultExecer<UInt8> Result, ViRPCResultExecer<UInt8>.DeleOnResult ResultRPCCallback, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_17_TestCallback;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> TestCallback(" + entity  + ", " + Param + ", " + Result + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Param);
		entity.RPC.OS.Append(entity.RPC.ResultDistributor.Hook(Result, ResultRPCCallback));
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void LogoutPlayer(Account entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_18_LogoutPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LogoutPlayer(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void LogoutPlayer(Account entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_18_LogoutPlayer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> LogoutPlayer(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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

}
