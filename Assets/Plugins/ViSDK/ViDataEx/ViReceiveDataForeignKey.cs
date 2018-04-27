using System;
using System.Collections.Generic;

using ViArrayIdx = System.Int32;
using UInt8 = System.Byte;

public class ViReceiveDataForeignKey<TSealedData> : ViReceiveDataNode
	where TSealedData : ViSealedData, new()
{
	public TSealedData Value { get { return ViSealedDB<TSealedData>.Data(_value); } }
	public override void OnUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		if (MatchChannel(channel))
		{
			Int32 oldValue = _value;
			IS.Read(out _value);
			OnUpdateInvoke(oldValue);
		}
	}
	public new void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		if (MatchChannel(channelMask))
		{
			IS.Read(out _value);
		}
	}
	public static bool operator ==(ViReceiveDataForeignKey<TSealedData> lhs, ViReceiveDataForeignKey<TSealedData> rhs)
	{
		return (lhs._value == rhs._value);
	}
	public static bool operator !=(ViReceiveDataForeignKey<TSealedData> lhs, ViReceiveDataForeignKey<TSealedData> rhs)
	{
		return (lhs._value != rhs._value);
	}
	public static bool operator ==(ViReceiveDataForeignKey<TSealedData> lhs, TSealedData rhs)
	{
		return (lhs._value == rhs.ID);
	}
	public static bool operator !=(ViReceiveDataForeignKey<TSealedData> lhs, TSealedData rhs)
	{
		return (lhs._value != rhs.ID);
	}
	public static implicit operator Int32(ViReceiveDataForeignKey<TSealedData> data)
	{
		return data._value;
	}
	public static implicit operator TSealedData(ViReceiveDataForeignKey<TSealedData> data)
	{
		return data.Value;
	}
	public static implicit operator ViForeignKey<TSealedData>(ViReceiveDataForeignKey<TSealedData> data)
	{
		return new ViForeignKey<TSealedData>(data._value);
	}
	public override int GetHashCode()
	{
		return _value.GetHashCode();
	}
	public override bool Equals(object other)
	{
		if (!(other is ViReceiveDataForeignKey<TSealedData>))
		{
			return false;
		}
		ViReceiveDataForeignKey<TSealedData> data = (ViReceiveDataForeignKey<TSealedData>)other;
		return _value.Equals(data.Value);
	}
	Int32 _value;
}

//public static class ViForeignKeySerializer
//{
//    public static void Append<TSealedData>(ViOStream OS, ViReceiveDataForeignKey<TSealedData> value)
//    where TSealedData : ViSealedData, new()
//    {
//        OS.Append(value);
//    }
//}
