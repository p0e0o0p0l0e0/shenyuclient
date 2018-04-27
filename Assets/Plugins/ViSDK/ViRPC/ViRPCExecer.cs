using System;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;

public class ViRPCExecer
{
	public virtual ViEntityID ID() { return 0; }
	public virtual ViRPCEntity Entity { get { return null; } }

	public virtual void End(ViEntityManager entityManager) { }
	public virtual void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS) { }
	public virtual void OnPropertyUpdateStart(UInt8 channel) { }
	public virtual void OnPropertyUpdate(UInt8 channel, ViIStream IS) { }
	public virtual void OnPropertyUpdateEnd(UInt8 channel) { }
	public virtual void OnMessage(UInt16 funcIdx, ViIStream IS) { }

}

public class ViEntityType
{
	static public ViEntityTypeID Type(ViEntityID ID)
	{
		return (ViEntityTypeID)(ID >> 56);
	}
	public static void Register(ViEntityTypeID typeID, CreateRPCExecer creator)
	{
		ViEntityType type = new ViEntityType();
		type._creator = creator;
		ViEntityCreator.RegisterCreator(typeID, type);
	}

	public delegate ViRPCExecer CreateRPCExecer();

	public ViRPCExecer Create()
	{
		ViDebuger.AssertError(_creator);
		return _creator();
	}

	CreateRPCExecer _creator;
}

public static class ViEntityCreator
{
	public static void RegisterCreator(ViEntityTypeID typeID, ViEntityType type)
	{
		_execerCreatorList[typeID] = type;
	}
	public static Dictionary<ViEntityTypeID, ViEntityType> List { get { return _execerCreatorList; } }

	static Dictionary<ViEntityTypeID, ViEntityType> _execerCreatorList = new Dictionary<ViEntityTypeID, ViEntityType>();
}

public enum ViRPCMessage
{
	INF = 60000,
	CONNECT_START,
	CONNECT_END,
	EXEC_ACK,
	EXEC_RESULT,
	EXEC_EXCEPTION,
	EXEC_BUSY,
	VERSION,
	VERSION_RESULT,
	LOGIN,
	LOGIN_RESULT,
	LICENCE_UPDATE,
	GAME_START,
	GAME_TIME_UPDATE,
	CREATE_SELF,
	ENTITY_EMERGE,
	ENTITY_VANISH,
	ENTITY_LIST_EMERGE,
	ENTITY_LIST_VANISH,
	ENTITY_PROPERTY_UPDATE_CHANNEL_INF,
	ENTITY_PROPERTY_UPDATE_CHANNEL_SUP = ENTITY_PROPERTY_UPDATE_CHANNEL_INF + 15,
	ENTITY_GM,
	ENTITY_MESSAGE,
	SCRIPT_STREAM,
	ENTITY_ID_PACK,
	ENTITY_ID_PACK_LIST,
	PING,
	SQL_EXEC,
	SQL_EXEC_LIST,
	SQL_RESULT,
	SUP,
}

public enum ViRPCSide
{
	CLIENT,
	CELL,
	BASE,
	GM,
	DB,
	GLOBAL,
	CENTER,
	TOTAL,	
}

public class ViRPCExecerManager
{
	public delegate void OnSystemMessage(UInt16 funcID, ViIStream IS);
	public delegate void DeleLoginResult(UInt8 result, string note);
	public delegate void OnSelfCreated(ViRPCExecer execer);
	public delegate void OnSelfMessage(UInt16 msgID, UInt64 types, ViIStream IS);
	public delegate void OnExecBussyMessage(UInt16 funcID);
	public delegate void OnEntityEnter(ViRPCExecer execer);
	public delegate void OnEntityLeave(ViRPCExecer execer);
	public delegate void DeleGameStart(Int64 time1970, Int64 timeAccumulate);
	public delegate void DeleGameTime(Int64 timeAccumulate);
	public delegate void DeleScriptStream(string script, ViIStream stream);
	public delegate void DeleOnPing(Int64 localTime, Int64 serverTime);
	public OnSystemMessage SystemMessageExecer;
	public DeleLoginResult OnLoginResult;
	public OnSelfCreated OnSelfCreatedExecer;
	public OnSelfMessage OnSelfMessageExecer;
	public OnExecBussyMessage OnExecBusyExecer;
	public OnEntityEnter OnEntityEnterExecer;
	public OnEntityLeave OnEntityLeaveExecer;
	public DeleGameStart OnGameStartExecer;
	public DeleGameTime OnGameTimeExecer;
	public DeleScriptStream OnScriptStream;
	public DeleOnPing OnPing;

	public static readonly UInt16 SYSTEM_MSG_INF = 60000;
	public UInt16 SELF_PROPERTY_MASK = 0;
	public UInt16 OTHER_PROPERTY_MASK = 0;

