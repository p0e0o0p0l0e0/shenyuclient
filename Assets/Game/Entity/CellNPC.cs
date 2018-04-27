using System;
using System.Collections.Generic;
using UnityEngine;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;

public class CellNPC : GameUnit, ViRPCEntity, ViEntity,IGoalFlag
{
	public new CellNPCReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public NPCStruct LogicInfo { get { return _logicInfo; } }
	public VisualNPCStruct VisualInfo { get { return _visualInfo; } }
	public VisualNPCBirthPositionStruct BirthPosInfo { get { return ViSealedDB<VisualNPCBirthPositionStruct>.Data(Property.BirthPos); } }
    public ViProvider<ViVector3> FlagProvider { get { return new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight * 1.5f)); } }
    public override string Name { get { return LogicInfo.Name; } }
	public override bool VisualRotate { get { return Property.ScriptValueList.Contain(GameKeyWord.RootYaw); } }
	public override float BodyHeight { get { return VisualInfo.GetBodyHeight(); } }
	public override float BodyRadius { get { return LogicInfo.GetBodyRadius(); } }
	public override float FireHeight { get { return 1.0f; } }
	public override float FireWidthOffset { get { return 1.0f; } }
	public override bool WeaponFireShake { get { return false; } }
	public override float AnimationSpeed { get { return VisualInfo.Avatar.Data.AnimSpeed; } }
	public override UInt32 AttackHitEffectVisualID { get { return VisualInfo.AttackHitEffectVisual; } }
	public override float AttackedColorizeScale { get { return VisualInfo.GetAttackColorizeScale(); } }

    public int BirthID
    {
        get
        {
            return (int)(Property == null ? 0 : Property.BirthPos.Value);
        }
    }

    public override float RangeAttackTravelSpeed
	{
		get
		{
            return 1.0f;
		}
	}

	public bool EntityHintShow
	{
		get
		{
			return VisualInfo.Hint.PData != null;
		}
	}

	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<CellNPCReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
        _property.FocusEntity.CallbackList.Attach(_NPCPropertyCallbackFocusEntity, this._OnNPCFocusEntityUpdated);

        base.SetProperty(_property);
	}
	public void EndProperty()
	{
        _NPCPropertyCallbackFocusEntity.End();
        _property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<CellNPCReceiveProperty>.Free(_property);
		_property = null;
	}
	public new void OnPropertyUpdateStart(UInt8 channel) { }
	public new void OnPropertyUpdateEnd(UInt8 channel) { }
	public new void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public new void PreStart()
	{
		base.PreStart();
		//
		UpdateInfo();
		//
		if (EntityHintShow)
		{
			if (_screenEntityHint == null)
			{
				_screenEntityHint = new ScreenEntityHintInterface();
				_screenEntityHint.SetHintInfo(VisualInfo.Hint.Data);
				_screenEntityHint.SetPosProvider(HeadPosProvider);
				_screenEntityHint.Start();
			}
		}
	}
	public new void AftStart()
	{
		base.AftStart();
        //
        EventDispatcher.TriggerEvent<IGoalFlag>(Events.SceneCommonEvent.NPCCreated,this);
    }
	public new void PreEnd()
	{
		if (_screenEntityHint != null)
		{
			_screenEntityHint.End();
			_screenEntityHint = null;
		}
		//
		UnityAssisstant.Destroy(ref _spaceLine);

        _showNode1.Detach();
        //
        CloseGoalFlag();
        //
        base.PreEnd();
	}

	public new void End()
	{
		//
		base.End();
	}

	public new void AftEnd()
	{
		//
		base.AftEnd();
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

	public new void ClearCallback()
	{
		base.ClearCallback();
		//
		_enterSpaceStartTimeNode.Detach();
	}
    ViAsynCallback<ViReceiveDataNode, object> _NPCPropertyCallbackFocusEntity = new ViAsynCallback<ViReceiveDataNode, object>();
    void _OnNPCFocusEntityUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
    {//focus對象改變時
        //UpdateFocusEntityHint();
        //this.Property.FocusEntity;
        FocusManager.Instance.FocusStateChange(this.ID, this.Property.FocusEntity);
    }


    public override void OnVisualLoad0()
	{
		base.OnVisualLoad0();
		//
		float enterSpaceReserveDuration = 0;
		if (HasAura(GameAuraDataInstance.AISpaceEnter.ID, out enterSpaceReserveDuration))
		{
			NameShow.Add("EnterSpace", 100, false);
			HPShow.Add("EnterSpace", 100, false);
			float enterSpaceDuration = ViMathDefine.Max(BirthPosInfo.EnterSpace.Data.Duration * 0.01f, 1.0f);
			float enterSpaceProgress = (1 - enterSpaceReserveDuration / enterSpaceDuration);
			if (enterSpaceProgress > 0.0f)
			{
				UpdateEnterSpaceVisual(enterSpaceDuration, enterSpaceProgress);
			}
			else
			{
				ViTimerInstance.SetTime(_enterSpaceStartTimeNode, (-enterSpaceProgress) * enterSpaceDuration, this._OnEnterSpaceStartTime);
				VisualActive.Add("EnterSpace", 100, false);
			}
		}
		//
		ReceiveDataInt64Property rootYaw;
		if (Property.ScriptValueList.TryGetValue(GameKeyWord.RootYaw, out rootYaw))
		{
			UpdateTranPath();
			UpdateGlobalTransform(rootYaw.Value * 0.01f);
			UpdateTransform(0.0f);
		}
		//
		if (VisualInfo.DurationVisual.NotEmpty())
		{
			AddAvatarDurationVisual(VisualInfo.DurationVisual);
		}
        //播放休闲动作
        PlayShowAnimation();
    }

    void PlayShowAnimation()
    {
        ViTimerInstance.SetTime(_showNode1, UnityEngine.Random.Range(500,800), this._OnWaitEnd);
    }

    void _OnWaitEnd(ViTimeNodeInterface node)
    {
        VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim,AnimationData.Show03,true);

        PlayShowAnimation();
    }

	void UpdateInfo()
	{
		_logicInfo = ViSealedDB<NPCStruct>.Data(Property.Template);
		_visualInfo = ViSealedDB<VisualNPCStruct>.Data(Property.Template);
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
    public override void UpdateNameBillBoard()
    {
        base.UpdateNameBillBoard();
        string name = _logicInfo.Name;
        string title = "";
        string finalStr = null;
        VisualNPCStruct vns = ViSealedDB<VisualNPCStruct>.Data(_logicInfo.ID);
        if (vns != null)
        {
            bool isShowNameBillBoard = (vns.IsShowNameBillBoard.Value == 1);
            if (isShowNameBillBoard)
            {
                name = _logicInfo.Name;
                title = vns.BillBoardTitle;
                if (_logicInfo.Faction.Value == (int)Faction.ENEMY)
                    finalStr = UIUtility.MakeNameBillBoardStr_Hostile(name, title);
                else if (_logicInfo.Faction.Value == (int)Faction.NEUTRAL)
                    finalStr = UIUtility.MakeNameBillBoardStr_NPC(name, title);
                else
                    finalStr = UIUtility.MakeNameBillBoardStr_Firend(name, title);
                if (this._nameBillBoard == null && SuperTextManager.Instance != null)
                {
                   // ViProvider<ViVector3> pos = new ViOffSetVector3Provider(HeadPosProvider, new ViVector3(0, 0, BodyHeight * 1.5f));
                    this._nameBillBoard = SuperTextManager.Instance.SpwanNameBillBoard(finalStr, HeadPosProvider);
                }else if (this._nameBillBoard != null)                   
                    this._nameBillBoard.SetText(finalStr);

            }
            else
            {
                if (this._nameBillBoard != null)
                    SuperTextManager.Instance.CloseTarget( HintType.NAME_BILL_BOARD, this._nameBillBoard);
            }
        }
    }
    public void OnLeaveSpace()
	{

	}

	public void OnEnterSpaceComplete()
	{
		NameShow.Del("EnterSpace");
		HPShow.Del("EnterSpace");
		//
		ExitSpaceLine();
	}

	void UpdateEnterSpaceVisual(float duration, float progress)
	{
		float enterSpaceReserveDuration = (1 - progress) * duration;
		VisualNPCShowStruct enterSpaceVisualInfo = BirthPosInfo.EnterSpace.Data.Visual.Data;
		//
		if (VisualBody.Anim != null)
		{
			VisualBody.AnimController.Play(VisualBody.Anim, enterSpaceVisualInfo.Anim, ViMathDefine.Clamp(progress, 0.01f, 1.0f), false);
		}
		//
		if (enterSpaceVisualInfo.SpaceRes.NotEmpty())
		{
			ViProvider<ViVector3> posProvider = GetPosProvider(enterSpaceVisualInfo.SpacePosition);
			FreeSpaceExpressEx express = new FreeSpaceExpressEx();
			express.CameraAnim = true;
			express.Start(enterSpaceVisualInfo.SpaceRes.Data, posProvider, Yaw, 0, enterSpaceReserveDuration);
		}
		if (enterSpaceVisualInfo.BodyRes.NotEmpty())
		{
			AttachedSpaceExpress express = new AttachedSpaceExpress();
			express.CameraAnim = true;
			express.Start(enterSpaceVisualInfo.BodyRes.Data, GetTransform(enterSpaceVisualInfo.BodyPosition), ViVector3.ZERO, 0, 0.0f, enterSpaceReserveDuration, 0.0f);
		}
		//
		ViCameraShakeStruct cameraShake = enterSpaceVisualInfo.CameraShake.PData;
		if (cameraShake != null)
		{
			ShakeExpressEx shakeExpress = new ShakeExpressEx();
			shakeExpress.SetProvider(PosProvider);
			shakeExpress.Start(enterSpaceVisualInfo.CameraShakeDelay * 0.01f, cameraShake);
		}
		//
		if (!string.IsNullOrEmpty(BirthPosInfo.EnterSpaceLine))
		{
			EnterSpaceLine(BirthPosInfo.EnterSpaceLine, duration, progress);
		}
	}

	ViTimeNode1 _enterSpaceStartTimeNode = new ViTimeNode1();
	void _OnEnterSpaceStartTime(ViTimeNodeInterface node)
	{
		VisualActive.Del("EnterSpace");
		UpdateEnterSpaceVisual(BirthPosInfo.EnterSpace.Data.Duration * 0.01f, 0.0f);
	}

	public void OnFirstChase(GameUnit victim)
	{

	}

	public void OnChaseStart(GameUnit target)
	{

	}

	public void OnFirstAttacked(GameUnit attacker)
	{

	}

	public override void OnDamageHited(GameUnit attacker)
	{
		base.OnDamageHited(attacker);
		//
// 		if (LogicInfo.NatureType == (Int32)UnitNatureType.BUILDING)
// 		{
// 			if (EntityRelationChecker.IsFriend(CellHero.LocalHero, this))
// 			{
// 				Colorizer.AddDynamic(Color.white * AttackedColorizeScale * SpaceEntity.VALUE_AttackColorScale, SpaceEntity.VALUE_AttackColorSpan);
// 			}
// 		}
        Colorizer.AddDynamic(new Color(1f, 1f, 0.2f, 0.3f) * 2.0f, SpaceEntity.VALUE_AttackColorSpan);
    }

	public override void OnDie()
	{
		base.OnDie();
		//
		DestroyType.Add("Dead", 10, (AvatarDestroyType)VisualInfo.DeadDestoryType.Value);
		//
	}

	public override void OnRevive()
	{
		base.OnRevive();
		//
		DestroyType.Del("Dead");
	}

	public override void OnSoul()
	{
		base.OnSoul();
		//

	}

	public void OnKilled(GameUnit attacker, Int8 fromYaw, UInt16 force, UInt8 explore)
	{
		OnKilled(attacker, fromYaw, force, 0, explore);
	}

	public void OnKilled(GameUnit attacker, Int8 fromYaw, UInt16 force, UInt32 visual, UInt8 explore)
	{
		if (VisualInfo.KilledExploreVisual != 0)
		{
			AddAvatarDurationVisual(VisualInfo.KilledExploreVisual, attacker, 10);
		}
		//
		if (explore != 0 && ApplicationSetting.Instance.GraphicsMainLevel > 0)
		{
			ViAttackForceStruct forceInfo = ViSealedDB<ViAttackForceStruct>.Data(force);
			ViVector3 attackPos = GetAttackPos(attacker, fromYaw);
			attackPos += Position;
			attackPos.z = Position.z + forceInfo.Height * 0.01f;
			ShowExplore(forceInfo, 1.0f, attackPos, VisualInfo.KilledIKExploreScale * 0.01f);
		}
	}

	public void ShowExplore(UInt32 force, float forceScale, UInt32 visual)
	{
		if (VisualInfo.KilledExploreVisual != 0)
		{
			AddAvatarDurationVisual(VisualInfo.KilledExploreVisual, this, 10);
		}
		ViAttackForceStruct forceInfo = ViSealedDB<ViAttackForceStruct>.Data(force);
		ViVector3 attackPos = GetRoundPos(ViRandom.Value(-314, 314) * 0.01f, 1.0f);
		attackPos += Position;
		attackPos.z = Position.z + forceInfo.Height * 0.01f;
		ShowExplore(forceInfo, forceScale, attackPos, 0.5f);
	}

	void ShowExplore(ViAttackForceStruct forceInfo, float forceScale, ViVector3 attackPos, float exploreProbability)
	{
		if (RigidbodyList.Count <= 0 && VisualBody.Property != null)
		{
			float forceV = forceInfo.PowerV * 0.01f * forceScale * VALUE_PhysicsIKStandardForce;
			float forceH = forceInfo.PowerH * 0.01f * forceScale * VALUE_PhysicsIKStandardForce;
			CharactorExplosion.Start(VisualBody.VisualTran, VisualBody.Property, RigidbodyList, CollderList, JiontList, attackPos, forceH, forceV, VisualInfo.GetBodyWeight(), exploreProbability);
			if (RigidbodyList.Count > 0)
			{
				SetTickState(GameKeyWord.Dead, 10, false);
				//
				if (VisualBody.Anim != null)
				{
					VisualBody.Anim.Stop();
					VisualBody.Anim.enabled = false;
				}
			}
		}
	}

	public void EnterSpaceLine(string name, float duration, float progress)
	{
 //       GameObject routeRoot = GameSpace.ActiveInstance.Controller.ViewConfigProperty.Route;
 //       if (routeRoot == null)
 //       {
 //           return;
 //       }
 //       GameObject line = routeRoot.GetChild(name);
 //       if (line == null)
 //       {
 //           return;
 //       }
 //       _spaceLine = UnityAssisstant.Instantiate(line);
	//	Animator anim = _spaceLine.GetComponentInChildren<Animator>();
	//	if (anim == null)
	//	{
	//		return;
	//	}
	//	anim.speed = 1.0f / duration;
	////	anim.Play(AnimationData.Enter, 0, progress);
	////	PlayActionAnim(AnimationData.JumpLoop);
	//	UnityAssisstant.JionTransform(anim.transform, VisualBody.RootTran, Vector3.zero, Quaternion.identity);
	//	SetTickState(GameKeyWord.SpaceLine, 10, false);
	}

	public void ExitSpaceLine()
	{
	//	PlayActionAnim(AnimationData.JumpEnd);
		ClearTickState(GameKeyWord.SpaceLine);
		VisualBody.RootTran.parent = null;
		UnityAssisstant.Destroy(ref _spaceLine);
	}

    public override void OnMeleeAttackOnce(GameUnit TargetEntity)
    {
        VisualBody.PlayActionAnim(AnimationData.Attack01, true);
    }

	#region Name Billboard
	public override ViArrayIdx BillBoardStartDepth
	{
		get
		{
			return 0;
		}
	}

	public override string RoleHintName { get { return VisualInfo.Hint.Data.Desc; } }

    //public override void UpdateNameBillBoard()
    //{
    //       //VisualSpaceStruct currentSpace = ViSealedDB<VisualSpaceStruct>.Data(GameSpaceRecordInstance.Instance.Property.Info.Value.ID);
    //       //if (!ViMask32.HasAny(currentSpace.NPCHint.Value, (int)VisualSpaceStruct.VisualEntityHintMask.NAME))
    //       //{
    //       //	NameShow.Add("Space", 250, false);
    //       //}
    //       //else
    //       //{
    //       //	NameShow.Del("Space");
    //       //}
    //       //if (!ViMask32.HasAny(currentSpace.NPCHint.Value, (int)VisualSpaceStruct.VisualEntityHintMask.HP))
    //       //{
    //       //	HPShow.Add("Space", 250, false);
    //       //}
    //       //else
    //       //{
    //       //	HPShow.Del("Space");
    //       //}
    //       //if (Property.Faction == (UInt8)Faction.FRIEND /*|| Property.Faction == (UInt8)Faction.NEUTRAL*/)
    //       //{
    //       //	HPShow.Add("Faction", 300, false);
    //       //}
    //       //else
    //       //{
    //       //	HPShow.Del("Faction");
    //       //}
    //       //      if (this.LogicInfo.NatureType.Value == (int)UnitNatureType.BOSS)
    //       //      {
    //       //          _isUpdateHpPos = false;
    //       //      }

    //       base.UpdateNameBillBoard();

    //   }

    protected override void UpdateHP()
    {
        //if (_nameBillboard != null)
        {
            if (HPShow.Value)
            {
                float hp = 1.0f * _property.HP.Value / _property.HPMax0.Value;
               // Debug.Log("------------>natureType="+ this.LogicInfo.NatureType.Value);
                if (LogicInfo.DataEx.NotEmpty() && LogicInfo.DataEx.Data.entityCategory.Value == (int)EntityCategory.BOSS_VILLAIN)
                    UIManagerUtility.UpdateBossHp(this.ID, hp);
                else
                    UIManagerUtility.UpdateEnemyHp(this.ID, hp, true);

            }
            else
            {
                //_nameBillboard.HideUnitHP();
                UIManagerUtility.KillHp(this.ID);
            }
        }
    }

    #endregion

    CellNPCReceiveProperty _property;
	NPCStruct _logicInfo;
	VisualNPCStruct _visualInfo;
	GameObject _spaceLine;
    
	//
	ScreenEntityHintInterface _screenEntityHint;

    ViTimeNode1 _showNode1 = new ViTimeNode1();
    SuperTextManager.SuperTextElement _goalFlag = null;
}

