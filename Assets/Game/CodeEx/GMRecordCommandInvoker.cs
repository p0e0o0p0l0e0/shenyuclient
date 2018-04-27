using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GMRecordCommandInvoker : ViEntityCommandInvoker<GMRecord>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".OnSQLResult", Server_0_OnSQLResult);
		AddFunc(".OnUpdatePlayerBaseInfo", Server_1_OnUpdatePlayerBaseInfo);
		AddFunc(".OnUpdatePlayerBaseInfo", Server_2_OnUpdatePlayerBaseInfo);
		AddFunc(".OnUpdatePlayerDetail", Server_3_OnUpdatePlayerDetail);
		AddFunc(".OnUpdateServer", Server_4_OnUpdateServer);
		AddFunc("/Test", Client_0_Test);
	}
	public static new bool Exec(GMRecord entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<GMRecord>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		GMRecord deriveEntity = entity as GMRecord;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void OnSQLResult(GMRecord entity, UInt64 Callback, ViString Tag, List<ViString> FieldList, List<ViString> ValueList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_0_OnSQLResult;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnSQLResult(" + entity  + ", " + Callback + ", " + Tag + ", " + FieldList + ", " + ValueList + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Callback);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, FieldList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ValueList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnUpdatePlayerBaseInfo(GMRecord entity, UInt64 CallbackID, AccountWithPlayerProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_1_OnUpdatePlayerBaseInfo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnUpdatePlayerBaseInfo(" + entity  + ", " + CallbackID + ", " + Property + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<AccountWithPlayerProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnUpdatePlayerBaseInfo(GMRecord entity, UInt64 CallbackID, PlayerWithAccountProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_2_OnUpdatePlayerBaseInfo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnUpdatePlayerBaseInfo(" + entity  + ", " + CallbackID + ", " + Property + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<PlayerWithAccountProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnUpdatePlayerDetail(GMRecord entity, UInt64 CallbackID, PlayerGMViewProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_3_OnUpdatePlayerDetail;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnUpdatePlayerDetail(" + entity  + ", " + CallbackID + ", " + Property + ")");
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<PlayerGMViewProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void OnUpdateServer(GMRecord entity, ServerViewProperty Property)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_4_OnUpdateServer;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> OnUpdateServer(" + entity  + ", " + Property + ")");
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
		ViGameSerializer<ServerViewProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_OnSQLResult(GMRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 Callback = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out Callback) == false) { return false; }
		ViString Tag = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Tag) == false) { return false; }
		List<ViString> FieldList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out FieldList) == false) { return false; }
		List<ViString> ValueList = default(List<ViString>); if (ViGameSerializer<ViString>.Read(IS, out ValueList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnSQLResult(" + entity  + ", " + Callback + ", " + Tag + ", " + FieldList + ", " + ValueList + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_0_OnSQLResult;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, Callback);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, Tag);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, FieldList);
		ViGameSerializer<ViString>.Append(entity.RPC.OS, ValueList);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_OnUpdatePlayerBaseInfo(GMRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		AccountWithPlayerProperty Property = default(AccountWithPlayerProperty); if (ViGameSerializer<AccountWithPlayerProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnUpdatePlayerBaseInfo(" + entity  + ", " + CallbackID + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_1_OnUpdatePlayerBaseInfo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<AccountWithPlayerProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_OnUpdatePlayerBaseInfo(GMRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		PlayerWithAccountProperty Property = default(PlayerWithAccountProperty); if (ViGameSerializer<PlayerWithAccountProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnUpdatePlayerBaseInfo(" + entity  + ", " + CallbackID + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_2_OnUpdatePlayerBaseInfo;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<PlayerWithAccountProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_OnUpdatePlayerDetail(GMRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt64 CallbackID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out CallbackID) == false) { return false; }
		PlayerGMViewProperty Property = default(PlayerGMViewProperty); if (ViGameSerializer<PlayerGMViewProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnUpdatePlayerDetail(" + entity  + ", " + CallbackID + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_3_OnUpdatePlayerDetail;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, CallbackID);
		ViGameSerializer<PlayerGMViewProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_OnUpdateServer(GMRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ServerViewProperty Property = default(ServerViewProperty); if (ViGameSerializer<ServerViewProperty>.Read(IS, out Property) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> OnUpdateServer(" + entity  + ", " + Property + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.GM;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GMRecordServerMethod.METHOD_4_OnUpdateServer;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<ServerViewProperty>.Append(entity.RPC.OS, Property);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_Test(GMRecord entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Name = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Name) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.Test(Name, Content);
		return true;
	}
}
