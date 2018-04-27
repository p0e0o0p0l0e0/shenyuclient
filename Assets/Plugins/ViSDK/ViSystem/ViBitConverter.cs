using System;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using System.Collections.Generic;

public static class ViBitConverter
{
	public static readonly bool IsLittleEndian = true;

	public static bool GetBytes(bool value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 1)
		{
			return false;
		}
		if (value)
		{
			buffer[0] = 1;
		}
		else
		{
			buffer[0] = 0;
		}
		return true;
	}

	public static bool GetBytes(Int8 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 1)
		{
			return false;
		}
		buffer[0] = (byte)value;
		return true;
	}

	public static bool GetBytes(UInt8 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 1)
		{
			return false;
		}
		buffer[0] = value;
		return true;
	}
	public static bool GetBytes(Int16 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 2)
		{
			return false;
		}
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		return true;
	}
	public static bool GetBytes(UInt16 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 2)
		{
			return false;
		}
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		return true;
	}
	public static bool GetBytes(Int32 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 2)
		{
			return false;
		}
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		buffer[2] = (byte)(value >> 16);
		buffer[3] = (byte)(value >> 24);
		return true;
	}
	public static bool GetBytes(UInt32 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 2)
		{
			return false;
		}
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		buffer[2] = (byte)(value >> 16);
		buffer[3] = (byte)(value >> 24);
		return true;
	}
	public static bool GetBytes(Int64 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 2)
		{
			return false;
		}
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		buffer[2] = (byte)(value >> 16);
		buffer[3] = (byte)(value >> 24);
		buffer[4] = (byte)(value >> 32);
		buffer[5] = (byte)(value >> 40);
		buffer[6] = (byte)(value >> 48);
		buffer[7] = (byte)(value >> 56);
		return true;
	}
	public static bool GetBytes(UInt64 value, byte[] buffer)
	{
		if (buffer == null)
		{
			return false;
		}
		if (buffer.Length < 2)
		{
			return false;
		}
		buffer[0] = (byte)value;
		buffer[1] = (byte)(value >> 8);
		buffer[2] = (byte)(value >> 16);
		buffer[3] = (byte)(value >> 24);
		buffer[4] = (byte)(value >> 32);
		buffer[5] = (byte)(value >> 40);
		buffer[6] = (byte)(value >> 48);
		buffer[7] = (byte)(value >> 56);
		return true;
	}
	public static bool GetBytes(float value, byte[] buffer)
	{
		return GetBytes((int)(value * 100 + 0.5f), buffer);
	}
	public static bool GetBytes(double value, byte[] buffer)
	{
		return GetBytes((long)(value * 10000 + 0.5), buffer);
	}

	public static bool ToBool(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 1 > value.Length)
		{
			return false;
		}
		if (value[0] == 0) { return false; }
		else { return true; }
	}
	public static Int8 ToInt8(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 1 > value.Length)
		{
			return (Int8)0;
		}
		return (Int8)value[offset + 0];
	}
	public static UInt8 ToUInt8(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 1 > value.Length)
		{
			return (UInt8)0;
		}
		return (UInt8)value[offset + 0];
	}
	public static Int16 ToInt16(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 2 > value.Length)
		{
			return (Int16)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)));
		return (Int16)num;
	}
	public static UInt16 ToUInt16(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 2 > value.Length)
		{
			return (UInt16)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)));
		return (UInt16)num;
	}
	public static UInt32 ToUInt24(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 3 > value.Length)
		{
			return (UInt32)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)) | (value[offset + 2] << 16));
		return (UInt32)num;
	}
	public static Int32 ToInt32(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 4 > value.Length)
		{
			return (Int32)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)) | (value[offset + 2] << 16)) | (value[offset + 3] << 24);
		return num;
	}
	public static UInt32 ToUInt32(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 4 > value.Length)
		{
			return (UInt32)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)) | (value[offset + 2] << 16)) | (value[offset + 3] << 24);
		return (UInt32)num;
	}
	public static Int64 ToInt64(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 8 > value.Length)
		{
			return (Int64)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)) | (value[offset + 2] << 16)) | (value[offset + 3] << 24);
		int num2 = ((value[offset + 4] | (value[offset + 5] << 8)) | (value[offset + 6] << 16)) | (value[offset + 7] << 24);
		UInt64 num3 = (UInt64)((UInt32)num);
		UInt64 num4 = (UInt64)((UInt32)num2);
		UInt64 num5 = num3 | (num4 << 32);
		return (Int64)num5;
	}
	public static UInt64 ToUInt64(byte[] value, int offset)
	{
		ViDebuger.AssertError(value);
		if (offset < 0 || offset + 8 > value.Length)
		{
			return (Int64)0;
		}
		int num = ((value[offset + 0] | (value[offset + 1] << 8)) | (value[offset + 2] << 16)) | (value[offset + 3] << 24);
		int num2 = ((value[offset + 4] | (value[offset + 5] << 8)) | (value[offset + 6] << 16)) | (value[offset + 7] << 24);
		UInt64 num3 = (UInt64)((UInt32)num);
		UInt64 num4 = (UInt64)((UInt32)num2);
		UInt64 num5 = num3 | (num4 << 32);
		return num5;
	}
	public static float ToFloat(byte[] value, int offset)
	{
		return ToInt32(value, offset) * 0.01f;
	}
	public static double ToDouble(byte[] value, int offset)
	{
		return ToInt64(value, offset) * 0.0001;
	}
	public static string ToString(byte[] value)
	{
		if (value == null)
		{
			return string.Empty;
		}
		return ToString(value, 0, value.Length);
	}

	public static string ToString(byte[] value, int startIndex)
	{
		if (value == null)
		{
			return string.Empty;
		}
		return ToString(value, startIndex, value.Length - startIndex);
	}

	static Char[] StringCache = new Char[1024];
	public static string ToString(byte[] value, int startIndex, int length)
	{
		ViDebuger.AssertError(value);
		if (startIndex < 0 || length < 0 || startIndex + length > value.Length)
		{
			return string.Empty;
		}
		int len16 = length / 2;
		if (len16 > StringCache.Length)
		{
			int newSize = Math.Max(StringCache.Length * 2, len16);
			StringCache = new char[newSize];
		}
		for (int idx = 0; idx < len16; ++idx)
		{
			int upper = (int)value[startIndex + 2 * idx + 1] << 8;
			int lower = (int)value[startIndex + 2 * idx];
			StringCache[idx] = (char)(upper + lower);
		}
		StringCache[len16] = (char)0;
		return new string(StringCache, 0, len16);
	}
}
