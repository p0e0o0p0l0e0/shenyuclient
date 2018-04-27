using System;

using UInt8 = System.Byte;
using Int8 = System.SByte;

public class ViRPCCallback<T>
{
	public UInt64 ID { get { return _CBID; } set { _CBID = value; } }
	public bool Active { get { return _CBID != 0;} }

	public ViRPCCallback(UInt64 ID)
	{
		_CBID = ID;
	}
	public ViRPCCallback()
	{

	}

	public void Exception(ViRPCEntity entity, ViRPCSide receiverSide)
	{
		if (_CBID == 0)
		{
			ViDebuger.Warning("ViRPCCallback: Exception Invalid");
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		UInt16 funcIdx = (UInt16)ViRPCMessage.EXEC_EXCEPTION;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append((UInt8)receiverSide);
		entity.RPC.OS.Append(funcIdx);
		entity.RPC.OS.Append(_CBID);
		entity.RPC.SendMessage();
		_CBID = 0;
	}

	public void Invoke(ViRPCEntity entity, ViRPCSide receiverSide, T value)
	{
		if (_CBID == 0)
		{
			ViDebuger.Warning("ViRPCCallback: Invoke Invalid");
			return;
		}
		if (!entity.RPC.Active)
		{
			return;
		}
		UInt16 uiFuncIdx = (UInt16)ViRPCMessage.EXEC_RESULT;
		entity.RPC.ResetSendStream();
		entity.RPC.OS.Append((UInt8)receiverSide);
		entity.RPC.OS.Append(uiFuncIdx);
		entity.RPC.OS.Append(_CBID);
		ViSerializer<T>.Append(entity.RPC.OS, value);
		entity.RPC.SendMessage();
		_CBID = 0;
	}

	UInt64 _CBID = 0;
}
