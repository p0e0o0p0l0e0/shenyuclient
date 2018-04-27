using System;


public class SpacePositionStruct : ViSealedData
{
	public struct RequestStruct
	{
		public ViForeignKey<SpaceBirthControllerStruct> Controller;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
	}
	//
	public ViForeignKey<SpaceConfigStruct> Space;
	public ViVector3Struct Position;
	public Int32 Range;
	public RequestStruct Request;
	public ViForeignKey<CoolingDownStruct> Coolingdown;
	public ViForeignKey<SpaceEventStruct> Event;
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
}

public struct SpacePointStruct
{
	public enum UseFlag
	{
		DEACTIVE,
		ACTIVE,
	}
	public ViEnum32<UseFlag> Active;
	public ViVector3Struct Position;
	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
	public Int32 Reserve_3;
}

public class SpaceRouteStruct : ViSealedData
{
	public static readonly UInt32 POINT_COUNT = 10;

	public ViForeignKey<SpaceConfigStruct> Space;
	public ViEnum32<BoolValue> Loop;
	public ViForeignKey<SpaceEventStruct> EndEvent;
	public ViStaticArray<SpacePointStruct> Points = new ViStaticArray<SpacePointStruct>(POINT_COUNT);
	public ViSealedArray<ViVector3> Route = new ViSealedArray<ViVector3>();

	public void GetList(System.Collections.Generic.List<ViVector3> list)
	{
		for (int iter = 0; iter < Points.Length; ++iter)
		{
			if (Points[iter].Active == (int)SpacePointStruct.UseFlag.ACTIVE)
			{
				list.Add(Points[iter].Position);
			}
		}
	}
}

public class SpaceReplacerStruct: ViSealedData
{
	public ViStaticArray<ViForeignKeyStruct<SpaceStruct>> m_kList = new ViStaticArray<ViForeignKeyStruct<SpaceStruct>>(20);
}

public class SpaceNPCReplacerStruct: ViSealedData
{
	public ViStaticArray<ViForeignKeyStruct<NPCStruct>> m_kList = new ViStaticArray<ViForeignKeyStruct<NPCStruct>>(20);
}

public struct SpaceTransportStruct
{
	public ViEnum32<BoolValue> Immediately;
	public ViForeignKey<SpaceStruct> Space;
	public ViForeignKey<SpacePositionStruct> SpacePos;
}

public class SpaceEventStruct : ViSealedData
{
	public class RandomEventorArrayStruct
	{
		public Int32 Probability;
		public Int32 Count;
		public ViStaticArray<ProbabilityValue<SpaceEventDelayStruct>> Data = new ViStaticArray<ProbabilityValue<SpaceEventDelayStruct>>(4);
	}

	public ViForeignKey<ViSealedDataTypeStruct> Type;
	public ViForeignKey<SpaceStruct> Space;
	public ViMask32<SpaceTypeMask> IgnoreSpaceMask;
	public ViEnum32<BoolValue> IgnoreState;
	public ViForeignKey<SpaceEventStruct> ReqEvent;
	public ViForeignKey<SpaceEventStruct> ReqNotEvent;
	public ViVector3Struct Pos;
	public Int32 Yaw;
	public Int32 DelayTime;
	public Int32 Coolingdown;
	public ViEnum32<BoolValue> Loop;
	public ViEnum32<BoolValue> Record;
	public ViEnum32<BoolValue> CacheUnique;
	public ViEnum32<BoolValue> OverrideEnterPos;
	public ViEnum32<BoolValue> Transport;
	public ViEnum32<BoolValue> BroadcastClient;
	public ViForeignKey<VisualSpaceEventDescStruct> Desc;
	public ViForeignKey<VisualProgressBarStruct> Progress;
	public ViForeignKey<SpaceEventStruct> RemoveEvent;
	public ViStaticArray<SpaceEventDelayStruct> Eventor = new ViStaticArray<SpaceEventDelayStruct>(4);
	public RandomEventorArrayStruct RandomEventor = new RandomEventorArrayStruct();
}

public struct SpaceEventDelayStruct
{
	public Int32 Delay;
	public ViForeignKey<SpaceEventStruct> Event;
}

public class SpaceBlockSlotStruct : ViSealedData
{
	public Int32 Range;
	public Int32 RecoverDuration;
	public ViForeignKey<PathFileResStruct> Res;
}

public class SpaceBlockSlotBirthPositionStruct : ViSealedData
{
	public ViForeignKey<SpaceStruct> Space;
	public Int32 PixelX;
	public Int32 PixelY;
	public ViForeignKey<SpaceBlockSlotStruct> Info;
}

