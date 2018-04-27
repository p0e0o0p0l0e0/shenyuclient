using System;
using System.Collections.Generic;
using System.Text;
using RakNet;

using ViString = System.String;
using UInt8 = System.Byte;
using System.Net.Sockets;

public enum ViRakNetMessage
{
	INF = 134,
	IMMEDIATE_STREAM,
	CACHE_STREAM,
}

public class ViRakClient
{
	public static ViConstValue<Int32> VALUE_RakNetTimeOut = new ViConstValue<Int32>("RakNetTimeOut", 10 * 60 * 100);

	public ViDelegateAssisstant.Dele ConnectCallback = null;
	public ViDelegateAssisstant.Dele ConnectFailedCallback = null;
	public ViDelegateAssisstant.Dele DisconnectCallback = null;
	public ViDelegateAssisstant.Dele<ViIStream> ReceiveCallback = null;

	public ViOStream OS { get { return _OS; } }
	public RakPeerInterface Client { get { return _client; } }
	public Int32 SendCount { get { return _sendCount; } }
	public Int64 SendSize { get { return _sendSize; } }
	public Int32 ReceiveCount { get { return _receiveCount; } }
	public Int64 ReceiveSize { get { return _receiveSize; } }

	public bool IsConnected()
	{
		return _isConnected;
	}

	public void Connect(ViString kIP, UInt16 uiPort, ViString kPasspord)
	{
		_client.Connect(kIP, uiPort, kPasspord, kPasspord.Length);
	}

	public bool IsInited()
	{
		return _client != null;
	}

	public void Start()
	{
		_client = RakPeerInterface.GetInstance();
		SocketDescriptor sock = new SocketDescriptor();
		sock.socketFamily = 2;
		_client.Startup(1, sock, 1);
	}

	public void Close()
	{
		if (_client != null)
		{
			_client.Shutdown(300);
			RakNet.RakPeerInterface.DestroyInstance(_client);
			_client = null;
		}
	}

	public void Receive()
	{
		if (_client == null)
		{
			return;
		}
		//
		RakNet.Packet kPacket = _client.Receive();
		if (kPacket != null)
		{
			UInt8 packetIdentifier = GetPacketIdentifier(kPacket);
			switch ((DefaultMessageIDTypes)packetIdentifier)
			{
				case DefaultMessageIDTypes.ID_DISCONNECTION_NOTIFICATION:
					{
						ViDebuger.CritOK("ID_DISCONNECTION_NOTIFICATION");
						_client.DeallocatePacket(kPacket);
						OnDisconnect(kPacket);
					}
					break;
				case DefaultMessageIDTypes.ID_CONNECTION_ATTEMPT_FAILED:
					{
						ViDebuger.CritOK("ID_CONNECTION_ATTEMPT_FAILED");
						_client.DeallocatePacket(kPacket);
						OnAttamptFailed();
					}
					break;
				case DefaultMessageIDTypes.ID_CONNECTION_LOST:
					{
						ViDebuger.CritOK("ID_CONNECTION_LOST");
						_client.DeallocatePacket(kPacket);
						OnDisconnect(kPacket);
					}
					break;
				case DefaultMessageIDTypes.ID_CONNECTION_REQUEST_ACCEPTED:
					{
						ViDebuger.CritOK("ID_CONNECTION_REQUEST_ACCEPTED");
						_client.DeallocatePacket(kPacket);
						OnConnect(kPacket);
					}
					break;
				case (DefaultMessageIDTypes)ViRakNetMessage.IMMEDIATE_STREAM:
					{
						_IS.Init(kPacket.data, 1, (int)kPacket.length - 1);
						_client.DeallocatePacket(kPacket);
						//
						++_receiveCount;
						_receiveSize += _ISCache.RemainLength;
						//
						ViDelegateAssisstant.Invoke(ReceiveCallback, _IS);
					}
					break;
				case (DefaultMessageIDTypes)ViRakNetMessage.CACHE_STREAM:
					{
						_ISCache.Init(kPacket.data, 1, (int)kPacket.length - 1);
						_client.DeallocatePacket(kPacket);
						//
						++_receiveCount;
						_receiveSize += _ISCache.RemainLength;
						//
						while (_ISCache.RemainLength > 0)
						{
							_ISCache.TryRead(_IS);
							if (_IS.RemainLength > 0)
							{
								ViDelegateAssisstant.Invoke(ReceiveCallback, _IS);
							}
						}
					}
					break;
				default:
					{
						_client.DeallocatePacket(kPacket);
						ViStringBuilder log = new ViStringBuilder();
						log.Add("ViRakClient.UpdateStream(PacketHeadID=").Add(packetIdentifier).Add(")");
						ViDebuger.CritOK(log.Value);
					}
					break;
			}
		}
	}

	public void ResetSendStream()
	{
		OS.Reset();
		OS.Append(_signBytes);
	}

	public void WriteToCache()
	{
		UInt8 sign = OS.Sign((UInt32)_signBytes.Length, (UInt32)(OS.Length - _signBytes.Length));
		ViBitConverter.GetBytes(sign, _signBytes);
		OS._SetValue(0, _signBytes, _signBytes.Length);
		//
		_OSCache.Append(OS);
		OS.Reset();
	}

	static RakNet.BitStream RAK_STREAM = new RakNet.BitStream();
	public void SendCache()
	{
		if (_client == null)
		{
			return;
		}
		//
		if (_OSCache.Length > 0)
		{
			++_sendCount;
			_sendSize += _OSCache.Length;
			//
			RAK_STREAM.Reset();
			_ViStream2BitStream(_OSCache, RAK_STREAM, ViRakNetMessage.CACHE_STREAM);
			_client.Send(RAK_STREAM, PacketPriority.IMMEDIATE_PRIORITY, PacketReliability.RELIABLE_ORDERED, (char)0, RakNet.RakNet.UNASSIGNED_SYSTEM_ADDRESS, true);
			_OSCache.Reset();
		}
	}

	void _ViStream2BitStream(ViOStream oStream, RakNet.BitStream bitStream, ViRakNetMessage type)
	{
		bitStream.Write((byte)type);
		bitStream.Write(oStream.Cache, (uint)oStream.Length);
	}

	void OnConnect(Packet packet)
	{
		_isConnected = true;
		_guid = packet.guid;
		_client.SetTimeoutTime((UInt32)VALUE_RakNetTimeOut.Value, packet.systemAddress);
		ViDelegateAssisstant.Invoke(ConnectCallback);
	}

	void OnDisconnect(Packet packet)
	{
		_isConnected = false;
		ViDelegateAssisstant.Invoke(DisconnectCallback);
	}

	void OnAttamptFailed()
	{
		_isConnected = false;
		ViDelegateAssisstant.Invoke(ConnectFailedCallback);
	}

	private static byte GetPacketIdentifier(Packet packet)
	{
		if (packet == null)
		{
			return 255;
		}
		byte buf = packet.data[0];
		if (buf == (char)DefaultMessageIDTypes.ID_TIMESTAMP)
		{
			return (byte)packet.data[5];
		}
		else
		{
			return buf;
		}
	}

	ViOStream _OS = new ViOStream();
	ViOStream _OSCache = new ViOStream();
	byte[] _signBytes = new byte[1];
	ViIStream _IS = new ViIStream();
	ViIStream _ISCache = new ViIStream();
	RakPeerInterface _client;
	RakNetGUID _guid;
	bool _isConnected = false;
	Int32 _sendCount;
	Int64 _sendSize;
	Int32 _receiveCount;
	Int64 _receiveSize;

}

