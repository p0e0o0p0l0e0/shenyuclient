using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GuildCommandInvoker : ViEntityCommandInvoker<Guild>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".CreatePVESpace", Server_0_CreatePVESpace);
		AddFunc(".ClosePVESpace", Server_1_ClosePVESpace);
		AddFunc("/OnSmallSpaceConvoke", Client_0_OnSmallSpaceConvoke);
		AddFunc("/OnActivityConvoke", Client_1_OnActivityConvoke);
	}
	public static new bool Exec(Guild entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<Guild>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		Guild deriveEntity = entity as Guild;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void CreatePVESpace(Guild entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GuildServerMethod.METHOD_0_CreatePVESpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CreatePVESpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void ClosePVESpace(Guild entity, UInt32 ID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)GuildServerMethod.METHOD_1_ClosePVESpace;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> ClosePVESpace(" + entity  + ", " + ID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_CreatePVESpace(Guild entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> CreatePVESpace(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GuildServerMethod.METHOD_0_CreatePVESpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_ClosePVESpace(Guild entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 ID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> ClosePVESpace(" + entity  + ", " + ID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)GuildServerMethod.METHOD_1_ClosePVESpace;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, ID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Client_0_OnSmallSpaceConvoke(Guild entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Space = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Space) == false) { return false; }
		PlayerIdentificationProperty Sayer = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Sayer) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnSmallSpaceConvoke(Space, Sayer);
		return true;
	}
	static bool Client_1_OnActivityConvoke(Guild entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Activity = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Activity) == false) { return false; }
		PlayerIdentificationProperty Sayer = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Sayer) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnActivityConvoke(Activity, Sayer);
		return true;
	}
}
