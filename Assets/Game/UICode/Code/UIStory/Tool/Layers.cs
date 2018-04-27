using UnityEngine;

/********************************************************************
	created:	2016/12/03
	created:	3:12:2016   16:56
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\Layers.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts
	file base:	Layers
	file ext:	cs
	author:		zlj
	
	purpose:	≤„º∂π‹¿Ì
*********************************************************************/

public static class Layers
{
    public static int Default = LayerMask.NameToLayer("Default");

    public static int UI = LayerMask.NameToLayer("UI");

    public static int Water = LayerMask.NameToLayer("Water");

    public static int Ground = LayerMask.NameToLayer("Ground");

    public static int GroundAlpha = LayerMask.NameToLayer("GroundAlpha");

    public static int Scene = LayerMask.NameToLayer("Scene");

    public static int SceneAlpha = LayerMask.NameToLayer("SceneAlpha");

    public static int Entity = LayerMask.NameToLayer("Entity");

    public static int EntityExplore = LayerMask.NameToLayer("EntityExplore");

    public static int EntityPick = LayerMask.NameToLayer("EntityPick");

    public static int Click = LayerMask.NameToLayer("Click");

    public static int Loot = LayerMask.NameToLayer("Loot");

    public static int CameraCollide = LayerMask.NameToLayer("CameraCollide");

    public static int EntityLow = LayerMask.NameToLayer("EntityLow");

    public static int UI_Invisible = LayerMask.NameToLayer("UI_Invisible"); 

    public static int UIModel = LayerMask.NameToLayer("UI_Model");

    public static int UIVideo = LayerMask.NameToLayer("UI_Video");

    public static int Story = LayerMask.NameToLayer("Story");

    public static int RTT_HERO = LayerMask.NameToLayer("RTT_HERO");

    public static int RTT_KanBanNiang = LayerMask.NameToLayer("RTT_KanBanNiang");

    public static int HDR = LayerMask.NameToLayer("HDR");

    public static void SetlayerRecursively(GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform tm in go.transform)
        {
            SetlayerRecursively(tm.gameObject, layer);
        }
    }
}