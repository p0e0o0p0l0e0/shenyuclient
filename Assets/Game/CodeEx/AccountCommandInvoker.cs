using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AccountCommandInvoker : ViEntityCommandInvoker<Account>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".Exec", Server_0_Exec);
		AddFunc(".Exec", Server_1_Exec);
		AddFunc(".RandomName", Server_2_RandomName);
		AddFunc(".CreateRole", Server_3_CreateRole);
		AddFunc(".SelectRole", Server_4_SelectRole);
		AddFunc(".DestroyRole", Server_5_DestroyRole);
		AddFunc(".RevertRole", Server_6_RevertRole);
		AddFunc(".BackToLogin", Server_7_BackToLogin);
		AddFunc(".OnDebugWarningTrace", Server_8_OnDebugWarningTrace);
		AddFunc(".OnDebugErrorTrace", Server_9_OnDebugErrorTrace);
		AddFunc(".UpdateDevice", Server_10_UpdateDevice);
		AddFunc(".UpdateKeyboardSetting", Server_11_UpdateKeyboardSetting);
		AddFunc(".UpdateKeyboardSetting", Server_12_UpdateKeyboardSetting);
		AddFunc(".ResetKeyboardSetting", Server_13_ResetKeyboardSetting);
		AddFunc(".ReadGameNote", Server_14_ReadGameNote);
		AddFunc(".ResetClientSetting", Server_15_ResetClientSetting);
		AddFunc(".UpdateClientSetting", Server_16_UpdateClientSetting);
		AddFunc(".TestCallback", Server_17_TestCallback);
		AddFunc(".LogoutPlayer", Server_18_LogoutPlayer);
		AddFunc("/OnCreateStart", Client_0_OnCreateStart);
		AddFunc("/OnSelectStart", Client_1_OnSelectStart);
		AddFunc("/OnRoleName", Client_2_OnRoleName);
		AddFunc("/OnCreateResult", Client_3_OnCreateResult);
		AddFunc("/OnIndulgeWarning", Client_4_OnIndulgeWarning);
		AddFunc("/OnPreventIndulgeResult", Client_5_OnPreventIndulgeResult);
		AddFunc("/ResponseTime", Client_6_ResponseTime);
		AddFunc("/UpdateLoginContent", Client_7_UpdateLoginContent);
		AddFunc("/OnUpdateVisualLoading", Client_8_OnUpdateVisualLoading);
		AddFunc("/MessageBox", Client_9_MessageBox);
		AddFunc("/DebugMessage", Client_10_DebugMessage);
		AddFunc("/ContainReserveWord", Client_11_ContainReserveWord);
		AddFunc("/HTTPRequest", Client_12_HTTPRequest);
		AddFunc("/OnLogoutPlayer", Client_13_OnLogoutPlayer);
	}
	public static new bool Exec(Account entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<Account>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		Account deriveEntity = entity as Account;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void Exec(Account entity, ViString Script)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_0_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ")");
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
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void Exec(Account entity, ViString Script, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_0_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ")");
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
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void Exec(Account entity, ViString Script, ViString ParamList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_1_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ", " + ParamList + ")");
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
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ParamList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void Exec(Account entity, ViString Script, ViString ParamList, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_1_Exec;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> Exec(" + entity  + ", " + Script + ", " + ParamList + ")");
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
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ParamList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_Exec(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Exec(" + entity  + ", " + Script + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_0_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_Exec(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		ViString ParamList = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out ParamList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> Exec(" + entity  + ", " + Script + ", " + ParamList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_1_Exec;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Script);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ParamList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_RandomName(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Gender = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Gender) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RandomName(" + entity  + ", " + Gender + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_2_RandomName;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt8>.Append(entity.RPC.OS, Gender);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_CreateRole(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		CreateRoleProperty Property = default(CreateRoleProperty); if (ViGameSerializer<CreateRoleProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreateRole(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_3_CreateRole;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<CreateRoleProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_SelectRole(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SelectRole(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_4_SelectRole;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_DestroyRole(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DestroyRole(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_5_DestroyRole;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_RevertRole(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt16 Idx = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Idx) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> RevertRole(" + entity  + ", " + Idx + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_6_RevertRole;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Idx);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_BackToLogin(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> BackToLogin(" + entity  + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_7_BackToLogin;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_OnDebugWarningTrace(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Log = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Log) == false) { return false; }
		ViString Stack = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Stack) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnDebugWarningTrace(" + entity  + ", " + Log + ", " + Stack + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_8_OnDebugWarningTrace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Log);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Stack);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_OnDebugErrorTrace(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Log = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Log) == false) { return false; }
		ViString Stack = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Stack) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnDebugErrorTrace(" + entity  + ", " + Log + ", " + Stack + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_9_OnDebugErrorTrace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Log);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Stack);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_UpdateDevice(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ClientDeviceProperty Property = default(ClientDeviceProperty); if (ViGameSerializer<ClientDeviceProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateDevice(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_10_UpdateDevice;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ClientDeviceProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_11_UpdateKeyboardSetting(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Key = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Key) == false) { return false; }
		UInt16 Value0 = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Value0) == false) { return false; }
		UInt16 Value1 = default(UInt16); if (ViGameSerializer<UInt16>.Read(IS, out Value1) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateKeyboardSetting(" + entity  + ", " + Key + ", " + Value0 + ", " + Value1 + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_11_UpdateKeyboardSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Key);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Value0);
		ViGameSerializer<UInt16>.Append(entity.RPC.OS, Value1);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_12_UpdateKeyboardSetting(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<KeyboardSlotProperty> List = default(List<KeyboardSlotProperty>); if (ViGameSerializer<KeyboardSlotProperty>.Read(IS, out List) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateKeyboardSetting(" + entity  + ", " + List + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_12_UpdateKeyboardSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<KeyboardSlotProperty>.Append(entity.RPC.OS, List);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_13_ResetKeyboardSetting(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetKeyboardSetting(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_13_ResetKeyboardSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_14_ReadGameNote(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ReadGameNote(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_14_ReadGameNote;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_15_ResetClientSetting(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ClientDeviceProperty Property = default(ClientDeviceProperty); if (ViGameSerializer<ClientDeviceProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ResetClientSetting(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_15_ResetClientSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ClientDeviceProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_16_UpdateClientSetting(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ClientSettingForAccountProperty AccountProperty = default(ClientSettingForAccountProperty); if (ViGameSerializer<ClientSettingForAccountProperty>.Read(IS, out AccountProperty) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> UpdateClientSetting(" + entity  + ", " + AccountProperty + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_16_UpdateClientSetting;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ClientSettingForAccountProperty>.Append(entity.RPC.OS, AccountProperty);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_17_TestCallback(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Param = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Param) == false) { return false; }
		ViRPCCallback<UInt8> Result = default(ViRPCCallback<UInt8>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> TestCallback(" + entity  + ", " + Param + ", " + Result + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_17_TestCallback;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, Param);
		ViRPCCallbackSerializer.Append(entity.RPC.OS, Result);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_18_LogoutPlayer(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> LogoutPlayer(" + entity  + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)AccountServerMethod.METHOD_18_LogoutPlayer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnCreateStart(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Gender = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Gender) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCreateStart(Gender);
		return true;
	}
	static bool Client_1_OnSelectStart(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnSelectStart();
		return true;
	}
	static bool Client_2_OnRoleName(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnRoleName(Name);
		return true;
	}
	static bool Client_3_OnCreateResult(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Result = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnCreateResult(Result);
		return true;
	}
	static bool Client_4_OnIndulgeWarning(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		Int32 ReserveTime = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out ReserveTime) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnIndulgeWarning(ReserveTime);
		return true;
	}
	static bool Client_5_OnPreventIndulgeResult(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt8 Error = default(UInt8); if (ViGameSerializer<UInt8>.Read(IS, out Error) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnPreventIndulgeResult(Error);
		return true;
	}
	static bool Client_6_ResponseTime(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViRPCCallback<Int64> Result = default(ViRPCCallback<Int64>); if (ViRPCCallbackSerializer.Read(IS, out Result) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ResponseTime(Result);
		return true;
	}
	static bool Client_7_UpdateLoginContent(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.UpdateLoginContent(Content);
		return true;
	}
	static bool Client_8_OnUpdateVisualLoading(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 VisualLoading = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out VisualLoading) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateVisualLoading(VisualLoading);
		return true;
	}
	static bool Client_9_MessageBox(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.MessageBox(Title, Content);
		return true;
	}
	static bool Client_10_DebugMessage(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.DebugMessage(Title, Content);
		return true;
	}
	static bool Client_11_ContainReserveWord(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString OrgValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out OrgValue) == false) { return false; }
		ViString FmtValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out FmtValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ContainReserveWord(OrgValue, FmtValue);
		return true;
	}
	static bool Client_12_HTTPRequest(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Value = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Value) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.HTTPRequest(Value);
		return true;
	}
	static bool Client_13_OnLogoutPlayer(Account entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnLogoutPlayer();
		return true;
	}
}
