using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameTimeScale
{
	public static float Scale { get { return _visualScale.Value * _logicScale; } }
	public static float DeltaTime { get { return RealDeltaTime * _logicScale; } }
	public static float VisualDeltaTime { get { return RealDeltaTime * _visualScale.Value; } }
	public static float RealDeltaTime { get { return _deltaRealTime; } }
	public static float LogicDeltaTime
	{
		get
		{
			if (ViTimerInstance.IsRunning)
			{
				float timeScaleEx = TimeScale(ViTimerInstance.Time, _logicTimeStamp, _logicTimespan) * _logicTimeStampScale;
				//if (timeScaleEx != 1.0f)
				//{
				//    ViDebuger.CritOK("GameTimeScale.ScaleEx=" + timeScaleEx);
				//}
				return RealDeltaTime * _logicScale * timeScaleEx;
			}
			else
			{
				return 0.0f;
			}
		}
	}

	static GameTimeScale()
	{
		_LastRealTime = Time.realtimeSinceStartup;
		_deltaRealTime = 0;
	}

	public static void Update()
	{
		float newTime = Time.realtimeSinceStartup;
		_deltaRealTime = newTime - _LastRealTime;
		_LastRealTime = newTime;
	}

	public static void SetLogic(float value)
	{
		_logicScale = value;
		Time.timeScale = Scale;
	}

	public static void AddVisual(string name, int weight, float value)
	{
		_visualScale.Add(name, weight, value);
		Time.timeScale = Scale;
	}

	public static void DelVisual(string name)
	{
		_visualScale.Del(name);
		Time.timeScale = Scale;
	}

	public static void SetVisual(float value)
	{
		_visualScale.DefaultValue = value;
		Time.timeScale = Scale;
	}

	public static void UpdateLogicTime(Int64 time, Int32 span)
	{
		_logicTimeStamp = time + span;
		_logicTimespan = span;
		//
		float diffScale = ((float)(ViTimerInstance.Time - time)) / span;
		_logicTimeStampScale = ViMathDefine.Sqrt(1.0f - ViMathDefine.Min(diffScale, 1.0f));
	}

	static float TimeScale(Int64 time, Int64 timeStamp, Int32 span)
	{
		float diffScale = ((float)(time - timeStamp)) / ((float)(span));
		if (diffScale < -1.0f)
		{
			return ViMathDefine.Sqrt(-diffScale);
		}
		else if (diffScale < 0.0f)
		{
			return 1.0f;
		}
		else if (diffScale < 0.99f)
		{
			return ViMathDefine.Sqrt(1.0f - diffScale);
		}
		else
		{
			return 0.1f;
		}
	}

	static ViPriorityValue<float> _visualScale = new ViPriorityValue<float>(1.0f);
	static float _logicScale = 1.0f;
	static Int64 _logicTimeStamp;
	static Int32 _logicTimespan;
	static float _logicTimeStampScale = 1.0f;
	static float _LastRealTime;
	static float _deltaRealTime;
}

