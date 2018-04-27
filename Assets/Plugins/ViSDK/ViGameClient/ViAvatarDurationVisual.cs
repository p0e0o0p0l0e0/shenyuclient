using System;
using System.Collections.Generic;

using ViEntityID = System.UInt64;

public static class ViAvatarDurationVisualChannelManager
{
	public static Int32 Channel(Int32 type)
	{
		Int32 channel;
		if (_List.TryGetValue(type, out channel))
		{
			return channel;
		}
		else
		{
			return 0;
		}
	}

	public static void Register(Int32 type, Int32 channel)
	{
		_List[type] = channel;
	}

	static Dictionary<Int32, Int32> _List = new Dictionary<Int32, Int32>();
}

public abstract class ViAvatarDurationVisualInterface<TAvatar>
{
	public delegate void OnEmptyHandler(TAvatar avatar, UInt32 type, object scriptObj);
	public static Dictionary<UInt32, OnEmptyHandler> EmptyHandlerList = new Dictionary<UInt32, OnEmptyHandler>();

	public Int64 ExpireTime { get { return _expireTime; } }
	public Int32 Type { get { return ViAvatarDurationVisualChannelManager.Channel(_info.type); } }
	public Int32 Weight { get { return _weight; } }
	public ViAvatarDurationVisualStruct Info { get { return _info; } }
	public ViEntity Entity { get { return _entity; } }
	public TAvatar Avatar { get { return _avatar; } }

	public abstract void OnActive(TAvatar avatar, bool destroying, ref object obj);
	public abstract void OnDeactive(TAvatar avatar, bool destroying, ref object obj);
	public abstract void OnStart(TAvatar avatar, bool destroying);
	public abstract void OnEnd(TAvatar avatar, bool destroying);
	public virtual void OnAvatarUpdate(TAvatar avatar) { }
	public virtual void OnCameraUpdate(bool active, ref object obj) { }
	//
	public ViAvatarDurationVisualInterface()
	{
		_priorityNode.Data = this;
		_attachNode.Data = this;
	}
	public void Init(ViEntity entity, TAvatar avatar, ViAvatarDurationVisualStruct info, Int32 weight, Int32 duration)
	{
		_entity = entity;
		_avatar = avatar;
		_info = info;
		_weight = weight;
		//
		if (duration > 0)
		{
			_expireTime = ViTimerInstance.Time + duration;
		}
		else
		{
			_expireTime = 0;
		}
	}
	public bool IsAttach()
	{
		return _priorityNode.IsAttach();
	}
	public TEntity GetEntity<TEntity>()
		where TEntity : class, ViEntity
	{
		if (_entity != null)
		{
			return _entity as TEntity;
		}
		else
		{
			return null;
		}
	}

	//
	ViEntity _entity;
	TAvatar _avatar;
	Int32 _weight;
	Int64 _expireTime;
	ViAvatarDurationVisualStruct _info;
	internal ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> _priorityNode = new ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>>();
	internal ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> _attachNode = new ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>>();
}

public class ViAvatarDurationVisualController<TAvatar>
{
	public ViAvatarDurationVisualController(UInt32 type)
	{

	}

	public void OnCameraUpdate()
	{
		if (m_kPriorityList.IsEmpty())
		{
			return;
		}
		//
		ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> iter = m_kPriorityList.GetHead();
		ViAvatarDurationVisualInterface<TAvatar> top = iter.Data;
		ViDebuger.AssertError(top);
		top.OnCameraUpdate(true, ref _scriptObject);
		while (!m_kPriorityList.IsEnd(iter))
		{
			ViAvatarDurationVisualInterface<TAvatar> pkEffect = iter.Data;
			ViDebuger.AssertError(pkEffect);
			ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.Next(ref iter);
			top.OnCameraUpdate(false, ref _scriptObject);
		}
	}

	public void OnAvatarUpdate(TAvatar avatar)
	{
		if (m_kPriorityList.IsEmpty())
		{
			return;
		}
		ViAvatarDurationVisualInterface<TAvatar> topEffect = m_kPriorityList.GetHead().Data;
		topEffect.OnAvatarUpdate(avatar);
	}

