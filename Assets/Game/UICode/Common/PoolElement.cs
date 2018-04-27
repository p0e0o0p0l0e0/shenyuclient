using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolElement<TKey>
{
    public TKey KeyType { set; get; }
    protected bool _isClose;
    public virtual bool IsClose()
    {
        return _isClose;
    }
    public virtual void Open()
    {
        _isClose = false;
    }
    public virtual void Close()
    {
        _isClose = true;
    }
    public virtual void Dispose()
    {
        Close();
    }
}

public class PoolElement
{
    protected bool _isClose;
    public virtual bool IsClose()
    {
        return _isClose;
    }
    public virtual void Open()
    {
        _isClose = false;
    }
    public virtual void Close()
    {
        _isClose = true;
    }
    public virtual void Dispose()
    { }
}