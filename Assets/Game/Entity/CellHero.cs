using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
//
public class CellHero : GameUnit, ViRPCEntity, ViEntity
{
	public static CellHero LocalHero { get { return GameApplication.Instance.Client.LocalHero; } }
	public static ViEntityID LocalHeroID
	{
		get
		{
			if (LocalHero != null)
			{
				return LocalHero.ID;
			}
			else
			{
				return 0;
			}
		}
	}

    public bool IsSelf { get { return ID == LocalHeroID; } }

	public static Faction LocalFaction
	{
		get
		{
			if (LocalHero != null)
			{
				return LocalHero.Faction;
			}
			else
			{
				return Faction.PLAYER_0;
			}
		}
	}

	public static UInt8 LocalFactionIdx
	{
		get
		{
			if (LocalHero != null)
			{
				return (UInt8)((UInt8)LocalHero.Faction - (UInt8)(Faction.PLAYER_0));
			}
			else
			{
				return 0;
			}
		}
	}

	public override string Name { get { return Property.NameAlias; } }
	public override float BodyRadius { get { return LogicInfo.BodyRadius * 0.01f; } }
	public override float BodyHeight { get { return VisualInfo.GetBodyHeight(); } }
	public override float FireHeight { get { return LogicInfo.ShotHeight * 0.01f; } }
	public override float FireWidthOffset { get { return LogicInfo.ShotWidthOffset * 0.01f; } }
	public override bool WeaponFireShake { get { return IsLocal; } }
	public new CellHeroReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public HeroStruct LogicInfo { get { return _logicInfo; } }
	public VisualHeroStruct VisualInfo { get { return _visualInfo; } }
    ViAsynCallback<ViReceiveDataNode, object> spellCallback = new ViAsynCallback<ViReceiveDataNode, object>();
    ViAsynCallback<ViReceiveDataNode, object> _HeroPropertyCallbackFocusEntity = new ViAsynCallback<ViReceiveDataNode, object>();
    
