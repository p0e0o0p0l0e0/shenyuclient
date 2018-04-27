using System;


public struct ViAnimStruct
{
	public bool IsEmpty() { return (res == null || res == string.Empty); }
	public Int32 scale;
	public string res;
}

public class ViCameraShakeStruct : ViSealedData
{
	public struct SpringStruct
	{
		public Int32 Range;
		public Int32 SpirngRate;
		public Int32 SpeedFriction;
		public Int32 TimeScale;
		public Int32 SpringCount;
	}
	public struct RandomStruct
	{
		public Int32 Duration;
		public Int32 Intensity;
		public Int32 Range;
	}
	//
	public Int32 Probability;
	public Int32 LookAtScale;
	public Int32 Reserve2;
	public SpringStruct Spring;
	public RandomStruct Random;
}

public enum ViVisualAutoScale
{
	NONE,
	HEIGHT,
	RADIUS,
	TOTAL,
}

public struct ViAttachExpressStruct
{
	public bool IsEmpty() { return res.Empty(); }
	public float Scale { get { return (scale == 0) ? 1.0f : scale * 0.01f; } }
	public Int32 delayTime;
	public Int32 duration;
	public Int32 fadeTime;
	public Int32 fadeType;
	public Int32 scale;
	public ViEnum32<ViVisualAutoScale> AutoScale;
	public string Reserve_0;
	public ViForeignKey<PathFileResStruct> res;
	public Int32 attachPos;
	public Int32 attachMask;
	public ViEnum32<BoolValue> notBroadcast;
}

public struct ViLinkExpressStruct
{
	public bool IsEmpty() { return res.Empty(); }
	public float Scale { get { return (scale == 0) ? 1.0f : scale * 0.01f; } }
	public Int32 scale;
	public ViForeignKey<PathFileResStruct> res;
	public Int32 fromPos;
	public Int32 toPos;
}

public enum ViTravelEndExpressDirection
{
	INHERIT,
	RESERVE,
}

public class ViTravelExpressStruct: ViSealedData
{
	public Int32 srcPos;
	public Int32 destPos;
	public Int32 height;
	public Int32 gravity;
	public ViForeignKey<PathFileResStruct> res;
	public Int32 reserveTime;
	public ViForeignKey<PathFileResStruct> reserveRes;
	public ViEnum32<ViTravelEndExpressDirection> reserveDirection;

	public ViForeignKey<ViCameraShakeStruct> HitCameraShake;
	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
	public Int32 Reserve_3;
	public Int32 Reserve_4;
}

public struct ViSoundStruct
{
	public bool IsEmpty()
	{
		return Resource.Empty();
	}
	public Int32 delayTime;
	public Int32 duration;
	public ViForeignKey<PathFileResStruct> Resource;
	public ViEnum32<BoolValue> Broadcast;
	public string Desc;
	public Int32 Reserve_1;
}

public class ViAvatarDurationVisualStruct : ViSealedData
{
	static readonly UInt32 MISC_VALUE_MAX = 10;

	public Int32 reserve0;
	public Int32 type;
	public Int32 duration;
	public ViForeignKey<ViVisualHitEffectStruct> hitVisual;
	public ViStaticArray<ViMiscInt32> MiscInt = new ViStaticArray<ViMiscInt32>(MISC_VALUE_MAX);
	public ViStaticArray<ViMiscString> MiscString = new ViStaticArray<ViMiscString>(MISC_VALUE_MAX);
}

public enum ViGroundType
{
	NONE,
	GROUND,
	FLY,
}

public enum ViAuraLookAtType
{
	NONE,
	YAW,
	ATTACH,
}

public class ViVisualAuraStruct : ViSealedData
{
	static readonly UInt32 EXPRESS_MAX = 3;
	static readonly UInt32 DURATION_VISUAL_MAX = 3;

