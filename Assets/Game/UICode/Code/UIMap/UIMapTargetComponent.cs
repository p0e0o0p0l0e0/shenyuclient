using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMapTargetComponent : UIWindowComponent<UIMiniMapWindow, UIMiniMapController>
{
    #region ui control name define
    private const string Target = "Target";
    #endregion

    public class TargetElement:PoolElement
    {
        public UInt64 UnitId { get; set; }
        public bool IsStatic { get; set; }
        public Transform Tran { get; set; }
        public ExUISprite Sprite { get; set; }
        public Action<UInt64, TargetEnum> ClickCallBack{ get;set;}
        public UIPointerListener PointerListener
        {
            get
            {
                return _listener;
            }
            set
            {
                _listener = value;
                if (_listener != null)
                    _listener.OnTouchUpCallBack = _OnClick;
            }
        }
        private UIPointerListener _listener = null;
        public TargetEnum TargetType { get; set; }
        public void SetPosition(Vector2 pos)
        {
            this.Tran.localPosition = pos;
        }
        public void SetRotation(Quaternion rotation)
        {
            Tran.rotation = rotation;
        }
		private ExUISprite _tSprite;
		private void SetPointerInvalid(bool isTrue)
		{
			if (_tSprite == null)
				_tSprite = this.Tran.GetComponent<ExUISprite>();
			if (_tSprite)
				_tSprite.raycastTarget = isTrue;
			if (this.PointerListener != null)
				this.PointerListener.enabled = isTrue;
		}
		public void UpdateTarget(TargetEnum targetType, bool hidePointerClick = false)
        {
            ViConstValue<string> iconName = null;
            if (MapTargetDefine.targetIconData.TryGetValue(targetType, out iconName))
            {
                Sprite.SpriteName = iconName.Value;
                Sprite.SetNativeSize();
            }
			SetPointerInvalid(!hidePointerClick);

			this.Tran.name = targetType.ToString();
            TargetType = targetType;
        }
        private void _OnClick(int id, object obj)
        {
            if (ClickCallBack != null)
                ClickCallBack(UnitId, TargetType);
        }
        public override void Dispose()
        {
            if (Tran != null)
                //GameObject.DestroyImmediate(Tran);
                Tran = null;
            base.Dispose();
        }
    }

    private Transform _cpTran = null;
    private PoolManager<TargetElement> _targetPool = new PoolManager<TargetElement>();
    private TargetElement _playerTarget = null;
    private Dictionary<TargetEnum, Dictionary<Int32,TargetElement>> _listTargets;
    public UIMapBase Map { get; set; }
    public override void Initial(UIMiniMapWindow window, string topPath)
    {
        base.Initial(window, topPath);
        _cpTran = this._rootTran;
        _listTargets = new Dictionary<TargetEnum,Dictionary<int, TargetElement>>();
    }
    public void UnSpawnTarget(TargetEnum targetType,List<IGoalMapInterface> goals)
    {
        if (_listTargets.ContainsKey(targetType) && _listTargets[targetType] != null)
        {
            foreach (Int32 uintId in _listTargets[targetType].Keys)
            {
                if (goals.Find(delegate (IGoalMapInterface goal) { return goal.EntityID == uintId; }) == null)
                {
                    CloseTarget(_listTargets[targetType][uintId]);
                    _listTargets[targetType].Remove(uintId);
                }
            }
        }
        
    }

	public void UnSpawnTargetExceptPlayer()
	{
		foreach (TargetEnum te in _listTargets.Keys)
		{
			foreach (TargetElement target in _listTargets[te].Values)
			{
                CloseTarget(target);
			}
			_listTargets[te].Clear();
		}
			
		_listTargets.Clear();
	}
    public void SpwanTarget(Int32 uintId, TargetEnum targetType, Vector2 localPos)
    {
        TargetElement target = null;
        if(_listTargets.ContainsKey(targetType) && _listTargets[targetType].ContainsKey(uintId))
        {
            target = _listTargets[targetType][uintId];
        }
        else
        {
            bool isNeedCreate = _targetPool.Spwan(out target);
            if (isNeedCreate)
                _CreateTarget(ref target);
            else
                _CreateTarget(ref target,false); //初始化target
            if (!_listTargets.ContainsKey(targetType))
                _listTargets.Add(targetType, new Dictionary<int, TargetElement>());
            if (!_listTargets[targetType].ContainsKey(uintId))
                _listTargets[targetType].Add(uintId, target);
        }

        target.IsStatic = true;
        target.UnitId = (UInt64)uintId;
        target.UpdateTarget(targetType);
        target.SetPosition(localPos);
        ShowTarget(target);
    }
    public void UnSpwanTargetPlayer()
    {
        foreach (TargetElement target in _cellHeroTargets.Values)
        {
            CloseTarget(target);
        }
        _cellHeroTargets.Clear();
    }
    Dictionary<UInt64, TargetElement> _cellHeroTargets = new Dictionary<UInt64, TargetElement>();
    public void SpwanTarget(UInt64 unitId)
    {
        TargetElement target = null;
        if (_cellHeroTargets.ContainsKey(unitId))
        {
            target = _cellHeroTargets[unitId];
        }
        else
        {
            bool isNeedCreate = _targetPool.Spwan(out target);
            if (isNeedCreate)
                _CreateTarget(ref target);
            _cellHeroTargets[unitId] = target;
        }

        target.IsStatic = false;
        target.UnitId = unitId;
        if (unitId == CellHero.LocalHeroID)
        {
            target.UpdateTarget(TargetEnum.TARGET_LOCAL_PLAYER, true);
            _playerTarget = target;
        }            
        else
            ;//其他队友或者玩家之后处理
        ShowTarget(target);
    }
    public void ShowTarget(TargetElement element)
    {
        element.Tran.gameObject.SetActive(true);
    }
    public void CloseTarget(TargetElement element)
    {
        _targetPool.Close(element);
        element.Tran.gameObject.SetActive(false);
    }
    public void CloseAllTarget()
    {
        for (int i = 0; i < _targetPool.GetPoolCount(); ++i)
        {
            TargetElement element = _targetPool.GetElement(i);
            CloseTarget(element);
        }
    }
    private void _CreateTarget(ref TargetElement target , bool isCreate = true)
    {
        if (_cpTran != null)
        {
            if(isCreate)
                target.Tran = GameObject.Instantiate(_cpTran);
            target.Tran.SetParent(_cpTran.parent);
            target.Tran.gameObject.SetActive(true);
            target.Sprite = target.Tran.GetComponentInChildren<ExUISprite>(true);
            target.PointerListener = target.Tran.GetComponent<UIPointerListener>();
            target.ClickCallBack = _OnTargetClick;
            target.Tran.localRotation = Quaternion.identity;
            target.Tran.localScale = Vector3.one;
            target.Tran.localPosition = Vector2.zero;            
        }
    }
    private void _OnTargetClick(UInt64 unitId, TargetEnum targetType)
    {
        EventDispatcher.TriggerEvent<UInt64, TargetEnum>(Events.SceneCommonEvent.OnNavTo, unitId, targetType);
    }
    public void UpdateTargetPosition()
    {
        List<TargetElement> closeElement = new List<TargetElement>();
        for (int i = 0; i < _targetPool.GetPoolCount(); ++i)
        {
            TargetElement element = _targetPool.GetElement(i);
            if (!element.IsStatic && element.UnitId > 0 && element != _playerTarget)
            {
                GameUnit unit = Client.Current.EntityManager.GetEntity<GameUnit>(element.UnitId);
                if (unit != null && !unit.Dead)
                {
                    Transform tran = unit.VisualBody.RootTran;
                    Vector2 localPos = Map.ConvertPosition(tran.position);
                    Quaternion localRotation = Map.ConvertRotation(tran.rotation);
                    element.SetPosition(localPos);
                    element.SetRotation(localRotation);
                }
                else
                {
                    closeElement.Add(element);
                }
            }
        }
        for (int i = 0; i < closeElement.Count; ++i)
        {
            _targetPool.Close(closeElement[i]);
        }
    }
    public TargetElement GetPlayerElement()
    {
        return _playerTarget;
    }
    public override void Dispose()
    {
        foreach (TargetEnum te in _listTargets.Keys)
            _listTargets[te].Clear();
        _cellHeroTargets.Clear();
        _listTargets.Clear();
        _targetPool.Dispose();
        _listTargets = null;
         _targetPool = null;
        _cpTran = null;
        _playerTarget = null;
        base.Dispose();
    }
}
