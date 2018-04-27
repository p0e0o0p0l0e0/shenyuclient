using System;

public struct ViLazyString
{
	public static ViLazyString Empty { get { return Instance_Empty; } }
	static ViLazyString Instance_Empty = new ViLazyString();
	static ViLazyString()
	{
		Instance_Empty._value = string.Empty;
	}

	public ViLazyString(string value)
	{
		_value = value;
		_buffer = null;
		_bufferStart = 0;
		_bufferLen = 0;
	}

	public string Value
	{
		get
		{
			ReadBuffer();
			return _value;
		}
	}

	public static implicit operator string(ViLazyString data)
	{
		data.ReadBuffer();
		return data._value;
	}

	public void SetValue(byte[] buffer, int startIndex, int length)
	{
		_value = null;
		_buffer = buffer;
		_bufferStart = startIndex;
		_bufferLen = length;
	}

	public void SetValue(string value)
	{
		_value = value;
		_buffer = null;
		_bufferStart = 0;
		_bufferLen = 0;
	}

	public void ReadBuffer()
	{
		if (Object.ReferenceEquals(_value, null))
		{
			if (_buffer != null)
			{
				_value = ViBitConverter.ToString(_buffer, _bufferStart, _bufferLen);
				_buffer = null;
				_bufferStart = 0;
				_bufferLen = 0;
			}
			else
			{
				_value = string.Empty;
			}
		}
	}

	string _value;
	//
	byte[] _buffer;
	int _bufferStart;
	int _bufferLen;
}
