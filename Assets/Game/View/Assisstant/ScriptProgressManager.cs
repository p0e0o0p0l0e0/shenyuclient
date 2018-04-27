using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScriptProgressManager
{
	struct NodeStruct
	{
		public bool Active { get { return Property.EndTime > ViTimerInstance.Time; } }
		public VisualProgressBarStruct Info;
		public ProgressProperty Property;
	}

	public void Add(UInt32 ID, ProgressProperty property)
	{
		NodeStruct node = new NodeStruct();
		node.Info = ViSealedDB<VisualProgressBarStruct>.Data(ID);
		node.Property = property;
		_list.Add(node);
	}

	public void Clear()
	{
		_list.Clear();
	}

	public void Del(UInt32 ID)
	{
		for (int iter = _list.Count - 1; iter >= 0; --iter)
		{
			NodeStruct iterNode = _list[iter];
			if (iterNode.Info.ID == ID)
			{
				_list.RemoveAt(iter);
			}
		}
	}

	public VisualProgressBarStruct Get(int mask, out ProgressProperty property)
	{
		property = new ProgressProperty();
		//
		Int32 maxWeight = Int32.MinValue;
		VisualProgressBarStruct info = null;
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			NodeStruct iterNode = _list[iter];
			if (!iterNode.Active)
			{
				continue;
			}
			if (ViMask32.HasAny(iterNode.Info.ProgressMask.Value, mask) && iterNode.Info.Weight > maxWeight)
			{
				property = iterNode.Property;
				info = iterNode.Info;
				maxWeight = iterNode.Info.Weight;
			}
		}
		return info;
	}

	List<NodeStruct> _list = new List<NodeStruct>();
}
