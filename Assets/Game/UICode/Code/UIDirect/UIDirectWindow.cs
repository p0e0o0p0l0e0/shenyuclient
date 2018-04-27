using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirectWindow : UIWindow<UIDirectWindow, UIDirectController>
{
    #region ui control name define
    private const string PlayerHPTran = "UIDirectorWindow/HeadHint_Player";
    private const string MonHPTran = "UIDirectorWindow/HeadHint_Mon";
    private const string BossHPTran = "UIDirectorWindow/HeadHint_Boss";
    private const string CriticalTran = "UIDirectorWindow/HeadHint_message/Critical_Mesage";
    private const string HealthTran = "UIDirectorWindow/HeadHint_message/Health_Mesage";
    private const string AttackTran = "UIDirectorWindow/HeadHint_message/Attack_Mesage";
    private const string BuffTran = "UIDirectorWindow/HeadHint_message/Buff_Mesage";
    private const string RealAttackTran = "UIDirectorWindow/HeadHint_message/RealAttack_Mesage";
    #endregion


    private Transform _playerHpTran = null;
    private Transform _monHpTran = null;
    private Transform _bossHpTran = null;
    private Dictionary<ulong, UIDirectManager.HpElement> _heroHp = new Dictionary<ulong, UIDirectManager.HpElement>();
    //private Dictionary<ulong, UIDirectManager.BoomHpElement> _boomHp = new Dictionary<ulong, UIDirectManager.BoomHpElement>();
    private UIDirectManager.BoomHpElement _boomHp = null;
    protected override void Initial()
    {
        base.Initial();
        _playerHpTran = this.FindTransform(PlayerHPTran);
        _monHpTran = this.FindTransform(MonHPTran);
        _bossHpTran = this.FindTransform(BossHPTran);
        UIDirectManager.Instance.SetEnemyTran(_monHpTran);
        UIDirectManager.Instance.SetBossTran(_bossHpTran);
        UIDirectManager.Instance.SetBoomTran(_playerHpTran);
        UIDirectManager.Instance.CreateEnemyHp(1);
        UIDirectManager.Instance.CreateBossHp(1);
        UIDirectManager.Instance.CreateBoomHp(1);

        //Transform ctran = this.FindTransform(CriticalTran);
        //Transform htran = this.FindTransform(HealthTran);
        //Transform atran = this.FindTransform(AttackTran);
        //Transform btran = this.FindTransform(BuffTran);
        //Transform rtran = this.FindTransform(RealAttackTran);
        //UIHeadHintManager.Instance.SetAttackTran(atran);
        //UIHeadHintManager.Instance.SetBuffTran(btran);
        //UIHeadHintManager.Instance.SetCriticalTran(ctran);
        //UIHeadHintManager.Instance.SetHealthTran(htran);
        //UIHeadHintManager.Instance.SetRealAttckTran(rtran);
    }
    public void UpdateEnemyHp(ulong id, float hp, bool isHostile)
    {
        UIDirectManager.HpElement hpElement = null;
        if (!_heroHp.TryGetValue(id, out hpElement))
        {
            hpElement = UIDirectManager.Instance.SpwanEnemyHp(isHostile);
            _heroHp.Add(id, hpElement);
        }
        hpElement.UpdateProgress(hp);
    }
    public void UpdateBossHp(ulong id, float hp)
    {
        //UIDirectManager.HpElement hpElement = null;
        //if (!_heroHp.TryGetValue(id, out hpElement))
        //{
        //    hpElement = UIDirectManager.Instance.SpwanBossHp();
        //    _heroHp.Add(id, hpElement);
        //}
        //hpElement.UpdateProgress(hp);
    }
    public void UpdateLocalPlayerHp(float hp)
    {
        if (_boomHp == null)
            _boomHp = UIDirectManager.Instance.SpwanBoomHp();
        _boomHp.UpdateProgress(hp);
    }
    public void UpdateLocalPlayerBoom(float val)
    {
        if (_boomHp == null)
            _boomHp = UIDirectManager.Instance.SpwanBoomHp();
        _boomHp.UpdateSubProgress(val);
    }
    public void KillLocalPlayerHp()
    {
        if (_boomHp != null)
            UIDirectManager.Instance.KillBoomHpElement(_boomHp);
        _boomHp = null;
    }
    public void KillHp(ulong id)
    {
        UIDirectManager.HpElement hpElement = null;
        if (_heroHp.TryGetValue(id, out hpElement))
        {
            if(hpElement is UIDirectManager.BossHpElement)
                UIDirectManager.Instance.KillBossHpElement((UIDirectManager.BossHpElement)hpElement);
            else
                UIDirectManager.Instance.KillEnemyHpElement(hpElement);
            _heroHp.Remove(id);
        }
    }
    public void UpdateHpPos(ulong unitId, ViProvider<ViVector3> pos)
    {
        UIDirectManager.HpElement element = null;
        if (_heroHp.TryGetValue(unitId, out element))
        {
            UIDirectManager.Instance.UpdateHpPos(pos, element);
        }
        else
        {
            UIDirectManager.Instance.UpdateHpPos(pos, _boomHp);
            //ViDebuger.Record("UpdateHpPos failed, not find the hpelement");
        }
    }
}
