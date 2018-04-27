using System;
using System.Collections.Generic;

public class EventController
{
    private Dictionary<string, Delegate> m_TheRouter = new Dictionary<string, Delegate>();

    public Dictionary<string, Delegate> TheRouter
    {
        get { return m_TheRouter; }
    }

    private List<string> m_PermanentEvents = new List<string>();

    public void MarkAsPermanent(string eventType)
    {
        m_PermanentEvents.Add(eventType);
    }

    public bool ContainsEvent(string eventType)
    {
        return m_TheRouter.ContainsKey(eventType);
    }

    public void Cleanup()
    {
        List<string> eventToRemove = new List<string>();
        foreach (KeyValuePair<string, Delegate> pair in m_TheRouter)
        {
            bool wasFound = false;
            foreach (string Event in m_PermanentEvents)
            {
                if (pair.Key == Event)
                {
                    wasFound = true;
                    break;
                }
            }
            if (!wasFound)
            {
                eventToRemove.Add(pair.Key);
            }
        }

        foreach (string Event in eventToRemove)
        {
            m_TheRouter.Remove(Event);
        }
    }

    private bool OnListenerAdding(string eventType, Delegate listenerBeingAdded)
    {
        if (!m_TheRouter.ContainsKey(eventType))
        {
            m_TheRouter.Add(eventType, null);
        }
        Delegate d = m_TheRouter[eventType];
        if (d == null)
            return true;
        //zlj edit 添加验证重复添加回调，导致重复调用
        Delegate[] dArray = d.GetInvocationList();

        for (int i = 0; i < dArray.Length; i++)
        {
            if (dArray[i] != null && dArray[i].Equals(listenerBeingAdded))
            {
                //NGUIDebug.Log("重复添加回调:" +eventType + listenerBeingAdded.Target +","+ listenerBeingAdded.Method);
                return false;
            }
        }
        return true;
    }
    private bool OnListenerRemoving(string eventType, Delegate listenerBeingRemoved)
    {
        if (!m_TheRouter.ContainsKey(eventType))
        {
            return false;
        }

        Delegate d = m_TheRouter[eventType];
        if ((d != null) && (d.GetType() != listenerBeingRemoved.GetType()))
        {
//                throw new EventException(string.Format(
//                    "Remove listener {0}\" failed, Current type is {1}, adding type is {2}.",
//                    eventType, d.GetType(), listenerBeingRemoved.GetType()));
			return false;
        }
        else
            return true;
    }
    private void OnListenerRemoved(string eventType)
    {
        if (m_TheRouter.ContainsKey(eventType) && m_TheRouter[eventType] == null)
        {
            m_TheRouter.Remove(eventType);
        }
    }

