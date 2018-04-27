using System;



public abstract class ViMouseHandlerInterface : ViDoubleLinkNode1<ViMouseHandlerInterface>
{
	public delegate void Callback();
	public Callback RawPressedCallback;
	public Callback RawReleasedCallback;
	public abstract bool AcceptMove { get; }
	public abstract bool Exclusive { get; }

	public virtual void End() { Detach(); }
	public virtual void OnPressed()
	{
		if (RawPressedCallback != null)
		{
			RawPressedCallback();
		}
	}
	public virtual void OnReleased()
	{
		if (RawReleasedCallback != null)
		{
			RawReleasedCallback();
		}
	}
	public virtual void OnMoved() { }
	public virtual void Reset() { }
	public virtual void Update() { }
}

public class ViMouseController
{
	public bool AcceptMove
	{
		get
		{
			ViMouseHandlerInterface handler = _GetTop();
			if (handler != null)
			{
				return handler.AcceptMove;
			}
			else
			{
				return false;
			}
		}
	}
	public bool Exclusive
	{
		get
		{
			ViMouseHandlerInterface handler = _GetTop();
			if (handler != null)
			{
				return handler.Exclusive;
			}
			else
			{
				return false;
			}
		}
	}
	public bool Pressed { get { return _pressed; } }

	public void AttachFront(ViMouseHandlerInterface handler)
	{
		_handlerList.PushFront(handler);
	}
	public void AttachBack(ViMouseHandlerInterface handler)
	{
		_handlerList.PushBack(handler);
	}
	public void OnPressed()
	{
		_updateExecer.Detach();
		//
		ViMouseHandlerInterface handler = _GetTop();
		_pressed = true;
		if (handler != null)
		{
			handler.OnPressed();
		}
	}
	public void OnReleased()
	{
		_updateExecer.Detach();
		//
		ViMouseHandlerInterface handler = _GetTop();
		_pressed = false;
		if (handler != null)
		{
			handler.OnReleased();
		}
	}
	public void OnMoved()
	{
		ViMouseHandlerInterface handler = _GetTop();
		if (handler != null)
		{
			handler.OnMoved();
		}
	}
	public void Clear()
	{
		_updateExecer.Detach();
		_handlerList.Clear();
	}
	public void ClearPress()
	{
		ViMouseHandlerInterface handler = _GetTop();
		if (handler != null)
		{
			handler.Reset();
		}
	}

	public void AsynUpdate()
	{
		_updateExecer.AsynExec(this.Update);
	}
	void Update() 
	{
		ViMouseHandlerInterface handler = _GetTop();
		_pressed = false;
		if (handler != null)
		{
			handler.Update();
		}
	}
	ViFramEndCallback0 _updateExecer = new ViFramEndCallback0();

	ViMouseHandlerInterface _GetTop()
	{
		if (_handlerList.IsNotEmpty())
		{
			return _handlerList.GetHead() as ViMouseHandlerInterface;
		}
		else
			return null;
	}

	bool _pressed = false;

	ViDoubleLink1<ViMouseHandlerInterface> _handlerList = new ViDoubleLink1<ViMouseHandlerInterface>();
}