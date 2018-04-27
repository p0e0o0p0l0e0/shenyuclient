using System;
using System.Collections.Generic;

public abstract class ViRoundEntityList
{
	public delegate bool DELE_IsInRange(GameUnit entity, ViVector3 center);
	public delegate bool DELE_IsStateMatch(GameUnit entity);
	public DELE_IsInRange DeleIsInRange;
	public DELE_IsStateMatch DeleIsStateMatch;

	public UInt32 Max = 10;
	public List<ViRefPtr<GameUnit>> EntityList { get { return _entityList; } }
	//
	public void Clear()
	{
		_entityList.Clear();
	}
	
	public GameUnit Next(float dir, ViVector3 center, List<GameUnit> entityList)
	{
		if (Max == 0)
		{
			return null;
		}
		GameUnit entity = GetNearst(entityList, center);
		if (entity == null && _entityList.Count > 0)
		{
			entity = _entityList[0].Obj;
			_entityList.RemoveAt(0);
		}
		if (entity != null)
		{
			if (_entityList.Count >= Max)
			{
				_entityList.RemoveAt(0);
			}
			_entityList.Add(new ViRefPtr<GameUnit>(entity));
		}
		return entity;
	}
	public GameUnit Prev()
	{
		if (_entityList.Count == 0)
		{
			return null;
		}
		GameUnit entity = _entityList[_entityList.Count-1].Obj;
		_entityList.RemoveAt(_entityList.Count-1);
		return entity;
	}

	bool _Has(GameUnit entity)
	{
		foreach (ViRefPtr<GameUnit> ptr in _entityList)
		{
			if (ptr.Obj == entity)
			{
				return true;
			}
		}
		return false;
	}
	void _EraseFarst(ViVector3 center)
	{
		if (_entityList.Count == 0)
		{
			return;
		}
		//
		float fMaxDist = 0.0f;
		int iterFar = 0;
		for (int iter = 0; iter < _entityList.Count; ++iter)
		{
			GameUnit entity = _entityList[iter].Obj;
			float fDist = entity.GetDistance(center) * _DisanceScale(entity);
			if (fMaxDist <= fDist)
			{
				fMaxDist = fDist;
				iterFar = iter;
			}
		}
		_entityList.RemoveAt(iterFar);
	}
	GameUnit GetNearst(List<GameUnit> entityList, ViVector3 center)
	{
		GameUnit pkNearst = null;
		float fMinDist = 10000.0f;
		ViDebuger.AssertError(DeleIsInRange);
		ViDebuger.AssertError(DeleIsStateMatch);
		foreach (GameUnit entity in entityList)
		{
			ViDebuger.AssertError(entity);
			if (_Has(entity))
			{
				continue;
			}
			if (!DeleIsInRange(entity, center))
			{
				continue;
			}
			if (!DeleIsStateMatch(entity))
			{
				continue;
			}
			float fDist = entity.GetDistance(center) * _DisanceScale(entity);
			if (fMinDist > fDist)
			{
				fMinDist = fDist;
				pkNearst = entity;
			}
		}
		return pkNearst;
	}

	public abstract void _OnDirCenterUpdated(float fDir, ViVector3 center);
	public abstract float _DisanceScale(GameUnit entity);

	List<ViRefPtr<GameUnit>> _entityList = new List<ViRefPtr<GameUnit>>();

}

public class RoundEntityList : ViRoundEntityList
{
	static ViConstValue<float> VALUE_RoundEntityRange = new ViConstValue<float>("RoundEntityRange", 10.0f);
	static ViConstValue<Int32> VALUE_RoundEntityCount = new ViConstValue<Int32>("RoundEntityCount", 20);

	public void Start()
	{
		DeleIsInRange = this._IsInRange;
		DeleIsStateMatch = this._IsStateMatch;
		Max = (UInt32)VALUE_RoundEntityCount.Value;
	}

	public void End()
	{
		Clear();
		DeleIsInRange = null;
		DeleIsStateMatch = null;
	}
	public void Update()
	{
		for (int iter = 0; iter < EntityList.Count; )
		{
			GameUnit iterEntity = EntityList[iter].Obj;
			if (iterEntity == null)
			{
				EntityList.RemoveAt(iter);
			}
			else
			{
				++iter;
			}
		}
	}

	public override void _OnDirCenterUpdated(float fDir, ViVector3 center)
	{

	}

	public override float _DisanceScale(GameUnit entity)
	{
		CellHero playerEntity = entity as CellHero;
		if (playerEntity != null)
		{
			return 1.0f;
		}
		return 3.0f;
	}

	public bool _IsInRange(GameUnit entity, ViVector3 center)
	{
		return ViGeographicObject.GetDistance2(entity.Position, center) < VALUE_RoundEntityRange * VALUE_RoundEntityRange;
	}
	public bool _IsStateMatch(GameUnit entity)
	{
		if (!entity.VisualActive.Value)
		{
			return false;
		}
		if (!entity.PickActive.Value)
		{
			return false;
		}
		//Int32 attackableStateConditionID = 3;
		//return entity.IsMatchState(attackableStateConditionID, false);
		return true;
	}

}