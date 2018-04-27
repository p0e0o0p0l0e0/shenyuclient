using System;

public enum CellRecordClientMethod
{
	INF = 0,
	SUP = INF,
}
public enum CellRecordServerMethod
{
	INF = 0,
	METHOD_0_Exec = INF,
	METHOD_1_FindEntityPackID,
	METHOD_2_SetCellPlayerExecReqFunc,
	METHOD_3_SetCellHeroExecReqFunc,
	METHOD_4_ClearRPCExecCount,
	METHOD_5_OnPingFromCenter,
	METHOD_6_AsynInvoke,
	METHOD_7_ResetConstValue,
	METHOD_8_ResetGameData,
	METHOD_9_ResetGameData,
	METHOD_10_ResetGameData,
	METHOD_11_SetConstBool,
	METHOD_12_SetConstBools,
	METHOD_13_SetConstInt,
	METHOD_14_SetConstInts,
	METHOD_15_SetConstFloat,
	METHOD_16_SetConstFloats,
	METHOD_17_SetConstString,
	METHOD_18_SetConstStrings,
	METHOD_19_SetConstVector3,
	METHOD_20_SetConstVector3s,
	METHOD_21_SetLogLevel,
	METHOD_22_SetLogLevel,
	METHOD_23_ResetReserveWord,
	METHOD_24_AddReserveWord,
	METHOD_25_CreateSpace,
	METHOD_26_CreateSpace,
	METHOD_27_DestroySpace,
	METHOD_28_ResultSmallSpace,
	METHOD_29_EventSpace,
	METHOD_30_UpdateSmallSpaceProperty,
	METHOD_31_AddSpaceFakePlayer,
	SUP,
}
