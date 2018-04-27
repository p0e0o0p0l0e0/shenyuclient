using System;
using System.Collections.Generic;


class ViPixelNavigateDestChecker_0 : ViAstarDestChecker
{
	public override bool IsDest(ViAstarStep step)
	{
		return (Object.ReferenceEquals(step, Dest));
	}
	public ViAstarStep Dest;
}

class ViPixelNavigateDestChecker_1 : ViAstarDestChecker
{
	public override bool IsDest(ViAstarStep step)
	{
		return (ViAstarStep.Distance(step, Dest) < Diff);
	}
	public ViAstarStep Dest;
	public float Diff;
}

public class ViPixelNavigateStepDynamicCostArray : ViAstarStepDynamicCostArray
{
	public void Init(Int32 sizeX, Int32 sizeY)
	{
		_sizeX = sizeX;
		_sizeY = sizeY;
	}

	public override Int32 Value(ViAstarStep kStep) 
	{
		if (_valueArray == null)
		{
			return 0;
		}
		else
		{
			if (!System.Object.ReferenceEquals(kStep, ViAstarStep.EMPTY))
			{
				return _valueArray[kStep.Pos.x + kStep.Pos.y * _sizeX];
			}
			else
			{
				return 0;
			}
		}
	}

	public void Mod(Int32 x, Int32 y, Int32 deltaValue)
	{
		if (_valueArray == null)
		{
			_valueArray = new Int32[_sizeY * _sizeX];
		}
		_valueArray[x + y * _sizeX] += deltaValue;
	}

	public void Clear()
	{
		_valueArray = null;
	}

	public Int32 _sizeX;
	public Int32 _sizeY;
	public Int32[] _valueArray;
}

public struct ViPixelNavigatePickData
{
	public Int32 HitX;
	public Int32 HitY;
	public Int32 LastX;
	public Int32 LastY;
}

public class ViPixelNavigator
{
	public static Int32 BLOCK_VALUE = 1;

	public List<ViVector3> Route { get { return _route; } }

	public Int32 SizeX { get { return _sizeX; } }
	public Int32 SizeY { get { return _sizeY; } }

	public ViPixelNavigator(UInt32 heapSize)
	{
		_astar0 = new ViAstar<ViPixelNavigateDestChecker_0, ViAstarStepDynamicCostArray>(heapSize);
		_astar1 = new ViAstar<ViPixelNavigateDestChecker_1, ViAstarStepDynamicCostArray>(heapSize);
		_astar0.DestChecker = new ViPixelNavigateDestChecker_0();
		_astar0.StepDynamicCostArray = _stepDynamicCostArray;
		_astar1.DestChecker = new ViPixelNavigateDestChecker_1();
		_astar1.StepDynamicCostArray = _stepDynamicCostArray;
	}

	public void Clear()
	{
		_steps = null;
		_route.Clear();
		_stepPool.Clear();
		_astar0.Clear();
		_astar1.Clear();
		_stepDynamicCostArray.Clear();
	}

	public void SetSize(Int32 sizeX, Int32 sizeY)
	{
		Int32 count = sizeX * sizeY;
		if (count == 0)
		{
			return;
		}
		_steps = new ViAstarStep[count];
		_sizeX = sizeX;
		_sizeY = sizeY;
		//
		ViAstarStep.EMPTY.Cost = BLOCK_VALUE;
		ViAstarStep.EMPTY.Pos.x = -1;
		ViAstarStep.EMPTY.Pos.y = -1;
		for (Int32 iterY = 0; iterY < _sizeY; ++iterY)
		{
			for (Int32 iterX = 0; iterX < _sizeX; ++iterX)
			{
				_steps[iterX + iterY * _sizeX] = ViAstarStep.EMPTY;
			}
		}
		//
		_stepDynamicCostArray.Init(_sizeX, _sizeX);
	}

	public void SetBlock(Int32 x, Int32 y, Int32 value)
	{
		if (x < _sizeX && y < _sizeY)
		{
			ViAstarStep step = new ViAstarStep();
			step.Cost = value;
			step.Pos.x = x;
			step.Pos.y = y;
			_steps[x + y * _sizeX] = step;
		}
	}

