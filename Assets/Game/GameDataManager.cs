using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


public class SealedDataLoaderInterface
{
	public static string AssetBundleSectionName(string name)
	{
		return "Assets/VIBPrefab/" + name + ".Prefab";// 导出方式是自定义方式
	}

	public void Load(string file, string fection)
	{
        GameDataManager.mAddLoad(fection);

        mResLoader.Start(file, SealedDataLoaderInterface.AssetBundleSectionName(fection), (UnityEngine.Object pAsset) =>
        {
            if (pAsset == null)
            {
                Debug.LogError("数据表加载失败 " + fection);
            }
            else
            {
                OnLoaded(pAsset);
            }
            GameDataManager.mFinishLoad(fection);

            mResLoader.End();
        });
	}

	void OnLoaded(UnityEngine.Object pAsset)
	{
        ViIStream stream = new ViIStream();
        ViDebuger.AssertError(pAsset);
        BlobStream blob = ((GameObject)pAsset).GetComponent<BlobStream>();
        stream.Init(blob.GetData(), 0, blob.GetData().Length);
        Read(stream);
    }

	public virtual void Read(ViIStream IS) { }

    ResourceRequest mResLoader = new ResourceRequest();
}

public class SealedDataLoader<T> : SealedDataLoaderInterface
	where T : ViSealedData, new()
{
	public override void Read(ViIStream IS)
	{
		ViSealedDB<T>.Load(IS, false);
	}
}


public class GameDataManager
{
	public delegate void DeleDataCompleted();
	public DeleDataCompleted DataCompletedCallback;

	public bool SealedDataEditor;
	public bool Completed{ get { return _completed; } }
    public static string mTempServerList = ""; // 临时的
    void LoadXML(string name)
    {
        mAddLoad(name);
        ResourceRequest mResLoader = new ResourceRequest();
        mResLoader.Start("vib/VIBStream", SealedDataLoaderInterface.AssetBundleSectionName(name), (UnityEngine.Object pAsset) =>
        {
            ReadConstValue(pAsset as GameObject);
            mFinishLoad(name);
            mResLoader.End();
        });
	}

    void LoadJosn(string name)
    {
        mAddLoad(name);

        ResourceRequest mResLoader = new ResourceRequest();
        mResLoader.Start("vib/VIBStream", SealedDataLoaderInterface.AssetBundleSectionName(name), (UnityEngine.Object pAsset) =>
        {
            if (pAsset == null)
            {
                Debug.Log("Load Json 失败" + name);
            }
            else
            {
                GameObject obj = pAsset as GameObject;
                byte[] data = obj.GetComponent<BlobStream>().GetData();
                mTempServerList = System.Text.Encoding.UTF8.GetString(data);
                //ViDebuger.Record(mTempServerList);
            }

            mFinishLoad(name);
            mResLoader.End();
        });
    }

    static void ReadConstValue(GameObject pFile)
	{
        MemoryStream stream = new MemoryStream(pFile.GetComponent<BlobStream>().GetData());
		XmlDocument xml = new XmlDocument();
		xml.Load(stream);
		ViConstValueReader.Load(xml["Root"]);
		stream.Close();
		xml.RemoveAll();
	}

	void LoadSealedData<T>() where T : ViSealedData, new()
	{
		ViSealedDataLoadNode<T>.ClearName = false;
		ViSealedDataLoadNode<T>.ClearNote = !SealedDataEditor;
		LoadSealedData<T>("VIBStream", typeof(T).Name);
	}

	void LoadSealedData<T>(bool clearName) where T : ViSealedData, new()
	{
		ViSealedDataLoadNode<T>.ClearName = clearName;
		ViSealedDataLoadNode<T>.ClearNote = !SealedDataEditor;
		LoadSealedData<T>("VIBStream", typeof(T).Name);
	}

	void LoadSealedData<T>(bool clearName, bool clearNote) where T : ViSealedData, new()
	{
		ViSealedDataLoadNode<T>.ClearName = clearName;
		ViSealedDataLoadNode<T>.ClearNote = clearNote;
		LoadSealedData<T>("VIBStream", typeof(T).Name);
	}

