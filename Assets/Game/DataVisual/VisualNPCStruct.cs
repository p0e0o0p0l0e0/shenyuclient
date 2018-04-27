using System;
using System.Collections.Generic;

public struct AvatarBodyResourceStruct
{
	public ViForeignKey<PathFileResStruct> Resource;
	public string MoveMixNode;
	public Int32 AnimationSpeed;
	public Int32 HeightOffset;
}

public struct VisualNPCMoveSpeedStruct
{
	public Int32 RunStandardSpeed;
	public Int32 BattleRunStandardSpeed;
	public Int32 RotateSpeed;
}

public class RTTStruct : ViSealedData
{
	public ViVector3Struct CameraPos;
	public ViVector3Struct CameraOri;
	public ViVector3Struct AvatarPos;
	public ViVector3Struct AvatarOri;
	public Int32 AvatarScale;
	public ViForeignKey<PathFileResStruct> StageRes;
}

public class SimpleAvatarStruct : ViSealedData
{
	public static readonly UInt32 ANIM_COUNT = 5;
	public float AnimSpeed
	{
		get
		{
			if (BodyResource.AnimationSpeed == 0)
			{
				return 1.0f;
			}
			else
			{
				return BodyResource.AnimationSpeed * 0.01f;
			}
		}
	}
	public float GetBodyWeight()
	{
		if (BodyWeight == 0)
		{
			return 1.0f;
		}
		else
		{
			return BodyWeight * 0.01f;
		}
	}
	public float GetBodyHeight()
	{
		if (BodyHeight == 0)
		{
			return 2.0f;
		}
		else
		{
			return BodyHeight * 0.01f;
		}
	}
	public float GetScale()
	{
		if (Scale == 0)
		{
			return 1.0f;
		}
		else
		{
			return Scale * 0.01f;
		}
	}
	public float GetRunStandardSpeed()
	{
		if (Speed.RunStandardSpeed == 0)
		{
			return 4.0f;
		}
		else
		{
			return ViMathDefine.Max(1.0f, Speed.RunStandardSpeed * 0.01f / GetScale());
		}
	}
	public float GetBattleRunStandardSpeed()
	{
		if (Speed.BattleRunStandardSpeed == 0)
		{
			return 4.0f;
		}
		else
		{
			return ViMathDefine.Max(1.0f, Speed.BattleRunStandardSpeed * 0.01f / GetScale());
		}
	}
	public float GetRotateSpeed()
	{
		if (Speed.RotateSpeed == 0)
		{
			return 10.0f;
		}
		else
		{
			return ViMathDefine.Max(3.0f, Speed.RotateSpeed * 0.01f / GetScale());
		}
	}

    public float GetPartScale()
    {
        return 1.0f;
    }

	public VisualNPCMoveSpeedStruct Speed;
	public AvatarBodyResourceStruct BodyResource;
	public ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> PartResource = new ViStaticArray<ViForeignKeyStruct<PathFileResStruct>>(3);
	public Int32 BodyWeight;
	public Int32 BodyHeight;
	public Int32 BodyDrag;
	public Int32 Scale;
	public string Icon;
	public string Photo;
	public ViForeignKey<PathFileResStruct> HitSound;
	public Int32 HitSoundProbability;
	public ViForeignKey<PathFileResStruct> AttackSound;
	public Int32 AttackSoundProbability;
	public Int32 AttackSoundDelay;
	public ViForeignKey<RTTStruct> RTT;
	public ViForeignKey<GraphicsLevelStruct> LODLowLevel;
}

public class VisualNPCShowStruct : ViSealedData
{
	public ViEnum32<AvatarAttachNode> SpacePosition;
	public ViForeignKey<PathFileResStruct> SpaceRes;
	public ViEnum32<AvatarAttachNode> BodyPosition;
	public ViForeignKey<PathFileResStruct> BodyRes;
	public ViForeignKey<ViCameraShakeStruct> CameraShake;
	public Int32 CameraShakeDelay;
	public ViForeignKey<PathFileResStruct> Sound;
	public string Anim;
}

public class VisualNPCStruct : ViSealedData
{
	public float GetBodyScale()
	{
		if (BodyScale == 0)
		{
			return 1.0f * Avatar.Data.GetScale();
		}
		else
		{
			return BodyScale * 0.01f * Avatar.Data.GetScale();
		}
	}
	public float GetBodyWeight()
	{
		return Avatar.Data.GetBodyWeight() * GetBodyScale();
	}
	public float GetBodyHeight()
	{
		return Avatar.Data.GetBodyHeight() * GetBodyScale();
	}
	public float GetAttackColorizeScale()
	{
		if (AttackedColorizeScale == 0)
		{
			return 1.0f;
		}
		else
		{
			return AttackedColorizeScale * 0.01f;
		}
	}
	//
	public string Description;
	public Int32 BodyScale;
	public Int32 BodyLevelScale;
	public Int32 EffectScale;
	public ViForeignKey<SimpleAvatarStruct> Avatar;
	public ViEnum32<BoolValue> Pickable;
	public ViForeignKey<VisualSpellStruct> AttackHitEffectVisual;
	public Int32 AttackedColorizeScale;
	public ViEnum32<BoolValue> ShowFocusLink;
	public ViEnum32<BoolValue> KilledIK;
	public Int32 KilledIKExploreScale;
	public ViForeignKey<ViAvatarDurationVisualStruct> KilledExploreVisual;
	public ViEnum32<AvatarDestroyType> DeadDestoryType;
	public Int32 HPSliderCount;
	public ViForeignKey<EntityHintStruct> Hint;
	public ViForeignKey<ViAvatarDurationVisualStruct> DurationVisual;
    public ViEnum32<BoolValue> IsShowNameBillBoard;
    public string BillBoardTitle;
    public Int32 FollowDistance;
    public Int32 DialogCount;
    public ViStaticArray<ViStringPro> DialogValues = new ViStaticArray<ViStringPro>(5);
}

public class EntityHintStruct : ViSealedData
{
	public string Desc;
	public string Icon;
}

public class ViStringPro
{
    public string _Value { get { return value; } }
    
    public string value = string.Empty;
}