public class SpaceHideSlotStruct : ViSealedData
{
	public Int32 Range;
	public Int32 RecoverDuration;
	public ViForeignKey<PathFileResStruct> Res;
}

public class SpaceHideSlotBirthPositionStruct : ViSealedData
{
	public ViForeignKey<SpaceStruct> Space;
	public Int32 PixelX;
	public Int32 PixelY;
	public ViForeignKey<SpaceHideSlotStruct> Info;
}

public class SpaceBirthControllerStruct : ViSealedData
{
	public struct FactionOwnStruct
	{
		public ViEnum32<Faction> Faction;
		public ViForeignKey<SpaceEventStruct> Event;
		public string StartDescription;
		public string EndDescription;
		public string RevertDescription;
		public ViEnum32<BoolValue> OwnExist;
	}

	public struct ResetFactionStruct
	{
		public ViForeignKey<SpaceEventStruct> Event;
		public ViEnum32<BoolValue> UpdateEntity;
	}

	public struct EndEventStruct
	{
		public ViForeignKey<SpaceEventStruct> Event;
		public ViEnum32<SpaceBirthControllerResult> Result;
	}

	public struct LevelStruct
	{
		public ViEnum32<BoolValue> EffectExist;
		public ViForeignKey<SpaceEventStruct> UpEvent;
		public ViForeignKey<SpaceEventStruct> DownEvent;
		public ViValueRange Range;
	}

	public class EventorStruct
	{
		public ViStaticArray<SpaceEventDelayStruct> Event = new ViStaticArray<SpaceEventDelayStruct>(4);
		public string Desc;
		public ViForeignKey<ViCameraShakeStruct> CameraShake;
	}

	public struct PlayerStruct
	{
		public ViForeignKey<ViAuraStruct> Aura;
		public ViMask32<FactionMask> FactionMask;
	}

	public struct InheritStruct
	{
		public ViForeignKey<SpaceEventStruct> Event;
		public ViForeignKey<SpaceBirthControllerStruct> Receiver;
	}

	public struct HandlerStruct
	{
		public ViForeignKey<SpaceEventStruct> Event;
		public ViForeignKey<ViAuraStruct> AddAura;
		public ViForeignKey<ViAuraStruct> DelAura;
		public Int32 DelAuraDelay;
	}

    public override void Format() { }
    public override void Start()
    {
        if (Space.NotEmpty())
        {
            SpaceStruct space_conf = Space.Data;
            space_conf.BirthControllerList.Add(this);
        }

    }

    //
    public ViForeignKey<SpaceStruct> Space;
	public ViForeignKey<ViSealedDataTypeStruct> Type;
	public ViStaticArray<ViForeignKeyStruct<SpaceBirthControllerStruct>> PreCondition = new ViStaticArray<ViForeignKeyStruct<SpaceBirthControllerStruct>>(5);
	public ViStaticArray<ViForeignKeyStruct<SpaceEventStruct>> ReqEvent = new ViStaticArray<ViForeignKeyStruct<SpaceEventStruct>>(3);
	public ViStaticArray<ViForeignKeyStruct<SpaceEventStruct>> NotReqEvent = new ViStaticArray<ViForeignKeyStruct<SpaceEventStruct>>(3);
	public ViEnum32<BoolValue> StartIgnoreSpaceState;
	public ViMask32<FactionMask> StartEventFaction;
	public ViStaticArray<ViForeignKeyStruct<SpaceEventStruct>> StartEvent = new ViStaticArray<ViForeignKeyStruct<SpaceEventStruct>>(3);
	public ViStaticArray<EndEventStruct> EndEvent = new ViStaticArray<EndEventStruct>(3);
	public ViForeignKey<SpaceEventStruct> CompleteEvent;
	public ViForeignKey<SpaceEventStruct> RouteResetEvent;
	public ViEnum32<BoolValue> RouteResetPos;
	public FactionOwnStruct FactionOwn;
	public ResetFactionStruct FactionReset;
	public ViEnum32<SpaceBirthControllerEndType> EndType;
	public LevelStruct Level;
	public Int32 StartTime;
	public Int32 Count;
	public Int32 Span;
	public ViForeignKey<SpaceBirthControllerStruct> DisBornController;
	public Int32 CompleteScale;
	public Int32 NPCRandomPosCount;
	public Int32 ServantRandomPosCount;
	public Int32 ObjectRandomPosCount;
	public Int32 AreaAuraRandomPosCount;
	public Int32 NPCMaxCount;
	public Int32 ObjectMaxCount;
	public Int32 AreaAuraMaxCount;
	public ViForeignGroup<NPCBirthPositionStruct> NPCBirthList = new ViForeignGroup<NPCBirthPositionStruct>();
	public ViForeignGroup<SpaceObjectBirthPositionStruct> ObjectBirthList = new ViForeignGroup<SpaceObjectBirthPositionStruct>();
	public ViForeignGroup<SpaceAuraBirthPositionStruct> AuraBirthList = new ViForeignGroup<SpaceAuraBirthPositionStruct>();
	public ViEnum32<BoolValue> DieOutBorn;
	public ViVector3Struct Position;
	public Int32 Yaw;
	public ViMask32<SpaceBirthControllerActionMask> ActionMask;
	public ViForeignKey<ViAuraStruct> AddAura;
	public ViForeignKey<SpaceRouteStruct> SpaceFomation;
	public Int32 SpaceFomationSpan;
	public Int32 EnterSpaceDelaySpan;
	public ViForeignKey<SpaceBirthControllerShowStruct> Show;
	public EventorStruct StartEventor = new EventorStruct();
	public EventorStruct EndEventor = new EventorStruct();
	public EventorStruct BornEventor = new EventorStruct();
	public EventorStruct CompleteEventor = new EventorStruct();
	public EventorStruct BreakEventor = new EventorStruct();
	public PlayerStruct Player;
	public ViForeignKey<LootStruct> Loot;
	public ViStaticArray<InheritStruct> Inheritor = new ViStaticArray<InheritStruct>(3);
	public ViStaticArray<HandlerStruct> Handler = new ViStaticArray<HandlerStruct>(5);
}

