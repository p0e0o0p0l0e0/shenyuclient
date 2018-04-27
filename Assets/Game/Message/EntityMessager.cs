using System;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;

public struct EntityMessager
{
	public static void Message(EntityMessage ID, bool asClient)
	{
		Instance.Reset();
		Instance.Send(ID, asClient);
	}
	public static void Message(ViGameMessageIdx ID, bool asClient)
	{
		Instance.Reset();
		Instance.Send(ID, asClient);
	}
	static EntityMessager Instance = new EntityMessager();

	//
	public void Reset()
	{
		_outStream.Reset();
		_typeMask = 0;
		_idx = 0;
	}
	public void Send(EntityMessage ID, bool asClient)
	{
		_outStream.Append(string.Empty);//MessageSender
		_inStream.Init(_outStream.Cache, 0, _outStream.Length);
		if (asClient)
		{
			EntityMessageController.OnClientMessage((UInt16)ID, _typeMask, _inStream);
		}
		else
		{
			EntityMessageController.OnServerMessage((UInt16)ID, _typeMask, _inStream);
		}
		Reset();
	}
	public void Send(ViGameMessageIdx ID, bool asClient)
	{
		_outStream.Append(string.Empty);//MessageSender
		_inStream.Init(_outStream.Cache, 0, _outStream.Length);
		if (asClient)
		{
			EntityMessageController.OnClientMessage((UInt16)ID, _typeMask, _inStream);
		}
		else
		{
			EntityMessageController.OnServerMessage((UInt16)ID, _typeMask, _inStream);
		}
		Reset();
	}

	//+-------------------------------------------------------------------------------------------------------------------------------------
#region Append
	public void Append(float value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<float> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(Int8 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<Int8> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(UInt8 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<UInt8> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(Int16 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<Int16> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(UInt16 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<UInt16> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(Int32 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<Int32> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(UInt32 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<UInt32> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(Int64 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<Int64> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(UInt64 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<UInt64> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(ViVector3 value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<ViVector3> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(string value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<string> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(CellHero value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<CellHero> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(CellPlayer value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<CellPlayer> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(Player value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<Player> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(ItemStruct value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<ItemStruct> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(ItemCountProperty value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<ItemCountProperty> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(SpaceStruct value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<SpaceStruct> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(CoolingDownStruct value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<CoolingDownStruct> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(GoalStruct value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<GoalStruct> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(FormatTime value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<FormatTime> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(GameFuncStruct value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<GameFuncStruct> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(ActivityStruct value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
	public void Append(List<ActivityStruct> value)
	{
		EntityMessageWriter.Append(ref _typeMask, _outStream, _idx, value);
		++_idx;
	}
#endregion

	UInt64 _typeMask;
	Int32 _idx;
	static ViOStream _outStream = new ViOStream();
	static ViIStream _inStream = new ViIStream();

}