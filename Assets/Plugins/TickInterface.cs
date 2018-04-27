using System;
using System.Collections.Generic;

public interface TickInterface
{
	void Update(float deltaTime);
}

public class TickManager
{
	public static void Update(float deltaTime)
	{
		ViDoubleLinkNode2<TickInterface> iter = _updateList.GetHead();
		while (!_updateList.IsEnd(iter))
		{
			TickInterface iterEntity = iter.Data;
			ViDoubleLink2<TickInterface>.Next(ref iter);
			//
			iterEntity.Update(deltaTime);
		}
	}
	public static void UpdateFix(float deltaTime)
	{
		ViDoubleLinkNode2<TickInterface> iter = _fixedUpdateList.GetHead();
		while (!_fixedUpdateList.IsEnd(iter))
		{
			TickInterface iterEntity = iter.Data;
			ViDoubleLink2<TickInterface>.Next(ref iter);
			//
			iterEntity.Update(deltaTime);
		}
	}
	static ViDoubleLink2<TickInterface> _updateList = new ViDoubleLink2<TickInterface>();
	static ViDoubleLink2<TickInterface> _fixedUpdateList = new ViDoubleLink2<TickInterface>();

	public static void PushBack(ViDoubleLinkNode2<TickInterface> node, TickInterface obj, bool fixedUpdate)
	{
		node.Data = obj;
		if (fixedUpdate)
		{
			_fixedUpdateList.PushBack(node);
		}
		else
		{
			_updateList.PushBack(node);
		}
	}

	public static void Detach(ViDoubleLinkNode2<TickInterface> node)
	{
		node.Data = null;
		node.Detach();
	}
}