	public void Active(TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> kEffect, bool destroying)
	{
		if (m_kPriorityList.IsEmpty())
		{
			m_kPriorityList.PushBack(kEffect._priorityNode);
			kEffect.OnActive(avatar, destroying, ref _scriptObject);
			_OnUpdated(avatar, null);
		}
		else
		{
			ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> iter = m_kPriorityList.GetHead();
			ViAvatarDurationVisualInterface<TAvatar> pkOldTop = iter.Data;
			ViDebuger.AssertError(pkOldTop);
			while (!m_kPriorityList.IsEnd(iter))
			{
				ViAvatarDurationVisualInterface<TAvatar> pkEffect = iter.Data;
				ViDebuger.AssertError(pkEffect);
				if (kEffect.Weight > pkEffect.Weight)
				{
					break;
				}
				ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.Next(ref iter);
			}
			ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.PushBefore(iter, kEffect._priorityNode);
			if (kEffect._priorityNode == m_kPriorityList.GetHead())
			{
				pkOldTop.OnDeactive(avatar, destroying, ref _scriptObject);
				kEffect.OnActive(avatar, destroying, ref _scriptObject);
				_OnUpdated(avatar, pkOldTop);
			}
		}
	}
	public void Deactive(TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> kEffect, bool destroying)
	{
		if (kEffect._priorityNode.IsAttach() == false)
		{
			return;
		}
		if (m_kPriorityList.IsEmpty())
		{
			ViAvatarDurationVisualInterface<TAvatar>.OnEmptyHandler handler;
			if (ViAvatarDurationVisualInterface<TAvatar>.EmptyHandlerList.TryGetValue(_type, out handler))
			{
				handler(avatar, _type, _scriptObject);
			}
			return;
		}
		if (kEffect._priorityNode == m_kPriorityList.GetHead())
		{
			kEffect._priorityNode.Detach();
			kEffect.OnDeactive(avatar, destroying, ref _scriptObject);
			if (!m_kPriorityList.IsEmpty())
			{
				ViAvatarDurationVisualInterface<TAvatar> pNewTop = m_kPriorityList.GetHead().Data;
				ViDebuger.AssertError(pNewTop);
				pNewTop.OnActive(avatar, destroying, ref _scriptObject);
			}
			_OnUpdated(avatar, kEffect);
		}
		else
		{
			kEffect._priorityNode.Detach();
		}
	}

	public void Fresh(TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> visual)
	{
		_OnUpdated(avatar, null);
	}

	public ViAvatarDurationVisualInterface<TAvatar> GetTop()
	{
		if (m_kPriorityList.IsEmpty())
		{
			return null;
		}
		else
		{
			ViAvatarDurationVisualInterface<TAvatar> top = m_kPriorityList.GetHead().Data;
			ViDebuger.AssertError(top);
			return top;
		}
	}
	public void Clear(TAvatar avatar, bool destroying)
	{
		if (!m_kPriorityList.IsEmpty())
		{
			ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> iter = m_kPriorityList.GetHead();
			ViAvatarDurationVisualInterface<TAvatar> top = iter.Data;
			ViDebuger.AssertError(top);
			top.OnDeactive(avatar, destroying, ref _scriptObject);
			while (!m_kPriorityList.IsEnd(iter))
			{
				ViAvatarDurationVisualInterface<TAvatar> pkEffect = iter.Data;
				ViDebuger.AssertError(pkEffect);
				ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.Next(ref iter);
				pkEffect._priorityNode.Detach();
			}
		}
		//
		_scriptObject = null;
	}

	private void _OnUpdated(TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> oldVisual)
	{
		ViAvatarDurationVisualInterface<TAvatar> pkNewTop = GetTop();
		ViAvatarDurationVisualInterface<TAvatar> pkEffect = (oldVisual != null ? oldVisual : pkNewTop);
		if (pkEffect != null)
		{
			//    UInt32 uiType = pkEffect->Type();
			//    FuncUpdate pFunc =  ViVisualDurationEffectCreator::FuncUpdateList<TAvatar>().Get(uiType);
			//    if(pFunc)
			//    {
			//        (*pFunc)(kAvatar, pkOldTop, pkNewTop);
			//    }
		}
	}

	Object _scriptObject;
	UInt32 _type = 0;
	ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>> m_kPriorityList = new ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>();

}

public class ViAvatarDurationVisualControllers<TAvatar>
{
	public void OnCameraUpdate()
	{
		foreach (KeyValuePair<UInt32, ViAvatarDurationVisualController<TAvatar>> pair in m_kEffectControllerList)
		{
			pair.Value.OnCameraUpdate();
		}
	}
	public void OnAvatarUpdate(TAvatar avatar)
	{
		foreach (KeyValuePair<UInt32, ViAvatarDurationVisualController<TAvatar>> pair in m_kEffectControllerList)
		{
			pair.Value.OnAvatarUpdate(avatar);
		}
	}
	public ViAvatarDurationVisualController<TAvatar> GetEffectController(UInt32 type)
	{
		ViAvatarDurationVisualController<TAvatar> controller = null;
		if (m_kEffectControllerList.TryGetValue(type, out controller))
		{
			return controller;
		}
		else
		{
			controller = new ViAvatarDurationVisualController<TAvatar>(type);
			m_kEffectControllerList[type] = controller;
			return controller;
		}
	}
	public void Clear(TAvatar avatar, bool destroying)
	{
		foreach (KeyValuePair<UInt32, ViAvatarDurationVisualController<TAvatar>> pair in m_kEffectControllerList)
		{
			pair.Value.Clear(avatar, destroying);
		}
		m_kEffectControllerList.Clear();
	}
	Dictionary<UInt32, ViAvatarDurationVisualController<TAvatar>> m_kEffectControllerList = new Dictionary<UInt32, ViAvatarDurationVisualController<TAvatar>>();
}

