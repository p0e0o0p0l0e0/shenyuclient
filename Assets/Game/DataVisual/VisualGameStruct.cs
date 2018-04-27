using System;
using System.Collections.Generic;

public class ColorStruct : ViSealedData
{
	public string Color;
}

public class EntityMessageLogStruct : ViSealedData
{
	static char[] Segregate = { '&' };
	public override void Format()
	{
		NameSegmentList.List.AddRange(Name.Split(Segregate, StringSplitOptions.None));
	}

	public string Type;
	public ViForeignKey<ColorStruct> Color;
	public ViEnum32<ChatChannelType> Channel;
	public ViMask32<EntityMessagePositionMask> Position;
	public string Icon;
	public string Description;
	public string WindowScript;
	public Int32 Duration;
	public ViSealedArray<string> NameSegmentList = new ViSealedArray<string>();
}

public class VisualProgressBarStruct : ViSealedData
{
	public Int32 Weight;
	public string Res;
	public string Icon;
	public ViForeignKey<ColorStruct> Color;
	public ViMask32<VisualProgressMask> ProgressMask;
}

public class VisualSpaceEventDescStruct : ViSealedData
{
	public string Desc;
	public Int32 DescDuration;
	public ViForeignKey<PathFileResStruct> SpaceResource;
	public ViMask32<ExpressAttachMask> SpaceResourceAttachMask;
	public Int32 SpaceResourceDuration;
}

public class SpaceCameraStruct : ViSealedData
{
	public struct DataStruct
	{
		public Int32 Pitch;
		public Int32 Field;
		public Int32 Height;
		public Int32 Front;
		public Int32 Distance;
		public Int32 CameraXMove;
		public Int32 CameraYMove;
	}
	//
	public ViEnum32<BoolValue> Free;
	public DataStruct Inf;
	public DataStruct Sup;
}

public class AttributeDisplayFomatStruct : ViSealedData
{
	public string Print(Int32 value)
	{
		string desc = (1.0f * value / ScaleReverse).ToString(PrintFomat) + Append;
		return desc;
	}

	public string PrintFomat;
	public int ScaleReverse;
	public string Append;
}

public class VisualHeroStruct : ViSealedData
{
	public struct HeroAbility
	{
		public Int32 HP;
		public Int32 ATK;
		public Int32 DEF;
		public Int32 RES;
	}

	public struct HeroPhoto
	{
		public string Icon;
	}

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

	public string PhotoA { get { return PhotoArray[0].Icon; } }
	public string PhotoB { get { return PhotoArray[1].Icon; } }
	public string PhotoC { get { return PhotoArray[2].Icon; } }
	public string PhotoD { get { return PhotoArray[3].Icon; } }
	public string PhotoE { get { return PhotoArray[4].Icon; } }
	public string PhotoF { get { return PhotoArray[5].Icon; } }
	public string PhotoH { get { return PhotoArray[6].Icon; } }
	public string PhotoI { get { return PhotoArray[7].Icon; } }
	public string PhotoJ { get { return PhotoArray[8].Icon; } }
	public string PhotoK { get { return PhotoArray[9].Icon; } }

	public string NameIcon;
	public string NameIcon2;
	public string Desc;
	public ViStaticArray<HeroPhoto> PhotoArray = new ViStaticArray<HeroPhoto>(10); // ABCDEFHIJK
	public string OccupationIcon;
	public string Reserve_2;
	public Int32 BodyScale;
	public ViForeignKey<SimpleAvatarStruct> Avatar;
	public ViForeignKey<ViAvatarDurationVisualStruct> EnterShow;
	public ViForeignKey<ViAvatarDurationVisualStruct> LeaveShow;
	public ViForeignKey<ViAvatarDurationVisualStruct> WinShow;
	public ViForeignKey<ViVisualHitEffectStruct> WinShowAction;
	public ViForeignKey<ViAvatarDurationVisualStruct> FailShow;
	public HeroAbility Ability;
	public ViStaticArray<HeroPhoto> StarPhotoArray = new ViStaticArray<HeroPhoto>(10);
	public string WeaponName;
	public string WeaponIcon;
	public string WeaponDesc;
	public string Introduction;
	public ViStaticArray<ViSoundStruct> Sound = new ViStaticArray<ViSoundStruct>(10);

}

public class MessageBoxStruct : ViSealedData
{

}

public class UIEventStruct : ViSealedData
{
	public string Window;
}

public class GoalDisplayTypeStruct : ViSealedData
{

}

public class VisualExpressionStruct : ViSealedData
{
	public struct PictureDuration
	{
		public Int32 Duration;

		public bool IsEmpty()
		{
			return Duration == 0;
		}
	}

	public List<float> SpriteDuringList()
	{
		List<float> list = new List<float>();
		for (int iter = 0; iter < DurationList.Length; ++iter)
		{
			if (DurationList[iter].IsEmpty())
			{
				continue;
			}
			list.Add(DurationList[iter].Duration * 0.01f);
		}
		return list;
	}

	public string Icon;
	public Int32 FPS;
	public ViStaticArray<PictureDuration> DurationList = new ViStaticArray<PictureDuration>(30);
}

public class MusicStruct : ViSealedData
{
	public float GetVolume()
	{
		if (Volume == 0)
		{
			return 1.0f;
		}
		else
		{
			return Volume * 0.01f;
		}
	}
	//
	public Int32 Volume;
	public ViForeignKey<PathFileResStruct> Res;
	public Int32 Duration;
}

public class GraphicsLevelStruct : ViSealedData
{
	public struct RecommandStruct
	{
		public Int32 APILevel;
		public Int32 SystemMemorySize;
		public Int32 GraphicsMemorySize;
		public Int32 ProcessorCount;
		public Int32 ProcessorFrequency;
	}
	//
	public Int32 SpellLODLevel;
	public ViEnum32<BoolValue> GraphicsMirrorCharacter;
	public ViEnum32<BoolValue> GraphicsMirrorScene;
	public ViEnum32<BoolValue> GraphicsShadow;
	public ViEnum32<BoolValue> GraphicsColorEnhance;
	public ViEnum32<BoolValue> GraphicsBloom;
	public ViEnum32<BoolValue> GraphicsDistort;
	public Int32 QualityLevel;
	public RecommandStruct Recommand;
}

public class DeviceEmulatorStruct : ViSealedData
{

}

public class VisualPartyMatchStruct : ViSealedData
{
	public ViForeignKey<SpaceStruct> Space;
	public string Icon;
	public string Desc;
}
