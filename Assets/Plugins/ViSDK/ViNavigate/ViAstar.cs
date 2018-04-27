using System;
using System.Collections.Generic;


public enum ViAstarStepState
{
	NONE,
	OPEN,
	CLOSE,
}

public struct ViAstarRoundStep
{
	public ViAstarStep node;
	public float cost;
}

public struct ViAStarPos
{
	public int x;
	public int y;
}

public class ViAstarStep : ViHeapNode
{
	public static ViAstarStep EMPTY = new ViAstarStep();
	public static Int32 RoundCapibility = 8;
	public ViAstarStep Parent { get { return _parent; } set { _parent = value; } }
	public ViDoubleLinkNode2<ViAstarStep> AttachNode
	{
		get
		{
			if (_attachNode == null)
			{
				_attachNode = new ViDoubleLinkNode2<ViAstarStep>();
				_attachNode.Data = this;
			}
			return _attachNode;
		}
	}
	public ViAstarRoundStep[] RoundSteps { get { return _roundNodeList; } }
	public bool IsOpen { get { return (State == ViAstarStepState.OPEN); } }
	public bool IsClose { get { return (State == ViAstarStepState.CLOSE); } }
	public ViAstarStepState State = ViAstarStepState.NONE;
	public float G;
	public float H;

	public ViAStarPos Pos;
	public Int32 Cost = 0;

	public static float Distance(ViAstarStep from, ViAstarStep to)
	{
		float deltaX = from.Pos.x - to.Pos.x;
		float deltaY = from.Pos.y - to.Pos.y;
		return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
	}

	public ViAstarStep()
	{
		
	}

	public void Reset()
	{
		G = 0;
		_parent = null;
		State = ViAstarStepState.NONE;
	}

	public void SetRound(List<ViAstarRoundStep> list)
	{
		if (list.Count <= 0)
		{
			_roundNodeList = null;
		}
		else
		{
			_roundNodeList = new ViAstarRoundStep[list.Count];
			list.CopyTo(_roundNodeList);
		}
	}

	ViAstarRoundStep[] _roundNodeList;
	ViAstarStep _parent;
	ViDoubleLinkNode2<ViAstarStep> _attachNode;
}

public class ViAstarDestChecker
{
	public virtual bool IsDest(ViAstarStep kStep)
	{
		return true;
	}
}

public class ViAstarStepDynamicCostArray
{
	public virtual Int32 Value(ViAstarStep kStep)
	{
		return 0;
	}
}

