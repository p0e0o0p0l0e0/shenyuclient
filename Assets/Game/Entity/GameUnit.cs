using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//

public class GameUnit : SpaceEntity, ViGameUnit, ViRPCEntity, ViEntity,IStoryCharacter//, PickalbeInterface
{
	public static ViConstValue<float> VALUE_TransportCameraSmoothMaxDistance = new ViConstValue<float>("TransportCameraSmoothMaxDistance", 18.0f);
	public static ViConstValue<float> VALUE_TransportCameraSmoothSpan = new ViConstValue<float>("TransportCameraSmoothSpan", 0.3f);
	public static ViConstValue<float> VALUE_RangeAttackSpeed = new ViConstValue<float>("RangeAttackSpeed", 20.0f);
	public static ViConstValue<float> VALUE_WorldSayShowDuration = new ViConstValue<float>("WorldSayShowDuration", 5.0f);

	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();

	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public override bool IsLocal { get { return _asLocal; } }
	public bool Active { get { return _active; } }
	public GameUnitReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public float HPPerc { get { return 1.0f * Property.HP.Value / Property.HPMax0.Value; } }
	public bool Dead { get { return ViMask32.HasAny(Property.ActionStateMask, (Int32)ActionStateMask.DEAD); } }
	public bool DeadOrSoul { get { return ViMask32.HasAny(Property.ActionStateMask, (Int32)ActionStateMask.DEAD + (Int32)ActionStateMask.SOUL); } }
	public Faction Faction { get { return (Faction)Property.Faction.Value; } }
	public virtual UInt32 AttackHitEffectVisualID { get { return 0; } }
	public virtual float AttackedColorizeScale { get { return 1.0f; } }
	public virtual float RangeAttackTravelSpeed { get { return VALUE_RangeAttackSpeed; } }
	public virtual float FireHeight { get { return 1.0f; } }
	public virtual float FireWidthOffset { get { return 0.0f; } }
	public virtual bool WeaponFireShake { get { return true; } }
	public ViExpressOwnList<ViExpressInterface> OwnExpressList { get { return _ownExpressList; } }
	//
	public ViPriorityValue<bool> NameShow { get { return _nameShow; } }
	public ViPriorityValue<bool> HPShow { get { return _HPShow; } }
	public ViPriorityValue<bool> LevelShow { get { return _levelShow; } }
    protected SuperTextManager.SuperTextElement _nameBillBoard = null;

