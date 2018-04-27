using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMiniMapComponent : UIMapComponent
{

    protected UIMapTargetComponent _targetCom = null;
    protected bool _isMoveMap = true;
    private ViTimeNode4 _updateCD = new ViTimeNode4();
    protected bool _isPlayerCenter { get; set; }
    public override void Initial(UIMiniMapWindow window, string topPath)
    {
        base.Initial(window, topPath);
        _targetCom = new UIMapTargetComponent();
        _targetCom.Initial(window, topPath + "/Back/Target");
    }
    public override void CreateMap(Vector2 terrianSize, Vector2 terrianCenter, Vector2 uimapSize, bool isRevertDir, float offsetAngle, float directionAngle)
    {
        base.CreateMap(terrianSize, terrianCenter, uimapSize, isRevertDir, offsetAngle, directionAngle);
        _targetCom.Map = this._mapCtrl;
        _OnTimeOut(null);
    }
    public virtual void UnSpwanTarget(TargetEnum targetType,List<IGoalMapInterface> goals)
    {
        _targetCom.UnSpawnTarget(targetType, goals);
    }
	public void UnSpwanTargetsExceptPlayer()
	{
		_targetCom.UnSpawnTargetExceptPlayer();
	}
    public void UnSpwanTargetPlayer()
    {
        _targetCom.UnSpwanTargetPlayer();
    }
    public virtual void SpwanStaticTarget(Int32 uintId, TargetEnum te, Vector3 worldPos)
    {
        Vector2 localPos = _mapCtrl.ConvertPosition(worldPos);
        _targetCom.SpwanTarget(uintId, te, localPos);
    }
    public virtual void SpwanActiveTarget(UInt64 uintId)
    {
        _targetCom.SpwanTarget(uintId);
    }
    public void ChangePlayerElementUpParent()
    {
        UIMapTargetComponent.TargetElement player = this._targetCom.GetPlayerElement();
        if (player != null)
        {
            player.Tran.SetParent(this._rootTran);
            player.Tran.localPosition = Vector3.zero;
        }
    }
    public override void SetVisible(bool isVisible)
    {
        base.SetVisible(isVisible);
        if (isVisible)
		{
			_OnTimeOut(null);
			_updateCD.Start(ViTimerRealInstance.Timer, 5, _OnTimeOut);
		}
            
        else
            _updateCD.Detach();
        //if (!isVisible)
        //    _targetCom.CloseAllTarget();
    }

    protected virtual void _OnTimeOut(ViTimeNodeInterface node)
    {
        if (CellHero.LocalHero != null)
        {
            if (CellHero.LocalHero != null)
            {
                Transform player = CellHero.LocalHero.VisualBody.RootTran;
                UpdatePosition(player);
            }
        }
        _targetCom.UpdateTargetPosition();
    }
    private void UpdatePosition(Transform target)
    {
        UIMapTargetComponent.TargetElement playerElement = _targetCom.GetPlayerElement();
        if (playerElement == null) return;
        playerElement.SetRotation(_mapCtrl.ConvertRotation(target.rotation));
        if (_isMoveMap)
            _mapTexture.transform.localPosition = -_mapCtrl.ConvertPosition(target.position);
        else
            playerElement.SetPosition(_mapCtrl.ConvertPosition(target.position));
    }
    public override void Dispose()
    {
        _targetCom.Dispose();
        _targetCom = null;
        if (_updateCD != null)
            _updateCD.Detach();
        _updateCD = null;
        base.Dispose();
    }
}
