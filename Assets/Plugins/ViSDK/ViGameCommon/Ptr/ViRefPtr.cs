using System;



public class ViRefObj
{
	public void _ClearReference()
	{
		_List.ClearAndClearContent();
	}
	public void _AddReference(ViDoubleLinkNode2<ViRefObj> node)
	{
		_List.PushBack(node);
	}
	ViDoubleLink2<ViRefObj> _List = new ViDoubleLink2<ViRefObj>();
}

//+-------------------------------------------------------------------------------------------------------------------------------------------------------------

public class ViRefPtr<T>
	where T : ViRefObj
{
	public T Obj
	{
		get { return _node.Data as T; }
		set { _SetObj(value); }
	}
	//
	public ViRefPtr()
	{

	}
	public ViRefPtr(T obj)
	{
		_SetObj(obj);
	}
	public ViRefPtr(ViRefPtr<T> ptr)
	{
		_SetObj(ptr.Obj);
	}
	public void Clear()
	{
		_node.Detach();
		_node.Data = null;
	}
	private void _SetObj(T obj)
	{
		if (_node.Data == obj)
		{
			return;
		}
		_node.Detach();
		_node.Data = null;
		//
		if (obj != null)
		{
			_node.Data = obj;
			obj._AddReference(_node);
		}
	}
	ViDoubleLinkNode2<ViRefObj> _node = new ViDoubleLinkNode2<ViRefObj>();
}

//+-------------------------------------------------------------------------------------------------------------------------------------------------------------

public class ViDynamicRefPtr
{
	public ViRefObj Obj
	{
		get { return _node.Data; }
		set { _SetObj(value); }
	}
	public ViDynamicRefPtr()
	{
		
	}
	public ViDynamicRefPtr(ViRefObj obj)
	{
		_SetObj(obj);
	}
	public ViDynamicRefPtr(ViDynamicRefPtr ptr)
	{
		_SetObj(ptr.Obj);
	}
	public void Clear()
	{
		_node.Detach();
		_node.Data = null;
	}
	private void _SetObj(ViRefObj obj)
	{
		if (_node.Data == obj)
		{
			return;
		}
		_node.Detach();
		_node.Data = null;
		//
		if (obj != null)
		{
			_node.Data = obj;
			obj._AddReference(_node);
		}
	}
	//
	ViDoubleLinkNode2<ViRefObj> _node = new ViDoubleLinkNode2<ViRefObj>();
}

//+-------------------------------------------------------------------------------------------------------------------------------------------------------------

public class Demo_RefPtr
{
#pragma warning disable 0219
	class Entity : ViRefObj
	{

	}
	public static void Test()
	{
		Entity obj = new Entity();
		ViRefPtr<Entity> ptrObj = new ViRefPtr<Entity>();
		ptrObj.Obj = obj;
		ViRefPtr<Entity> ptrObj2 = ptrObj;
		obj._ClearReference();
		obj = null;
	}
#pragma warning restore 0219
}