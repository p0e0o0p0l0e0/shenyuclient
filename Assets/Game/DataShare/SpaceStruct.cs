using System;
using System.Collections.Generic;

public class SpaceConfigStruct : ViSealedData
{
	public struct AreaStruct
	{
		public Int32 MinX;
		public Int32 MinY;
		public Int32 WidthX;
		public Int32 WidthY;
		public string NavMap;
	}

	public ViForeignKey<PathFileResStruct> StaticResource;
	public ViForeignKey<PathFileResStruct> DynamicResource;
	public AreaStruct Area;
	public Int32 Reserve_5;
	public Int32 Reserve_6;
	public Int32 Reserve_7;
	public Int32 Reserve_8;
	public Int32 Reserve_9;
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
    public string SkyRes;

}

public class SpaceStruct : ViSealedData
{
	public struct EnterStruct
	{
		public ViMask32<SpaceEnterMask> Mask;
	}

	public struct RequestStruct
	{
		public ViValueRange Level;
		public Int32 GMLevel;
		public ViForeignKey<SpaceStruct> Space;
		public Int32 Power;
		public ViForeignKey<ActivityStruct> Activity;
		public ViForeignKey<GameFuncStruct> Func;
		public ViForeignKey<ItemStruct> Ticket;
	}

	public class ReviveStruct
	{
		public ViMask32<SpaceReviveMask> Type;
		public ViEnum32<SpaceRevivePosType> PosType;
		public Int32 ReviveScale;
		public Int32 Duration;
		public ViStaticArray<ViAuraDurationStruct> Aura = new ViStaticArray<ViAuraDurationStruct>((int)SpaceReviveType.TOTAL);
		public ViStaticArray<ViForeignKeyStruct<ViSpellStruct>> Spell = new ViStaticArray<ViForeignKeyStruct<ViSpellStruct>>((int)SpaceReviveType.TOTAL);
	}

	public class TakeStruct
	{
		public ViMask32<ActionStateMask> HeroActionState;
		public ViMask32<SpaceStateMask> HeroSpaceState;
		public ViForeignKey<ViSpellStruct> HeroSpell;
		public ViStaticArray<ViForeignKeyStruct<ViAuraStruct>> HeroAura = new ViStaticArray<ViForeignKeyStruct<ViAuraStruct>>(5);
	}

	public struct ViewStruct
	{
		public ViMask32<SpaceVisibilityMask> PlayerViewMask;
		public ViForeignKey<ViStateConditionStruct> StateCondition;
	}

	public struct RewardStruct
	{
		public ViForeignKey<LootStruct> FirstWinLoot;
		public ViForeignKey<LootStruct> WinLoot;
		public ViForeignKey<LootStruct> LoseLoot;
		public ViEnum32<BoolValue> ReceiveImmdiate;
		public ViForeignKey<ScoreStruct> ScoreType;
		public Int32 StandardLevel;
		public ViForeignKey<ViValueMappingStruct> LevelScale;

		public float GetLevelScale(Int16 iLevel)
		{
			if (iLevel > StandardLevel)
			{
				return LevelScale.Data.Get((iLevel - StandardLevel) * 1.0f) * 0.01f;
			}
			else
			{
				return 1.0f;
			}
		}
	}

	public class EventorStruct
	{
		public ViForeignKey<SpaceEventStruct> Create;
		public ViStaticArray<SpaceEventDelayStruct> Start = new ViStaticArray<SpaceEventDelayStruct>(5);
		public ViForeignKey<SpaceEventStruct> End;
		public ViForeignKey<SpaceEventStruct> Expire;
	}

	public class HandlerScriptStruct
	{
		public string Script;
		public Int32 Tick0Span;
		public Int32 Tick1Span;
		public Int32 PosCount;
		public ViStaticArray<ViVector4Struct> PosList = new ViStaticArray<ViVector4Struct>(10);
		public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(4);
	}

