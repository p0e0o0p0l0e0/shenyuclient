using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameUnitClientExecer : ViGameUnitClientExecer
{
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(GameUnit entity)
	{
		_entity = entity;
		base.SetEntity(entity);
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((GameUnitClientMethod)funcIdx)
		{
			case GameUnitClientMethod.METHOD_0_OnMoveTo: 
				_0_OnMoveTo(IS);
				break;
			case GameUnitClientMethod.METHOD_1_OnMoveTo: 
				_1_OnMoveTo(IS);
				break;
			case GameUnitClientMethod.METHOD_2_OnBreakMove: 
				_2_OnBreakMove(IS);
				break;
			case GameUnitClientMethod.METHOD_3_OnBreakMove: 
				_3_OnBreakMove(IS);
				break;
			case GameUnitClientMethod.METHOD_4_OnUpdateYaw: 
				_4_OnUpdateYaw(IS);
				break;
			case GameUnitClientMethod.METHOD_5_OnUpdatePosYaw: 
				_5_OnUpdatePosYaw(IS);
				break;
			case GameUnitClientMethod.METHOD_6_OnChargeTo: 
				_6_OnChargeTo(IS);
				break;
			case GameUnitClientMethod.METHOD_7_OnChargeTo: 
				_7_OnChargeTo(IS);
				break;
			case GameUnitClientMethod.METHOD_8_OnChargeTo: 
				_8_OnChargeTo(IS);
				break;
			case GameUnitClientMethod.METHOD_9_OnChargeTo: 
				_9_OnChargeTo(IS);
				break;
			case GameUnitClientMethod.METHOD_10_OnAimChargeTo: 
				_10_OnAimChargeTo(IS);
				break;
			case GameUnitClientMethod.METHOD_11_OnAimChargeTo: 
				_11_OnAimChargeTo(IS);
				break;
			case GameUnitClientMethod.METHOD_12_OnTransportTo: 
				_12_OnTransportTo(IS);
				break;
			case GameUnitClientMethod.METHOD_13_OnTransportTo: 
				_13_OnTransportTo(IS);
				break;
			case GameUnitClientMethod.METHOD_14_OnFlyTo: 
				_14_OnFlyTo(IS);
				break;
			case GameUnitClientMethod.METHOD_15_FixTimeFlyTo: 
				_15_FixTimeFlyTo(IS);
				break;
			case GameUnitClientMethod.METHOD_16_SetBodyVisiable: 
				_16_SetBodyVisiable(IS);
				break;
			case GameUnitClientMethod.METHOD_17_OnWorldSay: 
				_17_OnWorldSay(IS);
				break;
			case GameUnitClientMethod.METHOD_18_OnWorldSay: 
				_18_OnWorldSay(IS);
				break;
			case GameUnitClientMethod.METHOD_19_CloseWorldSay: 
				_19_CloseWorldSay(IS);
				break;
			case GameUnitClientMethod.METHOD_20_CloseWorldSay: 
				_20_CloseWorldSay(IS);
				break;
			case GameUnitClientMethod.METHOD_21_OnDamageHited: 
				_21_OnDamageHited(IS);
				break;
			case GameUnitClientMethod.METHOD_22_OnDie: 
				_22_OnDie(IS);
				break;
			case GameUnitClientMethod.METHOD_23_OnRevive: 
				_23_OnRevive(IS);
				break;
			case GameUnitClientMethod.METHOD_24_OnSoul: 
				_24_OnSoul(IS);
				break;
			case GameUnitClientMethod.METHOD_25_OnShotStart: 
				_25_OnShotStart(IS);
				break;
			case GameUnitClientMethod.METHOD_26_OnShotEnd: 
				_26_OnShotEnd(IS);
				break;
			case GameUnitClientMethod.METHOD_27_OnShotRecover: 
				_27_OnShotRecover(IS);
				break;
			case GameUnitClientMethod.METHOD_28_OnBulletStart: 
				_28_OnBulletStart(IS);
				break;
			case GameUnitClientMethod.METHOD_29_OnBulletStart: 
				_29_OnBulletStart(IS);
				break;
			case GameUnitClientMethod.METHOD_30_OnBulletEnd: 
				_30_OnBulletEnd(IS);
				break;
			case GameUnitClientMethod.METHOD_31_OnBulletClear: 
				_31_OnBulletClear(IS);
				break;
			case GameUnitClientMethod.METHOD_32_OnMeleeAttackOnce: 
				_32_OnMeleeAttackOnce(IS);
				break;
			case GameUnitClientMethod.METHOD_33_OnSpellPrepare: 
				_33_OnSpellPrepare(IS);
				break;
			case GameUnitClientMethod.METHOD_34_OnSpellPrepare: 
				_34_OnSpellPrepare(IS);
				break;
			case GameUnitClientMethod.METHOD_35_OnSpellCast: 
				_35_OnSpellCast(IS);
				break;
			case GameUnitClientMethod.METHOD_36_OnSpellCast: 
				_36_OnSpellCast(IS);
				break;
			case GameUnitClientMethod.METHOD_37_OnSpellCast: 
				_37_OnSpellCast(IS);
				break;
			case GameUnitClientMethod.METHOD_38_OnSpellCast: 
				_38_OnSpellCast(IS);
				break;
			case GameUnitClientMethod.METHOD_39_OnSpellCastStart: 
				_39_OnSpellCastStart(IS);
				break;
			case GameUnitClientMethod.METHOD_40_OnSpellCastStart: 
				_40_OnSpellCastStart(IS);
				break;
			case GameUnitClientMethod.METHOD_41_OnSpellCastEnd: 
				_41_OnSpellCastEnd(IS);
				break;
			case GameUnitClientMethod.METHOD_42_OnCancelSpell: 
				_42_OnCancelSpell(IS);
				break;
			case GameUnitClientMethod.METHOD_43_OnBreakSpell: 
				_43_OnBreakSpell(IS);
				break;
			case GameUnitClientMethod.METHOD_44_OnSpellEnd: 
				_44_OnSpellEnd(IS);
				break;
			case GameUnitClientMethod.METHOD_45_OnCastTo: 
				_45_OnCastTo(IS);
				break;
			case GameUnitClientMethod.METHOD_46_OnCastTo: 
				_46_OnCastTo(IS);
				break;
			case GameUnitClientMethod.METHOD_47_OnCastTo: 
				_47_OnCastTo(IS);
				break;
			case GameUnitClientMethod.METHOD_48_OnCastFrom: 
				_48_OnCastFrom(IS);
				break;
			case GameUnitClientMethod.METHOD_49_OnHitVisual: 
				_49_OnHitVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_50_OnHitVisual: 
				_50_OnHitVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_51_OnHitVisual: 
				_51_OnHitVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_52_OnHitVisualShadow: 
				_52_OnHitVisualShadow(IS);
				break;
			case GameUnitClientMethod.METHOD_53_OnLinkVisualStart: 
				_53_OnLinkVisualStart(IS);
				break;
			case GameUnitClientMethod.METHOD_54_OnLinkVisualStart: 
				_54_OnLinkVisualStart(IS);
				break;
			case GameUnitClientMethod.METHOD_55_OnLinkVisualEnd: 
				_55_OnLinkVisualEnd(IS);
				break;
			case GameUnitClientMethod.METHOD_56_OnLinkVisualEndFrom: 
				_56_OnLinkVisualEndFrom(IS);
				break;
			case GameUnitClientMethod.METHOD_57_OnLinkVisualEndTo: 
				_57_OnLinkVisualEndTo(IS);
				break;
			case GameUnitClientMethod.METHOD_58_OnLinkVisualOnce: 
				_58_OnLinkVisualOnce(IS);
				break;
			case GameUnitClientMethod.METHOD_59_OnLinkVisualOnce: 
				_59_OnLinkVisualOnce(IS);
				break;
			case GameUnitClientMethod.METHOD_60_PlayActionAnim: 
				_60_PlayActionAnim(IS);
				break;
			case GameUnitClientMethod.METHOD_61_PlayStateAnim: 
				_61_PlayStateAnim(IS);
				break;
			case GameUnitClientMethod.METHOD_62_StopStateAnim: 
				_62_StopStateAnim(IS);
				break;
			case GameUnitClientMethod.METHOD_63_OnCastVisual: 
				_63_OnCastVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_64_OnCastVisual: 
				_64_OnCastVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_65_OnHitEffectVisual: 
				_65_OnHitEffectVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_66_OnHitEffectVisual: 
				_66_OnHitEffectVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_67_OnAreaHitEffectVisual: 
				_67_OnAreaHitEffectVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_68_AddAvatarDurationVisual: 
				_68_AddAvatarDurationVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_69_ClearAvatarDurationVisual: 
				_69_ClearAvatarDurationVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_70_ShowDriveVisual: 
				_70_ShowDriveVisual(IS);
				break;
			case GameUnitClientMethod.METHOD_71_PrintHoldResource: 
				_71_PrintHoldResource(IS);
				break;
			case GameUnitClientMethod.METHOD_72_ShootAura: 
				_72_ShootAura(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnMoveTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMoveTo(" + ", " + Pos + ")");
		}
		_entity.OnMoveTo(Pos);
	}

	void _1_OnMoveTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ViVector3> PosList;
		ViGameSerializer<ViVector3>.Read(IS, out PosList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMoveTo(" + ", " + PosList + ")");
		}
		_entity.OnMoveTo(PosList);
	}

	void _2_OnBreakMove(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBreakMove(" + ", " + Pos + ", " + Yaw + ")");
		}
		_entity.OnBreakMove(Pos, Yaw);
	}

	void _3_OnBreakMove(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBreakMove(" + ", " + Yaw + ")");
		}
		_entity.OnBreakMove(Yaw);
	}

	void _4_OnUpdateYaw(ViIStream IS)
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

	void _5_OnUpdatePosYaw(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdatePosYaw(" + ", " + Pos + ", " + Yaw + ")");
		}
		_entity.OnUpdatePosYaw(Pos, Yaw);
	}

	void _6_OnChargeTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		UInt8 LockOnGround;
		ViGameSerializer<UInt8>.Read(IS, out LockOnGround);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChargeTo(" + ", " + DestPos + ", " + Yaw + ", " + Duration + ", " + LockOnGround + ")");
		}
		_entity.OnChargeTo(DestPos, Yaw, Duration, LockOnGround);
	}

	void _7_OnChargeTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		UInt8 LockOnGround;
		ViGameSerializer<UInt8>.Read(IS, out LockOnGround);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChargeTo(" + ", " + Visual + ", " + DestPos + ", " + Yaw + ", " + Duration + ", " + LockOnGround + ")");
		}
		_entity.OnChargeTo(Visual, DestPos, Yaw, Duration, LockOnGround);
	}

	void _8_OnChargeTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		List<ViVector3> PosList;
		ViGameSerializer<ViVector3>.Read(IS, out PosList);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		UInt8 LockOnGround;
		ViGameSerializer<UInt8>.Read(IS, out LockOnGround);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChargeTo(" + ", " + PosList + ", " + Yaw + ", " + Duration + ", " + LockOnGround + ")");
		}
		_entity.OnChargeTo(PosList, Yaw, Duration, LockOnGround);
	}

	void _9_OnChargeTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		List<ViVector3> PosList;
		ViGameSerializer<ViVector3>.Read(IS, out PosList);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		UInt8 LockOnGround;
		ViGameSerializer<UInt8>.Read(IS, out LockOnGround);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnChargeTo(" + ", " + Visual + ", " + PosList + ", " + Yaw + ", " + Duration + ", " + LockOnGround + ")");
		}
		_entity.OnChargeTo(Visual, PosList, Yaw, Duration, LockOnGround);
	}

	void _10_OnAimChargeTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnAimChargeTo(" + ", " + DestPos + ", " + Duration + ")");
		}
		_entity.OnAimChargeTo(DestPos, Duration);
	}

	void _11_OnAimChargeTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnAimChargeTo(" + ", " + Visual + ", " + DestPos + ", " + Duration + ")");
		}
		_entity.OnAimChargeTo(Visual, DestPos, Duration);
	}

	void _12_OnTransportTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnTransportTo(" + ", " + DestPos + ", " + Yaw + ")");
		}
		_entity.OnTransportTo(DestPos, Yaw);
	}

	void _13_OnTransportTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnTransportTo(" + ", " + Visual + ", " + DestPos + ", " + Yaw + ")");
		}
		_entity.OnTransportTo(Visual, DestPos, Yaw);
	}

	void _14_OnFlyTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViVector3 StartPos;
		ViGameSerializer<ViVector3>.Read(IS, out StartPos);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnFlyTo(" + ", " + StartPos + ", " + DestPos + ", " + Yaw + ", " + Duration + ")");
		}
		_entity.OnFlyTo(StartPos, DestPos, Yaw, Duration);
	}

	void _15_FixTimeFlyTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 SpellID;
		ViGameSerializer<UInt32>.Read(IS, out SpellID);
		ViVector3 StartPos;
		ViGameSerializer<ViVector3>.Read(IS, out StartPos);
		ViVector3 DestPos;
		ViGameSerializer<ViVector3>.Read(IS, out DestPos);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].FixTimeFlyTo(" + ", " + SpellID + ", " + StartPos + ", " + DestPos + ", " + Yaw + ")");
		}
		_entity.FixTimeFlyTo(SpellID, StartPos, DestPos, Yaw);
	}

	void _16_SetBodyVisiable(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Visiable;
		ViGameSerializer<UInt8>.Read(IS, out Visiable);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetBodyVisiable(" + ", " + Visiable + ")");
		}
		_entity.SetBodyVisiable(Visiable);
	}

	void _17_OnWorldSay(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Dialog;
		ViGameSerializer<ViString>.Read(IS, out Dialog);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnWorldSay(" + ", " + Dialog + ")");
		}
		_entity.OnWorldSay(Dialog);
	}

	void _18_OnWorldSay(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Dialog;
		ViGameSerializer<ViString>.Read(IS, out Dialog);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnWorldSay(" + ", " + Dialog + ", " + Duration + ")");
		}
		_entity.OnWorldSay(Dialog, Duration);
	}

	void _19_CloseWorldSay(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].CloseWorldSay(" + ")");
		}
		_entity.CloseWorldSay();
	}

	void _20_CloseWorldSay(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float DelayTime;
		ViGameSerializer<float>.Read(IS, out DelayTime);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].CloseWorldSay(" + ", " + DelayTime + ")");
		}
		_entity.CloseWorldSay(DelayTime);
	}

	void _21_OnDamageHited(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnDamageHited(" + ", " + Attacker + ")");
		}
		_entity.OnDamageHited(Attacker);
	}

	void _22_OnDie(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnDie(" + ")");
		}
		_entity.OnDie();
	}

	void _23_OnRevive(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnRevive(" + ")");
		}
		_entity.OnRevive();
	}

	void _24_OnSoul(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSoul(" + ")");
		}
		_entity.OnSoul();
	}

	void _25_OnShotStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnShotStart(" + ")");
		}
		_entity.OnShotStart();
	}

	void _26_OnShotEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnShotEnd(" + ")");
		}
		_entity.OnShotEnd();
	}

	void _27_OnShotRecover(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnShotRecover(" + ")");
		}
		_entity.OnShotRecover();
	}

	void _28_OnBulletStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int8 Yaw;
		ViGameSerializer<Int8>.Read(IS, out Yaw);
		UInt8 ID;
		ViGameSerializer<UInt8>.Read(IS, out ID);
		UInt8 Duration;
		ViGameSerializer<UInt8>.Read(IS, out Duration);
		Int8 Speed;
		ViGameSerializer<Int8>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBulletStart(" + ", " + Yaw + ", " + ID + ", " + Duration + ", " + Speed + ")");
		}
		_entity.OnBulletStart(Yaw, ID, Duration, Speed);
	}

	void _29_OnBulletStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int8 Yaw;
		ViGameSerializer<Int8>.Read(IS, out Yaw);
		List<UInt8> IDList;
		ViGameSerializer<UInt8>.Read(IS, out IDList);
		List<Int8> YawList;
		ViGameSerializer<Int8>.Read(IS, out YawList);
		List<UInt8> DurationList;
		ViGameSerializer<UInt8>.Read(IS, out DurationList);
		Int8 Speed;
		ViGameSerializer<Int8>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBulletStart(" + ", " + Yaw + ", " + IDList + ", " + YawList + ", " + DurationList + ", " + Speed + ")");
		}
		_entity.OnBulletStart(Yaw, IDList, YawList, DurationList, Speed);
	}

	void _30_OnBulletEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 ID;
		ViGameSerializer<UInt8>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBulletEnd(" + ", " + ID + ")");
		}
		_entity.OnBulletEnd(ID);
	}

	void _31_OnBulletClear(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBulletClear(" + ")");
		}
		_entity.OnBulletClear();
	}

	void _32_OnMeleeAttackOnce(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit TargetEntity;
		ViGameSerializer<GameUnit>.Read(IS, out TargetEntity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnMeleeAttackOnce(" + ", " + TargetEntity + ")");
		}
		_entity.OnMeleeAttackOnce(TargetEntity);
	}

	void _33_OnSpellPrepare(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		GameUnit TargetEntity;
		ViGameSerializer<GameUnit>.Read(IS, out TargetEntity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellPrepare(" + ", " + ID + ", " + TargetEntity + ")");
		}
		_entity.OnSpellPrepare(ID, TargetEntity);
	}

	void _34_OnSpellPrepare(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 TargetPos;
		ViGameSerializer<ViVector3>.Read(IS, out TargetPos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellPrepare(" + ", " + ID + ", " + TargetPos + ")");
		}
		_entity.OnSpellPrepare(ID, TargetPos);
	}

	void _35_OnSpellCast(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		GameUnit TargetEntity;
		ViGameSerializer<GameUnit>.Read(IS, out TargetEntity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCast(" + ", " + ID + ", " + TargetEntity + ")");
		}
		_entity.OnSpellCast(ID, TargetEntity);
	}

	void _36_OnSpellCast(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 TargetPos;
		ViGameSerializer<ViVector3>.Read(IS, out TargetPos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCast(" + ", " + ID + ", " + TargetPos + ")");
		}
		_entity.OnSpellCast(ID, TargetPos);
	}

	void _37_OnSpellCast(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		GameUnit TargetEntity;
		ViGameSerializer<GameUnit>.Read(IS, out TargetEntity);
		float SendTime;
		ViGameSerializer<float>.Read(IS, out SendTime);
		float TravelDuration;
		ViGameSerializer<float>.Read(IS, out TravelDuration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCast(" + ", " + ID + ", " + TargetEntity + ", " + SendTime + ", " + TravelDuration + ")");
		}
		_entity.OnSpellCast(ID, TargetEntity, SendTime, TravelDuration);
	}

	void _38_OnSpellCast(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 TargetPos;
		ViGameSerializer<ViVector3>.Read(IS, out TargetPos);
		float SendTime;
		ViGameSerializer<float>.Read(IS, out SendTime);
		float TravelDuration;
		ViGameSerializer<float>.Read(IS, out TravelDuration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCast(" + ", " + ID + ", " + TargetPos + ", " + SendTime + ", " + TravelDuration + ")");
		}
		_entity.OnSpellCast(ID, TargetPos, SendTime, TravelDuration);
	}

	void _39_OnSpellCastStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		GameUnit TargetEntity;
		ViGameSerializer<GameUnit>.Read(IS, out TargetEntity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCastStart(" + ", " + ID + ", " + TargetEntity + ")");
		}
		_entity.OnSpellCastStart(ID, TargetEntity);
	}

	void _40_OnSpellCastStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 TargetPos;
		ViGameSerializer<ViVector3>.Read(IS, out TargetPos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCastStart(" + ", " + ID + ", " + TargetPos + ")");
		}
		_entity.OnSpellCastStart(ID, TargetPos);
	}

	void _41_OnSpellCastEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellCastEnd(" + ")");
		}
		_entity.OnSpellCastEnd();
	}

	void _42_OnCancelSpell(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCancelSpell(" + ")");
		}
		_entity.OnCancelSpell();
	}

	void _43_OnBreakSpell(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnBreakSpell(" + ")");
		}
		_entity.OnBreakSpell();
	}

	void _44_OnSpellEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSpellEnd(" + ")");
		}
		_entity.OnSpellEnd();
	}

	void _45_OnCastTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCastTo(" + ", " + ID + ", " + Pos + ", " + Duration + ")");
		}
		_entity.OnCastTo(ID, Pos, Duration);
	}

	void _46_OnCastTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		GameUnit Target;
		ViGameSerializer<GameUnit>.Read(IS, out Target);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCastTo(" + ", " + ID + ", " + Target + ", " + Duration + ")");
		}
		_entity.OnCastTo(ID, Target, Duration);
	}

	void _47_OnCastTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 FromPos;
		ViGameSerializer<ViVector3>.Read(IS, out FromPos);
		ViVector3 ToPos;
		ViGameSerializer<ViVector3>.Read(IS, out ToPos);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCastTo(" + ", " + ID + ", " + FromPos + ", " + ToPos + ", " + Duration + ")");
		}
		_entity.OnCastTo(ID, FromPos, ToPos, Duration);
	}

	void _48_OnCastFrom(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCastFrom(" + ", " + ID + ", " + Pos + ", " + Duration + ")");
		}
		_entity.OnCastFrom(ID, Pos, Duration);
	}

	void _49_OnHitVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitVisual(" + ", " + ID + ")");
		}
		_entity.OnHitVisual(ID);
	}

	void _50_OnHitVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitVisual(" + ", " + ID + ", " + Pos + ")");
		}
		_entity.OnHitVisual(ID, Pos);
	}

	void _51_OnHitVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		Int8 FromDir;
		ViGameSerializer<Int8>.Read(IS, out FromDir);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitVisual(" + ", " + ID + ", " + Pos + ", " + FromDir + ")");
		}
		_entity.OnHitVisual(ID, Pos, FromDir);
	}

	void _52_OnHitVisualShadow(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		Int8 FromDir;
		ViGameSerializer<Int8>.Read(IS, out FromDir);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitVisualShadow(" + ", " + ID + ", " + Pos + ", " + FromDir + ")");
		}
		_entity.OnHitVisualShadow(ID, Pos, FromDir);
	}

	void _53_OnLinkVisualStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float FlyDuration;
		ViGameSerializer<float>.Read(IS, out FlyDuration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualStart(" + ", " + ID + ", " + Visual + ", " + Pos + ", " + FlyDuration + ")");
		}
		_entity.OnLinkVisualStart(ID, Visual, Pos, FlyDuration);
	}

	void _54_OnLinkVisualStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		GameUnit Target;
		ViGameSerializer<GameUnit>.Read(IS, out Target);
		float FlyDuration;
		ViGameSerializer<float>.Read(IS, out FlyDuration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualStart(" + ", " + ID + ", " + Visual + ", " + Target + ", " + FlyDuration + ")");
		}
		_entity.OnLinkVisualStart(ID, Visual, Target, FlyDuration);
	}

	void _55_OnLinkVisualEnd(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualEnd(" + ", " + ID + ")");
		}
		_entity.OnLinkVisualEnd(ID);
	}

	void _56_OnLinkVisualEndFrom(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualEndFrom(" + ", " + ID + ", " + Duration + ")");
		}
		_entity.OnLinkVisualEndFrom(ID, Duration);
	}

	void _57_OnLinkVisualEndTo(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualEndTo(" + ", " + ID + ", " + Duration + ")");
		}
		_entity.OnLinkVisualEndTo(ID, Duration);
	}

	void _58_OnLinkVisualOnce(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		ViVector3 Pos;
		ViGameSerializer<ViVector3>.Read(IS, out Pos);
		float StartDuration;
		ViGameSerializer<float>.Read(IS, out StartDuration);
		float HoldDuration;
		ViGameSerializer<float>.Read(IS, out HoldDuration);
		float EndDuration;
		ViGameSerializer<float>.Read(IS, out EndDuration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualOnce(" + ", " + Visual + ", " + Pos + ", " + StartDuration + ", " + HoldDuration + ", " + EndDuration + ")");
		}
		_entity.OnLinkVisualOnce(Visual, Pos, StartDuration, HoldDuration, EndDuration);
	}

	void _59_OnLinkVisualOnce(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 Visual;
		ViGameSerializer<UInt32>.Read(IS, out Visual);
		GameUnit Target;
		ViGameSerializer<GameUnit>.Read(IS, out Target);
		float StartDuration;
		ViGameSerializer<float>.Read(IS, out StartDuration);
		float HoldDuration;
		ViGameSerializer<float>.Read(IS, out HoldDuration);
		float EndDuration;
		ViGameSerializer<float>.Read(IS, out EndDuration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLinkVisualOnce(" + ", " + Visual + ", " + Target + ", " + StartDuration + ", " + HoldDuration + ", " + EndDuration + ")");
		}
		_entity.OnLinkVisualOnce(Visual, Target, StartDuration, HoldDuration, EndDuration);
	}

	void _60_PlayActionAnim(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].PlayActionAnim(" + ", " + Name + ")");
		}
		_entity.PlayActionAnim(Name);
	}

	void _61_PlayStateAnim(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].PlayStateAnim(" + ", " + Name + ")");
		}
		_entity.PlayStateAnim(Name);
	}

	void _62_StopStateAnim(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].StopStateAnim(" + ", " + Name + ")");
		}
		_entity.StopStateAnim(Name);
	}

	void _63_OnCastVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt16 SendTime;
		ViGameSerializer<UInt16>.Read(IS, out SendTime);
		GameUnit TargetEntity;
		ViGameSerializer<GameUnit>.Read(IS, out TargetEntity);
		float Speed;
		ViGameSerializer<float>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCastVisual(" + ", " + ID + ", " + SendTime + ", " + TargetEntity + ", " + Speed + ")");
		}
		_entity.OnCastVisual(ID, SendTime, TargetEntity, Speed);
	}

	void _64_OnCastVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		UInt16 SendTime;
		ViGameSerializer<UInt16>.Read(IS, out SendTime);
		ViVector3 TargetPosition;
		ViGameSerializer<ViVector3>.Read(IS, out TargetPosition);
		float Speed;
		ViGameSerializer<float>.Read(IS, out Speed);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCastVisual(" + ", " + ID + ", " + SendTime + ", " + TargetPosition + ", " + Speed + ")");
		}
		_entity.OnCastVisual(ID, SendTime, TargetPosition, Speed);
	}

	void _65_OnHitEffectVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitEffectVisual(" + ", " + Attacker + ", " + ID + ")");
		}
		_entity.OnHitEffectVisual(Attacker, ID);
	}

	void _66_OnHitEffectVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		Int8 FromDir;
		ViGameSerializer<Int8>.Read(IS, out FromDir);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnHitEffectVisual(" + ", " + Attacker + ", " + ID + ", " + FromDir + ")");
		}
		_entity.OnHitEffectVisual(Attacker, ID, FromDir);
	}

	void _67_OnAreaHitEffectVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Attacker;
		ViGameSerializer<GameUnit>.Read(IS, out Attacker);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		ViVector3 Position;
		ViGameSerializer<ViVector3>.Read(IS, out Position);
		float Yaw;
		ViGameSerializer<float>.Read(IS, out Yaw);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnAreaHitEffectVisual(" + ", " + Attacker + ", " + ID + ", " + Position + ", " + Yaw + ")");
		}
		_entity.OnAreaHitEffectVisual(Attacker, ID, Position, Yaw);
	}

	void _68_AddAvatarDurationVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].AddAvatarDurationVisual(" + ", " + ID + ")");
		}
		_entity.AddAvatarDurationVisual(ID);
	}

	void _69_ClearAvatarDurationVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ClearAvatarDurationVisual(" + ")");
		}
		_entity.ClearAvatarDurationVisual();
	}

	void _70_ShowDriveVisual(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 ID;
		ViGameSerializer<UInt32>.Read(IS, out ID);
		float Duration;
		ViGameSerializer<float>.Read(IS, out Duration);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ShowDriveVisual(" + ", " + ID + ", " + Duration + ")");
		}
		_entity.ShowDriveVisual(ID, Duration);
	}

	void _71_PrintHoldResource(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].PrintHoldResource(" + ")");
		}
		_entity.PrintHoldResource();
	}

	void _72_ShootAura(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		GameUnit Caster;
		ViGameSerializer<GameUnit>.Read(IS, out Caster);
		UInt32 AuraID;
		ViGameSerializer<UInt32>.Read(IS, out AuraID);
		ViVector3 TargetPos;
		ViGameSerializer<ViVector3>.Read(IS, out TargetPos);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ShootAura(" + ", " + Caster + ", " + AuraID + ", " + TargetPos + ")");
		}
		_entity.ShootAura(Caster, AuraID, TargetPos);
	}

	protected new GameUnit _entity;
}
