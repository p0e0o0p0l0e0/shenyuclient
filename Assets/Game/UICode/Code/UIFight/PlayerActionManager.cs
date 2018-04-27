using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerActionManager :IDisposable
{
    
    public static ViConstValue<Int32> VALUE_MoveYawTickSpan = new ViConstValue<Int32>("MoveYawTickSpan", 20);
    public static ViConstValue<Int32> VALUE_ShotYawTickSpan = new ViConstValue<Int32>("ShotYawTickSpan", 20);
    public static ViConstValue<float> VALUE_DragIgnoreScale = new ViConstValue<float>("DragIgnoreScale", 0.1f);
    private float _lastMoveYaw = 0;
    private List<ViVector3> _MovePosList = new List<ViVector3>();
    private Int64 _nextMoveYawUpdateTime;
    private Int64 _lastMoveYawSendTime;
    private float _lastMoveSpeedScale;
    private static PlayerActionManager _handler = null;
    private bool _isReqDoDash = false;
    private ViTimeNode1 _node1 = new ViTimeNode1();

    public static PlayerActionManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new PlayerActionManager();
            return _handler;
        }
    }
    private PlayerActionManager() { }
    public void OnBeginMove()
    {
        _lastMoveYaw = float.MaxValue;
    }
    public void OnMoving(Vector3 ballPos)
    {
        //float dragScale = DragScale(100, ballPos);
        //if (dragScale <= 0.0f)
        //{
        //    return;
        //}
        //
        Vector3 localHeroPos = CellHero.LocalHero.Position.Convert();
        Vector3 dir = PickAssisstant.OffsetCamera2World(localHeroPos, ballPos).normalized;
        float yaw = ViGeographicObject.GetDirection(dir.x, dir.z);
        EntityAssisstant.FormatYaw(ref yaw);
        UpdateMoveYaw(yaw, GameValueMappingInstance.ControllerMoveSpeedScale.Data.Get(1));
    }
    public void OnEndMove()
    {
        if (CellHero.LocalHero == null) return;
        CellPlayerServerInvoker.REQ_BreakMoveTo(CellPlayer.Instance);
        CellPlayerServerInvoker.REQ_DelMoveSpeedScale(CellPlayer.Instance);
    }
    public void UpdateMoveYaw(float yaw, float speedScale)
    {
        if (CellHero.LocalHero == null) return;
        if (CellHero.LocalHero.CanNotOperation())
        {
            return;
        }
        if (!IsCanMove())
        {
            return;
        }
        _MovePosList.Clear();
        ViVector3 direction = ViVector3.ZERO;
        ViGeographicObject.GetRotate(yaw, ref direction.x, ref direction.y);
        float frontDistance = CellHero.LocalHero.Property.MoveSpeed0 * 0.01f * 1.2f;
        GameSpace.ActiveInstance.Navigator.Navigate(CellHero.LocalHero.Position, direction, frontDistance, _MovePosList);
        if (_MovePosList.Count <= 0)
        {
            return;
        }
        if (IsCanTurn())
        {
            
        }
        if (ViTimerInstance.Time < _nextMoveYawUpdateTime)
        {
            return;
        }
        _nextMoveYawUpdateTime = ViTimerInstance.Time + VALUE_MoveYawTickSpan;
        //
        float moveReserveDuration = CellHero.LocalHero.Physics.Route.Length(true) / (CellHero.LocalHero.Property.MoveSpeed0 * 0.01f);
        if (Math.Abs(yaw - _lastMoveYaw) + (ViTimerInstance.Time - _lastMoveYawSendTime) * 0.01f * 0.1f > 0.1f || moveReserveDuration < VALUE_MoveYawTickSpan * 0.01f)
        {
            HeroController.Instance.MoveTo(_MovePosList);
            _lastMoveYaw = yaw;
            _lastMoveYawSendTime = ViTimerInstance.Time;
        }
        //
        float speedScaleIgnore = 0.2f;
        speedScale = ViMathDefine.IntSup(speedScale / speedScaleIgnore) * speedScaleIgnore;
        if (Math.Abs(speedScale - _lastMoveSpeedScale) >= speedScaleIgnore * 0.5f)
        {
            CellPlayerServerInvoker.REQ_AddMoveSpeedScale(CellPlayer.Instance, speedScale);
            _lastMoveSpeedScale = speedScale;
        }
    }
    public bool IsCanTurn()
    {
        return !ViMask32.HasAll(CellHero.LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_TURN) && !_isReqDoDash;
    }
    public bool IsCanMove()
    {
        return !ViMask32.HasAll(CellHero.LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_MOVE) && !_isReqDoDash;
    }
    public void ReqDoDash()
    {
        _isReqDoDash = true;
        //翻滚失败,时间到了重置状态
        ViTimerInstance.SetTime(_node1,50, _WaitEnd);
    }
    public void UpdateActionState()
    {
        if (_isReqDoDash)
        {
            //服务器锁住位移和旋转度,且同步给客户端
            if ((ViMask32.HasAll(CellHero.LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_MOVE) &&
                ViMask32.HasAll(CellHero.LocalHero.Property.ActionStateMask, (Int32)ActionStateMask.DIS_TURN)))
            {
                _isReqDoDash = false;
            }
        }
    }
    private void _WaitEnd(ViTimeNodeInterface timeNode)
    {
        _isReqDoDash = false;
    }

    public virtual void Dispose()
    {
        _node1.Detach();
        _node1 = null;
    }
    private float DragScale(float radius, Vector3 ballPos)
    {
        return ViMathDefine.Clamp01(ballPos.magnitude / radius - VALUE_DragIgnoreScale) / (1 - VALUE_DragIgnoreScale);
    }
    public void Attack()
    {
        
    }
    public void OnPressAttack()
    {
        if (CellHero.LocalHero == null) return;
        //VisualSpellStruct visualSpellInfo = ViSealedDB<VisualSpellStruct>.Data(10000200);
        ViVector3 dir = ViVector3.ZERO;
        ViGeographicObject.GetRotate(CellHero.LocalHero.Yaw, ref dir.x, ref dir.y);
        float yaw, distance;
        if(HeroController.Instance.AutoFocus(36,GameStateConditionDataInstance.Attackedable, AutoFocusType.MINDISTANCE,0,300, 1.0f, ref dir, out yaw, out distance) != null)
        {
            CellPlayerServerInvoker.REQ_SetHeroYaw(CellPlayer.Instance, yaw);
        }


        CellPlayerServerInvoker.REQ_ShotStart(CellPlayer.Instance);
    }
    public void OnReleaseAttack()
    {
        CellPlayerServerInvoker.REQ_ShotEnd(CellPlayer.Instance);
    }
    public bool OnPressSkill(int index)
    {
        if (CellHero.LocalHero == null) return false;

        ReceiveDataHeroSpellProperty spellProperty = TalentDataMgr.GetInstance.GetSpellReceiveDataByIndex(index);
        Int64 startTime = 0;
        Int64 endTime = 0;
        bool canCast = CanCastSkill(spellProperty, out startTime, out endTime);
        if (canCast)
        {
            ViSpellStruct logicInfo = spellProperty.WorkingInfo.Value;
            VisualSpellStruct visualSpellInfo = ViSealedDB<VisualSpellStruct>.Data(logicInfo.ID);
            if (visualSpellInfo.Selector.Position == (Int32) SpellPositionSelectType.SELF)
            {
                CellPlayerServerInvoker.REQ_DoSpellByID(CellPlayer.Instance, (uint) spellProperty.Info.Value.Spell.Data.ID);//liupeng 4.16
                UConsole.Log("DoSpellByID  SELF :" + spellProperty.Info.Value.Spell.Data.ID);
                return false;
            }
            else
            {
                ViVector3 dir = ViVector3.ZERO;
                ViGeographicObject.GetRotate(CellHero.LocalHero.Yaw, ref dir.x, ref dir.y);
                float yaw, distance;
                HeroController.Instance.AutoFocus(
                    visualSpellInfo.Selector.GroupPosFocus, 
                    GameStateConditionDataInstance.Attackedable,
                    (AutoFocusType)visualSpellInfo.Selector.AutoFocusType.Value,
                    visualSpellInfo.Selector.casterEffectRange.minRange,
                     logicInfo.proc.Range.Sup,
                     1.0f, ref dir, out yaw, out distance);
                float scale = (distance - logicInfo.proc.Range.Inf * 0.01f) /
                              ViMathDefine.Max(1.0f, (logicInfo.proc.Range.Sup - logicInfo.proc.Range.Inf) * 0.01f);
                HeroController.Instance.StartAoIHint(spellProperty, logicInfo, visualSpellInfo, 0);
                HeroController.Instance.UpdateAoIHint(HeroController.Instance.GetSpellPos(logicInfo, dir, scale));
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public bool CanCastSkill(ReceiveDataHeroSpellProperty property, out Int64 startTime, out Int64 endTime)
    {
        bool ret = true;
        startTime = 0;
        endTime = 0;
        ViSpellStruct logicSpell = property.WorkingInfo.Value;
        ReceiveDataTimeProperty timeProperty;
        if (CellHero.LocalHero.Property.SpellCDList.TryGetValue((UInt32)logicSpell.ID, out timeProperty) && timeProperty.Value > ViTimerInstance.Time)
        {
            endTime = timeProperty.Value.Value;
            startTime = endTime - ViMathDefine.IntNear(logicSpell.proc.coolDuration);
            ret = false;
        }
        return ret;
    }

    public Int64 GetDashStartTime(Int64 endTime)
    {
        Int64 startTime = 0;
        var spell = ViSealedDB<ViSpellStruct>.GetData(10000300);
        startTime = endTime - ViMathDefine.IntNear(spell.proc.coolDuration);
        return startTime;
    }
    public void OnDragingSpell(float radius, Vector3 ballPos)
    {
        if (HeroController.Instance == null) return;
        if (HeroController.Instance.SpellAoIProperty == null)
        {
            return;
        }
        float dragScale = ballPos.magnitude / radius;
        ViSpellStruct spellInfo = HeroController.Instance.SpellAoIProperty.WorkingInfo.Value;
        ViVector3 dir = PickAssisstant.OffsetCamera2World(CellHero.LocalHero.Position.Convert(), ballPos).normalized.Convert();
        float yaw = ViGeographicObject.GetDirection(dir.x, dir.y);
        EntityAssisstant.FormatYaw(ref yaw);
        HeroController.Instance.UpdateAoIHint(HeroController.Instance.GetSpellPos(spellInfo, dir, dragScale));
    }
    public void OnReleaseSpell()
    {
        if (HeroController.Instance == null) return;
        int index;
        if (CellHero.LocalHero.Property.SpellList.GetIndex(HeroController.Instance.SpellAoIProperty, out index))
        {
            ViVector3 offset = HeroController.Instance.GetAoIHintOffset();
            offset.z = 0;
            float distance = offset.Length;
            offset.Normalize();
            float yaw = ViGeographicObject.GetDirection(offset.x, offset.y);
            EntityAssisstant.FormatYaw(ref yaw);
            if (HeroController.Instance.SpellAoIProperty.Info.Value.Spell.NotEmpty())
            {
                switch (HeroController.Instance.SpellAoIType)
                {
                    case SpellPositionSelectType.POS:
                        {
                            CellPlayerServerInvoker.REQ_DoSpellByID(CellPlayer.Instance, (uint)HeroController.Instance.SpellAoIProperty.Info.Value.Spell.Data.ID, yaw, distance);//liupeng 2018.4.11
                            UConsole.Log("DoSpellByID   POS :" + HeroController.Instance.SpellAoIProperty.Info.Value.ID);
                        }
                        break;
                    case SpellPositionSelectType.YAW:
                        {
                            CellPlayerServerInvoker.REQ_DoSpellByID(CellPlayer.Instance, (uint)HeroController.Instance.SpellAoIProperty.Info.Value.Spell.Data.ID, yaw);
                            UConsole.Log("DoSpellByID   YAW :" + HeroController.Instance.SpellAoIProperty.Info.Value.ID);
                        }
                        break;
                    case SpellPositionSelectType.SELF:
                        break;
                }
            }       
        }

        HeroController.Instance.EndAoIHint();
    }

    public void OnPressCancelSkill()
    {
        if (HeroController.Instance == null) return;
        HeroController.Instance.ChangeAoIhint();
    }

    public void OnReleaseCancelSkill()
    {
        if (HeroController.Instance == null) return;
        HeroController.Instance.EndAoIHint();
    }
    public void OnRetrunBackToSkill()
    {
        if (HeroController.Instance == null) return;
        HeroController.Instance.RestoreAOIHint();
    }
}

