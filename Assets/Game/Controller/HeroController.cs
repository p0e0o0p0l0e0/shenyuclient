using System;
using System.Collections.Generic;
using UnityEngine;
using ViEntityID = System.UInt64;

public class HeroController
{
	public static HeroController Instance { get { return _instance; } }
	static HeroController _instance = new HeroController();
	//
	public Client Client { get { return _client; } }
	public CellHero LocalHero { get { return _localHero; } }
	public RoundEntityList RoundEntities { get { return _roundEntityList; } }
	public ViPriorityValue<TouchHandleInterface> TouchHandle { get { return _touchHandle; } }

    public delegate void VectorDelegate(Vector2 delta);

    public static ViConstValue<int> VALUE_RegionCheckSpan = new ViConstValue<int>("ReginCheckSpan", 100);
    
    public AutoPathType AutoPathType { get; private set; }

    //private bool _isTouched = false;

  

    public void GestureEventDrag(DragGesture gesture)
    {

        CursorCamera cameraCursor = CameraController.Instance.CameraPosDir as CursorCamera;
        if (cameraCursor != null)
        {
            if(Math.Abs(gesture.DeltaMove.x / gesture.DeltaMove.y) < 1)
            {
                cameraCursor.Pitch -= gesture.DeltaMove.y * 0.5f;
            }else
            {
                cameraCursor.Yaw -= gesture.DeltaMove.x / 180.0f * 0.5f;
            }
            
            
        }

    }

    public void GestureEventPinch(PinchGesture gesture)
    {

        CursorCamera cameraCursor = CameraController.Instance.CameraPosDir as CursorCamera;
        if (cameraCursor != null)
        {
            cameraCursor.Distance -= gesture.Delta * 0.03f;
        }
    }

    //
    public void Start(CellHero hero, Client client)
	{
		_localHero = hero;
		_client = client;
		//
		RoundEntities.Start();
		//
		hero.Property.ActionStateMask.CallbackList.Attach(_heroPropertyCallbackOnActionState, this._OnHeroActionStateUpdated);
		hero.Property.FocusEntity.CallbackList.Attach(_heroPropertyCallbackFocusEntity, this._OnHeroFocusEntityUpdated);
		//
		_touchHandle.Add("Default", 10, TouchHandle_Default.Instace);

        EventDispatcher.TriggerEvent(Events.SceneCommonEvent.CreatedLocalHero);

        _RegionCheck.Start(ViTimerRealInstance.Timer, (UInt32)VALUE_RegionCheckSpan.Value, this.OnCheckRegionInfo);

        EventDispatcher.AddEventListener<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, _OnPlayerMoveEnd);
        EventDispatcher.AddEventListener(Events.PlayerEvent.PlayerBreakMove, _OnPlayerBreakMove);

        FingerManager.OnDrag += GestureEventDrag;
        FingerManager.OnPinch += GestureEventPinch;

