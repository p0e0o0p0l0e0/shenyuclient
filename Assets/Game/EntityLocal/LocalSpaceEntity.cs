using System;
using System.Collections.Generic;
using UnityEngine;
using UInt8 = System.Byte;

public class LocalSpaceEntity : ViGeographicObject, ViEntity,TickInterface, IStoryCharacter,IGoalFlag
{
    public  UInt64 ID { get; set; }
    public Avatar VisualBody { get { return _visualBody; } }
	public SimpleAvatarStruct Info { get { return _info; } }
	public string Name { get { return _name; } set { _name = value; } }
	public BodyPhysics Physics { get { return _bodyPhysics; } }
	public ViPriorityValue<float> Scale { get { return _scale; } }
	public override float BodyRadius { get { return 0.5f; } }
	public override float Yaw
	{
		get { return Physics.Yaw; }
		set { SetYaw(value); }
	}
	public override ViVector3 Position
	{
		get { return Physics.Position; }
		set { SetPos(value); }
	}
    public NPCStruct LogicInfo { get { return _logicInfo; } }
    public ViProvider<ViVector3> PosProvider { get { return Physics.PosProvider; } }
    public ViProvider<ViVector3> FlagProvider { get { return new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight * 1.5f)); } }
    public ViProvider<ViVector3> HeadPosProvider { get { return new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight)); } }
	public ViProvider<ViVector3> CenterPosProvider { get { return new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight * 0.6f)); } }
	public ViVector3 CenterPosition { get { return Physics.Position + new ViVector3(0, 0, BodyHeight * 0.6f); } }
	public virtual float BodyHeight { get { return 2f; } }
	public SpaceNavigator Navigator { get { return _navigator; } }
	public LocalSpaceEntityAI AI { get { return _AI; } }

	public ViPriorityValue<bool> VisualActive { get { return _visuable; } }
	public ViPriorityValue<bool> PickActive { get { return _pickable; } }

	public ViPriorityValue<bool> NameShow { get { return _nameShow; } }

    public LocalSpellVisualProccess SpellProc { get { return _spellProc; } }

    public bool IsReinforcements { get { return _isReinforcements; } set { _isReinforcements = value; } }

    public GameUnit FocusEntity { get { return _focusEntity; } }

    public ViSpellStruct ShowSpell { get; protected set; }

    public int FollowDistance { get; set; }
    public int BirthID{ get; set;}

    public void Start(SimpleAvatarStruct info, NPCStruct npcStruct = null)
	{
		_info = info;

        if (npcStruct != null)
        {
            _logicInfo = npcStruct;
            EventDispatcher.TriggerEvent<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, this);

            this.ShowSpell = npcStruct.ShowSpell;
            NPCSpellStruct npcSpellStruct = ViSealedDB<NPCSpellStruct>.Data(npcStruct.OwnSpell);
            if (npcSpellStruct != null)
            {
                for (int i = 0; i < npcSpellStruct.List.Length; i++)
                {
                    if (npcSpellStruct.List.Array[i].IsNull())
                        continue;
                    if (npcSpellStruct.List.Array[i].Spell.Empty())
                        continue;
                    if (npcSpellStruct.List.Array[i].Spell.PData.IsNull())
                        continue;
                    _ownSpellList.Add(npcSpellStruct.List.Array[i].Spell);
                    _isTargetList.Add(!ViMask32.HasAny(npcSpellStruct.List.Array[i].Spell.PData.proc.focusTargetMask,(int)ViUnitSocietyMask.ENEMY));
                }
            }
            NPCExStruct npcExStruct = ViSealedDB<NPCExStruct>.Data(npcStruct.ID);
            if (npcExStruct.IsNotNull())
            {
                if (npcExStruct.StandardProperty.PData.IsNotNull())
                {
                    Physics.Speed.DefaultValue = npcExStruct.StandardProperty.PData.Attribute.MoveSpeed * 0.01f;
                }
            }

        }
        //
        VisualActive.UpdatedExec = this.OnVisuableUpdated;
		Scale.UpdatedExec = this.OnScaleUpdated;
		//
		_yawCursor.SetSample(3.14f, 3.14f / info.GetRotateSpeed());
        //
        _spellProc.Start(this);
        //
        EventDispatcher.AddEventListener<bool>(Events.SpaceEvent.ChangeSpace, _OnChangeSpace);
    }

	public void End()
	{
        _AI.End();
        _info = null;
        _spellProc.End();
        ShowSpell = null;
        _ownSpellList.Clear();
        _isTargetList.Clear();
        _ownExpressList.End();
        TickManager.Detach(_updateNode);
        VisualActive.UpdatedExec = null;
        Scale.UpdatedExec = null;
        _visualBody.Clear();
        CloseGoalFlag();
        EventDispatcher.RemoveEventListener<GameUnit>(Events.PlayerEvent.SetLockTarget, _OnSetLockTargetCallback);
        EventDispatcher.RemoveEventListener<bool>(Events.SpaceEvent.ChangeSpace, _OnChangeSpace);
    }

	ViDoubleLinkNode2<TickInterface> _updateNode = new ViDoubleLinkNode2<TickInterface>();
	public void Update(float deltaTime)
	{
		bool updateTransform = false;
		//
		Physics.Update(deltaTime);
		//
		Vector3 pos = Position.Convert();
		if ((pos != VisualBody.RootTran.localPosition))
		{
			updateTransform = true;
		}
		if (_yawCursor.Update(deltaTime, Yaw))
		{
			updateTransform = true;
		}
		if (updateTransform)
		{
			UpdateTransform();
		}
	}

	public virtual void OnVisuableUpdated()
	{

	}

	public void OnVisuableUpdated(bool oldValue, bool newValue)
	{
		OnVisuableUpdated();
	}

	public void OnScaleUpdated(float oldValue, float newValue)
	{
		_visualBody.RootTran.localScale = Vector3.one * Scale.Value;
	}

	public void SetTickState(string tag, int weight, bool value)
	{
		_tickable.Add(tag, weight, value);
		UpdateTickState();
	}
	public void ClearTickState(string tag)
	{
		_tickable.Del(tag);
		UpdateTickState();
	}
	void UpdateTickState()
	{
		if (_tickable.Value)
		{
			TickManager.PushBack(_updateNode, this, false);
		}
		else
		{
			_updateNode.Detach();
		}
	}

	public void SetNavigator(SpaceNavigator navigator)
	{
		_navigator = navigator;
    }

    private void _OnChangeSpace(bool enter)
    {
        if (enter)
        {

        }
        else
        {
            End();
        }
    }
    private void _OnSetLockTargetCallback(GameUnit entity)
    {
        _focusEntity = entity;
        ResetAI();
    }
    public bool IsAttackTarget(GameUnit unit)
    {
        //TODO zlj 不是一个阵营，不是自己，必须是敌对的
        if (unit == null)
        {
            return false;
        }
        if (unit.ID > 0 && CellHero.LocalHero.ID != unit.ID)
        {
            if (!unit.Dead)
            {
                return true;
            }
        }
        return false;
    }
    public uint GetCurrentSpellID()
    {
        if (_ownSpellList.Count == 0)
        {
            return 1;
        }
        return (uint)_ownSpellList[0].ID;
    }

    public bool IsCurrentTargetPlayer()
    {
        if (_isTargetList.Count == 0)
        {
            return false;
        }
        return _isTargetList[0];
    }

    public void LookAtTarget(GameUnit target)
    {
        if (target.IsNotNull() && VisualBody.RootTran.IsNotNull())
        {
            VisualBody.RootTran.LookAt(target.transform);
        }
    }
    public int AttackTarget(GameUnit target,uint spellID)
    {
        int temp = 0;
        int maxTime = 0;
        LookAtTarget(target);
        temp = PlayVisualSpellEffect(spellID);
        if (maxTime < temp)
            maxTime = temp;
        ViSpellStruct spell = ViSealedDB<ViSpellStruct>.Data(spellID);
        if (spell.IsNotNull())
        {
            temp = spell.proc.castTime + spell.proc.castEndTime + spell.proc.actCoolTime;
            if (maxTime < temp)
                maxTime = temp;
            temp = spell.proc.coolDuration;
            if (maxTime < temp)
                maxTime = temp;

            if (spell.effect.Array.IsNotNull() && spell.effect.Array.Length > 0)
            {
                for (int i = 0; i < spell.effect.Array.Length; i++)
                {
                    if (spell.effect.Array[i].Empty())
                        continue;
                    temp = PlaySpellEffct(spell.effect.Array[i], target);
                    if (maxTime < temp)
                        maxTime = temp;
                }
            }
        }
        return maxTime;
    }
    public int PlaySpellEffct(int spellEffectID, GameUnit target)
    {
        ViSpellEffectStruct spellEffect = ViSealedDB<ViSpellEffectStruct>.Data(spellEffectID);
        if (spellEffect.IsNull())
            return 0;
        int temp = 0;
        int maxTime = 0;
        for (int i = 0; i < spellEffect.HitEffectInfo.Array.Length; i++)
        {
            if (spellEffect.HitEffectInfo.Array[i].Effect.Empty())
                continue;
            temp = PlayHitEffect(spellEffect.HitEffectInfo.Array[i].Effect, target.Position,target.Yaw);
            if (maxTime < temp)
                maxTime = temp;
        }
        for (int i = 0; i < spellEffect.AuraInfo.Array.Length; i++)
        {
            if (spellEffect.AuraInfo.Array[i].Effect.Empty())
                continue;
            temp = PlayAuraEffect(spellEffect.AuraInfo.Array[i].Effect, target.Position, target.Yaw);
            if (maxTime < temp)
                maxTime = temp;
        }
        return maxTime;
    }
    public int PlayVisualSpellEffect(UInt32 spellID)
    {
        VisualSpellStruct spellVisual = ViSealedDB<VisualSpellStruct>.Data(spellID);
        if (spellVisual != null)
            SpellProc.OnceExec(this, spellVisual.Proc);
        //TODO
        return 300;
    }
    public void OnEffectVisual(LocalSpaceEntity caster, ViAttachExpressStruct expressInfo, ViVector3 offset, ViAttackForceStruct force, ViExpressOwnList<ViExpressInterface> ownList)
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
            express.SwitchLayer = "Red";
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
            express.SwitchLayer = "Red";
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
    /// <summary>
    /// 播放受击特效
    /// </summary>
    /// <param name="hitEffectID"></param>
    /// <param name="position"></param>
    /// <param name="yaw"></param>
    /// <returns></returns>
    public int PlayHitEffect(int hitEffectID,ViVector3 position,float yaw)
    {
        GroundHeight.GetGroundHeight(ref position);
        position.z += 0.05f;
        ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(position);
        ViVisualHitEffectStruct effectVisualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(hitEffectID);
        int maxTime = 0;
        int temp = 0;
        for (int iter = 0; iter < effectVisualInfo.express.Length; ++iter)
        {
            ViAttachExpressStruct iterInfo = effectVisualInfo.express[iter];
            if (!iterInfo.IsEmpty())
            {
                FreeSpaceExpressEx express = new FreeSpaceExpressEx();
                express.CameraAnim = false;
                express.IsLocal = false;
                express.Scale = iterInfo.Scale;
                express.AttachMask = (UInt32)(iterInfo.attachMask);
                express.Start(iterInfo.res.Data, posProvider, yaw, iterInfo.delayTime * 0.01f, iterInfo.duration * 0.01f);

                temp = iterInfo.delayTime + iterInfo.duration + iterInfo.fadeTime;
                if (maxTime < temp)
                    maxTime = temp;
            }
        }
        return maxTime;
    }
    public int PlayAuraEffect(int auraEffectID, ViVector3 position, float yaw)
    {
        GroundHeight.GetGroundHeight(ref position);
        position.z += 0.05f;
        ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(position);
        ViVisualAuraStruct auraEffectInfo = ViSealedDB<ViVisualAuraStruct>.Data(auraEffectID);
        int maxTime = 0;
        int temp = 0;
        for (int iter = 0; iter < auraEffectInfo.express.Length; ++iter)
        {
            ViAttachExpressStruct iterInfo = auraEffectInfo.express[iter];
            if (!iterInfo.IsEmpty())
            {
                FreeSpaceExpressEx express = new FreeSpaceExpressEx();
                express.CameraAnim = false;
                express.IsLocal = false;
                express.Scale = iterInfo.Scale;
                express.AttachMask = (UInt32)(iterInfo.attachMask);
                express.Start(iterInfo.res.Data, posProvider, yaw, iterInfo.delayTime * 0.01f, iterInfo.duration * 0.01f);

                temp = iterInfo.delayTime + iterInfo.duration + iterInfo.fadeTime;
                if (maxTime < temp)
                    maxTime = temp;
            }
        }
        return maxTime;
    }

    public void OnMoveTo(ViVector3 Pos)
	{
		Physics.MoveTo(Pos, true, true);
		Physics.GetDestOnceEventor.Attach(_getDestCallbackNode, this.OnMoveGetDest);
		//
		VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim, AnimationData.Run03, true);
	}

	public void OnMoveTo(List<ViVector3> PosList)
	{
		Physics.MoveTo(PosList, true, true);
		Physics.GetDestOnceEventor.Attach(_getDestCallbackNode, this.OnMoveGetDest);
		//
		VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim, AnimationData.Run03, true);
	}

    public List<ViVector3> MoveToPosList(ViVector3 fromPos,ViVector3 toPos)
    {
        MoveCachePosList.Clear();
        Navigator.Navigate(fromPos, toPos, 10000, MoveCachePosList);
        OnMoveTo(MoveCachePosList);
        return MoveCachePosList;
    }

	public void OnBreakMove()
	{
		Physics.BreakMove();
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);

        if (_actioMoveEnd != null)
        {
            _actioMoveEnd = null;
            _obj = null;
            ResetAI();
        }
    }
    public void ResetAI()
    {
        if (IsReinforcements)
        {
            if (FocusEntity != null && IsAttackTarget(FocusEntity))
                _AI.SetAI(LocalAIActionType.Attack);
            else
                _AI.SetAI(LocalAIActionType.Follow);
        }
        else
            _AI.SetAI(LocalAIActionType.Idle);
    }

	ViCallback _getDestCallbackNode = new ViCallback();
	void OnMoveGetDest(UInt32 eventID)
	{
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);

        if (_actioMoveEnd != null)
        {
            _actioMoveEnd(_obj);
            _actioMoveEnd = null;
            _obj = null;
            ResetAI();
        }
    }

	public void SetPos(ViVector3 pos, float yaw)
	{
		Physics.SetPos(pos);
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
	}

	public void SetPos(ViVector3 pos)
	{
		Physics.SetPos(pos);
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
    }

    public void SetYaw(float value)
    {
        Physics.SetYaw(value);
        _yawCursor.Direction = value;
    }

    public void SetScale(float value)
    {
        _scale = new ViPriorityValue<float>(value);
    }

    public void SetVisual(PathFileResStruct body, ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> partList)
	{
		AvatarCreator.Create(_visualBody, body, 1.0f,partList);
		_visualBody.Name = "Entity_" + Name;
		_visualBody.RootTran.localScale = Vector3.one * Scale.Value;
		_visualBody.LoadCallback = this.OnVisualLoad;
		//
		UpdateTransform();
		//
		UpdateTickState();
	}

	public void UpdateTransform()
	{
		GroundWinger.Update(Position, _yawCursor.Direction, ViVector3.UNIT_Z, VisualBody.RootTran);
		//
		//if (VisualBody.VisualTran != null)
		//{
		//    Vector3 directionScale = VisualBody.VisualTran.localScale;
		//    if (_yawCursor.Direction > 0)
		//    {
		//        directionScale.x = Math.Abs(directionScale.x);
		//    }
		//    else
		//    {
		//        directionScale.x = -Math.Abs(directionScale.x);
		//    }
		//    VisualBody.VisualTran.localScale = directionScale;
		//}
	}

	public void PlayActionAnim(string name)
	{
        VisualBody.PlayActionAnim(name, true);
    }
	public void PlayStateAnim(string name)
	{
		VisualBody.PlayStateAnim(name);
	}
	public void StopStateAnim(string name)
	{
		VisualBody.StopStateAnim(name);
	}

	public Transform GetTransform(int pos)
	{
		if (VisualBody.Property != null)
		{
			return VisualBody.Property.GetAttachPos(pos);
		}
		else
		{
			return VisualBody.RootTran;
		}
    }

    public ViProvider<ViVector3> GetPosProvider(int pos)
    {
        return PosProvider;
    }

    void OnVisualLoad(Avatar avatar)
    {
        //
        //avatar.CreateGhost("XRay", false, null, null);
        //
        _AI.Start(this);

        ResetAI();

        EventDispatcher.AddEventListener<GameUnit>(Events.PlayerEvent.SetLockTarget, _OnSetLockTargetCallback);

        //播放休闲动作
        PlayShowAnimation();
    }
    void PlayShowAnimation()
    {
        ViTimerInstance.SetTime(_showNode1, UnityEngine.Random.Range(500, 800), this._OnWaitEnd);
    }

    void _OnWaitEnd(ViTimeNodeInterface node)
    {
        VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim, AnimationData.Show03, true);

        PlayShowAnimation();
    }

    public Transform transform { get { return VisualBody.RootTran; } }
    public GameObject gameObject { get { return VisualBody.Root; } }

    public GameObject GetDialogText() { return _dialogText; }

    private GameObject _dialogText;
    private Action<object> _actioMoveEnd = null;
    private object _obj = null;
    public void MoveTo(Vector3 point, Action<object> moveEndCallback = null, object obj = null)
    {
        if (IsReinforcements)
            _AI.SetAI(LocalAIActionType.Idle);
        _actioMoveEnd = moveEndCallback;
        _obj = obj;
        
        MoveToPosList(Position,point.ToViV3());
    }
    public void SetPosition(Vector3 point)
    {
        SetPos(point.ToViV3());
    }
    public void Play(string name, float speed = 1, Action callback = null)
    {
        PlayActionAnim(name);
        if (callback != null)
            callback();
    }
    public void PlaySkill(int id, GameUnit target, float dir, int hitID, Action callback = null)
    {
        AttackTarget(target,(uint)id);

        if (callback != null)
            callback();
    }
    public void LookAtPlayer()
    {
        LookAtTarget(CellHero.LocalHero);
    }
    public bool PlaySound(int id)
    {
        PathFileResStruct resourceData = ViSealedDB<PathFileResStruct>.Data(id);
        if (resourceData.IsNotNull())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = false;
            express.IsLocal = false;
            express.Start(resourceData, VisualBody.RootTran);
            express.SoundDuration = true;
            _ownExpressList.Add(express);
            return true;
        }
        return false;
    }

    public GameObject CreateDialogText()
    {
        _dialogText = StoryCharacterFactory.CreateCharacterBubbling(ID,transform);
        return _dialogText;
    }

    public void ShowGoalFlag()
    {
        if (_goalFlag.IsNull())
        {
            _goalFlag = SuperTextManager.Instance.SpwanGoalFlag(FlagProvider);
        }
    }
    public void CloseGoalFlag()
    {
        if (_goalFlag.IsNotNull())
        {
            SuperTextManager.Instance.CloseGoalFlag(_goalFlag);
        }
    }

    public uint PackID  { get { return (uint)ID; } }

    public byte Type { get { return 0; } }

    public bool IsLocal { get { return false; } }

    public bool Active { get { return true; } }

    public void Enable(ulong ID, uint PackID, bool asLocal)
    {
        
    }

    public void PreStart()
    {
       
    }

    public void Start()
    {
        
    }

    public void AftStart()
    {
        
    }

    public void Tick(float fDeltaTime)
    {
       
    }

    public void ClearCallback()
    {
        
    }

    public void PreEnd()
    {
        
    }

    public void AftEnd()
    {
        
    }

    public void SetActive(bool value)
    {
        
    }

    string _name = string.Empty;
    GameUnit _focusEntity;
    //
    ViPriorityValue<bool> _tickable = new ViPriorityValue<bool>(true);
	ViPriorityValue<bool> _visuable = new ViPriorityValue<bool>(true);
	ViPriorityValue<bool> _pickable = new ViPriorityValue<bool>(true);
	//
	SimpleAvatarStruct _info;
	Avatar _visualBody = new Avatar();
	ViAngleCursor2 _yawCursor = new ViAngleCursor2();
	ViPriorityValue<float> _moveAnimStandardSpeed = new ViPriorityValue<float>(5.0f);
	ViPriorityValue<float> _scale = new ViPriorityValue<float>(2.0f);
	BodyPhysics _bodyPhysics = new BodyPhysics();
	SpaceNavigator _navigator;
	//
	LocalSpaceEntityAI _AI = new LocalSpaceEntityAI();
    LocalSpellVisualProccess _spellProc = new LocalSpellVisualProccess();
    //
    ViPriorityValue<bool> _nameShow = new ViPriorityValue<bool>(false);
    ViExpressOwnList<ViExpressInterface> _ownExpressList = new ViExpressOwnList<ViExpressInterface>();
    bool _isReinforcements = false;

    List<ViSpellStruct> _ownSpellList = new List<ViSpellStruct>();
    List<bool> _isTargetList = new List<bool>();
    ViTimeNode1 _showNode1 = new ViTimeNode1();
    SuperTextManager.SuperTextElement _goalFlag = null;
    NPCStruct _logicInfo;
    static List<ViVector3> MoveCachePosList = new List<ViVector3>();
}