	public ViEntityManager EntityManager { get { return _entityManager; } }
	public bool OtherEntityShow { get { return _otherEntityShow; } }
	public ViRPCResultDistributor ResultDistributor { get { return _resultDistributor; } }

	public ViRPCExecerManager(bool otherEntityShow)
	{
		_otherEntityShow = otherEntityShow;
	}

	public void OnMessage(ViIStream IS)
	{
		ViEntitySerialize.EntityNameger = _entityManager;
		//
		UInt16 funcID;
		IS.Read(out funcID);
		//
		if (funcID >= SYSTEM_MSG_INF)
		{
			if (ViRPCMessage.ENTITY_PROPERTY_UPDATE_CHANNEL_INF <= (ViRPCMessage)funcID && (ViRPCMessage)funcID <= ViRPCMessage.ENTITY_PROPERTY_UPDATE_CHANNEL_SUP)
			{
				UInt8 channel = (UInt8)(funcID - (UInt16)ViRPCMessage.ENTITY_PROPERTY_UPDATE_CHANNEL_INF);
				OnEntityPropertyUpdate(channel, IS);
				return;
			}
			switch ((ViRPCMessage)funcID)
			{
				case ViRPCMessage.CREATE_SELF:
					OnSelfEntity(funcID, IS);
					break;
				case ViRPCMessage.ENTITY_EMERGE:
					OnEntityEmerge(IS);
					break;
				case ViRPCMessage.ENTITY_VANISH:
					OnEntityVanish(IS);
					break;
				case ViRPCMessage.ENTITY_LIST_EMERGE:
					OnEntityListEmerge(IS);
					break;
				case ViRPCMessage.ENTITY_LIST_VANISH:
					OnEntityListVanish(IS);
					break;
				case ViRPCMessage.ENTITY_MESSAGE:
					OnEntityMessage(IS);
					break;
				case ViRPCMessage.GAME_START:
					OnGameStart(IS);
					break;
				case ViRPCMessage.GAME_TIME_UPDATE:
					OnGameTime(IS);
					break;
				case ViRPCMessage.EXEC_ACK:
					OnExecACK(IS);
					break;
				case ViRPCMessage.EXEC_RESULT:
					_OnRPCResult(IS);
					break;
				case ViRPCMessage.EXEC_EXCEPTION:
					_OnRPCResultException(IS);
					break;
				case ViRPCMessage.EXEC_BUSY:
					_OnExecBusy(IS);
					break;
				case ViRPCMessage.LOGIN_RESULT:
					_OnLoginResult(IS);
					break;
				case ViRPCMessage.LICENCE_UPDATE:
					_OnLicenceUpdate(IS);
					break;
				case ViRPCMessage.SCRIPT_STREAM:
					_OnScriptStream(IS);
					break;
				case ViRPCMessage.PING:
					_OnPing(IS);
					break;
				default:
					ViDebuger.AssertError(SystemMessageExecer != null);
					SystemMessageExecer(funcID, IS);
					break;
			}
		}
		else
		{
			UInt32 entityID;
			IS.Read24(out entityID);
			OnEntityExec(entityID, funcID, IS);
		}
	}

	public void Start(ViNetInterface net)
	{
		_net = net;
		_entityManager.Start();
	}
	public void End()
	{
		_net = null;
		foreach (KeyValuePair<ViEntityID, ViRPCExecer> pair in _execerList)
		{
			pair.Value.End(_entityManager);
		}
		_execerList.Clear();
		_execerPackedList.Clear();
		_entityPackIDList.Clear();
		_entityManager.End();
		_licence.Clear();
	}

	public void OnEntityExec(UInt32 packedID, UInt16 funcID, ViIStream IS)
	{
		ViRPCExecer execer;
		if (_execerPackedList.TryGetValue(packedID, out execer))
		{
			execer.OnMessage(funcID, IS);
		}
		else
		{
			if (OtherEntityShow)
			{
				ViDebuger.Warning("Exec.Entity(PackedID=" + packedID + ") is not exist!");
			}
		}
	}