	void LoadSealedData<T>(string section) where T : ViSealedData, new()
	{
		LoadSealedData<T>("VIBStream", section);
	}

	void LoadSealedData<T>(string file, string section) where T : ViSealedData, new()
	{
		ViDebuger.AssertError(typeof(T).Name == section, "AddSealedData<" + typeof(T).Name + ">(" + file + ")");
		SealedDataLoaderInterface loader = new SealedDataLoader<T>();
		loader.Load("vib/" + file, section);
	}

	public void Load0()
	{
        mAddLoad = OnAddLoadFile;
        mFinishLoad = OnFinish0Load;

        LoadXML("ConstValue");
        LoadJosn("serverlist");
        LoadSealedData<ServerConfigViewStruct>(false, false);
		LoadSealedData<ServerConfigPortStruct>();
		LoadSealedData<FormatStringStruct>();
		LoadSealedData<EntityMessageLogStruct>();
        LoadSealedData<UIPanelConfigStruct>();
        _loadingEvent.Reset(this.ResourceLoaded);
		_loadingEvent.Wait("VIB");
    }

    public void Load1()
	{
        mFinishLoad = OnFinish1Load;

        LoadSealedData<ViEmptySealedData>();
		LoadSealedData<ViSealedDataTypeStruct>();
		LoadSealedData<ViStateConditionStruct>();
		LoadSealedData<ViDateTimeStruct>();
		LoadSealedData<ViDateTimeExStruct>();
		LoadSealedData<ViSpellStruct>();
		LoadSealedData<ViSpellEffectStruct>(true);
		LoadSealedData<ViAuraTypeStruct>();
		LoadSealedData<ViAuraChannelStruct>();
		LoadSealedData<ViAuraStruct>();
		LoadSealedData<ViHitEffectStruct>();
		LoadSealedData<ViAttackForceStruct>();
		LoadSealedData<PathFileResStruct>();
		//
		LoadSealedData<ViCameraShakeStruct>();
		LoadSealedData<ViVisualAuraStruct>();
		LoadSealedData<ViVisualHitEffectStruct>(true);
		LoadSealedData<ViTravelExpressStruct>(true);
		LoadSealedData<ViVisualDriveStruct>();
		//
		LoadSealedData<DateLoopStruct>();
		LoadSealedData<LoopDateTimeStruct>();
		LoadSealedData<ViDistributionStruct>();
		LoadSealedData<ViValueMappingStruct>();
		LoadSealedData<ItemValueStruct>();
		LoadSealedData<ItemStruct>();
		LoadSealedData<ItemQualityStruct>();
		LoadSealedData<MarketItemStruct>();
		LoadSealedData<RechargeItemStruct>();
		LoadSealedData<ItemComposeStruct>();
		LoadSealedData<AttributeModifyStruct>();
		LoadSealedData<OwnSpellStruct>();
		LoadSealedData<SpellLimitStruct>();
		LoadSealedData<HeroLevelStruct>();
		LoadSealedData<HeroStruct>();
		LoadSealedData<HeroNatureStruct>();
		LoadSealedData<BulletStruct>();
		LoadSealedData<WeaponTypeStruct>();
		LoadSealedData<GameUnitPropertyStruct>(true);
		LoadSealedData<ThreatStandardStruct>();
		LoadSealedData<PlayerStateConditionStruct>();
		LoadSealedData<PlayerLevelStruct>();
		LoadSealedData<PlayerPhotoStruct>();
		LoadSealedData<AttributeTypeStruct>();
		LoadSealedData<SpaceConfigStruct>();
		LoadSealedData<SpaceStruct>();
		LoadSealedData<SpaceEventStruct>();
		LoadSealedData<SpaceBlockSlotStruct>();
		//LoadSealedData<SpaceBlockSlotBirthPositionStruct>();
		LoadSealedData<SpaceHideSlotStruct>();
		//LoadSealedData<SpaceHideSlotBirthPositionStruct>();
		LoadSealedData<SpaceRouteStruct>();
		//LoadSealedData<SpaceReplacerStruct>();
		//LoadSealedData<SpaceNPCReplacerStruct>();
		LoadSealedData<SpaceBirthControllerStruct>();
		LoadSealedData<SpaceBirthControllerShowStruct>();
		LoadSealedData<NPCAIGroupStuct>();
		LoadSealedData<NPCEnterSpaceStruct>();
		LoadSealedData<NPCHPPercEventStruct>();
		LoadSealedData<NPCBirthPropertyStruct>();
		LoadSealedData<NPCBirthPositionStruct>();
        LoadSealedData<NPCSpellStruct>();
        LoadSealedData<SpaceObjectBirthPositionStruct>();
		LoadSealedData<SpaceAuraBirthPositionStruct>();
		LoadSealedData<NPCConfigStruct>();
		LoadSealedData<NPCLevelStruct>();
		//LoadSealedData<NPCSpellStruct>();
		//LoadSealedData<NPCPrivateLootStruct>();
		LoadSealedData<NPCExStruct>();
		LoadSealedData<NPCStruct>();
		LoadSealedData<SpaceObjectStruct>();
		LoadSealedData<SpaceRouteStruct>();
		LoadSealedData<ScoreRankPositionStruct>();
		LoadSealedData<ScoreRankStruct>();
		LoadSealedData<MailTypeStruct>();
		LoadSealedData<LootItem1Struct>(true);
		//LoadSealedData<LootItem2Struct>();
		//LoadSealedData<LootItem3Struct>();
		//LoadSealedData<LootItem5Struct>();
		//LoadSealedData<LootItem6Struct>();
		LoadSealedData<LootScaleStruct>();
		LoadSealedData<LootStruct>(true);
		LoadSealedData<CoolingDownStruct>();
		LoadSealedData<ScriptDurationStruct>();
		LoadSealedData<RankRewardStruct>();
		//LoadSealedData<PlayerFirstNameStruct>();
		//LoadSealedData<PlayerSecondMaleNameStruct>();
		//LoadSealedData<PlayerSecondFemaleNameStruct>();
		LoadSealedData<ForbidedStringStruct>();
		LoadSealedData<GuildPositionStruct>();
		LoadSealedData<GuildActivityStruct>();
		LoadSealedData<GuildLevelStruct>();
		LoadSealedData<AccumulateLoginRewardStruct>();
		LoadSealedData<AccumulateLoginInActivityRewardStruct>();
        LoadSealedData<StoryStruct>();
        LoadSealedData<GoalStruct>();
		//LoadSealedData<ServerConfigStruct>();
		//LoadSealedData<ProgramConfigStruct>();
		//LoadSealedData<AccountStruct>();
		LoadSealedData<GameStaticsPointStruct>();
		LoadSealedData<TimeBoardStruct>();
		//LoadSealedData<RPCStruct>();
		LoadSealedData<GMCommandAliasStruct>();
		LoadSealedData<ActivityScriptStruct>();
		LoadSealedData<ScoreStruct>();
		LoadSealedData<ScoreMarketItemStruct>();
		LoadSealedData<GameFuncStruct>();
		LoadSealedData<GameFuncPolicyStruct>();
		LoadSealedData<NotifyStruct>();
		LoadSealedData<ActivityStruct>();
		LoadSealedData<HintStruct>();
		LoadSealedData<KeyboardSlotStruct>();
		//
		LoadSealedData<ColorStruct>();
		LoadSealedData<SimpleAvatarStruct>(true);
		LoadSealedData<RTTStruct>();
		LoadSealedData<VisualNPCShowStruct>();
		LoadSealedData<VisualNPCStruct>();
		LoadSealedData<EntityHintStruct>();
		LoadSealedData<VisualProgressBarStruct>();
		LoadSealedData<VisualLoadingStruct>();
		LoadSealedData<VisualSpaceEventDescStruct>();
		LoadSealedData<VisualSpellStruct>();
        LoadSealedData<VisualSpellEffectStruct>();
        LoadSealedData<VisualItemStruct>();
		LoadSealedData<Icon3DStruct>();
        LoadSealedData<EquipInfoStruct>();
        LoadSealedData<ViAvatarDurationVisualStruct>();
		LoadSealedData<SpaceCameraStruct>();
		LoadSealedData<AttributeDisplayFomatStruct>();
		LoadSealedData<VisualHeroStruct>();
		LoadSealedData<VisualSpaceStruct>();
		LoadSealedData<VisualNPCBirthPositionStruct>(true);
		LoadSealedData<MessageBoxStruct>();
		LoadSealedData<UIEventStruct>();
		LoadSealedData<GoalDisplayTypeStruct>();
		LoadSealedData<DayGiftStruct>();
		LoadSealedData<VisualExpressionStruct>();
		LoadSealedData<MusicStruct>(true);
        //LoadSealedData<SpaceHeroStandardPropertyStruct>();
        LoadSealedData<PlayerInitStruct>();
		LoadSealedData<SpaceHeroLevelStruct>();
		LoadSealedData<SpaceHeroLevelEffectStruct>();
		LoadSealedData<GraphicsLevelStruct>();
		LoadSealedData<VisualPartyMatchStruct>();
        LoadSealedData<VisualSpaceRegionStruct>();
        LoadSealedData<VisualEnvironmentStruct>();
        LoadSealedData<VisualCorner>();
        LoadSealedData<VisualCornerList>();
        LoadSealedData<MaskWordStruct>();
        LoadSealedData<TaskStruct>();
        //LoadSealedData<DeviceEmulatorStruct>();
        //
        if (SealedDataEditor)
		{
			LoadSealedData<SpaceReplacerStruct>();
			LoadSealedData<SpaceNPCReplacerStruct>();
			LoadSealedData<SpaceBirthControllerStruct>();
			LoadSealedData<NPCPrivateLootStruct>();
		}
		//
		_loadingEvent.Reset(this.ResourceLoaded);
		_loadingEvent.Wait("VIB");
    }

