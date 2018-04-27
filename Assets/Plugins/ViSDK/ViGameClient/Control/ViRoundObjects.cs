using System;
using System.Collections;
using System.Collections.Generic;


public abstract class ViRoundObjects<TEntity>
	where TEntity : ViRefObj, ViGeographicInterface
{
	public delegate bool DELE_IsInRange(TEntity kObj, ViVector3 center);
	public delegate bool DELE_IsStateMatch(TEntity kObj);
	public DELE_IsInRange _deleIsInRange;
	public DELE_IsStateMatch _deleIsStateMatch;

	UInt32 Max { get; set; }
	//
	public void Clear()
	{
		_objs.Clear();
	}
	//
	public TEntity Next(float dir, ViVector3 center, Queue<TEntity> objs)
	{
		if (Max == 0)
		{
			return null;
		}
		EraseEmpty();
		_OnDirCenterUpdated(dir, center);
		_Check(center);
		TEntity obj = GetNearst(objs, center);
		if (obj == null && _objs.Count != 0)
		{
			obj = _objs[0].Obj;
			_objs.RemoveAt(0);
		}
		if (obj != null)
		{
			if (_objs.Count == Max)
			{
				_objs.RemoveAt(0);
			}
			_objs.Add(new ViRefPtr<TEntity>(obj));
		}
		return obj;
	}
	TEntity Prev()
	{
		if (_objs.Count == 0)
		{
			return null;
		}
		EraseEmpty();
		TEntity pkObj = _objs[_objs.Count-1].Obj;
		_objs.RemoveAt(_objs.Count - 1);
		return pkObj;
	}

	bool _Has(TEntity kObj)
	{
		foreach (ViRefPtr<TEntity> ptr in _objs)
		{
			if (ptr.Obj == kObj)
			{
				return true;
			}
		}
		return false;
	}

	void EraseEmpty()
	{
		for (int iter = 0; iter < _objs.Count; )
		{
			TEntity iterEntity = _objs[iter].Obj;
			if (iterEntity == null)
			{
				_objs.RemoveAt(iter);
			}
			else
			{
				++iter;
			}
		}
	}

	void _Check(ViVector3 center)
	{
		ViDebuger.AssertError(_deleIsInRange);
		for (int iter = 0; iter < _objs.Count; )
		{
			TEntity iterEntity = _objs[iter].Obj;
			if (!_deleIsInRange(iterEntity, center))
			{
				_objs.RemoveAt(iter);
			}
			else
			{
				++iter;
			}
		}
	}

	void _EraseFarst(ViVector3 center)
	{
		if (_objs.Count == 0)
		{
			return;
		}
		float fMaxDist = 0.0f;
		//
		int iterFar = 0;
		for (int iter = 0; iter < _objs.Count; ++iter)
		{
			TEntity iterEntity = _objs[iter].Obj;
			float iterDist = iterEntity.GetDistance(center);
			if (fMaxDist <= iterDist)
			{
				fMaxDist = iterDist;
				iterFar = iter;
			}
		}
		_objs.RemoveAt(iterFar);
	}

	TEntity GetNearst(Queue<TEntity> objs, ViVector3 center)
	{
		TEntity pkNearst = null;
		float fMinDist = 100.0f;
		ViDebuger.AssertError(_deleIsInRange);
		ViDebuger.AssertError(_deleIsStateMatch);
		for (int iter = 0; iter < _objs.Count; ++iter)
		{
			TEntity iterEntity = _objs[iter].Obj;
			if (_Has(iterEntity))
			{
				continue;
			}
			if (!_deleIsInRange(iterEntity, center))
			{
				continue;
			}
			if (!_deleIsStateMatch(iterEntity))
			{
				continue;
			}
			float fDist = iterEntity.GetDistance(center);
			if (fMinDist > fDist)
			{
				fMinDist = fDist;
				pkNearst = iterEntity;
			}
		}
		return pkNearst;
	}

	public abstract void _OnDirCenterUpdated(float fDir, ViVector3 center);

	List<ViRefPtr<TEntity>> _objs = new List<ViRefPtr<TEntity>>();

}