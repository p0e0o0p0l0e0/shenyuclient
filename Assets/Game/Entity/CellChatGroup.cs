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
//
public class CellChatGroup : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return Property.Name; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public CellChatGroupReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public ChatChannelType Channel { get { return (ChatChannelType)Property.Channel.Value; } }
	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart() { }
	public void Start() { }
	public void AftStart()
	{
		ChatGroupManager<CellChatGroup>.Instance.Register(Channel, this);
	}
	public void ClearCallback() { }
	public void PreEnd()
	{
		ChatGroupManager<CellChatGroup>.Instance.Erase(Channel);
	}
	public void End() { }
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<CellChatGroupReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<CellChatGroupReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}


	public void OnChatScriptBegin(PlayerIdentificationProperty name)
	{
		_chatContentList.Begin(name);
    }

	public void OnChatScriptShowItem(UInt32 item, UInt64 ID)
	{
		_chatContentList.ShowItem((ChatChannelType)_property.Channel.Value, item, ID);
	}

	public void OnChatScriptEnd(ViString script)
	{
		string chatText = _chatContentList.End(script);
		if (!string.IsNullOrEmpty(chatText))
		{
			chatText = WordFilterInstance.Instance.Filter(chatText);
		}
        
	}

    public void OnChatMessage(PlayerIdentificationProperty name, ViString script)
    {
        // UI处理Chat内容
		EventDispatcher.TriggerEvent<ChatDataInfo>(Events.ChatSystemEvent.ChatReceives, 
													new ChatDataInfo { 
														Property = name,
														ChannelId = _property.Channel,
														ChannelName = _property.Name,
														Content = script  });
    }

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	CellChatGroupReceiveProperty _property;
	//
	ChatScriptContentList _chatContentList = new ChatScriptContentList();
}