    void OnVIBCompleted0()
	{
		BroadcastFomatString();
		_loadingEvent.Complete("VIB");
    }

	void OnVIBCompleted1()
	{
		_loadingEvent.Complete("VIB");
		WordFilterInstance.Start();
		GameDataManagerEx.Initialize();
		_completed = true;
    }

    void OnAddLoadFile(string sName)
    {
        if (!mWaitLoadList.Contains(sName))
        {
            mWaitLoadList.Add(sName);
        }
    }

    void OnFinish0Load(string sName)
    {
        mWaitLoadList.Remove(sName);
        if (mWaitLoadList.Count <= 0)
        {
            OnVIBCompleted0();
        }
    }

    void OnFinish1Load(string sName)
    {
        mWaitLoadList.Remove(sName);
        if (mWaitLoadList.Count <= 0)
        {
            OnVIBCompleted1();
        }
    }

    public void ResourceLoaded()
	{
		if (DataCompletedCallback != null)
		{
			DeleDataCompleted callback = DataCompletedCallback;
			DataCompletedCallback = null;
			callback();
		}
	}

	void BroadcastFomatString()
	{
		List<FormatStringStruct> infoList = ViSealedDB<FormatStringStruct>.Array;
		for (int iter = 0; iter < infoList.Count; ++iter)
		{
			FormatStringStruct iterInfo = infoList[iter];
			ViFomatString.Dictionary.Set(iterInfo.Name, iterInfo.Value);
			ViFomatString.Dictionary.Broadcast();
            I18NManager.Instance.Append(iterInfo.Name, iterInfo.Value);
        }
		ViSealedDB<FormatStringStruct>.Clear();
	}
    public delegate void LoadFile(string sName);

    public static LoadFile mAddLoad = null;
    public static LoadFile mFinishLoad = null;

    static List<string> mWaitLoadList = new List<string>();

	ViWorkFlowEvent _loadingEvent = new ViWorkFlowEvent();
	bool _completed;
}

