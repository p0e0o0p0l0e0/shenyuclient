using System;

public class ViRPCResultExecerInterface
{
	public UInt64 ID { get { return _ID; } }
	public bool Active { get { return _attachNode.IsAttach(); } }

	protected void Attach(UInt64 ID, ViDoubleLink2<ViRPCResultExecerInterface> list)
	{
		_ID = ID;
		_attachNode.Data = this;
		list.PushBack(_attachNode);
	}

	public virtual void End()
	{
		_attachNode.Data = null;
		_attachNode.Detach();
	}

	public virtual void OnResult(ViIStream kIS) { }
	public virtual void OnException() { }

	UInt64 _ID;
	ViDoubleLinkNode2<ViRPCResultExecerInterface> _attachNode = new ViDoubleLinkNode2<ViRPCResultExecerInterface>();
}


public class ViRPCResultExecer<TResult> : ViRPCResultExecerInterface
{
	public delegate void DeleOnResult(bool exception, TResult result);
	public override void OnResult(ViIStream kIS)
	{
		ViSerializer<TResult>.Read(kIS, out _result);
		//
		Result(false, _result);
	}
	public override void OnException()
	{
		Result(true, default(TResult));
	}
	public override void End()
	{
		base.End();
		_result = default(TResult);
		_callback = null;
	}
	public void Start(DeleOnResult callback, UInt64 ID, ViDoubleLink2<ViRPCResultExecerInterface> list)
	{
		_callback = callback;
		Attach(ID, list);
	}
	void Result(bool exception, TResult result)
	{
		base.End();
		//
		DeleOnResult dele = _callback;
		_callback = null;
		if (dele != null)
		{
			dele(exception, result);
		}
	}

	TResult _result;
	DeleOnResult _callback;
}