    public void SetProperty(GameUnitReceiveProperty property)
	{
		_property = property;
	}
	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
		_asLocal = asLocal;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}

	public void PreStart()
	{
		Init();
	}

	public void Start()
	{
		GameUnitPropertyWatcherCreator.Start(_property, this);
		//
		_spellProc.Start(this);
        //_PickableNode.Start(VisualBody.)


    }



	public void AftStart()
	{
		Physics.Speed.DefaultValue = Property.MoveSpeed0.Value * 0.01f;
	}

	public void Tick(float deltaTime) { }
	public void ClearCallback()
	{
		_propertyCallbackOnMoveSpeed.End();
		_propertyCallbackOnHP.End();
		_propertyCallbackOnMaxHP.End();
		_propertyCallbackOnAura.End();
		_propertyCallbackOnActionState.End();
		_propertyCallbackOnWeapon.End();
		_propertyCallbackOnBullet.End();
		_propertyCallbackOnBulletReserveCount.End();
		_propertyCallbackOnLevel.End();
		_propertyCallbackOnScriptList.End();
		//
		_fireShowEndTimeNode.Detach();
	}

	public void PreEnd()
	{
		OnBulletClear();
        _bulletRes = null;
		UnityAssisstant.Destroy(ref _weaponFire);
		UnityAssisstant.Destroy(ref _weaponSound);
		//
		_spaceSlotHideDurationVisual.Clear(VisualBody, true);
        if (_nameBillBoard != null)
            SuperTextManager.Instance.CloseTarget( HintType.NAME_BILL_BOARD, _nameBillBoard);
        _nameBillBoard = null;

    }

	public void End()
	{
		//if (_nameBillboard != null)
		//{
		//	_nameBillboard.Clear();
		//	_nameBillboard = null;
		//}
		//
		_spellProc.End();
		_ownExpressList.End();
		_linkExpressList.Clear();
		//
		_HPShow.Clear();
	}

	public void AftEnd()
	{
		_driveExpress.End(true);

        if (_dialogText != null)
        {
            StoryCharacterFactory.DestroyCharacterBubbling(this);
            _dialogText = null;
        }
		//
		Clear();
	}

	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	public void StartInViewData(ViIStream IS)
	{
		SpaceObjectInViewData viewData = new SpaceObjectInViewData();
		viewData.Load(IS);
        //start set physics yaw
        Physics.SetYaw(viewData.Yaw);
        SetPos(viewData.Pos, viewData.Yaw);
		if (viewData.Route.Count > 0)
		{
			OnMoveTo(viewData.Route);
		}
		//
		ForceYawCursor();
		UpdateTransform(0.0f);
	}

	public bool HasActionState(UInt32 mask)
	{
		return ViMask32.HasAny(Property.ActionStateMask, mask);
	}
	public bool HasSpaceState(UInt32 mask)
	{
		return ViMask32.HasAny(Property.SpaceStateMask, mask);
	}
	public bool HasAuraState(UInt32 mask)
	{
		return ViMask32.HasAny(Property.AuraStateMask, mask);
	}
	public void StateNofity(ViGameMessageIdx message, UInt32 reqState, UInt32 curState)
	{
		EntityMessager messager = new EntityMessager();
		messager.Append(reqState);
		messager.Append(curState);
		messager.Send(message, true);
	}
	public bool IsMatch(ViStateConditionStruct condition, bool nofity)
	{
		if (condition == null)
		{
			return true;
		}
		if (condition.reqAuraState != 0)
		{
			if (!HasAuraState((UInt32)condition.reqAuraState))
			{
				if (nofity)
				{
					StateNofity(ViGameMessageIdx.AURA_REQ_STATE_NOT_MATCH, (UInt32)condition.reqAuraState, Property.AuraStateMask);
				}
				return false;
			}
		}
		if (condition.notAuraState != 0)
		{
			if (HasAuraState((UInt32)condition.notAuraState))
			{
				if (nofity)
				{
					StateNofity(ViGameMessageIdx.AURA_NOT_STATE_NOT_MATCH, (UInt32)condition.notAuraState, Property.AuraStateMask);
				}
				return false;
			}
		}
		if (condition.reqActionState != 0)
		{
			if (!HasActionState((UInt32)condition.reqActionState))
			{
				if (nofity)
				{
					StateNofity(ViGameMessageIdx.ACTION_REQ_STATE_NOT_MATCH, (UInt32)condition.reqActionState, Property.ActionStateMask);
				}
				return false;
			}
		}
		if (condition.notActionState != 0)
		{
			Int32 notActionState = condition.notActionState;
			ViMask32.Del(ref notActionState, (Int32)ActionStateMask.MOVING);// 暂时移动不作为客户端判断条件(服务器使用)
			if (HasActionState((UInt32)notActionState))
			{
				if (nofity)
				{
					StateNofity(ViGameMessageIdx.ACTION_NOT_STATE_NOT_MATCH, (UInt32)condition.notActionState, Property.ActionStateMask);
				}
				return false;
			}
		}
		if (condition.reqSpaceState != 0)
		{
			if (!HasSpaceState((UInt32)condition.reqSpaceState))
			{
				if (nofity)
				{
					StateNofity(ViGameMessageIdx.SPACE_REQ_STATE_NOT_MATCH, (UInt32)condition.reqSpaceState, Property.SpaceStateMask);
				}
				return false;
			}
		}
		if (condition.notSpaceState != 0)
		{
			if (HasSpaceState((UInt32)condition.notSpaceState))
			{
				if (nofity)
				{
					StateNofity(ViGameMessageIdx.SPACE_NOT_STATE_NOT_MATCH, (UInt32)condition.notSpaceState, Property.SpaceStateMask);
				}
				return false;
			}
		}
		return true;
	}

	public bool IsMatch(ViStateConditionStruct condition)
	{
		return IsMatch(condition, false);
	}
	public override void OnVisualLoad0()
	{
		base.OnVisualLoad0();
		//
	}

	public override void OnVisualLoad1()
	{
		base.OnVisualLoad1();
		//
		Property.ActionStateMask.CallbackList.Attach(_propertyCallbackOnActionState, this._OnActionStateUpdated);
        Property.AuraStateMask.CallbackList.Attach(_propertyCallbackOnAuraState, this._OnAuraStateUpdated);
        Property.MoveSpeed0.CallbackList.Attach(_propertyCallbackOnMoveSpeed, this._OnMoveSpeedUpdated);
		Property.HPMax0.CallbackList.Attach(_propertyCallbackOnMaxHP, this._OnHPUpdated);
		Property.HP.CallbackList.Attach(_propertyCallbackOnHP, this._OnHPChanged);
		Property.VisualAuraPropertyList.UpdateArrayCallbackList.Attach(_propertyCallbackOnAura, this._OnAuraListUpdated);
		Property.Level.CallbackList.Attach(_propertyCallbackOnLevel, this._OnLevelUpdated);
		Property.ScriptList.UpdateArrayCallbackList.Attach(_propertyCallbackOnScriptList, this._OnScriptListUpdated);
		//
		OnUpdateMoveSpeed();
		OnUpdateWeapon();
		OnUpdateBullet();
		OnUpdateSpaceHideSlot();
		//
		if (Dead)
		{
			VisualBody.AnimController.DieLayer.Play(VisualBody.Anim, AnimationData.Die, 1.0f, false);
		}
		//
		foreach (ViReceiveDataArrayNode<ReceiveDataVisualAuraProperty> iter in Property.VisualAuraPropertyList.Array)
		{
			VisualAuraWatcher iterAura = (VisualAuraWatcher)iter.Watcher;
			iterAura.OnVisualReady(iter.Property, this);
		}
		//
		UpdateNameBillBoard();
	}

	public override void OnVisuableUpdated()
	{
		base.OnVisuableUpdated();
		//
		UpdateNameBillBoard();
	}


	#region Name Billboard
	public virtual int BillBoardStartDepth { get { return -1; } }
	public virtual void UpdateNameBillBoard()
	{
        //Debug.Log("--------------->UpdateNameBillBoard"+ HeadPosProvider.Value);
		if (Dead)
		{
			NameShow.Add("Dead", 100, false);
			HPShow.Add("Dead", 100, false);
		}
		else
		{
			NameShow.Del("Dead");
			HPShow.Del("Dead");
		}
		//
		if (VisualActive.Value == false)
		{
			NameShow.Add("Visible", 200, false);
		}
		else
		{
			NameShow.Del("Visible");
		}
		//
		if (ViMask32.HasAny(Property.ActionStateMask, (UInt32)ActionStateMask.END_ATTACKED))
		{
			NameShow.Add("EndAttacked", 10, false);
		}
		else
		{
			NameShow.Del("EndAttacked");
		}
        ////
        //if (_nameBillboard == null)
        //{
        //	_nameBillboard = new RoleHintEx();
        //	_nameBillboard.SetPrefabName(UIResourceName.PREFAB_EnityName, Name, BillBoardStartDepth);
        //	_nameBillboard.SetPosProvider(HeadPosProvider);
        //	_nameBillboard.Start();
        //}
        //
        UpdateHP();
        if (_isUpdateHpPos)
            UIManagerUtility.UpdateHpPosition(this.ID, this.HeadPosProvider);
		UpdateName();
		UpdateLevel();		
		UpdateBullet();
	}

	public virtual string RoleHintName { get { return Name; } }
	protected virtual void UpdateName()
	{
		//if (_nameBillboard != null)
		//{
		//	string name = NameShow.Value ? RoleHintName : string.Empty;
		//	_nameBillboard.SetUnitName(name);
		//}
	}

	protected virtual void UpdateLevel()
	{
		//if (_nameBillboard != null)
		//{
		//	_nameBillboard.HideUnitLevel();
		//}
	}

	protected virtual void UpdateHP()
	{
        //if (HPShow.Value)
        //{
        //    //IconData fgIcon = IconDataManager.EntityHPSmall_FG_Red;
        //    //if (IsFriend(CellHero.LocalHero))
        //    //{
        //    //    fgIcon = IconDataManager.EntityHPSmall_FG_Blue;
        //    //}
        //    _nameBillboard.SetUnitHP(_property.HP.Value, _property.HPMaxTotalForClient.Value, IconDataManager.EntityHPSmall_BG, fgIcon);
        //    float hp = 1.0f * _property.HP.Val / _property.HPMaxTotalForClient.Value;
        //    UIManagerUtility.UpdateEnemyHp(this.ID, hp, );
        //}
        //else
        //{
        //    //_nameBillboard.HideUnitHP();
        //    UIManagerUtility.KillHp(this.ID);
        //}
    }

    internal void OnActionStateUpdated()
    {
        throw new NotImplementedException();
    }

    protected virtual void UpdateBullet()
	{
		//if (_nameBillboard != null)
		//{
		//	_nameBillboard.HideBullet();
		//}
	}

	#endregion


	#region Geo

	public ViVector3 GetAttackPos(GameUnit attacker, Int8 fromDir)
	{
		ViVector3 direction = ViVector3.ZERO;
		ViGeographicObject.GetRotate(fromDir * 0.1f, ref direction.x, ref direction.y);
		float diffDistance = BodyRadius;
		if (attacker != null)
		{
			float attackerDistance = ViGeographicObject.GetHorizontalDistance(attacker.Position, Position);
			if (attackerDistance < BodyRadius + attacker.BodyRadius)
			{
				diffDistance *= attackerDistance / (BodyRadius + attacker.BodyRadius);
			}
		}
		float distanceScale = 0.5f;
		return direction * diffDistance * distanceScale;
	}

    public void OnChargeTo(ViVector3 destPos, float yaw, float duration, UInt8 lockOnGround)
    {
        OnBreakMove(yaw);
		//
        GroundHeight.GetGroundHeight(ref destPos);
        float distance = GetDistance(Position, destPos);
        float speed = distance / duration;
        if (lockOnGround == 0)
        {
            Physics.MoveTo(destPos, false, false);
        }
        else
        {
            Physics.MoveTo(destPos, false, true);
        }
		Physics.Speed.Add("Charge", 10, speed);
		//
		CameraSmooth(Position, destPos);
		//
		//Caller.Invoke((UInt32)GameUnitEvent.CHARGETO);
		//
		ViTimerInstance.SetTime(_chargeEndTimeNode, duration, this.OnChargeEnd);

        /**
        OnBreakMove(Yaw);
        GroundHeight.GetGroundHeight(ref destPos);
        float distance = GetDistance(Position, destPos);
        destPos = Position + distance * 0.25f * Position;
        destPos.z += 10;
        this.PlayActionAnim(AnimationData.HitFly01);
        Physics.MoveTo(destPos, true, false);
        ViTimerInstance.SetTime(_hitFly1, 0.5f, this.OnHitFly1);*/
    }

    public void SetBodyVisiable(UInt8 visiable)
    {
        SetBodyVisiable(visiable == 1);
    }

    public void SetBodyVisiable(bool visiable)
    {
        if (VisualBody != null)
        {
            VisualBody.SetBodyVisiable(visiable);
        }
        if (_nameBillBoard != null)
        {
            _nameBillBoard.SetVisible(visiable);
        }
    }

    public void OnChargeTo(UInt32 visual, ViVector3 destPos, float yaw, float duration, UInt8 lockOnGround)
	{
		OnChargeTo(destPos, yaw, duration, lockOnGround);
		//
		ShowDriveVisual(visual, duration);
	}

    public void OnChargeTo(List<ViVector3> posList, float yaw, float duration, UInt8 lockOnGround)
	{
		OnBreakMove(yaw);
        //
        GroundHeight.GetGroundHeight(posList, 0.0f);
		float distance = ViRoute.GetLength(Position, posList);
		float speed = distance / duration;
        if (lockOnGround == 0)
        {
            Physics.MoveTo(posList, false, false);
        }
        else
        {
            Physics.MoveTo(posList, false, true);
        }

		Physics.Speed.Add("Charge", 10, speed);
		//
		CameraSmooth(distance);
		//
		//Caller.Invoke((UInt32)GameUnitEvent.CHARGETO);
		//
		ViTimerInstance.SetTime(_chargeEndTimeNode, duration, this.OnChargeEnd);
	}

    public void OnChargeTo(UInt32 visual, List<ViVector3> posList, float yaw, float duration, UInt8 lockOnGround)
	{
        OnChargeTo(posList, yaw, duration, lockOnGround);
		//
		ShowDriveVisual(visual, duration);
	}

	public void OnAimChargeTo(ViVector3 destPos, float duration)
	{
		OnBreakMove(Yaw);
        //
        GroundHeight.GetGroundHeight(ref destPos);
		float distance = GetDistance(Position, destPos);
		float speed = distance / duration;
		Physics.MoveTo(destPos, true, true);
		Physics.Speed.Add("Charge", 10, speed);
		//
		CameraSmooth(Position, destPos);
		//
		//Caller.Invoke((UInt32)GameUnitEvent.CHARGETO);
		//
		ViTimerInstance.SetTime(_chargeEndTimeNode, duration, this.OnChargeEnd);
	}

    public void OnChangeToJump(List<ViVector3> posList, float yaw, List<float> durationList)
    {
        if (posList.Count != durationList.Count)
            return;

        OnBreakMove(Yaw);
        ViVector3 destPos = posList[0];
        GroundHeight.GetGroundHeight(ref destPos);
        float distance = GetDistance(Position, destPos);
        destPos = Position + distance * 0.25f * Position;
        destPos.y += 10;
        this.PlayActionAnim(AnimationData.HitFly01);
        Physics.MoveTo(destPos, true, false);
        ViTimerInstance.SetTime(_chargeEndTimeNode, 0.5f, this.OnHitFly1);
    }

	public void OnAimChargeTo(UInt32 visual, ViVector3 destPos, float duration)
	{
		OnAimChargeTo(destPos, duration);
		//
		ShowDriveVisual(visual, duration);
	}
    public void OnFlyTo(ViVector3 startPos, ViVector3 destPos,float yaw,float duration)
    {
        OnBreakMove(yaw);

        const int FLYHEIGHT = 4;
        //起点 终点
        GroundHeight.GetGroundHeight(ref startPos);
        GroundHeight.GetGroundHeight(ref destPos);
        //中点 至高点
        ViVector3 midPos = (startPos + destPos) / 2;
        //选择最高处
        float high = Mathf.Max(startPos.z, destPos.z) + FLYHEIGHT;
        GroundHeight.GetGroundHeight(ref midPos);
        //和中点地面高度比较，选择最高点
        midPos.z = midPos.z >= high ? (midPos.z + FLYHEIGHT / 2) : high;
        List<ViVector3> posList = new List<ViVector3>();
        posList.Add(startPos);
        posList.Add(midPos);
        posList.Add(destPos);
        float distance = ViRoute.GetLength(Position, posList);
        float speed = 17;
        if (duration <= 0)
            duration = 0.5f;
        else
            speed = distance / duration;
        Physics.MoveTo(posList, false);
        Physics.Speed.Add("Charge", 10, speed);
        CameraSmooth(distance);
        ViTimerInstance.SetTime(_chargeEndTimeNode, duration, this.OnChargeEnd);
    }

    public void FixTimeFlyTo(UInt32 spellID,ViVector3 startPos, ViVector3 destPos,float yaw)
    {
        OnBreakMove(yaw);

        ViSpellStruct spellInfo = ViSealedDB<ViSpellStruct>.Data(spellID);
        VisualSpellStruct visualSpellInfo = ViSealedDB<VisualSpellStruct>.Data(spellID);
        if (spellInfo.IsNull() || visualSpellInfo.IsNull())
            return;
        ViSpellStruct.FlyStruct flyInfo = spellInfo.flyStruct;
        VisualSpellStruct.FlyStruct visualFlyInfo = visualSpellInfo.flyStruct;
        
        GroundHeight.GetGroundHeight(ref startPos);
        GroundHeight.GetGroundHeight(ref destPos);
        ViVector3 midPos = startPos;
        float high = flyInfo.flyHigh * 0.01f;
        List<ViVector3> posList = new List<ViVector3>();
        List<ViVector3> posList1 = new List<ViVector3>();
        float distance = 0;
        float speed = 0;

        switch ((ViSpellFlyType)flyInfo.flyType.Value)
        {
            case ViSpellFlyType.OUT_OF_CAMERA:
                {
                    midPos = destPos;
                    midPos.z += high;
                    posList.Add(midPos);
                    posList1.Add(destPos);
                    CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
                    if (camera != null)
                    {
                        FlyCameraPosDir flyCamera = new FlyCameraPosDir(camera.Position + (destPos - startPos), camera.LookAt + (destPos - startPos), camera.Field);
                        CameraController.Instance.AddController("Fly", 20, flyCamera);
                    }
                    distance = ViRoute.GetLength(Position, posList, false);
                    speed = distance / (flyInfo.upDuration * 0.01f);
                }
                break;
            case ViSpellFlyType.PARABOLA:
                {
                    midPos = (startPos + destPos) / 2;
                    GroundHeight.GetGroundHeight(ref midPos);
                    midPos.z += high;
                    float g = UnityTools.ParabolaLerp(startPos, midPos, 10, high, (flyInfo.upDuration * 0.01f),ref posList);
                    UnityTools.ParabolaLerp(midPos, destPos, 10, midPos.z - destPos.z, (flyInfo.downDuration * 0.01f), ref posList1);
                    speed = Mathf.Sqrt(Mathf.Abs(2 * g * high));
                }
                break;
            case ViSpellFlyType.ORIGIN_OBLIQUE_SPRINT:
                {
                    midPos = startPos;
                    midPos.z += high;
                    posList.Add(midPos);
                    posList1.Add(destPos);
                    distance = ViRoute.GetLength(Position, posList, false);
                    speed = distance / (flyInfo.upDuration * 0.01f);
                }
                break;
            case ViSpellFlyType.TARGET_OBLIQUE_SPRINT:
                {
                    midPos = destPos;
                    midPos.z += high;
                    posList.Add(midPos);
                    posList1.Add(destPos);
                    distance = ViRoute.GetLength(Position, posList, false);
                    speed = distance / (flyInfo.upDuration * 0.01f);
                }
                break;
        }
        Physics.MoveTo(posList, false);
        Physics.Speed.Add("Fly", 10, speed);
        CameraSmooth(distance);
        if (visualFlyInfo.Anim.Array[0].res.IsNotNullOrEmpty())
            PlayActionAnim(visualFlyInfo.Anim.Array[0].res);
        _upTimeNode.Value = new FlyInfo(posList1, flyInfo.airDuration, flyInfo.downDuration, 
            visualFlyInfo.Anim.Array[1].res, visualFlyInfo.Anim.Array[2].res);
        ViTimerInstance.SetTime<FlyInfo>(_upTimeNode, flyInfo.upDuration, this._OnFlyUp);
    }

    ViTimeNodeEx1<FlyInfo> _upTimeNode = new ViTimeNodeEx1<FlyInfo>();
    ViTimeNodeEx1<FlyInfo> _airTimeNode = new ViTimeNodeEx1<FlyInfo>();
    ViTimeNode1 _downTimeNode = new ViTimeNode1();

    void _OnFlyUp(ViTimeNodeInterface node, FlyInfo info)
    {
        Physics.Speed.Del("Fly");

        if (info.AirDuration <= 0)
        {
            _OnFlyAir(null, info);
        }
        else
        {
            if (info.AirAnim.IsNotNullOrEmpty())
            {
                PlayActionAnim(info.AirAnim);
            }
            _airTimeNode.Value = info;
            ViTimerInstance.SetTime<FlyInfo>(_airTimeNode, info.AirDuration, this._OnFlyAir);
        }
    }
    void _OnFlyAir(ViTimeNodeInterface node, FlyInfo info)
    {
        float distance = ViRoute.GetLength(Position, info.PosList, false);
        float speed = distance / (info.DownDuration * 0.01f);
        Physics.MoveTo(info.PosList, false);
        Physics.Speed.Add("Fly", 10, speed);
        CameraSmooth(distance);
        if (info.DownAnim.IsNotNullOrEmpty())
            PlayActionAnim(info.DownAnim);
        ViTimerInstance.SetTime(_downTimeNode, info.DownDuration, this._OnFlyDown);
        info.Clear();
    }
    void _OnFlyDown(ViTimeNodeInterface node)
    {
        Physics.Speed.Del("Fly");
        CameraController.Instance.DelController("Fly");
    }

    void OnChargeEnd(ViTimeNodeInterface node)
    {
        Physics.Speed.Del("Charge");
		//Caller.Invoke((UInt32)GameUnitEvent.CHARGE_END);
	}
	ViTimeNode1 _chargeEndTimeNode = new ViTimeNode1();

    //ViTimeNode1 _hitFly1 = new ViTimeNode1();
   // ViTimeNode1 _hitFly2 = new ViTimeNode1();
    ViTimeNode3 _hitFlyx = new ViTimeNode3();
    ViTimeNode1 _hitFly3 = new ViTimeNode1();
    ViTimeNode1 _hitFly4 = new ViTimeNode1();
   // ViTimeNode1 _hitFly5 = new ViTimeNode1();
    void OnHitFly1(ViTimeNodeInterface node)
    {
        ViVector3 destPos =  (Yaw + 1) * Position;
        //GroundHeight.GetGroundHeight(ref destPos);
       // this.PlayActionAnim(AnimationData.HitFly02);
       // Physics.MoveTo(destPos, true, false);
        //ViTimerInstance.SetTime(_hitFly2, 0.5f, this.OnHitFly2);
        _hitFlyx.Start(ViTimerInstance.Timer, 5, 10);
        _hitFlyx.TickDelegate = _OnMoveTick;
        _hitFlyx.EndDelegate = OnHitFly2;

    }
    private void _OnMoveTick(ViTimeNodeInterface node)
    {
        ViVector3 destPos = (Yaw* _hitFlyx.ReserveCnt * _hitFlyx.ReserveCnt * 0.05f) * Position;
        
        //GroundHeight.GetGroundHeight(ref destPos);
        this.PlayActionAnim(AnimationData.HitFly02);
        Physics.MoveTo(destPos, true, false);
    }

    void OnHitFly2(ViTimeNodeInterface node)
    {
        //ViVector3 destPos = (Yaw + 1) * Position;
        //GroundHeight.GetGroundHeight(ref destPos);
        this.PlayActionAnim(AnimationData.HitFly02);
        //Physics.MoveTo(destPos, true, false);
        ViTimerInstance.SetTime(_hitFly3, 0.5f, this.OnHitFly3);
    }
    void OnHitFly3(ViTimeNodeInterface node)
    {
       // ViVector3 destPos = (Yaw + 1) * Position;
        //GroundHeight.GetGroundHeight(ref destPos);
        this.PlayActionAnim(AnimationData.HitFly03);
        //Physics.MoveTo(destPos, true, true);
        ViTimerInstance.SetTime(_hitFly4, 0.5f, this.OnHitFly4);
    }
    void OnHitFly4(ViTimeNodeInterface node)
    {

    }
    void OnHitFly5(ViTimeNodeInterface node)
    {

    }
    public void OnTransportTo(ViVector3 destPos, float yaw)
	{
		OnBreakMove(yaw);
		//
		CameraSmooth(Position, destPos);
		//
		Position = destPos;
		Yaw = yaw;
	}

	public void OnTransportTo(UInt32 visual, ViVector3 destPos, float yaw)
	{
		OnTransportTo(destPos, yaw);
		//
		ShowDriveVisual(visual, VALUE_TransportCameraSmoothSpan);
	}

	public void ShowDriveVisual(UInt32 visual, float duration)
	{
		ViVisualDriveStruct sendVisual = ViSealedDB<ViVisualDriveStruct>.GetData(visual);
		if (sendVisual != null)
		{
			ViVisualAuraStruct auraVisual = sendVisual.auraVisual.PData;
			if (auraVisual != null)
			{
				_driveExpress.Start(this, VisualBody, auraVisual, EntityAssisstant.GetFactionColor(this, null));
				_driveExpress.SetDuartion(duration);
			}
			if (!string.IsNullOrEmpty(sendVisual.anim.res))
			{
				PlayActionAnim(sendVisual.anim.res);
			}
		}
	}
	DurationExpressEx _driveExpress = new DurationExpressEx();

	public void OnUpdateMoveSpeed()
	{
		Physics.Speed.DefaultValue = (Property.MoveSpeed0) * 0.01f;
		float moveAnimScale = Physics.Speed.DefaultValue / MoveAnimStantardSpeed.Value / Scale.Value;
		VisualBody.SetAnimSpeed(AnimationData.Run, moveAnimScale);
		//VisualBody.SetAnimSpeed(AnimationData.RunForward, moveAnimScale);
		//VisualBody.SetAnimSpeed(AnimationData.RunBackward, moveAnimScale);
		//VisualBody.SetAnimSpeed(AnimationData.RunLeft, moveAnimScale);
		//VisualBody.SetAnimSpeed(AnimationData.RunRight, moveAnimScale);
	}
	#endregion

	public void OnWorldSay(string content)
	{
		OnWorldSay(content, VALUE_WorldSayShowDuration);
	}

	public void OnWorldSay(string content, float duration)
	{
		VisualExpressionStruct info = ViSealedDB<VisualExpressionStruct>.GetData(content);
		if (info != null)
		{
			//if (_nameBillboard == null)
			//{
			//	_nameBillboard = new RoleHintEx();
			//	_nameBillboard.SetPrefabName(UIResourceName.PREFAB_EnityName, Name);
			//	_nameBillboard.SetPosProvider(HeadPosProvider);
			//	_nameBillboard.Start();
			//}
			//
			//IconData icon = IconDataManager.GetIcon(info.Icon);
			//_nameBillboard.SetPaoPaoExpression(icon, info.SpriteDuringList(), duration);
		}
	}

	public void CloseWorldSay()
	{
		//if (_nameBillboard != null)
		//{
		//	//_nameBillboard.ClosePaoPaoExpression(0.0f);
		//}
	}

	public void CloseWorldSay(float delayTime)
	{
		//if (_nameBillboard != null)
		{
		//	_nameBillboard.ClosePaoPaoExpression(delayTime);
		}
	}

	public bool IsFriend(GameUnit entity)
	{
		return EntityRelationChecker.IsFriend(this, entity);
	}
	public bool IsEnemy(GameUnit entity)
	{
		return EntityRelationChecker.IsEnemy(this, entity);
	}

    public bool IsNeutral(GameUnit entity)
	{
		return EntityRelationChecker.IsNeutral(this, entity);
	}

	#region Attack


	public virtual void OnDamageHited(GameUnit attacker)
	{
		PlayActionAnim(AnimationData.Hit);
	}

	public virtual void OnDie()
	{
        VisualBody.AnimController.DieLayer.Play(VisualBody.Anim, AnimationData.Die, 0, true);
        //VisualBody.PlayDieAnim(AnimationData.Die);
        //
        HPShow.Add("Dead", 100, false);
		UpdateNameBillBoard();
        // HeroController.Instance.OnFocusEntity(this.PackID);

        if(CellHero.LocalHero.Property.FocusEntity == this.PackID)
        {
            HeroController.Instance.OnEsc();
        }
    }
	public virtual void OnRevive()
	{
		VisualBody.AnimController.DieLayer.Stop(VisualBody.Anim, AnimationData.Die);
        VisualBody.PlayActionAnim(AnimationData.Idle, true);
        //
        HPShow.Del("Dead");
		UpdateNameBillBoard();

        if (IsLocal)
        {
            UIManager.Instance.Hide(UIControllerDefine.WIN_Resurrection);
        }
	}
	public virtual void OnSoul()
	{
		VisualBody.AnimController.DieLayer.Stop(VisualBody.Anim, AnimationData.Die);
		////////////
		UpdateNameBillBoard();
	}

	#endregion

	#region Bullet

	public void OnShotStart()
	{
		
	}

	public void OnShotEnd()
	{
		DelLookYaw();
	}

	public void OnShotRecover()
	{
		//PlayActionAnim(AnimationData.ChargeBullet);
	}

	List<ViExpressInterface> _bulletList = new List<ViExpressInterface>(256);
	public void OnBulletStart(Int8 yaw, UInt8 ID, UInt8 duration, Int8 speed)
	{
		//WeaponStruct weaponInfo = Weapon;
		//ViVector3 frontDir = ViVector3.ZERO;
		//ViGeographicObject.GetRotate(EntityAssisstant.FormatYaw(yaw), ref frontDir.x, ref frontDir.y);
		//ViVector3 widthDir = ViVector3.ZERO;
		//ViGeographicObject.GetRotate(EntityAssisstant.FormatYaw(yaw) - ViMathDefine.PI_HALF, ref widthDir.x, ref widthDir.y);
		//ViVector3 fromPos = Position + frontDir * (weaponInfo.Shot.Front * 0.01f) + widthDir * FireWidthOffset;
		//fromPos.z += FireHeight;
		//OnBulletStart(weaponInfo, Bullet, ID, EntityAssisstant.FormatYaw(yaw), fromPos, speed, duration * 0.01f);
		////
		//ShowWeaponFire(weaponInfo, fromPos, frontDir);
		////
		//if (IsLocal)
		//{
		//	++_shotCount;
		//	//
		//	UpdateBullet();
		//}
		//else
		//{
		//	AddLookYaw(EntityAssisstant.FormatYaw(yaw));
		//}
	}

	public void OnBulletStart(Int8 yaw, List<UInt8> IDList, List<Int8> yawList, List<UInt8> durationList, Int8 speed)
	{
		//WeaponStruct weaponInfo = Weapon;
		//float width = weaponInfo.Shot.Width * 0.01f;
		//float widthSpan = width / ViMathDefine.Max(IDList.Count - 1, 1);
		//float widthInf = -width * 0.5f;
		////
		//ViVector3 frontDir = ViVector3.ZERO;
		//ViGeographicObject.GetRotate(EntityAssisstant.FormatYaw(yaw), ref frontDir.x, ref frontDir.y);
		//ViVector3 widthDir = ViVector3.ZERO;
		//ViGeographicObject.GetRotate(EntityAssisstant.FormatYaw(yaw) - ViMathDefine.PI_HALF, ref widthDir.x, ref widthDir.y);
		//ViVector3 fromPos = Position + frontDir * (weaponInfo.Shot.Front * 0.01f) + widthDir * FireWidthOffset;
		//fromPos.z += FireHeight;
		//for (int iter = 0; iter < IDList.Count; ++iter)
		//{
		//	OnBulletStart(weaponInfo, Bullet, IDList[iter], EntityAssisstant.FormatYaw(yawList[iter]), fromPos + widthDir * (widthInf + iter * widthSpan), speed, durationList[iter] * 0.01f);
		//}
		////
		//ShowWeaponFire(weaponInfo, fromPos, frontDir);
		////
		//if (IsLocal)
		//{
		//	++_shotCount;
		//	//
		//	UpdateBullet();
		//}
		//else
		//{
		//	AddLookYaw(EntityAssisstant.FormatYaw(yaw));
		//}
	}

	void OnBulletStart(BulletStruct bullet, UInt8 ID, float yaw, ViVector3 fromPos, float speed, float duration)
	{
		if (_bulletRes == null)
		{
			return;
		}
		if (_bulletList.Count <= 0)
		{
			StandardAssisstant.AddValue(_bulletList, 256, null);
		}
		//
		ViVector3 direction = ViVector3.ZERO;
		ViGeographicObject.GetRotate(yaw, ref direction.x, ref direction.y);
		ViVector3 toPos = fromPos + direction * speed * duration;
		SpaceTravelExpress1<ViTrackMotor> express = new SpaceTravelExpress1<ViTrackMotor>();
		express.Motor.Translate = fromPos;
		express.SwitchLayer = EntityAssisstant.GetFactionColor(this, null);
		express.Start(new ViSimpleProvider<ViVector3>(toPos), duration, _bulletRes as GameObject, 0.0f, null);
		_bulletList[ID] = express;
	}

	public void ShowWeaponFire(ViVector3 pos, ViVector3 diretion)
	{
		//PlayActionAnim(AnimationData.Attack);
		//
		if (_weaponFire != null)
        {
            _weaponFire.transform.localPosition = pos.Convert();
			_weaponFire.transform.localRotation = Quaternion.LookRotation(diretion.Convert());
			_weaponFire.SetActive(false);
			_weaponFire.SetActive(true);
		}

		if (_weaponSound == null)
		{
			_weaponSound.transform.localPosition = Position.Convert();
		}
		//
		UnityComponentList<AudioSource>.Begin(_weaponSound);
		for (int iter = 0; iter < UnityComponentList<AudioSource>.List.Count; ++iter)
		{
			AudioSource iterComponent = UnityComponentList<AudioSource>.List[iter];
			iterComponent.time = 0.0f;
			iterComponent.volume = ApplicationSetting.Instance.SoundVolumeScale;
			iterComponent.loop = false;
			iterComponent.spread = 120.0f;
			iterComponent.Play();
		}
		UnityComponentList<AudioSource>.End();

		//
		ViTimerVisualInstance.SetTime(_fireShowEndTimeNode, 1.0f, this.OnTimeEndFireShow);
	}

	ViTimeNode1 _fireShowEndTimeNode = new ViTimeNode1();
	void OnTimeEndFireShow(ViTimeNodeInterface node)
	{
		if (_weaponFire != null)
		{
			_weaponFire.SetActive(false);
		}
	}

	public void OnBulletEnd(UInt8 ID)
	{
		if (ID >= _bulletList.Count)
		{
			return;
		}
		ViExpressInterface express = _bulletList[ID];
		_bulletList[ID] = null;
		if (express != null)
		{
			express.End();
		}
	}

	public void OnBulletClear()
	{
		for (int iter = 0; iter < _bulletList.Count; ++iter)
		{
			ViExpressInterface iterExpress = _bulletList[iter];
			if (iterExpress != null)
			{
				iterExpress.End();
			}
		}
		_bulletList.Clear();
	}


	#endregion


	#region Spell

	public SpellVisualProccess SpellProc { get { return _spellProc; } }
	public ViSpellStruct WorkingSpellInfo { get { return _workingSpellinfo; } }


    public virtual void OnMeleeAttackOnce(GameUnit TargetEntity)
    {
        VisualBody.PlayActionAnim(AnimationData.Attack01, true);
    }
    public void OnSpellPrepare(UInt32 spellID, GameUnit TargetEntity)
	{
		_workingSpellinfo = ViSealedDB<ViSpellStruct>.Data(spellID);
        SetSpellState(SpellState.Prepare);
    }

	public void OnSpellPrepare(UInt32 spellID, ViVector3 TargetPos)
	{
		_workingSpellinfo = ViSealedDB<ViSpellStruct>.Data(spellID);
        SetSpellState(SpellState.Prepare);
    }

	public void OnSpellCast(UInt32 spellID, GameUnit TargetEntity)
	{
        UInt32 checkSpellID = CheckSpellVisualID(spellID);
        VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(checkSpellID);
		SpellProc.OnceExec(this, spellVisual.Proc);
        EventDispatcher.TriggerEvent<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, spellID, this);
        SetSpellState(SpellState.Casting);
    }

	public void OnSpellCast(UInt32 spellID, ViVector3 TargetPos)
	{
        UInt32 checkSpellID = CheckSpellVisualID(spellID);
        VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(checkSpellID);
		SpellProc.OnceExec(this, spellVisual.Proc);
        EventDispatcher.TriggerEvent<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, spellID, this);
        SetSpellState(SpellState.Casting);
    }

    public void OnSpellEffectCast(UInt32 spellEffectID, GameUnit TargetEntity)
    { 
        //TODO
        UInt32 checkSpellID = CheckSpellVisualID(spellEffectID);
        VisualSpellEffectStruct spellVisual = ViSealedDB<VisualSpellEffectStruct>.Data(checkSpellID);
        SpellProc.OnceExec(this, spellVisual.Proc);
        //EventDispatcher.TriggerEvent<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, spellID, this);
        SetSpellState(SpellState.Casting);
    }

    public void OnSpellEffectCast(UInt32 spellEffectID, ViVector3 TargetPos)
    {
        //TODO
        UInt32 checkSpellID = CheckSpellVisualID(spellEffectID);
        VisualSpellEffectStruct spellVisual = ViSealedDB<VisualSpellEffectStruct>.Data(checkSpellID);
        SpellProc.OnceExec(this, spellVisual.Proc);
        //EventDispatcher.TriggerEvent<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, spellID, this);
        SetSpellState(SpellState.Casting);
    }

    private UInt32 CheckSpellVisualID(UInt32 spellID)
    {
        ViSpellStruct visualSpell = ViSealedDB<ViSpellStruct>.Data(spellID);
        // visualSpell.proc.reserve_2 是开始字段
        // visualSpell.proc.reserve_3 是随即个数
        if (visualSpell.proc.reserve_2 > 0)
        {
            int maxID = Math.Max(visualSpell.proc.reserve_3,1);
            do
            {
                spellID = (uint)UnityEngine.Random.Range(1, maxID);
            }
            while (spellID == _randomAttackID);

            _randomAttackID = spellID;

            //如果身上有狂暴状态,普攻触发光环特效播放动作
            if (ViMask32.HasAll(_effectConditionMask, (Int32)ViAuraEffectConditionType.RAGE))
            {
                UpdateAuraEffect(ViAuraEffectConditionType.RAGE, _randomAttackID);
            }

            return spellID + (uint)visualSpell.proc.reserve_2;
        }
        return spellID;

    }

    public void OnSpellCastForEditor(VisualSpellStruct info)
    {
        SpellProc.OnceExec(this, info.Proc);
    }

    public void TravelForEditor(ViTravelExpressStruct pTravelInfo, ViVector3 pos, float duration)
    {
        GroundHeight.GetGroundHeight(ref pos);
        ViTravelExpressStruct travelInfo = pTravelInfo;
        if (travelInfo != null)
        {
            ViSimpleProvider<ViVector3> target = new ViSimpleProvider<ViVector3>(pos + new ViVector3(0, 0, travelInfo.height * 0.01f));
            SpellVisualProccess.Express express = new SpellVisualProccess.Express();
            express.Pos = target;
            express.Info = travelInfo;
            MakeExpress(express.Pos, express.Info, duration, EntityAssisstant.GetFactionColor(this, null), express.EndAttachedTarget);
        }
    }


    public void OnSpellCast(UInt32 spellID, GameUnit entity, float sendTime, float travelDration)
    {
        VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
		SpellProc.OnceExec(this, spellVisual.Proc);
		if (entity != null)
		{
			ViTravelExpressStruct travelInfo = spellVisual.Travel.PData;
			if (travelInfo != null)
			{
				if (travelInfo.res == travelInfo.reserveRes)
				{
					SpellProc.AddTravel(entity.GetPosProvider(travelInfo.destPos), travelInfo, EntityAssisstant.GetFactionColor(this, entity), entity.GetTransform(travelInfo.destPos));
				}
				else
				{
					SpellProc.AddTravel(entity.GetPosProvider(travelInfo.destPos), travelInfo, EntityAssisstant.GetFactionColor(this, entity));
				}
			}
			SpellProc.SetSendTime(sendTime, travelDration);
        }
        EventDispatcher.TriggerEvent<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, spellID, this);
        SetSpellState(SpellState.Casting);
    }

	public void OnSpellCast(UInt32 spellID, ViVector3 pos, float sendTime, float travelDration)
	{
		VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
		SpellProc.OnceExec(this, spellVisual.Proc);
		GroundHeight.GetGroundHeight(ref pos);
		ViTravelExpressStruct travelInfo = spellVisual.Travel.PData;
		if (travelInfo != null)
		{
			ViSimpleProvider<ViVector3> target = new ViSimpleProvider<ViVector3>(pos + new ViVector3(0, 0, travelInfo.height * 0.01f));
			SpellProc.AddTravel(target, travelInfo, EntityAssisstant.GetFactionColor(this, null));
		}
		SpellProc.SetSendTime(sendTime, travelDration);

        EventDispatcher.TriggerEvent<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, spellID, this);
        SetSpellState(SpellState.Casting);
    }

	public void OnSpellCastStart(UInt32 SpellID, GameUnit TargetEntity) { SetSpellState(SpellState.Casting); }

	public void OnSpellCastStart(UInt32 SpellID, ViVector3 TargetPos) { SetSpellState(SpellState.Casting); }

	public void OnSpellCastEnd() { SetSpellState(SpellState.End); }

	public void OnCancelSpell()
	{
		_workingSpellinfo = null;
		//
		SpellProc.EndExec(this, true);

        SetSpellState(SpellState.End);
    }

	public void OnBreakSpell()
	{
		_workingSpellinfo = null;
		//
		SpellProc.EndExec(this, true);

        SetSpellState(SpellState.End);
    }

	public void OnSpellEnd()
	{
		_workingSpellinfo = null;
		//
		SpellProc.StopLoopAnim(this);
		SpellProc.DetachExpressToWorld();
		SpellProc.EndExec(this, false);
        SetSpellState(SpellState.End);
    }

	public void OnCastTo(UInt32 spellID, ViVector3 pos, float duration)
	{
		VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
		GroundHeight.GetGroundHeight(ref pos);
		ViTravelExpressStruct travelInfo = spellVisual.Travel.PData;
		if (travelInfo != null)
		{
			ViSimpleProvider<ViVector3> target = new ViSimpleProvider<ViVector3>(pos + new ViVector3(0, 0, travelInfo.height * 0.01f));
			SpellVisualProccess.Express express = new SpellVisualProccess.Express();
			express.Pos = target;
			express.Info = travelInfo;
			MakeExpress(express.Pos, express.Info, duration, EntityAssisstant.GetFactionColor(this, null), express.EndAttachedTarget);
		}
	}

	public void OnCastTo(UInt32 spellID, GameUnit target, float duration)
	{
		VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
		if (target != null)
		{
			ViTravelExpressStruct travelInfo = spellVisual.Travel.PData;
			if (travelInfo != null)
			{
				SpellVisualProccess.Express express = new SpellVisualProccess.Express();
				if (travelInfo.res == travelInfo.reserveRes)
				{
					express.Pos = target.GetPosProvider(travelInfo.destPos);
					express.EndAttachedTarget = target.GetTransform(travelInfo.destPos);
				}
				else
				{
					express.Pos = target.GetPosProvider(travelInfo.destPos);
				}
				express.Info = travelInfo;
				MakeExpress(express.Pos, express.Info, duration, EntityAssisstant.GetFactionColor(this, target), express.EndAttachedTarget);
			}
			
		}
	}

	public void OnCastTo(UInt32 spellID, ViVector3 fromPos, ViVector3 toPos, float duration)
	{
		VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
		GroundHeight.GetGroundHeight(ref fromPos);
		GroundHeight.GetGroundHeight(ref toPos);
		ViTravelExpressStruct travelInfo = spellVisual.Travel.PData;
		if (travelInfo != null)
		{
			ViSimpleProvider<ViVector3> fromTarget = new ViSimpleProvider<ViVector3>(fromPos + new ViVector3(0, 0, travelInfo.height * 0.01f));
			ViSimpleProvider<ViVector3> toTarget = new ViSimpleProvider<ViVector3>(toPos + new ViVector3(0, 0, travelInfo.height * 0.01f));
			SpellVisualProccess.Express express = new SpellVisualProccess.Express();
			express.Pos = toTarget;
			express.Info = travelInfo;
			MakeExpress(fromTarget, express.Pos, express.Info, duration, EntityAssisstant.GetFactionColor(this, null));

		}
	}

	public void OnCastFrom(UInt32 spellID, ViVector3 fromPos, float duration)
	{
		VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
		GroundHeight.GetGroundHeight(ref fromPos);
		ViTravelExpressStruct travelInfo = spellVisual.Travel.PData;
		if (travelInfo != null)
		{
			SpellVisualProccess.Express express = new SpellVisualProccess.Express();
			if (travelInfo.res == travelInfo.reserveRes)
			{
				express.Pos = GetPosProvider(travelInfo.destPos);
				express.EndAttachedTarget = GetTransform(travelInfo.destPos);
			}
			else
			{
				express.Pos = GetPosProvider(travelInfo.destPos);
			}
			express.Info = travelInfo;
			ViSimpleProvider<ViVector3> fromTarget = new ViSimpleProvider<ViVector3>(fromPos + new ViVector3(0, 0, travelInfo.height * 0.01f));
			MakeExpress(fromTarget, express.Pos, express.Info, duration, EntityAssisstant.GetFactionColor(this, null), express.EndAttachedTarget);
		}
	}

    public void OnHitVisualShadow(UInt32 ID, ViVector3 position, float yaw)
    {
        ViVisualHitEffectStruct effectVisualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(ID);
        if (effectVisualInfo.IsNull())
            return;

        _auraHitDuration = effectVisualInfo.Reserve_2 / 100f;
        if (Time.realtimeSinceStartup - _auraHitFlag > _auraHitDuration)
        {
            OnHitVisual(ID, position, yaw);
            _auraHitFlag = Time.realtimeSinceStartup;
        }
    }

	public void OnHitVisual(UInt32 ID)
	{
		OnHitVisual(ID, Position, Yaw);
	}

	public void OnHitVisual(UInt32 ID, ViVector3 position)
	{
		OnHitVisual(ID, position, Yaw);
	}

	public void OnHitVisual(UInt32 ID, ViVector3 position, Int8 fromDir)
	{
		OnHitVisual(ID, position, fromDir * 0.1f);
	}

	public void OnHitVisual(UInt32 ID, ViVector3 position, float yaw)
	{
		GroundHeight.GetGroundHeight(ref position);
		position.z += 0.05f;
		ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(position);
		ViVisualHitEffectStruct effectVisualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(ID);
        //
        switch ((ViEffectPlayType)effectVisualInfo.effectPlayType.Value)
        {
            case ViEffectPlayType.PUSHALL:
                {
                    for (int iter = 0; iter < effectVisualInfo.express.Length; ++iter)
                    {
                        OnHitVisual(posProvider, effectVisualInfo, yaw, iter);
                    }
                }
                break;
            case ViEffectPlayType.ONEBYONE:
                break;
            case ViEffectPlayType.RANDOM:
                {
                    int length = UnityEngine.Mathf.Min(effectVisualInfo.Reserve_1, effectVisualInfo.express.Length);
                    int iter = UnityEngine.Random.Range(0, length);
                    OnHitVisual(posProvider, effectVisualInfo, yaw, iter);
                }
                break;
        }
        if (BroadcastCameraShake(this, this, effectVisualInfo.cameraShake.Broadcast))
		{
			ViCameraShakeStruct cameraShake = effectVisualInfo.cameraShake.Shake.PData;
			if (cameraShake != null && CameraController.Instance.Camera != null)
			{
				if (UnityAssisstant.WorldPointInViewport(CameraController.Instance.Camera, Position.Convert()))
				{
					ShakeExpressEx shakeExpress = new ShakeExpressEx();
					shakeExpress.SetProvider(PosProvider);
					shakeExpress.Start(effectVisualInfo.cameraShake.DelayTime * 0.01f, cameraShake);
				}
			}
		}
	}

    private void OnHitVisual(ViSimpleProvider<ViVector3> posProvider, ViVisualHitEffectStruct effectVisualInfo, float yaw,int iter)
    {
        ViAttachExpressStruct iterInfo = effectVisualInfo.express[iter];
        if (!iterInfo.IsEmpty())
        {
            FreeSpaceExpressEx express = new FreeSpaceExpressEx();
            express.CameraAnim = IsLocal;
            express.IsLocal = IsLocal;
            express.Scale = iterInfo.Scale;
            express.AttachMask = (UInt32)(iterInfo.attachMask);
            express.Start(iterInfo.res.Data, posProvider, yaw, iterInfo.delayTime * 0.01f, iterInfo.duration * 0.01f);
        }
        //
        ViSoundStruct expressInfo = effectVisualInfo.sound[iter];
        if (!expressInfo.IsEmpty())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = IsLocal;
            express.IsLocal = IsLocal;
            express.Start(expressInfo.Resource.Data, VisualBody.RootTran);
            express.SoundDuration = true;
            _ownExpressList.Add(express);
        }
        //
        if (!effectVisualInfo.anims[iter].IsEmpty())
        {
            PlayActionAnim(effectVisualInfo.anims[iter].res);
        }
    }

    public bool PlaySound(int id)
    {
        PathFileResStruct resourceData = ViSealedDB<PathFileResStruct>.Data(id);
        if (resourceData.IsNotNull())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = IsLocal;
            express.IsLocal = IsLocal;
            express.Start(resourceData, VisualBody.RootTran);
            express.SoundDuration = true;
            _ownExpressList.Add(express);
            return true;
        }
        return false;
    }

    public void OnHitVisualForEditor(ViVisualHitEffectStruct pData)
    {
        OnHitVisualForEditor(pData, Position, Yaw);
       // OnEffectVisual();
        //OnHitEffectVisual();
    }
    public void OnHitVisualForEditor(ViVisualHitEffectStruct pData, ViVector3 position, float yaw)
    {
        ViVisualHitEffectStruct visualInfo = pData;
        for (int iter = 0; iter < visualInfo.express.Length; ++iter)
        {
            ViAttachExpressStruct iterInfo = visualInfo.express[iter];
            if (!iterInfo.IsEmpty())
            {
                OnEffectVisual(this, iterInfo, new ViVector3(), null);
            }
        }
        //
        for (int iter = 0; iter < visualInfo.sound.Length; ++iter)
        {
            ViSoundStruct iterInfo = visualInfo.sound[iter];
            if (!iterInfo.IsEmpty())
            {
                AttachedSpaceExpress express = new AttachedSpaceExpress();
                express.CameraAnim = IsLocal;
                express.IsLocal = IsLocal;
                express.Start(iterInfo.Resource.Data, iterInfo.delayTime * 0.01f, VisualBody.RootTran, ViVector3.ZERO);
                express.SoundDuration = true;
                _ownExpressList.Add(express);
            }
        }
        //
        if (!visualInfo.anims[0].IsEmpty())
        {
            PlayActionAnim(visualInfo.anims[0].res);
        }
        //
        if (BroadcastCameraShake(this, this, visualInfo.cameraShake.Broadcast))
        {
            ViCameraShakeStruct cameraShake = visualInfo.cameraShake.Shake.PData;
            if (cameraShake != null)
            {
                ShakeExpressEx shakeExpress = new ShakeExpressEx();
                shakeExpress.SetProvider(PosProvider);
                shakeExpress.Start(visualInfo.cameraShake.DelayTime * 0.01f, cameraShake);
            }
        }

    }

    public void ShowAuraForEditor(ViVisualAuraStruct pData, float duration)
    {
        ViVisualAuraStruct auraVisual = pData;
        if (auraVisual != null)
        {
            _driveExpress.End(false);
            _driveExpress.Start(this, VisualBody, auraVisual, EntityAssisstant.GetFactionColor(this, null));
            _driveExpress.SetDuartion(duration);
        }
    }

    public bool HasAura(UInt32 ID)
	{
		float reserveDuration = 0;
		return HasAura(ID, out reserveDuration);
	}

	public bool HasAura(UInt32 ID, out float reserveDuration)
	{
		for (int iter = 0; iter < Property.VisualAuraPropertyList.Count; ++iter)
		{
			ReceiveDataVisualAuraProperty iterProperty = Property.VisualAuraPropertyList[iter].Property;
			if (iterProperty.Effect == ID)
			{
				reserveDuration = VisualAuraWatcher.GetReserveDuration(iterProperty) * 0.01f;
				return true;
			}
		}
		reserveDuration = 0;
		return false;
	}

    public void SetSpellState(SpellState state)
    {
        _spellState = state;
    }
    public bool CanNotOperation()
    {
        return _spellState == SpellState.Casting;
    }
    /// <summary>
    /// 是否沉默光环中
    /// </summary>
    /// <returns></returns>
    public bool IsSilence()
    {
        return ViMask32.HasAll(Property.AuraStateMask, (Int32)AuraStateMask.SILENCE);
    }
    #endregion


    #region Visual
    public void AddVisualAuraState(ViEnum32<ViAuraEffectConditionType> effectConditionType)
    {
        if (!ViMask32.HasAll(_effectConditionMask, effectConditionType))
        {
            ViMask32.Add(ref _effectConditionMask, effectConditionType);
        }
    }
    public void RemoveVisualAuraState(ViEnum32<ViAuraEffectConditionType> effectConditionType)
    {
        if (ViMask32.HasAll(_effectConditionMask, effectConditionType))
        {
            ViMask32.Del(ref _effectConditionMask, effectConditionType);
        }
    }
    public void ShootAura(GameUnit caster,uint auraID,ViVector3 targetPos)
    {

    }

    public void UpdateAuraEffect(int auraID,ViVector3 targetPos)
    {
        ViReceiveDataArrayNode<ReceiveDataVisualAuraProperty> iter = 
            Property.VisualAuraPropertyList.Array.Find(
                _item => ((VisualAuraWatcher)_item.Watcher).ID.Equals(auraID));
        if (iter != null)
        {
            VisualAuraWatcher iterAura = (VisualAuraWatcher)iter.Watcher;
            iterAura.UpdateAuraEffect(iter.Property, this , targetPos);
        }
    }

    public void UpdateAuraEffect(ViAuraEffectConditionType effectConditionType,uint index = 0)
    {
        if (effectConditionType == ViAuraEffectConditionType.NONE)
        {
            return;
        }
        foreach (ViReceiveDataArrayNode<ReceiveDataVisualAuraProperty> iter in Property.VisualAuraPropertyList.Array)
        {
            VisualAuraWatcher iterAura = (VisualAuraWatcher)iter.Watcher;
            iterAura.UpdateAuraEffect(iter.Property, this, effectConditionType, ViVector3.ZERO,index);
        }
    }

    public void OnCastVisual(UInt32 visualID, UInt16 sendTime, GameUnit targetEntity, float speed) { }

	public void OnCastVisual(UInt32 visualID, UInt16 sendTime, ViVector3 targetPosition, float speed) { }

	public static bool BroadcastCameraShake(GameUnit caster, GameUnit owner, ViEnum32<BoolValue> broadcast)
	{
		if (broadcast == (UInt32)BoolValue.TRUE)
		{
			return true;
		}
		if (caster != null && caster.IsLocal)
		{
			return true;
		}
		if (owner != null && owner.IsLocal)
		{
			return true;
		}
		return false;
	}

	public void OnHitEffectVisual(GameUnit caster, UInt32 ID)
	{
		ViHitEffectStruct logicInfo = ViSealedDB<ViHitEffectStruct>.Data(ID);
		OnHitEffectVisual(caster, ID, ViVector3.ZERO, logicInfo.Force.PData);
	}

	public void OnHitEffectVisual(GameUnit caster, UInt32 ID, Int8 fromDir)
	{
		ViHitEffectStruct logicInfo = ViSealedDB<ViHitEffectStruct>.Data(ID);
		OnHitEffectVisual(caster, ID, GetAttackPos(caster, fromDir), logicInfo.Force.PData);
	}

	void OnHitEffectVisual(GameUnit caster, UInt32 ID, ViVector3 offset, ViAttackForceStruct force)
	{
		ViVisualHitEffectStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(ID);
        //
        switch ((ViEffectPlayType)visualInfo.effectPlayType.Value)
        {
            case ViEffectPlayType.PUSHALL:
                {
                    for (int iter = 0; iter < visualInfo.express.Length; ++iter)
                    {
                        OnHitEffectVisual(caster, offset, force, visualInfo, iter);
                    }
                }
                break;
            case ViEffectPlayType.ONEBYONE:
                break;
            case ViEffectPlayType.RANDOM:
                {
                    int length = UnityEngine.Mathf.Min(visualInfo.Reserve_1, visualInfo.express.Length);
                    int iter = UnityEngine.Random.Range(0, length);
                    OnHitEffectVisual(caster, offset, force, visualInfo,iter);
                }
                break;
        }
		//
		if (BroadcastCameraShake(caster, this, visualInfo.cameraShake.Broadcast))
		{
			ViCameraShakeStruct cameraShake = visualInfo.cameraShake.Shake.PData;
			if (cameraShake != null)
			{
				ShakeExpressEx shakeExpress = new ShakeExpressEx();
				shakeExpress.SetProvider(PosProvider);
				shakeExpress.Start(visualInfo.cameraShake.DelayTime * 0.01f, cameraShake);
			}
		}
	}

    void OnHitEffectVisual(GameUnit caster,ViVector3 offset, ViAttackForceStruct force,ViVisualHitEffectStruct visualInfo,int iter)
    {
        ViAttachExpressStruct attachInfo = visualInfo.express[iter];
        if (!attachInfo.IsEmpty())
        {
            OnEffectVisual(caster, attachInfo, offset, force);
        }
        //
        ViSoundStruct soundInfo = visualInfo.sound[iter];
        if (!soundInfo.IsEmpty())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = IsLocal;
            express.IsLocal = IsLocal;
            express.Start(soundInfo.Resource.Data, soundInfo.delayTime * 0.01f, VisualBody.RootTran, ViVector3.ZERO);
            express.SoundDuration = true;
            _ownExpressList.Add(express);
        }
        //
        if (!visualInfo.anims[iter].IsEmpty())
        {
            PlayActionAnim(visualInfo.anims[iter].res);
        }
    }


    public void OnAreaHitEffectVisual(GameUnit caster, UInt32 ID, ViVector3 position, float yaw)
	{
		GroundHeight.GetGroundHeight(ref position);
		position.z += 0.05f;
		ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(position);
		ViVisualHitEffectStruct effectVisualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(ID);
		//
		if (effectVisualInfo.attackTipsDuration > 0)
		{
			GameObjectCloneExpressEx express = new GameObjectCloneExpressEx();
			express.SwitchLayer = EntityAssisstant.GetFactionColor(caster, this);
			express.Start(GlobalGameObject.Instance.AOIEffect.GameObject, posProvider, yaw, effectVisualInfo.attackTipsDelayTime, effectVisualInfo.attackTipsDuration, new ViVector3(0.0f, 0.0f, 0.01f), effectVisualInfo.casterEffectRange);
		}
		//
		for (int iter = 0; iter < effectVisualInfo.express.Length; ++iter)
		{
			ViAttachExpressStruct iterInfo = effectVisualInfo.express[iter];
			if (!iterInfo.IsEmpty())
			{
				FreeSpaceExpressEx express = new FreeSpaceExpressEx();
				express.CameraAnim = IsLocal;
                express.IsLocal = IsLocal;
                express.Scale = iterInfo.Scale;
				express.AttachMask = (UInt32)(iterInfo.attachMask);
				express.Start(iterInfo.res.Data, posProvider, yaw, iterInfo.delayTime * 0.01f, iterInfo.duration * 0.01f);
			}
		}
		//
		for (int iter = 0; iter < effectVisualInfo.sound.Length; ++iter)
		{
			ViSoundStruct expressInfo = effectVisualInfo.sound[iter];
			if (!expressInfo.IsEmpty())
			{
				AttachedSpaceExpress express = new AttachedSpaceExpress();
				express.CameraAnim = IsLocal;
                express.IsLocal = IsLocal;
                express.Start(expressInfo.Resource.Data, expressInfo.delayTime * 0.01f, VisualBody.RootTran, ViVector3.ZERO);
				express.SoundDuration = true;
			}
		}
		//
		if (BroadcastCameraShake(caster, this, effectVisualInfo.cameraShake.Broadcast))
		{
			ViCameraShakeStruct cameraShake = effectVisualInfo.cameraShake.Shake.PData;
			if (cameraShake != null && CameraController.Instance.Camera != null)
			{
				if (UnityAssisstant.WorldPointInViewport(CameraController.Instance.Camera, Position.Convert()))
				{
					ShakeExpressEx shakeExpress = new ShakeExpressEx();
					shakeExpress.SetProvider(PosProvider);
					shakeExpress.Start(effectVisualInfo.cameraShake.DelayTime * 0.01f, cameraShake);
				}
			}
		}
	}

	public void OnEffectVisual(GameUnit caster, ViAttachExpressStruct expressInfo, ViVector3 offset, ViAttackForceStruct force)
	{
		OnEffectVisual(caster, expressInfo, offset, force, null);
	}
	public void OnEffectVisual(GameUnit caster, ViAttachExpressStruct expressInfo, ViVector3 offset, ViAttackForceStruct force, ViExpressOwnList<ViExpressInterface> ownList)
	{
		if (ownList == null)
		{
			ownList = _ownExpressList;
		}
		if (ViMask32.HasAny(expressInfo.attachMask, (Int32)ExpressAttachMask.WORLD))
		{
			ViVector3 pos = GetPosProvider(expressInfo.attachPos).Value;
			pos += offset;
			if (force != null)
			{
				pos.z = Position.z + force.Height * 0.01f;
			}
			ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(pos);
			FreeSpaceExpressEx express = new FreeSpaceExpressEx();
			express.CameraAnim = IsLocal;
            express.IsLocal = IsLocal;
            express.Scale = expressInfo.Scale;
			express.AttachMask = (UInt32)(expressInfo.attachMask);
			express.SwitchLayer = EntityAssisstant.GetFactionColor(caster, this);
			express.Start(expressInfo.res.Data, posProvider, Yaw, expressInfo.delayTime * 0.01f, expressInfo.duration * 0.01f);
			if (!ViMask32.HasAny(expressInfo.attachMask, (Int32)ExpressAttachMask.FREE))
			{
				ownList.Add(express);
			}
			else
			{
				_ownExpressList.Add(express);
			}
		}
		else
		{
			AttachedSpaceExpress express = new AttachedSpaceExpress();
			express.CameraAnim = IsLocal;
            express.IsLocal = IsLocal;
            express.Scale = expressInfo.Scale;
			express.SwitchLayer = EntityAssisstant.GetFactionColor(caster, this);
			express.Start(expressInfo.res.Data, GetTransform(expressInfo.attachPos), offset, (UInt32)expressInfo.attachMask, expressInfo.delayTime * 0.01f, expressInfo.duration * 0.01f, expressInfo.fadeTime * 0.01f);
			if (!ViMask32.HasAny(expressInfo.attachMask, (Int32)ExpressAttachMask.FREE))
			{
				ownList.Add(express);
			}
			else
			{
				_ownExpressList.Add(express);
			}
		}
	}

	public void MakeExpress(ViVector3 pos, ViTravelExpressStruct info, float duration, string switchLayer)
	{
		TravelExpressData instanceData = new TravelExpressData();
		ViSimpleProvider<ViVector3> target = new ViSimpleProvider<ViVector3>(pos);
		instanceData.FromPos = GetPosProvider(info.srcPos);
		instanceData.ToPos = target;
		instanceData.Duration = duration;
		instanceData.Resource = info.res;
		instanceData.Gravity = info.gravity * 0.01f;
		instanceData.ReserveTime = info.reserveTime * 0.01f;
		instanceData.ReserveResource = info.reserveRes.Data;
		instanceData.ReserveDirection = (ViTravelEndExpressDirection)info.reserveDirection.Value;
		instanceData.CameraShake = info.HitCameraShake.PData;
		instanceData.SwitchLayer = switchLayer;
		MakeExpress(instanceData);
	}

	public void MakeExpress(ViProvider<ViVector3> pos, ViTravelExpressStruct info, float duration, string switchLayer)
	{
		TravelExpressData instanceData = new TravelExpressData();
		instanceData.FromPos = GetPosProvider(info.srcPos);
		instanceData.ToPos = pos;
		instanceData.Duration = duration;
		instanceData.Resource = info.res;
		instanceData.Gravity = info.gravity * 0.01f;
		instanceData.ReserveTime = info.reserveTime * 0.01f;
		instanceData.ReserveResource = info.reserveRes;
		instanceData.ReserveDirection = (ViTravelEndExpressDirection)info.reserveDirection.Value;
		instanceData.CameraShake = info.HitCameraShake.PData;
		instanceData.SwitchLayer = switchLayer;
		MakeExpress(instanceData);
	}

	public void MakeExpress(ViProvider<ViVector3> pos, ViTravelExpressStruct info, float duration, string switchLayer, UnityEngine.Transform endAttachedTarget)
	{
		TravelExpressData instanceData = new TravelExpressData();
		instanceData.FromPos = GetPosProvider(info.srcPos);
		instanceData.ToPos = pos;
		instanceData.Duration = duration;
		instanceData.Resource = info.res;
		instanceData.Gravity = info.gravity * 0.01f;
		instanceData.ReserveTime = info.reserveTime * 0.01f;
		instanceData.ReserveResource = info.reserveRes;
		instanceData.ReserveDirection = (ViTravelEndExpressDirection)info.reserveDirection.Value;
		instanceData.CameraShake = info.HitCameraShake.PData;
		instanceData.EndAttachedTarget = endAttachedTarget;
		instanceData.SwitchLayer = switchLayer;
		MakeExpress(instanceData);
	}

	public void MakeExpress(ViProvider<ViVector3> fromPos, ViProvider<ViVector3> pos, ViTravelExpressStruct info, float duration, string switchLayer, UnityEngine.Transform endAttachedTarget)
	{
		TravelExpressData instanceData = new TravelExpressData();
		instanceData.FromPos = fromPos;
		instanceData.ToPos = pos;
		instanceData.Duration = duration;
		instanceData.Resource = info.res;
		instanceData.Gravity = info.gravity * 0.01f;
		instanceData.ReserveTime = info.reserveTime * 0.01f;
		instanceData.ReserveResource = info.reserveRes;
		instanceData.ReserveDirection = (ViTravelEndExpressDirection)info.reserveDirection.Value;
		instanceData.CameraShake = info.HitCameraShake.PData;
		instanceData.EndAttachedTarget = endAttachedTarget;
		instanceData.SwitchLayer = switchLayer;
		MakeExpress(instanceData);
	}

	public void MakeExpress(ViProvider<ViVector3> fromPos, ViProvider<ViVector3> toPos, ViTravelExpressStruct info, float duration, string switchLayer)
	{
		TravelExpressData instanceData = new TravelExpressData();
		instanceData.FromPos = fromPos;
		instanceData.ToPos = toPos;
		instanceData.Duration = duration;
		instanceData.Resource = info.res;
		instanceData.Gravity = info.gravity * 0.01f;
		instanceData.ReserveTime = info.reserveTime * 0.01f;
		instanceData.ReserveResource = info.reserveRes;
		instanceData.ReserveDirection = (ViTravelEndExpressDirection)info.reserveDirection.Value;
		instanceData.CameraShake = info.HitCameraShake.PData;
		instanceData.SwitchLayer = switchLayer;
		MakeExpress(instanceData);
	}

	public void MakeExpress(TravelExpressData instanceData)
	{
		if (instanceData.EndAttachedTarget != null)
		{
			SpaceTravelExpress1<ViGravityMotor> express = new SpaceTravelExpress1<ViGravityMotor>();
			express.Motor.Translate = instanceData.FromPos.Value;
			express.Motor.Gravity = instanceData.Gravity;
			express.SwitchLayer = instanceData.SwitchLayer;
			if (instanceData.CameraShake != null && ViRandom.Value(instanceData.CameraShake.Probability * 0.0001f))
			{
				express.HitCameraShake = instanceData.CameraShake;
			}
			express.Start(instanceData.ToPos, instanceData.Duration, instanceData.Resource, instanceData.ReserveTime, instanceData.EndAttachedTarget);
		}
		else
		{
			SpaceTravelExpress<ViGravityMotor> express = new SpaceTravelExpress<ViGravityMotor>();
			express.Motor.Translate = instanceData.FromPos.Value;
			express.Motor.Gravity = instanceData.Gravity;
			express.SwitchLayer = instanceData.SwitchLayer;
			if (instanceData.CameraShake != null && ViRandom.Value(instanceData.CameraShake.Probability * 0.0001f))
			{
				express.HitCameraShake = instanceData.CameraShake;
			}
			express.EndEpressReserveDirection = instanceData.ReserveDirection;
			express.Start(instanceData.ToPos, instanceData.Duration, instanceData.Resource);
		}
	}

	public void OnLinkVisualStart(UInt32 ID, UInt32 visual, GameUnit entity, float flyDuration)
	{
		if (entity == null)
		{
			return;
		}
		ViAttachExpressStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(visual).express[0];
		if (!visualInfo.IsEmpty())
		{
			OnLinkVisualStart(ID, GetPosProvider(visualInfo.attachPos), entity.GetPosProvider((Int32)AvatarAttachNode.MIDDLE), visualInfo.res.Data, flyDuration);
		}
	}

	public void OnLinkVisualStart(UInt32 ID, UInt32 visual, ViVector3 pos, float flyDuration)
	{
		ViAttachExpressStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(visual).express[0];
		if (visualInfo.res.NotEmpty())
		{
			ViProvider<ViVector3> fromPosProvider = GetPosProvider(visualInfo.attachPos);
			ViVector3 fromPos = fromPosProvider.Value;
			ViVector3 fromGroudPos = fromPos;
			GroundHeight.GetGroundHeight(ref fromGroudPos);
			float fromHeight = fromPos.z - fromGroudPos.z;
			//
			GroundHeight.GetGroundHeight(ref pos);
			pos.z += fromHeight;
			OnLinkVisualStart(ID, fromPosProvider, new ViSimpleProvider<ViVector3>(pos), visualInfo.res.Data, flyDuration);
		}
	}

	public void OnLinkVisualStart(UInt32 ID, PathFileResStruct res, ViVector3 pos, float flyDuration)
	{
		OnLinkVisualStart(ID, GetPosProvider((Int32)AvatarAttachNode.RIGHT_WEAPON), new ViSimpleProvider<ViVector3>(pos), res, flyDuration);
	}

	public void OnLinkVisualStart(UInt32 ID, ViProvider<ViVector3> from, ViProvider<ViVector3> to, PathFileResStruct res, float flyDuration)
	{
		LinkExpress existExpress;
		if (_linkExpressList.TryGetValue(ID, out existExpress))
		{
			existExpress.ReLink(from, to, flyDuration, true);
		}
		else
		{
			LinkExpress express = new LinkExpress();
			express.Start(from, to, res, flyDuration);
			_ownExpressList.Add(express);
			_linkExpressList[ID] = express;
		}
	}

	public void OnLinkVisualEnd(UInt32 ID)
	{
		LinkExpress existExpress;
		if (_linkExpressList.TryGetValue(ID, out existExpress))
		{
			existExpress.End();
			_linkExpressList.Remove(ID);
		}
	}

	public void OnLinkVisualEndFrom(UInt32 ID, float duration)
	{
		LinkExpress existExpress;
		if (_linkExpressList.TryGetValue(ID, out existExpress))
		{
			ViProvider<ViVector3> fromPos = existExpress.FromPosProvider;
			existExpress.ReLink(fromPos, fromPos, duration, false);
			existExpress.DelayEnd(duration);
			_linkExpressList.Remove(ID);
		}
	}

	public void OnLinkVisualEndTo(UInt32 ID, float duration)
	{
		//LinkExpress existExpress;
		//if (_linkExpressList.TryGetValue(ID, out existExpress))
		//{
		//    ViProvider<ViVector3> fromPos = existExpress.FromPos;
		//    ViProvider<ViVector3> toPos = existExpress.ToPos;
		//    existExpress.ReLink(toPos, toPos, duration, false);
		//    existExpress.DelayEnd(duration);
		//    _linkExpressList.Remove(ID);
		//}
	}

	public void OnLinkVisualOnce(UInt32 visual, ViVector3 pos, float startDuration, float holdDuration, float endDuration)
	{
		ViAttachExpressStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(visual).express[0];
		if (visualInfo.res.NotEmpty())
		{
			OnLinkVisualOnce(GetPosProvider((Int32)AvatarAttachNode.RIGHT_WEAPON), new ViSimpleProvider<ViVector3>(pos), visualInfo.res.Data, startDuration, holdDuration, endDuration);
		}
	}

	public void OnLinkVisualOnce(UInt32 visual, GameUnit target, float startDuration, float holdDuration, float endDuration)
	{
		if (target == null)
		{
			return;
		}
		ViAttachExpressStruct visualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(visual).express[0];
		if (visualInfo.res.NotEmpty())
		{
			OnLinkVisualOnce(GetPosProvider(visualInfo.attachPos), target.GetPosProvider((Int32)AvatarAttachNode.MIDDLE), visualInfo.res.Data, startDuration, holdDuration, endDuration);
		}
	}

	public void OnLinkVisualOnce(ViProvider<ViVector3> from, ViProvider<ViVector3> to, PathFileResStruct res, float startDuration, float holdDuration, float endDuration)
	{
		LinkExpress express = new LinkExpress();
		express.Start(from, to, res, startDuration);
		express.DelayEnd(holdDuration);
		_ownExpressList.Add(express);
	}

	public void AddAvatarDurationVisual(UInt32 ID)
	{
		AddAvatarDurationVisual(ID, null, 0);
	}
	public void AddAvatarDurationVisual(UInt32 ID, GameUnit caster, Int32 weight)
	{
		ViAvatarDurationVisualStruct info = ViSealedDB<ViAvatarDurationVisualStruct>.GetData(ID);
		if (info == null)
		{
			return;
		}
		VisualBody.DurationVisualOwnList.Add(this, VisualBody, info, weight);
		//
		if (info.hitVisual != 0)
		{
			OnHitEffectVisual(caster, info.hitVisual);
		}
	}

	public void ClearAvatarDurationVisual()
	{
		VisualBody.DurationVisualOwnList.Clear(VisualBody, false);
	}

	public void CameraSmooth(float distance)
	{
		if (!IsLocal)
		{
			return;
		}
		if (distance > VALUE_TransportCameraSmoothMaxDistance)
		{
			CursorCamera camera = CameraController.Instance.GetController("CursorCamera") as CursorCamera;
			if (camera != null)
			{

			}
		}
	}
	public void CameraSmooth(ViVector3 srcPos, ViVector3 destPos)
	{
		GroundHeight.GetGroundHeight(ref srcPos);
		GroundHeight.GetGroundHeight(ref destPos);
		CameraSmooth(ViVector3.Distance(srcPos, destPos));
	}

	ViSpellStruct _workingSpellinfo;
	SpellVisualProccess _spellProc = new SpellVisualProccess();
	ViExpressOwnList<ViExpressInterface> _ownExpressList = new ViExpressOwnList<ViExpressInterface>();
	Dictionary<UInt32, LinkExpress> _linkExpressList = new Dictionary<UInt32, LinkExpress>();
	//

	#endregion


	#region PropertyCallback

	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnActionState = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnActionStateUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		OnActionStateUpdated(Property.ActionStateMask, (UInt32)oldValue);
	}
	public virtual void OnActionStateUpdated(UInt32 newState, UInt32 oldState)
	{
        if (IsLocal)
        {
            //UConsole.Log("OnActionStateUpdated: " + 
            //    ViMask32.HasAll(CellHero.LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_MOVE) + "," + 
            //    ViMask32.HasAll(CellHero.LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_TURN));
            PlayerActionManager.Instance.UpdateActionState();
        }
        UpdateNameBillBoard();
		//
		//if (Dead)
		//{
		//	VisualBody.AnimController.DieLayer.Play(VisualBody.Anim, AnimationData.Die);
		//}
	}
    ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnAuraState = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnAuraStateUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
    {
        OnAuraStateUpdated(Property.AuraStateMask, (UInt32)oldValue);
    }
    public virtual void OnAuraStateUpdated(UInt32 newState, UInt32 oldState)
    {
        if (IsLocal)
        {
           // UConsole.Log("OnAuraStateUpdated: " + ViMask32.HasAll(CellHero.LocalHero.Property.AuraStateMask, (Int32)AuraStateMask.SILENCE));
        }
    }
    //
    ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnMoveSpeed = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnMoveSpeedUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		OnUpdateMoveSpeed();
	}
	//
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnHP = new ViAsynCallback<ViReceiveDataNode, object>();
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnMaxHP = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnHPUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
        EventDispatcher.TriggerEvent<IStoryCharacter, float>(Events.BattleEvent.HpChanged, this,HPPerc);
    }
    void _OnHPChanged(UInt32 eventID, ViReceiveDataNode node, object oldValue)
    {
        //Int32 oldHp = (Int32)oldValue;
        //if (oldHp < this.Property.HP.Value)
        //{
        //    if (SuperTextManager.Instance != null)
        //    {
        //        Int32 addHp = this.Property.HP.Value - oldHp;
        //        SuperTextManager.Instance.SpwanFlyHint("+" + addHp.ToString(), HintType.HEALTH, this.HeadPosProvider.Value.Convert());
        //    }
        //}
        UpdateHP();
        EventDispatcher.TriggerEvent<IStoryCharacter, float>(Events.BattleEvent.HpChanged, this, HPPerc);
    }
    //
    ViAsynCallback<ReceiveDataVisualAuraProperty> _propertyCallbackOnAura = new ViAsynCallback<ReceiveDataVisualAuraProperty>();
	void _OnAuraListUpdated(UInt32 eventID, ReceiveDataVisualAuraProperty node)
	{
		if (eventID == (UInt32)ViDataArrayOperator.INSERT
			|| eventID == (UInt32)ViDataArrayOperator.ADD_BACK
			|| eventID == (UInt32)ViDataArrayOperator.ADD_FRONT)
		{
			ViAuraStruct info = ViSealedDB<ViAuraStruct>.Data(node.Effect);
			//FightDamageTextController.Instance.AddAuraText(CenterPosProvider, IsLeftDir, info.Type.Value);
		}
	}
	//
	GameObject _weaponFire;
	GameObject _weaponSound;
	void OnUpdateWeapon()
	{
		//if (Weapon.Shot.Fire.NotEmpty())
		//{
  //          ResourceMgr.Instance.Load(Weapon.Shot.Fire.Data, (UnityEngine.Object pAsset) =>
  //          {
  //              _weaponFire = UnityAssisstant.Instantiate(pAsset as GameObject);
  //          });
		//}
		//if (Weapon.Shot.Sound.NotEmpty())
		//{
  //          ResourceMgr.Instance.Load(Weapon.Shot.Sound.Data, (UnityEngine.Object pAsset) =>
  //          {
  //              _weaponSound = UnityAssisstant.Instantiate(pAsset as GameObject);
  //          });
		//}
	}
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnWeapon = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnWeaponUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		OnUpdateWeapon();
	}

    UnityEngine.Object _bulletRes = null;
	void OnUpdateBullet()
	{
  //      _bulletRes = null;
  //      //
  //      if (Bullet.Res.NotEmpty())
		//{
  //          ResourceMgr.Instance.Load(Weapon.Shot.Sound.Data, (UnityEngine.Object pAsset) =>
  //          {
  //              _bulletRes = pAsset;
  //          });
		//}
	}
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnBullet = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnBulletUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		OnUpdateBullet();
	}
	//
	ViCallback<ViReceiveDataNode, object> _propertyCallbackOnBulletReserveCount = new ViCallback<ViReceiveDataNode, object>();
	void _OnBulletReserveCountUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		_shotCount = 0;
		//UpdateBullet();
	}
	//
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnLevel = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnLevelUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		UpdateLevel();
	}
	//
	void OnUpdateSpaceHideSlot()
	{
		if (Property.ScriptList.Contain(GameKeyWord.Hide))
		{
			_spaceSlotHideDurationVisual.Add(this, VisualBody, GameAvatarDurationVisualInstance.SpaceSlotHide, 10);
		}
		else
		{
			_spaceSlotHideDurationVisual.Clear(VisualBody, false);
		}
	}
	//
	ViAsynCallback<string> _propertyCallbackOnScriptList = new ViAsynCallback<string>();
	void _OnScriptListUpdated(UInt32 eventID, string key)
	{
		if (StandardAssisstant.EqualsIgnoreCase(key, GameKeyWord.Hide))
		{
			OnUpdateSpaceHideSlot();
		}
	}
	#endregion

	public void PrintHoldResource()
	{
		StringBuilder strBuilder = new StringBuilder();
		//ResHolder.Print(strBuilder);
		ViDebuger.CritOK("[" + Name + "].PrintHoldResource:\n" + strBuilder.ToString());
	}

    public Transform transform {  get { return VisualBody.RootTran; }  }
    public GameObject gameObject { get { return VisualBody.Root; } }
    public GameObject GetDialogText() { return _dialogText; }

    GameObject _dialogText;
   // ViCallback _getDestCallbackNode = new ViCallback();
    public void MoveTo(Vector3 point, Action<object> moveEndCallback = null,object obj = null)
    {
        if (IsLocal)
        {
            CellPlayerServerInvoker.REQ_NavigateTo(CellPlayer.Instance, point.ToViV3());
        }
        if (moveEndCallback != null)
            moveEndCallback(obj);
    }
    public void SetPosition(Vector3 point)
    {
        //服务器人物不能重置位置
    }
    public void Play(string name, float speed = 1, Action callback = null)
    {
        if (callback != null)
            callback();
    }
    public void PlaySkill(int id, GameUnit target, float dir, int hitID, Action callback = null)
    {
        if (callback != null)
            callback();
    }
    public void LookAtPlayer()
    {
    }
    public GameObject CreateDialogText()
    {
        _dialogText = StoryCharacterFactory.CreateCharacterBubbling(ID, transform);
        return _dialogText;
    }

    //entity技能状态
    SpellState _spellState;
    //
    ViEntityID _ID;
	UInt32 _PackID;
	bool _asLocal;
	bool _active;
    uint _randomAttackID = 0;
    Int32 _effectConditionMask;
    GameUnitReceiveProperty _property;
	Int8 _shotCount;
    protected bool _isUpdateHpPos = true;
    //PickableNode _PickableNode = new PickableNode();
  
    //
    //protected RoleHintEx _nameBillboard;
    ViPriorityValue<bool> _nameShow = new ViPriorityValue<bool>(true);
	ViPriorityValue<bool> _HPShow = new ViPriorityValue<bool>(true);
	ViPriorityValue<bool> _levelShow = new ViPriorityValue<bool>(false);
	//
	ViAvatarDurationVisualOwnList<Avatar> _spaceSlotHideDurationVisual = new ViAvatarDurationVisualOwnList<Avatar>();
    float _auraHitFlag = 0;
    float _auraHitDuration = 0;
}
public enum SpellState
{
    Prepare,
    Casting,
    End,
}