    public void SetProperty(CellHeroReceiveProperty property)
	{
		_property = property;
		base.SetProperty(property);
	}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<CellHeroReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
        _property.FocusEntity.CallbackList.Attach(_HeroPropertyCallbackFocusEntity, this._OnHeroFocusEntityUpdated);
        _property.SpellList.CallbackList.Attach(spellCallback, _OnSpellUpdated);
        base.SetProperty(_property);
	    if (IsSelf)
	        UIManager.Instance.Show(UIControllerDefine.WIN_FightWindow);
    }
	public void EndProperty()
	{
		_property.EndProperty(this);
        _HeroPropertyCallbackFocusEntity.End();
	    if (IsSelf)
	        UIManager.Instance.Hide(UIControllerDefine.WIN_FightWindow);

	}
	public void ClearProperty()
	{
		ViReceiveDataCache<CellHeroReceiveProperty>.Free(_property);
		_property = null;
	}

	public new void Start()
	{
		base.Start();
		//
		UpdateInfo();
		Property.Info.CallbackList.Attach(_propertyCallbackOnInfo, this._OnInfoUpdated);
		if (IsLocal)
		{
			Property.ScriptProgressList.UpdateArrayCallbackList.Attach(_scriptProgressCallback, this._OnScriptProgressUpdated);
		}
		Property.XP.CallbackList.Attach(_propertyCallbackOnXP, this._OnXPUpdated);
        Property.SP.CallbackList.Attach(_propertyCallbackOnSP, this._OnSPUpdated);
		Property.Level.CallbackList.Attach(_propertyCallbackOnLevel, this._OnLevelUpdated);
        Property.CallbackList.Attach(_propertyCallbackOnAll, _OnAllAttrUpdated);
		//
		if (VisualInfo.EnterShow.Empty())
		{
			VisualSpaceStruct visualSpaceInfo = ViSealedDB<VisualSpaceStruct>.Data(GameSpaceRecordInstance.Instance.Property.Info);
			if (visualSpaceInfo.EntityEnterShow.NotEmpty())
			{
				FreeSpaceExpressEx enterShow = new FreeSpaceExpressEx();
				enterShow.CameraAnim = IsLocal;
				enterShow.Start(visualSpaceInfo.EntityEnterShow.Data, PosProvider, 0.0f, 0.0f, 3.0f);
			}
		}
        //Property.ActionStateMask.CallbackList.Attach(_propertyCallbackOnActionState, this._OnActionStateUpdated);

    }

	public new void AftStart()
	{
		base.AftStart();
	}
    void _OnHeroFocusEntityUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
    {//focus對象改變時
        FocusManager.Instance.FocusStateChange(this.ID, this.Property.FocusEntity);
    }

    void _OnSpellUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
    {
        XLColorDebug.LogUI("技能改变 刷新界面");
        for (int i = 0; i < Property.SpellList.Count; i++)
        {
            XLColorDebug.LogUI(string.Format("id={0}，index={1}", Property.SpellList[i].Property.Info.Value.ID, Property.SpellList[i].Property.SetupIdx.Value));
        }
        UIManagerUtility.RefreshTalent();
    }

    public new void ClearCallback()
	{
		base.ClearCallback();
		//
		_propertyCallbackOnInfo.End();
		_scriptProgressCallback.End();
		_propertyCallbackOnXP.End();
	}

	public new void PreEnd()
	{
		//
		base.PreEnd();
	}

	public override void OnVisualLoad0()
	{
		base.OnVisualLoad0();
		//
		if (IsLocal)
		{
			CellPlayerServerInvoker.CompleteHeroLoad(CellPlayer.Instance);
            EventDispatcher.TriggerEvent(Events.SceneCommonEvent.CreatedLocalHeroModel);
        }
        //
        //float enterSpaceReserveDuration = 0;
        //if (HasAura(GameAuraDataInstance.HeroSpaceEnter.ID, out enterSpaceReserveDuration))
        //{
        //    float enterSpaceDuration = ViMathDefine.Max(LogicInfo.WorkingSwitch.EnterDuration * 0.01f, 1.0f);
        //    float enterSpaceProgress = (1 - enterSpaceReserveDuration / enterSpaceDuration);
        //    if (VisualBody.Anim != null)
        //    {
        //        string enterAnim = ViSealedDB<VisualSpaceStruct>.Data(CellPlayer.Instance.Property.Space).EntityEnterAnim;
        //        VisualBody.AnimController.Play(VisualBody.Anim, enterAnim, ViMathDefine.Clamp(enterSpaceProgress, 0.01f, 1.0f), false);
        //    }
        //    if (VisualInfo.EnterShow.NotEmpty())
        //    {
        //        AddAvatarDurationVisual(VisualInfo.EnterShow);
        //    }
        //}
        
    }
    private void _updateNameBillBoard()
    {
        string name = this.Property.NameAlias;
        string title = "";
        string finalStr = null;
        if (UIUtility.IsHostile(this))
            finalStr = UIUtility.MakeNameBillBoardStr_Hostile(name, title);
        else
            if (this.ID != CellHero.LocalHeroID)//firend or alliance
            finalStr = UIUtility.MakeNameBillBoardStr_Firend(name, title);
        else
            finalStr = UIUtility.MakeNameBillBoardStr_Myself(name, title);//my self

        if (_nameBillBoard == null && SuperTextManager.Instance != null)
        {
            //ViProvider<ViVector3> pos = new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight * 1.5f));
            _nameBillBoard = SuperTextManager.Instance.SpwanNameBillBoard(finalStr, HeadPosProvider);
        }
        else
        {
            if (_nameBillBoard != null)
                _nameBillBoard.SetText(finalStr);
        }
    }
	public void MessageBox(ViString title, ViString content)
	{
		//ViewControllerManager.PrintMSGView.SetMessage(content);
	}

	public void DebugMessage(ViString title, ViString content)
	{
		EntityMessageController.OnDebugMessage(title, content);
	}

	public void OnBroadCastPing(Int64 time)
	{
		ViDebuger.CritOK("OnBroadCastPing: " + time + ", Diff: " + (time * 0.01f - UnityEngine.Time.time).ToString(".00") + ", Application.PING: " + Client.Current.PingValue);
	}

	public void OnDeactiveByPlayer()
	{
		string exitAnim = ViSealedDB<VisualSpaceStruct>.Data(CellPlayer.Instance.Property.Space).EntityExitAnim;
		if (!string.IsNullOrEmpty(exitAnim))
		{
			DestroyType.Add("Hide", 20, AvatarDestroyType.EXIT);
			DestroyAnim.Add("Hide", 20, ViSealedDB<VisualSpaceStruct>.Data(CellPlayer.Instance.Property.Space).EntityExitAnim);
		}
		//
		if (VisualInfo.LeaveShow.NotEmpty())
		{
			AddAvatarDurationVisual(VisualInfo.LeaveShow);
		}
	}

	public void RollbackMove(ViVector3 pos, float yaw)
	{
		SetPos(pos, yaw);
	}

    public override void OnMoveToAnim()
    {
        if(ViMask32.HasAny(Property.ActionStateMask, (Int32)ActionStateMask.BATTLING))
        {
            VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim, AnimationData.Run03, true);
            VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, true);
        }
        else
        {
            VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim, AnimationData.Run, true);
            VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, true);
        }
    }


    public void MoveLockACK(ViRPCCallback<UInt8> result)
	{
		result.Invoke(this, ViRPCSide.CELL, 0);
	}

	public void OnLeaveSpace()
	{

	}

	public void OnSpaceActionStart(SpaceObject obj, float duration)
	{

	}

	public void OnSpaceActionEnd(SpaceObject obj)
	{

	}


    override public void OnDie()
    {
        base.OnDie();
        if(IsLocal)
        {
            HeroController.Instance.EndAoIHint();
            UIManager.Instance.Show(UIControllerDefine.WIN_Resurrection);
        }

    }
    public void OnNPCLoot(CellNPC entity, Int32 XP, Int32 yinPiao, List<ItemCountProperty> itemList)
	{
		if (XP > 0)
		{
            if(GlobalGameObject.Instance.Icon3D_XP != null)
            {
                _LootExpress("XP", CenterPosition, entity.CenterPosition, GlobalGameObject.Instance.Icon3D_XP.RealObject);
            }
		}
		if (yinPiao > 0)
		{
            if(GlobalGameObject.Instance.Icon3D_YinPiao != null)
            {
                _LootExpress("YinPiao", CenterPosition, entity.CenterPosition, GlobalGameObject.Instance.Icon3D_YinPiao.RealObject);
            }
		}
		for (int iter = 0; iter < itemList.Count; ++iter)
		{
			ItemCountProperty iterCount = itemList[iter];
			VisualItemStruct iterInfo = ViSealedDB<VisualItemStruct>.Data(iterCount.Info);
			GlobalGameObjectNode icon3D = GlobalGameObject.Instance.GetIcon3D(iterInfo.Icon3D);
			if (icon3D != null)
			{
				_LootExpress(iterInfo.Name, CenterPosition, entity.CenterPosition, icon3D.RealObject);
			}
		}
	}

	void _LootExpress(string name, ViVector3 rootPos, ViVector3 pos, GameObject res)
	{
		GameObject iterGameObject = UnityAssisstant.Instantiate(res, pos.Convert(), Quaternion.identity);
		iterGameObject.name = name;
		iterGameObject.layer = (int)UnityLayer.LOOT;
		//Rigidbody iterRigbody = CharactorExplosion.AddRigidbody(iterGameObject);
		ViVector3 direction = pos - rootPos;
		direction.Normalize();
		ViMath2D.Rotate(direction.x, direction.y, ViRandom.Value(-100, 100) * 0.005f * ViMathDefine.PI_HALF, ref direction.x, ref direction.y);
		//CharactorExplosion.AddForce(iterRigbody, direction * LootExpress.VALUE_LootExpressForce, 1.0f);
		LootExpress express = new LootExpress();
		express.Start(iterGameObject, CenterPosProvider);
		OwnExpressList.Add(express);
	}

    public void OnMeleeWithoutTarget()
    {
        OnMeleeAttackOnce(null);
    }

    public void OnSpotLight()
	{

	}

	//public void OnSpotLight(UInt8 defaultLight, List<UInt64> entityList, float density, float duration)
	//{
	//	if (IsLocal)
	//	{
	//		SceneConfig sceneConfig = GameSpace.ActiveInstance.Controller.SceneConfigProperty;
	//		if (sceneConfig == null)
	//		{
	//			return;
	//		}
	//		//
	//		sceneConfig.IsActiveSpotLight = true;
	//		sceneConfig.SpotLightDuration = duration;
	//		sceneConfig.ResetSpotLight();
	//	}
	//}

	public void OnWinShow()
	{
		CellHero.LocalHero.OnHitVisual(VisualInfo.WinShowAction);
		CellHero.LocalHero.VisualBody.IdleAnimName.DefaultValue = AnimationData.Idle02;
	}

	public void OnLoseShow()
	{

	}
    public void CollectSpaceObject(int id,int duration)
    {
        if (IsLocal)
        {
            EventDispatcher.TriggerEvent<int,int>(Events.SceneCommonEvent.CollectSpaceObjectStart, id, duration);
        }
    }
    public void OnNPCDie(int birthID,int npcID)
    {
        if (IsLocal)
        {
            EventDispatcher.TriggerEvent<int>(Events.BattleEvent.BattleWaveDie, birthID);
        }
    }
    public void OnWaveLoaded(int birthID)
    {
        if (IsLocal)
        {
            EventDispatcher.TriggerEvent<int>(Events.BattleEvent.BattleWaveLoaded, birthID);
        }
    }
    public void EnterSpaceObject(int birthID)
    {
        if (IsLocal)
        {
            EventDispatcher.TriggerEvent<int>(Events.BattleEvent.ArriveWaveCenter, birthID);
        }
    }

    public float GetSpPrecent()
    {
        if (Property.SPMax0 > 0)
            return (float) Property.SP / Property.SPMax0;
        return 0;
    }

    override public void OnMoveEnd()
    {
        if (IsLocal)
        {
            EventDispatcher.TriggerEvent<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd,HeroController.Instance.AutoPathType);
        }
    }
    override public void BreakMove()
    {
        if (IsLocal)
        {
            EventDispatcher.TriggerEvent(Events.PlayerEvent.PlayerBreakMove);
        }
    }
    public override void OnMeleeAttackOnce(GameUnit TargetEntity)
    {

        string[] Attacks = new string[] { AnimationData.Attack01, AnimationData.Attack02, AnimationData.Attack03, AnimationData.Attack06, AnimationData.Attack07};
        Int32 idx = ViRandom.Value(0, 4);
        VisualBody.PlayActionAnim(Attacks[idx], true);


        uint spelid = (uint)ViRandom.Value(1,5);
        this.OnSpellCast(spelid, null);
       // VisualBody.AnimController.Play()
        // callback 
    }

	#region PropertyCallback
	void UpdateInfo()
	{
		_logicInfo = Property.Info.Value;
		_visualInfo = ViSealedDB<VisualHeroStruct>.Data(Property.Info);
		SimpleAvatarStruct avatarInfo = _visualInfo.Avatar.Data;
		//
		Scale.DefaultValue = VisualInfo.GetBodyScale();
		MoveAnimStantardSpeed.DefaultValue = avatarInfo.GetRunStandardSpeed();
		YawCursorDuration.DefaultValue = 3.14f / avatarInfo.GetRotateSpeed();
		//
		List<ViForeignKeyStruct<PathFileResStruct>> partList = new List<ViForeignKeyStruct<PathFileResStruct>>();
		//AvatarCreator.MergePart(avatarInfo.PartResource, partList);
		//AvatarCreator.MergePart(Weapon.PartResource, partList);
		SetVisual(avatarInfo.BodyResource.Resource.Data, partList);
	}
    #region JustForEditorMode
    public void UpdateInfoForEditor(int nAvatarIndex, int vType)
    {
        //_logicInfo = Property.Info.Value;
        SimpleAvatarStruct avatarInfo = null;
        if (vType == 0)
        {
            _visualInfo = ViSealedDB<VisualHeroStruct>.Array[nAvatarIndex];
            avatarInfo = _visualInfo.Avatar.Data;
        }
        else
        {
            _visualInfo = ViSealedDB<VisualHeroStruct>.Array[1];
            VisualNPCStruct view = ViSealedDB<VisualNPCStruct>.Array[nAvatarIndex];
            avatarInfo = view.Avatar.Data;
        }
        
        Scale.DefaultValue = avatarInfo.GetScale();
        MoveAnimStantardSpeed.DefaultValue = avatarInfo.GetRunStandardSpeed();
        YawCursorDuration.DefaultValue = 3.14f / avatarInfo.GetRotateSpeed();
        //
        List<ViForeignKeyStruct<PathFileResStruct>> partList = new List<ViForeignKeyStruct<PathFileResStruct>>();
        //AvatarCreator.MergePart(avatarInfo.PartResource, partList);
        //AvatarCreator.MergePart(Weapon.PartResource, partList);
        Yaw = 180;
        SetVisual(avatarInfo.BodyResource.Resource.Data, partList);

        ViIStream speed = new ViIStream();

        ViOStream ddd = new ViOStream();
        ddd.Append(600);
        speed.Init(ddd.Cache, 0, ddd.Length);

        Property.MoveSpeed0.Start(UInt16.MaxValue, speed, null);
    }
    #endregion

    void _OnInfoUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		UpdateInfo();
	}
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnInfo = new ViAsynCallback<ViReceiveDataNode, object>();

	ViAsynCallback<UInt32, ReceiveDataProgressProperty> _scriptProgressCallback = new ViAsynCallback<UInt32, ReceiveDataProgressProperty>();
	void _OnScriptProgressUpdated(UInt32 eventID, UInt32 template, ReceiveDataProgressProperty node)
	{
		//ViewControllerManager.UpdateProgress();
	}

	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnXP = new ViAsynCallback<ViReceiveDataNode, object>();
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnSP = new ViAsynCallback<ViReceiveDataNode, object>();
    ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnLevel = new ViAsynCallback<ViReceiveDataNode, object>();
    ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnAll = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnXPUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
	    var con = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
        if(con.NotNull())
            con.RefreshAttr();
		UpdateLevel();
	}
    public void _OnSPUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
	    UIManagerUtility.GetFightController().UpdateLocalPlayerBoom(GetSpPrecent());
	}

    void _OnLevelUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
	    ViVisualHitEffectStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(Player.LevelUpEffectId.Value);
	    for (int iter = 0; iter < visualInfo.express.Length; ++iter)
	    {
	        ViAttachExpressStruct iterInfo = visualInfo.express[iter];
	        if (!iterInfo.IsEmpty())
	        {
	            CellHero.LocalHero.OnEffectVisual(null, iterInfo, ViVector3.ZERO, null);
	        }
	    }
        if (IsSelf)
        {
            EventDispatcher.TriggerEvent<int>(Events.PlayerEvent.PlayerLevelUpdated, 0);
        }        
    }
    void _OnAllAttrUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
        var con = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
	    if (con.NotNull())
	        con.RefreshAttr();
    }

    

    //
    public override void OnActionStateUpdated(UInt32 newState, UInt32 oldState)
    {
        base.OnActionStateUpdated(newState, oldState);

        //
        if (ViMask32.HasAny(newState, (Int32)ActionStateMask.BATTLING) && !ViMask32.HasAny(oldState, (Int32)ActionStateMask.BATTLING))
        {
            Debug.Log("Enter Battle State!!");
            //VisualBody.AnimController.MoveLayer.SetDefault(null, AnimationData.Idle03);
        }

        //if(ViMask32.HasAny(oldState, (Int32)ActionStateMask.BATTLING) && !ViMask32.HasAny(newState, (Int32)ActionStateMask.BATTLING))
        //{
        //    Debug.Log("Enter Battle State!!");
        //    VisualBody.AnimController.MoveLayer.SetDefault(null, AnimationData.Idle);

        //}
    }
    #endregion

    #region Name Billboard
    public override ViArrayIdx BillBoardStartDepth
	{
		get
		{
			return ID == LocalHeroID ? 100 : 80;
		}
	}
	public override void UpdateNameBillBoard()
	{
        if (GameSpaceRecordInstance.Instance == null)
        {
            return;
        }
        VisualSpaceStruct currentSpace = ViSealedDB<VisualSpaceStruct>.Data(GameSpaceRecordInstance.Instance.Property.Info.Value.ID);
        if (!ViMask32.HasAny(currentSpace.HeroHint.Value, (int)VisualSpaceStruct.VisualEntityHintMask.NAME))
        {
            NameShow.Add("Space", 250, false);
        }
        else
        {
            NameShow.Del("Space");
        }
        if (!ViMask32.HasAny(currentSpace.HeroHint.Value, (int)VisualSpaceStruct.VisualEntityHintMask.HP))
        {
            HPShow.Add("Space", 250, false);
        }
        else
        {
            HPShow.Del("Space");
        }
        //
        if (Dead)
        {
            LevelShow.Del("NotDead");
        }
        else
        {
            LevelShow.Add("NotDead", 50, true);
        }
        //
        base.UpdateNameBillBoard();
        _updateNameBillBoard();

    }

	protected override void UpdateLevel()
	{
		//if (_nameBillboard != null)
		//{
		//	if (LevelShow.Value)
		//	{
		//		IconData bgIcon = IconDataManager.EntityLevel_Red;
		//		if (IsLocal)
		//		{
		//			bgIcon = IconDataManager.EntityLevel_Blue;
		//		}
		//		else if (IsFriend(CellHero.LocalHero))
		//		{
		//			bgIcon = IconDataManager.EntityLevel_Blue;
		//		}
		//		_nameBillboard.SetUnitLevel(Property.Level.Value, bgIcon);
		//		//
		//		SpaceHeroLevelStruct heroLevelInfo = ViSealedDB<SpaceHeroLevelStruct>.GetData(Property.Level + 1);
		//		if (heroLevelInfo != null)
		//		{
		//			float percent = Property.XP.Value * 1.0f / heroLevelInfo.XP;
		//			_nameBillboard.SetUnitLevelXP(percent);
		//		}
		//		else
		//		{
		//			_nameBillboard.SetUnitLevelXP(1.0f);
		//		}
		//	}
		//	else
		//	{
		//		_nameBillboard.HideUnitLevel();
		//	}
		//}
	}

	protected override void UpdateHP()
	{
		//if (_nameBillboard != null)
		{
            if (HPShow.Value)
            {
                //IconData bgIcon = null;
                //IconData fgIcon = null;
                //IconData splitIcon = null;
                float hp = 1.0f * _property.HP.Value/ _property.HPMax0.Value;
                //ViDebuger.Record("----------->CellHero.UpdateHP. cur="+ _property.HP.Value+", total="+ _property.HPMax0.Value);
                if (IsLocal)
                {
                    //bgIcon = IconDataManager.EntityHP_BG_Blue;
                    //fgIcon = IconDataManager.EntityHP_FG_Blue;
                    //splitIcon = IconDataManager.EntityHPSplit_Blue;
                    UIManagerUtility.UpdateLocalPlayerHp(hp);
                    UIManagerUtility.UpdatePlayerHp(_property.HP, _property.HPMax0, hp);
                }
                else if (IsFriend(CellHero.LocalHero))
                {
                    //bgIcon = IconDataManager.EntityHP_BG_Blue;
                    //fgIcon = IconDataManager.EntityHP_FG_Blue;
                    //splitIcon = IconDataManager.EntityHPSplit_Blue;
                    UIManagerUtility.UpdateEnemyHp(this.ID,hp, false);
                }
                else
                {
                    //bgIcon = IconDataManager.EntityHP_BG_Red;
                    //fgIcon = IconDataManager.EntityHP_FG_Red;
                    //splitIcon = IconDataManager.EntityHPSplit_Red;
                    UIManagerUtility.UpdateEnemyHp(this.ID, hp, true);
                }
                //_nameBillboard.SetUnitHP_Hero(_property.HP.Value, _property.HPMaxTotalForClient.Value, bgIcon, fgIcon, splitIcon);
                
            }
            else
            {
                //_nameBillboard.HideUnitHP();
                if (IsLocal)
                    UIManagerUtility.KillLocalPlayerHp();
                else
                    UIManagerUtility.KillHp(this.ID);
            }
        }
	}

	protected override void UpdateBullet()
	{
		//if (_nameBillboard != null)
		//{
		//	if (IsLocal && !Dead)
		//	{
		//		float percent = BulletReserveCount * 1.0f / Property.BulletSlotSize.Value;
		//		_nameBillboard.SetBulletProgress(percent);
		//	}
		//	else
		//	{
		//		_nameBillboard.HideBullet();
		//	}
		//}
	}
	#endregion



	CellHeroReceiveProperty _property;
	HeroStruct _logicInfo;
	VisualHeroStruct _visualInfo;
}