	public void OnEntityListEmerge(ViIStream IS)
	{
		if (!OtherEntityShow)
		{
			return;
		}
		List<ViEntityID> entities;
		List<UInt32> packedIDList;
		IS.Read(out entities);
		IS.Read24(out packedIDList);
		ViDebuger.AssertError(entities.Count == packedIDList.Count);
		for (int iter = 0; iter < entities.Count; ++iter)
		{
			ViEntityID entityID = entities[iter];
			UInt32 packedID = packedIDList[iter];
			ViEntityTypeID typeID = ViEntityType.Type(entityID);
			ViEntityType type;
			if (!ViEntityCreator.List.TryGetValue(typeID, out type))
			{
				ViDebuger.Warning("EmergeList.EntityType(" + typeID + ") error!");
				continue;
			}
			ViRPCExecer execer = type.Create();
			if (_execerList.ContainsKey(entityID))
			{
				ViDebuger.Warning("EmergeList.Entity(ID:" + entityID + "/" + packedID + ") is exist!");
				continue;
			}
			if (_execerPackedList.ContainsKey(packedID))
			{
				ViDebuger.Warning("EmergeList.Entity(PackedID:" + packedID + "/" + entityID + ") is exist!");
				continue;
			}
			_execerList[entityID] = execer;
			_execerPackedList[packedID] = execer;
			_entityPackIDList[entityID] = packedID;
			UInt16 channelMask = OTHER_PROPERTY_MASK;
			execer.Start(entityID, packedID, false, EntityManager, channelMask, IS);
			execer.Entity.RPC.Start(_net, null, _licence);
			if (OnEntityEnterExecer != null)
			{
				OnEntityEnterExecer(execer);
			}
		}
	}

	public void OnEntityEmerge(ViIStream IS)
	{
		if (!OtherEntityShow)
		{
			return;
		}
		ViEntityID entityID;
		UInt32 packedID;
		IS.Read(out entityID);
		IS.Read24(out packedID);
		ViEntityTypeID typeID = ViEntityType.Type(entityID);
		ViEntityType type;
		if (!ViEntityCreator.List.TryGetValue(typeID, out type))
		{
			ViDebuger.Warning("Emerge.EntityType(" + typeID + ") error!");
			return;
		}
		ViRPCExecer execer = type.Create();
		if (_execerList.ContainsKey(entityID))
		{
			ViDebuger.Warning("Emerge.Entity(ID:" + entityID + "/" + packedID + ") is exist!");
			return;
		}
		if (_execerPackedList.ContainsKey(packedID))
		{
			ViDebuger.Warning("Emerge.Entity(PackedID:" + packedID + "/" + entityID + ") is exist!");
			return;
		}
		_execerList[entityID] = execer;
		_execerPackedList[packedID] = execer;
		_entityPackIDList[entityID] = packedID;
		UInt16 channelMask = OTHER_PROPERTY_MASK;
		execer.Start(entityID, packedID, false, EntityManager, channelMask, IS);
		execer.Entity.RPC.Start(_net, null, _licence);
		if (OnEntityEnterExecer != null)
		{
			OnEntityEnterExecer(execer);
		}
	}

	public void OnEntityListVanish(ViIStream IS)
	{
		if (!OtherEntityShow)
		{
			return;
		}
		List<UInt32> entities;
		IS.Read24(out entities);
		OnEntityListVanish(entities);
	}

	public void OnEntityListVanish(List<UInt32> entities)
	{
		for (int iter = 0; iter < entities.Count; ++iter)
		{
			UInt32 packedID = entities[iter];
			ViRPCExecer execer;
			if (!_execerPackedList.TryGetValue(packedID, out execer))
			{
				ViDebuger.Warning("Vanish.Entity(PackedID:" + packedID + ") is not exist!");
				continue;
			}
			execer.Entity.SetActive(false);
			if (OnEntityLeaveExecer != null)
			{
				OnEntityLeaveExecer(execer);
			}
			_execerList.Remove(execer.ID());
			_execerPackedList.Remove(packedID);
			_entityPackIDList.Remove(execer.ID());
			execer.End(EntityManager);
		}
	}

	public void OnEntityVanish(ViIStream IS)
	{
		if (!OtherEntityShow)
		{
			return;
		}
		UInt32 packedID;
		IS.Read24(out packedID);
		ViRPCExecer execer;
		if (!_execerPackedList.TryGetValue(packedID, out execer))
		{
			ViDebuger.Warning("Vanish.Entity(PackedID=" + packedID + ") is not exist!");
			return;
		}
		execer.Entity.SetActive(false);
		if (OnEntityLeaveExecer != null)
		{
			OnEntityLeaveExecer(execer);
		}
		_execerList.Remove(execer.ID());
		_execerPackedList.Remove(packedID);
		_entityPackIDList.Remove(execer.ID());
		execer.End(EntityManager);
	}

	public void DestroyEntity<TEntity>() where TEntity : class, ViEntity
	{
		List<UInt32> delList = new List<UInt32>();
		foreach (KeyValuePair<ViEntityID, ViRPCExecer> pair in _execerList)
		{
			TEntity iterEntity = pair.Value.Entity as TEntity;
			if (iterEntity != null)
			{
				delList.Add(iterEntity.PackID);
			}
		}
		//
		OnEntityListVanish(delList);
	}

