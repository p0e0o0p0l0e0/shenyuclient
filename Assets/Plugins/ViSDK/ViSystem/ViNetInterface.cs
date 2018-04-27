using System;

public interface ViNetInterface
{
	ViOStream OS { get; }
	void ResetSendStream();
	void SendStream();
}