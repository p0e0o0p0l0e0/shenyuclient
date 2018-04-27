using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyPhysics
{
	public ViPriorityValue<float> Speed { get { return _moveSpeed; } }
	public ViVector3 Position { get { return _posProvider.Value; } }
	public ViProvider<ViVector3> PosProvider{ get { return _posProvider; } }
	public float Yaw { get { return _yawProvider.Value.Value; } }
	public ViSimpleProvider<ViAngle> YawProvider { get { return _yawProvider; } }
	public ViRoute Route { get { return _moveRoute; } }
	public ViEventList GetDestEventor { get { return _getDestEventor; } }
	public ViEventList GetDestOnceEventor { get { return _getDestOnceEventor; } }

    public static void SetHeight(List<ViVector3> posList, float value)
    {
        for(int iter = 0; iter < posList.Count; ++iter)
        {
            ViVector3 iterValue = posList[iter];
            iterValue.z = value;
            posList[iter] = iterValue;
        }
    }

	public void Start()
	{

	}

	public void End()
	{

	}

	public void Update(float deltaTime)
	{
		if (Route.IsEnd())
		{
			return;
		}
		//
		Route.OnTick(deltaTime, Speed.Value);
		_UpdatePosition(Route.Position);
		if (_updateYaw)
		{
			ViAngle dir = new ViAngle(ViGeographicObject.GetDirection(Route.Direction.x, Route.Direction.y));
			_yawProvider.SetValue(dir);
		}
		if (Route.IsEnd())
		{
			GetDestEventor.Invoke(0);
			GetDestOnceEventor.Invoke(0);
			GetDestOnceEventor.Clear();
		}
	}

	public void SetPos(ViVector3 pos)
	{
		BreakMove();
		_UpdatePosition(pos);
	}
    public void SetYaw(float  dir)
    {
        _angle.SetValue(dir);
        _yawProvider.SetValue(_angle);
    }

	public void MoveTo(ViVector3 pos, bool updateYaw, bool updateHeight)
	{
		BreakMove();
		//
		_updateYaw = updateYaw;
		_updateHeight = updateHeight;
        //
        ViVector3 startPos = Position;
        startPos.z = 0;
        pos.z = 0;
        //
		Route.Reset();
		Route.Append(pos);
		Route.Start(startPos);
		//
		ViAngle dir = new ViAngle(ViGeographicObject.GetDirection(Route.Direction.x, Route.Direction.y));
		if (updateYaw)
		{
			_yawProvider.SetValue(dir);
		}
	}

	public void MoveTo(List<ViVector3> posList, bool updateYaw, bool updateHeight)
	{
		BreakMove();
		//
		_updateYaw = updateYaw;
		_updateHeight = updateHeight;
        //
        ViVector3 startPos = Position;
        startPos.z = 0;
        SetHeight(posList, 0);
		Route.Reset();
		Route.Append(posList);
		Route.Start(startPos);
		//
		ViAngle dir = new ViAngle(ViGeographicObject.GetDirection(Route.Direction.x, Route.Direction.y));
		_yawProvider.SetValue(dir);
	}
    public void MoveTo(List<ViVector3> posList, bool updateYaw)
    {
        BreakMove();
        //
        _updateYaw = updateYaw;
        _updateHeight = false;
        //
        ViVector3 startPos = Position;
        Route.Reset();
        Route.Append(posList);
        Route.Start(startPos);
        //
        ViAngle dir = new ViAngle(ViGeographicObject.GetDirection(Route.Direction.x, Route.Direction.y));
        if (updateYaw)
        {
            _yawProvider.SetValue(dir);
        }
    }

    public void BreakMove()
	{
		Route.Reset();
	}

	public void UpdateHeight()
	{
		ViVector3 pos = _posProvider.Value;
		GroundHeight.GetGroundHeight(ref pos);
		_posProvider.SetValue(pos);
	}

	void _UpdatePosition(ViVector3 pos)
	{
		if (_updateHeight)
		{
			GroundHeight.GetGroundHeight(ref pos);
		}
		_posProvider.SetValue(pos);
	}

    ViAngle _angle = new ViAngle();
    ViSimpleProvider<ViAngle> _yawProvider = new ViSimpleProvider<ViAngle>();
	ViSimpleProvider<ViVector3> _posProvider = new ViSimpleProvider<ViVector3>(ViVector3.ZERO);
	ViRoute _moveRoute = new ViRoute();
	ViEventList _getDestEventor = new ViEventList();
	ViEventList _getDestOnceEventor = new ViEventList();
	ViPriorityValue<float>  _moveSpeed = new ViPriorityValue<float>(4.0f);
	bool _updateYaw = true;
	bool _updateHeight = true;
}