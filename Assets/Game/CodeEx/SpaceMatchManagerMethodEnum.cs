using System;

public enum SpaceMatchManagerClientMethod
{
	INF = 0,
	SUP = INF,
}
public enum SpaceMatchManagerServerMethod
{
	INF = 0,
	METHOD_0_SelectPVPMatch = INF,
	METHOD_1_SelectPVPMatch,
	METHOD_2_AddPVPMatcher,
	METHOD_3_AddPVPMatcher,
	METHOD_4_DelPVPMatcher,
	METHOD_5_SelectPVAMatch,
	METHOD_6_AddPVAMatcher,
	METHOD_7_DelPVAMatcher,
	METHOD_8_SelectPVEMatch,
	METHOD_9_AddPVEMatcher,
	METHOD_10_DelPVEMatcher,
	SUP,
}
