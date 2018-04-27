using System;
using System.Collections.Generic;

public class MailWatcher : ViReceiveDataArrayNodeWatcher<ReceiveDataMailProperty>
{
	public MailState State { get { return (MailState)Property.State.Value; } }
	public Int64 Time1970 { get { return Property.Time1970.Value; } }

	public override void OnStart(ReceiveDataMailProperty property, ViEntity entity)
	{
	}

	public override void OnUpdate(ReceiveDataMailProperty property, ViEntity entity)
	{
	}
	//
	public override void OnEnd(ReceiveDataMailProperty property, ViEntity entity)
	{
	
	}

}
