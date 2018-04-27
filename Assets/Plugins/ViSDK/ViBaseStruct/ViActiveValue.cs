using System;

public struct ViActiveValue<T>
	where T : struct
{
	public bool Active { get { return _active; } }
	public ViActiveValue(bool active, T value)
	{
		_active = active;
		_value = value;
	}
	public void Set(T value)
	{
		_value = value;
		_active = true;
	}

	public void Clear()
	{
		_active = false;
	}

	public bool GetValue(ref T value)
	{
		if (_active)
		{
			value = _value;
			return true;
		}
		else
		{
			return false;
		}
	}

	public T Value(T value)
	{
		if (_active)
		{
			return _value;
		}
		else
		{
			return value;
		}
	}

	bool _active;
	T _value;
}