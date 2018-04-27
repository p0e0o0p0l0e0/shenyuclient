using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceNavigator
{
	public void Load(Rect area, Byte[] data)
	{
		_mapArea = area;
		_navigatorOffset = new ViVector3(_mapArea.x, _mapArea.y, 0);
		//
		ViIStream IS = new ViIStream();
		IS.Init(data, 0, data.Length);
		Int32 width = 0;
		Int32 height = 0;
		IS.Read(out width);
		IS.Read(out height);
		//
		_navigatorDistanceScale = _mapArea.width / (float)width;
		_navigatorDistanceScaleR = 1.0f / _navigatorDistanceScale;
		//
		_navigator.SetSize(width, height);
		for (int iterY = 0; iterY < height; ++iterY)
		{
			for (int iterX = 0; iterX < width; ++iterX)
			{
				UInt32 value = 0;
				IS.Read(out value);
				if (value == 1)
				{
					//_navigator.SetBlock(iterX, iterY, Int32.MaxValue);
				}
				else
				{
					_navigator.SetBlock(iterX, iterY, 0);
				}
			}
		}
		_navigator.EndBlockUpdate();
        IsReady = true;
    }

	public void Clear()
	{
        IsReady = false;
        ClearNavigateShow();
		_navigator.Clear();
	}

	public void Navigate(ViVector3 fromPos, ViVector3 toPos, UInt32 maxStep, List<ViVector3> route)
	{
		Int32 fromX, fromY, toX, toY;
		if (!FomatPos(fromPos, out fromX, out fromY) || !FomatPos(toPos, out toX, out toY))
		{
			return;
		}
		//
		bool reachDest = _navigator.Search(fromX, fromY, toX, toY, maxStep);
		//
		if (_navigator.Route.Count == 0)
		{
			if (!reachDest)
			{
				ViDebuger.Note("Navigate Fail " + fromPos + "->" + toPos);
			}
		}
		else if (_navigator.Route.Count == 1)
		{
			if (reachDest)
			{
				toPos.z = 0;
				route.Add(toPos);
			}
			else
			{
				ViVector3 pos = _navigator.Route[0];
				if (pos.x != fromX && pos.y != fromY)
				{
					ViVector3 worldPos = new ViVector3();
					worldPos.x = (pos.x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
					worldPos.y = (pos.y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
					worldPos.z = 0;
					route.Add(worldPos);
				}
			}
		}
		else
		{
			if (reachDest)
			{
				for (int idx = 1; idx < _navigator.Route.Count - 1; ++idx)
				{
					ViVector3 pos = _navigator.Route[idx];
					ViVector3 worldPos = new ViVector3();
					worldPos.x = (pos.x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
					worldPos.y = (pos.y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
					worldPos.z = 0;
					route.Add(worldPos);
				}
				toPos.z = 0;
				route.Add(toPos);
			}
			else
			{
				for (int idx = 1; idx < _navigator.Route.Count; ++idx)
				{
					ViVector3 pos = _navigator.Route[idx];
					ViVector3 worldPos = new ViVector3();
					worldPos.x = (pos.x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
					worldPos.y = (pos.y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
					worldPos.z = 0;
					route.Add(worldPos);
				}
			}
		}
	}

	public void Navigate(ViVector3 fromPos, ViVector3 toPos, float diff, UInt32 maxStep, List<ViVector3> route)
	{
		Int32 fromX, fromY, toX, toY;
		if (!FomatPos(fromPos, out fromX, out fromY) || !FomatPos(toPos, out toX, out toY))
		{
			return;
		}
		//
		bool reachDest = _navigator.Search(fromX, fromY, toX, toY, diff * _navigatorDistanceScaleR, maxStep);
		//
		if (_navigator.Route.Count == 0)
		{
			if (!reachDest)
			{
				ViDebuger.Note("Navigate Fail " + fromPos + "->" + toPos + ", Diff = " + diff);
			}
		}
		else if (_navigator.Route.Count == 1)
		{
			ViVector3 pos = _navigator.Route[0];
			ViVector3 worldPos = new ViVector3();
			worldPos.x = (pos.x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
			worldPos.y = (pos.y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
			worldPos.z = 0;
			route.Add(worldPos);
		}
		else
		{
			for (int idx = 1; idx < _navigator.Route.Count; ++idx)
			{
				ViVector3 pos = _navigator.Route[idx];
				ViVector3 worldPos = new ViVector3();
				worldPos.x = (pos.x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
				worldPos.y = (pos.y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
				worldPos.z = 0;
				route.Add(worldPos);
			}
		}
	}

	public void Navigate(ViVector3 fromPos, ViVector3 direction, float distance, List<ViVector3> route)
	{
		ViVector3 destPos = fromPos + direction * distance;
		if (!Pick(fromPos, destPos))
		{
            destPos.z = 0;
            route.Add(destPos);
			return;
		}
		Int32 fromX, fromY;
		if (!FomatPos(fromPos, out fromX, out fromY))
		{
			return;
		}
		//
		_navigator.SearchFront(fromX, fromY, direction, distance * _navigatorDistanceScaleR);
		for (int idx = 0; idx < _navigator.Route.Count; ++idx)
		{
			ViVector3 pos = _navigator.Route[idx];
			ViVector3 worldPos = new ViVector3();
			worldPos.x = (pos.x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
			worldPos.y = (pos.y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
			worldPos.z = 0;
			route.Add(worldPos);
		}
	}

	public void RandomRoute(ViVector3 rootPos, List<ViVector3> route)
	{
		ViVector3 freePos;
		if (RandomFreePos(out freePos))
		{
			Navigate(rootPos, freePos, 100000, route);
		}
	}

	public void RandomRoute(ViVector3 rootPos, float range, List<ViVector3> route)
	{
		ViVector3 freePos;
		if (RandomFreePos(rootPos, range, out freePos))
		{
			Navigate(rootPos, freePos, 100000, route);
		}
	}

	public bool RandomFreePos(ViVector3 rootPos, float range, out ViVector3 freePos)
	{
		for (int idx = 0; idx < 1000; ++idx)
		{
			float infX = ViMathDefine.Max(_navigatorOffset.x, rootPos.x - range);
			float supX = ViMathDefine.Min(_navigatorOffset.x + _mapArea.width, rootPos.x + range);
			float infY = ViMathDefine.Max(_navigatorOffset.y, rootPos.y - range);
			float supY = ViMathDefine.Min(_navigatorOffset.y + _mapArea.height, rootPos.y + range);
			ViVector3 pos = ViVector3.ZERO;
			pos.x = ViRandom.Value((Int32)(infX * 100), (Int32)(supX * 100)) * 0.01f;
			pos.y = ViRandom.Value((Int32)(infY * 100), (Int32)(supY * 100)) * 0.01f;
			if (!IsBlock(pos))
			{
				freePos = pos;
				return true;
			}
		}
		freePos = ViVector3.ZERO;
		return false;
	}

	public bool RandomFreePos(out ViVector3 freePos)
	{
		for (int idx = 0; idx < 1000; ++idx)
		{
			ViVector3 pos = _navigatorOffset;
			pos.x += ViRandom.Value(0, (Int32)(_mapArea.width * 100)) * 0.01f;
			pos.y += ViRandom.Value(0, (Int32)(_mapArea.height * 100)) * 0.01f;
			if (!IsBlock(pos))
			{
				freePos = pos;
				return true;
			}
		}
		freePos = ViVector3.ZERO;
		return false;
	}

	public bool IsBlock(ViVector3 pos)
	{
		if (!IsIn(pos))
		{
			return true;
		}
		ViVector3 localPos = pos - _navigatorOffset;
		Int32 x = (Int32)(localPos.x * _navigatorDistanceScaleR);
		Int32 y = (Int32)(localPos.y * _navigatorDistanceScaleR);
		return _navigator.IsBlock(x, y);
	}

	public void GetDestHeight(ViVector3 fromPos, List<ViVector3> posList, float offset, float defaultHeight)
	{
		ViVector3 iterFrom = fromPos;
		for (int iter = 0; iter < posList.Count; ++iter)
		{
			ViVector3 iterTo = posList[iter];
			iterTo.z = GetDestHeight(iterFrom, posList[iter], defaultHeight) + offset;
			iterFrom = iterTo;
			posList[iter] = iterTo;
		}
	}
	public float GetDestHeight(ViVector3 fromPos, ViVector3 toPos, float defaultHeight)
	{
		if (IsBlock(toPos))
		{
			ViVector3 blockAt = ViVector3.ZERO;
			blockAt.z = defaultHeight;
			if (Pick(toPos, fromPos, ref blockAt, 0, ViPixelNavigator.Equal))
			{
				GroundHeight.GetGroundHeight(ref blockAt);
				return blockAt.z;
			}
			else
			{
				GroundHeight.GetGroundHeight(ref fromPos);
				return fromPos.z;
			}
		}
		else
		{
			toPos.z = defaultHeight;
			GroundHeight.GetGroundHeight(ref toPos);
			return toPos.z;
		}
	}

	public void GetDestHeight(ViVector3 fromPos, List<ViVector3> posList, float radius, float offset, float defaultHeight)
	{
		ViVector3 iterFrom = fromPos;
		for (int iter = 0; iter < posList.Count; ++iter)
		{
			ViVector3 iterTo = posList[iter];
			iterTo.z = GetDestHeight(iterFrom, posList[iter], radius, defaultHeight) + offset;
			iterFrom = iterTo;
			posList[iter] = iterTo;
		}
	}

	public float GetDestHeight(ViVector3 fromPos, ViVector3 toPos, float radius, float defaultHeight)
	{
		if (IsBlock(toPos))
		{
			ViVector3 blockAt = ViVector3.ZERO;
			blockAt.z = defaultHeight;
			if (Pick(toPos, fromPos, ref blockAt, 0, ViPixelNavigator.Equal))
			{
				GroundHeight.GetGroundHeight(radius, ref blockAt);
				return blockAt.z;
			}
			else
			{
				GroundHeight.GetGroundHeight(radius, ref fromPos);
				return fromPos.z;
			}
		}
		else
		{
			toPos.z = defaultHeight;
			GroundHeight.GetGroundHeight(radius, ref toPos);
			return toPos.z;
		}
	}

	public bool Pick(ViVector3 fromPos, ViVector3 toPos)
	{
		ViVector3 pos = new ViVector3();
		return Pick(fromPos, toPos, ref pos);
	}

	public bool Pick(ViVector3 fromPos, ViVector3 toPos, ref ViVector3 pos)
	{
		return Pick(fromPos, toPos, ref pos, 0, ViPixelNavigator.EXEC_NotEqual);
	}

	public bool Pick(ViVector3 fromPos, ViVector3 toPos, ref ViVector3 pos, Int32 value, ViPixelNavigator.DeleValue dele)
	{
		if (!IsIn(fromPos))
		{
			return false;
		}
		FomatPos(fromPos, ref toPos);
		ViVector3 localFromPos = fromPos - _navigatorOffset;
		Int32 fromX = (Int32)(localFromPos.x * _navigatorDistanceScaleR);
		Int32 fromY = (Int32)(localFromPos.y * _navigatorDistanceScaleR);
		ViVector3 localToPos = toPos - _navigatorOffset;
		Int32 toX = (Int32)(localToPos.x * _navigatorDistanceScaleR);
		Int32 toY = (Int32)(localToPos.y * _navigatorDistanceScaleR);

		ViPixelNavigatePickData data = new ViPixelNavigatePickData();
		if (_navigator.Pick(fromX, fromY, toX, toY, value, dele, ref data))
		{
			pos.x = (data.LastX + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
			pos.y = (data.LastY + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
			pos.z = 0;
			return true;
		}
		else
		{
			pos = toPos;
			pos.z = 0;
			return false;
		}
	}

	public bool Pick(ViVector3 fromPos, ViVector3 toPos, ref ViVector3 pos, Int32 value, ViPixelNavigator.DeleValue dele, out ViVector3 normal)
	{
		normal = ViVector3.ZERO;
		if (!IsIn(fromPos))
		{
			return false;
		}
		FomatPos(fromPos, ref toPos);
		ViVector3 localFromPos = fromPos - _navigatorOffset;
		Int32 fromX = (Int32)(localFromPos.x * _navigatorDistanceScaleR);
		Int32 fromY = (Int32)(localFromPos.y * _navigatorDistanceScaleR);
		ViVector3 localToPos = toPos - _navigatorOffset;
		Int32 toX = (Int32)(localToPos.x * _navigatorDistanceScaleR);
		Int32 toY = (Int32)(localToPos.y * _navigatorDistanceScaleR);
		//
		ViPixelNavigatePickData pickResult = new ViPixelNavigatePickData();
		if (_navigator.Pick(fromX, fromY, toX, toY, value, dele, ref pickResult))
		{
			pos.x = (pickResult.LastX + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
			pos.y = (pickResult.LastY + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
			pos.z = 0;
			if ((pickResult.LastX - pickResult.HitX) * (pickResult.LastY - pickResult.HitY) == 0)
			{
				normal.x = (float)(pickResult.LastX - pickResult.HitX);
				normal.y = (float)(pickResult.LastY - pickResult.HitY);
				normal.z = 0;
			}
			else
			{
				if (_navigator.IsBlock(pickResult.LastX, pickResult.HitY))//(LastX, HitY)
				{
					//(LastX, HitY) -> (LastX, LastY)
					normal.x = (float)(pickResult.LastX - pickResult.LastX);
					normal.y = (float)(pickResult.LastY - pickResult.HitY);
				}
				else
				{
					//(HitX, HitY) -> (LastX, HitY)
					normal.x = (float)(pickResult.LastX - pickResult.HitX);
					normal.y = (float)(pickResult.HitY - pickResult.HitY);
				}
				if (_navigator.IsBlock(pickResult.HitX, pickResult.LastY))//(HitX, LastY)
				{
					//(HitX, LastY) -> (LastX, LastY)
					normal.x = (float)(pickResult.LastX - pickResult.HitX);
					normal.y = (float)(pickResult.LastY - pickResult.LastY);
				}
				else
				{
					//(HitX, HitY) -> (HitX, LastY)
					normal.x = (float)(pickResult.HitX - pickResult.HitX);
					normal.y = (float)(pickResult.LastY - pickResult.HitY);
				}
				normal.z = 0;
			}
			normal.Normalize();
			return true;
		}
		else
		{
			pos = toPos;
			pos.z = 0;
			return false;
		}
	}

	public void FomatPos(ViVector3 kOldPos, ref ViVector3 kNewPos)
	{
		ViDebuger.AssertError(IsIn(kOldPos));
		//
		if (kNewPos.x < _mapArea.xMin)
		{
			float fMinX = _mapArea.xMin + _navigatorDistanceScale;
			kNewPos.y = (kNewPos.y - kOldPos.y) * (fMinX - kOldPos.x) / (kNewPos.x - kOldPos.x) + kOldPos.y;
			kNewPos.x = fMinX;
		}
		else if (kNewPos.x > _mapArea.xMax)
		{
			float fMaxX = _mapArea.xMax - _navigatorDistanceScale;
			kNewPos.y = (kNewPos.y - kOldPos.y) * (fMaxX - kOldPos.x) / (kNewPos.x - kOldPos.x) + kOldPos.y;
			kNewPos.x = fMaxX;
		}
		//
		if (kNewPos.y < _mapArea.yMin)
		{
			float fMinY = _mapArea.yMin + _navigatorDistanceScale;
			kNewPos.x = (kNewPos.x - kOldPos.x) * (fMinY - kOldPos.y) / (kNewPos.y - kOldPos.y) + kOldPos.x;
			kNewPos.y = fMinY;
		}
		else if (kNewPos.y > _mapArea.yMax)
		{
			float fMaxY = _mapArea.yMax - _navigatorDistanceScale;
			kNewPos.x = (kNewPos.x - kOldPos.x) * (fMaxY - kOldPos.y) / (kNewPos.y - kOldPos.y) + kOldPos.x;
			kNewPos.y = fMaxY;
		}
		//
		ViDebuger.AssertError(IsIn(kNewPos));
	}

	public bool FomatPos(ViVector3 pos, out Int32 x, out Int32 y)
	{
		ViVector3 localPos = pos - _navigatorOffset;
		x = (Int32)(localPos.x * _navigatorDistanceScaleR);
		y = (Int32)(localPos.y * _navigatorDistanceScaleR);
		return (0 <= x && x < _navigator.SizeX) && (0 <= y && y < _navigator.SizeY);
	}

	public bool FomatPos(Int32 x, Int32 y, out ViVector3 pos)
	{
		pos = ViVector3.ZERO;
		pos.x = (x + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
		pos.y = (y + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
		return IsIn(pos);
	}

	public void FomatPos(ViVector3 pos, out float scaleX, out float scaleY)
	{
		ViVector3 localPos = pos - _navigatorOffset;
		scaleX = localPos.x / _mapArea.width;
		scaleY = localPos.y / _mapArea.height;
	}

	public ViVector3 FomatPos(float scaleX, float scaleY)
	{
		ViVector3 localPos = new ViVector3(scaleX * _mapArea.width, scaleY * _mapArea.height);
		return localPos + _navigatorOffset;
	}

	public bool SameSlot(ViVector3 left, ViVector3 right)
	{
		return (Int32)(left.x * _navigatorDistanceScaleR) == (Int32)(right.x * _navigatorDistanceScaleR) && (Int32)(left.y * _navigatorDistanceScaleR) == (Int32)(right.y * _navigatorDistanceScaleR);
	}

	bool IsIn(ViVector3 pos)
	{
		return (_mapArea.xMin <= pos.x && pos.x <= _mapArea.xMax) && (_mapArea.yMin <= pos.y && pos.y <= _mapArea.yMax);
	}

	public bool GetRoundMovable(ViVector3 oldPos, ref ViVector3 newPos)
	{
		FomatPos(oldPos, ref newPos);
		ViVector3 localPos = newPos - _navigatorOffset;
		Int32 rootX = (Int32)(localPos.x * _navigatorDistanceScaleR);
		Int32 rootY = (Int32)(localPos.y * _navigatorDistanceScaleR);
		Int32 movableX = 0;
		Int32 movableY = 0;
		bool result = GetRoundMovable(rootX, rootY, 100, out movableX, out movableY);
		//
		ViVector3 localMovablePos = new ViVector3(_navigatorDistanceScale * movableX, _navigatorDistanceScale * movableY);
		newPos = localMovablePos + _navigatorOffset;
		return result;
	}

    public bool GetRoundMovableNew(ViVector3 oldPos, ref ViVector3 newPos)
    {
        ViVector3 localPos = oldPos - _navigatorOffset;
        Int32 rootX = (Int32)(localPos.x * _navigatorDistanceScaleR);
        Int32 rootY = (Int32)(localPos.y * _navigatorDistanceScaleR);
        Int32 movableX = 0;
        Int32 movableY = 0;
        bool result = GetRoundMovable(rootX, rootY, 100, out movableX, out movableY);
        //
        ViVector3 localMovablePos = new ViVector3(_navigatorDistanceScale * movableX, _navigatorDistanceScale * movableY);
        newPos = localMovablePos + _navigatorOffset;
        return result;
    }

    public bool GetRoundMovable(Int32 rootX, Int32 rootY, Int32 range, out Int32 roundX, out Int32 roundY)
	{
		if (!_navigator.IsBlock(rootX, rootY))
		{
			roundX = rootX;
			roundY = rootY;
			return true;
		}
		//
		Int32 iMinDiff2 = Int32.MaxValue;
		roundX = rootX;
		roundY = rootY;
		for (Int32 iterRange = 1; iterRange < range; ++iterRange)
		{
			// iSrcX - iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iterX = rootX - iterRange;
				Int32 iterY = rootY + iter;
				if (!_navigator.IsBlock(iterX, iterY))
				{
					range = iterRange;
					Int32 iterDiff2 = iter * iter + iterRange * iterRange;
					if (iterDiff2 < iMinDiff2)
					{
						iMinDiff2 = iterDiff2;
						roundX = iterX;
						roundY = iterY;
					}
				}
			}
			// iSrcX + iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iterX = rootX + iterRange;
				Int32 iterY = rootY + iter;
				if (!_navigator.IsBlock(iterX, iterY))
				{
					range = iterRange;
					Int32 iterDiff2 = iter * iter + iterRange * iterRange;
					if (iterDiff2 < iMinDiff2)
					{
						iMinDiff2 = iterDiff2;
						roundX = iterX;
						roundY = iterY;
					}
				}
			}
			// iSrcY - iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iterX = rootX + iter;
				Int32 iterY = rootY - iterRange;
				if (!_navigator.IsBlock(iterX, iterY))
				{
					range = iterRange;
					Int32 iterDiff2 = iter * iter + iterRange * iterRange;
					if (iterDiff2 < iMinDiff2)
					{
						iMinDiff2 = iterDiff2;
						roundX = iterX;
						roundY = iterY;
					}
				}
			}
			// iSrcY + iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iterX = rootX + iter;
				Int32 iterY = rootY + iterRange;
				if (!_navigator.IsBlock(iterX, iterY))
				{
					range = iterRange;
					Int32 iterDiff2 = iter * iter + iterRange * iterRange;
					if (iterDiff2 < iMinDiff2)
					{
						iMinDiff2 = iterDiff2;
						roundX = iterX;
						roundY = iterY;
					}
				}
			}
		}
		//
		return iMinDiff2 < Int32.MaxValue;
	}

	bool IsNavigatePixelShow(Int32 x, Int32 y)
	{
		// 本身不可行走, 但周围有可行走的点
		if (!_navigator.IsBlock(x, y))
		{
			return false;
		}
		for (int iterY = -1; iterY <= 1; ++iterY)
		{
			for (int iterX = -1; iterX <= 1; ++iterX)
			{
				Int32 roundX = x + iterX;
				Int32 roundY = y + iterY;
				if (0 <= roundX && roundX < _navigator.SizeX && 0 <= roundY && roundY < _navigator.SizeY)
				{
					if (!_navigator.IsBlock(roundX, roundY))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public void ShowNavigate()
	{
		ClearNavigateShow();
		//
		GameObject root = new GameObject("ShowNavigate");
		Transform rootTran = root.transform;
		ViVector3 pos = ViVector3.ZERO;
		for (int iterY = 0; iterY < _navigator.SizeY; ++iterY)
		{
			for (int iterX = 0; iterX < _navigator.SizeX; ++iterX)
			{
				if (IsNavigatePixelShow(iterX, iterY))
				{
					pos.x = (iterX + 0.5f) * _navigatorDistanceScale + _navigatorOffset.x;
					pos.y = (iterY + 0.5f) * _navigatorDistanceScale + _navigatorOffset.y;
					GroundHeight.GetGroundHeight(ref pos);
					GameObject iterBox = UnityAssisstant.Instantiate(GlobalGameObject.Instance.FocusEntity.GameObject, pos.Convert(), Quaternion.identity);
					iterBox.transform.parent = rootTran;
					iterBox.name = "Box_" + iterX + "_" + iterY;
				}
			}
		}
		rootTran.parent = GameObjectPath.Instance.NavigateShow.transform;
	}

	public void ClearNavigateShow()
	{
		Transform root = GameObjectPath.Instance.NavigateShow.transform.Find("ShowNavigate");
		if (root != null)
		{
			GameObject rootObj = root.gameObject;
			UnityAssisstant.Destroy(ref rootObj);
		}
	}

	public void ModNavigateBlock(ViVector3 pos, Int32 range, Int32 deltaValue)
	{
		Int32 x, y;
		if (FomatPos(pos, out x, out y))
		{
			_navigator.ModDynamicBlock(x, y, deltaValue);
			for (Int32 iterY = y - range + 1; iterY < y + range; ++iterY)
			{
				for (Int32 iterX = x - range + 1; iterX < x + range; ++iterX)
				{
					_navigator.ModDynamicBlock(iterX, iterY, deltaValue);
				}
			}
		}
	}

    public bool IsReady = false;

    ViPixelNavigator _navigator = new ViPixelNavigator(10000);
	Rect _mapArea = new Rect(-50, -50, 100, 100);
	ViVector3 _navigatorOffset;
	float _navigatorDistanceScale;
	float _navigatorDistanceScaleR;
}