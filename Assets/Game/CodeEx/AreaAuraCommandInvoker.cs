using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AreaAuraCommandInvoker : ViEntityCommandInvoker<AreaAura>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc("/OnHitEffectVisual", Client_0_OnHitEffectVisual);
		AddFunc("/OnHitEffectVisual", Client_1_OnHitEffectVisual);
		AddFunc("/OnEmptyExploreVisual", Client_2_OnEmptyExploreVisual);
		AddFunc("/OnUpdateYaw", Client_3_OnUpdateYaw);
		AddFunc("/OnMoveTo", Client_4_OnMoveTo);
		AddFunc("/OnMoveTo", Client_5_OnMoveTo);
		AddFunc("/OnMoveTo", Client_6_OnMoveTo);
		AddFunc("/OnBreakMove", Client_7_OnBreakMove);
		AddFunc("/OnUpdateSpeed", Client_8_OnUpdateSpeed);
	}
	public static new bool Exec(AreaAura entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<AreaAura>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		AreaAura deriveEntity = entity as AreaAura;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	static bool Client_0_OnHitEffectVisual(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 VisualID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out VisualID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitEffectVisual(VisualID);
		return true;
	}
	static bool Client_1_OnHitEffectVisual(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 VisualID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out VisualID) == false) { return false; }
		ViVector3 Position = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Position) == false) { return false; }
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitEffectVisual(VisualID, Position, Yaw);
		return true;
	}
	static bool Client_2_OnEmptyExploreVisual(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnEmptyExploreVisual();
		return true;
	}
	static bool Client_3_OnUpdateYaw(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Yaw = default(float); if (ViGameSerializer<float>.Read(IS, out Yaw) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateYaw(Yaw);
		return true;
	}
	static bool Client_4_OnMoveTo(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Dest = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Dest) == false) { return false; }
		float Speed = default(float); if (ViGameSerializer<float>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnMoveTo(Dest, Speed);
		return true;
	}
	static bool Client_5_OnMoveTo(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		List<ViVector3> PosList = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PosList) == false) { return false; }
		float Speed = default(float); if (ViGameSerializer<float>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnMoveTo(PosList, Speed);
		return true;
	}
	static bool Client_6_OnMoveTo(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 ResetPos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out ResetPos) == false) { return false; }
		List<ViVector3> PosList = default(List<ViVector3>); if (ViGameSerializer<ViVector3>.Read(IS, out PosList) == false) { return false; }
		float Speed = default(float); if (ViGameSerializer<float>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnMoveTo(ResetPos, PosList, Speed);
		return true;
	}
	static bool Client_7_OnBreakMove(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViVector3 Pos = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Pos) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnBreakMove(Pos);
		return true;
	}
	static bool Client_8_OnUpdateSpeed(AreaAura entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		float Speed = default(float); if (ViGameSerializer<float>.Read(IS, out Speed) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnUpdateSpeed(Speed);
		return true;
	}
}
