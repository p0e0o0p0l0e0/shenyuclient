using System;
using System.Collections.Generic;

using UInt8 = System.Byte;

public class ViRPCInvoker
{
	public delegate void DeleMessage(ViEntity entity, UInt16 funcID);
	public DeleMessage PreMessageCallback;
	public DeleMessage AftMessageCallback;
	//
	public ViOStream OS { get { return _net.OS; } }
	public ViEntityACK ACK { get { return _ACK; } }
	public ViRPCResultDistributor ResultDistributor { get { return _resultDistributor; } }
	public bool Active { get { return _net != null; } }
	//

	public void Start(ViNetInterface net, ViRPCResultDistributor resultDistributor, ViRPCLicence licence)
	{
		_net = net;
		_resultDistributor = resultDistributor;
		_licence = licence;
	}

	public void End()
	{
		if (_resultDistributor != null)
		{
			_resultDistributor.Clear();
		}
		_net = null;
	}

	public void SendMessage()
	{
		ViDebuger.AssertWarning(_net);
		ViDebuger.AssertWarning(!_licence.Error);
		if (!_licence.Error && _net != null)
		{
			_net.SendStream();
		}
	}
	public void ResetSendStream()
	{
		ViDebuger.AssertWarning(_net);
		if (_net != null)
		{
			_net.ResetSendStream();
			OS.Append(_licence.Create());
		}
	}

	public void PreMessage(ViEntity entity, UInt16 funcID)
	{
		if (PreMessageCallback != null)
		{
			PreMessageCallback(entity, funcID);
		}
	}

	public void AftMessage(ViEntity entity, UInt16 funcID)
	{
		if (AftMessageCallback != null)
		{
			AftMessageCallback(entity, funcID);
		}
	}

	ViEntityACK _ACK = new ViEntityACK();
	ViNetInterface _net;
	ViRPCResultDistributor _resultDistributor;
	ViRPCLicence _licence;
}


public interface ViRPCEntity : ViEntity
{
	ViRPCInvoker RPC { get; }
}


public static class ViRPCEntityAssisstant
{
	public static ViRPCInvoker GetInvokerRPC(ViRPCEntity entity, UInt16 funcID)
	{
		if (!entity.RPC.Active)
		{
			return null;
		}
		if (entity.RPC.ACK.Has(funcID))
		{
			ViDebuger.Note("Sorry, the Net is busy, please waiting for a moment!");
			return null;
		}
		//
		return entity.RPC;
	}
}