public class ViAvatarDurationVisualOwnList<TAvatar>
{
	public delegate ViAvatarDurationVisualController<TAvatar> Dele_GetEffectController(TAvatar avatar, Int32 type);
	public delegate ViAvatarDurationVisualInterface<TAvatar> Dele_CerateDurationVisual(Int32 type);

	public static Dele_GetEffectController _deleGetEffectController;
	public static Dele_CerateDurationVisual _deleCerateDurationVisual;

	public void Add(ViEntity entity, TAvatar avatar, ViAvatarDurationVisualStruct kInfo, Int32 weight)
	{
		ViDebuger.AssertError(_deleCerateDurationVisual);
		ViAvatarDurationVisualInterface<TAvatar> pkEffect = _deleCerateDurationVisual(kInfo.type);
		if (pkEffect != null)
		{
			Add(entity, avatar, pkEffect, kInfo, weight);
		}
	}

	public void Add(ViEntity entity, TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> pkEffect, ViAvatarDurationVisualStruct kInfo, Int32 weight)
	{
		m_kEffectList.PushBack(pkEffect._attachNode);
		pkEffect.Init(entity, avatar, kInfo, weight, kInfo.duration);
		pkEffect.OnStart(avatar, false);
		_Active(avatar, pkEffect, false);
		//
		if (kInfo.duration > 0)
		{
			UpdateExpireTime();
		}
	}

	public void Clear(TAvatar avatar, bool destroying)
	{
		_eraseExpireTimeNode.Detach();
		//
		ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> iter = m_kEffectList.GetHead();
		while (!m_kEffectList.IsEnd(iter))
		{
			ViAvatarDurationVisualInterface<TAvatar> pkEffect = iter.Data;
			ViDebuger.AssertError(pkEffect);
			ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.Next(ref iter);
			_Deactive(avatar, pkEffect, destroying);
			pkEffect.OnEnd(avatar, destroying);
			pkEffect._attachNode.Detach();
		}
	}

	void _Active(TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> kEffect, bool destroying)
	{
		ViDebuger.AssertError(_deleGetEffectController);
		ViAvatarDurationVisualController<TAvatar> pkController = _deleGetEffectController(avatar, kEffect.Type);
		if (pkController != null)
		{
			pkController.Active(avatar, kEffect, destroying);
		}
	}
	void _Deactive(TAvatar avatar, ViAvatarDurationVisualInterface<TAvatar> kEffect, bool destroying)
	{
		ViDebuger.AssertError(_deleGetEffectController);
		ViAvatarDurationVisualController<TAvatar> pkController = _deleGetEffectController(avatar, kEffect.Type);
		if (pkController != null)
		{
			pkController.Deactive(avatar, kEffect, destroying);
		}
	}

	static List<ViAvatarDurationVisualInterface<TAvatar>> CACHE_EraseExpireList = new List<ViAvatarDurationVisualInterface<TAvatar>>();
	void EraseExpire()
	{
		for (ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> iter = m_kEffectList.GetHead(); !m_kEffectList.IsEnd(iter);  )
		{
			ViAvatarDurationVisualInterface<TAvatar> iterEffect = iter.Data;
			ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.Next(ref iter);
			//
			if (iterEffect.ExpireTime <= ViTimerInstance.Time)
			{
				CACHE_EraseExpireList.Add(iterEffect);
			}
		}
		//
		for (Int32 iter = 0 ; iter < CACHE_EraseExpireList.Count; ++iter)
		{
			ViAvatarDurationVisualInterface<TAvatar> iterEffect = CACHE_EraseExpireList[iter];
			_Deactive(iterEffect.Avatar, iterEffect, false);
			iterEffect.OnEnd(iterEffect.Avatar, false);
			iterEffect._attachNode.Detach();
		}
		CACHE_EraseExpireList.Clear();
		//
		UpdateExpireTime(); 
	}

	void UpdateExpireTime()
	{
		Int64 nearTime = Int64.MaxValue;
		for (ViDoubleLinkNode2<ViAvatarDurationVisualInterface<TAvatar>> iter = m_kEffectList.GetHead(); !m_kEffectList.IsEnd(iter);  )
		{
			ViAvatarDurationVisualInterface<TAvatar> iterEffect = iter.Data;
			ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>.Next(ref iter);
			//
			if (iterEffect.ExpireTime != 0)
			{
				nearTime = ViMathDefine.Min(nearTime, iterEffect.ExpireTime);
			}
		}
		//
		if(nearTime != Int64.MaxValue)
		{
			ViTimerInstance.SetTime(_eraseExpireTimeNode, nearTime - ViTimerInstance.Time, this.OnTimeEraseExpire);
		}
	}

	ViTimeNode1 _eraseExpireTimeNode = new ViTimeNode1();
	void OnTimeEraseExpire(ViTimeNodeInterface node)
	{
		EraseExpire();
	}

	ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>> m_kEffectList = new ViDoubleLink2<ViAvatarDurationVisualInterface<TAvatar>>();
}