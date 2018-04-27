using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
//
public class PlayerFriendList : PlayerComponent, ViRPCEntity, ViEntity
{
	public static PlayerFriendList Instance { get { return _instance; } }
	static PlayerFriendList _instance = null;
	//
	public static ViEventList EventCreate { get { return _CreateEvent; } }
	public static ViEventList EventExit { get { return _ExitEvent; } }
	static ViEventList _CreateEvent = new ViEventList();
	static ViEventList _ExitEvent = new ViEventList();
	//
	public new PlayerFriendListReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public new string Name { get { return "PlayerFriendList"; } }

    ViAsynCallback<ViReceiveDataNode, object> _friendViewPropertyListCallBack = new ViAsynCallback<ViReceiveDataNode, object>();

    ViAsynCallback<ViReceiveDataNode, object> _friendInvitorListCallBack = new ViAsynCallback<ViReceiveDataNode, object>();

    ViAsynCallback<ViReceiveDataNode, object> _blackFriendPropertyListCallBack = new ViAsynCallback<ViReceiveDataNode, object>();
    
    ViAsynCallback<ViReceiveDataNode, object> _recommandListCallBack = new ViAsynCallback<ViReceiveDataNode, object>();

    public void SetProperty(PlayerFriendListReceiveProperty property)
	{
		_property = property;
		base.SetProperty(property);
	}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<PlayerFriendListReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
		PlayerFriendListPropertyAssisstant.SetProperty(_property);
		base.SetProperty(_property);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		PlayerFriendListPropertyAssisstant.SetProperty(null);
		ViReceiveDataCache<PlayerFriendListReceiveProperty>.Free(_property);
		_property = null;
	}
	public new void OnPropertyUpdateStart(UInt8 channel){}
	public new void OnPropertyUpdateEnd(UInt8 channel){}
	public new void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public new void Start()
	{
		base.Start();
		//
		PlayerFriendListPropertyWatcherCreator.Start(_property, this);

        Property.FriendViewPropertyList.CallbackList.Attach(_friendViewPropertyListCallBack, _OnFriendViewPropertyListUpdate);
        Property.FriendInvitorList.CallbackList.Attach(_friendInvitorListCallBack, _OnFriendInvitorListUpdate);
        Property.BlackFriendPropertyList.CallbackList.Attach(_blackFriendPropertyListCallBack, _OnBlackFriendPropertyListUpdate);
        Property.RecommandList.CallbackList.Attach(_recommandListCallBack, _OnRecommandListUpdate);

        _instance = this;
		//
		if (_instance != null)
		{
			EventCreate.Invoke(0);
		}
	}    

    private void _OnFriendViewPropertyListUpdate(UInt32 dele, ViReceiveDataNode before, object after)
    {
        EventDispatcher.TriggerEvent(Events.FriendEvent.GameFriendRefresh);
    }

    private void _OnFriendInvitorListUpdate(UInt32 dele, ViReceiveDataNode before, object after)
    {
        EventDispatcher.TriggerEvent(Events.FriendEvent.FriendApplyRefresh);
    }

    private void _OnBlackFriendPropertyListUpdate(UInt32 dele, ViReceiveDataNode before, object after)
    {
        EventDispatcher.TriggerEvent(Events.FriendEvent.BlackListRefresh);
    }

    private void _OnRecommandListUpdate(UInt32 dele, ViReceiveDataNode before, object after)
    {
        EventDispatcher.TriggerEvent(Events.FriendEvent.RecommandListRefresh);
    }

    public new void ClearCallback()
	{
		//
		base.ClearCallback();
	}
	public new void End()
	{
		_instance = null;
		EventExit.Invoke(0);
		//
		base.End();
	}

	PlayerFriendListReceiveProperty _property;
	//

	public bool InviteeContains(UInt64 player)
	{
		for (int iter = 0; iter < Property.FriendInviteeList.Count; ++iter)
		{
			FriendInviteeProperty iterProperty = Property.FriendInviteeList[iter].Property;
			if (iterProperty.Identification.ID == player)
			{
				return true;
			}
		}
		return false;
	}

	public bool InvitorContains(UInt64 player)
	{
		int index = 0;
		return InvitorContains(player, out index);
	}
	public bool InvitorContains(UInt64 player, out int index)
	{
		index = 0;
		for (int iter = 0; iter < Property.FriendInvitorList.Count; ++iter)
		{
			FriendInvitorProperty iterProperty = Property.FriendInvitorList[iter].Property;
			if (iterProperty.Identification.ID == player)
			{
				index = iter;
				return true;
			}
		}
		return false;
	}

    public bool GetIsFriendById(ulong friendId)
    {
        foreach (var item in Property.FriendViewPropertyList.Array.Keys)
        {
            if (item == friendId)
            {
                return true;
            }
        }
        return false;
    }
	
}
