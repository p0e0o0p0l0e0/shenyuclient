using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceObjectClientExecer : ViRPCExecer
{
	public static SpaceObjectClientExecer Create() { return new SpaceObjectClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(SpaceObject entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new SpaceObject();
		SetEntity(_entity);
		_entity.Enable(ID, PackID, asLocal);
		_entity.StartProperty(channelMask, IS);
		entityManager.AddEntity(ID, PackID, _entity);
		_entity.SetActive(true);
		_entity.StartInViewData(IS);
	}
	public override void OnPropertyUpdateStart(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateStart(channel);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdate(channel, IS);
	}
	public override void OnPropertyUpdateEnd(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateEnd(channel);
	}
	public override void End(ViEntityManager entityManager)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnLeaveSpace();
		_entity.SetActive(false);
		_entity.EndProperty();
		entityManager.DelEntity(_entity);
		_entity.ClearProperty();
		_entity = null;
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((SpaceObjectClientMethod)funcIdx)
		{
			case SpaceObjectClientMethod.METHOD_0_OnHitEffectVisual: 
				_0_OnHitEffectVisual(IS);
				break;
			case SpaceObjectClientMethod.METHOD_1_OnHitEffectVisual: 
				_1_OnHitEffectVisual(IS);
				break;
			case SpaceObjectClientMethod.METHOD_2_OnLoot: 
				_2_OnLoot(IS);
				break;
			case SpaceObjectClientMethod.METHOD_3_OnDie: 
				_3_OnDie(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnHitEffectVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 VisualID;
		ViGameSerializer<UInt32>.Read(IS, out VisualID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitEffectVisual(" + ", " + VisualID + ")");
		}
		_entity.OnHitEffectVisual(VisualID);
	}

	void _1_OnHitEffectVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 VisualID;
		ViGameSerializer<UInt32>.Read(IS, out VisualID);
		ViVector3 Position;
		ViGameSerializer<ViVector3>.Read(IS, out Position);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitEffectVisual(" + ", " + VisualID + ", " + Position + ")");
		}
		_entity.OnHitEffectVisual(VisualID, Position);
	}

	void _2_OnLoot(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		CellHero Owner;
		ViGameSerializer<CellHero>.Read(IS, out Owner);
		Int32 XP;
		ViGameSerializer<Int32>.Read(IS, out XP);
		Int32 YinPiao;
		ViGameSerializer<Int32>.Read(IS, out YinPiao);
		List<ItemCountProperty> LootList;
		ViGameSerializer<ItemCountProperty>.Read(IS, out LootList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLoot(" + ", " + Owner + ", " + XP + ", " + YinPiao + ", " + LootList + ")");
		}
		_entity.OnLoot(Owner, XP, YinPiao, LootList);
	}

	void _3_OnDie(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnDie(" + ")");
		}
		_entity.OnDie();
	}

	protected SpaceObject _entity;
}
