using System;

public abstract class ViAsynExecer
{
	//+-------------------------------------------------------------------------------------------------------------------------------------------------------------
	public static UInt32 Count { get { return _list.Size; } }

	public static void UpdateAll(float deltaTime)
	{
		_list.BeginIterator();
		while (!_list.IsEnd())
		{
			ViRefNode2<ViAsynExecer> node = _list.CurrentNode;
			ViAsynExecer execer = node.Data;
			ViDebuger.AssertError<ViAsynExecer>(execer, "ViAsynLoader.UpdateAll() loader is null");
			_list.Next();
			if (execer.IsException)
			{
				Callback callback = execer.ExceptionCallback;
				execer.Clear();
				execer.OnException();
				if (callback != null)
				{
					callback(execer);
				}
			}
			if (!execer.IsLoaded)
			{
				execer.TryLoad();
			}
			if (execer.IsLoaded)
			{
				if (execer.DelayTime <= 0.0f)
				{
					Callback callback = execer.CompleteCallback;
					execer.Clear();
					execer.OnLoaded();
					if (callback != null)
					{
						callback(execer);
					}
				}
				else
				{
					execer.DelayTime -= deltaTime;
				}				
			}
		}
	}

	public static void ClearAll()
	{
		_list.BeginIterator();
		while (!_list.IsEnd())
		{
			ViRefNode2<ViAsynExecer> node = _list.CurrentNode;
			ViAsynExecer execer = node.Data;
			ViDebuger.AssertError<ViAsynExecer>(execer, "ViAsynExecer.ClearAll() loader is null");
			_list.Next();
			execer.Clear();
		}
		_list.Clear();
	}

	static ViRefList2<ViAsynExecer> _list = new ViRefList2<ViAsynExecer>();

	//+-------------------------------------------------------------------------------------------------------------------------------------------------------------

	public delegate void Callback(ViAsynExecer loader);
	public Callback CompleteCallback { get { return _completeCallback; } }
	public Callback ExceptionCallback { get { return _exceptionCallback; } }
	public virtual bool IsLoaded { get { return true; } }
	public virtual bool IsException { get { return _exception; } }
	public virtual float Progress { get { return 0.0f; } }
	public bool IsLoading { get { return _callbackNode.IsAttach(); } }
	public float DelayTime = 0.0f;

	public virtual void OnLoaded() { }
	public virtual void OnException() { }
	public virtual void TryLoad() { }

	public virtual void Detach()
	{
		Clear();
	}
	public void Attach()
	{
		Attach(null, null);
	}
	public void Attach(Callback completeCallback)
	{
		Attach(completeCallback, null);
	}
	public void Attach(Callback completeCallback, Callback exceptionCallback)
	{
		_exception = false;
		_completeCallback = completeCallback;
		_exceptionCallback = exceptionCallback;
		_callbackNode.Data = this;
		_list.Push(_callbackNode);
	}

	void Clear()
	{
		_callbackNode.Detach();
		_callbackNode.Data = null;
		_completeCallback = null;
		_exceptionCallback = null;
	}

	protected bool _exception = false;

	Callback _completeCallback;
	Callback _exceptionCallback;
	ViRefNode2<ViAsynExecer> _callbackNode = new ViRefNode2<ViAsynExecer>();
}
