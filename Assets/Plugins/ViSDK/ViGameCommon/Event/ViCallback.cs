using System;


public abstract class ViAsynDelegateInterface
{
	public static void Update()
	{
		_currentExecList.PushBack(_asynExecList);
		while (_currentExecList.IsNotEmpty())
		{
			ViAsynDelegateInterface asynCallback = _currentExecList.GetHead().Data;
			ViDebuger.AssertError(asynCallback);
			asynCallback._node.Detach();
			asynCallback._node.Data = null;
			asynCallback._AsynExec();
		}
		ViDebuger.AssertWarning(_currentExecList.IsEmpty());
	}
	public static void Clear()
	{
		_asynExecList.Clear();
		_currentExecList.Clear();
	}
	static ViDoubleLink2<ViAsynDelegateInterface> _asynExecList = new ViDoubleLink2<ViAsynDelegateInterface>();
	static ViDoubleLink2<ViAsynDelegateInterface> _currentExecList = new ViDoubleLink2<ViAsynDelegateInterface>();
	//
	public bool Active { get { return _node.IsAttach(); } }
	public void End()
	{
		_node.Data = null;
		_node.Detach();
	}

	protected void _AttachAsyn()
	{
		_node.Data = this;
		_asynExecList.PushBack(_node);
	}
	internal abstract void _AsynExec();
	ViDoubleLinkNode2<ViAsynDelegateInterface> _node = new ViDoubleLinkNode2<ViAsynDelegateInterface>();
}