public class ViAstar<TDestChecker, VTStepDynamicCostArray> 
	where TDestChecker : ViAstarDestChecker
	where VTStepDynamicCostArray : ViAstarStepDynamicCostArray
{
	public UInt32 StepCnt { get { return _stepCnt; } }
	public UInt32 MaxStepCnt { get { return _maxStepCnt; } set { _maxStepCnt = value; } }
	public TDestChecker DestChecker;
	public VTStepDynamicCostArray StepDynamicCostArray;

	public ViAstar(UInt32 heapSize)
	{
		_openHeap = new ViMinHeap<ViAstarStep>(heapSize);
	}

	public void Clear()
	{
		_startStep = null;
		_destStep = null;
		_currentStep = null;
		_bestStep = null;
		_openHeap.Clear();
		_openList.Clear();
		_closeList.Clear();
	}

	public bool Search(ViAstarStep src, ViAstarStep dest, Int32 costSup)
	{
		ViDebuger.AssertWarning(src.Cost == 0.0f);
		src.G = 0;
		src.H = ViAstarStep.Distance(src, dest);
		src.Key = src.G + src.H;
		//
		_startStep = src;
		_bestStep = src;
		_startStep.Reset();
		_destStep = dest;
		//
		_stepCnt = 0;
		//
		_AddToOpen(src);
		//
		while (_openHeap.Size > 0)
		{
			_currentStep = _openHeap.Pop();
			ViDebuger.AssertError(_currentStep);
			if (DestChecker.IsDest(_currentStep))
			{
				_bestStep = _currentStep;
				return true;
			}
			if (_stepCnt > _maxStepCnt)
			{
				return false;
			}
			if (_currentStep.H < _bestStep.H)
			{
				_bestStep = _currentStep;
			}
			++_stepCnt;
			ViDebuger.AssertError(_currentStep.IsOpen);
			_NewStep(_currentStep, costSup);
			_currentStep.AttachNode.Detach();
			_AddToClose(_currentStep);
		}
		return false;
	}
	//while (true)
	//{
	//    ViAstarStep fromStep = next;
	//    next = next.Parent;
	//    if (next != null)
	//    {
	//        ViAstarStep toStep = next;
	//        int deltaX = toStep.Pos.x - fromStep.Pos.x + 1;
	//        int deltaY = (toStep.Pos.y - fromStep.Pos.y + 1) << 2;
	//        int delta = deltaY + deltaX;
	//        if (delta != dir)
	//        {
	//            _stepCache.Insert(0, fromStep);
	//            dir = delta;
	//        }
	//    }
	//    else
	//    {
	//        _stepCache.Insert(0, fromStep);
	//        break;
	//    }
	//}
	static List<ViAstarStep> _stepCache = new List<ViAstarStep>();
	public void MakeRoute(List<ViAstarStep> steps, Int32 costSup, out bool costBlocked)
	{
		costBlocked = false;
		_stepCache.Clear();
		for (ViAstarStep iter = _bestStep; iter != null; iter = iter.Parent)
		{
			_stepCache.Insert(0, iter);
		}
		if (_stepCache.Count == 0)
		{
			return;
		}
		int dir = 1 + (1 << 2);
		ViAstarStep preStep = _stepCache[0];
		if (preStep.Cost > costSup)
		{
			costBlocked = true;
			return;
		}
		//
		for (int iter = 1; iter < _stepCache.Count - 1; ++iter)
		{
			ViAstarStep nextStep = _stepCache[iter];
			if (nextStep.Cost > costSup)
			{
				costBlocked = true;
				steps.Add(preStep);
				break;
			}
			int deltaX = nextStep.Pos.x - preStep.Pos.x + 1;
			int deltaY = (nextStep.Pos.y - preStep.Pos.y + 1) << 2;
			int delta = deltaY + deltaX;
			if (delta != dir)
			{
				steps.Add(preStep);
				dir = delta;
			}
			preStep = nextStep;
		}
		if (!costBlocked)
		{
			steps.Add(_stepCache[_stepCache.Count - 1]);
		}
	}

	public void Reset()
	{
		ViDoubleLinkNode2<ViAstarStep> iter = _openList.GetHead();
		while (!_openList.IsEnd(iter))
		{
			iter.Data.Reset();
			ViDoubleLink2<ViAstarStep>.Next(ref iter);
		}
		_openList.Clear();
		//
		iter = _closeList.GetHead();
		while (!_closeList.IsEnd(iter))
		{
			iter.Data.Reset();
			ViDoubleLink2<ViAstarStep>.Next(ref iter);
		}
		_closeList.Clear();
		//
		_openHeap.Clear();
	}

	void _NewStep(ViAstarStep step, Int32 costSup)
	{
		if (step.RoundSteps == null)
		{
			return;
		}
		//
		for (Int32 iter = 0; iter < step.RoundSteps.Length; ++iter)
		{
			ViAstarRoundStep iterRoundStep = step.RoundSteps[iter];
			ViDebuger.AssertError(iterRoundStep.node);
			ViAstarStep iterStep = iterRoundStep.node;
			if (iterStep.IsClose)
			{
				continue;
			}
			if (iterStep.Cost > costSup)
			{
				continue;
			}
			float iterNewG = iterRoundStep.cost + step.G + StepDynamicCostArray.Value(iterStep);
			if (iterStep.IsOpen)
			{
				if (iterStep.G > iterNewG)
				{
					iterStep.G = iterNewG;
					iterStep.Key = iterStep.G + iterStep.H;
					iterStep.Parent = step;
				}
			}
			else
			{
				iterStep.G = iterNewG;
				iterStep.H = ViAstarStep.Distance(iterStep, _destStep);
				iterStep.Key = iterStep.G + iterStep.H;
				iterStep.Parent = step;
				_AddToOpen(iterStep);
			}
		}
	}

	void _AddToOpen(ViAstarStep step)
	{
		_openList.PushBack(step.AttachNode);
		step.State = ViAstarStepState.OPEN;
		_openHeap.Push(step);
	}
	void _AddToClose(ViAstarStep step)
	{
		step.State = ViAstarStepState.CLOSE;
		_closeList.PushBack(step.AttachNode);
	}

	UInt32 _stepCnt;
	UInt32 _maxStepCnt = 10000;

	ViAstarStep _startStep;
	ViAstarStep _destStep;
	ViAstarStep _currentStep;
	ViAstarStep _bestStep;

	ViMinHeap<ViAstarStep> _openHeap;
	ViDoubleLink2<ViAstarStep> _openList = new ViDoubleLink2<ViAstarStep>();
	ViDoubleLink2<ViAstarStep> _closeList = new ViDoubleLink2<ViAstarStep>();

}