using System;
using System.Collections;
using System.Collections.Generic;
using ViOperatorIdx = System.Byte;
using ViArrayIdx = System.Int32;
using UInt8 = System.Byte;

public struct ViNormalDataPtr<T>
{
	public static readonly UInt8 EMPTY_TAG = (UInt8)0;
	public static readonly UInt8 UN_EMPTY_TAG = (UInt8)255;

	public T Data;
	public bool Empty { get { return !_active; } }

	public void Load(ViIStream IS)
	{
		UInt8 tag;
		IS.Read(out tag);
		if (tag == UN_EMPTY_TAG)
		{
			_active = true;
			ViSerializer<T>.Read(IS, out Data);
		}
		else
		{
			_active = false;
		}
	}
	public void Print(ViOStream OS)
	{
		if (Empty)
		{
			OS.Append(ViNormalDataPtr<T>.EMPTY_TAG);
		}
		else
		{
			OS.Append(ViNormalDataPtr<T>.UN_EMPTY_TAG);
			ViSerializer<T>.Append(OS, Data);
		}
	}

	public void Load(string head, ViStringDictionaryStream stream)
	{
		UInt8 tag;
		ViSerializer<UInt8>.Read(stream, head + ".PtrTag", out tag);
		if (tag == UN_EMPTY_TAG)
		{
			_active = true;
			ViSerializer<T>.Read(stream, head, out Data);
		}
		else
		{
			_active = false;
		}
	}
	public void Print(string head, ViStringDictionaryStream stream)
	{
		if (_active)
		{
			ViSerializer<UInt8>.Append(stream, head + ".PtrTag", UN_EMPTY_TAG);
			ViSerializer<T>.Append(stream, head, Data);
		}
		else
		{
			ViSerializer<UInt8>.Append(stream, head + ".PtrTag", EMPTY_TAG);
		}
	}

	public void Set(T data)
	{
		Data = data;
		_active = true;
	}

	bool _active;
}

public class ViReceiveDataPtr<TProto> : ViReceiveDataNode
	where TProto : new()
{
	public static readonly UInt16 END_SLOT = 0XFFFF;
	public static readonly UInt8 EMPTY_TAG = (UInt8)0;
	public static readonly UInt8 UN_EMPTY_TAG = (UInt8)255;

	public TProto Data { get { return _data; } }
	public bool Empty { get { return _empty; } }
	public static implicit operator ViNormalDataPtr<TProto>(ViReceiveDataPtr<TProto> data)
	{
		ViNormalDataPtr<TProto> value = new ViNormalDataPtr<TProto>();
		if (!data.Empty)
		{
			value.Set(data.Data);
		}
		return value;
	}

	public override void OnUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		if (!MatchChannel(channel))
		{
			return;
		}
		ViOperatorIdx op;
		IS.Read(out op);
		switch ((ViDataArrayOperator)op)
		{
			case ViDataArrayOperator.INSERT:
				{
					_empty = false;
					ViSerializer<TProto>.Read(IS, out _data);
					OnUpdateInvoke();
				}
				break;
			case ViDataArrayOperator.MOD:
				{
					ViDebuger.AssertError(!Empty);
					ViSerializer<TProto>.Read(IS, out _data);
					OnUpdateInvoke();
				}
				break;
			case ViDataArrayOperator.CLEAR:
				ViDebuger.AssertError(!Empty);
				if (_data != null)
				{
					_data = default(TProto);
				}
				_empty = true;
				OnUpdateInvoke();
				break;
			default:
				break;
		}
	}

	public new void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		if (!MatchChannel(channelMask))
		{
			return;
		}
		UInt8 tag = 0;
		IS.Read(out tag);
		if (tag == UN_EMPTY_TAG)
		{
			_empty = false;
			ViSerializer<TProto>.Read(IS, out _data);
		}
		else
		{
			_empty = true;
		}
	}
	TProto _data = new TProto();
	bool _empty = true;
}