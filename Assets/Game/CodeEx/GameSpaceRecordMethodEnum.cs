using System;

public enum GameSpaceRecordClientMethod
{
	INF = 0,
	METHOD_0_OnResult = INF,
	METHOD_1_OnEvent,
	METHOD_2_OnEvent,
	METHOD_3_OnControllerStart,
	METHOD_4_OnControllerEnd,
	METHOD_5_OnControllerBorn,
	METHOD_6_OnControllerFactionStart,
	METHOD_7_OnControllerFactionEnd,
	METHOD_8_OnControllerFactionRevert,
	METHOD_9_UIEvent,
	METHOD_10_UIEvent,
	SUP,
}
public enum GameSpaceRecordServerMethod
{
	INF = 0,
	METHOD_0_SetExitable = INF,
	METHOD_1_SetMemberCountSup,
	SUP,
}
