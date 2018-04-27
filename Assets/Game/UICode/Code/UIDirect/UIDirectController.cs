using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectController : UIController<UIDirectController, UIDirectWindow>
{
    public void UpdateEnemyHp(ulong unitId, float val, bool isHostile)
    {
        this._mWinHandler.UpdateEnemyHp(unitId, val, isHostile);
    }
    public void UpdateBossHp(ulong unitId, float val)
    {
        this._mWinHandler.UpdateBossHp(unitId, val);
    }
    public void UpdateLocalPlayerHp(float val)
    {
        this._mWinHandler.UpdateLocalPlayerHp(val);
    }
    public void UpdateLocalPlayerBoom(float val)
    {
        this._mWinHandler.UpdateLocalPlayerBoom(val);
    }
    public void KillLocalPlayerHp()
    {
        this._mWinHandler.KillLocalPlayerHp();
    }
    public void KillHp(ulong unitId)
    {
        this._mWinHandler.KillHp(unitId);
    }
    public void UpdateHpPos(ulong unitId, ViProvider<ViVector3> pos)
    {
        this._mWinHandler.UpdateHpPos(unitId, pos);
    }
}
