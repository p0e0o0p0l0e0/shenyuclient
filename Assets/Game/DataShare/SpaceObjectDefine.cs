using System;

public enum SpaceObjectType
{
	DEFAULT,
	TRIGGER,
    COLLECT,
    LOADNPC,
    ENTERCENTER,
    ENTERSTORYMODEL,
    TOTAL,
}
public enum SpaceObjectState
{
	LIVE,
	DEAD,
}

public enum SpaceObjectTransportType
{
	NONE,
	TRANPORT,
	JUMP,
    SPACE_TELEPORT,
}