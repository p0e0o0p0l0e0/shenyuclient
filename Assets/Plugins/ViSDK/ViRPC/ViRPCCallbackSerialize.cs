using System;

public static class ViRPCCallbackSerializer
{
	public static bool Read<T>(ViIStream iStream, out ViRPCCallback<T> callback)
	{
		callback = new ViRPCCallback<T>();
		UInt64 CBID;
		if (!iStream.Read(out CBID))
		{
			return false;
		}
		callback.ID = CBID;
		return true;
	}
	public static bool Read<T>(ViStringIStream iStream, out ViRPCCallback<T> callback)
	{
		ViDebuger.Warning("ViRPCCallback: not stringlize");
		callback = new ViRPCCallback<T>();
		return false;
	}
	//
	public static void Append<T>(ViOStream IS, ViRPCCallback<T> value)
	{
		IS.Append(value.ID);
	}
}