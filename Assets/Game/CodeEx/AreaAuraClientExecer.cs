using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AreaAuraClientExecer : ViRPCExecer
{
	public static AreaAuraClientExecer Create() { return new AreaAuraClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(AreaAura entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new AreaAura();
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
		switch((AreaAuraClientMethod)funcIdx)
		{
			case AreaAuraClientMethod.METHOD_0_OnHitEffectVisual: 
				_0_OnHitEffectVisual(IS);
				break;
			case AreaAuraClientMethod.METHOD_1_OnHitEffectVisual: 
				_1_OnHitEffectVisual(IS);
				break;
			case AreaAuraClientMethod.METHOD_2_OnEmptyExploreVisual: 
				_2_OnEmptyExploreVisual(IS);
				break;
			case AreaAuraClientMethod.METHOD_3_OnUpdateYaw: 
				_3_OnUpdateYaw(IS);
				break;
			case AreaAuraClientMethod.METHOD_4_OnMoveTo: 
				_4_OnMoveTo(IS);
				break;
			case AreaAuraClientMethod.METHOD_5_OnMoveTo: 
				_5_OnMoveTo(IS);
				break;
			case AreaAuraClientMethod.METHOD_6_OnMoveTo: 
				_6_OnMoveTo(IS);
				break;
			case AreaAuraClientMethod.METHOD_7_OnBreakMove: 
				_7_OnBreakMove(IS);
				break;
			case AreaAuraClientMethod.METHOD_8_OnUpdateSpeed: 
				_8_OnUpdateSpeed(IS);
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
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitEffectVisual(" + ", " + VisualID + ", " + Position + ", " + Yaw + ")");
		}
		_entity.OnHitEffectVisual(VisualID, Position, Yaw);
	}

	void _2_OnEmptyExploreVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnEmptyExploreVisual(" + ")");
		}
		_entity.OnEmptyExploreVisual();
	}

	void _3_OnUpdateYaw(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateYaw(" + ", " + Yaw + ")");
		}
		_entity.OnUpdateYaw(Yaw);
	}

	void _4_OnMoveTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 Dest;
		ViGameSerializer<ViVector3>.Read(IS, out Dest);
		float Speed;
		ViGameSerializer<float>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMoveTo(" + ", " + Dest + ", " + Speed + ")");
		}
		_entity.OnMoveTo(Dest, Speed);
	}

	void _5_OnMoveTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ViVector3> PosList;
		ViGameSerializer<ViVector3>.Read(IS, out PosList);
		float Speed;
		ViGameSerializer<float>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMoveTo(" + ", " + PosList + ", " + Speed + ")");
		}
		_entity.OnMoveTo(PosList, Speed);
	}

	void _6_OnMoveTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 ResetPos;
		ViGameSerializer<ViVector3>.Read(IS, out ResetPos);
		List<ViVector3> PosList;
		ViGameSerializer<ViVector3>.Read(IS, out PosList);
		float Speed;
		ViGameSerializer<float>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMoveTo(" + ", " + ResetPos + ", " + PosList + ", " + Speed + ")");
		}
		_entity.OnMoveTo(ResetPos, PosList, Speed);
	}

	void _7_OnBreakMove(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBreakMove(" + ", " + Pos + ")");
		}
		_entity.OnBreakMove(Pos);
	}

	void _8_OnUpdateSpeed(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float Speed;
		ViGameSerializer<float>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateSpeed(" + ", " + Speed + ")");
		}
		_entity.OnUpdateSpeed(Speed);
	}

	protected AreaAura _entity;
}
