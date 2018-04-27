using System;


public class ViArea
{
	public virtual bool InArea(ViVector3 pos) { return false; }
	public virtual bool InArea(ViVector3 pos, float range) { return false; }
	public virtual float Distance(ViVector3 pos) { return ViMathDefine.Max(0.0f, ViVector3.Distance(pos, Center) - Range); }

	public float Range { get { return _range; } }
	public ViVector3 Center { get { return _center; } set { _center = value; } }

	protected ViVector3 _center;
	protected float _range;
}

public class ViRoundArea : ViArea
{
	public void Init(float radius)
	{
		_radius2 = radius * radius;
		_range = radius;
	}
	public override bool InArea(ViVector3 pos)
	{
		return (ViMath2D.Length2(_center.x, _center.y, pos.x, pos.y) < _radius2);
	}
	public override bool InArea(ViVector3 pos, float range)
	{
		return (ViMath2D.Length(_center.x, _center.y, pos.x, pos.y) < (_range + range));
	}
	float _radius2;
}

public class ViSectorArea : ViArea
{
	public void Init(float radius, float angleInf, float angleSup)
	{
		SetRadius(radius);
		SetAngle(angleInf, angleSup);
	}
	public void SetDir(float dir)
	{
		_dirAngleInf = _angleInf + dir;
		_dirAngleSup = _angleSup + dir;
		if (_dirAngleInf > _dirAngleSup)
		{
			_dirAngleSup += ViMathDefine.PI_X2;
		}
		ViDebuger.AssertWarning(_angleInf <= _angleSup);
	}

	public void SetRadius(float radius)
	{
		_range = radius;
		_radius2 = radius * radius;
	}

	public void SetAngle(float angleInf, float angleSup)
	{
		_angleInf = angleInf;
		_angleSup = angleSup;
		ViAngle.Normalize(ref _angleInf);
		ViAngle.Normalize(ref _angleSup);
		if (_angleInf > _angleSup)
		{
			_angleSup += ViMathDefine.PI_X2;
		}
		ViDebuger.AssertWarning(_angleInf <= _angleSup);
	}

	public override bool InArea(ViVector3 pos)
	{
		ViDebuger.AssertWarning(_dirAngleInf <= _dirAngleSup);
		float deltaX = pos.x - _center.x;
		float deltaY = pos.y - _center.y;
		float dir = ViMath2D.GetAngle(deltaX, deltaY);
		if (dir < _angleInf)
		{
			dir += ViMathDefine.PI_X2;
		}
		return (ViMath2D.Length2(_center.x, _center.y, pos.x, pos.y) < _radius2) && (_dirAngleInf <= dir && dir < _dirAngleSup);

	}
	public override bool InArea(ViVector3 pos, float range)
	{
		ViDebuger.AssertWarning(_dirAngleInf <= _dirAngleSup);
		float deltaX = pos.x - _center.x;
		float deltaY = pos.y - _center.y;
		float dir = ViMath2D.GetAngle(deltaX, deltaY);
		if (dir < _angleInf)
		{
			dir += ViMathDefine.PI_X2;
		}
		return (ViMath2D.Length(_center.x, _center.y, pos.x, pos.y) < (_range + range)) && (_dirAngleInf <= dir && dir < _dirAngleSup);
	}


	float _angleInf;
	float _angleSup;

	float _dirAngleInf;
	float _dirAngleSup;

	float _radius2;
}


public struct ViRotRect
{
	public float Front;
	public float HalfWidth;
	public ViVector3 Dir { get { return _dir; } set { _dir = value; _dir.Normalize(); } }
	//
	public bool In(ViVector3 center, ViVector3 pos)
	{
		ViVector3 delta = pos - center;
		float front = ViVector3.Dot(delta, _dir);
		if (front < 0.0f || front > Front)
		{
			return false;
		}
		ViVector3 prjLen = _dir * front;
		ViVector3 prjWidth = delta - prjLen;
		float halfWidth2 = prjWidth.sqrMagnitude;
		if (halfWidth2 > HalfWidth * HalfWidth)
		{
			return false;
		}
		return true;
	}
	public bool In(ViVector3 center, ViVector3 pos, float range)
	{
		ViVector3 delta = pos - center;
		float front = ViVector3.Dot(delta, _dir);
		if (front < -range || front > (Front + range))
		{
			return false;
		}
		ViVector3 prjLen = _dir * front;
		ViVector3 prjWidth = delta - prjLen;
		float halfWidth2 = prjWidth.sqrMagnitude;
		if (halfWidth2 > (HalfWidth + range) * (HalfWidth + range))
		{
			return false;
		}
		return true;
	}
	public float Distance(ViVector3 center, ViVector3 pos)
	{
		ViVector3 delta = pos - center;
		float distance = delta.Length;
		float front = ViVector3.Dot(delta, _dir);
		ViVector3 prjLen = _dir * front;
		ViVector3 prjWidth = delta - prjLen;
		float halfWidth = prjWidth.Length;
		float scale = ViMathDefine.Max(front / Front, halfWidth / HalfWidth);
		if (scale <= 1.0f)
		{
			return 0;
		}
		return distance * (scale - 1.0f);
	}
	//
	ViVector3 _dir;
}


public class ViRotRectArea : ViArea
{
	public void SetDir(ViVector3 dir)
	{
		_rotRect.Dir = dir;
	}
	public void SetDir(float dir)
	{
		ViVector3 kDir = ViVector3.ZERO;
		ViGeographicObject.GetRotate(dir, ref kDir.x, ref kDir.y);
		_rotRect.Dir = kDir;
	}
	public void Init(float front, float halfWidth)
	{
		_rotRect.Front = front;
		_rotRect.HalfWidth = halfWidth;
		_range = ViMath2D.Length(front, halfWidth);
	}
	public override bool InArea(ViVector3 pos)
	{
		return _rotRect.In(_center, pos);
	}
	public override bool InArea(ViVector3 pos, float range)
	{
		return _rotRect.In(_center, pos, range);
	}
	public override float Distance(ViVector3 pos)
	{
		return _rotRect.Distance(_center, pos);
	}
	//
	ViRotRect _rotRect;
}