	public void EndBlockUpdate()
	{
		EndBlockUpdate(1, 1, _sizeX - 1, _sizeY - 1);
	}

	public void EndBlockUpdate(Int32 minX, Int32 minY, Int32 maxX, Int32 maxY)
	{
		for (Int32 iterY = minY; iterY < maxY; ++iterY)
		{
			for (Int32 iterX = minX; iterX < maxX; ++iterX)
			{
				_Fresh(iterX, iterY);
			}
		}
	}

	public bool IsBlock(Int32 x, Int32 y)
	{
		return IsValue(x, y, 0, NotEqual);
	}

	public void ModDynamicBlock(Int32 x, Int32 y, Int32 deltaValue)
	{
		if (0 < x && x < _sizeX - 1 && 0 < y && y < _sizeY - 1)
		{
			if (_steps[x + y * _sizeX].Cost != BLOCK_VALUE)
			{
				_stepDynamicCostArray.Mod(x, y, deltaValue);
			}
		}
	}

	public bool _IsValue(Int32 x, Int32 y, Int32 cost)
	{
		if (0 < x && x < _sizeX - 1 && 0 < y && y < _sizeY - 1)
		{
			return (_steps[x + y * _sizeX].Cost == cost);
		}
		else
		{
			return false;
		}
	}

	public delegate bool DeleValue(Int32 left, Int32 right);
	public static bool Equal(Int32 left, Int32 right) { return left == right; }
	public static bool NotEqual(Int32 left, Int32 right) { return left != right; }
	public static DeleValue EXEC_Equal = Equal;
	public static DeleValue EXEC_NotEqual = NotEqual;
	public bool IsValue(Int32 x, Int32 y, Int32 value, DeleValue dele)
	{
        if (_steps == null)
        {
            return false;
        }
        if (0 < x && x < _sizeX - 1 && 0 < y && y < _sizeY - 1)
		{
			ViAstarStep step = _steps[x + y * _sizeX];
			return dele(step.Cost + _stepDynamicCostArray.Value(step), value);
		}
		else
		{
			return false;
		}
	}

