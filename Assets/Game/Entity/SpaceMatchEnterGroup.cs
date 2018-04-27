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
public class SpaceMatchEnterGroup : ViRPCEntity, ViEntity
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "SpaceMatchEnterGroup"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public SpaceMatchEnterGroupReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }

	public SpaceMatchEnterMemberProperty MemberSelf
	{
		get
		{
			foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpaceMatchEnterMemberProperty>> pair in SpaceMatchEnterGroupInstance.Instance.Property.MemberList.Array)
			{
				ReceiveDataSpaceMatchEnterMemberProperty member = pair.Value.Property;
				if (pair.Key == Player.Instance.ID)
				{
					return member;
				}
			}
			return new SpaceMatchEnterMemberProperty();
		}
	}

	public bool SelfReady
	{
		get
		{
			foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpaceMatchEnterMemberProperty>> pair in SpaceMatchEnterGroupInstance.Instance.Property.MemberList.Array)
			{
				ReceiveDataSpaceMatchEnterMemberProperty member = pair.Value.Property;
				if (pair.Key == Player.Instance.ID)
				{
					return member.Ready == 1;
				}
			}
			return false;
		}
	}

	public bool SelfHeroReady
	{
		get
		{
			foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpaceMatchEnterMemberProperty>> pair in SpaceMatchEnterGroupInstance.Instance.Property.MemberList.Array)
			{
				ReceiveDataSpaceMatchEnterMemberProperty member = pair.Value.Property;
				if (pair.Key == Player.Instance.ID)
				{
					return member.HeroReady == 1;
				}
			}
			return false;
		}
	}

	public UInt8 SelfFaction
	{
		get
		{
			foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpaceMatchEnterMemberProperty>> pair in SpaceMatchEnterGroupInstance.Instance.Property.MemberList.Array)
			{
				ReceiveDataSpaceMatchEnterMemberProperty member = pair.Value.Property;
				if (pair.Key == Player.Instance.ID)
				{
					return member.FactionIdx;
				}
			}
			return 0;
		}
	}

	public UInt32 SelfHero
	{
		get
		{
			foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpaceMatchEnterMemberProperty>> pair in SpaceMatchEnterGroupInstance.Instance.Property.MemberList.Array)
			{
				ReceiveDataSpaceMatchEnterMemberProperty member = pair.Value.Property;
				if (pair.Key == Player.Instance.ID)
				{
					return member.Hero;
				}
			}
			return 0;
		}
	}

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
	public void Start()
	{
		SpaceMatchEnterGroupInstance.Start(this);
	}
	public void AftStart()
	{
		
	}
	public void ClearCallback() { }
	public void PreEnd()
	{
		
	}
	public void End()
	{
		SpaceMatchEnterGroupInstance.End();
	}
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<SpaceMatchEnterGroupReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<SpaceMatchEnterGroupReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	public bool HeroSelected(UInt32 hero, UInt8 faction)
	{
		foreach (KeyValuePair<UInt64, ViReceiveDataDictionaryNode<UInt64, ReceiveDataSpaceMatchEnterMemberProperty>> pair in SpaceMatchEnterGroupInstance.Instance.Property.MemberList.Array)
		{
			ReceiveDataSpaceMatchEnterMemberProperty member = pair.Value.Property;
			if (member.FactionIdx == faction && member.Hero == hero)
			{
				return true;
			}
		}
		return false;
	}

	public void OnReadyAll()
	{
		//ViewControllerManager.GMCustomRoomScanView.Close();
		//ViewControllerManager.PartyMatchHeroChooseView.Open();
	}

	public void OnDisReady()
	{
		//ViewControllerManager.PartyMatchSuccessView.Close();
	}


	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	SpaceMatchEnterGroupReceiveProperty _property;
}

public class SpaceMatchEnterGroupInstance
{
	public static SpaceMatchEnterGroup Instance { get { return _instance; } }
	static SpaceMatchEnterGroup _instance;
	//
	public static ViEventList EventCreate { get { return _CreateEvent; } }
	public static ViEventList EventExit { get { return _ExitEvent; } }

	public static void Start(SpaceMatchEnterGroup record)
	{
		_instance = record;
		if (_instance != null)
		{
			//ViewControllerManager.PartyMatchSuccessView.Open();
			EventCreate.Invoke(0);
		}
	}

	public static void End()
	{
		_instance = null;
		EventExit.Invoke(0);
		//ViewControllerManager.PartyMatchSuccessView.Close();
	}

	static ViEventList _CreateEvent = new ViEventList();
	static ViEventList _ExitEvent = new ViEventList();

}