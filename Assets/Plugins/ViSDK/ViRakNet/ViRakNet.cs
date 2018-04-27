using System;

using ViString = System.String;
using UInt8 = System.Byte;
using System.Net.Sockets;
using RakNet;

public class ViRakNet : ViNetInterface
{
	public ViDelegateAssisstant.Dele ConnectCallback = null;
	public ViDelegateAssisstant.Dele ConnectFailedCallback = null;
	public ViDelegateAssisstant.Dele DisconnectCallback = null;
	public ViDelegateAssisstant.Dele<ViIStream> ReceiveCallback = null;

	public Int32 SendCount { get { return _client.SendCount; } }
	public Int64 SendSize { get { return _client.SendSize; } }
	public Int32 ReceiveCount { get { return _client.ReceiveCount; } }
	public Int64 ReceiveSize { get { return _client.ReceiveSize; } }
	public ViOStream OS { get { return _client.OS; } }
	public void ResetSendStream()
	{
		_client.ResetSendStream();
	}

	public void SendStream()
	{
		_client.WriteToCache();
	}

	public void FreshSendCache()
	{
		_client.SendCache();
	}

	public void Connect(ViString IP, UInt16 port, ViString password)
	{
		_client.Connect(IP, port, password);
	}

	public bool IsInited()
	{
		return _client.IsInited();
	}

	public bool IsConnected()
	{
		return _client.IsConnected();
	}

	public void Start()
	{
		_client.Start();		
		_client.ConnectCallback = this._OnConnect;
		_client.ConnectFailedCallback = this._OnConnectFailed;
		_client.DisconnectCallback = this._OnDisconnect;
		_client.ReceiveCallback = this._OnReceive;
	}

	public void Close()
	{
		_client.Close();
		_client.ConnectCallback = null;
		_client.ConnectFailedCallback = null;
		_client.DisconnectCallback = null;
	}

	public void Receive()
	{
		_client.Receive();
	}

	void _OnConnectFailed()
	{
		ViDelegateAssisstant.Invoke(ConnectFailedCallback);
	}
	void _OnConnect()
	{
		ViDelegateAssisstant.Invoke(ConnectCallback);
	}
	void _OnDisconnect()
	{
		ViDelegateAssisstant.Invoke(DisconnectCallback);
	}
	void _OnReceive(ViIStream IS)
	{
		ViDelegateAssisstant.Invoke(ReceiveCallback, IS);
	}

	ViRakClient _client = new ViRakClient();
}

