using System;
using System.Collections.Generic;

using ViEntityID = System.UInt64;


public class ViEntityManager
{
    public Dictionary<ViEntityID, ViEntity> Entitys { get { return _entityList; } }
    public Dictionary<UInt64, ViEntity> PackEntitys { get { return _entityPackList; } }

    public enum Event
    {
        CREATE,
        BODY_UPDATE,
        DESTROY,
    }

    public class EventNode
    {
        public delegate void Func(Event eventID, ViEntity entity);

        public ViEntityID ID { get { return _ID; } } 
        public ViEntityID PackID { get { return _packID; } }
        public Func Callback { get { return _callback; } }

        public void Exec(Event eventID, ViEntity entity)
        {
            if (Callback != null)
            {
                Callback(eventID, entity);
            }
        }

        public void Start(ViEntityID ID, Func callback, ViRefList2<EventNode> list)
        {
            _ID = ID;
            _packID = 0;
            _callback = callback;
            _attachNode.Data = this;
            list.Push(_attachNode);
        }

        public void Start(UInt32 packID, Func callback, ViRefList2<EventNode> list)
        {
            _ID = 0;
            _packID = packID;
            _callback = callback;
            _attachNode.Data = this;
            list.Push(_attachNode);
        }

        public void End()
        {
            _callback = null;
            _attachNode.Data = null;
            _attachNode.Detach();
        }

        ViEntityID _ID;
        UInt32 _packID;
        Func _callback;
        ViRefNode2<EventNode> _attachNode = new ViRefNode2<EventNode>();
    }

    public void AttachEventNode(EventNode node, ViEntityID ID, EventNode.Func callback)
    {
        node.Start(ID, callback, _eventList);
    }
    public void AttachEventNode(EventNode node, UInt32 packID, EventNode.Func callback)
    {
        node.Start(packID, callback, _eventList);
    }
    //
    public void AddEntity(ViEntityID ID, UInt32 PackID, ViEntity entity)
    {
        ViDebuger.AssertError(entity);
        ViDebuger.AssertError(!_entityList.ContainsKey(ID));
        ViDebuger.AssertError(!_entityPackList.ContainsKey(PackID));
        _entityList[ID] = entity;
        _entityPackList[PackID] = entity;
        entity.PreStart();
        entity.Start();
        entity.AftStart();
        SendEvent(Event.CREATE, entity);
    }
    public void DelEntity(ViEntity entity)
    {
        SendEvent(Event.DESTROY, entity);
        entity.ClearCallback();
        entity.PreEnd();
        entity.End();
        entity.AftEnd();
        entity.ClearCallback();
        _entityList.Remove(entity.ID);
        _entityPackList.Remove(entity.PackID);
    }

    public TEntity GetEntity<TEntity>(ViEntityID ID) where TEntity : class, ViEntity
    {
        ViEntity entity;
        if (_entityList.TryGetValue(ID, out entity) && entity != null)
        {
            return entity as TEntity;
        }
        else
        {
            return null;
        }
    }
    public ViEntity GetEntity(ViEntityID ID)
    {
        ViEntity entity;
        if (_entityList.TryGetValue(ID, out entity) && entity != null)
        {
            return entity;
        }
        else
        {
            return null;
        }
    }

    public TEntity GetPackEntity<TEntity>(UInt64 PackID) where TEntity : class, ViEntity
    {
        ViEntity entity;
        if (_entityPackList.TryGetValue(PackID, out entity) && entity != null)
        {
            if (entity is TEntity)
                return (TEntity)entity;
            return null;
        }
        else
        {
            return default(TEntity);
        }
    }
    public ViEntity GetPackEntity(UInt32 PackID)
    {
        ViEntity entity;
        if (_entityPackList.TryGetValue(PackID, out entity))
        {
            return entity;
        }
        else
        {
            return null;
        }
    }

    public void GetEntityList<TEntity>(List<TEntity> list) where TEntity : class, ViEntity
    {
        foreach (KeyValuePair<ViEntityID, ViEntity> iter in _entityList)
        {
            TEntity iterEntity = iter.Value as TEntity;
            if (iterEntity != null)
            {
                list.Add(iterEntity);
            }
        }
    }

    public void Start()
    {

    }
    public void End()
    {
        _entityList.Clear();
        _entityPackList.Clear();
        _eventList.ClearAndClearContent();
    }

    public void SendEvent(Event eventID, ViEntity entity)
    {
        _eventList.BeginIterator();
        while (!_eventList.IsEnd())
        {
            EventNode iterNode = _eventList.CurrentNode.Data;
            _eventList.Next();
            //
            if (iterNode.ID == entity.ID)
            {
                iterNode.Exec(eventID, entity);
            }
            if (iterNode.PackID == entity.PackID)
            {
                iterNode.Exec(eventID, entity);
            }
        }
    }

    Dictionary<ViEntityID, ViEntity> _entityList = new Dictionary<ViEntityID, ViEntity>();
    Dictionary<UInt64, ViEntity> _entityPackList = new Dictionary<UInt64, ViEntity>();
    ViRefList2<EventNode> _eventList = new ViRefList2<EventNode>();
}