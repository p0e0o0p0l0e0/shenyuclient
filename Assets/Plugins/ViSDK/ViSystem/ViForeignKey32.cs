using System;
using System.Collections.Generic;


public struct ViForeignKey<T>
	where T : ViSealedData, new()
{
	public static implicit operator Int32(ViForeignKey<T> data)
	{
		return data.Value;
	}
	public static implicit operator UInt32(ViForeignKey<T> data)
	{
		return (UInt32)data.Value;
	}
	public static implicit operator T(ViForeignKey<T> data)
	{
		return data.PData;
	}

	public ViForeignKey(Int32 value)
	{
		_value = value;
	}

	public T Data { get { return ViSealedDB<T>.Data(_value); } }
	public T PData
	{
		get
		{
			return ViSealedDB<T>.GetData(_value, false);
		}
	}
	public T GetData(T defaultValue)
	{
		T data = ViSealedDB<T>.GetData(_value, false);
		if (data == null)
		{
			data = defaultValue;
		}
		return data;
	}
	public T GetData(Int32 offset)
	{
		if (_value != 0)
		{
			return ViSealedDB<T>.GetData(_value + offset, false);
		}
		else
		{
			return null;
		}
	}
	public Int32 Value { get { return _value; } }
	public bool Empty() { return _value == 0; }
	public bool NotEmpty() { return _value != 0; }

	public void Set(Int32 value) { _value = value; }

	Int32 _value;
}

public struct ViForeignKeyStruct<T> where T : ViSealedData, new()
{
	public static implicit operator Int32(ViForeignKeyStruct<T> data)
	{
		return data.Value;
	}
	public static implicit operator UInt32(ViForeignKeyStruct<T> data)
	{
		return (UInt32)data.Value;
	}
	public static implicit operator T(ViForeignKeyStruct<T> data)
	{
		return data.PData;
	}

	public Int32 Value { get { return _data.Value; } }
    public bool Empty() { return _data.Empty(); }
    public bool NotEmpty() { return _data.NotEmpty(); }

	public T Data { get { return _data.Data; } }
	public T PData { get { return _data.PData; } }

	public void Set(Int32 value) { _data.Set(value); }

	ViForeignKey<T> _data;
}


public class ViForeignGroup<T>
	where T : ViSealedData, new()
{
	public List<T> List { get { return _list; } }

	public void Add(T data)
	{
		_list.Add(data);
	}

	public void Reset()
	{
		_list.Clear();
	}

	List<T> _list = new List<T>();
}