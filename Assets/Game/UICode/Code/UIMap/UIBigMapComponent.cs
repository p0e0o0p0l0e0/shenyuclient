using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIBigMapComponent : UIMiniMapComponent
{
    private UIMapNavLineComponent _mapNavLine = null;
    private List<Vector2> _pathPos = new List<Vector2>();
    private bool _isClearPath = false;
    private UIBigMapNameListComponent _nameList = null;
    public override void Initial(UIMiniMapWindow window, string topPath)
    {
        base.Initial(window, topPath);

        this._isMoveMap = false;
        _mapNavLine = new UIMapNavLineComponent();
        _mapNavLine.Initial(window, topPath + "/Back");
    }
    public override void SetVisible(bool isVisible)
    {
        base.SetVisible(isVisible);
        if (isVisible)
        {
            _nameList = new UIBigMapNameListComponent();
            _nameList.Initial(_mWindow, _topPath);
        }
        else
        {
			NameListDispose();
        }
    }

    public void SetNavPath(List<ViVector3> worldPath)
    {
        _pathPos.Clear();
        if (CellHero.LocalHero != null)
        {
            _pathPos.Add(this._mapCtrl.ConvertPosition(CellHero.LocalHero.VisualBody.RootTran.position));
		}
        for (int i = 0; i < worldPath.Count; ++i)
        {
            Vector2 pos = new Vector2(worldPath[i].x, worldPath[i].y);
			pos = this._mapCtrl.ConvertPosition(pos, false);
            _pathPos.Add(pos);
        }
		_mapNavLine.SetPath(_pathPos);
        _isClearPath = false;
    }
    private void NameListDispose()
    {
        if (_nameList != null)
        {
            _nameList.Dispose();
            _nameList = null;
        }
    }
    public void ClearPath()
    {
        _mapNavLine.ClearPath();
        _isClearPath = true;
    }
    protected override void _OnTimeOut(ViTimeNodeInterface node)
    {
        base._OnTimeOut(node);
        if (this._isActive && _pathPos.Count > 0 && !_isClearPath)
            _UpdatePath();
    }

	private void _CheckNowPathPos() { 
	}
    private void _UpdatePath()
    {
		Transform player = CellHero.LocalHero.VisualBody.RootTran;
        Vector3 pos = player.position;
        Vector2 uiPos = this._mapCtrl.ConvertPosition(pos);
		//处理关闭小地图再打开继续寻路的bug
		int rPos = 0;
		for(int i = 0; i < _pathPos.Count - 1; i++)
		{
			Vector2 nextPos = _pathPos[i];
			Vector2 targetPos = _pathPos[i + 1];
			Vector2 dir1 = nextPos - uiPos;
			Vector2 dir2 = targetPos - uiPos;
			if (Vector2.Dot(dir1, dir2) < 0)
			{
				rPos = i;
				break;
			}
		}
		for (int i = 0; i < rPos && rPos > 0; i ++)
		{
			_pathPos.RemoveAt(0);
		}

        _pathPos[0] = uiPos;
        _mapNavLine.SetPath(_pathPos);
    }
    public override void SpwanActiveTarget(ulong uintId)
    {
        base.SpwanActiveTarget(uintId);
    }
    public override void Dispose()
    {
		_mapNavLine.Dispose();
		_mapNavLine = null;
		_pathPos.Clear();
		_pathPos = null;
		NameListDispose();

        base.Dispose();
    }
}