    public class EffectStruct
    {
        public ViAttachExpressStruct effectAvatar;
        public ViAnimStruct effectAnimStart;
        public ViAnimStruct effectAnimEnd;
        public ViEnum32<ViAuraEffectConditionType> effectConditionType;
        public ViEnum32<ViEffectPlayType> effectPlayType;
        public Int32 Reserve_1;
        public ViStaticArray<ViAttachExpressStruct> express = new ViStaticArray<ViAttachExpressStruct>(5);
        public ViEnum32<ViAuraEffectAnimType> effectAnimType;
        public ViStaticArray<Int32> effectAnimDelayTime = new ViStaticArray<Int32>(5);
        public ViStaticArray<ViAnimStruct> effectAnim = new ViStaticArray<ViAnimStruct>(5);
    }

    public ViAnimStruct animStart;
	public ViAnimStruct animLoop;
	public ViAnimStruct animEnd;

	public string description = string.Empty;
	public string icon = string.Empty;

	public Int32 height;
	public Int32 priority;
	public ViEnum32<ViGroundType> ground;
	public ViEnum32<ViAuraLookAtType> lookAtCaster;
	public string materialAnim;

	public ViAreaStruct casterEffectRange;
	public Int32 attackTipsDelayTime;
	public Int32 attackTipsDuration;

	public ViForeignKey<ViEmptySealedData> progressBar;
	public ViStaticArray<ViAttachExpressStruct> express = new ViStaticArray<ViAttachExpressStruct>(EXPRESS_MAX);
	public ViAttachExpressStruct vanishVisual;
	public ViStaticArray<ViLinkExpressStruct> linkExpress = new ViStaticArray<ViLinkExpressStruct>(5);
	public ViStaticArray<ViSoundStruct> sound = new ViStaticArray<ViSoundStruct>(2);
	public ViStaticArray<ViForeignKeyStruct<ViAvatarDurationVisualStruct>> durationVisual = new ViStaticArray<ViForeignKeyStruct<ViAvatarDurationVisualStruct>>(DURATION_VISUAL_MAX);

    public EffectStruct effectStruct = new EffectStruct();
}
public enum ViAuraEffectAnimType
{
    NONE,
    LOOP,
    CONDITION,
}
public enum ViAuraEffectConditionType
{
    NONE,
    RAGE,
    BLOCK,
    ICEPITONSPLASH,
}
public enum ViEffectPlayType
{
    PUSHALL,
    ONEBYONE,
    RANDOM,
}

public class ViVisualHitEffectStruct : ViSealedData
{
	static readonly UInt32 ANIM_MAX = 5;
	static readonly UInt32 EXPRESS_MAX = 5;
    static readonly UInt32 SOUND_MAX = 5;

    public struct CameraShake
	{
		public Int32 DelayTime;
		public ViForeignKey<ViCameraShakeStruct> Shake;
		public ViEnum32<BoolValue> Broadcast;
		public Int32 Reserve_2;
		public Int32 Reserve_3;
		public Int32 Reserve_4;
	}

	public float OffSetScale()
	{
		if (OffsetScale == 0)
		{
			return 1.0f;
		}
		return OffsetScale * 0.01f;
	}

	public Int32 OffsetScale;
	public ViStaticArray<ViAnimStruct> anims = new ViStaticArray<ViAnimStruct>(ANIM_MAX);
	public ViStaticArray<ViAttachExpressStruct> express = new ViStaticArray<ViAttachExpressStruct>(EXPRESS_MAX);
	public ViStaticArray<ViSoundStruct> sound = new ViStaticArray<ViSoundStruct>(SOUND_MAX);
	public CameraShake cameraShake;

	public ViAreaStruct casterEffectRange;
	public Int32 attackTipsDelayTime;
	public Int32 attackTipsDuration;

    public ViEnum32<ViEffectPlayType> effectPlayType;
    public Int32 Reserve_1;
    public Int32 Reserve_2;
}

public class ViVisualDriveStruct : ViSealedData
{
	public ViAnimStruct anim;
	public ViForeignKey<ViVisualAuraStruct> auraVisual;
	public ViForeignKey<ViVisualHitEffectStruct> hiteffectVisual;

	//
	public Int32 reserve0;
	public Int32 reserve1;
	public Int32 reserve2;
	public Int32 reserve3;
	public Int32 reserve4;
	public Int32 reserve5;
}

