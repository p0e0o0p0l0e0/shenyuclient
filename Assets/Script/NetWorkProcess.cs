using System;
using System.Collections.Generic;

public class NetWorkProcess
{
	public static NetWorkProcess Instance { get { return _instacne; } }
	static NetWorkProcess _instacne = new NetWorkProcess();

	public ViRakNet Net { get { return _net; } }

	public void SetNet(ViRakNet Net)
	{
		lock (this)
		{
			_streamCache.Reset();
			//
			if (_thread != null)
			{
				_thread.Abort();
				_thread = null;
			}
			//
			_net = Net;
		}
	}

	public void Start()
	{
		if (_net == null)
		{
			return;
		}
		//
		lock (this)
		{
			_thread = new System.Threading.Thread(this._Update);
			_thread.Start();
			//
			_net.ReceiveCallback = this.SaveNetInput;
		}
	}

	public void End(ViDelegateAssisstant.Dele<ViIStream> processStreamCallback)
	{
		if (_net == null)
		{
			return;
		}
		//
		lock (this)
		{
			if (_thread != null)
			{
				_thread.Abort();
				_thread = null;
			}
			//
			if (processStreamCallback != null)
			{
				ViIStream totalStream = new ViIStream();
				totalStream.Init(_streamCache.Cache, 0, _streamCache.Length);
				ViIStream elementStream = new ViIStream();
				while (totalStream.RemainLength > 0)
				{
					totalStream.TryRead(elementStream);
					if (elementStream.RemainLength > 0)
					{
						ViDelegateAssisstant.Invoke(processStreamCallback, elementStream);
					}
				}
			}
			_streamCache.Reset();
			_net.ReceiveCallback = processStreamCallback;
		}
	}

	void _Update()
	{
		while (true)
		{
			UpdateNetReceive();
			//
			System.Threading.Thread.Sleep(300);
		}
	}

	public void UpdateNetReceive()
	{
		lock (this)
		{
			if (_net != null)
			{
				_net.Receive();
			}
		}
	}

	void SaveNetInput(ViIStream IS)
	{
		IS.AppendTo(_streamCache);
	}

	System.Threading.Thread _thread;
	ViRakNet _net;
	ViOStream _streamCache = new ViOStream(256 * 1024);
}
