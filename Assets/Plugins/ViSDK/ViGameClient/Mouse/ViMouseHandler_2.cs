using System;



public class ViMouseHandler_2: ViMouseHandlerInterface
{
	enum State
	{
		NONE,
		MOVING,
	}

	public override bool AcceptMove { get { return IsPressing; } }
	public override bool Exclusive { get { return IsPressing; } }
	public bool IsMoving { get { return (_state == State.MOVING); } }
	public bool IsPressing { get { return (_state != State.NONE); } }
	
	public Callback MoveStartCallback;
	public Callback MovingCallback;
	public Callback MoveEndCallback;

	public override void End()
	{
		base.End();
		MoveStartCallback = null;
		MovingCallback = null;
		MoveEndCallback = null;
	}

	public override void Reset()
	{
		if (_state == State.MOVING)
		{
			_state = State.NONE;
			_OnMoveEnd();
		}
	}

	public override void OnPressed()
	{
		base.OnPressed();
		if (_state == State.NONE)
		{
			_state = State.MOVING;
			_OnMoveStart();
		}
	}
	public override void OnReleased()
	{
		base.OnReleased();
		if (_state == State.MOVING)
		{
			_state = State.NONE;
			_OnMoveEnd();
		}
	}
	public override void OnMoved()
	{
		if (_state == State.MOVING)
		{
			_OnMoving();
		}
	}
	
	void _OnMoveStart() { if (MoveStartCallback != null) { MoveStartCallback(); } }
	void _OnMoving() { if (MovingCallback != null) { MovingCallback(); } }
	void _OnMoveEnd() { if (MoveEndCallback != null) { MoveEndCallback(); } }

	State _state;
}