	public bool GetRound(Int32 rootX, Int32 rootY, Int32 value, DeleValue deleValue, Int32 range, ref Int32 roundX, ref Int32 roundY)
	{
		if (IsValue(rootX, rootY, value, deleValue))
		{
			roundX = rootX;
			roundY = rootY;
			return true;
		}
		float minDiff2 = float.MaxValue;
		for (Int32 iterRange = 1; iterRange < range; ++iterRange)
		{
			// iSrcX - iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iX = rootX - iterRange;
				Int32 iY = rootY + iter;
				if (IsValue(iX, iY, value, deleValue))
				{
					float iterDiff2 = iterRange * iterRange + iter * iter;
					if (iterDiff2 < minDiff2)
					{
						minDiff2 = iterDiff2;
						roundX = iX;
						roundY = iY;
					}
				}
			}
			// iSrcX + iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iX = rootX + iterRange;
				Int32 iY = rootY + iter;
				if (IsValue(iX, iY, value, deleValue))
				{
					float iterDiff2 = iterRange * iterRange + iter * iter;
					if (iterDiff2 < minDiff2)
					{
						minDiff2 = iterDiff2;
						roundX = iX;
						roundY = iY;
					}
				}
			}
			// iSrcY - iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iX = rootX + iter;
				Int32 iY = rootY - iterRange;
				if (IsValue(iX, iY, value, deleValue))
				{
					float iterDiff2 = iterRange * iterRange + iter * iter;
					if (iterDiff2 < minDiff2)
					{
						minDiff2 = iterDiff2;
						roundX = iX;
						roundY = iY;
					}
				}
			}
			// iSrcY + iRangeIdx
			for (int iter = -iterRange; iter <= iterRange; ++iter)
			{
				Int32 iX = rootX + iter;
				Int32 iY = rootY + iterRange;
				if (IsValue(iX, iY, value, deleValue))
				{
					float iterDiff2 = iterRange * iterRange + iter * iter;
					if (iterDiff2 < minDiff2)
					{
						minDiff2 = iterDiff2;
						roundX = iX;
						roundY = iY;
					}
				}
			}
		}
		//
		return minDiff2 < float.MaxValue;
	}

	public bool GetRoundInRange1(Int32 rootX, Int32 rootY, Int32 value, DeleValue deleValue, ref Int32 iRoundX, ref Int32 iRoundY)
	{
		if (IsValue(rootX, rootY, value, deleValue))
		{
			iRoundX = rootX;
			iRoundY = rootY;
			return true;
		}
		for (Int32 iterY = rootY - 1; iterY <= rootY + 1; ++iterY)
		{
			for (Int32 iterX = rootX - 1; iterX <= rootX + 1; ++iterX)
			{
				if (IsValue(iterX, iterY, value, deleValue))
				{
					iRoundX = iterX;
					iRoundY = iterY;
					return true;
				}
			}
		}
		return false;
	}

	public bool Search(Int32 srcX, Int32 srcY, Int32 destX, Int32 destY, UInt32 maxStep)
	{
		_route.Clear();
		//ViDebuger.Note("Search((" + srcX + ", " + srcY + "), (" + destX + ", " + destY + "))");
		if ((0 < srcX && srcX < _sizeX - 1 && 0 < srcY && srcY < _sizeY - 1) == false || (0 < destX && destX < _sizeX - 1 && 0 < destY && destY < _sizeY - 1) == false)
		{
			return false;
		}
		Int32 modSrcX = srcX;
		Int32 modSrcY = srcY;
		GetRound(srcX, srcY, 0, EXEC_Equal, 100, ref modSrcX, ref modSrcY);
		Int32 modDestX = destX;
		Int32 modDestY = destY;
		GetRound(destX, destY, 0, EXEC_Equal, 100, ref modDestX, ref modDestY);
		bool destMod = (modDestX == destX && modDestY == destY);
		if (modSrcX == modDestX && modSrcY == modDestY)
		{
			_route.Add(new ViVector3(modSrcX, modSrcY, 0));
			return destMod;
		}
		if (!Pick(modSrcX, modSrcY, modDestX, modDestY))
		{
			_route.Add(new ViVector3(modSrcX, modSrcY, 0));
			_route.Add(new ViVector3(modDestX, modDestY, 0));
			return destMod;
		}
		ViAstarStep modSrcStep = _steps[modSrcX + modSrcY * _sizeX];
		ViAstarStep modDestStep = _steps[modDestX + modDestY * _sizeX];
		_astar0.DestChecker.Dest = modDestStep;
		_astar0.MaxStepCnt = maxStep;
		bool reachDest = _astar0.Search(modSrcStep, modDestStep, Int32.MaxValue - 1);
		_stepPool.Clear();
		bool removedCost;
		_astar0.MakeRoute(_stepPool, 0, out removedCost);
		_astar0.Reset();
		if (removedCost)
		{
			reachDest = false;
		}
		ClipRoute(_stepPool, _route);
		return reachDest && destMod;
	}

	public bool Search(Int32 srcX, Int32 srcY, Int32 destX, Int32 destY, float fDiff, UInt32 maxStep)
	{
		//ViDebuger.Note("Search((" + srcX + ", " + srcY + "), (" + destX + ", " + destY + "))");
		if ((0 < srcX && srcX < _sizeX - 1 && 0 < srcY && srcY < _sizeY - 1) == false || (0 < destX && destX < _sizeX - 1 && 0 < destY && destY < _sizeY - 1) == false)
		{
			return false;
		}
		GetRound(srcX, srcY, 0, EXEC_Equal, 100, ref srcX, ref srcY);
		ViAstarStep srcStep = _steps[srcX + srcY * _sizeX];
		ViAstarStep destStep = _steps[destX + destY * _sizeX];
		_astar1.DestChecker.Dest = destStep;
		_astar1.DestChecker.Diff = fDiff;
		_astar1.MaxStepCnt = maxStep;
		bool reachDest = _astar1.Search(srcStep, destStep, Int32.MaxValue - 1);
		_route.Clear();
		_stepPool.Clear();
		bool removedCost;
		_astar1.MakeRoute(_stepPool, 0, out removedCost);
		_astar1.Reset();
		if (removedCost)
		{
			reachDest = false;
		}
		ClipRoute(_stepPool, _route);
		return reachDest;
	}

	public bool SearchFront(Int32 srcX, Int32 srcY, ViVector3 direction, float distance)
	{
      //  distance = 0.5f;

        if ((0 < srcX && srcX < _sizeX - 1 && 0 < srcY && srcY < _sizeY - 1) == false)
		{
			return false;
		}
		//
		Int32 directionXSign = ViMathDefine.IntNear(ViMathDefine.Sign(direction.x));
		Int32 directionYSign = ViMathDefine.IntNear(ViMathDefine.Sign(direction.y));
		_route.Clear();
		while (distance > 0)
		{
			Int32 destX = srcX + ViMathDefine.IntNear(direction.x * distance);
			Int32 destY = srcY + ViMathDefine.IntNear(direction.y * distance);
			//
			ViPixelNavigatePickData iterPickResult = new ViPixelNavigatePickData();
			if (Pick(srcX, srcY, destX, destY, 0, EXEC_NotEqual, ref iterPickResult))
			{
				if (iterPickResult.LastX == srcX && iterPickResult.LastY == srcY)
				{
					if (ViMathDefine.Abs(direction.x) > ViMathDefine.Abs(direction.y))
					{
						if (!IsBlock(iterPickResult.LastX + directionXSign, iterPickResult.LastY))//(LastX + directionXSign, LastY)
						{
							Int32 localX = iterPickResult.LastX + directionXSign;
							Int32 localY = iterPickResult.LastY;
							_route.Add(new ViVector3(localX, localY, 0));
							distance -= ViMath2D.Length(localX, localY, srcX, srcY);
							srcX = localX;
							srcY = localY;
						}
						else if (!IsBlock(iterPickResult.LastX, iterPickResult.LastY + directionYSign))//(LastX, LastY + directionYSign)
						{
							Int32 localX = iterPickResult.LastX;
							Int32 localY = iterPickResult.LastY + directionYSign;
							_route.Add(new ViVector3(localX, localY, 0));
							distance -= ViMath2D.Length(localX, localY, srcX, srcY);
							srcX = localX;
							srcY = localY;
						}
						else if (!IsBlock(iterPickResult.LastX + directionXSign, iterPickResult.LastY - directionYSign))//(LastX + directionXSign, LastY - directionYSign)
						{
							Int32 localX = iterPickResult.LastX + directionXSign;
							Int32 localY = iterPickResult.LastY - directionYSign;
							_route.Add(new ViVector3(localX, localY, 0));
							distance -= ViMath2D.Length(localX, localY, srcX, srcY);
							srcX = localX;
							srcY = localY;
						}
						else
						{
							distance = 0.0f;
						}
					}
					else
					{
						if (!IsBlock(iterPickResult.LastX, iterPickResult.LastY + directionYSign))//(LastX, LastY + directionYSign)
						{
							Int32 localX = iterPickResult.LastX;
							Int32 localY = iterPickResult.LastY + directionYSign;
							_route.Add(new ViVector3(localX, localY, 0));
							distance -= ViMath2D.Length(localX, localY, srcX, srcY);
							srcX = localX;
							srcY = localY;
						}
						else if (!IsBlock(iterPickResult.LastX + directionXSign, iterPickResult.LastY))//(LastX + directionXSign, LastY)
						{
							Int32 localX = iterPickResult.LastX + directionXSign;
							Int32 localY = iterPickResult.LastY;
							_route.Add(new ViVector3(localX, localY, 0));
							distance -= ViMath2D.Length(localX, localY, srcX, srcY);
							srcX = localX;
							srcY = localY;
						}
						else if (!IsBlock(iterPickResult.LastX - directionXSign, iterPickResult.LastY + directionYSign))//(LastX - directionXSign, LastY + directionYSign)
						{
							Int32 localX = iterPickResult.LastX - directionXSign;
							Int32 localY = iterPickResult.LastY + directionYSign;
							_route.Add(new ViVector3(localX, localY, 0));
							distance -= ViMath2D.Length(localX, localY, srcX, srcY);
							srcX = localX;
							srcY = localY;
						}
						else
						{
							distance = 0.0f;
						}
					}
				}
				else
				{
					_route.Add(new ViVector3(iterPickResult.LastX, iterPickResult.LastY));
					distance -= ViMath2D.Length(iterPickResult.LastX, iterPickResult.LastY, srcX, srcY);
					srcX = iterPickResult.LastX;
					srcY = iterPickResult.LastY;
				}
			}
			else
			{
				_route.Add(new ViVector3(destX, destY));
				distance = 0;
			}
		}
		//
		ClipRoute(_route);
		//
		return true;
	}

	public void ClipRoute(List<ViAstarStep> complex, List<ViVector3> simple)
	{
		if (complex.Count <= 2)
		{
			for (Int32 idx = 0; idx < complex.Count; ++idx)
			{
				ViAstarStep pre = complex[idx];
				simple.Add(new ViVector3(pre.Pos.x, pre.Pos.y, 0));
			}
			return;
		}
		ViAstarStep from = complex[0];
		simple.Add(new ViVector3(from.Pos.x, from.Pos.y, 0));
		for (Int32 iter = 2; iter < complex.Count; ++iter)
		{
			ViAstarStep current = complex[iter];
			if (Pick(from.Pos.x, from.Pos.y, current.Pos.x, current.Pos.y))
			{
				ViAstarStep pre = complex[iter - 1];
				simple.Add(new ViVector3(pre.Pos.x, pre.Pos.y, 0));
				from = pre;
			}
		}
		ViAstarStep back = complex[complex.Count - 1];
		simple.Add(new ViVector3(back.Pos.x, back.Pos.y, 0));
	}

	public void ClipRoute(List<ViVector3> list)
	{
		if (list.Count <= 2)
		{
			return;
		}
		ViVector3 from = list[0];
		Int32 fromIdx = 0;
		for (Int32 iter = 2; iter < list.Count; ++iter)
		{
			ViVector3 current = list[iter];
			if (Pick((Int32)from.x, (Int32)from.y, (Int32)current.x, (Int32)current.y))
			{
				list.RemoveRange(fromIdx + 1, (iter - 1) - (fromIdx + 1));// iter >= fromIdx+2
				//
				++fromIdx;
				from = list[fromIdx];
				iter = fromIdx + 1;
			}
		}
		//
		Int32 eraseBackCount = (list.Count - 1) - (fromIdx + 1);
		if (eraseBackCount > 0)
		{
			list.RemoveRange(fromIdx + 1, eraseBackCount);
		}
	}

	public bool Pick(Int32 fromX, Int32 fromY, Int32 destX, Int32 destY)
	{
		ViPixelNavigatePickData data = new ViPixelNavigatePickData();
		return Pick(fromX, fromY, destX, destY, 0, EXEC_NotEqual, ref data);
	}
	public bool Pick(Int32 fromX, Int32 fromY, Int32 destX, Int32 destY, Int32 value, DeleValue dele, ref ViPixelNavigatePickData result)
	{
		Int32 deltaX = destX - fromX;
		Int32 deltaY = destY - fromY;
		if (deltaX == 0 && deltaY == 0)
		{
			return false;
		}
		float absDeltaX = Math.Abs((float)deltaX);
		float absDeltaY = Math.Abs((float)deltaY);
		if (absDeltaX >= absDeltaY)
		{
			if (deltaX < 0)
			{
				return _PickXNegative(fromX, fromY, destX, destY, value, dele, ref result);
			}
			else
			{
				return _PickXPositive(fromX, fromY, destX, destY, value, dele, ref result);
			}
		}
		else
		{
			if (deltaY < 0)
			{
				return _PickYNegative(fromX, fromY, destX, destY, value, dele, ref result);
			}
			else
			{
				return _PickYPositive(fromX, fromY, destX, destY, value, dele, ref result);
			}
		}
	}
	bool _PickXNegative(Int32 fromX, Int32 fromY, Int32 destX, Int32 destY, Int32 value, DeleValue dele, ref ViPixelNavigatePickData result)
	{
		Int32 deltaX = destX - fromX;
		Int32 deltaY = destY - fromY;

		float fromCenterX = (float)fromX + 0.5f;
		float fromCenterY = (float)fromY + 0.5f;

		float fDeltaX = -1.0f;
		float fDeltaY = (float)deltaY / Math.Abs((float)deltaX);

		float pickX = fromCenterX;
		float pickY = fromCenterY;

		for (Int32 iter = fromX; iter > destX; --iter)
		{
			pickX += fDeltaX;
			pickY += fDeltaY;

			Int32 newCellX = (Int32)pickX;
			Int32 newCellY = (Int32)pickY;
			ViAstarStep iterStep = _steps[newCellX + newCellY * _sizeX];
			if (dele(iterStep.Cost + _stepDynamicCostArray.Value(iterStep), value))
			{
				result.HitX = newCellX;
				result.HitY = newCellY;
				result.LastX = (Int32)(pickX - fDeltaX);
				result.LastY = (Int32)(pickY - fDeltaY);
				return true;
			}
		}
		ViAstarStep destStep = _steps[destX + destY * _sizeX];
		if (dele(destStep.Cost + _stepDynamicCostArray.Value(destStep), value))
		{
			result.HitX = destX;
			result.HitY = destY;
			result.LastX = (Int32)(pickX);
			result.LastY = (Int32)(pickY);
			return true;
		}
		return false;
	}
	bool _PickXPositive(Int32 fromX, Int32 fromY, Int32 destX, Int32 destY, Int32 value, DeleValue dele, ref ViPixelNavigatePickData result)
	{
		Int32 deltaX = destX - fromX;
		Int32 deltaY = destY - fromY;

		float fromCenterX = (float)fromX + 0.5f;
		float fromCenterY = (float)fromY + 0.5f;

		float fDeltaX = 1.0f;
		float fDeltaY = (float)deltaY / Math.Abs((float)deltaX);

		float pickX = fromCenterX;
		float pickY = fromCenterY;

		for (Int32 iter = fromX; iter < destX; ++iter)
		{
			pickX += fDeltaX;
			pickY += fDeltaY;

			Int32 newCellX = (Int32)pickX;
			Int32 newCellY = (Int32)pickY;
			ViAstarStep iterStep = _steps[newCellX + newCellY * _sizeX];
			if (dele(iterStep.Cost + _stepDynamicCostArray.Value(iterStep), value))
			{
				result.HitX = newCellX;
				result.HitY = newCellY;
				result.LastX = (Int32)(pickX - fDeltaX);
				result.LastY = (Int32)(pickY - fDeltaY);
				return true;
			}
		}
		ViAstarStep destStep = _steps[destX + destY * _sizeX];
		if (dele(destStep.Cost + _stepDynamicCostArray.Value(destStep), value))
		{
			result.HitX = destX;
			result.HitY = destY;
			result.LastX = (Int32)(pickX);
			result.LastY = (Int32)(pickY);
			return true;
		}
		return false;
	}
	bool _PickYNegative(Int32 fromX, Int32 fromY, Int32 destX, Int32 destY, Int32 value, DeleValue dele, ref ViPixelNavigatePickData result)
	{
		Int32 deltaX = destX - fromX;
		Int32 deltaY = destY - fromY;

		float fromCenterX = (float)fromX + 0.5f;
		float fromCenterY = (float)fromY + 0.5f;

		float fDeltaX = (float)deltaX / Math.Abs((float)deltaY);
		float fDeltaY = -1.0f;
		float pickX = fromCenterX;
		float pickY = fromCenterY;

		for (Int32 iter = fromY; iter > destY; --iter)
		{
			pickX += fDeltaX;
			pickY += fDeltaY;

			Int32 newCellX = (Int32)pickX;
			Int32 newCellY = (Int32)pickY;
			ViAstarStep iterStep = _steps[newCellX + newCellY * _sizeX];
			if (dele(iterStep.Cost + _stepDynamicCostArray.Value(iterStep), value))
			{
				result.HitX = newCellX;
				result.HitY = newCellY;
				result.LastX = (Int32)(pickX - fDeltaX);
				result.LastY = (Int32)(pickY - fDeltaY);
				return true;
			}
		}
		ViAstarStep destStep = _steps[destX + destY * _sizeX];
		if (dele(destStep.Cost + _stepDynamicCostArray.Value(destStep), value))
		{
			result.HitX = destX;
			result.HitY = destY;
			result.LastX = (Int32)(pickX);
			result.LastY = (Int32)(pickY);
			return true;
		}
		return false;
	}
	bool _PickYPositive(Int32 fromX, Int32 fromY, Int32 destX, Int32 destY, Int32 value, DeleValue dele, ref ViPixelNavigatePickData result)
	{
		Int32 deltaX = destX - fromX;
		Int32 deltaY = destY - fromY;

		float fromCenterX = (float)fromX + 0.5f;
		float fromCenterY = (float)fromY + 0.5f;

		float fDeltaX = (float)deltaX / Math.Abs((float)deltaY);
		float fDeltaY = 1.0f;
		float pickX = fromCenterX;
		float pickY = fromCenterY;

		for (Int32 iter = fromY; iter < destY; ++iter)
		{
			pickX += fDeltaX;
			pickY += fDeltaY;

			Int32 newCellX = (Int32)pickX;
			Int32 newCellY = (Int32)pickY;
			ViAstarStep iterStep = _steps[newCellX + newCellY * _sizeX];
			if (dele(iterStep.Cost + _stepDynamicCostArray.Value(iterStep), value))
			{
				result.HitX = newCellX;
				result.HitY = newCellY;
				result.LastX = (Int32)(pickX - fDeltaX);
				result.LastY = (Int32)(pickY - fDeltaY);
				return true;
			}
		}
		ViAstarStep destStep = _steps[destX + destY * _sizeX];
		if (dele(destStep.Cost + _stepDynamicCostArray.Value(destStep), value))
		{
			result.HitX = destX;
			result.HitY = destY;
			result.LastX = (Int32)(pickX);
			result.LastY = (Int32)(pickY);
			return true;
		}
		return false;
	}

	static List<ViAstarRoundStep> CACHE_RoundList = new List<ViAstarRoundStep>();
	void _Fresh(Int32 x, Int32 y)
	{
		int stepIndex = x + y * _sizeX;
		if (stepIndex < 0 || stepIndex >= _steps.Length)
		{
			return;
		}
		ViAstarStep step = _steps[stepIndex];
		if (step.Cost > 0.0f)
		{
			return;
		}
		CACHE_RoundList.Clear();
		for (Int32 iterY = y - 1; iterY < y + 2; ++iterY)
		{
			for (Int32 iterX = x - 1; iterX < x + 2; ++iterX)
			{
				if (iterX == x && iterY == y)
				{
					continue;
				}
				ViAstarStep roundStep = _steps[iterX + iterY * _sizeX];
				if (roundStep.Cost != BLOCK_VALUE)
				{
					ViAstarRoundStep node = new ViAstarRoundStep();
					node.node = roundStep;
					//
					float deltaX = x - iterX;
					float deltaY = y - iterY;
					node.cost = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
					CACHE_RoundList.Add(node);
				}
			}
		}
		step.SetRound(CACHE_RoundList);
	}

	Int32 _sizeX;
	Int32 _sizeY;
	ViAstarStep[] _steps;
	List<ViVector3> _route = new List<ViVector3>();
	List<ViAstarStep> _stepPool = new List<ViAstarStep>();
	ViAstar<ViPixelNavigateDestChecker_0, ViAstarStepDynamicCostArray> _astar0;
	ViAstar<ViPixelNavigateDestChecker_1, ViAstarStepDynamicCostArray> _astar1;
	ViPixelNavigateStepDynamicCostArray _stepDynamicCostArray = new ViPixelNavigateStepDynamicCostArray();

}