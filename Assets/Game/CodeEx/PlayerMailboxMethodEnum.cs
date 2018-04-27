using System;

public enum PlayerMailboxClientMethod
{
	INF = PlayerComponentClientMethod.SUP,
	SUP = INF,
}
public enum PlayerMailboxServerMethod
{
	INF = PlayerComponentServerMethod.SUP,
	METHOD_0_RecordMailTarget = INF,
	SUP,
}
