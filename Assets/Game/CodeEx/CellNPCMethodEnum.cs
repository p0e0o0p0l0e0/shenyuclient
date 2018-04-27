using System;

public enum CellNPCClientMethod
{
	INF = GameUnitClientMethod.SUP,
	METHOD_0_OnEnterSpaceComplete = INF,
	METHOD_1_OnFirstChase,
	METHOD_2_OnChaseStart,
	METHOD_3_OnFirstAttacked,
	METHOD_4_OnKilled,
	METHOD_5_OnKilled,
	METHOD_6_ShowExplore,
	SUP,
}
public enum CellNPCServerMethod
{
	INF = GameUnitServerMethod.SUP,
	METHOD_0_DelSelf = INF,
	METHOD_1_ResetAI,
	SUP,
}
