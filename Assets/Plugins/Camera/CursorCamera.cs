using UnityEngine;
using System.Collections;
using System;

// 轨迹计算方程 y = a*(sqrt(x^2 + b^2) - b)
public class CursorCamera : CameraPosDirInterface
{
	public static ViConstValue<float> VALUE_CameraHorizOffsetScale = new ViConstValue<float>("CameraHorizOffsetScale", 1.0f);
	public static ViConstValue<float> VALUE_CameraHorizOffsetMinSpeed = new ViConstValue<float>("CameraHorizOffsetMinSpeed", 0.0f);
	public static ViConstValue<float> VALUE_CameraHorizOffsetMaxSpeed = new ViConstValue<float>("CameraHorizOffsetMaxSpeed", 50.0f);
	public static ViConstValue<float> VALUE_CameraHorizOffsetAccelerate = new ViConstValue<float>("CameraHorizOffsetAccelerate", 100.0f);
	public static ViConstValue<float> VALUE_CameraDistanceMinSpeed = new ViConstValue<float>("CameraDistanceMinSpeed", 0.0f);
	public static ViConstValue<float> VALUE_CameraDistanceMaxSpeed  = new ViConstValue<float>("CameraDistanceMaxSpeed", 10.0f);
	public static ViConstValue<float> VALUE_CameraDistanceAccelerate = new ViConstValue<float>("CameraDistanceAccelerate", 10.0f);

	public struct ConfigStruct
	{
		public static void Lerp(ConfigStruct inf, ConfigStruct sup, float progress, out ConfigStruct value)
		{
			value = new ConfigStruct();
			float reserveProgress = 1.0f - progress;
			value.Pitch = inf.Pitch * reserveProgress + sup.Pitch * progress;
			value.Field = inf.Field * reserveProgress + sup.Field * progress;
			value.Height = inf.Height * reserveProgress + sup.Height * progress;
			value.Front = inf.Front * reserveProgress + sup.Front * progress;
		}

		public float Pitch;
		public float Field;
		public float Height;
		public float Front;
		public float Distance;
	}

	public CursorCamera()
	{
		_horizDistanceSmooth.MinSpeed = VALUE_CameraDistanceMinSpeed;
		_horizDistanceSmooth.MaxSpeed = VALUE_CameraDistanceMaxSpeed;
		_horizDistanceSmooth.Accelerate = VALUE_CameraDistanceAccelerate;
		//
		_horizOffsetSmooth.StopAt(ViVector3.ZERO);
		_horizOffsetSmooth.MinSpeed = VALUE_CameraHorizOffsetMinSpeed;
		_horizOffsetSmooth.MaxSpeed = VALUE_CameraHorizOffsetMaxSpeed;
		_horizOffsetSmooth.Accelerate = VALUE_CameraHorizOffsetAccelerate;
		//
		_inf.Pitch = 0;
		_inf.Field = 30;
		_inf.Height = 1.0f;
		_inf.Front = 0.0f;
		_inf.Distance = 3.0f;
		//
		_sup.Pitch = 60;
		_sup.Field = 50;
		_sup.Height = -1.0f;
		_inf.Front = 1.0f;
		_sup.Distance = 100.0f;
        //
        _pitch = 45;
        _horizDistance = _sup.Distance;
		_horizDistanceSmooth.StopAt(_sup.Distance);
	}

	public ViProvider<ViVector3> TargetPos { get { return _targetPos; } }
	public ViProvider<ViAngle> TargetYaw { get { return _targetYaw; } }
	public ViVector3 Position { get { return _worldPos; } }
	public ViVector3 LookAt
	{
		get
		{
			return _targetPos.Value + _heightOffset/* + _horizOffsetSmooth.Value*/;
		}
	}
	public float Distance
	{
		get { return _horizDistance; }
		set
		{
			_horizDistance = ViMathDefine.Clamp(value, _inf.Distance, 30);
		}
	}

	public float Yaw
	{
		get { return _yaw; }
		set
		{
			_yaw = value;
			ViAngle.Normalize(ref _yaw);
		}
	}

    public float Pitch
    {
        get { return _pitch; }
        set
        {
            _pitch = value;
            _pitch = ViMathDefine.Clamp(value, 5, 70);
        }
    }
	public float Field { get { return _current.Field + FieldEx.Value; } }
	public ViPriorityValue<float> FieldEx = new ViPriorityValue<float>(0.0f);
	public ViPriorityValue<float> FrontScale { get { return _frontScale; } }
	public delegate void MinimumCameraDistanceCallback(bool enter);
	public ViValueInterpolation CameraDitance { get { return _horizDistanceSmooth; } }

	public ConfigStruct Inf { get { return _inf; } }
	public ConfigStruct Sup { get { return _sup; } }

	public void SetConfig(ConfigStruct inf, ConfigStruct sup)
	{
		_inf = inf;
		_sup = sup;
		_horizDistance = sup.Distance;
		_horizDistanceSmooth.StopAt(_horizDistance);
	}

	public void ForceDistance()
	{
		_horizDistanceSmooth.StopAt(_horizDistance);
		Update(0.0f);
	}

	public void SetTarget(ViProvider<ViVector3> pos, ViProvider<ViAngle> yaw)
	{
		_targetPos = pos;
		_targetYaw = yaw;
	}

	public void Update(float deltaTime)
	{
        _horizDistanceSmooth.Update(_horizDistance, deltaTime);
        float horizDistance = _horizDistanceSmooth.Value;
        float progress = (horizDistance - _inf.Distance) / (_sup.Distance - _inf.Distance);
        ConfigStruct.Lerp(_inf, _sup, progress, out _current);

        horizDistance = _horizDistance;
        float tan = (float)Math.Tan(_pitch * ViMathDefine.Deg2Rad);
        float sin = (float)Math.Sin(_pitch * ViMathDefine.Deg2Rad);
        float cos = (float)Math.Cos(_pitch * ViMathDefine.Deg2Rad);
        float verticalDistance = tan * horizDistance;

        float localX = cos * horizDistance;
        float localY = sin * horizDistance;

        _localPos = new ViVector3(0.0f, -localX, localY);

        ViMath2D.Rotate(ref _localPos.x, ref _localPos.y, Yaw);
        //
        _heightOffset.z = 1.0f;
        //
        ViVector3 horizOffset = ViVector3.ZERO;
        ViGeographicObject.GetRotate(TargetYaw.Value.Value, ref horizOffset.x, ref horizOffset.y);
        float frontScale = FrontScale.Value;
        horizOffset *= _current.Front;
        horizOffset.x *= FrontScale.Value;
        horizOffset.y *= FrontScale.Value;
        _horizOffsetSmooth.Update(horizOffset, deltaTime);
        //
        _worldPos = _targetPos.Value + _localPos;// + _heightOffset ;
    }

	//
	ViProvider<ViVector3> _targetPos;
	ViProvider<ViAngle> _targetYaw;
	//
	ViVector3 _worldPos;
	ViVector3 _localPos;
	//
	float _yaw;
    //
    float _pitch;
	ViVector3 _heightOffset;
	//
	
	ViVector3Interpolation _horizOffsetSmooth = new ViVector3Interpolation();
	//
	float _horizDistance;
	ViValueInterpolation _horizDistanceSmooth = new ViValueInterpolation();
	//
	ConfigStruct _inf;
	ConfigStruct _sup;
	ConfigStruct _current;
	//
	ViPriorityValue<float> _frontScale = new ViPriorityValue<float>();
}

