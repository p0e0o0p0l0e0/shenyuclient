using System;

public class ViMouseHandler_1 : ViMouseHandlerInterface
{

	enum State
	{
		NONE,
		PRESSED,
		MOVING_START,
		MOVING,
	}

	public override bool AcceptMove { get { return IsPressing; } }
	public override bool Exclusive { get { return IsPressing; } }
	public bool IsMoving { get { return (_state == State.MOVING); } }
	public bool IsPressing { get { return (_state != State.NONE); } }
	public bool IsPressed { get { return (_state == State.PRESSED); } }
	public float EnterMovingStateTime { get { return _enterMovingStateTime; } set { _enterMovingStateTime = value; } }
	public float IgnoreMovingStateTime { get { return _ignoreMovingStateTime; } set { _ignoreMovingStateTime = value; } }
	public Callback MoveStartCallback;
	public Callback MovingCallback;
	public Callback MoveEndCallback;
	public Callback ReleasedCallback;

	public override void Reset()
	{
		if (_state == State.MOVING)
		{
			_OnMoveEnd();
		}
		_pressedEndNode.Detach();
		_allowMoveStartNode.Detach();
		_state = State.NONE;
	}
	public override void End()
	{
		base.End();
		MoveStartCallback = null;
		MovingCallback = null;
		MoveEndCallback = null;
		ReleasedCallback = null;
		_pressedEndNode.Detach();
		_allowMoveStartNode.Detach();
	}
	public override void Update()
	{
		if (_state == State.MOVING)
		{
			_OnMoveStart();
		}
	}

	public void EnterMove()
	{
		if (_state == State.MOVING)
		{
			return;
		}
		_state = State.MOVING;
		_pressedEndNode.Detach();
		_allowMoveStartNode.Detach();
		_OnMoveStart();
	}

	public void EnterMove(float delayTime)
	{
		ViTimerInstance.SetTime(_allowMoveStartNode, delayTime, this.OnAllowMoveStartTime);
		ViTimerInstance.SetTime(_pressedEndNode, EnterMovingStateTime, this.OnMoveTime);
	}

	public override void OnPressed()
	{
		base.OnPressed();
		if (_state == State.NONE)
		{
			_state = State.PRESSED;
			EnterMove(EnterMovingStateTime);
		}
	}
	public override void OnReleased()
	{
		base.OnReleased();
		if (_state == State.PRESSED)
		{
			_OnReleased();
		}
		if (_state == State.MOVING)
		{
			_OnMoveEnd();
		}
		_state = State.NONE;
		_pressedEndNode.Detach();
	}
	public override void OnMoved()
	{
		if (_state == State.PRESSED)
		{
			if (!_allowMoveStartNode.IsAttach())
			{
				_state = State.MOVING;
				_pressedEndNode.Detach();
				_OnMoveStart();
			}
		}
		else if (_state == State.MOVING)
		{
			_OnMoving();
		}
	}
	void OnMoveTime(ViTimeNodeInterface node)
	{
		ViDebuger.AssertWarning(_state == State.PRESSED);
		_state = State.MOVING;
		_OnMoveStart();
	}

	void OnAllowMoveStartTime(ViTimeNodeInterface node)
	{

	}
	void _OnMoveStart() { if (MoveStartCallback != null) { MoveStartCallback(); } }
	void _OnMoving() { if (MovingCallback != null) { MovingCallback(); } }
	void _OnMoveEnd() { if (MoveEndCallback != null) { MoveEndCallback(); } }
	void _OnReleased() { if (ReleasedCallback != null) { ReleasedCallback(); } }

	ViTimeNode1 _pressedEndNode = new ViTimeNode1();
	ViTimeNode1 _allowMoveStartNode = new ViTimeNode1();

	State _state;
	float _enterMovingStateTime = 0.3f;
	float _ignoreMovingStateTime = 0.06f;

}
