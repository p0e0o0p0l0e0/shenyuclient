using System;


public class ViMouseHandler_3 : ViMouseHandlerInterface
{
	enum State
	{
		NONE,
		PRESSING,
	}

	public override bool AcceptMove { get { return IsPressing; } }
	public override bool Exclusive { get { return IsPressing; } }
	public bool IsPressing { get { return (_state != State.NONE); } }

	public Callback PressedCallback;
	public Callback ReleasedCallback;

	public override void End()
	{
		base.End();
		PressedCallback = null;
		ReleasedCallback = null;
	}


	public override void Reset()
	{
		if (_state == State.PRESSING)
		{
			_OnReleased();
		}
		_state = State.NONE;
	}

	public override void OnPressed()
	{
		base.OnPressed();
		if (_state == State.NONE)
		{
			_state = State.PRESSING;
			_OnPressed();
		}
	}
	public override void OnReleased()
	{
		base.OnReleased();
		if (_state == State.PRESSING)
		{
			_state = State.NONE;
			_OnReleased();
		}
	}
	public override void OnMoved()
	{

	}

	void _OnPressed() { if (PressedCallback != null) { PressedCallback(); } }
	void _OnReleased() { if (ReleasedCallback != null) { ReleasedCallback(); } }

	State _state;
}