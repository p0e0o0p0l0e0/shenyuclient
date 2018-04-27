using System;
using System.Collections;

public enum AOIAreaAttach
{
	WORLD,
	BOTTOM,
	SELF,
	TOTAL
}

public class VisualSpellProcStruct
{
	public struct BodyPartActive
	{
		public Int32 DelayTime;
		public Int32 DurationTime;
		public string BodyPartName;
		public ViEnum32<BoolValue> Active;
	}

	public struct CameraShake
	{
		public Int32 DelayTime;
		public ViForeignKey<ViCameraShakeStruct> Shake;
		public ViEnum32<BoolValue> Broadcast;
		public Int32 Reserve_2;
	}

	public ViStaticArray<ViAnimStruct> Anim = new ViStaticArray<ViAnimStruct>(3);
	public ViStaticArray<ViAttachExpressStruct> Express = new ViStaticArray<ViAttachExpressStruct>(6);
	public ViStaticArray<ViSoundStruct> sound = new ViStaticArray<ViSoundStruct>(4);
	public ViStaticArray<CameraShake> Shake = new ViStaticArray<CameraShake>(8);
	public ViStaticArray<BodyPartActive> BodyPartState = new ViStaticArray<BodyPartActive>(8);
	public ViForeignKey<ViVisualAuraStruct> DurationEffect;
	public Int32 DurationEffectDuration;
	public string FaceTo;
	public Int32 FaceDuration;

	public ViAreaStruct casterEffectRange;
	public Int32 attackTipsDelayTime;
	public Int32 attackTipsDuration;
}

public struct VisualSpellSelector
{
	public ViMask32<ViUnitSocietyMask> GroupPosFocus;
	public ViEnum32<SpellPositionSelectType> Position;
	public ViEnum32<AOIAreaAttach> AttachType;
    public ViEnum32<AutoFocusType> AutoFocusType;
    public ViAreaStruct casterEffectRange;
}

public class VisualSpellStruct : ViSealedData
{
    public class FlyStruct
    {
        public ViStaticArray<ViAnimStruct> Anim = new ViStaticArray<ViAnimStruct>(3);
    }

	public VisualSpellSelector Selector;

	public VisualSpellProcStruct Proc = new VisualSpellProcStruct();
	public ViForeignKey<ViTravelExpressStruct> Travel;

    public FlyStruct flyStruct = new FlyStruct();
}