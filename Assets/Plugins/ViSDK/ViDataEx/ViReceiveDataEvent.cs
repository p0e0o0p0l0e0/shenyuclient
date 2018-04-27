using System;

using UInt8 = System.Byte;



public class ViReceiveDataEvent : ViReceiveDataNode
{
	public override void OnUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		if (MatchChannel(channel))
		{
			OnUpdateInvoke();
		}
	}

	public new void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		if (MatchChannel(channelMask))
		{
			
		}
	}
}
public static class ViReceiveDataEventSerialize
{
	public static void Append(ViOStream OS, ViReceiveDataEvent value)
	{
		ViDebuger.Error("");
	}
}