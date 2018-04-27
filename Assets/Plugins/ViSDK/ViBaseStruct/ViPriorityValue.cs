using System;
using System.Collections.Generic;

public class ViPriorityValue<T>
{
	public delegate void DeleUpdated(T oldValue, T newValue);
	public DeleUpdated UpdatedExec;

	public ViPriorityValue()
	{

	}

	public ViPriorityValue(T defaultValue)
	{
		_defaultValue = defaultValue;
		_value = defaultValue;
	}

	public T Value { get { return _value; } }
	public T DefaultValue
	{
		get { return _defaultValue; }
		set
		{
			_defaultValue = value;
			Update();
		}
	}
	public int Count { get { return _list.Count; } }

	public void Clear()
	{
		_list.Clear();
		_value = DefaultValue;
	}

	public void Add(string name, Int32 weight, T value)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			Node iterNode = _list[iter];
			if (iterNode.Name == name)
			{
				iterNode.Weight = weight;
				iterNode.Value = value;
				//
				Update();
				return;
			}
		}
		//
		Node node = new Node();
		node.Name = name;
		node.Weight = weight;
		node.Value = value;
		_list.Add(node);
		//
		Update();
	}

	public bool Del(string name)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			Node iterNode = _list[iter];
			if (iterNode.Name == name)
			{
				_list.RemoveAt(iter);
				Update();
				return true;
			}
		}
		return false;
	}

	public bool Has(string name)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			Node iterNode = _list[iter];
			if (iterNode.Name == name)
			{
				return true;
			}
		}
		return false;
	}

	void Update()
	{
		T oldValue = _value;
		_value = _defaultValue;
		Int32 maxWeight = Int32.MinValue;
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			Node iterNode = _list[iter];
			if (iterNode.Weight > maxWeight)
			{
				_value = iterNode.Value;
				maxWeight = iterNode.Weight;
			}
		}
		if (!object.Equals(oldValue, _value))
		{
			if (UpdatedExec != null)
			{
				UpdatedExec(oldValue, _value);
			}
		}
	}

	public void UpdateNotify()
	{
		if (UpdatedExec != null)
		{
			UpdatedExec(_value, _value);
		}
	}

	T _value;
	T _defaultValue;

	public void CopyTo(List<Node> list)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			list.Add(_list[iter]);
		}
	}

	public class Node
	{
		public string Name;
		public Int32 Weight;
		public T Value;
	}
	List<Node> _list = new List<Node>();
}
