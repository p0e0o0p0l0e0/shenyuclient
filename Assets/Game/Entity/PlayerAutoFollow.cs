using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoFollow
{
	private const int StopDistance = 3;
	
    public Transform TargetTrans { get; set; }
	private bool IsFollow = false;


	public void Init ()
    {
		
	}

	public void Clear()
	{
		IsFollow = false;
		TargetTrans = null;
	}

	public void StartFollow(Transform trans)
	{
		TargetTrans = trans;

		if (CellHero.LocalHero != null) 
		{
			IsFollow = true;
			Follow ();
		}
	}
	public void StopFollow()
	{
		IsFollow = false;
		TargetTrans = null;
		Stop ();
	}

	private void Follow()
	{
		if (!IsFollow)
			return;
		
		if (IsCanFollow ()) 
		{
			HeroController.Instance.MoveTo(TargetTrans.position.ToViV3(),AutoPathType.AutoFollow);
			MoveCachePosList.Clear ();
			GameSpace.ActiveInstance.Navigator.Navigate (CellHero.LocalHero.Position, TargetTrans.position.ToViV3(), 1024, MoveCachePosList);
			_distance = ViRoute.GetLength (CellHero.LocalHero.Position, MoveCachePosList);
			_duration = _distance / CellHero.LocalHero.Physics.Speed.Value;
			_time = (uint)(UnityEngine.Mathf.CeilToInt(_duration) * 100);
			_nextStepTimeNode.Start(ViTimerInstance.Timer, _time / 50, 50);
			_nextStepTimeNode.TickDelegate = _OnMoveTick;
			_nextStepTimeNode.EndDelegate = _OnEnd;
		} 
		else 
		{
			_nextStepTimeNode.Start(ViTimerInstance.Timer,1, 200);
			_nextStepTimeNode.TickDelegate = _OnEnd;
			_nextStepTimeNode.EndDelegate = _OnEnd;
		}
	}

    protected virtual void MoveToRightSpace(int spaceID)
    {
        SpaceObjectBirthPositionStruct birthPos = GameSpaceRecordInstance.Instance.LogicInfo.GetTelePortPoint(spaceID);

        if (birthPos != null)
        {
            if (IsPointUseful(birthPos.Position))
            {
                GoalManager.GetInstance.MoveTo(birthPos.Position);
            }
            else
                UConsole.Log("MoveToRightSpace  数据不对，无处可去");
        }
        else
        {
            //TODO zlj 炉石开启用传送	
            //传送点不存在 TP主城
            GoalManager.GetInstance.GotoSpace(Client.VALUE_MainCitySpaceId);
        }

    }
    public bool IsInRightSpace(int spaceID)
    {
        return spaceID == GameSpaceRecordInstance.Instance.Property.Info.Value.ID;
    }
    protected bool IsPointUseful(ViVector3 viv3)
    {
        return !viv3.Equals(ViVector3.ZERO);
    }

    private void Stop()
	{
		HeroController.Instance.StopMove ();
	}

	private bool IsCanFollow()
	{
		if (TargetTrans == null)
			return false;
		_distance = ViVector3.DistanceH(CellHero.LocalHero.Position, TargetTrans.position.ToViV3());
		return _distance > StopDistance;
	}

	private void _OnMoveTick(ViTimeNodeInterface node)
	{
		if (!IsCanFollow())
		{
			_nextStepTimeNode.Detach();
			Stop ();
			Follow();
		}
	}

	private void _OnEnd(ViTimeNodeInterface node)
	{
		_nextStepTimeNode.Detach();
		Follow();
	}

	uint _time;
	float _duration;
	float _distance;
	ViTimeNode3 _nextStepTimeNode = new ViTimeNode3();
    List<ViVector3> MoveCachePosList = new List<ViVector3>();
}