public class NPCAIGroupStuct : ViSealedData
{

}

public class NPCEnterSpaceStruct : ViSealedData
{
	public Int32 Range;
	public Int32 Duration;
	public Int32 DisAttackedDuration;
	public ViForeignKey<ViSpellStruct> Spell;
	public Int32 SpellDelay;
	public ViForeignKey<VisualNPCShowStruct> Visual;
}

public struct NPCHPPercEventNodeStruct
{
	public Int32 HPPerc;
	public ViForeignKey<SpaceEventStruct> Event;
	public ViForeignKey<NPCStruct> Replace;
	public ViForeignKey<ViSpellStruct> ActionSpell;
	public ViForeignKey<ViAuraStruct> Aura;
}

public class NPCHPPercEventStruct : ViSealedData
{
	public ViStaticArray<NPCHPPercEventNodeStruct> List = new ViStaticArray<NPCHPPercEventNodeStruct>(5);
}

public class NPCBirthPropertyStruct : ViSealedData
{
	public bool HasEvevent(SpaceEventStruct info)
	{
		if (FirstChaseEvent == info.ID)
		{
			return true;
		}
		if (FirstAttackedEvent == info.ID)
		{
			return true;
		}
		if (FirstDiscoverEvent == info.ID)
		{
			return true;
		}
		if (FirstDiscoveredEvent == info.ID)
		{
			return true;
		}
		if (KilledEvent == info.ID)
		{
			return true;
		}
		if (DieOutEvent == info.ID)
		{
			return true;
		}
		if (AttackedEvent == info.ID)
		{
			return true;
		}
		//
		return false;
	}
	//
	public Int32 LiveCount;
	public ViForeignKey<ViAuraStruct> Aura;
	public ViEnum32<BoolValue> EnterBattle;
	public ViForeignKey<NPCAIGroupStuct> AIGroup;
	public ViForeignKey<ViSpellStruct> DieSpell;
	public Int32 DieSpellDelay;
	public ViForeignKey<SpaceEventStruct> FirstChaseEvent;
	public ViForeignKey<SpaceEventStruct> FirstAttackedEvent;
	public ViForeignKey<SpaceEventStruct> FirstDiscoverEvent;
	public ViForeignKey<SpaceEventStruct> FirstDiscoveredEvent;
	public ViForeignKey<SpaceEventStruct> KilledEvent;
	public ViForeignKey<SpaceEventStruct> DieOutEvent;
	public ViForeignKey<SpaceEventStruct> AttackedEvent;
	public Int32 AttackedEventCD;
	public ViForeignKey<NPCHPPercEventStruct> HPPercEvent;
	public Int32 NavigateStepCount;
	public ViEnum32<BoolValue> BigEntity;
	public ViEnum32<SpaceEntityBroadcastType> Broadcast;
}

