using System;
using System.Collections.Generic;
using System.Text;

using Int8 = System.SByte;
using UInt8 = System.Byte;

public class ViStringBuilder
{
	public ViStringBuilder()
	{

	}

	public ViStringBuilder(int capacity)
	{
		_builder.Capacity = capacity;
	}

	public bool Empty { get { return _builder.Length <= 0 && String.IsNullOrEmpty(_cacheValue); } }
	public bool NotEmpty { get { return _builder.Length > 0 || !String.IsNullOrEmpty(_cacheValue); } }
	public string Value
	{
		get
		{
			if (_builder.Length > 0 && String.IsNullOrEmpty(_cacheValue))
			{
				_cacheValue = _builder.ToString();
			}
			return _cacheValue;
		}
	}

	public ViStringBuilder Add(string value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(char value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(Int8 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(UInt8 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(Int16 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(UInt16 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(Int32 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(UInt32 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(Int64 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(UInt64 value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(float value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(double value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(bool value)
	{
		_builder.Append(value);
		return this;
	}

	public ViStringBuilder Add(StringBuilder value)
	{
		for (int iter = 0; iter < value.Length; ++iter)
		{
			_builder.Append(value[iter]);
		}
		return this;
	}

	public ViStringBuilder Add(ViStringBuilder value)
	{
		if (string.IsNullOrEmpty(value._cacheValue))
		{
			Add(value._builder);
		}
		else
		{
			Add(value._cacheValue);
		}
		return this;
	}

	public void Set(string value)
	{
		Clear();
		_cacheValue = value;
	}

	public void Clear()
	{
		_builder.Length = 0;
		_cacheValue = string.Empty;
	}

	StringBuilder _builder = new StringBuilder();
	string _cacheValue = string.Empty;
}
