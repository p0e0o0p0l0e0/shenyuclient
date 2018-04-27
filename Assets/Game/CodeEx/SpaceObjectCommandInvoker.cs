using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceObjectCommandInvoker : ViEntityCommandInvoker<SpaceObject>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc("/OnHitEffectVisual", Client_0_OnHitEffectVisual);
		AddFunc("/OnHitEffectVisual", Client_1_OnHitEffectVisual);
		AddFunc("/OnLoot", Client_2_OnLoot);
		AddFunc("/OnDie", Client_3_OnDie);
	}
	public static new bool Exec(SpaceObject entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<SpaceObject>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		SpaceObject deriveEntity = entity as SpaceObject;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	static bool Client_0_OnHitEffectVisual(SpaceObject entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 VisualID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out VisualID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitEffectVisual(VisualID);
		return true;
	}
	static bool Client_1_OnHitEffectVisual(SpaceObject entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 VisualID = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out VisualID) == false) { return false; }
		ViVector3 Position = default(ViVector3); if (ViGameSerializer<ViVector3>.Read(IS, out Position) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnHitEffectVisual(VisualID, Position);
		return true;
	}
	static bool Client_2_OnLoot(SpaceObject entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		CellHero Owner = default(CellHero); if (ViGameSerializer<CellHero>.Read(IS, out Owner) == false) { return false; }
		Int32 XP = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out XP) == false) { return false; }
		Int32 YinPiao = default(Int32); if (ViGameSerializer<Int32>.Read(IS, out YinPiao) == false) { return false; }
		List<ItemCountProperty> LootList = default(List<ItemCountProperty>); if (ViGameSerializer<ItemCountProperty>.Read(IS, out LootList) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnLoot(Owner, XP, YinPiao, LootList);
		return true;
	}
	static bool Client_3_OnDie(SpaceObject entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnDie();
		return true;
	}
}
