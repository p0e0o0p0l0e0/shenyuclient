using System;

public class UIInertiaVelocity
{
	public float Value { get { return _value; } }

	public void SetValue(float value)
	{
		_value = value;
	}

	public void UpdateVelocity(float value, float valueSup)
	{
		if (_value * value > 0)
		{
			_value = ViMathDefine.Sign(_value) * ViMathDefine.Max(ViMathDefine.Abs(_value), ViMathDefine.Abs(value));
		}
		else
		{
			_value = value;
		}
		_value = ViMathDefine.Sign(_value) * ViMathDefine.Min(ViMathDefine.Abs(_value), valueSup);
	}

	public void UpdateAccelerate(float deltaTime, float acc)
	{
		float deltaVelocity = ViMathDefine.Sign(_value) * deltaTime * acc;
		if (ViMathDefine.Abs(_value) < ViMathDefine.Abs(deltaVelocity))
		{
			_value = 0.0f;
		}
		else
		{
			_value -= deltaVelocity;
		}
	}

	float _value;
}

public class UIIntervalSlot
{
	public float Span { get { return _span; } }
	public float Offset { get { return _offset; } }
	public float ValueInf { get { return _valueInf; } }
	public float ValueSup { get { return _valueSup; } }
	public bool Active { get { return _span != 0.0f; } }
	//
	public void Init(Int32 slotSize, Int32 count, float offset, float ignore)
	{
		_span = 1.0f / slotSize;
		_offset = offset;
		_valueInf = offset + 0.5f * _span - count * _span + ignore;
		_valueSup = offset + 0.5f * _span - ignore;
	}

	public void Update(ref float value)
	{
		value = ViMathDefine.Clamp(value, _valueInf, _valueSup);
	}

	public void Clear()
	{
		_span = 0.0f;
	}

	float _span;
	float _offset;
	float _valueInf;
	float _valueSup;
}

