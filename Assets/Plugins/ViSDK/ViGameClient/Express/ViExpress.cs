using System;

public class ViExpressInterface
{
	//+-------------------------------------------------------------------------------------------------------------------------------------------------------------
	public static void ClearAllExpress()
	{
		_allExpressList.BeginIterator();
		while (!_allExpressList.IsEnd())
		{
			ViExpressInterface express = _allExpressList.CurrentNode.Data;
			ViDebuger.AssertError(express);
			_allExpressList.Next();
			express.End();
		}
	}

	public static void ClearAllExpress<T>()
		where T : ViExpressInterface
	{
		_allExpressList.BeginIterator();
		while (!_allExpressList.IsEnd())
		{
			ViExpressInterface express = _allExpressList.CurrentNode.Data;
			ViDebuger.AssertError(express);
			_allExpressList.Next();
			T expressDerive = express as T;
			if (expressDerive != null)
			{
				expressDerive.End();
			}
		}
	}

	public static void UpdateAll(float deltaTime)
	{
		_allExpressList.BeginIterator();
		while (!_allExpressList.IsEnd())
		{
			ViExpressInterface express = _allExpressList.CurrentNode.Data;
			ViDebuger.AssertError(express);
			_allExpressList.Next();
			express.Update(deltaTime);
		}
	}

	static ViRefList2<ViExpressInterface> _allExpressList = new ViRefList2<ViExpressInterface>();

	//+-------------------------------------------------------------------------------------------------------------------------------------------------------------

	public ViExpressInterface()
	{
		_updateAttachNode.Data = this;
		_ownAttachNode.Data = this;
	}
	public virtual void Update(float deltaTime)
	{

	}
	public virtual void End()
	{
        // TODO:粒子特效不能立刻删除 需要处理发射器
		_updateAttachNode.Detach();
		_updateAttachNode.Data = this;
		_ownAttachNode.Detach();
		_ownAttachNode.Data = this;
	}
	//
	public void DetachUpdate()
	{
		_updateAttachNode.Detach();
	}
	public void AttachUpdate()
	{
		_allExpressList.Push(_updateAttachNode);
	}
	public void OwnedTo(ViRefList2<ViExpressInterface> list)
	{
		list.Push(_ownAttachNode);
	}

	//
	ViRefNode2<ViExpressInterface> _updateAttachNode = new ViRefNode2<ViExpressInterface>();
	ViRefNode2<ViExpressInterface> _ownAttachNode = new ViRefNode2<ViExpressInterface>();
	
}

public class ViExpressOwnList<TExpress>
	where TExpress : ViExpressInterface
{
	~ViExpressOwnList()
	{
		ViDebuger.AssertWarning(_expressList.Size == 0, "ViExpressOwnList is not clear");
	}
	public void End()
	{
		_expressList.BeginIterator();
		while (!_expressList.IsEnd())
		{
			ViExpressInterface express = _expressList.CurrentNode.Data;
			ViDebuger.AssertError(express);
			_expressList.Next();
			express.End();
		}
		ViDebuger.AssertWarning(_expressList.Size == 0, "ViExpressOwnList is not clear");
	}
	public void Add(TExpress express)
	{
		express.OwnedTo(_expressList);
	}	
	
	public ViRefList2<ViExpressInterface> List { get { return _expressList; } }

	ViRefList2<ViExpressInterface> _expressList = new ViRefList2<ViExpressInterface>();
}

public class ViDurationExpressController<TExpress>
	where TExpress : ViExpressInterface, new()
{
	public TExpress Express { get { return _express; } }
	public void SetDuration(float duration)
	{
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
	}
	public void End()
	{
		_express.End();
		_endTimeNode.Detach();
	}
	//
	void OnEndTime(ViTimeNodeInterface node)
	{
		End();
	}
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
	//
	TExpress _express = new TExpress();
}