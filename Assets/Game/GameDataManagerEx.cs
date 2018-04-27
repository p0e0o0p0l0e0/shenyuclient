using System;
using System.Collections.Generic;


public static class GameDataManagerEx
{
	public static void Initialize()
	{

        foreach (SpaceBirthControllerStruct pSpaceBirthControllerStruct in ViSealedDB<SpaceBirthControllerStruct>.Array)
        {
            // space struct
            pSpaceBirthControllerStruct.Start();
        }
        foreach (NPCBirthPositionStruct pNPCBirthPositionStruct in ViSealedDB<NPCBirthPositionStruct>.Array)
        {
            // space struct SpaceBirthControllerStruct
            pNPCBirthPositionStruct.Start();
        }
        foreach (SpaceObjectBirthPositionStruct pSpaceObjectBirthPositionStruct in ViSealedDB<SpaceObjectBirthPositionStruct>.Array)
        {
            // space struct SpaceBirthControllerStruct
            pSpaceObjectBirthPositionStruct.Start();
        }
        foreach (SpaceAuraBirthPositionStruct pSpaceAuraBirthPositionStruct in ViSealedDB<SpaceAuraBirthPositionStruct>.Array)
        {
            pSpaceAuraBirthPositionStruct.Start();
        }

        foreach(VisualSpaceRegionStruct pVisualSpaceRegionStruct in ViSealedDB<VisualSpaceRegionStruct>.Array)
        {
            pVisualSpaceRegionStruct.Start();
        }
    }

}