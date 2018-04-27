using System;

public class ViRPCResultDistributor
{
	public UInt64 Hook<TResult>(ViRPCResultExecer<TResult> execer, ViRPCResultExecer<TResult>.DeleOnResult callback)
	{
		++_IDMaker;
		execer.Start(callback, _IDMaker, _execerList);
		return _IDMaker;
	}

	public void Clear()
	{
		ViDoubleLinkNode2<ViRPCResultExecerInterface> iter = _execerList.GetHead();
		while (!_execerList.IsEnd(iter))
		{
			ViRPCResultExecerInterface execer = iter.Data;
			ViDoubleLink2<ViRPCResultExecerInterface>.Next(ref iter);
			execer.End();
		}
		ViDebuger.AssertWarning(_execerList.IsEmpty());
	}

	public void OnResult(UInt64 ID, ViIStream kIS)
	{
		ViDoubleLinkNode2<ViRPCResultExecerInterface> iter = _execerList.GetHead();
		while (!_execerList.IsEnd(iter))
		{
			ViRPCResultExecerInterface execer = iter.Data;
			ViDoubleLink2<ViRPCResultExecerInterface>.Next(ref iter);
			if (execer.ID == ID)
			{
				execer.OnResult(kIS);
				return;
			}
		}
		ViDebuger.Note("ViRPCResultDistributor: RPC Result is discarded");
	}

	public void OnException(UInt64 ID)
	{
		ViDoubleLinkNode2<ViRPCResultExecerInterface> iter = _execerList.GetHead();
		while (!_execerList.IsEnd(iter))
		{
			ViRPCResultExecerInterface execer = iter.Data;
			ViDoubleLink2<ViRPCResultExecerInterface>.Next(ref iter);
			if (execer.ID == ID)
			{
				execer.OnException();
				return;
			}
		}
		ViDebuger.Note("ViRPCResultDistributor: RPC Result is discarded");
	}

	ViDoubleLink2<ViRPCResultExecerInterface> _execerList = new ViDoubleLink2<ViRPCResultExecerInterface>();
	UInt64 _IDMaker;
}