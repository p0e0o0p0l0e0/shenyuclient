using System;
using System.Collections.Generic;


public class ViWorkFlowEvent
{
	public delegate void DeleCompleteCallback();
	public bool Active { get { return Count <= 0; } }
	public Int32 Count { get { return _waitList.Count; } }

	public void Wait(string key)
	{
		Wait(key, null);
	}

	public void Wait(string key, DeleCompleteCallback callback)
	{
		if (IsWaiting(key))
		{
			return;
		}
		Node newNode = new Node(key, callback);
		_waitList.Add(newNode);
	}

	public bool IsWaiting(string key)
	{
		for (int iter = 0; iter < _waitList.Count; ++iter)
		{
			if (_waitList[iter].Name == key)
			{
				return true;
			}
		}
		//
		return false;
	}

	public bool EraseWaiting(string key)
	{
		bool result = false;
		for (int iter = _waitList.Count-1; iter >= 0; --iter)
		{
			if (_waitList[iter].Name == key)
			{
				_waitList.RemoveAt(iter);
				result = true;
			}
		}
		//
		return result;
	}


	public void Complete(string key)
	{
		EraseWaiting(key);
		if (_waitList.Count == 0)
		{
			_framEndCallback.AsynExec(this.Invoke);
		}
	}

	public void Reset(DeleCompleteCallback callback)
	{
		_waitList.Clear();
		_framEndCallback.Detach();
		//
		_callback = callback;
	}

	public void Clear()
	{
		_waitList.Clear();
		_framEndCallback.Detach();
		_callback = null;
	}

	ViFramEndCallback0 _framEndCallback = new ViFramEndCallback0();
	void Invoke()
	{
		DeleCompleteCallback dele = _callback;
		_callback = null;
		if (dele != null)
		{
			dele();
		}
	}

	struct Node
	{
		public Node(string name, DeleCompleteCallback callback)
		{
			Name = name;
			Callback = callback;
		}
		public string Name;
		public DeleCompleteCallback Callback;
	}

	DeleCompleteCallback _callback;
	List<Node> _waitList = new List<Node>();
}