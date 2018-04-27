using System;
using System.Collections.Generic;

public class FPSCountor
{
	public float Value { get { return _spanList.Count / _spanTotal; } }
	public bool Ready { get { return _spanList.Count == _size; } }

	public FPSCountor(int size)
	{
		_size = size;
		_spanIdx = 0;
		_spanTotal = 0;
		_spanList.Capacity = size;
	}

	public void Reset()
	{
		_spanIdx = 0;
		_spanTotal = 0;
		_spanList.Clear();
	}

	public void Update(float deltaTime)
	{
		if (_spanList.Count < _size)
		{
			_spanTotal += deltaTime;
			_spanList.Add(deltaTime);
		}
		else
		{
			_spanTotal -= _spanList[_spanIdx];
			_spanTotal += deltaTime;
			_spanList[_spanIdx] = deltaTime;
		}
		//
		++_spanIdx;
		if (_spanIdx >= _spanList.Count)
		{
			_spanIdx = 0;
		}
	}

	Int32 _size = 100;
	float _spanTotal = 0.0f;
	int _spanIdx = 0;
	List<float> _spanList = new List<float>();
}
