using System;
using System.Collections.Generic;
using UnityEngine;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityTypeID = System.Byte;
using ViEntityID = System.UInt64;

public class AreaAura : ViGeographicObject, ViGeographicInterface, ViRPCEntity, ViEntity, TickInterface
{
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public Client Client { get { return _client; } set { _client = value; } }
	Client _client;

	public AreaAuraReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool Active { get { return _active; } }
	public bool IsLocal { get { return Property.CasterID == CellHero.LocalHeroID; } }

	public override ViVector3 Position { get { return _posProvider.Value; } set { _posProvider.SetValue(value); } }
	public ViProvider<ViVector3> PosProvider { get { return _posProvider; } }
	public ViAuraStruct LogicInfo { get { return _logicInfo; } }
	public ViVisualAuraStruct VisualInfo { get { return _visualInfo; } }
	public ViVector3 VisualOffset { get { return _visualOffset; } }
	public override float BodyRadius { get { return ViMathDefine.Max(0.5f, LogicInfo.MiscValue("RadiateRange") * 0.01f); } }
	public float Range
	{
		get
		{
			//Int32 spellID = LogicInfo.MiscValue("SpellID");
			//Int32 effectIdx = LogicInfo.MiscValue("EffectIdx");
			//ViSpellStruct spellInfo = ViSealedDB<ViSpellStruct>.Data(spellID);
			//ViTargetSelectStruct selector = spellInfo.effect[effectIdx].Selector;
			//if (selector.casterMask != 0)
			//{
			//    return selector.casterEffectRange.maxRange * 0.01f;
			//}
			//if (selector.targetMask != 0)
			//{
			//    return selector.targetEffectRange.maxRange * 0.01f;
			//}
			return 0;
		}
	}
	public bool BroadcastCameraShake(ViEnum32<BoolValue> broadcast)
	{
		if (broadcast == (UInt32)BoolValue.TRUE)
		{
			return true;
		}
		if (Property.CasterID == CellHero.LocalHeroID)
		{
			return true;
		}
		if (ViVector3.DistanceH(Position, CellHero.LocalHero.Position) < Range)
		{
			return true;
		}
		return false;
	}