    public void AddEventListener(string eventType, Action handler)
    {
        if(OnListenerAdding(eventType, handler))
            m_TheRouter[eventType] = (Action)m_TheRouter[eventType] + handler;
    }
	public void AddEventListener<T>(string eventType, Action<T> handler)
	{
        if (OnListenerAdding(eventType, handler))
            m_TheRouter[eventType] = (Action<T>)m_TheRouter[eventType] + handler;
	}
	public void AddEventListener<T1,T2>(string eventType, Action<T1,T2> handler)
	{
        if (OnListenerAdding(eventType, handler))
            m_TheRouter[eventType] = (Action<T1,T2>)m_TheRouter[eventType] + handler;
	}
	public void AddEventListener<T1,T2,T3>(string eventType, Action<T1,T2,T3> handler)
	{
        if (OnListenerAdding(eventType, handler))
            m_TheRouter[eventType] = (Action<T1,T2,T3>)m_TheRouter[eventType] + handler;
	}
    public void AddEventListener<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        if (OnListenerAdding(eventType, handler))
            m_TheRouter[eventType] = (Action<T1, T2, T3, T4>)m_TheRouter[eventType] + handler;
    }

    public void RemoveEventListener(string eventType)
    {
        m_TheRouter.Remove(eventType);
    }

    public void RemoveEventListener(string eventType, Action handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_TheRouter[eventType] = (Action)m_TheRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }
    public void RemoveEventListener<T>(string eventType, Action<T> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_TheRouter[eventType] = (Action<T>)m_TheRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }
    public void RemoveEventListener<T1, T2>(string eventType, Action<T1, T2> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_TheRouter[eventType] = (Action<T1, T2>)m_TheRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }
    public void RemoveEventListener<T1, T2, T3>(string eventType, Action<T1, T2, T3> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_TheRouter[eventType] = (Action<T1, T2, T3>)m_TheRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }
    public void RemoveEventListener<T1, T2, T3,T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        if (OnListenerRemoving(eventType, handler))
        {
            m_TheRouter[eventType] = (Action<T1, T2, T3, T4>)m_TheRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }

    public void TriggerEvent(string eventType)
    {
        Delegate d;
        if (!m_TheRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action callback = callbacks[i] as Action;

            if (callback == null)
            {
                //throw new EventException(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback();
            }
            catch (Exception ex)
            {
                //LoggerHelper.Except(ex);
            }
        }
    }
	public void TriggerEvent<T>(string eventType,T arg1)
	{
		Delegate d;
		if (!m_TheRouter.TryGetValue(eventType, out d))
		{
			return;
		}
		
		var callbacks = d.GetInvocationList();
		for (int i = 0; i < callbacks.Length; i++)
		{
			Action<T> callback = callbacks[i] as Action<T>;
			
			if (callback == null)
			{
				//throw new EventException(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
				break;
			}
			
			try
			{
				callback(arg1);
			}
			catch (Exception ex)
			{
				//LoggerHelper.Except(ex);
			}
		}
	}
	public void TriggerEvent<T1,T2>(string eventType,T1 arg1,T2 arg2)
	{
		Delegate d;
		if (!m_TheRouter.TryGetValue(eventType, out d))
		{
			return;
		}
		
		var callbacks = d.GetInvocationList();
		for (int i = 0; i < callbacks.Length; i++)
		{
			Action<T1,T2> callback = callbacks[i] as Action<T1,T2>;
			
			if (callback == null)
			{
				//throw new EventException(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
				break;
			}
			
			try
			{
				callback(arg1,arg2);
			}
			catch (Exception ex)
			{
				//LoggerHelper.Except(ex);
			}
		}
	}
	public void TriggerEvent<T1,T2,T3>(string eventType,T1 arg1,T2 arg2,T3 arg3)
	{
		Delegate d;
		if (!m_TheRouter.TryGetValue(eventType, out d))
		{
			return;
		}
		
		var callbacks = d.GetInvocationList();
		for (int i = 0; i < callbacks.Length; i++)
		{
			Action<T1,T2,T3> callback = callbacks[i] as Action<T1,T2,T3>;
			
			if (callback == null)
			{
				//throw new EventException(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
				break;
			}
			
			try
			{
				callback(arg1,arg2,arg3);
			}
			catch (Exception ex)
			{
				//LoggerHelper.Except(ex);
			}
		}
	}
    public void TriggerEvent<T1, T2, T3, T4>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        Delegate d;
        if (!m_TheRouter.TryGetValue(eventType, out d))
        {
            return;
        }
        var callbacks = d.GetInvocationList();
        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T1, T2, T3, T4> callback = callbacks[i] as Action<T1, T2, T3, T4>;

            if (callback == null)
            {
                //throw new EventException(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }
            try
            {
                callback(arg1, arg2, arg3, arg4);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

public class EventDispatcher
{
    private static EventController m_EventController = new EventController();

    public static Dictionary<string, Delegate> TheRouter
    {
        get { return m_EventController.TheRouter; }
    }

    static public void MarkAsPermanent(string eventType)
    {
        m_EventController.MarkAsPermanent(eventType);
    }

    static public void Cleanup()
    {
        m_EventController.Cleanup();
    }

    static public void AddEventListener(string eventType, Action handler)
    {
        m_EventController.AddEventListener(eventType, handler);
    }
	static public void AddEventListener<T>(string eventType, Action<T> handler)
	{
		m_EventController.AddEventListener(eventType, handler);
	}
	static public void AddEventListener<T1,T2>(string eventType, Action<T1,T2> handler)
	{
		m_EventController.AddEventListener(eventType, handler);
	}
	static public void AddEventListener<T1,T2,T3>(string eventType, Action<T1,T2,T3> handler)
	{
		m_EventController.AddEventListener(eventType, handler);
	}
    static public void AddEventListener<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        m_EventController.AddEventListener(eventType, handler);
    }

    static public void RemoveEventListener(string eventType, Action handler)
    {
        m_EventController.RemoveEventListener(eventType, handler);
    }
    static public void RemoveEventListener<T>(string eventType, Action<T> handler)
    {
        m_EventController.RemoveEventListener(eventType, handler);
    }
    static public void RemoveEventListener<T1, T2>(string eventType, Action<T1, T2> handler)
    {
        m_EventController.RemoveEventListener(eventType, handler);
    }
    static public void RemoveEventListener<T1, T2, T3>(string eventType, Action<T1, T2, T3> handler)
    {
        m_EventController.RemoveEventListener(eventType, handler);
    }
    static public void RemoveEventListener<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        m_EventController.RemoveEventListener(eventType, handler);
    }

    static public void TriggerEvent(string eventType)
    {
        m_EventController.TriggerEvent(eventType);
    }
	static public void TriggerEvent<T>(string eventType,T arg1)
	{
		m_EventController.TriggerEvent(eventType, arg1);
	}
	static public void TriggerEvent<T1,T2>(string eventType,T1 arg1, T2 arg2)
	{
		m_EventController.TriggerEvent(eventType, arg1,arg2);
	}
	static public void TriggerEvent<T1,T2,T3>(string eventType,T1 arg1, T2 arg2,T3 arg3)
	{
		m_EventController.TriggerEvent(eventType,arg1,arg2,arg3);
	}
    static public void TriggerEvent<T1, T2, T3, T4>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        m_EventController.TriggerEvent(eventType, arg1, arg2, arg3, arg4);
    }
}