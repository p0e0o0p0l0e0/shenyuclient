using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 巡逻
/// </summary>
public class LocalSpaceEntityAIAction_Patrol : LocalSpaceEntityAIActionInterface
{
    public LocalSpaceEntityAIAction_Patrol(LocalSpaceEntity self): base(self)  {}

    public override Int32 Type { get { return (int)LocalAIActionType.Patrol; } }

    public override bool Reset() { return true; }

	public override void OnActive()
	{
		_NextStep();
	}

	public override void OnDeactive()
	{
		_nextStepTimeNode.Detach();
	}
    
	float _MoveTo(ViVector3 pos)
	{
		float distance = ViRoute.GetLength(Self.Position, Self.MoveToPosList(Self.Position, pos));
		float duration = distance / Self.Physics.Speed.Value;
		return duration;
	}

	void _NextStep()
	{
		ViVector3 pos;
		Self.Navigator.RandomFreePos(Self.Position, 10.0f, out pos);
		float duration = _MoveTo(pos);
		ViTimerInstance.SetTime(_nextStepTimeNode, duration + 1.0f, this._OnNextStep);
	}

	ViTimeNode1 _nextStepTimeNode = new ViTimeNode1();
	void _OnNextStep(ViTimeNodeInterface node)
	{
		_NextStep();
	}
}
/// <summary>
/// 晕厥
/// </summary>
public class LocalSpaceEntityAIAction_Swoon : LocalSpaceEntityAIActionInterface
{
    public override Int32 Type { get { return (int)LocalAIActionType.Swoon; } }

    public LocalSpaceEntityAIAction_Swoon(LocalSpaceEntity self)	: base(self){}

	public override bool Reset(){if (Self.AI.Swoon.Value){   return true;   } else{  return false; }}
	public override void OnActive()
	{
		Self.OnBreakMove();
	}
}
/// <summary>
/// 跟随主角
/// </summary>
public class LocalSpaceEntityAIAction_Follow : LocalSpaceEntityAIActionInterface
{
    private float Distance = 3.5f;
    public override Int32 Type { get { return (int)LocalAIActionType.Follow; } }

    public LocalSpaceEntityAIAction_Follow(LocalSpaceEntity self) : base(self){}

    public override bool Reset() { return true; }

    public override void OnActive()
    {
        Distance = Self.FollowDistance;
        _NextStep();
    }

    public override void OnDeactive()
    {
        _nextStepTimeNode.Detach();
    }

    float _MoveTo(ViVector3 pos)
    {
        _distance = ViRoute.GetLength(Self.Position, Self.MoveToPosList(Self.Position, pos));
        _duration = _distance / Self.Physics.Speed.Value;
        return _duration;
    }
    private bool IsMove()
    {
        if (CellHero.LocalHero == null)
            return false;
        _distance = ViVector3.DistanceH(CellHero.LocalHero.Position, Self.Position);
        return _distance > Distance;
    }

    void _NextStep()
    {
        if (CellHero.LocalHero != null)
        {
            _pos = CellHero.LocalHero.Position;
        }
        if (IsMove())
        {
            _duration = _MoveTo(_pos);
            _time = (uint)(UnityEngine.Mathf.CeilToInt(_duration) * 100);
            _nextStepTimeNode.Start(ViTimerInstance.Timer, _time / 50, 50);
            _nextStepTimeNode.TickDelegate = _OnMoveTick;
            _nextStepTimeNode.EndDelegate = _OnEnd;
        }
        else
        {
            _nextStepTimeNode.Start(ViTimerInstance.Timer,1, 100);
            _nextStepTimeNode.TickDelegate = _OnEnd;
            _nextStepTimeNode.EndDelegate = _OnEnd;
        }
    }
    private void _OnMoveTick(ViTimeNodeInterface node)
    {
        if (!IsMove())
        {
            _nextStepTimeNode.Detach();
            Self.OnBreakMove();
            _NextStep();
        }
    }
    private void _OnEnd(ViTimeNodeInterface node)
    {
        _nextStepTimeNode.Detach();
        Self.OnBreakMove();
        _NextStep();
    }
    uint _time;
    float _duration;
    float _distance;
    ViVector3 _pos;
    ViTimeNode3 _nextStepTimeNode = new ViTimeNode3();
}
/// <summary>
/// 攻击主角的攻击目标
/// </summary>
public class LocalSpaceEntityAIAction_Attack : LocalSpaceEntityAIActionInterface
{
    private float Distance = 3;
    public override Int32 Type { get { return (int)LocalAIActionType.Attack; } }
    public LocalSpaceEntityAIAction_Attack(LocalSpaceEntity self)    : base(self)  { }
    public override bool Reset() { return true; }