        //UIBackTouchController.Instance.TouchHoldingListener = (PointerEventData data) =>{ _isTouched = true; };
        //UIBackTouchController.Instance.TouchUpListener = (PointerEventData data) => { _isTouched = false; };

    }

    public void End()
    {
        FingerManager.OnDrag -= GestureEventDrag;
        FingerManager.OnPinch -= GestureEventPinch;
        _RegionCheck.Detach();
        EventDispatcher.TriggerEvent(Events.SceneCommonEvent.DestoryLocalHero);
        EventDispatcher.RemoveEventListener<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, _OnPlayerMoveEnd);
        EventDispatcher.RemoveEventListener(Events.PlayerEvent.PlayerBreakMove, _OnPlayerBreakMove);

        EndAoIHint();
		//
		_localHero = null;
		//_localHeroAimHint.End();
		//
		if (_lastTouchHandle != null)
		{
			_lastTouchHandle.OnEnd(this);
		}
		_lastTouchHandle = null;
		_touchHandle.Del("Default");
		//
		GlobalGameObject.Instance.FocusEntity.Detach(false);
		RoundEntities.End();
		_heroPropertyCallbackOnActionState.End();
		_heroPropertyCallbackFocusEntity.End();
	}

	public void Update(float deltaTime)
	{
		//if (LocalHero != null)
		//{
		//	UpdateAimHint(LocalHero, _localHeroAimHint);
		//}
	}

    public void AddTouchHandle(string sName, int nWeight, TouchHandleInterface pHandle)
    {
        _touchHandle.Add(sName, nWeight, pHandle);
    }

    public void RemoveTouchHandle(string sName)
    {
        _touchHandle.Del(sName);
    }


    static void UpdateAimHint(CellHero entity, AimHint _localHeroAimHint)
	{
		//WeaponStruct weaponInfo = entity.Weapon;
		//ViVector3 frontDir = ViVector3.ZERO;
		//ViGeographicObject.GetRotate(entity.Yaw, ref frontDir.x, ref frontDir.y);
		//ViVector3 widthDir = ViVector3.ZERO;
		//ViGeographicObject.GetRotate(entity.Yaw - ViMathDefine.PI_HALF, ref widthDir.x, ref widthDir.y);
		//ViVector3 fromPos = entity.Position + frontDir * (weaponInfo.Shot.Front * 0.01f) + widthDir * entity.FireWidthOffset;
		//fromPos.z += entity.FireHeight;
		//ViVector3 lookAtPos = fromPos + frontDir * weaponInfo.Shot.Distance * 0.01f;
		//GameSpace.ActiveInstance.Navigator.Pick(fromPos, lookAtPos, ref lookAtPos);
		//lookAtPos = fromPos + frontDir * ViVector3.Distance(fromPos, lookAtPos);
		//_localHeroAimHint.Update(fromPos, lookAtPos);
	}

	public UInt32 FocusEntityPackedID
	{
		get
		{
			if (ViEntityAssisstant.IsNullOrEmpty(_localHero))
			{
				return 0;
			}
			else
			{
				return _localHero.Property.FocusEntity;
			}
		}
	}
	public GameUnit FocusEntity { get { return Client.Current.EntityManager.GetPackEntity<GameUnit>(FocusEntityPackedID); } }

	public static ViConstValue<float> VALUE_MouseScrollScale = new ViConstValue<float>("MouseScrollScale", -10.0f);
	public void OnMouseScrolled(float deltaDis)
	{
		CameraPosDirInterface posDir = CameraController.Instance.CameraPosDir;
		if (posDir != null)
		{
			posDir.Distance = posDir.Distance + deltaDis * VALUE_MouseScrollScale;
		}
	}

	public bool OnEsc()
	{
		if (FocusEntity != null)
		{
			CellPlayerServerInvoker.REQ_EndFocus(CellPlayer.Instance);
			return true;
		}
		return false;
	}


    public void OnFocusEntity(UInt32 entityPackedID)
    {
        GameUnit gameUnitEntity = Client.Current.EntityManager.GetPackEntity<GameUnit>(entityPackedID);
        if (gameUnitEntity != null && !gameUnitEntity.Dead)
        {
            CellPlayerServerInvoker.REQ_StartFocus(CellPlayer.Instance, gameUnitEntity);
        }
    }
    public void OnFocusSpaceObject(UInt32 packedID)
    {
        SpaceObject spaceObject = Client.Current.EntityManager.GetPackEntity<SpaceObject>(packedID);
        if (spaceObject != null)
        {
            CellPlayerServerInvoker.REQ_InteractWithObject(CellPlayer.Instance, spaceObject);
        }
    }
    public void OnMoveToNpc(ViVector3 pos)
    {
        MoveTo(pos,AutoPathType.ClickNPC);
    }

    public TouchHandleInterface LastTouchHandle { get { return _lastTouchHandle; } }
	public void OnTouchStart(Vector3 pos)
	{
		TouchHandleInterface handle = _touchHandle.Value;
		if (handle != null && handle.Receivable(this))
		{
			handle.OnPress(this, pos);
			_lastTouchHandle = handle;
		}
	}

	public void OnTouchDrag(Vector3 pos, Vector3 deltaPos)
	{
		if (_lastTouchHandle != null)
		{
			if (_lastTouchHandle.Receivable(this))
			{
				_lastTouchHandle.OnDrag(this, pos, deltaPos);
			}
			else
			{
				_lastTouchHandle.OnBreak(this, pos);
				_lastTouchHandle.OnEnd(this);
				_lastTouchHandle = null;
			}
		}
	}

	public void OnTouchEnd(Vector3 pos)
	{
		if (_lastTouchHandle != null && !_lastTouchHandle.IsPause(this))
		{
			if (_lastTouchHandle.Receivable(this))
			{
				_lastTouchHandle.OnRelease(this, pos);
				_lastTouchHandle.OnEnd(this);
				_lastTouchHandle = null;
			}
			else
			{
				_lastTouchHandle.OnBreak(this, pos);
				_lastTouchHandle.OnEnd(this);
				_lastTouchHandle = null;
			}
		}
	}

	public void OnTouchBreak(Vector3 pos)
	{
		if (_lastTouchHandle != null)
		{
			_lastTouchHandle.OnBreak(this, pos);
			_lastTouchHandle.OnEnd(this);
			_lastTouchHandle = null;
		}
	}

	public void BreakTouch(TouchHandleInterface touch)
	{
		if (System.Object.ReferenceEquals(_lastTouchHandle, touch))
		{
			_lastTouchHandle.OnBreak(this, Vector2.zero);
			_lastTouchHandle.OnEnd(this);
			_lastTouchHandle = null;
		}
		else
		{
			touch.OnEnd(this);
		}
	}

    public void MoveTo(ViVector3 viv3, float stopDistance,AutoPathType type = AutoPathType.JoyStick)
    {
        float dis = ViVector3.DistanceH(CellHero.LocalHero.Position, viv3);
        if (dis <= stopDistance)
        {
            EventDispatcher.TriggerEvent<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, type);
            return;
        }

        ViVector3 pos= (dis - stopDistance) / dis * (viv3 - CellHero.LocalHero.Position) +  CellHero.LocalHero.Position;
        ViVector3 v3 = ViVector3.ZERO;

        if (GameSpace.ActiveInstance.Navigator.GetRoundMovableNew(pos, ref v3))
            MoveTo(v3, type);
        else
            MoveTo(viv3, type);
    }

    public void MoveTo(ViVector3 viv3,AutoPathType type = AutoPathType.JoyStick)
    {
        AutoPathType = type;
        _MovePosList.Clear();
        GameSpace.ActiveInstance.Navigator.Navigate(CellHero.LocalHero.Position, viv3, 10000, _MovePosList);
        MoveTo(_MovePosList);
        EventDispatcher.TriggerEvent<AutoPathType, List<ViVector3>>(Events.PlayerEvent.PlayerNavMove, type,_MovePosList);
        EventDispatcher.TriggerEvent<bool>(Events.PlayerEvent.PlayerPathFinding, true);
    }
	public void MoveTo(List<ViVector3> route)
	{
		if (route.Count > 0)
		{
			if (!ViMask32.HasAll(LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_MOVE))
			{
				CellPlayerServerInvoker.REQ_MoveTo(CellPlayer.Instance, route);
                //LocalHero.OnMoveTo(route);
                EventDispatcher.TriggerEvent<bool>(Events.PlayerEvent.PlayerPathFinding, false);
            }
			else
			{
				CellPlayerServerInvoker.REQ_CancelSpell(CellPlayer.Instance);
			}
		}
	}
    public void StopMove()
    {
        if (CellHero.LocalHero != null)
        {
            CellPlayerServerInvoker.REQ_BreakMoveTo(CellPlayer.Instance);
			_OnPlayerBreakMove ();
        }
    }

	ViAsynCallback<ViReceiveDataNode, object> _heroPropertyCallbackOnActionState = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnHeroActionStateUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		UInt32 newState = LocalHero.Property.ActionStateMask;
		UInt32 oldState = (UInt32)oldValue;
		if (ViMask32.Exit(oldState, newState, (Int32)ActionStateMask.DIS_MOVE))
		{

		}
    }

	ViAsynCallback<ViReceiveDataNode, object> _heroPropertyCallbackFocusEntity = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnHeroFocusEntityUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
    {
        UpdateFocusEntityHint();
	}
	public void UpdateFocusEntityHint()
	{
        GameUnit entity = FocusEntity;
		if (ViEntityAssisstant.IsNullOrEmpty(entity))
		{
			GlobalGameObject.Instance.FocusEntity.Detach(false);
            FocusManager.Instance.CancelFocus(0);
            EventDispatcher.TriggerEvent<GameUnit>(Events.PlayerEvent.SetLockTarget, null);
        }
		else
		{
			UnityAssisstant.SetScale(GlobalGameObject.Instance.FocusEntity.GameObject, entity.BodyRadius);
			GlobalGameObject.Instance.FocusEntity.AttachTo(entity.PosProvider, true);
            UInt64 unitId = 0;
            if (entity.Property.FocusEntity > 0)
            {
                GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(entity.Property.FocusEntity);
                if (unit != null)
                    unitId = entity.Property.FocusEntity;
            }
            FocusManager.Instance.Focus(entity.ID, unitId);
            EventDispatcher.TriggerEvent<GameUnit>(Events.PlayerEvent.SetLockTarget, entity);
        }
	}
    #region AOI
    public ReceiveDataHeroSpellProperty SpellAoIProperty { get { return _spellAoIProperty; } }
	public SpellPositionSelectType SpellAoIType { get { return _spellAoIType; } }
	public void StartAoIHint(ReceiveDataHeroSpellProperty property, ViSpellStruct logicInfo, VisualSpellStruct visualInfo)
	{
		EndAoIHint();
		//
		_spellAoIProperty = property;
		_spellAoIType = (SpellPositionSelectType)visualInfo.Selector.Position.Value;
		_spellAoIHintor = new AOIEffectEx();
		_spellAoIHintor.Init(CellHero.LocalHero.PosProvider, CellHero.LocalHero.Yaw, logicInfo, visualInfo, "Blue");
	}

    public void StartAoIHint(ReceiveDataHeroSpellProperty property, ViSpellStruct logicInfo, VisualSpellStruct visualInfo, float yaw)
    {
        EndAoIHint();
        //
        _spellAoIProperty = property;
        _spellAoIType = (SpellPositionSelectType)visualInfo.Selector.Position.Value;
        _spellAoIHintor = new AOIEffectEx();
        _spellAoIHintor.Init(CellHero.LocalHero.PosProvider, yaw, logicInfo, visualInfo, "Blue");
    }

    public void ChangeAoIhint()
    {
        if (_spellAoIHintor != null)
            _spellAoIHintor._UpdateSpellRangeEffectColor(new Color(0.49411f, 0.05f, 0.0f,0.5f));
        
    }
    public void RestoreAOIHint()
    {
        if (_spellAoIHintor != null)
            _spellAoIHintor._UpdateSpellRangeEffectColor(new Color(0.07f, 0.33f, 0.67f, 0.80f));
    }
    public void EndAoIHint()
	{
		_spellAoIProperty = null;
		if (_spellAoIHintor != null)
		{
			_spellAoIHintor.End();
			_spellAoIHintor = null;
		}
	}

	public void UpdateAoIHint(ViVector3 pos)
	{
        //Debug.Log(pos);
        if (_spellAoIHintor != null)
		{
			_spellAoIHintor.UpdateTagertPos(pos.Convert());
		}
	}

	public ViVector3 GetAoIHintOffset()
	{
		if (_spellAoIHintor != null)
		{
			return _spellAoIHintor.Offset.Convert();
		}
		else
		{
			return LocalHero.Position;
		}
	}

	public bool InAoIHintRange(ViVector3 pos)
	{
		if (_spellAoIHintor != null)
		{
			return ViVector3.DistanceH(LocalHero.Position, pos) <= _spellAoIHintor.LogicInfo.proc.Range.Sup * 0.01f;
		}
		else
		{
			return false;
		}
	}
    #endregion
    public ViVector3 GetSpellPos(ViSpellStruct spellInfo, ViVector3 dir, float scale)
	{
		if (scale > 0.01f && spellInfo.proc.Range.Sup > 0)
		{
			return LocalHero.Position + dir * ViMathDefine.Lerp(spellInfo.proc.Range.Inf * 0.01f, spellInfo.proc.Range.Sup * 0.01f, scale);
		}
		else
		{
			return LocalHero.GetRoundPos(0.0f, ViMathDefine.Max(spellInfo.proc.Range.Inf * 0.01f, 0.1f));
		}
	}

	public ViVector3 GetSpellPos(ViSpellStruct spellInfo, float radius, Vector3 ballPos, out float globalYaw, out float distance)
	{
		float scale = ballPos.magnitude / radius;
		if (scale > 0.01f && spellInfo.proc.Range.Sup > 0)
		{
			Vector3 dir = PickAssisstant.OffsetCamera2World(LocalHero.Position.Convert(), ballPos).normalized;
			globalYaw = ViGeographicObject.GetDirection(dir.x, dir.z);
			distance = ViMathDefine.Lerp(spellInfo.proc.Range.Inf * 0.01f, spellInfo.proc.Range.Sup * 0.01f, scale);
			return LocalHero.Position + dir.Convert() * distance;
		}
		else
		{
			globalYaw = LocalHero.Yaw;
			distance = spellInfo.proc.Range.Inf * 0.01f;
			return LocalHero.GetRoundPos(0.0f, ViMathDefine.Max(distance, 0.1f));
		}
	}

	public static ViConstValue<float> VALUE_AutoLockFocusYawRangeInf = new ViConstValue<float>("AutoLockFocusYawRangeInf", 10.0f * ViMathDefine.Deg2Rad);
	public static ViConstValue<float> VALUE_AutoLockFocusYawRangeSup = new ViConstValue<float>("AutoLockFocusYawRangeSup", 30.0f * ViMathDefine.Deg2Rad);
    public GameUnit AutoFocus(UInt32 societyMask, ViStateConditionStruct condition, AutoFocusType type,  Int32 minRange, Int32 maxRange, ViVector3 diretion, float yawRange)
	{
		ViVector3 angleRootPos = LocalHero.Position - (LocalHero.BodyRadius / ViMathDefine.Sin(yawRange)) * diretion;
		GameUnit entity = null;
        List<GameUnit> entityList = new List<GameUnit>();
		foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
		{
			GameUnit iterEntity = iter.Value as GameUnit;
			if (iterEntity == null)
			{
				continue;
			}
			if (iterEntity.IsLocal)
			{
				continue;
			}
            if (iterEntity.Dead)
            {
                continue;
            }
			if (!iterEntity.VisualActive.Value)
			{
				continue;
			}
			if (!iterEntity.PickActive.Value)
			{
				continue;
			}
            //社会关系是否匹配
			if (!EntityRelationChecker.IsMatch(LocalHero, iterEntity, societyMask))
			{
				continue;
			}
			if (!iterEntity.IsMatch(condition))
			{
				continue;
			}
			//if (ViVector3.Dot(iterEntity.Position - LocalHero.Position + diretion * radius * ViMathDefine.Clamp01((yawRange - ViMathDefine.PI_HALF) / ViMathDefine.PI_HALF), diretion) < 0.0f)
			//{
			//	continue;
			//}
            //超出技能范围
			float iterDistance = iterEntity.GetDistance(LocalHero.Position) * 100;
			if (iterDistance > maxRange)
			{
				continue;
			}
            //超出技能朝向范围
			float iterAngle = ViVector3.Angle((iterEntity.Position - angleRootPos).normalized, diretion);
			if (iterAngle > yawRange)
			{
				continue;
            }
            entityList.Add(iterEntity);
		}
        //如果已经锁定过目标。且在技能范围内，不切换目标
        if (FocusEntity != null)
        {
            int flag = entityList.FindIndex(item=>item.Equals(FocusEntity));
            if (flag >= 0)
            {
                return FocusEntity;
            }
        }
        //根据最优解类型选取目标
        float minTemp = float.MinValue;
        float maxTemp = float.MaxValue;
        for (int i = 0; i < entityList.Count; i++)
        {
            switch (type)
            {
                case AutoFocusType.MINHP:
                    {
                        if (maxTemp > entityList[i].Property.HP)
                        {
                            maxTemp = entityList[i].Property.HP;
                            entity = entityList[i];
                        }
                    }
                    break;
                case AutoFocusType.MAXHP:
                    {
                        if (minTemp < entityList[i].Property.HP)
                        {
                            minTemp = entityList[i].Property.HP;
                            entity = entityList[i];
                        }
                    }
                    break;
                case AutoFocusType.MINDISTANCE:
                    {
                        float iterDistance = entityList[i].GetDistance(LocalHero.Position);
                        if (maxTemp > iterDistance)
                        {
                            maxTemp = iterDistance;
                            entity = entityList[i];
                        }
                    }
                    break;
                case AutoFocusType.MAXDISTANCE:
                    {
                        float iterDistance = entityList[i].GetDistance(LocalHero.Position);
                        if (minTemp < iterDistance)
                        {
                            minTemp = iterDistance;
                            entity = entityList[i];
                        }
                    }
                    break;
                default:
                    break;
            }
        }
		//
		return entity;
	}

	public GameUnit AutoFocus(UInt32 societyMask, ViStateConditionStruct condition, AutoFocusType type, Int32 minRange, Int32 maxRange, float yawRangeScale, ref ViVector3 direction, out float yaw, out float distance)
	{
		float yawRange = ViMathDefine.Lerp(ViMathDefine.Lerp(VALUE_AutoLockFocusYawRangeInf, VALUE_AutoLockFocusYawRangeSup, ApplicationSetting.Instance.AccountProperty.AutoLockFocusScale), ViMathDefine.PI, yawRangeScale);
		GameUnit entity = AutoFocus(societyMask, condition, type, minRange, maxRange,direction, yawRange);
		if (entity != null)
		{
			ViVector3 diff = entity.Position - LocalHero.Position;
			diff.z = 0;
			direction = diff.normalized;
			distance = diff.Length;
        }
		else
		{
			distance = 0.0f;
		}
		yaw = ViGeographicObject.GetDirection(direction.x, direction.y);
		EntityAssisstant.FormatYaw(ref yaw);
		return entity;
	}

    public CellNPC GetNPCByPos(Int32 BirthPosID)
    {
        if (Client.IsNull() ||
       Client.EntityManager.IsNull() ||
       Client.EntityManager.Entitys.IsNull())
        {
            return null;
        }
        CellNPC npc = null;
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
        {
            CellNPC iterNpc = iter.Value as CellNPC;
            if (iterNpc == null)
            {
                continue;
            }
            if (iterNpc.Property == null)
            {
                continue;
            }
            if (iterNpc.Property.BirthPos == BirthPosID)
            {
                npc = iterNpc;
                break;
            }
        }
        return npc;
    }
    public CellNPC GetNPCByPos(Int32 BirthPosID,Int32 BirthPosIndex)
    {
        if (Client.IsNull() ||
           Client.EntityManager.IsNull() ||
           Client.EntityManager.Entitys.IsNull())
        {
            return null;
        }
        CellNPC npc = null;
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
        {
            CellNPC iterNpc = iter.Value as CellNPC;
            if (iterNpc == null)
            {
                continue;
            }
            if (iterNpc.Property == null)
            {
                continue;
            }
            if (iterNpc.Property.BirthPos == BirthPosID && 
                iterNpc.Property.BirthPosIndex == BirthPosIndex)
            {
                npc = iterNpc;
                break;
            }
        }
        return npc;
    }
    public CellNPC GetNPCByID(Int32 NpcID)
    {
        if (Client.IsNull() || 
            Client.EntityManager.IsNull() || 
            Client.EntityManager.Entitys.IsNull())
        {
            return null;
        }
        CellNPC npc = null;
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
        {
            CellNPC iterNpc = iter.Value as CellNPC;
            if (iterNpc == null)
            {
                continue;
            }
            if (iterNpc.LogicInfo.ID == NpcID)
            {
                npc = iterNpc;
            }
        }
        return npc;
    }

    public CellNPC GetNearestNPC()
    {
        CellNPC npc = null;
        float minDistance = float.MaxValue;
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
        {
            CellNPC iterNpc = iter.Value as CellNPC;
            if (iterNpc == null)
            {
                continue;
            }
            float distance = ViVector3.Distance2(CellHero.LocalHero.Position,iterNpc.Position);
            if (minDistance > distance)
            {
                minDistance = distance;
                npc = iterNpc;
            }
        }
        return npc;
    }


    public List<CellHero> GetNearPlayerByDistence(int distance)
    {
        List<CellHero> player = new List<CellHero>();
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
        {
            CellHero iterPlayer = iter.Value as CellHero;
            if (iterPlayer == null)
            {
                continue;
            }
            float dis = ViVector3.Distance2(CellHero.LocalHero.Position, iterPlayer.Position);
            if (distance > dis)
            {
                player.Add(iterPlayer);
            }
        }
        return player;
    }

    public List<Player> GetNearPlayerInfoByDistence(int distance)
    {
        List<Player> player = new List<Player>();
        foreach (KeyValuePair<ViEntityID, ViEntity> iter
                                in Client.EntityManager.Entitys) {
            CellHero iterPlayer = iter.Value as CellHero;
            Player p = iter.Value as Player;
            if ((iterPlayer == null) || (p == null) ) {
                continue;
            }
            float dis = ViVector3.Distance2(CellHero.LocalHero.Position, iterPlayer.Position);
            if (distance > dis)
            {
                player.Add(p);
            }
        }
        return player;
    }

    public SpaceObject GetNearestCollectSpaceObject()
    {
        SpaceObject so = null;
        float minDistance = float.MaxValue;
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in Client.EntityManager.Entitys)
        {
            SpaceObject iterSO = iter.Value as SpaceObject;
            if (iterSO == null)
            {
                continue;
            }
            if (iterSO.Info.Type != (int)SpaceObjectType.COLLECT)
            {
                continue;
            }
            float distance = ViVector3.Distance2(CellHero.LocalHero.Position, iterSO.Position);
            if (distance > 6)
                continue;

            if (minDistance > distance)
            {
                minDistance = distance;
                so = iterSO;
            }
        }
        return so;
    }

    void OnCheckRegionInfo(ViTimeNodeInterface node)
    {
        //_localHero.Position;
        VisualSpaceRegionStruct region = GameSpace.ActiveInstance.VisualInfo.GetSpaceRegion(_localHero.Position);
        if(region != null)
        {
            // UI显示

        }

    }

    private void _OnPlayerBreakMove()
    {
        AutoPathType = AutoPathType.None;
        EventDispatcher.TriggerEvent<bool>(Events.PlayerEvent.PlayerPathFinding, false);
    }
    private void _OnPlayerMoveEnd(AutoPathType type)
    {
        AutoPathType = AutoPathType.None;
        EventDispatcher.TriggerEvent<bool>(Events.PlayerEvent.PlayerPathFinding, false);
    }

    Client _client;
	CellHero _localHero;
	//AimHint _localHeroAimHint = new AimHint();
	//
	RoundEntityList _roundEntityList = new RoundEntityList();
	//
	ViPriorityValue<TouchHandleInterface> _touchHandle = new ViPriorityValue<TouchHandleInterface>(null);
	TouchHandleInterface _lastTouchHandle;
	//
	AOIEffectEx _spellAoIHintor;
	SpellPositionSelectType _spellAoIType;
	ReceiveDataHeroSpellProperty _spellAoIProperty;

    List<ViVector3> _MovePosList = new List<ViVector3>();

    // 区域检测定时器
    ViTimeNode4 _RegionCheck = new ViTimeNode4();

}
public enum AutoPathType
{
    None,
    JoyStick,
    Goal,
    MiniMap,
    ClickNPC,
	AutoFollow,
}