	public void OnEntityPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		UInt32 packedID;
		IS.Read24(out packedID);
		ViRPCExecer execer;
		if (!_execerPackedList.TryGetValue(packedID, out execer))
		{
			if (OtherEntityShow)
			{
				ViDebuger.Warning("UpdateProperty.Entity(" + packedID + ") is not exist!");
			}
			return;
		}
		execer.OnPropertyUpdateStart(channel);
		while (IS.RemainLength > 0)
		{
			execer.OnPropertyUpdate(channel, IS);
		}
		execer.OnPropertyUpdateEnd(channel);
	}

	public void OnSelfEntity(UInt16 funcID, ViIStream IS)
	{
		ViEntityID entityID;
		UInt32 packedID;
		IS.Read(out entityID);
		IS.Read24(out packedID);
		ViEntityTypeID typeID = ViEntityType.Type(entityID);
		ViEntityType type;
		if (!ViEntityCreator.List.TryGetValue(typeID, out type))
		{
			return;
		}
		ViRPCExecer execer = type.Create();
		_execerList[entityID] = execer;
		_execerPackedList[packedID] = execer;
		_entityPackIDList[entityID] = packedID;
		UInt16 channelMask = SELF_PROPERTY_MASK;
		execer.Start(entityID, packedID, true, EntityManager, channelMask, IS);
		execer.Entity.RPC.Start(_net, ResultDistributor, _licence);
		ViDebuger.AssertError(OnSelfCreatedExecer != null);
		OnSelfCreatedExecer(execer);
	}

	public void OnEntityMessage(ViIStream IS)
	{
		UInt16 msgID = 0;
		IS.Read(out msgID);
		UInt64 types = 0;
		IS.Read(out types);
		OnSelfMessageExecer(msgID, types, IS);
	}

	public void OnExecACK(ViIStream IS)
	{
		UInt32 entityID;
		UInt16 funcID;
		IS.Read24(out entityID);
		IS.Read(out funcID);
		ViRPCExecer execer;
		if (_execerPackedList.TryGetValue(entityID, out execer))
		{
			execer.Entity.RPC.ACK.Ack(funcID);
		}
	}

	public void _OnExecBusy(ViIStream IS)
	{
		UInt32 entityID;
		UInt16 funcID;
		IS.Read24(out entityID);
		IS.Read(out funcID);
		if (OnExecBusyExecer != null)
		{
			OnExecBusyExecer(funcID);
		}
	}

	public void _OnRPCResult(ViIStream IS)
	{
		UInt64 RPCID;
		IS.Read(out RPCID);
		ResultDistributor.OnResult(RPCID, IS);
	}

	public void _OnRPCResultException(ViIStream IS)
	{
		UInt64 RPCID;
		IS.Read(out RPCID);
		ResultDistributor.OnException(RPCID);
	}

	public void _OnLoginResult(ViIStream IS)
	{
		UInt8 result;
		string note;
		IS.Read(out result);
		IS.Read(out note);
		if (OnLoginResult != null)
		{
			OnLoginResult(result, note);
		}
	}

	public void _OnLicenceUpdate(ViIStream IS)
	{
		List<UInt8> licenceList;
		IS.Read(out licenceList);
		_licence.Add(licenceList);
	}

	public void OnGameStart(ViIStream IS)
	{
		Int64 time1970 = 0;
		Int64 timeAccumulate = 0;
		IS.Read(out time1970);
		IS.Read(out timeAccumulate);
		OnGameStartExecer(time1970, timeAccumulate);
	}

	public void OnGameTime(ViIStream IS)
	{
		Int64 timeAccumulate = 0;
		IS.Read(out timeAccumulate);
		OnGameTimeExecer(timeAccumulate);
	}

	public void _OnScriptStream(ViIStream IS)
	{
		string script;
		ViIStream stream;
		IS.Read(out script);
		IS.Read(out stream);
		OnScriptStream(script, stream);
	}

	public void _OnPing(ViIStream IS)
	{
		Int64 localTime = 0;
		IS.Read(out localTime);
		Int64 serverTime = 0;
		IS.Read(out serverTime);
		if (OnPing != null)
		{
			OnPing(localTime, serverTime);
		}
	}

	ViNetInterface _net;
	ViRPCResultDistributor _resultDistributor = new ViRPCResultDistributor();
	ViRPCLicence _licence = new ViRPCLicence();
	Dictionary<ViEntityID, ViRPCExecer> _execerList = new Dictionary<ViEntityID, ViRPCExecer>();
	Dictionary<ViEntityID, UInt32> _entityPackIDList = new Dictionary<ViEntityID, UInt32>();
	Dictionary<UInt32, ViRPCExecer> _execerPackedList = new Dictionary<UInt32, ViRPCExecer>();
	ViEntityManager _entityManager = new ViEntityManager();
	bool _otherEntityShow;
}


public class ViRPCExecerManagerInstance
{
	public static ViRPCExecerManager Instance { get { return _instance; } }
	static ViRPCExecerManager _instance = new ViRPCExecerManager(true);
}