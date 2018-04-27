using System;
using System.Collections.Generic;

public class LocalSpaceEntityAI
{
	public LocalSpaceEntity Self { get { return _self; } }
	public ViPriorityValue<bool> Swoon { get { return _swoon; } }
	public void Start(LocalSpaceEntity self)
	{
		_self = self;
		//
		_actionList.Register(new LocalSpaceEntityAIAction_Patrol(self));
		_actionList.Register(new LocalSpaceEntityAIAction_Swoon(self));
        _actionList.Register(new LocalSpaceEntityAIAction_Follow(self));
        _actionList.Register(new LocalSpaceEntityAIAction_Attack(self));
        _actionList.Register(new LocalSpaceEntityAIAction_Idle(self));
	}

	public void End()
	{
		_actionList.Clear();
		//
		_self = null;
	}

    public void SetAI(LocalAIActionType type)
    {
        _actionList.ChangeWeight((int)type);
    }

	public void Reset(bool breakSameState)
	{
		_actionList.Reset(breakSameState);
	}

    int HighWeight = 10;
	LocalSpaceEntity _self;
	ViActionStateList _actionList = new ViActionStateList();
	ViPriorityValue<bool> _swoon = new ViPriorityValue<bool>(false);
}