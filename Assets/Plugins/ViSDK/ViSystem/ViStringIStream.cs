using System;
using System.Collections;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViArrayIdx = System.Int32;

public class ViStringIStream
{
	public int RemainLength { get { return _buffer.Count - _offset; } }

	public void Init(List<string> buffer)
	{
		_buffer = buffer;
		_offset = 0;
	}
	public void ReWind() { _offset = 0; }

	public bool Read(out Int8 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (Int8)0;
			return false;
		}
		return Int8.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out UInt8 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (UInt8)0;
			return false;
		}
		return UInt8.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out Int16 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (Int16)0;
			return false;
		}
		return Int16.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out UInt16 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (UInt16)0;
			return false;
		}
		return UInt16.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out Int32 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (Int32)0;
			return false;
		}
		return Int32.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out UInt32 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (UInt32)0;
			return false;
		}
		return UInt32.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out Int64 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (Int64)0;
			return false;
		}
		return Int64.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out UInt64 value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (UInt64)0;
			return false;
		}
		return UInt64.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out float value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (float)0;
			return false;
		}
		return float.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out double value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = (double)0;
			return false;
		}
		return double.TryParse(_buffer[_offset++], out value);
	}
	public bool Read(out string value)
	{
		ViDebuger.AssertError(_buffer);
		if (_offset >= _buffer.Count)
		{
			value = string.Empty;
			return false;
		}
		value = _buffer[_offset];
		++_offset;
		return true;
	}
	public bool Read(out List<Int8> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<Int8>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int8 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<UInt8> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<UInt8>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt8 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<Int16> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<Int16>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int16 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<UInt16> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<UInt16>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt16 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<Int32> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<Int32>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int32 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<UInt32> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<UInt32>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt32 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<Int64> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<Int64>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			Int64 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<UInt64> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<UInt64>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			UInt64 value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<float> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<float>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			float value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<double> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<double>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			double value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	public bool Read(out List<string> list)
	{
		ViArrayIdx size;
		Read(out size);
		list = new List<string>((int)size);
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			string value;
			if (Read(out value) == false) { return false; }
			list.Add(value);
		}
		return true;
	}
	List<string> _buffer;
	int _offset;
}