public class NPCBirthPositionStruct : ViSealedData
{
	public ViForeignKey<SpaceStruct> Space;
	public ViVector3Struct Position;
	public Int32 Yaw;
	public Int32 Range;
	public ViForeignKey<NPCStruct> NPC;
	public ViForeignKey<SpaceNPCReplacerStruct> NPCReplacer;
	public Int32 Count;
	public ViForeignKey<NPCEnterSpaceStruct> EnterSpace;
	public ViForeignKey<NPCBirthPropertyStruct> BirthProperty;
	public ViForeignKey<SpaceRouteStruct> Route;
	public ViEnum32<BoolValue> RouteClip;
	public ViForeignKey<SpaceRouteStruct> SpaceFomation;
	public Int32 SpaceFormationSpan;
	public ViForeignKey<SpaceBirthControllerStruct> Controller;
	public Int32 ControllerProbability;
    public Int32 NpcLevel;
    public ViForeignKey<NPCPrivateLootStruct> Loot;
    public ViEnum32<BoolValue> AutoLoad;
    public ViEnum32<BoolValue> UseIndexPos;
    public ViStaticArray<ViVector3Struct> BirthIndexPos = new ViStaticArray<ViVector3Struct>(10);

    public override void Format() {
    }
    public override void Start() {
        if(Space.NotEmpty())
        {
            SpaceStruct space_conf = Space.Data;
            space_conf.FreeNPCBirthList.Add(this);
        }

        if(Controller.NotEmpty())
        {
            SpaceBirthControllerStruct space_birth_conf = Controller.Data;
            space_birth_conf.NPCBirthList.Add(this);
        }
    }
}

public struct SpaceObjectBirthPropertyStruct
{
	public struct RequestStruct
	{
		public ViForeignKey<SpaceBirthControllerStruct> Controller;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
	}

	public Int32 LiveCount;
	public ViForeignKey<SpaceEventStruct> FirstDiscoveredEvent;
	public ViForeignKey<SpaceEventStruct> ActionEvent;
	public ViForeignKey<SpaceEventStruct> KilledEvent;
	public ViForeignKey<SpaceEventStruct> DieEvent;
	public ViForeignKey<SpaceEventStruct> DieOutEvent;
	public RequestStruct Request;
	public ViEnum32<BoolValue> EnterSpace;
	public ViEnum32<BoolValue> ExitSpace;
}

public class SpaceObjectBirthPositionStruct : ViSealedData
{
    public Int32 Reserve_0;
    public ViForeignKey<SpaceStruct> Space;
    public ViVector3Struct Position;
    public Int32 Yaw;
    public Int32 Range;
    public Int32 Reserve_1;
    public Int32 Reserve_2;
    public ViForeignKey<SpaceObjectStruct> Object;
    public Int32 Count;
    public SpaceObjectBirthPropertyStruct BirthProperty;
    public ViForeignKey<SpaceRouteStruct> Route;
    public ViForeignKey<SpaceBirthControllerStruct> Controller;
    public Int32 ControllerProbability;


    public override void Format()
    {
    }
    public override void Start()
    {
        if (Space.NotEmpty())
        {
            SpaceStruct space_conf = Space.Data;
            space_conf.FreeObjectBirthList.Add(this);
        }

        if (Controller.NotEmpty())
        {
            SpaceBirthControllerStruct space_birth_conf = Controller.Data;
            space_birth_conf.ObjectBirthList.Add(this);
        }
    }
}

public class SpaceAuraBirthPositionStruct : ViSealedData
{
	public ViForeignKey<SpaceStruct> Space;
	public ViVector3Struct Position;
	public Int32 Range;
	public Int32 Yaw;
	public ViForeignKey<ViAuraStruct> Aura;
	public ViEnum32<Faction> Faction;
	public ViForeignKey<SpaceRouteStruct> Route;
	public Int32 MoveSpeed;
	public Int32 Duration;
	public ViForeignKey<SpaceBirthControllerStruct> Controller;
	public Int32 ControllerProbability;


    public override void Format()
    {
    }
    public override void Start()
    {
        if (Space.NotEmpty())
        {
            SpaceStruct space_conf = Space.Data;
            space_conf.FreeAuraBirthList.Add(this);
        }

        if (Controller.NotEmpty())
        {
            SpaceBirthControllerStruct space_birth_conf = Controller.Data;
            space_birth_conf.AuraBirthList.Add(this);
        }
    }
}

public class SpaceHeroStandardPropertyStruct: ViSealedData
{
	public Int32 HPMaxScale;
	public Int32 Level;
	public Int32 Star;
	public Int32 Quality;
	public Int32 WeaponLevel;
	public Int32 SpellLevel;
}

public class SpaceHeroLevelStruct : ViSealedData
{
	public Int32 XP;
	public Int32 KilledLootXP;
}

public class SpaceHeroLevelEffectStruct: ViSealedData
{
	public string Icon;
	public ViForeignKey<AttributeModifyStruct> Value;
	public ViForeignKey<AttributeModifyStruct> Scale;
}