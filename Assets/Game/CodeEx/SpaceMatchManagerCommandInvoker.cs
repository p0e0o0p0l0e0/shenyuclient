using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceMatchManagerCommandInvoker : ViEntityCommandInvoker<SpaceMatchManager>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc(".SelectPVPMatch", Server_0_SelectPVPMatch);
		AddFunc(".SelectPVPMatch", Server_1_SelectPVPMatch);
		AddFunc(".AddPVPMatcher", Server_2_AddPVPMatcher);
		AddFunc(".AddPVPMatcher", Server_3_AddPVPMatcher);
		AddFunc(".DelPVPMatcher", Server_4_DelPVPMatcher);
		AddFunc(".SelectPVAMatch", Server_5_SelectPVAMatch);
		AddFunc(".AddPVAMatcher", Server_6_AddPVAMatcher);
		AddFunc(".DelPVAMatcher", Server_7_DelPVAMatcher);
		AddFunc(".SelectPVEMatch", Server_8_SelectPVEMatch);
		AddFunc(".AddPVEMatcher", Server_9_AddPVEMatcher);
		AddFunc(".DelPVEMatcher", Server_10_DelPVEMatcher);
	}
	public static new bool Exec(SpaceMatchManager entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<SpaceMatchManager>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		SpaceMatchManager deriveEntity = entity as SpaceMatchManager;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	public static void SelectPVPMatch(SpaceMatchManager entity, UInt32 SpaceID, Int16 FactionMemberCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_0_SelectPVPMatch;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SelectPVPMatch(" + entity  + ", " + SpaceID + ", " + FactionMemberCount + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SelectPVPMatch(SpaceMatchManager entity, UInt32 SpaceID, Int8 FactionCount, Int16 FactionMemberCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_1_SelectPVPMatch;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SelectPVPMatch(" + entity  + ", " + SpaceID + ", " + FactionCount + ", " + FactionMemberCount + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int8>.Append(entity.RPC.OS, FactionCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPVPMatcher(SpaceMatchManager entity, UInt32 SpaceID, Int16 FactionMemberCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_2_AddPVPMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPVPMatcher(" + entity  + ", " + SpaceID + ", " + FactionMemberCount + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPVPMatcher(SpaceMatchManager entity, UInt32 SpaceID, Int8 FactionCount, Int16 FactionMemberCount)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_3_AddPVPMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPVPMatcher(" + entity  + ", " + SpaceID + ", " + FactionCount + ", " + FactionMemberCount + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int8>.Append(entity.RPC.OS, FactionCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPVPMatcher(SpaceMatchManager entity, UInt32 SpaceID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_4_DelPVPMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPVPMatcher(" + entity  + ", " + SpaceID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SelectPVAMatch(SpaceMatchManager entity, UInt32 SpaceID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_5_SelectPVAMatch;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SelectPVAMatch(" + entity  + ", " + SpaceID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPVAMatcher(SpaceMatchManager entity, UInt32 SpaceID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_6_AddPVAMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPVAMatcher(" + entity  + ", " + SpaceID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPVAMatcher(SpaceMatchManager entity, UInt32 SpaceID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_7_DelPVAMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPVAMatcher(" + entity  + ", " + SpaceID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void SelectPVEMatch(SpaceMatchManager entity, UInt32 SpaceID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_8_SelectPVEMatch;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> SelectPVEMatch(" + entity  + ", " + SpaceID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void AddPVEMatcher(SpaceMatchManager entity, UInt32 SpaceID, Int16 Count)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_9_AddPVEMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> AddPVEMatcher(" + entity  + ", " + SpaceID + ", " + Count + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void DelPVEMatcher(SpaceMatchManager entity, UInt32 SpaceID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_10_DelPVEMatcher;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> DelPVEMatcher(" + entity  + ", " + SpaceID + ")");
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	static bool Server_0_SelectPVPMatch(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int16 FactionMemberCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out FactionMemberCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SelectPVPMatch(" + entity  + ", " + SpaceID + ", " + FactionMemberCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_0_SelectPVPMatch;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_1_SelectPVPMatch(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int8 FactionCount = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FactionCount) == false) { return false; }
		Int16 FactionMemberCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out FactionMemberCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SelectPVPMatch(" + entity  + ", " + SpaceID + ", " + FactionCount + ", " + FactionMemberCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_1_SelectPVPMatch;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int8>.Append(entity.RPC.OS, FactionCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_2_AddPVPMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int16 FactionMemberCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out FactionMemberCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPVPMatcher(" + entity  + ", " + SpaceID + ", " + FactionMemberCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_2_AddPVPMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_3_AddPVPMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int8 FactionCount = default(Int8); if (ViGameSerializer<Int8>.Read(IS, out FactionCount) == false) { return false; }
		Int16 FactionMemberCount = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out FactionMemberCount) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPVPMatcher(" + entity  + ", " + SpaceID + ", " + FactionCount + ", " + FactionMemberCount + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_3_AddPVPMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int8>.Append(entity.RPC.OS, FactionCount);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, FactionMemberCount);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_4_DelPVPMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPVPMatcher(" + entity  + ", " + SpaceID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_4_DelPVPMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_5_SelectPVAMatch(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SelectPVAMatch(" + entity  + ", " + SpaceID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_5_SelectPVAMatch;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_6_AddPVAMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPVAMatcher(" + entity  + ", " + SpaceID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_6_AddPVAMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_7_DelPVAMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPVAMatcher(" + entity  + ", " + SpaceID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_7_DelPVAMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_8_SelectPVEMatch(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> SelectPVEMatch(" + entity  + ", " + SpaceID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_8_SelectPVEMatch;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_9_AddPVEMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		Int16 Count = default(Int16); if (ViGameSerializer<Int16>.Read(IS, out Count) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> AddPVEMatcher(" + entity  + ", " + SpaceID + ", " + Count + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_9_AddPVEMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		ViGameSerializer<Int16>.Append(entity.RPC.OS, Count);
		entity.RPC.SendMessage();
		return true;
	}
	static bool Server_10_DelPVEMatcher(SpaceMatchManager entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 SpaceID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out SpaceID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("GM >> DelPVEMatcher(" + entity  + ", " + SpaceID + ")");
		}
		//
		UInt8 receiverSide = (UInt8)ViRPCSide.CENTER;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append(receiverSide);
		entity.RPC.OS.Append((UInt16)ViRPCMessage.ENTITY_GM);
		UInt16 funcID = (UInt16)SpaceMatchManagerServerMethod.METHOD_10_DelPVEMatcher;
		entity.RPC.OS.Append(funcID);
		entity.RPC.OS.Append(entity.ID);
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, SpaceID);
		entity.RPC.SendMessage();
		return true;
	}
}
