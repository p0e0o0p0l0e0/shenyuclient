using System;
using System.Collections.Generic;
using UnityEngine;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityTypeID = System.Byte;
using ViEntityID = System.UInt64;

#pragma warning disable 0649 //从未对字段赋值,字段将一直保持其默认值 null;

public class SpaceObject : ViGeographicObject, ViGeographicInterface, ViRPCEntity, ViEntity, TickInterface,PickalbeInterface
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public Client Client { get { return _client; } set { _client = value; } }
	Client _client;

	public SpaceObjectReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return false; } }
	public bool Active { get { return _active; } }
	public override ViVector3 Position { get { return _posProvider.Value; } set { _posProvider.SetValue(value); } }
	public ViProvider<ViVector3> PosProvider { get { return _posProvider; } }
	public SpaceObjectStruct Info { get { return _info; } }
	public ViPriorityValue<bool> PickActive { get { return _pickable; } }
	public override float BodyRadius { get { return Info.Body.maxRange*0.01f; } }
	public override float Yaw { get { return 0; } set { } }
	public string Name { get { return "SpaceObject"; } }
	public Collider Collider { get { return _collider; } }
	public Animation Anim { get { return _animation; } }

	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<SpaceObjectReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<SpaceObjectReceiveProperty>.Free(_property);
		_property = null;
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

	}
	public void AftStart()
	{
		TickManager.PushBack(_updateNode, this, false);
	}

	public void Tick(float deltaTime) { }
	public void ClearCallback()
	{
		TickManager.Detach(_updateNode);
	}
	public void PreEnd()
	{
        mBodyLoader.End();
	}
	public void End()
    {

    }
	public void AftEnd()
	{
		RPC.End();
        _pickableNode.End();
		UnityAssisstant.Destroy(ref _rootVisual);
	}

	public void OnPropertyUpdateStart(UInt8 channel)
	{

	}

	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}

	public void OnPropertyUpdateEnd(UInt8 channel)
	{

	}

	ViDoubleLinkNode2<TickInterface> _updateNode = new ViDoubleLinkNode2<TickInterface>();
	public void Update(float deltaTime)
	{

	}

	public void StartInViewData(ViIStream IS)
	{
		SpaceObjectInViewData viewData = new SpaceObjectInViewData();
		viewData.Load(IS);
		//
		_info = ViSealedDB<SpaceObjectStruct>.Data(Property.Template);
		//
		ViVector3 newPos = viewData.Pos;
		GroundHeight.GetGroundHeight(BodyRadius, ref newPos);
		_posProvider.SetValue(newPos);
		//
		_rootVisual.transform.localPosition = newPos.Convert();
		_rootVisual.name = "SpaceObject_" + Info.Name;

        mBodyLoader.Start(_info.Resource.Data, OnLoad);
	}

	public virtual void OnLeaveSpace()
	{

	}

	public void OnHitEffectVisual(UInt32 visualID)
	{
		
	}

	public void OnHitEffectVisual(UInt32 visualID, ViVector3 position)
	{
		
	}

	public void OnLoot(CellHero hero, Int32 XP, Int32 yinPiao, List<ItemCountProperty> itemList)
	{

	}

	public void OnDie()
	{
        
    }

	public void SetVisual(GameObject res)
	{
        GameObject obj = UnityAssisstant.InstantiateAsChild(res, _rootVisual == null ? null : _rootVisual.transform);
		obj.SetActive(_active);
		UnityAssisstant.SetLayerRecursively(obj, (int)UnityLayer.ENTITY);
		//
		_animation = obj.GetComponentInChildren<Animation>();
		if (_animation != null)
		{
			AnimationData.Format(_animation, 1.0f);
		}
		//
		_collider = obj.GetComponentInChildren<Collider>();

        _pickableNode.Start(obj, this);
	}
    
	void OnLoad(UnityEngine.Object pAsset)
	{
		SetVisual(pAsset as GameObject);
	}

    public void OnFocusOn()
    {
       
    }

    public void OnFocusOff()
    {
        
    }

    public void OnPressed()
    {
        
    }

    public void OnReleased()
    {
        
    }

    public void OnMove()
    {
        
    }

    ViEntityID _ID;
	UInt32 _PackID;
	bool _active = false;
	SpaceObjectReceiveProperty _property;
	SpaceObjectStruct _info;
	GameObject _rootVisual = new GameObject();
	Collider _collider;
	Animation _animation;
	//
	ViSimpleProvider<ViVector3> _posProvider = new ViSimpleProvider<ViVector3>();
	//
	ViPriorityValue<bool> _pickable = new ViPriorityValue<bool>(true);
    PickableNode _pickableNode = new PickableNode();
    ResourceRequest mBodyLoader = new ResourceRequest();
}