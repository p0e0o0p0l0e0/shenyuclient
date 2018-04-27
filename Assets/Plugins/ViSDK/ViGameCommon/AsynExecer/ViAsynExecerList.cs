using System;
using System.Collections.Generic;

public class ViAsynExecerList: ViAsynExecer
{
	public override bool IsLoaded
	{
		get
		{
			for (int iter = 0; iter < _list.Count; ++iter)
			{
				ViAsynExecer iterLoader = _list[iter];
				if (iterLoader.IsLoading)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override float Progress
	{
		get
		{
			if (_list.Count == 0)
			{
				return 1.0f;
			}
			float current = 0.0f;
			float total = 0.0f;
			for (int iter = 0; iter < _list.Count; ++iter )
			{
				ViAsynExecer iterLoader = _list[iter];
				current += iterLoader.Progress;
				total += 1.0f;
			}
			return current / total;
		}
	}
	public void Add(ViAsynExecer loader)
	{
		_list.Add(loader);
	}
	public void Del(ViAsynExecer loader)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			ViAsynExecer iterLoader = _list[iter];
			if (iterLoader == loader)
			{
				loader.Detach();
				_list.Remove(iterLoader);
				break;
			}
		}
	}
	public new void Detach()
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			ViAsynExecer iterLoader = _list[iter];
			iterLoader.Detach();
		}
		_list.Clear();
		//
		base.Detach();
	}

	List<ViAsynExecer> _list = new List<ViAsynExecer>();

}