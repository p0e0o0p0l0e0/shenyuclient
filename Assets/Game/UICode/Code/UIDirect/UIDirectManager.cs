using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UIDirectManager : IDisposable
{
    private const string BackSlider = "BackSlider";
    private const string FrontSlider = "FrontSlider";
    private static UIDirectManager _handler;
    public static UIDirectManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new UIDirectManager();
            return _handler;
        }
    }

    public class HpElement
    {
        public Transform Tran { get; set; }
        public Transform CPTran { get; set; }
        public Slider FrontProgress { get; set; }
        public Slider BackProgress { get; set; }
        public ExUISprite HpSp { get; set; }
        private int _timerId = -1;
        private ViProvider<ViVector3> _lastTargetPos = null;
        private bool _isChangeProgress = false;
        private ViTimeNode4 _updateCD = new ViTimeNode4();
        public void UpdateProgress(float val)
        {
             FrontProgress.value = val;
             _isChangeProgress = true;
        }
        public virtual void SetHpType(HP_Type type)
        {
            switch (type)
            {
                case HP_Type.Unhostile: HpSp.SpriteName = "bar_mprole";
                    break;
                case HP_Type.Hostile: HpSp.SpriteName = "bar_mprole2"; break;
            }
        }
        public virtual void Close()
        {
            Tran.gameObject.SetActive(false);
            _updateCD.Detach();
        }
        public virtual void Open()
        {
            Tran.gameObject.SetActive(true);
            //if (_timerId == -1)
            //{
            //    _timerId = UITimerManager.Instance.CreateTimer(TimerType.EVERY_FRAME, 0f, _timerUpdate);
            //    UITimerManager.Instance.StartTimer(_timerId);
            //}
            _updateCD.Start(ViTimerRealInstance.Timer, 5, _timerUpdate);
        }
        public void SetTargetPosition(ViProvider<ViVector3> position)
        {
              _lastTargetPos = position;          
        }
        private void _timerUpdate(ViTimeNodeInterface node)
        {
            if (_lastTargetPos != null)
            {
                Vector2 curLocalPos = _convertTolocal(_lastTargetPos.Value.Convert());
                this.Tran.localPosition = curLocalPos;
            }
            if (_isChangeProgress)
            {
                float curProgress = BackProgress.value;
                float nextProgress = FrontProgress.value;
                float deltaProgress = Mathf.Lerp(curProgress, nextProgress, Time.deltaTime * 10);
                BackProgress.value = deltaProgress;
                if (Math.Abs(nextProgress-deltaProgress) < 0.001f)
                {
                    _isChangeProgress = false;
                    BackProgress.value = FrontProgress.value;
                }
                    
            }
        }
        private Vector2 _convertTolocal(Vector3 pos)
        {
            Camera cam = UIManager.Instance.UICamera;
            pos = GlobalGameObject.Instance.SceneCamera.WorldToScreenPoint(pos);
            pos = cam.ScreenToWorldPoint(pos);
            return CPTran.parent.InverseTransformPoint(pos);
        }
    }
    public class BoomHpElement : HpElement
    {
        public Slider SubProgress { get; set; }
        public void UpdateSubProgress(float val)
        {
            if (val >= 0)
            {
                SetBoomVisible(true);
                SubProgress.value = val;
            }               
            else
                SetBoomVisible(false);
        }
        public override void SetHpType(HP_Type type)
        {
            base.SetHpType(type);
        }
        public void SetBoomVisible(bool isVisible)
        {
            SubProgress.gameObject.SetActive(isVisible);
        }
    }
    public class BossHpElement : HpElement
    {
        public override void SetHpType(HP_Type type)
        {

        }
        public override void Open()
        {
            base.Open();
            HpSp.color = Color.white;
        }
    }



    private List<HpElement> _enmeyHpPool = new List<HpElement>();
    private List<BossHpElement> _bossHpPool = new List<BossHpElement>();
    private List<BoomHpElement> _boomHpPool = new List<BoomHpElement>();
    private int _enmeyHpUseCount = 0;
    private int _bossHpUseCount = 0;
    private int _boomHpUseCount = 0;
    private Transform _boomTran = null;
    private Transform _enmeyTran = null;
    private Transform _bossTran = null;


    private UIDirectManager() { }

    public void SetEnemyTran(Transform tran)
    {
        
        _enmeyTran = tran;
    }
    public void SetBossTran(Transform tran)
    {
        _bossTran = tran;
    }
    public void SetBoomTran(Transform tran)
    {
        _boomTran = tran;
    }

    public void CreateEnemyHp(int count)
    {
        if (_enmeyTran == null) return;
        for (int i = 0; i < count; ++i)
        {
            HpElement element = _initalHpElement<HpElement>(_enmeyTran.gameObject);
            _enmeyHpPool.Add(element);
        }
    }
    public void CreateBossHp(int count)
    {
        if (_bossTran == null) return;
        for (int i = 0; i < count; ++i)
        {
            BossHpElement element =_initalHpElement<BossHpElement>(_bossTran.gameObject) as BossHpElement;
            element.Tran.localPosition = _bossTran.localPosition;
            _bossHpPool.Add(element);
        }
    }
    public void CreateBoomHp(int count)
    {
        if (_boomTran == null) return;
        for (int i = 0; i < count; ++i)
        {
            BoomHpElement element = _initalHpElement<BoomHpElement>(_boomTran.gameObject) as BoomHpElement;
            _boomHpPool.Add(element);
        }
    }
    private HpElement _initalHpElement<T>(GameObject target) where T: HpElement, new ()
    {
        T element = new T();
        GameObject go = GameObject.Instantiate(target);
        element.Tran = go.transform;
        element.Tran.SetParent(target.transform.parent);
        element.Tran.localScale = Vector3.one;
        Transform backTran = element.Tran.Find(BackSlider);
        Transform frontTran = element.Tran.Find(FrontSlider);
        element.BackProgress = backTran.GetComponentInChildren<Slider>();
        element.FrontProgress = frontTran.GetComponentInChildren<Slider>();
        element.HpSp = element.FrontProgress.transform.GetComponentInChildren<ExUISprite>();
        element.CPTran = target.transform;
        element.Close();
        return element;
    }
    public HpElement SpwanEnemyHp(bool isHostile)
    {
        HpElement element = null;
        if (_enmeyHpUseCount == _enmeyHpPool.Count)
        {
            CreateEnemyHp(5);
            element = _enmeyHpPool[_enmeyHpUseCount];                         
        }
        else
        {
            element = _enmeyHpPool[_enmeyHpUseCount];
        }
        HP_Type typ = (isHostile ? HP_Type.Hostile : HP_Type.Unhostile);
        element.SetHpType(typ);
        element.Open();
        ++_enmeyHpUseCount;
        return element;
    }
    public BossHpElement SpwanBossHp()
    {
        BossHpElement element = null;
        if (_bossHpUseCount == _bossHpPool.Count)
        {
            CreateBossHp(2);
            element = _bossHpPool[_bossHpUseCount];           
        }
        else
        {
            element = _bossHpPool[_bossHpUseCount];
        }
        element.Open();
        ++_bossHpUseCount;
        return element;
    }
    public BoomHpElement SpwanBoomHp()
    {
        BoomHpElement element = null;
        if (_boomHpUseCount == _boomHpPool.Count)
        {
            this.CreateBoomHp(2);
            element = _boomHpPool[_boomHpUseCount];
        }
        else
        {
            element = _boomHpPool[_boomHpUseCount];
        }
        ++_boomHpUseCount;
        element.Open();
        return element;
    }
     
    public void KillEnemyHpElement(HpElement element)
    {
        element.Close();
        _enmeyHpPool.Remove(element);
        _enmeyHpPool.Add(element);
        --_enmeyHpUseCount;
    }
    public void KillBossHpElement(BossHpElement element)
    {
        element.Close();
        _bossHpPool.Remove(element);
        _bossHpPool.Add(element);
        --_bossHpUseCount;
    }
    public void KillBoomHpElement(BoomHpElement element)
    {
        element.Close();
        _boomHpPool.Remove(element);
        _boomHpPool.Add(element);
        --_boomHpUseCount;
    }
    public void UpdateHpPos(ViProvider<ViVector3> pos, HpElement element)
    {
        if (element == null) return;
        element.SetTargetPosition(pos);
    }
    public void Destroy()
    {
        _enmeyHpPool.Clear();
        _bossHpPool.Clear();
    }
    public void Dispose()
    {
        Destroy();
    }


}