    /// <summary>
    /// 返回一个可达的传送点
    /// </summary>
    public SpaceObjectBirthPositionStruct GetTelePortPoint(SpaceStruct gotoSpace)
    {
        foreach(SpaceObjectBirthPositionStruct spaceObjectBirthPosition in FreeObjectBirthList.List)
        {
            if(spaceObjectBirthPosition.Object != 0)
            {
                SpaceObjectStruct spaceObject = ViSealedDB<SpaceObjectStruct>.Data(spaceObjectBirthPosition.Object);
                if(spaceObject != null)
                {
                    if(spaceObject.Action.Effect.Transport.Type.Value == (Int32)SpaceObjectTransportType.SPACE_TELEPORT)
                    {
                        if(spaceObject.Action.Effect.Transport.Reserve_1 == gotoSpace.ID)
                        {
                            return spaceObjectBirthPosition;
                        }
                    }
                }
            }
        }
        return null;
    }

    public SpaceObjectBirthPositionStruct GetTelePortPoint(Int32 gotoSpaceID)
    {
        SpaceStruct space =  ViSealedDB<SpaceStruct>.Data(gotoSpaceID);
        if(space != null)
        {
            return GetTelePortPoint(space);
        }
        return null;
    }


    /// <summary>
    /// 获取当前地图的NPC出生点
    /// </summary>
    /// 


    public ViEnum32<SpaceType> Type;
	public EnterStruct Enter;
	public Int32 Level;
	public Int32 ModEntityLevel;
	public Int32 ReadyDuration;
	public ViEnum32<SpaceHeroSelectType> HeroSelectType;
	public Int32 FactionCount;
	public Int32 FactionMemberCount;
	public Int32 FactionOfflineDuration;
	public ViEnum32<BoolValue> FactionDieOutLose;
	public ViValueRange MemberInPartyCount;
	public ViForeignKey<SpaceConfigStruct> Config;
	public ViEnum32<SpacePKType> PK;
	public ViEnum32<BoolValue> RecordDamageOut;
	public ViVector3Struct EnterPosition;
	public Int32 EnterYaw;
	//
	public ViForeignKey<SpaceReplacerStruct> Replacer;
	public Int32 ReplacerIdx;
	public ViForeignGroup<SpaceBirthControllerStruct> BirthControllerList = new ViForeignGroup<SpaceBirthControllerStruct>();
	public ViForeignGroup<NPCBirthPositionStruct> FreeNPCBirthList = new ViForeignGroup<NPCBirthPositionStruct>();
	public ViForeignGroup<SpaceObjectBirthPositionStruct> FreeObjectBirthList = new ViForeignGroup<SpaceObjectBirthPositionStruct>();
	public ViForeignGroup<SpaceAuraBirthPositionStruct> FreeAuraBirthList = new ViForeignGroup<SpaceAuraBirthPositionStruct>();
	public ViForeignGroup<SpaceBlockSlotBirthPositionStruct> BlockSlotList = new ViForeignGroup<SpaceBlockSlotBirthPositionStruct>();
	public ViForeignGroup<SpaceHideSlotBirthPositionStruct> HideSlotList = new ViForeignGroup<SpaceHideSlotBirthPositionStruct>();
	public Int32 NPCMaxCount;
	public Int32 ObjectMaxCount;
	public Int32 AreaAuraMaxCount;
	public Int32 WatcherMaxCount;
	public Int32 WorkingWeight;
	//
	public ViForeignKey<GameFuncPolicyStruct> FuncPolicy;
	//
	public RequestStruct Request = new RequestStruct();
	public ReviveStruct Revive = new ReviveStruct();
	public TakeStruct Take = new TakeStruct();
	public ViewStruct View = new ViewStruct();
	public Int32 HeroPatrolRange;
	public Int32 HeroChaseRange;
	public Int32 HeroViewRange;
	public Int32 HeroVisibilityRange;
	public RewardStruct Reward = new RewardStruct();
	public ViForeignKey<ScoreRankStruct> ScoreRank;
	public ViForeignKey<SpaceHeroStandardPropertyStruct> HeroStandardProperty;
	public EventorStruct Eventor = new EventorStruct();
	public HandlerScriptStruct HandlerScript = new HandlerScriptStruct();
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
}
