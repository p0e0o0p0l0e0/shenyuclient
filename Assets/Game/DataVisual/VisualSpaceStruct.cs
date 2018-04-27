using System;


public class VisualSpaceStruct : ViSealedData
{
	public class CameraStruct
	{
		public ViEnum32<BoolValue> Override;
		public ViStaticArray<Int32> Yaw = new ViStaticArray<Int32>(3);
		public ViForeignKey<SpaceCameraStruct> Camera;
		public Int32 ShakeScale;
	}

	public enum SpaceFightViewMask
	{
		SCORE_PVP = 0x01,
		OPPONENT_HEROS = 0x02,
		TOP_RIGHT_MENU = 0x04,
		CHAT_CHANNEL = 0x08,
		DAMAGE_STATISTICS = 0X10,
		BOSS_HP = 0X20,
		SPACE_TIME = 0X40,
		SPACE_ENTITY_HINT = 0x80,
	}

	public enum VisualEntityHintMask
	{
		HP = 0x01,
		NAME = 0x02,
	}

	public bool OutputItem(UInt32 item, out int count)
	{
		for (int iter = 0; iter < OutputList.Length; ++iter)
		{
			ItemCountStruct iterCount = OutputList[iter];
			if (iterCount.IsEmpty())
			{
				continue;
			}
			if (iterCount.Item.Value == item)
			{
				count = iterCount.Count;
				return true;
			}
		}
		count = 0;
		return false;
	}

	public float GetCameraShakeScale()
	{
		if (Camera.ShakeScale == 0)
		{
			return 1.0f;
		}
		else
		{
			return Camera.ShakeScale * 0.01f;
		}
	}


    public VisualSpaceRegionStruct GetSpaceRegion(ViVector3 pos)
    {
        foreach(VisualSpaceRegionStruct region in SpaceRegions.List)
        {
            if(Math.Abs(region.CenterPostion.X - pos.x) < region.Height &&
                Math.Abs(region.CenterPostion.Y - pos.y) < region.Width) {
                return region;
            }
        }

        return null;
    }

    public string Icon;
	public string StoryIcon;
	public string Desc;
	public ViForeignKey<MusicStruct> Music;
	public string EntityEnterAnim;
	public ViForeignKey<PathFileResStruct> EntityEnterShow;
	public string EntityExitAnim;
	public ViEnum32<BoolValue> Reserve_0;
	public ViMask32<SpaceFightViewMask> FightViewMask;
	public ViEnum32<BoolValue> AutoAct;
	public CameraStruct Camera = new CameraStruct();
	public ViStaticArray<ItemCountStruct> VisualItemList = new ViStaticArray<ItemCountStruct>(10);
	public ViMask32<VisualEntityHintMask> HeroHint = new ViMask32<VisualEntityHintMask>();
	public ViMask32<VisualEntityHintMask> NPCHint = new ViMask32<VisualEntityHintMask>();
	public Int32 PosX;
	public Int32 PosY;
    public ViEnum32<BoolValue> IsShowBigMap;
    public ViEnum32<BoolValue> IsDirectionReverse;
    
    public Int32 MiniScale;
    public SpaceConfigStruct.AreaStruct VisualArea;
    public ViStaticArray<ItemCountStruct> OutputList = new ViStaticArray<ItemCountStruct>(10);
	public ViStaticArray<ViForeignKeyStruct<SimpleAvatarStruct>> WarmLoadAvatar = new ViStaticArray<ViForeignKeyStruct<SimpleAvatarStruct>>(10);
	public ViStaticArray<ViForeignKeyStruct<VisualSpellStruct>> WarmLoadSpell = new ViStaticArray<ViForeignKeyStruct<VisualSpellStruct>>(10);
	public ViStaticArray<ViForeignKeyStruct<ViVisualHitEffectStruct>> WarmLoadHitEffect = new ViStaticArray<ViForeignKeyStruct<ViVisualHitEffectStruct>>(10);
	public ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> WarmLoadResource = new ViStaticArray<ViForeignKeyStruct<PathFileResStruct>>(10);
    public ViForeignGroup<VisualSpaceRegionStruct> SpaceRegions = new ViForeignGroup<VisualSpaceRegionStruct>();
    public Int32 OffsetAngle;
    public Int32 DirectionAngle;
}

public class SpaceBirthControllerShowStruct : ViSealedData
{
	public ViForeignKey<PathFileResStruct> Res;
	public string Description;
	public ViForeignKey<ViCameraShakeStruct> EnterCameraShake;
	public ViForeignKey<ViCameraShakeStruct> ExitCameraShake;
}

public class VisualNPCBirthPositionStruct : ViSealedData
{
	public ViForeignKey<NPCEnterSpaceStruct> EnterSpace;
	public string EnterSpaceLine;
}
