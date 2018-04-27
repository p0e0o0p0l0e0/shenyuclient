using System;

using System.Collections;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViArrayIdx = System.Int32;

public class ViIStream
{
	public readonly static int ArraySizeSize = 4;

	public byte[] Buffer { get { return _buffer; } }
	public int RemainLength { get { return _end - _current; } }
	public bool Error { get { return _error; } }

	public void Init(byte[] buffer, int start, int len)
	{
		_buffer = buffer;
		_start = start;
		_current = start;
		_end = start + len;
		_error = false;
	}

	public void Clear()
	{
		_buffer = null;
		_start = 0;
		_current = 0;
		_end = 0;
		_error = false;
	}

	public void ReWind()
	{
		_current = _start;
		_error = false;
	}

	public void SetEnd()
	{
		_current = _end;
	}

	public bool Read(out Int8 value)
	{
		if (_current + 1 > _end)
		{
			ViDebuger.Warning("Read Fail Int8");
			value = (Int8)0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToInt8(_buffer, _current);
		_Print("Int8", value);
		_current += 1;
		return true;
	}
	public bool Read(out UInt8 value)
	{
		if (_current + 1 > _end)
		{
			ViDebuger.Warning("Read Fail UInt8");
			value = (UInt8)0;
			SetError();
			return false;
		}
		value = _buffer[_current];
		_Print("UInt8", value);
		_current += 1;
		return true;
	}
	public bool Read(out Int16 value)
	{
		if (_current + 2 > _end)
		{
			ViDebuger.Warning("Read Fail Int16");
			value = (Int16)0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToInt16(_buffer, _current);
		_Print("Int16", value);
		_current += 2;
		return true;
	}
	public bool Read(out UInt16 value)
	{
		if (_current + 2 > _end)
		{
			ViDebuger.Warning("Read Fail UInt16");
			value = (UInt16)0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToUInt16(_buffer, _current);
		_Print("UInt16", value);
		_current += 2;
		return true;
	}
	public bool Read(out Int32 value)
	{
		if (_current + 4 > _end)
		{
			ViDebuger.Warning("Read Fail Int32");
			value = 0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToInt32(_buffer, _current);
		_Print("Int32", value);
		_current += 4;
		return true;
	}
	public bool Read(out UInt32 value)
	{
		if (_current + 4 > _end)
		{
			ViDebuger.Warning("Read Fail UInt32");
			value = 0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToUInt32(_buffer, _current);
		_Print("UInt32", value);
		_current += 4;
		return true;
	}
	public bool Read(out Int64 value)
	{
		if (_current + 8 > _end)
		{
			ViDebuger.Warning("Read Fail Int64");
			value = (Int64)0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToInt64(_buffer, _current);
		_Print("Int64", value);
		_current += 8;
		return true;
	}
	public bool Read(out UInt64 value)
	{
		if (_current + 8 > _end)
		{
			ViDebuger.Warning("Read Fail UInt64");
			value = (UInt64)0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToUInt64(_buffer, _current);
		_Print("UInt64", value);
		_current += 8;
		return true;
	}
	public bool Read(out float value)
	{
		//if (_current + 4 > _end)
		//{
		//    ViDebuger.Warning("Read Fail float");
		//    value = 0;
		//    SetError();
		//    return false;
		//}
		//value = ViBitConverter.ToFloat(_buffer, _current);
		//_Print("float", value);
		//_current += 4;
		Int16 iValue;
		Read(out iValue);
		if (iValue != Int16.MaxValue)
		{
			value = iValue * 0.01f;
		}
		else
		{
			Int32 iBigValue;
			Read(out iBigValue);
			value = iBigValue * 0.01f;
		}
		return true;
	}
	public bool Read(out double value)
	{
		if (_current + 8 > _end)
		{
			ViDebuger.Warning("Read Fail double");
			value = 0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToDouble(_buffer, _current);
		_Print("double", value);
		_current += 8;
		return true;
	}
	public bool Read(out string value)
	{
		Int32 len;
		if (!ReadPacked(out len))
		{
			ViDebuger.Warning("Read Fail string");
			value = string.Empty;
			SetError();
			return false;
		}
		Int32 size = len * 2;
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read string.size Error");
			value = string.Empty;
			SetError();
			return false;
		}
		value = ViBitConverter.ToString(_buffer, _current, size);
		_Print("string", value);
		_current += size;
		return true;
	}

	public bool Read(out ViLazyString value)
	{
		Int32 len;
		if (!ReadPacked(out len))
		{
			ViDebuger.Warning("Read Fail string");
			value = ViLazyString.Empty;
			SetError();
			return false;
		}
		Int32 size = len * 2;
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read string.size Error");
			value = ViLazyString.Empty;
			SetError();
			return false;
		}
		value = new ViLazyString();
		value.SetValue(_buffer, _current, size);
		_Print("string", value);
		_current += size;
		return true;
	}

	public bool Read(out List<Int8> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<Int8>.size Error");
			list = new List<Int8>();
			return false;
		}
		list = new List<Int8>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int8 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<UInt8> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<UInt8>.size Error");
			list = new List<UInt8>();
			return false;
		}
		list = new List<UInt8>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt8 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<Int16> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<Int16>.size Error");
			list = new List<Int16>();
			return false;
		}
		list = new List<Int16>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int16 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<UInt16> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<UInt16>.size Error");
			list = new List<UInt16>();
			return false;
		}
		list = new List<UInt16>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt16 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<Int32> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<Int32>.size Error");
			list = new List<Int32>();
			return false;
		}
		list = new List<Int32>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int32 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<UInt32> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<UInt32>.size Error");
			list = new List<UInt32>();
			return false;
		}
		list = new List<UInt32>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt32 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<Int64> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<Int64>.size Error");
			list = new List<Int64>();
			return false;
		}
		list = new List<Int64>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int64 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<UInt64> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<UInt64>.size Error");
			list = new List<UInt64>();
			return false;
		}
		list = new List<UInt64>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt64 value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<float> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<float>.size Error");
			list = new List<float>();
			return false;
		}
		list = new List<float>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			float value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<double> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<double>.size Error");
			list = new List<double>();
			return false;
		}
		list = new List<double>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			double value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<string> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<string>.size Error");
			list = new List<string>();
			return false;
		}
		list = new List<string>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			string value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out List<ViLazyString> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<string>.size Error");
			list = new List<ViLazyString>();
			return false;
		}
		list = new List<ViLazyString>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			ViLazyString value;
			Read(out value);
			list.Add(value);
		}
		return true;
	}

	public bool Read(out ViIStream value)
	{
		value = new ViIStream();
		Int32 len;
		ReadPacked(out len);
		if (Error)
		{
			ViDebuger.Warning("Read Stream Error");
			return false;
		}
		if (len > RemainLength)
		{
			ViDebuger.Warning("Read Stream.size Error");
			SetError();
			return false;
		}
		value.Init(_buffer, _current, len);
		_current += len;
		return true;
	}

	public bool ReadPacked(out Int32 value)
	{
		if (_current + 1 > _end)
		{
			ViDebuger.Warning("ReadPacked Fail UInt32");
			value = 0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToUInt8(_buffer, _current);
		_current += 1;
		if (value == 255)
		{
			if (_current + 4 > _end)
			{
				ViDebuger.Warning("ReadPacked Fail UInt32");
				value = 0;
				SetError();
				return false;
			}
			value = ViBitConverter.ToInt32(_buffer, _current);
			_current += 4;
		}
		return true;
	}

	public bool Read24(out UInt32 value)
	{
		if (_current + 3 > _end)
		{
			ViDebuger.Warning("Read24 Fail UInt32");
			value = 0;
			SetError();
			return false;
		}
		value = ViBitConverter.ToUInt24(_buffer, _current);
		_Print("UInt32", value);
		_current += 3;
		return true;
	}

	public bool Read24(out List<UInt32> list)
	{
		ViArrayIdx size;
		ReadPacked(out size);
		if (size > RemainLength)
		{
			ViDebuger.Warning("Read List<UInt32>.size Error");
			list = new List<UInt32>();
			return false;
		}
		list = new List<UInt32>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt32 value;
			Read24(out value);
			list.Add(value);
		}
		return true;
	}

	public bool TryRead(ViIStream value)
	{
		Int32 len;
		ReadPacked(out len);
		if (Error)
		{
			ViDebuger.Warning("Read Stream Error");
			return false;
		}
		if (len > RemainLength)
		{
			ViDebuger.Warning("Read Stream.size Error");
			SetError();
			return false;
		}
		value.Init(_buffer, _current, len);
		_current += len;
		return true;
	}

	void _Print<T>(string type, T value)
	{
		//ViDebuger.Note("Read [" + _offset + "] <" + type + "> " + value);
	}

	public void AppendTo(ViOStream stream)
	{
		int len = RemainLength;
		stream.AppendPacked(len);
		stream.Append(Buffer, _current, len);
	}

	protected void SetError()
	{
		_error = true;
		_current = _end;
	}

	protected byte[] _buffer;
	protected int _start;
	protected int _current;
	protected int _end;
	protected bool _error = false;
}
