using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FocusChangeStruct
{
    public float Hp_percent { get; set; }
    public string Level { get; set; }
    public string Name { get; set; }
    public float Boom_percent { get; set; }
    public IconData Icon { get; set; }
    public bool IsShowBoom { get; set; }
    public bool IsHostile { get; set; }

    public void Clear()
    {
        Hp_percent = 0;
        Level = "";
        Name = "";
        Boom_percent = 0;
        Icon = null;
    }
}
public class FocusManager : IDisposable
{
   
    private static FocusManager _handler = null;
    public static FocusManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new FocusManager();
            return _handler;
        }
    }
    private FocusManager() { }

    public UICallback.VV_CB OnFocusChangeCallBack = null;
    public UICallback.VO_CB OnFocusStateChangeCallBack = null;
    private FocusChangeStruct _focusStruct = new FocusChangeStruct();
    public UInt64 CurFocusUnitId { get; set; }
    public UInt64 CurFocusTargetId { get; set; }

    public void Focus(UInt64 unitId, UInt64 packId)
    {
        XLColorDebug.LogUI("focus id="+unitId);
        CurFocusUnitId = unitId;
        CurFocusTargetId = packId;
        if (OnFocusChangeCallBack != null)
            OnFocusChangeCallBack();
        if (CurFocusTargetId > 0)
        {
            GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(CurFocusTargetId);
            XLColorDebug.LogUI("focus targetid=" + CurFocusTargetId);
            if (unit != null)
            {
                FillStruct(unit, ref _focusStruct);
                if (OnFocusStateChangeCallBack != null)
                    OnFocusStateChangeCallBack(_focusStruct);
            }
        }
    }

    public void FocusTarget()
    {
        if (CurFocusTargetId > 0)
        {
            GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(CurFocusTargetId);
            XLColorDebug.LogUI("focus targetid=" + CurFocusTargetId);
            if (unit != null)
            {
                FillStruct(unit, ref _focusStruct);
                if (OnFocusStateChangeCallBack != null)
                    OnFocusStateChangeCallBack(_focusStruct);
            }
        }
    }
    public void CancelFocus(UInt64 unitId)
    {
        CurFocusUnitId = 0;
        CurFocusTargetId = 0;
        if (OnFocusChangeCallBack != null)
            OnFocusChangeCallBack();
    }
    public FocusChangeStruct GetCurFocusData()
    {
        if (CurFocusUnitId > 0)
        {            
            GameUnit unit = Client.Current.EntityManager.GetEntity<GameUnit>(CurFocusUnitId);
            if (unit != null)
            {
                FillStruct(unit, ref _focusStruct);
            }
        }
        return _focusStruct;
    }

    public void FocusStateChange(UInt64 unitId, UInt32 targetPackId)
    {
        XLColorDebug.LogUI(string.Format("focus change srcid={0}   target={1}  CurFocusUnitId={2}", unitId, targetPackId, CurFocusUnitId));
        if (CurFocusUnitId == unitId)
        {
           // Debug.Log("--------------->FocusStateChange. targetid="+ targetPackId);
            if (targetPackId == 0)
            {
                CurFocusTargetId = 0;
                if (OnFocusStateChangeCallBack != null)
                    OnFocusStateChangeCallBack(null);
            }
            else
            {
                GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(targetPackId);
                XLColorDebug.LogUI("focus targetid="+targetPackId);
                if (unit != null)
                {
                    CurFocusTargetId = targetPackId;
                    FillStruct(unit, ref _focusStruct);
                    if (OnFocusStateChangeCallBack != null)
                        OnFocusStateChangeCallBack(_focusStruct);
                }
            }
        }
        else
        {
            Focus(unitId, targetPackId);
        }
    }
    private void FillStruct(GameUnit unit, ref FocusChangeStruct focusData)
    {
        focusData.Clear();
        focusData.Icon = UIUtility.GetIconDataByGameUint(unit);
        focusData.Level = UIUtility.GetUnitLevelByUnit(unit).ToUnityColor(EntityAssisstant.GetUINameColor(unit, null));
        focusData.Name = UIUtility.GetUnitNameByUnit(unit).ToUnityColor(EntityAssisstant.GetUINameColor(unit,null));
        focusData.Hp_percent = unit.HPPerc;
        if ((unit is CellHero) && (unit as CellHero).IsSelf)
        {
            focusData.IsShowBoom = true ;
            focusData.Boom_percent = CellHero.LocalHero.GetSpPrecent();
        }
        else
        {
            focusData.Boom_percent = 0;
            focusData.IsShowBoom = false;
        }
        focusData.IsHostile = UIUtility.IsHostile( unit);
    }
    public void Dispose()
    {
        CancelFocus(0);
    }
}