    public override void OnActive()
    {
        Distance = UnityEngine.Random.Range(3, 6);
        _NextStep();
    }

    public override void OnDeactive()
    {
        _nextStepTimeNode.Detach();
        _nextStepTimeNode1.Detach();
    }
    private bool IsMove()
    {
        if (Self.FocusEntity == null)
            return false;
        _distance = ViVector3.DistanceH(Self.IsCurrentTargetPlayer() ? CellHero.LocalHero.Position : Self.FocusEntity.Position, Self.Position);
        return _distance > Distance;
    }
    float _MoveTo(ViVector3 pos)
    {
        _distance = ViRoute.GetLength(Self.Position, Self.MoveToPosList(Self.Position, pos));
        _duration = _distance / Self.Physics.Speed.Value;
        return _duration;
    }

    void _NextStep()
    {
        if (Self.FocusEntity == null)
        {
            ViTimerInstance.SetTime(_nextStepTimeNode1, 100, this._OnEnd);
        }
        else if (!Self.IsCurrentTargetPlayer() && !Self.IsAttackTarget(Self.FocusEntity))
        {
            ViTimerInstance.SetTime(_nextStepTimeNode1, 100, this._OnEnd);
        }
        else
        {
            if (IsMove())
            {
                _duration = _MoveTo(Self.IsCurrentTargetPlayer() ? CellHero.LocalHero.Position : Self.FocusEntity.Position);
                duration = (uint)(UnityEngine.Mathf.CeilToInt(_duration) * 100);
                _nextStepTimeNode.Start(ViTimerInstance.Timer, duration / 50, 50);
                _nextStepTimeNode.TickDelegate = _OnMoveTick;
                _nextStepTimeNode.EndDelegate = _OnMoveEnd;
            }
            else
            {
                duration = (uint)Self.AttackTarget(Self.IsCurrentTargetPlayer() ? CellHero.LocalHero : Self.FocusEntity,Self.GetCurrentSpellID());
                ViTimerInstance.SetTime(_nextStepTimeNode1, duration, this._OnEnd);
            }
        }
    }
    private void _OnMoveEnd(ViTimeNodeInterface node)
    {
        _nextStepTimeNode.Detach();
        Self.OnBreakMove();
        _NextStep();
    }
    private void _OnMoveTick(ViTimeNodeInterface node)
    {
        if (!IsMove())
        {
            _nextStepTimeNode.Detach();
            Self.OnBreakMove();
            _NextStep();
        }
    }
    private void _OnEnd(ViTimeNodeInterface node)
    {
        _nextStepTimeNode1.Detach();
        _NextStep();
    }
    uint duration;
    float _duration;
    float _distance;
    ViTimeNode1 _nextStepTimeNode1 = new ViTimeNode1();
    ViTimeNode3 _nextStepTimeNode = new ViTimeNode3();
}
/// <summary>
/// 空闲
/// </summary>
public class LocalSpaceEntityAIAction_Idle : LocalSpaceEntityAIActionInterface
{
    public override Int32 Type { get { return (int)LocalAIActionType.Idle; } }
    public LocalSpaceEntityAIAction_Idle(LocalSpaceEntity self) : base(self) { }

    public override bool Reset() { return true; }
    public override void OnActive()
    {
        Self.OnBreakMove();
    }
}
public enum LocalAIActionType
{
    Idle = 0,
    Patrol = 1,
    Swoon = 2,
    Follow = 3,
    Attack = 4,
}