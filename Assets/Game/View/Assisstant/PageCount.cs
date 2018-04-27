using System;

public class PageCount
{
	public static readonly int MAX_COUNT = 9999999;

	public int Current
	{
		get
		{
			if (_current < 0 && _current >= _count)
			{
				_current = ViMathDefine.Clamp(_current, 0, _count - 1);
			}
			return _current;
		}
		set { _current = ViMathDefine.Clamp(value, 0, _count - 1); }
	}
	public int Count { get { return ViMathDefine.Clamp(_count, 1, MAX_COUNT); } }
	public int PerCount { get { return _perCount; } }
	public int StartIndex { get { return Current * _perCount; } }
	public string PageText { get { return (Current + 1).ToString() + "/" + _count.ToString(); } }
	public int LastPage
	{
		get
		{
			return Count - 1;
		}
	}
	public int Capacity { get { return _capibility; } }

	public bool HasNextPage() { return IsIn(Current + 1); }
	public bool HasPrePage() { return IsIn(Current - 1); }

	public bool NextPage()
	{
		return ModPage(1);
	}

	public bool PrePage()
	{
		return ModPage(-1);
	}

	public bool IsIn(int idx)
	{
		if (idx >= 0 && idx < Count)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool ModPage(int delta)
	{
		if (IsIn(Current + delta))
		{
			Current += delta;
			return true;
		}
		return false;
	}

	public void Reset(int capibility, int perCount)
	{
		_perCount = ViMathDefine.Max(1, perCount);
		_capibility = ViMathDefine.Max(1, capibility);
		_count = (_capibility + _perCount - 1) / _perCount;
		if (_current >= _count)
		{
			_current = ViMathDefine.Max(0, _count - 1);
		}
	}

	int _current = 0;
	int _count = 1;
	int _perCount = 10;
	int _capibility = 0;
}
