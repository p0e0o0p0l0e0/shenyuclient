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
public class CellPlayer : ViRPCEntity, ViEntity
{
	public static CellPlayer Instance { get { return _instance; } }
	static CellPlayer _instance;

	public static Faction LocalFaction
	{
		get
		{
			if (Instance != null)
			{
				return (Faction)Instance.Property.Faction.Value;
			}
			else
			{
				return Faction.PLAYER_0;
			}
		}
	}

	public static UInt8 LocalFactionIdx
	{
		get
		{
			if (Instance != null)
			{
				return (UInt8)(Instance.Property.Faction.Value - (UInt8)Faction.PLAYER_0);
			}
			else
			{
				return 0;
			}
		}
	}

	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();

	public string Name { get { return "CellPlayer"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return _asLocal; } }
	public bool Active { get { return _active; } }
	public CellPlayerReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }

	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
		_asLocal = asLocal;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart() { }
	public void Start()
	{
		_instance = this;
		//
		Property.ScriptProgressList.UpdateArrayCallbackList.Attach(_scriptProgressCallback, this._OnScriptProgressUpdated);
	}
	public void AftStart()
	{
		
	}
	public void ClearCallback()
	{
		_scriptProgressCallback.End();
	}
	public void PreEnd()
	{
		_instance = null;
		//
		FreeHeroRes();
	}
	public void End() { }
	public void AftEnd() { }
	public void Tick(float fDeltaTime) { }
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<CellPlayerReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<CellPlayerReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel) { }
	public void OnPropertyUpdateEnd(UInt8 channel) { }
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	ViAsynCallback<UInt32, ReceiveDataProgressProperty> _scriptProgressCallback = new ViAsynCallback<UInt32, ReceiveDataProgressProperty>();
	void _OnScriptProgressUpdated(UInt32 eventID, UInt32 template, ReceiveDataProgressProperty node)
	{
		//ViewControllerManager.UpdateProgress();
	}

	public void OnPing(Int64 time)
	{
		Int64 span = (Int64)(UnityEngine.Time.realtimeSinceStartup * 1000) - time;
		ViDebuger.CritOK("Cell.PING=" + span + " @" + time);
	}

	public void MessageBox(ViString title, ViString content)
	{
		//ViewControllerManager.PrintMSGView.SetMessage(content);
	}

	public void DebugMessage(ViString title, ViString content)
	{
		EntityMessageController.OnDebugMessage(title, content);
	}

	public void ContainReserveWord(ViString orgValue, ViString fmtValue)
	{
		//ViewControllerManager.PrintMSGView.SetMessage("包含禁用词汇(" + orgValue + "->" + fmtValue + ")");
	}

	public void HoldHeroRes()
	{
		//for (int iter = 0; iter < Property.HeroList.Count; ++iter)
		//{
		//    EntityResourceHolder iterHodler = new EntityResourceHolder();
		//    iterHodler.HoldHero(Property.HeroList[iter].Property, true);
		//    _heroResHolderList.Add(iterHodler);
		//}
	}

	public void FreeHeroRes()
	{
		//for (int iter = 0; iter < _heroResHolderList.Count; ++iter)
		//{
		//	EntityResourceHolder iterHodler = _heroResHolderList[iter];
		//	iterHodler.End();
		//}
		//_heroResHolderList.Clear();
	}

	public void ReportPrivateShareSpace(UInt8 MVP, UInt8 Killer, Int64 damage, Int32 rewardYinPiao)
	{
	
	}

    public void OnNavigateTo(List<ViVector3> positionList)
    {
    }

	public float Yaw;
	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	bool _asLocal;

	CellPlayerReceiveProperty _property;
}
