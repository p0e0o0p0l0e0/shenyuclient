using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CellPlayerServerInvoker
{
	public static void UpdateSpaceLoadProgress(CellPlayer entity, UInt64 SpaceRecordID, float Progress)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_24_UpdateSpaceLoadProgress;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateSpaceLoadProgress(" + entity  + ", " + SpaceRecordID + ", " + Progress + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, SpaceRecordID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Progress);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void UpdateSpaceLoadProgress(CellPlayer entity, UInt64 SpaceRecordID, float Progress, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_24_UpdateSpaceLoadProgress;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> UpdateSpaceLoadProgress(" + entity  + ", " + SpaceRecordID + ", " + Progress + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, SpaceRecordID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Progress);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CompleteSpaceLoad(CellPlayer entity, UInt64 SpaceRecordID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_25_CompleteSpaceLoad;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteSpaceLoad(" + entity  + ", " + SpaceRecordID + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, SpaceRecordID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void CompleteSpaceLoad(CellPlayer entity, UInt64 SpaceRecordID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_25_CompleteSpaceLoad;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteSpaceLoad(" + entity  + ", " + SpaceRecordID + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt64>.Append(entity.RPC.OS, SpaceRecordID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_SpaceScriptEvent(CellPlayer entity, ViString Script, Int32 Number)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_27_REQ_SpaceScriptEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_SpaceScriptEvent(" + entity  + ", " + Script + ", " + Number + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Number);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_SpaceScriptEvent(CellPlayer entity, ViString Script, Int32 Number, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_27_REQ_SpaceScriptEvent;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_SpaceScriptEvent(" + entity  + ", " + Script + ", " + Number + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<Int32>.Append(entity.RPC.OS, Number);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void CompleteHeroLoad(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_38_CompleteHeroLoad;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteHeroLoad(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void CompleteHeroLoad(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_38_CompleteHeroLoad;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> CompleteHeroLoad(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void REQ_AddMoveSpeedScale(CellPlayer entity, float Value)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_39_REQ_AddMoveSpeedScale;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_AddMoveSpeedScale(" + entity  + ", " + Value + ")");
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
		ViGameSerializer<float>.Append(entity.RPC.OS, Value);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_DelMoveSpeedScale(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_40_REQ_DelMoveSpeedScale;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DelMoveSpeedScale(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_MoveTo(CellPlayer entity, ViVector3 Pos)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_41_REQ_MoveTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_MoveTo(" + entity  + ", " + Pos + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, Pos);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_MoveTo(CellPlayer entity, List<ViVector3> PosList)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_42_REQ_MoveTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_MoveTo(" + entity  + ", " + PosList + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, PosList);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_BreakMoveTo(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_43_REQ_BreakMoveTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_BreakMoveTo(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_ShotStart(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_46_REQ_ShotStart;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_ShotStart(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_ShotEnd(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_47_REQ_ShotEnd;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_ShotEnd(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_RecoverShot(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_48_REQ_RecoverShot;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_RecoverShot(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_AddShotYaw(CellPlayer entity, float Yaw)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_49_REQ_AddShotYaw;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_AddShotYaw(" + entity  + ", " + Yaw + ")");
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
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_DelShotYaw(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_50_REQ_DelShotYaw;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DelShotYaw(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_51_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_51_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, float Yaw)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_52_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Yaw + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, float Yaw, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_52_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Yaw + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, float Yaw, float Distance)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_53_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Yaw + ", " + Distance + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		ViGameSerializer<float>.Append(entity.RPC.OS, Distance);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, float Yaw, float Distance, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_53_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Yaw + ", " + Distance + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		ViGameSerializer<float>.Append(entity.RPC.OS, Distance);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, GameUnit Target)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_54_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Target + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}
	public static void REQ_DoSpellByID(CellPlayer entity, UInt32 skillConfigID, GameUnit Target, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_54_REQ_DoSpellByID;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoSpellByID(" + entity  + ", " + skillConfigID + ", " + Target + ")");
		}
		if (entity == null)
		{
			return;
		}
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
		ViGameSerializer<UInt32>.Append(entity.RPC.OS, skillConfigID);
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_CancelSpell(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_55_REQ_CancelSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_CancelSpell(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void REQ_CancelSpell(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_55_REQ_CancelSpell;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_CancelSpell(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void REQ_DoDash(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_56_REQ_DoDash;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoDash(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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
	public static void REQ_DoDash(CellPlayer entity, ViEntityACK.DeleACKCallback callback)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_56_REQ_DoDash;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_DoDash(" + entity  + ")");
		}
		if (entity == null)
		{
			return;
		}
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

	public static void REQ_StartFocus(CellPlayer entity, GameUnit Target)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_57_REQ_StartFocus;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_StartFocus(" + entity  + ", " + Target + ")");
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
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, Target);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_EndFocus(CellPlayer entity)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_58_REQ_EndFocus;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_EndFocus(" + entity  + ")");
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
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_SetHeroYaw(CellPlayer entity, float Yaw)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_59_REQ_SetHeroYaw;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_SetHeroYaw(" + entity  + ", " + Yaw + ")");
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
		ViGameSerializer<float>.Append(entity.RPC.OS, Yaw);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_NavigateTo(CellPlayer entity, GameUnit TargetUnit)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_60_REQ_NavigateTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_NavigateTo(" + entity  + ", " + TargetUnit + ")");
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
		ViGameSerializer<GameUnit>.Append(entity.RPC.OS, TargetUnit);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_NavigateTo(CellPlayer entity, ViVector3 TargetPosition)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_61_REQ_NavigateTo;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_NavigateTo(" + entity  + ", " + TargetPosition + ")");
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
		ViGameSerializer<ViVector3>.Append(entity.RPC.OS, TargetPosition);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

	public static void REQ_InteractWithObject(CellPlayer entity, SpaceObject targetObject)
	{
		UInt8 receiverSide = (UInt8)ViRPCSide.CELL;
		UInt16 funcID = (UInt16)CellPlayerServerMethod.METHOD_62_REQ_InteractWithObject;
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Invoker >> REQ_InteractWithObject(" + entity  + ", " + targetObject + ")");
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
		ViGameSerializer<SpaceObject>.Append(entity.RPC.OS, targetObject);
		entity.RPC.SendMessage();
		entity.RPC.AftMessage(entity, funcID);
	}

}
