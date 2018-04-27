using System;

using System.Collections;
using System.Collections.Generic;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViArrayIdx = System.Int32;

public class ViOStream
{
	public byte[] Cache { get { return _buffer; } }
	public int Length { get { return _current; } }

	public ViOStream()
		: this(1024)
	{

	}
	public ViOStream(int initialSize)
	{
		this._buffer = new byte[initialSize];
	}
	public void Reset() { _current = 0; }

	public void Append(byte[] value)
	{
		this.Append(value, 0, value.Length);
	}
	public void Append(Int8 value)
	{
		_memCache[0] = (byte)value;
		this.Append(_memCache, 0, 1);
	}
	public void Append(UInt8 value)
	{
		this.EnsureBuffer(1);
		this._buffer[this._current++] = value;
	}
	public void Append(Int16 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		this.Append(_memCache, 0, 2);
	}
	public void Append(UInt16 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		this.Append(_memCache, 0, 2);
	}
	public void Append(Int32 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		_memCache[2] = (byte)(value >> 16);
		_memCache[3] = (byte)(value >> 24);
		this.Append(_memCache, 0, 4);
	}
	public void Append(UInt32 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		_memCache[2] = (byte)(value >> 16);
		_memCache[3] = (byte)(value >> 24);
		this.Append(_memCache, 0, 4);
	}
	public void Append(Int64 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		_memCache[2] = (byte)(value >> 16);
		_memCache[3] = (byte)(value >> 24);
		_memCache[4] = (byte)(value >> 32);
		_memCache[5] = (byte)(value >> 40);
		_memCache[6] = (byte)(value >> 48);
		_memCache[7] = (byte)(value >> 56);
		this.Append(_memCache, 0, 8);
	}
	public void Append(UInt64 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		_memCache[2] = (byte)(value >> 16);
		_memCache[3] = (byte)(value >> 24);
		_memCache[4] = (byte)(value >> 32);
		_memCache[5] = (byte)(value >> 40);
		_memCache[6] = (byte)(value >> 48);
		_memCache[7] = (byte)(value >> 56);
		this.Append(_memCache, 0, 8);
	}
	public void Append(float value)
	{
		Int32 iValue = (Int32)(value * 100 + 0.5f);
		if (Int16.MinValue < iValue && iValue < Int16.MaxValue)
		{
			this.Append((Int16)iValue);
		}
		else
		{
			this.Append(Int16.MaxValue);
			this.Append(iValue);
		}
	}
	public void Append(double value)
	{
		this.Append((Int64)(value * 10000 + 0.5));
	}

	public void Append(string value)
	{
		if (value == null)
		{
			value = string.Empty;
		}
		//value = value.Trim();//老杨 需求, 一些字符串 前面就是有空白
		AppendPacked(value.Length);
		Int32 size = value.Length * 2;
		this.EnsureBuffer(size);
		for (int iter = 0; iter < value.Length; ++iter)
		{
			char ch = value[iter];
			//if (ch > '\x00ff')
			//{
			//    throw new FormatException(SR.GetString("MailHeaderFieldInvalidCharacter"));
			//}
			this._buffer[this._current + 2 * iter] = (byte)ch;
			this._buffer[this._current + 2 * iter + 1] = (byte)(ch >> 8);
		}
		this._current += size;
	}
	public void Append(byte[] value, int offset, int count)
	{
		this.EnsureBuffer(count);
		System.Buffer.BlockCopy(value, offset, this._buffer, this._current, count);
		this._current += count;
	}
	public void Append(ViOStream stream)
	{
		int len = stream.Length;
		AppendPacked(len);
		Append(stream._buffer, 0, stream._current);
	}

	public void Append(List<Int8> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int8 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<UInt8> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt8 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<Int16> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int16 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<UInt16> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt16 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<Int32> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int32 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<UInt32> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt32 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<Int64> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Int64 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<UInt64> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt64 value = list[iter];
			Append(value);
		}
	}
	public void Append(List<float> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			float value = list[iter];
			Append(value);
		}
	}
	public void Append(List<double> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			double value = list[iter];
			Append(value);
		}
	}
	public void Append(List<string> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			string value = list[iter];
			Append(value);
		}
	}

	public void AppendPacked(Int32 value)
	{
		if (value < 255)
		{
			Append((UInt8)value);
		}
		else
		{
			Append((UInt8)255);
			Append((UInt32)value);
		}
	}

	public void Append24(UInt32 value)
	{
		_memCache[0] = (byte)value;
		_memCache[1] = (byte)(value >> 8);
		_memCache[2] = (byte)(value >> 16);
		this.Append(_memCache, 0, 3);
	}

	public void Append24(List<UInt32> list)
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			UInt32 value = list[iter];
			Append24(value);
		}
	}

	public UInt8 Sign(UInt32 start, UInt32 len)
	{
		UInt8 sign = 0;
		UInt32 end = Math.Min((start + len), (UInt32)Length);
		for (UInt32 iter = start; iter < end; ++iter )
		{
			UInt8 iterValue = _buffer[iter];
			sign += iterValue;
		}
		//ViDebuger.CritOK("Sign[start=" + start + "/len=" + len + "]=" + sign);
		return sign;
	}

	protected void EnsureBuffer(int count)
	{
		if (count > (this._buffer.Length - this._current))
		{
			byte[] dst = new byte[((this._buffer.Length * 2) > (this._buffer.Length + count)) ? (this._buffer.Length * 2) : (this._buffer.Length + count)];
			System.Buffer.BlockCopy(this._buffer, 0, dst, 0, this._current);
			this._buffer = dst;
		}
	}

	public void _SetValue(int offset, byte[] value, int cnt)
	{
		ViDebuger.AssertError(offset + cnt < _current && cnt <= value.Length);
		for (int i = 0; i < cnt; i++)
		{
			_buffer[offset + i] = value[i];
		}
	}

	public void Trim()
	{
		if (_buffer.Length >= Length)
		{
			return;
		}
		byte[] newBuffer = new byte[Length];
		for (int iter = 0; iter < Length; iter++)
		{
			newBuffer[iter] = _buffer[iter];
		}
		_buffer = newBuffer;
	}

	protected byte[] _memCache = new byte[8];

	protected byte[] _buffer;
	protected int _current;
}