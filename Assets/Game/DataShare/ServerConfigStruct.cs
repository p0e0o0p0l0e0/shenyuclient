using System;
using System.Collections.Generic;

public enum ViLogType
{
	OK,
	CRIT_OK,
	WARNING,
	RECORD,
	ERR,
	TOTAL,
}

public enum LogMask
{
	SPACE_DEBUG = 0X01,
}

public enum AccountGMRange
{
	SELF,
	BROADCAST,
}

public class ServerConfigPortStruct : ViSealedData
{
	public Int32 Port;
}

public class ServerConfigViewStruct : ViSealedData
{
	public ServerConfigPortStruct GetBase(string name)
	{
		Int32 valueID = Int32.Parse(name);
		return ViSealedDB<ServerConfigPortStruct>.Data(BasePort + valueID);
	}
	public string LoginIP;
	public ViForeignKey<ServerConfigPortStruct> BasePort;
	public ViForeignKey<ServerConfigViewStruct> Merge;
}

public class ServerHeadStruct : ViSealedData
{
	public string Head;
}

public class ServerConfigStruct : ViSealedData
{
	public struct RechargeStruct
	{
		public Int32 Port;
		public string SQLIP;
	}
	//
	public ViForeignKey<ServerHeadStruct> Head;
	public string GameCenterIP;
	public Int32 GameCenterForBasePort;
	public Int32 GameCenterForCellPort;
	public string GameLoginIP;
	public string GameDBIP;
	public Int32 GameDBPort;
	public string SpecialIP;
	public Int32 SpecialPort;
	public string SQLDBName;
	public Int32 SQLPort;
	public RechargeStruct Recharge;
	public ViEnum32<BoolValue> AutoCreateAccount;
	public ViForeignKey<ServerConfigStruct> Merge;
	public ViForeignKey<ServerConfigPortStruct> BasePortStart;
	public ViForeignKey<ServerConfigPortStruct> CellPortStart;
}

public class ProgramConfigStruct : ViSealedData
{
	public ViEnum32<ViLogType> LogLevel;
	public ViMask32<LogMask> IgnoreLogMask;
}

public class AccountStruct : ViSealedData
{
	public Int32 Level;
	public ViEnum32<AccountGMRange> Range;
}