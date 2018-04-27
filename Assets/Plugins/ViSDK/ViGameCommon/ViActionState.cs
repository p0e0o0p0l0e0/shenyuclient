using System;
using System.Collections.Generic;

public class ViActionState
{
    public virtual Int32 Weight { get; set; }
    public bool Active { get { return _active; } }
    public virtual UInt32 EndMask { get { return UInt32.MaxValue; } }

    public virtual Int32 Type { get { return 0; } }

    public virtual bool Reset() { return false; }

    public virtual void OnPreReset() { }
    public virtual void OnReset() { }
    public virtual void OnActive() { }
    public virtual void OnDeactive() { }
    public virtual void OnClear() { }

    public void SetActive(bool active) { _active = active; }

    bool _active = false;
}


public class ViActionStateList
{
    public ViActionState ActiveState { get { return _activeState; } }

    public void Register(ViActionState state)
    {
        if (_stateList.Contains(state))
        {
            return;
        }
        for (int idx = 0; idx < _stateList.Count; ++idx)
        {
            ViActionState iterState = _stateList[idx];
            if (state.Weight >= iterState.Weight)
            {
                _stateList.Insert(idx, state);
                return;
            }
        }
        _stateList.Add(state);
    }

    public void Clear()
    {
        if (_activeState != null)
        {
            _activeState.OnDeactive();
            _activeState.SetActive(false);
            _activeState = null;
        }
        //
        foreach (ViActionState iterState in _stateList)
        {
            iterState.OnClear();
        }
        _stateList.Clear();
        //
        _asynResetNode.Detach();
    }

    public void ChangeWeight(int type)
    {
        ViActionState state = _stateList.Find(_state => _state.Type == type);
        if (ActiveState == state)
            return;
        if (state != null)
        {
            state.Weight = HighWeight;
            if (ActiveState != null)
            {
                ActiveState.Weight = 0;

            }
            Reset(_breakSameState);
        }
    }

    public void Reset(bool breakSameState)
    {
        _breakSameState = breakSameState;
        _asynResetNode.AsynExec(this._OnResetExec);
    }

    ViFramEndCallback0 _asynResetNode = new ViFramEndCallback0();
    void _OnResetExec()
    {
        ViActionState oldActiveState = _activeState;
        //
        if (_activeState != null)
        {
            _activeState.OnPreReset();
        }
        //
        foreach (ViActionState iterState in _stateList)
        {
            if (iterState.Weight == HighWeight)
            {
                if (!System.Object.ReferenceEquals(iterState, oldActiveState) || _breakSameState)
                {
                    if (oldActiveState != null)
                    {
                        oldActiveState.OnDeactive();
                        oldActiveState.SetActive(false);
                    }
                    //
                    _activeState = iterState;
                    //
                    ViDebuger.AssertError(iterState.Active == false);
                    iterState.SetActive(true);
                    iterState.OnActive();
                }
                else
                {
                    if (oldActiveState != null)
                    {
                        oldActiveState.OnReset();
                    }
                }
                break;
            }
        }
    }

    int HighWeight = 10;
    bool _breakSameState = false;
    ViActionState _activeState;
    List<ViActionState> _stateList = new List<ViActionState>();
}