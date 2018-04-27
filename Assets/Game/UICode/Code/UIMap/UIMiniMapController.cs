using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMiniMapController : UIController<UIMiniMapController, UIMiniMapWindow>
{
    private const int rateFactor = 100;
    private Vector2 _terrianSize;
    private Vector2 _terrianCenter;
    private Vector2 _uimapSize;
    private string icon = "";
    private int _lastSpaceId = 0;
    private Dictionary<string, ViVector3> _objPos = new Dictionary<string, ViVector3>();

    public override void Show()
    {
        base.Show();
        EventDispatcher.AddEventListener<AutoPathType,List<ViVector3>>(Events.PlayerEvent.PlayerNavMove, _OnNavPath);
        EventDispatcher.AddEventListener(Events.SceneCommonEvent.CreatedLocalHero, _UpdateMapInfo);
        EventDispatcher.AddEventListener<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, _OnMoveEnd);
        EventDispatcher.AddEventListener(Events.PlayerEvent.PlayerBreakMove, _OnBreakMove);
        
        EventDispatcher.AddEventListener<UInt64, TargetEnum>(Events.SceneCommonEvent.OnNavTo, _OnNavTo);
        EventDispatcher.AddEventListener<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, _OnGoalStateChange);
		EventDispatcher.AddEventListener<bool>(Events.GoalEvent.UpdateMapInfo, _UpdateMapBirthPos);
		OnChangeSpace();
    }
    public override void Hide()
    {
		EventDispatcher.RemoveEventListener<bool>(Events.GoalEvent.UpdateMapInfo, _UpdateMapBirthPos);
		EventDispatcher.RemoveEventListener<GoalStateType, List<IGoalMapInterface>>(Events.GoalEvent.GoalStateTypeUpdate, _OnGoalStateChange);
        EventDispatcher.RemoveEventListener<AutoPathType,List<ViVector3>>(Events.PlayerEvent.PlayerNavMove, _OnNavPath);
        EventDispatcher.RemoveEventListener(Events.SceneCommonEvent.CreatedLocalHero, _UpdateMapInfo);
        EventDispatcher.RemoveEventListener<AutoPathType>(Events.PlayerEvent.PlayerMoveEnd, _OnMoveEnd);
        EventDispatcher.RemoveEventListener<UInt64, TargetEnum>(Events.SceneCommonEvent.OnNavTo, _OnNavTo);
        EventDispatcher.RemoveEventListener(Events.PlayerEvent.PlayerBreakMove, _OnBreakMove);
		
        if (!string.IsNullOrEmpty(icon))
            UITextureManager.Instance.UnLoad(icon);

        base.Hide();
    }
    private void _OnNavTo(UInt64 uintId, TargetEnum targetType)
    {
        ViVector3 targetPos;
        string key = targetType.ToString() + uintId;
        if (_objPos.ContainsKey(key))
        {
            targetPos = _objPos[key];
            HeroController.Instance.MoveTo(targetPos,AutoPathType.MiniMap);
        }

    }
    private void _OnBreakMove()
    {
        this._mWinHandler.ClearPath();
    }
    private void _OnMoveEnd(AutoPathType type)
    {
        this._mWinHandler.ClearPath();
    }
    private void _OnNavPath(AutoPathType type,List<ViVector3> path)
    {
        if (this.IsShow)
        {
            this._mWinHandler.SetNavPath(path);
        }
    }
    public void OnChangeSpace()
    {
        if (CellHero.LocalHero != null)
            _UpdateMapInfo();
    }
    private void _UpdateMapInfo()
    {
        //ViDebuger.Record("Update MapInfo");
        if (GameSpace.ActiveInstance != null)
        {
            SpaceConfigStruct spaceConfig = GameSpace.ActiveInstance.LogicInfo.Config;
            if (spaceConfig != null)
            {
                if (_lastSpaceId != spaceConfig.ID)
                {
                    _lastSpaceId = spaceConfig.ID;
                    VisualSpaceStruct spaceInfo = ViSealedDB<VisualSpaceStruct>.Data(spaceConfig.ID);
                    int minX = spaceInfo.VisualArea.MinX / rateFactor;
                    int minY = spaceInfo.VisualArea.MinY / rateFactor;
                    int width = spaceInfo.VisualArea.WidthX / rateFactor;
                    int height = spaceInfo.VisualArea.WidthY / rateFactor;
                    _terrianSize = new Vector2(width, height);
                    _terrianCenter = new Vector2(minX + width / 2, minY + height / 2);
                    _terrianCenter =   Quaternion.Euler(0, 0, spaceInfo.DirectionAngle) * _terrianCenter;
                    if (!string.IsNullOrEmpty(icon))
                        UITextureManager.Instance.UnLoad(icon);
                    icon = spaceInfo.Icon;
                    Texture mapTex = UITextureManager.Instance.Load(icon, (string name, object go) =>
                    {
                        if (this._mWinHandler == null || !this._mWinHandler.IsResAvaliable()) return;
                        Texture tex = go as Texture;
                        if (tex != null)
                        {
                            _uimapSize = new Vector2(tex.width, tex.height);
                            this._mWinHandler.CreateMap(_terrianSize, _terrianCenter, _uimapSize, spaceInfo.IsDirectionReverse.Value == 1, spaceInfo.OffsetAngle, spaceInfo.DirectionAngle);
                            this._mWinHandler.SetMapTex(tex as Texture2D);
                            this._mWinHandler.SetMapName(spaceInfo.Name);
                            this._mWinHandler.SetBigMapEnable(spaceInfo.IsShowBigMap.Value == 1);
                            _HideBirthPos();
                            _UpdateBirthPos();
                            _UpdatePlayers();
                        }
                    });
                }
                else
                {
                    this._mWinHandler.SetMiniMapVisible(true);
                    this._mWinHandler.SetBigMapVisible(false);
                }
            }
        }


    }
    private void _OnGoalStateChange(GoalStateType goalStateType, List<IGoalMapInterface> goals)
    {
        //Debug.Log("goalStateType ==" + goalStateType + ",count:" + goals.Count);
        if(goalStateType == GoalStateType.Acceptable /*|| goalStateType == GoalStateType.UnderWay */
            || goalStateType == GoalStateType.CanReceive)
        {
            _mWinHandler.UnSpawnTarget(GetTaskEnum(goalStateType), goals);
            _UpdateGoalListState(goals, GetTaskEnum(goalStateType));
        }
        
    }
	private void _UpdateMapBirthPos(bool isShow)
	{
		if (isShow)
		{
			_UpdateBirthPos();
		}
		else
		{
			_HideBirthPos();
		}
	}

	private void _HideBirthPos()
	{
		_objPos.Clear();
		_mWinHandler.UnSpawnStaticTarget();
	}
	private void _UpdateBirthPos()
    {
        _objPos.Clear();
        ViForeignGroup<NPCBirthPositionStruct> npcPoints = GameSpace.ActiveInstance.LogicInfo.FreeNPCBirthList;
        ViForeignGroup<SpaceObjectBirthPositionStruct> objPoints = GameSpace.ActiveInstance.LogicInfo.FreeObjectBirthList;
        if (npcPoints != null)
        {
            List<NPCBirthPositionStruct> pointList = npcPoints.List;
            for (int i = 0; i < pointList.Count; ++i)
            {
                NPCBirthPositionStruct point = pointList[i];
                EntityCategory entityCate = (EntityCategory)point.NPC.Data.DataEx.Data.entityCategory.Value;

                Vector3 pos = point.Position.ToV3();
                //DebugShow.Instance.AddV(pos);
                string key = ((TargetEnum)entityCate).ToString() + point.ID;
                                                     
                if (entityCate != EntityCategory.NONE && point.AutoLoad.IsTrue())
                {
                    this._mWinHandler.SpawnStaticTarget(point.ID, (TargetEnum)entityCate, pos);
                    _objPos[key] = point.Position;
                    //_mWinHandler.AddNpcToList(point.NPC.Data.DataEx.Data.Name, 1, point.ID, (TargetEnum)entityCate);
                }
                    
            }
        }

        if (objPoints != null)
        {
            List<SpaceObjectBirthPositionStruct> pointList = objPoints.List;
            for (int i = 0; i < pointList.Count; ++i)
            {
                SpaceObjectBirthPositionStruct point = pointList[i];
                EntityCategory entityCate = (EntityCategory)point.Object.Data.entityCategory.Value;
                Vector3 pos = point.Position.ToV3();
                string key = ((TargetEnum)entityCate).ToString() + point.ID;
                //DebugShow.Instance.AddV2(pos);
                if (entityCate != EntityCategory.NONE)
                {
                    this._mWinHandler.SpawnStaticTarget(point.ID, (TargetEnum)entityCate, pos);
                    _objPos[key] = point.Position;
                }
                    
            }
        }
        _UpdateGoalListState(GoalManager.GetInstance.GetGoalMapList(GoalStateType.Acceptable), GetTaskEnum(GoalStateType.Acceptable));
        //_UpdateGoalListState(GoalManager.Instance.GetGoalMapList(GoalStateType.UnderWay), GetTaskEnum(GoalStateType.UnderWay));
        _UpdateGoalListState(GoalManager.GetInstance.GetGoalMapList(GoalStateType.CanReceive), GetTaskEnum(GoalStateType.CanReceive));
    }
    private static TargetEnum GetTaskEnum(GoalStateType gst)
    {
        switch (gst) {
            case GoalStateType.Acceptable:
                return TargetEnum.TARGET_CAN_GET_TASK;
            case GoalStateType.UnderWay:
                return TargetEnum.TARGET_TASK2;
            case GoalStateType.CanReceive:
                return TargetEnum.TARGET_CAN_SUBMIT_TASK;
        }
        return TargetEnum.TARGET_TASK1;
    }
    private void _UpdateGoalListState(List<IGoalMapInterface> list, TargetEnum targetType)
    {
        foreach (IGoalMapInterface goal in list)
        {
            //Debug.LogError("_UpGoalList  " + targetType + "," + (EntityCategory)goal.EntityCategory.Value + ", " + goal.EntityID);
            string key = targetType.ToString() + goal.EntityID;
            if(!_objPos.ContainsKey(key))
                _objPos.Add(key, goal.EntityPosition);
            this._mWinHandler.SpawnStaticTarget((Int32)goal.EntityID, targetType,goal.EntityPosition.ToV3());
        }
    }
    private void _UpdatePlayers()
    {
        this._mWinHandler.UnSpwanPlayerTarget();
        if (CellHero.LocalHero != null)
            this._mWinHandler.SpwanActiveTarget(CellHero.LocalHeroID);
    }

}
