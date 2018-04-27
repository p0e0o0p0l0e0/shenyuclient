using System;
using System.Collections.Generic;

public class LocalSpaceEntityAIActionInterface : ViActionState
{
    public override Int32 Weight { get { return _weight; } set { _weight = value; } }
    protected Int32 _weight = 0;

    public LocalSpaceEntityAIActionInterface(LocalSpaceEntity self)
	{
		_self = self;
	}

	public LocalSpaceEntity Self { get { return _self; } }

	public override void OnClear() 
	{
		_self = null;
	}

	LocalSpaceEntity _self;
}
