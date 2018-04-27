using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMiniMapWindow : UIWindow<UIMiniMapWindow, UIMiniMapController>
{
    #region ui control name define
    private const string BackBtn = "BackBtn";
    private const string MiniMapTran = "Mini_Map";
    private const string BigMap = "Big_Map";
    
    #endregion

    private UIBigMapComponent _bigMap = new UIBigMapComponent();
    private UIMiniMapComponent _miniMap = new UIMiniMapComponent();
    private bool _isBigMapEnable = true;
    private bool _isBigMapVisible = false;
    protected override void Initial()
    {
        base.Initial();
        ExUIButton backBtn = this.GetComponent<ExUIButton>(BackBtn);
        backBtn.onClickEx = OnClickBack;
        _bigMap.Initial(this, BigMap);
        _miniMap.Initial(this, MiniMapTran);
        UIPointerListener backListener = this.GetComponent<UIPointerListener>(MiniMapTran);
        backListener.OnTouchUpCallBack = OnMiniMapClick;
        
        
    }
    public void CreateMap(Vector2 terrianSize, Vector2 terrianCenter, Vector2 uimapSize, bool isRevertDir, float offsetAngle, float directionAngle)
    {
        _miniMap.CreateMap(terrianSize, terrianCenter,uimapSize, isRevertDir, offsetAngle, directionAngle);
        _bigMap.CreateMap(terrianSize, terrianCenter, uimapSize, isRevertDir, offsetAngle, directionAngle);
    }
    public override void Show()
    {
        base.Show();
        //_isBigMapVisible = true;
        if (_isBigMapVisible)
            SwitchBigMap();
    }
    public void SetMapTex(Texture2D tex)
    {
        _bigMap.SetBackTex(tex);
        _miniMap.SetBackTex(tex);
        SetMiniMapVisible(true);
    }
    public void SetMiniMapVisible(bool isVisible)
    {
        _miniMap.SetVisible(isVisible);
    }
    public void SetBigMapVisible(bool isVisible)
    {
        _bigMap.SetVisible(isVisible);
    }
    public void SetBigMapEnable(bool enable)
    {
        _isBigMapEnable = enable;
    }
    private void OnClickBack(int id, object obj)
    {
        SwitchBigMap();
        
    }
    public void SetReverseDirection(bool isReverse)
    {
        _miniMap.SetReverseDirection(isReverse);
        _bigMap.SetReverseDirection(isReverse);
    }
    public override void Destroy()
    {
        _miniMap.Dispose();
        _bigMap.Dispose();
        _miniMap = null;
        _bigMap = null;
        base.Destroy();
    }
    private void OnMiniMapClick(int val, object obj)
    {
        if (_isBigMapEnable)
        {
            SwitchBigMap();
        }
    }
    private void SwitchBigMap()
    {
        _isBigMapVisible = !_isBigMapVisible;
        SetBigMapVisible(_isBigMapVisible);
        SetMiniMapVisible(!_isBigMapVisible);
        if (_isBigMapVisible)
        {
            UIManager.Instance.Hide(UIControllerDefine.WIN_FightWindow);
            UIManager.Instance.Hide(UIControllerDefine.WIN_Goal);
        }
        else
        {
            UIManager.Instance.Show(UIControllerDefine.WIN_FightWindow);
            UIManager.Instance.Show(UIControllerDefine.WIN_Goal);
        }           
    }
    public void SetMapName(string name)
    {
        _miniMap.SetMapName(name);
        _bigMap.SetMapName(name);
    }
    public void UnSpawnTarget(TargetEnum targetType, List<IGoalMapInterface> goals)
    {
        _bigMap.UnSpwanTarget(targetType, goals);
        _miniMap.UnSpwanTarget(targetType, goals);
    }
    public void AddNpcToList(string monsterName, int level, Int32 uintId, TargetEnum te)
    {
        //_bigMap.AddNpcToList(monsterName, level, uintId, te);
    }
	public void UnSpawnStaticTarget()
	{
		_bigMap.UnSpwanTargetsExceptPlayer();
		_miniMap.UnSpwanTargetsExceptPlayer();
	}
    public void SpawnStaticTarget(Int32 uintId, TargetEnum te, Vector3 worldPos)
    {
        _bigMap.SpwanStaticTarget(uintId, te, worldPos);
        _miniMap.SpwanStaticTarget(uintId, te, worldPos);
    }
    public void UnSpwanPlayerTarget()
    {
        _bigMap.UnSpwanTargetPlayer();
        _miniMap.UnSpwanTargetPlayer();
    }
    public void SpwanActiveTarget(UInt64 unitId)
    {
        _bigMap.SpwanActiveTarget(unitId);
        _miniMap.SpwanActiveTarget(unitId);
        if (unitId == CellHero.LocalHeroID)
        {
            _miniMap.ChangePlayerElementUpParent();
        }
    }
    public void SetNavPath(List<ViVector3> path)
    {
        _bigMap.SetNavPath(path);
    }
    public void ClearPath()
    {
        _bigMap.ClearPath();
    }
    public override void Hide()
    {
        this.ClearPath();
        
        this._miniMap.SetVisible(false);
        this._bigMap.SetVisible(false);
        base.Hide();
    }
}