	public override float Yaw { get { return _yaw; } set { } }
	public string Name { get { return "AreaAura"; } }

	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<AreaAuraReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<AreaAuraReceiveProperty>.Free(_property);
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
		Property.Faction.CallbackList.Attach(_propertyCallbackOnFaction, this._OnFactionlUpdated);
	}

	public void Tick(float deltaTime) { }
	public void ClearCallback()
	{
		TickManager.Detach(_updateNode);
		//
		_propertyCallbackOnFaction.End();
	}
	public void PreEnd()
	{
		UnityAssisstant.Destroy(ref _rootVisual);
	}
	public void End() { }
	public void AftEnd()
	{
		RPC.End();
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
		bool updated = _route.OnTick(deltaTime, _speed);
		if (updated)
		{
			ViVector3 newPos = _route.Position;
			_yaw = ViGeographicObject.GetDirection(_route.Direction.x, _route.Direction.y);
			switch ((ViGroundType)VisualInfo.ground.Value)
			{
				case ViGroundType.GROUND:
					{
						newPos.z = Position.z;
						ViVector3 normal = ViVector3.UNIT_Z;
						//if (!GameWorld.Instance.Scene.IsBlock(newPos))
						{
							GroundHeight.GetGroundHeight(0.5f, ref newPos, ref normal);
						}
						_posProvider.SetValue(newPos);
						//
						if (_rootVisual != null)
						{
							GroundWinger.Update(Position + VisualOffset, _yaw, normal, _rootVisual.transform);
						}
					}
					break;
				case ViGroundType.FLY:
					{
						_posProvider.SetValue(newPos);
						//
						if (_rootVisual != null)
						{
							GroundWinger.Update(Position + VisualOffset, _route.Direction, 0.0f, _rootVisual.transform);
						}
					}
					break;
				default:
					{
						_posProvider.SetValue(newPos);
						//
						if (_rootVisual != null)
						{
							GroundWinger.Update(Position + VisualOffset, _yaw, ViVector3.UNIT_Z, _rootVisual.transform);
						}
					}
					break;
			}
		}
	}

	//public static bool IsAttachPos(AvatarAttachNode node)
	//{
	//    switch (node)
	//    {
	//        case AvatarAttachNode.LEFT_HAND:
	//        case AvatarAttachNode.RIGHT_HAND:
	//        case AvatarAttachNode.LEFT_WEAPON:
	//        case AvatarAttachNode.RIGHT_WEAPON:
	//        case AvatarAttachNode.WEAPON_TRAIL:
	//            return true;
	//        default:
	//            return false;
	//    }
	//}

	//public static bool IsAttachPos(GameUnit caster, AvatarAttachNode node, float speed, ViVector3 pos)
	//{
	//    if (!IsAttachPos(node))
	//    {
	//        return false;
	//    }
	//    if (speed <= 1.0f)
	//    {
	//        return false;
	//    }
	//    float distance = ViGeographicObject.GetHorizontalDistance(pos, caster.Position);
	//    float duration = distance / speed;
	//    return duration < 0.1f;
	//}

	public string GetFactionColor()
	{
		if (Property.CasterID == CellHero.LocalHeroID)
		{
			return "Blue";
		}
		else
		{
			return EntityAssisstant.GetFactionColor(CellHero.LocalFaction, (Faction)Property.Faction.Value);
		}
	}
	
	ViAsynCallback<ViReceiveDataNode, object> _propertyCallbackOnFaction = new ViAsynCallback<ViReceiveDataNode, object>();
	void _OnFactionlUpdated(UInt32 eventID, ViReceiveDataNode node, object oldValue)
	{
		UnityAssisstant.UpdateSwitchComponent(_rootVisual, GetFactionColor());
	}

	public void StartInViewData(ViIStream IS)
	{
		SpaceObjectInViewData viewData = new SpaceObjectInViewData();
		viewData.Load(IS);
		//
		_logicInfo = ViSealedDB<ViAuraStruct>.Data(Property.Template);
		_visualInfo = ViSealedDB<ViVisualAuraStruct>.Data(Property.Template);
		_visualOffset = new ViVector3(0, 0, VisualInfo.height * 0.01f);
		//
		ViVector3 newPos = viewData.Pos;
		newPos.z = GetCasterHeight(0);
		GroundHeight.GetGroundHeight(BodyRadius, ref newPos);
		_posProvider.SetValue(newPos);
		//
		GroundWinger.Update(Position + VisualOffset, viewData.Yaw, ViVector3.UNIT_Z, _rootVisual.transform);
		//
		if (_visualInfo.attackTipsDuration > 0)
		{
			GameObjectCloneExpressEx express = new GameObjectCloneExpressEx();
			express.SwitchLayer = GetFactionColor();
			ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(_rootVisual.transform.position.Convert());
			express.Start(GlobalGameObject.Instance.AOIEffect.GameObject, posProvider, 0, _visualInfo.attackTipsDelayTime, _visualInfo.attackTipsDuration, new ViVector3(0.0f, 0.0f, 0.01f), _visualInfo.casterEffectRange);
			_expressList.Add(express);
		}
		//
		foreach (ViAttachExpressStruct expressInfo in _visualInfo.express.Array)
		{
			if (!expressInfo.IsEmpty())
			{
				AttachedSpaceExpress iterExpress = new AttachedSpaceExpress();
				iterExpress.CameraAnim = IsLocal;
				iterExpress.Start(expressInfo.res.Data, expressInfo.delayTime * 0.01f, _rootVisual.transform, ViVector3.ZERO);
				iterExpress.AttachMask = (UInt32)expressInfo.attachMask;
				iterExpress.SwitchLayer = GetFactionColor();
				_expressList.Add(iterExpress);
			}
		}
		//
		for (int iter = 0; iter < _visualInfo.sound.Length; ++iter)
		{
			ViSoundStruct expressInfo = _visualInfo.sound[iter];
			if (!expressInfo.IsEmpty())
			{
				AttachedSpaceExpress iterExpress = new AttachedSpaceExpress();
				iterExpress.CameraAnim = IsLocal;
				iterExpress.Start(expressInfo.Resource.Data, _rootVisual.transform);
				iterExpress.SoundDuration = false;
				_expressList.Add(iterExpress);
			}
		}
		//
		_speed = Property.Speed*0.01f;
		if (viewData.Route.Count > 0)
		{
			OnMoveTo(viewData.Route, _speed);
		}
	}

	public virtual void OnLeaveSpace()
	{
		_expressList.End();
		//
		if (!VisualInfo.vanishVisual.IsEmpty())
		{
			FreeSpaceExpressEx express = new FreeSpaceExpressEx();
			express.CameraAnim = IsLocal;
			express.Scale = VisualInfo.vanishVisual.Scale;
			express.AttachMask = (UInt32)(VisualInfo.vanishVisual.attachMask);
			ViOffSetVector3Provider posProvider = new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, VisualInfo.height * 0.01f));
			express.Start(VisualInfo.vanishVisual.res.Data, posProvider, Yaw, VisualInfo.vanishVisual.delayTime * 0.01f, VisualInfo.vanishVisual.duration * 0.01f);
		}
	}

	public void OnHitEffectVisual(UInt32 visualID)
	{
		OnHitEffectVisual(visualID, Position, Yaw);
	}
	public void OnHitEffectVisual(UInt32 visualID, ViVector3 position, float yaw)
	{
		GroundHeight.GetGroundHeight(BodyRadius, ref position);
		_OnHitEffectVisual(visualID, position, yaw);
	}
	void _OnHitEffectVisual(UInt32 visualID, ViVector3 position, float yaw)
	{
		ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(position + VisualOffset);
		ViVisualHitEffectStruct effectVisualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(visualID);
		foreach (ViAttachExpressStruct expressInfo in effectVisualInfo.express.Array)
		{
			if (!expressInfo.IsEmpty())
			{
				FreeSpaceExpressEx express = new FreeSpaceExpressEx();
				express.CameraAnim = IsLocal;
				express.Scale = expressInfo.Scale;
				express.AttachMask = (UInt32)(expressInfo.attachMask);
				express.Start(expressInfo.res.Data, posProvider, yaw, expressInfo.delayTime * 0.01f, expressInfo.duration * 0.01f);
			}
		}
		ViCameraShakeStruct cameraShake = effectVisualInfo.cameraShake.Shake.PData;
		if (cameraShake != null && BroadcastCameraShake(effectVisualInfo.cameraShake.Broadcast))
		{
			ShakeExpressEx shakeExpress = new ShakeExpressEx();
			shakeExpress.SetProvider(PosProvider);
			shakeExpress.Start(effectVisualInfo.cameraShake.DelayTime * 0.01f, cameraShake);
		}
	}

	public void OnEmptyExploreVisual()
	{
		_OnHitEffectVisual(LogicInfo.EmptyExploreVisual, Position + VisualOffset, Yaw);
	}

	public float GetCasterHeight(float defaultValue)
	{
		float value = defaultValue;
		GameUnit caster = Client.Current.EntityManager.GetPackEntity<GameUnit>(Property.CasterPackID);
		if (caster != null)
		{
			value = caster.Position.z;
		}
		return value;
	}

	public void OnUpdateYaw(float yaw)
	{
		_yaw = yaw;
	}

	public void OnMoveTo(ViVector3 dest, float speed)
	{
		float defaultHeight = GetCasterHeight(0);
		ViVector3 newPos = Position;
		newPos.z = GameSpace.ActiveInstance.Navigator.GetDestHeight(dest, newPos, BodyRadius, defaultHeight);
		_posProvider.SetValue(newPos);
		//
		dest.z = GameSpace.ActiveInstance.Navigator.GetDestHeight(Position, dest, BodyRadius, defaultHeight);
		//
		_route.Reset();
		_route.Append(dest);
		_route.Start(Position);
		_speed = speed;
	}

	public void OnMoveTo(List<ViVector3> route, float speed)
	{
		float defaultHeight = GetCasterHeight(0);
		//
		GameSpace.ActiveInstance.Navigator.GetDestHeight(Position, route, BodyRadius, 0.0f, defaultHeight);
		//
		_route.Reset();
		_route.Append(route);
		_route.Start(Position);
		_speed = speed;
	}

	public void OnMoveTo(ViVector3 resetPos, List<ViVector3> route, float speed)
	{
		float defaultHeight = GetCasterHeight(0);
		//
		ViVector3 newPos = resetPos;
		newPos.z = defaultHeight;
		GroundHeight.GetGroundHeight(BodyRadius, ref newPos);
		_posProvider.SetValue(newPos);
		//
		GameSpace.ActiveInstance.Navigator.GetDestHeight(Position, route, BodyRadius, 0.0f, defaultHeight);
		//
		_route.Reset();
		_route.Append(route);
		_route.Start(Position);
		_speed = speed;
	}

	public void OnBreakMove(ViVector3 pos)
	{
		_route.Reset();
		_speed = 0;
	}

	public void OnUpdateSpeed(float speed)
	{
		_speed = speed;
	}


	ViEntityID _ID;
	UInt32 _PackID;
	bool _active = false;
	AreaAuraReceiveProperty _property;
	ViAuraStruct _logicInfo;
	ViVisualAuraStruct _visualInfo;
	GameObject _rootVisual = new GameObject("AreaAura");
	//
	ViSimpleProvider<ViVector3> _posProvider = new ViSimpleProvider<ViVector3>();

	ViExpressOwnList<ViExpressInterface> _expressList = new ViExpressOwnList<ViExpressInterface>();

	ViVector3 _visualOffset;

	ViRoute _route = new ViRoute();
	float _speed = 4.0f;
	float _yaw;
}


